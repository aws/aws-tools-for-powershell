### 4.1.6.0 (2020-12-22)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.79.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAA. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MWAA and can be listed using the command 'Get-AWSCmdletName -Service MWAA'.
  * Amazon Amplify Backend. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AMPB and can be listed using the command 'Get-AWSCmdletName -Service AMPB'.
  * Amazon AppIntegrations Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AIS and can be listed using the command 'Get-AWSCmdletName -Service AIS'.
  * Amazon Audit Manager. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AUDM and can be listed using the command 'Get-AWSCmdletName -Service AUDM'.
  * Amazon Backup
    * Added cmdlet Get-BAKGlobalSetting leveraging the DescribeGlobalSettings service API.
    * Added cmdlet Update-BAKGlobalSetting leveraging the UpdateGlobalSettings service API.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter ComputeResources_Ec2Configuration.
    * Modified cmdlet Register-BATJobDefinition: added parameters FargatePlatformConfiguration_PlatformVersion, NetworkConfiguration_AssignPublicIp, PlatformCapability and PropagateTag.
    * Modified cmdlet Submit-BATJob: added parameter PropagateTag.
    * Modified cmdlet Update-BATComputeEnvironment: added parameters ComputeResources_SecurityGroupId and ComputeResources_Subnet.
  * Amazon Chime
    * Added cmdlet Get-CHMAppInstance leveraging the DescribeAppInstance service API.
    * Added cmdlet Get-CHMAppInstanceAdmin leveraging the DescribeAppInstanceAdmin service API.
    * Added cmdlet Get-CHMAppInstanceAdminList leveraging the ListAppInstanceAdmins service API.
    * Added cmdlet Get-CHMAppInstanceList leveraging the ListAppInstances service API.
    * Added cmdlet Get-CHMAppInstanceRetentionSetting leveraging the GetAppInstanceRetentionSettings service API.
    * Added cmdlet Get-CHMAppInstanceStreamingConfiguration leveraging the GetAppInstanceStreamingConfigurations service API.
    * Added cmdlet Get-CHMAppInstanceUser leveraging the DescribeAppInstanceUser service API.
    * Added cmdlet Get-CHMAppInstanceUserList leveraging the ListAppInstanceUsers service API.
    * Added cmdlet Get-CHMChannel leveraging the DescribeChannel service API.
    * Added cmdlet Get-CHMChannelBan leveraging the DescribeChannelBan service API.
    * Added cmdlet Get-CHMChannelBanList leveraging the ListChannelBans service API.
    * Added cmdlet Get-CHMChannelList leveraging the ListChannels service API.
    * Added cmdlet Get-CHMChannelMembership leveraging the DescribeChannelMembership service API.
    * Added cmdlet Get-CHMChannelMembershipForAppInstanceUser leveraging the DescribeChannelMembershipForAppInstanceUser service API.
    * Added cmdlet Get-CHMChannelMembershipList leveraging the ListChannelMemberships service API.
    * Added cmdlet Get-CHMChannelMembershipsForAppInstanceUserList leveraging the ListChannelMembershipsForAppInstanceUser service API.
    * Added cmdlet Get-CHMChannelMessage leveraging the GetChannelMessage service API.
    * Added cmdlet Get-CHMChannelMessageList leveraging the ListChannelMessages service API.
    * Added cmdlet Get-CHMChannelModeratedByAppInstanceUser leveraging the DescribeChannelModeratedByAppInstanceUser service API.
    * Added cmdlet Get-CHMChannelModerator leveraging the DescribeChannelModerator service API.
    * Added cmdlet Get-CHMChannelModeratorList leveraging the ListChannelModerators service API.
    * Added cmdlet Get-CHMChannelsModeratedByAppInstanceUserList leveraging the ListChannelsModeratedByAppInstanceUser service API.
    * Added cmdlet Get-CHMMessagingSessionEndpoint leveraging the GetMessagingSessionEndpoint service API.
    * Added cmdlet Get-CHMSipMediaApplication leveraging the GetSipMediaApplication service API.
    * Added cmdlet Get-CHMSipMediaApplicationList leveraging the ListSipMediaApplications service API.
    * Added cmdlet Get-CHMSipMediaApplicationLoggingConfiguration leveraging the GetSipMediaApplicationLoggingConfiguration service API.
    * Added cmdlet Get-CHMSipRule leveraging the GetSipRule service API.
    * Added cmdlet Get-CHMSipRuleList leveraging the ListSipRules service API.
    * Added cmdlet Hide-CHMChannelMessage leveraging the RedactChannelMessage service API.
    * Added cmdlet New-CHMAppInstance leveraging the CreateAppInstance service API.
    * Added cmdlet New-CHMAppInstanceAdmin leveraging the CreateAppInstanceAdmin service API.
    * Added cmdlet New-CHMAppInstanceUser leveraging the CreateAppInstanceUser service API.
    * Added cmdlet New-CHMChannel leveraging the CreateChannel service API.
    * Added cmdlet New-CHMChannelBan leveraging the CreateChannelBan service API.
    * Added cmdlet New-CHMChannelMembership leveraging the CreateChannelMembership service API.
    * Added cmdlet New-CHMChannelModerator leveraging the CreateChannelModerator service API.
    * Added cmdlet New-CHMMeetingDialOut leveraging the CreateMeetingDialOut service API.
    * Added cmdlet New-CHMSipMediaApplication leveraging the CreateSipMediaApplication service API.
    * Added cmdlet New-CHMSipMediaApplicationCall leveraging the CreateSipMediaApplicationCall service API.
    * Added cmdlet New-CHMSipRule leveraging the CreateSipRule service API.
    * Added cmdlet Remove-CHMAppInstance leveraging the DeleteAppInstance service API.
    * Added cmdlet Remove-CHMAppInstanceAdmin leveraging the DeleteAppInstanceAdmin service API.
    * Added cmdlet Remove-CHMAppInstanceStreamingConfiguration leveraging the DeleteAppInstanceStreamingConfigurations service API.
    * Added cmdlet Remove-CHMAppInstanceUser leveraging the DeleteAppInstanceUser service API.
    * Added cmdlet Remove-CHMChannel leveraging the DeleteChannel service API.
    * Added cmdlet Remove-CHMChannelBan leveraging the DeleteChannelBan service API.
    * Added cmdlet Remove-CHMChannelMembership leveraging the DeleteChannelMembership service API.
    * Added cmdlet Remove-CHMChannelMessage leveraging the DeleteChannelMessage service API.
    * Added cmdlet Remove-CHMChannelModerator leveraging the DeleteChannelModerator service API.
    * Added cmdlet Remove-CHMSipMediaApplication leveraging the DeleteSipMediaApplication service API.
    * Added cmdlet Remove-CHMSipRule leveraging the DeleteSipRule service API.
    * Added cmdlet Send-CHMChannelMessage leveraging the SendChannelMessage service API.
    * Added cmdlet Update-CHMAppInstance leveraging the UpdateAppInstance service API.
    * Added cmdlet Update-CHMAppInstanceUser leveraging the UpdateAppInstanceUser service API.
    * Added cmdlet Update-CHMChannel leveraging the UpdateChannel service API.
    * Added cmdlet Update-CHMChannelMessage leveraging the UpdateChannelMessage service API.
    * Added cmdlet Update-CHMChannelReadMarker leveraging the UpdateChannelReadMarker service API.
    * Added cmdlet Update-CHMSipMediaApplication leveraging the UpdateSipMediaApplication service API.
    * Added cmdlet Update-CHMSipRule leveraging the UpdateSipRule service API.
    * Added cmdlet Write-CHMAppInstanceRetentionSetting leveraging the PutAppInstanceRetentionSettings service API.
    * Added cmdlet Write-CHMAppInstanceStreamingConfiguration leveraging the PutAppInstanceStreamingConfigurations service API.
    * Added cmdlet Write-CHMSipMediaApplicationLoggingConfiguration leveraging the PutSipMediaApplicationLoggingConfiguration service API.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNTypeList: added parameter Type.
    * Modified cmdlet New-CFNChangeSet: added parameter IncludeNestedStack.
  * Amazon CloudHSM V2
    * Added cmdlet Edit-HSM2BackupAttribute leveraging the ModifyBackupAttributes service API.
    * Added cmdlet Edit-HSM2Cluster leveraging the ModifyCluster service API.
    * Modified cmdlet New-HSM2Cluster: added parameters BackupRetentionPolicy_Type and BackupRetentionPolicy_Value.
  * Amazon CloudTrail
    * Modified cmdlet Write-CTEventSelector: added parameter AdvancedEventSelector.
  * Amazon CloudWatch Events
    * Modified cmdlet Remove-CWEPermission: added parameter RemoveAllPermission.
    * Modified cmdlet Write-CWEPermission: added parameter Policy.
  * Amazon CodeBuild
    * Added cmdlet Get-CBReportGroupTrend leveraging the GetReportGroupTrend service API.
  * Amazon CodeGuru Reviewer
    * Added cmdlet Add-CGRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CGRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CGRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Register-CGRRepository: added parameter Tag.
  * Amazon CodeStar Connections
    * Added cmdlet Update-CSTCHost leveraging the UpdateHost service API.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameters CustomEmailSender_LambdaArn, CustomEmailSender_LambdaVersion, CustomSMSSender_LambdaArn, CustomSMSSender_LambdaVersion and LambdaConfig_KMSKeyID.
    * Modified cmdlet Update-CGIPUserPool: added parameters CustomEmailSender_LambdaArn, CustomEmailSender_LambdaVersion, CustomSMSSender_LambdaArn, CustomSMSSender_LambdaVersion and LambdaConfig_KMSKeyID.
  * Amazon Comprehend
    * Added cmdlet Get-COMPEventsDetectionJob leveraging the DescribeEventsDetectionJob service API.
    * Added cmdlet Get-COMPEventsDetectionJobList leveraging the ListEventsDetectionJobs service API.
    * Added cmdlet Start-COMPEventsDetectionJob leveraging the StartEventsDetectionJob service API.
    * Added cmdlet Stop-COMPEventsDetectionJob leveraging the StopEventsDetectionJob service API.
  * Amazon Compute Optimizer
    * Added cmdlet Get-COEBSVolumeRecommendation leveraging the GetEBSVolumeRecommendations service API.
  * Amazon Config
    * Added cmdlet Get-CFGStoredQuery leveraging the GetStoredQuery service API.
    * Added cmdlet Get-CFGStoredQueryList leveraging the ListStoredQueries service API.
    * Added cmdlet Remove-CFGStoredQuery leveraging the DeleteStoredQuery service API.
    * Added cmdlet Write-CFGExternalEvaluation leveraging the PutExternalEvaluation service API.
    * Added cmdlet Write-CFGStoredQuery leveraging the PutStoredQuery service API.
  * Amazon Connect Contact Lens. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CCL and can be listed using the command 'Get-AWSCmdletName -Service CCL'.
  * Amazon Connect Customer Profiles. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CPF and can be listed using the command 'Get-AWSCmdletName -Service CPF'.
  * Amazon Connect Participant Service
    * Added cmdlet Complete-CONNPAttachmentUpload leveraging the CompleteAttachmentUpload service API.
    * Added cmdlet Get-CONNPAttachment leveraging the GetAttachment service API.
    * Added cmdlet Start-CONNPAttachmentUpload leveraging the StartAttachmentUpload service API.
  * Amazon Connect Service
    * Added cmdlet Add-CONNApprovedOrigin leveraging the AssociateApprovedOrigin service API.
    * Added cmdlet Add-CONNInstanceStorageConfig leveraging the AssociateInstanceStorageConfig service API.
    * Added cmdlet Add-CONNLambdaFunction leveraging the AssociateLambdaFunction service API.
    * Added cmdlet Add-CONNLexBot leveraging the AssociateLexBot service API.
    * Added cmdlet Add-CONNSecurityKey leveraging the AssociateSecurityKey service API.
    * Added cmdlet Get-CONNApprovedOriginList leveraging the ListApprovedOrigins service API.
    * Added cmdlet Get-CONNInstance leveraging the DescribeInstance service API.
    * Added cmdlet Get-CONNInstanceAttribute leveraging the DescribeInstanceAttribute service API.
    * Added cmdlet Get-CONNInstanceAttributeList leveraging the ListInstanceAttributes service API.
    * Added cmdlet Get-CONNInstanceList leveraging the ListInstances service API.
    * Added cmdlet Get-CONNInstanceStorageConfig leveraging the DescribeInstanceStorageConfig service API.
    * Added cmdlet Get-CONNInstanceStorageConfigList leveraging the ListInstanceStorageConfigs service API.
    * Added cmdlet Get-CONNIntegrationAssociationList leveraging the ListIntegrationAssociations service API.
    * Added cmdlet Get-CONNLambdaFunctionList leveraging the ListLambdaFunctions service API.
    * Added cmdlet Get-CONNLexBotList leveraging the ListLexBots service API.
    * Added cmdlet Get-CONNQuickConnect leveraging the DescribeQuickConnect service API.
    * Added cmdlet Get-CONNQuickConnectList leveraging the ListQuickConnects service API.
    * Added cmdlet Get-CONNSecurityKeyList leveraging the ListSecurityKeys service API.
    * Added cmdlet Get-CONNUseCaseList leveraging the ListUseCases service API.
    * Added cmdlet New-CONNInstance leveraging the CreateInstance service API.
    * Added cmdlet New-CONNIntegrationAssociation leveraging the CreateIntegrationAssociation service API.
    * Added cmdlet New-CONNQuickConnect leveraging the CreateQuickConnect service API.
    * Added cmdlet New-CONNUseCase leveraging the CreateUseCase service API.
    * Added cmdlet New-CONNUserHierarchyGroup leveraging the CreateUserHierarchyGroup service API.
    * Added cmdlet Remove-CONNApprovedOrigin leveraging the DisassociateApprovedOrigin service API.
    * Added cmdlet Remove-CONNInstance leveraging the DeleteInstance service API.
    * Added cmdlet Remove-CONNInstanceStorageConfig leveraging the DisassociateInstanceStorageConfig service API.
    * Added cmdlet Remove-CONNIntegrationAssociation leveraging the DeleteIntegrationAssociation service API.
    * Added cmdlet Remove-CONNLambdaFunction leveraging the DisassociateLambdaFunction service API.
    * Added cmdlet Remove-CONNLexBot leveraging the DisassociateLexBot service API.
    * Added cmdlet Remove-CONNQuickConnect leveraging the DeleteQuickConnect service API.
    * Added cmdlet Remove-CONNSecurityKey leveraging the DisassociateSecurityKey service API.
    * Added cmdlet Remove-CONNUseCase leveraging the DeleteUseCase service API.
    * Added cmdlet Remove-CONNUserHierarchyGroup leveraging the DeleteUserHierarchyGroup service API.
    * Added cmdlet Start-CONNTaskContact leveraging the StartTaskContact service API.
    * Added cmdlet Update-CONNInstanceAttribute leveraging the UpdateInstanceAttribute service API.
    * Added cmdlet Update-CONNInstanceStorageConfig leveraging the UpdateInstanceStorageConfig service API.
    * Added cmdlet Update-CONNQuickConnectConfig leveraging the UpdateQuickConnectConfig service API.
    * Added cmdlet Update-CONNQuickConnectName leveraging the UpdateQuickConnectName service API.
    * Added cmdlet Update-CONNUserHierarchyGroupName leveraging the UpdateUserHierarchyGroupName service API.
    * Added cmdlet Update-CONNUserHierarchyStructure leveraging the UpdateUserHierarchyStructure service API.
  * Amazon Data Lifecycle Manager
    * Modified cmdlet New-DLMLifecyclePolicy: added parameters EventSource_Type, Parameters_DescriptionRegex, Parameters_EventType, Parameters_SnapshotOwner and PolicyDetails_Action.
    * Modified cmdlet Update-DLMLifecyclePolicy: added parameters EventSource_Type, Parameters_DescriptionRegex, Parameters_EventType, Parameters_SnapshotOwner and PolicyDetails_Action.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters DocDbSettings_SecretsManagerAccessRoleArn, DocDbSettings_SecretsManagerSecretId, IBMDb2Settings_SecretsManagerAccessRoleArn, IBMDb2Settings_SecretsManagerSecretId, MicrosoftSQLServerSettings_SecretsManagerAccessRoleArn, MicrosoftSQLServerSettings_SecretsManagerSecretId, MongoDbSettings_SecretsManagerAccessRoleArn, MongoDbSettings_SecretsManagerSecretId, MySQLSettings_SecretsManagerAccessRoleArn, MySQLSettings_SecretsManagerSecretId, OracleSettings_SecretsManagerAccessRoleArn, OracleSettings_SecretsManagerSecretId, PostgreSQLSettings_SecretsManagerAccessRoleArn, PostgreSQLSettings_SecretsManagerSecretId, RedshiftSettings_SecretsManagerAccessRoleArn, RedshiftSettings_SecretsManagerSecretId, S3Settings_CdcPath, S3Settings_CsvNoSupValue, S3Settings_PreserveTransaction, S3Settings_UseCsvNoSupValue, SybaseSettings_SecretsManagerAccessRoleArn and SybaseSettings_SecretsManagerSecretId.
    * Modified cmdlet New-DMSEndpoint: added parameters DocDbSettings_SecretsManagerAccessRoleArn, DocDbSettings_SecretsManagerSecretId, IBMDb2Settings_SecretsManagerAccessRoleArn, IBMDb2Settings_SecretsManagerSecretId, MicrosoftSQLServerSettings_SecretsManagerAccessRoleArn, MicrosoftSQLServerSettings_SecretsManagerSecretId, MongoDbSettings_SecretsManagerAccessRoleArn, MongoDbSettings_SecretsManagerSecretId, MySQLSettings_SecretsManagerAccessRoleArn, MySQLSettings_SecretsManagerSecretId, OracleSettings_SecretsManagerAccessRoleArn, OracleSettings_SecretsManagerSecretId, PostgreSQLSettings_SecretsManagerAccessRoleArn, PostgreSQLSettings_SecretsManagerSecretId, RedshiftSettings_SecretsManagerAccessRoleArn, RedshiftSettings_SecretsManagerSecretId, S3Settings_CdcPath, S3Settings_CsvNoSupValue, S3Settings_PreserveTransaction, S3Settings_UseCsvNoSupValue, SybaseSettings_SecretsManagerAccessRoleArn and SybaseSettings_SecretsManagerSecretId.
  * Amazon DevOps Guru. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DGURU and can be listed using the command 'Get-AWSCmdletName -Service DGURU'.
  * Amazon Directory Service
    * Added cmdlet Add-DSRegion leveraging the AddRegion service API.
    * Added cmdlet Disable-DSClientAuthentication leveraging the DisableClientAuthentication service API.
    * Added cmdlet Enable-DSClientAuthentication leveraging the EnableClientAuthentication service API.
    * Added cmdlet Get-DSRegion leveraging the DescribeRegions service API.
    * Added cmdlet Remove-DSRegion leveraging the RemoveRegion service API.
    * Modified cmdlet Register-DSCertificate: added parameters ClientCertAuthSettings_OCSPUrl and Type.
  * Amazon DynamoDB
    * Added cmdlet Disable-DDBKinesisStreamingDestination leveraging the DisableKinesisStreamingDestination service API.
    * Added cmdlet Enable-DDBKinesisStreamingDestination leveraging the EnableKinesisStreamingDestination service API.
    * Added cmdlet Get-DDBKinesisStreamingDestination leveraging the DescribeKinesisStreamingDestination service API.
    * Added cmdlet Invoke-DDBDDBBatchExecuteStatement leveraging the BatchExecuteStatement service API.
    * Added cmdlet Invoke-DDBDDBExecuteStatement leveraging the ExecuteStatement service API.
    * Added cmdlet Invoke-DDBDDBExecuteTransaction leveraging the ExecuteTransaction service API.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRRegistry leveraging the DescribeRegistry service API.
    * Added cmdlet Get-ECRRegistryPolicy leveraging the GetRegistryPolicy service API.
    * Added cmdlet Remove-ECRRegistryPolicy leveraging the DeleteRegistryPolicy service API.
    * Added cmdlet Write-ECRRegistryPolicy leveraging the PutRegistryPolicy service API.
    * Added cmdlet Write-ECRReplicationConfiguration leveraging the PutReplicationConfiguration service API.
  * Amazon EC2 Container Service
    * Added cmdlet Update-ECSCapacityProvider leveraging the UpdateCapacityProvider service API.
    * Modified cmdlet New-ECSCapacityProvider: added parameter ManagedScaling_InstanceWarmupPeriod.
    * Modified cmdlet New-ECSService: added parameters DeploymentCircuitBreaker_Enable and DeploymentCircuitBreaker_Rollback.
    * Modified cmdlet Update-ECSService: added parameters DeploymentCircuitBreaker_Enable and DeploymentCircuitBreaker_Rollback.
  * Amazon EC2 Image Builder
    * Added cmdlet Get-EC2IBContainerRecipe leveraging the GetContainerRecipe service API.
    * Added cmdlet Get-EC2IBContainerRecipeList leveraging the ListContainerRecipes service API.
    * Added cmdlet Get-EC2IBContainerRecipePolicy leveraging the GetContainerRecipePolicy service API.
    * Added cmdlet New-EC2IBContainerRecipe leveraging the CreateContainerRecipe service API.
    * Added cmdlet Remove-EC2IBContainerRecipe leveraging the DeleteContainerRecipe service API.
    * Added cmdlet Write-EC2IBContainerRecipePolicy leveraging the PutContainerRecipePolicy service API.
    * Modified cmdlet Get-EC2IBComponentList: added parameter ByName.
    * Modified cmdlet Get-EC2IBImageList: added parameters ByName and IncludeDeprecated.
    * Modified cmdlet New-EC2IBImage: added parameter ContainerRecipeArn.
    * Modified cmdlet New-EC2IBImagePipeline: added parameter ContainerRecipeArn.
    * Modified cmdlet Update-EC2IBImagePipeline: added parameter ContainerRecipeArn.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Approve-EC2TransitGatewayMulticastDomainAssociation leveraging the AcceptTransitGatewayMulticastDomainAssociations service API.
    * Added cmdlet Deny-EC2TransitGatewayMulticastDomainAssociation leveraging the RejectTransitGatewayMulticastDomainAssociations service API.
    * Added cmdlet Get-EC2NetworkInsightsAnalysis leveraging the DescribeNetworkInsightsAnalyses service API.
    * Added cmdlet Get-EC2NetworkInsightsPath leveraging the DescribeNetworkInsightsPaths service API.
    * Added cmdlet Get-EC2TransitGatewayConnect leveraging the DescribeTransitGatewayConnects service API.
    * Added cmdlet Get-EC2TransitGatewayConnectPeer leveraging the DescribeTransitGatewayConnectPeers service API.
    * Added cmdlet New-EC2NetworkInsightsPath leveraging the CreateNetworkInsightsPath service API.
    * Added cmdlet New-EC2TransitGatewayConnect leveraging the CreateTransitGatewayConnect service API.
    * Added cmdlet New-EC2TransitGatewayConnectPeer leveraging the CreateTransitGatewayConnectPeer service API.
    * Added cmdlet Remove-EC2NetworkInsightsAnalysis leveraging the DeleteNetworkInsightsAnalysis service API.
    * Added cmdlet Remove-EC2NetworkInsightsPath leveraging the DeleteNetworkInsightsPath service API.
    * Added cmdlet Remove-EC2TransitGatewayConnect leveraging the DeleteTransitGatewayConnect service API.
    * Added cmdlet Remove-EC2TransitGatewayConnectPeer leveraging the DeleteTransitGatewayConnectPeer service API.
    * Added cmdlet Start-EC2NetworkInsightsAnalysis leveraging the StartNetworkInsightsAnalysis service API.
    * Modified cmdlet Edit-EC2TransitGateway: added parameters Options_AddTransitGatewayCidrBlock and Options_RemoveTransitGatewayCidrBlock.
    * Modified cmdlet Edit-EC2Volume: added parameters MultiAttachEnabled and Throughput.
    * Modified cmdlet New-EC2Address: added parameter TagSpecification.
    * Modified cmdlet New-EC2Image: added parameter TagSpecification.
    * Modified cmdlet New-EC2TransitGateway: added parameter Options_TransitGatewayCidrBlock.
    * Modified cmdlet New-EC2TransitGatewayMulticastDomain: added parameters Options_AutoAcceptSharedAssociation, Options_Igmpv2Support and Options_StaticSourcesSupport.
    * Modified cmdlet New-EC2Volume: added parameter Throughput.
  * Amazon Elastic Container Registry Public. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ECRP and can be listed using the command 'Get-AWSCmdletName -Service ECRP'.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSAddon leveraging the DescribeAddon service API.
    * Added cmdlet Get-EKSAddonList leveraging the ListAddons service API.
    * Added cmdlet Get-EKSAddonVersion leveraging the DescribeAddonVersions service API.
    * Added cmdlet New-EKSAddon leveraging the CreateAddon service API.
    * Added cmdlet Remove-EKSAddon leveraging the DeleteAddon service API.
    * Added cmdlet Update-EKSAddon leveraging the UpdateAddon service API.
    * Modified cmdlet Get-EKSUpdate: added parameter AddonName.
    * Modified cmdlet Get-EKSUpdateList: added parameter AddonName.
    * Modified cmdlet New-EKSNodegroup: added parameter CapacityType.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMRStudio leveraging the DescribeStudio service API.
    * Added cmdlet Get-EMRStudioList leveraging the ListStudios service API.
    * Added cmdlet Get-EMRStudioSessionMapping leveraging the GetStudioSessionMapping service API.
    * Added cmdlet Get-EMRStudioSessionMappingList leveraging the ListStudioSessionMappings service API.
    * Added cmdlet New-EMRStudio leveraging the CreateStudio service API.
    * Added cmdlet New-EMRStudioSessionMapping leveraging the CreateStudioSessionMapping service API.
    * Added cmdlet Remove-EMRStudio leveraging the DeleteStudio service API.
    * Added cmdlet Remove-EMRStudioSessionMapping leveraging the DeleteStudioSessionMapping service API.
    * Added cmdlet Update-EMRStudioSessionMapping leveraging the UpdateStudioSessionMapping service API.
  * Amazon Elemental MediaLive
    * Modified cmdlet Update-EMLInputDevice: added parameters UhdDeviceSettings_ConfiguredInput and UhdDeviceSettings_MaxBitrate.
  * Amazon EMR Containers. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EMRC and can be listed using the command 'Get-AWSCmdletName -Service EMRC'.
  * Amazon EventBridge
    * Modified cmdlet Remove-EVBPermission: added parameter RemoveAllPermission.
    * Modified cmdlet Write-EVBPermission: added parameter Policy.
  * Amazon Forecast Service
    * Added cmdlet Get-FRCPredictorBacktestExportJob leveraging the DescribePredictorBacktestExportJob service API.
    * Added cmdlet Get-FRCPredictorBacktestExportJobList leveraging the ListPredictorBacktestExportJobs service API.
    * Added cmdlet New-FRCPredictorBacktestExportJob leveraging the CreatePredictorBacktestExportJob service API.
    * Added cmdlet Remove-FRCPredictorBacktestExportJob leveraging the DeletePredictorBacktestExportJob service API.
    * Modified cmdlet New-FRCDatasetImportJob: added parameters GeolocationFormat, TimeZone and UseGeolocationForTimeZone.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLMatchmakingConfiguration: added parameter FlexMatchMode.
    * Modified cmdlet Update-GMLMatchmakingConfiguration: added parameter FlexMatchMode.
  * Amazon Global Accelerator
    * Added cmdlet Add-GACLCustomRoutingEndpoint leveraging the AddCustomRoutingEndpoints service API.
    * Added cmdlet Disable-GACLCustomRoutingTraffic leveraging the DenyCustomRoutingTraffic service API.
    * Added cmdlet Enable-GACLCustomRoutingTraffic leveraging the AllowCustomRoutingTraffic service API.
    * Added cmdlet Get-GACLCustomRoutingAccelerator leveraging the DescribeCustomRoutingAccelerator service API.
    * Added cmdlet Get-GACLCustomRoutingAcceleratorAttribute leveraging the DescribeCustomRoutingAcceleratorAttributes service API.
    * Added cmdlet Get-GACLCustomRoutingAcceleratorList leveraging the ListCustomRoutingAccelerators service API.
    * Added cmdlet Get-GACLCustomRoutingEndpointGroup leveraging the DescribeCustomRoutingEndpointGroup service API.
    * Added cmdlet Get-GACLCustomRoutingEndpointGroupList leveraging the ListCustomRoutingEndpointGroups service API.
    * Added cmdlet Get-GACLCustomRoutingListener leveraging the DescribeCustomRoutingListener service API.
    * Added cmdlet Get-GACLCustomRoutingListenerList leveraging the ListCustomRoutingListeners service API.
    * Added cmdlet Get-GACLCustomRoutingPortMappingList leveraging the ListCustomRoutingPortMappings service API.
    * Added cmdlet Get-GACLCustomRoutingPortMappingsByDestinationList leveraging the ListCustomRoutingPortMappingsByDestination service API.
    * Added cmdlet New-GACLCustomRoutingAccelerator leveraging the CreateCustomRoutingAccelerator service API.
    * Added cmdlet New-GACLCustomRoutingEndpointGroup leveraging the CreateCustomRoutingEndpointGroup service API.
    * Added cmdlet New-GACLCustomRoutingListener leveraging the CreateCustomRoutingListener service API.
    * Added cmdlet Remove-GACLCustomRoutingAccelerator leveraging the DeleteCustomRoutingAccelerator service API.
    * Added cmdlet Remove-GACLCustomRoutingEndpoint leveraging the RemoveCustomRoutingEndpoints service API.
    * Added cmdlet Remove-GACLCustomRoutingEndpointGroup leveraging the DeleteCustomRoutingEndpointGroup service API.
    * Added cmdlet Remove-GACLCustomRoutingListener leveraging the DeleteCustomRoutingListener service API.
    * Added cmdlet Update-GACLCustomRoutingAccelerator leveraging the UpdateCustomRoutingAccelerator service API.
    * Added cmdlet Update-GACLCustomRoutingAcceleratorAttribute leveraging the UpdateCustomRoutingAcceleratorAttributes service API.
    * Added cmdlet Update-GACLCustomRoutingListener leveraging the UpdateCustomRoutingListener service API.
  * Amazon Glue
    * Added cmdlet Find-GLUESchemaVersionMetadata leveraging the QuerySchemaVersionMetadata service API.
    * Added cmdlet Get-GLUERegistry leveraging the GetRegistry service API.
    * Added cmdlet Get-GLUERegistryList leveraging the ListRegistries service API.
    * Added cmdlet Get-GLUESchema leveraging the GetSchema service API.
    * Added cmdlet Get-GLUESchemaByDefinition leveraging the GetSchemaByDefinition service API.
    * Added cmdlet Get-GLUESchemaList leveraging the ListSchemas service API.
    * Added cmdlet Get-GLUESchemaVersion leveraging the GetSchemaVersion service API.
    * Added cmdlet Get-GLUESchemaVersionList leveraging the ListSchemaVersions service API.
    * Added cmdlet Get-GLUESchemaVersionsDiff leveraging the GetSchemaVersionsDiff service API.
    * Added cmdlet Get-GLUESchemaVersionValidity leveraging the CheckSchemaVersionValidity service API.
    * Added cmdlet New-GLUEPartitionIndex leveraging the CreatePartitionIndex service API.
    * Added cmdlet New-GLUERegistry leveraging the CreateRegistry service API.
    * Added cmdlet New-GLUESchema leveraging the CreateSchema service API.
    * Added cmdlet Register-GLUESchemaVersion leveraging the RegisterSchemaVersion service API.
    * Added cmdlet Remove-GLUEPartitionIndex leveraging the DeletePartitionIndex service API.
    * Added cmdlet Remove-GLUERegistry leveraging the DeleteRegistry service API.
    * Added cmdlet Remove-GLUESchema leveraging the DeleteSchema service API.
    * Added cmdlet Remove-GLUESchemaVersion leveraging the DeleteSchemaVersions service API.
    * Added cmdlet Remove-GLUESchemaVersionMetadata leveraging the RemoveSchemaVersionMetadata service API.
    * Added cmdlet Update-GLUERegistry leveraging the UpdateRegistry service API.
    * Added cmdlet Update-GLUESchema leveraging the UpdateSchema service API.
    * Added cmdlet Write-GLUESchemaVersionMetadata leveraging the PutSchemaVersionMetadata service API.
    * Modified cmdlet New-GLUECrawler: added parameter LineageConfiguration_CrawlerLineageSetting.
    * Modified cmdlet Update-GLUECrawler: added parameter LineageConfiguration_CrawlerLineageSetting.
  * Amazon GreengrassV2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GGV2 and can be listed using the command 'Get-AWSCmdletName -Service GGV2'.
  * Amazon HealthLake. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AHL and can be listed using the command 'Get-AWSCmdletName -Service AHL'.
  * Amazon IoT
    * Added cmdlet Get-IOTBehaviorModelTrainingSummary leveraging the GetBehaviorModelTrainingSummaries service API.
    * Added cmdlet Get-IOTCustomMetric leveraging the DescribeCustomMetric service API.
    * Added cmdlet Get-IOTCustomMetricList leveraging the ListCustomMetrics service API.
    * Added cmdlet Get-IOTDetectMitigationActionsExecutionList leveraging the ListDetectMitigationActionsExecutions service API.
    * Added cmdlet Get-IOTDetectMitigationActionsTask leveraging the DescribeDetectMitigationActionsTask service API.
    * Added cmdlet Get-IOTDetectMitigationActionsTaskList leveraging the ListDetectMitigationActionsTasks service API.
    * Added cmdlet New-IOTCustomMetric leveraging the CreateCustomMetric service API.
    * Added cmdlet Remove-IOTCustomMetric leveraging the DeleteCustomMetric service API.
    * Added cmdlet Start-IOTDetectMitigationActionsTask leveraging the StartDetectMitigationActionsTask service API.
    * Added cmdlet Stop-IOTDetectMitigationActionsTask leveraging the CancelDetectMitigationActionsTask service API.
    * Added cmdlet Update-IOTCustomMetric leveraging the UpdateCustomMetric service API.
    * Modified cmdlet Get-IOTActiveViolationList: added parameters BehaviorCriteriaType and ListSuppressedAlert.
    * Modified cmdlet Get-IOTSecurityProfileList: added parameter MetricName.
    * Modified cmdlet Get-IOTViolationEventList: added parameters BehaviorCriteriaType and ListSuppressedAlert.
    * Modified cmdlet New-IOTTopicRule: added parameters Kafka_ClientProperty, Kafka_DestinationArn, Kafka_Key, Kafka_Partition and Kafka_Topic.
    * Modified cmdlet New-IOTTopicRuleDestination: added parameters VpcConfiguration_RoleArn, VpcConfiguration_SecurityGroup, VpcConfiguration_SubnetId and VpcConfiguration_VpcId.
    * Modified cmdlet Set-IOTTopicRule: added parameters Kafka_ClientProperty, Kafka_DestinationArn, Kafka_Key, Kafka_Partition and Kafka_Topic.
  * Amazon IoT Core Device Advisor. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTDA and can be listed using the command 'Get-AWSCmdletName -Service IOTDA'.
  * Amazon IoT Fleet Hub. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTFH and can be listed using the command 'Get-AWSCmdletName -Service IOTFH'.
  * IOTSW
    * [Breaking Change] Removed cmdlet New-IOTSWPresignedPortalUrl.
    * Added cmdlet Get-IOTSWAssetRelationshipList leveraging the ListAssetRelationships service API.
    * Added cmdlet Get-IOTSWDefaultEncryptionConfiguration leveraging the DescribeDefaultEncryptionConfiguration service API.
    * Added cmdlet Write-IOTSWDefaultEncryptionConfiguration leveraging the PutDefaultEncryptionConfiguration service API.
    * Modified cmdlet New-IOTSWAssetModel: added parameter AssetModelCompositeModel.
    * Modified cmdlet Update-IOTSWAssetModel: added parameter AssetModelCompositeModel.
  * Amazon IoT Wireless. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTW and can be listed using the command 'Get-AWSCmdletName -Service IOTW'.
  * Amazon Kendra
    * Added cmdlet Get-KNDRThesauriList leveraging the ListThesauri service API.
    * Added cmdlet Get-KNDRThesaurus leveraging the DescribeThesaurus service API.
    * Added cmdlet New-KNDRThesaurus leveraging the CreateThesaurus service API.
    * Added cmdlet Remove-KNDRThesaurus leveraging the DeleteThesaurus service API.
    * Added cmdlet Update-KNDRThesaurus leveraging the UpdateThesaurus service API.
    * Modified cmdlet Invoke-KNDRQuery: added parameter VisitorId.
  * Amazon Kinesis Analytics V2
    * Added cmdlet New-KINA2ApplicationPresignedUrl leveraging the CreateApplicationPresignedUrl service API.
  * Amazon Lambda
    * Added cmdlet Get-LMCodeSigningConfig leveraging the GetCodeSigningConfig service API.
    * Added cmdlet Get-LMCodeSigningConfigList leveraging the ListCodeSigningConfigs service API.
    * Added cmdlet Get-LMFunctionCodeSigningConfig leveraging the GetFunctionCodeSigningConfig service API.
    * Added cmdlet Get-LMFunctionsByCodeSigningConfigList leveraging the ListFunctionsByCodeSigningConfig service API.
    * Added cmdlet New-LMCodeSigningConfig leveraging the CreateCodeSigningConfig service API.
    * Added cmdlet Remove-LMCodeSigningConfig leveraging the DeleteCodeSigningConfig service API.
    * Added cmdlet Remove-LMFunctionCodeSigningConfig leveraging the DeleteFunctionCodeSigningConfig service API.
    * Added cmdlet Update-LMCodeSigningConfig leveraging the UpdateCodeSigningConfig service API.
    * Added cmdlet Write-LMFunctionCodeSigningConfig leveraging the PutFunctionCodeSigningConfig service API.
    * Modified cmdlet Publish-LMFunction: added parameters Code_ImageUri, CodeSigningConfigArn, ImageConfig_Command, ImageConfig_EntryPoint, ImageConfig_IsCommandSet, ImageConfig_IsEntryPointSet, ImageConfig_WorkingDirectory and PackageType.
    * Modified cmdlet Update-LMFunctionCode: added parameter ImageUri.
    * Modified cmdlet New-LMEventSourceMapping: added parameters FunctionResponseType, SelfManagedEventSource_Endpoint and TumblingWindowInSecond.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters FunctionResponseType and TumblingWindowInSecond.
    * Modified cmdlet Update-LMFunctionConfiguration: added parameters ImageConfig_Command, ImageConfig_EntryPoint, ImageConfig_IsCommandSet, ImageConfig_IsEntryPointSet and ImageConfig_WorkingDirectory.
  * Amazon Lex
    * Modified cmdlet Send-LEXContent: added parameter ActiveContext.
    * Modified cmdlet Send-LEXText: added parameter ActiveContext.
    * Modified cmdlet Write-LEXSession: added parameter ActiveContext.
  * Amazon Lex Model Building Service
    * Modified cmdlet Write-LMBIntent: added parameters InputContext and OutputContext.
  * Amazon License Manager
    * Added cmdlet Approve-LICMGrant leveraging the AcceptGrant service API.
    * Added cmdlet Deny-LICMGrant leveraging the RejectGrant service API.
    * Added cmdlet Get-LICMAccessToken leveraging the GetAccessToken service API.
    * Added cmdlet Get-LICMDistributedGrantList leveraging the ListDistributedGrants service API.
    * Added cmdlet Get-LICMGrant leveraging the GetGrant service API.
    * Added cmdlet Get-LICMLicense leveraging the GetLicense service API.
    * Added cmdlet Get-LICMLicenseList leveraging the ListLicenses service API.
    * Added cmdlet Get-LICMLicenseUsage leveraging the GetLicenseUsage service API.
    * Added cmdlet Get-LICMLicenseVersionList leveraging the ListLicenseVersions service API.
    * Added cmdlet Get-LICMReceivedGrantList leveraging the ListReceivedGrants service API.
    * Added cmdlet Get-LICMReceivedLicenseList leveraging the ListReceivedLicenses service API.
    * Added cmdlet Get-LICMTokenList leveraging the ListTokens service API.
    * Added cmdlet Invoke-LICMExtendLicenseConsumption leveraging the ExtendLicenseConsumption service API.
    * Added cmdlet Invoke-LICMLicenseCheckIn leveraging the CheckInLicense service API.
    * Added cmdlet Invoke-LICMLicenseCheckout leveraging the CheckoutLicense service API.
    * Added cmdlet Invoke-LICMLicenseCheckoutBorrow leveraging the CheckoutBorrowLicense service API.
    * Added cmdlet New-LICMGrant leveraging the CreateGrant service API.
    * Added cmdlet New-LICMGrantVersion leveraging the CreateGrantVersion service API.
    * Added cmdlet New-LICMLicense leveraging the CreateLicense service API.
    * Added cmdlet New-LICMLicenseVersion leveraging the CreateLicenseVersion service API.
    * Added cmdlet New-LICMToken leveraging the CreateToken service API.
    * Added cmdlet Remove-LICMGrant leveraging the DeleteGrant service API.
    * Added cmdlet Remove-LICMLicense leveraging the DeleteLicense service API.
    * Added cmdlet Remove-LICMToken leveraging the DeleteToken service API.
    * Modified cmdlet New-LICMLicenseConfiguration: added parameter DisassociateWhenNotFound.
    * Modified cmdlet Update-LICMLicenseConfiguration: added parameter DisassociateWhenNotFound.
  * Amazon Location Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LOC and can be listed using the command 'Get-AWSCmdletName -Service LOC'.
  * Amazon Lookout for Vision. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LFV and can be listed using the command 'Get-AWSCmdletName -Service LFV'.
  * Amazon Network Firewall. Added cmdlets to support the service. Cmdlets for the service have the noun prefix NWFW and can be listed using the command 'Get-AWSCmdletName -Service NWFW'.
  * Amazon Network Manager
    * Added cmdlet Get-NMGRConnection leveraging the GetConnections service API.
    * Added cmdlet Get-NMGRTransitGatewayConnectPeerAssociation leveraging the GetTransitGatewayConnectPeerAssociations service API.
    * Added cmdlet New-NMGRConnection leveraging the CreateConnection service API.
    * Added cmdlet Register-NMGRTransitGatewayConnectPeer leveraging the AssociateTransitGatewayConnectPeer service API.
    * Added cmdlet Remove-NMGRConnection leveraging the DeleteConnection service API.
    * Added cmdlet Unregister-NMGRTransitGatewayConnectPeer leveraging the DisassociateTransitGatewayConnectPeer service API.
    * Added cmdlet Update-NMGRConnection leveraging the UpdateConnection service API.
    * Modified cmdlet New-NMGRDevice: added parameters AWSLocation_SubnetArn and AWSLocation_Zone.
    * Modified cmdlet Update-NMGRDevice: added parameters AWSLocation_SubnetArn and AWSLocation_Zone.
  * Amazon Outposts
    * Added cmdlet Add-OUTPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-OUTPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-OUTPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-OUTPOutpost: added parameter Tag.
  * Amazon Prometheus Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PROM and can be listed using the command 'Get-AWSCmdletName -Service PROM'.
  * Amazon QuickSight
    * [Breaking Change] Modified cmdlet Get-QSDashboardEmbedUrl: the type of parameter IdentityType changed from Amazon.QuickSight.IdentityType to Amazon.QuickSight.EmbeddingIdentityType; added parameters AdditionalDashboardId and Namespace.
  * Amazon Redshift
    * Modified cmdlet Edit-RSCluster: added parameters AvailabilityZone, AvailabilityZoneRelocation and Port.
    * Modified cmdlet New-RSCluster: added parameter AvailabilityZoneRelocation.
    * Modified cmdlet Restore-RSFromClusterSnapshot: added parameter AvailabilityZoneRelocation.
  * Amazon Relational Database Service
    * Added cmdlet Start-RDSDBInstanceAutomatedBackupsReplication leveraging the StartDBInstanceAutomatedBackupsReplication service API.
    * Added cmdlet Stop-RDSDBInstanceAutomatedBackupsReplication leveraging the StopDBInstanceAutomatedBackupsReplication service API.
    * Modified cmdlet Copy-RDSDBSnapshot: added parameter TargetCustomAvailabilityZone.
    * Modified cmdlet Edit-RDSDBInstance: added parameter EnableCustomerOwnedIp.
    * Modified cmdlet Get-RDSDBInstanceAutomatedBackup: added parameter DBInstanceAutomatedBackupsArn.
    * Modified cmdlet New-RDSDBInstance: added parameter EnableCustomerOwnedIp.
    * Modified cmdlet Remove-RDSDBInstanceAutomatedBackup: added parameter DBInstanceAutomatedBackupsArn.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter EnableCustomerOwnedIp.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameters EnableCustomerOwnedIp and SourceDBInstanceAutomatedBackupsArn.
  * Amazon Route 53
    * Added cmdlet Disable-R53HostedZoneDNSSEC leveraging the DisableHostedZoneDNSSEC service API.
    * Added cmdlet Disable-R53KeySigningKey leveraging the DeactivateKeySigningKey service API.
    * Added cmdlet Enable-R53HostedZoneDNSSEC leveraging the EnableHostedZoneDNSSEC service API.
    * Added cmdlet Enable-R53KeySigningKey leveraging the ActivateKeySigningKey service API.
    * Added cmdlet Get-R53DNSSEC leveraging the GetDNSSEC service API.
    * Added cmdlet New-R53KeySigningKey leveraging the CreateKeySigningKey service API.
    * Added cmdlet Remove-R53KeySigningKey leveraging the DeleteKeySigningKey service API.
  * Amazon Route 53 Resolver
    * Added cmdlet Get-R53RResolverDnssecConfig leveraging the GetResolverDnssecConfig service API.
    * Added cmdlet Get-R53RResolverDnssecConfigList leveraging the ListResolverDnssecConfigs service API.
    * Added cmdlet Update-R53RResolverDnssecConfig leveraging the UpdateResolverDnssecConfig service API.
  * Amazon S3 Control
    * Added cmdlet Get-S3CStorageLensConfiguration leveraging the GetStorageLensConfiguration service API.
    * Added cmdlet Get-S3CStorageLensConfigurationList leveraging the ListStorageLensConfigurations service API.
    * Added cmdlet Get-S3CStorageLensConfigurationTagging leveraging the GetStorageLensConfigurationTagging service API.
    * Added cmdlet Remove-S3CStorageLensConfiguration leveraging the DeleteStorageLensConfiguration service API.
    * Added cmdlet Remove-S3CStorageLensConfigurationTagging leveraging the DeleteStorageLensConfigurationTagging service API.
    * Added cmdlet Write-S3CStorageLensConfiguration leveraging the PutStorageLensConfiguration service API.
    * Added cmdlet Write-S3CStorageLensConfigurationTagging leveraging the PutStorageLensConfigurationTagging service API.
  * Amazon Sagemaker Edge Manager. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SME and can be listed using the command 'Get-AWSCmdletName -Service SME'.
  * Amazon SageMaker Feature Store Runtime. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SMFS and can be listed using the command 'Get-AWSCmdletName -Service SMFS'.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpoint: added parameter InferenceId.
  * Amazon SageMaker Service
    * Added cmdlet Add-SMAssociation leveraging the AddAssociation service API.
    * Added cmdlet Disable-SMSagemakerServicecatalogPortfolio leveraging the DisableSagemakerServicecatalogPortfolio service API.
    * Added cmdlet Enable-SMSagemakerServicecatalogPortfolio leveraging the EnableSagemakerServicecatalogPortfolio service API.
    * Added cmdlet Get-SMAction leveraging the DescribeAction service API.
    * Added cmdlet Get-SMActionList leveraging the ListActions service API.
    * Added cmdlet Get-SMArtifact leveraging the DescribeArtifact service API.
    * Added cmdlet Get-SMArtifactList leveraging the ListArtifacts service API.
    * Added cmdlet Get-SMAssociationList leveraging the ListAssociations service API.
    * Added cmdlet Get-SMContext leveraging the DescribeContext service API.
    * Added cmdlet Get-SMContextList leveraging the ListContexts service API.
    * Added cmdlet Get-SMDataQualityJobDefinition leveraging the DescribeDataQualityJobDefinition service API.
    * Added cmdlet Get-SMDataQualityJobDefinitionList leveraging the ListDataQualityJobDefinitions service API.
    * Added cmdlet Get-SMDevice leveraging the DescribeDevice service API.
    * Added cmdlet Get-SMDeviceFleet leveraging the DescribeDeviceFleet service API.
    * Added cmdlet Get-SMDeviceFleetList leveraging the ListDeviceFleets service API.
    * Added cmdlet Get-SMDeviceFleetReport leveraging the GetDeviceFleetReport service API.
    * Added cmdlet Get-SMDeviceList leveraging the ListDevices service API.
    * Added cmdlet Get-SMEdgePackagingJob leveraging the DescribeEdgePackagingJob service API.
    * Added cmdlet Get-SMEdgePackagingJobList leveraging the ListEdgePackagingJobs service API.
    * Added cmdlet Get-SMFeatureGroup leveraging the DescribeFeatureGroup service API.
    * Added cmdlet Get-SMFeatureGroupList leveraging the ListFeatureGroups service API.
    * Added cmdlet Get-SMModelBiasJobDefinition leveraging the DescribeModelBiasJobDefinition service API.
    * Added cmdlet Get-SMModelBiasJobDefinitionList leveraging the ListModelBiasJobDefinitions service API.
    * Added cmdlet Get-SMModelExplainabilityJobDefinition leveraging the DescribeModelExplainabilityJobDefinition service API.
    * Added cmdlet Get-SMModelExplainabilityJobDefinitionList leveraging the ListModelExplainabilityJobDefinitions service API.
    * Added cmdlet Get-SMModelPackageGroup leveraging the DescribeModelPackageGroup service API.
    * Added cmdlet Get-SMModelPackageGroupList leveraging the ListModelPackageGroups service API.
    * Added cmdlet Get-SMModelPackageGroupPolicy leveraging the GetModelPackageGroupPolicy service API.
    * Added cmdlet Get-SMModelQualityJobDefinition leveraging the DescribeModelQualityJobDefinition service API.
    * Added cmdlet Get-SMModelQualityJobDefinitionList leveraging the ListModelQualityJobDefinitions service API.
    * Added cmdlet Get-SMPipeline leveraging the DescribePipeline service API.
    * Added cmdlet Get-SMPipelineDefinitionForExecution leveraging the DescribePipelineDefinitionForExecution service API.
    * Added cmdlet Get-SMPipelineExecution leveraging the DescribePipelineExecution service API.
    * Added cmdlet Get-SMPipelineExecutionList leveraging the ListPipelineExecutions service API.
    * Added cmdlet Get-SMPipelineExecutionStepList leveraging the ListPipelineExecutionSteps service API.
    * Added cmdlet Get-SMPipelineList leveraging the ListPipelines service API.
    * Added cmdlet Get-SMPipelineParametersForExecutionList leveraging the ListPipelineParametersForExecution service API.
    * Added cmdlet Get-SMProject leveraging the DescribeProject service API.
    * Added cmdlet Get-SMProjectList leveraging the ListProjects service API.
    * Added cmdlet Get-SMSagemakerServicecatalogPortfolioStatus leveraging the GetSagemakerServicecatalogPortfolioStatus service API.
    * Added cmdlet New-SMAction leveraging the CreateAction service API.
    * Added cmdlet New-SMArtifact leveraging the CreateArtifact service API.
    * Added cmdlet New-SMContext leveraging the CreateContext service API.
    * Added cmdlet New-SMDataQualityJobDefinition leveraging the CreateDataQualityJobDefinition service API.
    * Added cmdlet New-SMDeviceFleet leveraging the CreateDeviceFleet service API.
    * Added cmdlet New-SMEdgePackagingJob leveraging the CreateEdgePackagingJob service API.
    * Added cmdlet New-SMFeatureGroup leveraging the CreateFeatureGroup service API.
    * Added cmdlet New-SMModelBiasJobDefinition leveraging the CreateModelBiasJobDefinition service API.
    * Added cmdlet New-SMModelExplainabilityJobDefinition leveraging the CreateModelExplainabilityJobDefinition service API.
    * Added cmdlet New-SMModelPackageGroup leveraging the CreateModelPackageGroup service API.
    * Added cmdlet New-SMModelQualityJobDefinition leveraging the CreateModelQualityJobDefinition service API.
    * Added cmdlet New-SMPipeline leveraging the CreatePipeline service API.
    * Added cmdlet New-SMProject leveraging the CreateProject service API.
    * Added cmdlet Register-SMDevice leveraging the RegisterDevices service API.
    * Added cmdlet Remove-SMAction leveraging the DeleteAction service API.
    * Added cmdlet Remove-SMArtifact leveraging the DeleteArtifact service API.
    * Added cmdlet Remove-SMAssociation leveraging the DeleteAssociation service API.
    * Added cmdlet Remove-SMContext leveraging the DeleteContext service API.
    * Added cmdlet Remove-SMDataQualityJobDefinition leveraging the DeleteDataQualityJobDefinition service API.
    * Added cmdlet Remove-SMDevice leveraging the DeregisterDevices service API.
    * Added cmdlet Remove-SMDeviceFleet leveraging the DeleteDeviceFleet service API.
    * Added cmdlet Remove-SMFeatureGroup leveraging the DeleteFeatureGroup service API.
    * Added cmdlet Remove-SMModelBiasJobDefinition leveraging the DeleteModelBiasJobDefinition service API.
    * Added cmdlet Remove-SMModelExplainabilityJobDefinition leveraging the DeleteModelExplainabilityJobDefinition service API.
    * Added cmdlet Remove-SMModelPackageGroup leveraging the DeleteModelPackageGroup service API.
    * Added cmdlet Remove-SMModelPackageGroupPolicy leveraging the DeleteModelPackageGroupPolicy service API.
    * Added cmdlet Remove-SMModelQualityJobDefinition leveraging the DeleteModelQualityJobDefinition service API.
    * Added cmdlet Remove-SMPipeline leveraging the DeletePipeline service API.
    * Added cmdlet Remove-SMProject leveraging the DeleteProject service API.
    * Added cmdlet Start-SMPipelineExecution leveraging the StartPipelineExecution service API.
    * Added cmdlet Stop-SMEdgePackagingJob leveraging the StopEdgePackagingJob service API.
    * Added cmdlet Stop-SMPipelineExecution leveraging the StopPipelineExecution service API.
    * Added cmdlet Update-SMAction leveraging the UpdateAction service API.
    * Added cmdlet Update-SMArtifact leveraging the UpdateArtifact service API.
    * Added cmdlet Update-SMContext leveraging the UpdateContext service API.
    * Added cmdlet Update-SMDevice leveraging the UpdateDevices service API.
    * Added cmdlet Update-SMDeviceFleet leveraging the UpdateDeviceFleet service API.
    * Added cmdlet Update-SMModelPackage leveraging the UpdateModelPackage service API.
    * Added cmdlet Update-SMPipeline leveraging the UpdatePipeline service API.
    * Added cmdlet Update-SMPipelineExecution leveraging the UpdatePipelineExecution service API.
    * Added cmdlet Update-SMTrainingJob leveraging the UpdateTrainingJob service API.
    * Added cmdlet Write-SMModelPackageGroupPolicy leveraging the PutModelPackageGroupPolicy service API.
    * Modified cmdlet Get-SMModelPackageList: added parameters ModelApprovalStatus, ModelPackageGroupName and ModelPackageType.
    * Modified cmdlet Get-SMMonitoringExecutionList: added parameters MonitoringJobDefinitionName and MonitoringTypeEqual.
    * Modified cmdlet Get-SMMonitoringScheduleList: added parameters MonitoringJobDefinitionName and MonitoringTypeEqual.
    * Modified cmdlet New-SMAlgorithm: added parameter Tag.
    * Modified cmdlet New-SMCodeRepository: added parameter Tag.
    * Modified cmdlet New-SMCompilationJob: added parameter OutputConfig_KmsKeyId.
    * Modified cmdlet New-SMModelPackage: added parameters ClientToken, MetadataProperties_CommitId, MetadataProperties_GeneratedBy, MetadataProperties_ProjectId, MetadataProperties_Repository, ModelApprovalStatus, ModelMetrics_Bias_Report_ContentDigest, ModelMetrics_Bias_Report_ContentType, ModelMetrics_Bias_Report_S3Uri, ModelMetrics_Explainability_Report_ContentDigest, ModelMetrics_Explainability_Report_ContentType, ModelMetrics_Explainability_Report_S3Uri, ModelMetrics_ModelDataQuality_Constraints_ContentDigest, ModelMetrics_ModelDataQuality_Constraints_ContentType, ModelMetrics_ModelDataQuality_Constraints_S3Uri, ModelMetrics_ModelDataQuality_Statistics_ContentDigest, ModelMetrics_ModelDataQuality_Statistics_ContentType, ModelMetrics_ModelDataQuality_Statistics_S3Uri, ModelMetrics_ModelQuality_Constraints_ContentDigest, ModelMetrics_ModelQuality_Constraints_ContentType, ModelMetrics_ModelQuality_Constraints_S3Uri, ModelMetrics_ModelQuality_Statistics_ContentDigest, ModelMetrics_ModelQuality_Statistics_ContentType, ModelMetrics_ModelQuality_Statistics_S3Uri, ModelPackageGroupName and Tag.
    * Modified cmdlet New-SMTrainingJob: added parameters ProfilerConfig_ProfilingIntervalInMillisecond, ProfilerConfig_ProfilingParameter, ProfilerConfig_S3OutputPath and ProfilerRuleConfiguration.
    * Modified cmdlet New-SMTrial: added parameters MetadataProperties_CommitId, MetadataProperties_GeneratedBy, MetadataProperties_ProjectId and MetadataProperties_Repository.
    * Modified cmdlet New-SMTrialComponent: added parameters MetadataProperties_CommitId, MetadataProperties_GeneratedBy, MetadataProperties_ProjectId and MetadataProperties_Repository.
    * Modified cmdlet Update-SMEndpoint: added parameters AutoRollbackConfiguration_Alarm, BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond, BlueGreenUpdatePolicy_TerminationWaitInSecond, CanarySize_Type, CanarySize_Value, TrafficRoutingConfiguration_Type and TrafficRoutingConfiguration_WaitIntervalInSecond.
  * Amazon Security Hub
    * Added cmdlet Disable-SHUBOrganizationAdminAccount leveraging the DisableOrganizationAdminAccount service API.
    * Added cmdlet Enable-SHUBOrganizationAdminAccount leveraging the EnableOrganizationAdminAccount service API.
    * Added cmdlet Get-SHUBOrganizationAdminAccountList leveraging the ListOrganizationAdminAccounts service API.
    * Added cmdlet Get-SHUBOrganizationConfiguration leveraging the DescribeOrganizationConfiguration service API.
    * Added cmdlet Update-SHUBOrganizationConfiguration leveraging the UpdateOrganizationConfiguration service API.
  * Amazon Service Catalog
    * Added cmdlet Get-SCPortfolioShare leveraging the DescribePortfolioShares service API.
    * Added cmdlet Update-SCPortfolioShare leveraging the UpdatePortfolioShare service API.
    * Modified cmdlet Get-SCProductAsAdmin: added parameter SourcePortfolioId.
    * Modified cmdlet New-SCPortfolioShare: added parameter ShareTagOption.
  * Amazon Service Catalog App Registry
    * Added cmdlet Add-SCARResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SCARResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SCARResourceTag leveraging the UntagResource service API.
    * Added cmdlet Sync-SCARResource leveraging the SyncResource service API.
  * Amazon Service Quotas
    * Added cmdlet Add-SQResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SQResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SQResourceTag leveraging the UntagResource service API.
  * Amazon Single Sign-On Admin
    * Added cmdlet Get-SSOADMNInstanceAccessControlAttributeConfiguration leveraging the DescribeInstanceAccessControlAttributeConfiguration service API.
    * Added cmdlet New-SSOADMNInstanceAccessControlAttributeConfiguration leveraging the CreateInstanceAccessControlAttributeConfiguration service API.
    * Added cmdlet Remove-SSOADMNInstanceAccessControlAttributeConfiguration leveraging the DeleteInstanceAccessControlAttributeConfiguration service API.
    * Added cmdlet Update-SSOADMNInstanceAccessControlAttributeConfiguration leveraging the UpdateInstanceAccessControlAttributeConfiguration service API.
  * Amazon Step Functions
    * Added cmdlet Start-SFNSyncExecution leveraging the StartSyncExecution service API.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMDocumentMetadataHistory leveraging the ListDocumentMetadataHistory service API.
    * Added cmdlet Get-SSMOpsItemEvent leveraging the ListOpsItemEvents service API.
    * Added cmdlet Get-SSMOpsMetadata leveraging the GetOpsMetadata service API.
    * Added cmdlet Get-SSMOpsMetadataList leveraging the ListOpsMetadata service API.
    * Added cmdlet New-SSMOpsMetadata leveraging the CreateOpsMetadata service API.
    * Added cmdlet Remove-SSMOpsMetadata leveraging the DeleteOpsMetadata service API.
    * Added cmdlet Start-SSMChangeRequestExecution leveraging the StartChangeRequestExecution service API.
    * Added cmdlet Update-SSMDocumentMetadata leveraging the UpdateDocumentMetadata service API.
    * Added cmdlet Update-SSMOpsMetadata leveraging the UpdateOpsMetadata service API.
    * Modified cmdlet New-SSMAssociation: added parameter TargetLocation.
    * Modified cmdlet New-SSMOpsItem: added parameters ActualEndTime, ActualStartTime, OpsItemType, PlannedEndTime and PlannedStartTime.
    * Modified cmdlet Update-SSMAssociation: added parameter TargetLocation.
    * Modified cmdlet Update-SSMOpsItem: added parameters ActualEndTime, ActualStartTime, PlannedEndTime and PlannedStartTime.
  * Amazon Translate
    * Added cmdlet Get-TRNParallelData leveraging the GetParallelData service API.
    * Added cmdlet Get-TRNParallelDataList leveraging the ListParallelData service API.
    * Added cmdlet New-TRNParallelData leveraging the CreateParallelData service API.
    * Added cmdlet Remove-TRNParallelData leveraging the DeleteParallelData service API.
    * Added cmdlet Update-TRNParallelData leveraging the UpdateParallelData service API.
    * Modified cmdlet Start-TRNTextTranslationJob: added parameter ParallelDataName.
  * Amazon Well-Architected Tool. Added cmdlets to support the service. Cmdlets for the service have the noun prefix WAT and can be listed using the command 'Get-AWSCmdletName -Service WAT'.

