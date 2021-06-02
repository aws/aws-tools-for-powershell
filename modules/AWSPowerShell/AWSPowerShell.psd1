#
# Module manifest for module 'AWSPowerShell'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWSPowerShell.dll'

    # We are not including CompatiblePSEditions because it is not compatible with older PowerShell versions
    # CompatiblePSEditions = @('Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '21f083f2-4c41-4b5d-88ec-7d24c9e88769'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2021 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The AWS Tools for Windows PowerShell lets developers and administrators manage their AWS services from the Windows PowerShell scripting environment.
This version of AWS Tools for Windows PowerShell is compatible with Windows PowerShell 2-5.1. An alternative module, AWSPowerShell.NetCore, provides support for Windows PowerShell 3+ and PowerShell Core 6+ on Windows, Linux and macOS.
This product provides support for all AWS services in a single module. As an alternative, a modular variant is also available: separate smaller modules (e.g. AWS.Tools.EC2, AWS.Tools.S3...) allow managing each AWS Service.'

    # Minimum version of the PowerShell engine required by this module
    PowerShellVersion = '3.0'

    # Name of the PowerShell host required by this module
    PowerShellHostName = ''

    # Minimum version of the PowerShell host required by this module
    PowerShellHostVersion = ''

    # Minimum version of the .NET Framework required by this module
    DotNetFrameworkVersion = '4.5'

    # Minimum version of the common language runtime (CLR) required by this module
    CLRVersion = ''

    # Processor architecture (None, X86, Amd64, IA64) required by this module
    ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    RequiredModules = @(

    )

    # Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.AccessAnalyzer.dll',
        'AWSSDK.ACMPCA.dll',
        'AWSSDK.AlexaForBusiness.dll',
        'AWSSDK.Amplify.dll',
        'AWSSDK.AmplifyBackend.dll',
        'AWSSDK.APIGateway.dll',
        'AWSSDK.ApiGatewayManagementApi.dll',
        'AWSSDK.ApiGatewayV2.dll',
        'AWSSDK.AppConfig.dll',
        'AWSSDK.Appflow.dll',
        'AWSSDK.AppIntegrationsService.dll',
        'AWSSDK.ApplicationAutoScaling.dll',
        'AWSSDK.ApplicationCostProfiler.dll',
        'AWSSDK.ApplicationDiscoveryService.dll',
        'AWSSDK.ApplicationInsights.dll',
        'AWSSDK.AppMesh.dll',
        'AWSSDK.AppRegistry.dll',
        'AWSSDK.AppRunner.dll',
        'AWSSDK.AppStream.dll',
        'AWSSDK.AppSync.dll',
        'AWSSDK.Athena.dll',
        'AWSSDK.AuditManager.dll',
        'AWSSDK.AugmentedAIRuntime.dll',
        'AWSSDK.AutoScaling.dll',
        'AWSSDK.AutoScalingPlans.dll',
        'AWSSDK.AWSHealth.dll',
        'AWSSDK.AWSMarketplaceCommerceAnalytics.dll',
        'AWSSDK.AWSMarketplaceMetering.dll',
        'AWSSDK.AWSSupport.dll',
        'AWSSDK.Backup.dll',
        'AWSSDK.Batch.dll',
        'AWSSDK.Braket.dll',
        'AWSSDK.Budgets.dll',
        'AWSSDK.CertificateManager.dll',
        'AWSSDK.Chime.dll',
        'AWSSDK.Cloud9.dll',
        'AWSSDK.CloudDirectory.dll',
        'AWSSDK.CloudFormation.dll',
        'AWSSDK.CloudFront.dll',
        'AWSSDK.CloudHSM.dll',
        'AWSSDK.CloudHSMV2.dll',
        'AWSSDK.CloudSearch.dll',
        'AWSSDK.CloudSearchDomain.dll',
        'AWSSDK.CloudTrail.dll',
        'AWSSDK.CloudWatch.dll',
        'AWSSDK.CloudWatchEvents.dll',
        'AWSSDK.CloudWatchLogs.dll',
        'AWSSDK.CodeArtifact.dll',
        'AWSSDK.CodeBuild.dll',
        'AWSSDK.CodeCommit.dll',
        'AWSSDK.CodeDeploy.dll',
        'AWSSDK.CodeGuruProfiler.dll',
        'AWSSDK.CodeGuruReviewer.dll',
        'AWSSDK.CodePipeline.dll',
        'AWSSDK.CodeStar.dll',
        'AWSSDK.CodeStarconnections.dll',
        'AWSSDK.CodeStarNotifications.dll',
        'AWSSDK.CognitoIdentity.dll',
        'AWSSDK.CognitoIdentityProvider.dll',
        'AWSSDK.CognitoSync.dll',
        'AWSSDK.Comprehend.dll',
        'AWSSDK.ComprehendMedical.dll',
        'AWSSDK.ComputeOptimizer.dll',
        'AWSSDK.ConfigService.dll',
        'AWSSDK.Connect.dll',
        'AWSSDK.ConnectContactLens.dll',
        'AWSSDK.ConnectParticipant.dll',
        'AWSSDK.Core.dll',
        'AWSSDK.CostAndUsageReport.dll',
        'AWSSDK.CostExplorer.dll',
        'AWSSDK.CustomerProfiles.dll',
        'AWSSDK.DatabaseMigrationService.dll',
        'AWSSDK.DataExchange.dll',
        'AWSSDK.DataPipeline.dll',
        'AWSSDK.DataSync.dll',
        'AWSSDK.DAX.dll',
        'AWSSDK.Detective.dll',
        'AWSSDK.DeviceFarm.dll',
        'AWSSDK.DevOpsGuru.dll',
        'AWSSDK.DirectConnect.dll',
        'AWSSDK.DirectoryService.dll',
        'AWSSDK.DLM.dll',
        'AWSSDK.DocDB.dll',
        'AWSSDK.DynamoDBv2.dll',
        'AWSSDK.EBS.dll',
        'AWSSDK.EC2.dll',
        'AWSSDK.EC2InstanceConnect.dll',
        'AWSSDK.ECR.dll',
        'AWSSDK.ECRPublic.dll',
        'AWSSDK.ECS.dll',
        'AWSSDK.EKS.dll',
        'AWSSDK.ElastiCache.dll',
        'AWSSDK.ElasticBeanstalk.dll',
        'AWSSDK.ElasticFileSystem.dll',
        'AWSSDK.ElasticInference.dll',
        'AWSSDK.ElasticLoadBalancing.dll',
        'AWSSDK.ElasticLoadBalancingV2.dll',
        'AWSSDK.ElasticMapReduce.dll',
        'AWSSDK.Elasticsearch.dll',
        'AWSSDK.ElasticTranscoder.dll',
        'AWSSDK.EMRContainers.dll',
        'AWSSDK.EventBridge.dll',
        'AWSSDK.Finspace.dll',
        'AWSSDK.FinSpaceData.dll',
        'AWSSDK.FIS.dll',
        'AWSSDK.FMS.dll',
        'AWSSDK.ForecastQueryService.dll',
        'AWSSDK.ForecastService.dll',
        'AWSSDK.FraudDetector.dll',
        'AWSSDK.FSx.dll',
        'AWSSDK.GameLift.dll',
        'AWSSDK.Glacier.dll',
        'AWSSDK.GlobalAccelerator.dll',
        'AWSSDK.Glue.dll',
        'AWSSDK.GlueDataBrew.dll',
        'AWSSDK.Greengrass.dll',
        'AWSSDK.GreengrassV2.dll',
        'AWSSDK.GroundStation.dll',
        'AWSSDK.GuardDuty.dll',
        'AWSSDK.HealthLake.dll',
        'AWSSDK.Honeycode.dll',
        'AWSSDK.IdentityManagement.dll',
        'AWSSDK.IdentityStore.dll',
        'AWSSDK.Imagebuilder.dll',
        'AWSSDK.ImportExport.dll',
        'AWSSDK.Inspector.dll',
        'AWSSDK.IoT.dll',
        'AWSSDK.IoTDeviceAdvisor.dll',
        'AWSSDK.IoTEvents.dll',
        'AWSSDK.IoTEventsData.dll',
        'AWSSDK.IoTFleetHub.dll',
        'AWSSDK.IoTJobsDataPlane.dll',
        'AWSSDK.IoTSecureTunneling.dll',
        'AWSSDK.IoTSiteWise.dll',
        'AWSSDK.IoTThingsGraph.dll',
        'AWSSDK.IoTWireless.dll',
        'AWSSDK.IVS.dll',
        'AWSSDK.Kafka.dll',
        'AWSSDK.Kendra.dll',
        'AWSSDK.KeyManagementService.dll',
        'AWSSDK.Kinesis.dll',
        'AWSSDK.KinesisAnalytics.dll',
        'AWSSDK.KinesisAnalyticsV2.dll',
        'AWSSDK.KinesisFirehose.dll',
        'AWSSDK.KinesisVideo.dll',
        'AWSSDK.KinesisVideoMedia.dll',
        'AWSSDK.KinesisVideoSignalingChannels.dll',
        'AWSSDK.LakeFormation.dll',
        'AWSSDK.Lambda.dll',
        'AWSSDK.Lex.dll',
        'AWSSDK.LexModelBuildingService.dll',
        'AWSSDK.LexModelsV2.dll',
        'AWSSDK.LexRuntimeV2.dll',
        'AWSSDK.LicenseManager.dll',
        'AWSSDK.Lightsail.dll',
        'AWSSDK.LocationService.dll',
        'AWSSDK.LookoutEquipment.dll',
        'AWSSDK.LookoutforVision.dll',
        'AWSSDK.LookoutMetrics.dll',
        'AWSSDK.MachineLearning.dll',
        'AWSSDK.Macie.dll',
        'AWSSDK.Macie2.dll',
        'AWSSDK.ManagedBlockchain.dll',
        'AWSSDK.MarketplaceCatalog.dll',
        'AWSSDK.MarketplaceEntitlementService.dll',
        'AWSSDK.MediaConnect.dll',
        'AWSSDK.MediaConvert.dll',
        'AWSSDK.MediaLive.dll',
        'AWSSDK.MediaPackage.dll',
        'AWSSDK.MediaPackageVod.dll',
        'AWSSDK.MediaStore.dll',
        'AWSSDK.MediaStoreData.dll',
        'AWSSDK.MediaTailor.dll',
        'AWSSDK.Mgn.dll',
        'AWSSDK.MigrationHub.dll',
        'AWSSDK.MigrationHubConfig.dll',
        'AWSSDK.Mobile.dll',
        'AWSSDK.MQ.dll',
        'AWSSDK.MTurk.dll',
        'AWSSDK.MWAA.dll',
        'AWSSDK.Neptune.dll',
        'AWSSDK.NetworkFirewall.dll',
        'AWSSDK.NetworkManager.dll',
        'AWSSDK.NimbleStudio.dll',
        'AWSSDK.OpsWorks.dll',
        'AWSSDK.OpsWorksCM.dll',
        'AWSSDK.Organizations.dll',
        'AWSSDK.Outposts.dll',
        'AWSSDK.Personalize.dll',
        'AWSSDK.PersonalizeEvents.dll',
        'AWSSDK.PersonalizeRuntime.dll',
        'AWSSDK.PI.dll',
        'AWSSDK.Pinpoint.dll',
        'AWSSDK.PinpointEmail.dll',
        'AWSSDK.Polly.dll',
        'AWSSDK.Pricing.dll',
        'AWSSDK.PrometheusService.dll',
        'AWSSDK.Proton.dll',
        'AWSSDK.QLDB.dll',
        'AWSSDK.QLDBSession.dll',
        'AWSSDK.QuickSight.dll',
        'AWSSDK.RAM.dll',
        'AWSSDK.RDS.dll',
        'AWSSDK.RDSDataService.dll',
        'AWSSDK.Redshift.dll',
        'AWSSDK.RedshiftDataAPIService.dll',
        'AWSSDK.Rekognition.dll',
        'AWSSDK.ResourceGroups.dll',
        'AWSSDK.ResourceGroupsTaggingAPI.dll',
        'AWSSDK.RoboMaker.dll',
        'AWSSDK.Route53.dll',
        'AWSSDK.Route53Domains.dll',
        'AWSSDK.Route53Resolver.dll',
        'AWSSDK.S3.dll',
        'AWSSDK.S3Control.dll',
        'AWSSDK.S3Outposts.dll',
        'AWSSDK.SageMaker.dll',
        'AWSSDK.SagemakerEdgeManager.dll',
        'AWSSDK.SageMakerFeatureStoreRuntime.dll',
        'AWSSDK.SageMakerRuntime.dll',
        'AWSSDK.SavingsPlans.dll',
        'AWSSDK.Schemas.dll',
        'AWSSDK.SecretsManager.dll',
        'AWSSDK.SecurityHub.dll',
        'AWSSDK.SecurityToken.dll',
        'AWSSDK.ServerlessApplicationRepository.dll',
        'AWSSDK.ServerMigrationService.dll',
        'AWSSDK.ServiceCatalog.dll',
        'AWSSDK.ServiceDiscovery.dll',
        'AWSSDK.ServiceQuotas.dll',
        'AWSSDK.Shield.dll',
        'AWSSDK.SimpleEmail.dll',
        'AWSSDK.SimpleEmailV2.dll',
        'AWSSDK.SimpleNotificationService.dll',
        'AWSSDK.SimpleSystemsManagement.dll',
        'AWSSDK.SimpleWorkflow.dll',
        'AWSSDK.Snowball.dll',
        'AWSSDK.SQS.dll',
        'AWSSDK.SSMContacts.dll',
        'AWSSDK.SSMIncidents.dll',
        'AWSSDK.SSO.dll',
        'AWSSDK.SSOAdmin.dll',
        'AWSSDK.SSOOIDC.dll',
        'AWSSDK.StepFunctions.dll',
        'AWSSDK.StorageGateway.dll',
        'AWSSDK.Synthetics.dll',
        'AWSSDK.Textract.dll',
        'AWSSDK.TimestreamQuery.dll',
        'AWSSDK.TimestreamWrite.dll',
        'AWSSDK.TranscribeService.dll',
        'AWSSDK.Transfer.dll',
        'AWSSDK.Translate.dll',
        'AWSSDK.WAF.dll',
        'AWSSDK.WAFRegional.dll',
        'AWSSDK.WAFV2.dll',
        'AWSSDK.WellArchitected.dll',
        'AWSSDK.WorkDocs.dll',
        'AWSSDK.WorkLink.dll',
        'AWSSDK.WorkMail.dll',
        'AWSSDK.WorkMailMessageFlow.dll',
        'AWSSDK.WorkSpaces.dll',
        'AWSSDK.XRay.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(
        'ImportGuard.ps1'
    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(
        'AWSPowerShell.TypeExtensions.ps1xml'
    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWSPowerShell.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWSPowerShellCompleters.psm1',
        'AWSPowerShellLegacyAliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = '*-*'

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = '*'

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWSPowerShell.dll-Help.xml', 
        'CHANGELOG.txt'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md'
        }
    }
}
