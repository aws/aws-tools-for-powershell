### 5.0.113 (2025-12-09 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.149.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Account
    * Added cmdlet Get-ACCTGovCloudAccountInformation leveraging the GetGovCloudAccountInformation service API.
  * Amazon Application Migration Service
    * Modified cmdlet New-MGNLaunchConfigurationTemplate: added parameters EnableParametersEncryption and ParametersEncryptionKey.
    * Modified cmdlet New-MGNReplicationConfigurationTemplate: added parameter InternetProtocol.
    * Modified cmdlet Start-MGNExport: added parameter Tag.
    * Modified cmdlet Start-MGNImport: added parameter Tag.
    * Modified cmdlet Update-MGNLaunchConfigurationTemplate: added parameters EnableParametersEncryption and ParametersEncryptionKey.
    * Modified cmdlet Update-MGNReplicationConfiguration: added parameter InternetProtocol.
    * Modified cmdlet Update-MGNReplicationConfigurationTemplate: added parameter InternetProtocol.

### 5.0.112 (2025-12-08 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.148.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostCategoryResourceAssociationList leveraging the ListCostCategoryResourceAssociations service API.
    * Modified cmdlet Get-CECostCategoryDefinitionList: added parameter SupportedResourceType.
  * Amazon Identity Store
    * Modified cmdlet Find-IDSUserList: added parameter Extension.
    * Modified cmdlet Get-IDSUser: added parameter Extension.
    * Modified cmdlet New-IDSUser: added parameter Extension.
  * Amazon Redshift Serverless
    * Added cmdlet Get-RSSIdentityCenterAuthToken leveraging the GetIdentityCenterAuthToken service API.
  * Amazon Relational Database Service
    * Modified cmdlet Convert-RDSReadReplicaToStandalone: added parameter TagSpecification.
    * Modified cmdlet Edit-RDSDBInstance: added parameter TagSpecification.
    * Modified cmdlet New-RDSDBCluster: added parameter TagSpecification.
    * Modified cmdlet New-RDSDBInstance: added parameter TagSpecification.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter TagSpecification.
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameter TagSpecification.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter TagSpecification.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter TagSpecification.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter TagSpecification.
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter TagSpecification.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter TagSpecification.
    * Modified cmdlet Start-RDSDBInstanceAutomatedBackupsReplication: added parameter Tag.

### 5.0.111 (2025-12-05 21:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.147.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Partner Central Account API
    * Added cmdlet Get-PCAAVerification leveraging the GetVerification service API.
    * Added cmdlet Start-PCAAVerification leveraging the StartVerification service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3BucketRequestPayment: added parameter ContentMD5.

### 5.0.110 (2025-12-04 18:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.146.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.109 (2025-12-03 18:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.145.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Update-BDRCustomModelDeployment leveraging the UpdateCustomModelDeployment service API.
    * Modified cmdlet New-BDRModelCustomizationJob: added parameters HyperParameters_BatchSize, HyperParameters_EpochCount, HyperParameters_EvalInterval, HyperParameters_InferenceMaxToken, HyperParameters_LearningRate, HyperParameters_MaxPromptLength, HyperParameters_ReasoningEffort, HyperParameters_TrainingSamplePerPrompt and LambdaGrader_LambdaArn.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMModelPackage: added parameter ModelPackageRegistrationType.
    * Modified cmdlet New-SMTrainingJob: added parameters MlflowConfig_MlflowExperimentName, MlflowConfig_MlflowResourceArn, MlflowConfig_MlflowRunName, ModelPackageConfig_ModelPackageGroupArn, ModelPackageConfig_SourceModelPackageArn, ServerlessJobConfig_AcceptEula, ServerlessJobConfig_BaseModelArn, ServerlessJobConfig_CustomizationTechnique, ServerlessJobConfig_EvaluationType, ServerlessJobConfig_EvaluatorArn, ServerlessJobConfig_JobType and ServerlessJobConfig_Peft.
    * Modified cmdlet Start-SMPipelineExecution: added parameter MlflowExperimentName.
    * Modified cmdlet Update-SMModelPackage: added parameter ModelPackageRegistrationType.

### 5.0.108 (2025-12-02 18:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.144.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet Write-BDRModelInvocationLoggingConfiguration: added parameter LoggingConfig_AudioDataDeliveryEnabled.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Added cmdlet Get-BACCEvaluator leveraging the GetEvaluator service API.
    * Added cmdlet Get-BACCEvaluatorList leveraging the ListEvaluators service API.
    * Added cmdlet Get-BACCOnlineEvaluationConfig leveraging the GetOnlineEvaluationConfig service API.
    * Added cmdlet Get-BACCOnlineEvaluationConfigList leveraging the ListOnlineEvaluationConfigs service API.
    * Added cmdlet Get-BACCPolicy leveraging the GetPolicy service API.
    * Added cmdlet Get-BACCPolicyEngine leveraging the GetPolicyEngine service API.
    * Added cmdlet Get-BACCPolicyEngineList leveraging the ListPolicyEngines service API.
    * Added cmdlet Get-BACCPolicyGeneration leveraging the GetPolicyGeneration service API.
    * Added cmdlet Get-BACCPolicyGenerationAssetList leveraging the ListPolicyGenerationAssets service API.
    * Added cmdlet Get-BACCPolicyGenerationList leveraging the ListPolicyGenerations service API.
    * Added cmdlet Get-BACCPolicyList leveraging the ListPolicies service API.
    * Added cmdlet Get-BACCResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet New-BACCEvaluator leveraging the CreateEvaluator service API.
    * Added cmdlet New-BACCOnlineEvaluationConfig leveraging the CreateOnlineEvaluationConfig service API.
    * Added cmdlet New-BACCPolicy leveraging the CreatePolicy service API.
    * Added cmdlet New-BACCPolicyEngine leveraging the CreatePolicyEngine service API.
    * Added cmdlet Remove-BACCEvaluator leveraging the DeleteEvaluator service API.
    * Added cmdlet Remove-BACCOnlineEvaluationConfig leveraging the DeleteOnlineEvaluationConfig service API.
    * Added cmdlet Remove-BACCPolicy leveraging the DeletePolicy service API.
    * Added cmdlet Remove-BACCPolicyEngine leveraging the DeletePolicyEngine service API.
    * Added cmdlet Remove-BACCResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Start-BACCPolicyGeneration leveraging the StartPolicyGeneration service API.
    * Added cmdlet Update-BACCEvaluator leveraging the UpdateEvaluator service API.
    * Added cmdlet Update-BACCOnlineEvaluationConfig leveraging the UpdateOnlineEvaluationConfig service API.
    * Added cmdlet Update-BACCPolicy leveraging the UpdatePolicy service API.
    * Added cmdlet Update-BACCPolicyEngine leveraging the UpdatePolicyEngine service API.
    * Added cmdlet Write-BACCResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet New-BACCAgentRuntime: added parameters CustomJWTAuthorizer_AllowedScope and CustomJWTAuthorizer_CustomClaim.
    * Modified cmdlet New-BACCGateway: added parameters CustomJWTAuthorizer_AllowedScope, CustomJWTAuthorizer_CustomClaim, PolicyEngineConfiguration_Arn and PolicyEngineConfiguration_Mode.
    * Modified cmdlet New-BACCGatewayTarget: added parameters ApiGateway_RestApiId, ApiGateway_Stage, ApiGatewayToolConfiguration_ToolFilter and ApiGatewayToolConfiguration_ToolOverride.
    * Modified cmdlet Update-BACCAgentRuntime: added parameters CustomJWTAuthorizer_AllowedScope and CustomJWTAuthorizer_CustomClaim.
    * Modified cmdlet Update-BACCGateway: added parameters CustomJWTAuthorizer_AllowedScope, CustomJWTAuthorizer_CustomClaim, PolicyEngineConfiguration_Arn and PolicyEngineConfiguration_Mode.
    * Modified cmdlet Update-BACCGatewayTarget: added parameters ApiGateway_RestApiId, ApiGateway_Stage, ApiGatewayToolConfiguration_ToolFilter and ApiGatewayToolConfiguration_ToolOverride.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Invoke-BACEvaluate leveraging the Evaluate service API.
    * Modified cmdlet Invoke-BACMemoryRecord: added parameter SearchCriteria_MetadataFilter.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLAggregateLogGroupSummaryList leveraging the ListAggregateLogGroupSummaries service API.
    * Added cmdlet Get-CWLLogField leveraging the GetLogFields service API.
    * Added cmdlet Get-CWLSourcesForS3TableIntegrationList leveraging the ListSourcesForS3TableIntegration service API.
    * Added cmdlet Register-CWLSourceToS3TableIntegration leveraging the AssociateSourceToS3TableIntegration service API.
    * Added cmdlet Unregister-CWLSourceFromS3TableIntegration leveraging the DisassociateSourceFromS3TableIntegration service API.
    * Modified cmdlet Get-CWLLogGroupList: added parameters DataSource and FieldIndexName.
  * Amazon CloudWatch Observability Admin Service
    * Added cmdlet Get-CWOADMNS3TableIntegration leveraging the GetS3TableIntegration service API.
    * Added cmdlet Get-CWOADMNS3TableIntegrationList leveraging the ListS3TableIntegrations service API.
    * Added cmdlet Get-CWOADMNTelemetryPipeline leveraging the GetTelemetryPipeline service API.
    * Added cmdlet Get-CWOADMNTelemetryPipelineList leveraging the ListTelemetryPipelines service API.
    * Added cmdlet New-CWOADMNS3TableIntegration leveraging the CreateS3TableIntegration service API.
    * Added cmdlet New-CWOADMNTelemetryPipeline leveraging the CreateTelemetryPipeline service API.
    * Added cmdlet Remove-CWOADMNS3TableIntegration leveraging the DeleteS3TableIntegration service API.
    * Added cmdlet Remove-CWOADMNTelemetryPipeline leveraging the DeleteTelemetryPipeline service API.
    * Added cmdlet Test-CWOADMNTelemetryPipeline leveraging the TestTelemetryPipeline service API.
    * Added cmdlet Test-CWOADMNTelemetryPipelineConfiguration leveraging the ValidateTelemetryPipelineConfiguration service API.
    * Added cmdlet Update-CWOADMNTelemetryPipeline leveraging the UpdateTelemetryPipeline service API.
    * Modified cmdlet New-CWOADMNTelemetryRule: added parameters CloudtrailParameters_AdvancedEventSelector, ELBLoadBalancerLoggingParameters_FieldDelimiter, ELBLoadBalancerLoggingParameters_OutputFormat, LogDeliveryParameters_LogType, LoggingFilter_DefaultBehavior, LoggingFilter_Filter, Rule_TelemetrySourceType, WAFLoggingParameters_LogType and WAFLoggingParameters_RedactedField.
    * Modified cmdlet New-CWOADMNTelemetryRuleForOrganization: added parameters CloudtrailParameters_AdvancedEventSelector, ELBLoadBalancerLoggingParameters_FieldDelimiter, ELBLoadBalancerLoggingParameters_OutputFormat, LogDeliveryParameters_LogType, LoggingFilter_DefaultBehavior, LoggingFilter_Filter, Rule_TelemetrySourceType, WAFLoggingParameters_LogType and WAFLoggingParameters_RedactedField.
    * Modified cmdlet Update-CWOADMNTelemetryRule: added parameters CloudtrailParameters_AdvancedEventSelector, ELBLoadBalancerLoggingParameters_FieldDelimiter, ELBLoadBalancerLoggingParameters_OutputFormat, LogDeliveryParameters_LogType, LoggingFilter_DefaultBehavior, LoggingFilter_Filter, Rule_TelemetrySourceType, WAFLoggingParameters_LogType and WAFLoggingParameters_RedactedField.
    * Modified cmdlet Update-CWOADMNTelemetryRuleForOrganization: added parameters CloudtrailParameters_AdvancedEventSelector, ELBLoadBalancerLoggingParameters_FieldDelimiter, ELBLoadBalancerLoggingParameters_OutputFormat, LogDeliveryParameters_LogType, LoggingFilter_DefaultBehavior, LoggingFilter_Filter, Rule_TelemetrySourceType, WAFLoggingParameters_LogType and WAFLoggingParameters_RedactedField.
  * Amazon DataZone
    * Added cmdlet Get-DZDataExportConfiguration leveraging the GetDataExportConfiguration service API.
    * Added cmdlet Write-DZDataExportConfiguration leveraging the PutDataExportConfiguration service API.
    * Modified cmdlet Get-DZMetadataGenerationRun: added parameter Type.
    * Modified cmdlet Get-DZMetadataGenerationRunList: added parameter TargetIdentifier.
    * Modified cmdlet Start-DZMetadataGenerationRun: added parameter Types.
  * Amazon FSx
    * Modified cmdlet New-FSXAndAttachS3AccessPoint: added parameters OntapConfiguration_FileSystemIdentity_Type, OntapConfiguration_VolumeId, UnixUser_Name and WindowsUser_Name.
  * Amazon Lambda
    * Added cmdlet Checkpoint-LMDurableExecution leveraging the CheckpointDurableExecution service API.
    * Added cmdlet Get-LMDurableExecution leveraging the GetDurableExecution service API.
    * Added cmdlet Get-LMDurableExecutionHistory leveraging the GetDurableExecutionHistory service API.
    * Added cmdlet Get-LMDurableExecutionsByFunctionList leveraging the ListDurableExecutionsByFunction service API.
    * Added cmdlet Get-LMDurableExecutionState leveraging the GetDurableExecutionState service API.
    * Added cmdlet Send-LMDurableExecutionCallbackFailure leveraging the SendDurableExecutionCallbackFailure service API.
    * Added cmdlet Send-LMDurableExecutionCallbackHeartbeat leveraging the SendDurableExecutionCallbackHeartbeat service API.
    * Added cmdlet Send-LMDurableExecutionCallbackSuccess leveraging the SendDurableExecutionCallbackSuccess service API.
    * Added cmdlet Stop-LMDurableExecution leveraging the StopDurableExecution service API.
    * Modified cmdlet Publish-LMFunction: added parameters DurableConfig_ExecutionTimeout and DurableConfig_RetentionPeriodInDay.
    * Modified cmdlet Invoke-LMFunction: added parameter DurableExecutionName.
    * Modified cmdlet Update-LMFunctionConfiguration: added parameters DurableConfig_ExecutionTimeout and DurableConfig_RetentionPeriodInDay.
  * Amazon Nova Act. Added cmdlets to support the service. Cmdlets for the service have the noun prefix NOVA and can be listed using the command 'Get-AWSCmdletName -Service NOVA'.
  * Amazon OpenSearch Serverless
    * Modified cmdlet New-OSSCollection: added parameter VectorOptions_ServerlessVectorAcceleration.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter ServerlessVectorAcceleration_Enabled.
    * Modified cmdlet Update-OSDomainConfig: added parameter ServerlessVectorAcceleration_Enabled.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBInstance: added parameter AdditionalStorageVolume.
    * Modified cmdlet New-RDSCustomDBEngineVersion: added parameter DatabaseInstallationFile.
    * Modified cmdlet New-RDSDBInstance: added parameter AdditionalStorageVolume.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter AdditionalStorageVolume.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter AdditionalStorageVolume.
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter AdditionalStorageVolume.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter AdditionalStorageVolume.
  * Amazon S3 Control
    * Modified cmdlet Write-S3CStorageLensConfiguration: added parameters DataExport_StorageLensTableDestination_Encryption_SSES3, DataExport_StorageLensTableDestination_IsEnabled, DataExport_StorageLensTableDestination_SSEKMS_KeyId, ExpandedPrefixesDataExport_S3BucketDestination_AccountId, ExpandedPrefixesDataExport_S3BucketDestination_Arn, ExpandedPrefixesDataExport_S3BucketDestination_Encryption_SSES3, ExpandedPrefixesDataExport_S3BucketDestination_Format, ExpandedPrefixesDataExport_S3BucketDestination_OutputSchemaVersion, ExpandedPrefixesDataExport_S3BucketDestination_Prefix, ExpandedPrefixesDataExport_S3BucketDestination_SSEKMS_KeyId, ExpandedPrefixesDataExport_StorageLensTableDestination_Encryption_SSES3, ExpandedPrefixesDataExport_StorageLensTableDestination_IsEnabled, ExpandedPrefixesDataExport_StorageLensTableDestination_SSEKMS_KeyId, StorageLensConfiguration_AccountLevel_AdvancedPerformanceMetrics_IsEnabled, StorageLensConfiguration_BucketLevel_AdvancedPerformanceMetrics_IsEnabled and StorageLensConfiguration_PrefixDelimiter.
  * Amazon S3 Tables
    * Added cmdlet Get-S3TTableBucketReplication leveraging the GetTableBucketReplication service API.
    * Added cmdlet Get-S3TTableBucketStorageClass leveraging the GetTableBucketStorageClass service API.
    * Added cmdlet Get-S3TTableRecordExpirationConfiguration leveraging the GetTableRecordExpirationConfiguration service API.
    * Added cmdlet Get-S3TTableRecordExpirationJobStatus leveraging the GetTableRecordExpirationJobStatus service API.
    * Added cmdlet Get-S3TTableReplication leveraging the GetTableReplication service API.
    * Added cmdlet Get-S3TTableReplicationStatus leveraging the GetTableReplicationStatus service API.
    * Added cmdlet Get-S3TTableStorageClass leveraging the GetTableStorageClass service API.
    * Added cmdlet Remove-S3TTableBucketReplication leveraging the DeleteTableBucketReplication service API.
    * Added cmdlet Remove-S3TTableReplication leveraging the DeleteTableReplication service API.
    * Added cmdlet Write-S3TTableBucketReplication leveraging the PutTableBucketReplication service API.
    * Added cmdlet Write-S3TTableBucketStorageClass leveraging the PutTableBucketStorageClass service API.
    * Added cmdlet Write-S3TTableRecordExpirationConfiguration leveraging the PutTableRecordExpirationConfiguration service API.
    * Added cmdlet Write-S3TTableReplication leveraging the PutTableReplication service API.
    * Modified cmdlet New-S3TTable: added parameters Iceberg_Property and StorageClassConfiguration_StorageClass.
    * Modified cmdlet New-S3TTableBucket: added parameter StorageClassConfiguration_StorageClass.
  * Amazon S3 Vectors
    * Added cmdlet Add-S3VResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-S3VResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-S3VResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-S3VIndex: added parameters EncryptionConfiguration_KmsKeyArn, EncryptionConfiguration_SseType and Tag.
    * Modified cmdlet New-S3VVectorBucket: added parameter Tag.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMMlflowAppDetail leveraging the DescribeMlflowApp service API.
    * Added cmdlet Get-SMMlflowAppList leveraging the ListMlflowApps service API.
    * Added cmdlet New-SMMlflowApp leveraging the CreateMlflowApp service API.
    * Added cmdlet New-SMPresignedMlflowAppUrl leveraging the CreatePresignedMlflowAppUrl service API.
    * Added cmdlet Remove-SMMlflowApp leveraging the DeleteMlflowApp service API.
    * Added cmdlet Update-SMMlflowApp leveraging the UpdateMlflowApp service API.
  * Amazon Security Hub
    * [Breaking Change] Modified cmdlet New-SHUBConnectorV2: removed parameters ServiceNow_ClientId and ServiceNow_ClientSecret; added parameter ServiceNow_SecretArn.
    * Modified cmdlet New-SHUBTicketV2: added parameter Mode.
    * [Breaking Change] Modified cmdlet Register-SHUBConnectorV2: output changed from Amazon.SecurityHub.Model.ConnectorRegistrationsV2Response to Amazon.SecurityHub.Model.RegisterConnectorV2Response.
    * [Breaking Change] Modified cmdlet Update-SHUBConnectorV2: removed parameter ClientSecret; added parameter ServiceNow_SecretArn.

### 5.0.107 (2025-12-01 03:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.143.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameters BedrockEmbeddingModelConfiguration_Audio and BedrockEmbeddingModelConfiguration_Video.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters BedrockEmbeddingModelConfiguration_Audio and BedrockEmbeddingModelConfiguration_Video.
  * Amazon AmazonConnectCampaignServiceV2
    * Modified cmdlet New-CCS2Campaign: added parameters ChannelSubtypeConfig_WhatsApp_DefaultOutboundConfig_ConnectSourcePhoneNumberArn, DefaultOutboundConfig_WisdomTemplateArn, OpenHours_DailyHour, OutboundMode_Agentless, RestrictedPeriods_RestrictedPeriodList, Type and WhatsApp_Capacity.
    * Modified cmdlet Remove-CCS2ConnectInstanceIntegration: added parameter Lambda_FunctionArn.
    * Modified cmdlet Update-CCS2CampaignChannelSubtypeConfig: added parameters ChannelSubtypeConfig_WhatsApp_DefaultOutboundConfig_ConnectSourcePhoneNumberArn, DefaultOutboundConfig_WisdomTemplateArn, OutboundMode_Agentless and WhatsApp_Capacity.
    * Modified cmdlet Update-CCS2CampaignCommunicationTime: added parameters OpenHours_DailyHour and RestrictedPeriods_RestrictedPeriodList.
    * Modified cmdlet Write-CCS2ConnectInstanceIntegration: added parameter Lambda_FunctionArn.
  * Amazon AppIntegrations Service
    * Modified cmdlet Get-AISApplicationList: added parameter ApplicationType.
    * Modified cmdlet New-AISApplication: added parameter ApplicationType.
    * Modified cmdlet Update-AISApplication: added parameter ApplicationType.
  * Amazon Bedrock Agent Runtime
    * [Breaking Change] Modified cmdlet Invoke-BARRetrieve: removed parameter NoAutoIteration; added parameters Image_Format, Image_InlineContent and RetrievalQuery_Type.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSAnalysisTemplate: added parameters ColumnClassification_ColumnMapping, MlSyntheticDataParameters_Epsilon and MlSyntheticDataParameters_MaxMembershipInferenceAttackScore.
    * Modified cmdlet New-CRSCollaboration: added parameter SyntheticDataGeneration_IsResponsible.
    * Modified cmdlet New-CRSMembership: added parameter SyntheticDataGeneration_IsResponsible.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFDomainObjectType leveraging the GetDomainObjectType service API.
    * Added cmdlet Get-CPFDomainObjectTypeList leveraging the ListDomainObjectTypes service API.
    * Added cmdlet Get-CPFObjectTypeAttributeStatistic leveraging the GetObjectTypeAttributeStatistics service API.
    * Added cmdlet Get-CPFObjectTypeAttributeValueList leveraging the ListObjectTypeAttributeValues service API.
    * Added cmdlet Get-CPFProfileRecommendation leveraging the GetProfileRecommendations service API.
    * Added cmdlet Get-CPFRecommender leveraging the GetRecommender service API.
    * Added cmdlet Get-CPFRecommenderList leveraging the ListRecommenders service API.
    * Added cmdlet Get-CPFRecommenderRecipeList leveraging the ListRecommenderRecipes service API.
    * Added cmdlet New-CPFRecommender leveraging the CreateRecommender service API.
    * Added cmdlet Remove-CPFDomainObjectType leveraging the DeleteDomainObjectType service API.
    * Added cmdlet Remove-CPFRecommender leveraging the DeleteRecommender service API.
    * Added cmdlet Start-CPFRecommender leveraging the StartRecommender service API.
    * Added cmdlet Stop-CPFRecommender leveraging the StopRecommender service API.
    * Added cmdlet Update-CPFRecommender leveraging the UpdateRecommender service API.
    * Added cmdlet Write-CPFDomainObjectType leveraging the PutDomainObjectType service API.
    * Modified cmdlet New-CPFDomain: added parameter DataStore_Enabled.
    * Modified cmdlet New-CPFSegmentDefinition: added parameter SegmentSqlQuery.
    * Modified cmdlet New-CPFSegmentEstimate: added parameter SegmentSqlQuery.
    * Modified cmdlet Update-CPFDomain: added parameter DataStore_Enabled.
    * Modified cmdlet Write-CPFIntegration: added parameter Scope.
  * Amazon Connect Service
    * Added cmdlet Add-CONNSecurityProfile leveraging the AssociateSecurityProfiles service API.
    * Added cmdlet Add-CONNWorkspace leveraging the AssociateWorkspace service API.
    * Added cmdlet Get-CONNDataTableAttributeDetail leveraging the DescribeDataTableAttribute service API.
    * Added cmdlet Get-CONNDataTableAttributeList leveraging the ListDataTableAttributes service API.
    * Added cmdlet Get-CONNDataTableDetail leveraging the DescribeDataTable service API.
    * Added cmdlet Get-CONNDataTableList leveraging the ListDataTables service API.
    * Added cmdlet Get-CONNDataTablePrimaryValueList leveraging the ListDataTablePrimaryValues service API.
    * Added cmdlet Get-CONNDataTableValueDetailBatch leveraging the BatchDescribeDataTableValue service API.
    * Added cmdlet Get-CONNDataTableValueEvaluation leveraging the EvaluateDataTableValues service API.
    * Added cmdlet Get-CONNDataTableValueList leveraging the ListDataTableValues service API.
    * Added cmdlet Get-CONNEntitySecurityProfileList leveraging the ListEntitySecurityProfiles service API.
    * Added cmdlet Get-CONNSecurityProfileFlowModuleList leveraging the ListSecurityProfileFlowModules service API.
    * Added cmdlet Get-CONNWorkspaceDetail leveraging the DescribeWorkspace service API.
    * Added cmdlet Get-CONNWorkspaceList leveraging the ListWorkspaces service API.
    * Added cmdlet Get-CONNWorkspaceMediaList leveraging the ListWorkspaceMedia service API.
    * Added cmdlet Get-CONNWorkspacePageList leveraging the ListWorkspacePages service API.
    * Added cmdlet Import-CONNWorkspaceMedia leveraging the ImportWorkspaceMedia service API.
    * Added cmdlet New-CONNDataTable leveraging the CreateDataTable service API.
    * Added cmdlet New-CONNDataTableAttribute leveraging the CreateDataTableAttribute service API.
    * Added cmdlet New-CONNDataTableValueBatch leveraging the BatchCreateDataTableValue service API.
    * Added cmdlet New-CONNWorkspace leveraging the CreateWorkspace service API.
    * Added cmdlet New-CONNWorkspacePage leveraging the CreateWorkspacePage service API.
    * Added cmdlet Remove-CONNDataTable leveraging the DeleteDataTable service API.
    * Added cmdlet Remove-CONNDataTableAttribute leveraging the DeleteDataTableAttribute service API.
    * Added cmdlet Remove-CONNDataTableValueBatch leveraging the BatchDeleteDataTableValue service API.
    * Added cmdlet Remove-CONNWorkspace leveraging the DeleteWorkspace service API.
    * Added cmdlet Remove-CONNWorkspaceMedia leveraging the DeleteWorkspaceMedia service API.
    * Added cmdlet Remove-CONNWorkspacePage leveraging the DeleteWorkspacePage service API.
    * Added cmdlet Search-CONNDataTable leveraging the SearchDataTables service API.
    * Added cmdlet Search-CONNView leveraging the SearchViews service API.
    * Added cmdlet Search-CONNWorkspace leveraging the SearchWorkspaces service API.
    * Added cmdlet Search-CONNWorkspaceAssociation leveraging the SearchWorkspaceAssociations service API.
    * Added cmdlet Start-CONNContactMediaProcessing leveraging the StartContactMediaProcessing service API.
    * Added cmdlet Stop-CONNContactMediaProcessing leveraging the StopContactMediaProcessing service API.
    * Added cmdlet Unregister-CONNSecurityProfile leveraging the DisassociateSecurityProfiles service API.
    * Added cmdlet Unregister-CONNWorkspace leveraging the DisassociateWorkspace service API.
    * Added cmdlet Update-CONNDataTableAttribute leveraging the UpdateDataTableAttribute service API.
    * Added cmdlet Update-CONNDataTableMetadata leveraging the UpdateDataTableMetadata service API.
    * Added cmdlet Update-CONNDataTablePrimaryValue leveraging the UpdateDataTablePrimaryValues service API.
    * Added cmdlet Update-CONNDataTableValueBatch leveraging the BatchUpdateDataTableValue service API.
    * Added cmdlet Update-CONNWorkspaceMetadata leveraging the UpdateWorkspaceMetadata service API.
    * Added cmdlet Update-CONNWorkspacePage leveraging the UpdateWorkspacePage service API.
    * Added cmdlet Update-CONNWorkspaceTheme leveraging the UpdateWorkspaceTheme service API.
    * Added cmdlet Update-CONNWorkspaceVisibility leveraging the UpdateWorkspaceVisibility service API.
    * Modified cmdlet New-CONNEvaluationForm: added parameters AsDraft, LanguageConfiguration_FormLanguage and TargetConfiguration_ContactInteractionType.
    * Modified cmdlet New-CONNQuickConnect: added parameter FlowConfig_ContactFlowId.
    * Modified cmdlet New-CONNSecurityProfile: added parameters AllowedFlowModule and PrimaryAttributeAccessControlConfiguration_PrimaryAttributeValue.
    * Modified cmdlet Search-CONNContactFlow: added parameters AndCondition_TagCondition, FlowAttributeFilter_OrCondition, SearchFilter_FlowAttributeFilter_AndCondition_ContactFlowTypeCondition_ContactFlowType, SearchFilter_FlowAttributeFilter_ContactFlowTypeCondition_ContactFlowType, SearchFilter_FlowAttributeFilter_TagCondition_TagKey and SearchFilter_FlowAttributeFilter_TagCondition_TagValue.
    * Modified cmdlet Start-CONNChatContact: added parameter ParticipantConfiguration_ResponseMode.
    * Modified cmdlet Update-CONNEvaluationForm: added parameters AsDraft, LanguageConfiguration_FormLanguage and TargetConfiguration_ContactInteractionType.
    * Modified cmdlet Update-CONNQuickConnectConfig: added parameter FlowConfig_ContactFlowId.
    * Modified cmdlet Update-CONNSecurityProfile: added parameters AllowedFlowModule and PrimaryAttributeAccessControlConfiguration_PrimaryAttributeValue.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSCapabilityDetail leveraging the DescribeCapability service API.
    * Added cmdlet Get-EKSCapabilityList leveraging the ListCapabilities service API.
    * Added cmdlet New-EKSCapability leveraging the CreateCapability service API.
    * Added cmdlet Remove-EKSCapability leveraging the DeleteCapability service API.
    * Added cmdlet Update-EKSCapability leveraging the UpdateCapability service API.
    * Modified cmdlet Get-EKSUpdate: added parameter CapabilityName.
    * Modified cmdlet Get-EKSUpdateList: added parameter CapabilityName.
  * Amazon Lambda
    * Added cmdlet Get-LMCapacityProvider leveraging the GetCapacityProvider service API.
    * Added cmdlet Get-LMCapacityProviderList leveraging the ListCapacityProviders service API.
    * Added cmdlet Get-LMFunctionScalingConfig leveraging the GetFunctionScalingConfig service API.
    * Added cmdlet Get-LMFunctionVersionsByCapacityProviderList leveraging the ListFunctionVersionsByCapacityProvider service API.
    * Added cmdlet New-LMCapacityProvider leveraging the CreateCapacityProvider service API.
    * Added cmdlet Remove-LMCapacityProvider leveraging the DeleteCapacityProvider service API.
    * Added cmdlet Update-LMCapacityProvider leveraging the UpdateCapacityProvider service API.
    * Added cmdlet Write-LMFunctionScalingConfig leveraging the PutFunctionScalingConfig service API.
    * Modified cmdlet Publish-LMFunction: added parameters LambdaManagedInstancesCapacityProviderConfig_CapacityProviderArn, LambdaManagedInstancesCapacityProviderConfig_ExecutionEnvironmentMemoryGiBPerVCpu, LambdaManagedInstancesCapacityProviderConfig_PerExecutionEnvironmentMaxConcurrency and PublishTo.
    * Modified cmdlet Update-LMFunctionCode: added parameter PublishTo.
    * Modified cmdlet Publish-LMVersion: added parameter PublishTo.
    * Modified cmdlet Update-LMFunctionConfiguration: added parameters LambdaManagedInstancesCapacityProviderConfig_CapacityProviderArn, LambdaManagedInstancesCapacityProviderConfig_ExecutionEnvironmentMemoryGiBPerVCpu and LambdaManagedInstancesCapacityProviderConfig_PerExecutionEnvironmentMaxConcurrency.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameters DeepgramConfig_ApiTokenSecretArn, DeepgramConfig_ModelId, SpeechFoundationModel_ModelArn, SpeechFoundationModel_VoiceId and SpeechRecognitionSettings_SpeechModelPreference.
    * Modified cmdlet Start-LMBV2Import: added parameters DeepgramConfig_ApiTokenSecretArn, DeepgramConfig_ModelId, SpeechFoundationModel_ModelArn, SpeechFoundationModel_VoiceId and SpeechRecognitionSettings_SpeechModelPreference.
    * Modified cmdlet Update-LMBV2BotLocale: added parameters DeepgramConfig_ApiTokenSecretArn, DeepgramConfig_ModelId, SpeechFoundationModel_ModelArn, SpeechFoundationModel_VoiceId and SpeechRecognitionSettings_SpeechModelPreference.
  * Amazon Marketplace Catalog Service
    * Modified cmdlet Get-MCATEntityList: added parameters AssociatedOfferIds_ValueList, EntityTypeFilters_OfferSetFilters_EntityId_ValueList, EntityTypeFilters_OfferSetFilters_LastModifiedDate_DateRange_AfterValue, EntityTypeFilters_OfferSetFilters_LastModifiedDate_DateRange_BeforeValue, EntityTypeFilters_OfferSetFilters_ReleaseDate_DateRange_AfterValue, EntityTypeFilters_OfferSetFilters_ReleaseDate_DateRange_BeforeValue, EntityTypeFilters_OfferSetFilters_State_ValueList, Name_ValueList, OfferSetId_ValueList, OfferSetSort_SortBy, OfferSetSort_SortOrder and SolutionId_ValueList.
  * Amazon Partner Central Account API. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PCAA and can be listed using the command 'Get-AWSCmdletName -Service PCAA'.
  * Amazon Partner Central Selling API
    * Added cmdlet Get-PCOpportunityFromEngagementTaskList leveraging the ListOpportunityFromEngagementTasks service API.
    * Added cmdlet New-PCEngagementContext leveraging the CreateEngagementContext service API.
    * Added cmdlet Start-PCOpportunityFromEngagementTask leveraging the StartOpportunityFromEngagementTask service API.
    * Added cmdlet Update-PCEngagementContext leveraging the UpdateEngagementContext service API.
    * Modified cmdlet Get-PCEngagementList: added parameters ContextType and ExcludeContextType.
    * Modified cmdlet Invoke-PCAssignOpportunity: added parameter Assignee_Phone.
    * Modified cmdlet Invoke-PCCreateEngagementInvitation: added parameters Customer_AwsMaturity, Customer_MarketSegment, Interaction_ContactBusinessTitle, Interaction_SourceId, Interaction_SourceName, Interaction_SourceType, Interaction_Usecase, LeadInvitation_Customer_CompanyName, LeadInvitation_Customer_CountryCode, LeadInvitation_Customer_Industry and LeadInvitation_Customer_WebsiteUrl.
  * Amazon PartnerCentral Benefits Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PCB and can be listed using the command 'Get-AWSCmdletName -Service PCB'.
  * Amazon Personalize
    * Modified cmdlet New-PERSBatchInferenceJob: added parameter BatchInferenceJobConfig_RankingInfluence.
    * Modified cmdlet New-PERSCampaign: added parameter CampaignConfig_RankingInfluence.
    * Modified cmdlet New-PERSRecommender: added parameter TrainingDataConfig_IncludedDatasetColumn.
    * Modified cmdlet New-PERSSolution: added parameters PerformIncrementalUpdate and TrainingDataConfig_IncludedDatasetColumn.
    * Modified cmdlet Update-PERSCampaign: added parameter CampaignConfig_RankingInfluence.
    * Modified cmdlet Update-PERSRecommender: added parameter TrainingDataConfig_IncludedDatasetColumn.
    * Modified cmdlet Update-PERSSolution: added parameter PerformIncrementalUpdate.
  * Amazon Q Connect
    * Added cmdlet Get-QCSpanList leveraging the ListSpans service API.
    * Added cmdlet Invoke-QCRetrieve leveraging the Retrieve service API.
    * Modified cmdlet Get-QCMessageList: added parameter Filter.
    * Modified cmdlet Get-QCRecommendation: added parameter RecommendationType.
    * Modified cmdlet New-QCAIAgent: added parameters AnswerRecommendationAIAgentConfiguration_SuggestedMessage, CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId, CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId, CaseSummarizationAIAgentConfiguration_Locale, NoteTakingAIAgentConfiguration_Locale, NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId, NoteTakingAIAgentConfiguration_NoteTakingAIPromptId, OrchestrationAIAgentConfiguration_ConnectInstanceArn, OrchestrationAIAgentConfiguration_Locale, OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId, OrchestrationAIAgentConfiguration_OrchestrationAIPromptId and OrchestrationAIAgentConfiguration_ToolConfiguration.
    * Modified cmdlet New-QCAIPrompt: added parameters TextAIPromptInferenceConfiguration_MaxTokensToSample, TextAIPromptInferenceConfiguration_Temperature, TextAIPromptInferenceConfiguration_TopK and TextAIPromptInferenceConfiguration_TopP.
    * Modified cmdlet New-QCAssistantAssociation: added parameters ExternalBedrockKnowledgeBaseConfig_AccessRoleArn and ExternalBedrockKnowledgeBaseConfig_BedrockKnowledgeBaseArn.
    * Modified cmdlet New-QCSession: added parameters OrchestratorConfigurationList and RemoveOrchestratorConfigurationList.
    * Modified cmdlet Remove-QCAssistantAIAgent: added parameter OrchestratorUseCase.
    * Modified cmdlet Search-QCAssistant: added parameter CaseSummarizationInputData_CaseArn.
    * Modified cmdlet Send-QCMessage: added parameters AiAgentId, AiGuardrailAssessment_Blocked, Configuration_GenerateChunkedMessage, Metadata, OrchestratorUseCase, Text_Citation, ToolUseResult_InputSchema, ToolUseResult_ToolName, ToolUseResult_ToolResult and ToolUseResult_ToolUseId.
    * Modified cmdlet Update-QCAIAgent: added parameters AnswerRecommendationAIAgentConfiguration_SuggestedMessage, CaseSummarizationAIAgentConfiguration_CaseSummarizationAIGuardrailId, CaseSummarizationAIAgentConfiguration_CaseSummarizationAIPromptId, CaseSummarizationAIAgentConfiguration_Locale, NoteTakingAIAgentConfiguration_Locale, NoteTakingAIAgentConfiguration_NoteTakingAIGuardrailId, NoteTakingAIAgentConfiguration_NoteTakingAIPromptId, OrchestrationAIAgentConfiguration_ConnectInstanceArn, OrchestrationAIAgentConfiguration_Locale, OrchestrationAIAgentConfiguration_OrchestrationAIGuardrailId, OrchestrationAIAgentConfiguration_OrchestrationAIPromptId and OrchestrationAIAgentConfiguration_ToolConfiguration.
    * Modified cmdlet Update-QCAIPrompt: added parameters TextAIPromptInferenceConfiguration_MaxTokensToSample, TextAIPromptInferenceConfiguration_Temperature, TextAIPromptInferenceConfiguration_TopK and TextAIPromptInferenceConfiguration_TopP.
    * Modified cmdlet Update-QCAssistantAIAgent: added parameter OrchestratorConfigurationList.
    * Modified cmdlet Update-QCSession: added parameters OrchestratorConfigurationList and RemoveOrchestratorConfigurationList.
  * Amazon Route 53 Global Resolver. Added cmdlets to support the service. Cmdlets for the service have the noun prefix R53GR and can be listed using the command 'Get-AWSCmdletName -Service R53GR'.

### 5.0.106 (2025-11-26 20:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.142.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.105 (2025-11-25 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.141.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Network Firewall
    * Added cmdlet Dismount-NWFWRuleGroupsFromProxyConfiguration leveraging the DetachRuleGroupsFromProxyConfiguration service API.
    * Added cmdlet Get-NWFWProxyConfigurationDetail leveraging the DescribeProxyConfiguration service API.
    * Added cmdlet Get-NWFWProxyConfigurationList leveraging the ListProxyConfigurations service API.
    * Added cmdlet Get-NWFWProxyDetail leveraging the DescribeProxy service API.
    * Added cmdlet Get-NWFWProxyList leveraging the ListProxies service API.
    * Added cmdlet Get-NWFWProxyRuleDetail leveraging the DescribeProxyRule service API.
    * Added cmdlet Get-NWFWProxyRuleGroupDetail leveraging the DescribeProxyRuleGroup service API.
    * Added cmdlet Get-NWFWProxyRuleGroupList leveraging the ListProxyRuleGroups service API.
    * Added cmdlet Mount-NWFWRuleGroupsToProxyConfiguration leveraging the AttachRuleGroupsToProxyConfiguration service API.
    * Added cmdlet New-NWFWProxy leveraging the CreateProxy service API.
    * Added cmdlet New-NWFWProxyConfiguration leveraging the CreateProxyConfiguration service API.
    * Added cmdlet New-NWFWProxyRule leveraging the CreateProxyRules service API.
    * Added cmdlet New-NWFWProxyRuleGroup leveraging the CreateProxyRuleGroup service API.
    * Added cmdlet Remove-NWFWProxy leveraging the DeleteProxy service API.
    * Added cmdlet Remove-NWFWProxyConfiguration leveraging the DeleteProxyConfiguration service API.
    * Added cmdlet Remove-NWFWProxyRule leveraging the DeleteProxyRules service API.
    * Added cmdlet Remove-NWFWProxyRuleGroup leveraging the DeleteProxyRuleGroup service API.
    * Added cmdlet Update-NWFWProxy leveraging the UpdateProxy service API.
    * Added cmdlet Update-NWFWProxyConfiguration leveraging the UpdateProxyConfiguration service API.
    * Added cmdlet Update-NWFWProxyRule leveraging the UpdateProxyRule service API.
    * Added cmdlet Update-NWFWProxyRuleGroupPriority leveraging the UpdateProxyRuleGroupPriorities service API.
    * Added cmdlet Update-NWFWProxyRulePriority leveraging the UpdateProxyRulePriorities service API.
  * Amazon Route 53
    * Added cmdlet Update-R53HostedZoneFeature leveraging the UpdateHostedZoneFeatures service API.

### 5.0.104 (2025-11-24 20:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.140.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFront
    * Added cmdlet Get-CFConnectionFunction leveraging the GetConnectionFunction service API.
    * Added cmdlet Get-CFConnectionFunctionSummary leveraging the DescribeConnectionFunction service API.
    * Added cmdlet Get-CFDistributionsByConnectionFunction leveraging the ListDistributionsByConnectionFunction service API.
    * Added cmdlet Get-CFDistributionsByTrustStore leveraging the ListDistributionsByTrustStore service API.
    * Added cmdlet Get-CFListConnectionFunction leveraging the ListConnectionFunctions service API.
    * Added cmdlet Get-CFListTrustStore leveraging the ListTrustStores service API.
    * Added cmdlet Get-CFTrustStore leveraging the GetTrustStore service API.
    * Added cmdlet New-CFConnectionFunction leveraging the CreateConnectionFunction service API.
    * Added cmdlet New-CFTrustStore leveraging the CreateTrustStore service API.
    * Added cmdlet Publish-CFConnectionFunction leveraging the PublishConnectionFunction service API.
    * Added cmdlet Remove-CFConnectionFunction leveraging the DeleteConnectionFunction service API.
    * Added cmdlet Remove-CFTrustStore leveraging the DeleteTrustStore service API.
    * Added cmdlet Test-CFConnectionFunction leveraging the TestConnectionFunction service API.
    * Added cmdlet Update-CFConnectionFunction leveraging the UpdateConnectionFunction service API.
    * Added cmdlet Update-CFTrustStore leveraging the UpdateTrustStore service API.
    * Modified cmdlet New-CFDistribution: added parameters ConnectionFunctionAssociation_Id, TrustStoreConfig_AdvertiseTrustStoreCaName, TrustStoreConfig_IgnoreCertificateExpiry, TrustStoreConfig_TrustStoreId and ViewerMtlsConfig_Mode.
    * Modified cmdlet New-CFDistributionWithTag: added parameters ConnectionFunctionAssociation_Id, TrustStoreConfig_AdvertiseTrustStoreCaName, TrustStoreConfig_IgnoreCertificateExpiry, TrustStoreConfig_TrustStoreId and ViewerMtlsConfig_Mode.
    * Modified cmdlet Update-CFDistribution: added parameters ConnectionFunctionAssociation_Id, TrustStoreConfig_AdvertiseTrustStoreCaName, TrustStoreConfig_IgnoreCertificateExpiry, TrustStoreConfig_TrustStoreId and ViewerMtlsConfig_Mode.
  * Amazon CloudWatch Logs
    * Added cmdlet Write-CWLLogGroupDeletionProtection leveraging the PutLogGroupDeletionProtection service API.
    * Modified cmdlet New-CWLLogGroup: added parameter DeletionProtectionEnabled.

### 5.0.103 (2025-11-21 23:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.139.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Modified cmdlet Write-AGIntegration: added parameter IntegrationTarget.
  * Amazon Athena
    * Added cmdlet Get-ATHResourceDashboard leveraging the GetResourceDashboard service API.
    * Added cmdlet Get-ATHSessionEndpoint leveraging the GetSessionEndpoint service API.
    * Modified cmdlet New-ATHWorkGroup: added parameters CloudWatchLoggingConfiguration_Enabled, CloudWatchLoggingConfiguration_LogGroup, CloudWatchLoggingConfiguration_LogStreamNamePrefix, CloudWatchLoggingConfiguration_LogType, EngineConfiguration_AdditionalConfig, EngineConfiguration_Classification, EngineConfiguration_CoordinatorDpuSize, EngineConfiguration_DefaultExecutorDpuSize, EngineConfiguration_MaxConcurrentDpus, EngineConfiguration_SparkProperty, ManagedLoggingConfiguration_Enabled, ManagedLoggingConfiguration_KmsKey, S3LoggingConfiguration_Enabled, S3LoggingConfiguration_KmsKey and S3LoggingConfiguration_LogLocation.
    * Modified cmdlet Start-ATHQueryExecution: added parameters EngineConfiguration_AdditionalConfig, EngineConfiguration_Classification, EngineConfiguration_CoordinatorDpuSize, EngineConfiguration_DefaultExecutorDpuSize, EngineConfiguration_MaxConcurrentDpus and EngineConfiguration_SparkProperty.
    * Modified cmdlet Start-ATHSession: added parameters CloudWatchLoggingConfiguration_Enabled, CloudWatchLoggingConfiguration_LogGroup, CloudWatchLoggingConfiguration_LogStreamNamePrefix, CloudWatchLoggingConfiguration_LogType, CopyWorkGroupTag, EngineConfiguration_Classification, ExecutionRole, ManagedLoggingConfiguration_Enabled, ManagedLoggingConfiguration_KmsKey, S3LoggingConfiguration_Enabled, S3LoggingConfiguration_KmsKey, S3LoggingConfiguration_LogLocation and Tag.
    * Modified cmdlet Update-ATHWorkGroup: added parameters CloudWatchLoggingConfiguration_Enabled, CloudWatchLoggingConfiguration_LogGroup, CloudWatchLoggingConfiguration_LogStreamNamePrefix, CloudWatchLoggingConfiguration_LogType, EngineConfiguration_AdditionalConfig, EngineConfiguration_Classification, EngineConfiguration_CoordinatorDpuSize, EngineConfiguration_DefaultExecutorDpuSize, EngineConfiguration_MaxConcurrentDpus, EngineConfiguration_SparkProperty, ManagedLoggingConfiguration_Enabled, ManagedLoggingConfiguration_KmsKey, S3LoggingConfiguration_Enabled, S3LoggingConfiguration_KmsKey and S3LoggingConfiguration_LogLocation.
  * Amazon Bedrock
    * Added cmdlet Get-BDREnforcedGuardrailsConfigurationList leveraging the ListEnforcedGuardrailsConfiguration service API.
    * Added cmdlet Remove-BDREnforcedGuardrailConfiguration leveraging the DeleteEnforcedGuardrailConfiguration service API.
    * Added cmdlet Write-BDREnforcedGuardrailConfiguration leveraging the PutEnforcedGuardrailConfiguration service API.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCGateway: added parameter InterceptorConfiguration.
    * Modified cmdlet Update-BACCGateway: added parameter InterceptorConfiguration.
  * Amazon CloudFormation
    * Modified cmdlet New-CFNStackSet: added parameter AutoDeployment_DependsOn.
    * Modified cmdlet Update-CFNStackSet: added parameter AutoDeployment_DependsOn.
  * Amazon Compute Optimizer Automation Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix COA and can be listed using the command 'Get-AWSCmdletName -Service COA'.
  * Amazon Connect Service
    * Added cmdlet Get-CONNContactFlowModuleAliasDetail leveraging the DescribeContactFlowModuleAlias service API.
    * Added cmdlet Get-CONNContactFlowModuleAliasList leveraging the ListContactFlowModuleAliases service API.
    * Added cmdlet Get-CONNContactFlowModuleVersionList leveraging the ListContactFlowModuleVersions service API.
    * Added cmdlet New-CONNContactFlowModuleAlias leveraging the CreateContactFlowModuleAlias service API.
    * Added cmdlet New-CONNContactFlowModuleVersion leveraging the CreateContactFlowModuleVersion service API.
    * Added cmdlet Remove-CONNContactFlowModuleAlias leveraging the DeleteContactFlowModuleAlias service API.
    * Added cmdlet Remove-CONNContactFlowModuleVersion leveraging the DeleteContactFlowModuleVersion service API.
    * Added cmdlet Update-CONNContactFlowModuleAlias leveraging the UpdateContactFlowModuleAlias service API.
    * Modified cmdlet New-CONNContactFlowModule: added parameters ExternalInvocationConfiguration_Enabled and Setting.
    * Modified cmdlet Update-CONNContactFlowModuleContent: added parameter Setting.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRImageSigningStatusDetail leveraging the DescribeImageSigningStatus service API.
    * Added cmdlet Get-ECRSigningConfiguration leveraging the GetSigningConfiguration service API.
    * Added cmdlet Remove-ECRSigningConfiguration leveraging the DeleteSigningConfiguration service API.
    * Added cmdlet Write-ECRSigningConfiguration leveraging the PutSigningConfiguration service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet New-EC2InterruptibleCapacityReservationAllocation leveraging the CreateInterruptibleCapacityReservationAllocation service API.
    * Added cmdlet Update-EC2InterruptibleCapacityReservationAllocation leveraging the UpdateInterruptibleCapacityReservationAllocation service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter ControlPlaneScalingConfig_Tier.
    * Modified cmdlet Update-EKSClusterConfig: added parameter ControlPlaneScalingConfig_Tier.
  * Amazon Invoicing
    * Added cmdlet Get-INVProcurementPortalPreference leveraging the GetProcurementPortalPreference service API.
    * Added cmdlet Get-INVProcurementPortalPreferenceList leveraging the ListProcurementPortalPreferences service API.
    * Added cmdlet New-INVProcurementPortalPreference leveraging the CreateProcurementPortalPreference service API.
    * Added cmdlet Remove-INVProcurementPortalPreference leveraging the DeleteProcurementPortalPreference service API.
    * Added cmdlet Update-INVProcurementPortalPreferenceStatus leveraging the UpdateProcurementPortalPreferenceStatus service API.
    * Added cmdlet Write-INVProcurementPortalPreference leveraging the PutProcurementPortalPreference service API.
  * Amazon Kinesis Video Streams
    * Added cmdlet Get-KVStreamStorageConfigurationDetail leveraging the DescribeStreamStorageConfiguration service API.
    * Added cmdlet Update-KVStreamStorageConfiguration leveraging the UpdateStreamStorageConfiguration service API.
    * Modified cmdlet New-KVStream: added parameter StreamStorageConfiguration_DefaultStorageTier.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter ProvisionedPollerConfig_PollerGroupName.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter ProvisionedPollerConfig_PollerGroupName.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameters IntentDisambiguationSettings_CustomDisambiguationMessage, IntentDisambiguationSettings_Enabled, IntentDisambiguationSettings_MaxDisambiguationIntent and SpeechDetectionSensitivity.
    * Modified cmdlet New-LMBV2Intent: added parameter IntentDisplayName.
    * Modified cmdlet Start-LMBV2Import: added parameter BotLocaleImportSpecification_SpeechDetectionSensitivity.
    * Modified cmdlet Update-LMBV2BotLocale: added parameters IntentDisambiguationSettings_CustomDisambiguationMessage, IntentDisambiguationSettings_Enabled, IntentDisambiguationSettings_MaxDisambiguationIntent and SpeechDetectionSensitivity.
    * Modified cmdlet Update-LMBV2Intent: added parameter IntentDisplayName.
  * Amazon Oracle Database@Amazon Web Services
    * Added cmdlet Add-ODBIamRoleToResource leveraging the AssociateIamRoleToResource service API.
    * Added cmdlet Remove-ODBIamRoleFromResource leveraging the DisassociateIamRoleFromResource service API.
    * Modified cmdlet Initialize-ODBService: added parameter OciIdentityDomain.
    * Modified cmdlet New-ODBOdbNetwork: added parameters CrossRegionS3RestoreSourcesToEnable, KmsAccess, KmsPolicyDocument, StsAccess and StsPolicyDocument.
    * Modified cmdlet Update-ODBOdbNetwork: added parameters CrossRegionS3RestoreSourcesToDisable, CrossRegionS3RestoreSourcesToEnable, KmsAccess, KmsPolicyDocument, StsAccess and StsPolicyDocument.
  * Amazon Q Connect
    * Modified cmdlet New-QCMessageTemplate: added parameters Adm_Action, Adm_ImageIconUrl, Adm_ImageUrl, Adm_SmallImageIconUrl, Adm_Sound, Adm_Title, Adm_Url, Apns_Action, Apns_MediaUrl, Apns_Sound, Apns_Title, Apns_Url, Baidu_Action, Baidu_ImageIconUrl, Baidu_ImageUrl, Baidu_SmallImageIconUrl, Baidu_Sound, Baidu_Title, Baidu_Url, Content_Push_Adm_Body_Content, Content_Push_Adm_RawContent_Content, Content_Push_Apns_Body_Content, Content_Push_Apns_RawContent_Content, Content_Push_Baidu_Body_Content, Content_Push_Baidu_RawContent_Content, Content_Push_Fcm_Body_Content, Content_Push_Fcm_RawContent_Content, Fcm_Action, Fcm_ImageIconUrl, Fcm_ImageUrl, Fcm_SmallImageIconUrl, Fcm_Sound, Fcm_Title, Fcm_Url, WhatsApp_BusinessAccountId, WhatsApp_Component, WhatsApp_Data and WhatsApp_TemplateId.
    * Modified cmdlet Update-QCMessageTemplate: added parameters Adm_Action, Adm_ImageIconUrl, Adm_ImageUrl, Adm_SmallImageIconUrl, Adm_Sound, Adm_Title, Adm_Url, Apns_Action, Apns_MediaUrl, Apns_Sound, Apns_Title, Apns_Url, Baidu_Action, Baidu_ImageIconUrl, Baidu_ImageUrl, Baidu_SmallImageIconUrl, Baidu_Sound, Baidu_Title, Baidu_Url, Content_Push_Adm_Body_Content, Content_Push_Adm_RawContent_Content, Content_Push_Apns_Body_Content, Content_Push_Apns_RawContent_Content, Content_Push_Baidu_Body_Content, Content_Push_Baidu_RawContent_Content, Content_Push_Fcm_Body_Content, Content_Push_Fcm_RawContent_Content, Fcm_Action, Fcm_ImageIconUrl, Fcm_ImageUrl, Fcm_SmallImageIconUrl, Fcm_Sound, Fcm_Title, Fcm_Url, WhatsApp_BusinessAccountId, WhatsApp_Component, WhatsApp_Data and WhatsApp_TemplateId.
  * Amazon QuickSight
    * Modified cmdlet Initialize-QSEmbedUrlForRegisteredUserWithIdentity: added parameter ExperienceConfiguration_QuickChat.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameter ExperienceConfiguration_QuickChat.
  * Amazon Redshift
    * Added cmdlet Edit-RSLakehouseConfiguration leveraging the ModifyLakehouseConfiguration service API.
    * Modified cmdlet New-RSCluster: added parameter CatalogName.
    * Modified cmdlet New-RSRedshiftIdcApplication: added parameter ApplicationType.
    * Modified cmdlet Restore-RSFromClusterSnapshot: added parameters CatalogName and RedshiftIdcApplicationArn.
  * Amazon Redshift Serverless
    * Added cmdlet Update-RSSLakehouseConfiguration leveraging the UpdateLakehouseConfiguration service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMOptimizationJob: added parameters MaxInstanceCount, ModelSource_SageMakerModel_ModelName and OutputConfig_SageMakerModel_ModelName.
  * Amazon Security Incident Response
    * Added cmdlet Get-SecurityIRInvestigationList leveraging the ListInvestigations service API.
    * Added cmdlet Send-SecurityIRFeedback leveraging the SendFeedback service API.
    * Modified cmdlet Update-SecurityIRCase: added parameter CaseMetadata.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRWebApp: added parameters Vpc_SecurityGroupId, Vpc_SubnetId and Vpc_VpcId.
    * Modified cmdlet Update-TFRWebApp: added parameter Vpc_SubnetId.

### 5.0.102 (2025-11-20 22:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.138.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter RetentionTriggers_TerminateHookAbandon.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter RetentionTriggers_TerminateHookAbandon.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Get-BACMemoryExtractionJobList leveraging the ListMemoryExtractionJobs service API.
    * Added cmdlet Start-BACMemoryExtractionJob leveraging the StartMemoryExtractionJob service API.
  * Amazon Braket
    * Added cmdlet New-BRKTSpendingLimit leveraging the CreateSpendingLimit service API.
    * Added cmdlet Remove-BRKTSpendingLimit leveraging the DeleteSpendingLimit service API.
    * Added cmdlet Search-BRKTSpendingLimit leveraging the SearchSpendingLimits service API.
    * Added cmdlet Update-BRKTSpendingLimit leveraging the UpdateSpendingLimit service API.
  * Amazon CloudFront
    * Modified cmdlet New-CFAnycastIpList: added parameter IpamCidrConfig.
  * Amazon CloudTrail
    * Modified cmdlet Get-CTEventConfiguration: added parameter TrailName.
    * Modified cmdlet Write-CTEventConfiguration: added parameters AggregationConfiguration and TrailName.
  * Amazon CloudWatch Application Signals
    * Added cmdlet Get-CWASEntityEventList leveraging the ListEntityEvents service API.
    * Modified cmdlet Get-CWASAuditFindingList: added parameter DetailLevel.
    * Modified cmdlet Get-CWASGroupingAttributeDefinitionList: added parameters AwsAccountId and IncludeLinkedAccount.
  * Amazon Data Automation for Amazon Bedrock
    * Modified cmdlet New-BDADataAutomationProject: added parameters OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode, OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode, OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode, OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode and ProjectType.
    * Modified cmdlet Update-BDADataAutomationProject: added parameters OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode, OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode, OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes, OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode, OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode, OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionScope, OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_PiiEntityTypes and OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode.
  * Amazon Database Migration Service
    * Modified cmdlet Import-DMSCertificate: added parameter KmsKeyId.
  * Amazon Device Farm
    * Modified cmdlet Get-DFDevicePoolCompatibility: added parameters Configuration_EnvironmentVariable and Configuration_ExecutionRoleArn.
    * Modified cmdlet New-DFProject: added parameters EnvironmentVariable and ExecutionRoleArn.
    * Modified cmdlet Submit-DFTestRun: added parameters Configuration_EnvironmentVariable and Configuration_ExecutionRoleArn.
    * Modified cmdlet Update-DFProject: added parameters EnvironmentVariable and ExecutionRoleArn.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSExpressGatewayService leveraging the DescribeExpressGatewayService service API.
    * Added cmdlet New-ECSExpressGatewayService leveraging the CreateExpressGatewayService service API.
    * Added cmdlet Remove-ECSExpressGatewayService leveraging the DeleteExpressGatewayService service API.
    * Added cmdlet Update-ECSExpressGatewayService leveraging the UpdateExpressGatewayService service API.
    * Modified cmdlet Get-ECSClusterService: added parameter ResourceManagementType.
  * Amazon EC2 Image Builder
    * Added cmdlet Start-EC2IBImageDistribution leveraging the DistributeImage service API.
    * Added cmdlet Start-EC2IBImageRetry leveraging the RetryImage service API.
    * Modified cmdlet New-EC2IBComponent: added parameter DryRun.
    * Modified cmdlet New-EC2IBWorkflow: added parameter DryRun.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2TransitGatewayMeteringPolicy leveraging the ModifyTransitGatewayMeteringPolicy service API.
    * Added cmdlet Edit-EC2VpcEncryptionControl leveraging the ModifyVpcEncryptionControl service API.
    * Added cmdlet Get-EC2TransitGatewayMeteringPolicy leveraging the DescribeTransitGatewayMeteringPolicies service API.
    * Added cmdlet Get-EC2TransitGatewayMeteringPolicyEntry leveraging the GetTransitGatewayMeteringPolicyEntries service API.
    * Added cmdlet Get-EC2VolumesInRecycleBinList leveraging the ListVolumesInRecycleBin service API.
    * Added cmdlet Get-EC2VpcEncryptionControl leveraging the DescribeVpcEncryptionControls service API.
    * Added cmdlet Get-EC2VpcResourcesBlockingEncryptionEnforcement leveraging the GetVpcResourcesBlockingEncryptionEnforcement service API.
    * Added cmdlet New-EC2TransitGatewayMeteringPolicy leveraging the CreateTransitGatewayMeteringPolicy service API.
    * Added cmdlet New-EC2TransitGatewayMeteringPolicyEntry leveraging the CreateTransitGatewayMeteringPolicyEntry service API.
    * Added cmdlet New-EC2VpcEncryptionControl leveraging the CreateVpcEncryptionControl service API.
    * Added cmdlet Remove-EC2TransitGatewayMeteringPolicy leveraging the DeleteTransitGatewayMeteringPolicy service API.
    * Added cmdlet Remove-EC2TransitGatewayMeteringPolicyEntry leveraging the DeleteTransitGatewayMeteringPolicyEntry service API.
    * Added cmdlet Remove-EC2VpcEncryptionControl leveraging the DeleteVpcEncryptionControl service API.
    * Added cmdlet Restore-EC2VolumeFromRecycleBin leveraging the RestoreVolumeFromRecycleBin service API.
    * Modified cmdlet Edit-EC2TransitGateway: added parameter Options_EncryptionSupport.
    * Modified cmdlet Edit-EC2VpnTunnelOption: added parameters CloudWatchLogOptions_BgpLogEnabled, CloudWatchLogOptions_BgpLogGroupArn and CloudWatchLogOptions_BgpLogOutputFormat.
    * Modified cmdlet New-EC2Vpc: added parameters VpcEncryptionControl_EgressOnlyInternetGatewayExclusion, VpcEncryptionControl_ElasticFileSystemExclusion, VpcEncryptionControl_InternetGatewayExclusion, VpcEncryptionControl_LambdaExclusion, VpcEncryptionControl_Mode, VpcEncryptionControl_NatGatewayExclusion, VpcEncryptionControl_VirtualPrivateGatewayExclusion, VpcEncryptionControl_VpcLatticeExclusion and VpcEncryptionControl_VpcPeeringExclusion.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet New-ELB2TargetGroup: added parameter TargetControlPort.
  * Amazon Glue
    * Modified cmdlet Get-GLUEUserDefinedFunctionList: added parameter FunctionType.
  * Amazon Lake Formation
    * Modified cmdlet New-LKFLakeFormationIdentityCenterConfiguration: added parameter ServiceIntegration.
    * Modified cmdlet Update-LKFLakeFormationIdentityCenterConfiguration: added parameter ServiceIntegration.
  * Amazon License Manager
    * Added cmdlet Get-LICMAssetsForLicenseAssetGroupList leveraging the ListAssetsForLicenseAssetGroup service API.
    * Added cmdlet Get-LICMLicenseAssetGroup leveraging the GetLicenseAssetGroup service API.
    * Added cmdlet Get-LICMLicenseAssetGroupList leveraging the ListLicenseAssetGroups service API.
    * Added cmdlet Get-LICMLicenseAssetRuleset leveraging the GetLicenseAssetRuleset service API.
    * Added cmdlet Get-LICMLicenseAssetRulesetList leveraging the ListLicenseAssetRulesets service API.
    * Added cmdlet Get-LICMLicenseConfigurationsForOrganizationList leveraging the ListLicenseConfigurationsForOrganization service API.
    * Added cmdlet New-LICMLicenseAssetGroup leveraging the CreateLicenseAssetGroup service API.
    * Added cmdlet New-LICMLicenseAssetRuleset leveraging the CreateLicenseAssetRuleset service API.
    * Added cmdlet Remove-LICMLicenseAssetGroup leveraging the DeleteLicenseAssetGroup service API.
    * Added cmdlet Remove-LICMLicenseAssetRuleset leveraging the DeleteLicenseAssetRuleset service API.
    * Added cmdlet Update-LICMLicenseAssetGroup leveraging the UpdateLicenseAssetGroup service API.
    * Added cmdlet Update-LICMLicenseAssetRuleset leveraging the UpdateLicenseAssetRuleset service API.
    * Modified cmdlet New-LICMLicenseConfiguration: added parameter LicenseExpiry.
    * Modified cmdlet New-LICMLicenseManagerReportGenerator: added parameters ReportContext_LicenseAssetGroupArn, ReportContext_ReportEndDate and ReportContext_ReportStartDate.
    * Modified cmdlet Update-LICMLicenseConfiguration: added parameter LicenseExpiry.
    * Modified cmdlet Update-LICMLicenseManagerReportGenerator: added parameters ReportContext_LicenseAssetGroupArn, ReportContext_ReportEndDate and ReportContext_ReportStartDate.
    * Modified cmdlet Update-LICMServiceSetting: added parameter EnabledDiscoverySourceRegion.
  * Amazon Network Manager
    * Added cmdlet Get-NMGRAttachmentRoutingPolicyAssociationList leveraging the ListAttachmentRoutingPolicyAssociations service API.
    * Added cmdlet Get-NMGRCoreNetworkPrefixListAssociationList leveraging the ListCoreNetworkPrefixListAssociations service API.
    * Added cmdlet Get-NMGRCoreNetworkRoutingInformationList leveraging the ListCoreNetworkRoutingInformation service API.
    * Added cmdlet New-NMGRCoreNetworkPrefixListAssociation leveraging the CreateCoreNetworkPrefixListAssociation service API.
    * Added cmdlet Remove-NMGRAttachmentRoutingPolicyLabel leveraging the RemoveAttachmentRoutingPolicyLabel service API.
    * Added cmdlet Remove-NMGRCoreNetworkPrefixListAssociation leveraging the DeleteCoreNetworkPrefixListAssociation service API.
    * Added cmdlet Write-NMGRAttachmentRoutingPolicyLabel leveraging the PutAttachmentRoutingPolicyLabel service API.
    * Modified cmdlet New-NMGRConnectAttachment: added parameter RoutingPolicyLabel.
    * Modified cmdlet New-NMGRDirectConnectGatewayAttachment: added parameter RoutingPolicyLabel.
    * Modified cmdlet New-NMGRSiteToSiteVpnAttachment: added parameter RoutingPolicyLabel.
    * Modified cmdlet New-NMGRTransitGatewayRouteTableAttachment: added parameter RoutingPolicyLabel.
    * Modified cmdlet New-NMGRVpcAttachment: added parameter RoutingPolicyLabel.
  * Amazon Organizations
    * Added cmdlet Get-ORGInboundResponsibilityTransferList leveraging the ListInboundResponsibilityTransfers service API.
    * Added cmdlet Get-ORGOutboundResponsibilityTransferList leveraging the ListOutboundResponsibilityTransfers service API.
    * Added cmdlet Get-ORGResponsibilityTransfer leveraging the DescribeResponsibilityTransfer service API.
    * Added cmdlet New-ORGOrganizationToTransferResponsibility leveraging the InviteOrganizationToTransferResponsibility service API.
    * Added cmdlet Stop-ORGResponsibilityTransfer leveraging the TerminateResponsibilityTransfer service API.
    * Added cmdlet Update-ORGResponsibilityTransfer leveraging the UpdateResponsibilityTransfer service API.
  * Amazon QuickSight
    * Modified cmdlet New-QSTheme: added parameters AxisLabelFontConfiguration_FontColor, AxisLabelFontConfiguration_FontDecoration, AxisLabelFontConfiguration_FontFamily, AxisLabelFontConfiguration_FontStyle, AxisTitleFontConfiguration_FontColor, AxisTitleFontConfiguration_FontDecoration, AxisTitleFontConfiguration_FontFamily, AxisTitleFontConfiguration_FontStyle, Background_Color, Background_Gradient, Border_Color, Border_Width, Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute, Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative, Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name, Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute, Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative, Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name, Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute, Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative, Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name, Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute, Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative, Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name, Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute, Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative, Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name, DataLabelFontConfiguration_FontColor, DataLabelFontConfiguration_FontDecoration, DataLabelFontConfiguration_FontFamily, DataLabelFontConfiguration_FontStyle, LegendTitleFontConfiguration_FontColor, LegendTitleFontConfiguration_FontDecoration, LegendTitleFontConfiguration_FontFamily, LegendTitleFontConfiguration_FontStyle, LegendValueFontConfiguration_FontColor, LegendValueFontConfiguration_FontDecoration, LegendValueFontConfiguration_FontFamily, LegendValueFontConfiguration_FontStyle, Tile_BackgroundColor, Tile_BorderRadius, Tile_Padding, VisualSubtitleFontConfiguration_TextAlignment, VisualSubtitleFontConfiguration_TextTransform, VisualTitleFontConfiguration_TextAlignment and VisualTitleFontConfiguration_TextTransform.
    * Modified cmdlet Update-QSTheme: added parameters AxisLabelFontConfiguration_FontColor, AxisLabelFontConfiguration_FontDecoration, AxisLabelFontConfiguration_FontFamily, AxisLabelFontConfiguration_FontStyle, AxisTitleFontConfiguration_FontColor, AxisTitleFontConfiguration_FontDecoration, AxisTitleFontConfiguration_FontFamily, AxisTitleFontConfiguration_FontStyle, Background_Color, Background_Gradient, Border_Color, Border_Width, Configuration_Typography_AxisLabelFontConfiguration_FontSize_Absolute, Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative, Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name, Configuration_Typography_AxisTitleFontConfiguration_FontSize_Absolute, Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative, Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name, Configuration_Typography_DataLabelFontConfiguration_FontSize_Absolute, Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative, Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name, Configuration_Typography_LegendTitleFontConfiguration_FontSize_Absolute, Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative, Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name, Configuration_Typography_LegendValueFontConfiguration_FontSize_Absolute, Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative, Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontColor, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontFamily, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Absolute, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle, Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontColor, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontFamily, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Absolute, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle, Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name, DataLabelFontConfiguration_FontColor, DataLabelFontConfiguration_FontDecoration, DataLabelFontConfiguration_FontFamily, DataLabelFontConfiguration_FontStyle, LegendTitleFontConfiguration_FontColor, LegendTitleFontConfiguration_FontDecoration, LegendTitleFontConfiguration_FontFamily, LegendTitleFontConfiguration_FontStyle, LegendValueFontConfiguration_FontColor, LegendValueFontConfiguration_FontDecoration, LegendValueFontConfiguration_FontFamily, LegendValueFontConfiguration_FontStyle, Tile_BackgroundColor, Tile_BorderRadius, Tile_Padding, VisualSubtitleFontConfiguration_TextAlignment, VisualSubtitleFontConfiguration_TextTransform, VisualTitleFontConfiguration_TextAlignment and VisualTitleFontConfiguration_TextTransform.
  * Amazon Runtime for Amazon Bedrock Data Automation
    * Added cmdlet Invoke-BDARDataAutomation leveraging the InvokeDataAutomation service API.
  * Amazon SageMaker Service
    * Added cmdlet Set-SMBatchRebootClusterNode leveraging the BatchRebootClusterNodes service API.
    * Added cmdlet Set-SMBatchReplaceClusterNode leveraging the BatchReplaceClusterNodes service API.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBFindingsTrendsV2 leveraging the GetFindingsTrendsV2 service API.
    * Added cmdlet Get-SHUBResourcesTrendsV2 leveraging the GetResourcesTrendsV2 service API.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3BucketAbac leveraging the GetBucketAbac service API.
    * Added cmdlet Write-S3BucketAbac leveraging the PutBucketAbac service API.

### 5.0.101 (2025-11-19 23:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.137.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * 
    * Added cmdlet Invoke-AWSLogin.
    * Added cmdlet Invoke-AWSLogout.
  * Amazon AmazonConnectCampaignServiceV2
    * Modified cmdlet New-CCS2Campaign: added parameter DefaultOutboundConfig_RingTimeout.
    * Modified cmdlet Update-CCS2CampaignChannelSubtypeConfig: added parameter DefaultOutboundConfig_RingTimeout.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter EndpointAccessMode.
    * Modified cmdlet New-AGRestApi: added parameters EndpointAccessMode and SecurityPolicy.
    * Modified cmdlet Write-AGIntegration: added parameter ResponseTransferMode.
  * Amazon API Gateway V2
    * Added cmdlet Disable-AG2Portal leveraging the DisablePortal service API.
    * Added cmdlet Get-AG2Portal leveraging the GetPortal service API.
    * Added cmdlet Get-AG2PortalList leveraging the ListPortals service API.
    * Added cmdlet Get-AG2PortalProduct leveraging the GetPortalProduct service API.
    * Added cmdlet Get-AG2PortalProductList leveraging the ListPortalProducts service API.
    * Added cmdlet Get-AG2PortalProductSharingPolicy leveraging the GetPortalProductSharingPolicy service API.
    * Added cmdlet Get-AG2ProductPage leveraging the GetProductPage service API.
    * Added cmdlet Get-AG2ProductPageList leveraging the ListProductPages service API.
    * Added cmdlet Get-AG2ProductRestEndpointPage leveraging the GetProductRestEndpointPage service API.
    * Added cmdlet Get-AG2ProductRestEndpointPageList leveraging the ListProductRestEndpointPages service API.
    * Added cmdlet New-AG2Portal leveraging the CreatePortal service API.
    * Added cmdlet New-AG2PortalProduct leveraging the CreatePortalProduct service API.
    * Added cmdlet New-AG2ProductPage leveraging the CreateProductPage service API.
    * Added cmdlet New-AG2ProductRestEndpointPage leveraging the CreateProductRestEndpointPage service API.
    * Added cmdlet Publish-AG2Portal leveraging the PublishPortal service API.
    * Added cmdlet Remove-AG2Portal leveraging the DeletePortal service API.
    * Added cmdlet Remove-AG2PortalProduct leveraging the DeletePortalProduct service API.
    * Added cmdlet Remove-AG2PortalProductSharingPolicy leveraging the DeletePortalProductSharingPolicy service API.
    * Added cmdlet Remove-AG2ProductPage leveraging the DeleteProductPage service API.
    * Added cmdlet Remove-AG2ProductRestEndpointPage leveraging the DeleteProductRestEndpointPage service API.
    * Added cmdlet Request-AG2Portal leveraging the PreviewPortal service API.
    * Added cmdlet Update-AG2Portal leveraging the UpdatePortal service API.
    * Added cmdlet Update-AG2PortalProduct leveraging the UpdatePortalProduct service API.
    * Added cmdlet Update-AG2ProductPage leveraging the UpdateProductPage service API.
    * Added cmdlet Update-AG2ProductRestEndpointPage leveraging the UpdateProductRestEndpointPage service API.
    * Added cmdlet Write-AG2PortalProductSharingPolicy leveraging the PutPortalProductSharingPolicy service API.
  * Amazon AWSBillingConductor
    * Modified cmdlet Get-ABCBillingGroupList: added parameters Filters_BillingGroupType, Filters_Name, Filters_PrimaryAccountId and Filters_ResponsibilityTransferArn.
    * Modified cmdlet New-ABCBillingGroup: added parameter AccountGrouping_ResponsibilityTransferArn.
    * Modified cmdlet Update-ABCBillingGroup: added parameter AccountGrouping_ResponsibilityTransferArn.
  * Amazon Backup
    * Added cmdlet Get-BAKScanJob leveraging the DescribeScanJob service API.
    * Added cmdlet Get-BAKScanJobList leveraging the ListScanJobs service API.
    * Added cmdlet Get-BAKScanJobSummaryList leveraging the ListScanJobSummaries service API.
    * Added cmdlet Start-BAKScanJob leveraging the StartScanJob service API.
    * Modified cmdlet New-BAKBackupPlan: added parameter BackupPlan_ScanSetting.
    * Modified cmdlet Update-BAKBackupPlan: added parameter BackupPlan_ScanSetting.
  * Amazon Billing
    * Modified cmdlet Get-AWSBBillingViewList: added parameter Name.
  * Amazon CloudTrail
    * Added cmdlet Get-CTInsightsData leveraging the ListInsightsData service API.
    * Modified cmdlet Get-CTInsightsMetricData: added parameter TrailName.
  * Amazon CloudWatch RUM
    * Modified cmdlet New-CWRUMAppMonitor: added parameter Platform.
  * Amazon Cost Optimization Hub
    * Added cmdlet Get-COHEfficiencyMetricList leveraging the ListEfficiencyMetrics service API.
  * Amazon DataZone
    * Added cmdlet Get-DZBatchAttributesMetadata leveraging the BatchGetAttributesMetadata service API.
    * Added cmdlet Set-DZBatchAttributesMetadata leveraging the BatchPutAttributesMetadata service API.
    * Added cmdlet Update-DZRootDomainUnitOwner leveraging the UpdateRootDomainUnitOwner service API.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRImageReferrerList leveraging the ListImageReferrers service API.
    * Added cmdlet Get-ECRPullTimeUpdateExclusionList leveraging the ListPullTimeUpdateExclusions service API.
    * Added cmdlet Register-ECRPullTimeUpdateExclusion leveraging the RegisterPullTimeUpdateExclusion service API.
    * Added cmdlet Unregister-ECRPullTimeUpdateExclusion leveraging the DeregisterPullTimeUpdateExclusion service API.
    * Added cmdlet Update-ECRImageStorageClass leveraging the UpdateImageStorageClass service API.
    * Modified cmdlet Get-ECRImage: added parameter Filter_ImageStatus.
    * Modified cmdlet Get-ECRImageMetadata: added parameter Filter_ImageStatus.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCapacityProvider: added parameter InfrastructureOptimization_ScaleInAfter.
    * Modified cmdlet Update-ECSCapacityProvider: added parameter InfrastructureOptimization_ScaleInAfter.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Disable-EC2IpamPolicy leveraging the DisableIpamPolicy service API.
    * Added cmdlet Edit-EC2IpamPolicyAllocationRule leveraging the ModifyIpamPolicyAllocationRules service API.
    * Added cmdlet Enable-EC2IpamPolicy leveraging the EnableIpamPolicy service API.
    * Added cmdlet Get-EC2EnabledIpamPolicy leveraging the GetEnabledIpamPolicy service API.
    * Added cmdlet Get-EC2IpamPolicy leveraging the DescribeIpamPolicies service API.
    * Added cmdlet Get-EC2IpamPolicyAllocationRule leveraging the GetIpamPolicyAllocationRules service API.
    * Added cmdlet Get-EC2IpamPolicyOrganizationTarget leveraging the GetIpamPolicyOrganizationTargets service API.
    * Added cmdlet New-EC2IpamPolicy leveraging the CreateIpamPolicy service API.
    * Added cmdlet Remove-EC2IpamPolicy leveraging the DeleteIpamPolicy service API.
    * Modified cmdlet Edit-EC2VpcAttribute: parameter EnableDnsHostname is not mandatory anymore; parameter EnableDnsSupport is not mandatory anymore.
    * Modified cmdlet New-EC2NatGateway: added parameters AvailabilityMode, AvailabilityZoneAddress and VpcId.
    * Modified cmdlet Register-EC2NatGatewayAddress: added parameters AvailabilityZone and AvailabilityZoneId.
  * Amazon Elastic MapReduce
    * Modified cmdlet Start-EMRJobFlow: added parameters CloudWatchLogConfiguration_Enabled, CloudWatchLogConfiguration_EncryptionKeyArn, CloudWatchLogConfiguration_LogGroupName, CloudWatchLogConfiguration_LogStreamNamePrefix and CloudWatchLogConfiguration_LogType.
  * Amazon Elemental MediaConnect
    * Added cmdlet Add-EMCNTagGlobalResource leveraging the TagGlobalResource service API.
    * Added cmdlet Get-EMCNBatchRouterInput leveraging the BatchGetRouterInput service API.
    * Added cmdlet Get-EMCNBatchRouterNetworkInterface leveraging the BatchGetRouterNetworkInterface service API.
    * Added cmdlet Get-EMCNBatchRouterOutput leveraging the BatchGetRouterOutput service API.
    * Added cmdlet Get-EMCNRouterInput leveraging the GetRouterInput service API.
    * Added cmdlet Get-EMCNRouterInputList leveraging the ListRouterInputs service API.
    * Added cmdlet Get-EMCNRouterInputSourceMetadata leveraging the GetRouterInputSourceMetadata service API.
    * Added cmdlet Get-EMCNRouterInputThumbnail leveraging the GetRouterInputThumbnail service API.
    * Added cmdlet Get-EMCNRouterNetworkInterface leveraging the GetRouterNetworkInterface service API.
    * Added cmdlet Get-EMCNRouterNetworkInterfaceList leveraging the ListRouterNetworkInterfaces service API.
    * Added cmdlet Get-EMCNRouterOutput leveraging the GetRouterOutput service API.
    * Added cmdlet Get-EMCNRouterOutputList leveraging the ListRouterOutputs service API.
    * Added cmdlet Get-EMCNTagsForGlobalResourceList leveraging the ListTagsForGlobalResource service API.
    * Added cmdlet New-EMCNRouterInput leveraging the CreateRouterInput service API.
    * Added cmdlet New-EMCNRouterNetworkInterface leveraging the CreateRouterNetworkInterface service API.
    * Added cmdlet New-EMCNRouterOutput leveraging the CreateRouterOutput service API.
    * Added cmdlet Remove-EMCNRouterInput leveraging the DeleteRouterInput service API.
    * Added cmdlet Remove-EMCNRouterNetworkInterface leveraging the DeleteRouterNetworkInterface service API.
    * Added cmdlet Remove-EMCNRouterOutput leveraging the DeleteRouterOutput service API.
    * Added cmdlet Remove-EMCNTagGlobalResource leveraging the UntagGlobalResource service API.
    * Added cmdlet Restart-EMCNRouterInput leveraging the RestartRouterInput service API.
    * Added cmdlet Restart-EMCNRouterOutput leveraging the RestartRouterOutput service API.
    * Added cmdlet Set-EMCNRouterInput leveraging the TakeRouterInput service API.
    * Added cmdlet Start-EMCNRouterInput leveraging the StartRouterInput service API.
    * Added cmdlet Start-EMCNRouterOutput leveraging the StartRouterOutput service API.
    * Added cmdlet Stop-EMCNRouterInput leveraging the StopRouterInput service API.
    * Added cmdlet Stop-EMCNRouterOutput leveraging the StopRouterOutput service API.
    * Added cmdlet Update-EMCNRouterInput leveraging the UpdateRouterInput service API.
    * Added cmdlet Update-EMCNRouterNetworkInterface leveraging the UpdateRouterNetworkInterface service API.
    * Added cmdlet Update-EMCNRouterOutput leveraging the UpdateRouterOutput service API.
    * Modified cmdlet Update-EMCNFlowOutput: added parameters EncryptionKeyConfiguration_Automatic, RouterIntegrationState, RouterIntegrationTransitEncryption_EncryptionKeyType, SecretsManager_RoleArn and SecretsManager_SecretArn.
    * Modified cmdlet Update-EMCNFlowSource: added parameters EncryptionKeyConfiguration_Automatic, RouterIntegrationState, RouterIntegrationTransitDecryption_EncryptionKeyType, SecretsManager_RoleArn and SecretsManager_SecretArn.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLInput: added parameters RouterSettings_Destination, RouterSettings_EncryptionType and RouterSettings_SecretArn.
    * Modified cmdlet Update-EMLInput: added parameter SpecialRouterSettings_RouterArn.
  * Amazon GuardDuty
    * Added cmdlet Get-GDMalwareScanDetail leveraging the GetMalwareScan service API.
    * Added cmdlet Get-GDMalwareScanList leveraging the ListMalwareScans service API.
    * Modified cmdlet Start-GDMalwareScan: added parameters ClientToken, IncrementalScanDetails_BaselineResourceArn, RecoveryPoint_BackupVaultName and ScanConfiguration_Role.
  * Amazon Health
    * Modified cmdlet Get-HLTHEvent: added parameters Filter_Actionability and Filter_Persona.
    * Modified cmdlet Get-HLTHEventAggregate: added parameters Filter_Actionability and Filter_Persona.
    * Modified cmdlet Get-HLTHEventsForOrganization: added parameters Filter_Actionability and Filter_Persona.
    * Modified cmdlet Get-HLTHEventType: added parameters Filter_Actionability and Filter_Persona.
  * Amazon Identity and Access Management
    * Added cmdlet Disable-IAMOutboundWebIdentityFederation leveraging the DisableOutboundWebIdentityFederation service API.
    * Added cmdlet Enable-IAMOutboundWebIdentityFederation leveraging the EnableOutboundWebIdentityFederation service API.
    * Added cmdlet Get-IAMOutboundWebIdentityFederationInfo leveraging the GetOutboundWebIdentityFederationInfo service API.
  * Amazon Invoicing
    * Modified cmdlet Get-INVInvoiceUnitList: added parameter Filters_BillSourceAccount.
    * Modified cmdlet New-INVInvoiceUnit: added parameter Rule_BillSourceAccount.
    * Modified cmdlet Update-INVInvoiceUnit: added parameter Rule_BillSourceAccount.
  * Amazon Lambda
    * Modified cmdlet Publish-LMFunction: added parameter TenancyConfig_TenantIsolationMode.
    * Modified cmdlet Invoke-LMFunction: added parameter TenantId.
    * Modified cmdlet Invoke-LMWithResponseStream: added parameter TenantId.
  * Amazon Network Firewall
    * Modified cmdlet Get-NWFWRuleGroupList: added parameter SubscriptionStatus.
  * Amazon Partner Central Channel API. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PCC and can be listed using the command 'Get-AWSCmdletName -Service PCC'.
  * Amazon Pricing Calculator
    * Modified cmdlet New-BCMPCBillScenario: added parameters CostCategoryGroupSharingPreferenceArn and GroupSharingPreference.
    * Modified cmdlet Update-BCMPCBillScenario: added parameters CostCategoryGroupSharingPreferenceArn and GroupSharingPreference.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMEndpointConfig: added parameters MetricsConfig_EnableEnhancedMetric and MetricsConfig_MetricPublishFrequencyInSecond.
  * Amazon Secrets Manager
    * Modified cmdlet Invoke-SECSecretRotation: added parameters ExternalSecretRotationMetadata and ExternalSecretRotationRoleArn.
    * Modified cmdlet New-SECSecret: added parameter Type.
    * Modified cmdlet Update-SECSecret: added parameter Type.
  * Amazon Security Token Service
    * Added cmdlet Get-STSWebIdentityToken leveraging the GetWebIdentityToken service API.
  * Amazon Sign-In Data Plane. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AMSP and can be listed using the command 'Get-AWSCmdletName -Service AMSP'.
  * Amazon Step Functions
    * Modified cmdlet Test-SFNState: added parameters Context, ErrorOutput_Cause, ErrorOutput_Error, Mock_FieldValidationMode, Mock_Result, StateConfiguration_ErrorCausedByState, StateConfiguration_MapItemReaderData, StateConfiguration_MapIterationFailureCount, StateConfiguration_RetrierRetryCount and StateName.

### 5.0.100 (2025-11-18 22:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.136.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Added cmdlet Add-ASInstance leveraging the LaunchInstances service API.
  * Amazon Backup
    * Added cmdlet Get-BAKTieringConfiguration leveraging the GetTieringConfiguration service API.
    * Added cmdlet Get-BAKTieringConfigurationList leveraging the ListTieringConfigurations service API.
    * Added cmdlet New-BAKTieringConfiguration leveraging the CreateTieringConfiguration service API.
    * Added cmdlet Remove-BAKTieringConfiguration leveraging the DeleteTieringConfiguration service API.
    * Added cmdlet Update-BAKTieringConfiguration leveraging the UpdateTieringConfiguration service API.
  * Amazon Bedrock Runtime
    * Modified cmdlet Get-BDRRCountToken: added parameters Converse_AdditionalModelRequestField, Tool_Name, ToolChoice_Any, ToolChoice_Auto and ToolConfig_Tool.
    * Modified cmdlet Invoke-BDRRConverse: added parameter ServiceTier_Type.
    * Modified cmdlet Invoke-BDRRConverseStream: added parameter ServiceTier_Type.
    * Modified cmdlet Invoke-BDRRModel: added parameter ServiceTier.
    * Modified cmdlet Invoke-BDRRModelWithResponseStream: added parameter ServiceTier.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNCFNOperationEvent leveraging the DescribeEvents service API.
    * Modified cmdlet New-CFNChangeSet: added parameter DeploymentMode.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLScheduledQuery leveraging the GetScheduledQuery service API.
    * Added cmdlet Get-CWLScheduledQueryHistory leveraging the GetScheduledQueryHistory service API.
    * Added cmdlet Get-CWLScheduledQueryList leveraging the ListScheduledQueries service API.
    * Added cmdlet New-CWLScheduledQuery leveraging the CreateScheduledQuery service API.
    * Added cmdlet Remove-CWLScheduledQuery leveraging the DeleteScheduledQuery service API.
    * Added cmdlet Update-CWLScheduledQuery leveraging the UpdateScheduledQuery service API.
  * Amazon Connect Service
    * Modified cmdlet Start-CONNOutboundVoiceContact: added parameter RingTimeoutInSecond.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2VpnConcentrator leveraging the DescribeVpnConcentrators service API.
    * Added cmdlet New-EC2VpnConcentrator leveraging the CreateVpnConcentrator service API.
    * Added cmdlet Remove-EC2VpnConcentrator leveraging the DeleteVpnConcentrator service API.
    * Modified cmdlet New-EC2VpnConnection: added parameter VpnConcentratorId.
  * Amazon Identity and Access Management
    * Added cmdlet Approve-IAMDelegationRequest leveraging the AcceptDelegationRequest service API.
    * Added cmdlet Deny-IAMDelegationRequest leveraging the RejectDelegationRequest service API.
    * Added cmdlet Get-IAMDelegationRequest leveraging the GetDelegationRequest service API.
    * Added cmdlet Get-IAMDelegationRequestList leveraging the ListDelegationRequests service API.
    * Added cmdlet Get-IAMHumanReadableSummary leveraging the GetHumanReadableSummary service API.
    * Added cmdlet Register-IAMDelegationRequest leveraging the AssociateDelegationRequest service API.
    * Added cmdlet Send-IAMDelegationToken leveraging the SendDelegationToken service API.
    * Added cmdlet Update-IAMDelegationRequest leveraging the UpdateDelegationRequest service API.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Get-MSKTopic leveraging the DescribeTopic service API.
    * Added cmdlet Get-MSKTopicList leveraging the ListTopics service API.
    * Added cmdlet Get-MSKTopicPartition leveraging the DescribeTopicPartitions service API.
  * Amazon Resource Groups Tagging API
    * Added cmdlet Get-RGTRequiredTagList leveraging the ListRequiredTags service API.

### 5.0.99 (2025-11-17 21:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.135.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAAServerless. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MWAAS and can be listed using the command 'Get-AWSCmdletName -Service MWAAS'.
  * Amazon AppStream
    * Added cmdlet Get-APSExportImageTask leveraging the GetExportImageTask service API.
    * Added cmdlet Get-APSExportImageTaskList leveraging the ListExportImageTasks service API.
    * Added cmdlet New-APSExportImageTask leveraging the CreateExportImageTask service API.
    * Added cmdlet New-APSImportedImage leveraging the CreateImportedImage service API.
    * Modified cmdlet New-APSFleet: added parameter RootVolumeConfig_VolumeSizeInGb.
    * Modified cmdlet New-APSImageBuilder: added parameter RootVolumeConfig_VolumeSizeInGb.
    * Modified cmdlet Update-APSFleet: added parameter RootVolumeConfig_VolumeSizeInGb.
  * Amazon Backup
    * Modified cmdlet Get-BAKCopyJobList: added parameter BySourceRecoveryPointArn.
    * Modified cmdlet Start-BAKBackupJob: added parameters Lifecycle_DeleteAfterEvent and LogicallyAirGappedBackupVaultArn.
    * Modified cmdlet Start-BAKCopyJob: added parameter Lifecycle_DeleteAfterEvent.
    * Modified cmdlet Update-BAKRecoveryPointLifecycle: added parameter Lifecycle_DeleteAfterEvent.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSDataProvider: added parameters SybaseAseSettings_CertificateArn, SybaseAseSettings_DatabaseName, SybaseAseSettings_EncryptPassword, SybaseAseSettings_Port, SybaseAseSettings_ServerName and SybaseAseSettings_SslMode.
    * Modified cmdlet New-DMSDataProvider: added parameters SybaseAseSettings_CertificateArn, SybaseAseSettings_DatabaseName, SybaseAseSettings_EncryptPassword, SybaseAseSettings_Port, SybaseAseSettings_ServerName and SybaseAseSettings_SslMode.
  * Amazon Device Farm
    * [Breaking Change] Modified cmdlet New-DFRemoteAccessSession: removed parameters ClientId, RemoteDebugEnabled, RemoteRecordAppArn, RemoteRecordEnabled and SshPublicKey.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Disable-EC2InstanceSqlHaStandbyDetection leveraging the DisableInstanceSqlHaStandbyDetections service API.
    * Added cmdlet Enable-EC2InstanceSqlHaStandbyDetection leveraging the EnableInstanceSqlHaStandbyDetections service API.
    * Added cmdlet Get-EC2InstanceSqlHaHistoryState leveraging the DescribeInstanceSqlHaHistoryStates service API.
    * Added cmdlet Get-EC2InstanceSqlHaState leveraging the DescribeInstanceSqlHaStates service API.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2OriginEndpoint: added parameter Scte_ScteInSegment.
    * Modified cmdlet Update-MPV2OriginEndpoint: added parameter Scte_ScteInSegment.
  * Amazon Glue
    * Added cmdlet Get-GLUEIntegrationResourcePropertyList leveraging the ListIntegrationResourceProperties service API.
    * Added cmdlet Remove-GLUEIntegrationResourceProperty leveraging the DeleteIntegrationResourceProperty service API.
    * Modified cmdlet New-GLUEIntegrationResourceProperty: added parameter Tag.
  * Amazon GuardDuty
    * Added cmdlet Send-GDObjectMalwareScan leveraging the SendObjectMalwareScan service API.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameter NluImprovement_AssistedNluMode.
    * Modified cmdlet Update-LMBV2BotLocale: added parameter NluImprovement_AssistedNluMode.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSIndex leveraging the GetIndex service API.
    * Added cmdlet New-OSIndex leveraging the CreateIndex service API.
    * Added cmdlet Remove-OSIndex leveraging the DeleteIndex service API.
    * Added cmdlet Update-OSIndex leveraging the UpdateIndex service API.
  * Amazon Parallel Computing Service
    * Modified cmdlet New-PCSCluster: added parameter SlurmRest_Mode.
    * Modified cmdlet Update-PCSCluster: added parameter SlurmRest_Mode.

### 5.0.98 (2025-11-14 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.134.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Approve-DZSubscriptionRequest: added parameter AssetPermission.
    * Modified cmdlet Get-DZSubscriptionGrantList: added parameters OwningGroupId and OwningUserId.
    * Modified cmdlet Get-DZSubscriptionList: added parameters OwningGroupId and OwningUserId.
    * Modified cmdlet Get-DZSubscriptionRequestList: added parameters OwningGroupId and OwningUserId.
    * Modified cmdlet New-DZSubscriptionRequest: added parameters AssetPermission and AssetScope.

### 5.0.97 (2025-11-13 22:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.133.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNHookResultDetail leveraging the GetHookResult service API.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWWirelessDevice: added parameters Positioning_DestinationName and Sidewalk_SidewalkManufacturingSn.
    * Modified cmdlet Start-IOTWSingleWirelessDeviceImportTask: added parameters Positioning and Positioning_DestinationName.
    * Modified cmdlet Start-IOTWWirelessDeviceImportTask: added parameters Positioning and Positioning_DestinationName.
    * Modified cmdlet Update-IOTWWirelessDevice: added parameter Positioning_DestinationName.
  * Amazon SageMaker Service
    * Modified cmdlet Get-SMPartnerApp: added parameter IncludeAvailableUpgrade.
    * Modified cmdlet New-SMPartnerApp: added parameters ApplicationConfig_AssignedGroupPattern, ApplicationConfig_RoleGroupAssignment and EnableAutoMinorVersionUpgrade.
    * Modified cmdlet Update-SMPartnerApp: added parameters ApplicationConfig_AssignedGroupPattern, ApplicationConfig_RoleGroupAssignment, AppVersion and EnableAutoMinorVersionUpgrade.
  * Amazon WorkSpaces Web
    * Modified cmdlet New-WSWBrowserSetting: added parameters WebContentFilteringPolicy_AllowedUrl, WebContentFilteringPolicy_BlockedCategory and WebContentFilteringPolicy_BlockedUrl.
    * Modified cmdlet Update-WSWBrowserSetting: added parameters WebContentFilteringPolicy_AllowedUrl, WebContentFilteringPolicy_BlockedCategory and WebContentFilteringPolicy_BlockedUrl.

### 5.0.96 (2025-11-12 21:48Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.132.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Modified cmdlet Update-CONNAuthenticationProfile: added parameters SessionInactivityDuration and SessionInactivityHandlingEnabled.
  * Amazon Database Migration Service
    * Added cmdlet Get-DMSMetadataModel leveraging the DescribeMetadataModel service API.
    * Added cmdlet Get-DMSMetadataModelChild leveraging the DescribeMetadataModelChildren service API.
    * Added cmdlet Get-DMSMetadataModelCreation leveraging the DescribeMetadataModelCreations service API.
    * Added cmdlet Get-DMSTargetSelectionRule leveraging the GetTargetSelectionRules service API.
    * Added cmdlet Start-DMSMetadataModelCreation leveraging the StartMetadataModelCreation service API.
    * Added cmdlet Stop-DMSMetadataModelConversion leveraging the CancelMetadataModelConversion service API.
    * Added cmdlet Stop-DMSMetadataModelCreation leveraging the CancelMetadataModelCreation service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2ImageAncestry leveraging the GetImageAncestry service API.
  * Amazon Prometheus Service
    * Modified cmdlet New-PROMScraper: added parameters VpcConfiguration_SecurityGroupId and VpcConfiguration_SubnetId.
  * Amazon Redshift
    * Added cmdlet Get-RSIdentityCenterAuthToken leveraging the GetIdentityCenterAuthToken service API.
  * Amazon S3 Tables
    * Added cmdlet Get-S3TTableBucketMetricsConfiguration leveraging the GetTableBucketMetricsConfiguration service API.
    * Added cmdlet Remove-S3TTableBucketMetricsConfiguration leveraging the DeleteTableBucketMetricsConfiguration service API.
    * Added cmdlet Write-S3TTableBucketMetricsConfiguration leveraging the PutTableBucketMetricsConfiguration service API.

### 5.0.95 (2025-11-11 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.131.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Data Automation for Amazon Bedrock
    * Modified cmdlet New-BDADataAutomationProject: added parameters LanguageConfiguration_GenerativeOutputLanguage, LanguageConfiguration_IdentifyMultipleLanguage and LanguageConfiguration_InputLanguage.
    * Modified cmdlet Update-BDADataAutomationProject: added parameters LanguageConfiguration_GenerativeOutputLanguage, LanguageConfiguration_IdentifyMultipleLanguage and LanguageConfiguration_InputLanguage.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2VpnConnection: added parameter Options_TunnelBandwidth.
  * Amazon Medical Imaging Service
    * Modified cmdlet New-MISDatastore: added parameter LosslessStorageFormat.
  * Amazon RTBFabric
    * Modified cmdlet New-RTBInboundExternalLink: added parameters Sampling_ErrorLog and Sampling_FilterLog.
    * Modified cmdlet New-RTBOutboundExternalLink: added parameters Attributes_CustomerProvidedId, Attributes_ResponderErrorMasking, Sampling_ErrorLog and Sampling_FilterLog.

### 5.0.94 (2025-11-10 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.130.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Modified cmdlet Get-BAKRestoreJobList: added parameter ByParentJobId.
  * Amazon Braket
    * Modified cmdlet New-BRKTQuantumTask: added parameter ExperimentalCapabilities_Enabled.
  * Amazon DataZone
    * [Breaking Change] Modified cmdlet New-DZConnection: removed parameter MlflowProperties_TrackingServerName.
    * [Breaking Change] Modified cmdlet Update-DZConnection: removed parameter MlflowProperties_TrackingServerName.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Get-EC2InstanceTypesFromInstanceRequirement: added parameter InstanceRequirements_RequireEncryptionInTransit.
    * Modified cmdlet Get-EC2SpotPlacementScore: added parameter InstanceRequirements_RequireEncryptionInTransit.
  * Amazon GuardDuty
    * Modified cmdlet New-GDPublishingDestination: added parameter Tag.
  * Amazon Identity and Access Management
    * Added cmdlet New-IAMDelegationRequest leveraging the CreateDelegationRequest service API.
  * Amazon Invoicing
    * Added cmdlet Get-INVInvoicePDF leveraging the GetInvoicePDF service API.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Update-MSKRebalancing leveraging the UpdateRebalancing service API.
    * Modified cmdlet New-MSKCluster: added parameter Rebalancing_Status.
    * Modified cmdlet New-MSKClusterV2: added parameter Rebalancing_Status.
  * Amazon Security Token Service
    * Added cmdlet Get-STSDelegatedAccessToken leveraging the GetDelegatedAccessToken service API.

### 5.0.93 (2025-11-07 21:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.129.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Tower
    * Modified cmdlet Disable-ACTControl: added parameter EnabledControlIdentifier.
    * Modified cmdlet Get-ACTEnabledControlList: added parameters Filter_InheritanceDriftStatus, Filter_ParentIdentifier, Filter_ResourceDriftStatus and IncludeChild.
    * Modified cmdlet New-ACTLandingZone: added parameter RemediationType.
    * Modified cmdlet Update-ACTLandingZone: added parameter RemediationType.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Edit-EC2IpamScope: added parameters ExternalAuthorityConfiguration_ExternalResourceIdentifier, ExternalAuthorityConfiguration_Type and RemoveExternalAuthorityConfiguration.
    * Modified cmdlet Edit-EC2VpcEndpoint: added parameters DnsOptions_PrivateDnsPreference and DnsOptions_PrivateDnsSpecifiedDomain.
    * Modified cmdlet New-EC2IpamScope: added parameters ExternalAuthorityConfiguration_ExternalResourceIdentifier and ExternalAuthorityConfiguration_Type.
    * Modified cmdlet New-EC2VpcEndpoint: added parameters DnsOptions_PrivateDnsPreference and DnsOptions_PrivateDnsSpecifiedDomain.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSDefaultApplicationSetting leveraging the GetDefaultApplicationSetting service API.
    * Added cmdlet Write-OSDefaultApplicationSetting leveraging the PutDefaultApplicationSetting service API.
  * Amazon VPC Lattice
    * Added cmdlet Get-VPCLDomainVerification leveraging the GetDomainVerification service API.
    * Added cmdlet Get-VPCLDomainVerificationList leveraging the ListDomainVerifications service API.
    * Added cmdlet Remove-VPCLDomainVerification leveraging the DeleteDomainVerification service API.
    * Added cmdlet Start-VPCLDomainVerification leveraging the StartDomainVerification service API.
    * Modified cmdlet Get-VPCLResourceConfigurationList: added parameter DomainVerificationIdentifier.
    * Modified cmdlet New-VPCLResourceConfiguration: added parameters CustomDomainName, DomainVerificationIdentifier and GroupDomain.
    * Modified cmdlet New-VPCLServiceNetworkResourceAssociation: added parameter PrivateDnsEnabled.
    * Modified cmdlet New-VPCLServiceNetworkVpcAssociation: added parameters DnsOptions_PrivateDnsPreference, DnsOptions_PrivateDnsSpecifiedDomain and PrivateDnsEnabled.

### 5.0.92 (2025-11-06 21:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.128.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Modified cmdlet New-BAKLogicallyAirGappedBackupVault: added parameter EncryptionKeyArn.
  * Amazon Connect Service
    * Added cmdlet Search-CONNContactEvaluation leveraging the SearchContactEvaluations service API.
    * Added cmdlet Search-CONNEvaluationForm leveraging the SearchEvaluationForms service API.
    * Modified cmdlet New-CONNEvaluationForm: added parameters AutoEvaluationConfiguration_Enabled and Tag.
    * Modified cmdlet Start-CONNContactEvaluation: added parameters AutoEvaluationConfiguration_Enabled and Tag.
    * Modified cmdlet Submit-CONNContactEvaluation: added parameter SubmittedBy_ConnectUserArn.
    * Modified cmdlet Update-CONNContactEvaluation: added parameter UpdatedBy_ConnectUserArn.
    * Modified cmdlet Update-CONNEvaluationForm: added parameter AutoEvaluationConfiguration_Enabled.
  * Amazon Identity Store
    * Modified cmdlet New-IDSUser: added parameters Birthdate, Photo and Website.
  * Amazon QuickSight
    * Modified cmdlet New-QSDataSet: added parameters DataPrepConfiguration_DestinationTableMap, DataPrepConfiguration_SourceTableMap, DataPrepConfiguration_TransformStepMap and SemanticModelConfiguration_TableMap.
    * Modified cmdlet Update-QSDataSet: added parameters DataPrepConfiguration_DestinationTableMap, DataPrepConfiguration_SourceTableMap, DataPrepConfiguration_TransformStepMap and SemanticModelConfiguration_TableMap.
  * Amazon S3 Tables
    * Added cmdlet Add-S3TResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-S3TResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-S3TResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-S3TTable: added parameter Tag.
    * Modified cmdlet New-S3TTableBucket: added parameter Tag.
  * Amazon SageMaker Service
    * Modified cmdlet Update-SMCluster: added parameter NodeProvisioningMode.
    * Modified cmdlet Update-SMDomain: added parameter VpcId.

### 5.0.91 (2025-11-05 21:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.127.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFront
    * Added cmdlet Get-CFCFDistributionsByOwnedResource leveraging the ListDistributionsByOwnedResource service API.
    * Added cmdlet Get-CFCFResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-CFCFResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Update-CFAnycastIpList leveraging the UpdateAnycastIpList service API.
    * Added cmdlet Write-CFCFResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet New-CFAnycastIpList: added parameter IpAddressType.
  * Amazon DataZone
    * Modified cmdlet New-DZProject: added parameter ResourceTag.
    * Modified cmdlet New-DZProjectProfile: added parameters AllowCustomProjectResourceTag, ProjectResourceTag and ProjectResourceTagsDescription.
    * Modified cmdlet Update-DZProject: added parameter ResourceTag.
    * Modified cmdlet Update-DZProjectProfile: added parameters AllowCustomProjectResourceTag, ProjectResourceTag and ProjectResourceTagsDescription.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Disable-EC2FastSnapshotRestore: added parameter AvailabilityZoneId.
    * Modified cmdlet Enable-EC2FastSnapshotRestore: added parameter AvailabilityZoneId.
  * Amazon FSx
    * Modified cmdlet New-FSXStorageVirtualMachine: added parameter SelfManagedActiveDirectoryConfiguration_DomainJoinServiceAccountSecret.
    * Modified cmdlet Update-FSXStorageVirtualMachine: added parameter SelfManagedActiveDirectoryConfiguration_DomainJoinServiceAccountSecret.
  * Amazon Ground Station
    * Added cmdlet Get-GSAgentTaskResponseUrl leveraging the GetAgentTaskResponseUrl service API.
    * Added cmdlet New-GSDataflowEndpointGroupV2 leveraging the CreateDataflowEndpointGroupV2 service API.

### 5.0.90 (2025-11-04 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.126.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Pinpoint SMS Voice V2
    * Added cmdlet Use-SMSVCarrierLookup leveraging the CarrierLookup service API.

### 5.0.89 (2025-11-03 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.125.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCAgentRuntime: added parameters CodeConfiguration_EntryPoint, CodeConfiguration_Runtime, S3_Bucket, S3_Prefix and S3_VersionId.
    * Modified cmdlet New-BACCBrowser: added parameter S3Location_VersionId.
    * Modified cmdlet Remove-BACCAgentRuntime: added parameter ClientToken.
    * Modified cmdlet Update-BACCAgentRuntime: added parameters CodeConfiguration_EntryPoint, CodeConfiguration_Runtime, S3_Bucket, S3_Prefix and S3_VersionId.
  * Amazon Kinesis
    * Added cmdlet Get-KINAccountSetting leveraging the DescribeAccountSettings service API.
    * Added cmdlet Update-KINAccountSetting leveraging the UpdateAccountSettings service API.
    * Added cmdlet Update-KINStreamWarmThroughput leveraging the UpdateStreamWarmThroughput service API.
    * Modified cmdlet New-KINStream: added parameter WarmThroughputMiBp.
    * Modified cmdlet Update-KINStreamMode: added parameter WarmThroughputMiBp.

### 5.0.88 (2025-10-31 20:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.124.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASCaseRule: added parameters FieldOptions_ChildFieldId, FieldOptions_ParentChildFieldOptionsMapping, FieldOptions_ParentFieldId, Hidden_Condition and Hidden_DefaultValue.
    * Modified cmdlet Update-CCASCaseRule: added parameters FieldOptions_ChildFieldId, FieldOptions_ParentChildFieldOptionsMapping, FieldOptions_ParentFieldId, Hidden_Condition and Hidden_DefaultValue.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2IpamPrefixListResolver leveraging the ModifyIpamPrefixListResolver service API.
    * Added cmdlet Edit-EC2IpamPrefixListResolverTarget leveraging the ModifyIpamPrefixListResolverTarget service API.
    * Added cmdlet Get-EC2IpamPrefixListResolver leveraging the DescribeIpamPrefixListResolvers service API.
    * Added cmdlet Get-EC2IpamPrefixListResolverRule leveraging the GetIpamPrefixListResolverRules service API.
    * Added cmdlet Get-EC2IpamPrefixListResolverTarget leveraging the DescribeIpamPrefixListResolverTargets service API.
    * Added cmdlet Get-EC2IpamPrefixListResolverVersion leveraging the GetIpamPrefixListResolverVersions service API.
    * Added cmdlet Get-EC2IpamPrefixListResolverVersionEntry leveraging the GetIpamPrefixListResolverVersionEntries service API.
    * Added cmdlet New-EC2IpamPrefixListResolver leveraging the CreateIpamPrefixListResolver service API.
    * Added cmdlet New-EC2IpamPrefixListResolverTarget leveraging the CreateIpamPrefixListResolverTarget service API.
    * Added cmdlet Remove-EC2IpamPrefixListResolver leveraging the DeleteIpamPrefixListResolver service API.
    * Added cmdlet Remove-EC2IpamPrefixListResolverTarget leveraging the DeleteIpamPrefixListResolverTarget service API.
    * Modified cmdlet Edit-EC2ManagedPrefixList: added parameter IpamPrefixListResolverSyncEnabled.
  * Amazon SageMaker Service
    * Modified cmdlet Update-SMNotebookInstance: added parameter PlatformIdentifier.

### 5.0.87 (2025-10-30 21:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.123.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCBrowser: added parameter BrowserSigning_Enabled.
  * Amazon Clean Rooms Service
    * Modified cmdlet Start-CRSProtectedQuery: added parameter Properties_Spark.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameters AccessLogConfiguration_Format and AccessLogConfiguration_IncludeQueryParameter.
    * Modified cmdlet Update-ECSService: added parameters AccessLogConfiguration_Format and AccessLogConfiguration_IncludeQueryParameter.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameter IdentityCenterConfiguration_UserBackgroundSessionsEnabled.
    * Modified cmdlet Update-EMRServerlessApplication: added parameter IdentityCenterConfiguration_UserBackgroundSessionsEnabled.
  * Amazon Glue
    * Modified cmdlet New-GLUEGlueIdentityCenterConfiguration: added parameter UserBackgroundSessionsEnabled.
    * Modified cmdlet Update-GLUEGlueIdentityCenterConfiguration: added parameter UserBackgroundSessionsEnabled.
  * Amazon Key Management Service
    * Modified cmdlet New-KMSCustomKeyStore: added parameter XksProxyVpcEndpointServiceOwner.
    * Modified cmdlet Update-KMSCustomKeyStore: added parameter XksProxyVpcEndpointServiceOwner.
  * Amazon Managed integrations for AWS IoT Device Management
    * Added cmdlet Get-IOTMIManagedThingCertificate leveraging the GetManagedThingCertificate service API.
  * Amazon Prometheus Service
    * Added cmdlet Get-PROMAnomalyDetector leveraging the DescribeAnomalyDetector service API.
    * Added cmdlet Get-PROMAnomalyDetectorList leveraging the ListAnomalyDetectors service API.
    * Added cmdlet New-PROMAnomalyDetector leveraging the CreateAnomalyDetector service API.
    * Added cmdlet Remove-PROMAnomalyDetector leveraging the DeleteAnomalyDetector service API.
    * Added cmdlet Write-PROMAnomalyDetector leveraging the PutAnomalyDetector service API.

### 5.0.86 (2025-10-29 22:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.122.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.85 (2025-10-28 21:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.121.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon IoT Fleet Hub
  * [Breaking Change] Removed support for Amazon Lookout for Metrics
  * [Breaking Change] Removed support for Amazon Lookout for Vision
  * [Breaking Change] Removed support for Amazon Mainframe Modernization Application Testing
  * [Breaking Change] Removed support for Amazon QLDB
  * [Breaking Change] Removed support for Amazon QLDB Session
  * [Breaking Change] Removed support for Amazon RoboMaker
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameters CanaryConfiguration_CanaryBakeTimeInMinute, CanaryConfiguration_CanaryPercent, LinearConfiguration_StepBakeTimeInMinute and LinearConfiguration_StepPercent.
    * Modified cmdlet Update-ECSService: added parameters CanaryConfiguration_CanaryBakeTimeInMinute, CanaryConfiguration_CanaryPercent, LinearConfiguration_StepBakeTimeInMinute and LinearConfiguration_StepPercent.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2CapacityReservationTopology leveraging the DescribeCapacityReservationTopology service API.
  * Amazon Ground Station
    * Modified cmdlet Add-GSReservedContact: added parameter AzEl_EphemerisId.
    * Modified cmdlet Get-GSContactList: added parameter AzEl_Id.
    * Modified cmdlet Get-GSEphemerideList: added parameter EphemerisType.
    * Modified cmdlet New-GSEphemeris: added parameters AzEl_GroundStation, AzElData_AngleUnit, AzElData_AzElSegmentList, S3Object_Bucket, S3Object_Key and S3Object_Version.
  * Amazon SageMaker Service
    * Added cmdlet Remove-SMProcessingJob leveraging the DeleteProcessingJob service API.
    * Added cmdlet Remove-SMTrainingJob leveraging the DeleteTrainingJob service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Copy-S3Object: added parameter IfMatch.

### 5.0.84 (2025-10-27 21:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.120.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Kinesis
    * Added cmdlet Update-KINMaxRecordSize leveraging the UpdateMaxRecordSize service API.
    * Modified cmdlet New-KINStream: added parameter MaxRecordSizeInKiB.

### 5.0.83 (2025-10-24 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.119.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet New-DZConnection: added parameters MlflowProperties_TrackingServerArn and MlflowProperties_TrackingServerName.
    * Modified cmdlet Update-DZConnection: added parameters MlflowProperties_TrackingServerArn and MlflowProperties_TrackingServerName.
  * Amazon Location Service
    * Modified cmdlet New-LOCKey: added parameters Restrictions_AllowAndroidApp and Restrictions_AllowAppleApp.
    * Modified cmdlet Update-LOCKey: added parameters Restrictions_AllowAndroidApp and Restrictions_AllowAppleApp.
  * Amazon Location Service Maps V2
    * Modified cmdlet Get-GEOMTile: added parameter AdditionalFeature.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceComponent: added parameter DataCacheConfig_EnableCaching.
    * Modified cmdlet Update-SMInferenceComponent: added parameter DataCacheConfig_EnableCaching.

### 5.0.82 (2025-10-23 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.118.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Aurora DSQL
    * Added cmdlet Get-DSQLClusterPolicy leveraging the GetClusterPolicy service API.
    * Added cmdlet Remove-DSQLClusterPolicy leveraging the DeleteClusterPolicy service API.
    * Added cmdlet Set-DSQLClusterPolicy leveraging the PutClusterPolicy service API.
    * Modified cmdlet New-DSQLCluster: added parameters BypassPolicyLockoutSafetyCheck and Policy.

### 5.0.81 (2025-10-22 22:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.117.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonConnectCampaignServiceV2
    * Modified cmdlet New-CCS2Campaign: added parameters Preview_AgentAction, Preview_BandwidthAllocation and TimeoutConfig_DurationInSecond.
    * Modified cmdlet Update-CCS2CampaignChannelSubtypeConfig: added parameters Preview_AgentAction, Preview_BandwidthAllocation and TimeoutConfig_DurationInSecond.
  * Amazon Connect Service
    * Added cmdlet Add-CONNEmailAddressAlias leveraging the AssociateEmailAddressAlias service API.
    * Added cmdlet Remove-CONNEmailAddressAlias leveraging the DisassociateEmailAddressAlias service API.
    * Modified cmdlet Start-CONNOutboundVoiceContact: added parameters OutboundStrategy_Type, PostAcceptTimeoutConfig_DurationInSecond and Preview_AllowedUserAction.
  * Amazon Device Farm
    * Modified cmdlet New-DFRemoteAccessSession: added parameters AppArn and Configuration_AuxiliaryApp.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLAlertList leveraging the ListAlerts service API.
    * Added cmdlet Get-EMLClusterAlertList leveraging the ListClusterAlerts service API.
    * Added cmdlet Get-EMLMultiplexAlertList leveraging the ListMultiplexAlerts service API.
  * Amazon RTBFabric. Added cmdlets to support the service. Cmdlets for the service have the noun prefix RTB and can be listed using the command 'Get-AWSCmdletName -Service RTB'.

### 5.0.80 (2025-10-21 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.116.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaConvert
    * Added cmdlet Get-EMCJobsQueryResult leveraging the GetJobsQueryResults service API.
    * Added cmdlet Start-EMCJobsQuery leveraging the StartJobsQuery service API.
  * Amazon Marketplace Metering
    * Modified cmdlet Send-MMMeteringData: added parameter ClientToken.

### 5.0.79 (2025-10-17 22:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.115.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Location Service Maps V2
    * Modified cmdlet Get-GEOMStyleDescriptor: added parameters ContourDensity, Terrain, Traffic and TravelMode.

### 5.0.78 (2025-10-16 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.114.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Added cmdlet Add-APSSoftwareToImageBuilder leveraging the AssociateSoftwareToImageBuilder service API.
    * Added cmdlet Get-APSAppLicenseUsage leveraging the DescribeAppLicenseUsage service API.
    * Added cmdlet Get-APSSoftwareAssociation leveraging the DescribeSoftwareAssociations service API.
    * Added cmdlet Remove-APSSoftwareFromImageBuilder leveraging the DisassociateSoftwareFromImageBuilder service API.
    * Added cmdlet Start-APSSoftwareDeploymentToImageBuilder leveraging the StartSoftwareDeploymentToImageBuilder service API.
    * Modified cmdlet New-APSImageBuilder: added parameters SoftwaresToInstall and SoftwaresToUninstall.
  * Amazon AWSBillingConductor
    * Modified cmdlet New-ABCCustomLineItem: added parameters ComputationRule and PresentationDetails_Service.
  * Amazon Backup
    * Modified cmdlet Get-BAKBackupPlan: added parameter MaxScheduledRunsPreview.
  * Amazon Bedrock
    * Modified cmdlet New-BDRAutomatedReasoningPolicy: added parameter KmsKeyId.
    * Modified cmdlet Remove-BDRAutomatedReasoningPolicy: added parameter ForceDelete.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Added cmdlet Sync-BACCGatewayTarget leveraging the SynchronizeGatewayTargets service API.
    * Modified cmdlet New-BACCAgentRuntime: added parameters LifecycleConfiguration_IdleRuntimeSessionTimeout and LifecycleConfiguration_MaxLifetime.
    * Modified cmdlet New-BACCApiKeyCredentialProvider: added parameter Tag.
    * Modified cmdlet New-BACCGatewayTarget: added parameter McpServer_Endpoint.
    * Modified cmdlet New-BACCMemory: added parameter Tag.
    * Modified cmdlet New-BACCOauth2CredentialProvider: added parameters AtlassianOauth2ProviderConfig_ClientId, AtlassianOauth2ProviderConfig_ClientSecret, AuthorizationServerMetadata_TokenEndpointAuthMethod, IncludedOauth2ProviderConfig_AuthorizationEndpoint, IncludedOauth2ProviderConfig_ClientId, IncludedOauth2ProviderConfig_ClientSecret, IncludedOauth2ProviderConfig_Issuer, IncludedOauth2ProviderConfig_TokenEndpoint, LinkedinOauth2ProviderConfig_ClientId, LinkedinOauth2ProviderConfig_ClientSecret, MicrosoftOauth2ProviderConfig_TenantId and Tag.
    * Modified cmdlet New-BACCWorkloadIdentity: added parameter Tag.
    * Modified cmdlet Update-BACCAgentRuntime: added parameters LifecycleConfiguration_IdleRuntimeSessionTimeout and LifecycleConfiguration_MaxLifetime.
    * Modified cmdlet Update-BACCGatewayTarget: added parameter McpServer_Endpoint.
    * Modified cmdlet Update-BACCOauth2CredentialProvider: added parameters AtlassianOauth2ProviderConfig_ClientId, AtlassianOauth2ProviderConfig_ClientSecret, AuthorizationServerMetadata_TokenEndpointAuthMethod, IncludedOauth2ProviderConfig_AuthorizationEndpoint, IncludedOauth2ProviderConfig_ClientId, IncludedOauth2ProviderConfig_ClientSecret, IncludedOauth2ProviderConfig_Issuer, IncludedOauth2ProviderConfig_TokenEndpoint, LinkedinOauth2ProviderConfig_ClientId, LinkedinOauth2ProviderConfig_ClientSecret and MicrosoftOauth2ProviderConfig_TenantId.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Complete-BACResourceTokenAuth leveraging the CompleteResourceTokenAuth service API.
    * Added cmdlet Get-BACAgentCard leveraging the GetAgentCard service API.
    * Added cmdlet New-BACBatchMemoryRecord leveraging the BatchCreateMemoryRecords service API.
    * Added cmdlet Remove-BACBatchMemoryRecord leveraging the BatchDeleteMemoryRecords service API.
    * Added cmdlet Stop-BACRuntimeSession leveraging the StopRuntimeSession service API.
    * Added cmdlet Update-BACBatchMemoryRecord leveraging the BatchUpdateMemoryRecords service API.
    * Modified cmdlet Get-BACEventList: added parameter Filter_EventMetadata.
    * Modified cmdlet Get-BACResourceOauth2Token: added parameters CustomState and SessionUri.
    * Modified cmdlet Invoke-BACAgentRuntime: added parameter AccountId.
    * Modified cmdlet Invoke-BACCodeInterpreter: added parameters TraceId and TraceParent.
    * Modified cmdlet New-BACEvent: added parameter Metadata.
    * Modified cmdlet Start-BACBrowserSession: added parameters TraceId and TraceParent.
    * Modified cmdlet Start-BACCodeInterpreterSession: added parameters TraceId and TraceParent.
    * Modified cmdlet Stop-BACBrowserSession: added parameters TraceId and TraceParent.
    * Modified cmdlet Stop-BACCodeInterpreterSession: added parameters TraceId and TraceParent.
  * Amazon Chime SDK Meetings
    * Modified cmdlet New-CHMTGMeeting: added parameter MediaPlacementNetworkType.
    * Modified cmdlet New-CHMTGMeetingWithAttendee: added parameter MediaPlacementNetworkType.
  * Amazon Clean Rooms Service
    * Modified cmdlet Get-CRSCollaborationPrivacyBudgetList: added parameter AccessBudgetResourceArn.
    * Modified cmdlet Get-CRSPrivacyBudgetList: added parameter AccessBudgetResourceArn.
    * Modified cmdlet New-CRSCollaboration: added parameter AllowedResultRegion.
    * Modified cmdlet New-CRSConfiguredTable: added parameters Athena_Region and Glue_Region.
    * Modified cmdlet New-CRSPrivacyBudgetTemplate: added parameters AccessBudget_BudgetParameter and AccessBudget_ResourceArn.
    * Modified cmdlet Update-CRSConfiguredTable: added parameters Athena_Region and Glue_Region.
    * Modified cmdlet Update-CRSPrivacyBudgetTemplate: added parameter AccessBudget_BudgetParameter.
  * Amazon CloudWatch Observability Admin Service
    * Added cmdlet Get-CWOADMNTelemetryEnrichmentStatus leveraging the GetTelemetryEnrichmentStatus service API.
    * Added cmdlet Start-CWOADMNTelemetryEnrichment leveraging the StartTelemetryEnrichment service API.
    * Added cmdlet Stop-CWOADMNTelemetryEnrichment leveraging the StopTelemetryEnrichment service API.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter Code_BlueprintType.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameter Code_BlueprintType.
    * Modified cmdlet Update-CWSYNCanary: added parameter Code_BlueprintType.
  * Amazon Connect Cases
    * Added cmdlet Search-CCASAllRelatedItem leveraging the SearchAllRelatedItems service API.
  * Amazon DataZone
    * Modified cmdlet Get-DZConnectionList: added parameter Scope.
    * Modified cmdlet New-DZConnection: added parameters AmazonQProperties_AuthMode, AmazonQProperties_IsEnabled, AmazonQProperties_ProfileArn, EnableTrustedIdentityPropagation and Scope.
    * Modified cmdlet Update-DZConnection: added parameters AmazonQProperties_AuthMode, AmazonQProperties_IsEnabled and AmazonQProperties_ProfileArn.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet Edit-DOCDBCluster: added parameter NetworkType.
    * Modified cmdlet New-DOCDBCluster: added parameter NetworkType.
    * Modified cmdlet Restore-DOCDBClusterFromSnapshot: added parameter NetworkType.
    * Modified cmdlet Restore-DOCDBClusterToPointInTime: added parameter NetworkType.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Copy-EC2Volume leveraging the CopyVolumes service API.
    * Added cmdlet Disable-EC2CapacityManager leveraging the DisableCapacityManager service API.
    * Added cmdlet Enable-EC2CapacityManager leveraging the EnableCapacityManager service API.
    * Added cmdlet Get-EC2CapacityManagerAttribute leveraging the GetCapacityManagerAttributes service API.
    * Added cmdlet Get-EC2CapacityManagerDataExport leveraging the DescribeCapacityManagerDataExports service API.
    * Added cmdlet Get-EC2CapacityManagerMetricData leveraging the GetCapacityManagerMetricData service API.
    * Added cmdlet Get-EC2CapacityManagerMetricDimension leveraging the GetCapacityManagerMetricDimensions service API.
    * Added cmdlet New-EC2CapacityManagerDataExport leveraging the CreateCapacityManagerDataExport service API.
    * Added cmdlet Remove-EC2CapacityManagerDataExport leveraging the DeleteCapacityManagerDataExport service API.
    * Added cmdlet Update-EC2CapacityManagerOrganizationsAccess leveraging the UpdateCapacityManagerOrganizationsAccess service API.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Edit-ELB2Rule: added parameters ResetTransform and Transform.
    * Modified cmdlet New-ELB2Rule: added parameter Transform.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNFlow: added parameter FlowTag.
    * Modified cmdlet Update-EMCNFlow: added parameter FlowSize.
  * Amazon Glue
    * Modified cmdlet Get-GLUETable: added parameters AuditContext_AdditionalAuditContext, AuditContext_AllColumnsRequested and AuditContext_RequestedColumn.
    * Modified cmdlet Get-GLUETableList: added parameters AuditContext_AdditionalAuditContext, AuditContext_AllColumnsRequested and AuditContext_RequestedColumn.
  * Amazon Lambda
    * Modified cmdlet Add-LMPermission: added parameter InvokedViaFunctionUrl.
  * Amazon License Manager User Subscription
    * Modified cmdlet Add-LMUSUser: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Get-LMUSProductSubscriptionList: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Get-LMUSUserAssociationList: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Register-LMUSIdentityProvider: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Remove-LMUSUser: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Start-LMUSProductSubscription: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Stop-LMUSProductSubscription: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Unregister-LMUSIdentityProvider: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Update-LMUSIdentityProviderSetting: added parameter ActiveDirectorySettings_DomainIpv6List.
  * Amazon Lightsail
    * Modified cmdlet Get-LSBucket: added parameter IncludeCor.
    * Modified cmdlet Update-LSBucket: added parameter Cors_Rule.
  * Amazon MemoryDB
    * Added cmdlet Get-MDBMultiRegionParameter leveraging the DescribeMultiRegionParameters service API.
    * Added cmdlet Get-MDBMultiRegionParameterGroup leveraging the DescribeMultiRegionParameterGroups service API.
  * Amazon Oracle Database@Amazon Web Services
    * Added cmdlet Update-ODBOdbPeeringConnection leveraging the UpdateOdbPeeringConnection service API.
    * Modified cmdlet New-ODBOdbPeeringConnection: added parameter PeerNetworkCidrsToBeAdded.
  * Amazon Outposts
    * Added cmdlet Start-OUTPOutpostDecommission leveraging the StartOutpostDecommission service API.
  * Amazon Parallel Computing Service
    * Added cmdlet Update-PCSCluster leveraging the UpdateCluster service API.
    * Modified cmdlet New-PCSQueue: added parameter SlurmConfiguration_SlurmCustomSetting.
    * Modified cmdlet Update-PCSQueue: added parameter SlurmConfiguration_SlurmCustomSetting.
  * Amazon Payment Cryptography Data
    * Added cmdlet Convert-PAYCDKeyMaterial leveraging the TranslateKeyMaterial service API.
  * Amazon Q Connect
    * Modified cmdlet New-QCAIAgent: added parameters EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration, EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_Locale, EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId, EmailOverviewAIAgentConfiguration_Locale, EmailResponseAIAgentConfiguration_AssociationConfiguration, EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailResponseAIAgentConfiguration_EmailResponseAIPromptId and EmailResponseAIAgentConfiguration_Locale.
    * Modified cmdlet New-QCSession: added parameter ContactArn.
    * Modified cmdlet Update-QCAIAgent: added parameters EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration, EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_Locale, EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId, EmailOverviewAIAgentConfiguration_Locale, EmailResponseAIAgentConfiguration_AssociationConfiguration, EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailResponseAIAgentConfiguration_EmailResponseAIPromptId and EmailResponseAIAgentConfiguration_Locale.
  * Amazon QuickSight
    * Added cmdlet Get-QSActionConnector leveraging the DescribeActionConnector service API.
    * Added cmdlet Get-QSActionConnectorList leveraging the ListActionConnectors service API.
    * Added cmdlet Get-QSActionConnectorPermission leveraging the DescribeActionConnectorPermissions service API.
    * Added cmdlet Get-QSFlowList leveraging the ListFlows service API.
    * Added cmdlet Get-QSFlowMetadata leveraging the GetFlowMetadata service API.
    * Added cmdlet Get-QSFlowPermission leveraging the GetFlowPermissions service API.
    * Added cmdlet New-QSActionConnector leveraging the CreateActionConnector service API.
    * Added cmdlet Remove-QSActionConnector leveraging the DeleteActionConnector service API.
    * Added cmdlet Search-QSActionConnector leveraging the SearchActionConnectors service API.
    * Added cmdlet Search-QSFlow leveraging the SearchFlows service API.
    * Added cmdlet Update-QSActionConnector leveraging the UpdateActionConnector service API.
    * Added cmdlet Update-QSActionConnectorPermission leveraging the UpdateActionConnectorPermissions service API.
    * Added cmdlet Update-QSFlowPermission leveraging the UpdateFlowPermissions service API.
    * Modified cmdlet New-QSBrand: added parameters Automation_Background, Automation_Foreground, Connection_Background, Connection_Foreground, Insight_Background, Insight_Foreground, Visualization_Background and Visualization_Foreground.
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_Action, Capabilities_Automate, Capabilities_ChatAgent, Capabilities_CreateChatAgent, Capabilities_Flow, Capabilities_KnowledgeBase, Capabilities_PerformFlowUiTask, Capabilities_PublishWithoutApproval, Capabilities_Research, Capabilities_Space, Capabilities_UseAgentWebSearch and Capabilities_UseBedrockModel.
    * Modified cmdlet New-QSDashboard: added parameter QuickSuiteActionsOption_AvailabilityStatus.
    * Modified cmdlet New-QSDataSource: added parameters ConfluenceParameters_ConfluenceUrl, QBusinessParameters_ApplicationArn, S3KnowledgeBaseParameters_BucketUrl, S3KnowledgeBaseParameters_MetadataFilesLocation, S3KnowledgeBaseParameters_RoleArn, WebCrawlerParameters_LoginPageUrl, WebCrawlerParameters_PasswordButtonXpath, WebCrawlerParameters_PasswordFieldXpath, WebCrawlerParameters_UsernameButtonXpath, WebCrawlerParameters_UsernameFieldXpath, WebCrawlerParameters_WebCrawlerAuthType, WebCrawlerParameters_WebProxyHostName, WebCrawlerParameters_WebProxyPortNumber, WebProxyCredentials_WebProxyPassword and WebProxyCredentials_WebProxyUsername.
    * Modified cmdlet Update-QSBrand: added parameters Automation_Background, Automation_Foreground, Connection_Background, Connection_Foreground, Insight_Background, Insight_Foreground, Visualization_Background and Visualization_Foreground.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_Action, Capabilities_Automate, Capabilities_ChatAgent, Capabilities_CreateChatAgent, Capabilities_Flow, Capabilities_KnowledgeBase, Capabilities_PerformFlowUiTask, Capabilities_PublishWithoutApproval, Capabilities_Research, Capabilities_Space, Capabilities_UseAgentWebSearch and Capabilities_UseBedrockModel.
    * Modified cmdlet Update-QSDashboard: added parameter QuickSuiteActionsOption_AvailabilityStatus.
    * Modified cmdlet Update-QSDataSource: added parameters ConfluenceParameters_ConfluenceUrl, QBusinessParameters_ApplicationArn, S3KnowledgeBaseParameters_BucketUrl, S3KnowledgeBaseParameters_MetadataFilesLocation, S3KnowledgeBaseParameters_RoleArn, WebCrawlerParameters_LoginPageUrl, WebCrawlerParameters_PasswordButtonXpath, WebCrawlerParameters_PasswordFieldXpath, WebCrawlerParameters_UsernameButtonXpath, WebCrawlerParameters_UsernameFieldXpath, WebCrawlerParameters_WebCrawlerAuthType, WebCrawlerParameters_WebProxyHostName, WebCrawlerParameters_WebProxyPortNumber, WebProxyCredentials_WebProxyPassword and WebProxyCredentials_WebProxyUsername.
  * Amazon Resource Explorer
    * Added cmdlet Get-AREXResourceExplorerSetup leveraging the GetResourceExplorerSetup service API.
    * Added cmdlet Get-AREXServiceIndex leveraging the GetServiceIndex service API.
    * Added cmdlet Get-AREXServiceIndexList leveraging the ListServiceIndexes service API.
    * Added cmdlet Get-AREXServiceView leveraging the GetServiceView service API.
    * Added cmdlet Get-AREXServiceViewList leveraging the ListServiceViews service API.
    * Added cmdlet Get-AREXStreamingAccessForServiceList leveraging the ListStreamingAccessForServices service API.
    * Added cmdlet New-AREXResourceExplorerSetup leveraging the CreateResourceExplorerSetup service API.
    * Added cmdlet Remove-AREXResourceExplorerSetup leveraging the DeleteResourceExplorerSetup service API.
  * Amazon Service Quotas
    * Added cmdlet Get-SQAutoManagementConfiguration leveraging the GetAutoManagementConfiguration service API.
    * Added cmdlet Start-SQAutoManagement leveraging the StartAutoManagement service API.
    * Added cmdlet Stop-SQAutoManagement leveraging the StopAutoManagement service API.
    * Added cmdlet Update-SQAutoManagement leveraging the UpdateAutoManagement service API.
  * Amazon Timestream InfluxDB
    * Modified cmdlet New-TIDBDbParameterGroup: added parameters CatalogSyncInterval_DurationType, CatalogSyncInterval_Value, CompactionCheckInterval_DurationType, CompactionCheckInterval_Value, CompactionCleanupWait_DurationType, CompactionCleanupWait_Value, CompactionGen2Duration_DurationType, CompactionGen2Duration_Value, InfluxDBv3Core_DataFusionConfig, InfluxDBv3Core_DataFusionMaxParquetFanout, InfluxDBv3Core_DataFusionNumThread, InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot, InfluxDBv3Core_DataFusionRuntimeEventInterval, InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval, InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread, InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick, InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType, InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value, InfluxDBv3Core_DataFusionRuntimeThreadPriority, InfluxDBv3Core_DataFusionRuntimeType, InfluxDBv3Core_DataFusionUseCachedParquetLoader, InfluxDBv3Core_DeleteGracePeriod_DurationType, InfluxDBv3Core_DeleteGracePeriod_Value, InfluxDBv3Core_DisableParquetMemCache, InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType, InfluxDBv3Core_DistinctCacheEvictionInterval_Value, InfluxDBv3Core_ExecMemPoolBytes_Absolute, InfluxDBv3Core_ExecMemPoolBytes_Percent, InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute, InfluxDBv3Core_ForceSnapshotMemThreshold_Percent, InfluxDBv3Core_Gen1Duration_DurationType, InfluxDBv3Core_Gen1Duration_Value, InfluxDBv3Core_Gen1LookbackDuration_DurationType, InfluxDBv3Core_Gen1LookbackDuration_Value, InfluxDBv3Core_HardDeleteDefaultDuration_DurationType, InfluxDBv3Core_HardDeleteDefaultDuration_Value, InfluxDBv3Core_LastCacheEvictionInterval_DurationType, InfluxDBv3Core_LastCacheEvictionInterval_Value, InfluxDBv3Core_LogFilter, InfluxDBv3Core_LogFormat, InfluxDBv3Core_MaxHttpRequestSize, InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType, InfluxDBv3Core_ParquetMemCachePruneInterval_Value, InfluxDBv3Core_ParquetMemCachePrunePercentage, InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType, InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value, InfluxDBv3Core_ParquetMemCacheSize_Absolute, InfluxDBv3Core_ParquetMemCacheSize_Percent, InfluxDBv3Core_PreemptiveCacheAge_DurationType, InfluxDBv3Core_PreemptiveCacheAge_Value, InfluxDBv3Core_QueryFileLimit, InfluxDBv3Core_QueryLogSize, InfluxDBv3Core_RetentionCheckInterval_DurationType, InfluxDBv3Core_RetentionCheckInterval_Value, InfluxDBv3Core_SnapshottedWalFilesToKeep, InfluxDBv3Core_TableIndexCacheConcurrencyLimit, InfluxDBv3Core_TableIndexCacheMaxEntry, InfluxDBv3Core_WalMaxWriteBufferSize, InfluxDBv3Core_WalReplayConcurrencyLimit, InfluxDBv3Core_WalReplayFailOnError, InfluxDBv3Core_WalSnapshotSize, InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan, InfluxDBv3Enterprise_CompactionMultiplier, InfluxDBv3Enterprise_CompactionRowLimit, InfluxDBv3Enterprise_DataFusionConfig, InfluxDBv3Enterprise_DataFusionMaxParquetFanout, InfluxDBv3Enterprise_DataFusionNumThread, InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot, InfluxDBv3Enterprise_DataFusionRuntimeEventInterval, InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval, InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread, InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick, InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType, InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value, InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority, InfluxDBv3Enterprise_DataFusionRuntimeType, InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader, InfluxDBv3Enterprise_DedicatedCompactor, InfluxDBv3Enterprise_DeleteGracePeriod_DurationType, InfluxDBv3Enterprise_DeleteGracePeriod_Value, InfluxDBv3Enterprise_DisableParquetMemCache, InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType, InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value, InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory, InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute, InfluxDBv3Enterprise_ExecMemPoolBytes_Percent, InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute, InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent, InfluxDBv3Enterprise_Gen1Duration_DurationType, InfluxDBv3Enterprise_Gen1Duration_Value, InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType, InfluxDBv3Enterprise_Gen1LookbackDuration_Value, InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType, InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value, InfluxDBv3Enterprise_IngestQueryInstance, InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType, InfluxDBv3Enterprise_LastCacheEvictionInterval_Value, InfluxDBv3Enterprise_LastValueCacheDisableFromHistory, InfluxDBv3Enterprise_LogFilter, InfluxDBv3Enterprise_LogFormat, InfluxDBv3Enterprise_MaxHttpRequestSize, InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType, InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value, InfluxDBv3Enterprise_ParquetMemCachePrunePercentage, InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType, InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value, InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute, InfluxDBv3Enterprise_ParquetMemCacheSize_Percent, InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType, InfluxDBv3Enterprise_PreemptiveCacheAge_Value, InfluxDBv3Enterprise_QueryFileLimit, InfluxDBv3Enterprise_QueryLogSize, InfluxDBv3Enterprise_QueryOnlyInstance, InfluxDBv3Enterprise_RetentionCheckInterval_DurationType, InfluxDBv3Enterprise_RetentionCheckInterval_Value, InfluxDBv3Enterprise_SnapshottedWalFilesToKeep, InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit, InfluxDBv3Enterprise_TableIndexCacheMaxEntry, InfluxDBv3Enterprise_WalMaxWriteBufferSize, InfluxDBv3Enterprise_WalReplayConcurrencyLimit, InfluxDBv3Enterprise_WalReplayFailOnError, InfluxDBv3Enterprise_WalSnapshotSize, ReplicationInterval_DurationType and ReplicationInterval_Value.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameters VpcLattice_PortNumber and VpcLattice_ResourceConfigurationArn.
    * Modified cmdlet Update-TFRConnector: added parameters VpcLattice_PortNumber and VpcLattice_ResourceConfigurationArn.

### 5.0.77 (2025-10-15 20:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.113.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet New-BDRAutomatedReasoningPolicy: added parameter KmsKeyId.
    * Modified cmdlet Remove-BDRAutomatedReasoningPolicy: added parameter ForceDelete.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet Edit-DOCDBCluster: added parameter NetworkType.
    * Modified cmdlet New-DOCDBCluster: added parameter NetworkType.
    * Modified cmdlet Restore-DOCDBClusterFromSnapshot: added parameter NetworkType.
    * Modified cmdlet Restore-DOCDBClusterToPointInTime: added parameter NetworkType.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Disable-EC2CapacityManager leveraging the DisableCapacityManager service API.
    * Added cmdlet Enable-EC2CapacityManager leveraging the EnableCapacityManager service API.
    * Added cmdlet Get-EC2CapacityManagerAttribute leveraging the GetCapacityManagerAttributes service API.
    * Added cmdlet Get-EC2CapacityManagerDataExport leveraging the DescribeCapacityManagerDataExports service API.
    * Added cmdlet Get-EC2CapacityManagerMetricData leveraging the GetCapacityManagerMetricData service API.
    * Added cmdlet Get-EC2CapacityManagerMetricDimension leveraging the GetCapacityManagerMetricDimensions service API.
    * Added cmdlet New-EC2CapacityManagerDataExport leveraging the CreateCapacityManagerDataExport service API.
    * Added cmdlet Remove-EC2CapacityManagerDataExport leveraging the DeleteCapacityManagerDataExport service API.
    * Added cmdlet Update-EC2CapacityManagerOrganizationsAccess leveraging the UpdateCapacityManagerOrganizationsAccess service API.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Edit-ELB2Rule: added parameters ResetTransform and Transform.
    * Modified cmdlet New-ELB2Rule: added parameter Transform.
  * Amazon Lightsail
    * Modified cmdlet Get-LSBucket: added parameter IncludeCor.
    * Modified cmdlet Update-LSBucket: added parameter Cors_Rule.
  * Amazon Timestream InfluxDB
    * Modified cmdlet New-TIDBDbParameterGroup: added parameters CatalogSyncInterval_DurationType, CatalogSyncInterval_Value, CompactionCheckInterval_DurationType, CompactionCheckInterval_Value, CompactionCleanupWait_DurationType, CompactionCleanupWait_Value, CompactionGen2Duration_DurationType, CompactionGen2Duration_Value, InfluxDBv3Core_DataFusionConfig, InfluxDBv3Core_DataFusionMaxParquetFanout, InfluxDBv3Core_DataFusionNumThread, InfluxDBv3Core_DataFusionRuntimeDisableLifoSlot, InfluxDBv3Core_DataFusionRuntimeEventInterval, InfluxDBv3Core_DataFusionRuntimeGlobalQueueInterval, InfluxDBv3Core_DataFusionRuntimeMaxBlockingThread, InfluxDBv3Core_DataFusionRuntimeMaxIoEventsPerTick, InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType, InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_Value, InfluxDBv3Core_DataFusionRuntimeThreadPriority, InfluxDBv3Core_DataFusionRuntimeType, InfluxDBv3Core_DataFusionUseCachedParquetLoader, InfluxDBv3Core_DeleteGracePeriod_DurationType, InfluxDBv3Core_DeleteGracePeriod_Value, InfluxDBv3Core_DisableParquetMemCache, InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType, InfluxDBv3Core_DistinctCacheEvictionInterval_Value, InfluxDBv3Core_ExecMemPoolBytes_Absolute, InfluxDBv3Core_ExecMemPoolBytes_Percent, InfluxDBv3Core_ForceSnapshotMemThreshold_Absolute, InfluxDBv3Core_ForceSnapshotMemThreshold_Percent, InfluxDBv3Core_Gen1Duration_DurationType, InfluxDBv3Core_Gen1Duration_Value, InfluxDBv3Core_Gen1LookbackDuration_DurationType, InfluxDBv3Core_Gen1LookbackDuration_Value, InfluxDBv3Core_HardDeleteDefaultDuration_DurationType, InfluxDBv3Core_HardDeleteDefaultDuration_Value, InfluxDBv3Core_LastCacheEvictionInterval_DurationType, InfluxDBv3Core_LastCacheEvictionInterval_Value, InfluxDBv3Core_LogFilter, InfluxDBv3Core_LogFormat, InfluxDBv3Core_MaxHttpRequestSize, InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType, InfluxDBv3Core_ParquetMemCachePruneInterval_Value, InfluxDBv3Core_ParquetMemCachePrunePercentage, InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType, InfluxDBv3Core_ParquetMemCacheQueryPathDuration_Value, InfluxDBv3Core_ParquetMemCacheSize_Absolute, InfluxDBv3Core_ParquetMemCacheSize_Percent, InfluxDBv3Core_PreemptiveCacheAge_DurationType, InfluxDBv3Core_PreemptiveCacheAge_Value, InfluxDBv3Core_QueryFileLimit, InfluxDBv3Core_QueryLogSize, InfluxDBv3Core_RetentionCheckInterval_DurationType, InfluxDBv3Core_RetentionCheckInterval_Value, InfluxDBv3Core_SnapshottedWalFilesToKeep, InfluxDBv3Core_TableIndexCacheConcurrencyLimit, InfluxDBv3Core_TableIndexCacheMaxEntry, InfluxDBv3Core_WalMaxWriteBufferSize, InfluxDBv3Core_WalReplayConcurrencyLimit, InfluxDBv3Core_WalReplayFailOnError, InfluxDBv3Core_WalSnapshotSize, InfluxDBv3Enterprise_CompactionMaxNumFilesPerPlan, InfluxDBv3Enterprise_CompactionMultiplier, InfluxDBv3Enterprise_CompactionRowLimit, InfluxDBv3Enterprise_DataFusionConfig, InfluxDBv3Enterprise_DataFusionMaxParquetFanout, InfluxDBv3Enterprise_DataFusionNumThread, InfluxDBv3Enterprise_DataFusionRuntimeDisableLifoSlot, InfluxDBv3Enterprise_DataFusionRuntimeEventInterval, InfluxDBv3Enterprise_DataFusionRuntimeGlobalQueueInterval, InfluxDBv3Enterprise_DataFusionRuntimeMaxBlockingThread, InfluxDBv3Enterprise_DataFusionRuntimeMaxIoEventsPerTick, InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType, InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_Value, InfluxDBv3Enterprise_DataFusionRuntimeThreadPriority, InfluxDBv3Enterprise_DataFusionRuntimeType, InfluxDBv3Enterprise_DataFusionUseCachedParquetLoader, InfluxDBv3Enterprise_DedicatedCompactor, InfluxDBv3Enterprise_DeleteGracePeriod_DurationType, InfluxDBv3Enterprise_DeleteGracePeriod_Value, InfluxDBv3Enterprise_DisableParquetMemCache, InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType, InfluxDBv3Enterprise_DistinctCacheEvictionInterval_Value, InfluxDBv3Enterprise_DistinctValueCacheDisableFromHistory, InfluxDBv3Enterprise_ExecMemPoolBytes_Absolute, InfluxDBv3Enterprise_ExecMemPoolBytes_Percent, InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Absolute, InfluxDBv3Enterprise_ForceSnapshotMemThreshold_Percent, InfluxDBv3Enterprise_Gen1Duration_DurationType, InfluxDBv3Enterprise_Gen1Duration_Value, InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType, InfluxDBv3Enterprise_Gen1LookbackDuration_Value, InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType, InfluxDBv3Enterprise_HardDeleteDefaultDuration_Value, InfluxDBv3Enterprise_IngestQueryInstance, InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType, InfluxDBv3Enterprise_LastCacheEvictionInterval_Value, InfluxDBv3Enterprise_LastValueCacheDisableFromHistory, InfluxDBv3Enterprise_LogFilter, InfluxDBv3Enterprise_LogFormat, InfluxDBv3Enterprise_MaxHttpRequestSize, InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType, InfluxDBv3Enterprise_ParquetMemCachePruneInterval_Value, InfluxDBv3Enterprise_ParquetMemCachePrunePercentage, InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType, InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_Value, InfluxDBv3Enterprise_ParquetMemCacheSize_Absolute, InfluxDBv3Enterprise_ParquetMemCacheSize_Percent, InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType, InfluxDBv3Enterprise_PreemptiveCacheAge_Value, InfluxDBv3Enterprise_QueryFileLimit, InfluxDBv3Enterprise_QueryLogSize, InfluxDBv3Enterprise_QueryOnlyInstance, InfluxDBv3Enterprise_RetentionCheckInterval_DurationType, InfluxDBv3Enterprise_RetentionCheckInterval_Value, InfluxDBv3Enterprise_SnapshottedWalFilesToKeep, InfluxDBv3Enterprise_TableIndexCacheConcurrencyLimit, InfluxDBv3Enterprise_TableIndexCacheMaxEntry, InfluxDBv3Enterprise_WalMaxWriteBufferSize, InfluxDBv3Enterprise_WalReplayConcurrencyLimit, InfluxDBv3Enterprise_WalReplayFailOnError, InfluxDBv3Enterprise_WalSnapshotSize, ReplicationInterval_DurationType and ReplicationInterval_Value.

### 5.0.76 (2025-10-14 20:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.112.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Added cmdlet Add-APSSoftwareToImageBuilder leveraging the AssociateSoftwareToImageBuilder service API.
    * Added cmdlet Get-APSAppLicenseUsage leveraging the DescribeAppLicenseUsage service API.
    * Added cmdlet Get-APSSoftwareAssociation leveraging the DescribeSoftwareAssociations service API.
    * Added cmdlet Remove-APSSoftwareFromImageBuilder leveraging the DisassociateSoftwareFromImageBuilder service API.
    * Added cmdlet Start-APSSoftwareDeploymentToImageBuilder leveraging the StartSoftwareDeploymentToImageBuilder service API.
    * Modified cmdlet New-APSImageBuilder: added parameters SoftwaresToInstall and SoftwaresToUninstall.
  * Amazon DataZone
    * Modified cmdlet Get-DZConnectionList: added parameter Scope.
    * Modified cmdlet New-DZConnection: added parameters AmazonQProperties_AuthMode, AmazonQProperties_IsEnabled, AmazonQProperties_ProfileArn, EnableTrustedIdentityPropagation and Scope.
    * Modified cmdlet Update-DZConnection: added parameters AmazonQProperties_AuthMode, AmazonQProperties_IsEnabled and AmazonQProperties_ProfileArn.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Copy-EC2Volume leveraging the CopyVolumes service API.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameters VpcLattice_PortNumber and VpcLattice_ResourceConfigurationArn.
    * Modified cmdlet Update-TFRConnector: added parameters VpcLattice_PortNumber and VpcLattice_ResourceConfigurationArn.

### 5.0.75 (2025-10-13 20:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.111.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCApiKeyCredentialProvider: added parameter Tag.
    * Modified cmdlet New-BACCOauth2CredentialProvider: added parameters AtlassianOauth2ProviderConfig_ClientId, AtlassianOauth2ProviderConfig_ClientSecret, AuthorizationServerMetadata_TokenEndpointAuthMethod, IncludedOauth2ProviderConfig_AuthorizationEndpoint, IncludedOauth2ProviderConfig_ClientId, IncludedOauth2ProviderConfig_ClientSecret, IncludedOauth2ProviderConfig_Issuer, IncludedOauth2ProviderConfig_TokenEndpoint, LinkedinOauth2ProviderConfig_ClientId, LinkedinOauth2ProviderConfig_ClientSecret, MicrosoftOauth2ProviderConfig_TenantId and Tag.
    * Modified cmdlet New-BACCWorkloadIdentity: added parameter Tag.
    * Modified cmdlet Update-BACCOauth2CredentialProvider: added parameters AtlassianOauth2ProviderConfig_ClientId, AtlassianOauth2ProviderConfig_ClientSecret, AuthorizationServerMetadata_TokenEndpointAuthMethod, IncludedOauth2ProviderConfig_AuthorizationEndpoint, IncludedOauth2ProviderConfig_ClientId, IncludedOauth2ProviderConfig_ClientSecret, IncludedOauth2ProviderConfig_Issuer, IncludedOauth2ProviderConfig_TokenEndpoint, LinkedinOauth2ProviderConfig_ClientId, LinkedinOauth2ProviderConfig_ClientSecret and MicrosoftOauth2ProviderConfig_TenantId.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Complete-BACResourceTokenAuth leveraging the CompleteResourceTokenAuth service API.
    * Modified cmdlet Get-BACResourceOauth2Token: added parameters CustomState and SessionUri.
    * Modified cmdlet Invoke-BACAgentRuntime: added parameter AccountId.
  * Amazon CloudWatch Observability Admin Service
    * Added cmdlet Get-CWOADMNTelemetryEnrichmentStatus leveraging the GetTelemetryEnrichmentStatus service API.
    * Added cmdlet Start-CWOADMNTelemetryEnrichment leveraging the StartTelemetryEnrichment service API.
    * Added cmdlet Stop-CWOADMNTelemetryEnrichment leveraging the StopTelemetryEnrichment service API.

### 5.0.74 (2025-10-10 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.110.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Added cmdlet Sync-BACCGatewayTarget leveraging the SynchronizeGatewayTargets service API.
    * Modified cmdlet New-BACCGatewayTarget: added parameter McpServer_Endpoint.
    * Modified cmdlet Update-BACCGatewayTarget: added parameter McpServer_Endpoint.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Invoke-BACCodeInterpreter: added parameters TraceId and TraceParent.
    * Modified cmdlet Start-BACBrowserSession: added parameters TraceId and TraceParent.
    * Modified cmdlet Start-BACCodeInterpreterSession: added parameters TraceId and TraceParent.
    * Modified cmdlet Stop-BACBrowserSession: added parameters TraceId and TraceParent.
    * Modified cmdlet Stop-BACCodeInterpreterSession: added parameters TraceId and TraceParent.
  * Amazon Glue
    * Modified cmdlet Get-GLUETable: added parameters AuditContext_AdditionalAuditContext, AuditContext_AllColumnsRequested and AuditContext_RequestedColumn.
    * Modified cmdlet Get-GLUETableList: added parameters AuditContext_AdditionalAuditContext, AuditContext_AllColumnsRequested and AuditContext_RequestedColumn.
  * Amazon Lambda
    * Modified cmdlet Add-LMPermission: added parameter InvokedViaFunctionUrl.
  * Amazon Oracle Database@Amazon Web Services
    * Added cmdlet Update-ODBOdbPeeringConnection leveraging the UpdateOdbPeeringConnection service API.
    * Modified cmdlet New-ODBOdbPeeringConnection: added parameter PeerNetworkCidrsToBeAdded.

### 5.0.73 (2025-10-09 20:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.109.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QuickSight
    * Added cmdlet Get-QSActionConnector leveraging the DescribeActionConnector service API.
    * Added cmdlet Get-QSActionConnectorList leveraging the ListActionConnectors service API.
    * Added cmdlet Get-QSActionConnectorPermission leveraging the DescribeActionConnectorPermissions service API.
    * Added cmdlet Get-QSFlowList leveraging the ListFlows service API.
    * Added cmdlet Get-QSFlowMetadata leveraging the GetFlowMetadata service API.
    * Added cmdlet Get-QSFlowPermission leveraging the GetFlowPermissions service API.
    * Added cmdlet New-QSActionConnector leveraging the CreateActionConnector service API.
    * Added cmdlet Remove-QSActionConnector leveraging the DeleteActionConnector service API.
    * Added cmdlet Search-QSActionConnector leveraging the SearchActionConnectors service API.
    * Added cmdlet Search-QSFlow leveraging the SearchFlows service API.
    * Added cmdlet Update-QSActionConnector leveraging the UpdateActionConnector service API.
    * Added cmdlet Update-QSActionConnectorPermission leveraging the UpdateActionConnectorPermissions service API.
    * Added cmdlet Update-QSFlowPermission leveraging the UpdateFlowPermissions service API.
    * Modified cmdlet New-QSBrand: added parameters Automation_Background, Automation_Foreground, Connection_Background, Connection_Foreground, Insight_Background, Insight_Foreground, Visualization_Background and Visualization_Foreground.
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_Action, Capabilities_Automate, Capabilities_ChatAgent, Capabilities_CreateChatAgent, Capabilities_Flow, Capabilities_KnowledgeBase, Capabilities_PerformFlowUiTask, Capabilities_PublishWithoutApproval, Capabilities_Research, Capabilities_Space, Capabilities_UseAgentWebSearch and Capabilities_UseBedrockModel.
    * Modified cmdlet New-QSDashboard: added parameter QuickSuiteActionsOption_AvailabilityStatus.
    * Modified cmdlet New-QSDataSource: added parameters ConfluenceParameters_ConfluenceUrl, QBusinessParameters_ApplicationArn, S3KnowledgeBaseParameters_BucketUrl, S3KnowledgeBaseParameters_MetadataFilesLocation, S3KnowledgeBaseParameters_RoleArn, WebCrawlerParameters_LoginPageUrl, WebCrawlerParameters_PasswordButtonXpath, WebCrawlerParameters_PasswordFieldXpath, WebCrawlerParameters_UsernameButtonXpath, WebCrawlerParameters_UsernameFieldXpath, WebCrawlerParameters_WebCrawlerAuthType, WebCrawlerParameters_WebProxyHostName, WebCrawlerParameters_WebProxyPortNumber, WebProxyCredentials_WebProxyPassword and WebProxyCredentials_WebProxyUsername.
    * Modified cmdlet Update-QSBrand: added parameters Automation_Background, Automation_Foreground, Connection_Background, Connection_Foreground, Insight_Background, Insight_Foreground, Visualization_Background and Visualization_Foreground.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_Action, Capabilities_Automate, Capabilities_ChatAgent, Capabilities_CreateChatAgent, Capabilities_Flow, Capabilities_KnowledgeBase, Capabilities_PerformFlowUiTask, Capabilities_PublishWithoutApproval, Capabilities_Research, Capabilities_Space, Capabilities_UseAgentWebSearch and Capabilities_UseBedrockModel.
    * Modified cmdlet Update-QSDashboard: added parameter QuickSuiteActionsOption_AvailabilityStatus.
    * Modified cmdlet Update-QSDataSource: added parameters ConfluenceParameters_ConfluenceUrl, QBusinessParameters_ApplicationArn, S3KnowledgeBaseParameters_BucketUrl, S3KnowledgeBaseParameters_MetadataFilesLocation, S3KnowledgeBaseParameters_RoleArn, WebCrawlerParameters_LoginPageUrl, WebCrawlerParameters_PasswordButtonXpath, WebCrawlerParameters_PasswordFieldXpath, WebCrawlerParameters_UsernameButtonXpath, WebCrawlerParameters_UsernameFieldXpath, WebCrawlerParameters_WebCrawlerAuthType, WebCrawlerParameters_WebProxyHostName, WebCrawlerParameters_WebProxyPortNumber, WebProxyCredentials_WebProxyPassword and WebProxyCredentials_WebProxyUsername.

### 5.0.72 (2025-10-08 20:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.108.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon License Manager User Subscription
    * Modified cmdlet Add-LMUSUser: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Get-LMUSProductSubscriptionList: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Get-LMUSUserAssociationList: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Register-LMUSIdentityProvider: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Remove-LMUSUser: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Start-LMUSProductSubscription: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Stop-LMUSProductSubscription: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Unregister-LMUSIdentityProvider: added parameter ActiveDirectorySettings_DomainIpv6List.
    * Modified cmdlet Update-LMUSIdentityProviderSetting: added parameter ActiveDirectorySettings_DomainIpv6List.
  * Amazon Outposts
    * Added cmdlet Start-OUTPOutpostDecommission leveraging the StartOutpostDecommission service API.
  * Amazon Service Quotas
    * Added cmdlet Get-SQAutoManagementConfiguration leveraging the GetAutoManagementConfiguration service API.
    * Added cmdlet Start-SQAutoManagement leveraging the StartAutoManagement service API.
    * Added cmdlet Stop-SQAutoManagement leveraging the StopAutoManagement service API.
    * Added cmdlet Update-SQAutoManagement leveraging the UpdateAutoManagement service API.

### 5.0.71 (2025-10-07 19:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.107.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.70 (2025-10-06 20:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.106.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Modified cmdlet Get-BAKBackupPlan: added parameter MaxScheduledRunsPreview.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCAgentRuntime: added parameters LifecycleConfiguration_IdleRuntimeSessionTimeout and LifecycleConfiguration_MaxLifetime.
    * Modified cmdlet New-BACCMemory: added parameter Tag.
    * Modified cmdlet Update-BACCAgentRuntime: added parameters LifecycleConfiguration_IdleRuntimeSessionTimeout and LifecycleConfiguration_MaxLifetime.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Get-BACAgentCard leveraging the GetAgentCard service API.
    * Added cmdlet New-BACBatchMemoryRecord leveraging the BatchCreateMemoryRecords service API.
    * Added cmdlet Remove-BACBatchMemoryRecord leveraging the BatchDeleteMemoryRecords service API.
    * Added cmdlet Stop-BACRuntimeSession leveraging the StopRuntimeSession service API.
    * Added cmdlet Update-BACBatchMemoryRecord leveraging the BatchUpdateMemoryRecords service API.
    * Modified cmdlet Get-BACEventList: added parameter Filter_EventMetadata.
    * Modified cmdlet New-BACEvent: added parameter Metadata.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNFlow: added parameter FlowTag.
    * Modified cmdlet Update-EMCNFlow: added parameter FlowSize.
  * Amazon MemoryDB
    * Added cmdlet Get-MDBMultiRegionParameter leveraging the DescribeMultiRegionParameters service API.
    * Added cmdlet Get-MDBMultiRegionParameterGroup leveraging the DescribeMultiRegionParameterGroups service API.
  * Amazon Resource Explorer
    * Added cmdlet Get-AREXResourceExplorerSetup leveraging the GetResourceExplorerSetup service API.
    * Added cmdlet Get-AREXServiceIndex leveraging the GetServiceIndex service API.
    * Added cmdlet Get-AREXServiceIndexList leveraging the ListServiceIndexes service API.
    * Added cmdlet Get-AREXServiceView leveraging the GetServiceView service API.
    * Added cmdlet Get-AREXServiceViewList leveraging the ListServiceViews service API.
    * Added cmdlet Get-AREXStreamingAccessForServiceList leveraging the ListStreamingAccessForServices service API.
    * Added cmdlet New-AREXResourceExplorerSetup leveraging the CreateResourceExplorerSetup service API.
    * Added cmdlet Remove-AREXResourceExplorerSetup leveraging the DeleteResourceExplorerSetup service API.

### 5.0.69 (2025-10-03 20:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.105.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSCollaboration: added parameter AllowedResultRegion.
    * Modified cmdlet New-CRSConfiguredTable: added parameters Athena_Region and Glue_Region.
    * Modified cmdlet Update-CRSConfiguredTable: added parameters Athena_Region and Glue_Region.
  * Amazon Payment Cryptography Data
    * Added cmdlet Convert-PAYCDKeyMaterial leveraging the TranslateKeyMaterial service API.
  * Amazon Q Connect
    * Modified cmdlet New-QCAIAgent: added parameters EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration, EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_Locale, EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId, EmailOverviewAIAgentConfiguration_Locale, EmailResponseAIAgentConfiguration_AssociationConfiguration, EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailResponseAIAgentConfiguration_EmailResponseAIPromptId and EmailResponseAIAgentConfiguration_Locale.
    * Modified cmdlet New-QCSession: added parameter ContactArn.
    * Modified cmdlet Update-QCAIAgent: added parameters EmailGenerativeAnswerAIAgentConfiguration_AssociationConfiguration, EmailGenerativeAnswerAIAgentConfiguration_EmailGenerativeAnswerAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailGenerativeAnswerAIAgentConfiguration_Locale, EmailOverviewAIAgentConfiguration_EmailOverviewAIPromptId, EmailOverviewAIAgentConfiguration_Locale, EmailResponseAIAgentConfiguration_AssociationConfiguration, EmailResponseAIAgentConfiguration_EmailQueryReformulationAIPromptId, EmailResponseAIAgentConfiguration_EmailResponseAIPromptId and EmailResponseAIAgentConfiguration_Locale.

### 5.0.68 (2025-10-02 20:48Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.104.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter Code_BlueprintType.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameter Code_BlueprintType.
    * Modified cmdlet Update-CWSYNCanary: added parameter Code_BlueprintType.
  * Amazon Connect Cases
    * Added cmdlet Search-CCASAllRelatedItem leveraging the SearchAllRelatedItems service API.

### 5.0.67 (2025-10-01 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.103.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Meetings
    * Modified cmdlet New-CHMTGMeeting: added parameter MediaPlacementNetworkType.
    * Modified cmdlet New-CHMTGMeetingWithAttendee: added parameter MediaPlacementNetworkType.
  * Amazon Clean Rooms Service
    * Modified cmdlet Get-CRSCollaborationPrivacyBudgetList: added parameter AccessBudgetResourceArn.
    * Modified cmdlet Get-CRSPrivacyBudgetList: added parameter AccessBudgetResourceArn.
    * Modified cmdlet New-CRSPrivacyBudgetTemplate: added parameters AccessBudget_BudgetParameter and AccessBudget_ResourceArn.
    * Modified cmdlet Update-CRSPrivacyBudgetTemplate: added parameter AccessBudget_BudgetParameter.
  * Amazon Parallel Computing Service
    * Added cmdlet Update-PCSCluster leveraging the UpdateCluster service API.
    * Modified cmdlet New-PCSQueue: added parameter SlurmConfiguration_SlurmCustomSetting.
    * Modified cmdlet Update-PCSQueue: added parameter SlurmConfiguration_SlurmCustomSetting.

### 5.0.66 (2025-09-30 20:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.102.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCGateway: added parameter Tag.
  * Amazon Chime SDK Voice
    * Modified cmdlet New-CHMVOVoiceConnector: added parameter NetworkType.
  * Amazon CloudWatch Application Signals
    * Added cmdlet Get-CWASAuditFindingList leveraging the ListAuditFindings service API.
    * Added cmdlet Get-CWASGroupingAttributeDefinitionList leveraging the ListGroupingAttributeDefinitions service API.
    * Added cmdlet Get-CWASServiceStateList leveraging the ListServiceStates service API.
    * Added cmdlet Remove-CWASGroupingConfiguration leveraging the DeleteGroupingConfiguration service API.
    * Added cmdlet Write-CWASGroupingConfiguration leveraging the PutGroupingConfiguration service API.
    * Modified cmdlet New-CWASServiceLevelObjective: added parameter SliMetricConfig_MetricName.
    * Modified cmdlet Update-CWASServiceLevelObjective: added parameter SliMetricConfig_MetricName.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASRelatedItem: added parameters ConnectCase_CaseId and Custom_Field.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFProfileHistoryRecord leveraging the GetProfileHistoryRecord service API.
    * Added cmdlet Get-CPFProfileHistoryRecordList leveraging the ListProfileHistoryRecords service API.
  * Amazon DataZone
    * Modified cmdlet New-DZConnection: added parameter SparkEmrProperties_ManagedEndpointArn.
    * Modified cmdlet Update-DZConnection: added parameter SparkEmrProperties_ManagedEndpointArn.
  * Amazon Directory Service
    * Modified cmdlet Connect-DSDirectory: added parameters ConnectSettings_CustomerDnsIpsV6 and NetworkType.
    * Modified cmdlet Enable-DSRadius: added parameter RadiusSettings_RadiusServersIpv6.
    * Modified cmdlet New-DSConditionalForwarder: added parameter DnsIpv6Addr.
    * Modified cmdlet New-DSDirectory: added parameter NetworkType.
    * Modified cmdlet New-DSMicrosoftAD: added parameter NetworkType.
    * Modified cmdlet New-DSTrust: added parameter ConditionalForwarderIpv6Addr.
    * Modified cmdlet Remove-DSIpRoute: added parameter CidrIpv6.
    * Modified cmdlet Update-DSConditionalForwarder: added parameter DnsIpv6Addr.
    * Modified cmdlet Update-DSDirectorySetup: added parameters DirectorySizeUpdateSettings_DirectorySize, NetworkUpdateSettings_CustomerDnsIpsV6 and NetworkUpdateSettings_NetworkType.
    * Modified cmdlet Update-DSRadius: added parameter RadiusSettings_RadiusServersIpv6.
  * Amazon EC2 Container Service
    * Modified cmdlet Get-ECSCapacityProvider: added parameter Cluster.
    * Modified cmdlet New-ECSCapacityProvider: added parameters AcceleratorCount_Max, AcceleratorCount_Min, AcceleratorTotalMemoryMiB_Max, AcceleratorTotalMemoryMiB_Min, BaselineEbsBandwidthMbps_Max, BaselineEbsBandwidthMbps_Min, Cluster, InstanceLaunchTemplate_Ec2InstanceProfileArn, InstanceLaunchTemplate_Monitoring, InstanceRequirements_AcceleratorManufacturer, InstanceRequirements_AcceleratorName, InstanceRequirements_AcceleratorType, InstanceRequirements_AllowedInstanceType, InstanceRequirements_BareMetal, InstanceRequirements_BurstablePerformance, InstanceRequirements_CpuManufacturer, InstanceRequirements_ExcludedInstanceType, InstanceRequirements_InstanceGeneration, InstanceRequirements_LocalStorage, InstanceRequirements_LocalStorageType, InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice, InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice, InstanceRequirements_RequireHibernateSupport, InstanceRequirements_SpotMaxPricePercentageOverLowestPrice, ManagedInstancesProvider_InfrastructureRoleArn, ManagedInstancesProvider_PropagateTag, MemoryGiBPerVCpu_Max, MemoryGiBPerVCpu_Min, MemoryMiB_Max, MemoryMiB_Min, NetworkBandwidthGbps_Max, NetworkBandwidthGbps_Min, NetworkConfiguration_SecurityGroup, NetworkConfiguration_Subnet, NetworkInterfaceCount_Max, NetworkInterfaceCount_Min, StorageConfiguration_StorageSizeGiB, TotalLocalStorageGB_Max, TotalLocalStorageGB_Min, VCpuCount_Max and VCpuCount_Min.
    * Modified cmdlet Remove-ECSCapacityProvider: added parameter Cluster.
    * Modified cmdlet Update-ECSCapacityProvider: added parameters AcceleratorCount_Max, AcceleratorCount_Min, AcceleratorTotalMemoryMiB_Max, AcceleratorTotalMemoryMiB_Min, BaselineEbsBandwidthMbps_Max, BaselineEbsBandwidthMbps_Min, Cluster, InstanceLaunchTemplate_Ec2InstanceProfileArn, InstanceLaunchTemplate_Monitoring, InstanceRequirements_AcceleratorManufacturer, InstanceRequirements_AcceleratorName, InstanceRequirements_AcceleratorType, InstanceRequirements_AllowedInstanceType, InstanceRequirements_BareMetal, InstanceRequirements_BurstablePerformance, InstanceRequirements_CpuManufacturer, InstanceRequirements_ExcludedInstanceType, InstanceRequirements_InstanceGeneration, InstanceRequirements_LocalStorage, InstanceRequirements_LocalStorageType, InstanceRequirements_MaxSpotPriceAsPercentageOfOptimalOnDemandPrice, InstanceRequirements_OnDemandMaxPricePercentageOverLowestPrice, InstanceRequirements_RequireHibernateSupport, InstanceRequirements_SpotMaxPricePercentageOverLowestPrice, ManagedInstancesProvider_InfrastructureRoleArn, ManagedInstancesProvider_PropagateTag, MemoryGiBPerVCpu_Max, MemoryGiBPerVCpu_Min, MemoryMiB_Max, MemoryMiB_Min, NetworkBandwidthGbps_Max, NetworkBandwidthGbps_Min, NetworkConfiguration_SecurityGroup, NetworkConfiguration_Subnet, NetworkInterfaceCount_Max, NetworkInterfaceCount_Min, StorageConfiguration_StorageSizeGiB, TotalLocalStorageGB_Max, TotalLocalStorageGB_Min, VCpuCount_Max and VCpuCount_Min.
  * Amazon Elemental MediaTailor
    * Modified cmdlet New-EMTPrefetchSchedule: added parameters RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers, RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps, Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers and Retrieval_TrafficShapingTpsConfiguration_PeakTps.
  * Amazon FSx
    * Modified cmdlet New-FSXFileSystem: added parameter OntapConfiguration_EndpointIpv6AddressRange.
    * Modified cmdlet Update-FSXFileSystem: added parameter OntapConfiguration_EndpointIpv6AddressRange.
  * Amazon Transfer for SFTP
    * Modified cmdlet Update-TFRServer: added parameter IdentityProviderType.

### 5.0.65 (2025-09-29 20:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.101.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Image Builder
    * Modified cmdlet Import-EC2IBDiskImage: added parameter LoggingConfiguration_LogGroupName.
    * Modified cmdlet Import-EC2IBVmImage: added parameter LoggingConfiguration_LogGroupName.
    * Modified cmdlet New-EC2IBImage: added parameter LoggingConfiguration_LogGroupName.
    * Modified cmdlet New-EC2IBImagePipeline: added parameters AutoDisablePolicy_FailureCount, LoggingConfiguration_ImageLogGroupName and LoggingConfiguration_PipelineLogGroupName.
    * Modified cmdlet New-EC2IBImageRecipe: added parameter AmiTag.
    * Modified cmdlet Start-EC2IBImagePipelineExecution: added parameter Tag.
    * Modified cmdlet Update-EC2IBImagePipeline: added parameters AutoDisablePolicy_FailureCount, LoggingConfiguration_ImageLogGroupName and LoggingConfiguration_PipelineLogGroupName.
  * Amazon VPC Lattice
    * Modified cmdlet Get-VPCLServiceNetworkResourceAssociationList: added parameter IncludeChild.
    * Modified cmdlet New-VPCLResourceGateway: added parameter Ipv4AddressesPerEni.

### 5.0.64 (2025-09-26 20:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.100.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Billing
    * Added cmdlet Add-AWSBSourceView leveraging the AssociateSourceViews service API.
    * Added cmdlet Remove-AWSBSourceView leveraging the DisassociateSourceViews service API.
    * Modified cmdlet Get-AWSBBillingViewList: added parameter SourceAccountId.
    * Modified cmdlet New-AWSBBillingView: added parameters TimeRange_BeginDateInclusive and TimeRange_EndDateInclusive.
    * Modified cmdlet Remove-AWSBBillingView: added parameter ForceDelete.
    * Modified cmdlet Update-AWSBBillingView: added parameters TimeRange_BeginDateInclusive and TimeRange_EndDateInclusive.
  * Amazon Connect Service
    * Added cmdlet Get-CONNRoutingProfileManualAssignmentQueueList leveraging the ListRoutingProfileManualAssignmentQueues service API.
    * Added cmdlet Join-CONNContactWithUser leveraging the AssociateContactWithUser service API.
    * Modified cmdlet Disconnect-CONNRoutingProfileQueue: added parameter ManualAssignmentQueueReference.
    * Modified cmdlet Join-CONNRoutingProfileQueue: added parameter ManualAssignmentQueueConfig.
    * Modified cmdlet New-CONNRoutingProfile: added parameter ManualAssignmentQueueConfig.
    * Modified cmdlet Search-CONNContact: added parameters AdditionalTimeRange_Criterion, AdditionalTimeRange_MatchType, Name_MatchType, Name_SearchText and RoutingCriteria_Step.
  * Amazon Data Automation for Amazon Bedrock
    * Modified cmdlet New-BDADataAutomationProject: added parameters ChannelLabeling_State and SpeakerLabeling_State.
    * Modified cmdlet Update-BDADataAutomationProject: added parameters ChannelLabeling_State and SpeakerLabeling_State.
  * Amazon Redshift
    * Modified cmdlet New-RSRedshiftIdcApplication: added parameters SsoTagKey and Tag.

### 5.0.63 (2025-09-25 19:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.99.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.62 (2025-09-24 20:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.98.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DynamoDB Accelerator (DAX)
    * Modified cmdlet New-DAXCluster: added parameter NetworkType.

### 5.0.61 (2025-09-23 20:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.97.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Modified cmdlet Invoke-CRSIdMappingTable: added parameter JobType.
  * Amazon EntityResolution
    * Modified cmdlet New-ERESIdMappingWorkflow: added parameter IncrementalRunConfig_IncrementalRunType.
    * Modified cmdlet Start-ERESIdMappingJob: added parameter JobType.
    * Modified cmdlet Update-ERESIdMappingWorkflow: added parameter IncrementalRunConfig_IncrementalRunType.
  * Amazon Single Sign-On Admin
    * Modified cmdlet Update-SSOADMNInstance: added parameters EncryptionConfiguration_KeyType and EncryptionConfiguration_KmsKeyArn.
  * Amazon Systems Manager
    * Modified cmdlet Get-SSMDeployablePatchSnapshotForInstance: added parameter UseS3DualStackEndpoint.

### 5.0.60 (2025-09-22 19:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.96.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSNodegroup: added parameters NodeRepairConfig_MaxParallelNodesRepairedCount, NodeRepairConfig_MaxParallelNodesRepairedPercentage, NodeRepairConfig_MaxUnhealthyNodeThresholdCount, NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage and NodeRepairConfig_NodeRepairConfigOverride.
    * Modified cmdlet Update-EKSNodegroupConfig: added parameters NodeRepairConfig_MaxParallelNodesRepairedCount, NodeRepairConfig_MaxParallelNodesRepairedPercentage, NodeRepairConfig_MaxUnhealthyNodeThresholdCount, NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage and NodeRepairConfig_NodeRepairConfigOverride.

### 5.0.59 (2025-09-19 20:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.95.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Added cmdlet Add-BACCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-BACCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-BACCResourceTag leveraging the UntagResource service API.
    * [Breaking Change] Modified cmdlet Get-BACCAgentRuntimeEndpointList: output changed from Amazon.BedrockAgentCoreControl.Model.AgentEndpoint to Amazon.BedrockAgentCoreControl.Model.AgentRuntimeEndpoint.
    * [Breaking Change] Modified cmdlet Get-BACCAgentRuntimeList: output changed from Amazon.BedrockAgentCoreControl.Model.Agent to Amazon.BedrockAgentCoreControl.Model.AgentRuntime.
    * [Breaking Change] Modified cmdlet Get-BACCAgentRuntimeVersionList: output changed from Amazon.BedrockAgentCoreControl.Model.Agent to Amazon.BedrockAgentCoreControl.Model.AgentRuntime.
    * Modified cmdlet New-BACCAgentRuntime: added parameters NetworkModeConfig_SecurityGroup, NetworkModeConfig_Subnet, RequestHeaderConfiguration_RequestHeaderAllowlist and Tag.
    * Modified cmdlet New-BACCAgentRuntimeEndpoint: added parameter Tag.
    * Modified cmdlet New-BACCBrowser: added parameters Tag, VpcConfig_SecurityGroup and VpcConfig_Subnet.
    * Modified cmdlet New-BACCCodeInterpreter: added parameters Tag, VpcConfig_SecurityGroup and VpcConfig_Subnet.
    * [Breaking Change] Modified cmdlet Remove-BACCAgentRuntime: output changed from Amazon.BedrockAgentCoreControl.AgentStatus to Amazon.BedrockAgentCoreControl.AgentRuntimeStatus.
    * [Breaking Change] Modified cmdlet Remove-BACCAgentRuntimeEndpoint: output changed from Amazon.BedrockAgentCoreControl.AgentEndpointStatus to Amazon.BedrockAgentCoreControl.AgentRuntimeEndpointStatus.
    * Modified cmdlet Update-BACCAgentRuntime: added parameters NetworkModeConfig_SecurityGroup, NetworkModeConfig_Subnet and RequestHeaderConfiguration_RequestHeaderAllowlist.
  * Amazon License Manager User Subscription
    * Modified cmdlet Add-LMUSUser: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Get-LMUSProductSubscriptionList: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Get-LMUSUserAssociationList: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Register-LMUSIdentityProvider: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Remove-LMUSUser: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Start-LMUSProductSubscription: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Stop-LMUSProductSubscription: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Unregister-LMUSIdentityProvider: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.
    * Modified cmdlet Update-LMUSIdentityProviderSetting: added parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.

### 5.0.58 (2025-09-18 20:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.94.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * [Breaking Change] Modified cmdlet Update-BDRAutomatedReasoningPolicyTestCase: removed parameter KmsKeyArn.
  * Amazon Chime SDK Messaging
    * Modified cmdlet Get-CHMMGMessagingSessionEndpoint: added parameter NetworkType.

### 5.0.57 (2025-09-17 20:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.93.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Network Firewall
    * Modified cmdlet New-NWFWFirewallPolicy: added parameter FirewallPolicy_EnableTLSSessionHolding.
    * Modified cmdlet Update-NWFWFirewallPolicy: added parameter FirewallPolicy_EnableTLSSessionHolding.

### 5.0.56 (2025-09-16 20:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.92.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Modified cmdlet Write-CWLMetricFilter: added parameters EmitSystemFieldDimension and FieldSelectionCriterion.
    * Modified cmdlet Write-CWLSubscriptionFilter: added parameters EmitSystemField and FieldSelectionCriterion.
  * Amazon Interactive Video Service RealTime
    * Modified cmdlet Start-IVSRTComposition: added parameters Grid_ParticipantOrderAttribute and Pip_ParticipantOrderAttribute.
  * Amazon OpenSearch Ingestion
    * Added cmdlet Get-OSISPipelineEndpointConnectionList leveraging the ListPipelineEndpointConnections service API.
    * Added cmdlet Get-OSISPipelineEndpointList leveraging the ListPipelineEndpoints service API.
    * Added cmdlet Get-OSISResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet New-OSISPipelineEndpoint leveraging the CreatePipelineEndpoint service API.
    * Added cmdlet Remove-OSISPipelineEndpoint leveraging the DeletePipelineEndpoint service API.
    * Added cmdlet Remove-OSISResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Revoke-OSISPipelineEndpointConnection leveraging the RevokePipelineEndpointConnections service API.
    * Added cmdlet Write-OSISResourcePolicy leveraging the PutResourcePolicy service API.

### 5.0.55 (2025-09-15 20:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.91.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Server Migration Service
  * Amazon CloudWatch Observability Admin Service
    * Added cmdlet Get-CWOADMNCentralizationRuleForOrganization leveraging the GetCentralizationRuleForOrganization service API.
    * Added cmdlet Get-CWOADMNCentralizationRulesForOrganizationList leveraging the ListCentralizationRulesForOrganization service API.
    * Added cmdlet New-CWOADMNCentralizationRuleForOrganization leveraging the CreateCentralizationRuleForOrganization service API.
    * Added cmdlet Remove-CWOADMNCentralizationRuleForOrganization leveraging the DeleteCentralizationRuleForOrganization service API.
    * Added cmdlet Update-CWOADMNCentralizationRuleForOrganization leveraging the UpdateCentralizationRuleForOrganization service API.
  * Amazon Medical Imaging Service
    * Modified cmdlet New-MISDatastore: added parameter LambdaAuthorizerArn.
  * Amazon S3 Control
    * Modified cmdlet New-S3CJob: added parameter Filter_MatchAnyObjectEncryption.

### 5.0.54 (2025-09-12 19:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.90.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Payment Cryptography Control Plane
    * Added cmdlet Get-PAYCCCertificateSigningRequest leveraging the GetCertificateSigningRequest service API.
    * Modified cmdlet Export-PAYCCKey: added parameters Tr34KeyBlock_SigningKeyCertificate and Tr34KeyBlock_SigningKeyIdentifier.
    * Modified cmdlet Import-PAYCCKey: added parameters Tr34KeyBlock_WrappingKeyCertificate and Tr34KeyBlock_WrappingKeyIdentifier.

### 5.0.53 (2025-09-11 20:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.89.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic VMware Service
    * Added cmdlet Register-EVSEipToVlan leveraging the AssociateEipToVlan service API.
    * Added cmdlet Unregister-EVSEipFromVlan leveraging the DisassociateEipFromVlan service API.
    * Modified cmdlet New-EVSEnvironment: added parameters InitialVlans_HcxNetworkAclId and InitialVlans_IsHcxPublic.
  * Amazon EMR Containers
    * Modified cmdlet New-EMRCSecurityConfiguration: added parameters ContainerProvider_Id, ContainerProvider_Type, EksInfo_Namespace and EksInfo_NodeLabel.
    * Modified cmdlet New-EMRCVirtualCluster: added parameter EksInfo_NodeLabel.
  * Amazon Prometheus Service
    * Added cmdlet Get-PROMScraperLoggingConfiguration leveraging the DescribeScraperLoggingConfiguration service API.
    * Added cmdlet Remove-PROMScraperLoggingConfiguration leveraging the DeleteScraperLoggingConfiguration service API.
    * Added cmdlet Update-PROMScraperLoggingConfiguration leveraging the UpdateScraperLoggingConfiguration service API.
  * Amazon QuickSight
    * Added cmdlet Get-QSAccountCustomPermission leveraging the DescribeAccountCustomPermission service API.
    * Added cmdlet Remove-QSAccountCustomPermission leveraging the DeleteAccountCustomPermission service API.
    * Added cmdlet Update-QSAccountCustomPermission leveraging the UpdateAccountCustomPermission service API.
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_Analysis and Capabilities_Dashboard.
    * Modified cmdlet New-QSDashboard: added parameters DataStoriesSharingOption_AvailabilityStatus and ExecutiveSummaryOption_AvailabilityStatus.
    * Modified cmdlet New-QSDataSource: added parameter CustomConnectionParameters_ConnectionType.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_Analysis and Capabilities_Dashboard.
    * Modified cmdlet Update-QSDashboard: added parameters DataStoriesSharingOption_AvailabilityStatus and ExecutiveSummaryOption_AvailabilityStatus.
    * Modified cmdlet Update-QSDataSource: added parameter CustomConnectionParameters_ConnectionType.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBProxy: added parameter DefaultAuthScheme.
    * Modified cmdlet New-RDSDBProxy: added parameter DefaultAuthScheme.

### 5.0.52 (2025-09-10 19:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.88.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Payment Cryptography Control Plane
    * Added cmdlet Add-PAYCCKeyReplicationRegion leveraging the AddKeyReplicationRegions service API.
    * Added cmdlet Disable-PAYCCDefaultKeyReplicationRegion leveraging the DisableDefaultKeyReplicationRegions service API.
    * Added cmdlet Enable-PAYCCDefaultKeyReplicationRegion leveraging the EnableDefaultKeyReplicationRegions service API.
    * Added cmdlet Get-PAYCCDefaultKeyReplicationRegion leveraging the GetDefaultKeyReplicationRegions service API.
    * Added cmdlet Remove-PAYCCKeyReplicationRegion leveraging the RemoveKeyReplicationRegions service API.
    * Modified cmdlet Import-PAYCCKey: added parameter ReplicationRegion.
    * Modified cmdlet New-PAYCCKey: added parameter ReplicationRegion.

### 5.0.51 (2025-09-09 19:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.87.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet Stop-ASInstanceRefresh: added parameter WaitForTransitioningInstance.
  * Amazon CloudWatch
    * Added cmdlet Get-CWAlarmContributor leveraging the DescribeAlarmContributors service API.
    * Modified cmdlet Get-CWAlarmHistory: added parameter AlarmContributorId.
  * Amazon Connect Service
    * Modified cmdlet New-CONNPredefinedAttribute: added parameters AttributeConfiguration_EnableValueValidationOnAssociation and Purpose.
    * Modified cmdlet Update-CONNPredefinedAttribute: added parameters AttributeConfiguration_EnableValueValidationOnAssociation and Purpose.
  * Amazon DataZone
    * Added cmdlet New-DZEnvironmentBlueprint leveraging the CreateEnvironmentBlueprint service API.
    * Added cmdlet Remove-DZEnvironmentBlueprint leveraging the DeleteEnvironmentBlueprint service API.
    * Added cmdlet Update-DZEnvironmentBlueprint leveraging the UpdateEnvironmentBlueprint service API.
    * Modified cmdlet Write-DZEnvironmentBlueprintConfiguration: added parameter GlobalParameter.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter DomainSettings_IpAddressType.
    * Modified cmdlet Update-SMDomain: added parameter DomainSettingsForUpdate_IpAddressType.

### 5.0.50 (2025-09-08 20:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.86.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT SiteWise
    * Modified cmdlet Get-IOTSWComputationModel: added parameter ComputationModelVersion.

### 5.0.49 (2025-09-05 20:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.85.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCluster: added parameters TieredStorageConfig_InstanceMemoryAllocationPercentage and TieredStorageConfig_Mode.
    * Modified cmdlet New-SMNotebookInstance: added parameter IpAddressType.
    * Modified cmdlet Update-SMCluster: added parameters TieredStorageConfig_InstanceMemoryAllocationPercentage and TieredStorageConfig_Mode.
    * Modified cmdlet Update-SMNotebookInstance: added parameter IpAddressType.

### 5.0.48 (2025-09-04 19:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.84.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * [Breaking Change] Modified cmdlet Get-CRSCollaborationChangeRequest: parameter ChangeRequestIdentifier doesn't support pipeline ByValue anymore; parameter ChangeRequestIdentifier cannot be used positionally anymore.
    * Modified cmdlet Start-CRSProtectedJob: added parameters Worker_Number and Worker_Type.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNHookResult: added parameters Status and TypeArn.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBProxy: added parameters EndpointNetworkType and TargetConnectionNetworkType.
    * Modified cmdlet New-RDSDBProxyEndpoint: added parameter EndpointNetworkType.

### 5.0.47 (2025-09-03 22:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.83.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Added cmdlet Get-CRSCollaborationChangeRequest leveraging the GetCollaborationChangeRequest service API.
    * Added cmdlet Get-CRSCollaborationChangeRequestList leveraging the ListCollaborationChangeRequests service API.
    * Added cmdlet New-CRSCollaborationChangeRequest leveraging the CreateCollaborationChangeRequest service API.
    * Modified cmdlet New-CRSCollaboration: added parameter AutoApprovedChangeRequestType.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter MasterUserAuthenticationType.
    * Modified cmdlet Edit-RDSDBInstance: added parameter MasterUserAuthenticationType.
    * Modified cmdlet New-RDSDBCluster: added parameter MasterUserAuthenticationType.
    * Modified cmdlet New-RDSDBInstance: added parameter MasterUserAuthenticationType.

### 5.0.46 (2025-09-02 20:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.82.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon User Notifications
    * Added cmdlet Add-UNOOrganizationalUnit leveraging the AssociateOrganizationalUnit service API.
    * Added cmdlet Get-UNOMemberAccountList leveraging the ListMemberAccounts service API.
    * Added cmdlet Get-UNOOrganizationalUnitList leveraging the ListOrganizationalUnits service API.
    * Added cmdlet Remove-UNOOrganizationalUnit leveraging the DisassociateOrganizationalUnit service API.
    * Modified cmdlet Get-UNONotificationConfigurationList: added parameter Subtype.
    * Modified cmdlet Get-UNONotificationEventList: added parameter OrganizationalUnitId.

### 5.0.45 (2025-08-29 22:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.81.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.44 (2025-08-29 20:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.81.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon X-Ray
    * Modified cmdlet Get-XRSamplingTarget: added parameter SamplingBoostStatisticsDocument.
    * Modified cmdlet New-XRSamplingRule: added parameters SamplingRateBoost_CooldownWindowMinute and SamplingRateBoost_MaxRate.
    * Modified cmdlet Update-XRSamplingRule: added parameters SamplingRateBoost_CooldownWindowMinute and SamplingRateBoost_MaxRate.

### 5.0.43 (2025-08-28 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.80.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Modified cmdlet Get-CONNCurrentMetricData: added parameter Filters_AgentStatus.
    * Modified cmdlet Get-CONNMetricData: added parameter Filters_AgentStatus.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Copy-EC2Image: added parameters DestinationAvailabilityZone and DestinationAvailabilityZoneId.
    * Modified cmdlet Copy-EC2Snapshot: added parameter DestinationAvailabilityZone.
  * Amazon HealthLake
    * Modified cmdlet Start-AHLFHIRImportJob: added parameter ValidationLevel.
  * Amazon Omics
    * Modified cmdlet New-OMICSWorkflow: added parameters ContainerRegistryMap_ImageMapping, ContainerRegistryMap_RegistryMapping and ContainerRegistryMapUri.
    * Modified cmdlet New-OMICSWorkflowVersion: added parameters ContainerRegistryMap_ImageMapping, ContainerRegistryMap_RegistryMapping and ContainerRegistryMapUri.
  * Amazon Systems Manager for SAP
    * Added cmdlet Get-SMSAPConfigurationCheckDefinitionList leveraging the ListConfigurationCheckDefinitions service API.
    * Added cmdlet Get-SMSAPConfigurationCheckOperation leveraging the GetConfigurationCheckOperation service API.
    * Added cmdlet Get-SMSAPConfigurationCheckOperationList leveraging the ListConfigurationCheckOperations service API.
    * Added cmdlet Get-SMSAPSubCheckResultList leveraging the ListSubCheckResults service API.
    * Added cmdlet Get-SMSAPSubCheckRuleResultList leveraging the ListSubCheckRuleResults service API.
    * Added cmdlet Start-SMSAPConfigurationCheck leveraging the StartConfigurationChecks service API.

### 5.0.42 (2025-08-27 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.79.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon OpsWorks
  * [Breaking Change] Removed support for Amazon OpsWorksCM
  * Amazon Directory Service
    * Added cmdlet Disable-DSCAEnrollmentPolicy leveraging the DisableCAEnrollmentPolicy service API.
    * Added cmdlet Enable-DSCAEnrollmentPolicy leveraging the EnableCAEnrollmentPolicy service API.
    * Added cmdlet Get-DSCAEnrollmentPolicy leveraging the DescribeCAEnrollmentPolicy service API.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSInsightsRefresh leveraging the DescribeInsightsRefresh service API.
    * Added cmdlet Start-EKSInsightsRefresh leveraging the StartInsightsRefresh service API.
  * Amazon Neptune Graph
    * Added cmdlet Start-NEPTGGraph leveraging the StartGraph service API.
    * Added cmdlet Stop-NEPTGGraph leveraging the StopGraph service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCluster: added parameters AutoScaling_AutoScalerType, AutoScaling_Mode and ClusterRole.
    * Modified cmdlet Update-SMCluster: added parameters AutoScaling_AutoScalerType, AutoScaling_Mode and ClusterRole.

### 5.0.41 (2025-08-26 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.78.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ARC - Zonal Shift
    * Modified cmdlet New-AZSPracticeRunConfiguration: added parameter AllowedWindow.
    * Modified cmdlet Update-AZSPracticeRunConfiguration: added parameter AllowedWindow.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2ImageReference leveraging the DescribeImageReferences service API.
    * Added cmdlet Get-EC2ImageUsageReport leveraging the DescribeImageUsageReports service API.
    * Added cmdlet Get-EC2ImageUsageReportEntry leveraging the DescribeImageUsageReportEntries service API.
    * Added cmdlet New-EC2ImageUsageReport leveraging the CreateImageUsageReport service API.
    * Added cmdlet Remove-EC2ImageUsageReport leveraging the DeleteImageUsageReport service API.

### 5.0.40 (2025-08-25 23:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.77.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon B2B Data Interchange
    * Modified cmdlet New-B2BITransformer: added parameters InputConversion_AdvancedOptions_X12_ValidationOptions_ValidationRules, OutputConversion_AdvancedOptions_X12_SplitOptions_SplitBy and OutputConversion_AdvancedOptions_X12_ValidationOptions_ValidationRules.
    * Modified cmdlet Test-B2BIConversion: added parameters SplitOptions_SplitBy and ValidationOptions_ValidationRule.
    * Modified cmdlet Test-B2BIParsing: added parameter ValidationOptions_ValidationRule.
    * Modified cmdlet Update-B2BITransformer: added parameters InputConversion_AdvancedOptions_X12_ValidationOptions_ValidationRules, OutputConversion_AdvancedOptions_X12_SplitOptions_SplitBy and OutputConversion_AdvancedOptions_X12_ValidationOptions_ValidationRules.
  * Amazon DataZone
    * Added cmdlet Add-DZGovernedTerm leveraging the AssociateGovernedTerms service API.
    * Added cmdlet Remove-DZGovernedTerm leveraging the DisassociateGovernedTerms service API.
    * Modified cmdlet New-DZGlossary: added parameter UsageRestriction.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameters EndpointIpAddressType and TrafficIpAddressType.
  * Amazon Elemental MediaConvert
    * Added cmdlet New-EMCResourceShare leveraging the CreateResourceShare service API.

### 5.0.39 (2025-08-22 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.76.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet Get-CWSYNCanariesLastRun: added parameter BrowserType.
    * Modified cmdlet New-CWSYNCanary: added parameter BrowserConfig.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameters BrowserConfig, VisualReference and VisualReference_BrowserType.
    * Modified cmdlet Update-CWSYNCanary: added parameters BrowserConfig, VisualReference and VisualReference_BrowserType.
  * Amazon Q Connect
    * Modified cmdlet Update-QCAIPrompt: added parameter ModelId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter DockerSettings_RootlessDocker.
    * Modified cmdlet Update-SMDomain: added parameter DockerSettings_RootlessDocker.
  * Amazon WAF V2
    * Modified cmdlet Update-WAF2WebACL: added parameter ApplicationConfig_Attribute.

### 5.0.38 (2025-08-21 21:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.75.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GameLiftStreams
    * Modified cmdlet Update-GMLSStreamGroup: added parameter DefaultApplicationIdentifier.
  * Amazon Glue
    * Modified cmdlet Get-GLUEDataQualityResultList: added parameters DataQualityGlueTable_AdditionalOption, DataQualityGlueTable_CatalogId, DataQualityGlueTable_ConnectionName, DataQualityGlueTable_DatabaseName, DataQualityGlueTable_PreProcessingQuery and DataQualityGlueTable_TableName.
    * Modified cmdlet Get-GLUEDataQualityRuleRecommendationRunList: added parameters DataQualityGlueTable_AdditionalOption, DataQualityGlueTable_CatalogId, DataQualityGlueTable_ConnectionName, DataQualityGlueTable_DatabaseName, DataQualityGlueTable_PreProcessingQuery and DataQualityGlueTable_TableName.
    * Modified cmdlet Get-GLUEDataQualityRulesetEvaluationRunList: added parameters DataQualityGlueTable_AdditionalOption, DataQualityGlueTable_CatalogId, DataQualityGlueTable_ConnectionName, DataQualityGlueTable_DatabaseName, DataQualityGlueTable_PreProcessingQuery and DataQualityGlueTable_TableName.
    * Modified cmdlet Start-GLUEDataQualityRuleRecommendationRun: added parameters DataQualityGlueTable_AdditionalOption, DataQualityGlueTable_CatalogId, DataQualityGlueTable_ConnectionName, DataQualityGlueTable_DatabaseName, DataQualityGlueTable_PreProcessingQuery and DataQualityGlueTable_TableName.
    * Modified cmdlet Start-GLUEDataQualityRulesetEvaluationRun: added parameters DataQualityGlueTable_AdditionalOption, DataQualityGlueTable_CatalogId, DataQualityGlueTable_ConnectionName, DataQualityGlueTable_DatabaseName, DataQualityGlueTable_PreProcessingQuery and DataQualityGlueTable_TableName.

### 5.0.37 (2025-08-20 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.74.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Runtime
    * Added cmdlet Get-BDRRCountToken leveraging the CountTokens service API.
  * Amazon Cognito Identity Provider
    * Added cmdlet Get-CGIPTerm leveraging the DescribeTerms service API.
    * Added cmdlet Get-CGIPTermList leveraging the ListTerms service API.
    * Added cmdlet New-CGIPTerm leveraging the CreateTerms service API.
    * Added cmdlet Remove-CGIPTerm leveraging the DeleteTerms service API.
    * Added cmdlet Update-CGIPTerm leveraging the UpdateTerms service API.
  * Amazon DataZone
    * Modified cmdlet Remove-DZPolicyGrant: added parameter GrantIdentifier.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSAddon: added parameter NamespaceConfig_Namespace.
  * Amazon Pinpoint SMS Voice V2
    * Modified cmdlet New-SMSVPhoneNumber: added parameter InternationalSendingEnabled.
    * Modified cmdlet Update-SMSVPhoneNumber: added parameter InternationalSendingEnabled.

### 5.0.36 (2025-08-19 19:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.73.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSAnalysisTemplate: added parameter ErrorMessageConfiguration_Type.

### 5.0.35 (2025-08-18 20:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.72.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Billing and Cost Management Dashboards. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BCMD and can be listed using the command 'Get-AWSCmdletName -Service BCMD'.
  * Amazon Connect Service
    * Modified cmdlet New-CONNParticipant: added parameters ParticipantCapabilities_ScreenShare and ParticipantCapabilities_Video.
  * Amazon S3 Control
    * Modified cmdlet New-S3CJob: added parameters Report_ExpectedBucketOwner, S3ComputeObjectChecksum_ChecksumAlgorithm and S3ComputeObjectChecksum_ChecksumType.

### 5.0.34 (2025-08-15 20:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.71.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet Edit-GLUEIntegration: added parameters IntegrationConfig_ContinuousSync, IntegrationConfig_RefreshInterval and IntegrationConfig_SourceProperty.
    * Modified cmdlet New-GLUEIntegration: added parameter IntegrationConfig_ContinuousSync.
  * Amazon Prometheus Service
    * Added cmdlet Get-PROMResourcePolicy leveraging the DescribeResourcePolicy service API.
    * Added cmdlet Remove-PROMResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-PROMResourcePolicy leveraging the PutResourcePolicy service API.

### 5.0.33 (2025-08-14 20:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.70.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Billing And Cost Management Recommended Actions. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BCMRA and can be listed using the command 'Get-AWSCmdletName -Service BCMRA'.
  * Amazon Cloud Map
    * Modified cmdlet Find-SDInstance: added parameter OwnerAccount.
    * Modified cmdlet Get-SDInstancesRevision: added parameter OwnerAccount.
    * Modified cmdlet Get-SDOperation: added parameter OwnerAccount.
  * Amazon Direct Connect
    * Modified cmdlet Enable-DCPrivateVirtualInterface: added parameter NewPrivateVirtualInterfaceAllocation_AsnLong.
    * Modified cmdlet Enable-DCPublicVirtualInterface: added parameter NewPublicVirtualInterfaceAllocation_AsnLong.
    * Modified cmdlet Enable-DCTransitVirtualInterface: added parameter NewTransitVirtualInterfaceAllocation_AsnLong.
    * Modified cmdlet Get-DCConnection: added parameters MaxResult, NextToken and NoAutoIteration.
    * Modified cmdlet Get-DCHostedConnection: added parameters MaxResult, NextToken and NoAutoIteration.
    * Modified cmdlet Get-DCInterconnect: added parameters MaxResult, NextToken and NoAutoIteration.
    * Modified cmdlet Get-DCLag: added parameters MaxResult, NextToken and NoAutoIteration.
    * Modified cmdlet Get-DCVirtualInterface: added parameters MaxResult, NextToken and NoAutoIteration.
    * Modified cmdlet New-DCBGPPeer: added parameter NewBGPPeer_AsnLong.
    * Modified cmdlet New-DCPrivateVirtualInterface: added parameter NewPrivateVirtualInterface_AsnLong.
    * Modified cmdlet New-DCPublicVirtualInterface: added parameter NewPublicVirtualInterface_AsnLong.
    * Modified cmdlet New-DCTransitVirtualInterface: added parameter NewTransitVirtualInterface_AsnLong.
    * Modified cmdlet Remove-DCBGPPeer: added parameter AsnLong.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBContributorInsight: added parameter ContributorInsightsMode.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2InstanceConnectEndpoint leveraging the ModifyInstanceConnectEndpoint service API.
  * Amazon Glue
    * Added cmdlet Get-GLUEGlueIdentityCenterConfiguration leveraging the GetGlueIdentityCenterConfiguration service API.
    * Added cmdlet New-GLUEGlueIdentityCenterConfiguration leveraging the CreateGlueIdentityCenterConfiguration service API.
    * Added cmdlet Remove-GLUEGlueIdentityCenterConfiguration leveraging the DeleteGlueIdentityCenterConfiguration service API.
    * Added cmdlet Update-GLUEGlueIdentityCenterConfiguration leveraging the UpdateGlueIdentityCenterConfiguration service API.
  * Amazon GuardDuty
    * Added cmdlet Get-GDThreatEntitySet leveraging the GetThreatEntitySet service API.
    * Added cmdlet Get-GDThreatEntitySetList leveraging the ListThreatEntitySets service API.
    * Added cmdlet Get-GDTrustedEntitySet leveraging the GetTrustedEntitySet service API.
    * Added cmdlet Get-GDTrustedEntitySetList leveraging the ListTrustedEntitySets service API.
    * Added cmdlet New-GDThreatEntitySet leveraging the CreateThreatEntitySet service API.
    * Added cmdlet New-GDTrustedEntitySet leveraging the CreateTrustedEntitySet service API.
    * Added cmdlet Remove-GDThreatEntitySet leveraging the DeleteThreatEntitySet service API.
    * Added cmdlet Remove-GDTrustedEntitySet leveraging the DeleteTrustedEntitySet service API.
    * Added cmdlet Update-GDThreatEntitySet leveraging the UpdateThreatEntitySet service API.
    * Added cmdlet Update-GDTrustedEntitySet leveraging the UpdateTrustedEntitySet service API.
  * Amazon WorkSpaces
    * Added cmdlet Get-WKSCustomWorkspaceImageImport leveraging the DescribeCustomWorkspaceImageImport service API.
    * Added cmdlet Import-WKSCustomWorkspaceImage leveraging the ImportCustomWorkspaceImage service API.

### 5.0.32 (2025-08-13 20:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.69.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Added cmdlet Get-DZAccountPool leveraging the GetAccountPool service API.
    * Added cmdlet Get-DZAccountPoolList leveraging the ListAccountPools service API.
    * Added cmdlet Get-DZAccountsInAccountPoolList leveraging the ListAccountsInAccountPool service API.
    * Added cmdlet New-DZAccountPool leveraging the CreateAccountPool service API.
    * Added cmdlet Remove-DZAccountPool leveraging the DeleteAccountPool service API.
    * Added cmdlet Update-DZAccountPool leveraging the UpdateAccountPool service API.
  * Amazon FSx
    * Modified cmdlet New-FSXFileSystem: added parameters NetworkType and OpenZFSConfiguration_EndpointIpv6AddressRange.
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameters NetworkType and OpenZFSConfiguration_EndpointIpv6AddressRange.
    * Modified cmdlet Update-FSXFileSystem: added parameters NetworkType and OpenZFSConfiguration_EndpointIpv6AddressRange.
  * Amazon Partner Central Selling API
    * Modified cmdlet Invoke-PCCreateOpportunity: added parameter Tag.
  * Amazon Security Incident Response
    * Modified cmdlet New-SecurityIRMembership: added parameter CoverEntireOrganization.
    * Modified cmdlet Update-SecurityIRMembership: added parameters MembershipAccountsConfigurationsUpdate_CoverEntireOrganization, MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToAdd, MembershipAccountsConfigurationsUpdate_OrganizationalUnitsToRemove and UndoMembershipCancellation.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3Object: added parameters DisableDefaultChecksumValidation, DisablePayloadSigning, IfMatch, ObjectLockLegalHoldStatus, ObjectLockMode and ObjectLockRetainUntilDate.
    * Modified cmdlet Get-S3ObjectMetadata: added parameter Range.
    * Modified cmdlet Write-S3CORSConfiguration: added parameter ContentMD5.

### 5.0.31 (2025-08-12 21:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.68.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Register-EC2RouteTable: added parameter PublicIpv4Pool.
  * Amazon Organizations
    * Added cmdlet Get-ORGAccountsWithInvalidEffectivePolicyList leveraging the ListAccountsWithInvalidEffectivePolicy service API.
    * Added cmdlet Get-ORGEffectivePolicyValidationErrorList leveraging the ListEffectivePolicyValidationErrors service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter TrustedIdentityPropagationSettings_Status.
    * Modified cmdlet Update-SMDomain: added parameter TrustedIdentityPropagationSettings_Status.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSMedicalScribeJob: added parameter PatientContext_Pronoun.

### 5.0.30 (2025-08-11 20:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.67.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * [Breaking Change] Modified cmdlet Search-CONNAgentStatus: removed parameters HierarchyGroupCondition_HierarchyGroupMatchType and HierarchyGroupCondition_Value.
    * [Breaking Change] Modified cmdlet Search-CONNUserHierarchyGroup: removed parameters HierarchyGroupCondition_HierarchyGroupMatchType, HierarchyGroupCondition_Value, SearchFilter_HierarchyGroupCondition_HierarchyGroupMatchType and SearchFilter_HierarchyGroupCondition_Value.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2Instance: added parameter Placement_AvailabilityZoneId.
    * Modified cmdlet Get-EC2SpotPriceHistory: added parameter AvailabilityZoneId.
    * Modified cmdlet New-EC2DefaultSubnet: added parameter AvailabilityZoneId.
    * Modified cmdlet New-EC2Volume: added parameter AvailabilityZoneId.
  * Amazon Single Sign-On Admin
    * Added cmdlet Get-SSOADMNApplicationSessionConfiguration leveraging the GetApplicationSessionConfiguration service API.
    * Added cmdlet Write-SSOADMNApplicationSessionConfiguration leveraging the PutApplicationSessionConfiguration service API.

### 5.0.29 (2025-08-08 20:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.66.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Get-CONNContactMetric leveraging the GetContactMetrics service API.
    * Modified cmdlet Search-CONNAgentStatus: added parameters HierarchyGroupCondition_HierarchyGroupMatchType and HierarchyGroupCondition_Value.
    * Modified cmdlet Search-CONNUserHierarchyGroup: added parameters HierarchyGroupCondition_HierarchyGroupMatchType, HierarchyGroupCondition_Value, SearchFilter_HierarchyGroupCondition_HierarchyGroupMatchType and SearchFilter_HierarchyGroupCondition_Value.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMReservedCapacity leveraging the DescribeReservedCapacity service API.
    * Added cmdlet Get-SMUltraServersByReservedCapacityList leveraging the ListUltraServersByReservedCapacity service API.
    * Modified cmdlet New-SMTrainingPlan: added parameter SpareInstanceCountPerUltraServer.
    * Modified cmdlet Search-SMTrainingPlanOffering: added parameters UltraServerCount and UltraServerType.

### 5.0.28 (2025-08-07 20:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.65.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBWebhook: added parameters PullRequestBuildPolicy_ApproverRole and PullRequestBuildPolicy_RequiresCommentApproval.
    * Modified cmdlet Update-CBWebhook: added parameters PullRequestBuildPolicy_ApproverRole and PullRequestBuildPolicy_RequiresCommentApproval.
  * Amazon Glue
    * Modified cmdlet New-GLUECatalog: added parameters IcebergOptimizationProperties_Compaction, IcebergOptimizationProperties_OrphanFileDeletion, IcebergOptimizationProperties_Retention and IcebergOptimizationProperties_RoleArn.
    * Modified cmdlet New-GLUETableOptimizer: added parameters IcebergConfiguration_DeleteFileThreshold, IcebergConfiguration_MinInputFile, TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours and TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours.
    * Modified cmdlet Update-GLUECatalog: added parameters IcebergOptimizationProperties_Compaction, IcebergOptimizationProperties_OrphanFileDeletion, IcebergOptimizationProperties_Retention and IcebergOptimizationProperties_RoleArn.
    * Modified cmdlet Update-GLUETableOptimizer: added parameters IcebergConfiguration_DeleteFileThreshold, IcebergConfiguration_MinInputFile, TableOptimizerConfiguration_OrphanFileDeletionConfiguration_IcebergConfiguration_RunRateInHours and TableOptimizerConfiguration_RetentionConfiguration_IcebergConfiguration_RunRateInHours.

### 5.0.27 (2025-08-06 20:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.64.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Budgets
    * Modified cmdlet New-BGTBudget: added parameters Budget_BillingViewArn, HealthStatus_LastUpdatedTime, HealthStatus_Status and HealthStatus_StatusReason.
    * Modified cmdlet Update-BGTBudget: added parameters HealthStatus_LastUpdatedTime, HealthStatus_Status, HealthStatus_StatusReason and NewBudget_BillingViewArn.
  * Amazon OpenSearch Serverless
    * Added cmdlet Get-OSSIndex leveraging the GetIndex service API.
    * Added cmdlet New-OSSIndex leveraging the CreateIndex service API.
    * Added cmdlet Remove-OSSIndex leveraging the DeleteIndex service API.
    * Added cmdlet Update-OSSIndex leveraging the UpdateIndex service API.
  * Amazon QBusiness
    * Added cmdlet Get-QBUSDocumentContent leveraging the GetDocumentContent service API.

### 5.0.26 (2025-08-05 20:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.63.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Export-BDRAutomatedReasoningPolicyVersion leveraging the ExportAutomatedReasoningPolicyVersion service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicy leveraging the GetAutomatedReasoningPolicy service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyAnnotation leveraging the GetAutomatedReasoningPolicyAnnotations service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyBuildWorkflow leveraging the GetAutomatedReasoningPolicyBuildWorkflow service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyBuildWorkflowList leveraging the ListAutomatedReasoningPolicyBuildWorkflows service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyBuildWorkflowResultAsset leveraging the GetAutomatedReasoningPolicyBuildWorkflowResultAssets service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyList leveraging the ListAutomatedReasoningPolicies service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyNextScenario leveraging the GetAutomatedReasoningPolicyNextScenario service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyTestCase leveraging the GetAutomatedReasoningPolicyTestCase service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyTestCaseList leveraging the ListAutomatedReasoningPolicyTestCases service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyTestResult leveraging the GetAutomatedReasoningPolicyTestResult service API.
    * Added cmdlet Get-BDRAutomatedReasoningPolicyTestResultList leveraging the ListAutomatedReasoningPolicyTestResults service API.
    * Added cmdlet New-BDRAutomatedReasoningPolicy leveraging the CreateAutomatedReasoningPolicy service API.
    * Added cmdlet New-BDRAutomatedReasoningPolicyTestCase leveraging the CreateAutomatedReasoningPolicyTestCase service API.
    * Added cmdlet New-BDRAutomatedReasoningPolicyVersion leveraging the CreateAutomatedReasoningPolicyVersion service API.
    * Added cmdlet Remove-BDRAutomatedReasoningPolicy leveraging the DeleteAutomatedReasoningPolicy service API.
    * Added cmdlet Remove-BDRAutomatedReasoningPolicyBuildWorkflow leveraging the DeleteAutomatedReasoningPolicyBuildWorkflow service API.
    * Added cmdlet Remove-BDRAutomatedReasoningPolicyTestCase leveraging the DeleteAutomatedReasoningPolicyTestCase service API.
    * Added cmdlet Start-BDRAutomatedReasoningPolicyBuildWorkflow leveraging the StartAutomatedReasoningPolicyBuildWorkflow service API.
    * Added cmdlet Start-BDRAutomatedReasoningPolicyTestWorkflow leveraging the StartAutomatedReasoningPolicyTestWorkflow service API.
    * Added cmdlet Stop-BDRAutomatedReasoningPolicyBuildWorkflow leveraging the CancelAutomatedReasoningPolicyBuildWorkflow service API.
    * Added cmdlet Update-BDRAutomatedReasoningPolicy leveraging the UpdateAutomatedReasoningPolicy service API.
    * Added cmdlet Update-BDRAutomatedReasoningPolicyAnnotation leveraging the UpdateAutomatedReasoningPolicyAnnotations service API.
    * Added cmdlet Update-BDRAutomatedReasoningPolicyTestCase leveraging the UpdateAutomatedReasoningPolicyTestCase service API.
    * Modified cmdlet New-BDRGuardrail: added parameters AutomatedReasoningPolicyConfig_ConfidenceThreshold and AutomatedReasoningPolicyConfig_Policy.
    * Modified cmdlet Update-BDRGuardrail: added parameters AutomatedReasoningPolicyConfig_ConfidenceThreshold and AutomatedReasoningPolicyConfig_Policy.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter DeletionProtection.
    * Modified cmdlet Update-EKSClusterConfig: added parameter DeletionProtection.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMClusterEvent leveraging the DescribeClusterEvent service API.
    * Added cmdlet Get-SMClusterEventList leveraging the ListClusterEvents service API.
    * Added cmdlet Set-SMAddClusterNode leveraging the BatchAddClusterNodes service API.
    * Modified cmdlet Get-SMClusterNode: added parameter NodeLogicalId.
    * Modified cmdlet Get-SMClusterNodeList: added parameter IncludeNodeLogicalId.
    * Modified cmdlet New-SMCluster: added parameter NodeProvisioningMode.
    * Modified cmdlet Set-SMDeleteClusterNode: added parameter NodeLogicalId.
    * Modified cmdlet Update-SMClusterSoftware: added parameter ImageId.

### 5.0.25 (2025-08-04 23:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.62.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * [Breaking Change] Modified cmdlet Get-BACResourceOauth2Token: removed parameter UserId.
  * Amazon IoT SiteWise
    * Added cmdlet Get-IOTSWAssetModelInterfaceRelationship leveraging the DescribeAssetModelInterfaceRelationship service API.
    * Added cmdlet Get-IOTSWInterfaceRelationshipList leveraging the ListInterfaceRelationships service API.
    * Added cmdlet Remove-IOTSWAssetModelInterfaceRelationship leveraging the DeleteAssetModelInterfaceRelationship service API.
    * Added cmdlet Write-IOTSWAssetModelInterfaceRelationship leveraging the PutAssetModelInterfaceRelationship service API.
  * Amazon SageMaker Service
    * Added cmdlet Dismount-SMClusterNodeVolume leveraging the DetachClusterNodeVolume service API.
    * Added cmdlet Mount-SMClusterNodeVolume leveraging the AttachClusterNodeVolume service API.

### 5.0.24 (2025-08-01 19:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.61.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ARC - Region switch. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ARC and can be listed using the command 'Get-AWSCmdletName -Service ARC'.
  * Amazon CloudWatch Observability Admin Service
    * Added cmdlet Add-CWOADMNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWOADMNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-CWOADMNTelemetryRule leveraging the GetTelemetryRule service API.
    * Added cmdlet Get-CWOADMNTelemetryRuleForOrganization leveraging the GetTelemetryRuleForOrganization service API.
    * Added cmdlet Get-CWOADMNTelemetryRuleList leveraging the ListTelemetryRules service API.
    * Added cmdlet Get-CWOADMNTelemetryRulesForOrganizationList leveraging the ListTelemetryRulesForOrganization service API.
    * Added cmdlet New-CWOADMNTelemetryRule leveraging the CreateTelemetryRule service API.
    * Added cmdlet New-CWOADMNTelemetryRuleForOrganization leveraging the CreateTelemetryRuleForOrganization service API.
    * Added cmdlet Remove-CWOADMNResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-CWOADMNTelemetryRule leveraging the DeleteTelemetryRule service API.
    * Added cmdlet Remove-CWOADMNTelemetryRuleForOrganization leveraging the DeleteTelemetryRuleForOrganization service API.
    * Added cmdlet Update-CWOADMNTelemetryRule leveraging the UpdateTelemetryRule service API.
    * Added cmdlet Update-CWOADMNTelemetryRuleForOrganization leveraging the UpdateTelemetryRuleForOrganization service API.
  * Amazon Parallel Computing Service
    * Modified cmdlet New-PCSCluster: added parameter Networking_NetworkType.

### 5.0.23 (2025-07-31 20:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.60.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Modified cmdlet Merge-CPFProfile: added parameters FieldSourceProfileIds_EngagementPreference and FieldSourceProfileIds_ProfileType.
    * Modified cmdlet New-CPFProfile: added parameters EngagementPreferences_Email, EngagementPreferences_Phone and ProfileType.
    * Modified cmdlet Update-CPFProfile: added parameters EngagementPreferences_Email, EngagementPreferences_Phone and ProfileType.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Remove-EC2Instance: added parameter Enforce.
  * Amazon EntityResolution
    * Modified cmdlet New-ERESMatchingWorkflow: added parameter RuleConditionProperties_Rule.
    * Modified cmdlet Update-ERESMatchingWorkflow: added parameter RuleConditionProperties_Rule.
  * Amazon IoT
    * Added cmdlet Get-IOTEncryptionConfiguration leveraging the DescribeEncryptionConfiguration service API.
    * Added cmdlet Update-IOTEncryptionConfiguration leveraging the UpdateEncryptionConfiguration service API.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameters IAMFederationOptions_Enabled, IAMFederationOptions_RolesKey and IAMFederationOptions_SubjectKey.
    * Modified cmdlet Update-OSDomainConfig: added parameters IAMFederationOptions_Enabled, IAMFederationOptions_RolesKey and IAMFederationOptions_SubjectKey.
  * Amazon QuickSight
    * Modified cmdlet New-QSDataSource: added parameters ImpalaParameters_Database, ImpalaParameters_Host, ImpalaParameters_Port and ImpalaParameters_SqlEndpointPath.
    * Modified cmdlet Update-QSDataSource: added parameters ImpalaParameters_Database, ImpalaParameters_Host, ImpalaParameters_Port and ImpalaParameters_SqlEndpointPath.
  * Amazon S3 Control
    * Modified cmdlet New-S3CAccessPoint: added parameter Tag.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Get-SES2ReputationEntity leveraging the GetReputationEntity service API.
    * Added cmdlet Get-SES2ReputationEntityList leveraging the ListReputationEntities service API.
    * Added cmdlet Get-SES2ResourceTenantList leveraging the ListResourceTenants service API.
    * Added cmdlet Get-SES2Tenant leveraging the GetTenant service API.
    * Added cmdlet Get-SES2TenantList leveraging the ListTenants service API.
    * Added cmdlet Get-SES2TenantResourceList leveraging the ListTenantResources service API.
    * Added cmdlet New-SES2Tenant leveraging the CreateTenant service API.
    * Added cmdlet New-SES2TenantResourceAssociation leveraging the CreateTenantResourceAssociation service API.
    * Added cmdlet Remove-SES2Tenant leveraging the DeleteTenant service API.
    * Added cmdlet Remove-SES2TenantResourceAssociation leveraging the DeleteTenantResourceAssociation service API.
    * Added cmdlet Update-SES2ReputationEntityCustomerManagedStatus leveraging the UpdateReputationEntityCustomerManagedStatus service API.
    * Added cmdlet Update-SES2ReputationEntityPolicy leveraging the UpdateReputationEntityPolicy service API.
    * Modified cmdlet Send-SES2BulkEmail: added parameter TenantName.
    * Modified cmdlet Send-SES2Email: added parameter TenantName.
  * Amazon WorkSpaces Web
    * Added cmdlet Get-WSWSessionLogger leveraging the GetSessionLogger service API.
    * Added cmdlet Get-WSWSessionLoggerList leveraging the ListSessionLoggers service API.
    * Added cmdlet New-WSWSessionLogger leveraging the CreateSessionLogger service API.
    * Added cmdlet Register-WSWSessionLogger leveraging the AssociateSessionLogger service API.
    * Added cmdlet Remove-WSWSessionLogger leveraging the DeleteSessionLogger service API.
    * Added cmdlet Unregister-WSWSessionLogger leveraging the DisassociateSessionLogger service API.
    * Added cmdlet Update-WSWSessionLogger leveraging the UpdateSessionLogger service API.

### 5.0.22 (2025-07-30 20:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.59.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Directory Service
    * Added cmdlet Get-DSADAssessment leveraging the DescribeADAssessment service API.
    * Added cmdlet Get-DSADAssessmentList leveraging the ListADAssessments service API.
    * Added cmdlet Get-DSHybridADUpdate leveraging the DescribeHybridADUpdate service API.
    * Added cmdlet New-DSHybridAD leveraging the CreateHybridAD service API.
    * Added cmdlet Remove-DSADAssessment leveraging the DeleteADAssessment service API.
    * Added cmdlet Start-DSADAssessment leveraging the StartADAssessment service API.
    * Added cmdlet Update-DSHybridAD leveraging the UpdateHybridAD service API.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet Edit-DOCDBCluster: added parameters ServerlessV2ScalingConfiguration_MaxCapacity and ServerlessV2ScalingConfiguration_MinCapacity.
    * Modified cmdlet New-DOCDBCluster: added parameters ServerlessV2ScalingConfiguration_MaxCapacity and ServerlessV2ScalingConfiguration_MinCapacity.
    * Modified cmdlet Restore-DOCDBClusterFromSnapshot: added parameters ServerlessV2ScalingConfiguration_MaxCapacity and ServerlessV2ScalingConfiguration_MinCapacity.
    * Modified cmdlet Restore-DOCDBClusterToPointInTime: added parameters ServerlessV2ScalingConfiguration_MaxCapacity and ServerlessV2ScalingConfiguration_MinCapacity.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWServiceProfile: added parameters LoRaWAN_NbTransMax, LoRaWAN_NbTransMin, LoRaWAN_TxPowerIndexMax and LoRaWAN_TxPowerIndexMin.

### 5.0.21 (2025-07-29 20:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.58.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCMonitor: added parameter Tag.
  * Amazon Batch
    * Added cmdlet Get-BATServiceEnvironment leveraging the DescribeServiceEnvironments service API.
    * Added cmdlet Get-BATServiceJob leveraging the DescribeServiceJob service API.
    * Added cmdlet Get-BATServiceJobList leveraging the ListServiceJobs service API.
    * Added cmdlet New-BATServiceEnvironment leveraging the CreateServiceEnvironment service API.
    * Added cmdlet Remove-BATServiceEnvironment leveraging the DeleteServiceEnvironment service API.
    * Added cmdlet Stop-BATServiceJob leveraging the TerminateServiceJob service API.
    * Added cmdlet Submit-BATServiceJob leveraging the SubmitServiceJob service API.
    * Added cmdlet Update-BATServiceEnvironment leveraging the UpdateServiceEnvironment service API.
    * Modified cmdlet New-BATJobQueue: added parameters JobQueueType and ServiceEnvironmentOrder.
    * Modified cmdlet Update-BATJobQueue: added parameter ServiceEnvironmentOrder.
  * Amazon Clean Rooms Service
    * Modified cmdlet Update-CRSConfiguredTable: added parameters AllowedColumn, Athena_DatabaseName, Athena_OutputLocation, Athena_TableName, Athena_WorkGroup, Glue_DatabaseName, Glue_TableName, Snowflake_AccountIdentifier, Snowflake_DatabaseName, Snowflake_SchemaName, Snowflake_SecretArn, Snowflake_TableName and TableSchema_V1.
  * Amazon Location Service
    * Modified cmdlet Set-LOCGeofence: added parameter Geometry_MultiPolygon.
  * Amazon OpenSearch Serverless
    * Modified cmdlet New-OSSSecurityConfig: added parameters IamFederationOptions_GroupAttribute and IamFederationOptions_UserAttribute.
    * Modified cmdlet Update-OSSSecurityConfig: added parameters IamFederationOptions_GroupAttribute and IamFederationOptions_UserAttribute.

### 5.0.20 (2025-07-28 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.57.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Direct Connect
    * Modified cmdlet New-DCInterconnect: added parameter RequestMACSec.
  * Amazon IoT SiteWise
    * Added cmdlet Get-IOTSWComputationModel leveraging the DescribeComputationModel service API.
    * Added cmdlet Get-IOTSWComputationModelDataBindingUsageList leveraging the ListComputationModelDataBindingUsages service API.
    * Added cmdlet Get-IOTSWComputationModelExecutionSummary leveraging the DescribeComputationModelExecutionSummary service API.
    * Added cmdlet Get-IOTSWComputationModelList leveraging the ListComputationModels service API.
    * Added cmdlet Get-IOTSWComputationModelResolveToResourceList leveraging the ListComputationModelResolveToResources service API.
    * Added cmdlet Get-IOTSWExecution leveraging the DescribeExecution service API.
    * Added cmdlet Get-IOTSWExecutionList leveraging the ListExecutions service API.
    * Added cmdlet New-IOTSWComputationModel leveraging the CreateComputationModel service API.
    * Added cmdlet Remove-IOTSWComputationModel leveraging the DeleteComputationModel service API.
    * Added cmdlet Update-IOTSWComputationModel leveraging the UpdateComputationModel service API.
    * Modified cmdlet Get-IOTSWActionList: added parameters ResolveToResourceId and ResolveToResourceType.
    * Modified cmdlet Start-IOTSWAction: added parameters ResolveTo_AssetId and TargetResource_ComputationModelId.
  * Amazon OpenSearch Ingestion
    * Modified cmdlet New-OSISPipeline: added parameter PipelineRoleArn.
    * Modified cmdlet Update-OSISPipeline: added parameter PipelineRoleArn.

### 5.0.19 (2025-07-25 19:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.56.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppIntegrations Service
    * Modified cmdlet New-AISApplication: added parameters ContactHandling_Scope, IframeConfig_Allow, IframeConfig_Sandbox, InitializationTimeout and IsService.
    * Modified cmdlet Update-AISApplication: added parameters ContactHandling_Scope, IframeConfig_Allow, IframeConfig_Sandbox, InitializationTimeout and IsService.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2Channel: added parameter InputSwitchConfiguration_PreferredInput.
    * Modified cmdlet Update-MPV2Channel: added parameter InputSwitchConfiguration_PreferredInput.
  * Amazon End User Messaging Social
    * Added cmdlet Get-SOCIALWhatsAppMessageTemplate leveraging the GetWhatsAppMessageTemplate service API.
    * Added cmdlet Get-SOCIALWhatsAppMessageTemplateList leveraging the ListWhatsAppMessageTemplates service API.
    * Added cmdlet Get-SOCIALWhatsAppTemplateLibraryList leveraging the ListWhatsAppTemplateLibrary service API.
    * Added cmdlet New-SOCIALWhatsAppMessageTemplate leveraging the CreateWhatsAppMessageTemplate service API.
    * Added cmdlet New-SOCIALWhatsAppMessageTemplateFromLibrary leveraging the CreateWhatsAppMessageTemplateFromLibrary service API.
    * Added cmdlet New-SOCIALWhatsAppMessageTemplateMedia leveraging the CreateWhatsAppMessageTemplateMedia service API.
    * Added cmdlet Remove-SOCIALWhatsAppMessageTemplate leveraging the DeleteWhatsAppMessageTemplate service API.
    * Added cmdlet Update-SOCIALWhatsAppMessageTemplate leveraging the UpdateWhatsAppMessageTemplate service API.
    * Modified cmdlet Connect-SOCIALWhatsAppBusinessAccount: added parameter SignupCallback_CallbackUrl.

### 5.0.18 (2025-07-24 19:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.55.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Search-DZListing: added parameter Aggregation.
  * Amazon Omics
    * Modified cmdlet New-OMICSWorkflow: added parameters DefinitionRepository_ConnectionArn, DefinitionRepository_ExcludeFilePattern, DefinitionRepository_FullRepositoryId, ParameterTemplatePath, ReadmeMarkdown, ReadmePath, ReadmeUri, SourceReference_Type, SourceReference_Value and WorkflowBucketOwnerId.
    * Modified cmdlet New-OMICSWorkflowVersion: added parameters DefinitionRepository_ConnectionArn, DefinitionRepository_ExcludeFilePattern, DefinitionRepository_FullRepositoryId, ParameterTemplatePath, ReadmeMarkdown, ReadmePath, ReadmeUri, SourceReference_Type and SourceReference_Value.
    * Modified cmdlet Update-OMICSWorkflow: added parameter ReadmeMarkdown.
    * Modified cmdlet Update-OMICSWorkflowVersion: added parameter ReadmeMarkdown.

### 5.0.17 (2025-07-23 20:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.54.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Stop-EC2Instance: added parameter SkipOsShutdown.
    * Modified cmdlet Remove-EC2Instance: added parameter SkipOsShutdown.
  * Amazon Glue
    * Modified cmdlet Start-GLUEJobRun: added parameter ExecutionRoleSessionPolicy.

### 5.0.16 (2025-07-22 19:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.53.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Registry
    * Modified cmdlet New-ECRRepository: added parameter ImageTagMutabilityExclusionFilter.
    * Modified cmdlet New-ECRRepositoryCreationTemplate: added parameter ImageTagMutabilityExclusionFilter.
    * Modified cmdlet Update-ECRRepositoryCreationTemplate: added parameter ImageTagMutabilityExclusionFilter.
    * Modified cmdlet Write-ECRImageTagMutability: added parameter ImageTagMutabilityExclusionFilter.
  * Amazon Elastic MapReduce
    * Modified cmdlet Edit-EMRCluster: added parameter ExtendedSupport.
    * Modified cmdlet Start-EMRJobFlow: added parameter ExtendedSupport.

### 5.0.15 (2025-07-21 20:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.52.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameter VpcConfiguration_ResourceConfigurationArn.
    * Modified cmdlet Update-ADCFleet: added parameter VpcConfiguration_ResourceConfigurationArn.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMWorkforce: added parameter IpAddressType.
    * Modified cmdlet Update-SMWorkforce: added parameter IpAddressType.

### 5.0.14 (2025-07-18 20:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.51.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLLogObject leveraging the GetLogObject service API.
  * Amazon Outposts
    * Added cmdlet Get-OUTPOutpostBillingInformation leveraging the GetOutpostBillingInformation service API.

### 5.0.13 (2025-07-17 19:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.50.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CleanRoomsML
    * Modified cmdlet New-CRMLMLInputChannel: added parameter ProtectedQueryInputParameters_ResultFormat.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter Code_Dependency.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameter Code_Dependency.
    * Modified cmdlet Update-CWSYNCanary: added parameter Code_Dependency.

### 5.0.12 (2025-07-16 17:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.49.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRCustomModelDeployment leveraging the GetCustomModelDeployment service API.
    * Added cmdlet Get-BDRCustomModelDeploymentList leveraging the ListCustomModelDeployments service API.
    * Added cmdlet New-BDRCustomModelDeployment leveraging the CreateCustomModelDeployment service API.
    * Added cmdlet Remove-BDRCustomModelDeployment leveraging the DeleteCustomModelDeployment service API.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BACC and can be listed using the command 'Get-AWSCmdletName -Service BACC'.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BAC and can be listed using the command 'Get-AWSCmdletName -Service BAC'.
  * Amazon CloudWatch Logs
    * Modified cmdlet Get-CWLResourcePolicy: added parameters PolicyScope and ResourceArn.
    * Modified cmdlet Remove-CWLResourcePolicy: added parameters ExpectedRevisionId and ResourceArn.
    * Modified cmdlet Write-CWLDeliveryDestination: added parameter DeliveryDestinationType.
    * Modified cmdlet Write-CWLResourcePolicy: added parameters ExpectedRevisionId and ResourceArn.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet Write-MPV2OriginEndpointPolicy: added parameters CdnAuthConfiguration_CdnIdentifierSecretArn and CdnAuthConfiguration_SecretsRoleArn.
  * Amazon GuardDuty
    * Modified cmdlet New-GDIPSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet New-GDThreatIntelSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet Update-GDIPSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet Update-GDThreatIntelSet: added parameter ExpectedBucketOwner.

### 5.0.11 (2025-07-16 02:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.48.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.10 (2025-07-15 20:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.47.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameters S3VectorsConfiguration_IndexArn, S3VectorsConfiguration_IndexName and S3VectorsConfiguration_VectorBucketArn.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters S3VectorsConfiguration_IndexArn, S3VectorsConfiguration_IndexName and S3VectorsConfiguration_VectorBucketArn.
  * Amazon DataZone
    * Modified cmdlet New-DZConnection: added parameters S3Properties_S3AccessGrantLocationId and S3Properties_S3Uri.
    * Modified cmdlet Update-DZConnection: added parameters S3Properties_S3AccessGrantLocationId and S3Properties_S3Uri.
  * Amazon DynamoDB Streams
    * Modified cmdlet Get-DDBSStream: added parameters ShardFilter_ShardId and ShardFilter_Type.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameters DeploymentConfiguration_BakeTimeInMinute, DeploymentConfiguration_LifecycleHook and DeploymentConfiguration_Strategy.
    * Modified cmdlet Update-ECSService: added parameters DeploymentConfiguration_BakeTimeInMinute, DeploymentConfiguration_LifecycleHook, DeploymentConfiguration_Strategy and DeploymentController_Type.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2InstanceConnectEndpoint: added parameter IpAddressType.
  * Amazon EventBridge
    * Modified cmdlet New-EVBEventBus: added parameters LogConfig_IncludeDetail and LogConfig_Level.
    * Modified cmdlet Update-EVBEventBus: added parameters LogConfig_IncludeDetail and LogConfig_Level.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter S3VectorsEngine_Enabled.
    * Modified cmdlet Update-OSDomainConfig: added parameter S3VectorsEngine_Enabled.
  * Amazon QuickSight
    * Modified cmdlet New-QSTopic: added parameter CustomInstructions_CustomInstructionsString.
    * Modified cmdlet Update-QSTopic: added parameter CustomInstructions_CustomInstructionsString.
  * Amazon re:Post Private
    * Added cmdlet Add-RESPBatchChannelRoleToAccessor leveraging the BatchAddChannelRoleToAccessors service API.
    * Added cmdlet Get-RESPChannel leveraging the GetChannel service API.
    * Added cmdlet Get-RESPChannelList leveraging the ListChannels service API.
    * Added cmdlet New-RESPChannel leveraging the CreateChannel service API.
    * Added cmdlet Remove-RESPBatchChannelRoleFromAccessor leveraging the BatchRemoveChannelRoleFromAccessors service API.
    * Added cmdlet Update-RESPChannel leveraging the UpdateChannel service API.
    * Modified cmdlet New-RESPSpace: added parameters SupportedEmailDomains_AllowedDomain and SupportedEmailDomains_Enabled.
    * Modified cmdlet Update-RESPSpace: added parameters SupportedEmailDomains_AllowedDomain and SupportedEmailDomains_Enabled.
  * Amazon S3 Tables
    * Modified cmdlet Get-S3TTableBucketList: added parameter Type.
  * Amazon S3 Vectors. Added cmdlets to support the service. Cmdlets for the service have the noun prefix S3V and can be listed using the command 'Get-AWSCmdletName -Service S3V'.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMPipelineVersionList leveraging the ListPipelineVersions service API.
    * Added cmdlet Update-SMPipelineVersion leveraging the UpdatePipelineVersion service API.
    * Modified cmdlet Get-SMPipeline: added parameter PipelineVersionId.
    * Modified cmdlet New-SMCluster: added parameter RestrictedInstanceGroup.
    * Modified cmdlet Start-SMPipelineExecution: added parameter PipelineVersionId.
    * Modified cmdlet Update-SMCluster: added parameter RestrictedInstanceGroup.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3BucketMetadataConfiguration leveraging the GetBucketMetadataConfiguration service API.
    * Added cmdlet Get-S3HeadBucket leveraging the HeadBucket service API.
    * Added cmdlet New-S3BucketMetadataConfiguration leveraging the CreateBucketMetadataConfiguration service API.
    * Added cmdlet Remove-S3BucketMetadataConfiguration leveraging the DeleteBucketMetadataConfiguration service API.
    * Added cmdlet Update-S3BucketMetadataInventoryTableConfiguration leveraging the UpdateBucketMetadataInventoryTableConfiguration service API.
    * Added cmdlet Update-S3BucketMetadataJournalTableConfiguration leveraging the UpdateBucketMetadataJournalTableConfiguration service API.
  * Enabled support for generating Get-S3HeadBucket CmdLet corresponding to S3 HeadBucket service API operation.

### 5.0.9 (2025-07-09 20:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.46.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2CapacityBlock leveraging the DescribeCapacityBlocks service API.
    * Added cmdlet Get-EC2CapacityBlockStatus leveraging the DescribeCapacityBlockStatus service API.
    * Modified cmdlet Get-EC2CapacityBlockOffering: added parameters UltraserverCount and UltraserverType.
  * Amazon Free Tier
    * Added cmdlet Get-FTAccountActivity leveraging the GetAccountActivity service API.
    * Added cmdlet Get-FTAccountActivityList leveraging the ListAccountActivities service API.
    * Added cmdlet Get-FTAccountPlanState leveraging the GetAccountPlanState service API.
    * Added cmdlet Set-FTAccountPlan leveraging the UpgradeAccountPlan service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3ObjectTagSet: added parameter ContentMD5.

### 5.0.8 (2025-07-03 20:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.45.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFUploadJob leveraging the GetUploadJob service API.
    * Added cmdlet Get-CPFUploadJobList leveraging the ListUploadJobs service API.
    * Added cmdlet Get-CPFUploadJobPath leveraging the GetUploadJobPath service API.
    * Added cmdlet New-CPFUploadJob leveraging the CreateUploadJob service API.
    * Added cmdlet Start-CPFUploadJob leveraging the StartUploadJob service API.
    * Added cmdlet Stop-CPFUploadJob leveraging the StopUploadJob service API.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2OriginEndpoint: added parameters Encryption_CmafExcludeSegmentDrmMetadata, EncryptionMethod_IsmEncryptionMethod and MssManifest.
    * Modified cmdlet Update-MPV2OriginEndpoint: added parameters Encryption_CmafExcludeSegmentDrmMetadata, EncryptionMethod_IsmEncryptionMethod and MssManifest.
  * Amazon SageMaker Service
    * Added cmdlet New-SMHubContentPresignedUrl leveraging the CreateHubContentPresignedUrls service API.
    * Added cmdlet Start-SMSession leveraging the StartSession service API.
    * Modified cmdlet New-SMSpace: added parameter SpaceSettings_RemoteAccess.
    * Modified cmdlet Update-SMSpace: added parameter SpaceSettings_RemoteAccess.

### 5.0.7 (2025-07-02 19:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.44.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Added cmdlet Remove-CCASCase leveraging the DeleteCase service API.
    * Added cmdlet Remove-CCASRelatedItem leveraging the DeleteRelatedItem service API.

### 5.0.6 (2025-07-01 22:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.43.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CleanRoomsML
    * Added cmdlet Get-CRMLTrainedModelVersionList leveraging the ListTrainedModelVersions service API.
    * Modified cmdlet Get-CRMLCollaborationTrainedModel: added parameter VersionIdentifier.
    * Modified cmdlet Get-CRMLCollaborationTrainedModelExportJobList: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Get-CRMLCollaborationTrainedModelInferenceJobList: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Get-CRMLTrainedModel: added parameter VersionIdentifier.
    * Modified cmdlet Get-CRMLTrainedModelInferenceJobList: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet New-CRMLConfiguredModelAlgorithmAssociation: added parameters MaxArtifactSize_Unit and MaxArtifactSize_Value.
    * Modified cmdlet New-CRMLTrainedModel: added parameters IncrementalTrainingDataChannel and TrainingInputMode.
    * Modified cmdlet Remove-CRMLTrainedModelOutput: added parameter VersionIdentifier.
    * Modified cmdlet Start-CRMLTrainedModelExportJob: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Start-CRMLTrainedModelInferenceJob: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Stop-CRMLTrainedModel: added parameter VersionIdentifier.
  * Amazon DataZone
    * Modified cmdlet Update-DZProject: added parameter DomainUnitId.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Get-EC2InstanceTypesFromInstanceRequirement: added parameter Context.
  * Amazon Oracle Database@Amazon Web Services. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ODB and can be listed using the command 'Get-AWSCmdletName -Service ODB'.
  * Amazon QBusiness
    * Added cmdlet Get-QBUSChatResponseConfiguration leveraging the GetChatResponseConfiguration service API.
    * Added cmdlet Get-QBUSChatResponseConfigurationList leveraging the ListChatResponseConfigurations service API.
    * Added cmdlet New-QBUSChatResponseConfiguration leveraging the CreateChatResponseConfiguration service API.
    * Added cmdlet Remove-QBUSChatResponseConfiguration leveraging the DeleteChatResponseConfiguration service API.
    * Added cmdlet Update-QBUSChatResponseConfiguration leveraging the UpdateChatResponseConfiguration service API.
    * Modified cmdlet New-QBUSRetriever: added parameter NativeIndexConfiguration_Version.
    * Modified cmdlet Update-QBUSRetriever: added parameter NativeIndexConfiguration_Version.

### 5.0.5 (2025-06-30 20:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.42.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ARC - Zonal Shift
    * Added cmdlet Start-AZSPracticeRun leveraging the StartPracticeRun service API.
    * Added cmdlet Stop-AZSPracticeRun leveraging the CancelPracticeRun service API.
  * Amazon B2B Data Interchange
    * Modified cmdlet New-B2BIPartnership: added parameters AcknowledgmentOptions_FunctionalAcknowledgment, AcknowledgmentOptions_TechnicalAcknowledgment, Common_Gs05TimeFormat, ControlNumbers_StartingFunctionalGroupControlNumber, ControlNumbers_StartingInterchangeControlNumber, ControlNumbers_StartingTransactionSetControlNumber, WrapOptions_LineLength, WrapOptions_LineTerminator and WrapOptions_WrapBy.
    * Modified cmdlet New-B2BITransformer: added parameter SplitOptions_SplitBy.
    * Modified cmdlet Test-B2BIParsing: added parameter SplitOptions_SplitBy.
    * Modified cmdlet Update-B2BIPartnership: added parameters AcknowledgmentOptions_FunctionalAcknowledgment, AcknowledgmentOptions_TechnicalAcknowledgment, Common_Gs05TimeFormat, ControlNumbers_StartingFunctionalGroupControlNumber, ControlNumbers_StartingInterchangeControlNumber, ControlNumbers_StartingTransactionSetControlNumber, WrapOptions_LineLength, WrapOptions_LineTerminator and WrapOptions_WrapBy.
    * Modified cmdlet Update-B2BITransformer: added parameter SplitOptions_SplitBy.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBTable: added parameter GlobalTableWitnessUpdate.
  * Amazon Glue
    * Modified cmdlet New-GLUEIntegration: added parameter IntegrationConfig_SourceProperty.
  * Amazon Identity and Access Management
    * Modified cmdlet Get-IAMServiceSpecificCredentialList: added parameters AllUser, Marker, MaxItem and NoAutoIteration.
    * Modified cmdlet New-IAMServiceSpecificCredential: added parameter CredentialAgeDay.
  * Amazon Medical Imaging Service
    * Modified cmdlet Copy-MISImageSet: added parameter PromoteToPrimary.
  * Amazon QuickSight
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_ExportToCsvInScheduledReport, Capabilities_ExportToExcelInScheduledReport, Capabilities_ExportToPdf, Capabilities_ExportToPdfInScheduledReport, Capabilities_IncludeContentInScheduledReportsEmail and Capabilities_PrintReport.
    * Modified cmdlet New-QSDataSource: added parameter DataSourceParameters_AthenaParameters_IdentityCenterConfiguration_EnableIdentityPropagation.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_ExportToCsvInScheduledReport, Capabilities_ExportToExcelInScheduledReport, Capabilities_ExportToPdf, Capabilities_ExportToPdfInScheduledReport, Capabilities_IncludeContentInScheduledReportsEmail and Capabilities_PrintReport.
    * Modified cmdlet Update-QSDataSource: added parameter DataSourceParameters_AthenaParameters_IdentityCenterConfiguration_EnableIdentityPropagation.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter IpAddressType.
    * Modified cmdlet Update-TFRServer: added parameter IpAddressType.

### 5.0.4 (2025-06-27 22:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.41.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet New-GLUECatalog: added parameter FederatedCatalog_ConnectionType.
    * Modified cmdlet New-GLUETable: added parameters CreateIcebergTableInput_Location, CreateIcebergTableInput_Property, Name, PartitionSpec_Field, PartitionSpec_SpecId, Schema_Field, Schema_IdentifierFieldId, Schema_SchemaId, Schema_Type, WriteOrder_Field and WriteOrder_OrderId.
    * Modified cmdlet Update-GLUECatalog: added parameter FederatedCatalog_ConnectionType.
    * Modified cmdlet Update-GLUETable: added parameters Name and UpdateIcebergTableInput_Update.

### 5.0.3 (2025-06-26 20:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.40.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2Route: added parameter OdbNetworkArn.
    * Modified cmdlet Set-EC2Route: added parameter OdbNetworkArn.
  * Amazon Keyspaces
    * Modified cmdlet New-KSTable: added parameters CdcSpecification_PropagateTag, CdcSpecification_Status, CdcSpecification_Tag and CdcSpecification_ViewType.
    * Modified cmdlet Update-KSTable: added parameters CdcSpecification_PropagateTag, CdcSpecification_Status, CdcSpecification_Tag and CdcSpecification_ViewType.
  * Amazon Keyspaces Streams. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KST and can be listed using the command 'Get-AWSCmdletName -Service KST'.
  * Amazon Managed integrations for AWS IoT Device Management
    * Added cmdlet Add-IOTMIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-IOTMIAccountAssociation leveraging the GetAccountAssociation service API.
    * Added cmdlet Get-IOTMIAccountAssociationList leveraging the ListAccountAssociations service API.
    * Added cmdlet Get-IOTMICloudConnector leveraging the GetCloudConnector service API.
    * Added cmdlet Get-IOTMICloudConnectorList leveraging the ListCloudConnectors service API.
    * Added cmdlet Get-IOTMIConnectorDestination leveraging the GetConnectorDestination service API.
    * Added cmdlet Get-IOTMIConnectorDestinationList leveraging the ListConnectorDestinations service API.
    * Added cmdlet Get-IOTMIDeviceDiscoveryList leveraging the ListDeviceDiscoveries service API.
    * Added cmdlet Get-IOTMIDiscoveredDeviceList leveraging the ListDiscoveredDevices service API.
    * Added cmdlet Get-IOTMIManagedThingAccountAssociationList leveraging the ListManagedThingAccountAssociations service API.
    * Added cmdlet Get-IOTMIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-IOTMIAccountAssociation leveraging the CreateAccountAssociation service API.
    * Added cmdlet New-IOTMICloudConnector leveraging the CreateCloudConnector service API.
    * Added cmdlet New-IOTMIConnectorDestination leveraging the CreateConnectorDestination service API.
    * Added cmdlet Register-IOTMIAccountAssociation leveraging the RegisterAccountAssociation service API.
    * Added cmdlet Remove-IOTMIAccountAssociation leveraging the DeleteAccountAssociation service API.
    * Added cmdlet Remove-IOTMICloudConnector leveraging the DeleteCloudConnector service API.
    * Added cmdlet Remove-IOTMIConnectorDestination leveraging the DeleteConnectorDestination service API.
    * Added cmdlet Remove-IOTMIResourceTag leveraging the UntagResource service API.
    * Added cmdlet Send-IOTMIConnectorEvent leveraging the SendConnectorEvent service API.
    * Added cmdlet Start-IOTMIAccountAssociationRefresh leveraging the StartAccountAssociationRefresh service API.
    * Added cmdlet Unregister-IOTMIAccountAssociation leveraging the DeregisterAccountAssociation service API.
    * Added cmdlet Update-IOTMIAccountAssociation leveraging the UpdateAccountAssociation service API.
    * Added cmdlet Update-IOTMICloudConnector leveraging the UpdateCloudConnector service API.
    * Added cmdlet Update-IOTMIConnectorDestination leveraging the UpdateConnectorDestination service API.
    * Modified cmdlet Get-IOTMIManagedThingList: added parameters ConnectorDestinationIdFilter and ConnectorDeviceIdFilter.
    * Modified cmdlet New-IOTMIManagedThing: added parameter CapabilitySchema.
    * Modified cmdlet Send-IOTMIManagedThingCommand: added parameter AccountAssociationId.
    * Modified cmdlet Start-IOTMIDeviceDiscovery: added parameters AccountAssociationId and CustomProtocolDetail.
    * Modified cmdlet Update-IOTMIManagedThing: added parameter CapabilitySchema.
  * Amazon QBusiness
    * Modified cmdlet Add-QBUSPermission: added parameter Condition.
    * Modified cmdlet New-QBUSDataAccessor: added parameters AuthenticationDetail_AuthenticationType, AuthenticationDetail_ExternalId and IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn.
    * Modified cmdlet Update-QBUSDataAccessor: added parameters AuthenticationDetail_AuthenticationType, AuthenticationDetail_ExternalId and IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn.
  * Amazon WorkSpaces
    * Modified cmdlet Edit-WKSWorkspaceAccessProperty: added parameters AccessEndpointConfig_AccessEndpoint and AccessEndpointConfig_InternetFallbackProtocol.

### 5.0.2 (2025-06-25 20:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.39.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon FSx
    * Added cmdlet Dismount-FSXAndDeleteS3AccessPoint leveraging the DetachAndDeleteS3AccessPoint service API.
    * Added cmdlet Get-FSXS3AccessPointAttachment leveraging the DescribeS3AccessPointAttachments service API.
    * Added cmdlet New-FSXAndAttachS3AccessPoint leveraging the CreateAndAttachS3AccessPoint service API.
  * Amazon S3 Control
    * Modified cmdlet Get-S3CAccessPointList: added parameters DataSourceId and DataSourceType.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3BucketIntelligentTieringConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketIntelligentTieringConfigurationList: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketIntelligentTieringConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketIntelligentTieringConfiguration: added parameter ExpectedBucketOwner.

### 5.0.1 (2025-06-24 20:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.38.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AI Ops
    * Modified cmdlet New-AIOpsInvestigationGroup: added parameter CrossAccountConfiguration.
    * Modified cmdlet Update-AIOpsInvestigationGroup: added parameter CrossAccountConfiguration.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter LaunchTemplate_UserdataType.
    * Modified cmdlet Update-BATComputeEnvironment: added parameter LaunchTemplate_UserdataType.
  * Amazon Bedrock
    * Added cmdlet Get-BDRFoundationModelAgreementOfferList leveraging the ListFoundationModelAgreementOffers service API.
    * Added cmdlet Get-BDRFoundationModelAvailability leveraging the GetFoundationModelAvailability service API.
    * Added cmdlet Get-BDRUseCaseForModelAccess leveraging the GetUseCaseForModelAccess service API.
    * Added cmdlet New-BDRFoundationModelAgreement leveraging the CreateFoundationModelAgreement service API.
    * Added cmdlet Remove-BDRFoundationModelAgreement leveraging the DeleteFoundationModelAgreement service API.
    * Added cmdlet Write-BDRUseCaseForModelAccess leveraging the PutUseCaseForModelAccess service API.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2Image: added parameter SnapshotLocation.
  * Amazon License Manager
    * Modified cmdlet New-LICMLicenseConversionTaskForResource: added parameters DestinationLicenseContext_ProductCode and SourceLicenseContext_ProductCode.
  * Amazon Relational Database Service
    * Modified cmdlet Copy-RDSDBSnapshot: added parameters SnapshotAvailabilityZone and SnapshotTarget.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter BackupTarget.
  * Amazon Route 53 Resolver
    * Modified cmdlet New-R53RResolverRule: added parameter DelegationRecord.

### 5.0.0 (2025-06-23 20:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.37.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Please refer to the migration guide for a list of breaking changes and workarounds at https://docs.aws.amazon.com/powershell/v5/userguide/migrating-v5.html

### 5.0.0-preview005 (2025-05-30 15:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.22.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview005 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 5.0.0-preview004 (2025-04-29 14:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.0.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview004 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 5.0.0-preview003 (2025-03-17 16:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.0.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/v4-release/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview003 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 5.0.0-preview002 (2025-02-18 15:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.0.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/v4-release/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview002 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 4.1.845 (2025-06-20 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1068.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet New-BDRGuardrail: added parameters ContentPolicyConfig_TierConfig_TierName and TopicPolicyConfig_TierConfig_TierName.
    * Modified cmdlet Update-BDRGuardrail: added parameters ContentPolicyConfig_TierConfig_TierName and TopicPolicyConfig_TierConfig_TierName.

### 4.1.844 (2025-06-19 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1067.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameter IdentityCenterConfiguration_IdentityCenterInstanceArn.
    * Modified cmdlet Update-EMRServerlessApplication: added parameter IdentityCenterConfiguration_IdentityCenterInstanceArn.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameters AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs, SchemaRegistryConfig_AccessConfig, SchemaRegistryConfig_EventRecordFormat, SchemaRegistryConfig_SchemaRegistryURI and SchemaRegistryConfig_SchemaValidationConfig.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters AmazonManagedKafkaEventSourceConfig_ConsumerGroupId, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs, SchemaRegistryConfig_AccessConfig, SchemaRegistryConfig_EventRecordFormat, SchemaRegistryConfig_SchemaRegistryURI, SchemaRegistryConfig_SchemaValidationConfig and SelfManagedKafkaEventSourceConfig_ConsumerGroupId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMProject: added parameter TemplateProvider.
    * Modified cmdlet Update-SMProject: added parameter TemplateProvidersToUpdate.

### 4.1.843 (2025-06-18 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1066.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AI Ops. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AIOps and can be listed using the command 'Get-AWSCmdletName -Service AIOps'.
  * Amazon Auto Scaling
    * Modified cmdlet Get-ASAutoScalingGroup: added parameter IncludeInstance.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Rename-S3Object leveraging the RenameObject service API.

### 4.1.842 (2025-06-17 22:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1065.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Added cmdlet Add-BAKBackupVaultMpaApprovalTeam leveraging the AssociateBackupVaultMpaApprovalTeam service API.
    * Added cmdlet Get-BAKRestoreAccessBackupVaultList leveraging the ListRestoreAccessBackupVaults service API.
    * Added cmdlet New-BAKRestoreAccessBackupVault leveraging the CreateRestoreAccessBackupVault service API.
    * Added cmdlet Remove-BAKBackupVaultMpaApprovalTeam leveraging the DisassociateBackupVaultMpaApprovalTeam service API.
    * Added cmdlet Revoke-BAKRestoreAccessBackupVault leveraging the RevokeRestoreAccessBackupVault service API.
  * Amazon Certificate Manager
    * Added cmdlet Revoke-ACMCertificate leveraging the RevokeCertificate service API.
    * Modified cmdlet Get-ACMCertificateList: added parameter Includes_ExportOption.
    * Modified cmdlet New-ACMCertificate: added parameter Options_Export.
    * Modified cmdlet Update-ACMCertificateOption: added parameter Options_Export.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSDataProvider: added parameters IbmDb2LuwSettings_S3AccessRoleArn, IbmDb2LuwSettings_S3Path, IbmDb2zOsSettings_S3AccessRoleArn, IbmDb2zOsSettings_S3Path, MariaDbSettings_S3AccessRoleArn, MariaDbSettings_S3Path, MicrosoftSqlServerSettings_S3AccessRoleArn, MicrosoftSqlServerSettings_S3Path, MySqlSettings_S3AccessRoleArn, MySqlSettings_S3Path, OracleSettings_S3AccessRoleArn, OracleSettings_S3Path, PostgreSqlSettings_S3AccessRoleArn, PostgreSqlSettings_S3Path, RedshiftSettings_S3AccessRoleArn, RedshiftSettings_S3Path and Virtual.
    * Modified cmdlet New-DMSDataProvider: added parameters IbmDb2LuwSettings_S3AccessRoleArn, IbmDb2LuwSettings_S3Path, IbmDb2zOsSettings_S3AccessRoleArn, IbmDb2zOsSettings_S3Path, MariaDbSettings_S3AccessRoleArn, MariaDbSettings_S3Path, MicrosoftSqlServerSettings_S3AccessRoleArn, MicrosoftSqlServerSettings_S3Path, MySqlSettings_S3AccessRoleArn, MySqlSettings_S3Path, OracleSettings_S3AccessRoleArn, OracleSettings_S3Path, PostgreSqlSettings_S3AccessRoleArn, PostgreSqlSettings_S3Path, RedshiftSettings_S3AccessRoleArn, RedshiftSettings_S3Path and Virtual.
  * Amazon IAM Access Analyzer
    * Modified cmdlet New-IAMAAAnalyzer: added parameter AnalysisRule_Inclusion.
    * Modified cmdlet Update-IAMAAAnalyzer: added parameter AnalysisRule_Inclusion.
  * Amazon Inspector2
    * Added cmdlet Get-INS2CodeSecurityIntegration leveraging the GetCodeSecurityIntegration service API.
    * Added cmdlet Get-INS2CodeSecurityIntegrationList leveraging the ListCodeSecurityIntegrations service API.
    * Added cmdlet Get-INS2CodeSecurityScan leveraging the GetCodeSecurityScan service API.
    * Added cmdlet Get-INS2CodeSecurityScanConfiguration leveraging the GetCodeSecurityScanConfiguration service API.
    * Added cmdlet Get-INS2CodeSecurityScanConfigurationAssociationList leveraging the ListCodeSecurityScanConfigurationAssociations service API.
    * Added cmdlet Get-INS2CodeSecurityScanConfigurationList leveraging the ListCodeSecurityScanConfigurations service API.
    * Added cmdlet New-INS2CodeSecurityIntegration leveraging the CreateCodeSecurityIntegration service API.
    * Added cmdlet New-INS2CodeSecurityScanConfiguration leveraging the CreateCodeSecurityScanConfiguration service API.
    * Added cmdlet Register-INS2CodeSecurityScanConfigurationBatch leveraging the BatchAssociateCodeSecurityScanConfiguration service API.
    * Added cmdlet Remove-INS2CodeSecurityIntegration leveraging the DeleteCodeSecurityIntegration service API.
    * Added cmdlet Remove-INS2CodeSecurityScanConfiguration leveraging the DeleteCodeSecurityScanConfiguration service API.
    * Added cmdlet Start-INS2CodeSecurityScan leveraging the StartCodeSecurityScan service API.
    * Added cmdlet Unregister-INS2CodeSecurityScanConfigurationBatch leveraging the BatchDisassociateCodeSecurityScanConfiguration service API.
    * Added cmdlet Update-INS2CodeSecurityIntegration leveraging the UpdateCodeSecurityIntegration service API.
    * Added cmdlet Update-INS2CodeSecurityScanConfiguration leveraging the UpdateCodeSecurityScanConfiguration service API.
    * Modified cmdlet Get-INS2CoverageList: added parameters FilterCriteria_CodeRepositoryProjectName, FilterCriteria_CodeRepositoryProviderType, FilterCriteria_CodeRepositoryProviderTypeVisibility and FilterCriteria_LastScannedCommitId.
    * Modified cmdlet Get-INS2CoverageStatisticList: added parameters FilterCriteria_CodeRepositoryProjectName, FilterCriteria_CodeRepositoryProviderType, FilterCriteria_CodeRepositoryProviderTypeVisibility and FilterCriteria_LastScannedCommitId.
    * Modified cmdlet Get-INS2FindingAggregationList: added parameters CodeRepositoryAggregation_ProjectName, CodeRepositoryAggregation_ProviderType, CodeRepositoryAggregation_ResourceId, CodeRepositoryAggregation_SortBy and CodeRepositoryAggregation_SortOrder.
    * Modified cmdlet Get-INS2FindingList: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet New-INS2Filter: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet New-INS2FindingsReport: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet Update-INS2Filter: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet Update-INS2OrganizationConfiguration: added parameter AutoEnable_CodeRepository.
  * Amazon Multi-party Approval. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MPA and can be listed using the command 'Get-AWSCmdletName -Service MPA'.
  * NWFW
    * [Breaking Change] Removed cmdlets Approve-NWFWNetworkFirewallTransitGatewayAttachment, Register-NWFWAvailabilityZone and Unregister-NWFWAvailabilityZone.
    * Added cmdlet Get-NWFWRuleGroupSummary leveraging the DescribeRuleGroupSummary service API.
    * Added cmdlet Join-NWFWAvailabilityZone leveraging the AssociateAvailabilityZones service API.
    * Added cmdlet Receive-NWFWNetworkFirewallTransitGatewayAttachment leveraging the AcceptNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Remove-NWFWAvailabilityZone leveraging the DisassociateAvailabilityZones service API.
    * Modified cmdlet New-NWFWRuleGroup: added parameter SummaryConfiguration_RuleOption.
    * Modified cmdlet Update-NWFWRuleGroup: added parameter SummaryConfiguration_RuleOption.
  * Amazon Security Hub
    * Added cmdlet Disable-SHUBSecurityHubV2 leveraging the DisableSecurityHubV2 service API.
    * Added cmdlet Enable-SHUBSecurityHubV2 leveraging the EnableSecurityHubV2 service API.
    * Added cmdlet Get-SHUBAggregatorsV2List leveraging the ListAggregatorsV2 service API.
    * Added cmdlet Get-SHUBAggregatorV2 leveraging the GetAggregatorV2 service API.
    * Added cmdlet Get-SHUBAutomationRulesV2List leveraging the ListAutomationRulesV2 service API.
    * Added cmdlet Get-SHUBAutomationRuleV2 leveraging the GetAutomationRuleV2 service API.
    * Added cmdlet Get-SHUBConnectorsV2List leveraging the ListConnectorsV2 service API.
    * Added cmdlet Get-SHUBConnectorV2 leveraging the GetConnectorV2 service API.
    * Added cmdlet Get-SHUBFindingStatisticsV2 leveraging the GetFindingStatisticsV2 service API.
    * Added cmdlet Get-SHUBFindingsV2 leveraging the GetFindingsV2 service API.
    * Added cmdlet Get-SHUBProductsV2 leveraging the DescribeProductsV2 service API.
    * Added cmdlet Get-SHUBResourcesStatisticsV2 leveraging the GetResourcesStatisticsV2 service API.
    * Added cmdlet Get-SHUBResourcesV2 leveraging the GetResourcesV2 service API.
    * Added cmdlet Get-SHUBSecurityHubV2 leveraging the DescribeSecurityHubV2 service API.
    * Added cmdlet New-SHUBAggregatorV2 leveraging the CreateAggregatorV2 service API.
    * Added cmdlet New-SHUBAutomationRuleV2 leveraging the CreateAutomationRuleV2 service API.
    * Added cmdlet New-SHUBConnectorV2 leveraging the CreateConnectorV2 service API.
    * Added cmdlet New-SHUBTicketV2 leveraging the CreateTicketV2 service API.
    * Added cmdlet Register-SHUBConnectorV2 leveraging the ConnectorRegistrationsV2 service API.
    * Added cmdlet Remove-SHUBAggregatorV2 leveraging the DeleteAggregatorV2 service API.
    * Added cmdlet Remove-SHUBAutomationRuleV2 leveraging the DeleteAutomationRuleV2 service API.
    * Added cmdlet Remove-SHUBConnectorV2 leveraging the DeleteConnectorV2 service API.
    * Added cmdlet Set-SHUBBatchFindingsV2 leveraging the BatchUpdateFindingsV2 service API.
    * Added cmdlet Update-SHUBAggregatorV2 leveraging the UpdateAggregatorV2 service API.
    * Added cmdlet Update-SHUBAutomationRuleV2 leveraging the UpdateAutomationRuleV2 service API.
    * Added cmdlet Update-SHUBConnectorV2 leveraging the UpdateConnectorV2 service API.
    * Modified cmdlet Disable-SHUBOrganizationAdminAccount: added parameter Feature.
    * Modified cmdlet Enable-SHUBOrganizationAdminAccount: added parameter Feature.
    * Modified cmdlet Get-SHUBOrganizationAdminAccountList: added parameter Feature.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter ApplicationConfig_Attribute.

### 4.1.841 (2025-06-16 19:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1064.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet New-BDRCustomModel leveraging the CreateCustomModel service API.
    * Modified cmdlet Get-BDRCustomModelList: added parameter ModelStatus.
  * Amazon Network Firewall
    * Added cmdlet Approve-NWFWNetworkFirewallTransitGatewayAttachment leveraging the AcceptNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Deny-NWFWNetworkFirewallTransitGatewayAttachment leveraging the RejectNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Register-NWFWAvailabilityZone leveraging the AssociateAvailabilityZones service API.
    * Added cmdlet Remove-NWFWNetworkFirewallTransitGatewayAttachment leveraging the DeleteNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Unregister-NWFWAvailabilityZone leveraging the DisassociateAvailabilityZones service API.
    * Added cmdlet Update-NWFWAvailabilityZoneChangeProtection leveraging the UpdateAvailabilityZoneChangeProtection service API.
    * Modified cmdlet New-NWFWFirewall: added parameters AvailabilityZoneChangeProtection, AvailabilityZoneMapping and TransitGatewayId.

### 4.1.840 (2025-06-12 20:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1063.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonConnectCampaignServiceV2
    * Added cmdlet Get-CCS2InstanceCommunicationLimit leveraging the GetInstanceCommunicationLimits service API.
    * Added cmdlet Write-CCS2InstanceCommunicationLimit leveraging the PutInstanceCommunicationLimits service API.
    * Modified cmdlet New-CCS2Campaign: added parameter CommunicationLimitsOverride_InstanceLimitsHandling.
    * Modified cmdlet Update-CCS2CampaignCommunicationLimit: added parameter CommunicationLimitsOverride_InstanceLimitsHandling.

### 4.1.839 (2025-06-11 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1062.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Catalog
    * Added cmdlet Get-CLCATControlMappingList leveraging the ListControlMappings service API.
    * Modified cmdlet Get-CLCATControlList: added parameters Implementations_Identifier and Implementations_Type.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSPodIdentityAssociation: added parameters DisableSessionTag and TargetRoleArn.
    * Modified cmdlet Update-EKSPodIdentityAssociation: added parameters DisableSessionTag and TargetRoleArn.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameter NluImprovement_Enabled.
    * Modified cmdlet Update-LMBV2BotLocale: added parameter NluImprovement_Enabled.
  * Amazon Network Manager
    * Modified cmdlet New-NMGRVpcAttachment: added parameters Options_DnsSupport and Options_SecurityGroupReferencingSupport.
    * Modified cmdlet Update-NMGRVpcAttachment: added parameters Options_DnsSupport and Options_SecurityGroupReferencingSupport.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter OnSourceDDoSProtectionConfig_ALBLowReputationMode.
    * Modified cmdlet Update-WAF2WebACL: added parameter OnSourceDDoSProtectionConfig_ALBLowReputationMode.

### 4.1.838 (2025-06-10 20:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1061.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.837 (2025-06-09 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1061.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFDomainLayout leveraging the GetDomainLayout service API.
    * Added cmdlet Get-CPFDomainLayoutList leveraging the ListDomainLayouts service API.
    * Added cmdlet New-CPFDomainLayout leveraging the CreateDomainLayout service API.
    * Added cmdlet Remove-CPFDomainLayout leveraging the DeleteDomainLayout service API.
    * Added cmdlet Update-CPFDomainLayout leveraging the UpdateDomainLayout service API.
    * Modified cmdlet New-CPFCalculatedAttributeDefinition: added parameters Range_TimestampFormat, Range_TimestampSource, UseHistoricalData, ValueRange_End and ValueRange_Start.
    * Modified cmdlet Update-CPFCalculatedAttributeDefinition: added parameters Range_TimestampFormat, Range_TimestampSource, ValueRange_End and ValueRange_Start.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2NetworkInterfaceAttribute: added parameter AssociatedSubnetId.
  * Amazon Elastic File System
    * Modified cmdlet New-EFSMountTarget: added parameters IpAddressType and Ipv6Address.
  * Amazon Marketplace Catalog Service
    * Modified cmdlet Get-MCATEntityList: added parameters DateRange_AfterValue, DateRange_BeforeValue, EntityId_ValueList, MachineLearningProductSort_SortBy, MachineLearningProductSort_SortOrder, ProductTitle_ValueList, ProductTitle_WildCardValue and Visibility_ValueList.

### 4.1.836 (2025-06-06 20:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1060.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARAgent: added parameters PromptCreationConfigurations_ExcludePreviousThinkingStep and PromptCreationConfigurations_PreviousConversationTurnsToInclude.
    * Modified cmdlet Invoke-BARInlineAgent: added parameters PromptCreationConfigurations_ExcludePreviousThinkingStep and PromptCreationConfigurations_PreviousConversationTurnsToInclude.
  * Amazon Rekognition
    * Modified cmdlet New-REKFaceLivenessSession: added parameter Settings_ChallengePreference.
  * Amazon S3 Tables
    * Modified cmdlet Get-S3TTable: added parameter TableArn.

### 4.1.835 (2025-06-05 20:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1059.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Key Management Service
    * Modified cmdlet Get-KMSKeyRotation: added parameter IncludeKeyMaterial.
    * Modified cmdlet Import-KMSKeyMaterial: added parameters ImportType, KeyMaterialDescription and KeyMaterialId.
    * Modified cmdlet Remove-KMSImportedKeyMaterial: added parameter KeyMaterialId.

### 4.1.834 (2025-06-04 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1058.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic VMware Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EVS and can be listed using the command 'Get-AWSCmdletName -Service EVS'.
  * Amazon Invoicing
    * Added cmdlet Get-INVInvoiceSummaryList leveraging the ListInvoiceSummaries service API.
  * Amazon Network Firewall
    * Modified cmdlet Update-NWFWLoggingConfiguration: added parameter EnableMonitoringDashboard.

### 4.1.833 (2025-06-03 20:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1057.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter RoutingMode.
  * Amazon API Gateway V2
    * Added cmdlet Get-AG2RoutingRule leveraging the GetRoutingRule service API.
    * Added cmdlet Get-AG2RoutingRuleList leveraging the ListRoutingRules service API.
    * Added cmdlet New-AG2RoutingRule leveraging the CreateRoutingRule service API.
    * Added cmdlet Remove-AG2RoutingRule leveraging the DeleteRoutingRule service API.
    * Added cmdlet Write-AG2RoutingRule leveraging the PutRoutingRule service API.
    * Modified cmdlet New-AG2DomainName: added parameter RoutingMode.
    * Modified cmdlet Update-AG2DomainName: added parameter RoutingMode.
  * Amazon EMR Serverless
    * Modified cmdlet Stop-EMRServerlessJobRun: added parameter ShutdownGracePeriodInSecond.

### 4.1.832 (2025-06-02 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1056.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet Update-AABAgentAlias: added parameter AliasInvocationState.
  * Amazon Athena
    * Modified cmdlet Get-ATHQueryResult: added parameter QueryResultType.
    * Modified cmdlet New-ATHWorkGroup: added parameters Configuration_ManagedQueryResultsConfiguration_EncryptionConfiguration_KmsKey and ManagedQueryResultsConfiguration_Enabled.
    * Modified cmdlet Update-ATHWorkGroup: added parameters ConfigurationUpdates_ManagedQueryResultsConfigurationUpdates_EncryptionConfiguration_KmsKey, ManagedQueryResultsConfigurationUpdates_Enabled and ManagedQueryResultsConfigurationUpdates_RemoveEncryptionConfiguration.
  * Amazon EntityResolution
    * Added cmdlet Set-ERESMatchId leveraging the GenerateMatchId service API.

### 4.1.831 (2025-05-30 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1055.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet Start-EMRServerlessJobRun: added parameters ExecutionIamPolicy_Policy and ExecutionIamPolicy_PolicyArn.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter UnifiedStudioSettings_SingleSignOnApplicationArn.
    * Modified cmdlet Update-SMDomain: added parameter UnifiedStudioSettings_SingleSignOnApplicationArn.

### 4.1.830 (2025-05-29 20:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1054.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAA
    * Modified cmdlet Update-MWAAEnvironment: added parameter WorkerReplacementStrategy.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter JobConfig_BuildComputeType.
    * Modified cmdlet Update-AMPApp: added parameter JobConfig_BuildComputeType.
  * Amazon CloudTrail
    * Added cmdlet Get-CTEventConfiguration leveraging the GetEventConfiguration service API.
    * Added cmdlet Write-CTEventConfiguration leveraging the PutEventConfiguration service API.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXEventAction: added parameter Tag.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationAzureBlob: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet New-DSYNLocationObjectStorage: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationAzureBlob: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationObjectStorage: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
  * Amazon Interactive Video Service RealTime
    * Added cmdlet Get-IVSRTParticipantReplicaList leveraging the ListParticipantReplicas service API.
    * Added cmdlet Start-IVSRTParticipantReplication leveraging the StartParticipantReplication service API.
    * Added cmdlet Stop-IVSRTParticipantReplication leveraging the StopParticipantReplication service API.
    * Modified cmdlet New-IVSRTStage: added parameter AutoParticipantRecordingConfiguration_RecordParticipantReplica.
    * Modified cmdlet Update-IVSRTStage: added parameter AutoParticipantRecordingConfiguration_RecordParticipantReplica.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3BucketOwnershipControl: added parameter ChecksumAlgorithm.

### 4.1.829 (2025-05-28 20:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1053.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter RunConfig_EphemeralStorage.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameter RunConfig_EphemeralStorage.
    * Modified cmdlet Update-CWSYNCanary: added parameter RunConfig_EphemeralStorage.
  * Amazon Cost Optimization Hub
    * Modified cmdlet Update-COHPreference: added parameters PreferredCommitment_PaymentOption and PreferredCommitment_Term.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Unregister-EC2Image: added parameter DeleteAssociatedSnapshot.
  * Amazon Network Firewall
    * Added cmdlet Get-NWFWFirewallMetadata leveraging the DescribeFirewallMetadata service API.
    * Added cmdlet Get-NWFWVpcEndpointAssociation leveraging the DescribeVpcEndpointAssociation service API.
    * Added cmdlet Get-NWFWVpcEndpointAssociationList leveraging the ListVpcEndpointAssociations service API.
    * Added cmdlet New-NWFWVpcEndpointAssociation leveraging the CreateVpcEndpointAssociation service API.
    * Added cmdlet Remove-NWFWVpcEndpointAssociation leveraging the DeleteVpcEndpointAssociation service API.
    * Modified cmdlet Get-NWFWFlowOperation: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Get-NWFWFlowOperationList: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Get-NWFWFlowOperationResultList: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Start-NWFWFlowCapture: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Start-NWFWFlowFlush: added parameters VpcEndpointAssociationArn and VpcEndpointId.

### 4.1.828 (2025-05-27 20:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1052.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameter ServiceManagedEc2_StorageProfileId.
    * Modified cmdlet Update-ADCFleet: added parameter ServiceManagedEc2_StorageProfileId.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostAndUsageComparison leveraging the GetCostAndUsageComparisons service API.
    * Added cmdlet Get-CECostComparisonDriver leveraging the GetCostComparisonDrivers service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2ActiveVpnTunnelStatus leveraging the GetActiveVpnTunnelStatus service API.
    * Modified cmdlet Edit-EC2VpnTunnelOption: added parameter PreSharedKeyStorage.
    * Modified cmdlet Get-EC2VpnConnectionDeviceSampleConfiguration: added parameter SampleType.
    * Modified cmdlet New-EC2VpnConnection: added parameter PreSharedKeyStorage.

### 4.1.827 (2025-05-23 20:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1051.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.826 (2025-05-22 20:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1050.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Aurora DSQL
    * Modified cmdlet New-DSQLCluster: added parameter KmsEncryptionKey.
    * Modified cmdlet Update-DSQLCluster: added parameter KmsEncryptionKey.
  * Amazon Prometheus Service
    * Added cmdlet Get-PROMQueryLoggingConfiguration leveraging the DescribeQueryLoggingConfiguration service API.
    * Added cmdlet New-PROMQueryLoggingConfiguration leveraging the CreateQueryLoggingConfiguration service API.
    * Added cmdlet Remove-PROMQueryLoggingConfiguration leveraging the DeleteQueryLoggingConfiguration service API.
    * Added cmdlet Update-PROMQueryLoggingConfiguration leveraging the UpdateQueryLoggingConfiguration service API.

### 4.1.825 (2025-05-21 20:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1049.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Get-BARExecutionFlowSnapshot leveraging the GetExecutionFlowSnapshot service API.
    * Added cmdlet Get-BARFlowExecution leveraging the GetFlowExecution service API.
    * Added cmdlet Get-BARFlowExecutionEventList leveraging the ListFlowExecutionEvents service API.
    * Added cmdlet Get-BARFlowExecutionList leveraging the ListFlowExecutions service API.
    * Added cmdlet Start-BARFlowExecution leveraging the StartFlowExecution service API.
    * Added cmdlet Stop-BARFlowExecution leveraging the StopFlowExecution service API.
  * Amazon CloudWatch
    * Modified cmdlet Write-CWInsightRule: added parameter ApplyOnTransformedLog.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2PublicIpDnsNameOption leveraging the ModifyPublicIpDnsNameOptions service API.

### 4.1.824 (2025-05-20 20:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1048.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Private 5G
  * Amazon CloudWatch Observability Access Manager
    * Modified cmdlet Get-CWOAMLink: added parameter IncludeTag.
    * Modified cmdlet Get-CWOAMSink: added parameter IncludeTag.
    * Modified cmdlet Update-CWOAMLink: added parameter IncludeTag.
  * DSYN
    * [Breaking Change] Removed cmdlets Add-DSYNStorageSystem, Get-DSYNDiscoveryJob, Get-DSYNDiscoveryJobList, Get-DSYNStorageSystem, Get-DSYNStorageSystemList, Get-DSYNStorageSystemResource, Get-DSYNStorageSystemResourceMetric, New-DSYNRecommendation, Remove-DSYNStorageSystem, Start-DSYNDiscoveryJob, Stop-DSYNDiscoveryJob, Update-DSYNDiscoveryJob and Update-DSYNStorageSystem.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2InstanceMaintenanceOption: added parameter RebootMigration.
  * Amazon Inspector2
    * Added cmdlet Get-INS2ClustersForImage leveraging the GetClustersForImage service API.
    * Modified cmdlet Get-INS2CoverageList: added parameters FilterCriteria_EcrImageInUseCount and FilterCriteria_EcrImageLastInUseAt.
    * Modified cmdlet Get-INS2CoverageStatisticList: added parameters FilterCriteria_EcrImageInUseCount and FilterCriteria_EcrImageLastInUseAt.
    * Modified cmdlet Get-INS2FindingAggregationList: added parameters AwsEcrContainerAggregation_InUseCount and AwsEcrContainerAggregation_LastInUseAt.
    * Modified cmdlet Get-INS2FindingList: added parameters FilterCriteria_EcrImageInUseCount and FilterCriteria_EcrImageLastInUseAt.
    * Modified cmdlet New-INS2Filter: added parameters FilterCriteria_EcrImageInUseCount and FilterCriteria_EcrImageLastInUseAt.
    * Modified cmdlet New-INS2FindingsReport: added parameters FilterCriteria_EcrImageInUseCount and FilterCriteria_EcrImageLastInUseAt.
    * Modified cmdlet Update-INS2Configuration: added parameter EcrConfiguration_PullDateRescanMode.
    * Modified cmdlet Update-INS2Filter: added parameters FilterCriteria_EcrImageInUseCount and FilterCriteria_EcrImageLastInUseAt.
  * Amazon Relational Database Service
    * Added cmdlet Get-RDSDBMajorEngineVersion leveraging the DescribeDBMajorEngineVersions service API.

### 4.1.823 (2025-05-19 20:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1047.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * DSQL
    * [Breaking Change] Removed cmdlets New-DSQLMultiRegionCluster and Remove-DSQLMultiRegionCluster.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2MacModificationTask leveraging the DescribeMacModificationTasks service API.
    * Added cmdlet New-EC2DelegateMacVolumeOwnershipTask leveraging the CreateDelegateMacVolumeOwnershipTask service API.
    * Added cmdlet New-EC2MacSystemIntegrityProtectionModificationTask leveraging the CreateMacSystemIntegrityProtectionModificationTask service API.

### 4.1.822 (2025-05-16 20:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1046.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodePipeline
    * Added cmdlet Get-CPDeployActionExecutionTargetList leveraging the ListDeployActionExecutionTargets service API.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMROnClusterAppUIPresignedURL leveraging the GetOnClusterAppUIPresignedURL service API.
    * Added cmdlet Get-EMRPersistentAppUI leveraging the DescribePersistentAppUI service API.
    * Added cmdlet Get-EMRPersistentAppUIPresignedURL leveraging the GetPersistentAppUIPresignedURL service API.
    * Added cmdlet New-EMRPersistentAppUI leveraging the CreatePersistentAppUI service API.
  * Amazon Neptune
    * Added cmdlet Request-NPTSwitchoverGlobalCluster leveraging the SwitchoverGlobalCluster service API.
    * Modified cmdlet Edit-NPTGlobalClusterPrimary: added parameters AllowDataLoss and Switchover.
  * Amazon Runtime for Amazon Bedrock Data Automation
    * Modified cmdlet Invoke-BDARDataAutomationAsync: added parameters TimestampSegment_EndTimeMilli and TimestampSegment_StartTimeMilli.
  * Amazon Service Quotas
    * Added cmdlet New-SQSupportCase leveraging the CreateSupportCase service API.

### 4.1.821 (2025-05-15 20:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1045.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABFlowAlias: added parameters ConcurrencyConfiguration_MaxConcurrency and ConcurrencyConfiguration_Type.
    * Modified cmdlet Update-AABFlowAlias: added parameters ConcurrencyConfiguration_MaxConcurrency and ConcurrencyConfiguration_Type.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters DockerServer_ComputeType, DockerServer_SecurityGroupId, Status_Message and Status_Status.
    * Modified cmdlet Update-CBProject: added parameters DockerServer_ComputeType, DockerServer_SecurityGroupId, Status_Message and Status_Status.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters MySQLSettings_AuthenticationMethod, MySQLSettings_ServiceAccessRoleArn, PostgreSQLSettings_AuthenticationMethod and PostgreSQLSettings_ServiceAccessRoleArn.
    * Modified cmdlet New-DMSEndpoint: added parameters MySQLSettings_AuthenticationMethod, MySQLSettings_ServiceAccessRoleArn, PostgreSQLSettings_AuthenticationMethod and PostgreSQLSettings_ServiceAccessRoleArn.
  * Amazon Parallel Computing Service
    * Modified cmdlet New-PCSCluster: added parameters Accounting_DefaultPurgeTimeInDay and Accounting_Mode.
  * Amazon WorkSpaces
    * Modified cmdlet New-WKSWorkspacesPool: added parameter RunningMode.
    * Modified cmdlet Update-WKSWorkspacesPool: added parameter RunningMode.

### 4.1.820 (2025-05-14 20:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1044.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLLogGroupList leveraging the ListLogGroups service API.
    * Modified cmdlet Get-CWLLogGroup: added parameter LogGroupIdentifier.

### 4.1.819 (2025-05-13 20:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1043.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Aurora DSQL
    * Modified cmdlet New-DSQLCluster: added parameters MultiRegionProperties_Cluster and MultiRegionProperties_WitnessRegion.
    * Modified cmdlet Update-DSQLCluster: added parameters MultiRegionProperties_Cluster and MultiRegionProperties_WitnessRegion.
  * Amazon Bedrock
    * Modified cmdlet New-BDRGuardrail: added parameter CrossRegionConfig_GuardrailProfileIdentifier.
    * Modified cmdlet Update-BDRGuardrail: added parameter CrossRegionConfig_GuardrailProfileIdentifier.
  * Amazon Control Tower
    * Modified cmdlet Get-ACTEnabledBaselineList: added parameters Filter_InheritanceDriftStatus and Filter_Status.
  * Amazon License Manager
    * Modified cmdlet New-LICMGrant: added parameter Tag.
    * Modified cmdlet New-LICMLicense: added parameter Tag.

### 4.1.818 (2025-05-12 20:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1042.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameters HostConfiguration_ScriptBody and HostConfiguration_ScriptTimeoutSecond.
    * Modified cmdlet Update-ADCFleet: added parameters HostConfiguration_ScriptBody and HostConfiguration_ScriptTimeoutSecond.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Get-EC2ReservedInstancesOffering: added parameter AvailabilityZoneId.
    * Modified cmdlet New-EC2Host: added parameter AvailabilityZoneId.
  * Amazon Supply Chain
    * Added cmdlet Get-SUPCHDataIntegrationEvent leveraging the GetDataIntegrationEvent service API.
    * Added cmdlet Get-SUPCHDataIntegrationEventList leveraging the ListDataIntegrationEvents service API.
    * Added cmdlet Get-SUPCHDataIntegrationFlowExecution leveraging the GetDataIntegrationFlowExecution service API.
    * Added cmdlet Get-SUPCHDataIntegrationFlowExecutionList leveraging the ListDataIntegrationFlowExecutions service API.
    * Added cmdlet Get-SUPCHDataLakeNamespace leveraging the GetDataLakeNamespace service API.
    * Added cmdlet Get-SUPCHDataLakeNamespaceList leveraging the ListDataLakeNamespaces service API.
    * Added cmdlet New-SUPCHDataLakeNamespace leveraging the CreateDataLakeNamespace service API.
    * Added cmdlet Remove-SUPCHDataLakeNamespace leveraging the DeleteDataLakeNamespace service API.
    * Added cmdlet Update-SUPCHDataLakeNamespace leveraging the UpdateDataLakeNamespace service API.
    * Modified cmdlet New-SUPCHDataIntegrationFlow: added parameters DedupeStrategy_Type and FieldPriority_Field.
    * Modified cmdlet New-SUPCHDataLakeDataset: added parameters PartitionSpec_Field and Schema_PrimaryKey.
    * Modified cmdlet Send-SUPCHDataIntegrationEvent: added parameters DatasetTarget_DatasetIdentifier and DatasetTarget_OperationType.
    * Modified cmdlet Update-SUPCHDataIntegrationFlow: added parameters DedupeStrategy_Type and FieldPriority_Field.

### 4.1.817 (2025-05-09 20:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1041.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter RetryConfig_MaxRetry.
    * Modified cmdlet Update-CWSYNCanary: added parameter RetryConfig_MaxRetry.
  * Amazon WorkSpaces
    * [Breaking Change] Modified cmdlet Edit-WKSWorkspaceCreationProperty: removed parameter WorkspaceCreationProperties_EnableWorkDoc.
    * [Breaking Change] Modified cmdlet Register-WKSWorkspaceDirectory: removed parameter EnableWorkDoc.

### 4.1.816 (2025-05-08 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1040.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Add-EC2NetworkInterface: added parameter EnaQueueCount.
    * Modified cmdlet Edit-EC2NetworkInterfaceAttribute: added parameters Attachment_DefaultEnaQueueCount and Attachment_EnaQueueCount.
  * Amazon Glue
    * Modified cmdlet New-GLUEIntegration: added parameter IntegrationConfig_RefreshInterval.

### 4.1.815 (2025-05-07 20:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1039.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Added cmdlet Start-CWSYNCanaryDryRun leveraging the StartCanaryDryRun service API.
    * Modified cmdlet Get-CWSYNCanary: added parameter DryRunId.
    * Modified cmdlet Get-CWSYNCanaryRun: added parameters DryRunId and RunType.
    * Modified cmdlet Update-CWSYNCanary: added parameter DryRunId.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Start-EC2NetworkInsightsAnalysis: added parameter FilterOutArn.
  * Amazon Elemental MediaLive
    * Modified cmdlet Update-EMLChannel: added parameters AnywhereSettings_ChannelPlacementGroupId and AnywhereSettings_ClusterId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameters UnifiedStudioSettings_DomainAccountId, UnifiedStudioSettings_DomainId, UnifiedStudioSettings_DomainRegion, UnifiedStudioSettings_EnvironmentId, UnifiedStudioSettings_ProjectId, UnifiedStudioSettings_ProjectS3Path and UnifiedStudioSettings_StudioWebPortalAccess.
    * Modified cmdlet New-SMSpace: added parameter SpaceSettings_SpaceManagedResource.
    * Modified cmdlet Update-SMDomain: added parameters UnifiedStudioSettings_DomainAccountId, UnifiedStudioSettings_DomainId, UnifiedStudioSettings_DomainRegion, UnifiedStudioSettings_EnvironmentId, UnifiedStudioSettings_ProjectId, UnifiedStudioSettings_ProjectS3Path and UnifiedStudioSettings_StudioWebPortalAccess.
    * Modified cmdlet Update-SMSpace: added parameter SpaceSettings_SpaceManagedResource.

### 4.1.814 (2025-05-06 20:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1038.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2ReplaceRootVolumeTask: added parameter VolumeInitializationRate.
    * Modified cmdlet New-EC2Volume: added parameter VolumeInitializationRate.

### 4.1.813 (2025-05-05 20:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1037.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Add-DZPolicyGrant: added parameter UseAssetType_DomainUnitId.
  * Amazon Device Farm
    * Modified cmdlet Get-DFDevicePoolCompatibility: added parameter ProjectArn.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2OutpostLag leveraging the DescribeOutpostLags service API.
    * Added cmdlet Get-EC2ServiceLinkVirtualInterface leveraging the DescribeServiceLinkVirtualInterfaces service API.
    * Added cmdlet New-EC2LocalGatewayVirtualInterface leveraging the CreateLocalGatewayVirtualInterface service API.
    * Added cmdlet New-EC2LocalGatewayVirtualInterfaceGroup leveraging the CreateLocalGatewayVirtualInterfaceGroup service API.
    * Added cmdlet Remove-EC2LocalGatewayVirtualInterface leveraging the DeleteLocalGatewayVirtualInterface service API.
    * Added cmdlet Remove-EC2LocalGatewayVirtualInterfaceGroup leveraging the DeleteLocalGatewayVirtualInterfaceGroup service API.

### 4.1.812 (2025-05-02 20:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1036.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.811 (2025-05-01 20:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1035.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SageMaker Service
    * Modified cmdlet Update-SMClusterSoftware: added parameters DeploymentConfig_AutoRollbackConfiguration, DeploymentConfig_WaitIntervalInSecond, InstanceGroup, MaximumBatchSize_Type, MaximumBatchSize_Value, RollbackMaximumBatchSize_Type and RollbackMaximumBatchSize_Value.
  * Amazon Verified Permissions
    * Added cmdlet Add-AVPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AVPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-AVPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Get-AVPPolicyStore: added parameter Tag.
    * Modified cmdlet New-AVPPolicyStore: added parameter Tag.

### 4.1.810 (2025-04-30 20:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1034.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameter CustomerManaged_TagPropagationMode.
    * Modified cmdlet New-ADCWorker: added parameter Tag.
    * Modified cmdlet Update-ADCFleet: added parameter CustomerManaged_TagPropagationMode.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARInlineAgent: added parameters AgentName, Executor_Lambda and OrchestrationType.
  * Amazon Clean Rooms Service
    * Modified cmdlet Start-CRSProtectedQuery: added parameter Distribute_Location.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2Ipam: added parameter MeteredAccount.
    * Modified cmdlet New-EC2Ipam: added parameter MeteredAccount.

### 4.1.809 (2025-04-29 22:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1033.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASCase: added parameter PerformedBy_CustomEntity.
    * Modified cmdlet New-CCASRelatedItem: added parameter PerformedBy_CustomEntity.
    * Modified cmdlet Update-CCASCase: added parameter PerformedBy_CustomEntity.
  * Amazon Kinesis
    * Added cmdlet Add-KINResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KINResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-KINResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Register-KINStreamConsumer: added parameter Tag.
  * Amazon QBusiness
    * Added cmdlet New-QBUSAnonymousWebExperienceUrl leveraging the CreateAnonymousWebExperienceUrl service API.
  * Amazon SSM-GUIConnect. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSMG and can be listed using the command 'Get-AWSCmdletName -Service SSMG'.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMAccessToken leveraging the GetAccessToken service API.
    * Added cmdlet Start-SSMAccessRequest leveraging the StartAccessRequest service API.

### 4.1.808 (2025-04-28 20:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1032.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Certificate Manager
    * Modified cmdlet Get-ACMCertificateList: added parameter Includes_ManagedBy.
    * Modified cmdlet New-ACMCertificate: added parameter ManagedBy.
  * Amazon CloudFront
    * Added cmdlet Add-CFDistributionTenantWebACL leveraging the AssociateDistributionTenantWebACL service API.
    * Added cmdlet Add-CFDistributionWebACL leveraging the AssociateDistributionWebACL service API.
    * Added cmdlet Get-CFConnectionGroup leveraging the GetConnectionGroup service API.
    * Added cmdlet Get-CFConnectionGroupByRoutingEndpoint leveraging the GetConnectionGroupByRoutingEndpoint service API.
    * Added cmdlet Get-CFConnectionGroupList leveraging the ListConnectionGroups service API.
    * Added cmdlet Get-CFDistributionsByConnectionMode leveraging the ListDistributionsByConnectionMode service API.
    * Added cmdlet Get-CFDistributionTenant leveraging the GetDistributionTenant service API.
    * Added cmdlet Get-CFDistributionTenantByDomain leveraging the GetDistributionTenantByDomain service API.
    * Added cmdlet Get-CFDistributionTenantList leveraging the ListDistributionTenants service API.
    * Added cmdlet Get-CFDistributionTenantsByCustomization leveraging the ListDistributionTenantsByCustomization service API.
    * Added cmdlet Get-CFDomainConflict leveraging the ListDomainConflicts service API.
    * Added cmdlet Get-CFInvalidationForDistributionTenant leveraging the GetInvalidationForDistributionTenant service API.
    * Added cmdlet Get-CFInvalidationsForDistributionTenant leveraging the ListInvalidationsForDistributionTenant service API.
    * Added cmdlet Get-CFManagedCertificateDetail leveraging the GetManagedCertificateDetails service API.
    * Added cmdlet New-CFConnectionGroup leveraging the CreateConnectionGroup service API.
    * Added cmdlet New-CFDistributionTenant leveraging the CreateDistributionTenant service API.
    * Added cmdlet New-CFInvalidationForDistributionTenant leveraging the CreateInvalidationForDistributionTenant service API.
    * Added cmdlet Remove-CFConnectionGroup leveraging the DeleteConnectionGroup service API.
    * Added cmdlet Remove-CFDistributionTenant leveraging the DeleteDistributionTenant service API.
    * Added cmdlet Remove-CFDistributionTenantWebACL leveraging the DisassociateDistributionTenantWebACL service API.
    * Added cmdlet Remove-CFDistributionWebACL leveraging the DisassociateDistributionWebACL service API.
    * Added cmdlet Test-CFDnsConfiguration leveraging the VerifyDnsConfiguration service API.
    * Added cmdlet Update-CFConnectionGroup leveraging the UpdateConnectionGroup service API.
    * Added cmdlet Update-CFDistributionTenant leveraging the UpdateDistributionTenant service API.
    * Added cmdlet Update-CFDomainAssociation leveraging the UpdateDomainAssociation service API.
    * Modified cmdlet New-CFDistribution: added parameters DistributionConfig_ConnectionMode and TenantConfig_ParameterDefinition.
    * Modified cmdlet New-CFDistributionWithTag: added parameters DistributionConfig_ConnectionMode and TenantConfig_ParameterDefinition.
    * Modified cmdlet Update-CFDistribution: added parameters DistributionConfig_ConnectionMode and TenantConfig_ParameterDefinition.

### 4.1.807 (2025-04-25 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1031.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.806 (2025-04-24 23:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1030.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Modified cmdlet New-ASYNChannelNamespace: added parameters OnPublish_Behavior, OnPublish_Integration_DataSourceName, OnPublish_LambdaConfig_InvokeType, OnSubscribe_Behavior, OnSubscribe_Integration_DataSourceName and OnSubscribe_LambdaConfig_InvokeType.
    * Modified cmdlet Update-ASYNChannelNamespace: added parameters OnPublish_Behavior, OnPublish_Integration_DataSourceName, OnPublish_LambdaConfig_InvokeType, OnSubscribe_Behavior, OnSubscribe_Integration_DataSourceName and OnSubscribe_LambdaConfig_InvokeType.
  * Amazon Data Automation for Amazon Bedrock
    * Modified cmdlet New-BDADataAutomationProject: added parameters ModalityRouting_Jpeg, ModalityRouting_Mov, ModalityRouting_Mp4, ModalityRouting_Png, OverrideConfiguration_Audio_ModalityProcessing_State, OverrideConfiguration_Document_ModalityProcessing_State, OverrideConfiguration_Image_ModalityProcessing_State and OverrideConfiguration_Video_ModalityProcessing_State.
    * Modified cmdlet Update-BDADataAutomationProject: added parameters ModalityRouting_Jpeg, ModalityRouting_Mov, ModalityRouting_Mp4, ModalityRouting_Png, OverrideConfiguration_Audio_ModalityProcessing_State, OverrideConfiguration_Document_ModalityProcessing_State, OverrideConfiguration_Image_ModalityProcessing_State and OverrideConfiguration_Video_ModalityProcessing_State.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSTenantDatabase: added parameters ManageMasterUserPassword, MasterUserSecretKmsKeyId and RotateMasterUserPassword.
    * Modified cmdlet New-RDSTenantDatabase: added parameters ManageMasterUserPassword and MasterUserSecretKmsKeyId.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameters ManageMasterUserPassword and MasterUserSecretKmsKeyId.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameters ManageMasterUserPassword and MasterUserSecretKmsKeyId.

### 4.1.805 (2025-04-23 20:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1029.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBFleet: added parameter ComputeConfiguration_InstanceType.
    * Modified cmdlet New-CBProject: added parameter ComputeConfiguration_InstanceType.
    * Modified cmdlet Update-CBFleet: added parameter ComputeConfiguration_InstanceType.
    * Modified cmdlet Update-CBProject: added parameter ComputeConfiguration_InstanceType.
  * Amazon EC2 Container Service
    * Added cmdlet Stop-ECSServiceDeployment leveraging the StopServiceDeployment service API.

### 4.1.804 (2025-04-22 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1028.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Account
    * Added cmdlet Get-ACCTAccountInformation leveraging the GetAccountInformation service API.
    * Added cmdlet Write-ACCTAccountName leveraging the PutAccountName service API.
  * Amazon Cognito Identity Provider
    * Added cmdlet Get-CGIPTokensFromRefreshToken leveraging the GetTokensFromRefreshToken service API.
    * Modified cmdlet New-CGIPUserPoolClient: added parameters RefreshTokenRotation_Feature and RefreshTokenRotation_RetryGracePeriodSecond.
    * Modified cmdlet Update-CGIPUserPoolClient: added parameters RefreshTokenRotation_Feature and RefreshTokenRotation_RetryGracePeriodSecond.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameter ClientRouteEnforcementOptions_Enforced.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter ClientRouteEnforcementOptions_Enforced.
  * Amazon MQ
    * Added cmdlet Remove-MQConfiguration leveraging the DeleteConfiguration service API.
  * Amazon Redshift Serverless
    * Added cmdlet Get-RSSReservation leveraging the GetReservation service API.
    * Added cmdlet Get-RSSReservationList leveraging the ListReservations service API.
    * Added cmdlet Get-RSSReservationOffering leveraging the GetReservationOffering service API.
    * Added cmdlet Get-RSSReservationOfferingList leveraging the ListReservationOfferings service API.
    * Added cmdlet New-RSSReservation leveraging the CreateReservation service API.

### 4.1.803 (2025-04-21 20:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1027.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Budgets
    * Modified cmdlet Get-BGTBudget: added parameter ShowFilterExpression.
    * Modified cmdlet Get-BGTBudgetList: added parameter ShowFilterExpression.
    * Modified cmdlet New-BGTBudget: added parameters Budget_FilterExpression and Budget_Metric.
    * Modified cmdlet Update-BGTBudget: added parameters NewBudget_FilterExpression and NewBudget_Metric.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Get-EMTPrefetchScheduleList: added parameter ScheduleType.
    * Modified cmdlet New-EMTPrefetchSchedule: added parameters RecurringConsumption_AvailMatchingCriterion, RecurringConsumption_RetrievedAdExpirationSecond, RecurringPrefetchConfiguration_EndTime, RecurringPrefetchConfiguration_StartTime, RecurringRetrieval_DelayAfterAvailEndSecond, RecurringRetrieval_DynamicVariable, RecurringRetrieval_TrafficShapingType, RecurringTrafficShaping_WindowDurationSeconds, Retrieval_TrafficShapingType, ScheduleType and TrafficShaping_WindowDurationSeconds.
  * Amazon QBusiness
    * Added cmdlet Get-QBUSDocumentAccess leveraging the CheckDocumentAccess service API.

### 4.1.802 (2025-04-18 20:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1026.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Q Connect
    * Modified cmdlet Get-QCRecommendation: added parameter NextChunkToken.
    * Modified cmdlet Send-QCMessage: added parameter Configuration_GenerateFillerMessage.
  * Amazon Service Quotas
    * Modified cmdlet Request-SQServiceQuotaIncrease: added parameter SupportCaseAllowed.

### 4.1.801 (2025-04-17 20:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1025.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet New-BDREvaluationJob: added parameters CustomMetricConfig_CustomMetric and EvaluationConfig_Automated_CustomMetricConfig_EvaluatorModelConfig_BedrockEvaluatorModels.
  * Amazon MemoryDB
    * Modified cmdlet New-MDBCluster: added parameters IpDiscovery and NetworkType.
    * Modified cmdlet Update-MDBCluster: added parameter IpDiscovery.
  * Amazon Omics
    * Added cmdlet Get-OMICSWorkflowVersion leveraging the GetWorkflowVersion service API.
    * Added cmdlet Get-OMICSWorkflowVersionList leveraging the ListWorkflowVersions service API.
    * Added cmdlet New-OMICSWorkflowVersion leveraging the CreateWorkflowVersion service API.
    * Added cmdlet Remove-OMICSWorkflowVersion leveraging the DeleteWorkflowVersion service API.
    * Added cmdlet Update-OMICSWorkflowVersion leveraging the UpdateWorkflowVersion service API.
    * Modified cmdlet New-OMICSWorkflow: added parameter StorageType.
    * Modified cmdlet Start-OMICSRun: added parameter WorkflowVersionName.
    * Modified cmdlet Update-OMICSWorkflow: added parameters StorageCapacity and StorageType.
  * Amazon Prometheus Service
    * Added cmdlet Get-PROMWorkspaceConfiguration leveraging the DescribeWorkspaceConfiguration service API.
    * Added cmdlet Update-PROMWorkspaceConfiguration leveraging the UpdateWorkspaceConfiguration service API.

### 4.1.800 (2025-04-16 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1024.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Aurora DSQL
    * Added cmdlet Get-DSQLVpcEndpointServiceName leveraging the GetVpcEndpointServiceName service API.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASRelatedItem: added parameters SlaInputConfiguration_FieldId, SlaInputConfiguration_Name, SlaInputConfiguration_TargetFieldValue, SlaInputConfiguration_TargetSlaMinute and SlaInputConfiguration_Type.
  * Amazon EventBridge
    * Modified cmdlet New-EVBConnection: added parameter KmsKeyIdentifier.
    * Modified cmdlet Update-EVBConnection: added parameter KmsKeyIdentifier.
  * Amazon Resource Groups
    * Modified cmdlet Start-RGTagSyncTask: added parameter ResourceQuery.
  * Amazon S3 Tables
    * Added cmdlet Get-S3TTableBucketEncryption leveraging the GetTableBucketEncryption service API.
    * Added cmdlet Get-S3TTableEncryption leveraging the GetTableEncryption service API.
    * Added cmdlet Remove-S3TTableBucketEncryption leveraging the DeleteTableBucketEncryption service API.
    * Added cmdlet Write-S3TTableBucketEncryption leveraging the PutTableBucketEncryption service API.
    * Modified cmdlet New-S3TTable: added parameters EncryptionConfiguration_KmsKeyArn and EncryptionConfiguration_SseAlgorithm.
    * Modified cmdlet New-S3TTableBucket: added parameters EncryptionConfiguration_KmsKeyArn and EncryptionConfiguration_SseAlgorithm.

### 4.1.799 (2025-04-14 20:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1023.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Tax Settings
    * Modified cmdlet Write-TSATaxRegistration: added parameters IndonesiaAdditionalInfo_DecisionNumber, IndonesiaAdditionalInfo_PpnExceptionDesignationCode and IndonesiaAdditionalInfo_TaxRegistrationNumberType.
    * Modified cmdlet Write-TSATaxRegistrationBatch: added parameters IndonesiaAdditionalInfo_DecisionNumber, IndonesiaAdditionalInfo_PpnExceptionDesignationCode and IndonesiaAdditionalInfo_TaxRegistrationNumberType.

### 4.1.798 (2025-04-11 20:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1022.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Verified Permissions
    * Modified cmdlet New-AVPPolicyStore: added parameter DeletionProtection.
    * Modified cmdlet Update-AVPPolicyStore: added parameter DeletionProtection.

### 4.1.797 (2025-04-10 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1021.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECCacheCluster: added parameters ScaleConfig_ScaleIntervalMinute and ScaleConfig_ScalePercentage.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLSdiSource: added parameter PassThru.
    * Modified cmdlet Update-EMLInputDevice: added parameters HdDeviceSettings_InputResolution and UhdDeviceSettings_InputResolution.
  * Amazon M2
    * Added cmdlet Get-AMMDataSetExportHistoryList leveraging the ListDataSetExportHistory service API.
    * Added cmdlet Get-AMMDataSetExportTask leveraging the GetDataSetExportTask service API.
    * Added cmdlet New-AMMDataSetExportTask leveraging the CreateDataSetExportTask service API.
    * Modified cmdlet Start-AMMBatchJob: added parameters JobStepRestartMarker_Skip and JobStepRestartMarker_StepCheckpoint.
  * Amazon QBusiness
    * Modified cmdlet Update-QBUSChatControlsConfiguration: added parameter HallucinationReductionConfiguration_HallucinationReductionControl.
  * Amazon QuickSight
    * Modified cmdlet New-QSAnalysis: added parameter HighlightOperation_Trigger.
    * Modified cmdlet New-QSDashboard: added parameter HighlightOperation_Trigger.
    * Modified cmdlet New-QSTemplate: added parameter HighlightOperation_Trigger.
    * Modified cmdlet Update-QSAnalysis: added parameter HighlightOperation_Trigger.
    * Modified cmdlet Update-QSDashboard: added parameter HighlightOperation_Trigger.
    * Modified cmdlet Update-QSTemplate: added parameter HighlightOperation_Trigger.

### 4.1.796 (2025-04-09 23:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1020.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Ground Station
    * Modified cmdlet Register-GSAgent: added parameter Tag.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameter SftpConfig_MaxConcurrentConnection.
    * Modified cmdlet Update-TFRConnector: added parameter SftpConfig_MaxConcurrentConnection.

### 4.1.795 (2025-04-08 21:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1019.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT FleetWise
    * Modified cmdlet Update-IFWVehicle: added parameter StateTemplatesToUpdate.
  * Amazon Tax Settings
    * Modified cmdlet Write-TSATaxRegistration: added parameters UzbekistanAdditionalInfo_TaxRegistrationNumberType and UzbekistanAdditionalInfo_VatRegistrationNumber.
    * Modified cmdlet Write-TSATaxRegistrationBatch: added parameters UzbekistanAdditionalInfo_TaxRegistrationNumberType and UzbekistanAdditionalInfo_VatRegistrationNumber.

### 4.1.794 (2025-04-07 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1018.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Runtime
    * Modified cmdlet Invoke-BDRRGuardrail: added parameter OutputScope.
  * Amazon CodeBuild
    * Added cmdlet Get-CBCommandExecutionBatch leveraging the BatchGetCommandExecutions service API.
    * Added cmdlet Get-CBCommandExecutionListForSandbox leveraging the ListCommandExecutionsForSandbox service API.
    * Added cmdlet Get-CBSandboxBatch leveraging the BatchGetSandboxes service API.
    * Added cmdlet Get-CBSandboxIdList leveraging the ListSandboxes service API.
    * Added cmdlet Get-CBSandboxIdListForProject leveraging the ListSandboxesForProject service API.
    * Added cmdlet Start-CBCommandExecution leveraging the StartCommandExecution service API.
    * Added cmdlet Start-CBSandbox leveraging the StartSandbox service API.
    * Added cmdlet Start-CBSandboxConnection leveraging the StartSandboxConnection service API.
    * Added cmdlet Stop-CBSandbox leveraging the StopSandbox service API.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLSdiSource leveraging the DescribeSdiSource service API.
    * Added cmdlet Get-EMLSdiSourceList leveraging the ListSdiSources service API.
    * Added cmdlet New-EMLSdiSource leveraging the CreateSdiSource service API.
    * Added cmdlet Remove-EMLSdiSource leveraging the DeleteSdiSource service API.
    * Added cmdlet Update-EMLSdiSource leveraging the UpdateSdiSource service API.
    * Modified cmdlet New-EMLInput: added parameter SdiSource.
    * Modified cmdlet Update-EMLInput: added parameter SdiSource.
    * Modified cmdlet Update-EMLNode: added parameter SdiSourceMapping.
  * Amazon Personalize
    * Modified cmdlet New-PERSSolution: added parameter EventsConfig_EventParametersList.
    * Modified cmdlet Update-PERSSolution: added parameter EventsConfig_EventParametersList.
  * Amazon Transfer for SFTP
    * Added cmdlet Start-TFRRemoteDelete leveraging the StartRemoteDelete service API.
    * Added cmdlet Start-TFRRemoteMove leveraging the StartRemoteMove service API.

### 4.1.793 (2025-04-04 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1017.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EventBridge
    * Modified cmdlet New-EVBArchive: added parameter KmsKeyIdentifier.
    * Modified cmdlet Update-EVBArchive: added parameter KmsKeyIdentifier.

### 4.1.792 (2025-04-03 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1016.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameters FieldMapping_CustomMetadataField and MongoDbAtlasConfiguration_TextIndexName.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters FieldMapping_CustomMetadataField and MongoDbAtlasConfiguration_TextIndexName.
  * Amazon SES Mail Manager
    * Modified cmdlet New-MMGRIngressPoint: added parameters PrivateNetworkConfiguration_VpcEndpointId and PublicNetworkConfiguration_IpType.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2DeliverabilityTestReport: added parameters Simple_Attachment and Template_Attachment.
    * Modified cmdlet Send-SES2BulkEmail: added parameter Template_Attachment.
    * Modified cmdlet Send-SES2Email: added parameters Simple_Attachment and Template_Attachment.

### 4.1.791 (2025-04-03 03:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1015.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.790 (2025-04-02 21:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1015.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Application Signals
    * Modified cmdlet Get-CWASServiceLevelObjectiveList: added parameters DependencyConfig_DependencyKeyAttribute, DependencyConfig_DependencyOperationName and MetricSourceType.
    * Modified cmdlet New-CWASServiceLevelObjective: added parameters RequestBasedSliConfig_RequestBasedSliMetricConfig_DependencyConfig_DependencyKeyAttributes, RequestBasedSliConfig_RequestBasedSliMetricConfig_DependencyConfig_DependencyOperationName, SliConfig_SliMetricConfig_DependencyConfig_DependencyKeyAttributes and SliConfig_SliMetricConfig_DependencyConfig_DependencyOperationName.
    * Modified cmdlet Update-CWASServiceLevelObjective: added parameters RequestBasedSliConfig_RequestBasedSliMetricConfig_DependencyConfig_DependencyKeyAttributes, RequestBasedSliConfig_RequestBasedSliMetricConfig_DependencyConfig_DependencyOperationName, SliConfig_SliMetricConfig_DependencyConfig_DependencyKeyAttributes and SliConfig_SliMetricConfig_DependencyConfig_DependencyOperationName.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLInput: added parameter Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup.
    * Modified cmdlet Update-EMLInput: added parameter Smpte2110ReceiverGroupSettings_Smpte2110ReceiverGroup.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2Bot: added parameter ErrorLogSettings_Enabled.
    * Modified cmdlet New-LMBV2Intent: added parameter QInConnectAssistantConfiguration_AssistantArn.
    * Modified cmdlet Start-LMBV2Import: added parameter ErrorLogSettings_Enabled.
    * Modified cmdlet Update-LMBV2Bot: added parameter ErrorLogSettings_Enabled.
    * Modified cmdlet Update-LMBV2Intent: added parameter QInConnectAssistantConfiguration_AssistantArn.

### 4.1.789 (2025-04-01 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1014.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Modified cmdlet Update-CRSCollaboration: added parameter AnalyticsEngine.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMNotebookInstanceLifecycleConfig: added parameter Tag.

### 4.1.788 (2025-03-31 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1013.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2RouteServerPropagation leveraging the DisableRouteServerPropagation service API.
    * Added cmdlet Edit-EC2RouteServer leveraging the ModifyRouteServer service API.
    * Added cmdlet Enable-EC2RouteServerPropagation leveraging the EnableRouteServerPropagation service API.
    * Added cmdlet Get-EC2RouteServer leveraging the DescribeRouteServers service API.
    * Added cmdlet Get-EC2RouteServerAssociation leveraging the GetRouteServerAssociations service API.
    * Added cmdlet Get-EC2RouteServerEndpoint leveraging the DescribeRouteServerEndpoints service API.
    * Added cmdlet Get-EC2RouteServerPeer leveraging the DescribeRouteServerPeers service API.
    * Added cmdlet Get-EC2RouteServerPropagation leveraging the GetRouteServerPropagations service API.
    * Added cmdlet Get-EC2RouteServerRoutingDatabase leveraging the GetRouteServerRoutingDatabase service API.
    * Added cmdlet New-EC2RouteServer leveraging the CreateRouteServer service API.
    * Added cmdlet New-EC2RouteServerEndpoint leveraging the CreateRouteServerEndpoint service API.
    * Added cmdlet New-EC2RouteServerPeer leveraging the CreateRouteServerPeer service API.
    * Added cmdlet Register-EC2RouteServer leveraging the AssociateRouteServer service API.
    * Added cmdlet Remove-EC2RouteServer leveraging the DeleteRouteServer service API.
    * Added cmdlet Remove-EC2RouteServerEndpoint leveraging the DeleteRouteServerEndpoint service API.
    * Added cmdlet Remove-EC2RouteServerPeer leveraging the DeleteRouteServerPeer service API.
    * Added cmdlet Unregister-EC2RouteServer leveraging the DisassociateRouteServer service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet Update-EKSClusterConfig: added parameters RemoteNetworkConfig_RemoteNodeNetwork and RemoteNetworkConfig_RemotePodNetwork.
  * Amazon Outposts
    * Modified cmdlet Get-OUTPOutpostSupportedInstanceType: added parameter AssetId.
    * Modified cmdlet Start-OUTPCapacityTask: added parameter AssetId.
  * Amazon S3 Control
    * Added cmdlet Get-S3CAccessPointScope leveraging the GetAccessPointScope service API.
    * Added cmdlet Get-S3CAccessPointsForDirectoryBucketList leveraging the ListAccessPointsForDirectoryBuckets service API.
    * Added cmdlet Remove-S3CAccessPointScope leveraging the DeleteAccessPointScope service API.
    * Added cmdlet Write-S3CAccessPointScope leveraging the PutAccessPointScope service API.
    * Modified cmdlet New-S3CAccessPoint: added parameters Scope_Permission and Scope_Prefix.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRWebApp: added parameter WebAppEndpointPolicy.

### 4.1.787 (2025-03-28 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1012.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter EndpointConfiguration_IpAddressType.
    * Modified cmdlet New-AGRestApi: added parameter EndpointConfiguration_IpAddressType.
  * Amazon API Gateway V2
    * Modified cmdlet New-AG2Api: added parameter IpAddressType.
    * Modified cmdlet Update-AG2Api: added parameter IpAddressType.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter Cache_CacheNamespace.
    * Modified cmdlet Start-CBBatch: added parameter CacheOverride_CacheNamespace.
    * Modified cmdlet Start-CBBuild: added parameter CacheOverride_CacheNamespace.
    * Modified cmdlet Update-CBProject: added parameter Cache_CacheNamespace.
  * Amazon Payment Cryptography Control Plane
    * Modified cmdlet Export-PAYCCKey: added parameters DerivationData_SharedInformation, DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier, DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm, DiffieHellmanTr31KeyBlock_KeyDerivationFunction, DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm, DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier, DiffieHellmanTr31KeyBlock_PublicKeyCertificate, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap, KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion and KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks.
    * Modified cmdlet Import-PAYCCKey: added parameters DerivationData_SharedInformation, DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier, DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm, DiffieHellmanTr31KeyBlock_KeyDerivationFunction, DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm, DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier, DiffieHellmanTr31KeyBlock_PublicKeyCertificate and DiffieHellmanTr31KeyBlock_WrappedKeyBlock.
    * Modified cmdlet New-PAYCCKey: added parameter DeriveKeyUsage.
  * Amazon QuickSight
    * Modified cmdlet Initialize-QSEmbedUrlForRegisteredUserWithIdentity: added parameters DataQnA_Enabled, DataStories_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_Schedules_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_Enabled and GenerativeAuthoring_Enabled.
    * Modified cmdlet New-QSAnalysis: added parameters Options_ExcludedDataSetArn and Options_QBusinessInsightsStatus.
    * Modified cmdlet New-QSDashboard: added parameters DataQAEnabledOption_AvailabilityStatus, Options_ExcludedDataSetArn and Options_QBusinessInsightsStatus.
    * Modified cmdlet New-QSDataSet: added parameter UseAs.
    * Modified cmdlet New-QSDataSource: added parameter OracleParameters_UseServiceName.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameters DataQnA_Enabled, DataStories_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_RecentSnapshots_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_Schedules_Enabled, ExperienceConfiguration_Dashboard_FeatureConfigurations_ThresholdAlerts_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_AmazonQInQuickSight_ExecutiveSummary_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_RecentSnapshots_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_Schedules_Enabled, ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_ThresholdAlerts_Enabled and GenerativeAuthoring_Enabled.
    * Modified cmdlet New-QSTemplate: added parameters Options_ExcludedDataSetArn and Options_QBusinessInsightsStatus.
    * Modified cmdlet Update-QSAnalysis: added parameters Options_ExcludedDataSetArn and Options_QBusinessInsightsStatus.
    * Modified cmdlet Update-QSDashboard: added parameters DataQAEnabledOption_AvailabilityStatus, Options_ExcludedDataSetArn and Options_QBusinessInsightsStatus.
    * Modified cmdlet Update-QSDataSource: added parameter OracleParameters_UseServiceName.
    * Modified cmdlet Update-QSTemplate: added parameters Options_ExcludedDataSetArn and Options_QBusinessInsightsStatus.
    * Modified cmdlet Write-QSDataSetRefreshProperty: added parameter EmailAlert_AlertStatus.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMTransformJob: added parameter TransformResources_TransformAmiVersion.

### 4.1.786 (2025-03-27 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1011.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter ContainerProperties_EnableExecuteCommand.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNResourceScanList: added parameter ScanTypeFilter.
    * Modified cmdlet Start-CFNResourceScan: added parameter ScanFilter.
  * Amazon Pricing Calculator
    * Modified cmdlet Update-BCMPCPreference: added parameter StandaloneAccountRateTypeSelection.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMApp: added parameter RecoveryMode.

### 4.1.785 (2025-03-26 21:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1010.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Direct Connect
    * Modified cmdlet New-DCGateway: added parameter Tag.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Add-EMTLogsForPlaybackConfiguration: added parameters AdsInteractionLog_ExcludeEventType, AdsInteractionLog_PublishOptInEventType and ManifestServiceInteractionLog_ExcludeEventType.
  * Amazon WAF V2
    * Modified cmdlet Get-WAF2WebACL: added parameter ARN.

### 4.1.784 (2025-03-25 22:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1009.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameters OpensearchManagedClusterConfiguration_DomainArn, OpensearchManagedClusterConfiguration_DomainEndpoint, OpensearchManagedClusterConfiguration_VectorIndexName, StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField, StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField and StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters OpensearchManagedClusterConfiguration_DomainArn, OpensearchManagedClusterConfiguration_DomainEndpoint, OpensearchManagedClusterConfiguration_VectorIndexName, StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_MetadataField, StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_TextField and StorageConfiguration_OpensearchManagedClusterConfiguration_FieldMapping_VectorField.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet Update-EKSClusterVersion: added parameter ForceUpdate.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMPartnerApp: added parameter KmsKeyId.

### 4.1.783 (2025-03-24 20:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1008.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Systems Manager
    * Modified cmdlet Get-SSMDeployablePatchSnapshotForInstance: added parameter BaselineOverride_AvailableSecurityUpdatesComplianceStatus.
    * Modified cmdlet New-SSMPatchBaseline: added parameter AvailableSecurityUpdatesComplianceStatus.
    * Modified cmdlet Update-SSMPatchBaseline: added parameter AvailableSecurityUpdatesComplianceStatus.

### 4.1.782 (2025-03-21 21:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1007.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet New-DZDomain: added parameter SingleSignOn_IdcInstanceArn.
    * Modified cmdlet Update-DZDomain: added parameter SingleSignOn_IdcInstanceArn.
  * Amazon Route53 Recovery Control Config
    * Added cmdlet Update-R53RCCluster leveraging the UpdateCluster service API.
    * Modified cmdlet New-R53RCCluster: added parameter NetworkType.

### 4.1.781 (2025-03-20 20:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1006.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Network Firewall
    * Added cmdlet Get-NWFWFlowOperation leveraging the DescribeFlowOperation service API.
    * Added cmdlet Get-NWFWFlowOperationList leveraging the ListFlowOperations service API.
    * Added cmdlet Get-NWFWFlowOperationResultList leveraging the ListFlowOperationResults service API.
    * Added cmdlet Start-NWFWFlowCapture leveraging the StartFlowCapture service API.
    * Added cmdlet Start-NWFWFlowFlush leveraging the StartFlowFlush service API.

### 4.1.780 (2025-03-19 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1005.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNFlow: added parameters FlowSize, NdiConfig_MachineName, NdiConfig_NdiDiscoveryServer and NdiConfig_NdiState.
    * Modified cmdlet Update-EMCNFlow: added parameters NdiConfig_MachineName, NdiConfig_NdiDiscoveryServer and NdiConfig_NdiState.
    * Modified cmdlet Update-EMCNFlowOutput: added parameters NdiProgramName and NdiSpeedHqQuality.

### 4.1.779 (2025-03-18 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1004.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Modified cmdlet New-ASYNDomainName: added parameter Tag.
  * Amazon Clean Rooms Service
    * Added cmdlet Get-CRSProtectedJob leveraging the GetProtectedJob service API.
    * Added cmdlet Get-CRSProtectedJobList leveraging the ListProtectedJobs service API.
    * Added cmdlet Start-CRSProtectedJob leveraging the StartProtectedJob service API.
    * Added cmdlet Update-CRSProtectedJob leveraging the UpdateProtectedJob service API.
    * Modified cmdlet New-CRSAnalysisTemplate: added parameters Artifacts_AdditionalArtifact, Artifacts_RoleArn, Location_Bucket, Location_Key and Schema_ReferencedTable.
    * Modified cmdlet New-CRSCollaboration: added parameters JobCompute_IsResponsible and JobLogStatus.
    * Modified cmdlet New-CRSConfiguredTable: added parameter SelectedAnalysisMethod.
    * Modified cmdlet New-CRSMembership: added parameters DefaultJobResultConfiguration_OutputConfiguration_S3_Bucket, DefaultJobResultConfiguration_OutputConfiguration_S3_KeyPrefix, DefaultJobResultConfiguration_RoleArn, JobCompute_IsResponsible and JobLogStatus.
    * Modified cmdlet Update-CRSConfiguredTable: added parameters AnalysisMethod and SelectedAnalysisMethod.
    * Modified cmdlet Update-CRSMembership: added parameters DefaultJobResultConfiguration_OutputConfiguration_S3_Bucket, DefaultJobResultConfiguration_OutputConfiguration_S3_KeyPrefix, DefaultJobResultConfiguration_RoleArn and JobLogStatus.

### 4.1.778 (2025-03-17 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1003.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Application Signals
    * Added cmdlet Get-CWASServiceLevelObjectiveExclusionWindowList leveraging the ListServiceLevelObjectiveExclusionWindows service API.
    * Added cmdlet Update-CWASUpdateExclusionWindow leveraging the BatchUpdateExclusionWindows service API.
  * Amazon CloudWatch RUM
    * Modified cmdlet New-CWRUMAppMonitor: added parameters DomainList, JavaScriptSourceMaps_S3Uri and JavaScriptSourceMaps_Status.
    * Modified cmdlet Update-CWRUMAppMonitor: added parameters DomainList, JavaScriptSourceMaps_S3Uri and JavaScriptSourceMaps_Status.
  * Amazon Location Service Maps V2
    * Modified cmdlet Get-GEOMStaticMap: added parameters ColorScheme, CropLabel, LabelSize, Language, PointsOfInterest and PoliticalView.

### 4.1.777 (2025-03-14 20:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1002.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet New-GLUECatalog: added parameter CatalogInput_AllowFullTableExternalDataAccess.
    * Modified cmdlet Update-GLUECatalog: added parameter CatalogInput_AllowFullTableExternalDataAccess.
  * Amazon Lake Formation
    * Modified cmdlet Grant-LKFPermission: added parameter Condition_Expression.
    * Modified cmdlet New-LKFLakeFormationOptIn: added parameter Condition_Expression.
    * Modified cmdlet Register-LKFResource: added parameter WithPrivilegedAccess.
    * Modified cmdlet Remove-LKFLakeFormationOptIn: added parameter Condition_Expression.
    * Modified cmdlet Revoke-LKFPermission: added parameter Condition_Expression.

### 4.1.776 (2025-03-14 00:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1001.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet New-AMPBranch: added parameter EnableSkewProtection.
    * Modified cmdlet Update-AMPBranch: added parameter EnableSkewProtection.
  * Amazon DataZone
    * Modified cmdlet Update-DZEnvironment: added parameters BlueprintVersion and UserParameter.
    * Modified cmdlet Update-DZProject: added parameters ProjectProfileVersion and UserParameter.
  * Amazon Elemental MediaPackage v2
    * Added cmdlet Reset-MPV2ChannelState leveraging the ResetChannelState service API.
    * Added cmdlet Reset-MPV2OriginEndpointState leveraging the ResetOriginEndpointState service API.
  * Amazon Interactive Video Service RealTime
    * Modified cmdlet New-IVSRTStage: added parameter HlsConfiguration_TargetSegmentDurationSecond.
    * Modified cmdlet Update-IVSRTStage: added parameter HlsConfiguration_TargetSegmentDurationSecond.

### 4.1.775 (2025-03-11 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1000.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Registry
    * Modified cmdlet New-ECRPullThroughCacheRule: added parameters CustomRoleArn and UpstreamRepositoryPrefix.
    * Modified cmdlet Update-ECRPullThroughCacheRule: added parameter CustomRoleArn.

### 4.1.774 (2025-03-10 20:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.999.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABAgentActionGroup: added parameter ParentActionGroupSignatureParam.
    * Modified cmdlet Update-AABAgentActionGroup: added parameter ParentActionGroupSignatureParam.
  * Amazon Connect Service
    * Modified cmdlet New-CONNContact: added parameter PreviousContactId.
  * Amazon Pca Connector Ad
    * Modified cmdlet New-PCAADConnector: added parameter VpcInformation_IpAddressType.

### 4.1.773 (2025-03-07 21:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.998.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABDataSource: added parameters ContextEnrichmentConfiguration_Type, EnrichmentStrategyConfiguration_Method and VectorIngestionConfiguration_ContextEnrichmentConfiguration_BedrockFoundationModelConfiguration_ModelArn.
    * Modified cmdlet New-AABKnowledgeBase: added parameters NeptuneAnalyticsConfiguration_GraphArn, StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField and StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField.
    * Modified cmdlet Update-AABDataSource: added parameters ContextEnrichmentConfiguration_Type, EnrichmentStrategyConfiguration_Method and VectorIngestionConfiguration_ContextEnrichmentConfiguration_BedrockFoundationModelConfiguration_ModelArn.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters NeptuneAnalyticsConfiguration_GraphArn, StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_MetadataField and StorageConfiguration_NeptuneAnalyticsConfiguration_FieldMapping_TextField.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARInlineAgent: added parameters AgentCollaboration, Collaborator, CollaboratorConfiguration and ConversationHistory_Message.
  * Amazon Elastic Load Balancing V2
    * Added cmdlet Edit-ELB2IpPool leveraging the ModifyIpPools service API.
    * Modified cmdlet New-ELB2LoadBalancer: added parameter IpamPools_Ipv4IpamPoolId.

### 4.1.772 (2025-03-06 21:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.997.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet New-BDRPromptRouter leveraging the CreatePromptRouter service API.
    * Added cmdlet Remove-BDRPromptRouter leveraging the DeletePromptRouter service API.
    * Modified cmdlet Get-BDRPromptRouterList: added parameters PassThru and Type.
  * Amazon Interactive Video Service RealTime
    * Modified cmdlet New-IVSRTStage: added parameter AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond.
    * Modified cmdlet Update-IVSRTStage: added parameter AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond.
  * Amazon Redshift Data API Service
    * Modified cmdlet Get-RSDStatementList: added parameters ClusterIdentifier, Database and WorkgroupName.
  * Amazon WorkSpaces
    * Added cmdlet Edit-WKSEndpointEncryptionMode leveraging the ModifyEndpointEncryptionMode service API.

### 4.1.771 (2025-03-05 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.996.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataSync
    * Modified cmdlet Update-DSYNLocationNfs: added parameter ServerHostname.
    * Modified cmdlet Update-DSYNLocationObjectStorage: added parameter ServerHostname.
    * Modified cmdlet Update-DSYNLocationSmb: added parameter ServerHostname.
  * Amazon GameLiftStreams. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GMLS and can be listed using the command 'Get-AWSCmdletName -Service GMLS'.
  * Amazon WorkSpaces
    * Modified cmdlet Edit-WKSWorkspaceAccessProperty: added parameter WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient.

### 4.1.770 (2025-03-04 23:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.995.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT SiteWise
    * Modified cmdlet New-IOTSWGateway: added parameters GatewayVersion and GreengrassV2_CoreDeviceOperatingSystem.
  * Amazon Managed integrations for AWS IoT Device Management. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTMI and can be listed using the command 'Get-AWSCmdletName -Service IOTMI'.

### 4.1.769 (2025-03-03 21:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.994.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch RUM
    * Added cmdlet Get-CWRUMResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-CWRUMResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-CWRUMResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet Write-CWRUMRumEvent: added parameter Alias.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSDataSource: added parameters AudioExtractionConfiguration_AudioExtractionStatus and VideoExtractionConfiguration_VideoExtractionStatus.
    * Modified cmdlet Update-QBUSDataSource: added parameters AudioExtractionConfiguration_AudioExtractionStatus and VideoExtractionConfiguration_VideoExtractionStatus.

### 4.1.768 (2025-02-28 22:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.993.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Data Automation for Amazon Bedrock
    * Added cmdlet Add-BDAResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-BDAResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-BDAResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-BDABlueprint: added parameter Tag.
    * Modified cmdlet New-BDADataAutomationProject: added parameter Tag.
    * Modified cmdlet Update-BDABlueprint: added parameters EncryptionConfiguration_KmsEncryptionContext and EncryptionConfiguration_KmsKeyId.
    * Modified cmdlet Update-BDADataAutomationProject: added parameters EncryptionConfiguration_KmsEncryptionContext and EncryptionConfiguration_KmsKeyId.
  * Amazon Elemental MediaConvert
    * Added cmdlet Invoke-EMCProbe leveraging the Probe service API.
  * Amazon Runtime for Amazon Bedrock Data Automation
    * Added cmdlet Add-BDARResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-BDARResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-BDARResourceTag leveraging the UntagResource service API.
    * [Breaking Change] Modified cmdlet Invoke-BDARDataAutomationAsync: removed parameter DataAutomationConfiguration_DataAutomationArn; added parameters DataAutomationConfiguration_DataAutomationProjectArn, DataAutomationProfileArn and Tag.

### 4.1.767 (2025-02-27 21:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.992.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Add-BARResourceTag leveraging the TagResource service API.
    * Added cmdlet Close-BARSession leveraging the EndSession service API.
    * Added cmdlet Get-BARInvocationList leveraging the ListInvocations service API.
    * Added cmdlet Get-BARInvocationStep leveraging the GetInvocationStep service API.
    * Added cmdlet Get-BARInvocationStepList leveraging the ListInvocationSteps service API.
    * Added cmdlet Get-BARResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-BARSession leveraging the GetSession service API.
    * Added cmdlet Get-BARSessionList leveraging the ListSessions service API.
    * Added cmdlet New-BARInvocation leveraging the CreateInvocation service API.
    * Added cmdlet New-BARSession leveraging the CreateSession service API.
    * Added cmdlet Remove-BARResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-BARSession leveraging the DeleteSession service API.
    * Added cmdlet Update-BARSession leveraging the UpdateSession service API.
    * Added cmdlet Write-BARInvocationStep leveraging the PutInvocationStep service API.
  * Amazon QBusiness
    * Added cmdlet Remove-QBUSAttachment leveraging the DeleteAttachment service API.
  * Amazon Redshift Serverless
    * Added cmdlet Get-RSSTrack leveraging the GetTrack service API.
    * Added cmdlet Get-RSSTrackList leveraging the ListTracks service API.
    * Modified cmdlet New-RSSWorkgroup: added parameter TrackName.
    * Modified cmdlet Update-RSSWorkgroup: added parameter TrackName.
  * Amazon SageMaker Service
    * Added cmdlet Update-SMHubContent leveraging the UpdateHubContent service API.
    * Added cmdlet Update-SMHubContentReference leveraging the UpdateHubContentReference service API.
    * Modified cmdlet Import-SMHubContent: added parameter SupportStatus.
  * Amazon Storage Gateway
    * Added cmdlet Invoke-SGEvictFilesFailingUpload leveraging the EvictFilesFailingUpload service API.

### 4.1.766 (2025-02-26 21:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.991.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Added cmdlet Get-BATConsumableResource leveraging the DescribeConsumableResource service API.
    * Added cmdlet Get-BATConsumableResourceList leveraging the ListConsumableResources service API.
    * Added cmdlet Get-BATJobsByConsumableResourceList leveraging the ListJobsByConsumableResource service API.
    * Added cmdlet New-BATConsumableResource leveraging the CreateConsumableResource service API.
    * Added cmdlet Remove-BATConsumableResource leveraging the DeleteConsumableResource service API.
    * Added cmdlet Update-BATConsumableResource leveraging the UpdateConsumableResource service API.
    * Modified cmdlet Register-BATJobDefinition: added parameter ConsumableResourceProperties_ConsumableResourceList.
    * Modified cmdlet Submit-BATJob: added parameter ConsumableResourcePropertiesOverride_ConsumableResourceList.
  * CHM
    * [Breaking Change] Removed cmdlets Add-CHMAttendee, Add-CHMMeeting, Add-CHMPhoneNumbersToVoiceConnector, Add-CHMPhoneNumbersToVoiceConnectorGroup, Add-CHMResourceTag, Confirm-CHME911Address, Get-CHMAppInstance, Get-CHMAppInstanceAdmin, Get-CHMAppInstanceAdminList, Get-CHMAppInstanceList, Get-CHMAppInstanceRetentionSetting, Get-CHMAppInstanceStreamingConfiguration, Get-CHMAppInstanceUser, Get-CHMAppInstanceUserList, Get-CHMAttendee, Get-CHMAttendeeList, Get-CHMAttendeeTagList, Get-CHMChannel, Get-CHMChannelBan, Get-CHMChannelBanList, Get-CHMChannelList, Get-CHMChannelMembership, Get-CHMChannelMembershipForAppInstanceUser, Get-CHMChannelMembershipList, Get-CHMChannelMembershipsForAppInstanceUserList, Get-CHMChannelMessage, Get-CHMChannelMessageList, Get-CHMChannelModeratedByAppInstanceUser, Get-CHMChannelModerator, Get-CHMChannelModeratorList, Get-CHMChannelsModeratedByAppInstanceUserList, Get-CHMMediaCapturePipeline, Get-CHMMediaCapturePipelineList, Get-CHMMeeting, Get-CHMMeetingList, Get-CHMMeetingTagList, Get-CHMMessagingSessionEndpoint, Get-CHMProxySession, Get-CHMProxySessionList, Get-CHMResourceTag, Get-CHMSipMediaApplication, Get-CHMSipMediaApplicationList, Get-CHMSipMediaApplicationLoggingConfiguration, Get-CHMSipRule, Get-CHMSipRuleList, Get-CHMVoiceConnector, Get-CHMVoiceConnectorEmergencyCallingConfiguration, Get-CHMVoiceConnectorGroup, Get-CHMVoiceConnectorGroupList, Get-CHMVoiceConnectorList, Get-CHMVoiceConnectorLoggingConfiguration, Get-CHMVoiceConnectorOrigination, Get-CHMVoiceConnectorProxy, Get-CHMVoiceConnectorStreamingConfiguration, Get-CHMVoiceConnectorTermination, Get-CHMVoiceConnectorTerminationCredentialList, Get-CHMVoiceConnectorTerminationHealth, Hide-CHMChannelMessage, New-CHMAppInstance, New-CHMAppInstanceAdmin, New-CHMAppInstanceUser, New-CHMAttendee, New-CHMAttendeeBatch, New-CHMChannel, New-CHMChannelBan, New-CHMChannelMembership, New-CHMChannelModerator, New-CHMCreateChannelMembership, New-CHMMediaCapturePipeline, New-CHMMeeting, New-CHMMeetingWithAttendee, New-CHMProxySession, New-CHMSipMediaApplication, New-CHMSipMediaApplicationCall, New-CHMSipRule, New-CHMVoiceConnector, New-CHMVoiceConnectorGroup, Remove-CHMAppInstance, Remove-CHMAppInstanceAdmin, Remove-CHMAppInstanceStreamingConfiguration, Remove-CHMAppInstanceUser, Remove-CHMAttendee, Remove-CHMAttendeeTag, Remove-CHMChannel, Remove-CHMChannelBan, Remove-CHMChannelMembership, Remove-CHMChannelMessage, Remove-CHMChannelModerator, Remove-CHMMediaCapturePipeline, Remove-CHMMeeting, Remove-CHMMeetingTag, Remove-CHMPhoneNumbersFromVoiceConnector, Remove-CHMPhoneNumbersFromVoiceConnectorGroup, Remove-CHMProxySession, Remove-CHMResourceTag, Remove-CHMSipMediaApplication, Remove-CHMSipRule, Remove-CHMVoiceConnector, Remove-CHMVoiceConnectorEmergencyCallingConfiguration, Remove-CHMVoiceConnectorGroup, Remove-CHMVoiceConnectorOrigination, Remove-CHMVoiceConnectorProxy, Remove-CHMVoiceConnectorStreamingConfiguration, Remove-CHMVoiceConnectorTermination, Remove-CHMVoiceConnectorTerminationCredential, Send-CHMChannelMessage, Start-CHMMeetingTranscription, Stop-CHMMeetingTranscription, Update-CHMAppInstance, Update-CHMAppInstanceUser, Update-CHMChannel, Update-CHMChannelMessage, Update-CHMChannelReadMarker, Update-CHMProxySession, Update-CHMSipMediaApplication, Update-CHMSipMediaApplicationCall, Update-CHMSipRule, Update-CHMVoiceConnector, Update-CHMVoiceConnectorGroup, Write-CHMAppInstanceRetentionSetting, Write-CHMAppInstanceStreamingConfiguration, Write-CHMSipMediaApplicationLoggingConfiguration, Write-CHMVoiceConnectorEmergencyCallingConfiguration, Write-CHMVoiceConnectorLoggingConfiguration, Write-CHMVoiceConnectorOrigination, Write-CHMVoiceConnectorProxy, Write-CHMVoiceConnectorStreamingConfiguration, Write-CHMVoiceConnectorTermination and Write-CHMVoiceConnectorTerminationCredential.
  * Amazon CloudWatch Application Signals
    * Modified cmdlet Get-CWASServiceLevelObjectiveList: added parameters IncludeLinkedAccount and SloOwnerAwsAccountId.
    * Modified cmdlet Get-CWASServiceList: added parameters AwsAccountId and IncludeLinkedAccount.
  * Amazon IoT FleetWise
    * Modified cmdlet Get-IFWCampaignList: added parameter ListResponseScope.
    * Modified cmdlet Get-IFWDecoderManifestList: added parameter ListResponseScope.
    * Modified cmdlet Get-IFWFleetList: added parameters ListResponseScope and PassThru.
    * Modified cmdlet Get-IFWModelManifestList: added parameter ListResponseScope.
    * Modified cmdlet Get-IFWStateTemplateList: added parameters ListResponseScope and PassThru.
    * Modified cmdlet Get-IFWVehicleList: added parameter ListResponseScope.
  * Amazon SageMaker Service
    * Modified cmdlet Update-SMInferenceComponent: added parameters AutoRollbackConfiguration_Alarm, MaximumBatchSize_Type, MaximumBatchSize_Value, RollbackMaximumBatchSize_Type, RollbackMaximumBatchSize_Value, RollingUpdatePolicy_MaximumExecutionTimeoutInSecond and RollingUpdatePolicy_WaitIntervalInSecond.

### 4.1.765 (2025-02-25 21:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.990.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Device Farm
    * Modified cmdlet Get-DFDevicePoolCompatibility: added parameters DeviceProxy_Host and DeviceProxy_Port.
    * Modified cmdlet New-DFRemoteAccessSession: added parameters DeviceProxy_Host and DeviceProxy_Port.
    * Modified cmdlet Submit-DFTestRun: added parameters DeviceProxy_Host and DeviceProxy_Port.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Copy-EC2Image: added parameter SnapshotCopyCompletionDurationMinute.
  * Amazon Tax Settings
    * Modified cmdlet Write-TSATaxRegistration: added parameters EgyptAdditionalInfo_UniqueIdentificationNumber, EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate, GreeceAdditionalInfo_ContractingAuthorityCode, VietnamAdditionalInfo_ElectronicTransactionCodeNumber, VietnamAdditionalInfo_EnterpriseIdentificationNumber, VietnamAdditionalInfo_PaymentVoucherNumber and VietnamAdditionalInfo_PaymentVoucherNumberDate.
    * Modified cmdlet Write-TSATaxRegistrationBatch: added parameters EgyptAdditionalInfo_UniqueIdentificationNumber, EgyptAdditionalInfo_UniqueIdentificationNumberExpirationDate, GreeceAdditionalInfo_ContractingAuthorityCode, VietnamAdditionalInfo_ElectronicTransactionCodeNumber, VietnamAdditionalInfo_EnterpriseIdentificationNumber, VietnamAdditionalInfo_PaymentVoucherNumber and VietnamAdditionalInfo_PaymentVoucherNumberDate.

### 4.1.764 (2025-02-24 23:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.989.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Elastic Inference

### 4.1.763 (2025-02-21 21:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.988.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABDataSource: added parameter CrawlerConfiguration_UserAgentHeader.
    * Modified cmdlet Update-AABDataSource: added parameter CrawlerConfiguration_UserAgentHeader.

### 4.1.762 (2025-02-20 21:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.987.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SageMaker Service
    * Modified cmdlet Update-SMCluster: added parameter InstanceGroupsToDelete.
  * Amazon WorkSpaces Web
    * Modified cmdlet New-WSWUserSetting: added parameters ToolbarConfiguration_HiddenToolbarItem, ToolbarConfiguration_MaxDisplayResolution, ToolbarConfiguration_ToolbarType and ToolbarConfiguration_VisualMode.
    * Modified cmdlet Update-WSWUserSetting: added parameters ToolbarConfiguration_HiddenToolbarItem, ToolbarConfiguration_MaxDisplayResolution, ToolbarConfiguration_ToolbarType and ToolbarConfiguration_VisualMode.

### 4.1.761 (2025-02-19 21:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.986.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Network Firewall
    * Added cmdlet Get-NWFWAnalysisReportList leveraging the ListAnalysisReports service API.
    * Added cmdlet Get-NWFWAnalysisReportResult leveraging the GetAnalysisReportResults service API.
    * Added cmdlet Start-NWFWAnalysisReport leveraging the StartAnalysisReport service API.
    * Added cmdlet Update-NWFWFirewallAnalysisSetting leveraging the UpdateFirewallAnalysisSettings service API.
    * Modified cmdlet New-NWFWFirewall: added parameter EnabledAnalysisType.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Write-SES2ConfigurationSetArchivingOption leveraging the PutConfigurationSetArchivingOptions service API.
    * Modified cmdlet New-SES2ConfigurationSet: added parameter ArchivingOptions_ArchiveArn.

### 4.1.760 (2025-02-18 21:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.985.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaLive
    * [Breaking Change] Modified cmdlet Start-EMLMonitorDeployment: removed parameter RequestId.
  * Amazon EMR Containers
    * Modified cmdlet New-EMRCManagedEndpoint: added parameters ManagedLogs_AllowAWSToRetainLog and ManagedLogs_EncryptionKeyArn.
    * Modified cmdlet Start-EMRCJobRun: added parameters ManagedLogs_AllowAWSToRetainLog and ManagedLogs_EncryptionKeyArn.

### 4.1.759 (2025-02-17 21:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.984.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter ComputeRoleArn.
    * Modified cmdlet New-AMPBranch: added parameter ComputeRoleArn.
    * Modified cmdlet Update-AMPApp: added parameter ComputeRoleArn.
    * Modified cmdlet Update-AMPBranch: added parameter ComputeRoleArn.
  * Amazon Database Migration Service
    * Modified cmdlet Get-DMSApplicableIndividualAssessment: added parameter ReplicationConfigArn.
  * Amazon Timestream InfluxDB
    * Added cmdlet Get-TIDBDbCluster leveraging the GetDbCluster service API.
    * Added cmdlet Get-TIDBDbClusterList leveraging the ListDbClusters service API.
    * Added cmdlet Get-TIDBDbInstancesForClusterList leveraging the ListDbInstancesForCluster service API.
    * Added cmdlet New-TIDBDbCluster leveraging the CreateDbCluster service API.
    * Added cmdlet Remove-TIDBDbCluster leveraging the DeleteDbCluster service API.
    * Added cmdlet Update-TIDBDbCluster leveraging the UpdateDbCluster service API.

### 4.1.758 (2025-02-14 21:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.983.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Get-CONNAnalyticsDataLakeDataSetList leveraging the ListAnalyticsDataLakeDataSets service API.
    * Modified cmdlet Add-CONNApprovedOrigin: added parameter ClientToken.
    * Modified cmdlet Add-CONNBot: added parameter ClientToken.
    * Modified cmdlet Add-CONNInstanceStorageConfig: added parameter ClientToken.
    * Modified cmdlet Add-CONNLambdaFunction: added parameter ClientToken.
    * Modified cmdlet Add-CONNLexBot: added parameter ClientToken.
    * Modified cmdlet Add-CONNSecurityKey: added parameter ClientToken.
    * Modified cmdlet Remove-CONNApprovedOrigin: added parameter ClientToken.
    * Modified cmdlet Remove-CONNBot: added parameter ClientToken.
    * Modified cmdlet Remove-CONNInstance: added parameter ClientToken.
    * Modified cmdlet Remove-CONNInstanceStorageConfig: added parameter ClientToken.
    * Modified cmdlet Remove-CONNLambdaFunction: added parameter ClientToken.
    * Modified cmdlet Remove-CONNLexBot: added parameter ClientToken.
    * Modified cmdlet Remove-CONNSecurityKey: added parameter ClientToken.
    * Modified cmdlet Update-CONNInstanceAttribute: added parameter ClientToken.
    * Modified cmdlet Update-CONNInstanceStorageConfig: added parameter ClientToken.
  * Amazon Database Migration Service
    * Modified cmdlet Start-DMSReplication: added parameter PremigrationAssessmentSetting.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter DataProtectionConfig_DataProtection.
    * Modified cmdlet Update-WAF2WebACL: added parameter DataProtectionConfig_DataProtection.

### 4.1.757 (2025-02-13 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.982.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IAM Access Analyzer
    * Added cmdlet Get-IAMAAFindingsStatistic leveraging the GetFindingsStatistics service API.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGCacheReport leveraging the DescribeCacheReport service API.
    * Added cmdlet Get-SGCacheReportList leveraging the ListCacheReports service API.
    * Added cmdlet Remove-SGCacheReport leveraging the DeleteCacheReport service API.
    * Added cmdlet Start-SGCacheReport leveraging the StartCacheReport service API.
    * Added cmdlet Stop-SGCacheReport leveraging the CancelCacheReport service API.

### 4.1.756 (2025-02-12 22:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.981.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLCloudWatchAlarmTemplate: added parameter RequestId.
    * Modified cmdlet New-EMLCloudWatchAlarmTemplateGroup: added parameter RequestId.
    * Modified cmdlet New-EMLEventBridgeRuleTemplate: added parameter RequestId.
    * Modified cmdlet New-EMLEventBridgeRuleTemplateGroup: added parameter RequestId.
    * Modified cmdlet New-EMLSignalMap: added parameter RequestId.
    * Modified cmdlet Start-EMLMonitorDeployment: added parameter RequestId.
  * Amazon FSx
    * Modified cmdlet Update-FSXFileSystem: added parameter FileSystemTypeVersion.
  * Amazon OpenSearch Serverless
    * Modified cmdlet New-OSSSecurityConfig: added parameter SamlOptions_OpenSearchServerlessEntityId.
    * Modified cmdlet Update-OSSSecurityConfig: added parameter SamlOptions_OpenSearchServerlessEntityId.

### 4.1.755 (2025-02-11 22:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.980.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Copy-S3Object: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3Object: added parameter ExpectedBucketOwner.

### 4.1.754 (2025-02-10 21:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.979.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSDataProvider: added parameters IbmDb2LuwSettings_CertificateArn, IbmDb2LuwSettings_DatabaseName, IbmDb2LuwSettings_Port, IbmDb2LuwSettings_ServerName, IbmDb2LuwSettings_SslMode, IbmDb2zOsSettings_CertificateArn, IbmDb2zOsSettings_DatabaseName, IbmDb2zOsSettings_Port, IbmDb2zOsSettings_ServerName and IbmDb2zOsSettings_SslMode.
    * Modified cmdlet New-DMSDataProvider: added parameters IbmDb2LuwSettings_CertificateArn, IbmDb2LuwSettings_DatabaseName, IbmDb2LuwSettings_Port, IbmDb2LuwSettings_ServerName, IbmDb2LuwSettings_SslMode, IbmDb2zOsSettings_CertificateArn, IbmDb2zOsSettings_DatabaseName, IbmDb2zOsSettings_Port, IbmDb2zOsSettings_ServerName and IbmDb2zOsSettings_SslMode.

### 4.1.753 (2025-02-07 22:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.978.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet Get-EKSClusterVersion: added parameter VersionStatus.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSMedicalScribeJob: added parameter ClinicalNoteGenerationSettings_NoteTemplate.

### 4.1.752 (2025-02-06 21:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.977.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNCFNStackRefactor leveraging the DescribeStackRefactor service API.
    * Added cmdlet Get-CFNCFNStackRefactorActionList leveraging the ListStackRefactorActions service API.
    * Added cmdlet Get-CFNCFNStackRefactorList leveraging the ListStackRefactors service API.
    * Added cmdlet New-CFNCFNStackRefactor leveraging the CreateStackRefactor service API.
    * Added cmdlet Start-CFNCFNStackRefactor leveraging the ExecuteStackRefactor service API.
  * Amazon Connect Cases
    * Added cmdlet Get-CCASCaseRuleList leveraging the ListCaseRules service API.
    * Added cmdlet Group-CCASGetCaseRule leveraging the BatchGetCaseRule service API.
    * Added cmdlet New-CCASCaseRule leveraging the CreateCaseRule service API.
    * Added cmdlet Remove-CCASCaseRule leveraging the DeleteCaseRule service API.
    * Added cmdlet Update-CCASCaseRule leveraging the UpdateCaseRule service API.
    * Modified cmdlet New-CCASTemplate: added parameter Rule.
    * Modified cmdlet Update-CCASTemplate: added parameter Rule.

### 4.1.751 (2025-02-05 22:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.976.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.750 (2025-02-04 23:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.976.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSDataMigration: added parameter TargetDataSetting.
    * Modified cmdlet New-DMSDataMigration: added parameter TargetDataSetting.
  * Amazon Identity and Access Management
    * Modified cmdlet New-IAMSAMLProvider: added parameters AddPrivateKey and AssertionEncryptionMode.
    * Modified cmdlet Update-IAMSAMLProvider: added parameters AddPrivateKey, AssertionEncryptionMode and RemovePrivateKey.
  * Amazon Neptune Graph
    * Modified cmdlet Get-NEPTGExportTaskList: added parameters GraphIdentifier and PassThru.
  * Amazon QBusiness
    * Modified cmdlet Update-QBUSChatControlsConfiguration: added parameter OrchestrationConfiguration_Control.

### 4.1.749 (2025-02-03 21:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.975.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Add-EMTLogsForPlaybackConfiguration: added parameter EnabledLoggingStrategy.

### 4.1.748 (2025-01-31 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.974.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Location Service Routes V2
    * Modified cmdlet Get-GEOROptimizedWaypoint: added parameters Clustering_Algorithm and DrivingDistanceOptions_DrivingDistance.
  * Amazon Prometheus Service
    * Modified cmdlet New-PROMScraper: added parameters RoleConfiguration_SourceRoleArn and RoleConfiguration_TargetRoleArn.
    * Modified cmdlet Update-PROMScraper: added parameters RoleConfiguration_SourceRoleArn and RoleConfiguration_TargetRoleArn.

### 4.1.747 (2025-01-30 21:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.973.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter AdConditioningConfiguration_StreamingMediaFileConditioning.
  * Amazon QBusiness
    * Added cmdlet Get-QBUSSubscriptionList leveraging the ListSubscriptions service API.
    * Added cmdlet New-QBUSSubscription leveraging the CreateSubscription service API.
    * Added cmdlet Stop-QBUSSubscription leveraging the CancelSubscription service API.
    * Added cmdlet Update-QBUSSubscription leveraging the UpdateSubscription service API.
  * Amazon S3 Tables
    * Modified cmdlet New-S3TTable: added parameter Schema_Field.
  * Amazon Verified Permissions
    * Modified cmdlet Get-AVPBatchIsAuthorizedWithToken: added parameter Entities_CedarJson.
    * Modified cmdlet Test-AVPAuthorization: added parameters Context_CedarJson and Entities_CedarJson.
    * Modified cmdlet Test-AVPBatchAuthorization: added parameter Entities_CedarJson.
    * Modified cmdlet Test-AVPTokenAuthorization: added parameters Context_CedarJson and Entities_CedarJson.

### 4.1.746 (2025-01-29 22:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.972.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SES Mail Manager
    * Added cmdlet Add-MMGRMemberToAddressList leveraging the RegisterMemberToAddressList service API.
    * Added cmdlet Get-MMGRAddressList leveraging the GetAddressList service API.
    * Added cmdlet Get-MMGRAddressListImportJob leveraging the GetAddressListImportJob service API.
    * Added cmdlet Get-MMGRAddressListImportJobList leveraging the ListAddressListImportJobs service API.
    * Added cmdlet Get-MMGRAddressListList leveraging the ListAddressLists service API.
    * Added cmdlet Get-MMGRMemberOfAddressList leveraging the GetMemberOfAddressList service API.
    * Added cmdlet Get-MMGRMembersOfAddressListList leveraging the ListMembersOfAddressList service API.
    * Added cmdlet New-MMGRAddressList leveraging the CreateAddressList service API.
    * Added cmdlet New-MMGRAddressListImportJob leveraging the CreateAddressListImportJob service API.
    * Added cmdlet Remove-MMGRAddressList leveraging the DeleteAddressList service API.
    * Added cmdlet Remove-MMGRMemberFromAddressList leveraging the DeregisterMemberFromAddressList service API.
    * Added cmdlet Start-MMGRAddressListImportJob leveraging the StartAddressListImportJob service API.
    * Added cmdlet Stop-MMGRAddressListImportJob leveraging the StopAddressListImportJob service API.

### 4.1.745 (2025-01-28 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.971.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Added cmdlet Get-ADCLimit leveraging the GetLimit service API.
    * Added cmdlet Get-ADCLimitList leveraging the ListLimits service API.
    * Added cmdlet Get-ADCQueueLimitAssociation leveraging the GetQueueLimitAssociation service API.
    * Added cmdlet Get-ADCQueueLimitAssociationList leveraging the ListQueueLimitAssociations service API.
    * Added cmdlet New-ADCLimit leveraging the CreateLimit service API.
    * Added cmdlet New-ADCQueueLimitAssociation leveraging the CreateQueueLimitAssociation service API.
    * Added cmdlet Remove-ADCLimit leveraging the DeleteLimit service API.
    * Added cmdlet Remove-ADCQueueLimitAssociation leveraging the DeleteQueueLimitAssociation service API.
    * Added cmdlet Update-ADCLimit leveraging the UpdateLimit service API.
    * Added cmdlet Update-ADCQueueLimitAssociation leveraging the UpdateQueueLimitAssociation service API.
    * Modified cmdlet New-ADCJob: added parameter MaxWorkerCount.
    * Modified cmdlet Update-ADCJob: added parameter MaxWorkerCount.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationSmb: added parameters AuthenticationType, DnsIpAddress, KerberosKeytab, KerberosKrb5Conf and KerberosPrincipal.
    * Modified cmdlet Update-DSYNLocationSmb: added parameters AuthenticationType, DnsIpAddress, KerberosKeytab, KerberosKrb5Conf and KerberosPrincipal.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters DirectPutSourceConfiguration_ThroughputHintInMBs and IcebergDestinationConfiguration_AppendOnly.
    * Modified cmdlet Update-KINFDestination: added parameter IcebergDestinationUpdate_AppendOnly.
  * Amazon Timestream InfluxDB
    * Modified cmdlet Update-TIDBDbInstance: added parameters AllocatedStorage and DbStorageType.

### 4.1.744 (2025-01-27 22:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.970.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.743 (2025-01-24 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.969.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudTrail
    * Added cmdlet Search-CTSampleQuery leveraging the SearchSampleQueries service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSNodegroup: added parameter UpdateConfig_UpdateStrategy.
    * Modified cmdlet Update-EKSNodegroupConfig: added parameter UpdateConfig_UpdateStrategy.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRAgreement: added parameters CustomDirectories_FailedFilesDirectory, CustomDirectories_MdnFilesDirectory, CustomDirectories_PayloadFilesDirectory, CustomDirectories_StatusFilesDirectory and CustomDirectories_TemporaryFilesDirectory.
    * Modified cmdlet Update-TFRAgreement: added parameters CustomDirectories_FailedFilesDirectory, CustomDirectories_MdnFilesDirectory, CustomDirectories_PayloadFilesDirectory, CustomDirectories_StatusFilesDirectory and CustomDirectories_TemporaryFilesDirectory.

### 4.1.742 (2025-01-23 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.968.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.741 (2025-01-22 21:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.967.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * 
    * Added cmdlet Get-AWSSensitiveDataConfiguration.
    * Added cmdlet Set-AWSSensitiveDataConfiguration.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARFlow: added parameter ExecutionId.

### 4.1.740 (2025-01-21 22:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.966.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Remove-CONNContactFlowVersion leveraging the DeleteContactFlowVersion service API.
    * Modified cmdlet New-CONNContactFlowVersion: added parameter ContactFlowVersion.
  * Amazon IoT SiteWise
    * Modified cmdlet Import-IOTSWPutAssetPropertyValue: added parameters EnablePartialEntryProcessing and PassThru.
    * Modified cmdlet Write-IOTSWStorageConfiguration: added parameter DisallowIngestNullNaN.

### 4.1.739 (2025-01-17 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.965.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon User Notifications
    * Added cmdlet Add-UNOManagedNotificationAccountContact leveraging the AssociateManagedNotificationAccountContact service API.
    * Added cmdlet Add-UNOManagedNotificationAdditionalChannel leveraging the AssociateManagedNotificationAdditionalChannel service API.
    * Added cmdlet Disable-UNONotificationsAccessForOrganization leveraging the DisableNotificationsAccessForOrganization service API.
    * Added cmdlet Enable-UNONotificationsAccessForOrganization leveraging the EnableNotificationsAccessForOrganization service API.
    * Added cmdlet Get-UNOManagedNotificationChannelAssociationList leveraging the ListManagedNotificationChannelAssociations service API.
    * Added cmdlet Get-UNOManagedNotificationChildEvent leveraging the GetManagedNotificationChildEvent service API.
    * Added cmdlet Get-UNOManagedNotificationChildEventList leveraging the ListManagedNotificationChildEvents service API.
    * Added cmdlet Get-UNOManagedNotificationConfiguration leveraging the GetManagedNotificationConfiguration service API.
    * Added cmdlet Get-UNOManagedNotificationConfigurationList leveraging the ListManagedNotificationConfigurations service API.
    * Added cmdlet Get-UNOManagedNotificationEvent leveraging the GetManagedNotificationEvent service API.
    * Added cmdlet Get-UNOManagedNotificationEventList leveraging the ListManagedNotificationEvents service API.
    * Added cmdlet Get-UNONotificationsAccessForOrganization leveraging the GetNotificationsAccessForOrganization service API.
    * Added cmdlet Remove-UNOManagedNotificationAccountContact leveraging the DisassociateManagedNotificationAccountContact service API.
    * Added cmdlet Remove-UNOManagedNotificationAdditionalChannel leveraging the DisassociateManagedNotificationAdditionalChannel service API.

### 4.1.738 (2025-01-16 21:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.964.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.737 (2025-01-15 22:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.963.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARInlineAgent: added parameters StreamingConfigurations_ApplyGuardrailInterval and StreamingConfigurations_StreamFinalResponse.
  * Amazon Partner Central Selling API
    * Added cmdlet Add-PCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-PCResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Invoke-PCResourceSnapshotJob: added parameter Tag.
    * Modified cmdlet Invoke-PCStartEngagementByAcceptingInvitationTask: added parameter Tag.
    * Modified cmdlet Invoke-PCStartEngagementFromOpportunityTask: added parameter Tag.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3Object: added parameters ChecksumValue and MpuObjectSize.
    * Modified cmdlet Write-S3GetObjectResponse: added parameter ChecksumCRC64NVME.

### 4.1.736 (2025-01-14 21:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.962.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GameLift Service
    * Modified cmdlet Start-GMLGameSessionPlacement: added parameters PriorityConfigurationOverride_LocationOrder and PriorityConfigurationOverride_PlacementFallbackStrategy.

### 4.1.735 (2025-01-13 21:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.961.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameter DisconnectOnSessionTimeout.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter DisconnectOnSessionTimeout.
  * Amazon Managed Streaming for Kafka Connect
    * Added cmdlet Get-MSKCConnectorOperation leveraging the DescribeConnectorOperation service API.
    * Added cmdlet Get-MSKCConnectorOperationList leveraging the ListConnectorOperations service API.
    * Modified cmdlet Update-MSKCConnector: added parameter ConnectorConfiguration.
  * Amazon Transcribe Service
    * Modified cmdlet New-TRSCallAnalyticsCategory: added parameter Tag.
    * Modified cmdlet Start-TRSCallAnalyticsJob: added parameter Tag.

### 4.1.734 (2025-01-10 23:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.960.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Update the AWS Tools for PowerShell to support EKS Pod Identity credentials

### 4.1.733 (2025-01-09 22:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.960.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter Restrictions_FleetsAllowed.
    * Modified cmdlet Start-CBBatch: added parameter Restrictions_FleetsAllowed.
    * Modified cmdlet Update-CBProject: added parameter Restrictions_FleetsAllowed.

### 4.1.732 (2025-01-08 21:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.959.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.731 (2025-01-07 21:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.958.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudHSM V2
    * Modified cmdlet Edit-HSM2Cluster: added parameter HsmType.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBContinuousBackup: added parameter PointInTimeRecoverySpecification_RecoveryPeriodInDay.
  * Amazon EC2 Image Builder
    * Added cmdlet Import-EC2IBDiskImage leveraging the ImportDiskImage service API.

### 4.1.730 (2025-01-06 21:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.957.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Supply Chain
    * Modified cmdlet New-SUPCHInstance: added parameter WebAppDnsDomain.

### 4.1.729 (2025-01-03 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.956.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.728 (2025-01-02 21:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.955.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNFlow: added parameters SourceMonitoringConfig_AudioMonitoringSetting, SourceMonitoringConfig_ContentQualityAnalysisState and SourceMonitoringConfig_VideoMonitoringSetting.
    * Modified cmdlet Update-EMCNFlow: added parameters SourceMonitoringConfig_AudioMonitoringSetting, SourceMonitoringConfig_ContentQualityAnalysisState and SourceMonitoringConfig_VideoMonitoringSetting.
  * Amazon GameLift Service
    * Added cmdlet Stop-GMLGameSession leveraging the TerminateGameSession service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAlgorithm: added parameter AdditionalS3DataSource_ETag.