### 4.1.5.0 (2020-11-16)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.56.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon Identity Store. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IDS and can be listed using the command 'Get-AWSCmdletName -Service IDS'.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter CustomHeader.
    * Modified cmdlet Update-AMPApp: added parameter CustomHeader.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter RunConfig_EnvironmentVariable.
    * Modified cmdlet Update-CWSYNCanary: added parameter RunConfig_EnvironmentVariable.
  * Amazon Database Migration Service
    * Added cmdlet Move-DMSReplicationTask leveraging the MoveReplicationTask service API.
  * Amazon DataSync
    * Added cmdlet Update-DSYNTaskExecution leveraging the UpdateTaskExecution service API.
  * Amazon DynamoDB
    * Added cmdlet Export-DDBTableToPointInTime leveraging the ExportTableToPointInTime service API.
    * Added cmdlet Get-DDBExport leveraging the DescribeExport service API.
    * Added cmdlet Get-DDBExportList leveraging the ListExports service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2VpcEndpointServiceConfiguration: added parameters AddGatewayLoadBalancerArn and RemoveGatewayLoadBalancerArn.
    * Modified cmdlet New-EC2Route: added parameter VpcEndpointId.
    * Modified cmdlet New-EC2VpcEndpointServiceConfiguration: added parameter GatewayLoadBalancerArn.
    * Modified cmdlet Set-EC2Route: added parameter VpcEndpointId.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Set-ELB2Subnet: added parameter IpAddressType.
  * Amazon Elasticsearch
    * Added cmdlet Get-ESPackageVersionHistory leveraging the GetPackageVersionHistory service API.
    * Added cmdlet Update-ESPackage leveraging the UpdatePackage service API.
  * Amazon Forecast Service
    * Modified cmdlet New-FRCPredictor: added parameter ForecastType.
  * Amazon FSx
    * Added cmdlet Get-FSXFileSystemAlias leveraging the DescribeFileSystemAliases service API.
    * Added cmdlet Register-FSXFileSystemAlias leveraging the AssociateFileSystemAliases service API.
    * Added cmdlet Unregister-FSXFileSystemAlias leveraging the DisassociateFileSystemAliases service API.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameters Firehose_BatchMode, IotAnalytics_BatchMode and IotEvents_BatchMode.
    * Modified cmdlet Set-IOTTopicRule: added parameters Firehose_BatchMode, IotAnalytics_BatchMode and IotEvents_BatchMode.
  * Amazon IoT SiteWise
    * Added cmdlet New-IOTSWPresignedPortalUrl leveraging the CreatePresignedPortalUrl service API.
  * Amazon Lightsail
    * Added cmdlet Get-LSContainerAPIMetadata leveraging the GetContainerAPIMetadata service API.
    * Added cmdlet Get-LSContainerImage leveraging the GetContainerImages service API.
    * Added cmdlet Get-LSContainerLog leveraging the GetContainerLog service API.
    * Added cmdlet Get-LSContainerService leveraging the GetContainerServices service API.
    * Added cmdlet Get-LSContainerServiceDeployment leveraging the GetContainerServiceDeployments service API.
    * Added cmdlet Get-LSContainerServiceMetricData leveraging the GetContainerServiceMetricData service API.
    * Added cmdlet Get-LSContainerServicePower leveraging the GetContainerServicePowers service API.
    * Added cmdlet New-LSContainerService leveraging the CreateContainerService service API.
    * Added cmdlet New-LSContainerServiceDeployment leveraging the CreateContainerServiceDeployment service API.
    * Added cmdlet New-LSContainerServiceRegistryLogin leveraging the CreateContainerServiceRegistryLogin service API.
    * Added cmdlet Register-LSContainerImage leveraging the RegisterContainerImage service API.
    * Added cmdlet Remove-LSContainerImage leveraging the DeleteContainerImage service API.
    * Added cmdlet Remove-LSContainerService leveraging the DeleteContainerService service API.
    * Added cmdlet Update-LSContainerService leveraging the UpdateContainerService service API.
  * Amazon Personalize Runtime
    * Modified cmdlet Get-PERSRPersonalizedRanking: added parameter FilterValue.
    * Modified cmdlet Get-PERSRRecommendation: added parameter FilterValue.
  * Amazon QuickSight
    * Modified cmdlet Get-QSDashboardEmbedUrl: added parameter StatePersistenceEnabled.
    * Modified cmdlet New-QSDataSet: added parameter ColumnLevelPermissionRule.
    * Modified cmdlet New-QSDataSource: added parameters OracleParameters_Database, OracleParameters_Host and OracleParameters_Port.
    * Modified cmdlet Update-QSDataSet: added parameter ColumnLevelPermissionRule.
    * Modified cmdlet Update-QSDataSource: added parameters OracleParameters_Database, OracleParameters_Host and OracleParameters_Port.
  * Amazon RoboMaker
    * Modified cmdlet New-ROBOWorldGenerationJob: added parameter WorldTag.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter KmsKeyId.
  * Amazon Service Catalog
    * Added cmdlet Import-SCAsProvisionedProduct leveraging the ImportAsProvisionedProduct service API.
    * Modified cmdlet Remove-SCProvisionedProduct: added parameter RetainPhysicalResource.
  * Amazon Service Catalog App Registry. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SCAR and can be listed using the command 'Get-AWSCmdletName -Service SCAR'.
  * Amazon Shield
    * Added cmdlet Get-SHLDAttackStatistic leveraging the DescribeAttackStatistics service API.
    * Added cmdlet Get-SHLDProtectionGroup leveraging the DescribeProtectionGroup service API.
    * Added cmdlet Get-SHLDProtectionGroupList leveraging the ListProtectionGroups service API.
    * Added cmdlet Get-SHLDResourcesInProtectionGroupList leveraging the ListResourcesInProtectionGroup service API.
    * Added cmdlet New-SHLDProtectionGroup leveraging the CreateProtectionGroup service API.
    * Added cmdlet Remove-SHLDProtectionGroup leveraging the DeleteProtectionGroup service API.
    * Added cmdlet Update-SHLDProtectionGroup leveraging the UpdateProtectionGroup service API.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3BucketIntelligentTieringConfiguration leveraging the GetBucketIntelligentTieringConfiguration service API.
    * Added cmdlet Get-S3BucketIntelligentTieringConfigurationList leveraging the ListBucketIntelligentTieringConfigurations service API.
    * Added cmdlet Remove-S3BucketIntelligentTieringConfiguration leveraging the DeleteBucketIntelligentTieringConfiguration service API.
    * Added cmdlet Write-S3BucketIntelligentTieringConfiguration leveraging the PutBucketIntelligentTieringConfiguration service API.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGBandwidthRateLimitSchedule leveraging the DescribeBandwidthRateLimitSchedule service API.
    * Added cmdlet Update-SGBandwidthRateLimitSchedule leveraging the UpdateBandwidthRateLimitSchedule service API.
  * Amazon Textract
    * Modified cmdlet Start-TXTDocumentAnalysis: added parameter KMSKeyId.
    * Modified cmdlet Start-TXTDocumentTextDetection: added parameter KMSKeyId.

