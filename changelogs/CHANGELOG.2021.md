### 4.1.16.0 (2021-11-19)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.164.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify Backend
    * Added cmdlet Get-AMPBBackendStorage leveraging the GetBackendStorage service API.
    * Added cmdlet Get-AMPBS3BucketList leveraging the ListS3Buckets service API.
    * Added cmdlet Import-AMPBBackendStorage leveraging the ImportBackendStorage service API.
    * Added cmdlet New-AMPBBackendStorage leveraging the CreateBackendStorage service API.
    * Added cmdlet Remove-AMPBBackendStorage leveraging the DeleteBackendStorage service API.
    * Added cmdlet Update-AMPBBackendStorage leveraging the UpdateBackendStorage service API.
  * Amazon AppConfig
    * Modified cmdlet Get-APPCConfigurationProfileList: added parameter Type.
    * Modified cmdlet New-APPCConfigurationProfile: added parameter Type.
  * Amazon AppConfig Data. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ACD and can be listed using the command 'Get-AWSCmdletName -Service ACD'.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameter S3InputFormatConfig_S3InputFileType.
    * Modified cmdlet Update-AFFlow: added parameter S3InputFormatConfig_S3InputFileType.
  * Amazon Audit Manager
    * Added cmdlet Get-AUDMAssessmentControlInsightsByControlDomainList leveraging the ListAssessmentControlInsightsByControlDomain service API.
    * Added cmdlet Get-AUDMAssessmentFrameworkShareRequestList leveraging the ListAssessmentFrameworkShareRequests service API.
    * Added cmdlet Get-AUDMControlDomainInsightList leveraging the ListControlDomainInsights service API.
    * Added cmdlet Get-AUDMControlDomainInsightsByAssessmentList leveraging the ListControlDomainInsightsByAssessment service API.
    * Added cmdlet Get-AUDMControlInsightsByControlDomainList leveraging the ListControlInsightsByControlDomain service API.
    * Added cmdlet Get-AUDMInsight leveraging the GetInsights service API.
    * Added cmdlet Get-AUDMInsightsByAssessment leveraging the GetInsightsByAssessment service API.
    * Added cmdlet Remove-AUDMAssessmentFrameworkShare leveraging the DeleteAssessmentFrameworkShare service API.
    * Added cmdlet Start-AUDMAssessmentFrameworkShare leveraging the StartAssessmentFrameworkShare service API.
    * Added cmdlet Update-AUDMAssessmentFrameworkShare leveraging the UpdateAssessmentFrameworkShare service API.
    * Modified cmdlet Get-AUDMAssessmentList: added parameter Status.
  * Amazon Auto Scaling
    * Modified cmdlet Get-ASAutoScalingGroup: added parameter Filter.
    * Modified cmdlet New-ASAutoScalingGroup: added parameter DesiredCapacityType.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter DesiredCapacityType.
  * Amazon Backup
    * Added cmdlet Remove-BAKBackupVaultLockConfiguration leveraging the DeleteBackupVaultLockConfiguration service API.
    * Added cmdlet Write-BAKBackupVaultLockConfiguration leveraging the PutBackupVaultLockConfiguration service API.
    * Modified cmdlet New-BAKBackupSelection: added parameters BackupSelection_NotResource, Conditions_StringEqual, Conditions_StringLike, Conditions_StringNotEqual and Conditions_StringNotLike.
    * Modified cmdlet New-BAKReportPlan: added parameters ReportSetting_FrameworkArn and ReportSetting_NumberOfFramework.
    * Modified cmdlet Update-BAKReportPlan: added parameters ReportSetting_FrameworkArn and ReportSetting_NumberOfFramework.
  * Amazon Batch
    * Added cmdlet Get-BATSchedulingPolicy leveraging the DescribeSchedulingPolicies service API.
    * Added cmdlet Get-BATSchedulingPolicyList leveraging the ListSchedulingPolicies service API.
    * Added cmdlet New-BATSchedulingPolicy leveraging the CreateSchedulingPolicy service API.
    * Added cmdlet Remove-BATSchedulingPolicy leveraging the DeleteSchedulingPolicy service API.
    * Added cmdlet Update-BATSchedulingPolicy leveraging the UpdateSchedulingPolicy service API.
    * Modified cmdlet New-BATComputeEnvironment: added parameter UnmanagedvCpu.
    * Modified cmdlet New-BATJobQueue: added parameter SchedulingPolicyArn.
    * Modified cmdlet Register-BATJobDefinition: added parameter SchedulingPriority.
    * Modified cmdlet Submit-BATJob: added parameters SchedulingPriorityOverride and ShareIdentifier.
    * Modified cmdlet Update-BATComputeEnvironment: added parameter UnmanagedvCpu.
    * Modified cmdlet Update-BATJobQueue: added parameter SchedulingPolicyArn.
  * Amazon Chime
    * Modified cmdlet New-CHMMediaCapturePipeline: added parameters Audio_MuxType, Content_MuxType, Content_State, SelectedVideoStreams_AttendeeId, SelectedVideoStreams_ExternalUserId, Video_MuxType and Video_State.
    * Modified cmdlet Start-CHMMeetingTranscription: added parameters EngineTranscribeMedicalSettings_ContentIdentificationType, EngineTranscribeSettings_ContentIdentificationType, EngineTranscribeSettings_ContentRedactionType, EngineTranscribeSettings_EnablePartialResultsStabilization, EngineTranscribeSettings_LanguageModelName, EngineTranscribeSettings_PartialResultsStability and EngineTranscribeSettings_PiiEntityType.
  * Amazon Chime SDK Identity
    * Added cmdlet Add-CHMIDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CHMIDAppInstanceUserEndpoint leveraging the DescribeAppInstanceUserEndpoint service API.
    * Added cmdlet Get-CHMIDAppInstanceUserEndpointList leveraging the ListAppInstanceUserEndpoints service API.
    * Added cmdlet Get-CHMIDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Register-CHMIDAppInstanceUserEndpoint leveraging the RegisterAppInstanceUserEndpoint service API.
    * Added cmdlet Remove-CHMIDResourceTag leveraging the UntagResource service API.
    * Added cmdlet Unregister-CHMIDAppInstanceUserEndpoint leveraging the DeregisterAppInstanceUserEndpoint service API.
    * Added cmdlet Update-CHMIDAppInstanceUserEndpoint leveraging the UpdateAppInstanceUserEndpoint service API.
  * Amazon Chime SDK Meetings. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CHMTG and can be listed using the command 'Get-AWSCmdletName -Service CHMTG'.
  * Amazon Chime SDK Messaging
    * Added cmdlet Add-CHMMGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CHMMGChannelFlow leveraging the DescribeChannelFlow service API.
    * Added cmdlet Get-CHMMGChannelFlowList leveraging the ListChannelFlows service API.
    * Added cmdlet Get-CHMMGChannelMembershipPreference leveraging the GetChannelMembershipPreferences service API.
    * Added cmdlet Get-CHMMGChannelMessageStatus leveraging the GetChannelMessageStatus service API.
    * Added cmdlet Get-CHMMGChannelsAssociatedWithChannelFlowList leveraging the ListChannelsAssociatedWithChannelFlow service API.
    * Added cmdlet Get-CHMMGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-CHMMGChannelFlow leveraging the CreateChannelFlow service API.
    * Added cmdlet Register-CHMMGChannelFlow leveraging the AssociateChannelFlow service API.
    * Added cmdlet Remove-CHMMGChannelFlow leveraging the DeleteChannelFlow service API.
    * Added cmdlet Remove-CHMMGResourceTag leveraging the UntagResource service API.
    * Added cmdlet Send-CHMMGChannelFlowCallback leveraging the ChannelFlowCallback service API.
    * Added cmdlet Unregister-CHMMGChannelFlow leveraging the DisassociateChannelFlow service API.
    * Added cmdlet Update-CHMMGChannelFlow leveraging the UpdateChannelFlow service API.
    * Added cmdlet Write-CHMMGChannelMembershipPreference leveraging the PutChannelMembershipPreferences service API.
    * Modified cmdlet Send-CHMMGChannelMessage: added parameters MessageAttribute, PushNotification_Body, PushNotification_Title and PushNotification_Type.
  * Amazon CloudFront
    * Added cmdlet Get-CFDistributionsByResponseHeadersPolicyId leveraging the ListDistributionsByResponseHeadersPolicyId service API.
    * Added cmdlet Get-CFResponseHeadersPolicy leveraging the GetResponseHeadersPolicy service API.
    * Added cmdlet Get-CFResponseHeadersPolicyConfig leveraging the GetResponseHeadersPolicyConfig service API.
    * Added cmdlet Get-CFResponseHeadersPolicyList leveraging the ListResponseHeadersPolicies service API.
    * Added cmdlet New-CFResponseHeadersPolicy leveraging the CreateResponseHeadersPolicy service API.
    * Added cmdlet Remove-CFResponseHeadersPolicy leveraging the DeleteResponseHeadersPolicy service API.
    * Added cmdlet Update-CFResponseHeadersPolicy leveraging the UpdateResponseHeadersPolicy service API.
    * Modified cmdlet New-CFDistribution: added parameter DefaultCacheBehavior_ResponseHeadersPolicyId.
    * Modified cmdlet New-CFDistributionWithTag: added parameter DefaultCacheBehavior_ResponseHeadersPolicyId.
    * Modified cmdlet Update-CFDistribution: added parameter DefaultCacheBehavior_ResponseHeadersPolicyId.
  * Amazon CloudWatch
    * Modified cmdlet Get-CWAnomalyDetector: added parameter AnomalyDetectorType.
    * Modified cmdlet Remove-CWAnomalyDetector: added parameters MetricMathAnomalyDetector_MetricDataQuery, SingleMetricAnomalyDetector_Dimension, SingleMetricAnomalyDetector_MetricName, SingleMetricAnomalyDetector_Namespace and SingleMetricAnomalyDetector_Stat.
    * Modified cmdlet Write-CWAnomalyDetector: added parameters MetricMathAnomalyDetector_MetricDataQuery, SingleMetricAnomalyDetector_Dimension, SingleMetricAnomalyDetector_MetricName, SingleMetricAnomalyDetector_Namespace and SingleMetricAnomalyDetector_Stat.
  * Amazon CloudWatch Application Insights
    * Modified cmdlet Get-CWAIProblemList: added parameter ComponentName.
    * Modified cmdlet New-CWAIApplication: added parameters AutoConfigEnabled and AutoCreate.
    * Modified cmdlet Update-CWAIApplication: added parameter AutoConfigEnabled.
    * Modified cmdlet Update-CWAIComponentConfiguration: added parameter AutoConfigEnabled.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter BuildBatchConfig_BatchReportMode.
    * Modified cmdlet Start-CBBatch: added parameter BuildBatchConfigOverride_BatchReportMode.
    * Modified cmdlet Update-CBProject: added parameter BuildBatchConfig_BatchReportMode.
  * Amazon Connect Participant Service
    * Modified cmdlet New-CONNPParticipantConnection: added parameter ConnectParticipant.
  * Amazon Connect Service
    * Added cmdlet Get-CONNContact leveraging the DescribeContact service API.
    * Added cmdlet Get-CONNContactReferenceList leveraging the ListContactReferences service API.
    * Added cmdlet Get-CONNSecurityProfile leveraging the DescribeSecurityProfile service API.
    * Added cmdlet Get-CONNSecurityProfilePermissionList leveraging the ListSecurityProfilePermissions service API.
    * Added cmdlet New-CONNSecurityProfile leveraging the CreateSecurityProfile service API.
    * Added cmdlet Remove-CONNSecurityProfile leveraging the DeleteSecurityProfile service API.
    * Added cmdlet Start-CONNContactStreaming leveraging the StartContactStreaming service API.
    * Added cmdlet Stop-CONNContactStreaming leveraging the StopContactStreaming service API.
    * Added cmdlet Update-CONNContact leveraging the UpdateContact service API.
    * Added cmdlet Update-CONNContactSchedule leveraging the UpdateContactSchedule service API.
    * Added cmdlet Update-CONNSecurityProfile leveraging the UpdateSecurityProfile service API.
    * Modified cmdlet Start-CONNTaskContact: added parameter ScheduledTime.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXJob: added parameters ImportAssetsFromRedshiftDataShares_AssetSource, ImportAssetsFromRedshiftDataShares_DataSetId and ImportAssetsFromRedshiftDataShares_RevisionId.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters GcpMySQLSettings_AfterConnectScript, GcpMySQLSettings_CleanSourceMetadataOnMismatch, GcpMySQLSettings_DatabaseName, GcpMySQLSettings_EventsPollInterval, GcpMySQLSettings_MaxFileSize, GcpMySQLSettings_ParallelLoadThread, GcpMySQLSettings_Password, GcpMySQLSettings_Port, GcpMySQLSettings_SecretsManagerAccessRoleArn, GcpMySQLSettings_SecretsManagerSecretId, GcpMySQLSettings_ServerName, GcpMySQLSettings_ServerTimezone, GcpMySQLSettings_TargetDbType, GcpMySQLSettings_Username and S3Settings_UseTaskStartTimeForFullLoadTimestamp.
    * Modified cmdlet New-DMSEndpoint: added parameters GcpMySQLSettings_AfterConnectScript, GcpMySQLSettings_CleanSourceMetadataOnMismatch, GcpMySQLSettings_DatabaseName, GcpMySQLSettings_EventsPollInterval, GcpMySQLSettings_MaxFileSize, GcpMySQLSettings_ParallelLoadThread, GcpMySQLSettings_Password, GcpMySQLSettings_Port, GcpMySQLSettings_SecretsManagerAccessRoleArn, GcpMySQLSettings_SecretsManagerSecretId, GcpMySQLSettings_ServerName, GcpMySQLSettings_ServerTimezone, GcpMySQLSettings_TargetDbType, GcpMySQLSettings_Username and S3Settings_UseTaskStartTimeForFullLoadTimestamp.
  * Amazon DataSync
    * Added cmdlet Get-DSYNLocationHdf leveraging the DescribeLocationHdfs service API.
    * Added cmdlet New-DSYNLocationHdf leveraging the CreateLocationHdfs service API.
    * Added cmdlet Update-DSYNLocationHdf leveraging the UpdateLocationHdfs service API.
  * Amazon DevOps Guru
    * Added cmdlet Get-DGURUOrganizationHealth leveraging the DescribeOrganizationHealth service API.
    * Added cmdlet Get-DGURUOrganizationInsightList leveraging the ListOrganizationInsights service API.
    * Added cmdlet Get-DGURUOrganizationOverview leveraging the DescribeOrganizationOverview service API.
    * Added cmdlet Get-DGURUOrganizationResourceCollectionHealth leveraging the DescribeOrganizationResourceCollectionHealth service API.
    * Added cmdlet Search-DGURUOrganizationInsight leveraging the SearchOrganizationInsights service API.
    * Modified cmdlet Get-DGURUAnomaliesForInsightList: added parameter AccountId.
    * Modified cmdlet Get-DGURUAnomaly: added parameter AccountId.
    * Modified cmdlet Get-DGURUEventList: added parameter AccountId.
    * Modified cmdlet Get-DGURUInsight: added parameter AccountId.
    * Modified cmdlet Get-DGURURecommendationList: added parameter AccountId.
  * Amazon Direct Connect
    * Added cmdlet Confirm-DCCustomerAgreement leveraging the ConfirmCustomerAgreement service API.
    * Added cmdlet Get-DCCustomerMetadata leveraging the DescribeCustomerMetadata service API.
    * Added cmdlet Get-DCRouterConfiguration leveraging the DescribeRouterConfiguration service API.
    * Added cmdlet Update-DCDirectConnectGateway leveraging the UpdateDirectConnectGateway service API.
  * Amazon EC2 Container Service
    * Modified cmdlet Register-ECSTaskDefinition: added parameters RuntimePlatform_CpuArchitecture and RuntimePlatform_OperatingSystemFamily.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2CapacityReservationFleet leveraging the ModifyCapacityReservationFleet service API.
    * Added cmdlet Get-EC2CapacityReservationFleet leveraging the DescribeCapacityReservationFleets service API.
    * Added cmdlet Get-EC2InstanceTypesFromInstanceRequirement leveraging the GetInstanceTypesFromInstanceRequirements service API.
    * Added cmdlet Get-EC2SpotPlacementScore leveraging the GetSpotPlacementScores service API.
    * Added cmdlet New-EC2CapacityReservationFleet leveraging the CreateCapacityReservationFleet service API.
    * Added cmdlet Stop-EC2CapacityReservationFleet leveraging the CancelCapacityReservationFleets service API.
    * Modified cmdlet Edit-EC2CapacityReservation: added parameter AdditionalInfo.
    * Modified cmdlet Edit-EC2Fleet: added parameter TargetCapacitySpecification_TargetCapacityUnitType.
    * Modified cmdlet Edit-EC2ImageAttribute: added parameters OrganizationalUnitArn and OrganizationArn.
    * Modified cmdlet Edit-EC2SubnetAttribute: added parameter EnableDns64.
    * Modified cmdlet New-EC2Fleet: added parameters CapacityRebalance_TerminationDelay and TargetCapacitySpecification_TargetCapacityUnitType.
    * Modified cmdlet New-EC2FlowLog: added parameters DestinationOptions_FileFormat, DestinationOptions_HiveCompatiblePartition and DestinationOptions_PerHourPartition.
    * Modified cmdlet New-EC2Route: added parameter CoreNetworkArn.
    * Modified cmdlet Request-EC2SpotFleet: added parameters CapacityRebalance_TerminationDelay and SpotFleetRequestConfig_TargetCapacityUnitType.
    * Modified cmdlet Set-EC2Route: added parameter CoreNetworkArn.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet Register-EKSCluster: added parameter Tag.
  * Amazon Elastic Disaster Recovery Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EDRS and can be listed using the command 'Get-AWSCmdletName -Service EDRS'.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Get-ELB2SSLPolicy: added parameter LoadBalancerType.
    * Modified cmdlet New-ELB2TargetGroup: added parameter IpAddressType.
  * Amazon Elemental MediaConvert
    * Added cmdlet Get-EMCPolicy leveraging the GetPolicy service API.
    * Added cmdlet Remove-EMCPolicy leveraging the DeletePolicy service API.
    * Added cmdlet Write-EMCPolicy leveraging the PutPolicy service API.
  * Amazon Elemental MediaLive
    * Added cmdlet Request-EMLDevice leveraging the ClaimDevice service API.
  * Amazon Elemental MediaTailor
    * Added cmdlet Get-EMTPrefetchSchedule leveraging the GetPrefetchSchedule service API.
    * Added cmdlet Get-EMTPrefetchScheduleList leveraging the ListPrefetchSchedules service API.
    * Added cmdlet New-EMTPrefetchSchedule leveraging the CreatePrefetchSchedule service API.
    * Added cmdlet Remove-EMTPrefetchSchedule leveraging the DeletePrefetchSchedule service API.
  * Amazon FinSpace User Environment Management Service
    * Modified cmdlet New-FINSPEnvironment: added parameters DataBundle, SuperuserParameters_EmailAddress, SuperuserParameters_FirstName and SuperuserParameters_LastName.
  * Amazon Forecast Service
    * Added cmdlet Get-FRCAutoPredictor leveraging the DescribeAutoPredictor service API.
    * Added cmdlet Get-FRCExplainability leveraging the DescribeExplainability service API.
    * Added cmdlet Get-FRCExplainabilityExport leveraging the DescribeExplainabilityExport service API.
    * Added cmdlet Get-FRCExplainabilityExportList leveraging the ListExplainabilityExports service API.
    * Added cmdlet Get-FRCExplainabilityList leveraging the ListExplainabilities service API.
    * Added cmdlet New-FRCAutoPredictor leveraging the CreateAutoPredictor service API.
    * Added cmdlet New-FRCExplainability leveraging the CreateExplainability service API.
    * Added cmdlet New-FRCExplainabilityExport leveraging the CreateExplainabilityExport service API.
    * Added cmdlet Remove-FRCExplainability leveraging the DeleteExplainability service API.
    * Added cmdlet Remove-FRCExplainabilityExport leveraging the DeleteExplainabilityExport service API.
  * Amazon Fraud Detector
    * Added cmdlet Get-FDBatchImportJob leveraging the GetBatchImportJobs service API.
    * Added cmdlet Get-FDDeleteEventsByEventTypeStatus leveraging the GetDeleteEventsByEventTypeStatus service API.
    * Added cmdlet Get-FDEvent leveraging the GetEvent service API.
    * Added cmdlet New-FDBatchImportJob leveraging the CreateBatchImportJob service API.
    * Added cmdlet Remove-FDBatchImportJob leveraging the DeleteBatchImportJob service API.
    * Added cmdlet Remove-FDEventsByEventType leveraging the DeleteEventsByEventType service API.
    * Added cmdlet Send-FDEvent leveraging the SendEvent service API.
    * Added cmdlet Stop-FDBatchImportJob leveraging the CancelBatchImportJob service API.
    * Added cmdlet Update-FDEventLabel leveraging the UpdateEventLabel service API.
    * Modified cmdlet New-FDModelVersion: added parameters IngestedEventsTimeWindow_EndTime, IngestedEventsTimeWindow_StartTime and LabelSchema_UnlabeledEventsTreatment.
    * Modified cmdlet Remove-FDEvent: added parameter DeleteAuditHistory.
    * Modified cmdlet Update-FDModelVersion: added parameters IngestedEventsTimeWindow_EndTime and IngestedEventsTimeWindow_StartTime.
    * Modified cmdlet Write-FDEventType: added parameter EventIngestion.
  * Amazon FSx
    * Modified cmdlet New-FSXFileSystem: added parameter FileSystemTypeVersion.
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameter FileSystemTypeVersion.
  * Amazon Glue
    * Modified cmdlet New-GLUEConnection: added parameter Tag.
  * Amazon Glue DataBrew
    * Added cmdlet Get-GDBRuleset leveraging the DescribeRuleset service API.
    * Added cmdlet Get-GDBRulesetList leveraging the ListRulesets service API.
    * Added cmdlet New-GDBRuleset leveraging the CreateRuleset service API.
    * Added cmdlet Remove-GDBRuleset leveraging the DeleteRuleset service API.
    * Added cmdlet Update-GDBRuleset leveraging the UpdateRuleset service API.
    * Modified cmdlet New-GDBDataset: added parameters DatabaseInputDefinition_QueryString and Metadata_SourceArn.
    * Modified cmdlet New-GDBProfileJob: added parameters EntityDetectorConfiguration_AllowedStatistic, EntityDetectorConfiguration_EntityType and ValidationConfiguration.
    * Modified cmdlet Send-GDBProjectSessionAction: added parameters ViewFrame_Analytic, ViewFrame_RowRange and ViewFrame_StartRowIndex.
    * Modified cmdlet Update-GDBDataset: added parameters DatabaseInputDefinition_QueryString and Metadata_SourceArn.
    * Modified cmdlet Update-GDBProfileJob: added parameters EntityDetectorConfiguration_AllowedStatistic, EntityDetectorConfiguration_EntityType and ValidationConfiguration.
  * Amazon Interactive Video Service
    * Added cmdlet Get-IVSStreamSession leveraging the GetStreamSession service API.
    * Added cmdlet Get-IVSStreamSessionList leveraging the ListStreamSessions service API.
    * [Breaking Change] Modified cmdlet Get-IVSResourceTag: removed parameters MaxResult and NextToken.
    * Modified cmdlet Get-IVSStreamList: added parameters FilterBy_Health and PassThru.
  * Amazon IoT Wireless
    * Added cmdlet Get-IOTWFuotaTask leveraging the GetFuotaTask service API.
    * Added cmdlet Get-IOTWFuotaTaskList leveraging the ListFuotaTasks service API.
    * Added cmdlet Get-IOTWMulticastGroup leveraging the GetMulticastGroup service API.
    * Added cmdlet Get-IOTWMulticastGroupList leveraging the ListMulticastGroups service API.
    * Added cmdlet Get-IOTWMulticastGroupsByFuotaTaskList leveraging the ListMulticastGroupsByFuotaTask service API.
    * Added cmdlet Get-IOTWMulticastGroupSession leveraging the GetMulticastGroupSession service API.
    * Added cmdlet Get-IOTWResourceEventConfiguration leveraging the GetResourceEventConfiguration service API.
    * Added cmdlet Join-IOTWMulticastGroupWithFuotaTask leveraging the AssociateMulticastGroupWithFuotaTask service API.
    * Added cmdlet Join-IOTWWirelessDeviceWithFuotaTask leveraging the AssociateWirelessDeviceWithFuotaTask service API.
    * Added cmdlet Join-IOTWWirelessDeviceWithMulticastGroup leveraging the AssociateWirelessDeviceWithMulticastGroup service API.
    * Added cmdlet New-IOTWFuotaTask leveraging the CreateFuotaTask service API.
    * Added cmdlet New-IOTWMulticastGroup leveraging the CreateMulticastGroup service API.
    * Added cmdlet Remove-IOTWFuotaTask leveraging the DeleteFuotaTask service API.
    * Added cmdlet Remove-IOTWMulticastGroup leveraging the DeleteMulticastGroup service API.
    * Added cmdlet Send-IOTWDataToMulticastGroup leveraging the SendDataToMulticastGroup service API.
    * Added cmdlet Split-IOTWMulticastGroupFromFuotaTask leveraging the DisassociateMulticastGroupFromFuotaTask service API.
    * Added cmdlet Split-IOTWWirelessDeviceFromFuotaTask leveraging the DisassociateWirelessDeviceFromFuotaTask service API.
    * Added cmdlet Split-IOTWWirelessDeviceFromMulticastGroup leveraging the DisassociateWirelessDeviceFromMulticastGroup service API.
    * Added cmdlet Start-IOTWBulkAssociateWirelessDeviceWithMulticastGroup leveraging the StartBulkAssociateWirelessDeviceWithMulticastGroup service API.
    * Added cmdlet Start-IOTWBulkDisassociateWirelessDeviceFromMulticastGroup leveraging the StartBulkDisassociateWirelessDeviceFromMulticastGroup service API.
    * Added cmdlet Start-IOTWFuotaTask leveraging the StartFuotaTask service API.
    * Added cmdlet Start-IOTWMulticastGroupSession leveraging the StartMulticastGroupSession service API.
    * Added cmdlet Stop-IOTWMulticastGroupSession leveraging the CancelMulticastGroupSession service API.
    * Added cmdlet Update-IOTWFuotaTask leveraging the UpdateFuotaTask service API.
    * Added cmdlet Update-IOTWMulticastGroup leveraging the UpdateMulticastGroup service API.
    * Added cmdlet Update-IOTWResourceEventConfiguration leveraging the UpdateResourceEventConfiguration service API.
    * Modified cmdlet Get-IOTWWirelessDeviceList: added parameters FuotaTaskId and MulticastGroupId.
    * Modified cmdlet New-IOTWWirelessDevice: added parameters FPorts_ClockSync, FPorts_Fuota, FPorts_Multicast and x_GenAppKey.
  * Amazon Kendra
    * Modified cmdlet New-KNDRDataSource: added parameter LanguageCode.
    * Modified cmdlet New-KNDRFaq: added parameter LanguageCode.
    * Modified cmdlet New-KNDRIndex: added parameter UserGroupResolutionConfiguration_UserGroupResolutionMode.
    * Modified cmdlet Update-KNDRDataSource: added parameter LanguageCode.
    * Modified cmdlet Update-KNDRIndex: added parameter UserGroupResolutionConfiguration_UserGroupResolutionMode.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds, AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs, AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled, AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName, AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName, AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint, AmazonopensearchserviceDestinationConfiguration_DomainARN, AmazonopensearchserviceDestinationConfiguration_IndexName, AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod, AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled, AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors, AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds, AmazonopensearchserviceDestinationConfiguration_RoleARN, AmazonopensearchserviceDestinationConfiguration_S3BackupMode, AmazonopensearchserviceDestinationConfiguration_S3Configuration, AmazonopensearchserviceDestinationConfiguration_TypeName, AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN, AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds and AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds.
    * Modified cmdlet Update-KINFDestination: added parameters AmazonopensearchserviceDestinationUpdate_BufferingHints_IntervalInSeconds, AmazonopensearchserviceDestinationUpdate_BufferingHints_SizeInMBs, AmazonopensearchserviceDestinationUpdate_CloudWatchLoggingOptions_Enabled, AmazonopensearchserviceDestinationUpdate_CloudWatchLoggingOptions_LogGroupName, AmazonopensearchserviceDestinationUpdate_CloudWatchLoggingOptions_LogStreamName, AmazonopensearchserviceDestinationUpdate_ClusterEndpoint, AmazonopensearchserviceDestinationUpdate_DomainARN, AmazonopensearchserviceDestinationUpdate_IndexName, AmazonopensearchserviceDestinationUpdate_IndexRotationPeriod, AmazonopensearchserviceDestinationUpdate_ProcessingConfiguration_Enabled, AmazonopensearchserviceDestinationUpdate_ProcessingConfiguration_Processors, AmazonopensearchserviceDestinationUpdate_RetryOptions_DurationInSeconds, AmazonopensearchserviceDestinationUpdate_RoleARN, AmazonopensearchserviceDestinationUpdate_S3Update and AmazonopensearchserviceDestinationUpdate_TypeName.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameter VoiceSettings_Engine.
    * Modified cmdlet New-LMBV2Intent: added parameters FailureResponse_AllowInterrupt, FailureResponse_MessageGroup, FulfillmentUpdatesSpecification_Active, FulfillmentUpdatesSpecification_TimeoutInSecond, StartResponse_AllowInterrupt, StartResponse_DelayInSecond, StartResponse_MessageGroup, SuccessResponse_AllowInterrupt, SuccessResponse_MessageGroup, TimeoutResponse_AllowInterrupt, TimeoutResponse_MessageGroup, UpdateResponse_AllowInterrupt, UpdateResponse_FrequencyInSecond and UpdateResponse_MessageGroup.
    * Modified cmdlet Start-LMBV2Import: added parameter VoiceSettings_Engine.
    * Modified cmdlet Update-LMBV2BotLocale: added parameter VoiceSettings_Engine.
    * Modified cmdlet Update-LMBV2Intent: added parameters FailureResponse_AllowInterrupt, FailureResponse_MessageGroup, FulfillmentUpdatesSpecification_Active, FulfillmentUpdatesSpecification_TimeoutInSecond, StartResponse_AllowInterrupt, StartResponse_DelayInSecond, StartResponse_MessageGroup, SuccessResponse_AllowInterrupt, SuccessResponse_MessageGroup, TimeoutResponse_AllowInterrupt, TimeoutResponse_MessageGroup, UpdateResponse_AllowInterrupt, UpdateResponse_FrequencyInSecond and UpdateResponse_MessageGroup.
  * Amazon Lightsail
    * Modified cmdlet Update-LSBucket: added parameters AccessLogConfig_Destination, AccessLogConfig_Enabled and AccessLogConfig_Prefix.
  * Amazon Location Service
    * Modified cmdlet Edit-LOCTracker: added parameter PositionFiltering.
    * Modified cmdlet New-LOCTracker: added parameter PositionFiltering.
    * Modified cmdlet Search-LOCPlaceIndexForPosition: added parameter Language.
    * Modified cmdlet Search-LOCPlaceIndexForText: added parameter Language.
  * Amazon Macie 2
    * Modified cmdlet New-MAC2CustomDataIdentifier: added parameter SeverityLevel.
  * Amazon Managed Grafana. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MGRF and can be listed using the command 'Get-AWSCmdletName -Service MGRF'.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Update-MSKConnectivity leveraging the UpdateConnectivity service API.
  * Amazon Migration Hub Strategy Recommendations. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MHS and can be listed using the command 'Get-AWSCmdletName -Service MHS'.
  * Amazon Neptune
    * Modified cmdlet Edit-NPTDBCluster: added parameters AllowMajorVersionUpgrade and DBInstanceParameterGroupName.
  * Amazon Network Manager
    * Added cmdlet Get-NMGRNetworkResource leveraging the GetNetworkResources service API.
    * Added cmdlet Get-NMGRNetworkResourceCount leveraging the GetNetworkResourceCounts service API.
    * Added cmdlet Get-NMGRNetworkResourceRelationship leveraging the GetNetworkResourceRelationships service API.
    * Added cmdlet Get-NMGRNetworkRoute leveraging the GetNetworkRoutes service API.
    * Added cmdlet Get-NMGRNetworkTelemetry leveraging the GetNetworkTelemetry service API.
    * Added cmdlet Get-NMGRRouteAnalysis leveraging the GetRouteAnalysis service API.
    * Added cmdlet Start-NMGRRouteAnalysis leveraging the StartRouteAnalysis service API.
    * Added cmdlet Update-NMGRNetworkResourceMetadata leveraging the UpdateNetworkResourceMetadata service API.
  * Amazon Nimble Studio
    * Added cmdlet Start-NSStreamingSession leveraging the StartStreamingSession service API.
    * Added cmdlet Stop-NSStreamingSession leveraging the StopStreamingSession service API.
    * Modified cmdlet New-NSLaunchProfile: added parameter StreamConfiguration_MaxStoppedSessionLengthInMinute.
    * Modified cmdlet Update-NSLaunchProfile: added parameter StreamConfiguration_MaxStoppedSessionLengthInMinute.
  * Amazon Panorama. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PAN and can be listed using the command 'Get-AWSCmdletName -Service PAN'.
  * Amazon QuickSight
    * Added cmdlet Get-QSIpRestriction leveraging the DescribeIpRestriction service API.
    * Added cmdlet Update-QSIpRestriction leveraging the UpdateIpRestriction service API.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameter QSearchBar_InitialTopicId.
    * Modified cmdlet New-QSIngestion: added parameter IngestionType.
  * Amazon Rekognition
    * Added cmdlet Get-REKDataset leveraging the DescribeDataset service API.
    * Added cmdlet Get-REKDatasetEntryList leveraging the ListDatasetEntries service API.
    * Added cmdlet Get-REKDatasetLabelList leveraging the ListDatasetLabels service API.
    * Added cmdlet Invoke-REKDistributeDatasetEntry leveraging the DistributeDatasetEntries service API.
    * Added cmdlet New-REKDataset leveraging the CreateDataset service API.
    * Added cmdlet Remove-REKDataset leveraging the DeleteDataset service API.
    * Added cmdlet Update-REKDatasetEntry leveraging the UpdateDatasetEntries service API.
    * Modified cmdlet Get-REKProject: added parameter ProjectName.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSCustomDBEngineVersion leveraging the ModifyCustomDBEngineVersion service API.
    * Added cmdlet New-RDSCustomDBEngineVersion leveraging the CreateCustomDBEngineVersion service API.
    * Added cmdlet Remove-RDSCustomDBEngineVersion leveraging the DeleteCustomDBEngineVersion service API.
    * Modified cmdlet Edit-RDSDBInstance: added parameters AutomationMode and ResumeFullAutomationModeMinute.
    * Modified cmdlet New-RDSDBInstance: added parameter CustomIamInstanceProfile.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter CustomIamInstanceProfile.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter CustomIamInstanceProfile.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter CustomIamInstanceProfile.
  * Amazon Resilience Hub. Added cmdlets to support the service. Cmdlets for the service have the noun prefix RESH and can be listed using the command 'Get-AWSCmdletName -Service RESH'.
  * Amazon RoboMaker
    * Modified cmdlet New-ROBOSimulationJob: added parameters Compute_ComputeType and Compute_GpuUnitLimit.
  * Amazon Route 53 Resolver
    * Added cmdlet Get-R53RResolverConfig leveraging the GetResolverConfig service API.
    * Added cmdlet Get-R53RResolverConfigList leveraging the ListResolverConfigs service API.
    * Added cmdlet Update-R53RResolverConfig leveraging the UpdateResolverConfig service API.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMDescribeModelPackage leveraging the BatchDescribeModelPackage service API.
    * Added cmdlet Update-SMProject leveraging the UpdateProject service API.
    * Modified cmdlet New-SMDomain: added parameters AppSecurityGroupManagement, DefaultResourceSpec_InstanceType, DefaultResourceSpec_LifecycleConfigArn, DefaultResourceSpec_SageMakerImageArn, DefaultResourceSpec_SageMakerImageVersionArn, DomainSettings_SecurityGroupId, RStudioServerProDomainSettings_DomainExecutionRoleArn, RStudioServerProDomainSettings_RStudioConnectUrl and RStudioServerProDomainSettings_RStudioPackageManagerUrl.
    * Modified cmdlet New-SMEndpoint: added parameters AutoRollbackConfiguration_Alarm, BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond, BlueGreenUpdatePolicy_TerminationWaitInSecond, CanarySize_Type, CanarySize_Value, LinearStepSize_Type, LinearStepSize_Value, TrafficRoutingConfiguration_Type and TrafficRoutingConfiguration_WaitIntervalInSecond.
    * Modified cmdlet New-SMModelPackage: added parameter CustomerMetadataProperty.
    * Modified cmdlet Update-SMDomain: added parameters DefaultResourceSpec_InstanceType, DefaultResourceSpec_LifecycleConfigArn, DefaultResourceSpec_SageMakerImageArn, DefaultResourceSpec_SageMakerImageVersionArn and RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn.
    * Modified cmdlet Update-SMEndpoint: added parameters LinearStepSize_Type, LinearStepSize_Value and RetainDeploymentConfig.
    * Modified cmdlet Update-SMModelPackage: added parameters CustomerMetadataPropertiesToRemove and CustomerMetadataProperty.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBFindingAggregator leveraging the GetFindingAggregator service API.
    * Added cmdlet Get-SHUBFindingAggregatorList leveraging the ListFindingAggregators service API.
    * Added cmdlet New-SHUBFindingAggregator leveraging the CreateFindingAggregator service API.
    * Added cmdlet Remove-SHUBFindingAggregator leveraging the DeleteFindingAggregator service API.
    * Added cmdlet Update-SHUBFindingAggregator leveraging the UpdateFindingAggregator service API.
  * Amazon Simple Notification Service (SNS)
    * Added cmdlet Publish-SNSBatch leveraging the PublishBatch service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3Object: added parameter PartSize.
  * Amazon Storage Gateway
    * Added cmdlet Update-SGSGSMBLocalGroup leveraging the UpdateSMBLocalGroups service API.
    * Modified cmdlet New-SGNFSFileShare: added parameter AuditDestinationARN.
    * Modified cmdlet Update-SGNFSFileShare: added parameter AuditDestinationARN.
  * Amazon Systems Manager
    * Modified cmdlet Start-SSMSession: added parameter Reason.
  * Amazon Textract
    * Added cmdlet Get-TXTExpenseAnalysis leveraging the GetExpenseAnalysis service API.
    * Added cmdlet Start-TXTExpenseAnalysis leveraging the StartExpenseAnalysis service API.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSCallAnalyticsJob: added parameter Settings_LanguageIdSetting.
    * Modified cmdlet Start-TRSTranscriptionJob: added parameter LanguageIdSetting.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter IdentityProviderDetails_Function.
    * Modified cmdlet Update-TFRServer: added parameter IdentityProviderDetails_Function.
  * Amazon Translate
    * Modified cmdlet Import-TRNTerminology: added parameter TerminologyData_Directionality.
    * Modified cmdlet Start-TRNTextTranslationJob: added parameters EncryptionKey_Id and EncryptionKey_Type.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter ImmunityTimeProperty_ImmunityTime.
    * Modified cmdlet Update-WAF2WebACL: added parameter ImmunityTimeProperty_ImmunityTime.
  * Amazon WorkMail
    * Added cmdlet Add-WMMailDomain leveraging the RegisterMailDomain service API.
    * Added cmdlet Get-WMInboundDmarcSetting leveraging the DescribeInboundDmarcSettings service API.
    * Added cmdlet Get-WMMailDomain leveraging the GetMailDomain service API.
    * Added cmdlet Get-WMMailDomainList leveraging the ListMailDomains service API.
    * Added cmdlet Remove-WMMailDomain leveraging the DeregisterMailDomain service API.
    * Added cmdlet Update-WMDefaultMailDomain leveraging the UpdateDefaultMailDomain service API.
    * Added cmdlet Write-WMInboundDmarcSetting leveraging the PutInboundDmarcSettings service API.

