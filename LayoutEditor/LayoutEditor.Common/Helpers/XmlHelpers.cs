using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LayoutEditor.Common.Helpers
{
    public static class XmlHelpers
    {
        public static void SerializeObjectAsXmlToStringBuilder(object o, StringBuilder stringBuilder)
        {
            using (XmlWriter writer = XmlWriter.Create(stringBuilder, new XmlWriterSettings { Encoding = Encoding.UTF8 }))
            {
                var serializer = new XmlSerializer(o.GetType());
                serializer.Serialize(writer, o, new XmlSerializerNamespaces(new[] { new XmlQualifiedName("") }));
                writer.Close();
            }
        }
        public static object DeserializeXmlString(string s, Type type)
        {
            using (StringReader sr = new StringReader(s))
            {
                var xmlSerializer = new XmlSerializer(type);

                object obj = xmlSerializer.Deserialize(sr);
                Debug.Assert(obj != null);
                sr.Close();
                return obj;
            }
        }
    }
}