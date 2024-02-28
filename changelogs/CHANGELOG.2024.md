### 4.1.526 (2024-02-28 21:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.758.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameters EcsProperties_TaskProperty, PodProperties_InitContainer and PodProperties_ShareProcessNamespace.
    * Modified cmdlet Submit-BATJob: added parameters EcsPropertiesOverride_TaskProperty and PodProperties_InitContainer.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieve: added parameter VectorSearchConfiguration_OverrideSearchType.
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters VectorSearchConfiguration_NumberOfResult and VectorSearchConfiguration_OverrideSearchType.
  * Amazon Cost Explorer
    * Added cmdlet Get-CEApproximateUsageRecord leveraging the GetApproximateUsageRecords service API.

### 4.1.525 (2024-02-27 21:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.757.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify UI Builder
    * Added cmdlet Add-AMPUIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AMPUIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-AMPUIResourceTag leveraging the UntagResource service API.

### 4.1.524 (2024-02-26 21:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.756.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Managed Streaming for Kafka Connect
    * Added cmdlet Add-MSKCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-MSKCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-MSKCResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-MSKCWorkerConfiguration leveraging the DeleteWorkerConfiguration service API.
    * Modified cmdlet Get-MSKCCustomPluginList: added parameters NamePrefix and PassThru.
    * Modified cmdlet Get-MSKCWorkerConfigurationList: added parameters NamePrefix and PassThru.
    * Modified cmdlet New-MSKCConnector: added parameter Tag.
    * Modified cmdlet New-MSKCCustomPlugin: added parameter Tag.
    * Modified cmdlet New-MSKCWorkerConfiguration: added parameter Tag.

### 4.1.523 (2024-02-23 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.755.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.522 (2024-02-22 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.754.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.521 (2024-02-21 21:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.753.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaLive
    * Added cmdlet Restart-EMLChannelPipeline leveraging the RestartChannelPipelines service API.
  * Amazon Systems Manager
    * Modified cmdlet Get-SSMParameterList: added parameter Shared.

### 4.1.520 (2024-02-20 21:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.752.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * KINF
    * [Breaking Change] Removed cmdlets Get-KINFKinesisStream and Test-KINFResourcesExistForTagris.

### 4.1.519 (2024-02-19 21:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.751.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet New-AMPDomainAssociation: added parameters CertificateSettings_CustomCertificateArn and CertificateSettings_Type.
    * Modified cmdlet Update-AMPDomainAssociation: added parameters CertificateSettings_CustomCertificateArn and CertificateSettings_Type.
  * Amazon Chatbot. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CHAT and can be listed using the command 'Get-AWSCmdletName -Service CHAT'.

### 4.1.518 (2024-02-16 21:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.750.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic MapReduce
    * Added cmdlet Set-EMRUnhealthyNodeReplacement leveraging the SetUnhealthyNodeReplacement service API.
    * Modified cmdlet Start-EMRJobFlow: added parameter Instances_UnhealthyNodeReplacement.
  * Amazon Kinesis Firehose
    * Added cmdlet Get-KINFKinesisStream leveraging the GetKinesisStream service API.
    * Added cmdlet Test-KINFResourcesExistForTagris leveraging the VerifyResourcesExistForTagris service API.

### 4.1.517 (2024-02-15 22:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.749.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Artifact. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ART and can be listed using the command 'Get-AWSCmdletName -Service ART'.
  * Amazon SageMaker Service
    * Added cmdlet Update-SMClusterSoftware leveraging the UpdateClusterSoftware service API.

