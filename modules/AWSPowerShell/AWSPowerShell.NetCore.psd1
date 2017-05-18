#
# Module manifest for module 'AWSPowerShell.NetCore'
#

@{

# Script module or binary module file associated with this manifest
ModuleToProcess = 'AWSPowerShell.NetCore.dll'

CompatiblePSEditions = @('Core')

# Version number of this module.
ModuleVersion = '3.0.0.0'

# ID used to uniquely identify this module
GUID = 'cb0b9b96-f3f2-4eff-b7f4-cbe0a9203683'

# Author of this module
Author = 'Amazon.com, Inc'

# Company or vendor of this module
CompanyName = 'Amazon.com, Inc'

# Copyright statement for this module
Copyright = 'Copyright 2012-2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

# Description of the functionality provided by this module
Description = 'The AWS Tools for PowerShell Core lets developers and administrators manage their AWS services from the PowerShell Core scripting environment.'

# Minimum version of the PowerShell engine required by this module
PowerShellVersion = ''

# Name of the PowerShell host required by this module
PowerShellHostName = ''

# Minimum version of the PowerShell host required by this module
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
  "AWSSDK.APIGateway.dll",
  "AWSSDK.ApplicationAutoScaling.dll",
  "AWSSDK.ApplicationDiscoveryService.dll",
  "AWSSDK.AppStream.dll",
  "AWSSDK.AutoScaling.dll",
  "AWSSDK.AWSHealth.dll",
  "AWSSDK.AWSMarketplaceCommerceAnalytics.dll",
  "AWSSDK.AWSMarketplaceMetering.dll",
  "AWSSDK.AWSSupport.dll",
  "AWSSDK.Batch.dll",
  "AWSSDK.Budgets.dll",
  "AWSSDK.CertificateManager.dll",
  "AWSSDK.CloudDirectory.dll",
  "AWSSDK.CloudFormation.dll",
  "AWSSDK.CloudFront.dll",
  "AWSSDK.CloudHSM.dll",
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
  "AWSSDK.ConfigService.dll",
  "AWSSDK.Core.dll",
  "AWSSDK.CostAndUsageReport.dll",
  "AWSSDK.DatabaseMigrationService.dll",
  "AWSSDK.DataPipeline.dll",
  "AWSSDK.DeviceFarm.dll",
  "AWSSDK.DirectConnect.dll",
  "AWSSDK.DirectoryService.dll",
  "AWSSDK.DynamoDBv2.dll",
  "AWSSDK.EC2.dll",
  "AWSSDK.ECR.dll",
  "AWSSDK.ECS.dll",
  "AWSSDK.ElastiCache.dll",
  "AWSSDK.ElasticBeanstalk.dll",
  "AWSSDK.ElasticFileSystem.dll",
  "AWSSDK.ElasticLoadBalancing.dll",
  "AWSSDK.ElasticLoadBalancingV2.dll",
  "AWSSDK.ElasticMapReduce.dll",
  "AWSSDK.Elasticsearch.dll",
  "AWSSDK.ElasticTranscoder.dll",
  "AWSSDK.GameLift.dll",
  "AWSSDK.IdentityManagement.dll",
  "AWSSDK.ImportExport.dll",
  "AWSSDK.Inspector.dll",
  "AWSSDK.IoT.dll",
  "AWSSDK.KeyManagementService.dll",
  "AWSSDK.Kinesis.dll",
  "AWSSDK.KinesisAnalytics.dll",
  "AWSSDK.KinesisFirehose.dll",
  "AWSSDK.Lambda.dll",
  "AWSSDK.Lex.dll",
  "AWSSDK.LexModelBuildingService.dll",
  "AWSSDK.Lightsail.dll",
  "AWSSDK.MachineLearning.dll",
  "AWSSDK.MarketplaceEntitlementService.dll",
  "AWSSDK.MTurk.dll",
  "AWSSDK.OpsWorks.dll",
  "AWSSDK.OpsWorksCM.dll",
  "AWSSDK.Organizations.dll",
  "AWSSDK.Pinpoint.dll",
  "AWSSDK.Polly.dll",
  "AWSSDK.RDS.dll",
  "AWSSDK.Redshift.dll",
  "AWSSDK.Rekognition.dll",
  "AWSSDK.ResourceGroupsTaggingAPI.dll",
  "AWSSDK.Route53.dll",
  "AWSSDK.Route53Domains.dll",
  "AWSSDK.S3.dll",
  "AWSSDK.SecurityToken.dll",
  "AWSSDK.ServerMigrationService.dll",
  "AWSSDK.ServiceCatalog.dll",
  "AWSSDK.Shield.dll",
  "AWSSDK.SimpleEmail.dll",
  "AWSSDK.SimpleNotificationService.dll",
  "AWSSDK.SimpleSystemsManagement.dll",
  "AWSSDK.Snowball.dll",
  "AWSSDK.SQS.dll",
  "AWSSDK.StepFunctions.dll",
  "AWSSDK.StorageGateway.dll",
  "AWSSDK.WAF.dll",
  "AWSSDK.WAFRegional.dll",
  "AWSSDK.WorkDocs.dll",
  "AWSSDK.WorkSpaces.dll",
  "AWSSDK.XRay.dll"
)

# Script files (.ps1) that are run in the caller's environment prior to importing this module
ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
TypesToProcess = @('AWSPowerShell.TypeExtensions.ps1xml')

# Format files (.ps1xml) to be loaded when importing this module
FormatsToProcess = @('AWSPowerShell.Format.ps1xml')

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
  "Get-SSMParameterNameList"
)

# List of all modules packaged with this module
ModuleList = @()

# List of all files packaged with this module
FileList = @(
  'AWSPowerShell.NetCore.dll-Help.xml',
  'CHANGELOG.md'
)  

# Private data to pass to the module specified in ModuleToProcess
PrivateData = @{

    PSData = @{
		Tags = 'AWS'
        LicenseUri = 'http://docs.aws.amazon.com/powershell/latest/reference/License.html'
        ProjectUri = 'http://aws.amazon.com/powershell/'
    }

}

}
