using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrapySharp.Extensions;
using HtmlAgilityPack;

namespace SiAp_Parser.Helpers
{
    public abstract class ScrapingHelper
    {
        public ScrapingHelper(Uri uri)
        {
            Web = new HtmlWeb();
            Document = Web.Load(uri.ToString());
        }

        protected HtmlWeb Web { get; set; }
        protected HtmlDocument Document { get; set; }
    }
}