### 4.1.15.0 (2021-10-01)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.128.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Account. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ACCT and can be listed using the command 'Get-AWSCmdletName -Service ACCT'.
  * Amazon Amplify Backend
    * Added cmdlet Import-AMPBBackendAuth leveraging the ImportBackendAuth service API.
    * Modified cmdlet New-AMPBBackendAuth: added parameters SignInWithApple_ClientId, SignInWithApple_KeyId, SignInWithApple_PrivateKey and SignInWithApple_TeamId.
    * Modified cmdlet Update-AMPBBackendAuth: added parameters SignInWithApple_ClientId, SignInWithApple_KeyId, SignInWithApple_PrivateKey and SignInWithApple_TeamId.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter OwnershipVerificationCertificateArn.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameters SAPOData_ObjectPath, Veeva_DocumentType, Veeva_IncludeAllVersion, Veeva_IncludeRendition and Veeva_IncludeSourceFile.
    * Modified cmdlet Update-AFFlow: added parameters SAPOData_ObjectPath, Veeva_DocumentType, Veeva_IncludeAllVersion, Veeva_IncludeRendition and Veeva_IncludeSourceFile.
  * Amazon AppIntegrations Service
    * Added cmdlet Get-AISDataIntegration leveraging the GetDataIntegration service API.
    * Added cmdlet Get-AISDataIntegrationAssociationList leveraging the ListDataIntegrationAssociations service API.
    * Added cmdlet Get-AISDataIntegrationList leveraging the ListDataIntegrations service API.
    * Added cmdlet New-AISDataIntegration leveraging the CreateDataIntegration service API.
    * Added cmdlet Remove-AISDataIntegration leveraging the DeleteDataIntegration service API.
    * Added cmdlet Update-AISDataIntegration leveraging the UpdateDataIntegration service API.
  * Amazon AppSync
    * Modified cmdlet New-ASYNDataSource: added parameters OpenSearchServiceConfig_AwsRegion and OpenSearchServiceConfig_Endpoint.
    * Modified cmdlet New-ASYNGraphqlApi: added parameters LambdaAuthorizerConfig_AuthorizerResultTtlInSecond, LambdaAuthorizerConfig_AuthorizerUri and LambdaAuthorizerConfig_IdentityValidationExpression.
    * Modified cmdlet Update-ASYNDataSource: added parameters OpenSearchServiceConfig_AwsRegion and OpenSearchServiceConfig_Endpoint.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameters LambdaAuthorizerConfig_AuthorizerResultTtlInSecond, LambdaAuthorizerConfig_AuthorizerUri and LambdaAuthorizerConfig_IdentityValidationExpression.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter Context.
    * Modified cmdlet Start-ASInstanceRefresh: added parameters DesiredConfiguration_MixedInstancesPolicy, LaunchTemplate_LaunchTemplateId, LaunchTemplate_LaunchTemplateName, LaunchTemplate_Version and Preferences_SkipMatching.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter Context.
  * Amazon Backup
    * Added cmdlet Get-BAKFramework leveraging the DescribeFramework service API.
    * Added cmdlet Get-BAKFrameworkList leveraging the ListFrameworks service API.
    * Added cmdlet Get-BAKReportJob leveraging the DescribeReportJob service API.
    * Added cmdlet Get-BAKReportJobList leveraging the ListReportJobs service API.
    * Added cmdlet Get-BAKReportPlan leveraging the DescribeReportPlan service API.
    * Added cmdlet Get-BAKReportPlanList leveraging the ListReportPlans service API.
    * Added cmdlet New-BAKFramework leveraging the CreateFramework service API.
    * Added cmdlet New-BAKReportPlan leveraging the CreateReportPlan service API.
    * Added cmdlet Remove-BAKFramework leveraging the DeleteFramework service API.
    * Added cmdlet Remove-BAKReportPlan leveraging the DeleteReportPlan service API.
    * Added cmdlet Start-BAKReportJob leveraging the StartReportJob service API.
    * Added cmdlet Update-BAKFramework leveraging the UpdateFramework service API.
    * Added cmdlet Update-BAKReportPlan leveraging the UpdateReportPlan service API.
  * Amazon Batch
    * Modified cmdlet Get-BATJobList: added parameter Filter.
  * Amazon Chime
    * Added cmdlet Get-CHMMediaCapturePipeline leveraging the GetMediaCapturePipeline service API.
    * Added cmdlet Get-CHMMediaCapturePipelineList leveraging the ListMediaCapturePipelines service API.
    * Added cmdlet New-CHMMediaCapturePipeline leveraging the CreateMediaCapturePipeline service API.
    * Added cmdlet Remove-CHMMediaCapturePipeline leveraging the DeleteMediaCapturePipeline service API.
    * Added cmdlet Start-CHMMeetingTranscription leveraging the StartMeetingTranscription service API.
    * Added cmdlet Stop-CHMMeetingTranscription leveraging the StopMeetingTranscription service API.
    * Modified cmdlet New-CHMSipMediaApplicationCall: added parameter SipHeader.
  * Amazon Chime SDK Identity. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CHMID and can be listed using the command 'Get-AWSCmdletName -Service CHMID'.
  * Amazon Chime SDK Messaging. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CHMMG and can be listed using the command 'Get-AWSCmdletName -Service CHMMG'.
  * Amazon Cloud Control API. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CCA and can be listed using the command 'Get-AWSCmdletName -Service CCA'.
  * Amazon Cloud Map
    * Added cmdlet Update-SDHttpNamespace leveraging the UpdateHttpNamespace service API.
    * Added cmdlet Update-SDPrivateDnsNamespace leveraging the UpdatePrivateDnsNamespace service API.
    * Added cmdlet Update-SDPublicDnsNamespace leveraging the UpdatePublicDnsNamespace service API.
    * Modified cmdlet New-SDPrivateDnsNamespace: added parameter SOA_TTL.
    * Modified cmdlet New-SDPublicDnsNamespace: added parameter SOA_TTL.
  * Amazon Cloud9
    * Modified cmdlet New-C9EnvironmentEC2: added parameter DryRun.
    * Modified cmdlet Update-C9Environment: added parameter ManagedCredentialsAction.
  * Amazon CloudFormation
    * Added cmdlet Import-CFNStacksToStackSet leveraging the ImportStacksToStackSet service API.
    * Added cmdlet Undo-CFNStack leveraging the RollbackStack service API.
    * Modified cmdlet New-CFNStackSet: added parameter StackId.
    * Modified cmdlet Start-CFNChangeSet: added parameter DisableRollback.
    * Modified cmdlet Update-CFNStack: added parameter DisableRollback.
  * Amazon CloudFront
    * Added cmdlet Get-CFConflictingAlias leveraging the ListConflictingAliases service API.
    * Added cmdlet Move-CFAlias leveraging the AssociateAlias service API.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet Update-CWSYNCanary: added parameters VisualReference_BaseCanaryRunId and VisualReference_BaseScreenshot.
  * Amazon CodeBuild
    * Added cmdlet Update-CBProjectVisibility leveraging the UpdateProjectVisibility service API.
    * Modified cmdlet New-CBProject: added parameters Artifacts_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * Modified cmdlet Start-CBBatch: added parameters ArtifactsOverride_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * Modified cmdlet Start-CBBuild: added parameters ArtifactsOverride_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * Modified cmdlet Update-CBProject: added parameters Artifacts_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
  * Amazon Comprehend
    * Added cmdlet Get-COMPDocumentClassifierSummaryList leveraging the ListDocumentClassifierSummaries service API.
    * Added cmdlet Get-COMPEntityRecognizerSummaryList leveraging the ListEntityRecognizerSummaries service API.
    * Modified cmdlet Get-COMPDocumentClassifierList: added parameter Filter_DocumentClassifierName.
    * Modified cmdlet Get-COMPEntityRecognizerList: added parameter Filter_RecognizerName.
    * Modified cmdlet New-COMPDocumentClassifier: added parameters InputDataConfig_TestS3Uri and VersionName.
    * Modified cmdlet New-COMPEntityRecognizer: added parameters Annotations_TestS3Uri, Documents_InputFormat, Documents_TestS3Uri and VersionName.
    * Modified cmdlet Start-COMPDocumentClassificationJob: added parameter Tag.
    * Modified cmdlet Start-COMPDominantLanguageDetectionJob: added parameter Tag.
    * Modified cmdlet Start-COMPEntitiesDetectionJob: added parameter Tag.
    * Modified cmdlet Start-COMPEventsDetectionJob: added parameter Tag.
    * Modified cmdlet Start-COMPKeyPhrasesDetectionJob: added parameter Tag.
    * Modified cmdlet Start-COMPPiiEntitiesDetectionJob: added parameter Tag.
    * Modified cmdlet Start-COMPSentimentDetectionJob: added parameter Tag.
    * Modified cmdlet Start-COMPTopicsDetectionJob: added parameter Tag.
    * Modified cmdlet Update-COMPEndpoint: added parameters DesiredDataAccessRoleArn and DesiredModelArn.
  * Amazon Compute Optimizer
    * Added cmdlet Get-COEnrollmentStatusesForOrganization leveraging the GetEnrollmentStatusesForOrganization service API.
    * Modified cmdlet Export-COAutoScalingGroupRecommendation: added parameter RecommendationPreferences_CpuVendorArchitecture.
    * Modified cmdlet Export-COEC2InstanceRecommendation: added parameter RecommendationPreferences_CpuVendorArchitecture.
    * Modified cmdlet Get-COAutoScalingGroupRecommendation: added parameter RecommendationPreferences_CpuVendorArchitecture.
    * Modified cmdlet Get-COEC2InstanceRecommendation: added parameter RecommendationPreferences_CpuVendorArchitecture.
    * Modified cmdlet Get-COEC2RecommendationProjectedMetric: added parameter RecommendationPreferences_CpuVendorArchitecture.
  * Amazon Connect Customer Profiles
    * Modified cmdlet Get-CPFProfileObjectList: added parameters ObjectFilter_KeyName and ObjectFilter_Value.
  * Amazon Connect Service
    * Added cmdlet Get-CONNAgentStatus leveraging the DescribeAgentStatus service API.
    * Added cmdlet Get-CONNAgentStatusList leveraging the ListAgentStatuses service API.
    * Added cmdlet New-CONNAgentStatus leveraging the CreateAgentStatus service API.
    * Added cmdlet New-CONNHoursOfOperation leveraging the CreateHoursOfOperation service API.
    * Added cmdlet Remove-CONNHoursOfOperation leveraging the DeleteHoursOfOperation service API.
    * Added cmdlet Update-CONNAgentStatus leveraging the UpdateAgentStatus service API.
    * Added cmdlet Update-CONNHoursOfOperation leveraging the UpdateHoursOfOperation service API.
    * Modified cmdlet Get-CONNIntegrationAssociationList: added parameter IntegrationType.
    * Modified cmdlet Start-CONNOutboundVoiceContact: added parameters AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt, AnswerMachineDetectionConfig_EnableAnswerMachineDetection, CampaignId and TrafficType.
  * Amazon Connect Wisdom Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix WSDM and can be listed using the command 'Get-AWSCmdletName -Service WSDM'.
  * Amazon Cost Explorer
    * Modified cmdlet New-CECostCategoryDefinition: added parameter SplitChargeRule.
    * Modified cmdlet Update-CECostCategoryDefinition: added parameter SplitChargeRule.
  * Amazon Data Exchange
    * Added cmdlet Get-DTEXEventAction leveraging the GetEventAction service API.
    * Added cmdlet Get-DTEXEventActionList leveraging the ListEventActions service API.
    * Added cmdlet New-DTEXEventAction leveraging the CreateEventAction service API.
    * Added cmdlet Remove-DTEXEventAction leveraging the DeleteEventAction service API.
    * Added cmdlet Update-DTEXEventAction leveraging the UpdateEventAction service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters ExactSetting, KafkaSettings_NoHexPrefix, KinesisSettings_NoHexPrefix, OracleSettings_ExtraArchivedLogDestId, OracleSettings_StandbyDelayTime, OracleSettings_UseBFile, OracleSettings_UseDirectPathFullLoad, OracleSettings_UseLogminerReader, PostgreSQLSettings_HeartbeatEnable, PostgreSQLSettings_HeartbeatFrequency, PostgreSQLSettings_HeartbeatSchema, PostgreSQLSettings_PluginName, RedisSettings_AuthPassword, RedisSettings_AuthType, RedisSettings_AuthUserName, RedisSettings_Port, RedisSettings_ServerName, RedisSettings_SslCaCertificateArn, RedisSettings_SslSecurityProtocol, S3Settings_AddColumnName, S3Settings_CannedAclForObject, S3Settings_CdcMaxBatchInterval, S3Settings_CdcMinFileSize, S3Settings_CsvNullValue, S3Settings_IgnoreHeaderRow, S3Settings_MaxFileSize and S3Settings_Rfc4180.
    * Modified cmdlet Get-DMSResourceTag: added parameter ResourceArnList.
    * Modified cmdlet New-DMSEndpoint: added parameters KafkaSettings_NoHexPrefix, KinesisSettings_NoHexPrefix, OracleSettings_ExtraArchivedLogDestId, OracleSettings_StandbyDelayTime, OracleSettings_UseBFile, OracleSettings_UseDirectPathFullLoad, OracleSettings_UseLogminerReader, PostgreSQLSettings_HeartbeatEnable, PostgreSQLSettings_HeartbeatFrequency, PostgreSQLSettings_HeartbeatSchema, PostgreSQLSettings_PluginName, RedisSettings_AuthPassword, RedisSettings_AuthType, RedisSettings_AuthUserName, RedisSettings_Port, RedisSettings_ServerName, RedisSettings_SslCaCertificateArn, RedisSettings_SslSecurityProtocol, S3Settings_AddColumnName, S3Settings_CannedAclForObject, S3Settings_CdcMaxBatchInterval, S3Settings_CdcMinFileSize, S3Settings_CsvNullValue, S3Settings_IgnoreHeaderRow, S3Settings_MaxFileSize and S3Settings_Rfc4180.
    * Modified cmdlet Restart-DMSReplicationInstance: added parameter ForcePlannedFailover.
  * Amazon DataSync
    * Modified cmdlet New-DSYNTask: added parameter Include.
    * Modified cmdlet Start-DSYNTaskExecution: added parameter Exclude.
    * Modified cmdlet Update-DSYNTask: added parameter Include.
  * Amazon Directory Service
    * Added cmdlet Get-DSClientAuthenticationSetting leveraging the DescribeClientAuthenticationSettings service API.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRImageReplicationStatus leveraging the DescribeImageReplicationStatus service API.
    * Modified cmdlet New-ECRRepository: added parameter RegistryId.
  * Amazon EC2 Image Builder
    * Modified cmdlet New-EC2IBImageRecipe: added parameters AdditionalInstanceConfiguration_UserDataOverride and SystemsManagerAgent_UninstallAfterBuild.
    * Modified cmdlet New-EC2IBInfrastructureConfiguration: added parameters InstanceMetadataOptions_HttpPutResponseHopLimit and InstanceMetadataOptions_HttpToken.
    * Modified cmdlet Update-EC2IBInfrastructureConfiguration: added parameters InstanceMetadataOptions_HttpPutResponseHopLimit and InstanceMetadataOptions_HttpToken.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2InstanceEventWindow leveraging the ModifyInstanceEventWindow service API.
    * Added cmdlet Edit-EC2SecurityGroupRule leveraging the ModifySecurityGroupRules service API.
    * Added cmdlet Get-EC2InstanceEventWindow leveraging the DescribeInstanceEventWindows service API.
    * Added cmdlet Get-EC2SecurityGroupRule leveraging the DescribeSecurityGroupRules service API.
    * Added cmdlet Get-EC2SubnetCidrReservation leveraging the GetSubnetCidrReservations service API.
    * Added cmdlet Get-EC2VpnConnectionDeviceSampleConfiguration leveraging the GetVpnConnectionDeviceSampleConfiguration service API.
    * Added cmdlet Get-EC2VpnConnectionDeviceType leveraging the GetVpnConnectionDeviceTypes service API.
    * Added cmdlet New-EC2InstanceEventWindow leveraging the CreateInstanceEventWindow service API.
    * Added cmdlet New-EC2SubnetCidrReservation leveraging the CreateSubnetCidrReservation service API.
    * Added cmdlet Register-EC2InstanceEventWindow leveraging the AssociateInstanceEventWindow service API.
    * Added cmdlet Remove-EC2InstanceEventWindow leveraging the DeleteInstanceEventWindow service API.
    * Added cmdlet Remove-EC2SubnetCidrReservation leveraging the DeleteSubnetCidrReservation service API.
    * Added cmdlet Unregister-EC2InstanceEventWindow leveraging the DisassociateInstanceEventWindow service API.
    * Modified cmdlet New-EC2Instance: added parameter MetadataOptions_HttpProtocolIpv6.
    * Modified cmdlet Edit-EC2Fleet: added parameter Context.
    * Modified cmdlet Edit-EC2InstanceMetadataOption: added parameter HttpProtocolIpv6.
    * Modified cmdlet Edit-EC2ManagedPrefixList: added parameter MaxEntry.
    * Modified cmdlet Edit-EC2SpotFleetRequest: added parameter Context.
    * Modified cmdlet Grant-EC2SecurityGroupEgress: added parameter TagSpecification.
    * Modified cmdlet Grant-EC2SecurityGroupIngress: added parameter TagSpecification.
    * Modified cmdlet Import-EC2Image: added parameters BootMode and UsageOperation.
    * Modified cmdlet New-EC2Fleet: added parameter Context.
    * Modified cmdlet New-EC2KeyPair: added parameter KeyType.
    * Modified cmdlet New-EC2NetworkInterface: added parameters Ipv4Prefix, Ipv4PrefixCount, Ipv6Prefix and Ipv6PrefixCount.
    * Modified cmdlet New-EC2Volume: added parameter ClientToken.
    * Modified cmdlet Register-EC2Ipv6AddressList: added parameters Ipv6Prefix and Ipv6PrefixCount.
    * Modified cmdlet Register-EC2PrivateIpAddress: added parameters Ipv4Prefix and Ipv4PrefixCount.
    * Modified cmdlet Request-EC2SpotFleet: added parameter SpotFleetRequestConfig_Context.
    * Modified cmdlet Revoke-EC2SecurityGroupEgress: added parameter SecurityGroupRuleId.
    * Modified cmdlet Revoke-EC2SecurityGroupIngress: added parameter SecurityGroupRuleId.
    * Modified cmdlet Unregister-EC2Ipv6AddressList: added parameter Ipv6Prefix.
    * Modified cmdlet Unregister-EC2PrivateIpAddress: added parameter Ipv4Prefix.
    * Modified cmdlet Update-EC2SecurityGroupRuleEgressDescription: added parameter SecurityGroupRuleDescription.
    * Modified cmdlet Update-EC2SecurityGroupRuleIngressDescription: added parameter SecurityGroupRuleDescription.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Register-EKSCluster leveraging the RegisterCluster service API.
    * Added cmdlet Unregister-EKSCluster leveraging the DeregisterCluster service API.
    * Modified cmdlet Get-EKSClusterList: added parameter Include.
    * Modified cmdlet Remove-EKSAddon: added parameter Preserve.
  * Amazon Elastic MapReduce
    * Added cmdlet Find-EMRReleaseLabel leveraging the ListReleaseLabels service API.
    * Added cmdlet Get-EMRAutoTerminationPolicy leveraging the GetAutoTerminationPolicy service API.
    * Added cmdlet Get-EMRReleaseLabel leveraging the DescribeReleaseLabel service API.
    * Added cmdlet Remove-EMRAutoTerminationPolicy leveraging the RemoveAutoTerminationPolicy service API.
    * Added cmdlet Write-EMRAutoTerminationPolicy leveraging the PutAutoTerminationPolicy service API.
    * Modified cmdlet New-EMRStudio: added parameters IdpAuthUrl and IdpRelayStateParameterName.
    * Modified cmdlet Start-EMRJobFlow: added parameter AutoTerminationPolicy_IdleTimeout.
  * Amazon Elasticsearch
    * Modified cmdlet Get-ESDomainNameList: added parameter EngineType.
  * Amazon Elemental MediaTailor
    * Added cmdlet Add-EMTLogsForPlaybackConfiguration leveraging the ConfigureLogsForPlaybackConfiguration service API.
    * Added cmdlet Get-EMTAlertList leveraging the ListAlerts service API.
    * Modified cmdlet New-EMTChannel: added parameters FillerSlate_SourceLocationName and FillerSlate_VodSourceName.
    * Modified cmdlet New-EMTProgram: added parameter Transition_ScheduledStartTimeMilli.
  * Amazon EventBridge Schema Registry
    * Modified cmdlet New-SCHMDiscoverer: added parameter CrossAccount.
    * Modified cmdlet Update-SCHMDiscoverer: added parameter CrossAccount.
  * Amazon Forecast Service
    * Modified cmdlet New-FRCPredictor: added parameter OptimizationMetric.
  * Amazon FSx
    * Added cmdlet Get-FSXStorageVirtualMachine leveraging the DescribeStorageVirtualMachines service API.
    * Added cmdlet Get-FSXVolume leveraging the DescribeVolumes service API.
    * Added cmdlet New-FSXStorageVirtualMachine leveraging the CreateStorageVirtualMachine service API.
    * Added cmdlet New-FSXVolume leveraging the CreateVolume service API.
    * Added cmdlet New-FSXVolumeFromBackup leveraging the CreateVolumeFromBackup service API.
    * Added cmdlet Remove-FSXStorageVirtualMachine leveraging the DeleteStorageVirtualMachine service API.
    * Added cmdlet Remove-FSXVolume leveraging the DeleteVolume service API.
    * Added cmdlet Update-FSXStorageVirtualMachine leveraging the UpdateStorageVirtualMachine service API.
    * Added cmdlet Update-FSXVolume leveraging the UpdateVolume service API.
    * Modified cmdlet New-FSXBackup: added parameter VolumeId.
    * Modified cmdlet New-FSXFileSystem: added parameters DiskIopsConfiguration_Iops, DiskIopsConfiguration_Mode, OntapConfiguration_AutomaticBackupRetentionDay, OntapConfiguration_DailyAutomaticBackupStartTime, OntapConfiguration_DeploymentType, OntapConfiguration_EndpointIpAddressRange, OntapConfiguration_FsxAdminPassword, OntapConfiguration_PreferredSubnetId, OntapConfiguration_RouteTableId, OntapConfiguration_ThroughputCapacity and OntapConfiguration_WeeklyMaintenanceStartTime.
    * Modified cmdlet Update-FSXFileSystem: added parameters OntapConfiguration_AutomaticBackupRetentionDay, OntapConfiguration_DailyAutomaticBackupStartTime, OntapConfiguration_FsxAdminPassword and OntapConfiguration_WeeklyMaintenanceStartTime.
  * Amazon Glue
    * Added cmdlet Get-GLUEBlueprint leveraging the GetBlueprint service API.
    * Added cmdlet Get-GLUEBlueprintBatch leveraging the BatchGetBlueprints service API.
    * Added cmdlet Get-GLUEBlueprintList leveraging the ListBlueprints service API.
    * Added cmdlet Get-GLUEBlueprintRun leveraging the GetBlueprintRun service API.
    * Added cmdlet Get-GLUEBlueprintRunList leveraging the GetBlueprintRuns service API.
    * Added cmdlet New-GLUEBlueprint leveraging the CreateBlueprint service API.
    * Added cmdlet Remove-GLUEBlueprint leveraging the DeleteBlueprint service API.
    * Added cmdlet Start-GLUEBlueprintRun leveraging the StartBlueprintRun service API.
    * Added cmdlet Update-GLUEBlueprint leveraging the UpdateBlueprint service API.
    * Modified cmdlet New-GLUETrigger: added parameters EventBatchingCondition_BatchSize and EventBatchingCondition_BatchWindow.
  * Amazon Glue DataBrew
    * Modified cmdlet New-GDBProfileJob: added parameters Configuration_ColumnStatisticsConfiguration, Configuration_ProfileColumn, DatasetStatisticsConfiguration_IncludedStatistic and DatasetStatisticsConfiguration_Override.
    * Modified cmdlet New-GDBRecipeJob: added parameters DatabaseOutput and DataCatalogOutput.
    * Modified cmdlet Update-GDBProfileJob: added parameters Configuration_ColumnStatisticsConfiguration, Configuration_ProfileColumn, DatasetStatisticsConfiguration_IncludedStatistic and DatasetStatisticsConfiguration_Override.
    * Modified cmdlet Update-GDBRecipeJob: added parameters DatabaseOutput and DataCatalogOutput.
  * Amazon GreengrassV2
    * Modified cmdlet New-GGV2ComponentVersion: added parameter ClientToken.
    * Modified cmdlet New-GGV2Deployment: added parameter ClientToken.
  * Amazon HealthLake
    * Added cmdlet Add-AHLResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AHLFHIRExportJobList leveraging the ListFHIRExportJobs service API.
    * Added cmdlet Get-AHLFHIRImportJobList leveraging the ListFHIRImportJobs service API.
    * Added cmdlet Get-AHLResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-AHLResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-AHLFHIRDatastore: added parameters KmsEncryptionConfig_CmkType, KmsEncryptionConfig_KmsKeyId and Tag.
    * [Breaking Change] Modified cmdlet Start-AHLFHIRExportJob: removed parameter OutputDataConfig_S3Uri; added parameters S3Configuration_KmsKeyId and S3Configuration_S3Uri.
    * Modified cmdlet Start-AHLFHIRImportJob: added parameters S3Configuration_KmsKeyId and S3Configuration_S3Uri.
  * Amazon Import/Export Snowball
    * Modified cmdlet New-SNOWCluster: added parameters NFSOnDeviceService_StorageLimit, NFSOnDeviceService_StorageUnit and RemoteManagement.
    * Modified cmdlet New-SNOWJob: added parameters NFSOnDeviceService_StorageLimit, NFSOnDeviceService_StorageUnit and RemoteManagement.
    * Modified cmdlet Update-SNOWCluster: added parameters NFSOnDeviceService_StorageLimit and NFSOnDeviceService_StorageUnit.
    * Modified cmdlet Update-SNOWJob: added parameters NFSOnDeviceService_StorageLimit and NFSOnDeviceService_StorageUnit.
  * Amazon IoT
    * Added cmdlet Get-IOTBucketsAggregation leveraging the GetBucketsAggregation service API.
    * Added cmdlet Get-IOTFleetMetric leveraging the DescribeFleetMetric service API.
    * Added cmdlet Get-IOTFleetMetricList leveraging the ListFleetMetrics service API.
    * Added cmdlet New-IOTFleetMetric leveraging the CreateFleetMetric service API.
    * Added cmdlet Remove-IOTFleetMetric leveraging the DeleteFleetMetric service API.
    * Added cmdlet Update-IOTFleetMetric leveraging the UpdateFleetMetric service API.
    * Added cmdlet Write-IOTVerificationStateOnViolation leveraging the PutVerificationStateOnViolation service API.
    * Modified cmdlet Get-IOTActiveViolationList: added parameter VerificationState.
    * Modified cmdlet Get-IOTViolationEventList: added parameter VerificationState.
    * Modified cmdlet New-IOTTopicRule: added parameters OpenSearch_Endpoint, OpenSearch_Id, OpenSearch_Index, OpenSearch_RoleArn and OpenSearch_Type.
    * Modified cmdlet Set-IOTTopicRule: added parameters OpenSearch_Endpoint, OpenSearch_Id, OpenSearch_Index, OpenSearch_RoleArn and OpenSearch_Type.
  * Amazon IoT SiteWise
    * Added cmdlet Get-IOTSWStorageConfiguration leveraging the DescribeStorageConfiguration service API.
    * Added cmdlet Write-IOTSWStorageConfiguration leveraging the PutStorageConfiguration service API.
    * Modified cmdlet Get-IOTSWInterpolatedAssetPropertyValue: added parameter IntervalWindowInSecond.
    * Modified cmdlet New-IOTSWGateway: added parameter GreengrassV2_CoreDeviceThingName.
  * Amazon Kendra
    * Added cmdlet Get-KNDRGroupsOlderThanOrderingIdList leveraging the ListGroupsOlderThanOrderingId service API.
    * Added cmdlet Get-KNDRPrincipalMapping leveraging the DescribePrincipalMapping service API.
    * Added cmdlet Remove-KNDRPrincipalMapping leveraging the DeletePrincipalMapping service API.
    * Added cmdlet Write-KNDRPrincipalMapping leveraging the PutPrincipalMapping service API.
    * Modified cmdlet Invoke-KNDRQuery: added parameters UserContext_DataSourceGroup, UserContext_Group and UserContext_UserId.
  * Amazon Key Management Service
    * Modified cmdlet New-KMSKey: added parameter KeySpec.
  * Amazon Lambda
    * Modified cmdlet Publish-LMFunction: added parameter Architecture.
    * Modified cmdlet Update-LMFunctionCode: added parameter Architecture.
    * Modified cmdlet Get-LMLayerList: added parameter CompatibleArchitecture.
    * Modified cmdlet Get-LMLayerVersionList: added parameter CompatibleArchitecture.
    * Modified cmdlet Publish-LMLayerVersion: added parameter CompatibleArchitecture.
  * Amazon Lex Model Building Service
    * Added cmdlet Get-LMBMigration leveraging the GetMigration service API.
    * Added cmdlet Get-LMBMigrationSummaryList leveraging the GetMigrations service API.
    * Added cmdlet Start-LMBMigration leveraging the StartMigration service API.
  * Amazon Lex Model Building V2
    * Added cmdlet Get-LMBV2AggregatedUtteranceList leveraging the ListAggregatedUtterances service API.
    * Added cmdlet Remove-LMBV2Utterance leveraging the DeleteUtterances service API.
    * Modified cmdlet New-LMBV2Intent: added parameters IntentClosingSetting_Active and IntentConfirmationSetting_Active.
    * Modified cmdlet New-LMBV2Slot: added parameter WaitAndContinueSpecification_Active.
    * Modified cmdlet Update-LMBV2Intent: added parameters IntentClosingSetting_Active and IntentConfirmationSetting_Active.
    * Modified cmdlet Update-LMBV2Slot: added parameter WaitAndContinueSpecification_Active.
  * Amazon License Manager
    * Added cmdlet Get-LICMLicenseConversionTask leveraging the GetLicenseConversionTask service API.
    * Added cmdlet Get-LICMLicenseConversionTaskList leveraging the ListLicenseConversionTasks service API.
    * Added cmdlet New-LICMLicenseConversionTaskForResource leveraging the CreateLicenseConversionTaskForResource service API.
  * Amazon Lightsail
    * Added cmdlet Get-LSBucket leveraging the GetBuckets service API.
    * Added cmdlet Get-LSBucketAccessKey leveraging the GetBucketAccessKeys service API.
    * Added cmdlet Get-LSBucketBundle leveraging the GetBucketBundles service API.
    * Added cmdlet Get-LSBucketMetricData leveraging the GetBucketMetricData service API.
    * Added cmdlet New-LSBucket leveraging the CreateBucket service API.
    * Added cmdlet New-LSBucketAccessKey leveraging the CreateBucketAccessKey service API.
    * Added cmdlet Remove-LSBucket leveraging the DeleteBucket service API.
    * Added cmdlet Remove-LSBucketAccessKey leveraging the DeleteBucketAccessKey service API.
    * Added cmdlet Set-LSResourceAccessForBucket leveraging the SetResourceAccessForBucket service API.
    * Added cmdlet Update-LSBucket leveraging the UpdateBucket service API.
    * Added cmdlet Update-LSBucketBundle leveraging the UpdateBucketBundle service API.
  * Amazon Location Service
    * Added cmdlet Edit-LOCGeofenceCollection leveraging the UpdateGeofenceCollection service API.
    * Added cmdlet Edit-LOCMap leveraging the UpdateMap service API.
    * Added cmdlet Edit-LOCPlaceIndex leveraging the UpdatePlaceIndex service API.
    * Added cmdlet Edit-LOCRouteCalculator leveraging the UpdateRouteCalculator service API.
    * Added cmdlet Edit-LOCTracker leveraging the UpdateTracker service API.
  * Amazon Lookout for Equipment
    * Modified cmdlet New-L4EModel: added parameter OffCondition.
  * Amazon Macie 2
    * Added cmdlet Get-MAC2ManagedDataIdentifierList leveraging the ListManagedDataIdentifiers service API.
    * Modified cmdlet New-MAC2ClassificationJob: added parameters ManagedDataIdentifierId and ManagedDataIdentifierSelector.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Update-MSKSecurity leveraging the UpdateSecurity service API.
    * Modified cmdlet New-MSKCluster: added parameters Tls_Enabled and Unauthenticated_Enabled.
  * Amazon Managed Streaming for Kafka Connect. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MSKC and can be listed using the command 'Get-AWSCmdletName -Service MSKC'.
  * Amazon MemoryDB. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MDB and can be listed using the command 'Get-AWSCmdletName -Service MDB'.
  * Amazon MQ
    * Modified cmdlet Update-MQBroker: added parameter MaintenanceWindowStartTime.
  * Amazon Network Firewall
    * Modified cmdlet New-NWFWFirewallPolicy: added parameters FirewallPolicy_StatefulDefaultAction and StatefulEngineOptions_RuleOrder.
    * Modified cmdlet New-NWFWRuleGroup: added parameter StatefulRuleOptions_RuleOrder.
    * Modified cmdlet Update-NWFWFirewallPolicy: added parameters FirewallPolicy_StatefulDefaultAction and StatefulEngineOptions_RuleOrder.
    * Modified cmdlet Update-NWFWRuleGroup: added parameter StatefulRuleOptions_RuleOrder.
  * Amazon Nimble Studio
    * Modified cmdlet Get-NSStreamingSessionList: added parameter OwnedBy.
    * Modified cmdlet New-NSStreamingSession: added parameter OwnedBy.
  * Amazon OpenSearch Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix OS and can be listed using the command 'Get-AWSCmdletName -Service OS'.
  * Amazon Outposts
    * Added cmdlet New-OUTPOrder leveraging the CreateOrder service API.
    * Modified cmdlet Get-OUTPOutpostList: added parameters AvailabilityZoneFilter, AvailabilityZoneIdFilter and LifeCycleStatusFilter.
  * Amazon Pinpoint
    * Added cmdlet Get-PINInAppMessage leveraging the GetInAppMessages service API.
    * Added cmdlet Get-PINInAppTemplate leveraging the GetInAppTemplate service API.
    * Added cmdlet New-PINInAppTemplate leveraging the CreateInAppTemplate service API.
    * Added cmdlet Remove-PINInAppTemplate leveraging the DeleteInAppTemplate service API.
    * Added cmdlet Update-PINInAppTemplate leveraging the UpdateInAppTemplate service API.
    * Modified cmdlet New-PINCampaign: added parameters InAppMessage_Body, InAppMessage_Content, InAppMessage_CustomConfig, InAppMessage_Layout, Limits_Session and WriteCampaignRequest_Priority.
    * Modified cmdlet Update-PINApplicationSettingList: added parameter Limits_Session.
    * Modified cmdlet Update-PINCampaign: added parameters InAppMessage_Body, InAppMessage_Content, InAppMessage_CustomConfig, InAppMessage_Layout, Limits_Session and WriteCampaignRequest_Priority.
  * Amazon Prometheus Service
    * Added cmdlet Add-PROMResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PROMAlertManagerDefinition leveraging the DescribeAlertManagerDefinition service API.
    * Added cmdlet Get-PROMResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-PROMRuleGroupsNamespace leveraging the DescribeRuleGroupsNamespace service API.
    * Added cmdlet Get-PROMRuleGroupsNamespaceList leveraging the ListRuleGroupsNamespaces service API.
    * Added cmdlet New-PROMAlertManagerDefinition leveraging the CreateAlertManagerDefinition service API.
    * Added cmdlet New-PROMRuleGroupsNamespace leveraging the CreateRuleGroupsNamespace service API.
    * Added cmdlet Remove-PROMAlertManagerDefinition leveraging the DeleteAlertManagerDefinition service API.
    * Added cmdlet Remove-PROMResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-PROMRuleGroupsNamespace leveraging the DeleteRuleGroupsNamespace service API.
    * Added cmdlet Write-PROMAlertManagerDefinition leveraging the PutAlertManagerDefinition service API.
    * Added cmdlet Write-PROMRuleGroupsNamespace leveraging the PutRuleGroupsNamespace service API.
    * Modified cmdlet New-PROMWorkspace: added parameter Tag.
  * Amazon QLDB
    * Modified cmdlet New-QLDBLedger: added parameter KmsKey.
    * Modified cmdlet Update-QLDBLedger: added parameter KmsKey.
  * Amazon QuickSight
    * Added cmdlet New-QSEmbedUrlForAnonymousUser leveraging the GenerateEmbedUrlForAnonymousUser service API.
    * Added cmdlet New-QSEmbedUrlForRegisteredUser leveraging the GenerateEmbedUrlForRegisteredUser service API.
    * Modified cmdlet New-QSDataSet: added parameters DataSetUsageConfiguration_DisableUseAsDirectQuerySource, DataSetUsageConfiguration_DisableUseAsImportedSource, RowLevelPermissionDataSet_Status, RowLevelPermissionTagConfiguration_Status and RowLevelPermissionTagConfiguration_TagRule.
    * Modified cmdlet New-QSDataSource: added parameter AmazonOpenSearchParameters_Domain.
    * Modified cmdlet Update-QSDataSet: added parameters DataSetUsageConfiguration_DisableUseAsDirectQuerySource, DataSetUsageConfiguration_DisableUseAsImportedSource, RowLevelPermissionDataSet_Status, RowLevelPermissionTagConfiguration_Status and RowLevelPermissionTagConfiguration_TagRule.
    * Modified cmdlet Update-QSDataSource: added parameter AmazonOpenSearchParameters_Domain.
  * Amazon Redshift
    * Added cmdlet Add-RSDataShareConsumer leveraging the AssociateDataShareConsumer service API.
    * Added cmdlet Approve-RSDataShare leveraging the AuthorizeDataShare service API.
    * Added cmdlet Deny-RSDataShare leveraging the RejectDataShare service API.
    * Added cmdlet Edit-RSAuthenticationProfile leveraging the ModifyAuthenticationProfile service API.
    * Added cmdlet Get-RSAuthenticationProfile leveraging the DescribeAuthenticationProfiles service API.
    * Added cmdlet Get-RSDataShare leveraging the DescribeDataShares service API.
    * Added cmdlet Get-RSDataSharesForConsumer leveraging the DescribeDataSharesForConsumer service API.
    * Added cmdlet Get-RSDataSharesForProducer leveraging the DescribeDataSharesForProducer service API.
    * Added cmdlet New-RSAuthenticationProfile leveraging the CreateAuthenticationProfile service API.
    * Added cmdlet Remove-RSAuthenticationProfile leveraging the DeleteAuthenticationProfile service API.
    * Added cmdlet Remove-RSDataShareConsumer leveraging the DisassociateDataShareConsumer service API.
    * Added cmdlet Revoke-RSDataShare leveraging the DeauthorizeDataShare service API.
  * Amazon Redshift Data API Service
    * Added cmdlet Push-RSDBatchStatement leveraging the BatchExecuteStatement service API.
  * Amazon Rekognition
    * Modified cmdlet Start-REKSegmentDetection: added parameters BlackFrame_MaxPixelThreshold and BlackFrame_MinCoveragePercentage.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter ScalingConfiguration_SecondsBeforeTimeout.
    * Modified cmdlet New-RDSDBCluster: added parameter ScalingConfiguration_SecondsBeforeTimeout.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter ScalingConfiguration_SecondsBeforeTimeout.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter ScalingConfiguration_SecondsBeforeTimeout.
  * Amazon RoboMaker
    * Modified cmdlet New-ROBORobotApplication: added parameter Environment_Uri.
    * Modified cmdlet New-ROBORobotApplicationVersion: added parameters ImageDigest and S3Etag.
    * Modified cmdlet New-ROBOSimulationApplication: added parameter Environment_Uri.
    * Modified cmdlet New-ROBOSimulationApplicationVersion: added parameters ImageDigest and S3Etag.
    * Modified cmdlet Update-ROBORobotApplication: added parameter Environment_Uri.
    * Modified cmdlet Update-ROBOSimulationApplication: added parameter Environment_Uri.
  * Amazon Route 53
    * Modified cmdlet New-R53HealthCheck: added parameter HealthCheckConfig_RoutingControlArn.
  * Amazon Route53 Recovery Cluster. Added cmdlets to support the service. Cmdlets for the service have the noun prefix RRC and can be listed using the command 'Get-AWSCmdletName -Service RRC'.
  * Amazon Route53 Recovery Control Config. Added cmdlets to support the service. Cmdlets for the service have the noun prefix R53RC and can be listed using the command 'Get-AWSCmdletName -Service R53RC'.
  * Amazon Route53 Recovery Readiness. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PD and can be listed using the command 'Get-AWSCmdletName -Service PD'.
  * Amazon S3
    * Added dependency on AWS Common Runtime (CRT) to support S3 Multi-Region Access Points
  * Amazon S3 Control
    * Added cmdlet Get-S3CMultiRegionAccessPoint leveraging the GetMultiRegionAccessPoint service API.
    * Added cmdlet Get-S3CMultiRegionAccessPointList leveraging the ListMultiRegionAccessPoints service API.
    * Added cmdlet Get-S3CMultiRegionAccessPointOperation leveraging the DescribeMultiRegionAccessPointOperation service API.
    * Added cmdlet Get-S3CMultiRegionAccessPointPolicy leveraging the GetMultiRegionAccessPointPolicy service API.
    * Added cmdlet Get-S3CMultiRegionAccessPointPolicyStatus leveraging the GetMultiRegionAccessPointPolicyStatus service API.
    * Added cmdlet New-S3CMultiRegionAccessPoint leveraging the CreateMultiRegionAccessPoint service API.
    * Added cmdlet Remove-S3CMultiRegionAccessPoint leveraging the DeleteMultiRegionAccessPoint service API.
    * Added cmdlet Write-S3CMultiRegionAccessPointPolicy leveraging the PutMultiRegionAccessPointPolicy service API.
  * Amazon S3 Outposts
    * Modified cmdlet New-S3OEndpoint: added parameters AccessType and CustomerOwnedIpv4Pool.
  * Amazon SageMaker Runtime
    * Added cmdlet Invoke-SMREndpointAsync leveraging the InvokeEndpointAsync service API.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMStudioLifecycleConfig leveraging the DescribeStudioLifecycleConfig service API.
    * Added cmdlet Get-SMStudioLifecycleConfigList leveraging the ListStudioLifecycleConfigs service API.
    * Added cmdlet New-SMStudioLifecycleConfig leveraging the CreateStudioLifecycleConfig service API.
    * Added cmdlet Remove-SMStudioLifecycleConfig leveraging the DeleteStudioLifecycleConfig service API.
    * Added cmdlet Restart-SMPipelineExecution leveraging the RetryPipelineExecution service API.
    * Modified cmdlet New-SMApp: added parameter ResourceSpec_LifecycleConfigArn.
    * Modified cmdlet New-SMCompilationJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet New-SMEndpointConfig: added parameters ClientConfig_MaxConcurrentInvocationsPerInstance, NotificationConfig_ErrorTopic, NotificationConfig_SuccessTopic, OutputConfig_KmsKeyId and OutputConfig_S3OutputPath.
    * Modified cmdlet New-SMNotebookInstance: added parameter PlatformIdentifier.
  * Amazon Service Catalog App Registry
    * Added cmdlet Get-SCARAssociatedResource leveraging the GetAssociatedResource service API.
  * Amazon Simple Email Service V2 (SES V2)
    * Modified cmdlet New-SES2EmailIdentity: added parameter DkimSigningAttributes_NextSigningKeyLength.
    * Modified cmdlet Write-SES2EmailIdentityDkimSigningAttribute: added parameter SigningAttributes_NextSigningKeyLength.
  * Amazon Snow Device Management. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SDMS and can be listed using the command 'Get-AWSCmdletName -Service SDMS'.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGNFSFileShare: added parameters BucketRegion and VPCEndpointDNSName.
    * Modified cmdlet New-SGSGFileSystemAssociation: added parameter EndpointNetworkConfiguration_IpAddress.
    * Modified cmdlet New-SGSMBFileShare: added parameters BucketRegion, OplocksEnabled and VPCEndpointDNSName.
    * Modified cmdlet Update-SGGatewayInformation: added parameter GatewayCapacity.
    * Modified cmdlet Update-SGSMBFileShare: added parameter OplocksEnabled.
  * Amazon System Manager Contacts
    * Modified cmdlet Confirm-SMCPage: added parameter AcceptCodeValidation.
  * Amazon Systems Manager
    * Modified cmdlet Register-SSMTaskWithMaintenanceWindow: added parameter CutoffBehavior.
    * Modified cmdlet Update-SSMMaintenanceWindowTask: added parameter CutoffBehavior.
  * Amazon Textract
    * Added cmdlet Invoke-TXTExpenseAnalysis leveraging the AnalyzeExpense service API.
  * Amazon Transcribe Service
    * Added cmdlet Add-TRSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-TRSCallAnalyticsCategory leveraging the GetCallAnalyticsCategory service API.
    * Added cmdlet Get-TRSCallAnalyticsCategoryList leveraging the ListCallAnalyticsCategories service API.
    * Added cmdlet Get-TRSCallAnalyticsJob leveraging the GetCallAnalyticsJob service API.
    * Added cmdlet Get-TRSCallAnalyticsJobList leveraging the ListCallAnalyticsJobs service API.
    * Added cmdlet Get-TRSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-TRSCallAnalyticsCategory leveraging the CreateCallAnalyticsCategory service API.
    * Added cmdlet Remove-TRSCallAnalyticsCategory leveraging the DeleteCallAnalyticsCategory service API.
    * Added cmdlet Remove-TRSCallAnalyticsJob leveraging the DeleteCallAnalyticsJob service API.
    * Added cmdlet Remove-TRSResourceTag leveraging the UntagResource service API.
    * Added cmdlet Start-TRSCallAnalyticsJob leveraging the StartCallAnalyticsJob service API.
    * Added cmdlet Update-TRSCallAnalyticsCategory leveraging the UpdateCallAnalyticsCategory service API.
    * Modified cmdlet New-TRSLanguageModel: added parameter Tag.
    * Modified cmdlet New-TRSMedicalVocabulary: added parameter Tag.
    * Modified cmdlet New-TRSVocabulary: added parameter Tag.
    * Modified cmdlet New-TRSVocabularyFilter: added parameter Tag.
    * Modified cmdlet Start-TRSMedicalTranscriptionJob: added parameters KMSEncryptionContext, Media_RedactedMediaFileUri and Tag.
    * Modified cmdlet Start-TRSTranscriptionJob: added parameters KMSEncryptionContext, Media_RedactedMediaFileUri, Subtitles_Format and Tag.
  * Amazon Transfer for SFTP
    * Added cmdlet Get-TFRExecution leveraging the DescribeExecution service API.
    * Added cmdlet Get-TFRExecutionList leveraging the ListExecutions service API.
    * Added cmdlet Get-TFRWorkflow leveraging the DescribeWorkflow service API.
    * Added cmdlet Get-TFRWorkflowList leveraging the ListWorkflows service API.
    * Added cmdlet New-TFRWorkflow leveraging the CreateWorkflow service API.
    * Added cmdlet Remove-TFRWorkflow leveraging the DeleteWorkflow service API.
    * Added cmdlet Send-TFRWorkflowStepState leveraging the SendWorkflowStepState service API.
    * Modified cmdlet New-TFRServer: added parameter WorkflowDetails_OnUpload.
    * Modified cmdlet Update-TFRServer: added parameter WorkflowDetails_OnUpload.
  * Amazon Voice ID. Added cmdlets to support the service. Cmdlets for the service have the noun prefix VID and can be listed using the command 'Get-AWSCmdletName -Service VID'.
  * Amazon WAF V2
    * Added cmdlet Get-WAF2AvailableManagedRuleGroupVersionList leveraging the ListAvailableManagedRuleGroupVersions service API.
    * Added cmdlet Get-WAF2ManagedRuleSet leveraging the GetManagedRuleSet service API.
    * Added cmdlet Get-WAF2ManagedRuleSetList leveraging the ListManagedRuleSets service API.
    * Added cmdlet Update-WAF2ManagedRuleSetVersionExpiryDate leveraging the UpdateManagedRuleSetVersionExpiryDate service API.
    * Added cmdlet Write-WAF2ManagedRuleSetVersion leveraging the PutManagedRuleSetVersions service API.
    * Modified cmdlet Get-WAF2ManagedRuleGroup: added parameter VersionName.
    * Modified cmdlet Get-WAF2RateBasedStatementManagedKey: added parameter RuleGroupRuleName.
  * Amazon Well-Architected Tool
    * Modified cmdlet Update-WATAnswer: added parameters ChoiceUpdate and Reason.
  * Amazon WorkMail
    * Added cmdlet Get-WMMobileDeviceAccessOverride leveraging the GetMobileDeviceAccessOverride service API.
    * Added cmdlet Get-WMMobileDeviceAccessOverrideList leveraging the ListMobileDeviceAccessOverrides service API.
    * Added cmdlet Remove-WMMobileDeviceAccessOverride leveraging the DeleteMobileDeviceAccessOverride service API.
    * Added cmdlet Write-WMMobileDeviceAccessOverride leveraging the PutMobileDeviceAccessOverride service API.
  * Amazon WorkSpaces
    * Added cmdlet New-WKSUpdatedWorkspaceImage leveraging the CreateUpdatedWorkspaceImage service API.
  * Amazon Route53
    * Update Get-R53HostedZoneLimit to return limit instead of current count by default
  * AWS.Tools.Installer
    * Added support for new certificate used to sign AWS.Tools
  * Examples
    * Fixed invalid parameters for the Connect-DSDirectory sample
  * Common changes
    * Added support for document types
    * Update code signing certificate. Customers will require SkipPublisherCheck parameter to install newer version of an existing module.

