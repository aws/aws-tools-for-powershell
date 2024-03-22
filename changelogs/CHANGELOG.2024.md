### 4.1.543 (2024-03-22 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.774.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.542 (2024-03-21 20:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.773.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeArtifact
    * Added cmdlet Get-CAAllowedRepositoriesForGroupList leveraging the ListAllowedRepositoriesForGroup service API.
    * Added cmdlet Get-CAAssociatedPackageGroup leveraging the GetAssociatedPackageGroup service API.
    * Added cmdlet Get-CAAssociatedPackageList leveraging the ListAssociatedPackages service API.
    * Added cmdlet Get-CAPackageGroup leveraging the DescribePackageGroup service API.
    * Added cmdlet Get-CAPackageGroupList leveraging the ListPackageGroups service API.
    * Added cmdlet Get-CASubPackageGroupList leveraging the ListSubPackageGroups service API.
    * Added cmdlet New-CAPackageGroup leveraging the CreatePackageGroup service API.
    * Added cmdlet Remove-CAPackageGroup leveraging the DeletePackageGroup service API.
    * Added cmdlet Update-CAPackageGroup leveraging the UpdatePackageGroup service API.
    * Added cmdlet Update-CAPackageGroupOriginConfiguration leveraging the UpdatePackageGroupOriginConfiguration service API.

### 4.1.541 (2024-03-20 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.772.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-DDBResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-DDBResourcePolicy leveraging the PutResourcePolicy service API.
  * Amazon Managed Blockchain Query
    * Modified cmdlet Get-MBCQTransaction: added parameter TransactionId.
  * Amazon Savings Plans
    * Added cmdlet Invoke-SPReturnSavingsPlan leveraging the ReturnSavingsPlan service API.

### 4.1.540 (2024-03-19 20:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.771.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2MacHost leveraging the DescribeMacHosts service API.
  * Amazon FinSpace User Environment Management Service
    * Modified cmdlet New-FINSPKxDataview: added parameter ReadWrite.
  * Amazon Managed Blockchain Query
    * Added cmdlet Get-MBCQFilteredTransactionEventList leveraging the ListFilteredTransactionEvents service API.
    * Modified cmdlet Get-MBCQTransactionEventList: added parameter TransactionId.

### 4.1.539 (2024-03-18 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.770.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNStackSetAutoDeploymentTarget leveraging the ListStackSetAutoDeploymentTargets service API.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Get-EMTChannelSchedule: added parameter Audience.
    * Modified cmdlet New-EMTChannel: added parameter Audience.
    * Modified cmdlet New-EMTProgram: added parameters AudienceMedia and ClipRange_StartOffsetMilli.
    * Modified cmdlet Update-EMTChannel: added parameter Audience.
    * Modified cmdlet Update-EMTProgram: added parameters AudienceMedia and ClipRange_StartOffsetMilli.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSIntegration leveraging the ModifyIntegration service API.
    * Modified cmdlet New-RDSIntegration: added parameters DataFilter and Description.

### 4.1.538 (2024-03-15 20:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.769.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * 
    * Added cmdlet Initialize-AWSSSOConfiguration.
    * Added cmdlet Invoke-AWSSSOLogin.
    * Added cmdlet Invoke-AWSSSOLogout.
    * Added cmdlet Set-AWSSSOSessionConfiguration.
  * Amazon Backup
    * Modified cmdlet Get-BAKRecoveryPointsByResourceList: added parameter ManagedByAWSBackupOnly.
  * Amazon CodeBuild
    * Modified cmdlet New-CBFleet: added parameter OverflowBehavior.
    * Modified cmdlet Update-CBFleet: added parameter OverflowBehavior.
  * Amazon Connect Service
    * Modified cmdlet New-CONNSecurityProfile: added parameters AllowedAccessControlHierarchyGroupId and HierarchyRestrictedResource.
    * Modified cmdlet Search-CONNUser: added parameters AndCondition_TagCondition, SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_HierarchyGroupMatchType, SearchFilter_UserAttributeFilter_AndCondition_HierarchyGroupCondition_Value, SearchFilter_UserAttributeFilter_HierarchyGroupCondition_HierarchyGroupMatchType, SearchFilter_UserAttributeFilter_HierarchyGroupCondition_Value, TagCondition_TagKey, TagCondition_TagValue and UserAttributeFilter_OrCondition.
    * Modified cmdlet Update-CONNSecurityProfile: added parameters AllowedAccessControlHierarchyGroupId and HierarchyRestrictedResource.
  * Amazon WorkSpaces Thin Client
    * [Breaking Change] Modified cmdlet Update-WSTCDevice: removed parameter KmsKeyArn.

