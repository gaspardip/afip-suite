using SiAp_Parser.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SiAp_Parser.Settings
{
    [XmlRoot("documentSettings")]
    [XmlInclude(typeof(BuysIndexes))]
    [XmlInclude(typeof(SalesIndexes))]
    public class DocumentSettings
    {

        public DocumentSettings()
        {
            SalesPointAndVoucherNumberInTheSameColumn = new Setting<bool>(true);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("SalesPointAndVoucherNumberInTheSameColumn: {0}", SalesPointAndVoucherNumberInTheSameColumn));
            sb.Append(Indexes.ToString());

            return sb.ToString();
        }

        public Indexes Indexes { get; set; }
        [XmlElement("salesPointAndVoucherNumberInTheSameColumn")]
        public Setting<bool> SalesPointAndVoucherNumberInTheSameColumn { get; set; }
    }
}
