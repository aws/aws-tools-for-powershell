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
$nugetFolder = "$rootFolder/Include/sdk/nuget"

$moduleFilesSuffixes = @('.Completers.psm1', '.Aliases.psm1', '.psd1')
$binFilesSuffixes = @('.dll', '.XML', '.dll-Help.xml', '.Format.ps1xml')

If (Test-Path $modularDeploymentFolder)
{
    Remove-Item -Path $modularDeploymentFolder -Recurse
}
New-Item -Path $modularDeploymentFolder -ItemType Directory

dotnet $generatorAssemblyPath -rp $rootFolder -t formats -an AWS.Tools.Common -ml $commonModuleFolder/$releaseBitPath -sdk $nugetFolder
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

$projectNameList = @('ACMPCA', 'AlexaForBusiness', 'Amplify', 'APIGateway', 'ApiGatewayManagementApi', 'ApiGatewayV2', 'ApplicationAutoScaling', 'ApplicationDiscoveryService', 'ApplicationInsights', 'AppMesh', 'AppStream', 'AppSync', 'Athena', 'AutoScaling', 'AutoScalingPlans', 'AWSHealth', 'AWSMarketplaceCommerceAnalytics', 'AWSMarketplaceMetering', 'AWSSupport', 'Backup', 'Batch', 'Budgets', 'CertificateManager', 'Chime', 'Cloud9', 'CloudDirectory', 'CloudFormation', 'CloudFront', 'CloudHSMV2', 'CloudSearch', 'CloudSearchDomain', 'CloudTrail', 'CloudWatch', 'CloudWatchLogs', 'CodeBuild', 'CodeCommit', 'CodeDeploy', 'CodePipeline', 'CodeStar', 'CodeStarNotifications', 'CognitoIdentity', 'CognitoIdentityProvider', 'CognitoSync', 'Comprehend', 'ComprehendMedical', 'ConfigService', 'Connect', 'ConnectParticipant', 'CostAndUsageReport', 'CostExplorer', 'DatabaseMigrationService', 'DataExchange', 'DataPipeline', 'DataSync', 'DAX', 'DeviceFarm', 'DirectConnect', 'DirectoryService', 'DLM', 'DocDB', 'DynamoDBv2', 'EC2', 'ECR', 'ECS', 'EKS', 'ElastiCache', 'ElasticBeanstalk', 'ElasticFileSystem', 'ElasticLoadBalancing', 'ElasticLoadBalancingV2', 'ElasticMapReduce', 'Elasticsearch', 'ElasticTranscoder', 'EventBridge', 'FMS', 'ForecastQueryService', 'ForecastService', 'FSx', 'GameLift', 'Glacier', 'GlobalAccelerator', 'Glue', 'Greengrass', 'GroundStation', 'GuardDuty', 'IdentityManagement', 'ImportExport', 'Inspector', 'IoT', 'IoTEvents', 'IoTEventsData', 'IoTJobsDataPlane', 'IoTThingsGraph', 'Kafka', 'KeyManagementService', 'Kinesis', 'KinesisAnalyticsV2', 'KinesisFirehose', 'KinesisVideo', 'KinesisVideoMedia', 'LakeFormation', 'Lambda', 'Lex', 'LexModelBuildingService', 'LicenseManager', 'Lightsail', 'MachineLearning', 'Macie', 'ManagedBlockchain', 'MarketplaceCatalog', 'MarketplaceEntitlementService', 'MediaConnect', 'MediaConvert', 'MediaLive', 'MediaPackage', 'MediaPackageVod', 'MediaStore', 'MediaStoreData', 'MediaTailor', 'MigrationHub', 'MigrationHubConfig', 'Mobile', 'MQ', 'MTurk', 'Neptune', 'OpsWorks', 'OpsWorksCM', 'Organizations', 'Personalize', 'PersonalizeEvents', 'PersonalizeRuntime', 'PI', 'Pinpoint', 'PinpointEmail', 'Polly', 'Pricing', 'QLDB', 'QLDBSession', 'QuickSight', 'RAM', 'RDS', 'RDSDataService', 'Redshift', 'Rekognition', 'ResourceGroups', 'ResourceGroupsTaggingAPI', 'RoboMaker', 'Route53', 'Route53Domains', 'Route53Resolver', 'S3', 'S3Control', 'SageMaker', 'SageMakerRuntime', 'SavingsPlans', 'SecretsManager', 'SecurityHub', 'SecurityToken', 'ServerlessApplicationRepository', 'ServerMigrationService', 'ServiceCatalog', 'ServiceDiscovery', 'ServiceQuotas', 'Shield', 'SimpleEmail', 'SimpleEmailV2', 'SimpleNotificationService', 'SimpleSystemsManagement', 'SimpleWorkflow', 'Snowball', 'SQS', 'SSO', 'SSOOIDC', 'StepFunctions', 'StorageGateway', 'Textract', 'TranscribeService', 'Transfer', 'Translate', 'WAF', 'WAFRegional', 'WorkDocs', 'WorkLink', 'WorkMail', 'WorkMailMessageFlow', 'WorkSpaces', 'XRay')

foreach ($project in $projectNameList)
{
    $projectDeploymentFolder = "$modularDeploymentFolder/AWS.Tools.$project"
    $projectFolder = "$serviceProjectsFolder/$project"
    dotnet $generatorAssemblyPath -rp $rootFolder -t formats -an AWS.Tools.$project -ml $projectFolder/$releaseBitPath -sdk $nugetFolder
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
