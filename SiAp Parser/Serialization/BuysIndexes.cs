using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Serialization
{
    [XmlRoot("indexes")]
    public class BuysIndexes : Indexes
    {
        public BuysIndexes()
        {
            Type = TiposLibro.COMPRAS;
            ImportClearance = Index.Default;
            VATPerceptionsAmount = new Index(11, true);
            ComputableTaxCredit = Index.Default;
            CUITIssuer = Index.Default;
            IssuerName = Index.Default;
            VATCommission = Index.Default;
        }

        public BuysIndexes(BuysIndexes i) : base(i)
        {
            Type = TiposLibro.COMPRAS;
            ImportClearance = i.ImportClearance;
            VATPerceptionsAmount = i.VATPerceptionsAmount;
            ComputableTaxCredit = i.ComputableTaxCredit;
            CUITIssuer = i.CUITIssuer;
            IssuerName = i.IssuerName;
            VATCommission = i.VATCommission;
        }

        public BuysIndexes(Indexes i) : base(i)
        {
            Type = TiposLibro.COMPRAS;
        }

        [XmlElement("importClearance")]
        public Index ImportClearance { get; set; }

        [XmlElement("vatPerceptionsAmount")]
        public Index VATPerceptionsAmount { get; set; }

        [XmlElement("computableTaxCredit")]
        public Index ComputableTaxCredit { get; set; }

        [XmlElement("cuitIssuer")]
        public Index CUITIssuer { get; set; }

        [XmlElement("issuerName")]
        public Index IssuerName { get; set; }

        [XmlElement("vatCommission")]
        public Index VATCommission { get; set; }
    }
}
