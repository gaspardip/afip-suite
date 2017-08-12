using System;
using System.Collections.Generic;
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
            this.NumeroHasta = 0;
            this.ImportePercepcionNoCategorizados = 0;
            this.FechaVencimientoPago = this.Fecha;
            this.Alicuotas = new List<AlicuotaVenta>();
        }

        public ComprobanteVenta(Comprobante c) : this()
        {
            this.Fecha = c.Fecha;
            this.Tipo = c.Tipo;
            this.PuntoDeVenta = c.PuntoDeVenta;
            this.Numero = c.Numero;
            this.CodigoDocumentoContratante = c.CodigoDocumentoContratante;
            this.NumeroIdentificacionContratante = c.NumeroIdentificacionContratante;
            this.Contratante = c.Contratante;
            this.ImporteTotal = c.ImporteTotal;
            this.ImporteConceptosNoIntegranElNetoGravado = c.ImporteConceptosNoIntegranElNetoGravado;
            this.ImporteOperacionesExentas = c.ImporteOperacionesExentas;
            this.ImportePercepcionesImpuestosNacionales = c.ImportePercepcionesImpuestosNacionales;
            this.ImporteIngresosBrutos = c.ImporteIngresosBrutos;
            this.ImporteImpuestosMunicipales = c.ImporteImpuestosMunicipales;
            this.ImporteImpuestosInternos = c.ImporteImpuestosInternos;
            this.CodigoMoneda = c.CodigoMoneda;
            this.TipoCambio = c.TipoCambio;
            this.CantidadAlicuotasIVA = c.CantidadAlicuotasIVA;
            this.OtrosTributos = 0;
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(this.Fecha.ToString("yyyyMMdd"));
            sb.Append(((int)this.Tipo).ToString("D3"));
            sb.Append(this.PuntoDeVenta.ToString("D5"));
            sb.Append(this.Numero.ToString("D20"));
            sb.Append(this.NumeroHasta.ToString("D20"));
            sb.Append((int)this.CodigoDocumentoContratante);
            sb.Append(this.NumeroIdentificacionContratante.PadLeft(20, '0'));
            sb.Append(this.Contratante.PadRight(30, ' '));
            sb.Append(this.ImporteTotal.ToSIApFormat());
            sb.Append(this.ImporteConceptosNoIntegranElNetoGravado.ToSIApFormat());
            sb.Append(this.ImportePercepcionNoCategorizados.ToSIApFormat());
            sb.Append(this.ImporteOperacionesExentas.ToSIApFormat());
            sb.Append(this.ImportePercepcionesImpuestosNacionales.ToSIApFormat());
            sb.Append(this.ImporteIngresosBrutos.ToSIApFormat());
            sb.Append(this.ImporteImpuestosMunicipales.ToSIApFormat());
            sb.Append(this.ImporteImpuestosInternos.ToSIApFormat());
            sb.Append(this.CodigoMoneda);
            sb.Append(this.TipoCambio.ToSIApFormat("0000.000000", 10));
            sb.Append(this.CantidadAlicuotasIVA);
            sb.Append(this.CodigoOperacion.PadLeft(1, ' '));
            sb.Append(this.OtrosTributos.ToSIApFormat());
            sb.Append(this.FechaVencimientoPago.ToString("yyyyMMdd"));

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

        public new bool EsValido { get { return this.VerificarValidez(); } }

        private bool VerificarValidez()
        {
            decimal calculatedTotal = 0;

            calculatedTotal += this.ImporteConceptosNoIntegranElNetoGravado;
            calculatedTotal += this.ImporteOperacionesExentas;
            calculatedTotal += this.ImportePercepcionesImpuestosNacionales;
            calculatedTotal += this.ImporteIngresosBrutos;
            calculatedTotal += this.ImporteImpuestosMunicipales;
            calculatedTotal += this.ImporteImpuestosInternos;
            calculatedTotal += this.ImportePercepcionNoCategorizados;

            if (this.Tipo != TipoComprobante.FACTURAS_C && this.Tipo != TipoComprobante.NOTAS_DE_CREDITO_C)
            {
                foreach (var a in this.Alicuotas)
                {
                    calculatedTotal += a.ImporteNeto + a.ImpuestoLiquidado;
                }
            }

            return
                this.ImporteTotal.AlmostEquals(calculatedTotal, 2) ||
                this.ImporteTotal.GreaterThanOrEqualTo(calculatedTotal, 2) ||
                this.ImporteTotal.LessThanOrEqualTo(calculatedTotal, 2);
        }

        public int NumeroHasta { get; set; }
        public decimal ImportePercepcionNoCategorizados { get; set; }
        public DateTime FechaVencimientoPago { get; set; }
        public new List<AlicuotaVenta> Alicuotas { get; set; }

        #endregion
    }
}
