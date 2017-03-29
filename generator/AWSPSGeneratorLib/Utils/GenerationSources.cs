using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
            try
            {
                assembly = Assembly.LoadFrom(assemblyFile);
                ndoc = new XmlDocument();
                ndoc.Load(ndocFile);

                Add(baseName, assembly, ndoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while processing files {0} and {1}.", assemblyFile, ndocFile);
                throw ex;
            }
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

        struct DotNetPlatformAndArtifacts
        {
            public string DotNetPlatform { get; set; }
            public string ProjectFile { get; set; }
            public string ModuleManifestFile { get; set; }
            public string NugetPackagesFile { get; set; }
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
            var projectFiles = new[]            
            {
                new DotNetPlatformAndArtifacts
                {
                    DotNetPlatform = "net35",
                    ProjectFile = Path.Combine(moduleRootFolder, CmdletGenerator.AWSPowerShellDesktopProjectFilename),
                    ModuleManifestFile = Path.Combine(moduleRootFolder, CmdletGenerator.AWSPowerShellDesktopModuleManifestFilename),
                    NugetPackagesFile = Path.Combine(moduleRootFolder, "packages.AWSPowerShell.config")
                },
                new DotNetPlatformAndArtifacts
                {
                    DotNetPlatform = "netstandard1.3",
                    ProjectFile = Path.Combine(moduleRootFolder, "project.json"),
                    ModuleManifestFile = Path.Combine(moduleRootFolder, CmdletGenerator.AWSPowerShellNetCoreModuleManifestFilename),
                    NugetPackagesFile = Path.Combine(moduleRootFolder, "packages.AWSPowerShell.NetCore.config")
                }
            };

            foreach (var p in projectFiles)
            {
                UpdateProjectReferences(p.ProjectFile, p.DotNetPlatform);
                UpdateManifestRequiredAssemblies(p.ModuleManifestFile);
                UpdateManifestAliasExports(p.ModuleManifestFile, legacyAliases);
                UpdateNugetPackageConfig(p.NugetPackagesFile, p.DotNetPlatform);
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
        /// <param name="platformStandard">The moniker to the .NET platform that will be present in the hint paths, eg net35, netstandard1.5</param>
        private void UpdateProjectReferences(string projectFile, string platformStandard)
        {
            if (projectFile.EndsWith("project.json", StringComparison.OrdinalIgnoreCase))
                UpdateProjectJsonFormatReferences(projectFile, platformStandard);
            else
                UpdateCsprojFormatReferences(projectFile, platformStandard);
        }

        /// <summary>
        /// Updates sdk assembly references for a normal .csproj style project file.
        /// </summary>
        /// <param name="projectFile"></param>
        /// <param name="platformStandard"></param>
        private void UpdateCsprojFormatReferences(string projectFile, string platformStandard)
        {
            Console.WriteLine("...checking {0} project file for updated/new SDK nuget references", projectFile);
            var project = new XmlDocument();
            project.Load(projectFile);

            // helps to keep references in some defined order in the project file
            var usedSdkAssemblies = new SortedSet<string>(Assemblies.Keys);

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

                if (usedSdkAssemblies.Contains(assemblyName))
                {
                    // for simplicy, always update the hintpath of existing assemblies
                    var version = GetNugetPackageVersionForAssembly(assemblyName);
                    var children = xn.ChildNodes;
                    foreach (XmlNode c in children)
                    {
                        if (c.Name.Equals("HintPath", StringComparison.OrdinalIgnoreCase))
                        {
                            c.InnerText = string.Format(@"..\..\packages\{0}.{1}\lib\{2}\{0}.dll",
                                                        assemblyName,
                                                        version,
                                                        platformStandard);
                            break;
                        }
                    }

                    usedSdkAssemblies.Remove(assemblyName);
                }
            }

            if (usedSdkAssemblies.Any())
            {
                Console.WriteLine("......!missing references detected, updating project file");

                // project file needs updating with one or more new service assemblies
                var parentGroup = assemblyReferences[0].ParentNode;

                foreach (var assembly in usedSdkAssemblies)
                {
                    Console.WriteLine(".........adding {0}", assembly);

                    // create reference node for the new service
                    var referenceNode = CreateReferenceNode(project, platformStandard, assembly);
                    var newIncludeAttribute = referenceNode.Attributes["Include"].Value;

                    var childToInsertAfter = FindInsertionPoint(parentGroup, newIncludeAttribute);
                    parentGroup.InsertAfter(referenceNode, childToInsertAfter);
                }
            }

            project.Save(projectFile);
        }

        private void UpdateProjectJsonFormatReferences(string projectFile, string platformStandard)
        {
            const string DependenciesStartMarker = "\"sdkdependencies_start_marker\": \"\",";

            // sdk references exist in the first dependencies section
            var existingProjectFile = File.ReadAllText(projectFile);
            var sdkDependenciesStart = existingProjectFile.IndexOf(DependenciesStartMarker);
            if (sdkDependenciesStart < 0)
                throw new Exception("Unable to locate sdk dependencies marker key in project file " + projectFile);

            var sdkDependenciesEnd = existingProjectFile.IndexOf("},", sdkDependenciesStart);

            var dependencies = new StringBuilder();
            foreach (var assemblyName in Assemblies.Keys)
            {
                if (dependencies.Length > 0)
                    dependencies.AppendLine();

                dependencies.AppendFormat("\t\t\"{0}\": \"{1}\",",
                                          assemblyName,
                                          GetNugetPackageVersionForAssembly(assemblyName)
                                          );
            }

            var newProjectFile = existingProjectFile.Substring(0, sdkDependenciesStart + DependenciesStartMarker.Length)
                                    + "\r\n"
                                    + "\t\"dependencies\": {\r\n"
                                    + dependencies.ToString().TrimEnd(',')
                                    + "\r\n"
                                    + " \t},"
                                    + existingProjectFile.Substring(sdkDependenciesEnd + 2);

            WriteIfChanged(projectFile, existingProjectFile, newProjectFile);
        }

        private static XmlNode FindInsertionPoint(XmlNode parentGroup, string newIncludeAttribute)
        {
            int insertionIndex = -1;
            for (int i = 0; i < parentGroup.ChildNodes.Count; i++)
            {
                var child = parentGroup.ChildNodes[i];
                var includeAttribute = child.Attributes["Include"].Value;

                if (!includeAttribute.StartsWith("AWSSDK."))
                    continue;

                // if new include < current child, we found insertion point
                if (string.Compare(newIncludeAttribute, includeAttribute) < 0)
                {
                    insertionIndex = i - 1;
                    break;
                }
            }
            var childToInsertAfter = (insertionIndex < 0) ? parentGroup.FirstChild : parentGroup.ChildNodes[insertionIndex];
            return childToInsertAfter;
        }

        private XmlElement CreateReferenceNode(XmlDocument project, string platformStandard, string assembly)
        {
            // pass doc namespace to avoid empty xmlns attributing on the elements
            var referenceNode = project.CreateElement("Reference", project.DocumentElement.NamespaceURI);

            var xa = project.CreateAttribute("Include");
            xa.Value = assembly;
            referenceNode.Attributes.Append(xa);

            // locate the nuget package we'll build from, which is currently under Include\sdk\nuget;
            // at module build time it is restored to the packages folder
            var nugetPackage = LocateNugetPackageForAssembly(assembly);
                  
            var hintNode = project.CreateElement("HintPath", project.DocumentElement.NamespaceURI);
            hintNode.InnerText = string.Format(@"..\..\packages\{0}\lib\{1}\{2}.dll", nugetPackage, platformStandard, assembly);
            referenceNode.AppendChild(hintNode);
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
            var nugetPackagesPath = Path.Combine(SdkAssembliesFolder, @"..\..\nuget");
            var packages = Directory.GetFiles(nugetPackagesPath, string.Concat(assemblyName, ".*.nupkg"));
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
        /// Probes the packages folder to return the nuget package containing
        /// the supplied SDK assembly name.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private string GetNugetPackageVersionForAssembly(string assemblyName)
        {
            var nugetPackage = LocateNugetPackageForAssembly(assemblyName);
            // First two dotted parts are sdk assembly name by convention, the rest is the version
            // (there is no extension in the package name returned above). Further convention is
            // to drop any trailing .0.
            var versionStart = nugetPackage.IndexOf('.', nugetPackage.IndexOf('.') + 1) + 1;
            var version = nugetPackage.Substring(versionStart);
            if (version.EndsWith(".0", StringComparison.Ordinal))
                version = version.Substring(0, version.Length - 2);

            return version;
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
        /// Patches the specified aliases into the AliasesToExport member of the manifest.
        /// </summary>
        /// <param name="moduleManifestFile"></param>
        /// <param name="exportedAliases"></param>
        private void UpdateManifestAliasExports(string moduleManifestFile, IEnumerable<string> exportedAliases)
        {
            var replacementContent = new StringBuilder();
            foreach (var alias in exportedAliases)
            {
                replacementContent.AppendLine();
                replacementContent.AppendFormat("  \"{0}\",", alias); 
            }

            PatchManifestContent(moduleManifestFile, "AliasesToExport = @(", replacementContent.ToString());
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

        /// <summary>
        /// Updates the Nuget packages config file with required sdk assemblies for the
        /// given platform.
        /// </summary>
        /// <param name="configFile"></param>
        /// <param name="platformStandard"></param>
        private void UpdateNugetPackageConfig(string configFile, string platformStandard)
        {
            // simpler to replace the file, which contains only sdk assemblies at this time
            var newConfigBuilder = new StringBuilder();

            newConfigBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            newConfigBuilder.AppendLine("<packages>");

            foreach (var assemblyName in Assemblies.Keys)
            {
                newConfigBuilder.AppendFormat("  <package id=\"{0}\" version=\"{1}\" targetFramework=\"{2}\" />",
                                           assemblyName,
                                           GetNugetPackageVersionForAssembly(assemblyName),
                                           platformStandard
                                           );
                newConfigBuilder.AppendLine();
            }
            newConfigBuilder.AppendLine("</packages>");
            newConfigBuilder.AppendLine();

            var newConfig = newConfigBuilder.ToString();
            var existingConfig = File.ReadAllText(configFile);

            WriteIfChanged(configFile, existingConfig, newConfig);
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
