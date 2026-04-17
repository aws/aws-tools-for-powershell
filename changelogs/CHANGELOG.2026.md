### 5.0.197 (2026-04-17 19:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.233.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonConnectCampaignServiceV2
    * Added cmdlet Remove-CCS2CampaignEntryLimit leveraging the DeleteCampaignEntryLimits service API.
    * Added cmdlet Update-CCS2CampaignEntryLimit leveraging the UpdateCampaignEntryLimits service API.
    * Modified cmdlet New-CCS2Campaign: added parameters EntryLimitsConfig_MaxEntryCount and EntryLimitsConfig_MinEntryInterval.
  * Amazon Clean Rooms Service
    * Modified cmdlet Start-CRSProtectedJob: added parameter ComputeConfiguration_Worker_Properties_Spark.
  * Amazon Connect Service
    * [Breaking Change] Modified cmdlet Get-CONNTestCaseExecutionList: the type of parameter EndTime changed from System.DateTime to System.Int64; the type of parameter StartTime changed from System.DateTime to System.Int64.
  * Amazon EC2 Image Builder
    * Modified cmdlet Import-EC2IBDiskImage: added parameters RegisterImageOptions_SecureBootEnabled, RegisterImageOptions_UefiData and WindowsConfiguration_ImageIndex.
  * Amazon Ground Station
    * Added cmdlet Get-GSAntennaList leveraging the ListAntennas service API.
    * Added cmdlet Get-GSContactVersionDetail leveraging the DescribeContactVersion service API.
    * Added cmdlet Get-GSContactVersionList leveraging the ListContactVersions service API.
    * Added cmdlet Get-GSGroundStationReservationList leveraging the ListGroundStationReservations service API.
    * Added cmdlet Update-GSContact leveraging the UpdateContact service API.
    * Modified cmdlet Add-GSReservedContact: added parameters TrackingOverrides_ProgramTrackSettings_Oem_EphemerisId and TrackingOverrides_ProgramTrackSettings_Tle_EphemerisId.
  * Amazon QuickSight
    * Modified cmdlet Initialize-QSEmbedUrlForRegisteredUserWithIdentity: added parameters ExperienceConfiguration_Dashboard_FeatureConfigurations_DashboardCustomizationSummary_Enabled and ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_DashboardCustomizationSummary_Enabled.
    * Modified cmdlet New-QSCustomPermission: added parameter Capabilities_GenerateAnalyses.
    * Modified cmdlet New-QSDataSource: added parameters DataSourceParameters_AthenaParameters_ConsumerAccountRoleArn and DataSourceParameters_S3TablesParameters_TableBucketArn.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameters ExperienceConfiguration_Dashboard_FeatureConfigurations_DashboardCustomizationSummary_Enabled and ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_DashboardCustomizationSummary_Enabled.
    * Modified cmdlet Update-QSCustomPermission: added parameter Capabilities_GenerateAnalyses.
    * Modified cmdlet Update-QSDataSource: added parameters DataSourceParameters_AthenaParameters_ConsumerAccountRoleArn and DataSourceParameters_S3TablesParameters_TableBucketArn.

### 5.0.196 (2026-04-16 20:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.232.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Modified cmdlet Update-APSStack: added parameters ContentRedirection_HostToClient_AllowedUrl, ContentRedirection_HostToClient_DeniedUrl and ContentRedirection_HostToClient_Enabled.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter AvailabilityZoneId.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter AvailabilityZoneId.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Get-BACMemoryRecordList: added parameter NamespacePath.
    * Modified cmdlet Invoke-BACMemoryRecord: added parameter NamespacePath.
  * Amazon Cognito Identity Provider
    * Modified cmdlet Set-CGIPUserMFAPreference: added parameter WebAuthnMfaSettings_Enabled.
    * Modified cmdlet Set-CGIPUserMFAPreferenceAdmin: added parameter WebAuthnMfaSettings_Enabled.
    * Modified cmdlet Set-CGIPUserPoolMfaConfig: added parameter WebAuthnConfiguration_FactorConfiguration.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFRecommenderSchema leveraging the GetRecommenderSchema service API.
    * Added cmdlet Get-CPFRecommenderSchemaList leveraging the ListRecommenderSchemas service API.
    * Added cmdlet New-CPFRecommenderSchema leveraging the CreateRecommenderSchema service API.
    * Added cmdlet Remove-CPFRecommenderSchema leveraging the DeleteRecommenderSchema service API.
    * Modified cmdlet New-CPFRecommender: added parameters RecommenderConfig_IncludedColumn and RecommenderSchemaName.
    * Modified cmdlet New-CPFRecommenderFilter: added parameter RecommenderSchemaName.
    * Modified cmdlet Update-CPFRecommender: added parameter RecommenderConfig_IncludedColumn.
  * Amazon DataZone
    * Modified cmdlet Get-DZProjectList: added parameter ProjectCategory.
    * Modified cmdlet Get-DZUserProfile: added parameter SessionName.
    * Modified cmdlet New-DZGroupProfile: added parameter RolePrincipalArn.
    * Modified cmdlet New-DZProject: added parameters MembershipAssignment, ProjectCategory and ProjectExecutionRole.
    * Modified cmdlet New-DZUserProfile: added parameter SessionName.
    * Modified cmdlet Update-DZUserProfile: added parameter SessionName.
  * DOPS
    * [Breaking Change] Removed cmdlet Enable-DOPSVendedLogDeliveryForResource.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCQueue: added parameter MaximumConcurrentFeed.
    * Modified cmdlet Update-EMCQueue: added parameter MaximumConcurrentFeed.
  * Amazon Relational Database Service
    * Added cmdlet Get-RDSServerlessV2PlatformVersion leveraging the DescribeServerlessV2PlatformVersions service API.

### 5.0.195 (2026-04-13 19:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.231.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Added cmdlet Get-ADCMonitorSetting leveraging the GetMonitorSettings service API.
    * Added cmdlet Update-ADCMonitorSetting leveraging the UpdateMonitorSettings service API.
  * Amazon Connect Customer Profiles
    * Modified cmdlet New-CPFSegmentDefinition: added parameter SegmentSort_Attribute.
  * Amazon Interconnect. Added cmdlets to support the service. Cmdlets for the service have the noun prefix INTC and can be listed using the command 'Get-AWSCmdletName -Service INTC'.
  * Amazon Macie 2
    * Modified cmdlet Write-MAC2ClassificationExportConfiguration: added parameter Configuration_S3Destination_ExpectedBucketOwner.
  * Amazon Security Hub
    * Modified cmdlet Get-SHUBFindingStatisticsV2: added parameter Scopes_AwsOrganization.
    * Modified cmdlet Get-SHUBFindingsV2: added parameter Scopes_AwsOrganization.
    * Modified cmdlet Get-SHUBResourcesStatisticsV2: added parameter Scopes_AwsOrganization.
    * Modified cmdlet Get-SHUBResourcesV2: added parameter Scopes_AwsOrganization.

### 5.0.194 (2026-04-10 20:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.230.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Observability Admin Service
    * Modified cmdlet New-CWOADMNTelemetryRule: added parameters Rule_AllRegion and Rule_Region.
    * Modified cmdlet New-CWOADMNTelemetryRuleForOrganization: added parameters Rule_AllRegion and Rule_Region.
    * Modified cmdlet Start-CWOADMNTelemetryEvaluation: added parameters AllRegion and Regions.
    * Modified cmdlet Start-CWOADMNTelemetryEvaluationForOrganization: added parameters AllRegion and Regions.
    * Modified cmdlet Update-CWOADMNTelemetryRule: added parameters Rule_AllRegion and Rule_Region.
    * Modified cmdlet Update-CWOADMNTelemetryRuleForOrganization: added parameters Rule_AllRegion and Rule_Region.
  * Amazon DevOps Agent Service
    * Modified cmdlet Add-DOPSService: added parameters Configuration_Mcpserver_Tool, Configuration_Mcpserverdatadog and Configuration_Mcpserversplunk.
    * Modified cmdlet Update-DOPSAssociation: added parameters Configuration_Mcpserver_Tool, Configuration_Mcpserverdatadog and Configuration_Mcpserversplunk.
  * Amazon EC2 Image Builder
    * Modified cmdlet New-EC2IBImagePipeline: added parameter ImageTag.
    * Modified cmdlet Update-EC2IBImagePipeline: added parameter ImageTag.
  * Amazon RTBFabric
    * Modified cmdlet New-RTBResponderGateway: added parameters ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_HealthyThresholdCount, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_IntervalSecond, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_Path, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_Port, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_Protocol, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_StatusCodeMatcher, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_TimeoutMs and ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_UnhealthyThresholdCount.
    * Modified cmdlet Update-RTBResponderGateway: added parameters ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_HealthyThresholdCount, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_IntervalSecond, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_Path, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_Port, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_Protocol, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_StatusCodeMatcher, ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_TimeoutMs and ManagedEndpointConfiguration_AutoScalingGroups_HealthCheckConfig_UnhealthyThresholdCount.
  * Amazon SageMaker Service
    * Added cmdlet Start-SMClusterHealthCheck leveraging the StartClusterHealthCheck service API.

### 5.0.193 (2026-04-09 20:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.229.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Added cmdlet Get-BACCRegistry leveraging the GetRegistry service API.
    * Added cmdlet Get-BACCRegistryList leveraging the ListRegistries service API.
    * Added cmdlet Get-BACCRegistryRecord leveraging the GetRegistryRecord service API.
    * Added cmdlet Get-BACCRegistryRecordList leveraging the ListRegistryRecords service API.
    * Added cmdlet New-BACCRegistry leveraging the CreateRegistry service API.
    * Added cmdlet New-BACCRegistryRecord leveraging the CreateRegistryRecord service API.
    * Added cmdlet Remove-BACCRegistry leveraging the DeleteRegistry service API.
    * Added cmdlet Remove-BACCRegistryRecord leveraging the DeleteRegistryRecord service API.
    * Added cmdlet Submit-BACCRegistryRecordForApproval leveraging the SubmitRegistryRecordForApproval service API.
    * Added cmdlet Update-BACCRegistry leveraging the UpdateRegistry service API.
    * Added cmdlet Update-BACCRegistryRecord leveraging the UpdateRegistryRecord service API.
    * Added cmdlet Update-BACCRegistryRecordStatus leveraging the UpdateRegistryRecordStatus service API.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Search-BACRegistryRecord leveraging the SearchRegistryRecords service API.
  * Amazon Billing and Cost Management Dashboards
    * Added cmdlet Get-BCMDScheduledReport leveraging the GetScheduledReport service API.
    * Added cmdlet Get-BCMDScheduledReportList leveraging the ListScheduledReports service API.
    * Added cmdlet Invoke-BCMDScheduledReport leveraging the ExecuteScheduledReport service API.
    * Added cmdlet New-BCMDScheduledReport leveraging the CreateScheduledReport service API.
    * Added cmdlet Remove-BCMDScheduledReport leveraging the DeleteScheduledReport service API.
    * Added cmdlet Update-BCMDScheduledReport leveraging the UpdateScheduledReport service API.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNRouterInput: added parameters Configuration_MediaLiveChannel_MediaLiveChannelArn, Configuration_MediaLiveChannel_MediaLiveChannelOutputName, Configuration_MediaLiveChannel_MediaLivePipelineId, Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyConfiguration_Automatic, Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn, Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn and Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyType.
    * Modified cmdlet Update-EMCNRouterInput: added parameters Configuration_MediaLiveChannel_MediaLiveChannelArn, Configuration_MediaLiveChannel_MediaLiveChannelOutputName, Configuration_MediaLiveChannel_MediaLivePipelineId, Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyConfiguration_Automatic, Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn, Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn and Configuration_MediaLiveChannel_SourceTransitDecryption_EncryptionKeyType.
  * Amazon Redshift Data API Service
    * Modified cmdlet Push-RSDBatchStatement: added parameter Parameter.

### 5.0.192 (2026-04-08 22:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.228.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Disaster Recovery Service
    * Modified cmdlet New-EDRSReplicationConfigurationTemplate: added parameter InternetProtocol.
    * Modified cmdlet Update-EDRSFailbackReplicationConfiguration: added parameter InternetProtocol.
    * Modified cmdlet Update-EDRSReplicationConfiguration: added parameter InternetProtocol.
    * Modified cmdlet Update-EDRSReplicationConfigurationTemplate: added parameter InternetProtocol.
  * Amazon Elemental MediaLive
    * Modified cmdlet Update-EMLChannel: added parameter SpecialRouterSettings_RouterArn.
  * Amazon Interactive Video Service RealTime
    * Modified cmdlet New-IVSRTIngestConfiguration: added parameter RedundantIngest.
    * Modified cmdlet Update-IVSRTIngestConfiguration: added parameter RedundantIngest.
  * Amazon Marketplace Discovery. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MKTD and can be listed using the command 'Get-AWSCmdletName -Service MKTD'.
  * Amazon Outposts
    * Added cmdlet Get-OUTPRenewalPricing leveraging the GetRenewalPricing service API.
    * Added cmdlet New-OUTPRenewal leveraging the CreateRenewal service API.

### 5.0.191 (2026-04-07 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.227.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Invoke-BACBrowser leveraging the InvokeBrowser service API.
  * Amazon DataZone
    * Modified cmdlet New-DZConnection: added parameters Configuration, Props_S3Properties_RegisterS3AccessGrantLocation and SparkGlueProperties_GlueConnectionNames.
    * Modified cmdlet Update-DZConnection: added parameters Configuration and Props_S3Properties_RegisterS3AccessGrantLocation.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2CapacityManagerMonitoredTagKey leveraging the GetCapacityManagerMonitoredTagKeys service API.
    * Added cmdlet Update-EC2CapacityManagerMonitoredTagKey leveraging the UpdateCapacityManagerMonitoredTagKeys service API.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSNodegroup: added parameters WarmPoolConfig_Enabled, WarmPoolConfig_MaxGroupPreparedCapacity, WarmPoolConfig_MinSize, WarmPoolConfig_PoolState and WarmPoolConfig_ReuseOnScaleIn.
    * Modified cmdlet Update-EKSNodegroupConfig: added parameters WarmPoolConfig_Enabled, WarmPoolConfig_MaxGroupPreparedCapacity, WarmPoolConfig_MinSize, WarmPoolConfig_PoolState and WarmPoolConfig_ReuseOnScaleIn.
  * IAMAA
    * [Breaking Change] Removed cmdlets Get-IAMAAPolicyPreviewConfiguration, Get-IAMAAPolicyPreviewJob, Get-IAMAAPolicyPreviewJobList, New-IAMAAPolicyPreviewConfiguration, Remove-IAMAAPolicyPreviewConfiguration, Start-IAMAAPolicyPreviewJob and Stop-IAMAAPolicyPreviewJob.
  * Amazon Outposts
    * Modified cmdlet Get-OUTPAssetList: added parameter AssetTypeFilter.
  * Amazon RTBFabric
    * Modified cmdlet Approve-RTBLink: added parameter TimeoutInMilli.
    * Modified cmdlet New-RTBLink: added parameter TimeoutInMilli.
    * Modified cmdlet New-RTBResponderGateway: added parameters GatewayType and ListenerConfig_Protocol.
    * Modified cmdlet Update-RTBLink: added parameter TimeoutInMilli.
    * Modified cmdlet Update-RTBResponderGateway: added parameter ListenerConfig_Protocol.
  * Amazon S3 Files. Added cmdlets to support the service. Cmdlets for the service have the noun prefix S3F and can be listed using the command 'Get-AWSCmdletName -Service S3F'.

