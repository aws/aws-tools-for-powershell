#
# Module manifest for module 'AWS.Tools.ConfigService'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.ConfigService.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '37355e41-9861-4ed3-ba56-b71575ac6444'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The ConfigService module of AWS Tools for PowerShell lets developers and administrators manage AWS Config from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        @{
            ModuleName = 'AWS.Tools.Common';
            RequiredVersion = '0.0.0.0';
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }
    )

    # Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.ConfigService.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.ConfigService.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.ConfigService.Completers.psm1',
        'AWS.Tools.ConfigService.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-CFGResourceTag', 
        'Add-CFGResourceType', 
        'Get-CFGAggregateComplianceByConfigRuleList', 
        'Get-CFGAggregateComplianceByConformancePack', 
        'Get-CFGAggregateComplianceDetailsByConfigRule', 
        'Get-CFGAggregateConfigRuleComplianceSummary', 
        'Get-CFGAggregateConformancePackComplianceSummary', 
        'Get-CFGAggregateDiscoveredResourceCount', 
        'Get-CFGAggregateDiscoveredResourceList', 
        'Get-CFGAggregateResourceConfig', 
        'Get-CFGAggregateResourceConfigBatch', 
        'Get-CFGAggregationAuthorizationList', 
        'Get-CFGComplianceByConfigRule', 
        'Get-CFGComplianceByResource', 
        'Get-CFGComplianceDetailsByConfigRule', 
        'Get-CFGComplianceDetailsByResource', 
        'Get-CFGComplianceSummaryByConfigRule', 
        'Get-CFGComplianceSummaryByResourceType', 
        'Get-CFGConfigRule', 
        'Get-CFGConfigRuleEvaluationStatus', 
        'Get-CFGConfigurationAggregatorList', 
        'Get-CFGConfigurationAggregatorSourcesStatus', 
        'Get-CFGConfigurationRecorder', 
        'Get-CFGConfigurationRecorderList', 
        'Get-CFGConfigurationRecorderStatus', 
        'Get-CFGConformancePack', 
        'Get-CFGConformancePackCompliance', 
        'Get-CFGConformancePackComplianceDetail', 
        'Get-CFGConformancePackComplianceScoreList', 
        'Get-CFGConformancePackComplianceSummary', 
        'Get-CFGConformancePackStatus', 
        'Get-CFGCustomRulePolicy', 
        'Get-CFGDeliveryChannel', 
        'Get-CFGDeliveryChannelStatus', 
        'Get-CFGDiscoveredResource', 
        'Get-CFGDiscoveredResourceCount', 
        'Get-CFGGetResourceConfigBatch', 
        'Get-CFGOrganizationConfigRule', 
        'Get-CFGOrganizationConfigRuleDetailedStatus', 
        'Get-CFGOrganizationConfigRuleStatus', 
        'Get-CFGOrganizationConformancePack', 
        'Get-CFGOrganizationConformancePackDetailedStatus', 
        'Get-CFGOrganizationConformancePackStatus', 
        'Get-CFGOrganizationCustomRulePolicy', 
        'Get-CFGPendingAggregationRequestList', 
        'Get-CFGRemediationConfiguration', 
        'Get-CFGRemediationException', 
        'Get-CFGRemediationExecutionStatus', 
        'Get-CFGResourceConfigHistory', 
        'Get-CFGResourceEvaluationList', 
        'Get-CFGResourceEvaluationSummary', 
        'Get-CFGResourceTag', 
        'Get-CFGRetentionConfiguration', 
        'Get-CFGStoredQuery', 
        'Get-CFGStoredQueryList', 
        'Remove-CFGAggregationAuthorization', 
        'Remove-CFGConfigRule', 
        'Remove-CFGConfigurationAggregator', 
        'Remove-CFGConfigurationRecorder', 
        'Remove-CFGConformancePack', 
        'Remove-CFGDeliveryChannel', 
        'Remove-CFGEvaluationResult', 
        'Remove-CFGOrganizationConfigRule', 
        'Remove-CFGOrganizationConformancePack', 
        'Remove-CFGPendingAggregationRequest', 
        'Remove-CFGRemediationConfiguration', 
        'Remove-CFGRemediationException', 
        'Remove-CFGResourceConfig', 
        'Remove-CFGResourceTag', 
        'Remove-CFGResourceType', 
        'Remove-CFGRetentionConfiguration', 
        'Remove-CFGServiceLinkedConfigurationRecorder', 
        'Remove-CFGStoredQuery', 
        'Select-CFGAggregateResourceConfig', 
        'Select-CFGResourceConfig', 
        'Start-CFGConfigRulesEvaluation', 
        'Start-CFGConfigurationRecorder', 
        'Start-CFGRemediationExecution', 
        'Start-CFGResourceEvaluation', 
        'Stop-CFGConfigurationRecorder', 
        'Submit-CFGConfigSnapshotDelivery', 
        'Write-CFGAggregationAuthorization', 
        'Write-CFGConfigRule', 
        'Write-CFGConfigurationAggregator', 
        'Write-CFGConfigurationRecorder', 
        'Write-CFGConformancePack', 
        'Write-CFGDeliveryChannel', 
        'Write-CFGEvaluation', 
        'Write-CFGExternalEvaluation', 
        'Write-CFGOrganizationConfigRule', 
        'Write-CFGOrganizationConformancePack', 
        'Write-CFGRemediationConfiguration', 
        'Write-CFGRemediationException', 
        'Write-CFGResourceConfig', 
        'Write-CFGRetentionConfiguration', 
        'Write-CFGServiceLinkedConfigurationRecorder', 
        'Write-CFGStoredQuery')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-CFGConfigRules', 
        'Get-CFGConfigurationRecorders', 
        'Get-CFGDeliveryChannels', 
        'Write-CFGEvaluations')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.ConfigService.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md'
        }
    }
}
