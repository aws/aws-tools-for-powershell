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