### 5.0.190 (2026-04-06 20:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.226.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Added cmdlet Get-ADCJobBatch leveraging the BatchGetJob service API.
    * Added cmdlet Get-ADCSessionActionBatch leveraging the BatchGetSessionAction service API.
    * Added cmdlet Get-ADCSessionBatch leveraging the BatchGetSession service API.
    * Added cmdlet Get-ADCStepBatch leveraging the BatchGetStep service API.
    * Added cmdlet Get-ADCTaskBatch leveraging the BatchGetTask service API.
    * Added cmdlet Get-ADCWorkerBatch leveraging the BatchGetWorker service API.
    * Added cmdlet Update-ADCJobBatch leveraging the BatchUpdateJob service API.
    * Added cmdlet Update-ADCTaskBatch leveraging the BatchUpdateTask service API.
    * Modified cmdlet New-ADCMonitor: added parameter IdentityCenterRegion.
  * Amazon Elemental MediaTailor
    * Modified cmdlet New-EMTPrefetchSchedule: added parameter Tag.
    * Modified cmdlet New-EMTProgram: added parameter Tag.
  * Amazon IAM Access Analyzer
    * Added cmdlet Get-IAMAAPolicyPreviewConfiguration leveraging the GetPolicyPreviewConfiguration service API.
    * Added cmdlet Get-IAMAAPolicyPreviewJob leveraging the GetPolicyPreviewJob service API.
    * Added cmdlet Get-IAMAAPolicyPreviewJobList leveraging the ListPolicyPreviewJobs service API.
    * Added cmdlet New-IAMAAPolicyPreviewConfiguration leveraging the CreatePolicyPreviewConfiguration service API.
    * Added cmdlet Remove-IAMAAPolicyPreviewConfiguration leveraging the DeletePolicyPreviewConfiguration service API.
    * Added cmdlet Start-IAMAAPolicyPreviewJob leveraging the StartPolicyPreviewJob service API.
    * Added cmdlet Stop-IAMAAPolicyPreviewJob leveraging the CancelPolicyPreviewJob service API.
  * Amazon Q Connect
    * Modified cmdlet Send-QCMessage: added parameter OriginRequestId.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameter IpAddressType.
    * Modified cmdlet Update-TFRConnector: added parameter IpAddressType.

### 5.0.189 (2026-04-03 20:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.225.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-BDRResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-BDRResourcePolicy leveraging the PutResourcePolicy service API.
    * [Breaking Change] Modified cmdlet Write-BDREnforcedGuardrailConfiguration: removed parameter GuardrailInferenceConfig_InputTag; added parameters GuardrailInferenceConfig_SelectiveContentGuarding_Message and GuardrailInferenceConfig_SelectiveContentGuarding_System.
  * Amazon Lightsail
    * Modified cmdlet Add-LSAlarm: added parameter Tag.
  * Amazon Payment Cryptography Control Plane
    * Modified cmdlet Get-PAYCCParametersForExport: added parameter ReuseLastGeneratedToken.
    * Modified cmdlet Get-PAYCCParametersForImport: added parameter ReuseLastGeneratedToken.

### 5.0.188 (2026-04-02 20:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.224.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Added cmdlet Disable-APSSessionInstance leveraging the DrainSessionInstance service API.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCQueue: added parameters SchedulingConfiguration_PriorityBalanced_RenderingTaskBuffer, SchedulingConfiguration_PriorityFifo, SchedulingConfiguration_WeightedBalanced_ErrorWeight, SchedulingConfiguration_WeightedBalanced_MaxPriorityOverride_AlwaysScheduleFirst, SchedulingConfiguration_WeightedBalanced_MinPriorityOverride_AlwaysScheduleLast, SchedulingConfiguration_WeightedBalanced_PriorityWeight, SchedulingConfiguration_WeightedBalanced_RenderingTaskBuffer, SchedulingConfiguration_WeightedBalanced_RenderingTaskWeight and SchedulingConfiguration_WeightedBalanced_SubmissionTimeWeight.
    * Modified cmdlet Update-ADCQueue: added parameters SchedulingConfiguration_PriorityBalanced_RenderingTaskBuffer, SchedulingConfiguration_PriorityFifo, SchedulingConfiguration_WeightedBalanced_ErrorWeight, SchedulingConfiguration_WeightedBalanced_MaxPriorityOverride_AlwaysScheduleFirst, SchedulingConfiguration_WeightedBalanced_MinPriorityOverride_AlwaysScheduleLast, SchedulingConfiguration_WeightedBalanced_PriorityWeight, SchedulingConfiguration_WeightedBalanced_RenderingTaskBuffer, SchedulingConfiguration_WeightedBalanced_RenderingTaskWeight and SchedulingConfiguration_WeightedBalanced_SubmissionTimeWeight.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCGatewayTarget: added parameters TargetConfiguration_Mcp_McpServer_McpToolSchema_InlinePayload, TargetConfiguration_Mcp_McpServer_McpToolSchema_S3_BucketOwnerAccountId and TargetConfiguration_Mcp_McpServer_McpToolSchema_S3_Uri.
    * Modified cmdlet Update-BACCGatewayTarget: added parameters TargetConfiguration_Mcp_McpServer_McpToolSchema_InlinePayload, TargetConfiguration_Mcp_McpServer_McpToolSchema_S3_BucketOwnerAccountId and TargetConfiguration_Mcp_McpServer_McpToolSchema_S3_Uri.
  * Amazon CloudWatch
    * Added cmdlet Get-CWOTelEnrichment leveraging the GetOTelEnrichment service API.
    * Added cmdlet Start-CWOTelEnrichment leveraging the StartOTelEnrichment service API.
    * Added cmdlet Stop-CWOTelEnrichment leveraging the StopOTelEnrichment service API.
    * Modified cmdlet Write-CWMetricAlarm: added parameters EvaluationCriteria_PromQLCriteria_PendingPeriod, EvaluationCriteria_PromQLCriteria_Query, EvaluationCriteria_PromQLCriteria_RecoveryPeriod and EvaluationInterval.
  * Amazon Data Automation for Amazon Bedrock
    * Added cmdlet Get-BDADataAutomationLibrary leveraging the GetDataAutomationLibrary service API.
    * Added cmdlet Get-BDADataAutomationLibraryEntity leveraging the GetDataAutomationLibraryEntity service API.
    * Added cmdlet Get-BDADataAutomationLibraryEntityList leveraging the ListDataAutomationLibraryEntities service API.
    * Added cmdlet Get-BDADataAutomationLibraryIngestionJob leveraging the GetDataAutomationLibraryIngestionJob service API.
    * Added cmdlet Get-BDADataAutomationLibraryIngestionJobList leveraging the ListDataAutomationLibraryIngestionJobs service API.
    * Added cmdlet Get-BDADataAutomationLibraryList leveraging the ListDataAutomationLibraries service API.
    * Added cmdlet Invoke-BDADataAutomationLibraryIngestionJob leveraging the InvokeDataAutomationLibraryIngestionJob service API.
    * Added cmdlet New-BDADataAutomationLibrary leveraging the CreateDataAutomationLibrary service API.
    * Added cmdlet Remove-BDADataAutomationLibrary leveraging the DeleteDataAutomationLibrary service API.
    * Added cmdlet Update-BDADataAutomationLibrary leveraging the UpdateDataAutomationLibrary service API.
    * Modified cmdlet Get-BDADataAutomationProjectList: added parameter LibraryFilter_LibraryArn.
    * Modified cmdlet New-BDADataAutomationProject: added parameter DataAutomationLibraryConfiguration_Library.
    * Modified cmdlet Update-BDADataAutomationProject: added parameter DataAutomationLibraryConfiguration_Library.

### 5.0.187 (2026-04-01 20:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.223.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCGatewayTarget: added parameters PrivateEndpoint_ManagedLatticeResource_EndpointIpAddressType, PrivateEndpoint_ManagedLatticeResource_RoutingDomain, PrivateEndpoint_ManagedLatticeResource_SecurityGroupId, PrivateEndpoint_ManagedLatticeResource_SubnetId, PrivateEndpoint_ManagedLatticeResource_Tag, PrivateEndpoint_ManagedLatticeResource_VpcIdentifier and PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier.
    * Modified cmdlet Update-BACCGatewayTarget: added parameters PrivateEndpoint_ManagedLatticeResource_EndpointIpAddressType, PrivateEndpoint_ManagedLatticeResource_RoutingDomain, PrivateEndpoint_ManagedLatticeResource_SecurityGroupId, PrivateEndpoint_ManagedLatticeResource_SubnetId, PrivateEndpoint_ManagedLatticeResource_Tag, PrivateEndpoint_ManagedLatticeResource_VpcIdentifier and PrivateEndpoint_SelfManagedLatticeResource_ResourceConfigurationIdentifier.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Get-BACSessionList: added parameter Filter_EventFilter.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSDaemonDeploymentDetail leveraging the DescribeDaemonDeployments service API.
    * Added cmdlet Get-ECSDaemonDeploymentList leveraging the ListDaemonDeployments service API.
    * Added cmdlet Get-ECSDaemonDetail leveraging the DescribeDaemon service API.
    * Added cmdlet Get-ECSDaemonList leveraging the ListDaemons service API.
    * Added cmdlet Get-ECSDaemonRevisionDetail leveraging the DescribeDaemonRevisions service API.
    * Added cmdlet Get-ECSDaemonTaskDefinitionDetail leveraging the DescribeDaemonTaskDefinition service API.
    * Added cmdlet Get-ECSDaemonTaskDefinitionList leveraging the ListDaemonTaskDefinitions service API.
    * Added cmdlet New-ECSDaemon leveraging the CreateDaemon service API.
    * Added cmdlet Register-ECSDaemonTaskDefinition leveraging the RegisterDaemonTaskDefinition service API.
    * Added cmdlet Remove-ECSDaemon leveraging the DeleteDaemon service API.
    * Added cmdlet Remove-ECSDaemonTaskDefinition leveraging the DeleteDaemonTaskDefinition service API.
    * Added cmdlet Update-ECSDaemon leveraging the UpdateDaemon service API.
    * Modified cmdlet Get-ECSTaskList: added parameter DaemonName.
  * Amazon ElastiCache
    * Modified cmdlet New-ECServerlessCache: added parameter NetworkType.
  * Amazon Medical Imaging Service
    * Modified cmdlet Update-MISImageSetMetadata: added parameter IncludeStudyImageSet.

