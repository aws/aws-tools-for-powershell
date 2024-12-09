### 4.1.714 (2024-12-09 22:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.942.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2InstanceNetworkPerformanceOption leveraging the ModifyInstanceNetworkPerformanceOptions service API.
    * Modified cmdlet New-EC2Instance: added parameter NetworkPerformanceOptions_BandwidthWeighting.

### 4.1.713 (2024-12-05 03:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.941.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Partner Central Selling API
    * Added cmdlet Get-PCEngagement leveraging the GetEngagement service API.
    * Added cmdlet Get-PCEngagementByAcceptingInvitationTaskList leveraging the ListEngagementByAcceptingInvitationTasks service API.
    * Added cmdlet Get-PCEngagementFromOpportunityTaskList leveraging the ListEngagementFromOpportunityTasks service API.
    * Added cmdlet Get-PCEngagementList leveraging the ListEngagements service API.
    * Added cmdlet Get-PCEngagementMemberList leveraging the ListEngagementMembers service API.
    * Added cmdlet Get-PCEngagementResourceAssociationList leveraging the ListEngagementResourceAssociations service API.
    * Added cmdlet Get-PCResourceSnapshot leveraging the GetResourceSnapshot service API.
    * Added cmdlet Get-PCResourceSnapshotJob leveraging the GetResourceSnapshotJob service API.
    * Added cmdlet Get-PCResourceSnapshotJobList leveraging the ListResourceSnapshotJobs service API.
    * Added cmdlet Get-PCResourceSnapshotList leveraging the ListResourceSnapshots service API.
    * Added cmdlet Get-PCSellingSystemSetting leveraging the GetSellingSystemSettings service API.
    * Added cmdlet Invoke-PCAcceptEngagementInvitation leveraging the AcceptEngagementInvitation service API.
    * Added cmdlet Invoke-PCCreateEngagement leveraging the CreateEngagement service API.
    * Added cmdlet Invoke-PCCreateEngagementInvitation leveraging the CreateEngagementInvitation service API.
    * Added cmdlet Invoke-PCResourceSnapshot leveraging the CreateResourceSnapshot service API.
    * Added cmdlet Invoke-PCResourceSnapshotJob leveraging the CreateResourceSnapshotJob service API.
    * Added cmdlet Remove-PCResourceSnapshotJob leveraging the DeleteResourceSnapshotJob service API.
    * Added cmdlet Start-PCResourceSnapshotJob leveraging the StartResourceSnapshotJob service API.
    * Added cmdlet Stop-PCResourceSnapshotJob leveraging the StopResourceSnapshotJob service API.
    * Added cmdlet Submit-PCOpportunity leveraging the SubmitOpportunity service API.
    * Added cmdlet Write-PCSellingSystemSetting leveraging the PutSellingSystemSettings service API.
    * Modified cmdlet Get-PCEngagementInvitationList: added parameters EngagementIdentifier, SenderAwsAccountId and Status.
  * Amazon QBusiness
    * [Breaking Change] Modified cmdlet Search-QBUSRelevantContent: removed parameters UserGroup and UserId.

### 4.1.712 (2024-12-04 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.940.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABDataSource: added parameters BedrockDataAutomationConfiguration_ParsingModality and BedrockFoundationModelConfiguration_ParsingModality.
    * Modified cmdlet New-AABKnowledgeBase: added parameters AuthConfiguration_DatabaseUser, AuthConfiguration_Type, AuthConfiguration_UsernamePasswordSecretArn, GenerationContext_CuratedQuery, GenerationContext_Table, KendraKnowledgeBaseConfiguration_KendraIndexArn, KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type, KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn, ProvisionedConfiguration_ClusterIdentifier, QueryEngineConfiguration_Type, QueryGenerationConfiguration_ExecutionTimeoutSecond, RedshiftConfiguration_StorageConfiguration, ServerlessConfiguration_WorkgroupArn, SqlKnowledgeBaseConfiguration_Type and SupplementalDataStorageConfiguration_StorageLocation.
    * Modified cmdlet Update-AABDataSource: added parameters BedrockDataAutomationConfiguration_ParsingModality and BedrockFoundationModelConfiguration_ParsingModality.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters AuthConfiguration_DatabaseUser, AuthConfiguration_Type, AuthConfiguration_UsernamePasswordSecretArn, GenerationContext_CuratedQuery, GenerationContext_Table, KendraKnowledgeBaseConfiguration_KendraIndexArn, KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_Type, KnowledgeBaseConfiguration_SqlKnowledgeBaseConfiguration_RedshiftConfiguration_QueryEngineConfiguration_ProvisionedConfiguration_AuthConfiguration_UsernamePasswordSecretArn, ProvisionedConfiguration_ClusterIdentifier, QueryEngineConfiguration_Type, QueryGenerationConfiguration_ExecutionTimeoutSecond, RedshiftConfiguration_StorageConfiguration, ServerlessConfiguration_WorkgroupArn, SqlKnowledgeBaseConfiguration_Type and SupplementalDataStorageConfiguration_StorageLocation.
  * Amazon Bedrock
    * Added cmdlet Get-BDRMarketplaceModelEndpoint leveraging the GetMarketplaceModelEndpoint service API.
    * Added cmdlet Get-BDRMarketplaceModelEndpointList leveraging the ListMarketplaceModelEndpoints service API.
    * Added cmdlet Get-BDRPromptRouter leveraging the GetPromptRouter service API.
    * Added cmdlet Get-BDRPromptRouterList leveraging the ListPromptRouters service API.
    * Added cmdlet New-BDRMarketplaceModelEndpoint leveraging the CreateMarketplaceModelEndpoint service API.
    * Added cmdlet Register-BDRMarketplaceModelEndpoint leveraging the RegisterMarketplaceModelEndpoint service API.
    * Added cmdlet Remove-BDRMarketplaceModelEndpoint leveraging the DeleteMarketplaceModelEndpoint service API.
    * Added cmdlet Unregister-BDRMarketplaceModelEndpoint leveraging the DeregisterMarketplaceModelEndpoint service API.
    * Added cmdlet Update-BDRMarketplaceModelEndpoint leveraging the UpdateMarketplaceModelEndpoint service API.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Invoke-BARGenerateQuery leveraging the GenerateQuery service API.
  * Amazon Data Automation for Amazon Bedrock. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BDA and can be listed using the command 'Get-AWSCmdletName -Service BDA'.
  * Amazon Runtime for Amazon Bedrock Data Automation. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BDAR and can be listed using the command 'Get-AWSCmdletName -Service BDAR'.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMClusterSchedulerConfig leveraging the DescribeClusterSchedulerConfig service API.
    * Added cmdlet Get-SMClusterSchedulerConfigList leveraging the ListClusterSchedulerConfigs service API.
    * Added cmdlet Get-SMComputeQuota leveraging the DescribeComputeQuota service API.
    * Added cmdlet Get-SMComputeQuotaList leveraging the ListComputeQuotas service API.
    * Added cmdlet Get-SMPartnerApp leveraging the DescribePartnerApp service API.
    * Added cmdlet Get-SMPartnerAppList leveraging the ListPartnerApps service API.
    * Added cmdlet Get-SMTrainingPlan leveraging the DescribeTrainingPlan service API.
    * Added cmdlet Get-SMTrainingPlanList leveraging the ListTrainingPlans service API.
    * Added cmdlet New-SMClusterSchedulerConfig leveraging the CreateClusterSchedulerConfig service API.
    * Added cmdlet New-SMComputeQuota leveraging the CreateComputeQuota service API.
    * Added cmdlet New-SMPartnerApp leveraging the CreatePartnerApp service API.
    * Added cmdlet New-SMPartnerAppPresignedUrl leveraging the CreatePartnerAppPresignedUrl service API.
    * Added cmdlet New-SMTrainingPlan leveraging the CreateTrainingPlan service API.
    * Added cmdlet Remove-SMClusterSchedulerConfig leveraging the DeleteClusterSchedulerConfig service API.
    * Added cmdlet Remove-SMComputeQuota leveraging the DeleteComputeQuota service API.
    * Added cmdlet Remove-SMPartnerApp leveraging the DeletePartnerApp service API.
    * Added cmdlet Search-SMTrainingPlanOffering leveraging the SearchTrainingPlanOfferings service API.
    * Added cmdlet Update-SMClusterSchedulerConfig leveraging the UpdateClusterSchedulerConfig service API.
    * Added cmdlet Update-SMComputeQuota leveraging the UpdateComputeQuota service API.
    * Added cmdlet Update-SMPartnerApp leveraging the UpdatePartnerApp service API.
    * Modified cmdlet Get-SMClusterList: added parameter TrainingPlanArn.
    * Modified cmdlet Get-SMTrainingJobList: added parameter TrainingPlanArnEqual.

### 4.1.711 (2024-12-04 00:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.939.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Added cmdlet Get-AABAgentCollaborator leveraging the GetAgentCollaborator service API.
    * Added cmdlet Get-AABAgentCollaboratorList leveraging the ListAgentCollaborators service API.
    * Added cmdlet Register-AABAgentCollaborator leveraging the AssociateAgentCollaborator service API.
    * Added cmdlet Unregister-AABAgentCollaborator leveraging the DisassociateAgentCollaborator service API.
    * Added cmdlet Update-AABAgentCollaborator leveraging the UpdateAgentCollaborator service API.
    * Modified cmdlet New-AABAgent: added parameter AgentCollaboration.
    * Modified cmdlet Update-AABAgent: added parameter AgentCollaboration.
  * Amazon Athena
    * Modified cmdlet Remove-ATHDataCatalog: added parameter DeleteCatalogOnly.
  * Amazon Aurora DSQL. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DSQL and can be listed using the command 'Get-AWSCmdletName -Service DSQL'.
  * Amazon Bedrock
    * Modified cmdlet New-BDRModelCustomizationJob: added parameters InvocationLogsConfig_UsePromptResponse, InvocationLogSource_S3Uri, RequestMetadataFilters_AndAll, RequestMetadataFilters_Equal, RequestMetadataFilters_NotEqual, RequestMetadataFilters_OrAll, TeacherModelConfig_MaxResponseLengthForInference and TeacherModelConfig_TeacherModelIdentifier.
    * Modified cmdlet Write-BDRModelInvocationLoggingConfiguration: added parameter LoggingConfig_VideoDataDeliveryEnabled.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARAgent: added parameters ConversationHistory_Message and SourceArn.
  * Amazon Bedrock Runtime
    * Added cmdlet Get-BDRRAsyncInvoke leveraging the GetAsyncInvoke service API.
    * Added cmdlet Get-BDRRAsyncInvokeList leveraging the ListAsyncInvokes service API.
    * Added cmdlet Start-BDRRAsyncInvoke leveraging the StartAsyncInvoke service API.
    * Modified cmdlet Invoke-BDRRConverse: added parameter RequestMetadata.
    * Modified cmdlet Invoke-BDRRConverseStream: added parameter RequestMetadata.
  * Amazon DataZone
    * Added cmdlet Get-DZConnection leveraging the GetConnection service API.
    * Added cmdlet Get-DZConnectionList leveraging the ListConnections service API.
    * Added cmdlet Get-DZJobRun leveraging the GetJobRun service API.
    * Added cmdlet Get-DZJobRunList leveraging the ListJobRuns service API.
    * Added cmdlet Get-DZLineageEvent leveraging the GetLineageEvent service API.
    * Added cmdlet Get-DZLineageEventList leveraging the ListLineageEvents service API.
    * Added cmdlet Get-DZProjectProfile leveraging the GetProjectProfile service API.
    * Added cmdlet Get-DZProjectProfileList leveraging the ListProjectProfiles service API.
    * Added cmdlet New-DZConnection leveraging the CreateConnection service API.
    * Added cmdlet New-DZProjectProfile leveraging the CreateProjectProfile service API.
    * Added cmdlet Remove-DZConnection leveraging the DeleteConnection service API.
    * Added cmdlet Remove-DZProjectProfile leveraging the DeleteProjectProfile service API.
    * Added cmdlet Update-DZConnection leveraging the UpdateConnection service API.
    * Added cmdlet Update-DZProjectProfile leveraging the UpdateProjectProfile service API.
    * Modified cmdlet Add-DZPolicyGrant: added parameters CreateProjectFromProjectProfile_IncludeChildDomainUnit, CreateProjectFromProjectProfile_ProjectProfile and Detail_CreateEnvironmentFromBlueprint.
    * Modified cmdlet Get-DZDataSourceList: added parameter ConnectionIdentifier.
    * Modified cmdlet New-DZDataSource: added parameters ConnectionIdentifier, GlueRunConfiguration_CatalogName and SageMakerRunConfiguration_TrackingAsset.
    * Modified cmdlet New-DZDomain: added parameters DomainVersion and ServiceRole.
    * Modified cmdlet New-DZEnvironment: added parameters DeploymentOrder and EnvironmentConfigurationId.
    * Modified cmdlet New-DZProject: added parameters ProjectProfileId and UserParameter.
    * Modified cmdlet Update-DZDataSource: added parameters GlueRunConfiguration_CatalogName and SageMakerRunConfiguration_TrackingAsset.
    * Modified cmdlet Update-DZDomain: added parameter ServiceRole.
    * Modified cmdlet Update-DZProject: added parameters EnvironmentDeploymentDetails_EnvironmentFailureReason and EnvironmentDeploymentDetails_OverallDeploymentStatus.
    * Modified cmdlet Write-DZEnvironmentBlueprintConfiguration: added parameter EnvironmentRolePermissionBoundary.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBTable: added parameter MultiRegionConsistency.
  * Amazon Glue
    * Added cmdlet Edit-GLUEIntegration leveraging the ModifyIntegration service API.
    * Added cmdlet Get-GLUECatalog leveraging the GetCatalog service API.
    * Added cmdlet Get-GLUECatalogList leveraging the GetCatalogs service API.
    * Added cmdlet Get-GLUEConnectionType leveraging the DescribeConnectionType service API.
    * Added cmdlet Get-GLUEConnectionTypeList leveraging the ListConnectionTypes service API.
    * Added cmdlet Get-GLUEEntity leveraging the DescribeEntity service API.
    * Added cmdlet Get-GLUEEntityList leveraging the ListEntities service API.
    * Added cmdlet Get-GLUEEntityRecord leveraging the GetEntityRecords service API.
    * Added cmdlet Get-GLUEInboundIntegration leveraging the DescribeInboundIntegrations service API.
    * Added cmdlet Get-GLUEIntegration leveraging the DescribeIntegrations service API.
    * Added cmdlet Get-GLUEIntegrationResourceProperty leveraging the GetIntegrationResourceProperty service API.
    * Added cmdlet Get-GLUEIntegrationTableProperty leveraging the GetIntegrationTableProperties service API.
    * Added cmdlet New-GLUECatalog leveraging the CreateCatalog service API.
    * Added cmdlet New-GLUEIntegration leveraging the CreateIntegration service API.
    * Added cmdlet New-GLUEIntegrationResourceProperty leveraging the CreateIntegrationResourceProperty service API.
    * Added cmdlet New-GLUEIntegrationTableProperty leveraging the CreateIntegrationTableProperties service API.
    * Added cmdlet Remove-GLUECatalog leveraging the DeleteCatalog service API.
    * Added cmdlet Remove-GLUEIntegration leveraging the DeleteIntegration service API.
    * Added cmdlet Remove-GLUEIntegrationTableProperty leveraging the DeleteIntegrationTableProperties service API.
    * Added cmdlet Update-GLUECatalog leveraging the UpdateCatalog service API.
    * Added cmdlet Update-GLUEIntegrationResourceProperty leveraging the UpdateIntegrationResourceProperty service API.
    * Added cmdlet Update-GLUEIntegrationTableProperty leveraging the UpdateIntegrationTableProperties service API.
    * Modified cmdlet Get-GLUEConnection: added parameter ApplyOverrideForComputeEnvironment.
    * Modified cmdlet Test-GLUEConnection: added parameters AuthenticationConfiguration_CustomAuthenticationCredential, AuthenticationConfiguration_KmsKeyArn, BasicAuthenticationCredentials_Password, BasicAuthenticationCredentials_Username, CatalogId, OAuth2Credentials_AccessToken, OAuth2Credentials_JwtToken, OAuth2Credentials_RefreshToken and OAuth2Credentials_UserManagedClientApplicationClientSecret.
  * Amazon Lake Formation
    * [Breaking Change] Modified cmdlet Add-LKFLFTagsToResource: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Get-LKFLakeFormationOptInList: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Get-LKFPermissionList: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Get-LKFResourceLFTag: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Grant-LKFPermission: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet New-LKFLakeFormationOptIn: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Remove-LKFLakeFormationOptIn: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Remove-LKFLFTagsFromResource: removed parameter Resource_Catalog; added parameter Catalog_Id.
    * [Breaking Change] Modified cmdlet Revoke-LKFPermission: removed parameter Resource_Catalog; added parameter Catalog_Id.
  * Amazon QBusiness
    * Added cmdlet Add-QBUSPermission leveraging the AssociatePermission service API.
    * Added cmdlet Get-QBUSDataAccessor leveraging the GetDataAccessor service API.
    * Added cmdlet Get-QBUSDataAccessorList leveraging the ListDataAccessors service API.
    * Added cmdlet Get-QBUSPluginActionList leveraging the ListPluginActions service API.
    * Added cmdlet Get-QBUSPluginTypeActionList leveraging the ListPluginTypeActions service API.
    * Added cmdlet Get-QBUSPluginTypeMetadataList leveraging the ListPluginTypeMetadata service API.
    * Added cmdlet Get-QBUSPolicy leveraging the GetPolicy service API.
    * Added cmdlet New-QBUSDataAccessor leveraging the CreateDataAccessor service API.
    * Added cmdlet Remove-QBUSDataAccessor leveraging the DeleteDataAccessor service API.
    * Added cmdlet Remove-QBUSPermission leveraging the DisassociatePermission service API.
    * Added cmdlet Search-QBUSRelevantContent leveraging the SearchRelevantContent service API.
    * Added cmdlet Update-QBUSDataAccessor leveraging the UpdateDataAccessor service API.
    * Modified cmdlet New-QBUSApplication: added parameter QuickSightConfiguration_ClientNamespace.
    * Modified cmdlet New-QBUSPlugin: added parameters IdcAuthConfiguration_IdcApplicationArn, IdcAuthConfiguration_RoleArn, OAuth2ClientCredentialConfiguration_AuthorizationUrl and OAuth2ClientCredentialConfiguration_TokenUrl.
    * Modified cmdlet New-QBUSWebExperience: added parameters CustomizationConfiguration_CustomCSSUrl, CustomizationConfiguration_FaviconUrl, CustomizationConfiguration_FontUrl and CustomizationConfiguration_LogoUrl.
    * Modified cmdlet Update-QBUSPlugin: added parameters IdcAuthConfiguration_IdcApplicationArn, IdcAuthConfiguration_RoleArn, OAuth2ClientCredentialConfiguration_AuthorizationUrl and OAuth2ClientCredentialConfiguration_TokenUrl.
    * Modified cmdlet Update-QBUSWebExperience: added parameters CustomizationConfiguration_CustomCSSUrl, CustomizationConfiguration_FaviconUrl, CustomizationConfiguration_FontUrl and CustomizationConfiguration_LogoUrl.
  * Amazon QuickSight
    * Added cmdlet Get-QSDefaultQBusinessApplication leveraging the DescribeDefaultQBusinessApplication service API.
    * Added cmdlet Get-QSQuickSightQSearchConfiguration leveraging the DescribeQuickSightQSearchConfiguration service API.
    * Added cmdlet Initialize-QSEmbedUrlForRegisteredUserWithIdentity leveraging the GenerateEmbedUrlForRegisteredUserWithIdentity service API.
    * Added cmdlet Remove-QSDefaultQBusinessApplication leveraging the DeleteDefaultQBusinessApplication service API.
    * Added cmdlet Search-QSQAResult leveraging the PredictQAResults service API.
    * Added cmdlet Update-QSApplicationWithTokenExchangeGrant leveraging the UpdateApplicationWithTokenExchangeGrant service API.
    * Added cmdlet Update-QSDefaultQBusinessApplication leveraging the UpdateDefaultQBusinessApplication service API.
    * Added cmdlet Update-QSQuickSightQSearchConfiguration leveraging the UpdateQuickSightQSearchConfiguration service API.
  * Amazon Redshift
    * Added cmdlet Register-RSNamespace leveraging the RegisterNamespace service API.
    * Added cmdlet Unregister-RSNamespace leveraging the DeregisterNamespace service API.
  * Amazon Redshift Serverless
    * Added cmdlet Get-RSSManagedWorkgroupList leveraging the ListManagedWorkgroups service API.
  * Amazon S3 Tables. Added cmdlets to support the service. Cmdlets for the service have the noun prefix S3T and can be listed using the command 'Get-AWSCmdletName -Service S3T'.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3BucketMetadataTableConfiguration leveraging the GetBucketMetadataTableConfiguration service API.
    * Added cmdlet New-S3BucketMetadataTableConfiguration leveraging the CreateBucketMetadataTableConfiguration service API.
    * Added cmdlet Remove-S3BucketMetadataTableConfiguration leveraging the DeleteBucketMetadataTableConfiguration service API.

### 4.1.710 (2024-12-03 08:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.938.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Runtime
    * Modified cmdlet Invoke-BDRRConverse: added parameter PerformanceConfig_Latency.
    * Modified cmdlet Invoke-BDRRConverseStream: added parameter PerformanceConfig_Latency.
    * Modified cmdlet Invoke-BDRRModel: added parameter PerformanceConfigLatency.
    * Modified cmdlet Invoke-BDRRModelWithResponseStream: added parameter PerformanceConfigLatency.

### 4.1.709 (2024-12-02 06:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.937.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Added cmdlet Add-AABKnowledgeBaseDocument leveraging the IngestKnowledgeBaseDocuments service API.
    * Added cmdlet Get-AABKnowledgeBaseDocument leveraging the GetKnowledgeBaseDocuments service API.
    * Added cmdlet Get-AABKnowledgeBaseDocumentList leveraging the ListKnowledgeBaseDocuments service API.
    * Added cmdlet Remove-AABKnowledgeBaseDocument leveraging the DeleteKnowledgeBaseDocuments service API.
  * Amazon AmazonConnectCampaignServiceV2
    * Added cmdlet Write-CCS2ProfileOutboundRequestBatch leveraging the PutProfileOutboundRequestBatch service API.
    * Modified cmdlet New-CCS2Campaign: added parameter EventTrigger_CustomerProfilesDomainArn.
    * Modified cmdlet Update-CCS2CampaignSource: added parameter EventTrigger_CustomerProfilesDomainArn.
  * Amazon Bedrock
    * Modified cmdlet Get-BDREvaluationJobList: added parameter ApplicationTypeEqual.
    * Modified cmdlet New-BDREvaluationJob: added parameters ApplicationType, EvaluatorModelConfig_BedrockEvaluatorModel and InferenceConfig_RagConfig.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Invoke-BARRerank leveraging the Rerank service API.
    * Added cmdlet Invoke-BARRetrieveAndGenerateStream leveraging the RetrieveAndGenerateStream service API.
    * Modified cmdlet Invoke-BARRetrieve: added parameters BedrockRerankingConfiguration_NumberOfRerankedResult, GuardrailConfiguration_GuardrailId, GuardrailConfiguration_GuardrailVersion, ImplicitFilterConfiguration_MetadataAttribute, ImplicitFilterConfiguration_ModelArn, MetadataConfiguration_SelectionMode, ModelConfiguration_AdditionalModelRequestField, ModelConfiguration_ModelArn, RerankingConfiguration_Type, SelectiveModeConfiguration_FieldsToExclude and SelectiveModeConfiguration_FieldsToInclude.
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters BedrockRerankingConfiguration_NumberOfRerankedResult, ImplicitFilterConfiguration_MetadataAttribute, ImplicitFilterConfiguration_ModelArn, MetadataConfiguration_SelectionMode, ModelConfiguration_AdditionalModelRequestField, ModelConfiguration_ModelArn, RerankingConfiguration_Type, SelectiveModeConfiguration_FieldsToExclude and SelectiveModeConfiguration_FieldsToInclude.
  * Amazon Chime SDK Voice
    * Added cmdlet Get-CHMVOVoiceConnectorExternalSystemsConfiguration leveraging the GetVoiceConnectorExternalSystemsConfiguration service API.
    * Added cmdlet Remove-CHMVOVoiceConnectorExternalSystemsConfiguration leveraging the DeleteVoiceConnectorExternalSystemsConfiguration service API.
    * Added cmdlet Write-CHMVOVoiceConnectorExternalSystemsConfiguration leveraging the PutVoiceConnectorExternalSystemsConfiguration service API.
    * Modified cmdlet New-CHMVOVoiceConnector: added parameter IntegrationType.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSConfiguredTable: added parameters Athena_DatabaseName, Athena_OutputLocation, Athena_TableName, Athena_WorkGroup, Snowflake_AccountIdentifier, Snowflake_DatabaseName, Snowflake_SchemaName, Snowflake_SecretArn, Snowflake_TableName and TableSchema_V1.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLIntegration leveraging the GetIntegration service API.
    * Added cmdlet Get-CWLIntegrationList leveraging the ListIntegrations service API.
    * Added cmdlet Remove-CWLIntegration leveraging the DeleteIntegration service API.
    * Added cmdlet Write-CWLIntegration leveraging the PutIntegration service API.
    * Modified cmdlet Get-CWLQuery: added parameter QueryLanguage.
    * Modified cmdlet Get-CWLQueryDefinition: added parameter QueryLanguage.
    * Modified cmdlet Start-CWLQuery: added parameter QueryLanguage.
    * Modified cmdlet Write-CWLQueryDefinition: added parameter QueryLanguage.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFEventTrigger leveraging the GetEventTrigger service API.
    * Added cmdlet Get-CPFEventTriggerList leveraging the ListEventTriggers service API.
    * Added cmdlet New-CPFEventTrigger leveraging the CreateEventTrigger service API.
    * Added cmdlet Remove-CPFEventTrigger leveraging the DeleteEventTrigger service API.
    * Added cmdlet Update-CPFEventTrigger leveraging the UpdateEventTrigger service API.
    * Modified cmdlet Write-CPFIntegration: added parameter EventTriggerName.
  * Amazon Connect Service
    * Modified cmdlet Resume-CONNContactRecording: added parameter ContactRecordingType.
    * Modified cmdlet Start-CONNContactRecording: added parameter VoiceRecordingConfiguration_IvrRecordingTrack.
    * Modified cmdlet Stop-CONNContactRecording: added parameter ContactRecordingType.
    * Modified cmdlet Suspend-CONNContactRecording: added parameter ContactRecordingType.
    * Modified cmdlet Update-CONNContact: added parameters CustomerEndpoint_Address, CustomerEndpoint_Type, QueueInfo_Id, SystemEndpoint_Address, SystemEndpoint_Type and UserInfo_UserId.
  * Amazon EC2 Image Builder
    * Added cmdlet Get-EC2IBMarketplaceResource leveraging the GetMarketplaceResource service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2AllowedImagesSetting leveraging the DisableAllowedImagesSettings service API.
    * Added cmdlet Enable-EC2AllowedImagesSetting leveraging the EnableAllowedImagesSettings service API.
    * Added cmdlet Export-EC2VerifiedAccessInstanceClientConfiguration leveraging the ExportVerifiedAccessInstanceClientConfiguration service API.
    * Added cmdlet Get-EC2AllowedImagesSetting leveraging the GetAllowedImagesSettings service API.
    * Added cmdlet Get-EC2DeclarativePoliciesReport leveraging the DescribeDeclarativePoliciesReports service API.
    * Added cmdlet Get-EC2DeclarativePoliciesReportSummary leveraging the GetDeclarativePoliciesReportSummary service API.
    * Added cmdlet Get-EC2VerifiedAccessEndpointTarget leveraging the GetVerifiedAccessEndpointTargets service API.
    * Added cmdlet Get-EC2VpcEndpointAssociation leveraging the DescribeVpcEndpointAssociations service API.
    * Added cmdlet Set-EC2ImageCriteriaInAllowedImagesSetting leveraging the ReplaceImageCriteriaInAllowedImagesSettings service API.
    * Added cmdlet Start-EC2DeclarativePoliciesReport leveraging the StartDeclarativePoliciesReport service API.
    * Added cmdlet Stop-EC2DeclarativePoliciesReport leveraging the CancelDeclarativePoliciesReport service API.
    * Modified cmdlet Edit-EC2VerifiedAccessEndpoint: added parameters CidrOptions_PortRange, LoadBalancerOptions_PortRange, NetworkInterfaceOptions_PortRange, RdsOptions_Port, RdsOptions_RdsEndpoint and RdsOptions_SubnetId.
    * Modified cmdlet Edit-EC2VerifiedAccessInstance: added parameter CidrEndpointsCustomSubDomain.
    * Modified cmdlet Edit-EC2VerifiedAccessTrustProvider: added parameters NativeApplicationOidcOptions_AuthorizationEndpoint, NativeApplicationOidcOptions_ClientId, NativeApplicationOidcOptions_ClientSecret, NativeApplicationOidcOptions_Issuer, NativeApplicationOidcOptions_PublicSigningKeyEndpoint, NativeApplicationOidcOptions_Scope, NativeApplicationOidcOptions_TokenEndpoint and NativeApplicationOidcOptions_UserInfoEndpoint.
    * Modified cmdlet New-EC2VerifiedAccessEndpoint: added parameters CidrOptions_Cidr, CidrOptions_PortRange, CidrOptions_Protocol, CidrOptions_SubnetId, LoadBalancerOptions_PortRange, NetworkInterfaceOptions_PortRange, RdsOptions_Port, RdsOptions_Protocol, RdsOptions_RdsDbClusterArn, RdsOptions_RdsDbInstanceArn, RdsOptions_RdsDbProxyArn, RdsOptions_RdsEndpoint and RdsOptions_SubnetId.
    * Modified cmdlet New-EC2VerifiedAccessInstance: added parameter CidrEndpointsCustomSubDomain.
    * Modified cmdlet New-EC2VerifiedAccessTrustProvider: added parameters NativeApplicationOidcOptions_AuthorizationEndpoint, NativeApplicationOidcOptions_ClientId, NativeApplicationOidcOptions_ClientSecret, NativeApplicationOidcOptions_Issuer, NativeApplicationOidcOptions_PublicSigningKeyEndpoint, NativeApplicationOidcOptions_Scope, NativeApplicationOidcOptions_TokenEndpoint and NativeApplicationOidcOptions_UserInfoEndpoint.
    * Modified cmdlet New-EC2VpcEndpoint: added parameters ResourceConfigurationArn and ServiceNetworkArn.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameters BlockStorage_Enabled, ComputeConfig_Enabled, ComputeConfig_NodePool, ComputeConfig_NodeRoleArn, ElasticLoadBalancing_Enabled, RemoteNetworkConfig_RemoteNodeNetwork and RemoteNetworkConfig_RemotePodNetwork.
    * Modified cmdlet Update-EKSClusterConfig: added parameters BlockStorage_Enabled, ComputeConfig_Enabled, ComputeConfig_NodePool, ComputeConfig_NodeRoleArn, ElasticLoadBalancing_Enabled, KubernetesNetworkConfig_IpFamily and KubernetesNetworkConfig_ServiceIpv4Cidr.
  * Amazon EventBridge
    * Modified cmdlet New-EVBConnection: added parameters AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn and InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn.
    * Modified cmdlet Update-EVBConnection: added parameters AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn and InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn.
  * Amazon FSx
    * Modified cmdlet New-FSXFileSystem: added parameters ReadCacheConfiguration_SizeGiB and ReadCacheConfiguration_SizingMode.
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameters ReadCacheConfiguration_SizeGiB and ReadCacheConfiguration_SizingMode.
    * Modified cmdlet Update-FSXFileSystem: added parameters ReadCacheConfiguration_SizeGiB and ReadCacheConfiguration_SizingMode.
  * Amazon Invoicing. Added cmdlets to support the service. Cmdlets for the service have the noun prefix INV and can be listed using the command 'Get-AWSCmdletName -Service INV'.
  * Amazon MemoryDB
    * Added cmdlet Get-MDBAllowedMultiRegionClusterUpdateList leveraging the ListAllowedMultiRegionClusterUpdates service API.
    * Added cmdlet Get-MDBMultiRegionCluster leveraging the DescribeMultiRegionClusters service API.
    * Added cmdlet New-MDBMultiRegionCluster leveraging the CreateMultiRegionCluster service API.
    * Added cmdlet Remove-MDBMultiRegionCluster leveraging the DeleteMultiRegionCluster service API.
    * Added cmdlet Update-MDBMultiRegionCluster leveraging the UpdateMultiRegionCluster service API.
    * Modified cmdlet New-MDBCluster: added parameter MultiRegionClusterName.
    * Modified cmdlet Remove-MDBCluster: added parameter MultiRegionClusterName.
  * Amazon Network Flow Monitor. Added cmdlets to support the service. Cmdlets for the service have the noun prefix NFM and can be listed using the command 'Get-AWSCmdletName -Service NFM'.
  * Amazon OpenSearch Service
    * Added cmdlet Add-OSDirectQueryDataSource leveraging the AddDirectQueryDataSource service API.
    * Added cmdlet Get-OSDirectQueryDataSource leveraging the GetDirectQueryDataSource service API.
    * Added cmdlet Get-OSDirectQueryDataSourceList leveraging the ListDirectQueryDataSources service API.
    * Added cmdlet Remove-OSDirectQueryDataSource leveraging the DeleteDirectQueryDataSource service API.
    * Added cmdlet Update-OSDirectQueryDataSource leveraging the UpdateDirectQueryDataSource service API.
  * Amazon Q Connect
    * Added cmdlet Get-QCAIGuardrail leveraging the GetAIGuardrail service API.
    * Added cmdlet Get-QCAIGuardrailList leveraging the ListAIGuardrails service API.
    * Added cmdlet Get-QCAIGuardrailVersionList leveraging the ListAIGuardrailVersions service API.
    * Added cmdlet Get-QCMessageList leveraging the ListMessages service API.
    * Added cmdlet Get-QCNextMessage leveraging the GetNextMessage service API.
    * Added cmdlet New-QCAIGuardrail leveraging the CreateAIGuardrail service API.
    * Added cmdlet New-QCAIGuardrailVersion leveraging the CreateAIGuardrailVersion service API.
    * Added cmdlet Remove-QCAIGuardrail leveraging the DeleteAIGuardrail service API.
    * Added cmdlet Remove-QCAIGuardrailVersion leveraging the DeleteAIGuardrailVersion service API.
    * Added cmdlet Send-QCMessage leveraging the SendMessage service API.
    * Added cmdlet Update-QCAIGuardrail leveraging the UpdateAIGuardrail service API.
    * Modified cmdlet New-QCAIAgent: added parameters AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId, ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId, SelfServiceAIAgentConfiguration_AssociationConfiguration, SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId, SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId and SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId.
    * Modified cmdlet Update-QCAIAgent: added parameters AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIGuardrailId, ManualSearchAIAgentConfiguration_AnswerGenerationAIGuardrailId, SelfServiceAIAgentConfiguration_AssociationConfiguration, SelfServiceAIAgentConfiguration_SelfServiceAIGuardrailId, SelfServiceAIAgentConfiguration_SelfServiceAnswerGenerationAIPromptId and SelfServiceAIAgentConfiguration_SelfServicePreProcessingAIPromptId.
  * Amazon QBusiness
    * Added cmdlet Get-QBUSAttachmentList leveraging the ListAttachments service API.
    * Added cmdlet Get-QBUSMedia leveraging the GetMedia service API.
    * Modified cmdlet New-QBUSDataSource: added parameter ImageExtractionConfiguration_ImageExtractionStatus.
    * Modified cmdlet New-QBUSWebExperience: added parameter BrowserExtensionConfiguration_EnabledBrowserExtension.
    * Modified cmdlet Update-QBUSDataSource: added parameter ImageExtractionConfiguration_ImageExtractionStatus.
    * Modified cmdlet Update-QBUSWebExperience: added parameter BrowserExtensionConfiguration_EnabledBrowserExtension.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter DatabaseInsightsMode.
    * Modified cmdlet Edit-RDSDBInstance: added parameter DatabaseInsightsMode.
    * Modified cmdlet New-RDSDBCluster: added parameter DatabaseInsightsMode.
    * Modified cmdlet New-RDSDBInstance: added parameter DatabaseInsightsMode.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter DatabaseInsightsMode.
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter DatabaseInsightsMode.
  * Amazon Security Incident Response. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SecurityIR and can be listed using the command 'Get-AWSCmdletName -Service SecurityIR'.
  * Amazon Transfer for SFTP
    * Added cmdlet Get-TFRWebApp leveraging the DescribeWebApp service API.
    * Added cmdlet Get-TFRWebAppCustomization leveraging the DescribeWebAppCustomization service API.
    * Added cmdlet Get-TFRWebAppList leveraging the ListWebApps service API.
    * Added cmdlet New-TFRWebApp leveraging the CreateWebApp service API.
    * Added cmdlet Remove-TFRWebApp leveraging the DeleteWebApp service API.
    * Added cmdlet Remove-TFRWebAppCustomization leveraging the DeleteWebAppCustomization service API.
    * Added cmdlet Update-TFRWebApp leveraging the UpdateWebApp service API.
    * Added cmdlet Update-TFRWebAppCustomization leveraging the UpdateWebAppCustomization service API.
  * Amazon VPC Lattice
    * Added cmdlet Get-VPCLResourceConfiguration leveraging the GetResourceConfiguration service API.
    * Added cmdlet Get-VPCLResourceConfigurationList leveraging the ListResourceConfigurations service API.
    * Added cmdlet Get-VPCLResourceEndpointAssociationList leveraging the ListResourceEndpointAssociations service API.
    * Added cmdlet Get-VPCLResourceGateway leveraging the GetResourceGateway service API.
    * Added cmdlet Get-VPCLResourceGatewayList leveraging the ListResourceGateways service API.
    * Added cmdlet Get-VPCLServiceNetworkResourceAssociation leveraging the GetServiceNetworkResourceAssociation service API.
    * Added cmdlet Get-VPCLServiceNetworkResourceAssociationList leveraging the ListServiceNetworkResourceAssociations service API.
    * Added cmdlet Get-VPCLServiceNetworkVpcEndpointAssociationList leveraging the ListServiceNetworkVpcEndpointAssociations service API.
    * Added cmdlet New-VPCLResourceConfiguration leveraging the CreateResourceConfiguration service API.
    * Added cmdlet New-VPCLResourceGateway leveraging the CreateResourceGateway service API.
    * Added cmdlet New-VPCLServiceNetworkResourceAssociation leveraging the CreateServiceNetworkResourceAssociation service API.
    * Added cmdlet Remove-VPCLResourceConfiguration leveraging the DeleteResourceConfiguration service API.
    * Added cmdlet Remove-VPCLResourceEndpointAssociation leveraging the DeleteResourceEndpointAssociation service API.
    * Added cmdlet Remove-VPCLResourceGateway leveraging the DeleteResourceGateway service API.
    * Added cmdlet Remove-VPCLServiceNetworkResourceAssociation leveraging the DeleteServiceNetworkResourceAssociation service API.
    * Added cmdlet Update-VPCLResourceConfiguration leveraging the UpdateResourceConfiguration service API.
    * Added cmdlet Update-VPCLResourceGateway leveraging the UpdateResourceGateway service API.
    * Modified cmdlet New-VPCLAccessLogSubscription: added parameter ServiceNetworkLogType.
    * Modified cmdlet New-VPCLServiceNetwork: added parameter SharingConfig_Enabled.