### 4.1.4.0 (2020-11-06)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.50.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter AutoBranchCreationConfig_EnablePerformanceMode.
    * Modified cmdlet New-AMPBranch: added parameter EnablePerformanceMode.
    * Modified cmdlet Update-AMPApp: added parameter AutoBranchCreationConfig_EnablePerformanceMode.
    * Modified cmdlet Update-AMPBranch: added parameter EnablePerformanceMode.
  * Amazon API Gateway
    * Modified cmdlet New-AGRestApi: added parameter DisableExecuteApiEndpoint.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameter IncrementalPullConfig_DatetimeTypeFieldName.
    * Modified cmdlet Update-AFFlow: added parameter IncrementalPullConfig_DatetimeTypeFieldName.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter CapacityRebalance.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter CapacityRebalance.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter RetryStrategy_EvaluateOnExit.
    * Modified cmdlet Submit-BATJob: added parameter RetryStrategy_EvaluateOnExit.
  * Amazon Braket
    * Added cmdlet Add-BRKTResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-BRKTResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-BRKTResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-BRKTQuantumTask: added parameter Tag.
  * Amazon Budgets
    * Added cmdlet Get-BGTBudgetAction leveraging the DescribeBudgetAction service API.
    * Added cmdlet Get-BGTBudgetActionHistory leveraging the DescribeBudgetActionHistories service API.
    * Added cmdlet Get-BGTBudgetActionsForAccount leveraging the DescribeBudgetActionsForAccount service API.
    * Added cmdlet Get-BGTBudgetActionsForBudget leveraging the DescribeBudgetActionsForBudget service API.
    * Added cmdlet Invoke-BGTBudgetAction leveraging the ExecuteBudgetAction service API.
    * Added cmdlet New-BGTBudgetAction leveraging the CreateBudgetAction service API.
    * Added cmdlet Remove-BGTBudgetAction leveraging the DeleteBudgetAction service API.
    * Added cmdlet Update-BGTBudgetAction leveraging the UpdateBudgetAction service API.
  * Amazon CloudFront
    * Added cmdlet Get-CFDistributionsByKeyGroup leveraging the ListDistributionsByKeyGroup service API.
    * Added cmdlet Get-CFKeyGroup leveraging the GetKeyGroup service API.
    * Added cmdlet Get-CFKeyGroupConfig leveraging the GetKeyGroupConfig service API.
    * Added cmdlet Get-CFKeyGroupList leveraging the ListKeyGroups service API.
    * Added cmdlet New-CFKeyGroup leveraging the CreateKeyGroup service API.
    * Added cmdlet Remove-CFKeyGroup leveraging the DeleteKeyGroup service API.
    * Added cmdlet Update-CFKeyGroup leveraging the UpdateKeyGroup service API.
    * Modified cmdlet New-CFDistribution: added parameters TrustedKeyGroups_Enabled, TrustedKeyGroups_Item and TrustedKeyGroups_Quantity.
    * Modified cmdlet New-CFDistributionWithTag: added parameters TrustedKeyGroups_Enabled, TrustedKeyGroups_Item and TrustedKeyGroups_Quantity.
    * Modified cmdlet Update-CFDistribution: added parameters TrustedKeyGroups_Enabled, TrustedKeyGroups_Item and TrustedKeyGroups_Quantity.
  * Amazon CloudWatch Events
    * Added cmdlet Get-CWEArchive leveraging the DescribeArchive service API.
    * Added cmdlet Get-CWEArchiveList leveraging the ListArchives service API.
    * Added cmdlet Get-CWEReplay leveraging the DescribeReplay service API.
    * Added cmdlet Get-CWEReplayList leveraging the ListReplays service API.
    * Added cmdlet New-CWEArchive leveraging the CreateArchive service API.
    * Added cmdlet Remove-CWEArchive leveraging the DeleteArchive service API.
    * Added cmdlet Start-CWEReplay leveraging the StartReplay service API.
    * Added cmdlet Stop-CWEReplay leveraging the CancelReplay service API.
    * Added cmdlet Update-CWEArchive leveraging the UpdateArchive service API.
  * Amazon CodeArtifact
    * Added cmdlet Add-CAResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CAResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CAResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CADomain: added parameter Tag.
    * Modified cmdlet New-CARepository: added parameter Tag.
  * Amazon Data Lifecycle Manager
    * Modified cmdlet New-DLMLifecyclePolicy: added parameter Parameters_NoReboot.
    * Modified cmdlet Update-DLMLifecyclePolicy: added parameter Parameters_NoReboot.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters DocDbSettings_DatabaseName, DocDbSettings_DocsToInvestigate, DocDbSettings_ExtractDocId, DocDbSettings_KmsKeyId, DocDbSettings_NestingLevel, DocDbSettings_Password, DocDbSettings_Port, DocDbSettings_ServerName, DocDbSettings_Username, RedshiftSettings_CaseSensitiveName, RedshiftSettings_CompUpdate and RedshiftSettings_ExplicitId.
    * Modified cmdlet New-DMSEndpoint: added parameters DocDbSettings_DatabaseName, DocDbSettings_DocsToInvestigate, DocDbSettings_ExtractDocId, DocDbSettings_KmsKeyId, DocDbSettings_NestingLevel, DocDbSettings_Password, DocDbSettings_Port, DocDbSettings_ServerName, DocDbSettings_Username, RedshiftSettings_CaseSensitiveName, RedshiftSettings_CompUpdate, RedshiftSettings_ExplicitId and ResourceIdentifier.
    * Modified cmdlet New-DMSReplicationInstance: added parameter ResourceIdentifier.
    * Modified cmdlet New-DMSReplicationTask: added parameter ResourceIdentifier.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2AssociatedEnclaveCertificateIamRole leveraging the GetAssociatedEnclaveCertificateIamRoles service API.
    * Added cmdlet Register-EC2EnclaveCertificateIamRole leveraging the AssociateEnclaveCertificateIamRole service API.
    * Added cmdlet Unregister-EC2EnclaveCertificateIamRole leveraging the DisassociateEnclaveCertificateIamRole service API.
    * Modified cmdlet New-EC2Instance: added parameter EnclaveOptions_Enabled.
    * Modified cmdlet Add-EC2NetworkInterface: added parameter NetworkCardIndex.
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameters ClientConnectOptions_Enabled, ClientConnectOptions_LambdaFunctionArn and SelfServicePortal.
    * Modified cmdlet Edit-EC2TransitGatewayVpcAttachment: added parameter Options_ApplianceModeSupport.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameters ClientConnectOptions_Enabled, ClientConnectOptions_LambdaFunctionArn and SelfServicePortal.
    * Modified cmdlet New-EC2Fleet: added parameter CapacityRebalance_ReplacementStrategy.
    * Modified cmdlet New-EC2TransitGatewayVpcAttachment: added parameter Options_ApplianceModeSupport.
    * Modified cmdlet Request-EC2SpotFleet: added parameter CapacityRebalance_ReplacementStrategy.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Edit-ELB2TargetGroup: added parameter Matcher_GrpcCode.
    * Modified cmdlet New-ELB2TargetGroup: added parameters Matcher_GrpcCode and ProtocolVersion.
  * Amazon ElastiCache
    * Added cmdlet Edit-ECUser leveraging the ModifyUser service API.
    * Added cmdlet Edit-ECUserGroup leveraging the ModifyUserGroup service API.
    * Added cmdlet Get-ECUser leveraging the DescribeUsers service API.
    * Added cmdlet Get-ECUserGroup leveraging the DescribeUserGroups service API.
    * Added cmdlet New-ECUser leveraging the CreateUser service API.
    * Added cmdlet New-ECUserGroup leveraging the CreateUserGroup service API.
    * Added cmdlet Remove-ECUser leveraging the DeleteUser service API.
    * Added cmdlet Remove-ECUserGroup leveraging the DeleteUserGroup service API.
    * Modified cmdlet Edit-ECReplicationGroup: added parameters RemoveUserGroup, UserGroupIdsToAdd and UserGroupIdsToRemove.
    * Modified cmdlet New-ECCacheCluster: added parameters OutpostMode, PreferredOutpostArn and PreferredOutpostArnSet.
    * Modified cmdlet New-ECReplicationGroup: added parameter UserGroupId.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameters DomainEndpointOptions_CustomEndpoint, DomainEndpointOptions_CustomEndpointCertificateArn, DomainEndpointOptions_CustomEndpointEnabled, Idp_EntityId, Idp_MetadataContent, SAMLOptions_Enabled, SAMLOptions_MasterBackendRole, SAMLOptions_MasterUserName, SAMLOptions_RolesKey, SAMLOptions_SessionTimeoutMinute and SAMLOptions_SubjectKey.
    * Modified cmdlet Update-ESDomainConfig: added parameters DomainEndpointOptions_CustomEndpoint, DomainEndpointOptions_CustomEndpointCertificateArn, DomainEndpointOptions_CustomEndpointEnabled, Idp_EntityId, Idp_MetadataContent, SAMLOptions_Enabled, SAMLOptions_MasterBackendRole, SAMLOptions_MasterUserName, SAMLOptions_RolesKey, SAMLOptions_SessionTimeoutMinute and SAMLOptions_SubjectKey.
  * Amazon Elemental MediaLive
    * Added cmdlet Deny-EMLInputDeviceTransfer leveraging the RejectInputDeviceTransfer service API.
    * Added cmdlet Get-EMLInputDeviceTransferList leveraging the ListInputDeviceTransfers service API.
    * Added cmdlet Move-EMLInputDevice leveraging the TransferInputDevice service API.
    * Added cmdlet Receive-EMLInputDeviceTransfer leveraging the AcceptInputDeviceTransfer service API.
    * Added cmdlet Stop-EMLInputDeviceTransfer leveraging the CancelInputDeviceTransfer service API.
    * Modified cmdlet New-EMLChannel: added parameter CdiInputSpecification_Resolution.
    * Modified cmdlet New-EMLMultiplexProgram: added parameter StatmuxSettings_Priority.
    * Modified cmdlet Update-EMLChannel: added parameter CdiInputSpecification_Resolution.
    * Modified cmdlet Update-EMLMultiplexProgram: added parameter StatmuxSettings_Priority.
  * Amazon Elemental MediaPackage
    * Added cmdlet Update-EMPLogConfiguration leveraging the ConfigureLogs service API.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter AdMarkerPassthrough_Enabled.
  * Amazon EventBridge
    * Added cmdlet Get-EVBArchive leveraging the DescribeArchive service API.
    * Added cmdlet Get-EVBArchiveList leveraging the ListArchives service API.
    * Added cmdlet Get-EVBReplay leveraging the DescribeReplay service API.
    * Added cmdlet Get-EVBReplayList leveraging the ListReplays service API.
    * Added cmdlet New-EVBArchive leveraging the CreateArchive service API.
    * Added cmdlet Remove-EVBArchive leveraging the DeleteArchive service API.
    * Added cmdlet Start-EVBReplay leveraging the StartReplay service API.
    * Added cmdlet Stop-EVBReplay leveraging the CancelReplay service API.
    * Added cmdlet Update-EVBArchive leveraging the UpdateArchive service API.
  * Amazon Fraud Detector
    * Added cmdlet Remove-FDEntityType leveraging the DeleteEntityType service API.
    * Added cmdlet Remove-FDEventType leveraging the DeleteEventType service API.
    * Added cmdlet Remove-FDExternalModel leveraging the DeleteExternalModel service API.
    * Added cmdlet Remove-FDLabel leveraging the DeleteLabel service API.
    * Added cmdlet Remove-FDModel leveraging the DeleteModel service API.
    * Added cmdlet Remove-FDModelVersion leveraging the DeleteModelVersion service API.
    * Added cmdlet Remove-FDOutcome leveraging the DeleteOutcome service API.
    * Added cmdlet Remove-FDVariable leveraging the DeleteVariable service API.
  * Amazon Global Accelerator
    * Modified cmdlet New-GACLEndpointGroup: added parameter PortOverride.
    * Modified cmdlet Update-GACLEndpointGroup: added parameter PortOverride.
  * Amazon Glue
    * Modified cmdlet New-GLUECrawler: added parameter RecrawlPolicy_RecrawlBehavior.
    * Modified cmdlet New-GLUEMLTransform: added parameters MlUserDataEncryption_KmsKeyId, MlUserDataEncryption_MlUserDataEncryptionMode and TransformEncryption_TaskRunSecurityConfigurationName.
    * Modified cmdlet Update-GLUECrawler: added parameter RecrawlPolicy_RecrawlBehavior.
  * Amazon IAM Access Analyzer
    * Added cmdlet Start-IAMAAArchiveRule leveraging the ApplyArchiveRule service API.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWReturnShippingLabel leveraging the DescribeReturnShippingLabel service API.
    * Added cmdlet New-SNOWReturnShippingLabel leveraging the CreateReturnShippingLabel service API.
    * Added cmdlet Update-SNOWJobShipmentState leveraging the UpdateJobShipmentState service API.
  * Amazon IoT
    * Modified cmdlet Add-IOTTargetsWithJob: added parameter NamespaceId.
    * Modified cmdlet Get-IOTJobExecutionsForThingList: added parameter NamespaceId.
    * Modified cmdlet Get-IOTJobList: added parameter NamespaceId.
    * Modified cmdlet Get-IOTThingPrincipalList: added parameters MaxResult and NextToken.
    * Modified cmdlet New-IOTJob: added parameter NamespaceId.
    * Modified cmdlet Remove-IOTJob: added parameter NamespaceId.
    * Modified cmdlet Remove-IOTJobExecution: added parameter NamespaceId.
    * Modified cmdlet Update-IOTJob: added parameter NamespaceId.
  * IOTSW
    * [Breaking Change] Removed cmdlet New-IOTSWPresignedPortalUrl.
  * Amazon Kendra
    * Modified cmdlet Invoke-KNDRQuery: added parameter UserContext_Token.
    * Modified cmdlet New-KNDRDataSource: added parameter ClientToken.
    * Modified cmdlet New-KNDRFaq: added parameter ClientToken.
    * Modified cmdlet New-KNDRIndex: added parameters UserContextPolicy and UserTokenConfiguration.
    * Modified cmdlet Update-KNDRIndex: added parameters UserContextPolicy and UserTokenConfiguration.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameters Queue and SourceAccessConfiguration.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter SourceAccessConfiguration.
  * Amazon Marketplace Metering
    * Modified cmdlet Send-MMMeteringData: added parameter UsageAllocation.
  * Amazon Neptune
    * Added cmdlet Edit-NPTDBClusterEndpoint leveraging the ModifyDBClusterEndpoint service API.
    * Added cmdlet Get-NPTDBClusterEndpoint leveraging the DescribeDBClusterEndpoints service API.
    * Added cmdlet New-NPTDBClusterEndpoint leveraging the CreateDBClusterEndpoint service API.
    * Added cmdlet Remove-NPTDBClusterEndpoint leveraging the DeleteDBClusterEndpoint service API.
    * Modified cmdlet Add-NPTRoleToDBCluster: added parameter FeatureName.
    * Modified cmdlet Remove-NPTRoleFromDBCluster: added parameter FeatureName.
  * Amazon Rekognition
    * Added cmdlet Find-REKProtectiveEquipment leveraging the DetectProtectiveEquipment service API.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter MaxAllocatedStorage.
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter MaxAllocatedStorage.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter MaxAllocatedStorage.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMAppImageConfig leveraging the DescribeAppImageConfig service API.
    * Added cmdlet Get-SMAppImageConfigList leveraging the ListAppImageConfigs service API.
    * Added cmdlet Get-SMImage leveraging the DescribeImage service API.
    * Added cmdlet Get-SMImageList leveraging the ListImages service API.
    * Added cmdlet Get-SMImageVersion leveraging the DescribeImageVersion service API.
    * Added cmdlet Get-SMImageVersionList leveraging the ListImageVersions service API.
    * Added cmdlet New-SMAppImageConfig leveraging the CreateAppImageConfig service API.
    * Added cmdlet New-SMImage leveraging the CreateImage service API.
    * Added cmdlet New-SMImageVersion leveraging the CreateImageVersion service API.
    * Added cmdlet Remove-SMAppImageConfig leveraging the DeleteAppImageConfig service API.
    * Added cmdlet Remove-SMImage leveraging the DeleteImage service API.
    * Added cmdlet Remove-SMImageVersion leveraging the DeleteImageVersion service API.
    * Added cmdlet Update-SMAppImageConfig leveraging the UpdateAppImageConfig service API.
    * Added cmdlet Update-SMImage leveraging the UpdateImage service API.
    * Modified cmdlet New-SMApp: added parameter ResourceSpec_SageMakerImageVersionArn.
    * Modified cmdlet New-SMCompilationJob: added parameter Tag.
  * Amazon Service Catalog
    * Added cmdlet Get-SCProvisionedProductOutput leveraging the GetProvisionedProductOutputs service API.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Get-SES2Contact leveraging the GetContact service API.
    * Added cmdlet Get-SES2ContactCollection leveraging the ListContacts service API.
    * Added cmdlet Get-SES2ContactList leveraging the GetContactList service API.
    * Added cmdlet Get-SES2ContactListCollection leveraging the ListContactLists service API.
    * Added cmdlet New-SES2Contact leveraging the CreateContact service API.
    * Added cmdlet New-SES2ContactList leveraging the CreateContactList service API.
    * Added cmdlet Remove-SES2Contact leveraging the DeleteContact service API.
    * Added cmdlet Remove-SES2ContactList leveraging the DeleteContactList service API.
    * Added cmdlet Update-SES2Contact leveraging the UpdateContact service API.
    * Added cmdlet Update-SES2ContactList leveraging the UpdateContactList service API.
    * Modified cmdlet New-SES2ImportJob: added parameters ContactListDestination_ContactListImportAction and ContactListDestination_ContactListName.
    * Modified cmdlet Send-SES2Email: added parameters ListManagementOptions_ContactListName and ListManagementOptions_TopicName.
  * Amazon Simple Notification Service (SNS)
    * Modified cmdlet Publish-SNSMessage: added parameters MessageDeduplicationId and MessageGroupId.
  * Amazon Storage Gateway
    * Added cmdlet Update-SGSMBFileShareVisibility leveraging the UpdateSMBFileShareVisibility service API.
    * Modified cmdlet New-SGNFSFileShare: added parameter NotificationPolicy.
    * Modified cmdlet New-SGSMBFileShare: added parameters AccessBasedEnumeration and NotificationPolicy.
    * Modified cmdlet Update-SGNFSFileShare: added parameter NotificationPolicy.
    * Modified cmdlet Update-SGSMBFileShare: added parameters AccessBasedEnumeration and NotificationPolicy.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter EndpointDetails_SecurityGroupId.
    * Modified cmdlet Update-TFRServer: added parameter EndpointDetails_SecurityGroupId.
  * Amazon WorkMail
    * Added cmdlet New-WMOrganization leveraging the CreateOrganization service API.
    * Added cmdlet Remove-WMOrganization leveraging the DeleteOrganization service API.
  * Amazon X-Ray
    * Added cmdlet Get-XRInsight leveraging the GetInsight service API.
    * Added cmdlet Get-XRInsightEvent leveraging the GetInsightEvents service API.
    * Added cmdlet Get-XRInsightImpactGraph leveraging the GetInsightImpactGraph service API.
    * Added cmdlet Get-XRInsightSummary leveraging the GetInsightSummaries service API.
    * Modified cmdlet Get-XRTimeSeriesServiceStatistic: added parameter ForecastStatistic.
    * Modified cmdlet New-XRGroup: added parameter InsightsConfiguration_NotificationsEnabled.
    * Modified cmdlet Update-XRGroup: added parameter InsightsConfiguration_NotificationsEnabled.

