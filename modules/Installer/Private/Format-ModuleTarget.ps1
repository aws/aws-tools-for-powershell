<#
.Synopsis
    Creates consistent target descriptions for ShouldProcess.

.Description
    This function formats a consistent target description string for use with ShouldProcess
    based on the module type and version information. It handles both regular AWS.Tools modules
    and legacy AWSPowerShell modules with appropriate formatting.

.Parameter Modules
    Array of PSModuleInfo objects to include in the target description.

.Parameter TargetPath
    The path where the modules are located, included in the target description.

.Parameter ModuleType
    The type of modules being processed (e.g., "AWS.Tools", "AWS.Tools.Installer", "Legacy AWSPowerShell").
    Default is "AWS.Tools".

.Example
    Format-ModuleTarget -Modules $modules -TargetPath "C:\Program Files\PowerShell\Modules" -ModuleType "AWS.Tools"

    Returns a formatted target description for regular AWS.Tools modules.

.Example
    Format-ModuleTarget -Modules $legacyModules -TargetPath $userModulePath -ModuleType "Legacy AWSPowerShell"

    Returns a formatted target description for legacy AWSPowerShell modules.

.Notes
    This function is used internally by Uninstall-AWSToolsModule to provide consistent
    target descriptions for ShouldProcess operations across different module types.
#>
function Format-ModuleTarget {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [PSModuleInfo[]]$Modules,
        
        [Parameter(Mandatory)]
        [string]$TargetPath,
        
        [Parameter()]
        [string]$ModuleType = "AWS.Tools"
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - ModuleCount=$(@($Modules).Count) " +
            "TargetPath=$TargetPath ModuleType=$ModuleType")
    }
    
    Process {
        $moduleCount = @($Modules).Count
        
        if ($ModuleType -eq "Legacy AWSPowerShell") {
            # For legacy modules, include module names and versions in the description
            $legacyNames = $Modules | ForEach-Object { 
                $version = if ($_.Version) { $_.Version } else { "Unknown" }
                "$($_.Name) $version" 
            }
            $target = "$moduleCount $ModuleType modules ($($legacyNames -join ', ')) from $TargetPath"
        } else {
            # For AWS.Tools modules, group by version
            $modulesByVersion = $Modules | Group-Object { 
                if ($_.Version) { $_.Version.ToString() } else { "Unknown" }
            }
            $versionList = $modulesByVersion.Name -join ', '
            $target = "$moduleCount $ModuleType modules (versions: $versionList) from $TargetPath"
        }
        
        Write-Verbose ("[$($MyInvocation.MyCommand)] Formatted target description: $target")
        return $target
    }
    
    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
