param (
    [string]$rootFolder,
    [string]$configuration
)

$ErrorActionPreference = "Stop"

$releaseBitPath = "bin/$configuration/netstandard2.0"

$generatorAssemblyPath ="$rootFolder/generator/AWSPSGenerator/bin/$configuration/net8.0/AWSPSGenerator.dll"
$modularDeploymentFolder = "$rootFolder/Deployment/AWS.Tools"
$commonModuleFolder = "$rootFolder/modules/ModularAWSPowerShell"
$installerModuleFolder = "$rootFolder/modules/Installer"
$monolithicModuleFolder = "$rootFolder/modules/AWSPowerShell"
$serviceProjectsFolder = "$monolithicModuleFolder/Cmdlets"
$assembliesFolder = "$rootFolder/Include/sdk/assemblies"

$moduleFilesSuffixes = @('.Completers.psm1', '.Aliases.psm1', '.psd1')
$binFilesSuffixes = @('.dll', '.XML', '.dll-Help.xml', '.Format.ps1xml')

$transitiveDependencies = @('BouncyCastle.Cryptography.dll','Microsoft.Bcl.AsyncInterfaces.dll','Microsoft.Bcl.HashCode.dll','System.Buffers.dll','System.Memory.dll','System.Numerics.Vectors.dll','System.Runtime.CompilerServices.Unsafe.dll','System.Text.Json.dll','System.Threading.Tasks.Extensions.dll','System.Text.Encodings.Web.dll','System.Formats.Cbor.dll','AWSSDK.Extensions.CborProtocol.dll')

$serviceTransitiveDependencies = @{
    Signin = @('BouncyCastle.Cryptography.dll')
}

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
foreach($transitiveDependency in $transitiveDependencies){
  Copy-Item -Path "$assembliesFolder/netstandard2.0/$transitiveDependency" -Destination "$modularDeploymentFolder/AWS.Tools.Common/"
}
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.Core.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.Core.dll"
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.SecurityToken.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.SecurityToken.dll"
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.SSOOIDC.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.SSOOIDC.dll"
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.SSO.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.SSO.dll"
Copy-Item -Path "$commonModuleFolder/$releaseBitPath/AWSSDK.Signin.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.Signin.dll"
Copy-Item -Path "$monolithicModuleFolder/ImportGuard.ps1" -Destination "$modularDeploymentFolder/AWS.Tools.Common/ImportGuard.ps1"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt-auth.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt-auth.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt-http.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt-http.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/aws-crt-checksums.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/aws-crt-checksums.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/AWSSDK.Extensions.CrtIntegration.dll" -Destination "$modularDeploymentFolder/AWS.Tools.Common/AWSSDK.Extensions.CrtIntegration.dll"
Copy-Item -Path "$rootFolder/LICENSE" -Destination "$modularDeploymentFolder/AWS.Tools.Common/LICENSE"
Copy-Item -Path "$rootFolder/NOTICE" -Destination "$modularDeploymentFolder/AWS.Tools.Common/NOTICE"