### 4.1.3.0 (2020-10-29)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.45.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter AutoBranchCreationConfig_EnablePerformanceMode.
    * Modified cmdlet New-AMPBranch: added parameter EnablePerformanceMode.
    * Modified cmdlet Update-AMPApp: added parameter AutoBranchCreationConfig_EnablePerformanceMode.
    * Modified cmdlet Update-AMPBranch: added parameter EnablePerformanceMode.
  * Amazon API Gateway
    * Modified cmdlet New-AGRestApi: added parameter DisableExecuteApiEndpoint.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameter IncrementalPullConfig_DatetimeTypeFieldName.
    * Modified cmdlet Update-AFFlow: added parameter IncrementalPullConfig_DatetimeTypeFieldName.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter RetryStrategy_EvaluateOnExit.
    * Modified cmdlet Submit-BATJob: added parameter RetryStrategy_EvaluateOnExit.
  * Amazon Budgets
    * Added cmdlet Get-BGTBudgetAction leveraging the DescribeBudgetAction service API.
    * Added cmdlet Get-BGTBudgetActionHistory leveraging the DescribeBudgetActionHistories service API.
    * Added cmdlet Get-BGTBudgetActionsForAccount leveraging the DescribeBudgetActionsForAccount service API.
    * Added cmdlet Get-BGTBudgetActionsForBudget leveraging the DescribeBudgetActionsForBudget service API.
    * Added cmdlet Invoke-BGTBudgetAction leveraging the ExecuteBudgetAction service API.
    * Added cmdlet New-BGTBudgetAction leveraging the CreateBudgetAction service API.
    * Added cmdlet Remove-BGTBudgetAction leveraging the DeleteBudgetAction service API.
    * Added cmdlet Update-BGTBudgetAction leveraging the UpdateBudgetAction service API.
  * Amazon CloudFront
    * Added cmdlet Get-CFDistributionsByKeyGroup leveraging the ListDistributionsByKeyGroup service API.
    * Added cmdlet Get-CFKeyGroup leveraging the GetKeyGroup service API.
    * Added cmdlet Get-CFKeyGroupConfig leveraging the GetKeyGroupConfig service API.
    * Added cmdlet Get-CFKeyGroupList leveraging the ListKeyGroups service API.
    * Added cmdlet New-CFKeyGroup leveraging the CreateKeyGroup service API.
    * Added cmdlet Remove-CFKeyGroup leveraging the DeleteKeyGroup service API.
    * Added cmdlet Update-CFKeyGroup leveraging the UpdateKeyGroup service API.
    * Modified cmdlet New-CFDistribution: added parameters TrustedKeyGroups_Enabled, TrustedKeyGroups_Item and TrustedKeyGroups_Quantity.
    * Modified cmdlet New-CFDistributionWithTag: added parameters TrustedKeyGroups_Enabled, TrustedKeyGroups_Item and TrustedKeyGroups_Quantity.
    * Modified cmdlet Update-CFDistribution: added parameters TrustedKeyGroups_Enabled, TrustedKeyGroups_Item and TrustedKeyGroups_Quantity.
  * Amazon CodeArtifact
    * Added cmdlet Add-CAResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CAResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CAResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CADomain: added parameter Tag.
    * Modified cmdlet New-CARepository: added parameter Tag.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters RedshiftSettings_CaseSensitiveName, RedshiftSettings_CompUpdate and RedshiftSettings_ExplicitId.
    * Modified cmdlet New-DMSEndpoint: added parameters RedshiftSettings_CaseSensitiveName, RedshiftSettings_CompUpdate, RedshiftSettings_ExplicitId and ResourceIdentifier.
    * Modified cmdlet New-DMSReplicationInstance: added parameter ResourceIdentifier.
    * Modified cmdlet New-DMSReplicationTask: added parameter ResourceIdentifier.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2AssociatedEnclaveCertificateIamRole leveraging the GetAssociatedEnclaveCertificateIamRoles service API.
    * Added cmdlet Register-EC2EnclaveCertificateIamRole leveraging the AssociateEnclaveCertificateIamRole service API.
    * Added cmdlet Unregister-EC2EnclaveCertificateIamRole leveraging the DisassociateEnclaveCertificateIamRole service API.
    * Modified cmdlet New-EC2Instance: added parameter EnclaveOptions_Enabled.
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameter SelfServicePortal.
    * Modified cmdlet Edit-EC2TransitGatewayVpcAttachment: added parameter Options_ApplianceModeSupport.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter SelfServicePortal.
    * Modified cmdlet New-EC2TransitGatewayVpcAttachment: added parameter Options_ApplianceModeSupport.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Edit-ELB2TargetGroup: added parameter Matcher_GrpcCode.
    * Modified cmdlet New-ELB2TargetGroup: added parameters Matcher_GrpcCode and ProtocolVersion.
  * Amazon ElastiCache
    * Added cmdlet Edit-ECUser leveraging the ModifyUser service API.
    * Added cmdlet Edit-ECUserGroup leveraging the ModifyUserGroup service API.
    * Added cmdlet Get-ECUser leveraging the DescribeUsers service API.
    * Added cmdlet Get-ECUserGroup leveraging the DescribeUserGroups service API.
    * Added cmdlet New-ECUser leveraging the CreateUser service API.
    * Added cmdlet New-ECUserGroup leveraging the CreateUserGroup service API.
    * Added cmdlet Remove-ECUser leveraging the DeleteUser service API.
    * Added cmdlet Remove-ECUserGroup leveraging the DeleteUserGroup service API.
    * Modified cmdlet Edit-ECReplicationGroup: added parameters RemoveUserGroup, UserGroupIdsToAdd and UserGroupIdsToRemove.
    * Modified cmdlet New-ECCacheCluster: added parameters OutpostMode, PreferredOutpostArn and PreferredOutpostArnSet.
    * Modified cmdlet New-ECReplicationGroup: added parameter UserGroupId.
  * Amazon Elemental MediaLive
    * Added cmdlet Deny-EMLInputDeviceTransfer leveraging the RejectInputDeviceTransfer service API.
    * Added cmdlet Get-EMLInputDeviceTransferList leveraging the ListInputDeviceTransfers service API.
    * Added cmdlet Move-EMLInputDevice leveraging the TransferInputDevice service API.
    * Added cmdlet Receive-EMLInputDeviceTransfer leveraging the AcceptInputDeviceTransfer service API.
    * Added cmdlet Stop-EMLInputDeviceTransfer leveraging the CancelInputDeviceTransfer service API.
    * Modified cmdlet New-EMLChannel: added parameter CdiInputSpecification_Resolution.
    * Modified cmdlet New-EMLMultiplexProgram: added parameter StatmuxSettings_Priority.
    * Modified cmdlet Update-EMLChannel: added parameter CdiInputSpecification_Resolution.
    * Modified cmdlet Update-EMLMultiplexProgram: added parameter StatmuxSettings_Priority.
  * Amazon Elemental MediaPackage
    * Added cmdlet Update-EMPLogConfiguration leveraging the ConfigureLogs service API.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter AdMarkerPassthrough_Enabled.
  * Amazon Global Accelerator
    * Modified cmdlet New-GACLEndpointGroup: added parameter PortOverride.
    * Modified cmdlet Update-GACLEndpointGroup: added parameter PortOverride.
  * Amazon Glue
    * Modified cmdlet New-GLUECrawler: added parameter RecrawlPolicy_RecrawlBehavior.
    * Modified cmdlet New-GLUEMLTransform: added parameters MlUserDataEncryption_KmsKeyId, MlUserDataEncryption_MlUserDataEncryptionMode and TransformEncryption_TaskRunSecurityConfigurationName.
    * Modified cmdlet Update-GLUECrawler: added parameter RecrawlPolicy_RecrawlBehavior.
  * Amazon IAM Access Analyzer
    * Added cmdlet Start-IAMAAArchiveRule leveraging the ApplyArchiveRule service API.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWReturnShippingLabel leveraging the DescribeReturnShippingLabel service API.
    * Added cmdlet New-SNOWReturnShippingLabel leveraging the CreateReturnShippingLabel service API.
    * Added cmdlet Update-SNOWJobShipmentState leveraging the UpdateJobShipmentState service API.
  * Amazon IoT
    * Modified cmdlet Add-IOTTargetsWithJob: added parameter NamespaceId.
    * Modified cmdlet Get-IOTJobExecutionsForThingList: added parameter NamespaceId.
    * Modified cmdlet Get-IOTJobList: added parameter NamespaceId.
    * Modified cmdlet New-IOTJob: added parameter NamespaceId.
    * Modified cmdlet Remove-IOTJob: added parameter NamespaceId.
    * Modified cmdlet Remove-IOTJobExecution: added parameter NamespaceId.
    * Modified cmdlet Update-IOTJob: added parameter NamespaceId.
  * Amazon Kendra
    * Modified cmdlet New-KNDRDataSource: added parameter ClientToken.
    * Modified cmdlet New-KNDRFaq: added parameter ClientToken.
  * Amazon Neptune
    * Added cmdlet Edit-NPTDBClusterEndpoint leveraging the ModifyDBClusterEndpoint service API.
    * Added cmdlet Get-NPTDBClusterEndpoint leveraging the DescribeDBClusterEndpoints service API.
    * Added cmdlet New-NPTDBClusterEndpoint leveraging the CreateDBClusterEndpoint service API.
    * Added cmdlet Remove-NPTDBClusterEndpoint leveraging the DeleteDBClusterEndpoint service API.
    * Modified cmdlet Add-NPTRoleToDBCluster: added parameter FeatureName.
    * Modified cmdlet Remove-NPTRoleFromDBCluster: added parameter FeatureName.
  * Amazon Rekognition
    * Added cmdlet Find-REKProtectiveEquipment leveraging the DetectProtectiveEquipment service API.
  * Amazon Relational Database Service
    * Modified cmdlet Restore-RDSDBInstanceFromS3: added parameter MaxAllocatedStorage.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter MaxAllocatedStorage.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMAppImageConfig leveraging the DescribeAppImageConfig service API.
    * Added cmdlet Get-SMAppImageConfigList leveraging the ListAppImageConfigs service API.
    * Added cmdlet Get-SMImage leveraging the DescribeImage service API.
    * Added cmdlet Get-SMImageList leveraging the ListImages service API.
    * Added cmdlet Get-SMImageVersion leveraging the DescribeImageVersion service API.
    * Added cmdlet Get-SMImageVersionList leveraging the ListImageVersions service API.
    * Added cmdlet New-SMAppImageConfig leveraging the CreateAppImageConfig service API.
    * Added cmdlet New-SMImage leveraging the CreateImage service API.
    * Added cmdlet New-SMImageVersion leveraging the CreateImageVersion service API.
    * Added cmdlet Remove-SMAppImageConfig leveraging the DeleteAppImageConfig service API.
    * Added cmdlet Remove-SMImage leveraging the DeleteImage service API.
    * Added cmdlet Remove-SMImageVersion leveraging the DeleteImageVersion service API.
    * Added cmdlet Update-SMAppImageConfig leveraging the UpdateAppImageConfig service API.
    * Added cmdlet Update-SMImage leveraging the UpdateImage service API.
    * Modified cmdlet New-SMApp: added parameter ResourceSpec_SageMakerImageVersionArn.
    * Modified cmdlet New-SMCompilationJob: added parameter Tag.
  * Amazon Service Catalog
    * Added cmdlet Get-SCProvisionedProductOutput leveraging the GetProvisionedProductOutputs service API.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Get-SES2Contact leveraging the GetContact service API.
    * Added cmdlet Get-SES2ContactCollection leveraging the ListContacts service API.
    * Added cmdlet Get-SES2ContactList leveraging the GetContactList service API.
    * Added cmdlet Get-SES2ContactListCollection leveraging the ListContactLists service API.
    * Added cmdlet New-SES2Contact leveraging the CreateContact service API.
    * Added cmdlet New-SES2ContactList leveraging the CreateContactList service API.
    * Added cmdlet Remove-SES2Contact leveraging the DeleteContact service API.
    * Added cmdlet Remove-SES2ContactList leveraging the DeleteContactList service API.
    * Added cmdlet Update-SES2Contact leveraging the UpdateContact service API.
    * Added cmdlet Update-SES2ContactList leveraging the UpdateContactList service API.
    * Modified cmdlet New-SES2ImportJob: added parameters ContactListDestination_ContactListImportAction and ContactListDestination_ContactListName.
    * Modified cmdlet Send-SES2Email: added parameters ListManagementOptions_ContactListName and ListManagementOptions_TopicName.
  * Amazon Simple Notification Service (SNS)
    * Modified cmdlet Publish-SNSMessage: added parameters MessageDeduplicationId and MessageGroupId.
  * Amazon Storage Gateway
    * Added cmdlet Update-SGSMBFileShareVisibility leveraging the UpdateSMBFileShareVisibility service API.
    * Modified cmdlet New-SGNFSFileShare: added parameter NotificationPolicy.
    * Modified cmdlet New-SGSMBFileShare: added parameters AccessBasedEnumeration and NotificationPolicy.
    * Modified cmdlet Update-SGNFSFileShare: added parameter NotificationPolicy.
    * Modified cmdlet Update-SGSMBFileShare: added parameters AccessBasedEnumeration and NotificationPolicy.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter EndpointDetails_SecurityGroupId.
    * Modified cmdlet Update-TFRServer: added parameter EndpointDetails_SecurityGroupId.
  * Amazon WorkMail
    * Added cmdlet New-WMOrganization leveraging the CreateOrganization service API.
    * Added cmdlet Remove-WMOrganization leveraging the DeleteOrganization service API.
  * Amazon X-Ray
    * Modified cmdlet New-XRGroup: added parameter InsightsConfiguration_NotificationsEnabled.
    * Modified cmdlet Update-XRGroup: added parameter InsightsConfiguration_NotificationsEnabled.

### 4.1.2.0 (2020-10-06)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.31.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon Single Sign-On Admin. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSOADMN and can be listed using the command 'Get-AWSCmdletName -Service SSOADMN'.
  * Amazon Batch
    * Added cmdlet Add-BATResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-BATResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-BATResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-BATComputeEnvironment: added parameter Tag.
    * Modified cmdlet New-BATJobQueue: added parameter Tag.
    * Modified cmdlet Register-BATJobDefinition: added parameter Tag.
    * Modified cmdlet Submit-BATJob: added parameter Tag.
  * Amazon Cloud Map
    * Modified cmdlet Find-SDInstance: added parameter OptionalParameter.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters IBMDb2Settings_CurrentLsn, IBMDb2Settings_MaxKBytesPerRead, IBMDb2Settings_SetDataCaptureChange, MicrosoftSQLServerSettings_BcpPacketSize, MicrosoftSQLServerSettings_ControlTablesFileGroup, MicrosoftSQLServerSettings_ReadBackupOnly, MicrosoftSQLServerSettings_SafeguardPolicy, MicrosoftSQLServerSettings_UseBcpFullLoad, MySQLSettings_AfterConnectScript, MySQLSettings_EventsPollInterval, MySQLSettings_MaxFileSize, MySQLSettings_ParallelLoadThread, MySQLSettings_ServerTimezone, MySQLSettings_TargetDbType, OracleSettings_AccessAlternateDirectly, OracleSettings_AdditionalArchivedLogDestId, OracleSettings_AddSupplementalLogging, OracleSettings_AllowSelectNestedTable, OracleSettings_ArchivedLogDestId, OracleSettings_ArchivedLogsOnly, OracleSettings_CharLengthSemantic, OracleSettings_DirectPathNoLog, OracleSettings_DirectPathParallelLoad, OracleSettings_EnableHomogenousTablespace, OracleSettings_FailTasksOnLobTruncation, OracleSettings_NumberDatatypeScale, OracleSettings_OraclePathPrefix, OracleSettings_ParallelAsmReadThread, OracleSettings_ReadAheadBlock, OracleSettings_ReadTableSpaceName, OracleSettings_ReplacePathPrefix, OracleSettings_RetryInterval, OracleSettings_UseAlternateFolderForOnline, OracleSettings_UsePathPrefix, PostgreSQLSettings_AfterConnectScript, PostgreSQLSettings_CaptureDdl, PostgreSQLSettings_DdlArtifactsSchema, PostgreSQLSettings_ExecuteTimeout, PostgreSQLSettings_FailTasksOnLobTruncation, PostgreSQLSettings_MaxFileSize, PostgreSQLSettings_SlotName, S3Settings_DatePartitionDelimiter, S3Settings_DatePartitionEnabled and S3Settings_DatePartitionSequence.
    * Modified cmdlet New-DMSEndpoint: added parameters IBMDb2Settings_CurrentLsn, IBMDb2Settings_MaxKBytesPerRead, IBMDb2Settings_SetDataCaptureChange, MicrosoftSQLServerSettings_BcpPacketSize, MicrosoftSQLServerSettings_ControlTablesFileGroup, MicrosoftSQLServerSettings_ReadBackupOnly, MicrosoftSQLServerSettings_SafeguardPolicy, MicrosoftSQLServerSettings_UseBcpFullLoad, MySQLSettings_AfterConnectScript, MySQLSettings_EventsPollInterval, MySQLSettings_MaxFileSize, MySQLSettings_ParallelLoadThread, MySQLSettings_ServerTimezone, MySQLSettings_TargetDbType, OracleSettings_AccessAlternateDirectly, OracleSettings_AdditionalArchivedLogDestId, OracleSettings_AddSupplementalLogging, OracleSettings_AllowSelectNestedTable, OracleSettings_ArchivedLogDestId, OracleSettings_ArchivedLogsOnly, OracleSettings_CharLengthSemantic, OracleSettings_DirectPathNoLog, OracleSettings_DirectPathParallelLoad, OracleSettings_EnableHomogenousTablespace, OracleSettings_FailTasksOnLobTruncation, OracleSettings_NumberDatatypeScale, OracleSettings_OraclePathPrefix, OracleSettings_ParallelAsmReadThread, OracleSettings_ReadAheadBlock, OracleSettings_ReadTableSpaceName, OracleSettings_ReplacePathPrefix, OracleSettings_RetryInterval, OracleSettings_UseAlternateFolderForOnline, OracleSettings_UsePathPrefix, PostgreSQLSettings_AfterConnectScript, PostgreSQLSettings_CaptureDdl, PostgreSQLSettings_DdlArtifactsSchema, PostgreSQLSettings_ExecuteTimeout, PostgreSQLSettings_FailTasksOnLobTruncation, PostgreSQLSettings_MaxFileSize, PostgreSQLSettings_SlotName, S3Settings_DatePartitionDelimiter, S3Settings_DatePartitionEnabled and S3Settings_DatePartitionSequence.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet New-ELB2Listener: added parameter Tag.
    * Modified cmdlet New-ELB2Rule: added parameter Tag.
    * Modified cmdlet New-ELB2TargetGroup: added parameter Tag.
  * Amazon Glue
    * Modified cmdlet Get-GLUEPlan: added parameter AdditionalPlanOptionsMap.
  * Amazon Kinesis Analytics V2
    * Modified cmdlet Stop-KINA2Application: added parameter ForceStop.
  * Amazon Personalize Events
    * Added cmdlet Write-PERSEItem leveraging the PutItems service API.
    * Added cmdlet Write-PERSEUser leveraging the PutUsers service API.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstance: added parameter NcharCharacterSetName.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter AppNetworkAccessType.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3BucketOwnershipControl leveraging the GetBucketOwnershipControls service API.
    * Added cmdlet Remove-S3BucketOwnershipControl leveraging the DeleteBucketOwnershipControls service API.
    * Added cmdlet Write-S3BucketOwnershipControl leveraging the PutBucketOwnershipControls service API.

### 4.1.1.0 (2020-09-30)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.27.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameters MutualTlsAuthentication_TruststoreUri and MutualTlsAuthentication_TruststoreVersion.
  * Amazon API Gateway V2
    * Added cmdlet Reset-AG2AuthorizersCache leveraging the ResetAuthorizersCache service API.
    * Modified cmdlet New-AG2Api: added parameter DisableExecuteApiEndpoint.
    * Modified cmdlet New-AG2Authorizer: added parameters AuthorizerPayloadFormatVersion and EnableSimpleResponse.
    * Modified cmdlet New-AG2DomainName: added parameters MutualTlsAuthentication_TruststoreUri and MutualTlsAuthentication_TruststoreVersion.
    * Modified cmdlet New-AG2Integration: added parameter IntegrationSubtype.
    * Modified cmdlet Update-AG2Api: added parameter DisableExecuteApiEndpoint.
    * Modified cmdlet Update-AG2Authorizer: added parameters AuthorizerPayloadFormatVersion and EnableSimpleResponse.
    * Modified cmdlet Update-AG2DomainName: added parameters MutualTlsAuthentication_TruststoreUri and MutualTlsAuthentication_TruststoreVersion.
    * Modified cmdlet Update-AG2Integration: added parameter IntegrationSubtype.
  * Amazon Appflow. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AF and can be listed using the command 'Get-AWSCmdletName -Service AF'.
  * Amazon Backup
    * Modified cmdlet New-BAKBackupPlan: added parameter BackupPlan_AdvancedBackupSetting.
    * Modified cmdlet Start-BAKBackupJob: added parameter BackupOption.
    * Modified cmdlet Update-BAKBackupPlan: added parameter BackupPlan_AdvancedBackupSetting.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameters ContainerProperties_ExecutionRoleArn, ContainerProperties_Secret, LinuxParameters_InitProcessEnabled, LinuxParameters_MaxSwap, LinuxParameters_SharedMemorySize, LinuxParameters_Swappiness, LinuxParameters_Tmpf, LogConfiguration_LogDriver, LogConfiguration_Option and LogConfiguration_SecretOption.
  * Amazon CloudFront
    * Added cmdlet Get-CFDistributionsByRealtimeLogConfig leveraging the ListDistributionsByRealtimeLogConfig service API.
    * Added cmdlet Get-CFMonitoringSubscription leveraging the GetMonitoringSubscription service API.
    * Added cmdlet Get-CFRealtimeLogConfig leveraging the GetRealtimeLogConfig service API.
    * Added cmdlet Get-CFRealtimeLogConfigList leveraging the ListRealtimeLogConfigs service API.
    * Added cmdlet New-CFMonitoringSubscription leveraging the CreateMonitoringSubscription service API.
    * Added cmdlet New-CFRealtimeLogConfig leveraging the CreateRealtimeLogConfig service API.
    * Added cmdlet Remove-CFMonitoringSubscription leveraging the DeleteMonitoringSubscription service API.
    * Added cmdlet Remove-CFRealtimeLogConfig leveraging the DeleteRealtimeLogConfig service API.
    * Added cmdlet Update-CFRealtimeLogConfig leveraging the UpdateRealtimeLogConfig service API.
    * Modified cmdlet New-CFCachePolicy: added parameter ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli.
    * Modified cmdlet New-CFDistribution: added parameter DefaultCacheBehavior_RealtimeLogConfigArn.
    * Modified cmdlet New-CFDistributionWithTag: added parameter DefaultCacheBehavior_RealtimeLogConfigArn.
    * Modified cmdlet Update-CFCachePolicy: added parameter ParametersInCacheKeyAndForwardedToOrigin_EnableAcceptEncodingBrotli.
    * Modified cmdlet Update-CFDistribution: added parameter DefaultCacheBehavior_RealtimeLogConfigArn.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter RunConfig_ActiveTracing.
    * Modified cmdlet Update-CWSYNCanary: added parameter RunConfig_ActiveTracing.
  * Amazon CodeBuild
    * Modified cmdlet Get-CBTestCase: added parameter Filter_Keyword.
    * Modified cmdlet Remove-CBReportGroup: added parameter DeleteReport.
  * Amazon CodeGuru Reviewer
    * Added cmdlet New-CGRCodeReview leveraging the CreateCodeReview service API.
  * Amazon Comprehend
    * Added cmdlet Find-COMPPiiEntity leveraging the DetectPiiEntities service API.
    * Added cmdlet Get-COMPPiiEntitiesDetectionJob leveraging the DescribePiiEntitiesDetectionJob service API.
    * Added cmdlet Get-COMPPiiEntitiesDetectionJobList leveraging the ListPiiEntitiesDetectionJobs service API.
    * Added cmdlet Start-COMPPiiEntitiesDetectionJob leveraging the StartPiiEntitiesDetectionJob service API.
    * Added cmdlet Stop-COMPPiiEntitiesDetectionJob leveraging the StopPiiEntitiesDetectionJob service API.
    * Modified cmdlet New-COMPDocumentClassifier: added parameters InputDataConfig_AugmentedManifest and InputDataConfig_DataFormat.
    * Modified cmdlet New-COMPEntityRecognizer: added parameters InputDataConfig_AugmentedManifest and InputDataConfig_DataFormat.
  * Amazon Connect Service
    * Added cmdlet Disconnect-CONNRoutingProfileQueue leveraging the DisassociateRoutingProfileQueues service API.
    * Added cmdlet Get-CONNContactFlow leveraging the DescribeContactFlow service API.
    * Added cmdlet Get-CONNPromptList leveraging the ListPrompts service API.
    * Added cmdlet Get-CONNRoutingProfile leveraging the DescribeRoutingProfile service API.
    * Added cmdlet Get-CONNRoutingProfileQueueList leveraging the ListRoutingProfileQueues service API.
    * Added cmdlet Join-CONNRoutingProfileQueue leveraging the AssociateRoutingProfileQueues service API.
    * Added cmdlet New-CONNContactFlow leveraging the CreateContactFlow service API.
    * Added cmdlet New-CONNRoutingProfile leveraging the CreateRoutingProfile service API.
    * Added cmdlet Update-CONNContactFlowContent leveraging the UpdateContactFlowContent service API.
    * Added cmdlet Update-CONNContactFlowName leveraging the UpdateContactFlowName service API.
    * Added cmdlet Update-CONNRoutingProfileConcurrency leveraging the UpdateRoutingProfileConcurrency service API.
    * Added cmdlet Update-CONNRoutingProfileDefaultOutboundQueue leveraging the UpdateRoutingProfileDefaultOutboundQueue service API.
    * Added cmdlet Update-CONNRoutingProfileName leveraging the UpdateRoutingProfileName service API.
    * Added cmdlet Update-CONNRoutingProfileQueue leveraging the UpdateRoutingProfileQueues service API.
  * Amazon Cost Explorer
    * Added cmdlet Get-CEAnomaly leveraging the GetAnomalies service API.
    * Added cmdlet Get-CEAnomalyMonitor leveraging the GetAnomalyMonitors service API.
    * Added cmdlet Get-CEAnomalySubscription leveraging the GetAnomalySubscriptions service API.
    * Added cmdlet New-CEAnomalyMonitor leveraging the CreateAnomalyMonitor service API.
    * Added cmdlet New-CEAnomalySubscription leveraging the CreateAnomalySubscription service API.
    * Added cmdlet Remove-CEAnomalyMonitor leveraging the DeleteAnomalyMonitor service API.
    * Added cmdlet Remove-CEAnomalySubscription leveraging the DeleteAnomalySubscription service API.
    * Added cmdlet Set-CEAnomalyFeedback leveraging the ProvideAnomalyFeedback service API.
    * Added cmdlet Update-CEAnomalyMonitor leveraging the UpdateAnomalyMonitor service API.
    * Added cmdlet Update-CEAnomalySubscription leveraging the UpdateAnomalySubscription service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters KafkaSettings_IncludeNullAndEmpty, KafkaSettings_MessageMaxByte and KinesisSettings_IncludeNullAndEmpty.
    * Modified cmdlet New-DMSEndpoint: added parameters KafkaSettings_IncludeNullAndEmpty, KafkaSettings_MessageMaxByte and KinesisSettings_IncludeNullAndEmpty.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationS3: added parameter AgentArn.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet New-DOCDBCluster: added parameter PreSignedUrl.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2TransitGateway leveraging the ModifyTransitGateway service API.
    * Added cmdlet Edit-EC2TransitGatewayPrefixListReference leveraging the ModifyTransitGatewayPrefixListReference service API.
    * Added cmdlet Edit-EC2VpnConnectionOption leveraging the ModifyVpnConnectionOptions service API.
    * Added cmdlet Get-EC2TransitGatewayPrefixListReference leveraging the GetTransitGatewayPrefixListReferences service API.
    * Added cmdlet New-EC2TransitGatewayPrefixListReference leveraging the CreateTransitGatewayPrefixListReference service API.
    * Added cmdlet Remove-EC2TransitGatewayPrefixListReference leveraging the DeleteTransitGatewayPrefixListReference service API.
    * Modified cmdlet Edit-EC2Fleet: added parameter LaunchTemplateConfig.
    * Modified cmdlet Edit-EC2SpotFleetRequest: added parameter LaunchTemplateConfig.
    * Modified cmdlet Edit-EC2VpnTunnelOption: added parameters TunnelOptions_DPDTimeoutAction and TunnelOptions_StartupAction.
    * Modified cmdlet New-EC2VpnConnection: added parameters Options_LocalIpv4NetworkCidr, Options_LocalIpv6NetworkCidr, Options_RemoteIpv4NetworkCidr and Options_RemoteIpv6NetworkCidr.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter KubernetesNetworkConfig_ServiceIpv4Cidr.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet New-ELB2LoadBalancer: added parameter CustomerOwnedIpv4Pool.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMRNotebookExecution leveraging the DescribeNotebookExecution service API.
    * Added cmdlet Get-EMRNotebookExecutionList leveraging the ListNotebookExecutions service API.
    * Added cmdlet Start-EMRNotebookExecution leveraging the StartNotebookExecution service API.
    * Added cmdlet Stop-EMRNotebookExecution leveraging the StopNotebookExecution service API.
    * Modified cmdlet Start-EMRJobFlow: added parameter PlacementGroupConfig.
  * Amazon Elemental MediaConnect
    * Added cmdlet Get-EMCNOffering leveraging the DescribeOffering service API.
    * Added cmdlet Get-EMCNOfferingList leveraging the ListOfferings service API.
    * Added cmdlet Get-EMCNReservation leveraging the DescribeReservation service API.
    * Added cmdlet Get-EMCNReservationList leveraging the ListReservations service API.
    * Added cmdlet New-EMCNOffering leveraging the PurchaseOffering service API.
  * Amazon Elemental MediaLive
    * Added cmdlet Remove-EMLResourceBatch leveraging the BatchDelete service API.
    * Added cmdlet Start-EMLResourceBatch leveraging the BatchStart service API.
    * Added cmdlet Stop-EMLResourceBatch leveraging the BatchStop service API.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLGameServerInstance leveraging the DescribeGameServerInstances service API.
    * [Breaking Change] Modified cmdlet Register-GMLGameServer: removed parameters CustomSortKey and Tag.
    * [Breaking Change] Modified cmdlet Update-GMLGameServer: removed parameter CustomSortKey.
  * Amazon Glue
    * Added cmdlet Get-GLUEPartitionIndex leveraging the GetPartitionIndexes service API.
    * Added cmdlet Update-GLUEPartitionBatch leveraging the BatchUpdatePartition service API.
    * Modified cmdlet New-GLUETable: added parameter PartitionIndex.
  * Amazon Greengrass
    * Added cmdlet Get-GGThingRuntimeConfiguration leveraging the GetThingRuntimeConfiguration service API.
    * Added cmdlet Update-GGThingRuntimeConfiguration leveraging the UpdateThingRuntimeConfiguration service API.
  * Amazon Interactive Video Service
    * Added cmdlet Get-IVSPlaybackKeyPair leveraging the GetPlaybackKeyPair service API.
    * Added cmdlet Get-IVSPlaybackKeyPairList leveraging the ListPlaybackKeyPairs service API.
    * Added cmdlet Import-IVSPlaybackKeyPair leveraging the ImportPlaybackKeyPair service API.
    * Added cmdlet Remove-IVSPlaybackKeyPair leveraging the DeletePlaybackKeyPair service API.
    * Modified cmdlet New-IVSChannel: added parameter Authorized.
    * Modified cmdlet Update-IVSChannel: added parameter Authorized.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameters Timestamp_Unit, Timestamp_Value, Timestream_DatabaseName, Timestream_Dimension, Timestream_RoleArn and Timestream_TableName.
    * Modified cmdlet Set-IOTTopicRule: added parameters Timestamp_Unit, Timestamp_Value, Timestream_DatabaseName, Timestream_Dimension, Timestream_RoleArn and Timestream_TableName.
  * Amazon IoT SiteWise
    * Added cmdlet New-IOTSWPresignedPortalUrl leveraging the CreatePresignedPortalUrl service API.
    * Modified cmdlet Get-IOTSWAccessPolicyList: added parameter IamArn.
    * Modified cmdlet Get-IOTSWAssociatedAssetList: added parameter TraversalDirection.
    * Modified cmdlet New-IOTSWAccessPolicy: added parameter IamUser_Arn.
    * Modified cmdlet New-IOTSWPortal: added parameter PortalAuthMode.
    * Modified cmdlet Update-IOTSWAccessPolicy: added parameter IamUser_Arn.
  * Amazon Kendra
    * Modified cmdlet New-KNDRFaq: added parameter FileFormat.
  * Amazon Managed Blockchain
    * Modified cmdlet New-MBCNode: added parameter NodeConfiguration_StateDB.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Get-MSKScramSecretList leveraging the ListScramSecrets service API.
    * Added cmdlet Register-MSKAssociateScramSecret leveraging the BatchAssociateScramSecret service API.
    * Added cmdlet Remove-MSKConfiguration leveraging the DeleteConfiguration service API.
    * Added cmdlet Unregister-MSKDisassociateScramSecret leveraging the BatchDisassociateScramSecret service API.
    * Added cmdlet Update-MSKConfiguration leveraging the UpdateConfiguration service API.
    * Modified cmdlet New-MSKCluster: added parameter Scram_Enabled.
  * Amazon Organizations
    * Modified cmdlet New-ORGAccount: added parameter Tag.
    * Modified cmdlet New-ORGAccountInvitation: added parameter Tag.
    * Modified cmdlet New-ORGGovCloudAccount: added parameter Tag.
    * Modified cmdlet New-ORGOrganizationalUnit: added parameter Tag.
    * Modified cmdlet New-ORGPolicy: added parameter Tag.
  * Amazon Pinpoint
    * Modified cmdlet New-PINJourney: added parameters Dimensions_Attribute, Dimensions_Metric, EventFilter_FilterType, EventStartCondition_SegmentId, EventType_DimensionType and EventType_Value.
    * Modified cmdlet Update-PINApplicationSettingList: added parameter WriteApplicationSettingsRequest_EventTaggingEnabled.
    * Modified cmdlet Update-PINJourney: added parameters Dimensions_Attribute, Dimensions_Metric, EventFilter_FilterType, EventStartCondition_SegmentId, EventType_DimensionType and EventType_Value.
  * Amazon QuickSight
    * Modified cmdlet New-QSAccountCustomization: added parameter Tag.
  * Amazon Redshift Data API Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix RSD and can be listed using the command 'Get-AWSCmdletName -Service RSD'.
  * Amazon Route 53 Resolver
    * Added cmdlet Add-R53RResolverQueryLogConfigAssociation leveraging the AssociateResolverQueryLogConfig service API.
    * Added cmdlet Get-R53RResolverQueryLogConfig leveraging the GetResolverQueryLogConfig service API.
    * Added cmdlet Get-R53RResolverQueryLogConfigAssociation leveraging the GetResolverQueryLogConfigAssociation service API.
    * Added cmdlet Get-R53RResolverQueryLogConfigAssociationList leveraging the ListResolverQueryLogConfigAssociations service API.
    * Added cmdlet Get-R53RResolverQueryLogConfigList leveraging the ListResolverQueryLogConfigs service API.
    * Added cmdlet Get-R53RResolverQueryLogConfigPolicy leveraging the GetResolverQueryLogConfigPolicy service API.
    * Added cmdlet New-R53RResolverQueryLogConfig leveraging the CreateResolverQueryLogConfig service API.
    * Added cmdlet Remove-R53RResolverQueryLogConfig leveraging the DeleteResolverQueryLogConfig service API.
    * Added cmdlet Remove-R53RResolverQueryLogConfigAssociation leveraging the DisassociateResolverQueryLogConfig service API.
    * Added cmdlet Write-R53RResolverQueryLogConfigPolicy leveraging the PutResolverQueryLogConfigPolicy service API.
  * Amazon S3 Control
    * Added cmdlet Get-S3CBucket leveraging the GetBucket service API.
    * Added cmdlet Get-S3CBucketLifecycleConfiguration leveraging the GetBucketLifecycleConfiguration service API.
    * Added cmdlet Get-S3CBucketPolicy leveraging the GetBucketPolicy service API.
    * Added cmdlet Get-S3CBucketTagging leveraging the GetBucketTagging service API.
    * Added cmdlet Get-S3CRegionalBucketList leveraging the ListRegionalBuckets service API.
    * Added cmdlet New-S3CBucket leveraging the CreateBucket service API.
    * Added cmdlet Remove-S3CBucket leveraging the DeleteBucket service API.
    * Added cmdlet Remove-S3CBucketLifecycleConfiguration leveraging the DeleteBucketLifecycleConfiguration service API.
    * Added cmdlet Remove-S3CBucketPolicy leveraging the DeleteBucketPolicy service API.
    * Added cmdlet Remove-S3CBucketTagging leveraging the DeleteBucketTagging service API.
    * Added cmdlet Write-S3CBucketLifecycleConfiguration leveraging the PutBucketLifecycleConfiguration service API.
    * Added cmdlet Write-S3CBucketPolicy leveraging the PutBucketPolicy service API.
    * Added cmdlet Write-S3CBucketTagging leveraging the PutBucketTagging service API.
  * Amazon S3 Outposts. Added cmdlets to support the service. Cmdlets for the service have the noun prefix S3O and can be listed using the command 'Get-AWSCmdletName -Service S3O'.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMLabelingJob: added parameters OutputConfig_SnsTopicArn and SnsDataSource_SnsTopicArn.
  * Amazon Savings Plans
    * Added cmdlet Remove-SPQueuedSavingsPlan leveraging the DeleteQueuedSavingsPlan service API.
    * Modified cmdlet New-SPSavingsPlan: added parameter PurchaseTime.
  * Amazon Service Catalog
    * Modified cmdlet Get-SCProvisionedProductDetail: added parameter Name.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3Object: added parameter ExpectedBucketOwner.
    * Modified cmdlet Set-S3ACL: added parameter ExpectedBucketOwner.
    * Modified cmdlet Add-S3PublicAccessBlock: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3ACL: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketAccelerateConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketAnalyticsConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketAnalyticsConfigurationList: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketEncryption: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketInventoryConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketInventoryConfigurationList: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketLocation: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketLogging: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketMetricsConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketMetricsConfigurationList: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketNotification: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketPolicy: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketPolicyStatus: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketReplication: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketRequestPayment: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketTagging: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketVersioning: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketWebsite: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3CORSConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3LifecycleConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3ObjectLegalHold: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3ObjectLockConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3ObjectMetadata: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3ObjectRetention: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3ObjectTagSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3PublicAccessBlock: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3Version: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketAnalyticsConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketEncryption: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketInventoryConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketMetricsConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketPolicy: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketReplication: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketTagging: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketWebsite: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3CORSConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3LifecycleConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3ObjectTagSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3PublicAccessBlock: added parameter ExpectedBucketOwner.
    * Modified cmdlet Restore-S3Object: added parameter ExpectedBucketOwner.
    * Modified cmdlet Select-S3ObjectContent: added parameter ExpectedBucketOwner.
    * Modified cmdlet Set-S3BucketEncryption: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketAccelerateConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketAnalyticsConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketInventoryConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketLogging: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketMetricsConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketNotification: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketPolicy: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketReplication: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketRequestPayment: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketTagging: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketVersioning: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketWebsite: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3CORSConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3LifecycleConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3ObjectLegalHold: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3ObjectLockConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3ObjectRetention: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3ObjectTagSet: added parameter ExpectedBucketOwner.
  * Amazon Step Functions
    * Modified cmdlet Get-SFNExecutionHistory: added parameter IncludeExecutionData.
    * Modified cmdlet New-SFNStateMachine: added parameter TracingConfiguration_Enabled.
    * Modified cmdlet Start-SFNExecution: added parameter TraceHeader.
    * Modified cmdlet Update-SFNStateMachine: added parameter TracingConfiguration_Enabled.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGTapePool leveraging the ListTapePools service API.
    * Added cmdlet New-SGTapePool leveraging the CreateTapePool service API.
    * Added cmdlet Remove-SGTapePool leveraging the DeleteTapePool service API.
    * Modified cmdlet Add-SGTapeToTapePool: added parameter BypassGovernanceRetention.
    * Modified cmdlet New-SGTape: added parameter Worm.
    * Modified cmdlet New-SGTapeWithBarcode: added parameter Worm.
    * Modified cmdlet Remove-SGTape: added parameter BypassGovernanceRetention.
    * Modified cmdlet Remove-SGTapeArchive: added parameter BypassGovernanceRetention.
  * Amazon Textract
    * Modified cmdlet Start-TXTDocumentAnalysis: added parameters OutputConfig_S3Bucket and OutputConfig_S3Prefix.
    * Modified cmdlet Start-TXTDocumentTextDetection: added parameters OutputConfig_S3Bucket and OutputConfig_S3Prefix.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSMedicalTranscriptionJob: added parameter OutputKey.
    * Modified cmdlet Start-TRSTranscriptionJob: added parameters IdentifyLanguage, LanguageOption and OutputKey.
  * Amazon WorkMail
    * Added cmdlet Get-WMMailboxExportJob leveraging the DescribeMailboxExportJob service API.
    * Added cmdlet Get-WMMailboxExportJobList leveraging the ListMailboxExportJobs service API.
    * Added cmdlet Start-WMMailboxExportJob leveraging the StartMailboxExportJob service API.
    * Added cmdlet Stop-WMMailboxExportJob leveraging the CancelMailboxExportJob service API.
  * Amazon WorkSpaces
    * Added cmdlet Get-WKSConnectionAlias leveraging the DescribeConnectionAliases service API.
    * Added cmdlet Get-WKSConnectionAliasPermission leveraging the DescribeConnectionAliasPermissions service API.
    * Added cmdlet New-WKSConnectionAlias leveraging the CreateConnectionAlias service API.
    * Added cmdlet Register-WKSConnectionAlias leveraging the AssociateConnectionAlias service API.
    * Added cmdlet Remove-WKSConnectionAlias leveraging the DeleteConnectionAlias service API.
    * Added cmdlet Unregister-WKSConnectionAlias leveraging the DisassociateConnectionAlias service API.
    * Added cmdlet Update-WKSConnectionAliasPermission leveraging the UpdateConnectionAliasPermission service API.
    * Modified cmdlet Import-WKSWorkspaceImage: added parameter Application.
  * Amazon X-Ray
    * Added cmdlet Add-XRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-XRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-XRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-XRGroup: added parameters InsightsConfiguration_InsightsEnabled and Tag.
    * Modified cmdlet New-XRSamplingRule: added parameter Tag.
    * Modified cmdlet Update-XRGroup: added parameter InsightsConfiguration_InsightsEnabled.

