using System.Text.RegularExpressions;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Models
{
    public class Persona
    {
        public Persona() { }

        public Persona(string denominacion, string cuit)
        {
            Denominacion = denominacion;
            CUIT = cuit;
        }

        private string _denominacion;
        public string Denominacion
        {
            get => _denominacion;
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                _denominacion = Regex.Replace(value, "SOCIEDAD ANONIMA", "S.A.", RegexOptions.IgnoreCase);
            }
        }
        public string CUIT { get; set; }
        public TipoPersona Tipo { get; set; }
    }
}
