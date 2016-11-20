using System;
using System.Collections.Generic;
using System.Linq;
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

            string alicuotaStr = sb.ToString();

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

        private decimal _importeNeto;
        public decimal ImporteNeto
        {
            get { return _importeNeto; }
            set
            {
                if (value < 0)
                    return;
                _importeNeto = value;
            }
        }
        public ushort Tipo { get; private set; }

        private decimal _porcentaje;
        public decimal Porcentaje
        {
            get { return _porcentaje; }
            set
            {
                // https://bytes.com/topic/c-sharp/answers/255776-switch-expression-does-not-work-float-types
                switch ((int)(value * 100))
                {
                    case 0:
                        _porcentaje = 0m;
                        Tipo = 3;
                        break;
                    case 1050:
                        _porcentaje = 0.105m;
                        Tipo = 4;
                        break;
                    case 2100:
                        _porcentaje = 0.21m;
                        Tipo = 5;
                        break;
                    case 2700:
                        _porcentaje = 0.27m;
                        Tipo = 6;
                        break;
                    case 500:
                        _porcentaje = 0.05m;
                        Tipo = 8;
                        break;
                    case 250:
                        _porcentaje = 0.025m;
                        Tipo = 9;
                        break;
                }
            }
        }

        public decimal ImpuestoLiquidado
        {
            get { return ImporteNeto * Porcentaje; }
        }

        private const ushort CANTIDAD_CARACTERES_ALICUOTAS_COMPRAS = 84;
    }
}