﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        const string ModulesSubFolder = "modules";
        const string DeploymentArtifactsSubFolder = "Deployment";
        const string DocBuildOutputSubFolder = @"DocDeployment\docs";

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

#if DEBUG
            var configuration = "Debug";
#else
            var configuration = "Release";
#endif
            BinSubFolder = string.Format("bin\\{0}\\{1}\\", configuration, options.Edition);

            var fqRootPath = Path.GetFullPath(options.RootPath);

            var sdkAssembliesFolder = Path.GetFullPath(options.SDKAssembliesFolder);
            var awsPowerShellSourcePath = Path.Combine(fqRootPath, ModulesSubFolder, AWSPowerShellModuleName);

            var deploymentArtifactsPath = Path.Combine(fqRootPath, DeploymentArtifactsSubFolder, options.Edition);

            if (options.ShouldRunTask(GeneratorTasknames.GenerateCmdlets))
            {
                Console.WriteLine("Executing task 'GenerateCmdlets'");

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

            string awsPsXmlPath;
            string awsPsDllPath;

            if (string.IsNullOrEmpty(options.BuiltModulesLocation))
            {
                var basePath = Path.Combine(awsPowerShellSourcePath, BinSubFolder);
                Console.WriteLine("Helpgen: Referencing ndoc xml/module assembly from {0}", basePath);

                awsPsXmlPath = Path.Combine(basePath, AWSPowerShellModuleName + ".xml");
                awsPsDllPath = Path.Combine(basePath, AWSPowerShellModuleName + ".dll");
            }
            else
            {
                Console.WriteLine("Helpgen: referencing ndoc xml/module assembly from {0}", options.BuiltModulesLocation);

                awsPsXmlPath = Path.Combine(options.BuiltModulesLocation, AWSPowerShellModuleName + ".xml");
                awsPsDllPath = Path.Combine(options.BuiltModulesLocation, AWSPowerShellModuleName + ".dll");
            }

            var awsPowerShellAssembly = Assembly.LoadFrom(awsPsDllPath);

            if (options.ShouldRunTask(GeneratorTasknames.GenerateFormats))
            {
                Console.WriteLine("Executing task 'GenerateFormats'");

                var targetAssemblies = new List<Assembly> { awsPowerShellAssembly };
                var sdkAssemblyFiles = Directory.GetFiles(sdkAssembliesFolder, "*.dll");
                targetAssemblies.AddRange(sdkAssemblyFiles.Select(Assembly.LoadFrom));

                var formatsGenerator = new FormatGenerator
                {
                    OutputFolder = deploymentArtifactsPath,
                    Name = AWSPowerShellModuleName,
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
                var pshelpGenerator = new PsHelpGenerator
                {
                    CmdletAssembly = awsPowerShellAssembly,
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
    }
}