### 4.1.14.0 (2021-06-24)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.60.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHGatewayRoute: added parameters Match_Metadata, Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname, Spec_GrpcRoute_Match_Hostname_Exact, Spec_GrpcRoute_Match_Hostname_Suffix, Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname, Spec_Http2Route_Action_Rewrite_Path_Exact, Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix, Spec_Http2Route_Action_Rewrite_Prefix_Value, Spec_Http2Route_Match_Headers, Spec_Http2Route_Match_Hostname_Exact, Spec_Http2Route_Match_Hostname_Suffix, Spec_Http2Route_Match_Method, Spec_Http2Route_Match_Path_Exact, Spec_Http2Route_Match_Path_Regex, Spec_Http2Route_Match_QueryParameters, Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname, Spec_HttpRoute_Action_Rewrite_Path_Exact, Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix, Spec_HttpRoute_Action_Rewrite_Prefix_Value, Spec_HttpRoute_Match_Headers, Spec_HttpRoute_Match_Hostname_Exact, Spec_HttpRoute_Match_Hostname_Suffix, Spec_HttpRoute_Match_Method, Spec_HttpRoute_Match_Path_Exact, Spec_HttpRoute_Match_Path_Regex, Spec_HttpRoute_Match_QueryParameters and Spec_Priority.
    * Modified cmdlet New-AMSHRoute: added parameters Spec_Http2Route_Match_Path_Exact, Spec_Http2Route_Match_Path_Regex, Spec_Http2Route_Match_QueryParameters, Spec_HttpRoute_Match_Path_Exact, Spec_HttpRoute_Match_Path_Regex and Spec_HttpRoute_Match_QueryParameters.
    * Modified cmdlet New-AMSHVirtualNode: added parameter Dns_ResponseType.
    * Modified cmdlet Update-AMSHGatewayRoute: added parameters Match_Metadata, Spec_GrpcRoute_Action_Rewrite_Hostname_DefaultTargetHostname, Spec_GrpcRoute_Match_Hostname_Exact, Spec_GrpcRoute_Match_Hostname_Suffix, Spec_Http2Route_Action_Rewrite_Hostname_DefaultTargetHostname, Spec_Http2Route_Action_Rewrite_Path_Exact, Spec_Http2Route_Action_Rewrite_Prefix_DefaultPrefix, Spec_Http2Route_Action_Rewrite_Prefix_Value, Spec_Http2Route_Match_Headers, Spec_Http2Route_Match_Hostname_Exact, Spec_Http2Route_Match_Hostname_Suffix, Spec_Http2Route_Match_Method, Spec_Http2Route_Match_Path_Exact, Spec_Http2Route_Match_Path_Regex, Spec_Http2Route_Match_QueryParameters, Spec_HttpRoute_Action_Rewrite_Hostname_DefaultTargetHostname, Spec_HttpRoute_Action_Rewrite_Path_Exact, Spec_HttpRoute_Action_Rewrite_Prefix_DefaultPrefix, Spec_HttpRoute_Action_Rewrite_Prefix_Value, Spec_HttpRoute_Match_Headers, Spec_HttpRoute_Match_Hostname_Exact, Spec_HttpRoute_Match_Hostname_Suffix, Spec_HttpRoute_Match_Method, Spec_HttpRoute_Match_Path_Exact, Spec_HttpRoute_Match_Path_Regex, Spec_HttpRoute_Match_QueryParameters and Spec_Priority.
    * Modified cmdlet Update-AMSHRoute: added parameters Spec_Http2Route_Match_Path_Exact, Spec_Http2Route_Match_Path_Regex, Spec_Http2Route_Match_QueryParameters, Spec_HttpRoute_Match_Path_Exact, Spec_HttpRoute_Match_Path_Regex and Spec_HttpRoute_Match_QueryParameters.
    * Modified cmdlet Update-AMSHVirtualNode: added parameter Dns_ResponseType.
  * Amazon Chime
    * Added cmdlet Update-CHMSipMediaApplicationCall leveraging the UpdateSipMediaApplicationCall service API.
    * Modified cmdlet Update-CHMAccount: added parameter DefaultLicense.
  * Amazon CloudFormation
    * Added cmdlet Disable-CFNType leveraging the DeactivateType service API.
    * Added cmdlet Enable-CFNType leveraging the ActivateType service API.
    * Added cmdlet Get-CFNDescribeTypeConfiguration leveraging the BatchDescribeTypeConfigurations service API.
    * Added cmdlet Get-CFNPublisher leveraging the DescribePublisher service API.
    * Added cmdlet Publish-CFNType leveraging the PublishType service API.
    * Added cmdlet Register-CFNPublisher leveraging the RegisterPublisher service API.
    * Added cmdlet Set-CFNTypeConfiguration leveraging the SetTypeConfiguration service API.
    * Added cmdlet Test-CFNType leveraging the TestType service API.
    * Modified cmdlet Get-CFNType: added parameters PublicVersionNumber and PublisherId.
    * Modified cmdlet Get-CFNTypeList: added parameters Filters_Category, Filters_PublisherId and Filters_TypeNamePrefix.
    * Modified cmdlet Get-CFNTypeVersion: added parameter PublisherId.
  * Amazon CodeBuild
    * [Breaking Change] Modified cmdlet New-CBProject: removed parameters Artifacts_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * [Breaking Change] Modified cmdlet Start-CBBatch: removed parameters ArtifactsOverride_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * [Breaking Change] Modified cmdlet Start-CBBuild: removed parameters ArtifactsOverride_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * [Breaking Change] Modified cmdlet Update-CBProject: removed parameters Artifacts_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
  * Amazon CodeGuru Reviewer
    * Modified cmdlet New-CGRCodeReview: added parameters BranchDiff_DestinationBranchName, BranchDiff_SourceBranchName, CodeArtifacts_BuildArtifactsObjectKey, CodeArtifacts_SourceCodeArtifactsObjectKey, CommitDiff_DestinationCommit, CommitDiff_MergeBaseCommit, CommitDiff_SourceCommit, Details_BucketName, EventInfo_Name, EventInfo_State, RequestMetadata_Requester, RequestMetadata_RequestId, RequestMetadata_VendorName, S3BucketRepository_Name, Type_AnalysisType and Type_RepositoryAnalysis_SourceCodeType_RepositoryHead_BranchName.
    * Modified cmdlet Register-CGRRepository: added parameters S3Bucket_BucketName and S3Bucket_Name.
  * Amazon Cognito Identity Provider
    * Added cmdlet Revoke-CGIPToken leveraging the RevokeToken service API.
    * Modified cmdlet New-CGIPUserPoolClient: added parameter EnableTokenRevocation.
    * Modified cmdlet Update-CGIPUserPoolClient: added parameter EnableTokenRevocation.
  * Amazon Connect Service
    * Added cmdlet Add-CONNBot leveraging the AssociateBot service API.
    * Added cmdlet Get-CONNBotList leveraging the ListBots service API.
    * Added cmdlet Remove-CONNBot leveraging the DisassociateBot service API.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Added cmdlet Edit-DOCGlobalCluster leveraging the ModifyGlobalCluster service API.
    * Added cmdlet Get-DOCGlobalCluster leveraging the DescribeGlobalClusters service API.
    * Added cmdlet New-DOCGlobalCluster leveraging the CreateGlobalCluster service API.
    * Added cmdlet Remove-DOCFromGlobalCluster leveraging the RemoveFromGlobalCluster service API.
    * Added cmdlet Remove-DOCGlobalCluster leveraging the DeleteGlobalCluster service API.
    * Modified cmdlet New-DOCDBCluster: added parameter GlobalClusterIdentifier.
  * Amazon DynamoDB Accelerator (DAX)
    * Modified cmdlet New-DAXCluster: added parameter ClusterEndpointEncryptionType.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2ImageDeprecation leveraging the DisableImageDeprecation service API.
    * Added cmdlet Enable-EC2ImageDeprecation leveraging the EnableImageDeprecation service API.
    * Added cmdlet Get-EC2TrunkInterfaceAssociation leveraging the DescribeTrunkInterfaceAssociations service API.
    * Added cmdlet Register-EC2TrunkInterface leveraging the AssociateTrunkInterface service API.
    * Added cmdlet Unregister-EC2TrunkInterface leveraging the DisassociateTrunkInterface service API.
    * Modified cmdlet Get-EC2Image: added parameter IncludeDeprecated.
    * Modified cmdlet New-EC2NatGateway: added parameter ConnectivityType.
    * Modified cmdlet Register-EC2ByoipCidr: added parameter MultiRegion.
    * Fixed examples for Get-EC2Tag CmdLet.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSNodegroup: added parameters UpdateConfig_MaxUnavailable and UpdateConfig_MaxUnavailablePercentage.
    * Modified cmdlet Update-EKSNodegroupConfig: added parameters UpdateConfig_MaxUnavailable and UpdateConfig_MaxUnavailablePercentage.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNFlow: added parameters SourceFailoverConfig_FailoverMode and SourcePriority_PrimarySource.
    * Modified cmdlet Update-EMCNFlow: added parameters SourceFailoverConfig_FailoverMode and SourcePriority_PrimarySource.
  * Amazon Elemental MediaTailor
    * Modified cmdlet New-EMTSourceLocation: added parameters SecretsManagerAccessTokenConfiguration_HeaderName, SecretsManagerAccessTokenConfiguration_SecretArn and SecretsManagerAccessTokenConfiguration_SecretStringKey.
    * Modified cmdlet Update-EMTSourceLocation: added parameters SecretsManagerAccessTokenConfiguration_HeaderName, SecretsManagerAccessTokenConfiguration_SecretArn and SecretsManagerAccessTokenConfiguration_SecretStringKey.
  * Amazon Forecast Service
    * Modified cmdlet New-FRCPredictor: added parameter AutoMLOverrideStrategy.
  * Amazon GreengrassV2
    * Added cmdlet Add-GGV2BatchClientDeviceWithCoreDevice leveraging the BatchAssociateClientDeviceWithCoreDevice service API.
    * Added cmdlet Get-GGV2ClientDevicesAssociatedWithCoreDeviceList leveraging the ListClientDevicesAssociatedWithCoreDevice service API.
    * Added cmdlet Remove-GGV2BatchClientDeviceFromCoreDevice leveraging the BatchDisassociateClientDeviceFromCoreDevice service API.
  * Amazon Kendra
    * Added cmdlet Get-KNDRGetDocumentStatus leveraging the BatchGetDocumentStatus service API.
  * Amazon Key Management Service
    * Added cmdlet New-KMSReplicaKey leveraging the ReplicateKey service API.
    * Added cmdlet Update-KMSPrimaryRegion leveraging the UpdatePrimaryRegion service API.
    * Modified cmdlet New-KMSKey: added parameter MultiRegion.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2Slot: added parameter MultipleValuesSetting_AllowMultipleValue.
    * Modified cmdlet Update-LMBV2Slot: added parameter MultipleValuesSetting_AllowMultipleValue.
  * Amazon License Manager
    * Modified cmdlet New-LICMGrantVersion: added parameter StatusReason.
    * Modified cmdlet Remove-LICMGrant: added parameter StatusReason.
  * Amazon Macie 2
    * Modified cmdlet Update-MAC2FindingsFilter: added parameter ClientToken.
  * Amazon Managed Blockchain
    * Modified cmdlet New-MBCMember: added parameter MemberConfiguration_KmsKeyArn.
    * Modified cmdlet New-MBCNetwork: added parameter MemberConfiguration_KmsKeyArn.
  * Amazon Performance Insights
    * Added cmdlet Get-PIDimensionKeyDetail leveraging the GetDimensionKeyDetails service API.
  * Amazon Proton. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PRO and can be listed using the command 'Get-AWSCmdletName -Service PRO'.
  * Amazon QuickSight
    * Added cmdlet Get-QSFolder leveraging the DescribeFolder service API.
    * Added cmdlet Get-QSFolderList leveraging the ListFolders service API.
    * Added cmdlet Get-QSFolderMemberList leveraging the ListFolderMembers service API.
    * Added cmdlet Get-QSFolderPermission leveraging the DescribeFolderPermissions service API.
    * Added cmdlet Get-QSFolderResolvedPermission leveraging the DescribeFolderResolvedPermissions service API.
    * Added cmdlet New-QSFolder leveraging the CreateFolder service API.
    * Added cmdlet New-QSFolderMembership leveraging the CreateFolderMembership service API.
    * Added cmdlet Remove-QSFolder leveraging the DeleteFolder service API.
    * Added cmdlet Remove-QSFolderMembership leveraging the DeleteFolderMembership service API.
    * Added cmdlet Search-QSFolder leveraging the SearchFolders service API.
    * Added cmdlet Update-QSFolder leveraging the UpdateFolder service API.
    * Added cmdlet Update-QSFolderPermission leveraging the UpdateFolderPermissions service API.
  * Amazon Redshift Data API Service
    * Modified cmdlet Send-RSDStatement: added parameter Parameter.
  * Amazon Relational Database Service
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameters EngineMode, ScalingConfiguration_AutoPause, ScalingConfiguration_MaxCapacity, ScalingConfiguration_MinCapacity, ScalingConfiguration_SecondsUntilAutoPause and ScalingConfiguration_TimeoutAction.
    * Modified cmdlet Start-RDSActivityStream: added parameter EngineNativeAuditFieldsIncluded.
  * Amazon Resource Access Manager (RAM)
    * Modified cmdlet Add-RAMPermissionToResourceShare: added parameter PermissionVersion.
    * Modified cmdlet Get-RAMResourceShare: added parameter PermissionArn.
  * Amazon S3 Control
    * Modified cmdlet New-S3CJob: added parameter S3PutObjectCopy_BucketKeyEnabled.
  * Amazon SageMaker Feature Store Runtime
    * Added cmdlet Get-SMFSRecordBatch leveraging the BatchGetRecord service API.
  * Amazon SageMaker Service
    * Added cmdlet Send-SMPipelineExecutionStepFailure leveraging the SendPipelineExecutionStepFailure service API.
    * Added cmdlet Send-SMPipelineExecutionStepSuccess leveraging the SendPipelineExecutionStepSuccess service API.
    * Modified cmdlet New-SMDeviceFleet: added parameters EnableIotRoleAlias, OutputConfig_PresetDeploymentConfig and OutputConfig_PresetDeploymentType.
    * Modified cmdlet New-SMEdgePackagingJob: added parameters OutputConfig_PresetDeploymentConfig and OutputConfig_PresetDeploymentType.
    * Modified cmdlet Update-SMDeviceFleet: added parameters EnableIotRoleAlias, OutputConfig_PresetDeploymentConfig and OutputConfig_PresetDeploymentType.
  * Amazon Transfer for SFTP
    * Modified cmdlet Update-TFRServer: added parameter ProtocolDetails_PassiveIp.
  * Amazon WAF V2
    * Modified cmdlet Get-WAF2RuleGroup: added parameter ARN.

