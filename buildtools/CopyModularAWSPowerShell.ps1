param (
    [string]$rootFolder,
    [string]$configuration
)

$ErrorActionPreference = "Stop"

$releaseBitPath = "bin/$configuration/netstandard2.0"

$generatorAssemblyPath ="$rootFolder/generator/AWSPSGenerator/bin/$configuration/netcoreapp2.1/AWSPSGenerator.dll"
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

$projectNameList = @('AccessAnalyzer', 'ACMPCA', 'AlexaForBusiness', 'Amplify', 'APIGateway', 'ApiGatewayManagementApi', 'ApiGatewayV2', 'AppConfig', 'Appflow', 'ApplicationAutoScaling', 'ApplicationDiscoveryService', 'ApplicationInsights', 'AppMesh', 'AppStream', 'AppSync', 'Athena', 'AugmentedAIRuntime', 'AutoScaling', 'AutoScalingPlans', 'AWSHealth', 'AWSMarketplaceCommerceAnalytics', 'AWSMarketplaceMetering', 'AWSSupport', 'Backup', 'Batch', 'Braket', 'Budgets', 'CertificateManager', 'Chime', 'Cloud9', 'CloudDirectory', 'CloudFormation', 'CloudFront', 'CloudHSMV2', 'CloudSearch', 'CloudSearchDomain', 'CloudTrail', 'CloudWatch', 'CloudWatchLogs', 'CodeArtifact', 'CodeBuild', 'CodeCommit', 'CodeDeploy', 'CodeGuruProfiler', 'CodeGuruReviewer', 'CodePipeline', 'CodeStar', 'CodeStarconnections', 'CodeStarNotifications', 'CognitoIdentity', 'CognitoIdentityProvider', 'CognitoSync', 'Comprehend', 'ComprehendMedical', 'ComputeOptimizer', 'ConfigService', 'Connect', 'ConnectParticipant', 'CostAndUsageReport', 'CostExplorer', 'DatabaseMigrationService', 'DataExchange', 'DataPipeline', 'DataSync', 'DAX', 'Detective', 'DeviceFarm', 'DirectConnect', 'DirectoryService', 'DLM', 'DocDB', 'DynamoDBv2', 'EBS', 'EC2', 'ECR', 'ECS', 'EKS', 'ElastiCache', 'ElasticBeanstalk', 'ElasticFileSystem', 'ElasticInference', 'ElasticLoadBalancing', 'ElasticLoadBalancingV2', 'ElasticMapReduce', 'Elasticsearch', 'ElasticTranscoder', 'EventBridge', 'FMS', 'ForecastQueryService', 'ForecastService', 'FraudDetector', 'FSx', 'GameLift', 'Glacier', 'GlobalAccelerator', 'Glue', 'Greengrass', 'GroundStation', 'GuardDuty', 'IdentityManagement', 'Imagebuilder', 'ImportExport', 'Inspector', 'IoT', 'IoTEvents', 'IoTEventsData', 'IoTJobsDataPlane', 'IoTSecureTunneling', 'IoTSiteWise', 'IoTThingsGraph', 'IVS', 'Kafka', 'Kendra', 'KeyManagementService', 'Kinesis', 'KinesisAnalyticsV2', 'KinesisFirehose', 'KinesisVideo', 'KinesisVideoMedia', 'KinesisVideoSignalingChannels', 'LakeFormation', 'Lambda', 'Lex', 'LexModelBuildingService', 'LicenseManager', 'Lightsail', 'MachineLearning', 'Macie', 'Macie2', 'ManagedBlockchain', 'MarketplaceCatalog', 'MarketplaceEntitlementService', 'MediaConnect', 'MediaConvert', 'MediaLive', 'MediaPackage', 'MediaPackageVod', 'MediaStore', 'MediaStoreData', 'MediaTailor', 'MigrationHub', 'MigrationHubConfig', 'Mobile', 'MQ', 'MTurk', 'Neptune', 'NetworkManager', 'OpsWorks', 'OpsWorksCM', 'Organizations', 'Outposts', 'Personalize', 'PersonalizeEvents', 'PersonalizeRuntime', 'PI', 'Pinpoint', 'PinpointEmail', 'Polly', 'Pricing', 'QLDB', 'QLDBSession', 'QuickSight', 'RAM', 'RDS', 'RDSDataService', 'Redshift', 'RedshiftDataAPIService', 'Rekognition', 'ResourceGroups', 'ResourceGroupsTaggingAPI', 'RoboMaker', 'Route53', 'Route53Domains', 'Route53Resolver', 'S3', 'S3Control', 'S3Outposts', 'SageMaker', 'SageMakerRuntime', 'SavingsPlans', 'SecretsManager', 'SecurityHub', 'SecurityToken', 'ServerlessApplicationRepository', 'ServerMigrationService', 'ServiceCatalog', 'ServiceDiscovery', 'ServiceQuotas', 'Shield', 'SimpleEmail', 'SimpleEmailV2', 'SimpleNotificationService', 'SimpleSystemsManagement', 'SimpleWorkflow', 'Snowball', 'SQS', 'SSO', 'SSOOIDC', 'StepFunctions', 'StorageGateway', 'Synthetics', 'Textract', 'TranscribeService', 'Transfer', 'Translate', 'WAF', 'WAFRegional', 'WAFV2', 'WorkDocs', 'WorkLink', 'WorkMail', 'WorkMailMessageFlow', 'WorkSpaces', 'XRay')

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
}

New-Item -Path "$modularDeploymentFolder/AWS.Tools.Installer" -ItemType Directory
Copy-Item -Path "$installerModuleFolder/AWS.Tools.Installer.psd1" -Destination "$modularDeploymentFolder/AWS.Tools.Installer/AWS.Tools.Installer.psd1"
Copy-Item -Path "$installerModuleFolder/AWS.Tools.Installer.psm1" -Destination "$modularDeploymentFolder/AWS.Tools.Installer/AWS.Tools.Installer.psm1"
