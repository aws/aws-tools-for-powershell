<#
.Synopsis
    Tests if a version string is a wildcard pattern.

.Description
    Determines if a version string follows the wildcard pattern format (e.g., "4.*", "5.*").
    This centralized function ensures consistent wildcard detection across all installer functions.

.Parameter Version
    The version string to test. Can be any string value.

.Returns
    Returns $true if the version is a wildcard pattern (e.g., "5.*"), $false otherwise.

.Example
    Test-IsWildcardVersion -Version "5.*"
    
    Returns $true because "5.*" is a wildcard pattern.

.Example
    Test-IsWildcardVersion -Version "5.0.148"
    
    Returns $false because "5.0.148" is an exact version, not a wildcard.

.Example
    Test-IsWildcardVersion -Version "5.0.0-preview001"
    
    Returns $false because this is a semver prerelease version, not a wildcard.
#>
function Test-IsWildcardVersion {
    [CmdletBinding()]
    [OutputType([bool])]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [AllowEmptyString()]
        [string]$Version
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin"
    }

    Process {
        if ([string]::IsNullOrWhiteSpace($Version)) {
            return $false
        }
        
        $isWildcard = $Version -match '^\d+\.\*$'
        
        Write-Debug ("[$($MyInvocation.MyCommand)] Version '$Version' is wildcard: $isWildcard")
        
        return $isWildcard
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