### 4.1.708 (2024-11-27 23:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.936.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameter BedrockEmbeddingModelConfiguration_EmbeddingDataType.
    * Modified cmdlet Update-AABKnowledgeBase: added parameter BedrockEmbeddingModelConfiguration_EmbeddingDataType.
  * Amazon CloudWatch Observability Admin Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CWOADMN and can be listed using the command 'Get-AWSCmdletName -Service CWOADMN'.
  * Amazon Config
    * Added cmdlet Add-CFGResourceType leveraging the AssociateResourceTypes service API.
    * Added cmdlet Get-CFGConfigurationRecorderList leveraging the ListConfigurationRecorders service API.
    * Added cmdlet Remove-CFGResourceType leveraging the DisassociateResourceTypes service API.
    * Added cmdlet Remove-CFGServiceLinkedConfigurationRecorder leveraging the DeleteServiceLinkedConfigurationRecorder service API.
    * Added cmdlet Write-CFGServiceLinkedConfigurationRecorder leveraging the PutServiceLinkedConfigurationRecorder service API.
    * Modified cmdlet Get-CFGConfigurationRecorder: added parameters Arn and ServicePrincipal.
    * Modified cmdlet Get-CFGConfigurationRecorderStatus: added parameters Arn and ServicePrincipal.
    * Modified cmdlet Write-CFGConfigurationAggregator: added parameters ResourceType_Type, ResourceType_Value, ServicePrincipal_Type and ServicePrincipal_Value.
    * Modified cmdlet Write-CFGConfigurationRecorder: added parameters ConfigurationRecorder_Arn, ConfigurationRecorder_RecordingScope, ConfigurationRecorder_ServicePrincipal and Tag.

### 4.1.707 (2024-11-26 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.935.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABAgent: added parameters Executor_Lambda and OrchestrationType.
    * Modified cmdlet Update-AABAgent: added parameters Executor_Lambda and OrchestrationType.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARAgent: added parameters StreamingConfigurations_ApplyGuardrailInterval and StreamingConfigurations_StreamFinalResponse.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Copy-EC2Snapshot: added parameter CompletionDurationMinute.
    * Modified cmdlet Edit-EC2VpcEndpointServiceConfiguration: added parameters AddSupportedRegion and RemoveSupportedRegion.
    * Modified cmdlet Get-EC2VpcEndpointService: added parameter ServiceRegion.
    * Modified cmdlet New-EC2VpcEndpoint: added parameter ServiceRegion.
    * Modified cmdlet New-EC2VpcEndpointServiceConfiguration: added parameter SupportedRegion.
  * Amazon Q Apps
    * Added cmdlet Export-qappsQAppSessionData leveraging the ExportQAppSessionData service API.
    * Added cmdlet Get-qappsQAppPermission leveraging the DescribeQAppPermissions service API.
    * Added cmdlet Get-qappsQAppSessionDataList leveraging the ListQAppSessionData service API.
    * Added cmdlet Get-qappsQAppSessionMetadata leveraging the GetQAppSessionMetadata service API.
    * Added cmdlet New-qappsPresignedUrl leveraging the CreatePresignedUrl service API.
    * Added cmdlet Update-qappsQAppPermission leveraging the UpdateQAppPermissions service API.
    * Added cmdlet Update-qappsQAppSessionMetadata leveraging the UpdateQAppSessionMetadata service API.
    * Modified cmdlet Get-qappsQApp: added parameter AppVersion.
    * Modified cmdlet Start-qappsQAppSession: added parameter SessionId.

### 4.1.706 (2024-11-25 21:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.934.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Network Manager
    * Added cmdlet Get-NMGRDirectConnectGatewayAttachment leveraging the GetDirectConnectGatewayAttachment service API.
    * Added cmdlet New-NMGRDirectConnectGatewayAttachment leveraging the CreateDirectConnectGatewayAttachment service API.
    * Added cmdlet Update-NMGRDirectConnectGatewayAttachment leveraging the UpdateDirectConnectGatewayAttachment service API.

### 4.1.705 (2024-11-22 21:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.933.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet Write-ASScalingPolicy: added parameter CustomizedMetricSpecification_Period.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Invoke-BARInlineAgent leveraging the InvokeInlineAgent service API.
  * Amazon Chatbot
    * Added cmdlet Get-CHATAssociationList leveraging the ListAssociations service API.
    * Added cmdlet Get-CHATCustomAction leveraging the GetCustomAction service API.
    * Added cmdlet Get-CHATCustomActionList leveraging the ListCustomActions service API.
    * Added cmdlet New-CHATCustomAction leveraging the CreateCustomAction service API.
    * Added cmdlet Register-CHATAssociation leveraging the AssociateToConfiguration service API.
    * Added cmdlet Remove-CHATCustomAction leveraging the DeleteCustomAction service API.
    * Added cmdlet Unregister-CHATAssociation leveraging the DisassociateFromConfiguration service API.
    * Added cmdlet Update-CHATCustomAction leveraging the UpdateCustomAction service API.
  * Amazon Cognito Identity Provider
    * Added cmdlet Complete-CGIPWebAuthnRegistration leveraging the CompleteWebAuthnRegistration service API.
    * Added cmdlet Get-CGIPManagedLoginBranding leveraging the DescribeManagedLoginBranding service API.
    * Added cmdlet Get-CGIPManagedLoginBrandingByClient leveraging the DescribeManagedLoginBrandingByClient service API.
    * Added cmdlet Get-CGIPUserAuthFactor leveraging the GetUserAuthFactors service API.
    * Added cmdlet Get-CGIPWebAuthnCredentialList leveraging the ListWebAuthnCredentials service API.
    * Added cmdlet New-CGIPManagedLoginBranding leveraging the CreateManagedLoginBranding service API.
    * Added cmdlet Remove-CGIPManagedLoginBranding leveraging the DeleteManagedLoginBranding service API.
    * Added cmdlet Remove-CGIPWebAuthnCredential leveraging the DeleteWebAuthnCredential service API.
    * Added cmdlet Start-CGIPWebAuthnRegistration leveraging the StartWebAuthnRegistration service API.
    * Added cmdlet Update-CGIPManagedLoginBranding leveraging the UpdateManagedLoginBranding service API.
    * Modified cmdlet Confirm-CGIPUserRegistration: added parameter Session.
    * Modified cmdlet New-CGIPUserPool: added parameters SignInPolicy_AllowedFirstAuthFactor and UserPoolTier.
    * Modified cmdlet New-CGIPUserPoolDomain: added parameter ManagedLoginVersion.
    * Modified cmdlet Set-CGIPUserPoolMfaConfig: added parameters WebAuthnConfiguration_RelyingPartyId and WebAuthnConfiguration_UserVerification.
    * Modified cmdlet Start-CGIPAuth: added parameter Session.
    * Modified cmdlet Start-CGIPAuthAdmin: added parameter Session.
    * Modified cmdlet Update-CGIPUserPool: added parameters PoolName, SignInPolicy_AllowedFirstAuthFactor and UserPoolTier.
    * Modified cmdlet Update-CGIPUserPoolDomain: added parameter ManagedLoginVersion.
  * Amazon Connect Service
    * Added cmdlet Get-CONNAssociatedContactList leveraging the ListAssociatedContacts service API.
    * Added cmdlet Get-CONNEmailAddress leveraging the DescribeEmailAddress service API.
    * Added cmdlet New-CONNContact leveraging the CreateContact service API.
    * Added cmdlet New-CONNEmailAddress leveraging the CreateEmailAddress service API.
    * Added cmdlet Remove-CONNEmailAddress leveraging the DeleteEmailAddress service API.
    * Added cmdlet Search-CONNEmailAddress leveraging the SearchEmailAddresses service API.
    * Added cmdlet Send-CONNOutboundEmail leveraging the SendOutboundEmail service API.
    * Added cmdlet Start-CONNEmailContact leveraging the StartEmailContact service API.
    * Added cmdlet Start-CONNOutboundEmailContact leveraging the StartOutboundEmailContact service API.
    * Added cmdlet Update-CONNEmailAddressMetadata leveraging the UpdateEmailAddressMetadata service API.
    * Added cmdlet Update-CONNQueueOutboundEmailConfig leveraging the UpdateQueueOutboundEmailConfig service API.
    * Modified cmdlet New-CONNQueue: added parameter OutboundEmailConfig_OutboundEmailAddressId.
    * Modified cmdlet New-CONNTaskTemplate: added parameter SelfAssignFlowId.
    * Modified cmdlet Search-CONNContact: added parameters SearchableSegmentAttributes_Criterion and SearchableSegmentAttributes_MatchType.
    * Modified cmdlet Start-CONNTaskContact: added parameter SegmentAttribute.
    * Modified cmdlet Update-CONNContact: added parameter SegmentAttribute.
    * Modified cmdlet Update-CONNTaskTemplate: added parameter SelfAssignFlowId.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Edit-ELB2Listener: added parameter MutualAuthentication_AdvertiseTrustStoreCaName.
    * Modified cmdlet New-ELB2Listener: added parameter MutualAuthentication_AdvertiseTrustStoreCaName.
  * Amazon Elastic MapReduce
    * Modified cmdlet Start-EMRJobFlow: added parameters ManagedScalingPolicy_ScalingStrategy and ManagedScalingPolicy_UtilizationPerformanceIndex.
    * Modified cmdlet Write-EMRManagedScalingPolicy: added parameters ManagedScalingPolicy_ScalingStrategy and ManagedScalingPolicy_UtilizationPerformanceIndex.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameters ProvisionedPollerConfig_MaximumPoller and ProvisionedPollerConfig_MinimumPoller.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters ProvisionedPollerConfig_MaximumPoller and ProvisionedPollerConfig_MinimumPoller.
  * Amazon Neptune Graph
    * Added cmdlet Get-NEPTGExportTask leveraging the GetExportTask service API.
    * Added cmdlet Get-NEPTGExportTaskList leveraging the ListExportTasks service API.
    * Added cmdlet Start-NEPTGExportTask leveraging the StartExportTask service API.
    * Added cmdlet Stop-NEPTGExportTask leveraging the CancelExportTask service API.
    * Modified cmdlet New-NEPTGGraphUsingImportTask: added parameter ParquetType.
    * Modified cmdlet Start-NEPTGImportTask: added parameter ParquetType.
  * Amazon Omics
    * Added cmdlet Get-OMICSS3AccessPolicy leveraging the GetS3AccessPolicy service API.
    * Added cmdlet Remove-OMICSS3AccessPolicy leveraging the DeleteS3AccessPolicy service API.
    * Added cmdlet Update-OMICSSequenceStore leveraging the UpdateSequenceStore service API.
    * Added cmdlet Write-OMICSS3AccessPolicy leveraging the PutS3AccessPolicy service API.
    * Modified cmdlet Get-OMICSSequenceStoreList: added parameters Filter_Status, Filter_UpdatedAfter and Filter_UpdatedBefore.
    * Modified cmdlet New-OMICSSequenceStore: added parameters PropagatedSetLevelTag and S3AccessConfig_AccessLogLocation.
  * Amazon Pricing Calculator. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BCMPC and can be listed using the command 'Get-AWSCmdletName -Service BCMPC'.
  * Amazon QuickSight
    * Added cmdlet Get-QSDashboardsQAConfiguration leveraging the DescribeDashboardsQAConfiguration service API.
    * Added cmdlet Search-QSTopic leveraging the SearchTopics service API.
    * Added cmdlet Update-QSDashboardsQAConfiguration leveraging the UpdateDashboardsQAConfiguration service API.
    * Modified cmdlet New-QSAnalysis: added parameter Definition_StaticFile.
    * Modified cmdlet New-QSDashboard: added parameter Definition_StaticFile.
    * Modified cmdlet New-QSTemplate: added parameter Definition_StaticFile.
    * Modified cmdlet New-QSTopic: added parameter FolderArn.
    * Modified cmdlet Update-QSAnalysis: added parameter Definition_StaticFile.
    * Modified cmdlet Update-QSDashboard: added parameter Definition_StaticFile.
    * Modified cmdlet Update-QSTemplate: added parameter Definition_StaticFile.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceComponent: added parameter Specification_BaseInferenceComponentName.
    * Modified cmdlet Update-SMInferenceComponent: added parameter Specification_BaseInferenceComponentName.
  * Amazon Step Functions
    * Modified cmdlet Test-SFNState: added parameter Variable.

### 4.1.704 (2024-11-21 22:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.932.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Added cmdlet Disable-AGDomainNameAccessAssociation leveraging the RejectDomainNameAccessAssociation service API.
    * Added cmdlet Get-AGDomainNameAccessAssociation leveraging the GetDomainNameAccessAssociations service API.
    * Added cmdlet New-AGDomainNameAccessAssociation leveraging the CreateDomainNameAccessAssociation service API.
    * Added cmdlet Remove-AGDomainNameAccessAssociation leveraging the DeleteDomainNameAccessAssociation service API.
    * Modified cmdlet Get-AGBasePathMapping: added parameter DomainNameId.
    * Modified cmdlet Get-AGBasePathMappingList: added parameter DomainNameId.
    * Modified cmdlet Get-AGDomainName: added parameter DomainNameId.
    * Modified cmdlet Get-AGDomainNameList: added parameter ResourceOwner.
    * Modified cmdlet New-AGBasePathMapping: added parameter DomainNameId.
    * Modified cmdlet New-AGDomainName: added parameter Policy.
    * Modified cmdlet Remove-AGBasePathMapping: added parameter DomainNameId.
    * Modified cmdlet Remove-AGDomainName: added parameter DomainNameId.
    * Modified cmdlet Update-AGBasePathMapping: added parameter DomainNameId.
    * Modified cmdlet Update-AGDomainName: added parameter DomainNameId.
  * Amazon Application Auto Scaling
    * Added cmdlet Get-AASPredictiveScalingForecast leveraging the GetPredictiveScalingForecast service API.
    * Modified cmdlet Set-AASScalingPolicy: added parameters PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior, PredictiveScalingPolicyConfiguration_MaxCapacityBuffer, PredictiveScalingPolicyConfiguration_MetricSpecification, PredictiveScalingPolicyConfiguration_Mode and PredictiveScalingPolicyConfiguration_SchedulingBufferTime.
  * Amazon CloudTrail
    * Added cmdlet Get-CTDashboard leveraging the GetDashboard service API.
    * Added cmdlet Get-CTDashboardSummary leveraging the ListDashboards service API.
    * Added cmdlet New-CTDashboard leveraging the CreateDashboard service API.
    * Added cmdlet Remove-CTDashboard leveraging the DeleteDashboard service API.
    * Added cmdlet Start-CTDashboardRefresh leveraging the StartDashboardRefresh service API.
    * Added cmdlet Update-CTDashboard leveraging the UpdateDashboard service API.
    * Modified cmdlet Get-CTQuery: added parameters EventDataStoreOwnerAccountId and RefreshId.
    * Modified cmdlet Get-CTQueryResult: added parameter EventDataStoreOwnerAccountId.
    * Modified cmdlet Start-CTQuery: added parameter EventDataStoreOwnerAccountId.
    * Modified cmdlet Stop-CTQuery: added parameter EventDataStoreOwnerAccountId.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLFieldIndex leveraging the DescribeFieldIndexes service API.
    * Added cmdlet Get-CWLIndexPolicy leveraging the DescribeIndexPolicies service API.
    * Added cmdlet Get-CWLLogGroupsForQueryList leveraging the ListLogGroupsForQuery service API.
    * Added cmdlet Get-CWLTransformer leveraging the GetTransformer service API.
    * Added cmdlet Remove-CWLIndexPolicy leveraging the DeleteIndexPolicy service API.
    * Added cmdlet Remove-CWLTransformer leveraging the DeleteTransformer service API.
    * Added cmdlet Test-CWLTransformer leveraging the TestTransformer service API.
    * Added cmdlet Write-CWLIndexPolicy leveraging the PutIndexPolicy service API.
    * Added cmdlet Write-CWLTransformer leveraging the PutTransformer service API.
    * Modified cmdlet Get-CWLAccountPolicy: added parameters NextToken and NoAutoIteration.
    * Modified cmdlet Write-CWLMetricFilter: added parameter ApplyOnTransformedLog.
    * Modified cmdlet Write-CWLSubscriptionFilter: added parameter ApplyOnTransformedLog.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECommitmentPurchaseAnalysis leveraging the GetCommitmentPurchaseAnalysis service API.
    * Added cmdlet Get-CECommitmentPurchaseAnalysisList leveraging the ListCommitmentPurchaseAnalyses service API.
    * Added cmdlet Start-CECommitmentPurchaseAnalysis leveraging the StartCommitmentPurchaseAnalysis service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2CapacityBlockExtensionHistory leveraging the DescribeCapacityBlockExtensionHistory service API.
    * Added cmdlet Get-EC2CapacityBlockExtensionOffering leveraging the DescribeCapacityBlockExtensionOfferings service API.
    * Added cmdlet Invoke-EC2CapacityBlockExtension leveraging the PurchaseCapacityBlockExtension service API.
    * Modified cmdlet Add-EC2CapacityReservation: added parameters CommitmentDuration, DeliveryPreference and StartDate.
    * Modified cmdlet Edit-EC2IpamResourceDiscovery: added parameters AddOrganizationalUnitExclusion and RemoveOrganizationalUnitExclusion.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECUser: added parameter Engine.
    * Modified cmdlet Edit-ECUserGroup: added parameter Engine.
  * Amazon IoT
    * Added cmdlet Get-IOTCommand leveraging the GetCommand service API.
    * Added cmdlet Get-IOTCommandExecution leveraging the GetCommandExecution service API.
    * Added cmdlet Get-IOTCommandExecutionList leveraging the ListCommandExecutions service API.
    * Added cmdlet Get-IOTCommandList leveraging the ListCommands service API.
    * Added cmdlet New-IOTCommand leveraging the CreateCommand service API.
    * Added cmdlet Remove-IOTCommand leveraging the DeleteCommand service API.
    * Added cmdlet Remove-IOTCommandExecution leveraging the DeleteCommandExecution service API.
    * Added cmdlet Update-IOTCommand leveraging the UpdateCommand service API.
  * Amazon IoT FleetWise
    * Added cmdlet Get-IFWStateTemplate leveraging the GetStateTemplate service API.
    * Added cmdlet Get-IFWStateTemplateList leveraging the ListStateTemplates service API.
    * Added cmdlet New-IFWStateTemplate leveraging the CreateStateTemplate service API.
    * Added cmdlet Remove-IFWStateTemplate leveraging the DeleteStateTemplate service API.
    * Added cmdlet Update-IFWStateTemplate leveraging the UpdateStateTemplate service API.
    * Modified cmdlet New-IFWCampaign: added parameters DataPartition and SignalsToFetch.
    * Modified cmdlet New-IFWDecoderManifest: added parameter DefaultForUnmappedSignal.
    * Modified cmdlet New-IFWVehicle: added parameter StateTemplate.
    * Modified cmdlet Update-IFWDecoderManifest: added parameter DefaultForUnmappedSignal.
    * Modified cmdlet Update-IFWVehicle: added parameters StateTemplatesToAdd and StateTemplatesToRemove.
  * Amazon IoT Jobs Data Plane
    * Added cmdlet Start-IOTJCommandExecution leveraging the StartCommandExecution service API.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter MetricsConfig_Metric.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter MetricsConfig_Metric.
  * Amazon Resilience Hub
    * Added cmdlet Get-RESHMetricList leveraging the ListMetrics service API.
    * Added cmdlet Get-RESHMetricsExport leveraging the DescribeMetricsExport service API.
    * Added cmdlet Start-RESHMetricsExport leveraging the StartMetricsExport service API.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMExecutionPreview leveraging the GetExecutionPreview service API.
    * Added cmdlet Get-SSMNode leveraging the ListNodes service API.
    * Added cmdlet Get-SSMNodesSummary leveraging the ListNodesSummary service API.
    * Added cmdlet Start-SSMExecutionPreview leveraging the StartExecutionPreview service API.
  * Amazon Systems Manager QuickSetup
    * Added cmdlet Get-SSMQSConfiguration leveraging the GetConfiguration service API.
    * Added cmdlet Get-SSMQSConfigurationList leveraging the ListConfigurations service API.
  * Amazon User Notifications. Added cmdlets to support the service. Cmdlets for the service have the noun prefix UNO and can be listed using the command 'Get-AWSCmdletName -Service UNO'.
  * Amazon User Notifications Contacts. Added cmdlets to support the service. Cmdlets for the service have the noun prefix UNC and can be listed using the command 'Get-AWSCmdletName -Service UNC'.
  * Amazon X-Ray
    * Added cmdlet Get-XRIndexingRule leveraging the GetIndexingRules service API.
    * Added cmdlet Get-XRRetrievedTraceList leveraging the ListRetrievedTraces service API.
    * Added cmdlet Get-XRRetrievedTracesGraph leveraging the GetRetrievedTracesGraph service API.
    * Added cmdlet Get-XRTraceSegmentDestination leveraging the GetTraceSegmentDestination service API.
    * Added cmdlet Start-XRTraceRetrieval leveraging the StartTraceRetrieval service API.
    * Added cmdlet Stop-XRTraceRetrieval leveraging the CancelTraceRetrieval service API.
    * Added cmdlet Update-XRIndexingRule leveraging the UpdateIndexingRule service API.
    * Added cmdlet Update-XRTraceSegmentDestination leveraging the UpdateTraceSegmentDestination service API.