### 4.1.13.0 (2021-06-01)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.45.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Made 'Service' parameter positional for Get-AWSService cmdlet.
  * Amazon AmazonMWAA
    * Modified cmdlet New-MWAAEnvironment: added parameter Scheduler.
    * Modified cmdlet Update-MWAAEnvironment: added parameter Scheduler.
  * Amazon App Runner. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AAR and can be listed using the command 'Get-AWSCmdletName -Service AAR'.
  * Amazon ApplicationCostProfiler. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ACP and can be listed using the command 'Get-AWSCmdletName -Service ACP'.
  * Amazon Auto Scaling
    * Added cmdlet Get-ASPredictiveScalingForecast leveraging the GetPredictiveScalingForecast service API.
    * Modified cmdlet Write-ASScalingPolicy: added parameters PredictiveScalingConfiguration_MaxCapacityBreachBehavior, PredictiveScalingConfiguration_MaxCapacityBuffer, PredictiveScalingConfiguration_MetricSpecification, PredictiveScalingConfiguration_Mode and PredictiveScalingConfiguration_SchedulingBufferTime.
  * Amazon Certificate Manager Private Certificate Authority
    * Modified cmdlet New-PCACertificateAuthority: added parameter KeyStorageSecurityStandard.
  * Amazon Chime
    * Added cmdlet Get-CHMSupportedPhoneNumberCountryList leveraging the ListSupportedPhoneNumberCountries service API.
    * Added cmdlet New-CHMCreateChannelMembership leveraging the BatchCreateChannelMembership service API.
    * Modified cmdlet Search-CHMAvailablePhoneNumber: added parameters NoAutoIteration and PhoneNumberType.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNTemplateSummary: added parameter CallAs.
  * Amazon CloudFront
    * Added cmdlet Get-CFFunction leveraging the GetFunction service API.
    * Added cmdlet Get-CFFunctionList leveraging the ListFunctions service API.
    * Added cmdlet Get-CFFunctionSummary leveraging the DescribeFunction service API.
    * Added cmdlet New-CFFunction leveraging the CreateFunction service API.
    * Added cmdlet Publish-CFFunction leveraging the PublishFunction service API.
    * Added cmdlet Remove-CFFunction leveraging the DeleteFunction service API.
    * Added cmdlet Test-CFFunction leveraging the TestFunction service API.
    * Added cmdlet Update-CFFunction leveraging the UpdateFunction service API.
    * Modified cmdlet New-CFDistribution: added parameters FunctionAssociations_Item and FunctionAssociations_Quantity.
    * Modified cmdlet New-CFDistributionWithTag: added parameters FunctionAssociations_Item and FunctionAssociations_Quantity.
    * Modified cmdlet Update-CFDistribution: added parameters FunctionAssociations_Item and FunctionAssociations_Quantity.
  * Amazon CodeGuru Reviewer
    * Modified cmdlet Register-CGRRepository: added parameters KMSKeyDetails_EncryptionOption and KMSKeyDetails_KMSKeyId.
  * Amazon Compute Optimizer
    * Added cmdlet Export-COEBSVolumeRecommendation leveraging the ExportEBSVolumeRecommendations service API.
    * Added cmdlet Export-COLambdaFunctionRecommendation leveraging the ExportLambdaFunctionRecommendations service API.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFMatch leveraging the GetMatches service API.
    * Added cmdlet Merge-CPFProfile leveraging the MergeProfiles service API.
    * Modified cmdlet New-CPFDomain: added parameter Matching_Enabled.
    * Modified cmdlet Update-CPFDomain: added parameter Matching_Enabled.
  * Amazon Connect Service
    * Modified cmdlet New-CONNIntegrationAssociation: added parameter Tag.
    * Modified cmdlet New-CONNUseCase: added parameter Tag.
  * Amazon Device Farm
    * Modified cmdlet New-DFTestGridProject: added parameters VpcConfig_SecurityGroupId, VpcConfig_SubnetId and VpcConfig_VpcId.
    * Modified cmdlet Update-DFTestGridProject: added parameters VpcConfig_SecurityGroupId, VpcConfig_SubnetId and VpcConfig_VpcId.
  * Amazon DevOps Guru
    * Added cmdlet Get-DGURUCostEstimation leveraging the GetCostEstimation service API.
    * Added cmdlet Start-DGURUCostEstimation leveraging the StartCostEstimation service API.
    * Modified cmdlet Get-DGURURecommendationList: added parameter Locale.
    * Modified cmdlet Search-DGURUInsight: added parameter ServiceCollection_ServiceName.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSTask: added parameter EphemeralStorage_SizeInGiB.
    * Modified cmdlet Register-ECSTaskDefinition: added parameter EphemeralStorage_SizeInGiB.
    * Modified cmdlet Start-ECSTask: added parameter EphemeralStorage_SizeInGiB.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Add-EC2CapacityReservation: added parameter OutpostArn.
    * Modified cmdlet New-EC2NetworkInterface: added parameter ClientToken.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSNodegroup: added parameter Taint.
    * Modified cmdlet Update-EKSNodegroupConfig: added parameters Taints_AddOrUpdateTaint and Taints_RemoveTaint.
  * Amazon Elastic File System
    * Added cmdlet Get-EFSAccountPreference leveraging the DescribeAccountPreferences service API.
    * Added cmdlet Write-EFSAccountPreference leveraging the PutAccountPreferences service API.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameter ColdStorageOptions_Enabled.
    * Modified cmdlet Update-ESDomainConfig: added parameter ColdStorageOptions_Enabled.
  * Amazon Elemental MediaConnect
    * Added cmdlet Add-EMCNFlowMediaStream leveraging the AddFlowMediaStreams service API.
    * Added cmdlet Remove-EMCNFlowMediaStream leveraging the RemoveFlowMediaStream service API.
    * Added cmdlet Update-EMCNFlowMediaStream leveraging the UpdateFlowMediaStream service API.
    * Modified cmdlet New-EMCNFlow: added parameter MediaStream.
    * Modified cmdlet Update-EMCNFlowOutput: added parameter MediaStreamOutputConfiguration.
    * Modified cmdlet Update-EMCNFlowSource: added parameters MaxSyncBuffer and MediaStreamSourceConfiguration.
  * Amazon Elemental MediaPackage
    * Modified cmdlet New-EMPOriginEndpoint: added parameter Encryption_ConstantInitializationVector.
    * Modified cmdlet Update-EMPOriginEndpoint: added parameter Encryption_ConstantInitializationVector.
  * Amazon FinSpace Public API. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FNSP and can be listed using the command 'Get-AWSCmdletName -Service FNSP'.
  * Amazon FinSpace User Environment Management Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FINSP and can be listed using the command 'Get-AWSCmdletName -Service FINSP'.
  * Amazon Forecast Service
    * Added cmdlet Remove-FRCResourceTree leveraging the DeleteResourceTree service API.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWLongTermPricing leveraging the ListLongTermPricing service API.
    * Added cmdlet New-SNOWLongTermPricing leveraging the CreateLongTermPricing service API.
    * Added cmdlet Update-SNOWLongTermPricing leveraging the UpdateLongTermPricing service API.
    * Modified cmdlet New-SNOWJob: added parameter LongTermPricingId.
  * Amazon IoT
    * Added cmdlet Get-IOTJobTemplate leveraging the DescribeJobTemplate service API.
    * Added cmdlet Get-IOTJobTemplateList leveraging the ListJobTemplates service API.
    * Added cmdlet New-IOTJobTemplate leveraging the CreateJobTemplate service API.
    * Added cmdlet Remove-IOTJobTemplate leveraging the DeleteJobTemplate service API.
    * Modified cmdlet New-IOTJob: added parameter JobTemplateArn.
  * IOTDA
    * [Breaking Change] Removed cmdlet Get-IOTDATestCaseList.
    * Added cmdlet Stop-IOTDASuiteRun leveraging the StopSuiteRun service API.
    * [Breaking Change] Modified cmdlet Start-IOTDASuiteRun: removed parameters SecondaryDevice_CertificateArn and SecondaryDevice_ThingArn.
  * Amazon IoT Events
    * Added cmdlet Get-IOTEAlarmModel leveraging the DescribeAlarmModel service API.
    * Added cmdlet Get-IOTEAlarmModelList leveraging the ListAlarmModels service API.
    * Added cmdlet Get-IOTEAlarmModelVersionList leveraging the ListAlarmModelVersions service API.
    * Added cmdlet Get-IOTEInputRoutingList leveraging the ListInputRoutings service API.
    * Added cmdlet New-IOTEAlarmModel leveraging the CreateAlarmModel service API.
    * Added cmdlet Remove-IOTEAlarmModel leveraging the DeleteAlarmModel service API.
    * Added cmdlet Update-IOTEAlarmModel leveraging the UpdateAlarmModel service API.
  * Amazon IoT Events Data
    * Added cmdlet Get-IOTEDAlarm leveraging the DescribeAlarm service API.
    * Added cmdlet Get-IOTEDAlarmList leveraging the ListAlarms service API.
    * Added cmdlet Send-IOTEDAcknowledgeAlarm leveraging the BatchAcknowledgeAlarm service API.
    * Added cmdlet Send-IOTEDDisableAlarm leveraging the BatchDisableAlarm service API.
    * Added cmdlet Send-IOTEDEnableAlarm leveraging the BatchEnableAlarm service API.
    * Added cmdlet Send-IOTEDResetAlarm leveraging the BatchResetAlarm service API.
    * Added cmdlet Send-IOTEDSnoozeAlarm leveraging the BatchSnoozeAlarm service API.
  * Amazon IoT SiteWise
    * Added cmdlet Get-IOTSWInterpolatedAssetPropertyValue leveraging the GetInterpolatedAssetPropertyValues service API.
    * Modified cmdlet New-IOTSWPortal: added parameters Alarms_AlarmRoleArn, Alarms_NotificationLambdaArn and NotificationSenderEmail.
    * Modified cmdlet Update-IOTSWPortal: added parameters Alarms_AlarmRoleArn, Alarms_NotificationLambdaArn and NotificationSenderEmail.
  * Amazon IoT Wireless
    * Added cmdlet Get-IOTWLogLevelsByResourceType leveraging the GetLogLevelsByResourceTypes service API.
    * Added cmdlet Get-IOTWResourceLogLevel leveraging the GetResourceLogLevel service API.
    * Added cmdlet Reset-IOTWAllResourceLogLevel leveraging the ResetAllResourceLogLevels service API.
    * Added cmdlet Reset-IOTWResourceLogLevel leveraging the ResetResourceLogLevel service API.
    * Added cmdlet Update-IOTWLogLevelsByResourceType leveraging the UpdateLogLevelsByResourceTypes service API.
    * Added cmdlet Write-IOTWResourceLogLevel leveraging the PutResourceLogLevel service API.
    * Modified cmdlet New-IOTWWirelessGateway: added parameters LoRaWAN_JoinEuiFilter, LoRaWAN_NetIdFilter and LoRaWAN_SubBand.
    * Modified cmdlet Send-IOTWDataToWirelessDevice: added parameter Sidewalk_MessageType.
    * Modified cmdlet Update-IOTWWirelessGateway: added parameters JoinEuiFilter and NetIdFilter.
  * Amazon Kendra
    * Added cmdlet Clear-KNDRQuerySuggestion leveraging the ClearQuerySuggestions service API.
    * Added cmdlet Get-KNDRQuerySuggestion leveraging the GetQuerySuggestions service API.
    * Added cmdlet Get-KNDRQuerySuggestionsBlockList leveraging the DescribeQuerySuggestionsBlockList service API.
    * Added cmdlet Get-KNDRQuerySuggestionsBlockListList leveraging the ListQuerySuggestionsBlockLists service API.
    * Added cmdlet Get-KNDRQuerySuggestionsConfig leveraging the DescribeQuerySuggestionsConfig service API.
    * Added cmdlet New-KNDRQuerySuggestionsBlockList leveraging the CreateQuerySuggestionsBlockList service API.
    * Added cmdlet Remove-KNDRQuerySuggestionsBlockList leveraging the DeleteQuerySuggestionsBlockList service API.
    * Added cmdlet Update-KNDRQuerySuggestionsBlockList leveraging the UpdateQuerySuggestionsBlockList service API.
    * Added cmdlet Update-KNDRQuerySuggestionsConfig leveraging the UpdateQuerySuggestionsConfig service API.
  * Amazon Kinesis Analytics V2
    * Added cmdlet Get-KINA2ApplicationVersion leveraging the DescribeApplicationVersion service API.
    * Added cmdlet Get-KINA2ApplicationVersionList leveraging the ListApplicationVersions service API.
    * Added cmdlet Undo-KINA2Application leveraging the RollbackApplication service API.
    * Added cmdlet Update-KINA2ApplicationMaintenanceConfiguration leveraging the UpdateApplicationMaintenanceConfiguration service API.
    * Modified cmdlet Add-KINA2ApplicationCloudWatchLoggingOption: added parameter ConditionalToken.
    * Modified cmdlet Add-KINA2ApplicationVpcConfiguration: added parameter ConditionalToken.
    * Modified cmdlet New-KINA2Application: added parameter ApplicationMode.
    * Modified cmdlet Remove-KINA2ApplicationCloudWatchLoggingOption: added parameter ConditionalToken.
    * Modified cmdlet Remove-KINA2ApplicationVpcConfiguration: added parameter ConditionalToken.
    * Modified cmdlet Update-KINA2Application: added parameter ConditionalToken.
  * Amazon Lake Formation
    * Added cmdlet Add-LKFLFTagsToResource leveraging the AddLFTagsToResource service API.
    * Added cmdlet Get-LKFLFTag leveraging the GetLFTag service API.
    * Added cmdlet Get-LKFLFTagList leveraging the ListLFTags service API.
    * Added cmdlet Get-LKFResourceLFTag leveraging the GetResourceLFTags service API.
    * Added cmdlet New-LKFLFTag leveraging the CreateLFTag service API.
    * Added cmdlet Remove-LKFLFTag leveraging the DeleteLFTag service API.
    * Added cmdlet Remove-LKFLFTagsFromResource leveraging the RemoveLFTagsFromResource service API.
    * Added cmdlet Search-LKFDatabasesByLFTag leveraging the SearchDatabasesByLFTags service API.
    * Added cmdlet Search-LKFTablesByLFTag leveraging the SearchTablesByLFTags service API.
    * Added cmdlet Update-LKFLFTag leveraging the UpdateLFTag service API.
    * Modified cmdlet Get-LKFPermissionList: added parameters LFTag_CatalogId, LFTag_TagKey, LFTag_TagValue, LFTagPolicy_CatalogId, LFTagPolicy_Expression and LFTagPolicy_ResourceType.
    * Modified cmdlet Grant-LKFPermission: added parameters LFTag_CatalogId, LFTag_TagKey, LFTag_TagValue, LFTagPolicy_CatalogId, LFTagPolicy_Expression and LFTagPolicy_ResourceType.
    * Modified cmdlet Revoke-LKFPermission: added parameters LFTag_CatalogId, LFTag_TagKey, LFTag_TagValue, LFTagPolicy_CatalogId, LFTagPolicy_Expression and LFTagPolicy_ResourceType.
  * Amazon Lex Model Building V2
    * Added cmdlet Get-LMBV2Export leveraging the DescribeExport service API.
    * Added cmdlet Get-LMBV2ExportList leveraging the ListExports service API.
    * Added cmdlet Get-LMBV2Import leveraging the DescribeImport service API.
    * Added cmdlet Get-LMBV2ImportList leveraging the ListImports service API.
    * Added cmdlet Get-LMBV2ResourcePolicy leveraging the DescribeResourcePolicy service API.
    * Added cmdlet New-LMBV2Export leveraging the CreateExport service API.
    * Added cmdlet New-LMBV2ResourcePolicy leveraging the CreateResourcePolicy service API.
    * Added cmdlet New-LMBV2ResourcePolicyStatement leveraging the CreateResourcePolicyStatement service API.
    * Added cmdlet New-LMBV2UploadUrl leveraging the CreateUploadUrl service API.
    * Added cmdlet Remove-LMBV2Export leveraging the DeleteExport service API.
    * Added cmdlet Remove-LMBV2Import leveraging the DeleteImport service API.
    * Added cmdlet Remove-LMBV2ResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Remove-LMBV2ResourcePolicyStatement leveraging the DeleteResourcePolicyStatement service API.
    * Added cmdlet Start-LMBV2Import leveraging the StartImport service API.
    * Added cmdlet Update-LMBV2Export leveraging the UpdateExport service API.
    * Added cmdlet Update-LMBV2ResourcePolicy leveraging the UpdateResourcePolicy service API.
  * Amazon License Manager
    * Added cmdlet Get-LICMLicenseManagerReportGenerator leveraging the GetLicenseManagerReportGenerator service API.
    * Added cmdlet Get-LICMLicenseManagerReportGeneratorList leveraging the ListLicenseManagerReportGenerators service API.
    * Added cmdlet New-LICMLicenseManagerReportGenerator leveraging the CreateLicenseManagerReportGenerator service API.
    * Added cmdlet Remove-LICMLicenseManagerReportGenerator leveraging the DeleteLicenseManagerReportGenerator service API.
    * Added cmdlet Update-LICMLicenseManagerReportGenerator leveraging the UpdateLicenseManagerReportGenerator service API.
  * Amazon Location Service
    * Added cmdlet Add-LOCResourceTagSet leveraging the TagResource service API.
    * Added cmdlet Get-LOCDevicePositionList leveraging the ListDevicePositions service API.
    * Added cmdlet Get-LOCResourceTagSet leveraging the ListTagsForResource service API.
    * Added cmdlet Get-LOCRoute leveraging the CalculateRoute service API.
    * Added cmdlet Get-LOCRouteCalculator leveraging the DescribeRouteCalculator service API.
    * Added cmdlet Get-LOCRouteCalculatorList leveraging the ListRouteCalculators service API.
    * Added cmdlet New-LOCRouteCalculator leveraging the CreateRouteCalculator service API.
    * Added cmdlet Remove-LOCDevicePositionHistoryBatch leveraging the BatchDeleteDevicePositionHistory service API.
    * Added cmdlet Remove-LOCResourceTagSet leveraging the UntagResource service API.
    * Added cmdlet Remove-LOCRouteCalculator leveraging the DeleteRouteCalculator service API.
    * Modified cmdlet New-LOCGeofenceCollection: added parameters KmsKeyId and Tag.
    * Modified cmdlet New-LOCMap: added parameter Tag.
    * Modified cmdlet New-LOCPlaceIndex: added parameter Tag.
    * Modified cmdlet New-LOCTracker: added parameters KmsKeyId and Tag.
  * Amazon Macie 2
    * Added cmdlet Search-MAC2Resource leveraging the SearchResources service API.
    * Modified cmdlet New-MAC2ClassificationJob: added parameters S3JobDefinition_BucketCriteria_Excludes_And and S3JobDefinition_BucketCriteria_Includes_And.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Modified cmdlet New-MSKCluster: added parameter Iam_Enabled.
  * Amazon Neptune
    * Modified cmdlet Edit-NPTDBCluster: added parameter CopyTagsToSnapshot.
    * Modified cmdlet New-NPTDBCluster: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-NPTDBClusterFromSnapshot: added parameter CopyTagsToSnapshot.
  * Amazon Nimble Studio. Added cmdlets to support the service. Cmdlets for the service have the noun prefix NS and can be listed using the command 'Get-AWSCmdletName -Service NS'.
  * Amazon Personalize
    * Added cmdlet Get-PERSDatasetExportJob leveraging the DescribeDatasetExportJob service API.
    * Added cmdlet Get-PERSDatasetExportJobList leveraging the ListDatasetExportJobs service API.
    * Added cmdlet New-PERSDatasetExportJob leveraging the CreateDatasetExportJob service API.
    * Added cmdlet Stop-PERSSolutionVersionCreation leveraging the StopSolutionVersionCreation service API.
    * Modified cmdlet New-PERSSolution: added parameters OptimizationObjective_ItemAttribute and OptimizationObjective_ObjectiveSensitivity.
  * Amazon QLDB
    * Added cmdlet Update-QLDBLedgerPermissionsMode leveraging the UpdateLedgerPermissionsMode service API.
  * Amazon QuickSight
    * Modified cmdlet New-QSDataSet: added parameter RowLevelPermissionDataSet_FormatVersion.
    * Modified cmdlet Register-QSUser: added parameters CustomFederationProviderUrl, ExternalLoginFederationProviderType and ExternalLoginId.
    * Modified cmdlet Update-QSDataSet: added parameter RowLevelPermissionDataSet_FormatVersion.
    * Modified cmdlet Update-QSUser: added parameters CustomFederationProviderUrl, ExternalLoginFederationProviderType and ExternalLoginId.
  * Amazon Rekognition
    * Modified cmdlet New-REKProjectVersion: added parameter KmsKeyId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAutoMLJob: added parameters ModelDeployConfig_AutoGenerateEndpointName and ModelDeployConfig_EndpointName.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameter RetryStrategy_MaximumRetryAttempt.
    * Modified cmdlet New-SMTrainingJob: added parameter RetryStrategy_MaximumRetryAttempt.
  * Amazon Simple Notification Service (SNS)
    * Added cmdlet Confirm-SNSSMSSandboxPhoneNumber leveraging the VerifySMSSandboxPhoneNumber service API.
    * Added cmdlet Get-SNSOriginationNumber leveraging the ListOriginationNumbers service API.
    * Added cmdlet Get-SNSSMSSandboxAccountStatus leveraging the GetSMSSandboxAccountStatus service API.
    * Added cmdlet Get-SNSSMSSandboxPhoneNumber leveraging the ListSMSSandboxPhoneNumbers service API.
    * Added cmdlet New-SNSSMSSandboxPhoneNumber leveraging the CreateSMSSandboxPhoneNumber service API.
    * Added cmdlet Remove-SNSSMSSandboxPhoneNumber leveraging the DeleteSMSSandboxPhoneNumber service API.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3MultipartUpload leveraging the ListMultipartUploads service API.
    * Added cmdlet Get-S3ObjectV2 leveraging the ListObjectsV2 service API.
    * Modified cmdlet New-S3Bucket: added parameter ObjectLockEnabledForBucket.
    * Modified cmdlet Write-S3Object: added parameter CalculateContentMD5Header.
	* Fixed an issue where Write-S3Object ignores HeaderCollection argument when uploading folders.
  * Amazon System Manager Contacts. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SMC and can be listed using the command 'Get-AWSCmdletName -Service SMC'.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMOpsItemRelatedItem leveraging the ListOpsItemRelatedItems service API.
    * Added cmdlet Register-SSMOpsItemRelatedItem leveraging the AssociateOpsItemRelatedItem service API.
    * Added cmdlet Unregister-SSMOpsItemRelatedItem leveraging the DisassociateOpsItemRelatedItem service API.
    * Modified cmdlet New-SSMAssociation: added parameter CalendarName.
    * Modified cmdlet New-SSMDocument: added parameter DisplayName.
    * Modified cmdlet Update-SSMAssociation: added parameter CalendarName.
    * Modified cmdlet Update-SSMDocument: added parameter DisplayName.
  * Amazon Systems Manager Incident Manager. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSMI and can be listed using the command 'Get-AWSCmdletName -Service SSMI'.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSMedicalTranscriptionJob: added parameter ContentIdentificationType.
  * Amazon Transfer for SFTP
    * Added cmdlet Get-TFRAccess leveraging the DescribeAccess service API.
    * Added cmdlet Get-TFRAccessList leveraging the ListAccesses service API.
    * Added cmdlet New-TFRAccess leveraging the CreateAccess service API.
    * Added cmdlet Remove-TFRAccess leveraging the DeleteAccess service API.
    * Added cmdlet Update-TFRAccess leveraging the UpdateAccess service API.
    * Modified cmdlet New-TFRServer: added parameter IdentityProviderDetails_DirectoryId.
    * Modified cmdlet Update-TFRServer: added parameter IdentityProviderDetails_DirectoryId.
  * Amazon WorkSpaces
    * Modified cmdlet Edit-WKSWorkspaceAccessProperty: added parameter WorkspaceAccessProperties_DeviceTypeLinux.

