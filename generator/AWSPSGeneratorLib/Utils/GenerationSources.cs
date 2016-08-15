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
        /// Updates the references to the SDK assemblies in the project files, module
        /// manifests and nuget package configs for the module.
        /// </summary>
        /// <param name="moduleRootFolder">The root folder containing the module source files</param>
        public void UpdateSDKAssemblyReferences(string moduleRootFolder)
        {
            // update references in .csproj files
            var projectFiles = new DotNetPlatformAndArtifacts[]            
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

            const string completionScriptsStartMarker = "# begin service completion functions";
            const string completionScriptsEndMarker = "# end service completion functions";

            var moduleContent = File.ReadAllText(completorsScriptModuleFile);
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
                File.WriteAllText(completorsScriptModuleFile, replacementScript);
            }
            else
            {
                Console.WriteLine("......no new completion script functions, skipping {0} script module update", completorsScriptModuleFile);
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
            Console.WriteLine("...checking {0} project file for new SDK assembly references", projectFile);
            var project = new XmlDocument();
            project.Load(projectFile);

            // helps to keep references in some defined order in the project file
            var newAssemblies = new SortedSet<string>(Assemblies.Keys);

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

                if (newAssemblies.Contains(assemblyName))
                {
                    newAssemblies.Remove(assemblyName);
                }
            }

            if (newAssemblies.Any())
            {
                Console.WriteLine("......!missing references detected, updating project file");

                // project file needs updating with one or more new service assemblies
                var parentGroup = assemblyReferences[0].ParentNode;

                foreach (var assembly in newAssemblies)
                {
                    Console.WriteLine(".........adding {0}", assembly);

                    // create reference node for the new service
                    var referenceNode = CreateReferenceNode(project, platformStandard, assembly);
                    var newIncludeAttribute = referenceNode.Attributes["Include"].Value;

                    var childToInsertAfter = FindInsertionPoint(parentGroup, newIncludeAttribute);
                    parentGroup.InsertAfter(referenceNode, childToInsertAfter);
                }

                project.Save(projectFile);
            }
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

            // nuget drops trailing .0 on expanded package folder, but retains any trailing -tag text
            // (eg mydll.3.2.5.0-beta.nupkg becomes mydll.3.2.5-beta\...)
            var nugetPackage = Path.GetFileNameWithoutExtension(packages[0]);
            var tagStart = nugetPackage.LastIndexOf('-');
            if (tagStart > 0)
            {
                var preTagText = nugetPackage.Substring(0, tagStart);
                if (preTagText.EndsWith(".0", StringComparison.Ordinal))
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
            // first two dotted parts are sdk assembly name by convention, the rest is the version
            // (there is no extension in the package name returned above)
            var versionStart = nugetPackage.IndexOf('.', nugetPackage.IndexOf('.') + 1) + 1;
            return nugetPackage.Substring(versionStart);
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
            const string RequiredAssembliesKey = "RequiredAssemblies = @(";

            var manifestContent = File.ReadAllText(moduleManifestFile);
            var requiredAssembliesStart = manifestContent.IndexOf(RequiredAssembliesKey, StringComparison.Ordinal);
            if (requiredAssembliesStart < 0)
                throw new Exception("Unable to locate 'RequiredAssemblies' key in manifest " + moduleManifestFile);

            var requiredAssembliesEnd = manifestContent.IndexOf(")", requiredAssembliesStart, StringComparison.OrdinalIgnoreCase);

            var replacementContent = new StringBuilder();
            foreach (var assembly in Assemblies.Keys)
            {
                replacementContent.AppendLine();
                replacementContent.AppendFormat("  \"{0}.dll\",", assembly); // we'll trim the last ,
            }

            var newManifest = manifestContent.Substring(0, requiredAssembliesStart + RequiredAssembliesKey.Length)
                                + replacementContent.ToString().TrimEnd(',')
                                + "\r\n"
                                + manifestContent.Substring(requiredAssembliesEnd);

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
