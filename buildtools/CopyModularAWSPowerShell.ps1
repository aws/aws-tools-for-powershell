param (
    [string]$rootFolder,
    [string]$configuration
)

$ErrorActionPreference = "Stop"

$releaseBitPath = "bin/$configuration/netstandard2.0"

$generatorAssemblyPath ="$rootFolder/generator/AWSPSGenerator/bin/$configuration/netcoreapp3.1/AWSPSGenerator.dll"
$modularDeploymentFolder = "$rootFolder/Deployment/AWS.Tools"
$commonModuleFolder = "$rootFolder/modules/ModularAWSPowerShell"
$installerModuleFolder = "$rootFolder/modules/Installer"
$monolithicModuleFolder = "$rootFolder/modules/AWSPowerShell"
$serviceProjectsFolder = "$monolithicModuleFolder/Cmdlets"
$assembliesFolder = "$rootFolder/Include/sdk/assemblies"

$moduleFilesSuffixes = @('.Completers.psm1', '.Aliases.psm1', '.psd1')
$binFilesSuffixes = @('.dll', '.XML', '.dll-Help.xml', '.Format.ps1xml')

If (Test-Path $modularDeploymentFolder)
{
    Remove-Item -Path $modularDeploymentFolder -Recurse
}
New-Item -Path $modularDeploymentFolder -ItemType Directory

dotnet $generatorAssemblyPath -rp $rootFolder -t formats -an AWS.Tools.Common -ml $commonModuleFolder/$releaseBitPath -sdk $assembliesFolder
If ($LASTEXITCODE){
  Throw "Formats Generator returned error $LASTEXITCODE for Common"
}
dotnet $generatorAssemblyPath -rp $rootFolder -t pshelp -an AWS.Tools.Common -ml $commonModuleFolder/$releaseBitPath
If ($LASTEXITCODE){
  Throw "PSHelp Generator returned error $LASTEXITCODE for Common"
}
New-Item -Path "$modularDeploymentFolder/AWS.Tools.Common" -ItemType Directory
foreach ($suffix in $moduleFilesSuffixes)
{
    Copy-Item -Path "$commonModuleFolder/AWS.Tools.Common$suffix" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWS.Tools.Common$suffix"
}
foreach ($suffix in $binFilesSuffixes)
{
    Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWS.Tools.Common$suffix" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWS.Tools.Common$suffix"
}
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.Core.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.Core.dll"
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.SecurityToken.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.SecurityToken.dll"
Copy-Item -Path "$monolithicModuleFolder/ImportGuard.ps1" -Destination "$modularDeploymentFolder/AWS.Tools.Common/ImportGuard.ps1"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt-auth.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt-auth.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt-http.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt-http.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt-checksums.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt-checksums.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/AWSSDK.Extensions.CrtIntegration.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.Extensions.CrtIntegration.dll"
Copy-Item -Path "$rootFolder/LICENSE" -Destination "$modularDeploymentFolder/AWS.Tools.Common/LICENSE"
Copy-Item -Path "$rootFolder/NOTICE" -Destination "$modularDeploymentFolder/AWS.Tools.Common/NOTICE"

