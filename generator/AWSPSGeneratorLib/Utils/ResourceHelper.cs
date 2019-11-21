using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace AWSPowerShellGenerator.Utils
{
    internal static class ResourceHelper
    {
        public static Stream GetResourceStream(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            return stream;
        }

        public static string GetResourceContents(string resourceName, bool failOnMissingStream = true)
        {
            Stream stream = GetResourceStream(resourceName);
            if (stream == null)
            {
                if (failOnMissingStream)
                    throw new InvalidDataException("Unable to find resource " + resourceName);
                else
                    return null;
            }

            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
