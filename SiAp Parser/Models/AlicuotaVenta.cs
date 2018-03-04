using System.Text;
using SiAp_Parser.Extensions;

namespace SiAp_Parser.Models
{
    public class AlicuotaVenta : Alicuota
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(((int)TipoComprobante).ToString("D3"));
            sb.Append(PuntoDeVenta.ToString("D5"));
            sb.Append(NumeroComprobante.ToString("D20"));
            sb.Append(ImporteNeto.ToSIApFormat());
            sb.Append(Tipo.ToString("D4"));
            sb.Append(ImpuestoLiquidado.ToSIApFormat());

            string alicuotaStr = sb.ToString();

            if(alicuotaStr.Length != CANTIDAD_CARACTERES_ALICUOTAS_VENTAS)
            {
                // report ?
            }

            return alicuotaStr;
        }

        private const ushort CANTIDAD_CARACTERES_ALICUOTAS_VENTAS = 62;
    }
}