### 4.1.12.0 (2021-04-22)
  * Removed "PS C:\> " from one-line PowerShell API cmdlet examples.
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.19.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Database Migration Service
    * Added cmdlet Get-DMSEndpointSetting leveraging the DescribeEndpointSettings service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameters KafkaSettings_SaslPassword, KafkaSettings_SaslUsername, KafkaSettings_SecurityProtocol, KafkaSettings_SslCaCertificateArn, KafkaSettings_SslClientCertificateArn, KafkaSettings_SslClientKeyArn, KafkaSettings_SslClientKeyPassword, MicrosoftSQLServerSettings_QuerySingleAlwaysOnNode, MicrosoftSQLServerSettings_UseThirdPartyBackupDevice, MySQLSettings_CleanSourceMetadataOnMismatch and OracleSettings_SpatialDataOptionToGeoJsonFunctionName.
    * Modified cmdlet New-DMSEndpoint: added parameters KafkaSettings_SaslPassword, KafkaSettings_SaslUsername, KafkaSettings_SecurityProtocol, KafkaSettings_SslCaCertificateArn, KafkaSettings_SslClientCertificateArn, KafkaSettings_SslClientKeyArn, KafkaSettings_SslClientKeyPassword, MicrosoftSQLServerSettings_QuerySingleAlwaysOnNode, MicrosoftSQLServerSettings_UseThirdPartyBackupDevice, MySQLSettings_CleanSourceMetadataOnMismatch and OracleSettings_SpatialDataOptionToGeoJsonFunctionName.
  * Amazon EC2 Instance Connect. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EC2IC and can be listed using the command 'Get-AWSCmdletName -Service EC2IC'.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECCacheCluster: added parameter LogDeliveryConfiguration.
    * Modified cmdlet Edit-ECReplicationGroup: added parameter LogDeliveryConfiguration.
    * Modified cmdlet New-ECCacheCluster: added parameter LogDeliveryConfiguration.
    * Modified cmdlet New-ECReplicationGroup: added parameter LogDeliveryConfiguration.
  * Amazon EventBridge Schema Registry. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SCHM and can be listed using the command 'Get-AWSCmdletName -Service SCHM'.
  * Amazon Glue DataBrew. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GDB and can be listed using the command 'Get-AWSCmdletName -Service GDB'.
  * Amazon Ground Station
    * Modified cmdlet New-GSConfig: added parameters S3RecordingConfig_BucketArn, S3RecordingConfig_Prefix and S3RecordingConfig_RoleArn.
    * Modified cmdlet Update-GSConfig: added parameters S3RecordingConfig_BucketArn, S3RecordingConfig_Prefix and S3RecordingConfig_RoleArn.
  * Amazon Honeycode. Added cmdlets to support the service. Cmdlets for the service have the noun prefix HC and can be listed using the command 'Get-AWSCmdletName -Service HC'.
  * Amazon Kendra
    * Modified cmdlet Invoke-KNDRQuery: added parameter DocumentRelevanceOverrideConfiguration.
  * LMBV2
    * [Breaking Change] Removed cmdlet Build-LMBV2BotLocale.
    * Added cmdlet Invoke-LMBV2BuildBotLocale leveraging the BuildBotLocale service API.
  * Amazon Lookout for Equipment. Added cmdlets to support the service. Cmdlets for the service have the noun prefix L4E and can be listed using the command 'Get-AWSCmdletName -Service L4E'.
  * Amazon Redshift
    * Added cmdlet Add-RSPartner leveraging the AddPartner service API.
    * Added cmdlet Get-RSPartner leveraging the DescribePartners service API.
    * Added cmdlet Remove-RSPartner leveraging the DeletePartner service API.
    * Added cmdlet Update-RSPartnerStatus leveraging the UpdatePartnerStatus service API.
  * Amazon Security Hub
    * Added cmdlet Confirm-SHUBAdministratorInvitation leveraging the AcceptAdministratorInvitation service API.
    * Added cmdlet Get-SHUBAdministratorAccount leveraging the GetAdministratorAccount service API.
    * Added cmdlet Remove-SHUBFromAdministratorAccount leveraging the DisassociateFromAdministratorAccount service API.
  * Amazon Timestream Query. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TSQ and can be listed using the command 'Get-AWSCmdletName -Service TSQ'.
  * Amazon Timestream Write. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TSW and can be listed using the command 'Get-AWSCmdletName -Service TSW'.