### 4.1.516 (2024-02-14 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.748.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Tower
    * Added cmdlet Disable-ACTBaseline leveraging the DisableBaseline service API.
    * Added cmdlet Enable-ACTBaseline leveraging the EnableBaseline service API.
    * Added cmdlet Get-ACTBaseline leveraging the GetBaseline service API.
    * Added cmdlet Get-ACTBaselineList leveraging the ListBaselines service API.
    * Added cmdlet Get-ACTBaselineOperation leveraging the GetBaselineOperation service API.
    * Added cmdlet Get-ACTEnabledBaseline leveraging the GetEnabledBaseline service API.
    * Added cmdlet Get-ACTEnabledBaselineList leveraging the ListEnabledBaselines service API.
    * Added cmdlet Reset-ACTEnabledBaseline leveraging the ResetEnabledBaseline service API.
    * Added cmdlet Update-ACTEnabledBaseline leveraging the UpdateEnabledBaseline service API.
  * Amazon Lookout for Equipment
    * Modified cmdlet New-L4EModel: added parameters ModelDiagnosticsOutputConfiguration_KmsKeyId, S3OutputConfiguration_Bucket and S3OutputConfiguration_Prefix.
    * Modified cmdlet Update-L4EModel: added parameters ModelDiagnosticsOutputConfiguration_KmsKeyId, S3OutputConfiguration_Bucket and S3OutputConfiguration_Prefix.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSRetriever: added parameter NativeIndexConfiguration_BoostingOverride.
    * Modified cmdlet Update-QBUSRetriever: added parameter NativeIndexConfiguration_BoostingOverride.

### 4.1.515 (2024-02-13 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.747.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Lightsail
    * Modified cmdlet Update-LSRelationalDatabase: added parameter RelationalDatabaseBlueprintId.
  * Amazon Marketplace Catalog Service
    * Modified cmdlet Start-MCATChangeSet: added parameter Intent.

### 4.1.514 (2024-02-12 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.746.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Modified cmdlet New-ASYNApiCache: added parameter HealthMetricsConfig.
    * Modified cmdlet New-ASYNDataSource: added parameter MetricsConfig.
    * Modified cmdlet New-ASYNGraphqlApi: added parameters EnhancedMetricsConfig_DataSourceLevelMetricsBehavior, EnhancedMetricsConfig_OperationLevelMetricsConfig and EnhancedMetricsConfig_ResolverLevelMetricsBehavior.
    * Modified cmdlet New-ASYNResolver: added parameter MetricsConfig.
    * Modified cmdlet Update-ASYNApiCache: added parameter HealthMetricsConfig.
    * Modified cmdlet Update-ASYNDataSource: added parameter MetricsConfig.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameters EnhancedMetricsConfig_DataSourceLevelMetricsBehavior, EnhancedMetricsConfig_OperationLevelMetricsConfig and EnhancedMetricsConfig_ResolverLevelMetricsBehavior.
    * Modified cmdlet Update-ASYNResolver: added parameter MetricsConfig.
  * Amazon Neptune Graph
    * Modified cmdlet Invoke-NEPTGQuery: added parameter Parameter.
  * Amazon Route 53 Domains
    * Modified cmdlet Invoke-R53DDomainTransfer: added parameters BillingContact_AddressLine1, BillingContact_AddressLine2, BillingContact_City, BillingContact_ContactType, BillingContact_CountryCode, BillingContact_Email, BillingContact_ExtraParam, BillingContact_Fax, BillingContact_FirstName, BillingContact_LastName, BillingContact_OrganizationName, BillingContact_PhoneNumber, BillingContact_State, BillingContact_ZipCode and PrivacyProtectBillingContact.
    * Modified cmdlet Register-R53DDomain: added parameters BillingContact_AddressLine1, BillingContact_AddressLine2, BillingContact_City, BillingContact_ContactType, BillingContact_CountryCode, BillingContact_Email, BillingContact_ExtraParam, BillingContact_Fax, BillingContact_FirstName, BillingContact_LastName, BillingContact_OrganizationName, BillingContact_PhoneNumber, BillingContact_State, BillingContact_ZipCode and PrivacyProtectBillingContact.
    * Modified cmdlet Update-R53DDomainContact: added parameters BillingContact_AddressLine1, BillingContact_AddressLine2, BillingContact_City, BillingContact_ContactType, BillingContact_CountryCode, BillingContact_Email, BillingContact_ExtraParam, BillingContact_Fax, BillingContact_FirstName, BillingContact_LastName, BillingContact_OrganizationName, BillingContact_PhoneNumber, BillingContact_State and BillingContact_ZipCode.
    * Modified cmdlet Update-R53DDomainContactPrivacy: added parameter BillingPrivacy.

