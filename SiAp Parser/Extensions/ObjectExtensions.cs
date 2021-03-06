﻿using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SIAP.Parser.Extensions
{
    public static class ObjectExtensions
    {
        // http://stackoverflow.com/questions/1772004/how-can-i-make-the-xmlserializer-only-serialize-plain-xml
        public static string SerializeToXML(this object value)
        {
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());

            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamespaces);
                return stream.ToString();
            }
        }
    }
}
