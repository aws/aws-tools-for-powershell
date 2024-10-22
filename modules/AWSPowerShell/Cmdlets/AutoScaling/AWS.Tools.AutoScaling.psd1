#
# Module manifest for module 'AWS.Tools.AutoScaling'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.AutoScaling.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'db1bebf4-f2b3-4ad1-a7f5-02a6a7effb87'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The AutoScaling module of AWS Tools for PowerShell lets developers and administrators manage AWS Auto Scaling from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
The module AWS.Tools.Installer (https://www.powershellgallery.com/packages/AWS.Tools.Installer/) makes it easier to install, update and uninstall the AWS.Tools modules.
This version of AWS Tools for PowerShell is compatible with Windows PowerShell 5.1+ and PowerShell Core 6+ on Windows, Linux and macOS. When running on Windows PowerShell, .NET Framework 4.7.2 or newer is required. Alternative modules AWSPowerShell.NetCore and AWSPowerShell, provide support for all AWS services from a single module and also support older versions of Windows PowerShell and .NET Framework.'

    # Minimum version of the PowerShell engine required by this module
    PowerShellVersion = '5.1'

    # Name of the PowerShell host required by this module
    PowerShellHostName = ''

    # Minimum version of the PowerShell host required by this module
    PowerShellHostVersion = ''

    # Minimum version of the .NET Framework required by this module
    DotNetFrameworkVersion = '4.7.2'

    # Minimum version of the common language runtime (CLR) required by this module
    CLRVersion = ''

    # Processor architecture (None, X86, Amd64, IA64) required by this module
    ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    RequiredModules = @(
    )

# Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.AutoScaling.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.AutoScaling.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.AutoScaling.Completers.psm1',
        'AWS.Tools.AutoScaling.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-ASLoadBalancer', 
        'Add-ASLoadBalancerTargetGroup', 
        'Add-ASTrafficSource', 
        'Complete-ASLifecycleAction', 
        'Disable-ASMetricsCollection', 
        'Dismount-ASInstance', 
        'Dismount-ASLoadBalancer', 
        'Dismount-ASLoadBalancerTargetGroup', 
        'Dismount-ASTrafficSource', 
        'Enable-ASMetricsCollection', 
        'Enter-ASStandby', 
        'Exit-ASStandby', 
        'Get-ASAccountLimit', 
        'Get-ASAdjustmentType', 
        'Get-ASAutoScalingGroup', 
        'Get-ASAutoScalingInstance', 
        'Get-ASAutoScalingNotificationType', 
        'Get-ASInstanceRefresh', 
        'Get-ASLaunchConfiguration', 
        'Get-ASLifecycleHook', 
        'Get-ASLifecycleHookType', 
        'Get-ASLoadBalancer', 
        'Get-ASLoadBalancerTargetGroup', 
        'Get-ASMetricCollectionType', 
        'Get-ASNotificationConfiguration', 
        'Get-ASPolicy', 
        'Get-ASPredictiveScalingForecast', 
        'Get-ASScalingActivity', 
        'Get-ASScalingProcessType', 
        'Get-ASScheduledAction', 
        'Get-ASTag', 
        'Get-ASTerminationPolicyType', 
        'Get-ASTrafficSource', 
        'Get-ASWarmPool', 
        'Mount-ASInstance', 
        'New-ASAutoScalingGroup', 
        'New-ASLaunchConfiguration', 
        'Remove-ASAutoScalingGroup', 
        'Remove-ASLaunchConfiguration', 
        'Remove-ASLifecycleHook', 
        'Remove-ASNotificationConfiguration', 
        'Remove-ASPolicy', 
        'Remove-ASScheduledAction', 
        'Remove-ASScheduledActionBatch', 
        'Remove-ASTag', 
        'Remove-ASWarmPool', 
        'Resume-ASProcess', 
        'Set-ASDesiredCapacity', 
        'Set-ASInstanceHealth', 
        'Set-ASInstanceProtection', 
        'Set-ASScheduledUpdateGroupActionBatch', 
        'Set-ASTag', 
        'Start-ASInstanceRefresh', 
        'Start-ASPolicy', 
        'Stop-ASInstanceInAutoScalingGroup', 
        'Stop-ASInstanceRefresh', 
        'Suspend-ASProcess', 
        'Undo-ASInstanceRefresh', 
        'Update-ASAutoScalingGroup', 
        'Write-ASLifecycleActionHeartbeat', 
        'Write-ASLifecycleHook', 
        'Write-ASNotificationConfiguration', 
        'Write-ASScalingPolicy', 
        'Write-ASScheduledUpdateGroupAction', 
        'Write-ASWarmPool')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Add-ASInstances', 
        'Get-ASAccountLimits', 
        'Get-ASLifecycleHooks', 
        'Get-ASLifecycleHookTypes', 
        'Dismount-ASInstances')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.AutoScaling.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview001'
        }
    }
}
