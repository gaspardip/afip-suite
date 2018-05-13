using System.Text.RegularExpressions;

namespace GeneradorDeLibros
{
    /// <summary>
    /// See https://es.wikipedia.org/wiki/Clave_%C3%9Anica_de_Identificaci%C3%B3n_Tributaria
    /// </summary>
    public class CUIT : IDocumento
    {
        public CUIT(string cuit)
        {
            switch (cuit.Length)
            {
                // plain number
                case 11:
                    Tipo = cuit.Substring(0, 2);
                    Numero = cuit.Substring(2, 8);
                    DigitoVerificador = cuit.Substring(9, 1);
                    EsValido = true;
                    break;
                // formatted number
                case 13:
                    var parts = cuit.Split("-".ToCharArray());
                    Tipo = parts[0];
                    Numero = parts[1];
                    DigitoVerificador = parts[2];
                    EsValido = true;
                    break;
                default:
                    Numero = cuit;
                    break;
            }

            TipoDocumento = TipoDocumento.CUIT;
        }

        public CUIT(string tipo, string numero, string digitoVerificador)
        {
            Tipo = tipo;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
            TipoDocumento = TipoDocumento.CUIT;
        }

        public string Format(string separator = "-")
        {
            return Tipo + separator + Numero + separator + TipoDocumento;
        }

        public override string ToString()
        {
            return Tipo + Numero + DigitoVerificador;
        }

        public TipoDocumento TipoDocumento { get; private set; }

        private string _tipo;
        public string Tipo
        {
            get => _tipo;
            private set
            {
                if (value.Length != 2 || !regex.IsMatch(value))
                    EsValido = false;
                _tipo = value;
            }
        }

        private string _numero;
        public string Numero
        {
            get => _numero;
            private set
            {
                if (value.Length != 8 || !regex.IsMatch(value))
                    EsValido = false;
                _numero = value;
            }
        }

        private readonly Regex regex = new Regex("^[0-9]+$");

        private string _digitoVerificador;
        public string DigitoVerificador
        {
            get => _digitoVerificador;
            private set
            {
                if (value.Length != 1 || !regex.IsMatch(value))
                    EsValido = false;
                _digitoVerificador = value;
            }
        }
        public bool EsValido { get; set; }
    }
}
