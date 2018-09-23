using System.Xml.Serialization;

namespace SIAP.Parser.Serialization
{
    public class Alicuota
    {
        public Alicuota()
        {
            Percentage = 0;
            Enabled = false;
            Index = 0;
        }

        public Alicuota(decimal percentage, decimal index, bool enabled)
        {
            Percentage = percentage;
            Index = index;
            Enabled = enabled;
        }

        [XmlAttribute("percentage")]
        public decimal Percentage { get; set; }
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlText]
        public decimal Index { get; set; }
    }
}
