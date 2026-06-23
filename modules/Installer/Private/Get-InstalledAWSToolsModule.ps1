<#
.Synopsis
    Gets installed AWS Tools for PowerShell modules (V2 fast path).

.Description
    Walks $env:PSModulePath in C# via [Amazon.PowerShell.Installer.InstalledModules]::Get,
    reading only the manifest fields V2 callers consume. Does not construct full
    PSModuleInfo objects and does not run signature checks. V1 cmdlets continue to
    use Get-AWSToolsModule (the original Get-Module-based helper).

    Returns PSCustomObjects with: Name, Version (System.Version), ModuleBase, Path,
    PrivateData.PSData.Prerelease.

.Parameter Path
    Specific path to search for AWS Tools modules. When specified, only that path
    is scanned (PSModulePath is ignored for this call).

.Parameter Name
    Specifies which module type to retrieve. Valid values are 'AWS.Tools' (default,
    excludes AWS.Tools.Installer) or 'AWS.Tools.Installer' (only the installer module).
#>
function Get-InstalledAWSToolsModule {
    Param(
        [Parameter()]
        [String]
        $Path,

        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [String]
        $Name = 'AWS.Tools'
    )

    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - Path=$Path Name=$Name"
    }

    Process {
        if ($Path) {
            $searchPath = $Path
        }
        else {
            $searchPath = $env:PSModulePath
        }

        # Always pattern-match AWS.Tools.* (filter to specific Name afterward).
        $rawModules = [Amazon.PowerShell.Installer.InstalledModules]::Get($searchPath, 'AWS.Tools.*')

        # Convert to PSCustomObjects with the property shape the callers expect.
        $shaped = foreach ($m in $rawModules) {
            $verObj = $null
            $null = [System.Version]::TryParse($m.Version, [ref]$verObj)
            if (-not $verObj) {
                # Skip entries we can't parse — matches Get-Module's filter behavior.
                continue
            }

            $psdataObj = [PSCustomObject]@{
                Prerelease = $null
            }
            # If FullVersionString contains a -, the suffix is the prerelease tag.
            $dashIdx = $m.FullVersionString.IndexOf('-')
            if ($dashIdx -ge 0) {
                $psdataObj.Prerelease = $m.FullVersionString.Substring($dashIdx + 1)
            }
            $privateDataObj = [PSCustomObject]@{
                PSData = $psdataObj
            }

            [PSCustomObject]@{
                Name        = $m.Name
                Version     = $verObj
                ModuleBase  = $m.ModuleBase
                Path        = $m.Path
                PrivateData = $privateDataObj
            }
        }

        if ($shaped) {
            if ($Name -eq 'AWS.Tools') {
                $shaped = $shaped | Where-Object { $_.Name -ne 'AWS.Tools.Installer' }
            }
            elseif ($Name -eq 'AWS.Tools.Installer') {
                $shaped = $shaped | Where-Object { $_.Name -eq 'AWS.Tools.Installer' }
            }
        }

        # When -Path is provided, ensure ModuleBase is actually under that path.
        if ($Path -and $shaped) {
            $normalizedPath = [System.IO.Path]::GetFullPath($Path).TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
            $shaped = $shaped | Where-Object {
                $moduleBasePath = [System.IO.Path]::GetFullPath($_.ModuleBase)
                $moduleBasePath.StartsWith($normalizedPath, [System.StringComparison]::OrdinalIgnoreCase)
            }
        }

        $shaped
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
