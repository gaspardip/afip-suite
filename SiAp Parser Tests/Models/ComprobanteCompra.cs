using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAp_Parser.Models;

namespace SiAp_Parser_Tests.Models
{
    public class ComprobanteCompra : SiAp_Parser.Models.ComprobanteCompra
    {
        public new short Tipo { get; set; }
    }
}
