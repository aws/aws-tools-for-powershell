<#
.Synopsis
    Validates common parameters used across AWS.Tools.Installer functions.

.Description
    Provides centralized parameter validation with consistent error messages
    to improve user experience and reduce code duplication.

.Parameter Path
    Validates that a path is absolute and exists (if required).

.Parameter Version
    Validates that a version meets minimum requirements.

.Parameter ModuleName
    The name of the module being validated. Used to determine which validation rules to apply.
    For example, minimum version requirements only apply to AWS.Tools modules, not AWS.Tools.Installer.

.Parameter Timeout
    Validates that timeout value is reasonable.
#>
function Test-ParameterValidation {
    [CmdletBinding()]
    param(
        [Parameter()]
        [string]$Path,
        
        [Parameter()]
        [switch]$PathMustExist,
        
        [Parameter()]
        [Version]$Version,
        
        [Parameter()]
        [string]$ModuleName = 'AWS.Tools',
        
        [Parameter()]
        [int]$Timeout
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Path=$Path " +
            "PathMustExist=$PathMustExist Version=$Version Timeout=$Timeout")
    }

    Process {
        # Path validation
        if ($Path) {
            # Cross-platform path validation
            # Check if path starts with / (Unix) or contains : (Windows)
            $isRooted = $false
            if ($Path.StartsWith('/') -or $Path.StartsWith('\')) {
                $isRooted = $true
            }
            elseif ($Path -match '^[a-zA-Z]:') {
                $isRooted = $true
            }
            else {
                try {
                    $isRooted = [System.IO.Path]::IsPathRooted($Path)
                }
                catch {
                    $isRooted = $false
                }
            }
            
            if (-not $isRooted) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Path must be an absolute path: $Path"),
                        'PathNotAbsolute',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $Path
                    )
                )
            }
            
            if ($PathMustExist -and -not (Test-Path $Path)) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.IO.DirectoryNotFoundException]"Path does not exist: $Path"),
                        'PathNotFound',
                        [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                        $Path
                    )
                )
            }
        }
        
        # Version validation - apply appropriate minimum version check based on module type
        if ($Version) {
            if ($ModuleName -eq 'AWS.Tools' -and $Version -lt [Version]$script:Config.versions.MinimumSupportedVersion) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Version must be $($script:Config.versions.MinimumSupportedVersion) or higher: $Version"),
                        'VersionTooLow',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $Version
                    )
                )
            }
            elseif ($ModuleName -eq 'AWS.Tools.Installer' -and $Version -lt [Version]$script:Config.versions.CurrentMinInstallerVersion) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Version must be $($script:Config.versions.CurrentMinInstallerVersion) or higher: $Version"),
                        'InstallerVersionTooLow',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $Version
                    )
                )
            }
        }
        
        # Timeout validation
        if ($Timeout -and ($Timeout -lt $script:Config.network.TimeoutLimits.Minimum -or $Timeout -gt $script:Config.network.TimeoutLimits.Maximum)) {
            $errorMessage = "Timeout must be between $($script:Config.network.TimeoutLimits.Minimum) and $($script:Config.network.TimeoutLimits.Maximum) seconds: $Timeout"
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    (New-Object System.ArgumentOutOfRangeException "Timeout", $errorMessage),
                    'TimeoutOutOfRange',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $Timeout
                )
            )
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