$projectNameList = @('AccessAnalyzer', 'Account', 'ACMPCA', 'AIOps', 'Amplify', 'AmplifyBackend', 'AmplifyUIBuilder', 'APIGateway', 'ApiGatewayManagementApi', 'ApiGatewayV2', 'AppConfig', 'AppConfigData', 'AppFabric', 'Appflow', 'AppIntegrationsService', 'ApplicationAutoScaling', 'ApplicationCostProfiler', 'ApplicationDiscoveryService', 'ApplicationInsights', 'ApplicationSignals', 'AppMesh', 'AppRegistry', 'AppRunner', 'AppStream', 'AppSync', 'ARCRegionswitch', 'ARCZonalShift', 'Artifact', 'Athena', 'AuditManager', 'AugmentedAIRuntime', 'AutoScaling', 'AutoScalingPlans', 'AWSHealth', 'AWSMarketplaceCommerceAnalytics', 'AWSMarketplaceMetering', 'AWSSupport', 'B2bi', 'Backup', 'BackupGateway', 'BackupSearch', 'Batch', 'BCMDashboards', 'BCMDataExports', 'BCMPricingCalculator', 'BCMRecommendedActions', 'Bedrock', 'BedrockAgent', 'BedrockAgentCore', 'BedrockAgentCoreControl', 'BedrockAgentRuntime', 'BedrockDataAutomation', 'BedrockDataAutomationRuntime', 'BedrockRuntime', 'Billing', 'BillingConductor', 'Braket', 'Budgets', 'CertificateManager', 'Chatbot', 'Chime', 'ChimeSDKIdentity', 'ChimeSDKMediaPipelines', 'ChimeSDKMeetings', 'ChimeSDKMessaging', 'ChimeSDKVoice', 'CleanRooms', 'CleanRoomsML', 'Cloud9', 'CloudControlApi', 'CloudDirectory', 'CloudFormation', 'CloudFront', 'CloudFrontKeyValueStore', 'CloudHSMV2', 'CloudSearch', 'CloudSearchDomain', 'CloudTrail', 'CloudTrailData', 'CloudWatch', 'CloudWatchEvidently', 'CloudWatchLogs', 'CloudWatchRUM', 'CodeArtifact', 'CodeBuild', 'CodeCatalyst', 'CodeCommit', 'CodeConnections', 'CodeDeploy', 'CodeGuruProfiler', 'CodeGuruReviewer', 'CodeGuruSecurity', 'CodePipeline', 'CodeStarconnections', 'CodeStarNotifications', 'CognitoIdentity', 'CognitoIdentityProvider', 'CognitoSync', 'Comprehend', 'ComprehendMedical', 'ComputeOptimizer', 'ConfigService', 'Connect', 'ConnectCampaignService', 'ConnectCampaignsV2', 'ConnectCases', 'ConnectContactLens', 'ConnectParticipant', 'ConnectWisdomService', 'ControlCatalog', 'ControlTower', 'CostAndUsageReport', 'CostExplorer', 'CostOptimizationHub', 'CustomerProfiles', 'DatabaseMigrationService', 'DataExchange', 'DataPipeline', 'DataSync', 'DataZone', 'DAX', 'Deadline', 'Detective', 'DeviceFarm', 'DevOpsGuru', 'DirectConnect', 'DirectoryService', 'DirectoryServiceData', 'DLM', 'DocDB', 'DocDBElastic', 'Drs', 'DSQL', 'DynamoDBStreams', 'DynamoDBv2', 'EBS', 'EC2', 'EC2InstanceConnect', 'ECR', 'ECRPublic', 'ECS', 'EKS', 'EKSAuth', 'ElastiCache', 'ElasticBeanstalk', 'ElasticFileSystem', 'ElasticLoadBalancing', 'ElasticLoadBalancingV2', 'ElasticMapReduce', 'Elasticsearch', 'ElasticTranscoder', 'EMRContainers', 'EMRServerless', 'EntityResolution', 'EventBridge', 'Evs', 'Finspace', 'FinSpaceData', 'FIS', 'FMS', 'ForecastQueryService', 'ForecastService', 'FraudDetector', 'FreeTier', 'FSx', 'GameLift', 'GameLiftStreams', 'GeoMaps', 'GeoPlaces', 'GeoRoutes', 'Glacier', 'GlobalAccelerator', 'Glue', 'GlueDataBrew', 'Greengrass', 'GreengrassV2', 'GroundStation', 'GuardDuty', 'HealthLake', 'IAMRolesAnywhere', 'IdentityManagement', 'IdentityStore', 'Imagebuilder', 'ImportExport', 'Inspector', 'Inspector2', 'InspectorScan', 'InternetMonitor', 'Invoicing', 'IoT', 'IoTDeviceAdvisor', 'IoTEvents', 'IoTEventsData', 'IoTFleetWise', 'IoTJobsDataPlane', 'IoTManagedIntegrations', 'IoTSecureTunneling', 'IoTSiteWise', 'IoTThingsGraph', 'IoTTwinMaker', 'IoTWireless', 'IVS', 'Ivschat', 'IVSRealTime', 'Kafka', 'KafkaConnect', 'Kendra', 'KendraRanking', 'KeyManagementService', 'Keyspaces', 'KeyspacesStreams', 'Kinesis', 'KinesisAnalyticsV2', 'KinesisFirehose', 'KinesisVideo', 'KinesisVideoMedia', 'KinesisVideoSignalingChannels', 'KinesisVideoWebRTCStorage', 'LakeFormation', 'Lambda', 'LaunchWizard', 'Lex', 'LexModelBuildingService', 'LexModelsV2', 'LexRuntimeV2', 'LicenseManager', 'LicenseManagerLinuxSubscriptions', 'LicenseManagerUserSubscriptions', 'Lightsail', 'LocationService', 'LookoutEquipment', 'MachineLearning', 'Macie2', 'MailManager', 'MainframeModernization', 'ManagedBlockchain', 'ManagedBlockchainQuery', 'ManagedGrafana', 'MarketplaceAgreement', 'MarketplaceCatalog', 'MarketplaceDeployment', 'MarketplaceEntitlementService', 'MarketplaceReporting', 'MediaConnect', 'MediaConvert', 'MediaLive', 'MediaPackage', 'MediaPackageV2', 'MediaPackageVod', 'MediaStore', 'MediaStoreData', 'MediaTailor', 'MedicalImaging', 'MemoryDB', 'Mgn', 'MigrationHub', 'MigrationHubConfig', 'MigrationHubOrchestrator', 'MigrationHubRefactorSpaces', 'MigrationHubStrategyRecommendations', 'MPA', 'MQ', 'MTurk', 'MWAA', 'MWAAServerless', 'Neptune', 'Neptunedata', 'NeptuneGraph', 'NetworkFirewall', 'NetworkFlowMonitor', 'NetworkManager', 'NetworkMonitor', 'Notifications', 'NotificationsContacts', 'OAM', 'ObservabilityAdmin', 'Odb', 'Omics', 'OpenSearchServerless', 'OpenSearchService', 'Organizations', 'OSIS', 'Outposts', 'Panorama', 'PartnerCentralChannel', 'PartnerCentralSelling', 'PaymentCryptography', 'PaymentCryptographyData', 'PcaConnectorAd', 'PcaConnectorScep', 'PCS', 'Personalize', 'PersonalizeEvents', 'PersonalizeRuntime', 'PI', 'Pinpoint', 'PinpointEmail', 'PinpointSMSVoiceV2', 'Pipes', 'Polly', 'Pricing', 'PrometheusService', 'Proton', 'QApps', 'QBusiness', 'QConnect', 'QuickSight', 'RAM', 'RDS', 'RDSDataService', 'RecycleBin', 'Redshift', 'RedshiftDataAPIService', 'RedshiftServerless', 'Rekognition', 'Repostspace', 'ResilienceHub', 'ResourceExplorer2', 'ResourceGroups', 'ResourceGroupsTaggingAPI', 'Route53', 'Route53Domains', 'Route53Profiles', 'Route53RecoveryCluster', 'Route53RecoveryControlConfig', 'Route53RecoveryReadiness', 'Route53Resolver', 'RTBFabric', 'S3', 'S3Control', 'S3Outposts', 'S3Tables', 'S3Vectors', 'SageMaker', 'SagemakerEdgeManager', 'SageMakerFeatureStoreRuntime', 'SageMakerGeospatial', 'SageMakerMetrics', 'SageMakerRuntime', 'SavingsPlans', 'Scheduler', 'Schemas', 'SecretsManager', 'SecurityHub', 'SecurityIR', 'SecurityLake', 'SecurityToken', 'ServerlessApplicationRepository', 'ServiceCatalog', 'ServiceDiscovery', 'ServiceQuotas', 'Shield', 'Signin', 'SimpleEmail', 'SimpleEmailV2', 'SimpleNotificationService', 'SimpleSystemsManagement', 'SimpleWorkflow', 'SimSpaceWeaver', 'Snowball', 'SnowDeviceManagement', 'SocialMessaging', 'SQS', 'SSMContacts', 'SSMGuiConnect', 'SSMIncidents', 'SSMQuickSetup', 'SsmSap', 'SSO', 'SSOAdmin', 'SSOOIDC', 'StepFunctions', 'StorageGateway', 'SupplyChain', 'SupportApp', 'Synthetics', 'TaxSettings', 'Textract', 'TimestreamInfluxDB', 'TimestreamQuery', 'TimestreamWrite', 'Tnb', 'TranscribeService', 'Transfer', 'Translate', 'TrustedAdvisor', 'VerifiedPermissions', 'VoiceID', 'VPCLattice', 'WAF', 'WAFRegional', 'WAFV2', 'WellArchitected', 'WorkDocs', 'WorkMail', 'WorkMailMessageFlow', 'WorkSpaces', 'WorkspacesInstances', 'WorkSpacesThinClient', 'WorkSpacesWeb', 'XRay')

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

    if ($serviceTransitiveDependencies -ne $null -and $serviceTransitiveDependencies.ContainsKey($project))
    {
        if ($serviceTransitiveDependencies[$project] -ne $null)
        {
            foreach ($transitiveDependency in $serviceTransitiveDependencies[$project])
            {
                if (Test-Path -Path "$assembliesFolder/netstandard2.0/$transitiveDependency" -PathType Leaf)
                {
                    Copy-Item -Path "$assembliesFolder/netstandard2.0/$transitiveDependency" -Destination "$projectDeploymentFolder/"
                }
            }
        }
    }

    Copy-Item -Path "$rootFolder/LICENSE" -Destination "$projectDeploymentFolder/LICENSE"
    Copy-Item -Path "$rootFolder/NOTICE" -Destination "$projectDeploymentFolder/NOTICE"
}

Copy-Item -Path "$assembliesFolder/netstandard2.0/AWSSDK.Extensions.CloudFront.Signers.dll" -Destination "$modularDeploymentFolder/AWS.Tools.CloudFront/AWSSDK.Extensions.CloudFront.Signers.dll"
Copy-Item -Path "$assembliesFolder/netstandard2.0/AWSSDK.Extensions.EC2.DecryptPassword.dll" -Destination "$modularDeploymentFolder/AWS.Tools.EC2/AWSSDK.Extensions.EC2.DecryptPassword.dll"

New-Item -Path "$modularDeploymentFolder/AWS.Tools.Installer" -ItemType Directory
Copy-Item -Path "$installerModuleFolder/AWS.Tools.Installer.psd1" -Destination "$modularDeploymentFolder/AWS.Tools.Installer/AWS.Tools.Installer.psd1"
Copy-Item -Path "$installerModuleFolder/AWS.Tools.Installer.psm1" -Destination "$modularDeploymentFolder/AWS.Tools.Installer/AWS.Tools.Installer.psm1"
