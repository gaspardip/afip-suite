using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                    this.Tipo = cuit.Substring(0, 2);
                    this.Numero = cuit.Substring(2, 8);
                    this.DigitoVerificador = cuit.Substring(9, 1);
                    this.EsValido = true;
                    break;
                // formatted number
                case 13:
                    var parts = cuit.Split("-".ToCharArray());
                    this.Tipo = parts[0];
                    this.Numero = parts[1];
                    this.DigitoVerificador = parts[2];
                    this.EsValido = true;
                    break;
                default:
                    this.Numero = cuit;
                    break;
            }

            this.TipoDocumento = GeneradorDeLibros.TipoDocumento.CUIT;
        }

        public CUIT(string tipo, string numero, string digitoVerificador)
        {
            this.Tipo = tipo;
            this.Numero = numero;
            this.DigitoVerificador = digitoVerificador;
            this.TipoDocumento = GeneradorDeLibros.TipoDocumento.CUIT;
        }

        public string Format(string separator = "-")
        {
            return this.Tipo + separator + this.Numero + separator + this.TipoDocumento;
        }

        public override string ToString()
        {
            return this.Tipo + this.Numero + this.DigitoVerificador;
        }

        public TipoDocumento TipoDocumento { get; private set; }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            private set
            {
                if (value.Length != 2 || !regex.IsMatch(value))
                    this.EsValido = false;
                _tipo = value;
            }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            private set
            {
                if (value.Length != 8 || !regex.IsMatch(value))
                    this.EsValido = false;
                _numero = value;
            }
        }

        private Regex regex = new Regex("^[0-9]+$");

        private string _digitoVerificador;
        public string DigitoVerificador
        {
            get { return _digitoVerificador; }
            private set
            {
                if (value.Length != 1 || !regex.IsMatch(value))
                    this.EsValido = false;
                _digitoVerificador = value;
            }
        }
        public bool EsValido { get; set; }
    }
}
