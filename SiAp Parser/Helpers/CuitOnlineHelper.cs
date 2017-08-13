using System;
using System.Linq;
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

        public Persona GetPersonInfo()
        {
            var hit = Document.DocumentNode.CssSelect("#searchResults .hit").FirstOrDefault();

            if (hit == null || !hit.HasChildNodes)
                return null;

            return new Persona
            {
                Denominacion = hit.CssSelect("span.denominacion").First().InnerText,
                CUIT = hit.CssSelect(".cuit").First().InnerText,
                Tipo = hit.InnerText.IndexOf("Jurídica") != -1 ? TipoPersona.Juridica : TipoPersona.Fisica
            };
        }
    }
}
