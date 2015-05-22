using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Container holding assemblies and ndoc files for SDK assemblies,
    /// populated as the generator progresses through the services.
    /// </summary>
    public class GenerationSources
    {
        private readonly Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();
        private readonly Dictionary<string, XmlDocument> NDocs = new Dictionary<string, XmlDocument>();

        /// <summary>
        /// The default location that assemblies and ndoc files will be loaded from
        /// </summary>
        public string SdkAssembliesFolder { get; set; }

        /// <summary>
        /// Loads the assembly and ndoc data for the given assembly basename using the
        /// default folder location.
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="assembly"></param>
        /// <param name="ndoc"></param>
        public void Load(string baseName, out Assembly assembly, out XmlDocument ndoc)
        {
            if (string.IsNullOrEmpty(SdkAssembliesFolder))
                throw new InvalidOperationException("Expected 'SdkAssembliesFolder' to have been set prior to calling Load(...)");

            var assemblyFile = Path.Combine(SdkAssembliesFolder, baseName + ".dll");
            var ndocFile = Path.Combine(SdkAssembliesFolder, baseName + ".xml");

            assembly = Assembly.LoadFrom(assemblyFile);
            ndoc = new XmlDocument();
            ndoc.Load(ndocFile);

            Add(baseName, assembly, ndoc);
        }

        /// <summary>
        /// Adds preloaded artifacts to the collection.
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="assembly"></param>
        /// <param name="ndoc"></param>
        public void Add(string baseName, Assembly assembly, XmlDocument ndoc)
        {
            Assemblies.Add(baseName, assembly);
            NDocs.Add(baseName, ndoc);
        }
    }
}
