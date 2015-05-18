using System;
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
        public bool WaitOnExit { get; set; }

        /// <summary>
        /// If set, causes the generator to emit additional diagnostic messages 
        /// whilst running.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// If set, the generator triggers a build break if analysis of the output
        /// of an operation does not match what is configured.
        /// </summary>
        public bool BreakOnOutputMismatchError { get; set; }

        /// <summary>
        /// Optional log file used to contain results of the generator's
        /// analysis of sdk operations and the settings it chose as a result.
        /// </summary>
        public string AnalysisLog { get; set; }

        /// <summary>
        /// The folder containing the SDK assemblies to reflect over to 
        /// generate cmdlets.
        /// </summary>
        public string SDKAssembliesFolder { get; set; }

        /// <summary>
        /// Used when generating cmdlets, contains the comma-delimited service names to
       /// constrain generation to. If empty, all services are processed.
        /// </summary>
        public string[] Services { get; set; }

        /// <summary>
        /// The root folder location containing the generator and artifacts. Subpaths to the various components and
        /// deployment artifacts will be inferred from this location.
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
            WaitOnExit = false;
            Verbose = false;
            BreakOnOutputMismatchError = true;
            AnalysisLog = string.Empty; // no logging by default
            Services = null; // process all

            // to support F5-and-go (to test generator changes), set cmdlet gen to be the 
            // default task in debug builds.
            Tasks = new HashSet<string> { GeneratorTasknames.GenerateCmdlets };

            RootPath = @"..\..\..\.."; // relative to bin/debug folder of the generator assembly
            SDKAssembliesFolder = Path.Combine(RootPath,  @"include\sdk\dotnet35");

            CNNorth1RegionDocsDomain = "docs.amazonaws.cn"; 
        }

        public GeneratorOptions(GeneratorOptions rhs)
        {
            WaitOnExit = rhs.WaitOnExit;
            Verbose = rhs.Verbose;
            BreakOnOutputMismatchError = rhs.BreakOnOutputMismatchError;
            AnalysisLog = rhs.AnalysisLog;
            Services = rhs.Services;
            Tasks = rhs.Tasks;
            SDKAssembliesFolder = rhs.SDKAssembliesFolder;
            RootPath = rhs.RootPath;
            CNNorth1RegionDocsDomain = rhs.CNNorth1RegionDocsDomain;
        }
    }
}