### 4.1.11.0 (2021-04-14)
  * Version bump for AWS.Tools.Installer.
  * Documentation examples for DS CmdLets
  * Add Get-EC2Address tag filtering example.
  * Documentation examples for AAS, ECS and EKS Cmdlets
  * Added example for LaunchTemplate for Get-ASAutoscalingGroup CmdLet.
  * Documentation examples for ELB2 CmdLets
  * Removed "PS C:\> " from all PowerShell API CmdLet examples.
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.15.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBProfile: added parameter DataRetentionOptIn.
    * Modified cmdlet Update-ALXBProfile: added parameter DataRetentionOptIn.
  * Amazon Application Migration Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MGN and can be listed using the command 'Get-AWSCmdletName -Service MGN'.
  * Amazon AppStream
    * Added cmdlet New-APSUpdatedImage leveraging the CreateUpdatedImage service API.
  * Amazon Auto Scaling
    * Added cmdlet Get-ASWarmPool leveraging the DescribeWarmPool service API.
    * Added cmdlet Remove-ASWarmPool leveraging the DeleteWarmPool service API.
    * Added cmdlet Write-ASWarmPool leveraging the PutWarmPool service API.
  * Amazon Cloud9
    * Modified cmdlet New-C9EnvironmentEC2: added parameter ImageId.
  * Amazon CloudFormation
    * Modified cmdlet New-CFNStackInstance: added parameter DeploymentTargets_AccountsUrl.
    * Modified cmdlet Remove-CFNStackInstance: added parameter DeploymentTargets_AccountsUrl.
    * Modified cmdlet Update-CFNStackInstance: added parameter DeploymentTargets_AccountsUrl.
    * Modified cmdlet Update-CFNStackSet: added parameter DeploymentTargets_AccountsUrl.
  * Amazon CloudWatch
    * Added cmdlet Get-CWMetricStream leveraging the GetMetricStream service API.
    * Added cmdlet Get-CWMetricStreamList leveraging the ListMetricStreams service API.
    * Added cmdlet Remove-CWMetricStream leveraging the DeleteMetricStream service API.
    * Added cmdlet Start-CWMetricStream leveraging the StartMetricStreams service API.
    * Added cmdlet Stop-CWMetricStream leveraging the StopMetricStreams service API.
    * Added cmdlet Write-CWMetricStream leveraging the PutMetricStream service API.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters Artifacts_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * Modified cmdlet Start-CBBatch: added parameters ArtifactsOverride_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * Modified cmdlet Start-CBBuild: added parameters ArtifactsOverride_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
    * Modified cmdlet Update-CBProject: added parameters Artifacts_BucketOwnerAccess and S3Logs_BucketOwnerAccess.
  * Amazon CodeStar Connections
    * Modified cmdlet New-CSTCHost: added parameter Tag.
  * Amazon Comprehend
    * Modified cmdlet New-COMPDocumentClassifier: added parameter ModelKmsKeyId.
    * Modified cmdlet New-COMPEndpoint: added parameter DataAccessRoleArn.
    * Modified cmdlet New-COMPEntityRecognizer: added parameter ModelKmsKeyId.
  * Amazon Config
    * Added cmdlet Get-CFGAggregateComplianceByConformancePack leveraging the DescribeAggregateComplianceByConformancePacks service API.
    * Added cmdlet Get-CFGAggregateConformancePackComplianceSummary leveraging the GetAggregateConformancePackComplianceSummary service API.
  * Amazon Connect Customer Profiles
    * Modified cmdlet Write-CPFIntegration: added parameters FlowDefinition_Description, FlowDefinition_FlowName, FlowDefinition_KmsArn, FlowDefinition_Task, IncrementalPullConfig_DatetimeTypeFieldName, Marketo_Object, S3_BucketName, S3_BucketPrefix, Salesforce_EnableDynamicFieldUpdate, Salesforce_IncludeDeletedRecord, Salesforce_Object, Scheduled_DataPullMode, Scheduled_FirstExecutionFrom, Scheduled_ScheduleEndTime, Scheduled_ScheduleExpression, Scheduled_ScheduleOffset, Scheduled_ScheduleStartTime, Scheduled_Timezone, ServiceNow_Object, SourceFlowConfig_ConnectorProfileName, SourceFlowConfig_ConnectorType, TriggerConfig_TriggerType and Zendesk_Object.
  * Amazon Cost Explorer
    * Modified cmdlet New-CECostCategoryDefinition: added parameter DefaultValue.
    * Modified cmdlet Update-CECostCategoryDefinition: added parameter DefaultValue.
  * Amazon Detective
    * Added cmdlet Add-DTCTResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-DTCTResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-DTCTResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-DTCTGraph: added parameter Tag.
  * Amazon Direct Connect
    * Added cmdlet Add-DCMacSecKey leveraging the AssociateMacSecKey service API.
    * Added cmdlet Remove-DCMacSecKey leveraging the DisassociateMacSecKey service API.
    * Added cmdlet Update-DCConnection leveraging the UpdateConnection service API.
    * Modified cmdlet New-DCConnection: added parameter RequestMACSec.
    * Modified cmdlet New-DCLag: added parameter RequestMACSec.
    * Modified cmdlet Update-DCLag: added parameter EncryptionMode.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Added cmdlet Add-DOCSourceIdentifierToSubscription leveraging the AddSourceIdentifierToSubscription service API.
    * Added cmdlet Edit-DOCEventSubscription leveraging the ModifyEventSubscription service API.
    * Added cmdlet Get-DOCEventSubscription leveraging the DescribeEventSubscriptions service API.
    * Added cmdlet New-DOCEventSubscription leveraging the CreateEventSubscription service API.
    * Added cmdlet Remove-DOCEventSubscription leveraging the DeleteEventSubscription service API.
    * Added cmdlet Remove-DOCSourceIdentifierFromSubscription leveraging the RemoveSourceIdentifierFromSubscription service API.
  * Amazon EC2 Image Builder
    * Modified cmdlet New-EC2IBContainerRecipe: added parameters InstanceConfiguration_BlockDeviceMapping and InstanceConfiguration_Image.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2SerialConsoleAccess leveraging the DisableSerialConsoleAccess service API.
    * Added cmdlet Enable-EC2SerialConsoleAccess leveraging the EnableSerialConsoleAccess service API.
    * Added cmdlet Get-EC2FlowLogsIntegrationTemplate leveraging the GetFlowLogsIntegrationTemplate service API.
    * Added cmdlet Get-EC2ReplaceRootVolumeTask leveraging the DescribeReplaceRootVolumeTasks service API.
    * Added cmdlet Get-EC2SerialConsoleAccessStatus leveraging the GetSerialConsoleAccessStatus service API.
    * Added cmdlet Get-EC2StoreImageTask leveraging the DescribeStoreImageTasks service API.
    * Added cmdlet New-EC2ReplaceRootVolumeTask leveraging the CreateReplaceRootVolumeTask service API.
    * Added cmdlet New-EC2RestoreImageTask leveraging the CreateRestoreImageTask service API.
    * Added cmdlet New-EC2StoreImageTask leveraging the CreateStoreImageTask service API.
  * Amazon ElastiCache
    * Modified cmdlet Copy-ECSnapshot: added parameter Tag.
    * Modified cmdlet New-ECCacheParameterGroup: added parameter Tag.
    * Modified cmdlet New-ECCacheSecurityGroup: added parameter Tag.
    * Modified cmdlet New-ECCacheSubnetGroup: added parameter Tag.
    * Modified cmdlet New-ECSnapshot: added parameter Tag.
    * Modified cmdlet New-ECUser: added parameter Tag.
    * Modified cmdlet New-ECUserGroup: added parameter Tag.
    * Modified cmdlet Request-ECReservedCacheNodesOffering: added parameter Tag.
  * Amazon Elemental MediaPackage
    * Modified cmdlet New-EMPOriginEndpoint: added parameters EncryptionContractConfiguration_PresetSpeke20Audio and EncryptionContractConfiguration_PresetSpeke20Video.
    * Modified cmdlet Update-EMPOriginEndpoint: added parameters EncryptionContractConfiguration_PresetSpeke20Audio and EncryptionContractConfiguration_PresetSpeke20Video.
  * Amazon Fraud Detector
    * Added cmdlet Get-FDBatchPredictionJob leveraging the GetBatchPredictionJobs service API.
    * Added cmdlet New-FDBatchPredictionJob leveraging the CreateBatchPredictionJob service API.
    * Added cmdlet Remove-FDBatchPredictionJob leveraging the DeleteBatchPredictionJob service API.
    * Added cmdlet Stop-FDBatchPredictionJob leveraging the CancelBatchPredictionJob service API.
  * Amazon FSx
    * Added cmdlet Copy-FSXBackup leveraging the CopyBackup service API.
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameter KmsKeyId.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLGameSessionQueue: added parameters CustomEventData and NotificationTarget.
    * Modified cmdlet Update-GMLGameSessionQueue: added parameters CustomEventData and NotificationTarget.
  * Amazon IAM Access Analyzer
    * Added cmdlet Get-IAMAAGeneratedPolicy leveraging the GetGeneratedPolicy service API.
    * Added cmdlet Get-IAMAAPolicyGenerationList leveraging the ListPolicyGenerations service API.
    * Added cmdlet Start-IAMAAPolicyGeneration leveraging the StartPolicyGeneration service API.
    * Added cmdlet Stop-IAMAAPolicyGeneration leveraging the CancelPolicyGeneration service API.
  * Amazon Interactive Video Service
    * Added cmdlet Get-IVSRecordingConfiguration leveraging the GetRecordingConfiguration service API.
    * Added cmdlet Get-IVSRecordingConfigurationList leveraging the ListRecordingConfigurations service API.
    * Added cmdlet New-IVSRecordingConfiguration leveraging the CreateRecordingConfiguration service API.
    * Added cmdlet Remove-IVSRecordingConfiguration leveraging the DeleteRecordingConfiguration service API.
    * Modified cmdlet Get-IVSChannelList: added parameter FilterByRecordingConfigurationArn.
    * Modified cmdlet New-IVSChannel: added parameter RecordingConfigurationArn.
    * Modified cmdlet Update-IVSChannel: added parameter RecordingConfigurationArn.
  * Amazon IoT
    * Modified cmdlet Get-IOTThingList: added parameter UsePrefixAttributeValue.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWWirelessDevice: added parameter Tag.
  * Amazon Location Service
    * Modified cmdlet New-LOCGeofenceCollection: added parameter PricingPlanDataSource.
    * Modified cmdlet New-LOCTracker: added parameter PricingPlanDataSource.
  * Amazon Lookout for Metrics. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LOM and can be listed using the command 'Get-AWSCmdletName -Service LOM'.
  * Amazon Pinpoint
    * Modified cmdlet New-PINJourney: added parameters Limits_EndpointReentryInterval, WriteJourneyRequest_RefreshOnSegmentUpdate and WriteJourneyRequest_WaitForQuietTime.
    * Modified cmdlet Update-PINJourney: added parameters Limits_EndpointReentryInterval, WriteJourneyRequest_RefreshOnSegmentUpdate and WriteJourneyRequest_WaitForQuietTime.
  * Amazon Redshift
    * Added cmdlet Approve-RSEndpointAccess leveraging the AuthorizeEndpointAccess service API.
    * Added cmdlet Edit-RSEndpointAccess leveraging the ModifyEndpointAccess service API.
    * Added cmdlet Get-RSEndpointAccess leveraging the DescribeEndpointAccess service API.
    * Added cmdlet Get-RSEndpointAuthorization leveraging the DescribeEndpointAuthorization service API.
    * Added cmdlet New-RSEndpointAccess leveraging the CreateEndpointAccess service API.
    * Added cmdlet Remove-RSEndpointAccess leveraging the DeleteEndpointAccess service API.
    * Added cmdlet Revoke-RSEndpointAccess leveraging the RevokeEndpointAccess service API.
    * Modified cmdlet Restore-RSTableFromClusterSnapshot: added parameter EnableCaseSensitiveIdentifier.
  * Amazon Rekognition
    * Added cmdlet Add-REKResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-REKResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-REKResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-REKCollection: added parameter Tag.
    * Modified cmdlet New-REKProjectVersion: added parameter Tag.
    * Modified cmdlet New-REKStreamProcessor: added parameter Tag.
  * Amazon Route 53 Resolver
    * Added cmdlet Edit-R53RFirewallConfig leveraging the UpdateFirewallConfig service API.
    * Added cmdlet Edit-R53RFirewallDomain leveraging the UpdateFirewallDomains service API.
    * Added cmdlet Edit-R53RFirewallRule leveraging the UpdateFirewallRule service API.
    * Added cmdlet Edit-R53RFirewallRuleGroupAssociation leveraging the UpdateFirewallRuleGroupAssociation service API.
    * Added cmdlet Edit-R53RFirewallRuleGroupPolicy leveraging the PutFirewallRuleGroupPolicy service API.
    * Added cmdlet Get-R53RFirewallConfig leveraging the GetFirewallConfig service API.
    * Added cmdlet Get-R53RFirewallConfigList leveraging the ListFirewallConfigs service API.
    * Added cmdlet Get-R53RFirewallDomain leveraging the ListFirewallDomains service API.
    * Added cmdlet Get-R53RFirewallDomainList leveraging the GetFirewallDomainList service API.
    * Added cmdlet Get-R53RFirewallDomainListList leveraging the ListFirewallDomainLists service API.
    * Added cmdlet Get-R53RFirewallRuleGroup leveraging the GetFirewallRuleGroup service API.
    * Added cmdlet Get-R53RFirewallRuleGroupAssociation leveraging the GetFirewallRuleGroupAssociation service API.
    * Added cmdlet Get-R53RFirewallRuleGroupAssociationList leveraging the ListFirewallRuleGroupAssociations service API.
    * Added cmdlet Get-R53RFirewallRuleGroupList leveraging the ListFirewallRuleGroups service API.
    * Added cmdlet Get-R53RFirewallRuleGroupPolicy leveraging the GetFirewallRuleGroupPolicy service API.
    * Added cmdlet Get-R53RFirewallRuleList leveraging the ListFirewallRules service API.
    * Added cmdlet Import-R53RFirewallDomainList leveraging the ImportFirewallDomains service API.
    * Added cmdlet New-R53RFirewallDomainList leveraging the CreateFirewallDomainList service API.
    * Added cmdlet New-R53RFirewallRule leveraging the CreateFirewallRule service API.
    * Added cmdlet New-R53RFirewallRuleGroup leveraging the CreateFirewallRuleGroup service API.
    * Added cmdlet New-R53RFirewallRuleGroupAssociation leveraging the AssociateFirewallRuleGroup service API.
    * Added cmdlet Remove-R53RFirewallDomainList leveraging the DeleteFirewallDomainList service API.
    * Added cmdlet Remove-R53RFirewallRule leveraging the DeleteFirewallRule service API.
    * Added cmdlet Remove-R53RFirewallRuleGroup leveraging the DeleteFirewallRuleGroup service API.
    * Added cmdlet Remove-R53RFirewallRuleGroupAssociation leveraging the DisassociateFirewallRuleGroup service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMTrainingJob: added parameter Environment.
  * Amazon Security Token Service
    * Modified cmdlet Use-STSRole: added parameter SourceIdentity.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGSGFileSystemAssociation leveraging the DescribeFileSystemAssociations service API.
    * Added cmdlet Get-SGSGFileSystemAssociationList leveraging the ListFileSystemAssociations service API.
    * Added cmdlet New-SGSGFileSystemAssociation leveraging the AssociateFileSystem service API.
    * Added cmdlet Remove-SGSGFileSystemAssociation leveraging the DisassociateFileSystem service API.
    * Added cmdlet Update-SGSGFileSystemAssociation leveraging the UpdateFileSystemAssociation service API.
  * Amazon Systems Manager
    * Added cmdlet Reset-SSMParameterVersionLabel leveraging the UnlabelParameterVersion service API.
    * Modified cmdlet New-SSMResourceDataSync: added parameter SyncSource_EnableAllOpsDataSource.
    * Modified cmdlet Start-SSMChangeRequestExecution: added parameters ChangeDetail and ScheduledEndTime.
    * Modified cmdlet Update-SSMResourceDataSync: added parameter SyncSource_EnableAllOpsDataSource.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2RuleGroup: added parameter CustomResponseBody.
    * Modified cmdlet New-WAF2WebACL: added parameter CustomResponseBody.
    * Modified cmdlet Update-WAF2RuleGroup: added parameter CustomResponseBody.
    * Modified cmdlet Update-WAF2WebACL: added parameter CustomResponseBody.
    * Modified cmdlet Write-WAF2LoggingConfiguration: added parameters LoggingFilter_DefaultBehavior and LoggingFilter_Filter.
  * Amazon WorkMail
    * Added cmdlet Get-WMMobileDeviceAccessEffect leveraging the GetMobileDeviceAccessEffect service API.
    * Added cmdlet Get-WMMobileDeviceAccessRuleList leveraging the ListMobileDeviceAccessRules service API.
    * Added cmdlet New-WMMobileDeviceAccessRule leveraging the CreateMobileDeviceAccessRule service API.
    * Added cmdlet Remove-WMMobileDeviceAccessRule leveraging the DeleteMobileDeviceAccessRule service API.
    * Added cmdlet Update-WMMobileDeviceAccessRule leveraging the UpdateMobileDeviceAccessRule service API.

