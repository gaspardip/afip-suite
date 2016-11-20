using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAp_Parser.Extensions;

namespace SiAp_Parser.Models
{
    public class AlicuotaVenta : Alicuota
    {
        public AlicuotaVenta()
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(((int)this.TipoComprobante).ToString("D3"));
            sb.Append(this.PuntoDeVenta.ToString("D5"));
            sb.Append(this.NumeroComprobante.ToString("D20"));
            sb.Append(this.ImporteNeto.ToSIApFormat());
            sb.Append(this.Tipo.ToString("D4"));
            sb.Append(this.ImpuestoLiquidado.ToSIApFormat());

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
