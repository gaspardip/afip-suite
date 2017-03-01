using System;
using System.Collections.Generic;
using System.Linq;
using SiAp_Parser.Enums;
using System.Text.RegularExpressions;

namespace SiAp_Parser.Models
{
    public abstract class Comprobante
    {
        public Comprobante()
        {
            Fecha = DateTime.Now;
            Tipo = TipoComprobante.OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF;
            PuntoDeVenta = 1;
            Numero = 0;
            CodigoDocumentoContratante = CodigosDocumentos.C_U_I_T;
            NumeroIdentificacionContratante = "0";
            Contratante = string.Empty;
            ImporteTotal = 0;
            ImporteConceptosNoIntegranElNetoGravado = 0;
            ImporteOperacionesExentas = 0;
            ImportePercepcionesImpuestosNacionales = 0;
            ImporteIngresosBrutos = 0;
            ImporteImpuestosMunicipales = 0;
            ImporteImpuestosInternos = 0;
            CodigoMoneda = Monedas.PESOS_ARGENTINOS;
            TipoCambio = 1;
            CantidadAlicuotasIVA = 0;
            Alicuotas = new List<Alicuota>();
            CodigoOperacion = string.Empty;
            OtrosTributos = 0;
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
            ImporteConceptosNoIntegranElNetoGravado = c.ImporteConceptosNoIntegranElNetoGravado;
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

        public bool EsValido { get; set; }

        public DateTime Fecha { get; set; }

        private TipoComprobante _tipo;
        public dynamic Tipo
        {
            get { return _tipo; }
            set
            {
                if (value is string)
                {
                    if (string.IsNullOrEmpty(value))
                        return;

                    string[] parts;
                    string finalTypeStr = string.Empty;

                    parts = Regex.Replace(value, @"([,.-]*)(?:Poliza)?", string.Empty, RegexOptions.IgnoreCase).Split(' ');
                    parts = parts.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                    switch (parts.Length)
                    {
                        // FA
                        case 1:
                            // Fc
                            if (parts[0].Length == 2)
                                finalTypeStr = parts[0].Substring(0, 1) + "-" + "A";
                            else
                                finalTypeStr = parts[0].Substring(0, 1) + "-" + parts[0].Substring(1, 1);
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
                    }

                    finalTypeStr = finalTypeStr.ToUpper();

                    switch (finalTypeStr)
                    {
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
                }
                else if (value is TipoComprobante)
                {
                    _tipo = value;
                }
            }
        }

        private short _puntoDeVenta;
        public short PuntoDeVenta
        {
            get { return _puntoDeVenta; }
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
            get { return _numero; }
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
            get { return _numeroIdentificacionContratante; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                _numeroIdentificacionContratante = value.IndexOf('-') != -1 ? string.Concat(value.Split('-')) : value;
            }
        }

        private string _contratante;
        public string Contratante
        {
            get { return _contratante; }
            set
            {
                value = Regex.Replace(value, @"[^\u0000-\u007F]+", string.Empty);
                _contratante = (value.Length <= 30 ? value : value.Substring(0, 30)).ToUpper();
            }
        }
        public decimal ImporteTotal { get; set; }

        private decimal _importeConceptosNoIntegranElNetoGravado;
        public decimal ImporteConceptosNoIntegranElNetoGravado
        {
            get { return _importeConceptosNoIntegranElNetoGravado; }
            set
            {
                if (value < 0)
                    return;
                _importeConceptosNoIntegranElNetoGravado = value;
            }
        }

        private decimal _importeOperacionesExentas;
        public decimal ImporteOperacionesExentas
        {
            get { return _importeOperacionesExentas; }
            set
            {
                if (value < 0)
                    return;
                _importeOperacionesExentas = value;
            }
        }

        private decimal _importePercepcionesImpuestosNacionales;
        public decimal ImportePercepcionesImpuestosNacionales
        {
            get { return _importePercepcionesImpuestosNacionales; }
            set
            {
                if (value < 0)
                    return;
                _importePercepcionesImpuestosNacionales = value;
            }
        }

        private decimal _importeIngresosBrutos;
        public decimal ImporteIngresosBrutos
        {
            get { return _importeIngresosBrutos; }
            set
            {
                if (value < 0)
                    return;
                _importeIngresosBrutos = value;
            }
        }

        private decimal _importeImpuestosMunicipales;
        public decimal ImporteImpuestosMunicipales
        {
            get { return _importeImpuestosMunicipales; }
            set
            {
                if (value < 0)
                    return;
                _importeImpuestosMunicipales = value;
            }
        }

        private decimal _importeImpuestosInternos;
        public decimal ImporteImpuestosInternos
        {
            get { return _importeImpuestosInternos; }
            set
            {
                if (value < 0)
                    return;
                _importeImpuestosInternos = value;
            }
        }

        public string CodigoMoneda { get; set; }
        public decimal TipoCambio { get; set; }
        public ushort CantidadAlicuotasIVA { get; set; }
        public List<Alicuota> Alicuotas { get; set; }
        public string CodigoOperacion { get; set; }
        public decimal OtrosTributos { get; set; }
    }
}