### 4.1.513 (2024-02-09 21:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.745.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter RepositoryCredentials_CredentialsParameter.
  * Amazon IoT
    * Modified cmdlet New-IOTDomainConfiguration: added parameter ServerCertificateConfig_EnableOCSPCheck.
    * Modified cmdlet Update-IOTDomainConfiguration: added parameter ServerCertificateConfig_EnableOCSPCheck.

### 4.1.512 (2024-02-08 21:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.744.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodePipeline
    * Modified cmdlet Get-CPActionExecutionList: added parameters LatestInPipelineExecution_PipelineExecutionId and LatestInPipelineExecution_StartTimeRange.
  * Amazon WorkSpaces
    * Modified cmdlet Get-WKSWorkspace: added parameter WorkspaceName.

### 4.1.511 (2024-02-07 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.743.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataSync
    * [Breaking Change] Modified cmdlet New-DSYNTask: removed parameters S3_BucketAccessRoleArn and S3_S3BucketArn; added parameters ManifestConfig_Action, ManifestConfig_Format, ManifestConfig_Source_S3_BucketAccessRoleArn, ManifestConfig_Source_S3_S3BucketArn, S3_ManifestObjectPath, S3_ManifestObjectVersionId, TaskReportConfig_Destination_S3_BucketAccessRoleArn and TaskReportConfig_Destination_S3_S3BucketArn.
    * [Breaking Change] Modified cmdlet Start-DSYNTaskExecution: removed parameters S3_BucketAccessRoleArn and S3_S3BucketArn; added parameters ManifestConfig_Action, ManifestConfig_Format, ManifestConfig_Source_S3_BucketAccessRoleArn, ManifestConfig_Source_S3_S3BucketArn, S3_ManifestObjectPath, S3_ManifestObjectVersionId, TaskReportConfig_Destination_S3_BucketAccessRoleArn and TaskReportConfig_Destination_S3_S3BucketArn.
    * [Breaking Change] Modified cmdlet Update-DSYNTask: removed parameters S3_BucketAccessRoleArn and S3_S3BucketArn; added parameters ManifestConfig_Action, ManifestConfig_Format, ManifestConfig_Source_S3_BucketAccessRoleArn, ManifestConfig_Source_S3_S3BucketArn, S3_ManifestObjectPath, S3_ManifestObjectVersionId, TaskReportConfig_Destination_S3_BucketAccessRoleArn and TaskReportConfig_Destination_S3_S3BucketArn.
  * Amazon Lex Model Building V2
    * Added cmdlet Get-LMBV2BotAliasReplicaList leveraging the ListBotAliasReplicas service API.
    * Added cmdlet Get-LMBV2BotReplica leveraging the DescribeBotReplica service API.
    * Added cmdlet Get-LMBV2BotReplicaList leveraging the ListBotReplicas service API.
    * Added cmdlet Get-LMBV2BotVersionReplicaList leveraging the ListBotVersionReplicas service API.
    * Added cmdlet New-LMBV2BotReplica leveraging the CreateBotReplica service API.
    * Added cmdlet Remove-LMBV2BotReplica leveraging the DeleteBotReplica service API.
  * Amazon Redshift
    * Added cmdlet Get-RSRecommendationList leveraging the ListRecommendations service API.

### 4.1.510 (2024-02-06 21:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.742.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Added cmdlet Get-ASYNGraphqlApiEnvironmentVariable leveraging the GetGraphqlApiEnvironmentVariables service API.
    * Added cmdlet Write-ASYNGraphqlApiEnvironmentVariable leveraging the PutGraphqlApiEnvironmentVariables service API.
  * Amazon Elasticsearch
    * Added cmdlet Stop-ESDomainConfigChange leveraging the CancelDomainConfigChange service API.
  * Amazon OpenSearch Service
    * Added cmdlet Stop-OSDomainConfigChange leveraging the CancelDomainConfigChange service API.
  * Amazon WAF V2
    * Added cmdlet Remove-WAF2APIKey leveraging the DeleteAPIKey service API.