$projectNameList = @('AccessAnalyzer', 'Account', 'ACMPCA', 'AlexaForBusiness', 'Amplify', 'AmplifyBackend', 'AmplifyUIBuilder', 'APIGateway', 'ApiGatewayManagementApi', 'ApiGatewayV2', 'AppConfig', 'AppConfigData', 'AppFabric', 'Appflow', 'AppIntegrationsService', 'ApplicationAutoScaling', 'ApplicationCostProfiler', 'ApplicationDiscoveryService', 'ApplicationInsights', 'AppMesh', 'AppRegistry', 'AppRunner', 'AppStream', 'AppSync', 'ARCZonalShift', 'Athena', 'AuditManager', 'AugmentedAIRuntime', 'AutoScaling', 'AutoScalingPlans', 'AWSHealth', 'AWSMarketplaceCommerceAnalytics', 'AWSMarketplaceMetering', 'AWSSupport', 'B2bi', 'Backup', 'BackupGateway', 'BackupStorage', 'Batch', 'BCMDataExports', 'Bedrock', 'BedrockAgent', 'BedrockAgentRuntime', 'BedrockRuntime', 'BillingConductor', 'Braket', 'Budgets', 'CertificateManager', 'Chime', 'ChimeSDKIdentity', 'ChimeSDKMediaPipelines', 'ChimeSDKMeetings', 'ChimeSDKMessaging', 'ChimeSDKVoice', 'CleanRooms', 'CleanRoomsML', 'Cloud9', 'CloudControlApi', 'CloudDirectory', 'CloudFormation', 'CloudFront', 'CloudFrontKeyValueStore', 'CloudHSMV2', 'CloudSearch', 'CloudSearchDomain', 'CloudTrail', 'CloudTrailData', 'CloudWatch', 'CloudWatchEvidently', 'CloudWatchLogs', 'CloudWatchRUM', 'CodeArtifact', 'CodeBuild', 'CodeCatalyst', 'CodeCommit', 'CodeDeploy', 'CodeGuruProfiler', 'CodeGuruReviewer', 'CodeGuruSecurity', 'CodePipeline', 'CodeStar', 'CodeStarconnections', 'CodeStarNotifications', 'CognitoIdentity', 'CognitoIdentityProvider', 'CognitoSync', 'Comprehend', 'ComprehendMedical', 'ComputeOptimizer', 'ConfigService', 'Connect', 'ConnectCampaignService', 'ConnectCases', 'ConnectContactLens', 'ConnectParticipant', 'ConnectWisdomService', 'ControlTower', 'CostAndUsageReport', 'CostExplorer', 'CostOptimizationHub', 'CustomerProfiles', 'DatabaseMigrationService', 'DataExchange', 'DataPipeline', 'DataSync', 'DataZone', 'DAX', 'Detective', 'DeviceFarm', 'DevOpsGuru', 'DirectConnect', 'DirectoryService', 'DLM', 'DocDB', 'DocDBElastic', 'Drs', 'DynamoDBv2', 'EBS', 'EC2', 'EC2InstanceConnect', 'ECR', 'ECRPublic', 'ECS', 'EKS', 'EKSAuth', 'ElastiCache', 'ElasticBeanstalk', 'ElasticFileSystem', 'ElasticInference', 'ElasticLoadBalancing', 'ElasticLoadBalancingV2', 'ElasticMapReduce', 'Elasticsearch', 'ElasticTranscoder', 'EMRContainers', 'EMRServerless', 'EntityResolution', 'EventBridge', 'Finspace', 'FinSpaceData', 'FIS', 'FMS', 'ForecastQueryService', 'ForecastService', 'FraudDetector', 'FreeTier', 'FSx', 'GameLift', 'Glacier', 'GlobalAccelerator', 'Glue', 'GlueDataBrew', 'Greengrass', 'GreengrassV2', 'GroundStation', 'GuardDuty', 'HealthLake', 'Honeycode', 'IAMRolesAnywhere', 'IdentityManagement', 'IdentityStore', 'Imagebuilder', 'ImportExport', 'Inspector', 'Inspector2', 'InspectorScan', 'InternetMonitor', 'IoT', 'IoTDeviceAdvisor', 'IoTEvents', 'IoTEventsData', 'IoTFleetHub', 'IoTFleetWise', 'IoTJobsDataPlane', 'IoTRoboRunner', 'IoTSecureTunneling', 'IoTSiteWise', 'IoTThingsGraph', 'IoTTwinMaker', 'IoTWireless', 'IVS', 'Ivschat', 'IVSRealTime', 'Kafka', 'KafkaConnect', 'Kendra', 'KendraRanking', 'KeyManagementService', 'Keyspaces', 'Kinesis', 'KinesisAnalyticsV2', 'KinesisFirehose', 'KinesisVideo', 'KinesisVideoMedia', 'KinesisVideoSignalingChannels', 'KinesisVideoWebRTCStorage', 'LakeFormation', 'Lambda', 'LaunchWizard', 'Lex', 'LexModelBuildingService', 'LexModelsV2', 'LexRuntimeV2', 'LicenseManager', 'LicenseManagerLinuxSubscriptions', 'LicenseManagerUserSubscriptions', 'Lightsail', 'LocationService', 'LookoutEquipment', 'LookoutforVision', 'LookoutMetrics', 'MachineLearning', 'Macie2', 'MainframeModernization', 'ManagedBlockchain', 'ManagedBlockchainQuery', 'ManagedGrafana', 'MarketplaceAgreement', 'MarketplaceCatalog', 'MarketplaceDeployment', 'MarketplaceEntitlementService', 'MediaConnect', 'MediaConvert', 'MediaLive', 'MediaPackage', 'MediaPackageV2', 'MediaPackageVod', 'MediaStore', 'MediaStoreData', 'MediaTailor', 'MedicalImaging', 'MemoryDB', 'Mgn', 'MigrationHub', 'MigrationHubConfig', 'MigrationHubOrchestrator', 'MigrationHubRefactorSpaces', 'MigrationHubStrategyRecommendations', 'Mobile', 'MQ', 'MTurk', 'MWAA', 'Neptune', 'Neptunedata', 'NetworkFirewall', 'NetworkManager', 'NimbleStudio', 'OAM', 'Omics', 'OpenSearchServerless', 'OpenSearchService', 'OpsWorks', 'OpsWorksCM', 'Organizations', 'OSIS', 'Outposts', 'Panorama', 'PaymentCryptography', 'PaymentCryptographyData', 'PcaConnectorAd', 'Personalize', 'PersonalizeEvents', 'PersonalizeRuntime', 'PI', 'Pinpoint', 'PinpointEmail', 'PinpointSMSVoiceV2', 'Pipes', 'Polly', 'Pricing', 'Private5G', 'PrometheusService', 'Proton', 'QBusiness', 'QConnect', 'QLDB', 'QLDBSession', 'QuickSight', 'RAM', 'RDS', 'RDSDataService', 'RecycleBin', 'Redshift', 'RedshiftDataAPIService', 'RedshiftServerless', 'Rekognition', 'Repostspace', 'ResilienceHub', 'ResourceExplorer2', 'ResourceGroups', 'ResourceGroupsTaggingAPI', 'RoboMaker', 'Route53', 'Route53Domains', 'Route53RecoveryCluster', 'Route53RecoveryControlConfig', 'Route53RecoveryReadiness', 'Route53Resolver', 'S3', 'S3Control', 'S3Outposts', 'SageMaker', 'SagemakerEdgeManager', 'SageMakerFeatureStoreRuntime', 'SageMakerGeospatial', 'SageMakerMetrics', 'SageMakerRuntime', 'SavingsPlans', 'Scheduler', 'Schemas', 'SecretsManager', 'SecurityHub', 'SecurityLake', 'SecurityToken', 'ServerlessApplicationRepository', 'ServerMigrationService', 'ServiceCatalog', 'ServiceDiscovery', 'ServiceQuotas', 'Shield', 'SimpleEmail', 'SimpleEmailV2', 'SimpleNotificationService', 'SimpleSystemsManagement', 'SimpleWorkflow', 'SimSpaceWeaver', 'Snowball', 'SnowDeviceManagement', 'SQS', 'SSMContacts', 'SSMIncidents', 'SsmSap', 'SSO', 'SSOAdmin', 'SSOOIDC', 'StepFunctions', 'StorageGateway', 'SupportApp', 'Synthetics', 'Textract', 'TimestreamQuery', 'TimestreamWrite', 'Tnb', 'TranscribeService', 'Transfer', 'Translate', 'TrustedAdvisor', 'VerifiedPermissions', 'VoiceID', 'VPCLattice', 'WAF', 'WAFRegional', 'WAFV2', 'WellArchitected', 'WorkDocs', 'WorkLink', 'WorkMail', 'WorkMailMessageFlow', 'WorkSpaces', 'WorkSpacesThinClient', 'WorkSpacesWeb', 'XRay')

