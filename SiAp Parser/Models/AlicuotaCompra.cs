using System.Text;
using SiAp_Parser.Enums;
using SiAp_Parser.Extensions;

namespace SiAp_Parser
{
    public class AlicuotaCompra : Alicuota
    {
        public AlicuotaCompra()
        {
            this.TipoComprobante = TipoComprobante.OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF;
            this.PuntoDeVenta = 1;
            this.NumeroComprobante = 0;
            this.CodigoDocumentoContratante = CodigosDocumentos.C_U_I_T;
            this.NumeroIdentificacionContratante = "0";
            this.ImporteNeto = 0;
            this.Porcentaje = 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(((int)this.TipoComprobante).ToString("D3"));
            sb.Append(this.PuntoDeVenta.ToString("D5"));
            sb.Append(this.NumeroComprobante.ToString("D20"));
            sb.Append((int)this.CodigoDocumentoContratante);
            sb.Append(this.NumeroIdentificacionContratante.PadLeft(20, '0'));
            sb.Append(this.ImporteNeto.ToSIApFormat());
            sb.Append(this.Tipo.ToString("D4"));
            sb.Append(this.ImpuestoLiquidado.ToSIApFormat());

            return sb.ToString();
        }
    }
}