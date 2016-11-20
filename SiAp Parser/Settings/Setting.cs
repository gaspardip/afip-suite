using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SiAp_Parser.Settings
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// http://stackoverflow.com/questions/8745444/c-sharp-generic-constraints-to-include-value-types-and-strings
    /// http://stackoverflow.com/questions/11330643/serialize-property-as-xml-attribute-in-element
    public class Setting<T> where T : IConvertible
    {
        public Setting()
        {

        }

        public Setting(T value)
        {
            this.Value = value;
        }

        [XmlText]
        public T Value { get; set; }
    }
}
