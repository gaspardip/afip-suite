﻿using System.Xml.Serialization;

namespace SiAp_Parser.Serialization
{
    public class Index
    {
        public Index()
        {
            Value = string.Empty;
            Enabled = false;
        }

        public Index(decimal value, bool enabled)
        {
            Value = value.ToString();
            Enabled = enabled;
        }

        public Index(string value, bool enabled)
        {
            Value = value;
            Enabled = enabled;
        }

        [XmlIgnore]
        public static Index Default { get { return new Index(0, false); } }
        [XmlAttribute("enabled")]
        public bool Enabled { get; set; }
        [XmlText]
        public string Value { get; set; }
        [XmlIgnore]
        public decimal Number { get { return decimal.Parse(Value); } }
    }
}