### 5.0.186 (2026-03-31 20:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.222.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Certificate Manager
    * Added cmdlet Search-ACMCertificate leveraging the SearchCertificates service API.
  * Amazon CloudFront
    * Modified cmdlet Update-CFAnycastIpList: added parameter IpamCidrConfig.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXJob: added parameter AssetConfiguration_Tag.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSDataProvider: added parameters Settings_IbmDb2LuwSettings_EncryptionAlgorithm and Settings_IbmDb2LuwSettings_SecurityMechanism.
    * Modified cmdlet New-DMSDataProvider: added parameters Settings_IbmDb2LuwSettings_EncryptionAlgorithm and Settings_IbmDb2LuwSettings_SecurityMechanism.
  * Amazon DataZone
    * Modified cmdlet New-DZEnvironment: added parameter EnvironmentConfigurationName.
    * Modified cmdlet Update-DZEnvironment: added parameter EnvironmentConfigurationName.
  * DOPS
    * [Breaking Change] Removed cmdlets Close-DOPSChatForCase, Get-DOPSSupportLevelDetail and Start-DOPSChatForCase.
    * [Breaking Change] Modified cmdlet Add-DOPSService: removed parameters Configuration_Msteams_TeamId, Configuration_Msteams_TeamName, Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId, Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName, Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId and Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName.
    * [Breaking Change] Modified cmdlet Register-DOPSService: removed parameters ServiceDetails_Mcpserversigv4_AuthorizationConfig_Region, ServiceDetails_Mcpserversigv4_AuthorizationConfig_RoleArn, ServiceDetails_Mcpserversigv4_AuthorizationConfig_Service, ServiceDetails_Mcpserversigv4_Description, ServiceDetails_Mcpserversigv4_Endpoint and ServiceDetails_Mcpserversigv4_Name.
    * [Breaking Change] Modified cmdlet Update-DOPSAssociation: removed parameters Configuration_Msteams_TeamId, Configuration_Msteams_TeamName, Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelId, Configuration_Msteams_TransmissionTarget_OpsOncallTarget_ChannelName, Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelId and Configuration_Msteams_TransmissionTarget_OpsSRETarget_ChannelName.
  * Amazon Marketplace Agreement Service
    * Added cmdlet Get-MASAgreementCancellationRequest leveraging the GetAgreementCancellationRequest service API.
    * Added cmdlet Get-MASAgreementCancellationRequestList leveraging the ListAgreementCancellationRequests service API.
    * Added cmdlet Get-MASAgreementInvoiceLineItemList leveraging the ListAgreementInvoiceLineItems service API.
    * Added cmdlet Get-MASBillingAdjustmentRequest leveraging the GetBillingAdjustmentRequest service API.
    * Added cmdlet Get-MASBillingAdjustmentRequestList leveraging the ListBillingAdjustmentRequests service API.
    * Added cmdlet New-MASBillingAdjustmentRequestBatch leveraging the BatchCreateBillingAdjustmentRequest service API.
    * Added cmdlet Send-MASAgreementCancellationRequest leveraging the SendAgreementCancellationRequest service API.
    * Added cmdlet Stop-MASAgreementCancellationRequest leveraging the CancelAgreementCancellationRequest service API.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSCapability leveraging the GetCapability service API.
    * Added cmdlet Register-OSCapability leveraging the RegisterCapability service API.
    * Added cmdlet Unregister-OSCapability leveraging the DeregisterCapability service API.
  * Amazon Pinpoint SMS Voice V2
    * Added cmdlet Get-SMSVNotifyConfiguration leveraging the DescribeNotifyConfigurations service API.
    * Added cmdlet Get-SMSVNotifyCountryList leveraging the ListNotifyCountries service API.
    * Added cmdlet Get-SMSVNotifyTemplate leveraging the DescribeNotifyTemplates service API.
    * Added cmdlet Get-SMSVRcsAgent leveraging the DescribeRcsAgents service API.
    * Added cmdlet Get-SMSVRcsAgentCountryLaunchStatus leveraging the DescribeRcsAgentCountryLaunchStatus service API.
    * Added cmdlet New-SMSVNotifyConfiguration leveraging the CreateNotifyConfiguration service API.
    * Added cmdlet New-SMSVRcsAgent leveraging the CreateRcsAgent service API.
    * Added cmdlet Remove-SMSVNotifyConfiguration leveraging the DeleteNotifyConfiguration service API.
    * Added cmdlet Remove-SMSVNotifyMessageSpendLimitOverride leveraging the DeleteNotifyMessageSpendLimitOverride service API.
    * Added cmdlet Remove-SMSVRcsAgent leveraging the DeleteRcsAgent service API.
    * Added cmdlet Send-SMSVNotifyTextMessage leveraging the SendNotifyTextMessage service API.
    * Added cmdlet Send-SMSVNotifyVoiceMessage leveraging the SendNotifyVoiceMessage service API.
    * Added cmdlet Set-SMSVNotifyMessageSpendLimitOverride leveraging the SetNotifyMessageSpendLimitOverride service API.
    * Added cmdlet Update-SMSVNotifyConfiguration leveraging the UpdateNotifyConfiguration service API.
    * Added cmdlet Update-SMSVRcsAgent leveraging the UpdateRcsAgent service API.
    * Modified cmdlet New-SMSVVerifiedDestinationNumber: added parameter RcsAgentId.
  * Amazon QuickSight
    * Added cmdlet Get-QSAutomationJobDetail leveraging the DescribeAutomationJob service API.
    * Added cmdlet Start-QSAutomationJob leveraging the StartAutomationJob service API.
    * Modified cmdlet New-QSAnalysis: added parameter Definition_TooltipSheet.
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_CreateSpace, Capabilities_ShareChatAgent and Capabilities_ShareSpace.
    * Modified cmdlet New-QSDashboard: added parameter Definition_TooltipSheet.
    * Modified cmdlet New-QSDataSource: added parameters Credentials_OAuthClientCredentials_ClientId, Credentials_OAuthClientCredentials_ClientSecret and Credentials_OAuthClientCredentials_Username.
    * Modified cmdlet New-QSTemplate: added parameter Definition_TooltipSheet.
    * Modified cmdlet Update-QSAnalysis: added parameter Definition_TooltipSheet.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_CreateSpace, Capabilities_ShareChatAgent and Capabilities_ShareSpace.
    * Modified cmdlet Update-QSDashboard: added parameter Definition_TooltipSheet.
    * Modified cmdlet Update-QSDataSource: added parameters Credentials_OAuthClientCredentials_ClientId, Credentials_OAuthClientCredentials_ClientSecret and Credentials_OAuthClientCredentials_Username.
    * Modified cmdlet Update-QSTemplate: added parameter Definition_TooltipSheet.
  * Amazon S3 Control
    * Modified cmdlet Get-S3CDataAccess: added parameter AuditContext.
  * Amazon S3 Tables
    * Modified cmdlet New-S3TTable: added parameters Metadata_Iceberg_SchemaV2_Field, Metadata_Iceberg_SchemaV2_IdentifierFieldId, Metadata_Iceberg_SchemaV2_SchemaId and Metadata_Iceberg_SchemaV2_Type.
  * Amazon Security Agent. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SECAG and can be listed using the command 'Get-AWSCmdletName -Service SECAG'.
  * Amazon SES Mail Manager
    * Modified cmdlet Get-MMGRIngressPoint: added parameter IncludeTrustStoreContent.
    * Modified cmdlet New-MMGRIngressPoint: added parameters IngressPointConfiguration_TlsAuthConfiguration_TrustStore_CAContent, IngressPointConfiguration_TlsAuthConfiguration_TrustStore_CrlContent, IngressPointConfiguration_TlsAuthConfiguration_TrustStore_KmsKeyArn and TlsPolicy.
    * Modified cmdlet Update-MMGRIngressPoint: added parameters IngressPointConfiguration_TlsAuthConfiguration_TrustStore_CAContent, IngressPointConfiguration_TlsAuthConfiguration_TrustStore_CrlContent, IngressPointConfiguration_TlsAuthConfiguration_TrustStore_KmsKeyArn and TlsPolicy.
  * Amazon Sustainability. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SUST and can be listed using the command 'Get-AWSCmdletName -Service SUST'.

### 5.0.185 (2026-03-30 20:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.221.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Modified cmdlet New-APSStack: added parameters ContentRedirection_HostToClient_AllowedUrl, ContentRedirection_HostToClient_DeniedUrl and ContentRedirection_HostToClient_Enabled.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameters Configuration_CustomerManaged_AutoScalingConfiguration_ScaleOutWorkersPerMinute, Configuration_CustomerManaged_AutoScalingConfiguration_StandbyWorkerCount, Configuration_CustomerManaged_AutoScalingConfiguration_WorkerIdleDurationSecond, Configuration_ServiceManagedEc2_AutoScalingConfiguration_ScaleOutWorkersPerMinute, Configuration_ServiceManagedEc2_AutoScalingConfiguration_StandbyWorkerCount and Configuration_ServiceManagedEc2_AutoScalingConfiguration_WorkerIdleDurationSecond.
    * Modified cmdlet Update-ADCFleet: added parameters Configuration_CustomerManaged_AutoScalingConfiguration_ScaleOutWorkersPerMinute, Configuration_CustomerManaged_AutoScalingConfiguration_StandbyWorkerCount, Configuration_CustomerManaged_AutoScalingConfiguration_WorkerIdleDurationSecond, Configuration_ServiceManagedEc2_AutoScalingConfiguration_ScaleOutWorkersPerMinute, Configuration_ServiceManagedEc2_AutoScalingConfiguration_StandbyWorkerCount and Configuration_ServiceManagedEc2_AutoScalingConfiguration_WorkerIdleDurationSecond.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Invoke-BACEvaluate: added parameter EvaluationReferenceInput.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLLookupTable leveraging the GetLookupTable service API.
    * Added cmdlet Get-CWLLookupTableDetail leveraging the DescribeLookupTables service API.
    * Added cmdlet New-CWLLookupTable leveraging the CreateLookupTable service API.
    * Added cmdlet Remove-CWLLookupTable leveraging the DeleteLookupTable service API.
    * Added cmdlet Update-CWLLookupTable leveraging the UpdateLookupTable service API.
  * Amazon DevOps Agent Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DOPS and can be listed using the command 'Get-AWSCmdletName -Service DOPS'.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCapacityProvider: added parameter ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage.
    * Modified cmdlet Update-ECSCapacityProvider: added parameter ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSInsightDetailDetail leveraging the DescribeInsightDetails service API.
    * Added cmdlet Get-OSInsightList leveraging the ListInsights service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceComponent: added parameters Specification_SchedulingConfig_AvailabilityZoneBalance_EnforcementMode, Specification_SchedulingConfig_AvailabilityZoneBalance_MaxImbalance and Specification_SchedulingConfig_PlacementStrategy.
    * Modified cmdlet Update-SMInferenceComponent: added parameters Specification_SchedulingConfig_AvailabilityZoneBalance_EnforcementMode, Specification_SchedulingConfig_AvailabilityZoneBalance_MaxImbalance and Specification_SchedulingConfig_PlacementStrategy.

### 5.0.184 (2026-03-27 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.220.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCEvaluator: added parameters EvaluatorConfig_CodeBased_LambdaConfig_LambdaArn and EvaluatorConfig_CodeBased_LambdaConfig_LambdaTimeoutInSecond.
    * Modified cmdlet Update-BACCEvaluator: added parameters EvaluatorConfig_CodeBased_LambdaConfig_LambdaArn and EvaluatorConfig_CodeBased_LambdaConfig_LambdaTimeoutInSecond.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Invoke-BACCodeInterpreter: added parameter Arguments_Runtime.
  * Amazon Omics
    * Added cmdlet Get-OMICSConfiguration leveraging the GetConfiguration service API.
    * Added cmdlet Get-OMICSConfigurationList leveraging the ListConfigurations service API.
    * Added cmdlet New-OMICSConfiguration leveraging the CreateConfiguration service API.
    * Added cmdlet Remove-OMICSConfiguration leveraging the DeleteConfiguration service API.
    * Modified cmdlet Start-OMICSRun: added parameters ConfigurationName and NetworkingMode.

### 5.0.183 (2026-03-26 20:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.219.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSBillingAndCostManagementDataExports
    * Modified cmdlet New-BCMDEExport: added parameter Export_DestinationConfigurations_S3Destination_S3BucketOwner.
    * Modified cmdlet Update-BCMDEExport: added parameter Export_DestinationConfigurations_S3Destination_S3BucketOwner.
  * Amazon CloudWatch Logs
    * Modified cmdlet New-CWLScheduledQuery: added parameters DestinationConfiguration_S3Configuration_KmsKeyId and DestinationConfiguration_S3Configuration_OwnerAccountId.
    * Modified cmdlet Update-CWLScheduledQuery: added parameters DestinationConfiguration_S3Configuration_KmsKeyId and DestinationConfiguration_S3Configuration_OwnerAccountId.
    * Modified cmdlet Write-CWLQueryDefinition: added parameter Parameter.
  * Amazon Elastic MapReduce
    * Modified cmdlet Start-EMRJobFlow: added parameter StepExecutionRoleArn.
  * Amazon Timestream InfluxDB
    * Modified cmdlet New-TIDBDbCluster: added parameters MaintenanceSchedule_PreferredMaintenanceWindow and MaintenanceSchedule_Timezone.
    * Modified cmdlet New-TIDBDbInstance: added parameters MaintenanceSchedule_PreferredMaintenanceWindow and MaintenanceSchedule_Timezone.
    * Modified cmdlet Update-TIDBDbCluster: added parameters MaintenanceSchedule_PreferredMaintenanceWindow and MaintenanceSchedule_Timezone.
    * Modified cmdlet Update-TIDBDbInstance: added parameters MaintenanceSchedule_PreferredMaintenanceWindow and MaintenanceSchedule_Timezone.

### 5.0.182 (2026-03-25 20:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.218.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSAccountUXSetting. Added cmdlets to support the service. Cmdlets for the service have the noun prefix UXC and can be listed using the command 'Get-AWSCmdletName -Service UXC'.
  * Amazon CloudWatch Application Signals
    * Modified cmdlet Get-CWASServiceLevelObjectiveList: added parameters MetricSource_MetricSourceAttribute and MetricSource_MetricSourceKeyAttribute.
    * Modified cmdlet New-CWASServiceLevelObjective: added parameters RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricName, RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricSource_MetricSourceAttribute, RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricSource_MetricSourceKeyAttribute, SliConfig_SliMetricConfig_MetricSource_MetricSourceAttribute and SliConfig_SliMetricConfig_MetricSource_MetricSourceKeyAttribute.
    * Modified cmdlet Update-CWASServiceLevelObjective: added parameters RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricName, RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricSource_MetricSourceAttribute, RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricSource_MetricSourceKeyAttribute, SliConfig_SliMetricConfig_MetricSource_MetricSourceAttribute and SliConfig_SliMetricConfig_MetricSource_MetricSourceKeyAttribute.
  * Amazon Marketplace Agreement Service
    * Added cmdlet Get-MASAgreementPaymentRequest leveraging the GetAgreementPaymentRequest service API.
    * Added cmdlet Get-MASAgreementPaymentRequestList leveraging the ListAgreementPaymentRequests service API.
    * Added cmdlet Send-MASAgreementPaymentRequest leveraging the SendAgreementPaymentRequest service API.
    * Added cmdlet Stop-MASAgreementPaymentRequest leveraging the CancelAgreementPaymentRequest service API.

### 5.0.181 (2026-03-24 19:52Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.217.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet Get-BACCBrowserProfileList: added parameter Name.
    * Modified cmdlet New-BACCAgentRuntime: added parameter FilesystemConfiguration.
    * Modified cmdlet Update-BACCAgentRuntime: added parameter FilesystemConfiguration.
  * Amazon OpenSearch Serverless
    * Modified cmdlet Update-OSSCollection: added parameter VectorOptions_ServerlessVectorAcceleration.
  * Amazon Parallel Computing Service
    * Modified cmdlet New-PCSCluster: added parameters SlurmConfiguration_CgroupCustomSetting and SlurmConfiguration_SlurmdbdCustomSetting.
    * Modified cmdlet Update-PCSCluster: added parameters SlurmConfiguration_CgroupCustomSetting and SlurmConfiguration_SlurmdbdCustomSetting.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBCluster: added parameter WithExpressConfiguration.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameters EnableInternetAccessGateway and EnableVPCNetworking.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameters EnableInternetAccessGateway and EnableVPCNetworking.

### 5.0.180 (2026-03-23 20:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.216.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Added cmdlet Update-CCASRelatedItem leveraging the UpdateRelatedItem service API.
  * Amazon Lightsail
    * Modified cmdlet New-LSContactMethod: added parameter Tag.
  * Amazon Omics
    * Added cmdlet Get-OMICSBatch leveraging the GetBatch service API.
    * Added cmdlet Get-OMICSBatchList leveraging the ListBatch service API.
    * Added cmdlet Get-OMICSRunsInBatchList leveraging the ListRunsInBatch service API.
    * Added cmdlet Remove-OMICSBatch leveraging the DeleteBatch service API.
    * Added cmdlet Remove-OMICSRunBatch leveraging the DeleteRunBatch service API.
    * Added cmdlet Start-OMICSRunBatch leveraging the StartRunBatch service API.
    * Added cmdlet Stop-OMICSRunBatch leveraging the CancelRunBatch service API.
    * Modified cmdlet Get-OMICSRunList: added parameter BatchId.