### 4.1.703 (2024-11-21 01:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.931.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Discovery Service
    * Modified cmdlet New-ADSApplication: added parameter Wave.
    * Modified cmdlet Update-ADSApplication: added parameter Wave.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameters CapacityReservationSpecification_CapacityReservationPreference, CapacityReservationTarget_CapacityReservationId and CapacityReservationTarget_CapacityReservationResourceGroupArn.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameters CapacityReservationSpecification_CapacityReservationPreference, CapacityReservationTarget_CapacityReservationId and CapacityReservationTarget_CapacityReservationResourceGroupArn.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Get-BAROptimizePrompt leveraging the OptimizePrompt service API.
  * Amazon CloudFront
    * Added cmdlet Get-CFAnycastIpList leveraging the GetAnycastIpList service API.
    * Added cmdlet Get-CFAnycastIpListList leveraging the ListAnycastIpLists service API.
    * Added cmdlet Get-CFDistributionsByAnycastIpListId leveraging the ListDistributionsByAnycastIpListId service API.
    * Added cmdlet Get-CFDistributionsByVpcOriginId leveraging the ListDistributionsByVpcOriginId service API.
    * Added cmdlet Get-CFVpcOrigin leveraging the GetVpcOrigin service API.
    * Added cmdlet Get-CFVpcOriginList leveraging the ListVpcOrigins service API.
    * Added cmdlet New-CFAnycastIpList leveraging the CreateAnycastIpList service API.
    * Added cmdlet New-CFVpcOrigin leveraging the CreateVpcOrigin service API.
    * Added cmdlet Remove-CFAnycastIpList leveraging the DeleteAnycastIpList service API.
    * Added cmdlet Remove-CFVpcOrigin leveraging the DeleteVpcOrigin service API.
    * Added cmdlet Update-CFVpcOrigin leveraging the UpdateVpcOrigin service API.
    * Modified cmdlet New-CFDistribution: added parameters DistributionConfig_AnycastIpListId and GrpcConfig_Enabled.
    * Modified cmdlet New-CFDistributionWithTag: added parameters DistributionConfig_AnycastIpListId and GrpcConfig_Enabled.
    * Modified cmdlet Update-CFDistribution: added parameters DistributionConfig_AnycastIpListId and GrpcConfig_Enabled.
  * Amazon Compute Optimizer
    * Added cmdlet Export-COIdleRecommendation leveraging the ExportIdleRecommendations service API.
    * Added cmdlet Get-COIdleRecommendation leveraging the GetIdleRecommendations service API.
  * Amazon Control Tower
    * Modified cmdlet Get-ACTEnabledBaselineList: added parameters Filter_ParentIdentifier and IncludeChild.
  * Amazon DataZone
    * Added cmdlet Get-DZRule leveraging the GetRule service API.
    * Added cmdlet Get-DZRuleList leveraging the ListRules service API.
    * Added cmdlet New-DZRule leveraging the CreateRule service API.
    * Added cmdlet Remove-DZRule leveraging the DeleteRule service API.
    * Added cmdlet Update-DZRule leveraging the UpdateRule service API.
    * Modified cmdlet New-DZSubscriptionRequest: added parameter MetadataForm.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameter AvailabilityZoneRebalancing.
    * Modified cmdlet Update-ECSService: added parameter AvailabilityZoneRebalancing.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Get-EC2InstanceTypesFromInstanceRequirement: added parameter Cpu_Reference.
    * Modified cmdlet Get-EC2SpotPlacementScore: added parameter Cpu_Reference.
  * Amazon Elastic Load Balancing V2
    * Added cmdlet Edit-ELB2CapacityReservation leveraging the ModifyCapacityReservation service API.
    * Added cmdlet Get-ELB2CapacityReservation leveraging the DescribeCapacityReservation service API.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCQueue: added parameter ConcurrentJob.
    * Modified cmdlet Update-EMCQueue: added parameter ConcurrentJob.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2Channel: added parameters InputSwitchConfiguration_MQCSInputSwitching and OutputHeaderConfiguration_PublishMQCS.
    * Modified cmdlet Update-MPV2Channel: added parameters InputSwitchConfiguration_MQCSInputSwitching and OutputHeaderConfiguration_PublishMQCS.
  * Amazon Omics
    * Added cmdlet Get-OMICSRunCache leveraging the GetRunCache service API.
    * Added cmdlet Get-OMICSRunCachList leveraging the ListRunCaches service API.
    * Added cmdlet New-OMICSRunCache leveraging the CreateRunCache service API.
    * Added cmdlet Remove-OMICSRunCache leveraging the DeleteRunCache service API.
    * Added cmdlet Update-OMICSRunCache leveraging the UpdateRunCache service API.
    * Modified cmdlet Start-OMICSRun: added parameters CacheBehavior and CacheId.
  * Amazon Recycle Bin
    * Modified cmdlet Get-RBINRuleList: added parameter ExcludeResourceTag.
    * Modified cmdlet New-RBINRule: added parameter ExcludeResourceTag.
    * Modified cmdlet Update-RBINRule: added parameter ExcludeResourceTag.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSBlueGreenDeployment: added parameters TargetAllocatedStorage, TargetIops, TargetStorageThroughput and TargetStorageType.
  * Amazon Timestream Query
    * Modified cmdlet Update-TSQAccountSetting: added parameters NotificationConfiguration_RoleArn, ProvisionedCapacity_TargetQueryTCU, QueryCompute_ComputeMode and SnsConfiguration_TopicArn.
  * Amazon WorkSpaces Web
    * Added cmdlet Get-WSWDataProtectionSetting leveraging the GetDataProtectionSettings service API.
    * Added cmdlet Get-WSWDataProtectionSettingList leveraging the ListDataProtectionSettings service API.
    * Added cmdlet New-WSWDataProtectionSetting leveraging the CreateDataProtectionSettings service API.
    * Added cmdlet Register-WSWDataProtectionSetting leveraging the AssociateDataProtectionSettings service API.
    * Added cmdlet Remove-WSWDataProtectionSetting leveraging the DeleteDataProtectionSettings service API.
    * Added cmdlet Unregister-WSWDataProtectionSetting leveraging the DisassociateDataProtectionSettings service API.
    * Added cmdlet Update-WSWDataProtectionSetting leveraging the UpdateDataProtectionSettings service API.

### 4.1.702 (2024-11-19 22:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.930.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2VpcBlockPublicAccessExclusion leveraging the ModifyVpcBlockPublicAccessExclusion service API.
    * Added cmdlet Edit-EC2VpcBlockPublicAccessOption leveraging the ModifyVpcBlockPublicAccessOptions service API.
    * Added cmdlet Get-EC2VpcBlockPublicAccessExclusion leveraging the DescribeVpcBlockPublicAccessExclusions service API.
    * Added cmdlet Get-EC2VpcBlockPublicAccessOption leveraging the DescribeVpcBlockPublicAccessOptions service API.
    * Added cmdlet New-EC2VpcBlockPublicAccessExclusion leveraging the CreateVpcBlockPublicAccessExclusion service API.
    * Added cmdlet Remove-EC2VpcBlockPublicAccessExclusion leveraging the DeleteVpcBlockPublicAccessExclusion service API.
  * Amazon Elastic File System
    * Modified cmdlet Remove-EFSReplicationConfiguration: added parameter DeletionMode.
  * Amazon Glue
    * Modified cmdlet New-GLUETableOptimizer: added parameter VpcConfiguration_GlueConnectionName.
    * Modified cmdlet Update-GLUETableOptimizer: added parameter VpcConfiguration_GlueConnectionName.
  * Amazon Keyspaces
    * Added cmdlet Update-KSKeyspace leveraging the UpdateKeyspace service API.
  * Amazon Tax Settings
    * Added cmdlet Get-TSABatchTaxExemption leveraging the BatchGetTaxExemptions service API.
    * Added cmdlet Get-TSATaxExemptionList leveraging the ListTaxExemptions service API.
    * Added cmdlet Get-TSATaxExemptionType leveraging the GetTaxExemptionTypes service API.
    * Added cmdlet Get-TSATaxInheritance leveraging the GetTaxInheritance service API.
    * Added cmdlet Write-TSATaxExemption leveraging the PutTaxExemption service API.
    * Added cmdlet Write-TSATaxInheritance leveraging the PutTaxInheritance service API.

### 4.1.701 (2024-11-18 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.929.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet Add-ASTrafficSource: added parameter SkipZonalShiftValidation.
    * Modified cmdlet New-ASAutoScalingGroup: added parameters AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior, AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled and SkipZonalShiftValidation.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameters AvailabilityZoneImpairmentPolicy_ImpairedZoneHealthCheckBehavior, AvailabilityZoneImpairmentPolicy_ZonalShiftEnabled and SkipZonalShiftValidation.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNHookResult leveraging the ListHookResults service API.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFGetCalculatedAttributeForProfile leveraging the BatchGetCalculatedAttributeForProfile service API.
    * Added cmdlet Get-CPFGetProfile leveraging the BatchGetProfile service API.
    * Added cmdlet Get-CPFObjectTypeAttributeList leveraging the ListObjectTypeAttributes service API.
    * Added cmdlet Get-CPFProfileAttributeValueList leveraging the ListProfileAttributeValues service API.
    * Added cmdlet Get-CPFSegmentDefinition leveraging the GetSegmentDefinition service API.
    * Added cmdlet Get-CPFSegmentDefinitionList leveraging the ListSegmentDefinitions service API.
    * Added cmdlet Get-CPFSegmentEstimate leveraging the GetSegmentEstimate service API.
    * Added cmdlet Get-CPFSegmentMembership leveraging the GetSegmentMembership service API.
    * Added cmdlet Get-CPFSegmentSnapshot leveraging the GetSegmentSnapshot service API.
    * Added cmdlet New-CPFSegmentDefinition leveraging the CreateSegmentDefinition service API.
    * Added cmdlet New-CPFSegmentEstimate leveraging the CreateSegmentEstimate service API.
    * Added cmdlet New-CPFSegmentSnapshot leveraging the CreateSegmentSnapshot service API.
    * Added cmdlet Remove-CPFSegmentDefinition leveraging the DeleteSegmentDefinition service API.
    * Modified cmdlet New-CPFCalculatedAttributeDefinition: added parameters Filter_Group and Filter_Include.
  * Amazon Connect Service
    * Added cmdlet Get-CONNContactFlowVersionList leveraging the ListContactFlowVersions service API.
    * Added cmdlet New-CONNContactFlowVersion leveraging the CreateContactFlowVersion service API.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameter VpcLatticeConfiguration.
    * Modified cmdlet Update-ECSService: added parameter VpcLatticeConfiguration.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2Instance: added parameter Operator_Principal.
    * Modified cmdlet New-EC2LaunchTemplate: added parameter Operator_Principal.
    * Modified cmdlet New-EC2NetworkInterface: added parameter Operator_Principal.
    * Modified cmdlet New-EC2Volume: added parameter Operator_Principal.
  * Amazon IoT SiteWise
    * Added cmdlet Get-IOTSWDataset leveraging the DescribeDataset service API.
    * Added cmdlet Get-IOTSWDatasetList leveraging the ListDatasets service API.
    * Added cmdlet Invoke-IOTSWAssistant leveraging the InvokeAssistant service API.
    * Added cmdlet New-IOTSWDataset leveraging the CreateDataset service API.
    * Added cmdlet Remove-IOTSWDataset leveraging the DeleteDataset service API.
    * Added cmdlet Update-IOTSWDataset leveraging the UpdateDataset service API.
    * Modified cmdlet New-IOTSWPortal: added parameters PortalType and PortalTypeConfiguration.
    * Modified cmdlet Start-IOTSWQuery: added parameter ClientToken.
    * Modified cmdlet Update-IOTSWPortal: added parameters PortalType and PortalTypeConfiguration.
  * Amazon Q Connect
    * Added cmdlet Disable-QCMessageTemplate leveraging the DeactivateMessageTemplate service API.
    * Added cmdlet Enable-QCMessageTemplate leveraging the ActivateMessageTemplate service API.
    * Added cmdlet Get-QCMessageTemplate leveraging the GetMessageTemplate service API.
    * Added cmdlet Get-QCMessageTemplateList leveraging the ListMessageTemplates service API.
    * Added cmdlet Get-QCMessageTemplateVersionList leveraging the ListMessageTemplateVersions service API.
    * Added cmdlet Invoke-QCMessageTemplate leveraging the RenderMessageTemplate service API.
    * Added cmdlet New-QCMessageTemplate leveraging the CreateMessageTemplate service API.
    * Added cmdlet New-QCMessageTemplateAttachment leveraging the CreateMessageTemplateAttachment service API.
    * Added cmdlet New-QCMessageTemplateVersion leveraging the CreateMessageTemplateVersion service API.
    * Added cmdlet Remove-QCMessageTemplate leveraging the DeleteMessageTemplate service API.
    * Added cmdlet Remove-QCMessageTemplateAttachment leveraging the DeleteMessageTemplateAttachment service API.
    * Added cmdlet Search-QCMessageTemplate leveraging the SearchMessageTemplates service API.
    * Added cmdlet Update-QCMessageTemplate leveraging the UpdateMessageTemplate service API.
    * Added cmdlet Update-QCMessageTemplateMetadata leveraging the UpdateMessageTemplateMetadata service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter ServerlessV2ScalingConfiguration_SecondsUntilAutoPause.
    * Modified cmdlet New-RDSDBCluster: added parameter ServerlessV2ScalingConfiguration_SecondsUntilAutoPause.
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameter ServerlessV2ScalingConfiguration_SecondsUntilAutoPause.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter ServerlessV2ScalingConfiguration_SecondsUntilAutoPause.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter ServerlessV2ScalingConfiguration_SecondsUntilAutoPause.

### 4.1.700 (2024-11-15 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.928.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonConnectCampaignServiceV2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CCS2 and can be listed using the command 'Get-AWSCmdletName -Service CCS2'.
  * Amazon CloudWatch
    * Modified cmdlet Write-CWMetricData: added parameters EntityMetricData and StrictEntityValidation.
  * Amazon IoT
    * Added cmdlet Get-IOTPrincipalThingsV2List leveraging the ListPrincipalThingsV2 service API.
    * Added cmdlet Get-IOTThingPrincipalsV2List leveraging the ListThingPrincipalsV2 service API.
    * Added cmdlet Update-IOTThingType leveraging the UpdateThingType service API.
    * Modified cmdlet Add-IOTThingPrincipal: added parameter ThingPrincipalType.
    * Modified cmdlet New-IOTDomainConfiguration: added parameters ServerCertificateConfig_OcspAuthorizedResponderArn and ServerCertificateConfig_OcspLambdaArn.
    * Modified cmdlet New-IOTThingType: added parameter Mqtt5Configuration_PropagatingAttribute.
    * Modified cmdlet Update-IOTDomainConfiguration: added parameters ServerCertificateConfig_OcspAuthorizedResponderArn and ServerCertificateConfig_OcspLambdaArn.
  * Amazon Pinpoint SMS Voice V2
    * Added cmdlet Get-SMSVProtectConfigurationRuleSetNumberOverrideList leveraging the ListProtectConfigurationRuleSetNumberOverrides service API.
    * Added cmdlet Remove-SMSVProtectConfigurationRuleSetNumberOverride leveraging the DeleteProtectConfigurationRuleSetNumberOverride service API.
    * Added cmdlet Set-SMSVDefaultMessageFeedbackEnabled leveraging the SetDefaultMessageFeedbackEnabled service API.
    * Added cmdlet Write-SMSVMessageFeedback leveraging the PutMessageFeedback service API.
    * Added cmdlet Write-SMSVProtectConfigurationRuleSetNumberOverride leveraging the PutProtectConfigurationRuleSetNumberOverride service API.
    * Modified cmdlet Send-SMSVMediaMessage: added parameter MessageFeedbackEnabled.
    * Modified cmdlet Send-SMSVTextMessage: added parameter MessageFeedbackEnabled.
    * Modified cmdlet Send-SMSVVoiceMessage: added parameter MessageFeedbackEnabled.
  * Amazon Route 53 Resolver
    * Modified cmdlet Edit-R53RFirewallRule: added parameters ConfidenceThreshold, DnsThreatProtection and FirewallThreatProtectionId.
    * Modified cmdlet New-R53RFirewallRule: added parameters ConfidenceThreshold and DnsThreatProtection.
    * Modified cmdlet Remove-R53RFirewallRule: added parameter FirewallThreatProtectionId.

### 4.1.699 (2024-11-15 04:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.927.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.698 (2024-11-14 21:29Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.926.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameters AcceleratorCapabilities_Selection, Count_Max and Count_Min.
    * Modified cmdlet Update-ADCFleet: added parameters AcceleratorCapabilities_Selection, Count_Max and Count_Min.
  * Amazon IAM Access Analyzer
    * Added cmdlet Update-IAMAAAnalyzer leveraging the UpdateAnalyzer service API.
    * Modified cmdlet New-IAMAAAnalyzer: added parameter AnalysisRule_Exclusion.
  * Amazon Identity and Access Management
    * Added cmdlet Disable-IAMOrganizationsRootCredentialsManagement leveraging the DisableOrganizationsRootCredentialsManagement service API.
    * Added cmdlet Disable-IAMOrganizationsRootSession leveraging the DisableOrganizationsRootSessions service API.
    * Added cmdlet Enable-IAMOrganizationsRootCredentialsManagement leveraging the EnableOrganizationsRootCredentialsManagement service API.
    * Added cmdlet Enable-IAMOrganizationsRootSession leveraging the EnableOrganizationsRootSessions service API.
    * Added cmdlet Get-IAMOrganizationsFeature leveraging the ListOrganizationsFeatures service API.
  * Amazon Interactive Video Service
    * Modified cmdlet New-IVSChannel: added parameters ContainerFormat, MultitrackInputConfiguration_Enabled, MultitrackInputConfiguration_MaximumResolution and MultitrackInputConfiguration_Policy.
    * Modified cmdlet Update-IVSChannel: added parameters ContainerFormat, MultitrackInputConfiguration_Enabled, MultitrackInputConfiguration_MaximumResolution and MultitrackInputConfiguration_Policy.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWFuotaTask: added parameter Descriptor.
    * Modified cmdlet New-IOTWMulticastGroup: added parameters ParticipatingGateways_GatewayList and ParticipatingGateways_TransmissionInterval.
    * Modified cmdlet Update-IOTWFuotaTask: added parameter Descriptor.
    * Modified cmdlet Update-IOTWLogLevelsByResourceType: added parameter FuotaTaskLogOption.
    * Modified cmdlet Update-IOTWMulticastGroup: added parameters ParticipatingGateways_GatewayList and ParticipatingGateways_TransmissionInterval.
  * Amazon License Manager User Subscription
    * Added cmdlet Add-LMUSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-LMUSLicenseServerEndpointList leveraging the ListLicenseServerEndpoints service API.
    * Added cmdlet Get-LMUSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-LMUSLicenseServerEndpoint leveraging the CreateLicenseServerEndpoint service API.
    * Added cmdlet Remove-LMUSLicenseServerEndpoint leveraging the DeleteLicenseServerEndpoint service API.
    * Added cmdlet Remove-LMUSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Add-LMUSUser: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, SecretsManagerCredentialsProvider_SecretId and Tag.
    * Modified cmdlet Get-LMUSIdentityProviderList: added parameter Filter.
    * Modified cmdlet Get-LMUSProductSubscriptionList: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet and SecretsManagerCredentialsProvider_SecretId.
    * Modified cmdlet Get-LMUSUserAssociationList: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet and SecretsManagerCredentialsProvider_SecretId.
    * Modified cmdlet Register-LMUSIdentityProvider: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, SecretsManagerCredentialsProvider_SecretId and Tag.
    * Modified cmdlet Remove-LMUSUser: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, InstanceUserArn and SecretsManagerCredentialsProvider_SecretId.
    * Modified cmdlet Start-LMUSProductSubscription: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, SecretsManagerCredentialsProvider_SecretId and Tag.
    * Modified cmdlet Stop-LMUSProductSubscription: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, ProductUserArn and SecretsManagerCredentialsProvider_SecretId.
    * Modified cmdlet Unregister-LMUSIdentityProvider: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, IdentityProviderArn and SecretsManagerCredentialsProvider_SecretId.
    * Modified cmdlet Update-LMUSIdentityProviderSetting: added parameters ActiveDirectoryIdentityProvider_ActiveDirectoryType, ActiveDirectorySettings_DomainIpv4List, ActiveDirectorySettings_DomainName, DomainNetworkSettings_Subnet, IdentityProviderArn and SecretsManagerCredentialsProvider_SecretId.
  * Amazon Partner Central Selling API. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PC and can be listed using the command 'Get-AWSCmdletName -Service PC'.
  * Amazon QuickSight
    * Added cmdlet Get-QSBrand leveraging the DescribeBrand service API.
    * Added cmdlet Get-QSBrandAssignment leveraging the DescribeBrandAssignment service API.
    * Added cmdlet Get-QSBrandList leveraging the ListBrands service API.
    * Added cmdlet Get-QSBrandPublishedVersion leveraging the DescribeBrandPublishedVersion service API.
    * Added cmdlet Get-QSCustomPermission leveraging the DescribeCustomPermissions service API.
    * Added cmdlet Get-QSCustomPermissionList leveraging the ListCustomPermissions service API.
    * Added cmdlet New-QSBrand leveraging the CreateBrand service API.
    * Added cmdlet New-QSCustomPermission leveraging the CreateCustomPermissions service API.
    * Added cmdlet Remove-QSBrand leveraging the DeleteBrand service API.
    * Added cmdlet Remove-QSBrandAssignment leveraging the DeleteBrandAssignment service API.
    * Added cmdlet Remove-QSCustomPermission leveraging the DeleteCustomPermissions service API.
    * Added cmdlet Remove-QSUserCustomPermission leveraging the DeleteUserCustomPermission service API.
    * Added cmdlet Update-QSBrand leveraging the UpdateBrand service API.
    * Added cmdlet Update-QSBrandAssignment leveraging the UpdateBrandAssignment service API.
    * Added cmdlet Update-QSBrandPublishedVersion leveraging the UpdateBrandPublishedVersion service API.
    * Added cmdlet Update-QSCustomPermission leveraging the UpdateCustomPermissions service API.
    * Added cmdlet Update-QSUserCustomPermission leveraging the UpdateUserCustomPermission service API.
  * Amazon Security Token Service
    * Added cmdlet Use-STSRoot leveraging the AssumeRoot service API.

### 4.1.697 (2024-11-13 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.925.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon B2B Data Interchange
    * Added cmdlet Get-B2BIGeneratedMapping leveraging the GenerateMapping service API.
  * Amazon Billing. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AWSB and can be listed using the command 'Get-AWSCmdletName -Service AWSB'.
  * Amazon CloudTrail
    * Added cmdlet Invoke-CTGenerateQuery leveraging the GenerateQuery service API.
  * Amazon CloudWatch Application Signals
    * Modified cmdlet New-CWASServiceLevelObjective: added parameter BurnRateConfiguration.
    * Modified cmdlet Update-CWASServiceLevelObjective: added parameter BurnRateConfiguration.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBTable: added parameters WarmThroughput_ReadUnitsPerSecond and WarmThroughput_WriteUnitsPerSecond.

### 4.1.696 (2024-11-12 21:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.924.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Tower
    * Added cmdlet Reset-ACTEnabledControl leveraging the ResetEnabledControl service API.
  * Amazon Fault Injection Simulator
    * Modified cmdlet New-FISExperimentTemplate: added parameters DataSources_CloudWatchDashboard, ExperimentReportConfiguration_Outputs_S3Configuration_BucketName, ExperimentReportConfiguration_Outputs_S3Configuration_Prefix, ExperimentReportConfiguration_PostExperimentDuration and ExperimentReportConfiguration_PreExperimentDuration.
    * Modified cmdlet Update-FISExperimentTemplate: added parameters DataSources_CloudWatchDashboard, ExperimentReportConfiguration_Outputs_S3Configuration_BucketName, ExperimentReportConfiguration_Outputs_S3Configuration_Prefix, ExperimentReportConfiguration_PostExperimentDuration and ExperimentReportConfiguration_PreExperimentDuration.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLContainerFleet leveraging the DescribeContainerFleet service API.
    * Added cmdlet Get-GMLContainerFleetList leveraging the ListContainerFleets service API.
    * Added cmdlet Get-GMLContainerGroupDefinitionVersionList leveraging the ListContainerGroupDefinitionVersions service API.
    * Added cmdlet Get-GMLFleetDeployment leveraging the DescribeFleetDeployment service API.
    * Added cmdlet Get-GMLFleetDeploymentList leveraging the ListFleetDeployments service API.
    * Added cmdlet New-GMLContainerFleet leveraging the CreateContainerFleet service API.
    * Added cmdlet Remove-GMLContainerFleet leveraging the DeleteContainerFleet service API.
    * Added cmdlet Update-GMLContainerFleet leveraging the UpdateContainerFleet service API.
    * Added cmdlet Update-GMLContainerGroupDefinition leveraging the UpdateContainerGroupDefinition service API.
    * Modified cmdlet Get-GMLComputeList: added parameters ComputeStatus and ContainerGroupDefinitionName.
    * Modified cmdlet Get-GMLContainerGroupDefinition: added parameter VersionNumber.
    * [Breaking Change] Modified cmdlet Get-GMLContainerGroupDefinitionList: removed parameter SchedulingStrategy; added parameter ContainerGroupType.
    * [Breaking Change] Modified cmdlet Get-GMLFleet: removed parameter ContainerGroupDefinitionName.
    * [Breaking Change] Modified cmdlet New-GMLContainerGroupDefinition: removed parameters ContainerDefinition, SchedulingStrategy, TotalCpuLimit and TotalMemoryLimit; added parameters ContainerGroupType, GameServerContainerDefinition_ContainerName, GameServerContainerDefinition_DependsOn, GameServerContainerDefinition_EnvironmentOverride, GameServerContainerDefinition_ImageUri, GameServerContainerDefinition_MountPoint, GameServerContainerDefinition_ServerSdkVersion, PortConfiguration_ContainerPortRange, SupportContainerDefinition, TotalMemoryLimitMebibyte, TotalVcpuLimit and VersionDescription.
    * [Breaking Change] Modified cmdlet New-GMLFleet: removed parameters ConnectionPortRange_FromPort, ConnectionPortRange_ToPort, ContainerGroupsConfiguration_ContainerGroupDefinitionName and ContainerGroupsConfiguration_DesiredReplicaContainerGroupsPerInstance.
    * Modified cmdlet Remove-GMLContainerGroupDefinition: added parameters VersionCountToRetain and VersionNumber.
  * Amazon Payment Cryptography Control Plane
    * Modified cmdlet Get-PAYCCAliasList: added parameter KeyArn.

### 4.1.695 (2024-11-11 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.923.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon OpenSearch Service
    * Added cmdlet Start-OSOSAssociatePackageList leveraging the AssociatePackages service API.
    * Added cmdlet Start-OSOSDissociatePackageList leveraging the DissociatePackages service API.
    * Added cmdlet Update-OSOSPackageScope leveraging the UpdatePackageScope service API.
    * Modified cmdlet New-OSPackage: added parameters EngineVersion, PackageConfiguration_ConfigurationRequirement, PackageConfiguration_LicenseFilepath, PackageConfiguration_LicenseRequirement, PackageConfiguration_RequiresRestartForConfigurationUpdate, PackageEncryptionOptions_EncryptionEnabled, PackageEncryptionOptions_KmsKeyIdentifier and PackageVendingOptions_VendingEnabled.
    * Modified cmdlet Start-OSAssociatePackage: added parameters KeyStoreAccessOption_KeyAccessRoleArn, KeyStoreAccessOption_KeyStoreAccessEnabled and PrerequisitePackageIDList.
    * Modified cmdlet Update-OSPackage: added parameters PackageConfiguration_ConfigurationRequirement, PackageConfiguration_LicenseFilepath, PackageConfiguration_LicenseRequirement, PackageConfiguration_RequiresRestartForConfigurationUpdate, PackageEncryptionOptions_EncryptionEnabled and PackageEncryptionOptions_KmsKeyIdentifier.
  * Amazon Outposts
    * Added cmdlet Get-OUTPAssetInstanceList leveraging the ListAssetInstances service API.
    * Added cmdlet Get-OUTPBlockingInstancesForCapacityTaskList leveraging the ListBlockingInstancesForCapacityTask service API.
    * Modified cmdlet Start-OUTPCapacityTask: added parameters InstancesToExclude_AccountId, InstancesToExclude_Instance, InstancesToExclude_Service and TaskActionOnBlockingInstance.

### 4.1.694 (2024-11-08 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.922.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter LaunchTemplate_Override.
    * Modified cmdlet Update-BATComputeEnvironment: added parameter LaunchTemplate_Override.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARFlow: added parameter EnableTrace.
  * Amazon Chime SDK Media Pipelines
    * Modified cmdlet New-CHMMPMediaCapturePipeline: added parameters SinkIamRoleArn, SseAwsKeyManagementParams_AwsKmsEncryptionContext and SseAwsKeyManagementParams_AwsKmsKeyId.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters CatalogConfiguration_WarehouseLocation, Columns_Exclude, Columns_Include, Databases_Exclude, Databases_Include, DatabaseSourceConfiguration_Endpoint, DatabaseSourceConfiguration_Port, DatabaseSourceConfiguration_SnapshotWatermarkTable, DatabaseSourceConfiguration_SSLMode, DatabaseSourceConfiguration_SurrogateKey, DatabaseSourceConfiguration_Type, DatabaseSourceVPCConfiguration_VpcEndpointServiceName, SchemaEvolutionConfiguration_Enabled, SecretsManagerConfiguration_Enabled, SecretsManagerConfiguration_RoleARN, SecretsManagerConfiguration_SecretARN, TableCreationConfiguration_Enabled, Tables_Exclude and Tables_Include.
    * Modified cmdlet Update-KINFDestination: added parameters CatalogConfiguration_WarehouseLocation, SchemaEvolutionConfiguration_Enabled and TableCreationConfiguration_Enabled.
  * Amazon Lambda
    * Modified cmdlet Publish-LMFunction: added parameter Code_SourceKMSKeyArn.
    * Modified cmdlet Update-LMFunctionCode: added parameter SourceKMSKeyArn.
  * Amazon QBusiness
    * Modified cmdlet Write-QBUSGroup: added parameters RoleArn, S3PathForGroupMembers_Bucket and S3PathForGroupMembers_Key.

### 4.1.693 (2024-11-07 21:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.921.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Added cmdlet Confirm-AABFlowDefinition leveraging the ValidateFlowDefinition service API.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter AvailabilityZoneDistribution_CapacityDistributionStrategy.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter AvailabilityZoneDistribution_CapacityDistributionStrategy.
  * Amazon Bedrock Runtime
    * Modified cmdlet Invoke-BDRRConverse: added parameter PromptVariable.
    * Modified cmdlet Invoke-BDRRConverseStream: added parameter PromptVariable.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSCollaboration: added parameters CreatorMLMemberAbilities_CustomMLMemberAbility, ModelInference_IsResponsible and ModelTraining_IsResponsible.
    * Modified cmdlet New-CRSMembership: added parameters ModelInference_IsResponsible and ModelTraining_IsResponsible.
  * Amazon CleanRoomsML
    * Added cmdlet Get-CRMLCollaborationConfiguredModelAlgorithmAssociation leveraging the GetCollaborationConfiguredModelAlgorithmAssociation service API.
    * Added cmdlet Get-CRMLCollaborationConfiguredModelAlgorithmAssociationList leveraging the ListCollaborationConfiguredModelAlgorithmAssociations service API.
    * Added cmdlet Get-CRMLCollaborationMLInputChannel leveraging the GetCollaborationMLInputChannel service API.
    * Added cmdlet Get-CRMLCollaborationMLInputChannelList leveraging the ListCollaborationMLInputChannels service API.
    * Added cmdlet Get-CRMLCollaborationTrainedModel leveraging the GetCollaborationTrainedModel service API.
    * Added cmdlet Get-CRMLCollaborationTrainedModelExportJobList leveraging the ListCollaborationTrainedModelExportJobs service API.
    * Added cmdlet Get-CRMLCollaborationTrainedModelInferenceJobList leveraging the ListCollaborationTrainedModelInferenceJobs service API.
    * Added cmdlet Get-CRMLCollaborationTrainedModelList leveraging the ListCollaborationTrainedModels service API.
    * Added cmdlet Get-CRMLConfiguredModelAlgorithm leveraging the GetConfiguredModelAlgorithm service API.
    * Added cmdlet Get-CRMLConfiguredModelAlgorithmAssociation leveraging the GetConfiguredModelAlgorithmAssociation service API.
    * Added cmdlet Get-CRMLConfiguredModelAlgorithmAssociationList leveraging the ListConfiguredModelAlgorithmAssociations service API.
    * Added cmdlet Get-CRMLConfiguredModelAlgorithmList leveraging the ListConfiguredModelAlgorithms service API.
    * Added cmdlet Get-CRMLMLConfiguration leveraging the GetMLConfiguration service API.
    * Added cmdlet Get-CRMLMLInputChannel leveraging the GetMLInputChannel service API.
    * Added cmdlet Get-CRMLMLInputChannelList leveraging the ListMLInputChannels service API.
    * Added cmdlet Get-CRMLTrainedModel leveraging the GetTrainedModel service API.
    * Added cmdlet Get-CRMLTrainedModelInferenceJob leveraging the GetTrainedModelInferenceJob service API.
    * Added cmdlet Get-CRMLTrainedModelInferenceJobList leveraging the ListTrainedModelInferenceJobs service API.
    * Added cmdlet Get-CRMLTrainedModelList leveraging the ListTrainedModels service API.
    * Added cmdlet New-CRMLConfiguredModelAlgorithm leveraging the CreateConfiguredModelAlgorithm service API.
    * Added cmdlet New-CRMLConfiguredModelAlgorithmAssociation leveraging the CreateConfiguredModelAlgorithmAssociation service API.
    * Added cmdlet New-CRMLMLInputChannel leveraging the CreateMLInputChannel service API.
    * Added cmdlet New-CRMLTrainedModel leveraging the CreateTrainedModel service API.
    * Added cmdlet Remove-CRMLConfiguredModelAlgorithm leveraging the DeleteConfiguredModelAlgorithm service API.
    * Added cmdlet Remove-CRMLConfiguredModelAlgorithmAssociation leveraging the DeleteConfiguredModelAlgorithmAssociation service API.
    * Added cmdlet Remove-CRMLMLConfiguration leveraging the DeleteMLConfiguration service API.
    * Added cmdlet Remove-CRMLMLInputChannelData leveraging the DeleteMLInputChannelData service API.
    * Added cmdlet Remove-CRMLTrainedModelOutput leveraging the DeleteTrainedModelOutput service API.
    * Added cmdlet Start-CRMLTrainedModelExportJob leveraging the StartTrainedModelExportJob service API.
    * Added cmdlet Start-CRMLTrainedModelInferenceJob leveraging the StartTrainedModelInferenceJob service API.
    * Added cmdlet Stop-CRMLTrainedModel leveraging the CancelTrainedModel service API.
    * Added cmdlet Stop-CRMLTrainedModelInferenceJob leveraging the CancelTrainedModelInferenceJob service API.
    * Added cmdlet Write-CRMLMLConfiguration leveraging the PutMLConfiguration service API.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter ProvisionedResourceCleanup.
    * Modified cmdlet Update-CWSYNCanary: added parameter ProvisionedResourceCleanup.
  * Amazon QuickSight
    * Modified cmdlet New-QSDataSource: added parameters DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri, DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn, DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope, DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl, DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri, DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn, DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope, DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl, SnowflakeParameters_AuthenticationType, SnowflakeParameters_DatabaseAccessControlRole, StarburstParameters_AuthenticationType and StarburstParameters_DatabaseAccessControlRole.
    * Modified cmdlet Update-QSDataSource: added parameters DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderResourceUri, DataSourceParameters_SnowflakeParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn, DataSourceParameters_SnowflakeParameters_OAuthParameters_OAuthScope, DataSourceParameters_SnowflakeParameters_OAuthParameters_TokenProviderUrl, DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderResourceUri, DataSourceParameters_StarburstParameters_OAuthParameters_IdentityProviderVpcConnectionProperties_VpcConnectionArn, DataSourceParameters_StarburstParameters_OAuthParameters_OAuthScope, DataSourceParameters_StarburstParameters_OAuthParameters_TokenProviderUrl, SnowflakeParameters_AuthenticationType, SnowflakeParameters_DatabaseAccessControlRole, StarburstParameters_AuthenticationType and StarburstParameters_DatabaseAccessControlRole.
  * Amazon Resource Explorer
    * Added cmdlet Get-AREXManagedView leveraging the GetManagedView service API.
    * Added cmdlet Get-AREXManagedViewList leveraging the ListManagedViews service API.

