using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Analysis
{
    /// <summary>
    /// Holds the result of inspection on a method to determine if it
    /// requires the 'SupportsShouldProcess' attribution. Attribution
    /// can be enabled manually for an operation using the 'ShouldProcessTarget'
    /// configuration attribute to identify the cmdlet parameter that
    /// should be prompted on, or via inspection to find parameters
    /// with known name suffixes.
    /// </summary>
    internal class SupportsShouldProcessInspection
    {
        /// <summary>
        /// How we came to decide the cmdlet should be attributed with
        /// 'SupportsShouldProcess' or the reason the generator was not
        /// able to auto-determine the target type.
        /// </summary>
        public enum InspectionStatus
        {
            TargetFromConfig,
            TargetFromAnalysis,
            AnonymousTarget,
            ErrorNoRecognizableParameterSuffix,
            ErrorMultipleTargetOptions
        }

        public InspectionStatus Status { get; set; }

        /// <summary>
        /// Set to the parameter that will be used by the PowerShell host
        /// to obtain the id or name of the resource to use when prompting to
        /// suppport the -Confirm and -WhatIf parameters enabled for the cmdlet
        /// by the shell when the cmdlet is attributed with SupportsShouldProceess. 
        /// </summary>
        public SimplePropertyInfo TargetParameter { get; set; }

        /// <summary>
        /// This is just for the analysis log and allows some extra context on why
        /// a given parameter was selected as the target.
        /// </summary>
        public string AnalysisMessage { get; set; }
    }
}
