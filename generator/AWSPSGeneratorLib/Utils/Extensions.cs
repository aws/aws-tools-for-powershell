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

        public static string GetTypeFullCodeName(this Type t)
        {
            if (!t.IsGenericType)
            {
                // Return the full name of the type. This is redundant for primitive types ("System.String" will be used instead of "String"), but
                // it's necessary when using a custom type defined in the .NET SDK (e.g. the document type).
                return t.FullName;
            }
            string typeName = t.GetGenericTypeDefinition().Name;

            typeName = typeName.Substring(0, typeName.IndexOf('`'));
            string args = string.Join(",", t.GetGenericArguments().Select(ta => GetTypeFullCodeName(ta)).ToArray());

            return typeName + "<" + args + ">";
        }
    }
}
