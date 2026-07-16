namespace PSReleaseNotesGenerator
{
    /// <summary>
    /// Classifies the type of breaking change detected during release notes generation.
    /// Used to populate the Type attribute on Reason elements in BreakingChangesLookup.xml.
    /// </summary>
    public enum BreakingChangeType
    {
        /// <summary>An entire service was removed from the module.</summary>
        ServiceRemoved,

        /// <summary>One or more cmdlets were removed from a service.</summary>
        CmdletRemoved,

        /// <summary>A cmdlet's output type changed.</summary>
        CmdletOutputTypeChanged,

        /// <summary>A cmdlet's default parameter set changed.</summary>
        DefaultParameterSetChanged,

        /// <summary>A cmdlet's SupportsShouldProcess attribute changed.</summary>
        SupportsShouldProcessChanged,

        /// <summary>A cmdlet's ConfirmImpact attribute changed.</summary>
        ConfirmImpactChanged,

        /// <summary>One or more parameters were removed from a cmdlet.</summary>
        ParameterRemoved,

        /// <summary>A parameter that was optional became mandatory.</summary>
        ParameterBecameMandatory,

        /// <summary>A parameter's type changed.</summary>
        ParameterTypeChanged,

        /// <summary>A parameter that was nullable is no longer nullable.</summary>
        ParameterNoLongerNullable,

        /// <summary>A parameter lost pipeline ByValue support.</summary>
        ParameterPipelineByValueRemoved,

        /// <summary>A parameter lost pipeline ByPropertyName support.</summary>
        ParameterPipelineByPropertyNameRemoved,

        /// <summary>A parameter can no longer accept remaining arguments.</summary>
        ParameterRemainingArgumentsRemoved,

        /// <summary>A parameter can no longer be used positionally.</summary>
        ParameterPositionalRemoved,

        /// <summary>A parameter's positional index changed.</summary>
        ParameterPositionChanged
    }
}
