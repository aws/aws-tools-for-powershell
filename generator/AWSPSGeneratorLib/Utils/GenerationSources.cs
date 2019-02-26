using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// Container holding assemblies and ndoc files for SDK assemblies,
    /// populated as the generator progresses through the services.
    /// </summary>
    public class GenerationSources
    {
        // we use the keys in the Assemblies dictionary to update project files
        // etc, so maintain a sorted dictionary so we don't have to keep sorting
        // the keys in each routine that updates the various files
        private readonly SortedDictionary<string, Assembly> Assemblies = new SortedDictionary<string, Assembly>();
        private readonly Dictionary<string, XmlDocument> NDocs = new Dictionary<string, XmlDocument>();

        /// <summary>
        /// The default location that nupkg files will be loaded from
        /// </summary>
        public string SdkNugetFolder { get; set; }

        public const string SDKAssemblyNamePrefix = "AWSSDK.";
        public const string ExtractedNugetFolderName = "ExtractedNuGet";
        public const string DotNetPlatformNet35 = "net35";
        public const string DotNetPlatformNetStandard13 = "netstandard1.3";

        private static string[] PlatformsToExtractLibrariesFor = new string[] { DotNetPlatformNet35, DotNetPlatformNetStandard13 };

        /// <summary>
        /// Loads the assembly and ndoc data for the given assembly basename using the
        /// default folder location.
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="assembly"></param>
        /// <param name="ndoc"></param>
        /// <param name="addAsReference">If false, the method just downloads the NuGet package and unpacks the
        /// assemblies without adding them to the list of assemblies to be referenced</param>
        public (Assembly Assembly, XmlDocument Ndoc) Load(string baseName, bool addAsReference = true)
        {
            if (string.IsNullOrEmpty(SdkNugetFolder))
            {
                throw new InvalidOperationException("Expected 'SdkNugetFolder' to have been set prior to calling Load(...)");
            }

            var extractFolder = Path.Combine(SdkNugetFolder, $"..\\{ExtractedNugetFolderName}\\");

            foreach(var platform in PlatformsToExtractLibrariesFor)
            {
                NuGetUtils.ExtractSourceLibrary(baseName, SdkNugetFolder, Path.Combine(extractFolder, platform), platform);
            }

            if (addAsReference)
            {
                var assemblyFile = Path.Combine(extractFolder, $"{DotNetPlatformNet35}\\{baseName}.dll");
                var ndocFile = Path.Combine(extractFolder, $"{DotNetPlatformNet35}\\{baseName}.xml");
                try
                {
                    var assembly = Assembly.LoadFrom(assemblyFile);
                    var ndoc = new XmlDocument();
                    ndoc.Load(ndocFile);

                    Add(baseName, assembly, ndoc);
                    return (assembly, ndoc);
                }
                catch (Exception)
                {
                    Console.WriteLine("An exception occured while processing files {0} and {1}.", assemblyFile, ndocFile);
                    throw;
                }
            }

            return (null, null);
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
                Console.WriteLine("...ndocs for assembly basename {0} already registered.", baseName);
                return;
            }

            Assemblies.Add(baseName, assembly);
            NDocs.Add(baseName, ndoc);
        }

        /// <summary>
        /// Updates the references to the SDK assemblies in the project files and nuget package
        /// configs, and sdk references and exported aliases data in the module manifests. Adding
        /// the aliases to the manifest makes them available even if the module has not been explicity
        /// imported. The set of exported cmdlets is patched into the manifest at a later build
        /// stage, once we have compiled the module assembly and can reflect over it - at this stage
        /// of generation, we only know about generated service cmdlets, not hand written ones.
        /// </summary>
        /// <param name="moduleRootFolder">The root folder containing the module source files</param>
        /// <param name="legacyAliases">
        /// The collection of legacy alias names to patch into the AliasesToExport
        /// manifest member.
        /// </param>
        public void UpdateReferencesAndExports(string moduleRootFolder, IEnumerable<string> legacyAliases)
        {
            var projectFile = Path.Combine(moduleRootFolder, CmdletGenerator.AWSPowerShellProjectFilename);
            UpdateProjectReferences(projectFile);

            var manifestFiles = new[]
            {
                Path.Combine(moduleRootFolder, CmdletGenerator.AWSPowerShellDesktopModuleManifestFilename),
                Path.Combine(moduleRootFolder, CmdletGenerator.AWSPowerShellNetCoreModuleManifestFilename)
            };

            foreach (var manifestFile in manifestFiles)
            {
                UpdateManifestRequiredAssemblies(manifestFile);
            }
        }

        /// <summary>
        /// Injects the generated completer functions into one script module file. This has proven faster
        /// to load than one scriptfile per service.
        /// </summary>
        public void WriteCompletionScriptsFile(string completorsScriptModuleFile, string completionScript)
        {
            Console.WriteLine("...checking argument completors module file {0} for any new script content", completorsScriptModuleFile);

            const string completionScriptsStartMarker = "# begin auto-generated service completers";
            const string completionScriptsEndMarker = "# end auto-generated service completers";

            var moduleContent = File.ReadAllText(completorsScriptModuleFile, Encoding.UTF8);
            var completionScriptsStart = moduleContent.IndexOf(completionScriptsStartMarker, StringComparison.Ordinal);
            if (completionScriptsStart < 0)
                throw new Exception("Unable to locate " + completionScriptsStartMarker + " in module.");
            var completionScriptsEnd = moduleContent.IndexOf(completionScriptsEndMarker, completionScriptsStart, StringComparison.OrdinalIgnoreCase);

            var replacementScript = moduleContent.Substring(0, completionScriptsStart + completionScriptsStartMarker.Length)
                                        + "\r\n"
                                        + completionScript
                                        + moduleContent.Substring(completionScriptsEnd);

            // if the file didn't change, don't write it (otherwise Git shows it as changed but no hunks)
            if (!moduleContent.Equals(replacementScript, StringComparison.Ordinal))
            {
                Console.WriteLine("......new completion script functions detected, updating {0} script module", completorsScriptModuleFile);
                File.WriteAllText(completorsScriptModuleFile, replacementScript, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("......no new completion script functions, skipping {0} script module update", completorsScriptModuleFile);
            }

        }

        /// <summary>
        /// Writes the AWSPowerShellLegacyAliases.psm1 nested module file, containing a set of
        /// Set-Alias commands to map legacy cmdlet names to the current names.
        /// </summary>
        /// <param name="legacyAliasesScriptModuleFile"></param>
        /// <param name="legacyAliasesContent"></param>
        public void WriteLegacyAliasesFile(string legacyAliasesScriptModuleFile, string legacyAliasesContent)
        {
            var sb = new StringBuilder();

            sb.AppendLine("# Auto-generated aliases for backwards compatibility.");
            sb.AppendLine("# Do not modify this file; it may be overwritten during version upgrades.");
            sb.AppendLine();

            sb.AppendLine(legacyAliasesContent);

            var content = sb.ToString();

            var moduleContent = File.ReadAllText(legacyAliasesScriptModuleFile, Encoding.UTF8);
            if (!moduleContent.Equals(content, StringComparison.Ordinal))
            {
                Console.WriteLine("......new legacy aliases detected, updating {0} script module", legacyAliasesScriptModuleFile);
                File.WriteAllText(legacyAliasesScriptModuleFile, content, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("......no new legacy aliases, skipping {0} script module update", legacyAliasesScriptModuleFile);
            }
        }

        /// <summary>
        /// Ensures that a reference is present in the specified project file 
        /// for every SDK assembly that we inspected during generation. 
        /// </summary>
        /// <param name="projectFile">The project file to update</param>
        private void UpdateProjectReferences(string projectFile)
        {
            Console.WriteLine("...checking {0} project file for updated/new SDK nuget references", projectFile);
            var project = new XmlDocument();
            project.Load(projectFile);

            var targetFrameworkRegex = new Regex(@"'\$\(TargetFramework\)'=='([\w\.]+)'");

            // helps to keep references in some defined order in the project file
            var usedSdkAssemblies = new SortedSet<string>(Assemblies.Keys);

            var itemGroups = project.GetElementsByTagName("ItemGroup");
            foreach (XmlNode itemGroup in itemGroups)
            {
                var condition = itemGroup.Attributes["Condition"];
                if (condition == null)
                    continue;

                var match = targetFrameworkRegex.Match(condition.Value);
                if (!match.Success)
                    continue;

                var platform = match.Groups[1].Value;
                if (platform == "netstandard2.0")
                {
                    platform = "netstandard1.3";
                }

                var sdkReferences = itemGroup.ChildNodes
                    .OfType<XmlNode>()
                    .Where(child => child.Name == "Reference")
                    .Where(child => child.Attributes["Include"]?.InnerText.StartsWith(SDKAssemblyNamePrefix, StringComparison.OrdinalIgnoreCase) ?? false)
                    .ToArray();

                if (sdkReferences.Any())
                {
                    foreach (var assemblyReference in sdkReferences)
                    {
                        itemGroup.RemoveChild(assemblyReference);
                    }

                    foreach (var assembly in usedSdkAssemblies)
                    {
                        var referenceNode = CreatePackageReferenceNode(project, assembly, platform);
                        itemGroup.AppendChild(referenceNode);
                    }
                }
            }

            project.Save(projectFile);
        }

        private XmlElement CreatePackageReferenceNode(XmlDocument project, string assembly, string platform)
        {
            // pass doc namespace to avoid empty xmlns attributing on the elements
            var referenceNode = project.CreateElement("Reference", project.DocumentElement.NamespaceURI);

            var xa = project.CreateAttribute("Include");
            xa.Value = assembly;
            referenceNode.Attributes.Append(xa);

            var xb = project.CreateElement("HintPath");
            xb.InnerText = $"..\\..\\Include\\sdk\\ExtractedNuGet\\{platform}\\{assembly}.dll";
            referenceNode.AppendChild(xb);

            return referenceNode;
        }

        /// <summary>
        /// Probes the packages folder to return the nuget package containing
        /// the supplied SDK assembly name.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private string LocateNugetPackageForAssembly(string assemblyName)
        {
            var packages = Directory.GetFiles(SdkNugetFolder, string.Concat(assemblyName, ".*.nupkg"));
            if (packages.Length != 1)
                throw new Exception("Failed to locate single nuget package for assembly " + assemblyName);

            // nuget drops the 4th version component on expanded package folder if it is .0 , but retains 
            // any trailing -tag text (eg mydll.3.2.5.0-beta.nupkg becomes mydll.3.2.5-beta\..., mydll.3.3.0.nupkg
            // stays as mydll.3.3.0.nupkg)
            var nugetPackage = Path.GetFileNameWithoutExtension(packages[0]);
            var tagStart = nugetPackage.LastIndexOf('-');
            if (tagStart > 0)
            {
                var preTagText = nugetPackage.Substring(0, tagStart);
                if (preTagText.EndsWith(".0.0", StringComparison.Ordinal))
                {
                    nugetPackage = preTagText.Substring(0, preTagText.Length - 2) + nugetPackage.Substring(tagStart);
                }
            }

            return nugetPackage;
        }

        /// <summary>
        /// Updates the psd1 file so that all SDK assemblies are listed in the RequiredAssemblies
        /// member. This is done for PowerShell v2 users who want to work with generic types
        /// when the type parameter is in an external assembly.
        /// See https://connect.microsoft.com/PowerShell/feedback/details/583922/powershell-doesnt-always-recognise-a-generic-type-if-the-type-parameter-is-in-the-external-assembly.
        /// </summary>
        /// <param name="moduleManifestFile"></param>
        /// <remarks>
        /// Easier to just blat the set into the psd1 file each time - with consistent formatting
        /// we won't change the file if the assembly set is unchanged
        /// </remarks>
        private void UpdateManifestRequiredAssemblies(string moduleManifestFile)
        {
            var replacementContent = new StringBuilder();
            foreach (var assembly in Assemblies.Keys)
            {
                replacementContent.AppendLine();
                replacementContent.AppendFormat("  \"{0}.dll\",", assembly);
            }

            PatchManifestContent(moduleManifestFile, "RequiredAssemblies = @(", replacementContent.ToString());
        }

        /// <summary>
        /// Generalised helper to patch the RequiredAssemblies and AliasesToExport array members
        /// in a manifest. As these are array members, it is safe to assume the keys end with a closing )
        /// character.
        /// </summary>
        /// <param name="moduleManifestFile"></param>
        /// <param name="manifestKey"></param>
        /// <param name="newContent"></param>
        private void PatchManifestContent(string moduleManifestFile, string manifestKey, string newContent)
        {
            var manifestContent = File.ReadAllText(moduleManifestFile);

            var keyStart = manifestContent.IndexOf(manifestKey, StringComparison.Ordinal);
            if (keyStart < 0)
                throw new Exception(string.Format("Unable to locate '{0}' in manifest {1}", manifestKey, moduleManifestFile));

            var keyEnd = manifestContent.IndexOf(")", keyStart, StringComparison.OrdinalIgnoreCase);

            var newManifest = manifestContent.Substring(0, keyStart + manifestKey.Length)
                                + newContent.TrimEnd(',')
                                + "\r\n"
                                + manifestContent.Substring(keyEnd);

            WriteIfChanged(moduleManifestFile, manifestContent, newManifest);
        }

        private void WriteIfChanged(string fileName, string oldContent, string newContent)
        {
            if (!oldContent.Equals(newContent, StringComparison.Ordinal))
            {
                Console.WriteLine("......updating file {0} with new content", fileName);
                File.WriteAllText(fileName, newContent);
            }
            else
            {
                Console.WriteLine("......file {0} unchanged, skipping update", fileName);
            }
        }
    }
}
