using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.IO;

using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;
using System.Reflection;
using AWSPowerShellGenerator.Utils;

namespace AWSPowerShellGenerator
{
    /// <summary>
    /// Generation controller for the AWS PowerShell tools.
    /// </summary>
    public class Generator
    {
        private long? _startTimeTicks;

        const string ModulesSubFolder = "modules";
        const string DeploymentArtifactsSubFolder = "Deployment";
        string DocBuildOutputSubFolder => Path.Combine("DocDeployment", "docs");

        internal const string AWSPowerShellDllName = "AWSPowerShell.NetCore";
        internal const string AWSPowerShellCommonDllName = "AWS.Tools.Common";
        const string AWSPowerShellModuleName = "AWSPowerShell";

        // Varies depending on editon and configuration
        internal string BinSubFolder { get; private set; }

        /// <summary>
        /// How long the generation tasks took.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                if (!_startTimeTicks.HasValue)
                    throw new InvalidOperationException("Execute(...) method has not been called, no run duration data available");

                return new TimeSpan(DateTime.Now.Ticks - _startTimeTicks.Value);
            }
        }

        /// <summary>
        /// Runs one or more generation tasks.
        /// </summary>
        /// <param name="options"></param>
        public void Execute(GeneratorOptions options)
        {
            // this is just to record the run duration, so we can monitor and optimize 
            // build-time perf
            _startTimeTicks = DateTime.Now.Ticks;

            if (options.Tasks == null || options.Tasks.Count == 0)
                throw new Exception("No tasks specified for the generator to run");

            if (options.Verbose)
            {
                // todo: echo out generator options
            }

            var fqRootPath = options.RootPath;
            var sdkAssembliesFolder = options.SdkAssembliesFolder;
            var awsPowerShellSourcePath = Path.Combine(fqRootPath, ModulesSubFolder, AWSPowerShellModuleName);

            if (options.ShouldRunTask(GeneratorTasknames.GenerateCmdlets))
            {
                Console.WriteLine($"Executing task 'GenerateCmdlets' {(options.GenerateReportOnly ? "with reportonly option" : "")}");

                var cmdletGenerator = new CmdletGenerator
                {
                    SdkAssembliesFolder = sdkAssembliesFolder,
                    OutputFolder = awsPowerShellSourcePath,
                    Options = options
                };
                cmdletGenerator.Generate();

                // Note: the remaining tasks rely on having a built copy of the AWSPowerShell module,
                // so we exit so that a build can take place and the generator then re-run with the
                // new tasks
                Console.WriteLine("Task 'GenerateCmdlets' complete, exiting...");
                return;
            }

            // Batch modular tasks: generate formats and/or pshelp for all modular services in a single invocation.
            if (options.ShouldRunTask(GeneratorTasknames.GenerateModularFormats) ||
                options.ShouldRunTask(GeneratorTasknames.GenerateModularPsHelp))
            {
                ExecuteModularBatchTasks(options, fqRootPath, sdkAssembliesFolder);

                // If no other tasks are requested, we're done
                if (!options.ShouldRunTask(GeneratorTasknames.GenerateFormats) &&
                    !options.ShouldRunTask(GeneratorTasknames.GeneratePsHelp) &&
                    !options.ShouldRunTask(GeneratorTasknames.GenerateWebHelp))
                {
                    return;
                }
            }

            // Edition-dependent setup — only needed for single-assembly tasks (formats, pshelp, webhelp)
#if DEBUG
            var configuration = "Debug";
#else
            var configuration = "Release";
#endif
            BinSubFolder = Path.Combine("bin", configuration, options.TargetFramework);

            var basePath = string.IsNullOrEmpty(options.BuiltModulesLocation) ? Path.Combine(awsPowerShellSourcePath, BinSubFolder)
                                                                              : options.BuiltModulesLocation;

            var awsPsXmlPath = Path.Combine(basePath, options.AssemblyName + ".XML");
            var awsPsDllPath = Path.Combine(basePath, options.AssemblyName + ".dll");

            var awsPowerShellAssembly = Assembly.LoadFrom(awsPsDllPath);

            if (options.ShouldRunTask(GeneratorTasknames.GenerateFormats))
            {
                Console.WriteLine("Executing task 'GenerateFormats'");

                bool includeCore = options.AssemblyName.Equals(AWSPowerShellDllName, StringComparison.OrdinalIgnoreCase) ||
                                   options.AssemblyName.Equals(AWSPowerShellCommonDllName, StringComparison.OrdinalIgnoreCase);

                var targetAssemblies = new List<Assembly> { awsPowerShellAssembly };
                var sdkAssemblies = awsPowerShellAssembly.GetReferencedAssemblies()
                    .Where(assembly => assembly.Name.StartsWith("AWSSDK.", StringComparison.OrdinalIgnoreCase) &&
                                       (includeCore || !assembly.Name.Equals("AWSSDK.Core", StringComparison.OrdinalIgnoreCase)))
                    .ToArray();
                targetAssemblies.AddRange(sdkAssemblies.Select(assembly => Assembly.LoadFrom(Path.Combine(sdkAssembliesFolder, GenerationSources.DotNetPlatformNetStandard20, assembly.Name + ".dll"))));
                targetAssemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies().Where(assembly => sdkAssemblies.Contains(assembly.GetName())));

                var formatsGenerator = new FormatGenerator
                {
                    OutputFolder = basePath,
                    Name = options.AssemblyName,
                    TargetAssemblies = targetAssemblies,
                    Options = options
                };
                formatsGenerator.Generate();
            }

            if (options.ShouldRunTask(GeneratorTasknames.GeneratePsHelp))
            {
                Console.WriteLine("Executing task 'GeneratePshelp'");

                var cmdletDocumentation = new XmlDocument();
                cmdletDocumentation.Load(awsPsXmlPath);

                // For modular versions of AWS Tools module, load additional help for common parameters defined in AWS.Tools.Common.
                LoadCommonParameterHelpForModularVersion(options.AssemblyName, basePath, cmdletDocumentation);

                var pshelpGenerator = new PsHelpGenerator
                {
                    CmdletAssembly = awsPowerShellAssembly,
                    AssemblyDocumentation = cmdletDocumentation,
                    Name = options.AssemblyName,
                    OutputFolder = basePath,
                    Options = options
                };
                pshelpGenerator.Generate();
            }

            if (options.ShouldRunTask(GeneratorTasknames.GenerateWebHelp))
            {
                Console.WriteLine("Executing task 'GenerateWebhelp'");

                var cmdletDocumentation = new XmlDocument();
                cmdletDocumentation.Load(awsPsXmlPath);

                string docOutputFolder;
                if (string.IsNullOrEmpty(options.DocOutputFolder))
                    docOutputFolder = Path.Combine(fqRootPath, DocBuildOutputSubFolder);
                else
                    docOutputFolder = options.DocOutputFolder;

                var webhelpGenerator = new WebHelpGenerator
                {
                    CmdletAssembly = awsPowerShellAssembly,
                    AssemblyDocumentation = cmdletDocumentation,
                    Name = AWSPowerShellModuleName,
                    OutputFolder = docOutputFolder,
                    CNNorth1RegionDocsDomain = options.CNNorth1RegionDocsDomain,
                    Options = options
                };
                webhelpGenerator.Generate();
            }
        }

        /// <summary>
        /// Generates format and/or pshelp files for all modular services (AWS.Tools.Common + all
        /// per-service modules) in a single process invocation.
        /// </summary>
        private void ExecuteModularBatchTasks(GeneratorOptions options, string fqRootPath, string sdkAssembliesFolder)
        {
            var doFormats = options.ShouldRunTask(GeneratorTasknames.GenerateModularFormats);
            var doPsHelp = options.ShouldRunTask(GeneratorTasknames.GenerateModularPsHelp);

            if (!doFormats && !doPsHelp)
                return;

            var taskDesc = doFormats && doPsHelp ? "modular-formats + modular-pshelp"
                         : doFormats ? "modular-formats"
                         : "modular-pshelp";
            Console.WriteLine($"Executing batch task '{taskDesc}'");

            // Load service configurations
            var configurationsFolder = Path.Combine(fqRootPath, CmdletGenerator.ConfigurationFolderName);
            var modelCollection = ConfigModelCollection.LoadAllConfigs(configurationsFolder, options.Verbose);

            // Modular edition is always netstandard2.0
#if DEBUG
            var configurationName = "Debug";
#else
            var configurationName = "Release";
#endif
            var binRelPath = Path.Combine("bin", configurationName, "netstandard2.0");

            var serviceProjectsFolder = Path.Combine(fqRootPath, ModulesSubFolder, AWSPowerShellModuleName, "Cmdlets");
            var commonModuleFolder = Path.Combine(fqRootPath, ModulesSubFolder, "ModularAWSPowerShell");

            // Get list of modular services
            var modularServices = modelCollection.ConfigModels.Values
                .Where(service => !string.IsNullOrWhiteSpace(service.ServiceModuleGuid))
                .OrderBy(service => service.AssemblyName)
                .ToList();

            var totalSw = Stopwatch.StartNew();
            var serviceCount = 0;

            // Process AWS.Tools.Common first
            {
                var commonBasePath = Path.Combine(commonModuleFolder, binRelPath);

                Console.WriteLine($"  Processing {AWSPowerShellCommonDllName}...");
                GenerateModularHelpForAssembly(options, AWSPowerShellCommonDllName, commonBasePath,
                    sdkAssembliesFolder, doFormats, doPsHelp, includeCore: true);
                serviceCount++;
            }

            // Process each service module
            foreach (var service in modularServices)
            {
                var assemblyName = "AWS.Tools." + service.AssemblyName;
                var basePath = Path.Combine(serviceProjectsFolder, service.AssemblyName, binRelPath);

                if (options.Verbose)
                    Console.WriteLine($"  Processing {assemblyName}...");

                GenerateModularHelpForAssembly(options, assemblyName, basePath,
                    sdkAssembliesFolder, doFormats, doPsHelp, includeCore: false);
                serviceCount++;
            }

            totalSw.Stop();
            Console.WriteLine($"Batch '{taskDesc}' complete: {serviceCount} modules in {totalSw.Elapsed.TotalSeconds:F1}s");
        }

        /// <summary>
        /// Generates format and/or pshelp files for a single modular assembly.
        /// </summary>
        private void GenerateModularHelpForAssembly(
            GeneratorOptions options,
            string assemblyName,
            string basePath,
            string sdkAssembliesFolder,
            bool doFormats,
            bool doPsHelp,
            bool includeCore)
        {
            var dllPath = Path.Combine(basePath, assemblyName + ".dll");
            if (!File.Exists(dllPath))
            {
                throw new FileNotFoundException($"Assembly not found: {dllPath}. Ensure 'build-modular-modules' completed successfully.");
            }

            var assembly = Assembly.LoadFrom(dllPath);

            if (doFormats)
            {
                var targetAssemblies = new List<Assembly> { assembly };
                var sdkAssemblies = assembly.GetReferencedAssemblies()
                    .Where(a => a.Name.StartsWith("AWSSDK.", StringComparison.OrdinalIgnoreCase) &&
                                (includeCore || !a.Name.Equals("AWSSDK.Core", StringComparison.OrdinalIgnoreCase)))
                    .ToArray();
                targetAssemblies.AddRange(sdkAssemblies.Select(a =>
                    Assembly.LoadFrom(Path.Combine(sdkAssembliesFolder, GenerationSources.DotNetPlatformNetStandard20, a.Name + ".dll"))));
                targetAssemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => sdkAssemblies.Contains(a.GetName())));

                var formatsGenerator = new FormatGenerator
                {
                    OutputFolder = basePath,
                    Name = assemblyName,
                    TargetAssemblies = targetAssemblies,
                    Options = options
                };
                formatsGenerator.Generate();
            }

            if (doPsHelp)
            {
                var xmlPath = Path.Combine(basePath, assemblyName + ".xml");
                if (!File.Exists(xmlPath))
                {
                    throw new FileNotFoundException($"XML documentation not found: {xmlPath}. Ensure 'build-modular-modules' completed successfully.");
                }

                var cmdletDocumentation = new XmlDocument();
                cmdletDocumentation.Load(xmlPath);

                // For modular versions, load additional help for common parameters from AWS.Tools.Common
                LoadCommonParameterHelpForModularVersion(assemblyName, basePath, cmdletDocumentation);

                var pshelpGenerator = new PsHelpGenerator
                {
                    CmdletAssembly = assembly,
                    AssemblyDocumentation = cmdletDocumentation,
                    Name = assemblyName,
                    OutputFolder = basePath,
                    Options = options
                };
                pshelpGenerator.Generate();
            }
        }

        private static void LoadCommonParameterHelpForModularVersion(string assemblyName, string basePath, XmlDocument cmdletDocumentation)
        {
            if (assemblyName.StartsWith("AWS.Tools", StringComparison.OrdinalIgnoreCase))
            {
                string membersXpath = "doc/members";

                // Include help for parameters defined in AWS.Tools.Common.
                string awsToolsCommonHelpXmlPath = Path.Combine(basePath, "AWS.Tools.Common.xml");

                if (!File.Exists(awsToolsCommonHelpXmlPath))
                {
                    throw new FileNotFoundException($"Common parameter help XML not found: {awsToolsCommonHelpXmlPath}. Ensure 'build-modular-modules' completed successfully.");
                }

                var awsToolsCommonDocumentation = new XmlDocument();
                awsToolsCommonDocumentation.Load(awsToolsCommonHelpXmlPath);
                var awsToolsCommonDocMembersNode = awsToolsCommonDocumentation.SelectSingleNode(membersXpath);

                if (awsToolsCommonDocMembersNode?.ChildNodes.Count > 0)
                {
                    var cmdletDocMembersNode = cmdletDocumentation.SelectSingleNode(membersXpath);
                    foreach (XmlNode commonChildMemberNode in awsToolsCommonDocMembersNode.ChildNodes)
                    {
                        XmlNode importedNode = cmdletDocMembersNode.OwnerDocument.ImportNode(commonChildMemberNode, true);
                        cmdletDocMembersNode.AppendChild(importedNode);
                    }
                }
            }
        }
    }
}