### 4.1.509 (2024-02-05 21:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.741.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet Set-GLUEDataCatalogEncryptionSetting: added parameter EncryptionAtRest_CatalogEncryptionServiceRole.

### 4.1.508 (2024-02-02 21:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.740.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.507 (2024-02-01 21:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.739.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Interactive Video Service
    * Added cmdlet Get-IVSPlaybackRestrictionPolicy leveraging the GetPlaybackRestrictionPolicy service API.
    * Added cmdlet Get-IVSPlaybackRestrictionPolicyList leveraging the ListPlaybackRestrictionPolicies service API.
    * Added cmdlet New-IVSPlaybackRestrictionPolicy leveraging the CreatePlaybackRestrictionPolicy service API.
    * Added cmdlet Remove-IVSPlaybackRestrictionPolicy leveraging the DeletePlaybackRestrictionPolicy service API.
    * Added cmdlet Update-IVSPlaybackRestrictionPolicy leveraging the UpdatePlaybackRestrictionPolicy service API.
    * Modified cmdlet Get-IVSChannelList: added parameter FilterByPlaybackRestrictionPolicyArn.
    * Modified cmdlet New-IVSChannel: added parameter PlaybackRestrictionPolicyArn.
    * Modified cmdlet Update-IVSChannel: added parameter PlaybackRestrictionPolicyArn.
  * Amazon Managed Blockchain Query
    * Modified cmdlet Get-MBCQTransactionList: added parameter ConfirmationStatusFilter_Include.
  * Amazon Neptune Graph
    * Added cmdlet Get-NEPTGGraphSummary leveraging the GetGraphSummary service API.
    * Added cmdlet Get-NEPTGQuery leveraging the GetQuery service API.
    * Added cmdlet Get-NEPTGQueryList leveraging the ListQueries service API.
    * Added cmdlet Invoke-NEPTGQuery leveraging the ExecuteQuery service API.
    * Added cmdlet Stop-NEPTGQuery leveraging the CancelQuery service API.

### 4.1.506 (2024-01-31 22:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.738.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNGeneratedTemplate leveraging the GetGeneratedTemplate service API.
    * Added cmdlet Get-CFNGeneratedTemplateInformation leveraging the DescribeGeneratedTemplate service API.
    * Added cmdlet Get-CFNGeneratedTemplateList leveraging the ListGeneratedTemplates service API.
    * Added cmdlet Get-CFNResourceScan leveraging the DescribeResourceScan service API.
    * Added cmdlet Get-CFNResourceScanList leveraging the ListResourceScans service API.
    * Added cmdlet Get-CFNResourceScanRelatedResource leveraging the ListResourceScanRelatedResources service API.
    * Added cmdlet Get-CFNResourceScanResource leveraging the ListResourceScanResources service API.
    * Added cmdlet New-CFNGeneratedTemplate leveraging the CreateGeneratedTemplate service API.
    * Added cmdlet Remove-CFNGeneratedTemplate leveraging the DeleteGeneratedTemplate service API.
    * Added cmdlet Start-CFNResourceScan leveraging the StartResourceScan service API.
    * Added cmdlet Update-CFNGeneratedTemplate leveraging the UpdateGeneratedTemplate service API.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMAssociation: added parameter Duration.
    * Modified cmdlet Update-SSMAssociation: added parameter Duration.

### 4.1.505 (2024-01-30 21:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.737.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Remove-DZDomain: added parameter SkipDeletionCheck.
    * Modified cmdlet Remove-DZProject: added parameter SkipDeletionCheck.

### 4.1.504 (2024-01-29 21:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.736.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Get-EC2InstanceTypesFromInstanceRequirement: added parameter InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.
    * Modified cmdlet Get-EC2SpotPlacementScore: added parameter InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice.

