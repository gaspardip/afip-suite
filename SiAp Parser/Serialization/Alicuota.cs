using System.Xml.Serialization;

namespace SiAp_Parser.Serialization
{
    public class Alicuota
    {
        public Alicuota()
        {
            this.Percentage = 0;
            this.Enabled = false;
            this.Index = 0;
        }

        public Alicuota(decimal percentage, decimal index, bool enabled)
        {
            this.Percentage = percentage;
            this.Index = index;
            this.Enabled = enabled;
        }

        [XmlAttribute("percentage")]
        public decimal Percentage { get; set; }
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlText]
        public decimal Index { get; set; }
    }
}
