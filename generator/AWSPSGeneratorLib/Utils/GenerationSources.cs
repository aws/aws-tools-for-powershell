using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public const string SDKAssemblyNamePrefix = "AWSSDK.";

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
            // DynamoDBv2 has two separate PowerShell models but collapses
            // to one namespace and assembly
            if (Assemblies.ContainsKey(baseName))
            {
                Console.WriteLine("...ignoring additional attempt to register ndocs for assembly basename {0}, already present.", baseName);
                return;
            }

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
            Console.WriteLine("...checking AWSPowerShell.csproj file for new SDK assembly references");
            var project = new XmlDocument();
            project.Load(projectFile);

            // helps to keep references in some defined order in the project file
            var processedAssemblies = new SortedSet<string>(Assemblies.Keys);

            var assemblyReferences = project.GetElementsByTagName("Reference");
            foreach (var assemblyReference in assemblyReferences)
            {
                var xn = assemblyReference as XmlNode;
                var include = xn.Attributes["Include"];
                if (include == null)
                    continue;

                var assemblyName = include.InnerText;
                if (!assemblyName.StartsWith(SDKAssemblyNamePrefix, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (processedAssemblies.Contains(assemblyName))
                {
                    processedAssemblies.Remove(assemblyName);
                }
            }

            if (processedAssemblies.Any())
            {
                Console.WriteLine("......missing references detected, updating project file");

                // project file needs updating with one or more new service assemblies
                var parentGroup = assemblyReferences[0].ParentNode;

                foreach (var a in processedAssemblies)
                {
                    Console.WriteLine(".........adding {0}", a);

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

        /// <summary>
        /// Updates the psd1 file so that all SDK assemblies are listed in the RequiredAssemblies
        /// member. This is done for PowerShell v2 users who want to work with generic types
        /// when the type parameter is in an external assembly.
        /// See https://connect.microsoft.com/PowerShell/feedback/details/583922/powershell-doesnt-always-recognise-a-generic-type-if-the-type-parameter-is-in-the-external-assembly.
        /// </summary>
        /// <param name="projectFile"></param>
        /// <param name="moduleManifestFile"></param>
        /// <remarks>
        /// This should be called after we have updated the module project file to add any new
        /// assembly dependencies. That way we can handle partial (-services command line
        /// parameter) as well as full generation passes but still arrive at a consistent
        /// set of assemblies.
        /// </remarks>
        public void UpdateManifestRequiredAssemblies(string projectFile, string moduleManifestFile)
        {
            Console.WriteLine("...checking AWSPowerShell.psd1 file for any new SDK assemblies");
            var project = new XmlDocument();
            project.Load(projectFile);

            var sdkAssemblies = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            var assemblyReferences = project.GetElementsByTagName("Reference");
            foreach (var assemblyReference in assemblyReferences)
            {
                var xn = assemblyReference as XmlNode;
                var include = xn.Attributes["Include"];
                if (include == null)
                    continue;

                var assemblyName = include.InnerText;
                if (assemblyName.StartsWith(SDKAssemblyNamePrefix, StringComparison.OrdinalIgnoreCase))
                    sdkAssemblies.Add(assemblyName + ".dll");
            }

            const string RequiredAssembliesKey = "RequiredAssemblies = @(";

            // easier to just blat the set into the psd1 file each time - with consistent formatting
            // we won't change the file if the assembly set is unchanged
            var manifestContent = File.ReadAllText(moduleManifestFile);
            var requiredAssembliesStart = manifestContent.IndexOf(RequiredAssembliesKey, StringComparison.Ordinal);
            if (requiredAssembliesStart < 0)
                throw new Exception("Unable to locate 'RequiredAssemblies' key in psd1 manifest.");

            var requiredAssembliesEnd = manifestContent.IndexOf(")", requiredAssembliesStart, StringComparison.OrdinalIgnoreCase);

            var replacementContent = new StringBuilder();
            foreach (var assembly in sdkAssemblies)
            {
                replacementContent.AppendLine();
                replacementContent.AppendFormat("  \"{0}\",", assembly); // we'll trim the last ,
            }

            var newManifest = manifestContent.Substring(0, requiredAssembliesStart + RequiredAssembliesKey.Length)
                                + replacementContent.ToString().TrimEnd(',')
                                + "\n"
                                + manifestContent.Substring(requiredAssembliesEnd);

            // if the file didn't change, don't write it (otherwise Git shows it as changed but no hunks)
            if (manifestContent.Equals(newManifest, StringComparison.Ordinal))
            {
                Console.WriteLine("......new SDK assemblies required, updating AWSPowerShell.psd1");
                File.WriteAllText(moduleManifestFile, newManifest);
            }
            else
            {
                Console.WriteLine("......no new SDK assemblies required, skipping AWSPowerShell.psd1 update");
            }
        }
    }
}
