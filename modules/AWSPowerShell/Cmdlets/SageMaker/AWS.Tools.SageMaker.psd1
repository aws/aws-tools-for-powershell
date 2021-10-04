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
    Copyright = 'Copyright 2012-2021 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

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
        @{
            ModuleName = 'AWS.Tools.Common';
            RequiredVersion = '0.0.0.0';
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }
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
        'Get-SMAction', 
        'Get-SMActionList', 
        'Get-SMAlgorithm', 
        'Get-SMAlgorithmList', 
        'Get-SMApp', 
        'Get-SMAppImageConfig', 
        'Get-SMAppImageConfigList', 
        'Get-SMAppList', 
        'Get-SMArtifact', 
        'Get-SMArtifactList', 
        'Get-SMAssociationList', 
        'Get-SMAutoMLJob', 
        'Get-SMAutoMLJobList', 
        'Get-SMCandidatesForAutoMLJobList', 
        'Get-SMCodeRepository', 
        'Get-SMCodeRepositoryList', 
        'Get-SMCompilationJob', 
        'Get-SMCompilationJobList', 
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
        'Get-SMEdgePackagingJob', 
        'Get-SMEdgePackagingJobList', 
        'Get-SMEndpoint', 
        'Get-SMEndpointConfig', 
        'Get-SMEndpointList', 
        'Get-SMExperiment', 
        'Get-SMExperimentList', 
        'Get-SMFeatureGroup', 
        'Get-SMFeatureGroupList', 
        'Get-SMFlowDefinition', 
        'Get-SMFlowDefinitionList', 
        'Get-SMHumanTaskUi', 
        'Get-SMHumanTaskUiList', 
        'Get-SMHyperParameterTuningJob', 
        'Get-SMHyperParameterTuningJobList', 
        'Get-SMImage', 
        'Get-SMImageList', 
        'Get-SMImageVersion', 
        'Get-SMImageVersionList', 
        'Get-SMLabelingJob', 
        'Get-SMLabelingJobList', 
        'Get-SMLabelingJobListForWorkteam', 
        'Get-SMModel', 
        'Get-SMModelBiasJobDefinition', 
        'Get-SMModelBiasJobDefinitionList', 
        'Get-SMModelExplainabilityJobDefinition', 
        'Get-SMModelExplainabilityJobDefinitionList', 
        'Get-SMModelList', 
        'Get-SMModelPackage', 
        'Get-SMModelPackageGroup', 
        'Get-SMModelPackageGroupList', 
        'Get-SMModelPackageGroupPolicy', 
        'Get-SMModelPackageList', 
        'Get-SMModelQualityJobDefinition', 
        'Get-SMModelQualityJobDefinitionList', 
        'Get-SMMonitoringExecutionList', 
        'Get-SMMonitoringSchedule', 
        'Get-SMMonitoringScheduleList', 
        'Get-SMNotebookInstance', 
        'Get-SMNotebookInstanceLifecycleConfig', 
        'Get-SMNotebookInstanceLifecycleConfigList', 
        'Get-SMNotebookInstanceList', 
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
        'Get-SMResourceTagList', 
        'Get-SMSagemakerServicecatalogPortfolioStatus', 
        'Get-SMSearchSuggestion', 
        'Get-SMStudioLifecycleConfig', 
        'Get-SMStudioLifecycleConfigList', 
        'Get-SMSubscribedWorkteam', 
        'Get-SMSubscribedWorkteamList', 
        'Get-SMTrainingJob', 
        'Get-SMTrainingJobList', 
        'Get-SMTrainingJobsForHyperParameterTuningJobList', 
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
        'Invoke-SMUiTemplateRendering', 
        'New-SMAction', 
        'New-SMAlgorithm', 
        'New-SMApp', 
        'New-SMAppImageConfig', 
        'New-SMArtifact', 
        'New-SMAutoMLJob', 
        'New-SMCodeRepository', 
        'New-SMCompilationJob', 
        'New-SMContext', 
        'New-SMDataQualityJobDefinition', 
        'New-SMDeviceFleet', 
        'New-SMDomain', 
        'New-SMEdgePackagingJob', 
        'New-SMEndpoint', 
        'New-SMEndpointConfig', 
        'New-SMExperiment', 
        'New-SMFeatureGroup', 
        'New-SMFlowDefinition', 
        'New-SMHumanTaskUi', 
        'New-SMHyperParameterTuningJob', 
        'New-SMImage', 
        'New-SMImageVersion', 
        'New-SMLabelingJob', 
        'New-SMModel', 
        'New-SMModelBiasJobDefinition', 
        'New-SMModelExplainabilityJobDefinition', 
        'New-SMModelPackage', 
        'New-SMModelPackageGroup', 
        'New-SMModelQualityJobDefinition', 
        'New-SMMonitoringSchedule', 
        'New-SMNotebookInstance', 
        'New-SMNotebookInstanceLifecycleConfig', 
        'New-SMPipeline', 
        'New-SMPresignedDomainUrl', 
        'New-SMPresignedNotebookInstanceUrl', 
        'New-SMProcessingJob', 
        'New-SMProject', 
        'New-SMStudioLifecycleConfig', 
        'New-SMTrainingJob', 
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
        'Remove-SMCodeRepository', 
        'Remove-SMContext', 
        'Remove-SMDataQualityJobDefinition', 
        'Remove-SMDevice', 
        'Remove-SMDeviceFleet', 
        'Remove-SMDomain', 
        'Remove-SMEndpoint', 
        'Remove-SMEndpointConfig', 
        'Remove-SMExperiment', 
        'Remove-SMFeatureGroup', 
        'Remove-SMFlowDefinition', 
        'Remove-SMHumanTaskUi', 
        'Remove-SMImage', 
        'Remove-SMImageVersion', 
        'Remove-SMModel', 
        'Remove-SMModelBiasJobDefinition', 
        'Remove-SMModelExplainabilityJobDefinition', 
        'Remove-SMModelPackage', 
        'Remove-SMModelPackageGroup', 
        'Remove-SMModelPackageGroupPolicy', 
        'Remove-SMModelQualityJobDefinition', 
        'Remove-SMMonitoringSchedule', 
        'Remove-SMNotebookInstance', 
        'Remove-SMNotebookInstanceLifecycleConfig', 
        'Remove-SMPipeline', 
        'Remove-SMProject', 
        'Remove-SMResourceTag', 
        'Remove-SMStudioLifecycleConfig', 
        'Remove-SMTrial', 
        'Remove-SMTrialComponent', 
        'Remove-SMUserProfile', 
        'Remove-SMWorkforce', 
        'Remove-SMWorkteam', 
        'Restart-SMPipelineExecution', 
        'Search-SMResource', 
        'Send-SMPipelineExecutionStepFailure', 
        'Send-SMPipelineExecutionStepSuccess', 
        'Start-SMMonitoringSchedule', 
        'Start-SMNotebookInstance', 
        'Start-SMPipelineExecution', 
        'Stop-SMAutoMLJob', 
        'Stop-SMCompilationJob', 
        'Stop-SMEdgePackagingJob', 
        'Stop-SMHyperParameterTuningJob', 
        'Stop-SMLabelingJob', 
        'Stop-SMMonitoringSchedule', 
        'Stop-SMNotebookInstance', 
        'Stop-SMPipelineExecution', 
        'Stop-SMProcessingJob', 
        'Stop-SMTrainingJob', 
        'Stop-SMTransformJob', 
        'Unregister-SMTrialComponent', 
        'Update-SMAction', 
        'Update-SMAppImageConfig', 
        'Update-SMArtifact', 
        'Update-SMCodeRepository', 
        'Update-SMContext', 
        'Update-SMDevice', 
        'Update-SMDeviceFleet', 
        'Update-SMDomain', 
        'Update-SMEndpoint', 
        'Update-SMEndpointWeightAndCapacity', 
        'Update-SMExperiment', 
        'Update-SMImage', 
        'Update-SMModelPackage', 
        'Update-SMMonitoringSchedule', 
        'Update-SMNotebookInstance', 
        'Update-SMNotebookInstanceLifecycleConfig', 
        'Update-SMPipeline', 
        'Update-SMPipelineExecution', 
        'Update-SMProject', 
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
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md'
        }
    }
}