### 4.1.0.0 (2020-08-18)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.800.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Changing AWSPowerShell module to target .NET Framework 4.5 and PowerShell 3.0.
  * Allowing full build on Linux.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBBusinessReportSchedule: added parameter Tag.
    * Modified cmdlet New-ALXBProfile: added parameter Tag.
    * Modified cmdlet New-ALXBSkillGroup: added parameter Tag.
    * Modified cmdlet Register-ALXBAVSDevice: added parameter RoomArn.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter EnableBranchAutoDeletion.
    * Modified cmdlet New-AMPDomainAssociation: added parameters AutoSubDomainCreationPattern and AutoSubDomainIAMRole.
    * Modified cmdlet Update-AMPApp: added parameter EnableBranchAutoDeletion.
    * Modified cmdlet Update-AMPDomainAssociation: added parameters AutoSubDomainCreationPattern and AutoSubDomainIAMRole.
  * Amazon App Mesh
    * Added cmdlet Get-AMSHGatewayRoute leveraging the DescribeGatewayRoute service API.
    * Added cmdlet Get-AMSHGatewayRouteList leveraging the ListGatewayRoutes service API.
    * Added cmdlet Get-AMSHVirtualGateway leveraging the DescribeVirtualGateway service API.
    * Added cmdlet Get-AMSHVirtualGatewayList leveraging the ListVirtualGateways service API.
    * Added cmdlet New-AMSHGatewayRoute leveraging the CreateGatewayRoute service API.
    * Added cmdlet New-AMSHVirtualGateway leveraging the CreateVirtualGateway service API.
    * Added cmdlet Remove-AMSHGatewayRoute leveraging the DeleteGatewayRoute service API.
    * Added cmdlet Remove-AMSHVirtualGateway leveraging the DeleteVirtualGateway service API.
    * Added cmdlet Update-AMSHGatewayRoute leveraging the UpdateGatewayRoute service API.
    * Added cmdlet Update-AMSHVirtualGateway leveraging the UpdateVirtualGateway service API.
    * Modified cmdlet New-AMSHRoute: added parameters Spec_GrpcRoute_Timeout_Idle_Unit, Spec_GrpcRoute_Timeout_Idle_Value, Spec_GrpcRoute_Timeout_PerRequest_Unit, Spec_GrpcRoute_Timeout_PerRequest_Value, Spec_Http2Route_Timeout_Idle_Unit, Spec_Http2Route_Timeout_Idle_Value, Spec_Http2Route_Timeout_PerRequest_Unit, Spec_Http2Route_Timeout_PerRequest_Value, Spec_HttpRoute_Timeout_Idle_Unit, Spec_HttpRoute_Timeout_Idle_Value, Spec_HttpRoute_Timeout_PerRequest_Unit, Spec_HttpRoute_Timeout_PerRequest_Value, Spec_TcpRoute_Timeout_Idle_Unit and Spec_TcpRoute_Timeout_Idle_Value.
    * Modified cmdlet Update-AMSHRoute: added parameters Spec_GrpcRoute_Timeout_Idle_Unit, Spec_GrpcRoute_Timeout_Idle_Value, Spec_GrpcRoute_Timeout_PerRequest_Unit, Spec_GrpcRoute_Timeout_PerRequest_Value, Spec_Http2Route_Timeout_Idle_Unit, Spec_Http2Route_Timeout_Idle_Value, Spec_Http2Route_Timeout_PerRequest_Unit, Spec_Http2Route_Timeout_PerRequest_Value, Spec_HttpRoute_Timeout_Idle_Unit, Spec_HttpRoute_Timeout_Idle_Value, Spec_HttpRoute_Timeout_PerRequest_Unit, Spec_HttpRoute_Timeout_PerRequest_Value, Spec_TcpRoute_Timeout_Idle_Unit and Spec_TcpRoute_Timeout_Idle_Value.
  * Amazon AppConfig
    * Added cmdlet Get-APPCHostedConfigurationVersion leveraging the GetHostedConfigurationVersion service API.
    * Added cmdlet Get-APPCHostedConfigurationVersionList leveraging the ListHostedConfigurationVersions service API.
    * Added cmdlet New-APPCHostedConfigurationVersion leveraging the CreateHostedConfigurationVersion service API.
    * Added cmdlet Remove-APPCHostedConfigurationVersion leveraging the DeleteHostedConfigurationVersion service API.
  * Amazon AppStream
    * Modified cmdlet New-APSFleet: added parameter StreamView.
    * Modified cmdlet Update-APSFleet: added parameter StreamView.
  * Amazon Auto Scaling
    * Added cmdlet Get-ASInstanceRefresh leveraging the DescribeInstanceRefreshes service API.
    * Added cmdlet Start-ASInstanceRefresh leveraging the StartInstanceRefresh service API.
    * Added cmdlet Stop-ASInstanceRefresh leveraging the CancelInstanceRefresh service API.
    * Modified cmdlet New-ASLaunchConfiguration: added parameters MetadataOptions_HttpEndpoint, MetadataOptions_HttpPutResponseHopLimit and MetadataOptions_HttpToken.
  * Amazon Backup
    * Modified cmdlet Get-BAKBackupJobList: added parameter ByAccountId.
    * Modified cmdlet Get-BAKCopyJobList: added parameter ByAccountId.
    * Modified cmdlet Get-BAKRestoreJobList: added parameters ByAccountId, ByCreatedAfter, ByCreatedBefore and ByStatus.
  * Amazon Braket. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BRKT and can be listed using the command 'Get-AWSCmdletName -Service BRKT'.
  * Amazon Certificate Manager Private Certificate Authority
    * Added cmdlet Get-PCAPolicy leveraging the GetPolicy service API.
    * Added cmdlet Remove-PCAPolicy leveraging the DeletePolicy service API.
    * Added cmdlet Set-PCAPolicy leveraging the PutPolicy service API.
    * Modified cmdlet Get-PCACertificateAuthorityList: added parameters PassThru and ResourceOwner.
  * Amazon Chime
    * Added cmdlet Get-CHMVoiceConnectorEmergencyCallingConfiguration leveraging the GetVoiceConnectorEmergencyCallingConfiguration service API.
    * Added cmdlet New-CHMMeetingWithAttendee leveraging the CreateMeetingWithAttendees service API.
    * Added cmdlet Remove-CHMVoiceConnectorEmergencyCallingConfiguration leveraging the DeleteVoiceConnectorEmergencyCallingConfiguration service API.
    * Added cmdlet Write-CHMVoiceConnectorEmergencyCallingConfiguration leveraging the PutVoiceConnectorEmergencyCallingConfiguration service API.
  * Amazon Cloud9
    * Modified cmdlet New-C9EnvironmentEC2: added parameter ConnectionType.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNStackInstanceList: added parameter Filter.
  * Amazon CloudFront
    * Added cmdlet Get-CFCachePolicy leveraging the GetCachePolicy service API.
    * Added cmdlet Get-CFCachePolicyConfig leveraging the GetCachePolicyConfig service API.
    * Added cmdlet Get-CFCachePolicyList leveraging the ListCachePolicies service API.
    * Added cmdlet Get-CFDistributionsByCachePolicyId leveraging the ListDistributionsByCachePolicyId service API.
    * Added cmdlet Get-CFDistributionsByOriginRequestPolicyId leveraging the ListDistributionsByOriginRequestPolicyId service API.
    * Added cmdlet Get-CFOriginRequestPolicy leveraging the GetOriginRequestPolicy service API.
    * Added cmdlet Get-CFOriginRequestPolicyConfig leveraging the GetOriginRequestPolicyConfig service API.
    * Added cmdlet Get-CFOriginRequestPolicyList leveraging the ListOriginRequestPolicies service API.
    * Added cmdlet New-CFCachePolicy leveraging the CreateCachePolicy service API.
    * Added cmdlet New-CFOriginRequestPolicy leveraging the CreateOriginRequestPolicy service API.
    * Added cmdlet Remove-CFCachePolicy leveraging the DeleteCachePolicy service API.
    * Added cmdlet Remove-CFOriginRequestPolicy leveraging the DeleteOriginRequestPolicy service API.
    * Added cmdlet Update-CFCachePolicy leveraging the UpdateCachePolicy service API.
    * Added cmdlet Update-CFOriginRequestPolicy leveraging the UpdateOriginRequestPolicy service API.
    * Modified cmdlet New-CFDistribution: added parameters DefaultCacheBehavior_CachePolicyId and DefaultCacheBehavior_OriginRequestPolicyId.
    * Modified cmdlet New-CFDistributionWithTag: added parameters DefaultCacheBehavior_CachePolicyId and DefaultCacheBehavior_OriginRequestPolicyId.
    * Modified cmdlet Update-CFDistribution: added parameters DefaultCacheBehavior_CachePolicyId and DefaultCacheBehavior_OriginRequestPolicyId.
  * Amazon CloudWatch
    * Modified cmdlet Get-CWMetricList: added parameter RecentlyActive.
  * Amazon CodeBuild
    * Added cmdlet Get-CBBatch leveraging the BatchGetBuildBatches service API.
    * Added cmdlet Get-CBBatchIdList leveraging the ListBuildBatches service API.
    * Added cmdlet Get-CBBatchIdListForProject leveraging the ListBuildBatchesForProject service API.
    * Added cmdlet Get-CBCodeCoverage leveraging the DescribeCodeCoverages service API.
    * Added cmdlet Redo-CBBatch leveraging the RetryBuildBatch service API.
    * Added cmdlet Redo-CBBuild leveraging the RetryBuild service API.
    * Added cmdlet Remove-CBBatch leveraging the DeleteBuildBatch service API.
    * Added cmdlet Start-CBBatch leveraging the StartBuildBatch service API.
    * Added cmdlet Stop-CBBatch leveraging the StopBuildBatch service API.
    * Modified cmdlet New-CBProject: added parameters BuildBatchConfig_CombineArtifact, BuildBatchConfig_ServiceRole, BuildBatchConfig_TimeoutInMin, BuildStatusConfig_Context, BuildStatusConfig_TargetUrl, Restrictions_ComputeTypesAllowed and Restrictions_MaximumBuildsAllowed.
    * Modified cmdlet New-CBWebhook: added parameter BuildType.
    * Modified cmdlet Start-CBBuild: added parameters BuildStatusConfigOverride_Context, BuildStatusConfigOverride_TargetUrl and DebugSessionEnabled.
    * Modified cmdlet Update-CBProject: added parameters BuildBatchConfig_CombineArtifact, BuildBatchConfig_ServiceRole, BuildBatchConfig_TimeoutInMin, BuildStatusConfig_Context, BuildStatusConfig_TargetUrl, Restrictions_ComputeTypesAllowed and Restrictions_MaximumBuildsAllowed.
    * Modified cmdlet Update-CBWebhook: added parameter BuildType.
  * Amazon CodeCommit
    * Added cmdlet Get-CCCommentReaction leveraging the GetCommentReactions service API.
    * Added cmdlet Write-CCCommentReaction leveraging the PutCommentReaction service API.
  * Amazon CodeGuru Profiler
    * Added cmdlet Add-CGPNotificationChannel leveraging the AddNotificationChannels service API.
    * Added cmdlet Add-CGPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CGPFindingsReportAccountSummary leveraging the GetFindingsReportAccountSummary service API.
    * Added cmdlet Get-CGPFindingsReportList leveraging the ListFindingsReports service API.
    * Added cmdlet Get-CGPGetFrameMetricData leveraging the BatchGetFrameMetricData service API.
    * Added cmdlet Get-CGPNotificationConfiguration leveraging the GetNotificationConfiguration service API.
    * Added cmdlet Get-CGPRecommendation leveraging the GetRecommendations service API.
    * Added cmdlet Get-CGPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CGPNotificationChannel leveraging the RemoveNotificationChannel service API.
    * Added cmdlet Remove-CGPResourceTag leveraging the UntagResource service API.
    * Added cmdlet Submit-CGPFeedback leveraging the SubmitFeedback service API.
    * Modified cmdlet New-CGPProfilingGroup: added parameters ComputePlatform and Tag.
    * Modified cmdlet Set-CGPAgentConfiguration: added parameter Metadata.
  * Amazon CodeGuru Reviewer
    * Modified cmdlet Register-CGRRepository: added parameters GitHubEnterpriseServer_ConnectionArn, GitHubEnterpriseServer_Name and GitHubEnterpriseServer_Owner.
  * Amazon CodeStar Connections
    * Added cmdlet Get-CSTCHost leveraging the GetHost service API.
    * Added cmdlet Get-CSTCHostList leveraging the ListHosts service API.
    * Added cmdlet New-CSTCHost leveraging the CreateHost service API.
    * Added cmdlet Remove-CSTCHost leveraging the DeleteHost service API.
    * Modified cmdlet Get-CSTCConnectionList: added parameter HostArnFilter.
    * Modified cmdlet New-CSTCConnection: added parameter HostArn.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPoolClient: added parameters AccessTokenValidity, AnalyticsConfiguration_ApplicationArn, IdTokenValidity, TokenValidityUnits_AccessToken, TokenValidityUnits_IdToken and TokenValidityUnits_RefreshToken.
    * Modified cmdlet Update-CGIPUserPoolClient: added parameters AccessTokenValidity, AnalyticsConfiguration_ApplicationArn, IdTokenValidity, TokenValidityUnits_AccessToken, TokenValidityUnits_IdToken and TokenValidityUnits_RefreshToken.
  * Amazon Comprehend
    * Modified cmdlet Find-COMPEntity: added parameter EndpointArn.
  * Amazon Connect Service
    * Added cmdlet Resume-CONNContactRecording leveraging the ResumeContactRecording service API.
    * Added cmdlet Start-CONNContactRecording leveraging the StartContactRecording service API.
    * Added cmdlet Stop-CONNContactRecording leveraging the StopContactRecording service API.
    * Added cmdlet Suspend-CONNContactRecording leveraging the SuspendContactRecording service API.
  * Amazon Database Migration Service
    * Added cmdlet Get-DMSApplicableIndividualAssessment leveraging the DescribeApplicableIndividualAssessments service API.
    * Added cmdlet Get-DMSReplicationTaskAssessmentRun leveraging the DescribeReplicationTaskAssessmentRuns service API.
    * Added cmdlet Get-DMSReplicationTaskIndividualAssessment leveraging the DescribeReplicationTaskIndividualAssessments service API.
    * Added cmdlet Remove-DMSReplicationTaskAssessmentRun leveraging the DeleteReplicationTaskAssessmentRun service API.
    * Added cmdlet Start-DMSReplicationTaskAssessmentRun leveraging the StartReplicationTaskAssessmentRun service API.
    * Added cmdlet Stop-DMSReplicationTaskAssessmentRun leveraging the CancelReplicationTaskAssessmentRun service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameters IBMDb2Settings_DatabaseName, IBMDb2Settings_Password, IBMDb2Settings_Port, IBMDb2Settings_ServerName, IBMDb2Settings_Username, KafkaSettings_IncludeControlDetail, KafkaSettings_IncludePartitionValue, KafkaSettings_IncludeTableAlterOperation, KafkaSettings_IncludeTransactionDetail, KafkaSettings_MessageFormat, KafkaSettings_PartitionIncludeSchemaTable, MicrosoftSQLServerSettings_DatabaseName, MicrosoftSQLServerSettings_Password, MicrosoftSQLServerSettings_Port, MicrosoftSQLServerSettings_ServerName, MicrosoftSQLServerSettings_Username, MySQLSettings_DatabaseName, MySQLSettings_Password, MySQLSettings_Port, MySQLSettings_ServerName, MySQLSettings_Username, OracleSettings_AsmPassword, OracleSettings_AsmServer, OracleSettings_AsmUser, OracleSettings_DatabaseName, OracleSettings_Password, OracleSettings_Port, OracleSettings_SecurityDbEncryption, OracleSettings_SecurityDbEncryptionName, OracleSettings_ServerName, OracleSettings_Username, PostgreSQLSettings_DatabaseName, PostgreSQLSettings_Password, PostgreSQLSettings_Port, PostgreSQLSettings_ServerName, PostgreSQLSettings_Username, SybaseSettings_DatabaseName, SybaseSettings_Password, SybaseSettings_Port, SybaseSettings_ServerName and SybaseSettings_Username.
    * Modified cmdlet New-DMSEndpoint: added parameters IBMDb2Settings_DatabaseName, IBMDb2Settings_Password, IBMDb2Settings_Port, IBMDb2Settings_ServerName, IBMDb2Settings_Username, KafkaSettings_IncludeControlDetail, KafkaSettings_IncludePartitionValue, KafkaSettings_IncludeTableAlterOperation, KafkaSettings_IncludeTransactionDetail, KafkaSettings_MessageFormat, KafkaSettings_PartitionIncludeSchemaTable, MicrosoftSQLServerSettings_DatabaseName, MicrosoftSQLServerSettings_Password, MicrosoftSQLServerSettings_Port, MicrosoftSQLServerSettings_ServerName, MicrosoftSQLServerSettings_Username, MySQLSettings_DatabaseName, MySQLSettings_Password, MySQLSettings_Port, MySQLSettings_ServerName, MySQLSettings_Username, OracleSettings_AsmPassword, OracleSettings_AsmServer, OracleSettings_AsmUser, OracleSettings_DatabaseName, OracleSettings_Password, OracleSettings_Port, OracleSettings_SecurityDbEncryption, OracleSettings_SecurityDbEncryptionName, OracleSettings_ServerName, OracleSettings_Username, PostgreSQLSettings_DatabaseName, PostgreSQLSettings_Password, PostgreSQLSettings_Port, PostgreSQLSettings_ServerName, PostgreSQLSettings_Username, SybaseSettings_DatabaseName, SybaseSettings_Password, SybaseSettings_Port, SybaseSettings_ServerName and SybaseSettings_Username.
  * Amazon DataSync
    * Added cmdlet Get-DSYNLocationObjectStorage leveraging the DescribeLocationObjectStorage service API.
    * Added cmdlet New-DSYNLocationObjectStorage leveraging the CreateLocationObjectStorage service API.
    * Modified cmdlet Get-DSYNLocationList: added parameter Filter.
    * Modified cmdlet Get-DSYNTaskList: added parameter Filter.
  * Amazon EBS
    * Added cmdlet Complete-EBSSnapshot leveraging the CompleteSnapshot service API.
    * Added cmdlet Start-EBSSnapshot leveraging the StartSnapshot service API.
    * Added cmdlet Write-EBSSnapshotBlock leveraging the PutSnapshotBlock service API.
  * Amazon EC2 Container Registry
    * Modified cmdlet New-ECRRepository: added parameters EncryptionConfiguration_EncryptionType and EncryptionConfiguration_KmsKey.
    * Modified cmdlet Write-ECRImage: added parameter ImageDigest.
  * Amazon EC2 Container Service
    * Added cmdlet Remove-ECSCapacityProvider leveraging the DeleteCapacityProvider service API.
  * Amazon EC2 Image Builder
    * Modified cmdlet New-EC2IBImageRecipe: added parameter WorkingDirectory.
    * Modified cmdlet New-EC2IBInfrastructureConfiguration: added parameter ResourceTag.
    * Modified cmdlet Update-EC2IBInfrastructureConfiguration: added parameter ResourceTag.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2ManagedPrefixList leveraging the ModifyManagedPrefixList service API.
    * Added cmdlet Get-EC2CarrierGateway leveraging the DescribeCarrierGateways service API.
    * Added cmdlet Get-EC2GroupsForCapacityReservation leveraging the GetGroupsForCapacityReservation service API.
    * Added cmdlet Get-EC2ManagedPrefixList leveraging the DescribeManagedPrefixLists service API.
    * Added cmdlet Get-EC2ManagedPrefixListAssociation leveraging the GetManagedPrefixListAssociations service API.
    * Added cmdlet Get-EC2ManagedPrefixListEntry leveraging the GetManagedPrefixListEntries service API.
    * Added cmdlet New-EC2CarrierGateway leveraging the CreateCarrierGateway service API.
    * Added cmdlet New-EC2ManagedPrefixList leveraging the CreateManagedPrefixList service API.
    * Added cmdlet Remove-EC2CarrierGateway leveraging the DeleteCarrierGateway service API.
    * Added cmdlet Remove-EC2ManagedPrefixList leveraging the DeleteManagedPrefixList service API.
    * Added cmdlet Restore-EC2ManagedPrefixListVersion leveraging the RestoreManagedPrefixListVersion service API.
    * Modified cmdlet New-EC2Instance: added parameter CapacityReservationTarget_CapacityReservationResourceGroupArn.
    * Modified cmdlet Edit-EC2InstanceCapacityReservationAttribute: added parameter CapacityReservationTarget_CapacityReservationResourceGroupArn.
    * Modified cmdlet Edit-EC2VpnTunnelOption: added parameter TunnelOptions_TunnelInsideIpv6Cidr.
    * Modified cmdlet Export-EC2Image: added parameter TagSpecification.
    * Modified cmdlet Import-EC2Image: added parameter TagSpecification.
    * Modified cmdlet Import-EC2Snapshot: added parameter TagSpecification.
    * Modified cmdlet New-EC2CustomerGateway: added parameter TagSpecification.
    * Modified cmdlet New-EC2DhcpOption: added parameter TagSpecification.
    * Modified cmdlet New-EC2EgressOnlyInternetGateway: added parameter TagSpecification.
    * Modified cmdlet New-EC2HostReservation: added parameter TagSpecification.
    * Modified cmdlet New-EC2InstanceExportTask: added parameter TagSpecification.
    * Modified cmdlet New-EC2InternetGateway: added parameter TagSpecification.
    * Modified cmdlet New-EC2NetworkAcl: added parameter TagSpecification.
    * Modified cmdlet New-EC2NetworkInterface: added parameter TagSpecification.
    * Modified cmdlet New-EC2Route: added parameters CarrierGatewayId and DestinationPrefixListId.
    * Modified cmdlet New-EC2RouteTable: added parameter TagSpecification.
    * Modified cmdlet New-EC2SecurityGroup: added parameter TagSpecification.
    * Modified cmdlet New-EC2Subnet: added parameter TagSpecification.
    * Modified cmdlet New-EC2Vpc: added parameter TagSpecification.
    * Modified cmdlet New-EC2VpcPeeringConnection: added parameter TagSpecification.
    * Modified cmdlet New-EC2VpnConnection: added parameters Options_TunnelInsideIpVersion and TagSpecification.
    * Modified cmdlet New-EC2VpnGateway: added parameter TagSpecification.
    * Modified cmdlet Remove-EC2Route: added parameter DestinationPrefixListId.
    * Modified cmdlet Request-EC2SpotInstance: added parameter TagSpecification.
    * Modified cmdlet Set-EC2Route: added parameters CarrierGatewayId and DestinationPrefixListId.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSNodegroup: added parameters LaunchTemplate_Id, LaunchTemplate_Name and LaunchTemplate_Version.
    * Modified cmdlet Update-EKSNodegroupVersion: added parameters LaunchTemplate_Id, LaunchTemplate_Name and LaunchTemplate_Version.
  * Amazon Elastic File System
    * Added cmdlet Get-EFSBackupPolicy leveraging the DescribeBackupPolicy service API.
    * Added cmdlet Write-EFSBackupPolicy leveraging the PutBackupPolicy service API.
  * Amazon Elastic MapReduce
    * Modified cmdlet Add-EMRInstanceFleet: added parameters OnDemandSpecification_AllocationStrategy and SpotSpecification_AllocationStrategy.
    * Modified cmdlet Start-EMRJobFlow: added parameter ComputeLimits_MaximumCoreCapacityUnit.
    * Modified cmdlet Write-EMRManagedScalingPolicy: added parameter ComputeLimits_MaximumCoreCapacityUnit.
  * Amazon Elemental MediaConnect
    * Modified cmdlet Update-EMCNFlowEntitlement: added parameter EntitlementStatus.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLInputDeviceThumbnail leveraging the DescribeInputDeviceThumbnail service API.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameters Bumper_EndUrl and Bumper_StartUrl.
  * Amazon Firewall Management Service
    * Added cmdlet Get-FMSAppList leveraging the GetAppsList service API.
    * Added cmdlet Get-FMSAppsListList leveraging the ListAppsLists service API.
    * Added cmdlet Get-FMSProtocolList leveraging the GetProtocolsList service API.
    * Added cmdlet Get-FMSProtocolsListList leveraging the ListProtocolsLists service API.
    * Added cmdlet Get-FMSViolationDetail leveraging the GetViolationDetails service API.
    * Added cmdlet Remove-FMSAppList leveraging the DeleteAppsList service API.
    * Added cmdlet Remove-FMSProtocolList leveraging the DeleteProtocolsList service API.
    * Added cmdlet Write-FMSAppList leveraging the PutAppsList service API.
    * Added cmdlet Write-FMSProtocolList leveraging the PutProtocolsList service API.
  * Amazon Forecast Service
    * Added cmdlet Add-FRCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-FRCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-FRCResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-FRCDataset: added parameter Tag.
    * Modified cmdlet New-FRCDatasetGroup: added parameter Tag.
    * Modified cmdlet New-FRCDatasetImportJob: added parameter Tag.
    * Modified cmdlet New-FRCForecast: added parameter Tag.
    * Modified cmdlet New-FRCForecastExportJob: added parameter Tag.
    * Modified cmdlet New-FRCPredictor: added parameter Tag.
  * FD
    * [Breaking Change] Removed cmdlets Get-FDPrediction, Remove-FDRuleVersion and Write-FDModel.
    * Added cmdlet Add-FDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-FDEntityType leveraging the GetEntityTypes service API.
    * Added cmdlet Get-FDEventPrediction leveraging the GetEventPrediction service API.
    * Added cmdlet Get-FDEventType leveraging the GetEventTypes service API.
    * Added cmdlet Get-FDKMSEncryptionKey leveraging the GetKMSEncryptionKey service API.
    * Added cmdlet Get-FDLabel leveraging the GetLabels service API.
    * Added cmdlet Get-FDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-FDModel leveraging the CreateModel service API.
    * Added cmdlet Remove-FDResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-FDRule leveraging the DeleteRule service API.
    * Added cmdlet Update-FDModel leveraging the UpdateModel service API.
    * Added cmdlet Update-FDModelVersionStatus leveraging the UpdateModelVersionStatus service API.
    * Added cmdlet Write-FDEntityType leveraging the PutEntityType service API.
    * Added cmdlet Write-FDEventType leveraging the PutEventType service API.
    * Added cmdlet Write-FDKMSEncryptionKey leveraging the PutKMSEncryptionKey service API.
    * Added cmdlet Write-FDLabel leveraging the PutLabel service API.
    * Modified cmdlet New-FDDetectorVersion: added parameter Tag.
    * [Breaking Change] Modified cmdlet New-FDModelVersion: removed parameter Description; added parameters ExternalEventsDetail_DataAccessRoleArn, ExternalEventsDetail_DataLocation, LabelSchema_LabelMapper, Tag, TrainingDataSchema_ModelVariable and TrainingDataSource.
    * Modified cmdlet New-FDRule: added parameter Tag.
    * Modified cmdlet New-FDVariable: added parameter Tag.
    * Modified cmdlet New-FDVariableBatch: added parameter Tag.
    * Modified cmdlet Remove-FDEvent: added parameter EventTypeName.
    * [Breaking Change] Modified cmdlet Update-FDModelVersion: removed parameters Description, ModelVersionNumber and Status; added parameters ExternalEventsDetail_DataAccessRoleArn, ExternalEventsDetail_DataLocation, MajorVersionNumber and Tag.
    * Modified cmdlet Update-FDRuleVersion: added parameter Tag.
    * Modified cmdlet Write-FDDetector: added parameters EventTypeName and Tag.
    * [Breaking Change] Modified cmdlet Write-FDExternalModel: removed parameters InputConfiguration_IsOpaque, Role_Arn and Role_Name; added parameters InputConfiguration_EventTypeName, InputConfiguration_UseEventVariable, InvokeModelEndpointRoleArn and Tag.
    * Modified cmdlet Write-FDOutcome: added parameter Tag.
  * Amazon FSx
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameter LustreConfiguration.
    * Modified cmdlet Remove-FSXFileSystem: added parameters LustreConfiguration_FinalBackupTag and LustreConfiguration_SkipFinalBackup.
  * Amazon Glue
    * Added cmdlet Get-GLUEColumnStatisticsForPartition leveraging the GetColumnStatisticsForPartition service API.
    * Added cmdlet Get-GLUEColumnStatisticsForTable leveraging the GetColumnStatisticsForTable service API.
    * Added cmdlet Get-GLUEGluePolicyList leveraging the GetResourcePolicies service API.
    * Added cmdlet Remove-GLUEColumnStatisticsForPartition leveraging the DeleteColumnStatisticsForPartition service API.
    * Added cmdlet Remove-GLUEColumnStatisticsForTable leveraging the DeleteColumnStatisticsForTable service API.
    * Added cmdlet Resume-GLUEWorkflowRun leveraging the ResumeWorkflowRun service API.
    * Added cmdlet Update-GLUEColumnStatisticsForPartition leveraging the UpdateColumnStatisticsForPartition service API.
    * Added cmdlet Update-GLUEColumnStatisticsForTable leveraging the UpdateColumnStatisticsForTable service API.
    * Modified cmdlet Find-GLUETable: added parameter ResourceShareType.
    * Modified cmdlet Get-GLUEDatabaseList: added parameter ResourceShareType.
    * Modified cmdlet Get-GLUEResourcePolicy: added parameters PassThru and ResourceArn.
    * Modified cmdlet New-GLUEWorkflow: added parameter MaxConcurrentRun.
    * Modified cmdlet Remove-GLUEResourcePolicy: added parameter ResourceArn.
    * Modified cmdlet Set-GLUEResourcePolicy: added parameters EnableHybrid and ResourceArn.
    * Modified cmdlet Update-GLUEWorkflow: added parameter MaxConcurrentRun.
  * Amazon GuardDuty
    * Added cmdlet Get-GDMemberDetector leveraging the GetMemberDetectors service API.
    * Added cmdlet Get-GDUsageStatistic leveraging the GetUsageStatistics service API.
    * Added cmdlet Update-GDMemberDetector leveraging the UpdateMemberDetectors service API.
    * Modified cmdlet New-GDDetector: added parameter S3Logs_Enable.
    * Modified cmdlet Update-GDDetector: added parameter S3Logs_Enable.
    * Modified cmdlet Update-GDOrganizationConfiguration: added parameter S3Logs_AutoEnable.
  * Amazon Import/Export Snowball
    * Modified cmdlet New-SNOWJob: added parameter WirelessConnection_IsWifiEnabled.
  * Amazon Interactive Video Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IVS and can be listed using the command 'Get-AWSCmdletName -Service IVS'.
  * Amazon IoT
    * Added cmdlet Get-IOTAuditSuppression leveraging the DescribeAuditSuppression service API.
    * Added cmdlet Get-IOTAuditSuppressionList leveraging the ListAuditSuppressions service API.
    * Added cmdlet New-IOTAuditSuppression leveraging the CreateAuditSuppression service API.
    * Added cmdlet Remove-IOTAuditSuppression leveraging the DeleteAuditSuppression service API.
    * Added cmdlet Update-IOTAuditSuppression leveraging the UpdateAuditSuppression service API.
    * Modified cmdlet Get-IOTAuditFindingList: added parameter ListSuppressedFinding.
    * Modified cmdlet New-IOTOTAUpdate: added parameters AwsJobAbortConfig_AbortCriteriaList, AwsJobTimeoutConfig_InProgressTimeoutInMinute, ExponentialRate_BaseRatePerMinute, ExponentialRate_IncrementFactor, RateIncreaseCriteria_NumberOfNotifiedThing and RateIncreaseCriteria_NumberOfSucceededThing.
  * Amazon Kendra
    * Modified cmdlet Invoke-KNDRQuery: added parameters SortingConfiguration_DocumentAttributeKey and SortingConfiguration_SortOrder.
  * Amazon Kinesis
    * Modified cmdlet Get-KINShardList: added parameters ShardFilter_ShardId, ShardFilter_Timestamp and ShardFilter_Type.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters EndpointConfiguration_Name, HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds, HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs, HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled, HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName, HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName, HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey, HttpEndpointDestinationConfiguration_EndpointConfiguration_Url, HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled, HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors, HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes, HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding, HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds, HttpEndpointDestinationConfiguration_RoleARN, HttpEndpointDestinationConfiguration_S3BackupMode and HttpEndpointDestinationConfiguration_S3Configuration.
    * Modified cmdlet Update-KINFDestination: added parameters EndpointConfiguration_Name, HttpEndpointDestinationUpdate_BufferingHints_IntervalInSeconds, HttpEndpointDestinationUpdate_BufferingHints_SizeInMBs, HttpEndpointDestinationUpdate_CloudWatchLoggingOptions_Enabled, HttpEndpointDestinationUpdate_CloudWatchLoggingOptions_LogGroupName, HttpEndpointDestinationUpdate_CloudWatchLoggingOptions_LogStreamName, HttpEndpointDestinationUpdate_EndpointConfiguration_AccessKey, HttpEndpointDestinationUpdate_EndpointConfiguration_Url, HttpEndpointDestinationUpdate_ProcessingConfiguration_Enabled, HttpEndpointDestinationUpdate_ProcessingConfiguration_Processors, HttpEndpointDestinationUpdate_RequestConfiguration_CommonAttributes, HttpEndpointDestinationUpdate_RequestConfiguration_ContentEncoding, HttpEndpointDestinationUpdate_RetryOptions_DurationInSeconds, HttpEndpointDestinationUpdate_RoleARN, HttpEndpointDestinationUpdate_S3BackupMode and HttpEndpointDestinationUpdate_S3Update.
  * Amazon Lake Formation
    * Modified cmdlet Get-LKFPermissionList: added parameters Database_CatalogId, DataLocation_CatalogId, Table_CatalogId, Table_TableWildcard and TableWithColumns_CatalogId.
    * Modified cmdlet Grant-LKFPermission: added parameters Database_CatalogId, DataLocation_CatalogId, Table_CatalogId, Table_TableWildcard and TableWithColumns_CatalogId.
    * Modified cmdlet Revoke-LKFPermission: added parameters Database_CatalogId, DataLocation_CatalogId, Table_CatalogId, Table_TableWildcard and TableWithColumns_CatalogId.
    * Modified cmdlet Write-LKFDataLakeSetting: added parameter DataLakeSettings_TrustedResourceOwner.
  * Amazon Lambda
    * Modified cmdlet Publish-LMFunction: added parameter FileSystemConfig.
    * Modified cmdlet New-LMEventSourceMapping: added parameter Topic.
    * Modified cmdlet Update-LMFunctionConfiguration: added parameter FileSystemConfig.
  * Amazon Lex Model Building Service
    * Modified cmdlet Write-LMBBot: added parameters EnableModelImprovement and NluIntentConfidenceThreshold.
    * Modified cmdlet Write-LMBIntent: added parameters KendraConfiguration_KendraIndex, KendraConfiguration_QueryFilterString and KendraConfiguration_Role.
  * Amazon Lightsail
    * Added cmdlet Dismount-LSCertificateFromDistribution leveraging the DetachCertificateFromDistribution service API.
    * Added cmdlet Get-LSCertificate leveraging the GetCertificates service API.
    * Added cmdlet Get-LSDistribution leveraging the GetDistributions service API.
    * Added cmdlet Get-LSDistributionBundle leveraging the GetDistributionBundles service API.
    * Added cmdlet Get-LSDistributionLatestCacheReset leveraging the GetDistributionLatestCacheReset service API.
    * Added cmdlet Get-LSDistributionMetricData leveraging the GetDistributionMetricData service API.
    * Added cmdlet Mount-LSCertificateToDistribution leveraging the AttachCertificateToDistribution service API.
    * Added cmdlet New-LSCertificate leveraging the CreateCertificate service API.
    * Added cmdlet New-LSDistribution leveraging the CreateDistribution service API.
    * Added cmdlet Remove-LSCertificate leveraging the DeleteCertificate service API.
    * Added cmdlet Remove-LSDistribution leveraging the DeleteDistribution service API.
    * Added cmdlet Reset-LSDistributionCache leveraging the ResetDistributionCache service API.
    * Added cmdlet Update-LSDistribution leveraging the UpdateDistribution service API.
    * Added cmdlet Update-LSDistributionBundle leveraging the UpdateDistributionBundle service API.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Restart-MSKBroker leveraging the RebootBroker service API.
  * Amazon MQ
    * Modified cmdlet New-MQBroker: added parameters AuthenticationStrategy, LdapServerMetadata_Host, LdapServerMetadata_RoleBase, LdapServerMetadata_RoleName, LdapServerMetadata_RoleSearchMatching, LdapServerMetadata_RoleSearchSubtree, LdapServerMetadata_ServiceAccountPassword, LdapServerMetadata_ServiceAccountUsername, LdapServerMetadata_UserBase, LdapServerMetadata_UserRoleName, LdapServerMetadata_UserSearchMatching and LdapServerMetadata_UserSearchSubtree.
    * Modified cmdlet New-MQConfiguration: added parameter AuthenticationStrategy.
    * Modified cmdlet Update-MQBroker: added parameters AuthenticationStrategy, LdapServerMetadata_Host, LdapServerMetadata_RoleBase, LdapServerMetadata_RoleName, LdapServerMetadata_RoleSearchMatching, LdapServerMetadata_RoleSearchSubtree, LdapServerMetadata_ServiceAccountPassword, LdapServerMetadata_ServiceAccountUsername, LdapServerMetadata_UserBase, LdapServerMetadata_UserRoleName, LdapServerMetadata_UserSearchMatching and LdapServerMetadata_UserSearchSubtree.
  * Amazon Personalize
    * Modified cmdlet New-PERSBatchInferenceJob: added parameter BatchInferenceJobConfig_ItemExplorationConfig.
    * Modified cmdlet New-PERSCampaign: added parameter CampaignConfig_ItemExplorationConfig.
    * Modified cmdlet Update-PERSCampaign: added parameter CampaignConfig_ItemExplorationConfig.
  * Amazon Personalize Runtime
    * Modified cmdlet Get-PERSRPersonalizedRanking: added parameter FilterArn.
  * Amazon QuickSight
    * Added cmdlet Get-QSAccountCustomization leveraging the DescribeAccountCustomization service API.
    * Added cmdlet Get-QSAccountSetting leveraging the DescribeAccountSettings service API.
    * Added cmdlet Get-QSAnalysis leveraging the DescribeAnalysis service API.
    * Added cmdlet Get-QSAnalysisList leveraging the ListAnalyses service API.
    * Added cmdlet Get-QSAnalysisPermission leveraging the DescribeAnalysisPermissions service API.
    * Added cmdlet Get-QSNamespace leveraging the DescribeNamespace service API.
    * Added cmdlet Get-QSNamespaceList leveraging the ListNamespaces service API.
    * Added cmdlet Get-QSSessionEmbedUrl leveraging the GetSessionEmbedUrl service API.
    * Added cmdlet Get-QSTheme leveraging the DescribeTheme service API.
    * Added cmdlet Get-QSThemeAlias leveraging the DescribeThemeAlias service API.
    * Added cmdlet Get-QSThemeAliasList leveraging the ListThemeAliases service API.
    * Added cmdlet Get-QSThemeList leveraging the ListThemes service API.
    * Added cmdlet Get-QSThemePermission leveraging the DescribeThemePermissions service API.
    * Added cmdlet Get-QSThemeVersionList leveraging the ListThemeVersions service API.
    * Added cmdlet New-QSAccountCustomization leveraging the CreateAccountCustomization service API.
    * Added cmdlet New-QSAnalysis leveraging the CreateAnalysis service API.
    * Added cmdlet New-QSNamespace leveraging the CreateNamespace service API.
    * Added cmdlet New-QSTheme leveraging the CreateTheme service API.
    * Added cmdlet New-QSThemeAlias leveraging the CreateThemeAlias service API.
    * Added cmdlet Remove-QSAccountCustomization leveraging the DeleteAccountCustomization service API.
    * Added cmdlet Remove-QSAnalysis leveraging the DeleteAnalysis service API.
    * Added cmdlet Remove-QSNamespace leveraging the DeleteNamespace service API.
    * Added cmdlet Remove-QSTheme leveraging the DeleteTheme service API.
    * Added cmdlet Remove-QSThemeAlias leveraging the DeleteThemeAlias service API.
    * Added cmdlet Restore-QSAnalysis leveraging the RestoreAnalysis service API.
    * Added cmdlet Search-QSAnalysis leveraging the SearchAnalyses service API.
    * Added cmdlet Update-QSAccountCustomization leveraging the UpdateAccountCustomization service API.
    * Added cmdlet Update-QSAccountSetting leveraging the UpdateAccountSettings service API.
    * Added cmdlet Update-QSAnalysis leveraging the UpdateAnalysis service API.
    * Added cmdlet Update-QSAnalysisPermission leveraging the UpdateAnalysisPermissions service API.
    * Added cmdlet Update-QSTheme leveraging the UpdateTheme service API.
    * Added cmdlet Update-QSThemeAlias leveraging the UpdateThemeAlias service API.
    * Added cmdlet Update-QSThemePermission leveraging the UpdateThemePermissions service API.
    * Modified cmdlet New-QSDashboard: added parameter ThemeArn.
    * Modified cmdlet New-QSDataSet: added parameter RowLevelPermissionDataSet_Namespace.
    * Modified cmdlet New-QSDataSource: added parameters CredentialPair_AlternateDataSourceParameter and Credentials_CopySourceArn.
    * Modified cmdlet Register-QSUser: added parameter CustomPermissionsName.
    * Modified cmdlet Update-QSDashboard: added parameter ThemeArn.
    * Modified cmdlet Update-QSDataSet: added parameter RowLevelPermissionDataSet_Namespace.
    * Modified cmdlet Update-QSDataSource: added parameters CredentialPair_AlternateDataSourceParameter and Credentials_CopySourceArn.
    * Modified cmdlet Update-QSUser: added parameters CustomPermissionsName and UnapplyCustomPermission.
  * Amazon Rekognition
    * Added cmdlet Get-REKSegmentDetection leveraging the GetSegmentDetection service API.
    * Added cmdlet Start-REKSegmentDetection leveraging the StartSegmentDetection service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter EnableGlobalWriteForwarding.
    * Modified cmdlet Edit-RDSDBInstance: added parameter ReplicaMode.
    * Modified cmdlet New-RDSDBCluster: added parameter EnableGlobalWriteForwarding.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter ReplicaMode.
  * Amazon Resource Groups
    * Added cmdlet Add-RGResource leveraging the GroupResources service API.
    * Added cmdlet Get-RGGroupConfiguration leveraging the GetGroupConfiguration service API.
    * Added cmdlet Remove-RGResource leveraging the UngroupResources service API.
    * Modified cmdlet Get-RGGroup: added parameter Group.
    * Modified cmdlet Get-RGGroupQuery: added parameter Group.
    * Modified cmdlet Get-RGGroupResourceList: added parameter Group.
    * Modified cmdlet New-RGGroup: added parameter Configuration.
    * Modified cmdlet Remove-RGGroup: added parameter Group.
    * Modified cmdlet Update-RGGroup: added parameter Group.
    * Modified cmdlet Update-RGGroupQuery: added parameter Group.
  * Amazon RoboMaker
    * Added cmdlet Get-ROBOWorld leveraging the DescribeWorld service API.
    * Added cmdlet Get-ROBOWorldExportJob leveraging the DescribeWorldExportJob service API.
    * Added cmdlet Get-ROBOWorldExportJobList leveraging the ListWorldExportJobs service API.
    * Added cmdlet Get-ROBOWorldGenerationJob leveraging the DescribeWorldGenerationJob service API.
    * Added cmdlet Get-ROBOWorldGenerationJobList leveraging the ListWorldGenerationJobs service API.
    * Added cmdlet Get-ROBOWorldList leveraging the ListWorlds service API.
    * Added cmdlet Get-ROBOWorldTemplate leveraging the DescribeWorldTemplate service API.
    * Added cmdlet Get-ROBOWorldTemplateBody leveraging the GetWorldTemplateBody service API.
    * Added cmdlet Get-ROBOWorldTemplateList leveraging the ListWorldTemplates service API.
    * Added cmdlet New-ROBOWorldExportJob leveraging the CreateWorldExportJob service API.
    * Added cmdlet New-ROBOWorldGenerationJob leveraging the CreateWorldGenerationJob service API.
    * Added cmdlet New-ROBOWorldTemplate leveraging the CreateWorldTemplate service API.
    * Added cmdlet Remove-ROBODeleteWorld leveraging the BatchDeleteWorlds service API.
    * Added cmdlet Remove-ROBOWorldTemplate leveraging the DeleteWorldTemplate service API.
    * Added cmdlet Stop-ROBOWorldExportJob leveraging the CancelWorldExportJob service API.
    * Added cmdlet Stop-ROBOWorldGenerationJob leveraging the CancelWorldGenerationJob service API.
    * Added cmdlet Update-ROBOWorldTemplate leveraging the UpdateWorldTemplate service API.
  * Amazon Route 53
    * Added cmdlet Get-R53HostedZonesByVPC leveraging the ListHostedZonesByVPC service API.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMWorkforceList leveraging the ListWorkforces service API.
    * Added cmdlet New-SMWorkforce leveraging the CreateWorkforce service API.
    * Added cmdlet Remove-SMHumanTaskUi leveraging the DeleteHumanTaskUi service API.
    * Added cmdlet Remove-SMWorkforce leveraging the DeleteWorkforce service API.
    * Modified cmdlet New-SMCompilationJob: added parameters OutputConfig_CompilerOption, TargetPlatform_Accelerator, TargetPlatform_Arch and TargetPlatform_Os.
    * Modified cmdlet New-SMTransformJob: added parameters ModelClientConfig_InvocationsMaxRetry and ModelClientConfig_InvocationsTimeoutInSecond.
    * Modified cmdlet New-SMWorkteam: added parameter WorkforceName.
    * Modified cmdlet Update-SMWorkforce: added parameters OidcConfig_AuthorizationEndpoint, OidcConfig_ClientId, OidcConfig_ClientSecret, OidcConfig_Issuer, OidcConfig_JwksUri, OidcConfig_LogoutEndpoint, OidcConfig_TokenEndpoint and OidcConfig_UserInfoEndpoint.
  * Amazon Secrets Manager
    * Added cmdlet Test-SECResourcePolicy leveraging the ValidateResourcePolicy service API.
    * Modified cmdlet Get-SECSecretList: added parameters Filter, PassThru and SortOrder.
    * Modified cmdlet Write-SECResourcePolicy: added parameter BlockPublicPolicy.
  * Amazon Security Hub
    * Added cmdlet Update-SHUBSecurityHubConfiguration leveraging the UpdateSecurityHubConfiguration service API.
  * Amazon Server Migration Service
    * Added cmdlet Get-SMSAppValidationConfiguration leveraging the GetAppValidationConfiguration service API.
    * Added cmdlet Get-SMSAppValidationOutput leveraging the GetAppValidationOutput service API.
    * Added cmdlet Import-SMSAppCatalog leveraging the ImportAppCatalog service API.
    * Added cmdlet Remove-SMSAppValidationConfiguration leveraging the DeleteAppValidationConfiguration service API.
    * Added cmdlet Start-SMSOnDemandAppReplication leveraging the StartOnDemandAppReplication service API.
    * Added cmdlet Write-SMSAppValidationConfiguration leveraging the PutAppValidationConfiguration service API.
    * Added cmdlet Write-SMSAppValidationOutput leveraging the NotifyAppValidationOutput service API.
    * Modified cmdlet Write-SMSAppLaunchConfiguration: added parameter AutoLaunch.
  * Amazon Service Catalog
    * Modified cmdlet Get-SCProvisioningParameter: added parameters PathName, ProductName and ProvisioningArtifactName.
    * Modified cmdlet New-SCProvisionedProduct: added parameters PathName, ProductName and ProvisioningArtifactName.
    * Modified cmdlet Update-SCProvisionedProduct: added parameters PathName, ProductName and ProvisioningArtifactName.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Get-SES2CustomVerificationEmailTemplate leveraging the GetCustomVerificationEmailTemplate service API.
    * Added cmdlet Get-SES2CustomVerificationEmailTemplateList leveraging the ListCustomVerificationEmailTemplates service API.
    * Added cmdlet Get-SES2EmailIdentityPolicy leveraging the GetEmailIdentityPolicies service API.
    * Added cmdlet Get-SES2EmailTemplate leveraging the GetEmailTemplate service API.
    * Added cmdlet Get-SES2EmailTemplateList leveraging the ListEmailTemplates service API.
    * Added cmdlet Get-SES2ImportJob leveraging the GetImportJob service API.
    * Added cmdlet Get-SES2ImportJobList leveraging the ListImportJobs service API.
    * Added cmdlet New-SES2CustomVerificationEmailTemplate leveraging the CreateCustomVerificationEmailTemplate service API.
    * Added cmdlet New-SES2EmailIdentityPolicy leveraging the CreateEmailIdentityPolicy service API.
    * Added cmdlet New-SES2EmailTemplate leveraging the CreateEmailTemplate service API.
    * Added cmdlet New-SES2ImportJob leveraging the CreateImportJob service API.
    * Added cmdlet Remove-SES2CustomVerificationEmailTemplate leveraging the DeleteCustomVerificationEmailTemplate service API.
    * Added cmdlet Remove-SES2EmailIdentityPolicy leveraging the DeleteEmailIdentityPolicy service API.
    * Added cmdlet Remove-SES2EmailTemplate leveraging the DeleteEmailTemplate service API.
    * Added cmdlet Send-SES2BulkEmail leveraging the SendBulkEmail service API.
    * Added cmdlet Send-SES2CustomVerificationEmail leveraging the SendCustomVerificationEmail service API.
    * Added cmdlet Test-SES2RenderEmailTemplate leveraging the TestRenderEmailTemplate service API.
    * Added cmdlet Update-SES2CustomVerificationEmailTemplate leveraging the UpdateCustomVerificationEmailTemplate service API.
    * Added cmdlet Update-SES2EmailIdentityPolicy leveraging the UpdateEmailIdentityPolicy service API.
    * Added cmdlet Update-SES2EmailTemplate leveraging the UpdateEmailTemplate service API.
    * Added cmdlet Write-SES2AccountDetail leveraging the PutAccountDetails service API.
    * Modified cmdlet New-SES2DeliverabilityTestReport: added parameter Template_TemplateName.
    * Modified cmdlet Send-SES2Email: added parameters FeedbackForwardingEmailAddressIdentityArn, FromEmailAddressIdentityArn and Template_TemplateName.
  * Amazon Simple Queue Service (SQS)
    * Modified cmdlet Get-SQSDeadLetterSourceQueue: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-SQSQueue: added parameters MaxResult and NextToken.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGNFSFileShare: added parameters CacheAttributes_CacheStaleTimeoutInSecond and FileShareName.
    * Modified cmdlet New-SGSMBFileShare: added parameters CacheAttributes_CacheStaleTimeoutInSecond, CaseSensitivity and FileShareName.
    * Modified cmdlet Update-SGNFSFileShare: added parameters CacheAttributes_CacheStaleTimeoutInSecond and FileShareName.
    * Modified cmdlet Update-SGSMBFileShare: added parameters CacheAttributes_CacheStaleTimeoutInSecond, CaseSensitivity and FileShareName.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMMaintenanceWindow: added parameter ScheduleOffset.
    * Modified cmdlet Update-SSMMaintenanceWindow: added parameter ScheduleOffset.
  * Amazon Transcribe Service
    * Added cmdlet Get-TRSLanguageModel leveraging the DescribeLanguageModel service API.
    * Added cmdlet Get-TRSLanguageModelList leveraging the ListLanguageModels service API.
    * Added cmdlet New-TRSLanguageModel leveraging the CreateLanguageModel service API.
    * Added cmdlet Remove-TRSLanguageModel leveraging the DeleteLanguageModel service API.
    * Modified cmdlet Start-TRSTranscriptionJob: added parameter ModelSettings_LanguageModelName.
  * Amazon Transfer for SFTP
    * Added cmdlet Get-TFRSecurityPolicy leveraging the DescribeSecurityPolicy service API.
    * Added cmdlet Get-TFRSecurityPolicyList leveraging the ListSecurityPolicies service API.
    * Modified cmdlet New-TFRServer: added parameter SecurityPolicyName.
    * Modified cmdlet Update-TFRServer: added parameter SecurityPolicyName.
  * Amazon WAF V2
    * Modified cmdlet Write-WAF2LoggingConfiguration: added parameter LoggingConfiguration_ManagedByFirewallManager.
  * Amazon WorkSpaces
    * Added cmdlet Get-WKSWorkspaceImagePermission leveraging the DescribeWorkspaceImagePermissions service API.
    * Added cmdlet Update-WKSWorkspaceImagePermission leveraging the UpdateWorkspaceImagePermission service API.
    * Modified cmdlet Edit-WKSWorkspaceCreationProperty: added parameter WorkspaceCreationProperties_EnableWorkDoc.
    * Modified cmdlet Get-WKSWorkspaceImage: added parameter ImageType.

