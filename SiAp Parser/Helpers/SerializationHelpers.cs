using System;
using System.IO;
using System.Xml.Serialization;

namespace SiAp_Parser.Helpers
{
    // http://stackoverflow.com/questions/4996876/generic-deserialization-of-an-xml-string
    // http://stackoverflow.com/questions/9645349/getting-invalidoperationexception-when-deserializing-in-c-sharp
    // http://stackoverflow.com/questions/4726208/deserialization-error-in-xml-document1-1
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static class SerializationHelpers
    {
        public static T Deserialize<T>(string input) where T : class
        {
            if (string.IsNullOrEmpty(input))
                return null;

            var serializer = new XmlSerializer(typeof(T));

            using (var sr = new StreamReader(input))
                return (T)serializer.Deserialize(sr);
        }
    }
}