### 4.1.10.0 (2021-03-22)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.135.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBAddressBook: added parameter Tag.
    * Modified cmdlet New-ALXBConferenceProvider: added parameter Tag.
    * Modified cmdlet New-ALXBContact: added parameter Tag.
    * Modified cmdlet New-ALXBGatewayGroup: added parameter Tag.
    * Modified cmdlet New-ALXBNetworkProfile: added parameter Tag.
    * Modified cmdlet Register-ALXBAVSDevice: added parameter Tag.
  * Amazon AmazonMWAA
    * Modified cmdlet New-MWAAEnvironment: added parameter MinWorker.
    * Modified cmdlet Update-MWAAEnvironment: added parameter MinWorker.
  * Amazon Athena
    * Added cmdlet Get-ATHPreparedStatement leveraging the GetPreparedStatement service API.
    * Added cmdlet Get-ATHPreparedStatementList leveraging the ListPreparedStatements service API.
    * Added cmdlet New-ATHPreparedStatement leveraging the CreatePreparedStatement service API.
    * Added cmdlet Remove-ATHPreparedStatement leveraging the DeletePreparedStatement service API.
    * Added cmdlet Update-ATHPreparedStatement leveraging the UpdatePreparedStatement service API.
  * Amazon Auto Scaling
    * Modified cmdlet Start-ASInstanceRefresh: added parameters Preferences_CheckpointDelay and Preferences_CheckpointPercentage.
    * Modified cmdlet Write-ASScheduledUpdateGroupAction: added parameter TimeZone.
  * Amazon Backup
    * Added cmdlet Unlock-BAKRecoveryPoint leveraging the DisassociateRecoveryPoint service API.
  * Amazon Certificate Manager
    * Added cmdlet Get-ACMAccountConfiguration leveraging the GetAccountConfiguration service API.
    * Added cmdlet Write-ACMAccountConfiguration leveraging the PutAccountConfiguration service API.
  * Amazon Cloud Map
    * Modified cmdlet New-SDService: added parameter Type.
  * Amazon CloudWatch Events
    * Added cmdlet Clear-CWEConnection leveraging the DeauthorizeConnection service API.
    * Added cmdlet Get-CWEApiDestination leveraging the DescribeApiDestination service API.
    * Added cmdlet Get-CWEApiDestinationList leveraging the ListApiDestinations service API.
    * Added cmdlet Get-CWEConnection leveraging the DescribeConnection service API.
    * Added cmdlet Get-CWEConnectionList leveraging the ListConnections service API.
    * Added cmdlet New-CWEApiDestination leveraging the CreateApiDestination service API.
    * Added cmdlet New-CWEConnection leveraging the CreateConnection service API.
    * Added cmdlet Remove-CWEApiDestination leveraging the DeleteApiDestination service API.
    * Added cmdlet Remove-CWEConnection leveraging the DeleteConnection service API.
    * Added cmdlet Update-CWEApiDestination leveraging the UpdateApiDestination service API.
    * Added cmdlet Update-CWEConnection leveraging the UpdateConnection service API.
  * Amazon CodeBuild
    * Modified cmdlet Start-CBBatch: added parameter DebugSessionEnabled.
  * Amazon CodeDeploy
    * Modified cmdlet New-CDDeploymentGroup: added parameter OutdatedInstancesStrategy.
    * Modified cmdlet Update-CDDeploymentGroup: added parameter OutdatedInstancesStrategy.
  * Amazon CodePipeline
    * Modified cmdlet Get-CPPipelineList: added parameter MaxResult.
  * Amazon Comprehend
    * Added cmdlet Find-COMPPiiEntityType leveraging the ContainsPiiEntities service API.
  * Amazon Cost and Usage Report
    * Modified cmdlet Edit-CURReportDefinition: added parameter ReportDefinition_BillingViewArn.
    * Modified cmdlet Write-CURReportDefinition: added parameter ReportDefinition_BillingViewArn.
  * Amazon DataSync
    * Added cmdlet Update-DSYNLocationNfs leveraging the UpdateLocationNfs service API.
    * Added cmdlet Update-DSYNLocationObjectStorage leveraging the UpdateLocationObjectStorage service API.
    * Added cmdlet Update-DSYNLocationSmb leveraging the UpdateLocationSmb service API.
  * Amazon EC2 Container Service
    * Added cmdlet Invoke-ECSCommand leveraging the ExecuteCommand service API.
    * Added cmdlet Update-ECSCluster leveraging the UpdateCluster service API.
    * Modified cmdlet New-ECSCluster: added parameters ExecuteCommandConfiguration_KmsKeyId, ExecuteCommandConfiguration_Logging, LogConfiguration_CloudWatchEncryptionEnabled, LogConfiguration_CloudWatchLogGroupName, LogConfiguration_S3BucketName, LogConfiguration_S3EncryptionEnabled and LogConfiguration_S3KeyPrefix.
    * Modified cmdlet New-ECSService: added parameter EnableExecuteCommand.
    * Modified cmdlet New-ECSTask: added parameter EnableExecuteCommand.
    * Modified cmdlet Start-ECSTask: added parameter EnableExecuteCommand.
    * Modified cmdlet Update-ECSService: added parameter EnableExecuteCommand.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Register-EC2Image: added parameter BootMode.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Add-EKSEncryptionConfig leveraging the AssociateEncryptionConfig service API.
  * Amazon Elastic File System
    * Modified cmdlet New-EFSFileSystem: added parameters AvailabilityZoneName and Backup.
  * Amazon Elastic MapReduce
    * Added cmdlet Update-EMRStudio leveraging the UpdateStudio service API.
    * Modified cmdlet Add-EMRInstanceFleet: added parameters CapacityReservationOptions_CapacityReservationPreference, CapacityReservationOptions_CapacityReservationResourceGroupArn and CapacityReservationOptions_UsageStrategy.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameter TagList.
  * Amazon Elemental MediaConnect
    * Modified cmdlet Update-EMCNFlowOutput: added parameter MinLatency.
    * Modified cmdlet Update-EMCNFlowSource: added parameter MinLatency.
  * Amazon Elemental MediaLive
    * Modified cmdlet Move-EMLInputDevice: added parameter TargetRegion.
  * Amazon Elemental MediaTailor
    * Added cmdlet Get-EMTChannel leveraging the DescribeChannel service API.
    * Added cmdlet Get-EMTChannelList leveraging the ListChannels service API.
    * Added cmdlet Get-EMTChannelPolicy leveraging the GetChannelPolicy service API.
    * Added cmdlet Get-EMTChannelSchedule leveraging the GetChannelSchedule service API.
    * Added cmdlet Get-EMTProgram leveraging the DescribeProgram service API.
    * Added cmdlet Get-EMTSourceLocation leveraging the DescribeSourceLocation service API.
    * Added cmdlet Get-EMTSourceLocationList leveraging the ListSourceLocations service API.
    * Added cmdlet Get-EMTVodSource leveraging the DescribeVodSource service API.
    * Added cmdlet Get-EMTVodSourceList leveraging the ListVodSources service API.
    * Added cmdlet New-EMTChannel leveraging the CreateChannel service API.
    * Added cmdlet New-EMTProgram leveraging the CreateProgram service API.
    * Added cmdlet New-EMTSourceLocation leveraging the CreateSourceLocation service API.
    * Added cmdlet New-EMTVodSource leveraging the CreateVodSource service API.
    * Added cmdlet Remove-EMTChannel leveraging the DeleteChannel service API.
    * Added cmdlet Remove-EMTChannelPolicy leveraging the DeleteChannelPolicy service API.
    * Added cmdlet Remove-EMTProgram leveraging the DeleteProgram service API.
    * Added cmdlet Remove-EMTSourceLocation leveraging the DeleteSourceLocation service API.
    * Added cmdlet Remove-EMTVodSource leveraging the DeleteVodSource service API.
    * Added cmdlet Start-EMTChannel leveraging the StartChannel service API.
    * Added cmdlet Stop-EMTChannel leveraging the StopChannel service API.
    * Added cmdlet Update-EMTChannel leveraging the UpdateChannel service API.
    * Added cmdlet Update-EMTSourceLocation leveraging the UpdateSourceLocation service API.
    * Added cmdlet Update-EMTVodSource leveraging the UpdateVodSource service API.
    * Added cmdlet Write-EMTChannelPolicy leveraging the PutChannelPolicy service API.
  * Amazon EventBridge
    * Added cmdlet Clear-EVBConnection leveraging the DeauthorizeConnection service API.
    * Added cmdlet Get-EVBApiDestination leveraging the DescribeApiDestination service API.
    * Added cmdlet Get-EVBApiDestinationList leveraging the ListApiDestinations service API.
    * Added cmdlet Get-EVBConnection leveraging the DescribeConnection service API.
    * Added cmdlet Get-EVBConnectionList leveraging the ListConnections service API.
    * Added cmdlet New-EVBApiDestination leveraging the CreateApiDestination service API.
    * Added cmdlet New-EVBConnection leveraging the CreateConnection service API.
    * Added cmdlet Remove-EVBApiDestination leveraging the DeleteApiDestination service API.
    * Added cmdlet Remove-EVBConnection leveraging the DeleteConnection service API.
    * Added cmdlet Update-EVBApiDestination leveraging the UpdateApiDestination service API.
    * Added cmdlet Update-EVBConnection leveraging the UpdateConnection service API.
  * Amazon Fault Injection Simulator. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FIS and can be listed using the command 'Get-AWSCmdletName -Service FIS'.
  * Amazon Forecast Service
    * Added cmdlet Stop-FRCResource leveraging the StopResource service API.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLFleetLocationAttribute leveraging the DescribeFleetLocationAttributes service API.
    * Added cmdlet Get-GMLFleetLocationCapacity leveraging the DescribeFleetLocationCapacity service API.
    * Added cmdlet Get-GMLFleetLocationUtilization leveraging the DescribeFleetLocationUtilization service API.
    * Added cmdlet New-GMLFleetLocation leveraging the CreateFleetLocations service API.
    * Added cmdlet Remove-GMLFleetLocation leveraging the DeleteFleetLocations service API.
    * Modified cmdlet Find-GMLGameSession: added parameter Location.
    * Modified cmdlet Get-GMLEC2InstanceLimit: added parameter Location.
    * Modified cmdlet Get-GMLFleetPortSetting: added parameter Location.
    * Modified cmdlet Get-GMLGameSession: added parameter Location.
    * Modified cmdlet Get-GMLGameSessionDetail: added parameter Location.
    * Modified cmdlet Get-GMLInstance: added parameter Location.
    * Modified cmdlet Get-GMLScalingPolicy: added parameter Location.
    * Modified cmdlet New-GMLFleet: added parameter Location.
    * Modified cmdlet New-GMLGameSession: added parameter Location.
    * Modified cmdlet New-GMLGameSessionQueue: added parameters FilterConfiguration_AllowedLocation, PriorityConfiguration_LocationOrder and PriorityConfiguration_PriorityOrder.
    * Modified cmdlet Start-GMLFleetAction: added parameter Location.
    * Modified cmdlet Stop-GMLFleetAction: added parameter Location.
    * Modified cmdlet Update-GMLFleetCapacity: added parameter Location.
    * Modified cmdlet Update-GMLGameSessionQueue: added parameters FilterConfiguration_AllowedLocation, PriorityConfiguration_LocationOrder and PriorityConfiguration_PriorityOrder.
  * Amazon IAM Access Analyzer
    * Added cmdlet Get-IAMAAAccessPreview leveraging the GetAccessPreview service API.
    * Added cmdlet Get-IAMAAAccessPreviewFindingList leveraging the ListAccessPreviewFindings service API.
    * Added cmdlet Get-IAMAAAccessPreviewList leveraging the ListAccessPreviews service API.
    * Added cmdlet New-IAMAAAccessPreview leveraging the CreateAccessPreview service API.
    * Added cmdlet Use-IAMAAPolicyValidation leveraging the ValidatePolicy service API.
  * Amazon IoT Wireless
    * Modified cmdlet Join-IOTWAwsAccountWithPartnerAccount: added parameter Tag.
    * Modified cmdlet New-IOTWWirelessGatewayTaskDefinition: added parameter Tag.
  * Amazon Macie 2
    * Added cmdlet Get-MAC2FindingsPublicationConfiguration leveraging the GetFindingsPublicationConfiguration service API.
    * Added cmdlet Write-MAC2FindingsPublicationConfiguration leveraging the PutFindingsPublicationConfiguration service API.
  * Amazon Redshift
    * Added cmdlet Edit-RSAquaConfiguration leveraging the ModifyAquaConfiguration service API.
    * Modified cmdlet New-RSCluster: added parameter AquaConfigurationStatus.
    * Modified cmdlet Restore-RSFromClusterSnapshot: added parameter AquaConfigurationStatus.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSDBProxyEndpoint leveraging the ModifyDBProxyEndpoint service API.
    * Added cmdlet Get-RDSDBProxyEndpoint leveraging the DescribeDBProxyEndpoints service API.
    * Added cmdlet New-RDSDBProxyEndpoint leveraging the CreateDBProxyEndpoint service API.
    * Added cmdlet Remove-RDSDBProxyEndpoint leveraging the DeleteDBProxyEndpoint service API.
  * Amazon S3 Control
    * Added cmdlet Get-S3CAccessPointConfigurationForObjectLambda leveraging the GetAccessPointConfigurationForObjectLambda service API.
    * Added cmdlet Get-S3CAccessPointForObjectLambda leveraging the GetAccessPointForObjectLambda service API.
    * Added cmdlet Get-S3CAccessPointPolicyForObjectLambda leveraging the GetAccessPointPolicyForObjectLambda service API.
    * Added cmdlet Get-S3CAccessPointPolicyStatusForObjectLambda leveraging the GetAccessPointPolicyStatusForObjectLambda service API.
    * Added cmdlet Get-S3CAccessPointsForObjectLambdaList leveraging the ListAccessPointsForObjectLambda service API.
    * Added cmdlet New-S3CAccessPointForObjectLambda leveraging the CreateAccessPointForObjectLambda service API.
    * Added cmdlet Remove-S3CAccessPointForObjectLambda leveraging the DeleteAccessPointForObjectLambda service API.
    * Added cmdlet Remove-S3CAccessPointPolicyForObjectLambda leveraging the DeleteAccessPointPolicyForObjectLambda service API.
    * Added cmdlet Write-S3CAccessPointConfigurationForObjectLambda leveraging the PutAccessPointConfigurationForObjectLambda service API.
    * Added cmdlet Write-S3CAccessPointPolicyForObjectLambda leveraging the PutAccessPointPolicyForObjectLambda service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMFeatureGroup: added parameter S3StorageConfig_ResolvedOutputS3Uri.
  * Amazon Secrets Manager
    * Added cmdlet Add-SECSecretToRegion leveraging the ReplicateSecretToRegions service API.
    * Added cmdlet Remove-SECRegionsFromReplication leveraging the RemoveRegionsFromReplication service API.
    * Added cmdlet Stop-SECReplicationToReplica leveraging the StopReplicationToReplica service API.
    * Modified cmdlet New-SECSecret: added parameters AddReplicaRegion and ForceOverwriteReplicaSecret.
  * Amazon Shield
    * Added cmdlet Add-SHLDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SHLDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SHLDResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-SHLDProtection: added parameter Tag.
    * Modified cmdlet New-SHLDProtectionGroup: added parameter Tag.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Write-S3GetObjectResponse leveraging the WriteGetObjectResponse service API.
    * Modified cmdlet Get-S3ObjectTagSet: added parameter RequestPayer.
    * Modified cmdlet Write-S3ObjectTagSet: added parameter RequestPayer.
  * Amazon Systems Manager
    * Modified cmdlet Get-SSMDeployablePatchSnapshotForInstance: added parameters ApprovalRules_PatchRule, BaselineOverride_ApprovedPatch, BaselineOverride_ApprovedPatchesComplianceLevel, BaselineOverride_ApprovedPatchesEnableNonSecurity, BaselineOverride_OperatingSystem, BaselineOverride_RejectedPatch, BaselineOverride_RejectedPatchesAction, BaselineOverride_Source and GlobalFilters_PatchFilter.
    * Modified cmdlet New-SSMOpsMetadata: added parameter Tag.
  * Amazon Well-Architected Tool
    * Added cmdlet Add-WATResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WATResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WATResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-WATWorkload: added parameter Tag.
  * Amazon WorkSpaces
    * Added cmdlet New-WKSWorkspaceBundle leveraging the CreateWorkspaceBundle service API.
    * Added cmdlet Remove-WKSWorkspaceBundle leveraging the DeleteWorkspaceBundle service API.
    * Added cmdlet Update-WKSWorkspaceBundle leveraging the UpdateWorkspaceBundle service API.

