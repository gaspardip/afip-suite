using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrapySharp.Extensions;
using SiAp_Parser.Models;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Helpers
{
    public class CuitOnlineHelper : ScrapingHelper
    {
        public CuitOnlineHelper(string p) : base(new Uri($"https://www.cuitonline.com/search.php?q={p.Replace(' ', '+')}"))
        {

        }

        public Persona GetInfo()
        {
            var hit = Document.DocumentNode.CssSelect("#searchResults .hit").First();

            if (hit.HasChildNodes)
                return new Persona
                {
                    Denominacion = hit.CssSelect("span.denominacion").First().InnerText,
                    CUIT = hit.CssSelect(".cuit").First().InnerText,
                    Tipo = hit.InnerText.IndexOf("Jurídica") != -1 ? TipoPersona.Juridica : TipoPersona.Fisica
                };
            else
                return null;
        }
    }
}
