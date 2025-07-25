﻿using System;
using System.Collections.Generic;
using System.IO;

namespace AWSPowerShellGenerator
{
    /// <summary>
    /// The set of known task names for the generator controller. Each
    /// task invokes a separate generation process.
    /// </summary>
    public abstract class GeneratorTasknames
    {
        public const string GenerateCmdlets = "cmdlets";
        public const string GenerateFormats = "formats";
        public const string GeneratePsHelp = "pshelp";
        public const string GenerateWebHelp = "webhelp";
    }

    public class GeneratorOptions
    {
        /// <summary>
        /// If set, the generation pauses after all tasks are complete waiting
        /// for a key before shutting down.
        /// </summary>
        public bool WaitOnExit { get; set; } = false;

        /// <summary>
        /// If set, causes the generator to emit additional diagnostic messages 
        /// whilst running.
        /// </summary>
        public bool Verbose { get; set; } = false;

        /// <summary>
        /// If true (default), cmdlets are created for discovered service operations.
        /// Set false to generate code for an emergency maintenance releases without
        /// needing to configure new service operations changes first.
        /// </summary>
        public bool CreateNewCmdlets { get; set; } = true;

        /// <summary>
        /// If true, report.xml is generated when there is a new operation and
        /// there are no errors during auto-generation of the buildconfig
        /// When this is set, the generator won't throw exception for any analysis errors.
        /// The cmdlets will not be generated when this is true.
        /// </summary>
        public bool GenerateReportOnly { get; set; } = false;

        /// <summary>
        /// If true (the default is false), the build will fail if new operations are
        /// present in the SDK. Set to true for release builds when all configurations
        /// are expected to be already committed.
        /// </summary>
        public bool BreakOnNewOperations { get; set; } = false;

        /// <summary>
        /// The folder containing the platform-specific folders with SDK assemblies.
        /// </summary>
        public string SdkAssembliesFolder { get; set; }

        /// <summary>
        /// Name of the assembly to analyze, doesn't include the extension.
        /// </summary>
        public string AssemblyName { get; set; } = Generator.AWSPowerShellDllName;

        /// <summary>
        /// The four components version number to be used for the module e.g. 4.0.0.0.
        /// </summary>
        public string VersionNumber { get; set; } = "0.0.0.0";

        /// <summary>
        /// Setting this to true is equivalent to setting SkipCmdletGeneration to true in
        /// all ConfigModels for each service. If specified, allows us to skip reflecting
        /// over the service client to generate cmdlets but still process other data in 
        /// the config (eg legacy aliases). 
        /// </summary>
        public bool SkipCmdletGeneration { get; set; } = false;

        /// <summary>
        /// The root folder location containing the generator and artifacts. Subpaths to the various 
        /// components, service generation configurations and deployment artifacts will be inferred 
        /// from this location.
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// Comma-delimited names of the generator tasks to run. If not specified, nothing
        /// is done. Note that all tasks except for 'cmdlets' require a built copy of the
        /// AWSPowerShell module, therefore the generator exits after the cmdlet generation
        /// task, if specified, completes.
        /// 
        /// Valid values are:
        ///     cmdlets: generates cmdlets
        ///     formats: generates custom formats file
        ///     pshelp:  generates native ps help
        ///     webhelp: generates web x-reference help
        /// </summary>
        public HashSet<string> Tasks { get; set; }

        /// <summary>
        /// The base domain for BJS documentation, injected into the web x-reference
        /// help files.
        /// </summary>
        public string CNNorth1RegionDocsDomain { get; set; }

        /// <summary>
        /// The folder containing the built AWSPowerShell module(s). Used when generating
        /// the web docs in our release process, where we pick up the module from the Include\PowerShell
        /// folder. 
        /// </summary>
        public string BuiltModulesLocation { get; set; }

        /// <summary>
        /// Curently used only when generating web docs, to override internal defaults 
        /// and allow us to write directly into the docs repo location.
        /// </summary>
        public string DocOutputFolder { get; set; }

        /// <summary>
        /// <para>
        /// Used when running generator tasks such as format or help construction to
        /// help us find the correct AWSPowerShell module to process (desktop or coreclr).
        /// Defaults to 'desktop' if not supplied. Edition is also used in #ifdef
        /// statements in cmdlet source code where explicit targetting is required.
        /// </para>
        /// <para>
        /// Edition 'desktop' maps to output folder Deployment\AWSPowerShell.
        /// Edition 'coreclr' maps to output folder Deployment\AWSPowerShell.NetCore.
        /// </para> 
        /// </summary>
        public string Edition { get; set; }

        public string PreviewLabel { get; set; } = string.Empty;

        public bool IsPreview => !string.IsNullOrEmpty(PreviewLabel);

        /// <summary>
        /// Returns the constructed deployment folder path for the edition
        /// denoted in the Edition property.
        /// </summary>
        /// <param name="outputRoot"></param>
        /// <returns></returns>
        public string GetEditionOutputFolder(string outputRoot)
        {
            if (Edition.Equals("coreclr", StringComparison.OrdinalIgnoreCase))
                return Path.Combine(outputRoot, "AWSPowerShell.NetCore");

            if (Edition.Equals("desktop", StringComparison.OrdinalIgnoreCase))
                return Path.Combine(outputRoot, "AWSPowerShell");

            throw new InvalidOperationException("Unknown edition - " + Edition);
        }

        public string TargetFramework
        {
            get {
                if (Edition.Equals("coreclr", StringComparison.OrdinalIgnoreCase))
                    return "netstandard2.0";

            if (Edition.Equals("desktop", StringComparison.OrdinalIgnoreCase))
                    return "net472";

                throw new InvalidOperationException("Unknown edition - " + Edition);
            }
        }

        /// <summary>
        /// Internal helper used by the generator to determine if a given
        /// generation task should be run.
        /// </summary>
        /// <param name="taskName">The task being considered for run</param>
        /// <returns>True if the task should run</returns>
        internal bool ShouldRunTask(string taskName)
        {
            if (Tasks == null)
                return false;

            return Tasks.Contains(taskName);
        }

        /// <summary>
        /// Sets up the generator options for 'F5 and go' usage inside Visual Studio.
        /// Relative paths in the default options are relative to the location of the 
        /// built generator assembly.
        /// </summary>
        public GeneratorOptions()
        {
            // to support F5-and-go (to test generator changes), set cmdlet gen to be the 
            // default task in debug builds.
            Tasks = new HashSet<string> { GeneratorTasknames.GenerateCmdlets };

            RootPath = Path.GetFullPath(Path.Combine("..", "..", "..", "..")); // relative to bin/debug folder of the generator assembly
            SdkAssembliesFolder = Path.Combine(RootPath,  "include", "sdk", "nuget");

            CNNorth1RegionDocsDomain = "docs.amazonaws.cn";

            Edition = "desktop";
        }

        public GeneratorOptions(GeneratorOptions rhs)
        {
            WaitOnExit = rhs.WaitOnExit;
            Verbose = rhs.Verbose;
            CreateNewCmdlets = rhs.CreateNewCmdlets;
            BreakOnNewOperations = rhs.BreakOnNewOperations;
            Tasks = rhs.Tasks;
            SdkAssembliesFolder = rhs.SdkAssembliesFolder;
            RootPath = rhs.RootPath;
            CNNorth1RegionDocsDomain = rhs.CNNorth1RegionDocsDomain;
            Edition = rhs.Edition;
            SkipCmdletGeneration = rhs.SkipCmdletGeneration;
            PreviewLabel = rhs.PreviewLabel;
            GenerateReportOnly = rhs.GenerateReportOnly;
        }
    }
}
