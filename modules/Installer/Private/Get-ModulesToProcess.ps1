<#
.Synopsis
    Retrieves and filters AWS.Tools modules based on specified criteria.

.Description
    This function discovers AWS.Tools modules in the target path and applies filtering based on
    module name, version, and other criteria. AWS.Tools.Installer is excluded from regular processing
    as it is handled by separate cmdlets.

.Parameter TargetPath
    The path where modules should be discovered.

.Parameter Name
    Optional array of module names to filter by. Names without the "AWS.Tools." prefix will be normalized.

.Parameter Version
    Optional specific version to filter by. Only modules with this exact version will be returned.

.Parameter ExceptVersion
    Optional version to exclude. All modules except those with this version will be returned.

.Parameter ExceptModules
    Optional array of hashtables specifying modules to exclude. Each hashtable must contain
    'Name' and 'Version' keys. Modules matching both name and version will be excluded.

.Example
    Get-ModulesToProcess -TargetPath "C:\Program Files\PowerShell\Modules"

    Returns all AWS.Tools modules found in the specified path.

.Example
    Get-ModulesToProcess -TargetPath $userModulePath -Name "EC2","S3" -Version "4.1.0.0"

    Returns only the EC2 and S3 modules with version 4.1.0.0.

.Example
    Get-ModulesToProcess -TargetPath $userModulePath -ExceptModules @(
        @{ Name = 'AWS.Tools.Common'; Version = '5.0.8' }
        @{ Name = 'AWS.Tools.S3'; Version = '5.0.8' }
    )

    Returns all AWS.Tools modules except Common 5.0.8 and S3 5.0.8.

.Notes
    This function is used internally by Uninstall-AWSToolsModule to standardize module discovery
    and filtering across different module types.
#>
function Get-ModulesToProcess {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$TargetPath,
        
        [Parameter()]
        [string[]]$Name,
        
        [Parameter()]
        [string]$Version,
        
        [Parameter()]
        [string]$ExceptVersion,
        
        [Parameter()]
        [hashtable[]]$ExceptModules
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - TargetPath=$TargetPath " +
            "Name=($($Name -join ',')) Version=$Version ExceptVersion=$ExceptVersion " +
            "ExceptModules=$($ExceptModules.Count)")
    }
    
    Process {
        # Get modules from target path - use AWS.Tools to exclude AWS.Tools.Installer
        $allModules = if ($TargetPath) {
            Get-InstalledAWSToolsModule -Path $TargetPath -Name 'AWS.Tools'
        } else {
            Get-InstalledAWSToolsModule -Name 'AWS.Tools'
        }
        
        # Filter modules by path
        $installedModules = $allModules | 
            Where-Object { 
                $_.ModuleBase.StartsWith($TargetPath, [System.StringComparison]::OrdinalIgnoreCase) 
            }

        # Filter by module name if specified
        if ($Name) {
            # Normalize module names (add AWS.Tools. prefix if missing)
            $normalizedNames = @()
            foreach ($moduleName in $Name) {
                if ($moduleName -notlike "AWS.Tools*") {
                    $normalizedNames += "AWS.Tools.$moduleName"
                } else {
                    $normalizedNames += $moduleName
                }
            }
            
            Write-Verbose ("[$($MyInvocation.MyCommand)] Filtering by module names: " +
                "$($normalizedNames -join ', ')")
            
            $installedModules = $installedModules | 
                Where-Object { $normalizedNames -contains $_.Name }
        }

        # Filter by version if specified
        if ($Version -and $installedModules) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Filtering by version: $Version"
            # For semver strings, compare the full version string including prerelease tag
            # For standard versions, use Get-CleanVersion for normalization
            if ($Version -match '^\d+\.\d+\.\d+-.+$') {
                # Semver string - compare full version strings
                $installedModules = $installedModules | 
                    Where-Object { 
                        $moduleVersionString = "$($_.Version.Major).$($_.Version.Minor).$($_.Version.Build)"
                        if ($_.PrivateData.PSData.Prerelease) {
                            $moduleVersionString += "-$($_.PrivateData.PSData.Prerelease)"
                        }
                        $moduleVersionString -eq $Version
                    }
            }
            else {
                # Standard version - use Get-CleanVersion
                $versionObj = Get-CleanVersion $Version
                $installedModules = $installedModules | 
                    Where-Object { (Get-CleanVersion $_.Version) -eq $versionObj }
            }
        }
        
        # Filter by except version if specified
        if ($ExceptVersion -and $installedModules) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Filtering by except version: $ExceptVersion"
            # For semver strings, compare the full version string including prerelease tag
            # For standard versions, use Get-CleanVersion for normalization
            if ($ExceptVersion -match '^\d+\.\d+\.\d+-.+$') {
                # Semver string - compare full version strings
                $installedModules = $installedModules | 
                    Where-Object { 
                        $moduleVersionString = "$($_.Version.Major).$($_.Version.Minor).$($_.Version.Build)"
                        if ($_.PrivateData.PSData.Prerelease) {
                            $moduleVersionString += "-$($_.PrivateData.PSData.Prerelease)"
                        }
                        $moduleVersionString -ne $ExceptVersion
                    }
            }
            else {
                # Standard version - use Get-CleanVersion
                $exceptVersionObj = Get-CleanVersion $ExceptVersion
                $installedModules = $installedModules | 
                    Where-Object { (Get-CleanVersion $_.Version) -ne $exceptVersionObj }
            }
        }
        
        # Filter by except modules if specified
        if ($ExceptModules -and $installedModules) {
            Write-Verbose ("[$($MyInvocation.MyCommand)] Filtering by except modules: " +
                "$($ExceptModules.Count) module-version pairs")
            
            # Build a hashtable for fast lookups: Key = "ModuleName|Version", Value = $true
            $exceptLookup = @{}
            foreach ($moduleInfo in $ExceptModules) {
                $moduleName = $moduleInfo.Name
                $moduleVersion = $moduleInfo.Version
                # Use Get-CleanVersion for consistent version normalization
                $normalizedVersion = (Get-CleanVersion $moduleVersion).ToString()
                $lookupKey = "$moduleName|$normalizedVersion"
                $exceptLookup[$lookupKey] = $true
                Write-Verbose ("[$($MyInvocation.MyCommand)] Excluding: $moduleName " +
                    "version $normalizedVersion")
            }
            
            # Filter out modules that match name and version in ExceptModules
            $installedModules = $installedModules | Where-Object {
                $module = $_
                $moduleVersion = (Get-CleanVersion $module.Version).ToString()
                $lookupKey = "$($module.Name)|$moduleVersion"
                
                # Keep module if it's NOT in the except list
                $shouldKeep = -not $exceptLookup.ContainsKey($lookupKey)
                if (-not $shouldKeep) {
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Excluding module: " +
                        "$($module.Name) version $moduleVersion (matched except list)")
                }
                $shouldKeep
            }
        }

        # @(...) keeps a single match as an array; a 5.1 scalar has no .Count.
        $installerModules = @($installedModules | Where-Object { $_.Name -eq "AWS.Tools.Installer" })
        $regularModules = @($installedModules | Where-Object { $_.Name -ne "AWS.Tools.Installer" })
        
        Write-Verbose ("[$($MyInvocation.MyCommand)] Found $($regularModules.Count) regular AWS.Tools modules")
        Write-Verbose ("[$($MyInvocation.MyCommand)] Found $($installerModules.Count) AWS.Tools.Installer modules")
        
        # Return grouped modules (keeping the same structure for backward compatibility)
        return @{
            Regular = $regularModules
            Installer = $installerModules
        }
    }
    
    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
