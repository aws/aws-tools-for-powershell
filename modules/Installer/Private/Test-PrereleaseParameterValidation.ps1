<#
.Synopsis
    Validates prerelease parameter usage.

.Description
    Centralized validation for the -Prerelease parameter across installer commands.
    Ensures consistent validation behavior for Install-AWSToolsModule, Install-AWSToolsInstaller,
    and Update-AWSToolsModule.

.Parameter Version
    The version string to validate. Can be exact version, wildcard, semver, or null/empty.

.Parameter Prerelease
    Whether the -Prerelease switch was specified.

.Parameter ModuleName
    The name of the module for error messages (e.g., "AWS.Tools", "AWS.Tools.Installer").

.Returns
    Returns a hashtable with:
    - IsPreReleaseVersion: $true if version is a semver prerelease (e.g., "5.0.0-preview001")
    - IsWildcardVersion: $true if version is a wildcard pattern (e.g., "5.*")

.Example
    Test-PrereleaseParameterValidation -Version "5.0.0-preview001" -Prerelease $true -ModuleName "AWS.Tools"
    
    Returns @{ IsPreReleaseVersion = $true; IsWildcardVersion = $false }

.Example
    Test-PrereleaseParameterValidation -Version "5.*" -Prerelease $true -ModuleName "AWS.Tools"
    
    Returns @{ IsPreReleaseVersion = $false; IsWildcardVersion = $true }
#>
function Test-PrereleaseParameterValidation {
    [CmdletBinding()]
    [OutputType([hashtable])]
    param(
        [Parameter()]
        [AllowEmptyString()]
        [string]$Version,
        
        [Parameter(Mandatory)]
        [bool]$Prerelease,
        
        [Parameter()]
        [string]$ModuleName = 'AWS.Tools'
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - Version='$Version' Prerelease=$Prerelease"
    }

    Process {
        # Detect version type
        $isPreReleaseVersion = $false
        $isWildcardVersion = $false
        
        if (-not [string]::IsNullOrWhiteSpace($Version)) {
            if ($Version -match '^\d+\.\d+\.\d+-.+$') {
                $isPreReleaseVersion = $true
            }
            elseif (Test-IsWildcardVersion -Version $Version) {
                $isWildcardVersion = $true
            }
        }
        
        # Validate that -Prerelease switch is specified for prerelease versions
        if ($isPreReleaseVersion -and -not $Prerelease) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"The -Prerelease switch must be specified when installing a prerelease version ('$Version'). Use -Version '$Version' -Prerelease to install this version."),
                    'PrereleaseVersionRequiresSwitch',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $Version
                )
            )
        }
        
        # Validate that -Prerelease with explicit version is either:
        # 1. A prerelease version (e.g., 5.0.0-preview001)
        # 2. A wildcard version (e.g., 5.*)
        # 3. Empty/null (for latest preview)
        if ($Prerelease -and -not $isPreReleaseVersion -and -not $isWildcardVersion -and -not [string]::IsNullOrWhiteSpace($Version)) {
            # Customize error message based on module
            $exampleVersion = if ($ModuleName -eq 'AWS.Tools.Installer') { "2.0.0-preview001" } else { "5.0.0-preview001" }
            $exampleWildcard = if ($ModuleName -eq 'AWS.Tools.Installer') { "2.*" } else { "5.*" }
            
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"The -Prerelease switch was specified but the version '$Version' is not a prerelease version or wildcard pattern. Prerelease versions must include a prerelease tag (e.g., $exampleVersion) or use a wildcard pattern (e.g., $exampleWildcard)."),
                    'PrereleaseVersionRequired',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $Version
                )
            )
        }
        
        Write-Debug ("[$($MyInvocation.MyCommand)] IsPreReleaseVersion=$isPreReleaseVersion " +
            "IsWildcardVersion=$isWildcardVersion")
        
        return @{
            IsPreReleaseVersion = $isPreReleaseVersion
            IsWildcardVersion = $isWildcardVersion
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
