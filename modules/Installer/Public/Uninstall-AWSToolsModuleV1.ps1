<#
.Synopsis
    Uninstalls all currently installed AWS.Tools modules (Legacy compatibility).

.Description
    This cmdlet uses Uninstall-Module to uninstall all currently installed AWS.Tools
    modules.

    This is a legacy compatibility cmdlet that replicates the behavior of AWS.Tools.Installer 1.0.3.
    For new installations, consider using Uninstall-AWSToolsModule which may have improved functionality.

.Notes
    This cmdlet replicates the exact behavior from AWS.Tools.Installer 1.0.3.

.Example
    Uninstall-AWSToolsModuleV1 -ExceptVersion 4.0.0.0

    This example uninstalls all versions of all AWS.Tools modules except for version 4.0.0.0.
#>
function Uninstall-AWSToolsModuleV1 {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    Param(
        ## Specifies the minimum version of the modules to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MinimumVersion,

        ## Specifies exact version number of the module to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to uninstall.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MaximumVersion,

        ## Specifies that you want to uninstall all of the other available versions of AWS Tools except this one.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $ExceptVersion,

        ## Forces Uninstall-AWSToolsModuleV1 to run without asking for user confirmation
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $Force
    )

    Begin {
        # Deprecation warning
        Write-Warning "Uninstall-AWSToolsModuleV1 is deprecated. Please use Uninstall-AWSToolsModule instead for improved functionality."
        
        $MinimumVersion = Get-CleanVersion $MinimumVersion
        $RequiredVersion = Get-CleanVersion $RequiredVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion
        $ExceptVersion = Get-CleanVersion $ExceptVersion

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
        [PSModuleInfo[]]$InstalledAwsToolsModules = Get-AWSToolsModule

        if ($MinimumVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { (Get-CleanVersion $_.Version) -ge $MinimumVersion }
        }
        if ($MaximumVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { (Get-CleanVersion $_.Version) -le $MaximumVersion }
        }
        if ($RequiredVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { (Get-CleanVersion $_.Version) -eq $RequiredVersion }
        }
        if ($ExceptVersion -and $InstalledAwsToolsModules) {
            $InstalledAwsToolsModules = $InstalledAwsToolsModules | Where-Object { (Get-CleanVersion $_.Version) -ne $ExceptVersion }
        }

        if ($InstalledAwsToolsModules) {
            $versions = $InstalledAwsToolsModules | Group-Object Version

            if ($versions -and ($Force -or $WhatIfPreference -or $PSCmdlet.ShouldProcess("AWS Tools version $([string]::Join(', ', $versions.Name))"))) {
                $ConfirmPreference = 'None'

                $versions | ForEach-Object {
                    Write-Host "Uninstalling AWS.Tools version $($_.Name)"

                    [PSModuleInfo[]]$versionModules = $_.Group

                    while ($versionModules) {
                        [string[]]$dependencyNames = $versionModules | Select-Object -ExpandProperty RequiredModules | Select-Object -ExpandProperty Name | Sort-Object -Unique
                        if ($dependencyNames) {
                            [PSModuleInfo[]]$removableModules = $versionModules | Where-Object { -not $dependencyNames.Contains($_.Name) }
                        }
                        else {
                            [PSModuleInfo[]]$removableModules = $versionModules
                        }

                        if (-not $removableModules) {
                            Write-Error "Remaining modules for version $($_.Name) cannot be removed"
                            break
                        }
                        $removableModules | ForEach-Object {
                            if ($WhatIfPreference) {
                                Write-Host "What if: Uninstalling module $($_.Name)"
                            }
                            else {
                                Write-Host "Uninstalling module $($_.Name)"
                                #We need to use -Force to work around https://github.com/PowerShell/PowerShellGet/issues/542
                                $uninstallModuleParams = @{
                                    Name            = $_.Name
                                    RequiredVersion = $_.Version
                                    Force           = $true
                                    Confirm         = $false
                                    ErrorAction     = 'Continue'
                                }
                                PowerShellGet\Uninstall-Module @uninstallModuleParams
                            }
                        }

                        $versionModules = $versionModules | Where-Object { $_.Name -notin ($removableModules | Select-Object -ExpandProperty Name) }
                    }
                }
            }
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
