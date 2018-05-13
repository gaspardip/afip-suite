using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SiAp_Parser.Extensions;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Models
{
    public class ComprobanteVenta : Comprobante
    {
        #region Constructors
        public ComprobanteVenta()
        {
            NumeroHasta = 0;
            ImportePercepcionNoCategorizados = 0;
            FechaVencimientoPago = Fecha;
            Alicuotas = new List<AlicuotaVenta>();
        }

        public ComprobanteVenta(Comprobante c) : this()
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
            OtrosTributos = 0;
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Fecha.ToString("yyyyMMdd"));
            sb.Append(((int)Tipo).ToString("D3"));
            sb.Append(PuntoDeVenta.ToString("D5"));
            sb.Append(Numero.ToString("D20"));
            sb.Append(NumeroHasta.ToString("D20"));
            sb.Append((int)CodigoDocumentoContratante);
            sb.Append(NumeroIdentificacionContratante.PadLeft(20, '0'));
            sb.Append(Contratante.PadRight(30, ' '));
            sb.Append(ImporteTotal.ToSIApFormat());
            sb.Append(ImporteNoGravados.ToSIApFormat());
            sb.Append(ImportePercepcionNoCategorizados.ToSIApFormat());
            sb.Append(ImporteOperacionesExentas.ToSIApFormat());
            sb.Append(ImportePercepcionesImpuestosNacionales.ToSIApFormat());
            sb.Append(ImporteIngresosBrutos.ToSIApFormat());
            sb.Append(ImporteImpuestosMunicipales.ToSIApFormat());
            sb.Append(ImporteImpuestosInternos.ToSIApFormat());
            sb.Append(CodigoMoneda);
            sb.Append(TipoCambio.ToSIApFormat("0000.000000", 10));
            sb.Append(CantidadAlicuotasIVA);
            sb.Append(CodigoOperacion.PadLeft(1, ' '));
            sb.Append(OtrosTributos.ToSIApFormat());
            sb.Append(FechaVencimientoPago.ToString("yyyyMMdd"));

            var comprobanteStr = sb.ToString();

            if (comprobanteStr.Length != CANTIDAD_CARACTERES_COMPROBANTES_VENTAS)
            {
                // Report error here
            }

            return comprobanteStr;
        }

        #region Constants

        private const ushort CANTIDAD_CARACTERES_COMPROBANTES_VENTAS = 266;

        #endregion

        #region Properties

        public new bool EsValido => VerificarValidez();

        private bool VerificarValidez()
        {
            double calculatedTotal = 0;

            calculatedTotal += ImporteNoGravados;
            calculatedTotal += ImporteOperacionesExentas;
            calculatedTotal += ImportePercepcionesImpuestosNacionales;
            calculatedTotal += ImporteIngresosBrutos;
            calculatedTotal += ImporteImpuestosMunicipales;
            calculatedTotal += ImporteImpuestosInternos;
            calculatedTotal += ImportePercepcionNoCategorizados;

            if (Tipo != TipoComprobante.FACTURAS_C && Tipo != TipoComprobante.NOTAS_DE_CREDITO_C)
            {
                foreach (var a in Alicuotas)
                {
                    calculatedTotal += a.ImporteNeto + a.ImpuestoLiquidado;
                }
            }

            return
                ImporteTotal.AlmostEquals(calculatedTotal, 2) ||
                ImporteTotal.GreaterThanOrEqualTo(calculatedTotal, 2) ||
                ImporteTotal.LessThanOrEqualTo(calculatedTotal, 2);
        }

        public override double ImpuestoLiquidadoTotal
        {
            get
            {
                if (Alicuotas.Count == 0)
                    return 0;

                return Alicuotas
                    .Select(a => a.ImpuestoLiquidado)
                    .Aggregate((acc, x) => acc + x);
            }
        }

        public int NumeroHasta { get; set; }
        public double ImportePercepcionNoCategorizados { get; set; }
        public DateTime FechaVencimientoPago { get; set; }
        public new List<AlicuotaVenta> Alicuotas { get; set; }

        #endregion
    }
}
