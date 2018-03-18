using System.Collections.Generic;
using System.Xml.Serialization;
using SiAp_Parser.Enums;

namespace SiAp_Parser.Serialization
{
    [XmlRoot("indexes")]
    [XmlInclude(typeof(Index))]
    [XmlInclude(typeof(Alicuota))]
    public class Indexes
    {
        public Indexes()
        {
            // Default Indexes
            Date = new Index(0, true);
            VoucherType = new Index(1, true);
            SalesPoint = new Index(2, true);
            VoucherNumber = new Index(3, true);
            SellerName = new Index(4, true);
            SellerIDNumber = new Index(5, true);
            UntaxedNet = new Index(9, true);
            GrossIncome = new Index(10, true);
            InternalTaxes = new Index(13, true);
            Total = new Index(12, true);
            Aliquots = new List<Alicuota>
            {
                new Alicuota(21, 6, true),
                new Alicuota(10.5m, 7, true),
                new Alicuota(27m, 8, true ),
                new Alicuota(5, 9, false),
                new Alicuota(2.5m, 10, false),
                new Alicuota(0, 11, false)
            };
            Type = TiposLibro.UNDEFINED;
        }

        public Indexes(Indexes i)
        {
            Date = i.Date;
            VoucherNumber = i.VoucherNumber;
            SalesPoint = i.SalesPoint;
            VoucherNumber = i.VoucherNumber;
            SellerName = i.SellerName;
            SellerIDNumber = i.SellerIDNumber;
            UntaxedNet = i.UntaxedNet;
            GrossIncome = i.GrossIncome;
            InternalTaxes = i.InternalTaxes;
            Total = i.Total;
            Aliquots = i.Aliquots;
            Type = i.Type;
        }

        [XmlAttribute("type")]
        public TiposLibro Type { get; set; }
        [XmlElement("date")]
        public Index Date { get; set; }
        [XmlElement("voucherType")]
        public Index VoucherType { get; set; }
        [XmlElement("salesPoint")]
        public Index SalesPoint { get; set; }
        [XmlElement("voucherNumber")]
        public Index VoucherNumber { get; set; }
        [XmlElement("sellerName")]
        public Index SellerName { get; set; }
        [XmlElement("sellerIDNumber")]
        public Index SellerIDNumber { get; set; }
        [XmlElement("untaxedNet")]
        public Index UntaxedNet { get; set; }
        [XmlElement("grossIncome")]
        public Index GrossIncome { get; set; }
        [XmlElement("internalTaxes")]
        public Index InternalTaxes { get; set; }
        [XmlElement("total")]
        public Index Total { get; set; }
        [XmlArray("Aliquots")]
        [XmlArrayItem("Aliquot")]
        public List<Alicuota> Aliquots { get; set; }
    }
}
