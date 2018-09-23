using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SIAP.Parser.Enums;

namespace SIAP.Parser.Models
{
    public abstract class Comprobante
    {
        public Comprobante()
        {
            Fecha = DateTime.Now;
            Tipo = TipoComprobante.OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF;
            PuntoDeVenta = 1;
            CodigoDocumentoContratante = CodigosDocumentos.C_U_I_T;
            NumeroIdentificacionContratante = "0";
            Contratante = string.Empty;
            CodigoMoneda = Monedas.PESOS_ARGENTINOS;
            TipoCambio = 1;
            Alicuotas = new List<Alicuota>();
            CodigoOperacion = string.Empty;
        }

        public Comprobante(Comprobante c)
        {
            Fecha = c.Fecha;
            Tipo = c.Tipo;
            PuntoDeVenta = c.PuntoDeVenta;
            Numero = c.Numero;
            CodigoDocumentoContratante = c.CodigoDocumentoContratante;
            NumeroIdentificacionContratante = c.NumeroIdentificacionContratante;
            Contratante = c.Contratante;
            ImporteTotal = c.ImporteTotal;
            ImporteNoGravados = c.ImporteNoGravados;
            ImporteOperacionesExentas = c.ImporteOperacionesExentas;
            ImportePercepcionesImpuestosNacionales = c.ImportePercepcionesImpuestosNacionales;
            ImporteIngresosBrutos = c.ImporteIngresosBrutos;
            ImporteImpuestosMunicipales = c.ImporteImpuestosMunicipales;
            ImporteImpuestosInternos = c.ImporteImpuestosInternos;
            CodigoMoneda = c.CodigoMoneda;
            TipoCambio = c.TipoCambio;
            CantidadAlicuotasIVA = c.CantidadAlicuotasIVA;
            Alicuotas = c.Alicuotas;
            CodigoOperacion = c.CodigoOperacion;
            OtrosTributos = c.OtrosTributos;
        }

        public bool Es(GrupoComprobante gc)
        {
            switch (gc)
            {
                case GrupoComprobante.FACTURA:
                    return
                        Tipo == TipoComprobante.FACTURAS_A ||
                        Tipo == TipoComprobante.FACTURAS_B ||
                        Tipo == TipoComprobante.FACTURAS_C ||
                        Tipo == TipoComprobante.FACTURAS_M;
                case GrupoComprobante.NOTA_DE_CREDITO:
                    return
                        Tipo == TipoComprobante.NOTAS_DE_CREDITO_A ||
                        Tipo == TipoComprobante.NOTAS_DE_CREDITO_B ||
                        Tipo == TipoComprobante.NOTAS_DE_CREDITO_C ||
                        Tipo == TipoComprobante.NOTAS_DE_CREDITO_M;
                default:
                    return false;
            }
        }

        public abstract double ImpuestoLiquidadoTotal { get; }

        public bool EsValido { get; protected set; }

        public DateTime Fecha { get; set; }