### 4.1.503 (2024-01-26 21:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.735.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Inspector2
    * Modified cmdlet Get-INS2CoverageList: added parameter FilterCriteria_ImagePulledAt.
    * Modified cmdlet Get-INS2CoverageStatisticList: added parameter FilterCriteria_ImagePulledAt.
    * Modified cmdlet Update-INS2Configuration: added parameter EcrConfiguration_PullDateRescanDuration.
  * Amazon SageMaker Service
    * Added cmdlet Remove-SMHyperParameterTuningJob leveraging the DeleteHyperParameterTuningJob service API.

### 4.1.502 (2024-01-25 23:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.734.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.501 (2024-01-25 00:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.733.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2NetworkAcl: added parameter ClientToken.
    * Modified cmdlet New-EC2RouteTable: added parameter ClientToken.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSDBShardGroup leveraging the ModifyDBShardGroup service API.
    * Added cmdlet Get-RDSDBShardGroup leveraging the DescribeDBShardGroups service API.
    * Added cmdlet New-RDSDBShardGroup leveraging the CreateDBShardGroup service API.
    * Added cmdlet Remove-RDSDBShardGroup leveraging the DeleteDBShardGroup service API.
    * Added cmdlet Restart-RDSDBShardGroup leveraging the RebootDBShardGroup service API.
    * Modified cmdlet Edit-RDSDBCluster: added parameter EnableLimitlessDatabase.
    * Modified cmdlet New-RDSDBCluster: added parameter EnableLimitlessDatabase.

### 4.1.500 (2024-01-23 23:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.732.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Inspector2
    * Added cmdlet Get-INS2CisScanConfigurationList leveraging the ListCisScanConfigurations service API.
    * Added cmdlet Get-INS2CisScanList leveraging the ListCisScans service API.
    * Added cmdlet Get-INS2CisScanReport leveraging the GetCisScanReport service API.
    * Added cmdlet Get-INS2CisScanResultDetail leveraging the GetCisScanResultDetails service API.
    * Added cmdlet Get-INS2CisScanResultsAggregatedByCheckList leveraging the ListCisScanResultsAggregatedByChecks service API.
    * Added cmdlet Get-INS2CisScanResultsAggregatedByTargetResourceList leveraging the ListCisScanResultsAggregatedByTargetResource service API.
    * Added cmdlet New-INS2CisScanConfiguration leveraging the CreateCisScanConfiguration service API.
    * Added cmdlet Remove-INS2CisScanConfiguration leveraging the DeleteCisScanConfiguration service API.
    * Added cmdlet Send-INS2CisSessionHealth leveraging the SendCisSessionHealth service API.
    * Added cmdlet Send-INS2CisSessionTelemetry leveraging the SendCisSessionTelemetry service API.
    * Added cmdlet Start-INS2CisSession leveraging the StartCisSession service API.
    * Added cmdlet Stop-INS2CisSession leveraging the StopCisSession service API.
    * Added cmdlet Update-INS2CisScanConfiguration leveraging the UpdateCisScanConfiguration service API.

### 4.1.499 (2024-01-22 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.731.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Added cmdlet Get-CCASCaseAuditEvent leveraging the GetCaseAuditEvents service API.
    * Modified cmdlet New-CCASCase: added parameter PerformedBy_UserArn.
    * Modified cmdlet Update-CCASCase: added parameter PerformedBy_UserArn.

### 4.1.498 (2024-01-19 22:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.730.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * Modified cmdlet Import-ATHNotebook: added parameter NotebookS3LocationUri.
  * Amazon CodeBuild
    * Added cmdlet Get-CBCBFleetBatch leveraging the BatchGetFleets service API.
    * Added cmdlet Get-CBFleetList leveraging the ListFleets service API.
    * Added cmdlet New-CBFleet leveraging the CreateFleet service API.
    * Added cmdlet Remove-CBFleet leveraging the DeleteFleet service API.
    * Added cmdlet Update-CBFleet leveraging the UpdateFleet service API.
    * Modified cmdlet New-CBProject: added parameter Fleet_FleetArn.
    * Modified cmdlet Start-CBBuild: added parameter FleetOverride_FleetArn.
    * Modified cmdlet Update-CBProject: added parameter Fleet_FleetArn.
  * Amazon DynamoDB
    * Added cmdlet Update-DDBKinesisStreamingDestination leveraging the UpdateKinesisStreamingDestination service API.
    * Modified cmdlet Disable-DDBKinesisStreamingDestination: added parameter EnableKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision.
    * Modified cmdlet Enable-DDBKinesisStreamingDestination: added parameter EnableKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision.

