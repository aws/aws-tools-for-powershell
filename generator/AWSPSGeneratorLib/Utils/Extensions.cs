using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace AWSPowerShellGenerator.Utils
{
    public static class Extensions
    {
        public static T XmlDeserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static string XmlSerialize<T>(this T t)
        {
            if (t == null) return null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(var writer = new StringWriter())
            {
                //return (T)serializer.Deserialize(reader);
                serializer.Serialize(writer, t);
                return writer.ToString();
            }
        }
    }
}
