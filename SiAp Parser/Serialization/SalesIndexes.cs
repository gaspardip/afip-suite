using System.Xml.Serialization;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Serialization
{
    [XmlRoot("indexes")]
    public class SalesIndexes : Indexes
    {
        public SalesIndexes()
        {
            Type = TiposLibro.VENTAS;
            VoucherNumberUntil = Index.Default;
            UncategorizedPerceptionAmount = Index.Default;
            PaymentExpireDate = Index.Default;
        }

        public SalesIndexes(SalesIndexes i) : base(i)
        {
            Type = TiposLibro.VENTAS;
            VoucherNumberUntil = i.VoucherNumberUntil;
            UncategorizedPerceptionAmount = i.UncategorizedPerceptionAmount;
            PaymentExpireDate = i.PaymentExpireDate;
        }

        public SalesIndexes(Indexes i) : base(i)
        {
            Type = TiposLibro.VENTAS;
        }

        [XmlElement("voucherNumberUntil")]
        public Index VoucherNumberUntil { get; set; }

        [XmlElement("uncategorizedPerceptionAmount")]
        public Index UncategorizedPerceptionAmount { get; set; }

        [XmlElement("paymentExpireDate")]
        public Index PaymentExpireDate { get; set; }
    }
}