### 4.1.497 (2024-01-18 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.729.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudTrail
    * Added cmdlet Get-CTInsightsMetricData leveraging the ListInsightsMetricData service API.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters SnowflakeDestinationConfiguration_AccountUrl, SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled, SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName, SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName, SnowflakeDestinationConfiguration_ContentColumnName, SnowflakeDestinationConfiguration_Database, SnowflakeDestinationConfiguration_DataLoadingOption, SnowflakeDestinationConfiguration_KeyPassphrase, SnowflakeDestinationConfiguration_MetaDataColumnName, SnowflakeDestinationConfiguration_PrivateKey, SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled, SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors, SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds, SnowflakeDestinationConfiguration_RoleARN, SnowflakeDestinationConfiguration_S3BackupMode, SnowflakeDestinationConfiguration_S3Configuration, SnowflakeDestinationConfiguration_Schema, SnowflakeDestinationConfiguration_Table, SnowflakeDestinationConfiguration_User, SnowflakeRoleConfiguration_Enabled, SnowflakeRoleConfiguration_SnowflakeRole and SnowflakeVpcConfiguration_PrivateLinkVpceId.
    * Modified cmdlet Update-KINFDestination: added parameters SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled, SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName, SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName, SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled, SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors, SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds, SnowflakeDestinationUpdate_AccountUrl, SnowflakeDestinationUpdate_ContentColumnName, SnowflakeDestinationUpdate_Database, SnowflakeDestinationUpdate_DataLoadingOption, SnowflakeDestinationUpdate_KeyPassphrase, SnowflakeDestinationUpdate_MetaDataColumnName, SnowflakeDestinationUpdate_PrivateKey, SnowflakeDestinationUpdate_RoleARN, SnowflakeDestinationUpdate_S3BackupMode, SnowflakeDestinationUpdate_S3Update, SnowflakeDestinationUpdate_Schema, SnowflakeDestinationUpdate_Table, SnowflakeDestinationUpdate_User, SnowflakeRoleConfiguration_Enabled and SnowflakeRoleConfiguration_SnowflakeRole.

### 4.1.496 (2024-01-17 21:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.728.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Keyspaces
    * Added cmdlet Get-KSTableAutoScalingSetting leveraging the GetTableAutoScalingSettings service API.
    * Modified cmdlet New-KSTable: added parameters ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn, ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown, ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown, ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue, ReadCapacityAutoScaling_AutoScalingDisabled, ReadCapacityAutoScaling_MaximumUnit, ReadCapacityAutoScaling_MinimumUnit, ReplicaSpecification, WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn, WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown, WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown, WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue, WriteCapacityAutoScaling_AutoScalingDisabled, WriteCapacityAutoScaling_MaximumUnit and WriteCapacityAutoScaling_MinimumUnit.
    * Modified cmdlet Restore-KSTable: added parameters ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn, ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown, ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown, ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue, ReadCapacityAutoScaling_AutoScalingDisabled, ReadCapacityAutoScaling_MaximumUnit, ReadCapacityAutoScaling_MinimumUnit, ReplicaSpecification, WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn, WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown, WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown, WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue, WriteCapacityAutoScaling_AutoScalingDisabled, WriteCapacityAutoScaling_MaximumUnit and WriteCapacityAutoScaling_MinimumUnit.
    * Modified cmdlet Update-KSTable: added parameters ReadCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn, ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown, ReadCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown, ReadCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue, ReadCapacityAutoScaling_AutoScalingDisabled, ReadCapacityAutoScaling_MaximumUnit, ReadCapacityAutoScaling_MinimumUnit, ReplicaSpecification, WriteCapacity_TargetTrackingScalingPolicyConfiguration_DisableScaleIn, WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleInCooldown, WriteCapacity_TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown, WriteCapacity_TargetTrackingScalingPolicyConfiguration_TargetValue, WriteCapacityAutoScaling_AutoScalingDisabled, WriteCapacityAutoScaling_MaximumUnit and WriteCapacityAutoScaling_MinimumUnit.

