#
# Module manifest for module 'AWS.Tools.SageMaker'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.SageMaker.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '2c5c1112-6b0f-437e-b18c-2da050c9f8c9'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The SageMaker module of AWS Tools for PowerShell lets developers and administrators manage Amazon SageMaker Service from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.SageMaker.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.SageMaker.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.SageMaker.Completers.psm1',
        'AWS.Tools.SageMaker.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SMAssociation', 
        'Add-SMResourceTag', 
        'Disable-SMSagemakerServicecatalogPortfolio', 
        'Enable-SMSagemakerServicecatalogPortfolio', 
        'Find-SMLineage', 
        'Get-SMAction', 
        'Get-SMActionList', 
        'Get-SMAlgorithm', 
        'Get-SMAlgorithmList', 
        'Get-SMAliasList', 
        'Get-SMApp', 
        'Get-SMAppImageConfig', 
        'Get-SMAppImageConfigList', 
        'Get-SMAppList', 
        'Get-SMArtifact', 
        'Get-SMArtifactList', 
        'Get-SMAssociationList', 
        'Get-SMAutoMLJob', 
        'Get-SMAutoMLJobList', 
        'Get-SMAutoMLJobV2', 
        'Get-SMCandidatesForAutoMLJobList', 
        'Get-SMCluster', 
        'Get-SMClusterList', 
        'Get-SMClusterNode', 
        'Get-SMClusterNodeList', 
        'Get-SMClusterSchedulerConfig', 
        'Get-SMClusterSchedulerConfigList', 
        'Get-SMCodeRepository', 
        'Get-SMCodeRepositoryList', 
        'Get-SMCompilationJob', 
        'Get-SMCompilationJobList', 
        'Get-SMComputeQuota', 
        'Get-SMComputeQuotaList', 
        'Get-SMConfigList', 
        'Get-SMContext', 
        'Get-SMContextList', 
        'Get-SMDataQualityJobDefinition', 
        'Get-SMDataQualityJobDefinitionList', 
        'Get-SMDescribeModelPackage', 
        'Get-SMDevice', 
        'Get-SMDeviceFleet', 
        'Get-SMDeviceFleetList', 
        'Get-SMDeviceFleetReport', 
        'Get-SMDeviceList', 
        'Get-SMDomain', 
        'Get-SMDomainList', 
        'Get-SMEdgeDeploymentPlan', 
        'Get-SMEdgeDeploymentPlanList', 
        'Get-SMEdgePackagingJob', 
        'Get-SMEdgePackagingJobList', 
        'Get-SMEndpoint', 
        'Get-SMEndpointConfig', 
        'Get-SMEndpointList', 
        'Get-SMExperiment', 
        'Get-SMExperimentList', 
        'Get-SMFeatureGroup', 
        'Get-SMFeatureGroupList', 
        'Get-SMFeatureMetadata', 
        'Get-SMFlowDefinition', 
        'Get-SMFlowDefinitionList', 
        'Get-SMHub', 
        'Get-SMHubContent', 
        'Get-SMHubContentList', 
        'Get-SMHubContentVersionList', 
        'Get-SMHubList', 
        'Get-SMHumanTaskUi', 
        'Get-SMHumanTaskUiList', 
        'Get-SMHyperParameterTuningJob', 
        'Get-SMHyperParameterTuningJobList', 
        'Get-SMImage', 
        'Get-SMImageList', 
        'Get-SMImageVersion', 
        'Get-SMImageVersionList', 
        'Get-SMInferenceComponent', 
        'Get-SMInferenceComponentList', 
        'Get-SMInferenceExperiment', 
        'Get-SMInferenceExperimentList', 
        'Get-SMInferenceRecommendationsJob', 
        'Get-SMInferenceRecommendationsJobList', 
        'Get-SMInferenceRecommendationsJobStepList', 
        'Get-SMLabelingJob', 
        'Get-SMLabelingJobList', 
        'Get-SMLabelingJobListForWorkteam', 
        'Get-SMLineageGroup', 
        'Get-SMLineageGroupList', 
        'Get-SMLineageGroupPolicy', 
        'Get-SMMlflowTrackingServer', 
        'Get-SMMlflowTrackingServerList', 
        'Get-SMModel', 
        'Get-SMModelBiasJobDefinition', 
        'Get-SMModelBiasJobDefinitionList', 
        'Get-SMModelCard', 
        'Get-SMModelCardExportJob', 
        'Get-SMModelCardExportJobList', 
        'Get-SMModelCardList', 
        'Get-SMModelCardVersionList', 
        'Get-SMModelExplainabilityJobDefinition', 
        'Get-SMModelExplainabilityJobDefinitionList', 
        'Get-SMModelList', 
        'Get-SMModelMetadataList', 
        'Get-SMModelPackage', 
        'Get-SMModelPackageGroup', 
        'Get-SMModelPackageGroupList', 
        'Get-SMModelPackageGroupPolicy', 
        'Get-SMModelPackageList', 
        'Get-SMModelQualityJobDefinition', 
        'Get-SMModelQualityJobDefinitionList', 
        'Get-SMMonitoringAlertHistoryList', 
        'Get-SMMonitoringAlertList', 
        'Get-SMMonitoringExecutionList', 
        'Get-SMMonitoringSchedule', 
        'Get-SMMonitoringScheduleList', 
        'Get-SMNotebookInstance', 
        'Get-SMNotebookInstanceLifecycleConfig', 
        'Get-SMNotebookInstanceLifecycleConfigList', 
        'Get-SMNotebookInstanceList', 
        'Get-SMOptimizationJob', 
        'Get-SMOptimizationJobList', 
        'Get-SMPartnerApp', 
        'Get-SMPartnerAppList', 
        'Get-SMPipeline', 
        'Get-SMPipelineDefinitionForExecution', 
        'Get-SMPipelineExecution', 
        'Get-SMPipelineExecutionList', 
        'Get-SMPipelineExecutionStepList', 
        'Get-SMPipelineList', 
        'Get-SMPipelineParametersForExecutionList', 
        'Get-SMProcessingJob', 
        'Get-SMProcessingJobList', 
        'Get-SMProject', 
        'Get-SMProjectList', 
        'Get-SMResourceCatalogList', 
        'Get-SMResourceTagList', 
        'Get-SMSagemakerServicecatalogPortfolioStatus', 
        'Get-SMScalingConfigurationRecommendation', 
        'Get-SMSearchSuggestion', 
        'Get-SMSpace', 
        'Get-SMSpaceList', 
        'Get-SMStageDeviceList', 
        'Get-SMStudioLifecycleConfig', 
        'Get-SMStudioLifecycleConfigList', 
        'Get-SMSubscribedWorkteam', 
        'Get-SMSubscribedWorkteamList', 
        'Get-SMTrainingJob', 
        'Get-SMTrainingJobList', 
        'Get-SMTrainingJobsForHyperParameterTuningJobList', 
        'Get-SMTrainingPlan', 
        'Get-SMTrainingPlanList', 
        'Get-SMTransformJob', 
        'Get-SMTransformJobList', 
        'Get-SMTrial', 
        'Get-SMTrialComponent', 
        'Get-SMTrialComponentList', 
        'Get-SMTrialList', 
        'Get-SMUserProfile', 
        'Get-SMUserProfileList', 
        'Get-SMWorkforce', 
        'Get-SMWorkforceList', 
        'Get-SMWorkteam', 
        'Get-SMWorkteamList', 
        'Import-SMHubContent', 
        'Invoke-SMUiTemplateRendering', 
        'New-SMAction', 
        'New-SMAlgorithm', 
        'New-SMApp', 
        'New-SMAppImageConfig', 
        'New-SMArtifact', 
        'New-SMAutoMLJob', 
        'New-SMAutoMLJobV2', 
        'New-SMCluster', 
        'New-SMClusterSchedulerConfig', 
        'New-SMCodeRepository', 
        'New-SMCompilationJob', 
        'New-SMComputeQuota', 
        'New-SMContext', 
        'New-SMDataQualityJobDefinition', 
        'New-SMDeviceFleet', 
        'New-SMDomain', 
        'New-SMEdgeDeploymentPlan', 
        'New-SMEdgeDeploymentStage', 
        'New-SMEdgePackagingJob', 
        'New-SMEndpoint', 
        'New-SMEndpointConfig', 
        'New-SMExperiment', 
        'New-SMFeatureGroup', 
        'New-SMFlowDefinition', 
        'New-SMHub', 
        'New-SMHubContentReference', 
        'New-SMHumanTaskUi', 
        'New-SMHyperParameterTuningJob', 
        'New-SMImage', 
        'New-SMImageVersion', 
        'New-SMInferenceComponent', 
        'New-SMInferenceExperiment', 
        'New-SMInferenceRecommendationsJob', 
        'New-SMLabelingJob', 
        'New-SMMlflowTrackingServer', 
        'New-SMModel', 
        'New-SMModelBiasJobDefinition', 
        'New-SMModelCard', 
        'New-SMModelCardExportJob', 
        'New-SMModelExplainabilityJobDefinition', 
        'New-SMModelPackage', 
        'New-SMModelPackageGroup', 
        'New-SMModelQualityJobDefinition', 
        'New-SMMonitoringSchedule', 
        'New-SMNotebookInstance', 
        'New-SMNotebookInstanceLifecycleConfig', 
        'New-SMOptimizationJob', 
        'New-SMPartnerApp', 
        'New-SMPartnerAppPresignedUrl', 
        'New-SMPipeline', 
        'New-SMPresignedDomainUrl', 
        'New-SMPresignedMlflowTrackingServerUrl', 
        'New-SMPresignedNotebookInstanceUrl', 
        'New-SMProcessingJob', 
        'New-SMProject', 
        'New-SMSpace', 
        'New-SMStudioLifecycleConfig', 
        'New-SMTrainingJob', 
        'New-SMTrainingPlan', 
        'New-SMTransformJob', 
        'New-SMTrial', 
        'New-SMTrialComponent', 
        'New-SMUserProfile', 
        'New-SMWorkforce', 
        'New-SMWorkteam', 
        'Register-SMDevice', 
        'Register-SMTrialComponent', 
        'Remove-SMAction', 
        'Remove-SMAlgorithm', 
        'Remove-SMApp', 
        'Remove-SMAppImageConfig', 
        'Remove-SMArtifact', 
        'Remove-SMAssociation', 
        'Remove-SMCluster', 
        'Remove-SMClusterSchedulerConfig', 
        'Remove-SMCodeRepository', 
        'Remove-SMCompilationJob', 
        'Remove-SMComputeQuota', 
        'Remove-SMContext', 
        'Remove-SMDataQualityJobDefinition', 
        'Remove-SMDevice', 
        'Remove-SMDeviceFleet', 
        'Remove-SMDomain', 
        'Remove-SMEdgeDeploymentPlan', 
        'Remove-SMEdgeDeploymentStage', 
        'Remove-SMEndpoint', 
        'Remove-SMEndpointConfig', 
        'Remove-SMExperiment', 
        'Remove-SMFeatureGroup', 
        'Remove-SMFlowDefinition', 
        'Remove-SMHub', 
        'Remove-SMHubContent', 
        'Remove-SMHubContentReference', 
        'Remove-SMHumanTaskUi', 
        'Remove-SMHyperParameterTuningJob', 
        'Remove-SMImage', 
        'Remove-SMImageVersion', 
        'Remove-SMInferenceComponent', 
        'Remove-SMInferenceExperiment', 
        'Remove-SMMlflowTrackingServer', 
        'Remove-SMModel', 
        'Remove-SMModelBiasJobDefinition', 
        'Remove-SMModelCard', 
        'Remove-SMModelExplainabilityJobDefinition', 
        'Remove-SMModelPackage', 
        'Remove-SMModelPackageGroup', 
        'Remove-SMModelPackageGroupPolicy', 
        'Remove-SMModelQualityJobDefinition', 
        'Remove-SMMonitoringSchedule', 
        'Remove-SMNotebookInstance', 
        'Remove-SMNotebookInstanceLifecycleConfig', 
        'Remove-SMOptimizationJob', 
        'Remove-SMPartnerApp', 
        'Remove-SMPipeline', 
        'Remove-SMProject', 
        'Remove-SMResourceTag', 
        'Remove-SMSpace', 
        'Remove-SMStudioLifecycleConfig', 
        'Remove-SMTrial', 
        'Remove-SMTrialComponent', 
        'Remove-SMUserProfile', 
        'Remove-SMWorkforce', 
        'Remove-SMWorkteam', 
        'Restart-SMPipelineExecution', 
        'Search-SMResource', 
        'Search-SMTrainingPlanOffering', 
        'Send-SMPipelineExecutionStepFailure', 
        'Send-SMPipelineExecutionStepSuccess', 
        'Set-SMDeleteClusterNode', 
        'Start-SMEdgeDeploymentStage', 
        'Start-SMInferenceExperiment', 
        'Start-SMMlflowTrackingServer', 
        'Start-SMMonitoringSchedule', 
        'Start-SMNotebookInstance', 
        'Start-SMPipelineExecution', 
        'Stop-SMAutoMLJob', 
        'Stop-SMCompilationJob', 
        'Stop-SMEdgeDeploymentStage', 
        'Stop-SMEdgePackagingJob', 
        'Stop-SMHyperParameterTuningJob', 
        'Stop-SMInferenceExperiment', 
        'Stop-SMInferenceRecommendationsJob', 
        'Stop-SMLabelingJob', 
        'Stop-SMMlflowTrackingServer', 
        'Stop-SMMonitoringSchedule', 
        'Stop-SMNotebookInstance', 
        'Stop-SMOptimizationJob', 
        'Stop-SMPipelineExecution', 
        'Stop-SMProcessingJob', 
        'Stop-SMTrainingJob', 
        'Stop-SMTransformJob', 
        'Unregister-SMTrialComponent', 
        'Update-SMAction', 
        'Update-SMAppImageConfig', 
        'Update-SMArtifact', 
        'Update-SMCluster', 
        'Update-SMClusterSchedulerConfig', 
        'Update-SMClusterSoftware', 
        'Update-SMCodeRepository', 
        'Update-SMComputeQuota', 
        'Update-SMContext', 
        'Update-SMDevice', 
        'Update-SMDeviceFleet', 
        'Update-SMDomain', 
        'Update-SMEndpoint', 
        'Update-SMEndpointWeightAndCapacity', 
        'Update-SMExperiment', 
        'Update-SMFeatureGroup', 
        'Update-SMFeatureMetadata', 
        'Update-SMHub', 
        'Update-SMHubContent', 
        'Update-SMHubContentReference', 
        'Update-SMImage', 
        'Update-SMImageVersion', 
        'Update-SMInferenceComponent', 
        'Update-SMInferenceComponentRuntimeConfig', 
        'Update-SMInferenceExperiment', 
        'Update-SMMlflowTrackingServer', 
        'Update-SMModelCard', 
        'Update-SMModelPackage', 
        'Update-SMMonitoringAlert', 
        'Update-SMMonitoringSchedule', 
        'Update-SMNotebookInstance', 
        'Update-SMNotebookInstanceLifecycleConfig', 
        'Update-SMPartnerApp', 
        'Update-SMPipeline', 
        'Update-SMPipelineExecution', 
        'Update-SMProject', 
        'Update-SMSpace', 
        'Update-SMTrainingJob', 
        'Update-SMTrial', 
        'Update-SMTrialComponent', 
        'Update-SMUserProfile', 
        'Update-SMWorkforce', 
        'Update-SMWorkteam', 
        'Write-SMModelPackageGroupPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.SageMaker.dll-Help.xml'
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