### 4.1.537 (2024-03-14 20:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.768.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon IoT RoboRunner
  * Amazon Fault Injection Simulator
    * Modified cmdlet Get-FISExperimentList: added parameters ExperimentTemplateId and PassThru.
    * Modified cmdlet Start-FISExperiment: added parameter ExperimentOptions_ActionsMode.
  * Amazon Timestream InfluxDB. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TIDB and can be listed using the command 'Get-AWSCmdletName -Service TIDB'.

### 4.1.536 (2024-03-13 20:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.767.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Cognito Identity
    * Added cmdlet Dismount-CGIDeveloperIdentity leveraging the UnlinkDeveloperIdentity service API.
    * Added cmdlet Dismount-CGIIdentity leveraging the UnlinkIdentity service API.
    * Added cmdlet Find-CGIDeveloperIdentity leveraging the LookupDeveloperIdentity service API.
    * Added cmdlet Get-CGICredentialsForIdentity leveraging the GetCredentialsForIdentity service API.
    * Added cmdlet Get-CGIId leveraging the GetId service API.
    * Added cmdlet Get-CGIIdentity leveraging the DescribeIdentity service API.
    * Added cmdlet Get-CGIIdentityList leveraging the ListIdentities service API.
    * Added cmdlet Get-CGIOpenIdToken leveraging the GetOpenIdToken service API.
    * Added cmdlet Get-CGIOpenIdTokenForDeveloperIdentity leveraging the GetOpenIdTokenForDeveloperIdentity service API.
    * Added cmdlet Merge-CGIDeveloperIdentity leveraging the MergeDeveloperIdentities service API.
    * Added cmdlet Remove-CGIIdentity leveraging the DeleteIdentities service API.
  * Amazon Interactive Video Service RealTime
    * Modified cmdlet Start-IVSRTComposition: added parameters Grid_GridGap, Grid_OmitStoppedVideo, Grid_VideoAspectRatio, Grid_VideoFillMode, Pip_FeaturedParticipantAttribute, Pip_GridGap, Pip_OmitStoppedVideo, Pip_PipBehavior, Pip_PipHeight, Pip_PipOffset, Pip_PipParticipantAttribute, Pip_PipPosition, Pip_PipWidth and Pip_VideoFillMode.
  * Amazon Kinesis Analytics V2
    * Modified cmdlet Update-KINA2Application: added parameter RuntimeEnvironmentUpdate.

### 4.1.535 (2024-03-12 20:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.766.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.534 (2024-03-11 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.765.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeStar Connections
    * Modified cmdlet New-CSTCSyncConfiguration: added parameters PublishDeploymentStatus and TriggerResourceUpdateOn.
    * Modified cmdlet Update-CSTCSyncConfiguration: added parameters PublishDeploymentStatus and TriggerResourceUpdateOn.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet Update-MPV2Channel: added parameter ETag.
    * Modified cmdlet Update-MPV2ChannelGroup: added parameter ETag.
    * Modified cmdlet Update-MPV2OriginEndpoint: added parameter ETag.

### 4.1.533 (2024-03-08 21:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.764.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet New-BATJobQueue: added parameter JobStateTimeLimitAction.
    * Modified cmdlet Update-BATJobQueue: added parameter JobStateTimeLimitAction.

### 4.1.532 (2024-03-07 21:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.763.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppConfig
    * Modified cmdlet Start-APPCDeployment: added parameter DynamicExtensionParameter.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Copy-EC2Image: added parameter TagSpecification.
    * Modified cmdlet Register-EC2Image: added parameter TagSpecification.
  * Amazon Managed Grafana
    * Modified cmdlet Add-MGRFLicense: added parameter GrafanaToken.
  * Amazon Payment Cryptography Data
    * Modified cmdlet Protect-PAYCDData: added parameters Emv_InitializationVector, Emv_MajorKeyDerivationMode, Emv_Mode, Emv_PanSequenceNumber, Emv_PrimaryAccountNumber and Emv_SessionDerivationData.
    * Modified cmdlet Unprotect-PAYCDData: added parameters Emv_InitializationVector, Emv_MajorKeyDerivationMode, Emv_Mode, Emv_PanSequenceNumber, Emv_PrimaryAccountNumber and Emv_SessionDerivationData.

