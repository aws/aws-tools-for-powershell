param(
    [switch]$SkipInvocation
)

[string]$script:VersionCheckerSource = @'
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AWSToolsModuleVersionChecker
{
    private static readonly Regex VersionRegex = new Regex(
        @"ModuleVersion\s*=\s*'(?<ver>[^']+)'", RegexOptions.Compiled);

    public static bool HasVersionMismatch()
    {
        var psModulePath = Environment.GetEnvironmentVariable("PSModulePath");
        if (string.IsNullOrEmpty(psModulePath)) return false;

        var moduleVersions = new Dictionary<string, HashSet<Version>>(StringComparer.OrdinalIgnoreCase);
        Version maxVersion = null;

        foreach (var modulePath in psModulePath.Split(Path.PathSeparator))
        {
            if (!Directory.Exists(modulePath)) continue;

            string[] awsDirs;
            try { awsDirs = Directory.GetDirectories(modulePath, "AWS.Tools.*"); }
            catch { continue; }

            foreach (var dir in awsDirs)
            {
                var dirName = Path.GetFileName(dir);
                if (dirName.Equals("AWS.Tools.Installer", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Flat layout: psd1 directly in the module directory
                var flatPsd1 = Path.Combine(dir, dirName + ".psd1");
                if (File.Exists(flatPsd1))
                    AddVersion(moduleVersions, dirName, ReadVersionFromManifest(flatPsd1), ref maxVersion);

                // Versioned layout: subdirectories named with version numbers
                string[] subDirs;
                try { subDirs = Directory.GetDirectories(dir); }
                catch { continue; }

                foreach (var vDir in subDirs)
                {
                    Version ver;
                    if (Version.TryParse(Path.GetFileName(vDir), out ver) &&
                        File.Exists(Path.Combine(vDir, dirName + ".psd1")))
                        AddVersion(moduleVersions, dirName, ver, ref maxVersion);
                }
            }
        }

        if (maxVersion == null) return false;

        foreach (var entry in moduleVersions)
            if (!entry.Value.Contains(maxVersion))
                return true;

        return false;
    }

    private static void AddVersion(Dictionary<string, HashSet<Version>> dict,
        string name, Version ver, ref Version maxVersion)
    {
        if (ver == null) return;
        if (!dict.ContainsKey(name))
            dict[name] = new HashSet<Version>();
        dict[name].Add(ver);
        if (maxVersion == null || ver > maxVersion)
            maxVersion = ver;
    }

    private static Version ReadVersionFromManifest(string path)
    {
        try
        {
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var match = VersionRegex.Match(line);
                    if (match.Success)
                    {
                        Version ver;
                        if (Version.TryParse(match.Groups["ver"].Value, out ver))
                            return ver;
                    }
                }
            }
        }
        catch { }
        return null;
    }
}
'@

if (-not ([System.Management.Automation.PSTypeName]'AWSToolsModuleVersionChecker').Type) {
    $null = Add-Type -TypeDefinition $script:VersionCheckerSource -Language CSharp
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
        if (-not ([System.Management.Automation.PSTypeName]'AWSToolsModuleVersionChecker').Type) {
            $null = Add-Type -TypeDefinition $script:VersionCheckerSource -Language CSharp
        }

        if ([AWSToolsModuleVersionChecker]::HasVersionMismatch()) {
            if (Get-Module 'AWS.Tools.Installer' -ListAvailable) {
                Write-Warning 'You have mismatched versions of the AWS.Tools modules. You can use Update-AWSToolsModule to synchronize the versions of all installed AWS.Tools modules.'
            } else {
                Write-Warning 'You have mismatched versions of the AWS.Tools modules. You can run ''Install-Module AWS.Tools.Installer ; Update-AWSToolsModule'' to synchronize the versions of all installed AWS.Tools modules.'
            }
        }
    } catch {
        Write-Verbose "ImportGuard version mismatch check failed: $_"
    }

    [int]$installedModuleVariants = Microsoft.PowerShell.Core\Get-Module -Name $rootModules -ListAvailable | Group-Object -Property Name -NoElement | Measure-Object | Select-Object -ExpandProperty Count
    if ($installedModuleVariants -gt 1) {
        Write-Warning 'Multiple variants of AWS Tools for PowerShell (AWSPowerShell, AWSPowerShell.NetCore or AWS.Tools) are currently installed. Please run ''Get-Module -Name AWSPowerShell,AWSPowerShell.NetCore,AWS.Tools.Common -ListAvailable'' for details. To avoid problems with cmdlet auto-importing, it is suggested to only install one variant.
AWS.Tools is the new modularized version of AWS Tools for PowerShell, compatible with PowerShell Core 6+ and Windows Powershell 5.1+ (when .NET Framework 4.7.2+ is installed).
AWSPowerShell.NetCore is the monolithic variant that supports all AWS services in a single large module, it is compatible with PowerShell Core 6+ and Windows Powershell 3+ (when .NET Framework 4.7.2+ is installed).
AWSPowerShell is the legacy module for older systems which are either running Windows PowerShell 2 or cannot be updated to .NET Framework 4.7.2 (or newer).'
    }
}

if (-not $SkipInvocation) {
    AWSToolsImportGuard
}
