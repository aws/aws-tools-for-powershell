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

