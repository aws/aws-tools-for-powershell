#
# Module manifest for module 'AWSPowerShell'
#

@{

# Script module or binary module file associated with this manifest
ModuleToProcess = 'AWSPowerShell.dll'

# Version number of this module.
ModuleVersion = '3.3.183.1'

# ID used to uniquely identify this module
GUID = '21f083f2-4c41-4b5d-88ec-7d24c9e88769'

# Author of this module
Author = 'Amazon.com, Inc'

# Company or vendor of this module
CompanyName = 'Amazon.com, Inc'

# Copyright statement for this module
Copyright = 'Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

# Description of the functionality provided by this module
Description = 'The AWS Tools for Windows PowerShell lets developers and administrators manage their AWS services from the Windows PowerShell scripting environment.'

# Minimum version of the Windows PowerShell engine required by this module
PowerShellVersion = '2.0'

# Name of the Windows PowerShell host required by this module
PowerShellHostName = ''

# Minimum version of the Windows PowerShell host required by this module
PowerShellHostVersion = ''

# Minimum version of the .NET Framework required by this module
DotNetFrameworkVersion = ''

# Minimum version of the common language runtime (CLR) required by this module
CLRVersion = ''

# Processor architecture (None, X86, Amd64, IA64) required by this module
ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
RequiredModules = @()

# Assemblies that must be loaded prior to importing this module.
# We list the SDK assemblies for the convenience of PowerShell v2 users 
# who want to work with generic types when the type parameter is in an 
# external SDK assembly.
RequiredAssemblies = @(
  "AWSSDK.ACMPCA.dll",
  "AWSSDK.AlexaForBusiness.dll",
  "AWSSDK.Amplify.dll",
  "AWSSDK.APIGateway.dll",
  "AWSSDK.ApiGatewayManagementApi.dll",
  "AWSSDK.ApiGatewayV2.dll",
  "AWSSDK.ApplicationAutoScaling.dll",
  "AWSSDK.ApplicationDiscoveryService.dll",
  "AWSSDK.AppMesh.dll",
  "AWSSDK.AppStream.dll",
  "AWSSDK.AppSync.dll",
  "AWSSDK.Athena.dll",
  "AWSSDK.AutoScaling.dll",
  "AWSSDK.AutoScalingPlans.dll",
  "AWSSDK.AWSHealth.dll",
  "AWSSDK.AWSMarketplaceCommerceAnalytics.dll",
  "AWSSDK.AWSMarketplaceMetering.dll",
  "AWSSDK.AWSSupport.dll",
  "AWSSDK.Backup.dll",
  "AWSSDK.Batch.dll",
  "AWSSDK.Budgets.dll",
  "AWSSDK.CertificateManager.dll",
  "AWSSDK.Chime.dll",
  "AWSSDK.Cloud9.dll",
  "AWSSDK.CloudDirectory.dll",
  "AWSSDK.CloudFormation.dll",
  "AWSSDK.CloudFront.dll",
  "AWSSDK.CloudHSM.dll",
  "AWSSDK.CloudHSMV2.dll",
  "AWSSDK.CloudSearch.dll",
  "AWSSDK.CloudSearchDomain.dll",
  "AWSSDK.CloudTrail.dll",
  "AWSSDK.CloudWatch.dll",
  "AWSSDK.CloudWatchEvents.dll",
  "AWSSDK.CloudWatchLogs.dll",
  "AWSSDK.CodeBuild.dll",
  "AWSSDK.CodeCommit.dll",
  "AWSSDK.CodeDeploy.dll",
  "AWSSDK.CodePipeline.dll",
  "AWSSDK.CodeStar.dll",
  "AWSSDK.CognitoIdentity.dll",
  "AWSSDK.CognitoIdentityProvider.dll",
  "AWSSDK.CognitoSync.dll",
  "AWSSDK.Comprehend.dll",
  "AWSSDK.ComprehendMedical.dll",
  "AWSSDK.ConfigService.dll",
  "AWSSDK.Connect.dll",
  "AWSSDK.Core.dll",
  "AWSSDK.CostAndUsageReport.dll",
  "AWSSDK.CostExplorer.dll",
  "AWSSDK.DatabaseMigrationService.dll",
  "AWSSDK.DataPipeline.dll",
  "AWSSDK.DataSync.dll",
  "AWSSDK.DAX.dll",
  "AWSSDK.DeviceFarm.dll",
  "AWSSDK.DirectConnect.dll",
  "AWSSDK.DirectoryService.dll",
  "AWSSDK.DLM.dll",
  "AWSSDK.DocDB.dll",
  "AWSSDK.DynamoDBv2.dll",
  "AWSSDK.EC2.dll",
  "AWSSDK.ECR.dll",
  "AWSSDK.ECS.dll",
  "AWSSDK.EKS.dll",
  "AWSSDK.ElastiCache.dll",
  "AWSSDK.ElasticBeanstalk.dll",
  "AWSSDK.ElasticFileSystem.dll",
  "AWSSDK.ElasticLoadBalancing.dll",
  "AWSSDK.ElasticLoadBalancingV2.dll",
  "AWSSDK.ElasticMapReduce.dll",
  "AWSSDK.Elasticsearch.dll",
  "AWSSDK.ElasticTranscoder.dll",
  "AWSSDK.FMS.dll",
  "AWSSDK.FSx.dll",
  "AWSSDK.GameLift.dll",
  "AWSSDK.Glacier.dll",
  "AWSSDK.GlobalAccelerator.dll",
  "AWSSDK.Glue.dll",
  "AWSSDK.Greengrass.dll",
  "AWSSDK.GuardDuty.dll",
  "AWSSDK.IdentityManagement.dll",
  "AWSSDK.ImportExport.dll",
  "AWSSDK.Inspector.dll",
  "AWSSDK.IoT.dll",
  "AWSSDK.IoTJobsDataPlane.dll",
  "AWSSDK.Kafka.dll",
  "AWSSDK.KeyManagementService.dll",
  "AWSSDK.Kinesis.dll",
  "AWSSDK.KinesisAnalytics.dll",
  "AWSSDK.KinesisAnalyticsV2.dll",
  "AWSSDK.KinesisFirehose.dll",
  "AWSSDK.KinesisVideo.dll",
  "AWSSDK.KinesisVideoMedia.dll",
  "AWSSDK.Lambda.dll",
  "AWSSDK.Lex.dll",
  "AWSSDK.LexModelBuildingService.dll",
  "AWSSDK.LicenseManager.dll",
  "AWSSDK.Lightsail.dll",
  "AWSSDK.MachineLearning.dll",
  "AWSSDK.Macie.dll",
  "AWSSDK.MarketplaceEntitlementService.dll",
  "AWSSDK.MediaConnect.dll",
  "AWSSDK.MediaConvert.dll",
  "AWSSDK.MediaLive.dll",
  "AWSSDK.MediaPackage.dll",
  "AWSSDK.MediaStore.dll",
  "AWSSDK.MediaStoreData.dll",
  "AWSSDK.MediaTailor.dll",
  "AWSSDK.MigrationHub.dll",
  "AWSSDK.Mobile.dll",
  "AWSSDK.MQ.dll",
  "AWSSDK.MTurk.dll",
  "AWSSDK.Neptune.dll",
  "AWSSDK.OpsWorks.dll",
  "AWSSDK.OpsWorksCM.dll",
  "AWSSDK.Organizations.dll",
  "AWSSDK.PI.dll",
  "AWSSDK.Pinpoint.dll",
  "AWSSDK.PinpointEmail.dll",
  "AWSSDK.Polly.dll",
  "AWSSDK.Pricing.dll",
  "AWSSDK.QuickSight.dll",
  "AWSSDK.RAM.dll",
  "AWSSDK.RDS.dll",
  "AWSSDK.RDSDataService.dll",
  "AWSSDK.Redshift.dll",
  "AWSSDK.Rekognition.dll",
  "AWSSDK.ResourceGroups.dll",
  "AWSSDK.ResourceGroupsTaggingAPI.dll",
  "AWSSDK.RoboMaker.dll",
  "AWSSDK.Route53.dll",
  "AWSSDK.Route53Domains.dll",
  "AWSSDK.Route53Resolver.dll",
  "AWSSDK.S3.dll",
  "AWSSDK.S3Control.dll",
  "AWSSDK.SageMaker.dll",
  "AWSSDK.SageMakerRuntime.dll",
  "AWSSDK.SecretsManager.dll",
  "AWSSDK.SecurityHub.dll",
  "AWSSDK.SecurityToken.dll",
  "AWSSDK.ServerlessApplicationRepository.dll",
  "AWSSDK.ServerMigrationService.dll",
  "AWSSDK.ServiceCatalog.dll",
  "AWSSDK.ServiceDiscovery.dll",
  "AWSSDK.Shield.dll",
  "AWSSDK.SimpleEmail.dll",
  "AWSSDK.SimpleNotificationService.dll",
  "AWSSDK.SimpleSystemsManagement.dll",
  "AWSSDK.SimpleWorkflow.dll",
  "AWSSDK.Snowball.dll",
  "AWSSDK.SQS.dll",
  "AWSSDK.StepFunctions.dll",
  "AWSSDK.StorageGateway.dll",
  "AWSSDK.TranscribeService.dll",
  "AWSSDK.Transfer.dll",
  "AWSSDK.Translate.dll",
  "AWSSDK.WAF.dll",
  "AWSSDK.WAFRegional.dll",
  "AWSSDK.WorkDocs.dll",
  "AWSSDK.WorkLink.dll",
  "AWSSDK.WorkMail.dll",
  "AWSSDK.WorkSpaces.dll",
  "AWSSDK.XRay.dll"
)

# Script files (.ps1) that are run in the caller's environment prior to importing this module
ScriptsToProcess = @()

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
  "AWSPowerShellCompleters.psm1",
  "AWSPowerShellLegacyAliases.psm1"
)

