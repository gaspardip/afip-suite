using System.Text;
using SiAp_Parser.Enums;
using SiAp_Parser.Extensions;

namespace SiAp_Parser
{
    public class Alicuota
    {
        public Alicuota()
        {
            TipoComprobante = TipoComprobante.OTROS_COMP_QUE_NO_CUMPLEN_CON_LA_R_G_1415_Y_SUS_MODIF;
            PuntoDeVenta = 1;
            NumeroComprobante = 0;
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

            var alicuotaStr = sb.ToString();

            if (alicuotaStr.Length != CANTIDAD_CARACTERES_ALICUOTAS_COMPRAS)
            {

            }

            return alicuotaStr;
        }

        public TipoComprobante TipoComprobante { get; set; }
        public short PuntoDeVenta { get; set; }
        public int NumeroComprobante { get; set; }

        public CodigosDocumentos CodigoDocumentoContratante { get; set; }
        public string NumeroIdentificacionContratante { get; set; }

        private double _importeNeto;
        public double ImporteNeto
        {
            get => _importeNeto;
            set
            {
                if (value < 0)
                    return;

                _importeNeto = value;
            }
        }
        public ushort Tipo { get; private set; }

        private double _porcentaje;
        public double Porcentaje
        {
            get => _porcentaje;
            set
            {
                // https://bytes.com/topic/c-sharp/answers/255776-switch-expression-does-not-work-float-types
                switch ((int)(value * 100))
                {
                    case 0:
                        _porcentaje = 0d;
                        Tipo = 3;
                        break;
                    case 1050:
                        _porcentaje = 0.105d;
                        Tipo = 4;
                        break;
                    case 2100:
                        _porcentaje = 0.21d;
                        Tipo = 5;
                        break;
                    case 2700:
                        _porcentaje = 0.27d;
                        Tipo = 6;
                        break;
                    case 500:
                        _porcentaje = 0.05d;
                        Tipo = 8;
                        break;
                    case 250:
                        _porcentaje = 0.025d;
                        Tipo = 9;
                        break;
                }
            }
        }

        public double ImpuestoLiquidado => ImporteNeto * Porcentaje;

        private const ushort CANTIDAD_CARACTERES_ALICUOTAS_COMPRAS = 84;
    }
}