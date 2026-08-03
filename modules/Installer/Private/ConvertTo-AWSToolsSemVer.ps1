<#
.Synopsis
    Converts a version string to an AWS Tools semantic version object.

.Description
    Parses version strings including prerelease versions (e.g., 5.0.0-preview001) and returns
    a structured object containing the version components. This function supports both standard
    3-part versions and semver prerelease versions used for preview builds.

.Parameter VersionString
    The version string to parse. Can be a standard 3-part version (5.0.0) or a semver 
    prerelease version (5.0.0-preview001).

.Returns
    A PSCustomObject with the following properties:
    - Version: [Version] The base version (Major.Minor.Build)
    - PreReleaseTag: [string] The prerelease tag (e.g., "preview001") or $null for stable versions
    - IsPreRelease: [bool] Whether this is a prerelease version
    - SemVerString: [string] The full semver string for URL construction

.Example
    ConvertTo-AWSToolsSemVer -VersionString "5.0.0"
    
    Returns an object with Version=5.0.0, PreReleaseTag=$null, IsPreRelease=$false

.Example
    ConvertTo-AWSToolsSemVer -VersionString "5.0.0-preview001"
    
    Returns an object with Version=5.0.0, PreReleaseTag="preview001", IsPreRelease=$true
#>
function ConvertTo-AWSToolsSemVer {
    [CmdletBinding()]
    [OutputType([PSCustomObject])]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [AllowEmptyString()]
        [string]$VersionString
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin"
        
        # Regex pattern for semver with optional prerelease tag
        # Matches: Major.Minor.Build or Major.Minor.Build-prerelease
        # Prerelease tag can contain alphanumeric characters and dots
        $semverPattern = '^(\d+)\.(\d+)\.(\d+)(?:-([a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*))?$'
    }

    Process {
        if ([string]::IsNullOrWhiteSpace($VersionString)) {
            return $null
        }
        
        $VersionString = $VersionString.Trim()
        
        # Validate version string length (NuGet/PowerShell Gallery limit)
        if ($VersionString.Length -gt 64) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"Version string exceeds maximum length of 64 characters: '$VersionString' (length: $($VersionString.Length))"),
                    'VersionStringTooLong',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $VersionString
                )
            )
        }
        
        Write-Debug "[$($MyInvocation.MyCommand)] Parsing version string: $VersionString"
        
        if ($VersionString -match $semverPattern) {
            $major = [int]$matches[1]
            $minor = [int]$matches[2]
            $build = [int]$matches[3]
            $preReleaseTag = if ($matches[4]) { $matches[4] } else { $null }
            
            $baseVersion = [Version]::new($major, $minor, $build)
            
            $result = [PSCustomObject]@{
                Version = $baseVersion
                PreReleaseTag = $preReleaseTag
                IsPreRelease = ($null -ne $preReleaseTag)
                SemVerString = $VersionString
                Major = $major
                Minor = $minor
                Build = $build
            }
            
            Write-Debug ("[$($MyInvocation.MyCommand)] Parsed version - Base: $baseVersion, " +
                "PreRelease: $($result.IsPreRelease), Tag: $preReleaseTag")
            
            return $result
        }
        else {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"Invalid version format: '$VersionString'. Expected format: Major.Minor.Build or Major.Minor.Build-prerelease (e.g., 5.0.0 or 5.0.0-preview001)"),
                    'InvalidVersionFormat',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $VersionString
                )
            )
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