        private TipoComprobante _tipo;
        public dynamic Tipo
        {
            get => _tipo;
            set
            {
                switch (value)
                {
                    case string _:
                        if (string.IsNullOrEmpty(value))
                            return;

                        string[] parts;
                        string finalTypeStr;

                        parts = Regex.Replace(value, @"(["",.-]*)(?:poliza)?", string.Empty, RegexOptions.IgnoreCase).Split(' ');
                        parts = parts.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                        switch (parts.Length)
                        {
                            // FA
                            case 1:
                                // Fc
                                switch(parts[0].Length)
                                {
                                    // Just A...
                                    case 1:
                                        finalTypeStr = "FC-" + parts[0];
                                        break;
                                    case 2:
                                        finalTypeStr = parts[0].Substring(0, 1) + "-" + parts[0].Substring(1, 1);
                                        break;
                                    case 3:
                                        finalTypeStr = parts[0].Substring(0, 2) + "-" + parts[0].Substring(2, 1);
                                        break;
                                    default:
                                        finalTypeStr = parts[0].Substring(0, 1);
                                        break;
                                }
                                break;
                            // Factura A
                            case 2:
                                // NC A
                                if (parts[0].Length == 2)
                                    finalTypeStr = parts[0] + "-" + parts[1];
                                else
                                    finalTypeStr = parts[0].Substring(0, 1) + "-" + parts[1];
                                break;
                            // Tique factura A
                            case 3:
                                finalTypeStr = parts[0].Substring(0, 1) + parts[1].Substring(0, 1) + "-" + parts[2];
                                break;
                            // Nota de crédito A
                            case 4:
                                finalTypeStr = parts[0].Substring(0, 1) + parts[2].Substring(0, 1) + "-" + parts[3];
                                break;
                            // Nota de venta al contado A
                            case 5:
                                finalTypeStr = parts[0].Substring(0, 1) + parts[2].Substring(0, 1) + parts[4].Substring(0, 1) + "-" + parts[5];
                                break;
                            default:
                                _tipo = TipoComprobante.OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF;
                                return;
                        }

                        finalTypeStr = finalTypeStr.ToUpper();

                        switch (finalTypeStr)
                        {
                            case "T":
                                _tipo = TipoComprobante.TIQUE;
                                break;
                            case "F-A":
                            case "FC-A":
                                _tipo = TipoComprobante.FACTURAS_A;
                                break;
                            case "ND-A":
                                _tipo = TipoComprobante.NOTAS_DE_DEBITO_A;
                                break;
                            case "NC-A":
                                _tipo = TipoComprobante.NOTAS_DE_CREDITO_A;
                                break;
                            case "R-A":
                                _tipo = TipoComprobante.RECIBOS_A;
                                break;
                            case "NVC-A":
                                _tipo = TipoComprobante.NOTAS_DE_VENTA_AL_CONTADO_A;
                                break;
                            case "TF-A":
                                _tipo = TipoComprobante.TIQUE_FACTURA_A_CONTROLADORES_FISCALES;
                                break;
                            case "F-B":
                            case "FC-B":
                                _tipo = TipoComprobante.FACTURAS_B;
                                break;
                            case "ND-B":
                                _tipo = TipoComprobante.NOTAS_DE_DEBITO_B;
                                break;
                            case "NC-B":
                                _tipo = TipoComprobante.NOTAS_DE_CREDITO_B;
                                break;
                            case "R-B":
                                _tipo = TipoComprobante.RECIBOS_B;
                                break;
                            case "NVC-B":
                                _tipo = TipoComprobante.NOTAS_DE_VENTA_AL_CONTADO_B;
                                break;
                            case "TF-B":
                                _tipo = TipoComprobante.TIQUE_FACTURA_B;
                                break;
                            case "F-C":
                            case "FC-C":
                                _tipo = TipoComprobante.FACTURAS_C;
                                break;
                            case "ND-C":
                                _tipo = TipoComprobante.NOTAS_DE_DEBITO_C;
                                break;
                            case "NC-C":
                                _tipo = TipoComprobante.NOTAS_DE_CREDITO_C;
                                break;
                            case "R-C":
                                _tipo = TipoComprobante.RECIBOS_C;
                                break;
                            case "NVC-C":
                                _tipo = TipoComprobante.NOTAS_DE_VENTA_AL_CONTADO_C;
                                break;
                            case "TF-C":
                                _tipo = TipoComprobante.TIQUE_FACTURA_C;
                                break;
                        }

                        break;
                    case TipoComprobante _:
                        _tipo = value;
                        break;
                }
            }
        }

        private short _puntoDeVenta;
        public short PuntoDeVenta
        {
            get => _puntoDeVenta;
            set
            {
                if (value < 0)
                    return;

                _puntoDeVenta = value;
            }
        }

        private int _numero;
        public int Numero
        {
            get => _numero;
            set
            {
                if (value < 0)
                    return;

                _numero = value;
            }
        }

        public CodigosDocumentos CodigoDocumentoContratante { get; set; }

        private string _numeroIdentificacionContratante;
        public string NumeroIdentificacionContratante
        {
            get => _numeroIdentificacionContratante;
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                _numeroIdentificacionContratante = Regex.Replace(value, @"[^\d]", string.Empty);
            }
        }

        private string _contratante;
        public string Contratante
        {
            get => _contratante;
            set
            {
                value = Regex.Replace(value, @"[^\u0000-\u007F]+", string.Empty);
                _contratante = (value.Length <= 30 ? value : value.Substring(0, 30)).ToUpper();
            }
        }
        public double ImporteTotal { get; set; }

        private double _importeNoGravados;
        public double ImporteNoGravados
        {
            get => _importeNoGravados;
            set
            {
                if (value < 0)
                    return;

                _importeNoGravados = value;
            }
        }

        private double _importeOperacionesExentas;
        public double ImporteOperacionesExentas
        {
            get => _importeOperacionesExentas;
            set
            {
                if (value < 0)
                    return;

                _importeOperacionesExentas = value;
            }
        }

        private double _importePercepcionesImpuestosNacionales;
        public double ImportePercepcionesImpuestosNacionales
        {
            get => _importePercepcionesImpuestosNacionales;
            set
            {
                if (value < 0)
                    return;
                _importePercepcionesImpuestosNacionales = value;
            }
        }

        private double _importeIngresosBrutos;
        public double ImporteIngresosBrutos
        {
            get => _importeIngresosBrutos;
            set
            {
                if (value < 0)
                    return;

                _importeIngresosBrutos = value;
            }
        }

        private double _importeImpuestosMunicipales;
        public double ImporteImpuestosMunicipales
        {
            get => _importeImpuestosMunicipales;
            set
            {
                if (value < 0)
                    return;

                _importeImpuestosMunicipales = value;
            }
        }

        private double _importeImpuestosInternos;
        public double ImporteImpuestosInternos
        {
            get => _importeImpuestosInternos;
            set
            {
                if (value < 0)
                    return;

                _importeImpuestosInternos = value;
            }
        }

        public string CodigoMoneda { get; set; }
        public double TipoCambio { get; set; }
        public ushort CantidadAlicuotasIVA { get; set; }
        public List<Alicuota> Alicuotas { get; set; }
        public string CodigoOperacion { get; set; }
        public double OtrosTributos { get; set; }
    }
}