### 4.1.692 (2024-11-06 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.920.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBFleet: added parameters ComputeConfiguration_Disk, ComputeConfiguration_MachineType, ComputeConfiguration_Memory and ComputeConfiguration_VCpu.
    * Modified cmdlet New-CBProject: added parameters ComputeConfiguration_Disk, ComputeConfiguration_MachineType, ComputeConfiguration_Memory and ComputeConfiguration_VCpu.
    * Modified cmdlet Update-CBFleet: added parameters ComputeConfiguration_Disk, ComputeConfiguration_MachineType, ComputeConfiguration_Memory and ComputeConfiguration_VCpu.
    * Modified cmdlet Update-CBProject: added parameters ComputeConfiguration_Disk, ComputeConfiguration_MachineType, ComputeConfiguration_Memory and ComputeConfiguration_VCpu.
  * Amazon Lake Formation
    * Added cmdlet Get-LKFLFTagExpression leveraging the GetLFTagExpression service API.
    * Added cmdlet Get-LKFLFTagExpressionList leveraging the ListLFTagExpressions service API.
    * Added cmdlet New-LKFLFTagExpression leveraging the CreateLFTagExpression service API.
    * Added cmdlet Remove-LKFLFTagExpression leveraging the DeleteLFTagExpression service API.
    * Added cmdlet Update-LKFLFTagExpression leveraging the UpdateLFTagExpression service API.
    * Modified cmdlet Add-LKFLFTagsToResource: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Get-LKFLakeFormationOptInList: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Get-LKFPermissionList: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Get-LKFResourceLFTag: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Grant-LKFPermission: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet New-LKFLakeFormationOptIn: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Remove-LKFLakeFormationOptIn: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Remove-LKFLFTagsFromResource: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
    * Modified cmdlet Revoke-LKFPermission: added parameters LFTagExpression_CatalogId, LFTagExpression_Name and LFTagPolicy_ExpressionName.
  * Amazon Q Apps
    * Added cmdlet Get-qappsCategoryList leveraging the ListCategories service API.
    * Added cmdlet New-qappsCreateCategory leveraging the BatchCreateCategory service API.
    * Added cmdlet Remove-qappsDeleteCategory leveraging the BatchDeleteCategory service API.
    * Added cmdlet Set-qappsUpdateCategory leveraging the BatchUpdateCategory service API.
  * Amazon Verified Permissions
    * Added cmdlet Get-AVPBatchGetPolicy leveraging the BatchGetPolicy service API.

### 4.1.691 (2024-11-01 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.919.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DocumentDB Elastic Clusters
    * Added cmdlet Get-DOCEPendingMaintenanceAction leveraging the GetPendingMaintenanceAction service API.
    * Added cmdlet Get-DOCEPendingMaintenanceActionList leveraging the ListPendingMaintenanceActions service API.
    * Added cmdlet Set-DOCEPendingMaintenanceAction leveraging the ApplyPendingMaintenanceAction service API.
  * Amazon Tax Settings
    * Added cmdlet Get-TSASupplementalTaxRegistrationList leveraging the ListSupplementalTaxRegistrations service API.
    * Added cmdlet Remove-TSASupplementalTaxRegistration leveraging the DeleteSupplementalTaxRegistration service API.
    * Added cmdlet Write-TSASupplementalTaxRegistration leveraging the PutSupplementalTaxRegistration service API.
    * Modified cmdlet Write-TSATaxRegistration: added parameters MalaysiaAdditionalInfo_BusinessRegistrationNumber and MalaysiaAdditionalInfo_TaxInformationNumber.
    * Modified cmdlet Write-TSATaxRegistrationBatch: added parameters MalaysiaAdditionalInfo_BusinessRegistrationNumber and MalaysiaAdditionalInfo_TaxInformationNumber.

### 4.1.690 (2024-10-31 22:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.918.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet Start-ASInstanceRefresh: added parameter Preferences_BakeTime.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet New-ELB2LoadBalancer: added parameter EnablePrefixForIpv6SourceNat.
    * Modified cmdlet Set-ELB2Subnet: added parameter EnablePrefixForIpv6SourceNat.
  * Amazon Glue
    * Added cmdlet Get-GLUEColumnStatisticsTaskSetting leveraging the GetColumnStatisticsTaskSettings service API.
    * Added cmdlet New-GLUEColumnStatisticsTaskSetting leveraging the CreateColumnStatisticsTaskSettings service API.
    * Added cmdlet Remove-GLUEColumnStatisticsTaskSetting leveraging the DeleteColumnStatisticsTaskSettings service API.
    * Added cmdlet Start-GLUEColumnStatisticsTaskRunSchedule leveraging the StartColumnStatisticsTaskRunSchedule service API.
    * Added cmdlet Stop-GLUEColumnStatisticsTaskRunSchedule leveraging the StopColumnStatisticsTaskRunSchedule service API.
    * Added cmdlet Update-GLUEColumnStatisticsTaskSetting leveraging the UpdateColumnStatisticsTaskSettings service API.
  * Amazon Prometheus Service
    * Added cmdlet Update-PROMScraper leveraging the UpdateScraper service API.
  * Amazon SageMaker Service
    * Added cmdlet Set-SMDeleteClusterNode leveraging the BatchDeleteClusterNodes service API.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2DeliverabilityTestReport: added parameters TemplateContent_Html, TemplateContent_Subject and TemplateContent_Text.
    * Modified cmdlet Send-SES2BulkEmail: added parameters TemplateContent_Html, TemplateContent_Subject and TemplateContent_Text.
    * Modified cmdlet Send-SES2Email: added parameters TemplateContent_Html, TemplateContent_Subject and TemplateContent_Text.

### 4.1.689 (2024-10-30 20:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.917.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Added cmdlet Get-ASYNApi leveraging the GetApi service API.
    * Added cmdlet Get-ASYNApiList leveraging the ListApis service API.
    * Added cmdlet Get-ASYNChannelNamespace leveraging the GetChannelNamespace service API.
    * Added cmdlet Get-ASYNChannelNamespaceList leveraging the ListChannelNamespaces service API.
    * Added cmdlet New-ASYNApi leveraging the CreateApi service API.
    * Added cmdlet New-ASYNChannelNamespace leveraging the CreateChannelNamespace service API.
    * Added cmdlet Remove-ASYNApi leveraging the DeleteApi service API.
    * Added cmdlet Remove-ASYNChannelNamespace leveraging the DeleteChannelNamespace service API.
    * Added cmdlet Update-ASYNApi leveraging the UpdateApi service API.
    * Added cmdlet Update-ASYNChannelNamespace leveraging the UpdateChannelNamespace service API.
  * Amazon DataSync
    * Modified cmdlet New-DSYNTask: added parameter TaskMode.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSServiceDeploymentDetail leveraging the DescribeServiceDeployments service API.
    * Added cmdlet Get-ECSServiceDeploymentList leveraging the ListServiceDeployments service API.
    * Added cmdlet Get-ECSServiceRevision leveraging the DescribeServiceRevisions service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2SecurityGroupVpcAssociation leveraging the DescribeSecurityGroupVpcAssociations service API.
    * Added cmdlet Register-EC2SecurityGroupVpc leveraging the AssociateSecurityGroupVpc service API.
    * Added cmdlet Unregister-EC2SecurityGroupVpc leveraging the DisassociateSecurityGroupVpc service API.
  * Amazon Keyspaces
    * Added cmdlet Get-KSType leveraging the GetType service API.
    * Added cmdlet Get-KSTypeList leveraging the ListTypes service API.
    * Added cmdlet New-KSType leveraging the CreateType service API.
    * Added cmdlet Remove-KSType leveraging the DeleteType service API.
  * Amazon Location Service Maps V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GEOM and can be listed using the command 'Get-AWSCmdletName -Service GEOM'.
  * Amazon Location Service Places V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GEOP and can be listed using the command 'Get-AWSCmdletName -Service GEOP'.
  * Amazon Location Service Routes V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GEOR and can be listed using the command 'Get-AWSCmdletName -Service GEOR'.
  * Amazon Network Firewall
    * Modified cmdlet New-NWFWFirewallPolicy: added parameter FlowTimeouts_TcpIdleTimeoutSecond.
    * Modified cmdlet Update-NWFWFirewallPolicy: added parameter FlowTimeouts_TcpIdleTimeoutSecond.
  * Amazon OpenSearch Serverless
    * Modified cmdlet New-OSSSecurityConfig: added parameters IamIdentityCenterOptions_GroupAttribute, IamIdentityCenterOptions_InstanceArn and IamIdentityCenterOptions_UserAttribute.
    * Modified cmdlet Update-OSSSecurityConfig: added parameters IamIdentityCenterOptionsUpdates_GroupAttribute and IamIdentityCenterOptionsUpdates_UserAttribute.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSApplication leveraging the GetApplication service API.
    * Added cmdlet Get-OSApplicationList leveraging the ListApplications service API.
    * Added cmdlet New-OSApplication leveraging the CreateApplication service API.
    * Added cmdlet Remove-OSApplication leveraging the DeleteApplication service API.
    * Added cmdlet Update-OSApplication leveraging the UpdateApplication service API.
    * Modified cmdlet Approve-OSVpcEndpointAccess: added parameter Service.
    * Modified cmdlet New-OSDomain: added parameters IdentityCenterOptions_EnabledAPIAccess, IdentityCenterOptions_IdentityCenterInstanceARN, IdentityCenterOptions_RolesKey and IdentityCenterOptions_SubjectKey.
    * Modified cmdlet Revoke-OSVpcEndpointAccess: added parameter Service.
    * Modified cmdlet Update-OSDomainConfig: added parameters IdentityCenterOptions_EnabledAPIAccess, IdentityCenterOptions_IdentityCenterInstanceARN, IdentityCenterOptions_RolesKey and IdentityCenterOptions_SubjectKey.
  * Amazon Redshift Serverless
    * Modified cmdlet New-RSSWorkgroup: added parameters PricePerformanceTarget_Level and PricePerformanceTarget_Status.
    * Modified cmdlet Update-RSSWorkgroup: added parameters PricePerformanceTarget_Level and PricePerformanceTarget_Status.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMModelPackage: added parameters ModelLifeCycle_Stage, ModelLifeCycle_StageDescription and ModelLifeCycle_StageStatus.
    * Modified cmdlet Update-SMModelPackage: added parameters ClientToken, ModelLifeCycle_Stage, ModelLifeCycle_StageDescription and ModelLifeCycle_StageStatus.
  * Amazon WorkMail
    * Added cmdlet Get-WMIdentityProviderConfiguration leveraging the DescribeIdentityProviderConfiguration service API.
    * Added cmdlet Get-WMPersonalAccessTokenList leveraging the ListPersonalAccessTokens service API.
    * Added cmdlet Get-WMPersonalAccessTokenMetadata leveraging the GetPersonalAccessTokenMetadata service API.
    * Added cmdlet New-WMIdentityCenterApplication leveraging the CreateIdentityCenterApplication service API.
    * Added cmdlet Remove-WMIdentityCenterApplication leveraging the DeleteIdentityCenterApplication service API.
    * Added cmdlet Remove-WMIdentityProviderConfiguration leveraging the DeleteIdentityProviderConfiguration service API.
    * Added cmdlet Remove-WMPersonalAccessToken leveraging the DeletePersonalAccessToken service API.
    * Added cmdlet Write-WMIdentityProviderConfiguration leveraging the PutIdentityProviderConfiguration service API.
    * Modified cmdlet Get-WMUserList: added parameter Filters_IdentityProviderUserIdPrefix.
    * Modified cmdlet New-WMUser: added parameter IdentityProviderUserId.
    * Modified cmdlet Remove-WMOrganization: added parameter DeleteIdentityCenterApplication.
    * Modified cmdlet Update-WMUser: added parameter IdentityProviderUserId.

### 4.1.688 (2024-10-29 21:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.916.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet New-BDRInferenceProfile leveraging the CreateInferenceProfile service API.
    * Added cmdlet Remove-BDRInferenceProfile leveraging the DeleteInferenceProfile service API.
    * Modified cmdlet Get-BDRInferenceProfileList: added parameters PassThru and TypeEqual.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSCollaboration: added parameter AnalyticsEngine.
    * Modified cmdlet New-CRSMembership: added parameter S3_SingleFileOutput.
    * Modified cmdlet Start-CRSProtectedQuery: added parameters S3_SingleFileOutput, Worker_Number and Worker_Type.
    * Modified cmdlet Update-CRSMembership: added parameter S3_SingleFileOutput.
  * Amazon CloudWatch Logs
    * Modified cmdlet Update-CWLAnomaly: added parameter Baseline.
  * Amazon Redshift Data API Service
    * Added cmdlet Get-RSDStatementResultV2 leveraging the GetStatementResultV2 service API.
    * Modified cmdlet Push-RSDBatchStatement: added parameter ResultFormat.
    * Modified cmdlet Send-RSDStatement: added parameter ResultFormat.

### 4.1.687 (2024-10-28 20:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.915.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaPackage v2
    * Added cmdlet Get-MPV2HarvestJob leveraging the GetHarvestJob service API.
    * Added cmdlet Get-MPV2HarvestJobList leveraging the ListHarvestJobs service API.
    * Added cmdlet New-MPV2HarvestJob leveraging the CreateHarvestJob service API.
    * Added cmdlet Stop-MPV2HarvestJob leveraging the CancelHarvestJob service API.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter ClusterConfig_NodeOption.
    * Modified cmdlet Update-OSDomainConfig: added parameter ClusterConfig_NodeOption.
  * Amazon Relational Database Service
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameters EnablePerformanceInsight, MonitoringInterval, MonitoringRoleArn, PerformanceInsightsKMSKeyId and PerformanceInsightsRetentionPeriod.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameters EnablePerformanceInsight, MonitoringInterval, MonitoringRoleArn, PerformanceInsightsKMSKeyId and PerformanceInsightsRetentionPeriod.

### 4.1.686 (2024-10-25 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.914.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter AutoRetryLimit.
    * Modified cmdlet Start-CBBuild: added parameter AutoRetryLimitOverride.
    * Modified cmdlet Update-CBProject: added parameter AutoRetryLimit.

### 4.1.685 (2024-10-24 21:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.913.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Nimble Studio
  * Amazon AppConfig
    * Modified cmdlet Stop-APPCDeployment: added parameter AllowRevert.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2InstanceImageMetadata leveraging the DescribeInstanceImageMetadata service API.

### 4.1.684 (2024-10-23 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.912.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAA
    * Added cmdlet Invoke-MWAARestApi leveraging the InvokeRestApi service API.
  * Amazon Connect Service
    * Added cmdlet Start-CONNScreenSharing leveraging the StartScreenSharing service API.
    * Modified cmdlet Start-CONNWebRTCContact: added parameters Agent_ScreenShare and Customer_ScreenShare.
  * Amazon Payment Cryptography Data
    * Modified cmdlet Convert-PAYCDPinData: added parameters IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyAlgorithm, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationFunction, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_PublicKeyCertificate, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_SharedInformation, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyAlgorithm, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationFunction, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_PublicKeyCertificate and OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_SharedInformation.
    * Modified cmdlet New-PAYCDPinData: added parameters DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, DiffieHellmanSymmetricKey_KeyAlgorithm, DiffieHellmanSymmetricKey_KeyDerivationFunction, DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, DiffieHellmanSymmetricKey_PublicKeyCertificate, DiffieHellmanSymmetricKey_SharedInformation, EncryptionWrappedKey_KeyCheckValueAlgorithm and WrappedKeyMaterial_Tr31KeyBlock.
    * Modified cmdlet Protect-PAYCDData: added parameters DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, DiffieHellmanSymmetricKey_KeyAlgorithm, DiffieHellmanSymmetricKey_KeyDerivationFunction, DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, DiffieHellmanSymmetricKey_PublicKeyCertificate and DiffieHellmanSymmetricKey_SharedInformation.
    * Modified cmdlet Test-PAYCDPinData: added parameters DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, DiffieHellmanSymmetricKey_KeyAlgorithm, DiffieHellmanSymmetricKey_KeyDerivationFunction, DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, DiffieHellmanSymmetricKey_PublicKeyCertificate, DiffieHellmanSymmetricKey_SharedInformation, EncryptionWrappedKey_KeyCheckValueAlgorithm and WrappedKeyMaterial_Tr31KeyBlock.
    * Modified cmdlet Unprotect-PAYCDData: added parameters DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, DiffieHellmanSymmetricKey_KeyAlgorithm, DiffieHellmanSymmetricKey_KeyDerivationFunction, DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, DiffieHellmanSymmetricKey_PublicKeyCertificate and DiffieHellmanSymmetricKey_SharedInformation.
    * Modified cmdlet Update-PAYCDEncryptData: added parameters IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyAlgorithm, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationFunction, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_PublicKeyCertificate, IncomingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_SharedInformation, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyAlgorithm, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationFunction, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm, OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_PublicKeyCertificate and OutgoingWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_SharedInformation.

### 4.1.683 (2024-10-22 23:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.911.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Image Builder
    * Modified cmdlet New-EC2IBInfrastructureConfiguration: added parameters Placement_AvailabilityZone, Placement_HostId, Placement_HostResourceGroupArn and Placement_Tenancy.
    * Modified cmdlet Update-EC2IBInfrastructureConfiguration: added parameters Placement_AvailabilityZone, Placement_HostId, Placement_HostResourceGroupArn and Placement_Tenancy.
  * Amazon M2
    * Modified cmdlet Get-AMMBatchJobRestartPointList: added parameter AuthSecretsManagerArn.
    * Modified cmdlet Start-AMMBatchJob: added parameter AuthSecretsManagerArn.
    * Modified cmdlet Stop-AMMBatchJobExecution: added parameter AuthSecretsManagerArn.
  * Amazon re:Post Private
    * Added cmdlet Add-RESPBatchRole leveraging the BatchAddRole service API.
    * Added cmdlet Remove-RESPBatchRole leveraging the BatchRemoveRole service API.
  * Amazon Timestream Query
    * Modified cmdlet Invoke-TSQQuery: added parameter QueryInsights_Mode.
    * Modified cmdlet Start-TSQScheduledQuery: added parameter QueryInsights_Mode.

### 4.1.682 (2024-10-21 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.910.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters OrchestrationConfiguration_AdditionalModelRequestField, RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_OrchestrationConfiguration_InferenceConfig_TextInferenceConfig_MaxTokens, RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_OrchestrationConfiguration_InferenceConfig_TextInferenceConfig_StopSequences, RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_OrchestrationConfiguration_InferenceConfig_TextInferenceConfig_Temperature, RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_OrchestrationConfiguration_InferenceConfig_TextInferenceConfig_TopP and RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_OrchestrationConfiguration_PromptTemplate_TextPromptTemplate.
  * Amazon CloudWatch Application Insights
    * Modified cmdlet New-CWAIApplication: added parameter SNSNotificationArn.
    * Modified cmdlet Update-CWAIApplication: added parameter SNSNotificationArn.
  * Amazon Database Migration Service
    * Modified cmdlet Start-DMSReplicationTaskAssessmentRun: added parameter Tag.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter ZonalShiftConfig_Enabled.
    * Modified cmdlet Update-EKSClusterConfig: added parameter ZonalShiftConfig_Enabled.
  * Amazon Payment Cryptography Data
    * Added cmdlet New-PAYCDMacEmvPinChange leveraging the GenerateMacEmvPinChange service API.

### 4.1.681 (2024-10-18 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.909.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * [Breaking Change] Modified cmdlet New-ATHDataCatalog: output changed from Amazon.Athena.Model.CreateDataCatalogResponse to None.
    * [Breaking Change] Modified cmdlet Remove-ATHDataCatalog: output changed from Amazon.Athena.Model.DeleteDataCatalogResponse to None.

### 4.1.680 (2024-10-17 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.908.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Data Exchange
    * Added cmdlet Get-DTEXDataGrant leveraging the GetDataGrant service API.
    * Added cmdlet Get-DTEXDataGrantList leveraging the ListDataGrants service API.
    * Added cmdlet Get-DTEXReceivedDataGrant leveraging the GetReceivedDataGrant service API.
    * Added cmdlet Get-DTEXReceivedDataGrantList leveraging the ListReceivedDataGrants service API.
    * Added cmdlet New-DTEXDataGrant leveraging the CreateDataGrant service API.
    * Added cmdlet Receive-DTEXDataGrant leveraging the AcceptDataGrant service API.
    * Added cmdlet Remove-DTEXDataGrant leveraging the DeleteDataGrant service API.
  * Amazon QuickSight
    * Added cmdlet Start-QSDashboardSnapshotJobSchedule leveraging the StartDashboardSnapshotJobSchedule service API.
    * Modified cmdlet Restore-QSAnalysis: added parameter RestoreToFolder.

### 4.1.679 (2024-10-16 21:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.907.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3Bucket: added parameters BucketRegion and Prefix.

### 4.1.678 (2024-10-15 20:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.906.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet Start-AMPDeployment: added parameter SourceUrlType.
  * Amazon CodeBuild
    * Modified cmdlet New-CBFleet: added parameters ProxyConfiguration_DefaultBehavior and ProxyConfiguration_OrderedProxyRule.
    * Modified cmdlet Update-CBFleet: added parameters ProxyConfiguration_DefaultBehavior and ProxyConfiguration_OrderedProxyRule.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSWebExperience: added parameter Origin.
    * Modified cmdlet Update-QBUSWebExperience: added parameter Origin.
  * Amazon Redshift
    * Added cmdlet Edit-RSIntegration leveraging the ModifyIntegration service API.
    * Added cmdlet Get-RSIntegration leveraging the DescribeIntegrations service API.
    * Added cmdlet New-RSIntegration leveraging the CreateIntegration service API.
    * Added cmdlet Remove-RSIntegration leveraging the DeleteIntegration service API.
  * Amazon Resilience Hub
    * Modified cmdlet Get-RESHAppList: added parameter AwsApplicationArn.
    * Modified cmdlet New-RESHApp: added parameter AwsApplicationArn.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2ConfigurationSet: added parameter DeliveryOptions_MaxDeliverySecond.
    * Modified cmdlet Write-SES2ConfigurationSetDeliveryOption: added parameter MaxDeliverySecond.

### 4.1.677 (2024-10-14 20:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.905.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SES Mail Manager
    * Modified cmdlet Start-MMGRArchiveExport: added parameter IncludeMetadata.
  * Amazon Supply Chain
    * Added cmdlet Get-SUPCHInstance leveraging the GetInstance service API.
    * Added cmdlet Get-SUPCHInstanceList leveraging the ListInstances service API.
    * Added cmdlet New-SUPCHInstance leveraging the CreateInstance service API.
    * Added cmdlet Remove-SUPCHInstance leveraging the DeleteInstance service API.
    * Added cmdlet Update-SUPCHInstance leveraging the UpdateInstance service API.
  * Amazon Transfer for SFTP
    * Added cmdlet Get-TFRFileTransferResultList leveraging the ListFileTransferResults service API.
  * Deprecated AWSHistory which will be removed in the next major release. Instead, use '-Select *' when it is necessary to return the entire service response as cmdlet output.

### 4.1.676 (2024-10-11 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.904.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic MapReduce
    * Modified cmdlet Add-EMRInstanceFleet: added parameter InstanceFleet_Context.
    * Modified cmdlet Edit-EMRInstanceFleet: added parameter InstanceFleet_Context.

### 4.1.675 (2024-10-10 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.903.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Database Migration Service
    * Added cmdlet Edit-DMSDataMigration leveraging the ModifyDataMigration service API.
    * Added cmdlet Get-DMSDataMigration leveraging the DescribeDataMigrations service API.
    * Added cmdlet New-DMSDataMigration leveraging the CreateDataMigration service API.
    * Added cmdlet Remove-DMSDataMigration leveraging the DeleteDataMigration service API.
    * Added cmdlet Start-DMSDataMigration leveraging the StartDataMigration service API.
    * Added cmdlet Stop-DMSDataMigration leveraging the StopDataMigration service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Approve-EC2CapacityReservationBillingOwnership leveraging the AcceptCapacityReservationBillingOwnership service API.
    * Added cmdlet Deny-EC2CapacityReservationBillingOwnership leveraging the RejectCapacityReservationBillingOwnership service API.
    * Added cmdlet Get-EC2CapacityReservationBillingRequest leveraging the DescribeCapacityReservationBillingRequests service API.
    * Added cmdlet Register-EC2CapacityReservationBillingOwner leveraging the AssociateCapacityReservationBillingOwner service API.
    * Added cmdlet Unregister-EC2CapacityReservationBillingOwner leveraging the DisassociateCapacityReservationBillingOwner service API.
  * Amazon End User Messaging Social. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SOCIAL and can be listed using the command 'Get-AWSCmdletName -Service SOCIAL'.

### 4.1.674 (2024-10-09 20:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.902.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.673 (2024-10-08 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.901.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECCacheCluster: added parameter Engine.
    * Modified cmdlet Edit-ECGlobalReplicationGroup: added parameter Engine.
    * Modified cmdlet Edit-ECReplicationGroup: added parameter Engine.
    * Modified cmdlet Edit-ECServerlessCache: added parameters Engine and MajorEngineVersion.
  * Amazon MemoryDB
    * Modified cmdlet Get-MDBEngineVersion: added parameter Engine.
    * Modified cmdlet New-MDBCluster: added parameter Engine.
    * Modified cmdlet Update-MDBCluster: added parameter Engine.

### 4.1.672 (2024-10-07 21:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.900.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Added cmdlet Get-ADCJobParameterDefinitionList leveraging the ListJobParameterDefinitions service API.
    * Modified cmdlet New-ADCJob: added parameter SourceJobId.
  * Amazon Q Connect
    * Added cmdlet Get-QCAIAgent leveraging the GetAIAgent service API.
    * Added cmdlet Get-QCAIAgentList leveraging the ListAIAgents service API.
    * Added cmdlet Get-QCAIAgentVersionList leveraging the ListAIAgentVersions service API.
    * Added cmdlet Get-QCAIPrompt leveraging the GetAIPrompt service API.
    * Added cmdlet Get-QCAIPromptList leveraging the ListAIPrompts service API.
    * Added cmdlet Get-QCAIPromptVersionList leveraging the ListAIPromptVersions service API.
    * Added cmdlet New-QCAIAgent leveraging the CreateAIAgent service API.
    * Added cmdlet New-QCAIAgentVersion leveraging the CreateAIAgentVersion service API.
    * Added cmdlet New-QCAIPrompt leveraging the CreateAIPrompt service API.
    * Added cmdlet New-QCAIPromptVersion leveraging the CreateAIPromptVersion service API.
    * Added cmdlet Remove-QCAIAgent leveraging the DeleteAIAgent service API.
    * Added cmdlet Remove-QCAIAgentVersion leveraging the DeleteAIAgentVersion service API.
    * Added cmdlet Remove-QCAIPrompt leveraging the DeleteAIPrompt service API.
    * Added cmdlet Remove-QCAIPromptVersion leveraging the DeleteAIPromptVersion service API.
    * Added cmdlet Remove-QCAssistantAIAgent leveraging the RemoveAssistantAIAgent service API.
    * Added cmdlet Update-QCAIAgent leveraging the UpdateAIAgent service API.
    * Added cmdlet Update-QCAIPrompt leveraging the UpdateAIPrompt service API.
    * Added cmdlet Update-QCAssistantAIAgent leveraging the UpdateAssistantAIAgent service API.
    * Added cmdlet Update-QCSessionData leveraging the UpdateSessionData service API.
    * Modified cmdlet New-QCKnowledgeBase: added parameters BedrockFoundationModelConfiguration_ModelArn, ChunkingConfiguration_ChunkingStrategy, CrawlerLimits_RateLimit, FixedSizeChunkingConfiguration_MaxToken, FixedSizeChunkingConfiguration_OverlapPercentage, HierarchicalChunkingConfiguration_LevelConfiguration, HierarchicalChunkingConfiguration_OverlapToken, ParsingConfiguration_ParsingStrategy, ParsingPrompt_ParsingPromptText, SemanticChunkingConfiguration_BreakpointPercentileThreshold, SemanticChunkingConfiguration_BufferSize, SemanticChunkingConfiguration_MaxToken, UrlConfiguration_SeedUrl, WebCrawlerConfiguration_ExclusionFilter, WebCrawlerConfiguration_InclusionFilter and WebCrawlerConfiguration_Scope.
    * Modified cmdlet New-QCSession: added parameter AiAgentConfiguration.
    * Modified cmdlet Search-QCAssistant: added parameters IntentInputData_IntentId, OverrideKnowledgeBaseSearchType and QueryTextInputData_Text.
    * Modified cmdlet Update-QCSession: added parameter AiAgentConfiguration.

### 4.1.671 (2024-10-04 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.899.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.670 (2024-10-03 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.898.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2InstanceCpuOption leveraging the ModifyInstanceCpuOptions service API.
  * Amazon IoT
    * Modified cmdlet New-IOTDomainConfiguration: added parameters ApplicationProtocol, AuthenticationType and ClientCertificateConfig_ClientCertificateCallbackArn.
    * Modified cmdlet Update-IOTDomainConfiguration: added parameters ApplicationProtocol, AuthenticationType and ClientCertificateConfig_ClientCertificateCallbackArn.
  * Amazon Marketplace Reporting Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MR and can be listed using the command 'Get-AWSCmdletName -Service MR'.
  * Amazon QuickSight
    * Modified cmdlet New-QSTopic: added parameter ConfigOptions_QBusinessInsightsEnabled.
    * Modified cmdlet Start-QSAssetBundleExportJob: added parameters CloudFormationOverridePropertyConfiguration_Folder, IncludeFolderMember and IncludeFolderMembership.
    * Modified cmdlet Start-QSAssetBundleImportJob: added parameters OverrideParameters_Folder, OverridePermissions_Folder and OverrideTags_Folder.
    * Modified cmdlet Update-QSTopic: added parameter ConfigOptions_QBusinessInsightsEnabled.