### 4.0.6.0 (2020-06-10)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.758.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Modified cmdlet Write-AGIntegration: added parameter TlsConfig_InsecureSkipVerification.
  * Amazon API Gateway V2
    * Added cmdlet Export-AG2Api leveraging the ExportApi service API.
  * Amazon Athena
    * Added cmdlet Get-ATHDatabase leveraging the GetDatabase service API.
    * Added cmdlet Get-ATHDatabasisList leveraging the ListDatabases service API.
    * Added cmdlet Get-ATHDataCatalog leveraging the GetDataCatalog service API.
    * Added cmdlet Get-ATHDataCatalogList leveraging the ListDataCatalogs service API.
    * Added cmdlet Get-ATHTableMetadata leveraging the GetTableMetadata service API.
    * Added cmdlet Get-ATHTableMetadataList leveraging the ListTableMetadata service API.
    * Added cmdlet New-ATHDataCatalog leveraging the CreateDataCatalog service API.
    * Added cmdlet Remove-ATHDataCatalog leveraging the DeleteDataCatalog service API.
    * Added cmdlet Update-ATHDataCatalog leveraging the UpdateDataCatalog service API.
    * Modified cmdlet Start-ATHQueryExecution: added parameter QueryExecutionContext_Catalog.
  * Amazon Backup
    * Added cmdlet Get-BAKRegionSetting leveraging the DescribeRegionSettings service API.
    * Added cmdlet Update-BAKRegionSetting leveraging the UpdateRegionSettings service API.
  * Amazon Chime
    * Added cmdlet Add-CHMAttendee leveraging the TagAttendee service API.
    * Added cmdlet Add-CHMMeeting leveraging the TagMeeting service API.
    * Added cmdlet Add-CHMResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CHMAttendeeTagList leveraging the ListAttendeeTags service API.
    * Added cmdlet Get-CHMMeetingTagList leveraging the ListMeetingTags service API.
    * Added cmdlet Get-CHMProxySession leveraging the GetProxySession service API.
    * Added cmdlet Get-CHMProxySessionList leveraging the ListProxySessions service API.
    * Added cmdlet Get-CHMResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-CHMRetentionSetting leveraging the GetRetentionSettings service API.
    * Added cmdlet Get-CHMVoiceConnectorProxy leveraging the GetVoiceConnectorProxy service API.
    * Added cmdlet Hide-CHMConversationMessage leveraging the RedactConversationMessage service API.
    * Added cmdlet Hide-CHMRoomMessage leveraging the RedactRoomMessage service API.
    * Added cmdlet New-CHMProxySession leveraging the CreateProxySession service API.
    * Added cmdlet Remove-CHMAttendeeTag leveraging the UntagAttendee service API.
    * Added cmdlet Remove-CHMMeetingTag leveraging the UntagMeeting service API.
    * Added cmdlet Remove-CHMProxySession leveraging the DeleteProxySession service API.
    * Added cmdlet Remove-CHMResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-CHMVoiceConnectorProxy leveraging the DeleteVoiceConnectorProxy service API.
    * Added cmdlet Update-CHMProxySession leveraging the UpdateProxySession service API.
    * Added cmdlet Write-CHMRetentionSetting leveraging the PutRetentionSettings service API.
    * Added cmdlet Write-CHMVoiceConnectorProxy leveraging the PutVoiceConnectorProxy service API.
    * Modified cmdlet New-CHMAttendee: added parameter Tag.
    * Modified cmdlet New-CHMMeeting: added parameters ExternalMeetingId and Tag.
    * Modified cmdlet Write-CHMVoiceConnectorStreamingConfiguration: added parameter StreamingConfiguration_StreamingNotificationTarget.
  * Amazon Cloud Map
    * Added cmdlet Add-SDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SDResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-SDHttpNamespace: added parameter Tag.
    * Modified cmdlet New-SDPrivateDnsNamespace: added parameter Tag.
    * Modified cmdlet New-SDPublicDnsNamespace: added parameter Tag.
    * Modified cmdlet New-SDService: added parameter Tag.
  * Amazon CloudWatch
    * Modified cmdlet Write-CWInsightRule: added parameter Tag.
  * Amazon CloudWatch Application Insights
    * Modified cmdlet New-CWAIApplication: added parameter CWEMonitorEnabled.
    * Modified cmdlet Update-CWAIApplication: added parameter CWEMonitorEnabled.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLQueryDefinition leveraging the DescribeQueryDefinitions service API.
    * Added cmdlet Remove-CWLQueryDefinition leveraging the DeleteQueryDefinition service API.
    * Added cmdlet Write-CWLQueryDefinition leveraging the PutQueryDefinition service API.
  * Amazon CloudWatch Synthetics. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CWSYN and can be listed using the command 'Get-AWSCmdletName -Service CWSYN'.
  * Amazon CodeArtifact. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CA and can be listed using the command 'Get-AWSCmdletName -Service CA'.
  * Amazon CodeBuild
    * Modified cmdlet New-CBReportGroup: added parameter Tag.
    * Modified cmdlet Update-CBReportGroup: added parameter Tag.
  * Amazon CodeDeploy
    * Added cmdlet Remove-CDResourcesByExternalId leveraging the DeleteResourcesByExternalId service API.
    * Modified cmdlet Get-CDDeploymentList: added parameter ExternalId.
  * Amazon CodeGuru Profiler
    * Added cmdlet Get-CGPPolicy leveraging the GetPolicy service API.
    * Added cmdlet Remove-CGPPermission leveraging the RemovePermission service API.
    * Added cmdlet Write-CGPPermission leveraging the PutPermission service API.
  * Amazon CodeGuru Reviewer
    * Added cmdlet Get-CGRCodeReview leveraging the DescribeCodeReview service API.
    * Added cmdlet Get-CGRCodeReviewList leveraging the ListCodeReviews service API.
    * Added cmdlet Get-CGRRecommendationFeedback leveraging the DescribeRecommendationFeedback service API.
    * Added cmdlet Get-CGRRecommendationFeedbackList leveraging the ListRecommendationFeedback service API.
    * Added cmdlet Get-CGRRecommendationList leveraging the ListRecommendations service API.
    * Added cmdlet Write-CGRRecommendationFeedback leveraging the PutRecommendationFeedback service API.
    * Modified cmdlet Register-CGRRepository: added parameters Bitbucket_ConnectionArn, Bitbucket_Name and Bitbucket_Owner.
  * Amazon CodeStar Connections
    * Added cmdlet Add-CSTCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CSTCResourceTagList leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CSTCResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CSTCConnection: added parameter Tag.
  * Amazon Comprehend Medical
    * Added cmdlet Get-CMPMICD10CMInferenceJob leveraging the DescribeICD10CMInferenceJob service API.
    * Added cmdlet Get-CMPMICD10CMInferenceJobList leveraging the ListICD10CMInferenceJobs service API.
    * Added cmdlet Get-CMPMRxNormInferenceJob leveraging the DescribeRxNormInferenceJob service API.
    * Added cmdlet Get-CMPMRxNormInferenceJobList leveraging the ListRxNormInferenceJobs service API.
    * Added cmdlet Start-CMPMICD10CMInferenceJob leveraging the StartICD10CMInferenceJob service API.
    * Added cmdlet Start-CMPMRxNormInferenceJob leveraging the StartRxNormInferenceJob service API.
    * Added cmdlet Stop-CMPMICD10CMInferenceJob leveraging the StopICD10CMInferenceJob service API.
    * Added cmdlet Stop-CMPMRxNormInferenceJob leveraging the StopRxNormInferenceJob service API.
  * Amazon Compute Optimizer
    * Added cmdlet Export-COAutoScalingGroupRecommendation leveraging the ExportAutoScalingGroupRecommendations service API.
    * Added cmdlet Export-COEC2InstanceRecommendation leveraging the ExportEC2InstanceRecommendations service API.
    * Added cmdlet Get-CORecommendationExportJob leveraging the DescribeRecommendationExportJobs service API.
  * Amazon Cost Explorer
    * Modified cmdlet Get-CECostCategoryDefinitionList: added parameter MaxResult.
    * Modified cmdlet Get-CERightsizingRecommendation: added parameters Configuration_BenefitsConsidered and Configuration_RecommendationTarget.
    * Modified cmdlet Get-CESavingsPlansPurchaseRecommendation: added parameters AccountScope and Filter.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXJob: added parameters Encryption_KmsKeyArn and Encryption_Type.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters NeptuneSettings_ErrorRetryDuration, NeptuneSettings_IamAuthEnabled, NeptuneSettings_MaxFileSize, NeptuneSettings_MaxRetryCount, NeptuneSettings_S3BucketFolder, NeptuneSettings_S3BucketName and NeptuneSettings_ServiceAccessRoleArn.
    * Modified cmdlet Edit-DMSReplicationTask: added parameter TaskData.
    * Modified cmdlet New-DMSEndpoint: added parameters NeptuneSettings_ErrorRetryDuration, NeptuneSettings_IamAuthEnabled, NeptuneSettings_MaxFileSize, NeptuneSettings_MaxRetryCount, NeptuneSettings_S3BucketFolder, NeptuneSettings_S3BucketName and NeptuneSettings_ServiceAccessRoleArn.
    * Modified cmdlet New-DMSReplicationTask: added parameter TaskData.
  * Amazon Detective
    * Added cmdlet Start-DTCTMonitoringMember leveraging the StartMonitoringMember service API.
  * Amazon Direct Connect
    * Added cmdlet Get-DCVirtualInterfaceTestHistoryList leveraging the ListVirtualInterfaceTestHistory service API.
    * Added cmdlet Start-DCBgpFailoverTest leveraging the StartBgpFailoverTest service API.
    * Added cmdlet Stop-DCBgpFailoverTest leveraging the StopBgpFailoverTest service API.
  * Amazon EC2 Container Registry
    * Modified cmdlet Write-ECRImage: added parameter ImageManifestMediaType.
  * Amazon EC2 Container Service
    * Modified cmdlet Update-ECSService: added parameters PlacementConstraint and PlacementStrategy.
  * Amazon EC2 Image Builder
    * Modified cmdlet New-EC2IBComponent: added parameter SupportedOsVersion.
    * Modified cmdlet New-EC2IBImage: added parameter EnhancedImageMetadataEnabled.
    * Modified cmdlet New-EC2IBImagePipeline: added parameter EnhancedImageMetadataEnabled.
    * Modified cmdlet Update-EC2IBImagePipeline: added parameter EnhancedImageMetadataEnabled.
  * Amazon Elastic Beanstalk
    * Added cmdlet Get-EBPlatformBranch leveraging the ListPlatformBranches service API.
    * Added cmdlet Register-EBEnvironmentOperationsRole leveraging the AssociateEnvironmentOperationsRole service API.
    * Added cmdlet Unregister-EBEnvironmentOperationsRole leveraging the DisassociateEnvironmentOperationsRole service API.
    * Modified cmdlet New-EBEnvironment: added parameter OperationsRole.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2InstanceEventNotificationAttribute leveraging the DescribeInstanceEventNotificationAttributes service API.
    * Added cmdlet Register-EC2InstanceEventNotificationAttribute leveraging the RegisterInstanceEventNotificationAttributes service API.
    * Added cmdlet Unregister-EC2InstanceEventNotificationAttribute leveraging the DeregisterInstanceEventNotificationAttributes service API.
    * Modified cmdlet Import-EC2KeyPair: added parameter TagSpecification.
    * Modified cmdlet Edit-EC2SubnetAttribute: added parameters CustomerOwnedIpv4Pool and MapCustomerOwnedIpOnLaunch.
    * Modified cmdlet New-EC2KeyPair: added parameter TagSpecification.
    * Modified cmdlet New-EC2LocalGatewayRouteTableVpcAssociation: added parameter TagSpecification.
    * Modified cmdlet New-EC2PlacementGroup: added parameter TagSpecification.
    * Modified cmdlet Register-EC2ByoipCidr: added parameter PoolTagSpecification.
    * Modified cmdlet Remove-EC2KeyPair: added parameter KeyPairId.
  * Amazon Elastic Inference
    * Added cmdlet Get-EIAccelerator leveraging the DescribeAccelerators service API.
    * Added cmdlet Get-EIAcceleratorOffering leveraging the DescribeAcceleratorOfferings service API.
    * Added cmdlet Get-EIAcceleratorType leveraging the DescribeAcceleratorTypes service API.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Edit-ELB2Listener: added parameter AlpnPolicy.
    * Modified cmdlet New-ELB2Listener: added parameter AlpnPolicy.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMRManagedScalingPolicy leveraging the GetManagedScalingPolicy service API.
    * Added cmdlet Remove-EMRManagedScalingPolicy leveraging the RemoveManagedScalingPolicy service API.
    * Added cmdlet Write-EMRManagedScalingPolicy leveraging the PutManagedScalingPolicy service API.
    * Modified cmdlet Start-EMRJobFlow: added parameters ComputeLimits_MaximumCapacityUnit, ComputeLimits_MaximumOnDemandCapacityUnit, ComputeLimits_MinimumCapacityUnit, ComputeLimits_UnitType and LogEncryptionKmsKeyId.
  * Amazon ElastiCache
    * Added cmdlet Edit-ECGlobalReplicationGroup leveraging the ModifyGlobalReplicationGroup service API.
    * Added cmdlet Get-ECGlobalReplicationGroup leveraging the DescribeGlobalReplicationGroups service API.
    * Added cmdlet New-ECGlobalReplicationGroup leveraging the CreateGlobalReplicationGroup service API.
    * Added cmdlet Remove-ECGlobalReplicationGroup leveraging the DeleteGlobalReplicationGroup service API.
    * Added cmdlet Remove-ECReplicationGroupFromGlobalReplicationGroup leveraging the DisassociateGlobalReplicationGroup service API.
    * Added cmdlet Request-ECGlobalReplicationGroupFailover leveraging the FailoverGlobalReplicationGroup service API.
    * Added cmdlet Request-ECNodeGroupDecreaseInGlobalReplicationGroup leveraging the DecreaseNodeGroupsInGlobalReplicationGroup service API.
    * Added cmdlet Request-ECNodeGroupIncreaseInGlobalReplicationGroup leveraging the IncreaseNodeGroupsInGlobalReplicationGroup service API.
    * Added cmdlet Request-ECSlotRebalanceInGlobalReplicationGroup leveraging the RebalanceSlotsInGlobalReplicationGroup service API.
    * Modified cmdlet Edit-ECReplicationGroup: added parameter MultiAZEnabled.
    * Modified cmdlet New-ECReplicationGroup: added parameters GlobalReplicationGroupId and MultiAZEnabled.
  * Amazon Elasticsearch
    * Added cmdlet Approve-ESInboundCrossClusterSearchConnection leveraging the AcceptInboundCrossClusterSearchConnection service API.
    * Added cmdlet Deny-ESInboundCrossClusterSearchConnection leveraging the RejectInboundCrossClusterSearchConnection service API.
    * Added cmdlet Get-ESDomainsForPackageList leveraging the ListDomainsForPackage service API.
    * Added cmdlet Get-ESInboundCrossClusterSearchConnection leveraging the DescribeInboundCrossClusterSearchConnections service API.
    * Added cmdlet Get-ESOutboundCrossClusterSearchConnection leveraging the DescribeOutboundCrossClusterSearchConnections service API.
    * Added cmdlet Get-ESPackage leveraging the DescribePackages service API.
    * Added cmdlet Get-ESPackagesForDomainList leveraging the ListPackagesForDomain service API.
    * Added cmdlet New-ESOutboundCrossClusterSearchConnection leveraging the CreateOutboundCrossClusterSearchConnection service API.
    * Added cmdlet New-ESPackage leveraging the CreatePackage service API.
    * Added cmdlet Remove-ESInboundCrossClusterSearchConnection leveraging the DeleteInboundCrossClusterSearchConnection service API.
    * Added cmdlet Remove-ESOutboundCrossClusterSearchConnection leveraging the DeleteOutboundCrossClusterSearchConnection service API.
    * Added cmdlet Remove-ESPackage leveraging the DeletePackage service API.
    * Added cmdlet Start-ESAssociatePackage leveraging the AssociatePackage service API.
    * Added cmdlet Start-ESDissociatePackage leveraging the DissociatePackage service API.
  * Amazon Elemental MediaConnect
    * Added cmdlet Add-EMCNFlowSource leveraging the AddFlowSources service API.
    * Added cmdlet Add-EMCNFlowVpcInterface leveraging the AddFlowVpcInterfaces service API.
    * Added cmdlet Remove-EMCNFlowSource leveraging the RemoveFlowSource service API.
    * Added cmdlet Remove-EMCNFlowVpcInterface leveraging the RemoveFlowVpcInterface service API.
    * Added cmdlet Update-EMCNFlow leveraging the UpdateFlow service API.
    * [Breaking Change] Modified cmdlet New-EMCNFlow: the type of parameter Source changed from Amazon.MediaConnect.Model.SetSourceRequest to Amazon.MediaConnect.Model.SetSourceRequest[]; added parameters SourceFailoverConfig_RecoveryWindow, SourceFailoverConfig_State and VpcInterface.
    * Modified cmdlet Update-EMCNFlowOutput: added parameter VpcInterfaceAttachment_VpcInterfaceName.
    * Modified cmdlet Update-EMCNFlowSource: added parameter VpcInterfaceName.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter HopDestination.
    * Modified cmdlet New-EMCJobTemplate: added parameter HopDestination.
    * Modified cmdlet Update-EMCJobTemplate: added parameter HopDestination.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLInputDevice leveraging the DescribeInputDevice service API.
    * Added cmdlet Get-EMLInputDeviceList leveraging the ListInputDevices service API.
    * Added cmdlet Update-EMLInputDevice leveraging the UpdateInputDevice service API.
    * Modified cmdlet New-EMLInput: added parameter InputDevice.
    * Modified cmdlet Update-EMLInput: added parameter InputDevice.
  * Amazon Elemental MediaPackage VOD
    * Added cmdlet Add-EMPVResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMPVResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMPVResourceTag leveraging the UntagResource service API.
    * Added cmdlet Update-EMPVPackagingGroup leveraging the UpdatePackagingGroup service API.
    * Modified cmdlet New-EMPVAsset: added parameter Tag.
    * Modified cmdlet New-EMPVPackagingConfiguration: added parameter Tag.
    * Modified cmdlet New-EMPVPackagingGroup: added parameters Authorization_CdnIdentifierSecret, Authorization_SecretsRoleArn and Tag.
  * Amazon Elemental MediaStore
    * Added cmdlet Get-EMSMetricPolicy leveraging the GetMetricPolicy service API.
    * Added cmdlet Remove-EMSMetricPolicy leveraging the DeleteMetricPolicy service API.
    * Added cmdlet Write-EMSMetricPolicy leveraging the PutMetricPolicy service API.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameters AvailSuppression_Mode and AvailSuppression_Value.
  * Amazon Fraud Detector
    * Added cmdlet Remove-FDDetector leveraging the DeleteDetector service API.
    * Added cmdlet Remove-FDRuleVersion leveraging the DeleteRuleVersion service API.
    * Modified cmdlet New-FDDetectorVersion: added parameter RuleExecutionMode.
    * Modified cmdlet Update-FDDetectorVersion: added parameter RuleExecutionMode.
  * Amazon FSx
    * Modified cmdlet New-FSXFileSystem: added parameter StorageType.
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameter StorageType.
    * Modified cmdlet Update-FSXFileSystem: added parameter StorageCapacity.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLGameServer leveraging the DescribeGameServer service API.
    * Added cmdlet Get-GMLGameServerGroup leveraging the DescribeGameServerGroup service API.
    * Added cmdlet Get-GMLGameServerGroupList leveraging the ListGameServerGroups service API.
    * Added cmdlet Get-GMLGameServerList leveraging the ListGameServers service API.
    * Added cmdlet New-GMLGameServerGroup leveraging the CreateGameServerGroup service API.
    * Added cmdlet Register-GMLGameServer leveraging the RegisterGameServer service API.
    * Added cmdlet Remove-GMLGameServerGroup leveraging the DeleteGameServerGroup service API.
    * Added cmdlet Request-GMLGameServer leveraging the ClaimGameServer service API.
    * Added cmdlet Resume-GMLGameServerGroup leveraging the ResumeGameServerGroup service API.
    * Added cmdlet Suspend-GMLGameServerGroup leveraging the SuspendGameServerGroup service API.
    * Added cmdlet Unregister-GMLGameServer leveraging the DeregisterGameServer service API.
    * Added cmdlet Update-GMLGameServer leveraging the UpdateGameServer service API.
    * Added cmdlet Update-GMLGameServerGroup leveraging the UpdateGameServerGroup service API.
  * Amazon Glue
    * Added cmdlet Stop-GLUEWorkflowRun leveraging the StopWorkflowRun service API.
  * Amazon GuardDuty
    * Added cmdlet Disable-GDOrganizationAdminAccount leveraging the DisableOrganizationAdminAccount service API.
    * Added cmdlet Enable-GDOrganizationAdminAccount leveraging the EnableOrganizationAdminAccount service API.
    * Added cmdlet Get-GDOrganizationAdminAccountList leveraging the ListOrganizationAdminAccounts service API.
    * Added cmdlet Get-GDOrganizationConfiguration leveraging the DescribeOrganizationConfiguration service API.
    * Added cmdlet Update-GDOrganizationConfiguration leveraging the UpdateOrganizationConfiguration service API.
  * Amazon Identity and Access Management
    * Modified cmdlet Request-IAMServiceLastAccessedDetail: added parameter Granularity.
  * Amazon IoT
    * Added cmdlet Get-IOTDimension leveraging the DescribeDimension service API.
    * Added cmdlet Get-IOTDimensionList leveraging the ListDimensions service API.
    * Added cmdlet New-IOTDimension leveraging the CreateDimension service API.
    * Added cmdlet Register-IOTCertificateWithoutCA leveraging the RegisterCertificateWithoutCA service API.
    * Added cmdlet Remove-IOTDimension leveraging the DeleteDimension service API.
    * Added cmdlet Update-IOTDimension leveraging the UpdateDimension service API.
    * [Breaking Change] Modified cmdlet Get-IOTSecurityProfileList: removed parameter PassThru; parameter NextToken doesn't support pipeline ByValue anymore; parameter NextToken cannot be used positionally anymore; added parameter DimensionName.
    * Modified cmdlet New-IOTAuthorizer: added parameter Tag.
    * Modified cmdlet New-IOTDomainConfiguration: added parameter Tag.
    * Modified cmdlet New-IOTPolicy: added parameter Tag.
    * Modified cmdlet New-IOTProvisioningTemplate: added parameters PreProvisioningHook_PayloadVersion and PreProvisioningHook_TargetArn.
    * Modified cmdlet New-IOTRoleAlias: added parameter Tag.
    * Modified cmdlet New-IOTSecurityProfile: added parameter AdditionalMetricsToRetainV2.
    * Modified cmdlet Register-IOTCACertificate: added parameter Tag.
    * Modified cmdlet Update-IOTProvisioningTemplate: added parameters PreProvisioningHook_PayloadVersion, PreProvisioningHook_TargetArn and RemovePreProvisioningHook.
    * Modified cmdlet Update-IOTSecurityProfile: added parameter AdditionalMetricsToRetainV2.
  * Amazon IoT SiteWise. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTSW and can be listed using the command 'Get-AWSCmdletName -Service IOTSW'.
  * Amazon Kendra
    * Added cmdlet Add-KNDRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KNDRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-KNDRDataSource leveraging the DeleteDataSource service API.
    * Added cmdlet Remove-KNDRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-KNDRDataSource: added parameter Tag.
    * Modified cmdlet New-KNDRFaq: added parameter Tag.
    * Modified cmdlet New-KNDRIndex: added parameters ClientToken, Edition and Tag.
    * Modified cmdlet Remove-KNDRDocumentBatch: added parameters DataSourceSyncJobMetricTarget_DataSourceId and DataSourceSyncJobMetricTarget_DataSourceSyncJobId.
    * Modified cmdlet Update-KNDRIndex: added parameters CapacityUnits_QueryCapacityUnit and CapacityUnits_StorageCapacityUnit.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters VpcConfiguration_RoleARN, VpcConfiguration_SecurityGroupId and VpcConfiguration_SubnetId.
  * Amazon Lightsail
    * Modified cmdlet Close-LSInstancePublicPort: added parameters PortInfo_Cidr and PortInfo_CidrListAlias.
    * Modified cmdlet Open-LSInstancePublicPort: added parameters PortInfo_Cidr and PortInfo_CidrListAlias.
  * Amazon Macie 2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MAC2 and can be listed using the command 'Get-AWSCmdletName -Service MAC2'.
  * Amazon Managed Blockchain
    * Added cmdlet Update-MBCMember leveraging the UpdateMember service API.
    * Added cmdlet Update-MBCNode leveraging the UpdateNode service API.
    * Modified cmdlet New-MBCMember: added parameter Cloudwatch_Enabled.
    * Modified cmdlet New-MBCNetwork: added parameter Cloudwatch_Enabled.
    * Modified cmdlet New-MBCNode: added parameter LogPublishingConfiguration_Fabric.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Get-MSKCompatibleKafkaVersion leveraging the GetCompatibleKafkaVersions service API.
    * Added cmdlet Update-MSKClusterKafkaVersion leveraging the UpdateClusterKafkaVersion service API.
  * Amazon Organizations
    * Added cmdlet Get-ORGDelegatedAdministratorList leveraging the ListDelegatedAdministrators service API.
    * Added cmdlet Get-ORGDelegatedServicesForAccountList leveraging the ListDelegatedServicesForAccount service API.
    * Added cmdlet Register-ORGDelegatedAdministrator leveraging the RegisterDelegatedAdministrator service API.
    * Added cmdlet Unregister-ORGDelegatedAdministrator leveraging the DeregisterDelegatedAdministrator service API.
  * Amazon Personalize
    * Added cmdlet Get-PERSFilter leveraging the DescribeFilter service API.
    * Added cmdlet Get-PERSFilterList leveraging the ListFilters service API.
    * Added cmdlet New-PERSFilter leveraging the CreateFilter service API.
    * Added cmdlet Remove-PERSFilter leveraging the DeleteFilter service API.
    * Modified cmdlet New-PERSBatchInferenceJob: added parameter FilterArn.
  * Amazon Personalize Runtime
    * Modified cmdlet Get-PERSRRecommendation: added parameter FilterArn.
  * Amazon Pinpoint
    * Modified cmdlet New-PINCampaign: added parameters CustomDeliveryConfiguration_DeliveryUri, CustomDeliveryConfiguration_EndpointType and CustomMessage_Data.
    * Modified cmdlet Send-PINMessage: added parameter SMSMessage_MediaUrl.
    * Modified cmdlet Send-PINUserMessageBatch: added parameter SMSMessage_MediaUrl.
    * Modified cmdlet Update-PINCampaign: added parameters CustomDeliveryConfiguration_DeliveryUri, CustomDeliveryConfiguration_EndpointType and CustomMessage_Data.
  * Amazon QLDB
    * Added cmdlet Get-QLDBJournalKinesisStream leveraging the DescribeJournalKinesisStream service API.
    * Added cmdlet Get-QLDBJournalKinesisStreamsForLedgerList leveraging the ListJournalKinesisStreamsForLedger service API.
    * Added cmdlet Start-QLDBStreamJournalToKinesi leveraging the StreamJournalToKinesis service API.
    * Added cmdlet Stop-QLDBJournalKinesisStream leveraging the CancelJournalKinesisStream service API.
  * Amazon Redshift
    * Added cmdlet Edit-RSUsageLimit leveraging the ModifyUsageLimit service API.
    * Added cmdlet Get-RSUsageLimit leveraging the DescribeUsageLimits service API.
    * Added cmdlet New-RSUsageLimit leveraging the CreateUsageLimit service API.
    * Added cmdlet Remove-RSUsageLimit leveraging the DeleteUsageLimit service API.
  * Amazon Rekognition
    * Added cmdlet Remove-REKProject leveraging the DeleteProject service API.
    * Added cmdlet Remove-REKProjectVersion leveraging the DeleteProjectVersion service API.
  * Amazon Relational Database Service
    * [Breaking Change] Modified cmdlet Get-RDSExportTask: the type of parameter MaxRecord changed from System.String to System.Int32.
    * Modified cmdlet Get-RDSOrderableDBInstanceOption: added parameter AvailabilityZoneGroup.
  * Amazon Resource Access Manager (RAM)
    * Added cmdlet Get-RAMResourceTypeList leveraging the ListResourceTypes service API.
  * Amazon RoboMaker
    * Modified cmdlet New-ROBOSimulationJob: added parameter Compute_SimulationUnitLimit.
  * Amazon Route 53 Domains
    * Added cmdlet Approve-R53DDomainTransferFromAnotherAwsAccount leveraging the AcceptDomainTransferFromAnotherAwsAccount service API.
    * Added cmdlet Deny-R53DDomainTransferFromAnotherAwsAccount leveraging the RejectDomainTransferFromAnotherAwsAccount service API.
    * Added cmdlet Move-R53DDomainToAnotherAwsAccount leveraging the TransferDomainToAnotherAwsAccount service API.
    * Added cmdlet Stop-R53DDomainTransferToAnotherAwsAccount leveraging the CancelDomainTransferToAnotherAwsAccount service API.
  * Amazon S3 Control
    * Added cmdlet Add-S3CJobTagging leveraging the PutJobTagging service API.
    * Added cmdlet Get-S3CJobTagging leveraging the GetJobTagging service API.
    * Added cmdlet Remove-S3CJobTagging leveraging the DeleteJobTagging service API.
    * Modified cmdlet New-S3CJob: added parameters LegalHold_Status, Retention_Mode, Retention_RetainUntilDate, S3PutObjectRetention_BypassGovernanceRetention and Tag.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpoint: added parameter TargetVariant.
  * Amazon SageMaker Service
    * Modified cmdlet Invoke-SMUiTemplateRendering: added parameter HumanTaskUiArn.
    * [Breaking Change] Modified cmdlet New-SMApp: removed parameter ResourceSpec_EnvironmentArn; added parameter ResourceSpec_SageMakerImageArn.
    * [Breaking Change] Modified cmdlet New-SMFlowDefinition: removed parameter HumanLoopRequestSource_AwsManagedHumanLoopRequestSource; added parameter HumanLoopRequestSource_AwsManagedHumanLoopRequestSource.
    * Modified cmdlet New-SMLabelingJob: added parameter UiConfig_HumanTaskUiArn.
    * Modified cmdlet New-SMProcessingJob: added parameter NetworkConfig_EnableInterContainerTrafficEncryption.
  * Amazon Security Hub
    * Added cmdlet Update-SHUBFindingsBatch leveraging the BatchUpdateFindings service API.
    * Modified cmdlet Enable-SHUBSecurityHub: added parameter EnableDefaultStandard.
  * Amazon Service Catalog
    * Modified cmdlet Get-SCProduct: added parameter Name.
    * Modified cmdlet Get-SCProductAsAdmin: added parameter Name.
    * Modified cmdlet Get-SCProvisioningArtifact: added parameters ProductName and ProvisioningArtifactName.
  * Amazon Shield
    * Added cmdlet Add-SHLDProactiveEngagementDetail leveraging the AssociateProactiveEngagementDetails service API.
    * Added cmdlet Disable-SHLDProactiveEngagement leveraging the DisableProactiveEngagement service API.
    * Added cmdlet Enable-SHLDProactiveEngagement leveraging the EnableProactiveEngagement service API.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGAutomaticTapeCreationPolicy leveraging the ListAutomaticTapeCreationPolicies service API.
    * Added cmdlet Remove-SGAutomaticTapeCreationPolicy leveraging the DeleteAutomaticTapeCreationPolicy service API.
    * Added cmdlet Update-SGAutomaticTapeCreationPolicy leveraging the UpdateAutomaticTapeCreationPolicy service API.
    * Modified cmdlet New-SGSMBFileShare: added parameter AuditDestinationARN.
    * Modified cmdlet Update-SGSMBFileShare: added parameter AuditDestinationARN.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMAssociation: added parameters ApplyOnlyAtCronInterval and SyncCompliance.
    * Modified cmdlet New-SSMResourceDataSync: added parameter DestinationDataSharing_DestinationDataSharingType.
    * Modified cmdlet Update-SSMAssociation: added parameters ApplyOnlyAtCronInterval and SyncCompliance.
    * Modified cmdlet Write-SSMComplianceItem: added parameter UploadType.
    * Modified cmdlet Write-SSMParameter: added parameter DataType.
  * Amazon Transcribe Service
    * Added cmdlet Get-TRSMedicalTranscriptionJob leveraging the GetMedicalTranscriptionJob service API.
    * Added cmdlet Get-TRSMedicalTranscriptionJobList leveraging the ListMedicalTranscriptionJobs service API.
    * Added cmdlet Get-TRSMedicalVocabulary leveraging the GetMedicalVocabulary service API.
    * Added cmdlet Get-TRSMedicalVocabularyList leveraging the ListMedicalVocabularies service API.
    * Added cmdlet New-TRSMedicalVocabulary leveraging the CreateMedicalVocabulary service API.
    * Added cmdlet Remove-TRSMedicalTranscriptionJob leveraging the DeleteMedicalTranscriptionJob service API.
    * Added cmdlet Remove-TRSMedicalVocabulary leveraging the DeleteMedicalVocabulary service API.
    * Added cmdlet Start-TRSMedicalTranscriptionJob leveraging the StartMedicalTranscriptionJob service API.
    * Added cmdlet Update-TRSMedicalVocabulary leveraging the UpdateMedicalVocabulary service API.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameters Certificate and Protocol.
    * Modified cmdlet Test-TFRIdentityProvider: added parameters ServerProtocol and SourceIp.
    * Modified cmdlet Update-TFRServer: added parameters Certificate and Protocol.
  * Amazon WAF
    * Added cmdlet New-WAFWebACLMigrationStack leveraging the CreateWebACLMigrationStack service API.
  * Amazon WAF Regional
    * Added cmdlet New-WAFRWebACLMigrationStack leveraging the CreateWebACLMigrationStack service API.
  * Amazon WAF V2
    * Added cmdlet Get-WAF2PermissionPolicy leveraging the GetPermissionPolicy service API.
    * Added cmdlet Remove-WAF2FirewallManagerRuleGroup leveraging the DeleteFirewallManagerRuleGroups service API.
    * Added cmdlet Remove-WAF2PermissionPolicy leveraging the DeletePermissionPolicy service API.
    * Added cmdlet Write-WAF2PermissionPolicy leveraging the PutPermissionPolicy service API.
  * Amazon WorkLink
    * Added cmdlet Add-WLResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WLResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WLResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-WLFleet: added parameter Tag.
  * Amazon WorkMail
    * Added cmdlet Get-WMDefaultRetentionPolicy leveraging the GetDefaultRetentionPolicy service API.
    * Added cmdlet Remove-WMRetentionPolicy leveraging the DeleteRetentionPolicy service API.
    * Added cmdlet Write-WMRetentionPolicy leveraging the PutRetentionPolicy service API.