### 5.0.179 (2026-03-20 20:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.215.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon OpenSearch Service
    * Modified cmdlet Add-OSDirectQueryDataSource: added parameters DataSourceType_Prometheus_RoleArn and DataSourceType_Prometheus_WorkspaceArn.
    * Modified cmdlet Update-OSDirectQueryDataSource: added parameters DataSourceType_Prometheus_RoleArn and DataSourceType_Prometheus_WorkspaceArn.
  * Amazon Verified Permissions
    * Added cmdlet Get-AVPPolicyStoreAlias leveraging the GetPolicyStoreAlias service API.
    * Added cmdlet Get-AVPPolicyStoreAliasList leveraging the ListPolicyStoreAliases service API.
    * Added cmdlet New-AVPPolicyStoreAlias leveraging the CreatePolicyStoreAlias service API.
    * Added cmdlet Remove-AVPPolicyStoreAlias leveraging the DeletePolicyStoreAlias service API.
    * Modified cmdlet New-AVPPolicy: added parameter Name.
    * Modified cmdlet New-AVPPolicyTemplate: added parameter Name.
    * Modified cmdlet Update-AVPPolicy: added parameter Name.
    * Modified cmdlet Update-AVPPolicyTemplate: added parameter Name.

### 5.0.178 (2026-03-19 22:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.214.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Added cmdlet Get-BATQuotaShareDetail leveraging the DescribeQuotaShare service API.
    * Added cmdlet Get-BATQuotaShareList leveraging the ListQuotaShares service API.
    * Added cmdlet New-BATQuotaShare leveraging the CreateQuotaShare service API.
    * Added cmdlet Remove-BATQuotaShare leveraging the DeleteQuotaShare service API.
    * Added cmdlet Update-BATQuotaShare leveraging the UpdateQuotaShare service API.
    * Added cmdlet Update-BATServiceJob leveraging the UpdateServiceJob service API.
    * Modified cmdlet New-BATSchedulingPolicy: added parameter QuotaSharePolicy_IdleResourceAssignmentStrategy.
    * Modified cmdlet Submit-BATServiceJob: added parameters PreemptionConfiguration_PreemptionRetriesBeforeTermination and QuotaShareName.
    * Modified cmdlet Update-BATSchedulingPolicy: added parameter QuotaSharePolicy_IdleResourceAssignmentStrategy.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCBrowser: added parameters Certificate and EnterprisePolicy.
    * Modified cmdlet New-BACCCodeInterpreter: added parameter Certificate.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Start-BACBrowserSession: added parameters Certificate and EnterprisePolicy.
    * Modified cmdlet Start-BACCodeInterpreterSession: added parameter Certificate.
  * Amazon CloudWatch Observability Admin Service
    * Modified cmdlet New-CWOADMNCentralizationRuleForOrganization: added parameter Rule_Source_SourceLogsConfiguration_DataSourceSelectionCriterion.
    * Modified cmdlet Update-CWOADMNCentralizationRuleForOrganization: added parameter Rule_Source_SourceLogsConfiguration_DataSourceSelectionCriterion.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2Fleet: added parameter ReservedCapacityOptions_ReservationType.

### 5.0.177 (2026-03-18 23:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.213.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.176 (2026-03-17 20:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.212.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic MapReduce
    * Modified cmdlet Start-EMRJobFlow: added parameter MonitoringConfiguration_S3LoggingConfiguration_LogTypeUploadPolicy.
  * Amazon Glue
    * Modified cmdlet New-GLUECatalog: added parameter CatalogInput_OverwriteChildResourcePermissionsWithDefault.
    * Modified cmdlet Update-GLUECatalog: added parameter CatalogInput_OverwriteChildResourcePermissionsWithDefault.

### 5.0.175 (2026-03-16 23:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.211.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Invoke-BACAgentRuntimeCommand leveraging the InvokeAgentRuntimeCommand service API.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCapacityProvider: added parameter ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation.
    * Modified cmdlet Update-ECSCapacityProvider: added parameter ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation.

### 5.0.174 (2026-03-13 20:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.210.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Migration Service
    * Added cmdlet Get-MGNImportFileEnrichmentList leveraging the ListImportFileEnrichments service API.
    * Added cmdlet Get-MGNNetworkMigrationAnalysisList leveraging the ListNetworkMigrationAnalyses service API.
    * Added cmdlet Get-MGNNetworkMigrationAnalysisResultList leveraging the ListNetworkMigrationAnalysisResults service API.
    * Added cmdlet Get-MGNNetworkMigrationCodeGenerationList leveraging the ListNetworkMigrationCodeGenerations service API.
    * Added cmdlet Get-MGNNetworkMigrationCodeGenerationSegmentList leveraging the ListNetworkMigrationCodeGenerationSegments service API.
    * Added cmdlet Get-MGNNetworkMigrationDefinition leveraging the GetNetworkMigrationDefinition service API.
    * Added cmdlet Get-MGNNetworkMigrationDefinitionList leveraging the ListNetworkMigrationDefinitions service API.
    * Added cmdlet Get-MGNNetworkMigrationDeployedStackList leveraging the ListNetworkMigrationDeployedStacks service API.
    * Added cmdlet Get-MGNNetworkMigrationDeploymentList leveraging the ListNetworkMigrationDeployments service API.
    * Added cmdlet Get-MGNNetworkMigrationExecutionList leveraging the ListNetworkMigrationExecutions service API.
    * Added cmdlet Get-MGNNetworkMigrationMapperSegmentConstruct leveraging the GetNetworkMigrationMapperSegmentConstruct service API.
    * Added cmdlet Get-MGNNetworkMigrationMapperSegmentConstructList leveraging the ListNetworkMigrationMapperSegmentConstructs service API.
    * Added cmdlet Get-MGNNetworkMigrationMapperSegmentList leveraging the ListNetworkMigrationMapperSegments service API.
    * Added cmdlet Get-MGNNetworkMigrationMappingList leveraging the ListNetworkMigrationMappings service API.
    * Added cmdlet Get-MGNNetworkMigrationMappingUpdateList leveraging the ListNetworkMigrationMappingUpdates service API.
    * Added cmdlet New-MGNNetworkMigrationDefinition leveraging the CreateNetworkMigrationDefinition service API.
    * Added cmdlet Remove-MGNNetworkMigrationDefinition leveraging the DeleteNetworkMigrationDefinition service API.
    * Added cmdlet Start-MGNImportFileEnrichment leveraging the StartImportFileEnrichment service API.
    * Added cmdlet Start-MGNNetworkMigrationAnalysis leveraging the StartNetworkMigrationAnalysis service API.
    * Added cmdlet Start-MGNNetworkMigrationCodeGeneration leveraging the StartNetworkMigrationCodeGeneration service API.
    * Added cmdlet Start-MGNNetworkMigrationDeployment leveraging the StartNetworkMigrationDeployment service API.
    * Added cmdlet Start-MGNNetworkMigrationMapping leveraging the StartNetworkMigrationMapping service API.
    * Added cmdlet Start-MGNNetworkMigrationMappingUpdate leveraging the StartNetworkMigrationMappingUpdate service API.
    * Added cmdlet Update-MGNNetworkMigrationDefinition leveraging the UpdateNetworkMigrationDefinition service API.
    * Added cmdlet Update-MGNNetworkMigrationMapperSegment leveraging the UpdateNetworkMigrationMapperSegment service API.
  * Amazon Glue
    * Modified cmdlet Get-GLUEPartitionBatch: added parameters AuditContext_AdditionalAuditContext, AuditContext_AllColumnsRequested, AuditContext_RequestedColumn, QuerySessionContext_AdditionalContext, QuerySessionContext_ClusterId, QuerySessionContext_QueryAuthorizationId, QuerySessionContext_QueryId and QuerySessionContext_QueryStartTime.
  * Amazon QuickSight
    * Modified cmdlet New-QSCustomPermission: added parameter Capabilities_ManageSharedFolder.
    * Modified cmdlet Update-QSCustomPermission: added parameter Capabilities_ManageSharedFolder.

### 5.0.173 (2026-03-12 20:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.209.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationFsxOntap: added parameters Protocol_SMB_CmkSecretConfig_KmsKeyArn, Protocol_SMB_CmkSecretConfig_SecretArn, Protocol_SMB_CustomSecretConfig_SecretAccessRoleArn, Protocol_SMB_CustomSecretConfig_SecretArn and Protocol_SMB_ManagedSecretConfig_SecretArn.
    * Modified cmdlet New-DSYNLocationFsxOpenZf: added parameters Protocol_SMB_CmkSecretConfig_KmsKeyArn, Protocol_SMB_CmkSecretConfig_SecretArn, Protocol_SMB_CustomSecretConfig_SecretAccessRoleArn, Protocol_SMB_CustomSecretConfig_SecretArn and Protocol_SMB_ManagedSecretConfig_SecretArn.
    * Modified cmdlet New-DSYNLocationFsxWindow: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet New-DSYNLocationHdf: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationFsxOntap: added parameters Protocol_SMB_CmkSecretConfig_KmsKeyArn, Protocol_SMB_CmkSecretConfig_SecretArn, Protocol_SMB_CustomSecretConfig_SecretAccessRoleArn and Protocol_SMB_CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationFsxOpenZf: added parameters Protocol_SMB_CmkSecretConfig_KmsKeyArn, Protocol_SMB_CmkSecretConfig_SecretArn, Protocol_SMB_CustomSecretConfig_SecretAccessRoleArn, Protocol_SMB_CustomSecretConfig_SecretArn and Protocol_SMB_ManagedSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationFsxWindow: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationHdf: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.

### 5.0.172 (2026-03-11 21:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.208.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFRecommenderFilter leveraging the GetRecommenderFilter service API.
    * Added cmdlet Get-CPFRecommenderFilterList leveraging the ListRecommenderFilters service API.
    * Added cmdlet New-CPFRecommenderFilter leveraging the CreateRecommenderFilter service API.
    * Added cmdlet Remove-CPFRecommenderFilter leveraging the DeleteRecommenderFilter service API.
    * Modified cmdlet Get-CPFProfileRecommendation: added parameters CandidateId, MetadataConfig_MetadataColumn, RecommenderFilter and RecommenderPromotionalFilter.
    * Modified cmdlet New-CPFRecommender: added parameter RecommenderConfig_InferenceConfig_MinProvisionedTPS.
    * Modified cmdlet Update-CPFRecommender: added parameter RecommenderConfig_InferenceConfig_MinProvisionedTPS.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMTrainingPlanExtensionHistoryDetail leveraging the DescribeTrainingPlanExtensionHistory service API.
    * Added cmdlet Set-SMTrainingPlanExtension leveraging the ExtendTrainingPlan service API.
    * Modified cmdlet Search-SMTrainingPlanOffering: added parameter TrainingPlanArn.
  * Amazon SimpleDB v2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SDBV2 and can be listed using the command 'Get-AWSCmdletName -Service SDBV2'.

### 5.0.171 (2026-03-10 19:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.207.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Lex Model Building V2
    * Added cmdlet Get-LMBV2BotAnalyzerHistoryList leveraging the ListBotAnalyzerHistory service API.
    * Added cmdlet Get-LMBV2BotAnalyzerRecommendationDetail leveraging the DescribeBotAnalyzerRecommendation service API.
    * Added cmdlet Remove-LMBV2BotAnalyzerRecommendation leveraging the DeleteBotAnalyzerRecommendation service API.
    * Added cmdlet Start-LMBV2BotAnalyzer leveraging the StartBotAnalyzer service API.
    * Added cmdlet Stop-LMBV2BotAnalyzer leveraging the StopBotAnalyzer service API.

### 5.0.170 (2026-03-09 20:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.206.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Migration Service
    * Modified cmdlet New-MGNReplicationConfigurationTemplate: added parameter StoreSnapshotOnLocalZone.
    * Modified cmdlet Update-MGNReplicationConfiguration: added parameter StoreSnapshotOnLocalZone.
    * Modified cmdlet Update-MGNReplicationConfigurationTemplate: added parameter StoreSnapshotOnLocalZone.
  * Amazon OpenSearch Service
    * Modified cmdlet Add-OSDirectQueryDataSource: added parameter DataSourceAccessPolicy.
    * Modified cmdlet Update-OSDirectQueryDataSource: added parameter DataSourceAccessPolicy.
  * Amazon Route 53 Global Resolver
    * Modified cmdlet New-R53GRGlobalResolver: added parameter IpAddressType.
    * Modified cmdlet Update-R53GRGlobalResolver: added parameter IpAddressType.

### 5.0.169 (2026-03-07 00:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.205.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFarm: added parameter CostScaleFactor.
    * Modified cmdlet Update-ADCFarm: added parameter CostScaleFactor.
  * Amazon Bedrock
    * Modified cmdlet Write-BDREnforcedGuardrailConfiguration: added parameters GuardrailInferenceConfig_ModelEnforcement_ExcludedModel and GuardrailInferenceConfig_ModelEnforcement_IncludedModel.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCMemory: added parameter StreamDeliveryResources_Resource.
    * Modified cmdlet Update-BACCMemory: added parameter StreamDeliveryResources_Resource.
  * Amazon Connect Service
    * Modified cmdlet New-CONNTestCase: added parameter EntryPoint_ChatEntryPointParameters_FlowId.
    * Modified cmdlet Update-CONNTestCase: added parameter EntryPoint_ChatEntryPointParameters_FlowId.

### 5.0.168 (2026-03-06 00:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.204.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Health. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CNH and can be listed using the command 'Get-AWSCmdletName -Service CNH'.
  * Amazon Multi-party Approval
    * Added cmdlet Start-MPAApprovalTeamBaseline leveraging the StartApprovalTeamBaseline service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMMlflowTrackingServer: added parameters S3BucketOwnerAccountId and S3BucketOwnerVerification.
    * Modified cmdlet Update-SMMlflowTrackingServer: added parameters S3BucketOwnerAccountId and S3BucketOwnerVerification.

