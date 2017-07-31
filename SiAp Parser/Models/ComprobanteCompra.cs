using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAp_Parser.Extensions;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Models
{
    public class ComprobanteCompra : Comprobante
    {
        private const ushort CANTIDAD_CARACTERES_COMPROBANTES_COMPRAS = 325;
        public ComprobanteCompra()
        {
            DespachoImportacion = string.Empty;
            ImportePercepcionesIVA = 0;
            CreditoFiscalComputable = 0;
            CUITEmisor = "0";
            DenominacionEmisor = string.Empty;
            IVAComision = 0;
            Alicuotas = new List<AlicuotaCompra>();
        }

        public ComprobanteCompra(ComprobanteCompra c) : base(c)
        {
            DespachoImportacion = c.DespachoImportacion;
            ImportePercepcionesIVA = c.ImportePercepcionesIVA;
            CreditoFiscalComputable = c.CreditoFiscalComputable;
            CUITEmisor = c.CUITEmisor;
            DenominacionEmisor = c.DenominacionEmisor;
            IVAComision = c.IVAComision;
            Alicuotas = c.Alicuotas;
        }

        public new bool EsValido { get { return VerificarValidez(); } }

        private bool VerificarValidez()
        {
            decimal calculatedTotal = 0;

            calculatedTotal += ImporteConceptosNoIntegranElNetoGravado;
            calculatedTotal += ImporteOperacionesExentas;
            calculatedTotal += ImportePercepcionesImpuestosNacionales;
            calculatedTotal += ImporteIngresosBrutos;
            calculatedTotal += ImporteImpuestosMunicipales;
            calculatedTotal += ImporteImpuestosInternos;

            if (Tipo != TipoComprobante.FACTURAS_C && Tipo != TipoComprobante.NOTAS_DE_CREDITO_C)
                foreach (var a in Alicuotas)
                    calculatedTotal += a.ImporteNeto + a.ImpuestoLiquidado;

            return
                ImporteTotal.AlmostEquals(calculatedTotal, 2) ||
                ImporteTotal.GreaterThanOrEqualTo(calculatedTotal, 2) ||
                ImporteTotal.LessThanOrEqualTo(calculatedTotal, 2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Fecha.ToString("yyyyMMdd"));
            sb.Append(((int)Tipo).ToString("D3"));
            sb.Append(PuntoDeVenta.ToString("D5"));
            sb.Append(Numero.ToString("D20"));
            sb.Append(DespachoImportacion.PadLeft(16, ' '));
            sb.Append((int)CodigoDocumentoContratante);
            sb.Append(NumeroIdentificacionContratante.PadLeft(20, '0'));
            sb.Append(Contratante.PadRight(30, ' '));
            sb.Append(ImporteTotal.ToSIApFormat());
            sb.Append(ImporteConceptosNoIntegranElNetoGravado.ToSIApFormat());
            sb.Append(ImporteOperacionesExentas.ToSIApFormat());
            sb.Append(ImportePercepcionesIVA.ToSIApFormat());
            sb.Append(ImportePercepcionesImpuestosNacionales.ToSIApFormat());
            sb.Append(ImporteIngresosBrutos.ToSIApFormat());
            sb.Append(ImporteImpuestosMunicipales.ToSIApFormat());
            sb.Append(ImporteImpuestosInternos.ToSIApFormat());
            sb.Append(CodigoMoneda);
            sb.Append(TipoCambio.ToSIApFormat("0000.000000", 10));
            sb.Append(CantidadAlicuotasIVA);
            sb.Append(CodigoOperacion.PadLeft(1, ' '));
            sb.Append(CreditoFiscalComputable.ToSIApFormat());
            sb.Append(OtrosTributos.ToSIApFormat());
            sb.Append(CUITEmisor.PadLeft(11, '0'));
            sb.Append(DenominacionEmisor.PadRight(30, ' '));
            sb.Append(IVAComision.ToSIApFormat());

            var comprobanteStr = sb.ToString();

            if(comprobanteStr.Length != CANTIDAD_CARACTERES_COMPROBANTES_COMPRAS)
            {
                return string.Empty;
            }

            return comprobanteStr;
        }

        public string DespachoImportacion { get; set; }

        private decimal _importePercepcionesIVA;
        public decimal ImportePercepcionesIVA
        {
            get { return _importePercepcionesIVA; }
            set
            {
                if (value <= 0)
                    return;
                _importePercepcionesIVA = value;
            }
        }

        public new List<AlicuotaCompra> Alicuotas { get; set; }
        public decimal CreditoFiscalComputable { get; set; }
        public string CUITEmisor { get; set; }
        public string DenominacionEmisor { get; set; }
        public decimal IVAComision { get; set; }
    }
}