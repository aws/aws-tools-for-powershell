using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Holds all type extensions (across all services) to be emitted into
    /// single AWSPowerShell.TypeExtensions.ps1xml file at build time.
    /// </summary>
    internal class TypeExtensionsStore
    {
        TypeExtensionsStore() { }

        static TypeExtensionsStore _this;
        public static TypeExtensionsStore Instance
        {
            get
            {
                if (_this == null)
                    _this = new TypeExtensionsStore();
                return _this;
            }
        }

        // key is service noun prefix
        Dictionary<string, List<string>> _typeExtensions = new Dictionary<string, List<string>>();

        /// <summary>
        /// Adds an extension type defined in a loaded xml file
        /// </summary>
        /// <param name="forService"></param>
        /// <param name="typeExtension"></param>
        public void AddTypeExtension(string forService, XElement typeExtension)
        {
            AddTypeExtension(forService, typeExtension.ToString(SaveOptions.DisableFormatting));
        }

        /// <summary>
        /// Adds an ad-hoc extension type defined as a serialized xml content
        /// </summary>
        /// <param name="forService"></param>
        /// <param name="typeExtension"></param>
        public void AddTypeExtension(string forService, string typeExtension)
        {
            List<string> extensions;
            if (_typeExtensions.ContainsKey(forService))
                extensions = _typeExtensions[forService];
            else
            {
                extensions = new List<string>();
                _typeExtensions.Add(forService, extensions);
            }

            extensions.Add(typeExtension);
        }

        /// <summary>
        /// Serializes xml Type nodes into a single string for insertion into the output types file
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            
            foreach (string serviceKey in _typeExtensions.Keys)
            {
                List<string> extensions = _typeExtensions[serviceKey];
                foreach (string extension in extensions)
                {
                    sw.WriteLine(extension);
                }
            }

            return sw.ToString();
        }

        /// <summary>
        /// Serializes xml Type nodes into a single string for the specified service
        /// </summary>
        /// <param name="forService"></param>
        /// <returns></returns>
        public string Serialize(string forService)
        {
            if (!_typeExtensions.ContainsKey(forService))
                return string.Empty;

            StringWriter sw = new StringWriter();
            
            List<string> extensions = _typeExtensions[forService];
            foreach (string extension in extensions)
            {
                sw.WriteLine(extension);
            }

            return sw.ToString();
        }
    }
}
