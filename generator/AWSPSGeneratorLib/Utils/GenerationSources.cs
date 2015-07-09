using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        /// <summary>
        /// Ensures that a reference is present in the specified project file 
        /// for every SDK assembly that we inspected during generation. 
        /// </summary>
        /// <param name="projectFile"></param>
        public void UpdateProjectReferences(string projectFile)
        {
            var project = new XmlDocument();
            project.Load(projectFile);

            var processedAssemblies = new HashSet<string>(Assemblies.Keys);

            var assemblyReferences = project.GetElementsByTagName("Reference");
            foreach (var assemblyReference in assemblyReferences)
            {
                var xn = assemblyReference as XmlNode;
                var include = xn.Attributes["Include"];
                if (include == null)
                    continue;

                var assemblyName = include.InnerText;
                if (processedAssemblies.Contains(assemblyName))
                {
                    processedAssemblies.Remove(assemblyName);
                }
            }

            if (processedAssemblies.Any())
            {
                Console.WriteLine("...updating project file for new service(s)");

                // project file needs updating with one or more new service assemblies
                var parentGroup = assemblyReferences[0].ParentNode;

                foreach (var a in processedAssemblies)
                {
                    Console.WriteLine("......adding {0}", a);

                    var xa = project.CreateAttribute("Include");
                    xa.Value = a;

                    // pass doc namespace to avoid empty xmlns attributing on the elements
                    var referenceNode = project.CreateElement("Reference", project.DocumentElement.NamespaceURI);
                    referenceNode.Attributes.Append(xa);
                    
                    var hintNode = project.CreateElement("HintPath", project.DocumentElement.NamespaceURI);
                    hintNode.InnerText = string.Concat(@"..\..\Include\sdk\assemblies\net35\", a, ".dll");

                    referenceNode.AppendChild(hintNode);

                    parentGroup.AppendChild(referenceNode);
                }

                project.Save(projectFile);
            }
        }
    }
}