### 4.0.5.0 (2020-03-13)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.699.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway V2
    * Added cmdlet Get-AG2VpcLink leveraging the GetVpcLink service API.
    * Added cmdlet Get-AG2VpcLinkList leveraging the GetVpcLinks service API.
    * Added cmdlet New-AG2VpcLink leveraging the CreateVpcLink service API.
    * Added cmdlet Remove-AG2AccessLogSetting leveraging the DeleteAccessLogSettings service API.
    * Added cmdlet Remove-AG2RouteRequestParameter leveraging the DeleteRouteRequestParameter service API.
    * Added cmdlet Remove-AG2VpcLink leveraging the DeleteVpcLink service API.
    * Added cmdlet Update-AG2VpcLink leveraging the UpdateVpcLink service API.
    * Modified cmdlet New-AG2Integration: added parameter TlsConfig_ServerNameToVerify.
    * Modified cmdlet Update-AG2Integration: added parameter TlsConfig_ServerNameToVerify.
  * Amazon App Mesh
    * Modified cmdlet Get-AMSHMesh: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHRoute: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHRouteList: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHVirtualNode: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHVirtualNodeList: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHVirtualRouter: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHVirtualRouterList: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHVirtualService: added parameter MeshOwner.
    * Modified cmdlet Get-AMSHVirtualServiceList: added parameter MeshOwner.
    * Modified cmdlet New-AMSHRoute: added parameter MeshOwner.
    * Modified cmdlet New-AMSHVirtualNode: added parameters Acm_CertificateAuthorityArn, File_CertificateChain, MeshOwner, Tls_Enforce and Tls_Port.
    * Modified cmdlet New-AMSHVirtualRouter: added parameter MeshOwner.
    * Modified cmdlet New-AMSHVirtualService: added parameter MeshOwner.
    * Modified cmdlet Remove-AMSHRoute: added parameter MeshOwner.
    * Modified cmdlet Remove-AMSHVirtualNode: added parameter MeshOwner.
    * Modified cmdlet Remove-AMSHVirtualRouter: added parameter MeshOwner.
    * Modified cmdlet Remove-AMSHVirtualService: added parameter MeshOwner.
    * Modified cmdlet Update-AMSHRoute: added parameter MeshOwner.
    * Modified cmdlet Update-AMSHVirtualNode: added parameters Acm_CertificateAuthorityArn, File_CertificateChain, MeshOwner, Tls_Enforce and Tls_Port.
    * Modified cmdlet Update-AMSHVirtualRouter: added parameter MeshOwner.
    * Modified cmdlet Update-AMSHVirtualService: added parameter MeshOwner.
  * Amazon AppSync
    * Modified cmdlet New-ASYNGraphqlApi: added parameter XrayEnabled.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameter XrayEnabled.
  * Amazon Augmented AI (A2I) Runtime
    * Modified cmdlet Get-A2IRHumanLoopList: added parameter FlowDefinitionArn.
  * Amazon Auto Scaling
    * Modified cmdlet Write-ASScalingPolicy: added parameter Enabled.
  * Amazon Cloud9
    * Added cmdlet Add-C9ResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-C9ResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-C9ResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-C9EnvironmentEC2: added parameter Tag.
  * Amazon CloudFormation
    * Modified cmdlet New-CFNStackInstance: added parameters DeploymentTargets_Account and DeploymentTargets_OrganizationalUnitId.
    * Modified cmdlet New-CFNStackSet: added parameters AutoDeployment_Enabled, AutoDeployment_RetainStacksOnAccountRemoval and PermissionModel.
    * Modified cmdlet Remove-CFNStackInstance: added parameters DeploymentTargets_Account and DeploymentTargets_OrganizationalUnitId.
    * Modified cmdlet Update-CFNStackInstance: added parameters DeploymentTargets_Account and DeploymentTargets_OrganizationalUnitId.
    * Modified cmdlet Update-CFNStackSet: added parameters AutoDeployment_Enabled, AutoDeployment_RetainStacksOnAccountRemoval, DeploymentTargets_Account, DeploymentTargets_OrganizationalUnitId and PermissionModel.
  * Amazon CloudWatch
    * Added cmdlet Write-CWCompositeAlarm leveraging the PutCompositeAlarm service API.
    * Modified cmdlet Get-CWAlarm: added parameters AlarmType, ChildrenOfAlarmName and ParentsOfAlarmName.
    * Modified cmdlet Get-CWAlarmHistory: added parameters AlarmType and ScanBy.
  * Amazon CloudWatch Events
    * Modified cmdlet New-CWEEventBus: added parameter Tag.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter FileSystemLocation.
    * Modified cmdlet Update-CBProject: added parameter FileSystemLocation.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter UsernameConfiguration_CaseSensitive.
  * Amazon Config
    * Added cmdlet Select-CFGAggregateResourceConfig leveraging the SelectAggregateResourceConfig service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters KafkaSettings_Broker, KafkaSettings_Topic, KinesisSettings_IncludeControlDetail, KinesisSettings_IncludePartitionValue, KinesisSettings_IncludeTableAlterOperation, KinesisSettings_IncludeTransactionDetail, KinesisSettings_PartitionIncludeSchemaTable and S3Settings_CdcInsertsAndUpdate.
    * Modified cmdlet New-DMSEndpoint: added parameters KafkaSettings_Broker, KafkaSettings_Topic, KinesisSettings_IncludeControlDetail, KinesisSettings_IncludePartitionValue, KinesisSettings_IncludeTableAlterOperation, KinesisSettings_IncludeTransactionDetail, KinesisSettings_PartitionIncludeSchemaTable and S3Settings_CdcInsertsAndUpdate.
  * Amazon DynamoDB
    * Modified cmdlet Restore-DDBTableFromBackup: added parameters SSESpecificationOverride_Enabled, SSESpecificationOverride_KMSMasterKeyId and SSESpecificationOverride_SSEType.
    * Modified cmdlet Restore-DDBTableToPointInTime: added parameters SourceTableArn, SSESpecificationOverride_Enabled, SSESpecificationOverride_KMSMasterKeyId and SSESpecificationOverride_SSEType.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2AvailabilityZoneGroup leveraging the ModifyAvailabilityZoneGroup service API.
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameters SecurityGroupId and VpcId.
    * Modified cmdlet Get-EC2PublicIpv4Pool: added parameter Filter.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameters SecurityGroupId and VpcId.
    * Modified cmdlet New-EC2FlowLog: added parameter TagSpecification.
    * Modified cmdlet New-EC2NatGateway: added parameter TagSpecification.
    * Modified cmdlet New-EC2Volume: added parameter MultiAttachEnabled.
    * Modified cmdlet New-EC2VpcEndpoint: added parameter TagSpecification.
    * Modified cmdlet New-EC2VpcEndpointServiceConfiguration: added parameter TagSpecification.
    * Modified cmdlet Request-EC2SpotFleet: added parameter SpotFleetRequestConfig_TagSpecification.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter EncryptionConfig.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameters AdvancedSecurityOptions_Enabled, AdvancedSecurityOptions_InternalUserDatabaseEnabled, MasterUserOptions_MasterUserARN, MasterUserOptions_MasterUserName and MasterUserOptions_MasterUserPassword.
    * Modified cmdlet Update-ESDomainConfig: added parameters AdvancedSecurityOptions_Enabled, AdvancedSecurityOptions_InternalUserDatabaseEnabled, MasterUserOptions_MasterUserARN, MasterUserOptions_MasterUserName and MasterUserOptions_MasterUserPassword.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLMultiplexProgram: added parameter MultiplexProgramSettings_PreferredChannelPipeline.
    * Modified cmdlet Update-EMLMultiplexProgram: added parameter MultiplexProgramSettings_PreferredChannelPipeline.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter PersonalizationThresholdSecond.
  * Amazon EventBridge
    * Modified cmdlet New-EVBEventBus: added parameter Tag.
  * Amazon Global Accelerator
    * Added cmdlet Add-GACLByoipCidrProvision leveraging the ProvisionByoipCidr service API.
    * Added cmdlet Add-GACLResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GACLByoipCidrList leveraging the ListByoipCidrs service API.
    * Added cmdlet Get-GACLResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-GACLByoipCidrProvision leveraging the DeprovisionByoipCidr service API.
    * Added cmdlet Remove-GACLResourceTag leveraging the UntagResource service API.
    * Added cmdlet Start-GACLAdvertisingByoipCidr leveraging the AdvertiseByoipCidr service API.
    * Added cmdlet Stop-GACLAdvertisingByoipCidr leveraging the WithdrawByoipCidr service API.
    * Modified cmdlet New-GACLAccelerator: added parameters IpAddress and Tag.
  * Amazon Glue
    * Added cmdlet Get-GLUEMLTransformIdentifier leveraging the ListMLTransforms service API.
    * Modified cmdlet New-GLUEJob: added parameter NonOverridableArgument.
    * Modified cmdlet New-GLUEMLTransform: added parameter Tag.
  * Amazon Ground Station
    * Modified cmdlet Get-GSGroundStationList: added parameters PassThru and SatelliteId.
  * Amazon Import/Export Snowball
    * Modified cmdlet New-SNOWCluster: added parameter IND_GSTIN.
    * Modified cmdlet New-SNOWJob: added parameter IND_GSTIN.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameters CloudwatchLogs_LogGroupName and CloudwatchLogs_RoleArn.
    * Modified cmdlet Set-IOTTopicRule: added parameters CloudwatchLogs_LogGroupName and CloudwatchLogs_RoleArn.
  * Amazon Lex Model Building Service
    * Added cmdlet Add-LMBResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-LMBResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-LMBResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Start-LMBImport: added parameter Tag.
    * Modified cmdlet Write-LMBBot: added parameter Tag.
    * Modified cmdlet Write-LMBBotAlias: added parameter Tag.
    * Modified cmdlet Write-LMBSlotType: added parameters ParentSlotTypeSignature and SlotTypeConfiguration.
  * Amazon Lightsail
    * Added cmdlet Add-LSAlarm leveraging the PutAlarm service API.
    * Added cmdlet Get-LSAlarm leveraging the GetAlarms service API.
    * Added cmdlet Get-LSContactMethod leveraging the GetContactMethods service API.
    * Added cmdlet New-LSContactMethod leveraging the CreateContactMethod service API.
    * Added cmdlet Remove-LSAlarm leveraging the DeleteAlarm service API.
    * Added cmdlet Remove-LSContactMethod leveraging the DeleteContactMethod service API.
    * Added cmdlet Send-LSContactMethodVerification leveraging the SendContactMethodVerification service API.
    * Added cmdlet Test-LSAlarm leveraging the TestAlarm service API.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Modified cmdlet New-MSKCluster: added parameters CloudWatchLogs_Enabled, CloudWatchLogs_LogGroup, Firehose_DeliveryStream, Firehose_Enabled, S3_Bucket, S3_Enabled and S3_Prefix.
    * Modified cmdlet Update-MSKMonitoring: added parameters CloudWatchLogs_Enabled, CloudWatchLogs_LogGroup, Firehose_DeliveryStream, Firehose_Enabled, S3_Bucket, S3_Enabled and S3_Prefix.
  * Amazon Neptune
    * Added cmdlet Start-NPTDBCluster leveraging the StartDBCluster service API.
    * Added cmdlet Stop-NPTDBCluster leveraging the StopDBCluster service API.
  * Amazon Outposts
    * Added cmdlet Remove-OUTPOutpost leveraging the DeleteOutpost service API.
    * Added cmdlet Remove-OUTPSite leveraging the DeleteSite service API.
  * Amazon Pinpoint
    * Added cmdlet Get-PINRecommenderConfiguration leveraging the GetRecommenderConfiguration service API.
    * Added cmdlet Get-PINRecommenderConfigurationList leveraging the GetRecommenderConfigurations service API.
    * Added cmdlet New-PINRecommenderConfiguration leveraging the CreateRecommenderConfiguration service API.
    * Added cmdlet Remove-PINRecommenderConfiguration leveraging the DeleteRecommenderConfiguration service API.
    * Added cmdlet Update-PINRecommenderConfiguration leveraging the UpdateRecommenderConfiguration service API.
    * Modified cmdlet New-PINEmailTemplate: added parameter EmailTemplateRequest_RecommenderId.
    * Modified cmdlet New-PINPushTemplate: added parameter PushNotificationTemplateRequest_RecommenderId.
    * Modified cmdlet New-PINSmsTemplate: added parameter SMSTemplateRequest_RecommenderId.
    * Modified cmdlet Update-PINEmailTemplate: added parameter EmailTemplateRequest_RecommenderId.
    * Modified cmdlet Update-PINPushTemplate: added parameter PushNotificationTemplateRequest_RecommenderId.
    * Modified cmdlet Update-PINSmsTemplate: added parameter SMSTemplateRequest_RecommenderId.
  * Amazon QuickSight
    * Added cmdlet Search-QSDashboard leveraging the SearchDashboards service API.
  * Amazon Redshift
    * Added cmdlet Start-RSCluster leveraging the ResumeCluster service API.
    * Added cmdlet Stop-RSCluster leveraging the PauseCluster service API.
    * Modified cmdlet Edit-RSScheduledAction: added parameters PauseCluster_ClusterIdentifier and ResumeCluster_ClusterIdentifier.
    * Modified cmdlet New-RSScheduledAction: added parameters PauseCluster_ClusterIdentifier and ResumeCluster_ClusterIdentifier.
  * Amazon Rekognition
    * Added cmdlet Get-REKTextDetection leveraging the GetTextDetection service API.
    * Added cmdlet Start-REKTextDetection leveraging the StartTextDetection service API.
    * Modified cmdlet Find-REKText: added parameters Filters_RegionsOfInterest, WordFilter_MinBoundingBoxHeight, WordFilter_MinBoundingBoxWidth and WordFilter_MinConfidence.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameters Domain and DomainIAMRoleName.
    * Modified cmdlet New-RDSDBCluster: added parameters Domain and DomainIAMRoleName.
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameters Domain and DomainIAMRoleName.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameters Domain and DomainIAMRoleName.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameters Domain and DomainIAMRoleName.
  * Amazon RoboMaker
    * Added cmdlet Get-ROBOSimulationJobBatch leveraging the DescribeSimulationJobBatch service API.
    * Added cmdlet Get-ROBOSimulationJobBatchList leveraging the ListSimulationJobBatches service API.
    * Added cmdlet Start-ROBOSimulationJobBatch leveraging the StartSimulationJobBatch service API.
    * Added cmdlet Stop-ROBOSimulationJobBatch leveraging the CancelSimulationJobBatch service API.
  * Amazon SageMaker Service
    * Modified cmdlet Get-SMTrialList: added parameter TrialComponentName.
    * Modified cmdlet Update-SMEndpoint: added parameters ExcludeRetainedVariantProperty and RetainAllVariantProperty.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBStandard leveraging the DescribeStandards service API.
  * Amazon Serverless Application Repository
    * Added cmdlet Revoke-SARApplicationSharing leveraging the UnshareApplication service API.
  * Amazon Service Catalog
    * Modified cmdlet Get-SCPortfolioAccessList: added parameters NoAutoIteration, OrganizationParentId, PageSize and PageToken.
  * Amazon Shield
    * Added cmdlet Add-SHLDHealthCheck leveraging the AssociateHealthCheck service API.
    * Added cmdlet Remove-SHLDHealthCheck leveraging the DisassociateHealthCheck service API.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSTranscriptionJob: added parameters ContentRedaction_RedactionOutput and ContentRedaction_RedactionType.
  * Amazon WorkMail
    * Added cmdlet Get-WMAccessControlEffect leveraging the GetAccessControlEffect service API.
    * Added cmdlet Get-WMAccessControlRuleList leveraging the ListAccessControlRules service API.
    * Added cmdlet Remove-WMAccessControlRule leveraging the DeleteAccessControlRule service API.
    * Added cmdlet Write-WMAccessControlRule leveraging the PutAccessControlRule service API.

