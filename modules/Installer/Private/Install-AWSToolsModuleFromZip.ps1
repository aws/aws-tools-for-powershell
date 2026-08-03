<#
.Synopsis
    Installs AWS Tools modules from a zip file.

.Description
    Delegates extraction and PSGetModuleInfo.xml generation to the precompiled
    [Amazon.PowerShell.Installer.ModuleInstaller] type (shipped as
    AWS.Tools.Installer.dll, loaded via the manifest's RequiredAssemblies).
    The C# helper extracts directly into TargetPath using synchronous file I/O
    parallelized across modules with Parallel.ForEach.

    Returns a hashtable with three properties:
    - Version: String representing the release version (from AWS.Tools rollup,
      AWS.Tools.Common, or first module).
    - VersionString: Same string as Version (kept for caller compatibility).
    - Modules: Array of hashtables, each containing Name and Version keys for
      each installed module.

.Parameter Name
    Specifies which module type to install. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter ZipPath
    Path to the zip file (AWS.Tools.zip or AWS.Tools.Installer.zip).

.Parameter ModuleNames
    Array of specific module names to install. If null, installs all modules.

.Parameter TargetPath
    Target installation path for modules.
#>
function Install-AWSToolsModuleFromZip {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [string]
        $Name = 'AWS.Tools',

        [Parameter(Mandatory)]
        [string]$ZipPath,

        [Parameter()]
        [string[]]$ModuleNames,

        [Parameter(Mandatory)]
        [string]$TargetPath,

        [Parameter()]
        [System.Threading.CancellationToken]$CancellationToken = [System.Threading.CancellationToken]::None
    )

    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Name=$Name ZipPath=$ZipPath " +
            "ModuleNames=($($ModuleNames -join ',')) TargetPath=$TargetPath")
    }

    Process {
        # AWS.Tools archives require AWS.Tools.Common to be present alongside any
        # specific service module. AWS.Tools.Installer archives ship the installer
        # only — no mandatory companions.
        [string[]]$mandatoryModules = if ($Name -eq 'AWS.Tools' -and $ModuleNames) {
            @('AWS.Tools.Common')
        } else {
            @()
        }

        if (-not (Test-Path $TargetPath)) {
            New-Item -ItemType 'Directory' -Path $TargetPath -Force -ErrorAction Stop | Out-Null
        }

        Write-Verbose "[$($MyInvocation.MyCommand)] Extracting via [Amazon.PowerShell.Installer.ModuleInstaller]"

        try {
            $results = [Amazon.PowerShell.Installer.ModuleInstaller]::ExtractAndInstall(
                $ZipPath, $TargetPath, $ModuleNames, $mandatoryModules, $CancellationToken)
        }
        catch [Amazon.PowerShell.Installer.MissingModulesException] {
            $missing = $_.Exception.MissingModules
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.IO.FileNotFoundException]"Required modules not found in archive: $($missing -join ', ')"),
                    'MandatoryModulesNotFound',
                    [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                    @($missing)
                )
            )
        }

        if (-not $results -or $results.Count -eq 0) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.IO.FileNotFoundException]"None of the specified modules were found in the archive."),
                    'ModulesNotFoundInZip',
                    [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                    $ModuleNames
                )
            )
        }

        if ($ModuleNames) {
            $installedNames = @($results | ForEach-Object { $_.Name })
            foreach ($requested in $ModuleNames) {
                if ($installedNames -notcontains $requested) {
                    Write-Warning "Module '$requested' is not available in this version and was skipped."
                }
            }
        }

        # Build the return value: a hashtable with Version, VersionString, and a
        # Modules array (Name + Version per module). Surface any non-fatal
        # warnings (e.g. PSGetModuleInfo.xml write failures) per module.
        $installedModuleInfo = @{}
        foreach ($r in $results) {
            $installedModuleInfo[$r.Name] = $r.FullVersionString
            Write-Verbose ("[$($MyInvocation.MyCommand)] Installed module $($r.Name) " +
                "version $($r.FullVersionString)")
            if ($r.Warning) {
                Write-Warning $r.Warning
            }
        }

        $modulesArray = @()
        foreach ($moduleName in $installedModuleInfo.Keys) {
            $modulesArray += @{
                Name = $moduleName
                Version = $installedModuleInfo[$moduleName]
            }
        }

        # Representative version: AWS.Tools rollup > AWS.Tools.Common > first module.
        if ($installedModuleInfo.ContainsKey('AWS.Tools')) {
            $representativeVersion = $installedModuleInfo['AWS.Tools']
        }
        elseif ($installedModuleInfo.ContainsKey('AWS.Tools.Common')) {
            $representativeVersion = $installedModuleInfo['AWS.Tools.Common']
        }
        else {
            $representativeVersion = $installedModuleInfo.Values | Select-Object -First 1
        }

        Write-Verbose "[$($MyInvocation.MyCommand)] Representative version: $representativeVersion"

        return @{
            Version = $representativeVersion
            VersionString = $representativeVersion
            Modules = $modulesArray
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
