<#
.Synopsis
    Unlists the specified version of all AWS Tools for PowerShell modules
.Description
    Unlists the specified version of all AWS Tools for PowerShell modules.
    This includes AWSPowerShell, AWSPowerShell.NetCore, and all of the AWS.Tools.* modules.
    This does not include AWS.Tools.Installer.
.Notes
    The script must be run from the project root so that it could resolve the path 
    to the modules folder to loop over all services.

.Example
    .\buildtools\Unpublish-AWSPowerShellVersion.ps1 -Version 4.1.121 -ApiKey "apiKey" -DryRun $false
#>

[CmdletBinding()]
Param (
    # The version of AWS Tools for PowerShell to unlist, e.g. "4.1.121"
    [Parameter(Mandatory = $true)]
    [string]$Version,

    # API Key for PowerShell gallery
    [Parameter(Mandatory = $true)]
    [string] $ApiKey,

    # Set to false to unlist the modules. By default this will only 
    # print the commands that will be run.
    [Parameter()]
    [bool] $DryRun = $true
)

# Helper function that unlists a single module
function Unpublish-AWSPowerShellModule {
    param (
        $Name,
        $Version,
        $ApiKey,
        $DryRun
    )

    $deleteCommand = "dotnet nuget delete $Name $Version -s https://www.powershellgallery.com --api-key $ApiKey --non-interactive"

    if ($DryRun)
    {
        Write-Host $deleteCommand
    }
    else
    {
        Invoke-Expression $deleteCommand
    }
}

# First unlist the service-specific modules
$modules = Get-ChildItem ./modules/AWSPowerShell/Cmdlets
foreach ($module in $modules)
{
    $name = "AWS.Tools." + $module.Name

    # We've never published modular versions of these, see https://github.com/aws/aws-tools-for-powershell/issues/33
    # Despite it being listed in that issue as an exception, it appears we have since published ELB
    if (($name -eq "AWS.Tools.CloudHSM") -or ($name -eq "AWS.Tools.CloudWatchEvents") -or ($name -eq "AWS.Tools.KinesisAnalytics"))
    {
        continue
    }

    Unpublish-AWSPowerShellModule -Name $name -Version $version -ApiKey $apiKey -DryRun $dryRun
}

# Then monoliths and Common
Unpublish-AWSPowerShellModule -Name "AWSPowerShell" -Version $version -ApiKey $apiKey -DryRun $dryRun
Unpublish-AWSPowerShellModule -Name "AWSPowerShell.NetCore" -Version $version -ApiKey $apiKey -DryRun $dryRun
Unpublish-AWSPowerShellModule -Name "AWS.Tools.Common" -Version $version -ApiKey $apiKey -DryRun $dryRun