### 5.0.167 (2026-03-04 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.203.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Add-CONNQueueEmailAddress leveraging the AssociateQueueEmailAddresses service API.
    * Added cmdlet Get-CONNQueueEmailAddressList leveraging the ListQueueEmailAddresses service API.
    * Added cmdlet Remove-CONNQueueEmailAddress leveraging the DisassociateQueueEmailAddresses service API.
    * Modified cmdlet New-CONNQueue: added parameter EmailAddressesConfig.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameter DeploymentStrategyOptions_DeploymentStrategy.
    * Modified cmdlet Update-ESDomainConfig: added parameter DeploymentStrategyOptions_DeploymentStrategy.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLPlayerConnectionDetail leveraging the GetPlayerConnectionDetails service API.
    * Modified cmdlet New-GMLContainerFleet: added parameter PlayerGatewayMode.
    * Modified cmdlet New-GMLFleet: added parameters PlayerGatewayConfiguration_GameServerIpProtocolSupported and PlayerGatewayMode.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter DeploymentStrategyOptions_DeploymentStrategy.
    * Modified cmdlet Update-OSDomainConfig: added parameter DeploymentStrategyOptions_DeploymentStrategy.
  * Amazon QuickSight
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_ApproveFlowShareRequest, Capabilities_BuildCalculatedFieldWithQ, Capabilities_CreateDashboardExecutiveSummaryWithQ, Capabilities_EditVisualWithQ, Capabilities_Extension and Capabilities_Topic.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_ApproveFlowShareRequest, Capabilities_BuildCalculatedFieldWithQ, Capabilities_CreateDashboardExecutiveSummaryWithQ, Capabilities_EditVisualWithQ, Capabilities_Extension and Capabilities_Topic.

### 5.0.166 (2026-03-03 23:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.202.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCPolicy: added parameters Definition_PolicyGeneration_PolicyGenerationAssetId and Definition_PolicyGeneration_PolicyGenerationId.
    * Modified cmdlet New-BACCPolicyEngine: added parameters EncryptionKeyArn and Tag.
    * Modified cmdlet Update-BACCAgentRuntime: added parameter MetadataConfiguration_RequireMMDSV2.
    * [Breaking Change] Modified cmdlet Update-BACCPolicy: removed parameter Description; added parameters Definition_PolicyGeneration_PolicyGenerationAssetId, Definition_PolicyGeneration_PolicyGenerationId and Description_OptionalValue.
    * [Breaking Change] Modified cmdlet Update-BACCPolicyEngine: removed parameter Description; added parameter Description_OptionalValue.
  * Amazon CloudWatch Logs
    * Added cmdlet Write-CWLBearerTokenAuthentication leveraging the PutBearerTokenAuthentication service API.
  * Amazon DataZone
    * Added cmdlet Find-DZGraph leveraging the QueryGraph service API.
  * Amazon Partner Central Channel API
    * [Breaking Change] Modified cmdlet New-PCCRelationship: removed parameter ResoldBusiness_Coverage; added parameters RequestedSupportPlan_ResoldUnifiedOperations_ChargeAccountId, RequestedSupportPlan_ResoldUnifiedOperations_Coverage and RequestedSupportPlan_ResoldUnifiedOperations_TamLocation.
    * [Breaking Change] Modified cmdlet Update-PCCRelationship: removed parameter ResoldBusiness_Coverage; added parameters RequestedSupportPlan_ResoldUnifiedOperations_ChargeAccountId, RequestedSupportPlan_ResoldUnifiedOperations_Coverage and RequestedSupportPlan_ResoldUnifiedOperations_TamLocation.

### 5.0.165 (2026-02-27 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.201.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ARC - Region switch
    * Modified cmdlet Start-ARCPlanExecution: added parameter RecoveryExecutionId.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter ComputeResources_ScalingPolicy_MinScaleDownDelayMinute.
    * Modified cmdlet Update-BATComputeEnvironment: added parameter ComputeResources_ScalingPolicy_MinScaleDownDelayMinute.
  * Amazon Bedrock
    * Modified cmdlet New-BDRModelInvocationJob: added parameter ModelInvocationType.
  * Amazon Cognito Identity Provider
    * Added cmdlet Add-CGIPUserPoolClientSecret leveraging the AddUserPoolClientSecret service API.
    * Added cmdlet Get-CGIPUserPoolClientSecretList leveraging the ListUserPoolClientSecrets service API.
    * Added cmdlet Remove-CGIPUserPoolClientSecret leveraging the DeleteUserPoolClientSecret service API.
    * Modified cmdlet New-CGIPUserPoolClient: added parameter ClientSecret.
  * Amazon Connect Customer Profiles
    * Modified cmdlet Write-CPFProfileObjectType: added parameter SourcePriority.
  * Amazon Oracle Database@Amazon Web Services
    * Modified cmdlet New-ODBOdbPeeringConnection: added parameter PeerNetworkRouteTableId.
  * Amazon Resource Access Manager (RAM)
    * Modified cmdlet New-RAMResourceShare: added parameter ResourceShareConfiguration_RetainSharingOnAccountLeaveOrganization.

### 5.0.164 (2026-02-26 21:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.200.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCapacityProvider: added parameters ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn and ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference.
    * Modified cmdlet Update-ECSCapacityProvider: added parameters ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn and ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference.

### 5.0.163 (2026-02-25 22:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.199.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Get-EC2CapacityBlockOffering: added parameter AllAvailabilityZone.
  * Amazon Neptune
    * Modified cmdlet New-NPTGlobalCluster: added parameters DatabaseName and Tag.
  * Amazon WAF V2
    * Added cmdlet Get-WAF2TopPathStatisticsByTraffic leveraging the GetTopPathStatisticsByTraffic service API.

### 5.0.162 (2026-02-24 21:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.198.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch
    * Added cmdlet Get-CWAlarmMuteRule leveraging the GetAlarmMuteRule service API.
    * Added cmdlet Get-CWAlarmMuteRuleList leveraging the ListAlarmMuteRules service API.
    * Added cmdlet Remove-CWAlarmMuteRule leveraging the DeleteAlarmMuteRule service API.
    * Added cmdlet Write-CWAlarmMuteRule leveraging the PutAlarmMuteRule service API.
  * Amazon CloudWatch Observability Admin Service
    * Modified cmdlet New-CWOADMNCentralizationRuleForOrganization: added parameter Rule_Destination_DestinationLogsConfiguration_LogGroupNameConfiguration_LogGroupNamePattern.
    * Modified cmdlet Update-CWOADMNCentralizationRuleForOrganization: added parameter Rule_Destination_DestinationLogsConfiguration_LogGroupNameConfiguration_LogGroupNamePattern.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Edit-EC2InstanceMetadataDefault: added parameter HttpTokensEnforced.
  * Amazon Elemental Inference. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EMI and can be listed using the command 'Get-AWSCmdletName -Service EMI'.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLChannel: added parameter InferenceSettings_FeedArn.
    * Modified cmdlet Update-EMLChannel: added parameter InferenceSettings_FeedArn.
  * Amazon Partner Central Selling API
    * Modified cmdlet Get-PCOpportunityList: added parameters TargetCloseDate_AfterTargetCloseDate and TargetCloseDate_BeforeTargetCloseDate.

### 5.0.161 (2026-02-23 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.197.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet Get-BDRAutomatedReasoningPolicyBuildWorkflowResultAsset: added parameter AssetId.
    * Modified cmdlet Start-BDRAutomatedReasoningPolicyBuildWorkflow: added parameter SourceContent_WorkflowContent_GenerateFidelityReportContent_Document.
  * Amazon DataZone
    * Modified cmdlet New-DZConnection: added parameters Props_WorkflowsMwaaProperties_MwaaEnvironmentName and Props_WorkflowsServerlessProperty.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBTable: added parameter GlobalTableSettingsReplicationMode.
  * Amazon Wickr Admin API
    * Added cmdlet Get-WICOpentdfConfig leveraging the GetOpentdfConfig service API.
    * Added cmdlet Register-WICOpentdfConfig leveraging the RegisterOpentdfConfig service API.
    * Modified cmdlet Update-WICNetworkSetting: added parameter Settings_EnableTrustedDataFormat.

### 5.0.160 (2026-02-20 22:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.196.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Modified cmdlet New-APSAppBlockBuilder: added parameter DisableIMDSV1.
    * Modified cmdlet New-APSFleet: added parameter DisableIMDSV1.
    * Modified cmdlet New-APSImageBuilder: added parameter DisableIMDSV1.
    * Modified cmdlet Update-APSAppBlockBuilder: added parameter DisableIMDSV1.
    * Modified cmdlet Update-APSFleet: added parameter DisableIMDSV1.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpointAsync: added parameters Filename and S3OutputPathExtension.
  * Amazon Signer Data Plane. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SGND and can be listed using the command 'Get-AWSCmdletName -Service SGND'.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMAssociation: added parameter AssociationDispatchAssumeRole.
    * Modified cmdlet New-SSMAssociationFromBatch: added parameter AssociationDispatchAssumeRole.
    * Modified cmdlet Update-SSMAssociation: added parameter AssociationDispatchAssumeRole.
  * Amazon Trusted Advisor
    * Modified cmdlet Get-TARecommendation: added parameter Language.
    * Modified cmdlet Get-TARecommendationList: added parameter Language.
    * Modified cmdlet Get-TARecommendationResourceList: added parameter Language.

### 5.0.159 (2026-02-19 21:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.195.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Private CA Connector for SCEP
    * Modified cmdlet New-PCASCEPConnector: added parameter VpcEndpointId.

### 5.0.158 (2026-02-18 21:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.194.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * [Breaking Change] Removed support for Amazon CloudWatch Evidently
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSConfiguredTable: added parameter TableReference_Athena_CatalogName.
    * Modified cmdlet Update-CRSConfiguredTable: added parameter TableReference_Athena_CatalogName.

### 5.0.157 (2026-02-17 22:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.193.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2PlacementGroup: added parameter Operator_Principal.
  * Amazon Managed Grafana
    * Modified cmdlet New-MGRFWorkspace: added parameter KmsKeyId.

### 5.0.156 (2026-02-16 21:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.192.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Key Management Service
    * Modified cmdlet Invoke-KMSDecrypt: added parameter DryRunModifier.
    * Modified cmdlet Invoke-KMSReEncrypt: added parameter DryRunModifier.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Modified cmdlet Update-MSKConnectivity: added parameter ConnectivityInfo_NetworkType.

### 5.0.155 (2026-02-13 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.191.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Get-CONNNotification leveraging the DescribeNotification service API.
    * Added cmdlet Get-CONNNotificationList leveraging the ListNotifications service API.
    * Added cmdlet Get-CONNUserNotificationList leveraging the ListUserNotifications service API.
    * Added cmdlet New-CONNNotification leveraging the CreateNotification service API.
    * Added cmdlet Remove-CONNNotification leveraging the DeleteNotification service API.
    * Added cmdlet Search-CONNNotification leveraging the SearchNotifications service API.
    * Added cmdlet Update-CONNNotificationContent leveraging the UpdateNotificationContent service API.
    * Added cmdlet Update-CONNUserNotificationStatus leveraging the UpdateUserNotificationStatus service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCluster: added parameter Orchestrator_Slurm_SlurmConfigStrategy.
    * Modified cmdlet Update-SMCluster: added parameters Orchestrator_Eks_ClusterArn and Orchestrator_Slurm_SlurmConfigStrategy.

### 5.0.154 (2026-02-12 21:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.190.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Edit-EC2InstanceCpuOption: added parameter NestedVirtualization.


### AWS.Tools.Installer 2.0.1-preview001 (2026-02-11 21:35Z)
  * **[PREVIEW RELEASE]** AWS.Tools.Installer V2 introduces a major architectural redesign to installation performance and reliability. This preview release is available for testing and feedback before general availability.
  
  * **New Cmdlets**
    * Added cmdlet Install-AWSToolsInstaller for installing/updating the installer module itself
    * Added cmdlet Uninstall-AWSToolsInstaller for removing the installer module
  
  * **Enhanced Security**
    * Implemented SHA512 hash validation for all downloads by default
    * Added -SkipIntegrityCheck parameter to bypass validation when needed
    * Added -SourceHashPath parameter for local hash file validation in offline scenarios
  
  * **Improved Version Management**
    * Added support for installing prerelease versions of AWS Tools for PowerShell and AWS Tools Installer
    * Added support for installing latest major versions using wildcard patterns (e.g., "4.*" installs latest 4.x version)
    * Restored -MinimumVersion and -MaximumVersion parameters for backward compatibility (marked as deprecated)
    * Enhanced version resolution with better error messages and validation
  
  * **Offline Installation Support**
    * Enhanced -SourceZipPath parameter to support local AWS.Tools.zip files for air-gapped environments
    * Added local hash file validation via -SourceHashPath parameter
  
  * **Alternative V1 Cmdlets**
    * Added V1 compatibility cmdlets (Install-AWSToolsModuleV1, Update-AWSToolsModuleV1, Uninstall-AWSToolsModuleV1) that maintain PowerShellGallery-based behavior for scripts that require it
    * V1 cmdlets display deprecation warnings and will be removed in next major version
  
  * **Breaking Changes**
    * Install-AWSToolsModule now installs all modules by default when -Name parameter is not specified
    * Removed proxy support (-Proxy and -ProxyCredential parameters); workloads behind proxies should configure session proxy settings
    * Deprecated parameters: -SkipUpdate, -SkipPublisherCheck, -AllowClobber (ignored in V2, will be removed in V3)
  
  * **Module Source**
    * Changed module source from PowerShellGallery to CloudFront-hosted AWS.Tools.zip
  
  * **PowerShellGet Compatibility**
    * Modules installed by AWS.Tools.Installer can now be removed with Uninstall-Module and Uninstall-PSResource
  
  * **Additional Improvements**
    * Added automatic version check that warns when newer versions of AWS.Tools.Installer are available
    * Added support for cleaning up legacy AWSPowerShell and AWSPowerShell.NetCore modules via -CleanUpLegacyModuleScope parameter
    * Refactored codebase into modular function files for better maintainability
    * Enhanced progress reporting with detailed status updates
    * Improved error handling with retry logic and exponential backoff
    * Added comprehensive unit test coverage
    * Cross-platform compatibility improvements for Windows, Linux, and macOS
  
  * **Documentation**
    * For detailed information about V2 changes, see: https://aws.amazon.com/blogs/developer/aws-tools-installer-v2-preview/
    * For migration guidance and feedback, see: https://github.com/aws/aws-tools-for-powershell/issues/411

