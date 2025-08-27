<#
.Synopsis
    Resolves and validates AWS Tools module names.

.Description
    Normalizes module names by adding AWS.Tools prefix if needed and validates
    that all names are valid AWS Tools modules.

.Parameter Name
    Array of module names to resolve. Can include or exclude AWS.Tools prefix.
#>
function Resolve-AWSToolsModuleNames {
    [CmdletBinding()]
    param(
        [Parameter()]
        [string[]]$Name
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - Name=($($Name -join ','))"
    }

    Process {
        if (-not $Name) {
            return $null
        }
        
        $resolvedNames = $Name | ForEach-Object {
            if ($_.Contains('.')) {
                $_
            }
            else {
                "AWS.Tools.$_"
            }
        } | Sort-Object -Unique

        $invalidNames = $resolvedNames | Where-Object { $_ -notlike 'AWS.Tools.*' }
        if ($invalidNames) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"The Name parameter must contain only AWS.Tools modules."),
                    'InvalidModuleNames',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $invalidNames
                )
            )
        }
        
        # Check for AWS.Tools.Installer and reject it
        $installerNames = $resolvedNames | Where-Object { $_ -eq 'AWS.Tools.Installer' }
        if ($installerNames) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.InvalidOperationException]"AWS.Tools.Installer cannot be installed using Install-AWSToolsModule. Use Install-AWSToolsInstaller instead."),
                    'InstallerModuleSpecified',
                    [System.Management.Automation.ErrorCategory]::InvalidOperation,
                    $installerNames
                )
            )
        }
        
        # Always include AWS.Tools.Common when specific modules are requested
        if ($resolvedNames -and -not ($resolvedNames -contains 'AWS.Tools.Common')) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Adding AWS.Tools.Common as it is required for all AWS.Tools modules"
            $resolvedNames = @('AWS.Tools.Common') + $resolvedNames
        }
        
        return $resolvedNames
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