### 4.1.495 (2024-01-16 21:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.727.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT FleetWise
    * Modified cmdlet Get-IFWSignalCatalogNodeList: added parameter SignalNodeType.
  * Amazon Payment Cryptography Control Plane
    * Modified cmdlet Export-PAYCCKey: added parameters KeyCryptogram_CertificateAuthorityPublicKeyIdentifier, KeyCryptogram_WrappingKeyCertificate and KeyCryptogram_WrappingSpec.
    * Modified cmdlet Import-PAYCCKey: added parameters KeyCryptogram_Exportable, KeyCryptogram_ImportToken, KeyCryptogram_WrappedKeyCryptogram, KeyCryptogram_WrappingSpec, KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm, KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify, KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap and KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage.

### 4.1.494 (2024-01-14 08:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.726.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.493 (2024-01-12 22:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.725.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Supply Chain. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SUPCH and can be listed using the command 'Get-AWSCmdletName -Service SUPCH'.

### 4.1.492 (2024-01-11 21:48Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.724.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameter VolumeConfiguration.
    * Modified cmdlet New-ECSTask: added parameter VolumeConfiguration.
    * Modified cmdlet Start-ECSTask: added parameter VolumeConfiguration.
    * Modified cmdlet Update-ECSService: added parameter VolumeConfiguration.

### 4.1.491 (2024-01-10 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.723.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Modified cmdlet Write-CWLAccountPolicy: added parameter SelectionCriterion.
  * Amazon Location Service
    * Modified cmdlet Edit-LOCMap: added parameter ConfigurationUpdate_CustomLayer.
    * Modified cmdlet New-LOCMap: added parameter Configuration_CustomLayer.

### 4.1.490 (2024-01-08 21:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.722.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Route 53 Resolver
    * Modified cmdlet Edit-R53RFirewallRule: added parameter Qtype.
    * Modified cmdlet New-R53RFirewallRule: added parameter Qtype.
    * Modified cmdlet Remove-R53RFirewallRule: added parameter Qtype.

### 4.1.489 (2024-01-05 21:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.721.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.488 (2024-01-04 22:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.720.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCapacityProvider: added parameter AutoScalingGroupProvider_ManagedDraining.
    * Modified cmdlet Update-ECSCapacityProvider: added parameter AutoScalingGroupProvider_ManagedDraining.
  * Amazon Lightsail
    * Added cmdlet Get-LSSetupHistory leveraging the GetSetupHistory service API.
    * Added cmdlet Set-LSInstanceHttp leveraging the SetupInstanceHttps service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMFeatureGroup: added parameters ThroughputConfig_ProvisionedReadCapacityUnit, ThroughputConfig_ProvisionedWriteCapacityUnit and ThroughputConfig_ThroughputMode.
    * Modified cmdlet Update-SMFeatureGroup: added parameters ThroughputConfig_ProvisionedReadCapacityUnit, ThroughputConfig_ProvisionedWriteCapacityUnit and ThroughputConfig_ThroughputMode.
  * Amazon Service Catalog
    * Modified cmdlet Add-SCServiceActionAssociationWithProvisioningArtifact: added parameter IdempotencyToken.
    * Modified cmdlet Remove-SCServiceAction: added parameter IdempotencyToken.
    * Modified cmdlet Remove-SCServiceActionAssociationFromProvisioningArtifact: added parameter IdempotencyToken.

### 4.1.487 (2024-01-03 21:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.719.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

