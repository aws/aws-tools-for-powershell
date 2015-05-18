using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

using AWSPowerShellGenerator.Generators;
using System.Reflection;

namespace AWSPowerShellGenerator
{
    /// <summary>
    /// Generation controller for the AWS PowerShell tools.
    /// </summary>
    public class Generator
    {
        private long? _startTimeTicks;

#if DEBUG
        const string BinSubFolder = @"bin\debug\";
#else
        const string BinSubFolder = @"bin\release\";
#endif

        const string ModulesSubFolder = "modules";
        const string DeploymentArtifactsSubFolder = "Deployment";
        const string WebHelpBuildOutputSubFolder = "WebHelpDeployment";

        const string AWSPowerShellModuleName = "AWSPowerShell";
        const string CmdletsSubFolder = "Cmdlets";

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

            var fqRootPath = Path.GetFullPath(options.RootPath);

            var sdkAssembly = Path.GetFullPath(Path.Combine(options.SDKAssembliesFolder, "AWSSDK.dll"));
            var sdkDocFile = Path.GetFullPath(Path.Combine(options.SDKAssembliesFolder, "AWSSDK.xml"));

            var sdkDocumentation = new XmlDocument();
            sdkDocumentation.Load(sdkDocFile);

            var awsPowerShellSourcePath = Path.Combine(fqRootPath, ModulesSubFolder, AWSPowerShellModuleName);
            var deploymentArtifactsPath = Path.Combine(fqRootPath, DeploymentArtifactsSubFolder);

            if (options.ShouldRunTask(GeneratorTasknames.GenerateCmdlets))
            {
                Console.WriteLine("Executing task 'GenerateCmdlets'");

                var cmdletGenerator = new CmdletGenerator
                {
                    TargetAssembly = Assembly.LoadFrom(sdkAssembly),
                    OutputFolder = awsPowerShellSourcePath,
                    AssemblyDocumentation = sdkDocumentation,
                    Options = options
                };
                cmdletGenerator.Generate();

                // Note: the remaining tasks rely on having a built copy of the AWSPowerShell module,
                // so we exit so that a build can take place and the generator then re-run with the
                // new tasks
                Console.WriteLine("Task 'GenerateCmdlets' complete, exiting...");
                return;
            }

            string awsPsXmlPath = Path.Combine(awsPowerShellSourcePath, Path.Combine(BinSubFolder, AWSPowerShellModuleName + ".xml"));
            string awsPsDllPath = Path.Combine(awsPowerShellSourcePath, Path.Combine(BinSubFolder, AWSPowerShellModuleName + ".dll"));

            if (options.ShouldRunTask(GeneratorTasknames.GenerateFormats))
            {
                Console.WriteLine("Executing task 'GenerateFormats'");

                var formatsGenerator = new FormatGenerator
                {
                    OutputFolder = deploymentArtifactsPath,
                    Name = AWSPowerShellModuleName,
                    TargetAssemblies = new List<Assembly>
                {
                    Assembly.LoadFrom(awsPsDllPath),
                    Assembly.LoadFrom(sdkAssembly)
                },
                    Options = options
                };
                formatsGenerator.Generate();
            }

            if (options.ShouldRunTask(GeneratorTasknames.GeneratePsHelp))
            {
                Console.WriteLine("Executing task 'GeneratePshelp'");

                var cmdletDocumentation = new XmlDocument();
                cmdletDocumentation.Load(awsPsXmlPath);
                var pshelpGenerator = new PsHelpGenerator
                {
                    CmdletAssembly = Assembly.LoadFrom(awsPsDllPath),
                    AssemblyDocumentation = cmdletDocumentation,
                    Name = AWSPowerShellModuleName,
                    OutputFolder = deploymentArtifactsPath,
                    Options = options
                };
                pshelpGenerator.Generate();
            }

            if (options.ShouldRunTask(GeneratorTasknames.GenerateWebHelp))
            {
                Console.WriteLine("Executing task 'GenerateWebhelp'");

                var cmdletDocumentation = new XmlDocument();
                cmdletDocumentation.Load(awsPsXmlPath);
                var webhelpGenerator = new WebHelpGenerator
                {
                    CmdletAssembly = Assembly.LoadFrom(awsPsDllPath),
                    AssemblyDocumentation = cmdletDocumentation,
                    Name = AWSPowerShellModuleName,
                    OutputFolder = Path.Combine(fqRootPath, WebHelpBuildOutputSubFolder),
                    BJSDocsDomain = options.BJSDocsDomain,
                    Options = options
                };
                webhelpGenerator.Generate();
            }
        }
    }
}
