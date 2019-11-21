function AWSToolsImportGuard() {
    $rootModules = @( 'AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools.Common' )

    if ($PSVersionTable.PSVersion.Major -ge 5) {
        $importingModule = Get-Module "$PSScriptRoot/*.psd1" -ListAvailable
        if ($importingModule.Count -eq 1) {
            $importingModuleData = Import-PowerShellDataFile $importingModule.Path
            $message = "Module $($importingModule.Name) version $($importingModuleData.ModuleVersion) failed importing. " + $message    
        }
    }

    foreach ($rootModule in $rootModules) {
        $version = Get-Module -Name $rootModule | Select-Object Version
        if ($version) {
            $message = "$rootModule version $($version.Version) is currently imported. Only a single version of a single variant of AWS Tools for PowerShell (AWSPowerShell, AWSPowerShell.NetCore or AWS.Tools.Common) can be imported at any time."

            if ($importingModuleData) {
                $message = "Module $($importingModule.Name) version $($importingModuleData.ModuleVersion) failed importing. " + $message    
            }

            Write-Error $message
        }
    }

    $installedAWSToolsModules = Get-Module AWS.Tools.* -ListAvailable | Where-Object { $_.Name -ne 'AWS.Tools.Installer' }
    $maxAWSToolsVersion = $installedAWSToolsModules | Select-Object -ExpandProperty Version | Measure-Object -Maximum | Select-Object -ExpandProperty Maximum
    if ($importingModuleData -and $maxAWSToolsVersion) {
        $maxVersionModules = $installedAWSToolsModules | Where-Object { $_.Version -eq $maxAWSToolsVersion } | Select-Object -ExpandProperty Name | Sort-Object -Unique
        $prevVersionsModules = $installedAWSToolsModules | Where-Object { $_.Version -ne $maxAWSToolsVersion } | Select-Object -ExpandProperty Name | Sort-Object -Unique
        if ($prevVersionsModules | Where-Object { -not $maxVersionModules.Contains($_) }) {
            if (Get-Module 'AWS.Tools.Installer' -ListAvailable) {
                Write-Warning 'You have mismatched versions of the AWS.Tools modules. You can use Update-AWSToolsModule to synchronize the versions of all installed AWS.Tools modules.'
            } else {
                Write-Warning 'You have mismatched versions of the AWS.Tools modules. You can run ''Install-Module AWS.Tools.Installer ; Update-AWSToolsModule'' to synchronize the versions of all installed AWS.Tools modules.'
            }
        }
    }

    if (($rootModules | Where-Object { Get-Module -Name $_ -ListAvailable }).Count -gt 1) {
        Write-Warning 'Multiple variants of AWS Tools for PowerShell (AWSPowerShell, AWSPowerShell.NetCore or AWS.Tools) are currently installed. Please run ''Get-Module -Name AWSPowerShell,AWSPowerShell.NetCore,AWS.Tools.Common -ListAvailable'' for details. To avoid problems with cmdlet auto-importing, it is suggested to only install one variant.
AWS.Tools is the new modularized version of AWS Tools for PowerShell, compatible with PowerShell Core 6+ and Windows Powershell 5.1+ (when .NET Framework 4.7.2+ is installed).
AWSPowerShell.NetCore is the monolithic variant that supports all AWS services in a single large module, it is compatible with PowerShell Core 6+ and Windows Powershell 3+ (when .NET Framework 4.7.2+ is installed).
AWSPowerShell is the legacy module for older systems which are either running Windows PowerShell 2 or cannot be updated to .NET Framework 4.7.2 (or newer).'
    }
}

AWSToolsImportGuard