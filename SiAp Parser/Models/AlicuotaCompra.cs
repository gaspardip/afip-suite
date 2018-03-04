using System.Text;
using SiAp_Parser.Enums;
using SiAp_Parser.Extensions;

namespace SiAp_Parser
{
    public class AlicuotaCompra : Alicuota
    {
        public AlicuotaCompra()
        {
            TipoComprobante = TipoComprobante.OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF;
            PuntoDeVenta = 1;
            NumeroComprobante = 0;
            CodigoDocumentoContratante = CodigosDocumentos.C_U_I_T;
            NumeroIdentificacionContratante = "0";
            ImporteNeto = 0;
            Porcentaje = 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(((int)TipoComprobante).ToString("D3"));
            sb.Append(PuntoDeVenta.ToString("D5"));
            sb.Append(NumeroComprobante.ToString("D20"));
            sb.Append((int)CodigoDocumentoContratante);
            sb.Append(NumeroIdentificacionContratante.PadLeft(20, '0'));
            sb.Append(ImporteNeto.ToSIApFormat());
            sb.Append(Tipo.ToString("D4"));
            sb.Append(ImpuestoLiquidado.ToSIApFormat());

            return sb.ToString();
        }
    }
}