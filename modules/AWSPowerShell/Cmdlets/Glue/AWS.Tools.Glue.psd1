#
# Module manifest for module 'AWS.Tools.Glue'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Glue.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '4c852a13-4bb9-4d9b-891e-10d7c65b8922'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Glue module of AWS Tools for PowerShell lets developers and administrators manage AWS Glue from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Glue.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Glue.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Glue.Completers.psm1',
        'AWS.Tools.Glue.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-GLUEResourceTag', 
        'Edit-GLUEIntegration', 
        'Find-GLUESchemaVersionMetadata', 
        'Find-GLUETable', 
        'Get-GLUEBlueprint', 
        'Get-GLUEBlueprintBatch', 
        'Get-GLUEBlueprintList', 
        'Get-GLUEBlueprintRun', 
        'Get-GLUEBlueprintRunList', 
        'Get-GLUECatalog', 
        'Get-GLUECatalogImportStatus', 
        'Get-GLUECatalogList', 
        'Get-GLUEClassifier', 
        'Get-GLUEClassifierList', 
        'Get-GLUEColumnStatisticsForPartition', 
        'Get-GLUEColumnStatisticsForTable', 
        'Get-GLUEColumnStatisticsTaskList', 
        'Get-GLUEColumnStatisticsTaskRun', 
        'Get-GLUEColumnStatisticsTaskRunList', 
        'Get-GLUEColumnStatisticsTaskSetting', 
        'Get-GLUEConnection', 
        'Get-GLUEConnectionList', 
        'Get-GLUEConnectionType', 
        'Get-GLUEConnectionTypeList', 
        'Get-GLUECrawler', 
        'Get-GLUECrawlerBatch', 
        'Get-GLUECrawlerList', 
        'Get-GLUECrawlerMetricList', 
        'Get-GLUECrawlerNameList', 
        'Get-GLUECrawlList', 
        'Get-GLUECustomEntityType', 
        'Get-GLUECustomEntityTypeList', 
        'Get-GLUEDatabase', 
        'Get-GLUEDatabaseList', 
        'Get-GLUEDataCatalogEncryptionSetting', 
        'Get-GLUEDataflowGraph', 
        'Get-GLUEDataQualityModel', 
        'Get-GLUEDataQualityModelResult', 
        'Get-GLUEDataQualityResult', 
        'Get-GLUEDataQualityResultBatch', 
        'Get-GLUEDataQualityResultList', 
        'Get-GLUEDataQualityRuleRecommendationRun', 
        'Get-GLUEDataQualityRuleRecommendationRunList', 
        'Get-GLUEDataQualityRuleset', 
        'Get-GLUEDataQualityRulesetEvaluationRun', 
        'Get-GLUEDataQualityRulesetEvaluationRunList', 
        'Get-GLUEDataQualityRulesetList', 
        'Get-GLUEDataQualityStatisticAnnotationList', 
        'Get-GLUEDataQualityStatisticList', 
        'Get-GLUEDevEndpoint', 
        'Get-GLUEDevEndpointBatch', 
        'Get-GLUEDevEndpointList', 
        'Get-GLUEDevEndpointNameList', 
        'Get-GLUEEntity', 
        'Get-GLUEEntityList', 
        'Get-GLUEEntityRecord', 
        'Get-GLUEGetCustomEntityType', 
        'Get-GLUEGluePolicyList', 
        'Get-GLUEInboundIntegration', 
        'Get-GLUEIntegration', 
        'Get-GLUEIntegrationResourceProperty', 
        'Get-GLUEIntegrationTableProperty', 
        'Get-GLUEJob', 
        'Get-GLUEJobBatch', 
        'Get-GLUEJobBookmark', 
        'Get-GLUEJobList', 
        'Get-GLUEJobNameList', 
        'Get-GLUEJobRun', 
        'Get-GLUEJobRunList', 
        'Get-GLUEMapping', 
        'Get-GLUEMLTaskRun', 
        'Get-GLUEMLTaskRunList', 
        'Get-GLUEMLTransform', 
        'Get-GLUEMLTransformIdentifier', 
        'Get-GLUEMLTransformList', 
        'Get-GLUEPartition', 
        'Get-GLUEPartitionBatch', 
        'Get-GLUEPartitionIndex', 
        'Get-GLUEPartitionList', 
        'Get-GLUEPlan', 
        'Get-GLUERegistry', 
        'Get-GLUERegistryList', 
        'Get-GLUEResourcePolicy', 
        'Get-GLUESchema', 
        'Get-GLUESchemaByDefinition', 
        'Get-GLUESchemaList', 
        'Get-GLUESchemaVersion', 
        'Get-GLUESchemaVersionList', 
        'Get-GLUESchemaVersionsDiff', 
        'Get-GLUESchemaVersionValidity', 
        'Get-GLUESecurityConfiguration', 
        'Get-GLUESecurityConfigurationList', 
        'Get-GLUESession', 
        'Get-GLUESessionList', 
        'Get-GLUEStatement', 
        'Get-GLUEStatementList', 
        'Get-GLUETable', 
        'Get-GLUETableList', 
        'Get-GLUETableOptimizer', 
        'Get-GLUETableOptimizerBatch', 
        'Get-GLUETableOptimizerRunList', 
        'Get-GLUETableVersion', 
        'Get-GLUETableVersionList', 
        'Get-GLUETag', 
        'Get-GLUETrigger', 
        'Get-GLUETriggerBatch', 
        'Get-GLUETriggerList', 
        'Get-GLUETriggerNameList', 
        'Get-GLUEUnfilteredPartitionMetadata', 
        'Get-GLUEUnfilteredPartitionsMetadata', 
        'Get-GLUEUnfilteredTableMetadata', 
        'Get-GLUEUsageProfile', 
        'Get-GLUEUsageProfileList', 
        'Get-GLUEUserDefinedFunction', 
        'Get-GLUEUserDefinedFunctionList', 
        'Get-GLUEWorkflow', 
        'Get-GLUEWorkflowBatch', 
        'Get-GLUEWorkflowList', 
        'Get-GLUEWorkflowRun', 
        'Get-GLUEWorkflowRunList', 
        'Get-GLUEWorkflowRunProperty', 
        'Import-GLUECatalog', 
        'Invoke-GLUEStatement', 
        'New-GLUEBlueprint', 
        'New-GLUECatalog', 
        'New-GLUEClassifier', 
        'New-GLUEColumnStatisticsTaskSetting', 
        'New-GLUEConnection', 
        'New-GLUECrawler', 
        'New-GLUECustomEntityType', 
        'New-GLUEDatabase', 
        'New-GLUEDataQualityRuleset', 
        'New-GLUEDevEndpoint', 
        'New-GLUEIntegration', 
        'New-GLUEIntegrationResourceProperty', 
        'New-GLUEIntegrationTableProperty', 
        'New-GLUEJob', 
        'New-GLUEMLTransform', 
        'New-GLUEPartition', 
        'New-GLUEPartitionBatch', 
        'New-GLUEPartitionIndex', 
        'New-GLUERegistry', 
        'New-GLUESchema', 
        'New-GLUEScript', 
        'New-GLUESecurityConfiguration', 
        'New-GLUESession', 
        'New-GLUETable', 
        'New-GLUETableOptimizer', 
        'New-GLUETrigger', 
        'New-GLUEUsageProfile', 
        'New-GLUEUserDefinedFunction', 
        'New-GLUEWorkflow', 
        'Register-GLUESchemaVersion', 
        'Remove-GLUEBlueprint', 
        'Remove-GLUECatalog', 
        'Remove-GLUEClassifier', 
        'Remove-GLUEColumnStatisticsForPartition', 
        'Remove-GLUEColumnStatisticsForTable', 
        'Remove-GLUEColumnStatisticsTaskSetting', 
        'Remove-GLUEConnection', 
        'Remove-GLUEConnectionBatch', 
        'Remove-GLUECrawler', 
        'Remove-GLUECustomEntityType', 
        'Remove-GLUEDatabase', 
        'Remove-GLUEDataQualityRuleset', 
        'Remove-GLUEDevEndpoint', 
        'Remove-GLUEIntegration', 
        'Remove-GLUEIntegrationTableProperty', 
        'Remove-GLUEJob', 
        'Remove-GLUEMLTransform', 
        'Remove-GLUEPartition', 
        'Remove-GLUEPartitionBatch', 
        'Remove-GLUEPartitionIndex', 
        'Remove-GLUERegistry', 
        'Remove-GLUEResourcePolicy', 
        'Remove-GLUEResourceTag', 
        'Remove-GLUESchema', 
        'Remove-GLUESchemaVersion', 
        'Remove-GLUESchemaVersionMetadata', 
        'Remove-GLUESecurityConfiguration', 
        'Remove-GLUESession', 
        'Remove-GLUETable', 
        'Remove-GLUETableBatch', 
        'Remove-GLUETableOptimizer', 
        'Remove-GLUETableVersion', 
        'Remove-GLUETableVersionBatch', 
        'Remove-GLUETrigger', 
        'Remove-GLUEUsageProfile', 
        'Remove-GLUEUserDefinedFunction', 
        'Remove-GLUEWorkflow', 
        'Reset-GLUEJobBookmark', 
        'Resume-GLUEWorkflowRun', 
        'Set-GLUEBatchDataQualityStatisticAnnotation', 
        'Set-GLUEDataCatalogEncryptionSetting', 
        'Set-GLUEResourcePolicy', 
        'Start-GLUEBlueprintRun', 
        'Start-GLUEColumnStatisticsTaskRun', 
        'Start-GLUEColumnStatisticsTaskRunSchedule', 
        'Start-GLUECrawler', 
        'Start-GLUECrawlerSchedule', 
        'Start-GLUEDataQualityRuleRecommendationRun', 
        'Start-GLUEDataQualityRulesetEvaluationRun', 
        'Start-GLUEExportLabelsTaskRun', 
        'Start-GLUEImportLabelsTaskRun', 
        'Start-GLUEJobRun', 
        'Start-GLUEMLEvaluationTaskRun', 
        'Start-GLUEMLLabelingSetGenerationTaskRun', 
        'Start-GLUETrigger', 
        'Start-GLUEWorkflowRun', 
        'Stop-GLUEColumnStatisticsTaskRun', 
        'Stop-GLUEColumnStatisticsTaskRunSchedule', 
        'Stop-GLUECrawler', 
        'Stop-GLUECrawlerSchedule', 
        'Stop-GLUEDataQualityRuleRecommendationRun', 
        'Stop-GLUEDataQualityRulesetEvaluationRun', 
        'Stop-GLUEJobRunBatch', 
        'Stop-GLUEMLTaskRun', 
        'Stop-GLUESession', 
        'Stop-GLUEStatement', 
        'Stop-GLUETrigger', 
        'Stop-GLUEWorkflowRun', 
        'Test-GLUEConnection', 
        'Update-GLUEBlueprint', 
        'Update-GLUECatalog', 
        'Update-GLUEClassifier', 
        'Update-GLUEColumnStatisticsForPartition', 
        'Update-GLUEColumnStatisticsForTable', 
        'Update-GLUEColumnStatisticsTaskSetting', 
        'Update-GLUEConnection', 
        'Update-GLUECrawler', 
        'Update-GLUECrawlerSchedule', 
        'Update-GLUEDatabase', 
        'Update-GLUEDataQualityRuleset', 
        'Update-GLUEDevEndpoint', 
        'Update-GLUEIntegrationResourceProperty', 
        'Update-GLUEIntegrationTableProperty', 
        'Update-GLUEJob', 
        'Update-GLUEJobFromSourceControl', 
        'Update-GLUEMLTransform', 
        'Update-GLUEPartition', 
        'Update-GLUEPartitionBatch', 
        'Update-GLUERegistry', 
        'Update-GLUESchema', 
        'Update-GLUESourceControlFromJob', 
        'Update-GLUETable', 
        'Update-GLUETableOptimizer', 
        'Update-GLUETrigger', 
        'Update-GLUEUsageProfile', 
        'Update-GLUEUserDefinedFunction', 
        'Update-GLUEWorkflow', 
        'Write-GLUEDataQualityProfileAnnotation', 
        'Write-GLUESchemaVersionMetadata', 
        'Write-GLUEWorkflowRunProperty')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-GLUECrawlerMetricsList')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Glue.dll-Help.xml'
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