### 4.1.669 (2024-10-02 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.897.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon B2B Data Interchange
    * Added cmdlet New-B2BIStarterMappingTemplate leveraging the CreateStarterMappingTemplate service API.
    * Added cmdlet Test-B2BIConversion leveraging the TestConversion service API.
    * Modified cmdlet New-B2BICapability: added parameter Edi_CapabilityDirection.
    * Modified cmdlet New-B2BIPartnership: added parameters Common_ValidateEdi, Delimiters_ComponentSeparator, Delimiters_DataElementSeparator, Delimiters_SegmentTerminator, FunctionalGroupHeaders_ApplicationReceiverCode, FunctionalGroupHeaders_ApplicationSenderCode, FunctionalGroupHeaders_ResponsibleAgencyCode, InterchangeControlHeaders_AcknowledgmentRequestedCode, InterchangeControlHeaders_ReceiverId, InterchangeControlHeaders_ReceiverIdQualifier, InterchangeControlHeaders_RepetitionSeparator, InterchangeControlHeaders_SenderId, InterchangeControlHeaders_SenderIdQualifier and InterchangeControlHeaders_UsageIndicatorCode.
    * Modified cmdlet New-B2BITransformer: added parameters InputConversion_FormatOptions_X12_TransactionSet, InputConversion_FormatOptions_X12_Version, InputConversion_FromFormat, Mapping_Template, Mapping_TemplateLanguage, OutputConversion_FormatOptions_X12_TransactionSet, OutputConversion_FormatOptions_X12_Version, OutputConversion_ToFormat, SampleDocuments_BucketName and SampleDocuments_Key.
    * Modified cmdlet Update-B2BICapability: added parameter Edi_CapabilityDirection.
    * Modified cmdlet Update-B2BIPartnership: added parameters Common_ValidateEdi, Delimiters_ComponentSeparator, Delimiters_DataElementSeparator, Delimiters_SegmentTerminator, FunctionalGroupHeaders_ApplicationReceiverCode, FunctionalGroupHeaders_ApplicationSenderCode, FunctionalGroupHeaders_ResponsibleAgencyCode, InterchangeControlHeaders_AcknowledgmentRequestedCode, InterchangeControlHeaders_ReceiverId, InterchangeControlHeaders_ReceiverIdQualifier, InterchangeControlHeaders_RepetitionSeparator, InterchangeControlHeaders_SenderId, InterchangeControlHeaders_SenderIdQualifier and InterchangeControlHeaders_UsageIndicatorCode.
    * Modified cmdlet Update-B2BITransformer: added parameters InputConversion_FormatOptions_X12_TransactionSet, InputConversion_FormatOptions_X12_Version, InputConversion_FromFormat, Mapping_Template, Mapping_TemplateLanguage, OutputConversion_FormatOptions_X12_TransactionSet, OutputConversion_FormatOptions_X12_Version, OutputConversion_ToFormat, SampleDocuments_BucketName and SampleDocuments_Key.
  * Amazon IoT Core Device Advisor
    * Modified cmdlet New-IOTDASuiteDefinition: added parameter ClientToken.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter JupyterLabAppSettings_BuiltInLifecycleConfigArn.
    * Modified cmdlet Update-SMDomain: added parameter JupyterLabAppSettings_BuiltInLifecycleConfigArn.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3LifecycleConfiguration: added parameter TransitionDefaultMinimumObjectSize.

### 4.1.668 (2024-10-01 21:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.896.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Added cmdlet Stop-AABIngestionJob leveraging the StopIngestionJob service API.
  * Amazon CodeArtifact
    * Modified cmdlet Get-CARepositoryEndpoint: added parameter EndpointType.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBCluster: added parameter ClusterScalabilityType.
    * Modified cmdlet New-RDSDBShardGroup: added parameter Tag.

### 4.1.667 (2024-10-01 00:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.895.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Start-CONNOutboundChatContact leveraging the StartOutboundChatContact service API.
  * Amazon Resource Groups
    * Added cmdlet Get-RGGroupingStatusList leveraging the ListGroupingStatuses service API.
    * Added cmdlet Get-RGTagSyncTask leveraging the GetTagSyncTask service API.
    * Added cmdlet Get-RGTagSyncTaskList leveraging the ListTagSyncTasks service API.
    * Added cmdlet Start-RGTagSyncTask leveraging the StartTagSyncTask service API.
    * Added cmdlet Stop-RGTagSyncTask leveraging the CancelTagSyncTask service API.
    * Modified cmdlet New-RGGroup: added parameters Criticality, DisplayName and Owner.
    * Modified cmdlet Update-RGGroup: added parameters Criticality, DisplayName and Owner.
  * Amazon Supply Chain
    * Added cmdlet Add-SUPCHResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SUPCHDataIntegrationFlow leveraging the GetDataIntegrationFlow service API.
    * Added cmdlet Get-SUPCHDataIntegrationFlowList leveraging the ListDataIntegrationFlows service API.
    * Added cmdlet Get-SUPCHDataLakeDataset leveraging the GetDataLakeDataset service API.
    * Added cmdlet Get-SUPCHDataLakeDatasetList leveraging the ListDataLakeDatasets service API.
    * Added cmdlet Get-SUPCHResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-SUPCHDataIntegrationFlow leveraging the CreateDataIntegrationFlow service API.
    * Added cmdlet New-SUPCHDataLakeDataset leveraging the CreateDataLakeDataset service API.
    * Added cmdlet Remove-SUPCHDataIntegrationFlow leveraging the DeleteDataIntegrationFlow service API.
    * Added cmdlet Remove-SUPCHDataLakeDataset leveraging the DeleteDataLakeDataset service API.
    * Added cmdlet Remove-SUPCHResourceTag leveraging the UntagResource service API.
    * Added cmdlet Update-SUPCHDataIntegrationFlow leveraging the UpdateDataIntegrationFlow service API.
    * Added cmdlet Update-SUPCHDataLakeDataset leveraging the UpdateDataLakeDataset service API.
  * Amazon Timestream InfluxDB
    * Modified cmdlet New-TIDBDbInstance: added parameter Port.
    * Modified cmdlet New-TIDBDbParameterGroup: added parameters HttpIdleTimeout_DurationType, HttpIdleTimeout_Value, HttpReadHeaderTimeout_DurationType, HttpReadHeaderTimeout_Value, HttpReadTimeout_DurationType, HttpReadTimeout_Value, HttpWriteTimeout_DurationType, HttpWriteTimeout_Value, InfluxDBv2_InfluxqlMaxSelectBucket, InfluxDBv2_InfluxqlMaxSelectPoint, InfluxDBv2_InfluxqlMaxSelectSeries, InfluxDBv2_PprofDisabled, InfluxDBv2_QueryInitialMemoryByte, InfluxDBv2_QueryMaxMemoryByte, InfluxDBv2_QueryMemoryByte, InfluxDBv2_SessionLength, InfluxDBv2_SessionRenewDisabled, InfluxDBv2_StorageCacheMaxMemorySize, InfluxDBv2_StorageCacheSnapshotMemorySize, InfluxDBv2_StorageCompactThroughputBurst, InfluxDBv2_StorageMaxConcurrentCompaction, InfluxDBv2_StorageMaxIndexLogFileSize, InfluxDBv2_StorageNoValidateFieldSize, InfluxDBv2_StorageSeriesFileMaxConcurrentSnapshotCompaction, InfluxDBv2_StorageSeriesIdSetCacheSize, InfluxDBv2_StorageWalMaxConcurrentWrite, InfluxDBv2_UiDisabled, StorageCacheSnapshotWriteColdDuration_DurationType, StorageCacheSnapshotWriteColdDuration_Value, StorageCompactFullWriteColdDuration_DurationType, StorageCompactFullWriteColdDuration_Value, StorageRetentionCheckInterval_DurationType, StorageRetentionCheckInterval_Value, StorageWalMaxWriteDelay_DurationType and StorageWalMaxWriteDelay_Value.
    * Modified cmdlet Update-TIDBDbInstance: added parameter Port.

### 4.1.666 (2024-09-27 21:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.894.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon WorkLink
  * Amazon Connect Customer Profiles
    * Modified cmdlet Write-CPFIntegration: added parameter RoleArn.
  * Amazon QuickSight
    * Added cmdlet Get-QSQPersonalizationConfiguration leveraging the DescribeQPersonalizationConfiguration service API.
    * Added cmdlet Update-QSQPersonalizationConfiguration leveraging the UpdateQPersonalizationConfiguration service API.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2ConfigurationSet: added parameter TrackingOptions_HttpsPolicy.
    * Modified cmdlet Write-SES2ConfigurationSetTrackingOption: added parameter HttpsPolicy.

### 4.1.665 (2024-09-26 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.893.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * LM
    * [Breaking Change] Removed cmdlets Get-LMPublicAccessBlockConfig, Get-LMResourcePolicy, Remove-LMResourcePolicy, Write-LMPublicAccessBlockConfig and Write-LMResourcePolicy.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter TagPropagation.
    * Modified cmdlet Update-SMDomain: added parameter TagPropagation.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Copy-S3Object: added parameter RequestPayer.
    * Modified cmdlet Remove-S3Object: added parameter RequestPayer.
    * Modified cmdlet Write-S3Object: added parameter RequestPayer.

### 4.1.664 (2024-09-25 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.892.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.663 (2024-09-24 21:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.892.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Kinesis
    * Modified cmdlet New-KINStream: added parameter Tag.
  * Amazon Pinpoint SMS Voice V2
    * Added cmdlet Get-SMSVResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-SMSVResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-SMSVResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet Get-SMSVOptOutList: added parameter Owner.
    * Modified cmdlet Get-SMSVPhoneNumber: added parameter Owner.
    * Modified cmdlet Get-SMSVPool: added parameter Owner.
    * Modified cmdlet Get-SMSVSenderId: added parameter Owner.

### 4.1.662 (2024-09-23 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.891.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameters SchedulerConfiguration_MaxConcurrentRun and SchedulerConfiguration_QueueTimeoutMinute.
    * Modified cmdlet Update-EMRServerlessApplication: added parameters SchedulerConfiguration_MaxConcurrentRun and SchedulerConfiguration_QueueTimeoutMinute.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBShardGroup: added parameter ComputeRedundancy.
  * Amazon Resource Explorer
    * Added cmdlet Get-AREXResourceList leveraging the ListResources service API.

### 4.1.661 (2024-09-21 01:29Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.890.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SageMaker Metrics Service
    * Added cmdlet Get-SMMMetric leveraging the BatchGetMetrics service API.

### 4.1.660 (2024-09-19 20:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.889.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeConnections
    * Modified cmdlet New-CCONSyncConfiguration: added parameter PullRequestComment.
    * Modified cmdlet Update-CCONSyncConfiguration: added parameter PullRequestComment.
  * Amazon Glue
    * Added cmdlet Test-GLUEConnection leveraging the TestConnection service API.
  * Amazon Lambda
    * Modified cmdlet New-LMCodeSigningConfig: added parameter Tag.
    * Modified cmdlet New-LMEventSourceMapping: added parameter Tag.
  * Amazon QuickSight
    * Added cmdlet Get-QSFoldersForResourceList leveraging the ListFoldersForResource service API.
  * Amazon WorkSpaces Web
    * Added cmdlet Get-WSWSession leveraging the GetSession service API.
    * Added cmdlet Get-WSWSessionList leveraging the ListSessions service API.
    * Added cmdlet Revoke-WSWSession leveraging the ExpireSession service API.

### 4.1.659 (2024-09-18 20:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.888.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Directory Service
    * Added cmdlet Disable-DSDirectoryDataAccess leveraging the DisableDirectoryDataAccess service API.
    * Added cmdlet Enable-DSDirectoryDataAccess leveraging the EnableDirectoryDataAccess service API.
    * Added cmdlet Get-DSDirectoryDataAccess leveraging the DescribeDirectoryDataAccess service API.
  * Amazon Directory Service Data. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DSD and can be listed using the command 'Get-AWSCmdletName -Service DSD'.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet New-S3Session: added parameters BucketKeyEnabled, ServerSideEncryption, SSEKMSEncryptionContext and SSEKMSKeyId.

### 4.1.658 (2024-09-17 20:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.887.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Lambda
    * Added cmdlet Get-LMPublicAccessBlockConfig leveraging the GetPublicAccessBlockConfig service API.
    * Added cmdlet Get-LMResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-LMResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-LMPublicAccessBlockConfig leveraging the PutPublicAccessBlockConfig service API.
    * Added cmdlet Write-LMResourcePolicy leveraging the PutResourcePolicy service API.
  * Amazon Systems Manager
    * Modified cmdlet Start-SSMAutomationExecution: added parameter TargetLocationsURL.

### 4.1.657 (2024-09-16 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.886.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet New-BDRModelInvocationJob: added parameters S3InputDataConfig_S3BucketOwner, S3OutputDataConfig_S3BucketOwner, VpcConfig_SecurityGroupId and VpcConfig_SubnetId.
  * Amazon IoT
    * Added cmdlet Add-IOTSbomWithPackageVersion leveraging the AssociateSbomWithPackageVersion service API.
    * Added cmdlet Get-IOTSbomValidationResultList leveraging the ListSbomValidationResults service API.
    * Added cmdlet Remove-IOTSbomFromPackageVersion leveraging the DisassociateSbomFromPackageVersion service API.
    * Modified cmdlet Get-IOTJob: added parameter BeforeSubstitution.
    * Modified cmdlet Get-IOTJobDocument: added parameter BeforeSubstitution.
    * Modified cmdlet New-IOTPackageVersion: added parameters Recipe, S3Location_Bucket, S3Location_Key and S3Location_Version.
    * Modified cmdlet Update-IOTPackageVersion: added parameters Recipe, S3Location_Bucket, S3Location_Key and S3Location_Version.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSGlobalCluster: added parameter Tag.

### 4.1.656 (2024-09-13 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.885.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.655 (2024-09-12 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.885.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter ResourcesToReplicateTag.
  * Amazon Cognito Identity Provider
    * Modified cmdlet Set-CGIPUserMFAPreference: added parameters EmailMfaSettings_Enabled and EmailMfaSettings_PreferredMfa.
    * Modified cmdlet Set-CGIPUserMFAPreferenceAdmin: added parameters EmailMfaSettings_Enabled and EmailMfaSettings_PreferredMfa.
    * Modified cmdlet Set-CGIPUserPoolMfaConfig: added parameters EmailMfaConfiguration_Message and EmailMfaConfiguration_Subject.
  * Amazon Elastic MapReduce
    * Modified cmdlet Add-EMRInstanceFleet: added parameters InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_CapacityReservationPreference, InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_CapacityReservationResourceGroupArn, InstanceFleet_ResizeSpecifications_OnDemandResizeSpecification_CapacityReservationOptions_UsageStrategy, OnDemandResizeSpecification_AllocationStrategy and SpotResizeSpecification_AllocationStrategy.
    * Modified cmdlet Edit-EMRInstanceFleet: added parameters CapacityReservationOptions_CapacityReservationPreference, CapacityReservationOptions_CapacityReservationResourceGroupArn, CapacityReservationOptions_UsageStrategy, InstanceFleet_InstanceTypeConfig, OnDemandResizeSpecification_AllocationStrategy and SpotResizeSpecification_AllocationStrategy.
  * Amazon Elemental MediaConvert
    * Added cmdlet Get-EMCVersionList leveraging the ListVersions service API.
    * Modified cmdlet New-EMCJob: added parameter JobEngineVersion.
  * Amazon Glue
    * Modified cmdlet New-GLUETableOptimizer: added parameters IcebergConfiguration_CleanExpiredFile, IcebergConfiguration_Location, IcebergConfiguration_NumberOfSnapshotsToRetain, IcebergConfiguration_OrphanFileRetentionPeriodInDay and IcebergConfiguration_SnapshotRetentionPeriodInDay.
    * Modified cmdlet Update-GLUETableOptimizer: added parameters IcebergConfiguration_CleanExpiredFile, IcebergConfiguration_Location, IcebergConfiguration_NumberOfSnapshotsToRetain, IcebergConfiguration_OrphanFileRetentionPeriodInDay and IcebergConfiguration_SnapshotRetentionPeriodInDay.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGNFSFileShare: added parameter EncryptionType.
    * Modified cmdlet New-SGSMBFileShare: added parameter EncryptionType.
    * Modified cmdlet Update-SGNFSFileShare: added parameter EncryptionType.
    * Modified cmdlet Update-SGSMBFileShare: added parameter EncryptionType.

### 4.1.654 (2024-09-11 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.884.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLChannelPlacementGroup leveraging the DescribeChannelPlacementGroup service API.
    * Added cmdlet Get-EMLChannelPlacementGroupList leveraging the ListChannelPlacementGroups service API.
    * Added cmdlet Get-EMLCluster leveraging the DescribeCluster service API.
    * Added cmdlet Get-EMLClusterList leveraging the ListClusters service API.
    * Added cmdlet Get-EMLNetwork leveraging the DescribeNetwork service API.
    * Added cmdlet Get-EMLNetworkList leveraging the ListNetworks service API.
    * Added cmdlet Get-EMLNode leveraging the DescribeNode service API.
    * Added cmdlet Get-EMLNodeList leveraging the ListNodes service API.
    * Added cmdlet New-EMLChannelPlacementGroup leveraging the CreateChannelPlacementGroup service API.
    * Added cmdlet New-EMLCluster leveraging the CreateCluster service API.
    * Added cmdlet New-EMLNetwork leveraging the CreateNetwork service API.
    * Added cmdlet New-EMLNode leveraging the CreateNode service API.
    * Added cmdlet New-EMLNodeRegistrationScript leveraging the CreateNodeRegistrationScript service API.
    * Added cmdlet Remove-EMLChannelPlacementGroup leveraging the DeleteChannelPlacementGroup service API.
    * Added cmdlet Remove-EMLCluster leveraging the DeleteCluster service API.
    * Added cmdlet Remove-EMLNetwork leveraging the DeleteNetwork service API.
    * Added cmdlet Remove-EMLNode leveraging the DeleteNode service API.
    * Added cmdlet Update-EMLChannelPlacementGroup leveraging the UpdateChannelPlacementGroup service API.
    * Added cmdlet Update-EMLCluster leveraging the UpdateCluster service API.
    * Added cmdlet Update-EMLNetwork leveraging the UpdateNetwork service API.
    * Added cmdlet Update-EMLNode leveraging the UpdateNode service API.
    * Added cmdlet Update-EMLNodeState leveraging the UpdateNodeState service API.
    * Modified cmdlet New-EMLChannel: added parameters AnywhereSettings_ChannelPlacementGroupId and AnywhereSettings_ClusterId.
    * Modified cmdlet New-EMLInput: added parameters InputNetworkLocation and MulticastSettings_Source.
    * Modified cmdlet Update-EMLInput: added parameter MulticastSettings_Source.
  * Amazon GuardDuty
    * Modified cmdlet Get-GDFindingStatistic: added parameters GroupBy, MaxResult and OrderBy.

### 4.1.653 (2024-09-10 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.883.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EventBridge Pipes
    * Modified cmdlet New-PIPESPipe: added parameter KmsKeyIdentifier.
    * Modified cmdlet Update-PIPESPipe: added parameter KmsKeyIdentifier.

### 4.1.652 (2024-09-09 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.882.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Interactive Video Service RealTime
    * Added cmdlet Get-IVSRTIngestConfiguration leveraging the GetIngestConfiguration service API.
    * Added cmdlet Get-IVSRTIngestConfigurationList leveraging the ListIngestConfigurations service API.
    * Added cmdlet New-IVSRTIngestConfiguration leveraging the CreateIngestConfiguration service API.
    * Added cmdlet Remove-IVSRTIngestConfiguration leveraging the DeleteIngestConfiguration service API.
    * Added cmdlet Update-IVSRTIngestConfiguration leveraging the UpdateIngestConfiguration service API.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpoint: added parameter SessionId.
    * Modified cmdlet Invoke-SMREndpointWithResponseStream: added parameter SessionId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCluster: added parameters Eks_ClusterArn and NodeRecovery.
    * Modified cmdlet Update-SMCluster: added parameter NodeRecovery.

### 4.1.651 (2024-09-06 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.881.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Q Apps
    * Added cmdlet Update-qappsLibraryItemMetadata leveraging the UpdateLibraryItemMetadata service API.

### 4.1.650 (2024-09-05 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.880.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Application Signals
    * Modified cmdlet New-CWASServiceLevelObjective: added parameters MonitoredRequestCountMetric_BadCountMetric, MonitoredRequestCountMetric_GoodCountMetric, RequestBasedSliConfig_ComparisonOperator, RequestBasedSliConfig_MetricThreshold, RequestBasedSliMetricConfig_KeyAttribute, RequestBasedSliMetricConfig_MetricType, RequestBasedSliMetricConfig_OperationName and RequestBasedSliMetricConfig_TotalRequestCountMetric.
    * Modified cmdlet Update-CWASServiceLevelObjective: added parameters MonitoredRequestCountMetric_BadCountMetric, MonitoredRequestCountMetric_GoodCountMetric, RequestBasedSliConfig_ComparisonOperator, RequestBasedSliConfig_MetricThreshold, RequestBasedSliMetricConfig_KeyAttribute, RequestBasedSliMetricConfig_MetricType, RequestBasedSliMetricConfig_OperationName and RequestBasedSliMetricConfig_TotalRequestCountMetric.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameters IdleSettings_IdleTimeoutInMinute, IdleSettings_LifecycleManagement, IdleSettings_MaxIdleTimeoutInMinute and IdleSettings_MinIdleTimeoutInMinute.
    * Modified cmdlet New-SMSpace: added parameters SpaceSettings_CodeEditorAppSettings_AppLifecycleManagement_IdleSettings_IdleTimeoutInMinutes and SpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_IdleTimeoutInMinutes.
    * Modified cmdlet Update-SMDomain: added parameters IdleSettings_IdleTimeoutInMinute, IdleSettings_LifecycleManagement, IdleSettings_MaxIdleTimeoutInMinute and IdleSettings_MinIdleTimeoutInMinute.
    * Modified cmdlet Update-SMSpace: added parameters SpaceSettings_CodeEditorAppSettings_AppLifecycleManagement_IdleSettings_IdleTimeoutInMinutes and SpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_IdleTimeoutInMinutes.

### 4.1.649 (2024-09-04 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.879.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Added cmdlet Find-CWLConfigurationTemplate leveraging the DescribeConfigurationTemplates service API.
    * Added cmdlet Update-CWLDeliveryConfiguration leveraging the UpdateDeliveryConfiguration service API.
    * Modified cmdlet New-CWLDelivery: added parameters FieldDelimiter, RecordField, S3DeliveryConfiguration_EnableHiveCompatiblePath and S3DeliveryConfiguration_SuffixPath.
  * Amazon Fault Injection Simulator
    * Added cmdlet Get-FISSafetyLever leveraging the GetSafetyLever service API.
    * Added cmdlet Update-FISSafetyLeverState leveraging the UpdateSafetyLeverState service API.
  * Amazon S3 Control
    * Added cmdlet Get-S3CCallerAccessGrantList leveraging the ListCallerAccessGrants service API.

### 4.1.648 (2024-09-03 20:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.878.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Approve-DZSubscriptionRequest: added parameter AssetScope.
  * Amazon Elastic Load Balancing V2
    * Added cmdlet Edit-ELB2ListenerAttribute leveraging the ModifyListenerAttributes service API.
    * Added cmdlet Get-ELB2ListenerAttribute leveraging the DescribeListenerAttributes service API.
  * Amazon Elemental MediaConnect
    * Added cmdlet Get-EMCNFlowSourceThumbnail leveraging the DescribeFlowSourceThumbnail service API.
    * Modified cmdlet New-EMCNFlow: added parameter SourceMonitoringConfig_ThumbnailState.
    * Modified cmdlet Update-EMCNFlow: added parameter SourceMonitoringConfig_ThumbnailState.
  * Amazon Timestream InfluxDB
    * Modified cmdlet Update-TIDBDbInstance: added parameters DbInstanceType and DeploymentType.

### 4.1.647 (2024-08-30 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.877.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Modified cmdlet Write-CWLLogEvent: added parameters Entity_Attribute and Entity_KeyAttribute.
  * Amazon DataZone
    * Added cmdlet Add-DZEntityOwner leveraging the AddEntityOwner service API.
    * Added cmdlet Add-DZPolicyGrant leveraging the AddPolicyGrant service API.
    * Added cmdlet Get-DZDomainUnit leveraging the GetDomainUnit service API.
    * Added cmdlet Get-DZDomainUnitsForParentList leveraging the ListDomainUnitsForParent service API.
    * Added cmdlet Get-DZEntityOwnerList leveraging the ListEntityOwners service API.
    * Added cmdlet Get-DZPolicyGrantList leveraging the ListPolicyGrants service API.
    * Added cmdlet New-DZDomainUnit leveraging the CreateDomainUnit service API.
    * Added cmdlet Remove-DZDomainUnit leveraging the DeleteDomainUnit service API.
    * Added cmdlet Remove-DZEntityOwner leveraging the RemoveEntityOwner service API.
    * Added cmdlet Remove-DZPolicyGrant leveraging the RemovePolicyGrant service API.
    * Added cmdlet Update-DZDomainUnit leveraging the UpdateDomainUnit service API.
    * Modified cmdlet New-DZProject: added parameter DomainUnitId.
  * Amazon Redshift Data API Service
    * Modified cmdlet Push-RSDBatchStatement: added parameters SessionId and SessionKeepAliveSecond.
    * Modified cmdlet Send-RSDStatement: added parameters SessionId and SessionKeepAliveSecond.

### 4.1.646 (2024-08-29 21:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.876.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Personalize
    * Added cmdlet Update-PERSSolution leveraging the UpdateSolution service API.
  * Amazon Step Functions
    * Modified cmdlet Test-SFNStateMachineDefinitionValidation: added parameters MaxResult and Severity.

### 4.1.645 (2024-08-28 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.875.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppConfig
    * Added cmdlet Get-APPCAccountSetting leveraging the GetAccountSettings service API.
    * Added cmdlet Update-APPCAccountSetting leveraging the UpdateAccountSettings service API.
    * Modified cmdlet Remove-APPCConfigurationProfile: added parameter DeletionProtectionCheck.
    * Modified cmdlet Remove-APPCEnvironment: added parameter DeletionProtectionCheck.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2Address: added parameter IpamPoolId.
  * Amazon Parallel Computing Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PCS and can be listed using the command 'Get-AWSCmdletName -Service PCS'.

### 4.1.644 (2024-08-27 20:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.874.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRInferenceProfile leveraging the GetInferenceProfile service API.
    * Added cmdlet Get-BDRInferenceProfileList leveraging the ListInferenceProfiles service API.

### 4.1.643 (2024-08-26 20:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.873.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT SiteWise
    * Modified cmdlet Get-IOTSWAssetModel: added parameter AssetModelVersion.
    * Modified cmdlet Get-IOTSWAssetModelCompositeModel: added parameter AssetModelVersion.
    * Modified cmdlet Get-IOTSWAssetModelCompositeModelList: added parameter AssetModelVersion.
    * Modified cmdlet Get-IOTSWAssetModelList: added parameter AssetModelVersion.
    * Modified cmdlet Get-IOTSWAssetModelPropertyList: added parameter AssetModelVersion.
    * Modified cmdlet New-IOTSWAssetModelCompositeModel: added parameters IfMatch, IfNoneMatch and MatchForVersionType.
    * Modified cmdlet Remove-IOTSWAssetModel: added parameters IfMatch, IfNoneMatch and MatchForVersionType.
    * Modified cmdlet Remove-IOTSWAssetModelCompositeModel: added parameters IfMatch, IfNoneMatch and MatchForVersionType.
    * Modified cmdlet Update-IOTSWAssetModel: added parameters IfMatch, IfNoneMatch and MatchForVersionType.
    * Modified cmdlet Update-IOTSWAssetModelCompositeModel: added parameters IfMatch, IfNoneMatch and MatchForVersionType.
  * Amazon WorkSpaces
    * Modified cmdlet Get-WKSWorkspaceDirectory: added parameter Filter.
    * Modified cmdlet Register-WKSWorkspaceDirectory: added parameters IdcInstanceArn, MicrosoftEntraConfig_ApplicationConfigSecretArn and MicrosoftEntraConfig_TenantId.

### 4.1.642 (2024-08-23 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.872.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSApplication: added parameters ClientIdsForOIDC, IamIdentityProviderArn and IdentityType.
    * Modified cmdlet New-QBUSWebExperience: added parameters OpenIDConnectConfiguration_SecretsArn, OpenIDConnectConfiguration_SecretsRole and SamlConfiguration_AuthenticationUrl.
    * Modified cmdlet Update-QBUSApplication: added parameters AutoSubscriptionConfiguration_AutoSubscribe and AutoSubscriptionConfiguration_DefaultSubscriptionType.
    * Modified cmdlet Update-QBUSWebExperience: added parameters OpenIDConnectConfiguration_SecretsArn, OpenIDConnectConfiguration_SecretsRole and SamlConfiguration_AuthenticationUrl.

### 4.1.641 (2024-08-22 21:29Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.871.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRImportedModel leveraging the GetImportedModel service API.
    * Added cmdlet Get-BDRImportedModelList leveraging the ListImportedModels service API.
    * Added cmdlet Get-BDRModelImportJob leveraging the GetModelImportJob service API.
    * Added cmdlet Get-BDRModelImportJobList leveraging the ListModelImportJobs service API.
    * Added cmdlet New-BDRModelImportJob leveraging the CreateModelImportJob service API.
    * Added cmdlet Remove-BDRImportedModel leveraging the DeleteImportedModel service API.
    * Added cmdlet Set-BDRBatchDeleteEvaluationJob leveraging the BatchDeleteEvaluationJob service API.
  * Amazon QuickSight
    * Modified cmdlet New-QSAnalysis: added parameter QueryExecutionOptions_QueryExecutionMode.
    * Modified cmdlet New-QSEmbedUrlForAnonymousUser: added parameters Dashboard_DisabledFeature, Dashboard_EnabledFeature and SharedView_Enabled.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameters ExperienceConfiguration_Dashboard_FeatureConfigurations_SharedView_Enabled and ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_SharedView_Enabled.
    * Modified cmdlet New-QSTemplate: added parameter QueryExecutionOptions_QueryExecutionMode.
    * Modified cmdlet Update-QSAnalysis: added parameter QueryExecutionOptions_QueryExecutionMode.
    * Modified cmdlet Update-QSTemplate: added parameter QueryExecutionOptions_QueryExecutionMode.

### 4.1.640 (2024-08-21 20:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.870.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon CodeStar
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameter JobRunQueuingEnabled.
    * Modified cmdlet Start-GLUEJobRun: added parameter JobRunQueuingEnabled.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter KMSKeyArn.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter KMSKeyArn.

### 4.1.639 (2024-08-20 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.869.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Copy-S3Object: added parameter IfNoneMatch.
    * Modified cmdlet Write-S3Object: added parameter IfNoneMatch.

### 4.1.638 (2024-08-19 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.868.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRModelInvocationJob leveraging the GetModelInvocationJob service API.
    * Added cmdlet Get-BDRModelInvocationJobList leveraging the ListModelInvocationJobs service API.
    * Added cmdlet New-BDRModelInvocationJob leveraging the CreateModelInvocationJob service API.
    * Added cmdlet Stop-BDRModelInvocationJob leveraging the StopModelInvocationJob service API.
  * Amazon CodeBuild
    * Modified cmdlet New-CBFleet: added parameter ImageId.
    * Modified cmdlet Update-CBFleet: added parameter ImageId.
  * Amazon Lambda
    * Added cmdlet Get-LMFunctionRecursionConfig leveraging the GetFunctionRecursionConfig service API.
    * Added cmdlet Write-LMFunctionRecursionConfig leveraging the PutFunctionRecursionConfig service API.