### 4.1.531 (2024-03-06 22:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.762.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter CACertificateIdentifier.
    * Modified cmdlet New-RDSDBCluster: added parameter CACertificateIdentifier.

### 4.1.530 (2024-03-05 21:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.761.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2DeliverabilityTestReport: added parameters Simple_Header and Template_Header.
    * Modified cmdlet Send-SES2BulkEmail: added parameter Template_Header.
    * Modified cmdlet Send-SES2Email: added parameters Simple_Header and Template_Header.

### 4.1.529 (2024-03-04 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.760.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.528 (2024-03-01 21:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.759.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.527 (2024-02-29 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.759.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DocumentDB Elastic Clusters
    * Added cmdlet Copy-DOCEClusterSnapshot leveraging the CopyClusterSnapshot service API.
    * Added cmdlet Start-DOCECluster leveraging the StartCluster service API.
    * Added cmdlet Stop-DOCECluster leveraging the StopCluster service API.
    * Modified cmdlet Get-DOCEClusterSnapshotList: added parameter SnapshotType.
    * Modified cmdlet New-DOCECluster: added parameters BackupRetentionPeriod, PreferredBackupWindow and ShardInstanceCount.
    * Modified cmdlet Restore-DOCEClusterFromSnapshot: added parameters ShardCapacity and ShardInstanceCount.
    * Modified cmdlet Update-DOCECluster: added parameters BackupRetentionPeriod, PreferredBackupWindow and ShardInstanceCount.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2Intent: added parameters BedrockKnowledgeStoreConfiguration_BedrockKnowledgeBaseArn, BedrockModelConfiguration_ModelArn, ExactResponseFields_AnswerField, ExactResponseFields_QuestionField, KendraConfiguration_ExactResponse, OpensearchConfiguration_DomainEndpoint, OpensearchConfiguration_ExactResponse, OpensearchConfiguration_IncludeField, OpensearchConfiguration_IndexName, QnAIntentConfiguration_DataSourceConfiguration_KendraConfiguration_KendraIndex, QnAIntentConfiguration_DataSourceConfiguration_KendraConfiguration_QueryFilterString and QnAIntentConfiguration_DataSourceConfiguration_KendraConfiguration_QueryFilterStringEnabled.
    * Modified cmdlet Update-LMBV2Intent: added parameters BedrockKnowledgeStoreConfiguration_BedrockKnowledgeBaseArn, BedrockModelConfiguration_ModelArn, ExactResponseFields_AnswerField, ExactResponseFields_QuestionField, KendraConfiguration_ExactResponse, OpensearchConfiguration_DomainEndpoint, OpensearchConfiguration_ExactResponse, OpensearchConfiguration_IncludeField, OpensearchConfiguration_IndexName, QnAIntentConfiguration_DataSourceConfiguration_KendraConfiguration_KendraIndex, QnAIntentConfiguration_DataSourceConfiguration_KendraConfiguration_QueryFilterString and QnAIntentConfiguration_DataSourceConfiguration_KendraConfiguration_QueryFilterStringEnabled.
  * Amazon Migration Hub Orchestrator
    * Added cmdlet New-MHOTemplate leveraging the CreateTemplate service API.
    * Added cmdlet Remove-MHOTemplate leveraging the DeleteTemplate service API.
    * Added cmdlet Update-MHOTemplate leveraging the UpdateTemplate service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMModelPackage: added parameter SourceUri.
    * Modified cmdlet Update-SMModelPackage: added parameters InferenceSpecification_Container, InferenceSpecification_SupportedContentType, InferenceSpecification_SupportedRealtimeInferenceInstanceType, InferenceSpecification_SupportedResponseMIMEType, InferenceSpecification_SupportedTransformInstanceType and SourceUri.
  * Amazon Security Lake
    * Modified cmdlet Update-SLKDataLake: added parameters MetaStoreManagerRoleArn and PassThru.

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

