using System;
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