### 4.1.637 (2024-08-16 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.867.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter Context.
    * Modified cmdlet Update-BATComputeEnvironment: added parameter Context.

### 4.1.636 (2024-08-15 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.866.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Added cmdlet Start-DOCFailoverGlobalCluster leveraging the FailoverGlobalCluster service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3Bucket: added parameters ContinuationToken and MaxBucket.

### 4.1.635 (2024-08-14 20:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.865.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.634 (2024-08-13 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.864.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter CacheConfig_Type.
    * Modified cmdlet Update-AMPApp: added parameter CacheConfig_Type.
  * Amazon AppStream
    * Added cmdlet Get-APSThemeForStack leveraging the DescribeThemeForStack service API.
    * Added cmdlet New-APSThemeForStack leveraging the CreateThemeForStack service API.
    * Added cmdlet Remove-APSThemeForStack leveraging the DeleteThemeForStack service API.
    * Added cmdlet Update-APSThemeForStack leveraging the UpdateThemeForStack service API.
  * Amazon Glue
    * Modified cmdlet Get-GLUETableList: added parameter AttributesToGet.
  * Amazon Neptune Graph
    * Modified cmdlet New-NEPTGGraphUsingImportTask: added parameter BlankNodeHandling.
    * Modified cmdlet Start-NEPTGImportTask: added parameter BlankNodeHandling.

### 4.1.633 (2024-08-12 20:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.863.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Move-EC2CapacityReservationInstance leveraging the MoveCapacityReservationInstances service API.
    * Added cmdlet New-EC2CapacityReservationBySplitting leveraging the CreateCapacityReservationBySplitting service API.
    * Modified cmdlet Edit-EC2CapacityReservation: added parameter InstanceMatchCriterion.
  * Amazon Elemental MediaLive
    * Modified cmdlet Update-EMLMultiplex: added parameter PacketIdentifiersMapping.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAutoMLJobV2: added parameter EmrServerlessComputeConfig_ExecutionRoleARN.

### 4.1.632 (2024-08-09 21:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.862.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Modified cmdlet Update-CONNContactRoutingData: added parameter RoutingCriteria_Step.

### 4.1.631 (2024-08-08 20:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.861.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter AdvancedSecurityAdditionalFlows_CustomAuthMode.
    * Modified cmdlet Update-CGIPUserPool: added parameter AdvancedSecurityAdditionalFlows_CustomAuthMode.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2Ipam: added parameter EnablePrivateGua.
    * Modified cmdlet New-EC2Ipam: added parameter EnablePrivateGua.
  * Amazon Glue
    * Modified cmdlet Find-GLUETable: added parameter IncludeStatusDetail.
    * Modified cmdlet Get-GLUETable: added parameter IncludeStatusDetail.
    * Modified cmdlet Get-GLUETableList: added parameter IncludeStatusDetail.

### 4.1.630 (2024-08-07 20:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.860.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppIntegrations Service
    * Added cmdlet New-AISDataIntegrationAssociation leveraging the CreateDataIntegrationAssociation service API.
    * Added cmdlet Update-AISDataIntegrationAssociation leveraging the UpdateDataIntegrationAssociation service API.
  * Amazon Glue
    * Added cmdlet Get-GLUEDataQualityModel leveraging the GetDataQualityModel service API.
    * Added cmdlet Get-GLUEDataQualityModelResult leveraging the GetDataQualityModelResult service API.
    * Added cmdlet Get-GLUEDataQualityStatisticAnnotationList leveraging the ListDataQualityStatisticAnnotations service API.
    * Added cmdlet Get-GLUEDataQualityStatisticList leveraging the ListDataQualityStatistics service API.
    * Added cmdlet Set-GLUEBatchDataQualityStatisticAnnotation leveraging the BatchPutDataQualityStatisticAnnotation service API.
    * Added cmdlet Write-GLUEDataQualityProfileAnnotation leveraging the PutDataQualityProfileAnnotation service API.
    * Modified cmdlet New-GLUEDataQualityRuleset: added parameter DataQualitySecurityConfiguration.
    * Modified cmdlet Start-GLUEDataQualityRuleRecommendationRun: added parameter DataQualitySecurityConfiguration.

### 4.1.629 (2024-08-06 20:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.859.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter PasswordPolicy_PasswordHistorySize.
    * Modified cmdlet Update-CGIPUserPool: added parameter PasswordPolicy_PasswordHistorySize.
  * Amazon Cost Optimization Hub
    * Modified cmdlet Get-COHRecommendationSummaryList: added parameter Metric.

### 4.1.628 (2024-08-05 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.858.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Added cmdlet Get-DZDataProduct leveraging the GetDataProduct service API.
    * Added cmdlet Get-DZDataProductRevisionList leveraging the ListDataProductRevisions service API.
    * Added cmdlet New-DZDataProduct leveraging the CreateDataProduct service API.
    * Added cmdlet New-DZDataProductRevision leveraging the CreateDataProductRevision service API.
    * Added cmdlet Remove-DZDataProduct leveraging the DeleteDataProduct service API.
    * Modified cmdlet Get-DZSubscriptionGrantList: added parameter OwningProjectId.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRAccountSetting leveraging the GetAccountSetting service API.
    * Added cmdlet Write-ECRAccountSetting leveraging the PutAccountSetting service API.
  * Amazon Kinesis Video WebRTC Storage
    * Added cmdlet Join-KVWSStorageSessionAsViewer leveraging the JoinStorageSessionAsViewer service API.

### 4.1.627 (2024-08-02 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.857.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Resilience Hub
    * Added cmdlet Approve-RESHResourceGroupingRecommendation leveraging the AcceptResourceGroupingRecommendations service API.
    * Added cmdlet Deny-RESHResourceGroupingRecommendation leveraging the RejectResourceGroupingRecommendations service API.
    * Added cmdlet Get-RESHResourceGroupingRecommendationList leveraging the ListResourceGroupingRecommendations service API.
    * Added cmdlet Get-RESHResourceGroupingRecommendationTask leveraging the DescribeResourceGroupingRecommendationTask service API.
    * Added cmdlet Start-RESHResourceGroupingRecommendationTask leveraging the StartResourceGroupingRecommendationTask service API.

### 4.1.626 (2024-08-01 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.856.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRModelCopyJob leveraging the GetModelCopyJob service API.
    * Added cmdlet Get-BDRModelCopyJobList leveraging the ListModelCopyJobs service API.
    * Added cmdlet New-BDRModelCopyJob leveraging the CreateModelCopyJob service API.
    * Modified cmdlet Get-BDRCustomModelList: added parameter IsOwned.
  * Amazon Control Catalog
    * Added cmdlet Get-CLCATControl leveraging the GetControl service API.
    * Added cmdlet Get-CLCATControlList leveraging the ListControls service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBShardGroup: added parameter MinACU.
    * Modified cmdlet New-RDSDBShardGroup: added parameter MinACU.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameters EmrSettings_AssumableRoleArn and EmrSettings_ExecutionRoleArn.
    * Modified cmdlet Update-SMDomain: added parameters EmrSettings_AssumableRoleArn and EmrSettings_ExecutionRoleArn.
  * Amazon Systems Manager QuickSetup. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSMQS and can be listed using the command 'Get-AWSCmdletName -Service SSMQS'.

### 4.1.625 (2024-07-30 20:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.855.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodePipeline
    * Added cmdlet Get-CPRuleExecutionList leveraging the ListRuleExecutions service API.
    * Added cmdlet Get-CPRuleTypeList leveraging the ListRuleTypes service API.
    * Added cmdlet Skip-CPStageCondition leveraging the OverrideStageCondition service API.
  * Amazon IAM Roles Anywhere
    * Modified cmdlet New-IAMRAProfile: added parameter AcceptRoleSessionName.
    * Modified cmdlet Update-IAMRAProfile: added parameter AcceptRoleSessionName.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameters GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt, GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier, GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version, GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus, GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt, GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier, GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version and GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus.
    * Modified cmdlet New-LMBV2Intent: added parameters BedrockKnowledgeStoreConfiguration_ExactResponse, BedrockModelConfiguration_CustomPrompt, BedrockModelConfiguration_TraceStatus, Guardrail_Identifier, Guardrail_Version and QnAIntentConfiguration_DataSourceConfiguration_BedrockKnowledgeStoreConfiguration_ExactResponseFields_AnswerField.
    * Modified cmdlet Update-LMBV2BotLocale: added parameters GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_CustomPrompt, GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Identifier, GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_Guardrail_Version, GenerativeAISettings_BuildtimeSettings_DescriptiveBotBuilder_BedrockModelSpecification_TraceStatus, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_CustomPrompt, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Identifier, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_Guardrail_Version, GenerativeAISettings_BuildtimeSettings_SampleUtteranceGeneration_BedrockModelSpecification_TraceStatus, GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_CustomPrompt, GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Identifier, GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_Guardrail_Version and GenerativeAISettings_RuntimeSettings_SlotResolutionImprovement_BedrockModelSpecification_TraceStatus.
    * Modified cmdlet Update-LMBV2Intent: added parameters BedrockKnowledgeStoreConfiguration_ExactResponse, BedrockModelConfiguration_CustomPrompt, BedrockModelConfiguration_TraceStatus, Guardrail_Identifier, Guardrail_Version and QnAIntentConfiguration_DataSourceConfiguration_BedrockKnowledgeStoreConfiguration_ExactResponseFields_AnswerField.
  * Amazon Telco Network Builder
    * Modified cmdlet Get-TNBSolNetworkOperationList: added parameter NsInstanceId.
    * Modified cmdlet Update-TNBSolNetworkInstance: added parameters UpdateNs_AdditionalParamsForNs and UpdateNs_NsdInfoId.

### 4.1.624 (2024-07-29 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.854.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.623 (2024-07-25 22:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.854.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Added cmdlet Get-DZEnvironmentCredential leveraging the GetEnvironmentCredentials service API.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRRepositoryCreationTemplate leveraging the DescribeRepositoryCreationTemplates service API.
    * Added cmdlet New-ECRRepositoryCreationTemplate leveraging the CreateRepositoryCreationTemplate service API.
    * Added cmdlet Remove-ECRRepositoryCreationTemplate leveraging the DeleteRepositoryCreationTemplate service API.
    * Added cmdlet Update-ECRRepositoryCreationTemplate leveraging the UpdateRepositoryCreationTemplate service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter UpgradePolicy_SupportType.
    * Modified cmdlet Update-EKSClusterConfig: added parameter UpgradePolicy_SupportType.
  * Amazon Elastic Load Balancing V2
    * Added cmdlet Get-ELB2ResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-ELB2SharedTrustStoreAssociation leveraging the DeleteSharedTrustStoreAssociation service API.
    * Modified cmdlet Edit-ELB2Listener: added parameter MutualAuthentication_TrustStoreAssociationStatus.
    * Modified cmdlet New-ELB2Listener: added parameter MutualAuthentication_TrustStoreAssociationStatus.
  * Amazon Step Functions
    * Modified cmdlet Get-SFNExecution: added parameter IncludedData.
    * Modified cmdlet Get-SFNStateMachine: added parameter IncludedData.
    * Modified cmdlet Get-SFNStateMachineForExecution: added parameter IncludedData.
    * Modified cmdlet New-SFNActivity: added parameters EncryptionConfiguration_KmsDataKeyReusePeriodSecond, EncryptionConfiguration_KmsKeyId and EncryptionConfiguration_Type.
    * Modified cmdlet New-SFNStateMachine: added parameters EncryptionConfiguration_KmsDataKeyReusePeriodSecond, EncryptionConfiguration_KmsKeyId and EncryptionConfiguration_Type.
    * Modified cmdlet Start-SFNSyncExecution: added parameter IncludedData.
    * Modified cmdlet Update-SFNStateMachine: added parameters EncryptionConfiguration_KmsDataKeyReusePeriodSecond, EncryptionConfiguration_KmsKeyId and EncryptionConfiguration_Type.

### 4.1.622 (2024-07-24 20:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.853.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Added cmdlet Get-CRSConfiguredTableAssociationAnalysisRule leveraging the GetConfiguredTableAssociationAnalysisRule service API.
    * Added cmdlet New-CRSConfiguredTableAssociationAnalysisRule leveraging the CreateConfiguredTableAssociationAnalysisRule service API.
    * Added cmdlet Remove-CRSConfiguredTableAssociationAnalysisRule leveraging the DeleteConfiguredTableAssociationAnalysisRule service API.
    * Added cmdlet Update-CRSConfiguredTableAssociationAnalysisRule leveraging the UpdateConfiguredTableAssociationAnalysisRule service API.
    * Modified cmdlet New-CRSConfiguredTableAnalysisRule: added parameters Aggregation_AdditionalAnalysis, Custom_AdditionalAnalysis, Custom_DisallowedOutputColumn and List_AdditionalAnalysis.
    * Modified cmdlet New-CRSIdMappingTable: added parameter PassThru.
    * Modified cmdlet New-CRSIdNamespaceAssociation: added parameter PassThru.
    * Modified cmdlet Start-CRSProtectedQuery: added parameter Member_AccountId.
    * Modified cmdlet Update-CRSConfiguredTableAnalysisRule: added parameters Aggregation_AdditionalAnalysis, Custom_AdditionalAnalysis, Custom_DisallowedOutputColumn and List_AdditionalAnalysis.
  * Amazon IoT SiteWise
    * Modified cmdlet New-IOTSWGateway: added parameter SiemensIE_IotCoreThingName.
  * Amazon Medical Imaging Service
    * Modified cmdlet Copy-MISImageSet: added parameters DICOMCopies_CopiableAttribute and ForceCopy.
    * Modified cmdlet Update-MISImageSetMetadata: added parameters ForceUpdate and UpdateImageSetMetadataUpdates_RevertToVersionId.

### 4.1.621 (2024-07-23 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.852.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Added cmdlet Get-CRSCollaborationIdNamespaceAssociation leveraging the GetCollaborationIdNamespaceAssociation service API.
    * Added cmdlet Get-CRSCollaborationIdNamespaceAssociationList leveraging the ListCollaborationIdNamespaceAssociations service API.
    * Added cmdlet Get-CRSIdMappingTable leveraging the GetIdMappingTable service API.
    * Added cmdlet Get-CRSIdMappingTableList leveraging the ListIdMappingTables service API.
    * Added cmdlet Get-CRSIdNamespaceAssociation leveraging the GetIdNamespaceAssociation service API.
    * Added cmdlet Get-CRSIdNamespaceAssociationList leveraging the ListIdNamespaceAssociations service API.
    * Added cmdlet Invoke-CRSIdMappingTable leveraging the PopulateIdMappingTable service API.
    * Added cmdlet New-CRSIdMappingTable leveraging the CreateIdMappingTable service API.
    * Added cmdlet New-CRSIdNamespaceAssociation leveraging the CreateIdNamespaceAssociation service API.
    * Added cmdlet Remove-CRSIdMappingTable leveraging the DeleteIdMappingTable service API.
    * Added cmdlet Remove-CRSIdNamespaceAssociation leveraging the DeleteIdNamespaceAssociation service API.
    * Added cmdlet Update-CRSIdMappingTable leveraging the UpdateIdMappingTable service API.
    * Added cmdlet Update-CRSIdNamespaceAssociation leveraging the UpdateIdNamespaceAssociation service API.
  * Amazon CleanRoomsML
    * Modified cmdlet Start-CRMLAudienceGenerationJob: added parameters SqlParameters_AnalysisTemplateArn, SqlParameters_Parameter and SqlParameters_QueryString.
  * Amazon EntityResolution
    * Modified cmdlet New-ERESIdMappingWorkflow: added parameters RuleBasedProperties_AttributeMatchingModel, RuleBasedProperties_RecordMatchingModel, RuleBasedProperties_Rule and RuleBasedProperties_RuleDefinitionType.
    * Modified cmdlet New-ERESMatchingWorkflow: added parameter RuleBasedProperties_MatchPurpose.
    * Modified cmdlet Update-ERESIdMappingWorkflow: added parameters RuleBasedProperties_AttributeMatchingModel, RuleBasedProperties_RecordMatchingModel, RuleBasedProperties_Rule and RuleBasedProperties_RuleDefinitionType.
    * Modified cmdlet Update-ERESMatchingWorkflow: added parameter RuleBasedProperties_MatchPurpose.

### 4.1.620 (2024-07-22 22:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.851.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Mobile
  * Amazon DataZone
    * Added cmdlet Get-DZAssetFilter leveraging the GetAssetFilter service API.
    * Added cmdlet Get-DZAssetFilterList leveraging the ListAssetFilters service API.
    * Added cmdlet New-DZAssetFilter leveraging the CreateAssetFilter service API.
    * Added cmdlet Remove-DZAssetFilter leveraging the DeleteAssetFilter service API.
    * Added cmdlet Update-DZAssetFilter leveraging the UpdateAssetFilter service API.
    * Modified cmdlet Write-DZEnvironmentBlueprintConfiguration: added parameter ProvisioningConfiguration.
  * Amazon Redshift Serverless
    * Modified cmdlet New-RSSWorkgroup: added parameter IpAddressType.
    * Modified cmdlet Update-RSSWorkgroup: added parameter IpAddressType.

### 4.1.619 (2024-07-18 22:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.850.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Search-CONNAgentStatus leveraging the SearchAgentStatuses service API.
    * Added cmdlet Search-CONNUserHierarchyGroup leveraging the SearchUserHierarchyGroups service API.
    * Modified cmdlet Search-CONNUser: added parameters ListCondition_Condition and ListCondition_TargetListType.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2IpamExternalResourceVerificationToken leveraging the DescribeIpamExternalResourceVerificationTokens service API.
    * Added cmdlet New-EC2IpamExternalResourceVerificationToken leveraging the CreateIpamExternalResourceVerificationToken service API.
    * Added cmdlet Remove-EC2IpamExternalResourceVerificationToken leveraging the DeleteIpamExternalResourceVerificationToken service API.
    * Modified cmdlet Register-EC2IpamPoolCidr: added parameters IpamExternalResourceVerificationTokenId and VerificationMethod.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLInput: added parameter SrtSettings_SrtCallerSource.
    * Modified cmdlet Update-EMLInput: added parameter SrtSettings_SrtCallerSource.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters CatalogConfiguration_CatalogARN, IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds, IcebergDestinationConfiguration_BufferingHints_SizeInMBs, IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled, IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName, IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName, IcebergDestinationConfiguration_DestinationTableConfigurationList, IcebergDestinationConfiguration_ProcessingConfiguration_Enabled, IcebergDestinationConfiguration_ProcessingConfiguration_Processors, IcebergDestinationConfiguration_RetryOptions_DurationInSeconds, IcebergDestinationConfiguration_RoleARN, IcebergDestinationConfiguration_S3BackupMode, IcebergDestinationConfiguration_S3Configuration, MSKSourceConfiguration_ReadFromTimestamp, SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds and SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs.
    * Modified cmdlet Update-KINFDestination: added parameters CatalogConfiguration_CatalogARN, IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds, IcebergDestinationConfiguration_BufferingHints_SizeInMBs, IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled, IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName, IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName, IcebergDestinationConfiguration_ProcessingConfiguration_Enabled, IcebergDestinationConfiguration_ProcessingConfiguration_Processors, IcebergDestinationConfiguration_RetryOptions_DurationInSeconds, IcebergDestinationUpdate_DestinationTableConfigurationList, IcebergDestinationUpdate_RoleARN, IcebergDestinationUpdate_S3BackupMode, IcebergDestinationUpdate_S3Configuration, SnowflakeDestinationUpdate_BufferingHints_IntervalInSeconds and SnowflakeDestinationUpdate_BufferingHints_SizeInMBs.

### 4.1.618 (2024-07-12 21:48Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.849.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ARC - Zonal Shift
    * Added cmdlet Get-AZSAutoshiftObserverNotificationStatus leveraging the GetAutoshiftObserverNotificationStatus service API.
    * Added cmdlet Update-AZSAutoshiftObserverNotificationStatus leveraging the UpdateAutoshiftObserverNotificationStatus service API.
  * Amazon QuickSight
    * Added cmdlet Get-QSTopicReviewedAnswerList leveraging the ListTopicReviewedAnswers service API.
    * Added cmdlet Set-QSBatchCreateTopicReviewedAnswer leveraging the BatchCreateTopicReviewedAnswer service API.
    * Added cmdlet Set-QSBatchDeleteTopicReviewedAnswer leveraging the BatchDeleteTopicReviewedAnswer service API.

### 4.1.617 (2024-07-10 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.848.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Added cmdlet Get-AABFlow leveraging the GetFlow service API.
    * Added cmdlet Get-AABFlowAlias leveraging the GetFlowAlias service API.
    * Added cmdlet Get-AABFlowAliasList leveraging the ListFlowAliases service API.
    * Added cmdlet Get-AABFlowList leveraging the ListFlows service API.
    * Added cmdlet Get-AABFlowVersion leveraging the GetFlowVersion service API.
    * Added cmdlet Get-AABFlowVersionList leveraging the ListFlowVersions service API.
    * Added cmdlet Get-AABPrompt leveraging the GetPrompt service API.
    * Added cmdlet Get-AABPromptList leveraging the ListPrompts service API.
    * Added cmdlet Initialize-AABFlow leveraging the PrepareFlow service API.
    * Added cmdlet New-AABFlow leveraging the CreateFlow service API.
    * Added cmdlet New-AABFlowAlias leveraging the CreateFlowAlias service API.
    * Added cmdlet New-AABFlowVersion leveraging the CreateFlowVersion service API.
    * Added cmdlet New-AABPrompt leveraging the CreatePrompt service API.
    * Added cmdlet New-AABPromptVersion leveraging the CreatePromptVersion service API.
    * Added cmdlet Remove-AABFlow leveraging the DeleteFlow service API.
    * Added cmdlet Remove-AABFlowAlias leveraging the DeleteFlowAlias service API.
    * Added cmdlet Remove-AABFlowVersion leveraging the DeleteFlowVersion service API.
    * Added cmdlet Remove-AABPrompt leveraging the DeletePrompt service API.
    * Added cmdlet Update-AABFlow leveraging the UpdateFlow service API.
    * Added cmdlet Update-AABFlowAlias leveraging the UpdateFlowAlias service API.
    * Added cmdlet Update-AABPrompt leveraging the UpdatePrompt service API.
    * Modified cmdlet New-AABAgent: added parameters MemoryConfiguration_EnabledMemoryType and MemoryConfiguration_StorageDay.
    * Modified cmdlet New-AABDataSource: added parameters BedrockFoundationModelConfiguration_ModelArn, CrawlerConfiguration_ExclusionFilter, CrawlerConfiguration_InclusionFilter, CrawlerConfiguration_Scope, CrawlerLimits_RateLimit, CustomTransformationConfiguration_Transformation, DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters, DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl, DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters, DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type, DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType, DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn, DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl, DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters, DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type, DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType, DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn, DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType, HierarchicalChunkingConfiguration_LevelConfiguration, HierarchicalChunkingConfiguration_OverlapToken, ParsingConfiguration_ParsingStrategy, ParsingPrompt_ParsingPromptText, S3Location_Uri, SemanticChunkingConfiguration_BreakpointPercentileThreshold, SemanticChunkingConfiguration_BufferSize, SemanticChunkingConfiguration_MaxToken, SourceConfiguration_Domain, SourceConfiguration_SiteUrl, SourceConfiguration_TenantId and UrlConfiguration_SeedUrl.
    * Modified cmdlet Update-AABAgent: added parameters MemoryConfiguration_EnabledMemoryType and MemoryConfiguration_StorageDay.
    * Modified cmdlet Update-AABDataSource: added parameters BedrockFoundationModelConfiguration_ModelArn, CrawlerConfiguration_ExclusionFilter, CrawlerConfiguration_InclusionFilter, CrawlerConfiguration_Scope, CrawlerLimits_RateLimit, CustomTransformationConfiguration_Transformation, DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters, DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_CredentialsSecretArn, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType, DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostUrl, DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters, DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type, DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType, DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_CredentialsSecretArn, DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_HostUrl, DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_PatternObjectFilter_Filters, DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type, DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType, DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_CredentialsSecretArn, DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType, HierarchicalChunkingConfiguration_LevelConfiguration, HierarchicalChunkingConfiguration_OverlapToken, ParsingConfiguration_ParsingStrategy, ParsingPrompt_ParsingPromptText, S3Location_Uri, SemanticChunkingConfiguration_BreakpointPercentileThreshold, SemanticChunkingConfiguration_BufferSize, SemanticChunkingConfiguration_MaxToken, SourceConfiguration_Domain, SourceConfiguration_SiteUrl, SourceConfiguration_TenantId and UrlConfiguration_SeedUrl.
  * Amazon Bedrock
    * Modified cmdlet New-BDRGuardrail: added parameter ContextualGroundingPolicyConfig_FiltersConfig.
    * Modified cmdlet Update-BDRGuardrail: added parameter ContextualGroundingPolicyConfig_FiltersConfig.
  * Amazon Bedrock Agent Runtime
    * Added cmdlet Get-BARAgentMemory leveraging the GetAgentMemory service API.
    * Added cmdlet Invoke-BARFlow leveraging the InvokeFlow service API.
    * Added cmdlet Remove-BARAgentMemory leveraging the DeleteAgentMemory service API.
    * Modified cmdlet Invoke-BARAgent: added parameters MemoryId, SessionState_File and SessionState_KnowledgeBaseConfiguration.
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameter QueryTransformationConfiguration_Type.
  * Amazon Bedrock Runtime
    * Added cmdlet Invoke-BDRRGuardrail leveraging the ApplyGuardrail service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2PublicIpv4Pool: added parameter NetworkBorderGroup.
    * Modified cmdlet Register-EC2PublicIpv4PoolCidr: added parameter NetworkBorderGroup.
    * Modified cmdlet Remove-EC2PublicIpv4Pool: added parameter NetworkBorderGroup.
  * Amazon Elemental MediaConnect
    * Modified cmdlet Update-EMCNFlowOutput: added parameter OutputStatus.
  * Amazon License Manager - Linux Subscriptions
    * Added cmdlet Add-LLMSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-LLMSRegisteredSubscriptionProvider leveraging the GetRegisteredSubscriptionProvider service API.
    * Added cmdlet Get-LLMSRegisteredSubscriptionProviderList leveraging the ListRegisteredSubscriptionProviders service API.
    * Added cmdlet Get-LLMSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Register-LLMSSubscriptionProvider leveraging the RegisterSubscriptionProvider service API.
    * Added cmdlet Remove-LLMSResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-LLMSSubscriptionProvider leveraging the DeregisterSubscriptionProvider service API.

### 4.1.616 (2024-07-09 20:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.847.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon FSx
    * Modified cmdlet Update-FSXFileSystem: added parameter OntapConfiguration_HAPair.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter NaturalLanguageQueryGenerationOptions_DesiredState.
    * Modified cmdlet Update-OSDomainConfig: added parameter NaturalLanguageQueryGenerationOptions_DesiredState.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMOptimizationJob leveraging the DescribeOptimizationJob service API.
    * Added cmdlet Get-SMOptimizationJobList leveraging the ListOptimizationJobs service API.
    * Added cmdlet New-SMOptimizationJob leveraging the CreateOptimizationJob service API.
    * Added cmdlet Remove-SMOptimizationJob leveraging the DeleteOptimizationJob service API.
    * Added cmdlet Stop-SMOptimizationJob leveraging the StopOptimizationJob service API.
    * Modified cmdlet New-SMDomain: added parameters AmazonQSettings_QProfileArn and AmazonQSettings_Status.
    * Modified cmdlet Update-SMDomain: added parameters AmazonQSettings_QProfileArn and AmazonQSettings_Status.

### 4.1.615 (2024-07-08 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.846.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Q Apps. Added cmdlets to support the service. Cmdlets for the service have the noun prefix qapps and can be listed using the command 'Get-AWSCmdletName -Service qapps'.

### 4.1.614 (2024-07-05 20:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.845.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSApplication: added parameter PersonalizationConfiguration_PersonalizationControlMode.
    * Modified cmdlet Update-QBUSApplication: added parameter PersonalizationConfiguration_PersonalizationControlMode.

### 4.1.613 (2024-07-03 20:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.844.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Rekognition
    * Modified cmdlet New-REKDataset: added parameter Tag.
    * Modified cmdlet New-REKProject: added parameter Tag.

### 4.1.612 (2024-07-02 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.843.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3ObjectMetadata: added parameters ResponseCacheControl, ResponseContentDisposition, ResponseContentEncoding, ResponseContentLanguage, ResponseContentType and ResponseExpire.

### 4.1.611 (2024-07-01 22:48Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.842.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Get-CONNAuthenticationProfile leveraging the DescribeAuthenticationProfile service API.
    * Added cmdlet Get-CONNAuthenticationProfileList leveraging the ListAuthenticationProfiles service API.
    * Added cmdlet Update-CONNAuthenticationProfile leveraging the UpdateAuthenticationProfile service API.
  * Amazon Payment Cryptography Data
    * Modified cmdlet Convert-PAYCDPinData: added parameters IncomingWrappedKey_KeyCheckValueAlgorithm, IncomingWrappedKey_WrappedKeyMaterial_Tr31KeyBlock, OutgoingWrappedKey_KeyCheckValueAlgorithm and OutgoingWrappedKey_WrappedKeyMaterial_Tr31KeyBlock.
    * Modified cmdlet Protect-PAYCDData: added parameters WrappedKey_KeyCheckValueAlgorithm and WrappedKeyMaterial_Tr31KeyBlock.
    * Modified cmdlet Unprotect-PAYCDData: added parameters WrappedKey_KeyCheckValueAlgorithm and WrappedKeyMaterial_Tr31KeyBlock.
    * Modified cmdlet Update-PAYCDEncryptData: added parameters IncomingWrappedKey_KeyCheckValueAlgorithm, IncomingWrappedKey_WrappedKeyMaterial_Tr31KeyBlock, OutgoingWrappedKey_KeyCheckValueAlgorithm and OutgoingWrappedKey_WrappedKeyMaterial_Tr31KeyBlock.

### 4.1.610 (2024-06-28 22:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.841.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudHSM V2
    * Added cmdlet Get-HSM2ResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-HSM2ResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-HSM2ResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet Get-HSM2Backup: added parameter Shared.
  * Amazon Glue
    * Modified cmdlet Get-GLUEDatabaseList: added parameter AttributesToGet.
  * Amazon OpenSearch Service
    * [Breaking Change] Modified cmdlet New-OSDomain: removed parameter NaturalLanguageQueryGenerationOptions_DesiredState.
    * [Breaking Change] Modified cmdlet Update-OSDomainConfig: removed parameter NaturalLanguageQueryGenerationOptions_DesiredState.

