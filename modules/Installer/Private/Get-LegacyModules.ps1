<#
.Synopsis
    Retrieves legacy AWSPowerShell modules from a specified path.

.Description
    This function discovers legacy AWSPowerShell and AWSPowerShell.NetCore modules
    in the target path for cleanup operations. It filters modules to only include
    those located in the specified path.

.Parameter TargetPath
    The path where legacy modules should be discovered.

.Example
    Get-LegacyModules -TargetPath "C:\Program Files\PowerShell\Modules"

    Returns all legacy AWSPowerShell modules found in the specified path.

.Notes
    This function is used internally by Uninstall-AWSToolsModule to standardize
    legacy module discovery for cleanup operations.
#>
function Get-LegacyModules {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [string]$TargetPath
    )
    
    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - TargetPath=$TargetPath"
    }
    
    Process {
        # Find legacy modules
        $legacyModules = Get-Module -Name 'AWSPowerShell*' -ListAvailable | 
            Where-Object { 
                $_.ModuleBase.StartsWith($TargetPath, [System.StringComparison]::OrdinalIgnoreCase) 
            }
        
        Write-Verbose ("[$($MyInvocation.MyCommand)] Found $(@($legacyModules).Count) legacy " +
            "AWSPowerShell modules in path: $TargetPath")
            
        return $legacyModules
    }
    
    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}