### 5.0.153 (2026-02-11 21:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.189.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Managed Streaming for Kafka Connect
    * Modified cmdlet New-MSKCConnector: added parameter Capacity_AutoScaling_MaxAutoscalingTaskCount.
    * Modified cmdlet Update-MSKCConnector: added parameter Capacity_AutoScaling_MaxAutoscalingTaskCount.
  * Amazon S3 Tables
    * Modified cmdlet New-S3TTable: added parameters Metadata_Iceberg_PartitionSpec_Field, Metadata_Iceberg_PartitionSpec_SpecId, Metadata_Iceberg_WriteOrder_Field and Metadata_Iceberg_WriteOrder_OrderId.

### 5.0.152 (2026-02-10 22:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.188.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Start-BACBrowserSession: added parameters ProxyConfiguration_Bypass_DomainPattern and ProxyConfiguration_Proxy.
  * Amazon Connect Service
    * Added cmdlet Update-CONNUserConfig leveraging the UpdateUserConfig service API.
    * Modified cmdlet New-CONNUser: added parameters AfterContactWorkConfig, AutoAcceptConfig, PersistentConnectionConfig, PhoneNumberConfig and VoiceEnhancementConfig.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSPodIdentityAssociation: added parameter Policy.
    * Modified cmdlet Update-EKSPodIdentityAssociation: added parameter Policy.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet New-MSKTopic leveraging the CreateTopic service API.
    * Added cmdlet Remove-MSKTopic leveraging the DeleteTopic service API.
    * Added cmdlet Update-MSKTopic leveraging the UpdateTopic service API.
  * Amazon Relational Database Service
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameters BackupRetentionPeriod and PreferredBackupWindow.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameters BackupRetentionPeriod and PreferredBackupWindow.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameters BackupRetentionPeriod and PreferredBackupWindow.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameters BackupRetentionPeriod and PreferredBackupWindow.

### 5.0.151 (2026-02-09 22:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.187.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2SecondaryInterfaceDetail leveraging the DescribeSecondaryInterfaces service API.
    * Added cmdlet Get-EC2SecondaryNetworkDetail leveraging the DescribeSecondaryNetworks service API.
    * Added cmdlet Get-EC2SecondarySubnetDetail leveraging the DescribeSecondarySubnets service API.
    * Added cmdlet New-EC2SecondaryNetwork leveraging the CreateSecondaryNetwork service API.
    * Added cmdlet New-EC2SecondarySubnet leveraging the CreateSecondarySubnet service API.
    * Added cmdlet Remove-EC2SecondaryNetwork leveraging the DeleteSecondaryNetwork service API.
    * Added cmdlet Remove-EC2SecondarySubnet leveraging the DeleteSecondarySubnet service API.
    * Modified cmdlet New-EC2Instance: added parameter SecondaryInterface.
  * Amazon NeptuneData
    * Modified cmdlet Start-NEPTLoaderJob: added parameter EdgeOnlyLoad.

### 5.0.150 (2026-02-06 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.186.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCJob: added parameter Tag.
  * Amazon Managed integrations for AWS IoT Device Management
    * Modified cmdlet New-IOTMIAccountAssociation: added parameter GeneralAuthorization_AuthMaterialName.
    * Modified cmdlet New-IOTMIConnectorDestination: added parameter AuthConfig_GeneralAuthorization.
    * Modified cmdlet New-IOTMIProvisioningProfile: added parameter ClaimCertificate.
    * Modified cmdlet Start-IOTMIDeviceDiscovery: added parameter ConnectorDeviceIdList.
    * Modified cmdlet Update-IOTMIConnectorDestination: added parameters AuthConfig_GeneralAuthorizationUpdate_AuthMaterialsToAdd and AuthConfig_GeneralAuthorizationUpdate_AuthMaterialsToUpdate.
  * Amazon Partner Central Selling API
    * Modified cmdlet Get-PCOpportunityList: added parameters CreatedDate_AfterCreatedDate and CreatedDate_BeforeCreatedDate.
  * Amazon Runtime for Amazon Bedrock Data Automation
    * Modified cmdlet Invoke-BDARDataAutomation: added parameter OutputConfiguration_S3Uri.

### 5.0.149 (2026-02-05 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.185.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Added cmdlet Get-BACCBrowserProfile leveraging the GetBrowserProfile service API.
    * Added cmdlet Get-BACCBrowserProfileList leveraging the ListBrowserProfiles service API.
    * Added cmdlet New-BACCBrowserProfile leveraging the CreateBrowserProfile service API.
    * Added cmdlet Remove-BACCBrowserProfile leveraging the DeleteBrowserProfile service API.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Added cmdlet Save-BACBrowserSessionProfile leveraging the SaveBrowserSessionProfile service API.
    * Modified cmdlet Start-BACBrowserSession: added parameter ProfileConfiguration_ProfileIdentifier.
  * Amazon Glue
    * Added cmdlet Register-GLUEConnectionType leveraging the RegisterConnectionType service API.
    * Added cmdlet Remove-GLUEConnectionType leveraging the DeleteConnectionType service API.
  * Amazon Resource Access Manager (RAM)
    * Added cmdlet Get-RAMSourceAssociationList leveraging the ListSourceAssociations service API.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameters As2Config_AsyncMdnConfig_ServerId and As2Config_AsyncMdnConfig_Url.
    * Modified cmdlet Start-TFRFileTransfer: added parameter CustomHttpHeader.
    * Modified cmdlet Update-TFRConnector: added parameters As2Config_AsyncMdnConfig_ServerId and As2Config_AsyncMdnConfig_Url.

### 5.0.148 (2026-02-04 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.184.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Runtime
    * Modified cmdlet Invoke-BDRRConverse: added parameters OutputConfig_TextFormat_Structure_JsonSchema_Description, OutputConfig_TextFormat_Structure_JsonSchema_Name, OutputConfig_TextFormat_Structure_JsonSchema_Schema and OutputConfig_TextFormat_Type.
    * Modified cmdlet Invoke-BDRRConverseStream: added parameters OutputConfig_TextFormat_Structure_JsonSchema_Description, OutputConfig_TextFormat_Structure_JsonSchema_Name, OutputConfig_TextFormat_Structure_JsonSchema_Schema and OutputConfig_TextFormat_Type.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASField: added parameter Attributes_Text_IsMultiline.
    * Modified cmdlet Update-CCASField: added parameter Attributes_Text_IsMultiline.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLChannel: added parameter ChannelSecurityGroup.
    * Modified cmdlet New-EMLInput: added parameters SrtSettings_SrtListenerSettings_Decryption_Algorithm, SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn, SrtSettings_SrtListenerSettings_MinimumLatency and SrtSettings_SrtListenerSettings_StreamId.
    * Modified cmdlet Update-EMLChannel: added parameter ChannelSecurityGroup.
    * Modified cmdlet Update-EMLInput: added parameters SrtSettings_SrtListenerSettings_Decryption_Algorithm, SrtSettings_SrtListenerSettings_Decryption_PassphraseSecretArn, SrtSettings_SrtListenerSettings_MinimumLatency and SrtSettings_SrtListenerSettings_StreamId.
  * Amazon WorkSpaces Web
    * Modified cmdlet New-WSWPortal: added parameter PortalCustomDomain.
    * Modified cmdlet Update-WSWPortal: added parameter PortalCustomDomain.

### 5.0.147 (2026-02-03 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.183.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Kinesis
    * Modified cmdlet Write-KINRecord: added parameter StreamId.
    * Modified cmdlet Add-KINResourceTag: added parameter StreamId.
    * Modified cmdlet Add-KINTagsToStream: added parameter StreamId.
    * Modified cmdlet Disable-KINEnhancedMonitoring: added parameter StreamId.
    * Modified cmdlet Enable-KINEnhancedMonitoring: added parameter StreamId.
    * Modified cmdlet Get-KINRecord: added parameter StreamId.
    * Modified cmdlet Get-KINResourcePolicy: added parameter StreamId.
    * Modified cmdlet Get-KINResourceTag: added parameter StreamId.
    * Modified cmdlet Get-KINShardIterator: added parameter StreamId.
    * Modified cmdlet Get-KINShardList: added parameter StreamId.
    * Modified cmdlet Get-KINStream: added parameter StreamId.
    * Modified cmdlet Get-KINStreamConsumer: added parameter StreamId.
    * Modified cmdlet Get-KINStreamConsumerList: added parameter StreamId.
    * Modified cmdlet Get-KINStreamSummary: added parameter StreamId.
    * Modified cmdlet Get-KINTagsForStream: added parameter StreamId.
    * Modified cmdlet Merge-KINShard: added parameter StreamId.
    * Modified cmdlet Register-KINStreamConsumer: added parameter StreamId.
    * Modified cmdlet Remove-KINResourcePolicy: added parameter StreamId.
    * Modified cmdlet Remove-KINResourceTag: added parameter StreamId.
    * Modified cmdlet Remove-KINStream: added parameter StreamId.
    * Modified cmdlet Remove-KINTagsFromStream: added parameter StreamId.
    * Modified cmdlet Request-KINStreamRetentionPeriodDecrease: added parameter StreamId.
    * Modified cmdlet Request-KINStreamRetentionPeriodIncrease: added parameter StreamId.
    * Modified cmdlet Split-KINShard: added parameter StreamId.
    * Modified cmdlet Start-KINStreamEncryption: added parameter StreamId.
    * Modified cmdlet Stop-KINStreamEncryption: added parameter StreamId.
    * Modified cmdlet Unregister-KINStreamConsumer: added parameter StreamId.
    * Modified cmdlet Update-KINMaxRecordSize: added parameter StreamId.
    * Modified cmdlet Update-KINShardCount: added parameter StreamId.
    * Modified cmdlet Update-KINStreamMode: added parameter StreamId.
    * Modified cmdlet Update-KINStreamWarmThroughput: added parameter StreamId.
    * Modified cmdlet Write-KINMultipleRecord: added parameter StreamId.
    * Modified cmdlet Write-KINResourcePolicy: added parameter StreamId.
  * Amazon Location Service Maps V2
    * Modified cmdlet Get-GEOMStyleDescriptor: added parameter Building.
  * Amazon Single Sign-On Admin
    * Added cmdlet Add-SSOADMNRegion leveraging the AddRegion service API.
    * Added cmdlet Get-SSOADMNRegion leveraging the DescribeRegion service API.
    * Added cmdlet Get-SSOADMNRegionList leveraging the ListRegions service API.
    * Added cmdlet Remove-SSOADMNRegion leveraging the RemoveRegion service API.

### 5.0.146 (2026-02-02 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.182.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet New-BACCEvaluator: added parameter Tag.
    * Modified cmdlet New-BACCOnlineEvaluationConfig: added parameter Tag.
  * Amazon Multi-party Approval
    * Modified cmdlet Update-MPAApprovalTeam: added parameter UpdateAction.

### 5.0.145 (2026-01-30 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.181.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.144 (2026-01-29 21:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.180.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GameLift Service
    * Modified cmdlet Update-GMLFleetCapacity: added parameters ManagedCapacityConfiguration_ScaleInAfterInactivityMinute and ManagedCapacityConfiguration_ZeroCapacityStrategy.

### 5.0.143 (2026-01-28 21:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.179.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameters LambdaConfig_InboundFederation_LambdaArn and LambdaConfig_InboundFederation_LambdaVersion.
    * Modified cmdlet Update-CGIPUserPool: added parameters LambdaConfig_InboundFederation_LambdaArn and LambdaConfig_InboundFederation_LambdaVersion.
  * Amazon Connect Service
    * Modified cmdlet Search-CONNContact: added parameters SearchCriteria_ContactTags_AndCondition, SearchCriteria_ContactTags_OrCondition, SearchCriteria_ContactTags_TagCondition_TagKey and SearchCriteria_ContactTags_TagCondition_TagValue.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Search-EC2TransitGatewayRoute: added parameters NextToken and NoAutoIteration.
  * Amazon Elemental MediaConnect
    * Modified cmdlet New-EMCNFlow: added parameters EncodingConfig_EncodingProfile and EncodingConfig_VideoMaxBitrate.
    * Modified cmdlet Update-EMCNFlow: added parameters EncodingConfig_EncodingProfile and EncodingConfig_VideoMaxBitrate.
    * Modified cmdlet Update-EMCNFlowSource: added parameter NdiSourceSettings_SourceName.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter LoggingConfig_SystemLogLevel.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter LoggingConfig_SystemLogLevel.
  * Amazon S3 Control
    * Modified cmdlet New-S3CJob: added parameters Operation_S3UpdateObjectEncryption_ObjectEncryption_SSEKMS_BucketKeyEnabled and Operation_S3UpdateObjectEncryption_ObjectEncryption_SSEKMS_KMSKeyArn.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Update-S3ObjectEncryption leveraging the UpdateObjectEncryption service API.

### 5.0.142 (2026-01-27 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.178.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCJob: added parameters DescriptionOverride and NameOverride.
    * Modified cmdlet Update-ADCJob: added parameters Description and Name.
  * Amazon Connect Service
    * Modified cmdlet Start-CONNTaskContact: added parameter Attachment.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMClusterSchedulerConfig: added parameter SchedulerConfig_IdleResourceSharing.
    * Modified cmdlet New-SMComputeQuota: added parameter ComputeQuotaConfig_ResourceSharingConfig_AbsoluteBorrowLimit.
    * Modified cmdlet Update-SMClusterSchedulerConfig: added parameter SchedulerConfig_IdleResourceSharing.
    * Modified cmdlet Update-SMComputeQuota: added parameter ComputeQuotaConfig_ResourceSharingConfig_AbsoluteBorrowLimit.

### 5.0.141 (2026-01-26 21:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.177.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Modified cmdlet New-CCASCase: added parameter Tag.
    * Modified cmdlet New-CCASTemplate: added parameter TagPropagationConfiguration.
    * Modified cmdlet Update-CCASTemplate: added parameter TagPropagationConfiguration.
  * Amazon Ground Station
    * Modified cmdlet New-GSConfig: added parameters ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn, ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn and ConfigData_TelemetrySinkConfig_TelemetrySinkType.
    * Modified cmdlet New-GSMissionProfile: added parameter TelemetrySinkConfigArn.
    * Modified cmdlet Update-GSConfig: added parameters ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn, ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn and ConfigData_TelemetrySinkConfig_TelemetrySinkType.
    * Modified cmdlet Update-GSMissionProfile: added parameter TelemetrySinkConfigArn.