### 4.0.4.0 (2020-02-05)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.671.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon DataSync
    * Added cmdlet Get-DSYNLocationFsxWindow leveraging the DescribeLocationFsxWindows service API.
    * Added cmdlet New-DSYNLocationFsxWindow leveraging the CreateLocationFsxWindows service API.
  * Amazon EC2 Container Service
    * Modified cmdlet Get-ECSTaskSet: added parameter Include.
    * Modified cmdlet New-ECSTaskSet: added parameter Tag.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2FlowLog: added parameter MaxAggregationInterval.
  * Amazon Identity and Access Management
    * Modified cmdlet Test-IAMCustomPolicy: added parameter PermissionsBoundaryPolicyInputList.
    * Modified cmdlet Test-IAMPrincipalPolicy: added parameter PermissionsBoundaryPolicyInputList.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Get-MSKKafkaVersionList leveraging the ListKafkaVersions service API.
  * Amazon Relational Database Service
    * Added cmdlet Get-RDSExportTask leveraging the DescribeExportTasks service API.
    * Added cmdlet Start-RDSExportTask leveraging the StartExportTask service API.
    * Added cmdlet Stop-RDSExportTask leveraging the CancelExportTask service API.
  * Amazon WorkMail
    * Added cmdlet Add-WMResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WMResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WMResourceTag leveraging the UntagResource service API.

### 4.0.3.0 (2020-01-21)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.668.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Added cmdlet Get-BAKCopyJob leveraging the DescribeCopyJob service API.
    * Added cmdlet Get-BAKCopyJobList leveraging the ListCopyJobs service API.
    * Added cmdlet Start-BAKCopyJob leveraging the StartCopyJob service API.
  * Amazon Chime
    * Added cmdlet Add-CHMSigninDelegateGroupsToAccount leveraging the AssociateSigninDelegateGroupsWithAccount service API.
    * Added cmdlet New-CHMUser leveraging the CreateUser service API.
    * Added cmdlet Remove-CHMSigninDelegateGroupsFromAccount leveraging the DisassociateSigninDelegateGroupsFromAccount service API.
    * Modified cmdlet Get-CHMUserList: added parameter UserType.
    * Modified cmdlet Send-CHMUserInvitation: added parameter UserType.
    * Modified cmdlet Update-CHMUser: added parameters AlexaForBusinessMetadata_AlexaForBusinessRoomArn, AlexaForBusinessMetadata_IsAlexaForBusinessEnabled and UserType.
  * Amazon CloudHSM V2
    * Modified cmdlet Copy-HSM2BackupToRegion: added parameter TagList.
    * Modified cmdlet New-HSM2Cluster: added parameter TagList.
  * Amazon CloudWatch Application Insights
    * Added cmdlet Get-CWAIConfigurationHistoryList leveraging the ListConfigurationHistory service API.
  * Amazon CodeBuild
    * Added cmdlet Get-CBResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Get-CBSharedProjectList leveraging the ListSharedProjects service API.
    * Added cmdlet Get-CBSharedReportGroupList leveraging the ListSharedReportGroups service API.
    * Added cmdlet Remove-CBResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-CBResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet Start-CBBuild: added parameter EncryptionKeyOverride.
  * Amazon CodePipeline
    * Added cmdlet Stop-CPPipelineExecution leveraging the StopPipelineExecution service API.
  * Amazon CodeStar Connections. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CSTC and can be listed using the command 'Get-AWSCmdletName -Service CSTC'.
  * Amazon Comprehend
    * Modified cmdlet New-COMPDocumentClassifier: added parameters InputDataConfig_LabelDelimiter and Mode.
  * Amazon Comprehend Medical
    * Added cmdlet Find-CMPMICD10CM leveraging the InferICD10CM service API.
    * Added cmdlet Find-CMPMRxNorm leveraging the InferRxNorm service API.
  * Amazon Detective. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DTCT and can be listed using the command 'Get-AWSCmdletName -Service DTCT'.
  * Amazon Device Farm
    * Added cmdlet Get-DFTestGridProject leveraging the GetTestGridProject service API.
    * Added cmdlet Get-DFTestGridProjectList leveraging the ListTestGridProjects service API.
    * Added cmdlet Get-DFTestGridSession leveraging the GetTestGridSession service API.
    * Added cmdlet Get-DFTestGridSessionActionList leveraging the ListTestGridSessionActions service API.
    * Added cmdlet Get-DFTestGridSessionArtifactList leveraging the ListTestGridSessionArtifacts service API.
    * Added cmdlet Get-DFTestGridSessionList leveraging the ListTestGridSessions service API.
    * Added cmdlet New-DFTestGridProject leveraging the CreateTestGridProject service API.
    * Added cmdlet New-DFTestGridUrl leveraging the CreateTestGridUrl service API.
    * Added cmdlet Remove-DFTestGridProject leveraging the DeleteTestGridProject service API.
    * Added cmdlet Update-DFTestGridProject leveraging the UpdateTestGridProject service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2AssociatedIpv6PoolCidr leveraging the GetAssociatedIpv6PoolCidrs service API.
    * Added cmdlet Get-EC2Ipv6Pool leveraging the DescribeIpv6Pools service API.
    * Added cmdlet Start-EC2VpcEndpointServicePrivateDnsVerification leveraging the StartVpcEndpointServicePrivateDnsVerification service API.
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameter VpnPort.
    * Modified cmdlet Edit-EC2VpcEndpointServiceConfiguration: added parameters PrivateDnsName and RemovePrivateDnsName.
    * Modified cmdlet Get-EC2EgressOnlyInternetGatewayList: added parameter Filter.
    * Modified cmdlet Get-EC2ExportTask: added parameter Filter.
    * Modified cmdlet Get-EC2KeyPair: added parameter KeyPairId.
    * Modified cmdlet Get-EC2PlacementGroup: added parameter GroupId.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter VpnPort.
    * Modified cmdlet New-EC2Fleet: added parameter CapacityReservationOptions_UsageStrategy.
    * Modified cmdlet New-EC2Vpc: added parameters Ipv6CidrBlock and Ipv6Pool.
    * Modified cmdlet New-EC2VpcEndpointServiceConfiguration: added parameter PrivateDnsName.
    * Modified cmdlet Register-EC2ByoipCidr: added parameter PubliclyAdvertisable.
    * Modified cmdlet Register-EC2VpcCidrBlock: added parameters Ipv6CidrBlock and Ipv6Pool.
  * Amazon Elastic File System
    * Added cmdlet Add-EFSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EFSAccessPoint leveraging the DescribeAccessPoints service API.
    * Added cmdlet Get-EFSFileSystemPolicy leveraging the DescribeFileSystemPolicy service API.
    * Added cmdlet Get-EFSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-EFSAccessPoint leveraging the CreateAccessPoint service API.
    * Added cmdlet Remove-EFSAccessPoint leveraging the DeleteAccessPoint service API.
    * Added cmdlet Remove-EFSFileSystemPolicy leveraging the DeleteFileSystemPolicy service API.
    * Added cmdlet Remove-EFSResourceTag leveraging the UntagResource service API.
    * Added cmdlet Write-EFSFileSystemPolicy leveraging the PutFileSystemPolicy service API.
    * Modified cmdlet Get-EFSMountTarget: added parameter AccessPointId.
  * Amazon Elemental MediaPackage
    * Modified cmdlet New-EMPOriginEndpoint: added parameters Authorization_CdnIdentifierSecret and Authorization_SecretsRoleArn.
    * Modified cmdlet Update-EMPOriginEndpoint: added parameters Authorization_CdnIdentifierSecret and Authorization_SecretsRoleArn.
  * Amazon Firewall Management Service
    * Added cmdlet Add-FMSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-FMSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-FMSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Set-FMSPolicy: added parameter TagList.
  * Amazon FSx
    * Added cmdlet Get-FSXDataRepositoryTask leveraging the DescribeDataRepositoryTasks service API.
    * Added cmdlet New-FSXDataRepositoryTask leveraging the CreateDataRepositoryTask service API.
    * Added cmdlet Stop-FSXDataRepositoryTask leveraging the CancelDataRepositoryTask service API.
  * Amazon GameLift Service
    * Added cmdlet Add-GMLResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GMLResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-GMLResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GMLAlias: added parameter Tag.
    * Modified cmdlet New-GMLBuild: added parameter Tag.
    * Modified cmdlet New-GMLFleet: added parameter Tag.
    * Modified cmdlet New-GMLGameSessionQueue: added parameter Tag.
    * Modified cmdlet New-GMLMatchmakingConfiguration: added parameter Tag.
    * Modified cmdlet New-GMLMatchmakingRuleSet: added parameter Tag.
    * Modified cmdlet New-GMLScript: added parameter Tag.
  * Amazon Health
    * Added cmdlet Disable-HLTHHealthServiceAccessForOrganization leveraging the DisableHealthServiceAccessForOrganization service API.
    * Added cmdlet Enable-HLTHHealthServiceAccessForOrganization leveraging the EnableHealthServiceAccessForOrganization service API.
    * Added cmdlet Get-HLTHAffectedAccountsForOrganization leveraging the DescribeAffectedAccountsForOrganization service API.
    * Added cmdlet Get-HLTHAffectedEntitiesForOrganization leveraging the DescribeAffectedEntitiesForOrganization service API.
    * Added cmdlet Get-HLTHEventDetailsForOrganization leveraging the DescribeEventDetailsForOrganization service API.
    * Added cmdlet Get-HLTHEventsForOrganization leveraging the DescribeEventsForOrganization service API.
    * Added cmdlet Get-HLTHHealthServiceStatusForOrganization leveraging the DescribeHealthServiceStatusForOrganization service API.
  * Amazon IoT
    * Modified cmdlet New-IOTOTAUpdate: added parameters AwsJobPresignedUrlConfig_ExpiresInSec and Protocol.
  * Amazon Lambda
    * Modified cmdlet Update-LMFunctionConfiguration: added parameter IsLayersSet.
  * Amazon Lex Model Building Service
    * Modified cmdlet Write-LMBBotAlias: added parameters ConversationLogs_IamRoleArn and ConversationLogs_LogSetting.
  * Amazon Lightsail
    * Modified cmdlet Update-LSRelationalDatabase: added parameter CaCertificateIdentifier.
  * Amazon Migration Hub
    * Added cmdlet Get-MHApplicationStateList leveraging the ListApplicationStates service API.
  * Amazon MQ
    * Modified cmdlet Get-MQBrokerInstanceOption: added parameter StorageType.
    * Modified cmdlet New-MQBroker: added parameter StorageType.
  * Amazon Neptune
    * Modified cmdlet Edit-NPTDBCluster: added parameter DeletionProtection.
    * Modified cmdlet Edit-NPTDBInstance: added parameter DeletionProtection.
    * Modified cmdlet New-NPTDBCluster: added parameter DeletionProtection.
    * Modified cmdlet New-NPTDBInstance: added parameter DeletionProtection.
    * Modified cmdlet Restore-NPTDBClusterFromSnapshot: added parameter DeletionProtection.
    * Modified cmdlet Restore-NPTDBClusterToPointInTime: added parameter DeletionProtection.
  * Amazon OpsWorksCM
    * Added cmdlet Add-OWCMResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-OWCMResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-OWCMResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-OWCMBackup: added parameter Tag.
    * Modified cmdlet New-OWCMServer: added parameter Tag.
  * Amazon Personalize Runtime
    * Modified cmdlet Get-PERSRPersonalizedRanking: added parameter Context.
    * Modified cmdlet Get-PERSRRecommendation: added parameter Context.
  * Amazon Pinpoint
    * Added cmdlet Get-PINTemplateVersionList leveraging the ListTemplateVersions service API.
    * Added cmdlet Update-PINTemplateActiveVersion leveraging the UpdateTemplateActiveVersion service API.
    * Modified cmdlet Get-PINEmailTemplate: added parameter Version.
    * Modified cmdlet Get-PINPushTemplate: added parameter Version.
    * Modified cmdlet Get-PINSmsTemplate: added parameter Version.
    * Modified cmdlet Get-PINVoiceTemplate: added parameter Version.
    * Modified cmdlet New-PINCampaign: added parameters EmailTemplate_Version, PushTemplate_Version, SMSTemplate_Version and VoiceTemplate_Version.
    * Modified cmdlet Remove-PINEmailTemplate: added parameter Version.
    * Modified cmdlet Remove-PINPushTemplate: added parameter Version.
    * Modified cmdlet Remove-PINSmsTemplate: added parameter Version.
    * Modified cmdlet Remove-PINVoiceTemplate: added parameter Version.
    * Modified cmdlet Send-PINMessage: added parameters EmailTemplate_Version, PushTemplate_Version, SMSTemplate_Version and VoiceTemplate_Version.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters EmailTemplate_Version, PushTemplate_Version, SMSTemplate_Version and VoiceTemplate_Version.
    * Modified cmdlet Update-PINCampaign: added parameters EmailTemplate_Version, PushTemplate_Version, SMSTemplate_Version and VoiceTemplate_Version.
    * Modified cmdlet Update-PINEmailTemplate: added parameters CreateNewVersion and Version.
    * Modified cmdlet Update-PINPushTemplate: added parameters CreateNewVersion and Version.
    * Modified cmdlet Update-PINSmsTemplate: added parameters CreateNewVersion and Version.
    * Modified cmdlet Update-PINVoiceTemplate: added parameters CreateNewVersion and Version.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSCertificate leveraging the ModifyCertificates service API.
    * Modified cmdlet Edit-RDSDBInstance: added parameter CertificateRotationRestart.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMWorkforce leveraging the DescribeWorkforce service API.
    * Added cmdlet Update-SMWorkforce leveraging the UpdateWorkforce service API.
    * Modified cmdlet Get-SMTrialComponentList: added parameters ExperimentName and TrialName.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBStandardsControl leveraging the DescribeStandardsControls service API.
    * Added cmdlet Update-SHUBStandardsControl leveraging the UpdateStandardsControl service API.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Write-SES2EmailIdentityDkimSigningAttribute leveraging the PutEmailIdentityDkimSigningAttributes service API.
    * Modified cmdlet New-SES2EmailIdentity: added parameters DkimSigningAttributes_DomainSigningPrivateKey and DkimSigningAttributes_DomainSigningSelector.
  * Amazon Systems Manager
    * Modified cmdlet Register-SSMTaskWithMaintenanceWindow: added parameters CloudWatchOutputConfig_CloudWatchLogGroupName, CloudWatchOutputConfig_CloudWatchOutputEnabled and RunCommand_DocumentVersion.
    * Modified cmdlet Start-SSMAutomationExecution: added parameter Tag.
    * Modified cmdlet Update-SSMMaintenanceWindowTask: added parameters CloudWatchOutputConfig_CloudWatchLogGroupName, CloudWatchOutputConfig_CloudWatchOutputEnabled and RunCommand_DocumentVersion.
  * Amazon Transcribe Service
    * Added cmdlet Get-TRSVocabularyFilter leveraging the GetVocabularyFilter service API.
    * Added cmdlet Get-TRSVocabularyFilterList leveraging the ListVocabularyFilters service API.
    * Added cmdlet New-TRSVocabularyFilter leveraging the CreateVocabularyFilter service API.
    * Added cmdlet Remove-TRSVocabularyFilter leveraging the DeleteVocabularyFilter service API.
    * Added cmdlet Update-TRSVocabularyFilter leveraging the UpdateVocabularyFilter service API.
    * Modified cmdlet Start-TRSTranscriptionJob: added parameters JobExecutionSettings_AllowDeferredExecution, JobExecutionSettings_DataAccessRoleArn, Settings_VocabularyFilterMethod and Settings_VocabularyFilterName.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameters EndpointDetails_AddressAllocationId, EndpointDetails_SubnetId and EndpointDetails_VpcId.
    * Modified cmdlet Update-TFRServer: added parameters EndpointDetails_AddressAllocationId, EndpointDetails_SubnetId and EndpointDetails_VpcId.
  * Amazon Translate
    * Added cmdlet Get-TRNTextTranslationJob leveraging the DescribeTextTranslationJob service API.
    * Added cmdlet Get-TRNTextTranslationJobList leveraging the ListTextTranslationJobs service API.
    * Added cmdlet Start-TRNTextTranslationJob leveraging the StartTextTranslationJob service API.
    * Added cmdlet Stop-TRNTextTranslationJob leveraging the StopTextTranslationJob service API.
  * Amazon WorkSpaces
    * Added cmdlet Start-WKSWorkspaceMigration leveraging the MigrateWorkspace service API.
