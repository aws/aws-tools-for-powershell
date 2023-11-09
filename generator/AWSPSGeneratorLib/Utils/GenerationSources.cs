using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Writers.SourceCode;
using Newtonsoft.Json.Linq;

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
        private readonly string AwsPowerShellModuleFolder;

        /// <summary>
        /// The default location that nupkg files will be loaded from
        /// </summary>
        public string SdkAssembliesFolder { get; }

        public const string SDKAssemblyNamePrefix = "AWSSDK.";
        public const string DotNetPlatformNet45 = "net45";
        public const string DotNetPlatformNetStandard20 = "netstandard2.0";

        private const string AWSPowerShellCommonGuid = "e5b05bf3-9eee-47b2-81f2-41ddc0501b86";
        private const string AWSPowerShellNetCoreGuid = "cb0b9b96-f3f2-4eff-b7f4-cbe0a9203683";
        private const string AWSPowerShellGuid = "21f083f2-4c41-4b5d-88ec-7d24c9e88769";
        private readonly string[] AwsToolsCommonSdkAssemblies = { "AWSSDK.Core", "AWSSDK.SecurityToken" };
        private readonly string[] AdditionalCrtAssemblies = { "aws-crt", "aws-crt-auth", "aws-crt-http", "aws-crt-checksums", "AWSSDK.Extensions.CrtIntegration" };

        //All paths are relative to the AwsPowerShellModuleFolder
        public static readonly string AWSPowerShellModularSolutionFilename = Path.Combine("..", "..", "solutions", "ModularAWSPowerShell.sln");
        public static readonly string CopyModularArtifactsScriptFilename = Path.Combine("..", "..", "buildtools", "CopyModularAWSPowerShell.ps1");
        public static readonly string AWSPowerShellCommonModuleFilename = Path.Combine("..", "ModularAWSPowerShell", "AWS.Tools.Common.psd1");
        public static readonly string CmdletsListFilename = "CmdletsList.dat";
        public static readonly string ModularCmdletsListFilename = Path.Combine("..", "ModularAWSPowerShell", "CmdletsList.dat");
        public static readonly string AWSPowerShellCommonProjectFilename = Path.Combine("..", "ModularAWSPowerShell", "AWS.Tools.Common.csproj");
        public static readonly string CommonModuleLegacyAliasesFilename = Path.Combine("..", "ModularAWSPowerShell", "AWS.Tools.Common.Aliases.psm1");
        public const string AWSPowerShellProjectFilename = "AWSPowerShell.csproj";
        public static readonly string MonolithicProjectFileName = "AWSPowerShell.csproj";
        public static readonly string MonolithicModule35FileName = "AWSPowerShell.psd1";
        public static readonly string MonolithicModuleStandardFileName = "AWSPowerShell.NetCore.psd1";
        public const string ArgumentCompleterScriptModuleFilename = "AWSPowerShellCompleters.psm1";
        public static readonly string CommonArgumentCompleterScriptModuleFilename = Path.Combine("..", "ModularAWSPowerShell", "AWS.Tools.Common.Completers.psm1");
        public const string AWSPowerShellVersionJsonFilename = "awspowershell_versioninfo.json";
        public static readonly string CompletersConfigFoldername = Path.Combine("..", "..", "generator", "AWSPSGeneratorLib", "CompletersConfig");
        // the legacy aliases file is where we rename cmdlets without incurring breaking changes;
        // the module is auto-loaded when our main module loads
        public const string LegacyAliasesScriptModuleFilename = "AWSPowerShellLegacyAliases.psm1";
        // this aliases file maps from service_opname to cmdletname; it's not the same as the legacy
        // aliases file and is not loaded by default
        public const string AdditionalAliasesFilename = "AWSAliases.ps1";

        private static string[] PlatformsToExtractLibrariesFor = new string[] { DotNetPlatformNet45, DotNetPlatformNetStandard20 };

        public string ModuleVersionNumber { get; }

        public GenerationSources(string awsPowerShellModuleFolder, string sdkAssembliesFolder, string versionNumber)
        {
            AwsPowerShellModuleFolder = awsPowerShellModuleFolder;
            SdkAssembliesFolder = sdkAssembliesFolder;

            Func<string, string> sanitizeInteger = (string s) =>
            {
                if (!int.TryParse(s, out var n))
                {
                    n = -1;
                }
                return n.ToString();
            };

            var splitVersion = versionNumber.Split('.');
            if (versionNumber != "0.0.0.0" &&
                (splitVersion.Length < 3 ||
                 !versionNumber.StartsWith("4.1.") ||
                 versionNumber != string.Join(".", splitVersion.Select(sanitizeInteger))))
            {
                throw new FileFormatException($"Invalid version number {versionNumber}");
            }
            ModuleVersionNumber = versionNumber;
        }

        /// <summary>
        /// Loads the assembly and ndoc data for the given assembly basename using the
        /// default folder location.
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="assembly"></param>
        /// <param name="ndoc"></param>
        /// <param name="addAsReference">If false, the method just downloads the NuGet package and unpacks the
        /// assemblies without adding them to the list of assemblies to be referenced</param>
        public (Assembly Assembly, XmlDocument Ndoc, IEnumerable<string> Dependencies) Load(string baseName, bool addAsReference = true)
        {
            if (string.IsNullOrEmpty(SdkAssembliesFolder))
            {
                throw new InvalidOperationException("Expected 'SdkNugetFolder' to have been set prior to calling Load(...)");
            }

            SdkVersionsUtils.EnsureSdkLibraryIsAvailable(baseName, SdkAssembliesFolder, PlatformsToExtractLibrariesFor);
            var dependencies = SdkVersionsUtils.GetDependencies(SdkAssembliesFolder, baseName);


            if (addAsReference)
            {
                var assemblyFile = Path.Combine(SdkAssembliesFolder, DotNetPlatformNetStandard20, $"{baseName}.dll");
                var ndocFile = Path.Combine(SdkAssembliesFolder, DotNetPlatformNetStandard20, $"{baseName}.xml");
                try
                {
                    var assembly = Assembly.LoadFrom(assemblyFile);
                    var ndoc = new XmlDocument();
                    ndoc.Load(ndocFile);

                    Add(baseName, assembly, ndoc);
                    return (assembly, ndoc, dependencies);
                }
                catch (Exception)
                {
                    Console.WriteLine("An exception occurred while processing files {0} and {1}.", assemblyFile, ndocFile);
                    throw;
                }
            }

            return (null, null, null);
        }

        /// <summary>
        /// Finds all the distinct net45 and netstandard2.0 SDK filenames from the assemblies folder.
        /// </summary>
        /// <param name="SdkAssembliesFolder">Location of the SDK assemblies to generate against.</param>
        /// <param name="EnumerateFiles">Function used to enumerate the files in the assemblies folder. This
        /// function matches the signature of Directory.EnumerateFiles in order to have a search filter
        /// and search options while we process the files on demand.</param>
        /// <returns>A distinct list of sdk assembly full filenames.</returns>
        public static IEnumerable<string> SDKFindAssemblyFilenames(string SdkAssembliesFolder,
            Func<string, string, SearchOption, IEnumerable<string>> EnumerateFiles)
        {
            //PowerShell works with netstandard2.0 and net45 so we will find those AWSSDK assembly filenames.
            var foundNet45SdkFilenames = EnumerateFiles(
                Path.Combine(SdkAssembliesFolder, DotNetPlatformNet45),
                "AWSSDK.*.dll",
                SearchOption.TopDirectoryOnly)
                .Select(fullFilename => Path.GetFileNameWithoutExtension(fullFilename).Substring("AWSSDK.".Length));
            var foundNetstandard20SdkFilenames = EnumerateFiles(
                Path.Combine(SdkAssembliesFolder, DotNetPlatformNetStandard20),
                "AWSSDK.*.dll",
                SearchOption.TopDirectoryOnly)
                .Select(fullFilename => Path.GetFileNameWithoutExtension(fullFilename).Substring("AWSSDK.".Length));
            var distinctAssemblyFilenames = foundNet45SdkFilenames.Union(foundNetstandard20SdkFilenames)
                .Where(name => !name.StartsWith("Extensions.", StringComparison.OrdinalIgnoreCase)
                    && !name.Equals("Core", StringComparison.OrdinalIgnoreCase)
                    && !name.Equals("Macie", StringComparison.OrdinalIgnoreCase));

            return distinctAssemblyFilenames;
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
                return;
            }

            Assemblies.Add(baseName, assembly);
            NDocs.Add(baseName, ndoc);
        }

        public void WriteModularSolution(IEnumerable<ConfigModel> services)
        {
            var solutionFile = Path.Combine(AwsPowerShellModuleFolder, AWSPowerShellModularSolutionFilename);

            var fileContents = ModularSolutionFileTemplate.Generate(services);
            File.WriteAllText(solutionFile, fileContents);
        }

        public void WriteServiceProjectFile(ConfigModel service)
        {
            var projectFile = Path.Combine(AwsPowerShellModuleFolder, "Cmdlets", service.AssemblyName, $"AWS.Tools.{service.AssemblyName}.csproj");

            var fileContents = ServiceProjectFileTemplate.Generate(service, ModuleVersionNumber);

            File.WriteAllText(projectFile, fileContents);
        }

        public void WriteCommonProjectFile()
        {
            var projectFile = Path.Combine(AwsPowerShellModuleFolder, AWSPowerShellCommonProjectFilename);

            var fileContents = CommonProjectFileTemplate.Generate(ModuleVersionNumber);

            File.WriteAllText(projectFile, fileContents);
        }

        public void WriteCmdletsList(IEnumerable<ConfigModel> services)
        {
            var cmdletsListFile = Path.Combine(AwsPowerShellModuleFolder, CmdletsListFilename);

            var fileContents = CmdletListTemplate.Generate(services, false);

            using (var textStream = new MemoryStream(new UTF8Encoding(false).GetBytes(fileContents)))
            using (var fileStream = new FileStream(cmdletsListFile, FileMode.Create))
            using (var gzipFileStream = new GZipStream(fileStream, CompressionLevel.Optimal))
            {
                textStream.CopyTo(gzipFileStream);
            }
        }

        public void WriteCommonModuleCmdletsList(IEnumerable<ConfigModel> services)
        {
            var cmdletsListFile = Path.Combine(AwsPowerShellModuleFolder, ModularCmdletsListFilename);

            var fileContents = CmdletListTemplate.Generate(services, true);

            using (var textStream = new MemoryStream(new UTF8Encoding(false).GetBytes(fileContents)))
            using (var fileStream = new FileStream(cmdletsListFile, FileMode.Create))
            using (var gzipFileStream = new GZipStream(fileStream, CompressionLevel.Optimal))
            {
                textStream.CopyTo(gzipFileStream);
            }
        }

        public void WriteCommonModule(IEnumerable<string> commonAdvancedCmdlets, Dictionary<string, HashSet<string>> commonLegacyAliases)
        {
            var projectFile = Path.Combine(AwsPowerShellModuleFolder, AWSPowerShellCommonModuleFilename);

            var fileContents = ManifestFileTemplate.Generate(
                "AWS.Tools.Common",
                "AWS.Tools.Common.dll",
                AWSPowerShellCommonGuid,
                ModuleVersionNumber,
                "The AWS Tools for PowerShell lets developers and administrators manage their AWS services from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...)." + Environment.NewLine +
                    "The module AWS.Tools.Installer (https://www.powershellgallery.com/packages/AWS.Tools.Installer/) makes it easier to install, update and uninstall the AWS.Tools modules." + Environment.NewLine +
                    "This version of AWS Tools for PowerShell is compatible with Windows PowerShell 5.1+ and PowerShell Core 6+ on Windows, Linux and macOS. When running on Windows PowerShell, .NET Framework 4.7.2 or newer is required." + Environment.NewLine +
                    "Alternative modules, AWSPowerShell.NetCore and AWSPowerShell, provide support for all AWS services from a single module and also support older versions of Windows PowerShell and .NET Framework.",
                compatiblePowerShellVersion: 5,
                compatiblePowerShellMinorVersion: 1,
                assemblies: AwsToolsCommonSdkAssemblies.Concat(AdditionalCrtAssemblies),
                nestedModulesFiles: new string[] { "AWS.Tools.Common.Completers.psm1",
                                                   "AWS.Tools.Common.Aliases.psm1" },
                fileList: new string[] { "AWS.Tools.Common.dll-Help.xml" },
                scriptsToProcess: new string[] { "ImportGuard.ps1" },
                aliasesToExport: commonLegacyAliases.SelectMany(cmdlet => cmdlet.Value),
                cmdletsToExport: commonAdvancedCmdlets);

            File.WriteAllText(projectFile, fileContents);
        }

        public void WriteMonolithicModuleFiles()
        {
            WriteMonolithicModuleFile(Path.Combine(AwsPowerShellModuleFolder, MonolithicModuleStandardFileName), true);
            WriteMonolithicModuleFile(Path.Combine(AwsPowerShellModuleFolder, MonolithicModule35FileName), false);
        }

        private void WriteMonolithicModuleFile(string filePath, bool netStandard)
        {
            var fileContents = ManifestFileTemplate.Generate(
                netStandard ? "AWSPowerShell.NetCore" : "AWSPowerShell",
                netStandard ? "AWSPowerShell.NetCore.dll" : "AWSPowerShell.dll",
                netStandard ? AWSPowerShellNetCoreGuid : AWSPowerShellGuid,
                ModuleVersionNumber,
                netStandard ?
                "The AWS Tools for PowerShell lets developers and administrators manage their AWS services from the PowerShell scripting environment." + Environment.NewLine +
                    "This version of AWS Tools for PowerShell is compatible with Windows PowerShell 3+ and PowerShell Core 6+ on Windows, Linux and macOS. When running on Windows PowerShell, .NET Framework 4.7.2 or newer is required. An alternative module, AWSPowerShell, provides support for older versions of Windows PowerShell and .NET Framework." + Environment.NewLine +
                    "This product provides support for all AWS services in a single module. As an alternative, a modular variant is also available: separate smaller modules (e.g. AWS.Tools.EC2, AWS.Tools.S3...) allow managing each AWS Service." :
                "The AWS Tools for Windows PowerShell lets developers and administrators manage their AWS services from the Windows PowerShell scripting environment." + Environment.NewLine +
                    "This version of AWS Tools for Windows PowerShell is compatible with Windows PowerShell 2-5.1. An alternative module, AWSPowerShell.NetCore, provides support for Windows PowerShell 3+ and PowerShell Core 6+ on Windows, Linux and macOS." + Environment.NewLine +
                    "This product provides support for all AWS services in a single module. As an alternative, a modular variant is also available: separate smaller modules (e.g. AWS.Tools.EC2, AWS.Tools.S3...) allow managing each AWS Service.",
                compatiblePowerShellVersion: 3,
                compatibleFrameworkVersion: netStandard ? "4.7.2" : "4.5",
                netStandard: netStandard,
                assemblies: Assemblies.Keys.ToArray().Concat(AdditionalCrtAssemblies),
                typesToProcessFiles: new string[] { "AWSPowerShell.TypeExtensions.ps1xml" },
                formatsToProcessFiles: new string[] { $"AWSPowerShell{(netStandard ? ".NetCore" : "")}.Format.ps1xml" },
                nestedModulesFiles: new string[] { "AWSPowerShellCompleters.psm1",
                                                   "AWSPowerShellLegacyAliases.psm1" },
                scriptsToProcess: new string[] { "ImportGuard.ps1" },
                fileList: new string[] { $"AWSPowerShell{(netStandard ? ".NetCore" : "")}.dll-Help.xml",
                                         "CHANGELOG.txt"});

            File.WriteAllText(filePath, fileContents);
        }

        public void WriteModularManifestFiles(IEnumerable<ConfigModel> services, Dictionary<string, Dictionary<string, string>> legacyAliases)
        {
            foreach (var project in services.GroupBy(service => service.AssemblyName)
                                            .Where(project => project.Any((service) => !string.IsNullOrWhiteSpace(service.ServiceModuleGuid))))
            {
                try
                {
                    if (!legacyAliases.TryGetValue(project.Key, out var projectAliases))
                    {
                        projectAliases = new Dictionary<string, string>();
                    }

                    var dependencies = services
                        .Where(service => !string.IsNullOrWhiteSpace(service.ServiceModuleGuid) &&
                                          project.First().SDKDependencies.Contains(service.AssemblyName))
                        .ToArray();

                    var mainServiceConfig = project.Single(service => !string.IsNullOrEmpty(service.ServiceModuleGuid));

                    var fileContents = ManifestFileTemplate.Generate(
                        $"AWS.Tools.{project.Key}",
                        $"AWS.Tools.{project.Key}.dll",
                        mainServiceConfig.ServiceModuleGuid,
                        ModuleVersionNumber,
                        $"The {mainServiceConfig.AssemblyName} module of AWS Tools for PowerShell lets developers and administrators manage {mainServiceConfig.ServiceName} from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...)." + Environment.NewLine +
                            "The module AWS.Tools.Installer (https://www.powershellgallery.com/packages/AWS.Tools.Installer/) makes it easier to install, update and uninstall the AWS.Tools modules." + Environment.NewLine +
                            "This version of AWS Tools for PowerShell is compatible with Windows PowerShell 5.1+ and PowerShell Core 6+ on Windows, Linux and macOS. When running on Windows PowerShell, .NET Framework 4.7.2 or newer is required. Alternative modules AWSPowerShell.NetCore and AWSPowerShell, provide support for all AWS services from a single module and also support older versions of Windows PowerShell and .NET Framework.",
                        compatiblePowerShellVersion: 5,
                        compatiblePowerShellMinorVersion: 1,
                        assemblies: new string[] { $"AWSSDK.{project.Key}" }.Except(AwsToolsCommonSdkAssemblies),
                        formatsToProcessFiles: new string[] { $"AWS.Tools.{project.Key}.Format.ps1xml" },
                        fileList: new string[] { $"AWS.Tools.{project.Key}.dll-Help.xml" },
                        nestedModulesFiles: new string[] { $"AWS.Tools.{project.Key}.Completers.psm1",
                                                           $"AWS.Tools.{project.Key}.Aliases.psm1" },
                        requiredModules: dependencies
                            .Select(service => new ManifestFileTemplate.DependencyModule($"AWS.Tools.{service.AssemblyName}", service.ServiceModuleGuid))
                            .Concat(new ManifestFileTemplate.DependencyModule[] {
                                new ManifestFileTemplate.DependencyModule("AWS.Tools.Common", AWSPowerShellCommonGuid) }),
                        cmdletsToExport: project
                            .SelectMany(service => service.ServiceOperationsList
                                .Where(operation => !operation.Exclude))
                            .Select(operation => $"{operation.SelectedVerb}-{operation.SelectedNoun}")
                            .Concat(project
                                .SelectMany(service => service.AdvancedCmdlets.Keys))
                            .OrderBy(name => name),
                        aliasesToExport: projectAliases.Keys);

                    File.WriteAllText(Path.Combine(AwsPowerShellModuleFolder, CmdletGenerator.CmdletsOutputSubFoldername, project.Key, $"AWS.Tools.{project.Key}.psd1"), fileContents);
                }
                catch (Exception e)
                {
                    foreach (var service in project)
                    {
                        AnalysisError.ExceptionWhileWritingServiceProjectFile(service, e);
                    }
                }
            }
        }

        public void WriteVersionFile()
        {
            var filePath = Path.Combine(AwsPowerShellModuleFolder, AWSPowerShellVersionJsonFilename);

            var versionRecap = new JObject(
                new JProperty("awspowershell.netcore",
                    new JObject(
                        new JProperty("latest", ModuleVersionNumber))),
                new JProperty("awspowershell",
                    new JObject(
                        new JProperty("latest", ModuleVersionNumber))));

            File.WriteAllText(filePath, versionRecap.ToString());
        }

        public void WriteCopyModularArtifactsScript(IEnumerable<ConfigModel> services)
        {
            var projectFile = Path.Combine(AwsPowerShellModuleFolder, CopyModularArtifactsScriptFilename);

            var fileContents = CopyModularArtifactsScriptTemplate.Generate(services);
            File.WriteAllText(projectFile, fileContents);
        }

        public void WriteMonolithicCompletionScriptsFile(string completionScript)
        {
            var scriptFile = Path.Combine(AwsPowerShellModuleFolder, ArgumentCompleterScriptModuleFilename);

            WriteCompletionScriptsFile(scriptFile, completionScript);
        }

        public void WriteCommonCompletionScriptsFile()
        {
            var scriptFile = Path.Combine(AwsPowerShellModuleFolder, CommonArgumentCompleterScriptModuleFilename);

            WriteCompletionScriptsFile(scriptFile, string.Empty, "Common");
        }

        /// <summary>
        /// Injects the generated completer functions into one script module file. This has proven faster
        /// to load than one scriptfile per service.
        /// </summary>
        private void WriteCompletionScriptsFile(string completorsScriptModuleFile, string completionScript, string customCompletersFilter = null)
        {
            string fileHeader;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AWSPowerShellGenerator.CompletersHeader.psm1"))
            using (var reader = new StreamReader(stream))
            {
                fileHeader = reader.ReadToEnd();
            }

            var customCompletersFolder = Path.Combine(AwsPowerShellModuleFolder, CompletersConfigFoldername);

            string[] customCompleterFiles;
            if (customCompletersFilter == null)
            {
                customCompleterFiles = Directory.GetFiles(customCompletersFolder, "*.psm1");
            }
            else
            {
                var fileName = Path.Combine(customCompletersFolder, $"{customCompletersFilter}.psm1");
                customCompleterFiles = File.Exists(fileName) ? new string[] { fileName } : Array.Empty<string>();
            }

            using (var writer = File.CreateText(completorsScriptModuleFile))
            {
                writer.WriteLine(fileHeader);
                writer.WriteLine();
                writer.WriteLine(completionScript);
                foreach(var customCompleterFile in customCompleterFiles)
                {
                    string content = File.ReadAllText(customCompleterFile);
                    writer.WriteLine();
                    writer.Write(content);
                }
            }
        }

        /// <summary>
        /// Writes the AWSPowerShellLegacyAliases.psm1 nested module file, containing a set of
        /// Set-Alias commands to map legacy cmdlet names to the current names.
        /// </summary>
        public void WriteLegacyAliasesFile(Dictionary<string, Dictionary<string, string>> legacyAliases, Dictionary<string, HashSet<string>> commonLegacyAliases)
        {
            var legacyAliasesScriptModuleFilename = Path.Combine(AwsPowerShellModuleFolder, LegacyAliasesScriptModuleFilename);

            var sections = new[] { new AliasFileTemplate.AliasFileSection("Shell Configuration", commonLegacyAliases
                    .SelectMany(cmdlet => cmdlet.Value.Select(alias => (alias, cmdlet.Key)))
                    .ToDictionary(alias => alias.alias, alias => alias.Key)) }
                .Concat(legacyAliases
                    .OrderBy(projectAliases => projectAliases.Key)
                    .Select(projectAliases => new AliasFileTemplate.AliasFileSection(projectAliases.Key, projectAliases.Value)));

            string fileContent = AliasFileTemplate.Generate(sections);

            File.WriteAllText(legacyAliasesScriptModuleFilename, fileContent, Encoding.UTF8);
        }

        public void WriteLegacyAliasesFileForCommonModule(Dictionary<string, HashSet<string>> commonLegacyAliases)
        {
            var scriptFile = Path.Combine(AwsPowerShellModuleFolder, CommonModuleLegacyAliasesFilename);

            var sections = new[] { new AliasFileTemplate.AliasFileSection("Shell Configuration", commonLegacyAliases
                .SelectMany(cmdlet => cmdlet.Value.Select(alias => (alias, cmdlet.Key)))
                .ToDictionary(alias => alias.alias, alias => alias.Key)) };

            string fileContent = AliasFileTemplate.Generate(sections);

            File.WriteAllText(scriptFile, fileContent, Encoding.UTF8);
        }

        /// <summary>
        /// Writes the .psm1 nested module file, for each modular project. They contain a set of
        /// Set-Alias commands to map legacy cmdlet names to the current names.
        /// </summary>
        public void WriteLegacyAliasesModularFiles(Dictionary<string, Dictionary<string, string>> legacyAliases, IEnumerable<ConfigModel> services)
        {
            foreach (var assemblyName in services
                .Where(model => !string.IsNullOrWhiteSpace(model.ServiceModuleGuid))
                .Select(model => model.AssemblyName))
            {
                if (!legacyAliases.TryGetValue(assemblyName, out var projectAliases))
                {
                    projectAliases = new Dictionary<string, string>();
                }

                var sections = new[] { new AliasFileTemplate.AliasFileSection(assemblyName, projectAliases) };

                string fileContent = AliasFileTemplate.Generate(sections);
                string filePath = Path.Combine(AwsPowerShellModuleFolder, CmdletGenerator.CmdletsOutputSubFoldername, assemblyName, $"AWS.Tools.{assemblyName}.Aliases.psm1");

                File.WriteAllText(filePath, fileContent, Encoding.UTF8);
            }
        }

        public void WriteAdditionalAliasesFiles(string aliases)
        {
            string scriptFile = Path.Combine(AwsPowerShellModuleFolder, AdditionalAliasesFilename);

            using (var sw = new StreamWriter(scriptFile, false, new UTF8Encoding(false)))
            {
                sw.WriteLine(aliases);
            }
        }

        public void WriteMonolithicProjectFile()
        {
            string projectFilePath = Path.Combine(AwsPowerShellModuleFolder, MonolithicProjectFileName);

            string fileContent = MonolithicProjectFileTemplate.Generate(Assemblies.Keys, ModuleVersionNumber);

            File.WriteAllText(projectFilePath, fileContent, Encoding.UTF8);
        }

        /// <summary>
        /// Writes the completer scrip files for each modular project.
        /// </summary>
        public void WriteCompletersModularFiles(IEnumerable<ConfigModel> services)
        {
            foreach (var assemblyName in services
                .Where(model => !string.IsNullOrWhiteSpace(model.ServiceModuleGuid))
                .Select(model => model.AssemblyName))
            {
                string filePath = Path.Combine(AwsPowerShellModuleFolder, CmdletGenerator.CmdletsOutputSubFoldername, assemblyName, $"AWS.Tools.{assemblyName}.Completers.psm1");
                var stringBuilder = new StringBuilder();
                foreach (var model in services.Where(service => service.AssemblyName == assemblyName))
                {
                    stringBuilder.Append(CompletersFileTemplate.Generate(model));
                }
                WriteCompletionScriptsFile(filePath, stringBuilder.ToString(), assemblyName);
            }
        }

        public void WriteModularProjectFiles(IEnumerable<ConfigModel> services)
        {
            foreach (var model in services
                .Where(model => !string.IsNullOrWhiteSpace(model.ServiceModuleGuid)))
            {
                try
                {
                    WriteServiceProjectFile(model);
                }
                catch (Exception e)
                {
                    AnalysisError.ExceptionWhileWritingServiceProjectFile(model, e);
                }
            }
        }
    }
}