### 5.0.140 (2026-01-23 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.176.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Get-CONNTestCaseDetail leveraging the DescribeTestCase service API.
    * Added cmdlet Get-CONNTestCaseExecutionList leveraging the ListTestCaseExecutions service API.
    * Added cmdlet Get-CONNTestCaseExecutionRecordList leveraging the ListTestCaseExecutionRecords service API.
    * Added cmdlet Get-CONNTestCaseExecutionSummary leveraging the GetTestCaseExecutionSummary service API.
    * Added cmdlet Get-CONNTestCaseList leveraging the ListTestCases service API.
    * Added cmdlet New-CONNTestCase leveraging the CreateTestCase service API.
    * Added cmdlet Remove-CONNTestCase leveraging the DeleteTestCase service API.
    * Added cmdlet Search-CONNTestCase leveraging the SearchTestCases service API.
    * Added cmdlet Start-CONNTestCaseExecution leveraging the StartTestCaseExecution service API.
    * Added cmdlet Stop-CONNTestCaseExecution leveraging the StopTestCaseExecution service API.
    * Added cmdlet Update-CONNTestCase leveraging the UpdateTestCase service API.
  * Amazon DataZone
    * Added cmdlet Remove-DZDataExportConfiguration leveraging the DeleteDataExportConfiguration service API.
  * Amazon Q Connect
    * [Breaking Change] Modified cmdlet Update-QCAssistantAIAgent: removed parameter OrchestratorConfigurationList; added parameter OrchestratorUseCase.

### 5.0.139 (2026-01-22 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.175.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter DeletionProtection.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter DeletionProtection.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLScript: added parameter NodeJsVersion.

### 5.0.138 (2026-01-21 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.174.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer
    * Modified cmdlet Start-BACBrowserSession: added parameter Extension.
  * Amazon Config
    * Modified cmdlet Write-CFGConformancePack: added parameter Tag.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Add-EC2Volume: added parameter EbsCardIndex.
  * Amazon QuickSight
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_AmazonBedrockARSAction, Capabilities_AmazonBedrockFSAction, Capabilities_AmazonBedrockKRSAction, Capabilities_AmazonSThreeAction, Capabilities_AsanaAction, Capabilities_BambooHRAction, Capabilities_BoxAgentAction, Capabilities_CanvaAgentAction, Capabilities_ComprehendAction, Capabilities_ComprehendMedicalAction, Capabilities_ConfluenceAction, Capabilities_CreateAndUpdateAmazonBedrockARSAction, Capabilities_CreateAndUpdateAmazonBedrockFSAction, Capabilities_CreateAndUpdateAmazonBedrockKRSAction, Capabilities_CreateAndUpdateAmazonSThreeAction, Capabilities_CreateAndUpdateAsanaAction, Capabilities_CreateAndUpdateBambooHRAction, Capabilities_CreateAndUpdateBoxAgentAction, Capabilities_CreateAndUpdateCanvaAgentAction, Capabilities_CreateAndUpdateComprehendAction, Capabilities_CreateAndUpdateComprehendMedicalAction, Capabilities_CreateAndUpdateConfluenceAction, Capabilities_CreateAndUpdateFactSetAction, Capabilities_CreateAndUpdateGenericHTTPAction, Capabilities_CreateAndUpdateGithubAction, Capabilities_CreateAndUpdateGoogleCalendarAction, Capabilities_CreateAndUpdateHubspotAction, Capabilities_CreateAndUpdateHuggingFaceAction, Capabilities_CreateAndUpdateIntercomAction, Capabilities_CreateAndUpdateJiraAction, Capabilities_CreateAndUpdateLinearAction, Capabilities_CreateAndUpdateMCPAction, Capabilities_CreateAndUpdateMondayAction, Capabilities_CreateAndUpdateMSExchangeAction, Capabilities_CreateAndUpdateMSTeamsAction, Capabilities_CreateAndUpdateNewRelicAction, Capabilities_CreateAndUpdateNotionAction, Capabilities_CreateAndUpdateOneDriveAction, Capabilities_CreateAndUpdateOpenAPIAction, Capabilities_CreateAndUpdatePagerDutyAction, Capabilities_CreateAndUpdateSalesforceAction, Capabilities_CreateAndUpdateSandPGlobalEnergyAction, Capabilities_CreateAndUpdateSandPGMIAction, Capabilities_CreateAndUpdateSAPBillOfMaterialAction, Capabilities_CreateAndUpdateSAPBusinessPartnerAction, Capabilities_CreateAndUpdateSAPMaterialStockAction, Capabilities_CreateAndUpdateSAPPhysicalInventoryAction, Capabilities_CreateAndUpdateSAPProductMasterDataAction, Capabilities_CreateAndUpdateServiceNowAction, Capabilities_CreateAndUpdateSharePointAction, Capabilities_CreateAndUpdateSlackAction, Capabilities_CreateAndUpdateSmartsheetAction, Capabilities_CreateAndUpdateTextractAction, Capabilities_CreateAndUpdateZendeskAction, Capabilities_FactSetAction, Capabilities_GenericHTTPAction, Capabilities_GithubAction, Capabilities_GoogleCalendarAction, Capabilities_HubspotAction, Capabilities_HuggingFaceAction, Capabilities_IntercomAction, Capabilities_JiraAction, Capabilities_LinearAction, Capabilities_MCPAction, Capabilities_MondayAction, Capabilities_MSExchangeAction, Capabilities_MSTeamsAction, Capabilities_NewRelicAction, Capabilities_NotionAction, Capabilities_OneDriveAction, Capabilities_OpenAPIAction, Capabilities_PagerDutyAction, Capabilities_SalesforceAction, Capabilities_SandPGlobalEnergyAction, Capabilities_SandPGMIAction, Capabilities_SAPBillOfMaterialAction, Capabilities_SAPBusinessPartnerAction, Capabilities_SAPMaterialStockAction, Capabilities_SAPPhysicalInventoryAction, Capabilities_SAPProductMasterDataAction, Capabilities_ServiceNowAction, Capabilities_ShareAmazonBedrockARSAction, Capabilities_ShareAmazonBedrockFSAction, Capabilities_ShareAmazonBedrockKRSAction, Capabilities_ShareAmazonSThreeAction, Capabilities_ShareAsanaAction, Capabilities_ShareBambooHRAction, Capabilities_ShareBoxAgentAction, Capabilities_ShareCanvaAgentAction, Capabilities_ShareComprehendAction, Capabilities_ShareComprehendMedicalAction, Capabilities_ShareConfluenceAction, Capabilities_ShareFactSetAction, Capabilities_ShareGenericHTTPAction, Capabilities_ShareGithubAction, Capabilities_ShareGoogleCalendarAction, Capabilities_ShareHubspotAction, Capabilities_ShareHuggingFaceAction, Capabilities_ShareIntercomAction, Capabilities_ShareJiraAction, Capabilities_ShareLinearAction, Capabilities_ShareMCPAction, Capabilities_ShareMondayAction, Capabilities_ShareMSExchangeAction, Capabilities_ShareMSTeamsAction, Capabilities_ShareNewRelicAction, Capabilities_ShareNotionAction, Capabilities_ShareOneDriveAction, Capabilities_ShareOpenAPIAction, Capabilities_SharePagerDutyAction, Capabilities_SharePointAction, Capabilities_ShareSalesforceAction, Capabilities_ShareSandPGlobalEnergyAction, Capabilities_ShareSandPGMIAction, Capabilities_ShareSAPBillOfMaterialAction, Capabilities_ShareSAPBusinessPartnerAction, Capabilities_ShareSAPMaterialStockAction, Capabilities_ShareSAPPhysicalInventoryAction, Capabilities_ShareSAPProductMasterDataAction, Capabilities_ShareServiceNowAction, Capabilities_ShareSharePointAction, Capabilities_ShareSlackAction, Capabilities_ShareSmartsheetAction, Capabilities_ShareTextractAction, Capabilities_ShareZendeskAction, Capabilities_SlackAction, Capabilities_SmartsheetAction, Capabilities_TextractAction, Capabilities_UseAmazonBedrockARSAction, Capabilities_UseAmazonBedrockFSAction, Capabilities_UseAmazonBedrockKRSAction, Capabilities_UseAmazonSThreeAction, Capabilities_UseAsanaAction, Capabilities_UseBambooHRAction, Capabilities_UseBoxAgentAction, Capabilities_UseCanvaAgentAction, Capabilities_UseComprehendAction, Capabilities_UseComprehendMedicalAction, Capabilities_UseConfluenceAction, Capabilities_UseFactSetAction, Capabilities_UseGenericHTTPAction, Capabilities_UseGithubAction, Capabilities_UseGoogleCalendarAction, Capabilities_UseHubspotAction, Capabilities_UseHuggingFaceAction, Capabilities_UseIntercomAction, Capabilities_UseJiraAction, Capabilities_UseLinearAction, Capabilities_UseMCPAction, Capabilities_UseMondayAction, Capabilities_UseMSExchangeAction, Capabilities_UseMSTeamsAction, Capabilities_UseNewRelicAction, Capabilities_UseNotionAction, Capabilities_UseOneDriveAction, Capabilities_UseOpenAPIAction, Capabilities_UsePagerDutyAction, Capabilities_UseSalesforceAction, Capabilities_UseSandPGlobalEnergyAction, Capabilities_UseSandPGMIAction, Capabilities_UseSAPBillOfMaterialAction, Capabilities_UseSAPBusinessPartnerAction, Capabilities_UseSAPMaterialStockAction, Capabilities_UseSAPPhysicalInventoryAction, Capabilities_UseSAPProductMasterDataAction, Capabilities_UseServiceNowAction, Capabilities_UseSharePointAction, Capabilities_UseSlackAction, Capabilities_UseSmartsheetAction, Capabilities_UseTextractAction, Capabilities_UseZendeskAction and Capabilities_ZendeskAction.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_AmazonBedrockARSAction, Capabilities_AmazonBedrockFSAction, Capabilities_AmazonBedrockKRSAction, Capabilities_AmazonSThreeAction, Capabilities_AsanaAction, Capabilities_BambooHRAction, Capabilities_BoxAgentAction, Capabilities_CanvaAgentAction, Capabilities_ComprehendAction, Capabilities_ComprehendMedicalAction, Capabilities_ConfluenceAction, Capabilities_CreateAndUpdateAmazonBedrockARSAction, Capabilities_CreateAndUpdateAmazonBedrockFSAction, Capabilities_CreateAndUpdateAmazonBedrockKRSAction, Capabilities_CreateAndUpdateAmazonSThreeAction, Capabilities_CreateAndUpdateAsanaAction, Capabilities_CreateAndUpdateBambooHRAction, Capabilities_CreateAndUpdateBoxAgentAction, Capabilities_CreateAndUpdateCanvaAgentAction, Capabilities_CreateAndUpdateComprehendAction, Capabilities_CreateAndUpdateComprehendMedicalAction, Capabilities_CreateAndUpdateConfluenceAction, Capabilities_CreateAndUpdateFactSetAction, Capabilities_CreateAndUpdateGenericHTTPAction, Capabilities_CreateAndUpdateGithubAction, Capabilities_CreateAndUpdateGoogleCalendarAction, Capabilities_CreateAndUpdateHubspotAction, Capabilities_CreateAndUpdateHuggingFaceAction, Capabilities_CreateAndUpdateIntercomAction, Capabilities_CreateAndUpdateJiraAction, Capabilities_CreateAndUpdateLinearAction, Capabilities_CreateAndUpdateMCPAction, Capabilities_CreateAndUpdateMondayAction, Capabilities_CreateAndUpdateMSExchangeAction, Capabilities_CreateAndUpdateMSTeamsAction, Capabilities_CreateAndUpdateNewRelicAction, Capabilities_CreateAndUpdateNotionAction, Capabilities_CreateAndUpdateOneDriveAction, Capabilities_CreateAndUpdateOpenAPIAction, Capabilities_CreateAndUpdatePagerDutyAction, Capabilities_CreateAndUpdateSalesforceAction, Capabilities_CreateAndUpdateSandPGlobalEnergyAction, Capabilities_CreateAndUpdateSandPGMIAction, Capabilities_CreateAndUpdateSAPBillOfMaterialAction, Capabilities_CreateAndUpdateSAPBusinessPartnerAction, Capabilities_CreateAndUpdateSAPMaterialStockAction, Capabilities_CreateAndUpdateSAPPhysicalInventoryAction, Capabilities_CreateAndUpdateSAPProductMasterDataAction, Capabilities_CreateAndUpdateServiceNowAction, Capabilities_CreateAndUpdateSharePointAction, Capabilities_CreateAndUpdateSlackAction, Capabilities_CreateAndUpdateSmartsheetAction, Capabilities_CreateAndUpdateTextractAction, Capabilities_CreateAndUpdateZendeskAction, Capabilities_FactSetAction, Capabilities_GenericHTTPAction, Capabilities_GithubAction, Capabilities_GoogleCalendarAction, Capabilities_HubspotAction, Capabilities_HuggingFaceAction, Capabilities_IntercomAction, Capabilities_JiraAction, Capabilities_LinearAction, Capabilities_MCPAction, Capabilities_MondayAction, Capabilities_MSExchangeAction, Capabilities_MSTeamsAction, Capabilities_NewRelicAction, Capabilities_NotionAction, Capabilities_OneDriveAction, Capabilities_OpenAPIAction, Capabilities_PagerDutyAction, Capabilities_SalesforceAction, Capabilities_SandPGlobalEnergyAction, Capabilities_SandPGMIAction, Capabilities_SAPBillOfMaterialAction, Capabilities_SAPBusinessPartnerAction, Capabilities_SAPMaterialStockAction, Capabilities_SAPPhysicalInventoryAction, Capabilities_SAPProductMasterDataAction, Capabilities_ServiceNowAction, Capabilities_ShareAmazonBedrockARSAction, Capabilities_ShareAmazonBedrockFSAction, Capabilities_ShareAmazonBedrockKRSAction, Capabilities_ShareAmazonSThreeAction, Capabilities_ShareAsanaAction, Capabilities_ShareBambooHRAction, Capabilities_ShareBoxAgentAction, Capabilities_ShareCanvaAgentAction, Capabilities_ShareComprehendAction, Capabilities_ShareComprehendMedicalAction, Capabilities_ShareConfluenceAction, Capabilities_ShareFactSetAction, Capabilities_ShareGenericHTTPAction, Capabilities_ShareGithubAction, Capabilities_ShareGoogleCalendarAction, Capabilities_ShareHubspotAction, Capabilities_ShareHuggingFaceAction, Capabilities_ShareIntercomAction, Capabilities_ShareJiraAction, Capabilities_ShareLinearAction, Capabilities_ShareMCPAction, Capabilities_ShareMondayAction, Capabilities_ShareMSExchangeAction, Capabilities_ShareMSTeamsAction, Capabilities_ShareNewRelicAction, Capabilities_ShareNotionAction, Capabilities_ShareOneDriveAction, Capabilities_ShareOpenAPIAction, Capabilities_SharePagerDutyAction, Capabilities_SharePointAction, Capabilities_ShareSalesforceAction, Capabilities_ShareSandPGlobalEnergyAction, Capabilities_ShareSandPGMIAction, Capabilities_ShareSAPBillOfMaterialAction, Capabilities_ShareSAPBusinessPartnerAction, Capabilities_ShareSAPMaterialStockAction, Capabilities_ShareSAPPhysicalInventoryAction, Capabilities_ShareSAPProductMasterDataAction, Capabilities_ShareServiceNowAction, Capabilities_ShareSharePointAction, Capabilities_ShareSlackAction, Capabilities_ShareSmartsheetAction, Capabilities_ShareTextractAction, Capabilities_ShareZendeskAction, Capabilities_SlackAction, Capabilities_SmartsheetAction, Capabilities_TextractAction, Capabilities_UseAmazonBedrockARSAction, Capabilities_UseAmazonBedrockFSAction, Capabilities_UseAmazonBedrockKRSAction, Capabilities_UseAmazonSThreeAction, Capabilities_UseAsanaAction, Capabilities_UseBambooHRAction, Capabilities_UseBoxAgentAction, Capabilities_UseCanvaAgentAction, Capabilities_UseComprehendAction, Capabilities_UseComprehendMedicalAction, Capabilities_UseConfluenceAction, Capabilities_UseFactSetAction, Capabilities_UseGenericHTTPAction, Capabilities_UseGithubAction, Capabilities_UseGoogleCalendarAction, Capabilities_UseHubspotAction, Capabilities_UseHuggingFaceAction, Capabilities_UseIntercomAction, Capabilities_UseJiraAction, Capabilities_UseLinearAction, Capabilities_UseMCPAction, Capabilities_UseMondayAction, Capabilities_UseMSExchangeAction, Capabilities_UseMSTeamsAction, Capabilities_UseNewRelicAction, Capabilities_UseNotionAction, Capabilities_UseOneDriveAction, Capabilities_UseOpenAPIAction, Capabilities_UsePagerDutyAction, Capabilities_UseSalesforceAction, Capabilities_UseSandPGlobalEnergyAction, Capabilities_UseSandPGMIAction, Capabilities_UseSAPBillOfMaterialAction, Capabilities_UseSAPBusinessPartnerAction, Capabilities_UseSAPMaterialStockAction, Capabilities_UseSAPPhysicalInventoryAction, Capabilities_UseSAPProductMasterDataAction, Capabilities_UseServiceNowAction, Capabilities_UseSharePointAction, Capabilities_UseSlackAction, Capabilities_UseSmartsheetAction, Capabilities_UseTextractAction, Capabilities_UseZendeskAction and Capabilities_ZendeskAction.

