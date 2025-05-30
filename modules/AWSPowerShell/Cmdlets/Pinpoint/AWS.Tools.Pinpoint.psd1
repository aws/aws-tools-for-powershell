#
# Module manifest for module 'AWS.Tools.Pinpoint'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Pinpoint.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'e46abf94-73c9-4ed2-b4d5-4a9df908a970'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Pinpoint module of AWS Tools for PowerShell lets developers and administrators manage Amazon Pinpoint from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Pinpoint.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Pinpoint.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Pinpoint.Completers.psm1',
        'AWS.Tools.Pinpoint.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-PINResourceTag', 
        'Confirm-PINOTPMessage', 
        'Confirm-PINPhoneNumber', 
        'Get-PINAdmChannel', 
        'Get-PINApnsChannel', 
        'Get-PINApnsSandboxChannel', 
        'Get-PINApnsVoipChannel', 
        'Get-PINApnsVoipSandboxChannel', 
        'Get-PINApp', 
        'Get-PINApplicationDateRangeKpi', 
        'Get-PINApplicationSettingList', 
        'Get-PINAppList', 
        'Get-PINBaiduChannel', 
        'Get-PINCampaign', 
        'Get-PINCampaignActivityList', 
        'Get-PINCampaignDateRangeKpi', 
        'Get-PINCampaignList', 
        'Get-PINCampaignVersion', 
        'Get-PINCampaignVersionList', 
        'Get-PINChannel', 
        'Get-PINEmailChannel', 
        'Get-PINEmailTemplate', 
        'Get-PINEndpoint', 
        'Get-PINEventStream', 
        'Get-PINExportJob', 
        'Get-PINExportJobList', 
        'Get-PINGcmChannel', 
        'Get-PINImportJob', 
        'Get-PINImportJobList', 
        'Get-PINInAppMessage', 
        'Get-PINInAppTemplate', 
        'Get-PINJourney', 
        'Get-PINJourneyDateRangeKpi', 
        'Get-PINJourneyExecutionActivityMetric', 
        'Get-PINJourneyExecutionMetric', 
        'Get-PINJourneyList', 
        'Get-PINJourneyRun', 
        'Get-PINJourneyRunExecutionActivityMetric', 
        'Get-PINJourneyRunExecutionMetric', 
        'Get-PINPushTemplate', 
        'Get-PINRecommenderConfiguration', 
        'Get-PINRecommenderConfigurationList', 
        'Get-PINResourceTag', 
        'Get-PINSegment', 
        'Get-PINSegmentExportJobList', 
        'Get-PINSegmentImportJobList', 
        'Get-PINSegmentList', 
        'Get-PINSegmentVersion', 
        'Get-PINSegmentVersionList', 
        'Get-PINSmsChannel', 
        'Get-PINSmsTemplate', 
        'Get-PINTemplateList', 
        'Get-PINTemplateVersionList', 
        'Get-PINUserEndpoint', 
        'Get-PINVoiceChannel', 
        'Get-PINVoiceTemplate', 
        'New-PINApp', 
        'New-PINCampaign', 
        'New-PINEmailTemplate', 
        'New-PINExportJob', 
        'New-PINImportJob', 
        'New-PINInAppTemplate', 
        'New-PINJourney', 
        'New-PINPushTemplate', 
        'New-PINRecommenderConfiguration', 
        'New-PINSegment', 
        'New-PINSmsTemplate', 
        'New-PINVoiceTemplate', 
        'Remove-PINAdmChannel', 
        'Remove-PINApnsChannel', 
        'Remove-PINApnsSandboxChannel', 
        'Remove-PINApnsVoipChannel', 
        'Remove-PINApnsVoipSandboxChannel', 
        'Remove-PINApp', 
        'Remove-PINAttribute', 
        'Remove-PINBaiduChannel', 
        'Remove-PINCampaign', 
        'Remove-PINEmailChannel', 
        'Remove-PINEmailTemplate', 
        'Remove-PINEndpoint', 
        'Remove-PINEventStream', 
        'Remove-PINGcmChannel', 
        'Remove-PINInAppTemplate', 
        'Remove-PINJourney', 
        'Remove-PINPushTemplate', 
        'Remove-PINRecommenderConfiguration', 
        'Remove-PINResourceTag', 
        'Remove-PINSegment', 
        'Remove-PINSmsChannel', 
        'Remove-PINSmsTemplate', 
        'Remove-PINUserEndpoint', 
        'Remove-PINVoiceChannel', 
        'Remove-PINVoiceTemplate', 
        'Send-PINMessage', 
        'Send-PINOTPMessage', 
        'Send-PINUserMessageBatch', 
        'Update-PINAdmChannel', 
        'Update-PINApnsChannel', 
        'Update-PINApnsSandboxChannel', 
        'Update-PINApnsVoipChannel', 
        'Update-PINApnsVoipSandboxChannel', 
        'Update-PINApplicationSettingList', 
        'Update-PINBaiduChannel', 
        'Update-PINCampaign', 
        'Update-PINEmailChannel', 
        'Update-PINEmailTemplate', 
        'Update-PINEndpoint', 
        'Update-PINEndpointsBatch', 
        'Update-PINGcmChannel', 
        'Update-PINInAppTemplate', 
        'Update-PINJourney', 
        'Update-PINJourneyState', 
        'Update-PINPushTemplate', 
        'Update-PINRecommenderConfiguration', 
        'Update-PINSegment', 
        'Update-PINSmsChannel', 
        'Update-PINSmsTemplate', 
        'Update-PINTemplateActiveVersion', 
        'Update-PINVoiceChannel', 
        'Update-PINVoiceTemplate', 
        'Write-PINEvent', 
        'Write-PINEventStream')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Pinpoint.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview005'
        }
    }
}
