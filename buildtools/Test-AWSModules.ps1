
# function to test module loading locally
# Test-AWSModules -DeploymentFolderPath 'C:/Stuff/WindowsPS/Deployment' -TestCommandProfileName test
function Test-AWSModules {
    [CmdletBinding()]
    param (
        $DeploymentFolderPath,
        $TestCommandProfileName
    ) 
    process {
        $moduleLoadResults = @()
        $osRuntimeModules = @{
            'windows' = @{
                'pwsh'       = 'AWSPowerShell', 'AWSPowerShell.NetCore', @('AWS.Tools.Common', 'AWS.Tools.S3')
                'powershell' = 'AWSPowerShell', @('AWS.Tools.Common', 'AWS.Tools.S3')
            }
            'linux'   = @{
                'pwsh' = 'AWSPowerShell.NetCore', @('AWS.Tools.Common', 'AWS.Tools.S3')
            }
        }
        $command = '$b = Get-S3Bucket -ProfileName "{0}" -Region us-west-2; Write-Host "BucketCount: $($b.Count)"' -f $TestCommandProfileName
        $runtimeModules = $osRuntimeModules['linux']
        if ($IsWindows) {
            $runtimeModules = $osRuntimeModules['windows']
        }
        $runtimes = $runtimeModules.Keys
        foreach ($runtime in $runtimes) {
            $modules = $runtimeModules[$runtime]
            foreach ($module in $modules) {
                $moduleReportName = $module
                $subFolder = ""
                if ($module -like 'AWS.Tools.*') {
                    $subFolder = 'AWS.Tools'
                    $moduleReportName = 'AWS.Tools'
                }
                $importcmd = $module.foreach{ 
                    'Import-Module ' + ([IO.Path]::Combine($DeploymentFolderPath, $subFolder, $_, "$_.psd1")) 
                } -join ';'
                
                $commands = "
                            `$ErrorActionPreference='STOP'
                            try{
                                $importcmd;
                                $command;
                                }
                            catch{
                                return 'psscriptfailed'
                            }"
                
                $psoutput = & $runtime -NoProfile -Command $commands
                $moduleLoadResults += ([PSCustomObject]@{
                        Runtime = $runtime
                        Module  = $moduleReportName
                        Success = ($psoutput -join '') -notmatch 'psscriptfailed'
                    })
            }
        }
        $moduleLoadResults
    }
}