### 5.0.137 (2026-01-20 21:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.173.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Modified cmdlet Get-ASScalingActivity: added parameter Filter.
  * Amazon Keyspaces
    * Modified cmdlet New-KSTable: added parameters WarmThroughputSpecification_ReadUnitsPerSecond and WarmThroughputSpecification_WriteUnitsPerSecond.
    * Modified cmdlet Update-KSTable: added parameters WarmThroughputSpecification_ReadUnitsPerSecond and WarmThroughputSpecification_WriteUnitsPerSecond.
  * Amazon Verified Permissions
    * Modified cmdlet New-AVPPolicyStore: added parameters EncryptionSettings_Default, EncryptionSettings_KmsEncryptionSettings_EncryptionContext and EncryptionSettings_KmsEncryptionSettings_Key.
  * Amazon Workspaces Instances
    * Modified cmdlet Get-WKSIInstanceTypeList: added parameters InstanceConfigurationFilter_BillingMode, InstanceConfigurationFilter_PlatformType and InstanceConfigurationFilter_Tenancy.
    * Modified cmdlet New-WKSIWorkspaceInstance: added parameter BillingConfiguration_BillingMode.

### 5.0.136 (2026-01-16 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.172.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Modified cmdlet New-CONNEvaluationForm: added parameters ReviewConfiguration_EligibilityDay and ReviewConfiguration_ReviewNotificationRecipient.
    * Modified cmdlet Update-CONNEvaluationForm: added parameters ReviewConfiguration_EligibilityDay and ReviewConfiguration_ReviewNotificationRecipient.
  * Amazon DataZone
    * Modified cmdlet Search-DZListing: added parameters Filters_Filter_IntValue and Filters_Filter_Operator.
    * Modified cmdlet Search-DZResource: added parameters Filters_Filter_IntValue and Filters_Filter_Operator.
    * Modified cmdlet Search-DZType: added parameters Filters_Filter_IntValue and Filters_Filter_Operator.
  * Amazon Launch Wizard
    * Added cmdlet Get-LWIZDeploymentPatternVersion leveraging the GetDeploymentPatternVersion service API.
    * Added cmdlet Get-LWIZDeploymentPatternVersionList leveraging the ListDeploymentPatternVersions service API.
    * Added cmdlet Update-LWIZDeployment leveraging the UpdateDeployment service API.

### 5.0.135 (2026-01-15 21:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.171.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCBudget: added parameter Tag.
  * Amazon Clean Rooms Service
    * Modified cmdlet Start-CRSProtectedJob: added parameter JobParameters_Parameter.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCapacityProvider: added parameter ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled.
  * Amazon Elastic VMware Service
    * Added cmdlet Get-EVSVersion leveraging the GetVersions service API.
    * Modified cmdlet New-EVSEnvironmentHost: added parameter EsxVersion.
  * Amazon Lake Formation
    * Added cmdlet Get-LKFTemporaryDataLocationCredential leveraging the GetTemporaryDataLocationCredentials service API.
    * Modified cmdlet Register-LKFResource: added parameter ExpectedResourceOwnerAccount.
    * Modified cmdlet Update-LKFResource: added parameter ExpectedResourceOwnerAccount.
  * Amazon OpenSearch Serverless
    * Added cmdlet Get-OSSCollectionGroup leveraging the BatchGetCollectionGroup service API.
    * Added cmdlet Get-OSSCollectionGroupList leveraging the ListCollectionGroups service API.
    * Added cmdlet New-OSSCollectionGroup leveraging the CreateCollectionGroup service API.
    * Added cmdlet Remove-OSSCollectionGroup leveraging the DeleteCollectionGroup service API.
    * Added cmdlet Update-OSSCollectionGroup leveraging the UpdateCollectionGroup service API.
    * Modified cmdlet Get-OSSCollectionList: added parameter CollectionFilters_CollectionGroupName.
    * Modified cmdlet New-OSSCollection: added parameters CollectionGroupName, EncryptionConfig_AWSOwnedKey and EncryptionConfig_KmsKeyArn.
  * Amazon Q Connect
    * [Breaking Change] Modified cmdlet New-QCAIPrompt: removed parameters TextAIPromptInferenceConfiguration_MaxTokensToSample, TextAIPromptInferenceConfiguration_Temperature, TextAIPromptInferenceConfiguration_TopK and TextAIPromptInferenceConfiguration_TopP; added parameters InferenceConfiguration_MaxTokensToSample, InferenceConfiguration_Temperature, InferenceConfiguration_TopK and InferenceConfiguration_TopP.
    * [Breaking Change] Modified cmdlet Update-QCAIPrompt: removed parameters TextAIPromptInferenceConfiguration_MaxTokensToSample, TextAIPromptInferenceConfiguration_Temperature, TextAIPromptInferenceConfiguration_TopK and TextAIPromptInferenceConfiguration_TopP; added parameters InferenceConfiguration_MaxTokensToSample, InferenceConfiguration_Temperature, InferenceConfiguration_TopK and InferenceConfiguration_TopP.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3Bucket: added parameter NoAutoIteration.
    * Modified cmdlet Get-S3DirectoryBucket: added parameter NoAutoIteration.
    * Modified cmdlet Get-S3Version: added parameter NoAutoIteration.

### 5.0.134 (2026-01-14 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.170.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Add-CONNHoursOfOperation leveraging the AssociateHoursOfOperations service API.
    * Added cmdlet Get-CONNChildHoursOfOperationList leveraging the ListChildHoursOfOperations service API.
    * Added cmdlet Unregister-CONNHoursOfOperation leveraging the DisassociateHoursOfOperations service API.
    * Modified cmdlet New-CONNHoursOfOperation: added parameter ParentHoursOfOperationConfig.
    * Modified cmdlet New-CONNHoursOfOperationOverride: added parameters OverrideType, RecurrenceConfig_RecurrencePattern_ByMonth, RecurrenceConfig_RecurrencePattern_ByMonthDay, RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence, RecurrenceConfig_RecurrencePattern_Frequency and RecurrenceConfig_RecurrencePattern_Interval.
    * Modified cmdlet Update-CONNHoursOfOperationOverride: added parameters OverrideType, RecurrenceConfig_RecurrencePattern_ByMonth, RecurrenceConfig_RecurrencePattern_ByMonthDay, RecurrenceConfig_RecurrencePattern_ByWeekdayOccurrence, RecurrenceConfig_RecurrencePattern_Frequency and RecurrenceConfig_RecurrencePattern_Interval.
  * Amazon End User Messaging Social
    * Modified cmdlet Update-SOCIALWhatsAppMessageTemplate: added parameters CtaUrlLinkTrackingOptedOut and ParameterFormat.
  * Amazon Redshift
    * Modified cmdlet Edit-RSCluster: added parameter ExtraComputeForAutomaticOptimization.
    * Modified cmdlet New-RSCluster: added parameter ExtraComputeForAutomaticOptimization.
  * Amazon Redshift Serverless
    * Modified cmdlet New-RSSWorkgroup: added parameter ExtraComputeForAutomaticOptimization.
    * Modified cmdlet Update-RSSWorkgroup: added parameter ExtraComputeForAutomaticOptimization.

### 5.0.133 (2026-01-13 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.169.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Get-DZSubscriptionGrantList: added parameter OwningIamPrincipalArn.
    * Modified cmdlet Get-DZSubscriptionList: added parameter OwningIamPrincipalArn.
    * Modified cmdlet Get-DZSubscriptionRequestList: added parameter OwningIamPrincipalArn.
    * Modified cmdlet New-DZSubscriptionTarget: added parameter SubscriptionGrantCreationMode.
    * Modified cmdlet Update-DZSubscriptionTarget: added parameter SubscriptionGrantCreationMode.

### 5.0.132 (2026-01-12 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.168.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Billing
    * Modified cmdlet New-AWSBBillingView: added parameters DataFilterExpression_CostCategories_Key and DataFilterExpression_CostCategories_Value.
    * Modified cmdlet Update-AWSBBillingView: added parameters DataFilterExpression_CostCategories_Key and DataFilterExpression_CostCategories_Value.
  * Amazon Managed integrations for AWS IoT Device Management
    * Modified cmdlet New-IOTMIManagedThing: added parameters WiFiSimpleSetupConfiguration_EnableAsProvisionee, WiFiSimpleSetupConfiguration_EnableAsProvisioner and WiFiSimpleSetupConfiguration_TimeoutInMinute.
    * Modified cmdlet Start-IOTMIDeviceDiscovery: added parameters EndDeviceIdentifier and Protocol.
    * Modified cmdlet Update-IOTMIManagedThing: added parameters WiFiSimpleSetupConfiguration_EnableAsProvisionee, WiFiSimpleSetupConfiguration_EnableAsProvisioner and WiFiSimpleSetupConfiguration_TimeoutInMinute.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3BucketWebsite: added parameter ContentMD5.

### 5.0.131 (2026-01-09 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.167.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet Get-BACCMemory: added parameter View.
  * Amazon Glue
    * Added cmdlet Get-GLUEMaterializedViewRefreshTaskRun leveraging the GetMaterializedViewRefreshTaskRun service API.
    * Added cmdlet Get-GLUEMaterializedViewRefreshTaskRunList leveraging the ListMaterializedViewRefreshTaskRuns service API.
    * Added cmdlet Start-GLUEMaterializedViewRefreshTaskRun leveraging the StartMaterializedViewRefreshTaskRun service API.
    * Added cmdlet Stop-GLUEMaterializedViewRefreshTaskRun leveraging the StopMaterializedViewRefreshTaskRun service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3BucketLogging: added parameter ContentMD5.

### 5.0.130 (2026-01-07 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.166.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.129 (2026-01-06 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.165.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameters DiskEncryptionConfiguration_EncryptionContext and DiskEncryptionConfiguration_EncryptionKeyArn.
    * Modified cmdlet Start-EMRServerlessJobRun: added parameters ConfigurationOverrides_DiskEncryptionConfiguration_EncryptionContext and ConfigurationOverrides_DiskEncryptionConfiguration_EncryptionKeyArn.
    * Modified cmdlet Update-EMRServerlessApplication: added parameters DiskEncryptionConfiguration_EncryptionContext and DiskEncryptionConfiguration_EncryptionKeyArn.

### 5.0.128 (2026-01-05 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.164.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CleanRoomsML
    * Modified cmdlet New-CRMLMLInputChannel: added parameter InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark.
    * Modified cmdlet Start-CRMLAudienceGenerationJob: added parameter SeedAudience_SqlComputeConfiguration_Worker_Properties_Spark.

### 5.0.127 (2026-01-02 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.163.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSCollaboration: added parameter IsMetricsEnabled.
    * Modified cmdlet New-CRSMembership: added parameter IsMetricsEnabled.
  * Amazon Identity Store
    * Modified cmdlet New-IDSUser: added parameter Role.

