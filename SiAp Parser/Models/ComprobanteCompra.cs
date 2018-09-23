using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAP.Parser.Enums;
using SIAP.Parser.Extensions;

namespace SIAP.Parser.Models
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
            sb.Append(ImporteNoGravados.ToSIApFormat());
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
                return string.Empty;

            return comprobanteStr;
        }

        public string DespachoImportacion { get; set; }

        private double _importePercepcionesIVA;
        public double ImportePercepcionesIVA
        {
            get => _importePercepcionesIVA;
            set
            {
                if (value <= 0)
                    return;

                _importePercepcionesIVA = value;
            }
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

        public new List<AlicuotaCompra> Alicuotas { get; set; }
        public double CreditoFiscalComputable { get; set; }
        public string CUITEmisor { get; set; }
        public string DenominacionEmisor { get; set; }
        public double IVAComision { get; set; }
    }
}