# Functions to export from this module
FunctionsToExport = ''

# Cmdlets to export from this module
CmdletsToExport = '*-*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = @(
  "Add-ASInstances",
  "Add-CTTag",
  "Add-DPTags",
  "Add-DSIpRoutes",
  "Add-ELBTags",
  "Add-EMRTag",
  "Add-ESTag",
  "Add-MLTag",
  "Clear-AWSCredentials",
  "Clear-AWSDefaults",
  "Dismount-ASInstances",
  "Edit-EC2Hosts",
  "Edit-RSClusterIamRoles",
  "Enable-ORGAllFeatures",
  "Find-CTEvents",
  "Get-ASACases",
  "Get-ASAccountLimits",
  "Get-ASACommunications",
  "Get-ASAServices",
  "Get-ASASeverityLevels",
  "Get-ASATrustedAdvisorCheckRefreshStatuses",
  "Get-ASATrustedAdvisorChecks",
  "Get-ASATrustedAdvisorCheckSummaries",
  "Get-ASLifecycleHooks",
  "Get-ASLifecycleHookTypes",
  "Get-AWSCredentials",
  "Get-CDApplications",
  "Get-CDDeployments",
  "Get-CFCloudFrontOriginAccessIdentities",
  "Get-CFDistributions",
  "Get-CFGConfigRules",
  "Get-CFGConfigurationRecorders",
  "Get-CFGDeliveryChannels",
  "Get-CFInvalidations",
  "Get-CFNAccountLimits",
  "Get-CFNStackEvents",
  "Get-CFNStackResources",
  "Get-CFNStackResourceSummaries",
  "Get-CFNStackSummaries",
  "Get-CFStreamingDistributions",
  "Get-CPActionableJobs",
  "Get-CPActionableThirdPartyJobs",
  "Get-CPJobDetails",
  "Get-CPThirdPartyJobDetails",
  "Get-CSAnalysisSchemes",
  "Get-CSAvailabilityOptions",
  "Get-CSDSuggestions",
  "Get-CSIndexFields",
  "Get-CSListDomainNames",
  "Get-CSScalingParameters",
  "Get-CSServiceAccessPolicies",
  "Get-CTEventSelectors",
  "Get-CTTag",
  "Get-CURReportDefinitions",
  "Get-CWLExportTasks",
  "Get-CWLLogEvents",
  "Get-CWLLogGroups",
  "Get-CWLLogStreams",
  "Get-CWLMetricFilters",
  "Get-CWLSubscriptionFilters",
  "Get-CWMetrics",
  "Get-CWMetricStatistics",
  "Get-DCLocations",
  "Get-DDBTables",
  "Get-DSIpRoutes",
  "Get-EBApplications",
  "Get-EBApplicationVersions",
  "Get-EBAvailableSolutionStack",
  "Get-EBConfigurationOptions",
  "Get-EBConfigurationSettings",
  "Get-EBEnvironmentResources",
  "Get-EC2AccountAttributes",
  "Get-EC2ExportTasks",
  "Get-EC2FlowLogs",
  "Get-EC2Hosts",
  "Get-EC2ReservedInstancesModifications",
  "Get-EC2VpcPeeringConnections",
  "Get-ECCacheEngineVersions",
  "Get-ECCacheSubnetGroups",
  "Get-ECReplicationGroups",
  "Get-ECSClusters",
  "Get-ECSContainerInstances",
  "Get-ECSnapshots",
  "Get-ECSTaskDefinitionFamilies",
  "Get-ECSTaskDefinitions",
  "Get-ECSTasks",
  "Get-ELBTags",
  "Get-EMRBootstrapActions",
  "Get-EMRClusters",
  "Get-EMRInstanceFleets",
  "Get-EMRInstanceGroups",
  "Get-EMRInstances",
  "Get-EMRSteps",
  "Get-ESTag",
  "Get-HSMAvailableZones",
  "Get-IAMAccountAuthorizationDetails",
  "Get-IAMAttachedGroupPolicies",
  "Get-IAMAttachedRolePolicies",
  "Get-IAMAttachedUserPolicies",
  "Get-IAMGroupPolicies",
  "Get-IAMGroups",
  "Get-IAMInstanceProfiles",
  "Get-IAMOpenIDConnectProviders",
  "Get-IAMPolicies",
  "Get-IAMPolicyVersions",
  "Get-IAMRolePolicies",
  "Get-IAMRoles",
  "Get-IAMSAMLProviders",
  "Get-IAMServerCertificates",
  "Get-IAMUserPolicies",
  "Get-IAMUsers",
  "Get-IOTLoggingOptions",
  "Get-KINStreams",
  "Get-KMSAliases",
  "Get-KMSGrants",
  "Get-KMSKeyPolicies",
  "Get-KMSKeys",
  "Get-LMEventSourceMappings",
  "Get-LMFunctions",
  "Get-MLBatchPredictions",
  "Get-MLDataSources",
  "Get-MLEvaluations",
  "Get-MLModels",
  "Get-MLTag",
  "Get-OPSApps",
  "Get-OPSCommands",
  "Get-OPSDeployments",
  "Get-OPSElasticIps",
  "Get-OPSElasticLoadBalancers",
  "Get-OPSInstances",
  "Get-OPSLayers",
  "Get-OPSPermissions",
  "Get-OPSRaidArrays",
  "Get-OPSRdsDbInstances",
  "Get-OPSServiceErrors",
  "Get-OPSStackProvisioningParameters",
  "Get-OPSStacks",
  "Get-OPSUserProfiles",
  "Get-OPSVolumes",
  "Get-R53CheckerIpRanges",
  "Get-R53DDomainAvailability",
  "Get-R53DDomains",
  "Get-R53DOperations",
  "Get-R53GeoLocations",
  "Get-R53HealthChecks",
  "Get-R53HostedZones",
  "Get-R53ReusableDelegationSets",
  "Get-R53TagsForResources",
  "Get-R53TrafficPolicies",
  "Get-R53TrafficPolicyInstances",
  "Get-R53TrafficPolicyVersions",
  "Get-RDSAccountAttributes",
  "Get-RDSCertificates",
  "Get-RDSDBLogFiles",
  "Get-RDSDBSnapshotAttributes",
  "Get-RDSEventCategories",
  "Get-RDSEventSubscriptions",
  "Get-RDSPendingMaintenanceActions",
  "Get-RDSReservedDBInstancesOffering",
  "Get-RDSReservedDBInstancesOfferings",
  "Get-RSClusterParameterGroups",
  "Get-RSClusterParameters",
  "Get-RSClusters",
  "Get-RSClusterSecurityGroups",
  "Get-RSClusterSnapshots",
  "Get-RSClusterSubnetGroups",
  "Get-RSClusterVersions",
  "Get-RSDefaultClusterParameters",
  "Get-RSEventCategories",
  "Get-RSEvents",
  "Get-RSEventSubscriptions",
  "Get-RSHsmClientCertificates",
  "Get-RSHsmConfigurations",
  "Get-RSOrderableClusterOptions",
  "Get-RSReservedNodeOfferings",
  "Get-RSReservedNodes",
  "Get-RSTags",
  "Get-SESIdentityMailFromDomainAttributes",
  "Get-SESReceiptFilters",
  "Get-SESReceiptRuleSets",
  "Get-SESSendStatistics",
  "Get-SGChapCredentials",
  "Get-SGResourceTags",
  "Get-SGTapeArchives",
  "Get-SGTapeRecoveryPoints",
  "Get-SGTapes",
  "Get-SGVolumeInitiators",
  "Get-SGVTLDevices",
  "Get-SNSEndpointAttributes",
  "Get-SNSPlatformApplicationAttributes",
  "Get-SNSPlatformApplications",
  "Get-SNSSMSAttributes",
  "Get-SQSDeadLetterSourceQueues",
  "Get-SSMMaintenanceWindowTargets",
  "Get-SSMParameterNameList",
  "Get-WKSWorkspaceBundles",
  "Get-WKSWorkspaceDirectories",
  "Get-WKSWorkspaces",
  "Initialize-AWSDefaults",
  "New-AWSCredentials",
  "New-EC2FlowLogs",
  "New-EC2Hosts",
  "New-RSTags",
  "New-SGTapes",
  "ReleaseHosts",
  "Remove-ADSApplications",
  "Remove-CTTag",
  "Remove-DPTags",
  "Remove-DSIpRoutes",
  "Remove-EC2FlowLogs",
  "Remove-ELBTags",
  "Remove-EMRTag",
  "Remove-ESTag",
  "Remove-MLTag",
  "Remove-RSTags",
  "Remove-S3MultipartUploads",
  "Remove-SGChapCredentials",
  "Search-CSDDocuments",
  "Set-AWSCredentials",
  "Set-EBEnvironmentCNAMEs",
  "Set-EMRVisibleToAllUsers",
  "Set-IOTLoggingOptions",
  "Set-SNSEndpointAttributes",
  "Set-SNSPlatformApplicationAttributes",
  "Set-SNSSMSAttributes",
  "Stop-EMRSteps",
  "Test-EBConfigurationSettings",
  "Update-CSAvailabilityOptions",
  "Update-CSScalingParameters",
  "Update-CSServiceAccessPolicies",
  "Update-ETSPipelineNotifications",
  "Update-R53DDomainNameservers",
  "Update-SGChapCredentials",
  "Write-AASScalingPolicy",
  "Write-CFGEvaluations",
  "Write-CSDDocuments",
  "Write-CTEventSelectors",
  "Write-CWLLogEvents"
)

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
		Tags = @('AWS', 'cloud')
        LicenseUri = 'https://docs.aws.amazon.com/powershell/latest/reference/License.html'
        ProjectUri = 'https://aws.amazon.com/powershell/'
        IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
        ReleaseNotes = 'Release notes are available in the attached CHANGELOG.txt file.'
    }

}

}