### 4.1.609 (2024-06-27 20:48Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.840.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Added cmdlet Get-DZLineageNode leveraging the GetLineageNode service API.
    * Added cmdlet Get-DZLineageNodeHistoryList leveraging the ListLineageNodeHistory service API.
    * Added cmdlet Submit-DZLineageEvent leveraging the PostLineageEvent service API.
  * Amazon Q Connect
    * Added cmdlet Get-QCContentAssociation leveraging the GetContentAssociation service API.
    * Added cmdlet Get-QCContentAssociationList leveraging the ListContentAssociations service API.
    * Added cmdlet New-QCContentAssociation leveraging the CreateContentAssociation service API.
    * Added cmdlet Remove-QCContentAssociation leveraging the DeleteContentAssociation service API.
  * Amazon WorkSpaces
    * Added cmdlet Edit-WKSStreamingProperty leveraging the ModifyStreamingProperties service API.
    * Added cmdlet Get-WKSWorkspacesPool leveraging the DescribeWorkspacesPools service API.
    * Added cmdlet Get-WKSWorkspacesPoolSession leveraging the DescribeWorkspacesPoolSessions service API.
    * Added cmdlet New-WKSWorkspacesPool leveraging the CreateWorkspacesPool service API.
    * Added cmdlet Remove-WKSWorkspacesPool leveraging the TerminateWorkspacesPool service API.
    * Added cmdlet Remove-WKSWorkspacesPoolSession leveraging the TerminateWorkspacesPoolSession service API.
    * Added cmdlet Start-WKSWorkspacesPool leveraging the StartWorkspacesPool service API.
    * Added cmdlet Stop-WKSWorkspacesPool leveraging the StopWorkspacesPool service API.
    * Added cmdlet Update-WKSWorkspacesPool leveraging the UpdateWorkspacesPool service API.
    * Modified cmdlet Edit-WKSWorkspaceCreationProperty: added parameter WorkspaceCreationProperties_InstanceIamRoleArn.
    * Modified cmdlet Get-WKSWorkspaceDirectory: added parameter WorkspaceDirectoryName.
    * Modified cmdlet Register-WKSWorkspaceDirectory: added parameters ActiveDirectoryConfig_DomainName, ActiveDirectoryConfig_ServiceAccountSecretArn, UserIdentityType, WorkspaceDirectoryDescription, WorkspaceDirectoryName and WorkspaceType.

### 4.1.608 (2024-06-26 22:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.839.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Tower
    * Added cmdlet Get-ACTLandingZoneOperationList leveraging the ListLandingZoneOperations service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter BootstrapSelfManagedAddon.
  * Amazon Interactive Video Service RealTime
    * Added cmdlet Get-IVSRTPublicKey leveraging the GetPublicKey service API.
    * Added cmdlet Get-IVSRTPublicKeyList leveraging the ListPublicKeys service API.
    * Added cmdlet Import-IVSRTPublicKey leveraging the ImportPublicKey service API.
    * Added cmdlet Remove-IVSRTPublicKey leveraging the DeletePublicKey service API.
  * Amazon Kinesis Analytics V2
    * Added cmdlet Get-KINA2ApplicationOperation leveraging the DescribeApplicationOperation service API.
    * Added cmdlet Get-KINA2ApplicationOperationList leveraging the ListApplicationOperations service API.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter NaturalLanguageQueryGenerationOptions_DesiredState.
    * Modified cmdlet Update-OSDomainConfig: added parameter NaturalLanguageQueryGenerationOptions_DesiredState.

### 4.1.607 (2024-06-25 20:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.838.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon WorkSpaces Thin Client
    * Modified cmdlet New-WSTCEnvironment: added parameter DeviceCreationTag.
    * Modified cmdlet Update-WSTCEnvironment: added parameter DeviceCreationTag.

### 4.1.606 (2024-06-25 00:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.837.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Modified cmdlet Write-CPFProfileObjectType: added parameter MaxProfileObjectCount.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSApplication: added parameter QAppsConfiguration_QAppsControlMode.
    * Modified cmdlet Update-QBUSApplication: added parameter QAppsConfiguration_QAppsControlMode.
  * Amazon WorkSpaces Web
    * Modified cmdlet New-WSWIdentityProvider: added parameter Tag.
    * Modified cmdlet New-WSWUserSetting: added parameter DeepLinkAllowed.
    * Modified cmdlet Update-WSWUserSetting: added parameter DeepLinkAllowed.

### 4.1.605 (2024-06-20 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.836.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Compute Optimizer
    * Added cmdlet Export-CORDSDatabaseRecommendation leveraging the ExportRDSDatabaseRecommendations service API.
    * Added cmdlet Get-CORDSDatabaseRecommendation leveraging the GetRDSDatabaseRecommendations service API.
    * Added cmdlet Get-CORDSDatabaseRecommendationProjectedMetric leveraging the GetRDSDatabaseRecommendationProjectedMetrics service API.
  * Amazon Interactive Video Service RealTime
    * Modified cmdlet Get-IVSRTParticipantList: added parameter FilterByRecordingState.
    * Modified cmdlet New-IVSRTStage: added parameters AutoParticipantRecordingConfiguration_MediaType and AutoParticipantRecordingConfiguration_StorageConfigurationArn.
    * Modified cmdlet Update-IVSRTStage: added parameters AutoParticipantRecordingConfiguration_MediaType and AutoParticipantRecordingConfiguration_StorageConfigurationArn.
  * Amazon SageMaker Service
    * Added cmdlet New-SMHubContentReference leveraging the CreateHubContentReference service API.
    * Added cmdlet Remove-SMHubContentReference leveraging the DeleteHubContentReference service API.

### 4.1.604 (2024-06-19 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.835.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameters JWTOptions_Enabled, JWTOptions_PublicKey, JWTOptions_RolesKey and JWTOptions_SubjectKey.
    * Modified cmdlet Update-OSDomainConfig: added parameters JWTOptions_Enabled, JWTOptions_PublicKey, JWTOptions_RolesKey and JWTOptions_SubjectKey.

### 4.1.603 (2024-06-18 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.834.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Runtime
    * Modified cmdlet Invoke-BDRRConverse: added parameters GuardrailConfig_GuardrailIdentifier, GuardrailConfig_GuardrailVersion and GuardrailConfig_Trace.
    * Modified cmdlet Invoke-BDRRConverseStream: added parameters GuardrailConfig_GuardrailIdentifier, GuardrailConfig_GuardrailVersion, GuardrailConfig_StreamProcessingMode and GuardrailConfig_Trace.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMMlflowTrackingServer leveraging the DescribeMlflowTrackingServer service API.
    * Added cmdlet Get-SMMlflowTrackingServerList leveraging the ListMlflowTrackingServers service API.
    * Added cmdlet New-SMMlflowTrackingServer leveraging the CreateMlflowTrackingServer service API.
    * Added cmdlet New-SMPresignedMlflowTrackingServerUrl leveraging the CreatePresignedMlflowTrackingServerUrl service API.
    * Added cmdlet Remove-SMMlflowTrackingServer leveraging the DeleteMlflowTrackingServer service API.
    * Added cmdlet Start-SMMlflowTrackingServer leveraging the StartMlflowTrackingServer service API.
    * Added cmdlet Stop-SMMlflowTrackingServer leveraging the StopMlflowTrackingServer service API.
    * Added cmdlet Update-SMMlflowTrackingServer leveraging the UpdateMlflowTrackingServer service API.

### 4.1.602 (2024-06-17 21:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.833.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBWebhook: added parameters ScopeConfiguration_Domain, ScopeConfiguration_Name and ScopeConfiguration_Scope.
  * Amazon Glue
    * Added cmdlet Get-GLUEUsageProfile leveraging the GetUsageProfile service API.
    * Added cmdlet Get-GLUEUsageProfileList leveraging the ListUsageProfiles service API.
    * Added cmdlet New-GLUEUsageProfile leveraging the CreateUsageProfile service API.
    * Added cmdlet Remove-GLUEUsageProfile leveraging the DeleteUsageProfile service API.
    * Added cmdlet Update-GLUEUsageProfile leveraging the UpdateUsageProfile service API.

### 4.1.601 (2024-06-14 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.832.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Added cmdlet Get-DZEnvironmentAction leveraging the GetEnvironmentAction service API.
    * Added cmdlet Get-DZEnvironmentActionList leveraging the ListEnvironmentActions service API.
    * Added cmdlet New-DZEnvironmentAction leveraging the CreateEnvironmentAction service API.
    * Added cmdlet Remove-DZEnvironmentAction leveraging the DeleteEnvironmentAction service API.
    * Added cmdlet Reset-DZEnvironmentRole leveraging the DisassociateEnvironmentRole service API.
    * Added cmdlet Set-DZEnvironmentRole leveraging the AssociateEnvironmentRole service API.
    * Added cmdlet Update-DZEnvironmentAction leveraging the UpdateEnvironmentAction service API.
    * Modified cmdlet New-DZEnvironment: added parameters EnvironmentAccountIdentifier, EnvironmentAccountRegion and EnvironmentBlueprintIdentifier.
    * Modified cmdlet Remove-DZDataSource: added parameter RetainPermissionsOnRevokeFailure.
    * Modified cmdlet Update-DZDataSource: added parameter RetainPermissionsOnRevokeFailure.
  * Amazon Elemental MediaConvert
    * Added cmdlet Search-EMCJob leveraging the SearchJobs service API.
  * Amazon Macie 2
    * Added cmdlet Get-MAC2AutomatedDiscoveryAccountList leveraging the ListAutomatedDiscoveryAccounts service API.
    * Added cmdlet Update-MAC2UpdateAutomatedDiscoveryAccount leveraging the BatchUpdateAutomatedDiscoveryAccounts service API.
    * Modified cmdlet Update-MAC2AutomatedDiscoveryConfiguration: added parameter AutoEnableOrganizationMember.

### 4.1.600 (2024-06-13 20:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.831.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudHSM V2
    * Modified cmdlet New-HSM2Cluster: added parameter Mode.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2Channel: added parameter InputType.
    * Modified cmdlet New-MPV2OriginEndpoint: added parameter ForceEndpointErrorConfiguration_EndpointErrorCondition.
    * Modified cmdlet Update-MPV2OriginEndpoint: added parameter ForceEndpointErrorConfiguration_EndpointErrorCondition.
  * Amazon Glue
    * Modified cmdlet Start-GLUEDataQualityRulesetEvaluationRun: added parameter AdditionalRunOptions_CompositeRuleEvaluationMethod.
  * Amazon Key Management Service
    * Added cmdlet Get-KMSSharedSecret leveraging the DeriveSharedSecret service API.

### 4.1.599 (2024-06-12 20:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.830.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Backup Storage
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2TrafficMirrorFilterRule leveraging the DescribeTrafficMirrorFilterRules service API.
    * Modified cmdlet New-EC2TrafficMirrorFilterRule: added parameter TagSpecification.
  * Amazon Mainframe Modernization Application Testing. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AT and can be listed using the command 'Get-AWSCmdletName -Service AT'.
  * Amazon OpenSearch Ingestion
    * Modified cmdlet New-OSISPipeline: added parameter VpcOptions_VpcEndpointManagement.
  * Amazon Secrets Manager
    * Modified cmdlet Write-SECSecretValue: added parameter RotationToken.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2ConfigurationSetEventDestination: added parameter EventBridgeDestination_EventBusArn.
    * Modified cmdlet Update-SES2ConfigurationSetEventDestination: added parameter EventBridgeDestination_EventBusArn.

### 4.1.598 (2024-06-11 21:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.829.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GuardDuty
    * Added cmdlet Get-GDMalwareProtectionPlan leveraging the GetMalwareProtectionPlan service API.
    * Added cmdlet Get-GDMalwareProtectionPlanList leveraging the ListMalwareProtectionPlans service API.
    * Added cmdlet New-GDMalwareProtectionPlan leveraging the CreateMalwareProtectionPlan service API.
    * Added cmdlet Remove-GDMalwareProtectionPlan leveraging the DeleteMalwareProtectionPlan service API.
    * Added cmdlet Update-GDMalwareProtectionPlan leveraging the UpdateMalwareProtectionPlan service API.
  * Amazon IAM Access Analyzer
    * Added cmdlet Get-IAMAAFindingRecommendation leveraging the GetFindingRecommendation service API.
    * Added cmdlet Start-IAMAAFindingRecommendation leveraging the GenerateFindingRecommendation service API.
    * Added cmdlet Test-IAMAANoPublicAccess leveraging the CheckNoPublicAccess service API.
  * Amazon Network Manager
    * Modified cmdlet Get-NMGRNetworkRoute: added parameters CoreNetworkNetworkFunctionGroup_CoreNetworkId, CoreNetworkNetworkFunctionGroup_EdgeLocation and CoreNetworkNetworkFunctionGroup_NetworkFunctionGroupName.
  * Amazon Private CA Connector for SCEP. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PCASCEP and can be listed using the command 'Get-AWSCmdletName -Service PCASCEP'.
  * Amazon SageMaker Service
    * Modified cmdlet Get-SMModelPackageGroupList: added parameter CrossAccountFilterOption.
    * Modified cmdlet New-SMWorkforce: added parameters OidcConfig_AuthenticationRequestExtraParam and OidcConfig_Scope.
    * Modified cmdlet Update-SMWorkforce: added parameters OidcConfig_AuthenticationRequestExtraParam and OidcConfig_Scope.

### 4.1.597 (2024-06-10 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.828.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Application Signals. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CWAS and can be listed using the command 'Get-AWSCmdletName -Service CWAS'.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCluster: added parameters ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId and ManagedStorageConfiguration_KmsKeyId.
    * Modified cmdlet Update-ECSCluster: added parameters ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId and ManagedStorageConfiguration_KmsKeyId.

### 4.1.596 (2024-06-07 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.827.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Audit Manager
    * Modified cmdlet Get-AUDMControlList: added parameter ControlCatalogId.
    * [Breaking Change] Modified cmdlet Get-AUDMKeywordForDataSourceList: the type of parameter Source changed from Amazon.AuditManager.SourceType to Amazon.AuditManager.DataSourceType.
  * Amazon Verified Permissions
    * Modified cmdlet New-AVPIdentitySource: added parameters AccessTokenOnly_Audience, AccessTokenOnly_PrincipalIdClaim, IdentityTokenOnly_ClientId, IdentityTokenOnly_PrincipalIdClaim, OpenIdConnectConfiguration_EntityIdPrefix, OpenIdConnectConfiguration_GroupClaim, OpenIdConnectConfiguration_GroupEntityType and OpenIdConnectConfiguration_Issuer.
    * Modified cmdlet Update-AVPIdentitySource: added parameters AccessTokenOnly_Audience, AccessTokenOnly_PrincipalIdClaim, IdentityTokenOnly_ClientId, IdentityTokenOnly_PrincipalIdClaim, OpenIdConnectConfiguration_EntityIdPrefix, OpenIdConnectConfiguration_GroupClaim, OpenIdConnectConfiguration_GroupEntityType and OpenIdConnectConfiguration_Issuer.

### 4.1.595 (2024-06-06 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.826.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Account
    * Added cmdlet Approve-ACCTPrimaryEmailUpdate leveraging the AcceptPrimaryEmailUpdate service API.
    * Added cmdlet Get-ACCTPrimaryEmail leveraging the GetPrimaryEmail service API.
    * Added cmdlet Start-ACCTPrimaryEmailUpdate leveraging the StartPrimaryEmailUpdate service API.
  * Amazon Glue
    * Modified cmdlet Update-GLUETable: added parameters ForceUpdate and ViewUpdateAction.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled, HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN, HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN, SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled, SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN and SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN.
    * Modified cmdlet Update-KINFDestination: added parameters HttpEndpointDestinationUpdate_SecretsManagerConfiguration_Enabled, HttpEndpointDestinationUpdate_SecretsManagerConfiguration_RoleARN, HttpEndpointDestinationUpdate_SecretsManagerConfiguration_SecretARN, SnowflakeDestinationUpdate_SecretsManagerConfiguration_Enabled, SnowflakeDestinationUpdate_SecretsManagerConfiguration_RoleARN and SnowflakeDestinationUpdate_SecretsManagerConfiguration_SecretARN.
  * Amazon Location Service
    * Added cmdlet Invoke-LOCForecastGeofenceEventsOperation leveraging the ForecastGeofenceEvents service API.
    * Added cmdlet Invoke-LOCVerifyDevicePositionOperation leveraging the VerifyDevicePosition service API.
    * Modified cmdlet Set-LOCGeofence: added parameter Geometry_Geobuf.
  * Amazon Storage Gateway
    * Modified cmdlet Update-SGMaintenanceStartTime: added parameter SoftwareUpdatePreferences_AutomaticUpdatePolicy.

### 4.1.594 (2024-06-05 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.825.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Global Accelerator
    * Modified cmdlet Update-GACLAccelerator: added parameter IpAddress.
    * Modified cmdlet Update-GACLCustomRoutingAccelerator: added parameter IpAddress.

### 4.1.593 (2024-06-04 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.824.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EventBridge Pipes
    * Modified cmdlet New-PIPESPipe: added parameters TimestreamParameters_DimensionMapping, TimestreamParameters_EpochTimeUnit, TimestreamParameters_MultiMeasureMapping, TimestreamParameters_SingleMeasureMapping, TimestreamParameters_TimeFieldType, TimestreamParameters_TimestampFormat, TimestreamParameters_TimeValue and TimestreamParameters_VersionValue.
    * Modified cmdlet Update-PIPESPipe: added parameters TimestreamParameters_DimensionMapping, TimestreamParameters_EpochTimeUnit, TimestreamParameters_MultiMeasureMapping, TimestreamParameters_SingleMeasureMapping, TimestreamParameters_TimeFieldType, TimestreamParameters_TimestampFormat, TimestreamParameters_TimeValue and TimestreamParameters_VersionValue.
  * Amazon Tax Settings. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TSA and can be listed using the command 'Get-AWSCmdletName -Service TSA'.

### 4.1.592 (2024-06-03 20:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.823.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Added cmdlet Get-BATJobQueueSnapshot leveraging the GetJobQueueSnapshot service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSAddon: added parameter PodIdentityAssociation.
    * Modified cmdlet Update-EKSAddon: added parameter PodIdentityAssociation.

### 4.1.591 (2024-05-31 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.822.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Launch Wizard
    * Added cmdlet Add-LWIZResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-LWIZResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-LWIZWorkloadDeploymentPattern leveraging the GetWorkloadDeploymentPattern service API.
    * Added cmdlet Remove-LWIZResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-LWIZDeployment: added parameter Tag.

### 4.1.590 (2024-05-30 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.821.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameter BedrockEmbeddingModelConfiguration_Dimension.
    * Modified cmdlet Update-AABKnowledgeBase: added parameter BedrockEmbeddingModelConfiguration_Dimension.
  * Amazon Bedrock Runtime
    * Added cmdlet Invoke-BDRRConverse leveraging the Converse service API.
    * Added cmdlet Invoke-BDRRConverseStream leveraging the ConverseStream service API.
  * Amazon EMR Serverless
    * Added cmdlet Get-EMRServerlessJobRunAttemptList leveraging the ListJobRunAttempts service API.
    * Modified cmdlet Get-EMRServerlessDashboardForJobRun: added parameter Attempt.
    * Modified cmdlet Get-EMRServerlessJobRun: added parameter Attempt.
    * Modified cmdlet Get-EMRServerlessJobRunList: added parameter Mode.
    * Modified cmdlet Start-EMRServerlessJobRun: added parameters Mode, RetryPolicy_MaxAttempt and RetryPolicy_MaxFailedAttemptsPerHour.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAutoMLJobV2: added parameter AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CandidateGenerationConfig_AlgorithmsConfig.
    * Modified cmdlet New-SMModelPackage: added parameters ModelCard_ModelCardContent, ModelCard_ModelCardStatus and SecurityConfig_KmsKeyId.
    * Modified cmdlet Update-SMModelPackage: added parameters ModelCard_ModelCardContent and ModelCard_ModelCardStatus.

### 4.1.589 (2024-05-29 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.820.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeBuild
    * Modified cmdlet New-CBWebhook: added parameter ManualCreation.
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameter JobMode.

### 4.1.588 (2024-05-28 20:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.819.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2CustomerGateway: added parameter BgpAsnExtended.
  * Amazon Simple Workflow Service (SWF)
    * Added cmdlet Uninstall-SWFActivityType leveraging the DeleteActivityType service API.
    * Added cmdlet Uninstall-SWFWorkflowType leveraging the DeleteWorkflowType service API.

### 4.1.587 (2024-05-24 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.818.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT FleetWise
    * Modified cmdlet Get-IFWVehicleList: added parameters AttributeName and AttributeValue.

### 4.1.586 (2024-05-23 20:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.817.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameters InteractiveConfiguration_LivyEndpointEnabled and InteractiveConfiguration_StudioEnabled.
    * Modified cmdlet Update-EMRServerlessApplication: added parameters InteractiveConfiguration_LivyEndpointEnabled and InteractiveConfiguration_StudioEnabled.

### 4.1.585 (2024-05-22 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.816.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chatbot
    * Added cmdlet Add-CHATResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CHATResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CHATResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CHATChimeWebhookConfiguration: added parameter Tag.
    * Modified cmdlet New-CHATMicrosoftTeamsChannelConfiguration: added parameter Tag.
    * Modified cmdlet New-CHATSlackChannelConfiguration: added parameter Tag.
  * Amazon CloudFormation
    * Modified cmdlet Remove-CFNStack: added parameter DeletionMode.
  * Amazon OpenSearch Service
    * Modified cmdlet Update-OSDataSource: added parameter Status.
  * Amazon WAF V2
    * Modified cmdlet Get-WAF2LoggingConfiguration: added parameters LogScope and LogType.
    * Modified cmdlet Get-WAF2LoggingConfigurationList: added parameter LogScope.
    * Modified cmdlet Remove-WAF2LoggingConfiguration: added parameters LogScope and LogType.
    * Modified cmdlet Write-WAF2LoggingConfiguration: added parameters LoggingConfiguration_LogScope and LoggingConfiguration_LogType.

### 4.1.584 (2024-05-21 20:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.815.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameter MaintenanceWindow.
  * Amazon Lightsail
    * Modified cmdlet Set-LSIpAddressType: added parameter AcceptBundleUpdate.
  * Amazon Performance Insights
    * Modified cmdlet Get-PIAvailableResourceDimensionList: added parameter AuthorizedAction.
  * Amazon SES Mail Manager. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MMGR and can be listed using the command 'Get-AWSCmdletName -Service MMGR'.

### 4.1.583 (2024-05-20 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.814.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABAgent: added parameters GuardrailConfiguration_GuardrailIdentifier and GuardrailConfiguration_GuardrailVersion.
    * Modified cmdlet Update-AABAgent: added parameters GuardrailConfiguration_GuardrailIdentifier and GuardrailConfiguration_GuardrailVersion.
  * Amazon Control Tower
    * Added cmdlet Get-ACTControlOperationList leveraging the ListControlOperations service API.
    * Modified cmdlet Get-ACTEnabledControlList: added parameters Filter_ControlIdentifier, Filter_DriftStatus and Filter_Status.
  * Amazon OpenSearch Ingestion
    * Modified cmdlet Get-OSISPipelineBlueprint: added parameter Format.
    * Modified cmdlet New-OSISPipeline: added parameters VpcAttachmentOptions_AttachToVpc and VpcAttachmentOptions_CidrBlock.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBCluster: added parameter EngineLifecycleSupport.
    * Modified cmdlet New-RDSDBInstance: added parameter EngineLifecycleSupport.
    * Modified cmdlet New-RDSGlobalCluster: added parameter EngineLifecycleSupport.
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameter EngineLifecycleSupport.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter EngineLifecycleSupport.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter EngineLifecycleSupport.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter EngineLifecycleSupport.
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter EngineLifecycleSupport.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter EngineLifecycleSupport.

### 4.1.582 (2024-05-17 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.813.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon Alexa For Business
  * [Breaking Change] Removed support for Amazon Honeycode
  * Amazon Lake Formation
    * Added cmdlet Get-LKFDataLakePrincipal leveraging the GetDataLakePrincipal service API.

### 4.1.581 (2024-05-16 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.812.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAA
    * Modified cmdlet New-MWAAEnvironment: added parameters MaxWebserver and MinWebserver.
    * Modified cmdlet Update-MWAAEnvironment: added parameters MaxWebserver and MinWebserver.
  * Amazon QuickSight
    * Added cmdlet Get-QSKeyRegistration leveraging the DescribeKeyRegistration service API.
    * Added cmdlet Update-QSKeyRegistration leveraging the UpdateKeyRegistration service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMWorkteam: added parameters IamPolicyConstraints_SourceIp and IamPolicyConstraints_VpcSourceIp.
    * Modified cmdlet Update-SMWorkteam: added parameters IamPolicyConstraints_SourceIp and IamPolicyConstraints_VpcSourceIp.

### 4.1.580 (2024-05-15 20:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.811.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieve: added parameters ListContains_Key, ListContains_Value, StringContains_Key and StringContains_Value.
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters ListContains_Key, ListContains_Value, StringContains_Key and StringContains_Value.
  * Amazon CodeBuild
    * Modified cmdlet New-CBFleet: added parameters FleetServiceRole, VpcConfig_SecurityGroupId, VpcConfig_Subnet and VpcConfig_VpcId.
    * Modified cmdlet Update-CBFleet: added parameters FleetServiceRole, VpcConfig_SecurityGroupId, VpcConfig_Subnet and VpcConfig_VpcId.
  * Amazon Managed Grafana
    * Added cmdlet Get-MGRFWorkspaceServiceAccountList leveraging the ListWorkspaceServiceAccounts service API.
    * Added cmdlet Get-MGRFWorkspaceServiceAccountTokenList leveraging the ListWorkspaceServiceAccountTokens service API.
    * Added cmdlet New-MGRFWorkspaceServiceAccount leveraging the CreateWorkspaceServiceAccount service API.
    * Added cmdlet New-MGRFWorkspaceServiceAccountToken leveraging the CreateWorkspaceServiceAccountToken service API.
    * Added cmdlet Remove-MGRFWorkspaceServiceAccount leveraging the DeleteWorkspaceServiceAccount service API.
    * Added cmdlet Remove-MGRFWorkspaceServiceAccountToken leveraging the DeleteWorkspaceServiceAccountToken service API.
  * Amazon Medical Imaging Service
    * Modified cmdlet Start-MISDICOMImportJob: added parameter InputOwnerAccountId.

### 4.1.579 (2024-05-14 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.810.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Search-CONNContactFlow leveraging the SearchContactFlows service API.
    * Added cmdlet Search-CONNContactFlowModule leveraging the SearchContactFlowModules service API.
    * Modified cmdlet New-CONNContactFlow: added parameter Status.

### 4.1.578 (2024-05-13 20:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.809.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EventBridge
    * Added cmdlet Update-EVBEventBus leveraging the UpdateEventBus service API.
    * Modified cmdlet New-EVBEventBus: added parameters DeadLetterConfig_Arn, Description and KmsKeyIdentifier.

### 4.1.577 (2024-05-10 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.808.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GreengrassV2
    * Modified cmdlet Get-GGV2ComponentVersionArtifact: added parameters IotEndpointType and S3EndpointType.
  * Amazon Single Sign-On OIDC
    * Modified cmdlet New-SSOOIDCToken: added parameter CodeVerifier.
    * Modified cmdlet New-SSOOIDCTokenWithIAM: added parameter CodeVerifier.
    * Modified cmdlet Register-SSOOIDCClient: added parameters EntitledApplicationArn, GrantType, IssuerUrl and RedirectUris.

### 4.1.576 (2024-05-10 02:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.807.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters GenerationConfiguration_AdditionalModelRequestField, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_AdditionalModelRequestFields, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_GuardrailConfiguration_GuardrailId, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_GuardrailConfiguration_GuardrailVersion, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_InferenceConfig_TextInferenceConfig_MaxTokens, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_InferenceConfig_TextInferenceConfig_StopSequences, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_InferenceConfig_TextInferenceConfig_Temperature, RetrieveAndGenerateConfiguration_ExternalSourcesConfiguration_GenerationConfiguration_InferenceConfig_TextInferenceConfig_TopP, RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_GuardrailConfiguration_GuardrailId, RetrieveAndGenerateConfiguration_KnowledgeBaseConfiguration_GenerationConfiguration_GuardrailConfiguration_GuardrailVersion, TextInferenceConfig_MaxToken, TextInferenceConfig_StopSequence, TextInferenceConfig_Temperature and TextInferenceConfig_TopP.
  * Amazon Pinpoint
    * Modified cmdlet New-PINCampaign: added parameter EmailMessage_Header.
    * Modified cmdlet New-PINEmailTemplate: added parameter EmailTemplateRequest_Header.
    * Modified cmdlet Send-PINMessage: added parameter SimpleEmail_Header.
    * Modified cmdlet Send-PINUserMessageBatch: added parameter SimpleEmail_Header.
    * Modified cmdlet Update-PINCampaign: added parameter EmailMessage_Header.
    * Modified cmdlet Update-PINEmailTemplate: added parameter EmailTemplateRequest_Header.
  * Amazon Systems Manager for SAP
    * Added cmdlet Get-SMSAPOperationEventList leveraging the ListOperationEvents service API.
    * Added cmdlet Start-SMSAPApplication leveraging the StartApplication service API.
    * Added cmdlet Stop-SMSAPApplication leveraging the StopApplication service API.

### 4.1.575 (2024-05-08 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.806.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Simple Queue Service (SQS)
    * Modified cmdlet Receive-SQSMessage: added parameter MessageSystemAttributeName.

### 4.1.574 (2024-05-07 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.805.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Budgets
    * Added cmdlet Add-BGTResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-BGTResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-BGTResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-BGTBudget: added parameter ResourceTag.
    * Modified cmdlet New-BGTBudgetAction: added parameter ResourceTag.
  * Amazon Resilience Hub
    * Added cmdlet Get-RESHAppAssessmentResourceDriftList leveraging the ListAppAssessmentResourceDrifts service API.

### 4.1.573 (2024-05-06 20:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.804.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.572 (2024-05-03 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.803.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASRelatedItem: added parameter File_FileArn.
  * Amazon Connect Service
    * Added cmdlet Complete-CONNAttachedFileUpload leveraging the CompleteAttachedFileUpload service API.
    * Added cmdlet Get-CONNAttachedFile leveraging the GetAttachedFile service API.
    * Added cmdlet Get-CONNBatchAttachedFileMetadata leveraging the BatchGetAttachedFileMetadata service API.
    * Added cmdlet Remove-CONNAttachedFile leveraging the DeleteAttachedFile service API.
    * Added cmdlet Start-CONNAttachedFileUpload leveraging the StartAttachedFileUpload service API.
  * Amazon Inspector2
    * Modified cmdlet Get-INS2CisScanReport: added parameter ReportFormat.

### 4.1.571 (2024-05-02 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.802.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DynamoDB
    * Modified cmdlet Import-DDBTable: added parameters OnDemandThroughput_MaxReadRequestUnit and OnDemandThroughput_MaxWriteRequestUnit.
    * Modified cmdlet Restore-DDBTableFromBackup: added parameters OnDemandThroughputOverride_MaxReadRequestUnit and OnDemandThroughputOverride_MaxWriteRequestUnit.
    * Modified cmdlet Restore-DDBTableToPointInTime: added parameters OnDemandThroughputOverride_MaxReadRequestUnit and OnDemandThroughputOverride_MaxWriteRequestUnit.
    * Modified cmdlet Update-DDBTable: added parameters OnDemandThroughput_MaxReadRequestUnit and OnDemandThroughput_MaxWriteRequestUnit.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2InstanceTpmEkPub leveraging the GetInstanceTpmEkPub service API.
  * Amazon Personalize
    * Added cmdlet Get-PERSDataDeletionJob leveraging the DescribeDataDeletionJob service API.
    * Added cmdlet Get-PERSDataDeletionJobList leveraging the ListDataDeletionJobs service API.
    * Added cmdlet New-PERSDataDeletionJob leveraging the CreateDataDeletionJob service API.
  * Amazon Redshift Serverless
    * [Breaking Change] Modified cmdlet Get-RSSScheduledActionList: output changed from System.String to Amazon.RedshiftServerless.Model.ScheduledActionAssociation.

### 4.1.570 (2024-05-01 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.801.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameters MongoDbAtlasConfiguration_CollectionName, MongoDbAtlasConfiguration_CredentialsSecretArn, MongoDbAtlasConfiguration_DatabaseName, MongoDbAtlasConfiguration_Endpoint, MongoDbAtlasConfiguration_EndpointServiceName, MongoDbAtlasConfiguration_VectorIndexName, StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField, StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField and StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters MongoDbAtlasConfiguration_CollectionName, MongoDbAtlasConfiguration_CredentialsSecretArn, MongoDbAtlasConfiguration_DatabaseName, MongoDbAtlasConfiguration_Endpoint, MongoDbAtlasConfiguration_EndpointServiceName, MongoDbAtlasConfiguration_VectorIndexName, StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_MetadataField, StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_TextField and StorageConfiguration_MongoDbAtlasConfiguration_FieldMapping_VectorField.