### 4.1.9.0 (2021-02-25)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.118.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameters Scheduled_FirstExecutionFrom and Scheduled_ScheduleOffset.
    * Modified cmdlet Update-AFFlow: added parameters Scheduled_FirstExecutionFrom and Scheduled_ScheduleOffset.
  * Amazon AppSync
    * Modified cmdlet New-ASYNFunction: added parameters LambdaConflictHandlerConfig_LambdaConflictHandlerArn, SyncConfig_ConflictDetection and SyncConfig_ConflictHandler.
    * Modified cmdlet Update-ASYNFunction: added parameters LambdaConflictHandlerConfig_LambdaConflictHandlerArn, SyncConfig_ConflictDetection and SyncConfig_ConflictHandler.
  * Amazon Athena
    * Added cmdlet Get-ATHEngineVersionList leveraging the ListEngineVersions service API.
    * Modified cmdlet New-ATHWorkGroup: added parameters EngineVersion_EffectiveEngineVersion and EngineVersion_SelectedEngineVersion.
    * Modified cmdlet Update-ATHWorkGroup: added parameters EngineVersion_EffectiveEngineVersion and EngineVersion_SelectedEngineVersion.
  * Amazon Auto Scaling
    * Modified cmdlet Get-ASScalingActivity: added parameter IncludeDeletedGroup.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNStackInstance: added parameter CallAs.
    * Modified cmdlet Get-CFNStackInstanceList: added parameter CallAs.
    * Modified cmdlet Get-CFNStackSet: added parameter CallAs.
    * Modified cmdlet Get-CFNStackSetList: added parameter CallAs.
    * Modified cmdlet Get-CFNStackSetOperation: added parameter CallAs.
    * Modified cmdlet Get-CFNStackSetOperationList: added parameter CallAs.
    * Modified cmdlet Get-CFNStackSetOperationResultList: added parameter CallAs.
    * Modified cmdlet New-CFNStackInstance: added parameter CallAs.
    * Modified cmdlet New-CFNStackSet: added parameter CallAs.
    * Modified cmdlet Remove-CFNStackInstance: added parameter CallAs.
    * Modified cmdlet Remove-CFNStackSet: added parameter CallAs.
    * Modified cmdlet Start-CFNStackSetDriftDetection: added parameter CallAs.
    * Modified cmdlet Stop-CFNStackSetOperation: added parameter CallAs.
    * Modified cmdlet Update-CFNStackInstance: added parameter CallAs.
    * Modified cmdlet Update-CFNStackSet: added parameter CallAs.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter ConcurrentBuildLimit.
    * Modified cmdlet New-CBReportGroup: added parameter S3Destination_BucketOwner.
    * Modified cmdlet Update-CBProject: added parameter ConcurrentBuildLimit.
    * Modified cmdlet Update-CBReportGroup: added parameter S3Destination_BucketOwner.
  * Amazon CodePipeline
    * Added cmdlet Get-CPActionTypeDeclaration leveraging the GetActionType service API.
    * Added cmdlet Update-CPActionType leveraging the UpdateActionType service API.
    * Modified cmdlet Get-CPActionType: added parameter RegionFilter.
  * Amazon Config
    * Modified cmdlet Write-CFGDeliveryChannel: added parameter DeliveryChannel_S3KmsKeyArn.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXJob: added parameters Details_ExportRevisionsToS3_Encryption_KmsKeyArn, Details_ExportRevisionsToS3_Encryption_Type, ExportRevisionsToS3_DataSetId and ExportRevisionsToS3_RevisionDestination.
  * Amazon Data Lifecycle Manager
    * Modified cmdlet New-DLMLifecyclePolicy: added parameter PolicyDetails_ResourceLocation.
    * Modified cmdlet Update-DLMLifecyclePolicy: added parameter PolicyDetails_ResourceLocation.
  * Amazon Detective
    * Modified cmdlet New-DTCTMember: added parameter DisableEmailNotification.
  * Amazon DevOps Guru
    * Added cmdlet Get-DGURUFeedback leveraging the DescribeFeedback service API.
  * Amazon EC2 Image Builder
    * Added cmdlet Get-EC2IBImagePackageList leveraging the ListImagePackages service API.
    * Modified cmdlet New-EC2IBImagePipeline: added parameter Schedule_Timezone.
    * Modified cmdlet Update-EC2IBImagePipeline: added parameter Schedule_Timezone.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2AddressAttribute leveraging the ModifyAddressAttribute service API.
    * Added cmdlet Get-EC2AddressesAttribute leveraging the DescribeAddressesAttribute service API.
    * Added cmdlet Reset-EC2AddressAttribute leveraging the ResetAddressAttribute service API.
    * Modified cmdlet Copy-EC2Image: added parameter DestinationOutpostArn.
    * Modified cmdlet Copy-EC2Snapshot: added parameter DestinationOutpostArn.
    * Modified cmdlet New-EC2Snapshot: added parameter OutpostArn.
    * Modified cmdlet New-EC2SnapshotBatch: added parameter OutpostArn.
  * Amazon Elastic Container Registry Public
    * Added cmdlet Add-ECRPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ECRPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ECRPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-ECRPRepository: added parameter Tag.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Add-EKSIdentityProviderConfig leveraging the AssociateIdentityProviderConfig service API.
    * Added cmdlet Get-EKSIdentityProviderConfig leveraging the DescribeIdentityProviderConfig service API.
    * Added cmdlet Get-EKSIdentityProviderConfigList leveraging the ListIdentityProviderConfigs service API.
    * Added cmdlet Remove-EKSIdentityProviderConfig leveraging the DisassociateIdentityProviderConfig service API.
  * Amazon Elasticsearch
    * Added cmdlet Get-ESDomainAutoTune leveraging the DescribeDomainAutoTunes service API.
    * Modified cmdlet New-ESDomain: added parameters AutoTuneOptions_DesiredState and AutoTuneOptions_MaintenanceSchedule.
    * Modified cmdlet Update-ESDomainConfig: added parameters AutoTuneOptions_DesiredState, AutoTuneOptions_MaintenanceSchedule and AutoTuneOptions_RollbackOnDisable.
  * Amazon Elemental MediaLive
    * Added cmdlet New-EMLPartnerInput leveraging the CreatePartnerInput service API.
  * Amazon Elemental MediaPackage VOD
    * Added cmdlet Update-EMPVLog leveraging the ConfigureLogs service API.
    * Modified cmdlet New-EMPVPackagingGroup: added parameter EgressAccessLogs_LogGroupName.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter ConfigurationAlias.
  * Amazon Global Accelerator
    * Modified cmdlet New-GACLCustomRoutingAccelerator: added parameter IpAddress.
  * Amazon Glue
    * Modified cmdlet Get-GLUEPartitionList: added parameter ExcludeColumnSchema.
  * Amazon Identity and Access Management
    * Added cmdlet Add-IAMInstanceProfileTag leveraging the TagInstanceProfile service API.
    * Added cmdlet Add-IAMMFADeviceTag leveraging the TagMFADevice service API.
    * Added cmdlet Add-IAMOpenIDConnectProviderTag leveraging the TagOpenIDConnectProvider service API.
    * Added cmdlet Add-IAMPolicyTag leveraging the TagPolicy service API.
    * Added cmdlet Add-IAMSAMLProviderTag leveraging the TagSAMLProvider service API.
    * Added cmdlet Add-IAMServerCertificateTag leveraging the TagServerCertificate service API.
    * Added cmdlet Get-IAMInstanceProfileTagList leveraging the ListInstanceProfileTags service API.
    * Added cmdlet Get-IAMMFADeviceTagList leveraging the ListMFADeviceTags service API.
    * Added cmdlet Get-IAMOpenIDConnectProviderTagList leveraging the ListOpenIDConnectProviderTags service API.
    * Added cmdlet Get-IAMPolicyTagList leveraging the ListPolicyTags service API.
    * Added cmdlet Get-IAMSAMLProviderTagList leveraging the ListSAMLProviderTags service API.
    * Added cmdlet Get-IAMServerCertificateTagList leveraging the ListServerCertificateTags service API.
    * Added cmdlet Remove-IAMInstanceProfileTag leveraging the UntagInstanceProfile service API.
    * Added cmdlet Remove-IAMMFADeviceTag leveraging the UntagMFADevice service API.
    * Added cmdlet Remove-IAMOpenIDConnectProviderTag leveraging the UntagOpenIDConnectProvider service API.
    * Added cmdlet Remove-IAMPolicyTag leveraging the UntagPolicy service API.
    * Added cmdlet Remove-IAMSAMLProviderTag leveraging the UntagSAMLProvider service API.
    * Added cmdlet Remove-IAMServerCertificateTag leveraging the UntagServerCertificate service API.
    * Modified cmdlet New-IAMInstanceProfile: added parameter Tag.
    * Modified cmdlet New-IAMOpenIDConnectProvider: added parameter Tag.
    * Modified cmdlet New-IAMPolicy: added parameter Tag.
    * Modified cmdlet New-IAMSAMLProvider: added parameter Tag.
    * Modified cmdlet New-IAMVirtualMFADevice: added parameter Tag.
    * Modified cmdlet Publish-IAMServerCertificate: added parameter Tag.
  * Amazon IoT Events
    * Added cmdlet Get-IOTEDetectorModelAnalysis leveraging the DescribeDetectorModelAnalysis service API.
    * Added cmdlet Get-IOTEDetectorModelAnalysisResult leveraging the GetDetectorModelAnalysisResults service API.
    * Added cmdlet Start-IOTEDetectorModelAnalysis leveraging the StartDetectorModelAnalysis service API.
  * Amazon IoT SiteWise
    * Modified cmdlet New-IOTSWAccessPolicy: added parameter IamRole_Arn.
    * Modified cmdlet Update-IOTSWAccessPolicy: added parameter IamRole_Arn.
  * Amazon Macie 2
    * Added cmdlet Get-MAC2AdministratorAccount leveraging the GetAdministratorAccount service API.
    * Added cmdlet Unregister-MAC2FromAdministratorAccount leveraging the DisassociateFromAdministratorAccount service API.
    * Modified cmdlet Approve-MAC2Invitation: added parameter AdministratorAccountId.
    * Modified cmdlet Get-MAC2UsageStatistic: added parameter TimeRange.
    * Modified cmdlet Get-MAC2UsageTotal: added parameters PassThru and TimeRange.
  * Amazon Pinpoint
    * Modified cmdlet New-PINCampaign: added parameters SMSMessage_EntityId, SMSMessage_OriginationNumber and SMSMessage_TemplateId.
    * Modified cmdlet Send-PINMessage: added parameters SMSMessage_EntityId and SMSMessage_TemplateId.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters SMSMessage_EntityId and SMSMessage_TemplateId.
    * Modified cmdlet Update-PINCampaign: added parameters SMSMessage_EntityId, SMSMessage_OriginationNumber and SMSMessage_TemplateId.
  * Amazon QuickSight
    * Modified cmdlet New-QSDataSet: added parameter FieldFolder.
    * Modified cmdlet Update-QSDataSet: added parameter FieldFolder.
  * Amazon Redshift Data API Service
    * Modified cmdlet Get-RSDSchemaList: added parameter ConnectedDatabase.
    * Modified cmdlet Get-RSDStatementList: added parameter RoleLevel.
    * Modified cmdlet Get-RSDTable: added parameter ConnectedDatabase.
    * Modified cmdlet Get-RSDTableList: added parameter ConnectedDatabase.
  * Amazon Relational Database Service
    * Added cmdlet Start-RDSFailoverGlobalCluster leveraging the FailoverGlobalCluster service API.
    * Modified cmdlet Edit-RDSDBInstance: added parameter AwsBackupRecoveryPointArn.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpoint: added parameter TargetContainerHostname.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCompilationJob: added parameter InputConfig_FrameworkVersion.
    * Modified cmdlet New-SMModel: added parameter InferenceExecutionConfig_Mode.
    * Modified cmdlet New-SMPresignedDomainUrl: added parameter ExpiresInSecond.
  * Amazon Security Hub
    * Modified cmdlet Get-SHUBProduct: added parameters PassThru and ProductArn.
  * Amazon WorkMail Message Flow
    * Added cmdlet Write-WMMFRawMessageContent leveraging the PutRawMessageContent service API.

### 4.1.8.0 (2021-02-02)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.101.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHVirtualGateway: added parameters File_PrivateKey, Match_Exact, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName and Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName.
    * Modified cmdlet New-AMSHVirtualNode: added parameters File_PrivateKey, Match_Exact, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName and Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName.
    * Modified cmdlet Update-AMSHVirtualGateway: added parameters File_PrivateKey, Match_Exact, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName and Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName.
    * Modified cmdlet Update-AMSHVirtualNode: added parameters File_PrivateKey, Match_Exact, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain, Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName and Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName.
  * Amazon Application Auto Scaling
    * Modified cmdlet Set-AASScheduledAction: added parameter Timezone.
  * Amazon Audit Manager
    * Modified cmdlet New-AUDMAssessmentFramework: added parameter Tag.
  * Amazon Certificate Manager Private Certificate Authority
    * Modified cmdlet New-PCACertificate: added parameters Extensions_CertificatePolicy, Extensions_ExtendedKeyUsage, Extensions_SubjectAlternativeName, KeyUsage_CRLSign, KeyUsage_DataEncipherment, KeyUsage_DecipherOnly, KeyUsage_DigitalSignature, KeyUsage_EncipherOnly, KeyUsage_KeyAgreement, KeyUsage_KeyCertSign, KeyUsage_KeyEncipherment, KeyUsage_NonRepudiation, Subject_CommonName, Subject_Country, Subject_DistinguishedNameQualifier, Subject_GenerationQualifier, Subject_GivenName, Subject_Initial, Subject_Locality, Subject_Organization, Subject_OrganizationalUnit, Subject_Pseudonym, Subject_SerialNumber, Subject_State, Subject_Surname, Subject_Title and ValidityNotBefore.
  * Amazon Chime
    * Modified cmdlet Get-CHMChannel: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelBan: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelBanList: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelList: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelMembership: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelMembershipForAppInstanceUser: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelMembershipList: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelMembershipsForAppInstanceUserList: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelMessage: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelMessageList: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelModeratedByAppInstanceUser: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelModerator: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelModeratorList: added parameter ChimeBearer.
    * Modified cmdlet Get-CHMChannelsModeratedByAppInstanceUserList: added parameter ChimeBearer.
    * Modified cmdlet Hide-CHMChannelMessage: added parameter ChimeBearer.
    * Modified cmdlet New-CHMAppInstance: added parameter Tag.
    * Modified cmdlet New-CHMAppInstanceUser: added parameter Tag.
    * Modified cmdlet New-CHMChannel: added parameter ChimeBearer.
    * Modified cmdlet New-CHMChannelBan: added parameter ChimeBearer.
    * Modified cmdlet New-CHMChannelMembership: added parameter ChimeBearer.
    * Modified cmdlet New-CHMChannelModerator: added parameter ChimeBearer.
    * Modified cmdlet Remove-CHMChannel: added parameter ChimeBearer.
    * Modified cmdlet Remove-CHMChannelBan: added parameter ChimeBearer.
    * Modified cmdlet Remove-CHMChannelMembership: added parameter ChimeBearer.
    * Modified cmdlet Remove-CHMChannelMessage: added parameter ChimeBearer.
    * Modified cmdlet Remove-CHMChannelModerator: added parameter ChimeBearer.
    * Modified cmdlet Send-CHMChannelMessage: added parameter ChimeBearer.
    * Modified cmdlet Update-CHMChannel: added parameter ChimeBearer.
    * Modified cmdlet Update-CHMChannelMessage: added parameter ChimeBearer.
    * Modified cmdlet Update-CHMChannelReadMarker: added parameter ChimeBearer.
  * Amazon CloudWatch
    * Modified cmdlet Get-CWMetricData: added parameter LabelOptions_Timezone.
  * Amazon Cognito Identity
    * Added cmdlet Get-CGIPrincipalTagAttributeMap leveraging the GetPrincipalTagAttributeMap service API.
    * Added cmdlet Set-CGIPrincipalTagAttributeMap leveraging the SetPrincipalTagAttributeMap service API.
  * Amazon Connect Service
    * Added cmdlet Add-CONNQueueQuickConnect leveraging the AssociateQueueQuickConnects service API.
    * Added cmdlet Get-CONNHoursOfOperation leveraging the DescribeHoursOfOperation service API.
    * Added cmdlet Get-CONNQueue leveraging the DescribeQueue service API.
    * Added cmdlet Get-CONNQueueQuickConnectList leveraging the ListQueueQuickConnects service API.
    * Added cmdlet New-CONNQueue leveraging the CreateQueue service API.
    * Added cmdlet Remove-CONNQueueQuickConnect leveraging the DisassociateQueueQuickConnects service API.
    * Added cmdlet Update-CONNQueueHoursOfOperation leveraging the UpdateQueueHoursOfOperation service API.
    * Added cmdlet Update-CONNQueueMaxContact leveraging the UpdateQueueMaxContacts service API.
    * Added cmdlet Update-CONNQueueName leveraging the UpdateQueueName service API.
    * Added cmdlet Update-CONNQueueOutboundCallerConfig leveraging the UpdateQueueOutboundCallerConfig service API.
    * Added cmdlet Update-CONNQueueStatus leveraging the UpdateQueueStatus service API.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet Copy-DOCDBClusterSnapshot: added parameter SourceRegion.
    * Modified cmdlet New-DOCDBCluster: added parameter SourceRegion.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2CapacityReservation: added parameter Accept.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECGlobalReplicationGroup: added parameter CacheParameterGroupName.
  * Amazon Elasticsearch
    * Modified cmdlet Update-ESDomainConfig: added parameters EncryptionAtRestOption and NodeToNodeEncryptionOptions_Enabled.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLChannel: added parameters Vpc_PublicAddressAllocationId, Vpc_SecurityGroupId and Vpc_SubnetId.
  * Amazon Key Management Service
    * Modified cmdlet Get-KMSGrantList: added parameters GranteePrincipal and GrantId.
  * Amazon Lex Model Building V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LMBV2 and can be listed using the command 'Get-AWSCmdletName -Service LMBV2'.
  * Amazon Lex Runtime V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LRSV2 and can be listed using the command 'Get-AWSCmdletName -Service LRSV2'.
  * Amazon Lightsail
    * Added cmdlet Set-LSIpAddressType leveraging the SetIpAddressType service API.
    * Modified cmdlet Close-LSInstancePublicPort: added parameter PortInfo_Ipv6Cidr.
    * Modified cmdlet New-LSDistribution: added parameter IpAddressType.
    * Modified cmdlet New-LSInstance: added parameter IpAddressType.
    * Modified cmdlet New-LSInstancesFromSnapshot: added parameter IpAddressType.
    * Modified cmdlet New-LSLoadBalancer: added parameter IpAddressType.
    * Modified cmdlet Open-LSInstancePublicPort: added parameter PortInfo_Ipv6Cidr.
  * Amazon Lookout for Vision
    * Added cmdlet Add-LFVResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-LFVResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-LFVResourceTag leveraging the UntagResource service API.
    * [Breaking Change] Modified cmdlet New-LFVModel: removed parameters Description_CreationTimestamp, Description_Description, Description_EvaluationEndTimestamp, Description_KmsKeyId, Description_ModelArn, Description_ModelVersion, Description_Status, Description_StatusMessage, EvaluationManifest_Bucket, EvaluationManifest_Key, EvaluationResult_Bucket, EvaluationResult_Key, Performance_F1Score, Performance_Precision, Performance_Recall, S3Location_Bucket and S3Location_Prefix; added parameters Description and Tag.
  * Amazon Managed Blockchain
    * Added cmdlet Add-MBCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-MBCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-MBCResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-MBCMember: added parameter MemberConfiguration_Tag.
    * Modified cmdlet New-MBCNetwork: added parameters MemberConfiguration_Tag and Tag.
    * Modified cmdlet New-MBCNode: added parameter Tag.
    * Modified cmdlet New-MBCProposal: added parameter Tag.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Update-MSKBrokerType leveraging the UpdateBrokerType service API.
  * Amazon Neptune
    * Modified cmdlet Copy-NPTDBClusterSnapshot: added parameter SourceRegion.
    * Modified cmdlet New-NPTDBCluster: added parameter SourceRegion.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSGlobalCluster: added parameters AllowMajorVersionUpgrade and EngineVersion.
  * Amazon Resource Groups Tagging API
    * Modified cmdlet Get-RGTResource: added parameter ResourceARNList.
  * Amazon S3 Control
    * Modified cmdlet New-S3CJob: added parameter Operation_S3DeleteObjectTagging.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Write-SES2EmailIdentityConfigurationSetAttribute leveraging the PutEmailIdentityConfigurationSetAttributes service API.
    * Modified cmdlet New-SES2EmailIdentity: added parameter ConfigurationSetName.
  * Amazon Systems Manager
    * Modified cmdlet Get-SSMDocumentPermission: added parameters MaxResult, NextToken and NoAutoIteration.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter Domain.
    * Modified cmdlet New-TFRUser: added parameters PosixProfile_Gid, PosixProfile_SecondaryGid and PosixProfile_Uid.
    * Modified cmdlet Update-TFRUser: added parameters PosixProfile_Gid, PosixProfile_SecondaryGid and PosixProfile_Uid.

### 4.1.7.0 (2021-01-05)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.5.84.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Use ECSTaskCredentials when either AWS_CONTAINER_CREDENTIALS_RELATIVE_URI or AWS_CONTAINER_CREDENTIALS_FULL_URI set
  * Amazon API Gateway V2
    * Modified cmdlet New-AG2Integration: added parameter ResponseParameter.
    * Modified cmdlet Update-AG2Integration: added parameter ResponseParameter.
  * Amazon Compute Optimizer
    * Added cmdlet Get-COLambdaFunctionRecommendation leveraging the GetLambdaFunctionRecommendations service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters OracleSettings_SecretsManagerOracleAsmAccessRoleArn and OracleSettings_SecretsManagerOracleAsmSecretId.
    * Modified cmdlet New-DMSEndpoint: added parameters OracleSettings_SecretsManagerOracleAsmAccessRoleArn and OracleSettings_SecretsManagerOracleAsmSecretId.
  * Amazon HealthLake
    * Added cmdlet Get-AHLFHIRExportJob leveraging the DescribeFHIRExportJob service API.
    * Added cmdlet Start-AHLFHIRExportJob leveraging the StartFHIRExportJob service API.
  * Amazon Resource Groups
    * Added cmdlet Write-RGGroupConfiguration leveraging the PutGroupConfiguration service API.
