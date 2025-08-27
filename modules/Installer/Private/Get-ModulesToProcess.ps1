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

.Example
    Get-ModulesToProcess -TargetPath "C:\Program Files\PowerShell\Modules"

    Returns all AWS.Tools modules found in the specified path.

.Example
    Get-ModulesToProcess -TargetPath $userModulePath -Name "EC2","S3" -Version "4.1.0.0"

    Returns only the EC2 and S3 modules with version 4.1.0.0.

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
        [Version]$Version,
        
        [Parameter()]
        [Version]$ExceptVersion
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - TargetPath=$TargetPath " +
            "Name=($($Name -join ',')) Version=$Version ExceptVersion=$ExceptVersion")
    }
    
    Process {
        # Get modules from target path - use AWS.Tools to exclude AWS.Tools.Installer
        $allModules = if ($TargetPath) {
            Get-AWSToolsModule -Path $TargetPath -SkipIfInvalidSignature -Name 'AWS.Tools'
        } else {
            Get-AWSToolsModule -SkipIfInvalidSignature -Name 'AWS.Tools'
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
                if ($moduleName -notlike "AWS.Tools.*") {
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
            $installedModules = $installedModules | 
                Where-Object { (Get-CleanVersion $_.Version) -eq $Version }
        }
        
        # Filter by except version if specified
        if ($ExceptVersion -and $installedModules) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Filtering by except version: $ExceptVersion"
            $installedModules = $installedModules | 
                Where-Object { (Get-CleanVersion $_.Version) -ne $ExceptVersion }
        }

        # Separate AWS.Tools.Installer from regular modules
        $installerModules = $installedModules | Where-Object { $_.Name -eq "AWS.Tools.Installer" }
        $regularModules = $installedModules | Where-Object { $_.Name -ne "AWS.Tools.Installer" }
        
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
