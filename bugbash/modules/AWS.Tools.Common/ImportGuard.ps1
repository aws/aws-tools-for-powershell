param(
    [switch]$SkipInvocation
)

function Get-VersionFromManifest {
    [OutputType([System.Version])]
    param([string]$Path)

    $reader = $null
    try {
        $reader = [System.IO.StreamReader]::new($Path)
        while ($null -ne ($line = $reader.ReadLine())) {
            if ($line -match "ModuleVersion\s*=\s*'([^']+)'") {
                $ver = $null
                if ([System.Version]::TryParse($Matches[1], [ref]$ver)) { return $ver }
            }
        }
    } catch {
        Write-Verbose "Failed to read manifest '$Path': $_"
    }
    finally { if ($reader) { $reader.Dispose() } }
    return $null
}

function Test-MultipleModuleVariantsInstalled {
    [OutputType([bool])]
    param([string[]]$ModuleNames)

    $found = @{}
    foreach ($modulePath in ($env:PSModulePath -split [System.IO.Path]::PathSeparator)) {
        if (-not [System.IO.Directory]::Exists($modulePath)) { continue }
        foreach ($name in $ModuleNames) {
            if (-not $found.ContainsKey($name) -and
                [System.IO.Directory]::Exists([System.IO.Path]::Combine($modulePath, $name))) {
                $found[$name] = $true
                if ($found.Count -gt 1) { return $true }
            }
        }
    }
    return $false
}

function Test-AWSToolsVersionMismatch {
    [OutputType([bool])]
    param()

    $moduleVersions = @{}
    [System.Version]$maxVersion = $null

    foreach ($modulePath in ($env:PSModulePath -split [System.IO.Path]::PathSeparator)) {
        if (-not [System.IO.Directory]::Exists($modulePath)) { continue }

        try {
            $awsDirs = [System.IO.Directory]::GetDirectories($modulePath, 'AWS.Tools.*')
        } catch {
            Write-Verbose "Skipping module path '$modulePath': $_"
            continue
        }

        foreach ($dirPath in $awsDirs) {
            $dirName = [System.IO.Path]::GetFileName($dirPath)
            if ($dirName -eq 'AWS.Tools.Installer') { continue }

            # Flat layout: ModuleName/ModuleName.psd1
            $flatPsd1 = [System.IO.Path]::Combine($dirPath, "$dirName.psd1")
            if ([System.IO.File]::Exists($flatPsd1)) {
                $ver = Get-VersionFromManifest $flatPsd1
                if ($ver) {
                    if (-not $moduleVersions.ContainsKey($dirName)) {
                        $moduleVersions[$dirName] = [System.Collections.Generic.HashSet[System.Version]]::new()
                    }
                    $null = $moduleVersions[$dirName].Add($ver)
                    if ($null -eq $maxVersion -or $ver -gt $maxVersion) { $maxVersion = $ver }
                }
            }

            # Versioned layout: ModuleName/Version/ModuleName.psd1
            try {
                $subDirs = [System.IO.Directory]::GetDirectories($dirPath)
            } catch {
                Write-Verbose "Skipping directory '$dirPath': $_"
                continue
            }

            foreach ($subDirPath in $subDirs) {
                $ver = $null
                if ([System.Version]::TryParse([System.IO.Path]::GetFileName($subDirPath), [ref]$ver)) {
                    $vPsd1 = [System.IO.Path]::Combine($subDirPath, "$dirName.psd1")
                    if ([System.IO.File]::Exists($vPsd1)) {
                        if (-not $moduleVersions.ContainsKey($dirName)) {
                            $moduleVersions[$dirName] = [System.Collections.Generic.HashSet[System.Version]]::new()
                        }
                        $null = $moduleVersions[$dirName].Add($ver)
                        if ($null -eq $maxVersion -or $ver -gt $maxVersion) { $maxVersion = $ver }
                    }
                }
            }
        }
    }

    if ($null -eq $maxVersion) { return $false }

    foreach ($entry in $moduleVersions.GetEnumerator()) {
        if (-not $entry.Value.Contains($maxVersion)) { return $true }
    }
    return $false
}

function AWSToolsImportGuard() {
    Microsoft.PowerShell.Core\Set-StrictMode -Version 3

    [string[]]$rootModules = @( 'AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools.Common' )

    foreach ($rootModule in $rootModules) {
        [string]$version = Microsoft.PowerShell.Core\Get-Module -Name $rootModule | Select-Object -First 1 -ExpandProperty Version
        if ($version) {
            [string]$message = "$rootModule version $version is currently imported. Only a single version of a single variant of AWS Tools for PowerShell (AWSPowerShell, AWSPowerShell.NetCore or AWS.Tools.Common) can be imported at any time."

            [System.Management.Automation.PSModuleInfo[]]$importingModule = Get-Module "$PSScriptRoot/*.psd1" -ListAvailable
            if ($importingModule.Count -eq 1) {
                if ($PSVersionTable.PSVersion.Major -ge 5) {
                    [System.Collections.Hashtable]$importingModuleData = Microsoft.PowerShell.Utility\Import-PowerShellDataFile $importingModule.Path
                    $message = "Module $($importingModule.Name) version $($importingModuleData.ModuleVersion) failed importing. " + $message
                } else {
                    $message = "Module $($importingModule.Name) failed importing. " + $message
                }
            }

            throw $message
        }
    }

    try {
        if (Test-AWSToolsVersionMismatch) {
            if (Get-Module 'AWS.Tools.Installer' -ListAvailable) {
                Write-Warning 'You have mismatched versions of the AWS.Tools modules. You can use Update-AWSToolsModule to synchronize the versions of all installed AWS.Tools modules.'
            } else {
                Write-Warning 'You have mismatched versions of the AWS.Tools modules. You can run ''Install-Module AWS.Tools.Installer ; Update-AWSToolsModule'' to synchronize the versions of all installed AWS.Tools modules.'
            }
        }
    } catch {
        Write-Verbose "ImportGuard version mismatch check failed: $_"
    }

    if (Test-MultipleModuleVariantsInstalled $rootModules) {
        Write-Warning 'Multiple variants of AWS Tools for PowerShell (AWSPowerShell, AWSPowerShell.NetCore or AWS.Tools) are currently installed. Please run ''Get-Module -Name AWSPowerShell,AWSPowerShell.NetCore,AWS.Tools.Common -ListAvailable'' for details. To avoid problems with cmdlet auto-importing, it is suggested to only install one variant.
AWS.Tools is the new modularized version of AWS Tools for PowerShell, compatible with PowerShell Core 6+ and Windows Powershell 5.1+ (when .NET Framework 4.7.2+ is installed).
AWSPowerShell.NetCore is the monolithic variant that supports all AWS services in a single large module, it is compatible with PowerShell Core 6+ and Windows Powershell 3+ (when .NET Framework 4.7.2+ is installed).
AWSPowerShell is the legacy module for older systems which are either running Windows PowerShell 2 or cannot be updated to .NET Framework 4.7.2 (or newer).'
    }
}

if (-not $SkipInvocation) {
    AWSToolsImportGuard
}
