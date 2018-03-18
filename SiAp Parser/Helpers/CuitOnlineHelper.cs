using System;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using SiAp_Parser.Enums;
using SiAp_Parser.Models;

namespace SiAp_Parser.Helpers
{
    public static class CuitOnlineHelper
    {
        static CuitOnlineHelper()
        {
            Web = new HtmlWeb();
        }

        public static async Task<Persona> GetPersonInfo(string id)
        {
            Uri = new Uri($"https://www.cuitonline.com/search.php?q={id.Replace(' ', '+')}");
            Document = await Web.LoadFromWebAsync(Uri.ToString());

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

        private static Uri Uri { get; set; }
        private static HtmlWeb Web { get; }
        private static HtmlDocument Document { get; set; }
    }
}