foreach ($project in $projectNameList)
{
    $projectDeploymentFolder = "$modularDeploymentFolder/AWS.Tools.$project"
    $projectFolder = "$serviceProjectsFolder/$project"
    dotnet $generatorAssemblyPath -rp $rootFolder -t formats -an AWS.Tools.$project -ml $projectFolder/$releaseBitPath -sdk $assembliesFolder
    If ($LASTEXITCODE){
      Throw "Formats Generator returned error $LASTEXITCODE for $project"
    }
    dotnet $generatorAssemblyPath -rp $rootFolder -t pshelp -an AWS.Tools.$project -ml $projectFolder/$releaseBitPath
    If ($LASTEXITCODE){
      Throw "PSHelp Generator returned error $LASTEXITCODE for $project"
    }
    New-Item -Path $projectDeploymentFolder -ItemType Directory
    foreach ($suffix in $moduleFilesSuffixes)
    {
        Copy-Item -Path "$projectFolder/AWS.Tools.$project$suffix" -Destination "$projectDeploymentFolder/AWS.Tools.$project$suffix"
    }
    foreach ($suffix in $binFilesSuffixes)
    {
        Copy-Item -Path "$projectFolder/$releaseBitPath/AWS.Tools.$project$suffix" -Destination "$projectDeploymentFolder/AWS.Tools.$project$suffix"
    }
    if ($project -ne 'SecurityToken')
    {
        Copy-Item -Path "$projectFolder/$releaseBitPath/AWSSDK.$project.dll" -Destination "$projectDeploymentFolder/AWSSDK.$project.dll"
    }

    Copy-Item -Path "$rootFolder/LICENSE" -Destination "$projectDeploymentFolder/LICENSE"
    Copy-Item -Path "$rootFolder/NOTICE" -Destination "$projectDeploymentFolder/NOTICE"
}

New-Item -Path "$modularDeploymentFolder/AWS.Tools.Installer" -ItemType Directory
Copy-Item -Path "$installerModuleFolder/AWS.Tools.Installer.psd1" -Destination "$modularDeploymentFolder/AWS.Tools.Installer/AWS.Tools.Installer.psd1"
Copy-Item -Path "$installerModuleFolder/AWS.Tools.Installer.psm1" -Destination "$modularDeploymentFolder/AWS.Tools.Installer/AWS.Tools.Installer.psm1"