### 4.1.569 (2024-04-30 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.800.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Omics
    * Modified cmdlet Get-OMICSShareList: added parameter Filter_Type.
    * Modified cmdlet Get-OMICSWorkflow: added parameter WorkflowOwnerId.
    * Modified cmdlet Start-OMICSRun: added parameters StorageType and WorkflowOwnerId.
  * Amazon Pinpoint SMS Voice V2
    * Added cmdlet Get-SMSVProtectConfiguration leveraging the DescribeProtectConfigurations service API.
    * Added cmdlet Get-SMSVProtectConfigurationCountryRuleSet leveraging the GetProtectConfigurationCountryRuleSet service API.
    * Added cmdlet New-SMSVProtectConfiguration leveraging the CreateProtectConfiguration service API.
    * Added cmdlet Register-SMSVProtectConfiguration leveraging the AssociateProtectConfiguration service API.
    * Added cmdlet Remove-SMSVAccountDefaultProtectConfiguration leveraging the DeleteAccountDefaultProtectConfiguration service API.
    * Added cmdlet Remove-SMSVMediaMessageSpendLimitOverride leveraging the DeleteMediaMessageSpendLimitOverride service API.
    * Added cmdlet Remove-SMSVProtectConfiguration leveraging the DeleteProtectConfiguration service API.
    * Added cmdlet Send-SMSVMediaMessage leveraging the SendMediaMessage service API.
    * Added cmdlet Set-SMSVAccountDefaultProtectConfiguration leveraging the SetAccountDefaultProtectConfiguration service API.
    * Added cmdlet Set-SMSVMediaMessageSpendLimitOverride leveraging the SetMediaMessageSpendLimitOverride service API.
    * Added cmdlet Unregister-SMSVProtectConfiguration leveraging the DisassociateProtectConfiguration service API.
    * Added cmdlet Update-SMSVProtectConfiguration leveraging the UpdateProtectConfiguration service API.
    * Added cmdlet Update-SMSVProtectConfigurationCountryRuleSet leveraging the UpdateProtectConfigurationCountryRuleSet service API.
    * Modified cmdlet Send-SMSVTextMessage: added parameter ProtectConfigurationId.
    * Modified cmdlet Send-SMSVVoiceMessage: added parameter ProtectConfigurationId.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSIndex: added parameter Type.
    * Modified cmdlet New-QBUSPlugin: added parameters ApiSchema_Payload, AuthConfiguration_NoAuthConfiguration, CustomPluginConfiguration_ApiSchemaType, CustomPluginConfiguration_Description, S3_Bucket and S3_Key.
    * Modified cmdlet Set-QBUSChatSync: added parameter AuthChallengeResponse_ResponseMap.
    * Modified cmdlet Update-QBUSApplication: added parameter IdentityCenterInstanceArn.
    * Modified cmdlet Update-QBUSPlugin: added parameters ApiSchema_Payload, AuthConfiguration_NoAuthConfiguration, CustomPluginConfiguration_ApiSchemaType, CustomPluginConfiguration_Description, S3_Bucket and S3_Key.
    * Modified cmdlet Update-QBUSWebExperience: added parameter RoleArn.
  * Amazon QuickSight
    * Added cmdlet Update-QSSPICECapacityConfiguration leveraging the UpdateSPICECapacityConfiguration service API.
    * Modified cmdlet New-QSAccountSubscription: added parameters AdminProGroup, AuthorProGroup and ReaderProGroup.
    * Modified cmdlet New-QSEmbedUrlForAnonymousUser: added parameter GenerativeQnA_InitialTopicId.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameter GenerativeQnA_InitialTopicId.
  * Amazon Route 53 Resolver
    * Modified cmdlet Edit-R53RFirewallRule: added parameter FirewallDomainRedirectionAction.
    * Modified cmdlet New-R53RFirewallRule: added parameter FirewallDomainRedirectionAction.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMTrainingJob: added parameter SessionChainingConfig_EnableSessionTagChaining.

### 4.1.568 (2024-04-29 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.799.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Added cmdlet Remove-CCASField leveraging the DeleteField service API.
    * Added cmdlet Remove-CCASLayout leveraging the DeleteLayout service API.
    * Added cmdlet Remove-CCASTemplate leveraging the DeleteTemplate service API.
  * Amazon Inspector2
    * Modified cmdlet Get-INS2CoverageList: added parameter FilterCriteria_ScanMode.
    * Modified cmdlet Get-INS2CoverageStatisticList: added parameter FilterCriteria_ScanMode.
    * Modified cmdlet Update-INS2Configuration: added parameter Ec2Configuration_ScanMode.
  * Amazon Timestream Query
    * Added cmdlet Get-TSQAccountSetting leveraging the DescribeAccountSettings service API.
    * Added cmdlet Update-TSQAccountSetting leveraging the UpdateAccountSettings service API.
  * Amazon Trusted Advisor
    * Added cmdlet Update-TAUpdateRecommendationResourceExclusionBatch leveraging the BatchUpdateRecommendationResourceExclusion service API.
    * Modified cmdlet Get-TAOrganizationRecommendationResourceList: added parameter ExclusionStatus.
    * Modified cmdlet Get-TARecommendationResourceList: added parameter ExclusionStatus.

### 4.1.567 (2024-04-26 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.798.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Observability Access Manager
    * Modified cmdlet New-CWOAMLink: added parameters LogGroupConfiguration_Filter and MetricConfiguration_Filter.
    * Modified cmdlet Update-CWOAMLink: added parameters LogGroupConfiguration_Filter and MetricConfiguration_Filter.
  * Amazon CodePipeline
    * Added cmdlet Undo-CPStageExecution leveraging the RollbackStage service API.
    * Modified cmdlet Get-CPPipelineExecutionSummary: added parameter SucceededInStage_StageName.
  * Amazon Connect Campaign Service
    * Modified cmdlet New-CCSCampaign: added parameter AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt.
    * Modified cmdlet Update-CCSCampaignOutboundCallConfig: added parameter AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt.

### 4.1.566 (2024-04-25 20:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.797.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Step Functions
    * Added cmdlet Test-SFNStateMachineDefinitionValidation leveraging the ValidateStateMachineDefinition service API.

### 4.1.565 (2024-04-24 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.796.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataSync
    * Modified cmdlet New-DSYNTask: added parameter Schedule_Status.
    * Modified cmdlet Update-DSYNTask: added parameter Schedule_Status.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2NetworkInterfaceAttribute: added parameter AssociatePublicIpAddress.
  * Amazon EMR Containers
    * Added cmdlet Get-EMRCSecurityConfiguration leveraging the DescribeSecurityConfiguration service API.
    * Added cmdlet Get-EMRCSecurityConfigurationList leveraging the ListSecurityConfigurations service API.
    * Added cmdlet New-EMRCSecurityConfiguration leveraging the CreateSecurityConfiguration service API.
    * Modified cmdlet New-EMRCVirtualCluster: added parameter SecurityConfigurationId.
  * Amazon EntityResolution
    * Added cmdlet Remove-ERESDeleteUniqueId leveraging the BatchDeleteUniqueId service API.
    * Modified cmdlet Add-ERESPolicyStatement: added parameter PassThru.
    * Modified cmdlet New-ERESIdNamespace: added parameter PassThru.
    * Modified cmdlet Remove-ERESPolicyStatement: added parameter PassThru.
    * Modified cmdlet Write-ERESPolicy: added parameter PassThru.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLContainerGroupDefinition leveraging the DescribeContainerGroupDefinition service API.
    * Added cmdlet Get-GMLContainerGroupDefinitionList leveraging the ListContainerGroupDefinitions service API.
    * Added cmdlet New-GMLContainerGroupDefinition leveraging the CreateContainerGroupDefinition service API.
    * Added cmdlet Remove-GMLContainerGroupDefinition leveraging the DeleteContainerGroupDefinition service API.
    * Modified cmdlet Get-GMLFleet: added parameter ContainerGroupDefinitionName.
    * Modified cmdlet New-GMLFleet: added parameters ConnectionPortRange_FromPort, ConnectionPortRange_ToPort, ContainerGroupsConfiguration_ContainerGroupDefinitionName and ContainerGroupsConfiguration_DesiredReplicaContainerGroupsPerInstance.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMInstanceProperty leveraging the DescribeInstanceProperties service API.

### 4.1.564 (2024-04-23 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.795.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABDataSource: added parameters DataDeletionPolicy and S3Configuration_BucketOwnerAccountId.
    * Modified cmdlet Update-AABDataSource: added parameters DataDeletionPolicy and S3Configuration_BucketOwnerAccountId.
  * Amazon Bedrock
    * Added cmdlet Get-BDREvaluationJob leveraging the GetEvaluationJob service API.
    * Added cmdlet Get-BDREvaluationJobList leveraging the ListEvaluationJobs service API.
    * Added cmdlet Get-BDRGuardrail leveraging the GetGuardrail service API.
    * Added cmdlet Get-BDRGuardrailList leveraging the ListGuardrails service API.
    * Added cmdlet New-BDREvaluationJob leveraging the CreateEvaluationJob service API.
    * Added cmdlet New-BDRGuardrail leveraging the CreateGuardrail service API.
    * Added cmdlet New-BDRGuardrailVersion leveraging the CreateGuardrailVersion service API.
    * Added cmdlet Remove-BDRGuardrail leveraging the DeleteGuardrail service API.
    * Added cmdlet Stop-BDREvaluationJob leveraging the StopEvaluationJob service API.
    * Added cmdlet Update-BDRGuardrail leveraging the UpdateGuardrail service API.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters ExternalSource_PromptTemplate_TextPromptTemplate, ExternalSourcesConfiguration_ModelArn and ExternalSourcesConfiguration_Source.
  * Amazon Bedrock Runtime
    * Modified cmdlet Invoke-BDRRModel: added parameters GuardrailIdentifier, GuardrailVersion and Trace.
    * Modified cmdlet Invoke-BDRRModelWithResponseStream: added parameters GuardrailIdentifier, GuardrailVersion and Trace.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2ImageDeregistrationProtection leveraging the DisableImageDeregistrationProtection service API.
    * Added cmdlet Enable-EC2ImageDeregistrationProtection leveraging the EnableImageDeregistrationProtection service API.
  * Amazon WorkSpaces Web
    * Modified cmdlet New-WSWPortal: added parameters InstanceType and MaxConcurrentSession.
    * Modified cmdlet Update-WSWPortal: added parameters InstanceType and MaxConcurrentSession.

### 4.1.563 (2024-04-22 20:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.794.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABAgentActionGroup: added parameters ActionGroupExecutor_CustomControl and FunctionSchema_Function.
    * Modified cmdlet Update-AABAgentActionGroup: added parameters ActionGroupExecutor_CustomControl and FunctionSchema_Function.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARAgent: added parameters SessionState_InvocationId and SessionState_ReturnControlInvocationResult.
  * Amazon Payment Cryptography Control Plane
    * Modified cmdlet Export-PAYCCKey: added parameters KeyBlockHeaders_KeyExportability, KeyBlockHeaders_KeyVersion, KeyBlockHeaders_OptionalBlock, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion, KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks, KeyModesOfUse_Decrypt, KeyModesOfUse_DeriveKey, KeyModesOfUse_Encrypt, KeyModesOfUse_Generate, KeyModesOfUse_NoRestriction, KeyModesOfUse_Sign, KeyModesOfUse_Unwrap, KeyModesOfUse_Verify and KeyModesOfUse_Wrap.
  * Amazon Route 53 Profiles. Added cmdlets to support the service. Cmdlets for the service have the noun prefix R53P and can be listed using the command 'Get-AWSCmdletName -Service R53P'.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameters CustomPosixUserConfig_Gid, CustomPosixUserConfig_Uid, DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb, DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb, DefaultResourceSpec_SageMakerImageVersionAlias, DefaultSpaceSettings_CustomFileSystemConfig, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn, JupyterLabAppSettings_CodeRepository, JupyterLabAppSettings_CustomImage and JupyterLabAppSettings_LifecycleConfigArn.
    * Modified cmdlet Update-SMDomain: added parameters CustomPosixUserConfig_Gid, CustomPosixUserConfig_Uid, DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb, DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb, DefaultResourceSpec_SageMakerImageVersionAlias, DefaultSpaceSettings_CustomFileSystemConfig, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn, DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn, JupyterLabAppSettings_CodeRepository, JupyterLabAppSettings_CustomImage and JupyterLabAppSettings_LifecycleConfigArn.
  * Amazon Transfer for SFTP
    * Added cmdlet Start-TFRDirectoryListing leveraging the StartDirectoryListing service API.

### 4.1.562 (2024-04-19 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.793.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Internet Monitor
    * Added cmdlet Get-CWIMInternetEvent leveraging the GetInternetEvent service API.
    * Added cmdlet Get-CWIMInternetEventList leveraging the ListInternetEvents service API.
  * Amazon Personalize
    * Modified cmdlet New-PERSCampaign: added parameter CampaignConfig_SyncWithLatestSolutionVersion.
    * Modified cmdlet New-PERSSolution: added parameters AutoTrainingConfig_SchedulingExpression and PerformAutoTraining.
    * Modified cmdlet Update-PERSCampaign: added parameter CampaignConfig_SyncWithLatestSolutionVersion.

### 4.1.561 (2024-04-18 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.792.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameter PrometheusMonitoringConfiguration_RemoteWriteUrl.
    * Modified cmdlet Start-EMRServerlessJobRun: added parameter PrometheusMonitoringConfiguration_RemoteWriteUrl.
    * Modified cmdlet Update-EMRServerlessApplication: added parameter PrometheusMonitoringConfiguration_RemoteWriteUrl.
  * Amazon IAM Roles Anywhere
    * Added cmdlet Remove-IAMRAAttributeMapping leveraging the DeleteAttributeMapping service API.
    * Added cmdlet Write-IAMRAAttributeMapping leveraging the PutAttributeMapping service API.
  * Amazon WorkSpaces
    * Added cmdlet Approve-WKSAccountLinkInvitation leveraging the AcceptAccountLinkInvitation service API.
    * Added cmdlet Deny-WKSAccountLinkInvitation leveraging the RejectAccountLinkInvitation service API.
    * Added cmdlet Get-WKSAccountLink leveraging the GetAccountLink service API.
    * Added cmdlet Get-WKSAccountLinkList leveraging the ListAccountLinks service API.
    * Added cmdlet New-WKSAccountLinkInvitation leveraging the CreateAccountLinkInvitation service API.
    * Added cmdlet Remove-WKSAccountLinkInvitation leveraging the DeleteAccountLinkInvitation service API.

### 4.1.560 (2024-04-17 22:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.791.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QBusiness
    * Modified cmdlet New-QBUSApplication: added parameter IdentityCenterInstanceArn.
    * Modified cmdlet New-QBUSWebExperience: added parameter RoleArn.
    * Modified cmdlet Set-QBUSChatSync: added parameters ChatMode and PluginConfiguration_PluginId.
    * Modified cmdlet Update-QBUSChatControlsConfiguration: added parameter CreatorModeConfiguration_CreatorModeControl.

### 4.1.559 (2024-04-16 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.790.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2OriginEndpoint: added parameter DashManifest.
    * Modified cmdlet Update-MPV2OriginEndpoint: added parameter DashManifest.
  * Amazon EntityResolution
    * Added cmdlet Add-ERESPolicyStatement leveraging the AddPolicyStatement service API.
    * Added cmdlet Get-ERESIdNamespace leveraging the GetIdNamespace service API.
    * Added cmdlet Get-ERESIdNamespaceList leveraging the ListIdNamespaces service API.
    * Added cmdlet Get-ERESPolicy leveraging the GetPolicy service API.
    * Added cmdlet New-ERESIdNamespace leveraging the CreateIdNamespace service API.
    * Added cmdlet Remove-ERESIdNamespace leveraging the DeleteIdNamespace service API.
    * Added cmdlet Remove-ERESPolicyStatement leveraging the DeletePolicyStatement service API.
    * Added cmdlet Update-ERESIdNamespace leveraging the UpdateIdNamespace service API.
    * Added cmdlet Write-ERESPolicy leveraging the PutPolicy service API.
    * Modified cmdlet Get-ERESMatchId: added parameter ApplyNormalization.
    * Modified cmdlet Start-ERESIdMappingJob: added parameter OutputSourceConfig.
  * Amazon Lake Formation
    * Modified cmdlet New-LKFLakeFormationIdentityCenterConfiguration: added parameter ShareRecipient.
    * Modified cmdlet Update-LKFLakeFormationIdentityCenterConfiguration: added parameter ShareRecipient.
  * Amazon M2
    * Added cmdlet Get-AMMBatchJobRestartPointList leveraging the ListBatchJobRestartPoints service API.
    * Modified cmdlet Start-AMMBatchJob: added parameters JobStepRestartMarker_FromProcStep, JobStepRestartMarker_FromStep, JobStepRestartMarker_ToProcStep, JobStepRestartMarker_ToStep and RestartBatchJobIdentifier_ExecutionId.
  * Amazon Outposts
    * Added cmdlet Get-OUTPCapacityTask leveraging the GetCapacityTask service API.
    * Added cmdlet Get-OUTPCapacityTaskList leveraging the ListCapacityTasks service API.
    * Added cmdlet Get-OUTPOutpostSupportedInstanceType leveraging the GetOutpostSupportedInstanceTypes service API.
    * Added cmdlet Start-OUTPCapacityTask leveraging the StartCapacityTask service API.
    * Added cmdlet Stop-OUTPCapacityTask leveraging the CancelCapacityTask service API.
  * Amazon Well-Architected Tool
    * Added cmdlet Get-WATGlobalSetting leveraging the GetGlobalSettings service API.
    * Added cmdlet Update-WATIntegration leveraging the UpdateIntegration service API.
    * Modified cmdlet New-WATWorkload: added parameters JiraConfiguration_IssueManagementStatus, JiraConfiguration_IssueManagementType and JiraConfiguration_JiraProjectKey.
    * Modified cmdlet Update-WATGlobalSetting: added parameters JiraConfiguration_IntegrationStatus, JiraConfiguration_IssueManagementStatus, JiraConfiguration_IssueManagementType and JiraConfiguration_JiraProjectKey.
    * Modified cmdlet Update-WATLensReview: added parameter JiraConfiguration_SelectedPillar.
    * Modified cmdlet Update-WATWorkload: added parameters JiraConfiguration_IssueManagementStatus, JiraConfiguration_IssueManagementType and JiraConfiguration_JiraProjectKey.

### 4.1.558 (2024-04-12 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.789.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNChangeSet: added parameter IncludePropertyValue.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter InsertionMode.
  * Amazon Glue
    * Modified cmdlet Get-GLUEUnfilteredTableMetadata: added parameters ParentResourceArn and RootResourceArn.
  * Amazon Key Management Service
    * Added cmdlet Get-KMSKeyRotation leveraging the ListKeyRotations service API.
    * Added cmdlet Start-KMSRotateKeyOnDemand leveraging the RotateKeyOnDemand service API.
    * Modified cmdlet Enable-KMSKeyRotation: added parameter RotationPeriodInDay.

### 4.1.557 (2024-04-11 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.788.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch
    * Modified cmdlet Write-CWAnomalyDetector: added parameter MetricCharacteristics_PeriodicSpike.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLCloudWatchAlarmTemplate leveraging the GetCloudWatchAlarmTemplate service API.
    * Added cmdlet Get-EMLCloudWatchAlarmTemplateGroup leveraging the GetCloudWatchAlarmTemplateGroup service API.
    * Added cmdlet Get-EMLCloudWatchAlarmTemplateGroupList leveraging the ListCloudWatchAlarmTemplateGroups service API.
    * Added cmdlet Get-EMLCloudWatchAlarmTemplateList leveraging the ListCloudWatchAlarmTemplates service API.
    * Added cmdlet Get-EMLEventBridgeRuleTemplate leveraging the GetEventBridgeRuleTemplate service API.
    * Added cmdlet Get-EMLEventBridgeRuleTemplateGroup leveraging the GetEventBridgeRuleTemplateGroup service API.
    * Added cmdlet Get-EMLEventBridgeRuleTemplateGroupList leveraging the ListEventBridgeRuleTemplateGroups service API.
    * Added cmdlet Get-EMLEventBridgeRuleTemplateList leveraging the ListEventBridgeRuleTemplates service API.
    * Added cmdlet Get-EMLSignalMap leveraging the GetSignalMap service API.
    * Added cmdlet Get-EMLSignalMapList leveraging the ListSignalMaps service API.
    * Added cmdlet New-EMLCloudWatchAlarmTemplate leveraging the CreateCloudWatchAlarmTemplate service API.
    * Added cmdlet New-EMLCloudWatchAlarmTemplateGroup leveraging the CreateCloudWatchAlarmTemplateGroup service API.
    * Added cmdlet New-EMLEventBridgeRuleTemplate leveraging the CreateEventBridgeRuleTemplate service API.
    * Added cmdlet New-EMLEventBridgeRuleTemplateGroup leveraging the CreateEventBridgeRuleTemplateGroup service API.
    * Added cmdlet New-EMLSignalMap leveraging the CreateSignalMap service API.
    * Added cmdlet Remove-EMLCloudWatchAlarmTemplate leveraging the DeleteCloudWatchAlarmTemplate service API.
    * Added cmdlet Remove-EMLCloudWatchAlarmTemplateGroup leveraging the DeleteCloudWatchAlarmTemplateGroup service API.
    * Added cmdlet Remove-EMLEventBridgeRuleTemplate leveraging the DeleteEventBridgeRuleTemplate service API.
    * Added cmdlet Remove-EMLEventBridgeRuleTemplateGroup leveraging the DeleteEventBridgeRuleTemplateGroup service API.
    * Added cmdlet Remove-EMLSignalMap leveraging the DeleteSignalMap service API.
    * Added cmdlet Start-EMLDeleteMonitorDeployment leveraging the StartDeleteMonitorDeployment service API.
    * Added cmdlet Start-EMLMonitorDeployment leveraging the StartMonitorDeployment service API.
    * Added cmdlet Start-EMLUpdateSignalMap leveraging the StartUpdateSignalMap service API.
    * Added cmdlet Update-EMLCloudWatchAlarmTemplate leveraging the UpdateCloudWatchAlarmTemplate service API.
    * Added cmdlet Update-EMLCloudWatchAlarmTemplateGroup leveraging the UpdateCloudWatchAlarmTemplateGroup service API.
    * Added cmdlet Update-EMLEventBridgeRuleTemplate leveraging the UpdateEventBridgeRuleTemplate service API.
    * Added cmdlet Update-EMLEventBridgeRuleTemplateGroup leveraging the UpdateEventBridgeRuleTemplateGroup service API.
  * Amazon Omics
    * Modified cmdlet New-OMICSSequenceStore: added parameter ETagAlgorithmFamily.

### 4.1.556 (2024-04-10 20:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.787.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Q Connect
    * Added cmdlet Update-QCSession leveraging the UpdateSession service API.
    * Modified cmdlet New-QCSession: added parameters TagCondition_Key, TagCondition_Value, TagFilter_AndCondition and TagFilter_OrCondition.
  * Amazon Supply Chain
    * Added cmdlet Send-SUPCHDataIntegrationEvent leveraging the SendDataIntegrationEvent service API.

### 4.1.555 (2024-04-09 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.786.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Pinpoint
    * Modified cmdlet Update-PINEmailChannel: added parameter EmailChannelRequest_OrchestrationSendingRoleArn.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter CACertificateIdentifier.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter CACertificateIdentifier.
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter CACertificateIdentifier.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter CACertificateIdentifier.

### 4.1.554 (2024-04-08 21:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.785.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Catalog. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CLCAT and can be listed using the command 'Get-AWSCmdletName -Service CLCAT'.

### 4.1.553 (2024-04-05 20:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.784.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QuickSight
    * Modified cmdlet New-QSAccountSubscription: added parameter IAMIdentityCenterInstanceArn.
  * Amazon Verified Permissions
    * Added cmdlet Get-AVPBatchIsAuthorizedWithToken leveraging the BatchIsAuthorizedWithToken service API.

### 4.1.552 (2024-04-04 20:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.783.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Added cmdlet Get-CRSBatchGetSchemaAnalysisRule leveraging the BatchGetSchemaAnalysisRule service API.
  * Amazon EMR Containers
    * Modified cmdlet Get-EMRCVirtualClusterList: added parameter EksAccessEntryIntegrated.
  * Amazon Verified Permissions
    * Modified cmdlet New-AVPIdentitySource: added parameter GroupConfiguration_GroupEntityType.
    * Modified cmdlet Update-AVPIdentitySource: added parameter GroupConfiguration_GroupEntityType.

### 4.1.551 (2024-04-03 20:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.782.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Added cmdlet Get-DZTimeSeriesDataPoint leveraging the GetTimeSeriesDataPoint service API.
    * Added cmdlet Get-DZTimeSeriesDataPointList leveraging the ListTimeSeriesDataPoints service API.
    * Added cmdlet New-DZTimeSeriesDataPoint leveraging the PostTimeSeriesDataPoints service API.
    * Added cmdlet Remove-DZTimeSeriesDataPoint leveraging the DeleteTimeSeriesDataPoints service API.
    * Modified cmdlet New-DZDataSource: added parameter GlueRunConfiguration_AutoImportDataQualityResult.
    * Modified cmdlet Update-DZDataSource: added parameter GlueRunConfiguration_AutoImportDataQualityResult.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Added cmdlet Request-DOCSwitchoverGlobalCluster leveraging the SwitchoverGlobalCluster service API.
  * Amazon Medical Imaging Service
    * Modified cmdlet Search-MISImageSet: added parameters Sort_SortField and Sort_SortOrder.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameter SecurityPolicyName.
    * Modified cmdlet Update-TFRConnector: added parameter SecurityPolicyName.

### 4.1.550 (2024-04-02 20:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.781.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.549 (2024-04-01 21:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.780.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ADC and can be listed using the command 'Get-AWSCmdletName -Service ADC'.
  * Amazon CloudWatch
    * Modified cmdlet Remove-CWAnomalyDetector: added parameter SingleMetricAnomalyDetector_AccountId.
    * Modified cmdlet Write-CWAnomalyDetector: added parameter SingleMetricAnomalyDetector_AccountId.
  * Amazon DataZone
    * Added cmdlet Get-DZMetadataGenerationRun leveraging the GetMetadataGenerationRun service API.
    * Added cmdlet Get-DZMetadataGenerationRunList leveraging the ListMetadataGenerationRuns service API.
    * Added cmdlet Start-DZMetadataGenerationRun leveraging the StartMetadataGenerationRun service API.
    * Added cmdlet Stop-DZMetadataGenerationRun leveraging the CancelMetadataGenerationRun service API.
  * Amazon Lightsail
    * Modified cmdlet New-LSDistribution: added parameters CertificateName, Origin_ResponseTimeout and ViewerMinimumTlsProtocolVersion.
    * Modified cmdlet Update-LSDistribution: added parameters CertificateName, Origin_ResponseTimeout, UseDefaultCertificate and ViewerMinimumTlsProtocolVersion.

### 4.1.548 (2024-03-29 20:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.779.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Internet Monitor
    * Modified cmdlet Get-CWIMHealthEvent: added parameter LinkedAccountId.
    * Modified cmdlet Get-CWIMHealthEventList: added parameter LinkedAccountId.
    * Modified cmdlet Get-CWIMMonitor: added parameter LinkedAccountId.
    * Modified cmdlet Get-CWIMMonitorList: added parameter IncludeLinkedAccount.
    * Modified cmdlet Start-CWIMQuery: added parameter LinkedAccountId.
  * Amazon CodeConnections. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CCON and can be listed using the command 'Get-AWSCmdletName -Service CCON'.
  * Amazon IoT Wireless
    * Added cmdlet Get-IOTWMetric leveraging the GetMetrics service API.
    * Added cmdlet Get-IOTWMetricConfiguration leveraging the GetMetricConfiguration service API.
    * Added cmdlet Update-IOTWMetricConfiguration leveraging the UpdateMetricConfiguration service API.
  * Amazon Marketplace Catalog Service
    * Modified cmdlet Get-MCATEntityList: added parameter ResaleAuthorizationId_ValueList.
  * Amazon Neptune Graph
    * Added cmdlet Start-NEPTGImportTask leveraging the StartImportTask service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAppImageConfig: added parameters CodeEditorAppImageConfig_ContainerConfig_ContainerArguments, CodeEditorAppImageConfig_ContainerConfig_ContainerEntrypoint, CodeEditorAppImageConfig_ContainerConfig_ContainerEnvironmentVariables, CodeEditorAppImageConfig_FileSystemConfig_DefaultGid, CodeEditorAppImageConfig_FileSystemConfig_DefaultUid and CodeEditorAppImageConfig_FileSystemConfig_MountPath.
    * Modified cmdlet Update-SMAppImageConfig: added parameters CodeEditorAppImageConfig_ContainerConfig_ContainerArguments, CodeEditorAppImageConfig_ContainerConfig_ContainerEntrypoint, CodeEditorAppImageConfig_ContainerConfig_ContainerEnvironmentVariables, CodeEditorAppImageConfig_FileSystemConfig_DefaultGid, CodeEditorAppImageConfig_FileSystemConfig_DefaultUid and CodeEditorAppImageConfig_FileSystemConfig_MountPath.

### 4.1.547 (2024-03-28 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.778.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QuickSight
    * Modified cmdlet Update-QSIpRestriction: added parameters VpcEndpointIdRestrictionRuleMap and VpcIdRestrictionRuleMap.

### 4.1.546 (2024-03-27 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.777.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter PodProperties_ImagePullSecret.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieve: added parameters Equals_Key, Equals_Value, Filter_AndAll, Filter_OrAll, GreaterThan_Key, GreaterThan_Value, GreaterThanOrEquals_Key, GreaterThanOrEquals_Value, In_Key, In_Value, LessThan_Key, LessThan_Value, LessThanOrEquals_Key, LessThanOrEquals_Value, NotEquals_Key, NotEquals_Value, NotIn_Key, NotIn_Value, StartsWith_Key and StartsWith_Value.
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameters Equals_Key, Equals_Value, Filter_AndAll, Filter_OrAll, GreaterThan_Key, GreaterThan_Value, GreaterThanOrEquals_Key, GreaterThanOrEquals_Value, In_Key, In_Value, LessThan_Key, LessThan_Value, LessThanOrEquals_Key, LessThanOrEquals_Value, NotEquals_Key, NotEquals_Value, NotIn_Key, NotIn_Value, StartsWith_Key and StartsWith_Value.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECServerlessCache: added parameters DataStorage_Minimum and ECPUPerSecond_Minimum.
    * Modified cmdlet New-ECServerlessCache: added parameters DataStorage_Minimum and ECPUPerSecond_Minimum.

### 4.1.545 (2024-03-26 22:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.776.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARRetrieveAndGenerate: added parameter PromptTemplate_TextPromptTemplate.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostAllocationTagBackfillHistoryList leveraging the ListCostAllocationTagBackfillHistory service API.
    * Added cmdlet Start-CECostAllocationTagBackfill leveraging the StartCostAllocationTagBackfill service API.
  * EC2
    * [Breaking Change] Removed cmdlet Set-EC2InstanceMetadataDefault.
    * Added cmdlet Edit-EC2InstanceMetadataDefault leveraging the ModifyInstanceMetadataDefaults service API.
  * Amazon FinSpace User Environment Management Service
    * Added cmdlet Remove-FINSPKxClusterNode leveraging the DeleteKxClusterNode service API.

### 4.1.544 (2024-03-25 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.775.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2InstanceMetadataDefault leveraging the GetInstanceMetadataDefaults service API.
    * Added cmdlet Set-EC2InstanceMetadataDefault leveraging the ModifyInstanceMetadataDefaults service API.

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

