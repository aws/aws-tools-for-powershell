<#
.Synopsis
    Gets the full version string for a module including prerelease tag.

.Description
    Constructs the full semantic version string for a module by combining the base version
    with the prerelease tag from PrivateData.PSData.Prerelease if present.

.Parameter Module
    The PSModuleInfo object to get the version string from.

.Example
    Get-ModuleVersionString -Module $moduleInfo
    
    Returns "5.0.0-preview005" for a prerelease module or "5.0.0" for a standard module.

.Notes
    This function is used internally to ensure consistent version string formatting
    across all installer operations, including display messages and logging.
#>
function Get-ModuleVersionString {
    [CmdletBinding()]
    [OutputType([string])]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [PSObject]
        $Module
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin"
    }
    
    Process {
        $versionString = "$($Module.Version.Major).$($Module.Version.Minor).$($Module.Version.Build)"
        
        # Add prerelease tag if present
        if ($Module.PrivateData.PSData.Prerelease) {
            $versionString += "-$($Module.PrivateData.PSData.Prerelease)"
        }
        
        Write-Debug "[$($MyInvocation.MyCommand)] Module $($Module.Name) version string: $versionString"
        return $versionString
    }
    
    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
