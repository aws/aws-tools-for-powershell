### 4.0.5.0 (2020-03-13)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.699.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
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
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.671.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
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
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.668.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
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

### 4.0.2.0 (2019-12-13)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.648.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Improving speed of AWS.Tools.Installer's Install-AWSPowerShellModule and Update-AWSPowerShellModule, adding support for running AWS.Tools in strict mode.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBProfile: added parameters EndOfMeetingReminder_Enabled, EndOfMeetingReminder_ReminderAtMinute, EndOfMeetingReminder_ReminderType, InstantBooking_DurationInMinute, InstantBooking_Enabled, MeetingRoomConfiguration_RoomUtilizationMetricsEnabled, RequireCheckIn_Enabled and RequireCheckIn_ReleaseAfterMinute.
    * Modified cmdlet Update-ALXBProfile: added parameters EndOfMeetingReminder_Enabled, EndOfMeetingReminder_ReminderAtMinute, EndOfMeetingReminder_ReminderType, InstantBooking_DurationInMinute, InstantBooking_Enabled, MeetingRoomConfiguration_RoomUtilizationMetricsEnabled, RequireCheckIn_Enabled and RequireCheckIn_ReleaseAfterMinute.
  * Amazon API Gateway V2
    * Added cmdlet Import-AG2Api leveraging the ImportApi service API.
    * Added cmdlet Remove-AG2CorsConfiguration leveraging the DeleteCorsConfiguration service API.
    * Added cmdlet Remove-AG2RouteSetting leveraging the DeleteRouteSettings service API.
    * Added cmdlet Update-AG2ApiImport leveraging the ReimportApi service API.
    * Modified cmdlet New-AG2Api: added parameters CorsConfiguration_AllowCredential, CorsConfiguration_AllowHeader, CorsConfiguration_AllowMethod, CorsConfiguration_AllowOrigin, CorsConfiguration_ExposeHeader, CorsConfiguration_MaxAge, CredentialsArn, RouteKey and Target.
    * [Breaking Change] Modified cmdlet New-AG2Authorizer: removed parameter ProviderArn; added parameters JwtConfiguration_Audience and JwtConfiguration_Issuer.
    * Modified cmdlet New-AG2Integration: added parameter PayloadFormatVersion.
    * Modified cmdlet New-AG2Stage: added parameter AutoDeploy.
    * Modified cmdlet Update-AG2Api: added parameters CorsConfiguration_AllowCredential, CorsConfiguration_AllowHeader, CorsConfiguration_AllowMethod, CorsConfiguration_AllowOrigin, CorsConfiguration_ExposeHeader, CorsConfiguration_MaxAge, CredentialsArn, RouteKey and Target.
    * [Breaking Change] Modified cmdlet Update-AG2Authorizer: removed parameter ProviderArn; added parameters JwtConfiguration_Audience and JwtConfiguration_Issuer.
    * Modified cmdlet Update-AG2Integration: added parameter PayloadFormatVersion.
    * Modified cmdlet Update-AG2Stage: added parameter AutoDeploy.
  * Amazon AppConfig. Added cmdlets to support the service. Cmdlets for the service have the noun prefix APPC and can be listed using the command 'Get-AWSCmdletName -Service APPC'. Introducing AWS AppConfig, a new service that enables customers to quickly deploy validated configurations to applications of any size in a controlled and monitored fashion.
  * Amazon Augmented AI (A2I) Runtime. Added cmdlets to support the service. Cmdlets for the service have the noun prefix A2IR and can be listed using the command 'Get-AWSCmdletName -Service A2IR'. This release adds support for Amazon Augmented AI, which makes it easy to build workflows for human review of machine learning predictions.
  * Amazon CloudWatch
    * Added cmdlet Disable-CWInsightRule leveraging the DisableInsightRules service API.
    * Added cmdlet Enable-CWInsightRule leveraging the EnableInsightRules service API.
    * Added cmdlet Get-CWInsightRule leveraging the DescribeInsightRules service API.
    * Added cmdlet Get-CWInsightRuleReport leveraging the GetInsightRuleReport service API.
    * Added cmdlet Remove-CWInsightRule leveraging the DeleteInsightRules service API.
    * Added cmdlet Write-CWInsightRule leveraging the PutInsightRule service API.
  * Amazon CloudWatch Application Insights
    * Added cmdlet Add-CWAIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWAILogPattern leveraging the DescribeLogPattern service API.
    * Added cmdlet Get-CWAILogPatternList leveraging the ListLogPatterns service API.
    * Added cmdlet Get-CWAILogPatternSetList leveraging the ListLogPatternSets service API.
    * Added cmdlet Get-CWAIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-CWAILogPattern leveraging the CreateLogPattern service API.
    * Added cmdlet Remove-CWAILogPattern leveraging the DeleteLogPattern service API.
    * Added cmdlet Remove-CWAIResourceTag leveraging the UntagResource service API.
    * Added cmdlet Update-CWAILogPattern leveraging the UpdateLogPattern service API.
    * Modified cmdlet New-CWAIApplication: added parameter Tag.
  * Amazon CodeBuild
    * Added cmdlet Get-CBReportBatch leveraging the BatchGetReports service API.
    * Added cmdlet Get-CBReportGroupBatch leveraging the BatchGetReportGroups service API.
    * Added cmdlet Get-CBReportGroupList leveraging the ListReportGroups service API.
    * Added cmdlet Get-CBReportList leveraging the ListReports service API.
    * Added cmdlet Get-CBReportsForReportGroupList leveraging the ListReportsForReportGroup service API.
    * Added cmdlet Get-CBTestCase leveraging the DescribeTestCases service API.
    * Added cmdlet New-CBReportGroup leveraging the CreateReportGroup service API.
    * Added cmdlet Remove-CBReport leveraging the DeleteReport service API.
    * Added cmdlet Remove-CBReportGroup leveraging the DeleteReportGroup service API.
    * Added cmdlet Update-CBReportGroup leveraging the UpdateReportGroup service API.
  * Amazon CodeGuru Profiler. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CGP and can be listed using the command 'Get-AWSCmdletName -Service CGP'. Amazon CodeGuru Profiler analyzes application CPU utilization and latency characteristics to show you where you are spending the most cycles in your application. This analysis is presented in an interactive flame graph that helps you easily understand which paths consume the most resources, verify that your application is performing as expected, and uncover areas that can be optimized further.
  * Amazon CodeGuru Reviewer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CGR and can be listed using the command 'Get-AWSCmdletName -Service CGR'. This is the preview release of Amazon CodeGuru Reviewer.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter AccountRecoverySetting_RecoveryMechanism.
    * Modified cmdlet Update-CGIPUserPool: added parameter AccountRecoverySetting_RecoveryMechanism.
  * Amazon Comprehend
    * Added cmdlet Get-COMPEndpoint leveraging the DescribeEndpoint service API.
    * Added cmdlet Get-COMPEndpointList leveraging the ListEndpoints service API.
    * Added cmdlet Invoke-COMPDocumentClassification leveraging the ClassifyDocument service API.
    * Added cmdlet New-COMPEndpoint leveraging the CreateEndpoint service API.
    * Added cmdlet Remove-COMPEndpoint leveraging the DeleteEndpoint service API.
    * Added cmdlet Update-COMPEndpoint leveraging the UpdateEndpoint service API.
  * Amazon Compute Optimizer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CO and can be listed using the command 'Get-AWSCmdletName -Service CO'. AWS Compute Optimizer recommends optimal AWS Compute resources to reduce costs and improve performance for your workloads.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostCategoryDefinition leveraging the DescribeCostCategoryDefinition service API.
    * Added cmdlet Get-CECostCategoryDefinitionList leveraging the ListCostCategoryDefinitions service API.
    * Added cmdlet New-CECostCategoryDefinition leveraging the CreateCostCategoryDefinition service API.
    * Added cmdlet Remove-CECostCategoryDefinition leveraging the DeleteCostCategoryDefinition service API.
    * Added cmdlet Update-CECostCategoryDefinition leveraging the UpdateCostCategoryDefinition service API.
  * Amazon Directory Service
    * Added cmdlet Disable-DSLDAPS leveraging the DisableLDAPS service API.
    * Added cmdlet Enable-DSLDAPS leveraging the EnableLDAPS service API.
    * Added cmdlet Get-DSCertificate leveraging the DescribeCertificate service API.
    * Added cmdlet Get-DSCertificateList leveraging the ListCertificates service API.
    * Added cmdlet Get-DSLDAPSSetting leveraging the DescribeLDAPSSettings service API.
    * Added cmdlet Register-DSCertificate leveraging the RegisterCertificate service API.
    * Added cmdlet Unregister-DSCertificate leveraging the DeregisterCertificate service API.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBContributorInsight leveraging the DescribeContributorInsights service API.
    * Added cmdlet Get-DDBContributorInsightList leveraging the ListContributorInsights service API.
    * Added cmdlet Update-DDBContributorInsight leveraging the UpdateContributorInsights service API.
  * Amazon EBS. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EBS and can be listed using the command 'Get-AWSCmdletName -Service EBS'. This release introduces the EBS direct APIs for Snapshots: 1. Get-EBSChangedBlockList, which lists the block indexes and block tokens for blocks in an Amazon EBS snapshot. 2. Get-EBSSnapshotBlockList, which lists the block indexes and block tokens for blocks that are different between two snapshots of the same volume/snapshot lineage. 3. Get-EBSSnapshotBlock, which returns the data in a block of an Amazon EBS snapshot.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSCapacityProvider leveraging the DescribeCapacityProviders service API.
    * Added cmdlet New-ECSCapacityProvider leveraging the CreateCapacityProvider service API.
    * Added cmdlet Write-ECSClusterCapacityProvider leveraging the PutClusterCapacityProviders service API.
    * Modified cmdlet New-ECSCluster: added parameters CapacityProvider and DefaultCapacityProviderStrategy.
    * Modified cmdlet New-ECSService: added parameter CapacityProviderStrategy.
    * Modified cmdlet New-ECSTask: added parameter CapacityProviderStrategy.
    * Modified cmdlet New-ECSTaskSet: added parameter CapacityProviderStrategy.
    * Modified cmdlet Update-ECSService: added parameter CapacityProviderStrategy.
  * Amazon EC2 Image Builder. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EC2IB and can be listed using the command 'Get-AWSCmdletName -Service EC2IB'. Image Builder provides a managed experience for automating the creation of EC2 AMIs.
  * EC2
    * Added cmdlet Approve-EC2TransitGatewayPeeringAttachment leveraging the AcceptTransitGatewayPeeringAttachment service API.
    * Added cmdlet Deny-EC2TransitGatewayPeeringAttachment leveraging the RejectTransitGatewayPeeringAttachment service API.
    * Added cmdlet Edit-EC2DefaultCreditSpecification leveraging the ModifyDefaultCreditSpecification service API.
    * Added cmdlet Get-EC2CoipPool leveraging the DescribeCoipPools service API.
    * Added cmdlet Get-EC2CoipPoolUsage leveraging the GetCoipPoolUsage service API.
    * Added cmdlet Get-EC2DefaultCreditSpecification leveraging the GetDefaultCreditSpecification service API.
    * Added cmdlet Get-EC2LocalGateway leveraging the DescribeLocalGateways service API.
    * Added cmdlet Get-EC2LocalGatewayRouteTable leveraging the DescribeLocalGatewayRouteTables service API.
    * Added cmdlet Get-EC2LocalGatewayRouteTableVirtualInterfaceGroupAssociation leveraging the DescribeLocalGatewayRouteTableVirtualInterfaceGroupAssociations service API.
    * Added cmdlet Get-EC2LocalGatewayRouteTableVpcAssociation leveraging the DescribeLocalGatewayRouteTableVpcAssociations service API.
    * Added cmdlet Get-EC2LocalGatewayVirtualInterface leveraging the DescribeLocalGatewayVirtualInterfaces service API.
    * Added cmdlet Get-EC2LocalGatewayVirtualInterfaceGroup leveraging the DescribeLocalGatewayVirtualInterfaceGroups service API.
    * Added cmdlet Get-EC2TransitGatewayMulticastDomain leveraging the DescribeTransitGatewayMulticastDomains service API.
    * Added cmdlet Get-EC2TransitGatewayMulticastDomainAssociation leveraging the GetTransitGatewayMulticastDomainAssociations service API.
    * Added cmdlet Get-EC2TransitGatewayPeeringAttachment leveraging the DescribeTransitGatewayPeeringAttachments service API.
    * Added cmdlet New-EC2LocalGatewayRoute leveraging the CreateLocalGatewayRoute service API.
    * Added cmdlet New-EC2LocalGatewayRouteTableVpcAssociation leveraging the CreateLocalGatewayRouteTableVpcAssociation service API.
    * Added cmdlet New-EC2TransitGatewayMulticastDomain leveraging the CreateTransitGatewayMulticastDomain service API.
    * Added cmdlet New-EC2TransitGatewayPeeringAttachment leveraging the CreateTransitGatewayPeeringAttachment service API.
    * Added cmdlet Register-EC2TransitGatewayMulticastDomain leveraging the AssociateTransitGatewayMulticastDomain service API.
    * Added cmdlet Register-EC2TransitGatewayMulticastGroupMember leveraging the RegisterTransitGatewayMulticastGroupMembers service API.
    * Added cmdlet Register-EC2TransitGatewayMulticastGroupSource leveraging the RegisterTransitGatewayMulticastGroupSources service API.
    * Added cmdlet Remove-EC2LocalGatewayRoute leveraging the DeleteLocalGatewayRoute service API.
    * Added cmdlet Remove-EC2LocalGatewayRouteTableVpcAssociation leveraging the DeleteLocalGatewayRouteTableVpcAssociation service API.
    * Added cmdlet Remove-EC2TransitGatewayMulticastDomain leveraging the DeleteTransitGatewayMulticastDomain service API.
    * Added cmdlet Remove-EC2TransitGatewayPeeringAttachment leveraging the DeleteTransitGatewayPeeringAttachment service API.
    * Added cmdlet Search-EC2LocalGatewayRoute leveraging the SearchLocalGatewayRoutes service API.
    * Added cmdlet Search-EC2TransitGatewayMulticastGroup leveraging the SearchTransitGatewayMulticastGroups service API.
    * Added cmdlet Unregister-EC2TransitGatewayMulticastDomain leveraging the DisassociateTransitGatewayMulticastDomain service API.
    * Added cmdlet Unregister-EC2TransitGatewayMulticastGroupMember leveraging the DeregisterTransitGatewayMulticastGroupMembers service API.
    * Added cmdlet Unregister-EC2TransitGatewayMulticastGroupSource leveraging the DeregisterTransitGatewayMulticastGroupSources service API.
    * Modified cmdlet New-EC2Instance: added parameter Placement_HostResourceGroupArn.
    * Modified cmdlet Edit-EC2InstancePlacement: added parameter HostResourceGroupArn.
    * Modified cmdlet Get-EC2AvailabilityZone: added parameter AllAvailabilityZone.
    * Modified cmdlet New-EC2Address: added parameters CustomerOwnedIpv4Pool and NetworkBorderGroup.
    * Modified cmdlet New-EC2Route: added parameter LocalGatewayId.
    * Modified cmdlet New-EC2Subnet: added parameter OutpostArn.
    * Modified cmdlet New-EC2TransitGateway: added parameter Options_MulticastSupport.
    * Modified cmdlet New-EC2Volume: added parameter OutpostArn.
    * Modified cmdlet New-EC2Vpc: added parameter Ipv6CidrBlockNetworkBorderGroup.
    * Modified cmdlet New-EC2VpnConnection: added parameter Options_EnableAcceleration.
    * Modified cmdlet Register-EC2RouteTable: added parameter GatewayId.
    * Modified cmdlet Register-EC2VpcCidrBlock: added parameter Ipv6CidrBlockNetworkBorderGroup.
    * Modified cmdlet Remove-EC2Address: added parameter NetworkBorderGroup.
    * Modified cmdlet Set-EC2Route: added parameters LocalGatewayId and LocalTarget.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSFargateProfile leveraging the DescribeFargateProfile service API.
    * Added cmdlet Get-EKSFargateProfileList leveraging the ListFargateProfiles service API.
    * Added cmdlet New-EKSFargateProfile leveraging the CreateFargateProfile service API.
    * Added cmdlet Remove-EKSFargateProfile leveraging the DeleteFargateProfile service API.
  * Amazon Elastic Inference. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EI and can be listed using the command 'Get-AWSCmdletName -Service EI'. Amazon Elastic Inference allows customers to attach Elastic Inference Accelerators to Amazon EC2 and Amazon ECS tasks, thus providing low-cost GPU-powered acceleration and reducing the cost of running deep learning inference. This release allows customers to add or remove tags for their Elastic Inference Accelerators.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameters ElasticsearchClusterConfig_WarmCount, ElasticsearchClusterConfig_WarmEnabled and ElasticsearchClusterConfig_WarmType.
    * Modified cmdlet Update-ESDomainConfig: added parameters ElasticsearchClusterConfig_WarmCount, ElasticsearchClusterConfig_WarmEnabled and ElasticsearchClusterConfig_WarmType.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLMultiplex leveraging the DescribeMultiplex service API.
    * Added cmdlet Get-EMLMultiplexList leveraging the ListMultiplexes service API.
    * Added cmdlet Get-EMLMultiplexProgram leveraging the DescribeMultiplexProgram service API.
    * Added cmdlet Get-EMLMultiplexProgramList leveraging the ListMultiplexPrograms service API.
    * Added cmdlet New-EMLMultiplex leveraging the CreateMultiplex service API.
    * Added cmdlet New-EMLMultiplexProgram leveraging the CreateMultiplexProgram service API.
    * Added cmdlet Remove-EMLMultiplex leveraging the DeleteMultiplex service API.
    * Added cmdlet Remove-EMLMultiplexProgram leveraging the DeleteMultiplexProgram service API.
    * Added cmdlet Start-EMLMultiplex leveraging the StartMultiplex service API.
    * Added cmdlet Stop-EMLMultiplex leveraging the StopMultiplex service API.
    * Added cmdlet Update-EMLMultiplex leveraging the UpdateMultiplex service API.
    * Added cmdlet Update-EMLMultiplexProgram leveraging the UpdateMultiplexProgram service API.
    * Modified cmdlet Get-EMLOfferingList: added parameter Duration.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameters LivePreRollConfiguration_AdDecisionServerUrl and LivePreRollConfiguration_MaxDurationSecond.
  * Amazon Fraud Detector. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FD and can be listed using the command 'Get-AWSCmdletName -Service FD'. Amazon Fraud Detector is a fully managed service that makes it easy to identify potentially fraudulent online activities such as online payment fraud and the creation of fake accounts. Amazon Fraud Detector uses your data, machine learning (ML), and more than 20 years of fraud detection expertise from Amazon to automatically identify potentially fraudulent online activity so you can catch more fraud faster.
  * Amazon IAM Access Analyzer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IAMAA and can be listed using the command 'Get-AWSCmdletName -Service IAMAA'. IAM Access Analyzer is an IAM feature that makes it easy for AWS customers to ensure that their resource-based policies provide only the intended access to resources outside their AWS accounts.
  * Amazon IoT
    * Added cmdlet Get-IOTDomainConfiguration leveraging the DescribeDomainConfiguration service API.
    * Added cmdlet Get-IOTDomainConfigurationList leveraging the ListDomainConfigurations service API.
    * Added cmdlet Get-IOTProvisioningTemplate leveraging the DescribeProvisioningTemplate service API.
    * Added cmdlet Get-IOTProvisioningTemplateList leveraging the ListProvisioningTemplates service API.
    * Added cmdlet Get-IOTProvisioningTemplateVersion leveraging the DescribeProvisioningTemplateVersion service API.
    * Added cmdlet Get-IOTProvisioningTemplateVersionList leveraging the ListProvisioningTemplateVersions service API.
    * Added cmdlet New-IOTDomainConfiguration leveraging the CreateDomainConfiguration service API.
    * Added cmdlet New-IOTProvisioningClaim leveraging the CreateProvisioningClaim service API.
    * Added cmdlet New-IOTProvisioningTemplate leveraging the CreateProvisioningTemplate service API.
    * Added cmdlet New-IOTProvisioningTemplateVersion leveraging the CreateProvisioningTemplateVersion service API.
    * Added cmdlet Remove-IOTDomainConfiguration leveraging the DeleteDomainConfiguration service API.
    * Added cmdlet Remove-IOTProvisioningTemplate leveraging the DeleteProvisioningTemplate service API.
    * Added cmdlet Remove-IOTProvisioningTemplateVersion leveraging the DeleteProvisioningTemplateVersion service API.
    * Added cmdlet Update-IOTDomainConfiguration leveraging the UpdateDomainConfiguration service API.
    * Added cmdlet Update-IOTProvisioningTemplate leveraging the UpdateProvisioningTemplate service API.
    * Modified cmdlet Get-IOTAuditFindingList: added parameters ResourceIdentifier_IamRoleArn and ResourceIdentifier_RoleAliasArn.
    * Modified cmdlet New-IOTAuthorizer: added parameter SigningDisabled.
    * Modified cmdlet New-IOTTopicRule: added parameters IotSiteWise_PutAssetPropertyValueEntry and IotSiteWise_RoleArn.
    * Modified cmdlet Set-IOTTopicRule: added parameters IotSiteWise_PutAssetPropertyValueEntry and IotSiteWise_RoleArn.
    * Modified cmdlet Test-IOTInvokeAuthorizer: added parameters HttpContext_Header, HttpContext_QueryString, MqttContext_ClientId, MqttContext_Password, MqttContext_Username and TlsContext_ServerName.
  * Amazon IoT Secure Tunneling. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTST and can be listed using the command 'Get-AWSCmdletName -Service IOTST'. This release adds support for IoT Secure Tunneling to remote access devices behind restricted firewalls.
  * Amazon Kendra. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KNDR and can be listed using the command 'Get-AWSCmdletName -Service KNDR'. Amazon Kendra is a managed, highly accurate and easy to use enterprise search service that is powered by machine learning.
  * Amazon Key Management Service
    * Added cmdlet Get-KMSPublicKey leveraging the GetPublicKey service API.
    * Added cmdlet Invoke-KMSSigning leveraging the Sign service API.
    * Added cmdlet New-KMSDataKeyPair leveraging the GenerateDataKeyPair service API.
    * Added cmdlet New-KMSDataKeyPairWithoutPlaintext leveraging the GenerateDataKeyPairWithoutPlaintext service API.
    * Added cmdlet Test-KMSSignature leveraging the Verify service API.
    * Modified cmdlet Invoke-KMSDecrypt: added parameters EncryptionAlgorithm and KeyId.
    * Modified cmdlet Invoke-KMSEncrypt: added parameter EncryptionAlgorithm.
    * Modified cmdlet Invoke-KMSReEncrypt: added parameters DestinationEncryptionAlgorithm, SourceEncryptionAlgorithm and SourceKeyId.
    * Modified cmdlet New-KMSKey: added parameter CustomerMasterKeySpec.
  * Amazon Kinesis Analytics V2
    * Added cmdlet Add-KINA2ApplicationVpcConfiguration leveraging the AddApplicationVpcConfiguration service API.
    * Added cmdlet Remove-KINA2ApplicationVpcConfiguration leveraging the DeleteApplicationVpcConfiguration service API.
  * Amazon Kinesis Video Signaling Channels. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KVSC and can be listed using the command 'Get-AWSCmdletName -Service KVSC'. Announcing support for WebRTC in Kinesis Video Streams, as fully managed capability. You can now use simple APIs to enable your connected devices, web, and mobile apps with real-time two-way media streaming capabilities.
  * Amazon Kinesis Video Streams
    * Added cmdlet Add-KVResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KVResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-KVSignalingChannel leveraging the DescribeSignalingChannel service API.
    * Added cmdlet Get-KVSignalingChannelEndpoint leveraging the GetSignalingChannelEndpoint service API.
    * Added cmdlet Get-KVSignalingChannelList leveraging the ListSignalingChannels service API.
    * Added cmdlet New-KVSignalingChannel leveraging the CreateSignalingChannel service API.
    * Added cmdlet Remove-KVResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-KVSignalingChannel leveraging the DeleteSignalingChannel service API.
    * Added cmdlet Update-KVSignalingChannel leveraging the UpdateSignalingChannel service API.
  * Amazon Lambda
    * Added cmdlet Get-LMFunctionConcurrency leveraging the GetFunctionConcurrency service API.
    * Added cmdlet Get-LMFunctionEventInvokeConfig leveraging the GetFunctionEventInvokeConfig service API.
    * Added cmdlet Get-LMFunctionEventInvokeConfigList leveraging the ListFunctionEventInvokeConfigs service API.
    * Added cmdlet Get-LMProvisionedConcurrencyConfig leveraging the GetProvisionedConcurrencyConfig service API.
    * Added cmdlet Get-LMProvisionedConcurrencyConfigList leveraging the ListProvisionedConcurrencyConfigs service API.
    * Added cmdlet Remove-LMFunctionEventInvokeConfig leveraging the DeleteFunctionEventInvokeConfig service API.
    * Added cmdlet Remove-LMProvisionedConcurrencyConfig leveraging the DeleteProvisionedConcurrencyConfig service API.
    * Added cmdlet Update-LMFunctionEventInvokeConfig leveraging the UpdateFunctionEventInvokeConfig service API.
    * Added cmdlet Write-LMFunctionEventInvokeConfig leveraging the PutFunctionEventInvokeConfig service API.
    * Added cmdlet Write-LMProvisionedConcurrencyConfig leveraging the PutProvisionedConcurrencyConfig service API.
    * Modified cmdlet New-LMEventSourceMapping: added parameters BisectBatchOnFunctionError, MaximumRecordAgeInSecond, MaximumRetryAttempt, OnFailure_Destination, OnSuccess_Destination and ParallelizationFactor.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters BisectBatchOnFunctionError, MaximumRecordAgeInSecond, MaximumRetryAttempt, OnFailure_Destination, OnSuccess_Destination and ParallelizationFactor.
  * Amazon License Manager
    * Added cmdlet Get-LICMFailuresForLicenseConfigurationOperationList leveraging the ListFailuresForLicenseConfigurationOperations service API.
    * Modified cmdlet New-LICMLicenseConfiguration: added parameter ProductInformationList.
    * Modified cmdlet Update-LICMLicenseConfiguration: added parameter ProductInformationList.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Update-MSKMonitoring leveraging the UpdateMonitoring service API.
    * Modified cmdlet New-MSKCluster: added parameters JmxExporter_EnabledInBroker and NodeExporter_EnabledInBroker.
  * Amazon Network Manager. Added cmdlets to support the service. Cmdlets for the service have the noun prefix NMGR and can be listed using the command 'Get-AWSCmdletName -Service NMGR'.
  * Amazon Organizations
    * Added cmdlet Get-ORGEffectivePolicy leveraging the DescribeEffectivePolicy service API.
  * Amazon Outposts. Added cmdlets to support the service. Cmdlets for the service have the noun prefix OUTP and can be listed using the command 'Get-AWSCmdletName -Service OUTP'. AWS Outposts is a fully managed service that extends AWS infrastructure, services, APIs, and tools to customer sites. AWS Outposts enables you to launch and run EC2 instances and EBS volumes locally at your on-premises location. This release introduces new APIs for creating and viewing Outposts.
  * Amazon Redshift
    * Added cmdlet Edit-RSScheduledAction leveraging the ModifyScheduledAction service API.
    * Added cmdlet Get-RSScheduledAction leveraging the DescribeScheduledActions service API.
    * Added cmdlet New-RSScheduledAction leveraging the CreateScheduledAction service API.
    * Added cmdlet Remove-RSScheduledAction leveraging the DeleteScheduledAction service API.
    * Modified cmdlet Get-RSNodeConfigurationOption: added parameter ClusterIdentifier.
  * Amazon Rekognition
    * Added cmdlet Find-REKCustomLabel leveraging the DetectCustomLabels service API.
    * Added cmdlet Get-REKProject leveraging the DescribeProjects service API.
    * Added cmdlet Get-REKProjectVersion leveraging the DescribeProjectVersions service API.
    * Added cmdlet New-REKProject leveraging the CreateProject service API.
    * Added cmdlet New-REKProjectVersion leveraging the CreateProjectVersion service API.
    * Added cmdlet Start-REKProjectVersion leveraging the StartProjectVersion service API.
    * Added cmdlet Stop-REKProjectVersion leveraging the StopProjectVersion service API.
    * Modified cmdlet Find-REKModerationLabel: added parameters DataAttributes_ContentClassifier, HumanLoopConfig_FlowDefinitionArn and HumanLoopConfig_HumanLoopName.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSDBProxy leveraging the ModifyDBProxy service API.
    * Added cmdlet Edit-RDSDBProxyTargetGroup leveraging the ModifyDBProxyTargetGroup service API.
    * Added cmdlet Get-RDSDBProxy leveraging the DescribeDBProxies service API.
    * Added cmdlet Get-RDSDBProxyTarget leveraging the DescribeDBProxyTargets service API.
    * Added cmdlet Get-RDSDBProxyTargetGroup leveraging the DescribeDBProxyTargetGroups service API.
    * Added cmdlet New-RDSDBProxy leveraging the CreateDBProxy service API.
    * Added cmdlet Register-RDSDBProxyTarget leveraging the RegisterDBProxyTargets service API.
    * Added cmdlet Remove-RDSDBProxy leveraging the DeleteDBProxy service API.
    * Added cmdlet Unregister-RDSDBProxyTarget leveraging the DeregisterDBProxyTargets service API.
    * Modified cmdlet New-RDSDBClusterEndpoint: added parameter Tag.
  * Amazon Resource Access Manager (RAM)
    * Added cmdlet Add-RAMPermissionToResourceShare leveraging the AssociateResourceSharePermission service API.
    * Added cmdlet Convert-RAMPolicyBasedResourceShareToPromoted leveraging the PromoteResourceShareCreatedFromPolicy service API.
    * Added cmdlet Get-RAMPermission leveraging the GetPermission service API.
    * Added cmdlet Get-RAMPermissionList leveraging the ListPermissions service API.
    * Added cmdlet Get-RAMResourceSharePermissionList leveraging the ListResourceSharePermissions service API.
    * Added cmdlet Remove-RAMPermissionFromResourceShare leveraging the DisassociateResourceSharePermission service API.
    * Modified cmdlet New-RAMResourceShare: added parameter PermissionArn.
  * Amazon Resource Groups Tagging API
    * Added cmdlet Get-RGTComplianceSummary leveraging the GetComplianceSummary service API.
    * Added cmdlet Get-RGTReportCreation leveraging the DescribeReportCreation service API.
    * Added cmdlet Start-RGTReportCreation leveraging the StartReportCreation service API.
    * Modified cmdlet Get-RGTResource: added parameters ExcludeCompliantResource and IncludeComplianceDetail.
  * Amazon S3 Control
    * Added cmdlet Get-S3CAccessPoint leveraging the GetAccessPoint service API.
    * Added cmdlet Get-S3CAccessPointList leveraging the ListAccessPoints service API.
    * Added cmdlet Get-S3CAccessPointPolicy leveraging the GetAccessPointPolicy service API.
    * Added cmdlet Get-S3CAccessPointPolicyStatus leveraging the GetAccessPointPolicyStatus service API.
    * Added cmdlet New-S3CAccessPoint leveraging the CreateAccessPoint service API.
    * Added cmdlet Remove-S3CAccessPoint leveraging the DeleteAccessPoint service API.
    * Added cmdlet Remove-S3CAccessPointPolicy leveraging the DeleteAccessPointPolicy service API.
    * Added cmdlet Write-S3CAccessPointPolicy leveraging the PutAccessPointPolicy service API.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpoint: added parameter TargetModel.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMApp leveraging the DescribeApp service API.
    * Added cmdlet Get-SMAppList leveraging the ListApps service API.
    * Added cmdlet Get-SMAutoMLJob leveraging the DescribeAutoMLJob service API.
    * Added cmdlet Get-SMAutoMLJobList leveraging the ListAutoMLJobs service API.
    * Added cmdlet Get-SMCandidatesForAutoMLJobList leveraging the ListCandidatesForAutoMLJob service API.
    * Added cmdlet Get-SMDomain leveraging the DescribeDomain service API.
    * Added cmdlet Get-SMDomainList leveraging the ListDomains service API.
    * Added cmdlet Get-SMExperiment leveraging the DescribeExperiment service API.
    * Added cmdlet Get-SMExperimentList leveraging the ListExperiments service API.
    * Added cmdlet Get-SMFlowDefinition leveraging the DescribeFlowDefinition service API.
    * Added cmdlet Get-SMFlowDefinitionList leveraging the ListFlowDefinitions service API.
    * Added cmdlet Get-SMHumanTaskUi leveraging the DescribeHumanTaskUi service API.
    * Added cmdlet Get-SMHumanTaskUiList leveraging the ListHumanTaskUis service API.
    * Added cmdlet Get-SMMonitoringExecutionList leveraging the ListMonitoringExecutions service API.
    * Added cmdlet Get-SMMonitoringSchedule leveraging the DescribeMonitoringSchedule service API.
    * Added cmdlet Get-SMMonitoringScheduleList leveraging the ListMonitoringSchedules service API.
    * Added cmdlet Get-SMProcessingJob leveraging the DescribeProcessingJob service API.
    * Added cmdlet Get-SMProcessingJobList leveraging the ListProcessingJobs service API.
    * Added cmdlet Get-SMTrial leveraging the DescribeTrial service API.
    * Added cmdlet Get-SMTrialComponent leveraging the DescribeTrialComponent service API.
    * Added cmdlet Get-SMTrialComponentList leveraging the ListTrialComponents service API.
    * Added cmdlet Get-SMTrialList leveraging the ListTrials service API.
    * Added cmdlet Get-SMUserProfile leveraging the DescribeUserProfile service API.
    * Added cmdlet Get-SMUserProfileList leveraging the ListUserProfiles service API.
    * Added cmdlet New-SMApp leveraging the CreateApp service API.
    * Added cmdlet New-SMAutoMLJob leveraging the CreateAutoMLJob service API.
    * Added cmdlet New-SMDomain leveraging the CreateDomain service API.
    * Added cmdlet New-SMExperiment leveraging the CreateExperiment service API.
    * Added cmdlet New-SMFlowDefinition leveraging the CreateFlowDefinition service API.
    * Added cmdlet New-SMHumanTaskUi leveraging the CreateHumanTaskUi service API.
    * Added cmdlet New-SMMonitoringSchedule leveraging the CreateMonitoringSchedule service API.
    * Added cmdlet New-SMPresignedDomainUrl leveraging the CreatePresignedDomainUrl service API.
    * Added cmdlet New-SMProcessingJob leveraging the CreateProcessingJob service API.
    * Added cmdlet New-SMTrial leveraging the CreateTrial service API.
    * Added cmdlet New-SMTrialComponent leveraging the CreateTrialComponent service API.
    * Added cmdlet New-SMUserProfile leveraging the CreateUserProfile service API.
    * Added cmdlet Register-SMTrialComponent leveraging the AssociateTrialComponent service API.
    * Added cmdlet Remove-SMApp leveraging the DeleteApp service API.
    * Added cmdlet Remove-SMDomain leveraging the DeleteDomain service API.
    * Added cmdlet Remove-SMExperiment leveraging the DeleteExperiment service API.
    * Added cmdlet Remove-SMFlowDefinition leveraging the DeleteFlowDefinition service API.
    * Added cmdlet Remove-SMMonitoringSchedule leveraging the DeleteMonitoringSchedule service API.
    * Added cmdlet Remove-SMTrial leveraging the DeleteTrial service API.
    * Added cmdlet Remove-SMTrialComponent leveraging the DeleteTrialComponent service API.
    * Added cmdlet Remove-SMUserProfile leveraging the DeleteUserProfile service API.
    * Added cmdlet Start-SMMonitoringSchedule leveraging the StartMonitoringSchedule service API.
    * Added cmdlet Stop-SMAutoMLJob leveraging the StopAutoMLJob service API.
    * Added cmdlet Stop-SMMonitoringSchedule leveraging the StopMonitoringSchedule service API.
    * Added cmdlet Stop-SMProcessingJob leveraging the StopProcessingJob service API.
    * Added cmdlet Unregister-SMTrialComponent leveraging the DisassociateTrialComponent service API.
    * Added cmdlet Update-SMDomain leveraging the UpdateDomain service API.
    * Added cmdlet Update-SMExperiment leveraging the UpdateExperiment service API.
    * Added cmdlet Update-SMMonitoringSchedule leveraging the UpdateMonitoringSchedule service API.
    * Added cmdlet Update-SMTrial leveraging the UpdateTrial service API.
    * Added cmdlet Update-SMTrialComponent leveraging the UpdateTrialComponent service API.
    * Added cmdlet Update-SMUserProfile leveraging the UpdateUserProfile service API.
    * Modified cmdlet New-SMEndpointConfig: added parameters CaptureContentTypeHeader_CsvContentType, CaptureContentTypeHeader_JsonContentType, DataCaptureConfig_CaptureOption, DataCaptureConfig_DestinationS3Uri, DataCaptureConfig_EnableCapture, DataCaptureConfig_InitialSamplingPercentage and DataCaptureConfig_KmsKeyId.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameters HyperParameterRanges_CategoricalParameterRange, HyperParameterRanges_ContinuousParameterRange, HyperParameterRanges_IntegerParameterRange, TrainingJobDefinition, TrainingJobDefinition_DefinitionName, TuningJobCompletionCriteria_TargetObjectiveMetricValue, TuningObjective_MetricName and TuningObjective_Type.
    * Modified cmdlet New-SMTrainingJob: added parameters DebugHookConfig_CollectionConfiguration, DebugHookConfig_HookParameter, DebugHookConfig_LocalPath, DebugHookConfig_S3OutputPath, DebugRuleConfiguration, ExperimentConfig_ExperimentName, ExperimentConfig_TrialComponentDisplayName, ExperimentConfig_TrialName, TensorBoardOutputConfig_LocalPath and TensorBoardOutputConfig_S3OutputPath.
    * Modified cmdlet New-SMTransformJob: added parameters ExperimentConfig_ExperimentName, ExperimentConfig_TrialComponentDisplayName and ExperimentConfig_TrialName.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Get-SES2SuppressedDestination leveraging the GetSuppressedDestination service API.
    * Added cmdlet Get-SES2SuppressedDestinationList leveraging the ListSuppressedDestinations service API.
    * Added cmdlet Remove-SES2SuppressedDestination leveraging the DeleteSuppressedDestination service API.
    * Added cmdlet Write-SES2AccountSuppressionAttribute leveraging the PutAccountSuppressionAttributes service API.
    * Added cmdlet Write-SES2ConfigurationSetSuppressionOption leveraging the PutConfigurationSetSuppressionOptions service API.
    * Added cmdlet Write-SES2SuppressedDestination leveraging the PutSuppressedDestination service API.
    * Modified cmdlet New-SES2ConfigurationSet: added parameter SuppressionOptions_SuppressedReason.
  * Amazon Step Functions
    * Modified cmdlet New-SFNStateMachine: added parameters LoggingConfiguration_Destination, LoggingConfiguration_IncludeExecutionData, LoggingConfiguration_Level and Type.
    * Modified cmdlet Update-SFNStateMachine: added parameters LoggingConfiguration_Destination, LoggingConfiguration_IncludeExecutionData and LoggingConfiguration_Level.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMCalendarState leveraging the GetCalendarState service API.
    * Modified cmdlet Edit-SSMDocumentPermission: added parameter SharedDocumentVersion.
    * Modified cmdlet New-SSMDocument: added parameter Require.
    * Modified cmdlet Remove-SSMDocument: added parameter Enforce.
  * Amazon Textract
    * Modified cmdlet Invoke-TXTDocumentAnalysis: added parameters DataAttributes_ContentClassifier, HumanLoopConfig_FlowDefinitionArn and HumanLoopConfig_HumanLoopName.
  * Amazon WAF V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix WAF2 and can be listed using the command 'Get-AWSCmdletName -Service WAF2'. This release introduces new set of APIs (wafv2) for AWS WAF. Major changes include single set of APIs for creating/updating resources in global and regional scope, and rules are configured directly into web ACL instead of being referenced. The previous APIs (waf and waf-regional) are now referred as AWS WAF Classic. For more information visit: https://docs.aws.amazon.com/waf/latest/APIReference/Welcome.html

### 4.0.1.1 (2019-11-25)
  * Fixed an issue where an older version of AWSSDK.SageMakerRuntime was included in the modules resulting in the MSI installer being non functional.

### 4.0.1.0 (2019-11-25)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.637.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Fixed Get-AWSCmdletName returning wrong cmdlet names.
  * Fixed error in AWS.Tools.Installer.
  * Amazon Amplify
    * Added cmdlet Get-AMPBackendEnvironment leveraging the GetBackendEnvironment service API.
    * Added cmdlet Get-AMPBackendEnvironmentList leveraging the ListBackendEnvironments service API.
    * Added cmdlet New-AMPBackendEnvironment leveraging the CreateBackendEnvironment service API.
    * Added cmdlet Remove-AMPBackendEnvironment leveraging the DeleteBackendEnvironment service API.
    * Modified cmdlet New-AMPApp: added parameter AutoBranchCreationConfig_PullRequestEnvironmentName.
    * Modified cmdlet New-AMPBranch: added parameters BackendEnvironmentArn and PullRequestEnvironmentName.
    * Modified cmdlet Update-AMPApp: added parameter AutoBranchCreationConfig_PullRequestEnvironmentName.
    * Modified cmdlet Update-AMPBranch: added parameters BackendEnvironmentArn and PullRequestEnvironmentName.
  * Amazon AppSync
    * Added cmdlet Clear-ASYNApiCache leveraging the FlushApiCache service API.
    * Added cmdlet Get-ASYNApiCache leveraging the GetApiCache service API.
    * Added cmdlet New-ASYNApiCache leveraging the CreateApiCache service API.
    * Added cmdlet Remove-ASYNApiCache leveraging the DeleteApiCache service API.
    * Added cmdlet Update-ASYNApiCache leveraging the UpdateApiCache service API.
    * Modified cmdlet New-ASYNResolver: added parameters CachingConfig_CachingKey, CachingConfig_Ttl, LambdaConflictHandlerConfig_LambdaConflictHandlerArn, SyncConfig_ConflictDetection and SyncConfig_ConflictHandler.
    * Modified cmdlet Update-ASYNResolver: added parameters CachingConfig_CachingKey, CachingConfig_Ttl, LambdaConflictHandlerConfig_LambdaConflictHandlerArn, SyncConfig_ConflictDetection and SyncConfig_ConflictHandler.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter MaxInstanceLifetime.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter MaxInstanceLifetime.
  * Amazon Certificate Manager
    * Modified cmdlet Import-ACMCertificate: added parameter Tag.
    * Modified cmdlet New-ACMCertificate: added parameter Tag.
  * Amazon Chime
    * Added cmdlet Get-CHMAttendee leveraging the GetAttendee service API.
    * Added cmdlet Get-CHMAttendeeList leveraging the ListAttendees service API.
    * Added cmdlet Get-CHMMeeting leveraging the GetMeeting service API.
    * Added cmdlet Get-CHMMeetingList leveraging the ListMeetings service API.
    * Added cmdlet Get-CHMRoom leveraging the GetRoom service API.
    * Added cmdlet Get-CHMRoomList leveraging the ListRooms service API.
    * Added cmdlet Get-CHMRoomMembershipList leveraging the ListRoomMemberships service API.
    * Added cmdlet New-CHMAttendee leveraging the CreateAttendee service API.
    * Added cmdlet New-CHMAttendeeBatch leveraging the BatchCreateAttendee service API.
    * Added cmdlet New-CHMMeeting leveraging the CreateMeeting service API.
    * Added cmdlet New-CHMRoom leveraging the CreateRoom service API.
    * Added cmdlet New-CHMRoomMembership leveraging the CreateRoomMembership service API.
    * Added cmdlet New-CHMRoomMembershipBatch leveraging the BatchCreateRoomMembership service API.
    * Added cmdlet Remove-CHMAttendee leveraging the DeleteAttendee service API.
    * Added cmdlet Remove-CHMMeeting leveraging the DeleteMeeting service API.
    * Added cmdlet Remove-CHMRoom leveraging the DeleteRoom service API.
    * Added cmdlet Remove-CHMRoomMembership leveraging the DeleteRoomMembership service API.
    * Added cmdlet Update-CHMRoom leveraging the UpdateRoom service API.
    * Added cmdlet Update-CHMRoomMembership leveraging the UpdateRoomMembership service API.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNType leveraging the DescribeType service API.
    * Added cmdlet Get-CFNTypeList leveraging the ListTypes service API.
    * Added cmdlet Get-CFNTypeRegistration leveraging the DescribeTypeRegistration service API.
    * Added cmdlet Get-CFNTypeRegistrationList leveraging the ListTypeRegistrations service API.
    * Added cmdlet Get-CFNTypeVersion leveraging the ListTypeVersions service API.
    * Added cmdlet Register-CFNType leveraging the RegisterType service API.
    * Added cmdlet Set-CFNTypeDefaultVersion leveraging the SetTypeDefaultVersion service API.
    * Added cmdlet Start-CFNStackSetDriftDetection leveraging the DetectStackSetDrift service API.
    * Added cmdlet Unregister-CFNType leveraging the DeregisterType service API.
    * Added cmdlet Write-CFNHandlerProgress leveraging the RecordHandlerProgress service API.
    * Modified cmdlet New-CFNChangeSet: added parameter ResourcesToImport.
  * Amazon CloudSearch
    * Added cmdlet Get-CSDomainEndpointOption leveraging the DescribeDomainEndpointOptions service API.
    * Added cmdlet Update-CSDomainEndpointOption leveraging the UpdateDomainEndpointOptions service API.
  * Amazon CloudTrail
    * Added cmdlet Get-CTInsightSelector leveraging the GetInsightSelectors service API.
    * Added cmdlet Get-CTTrailByName leveraging the GetTrail service API.
    * Added cmdlet Get-CTTrailSummary leveraging the ListTrails service API.
    * Added cmdlet Write-CTInsightSelector leveraging the PutInsightSelectors service API.
    * Modified cmdlet Find-CTEvent: added parameter EventCategory.
    * Modified cmdlet New-CTTrail: added parameter TagsList.
  * Amazon CodeCommit
    * Added cmdlet Add-CCApprovalRuleTemplateToRepository leveraging the AssociateApprovalRuleTemplateWithRepository service API.
    * Added cmdlet Add-CCApprovalRuleTemplateToRepositoryBatch leveraging the BatchAssociateApprovalRuleTemplateWithRepositories service API.
    * Added cmdlet Get-CCApprovalRuleTemplate leveraging the GetApprovalRuleTemplate service API.
    * Added cmdlet Get-CCApprovalRuleTemplateList leveraging the ListApprovalRuleTemplates service API.
    * Added cmdlet Get-CCAssociatedApprovalRuleTemplatesForRepositoryList leveraging the ListAssociatedApprovalRuleTemplatesForRepository service API.
    * Added cmdlet Get-CCPullRequestApprovalState leveraging the GetPullRequestApprovalStates service API.
    * Added cmdlet Get-CCPullRequestOverrideState leveraging the GetPullRequestOverrideState service API.
    * Added cmdlet Get-CCRepositoriesForApprovalRuleTemplateList leveraging the ListRepositoriesForApprovalRuleTemplate service API.
    * Added cmdlet Invoke-CCPullRequestApprovalRule leveraging the EvaluatePullRequestApprovalRules service API.
    * Added cmdlet New-CCApprovalRuleTemplate leveraging the CreateApprovalRuleTemplate service API.
    * Added cmdlet New-CCPullRequestApprovalRule leveraging the CreatePullRequestApprovalRule service API.
    * Added cmdlet Remove-CCApprovalRuleTemplate leveraging the DeleteApprovalRuleTemplate service API.
    * Added cmdlet Remove-CCApprovalRuleTemplateFromRepository leveraging the DisassociateApprovalRuleTemplateFromRepository service API.
    * Added cmdlet Remove-CCApprovalRuleTemplateFromRepositoryBatch leveraging the BatchDisassociateApprovalRuleTemplateFromRepositories service API.
    * Added cmdlet Remove-CCPullRequestApprovalRule leveraging the DeletePullRequestApprovalRule service API.
    * Added cmdlet Skip-CCPullRequestApprovalRule leveraging the OverridePullRequestApprovalRules service API.
    * Added cmdlet Update-CCApprovalRuleTemplateContent leveraging the UpdateApprovalRuleTemplateContent service API.
    * Added cmdlet Update-CCApprovalRuleTemplateDescription leveraging the UpdateApprovalRuleTemplateDescription service API.
    * Added cmdlet Update-CCApprovalRuleTemplateName leveraging the UpdateApprovalRuleTemplateName service API.
    * Added cmdlet Update-CCPullRequestApprovalRuleContent leveraging the UpdatePullRequestApprovalRuleContent service API.
    * Added cmdlet Update-CCPullRequestApprovalState leveraging the UpdatePullRequestApprovalState service API.
  * Amazon CodePipeline
    * Modified cmdlet Write-CPJobSuccessResult: added parameter OutputVariable.
  * Amazon CodeStar Notifications. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CSTN and can be listed using the command 'Get-AWSCmdletName -Service CSTN'. You can now configure rules and receive notifications about events that occur for resources. Each notification includes a status message as well as a link to the resource (repository, build project, deployment application, or pipeline) whose event generated the notification.
  * Amazon Cognito Identity
    * Modified cmdlet New-CGIIdentityPool: added parameter AllowClassicFlow.
    * Modified cmdlet Update-CGIIdentityPool: added parameter AllowClassicFlow.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameters EmailConfiguration_ConfigurationSet and EmailConfiguration_From.
    * Modified cmdlet New-CGIPUserPoolClient: added parameter PreventUserExistenceError.
    * Modified cmdlet Update-CGIPUserPool: added parameters EmailConfiguration_ConfigurationSet and EmailConfiguration_From.
    * Modified cmdlet Update-CGIPUserPoolClient: added parameter PreventUserExistenceError.
  * Amazon Config
    * Added cmdlet Get-CFGConformancePack leveraging the DescribeConformancePacks service API.
    * Added cmdlet Get-CFGConformancePackCompliance leveraging the DescribeConformancePackCompliance service API.
    * Added cmdlet Get-CFGConformancePackComplianceDetail leveraging the GetConformancePackComplianceDetails service API.
    * Added cmdlet Get-CFGConformancePackComplianceSummary leveraging the GetConformancePackComplianceSummary service API.
    * Added cmdlet Get-CFGConformancePackStatus leveraging the DescribeConformancePackStatus service API.
    * Added cmdlet Get-CFGOrganizationConformancePack leveraging the DescribeOrganizationConformancePacks service API.
    * Added cmdlet Get-CFGOrganizationConformancePackDetailedStatus leveraging the GetOrganizationConformancePackDetailedStatus service API.
    * Added cmdlet Get-CFGOrganizationConformancePackStatus leveraging the DescribeOrganizationConformancePackStatuses service API.
    * Added cmdlet Remove-CFGConformancePack leveraging the DeleteConformancePack service API.
    * Added cmdlet Remove-CFGOrganizationConformancePack leveraging the DeleteOrganizationConformancePack service API.
    * Added cmdlet Remove-CFGResourceConfig leveraging the DeleteResourceConfig service API.
    * Added cmdlet Write-CFGConformancePack leveraging the PutConformancePack service API.
    * Added cmdlet Write-CFGOrganizationConformancePack leveraging the PutOrganizationConformancePack service API.
    * Added cmdlet Write-CFGResourceConfig leveraging the PutResourceConfig service API.
  * Amazon Connect Participant Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CONNP and can be listed using the command 'Get-AWSCmdletName -Service CONNP'. You can use them to programmatically perform participant actions on the configured Amazon Connect instance.
  * Amazon Connect Service
    * Added cmdlet Add-CONNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CONNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CONNResourceTag leveraging the UntagResource service API.
    * Added cmdlet Start-CONNChatContact leveraging the StartChatContact service API.
    * Modified cmdlet New-CONNUser: added parameter Tag.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostAndUsageWithResource leveraging the GetCostAndUsageWithResources service API.
    * Added cmdlet Get-CESavingsPlansCoverage leveraging the GetSavingsPlansCoverage service API.
    * Added cmdlet Get-CESavingsPlansPurchaseRecommendation leveraging the GetSavingsPlansPurchaseRecommendation service API.
    * Added cmdlet Get-CESavingsPlansUtilization leveraging the GetSavingsPlansUtilization service API.
    * Added cmdlet Get-CESavingsPlansUtilizationDetail leveraging the GetSavingsPlansUtilizationDetails service API.
  * Amazon Data Exchange. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DTEX and can be listed using the command 'Get-AWSCmdletName -Service DTEX'. AWS Data Exchange is a service that makes it easy for AWS customers to securely create, manage, access, and exchange data sets in the cloud.
  * Amazon Data Lifecycle Manager
    * Added cmdlet Add-DLMResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-DLMResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-DLMResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-DLMLifecyclePolicy: added parameter Tag.
  * Amazon DataSync
    * Modified cmdlet New-DSYNTask: added parameter Schedule_ScheduleExpression.
    * Modified cmdlet Update-DSYNTask: added parameter Schedule_ScheduleExpression.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBTableReplicaAutoScaling leveraging the DescribeTableReplicaAutoScaling service API.
    * Added cmdlet Update-DDBTableReplicaAutoScaling leveraging the UpdateTableReplicaAutoScaling service API.
    * Modified cmdlet Restore-DDBTableFromBackup: added parameters BillingModeOverride, GlobalSecondaryIndexOverride, LocalSecondaryIndexOverride, ProvisionedThroughputOverride_ReadCapacityUnit and ProvisionedThroughputOverride_WriteCapacityUnit.
    * Modified cmdlet Restore-DDBTableToPointInTime: added parameters BillingModeOverride, GlobalSecondaryIndexOverride, LocalSecondaryIndexOverride, ProvisionedThroughputOverride_ReadCapacityUnit and ProvisionedThroughputOverride_WriteCapacityUnit.
    * Modified cmdlet Update-DDBTable: added parameter ReplicaUpdate.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSTask: added parameters Overrides_Cpu, Overrides_Memory and ReferenceId.
    * Modified cmdlet Start-ECSTask: added parameters Overrides_Cpu, Overrides_Memory and ReferenceId.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2FastSnapshotRestore leveraging the DisableFastSnapshotRestores service API.
    * Added cmdlet Edit-EC2InstanceMetadataOption leveraging the ModifyInstanceMetadataOptions service API.
    * Added cmdlet Enable-EC2FastSnapshotRestore leveraging the EnableFastSnapshotRestores service API.
    * Added cmdlet Get-EC2FastSnapshotRestore leveraging the DescribeFastSnapshotRestores service API.
    * Added cmdlet Get-EC2InstanceType leveraging the DescribeInstanceTypes service API.
    * Added cmdlet Get-EC2InstanceTypeOffering leveraging the DescribeInstanceTypeOfferings service API.
    * Modified cmdlet New-EC2Instance: added parameters MetadataOptions_HttpEndpoint, MetadataOptions_HttpPutResponseHopLimit and MetadataOptions_HttpToken.
    * Modified cmdlet Copy-EC2Snapshot: added parameter TagSpecification.
    * Modified cmdlet Edit-EC2Host: added parameters InstanceFamily and InstanceType.
    * Modified cmdlet Import-EC2Image: added parameter LicenseSpecification.
    * Modified cmdlet New-EC2CustomerGateway: added parameter DeviceName.
    * Modified cmdlet New-EC2Host: added parameter InstanceFamily.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSNodegroup leveraging the DescribeNodegroup service API.
    * Added cmdlet Get-EKSNodegroupList leveraging the ListNodegroups service API.
    * Added cmdlet New-EKSNodegroup leveraging the CreateNodegroup service API.
    * Added cmdlet Remove-EKSNodegroup leveraging the DeleteNodegroup service API.
    * Added cmdlet Update-EKSNodegroupConfig leveraging the UpdateNodegroupConfig service API.
    * Added cmdlet Update-EKSNodegroupVersion leveraging the UpdateNodegroupVersion service API.
    * Modified cmdlet Get-EKSUpdate: added parameter NodegroupName.
    * Modified cmdlet Get-EKSUpdateList: added parameter NodegroupName.
  * Amazon Elastic MapReduce
    * Added cmdlet Edit-EMRCluster leveraging the ModifyCluster service API.
    * Modified cmdlet Start-EMRJobFlow: added parameter StepConcurrencyLevel.
    * Modified cmdlet Stop-EMRStep: added parameter StepCancellationOption.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECCacheCluster: added parameters AuthToken and AuthTokenUpdateStrategy.
    * Modified cmdlet Edit-ECReplicationGroup: added parameters AuthToken and AuthTokenUpdateStrategy.
  * Amazon Forecast Service
    * Modified cmdlet New-FRCForecast: added parameter ForecastType.
  * Amazon Glue
    * Modified cmdlet Get-GLUEMLTransformList: added parameter Filter_GlueVersion.
    * Modified cmdlet New-GLUEMLTransform: added parameter GlueVersion.
    * Modified cmdlet Update-GLUEMLTransform: added parameter GlueVersion.
  * Amazon GuardDuty
    * Added cmdlet Get-GDPublishingDestination leveraging the DescribePublishingDestination service API.
    * Added cmdlet Get-GDPublishingDestinationList leveraging the ListPublishingDestinations service API.
    * Added cmdlet New-GDPublishingDestination leveraging the CreatePublishingDestination service API.
    * Added cmdlet Remove-GDPublishingDestination leveraging the DeletePublishingDestination service API.
    * Added cmdlet Update-GDPublishingDestination leveraging the UpdatePublishingDestination service API.
  * Amazon IoT
    * Added cmdlet Confirm-IOTTopicRuleDestination leveraging the ConfirmTopicRuleDestination service API.
    * Added cmdlet Get-IOTCardinality leveraging the GetCardinality service API.
    * Added cmdlet Get-IOTPercentile leveraging the GetPercentiles service API.
    * Added cmdlet Get-IOTTopicRuleDestination leveraging the GetTopicRuleDestination service API.
    * Added cmdlet Get-IOTTopicRuleDestinationList leveraging the ListTopicRuleDestinations service API.
    * Added cmdlet New-IOTTopicRuleDestination leveraging the CreateTopicRuleDestination service API.
    * Added cmdlet Remove-IOTTopicRuleDestination leveraging the DeleteTopicRuleDestination service API.
    * Added cmdlet Update-IOTTopicRuleDestination leveraging the UpdateTopicRuleDestination service API.
    * Modified cmdlet New-IOTTopicRule: added parameters Http_ConfirmationUrl, Http_Header, Http_Url, Sigv4_RoleArn, Sigv4_ServiceName and Sigv4_SigningRegion.
    * Modified cmdlet Set-IOTTopicRule: added parameters Http_ConfirmationUrl, Http_Header, Http_Url, Sigv4_RoleArn, Sigv4_ServiceName and Sigv4_SigningRegion.
    * Modified cmdlet Update-IOTIndexingConfiguration: added parameters ThingGroupIndexingConfiguration_CustomField, ThingGroupIndexingConfiguration_ManagedField, ThingIndexingConfiguration_CustomField and ThingIndexingConfiguration_ManagedField.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters DeliveryStreamEncryptionConfigurationInput_KeyARN and DeliveryStreamEncryptionConfigurationInput_KeyType.
    * Modified cmdlet Remove-KINFDeliveryStream: added parameter AllowForceDelete.
    * Modified cmdlet Start-KINFDeliveryStreamEncryption: added parameters DeliveryStreamEncryptionConfigurationInput_KeyARN and DeliveryStreamEncryptionConfigurationInput_KeyType.
  * Amazon Lambda
    * Modified cmdlet Publish-LMFunction: added parameter Environment_IsVariablesSet.
    * Modified cmdlet Update-LMFunctionConfiguration: added parameter Environment_IsVariablesSet.
  * Amazon Lex Model Building Service
    * Modified cmdlet Write-LMBBot: added parameter DetectSentiment.
  * Amazon Marketplace Catalog Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MCAT and can be listed using the command 'Get-AWSCmdletName -Service MCAT'. AWS Marketplace Catalog service allows you to list, describe and manage change requests on your published entities on AWS Marketplace.
  * Amazon Migration Hub
    * Modified cmdlet Send-MHApplicationStateNotification: added parameter UpdateDateTime.
  * Amazon Migration Hub Config. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MHC and can be listed using the command 'Get-AWSCmdletName -Service MHC'. AWS Migration Hub Config Service allows you to get and set the Migration Hub home region for use with AWS Migration Hub and Application Discovery Service.
  * Amazon Personalize
    * Added cmdlet Get-PERSBatchInferenceJob leveraging the DescribeBatchInferenceJob service API.
    * Added cmdlet Get-PERSBatchInferenceJobList leveraging the ListBatchInferenceJobs service API.
    * Added cmdlet New-PERSBatchInferenceJob leveraging the CreateBatchInferenceJob service API.
  * Amazon Pinpoint
    * Added cmdlet Get-PINJourney leveraging the GetJourney service API.
    * Added cmdlet Get-PINJourneyDateRangeKpi leveraging the GetJourneyDateRangeKpi service API.
    * Added cmdlet Get-PINJourneyExecutionActivityMetric leveraging the GetJourneyExecutionActivityMetrics service API.
    * Added cmdlet Get-PINJourneyExecutionMetric leveraging the GetJourneyExecutionMetrics service API.
    * Added cmdlet Get-PINJourneyList leveraging the ListJourneys service API.
    * Added cmdlet Get-PINVoiceTemplate leveraging the GetVoiceTemplate service API.
    * Added cmdlet New-PINJourney leveraging the CreateJourney service API.
    * Added cmdlet New-PINVoiceTemplate leveraging the CreateVoiceTemplate service API.
    * Added cmdlet Remove-PINJourney leveraging the DeleteJourney service API.
    * Added cmdlet Remove-PINVoiceTemplate leveraging the DeleteVoiceTemplate service API.
    * Added cmdlet Update-PINJourney leveraging the UpdateJourney service API.
    * Added cmdlet Update-PINJourneyState leveraging the UpdateJourneyState service API.
    * Added cmdlet Update-PINVoiceTemplate leveraging the UpdateVoiceTemplate service API.
    * Modified cmdlet New-PINCampaign: added parameter VoiceTemplate_Name.
    * Modified cmdlet New-PINEmailTemplate: added parameters EmailTemplateRequest_DefaultSubstitution and EmailTemplateRequest_TemplateDescription.
    * Modified cmdlet New-PINPushTemplate: added parameters ADM_RawContent, APNS_RawContent, Baidu_RawContent, GCM_RawContent, PushNotificationTemplateRequest_DefaultSubstitution and PushNotificationTemplateRequest_TemplateDescription.
    * Modified cmdlet New-PINSmsTemplate: added parameters SMSTemplateRequest_DefaultSubstitution and SMSTemplateRequest_TemplateDescription.
    * Modified cmdlet Send-PINMessage: added parameters APNSMessage_APNSPushType and VoiceTemplate_Name.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters APNSMessage_APNSPushType and VoiceTemplate_Name.
    * Modified cmdlet Update-PINCampaign: added parameter VoiceTemplate_Name.
    * Modified cmdlet Update-PINEmailTemplate: added parameters EmailTemplateRequest_DefaultSubstitution and EmailTemplateRequest_TemplateDescription.
    * Modified cmdlet Update-PINPushTemplate: added parameters ADM_RawContent, APNS_RawContent, Baidu_RawContent, GCM_RawContent, PushNotificationTemplateRequest_DefaultSubstitution and PushNotificationTemplateRequest_TemplateDescription.
    * Modified cmdlet Update-PINSmsTemplate: added parameters SMSTemplateRequest_DefaultSubstitution and SMSTemplateRequest_TemplateDescription.
  * Amazon QuickSight
    * Added cmdlet Add-QSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-QSDashboard leveraging the DescribeDashboard service API.
    * Added cmdlet Get-QSDashboardList leveraging the ListDashboards service API.
    * Added cmdlet Get-QSDashboardPermission leveraging the DescribeDashboardPermissions service API.
    * Added cmdlet Get-QSDashboardVersionList leveraging the ListDashboardVersions service API.
    * Added cmdlet Get-QSDataSet leveraging the DescribeDataSet service API.
    * Added cmdlet Get-QSDataSetList leveraging the ListDataSets service API.
    * Added cmdlet Get-QSDataSetPermission leveraging the DescribeDataSetPermissions service API.
    * Added cmdlet Get-QSDataSource leveraging the DescribeDataSource service API.
    * Added cmdlet Get-QSDataSourceList leveraging the ListDataSources service API.
    * Added cmdlet Get-QSDataSourcePermission leveraging the DescribeDataSourcePermissions service API.
    * Added cmdlet Get-QSIAMPolicyAssignment leveraging the DescribeIAMPolicyAssignment service API.
    * Added cmdlet Get-QSIAMPolicyAssignmentList leveraging the ListIAMPolicyAssignments service API.
    * Added cmdlet Get-QSIAMPolicyAssignmentsForUserList leveraging the ListIAMPolicyAssignmentsForUser service API.
    * Added cmdlet Get-QSIngestion leveraging the DescribeIngestion service API.
    * Added cmdlet Get-QSIngestionList leveraging the ListIngestions service API.
    * Added cmdlet Get-QSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-QSTemplate leveraging the DescribeTemplate service API.
    * Added cmdlet Get-QSTemplateAlias leveraging the DescribeTemplateAlias service API.
    * Added cmdlet Get-QSTemplateAliasList leveraging the ListTemplateAliases service API.
    * Added cmdlet Get-QSTemplateList leveraging the ListTemplates service API.
    * Added cmdlet Get-QSTemplatePermission leveraging the DescribeTemplatePermissions service API.
    * Added cmdlet Get-QSTemplateVersionList leveraging the ListTemplateVersions service API.
    * Added cmdlet New-QSDashboard leveraging the CreateDashboard service API.
    * Added cmdlet New-QSDataSet leveraging the CreateDataSet service API.
    * Added cmdlet New-QSDataSource leveraging the CreateDataSource service API.
    * Added cmdlet New-QSIAMPolicyAssignment leveraging the CreateIAMPolicyAssignment service API.
    * Added cmdlet New-QSIngestion leveraging the CreateIngestion service API.
    * Added cmdlet New-QSTemplate leveraging the CreateTemplate service API.
    * Added cmdlet New-QSTemplateAlias leveraging the CreateTemplateAlias service API.
    * Added cmdlet Remove-QSDashboard leveraging the DeleteDashboard service API.
    * Added cmdlet Remove-QSDataSet leveraging the DeleteDataSet service API.
    * Added cmdlet Remove-QSDataSource leveraging the DeleteDataSource service API.
    * Added cmdlet Remove-QSIAMPolicyAssignment leveraging the DeleteIAMPolicyAssignment service API.
    * Added cmdlet Remove-QSResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-QSTemplate leveraging the DeleteTemplate service API.
    * Added cmdlet Remove-QSTemplateAlias leveraging the DeleteTemplateAlias service API.
    * Added cmdlet Stop-QSIngestion leveraging the CancelIngestion service API.
    * Added cmdlet Update-QSDashboard leveraging the UpdateDashboard service API.
    * Added cmdlet Update-QSDashboardPermission leveraging the UpdateDashboardPermissions service API.
    * Added cmdlet Update-QSDashboardPublishedVersion leveraging the UpdateDashboardPublishedVersion service API.
    * Added cmdlet Update-QSDataSet leveraging the UpdateDataSet service API.
    * Added cmdlet Update-QSDataSetPermission leveraging the UpdateDataSetPermissions service API.
    * Added cmdlet Update-QSDataSource leveraging the UpdateDataSource service API.
    * Added cmdlet Update-QSDataSourcePermission leveraging the UpdateDataSourcePermissions service API.
    * Added cmdlet Update-QSIAMPolicyAssignment leveraging the UpdateIAMPolicyAssignment service API.
    * Added cmdlet Update-QSTemplate leveraging the UpdateTemplate service API.
    * Added cmdlet Update-QSTemplateAlias leveraging the UpdateTemplateAlias service API.
    * Added cmdlet Update-QSTemplatePermission leveraging the UpdateTemplatePermissions service API.
  * Amazon Rekognition
    * Modified cmdlet Compare-REKFace: added parameter QualityFilter.
    * Modified cmdlet Search-REKFacesByImage: added parameter QualityFilter.
  * Amazon Savings Plans. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SP and can be listed using the command 'Get-AWSCmdletName -Service SP'. Savings Plans is a new flexible pricing model that offers low prices on Amazon EC2 and AWS Fargate usage.
  * Amazon Security Token Service
    * Modified cmdlet Get-STSFederationToken: added parameter Tag.
    * Modified cmdlet Use-STSRole: added parameters Tag and TransitiveTagKey.
  * Amazon Simple Email Service V2 (SES V2). Added cmdlets to support the service. Cmdlets for the service have the noun prefix SES2 and can be listed using the command 'Get-AWSCmdletName -Service SES2'. You can use this API to configure your Amazon SES account, and to send email. This API extends the functionality that exists in the previous version of the Amazon SES API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlets adding parameter ForcePathStyleAddressing.
  * Amazon Single Sign-On. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSO and can be listed using the command 'Get-AWSCmdletName -Service SSO'. This release adds support for accessing AWS accounts assigned in AWS SSO using short term credentials.
  * Amazon Single Sign-On OIDC. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSOOIDC and can be listed using the command 'Get-AWSCmdletName -Service SSOOIDC'. This is an initial release of AWS Single Sign-On OAuth device code authorization service.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGAvailabilityMonitorTest leveraging the DescribeAvailabilityMonitorTest service API.
    * Added cmdlet Start-SGAvailabilityMonitorTest leveraging the StartAvailabilityMonitorTest service API.
    * Modified cmdlet Join-SGDomain: added parameter TimeoutInSecond.
  * Amazon Systems Manager
    * Added cmdlet Update-SSMResourceDataSync leveraging the UpdateResourceDataSync service API.
    * Modified cmdlet Get-SSMOpsSummary: added parameters ResultAttribute and SyncName.
    * Modified cmdlet Get-SSMResourceDataSync: added parameters PassThru and SyncType.
    * Modified cmdlet New-SSMOpsItem: added parameters Category and Severity.
    * Modified cmdlet New-SSMResourceDataSync: added parameters AwsOrganizationsSource_OrganizationalUnit, AwsOrganizationsSource_OrganizationSourceType, SyncSource_IncludeFutureRegion, SyncSource_SourceRegion, SyncSource_SourceType and SyncType.
    * Modified cmdlet Remove-SSMResourceDataSync: added parameter SyncType.
    * Modified cmdlet Update-SSMOpsItem: added parameters Category and Severity.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSTranscriptionJob: added parameters Settings_MaxAlternative and Settings_ShowAlternative.
  * Amazon WorkSpaces
    * Added cmdlet Edit-WKSSelfservicePermission leveraging the ModifySelfservicePermissions service API.
    * Added cmdlet Edit-WKSWorkspaceAccessProperty leveraging the ModifyWorkspaceAccessProperties service API.
    * Added cmdlet Edit-WKSWorkspaceCreationProperty leveraging the ModifyWorkspaceCreationProperties service API.
    * Added cmdlet Register-WKSWorkspaceDirectory leveraging the RegisterWorkspaceDirectory service API.
    * Added cmdlet Unregister-WKSWorkspaceDirectory leveraging the DeregisterWorkspaceDirectory service API.
    * Modified cmdlet Get-WKSWorkspaceDirectory: added parameter Limit.

### 4.0.0.0 (2019-11-21)
  * Version 4.0 is highly backwards compatible with version 3.3 of AWS Tools for PowerShell and, in most scenarios, you can expect a seamless upgrade. As a good practice we always recommend thorough testing before upgrading production environments.
  * A detailed list of changes included in version 4.0 of AWS Tools for PowerShell is available in [our announcment](https://github.com/aws/aws-tools-for-powershell/issues/67).
  * AWS.Tools modules
    * [AWS.Tools](https://www.powershellgallery.com/packages/AWS.Tools.Common) modules are now available for production use. AWS.Tools is the new modular variant of AWS Tools for PowerShell, which is preferred for most use cases. It has the same capabilities as AWSPowerShell and AWSPowerShell.NetCore and is compatible with all modern platforms: Windows PowerShell 5.1 (when .NET Framework 4.7.2 is installed) and PowerShell Core 6.0-6.2 on Windows, Linux and macOS. AWS.Tools has a modular architecture with a separate PowerShell module for each service. You can reduce download time, import time and memory usage by only installing modules your application requires.
    * The [AWS.Tools.Installer](https://www.powershellgallery.com/packages/AWS.Tools.Installer) module can be used to simplify installing, updating and removing the _AWS.Tools_ modules. New versions of all the modules are released together with the same version number, different versions of the AWS.Tools modules cannot be imported at the same time. Running, for example, `Install-AWSToolsModule AWS.Tools.EC2,AWS.Tools.S3 -CleanUp` will install the latest versions of the EC2 and S3 modules, sync existing modules to the current version and remove older versions.
    * The new AWS.Tools modules now declare and enforce mandatory cmdlet parameters. When an AWS Service declares that an API parameter is required, PowerShell will prompt you for the missing corresponding cmdlet parameter. For backward compatibility reasons we did not extend this feature to the AWSPowerShell.NetCore or AWSPowerShell modules.
    * [Breaking Change] AWS Tools for PowerShell support auto-pagination. Cmdlets like `Get-S3Object` will internally use, if necessary, multiple service calls in order to retrieve all the values. In AWSPowerShell.NetCore and AWSPowerShell the `-MaxItems` parameter allows to limit the number of items returned by some cmdlets. This behavior is now considered obsolete and is not available in AWS.Tools. You can instead pipe the output of the cmdlet into `| select -first $n`. Leveraging the new `-Select` parameter and this simplified pagination approach, we were able to enable auto-pagination in AWS.Tools for an additional 70 cmdlets that require manual pagination in AWSPowerShell.NetCore and AWSPowerShell.
    * AWS.Tools doesn’t include [undocumented type extension](https://www.powershellgallery.com/packages/AWSPowerShell/3.3.618.0/Content/AWSPowerShell.TypeExtensions.ps1xml) which are available in AWSPowerShell and AWSPowerShell.NetCore. These type extensions provide aliases for fields of .NET objects, mostly related to the EC2 service.
  * AWS.Tools, AWSPowerShell.NetCore and AWSPowerShell modules
    * Added cmdlet Get-AWSService to improve discoverability of supported AWS services and the corresponding AWS.Tools module names.
    * Most cmdlets have a new parameter: `-Select`. Select can be used to change the value returned by the cmdlet. For example the [service API](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/index.html?page=S3/MS3ListObjectsListObjectsRequest.html) used by `Get-S3Object` returns a [ListObjectsResponse](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/index.html?page=S3/TListObjectsResponse.html&tocid=Amazon_S3_Model_ListObjectsResponse) object but the cmdlet is configured to return only the `S3Objects` field. Now you can specify `-Select *` to receive the full API response. You can also specify the path to a nested result property like `-Select S3Objects.Key`. In certain situations it may be useful to return a cmdlet parameter, this can be achieved with `-Select ^ParameterName`.
    * Parameters of type `Stream` or `byte[]` can now accept `string`, `string[]` or `FileInfo` values. All strings are converted to `byte[]` using UTF8 encoding.
    * In order to provide a consistent user experience pipeline input by Property Name is now enabled for all parameters.
    * [Breaking Change] In previous versions of AWS Tools for PowerShell, common parameters (`AccessKey`, `SecretKey`, `ProfileName`, `Region`, etc.) used to be [dynamic](https://docs.microsoft.com/en-us/dotnet/api/system.management.automation.idynamicparameters) while all other parameters were static. This could create problems because PowerShell binds static parameters before dynamic ones. For example, when calling `Get-EC2Region -Region us-west-2`, PowerShell used to bind `us-west-2` to the `-RegionName` static parameter instead of the `-Region` dynamic parameter. In order to improve consistency in version 4.0 of AWS Tools for PowerShell all parameters are static. This may have an effect on the behavior of scripts if they are using:
      * `AccessKey` parameter of `Remove-IAMAccessKey`, `Get-IAMAccessKeyLastUsed` and Update-IAMAccessKey
      * `Credential` parameter of `New-AG2Integration`, `Update-AG2Integration``, `New-IOTRoleAlias` and `Update-IOTRoleAlias`
      * `Region` parameter of `New-AGDomainName`, `Get-DDBGlobalTableList`, `Get-EC2Region`, `Get-RDSSourceRegion` and `Update-R53HealthCheck`.
    * [Breaking Change] Removed the deprecated `-ProfileName` parameter from the `Clear-AWSCredential` cmdlet. Use `Remove-AWSCredentialProfile` instead.
    * Amazon Elastic Compute Cloud (EC2)
      * [Breaking Change] Removed the deprecated `-Terminate` parameter from the `Stop-EC2Instance` cmdlet. Use `Remove-EC2Instance` instead.
      * [Breaking Change] Removed deprecated cmdlets `Import-EC2Instance` and `Import-EC2Volume` from the AWSPowerShell module.
      * Modified cmdlet `Import-EC2KeyPair` to automatically perform Base64 encoding of the key when using the new parameter PublicKey.
    * Amazon Systems Manager
      * Added cmdlet `Get-SSMLatestEC2Image` replacing the functionality of `Get-EC2ImageByName` which is now marked as obsolete.

### 3.3.618.1 (2019-11-18)
  * This is a minor update to AWS.Tools only, the following changes don't apply to AWSPowerShell and AWSPowerShell.NetCore.
  * Released an updated preview of [AWS.Tools.Installer](https://www.powershellgallery.com/packages/AWS.Tools.Installer) which makes it easier to install, update and uninstall other AWS.Tools modules. You can use a single command like `Install-AWSToolsModule AWS.Tools.EC2,AWS.Tools.S3` to install multiple modules. You can also update all your installed AWS.Tools modules and remove old versions by running `Update-AWSToolsModule -CleanUp`.
  * Fixed behavior of `Get-AWSPowerShellVersion -ListServiceVersionInfo` and Get-AWSCmdletName: the cmdlets now report services and cmdlets also for modules that are not imported.
  * Added cmdlet Get-AWSService to improve discoverability of supported AWS services and the corresponding AWS.Tools module names.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Import-EC2KeyPair to automatically perform Base64 encoding of the key when using the new parameter PublicKey.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMLatestEC2Image replacing the functionality of Get-EC2ImageByName which is now marked as obsolete.

### 3.3.618.0 (2019-11-04)
  * The modular version of AWS Tools for PowerShell (AWS.Tools) includes a preview of the upcoming changes from AWS Tools for Powershell v4. You can find detailed information in the [GitHub announcement](https://github.com/aws/aws-tools-for-powershell/issues/61).
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.618.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHRoute: added parameters Match_Metadata, Match_ServiceName, RetryPolicy_GrpcRetryEvent, Spec_GrpcRoute_Action_WeightedTarget, Spec_GrpcRoute_Match_MethodName, Spec_GrpcRoute_RetryPolicy_HttpRetryEvent, Spec_GrpcRoute_RetryPolicy_MaxRetry, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value, Spec_GrpcRoute_RetryPolicy_TcpRetryEvent, Spec_Http2Route_Action_WeightedTarget, Spec_Http2Route_Match_Header, Spec_Http2Route_Match_Method, Spec_Http2Route_Match_Prefix, Spec_Http2Route_Match_Scheme, Spec_Http2Route_RetryPolicy_HttpRetryEvent, Spec_Http2Route_RetryPolicy_MaxRetry, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value, Spec_Http2Route_RetryPolicy_TcpRetryEvent, Spec_HttpRoute_Match_Header, Spec_HttpRoute_Match_Method, Spec_HttpRoute_Match_Prefix, Spec_HttpRoute_Match_Scheme, Spec_HttpRoute_RetryPolicy_HttpRetryEvent, Spec_HttpRoute_RetryPolicy_MaxRetry, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value and Spec_HttpRoute_RetryPolicy_TcpRetryEvent.
    * Modified cmdlet Update-AMSHRoute: added parameters Match_Metadata, Match_ServiceName, RetryPolicy_GrpcRetryEvent, Spec_GrpcRoute_Action_WeightedTarget, Spec_GrpcRoute_Match_MethodName, Spec_GrpcRoute_RetryPolicy_HttpRetryEvent, Spec_GrpcRoute_RetryPolicy_MaxRetry, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value, Spec_GrpcRoute_RetryPolicy_TcpRetryEvent, Spec_Http2Route_Action_WeightedTarget, Spec_Http2Route_Match_Header, Spec_Http2Route_Match_Method, Spec_Http2Route_Match_Prefix, Spec_Http2Route_Match_Scheme, Spec_Http2Route_RetryPolicy_HttpRetryEvent, Spec_Http2Route_RetryPolicy_MaxRetry, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value, Spec_Http2Route_RetryPolicy_TcpRetryEvent, Spec_HttpRoute_Match_Header, Spec_HttpRoute_Match_Method, Spec_HttpRoute_Match_Prefix, Spec_HttpRoute_Match_Scheme, Spec_HttpRoute_RetryPolicy_HttpRetryEvent, Spec_HttpRoute_RetryPolicy_MaxRetry, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value and Spec_HttpRoute_RetryPolicy_TcpRetryEvent.
  * Amazon AppStream
    * Modified cmdlet New-APSStack: added parameter EmbedHostDomain.
    * Modified cmdlet Update-APSStack: added parameter EmbedHostDomain.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter ComputeResources_AllocationStrategy.
  * Amazon Chime
    * Added cmdlet Add-CHMPhoneNumbersToVoiceConnectorGroup leveraging the AssociatePhoneNumbersWithVoiceConnectorGroup service API.
    * Added cmdlet Get-CHMPhoneNumberSetting leveraging the GetPhoneNumberSettings service API.
    * Added cmdlet Get-CHMVoiceConnectorGroup leveraging the GetVoiceConnectorGroup service API.
    * Added cmdlet Get-CHMVoiceConnectorGroupList leveraging the ListVoiceConnectorGroups service API.
    * Added cmdlet Get-CHMVoiceConnectorLoggingConfiguration leveraging the GetVoiceConnectorLoggingConfiguration service API.
    * Added cmdlet Get-CHMVoiceConnectorStreamingConfiguration leveraging the GetVoiceConnectorStreamingConfiguration service API.
    * Added cmdlet New-CHMVoiceConnectorGroup leveraging the CreateVoiceConnectorGroup service API.
    * Added cmdlet Remove-CHMPhoneNumbersFromVoiceConnectorGroup leveraging the DisassociatePhoneNumbersFromVoiceConnectorGroup service API.
    * Added cmdlet Remove-CHMVoiceConnectorGroup leveraging the DeleteVoiceConnectorGroup service API.
    * Added cmdlet Remove-CHMVoiceConnectorStreamingConfiguration leveraging the DeleteVoiceConnectorStreamingConfiguration service API.
    * Added cmdlet Update-CHMPhoneNumberSetting leveraging the UpdatePhoneNumberSettings service API.
    * Added cmdlet Update-CHMVoiceConnectorGroup leveraging the UpdateVoiceConnectorGroup service API.
    * Added cmdlet Write-CHMVoiceConnectorLoggingConfiguration leveraging the PutVoiceConnectorLoggingConfiguration service API.
    * Added cmdlet Write-CHMVoiceConnectorStreamingConfiguration leveraging the PutVoiceConnectorStreamingConfiguration service API.
    * Modified cmdlet Add-CHMPhoneNumbersToVoiceConnector: added parameter ForceAssociate.
    * Modified cmdlet New-CHMVoiceConnector: added parameter AwsRegion.
    * Modified cmdlet Update-CHMPhoneNumber: added parameter CallingName.
  * Amazon Connect Service
    * Added cmdlet Get-CONNContactFlowList leveraging the ListContactFlows service API.
    * Added cmdlet Get-CONNHoursOfOperationList leveraging the ListHoursOfOperations service API.
    * Added cmdlet Get-CONNPhoneNumberList leveraging the ListPhoneNumbers service API.
    * Added cmdlet Get-CONNQueueList leveraging the ListQueues service API.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRImageScanFinding leveraging the DescribeImageScanFindings service API.
    * Added cmdlet Start-ECRImageScan leveraging the StartImageScan service API.
    * Added cmdlet Write-ECRImageScanningConfiguration leveraging the PutImageScanningConfiguration service API.
    * Modified cmdlet New-ECRRepository: added parameter ImageScanningConfiguration_ScanOnPush.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2FpgaImage: added parameter TagSpecification.
  * Amazon ElastiCache
    * Added cmdlet Complete-ECMigration leveraging the CompleteMigration service API.
    * Added cmdlet Start-ECMigration leveraging the StartMigration service API.
  * Amazon IoT Events
    * Modified cmdlet New-IOTEDetectorModel: added parameter EvaluationMethod.
    * Modified cmdlet Update-IOTEDetectorModel: added parameter EvaluationMethod.
  * Amazon Lex
    * Modified cmdlet Get-LEXSession: added parameter CheckpointLabelFilter.
    * Modified cmdlet Write-LEXSession: added parameter RecentIntentSummaryView.
  * Amazon Managed Streaming for Kafka
    * Added cmdlet Update-MSKBrokerCount leveraging the UpdateBrokerCount service API.
  * Amazon OpsWorksCM
    * Modified cmdlet New-OWCMServer: added parameters CustomCertificate, CustomDomain and CustomPrivateKey.
  * Amazon Personalize
    * Modified cmdlet New-PERSSolutionVersion: added parameter TrainingMode.
  * Amazon Relational Database Service
    * Added cmdlet Get-RDSCustomAvailabilityZone leveraging the DescribeCustomAvailabilityZones service API.
    * Added cmdlet Get-RDSInstallationMedia leveraging the DescribeInstallationMedia service API.
    * Added cmdlet Import-RDSInstallationMedia leveraging the ImportInstallationMedia service API.
    * Added cmdlet New-RDSCustomAvailabilityZone leveraging the CreateCustomAvailabilityZone service API.
    * Added cmdlet Remove-RDSCustomAvailabilityZone leveraging the DeleteCustomAvailabilityZone service API.
    * Added cmdlet Remove-RDSInstallationMedia leveraging the DeleteInstallationMedia service API.
  * Amazon Simple Storage Service
    * Modified cmdlet Select-S3ObjectContent: added parameters ScanRange_End and ScanRange_Start.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRUser: added parameters HomeDirectoryMapping and HomeDirectoryType.
    * Modified cmdlet Update-TFRUser: added parameters HomeDirectoryMapping and HomeDirectoryType.

### 3.3.604.0 (2019-10-11)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.604.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Amplify
    * Added cmdlet Get-AMPArtifactList leveraging the ListArtifacts service API.
    * Added cmdlet Get-AMPArtifactUrl leveraging the GetArtifactUrl service API.
    * Added cmdlet New-AMPAccessLog leveraging the GenerateAccessLogs service API.
    * Modified cmdlet New-AMPApp: added parameter AutoBranchCreationConfig_EnablePullRequestPreview.
    * Modified cmdlet New-AMPBranch: added parameter EnablePullRequestPreview.
    * Modified cmdlet Update-AMPApp: added parameters AccessToken, AutoBranchCreationConfig_EnablePullRequestPreview, OauthToken and Repository.
    * Modified cmdlet Update-AMPBranch: added parameter EnablePullRequestPreview.
  * Amazon Cognito Identity Provider
    * Modified cmdlet Confirm-CGIPForgotPassword: added parameter ClientMetadata.
    * Modified cmdlet Confirm-CGIPUserRegistration: added parameter ClientMetadata.
    * Modified cmdlet Confirm-CGIPUserRegistrationAdmin: added parameter ClientMetadata.
    * Modified cmdlet Get-CGIPUserAttributeVerificationCode: added parameter ClientMetadata.
    * Modified cmdlet New-CGIPUserAdmin: added parameter ClientMetadata.
    * Modified cmdlet Register-CGIPUserInPool: added parameter ClientMetadata.
    * Modified cmdlet Reset-CGIPForgottenPassword: added parameter ClientMetadata.
    * Modified cmdlet Reset-CGIPUserPasswordAdmin: added parameter ClientMetadata.
    * Modified cmdlet Send-CGIPAuthChallengeResponse: added parameter ClientMetadata.
    * Modified cmdlet Send-CGIPAuthChallengeResponseAdmin: added parameter ClientMetadata.
    * Modified cmdlet Send-CGIPConfirmationCode: added parameter ClientMetadata.
    * Modified cmdlet Update-CGIPUserAttribute: added parameter ClientMetadata.
    * Modified cmdlet Update-CGIPUserAttributeAdmin: added parameter ClientMetadata.
  * Amazon Comprehend Medical
    * Added cmdlet Find-CMPMMedicalEntityV2 leveraging the DetectEntitiesV2 service API.
    * Added cmdlet Get-CMPMEntitiesDetectionV2Job leveraging the DescribeEntitiesDetectionV2Job service API.
    * Added cmdlet Get-CMPMEntitiesDetectionV2JobList leveraging the ListEntitiesDetectionV2Jobs service API.
    * Added cmdlet Get-CMPMPersonalHealthInformationDetectionJob leveraging the DescribePHIDetectionJob service API.
    * Added cmdlet Get-CMPMPersonalHealthInformationDetectionJobList leveraging the ListPHIDetectionJobs service API.
    * Added cmdlet Start-CMPMEntitiesDetectionV2Job leveraging the StartEntitiesDetectionV2Job service API.
    * Added cmdlet Start-CMPMPersonalHealthInformationDetectionJob leveraging the StartPHIDetectionJob service API.
    * Added cmdlet Stop-CMPMEntitiesDetectionV2Job leveraging the StopEntitiesDetectionV2Job service API.
    * Added cmdlet Stop-CMPMPersonalHealthInformationDetectionJob leveraging the StopPHIDetectionJob service API.
  * Amazon Database Migration Service
    * Added cmdlet Remove-DMSConnection leveraging the DeleteConnection service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameter S3Settings_ParquetTimestampInMillisecond.
    * Modified cmdlet New-DMSEndpoint: added parameter S3Settings_ParquetTimestampInMillisecond.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationS3: added parameter S3StorageClass.
  * Amazon Direct Connect
    * Modified cmdlet New-DCConnection: added parameter ProviderName.
    * Modified cmdlet New-DCInterconnect: added parameter ProviderName.
    * Modified cmdlet New-DCLag: added parameter ProviderName.
  * Amazon DocumentDB
    * Added cmdlet Get-DOCCertificate leveraging the DescribeCertificates service API.
    * Modified cmdlet Edit-DOCDBInstance: added parameter CACertificateIdentifier.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Remove-EC2QueuedReservedInstance leveraging the DeleteQueuedReservedInstances service API.
    * Modified cmdlet New-EC2Instance: added parameter HibernationOptions_Configured.
    * Modified cmdlet Stop-EC2Instance: added parameter Hibernate.
    * Modified cmdlet New-EC2ReservedInstance: added parameter PurchaseTime.
  * Amazon ElastiCache
    * Modified cmdlet Get-ECUpdateAction: added parameters CacheClusterId and Engine.
    * Modified cmdlet Start-ECUpdateActionBatch: added parameter CacheClusterId.
    * Modified cmdlet Stop-ECUpdateActionBatch: added parameter CacheClusterId.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameters DomainEndpointOptions_EnforceHTTPS and DomainEndpointOptions_TLSSecurityPolicy.
    * Modified cmdlet Update-ESDomainConfig: added parameters DomainEndpointOptions_EnforceHTTPS and DomainEndpointOptions_TLSSecurityPolicy.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter Tag.
  * Amazon Elemental MediaPackage
    * Added cmdlet Get-EMPHarvestJob leveraging the DescribeHarvestJob service API.
    * Added cmdlet Get-EMPHarvestJobList leveraging the ListHarvestJobs service API.
    * Added cmdlet New-EMPHarvestJob leveraging the CreateHarvestJob service API.
    * Modified cmdlet New-EMPOriginEndpoint: added parameter Origination.
    * Modified cmdlet Update-EMPOriginEndpoint: added parameter Origination.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWSoftwareUpdate leveraging the GetSoftwareUpdates service API.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameter ElasticsearchDestinationConfiguration_ClusterEndpoint.
    * Modified cmdlet Update-KINFDestination: added parameter ElasticsearchDestinationUpdate_ClusterEndpoint.
  * Amazon Lightsail
    * Added cmdlet Disable-LSAddOn leveraging the DisableAddOn service API.
    * Added cmdlet Enable-LSAddOn leveraging the EnableAddOn service API.
    * Added cmdlet Get-LSAutoSnapshot leveraging the GetAutoSnapshots service API.
    * Added cmdlet Remove-LSAutoSnapshot leveraging the DeleteAutoSnapshot service API.
    * Modified cmdlet Add-LSResourceTag: added parameter ResourceArn.
    * Modified cmdlet Copy-LSSnapshot: added parameters RestoreDate, SourceResourceName and UseLatestRestorableAutoSnapshot.
    * Modified cmdlet New-LSDisk: added parameter AddOn.
    * Modified cmdlet New-LSDiskFromSnapshot: added parameters AddOn, RestoreDate, SourceDiskName and UseLatestRestorableAutoSnapshot.
    * Modified cmdlet New-LSInstance: added parameter AddOn.
    * Modified cmdlet New-LSInstancesFromSnapshot: added parameters AddOn, RestoreDate, SourceInstanceName and UseLatestRestorableAutoSnapshot.
    * Modified cmdlet Remove-LSDisk: added parameter ForceDeleteAddOn.
    * Modified cmdlet Remove-LSInstance: added parameter ForceDeleteAddOn.
    * Modified cmdlet Remove-LSResourceTag: added parameter ResourceArn.
  * Amazon MQ
    * Modified cmdlet Update-MQBroker: added parameter HostInstanceType.
  * Amazon Pinpoint
    * Added cmdlet Get-PINEmailTemplate leveraging the GetEmailTemplate service API.
    * Added cmdlet Get-PINPushTemplate leveraging the GetPushTemplate service API.
    * Added cmdlet Get-PINSmsTemplate leveraging the GetSmsTemplate service API.
    * Added cmdlet Get-PINTemplateList leveraging the ListTemplates service API.
    * Added cmdlet New-PINEmailTemplate leveraging the CreateEmailTemplate service API.
    * Added cmdlet New-PINPushTemplate leveraging the CreatePushTemplate service API.
    * Added cmdlet New-PINSmsTemplate leveraging the CreateSmsTemplate service API.
    * Added cmdlet Remove-PINEmailTemplate leveraging the DeleteEmailTemplate service API.
    * Added cmdlet Remove-PINPushTemplate leveraging the DeletePushTemplate service API.
    * Added cmdlet Remove-PINSmsTemplate leveraging the DeleteSmsTemplate service API.
    * Added cmdlet Update-PINEmailTemplate leveraging the UpdateEmailTemplate service API.
    * Added cmdlet Update-PINPushTemplate leveraging the UpdatePushTemplate service API.
    * Added cmdlet Update-PINSmsTemplate leveraging the UpdateSmsTemplate service API.
    * Modified cmdlet New-PINCampaign: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
    * Modified cmdlet Send-PINMessage: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
    * Modified cmdlet Update-PINCampaign: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
  * Amazon Pinpoint Email
    * Modified cmdlet New-PINEDeliverabilityTestReport: added parameters Template_TemplateArn and Template_TemplateData.
    * Modified cmdlet Send-PINEEmail: added parameters Template_TemplateArn and Template_TemplateData.
  * Amazon RDS DataService
    * Modified cmdlet Invoke-RDSDStatement: added parameter ResultSetOptions_DecimalReturnType.
  * Amazon Redshift
    * Added cmdlet Get-RSNodeConfigurationOption leveraging the DescribeNodeConfigurationOptions service API.
    * Modified cmdlet Restore-RSFromClusterSnapshot: added parameter NumberOfNode.
  * Amazon Relational Database Service
    * Modified cmdlet Get-RDSReservedDBInstance: added parameter LeaseId.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameters Domain and DomainIAMRoleName.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSTranscriptionJob: added parameter OutputEncryptionKMSKeyId.
  * Amazon WorkSpaces
    * Added cmdlet Get-WKSWorkspaceSnapshot leveraging the DescribeWorkspaceSnapshots service API.
    * Added cmdlet Restore-WKSWorkspace leveraging the RestoreWorkspace service API.

### 3.3.590.0 (2019-09-23)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.590.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBProfile: added parameter Locale.
    * Modified cmdlet Update-ALXBProfile: added parameter Locale.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter EndpointConfiguration_VpcEndpointId.
    * Modified cmdlet New-AGRestApi: added parameter EndpointConfiguration_VpcEndpointId.
  * Amazon API Gateway Management API
    * Added cmdlet Get-AGMConnection leveraging the GetConnection service API.
    * Added cmdlet Remove-AGMConnection leveraging the DeleteConnection service API.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHRoute: added parameters Match_Header, Match_Method, Match_Scheme, PerRetryTimeout_Unit, PerRetryTimeout_Value, RetryPolicy_HttpRetryEvent, RetryPolicy_MaxRetry, RetryPolicy_TcpRetryEvent and Spec_Priority.
    * Modified cmdlet Update-AMSHRoute: added parameters Match_Header, Match_Method, Match_Scheme, PerRetryTimeout_Unit, PerRetryTimeout_Value, RetryPolicy_HttpRetryEvent, RetryPolicy_MaxRetry, RetryPolicy_TcpRetryEvent and Spec_Priority.
  * Amazon Application Auto Scaling
    * Modified cmdlet Add-AASScalableTarget: added parameters SuspendedState_DynamicScalingInSuspended, SuspendedState_DynamicScalingOutSuspended and SuspendedState_ScheduledScalingSuspended.
  * Amazon AppStream
    * Modified cmdlet New-APSFleet: added parameter IamRoleArn.
    * Modified cmdlet New-APSImageBuilder: added parameters AccessEndpoint and IamRoleArn.
    * Modified cmdlet New-APSStack: added parameter AccessEndpoint.
    * Modified cmdlet Update-APSFleet: added parameter IamRoleArn.
    * Modified cmdlet Update-APSStack: added parameter AccessEndpoint.
  * Amazon AppSync
    * Modified cmdlet New-ASYNGraphqlApi: added parameter LogConfig_ExcludeVerboseContent.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameter LogConfig_ExcludeVerboseContent.
  * Amazon Athena
    * Modified cmdlet New-ATHWorkGroup: added parameter Configuration_RequesterPaysEnabled.
    * Modified cmdlet Update-ATHWorkGroup: added parameter ConfigurationUpdates_RequesterPaysEnabled.
  * Amazon CodeBuild
    * Modified cmdlet Import-CBSourceCredential: added parameter ShouldOverwrite.
  * Amazon CodeCommit
    * Added cmdlet Get-CCCommitBatch leveraging the BatchGetCommits service API.
  * Amazon Config
    * Added cmdlet Get-CFGRemediationException leveraging the DescribeRemediationExceptions service API.
    * Added cmdlet Remove-CFGRemediationException leveraging the DeleteRemediationExceptions service API.
    * Added cmdlet Write-CFGRemediationException leveraging the PutRemediationExceptions service API.
  * Amazon Cost and Usage Report
    * Added cmdlet Edit-CURReportDefinition leveraging the ModifyReportDefinition service API.
  * Amazon DataSync
    * Added cmdlet Get-DSYNLocationSmb leveraging the DescribeLocationSmb service API.
    * Added cmdlet New-DSYNLocationSmb leveraging the CreateLocationSmb service API.
  * Amazon EC2 Container Service
    * Added cmdlet Update-ECSClusterSetting leveraging the UpdateClusterSettings service API.
    * Modified cmdlet New-ECSTask: added parameter Overrides_InferenceAcceleratorOverride.
    * Modified cmdlet Register-ECSTaskDefinition: added parameter InferenceAccelerator.
    * Modified cmdlet Start-ECSTask: added parameter Overrides_InferenceAcceleratorOverride.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2VpnTunnelCertificate leveraging the ModifyVpnTunnelCertificate service API.
    * Added cmdlet Edit-EC2VpnTunnelOption leveraging the ModifyVpnTunnelOptions service API.
    * Added cmdlet Export-EC2Image leveraging the ExportImage service API.
    * Added cmdlet Get-EC2ExportImageTask leveraging the DescribeExportImageTasks service API.
    * Added cmdlet Send-EC2DiagnosticInterrupt leveraging the SendDiagnosticInterrupt service API.
    * Modified cmdlet Edit-EC2VpnConnection: added parameter CustomerGatewayId.
    * Modified cmdlet New-EC2CustomerGateway: added parameter CertificateArn.
    * Modified cmdlet New-EC2FlowLog: added parameter LogFormat.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Add-EKSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EKSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EKSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-EKSCluster: added parameter Tag.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMRBlockPublicAccessConfiguration leveraging the GetBlockPublicAccessConfiguration service API.
    * Added cmdlet Write-EMRBlockPublicAccessConfiguration leveraging the PutBlockPublicAccessConfiguration service API.
  * Amazon ElastiCache
    * Modified cmdlet Copy-ECSnapshot: added parameter KmsKeyId.
    * Modified cmdlet New-ECReplicationGroup: added parameter KmsKeyId.
    * Modified cmdlet New-ECSnapshot: added parameter KmsKeyId.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter SimulateReservedQueue.
    * Modified cmdlet New-EMCQueue: added parameter Status.
  * Amazon Forecast Query Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FRCQ and can be listed using the command 'Get-AWSCmdletName -Service FRCQ'.
  * Amazon Forecast Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FRC and can be listed using the command 'Get-AWSCmdletName -Service FRC'.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLFleet: added parameter CertificateConfiguration_CertificateType.
  * Amazon Glacier
    * Modified cmdlet Start-GLCJob: renamed parameter Select as SelectParameter.
  * Amazon Glue
    * Added cmdlet Find-GLUETable leveraging the SearchTables service API.
    * Added cmdlet Get-GLUEMLTaskRun leveraging the GetMLTaskRun service API.
    * Added cmdlet Get-GLUEMLTaskRunList leveraging the GetMLTaskRuns service API.
    * Added cmdlet Get-GLUEMLTransform leveraging the GetMLTransform service API.
    * Added cmdlet Get-GLUEMLTransformList leveraging the GetMLTransforms service API.
    * Added cmdlet New-GLUEMLTransform leveraging the CreateMLTransform service API.
    * Added cmdlet Remove-GLUEMLTransform leveraging the DeleteMLTransform service API.
    * Added cmdlet Start-GLUEExportLabelsTaskRun leveraging the StartExportLabelsTaskRun service API.
    * Added cmdlet Start-GLUEImportLabelsTaskRun leveraging the StartImportLabelsTaskRun service API.
    * Added cmdlet Start-GLUEMLEvaluationTaskRun leveraging the StartMLEvaluationTaskRun service API.
    * Added cmdlet Start-GLUEMLLabelingSetGenerationTaskRun leveraging the StartMLLabelingSetGenerationTaskRun service API.
    * Added cmdlet Stop-GLUEMLTaskRun leveraging the CancelMLTaskRun service API.
    * Added cmdlet Update-GLUEMLTransform leveraging the UpdateMLTransform service API.
    * Modified cmdlet New-GLUEDevEndpoint: added parameter GlueVersion.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameter Republish_Qo.
    * Modified cmdlet Set-IOTTopicRule: added parameter Republish_Qo.
  * Amazon Lake Formation. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LKF and can be listed using the command 'Get-AWSCmdletName -Service LKF'.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter MaximumBatchingWindowInSecond.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter MaximumBatchingWindowInSecond.
  * Amazon Lex
    * Added cmdlet Get-LEXSession leveraging the GetSession service API.
    * Added cmdlet Remove-LEXSession leveraging the DeleteSession service API.
    * Added cmdlet Write-LEXSession leveraging the PutSession service API.
  * Amazon MQ
    * Modified cmdlet Update-MQBroker: added parameter SecurityGroup.
  * Amazon QLDB. Added cmdlets to support the service. Cmdlets for the service have the noun prefix QLDB and can be listed using the command 'Get-AWSCmdletName -Service QLDB'.
  * Amazon QLDB Session. Added cmdlets to support the service. Cmdlets for the service have the noun prefix QLDBS and can be listed using the command 'Get-AWSCmdletName -Service QLDBS'.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBCluster: added parameter EnableHttpEndpoint.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter DBParameterGroupName.
  * Amazon Resource Access Manager
    * Added cmdlet Get-RAMPendingInvitationResourceList leveraging the ListPendingInvitationResources service API.
  * Amazon RoboMaker
    * Modified cmdlet New-ROBOSimulationJob: added parameters DataSource and LoggingConfig_RecordAllRosTopic.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCompilationJob: added parameter StoppingCondition_MaxWaitTimeInSecond.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameters CheckpointConfig_LocalPath, CheckpointConfig_S3Uri, StoppingCondition_MaxWaitTimeInSecond and TrainingJobDefinition_EnableManagedSpotTraining.
    * Modified cmdlet New-SMTrainingJob: added parameters CheckpointConfig_LocalPath, CheckpointConfig_S3Uri, EnableManagedSpotTraining and StoppingCondition_MaxWaitTimeInSecond.
  * Amazon Simple Queue Service
    * Modified cmdlet New-SQSQueue: added parameter Tag.
    * Modified cmdlet Send-SQSMessage: added parameter MessageSystemAttribute.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGSnapshotFromVolumeRecoveryPoint: added parameter Tag.
    * Modified cmdlet Update-SGGatewayInformation: added parameter CloudWatchLogGroupARN.
  * Amazon WorkMail Message Flow. Added cmdlets to support the service. Cmdlets for the service have the noun prefix WMMF and can be listed using the command 'Get-AWSCmdletName -Service WMMF'.

### 3.3.563.1 (2019-08-09)
  * Fixing bug introduced in 3.3.563.0 resulting in variables being set in the local scope importing AWS Tools for PowerShell modules.

### 3.3.563.0 (2019-08-08)
  * A new new modular variant of AWS Tools for PowerShell ([AWS.Tools](https://www.powershellgallery.com/packages/AWS.Tools.Common)) is now offered in prerelease. Please provide feedback by opening a GitHub issue [here](https://github.com/aws/aws-tools-for-powershell/issues) if you encounter any problem using it. In order to manage each AWS service, install from [PowerShell Gallery](https://www.powershellgallery.com/) the corresponding module (e.g. [AWS.Tools.EC2](https://www.powershellgallery.com/packages/AWS.Tools.EC2), [AWS.Tools.S3](https://www.powershellgallery.com/packages/AWS.Tools.S3)...).
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.563.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter LinuxParameters_Device.
  * Amazon CloudWatch Application Insights
    * Added cmdlet Update-CWAIApplication leveraging the UpdateApplication service API.
    * Modified cmdlet New-CWAIApplication: added parameters OpsCenterEnabled and OpsItemSNSTopicArn.
  * Amazon CloudWatch Logs
    * Modified cmdlet Start-CWLQuery: added parameter LogGroupNameList.
  * Amazon Cost Explorer
    * Added cmdlet Get-CERightsizingRecommendation leveraging the GetRightsizingRecommendation service API.
  * Amazon DataSync
    * Modified cmdlet New-DSYNAgent: added parameters SecurityGroupArn, SubnetArn and VpcEndpointId.
  * Amazon EC2 Container Registry
    * Added cmdlet Write-ECRImageTagMutability leveraging the PutImageTagMutability service API.
    * Modified cmdlet New-ECRRepository: added parameter ImageTagMutability.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2CapacityReservationUsage leveraging the GetCapacityReservationUsage service API.
    * Modified cmdlet New-EC2LaunchTemplate: added parameter TagSpecification.
    * Modified cmdlet Add-EC2CapacityReservation: added parameter AvailabilityZoneId.
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameter SplitTunnel.
    * Modified cmdlet Get-EC2Region: added parameter AllRegion.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter SplitTunnel.
  * Amazon Elemental MediaConnect
    * Modified cmdlet Update-EMCNFlowOutput: added parameters CidrAllowList and RemoteId.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter Priority.
    * Modified cmdlet New-EMCJobTemplate: added parameter Priority.
    * Modified cmdlet Update-EMCJobTemplate: added parameter Priority.
  * Amazon Glue
    * Added cmdlet Get-GLUEJobBookmark leveraging the GetJobBookmark service API.
    * Modified cmdlet New-GLUEDevEndpoint: added parameters NumberOfWorker and WorkerType.
    * Modified cmdlet New-GLUEJob: added parameter GlueVersion.
    * Modified cmdlet Reset-GLUEJobBookmark: added parameter RunId.
  * Amazon IoT
    * Added cmdlet Get-IOTAuditFinding leveraging the DescribeAuditFinding service API.
    * Added cmdlet Get-IOTAuditMitigationActionsExecutionList leveraging the ListAuditMitigationActionsExecutions service API.
    * Added cmdlet Get-IOTAuditMitigationActionsTask leveraging the DescribeAuditMitigationActionsTask service API.
    * Added cmdlet Get-IOTAuditMitigationActionsTaskList leveraging the ListAuditMitigationActionsTasks service API.
    * Added cmdlet Get-IOTMitigationAction leveraging the DescribeMitigationAction service API.
    * Added cmdlet Get-IOTMitigationActionList leveraging the ListMitigationActions service API.
    * Added cmdlet New-IOTMitigationAction leveraging the CreateMitigationAction service API.
    * Added cmdlet Remove-IOTMitigationAction leveraging the DeleteMitigationAction service API.
    * Added cmdlet Start-IOTAuditMitigationActionsTask leveraging the StartAuditMitigationActionsTask service API.
    * Added cmdlet Stop-IOTAuditMitigationActionsTask leveraging the CancelAuditMitigationActionsTask service API.
    * Added cmdlet Update-IOTMitigationAction leveraging the UpdateMitigationAction service API.
  * Amazon MQ
    * Modified cmdlet New-MQBroker: added parameters EncryptionOptions_KmsKeyId and EncryptionOptions_UseAwsOwnedKey.
  * Amazon Pinpoint
    * Added cmdlet Get-PINApplicationDateRangeKpi leveraging the GetApplicationDateRangeKpi service API.
    * Added cmdlet Get-PINCampaignDateRangeKpi leveraging the GetCampaignDateRangeKpi service API.
  * Amazon Polly
    * Modified cmdlet Get-POLSpeech: added parameter Engine.
    * Modified cmdlet Get-POLVoice: added parameter Engine.
    * Modified cmdlet Start-POLSpeechSynthesisTask: added parameter Engine.
  * Amazon Security Token Service
    * Added cmdlet Get-STSAccessKeyInfo leveraging the GetAccessKeyInfo service API.

### 3.3.553.0 (2019-07-19)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.553.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Amplify
    * Added cmdlet Add-AMPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AMPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-AMPWebhook leveraging the GetWebhook service API.
    * Added cmdlet Get-AMPWebhookList leveraging the ListWebhooks service API.
    * Added cmdlet New-AMPDeployment leveraging the CreateDeployment service API.
    * Added cmdlet New-AMPWebhook leveraging the CreateWebhook service API.
    * Added cmdlet Remove-AMPResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-AMPWebhook leveraging the DeleteWebhook service API.
    * Added cmdlet Start-AMPDeployment leveraging the StartDeployment service API.
    * Added cmdlet Update-AMPWebhook leveraging the UpdateWebhook service API.
    * Modified cmdlet New-AMPApp: added parameters AccessToken, AutoBranchCreationConfig_BasicAuthCredential, AutoBranchCreationConfig_BuildSpec, AutoBranchCreationConfig_EnableAutoBuild, AutoBranchCreationConfig_EnableBasicAuth, AutoBranchCreationConfig_EnvironmentVariable, AutoBranchCreationConfig_Framework, AutoBranchCreationConfig_Stage, AutoBranchCreationPattern and EnableAutoBranchCreation.
    * Modified cmdlet New-AMPBranch: added parameter DisplayName.
    * Modified cmdlet Update-AMPApp: added parameters AutoBranchCreationConfig_BasicAuthCredential, AutoBranchCreationConfig_BuildSpec, AutoBranchCreationConfig_EnableAutoBuild, AutoBranchCreationConfig_EnableBasicAuth, AutoBranchCreationConfig_EnvironmentVariable, AutoBranchCreationConfig_Framework, AutoBranchCreationConfig_Stage, AutoBranchCreationPattern and EnableAutoBranchCreation.
    * Modified cmdlet Update-AMPBranch: added parameter DisplayName.
  * Amazon CloudWatch
    * Added cmdlet Get-CWAnomalyDetector leveraging the DescribeAnomalyDetectors service API.
    * Added cmdlet Remove-CWAnomalyDetector leveraging the DeleteAnomalyDetector service API.
    * Added cmdlet Write-CWAnomalyDetector leveraging the PutAnomalyDetector service API.
    * Modified cmdlet Write-CWMetricAlarm: added parameter ThresholdMetricId.
  * Amazon CloudWatch Events
    * Added cmdlet Disable-CWEEventSource leveraging the DeactivateEventSource service API.
    * Added cmdlet Enable-CWEEventSource leveraging the ActivateEventSource service API.
    * Added cmdlet Get-CWEEventBusList leveraging the ListEventBuses service API.
    * Added cmdlet Get-CWEEventSource leveraging the DescribeEventSource service API.
    * Added cmdlet Get-CWEEventSourceList leveraging the ListEventSources service API.
    * Added cmdlet Get-CWEPartnerEventSource leveraging the DescribePartnerEventSource service API.
    * Added cmdlet Get-CWEPartnerEventSourceAccountList leveraging the ListPartnerEventSourceAccounts service API.
    * Added cmdlet Get-CWEPartnerEventSourceList leveraging the ListPartnerEventSources service API.
    * Added cmdlet New-CWEEventBus leveraging the CreateEventBus service API.
    * Added cmdlet New-CWEPartnerEventSource leveraging the CreatePartnerEventSource service API.
    * Added cmdlet Remove-CWEEventBus leveraging the DeleteEventBus service API.
    * Added cmdlet Remove-CWEPartnerEventSource leveraging the DeletePartnerEventSource service API.
    * Added cmdlet Write-CWEPartnerEvent leveraging the PutPartnerEvents service API.
    * Modified cmdlet Disable-CWERule: added parameter EventBusName.
    * Modified cmdlet Enable-CWERule: added parameter EventBusName.
    * Modified cmdlet Get-CWEEventBus: added parameter Name.
    * Modified cmdlet Get-CWERule: added parameter EventBusName.
    * Modified cmdlet Get-CWERuleDetail: added parameter EventBusName.
    * Modified cmdlet Get-CWERuleNamesByTarget: added parameter EventBusName.
    * Modified cmdlet Get-CWETargetsByRule: added parameter EventBusName.
    * Modified cmdlet Remove-CWEPermission: added parameter EventBusName.
    * Modified cmdlet Remove-CWERule: added parameter EventBusName.
    * Modified cmdlet Remove-CWETarget: added parameter EventBusName.
    * Modified cmdlet Write-CWEPermission: added parameter EventBusName.
    * Modified cmdlet Write-CWERule: added parameter EventBusName.
    * Modified cmdlet Write-CWETarget: added parameter EventBusName.
  * Amazon Config
    * Added cmdlet Get-CFGOrganizationConfigRule leveraging the DescribeOrganizationConfigRules service API.
    * Added cmdlet Get-CFGOrganizationConfigRuleDetailedStatus leveraging the GetOrganizationConfigRuleDetailedStatus service API.
    * Added cmdlet Get-CFGOrganizationConfigRuleStatus leveraging the DescribeOrganizationConfigRuleStatuses service API.
    * Added cmdlet Remove-CFGOrganizationConfigRule leveraging the DeleteOrganizationConfigRule service API.
    * Added cmdlet Write-CFGOrganizationConfigRule leveraging the PutOrganizationConfigRule service API.
  * Amazon Cost Explorer
    * Added cmdlet Get-CEUsageForecast leveraging the GetUsageForecast service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters S3Settings_IncludeOpForFullLoad and S3Settings_TimestampColumnName.
    * [Breaking Change] Modified cmdlet Get-DMSAccountAttribute: output changed from Amazon.DatabaseMigrationService.Model.AccountQuota to Amazon.DatabaseMigrationService.Model.DescribeAccountAttributesResponse.
    * Modified cmdlet New-DMSEndpoint: added parameters S3Settings_IncludeOpForFullLoad and S3Settings_TimestampColumnName.
  * Amazon DocumentDB
    * Added cmdlet Start-DOCDBCluster leveraging the StartDBCluster service API.
    * Added cmdlet Stop-DOCDBCluster leveraging the StopDBCluster service API.
    * Modified cmdlet Edit-DOCDBCluster: added parameter DeletionProtection.
    * Modified cmdlet New-DOCDBCluster: added parameter DeletionProtection.
    * Modified cmdlet Restore-DOCDBClusterFromSnapshot: added parameter DeletionProtection.
    * Modified cmdlet Restore-DOCDBClusterToPointInTime: added parameter DeletionProtection.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCluster: added parameter Setting.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Edit-EC2SpotFleetRequest: added parameter OnDemandTargetCapacity.
    * Modified cmdlet New-EC2Fleet: added parameters OnDemandOptions_MaxTotalPrice and SpotOptions_MaxTotalPrice.
    * [Breaking Change] Modified cmdlet Register-EC2PrivateIpAddress: output changed from None and System.String to Amazon.EC2.Model.AssignedPrivateIpAddress; removed parameter PassThru.
    * Modified cmdlet Request-EC2SpotFleet: added parameters SpotFleetRequestConfig_OnDemandMaxTotalPrice and SpotFleetRequestConfig_SpotMaxTotalPrice.
  * Amazon Elemental MediaStore
    * Added cmdlet Add-EMSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-EMSContainer: added parameter Tag.
  * Amazon EventBridge. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EVB and can be listed using the command 'Get-AWSCmdletName -Service EVB'. Amazon EventBridge is a serverless event bus service that makes it easy to connect your applications with data from a variety of sources, including AWS services, partner applications, and your own applications.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLMatchmakingConfiguration: added parameter BackfillMode.
    * Modified cmdlet Update-GMLMatchmakingConfiguration: added parameter BackfillMode.
  * Amazon QuickSight
    * Modified cmdlet Get-QSDashboardEmbedUrl: added parameter UserArn.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameters AllowMajorVersionUpgrade and DBInstanceParameterGroupName.
    * Modified cmdlet Get-RDSDBCluster: added parameter IncludeShared.
  * Amazon Service Catalog
    * Added cmdlet Get-SCServiceActionExecutionParameter leveraging the DescribeServiceActionExecutionParameters service API.
    * Modified cmdlet Start-SCProvisionedProductServiceActionExecution: added parameter Parameter.
  * Amazon Simple Workflow Service
    * Added cmdlet Add-SWFResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SWFResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SWFResourceTag leveraging the UntagResource service API.
    * Added cmdlet Restore-SWFActivityType leveraging the UndeprecateActivityType service API.
    * Added cmdlet Restore-SWFDomain leveraging the UndeprecateDomain service API.
    * Added cmdlet Restore-SWFWorkflowType leveraging the UndeprecateWorkflowType service API.
    * Modified cmdlet New-SWFDomain: added parameter Tag.
  * Amazon WAF
    * Added cmdlet Add-WAFResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WAFResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WAFResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-WAFRateBasedRule: added parameter Tag.
    * Modified cmdlet New-WAFRule: added parameter Tag.
    * Modified cmdlet New-WAFRuleGroup: added parameter Tag.
    * Modified cmdlet New-WAFWebACL: added parameter Tag.
  * Amazon WAF Regional
    * Added cmdlet Add-WAFRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WAFRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WAFRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-WAFRRateBasedRule: added parameter Tag.
    * Modified cmdlet New-WAFRRule: added parameter Tag.
    * Modified cmdlet New-WAFRRuleGroup: added parameter Tag.
    * Modified cmdlet New-WAFRWebACL: added parameter Tag.

### 3.3.542.0 (2019-06-28)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.542.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBContact: added parameters PhoneNumberList and SipAddress.
    * Modified cmdlet Update-ALXBContact: added parameters PhoneNumberList and SipAddress.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter SecurityPolicy.
  * Amazon API Gateway V2
    * Added cmdlet Add-AG2ResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AG2Tag leveraging the GetTags service API.
    * Added cmdlet Remove-AG2ResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-AG2Api: added parameter Tag.
    * Modified cmdlet New-AG2DomainName: added parameter Tag.
    * Modified cmdlet New-AG2Stage: added parameter Tag.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHVirtualNode: added parameters AwsCloudMap_Attribute, AwsCloudMap_NamespaceName and AwsCloudMap_ServiceName.
    * Modified cmdlet Update-AMSHVirtualNode: added parameters AwsCloudMap_Attribute, AwsCloudMap_NamespaceName and AwsCloudMap_ServiceName.
  * Amazon Certificate Manager Private Certificate Authority
    * Modified cmdlet New-PCACertificate: added parameter TemplateArn.
  * Amazon CloudWatch Application Insights. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CWAI and can be listed using the command 'Get-AWSCmdletName -Service CWAI'. CloudWatch Application Insights detects errors and exceptions from logs, including .NET custom application logs, SQL Server logs, IIS logs, and more, and uses a combination of built-in rules and machine learning, such as dynamic baselining, to identify common problems. You can then easily drill into specific issues with CloudWatch Automatic Dashboards that are dynamically generated. These dashboards contain the most recent alarms, a summary of relevant metrics, and log snippets to help you identify root cause.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters SecondarySourceVersion and SourceVersion.
    * Modified cmdlet Update-CBProject: added parameters SecondarySourceVersion and SourceVersion.
  * Amazon CodeCommit
    * Added cmdlet Get-CCFileMergeConflict leveraging the DescribeMergeConflicts service API.
    * Added cmdlet Get-CCFileMergeConflictBatch leveraging the BatchDescribeMergeConflicts service API.
    * Added cmdlet Get-CCMergeCommit leveraging the GetMergeCommit service API.
    * Added cmdlet Get-CCMergeOption leveraging the GetMergeOptions service API.
    * Added cmdlet Merge-CCBranchesByFastForward leveraging the MergeBranchesByFastForward service API.
    * Added cmdlet Merge-CCBranchesBySquash leveraging the MergeBranchesBySquash service API.
    * Added cmdlet Merge-CCBranchesByThreeWay leveraging the MergeBranchesByThreeWay service API.
    * Added cmdlet Merge-CCPullRequestBySquash leveraging the MergePullRequestBySquash service API.
    * Added cmdlet Merge-CCPullRequestByThreeWay leveraging the MergePullRequestByThreeWay service API.
    * Added cmdlet New-CCUnreferencedMergeCommit leveraging the CreateUnreferencedMergeCommit service API.
    * Modified cmdlet Get-CCMergeConflict: added parameters ConflictDetailLevel, ConflictResolutionStrategy, MaxConflictFile and NextToken.
  * Amazon Direct Connect
    * Modified cmdlet Enable-DCPrivateVirtualInterface: added parameter NewPrivateVirtualInterfaceAllocation_Tag.
    * Modified cmdlet Enable-DCPublicVirtualInterface: added parameter NewPublicVirtualInterfaceAllocation_Tag.
    * Modified cmdlet Enable-DCTransitVirtualInterface: added parameter NewTransitVirtualInterfaceAllocation_Tag.
    * Modified cmdlet New-DCConnection: added parameter Tag.
    * Modified cmdlet New-DCHostedConnection: added parameter Tag.
    * Modified cmdlet New-DCInterconnect: added parameter Tag.
    * Modified cmdlet New-DCLag: added parameters ChildConnectionTag and Tag.
    * Modified cmdlet New-DCPrivateVirtualInterface: added parameter NewPrivateVirtualInterface_Tag.
    * Modified cmdlet New-DCPublicVirtualInterface: added parameter NewPublicVirtualInterface_Tag.
    * Modified cmdlet New-DCTransitVirtualInterface: added parameter NewTransitVirtualInterface_Tag.
  * Amazon EC2 Container Service
    * Added cmdlet Submit-ECSAttachmentStateChange leveraging the SubmitAttachmentStateChanges service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2TrafficMirrorFilterNetworkService leveraging the ModifyTrafficMirrorFilterNetworkServices service API.
    * Added cmdlet Edit-EC2TrafficMirrorFilterRule leveraging the ModifyTrafficMirrorFilterRule service API.
    * Added cmdlet Edit-EC2TrafficMirrorSession leveraging the ModifyTrafficMirrorSession service API.
    * Added cmdlet Get-EC2TrafficMirrorFilter leveraging the DescribeTrafficMirrorFilters service API.
    * Added cmdlet Get-EC2TrafficMirrorSession leveraging the DescribeTrafficMirrorSessions service API.
    * Added cmdlet Get-EC2TrafficMirrorTarget leveraging the DescribeTrafficMirrorTargets service API.
    * Added cmdlet New-EC2TrafficMirrorFilter leveraging the CreateTrafficMirrorFilter service API.
    * Added cmdlet New-EC2TrafficMirrorFilterRule leveraging the CreateTrafficMirrorFilterRule service API.
    * Added cmdlet New-EC2TrafficMirrorSession leveraging the CreateTrafficMirrorSession service API.
    * Added cmdlet New-EC2TrafficMirrorTarget leveraging the CreateTrafficMirrorTarget service API.
    * Added cmdlet Remove-EC2TrafficMirrorFilter leveraging the DeleteTrafficMirrorFilter service API.
    * Added cmdlet Remove-EC2TrafficMirrorFilterRule leveraging the DeleteTrafficMirrorFilterRule service API.
    * Added cmdlet Remove-EC2TrafficMirrorSession leveraging the DeleteTrafficMirrorSession service API.
    * Added cmdlet Remove-EC2TrafficMirrorTarget leveraging the DeleteTrafficMirrorTarget service API.
    * Modified cmdlet Edit-EC2Host: added parameter HostRecovery.
    * Modified cmdlet New-EC2Host: added parameter HostRecovery.
  * Amazon ElastiCache
    * Added cmdlet Get-ECServiceUpdate leveraging the DescribeServiceUpdates service API.
    * Added cmdlet Get-ECUpdateAction leveraging the DescribeUpdateActions service API.
    * Added cmdlet Start-ECUpdateActionBatch leveraging the BatchApplyUpdateAction service API.
    * Added cmdlet Stop-ECUpdateActionBatch leveraging the BatchStopUpdateAction service API.
  * Amazon Glue
    * Added cmdlet Get-GLUEWorkflow leveraging the GetWorkflow service API.
    * Added cmdlet Get-GLUEWorkflowBatch leveraging the BatchGetWorkflows service API.
    * Added cmdlet Get-GLUEWorkflowList leveraging the ListWorkflows service API.
    * Added cmdlet Get-GLUEWorkflowRun leveraging the GetWorkflowRun service API.
    * Added cmdlet Get-GLUEWorkflowRunList leveraging the GetWorkflowRuns service API.
    * Added cmdlet Get-GLUEWorkflowRunProperty leveraging the GetWorkflowRunProperties service API.
    * Added cmdlet New-GLUEWorkflow leveraging the CreateWorkflow service API.
    * Added cmdlet Remove-GLUEWorkflow leveraging the DeleteWorkflow service API.
    * Added cmdlet Start-GLUEWorkflowRun leveraging the StartWorkflowRun service API.
    * Added cmdlet Update-GLUEWorkflow leveraging the UpdateWorkflow service API.
    * Added cmdlet Write-GLUEWorkflowRunProperty leveraging the PutWorkflowRunProperties service API.
    * Modified cmdlet New-GLUETrigger: added parameter WorkflowName.
  * Amazon GuardDuty
    * Added cmdlet Add-GDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-GDResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GDDetector: added parameter Tag.
    * Modified cmdlet New-GDFilter: added parameter Tag.
    * Modified cmdlet New-GDIPSet: added parameter Tag.
    * Modified cmdlet New-GDThreatIntelSet: added parameter Tag.
  * Amazon Identity and Access Management
    * Added cmdlet Get-IAMOrganizationsAccessReport leveraging the GetOrganizationsAccessReport service API.
    * Added cmdlet New-IAMOrganizationsAccessReport leveraging the GenerateOrganizationsAccessReport service API.
  * Amazon Neptune
    * Modified cmdlet Edit-NPTDBCluster: added parameters CloudwatchLogsExportConfiguration_DisableLogType and CloudwatchLogsExportConfiguration_EnableLogType.
    * Modified cmdlet New-NPTDBCluster: added parameter EnableCloudwatchLogsExport.
    * Modified cmdlet Restore-NPTDBClusterFromSnapshot: added parameter EnableCloudwatchLogsExport.
    * Modified cmdlet Restore-NPTDBClusterToPointInTime: added parameter EnableCloudwatchLogsExport.
  * Amazon Organizations
    * Added cmdlet Add-ORGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ORGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ORGResourceTag leveraging the UntagResource service API.
  * Amazon Personalize. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PERS and can be listed using the command 'Get-AWSCmdletName -Service PERS'. Amazon Personalize is a machine learning service that makes it easy for developers to create individualized recommendations for customers using their applications.
  * Amazon Personalize Events. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PERSE and can be listed using the command 'Get-AWSCmdletName -Service PERSE'.
  * Amazon Personalize Runtime. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PERSR and can be listed using the command 'Get-AWSCmdletName -Service PERSR'.
  * Amazon RDS DataService
    * Added cmdlet Start-RDSDTransaction leveraging the BeginTransaction service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBInstance: added parameter MaxAllocatedStorage.
    * Modified cmdlet New-RDSDBInstance: added parameter MaxAllocatedStorage.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMTransformJob: added parameters DataProcessing_InputFilter, DataProcessing_JoinSource and DataProcessing_OutputFilter.
  * Amazon Security Hub
    * [Breaking Change] Removed cmdlet Get-SHUBProductSubscriberList.
    * Added cmdlet Add-SHUBResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SHUBActionTarget leveraging the DescribeActionTargets service API.
    * Added cmdlet Get-SHUBHub leveraging the DescribeHub service API.
    * Added cmdlet Get-SHUBResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-SHUBActionTarget leveraging the CreateActionTarget service API.
    * Added cmdlet Remove-SHUBActionTarget leveraging the DeleteActionTarget service API.
    * Added cmdlet Remove-SHUBResourceTag leveraging the UntagResource service API.
    * Added cmdlet Update-SHUBActionTarget leveraging the UpdateActionTarget service API.
    * Modified cmdlet Enable-SHUBSecurityHub: added parameter Tag.
  * Amazon Service Catalog
    * Modified cmdlet Update-SCProvisioningArtifact: added parameter Guidance.
  * Amazon Service Quotas. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SQ and can be listed using the command 'Get-AWSCmdletName -Service SQ'. Service Quotas enables you to view and manage your quotas for AWS services from a central location.
  * Amazon Simple Email Service
    * Added cmdlet Write-SESConfigurationSetDeliveryOption leveraging the PutConfigurationSetDeliveryOptions service API.
  * Amazon Storage Gateway
    * Added cmdlet Update-SGSMBSecurityStrategy leveraging the UpdateSMBSecurityStrategy service API.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMOpsItem leveraging the GetOpsItem service API.
    * Added cmdlet Get-SSMOpsItemSummary leveraging the DescribeOpsItems service API.
    * Added cmdlet Get-SSMOpsSummary leveraging the GetOpsSummary service API.
    * Added cmdlet New-SSMOpsItem leveraging the CreateOpsItem service API.
    * Added cmdlet Update-SSMOpsItem leveraging the UpdateOpsItem service API.
    * Modified cmdlet Remove-SSMDocument: added parameters DocumentVersion and VersionName.
  * Amazon WorkSpaces
    * Added cmdlet Copy-WKSWorkspaceImage leveraging the CopyWorkspaceImage service API.

### 3.3.522.0 (2019-05-31)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.522.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Alexa For Business
    * Added cmdlet Add-ALXBContactToAddressBook leveraging the AssociateContactWithAddressBook service API.
    * Added cmdlet Add-ALXBDeviceToNetworkProfile leveraging the AssociateDeviceWithNetworkProfile service API.
    * Added cmdlet Get-ALXBNetworkProfile leveraging the GetNetworkProfile service API.
    * Added cmdlet New-ALXBNetworkProfile leveraging the CreateNetworkProfile service API.
    * Added cmdlet Remove-ALXBNetworkProfile leveraging the DeleteNetworkProfile service API.
    * Added cmdlet Search-ALXBNetworkProfile leveraging the SearchNetworkProfiles service API.
    * Added cmdlet Update-ALXBNetworkProfile leveraging the UpdateNetworkProfile service API.
  * Amazon API Gateway
    * Modified cmdlet New-AGApiKey: added parameter Tag.
    * Modified cmdlet New-AGClientCertificate: added parameter Tag.
    * Modified cmdlet New-AGDomainName: added parameter Tag.
    * Modified cmdlet New-AGRestApi: added parameter Tag.
    * Modified cmdlet New-AGUsagePlan: added parameter Tag.
    * Modified cmdlet New-AGVpcLink: added parameter Tag.
  * Amazon AppStream
    * Added cmdlet Get-APSUsageReportSubscription leveraging the DescribeUsageReportSubscriptions service API.
    * Added cmdlet New-APSUsageReportSubscription leveraging the CreateUsageReportSubscription service API.
    * Added cmdlet Remove-APSUsageReportSubscription leveraging the DeleteUsageReportSubscription service API.
    * Modified cmdlet New-APSFleet: added parameter IdleDisconnectTimeoutInSecond.
    * Modified cmdlet Update-APSFleet: added parameter IdleDisconnectTimeoutInSecond.
  * Amazon Budgets
    * Modified cmdlet New-BGTBudget: added parameter Budget_PlannedBudgetLimit.
    * Modified cmdlet Update-BGTBudget: added parameter NewBudget_PlannedBudgetLimit.
  * Amazon Chime
    * Added cmdlet Get-CHMBot leveraging the GetBot service API.
    * Added cmdlet Get-CHMBotList leveraging the ListBots service API.
    * Added cmdlet Get-CHMEventsConfiguration leveraging the GetEventsConfiguration service API.
    * Added cmdlet New-CHMBot leveraging the CreateBot service API.
    * Added cmdlet Remove-CHMEventsConfiguration leveraging the DeleteEventsConfiguration service API.
    * Added cmdlet Update-CHMBot leveraging the UpdateBot service API.
    * Added cmdlet Update-CHMSecurityToken leveraging the RegenerateSecurityToken service API.
    * Added cmdlet Write-CHMEventsConfiguration leveraging the PutEventsConfiguration service API.
    * Modified cmdlet Search-CHMAvailablePhoneNumber: added parameter TollFreePrefix.
  * Amazon CodeCommit
    * Added cmdlet Add-CCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CCResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CCRepository: added parameter Tag.
  * Amazon CodeDeploy
    * Added cmdlet Add-CDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CDResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CDApplication: added parameter Tag.
    * Modified cmdlet New-CDDeploymentGroup: added parameter Tag.
  * Amazon CodePipeline
    * Added cmdlet Add-CPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CPCustomActionType: added parameter Tag.
    * Modified cmdlet New-CPPipeline: added parameter Tag.
    * Modified cmdlet Write-CPWebhook: added parameter Tag.
  * Amazon Comprehend
    * Modified cmdlet New-COMPDocumentClassifier: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet New-COMPEntityRecognizer: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPDocumentClassificationJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPDominantLanguageDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPEntitiesDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPKeyPhrasesDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPSentimentDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPTopicsDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
  * Amazon Data Lifecycle Manager
    * Modified cmdlet New-DLMLifecyclePolicy: added parameters Parameters_ExcludeBootVolume and PolicyDetails_PolicyType.
    * Modified cmdlet Update-DLMLifecyclePolicy: added parameters Parameters_ExcludeBootVolume and PolicyDetails_PolicyType.
  * Amazon Device Farm
    * Added cmdlet Add-DFResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-DFResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-DFResourceTag leveraging the UntagResource service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Disable-EC2EbsEncryptionByDefault leveraging the DisableEbsEncryptionByDefault service API.
    * Added cmdlet Edit-EC2EbsDefaultKmsKeyId leveraging the ModifyEbsDefaultKmsKeyId service API.
    * Added cmdlet Enable-EC2EbsEncryptionByDefault leveraging the EnableEbsEncryptionByDefault service API.
    * Added cmdlet Get-EC2EbsDefaultKmsKeyId leveraging the GetEbsDefaultKmsKeyId service API.
    * Added cmdlet Get-EC2EbsEncryptionByDefault leveraging the GetEbsEncryptionByDefault service API.
    * Added cmdlet New-EC2SnapshotBatch leveraging the CreateSnapshots service API.
    * Added cmdlet Reset-EC2EbsDefaultKmsKeyId leveraging the ResetEbsDefaultKmsKeyId service API.
    * Modified cmdlet Get-EC2DhcpOption: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-EC2Subnet: added parameters MaxResult and NextToken.
    * Modified cmdlet Grant-EC2ClientVpnIngress: added parameter ClientToken.
    * Modified cmdlet New-EC2ClientVpnRoute: added parameter ClientToken.
    * Modified cmdlet Register-EC2ClientVpnTargetNetwork: added parameter ClientToken.
  * Amazon Elemental MediaPackage VOD. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EMPV and can be listed using the command 'Get-AWSCmdletName -Service EMPV'. AWS Elemental MediaPackage now supports Video-on-Demand (VOD) workflows. These new features allow you to easily deliver a vast library of source video Assets stored in your own S3 buckets using a small set of simple to set up Packaging Configurations and Packaging Groups.
  * Amazon Ground Station. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GS and can be listed using the command 'Get-AWSCmdletName -Service GS'. AWS Ground Station is a fully managed service that enables you to control satellite communications, downlink and process satellite data, and scale your satellite operations efficiently and cost-effectively without having to build or manage your own ground station infrastructure.
  * Amazon IoT Events. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTE and can be listed using the command 'Get-AWSCmdletName -Service IOTE'. The AWS IoT Events service allows customers to monitor their IoT devices and sensors to detect failures or changes in operation and to trigger actions when these events occur.
  * Amazon IoT Events Data. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTED and can be listed using the command 'Get-AWSCmdletName -Service IOTED'.
  * Amazon IoT Things Graph. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTTG and can be listed using the command 'Get-AWSCmdletName -Service IOTTG'.
  * Amazon Managed Streaming for Kafka
    * Added cmdlet Get-MSKClusterOperation leveraging the DescribeClusterOperation service API.
    * Added cmdlet Get-MSKClusterOperationList leveraging the ListClusterOperations service API.
    * Added cmdlet Get-MSKConfiguration leveraging the DescribeConfiguration service API.
    * Added cmdlet Get-MSKConfigurationList leveraging the ListConfigurations service API.
    * Added cmdlet Get-MSKConfigurationRevision leveraging the DescribeConfigurationRevision service API.
    * Added cmdlet Get-MSKConfigurationRevisionList leveraging the ListConfigurationRevisions service API.
    * Added cmdlet New-MSKConfiguration leveraging the CreateConfiguration service API.
    * Added cmdlet Update-MSKBrokerStorage leveraging the UpdateBrokerStorage service API.
    * Added cmdlet Update-MSKClusterConfiguration leveraging the UpdateClusterConfiguration service API.
    * Modified cmdlet New-MSKCluster: added parameters ConfigurationInfo_Arn, ConfigurationInfo_Revision, EncryptionInTransit_ClientBroker, EncryptionInTransit_InCluster, Tag and Tls_CertificateAuthorityArnList.
  * Amazon Pinpoint Email
    * Added cmdlet Get-PINEDomainDeliverabilityCampaign leveraging the GetDomainDeliverabilityCampaign service API.
    * Added cmdlet Get-PINEDomainDeliverabilityCampaignList leveraging the ListDomainDeliverabilityCampaigns service API.
    * [Breaking Change] Modified cmdlet Get-PINEDeliverabilityDashboardOption: output changed from System.Boolean to Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse.
    * Modified cmdlet New-PINEConfigurationSet: added parameter DeliveryOptions_TlsPolicy.
    * Modified cmdlet Write-PINEConfigurationSetDeliveryOption: added parameter TlsPolicy.
    * Modified cmdlet Write-PINEDeliverabilityDashboardOption: added parameter SubscribedDomain.
  * Amazon RDS DataService
    * Added cmdlet Confirm-RDSDTransaction leveraging the CommitTransaction service API.
    * Added cmdlet Invoke-RDSDStatement leveraging the ExecuteStatement service API.
    * Added cmdlet Invoke-RDSDStatementBatch leveraging the BatchExecuteStatement service API.
    * Added cmdlet Reset-RDSDTransaction leveraging the RollbackTransaction service API.
  * Amazon Relational Database Service
    * Added cmdlet Start-RDSActivityStream leveraging the StartActivityStream service API.
    * Added cmdlet Stop-RDSActivityStream leveraging the StopActivityStream service API.
    * Modified cmdlet Get-RDSDBEngineVersion: added parameter IncludeAll.
  * Amazon RoboMaker
    * Added cmdlet Stop-ROBODeploymentJob leveraging the CancelDeploymentJob service API.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBProduct leveraging the DescribeProducts service API.
    * Added cmdlet Get-SHUBProductSubscriberList leveraging the ListProductSubscribers service API.
  * Amazon Service Catalog
    * Added cmdlet Get-SCStackInstancesForProvisionedProduct leveraging the ListStackInstancesForProvisionedProduct service API.
    * Added cmdlet Update-SCProvisionedProductProperty leveraging the UpdateProvisionedProductProperties service API.
  * Amazon Simple Storage Service
    * Modified cmdlet Write-S3BucketReplication: added parameter Token.
  * Amazon Storage Gateway
    * Added cmdlet Add-SGTapeToTapePool leveraging the AssignTapePool service API.
    * Modified cmdlet New-SGSnapshot: added parameter Tag.
    * Modified cmdlet Update-SGSnapshotSchedule: added parameter Tag.
  * Amazon WorkLink
    * Added cmdlet Add-WLWebsiteAuthorizationProviderToFleet leveraging the AssociateWebsiteAuthorizationProvider service API.
    * Added cmdlet Get-WLWebsiteAuthorizationProviderList leveraging the ListWebsiteAuthorizationProviders service API.
    * Added cmdlet Remove-WLWebsiteAuthorizationProviderFromFleet leveraging the DisassociateWebsiteAuthorizationProvider service API.

### 3.3.509.0 (2019-05-14)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.509.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * AWSPowerShell cmdlets
    * [Breaking Change] Modified cmdlets Use-STSRoleWithSAML and Use-STSWebIdentityRole to honor the Set-AWSProxy configuration.
    * Modified cmdlets Clear-AWSDefaultConfiguration, Clear-AWSCredential, Set-AWSProxy, Clear-AWSProxy, Set-DefaultAWSRegion and Clear-DefaultAWSRegion: added parameter Scope.
  * Amazon Alexa For Business
    * Added cmdlet Remove-ALXBDeviceUsageData leveraging the DeleteDeviceUsageData service API.
    * Added cmdlet Send-ALXBAnnouncement leveraging the SendAnnouncement service API.
  * Amazon AppSync
    * Added cmdlet Add-ASYNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ASYNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ASYNResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Get-ASYNIntrospectionSchema: added parameter IncludeDirective.
    * Modified cmdlet New-ASYNGraphqlApi: added parameters AdditionalAuthenticationProvider and Tag.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameter AdditionalAuthenticationProvider.
  * Amazon Cognito Identity Provider
    * Added cmdlet Set-CGIPUserPasswordAdmin leveraging the AdminSetUserPassword service API.
    * Modified cmdlet New-CGIPUserPool: added parameter PasswordPolicy_TemporaryPasswordValidityDay.
    * Modified cmdlet Update-CGIPUserPool: added parameter PasswordPolicy_TemporaryPasswordValidityDay.
  * Amazon Config
    * Modified cmdlet Write-CFGAggregationAuthorization: added parameter Tag.
    * Modified cmdlet Write-CFGConfigRule: added parameter Tag.
    * Modified cmdlet Write-CFGConfigurationAggregator: added parameter Tag.
  * Amazon Direct Connect
    * Added cmdlet Confirm-DCTransitVirtualInterface leveraging the ConfirmTransitVirtualInterface service API.
    * Added cmdlet Enable-DCTransitVirtualInterface leveraging the AllocateTransitVirtualInterface service API.
    * Added cmdlet New-DCTransitVirtualInterface leveraging the CreateTransitVirtualInterface service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2VpnConnection leveraging the ModifyVpnConnection service API.
    * Modified cmdlet New-EC2NetworkInterface: added parameter InterfaceType.
  * Amazon Elemental MediaLive
    * Added cmdlet Remove-EMLSchedule leveraging the DeleteSchedule service API.
    * Added cmdlet Update-EMLChannelClass leveraging the UpdateChannelClass service API.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLScript leveraging the DescribeScript service API.
    * Added cmdlet Get-GMLScriptList leveraging the ListScripts service API.
    * Added cmdlet New-GMLScript leveraging the CreateScript service API.
    * Added cmdlet Remove-GMLScript leveraging the DeleteScript service API.
    * Added cmdlet Update-GMLScript leveraging the UpdateScript service API.
    * Modified cmdlet Get-GMLFleet: added parameter ScriptId.
    * Modified cmdlet New-GMLBuild: added parameter StorageLocation_ObjectVersion.
    * Modified cmdlet New-GMLFleet: added parameter ScriptId.
  * Amazon Identity and Access Management
    * Added cmdlet Set-IAMSecurityTokenServicePreference leveraging the SetSecurityTokenServicePreferences service API.
  * Amazon Kinesis Analytics
    * Added cmdlet Add-KINAResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KINAResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-KINAResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-KINAApplication: added parameter Tag.
  * Amazon Kinesis Analytics (v2)
    * Added cmdlet Add-KINA2ResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KINA2ResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-KINA2ResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-KINA2Application: added parameter Tag.
  * Amazon Lambda
    * Added cmdlet Get-LMLayerVersionByArn leveraging the GetLayerVersionByArn service API.
  * Amazon Managed Blockchain. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MBC and can be listed using the command 'Get-AWSCmdletName -Service MBC'. Amazon Managed Blockchain is a fully managed service that makes it easy to create and manage scalable blockchain networks using popular open source frameworks.
  * Amazon Neptune
    * Modified cmdlet Restore-NPTDBClusterFromSnapshot: added parameter DBClusterParameterGroupName.
    * Modified cmdlet Restore-NPTDBClusterToPointInTime: added parameter DBClusterParameterGroupName.
  * Amazon S3 Control
    * Added cmdlet Get-S3CJob leveraging the DescribeJob service API.
    * Added cmdlet Get-S3CJobList leveraging the ListJobs service API.
    * Added cmdlet New-S3CJob leveraging the CreateJob service API.
    * Added cmdlet Update-S3CJobPriority leveraging the UpdateJobPriority service API.
    * Added cmdlet Update-S3CJobStatus leveraging the UpdateJobStatus service API.
  * Amazon Service Catalog
    * Added cmdlet Get-SCBudgetsForResource leveraging the ListBudgetsForResource service API.
    * Added cmdlet Register-SCBudgetWithResource leveraging the AssociateBudgetWithResource service API.
    * Added cmdlet Unregister-SCBudgetFromResource leveraging the DisassociateBudgetFromResource service API.
    * Modified cmdlet New-SCProduct: added parameter ProvisioningArtifactParameters_DisableTemplateValidation.
    * Modified cmdlet New-SCProvisioningArtifact: added parameter Parameters_DisableTemplateValidation.
  * Amazon Simple Notification Service
    * Added cmdlet Add-SNSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SNSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SNSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-SNSTopic: added parameter Tag.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGSMBFileShare: added parameter AdminUserList.
    * Modified cmdlet Update-SGSMBFileShare: added parameter AdminUserList.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMPatchProperty leveraging the DescribePatchProperties service API.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter HostKey.
    * Modified cmdlet Update-TFRServer: added parameter HostKey.
  * Amazon WorkMail
    * Added cmdlet Get-WMMailboxDetail leveraging the GetMailboxDetails service API.
    * Added cmdlet Update-WMMailboxQuota leveraging the UpdateMailboxQuota service API.
  * Amazon X-Ray
    * Added cmdlet Get-XRTimeSeriesServiceStatistic leveraging the GetTimeSeriesServiceStatistics service API.
    * Modified cmdlet Get-XRTraceSummary: added parameters SamplingStrategy_Name, SamplingStrategy_Value and TimeRangeType.

### 3.3.498.0 (2019-04-24)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.498.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * SAML Configuration Cmdlets Set-AWSSamlEndpoint and Set-AWSSamlRoleProfile are now available in the AWSPowerShell.NetCore module when used under Windows.
  * Modified cmdlet Set-AWSCredential: added parameters Scope. Using Set-AWSCredential with _-Scope Global_ allows to make credentials available to the whole PowerShell session.
  * Amazon Alexa For Business
    * Added cmdlet Get-ALXBGateway leveraging the GetGateway service API.
    * Added cmdlet Get-ALXBGatewayGroup leveraging the GetGatewayGroup service API.
    * Added cmdlet Get-ALXBGatewayGroupList leveraging the ListGatewayGroups service API.
    * Added cmdlet Get-ALXBGatewayList leveraging the ListGateways service API.
    * Added cmdlet New-ALXBGatewayGroup leveraging the CreateGatewayGroup service API.
    * Added cmdlet Remove-ALXBGatewayGroup leveraging the DeleteGatewayGroup service API.
    * Added cmdlet Update-ALXBGateway leveraging the UpdateGateway service API.
    * Added cmdlet Update-ALXBGatewayGroup leveraging the UpdateGatewayGroup service API.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter ContainerProperties_ResourceRequirement.
    * Modified cmdlet Submit-BATJob: added parameters ContainerOverrides_ResourceRequirement and NodeOverrides_NumNode.
  * Amazon CloudWatch
    * Added cmdlet Add-CWResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CWResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Write-CWMetricAlarm: added parameter Tag.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter EmailConfiguration_EmailSendingAccount.
    * Modified cmdlet Update-CGIPUserPool: added parameter EmailConfiguration_EmailSendingAccount.
  * Amazon Comprehend
    * Added cmdlet Add-COMPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-COMPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-COMPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-COMPDocumentClassifier: added parameters OutputDataConfig_KmsKeyId, OutputDataConfig_S3Uri, Tag and VolumeKmsKeyId.
    * Modified cmdlet New-COMPEntityRecognizer: added parameters Tag and VolumeKmsKeyId.
    * Modified cmdlet Start-COMPDocumentClassificationJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPDominantLanguageDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPEntitiesDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPKeyPhrasesDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPSentimentDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPTopicsDetectionJob: added parameter VolumeKmsKeyId.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter Logging_ClusterLogging.
    * Modified cmdlet Update-EKSClusterConfig: added parameter Logging_ClusterLogging.
  * Amazon Elemental MediaLive
    * Added cmdlet Update-EMLReservation leveraging the UpdateReservation service API.
    * Modified cmdlet Get-EMLOfferingList: added parameter ChannelClass.
    * Modified cmdlet Get-EMLReservationList: added parameter ChannelClass.
    * Modified cmdlet New-EMLChannel: added parameter ChannelClass.
    * Modified cmdlet New-EMLOfferingPurchase: added parameter Tag.
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameters NumberOfWorker and WorkerType.
    * Modified cmdlet Start-GLUEJobRun: added parameters NumberOfWorker and WorkerType.
  * Amazon Greengrass
    * Added cmdlet Add-GGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-GGResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GGConnectorDefinition: added parameter Tag.
    * Modified cmdlet New-GGCoreDefinition: added parameter Tag.
    * Modified cmdlet New-GGDeviceDefinition: added parameter Tag.
    * Modified cmdlet New-GGFunctionDefinition: added parameter Tag.
    * Modified cmdlet New-GGGroup: added parameter Tag.
    * Modified cmdlet New-GGLoggerDefinition: added parameter Tag.
    * Modified cmdlet New-GGResourceDefinition: added parameter Tag.
    * Modified cmdlet New-GGSubscriptionDefinition: added parameter Tag.
    * Modified cmdlet Start-GGBulkDeployment: added parameter Tag.
  * Amazon Managed Streaming for Kafka
    * Added cmdlet Add-MSKResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-MSKResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-MSKResourceTag leveraging the UntagResource service API.
  * Amazon MQ
    * Added cmdlet Get-MQBrokerEngineType leveraging the DescribeBrokerEngineTypes service API.
    * Added cmdlet Get-MQBrokerInstanceOption leveraging the DescribeBrokerInstanceOptions service API.
  * Amazon Organizations
    * Added cmdlet New-ORGGovCloudAccount leveraging the CreateGovCloudAccount service API.
  * Amazon Pinpoint Email
    * Added cmdlet Add-PINEResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PINEResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-PINEResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-PINEConfigurationSet: added parameter Tag.
    * Modified cmdlet New-PINEDedicatedIpPool: added parameter Tag.
    * Modified cmdlet New-PINEDeliverabilityTestReport: added parameter Tag.
    * Modified cmdlet New-PINEEmailIdentity: added parameter Tag.
  * Amazon Relational Database Service
    * Modified cmdlet Add-RDSRoleToDBCluster: added parameter FeatureName.
    * Modified cmdlet Edit-RDSDBCluster: added parameter ScalingConfiguration_TimeoutAction.
    * Modified cmdlet New-RDSDBCluster: added parameter ScalingConfiguration_TimeoutAction.
    * Modified cmdlet Remove-RDSRoleFromDBCluster: added parameter FeatureName.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter ScalingConfiguration_TimeoutAction.
  * Amazon Route 53
    * Modified cmdlet Update-R53HealthCheck: added parameters Disabled and ResetElement.
  * Amazon Service Catalog
    * Modified cmdlet Update-SCProvisionedProduct: added parameter Tag.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGCachediSCSIVolume: added parameter Tag.
    * Modified cmdlet New-SGSMBFileShare: added parameter SMBACLEnabled.
    * Modified cmdlet New-SGStorediSCSIVolume: added parameter Tag.
    * Modified cmdlet New-SGTape: added parameter Tag.
    * Modified cmdlet New-SGTapeWithBarcode: added parameter Tag.
    * Modified cmdlet Update-SGMaintenanceStartTime: added parameter DayOfMonth.
    * Modified cmdlet Update-SGSMBFileShare: added parameter SMBACLEnabled.
  * Amazon Systems Manager
    * Modified cmdlet Write-SSMParameter: added parameters Policy and Tier.
  * Amazon WorkLink
    * Added cmdlet Get-WLDomain leveraging the DescribeDomain service API.
    * Added cmdlet Get-WLDomainList leveraging the ListDomains service API.
    * Added cmdlet Register-WLDomain leveraging the AssociateDomain service API.
    * Added cmdlet Restore-WLDomainAccess leveraging the RestoreDomainAccess service API.
    * Added cmdlet Revoke-WLDomainAccess leveraging the RevokeDomainAccess service API.
    * Added cmdlet Unregister-WLDomain leveraging the DisassociateDomain service API.
    * Added cmdlet Update-WLDomainMetadata leveraging the UpdateDomainMetadata service API.
  * Amazon WorkSpaces
    * Modified cmdlet Import-WKSWorkspaceImage: added parameter Tag.
    * Modified cmdlet New-WKSIpGroup: added parameter Tag.

### 3.3.485.0 (2019-03-28)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.485.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * AWSPowerShell.NetCore now targets PowerShell Standard (https://github.com/PowerShell/PowerShellStandard). As a preview feature, you can test using the AWSPowerShell.NetCore module under older version of PowerShell starting with PowerShell 3.0 when at least .NET Framework 4.7.2 is installed.
  * AWSPowerShell.NetCore now targets AWS .NET SDK for NetStandard 2.0.
  * This changelog is now available on GitHub at https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md. Users are also invited to create GitHub issues at https://github.com/aws/aws-tools-for-powershell/issues to report bugs or make feature requests.
  * [Breaking Change] AWSPowerShell.NetCore now unwraps AggregateException (https://docs.microsoft.com/en-us/dotnet/api/system.aggregateexception) when returning errors, following the same behavior as the AWSPowerShell module.
  * Amazon Alexa For Business
    * Added cmdlet Get-ALXBInvitationConfiguration leveraging the GetInvitationConfiguration service API.
    * Added cmdlet Write-ALXBInvitationConfiguration leveraging the PutInvitationConfiguration service API.
    * [Breaking Change] Modified cmdlet Add-ALXBSkillToUser: removed parameter OrganizationArn.
    * [Breaking Change] Modified cmdlet Remove-ALXBSkillFromUser: removed parameter OrganizationArn.
  * Amazon API Gateway V2
    * [Breaking Change] Modified cmdlet Get-AG2ApiMapping: removed parameter ApiId; parameter ApiMappingId now supports pipeline ByValue.
    * [Breaking Change] Modified cmdlet Remove-AG2ApiMapping: removed parameter ApiId; parameter ApiMappingId now supports pipeline ByValue.
  * Amazon App Mesh
    * Added cmdlet Add-AMSHResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AMSHResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-AMSHVirtualService leveraging the DescribeVirtualService service API.
    * Added cmdlet Get-AMSHVirtualServiceList leveraging the ListVirtualServices service API.
    * Added cmdlet New-AMSHVirtualService leveraging the CreateVirtualService service API.
    * Added cmdlet Remove-AMSHResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-AMSHVirtualService leveraging the DeleteVirtualService service API.
    * Added cmdlet Update-AMSHMesh leveraging the UpdateMesh service API.
    * Added cmdlet Update-AMSHVirtualService leveraging the UpdateVirtualService service API.
    * Modified cmdlet New-AMSHMesh: added parameters EgressFilter_Type and Tag.
    * Modified cmdlet New-AMSHRoute: added parameters Spec_TcpRoute_Action_WeightedTarget and Tag.
    * Modified cmdlet Update-AMSHRoute: added parameter Spec_TcpRoute_Action_WeightedTarget.
    * [Breaking Change] Modified cmdlet New-AMSHVirtualNode: removed parameter Dns_ServiceName; added parameters Dns_Hostname, File_Path and Tag.
    * [Breaking Change] Modified cmdlet New-AMSHVirtualRouter: removed parameter Spec_ServiceName; added parameters Spec_Listener and Tag.
    * [Breaking Change] Modified cmdlet Update-AMSHVirtualNode: removed parameter Dns_ServiceName; added parameters Dns_Hostname and File_Path.
    * [Breaking Change] Modified cmdlet Update-AMSHVirtualRouter: removed parameter Spec_ServiceName; added parameter Spec_Listener.
  * Amazon Certificate Manager
    * Added cmdlet Invoke-ACMCertificateRenewal leveraging the RenewCertificate service API.
  * Amazon Certificate Manager Private Certificate Authority
    * Added cmdlet Get-PCAPermissionList leveraging the ListPermissions service API.
    * Added cmdlet New-PCAPermission leveraging the CreatePermission service API.
    * Added cmdlet Remove-PCAPermission leveraging the DeletePermission service API.
  * Amazon Chime
    * Added cmdlet Add-CHMPhoneNumbersToVoiceConnector leveraging the AssociatePhoneNumbersWithVoiceConnector service API.
    * Added cmdlet Add-CHMPhoneNumberToUser leveraging the AssociatePhoneNumberWithUser service API.
    * Added cmdlet Get-CHMGlobalSetting leveraging the GetGlobalSettings service API.
    * Added cmdlet Get-CHMPhoneNumber leveraging the GetPhoneNumber service API.
    * Added cmdlet Get-CHMPhoneNumberList leveraging the ListPhoneNumbers service API.
    * Added cmdlet Get-CHMPhoneNumberOrder leveraging the GetPhoneNumberOrder service API.
    * Added cmdlet Get-CHMPhoneNumberOrderList leveraging the ListPhoneNumberOrders service API.
    * Added cmdlet Get-CHMUserSetting leveraging the GetUserSettings service API.
    * Added cmdlet Get-CHMVoiceConnector leveraging the GetVoiceConnector service API.
    * Added cmdlet Get-CHMVoiceConnectorList leveraging the ListVoiceConnectors service API.
    * Added cmdlet Get-CHMVoiceConnectorOrigination leveraging the GetVoiceConnectorOrigination service API.
    * Added cmdlet Get-CHMVoiceConnectorTermination leveraging the GetVoiceConnectorTermination service API.
    * Added cmdlet Get-CHMVoiceConnectorTerminationCredentialList leveraging the ListVoiceConnectorTerminationCredentials service API.
    * Added cmdlet Get-CHMVoiceConnectorTerminationHealth leveraging the GetVoiceConnectorTerminationHealth service API.
    * Added cmdlet New-CHMPhoneNumberOrder leveraging the CreatePhoneNumberOrder service API.
    * Added cmdlet New-CHMVoiceConnector leveraging the CreateVoiceConnector service API.
    * Added cmdlet Remove-CHMPhoneNumber leveraging the DeletePhoneNumber service API.
    * Added cmdlet Remove-CHMPhoneNumberBatch leveraging the BatchDeletePhoneNumber service API.
    * Added cmdlet Remove-CHMPhoneNumberFromUser leveraging the DisassociatePhoneNumberFromUser service API.
    * Added cmdlet Remove-CHMPhoneNumbersFromVoiceConnector leveraging the DisassociatePhoneNumbersFromVoiceConnector service API.
    * Added cmdlet Remove-CHMVoiceConnector leveraging the DeleteVoiceConnector service API.
    * Added cmdlet Remove-CHMVoiceConnectorOrigination leveraging the DeleteVoiceConnectorOrigination service API.
    * Added cmdlet Remove-CHMVoiceConnectorTermination leveraging the DeleteVoiceConnectorTermination service API.
    * Added cmdlet Remove-CHMVoiceConnectorTerminationCredential leveraging the DeleteVoiceConnectorTerminationCredentials service API.
    * Added cmdlet Restore-CHMPhoneNumber leveraging the RestorePhoneNumber service API.
    * Added cmdlet Search-CHMAvailablePhoneNumber leveraging the SearchAvailablePhoneNumbers service API.
    * Added cmdlet Update-CHMGlobalSetting leveraging the UpdateGlobalSettings service API.
    * Added cmdlet Update-CHMPhoneNumber leveraging the UpdatePhoneNumber service API.
    * Added cmdlet Update-CHMPhoneNumberBatch leveraging the BatchUpdatePhoneNumber service API.
    * Added cmdlet Update-CHMUserSetting leveraging the UpdateUserSettings service API.
    * Added cmdlet Update-CHMVoiceConnector leveraging the UpdateVoiceConnector service API.
    * Added cmdlet Write-CHMVoiceConnectorOrigination leveraging the PutVoiceConnectorOrigination service API.
    * Added cmdlet Write-CHMVoiceConnectorTermination leveraging the PutVoiceConnectorTermination service API.
    * Added cmdlet Write-CHMVoiceConnectorTerminationCredential leveraging the PutVoiceConnectorTerminationCredentials service API.
  * Amazon CloudFormation
    * [Breaking Change] Fixed a bug in Test-CFNStack causing the cmdlet to throw an exception instead of returning false, as described in the documentation, when the stack doesn't exist.
  * Amazon CloudWatch
    * [Breaking Change] The service output for the API called by the Get-CWMetricData cmdlet has been updated and it is no longer possible for this cmdlet to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon CloudWatch Events
    * Added cmdlet Add-CWEResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWEResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CWEResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Write-CWERule: added parameter Tag.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters GitSubmodulesConfig_FetchSubmodule and S3Logs_EncryptionDisabled.
    * Modified cmdlet Start-CBBuild: added parameters GitSubmodulesConfigOverride_FetchSubmodule and S3Logs_EncryptionDisabled.
    * Modified cmdlet Update-CBProject: added parameters GitSubmodulesConfig_FetchSubmodule and S3Logs_EncryptionDisabled.
  * Amazon CodePipeline
    * Added cmdlet Get-CPActionExecutionList leveraging the ListActionExecutions service API.
  * Amazon Cognito Identity
    * Added cmdlet Add-CGIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CGIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CGIResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CGIIdentityPool: added parameter IdentityPoolTag.
    * Modified cmdlet Update-CGIIdentityPool: added parameter IdentityPoolTag.
  * Amazon Cognito Identity Provider
    * Added cmdlet Add-CGIPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CGIPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CGIPResourceTag leveraging the UntagResource service API.
  * Amazon Config
    * Added cmdlet Add-CFGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CFGRemediationConfiguration leveraging the DescribeRemediationConfigurations service API.
    * Added cmdlet Get-CFGRemediationExecutionStatus leveraging the DescribeRemediationExecutionStatus service API.
    * Added cmdlet Get-CFGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CFGRemediationConfiguration leveraging the DeleteRemediationConfiguration service API.
    * Added cmdlet Remove-CFGResourceTag leveraging the UntagResource service API.
    * Added cmdlet Select-CFGResourceConfig leveraging the SelectResourceConfig service API.
    * Added cmdlet Start-CFGRemediationExecution leveraging the StartRemediationExecution service API.
    * Added cmdlet Write-CFGRemediationConfiguration leveraging the PutRemediationConfigurations service API.
  * Amazon Cost and Usage Report
    * Modified cmdlet Write-CURReportDefinition: added parameters ReportDefinition_RefreshClosedReport and ReportDefinition_ReportVersioning.
  * Amazon Database Migration Service
    * Added cmdlet Complete-DMSPendingMaintenanceAction leveraging the ApplyPendingMaintenanceAction service API.
    * Added cmdlet Get-DMSPendingMaintenanceAction leveraging the DescribePendingMaintenanceActions service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameters RedshiftSettings_AcceptAnyDate, RedshiftSettings_AfterConnectScript, RedshiftSettings_BucketFolder, RedshiftSettings_BucketName, RedshiftSettings_ConnectionTimeout, RedshiftSettings_DatabaseName, RedshiftSettings_DateFormat, RedshiftSettings_EmptyAsNull, RedshiftSettings_EncryptionMode, RedshiftSettings_FileTransferUploadStream, RedshiftSettings_LoadTimeout, RedshiftSettings_MaxFileSize, RedshiftSettings_Password, RedshiftSettings_Port, RedshiftSettings_RemoveQuote, RedshiftSettings_ReplaceChar, RedshiftSettings_ReplaceInvalidChar, RedshiftSettings_ServerName, RedshiftSettings_ServerSideEncryptionKmsKeyId, RedshiftSettings_ServiceAccessRoleArn, RedshiftSettings_TimeFormat, RedshiftSettings_TrimBlank, RedshiftSettings_TruncateColumn, RedshiftSettings_Username, RedshiftSettings_WriteBufferSize, S3Settings_CdcInsertsOnly, S3Settings_DataFormat, S3Settings_DataPageSize, S3Settings_DictPageSizeLimit, S3Settings_EnableStatistic, S3Settings_EncodingType, S3Settings_EncryptionMode, S3Settings_ParquetVersion, S3Settings_RowGroupLength and S3Settings_ServerSideEncryptionKmsKeyId.
    * Modified cmdlet Get-DMSReplicationTask: added parameter WithoutSetting.
    * Modified cmdlet New-DMSEndpoint: added parameters RedshiftSettings_AcceptAnyDate, RedshiftSettings_AfterConnectScript, RedshiftSettings_BucketFolder, RedshiftSettings_BucketName, RedshiftSettings_ConnectionTimeout, RedshiftSettings_DatabaseName, RedshiftSettings_DateFormat, RedshiftSettings_EmptyAsNull, RedshiftSettings_EncryptionMode, RedshiftSettings_FileTransferUploadStream, RedshiftSettings_LoadTimeout, RedshiftSettings_MaxFileSize, RedshiftSettings_Password, RedshiftSettings_Port, RedshiftSettings_RemoveQuote, RedshiftSettings_ReplaceChar, RedshiftSettings_ReplaceInvalidChar, RedshiftSettings_ServerName, RedshiftSettings_ServerSideEncryptionKmsKeyId, RedshiftSettings_ServiceAccessRoleArn, RedshiftSettings_TimeFormat, RedshiftSettings_TrimBlank, RedshiftSettings_TruncateColumn, RedshiftSettings_Username, RedshiftSettings_WriteBufferSize, S3Settings_CdcInsertsOnly, S3Settings_DataFormat, S3Settings_DataPageSize, S3Settings_DictPageSizeLimit, S3Settings_EnableStatistic, S3Settings_EncodingType, S3Settings_EncryptionMode, S3Settings_ParquetVersion, S3Settings_RowGroupLength and S3Settings_ServerSideEncryptionKmsKeyId.
  * Amazon Direct Connect
    * Added cmdlet Confirm-DCDirectConnectGatewayAssociationProposal leveraging the AcceptDirectConnectGatewayAssociationProposal service API.
    * Added cmdlet Get-DCDirectConnectGatewayAssociationProposal leveraging the DescribeDirectConnectGatewayAssociationProposals service API.
    * Added cmdlet New-DCDirectConnectGatewayAssociationProposal leveraging the CreateDirectConnectGatewayAssociationProposal service API.
    * Added cmdlet Remove-DCDirectConnectGatewayAssociationProposal leveraging the DeleteDirectConnectGatewayAssociationProposal service API.
    * Added cmdlet Update-DCDirectConnectGatewayAssociation leveraging the UpdateDirectConnectGatewayAssociation service API.
    * Modified cmdlet Get-DCGatewayAssociation: added parameters AssociatedGatewayId and AssociationId.
    * Modified cmdlet New-DCGatewayAssociation: added parameters AddAllowedPrefixesToDirectConnectGateway and GatewayId.
    * Modified cmdlet Remove-DCGatewayAssociation: added parameter AssociationId.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSTaskSet leveraging the DescribeTaskSets service API.
    * Added cmdlet New-ECSTaskSet leveraging the CreateTaskSet service API.
    * Added cmdlet Remove-ECSTaskSet leveraging the DeleteTaskSet service API.
    * Added cmdlet Update-ECSServicePrimaryTaskSet leveraging the UpdateServicePrimaryTaskSet service API.
    * Added cmdlet Update-ECSTaskSet leveraging the UpdateTaskSet service API.
    * Modified cmdlet Register-ECSTaskDefinition: added parameters ProxyConfiguration_ContainerName, ProxyConfiguration_Property and ProxyConfiguration_Type.
  * Amazon Elastic Beanstalk
    * Modified cmdlet New-EBApplication: added parameter Tag.
    * Modified cmdlet New-EBApplicationVersion: added parameter Tag.
    * Modified cmdlet New-EBConfigurationTemplate: added parameter Tag.
    * Modified cmdlet New-EBPlatformVersion: added parameter Tag.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2InstanceEventStartTime leveraging the ModifyInstanceEventStartTime service API.
    * Modified cmdlet Get-EC2InternetGateway: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-EC2NetworkAcl: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-EC2Vpc: added parameters MaxResult and NextToken.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Update-EKSClusterConfig leveraging the UpdateClusterConfig service API.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter StatusUpdateIntervalInSec.
    * Modified cmdlet New-EMCJobTemplate: added parameter StatusUpdateIntervalInSec.
    * Modified cmdlet Update-EMCJobTemplate: added parameter StatusUpdateIntervalInSec.
  * Amazon Elemental MediaPackage
    * Added cmdlet Add-EMPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-EMPChannel: added parameter Tag.
    * Modified cmdlet New-EMPOriginEndpoint: added parameter Tag.
  * Amazon Elemental MediaStore
    * Added cmdlet Start-EMSAccessLogging leveraging the StartAccessLogging service API.
    * Added cmdlet Stop-EMSAccessLogging leveraging the StopAccessLogging service API.
  * Amazon Firewall Management Service
    * Added cmdlet Get-FMSProtectionStatus leveraging the GetProtectionStatus service API.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLFleet: added parameter InstanceRoleArn.
  * Amazon Glue
    * Modified cmdlet New-GLUEClassifier: added parameters CsvClassifier_AllowSingleColumn, CsvClassifier_ContainsHeader, CsvClassifier_Delimiter, CsvClassifier_DisableValueTrimming, CsvClassifier_Header, CsvClassifier_Name and CsvClassifier_QuoteSymbol.
    * Modified cmdlet New-GLUEDevEndpoint: added parameter Argument.
    * Modified cmdlet Update-GLUEClassifier: added parameters CsvClassifier_AllowSingleColumn, CsvClassifier_ContainsHeader, CsvClassifier_Delimiter, CsvClassifier_DisableValueTrimming, CsvClassifier_Header, CsvClassifier_Name and CsvClassifier_QuoteSymbol.
    * Modified cmdlet Update-GLUEDevEndpoint: added parameters AddArgument and DeleteArgument.
  * Amazon Greengrass
    * Modified cmdlet New-GGFunctionDefinition: added parameters RunAs_Gid and RunAs_Uid.
    * Modified cmdlet New-GGFunctionDefinitionVersion: added parameters RunAs_Gid and RunAs_Uid.
  * Amazon IoT
    * Added cmdlet Get-IOTStatistic leveraging the GetStatistics service API.
    * Modified cmdlet New-IOTOTAUpdate: added parameter Tag.
    * Modified cmdlet New-IOTStream: added parameter Tag.
  * Amazon Lightsail
    * Added cmdlet Remove-LSKnownHostKey leveraging the DeleteKnownHostKeys service API.
  * Amazon Mobile
    * Fixed cmdlet New-MOBLProject not loading.
  * Amazon Pinpoint
    * Added cmdlet Add-PINResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PINResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-PINResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-PINApp: added parameter CreateApplicationRequest_Tag.
    * Modified cmdlet New-PINCampaign: added parameter WriteCampaignRequest_Tag.
    * Modified cmdlet New-PINSegment: added parameter WriteSegmentRequest_Tag.
    * Modified cmdlet Update-PINCampaign: added parameter WriteCampaignRequest_Tag.
    * Modified cmdlet Update-PINSegment: added parameter WriteSegmentRequest_Tag.
  * Amazon QuickSight
    * Added cmdlet Remove-QSUserByPrincipalId leveraging the DeleteUserByPrincipalId service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter CopyTagsToSnapshot.
    * Modified cmdlet New-RDSDBCluster: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter CopyTagsToSnapshot.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMNotebookInstance: added parameter RootAccess.
    * Modified cmdlet Update-SMNotebookInstance: added parameter RootAccess.
  * Amazon Serverless Application Repository
    * Modified cmdlet New-SARApplication: added parameter SourceCodeArchiveUrl.
    * Modified cmdlet New-SARApplicationVersion: added parameter SourceCodeArchiveUrl.
  * Amazon Storage Gateway
    * Modified cmdlet Enable-SGGateway: added parameter Tag.
    * Modified cmdlet New-SGNFSFileShare: added parameter Tag.
    * Modified cmdlet New-SGSMBFileShare: added parameter Tag.
    * Modified cmdlet New-SGTape: added parameter PoolId.
    * Modified cmdlet New-SGTapeWithBarcode: added parameter PoolId.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMServiceSetting leveraging the GetServiceSetting service API.
    * Added cmdlet Reset-SSMServiceSetting leveraging the ResetServiceSetting service API.
    * Added cmdlet Update-SSMServiceSetting leveraging the UpdateServiceSetting service API.
  * Amazon Textract. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TXT and can be listed using the command 'Get-AWSCmdletName -Service TXT'.
  * Amazon Transcribe Service
    * Modified cmdlet New-TRSVocabulary: added parameter VocabularyFileUri.
    * Modified cmdlet Update-TRSVocabulary: added parameter VocabularyFileUri.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameters EndpointDetails_VpcEndpointId and EndpointType.
    * Modified cmdlet Update-TFRServer: added parameters EndpointDetails_VpcEndpointId and EndpointType.

### 3.3.462.0 (2019-02-25)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.462.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Updated AWSPowerShell.NetCore manifest to reference missing assemblies.
  * Enabled pagination support for multiple cmdlets.
  * Amazon Athena
    * Added cmdlet Add-ATHResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ATHResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-ATHWorkGroup leveraging the GetWorkGroup service API.
    * Added cmdlet Get-ATHWorkGroupList leveraging the ListWorkGroups service API.
    * Added cmdlet New-ATHWorkGroup leveraging the CreateWorkGroup service API.
    * Added cmdlet Remove-ATHResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-ATHWorkGroup leveraging the DeleteWorkGroup service API.
    * Added cmdlet Update-ATHWorkGroup leveraging the UpdateWorkGroup service API.
    * Modified cmdlet Get-ATHNamedQueryList: added parameter WorkGroup.
    * Modified cmdlet Get-ATHQueryExecutionList: added parameter WorkGroup.
    * Modified cmdlet New-ATHNamedQuery: added parameter WorkGroup.
    * Modified cmdlet Start-ATHQueryExecution: added parameter WorkGroup.
  * Amazon CloudFront
    * [Breaking Change] Modified cmdlets Get-CFFieldLevelEncryptionConfigList, Get-CFFieldLevelEncryptionProfileList and Get-CFPublicKeyList: enabled pagination support, this required a change of the cmdlets result type.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter Cache_Mode.
    * Modified cmdlet New-CBWebhook: added parameter FilterGroup.
    * Modified cmdlet Start-CBBuild: added parameter CacheOverride_Mode.
    * Modified cmdlet Update-CBProject: added parameter Cache_Mode.
    * Modified cmdlet Update-CBWebhook: added parameter FilterGroup.
  * Amazon CodeCommit
    * Added cmdlet New-CCCommit leveraging the CreateCommit service API.
  * Amazon EC2 Container Service
    * Added cmdlet Write-ECSAccountSettingDefault leveraging the PutAccountSettingDefault service API.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter TagSpecification.
  * Amazon Directory Service
    * Modified cmdlet Connect-DSDirectory: added parameter Tag.
    * Modified cmdlet New-DSDirectory: added parameter Tag.
    * Modified cmdlet New-DSMicrosoftAD: added parameter Tag.
  * Amazon Elastic File System
    * Added cmdlet Get-EFSLifecycleConfiguration leveraging the DescribeLifecycleConfiguration service API.
    * Added cmdlet Write-EFSLifecycleConfiguration leveraging the PutLifecycleConfiguration service API.
    * Modified cmdlet New-EFSFileSystem: added parameter Tag.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameter ZoneAwarenessConfig_AvailabilityZoneCount.
    * Modified cmdlet Update-ESDomainConfig: added parameter ZoneAwarenessConfig_AvailabilityZoneCount.
  * Amazon Elemental MediaLive
    * Added cmdlet Add-EMLResourceTag leveraging the CreateTags service API.
    * Added cmdlet Get-EMLResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMLResourceTag leveraging the DeleteTags service API.
    * Modified cmdlet New-EMLChannel: added parameter Tag.
    * Modified cmdlet New-EMLInput: added parameters Tag, Vpc_SecurityGroupId and Vpc_SubnetId.
    * Modified cmdlet New-EMLInputSecurityGroup: added parameter Tag.
    * Modified cmdlet Update-EMLInputSecurityGroup: added parameter Tag.
  * Amazon Elemental MediaTailor
    * Added cmdlet Add-EMTResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMTResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMTResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter Tag.
  * Amazon GameLift Service
    * Added cmdlet Remove-GMLMatchmakingRuleSet leveraging the DeleteMatchmakingRuleSet service API.
  * Amazon DynamoDB
    * [Breaking Change] Modified cmdlets Get-DDBBackupList and Get-DDBGlobalTableList: enabled pagination support, this required a change of the cmdlets result type.
  * Amazon Glue
    * Added cmdlet Add-GLUEResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GLUECrawlerBatch leveraging the BatchGetCrawlers service API.
    * Added cmdlet Get-GLUECrawlerNameList leveraging the ListCrawlers service API.
    * Added cmdlet Get-GLUEDevEndpointBatch leveraging the BatchGetDevEndpoints service API.
    * Added cmdlet Get-GLUEDevEndpointNameList leveraging the ListDevEndpoints service API.
    * Added cmdlet Get-GLUEJobBatch leveraging the BatchGetJobs service API.
    * Added cmdlet Get-GLUEJobNameList leveraging the ListJobs service API.
    * Added cmdlet Get-GLUETag leveraging the GetTags service API.
    * Added cmdlet Get-GLUETriggerBatch leveraging the BatchGetTriggers service API.
    * Added cmdlet Get-GLUETriggerNameList leveraging the ListTriggers service API.
    * Added cmdlet Remove-GLUEResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GLUECrawler: added parameter Tag.
    * Modified cmdlet New-GLUEDevEndpoint: added parameter Tag.
    * Modified cmdlet New-GLUEJob: added parameter Tag.
    * Modified cmdlet New-GLUETrigger: added parameter Tag.
  * Amazon IoT
    * [Breaking Change] Modified cmdlet Get-IOTThingRegistrationTaskReportList: enabled pagination support, this required a change of the cmdlet result type.
    * Modified cmdlet New-IOTScheduledAudit: added parameter Tag.
    * Modified cmdlet New-IOTSecurityProfile: added parameter AdditionalMetricsToRetain.
    * Modified cmdlet Update-IOTSecurityProfile: added parameters AdditionalMetricsToRetain, DeleteAdditionalMetricsToRetain, DeleteAlertTarget and DeleteBehavior.
  * Amazon Kinesis Video Streams
    * Modified cmdlet New-KVStream: added parameter Tag.
  * Amazon Redshift
    * [Breaking Change] Modified cmdlet Get-RSDefaultClusterParameter: enabled pagination support, this required a change of the cmdlet result type.
  * Amazon Relational Database Service
    * [Breaking Change] Modified cmdlet Get-RDSEngineDefaultParameter: enabled pagination support, this required a change of the cmdlet result type.
  * Amazon RoboMaker
    * Added cmdlet Add-ROBOResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ROBOResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ROBOResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-ROBODeploymentJob: added parameter Tag.
    * Modified cmdlet New-ROBOFleet: added parameter Tag.
    * Modified cmdlet New-ROBORobot: added parameter Tag.
    * Modified cmdlet New-ROBORobotApplication: added parameter Tag.
    * Modified cmdlet New-ROBOSimulationApplication: added parameter Tag.
    * Modified cmdlet New-ROBOSimulationJob: added parameter Tag.
  * Amazon Step Functions
    * Modified cmdlet New-SFNActivity: added parameter Tag.
    * Modified cmdlet New-SFNStateMachine: added parameter Tag.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMActivation: added parameter Tag.
    * Modified cmdlet New-SSMDocument: added parameter Tag.
    * Modified cmdlet New-SSMMaintenanceWindow: added parameter Tag.
    * Modified cmdlet New-SSMPatchBaseline: added parameter Tag.
    * Modified cmdlet Write-SSMParameter: added parameter Tag.

### 3.3.450.0 (2019-02-06)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.450.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Fixed all autopaginating cmdlets so that specifying -NextToken $null correctly enables manual control of pagination.
  * Amazon API Gateway Management API. Added cmdlets to support the service. Amazon API Gateway Management API allows you to directly manage runtime aspects of your APIs. Cmdlets for the service have the noun prefix AGM and can be listed using the command 'Get-AWSCmdletName -Service AGM'.
  * Amazon API Gateway V2. Added cmdlets to support the service. Amazon API Gateway V2 allows you to programmatically setup and manage WebSocket APIs end to end. Cmdlets for the service have the noun prefix AG2 and can be listed using the command 'Get-AWSCmdletName -Service AG2'.
  * Amazon Application Discovery Service
    * Added cmdlet Get-ADSImportTask leveraging the DescribeImportTasks service API.
    * Added cmdlet Remove-ADSImportDataBatch leveraging the BatchDeleteImportData service API.
    * Added cmdlet Start-ADSImportTask leveraging the StartImportTask service API.
  * Amazon AppStream
    * Modified cmdlet New-APSFleet: added parameter Tag.
    * Modified cmdlet New-APSImageBuilder: added parameter Tag.
    * Modified cmdlet New-APSStack: added parameter Tag.
  * Amazon Backup. Added cmdlets to support the service. Amazon Backup is a unified backup service designed to protect AWS services and their associated data. Amazon Backup simplifies the creation, migration, restoration, and deletion of backups, while also providing reporting and auditing. Cmdlets for the service have the noun prefix BAK and can be listed using the command 'Get-AWSCmdletName -Service BAK'.
  * Amazon Certificate Manager Private Certificate Authority
    * Modified cmdlet New-PCACertificateAuthority: added parameter Tag.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters Environment_ImagePullCredentialsType, RegistryCredential_Credential and RegistryCredential_CredentialProvider.
    * Modified cmdlet Start-CBBuild: added parameters ImagePullCredentialsTypeOverride, RegistryCredentialOverride_Credential and RegistryCredentialOverride_CredentialProvider.
    * Modified cmdlet Update-CBProject: added parameters Environment_ImagePullCredentialsType, RegistryCredential_Credential and RegistryCredential_CredentialProvider.
  * Amazon Cognito Identity Provider
    * Added cmdlet Update-CGIPUserPoolDomain leveraging the UpdateUserPoolDomain service API.
  * Amazon Comprehend
    * Added cmdlet Stop-COMPTrainingDocumentClassifier leveraging the StopTrainingDocumentClassifier service API.
    * Added cmdlet Stop-COMPTrainingEntityRecognizer leveraging the StopTrainingEntityRecognizer service API.
  * Amazon Device Farm
    * Modified cmdlet New-DFDevicePool: added parameter MaxDevice.
    * Modified cmdlet Update-DFDevicePool: added parameters ClearMaxDevice and MaxDevice.
  * Amazon DocumentDB. Added cmdlets to support the service. Amazon DocumentDB (with MongoDB compatibility) is a fast, reliable, and fully-managed database service. Amazon DocumentDB makes it easy for developers to set up, run, and scale MongoDB-compatible databases in the cloud. Cmdlets for the service have the noun prefix DOC and can be listed using the command 'Get-AWSCmdletName -Service DOC'.
  * Amazon EC2 Container Registry
    * Added cmdlet Add-ECRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ECRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ECRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-ECRRepository: added parameter Tag.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Add-EC2SecurityGroupToClientVpnTargetNetwork leveraging the ApplySecurityGroupsToClientVpnTargetNetwork service API.
    * Added cmdlet Edit-EC2ClientVpnEndpoint leveraging the ModifyClientVpnEndpoint service API.
    * Added cmdlet Export-EC2ClientVpnClientCertificateRevocationList leveraging the ExportClientVpnClientCertificateRevocationList service API.
    * Added cmdlet Export-EC2ClientVpnClientConfiguration leveraging the ExportClientVpnClientConfiguration service API.
    * Added cmdlet Get-EC2ClientVpnAuthorizationRule leveraging the DescribeClientVpnAuthorizationRules service API.
    * Added cmdlet Get-EC2ClientVpnConnection leveraging the DescribeClientVpnConnections service API.
    * Added cmdlet Get-EC2ClientVpnEndpoint leveraging the DescribeClientVpnEndpoints service API.
    * Added cmdlet Get-EC2ClientVpnRoute leveraging the DescribeClientVpnRoutes service API.
    * Added cmdlet Get-EC2ClientVpnTargetNetwork leveraging the DescribeClientVpnTargetNetworks service API.
    * Added cmdlet Grant-EC2ClientVpnIngress leveraging the AuthorizeClientVpnIngress service API.
    * Added cmdlet Import-EC2ClientVpnClientCertificateRevocationList leveraging the ImportClientVpnClientCertificateRevocationList service API.
    * Added cmdlet New-EC2ClientVpnEndpoint leveraging the CreateClientVpnEndpoint service API.
    * Added cmdlet New-EC2ClientVpnRoute leveraging the CreateClientVpnRoute service API.
    * Added cmdlet Register-EC2ClientVpnTargetNetwork leveraging the AssociateClientVpnTargetNetwork service API.
    * Added cmdlet Remove-EC2ClientVpnEndpoint leveraging the DeleteClientVpnEndpoint service API.
    * Added cmdlet Remove-EC2ClientVpnRoute leveraging the DeleteClientVpnRoute service API.
    * Added cmdlet Revoke-EC2ClientVpnIngress leveraging the RevokeClientVpnIngress service API.
    * Added cmdlet Stop-EC2ClientVpnConnection leveraging the TerminateClientVpnConnections service API.
    * Added cmdlet Unregister-EC2ClientVpnTargetNetwork leveraging the DisassociateClientVpnTargetNetwork service API.
    * Modified cmdlet Edit-EC2InstancePlacement: added parameter PartitionNumber.
    * Modified cmdlet Get-EC2SpotInstanceRequest: enabled pagination support.
    * Modified cmdlet Get-EC2VpcPeeringConnection: enabled pagination support.
    * Modified cmdlet New-EC2Fleet: added parameters OnDemandOptions_SingleAvailabilityZone and SpotOptions_SingleAvailabilityZone.
    * Modified cmdlet New-EC2PlacementGroup: added parameter PartitionCount.
  * Amazon Elemental MediaConnect
    * Added cmdlet Add-EMCNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMCNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMCNResourceTag leveraging the UntagResource service API.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter AccelerationSettings_Mode.
    * Modified cmdlet New-EMCJobTemplate: added parameter AccelerationSettings_Mode.
    * Modified cmdlet Update-EMCJobTemplate: added parameter AccelerationSettings_Mode.
  * Amazon Firewall Management Service
    * Modified cmdlet Remove-FMSPolicy: added parameter DeleteAllPolicyResource.
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameter MaxCapacity.
    * Modified cmdlet Start-GLUEJobRun: added parameter MaxCapacity.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameter Tag.
  * Amazon Lightsail
    * Modified cmdlet New-LSDiskSnapshot: added parameter InstanceName.
  * Amazon QuickSight
    * [Breaking Change] The response data from the corresponding service's API has been extended. The output from the corresponding Register-QSUser cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Register-QSUser).User_ in place of _Register-QSUser_.
  * Amazon Rekognition
    * [Breaking Change] The response data from the corresponding service's API has been extended. The output from the corresponding Find-REKModerationLabel cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Find-REKModerationLabel).ModerationLabels_ in place of _Find-REKModerationLabel_.
  * Amazon Relational Database Service
    * Added cmdlet Add-RDSRoleToDBInstance leveraging the AddRoleToDBInstance service API.
    * Added cmdlet Remove-RDSRoleFromDBInstance leveraging the RemoveRoleFromDBInstance service API.
  * Amazon SageMaker Service
    * Modified cmdlet Get-SMCompilationJobList: added parameters SortBy and SortOrder.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameter TrainingJobDefinition_EnableInterContainerTrafficEncryption.
    * Modified cmdlet New-SMTrainingJob: added parameter EnableInterContainerTrafficEncryption.
  * Amazon Shield
    * Modified cmdlet Get-SHLDProtection: added parameter ResourceArn.
  * Amazon Step Functions
    * Added cmdlet Add-SFNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SFNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SFNResourceTag leveraging the UntagResource service API.
  * Amazon Storage Gateway
    * Added cmdlet Dismount-SGVolume leveraging the DetachVolume service API.
    * Added cmdlet Mount-SGVolume leveraging the AttachVolume service API.
    * Modified cmdlet Join-SGDomain: added parameters DomainController and OrganizationalUnit.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMAssociation: added parameter AutomationTargetParameterName.
    * Modified cmdlet Update-SSMAssociation: added parameter AutomationTargetParameterName.
  * Amazon Simple Workflow Service. Added cmdlets to support the service. Amazon Simple Workflow Service helps developers build, run, and scale background jobs that have parallel or sequential steps. You can think of Amazon SWF as a fully-managed state tracker and task coordinator in the Cloud. Cmdlets for the service have the noun prefix SWF and can be listed using the command 'Get-AWSCmdletName -Service SWF'.
  * Amazon WorkLink. Added cmdlets to support the service. Amazon WorkLink is a fully managed, cloud-based service that enables secure, one-click access to internal websites and web apps from mobile phones. With Amazon WorkLink, employees can access internal websites as seamlessly as they access any other website. IT administrators can manage users, devices, and domains by enforcing their own security and access policies via the AWS Console or the AWS SDK. Cmdlets for the service have the noun prefix WL and can be listed using the command 'Get-AWSCmdletName -Service WL'.

### 3.3.428.0 (2018-12-14)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.428.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.
  * Amazon Alexa For Business
    * Added cmdlet Add-ALXBSkillToUser leveraging the AssociateSkillWithUsers service API.
    * Added cmdlet Get-ALXBBusinessReportScheduleList leveraging the ListBusinessReportSchedules service API.
    * Added cmdlet New-ALXBBusinessReportSchedule leveraging the CreateBusinessReportSchedule service API.
    * Added cmdlet Remove-ALXBBusinessReportSchedule leveraging the DeleteBusinessReportSchedule service API.
    * Added cmdlet Remove-ALXBSkillFromUser leveraging the DisassociateSkillFromUsers service API.
    * Added cmdlet Update-ALXBBusinessReportSchedule leveraging the UpdateBusinessReportSchedule service API.
  * Amazon Amplify
    * Added support for AWS Amplify. AWS Amplify enables developers to develop and deploy cloud-powered mobile and web apps. Cmdlets for the service have the noun prefix AMP and can be listed using the command 'Get-AWSCmdletName -Service AMP'.
  * Amazon App Mesh
    * Added support for AWS App Mesh. AWS App Mesh makes it easy to monitor and control microservices running on AWS. Cmdlets for the service have the noun prefix AMSH and can be listed using the command 'Get-AWSCmdletName -Service AMSH'.
  * Amazon Auto Scaling Plans
    * Added support for AWS Auto Scaling Plans. Use AWS Auto Scaling to quickly discover all the scalable AWS resources for your application and configure dynamic scaling and predictive scaling for your resources using scaling plans. Cmdlets for the service have the noun prefix ASP and can be listed using the command 'Get-AWSCmdletName -Service ASP'.
  * Amazon Chime
    * Added support for Amazon Chime. Amazon Chime is a secure, real-time, unified communications service that transforms meetings by making them more efficient and easier to conduct. The Amazon Chime API (application programming interface) is designed for administrators to use to perform key tasks, such as creating and managing Amazon Chime accounts and users. Cmdlets for the service have the noun prefix CHM and can be listed using the command 'Get-AWSCmdletName -Service CHM'.
  * Amazon CodeBuild
    * Added cmdlet Get-CBSourceCredentialList leveraging the ListSourceCredentials service API.
    * Added cmdlet Import-CBSourceCredential leveraging the ImportSourceCredentials service API.
    * Added cmdlet Remove-CBSourceCredential leveraging the DeleteSourceCredentials service API.
  * Amazon Cognito Sync
    * Added support for Amazon Cognito Sync. Amazon Cognito Sync provides an AWS service and client library that enable cross-device syncing of application-related user data. High-level client libraries are available for both iOS and Android. You can use these libraries to persist data locally so that it's available even if the device is offline. Cmdlets for the service have the noun prefix CGIS and can be listed using the command 'Get-AWSCmdletName -Service CGIS'.
  * Amazon Comprehend Medical
    * Added support for AWS Comprehend Medical. Comprehend Medical extracts structured information from unstructured clinical text. Use these actions to gain insight in your documents. Cmdlets for the service have the noun prefix CMPM and can be listed using the command 'Get-AWSCmdletName -Service CMPM'.
  * Amazon Connect Service
    * Added support for Amazon Connect Service. Amazon Connect is a contact center as a service (CCaS) solution that offers easy, self-service configuration and enables dynamic, personal, and natural customer engagement at any scale. Cmdlets for the service have the noun prefix CONN and can be listed using the command 'Get-AWSCmdletName -Service CONN'.
  * Amazon DataSync
    * Added support for AWS DataSync. AWS DataSync is a managed data transfer service that makes it simpler for you to automate moving data between on-premises storage and Amazon Simple Storage Service (Amazon S3) or Amazon Elastic File System (Amazon EFS). Cmdlets for the service have the noun prefix DSYN and can be listed using the command 'Get-AWSCmdletName -Service DSYN'.
  * Amazon Elastic Container Service for Kubernetes
    * Added support for Amazon Elastic Container Service for Kubernetes. Amazon Elastic Container Service for Kubernetes (Amazon EKS) is a managed service that makes it easy for you to run Kubernetes on AWS without needing to stand up or maintain your own Kubernetes control plane. Kubernetes is an open-source system for automating the deployment, scaling, and management of containerized applications. Cmdlets for the service have the noun prefix EKS and can be listed using the command 'Get-AWSCmdletName -Service EKS'.
  * Amazon Elemental MediaConnect
    * Added support for AWS Elemental MediaConnect. AWS Elemental MediaConnect is a reliable, secure, and flexible transport service for live video. Using AWS Elemental MediaConnect, broadcasters and content owners can cost-effectively send high-value live content into the cloud, securely transmit it to partners for distribution, and replicate it to multiple destinations around the globe. Cmdlets for the service have the noun prefix EMCN and can be listed using the command 'Get-AWSCmdletName -Service EMCN'.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLInput: added parameters MediaConnectFlow and RoleArn.
    * Modified cmdlet Update-EMLInput: added parameters MediaConnectFlow and RoleArn.
  * Amazon Elemental MediaStore
    * Added cmdlet Get-EMSLifecyclePolicy leveraging the GetLifecyclePolicy service API.
    * Added cmdlet Remove-EMSLifecyclePolicy leveraging the DeleteLifecyclePolicy service API.
    * Added cmdlet Write-EMSLifecyclePolicy leveraging the PutLifecyclePolicy service API.
  * Amazon Elemental MediaTailor
    * Added support for AWS Elemental MediaTailor. AWS Elemental MediaTailor is a personalization and monetization service that allows scalable server-side ad insertion. The service enables you to serve targeted ads to viewers while maintaining broadcast quality in over-the-top (OTT) video applications. The service also enables you to track ad views for accurate ad reporting. Cmdlets for the service have the noun prefix EMT and can be listed using the command 'Get-AWSCmdletName -Service EMT'.
  * Amazon FSx
    * Added support for Amazon FSx. Amazon FSx is a fully managed service that makes it easy for storage and application administrators to launch and use shared file storage. Cmdlets for the service have the noun prefix FSX and can be listed using the command 'Get-AWSCmdletName -Service FSX'.
  * Amazon Glacier
    * Added support for Amazon Glacier. Amazon Glacier is a storage service optimized for infrequently used data, or "cold data." The service provides durable and extremely low-cost storage with security features for data archiving and backup. Cmdlets for the service have the noun prefix GLC and can be listed with the command 'Get-AWSCmdletName -Service GLC'.
  * Amazon Global Accelerator
    * Added support for AWS Global Accelerator. AWS Global Accelerator is a network layer service in which you create accelerators to improve availability and performance for internet applications used by a global audience. Cmdlets for the service have the noun prefix GACL and can be listed using the command 'Get-AWSCmdletName -Service GACL'.
  * Amazon Glue
    * Modified cmdlet Get-GLUEConnection: added parameter HidePassword.
    * Modified cmdlet Get-GLUEConnectionList: added parameter HidePassword.
    * Modified cmdlet Set-GLUEDataCatalogEncryptionSetting: added parameters ConnectionPasswordEncryption_AwsKmsKeyId and ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted.
  * Amazon Identity and Access Management
    * Added cmdlet Get-IAMPolicyGrantingServiceAccessList leveraging the ListPoliciesGrantingServiceAccess service API.
    * Added cmdlet Get-IAMServiceLastAccessedDetail leveraging the GetServiceLastAccessedDetails service API.
    * Added cmdlet Get-IAMServiceLastAccessedDetailWithEntity leveraging the GetServiceLastAccessedDetailsWithEntities service API.
    * Added cmdlet Request-IAMServiceLastAccessedDetail leveraging the GenerateServiceLastAccessedDetails service API.
  * Amazon Kinesis Analytics (V2)
    * Added support for V2 of Amazon Kinesis Analytics. Cmdlets for the service have the noun prefix KINA2 and can be listed using the command 'Get-AWSCmdletName -Service KINA2'.
  * Amazon License Manager
    * Added support for AWS License Manager. AWS License Manager streamlines the process of bringing software vendor licenses to the cloud. Cmdlets for the service have the noun prefix LICM and can be listed using the command 'Get-AWSCmdletName -Service LICM'.
  * Amazon Managed Streaming for Kafka (Preview)
    * Added support for Amazon Managed Streaming for Kafka. Amazon Managed Streaming for Kafka (Amazon MSK) is a fully managed service that makes it easy for you to build and run applications that use Apache Kafka to process streaming data. Cmdlets for the service have the noun prefix MSK and can be listed using the command 'Get-AWSCmdletName -Service MSK'.
  * Amazon Mobile
    * Added support for AWS Mobile. AWS Mobile Service provides mobile app and website developers with capabilities required to configure AWS resources and bootstrap their developer desktop projects with the necessary SDKs, constants, tools and samples to make use of those resources. Cmdlets for the service have the noun prefix MOBL and can be listed using the command 'Get-AWSCmdletName -Service MOBL'.
  * Amazon Neptune
    * Added support for Amazon Neptune. Amazon Neptune is a fast, reliable, fully managed graph database service that makes it easy to build and run applications that work with highly connected datasets. Cmdlets for the service have the noun prefix NPT and can be listed with the command 'Get-AWSCmdletName -Service NPT'.
  * Amazon Performance Insights
    * Added support for AWS Performance Insights. AWS Performance Insights enables you to monitor and explore different dimensions of database load based on data captured from a running RDS instance. Cmdlets for the service have the noun prefix PI and can be listed with the command 'Get-AWSCmdletName -Service PI'.
  * Amazon Pinpoint Email
    * Added cmdlet Get-PINEBlacklistReport leveraging the GetBlacklistReports service API.
    * Added cmdlet Get-PINEDeliverabilityDashboardOption leveraging the GetDeliverabilityDashboardOptions service API.
    * Added cmdlet Get-PINEDeliverabilityTestReport leveraging the GetDeliverabilityTestReport service API.
    * Added cmdlet Get-PINEDeliverabilityTestReportList leveraging the ListDeliverabilityTestReports service API.
    * Added cmdlet Get-PINEDomainStatisticsReport leveraging the GetDomainStatisticsReport service API.
    * Added cmdlet New-PINEDeliverabilityTestReport leveraging the CreateDeliverabilityTestReport service API.
    * Added cmdlet Write-PINEDeliverabilityDashboardOption leveraging the PutDeliverabilityDashboardOption service API.
  * Amazon QuickSight
    * Added support for Amazon QuickSight. Amazon QuickSight is a fast, cloud-powered BI service that makes it easy to build visualizations, perform ad hoc analysis, and quickly get business insights from your data. Cmdlets for the service have the noun prefix QS and can be listed using the command 'Get-AWSCmdletName -Service QS'.
  * Amazon RDS DataService
    * Added cmdlet Invoke-RDSDSqlExecution to support the AWS RDS DataService. The AWS RDS DataService provides a Http Endpoint to query RDS databases.  The noun prefix for this service is RDSD which will also be applied to any new APIs this service exposes.
  * Amazon Resource Access Manager
    * Added support for AWS Resource Manager. AWS Resource Access Manager (AWS RAM) enables you to share your resources with any AWS account or organization in AWS Organizations. Customers who operate multiple accounts can create resources centrally and use AWS RAM to share them with all of their accounts to reduce operational overhead. Cmdlets for the service have the noun prefix RAM and can be listed with the command 'Get-AWSCmdletName -Service RAM'.
  * Amazon RoboMaker
    * Added support for AWS RoboMaker. AWS RoboMaker is a service that makes it easy to develop, simulate, and deploy intelligent robotics applications at scale. Cmdlets for the service have the noun prefix ROBO and can be listed with the command 'Get-AWSCmdletName -Service ROBO'.
  * Amazon Route 53 Resolver
    * Added support for Amazon Route 53 Resolver. Cmdlets for the service have the noun prefix R53R and can be listed using the command 'Get-AWSCmdletName -Service R53R'.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameter HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType.
  * Amazon Security Hub
    * Added support for AWS Security Hub service (Preview). AWS Security Hub provides you with a comprehensive view of your security state within AWS and your compliance with the security industry standards and best practices. Security Hub collects security data from across AWS accounts, services, and supported third-party partners and helps you analyze your security trends and identify the highest priority security issues. Cmdlets for the service have the noun prefix SHUB and can be listed using the command 'Get-AWSCmdletName -Service SHUB'.
  * Amazon Transfer for SFTP
    * Added support for AWS Transfer for SFTP. AWS Transfer is a fully managed service that enables the transfer of files over the Secure File Transfer Protocol (SFTP) directly into and out of Amazon Simple Storage Service (Amazon S3). Cmdlets for the service have the noun prefix TFR and can be listed using the command 'Get-AWSCmdletName -Service TFR'.

### 3.3.422.0 (2018-12-06)
  * Amazon CloudDirectory
    * [Breaking Change] The service output for the APIs called by the Get-CDIRObjectParent cmdlet has been updated and it is no longer possible for these cmdlets to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon EC2
    * [Breaking Change] The response data from the service's CreateFleet API has been extended to emit the instances launched in the API response.
    * Added and updated cmdlets:
      * Transit Gateway helps easily scale connectivity across thousands of Amazon VPCs, AWS accounts, and on-premises networks.
      * Added the AvailabilityZoneId parameter to Get-AvailabilityZone cmdlet.
      * VM Import/Export now supports generating encrypted EBS snapshots, as well as AMIs backed by encrypted EBS snapshots during the import process.
      * With On-Demand Capacity Reservations, customers can reserve the exact EC2 capacity they need, and can keep it only for as long as they need it.
      * Provides customers the ability to Bring Your Own IP (BYOIP) prefix. You can bring part or all of your public IPv4 address range from your on-premises network to your AWS account. You continue to own the address range, but AWS advertises it on the internet.
    * Updated cmdlet Get-EC2ReservedInstancesModification to add pagination support.
  * Amazon ECS
    * [Breaking Change] The response data from the service's DescribeTaskDefinition API has been extended to emit both the task definition and the tags that are applied to it. The output from the corresponding Get-TaskDefinitionDetail cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-TaskDefinitionDetail).TaskDefinition_ in place of _Get-TaskDefinitionDetail_.
    * Added and updated cmdlets.
      * This release of Amazon Elastic Container Service (Amazon ECS) introduces support for additional Docker flags as Task Definition parameters. Customers can now configure their ECS Tasks to use pidMode (pid) and ipcMode (ipc) Docker flags.
      * ECS now supports integration with Systems Manager Parameter Store for injecting runtime secrets.
      * ECS introduces support for resources tagging. 
      * ECS introduces a new ARN and ID Format for its resources, and provides new APIs for opt-in to the new formats.
      * ECS introduces support for blue/green deployment feature
  * Amazon ResourceGroups
    * [Breaking Change] The service output for the APIs called by the Get-RGGroupResourceList and Find-RGResource APIs cmdlets has been updated and it is no longer possible for these cmdlets to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon Translate
    * [Breaking Change] The response data from the service's TranslateText API has been extended to emit both the translated text and terminology names. The output from the corresponding ConvertTo-TRNTargetLanguage cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(ConvertTo-TRNTargetLanguage).Text_ in place of _ConvertTo-TRNTargetLanguage_.
    * Added and updated cmdlet supporting custom terminology. Using custom terminology with your translation requests enables you to make sure that your brand names, character names, model names, and other unique content is translated exactly the way you need it, regardless of its context and the Amazon Translate algorithm's decision.
  * Amazon AlexaForBusiness
    * Added and updated cmdlets to extend the functionality of the Alexa for Business SDK, including additional support for third-party Alexa built-in devices, managing private and public skills, and conferencing setup.
  * Amazon AppSync
    * Added and updated cmdlets. AWS AppSync now supports:
      1. Pipeline Resolvers - Enables execution of one or more operations against multiple data sources in order, on a single GraphQL field. This allows orchestration of actions by composing code into a single Resolver, or share code across Resolvers.
      2. Aurora Serverless Data Source - Built-in resolver for executing GraphQL operations with the new Aurora Serverless Data API, including connection management functionality.
  * Amazon Auto Scaling
    * Updated cmdlets New-ASAutoScalingGroup and Update-ASAutoScalingGroup to allow users to provision and automatically scale instances across purchase options (Spot, On-Demand, and RIs) and instance types in a single Auto Scaling group (ASG).
  * Amazon Batch
    * Updated cmdlet New-BATComputeEnvironment adding EC2 Launch Template support.
    * Updated cmdlets Get-BATJobsList, New-BATComputeEnvironment, Register-BATJobDefinition and Submit-BATJob adding support for multinode parallel jobs, placement group support for compute environments.
  * Amazon Budgets
    * Added Get-BGTBudgetPerformanceHistory cmdlet enabling you to see how well your budgets matched your actual costs and usage.
    * Updated cmdlets adding budget performance history, notification state, and last updated time, enabling you to see how well your budgets matched your actual costs and usage, how often your budget alerts triggered, and when your budget was last updated.
  * Amazon CloudFormation
    * Added cmdlets Get-CFNDetectedStackResourceDrift, Get-CFNStackDriftDetectionStatus, Get-CFNStackResourceDrift and Start-CFNStackDriftDetection. The Drift Detection feature enables customers to detect whether a stack's actual configuration differs, or has drifted, from its expected configuration as defined within AWS CloudFormation.
  * Amazon CloudFront
    * Updated cmdlets New-CFDistribution, New-CFDistributionWithTag and Update-CFDistribution adding Origin Failover capability in CloudFront, you can setup two origins for your distributions - primary and secondary, such that your content is served from your secondary origin if CloudFront detects that your primary origin is unavailable. These origins can be any combination of AWS origins or non-AWS custom HTTP origins.
  * Amazon CloudTrail
    * Updated cmdlets New-CTTrail and Update-CTTrail supporting creation of a trail in CloudTrail that logs events for all AWS accounts in an organization in AWS Organizations.
  * Amazon CloudWatch
    * Updated cmdlets Get-EBEnvironmentManagedActionHistory and Get-EBInstanceHealth to add pagination support.
    * Updated cmdlet Write-CWMetricAlarm supporting alarms on metric math expressions.
  * Amazon CloudWatchEvents
    * Updated cmdlets Remove-CWERule and Remove-CWETarget by adding Enforce paramter
  * Amazon CloudWatchLogs
    * Added cmdlets Get-CWLQuery, Get-CWLLogGroupField, Get-CWLLogRecord, Get-CWLQueryResult, Start-CWLQuery, Stop-CWLQuery supporting CloudWatch Logs Insights
  * Amazon CodeBuild
    * Updated cmdlets New-CBProject, Start-CBBuild and Update-CBProject adding queue phase and configurable queue timeout to CodeBuild.
  * Amazon CodeDeploy
    * Added cmdlets Get-CDDeploymentTargetBatch, Get-CDDeploymentTarget, Get-CDDeploymentTargetList supporting Amazon ECS deployment.
  * Amazon CodePipeline
    * Updated cmdlet Start-CPPipelineExecution adding the ClientRequestToken parameter: the system-generated unique ID used to identify a unique execution request.
  * Amazon CodeStar
    * Added New-CSTProject cmdlet allowing to create projects from source code and a toolchain definition that you provide.
  * Amazon Comprehend
    * Added and updated cmdlets:
      * Custom Entities automatically trains entity recognition models using your entities and noun-based phrases.
      * Custom Classification automatically trains classification models using your text and custom labels.
  * Amazon ConfigService
    * Added cmdlets Get-CFGAggregateDiscoveredResourceCount, Get-CFGAggregateDiscoveredResourceList, Get-CFGAggregateResourceConfig and Get-CFGAggregateResourceConfigBatch providing support for aggregating the configuration data of AWS resources into multi-account and multi-region aggregators.
  * Amazon CostExplorer
    * Added cmdlet Get-CECostForecast which allows you to programmatically access AWS Cost Explorer's forecasting engine.
    * Updated cmdlet Get-CEReservationCoverage adding normalized unit support.
  * Amazon DatabaseMigrationService
    * Updated cmdlets Edit-DMSEndpoint, New-DMSEndpoint and New-DMSReplicationInstance to support Kinesis and Elasticsearch as targets.
  * Amazon DeviceFarm
    * Updated cmdlet Get-DFDeviceList and Submit-DFTestRun allowing to schedule runs without a need to create a Device Pool.
  * Amazon DirectConnect
    * Updated cmdlet Remove-DCBGPPeer adding BgpPeerId parameter.
  * Amazon DLM
    * Amazon Data Lifecycle Manager (DLM) for EBS Snapshots provides a simple, automated way to back up data stored on Amazon EBS volumes.
  * Amazon DynamoDB
    * Added cmdlets Write-DDBItemTransactionally and Get-DDBItemTransactionally to support ACID transactions which simplify the developer experience of making coordinated, all-or-nothing changes to multiple items both within and across tables.
    * Updated cmdlets Update-DDBGlobalTableSetting and Update-DDBTable-Cmdlet to support DynamoDB on-demand which offers simple pay-per-request pricing for read and write requests so that you only pay for what you use, making it easy to balance costs and performance.
  * Amazon Elastic Beanstalk
    * Updated cmdlet Get-EBEnvironmentManagedActionHistory and Get-EBInstanceHealth to add pagination support.
  * Amazon Elastic Load Balancing V2
    * Added and updated cmdlets
      * This release allows Application Load Balancers to route traffic to Lambda functions, in addition to instances and IP addresses.
      * ELBv2 now allows you to enable health checks.
  * Amazon Greengrass
    * Added and updated cmdlets supporting bulk deployment operations, Greengrass Connectors and allowing Lambda functions to run without Greengrass containers.
  * Amazon IdentityManagement
    * Added and updated cmdlets making it easier for you to manage your AWS Identity and Access Management (IAM) resources by enabling you to add tags to your IAM principals (users and roles). Adding tags on IAM principals will enable you to write fewer policies for permissions management and make policies easier to comprehend.  Additionally, tags will also make it easier for you to grant access to AWS resources.
  * Amazon IoT
    * Added and updated cmdlets.
      * We are extending capability of AWS IoT Rules Engine to support IoT Events rule action. The IoT Events rule action lets you send messages from IoT sensors and applications to IoT Events for pattern recognition and event detection.
      * IoT now supports resource tagging and tag based access control for Billing Groups, Thing Groups, Thing Types, Jobs, and Security Profiles. IoT Billing Groups help you group devices to categorize and track your costs.
      * AWS IoT Device Management introduces Dynamic thing groups, Jobs dynamic rollouts and Device connectivity indexing.
  * Amazon KinesisFirehose
    * Added cmdlets Start-KINFDeliveryStreamEncryption and Stop-KINFDeliveryStreamEncryption allowing you to enable/disable server-side encryption(SSE) for your delivery streams ensuring encryption of data at rest.
    * Updated cmdlet New-KINFDeliveryStream allowing to assign a set of tags to the delivery stream.
  * Amazon Kinesis Video
    * Updated cmdlets to add pagination support.
  * Amazon Kinesis Analytics
    * Updated cmdlets Add-KINAApplicationInput, Add-KINAApplicationOutput, and New-KINAApplication to add improvements to error messages, validations, and more to the Kinesis Data Analytics
  * Amazon KeyManagementService
    * Added and updated cmdlets enabling customers to create and manage dedicated, single-tenant key stores in addition to the default KMS key store. These are known as custom key stores and are deployed using AWS CloudHSM clusters. Keys that are created in a KMS custom key store can be used like any other customer master key in KMS.
  * AWS Lambda
    * Added and updated cmlets to support Lambda Layers and Ruby as a runtime. Lambda Layers are a new type of artifact that contains arbitrary code and data, and may be referenced by zero, one, or more functions at the same time. You can also now develop your AWS Lambda function code using the Ruby programming language.
  * Amazon Lightsail
    * Added and updated cmdlets.
      * Copy instance and disk snapshots within the same AWS Region or from one region to another in Amazon Lightsail.
      * Export Lightsail instance and disk snapshots to Amazon Elastic Compute Cloud (Amazon EC2).
      * Create an Amazon EC2 instance from an exported Lightsail instance snapshot using AWS CloudFormation stacks.
      * Apply tags to filter your Lightsail resources, or organize your costs, or control access.
  * AWS MarketPplace Metering
    * Added cmdlet Register-MMUsage allows sellers to meter and entitle Docker container software use with AWS Marketplace
  * Amazon Macie
    * Amazon Macie is a security service that uses machine learning to automatically discover, classify, and protect sensitive data in AWS.
  * Amazon MediaConvert
    * Added cmdlets Register-EMCCertificate and Unregister-EMCCertificate.
  * Amazon MediaPackage
    * Updated cmdlets EMPOriginEndpoint and EMPOriginEndpoint to support encrypted content keys.
  * Amazon MQ
    * Added cmdlets Get-MQTagList, New-MQTags and, Remove-MQTags and updated cmdlets New-MQBroker and New-MQConfiguration adding support for cost allocation tagging. You can now create, delete, and list tags for AmazonMQ resources.
  * Amazon Pinpoint
    * Added and updated cmdlets.
      * With Amazon Pinpoint Voice, you can use text-to-speech technology to deliver personalized voice messages to your customers. Amazon Pinpoint Voice is a great way to deliver transactional messages to customers. 2. Adding support for Campaign Event Triggers.
      * With Campaign Event Triggers you can now schedule campaigns to execute based on incoming event data and target just the source of the event.
    * Updated cmdlets Send-PINMessage, Send-PINUserMessageBatch and Update-PINEmailChannel allowing to send transactional email.
  * Amazon PinpointEmail
    * You can use Amazon Pinpoint Email to configure and send transactional email from your Amazon Pinpoint account to specific email addresses. Unlike campaign-based email that you send from Amazon Pinpoint, you don't have to create segments and campaigns in order to send transactional email.
  * Amazon Polly
    * Updated cmdlets Get-POLLexiconList and Get-POLVoice to add pagination support.
  * Amazon RDS
    * Added cmdlet Remove-RDSDBInstanceAutomatedBackup and updated cmdlet Remove-RDSDBInstance introducing DB Instance Automated Backups for the MySQL, MariaDB, PostgreSQL, Oracle and Microsoft SQL Server database engines. You can now retain Amazon RDS automated backups (system snapshots and transaction logs) when you delete a database instance. This allows you to restore a deleted database instance to a specified point in time within the backup retention period even after it has been deleted, protecting you against accidental deletion of data.
    * Updated cmdlet New-RDSDBInstanceReadReplica, Restore-RDSDBInstanceFromDBSnapshot and Restore-RDSDBInstanceToPointInTime allowing to specify VPC security groups.
    * Added cmdlets Edit-RDSDBClusterEndpoint, Get-RDSDBClusterEndpoint, New-RDSDBClusterEndpoint and Remove-RDSDBClusterEndpoint enabling Custom Endpoints, a new feature compatible with Aurora Mysql, Aurora PostgreSQL and Neptune that allows users to configure a customizable endpoint that will provide access to their instances in a cluster. 
    * Added cmddlets New-RDSGlobalCluster, Get-RDSGlobalCluster, Edit-RDSGlobalCluster, Remove-RDSGlobalCluster and Remove-RDSFromGlobalCluster to support Amazon Aurora Global Database, a feature that allows a single Amazon Aurora database to span multiple AWS regions. Customers can use the feature to replicate data with no impact on database performance, enable fast local reads with low latency in each region, and improve disaster recovery from region-wide outages.
  * Amazon Redshift
    * Added and updated cmdlets. With this release, Redshift is providing API's for better snapshot management by supporting user defined automated snapshot schedules, retention periods for manual snapshots, and aggregate snapshot actions including batch deleting user snapshots, viewing account level snapshot storage metrics, and better filtering and sorting on the describe-cluster-snapshots API. Automated snapshots can be scheduled to be taken at a custom interval and the schedule created can be reused across clusters. Manual snapshot retention periods can be set at the cluster, snapshot, and cross-region-copy level. The retention period set on a manual snapshot indicates how many days the snapshot will be retained before being automatically deleted.
  * Amazon S3
    * Added and updated cmdlets.
      * S3 Object Lock enables customers to apply Write Once Read Many (WORM) protection to objects in S3 in order to prevent object deletion for a customer-defined retention period.
      * S3 Inventory now supports fields for reporting on S3 Object Lock. "ObjectLockRetainUntilDate", "ObjectLockMode", and "ObjectLockLegalHoldStatus" are now available as valid optional fields.
      * S3 Block Public Access bucket-level APIs. The new Block Public Access settings allow bucket owners to prevent public access to S3 data via bucket/object ACLs or bucket policies.
  * Amazon S3Control
    * Add support for new S3 Block Public Access account-level APIs. The Block Public Access settings allow account owners to prevent public access to S3 data via bucket/object ACLs or bucket policies.
  * Amazon SageMaker
    * Added and updated cmdlets.
      * Amazon SageMaker now has Algorithm and Model Package entities that can be used to create Training Jobs, Hyperparameter Tuning Jobs and hosted Models. 
      *. Subscribed Marketplace products can be used on SageMaker to create Training Jobs, Hyperparameter Tuning Jobs and Models. Notebook Instances and Endpoints can leverage Elastic Inference accelerator types for on-demand GPU computing. 
      * Model optimizations can be performed with Compilation Jobs. Labeling Jobs can be created and supported by a Workforce. Models can now contain up to 5 containers allowing for inference pipelines within Endpoints. 
      * Code Repositories (such as Git) can be linked with SageMaker and loaded into Notebook Instances. 
      * Network isolation is now possible on Models, Training Jobs, and Hyperparameter Tuning Jobs, which restricts inbound/outbound network calls for the container. However, containers can talk to their peers in distributed training mode within the same security group. 
      * A Public Beta Search API was added that currently supports Training Jobs.
  * Amazon ServerMigrationService
    * Added and updated cmdlets supporting multi-server migration to simplify the application migration process. Customers can migrate all their application-specific servers together as a single unit as opposed to moving individual server one at a time.
  * Amazon Service Discovery
    * Added and updated cmlets.
      * Service Discovery now allows friendly names for your cloud resources so that your applications can quickly and dynamically discover them. 
      * When a resource becomes available (for example, an Amazon EC2 instance running a web server), you can register a Service Discovery service instance. Then your application can discover service instances by submitting DNS queries or API calls.
  * Amazon SimpleSystemsManagement
    * Updated cmdlets Get-SSMDocument, Get-SSMDocumentDescription, New-SSMDocument, Start-SSMAutomationExecution and Update-SSMDocument.
  * ServerlessApplicationRepository
    * Added cmdlet New-SARCloudFormationTemplate and Get-SARCloudFormationTemplate and updated cmdlet New-SARCloudFormationChangeSet supporting creating and reading a broader set of AWS CloudFormation templates.
    * Added cmdlet Get-SARApplicationDependencyList supporting nested applications.
    * Updated cmdlets Get-SARApplicationList and Get-SARApplicationVersionList to add pagination support.
  * Amazon ServiceCatalog
    * Added and updated cmdlets allowing integration with AWS Organizations, enabling customers to more easily create and manage a portfolio of IT services across an organization. Administrators can now take advantage of the AWS account structure and account groupings configured in AWS Organizations to share Service Catalog Portfolios increasing agility and reducing risk. With this integration the admin user will leverage the trust relationship that exists within the accounts of the Organization to share portfolios to the entire Organization, a specific Organizational Unit or a specific Account.
  * Amazon Simple Email Service
    * Updated cmdlets Get-SESCustomVerificationEmailTemplateList and Get-SESReceiptRuleSetList to add pagination support.
  * Amazon SimpleNotificationService
    * Updated cmdlet New-SNSTopic adding optional Attributes parameter.
  * Amazon SimpleSystemsManagement
    * Updated cmdlets New-SSMAssociation and Update-SSMAssociation allowing users to select compliance severity to their association.
  * Amazon Step Functions
    * Updated cmdlets to integrate with eight additioanl AWS services:
      * Amazon ECS
      * AWS Fargate
      * Amazon DynamoDB
      * Amazon SNS
      * Amazon SQS
      * AWS Batch
      * AWS Glue
      * Amazon SageMaker
  * Amazon WAFRegional
    * Updated cmdlet Get-WAFRResourceForWebACLList allowing to configure protections for your Amazon API Gateway API.
  * Amazon WorkDocs
    * Added cmdlet Get-WDResource allowing to fetch files and folders from the user's SharedWithMe collection.
    * Updated cmdlet Get-WDActivity supporting additional filters such as the ActivityType and the ResourceId.
  * Amazon WorkSpaces
    * Added and updated cmdlets.
    * Added new APIs to Modify and Describe WorkSpaces client properties for users in a directory. With the new APIs, you can enable/disable remember me option in WorkSpaces client for users in a directory.
    * Added new Bring Your Own License (BYOL) automation APIs. With the new APIs, you can list available management CIDR ranges for dedicated tenancy, enable your account for BYOL, describe BYOL status of your account, and import BYOL images.
    * Added new APIs to describe and delete WorkSpaces images. 
  * Amazon XRay
    * Added and updated cmdlets. Groups build upon X-Ray filter expressions to allow for fine tuning trace summaries and service graph results. You can configure groups by using the AWS X-Ray console or by using the New-XRGroup cmdlet. The addition of groups has extended the available request fields to the Get-XRServiceGraph cmdlet. You can now specify a group name or group ARN to retrieve its service graph.

### 3.3.390.0 (2018-10-22)
  * Cmdlets and parameters are now marked as obsolete if the corresponding service operation or parameter are deprecated.
  * Added support for Set-AWSProxy and Clear-AWSProxy cmdlets to AWSPowerShell.NetCore
  * Amazon Storage Gateway
    * [Breaking Change] The response data from the service's RefreshCache API has been extended to emit both the file share ARN and the notification id.
  * Amazon APIGateway
    * Updated cmdlets Test-AGInvokeMethod and Test-AGInvokeAuthorizer adding support for multi-value parameters.
  * Amazon AppStream
    * Added cmdlets providing support for creating, managing, and deleting users in the AppStream 2.0 user pool.
  * Amazon Auto Scaling
    * DateTime parameters of Get-ASScheduledAction and Write-ASScheduledUpdateGroupAction were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon CloudWatch
    * DateTime parameters of Get-CWAlarmHistory and Get-CWMetricData, Get-CWMetricStatistic were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon CodeCommit
    * Added cmdlets Get-CCFile, Get-CCFolder and Remove-CCFile allowing to get the contents of a file, get the contents of a folder, and delete a file in an AWS CodeCommit repository.
  * Amazon CodeStar
    * Updated cmdlet New-CSTProject enabling to tag CodeStar Projects at creation.
  * Amazon DirectConnect
    * Added cmdlet Update-DCVirtualInterfaceAttribute allowing to modify the MTU value of existing virtual interfaces.
  * Amazon Directory Service
    * Added and updated cmdlets related to launch of cross account for Directory Service and to create a new type of trust for active directory.
  * Amazon EC2
    * DateTime parameters of multiple cmdlets were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
    * Updated cmdlet Get-EC2RouteTable to add pagination support.
  * Amazon Elastic Beanstalk
    * DateTime parameters of Get-EBEnvironment and Get-EBEvent were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon ElastiCache
    * DateTime parameters of Get-ECEvent were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon Elasticsearch
    * Added cmdlets Start-ESElasticsearchServiceSoftwareUpdate and Stop-ESElasticsearchServiceSoftwareUpdate to support customer-scheduled service software updates. When new service software becomes available, you can request an update to your domain and benefit from new features more quickly. If you take no action, we update the service software automatically after a certain time frame.
  * Amazon Glue
    * Added cmdlet Get-GLUEDataCatalogEncryptionSetting. AWS Glue now supports data encryption at rest for ETL jobs and development endpoints. With encryption enabled, when you run ETL jobs, or development endpoints, Glue will use AWS KMS keys to write encrypted data at rest. You can also encrypt the metadata stored in the Glue Data Catalog using keys that you manage with AWS KMS. Additionally, you can use AWS KMS keys to encrypt the logs generated by crawlers and ETL jobs as well as encrypt ETL job bookmarks. Encryption settings for Glue crawlers, ETL jobs, and development endpoints can be configured using the security configurations in Glue. Glue Data Catalog encryption can be enabled via the settings for the Glue Data Catalog.
    * Added cmdlets Set-GLUEResourcePolicy, Get-GLUEResourcePolicy and Remove-GLUEResourcePolicy for creating, updating, reading and deleting Data Catalog resource-based policies.
  * Amazon GuardDuty
    * Updated cmdlets New-GDDetector and Update-GDDetector to support optional FindingPublishingFrequency parameter.
    * Updated cmdlets New-GDThreatIntelSet, New-GDIPSet and New-GDDetector to add an idempotency token parameter.
  * Amazon IoT
    * DateTime parameters of Get-IOTTaskList and Get-IOTViolationEventsList were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
    * Updated cmdlets New-IOTJob, Start-IOTJNextPendingJobExecution and Update-IOTJJobExecution to support job execution timeout functionalities. Customer now can set job execution timeout on the job level when creating a job.
  * Amazon Lightsail
    * Added cmdlets supporting Lightsail managed databases.
  * Amazon MediaConvert
    * Updated New-EMCQueue and Update-EMCQueue to support offering lower prices for predictable, non-urgent workloads, we propose the concept of Reserved Transcode pricing.
  * Amazon MQ
    * Updated cmdlet Update-MQBroker with new parameters AutoMinorVersionUpgrade and EngineVersion to support ActiveMQ 5.15.6, in addition to 5.15.0.
  * Amazon OpsWorksCM
    * Added cmdlet Export-OWCMServerEngineAttribute allowing to export engine specific attributes like the UserData script used for unattended bootstrapping of new nodes that connect to the server. 
  * Amazon RDS
    * DateTime parameters of Get-RDSEvent, Reset-RDSDBCluster, Restore-RDSDBClusterToPointInTime and Restore-RDSDBInstanceToPointInTime were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
    * Updated cmdlets to support Deletion Protection for RDS databases.
  * Amazon Redshift
    * DateTime parameters of Get-RSClusterSnapshot and Get-RSEvent were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon S3
    * DateTime parameters of Copy-S3Object, Get-S3ObjectMetadata and Read-S3Object were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon ServiceCatalog
    * Added cmdlets to support Service Actions. With service actions, you as the administrator can enable end users to perform operational tasks, troubleshoot issues, run approved commands, or request permissions within Service Catalog. Service actions are defined using AWS Systems Manager documents, where you have access to pre-defined actions that implement AWS best practices, such asEC2 stop and reboot, as well as the ability to define custom actions.
  * Amazon Simple Email Service
    * DateTime parameters of Send-SESBounce were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon SimpleSystemsManagement
    * Added and updated cmdlets allowing to interact with maintenance windows.
    * Updated cmdlets New-SSMPatchBaseline and Update-SSMPatchBaseline adding RejectedPatchesAction to enable stricted validation of the rejected Patches List.
  * Amazon StorageGateway
    * Updated cmdlet Invoke-SGCacheRefresh allowing to specify folders and subfolders.
  * Amazon  TranscribeService
    * Added cmdlet Remove-TRSTranscriptionJob allowing to delete completed transcription jobs. 
  * Amazon WorkDocs
    * DateTime parameters of Get-WDActivity were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.

### 3.3.365.0 (2018-09-21)
  * Get-AWSPublicIpAddressRange has been changed to honor proxy configurations provided through Set-AWSProxy.
  * Amazon Firewall Management Service
    * [Breaking Change] The response data from the service's GetAdminAccount API has been extended to emit both the administrator account and the status of the account. The output from the corresponding Get-FMSAdminAccount cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-FMSAdminAccount).AdminAccount_ in place of _Get-FMSAdminAccount_.
    * Added cmdlet Get-FMSMemberAccountList which allows to get all the member accounts belonging to a certain Fire Wall Manager admin account. 
  * Amazon IOT
    * [Breaking Change] The response data from the service's GetIndexingConfiguration API has been extended to emit both the index configuration and the thing indexing configuration. The output from the corresponding Get-IOTIndexingConfiguration cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-IOTIndexingConfiguration).ThingIndexingConfiguration_ in place of _Get-IOTIndexingConfiguration_.
    * [Breaking Change] The response data from the service's SearchIndex API has been extended to emit both the things and the thing groups that match the search query. The output from the corresponding Search-IOTIndex cmdlet has therefore been changed to emit the service
 response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Search-IOTIndex).Things_ in place of _Search-IOTIndex_.
    * Updated cmdlet New-IOTOTAUpdate to allow specifying maximum number of OTA update job executions started per minute.
    * Updated cmdlet Update-IOTIndexingConfiguration to allow specifying the thing group indexing mode.
  * Amazon Cloud HSM V2
    * Added cmdlets Remove-HSM2Backup and Restore-HSM2Backup allowing to delete or restore a specified AWS CloudHSM backup.
  * Amazon CloudWatch
    * Added cmdlet Get-CWMetricWidgetImage which provides the ability to request png image snapshots of metric widgets.
  * Amazon Cognito Identity Provider
    * Updated cmdlet New-CGIPUserPoolDomain adding support for creating custom domains for our hosted UI for User Pools.
  * Amazon Directory Service
    * Added cmdlets New-DSLogSubscription, Remove-DSLogSubscription and Get-DSLogSubscriptionList. Customers can now opt in to have Windows security event logs from the domain controllers forwarded to a log group in their account.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBEndpoint.
  * Amazon ElastiCache
    * Added cmdlets Request-ECReplicaCountDecrease and Request-ECReplicaCountIncrease which allow adding and removing read-replicas from any cluster with no cluster downtime.
  * Amazon Elemental MediaLive
    * Added cmdlets Update-EMLScheduleBatch and Get-EMLSchedule allowing scheduling actions for SCTE-35 message insertion and for static image overlays.
  * Amazon Elemental MediaPackage
    * Added cmdlet Invoke-EMPIngestEndpointCredentialRotation allowing to rotate the IngestEndpoint's username and password.
  * Amazon Glue
    * Added cmdlets New-GLUESecurityConfiguration, Remove-GLUESecurityConfiguration, Get-GLUESecurityConfiguration and Get-GLUESecurityConfigurationList for creating, updating, reading and deleting Data Catalog resource-based policies.
    * Updated cmdlets New-GLUECrawler, New-GLUEJob and New-GLUEDevEndpoint to allow specifying Encryption settings for Glue crawlers, ETL jobs, and development endpoints.
  * Amazon Rekognition
    * Added cmdlet Get-REKCollection allowing to get information about an existing face collection.
    * Updated cmdlet Add-REKDetectedFacesToCollection introducing a MaxFaces parameter and a QualityFilter parameter that allows you to automatically filter out detected faces that are deemed to be of low quality by Amazon Rekognition.
  * Amazon Relational Database Service
    * Added cmdlets Start-RDSDBCluster, Stop-RDSDBCluster. Stopping and starting Amazon Aurora clusters helps you manage costs for development and test environments. You can temporarily stop all the DB instances in your cluster, instead of setting up and tearing down all the DB instances each time that you use the cluster.
  * Amazon Systems Manager
    * Added cmdlets Get-SSMSession, Get-SSMConnectionStatus, Resume-SSMSession, Start-SSMSession and Stop-SSMSession. Session Manager is a fully managed AWS Systems Manager capability that provides interactive one-click access to Amazon EC2 Linux and Windows instances.
  * Amazon WAF
    * Added cmdlets Remove-WAFLoggingConfiguration, Get-WAFLoggingConfiguration, Get-WAFLoggingConfigurationList and Write-WAFLoggingConfiguration to provide access to all the logs of requests that are inspected by a WAF WebACL.
  * Amazon WAF Regional
    * Added cmdlets Remove-WAFRLoggingConfiguration, Get-WAFRLoggingConfiguration, Get-WAFRLoggingConfigurationList and Write-WAFRLoggingConfiguration to provide access to all the logs of requests that are inspected by a WAF WebACL.
  * Amazon X-Ray
    * Added cmdlets to support managing sampling rules

### 3.3.343.0 (2018-08-23)
  * Application Discovery Service
    * Added cmdlets to support the service's new Continuous Export APIs. Continuous Export APIs allow you to analyze your on-premises server inventory data, including system performance and network dependencies, in Amazon Athena. The new cmdlets are Get-ADSContinousExport (DescribeContinuousExports API), Start-ADSContinuousExport (StartContinuousExport API) and Stop-ADSContinuousExport (StopContinuousExport API).
  * Auto Scaling
    * Added cmdlets to support new batch operations for creating/updating and deleting scheduled scaling actions. The new cmdlets are Remove-ASScheduledActionBatch (BatchDeleteScheduledAction API) and Set-ASScheduledUpdateGroupActionBatch (BatchPutScheduledUpdateGroupAction API).
  * Amazon DynamoDB
    * Updated cmdlets to support new service features for modifying table Server-Side Encryption settings.
  * Amazon Redshift
    * Added cmdlet Set-RSClusterSize to support the new ResizeCluster API. With the new ResizeCluster action, your cluster is available for read and write operations within minutes.
  * Amazon SageMaker
    * Updated cmdlets to support new service feature allowing lifecycle configurations to be associated and disassociated.
  * AWS Device Farm
    * Added and updated cmdlets to support running tests in a custom environment with live logs/video streaming, full test features parity and reduction in overall test execution time. The new cmdlets are Stop-DFJob (StopJob API) and Update-DFUpload (UpdateUpload API).
  * AWS Elasticsearch
    *  Added support for no downtime, in-place upgrade for Elasticsearch version 5.1 and above. The new cmdlets are Get-ESCompatibleElasticsearchVersion (GetCompatibleElasticsearchVersions API), Get-ESUpgradeHistory (GetUpgradeHistory API), Get-ESUpgradeStatus (GetUpgradeStatus API) and Update-ESElasticsearchDomain (UpgradeElasticsearchDomain API).

### 3.3.335.0 (2018-08-13)
  * Amazon DynamoDB
    * Updated the Get-DDBBackupsList cmdlet with new parameter -BackupType to filter the returned backups.
  * Amazon DynamoDB Accelerator (DAX)
    * Updated New-DAXCluster cmdlet to support creation of clusters with server-side encryption.
  * Amazon EC2
    * Updated the New-EC2FlowLog cmdlet to support delivering flow logs directly to Amazon S3.
  * Amazon Pinpoint
    * Updated cmdlets to support updating endpoints.
    * Added Write-PINEvent (PutEvents API) cmdlet to support submission of events.
  * Amazon Relational Database Service
    * Added Edit-RDSCurrentDBClusterCapacity cmdlet, and updated others, to support the new ModifyCurrentDBClusterCapacity API for Aurora Serverless.
  * AWS CloudFormation
    * Fixed issue with missing parameters for ChangeSetType and RollbackConfiguration in New-CFNChangeSet cmdlet.
  * AWS CodeBuild
    * Updated cmdlets to support new service feature enabling semantic versioning.
  * AWS Secrets Manager
    * Updated the Remove-SECSecret cmdlet with parameter -DeleteWithNoRecovery. This enables forcing deletion of a secret without any recovery window and maps to the ForceDeleteWithoutRecovery property in the DeleteSecret API.
  * AWS Systems Manager
    * Updated the Start-SSMAutomationExecution cmdlet to support Automation Execution Rate Control based on tags and customized parameter maps. With Automation Execution Rate Control customers can target their resources by specifying a Tag with Key/Value. With customized parameter maps rate control customers can benefit from customization of input parameters.

### 3.3.330.0 (2018-08-06)
  * Amazon Comprehend
    * Updated and added cmdlets to support the new service ability to tokenize (find word boundaries) text and for each word provide a label for the part of speech, using the DetectSyntax operation. This API is useful to analyze text for specific conditions like for example finding nouns and the correlating adjectives to understand customer feedback. The new cmdlets are Find-COMPSyntax (DetectSyntax API) and Find-COMPSyntaxBatch (BatchDetectSyntax API).
  * Amazon DynamoDB
    * Updated the Update-DDBGlobalTableSetting cmdlet to add support for configuring AutoScaling settings for a DynamoDB global table.
  * Amazon EC2
    * Updated cmdlets to add support for two new allocation strategies for EC2/Spot customers -- LowestN for Spot instances, and OD priority for on-demand instances.
  * Amazon Kinesis
    * Updated and added cmdlets to support the new SubscribeToShard and RegisterStreamConsumer APIs which allows for retrieving records on a data stream over HTTP2 with enhanced fan-out capabilities. With this new feature the Java SDK now supports event streaming natively which will allow you to define payload and exception structures on the client over a persistent connection. For more information, see Developing Consumers with Enhanced Fan-Out in the Kinesis Developer Guide. The new cmdlets are Get-KINStreamConsumer (DescribeStreamConsumer API), Get-KINStreamConsumerList (ListStreamConsumers API), Register-KINStreamConsumer (RegisterStreamConsumer API) and Unregister-KINStreamConsumer (DeregisterStreamConsumer API).
  * Amazon MQ
    * Updated cmdlets to support integration with Amazon CloudWatch Logs.
  * Amazon Polly
    * Updated and added cmdlets to support asynchronous synthesis to Amazon S3. The new cmdlets are Get-POLSpeechSynthesisTask (GetSpeechSynthesisTask API), Get-POLSpeechSynthesisTaskList (ListSpeechSynthesisTasks API) and Start-POLSpeechSynthesisTask (StartSpeechSynthesisTask API).
  * Amazon Redshift
    * Updated and added cmdlets to support maintenance tracks. When we make a new version of Amazon Redshift available, we update your cluster during its maintenance window. By selecting a maintenance track, you control whether we update your cluster with the most recent approved release, or with the previous release. The two values for maintenance track are current and trailing. If you choose the current track, your cluster is updated with the latest approved release. If you choose the trailing track, your cluster is updated with the release that was approved previously. The new cmdlet is Get-RSClusterTrack (DescribeClusterTracks API).
  * Amazon S3
    * Added cmdlet Select-S3ObjectContent (SelectObjectContent API) to support Amazon S3 Select. Amazon S3 Select is an Amazon S3 feature that makes it easy to retrieve specific data from the contents of an object using simple SQL expressions without having to retrieve the entire object. With this release the S3 Select API is now generally available in all public regions and supports retrieval of a subset of data using SQL clauses, like SELECT and WHERE, from delimited text files and JSON objects.
  * Amazon SageMaker
    * Updated and added cmdlets to support the capability for customers to run fully-managed, high-throughput batch transform machine learning models with a simple API call. Batch Transform is ideal for high-throughput workloads and predictions in non-real-time scenarios where data is accumulated over a period of time for offline processing.
  * Amazon Transcribe
    * Updated the Start-TRSTranscribeJob cmdlet to support specifying an Amazon S3 output bucket to store the transcription of your audio file.
  * AWS AppStream
    * Updated and added cmdlets to support the new service feature enabling sharing AppStream images across AWS accounts within the same region. The new cmdlet are Get-APSImagePermission (DescribeImagePermissions API), Remove-APSImagePermission (DeleteImagePermission API) and Update-APSImagePermission (UpdateImagePermissions API).
  * AWS AppSync
    * Updated cmdlets to support configuring HTTP endpoints as data sources for your AWS AppSync GraphQL API.
  * AWS Cloud HSM V2
    * Updated and added cmdlets to support copy-backup-to-region, which allows you to copy a backup of a cluster from one region to another. The copied backup can be used in the destination region to create a new AWS CloudHSM cluster as a clone of the original cluster. The new cmdlet is Copy-HSM2BackupToRegion (CopyBackupToRegion API).
  * AWS CodeBuild
    * Updated cmdlets to support disabling encryption and specifying encryption key on build artifacts.
  * AWS Database Migration Service
    * Updated cmdlets to add support for DmsTransfer endpoint type and support for re-validate option in table reload API.
  * AWS Elastic File System
    * Updated and added cmdlets to support instant provisioning of the throughput required for your applications independent of the amount of data stored in your file system, allowing you to optimize throughput for your applications performance needs. The new cmdlet is Update-EFSFileSystem (UpdateFileSystem API).
  * AWS Glue
    * Updated cmdlets to support association of multiple SSH public keys with a development endpoints.
  * AWS Identity and Access Management
    * Updated and added cmdlets to support the IAM delegated administrator feature. This feature enables customers to attach permissions boundary to IAM principals. The IAM principals cannot operate exceeding the permission specified in permissions boundary. The new cmdlets for this feature are Set-IAMRolePermissionsBoundary (PutRolePermissionsBoundary), Set-IAMUserPermissionsBoundary (PutUserPermissionsBoundary API), Remove-IAMRolePermissionsBoundary (DeleteRolePermissionsBoundary API) and Remove-IAMUserPermissionsBoundary (DeleteUserPermissionsBoundary API).
  * AWS Import/Export Snowball
    * Updated and added cmdlets to support the availability of Amazon EC2 compute instances that run on the device. AWS Snowball Edge is a 100-TB ruggedized device built to transfer data into and out of AWS with optional support for local Lambda-based compute functions. With this feature, developers and administrators can run their EC2-based applications on the device providing them with an end to end vertically integrated AWS experience. Designed for data pre-processing, compression, machine learning, and data collection applications, these new instances, called SBE1 instances, feature 1.8 GHz Intel Xeon D processors up to 16 vCPUs, and 32 GB of memory. The SBE1 instance type is available in four sizes and multiple instances can be run on the device at the same time. Customers can now run compute instances using the same Amazon Machine Images (AMIs) that are used in Amazon EC2.
  * AWS IoT
    * Updated and added cmdlets to support the new IoT security service, AWS IoT Device Defender, and extending the capability of AWS IoT to support Step Functions rule action. The AWS IoT Device Defender is a fully managed service that helps you secure your fleet of IoT devices. For more details on this new service, go to https://aws.amazon.com/iot-device-defender. The Step Functions rule action lets you start an execution of AWS Step Functions state machine from a rule.
  * AWS Storage Gateway
    * Updated cmdlets to support creation of stored volumes using AWS KMS keys.
  * AWS Systems Manager
    * Updated and added cmdlets to support attaching labels to history parameter records and reference history parameter records via labels. It also adds Parameter Store integration with AWS Secrets Manager to allow referencing and retrieving AWS Secrets Manager's secrets from Parameter Store.
    * Updated and added cmdlets to support creation and use of service-linked roles to register and edit Maintenance Window tasks.

### 3.3.313.0 (2018-07-09)
  * Amazon Route 53 Auto Naming
    * Added support for the Amazon Route 53 Auto Naming service (Service Discovery). Amazon Route 53 auto naming lets you configure public or private namespaces that your microservice applications run in. When instances of the service become available, you can call the auto naming API to register the instance, and Route 53 automatically creates up to five DNS records and an optional health check. Clients that submit DNS queries for the service receive an answer that contains up to eight healthy records. Cmdlets for the service have the noun prefix SD and can be listed with the command *Get-AWSCmdletName -Service SD*.
  * Amazon CloudFront
    * [Breaking Change] The DeleteServiceLinkedRole api was released in error and has now been removed by the service. Accordingly the Remove-CFServiceLinkedRole cmdlet has been removed from the module. We apologize for any inconvenience caused.
  * Amazon EC2
    * Added parameter -CpuOption to the New-EC2Instance cmdlet to enable optimizing CPU options for your new instance(s). For more details see [Optimizing CPU Options](https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-optimize-cpu.html) in the Amazon EC2 User Guide.
    * Added revised examples for the Get-EC2ConsoleOutput and Grant-EC2SecurityGroupIngress cmdets based on user feedback.
  * Amazon Workpaces
    * Renamed the _-ResourceId_ parameter for the New-WKSTag and Get-WKSTag cmdlets to _-WorkspaceId_ to improve consistency with other Amazon Workspaces cmdlets. A backwards compatible alias of ResourceId has also been applied to this parameter to support existing scripts.
  * Amazon Relational Database Service
    * The name of the cmdlet _Get-RDSReservedDBInstancesOffering_, which maps to the service API _PurchaseReservedDBInstancesOffering_, has been corrected to _New-RDSReservedDBInstancesOfferingPurchase_. The Get verb had been applied incorrectly as this cmdlet/API actually performs a purchase and does not simply return information. An alias for the old name has been included in the module for backwards compatibility but we encourage users of this cmdlet to adopt the new name at their earliest convenience.
    * Updated cmdlets to support new service feature enabling users to specify the retention period for Performance Insights data for RDS instances. You can either choose 7 days (default) or 731 days.
  * Amazon Comprehend
    * Updated cmdlets to support new service feature enabling batch processing of a set of documents stored within an S3 bucket.
  * Amazon ECS
    * Updated cmdlets to support new service feature enabling daemon scheduling capability to deploy one task per instance on selected instances in a cluster.
    * Added parameter _-Enforce_ flag to the Remove-ECSService cmdlet to allow deleting a service without requiring to scale down the number of tasks to zero. This parameter maps to the _Force_ value in the underlying DeleteService API.
  * Amazon Inspector
    * Added cmdlets to support new service feature for viewing and previewing exclusions. Exclusions show which intended security checks are excluded from an assessment, along with reasons and recommendations to fix.
  * Amazon Pinpoint
    * Updated cmdlets to support new service features for creating complex segments and validating phone numbers for SMS messages. It also adds the ability to get or delete endpoints based on user IDs, remove attributes from endpoints, and list the defined channels for an app.
  * Amazon Redshift
    * Updated cmdlets to support new service features. (1) On-demand cluster release version: When Amazon Redshift releases a new cluster version, you can choose to upgrade to that version immediately instead of waiting until your next maintenance window. You can also choose to roll back to a previous version. (2) Upgradeable reserved instance - You can now exchange one Reserved Instance for a new Reserved Instance with no changes to the terms of your existing Reserved Instance (term, payment type, or number of nodes).
  * Amazon SageMaker
    * Added support for Notebook instances and the ability to run hyperparameter tuning jobs. A hyperparameter tuning job will create and evaluate multiple training jobs while tuning algorithm hyperparameters, to optimize a customer specified objective metric.
  * AWS Secrets Manager
    * Updated cmdlets to support new service feature for esource-based policies that attach directly to your secrets. These policies provide an additional way to control who can access your secrets and what they can do with them. For more information, see https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access_resource-based-policies.html in the Secrets Manager User Guide.
  * AWS Shield
    * Added support for DDoS Response Team access management.
  * AWS Storage Gateway
    * Updated cmdlets to support new service features for using Server Message Block (SMB) protocol to store and access objects in Amazon Simple Storage Service (S3).
  * AWS CloudFormation
    * Updated the New-CFNStackSet and Update-CFNStack set with parameters to support filtered updates for StackSets based on accounts and regions (this feature will allow flexibility for the customers to roll out updates on a StackSet based on specific accounts and regions) and to support customized ExecutionRoleName (this feature will allow customers to attach ExecutionRoleName to the StackSet thus ensuring more security and controlling the behavior of any AWS resources in the target accounts).
  * AWS IoT
    * Added cmdlets to support new APIs released by the service: Remove-IOTJob (DeleteJob API) and Remove-IOTJobExecution (DeleteJobExecution API).
    * Updated the Stop-IOTJob cmdlet to support forced cancellation.
    * Added cmdlet Stop-IOTJobExecution (CancelJobExecution API).
  * AWS Systems Manager
    * Added example for the New-SSMAssociation cmdlet.
    * Updated cmdlets to support new service features around sending RunCommand output to CloudWatch Logs, add the ability to view association execution history and execute an association.
  * AWS AppStream
    * Updated cmdlets to support new service feature enabling customers to find their VPC private IP address and ENI ID associated with AppStream streaming sessions.
  * AWS Certificate Manager Private Certificate Authority
    * Updated cmdlets to support new service 'Restore' feature, enabling users to restore a private certificate authority that has been deleted. When you use the Remove-PCACertificateAuthority cmdlet, you can now specify the number of days (7-30, with 30 being the default) in which the private certificate authority will remain in the DELETED state. During this time, the private certificate authority can be restored with the new Restore-PCACertificateAuthority (RestoreCertificateAuthority API) cmdlet and then be returned to the PENDING_CERTIFICATE or DISABLED state, depending upon the state prior to deletion.
  * AWS Cloud Directory
    * Updated cmdlets to support new service 'Flexible Schema' feature. This feature lets customers using new capabilities like: variant typed attributes, dynamic facets and AWS managed Cloud Directory schemas.
  * AWS Glue
    * Updated cmdlets to support new service feature for sending delay notification to Amazon CloudWatch Events when an ETL job runs longer than the specified delay notification threshold.
  * AWS Elemental MediaLive
    * Added and updated cmdlets to support new service features for reserved inputs and outputs. You can reserve inputs and outputs with a 12 month commitment in exchange for discounted hourly rates. Pricing is available at https://aws.amazon.com/medialive/pricing/.
  * AWS Elemental MediaConvert
    * Added cmdlets to support tagging queues, presets, and templates during creation of those resources on MediaConvert.
  * AWS Config
    * Updated cmdlets to support new service feature for retention, allowing you to specify a retention period for your AWS Config configuration items.
  * AWS Directory Service
    * Added cmdlet Reset-DSUserPassword (ResetUserPassword API). Customers can now reset their users' passwords without providing the old passwords in Simple AD and Microsoft AD.

### 3.3.283.0 (2018-05-18)
  * AWS Service Catalog
    * Users can now pass a new option to Get-SCAcceptedPortfolioSharesList called PortfolioShareType with a value of AWS_SERVICECATALOG in order to access Getting Started Portfolios that contain selected products representing common customer use cases.
  * Alexa for Business
    * Added operations for creating and managing address books of phone contacts for use in A4B managed shared devices.
    * Added Get-ALXBDeviceEventList to paginated list of device events (such as ConnectionStatus).
    * Added ConnectionStatus param to Find-ALXBDevice and Start-ALXBDeviceSync.
    * Added new Device status "DEREGISTERED". This release also adds DEVICE_STATUS as the new DeviceEventType.
  * AWS Certificate Manager
    * Updated documentation notes to
      * Replace incorrect userguide links in Add-ACMCertificateTag, Import-ACMCertificate, New-ACMCertificate, Send-ACMValidationEmail and Update-ACMCertificateOption with the correct links.
      * Added comments in Export-ACMCertificate detailing the issuer of a private certificate as the Private Certificate Authority (CA).
  * AWS CodeBuild
    * Added support for more override fields such as CertificateOverride, EnvironmentTypeOverride for Start-CBBuild
    * Added support for idempotency token field (IdempotencyToken) for Start-CBBuild
  * AWS CodePipeline
    * Added new cmdlets to support webhooks in AWS CodePipeline. A webhook is an HTTP notification that detects events in another tool, such as a GitHub repository, and connects those external events to a pipeline. AWS CodePipeline creates a webhook when you use the console to create or edit your GitHub pipeline and deletes your webhook when you delete your pipeline.
  * Amazon DynamoDB
    * Adds two new cmdlets Get-DDBGlobalTableSetting and Update-DDBGlobalTableSetting to get region specific settings for a global table and update settings for a global table respectively. This update introduces new constraints in the New-DDBGlobalTable and Update-DDBGlobalTable. Tables must have the same write capacity units. If Global Secondary Indexes exist then they must have the same write capacity units and key schema.
  * Amazon EC2
    * Added EC2 Fleet cmdlets. Amazon EC2 Fleet is a new feature that simplifies the provisioning of Amazon EC2 capacity across different EC2 instance types, Availability Zones, and the On-Demand, Reserved Instance, and Spot Instance purchase models. With a single call, you can now provision capacity to achieve desired scale, performance, and cost.
  * Amazon Elasticsearch
    * Added Get-ESReservedElasticsearchInstanceList, Get-ESReservedElasticsearchInstanceOfferingList and New-ESReservedElasticsearchInstanceOffering to support Reserved Instances on AWS Elasticsearch.
  * Amazon GameLift
    * AutoScaling Target Tracking scaling simplification along with Start-GMLFleetAction and Stop-GMLFleetAction to suspend and resume automatic scaling at will.
  * Amazon Guard Duty
    * Added new cmdlets for Amazon GuardDuty for creating and managing filters. For each filter, you can specify a criteria and an action. The action you specify is applied to findings that match the specified criteria.
  * Amazon Kinesis Firehose
    * With this release, Amazon Kinesis Data Firehose can convert the format of your input data from JSON to Apache Parquet or Apache ORC before storing the data in Amazon S3. Parquet and ORC are columnar data formats that save space and enable faster queries compared to row-oriented formats like JSON.
  * AWS Organizations
    * Documentation updates for organizations
  * Amazon Relational Database Service
    * Changes to support the Aurora MySQL Backtrack feature. Cmdlets added are Reset-RDSDBCluster and Get-RDSDBClusterBacktrackList
    * Correction to the documentation about copying unencrypted snapshots.
  * Amazon Route53 Domains
    * This release adds a SubmittedSince attribute to Get-R53DOperationList, so you can list operations that were submitted after a specified date and time.
  * Amazon SageMaker
    * SageMaker has added support for VPC configuration for both Endpoints and Training Jobs. This allows you to connect from the instances running the Endpoint or Training Job to your VPC and any resources reachable in the VPC rather than being restricted to resources that were internet accessible.
  * AWS Secrets Manager
    * Documentation updates for Secret Manager
  * Amazon Simple Systems Management
    * Added support for new parameter, DocumentVersion, for Send-SSMCommand. Users can now specify version of SSM document to be executed on the target(s).
  * Amazon WorkSpaces
    * Added new IP Access Control cmdlets. You can now create/delete IP Access Control Groups, add/delete/update rules for IP Access Control Groups, Associate/Disassociate IP Access Control Groups to/from a WorkSpaces Directory, and Describe IP Based Access Control Groups.
    * Added cmdlet Edit-WKSWorkspaceState to change the state of a Workspace, and the ADMIN_MAINTENANCE WorkSpace state.

### 3.3.270.0 (2018-04-25)
  * The CmdletsToExport property in the module manifest has been temporarily set to '*-*' instead of the individual cmdlet names to work around a limitation publishing modules that contain over 4000 cmdlets to the PowerShell Gallery. The net effect of this change is to disable tab completion for cmdlet names unless the module is explicitly imported. We are investigating approaches to work around or fix this issue and will re-instate the list of cmdlets as soon as possible.
  * AWS Secrets Manager
    * Added cmdlets to support the new AWS Secrets Manager service that enables you to store, manage, and retrieve, secrets. Cmdlets for the service have the noun prefix SEC and can be listed with the command *Get-AWSCmdletName -Service SEC*.
  * AWS Certificate Manager Private Certificate Authority
    * Added cmdlets to support the new AWS Certificate Manager (ACM) Private Certificate Authority (CA), a managed private CA service that helps you easily and securely manage the lifecycle of your private certificates. ACM Private CA provides you a highly-available private CA service without the upfront investment and ongoing maintenance costs of operating your own private CA. ACM Private CA extends ACM's certificate management capabilities to private certificates, enabling you to manage public and private certificates centrally. Cmdlets for the service have the noun prefix PCA and can be listed with the command *Get-AWSCmdletName -Service PCA*.
  * Firewall Management Service
    * Added cmdlets to support the Firewall Management Service, a new AWS service that makes it easy for customers to centrally configure WAF rules across all their resources (ALBs and CloudFront distributions) and across accounts. Cmdlets for the service have the noun prefix FMS and can be listed with the command *Get-AWSCmdletName -Service FMS*.
  * AWS Certificate Manager
    * Updated the New-ACMCertificate and added new cmdlet Update-ACMCertificateOption (UpdateCertificateOption API) to support disabling Certificate Transparency logging on a per-certificate basis.
    * Added support for new service features for requesting and exporting private certificates. This API enables you to collect batch amounts of metric data and optionally perform math expressions on the data. With one GetMetricData call you can retrieve as many as 100 different metrics and a total of 100,800 data points.
  * Amazon CloudWatch
    * Added cmdlet Get-CWMetricData to support the new GetMetricData API.
  * Amazon DynamoDB
    * Added cmdlets restore-DDBTableToPointInTime (RestoreTableToPointInTime API) and Update-DDBContinuousBackup (UpdateContinuousBackups API) t o support Point-in-time recovery (PITR) continuous backups of your DynamoDB table data. With PITR, you do not have to worry about creating, maintaining, or scheduling backups. You enable PITR on your table and your backup is available for restore at any point in time from the moment you enable it, up to a maximum of the 35 preceding days. PITR provides continuous backups until you explicitly disable it.
  * AWS Identity and Access Management
    * Updated the New-IAMRole cmdlet with parameter -MaxSessionDuration, and added cmdlet Update-IAMRole (UpdateRole API) to support the new longer role sessions.
  * AWS Cloudwatch Logs
    * Fixed bad links to the service API references in the help details for the service's cmdlets.
  * Amazon Inspector
    * Fixed bad links to the service API references in the help details for the service's cmdlets.
  * Alexa for Business
    * Added cmdlets to support new operations related to creating and managing address books of contacts for use in A4B managed shared devices.
  * AWS CloudFormation
    * Updated cmdlets to support use of a customized AdministrationRole to create security boundaries between different users.
  * Amazon CloudFront
    * Added cmdlets to support Field-Level Encryption to further enhance the security of sensitive data, such as credit card numbers or personally identifiable information (PII) like social security numbers. CloudFront's field-level encryption further encrypts sensitive data in an HTTPS form using field-specific encryption keys (which you supply) before a POST request is forwarded to your origin. This ensures that sensitive data can only be decrypted and viewed by certain components or services in your application stack. Field-level encryption is easy to setup. Simply configure the fields that have to be further encrypted by CloudFront using the public keys you specify and you can reduce attack surface for your sensitive data.
  * Amazon Elasticsearch
    * Updated cmdlets to support Amazon Cognito authentication support to Kibana.
  * AWS Config Service
    * Added support for multi-account multi-region data aggregation features. Customers can create an aggregator (a new resource type) in AWS Config that collects AWS Config data from multiple source accounts and regions into an aggregator account. Customers can aggregate data from individual account(s) or an organization and multiple regions. In this release, AWS Config adds several API's for multi-account multi-region data aggregation.
  * AWS Device Farm
    * Added support for Private Device Management feature. Customers can now manage their private devices efficiently - view their status, set labels and apply profiles on them. Customers can also schedule automated tests and remote access sessions on individual instances in their private device fleet.
    * Added cmdlets to support new service features for VPC endpoints.
  * Amazon WorkMail
    * Added cmdlets to support granting users and groups with "Full Access", "Send As" and "Send on Behalf" permissions on a given mailbox.
  * AWS Glue
    * Updated cmdlets to support timeout values for ETL jobs. With this release, all new ETL jobs have a default timeout value of 48 hours. AWS Glue also now supports the ability to start a schedule or job events trigger when it is created.
  * Amazon Cloud Directory
    * Added cmdlets to support new APIs to fetch attributes within a facet on an object or multiple facets or objects.
  * AWS Batch
    * Added support for specifying timeout when submitting jobs or registering job definitions.
  * AWS Systems Manager
    * Added cmdlets Get-SSMInventoryDeletionList (DescribeInventoryDeletions API) and Remove-SSMInventory (DeleteInventory API).
  * AWS X-Ray
    * Added cmdlets Get-XREncryptionConfig (GetEncryptionConfig API) and Write-XREncryptionConfig (PutEncryptionConfig API) to support managing data encryption settings. Use Write-XREncryptionConfig to configure X-Ray to use an AWS Key Management Service customer master key to encrypt trace data at rest.

### 3.3.253.0 (2018-03-26)
  * Amazon WorkMail
    * Added cmdlets to support the Amazon WorkMail service. Cmdlets for the service have the noun prefix WM and can be listed with the command *Get-AWSCmdletName -Service WM*.
  * Amazon Pinpoint
    * Added cmdlets to support the new service feature enabling endpoint exports from your Amazon Pinpoint projects. The new cmdlets are Get-PINExportJobList (GetExportJobs API), Get-PINSegmentExportJobList (GetSegmentExportJobs API) and New-PINExportJob (CreateExportJob API).
    * Added cmdlet Remove-PINEndpoint to support the new DeleteEndpoint API.
  * Amazon SageMaker
    * Added cmdlets to support the new customizable notebook instance lifecycle configuration APIs. The new cmdlets are Get-SMNotebookInstanceLifecycleConfig (DescribeNotebookInstanceLifecycleConfig API), Get-SMNotebookInstanceLifecycleConfig (ListNotebookInstanceLifecycleConfigs API), New-SMNotebookInstanceLifecycleConfig (CreateNotebookInstanceLifecycleConfig API), Remove-SMNotebookInstanceLifecycleConfig (DeleteNotebookInstanceLifecycleConfig API) and Update-SMNotebookInstanceLifecycleConfig (UpdateNotebookInstanceLifecycleConfig API).
  * AWS Elastic Beanstalk
    * Added new cmdlet Get-EBAccountAttribute to support the new DescribeAccountAttributes API. In this release the API will support quotas for resources such as applications, application versions, and environments.

### 3.3.245.0 (2018-03-02)
  * AWS AppStream
    * Added cmdlet Copy-APSImage to support the new CopyImage API. This API enables customers to copy their Amazon AppStream 2.0 images within and between AWS Regions.
  * Auto Scaling
    * Updated the New-ASAutoScalingGroup and Update-ASAutoScalingGroup cmdlets with a new parameter, -ServiceLinkedRoleARN, to support service linked roles.
  * AWS CodeCommit
    * Added cmdlet Write-CFFile to support the new PutFile API. This API enables customers to add a file directly to an AWS CodeCommit repository without requiring a Git client.
  * AWS Cost Explorer
    * Added cmdlet Get-CEReservationCoverage to support the new GetReservationCoverage API.
  * Amazon EC2
    * Updated the New-EC2Snapshot cmdlet to add suport for tagging EBS snapshots.
  * Serverless Application Repository
    * Updated the New-SARApplication and Update-SARApplication cmdlets to support setting a home page URL for the application.
    * Added cmdlet Remove-SARApplication to support the new DeleteApplication API.
  * AWS WAF
    * Added cmdlets Get-WAFPermissionPolicy (GetPermissionPolicy API) and Remove-WAFPermissionPolicy (DeletePermissionPolicy API).
  * AWS WAF Regional
    * Added cmdlets Get-WAFRPermissionPolicy (GetPermissionPolicy API) and Remove-WAFRPermissionPolicy (DeletePermissionPolicy API).
  * AWS Service Catalog
    * Added cmdlet Remove-SCTagOption to support the new DeleteTagOption API.
  * AWS Storage Gateway
    * Updated the New-SGNFSFileShare and Update-SGNFSFileShare cmdlets to support new service features for file share attributes. Users can now specify the S3 Canned ACL to use for new objects created in the file share and create file shares for requester-pays buckets.

### 3.3.234.0 (2018-02-14)
  (This version was only released as part of the combined AWS Tools for Windows installer. It was not released to the PowerShell Gallery.)
  * AWS AppSync
    * Added cmdlet Update-ASYNApiKey to support the new UpdateApiKey API.
  * Amazon Lex Model Builder Service
    * Added cmdlets Get-LMBImport (GetImport API) and Start-LMBImport (StartImport API) to support the new to export and import your Amazon Lex chatbot definition as a JSON file.

### 3.3.232.0 (2018-02-13)
  * AWS Lambda
    * [Breaking Change] The response data from the service's GetPolicy API has been extended to emit both the policy and revision ID of the policy. The output from the corresponding Get-LMPolicy cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-LMPolicy).Policy_ in place of _Get-LMPolicy_.
    * Updated the Add-LMPermission, Publish-LMVersion, Remove-LMPermission, Update-LMAlias and Update-LMFunctionConfiguration cmdlets to support setting Revision ID on your function versions and aliases, to track and apply conditional updates when you are updating your function version or alias resources.
  * AWS Key Management Service.
    * [Breaking Change] The cmdlet for the service's ListKeyPolicies API had been named in error as Get-KMSKysPolicyList due to a typo. This has now been corrected and the cmdlet name updated to Get-KMSKeyPolicyList.
  * AWS CodeBuild
    * Added new parameters to the Start-CBBuild and Update-CBProject cmdlets to support shallow clone and GitHub Enterprise.
  * AWS Device Farm
    * Updated the New-DFRemoteAccessSession cmdlet to support the service's new InteractionMode setting for the DirectDeviceAccess feature.
  * AWS Elemental MediaLive
    * Updated the New-EMLChannel cmdlet to support the new InputSpecification settings (specification of input attributes is used for channel sizing and affects pricing).
  * Amazon CloudFront
    * Updated the Get-CFCloudFrontOriginAccessIdentityList, Get-CFDistributionList, Get-CFDistributionListByWebACLId, Get-CFInvalidationList and Get-CFStreamDistributionList cmdlets to support automatic pagination of result output. The cmdlets will now make repeated calls to obtain all available data and no longer require users to implement their own pagination logic in scripts or at the command line.
  * Amazon Kinesis
    * Added new cmdlet Get-KINShardList to support the new ListShards service API. Using ListShards a Kinesis Data Streams customer or client can get information about shards in a data stream (including meta-data for each shard) without obtaining data stream level information.
  * AWS OpsWorks
    * Added new cmdlet Get-OPSOperatingSystem to support the new DescribeOperatingSystems API.
  * AWS Glue
    * Added parameters to the New-GLUClassifier and Update-GLUEClassifier cmdlets to support specifying the json paths for customized classifiers. The custom path indicates the object, array or field of the json documents the user would like crawlers to inspect when they crawl json files.
  * AWS Service Catalog
    * [Breaking Change] The response data from the service's DescribeProvisionedProduct api has been changed to emit additional data. The output from the corresponding Get-SCProvisionedProduct cmdlet has therefore been changed to now emit the full service response to the pipeline. To keep the original behavior your scriprs need to be changed to use _(Get-SCProvisionedProduct).ProvisionedProductDetail_ in place of _Get-SCProvisionedProduct_.
    * Added cmdlets to support new APIs: Find-SCProvisionedProduct (SearchProvisionedProduct API), Get-SCProvisionedProductPlan (DescribeProvisionedPlan API), Get-SCProvisionedPlanList (ListProvisionedproductPlans API), New-SCProvisionedproductPlan (CreateProvisionedproductPlan API), Remove-SCProvisionedProductPlan (DeleteProvisionedProductPlan API) and Start-SCProvisionedProductPlanExecution (ExecuteProvisionedProductPlan API).
    * Amazon Systems Manager
      * Updated cmdlets with parameters to support Patch Manager enhancements for configuring Linux repos as part of patch baselines, controlling updates of non-OS security packages and also creating patch baselines for SUSE12.
      * Updated service name in cmdlet help documentation.
  * Amazon AppStream
      * Added parameter -RedirectURL to the New-APSStack and Update-APSStack cmdlets enabling a redirect url to be provided for a stack. Users will be redirected to the link provided by the admin at the end of their streaming session. Update-APSStack also now supports a new parameter enabling attributes to be deleted from a stack.
  * AWS Database Migration Service
    * Added cmdlets to support new APIs for replication instance task logs and rebooting instances. Replication instance task logs allows users to see how much storage each log for a task on a given instance is occupying. The reboot API gives users the option to reboot the application software on the instance and force a fail over for MAZ instances to test robustness of their integration with our service. The new cmdlets are Get-DMSReplicationInstanceTaskLog (DescribeReplicationInstanceTaskLogs API) and Restart-DMSReplicationInstance (RebootReplicationInstance API).
  * Amazon EC2
    * Added cmdlets for new APIs to support determining the longer ID opt-in status of their account. The new cmdlets are Get-EC2AggregatedIdFormat (DescribeAggregatedIdFormat API) and Get-EC2PrincipalIdFormat (DescribePrincipalIdFormat API).
  * Amazon GameLift
    * Added cmdlet Start-GMLMatchBackfill to support the new StartMatchBackfill API. This API allows developers to add new players to an existing game session using the same matchmaking rules and player data that were used to initially create the session.
  * AWS Elemental Media Live
    * Added cmdlet Update-EMLChannel to support the new UpdateChannel API. For idle channels you can now update channel name, channel outputs and output destinations, encoder settings, user role ARN, and input specifications. Channel settings can be updated in the console or with API calls. Please note that running channels need to be stopped before they can be updated. We've also deprecated the 'Reserved' field.
  * AWS Elemental Media Store
    * Added cmdlets Get-EMSCorsPolicy (GetCorsPolicy API), Write-EMSCorsPolicy (PutCorsPolicy API) and Remove-EMSCorsPolicy (DeleteCorsPolicy API) to support per-container CORS configuration.
  * Amazon Cognito Identity Provider
    * Added cmdlet Get-CGIPSigningCertificate to support the new  GetSigningCertificate API.
    * Updated the New-CGIPUserPool and Update-CGIPUserPool cmdlets to support user migration using an AWS Lambda trigger.

### 3.3.225.1 (2018-01-24)
  * Amazon Guard Duty
    * Fixed issue with error 'The request is rejected because an invalid or out-of-range value is specified as an input parameter' being emitted when running cmdlets that map to service apis that support pagination (eg Get-GDDetectorList).

### 3.3.225.0 (2018-01-23)
  * Amazon Transcribe
    * Added cmdlets to support the public preview release of the new Amazon Transcribe service. Cmdlets for the service have the noun prefix TRS and can be listed with the command *Get-AWSCmdletName -Service TRS*.
  * AWS Glue
    * Added cmdlets to support the AWS Glue service. Cmdlets for the service have the noun prefix GLUE and can be listed with the command *Get-AWSCmdletName -Service GLUE*.
  * AWS Cloud9
    * Added examples for all Cloud9 cmdlets.
  * Amazon Relational Database Service
    * Updated the Edit-RDSDBInstance, New-RDSDBInstance, New-RDSDBInstanceReadReplica, Restore-RDSDBInstanceFromDBSnapshot, Restore-RDSDBInstanceFromS3 and Restore-RDSDBInstanceToPointInTime cmdlets with new parameters to support integration with CloudWatch Logs.
  * Amazon SageMaker Service
    * Updated the New-SMEndpointConfig cmdlet with support for specifying a KMS key for volume encryption.
  * AWS Budgets
    * Updated the New-BGTBudget and Update-BGTBudget cmdlets to support additional cost types (IncludeDiscount and UseAmortized) to support finer control for different charges included in a cost budget.

### 3.3.221.0 (2018-01-15)
  * Amazon S3
    * Fixed issue with the Copy-S3Object displaying an error when copying objects between buckets and the object keys started with the '/' character.
  * AWS Lambda
    * Updated cmdlets and argument completers to support the newly released dotnetcore2.0 and go1.x runtimes for Lamba functions.

### 3.3.219.0 (2018-01-12)
  * Amazon EC2
    * Updated the Get-EC2Snapshot and Get-EC2Volume cmdlets to use pagination to process data when a snapshot id or volume id is not supplied. This update should help customers with large numbers of snapshots or volumes who were experiencing timeout issues in previous versions which attempted to use a single call to obtain all data.
    * Added support for pipelining the output launch template object types returned by the the New-EC2LaunchTemplate and New-EC2LaunchTemplateVersion into the same cmdlets, and also into the New-EC2Instance cmdlet.
    * Updated the Get-EC2PasswordData cmdlet to display better error message if used to obtain password before the instance is ready.
  * Get-AWSRegion
    * Updated documentation notes and examples to address confusion as to how this cmdlet handles regions launched after the module is released. The cmdlet uses built-in data to display the list of regions, so won't show new regions launched subsequently, but those new regions can still be used with all cmdlets without requiring an update to the tools.
  * AWS CodeDeploy
    * Added cmdlet Remove-CDGitHubAccountToken to support the new DeleteGitHubAccountToken API.
  * AWS Directory Service
    * Updated the New-DSMicrosoftAD cmdlet to add support for an -Edition parameter. The service now supports Standard and Enterprise (the default) editions of Microsoft Active Directory. Microsoft Active Directory (Standard Edition), also known as AWS Microsoft AD (Standard Edition), is a managed Microsoft Active Directory (AD) that is optimized for small and midsize businesses (SMBs). With this SDK release, you can now create an AWS Microsoft AD directory using API. This enables you to run typical SMB workloads using a cost-effective, highly available, and managed Microsoft AD in the AWS Cloud.
  * Amazon Relational Database Service
    * Updated the New-RDSDBInstanceReadReplica cmdlet with support for Multi AZ deployments.

### 3.3.215.0 (2018-01-02)
  * Amazon API Gateway
    * Added support for tagging resources for cost allocation with new cmdlets Add-AGResourceTag (TagResource API), Get-AGResourceTag (GetTags API) and Remove-AGResourceTag (UntagResource API). The New-AGStage cmdlet was also updated with a new -Tag parameter.
    * Updated the New-AGRestApi cmdlet with parameters to support setting minimum compression size and returning API keys from a custom authorizer for use with a usage plan.
  * Amazon ECS
    * Updated the New-ECSService and Update-ECSService cmdlets to support the new service feature enabling a grace period for health checks to be specified.
  * AWS IoT
    * Added cmdlets to support the new service feature for code signed Over-the-air update functionality for Amazon FreeRTOS. Users can now create and schedule Over-the-air updates to their Amazon FreeRTOS devices using these new APIs.
  * Amazon Kinesis Analytics
    * Updated the Add-KINAApplicationOutput cmdlet to support the new service feature enabling AWS Lambda functions as output.
  * Amazon SageMaker Service
    * *BREAKING CHANGE* The -SupplementalContainer parameter for the New-SMModel cmdlet has been removed as it is no longer supported by the service.
  * Amazon WorkSpaces
    * Updated the Edit-WKSWorkspaceProperty cmdlet to support new service features for flexible storage and switching of hardware bundles.

### 3.3.210.0 (2017-12-19)
  * Amazon AppStream
    * Added support add tags to Amazon AppStream 2.0 resources with new cmdlets Add-APSResourceTag (TagResource API) and Remove-APSResourceTag (UntagResource API).
  * Amazon S3
    * Extended the Copy-S3Object cmdlet to support copying of objects larger than 5GB within S3. The cmdlet previously used the CopyObject API which is limited to objects up to 5GB in size. With this release the cmdlet inspects the object size and switches automatically to multi-part copy if necessary. The output of the cmdlet when copying objects within S3 has also changed; previously the output of the CopyObject API was emitted. With this update an Amazon.S3.Model.S3Object, referencing the newly copied object, is emitted to the pipeline.
  * Added tab completion support for the new EU (Paris), eu-west-3, region to the -Region parameter for cmdlets.

### 3.3.208.1 (2017-12-13)
  * Amazon EC2
    * Fixed issue with Get-EC2PasswordData cmdlet reporting a null reference when invoked without the -PemFile parameter. This parameter is not required if the keypair data for the instance is saved in the configuration store for the AWS Toolkit for Visual Studio.
  * All cmdlets
    * Added support for the new China (Ningxia) region (cn-northwest-1).

### 3.3.208.0 (2017-12-13)
  * AWS Cost Explorer
    * Added support for the AWS Cost Explorer service. AWS Cost Explorer helps you visualize, understand, and manage your AWS costs and usage over time. The Cost Explorer API gives you programmatic access to the full Cost Explorer dataset, including advanced metrics (e.g., Reserved Instance utilization) and your cost allocation tags. Cmdlets for the service have the noun prefix 'CE' and can be listed with the command *Get-AWSCmdletName -Service CE*.
  * AWS Resource Groups
    * Added support for the AWS Resource Groups service announced at AWS re:Invent 2017. A resource group is a collection of AWS resources that are all in the same AWS region, and that match criteria provided in a query. Queries include lists of resources that are specified in the following format *AWS::service::resource*, and tags. Tags are keys that help identify and sort your resources within your organization; optionally, tags include values for keys. Cmdlets for the service have the noun prefix 'RG' and can be listed with the command *Get-AWSCmdletName -Service RG*.
  * Amazon Kinesis Video Streams
    * Added support for the Amazon Kinesis Video Streams service announced at AWS re:Invent 2017. Amazon Kinesis Video Streams is a fully managed AWS service that you can use to stream live video from devices to the AWS Cloud, or build applications for real-time video processing or batch-oriented video analytics. Cmdlets for the service have the noun prefix 'KV' and can be listed with the command *Get-AWSCmdletName -Service KV*.
  * Amazon Kinesis Video Streams Media
    * Added support for the Amazon Kinesis Video Streams Media service announced at AWS re:Invent 2017. Cmdlets for the service have the noun prefix 'KVM' and can be listed with the command *Get-AWSCmdletName -Service KVM*.
  * AWS IoT Jobs Data Plane
    * Added support for the AWS IoT Jobs Data Plane service announced at AWS re:Invent 2017. Cmdlets for the service have the noun prefix 'IOTJ' and can be listed with the command *Get-AWSCmdletName -Service IOTJ*.
  * AWS AppSync
    * Added support for the AWS AppSync service announced at AWS re:Invent 2017. AWS AppSync is an enterprise level, fully managed GraphQL service with real-time data synchronization and offline programming features. Cmdlets for the service have the noun prefix 'ASYN' and can be listed with the command *Get-AWSCmdletName -Service ASYN*.
  * Alexa for Business
    * Added support for the Alexa for Business service announced at AWS re:Invent 2017. Alexa for Business gives you the tools you need to manage Alexa devices, enroll users, and assign skills. You can build your own voice skills using the Alexa Skills Kit and the Alexa for Business API. You can also make them available as private skills for your organization. Cmdlets for the service have the noun prefix 'ALXB' and can be listed with the command *Get-AWSCmdletName -Service ALXB*.
  * AWS Cloud9
    * Added support for the AWS Cloud9 service announced at AWS re:Invent 2017. AWS Cloud9 is a cloud-based integrated development environment (IDE) that you use to write, run, and debug code. Cmdlets for the service have the noun prefix 'C9' and can be listed with the command *Get-AWSCmdletName -Service C9*.
  * AWS Serverless Application Repository
    * Added support for the AWS Serverless Application Repository. With AWS Serverless Application Repository, you can quickly find and deploy serverless applications in the AWS Cloud. You can browse applications by category, or search for them by name, publisher, or event source. Cmdlets for the service have the noun prefix 'SAR' and can be listed with the command *Get-AWSCmdletName -Service SAR*.
  * Amazon SageMaker Service
    * Added support for Amazon SageMaker Service, announced at AWS re:Invent 2017. Amazon SageMaker is a fully managed machine learning service. With Amazon SageMaker, data scientists and developers can quickly and easily build and train machine learning models, and then directly deploy them into a production-ready hosted environment. Cmdlets for the service have the noun prefix 'SM' and can be listed with the command *Get-AWSCmdletName -Service SM*. Cmdlets for the Amazon SameMaker Runtime service have the noun prefix 'SMR' and can be listed with the command *Get-AWSCmdletName -Service SMR*.

### 3.3.205.0 (2017-12-08)
  * Amazon EC2
    * Updated the New-EC2Instance cmdlet to support the new [T2 Unlimited](http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/t2-unlimited.html#launch-t2) feature.
  * Amazon Cloud Directory
    * Added support for new APIs to enable schema changes across your directories with in-place schema upgrades. Your directories now remain available while backward-compatible schema changes are being applied, such as the addition of new fields. You also can view the history of your schema changes in Cloud Directory by using both major and minor version identifiers, which can help you track and audit schema versions across directories. The new cmdlets are Get-CDIRAppliedSchemaVersion (GetAppliedSchemaVersion API), Update-CDIRAppliedSchema (UpgradeAppliedSchema API) and Update-CDIRPublishedSchema (UpgradePublishedSchema API).
  * AWS Budgets
    * Added support for additional cost types to support finer control for different charges included in a cost budget.
  * Amazon Elasticsearch
    * Updated the New-ESDomain cmdlet to add support for encryption of data at rest on Amazon Elasticsearch Service using AWS KMS.
  * Amazon Simple Email Service
    * Added cmdlets to support new service features for customization of the emails that Amazon SES sends when verifying new identities. This feature is helpful for developers whose applications send email through Amazon SES on behalf of their customers.
  * Amazon MQ
    * Added support for the Amazon MQ service launched at AWS re:Invent 2017. Amazon MQ is a managed message broker service for [Apache ActiveMQ](http://activemq.apache.org/) that makes it easy to set up and operate message brokers in the cloud. Cmdlets for the service have the noun prefix 'MQ' and can be listed with the command *Get-AWSCmdletName -Service MQ*.
  * Amazon GuardDuty
    * Added support for the Amazon GuardDuty service launched at AWS re:Invent 2017. Amazon GuardDuty is a continuous security monitoring service that analyzes and processes VPC Flow Logs, AWS CloudTrail event logs, and DNS logs. It uses threat intelligence feeds, such as lists of malicious IPs and domains, and machine learning to identify unexpected and potentially unauthorized and malicious activity within your AWS environment. Cmdlets for the service have the noun prefix 'GD' and can be listed with the command *Get-AWSCmdletName -Service GD*.
  * Amazon Comprehend
    * Added support for the Amazon Comprehend service launched at AWS re:Invent 2017. Amazon Comprehend uses natural language processing (NLP) to extract insights about the content of documents. Amazon Comprehend processes any text file in UTF-8 format. It develops insights by recognizing the entities, key phrases, language, sentiments, and other common elements in a document. Use Amazon Comprehend to create new products based on understanding the structure of documents. For example, using Amazon Comprehend you can search social networking feeds for mentions of products or scan an entire document repository for key phrases. Cmdlets for the service have the noun prefix 'COMP' and can be listed with the command *Get-AWSCmdletName -Service COMP*.
  * Amazon Translate
    * Added support for Amazon Translate service launched at AWS re:Invent 2017. Amazon Translate translates documents from the following six languages into English, and from English into these languages:
        * Arabic
        * Chinese
        * French
        * German
        * Portuguese
        * Spanish
      Cmdlets for the service have the noun prefix 'TRN' and can be listed with the command *Get-AWSCmdletName -Service TRN*.

### 3.3.201.0 (2017-12-02)
  * Updated cmdlets for multiple services to include new APIs and API updates released during AWS re:Invent 2017, for services already supported by the tools. New services launched at the conference will be added to the tools in the coming days. The updated services are:
    * Auto Scaling
    * Amazon API GatewayGateway
    * Amazon DynamoDB
    * Amazon Cognito
    * Amazon Cognito Identity Provider
    * Amazon EC2
    * Amazon Elastic Container Service
    * Amazon Lightsail
    * Amazon Rekognition
    * Amazon Systems Manager
    * AWS Batch
    * AWS CloudFormation
    * AWS CodeDeploy
    * AWS Greengrass
    * AWS IoT
    * AWS Lambda
    * AWS WAF
    * AWS WAF Regional

### 3.3.197.0 (2017-11-27)
  * AWS Elemental Media Convert
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMC'.
  * AWS Elemental Media Live
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EML'.
  * AWS Elemental Media Package
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMP'.
  * AWS Elemental Media Store
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMS'.
  * AWS Elemental Media Data Plane
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMSD'.

### 3.3.196.0 (2017-11-25)
  * AWS Certificate Manager
    * Updated the New-ACMCertificate and Get-ACMCertificateList cmdlets for new service features enabling the ability to import domainless certs and additional Key Types as well as an additional validation method for DNS.
  * Amazon API Gateway
    * Updated the Get-AGDocumentationPartList and Write-AGIntegration cmdlets for new service features enabling support for access logs and customizable integration timeouts.
  * AWS CloudFormation
    * Updated the New-CFNStackInstance cmdlet to support instance-level parameter overrides.
    * Added new cmdlet Update-CFNStackInstance to support the new UpdateStackInstances API.
  * AWS CodeBuild
    * Updated the New-CBProject and Update-CBProject cmdlets to support new service features for accessing Amazon VPC resources from AWS CodeBuild, dependency caching and build badges.
    * Added the cmdlet Reset-CBProjectCache to support the new InvalidateProjectCache API.
  * AWS CodeCommit
    * Added new cmdlets for the new service feature supporting pull requests.
  * AWS Database Migration Service
    * Added cmdlet Start-DMSReplicationTaskAssessment to support the new StartReplicationTaskAssessment API.
  * Amazon ECS
    * Updated the New-ECSTask, New-ECSService, Start-ECSTask and Update-ECSService cmdlets to add support for new mode for Task Networking in ECS, called awsvpc mode.
  * Amazon Elastic Map Reduce
    * Updated the Start-EMRJobFlow cmdlet to support new service feature enabling Kerberos.
  * Amazon Kinesis
    * Added cmdlet Get-KINStreamSummary to support the new DescribeStreamSummary API.
  * Amazon Kinesis Firehose
    * Updated the New-KINFDeliveryStream and Update-KINFDestination cmdlets to support Splunk as Kinesis Firehose delivery destination. You can now use Kinesis Firehose to ingest real-time data to Splunk in a serverless, reliable, and salable manner. This release also includes a new feature that allows you to configure Lambda buffer size in Kinesis Firehose data transformation feature. You can now customize the data buffer size before invoking Lambda function in Kinesis Firehose for data transformation. This feature allows you to flexibly trade-off processing and delivery latency with cost and efficiency based on your specific use cases and requirements.
  * Amazon Lightsail
    * Added cmdlets to support the new service feature enabling attached block storage, which allows you to scale your applications and protect application data with additional SSD-backed storage disks. This feature allows Lightsail customers to attach secure storage disks to their Lightsail instances and manage their attached disks, including creating and deleting disks, attaching and detaching disks from instances, and backing up disks via snapshot.
  * AWS Organizations
    * Added cmdlets to support new service APIs to enable and disable integration with AWS services designed to work with AWS Organizations. This integration allows the AWS service to perform operations on your behalf on all of the accounts in your organization. Although you can use these APIs yourself, we recommend that you instead use the commands provided in the other AWS service to enable integration with AWS Organizations.
  * Amazon Relational Database Service
    * Added new cmdlet Restore-RDSDBInstanceFromS3 to support the new RestoreDBInstanceFromS3 API. This feature supports importing MySQL databases by using backup files from Amazon S3.
  * Amazon Rekognition
    * Added new cmdlet Find-REKText to support the new DetectText service API. This API allows you to recognize and extract textual content from images.
    * Updated cmdlets related to face detection to support the new Face Model Versioning feature.
    * [BREAKING CHANGE] The service output for the APIs called by the Get-REKCollectionIdList and Get-REKFaceList cmdlet has been updated and it is no longer possible for these cmdlets to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon Route53
    * Added cmdlets Get-R53AccountLimit (GetAccountLimit API), Get-R53HostedZoneLimit (GetHostedZoneLimit API) and Get-R53ReusableDelegationSetLimit (GetReusableDelegationSetLimit API). These cmdlets enable you to view your current limits (including custom set limits) on Route 53 resources such as hosted zones and health checks. These APIs also return the number of each resource you're currently using to enable comparison against your current limits.
  * AWS Shield
    * Added cmdlet Get-SHLDSubscriptionState to support the new GetSubscriptionState API.
  * Amazon Simple Email Service
    * Added and updated cmdlets to support new service features enabling Reputation Metrics and Email Pausing Today, two features that build upon the capabilities of the reputation dashboard. The first is the ability to export reputation metrics for individual configuration sets. The second is the ability to temporarily pause email sending, either at the configuration set level, or across your entire Amazon SES account.
  * Amazon EC2 Systems Manager
    * Updated the Get-SSMInventory and Get-SSMInventorySchema cmdlets to support aggregation.
  * Amazon Set Functions
    * Added cmdlets Get-SFNStateMachineForExecution (DescribeStateMachineForExecution API) and Update-SFNStateMachine (UpdateStateMachine API). The new APIs enable you to update your state machine definition and role ARN. Existing executions will continue to use the previous definition and role ARN. You can use the DescribeStateMachineForExecution API to determine which state machine definition and role ARN is associated with an execution.
  * AWS Storage Gateway
    * Updated the New-SGNFileShare and Update-SGNFileShare cmdlets to enable guessing of MIME types for uploaded files based on the file extension.
    * Added cmdlet Send-SGUploadedNotification (NotifyWhenUploaded API). This API enables you to get notification when all your files written to your NFS file share have been uploaded.
  * Amazon WorkDocs
    * Added cmdlet Get-WDGroup to support the new DescribeGroups API.
    * Updated cmdlets to support new service features.

### 3.3.189.1 (2017-11-13)
  * Amazon EC2
    * Added cmdlet New-EC2DefaultSubnet (CreateDefaultSubnet API) enabling creation of a default subnet in an Availability Zone if no default subnet exists.
  * Amazon S3
    * Added parameter -RequesterPay to the Get-S3PresignedUrl cmdlet to support 'requester pays' mode when generating a presigned url.
    * Fixed issue with Test-S3Bucket reporting an exception 'x-amz-security-token cannot be used as both a header and a parameter' when invoked from an EC2 instance launched with an instance profile (this bug was introduced into the 3.3.189.0 release of the AWS SDK for .NET and affected v3.3.189.0 of the AWS Tools for Windows PowerShell, released only as part of the combined AWS Tools for Windows installer).

### 3.3.187.0 (2017-11-09)
  * AWS CloudFormation
    * Fixed issue with the Wait-CFNStack cmdlet not exiting when testing for 'DELETE_COMPLETE' status on a deleted stack.
  * Amazon S3
    * Added support for new bucket encryption APIs with three new cmdlets: Get-S3BucketEncryption (GetBucketEnryption API), Set-S3BucketEncryption (PutBucketEncryption API) and Remove-S3BucketEncryption (DeleteBucketEncryption API).
  * AWS Price List Service
    * Added cmdlets to support the new service. AWS Price List Service API is a centralized and convenient way to programmatically query Amazon Web Services for services, products, and pricing information. Cmdlets for the service have the noun prefix 'PLS' and can be listed using the command 'Get-AWSCmdletName -Service PLS'.
  * AWS Cloud HSM V2
    * Added cmdlets to support the Cloud HSM V2 service. Cmdlets for the service have the noun prefix 'HSM2' and can be listed using the command 'Get-AWSCmdletName -Service HSM2'.
  * Amazon API Gateway
    * Added support for new service features to create and manage regional and edge-optimized API endpoints.
  * Amazon EC2
    * [BREAKING CHANGE] The DescribeVpcEndpointServices service API, called by the cmdlet Get-EC2VpcEndpointService, has been extended to include an extra collection of service names. This additional collection is incompatible with automatic pagination therefore this cmdlet has had to be updated to disable automatic pagination of all results.
  * Application Auto Scaling
    * Added support for new service APIs to enable scheduling adjustments to MinCapacity and MaxCapacity, which makes it possible to pre-provision adequate capacity for anticipated demand and then reduce the provisioned capacity as demand lulls. The new cmdlets are Get-AASScheduledAction (DescribeScheduledActions API), Remove-AASScheduledAction (DeleteScheduledAction API) and Set-AASScheduledAction (PutScheduledAction API).
    * Renamed the existing Write-AASScalingPolicy cmdlet has been renamed to a more appropriate verb, Set-AASScalingPolicy. An alias for backwards compatibility is automatically enabled by the module.
  * Amazon ElastiCacheElastiCache
    * Added cmdlet Edit-ECReplicationGroupShardConfiguration to support the new ModifyReplicationGroupShardConfiguration service API.

### 3.3.181.0 (2017-11-01)
  * Amazon EC2 Systems Manager
    * Fixed bug in the Get-SSMParametersByPath cmdlet preventing automatic pagination.

### 3.3.180.0 (2017-10-30)
  * Amazon CloudFront
    * Added cmdlet Remove-CFServiceLinkedRole for the new DeleteServiceLinkedRole API.
  * AWS Migration Hub
    * Added cmdlets to support the AWS Migration Hub service. Cmdlets for the service have the noun prefix 'MH' and can be listed using the command 'Get-AWSCmdletName -Service MH'. For more information on the service please refer to the service user guide [here](http://docs.aws.amazon.com/migrationhub/latest/ug/whatishub.html).
  * Amazon Pinpoint
    * Added cmdlets to support the new service APIs for APNs VoIP messages.

### 3.3.178.0 (2017-10-24)
  * Amazon EC2
    * The Get-EC2SecurityGroup cmdlet has been updated to support automatic pagination of all groups to match the corresponding enhancement in the underlying DescribeSecurityGroups API.
  * Amazon Elasticsearch
    * Added cmdlet Remove-ESElasticsearchServiceRole (DeleteElasticsearchServiceRole API).
  * Amazon EC2 Systems Manager
    * Updated the Write-SSMParameter cmdlet to return the version of the parameter. Previously the cmdlet, and the underlying service PutParameter API, generated no output.
  * Amazon SQS
    * Added new cmdlets to support tracking cost allocation by adding, updating, removing, and listing the metadata tags of Amazon SQS queues. The new cmdlets are Add-SQSResourceTag (TagQueue API), Get-SQSResourceTag (ListQueueTags API) and Remove-SQSResourceTag (UntagQueue API).

### 3.3.173.0 (2017-10-16)
  * AWS Elastic Beanstalk
    * Added support for tagging environments, including two additional cmdlets Get-EBResourceTag (ListResourceTags API) and Update-EBResourceTag (UpdateResourceTags API).
  * AWS CodeCommit
    * Added support for the new DeleteBranch API with cmdlet Remove-CCBranch.
  * Amazon EC2 Container Registry
    * Added cmdlets to support new APIs for repository lifecycle policies. Lifecycle policies enable you to specify the lifecycle management of images in a repository. The configuration is a set of one or more rules, where each rule defines an action for Amazon ECR to apply to an image. This allows the automation of cleaning up unused images, for example expiring images based on age or status. A lifecycle policy preview API is provided as well, which allows you to see the impact of a lifecycle policy on an image repository before you execute it.
  * Elastic Load Balancing v2
    * Added cmdlets to support Server Name Indication (SNI). Server Name Indication (SNI) is an extension to the TLS protocol by which a client indicates the hostname to connect to at the start of the TLS handshake. The load balancer can present multiple certificates through the same secure listener, which enables it to support multiple secure websites using a single secure listener. Application Load Balancers also support a smart certificate selection algorithm with SNI. If the hostname indicated by a client matches multiple certificates, the load balancer determines the best certificate to use based on multiple factors including the capabilities of the client. The new cmdlets are Add-ELB2ListenerCertificate (AddListenerCertificates API), Get-ELB2ListenerCertificate (DescribeListenerCertificates API) and Remove-ELB2ListenerCertificate (RemoveListenerCertificates API).
  * AWS OpsWorks CM
    * [BREAKING CHANGE] The service response data from the DescribeNodeAssociationStatus API (Get-OWCMNodeAssociationStatus cmdlet) has been updated to include additional fields. This cmdlet therefore now emits the service response object to the pipeline.
  * Amazon Relational Database Service
    * Added new cmdlet Get-RDSValidDBInstanceModification (DescribeValidDBInstanceModifications API) enabling you to query what modifications can be made to your DB instance.
  * Amazon Simple Email Service
    * Added cmdlets to support new service APIs related to email template management and templated email sending operations.
  * Amazon EC2
    * Added new cmdlet Edit-EC2VpcTenancy (ModifyVpcTenancy API) enabling you to change the tenancy of your VPC from dedicated to default with a single API operation. For more details refer to the documentation for changing VPC tenancy.
  * AWS WAF
    * Added cmdlets to support regular expressions as match conditions in rules, and support for geographical location by country of request IP address as a match condition in rules.
  * AWS WAF Regional
    * Added cmdlets to support regular expressions as match conditions in rules, and support for geographical location by country of request IP address as a match condition in rules.

### 3.3.169.0 (2017-10-09)
  * AWS Lambda
    * Revised parameter sets and mandatory parameters for the Update-LMFunctionCode and Publish-LMFunction cmdlets based on user feedback. Also made the options for how the function code can be supplied the same.
  * Amazon AppStream
    * Added cmdlets to support new service APIs for APIs for managing and accessing image builders, and deleting images. The new cmdlets are: Get-APSImageBuilderList (DescribeImageBuilders API), New-APSImageBuilder (CreateImageBuilder API), New-APSImageBuilderStreamingURL (CreateImageBuilderStreamingURL API), Start-APSImageBuilder (StartImageBuilder API), Stop-APSImageBuilder (StopImageBuilder API), Remove-APSImage (DeleteImage API) and Remove-APSImageBuilder (DeleteImageBuilder API).
  * AWS CodeBuild
    * Added cmdlets New-CBWebHook (CreateWebHook API) and Remove-CBWebHook (DeleteWebHook API) to support the new service update for building GitHub pull requests.
  * Amazon Kinesis Analytics
    * Added support for schema discovery on objects in S3 and the ability to support configure input data preprocessing through Lambda with new cmdletsAdd-KINAApplicationInputProcessingConfiguration (AddApplicationInputProcessingConfiguration API) and Remove-KINAApplicationInputProcessingConfiguration (DeleteApplicationInputProcessingConfiguration API).
  * Amazon Route 53 Domains
    * Added cmdlet Test-R53DDomainTransferability to support the new CheckDomainTransferability API.

### 3.3.164.0 (2017-09-29)
  * Amazon EC2 Container Registry
    * Implemented a new helper cmdlet, Get-ECRLoginCommand, to return the login command to the pipeline for your default or specified registry or registries. This command is similar to the AWS CLI's 'ecr get-login' command.
  * AWS CloudFormation
    * Added cmdlet Update-CFNTerminationProtection to support the new UpdateTerminationProtection API enabling you to prevent a stack from being accidentally deleted. If you attempt to delete a stack with termination protection enabled, the deletion fails and the stack, including its status, remains unchanged. You can also enable termination protection on a stack when you create it using the new -EnableTerminationProtection parameter on the New-CFNStack cmdlet. Termination protection on stacks is disabled by default. After creation, you can set termination protection on a stack whose status is CREATE_COMPLETE, UPDATE_COMPLETE, or UPDATE_ROLLBACK_COMPLETE.
  * Amazon EC2
    * Added argument completion support for the Attribute parameter of the Edit-EC2ImageAttribute cmdlet, enabling tab completion of the possible attribute names. The service models this parameter as a simple string type, rather than a service enumeration, so tab completion was not available by default.
  * Amazon S3
    * Updated the Copy-S3Object cmdlet to support copying (downloading) multiple objects, identified by common key prefix, to a folder on the local file system. Previously the cmdlet could only process single object download to a file or folder. You may therefore use either Read-S3Object or Copy-S3Object to download one or multiple files from S3 to the local system (the functionality is the same). To copy files within S3, use the Copy-S3Object cmdlet.
  * Amazon Pinpoint
    * Added new cmdlets to support new APIs for new push notification channels: Amazon Device Messaging (ADM) and, for push notification support in China, Baidu Cloud Push.
    * Added new cmdlet for direct message deliveries to user IDs, enabling you to message an individual user on multiple endpoints.

### 3.3.161.0 (2017-09-22)
  * AWS CodePipeline
    * [BREAKING CHANGE]
      The output of the Get-CPPipeline cmdlet has changed as a result of a service update to the underlying GetPipeline API. The api response data now includes pipeline metadata info in addition to the pipeline declaration data (which was the previous output). To access the original data, use the '.Pipeline' member of the output object. To access the new metadata use the the '.Metadata' member of the output object.
  * AWS Greengrass
    * Added new cmdlet Reset-GGDeployment to support the new ResetDeployments API.
  * AWS CloudWatchLogs
    * Added support for associating LogGroups with KMS Keys with new cmdlets Register-CWLKmsKey (AssociateKmsKey API) and Unregister-CWLKmsKey (DisassociateKmsKey API).
  * Amazon EC2
    * Added support for new operations on Amazon FPGA Images (AFIs), within the same region and across multiple regions, with new cmdlets Get-EC2FpgaImageAttribute (DescribeFpgaImageAttribute API), Edit-EC2FpgaImageAttribute (ModifyFpgaImageAttribute API), Reset-EC2FpgaImageAttribute (ResetFpgaImageAttribute API),  Remove-EC2FpgaImage (DeleteFpgaImage API) and Copy-EC2FpgaImage (CopyFpgaImage API). AFI attributes include name, description and granting/denying other AWS accounts to load the AFI.
  * AWS Identity and Access Management
    * Added support for new APIs to submit a service-linked role deletion request and querying the status of the deletion with new cmdlets Remove-IAMServiceLinkedRole (DeleteServiceLinkedRole API) and Get-IAMServiceLinkedRoleDeletionStatus (GetServiceLinkedRoleDeletionStatus API).
  * Amazon Simple Email Service
    * Added support for new APIs enabling domain customization for tracking open and click events with new cmdlets New-SESConfigurationSetTrackingOption (CreateConfigurationSetTrackingOptions API), Update-SESConfigurationSetTrackingOption (UpdateConfigurationSetTrackingOptions API) and Remove-SESConfigurationSetTrackingOption (DeleteConfigurationSetTrackingOptions API).

### 3.3.158.0 (2017-09-17)
  * AWS Service Catalog
    - Added cmdlets to support the new CopyProduct and DescribeCopyProductStatus apis.

### 3.3.152.0 (2017-09-09)
  * Amazon CloudWatch Logs
    - Added cmdlets for managing resource polices
  * Amazon EC2
    - Added new cmdlets Update-EC2SecurityGroupRuleIngressDescription and Update-EC2SecurityGroupRuleEgressDescription
  * Amazon Lex Model Building Service
	- Added new cmdlet Get-LMBExport
  * Amazon Route53
    - Added new cmdlets to manage query logging config.

### 3.3.150.0 (2017-09-07)
  * AWS CodeBuild
    - Added new cmdlet RemoveCBBuildBatch
  * AWS CodeStar
    - Added new cmdlets Add-CSTTagsForProject, Remove-CSTTagsForProject and Get-CSTTagsForProject
  * Amazon GameLift
    - Added new cmdlets for setting up EC2 VPC peering.

### 3.3.143.0 (2017-08-24)
  * Amazon Simple Systems Management
    - Added new cmdlet, Get-SSMAssociationVersionList (ListAssociationVersions API), to returns versioned associations.
  * Amazon Kinesis Firehose
    - Added new cmdlet, Get-KINFKinesisStream (GetKinesisStream API).

### 3.3.140.0 (2017-08-16)
  * All services
    - Improved error messaging for 'name resolution failure' errors. The cmdlets now detail the endpoint they attempted to access and list some possible causes (for example, use of an availability zone instead of a region code).
  * Amazon Simple Systems Management
    - Added and updated cmdlets to support new service features. Maintenance Windows include the following changes or enhancements: New task options using Systems Manager Automation, AWS Lambda, and AWS Step Functions; enhanced ability to edit the targets of a Maintenance Window, including specifying a target name and description, and ability to edit the owner field; enhanced ability to edits tasks; enhanced support for Run Command parameters; and you can now use a --safe flag when attempting to deregister a target. If this flag is enabled when you attempt to deregister a target, the system returns an error if the target is referenced by any task. Also, Systems Manager now includes Configuration Compliance to scan your fleet of managed instances for patch compliance and configuration inconsistencies. You can collect and aggregate data from multiple AWS accounts and Regions, and then drill down into specific resources that aren't compliant.
  * AWS Elastic File System
    - Extended the New-EFSFileSystem cmdlet to support encrypted EFS file systems and specifying a KMS master key to encrypt it with.
  * AWS Storage Gateway
    - Extended the Remove-SGFileShare with new parameter -ForceDelete. If set, the file share is immediately deleted and all data uploads aborted immediately otherwise the share is not deleted until all uploads complete.
  * AWS CodeDeploy
    - Updated the New-CDDeploymentGroup and Update-CDDeploymentGroup cmdlets with parameters to support specifying Application Load Balancers in deployment groups, for both in-place and blue/green deployments.
  * Amazon Cognito Identity Provider
    - Updated and added cmdlets to support new features for Amazon Cognito User Pools that enable application developers to easily add and customize a sign-up and sign-in user experience, use OAuth 2.0, and integrate with Facebook, Google, Login with Amazon, and SAML-based identity providers.
  * Amazon EC2
    - Updated the New-EC2Address cmdlet with a new parameter, -Address, to support the new service feature enabling recovery of an elastic IP address (EIP) that was released.
  * AWS Elastic Beanstalk
    - Updated the Get-EBEnvironment cmdlet to support automatic pagination now that the underlying service API, DescribeEnvironments, can paginate output.
  * Amazon Route 53
    - Applied parameter alias "Id" to all cmdlets that accept a -HostedZoneId parameter to make pipeline scenarios more convenient, for example Get-R53HostedZoneList | Get-R53ResourceRecordSet. The change avoids the need for an intermediate 'Select-Object -ExpandProperty Id' clause in the pipeline to extract the zone ID from the output of Get-R53ResourceRecordSet to pass to Get-R53ResourceRecordSet.
  * Amazon S3
    - Extended the Write-S3Object cmdlet to accept tags for all operating modes. Previously tags could only be specified for single file or object uploads, now they can also be specified when uploading multiple objects from a folder hierarchy. The specified tags will be applied to all uploaded objects.
  * Amazon GameLift
    - New and updated cmdlets to support the Matchmaking Grouping Service, a new feature that groups player match requests for a given game together into game sessions based on developer configured rules.

### 3.3.133.0 (2017-08-04)
  * AWS CodeDeploy
    - Updated the New-CDDeployment, New-CDDeploymentGroup and Update-CDDeploymentGroup with parameters to support the use of multiple tag groups in a single deployment group (an intersection of tags) to identify the instances for a deployment. When you create or update a deployment group, use the new -Ec2TagSetList and -OnPremisesTagSetList parameters to specify up to three groups of tags. Only instances that are identified by at least one tag in each of the tag groups are included in the deployment group.
    - Revised some parameter names in the New-CDDeployment, New-CDDeploymentGroup and Update-CDDeploymentGroup to improve usability. Backwards compatible aliases were also applied to the affected parameters.
  * Amazon Pinpoint
    - Added support for the new app management APIs with new cmdlets Get-PINApp (GetApp API), Get-PINAppList (GetApps API), New-PINApp (CreateApp API) and Remove-PINApp (DeleteApp API).
  * AWS Config Service
    - Added new cmdlet, Get-CFGDiscoveredResourceCount (GetDiscoveredResourceCounts API), to returns the resource types and the number of each resource type in your AWS account.
  * Amazon Simple Systems Management
    - Added new cmdlet, Send-SSMAutomationSignal (SendAutomationSignal API). This API is used to send a signal to an automation execution to change the current behavior or status of the execution.

### 3.3.130.0 (2017-07-28)
  * Fixed issue using Kerberos authentication when obtaining SAML federated credentials. The authentication process failed for some users with a '401 unauthorized' exception.
  * Added new output format templates for the LogGroup and LogStream types for Amazon CloudWatch Logs.
  * AWS Directory Service
    - You can now improve the resilience and performance of your Microsoft AD directory by deploying additional domain controllers with the new Set-DSDomainControllerCount cmdlet (UpdateNumberofDomainControllers API). This cmdlet enables you to update the number of domain controllers you want for your directory. The new Get-DSDomainControllerList cmdlet (DescribeDomainControllers API) enables you to describe the detailed information of each domain controller of your directory. The output of the Get-Directory cmdlet was also extended to contain a new field,  'DesiredNumberOfDomainControllers'.
  * Amazon Kinesis
    - You can now encrypt your data at rest within an Amazon Kinesis Stream using server-side encryption using new cmdlets Start-KINStreamEncryption (StartStreamEncryption API) and Stop-KINStreamEncryption (StopStreamEncryption API). Server-side encryption via AWS KMS makes it easy for customers to meet strict data management requirements by encrypting their data at rest within the Amazon Kinesis Streams, a fully managed real-time data processing service.
  * Amazon EC2 Simple Systems Management
    - Added parameters to support patching for Amazon Linux, Red Hat and Ubuntu systems.
  * Amazon API Gateway
    - Added new cmdlets Get-AGGatewayResponse (GetGatewayResponse API), Get-AG-GatewayResponseList (GetGatewayResponses API), Update-AGGatewayResponse(UpdateGatewayResponse API), Remove-AGGatewayResponse (DeleteGatewayResponse API) and Write-AGGatewayResponse (PutGatewayResponse API) to support management of gateway responses.
  * AWS AppStream
    - Amazon AppStream 2.0 image builders and fleets can now access applications and network resources that rely on Microsoft Active Directory (AD) for authentication and permissions. This new feature allows you to join your streaming instances to your AD, so you can use your existing AD user management tools. New cmdlets to support this feature are Get-APSDirectoryConfigList (DescribeDirectoryConfigs API), New-APSDirectoryConfig (CreateDirectoryConfig API), Remove-APSDirectoryConfig (DeleteDirectoryConfig API) and Update-APSDirectoryConfig (UpdateDirectoryConfig API). New-APSFleet was updated with new parameters to support specifying domain information.
  * Application Discovery Service
    - Updated the Get-ADSExportTask and Start-ADSExportTask cmdlets to support filters, allow export based on per agent id.
  * Auto Scaling
    - Updated the Write-ASScalingPolicy to support a new type of scaling policy called target tracking scaling policies that you can use to set up dynamic scaling for your application.
  * Amazon Cognito Identity Provider
    - Updated the New-CGIPUserPool cmdlet to support configuration of user pools for email/phone based signup and sign-in.
  * Amazon EC2
    - X-ENI (or Cross-Account ENI) is a new feature that allows the attachment or association of Elastic Network Interfaces (ENI) between VPCs in different AWS accounts located in the same availability zone. With this new capability, service providers and partners can deliver managed solutions in a variety of new architectural patterns where the provider and consumer of the service are in different AWS accounts. To support this new feature the cmdlets Get-EC2NetworkInterfacePermission (DescribeNetworkInterfacePermissions API), New-EC2NetworkInterfacePermission (CreateNetworkInterfacePermission API) and Remove-EC2NetworkInterfacePermission (DeleteNetworkInterfacePermission) were added.
    - Added cmdlet Get-EC2ElasticGpu (DescribeElasticGpus API). Amazon EC2 Elastic GPUs allow you to easily attach low-cost graphics acceleration to current generation EC2 instances. With Amazon EC2 Elastic GPUs, you can configure the right amount of graphics acceleration to your particular workload without being constrained by fixed hardware configurations and limited GPU selection.
    - Added cmdlet New-EC2DefaultVpc (CreateDefaultVpc API). You no longer need to contact AWS support, if your default VPC has been deleted.
  * Amazon Elastic MapReduce
    - Added support for the ability to use a custom Amazon Linux AMI and adjustable root volume size when launching a cluster.
  * Amazon Lambda
    - Updated the Get-LMFunctionList cmdlet to support the latest Lambda@Edge enhancements.
  * AWS CloudFormation
    - Added and updated cmdlets to support StackSets, enabling users to manage stacks across multiple accounts and regions.

### 3.3.119.0 (2017-07-07)
  * AWS CloudFormation
    - Added new helper cmdlets Test-CFNStack, which tests a CloudFormation stack to determine if it's in a certain status and Wait-CFNStack which Pauses execution of the script until the desired CloudFormation Stack status has been reached or timeout occurs.
  * Added new format definitions for several types to improve output usability. The new formats take effect on objects of type:
    - Amazon.AutoScaling.Model.AutoScalingGroup
    - Amazon.AutoScaling.Model.LaunchConfiguration
    - Amazon.CloudFormation.Model.Stack
    - Amazon.CloudFormation.Model.StackEvent
    - Amazon.CloudWatch.Model.MetricAlarm
    - Amazon.CloudWatchEvents.Model.Rule
    - Amazon.EC2.Model.Instance
    - Amazon.IdentityManagement.Model.Role
    - Amazon.Lambda.Model.FunctionConfiguration
    - Amazon.SimpleSystemsManagement.Model.AssociationDescription
    - Amazon.WorkSpaces.Model.Workspace
  * AWS Service Catalog
    - Added support for the new TagOption library with new cmdlets Add-SCTagOptionToResource (AssociateTagOptionWithResource API), Get-SCTagOptionList (ListTagOptions API), Get-SCResourcesForTagOption (ListResourcesForTagOption API), Get-SCTagOption (DescribeTagOption API), New-SCTagOption (CreateTagOption API), Remove-SCTagOptionFromResource (DisassociateTagOptionFromResource API) and Update-SCTagOption (UpdateTagOption API).
  * Amazon Simple Systems Management
    - Added cmdlets for Resource Data Sync support with SSM Inventory. The new cmdlets are New-SSMResourceDataSync (CreateResourceDataSync API)- creates a new resource data sync configuration, Get-SSMResourceDataSync (ListResourceDataSync API) - lists existing resource data sync configurations, and Remove-SSMResourceDataSync (DeleteResourceDataSync API) - deletes an existing resource data sync configuration.
  * Amazon DynamoDB Accelerator (DAX)
    - Added cmdlet support for the new Amazon DynamoDB Accelerator (DAX) service. DAX is a managed caching service engineered for Amazon DynamoDB. DAX dramatically speeds up database reads by caching frequently-accessed data from DynamoDB, so applications can access that data with sub-millisecond latency. You can create a DAX cluster easily, using the AWS Management Console. With a few simple modifications to your code, your application can begin taking advantage of the DAX cluster and realize significant improvements in read performance. Cmdlets for the new service have the noun prefix 'DAX' and can be listed with the command 'Get-AWSCmdletName -Service DAX'.
  * Amazon CloudWatch Events
    - CloudWatch Events now allows different AWS accounts to share events with each other through a new resource called event bus. Event buses accept events from AWS services, other AWS accounts and Write-CWEEvent (PutEvents API) calls. Currently all AWS accounts have one default event bus. To send events to another account, customers simply write rules to match the events of interest and attach an event bus in the receiving account as the target to the rule. The new cmdlets are Get-CWEEventBus (DescribeEventBus API), Write-CWEPermission (PutPermission API) and Remove-CWEPermission (RemovePermission).
  * Amazon S3
    - Added new parameter -TagSet to the Write-S3Object and Copy-S3Object cmdlets to support specifying tags when uploading individual files to a bucket or copying objects within S3.
    - Updated cmdlets to switch to using path style addressing if the -EndpointUrl parameter is used. The default behavior without the parameter is to prefer virtual host style addressing unless the bucket name is not DNS compatible.
  * AWS Greengrass
    - Added cmdlet support for the new AWS Greengrass service. AWS Greengrass seamlessly extends AWS onto physical devices so they can act locally on the data they generate, while still using the cloud for management, analytics, and durable storage. AWS Greengrass ensures your devices can respond quickly to local events and operate with intermittent connectivity. AWS Greengrass minimizes the cost of transmitting data to the cloud by allowing you to author AWS Lambda functions that execute locally. Cmdlets for the service have the noun prefix 'GG' and can be listed with the command 'Get-AWSCmdletName -Service GG'.
  * AWS CloudWatch
    - Added cmdlets to support the new functionality for dynamically building and maintaining dashboards to monitor your infrastructure and applications. The new cmdlets are Get-CWDashboard (GetDashboard API), Get-CWDashboardList (ListDashboards API), Remove-CWDashboard (DeleteDashboard API) and Write-CWDashboard (PutDashboard API).

### 3.3.113.0 (2017-06-23)
  * Amazon Simple Systems Management
    - Added cmdlets Get-SSMParameter (GetParameter API), Get-SSMParametersByPath (GetParametersByPath API), Remove-SSMParameterCollection (DeleteParameters API).
    - Updated Get-SSMParameterList with a new parameter, -ParameterFilter, to support filtering of the results.
    - Updated Write-SSMParameter with a new parameter, -AllowedPattern, to support enforcement of the parameter value by applying a regex.
  * AWS WAF
    - Added new cmdlets to support creation, editing, updating, and deleting a new type of WAF rule with a rate tracking component. The new cmdlets are Get-WAFRateBasedRule (GetRateBasedRule API), Get-WAFRateBasedRuleList (ListRateBasedRules API), Get-WAFRateBasedRuleManagedKey (GetRateBasedRuleManagedKeys API), New-WAFRateBasedRule (CreateRateBasedRule API), Remove-WAFRateBasedRule (DeleteRateBasedRule API) and Update-WAFRateBasedRule (UpdateRateBasedRule API).
  * AWS WAF Regional
    - Added new cmdlets to support creation, editing, updating, and deleting a new type of WAF rule with a rate tracking component. The new cmdlets are Get-WAFRRateBasedRule (GetRateBasedRule API), Get-WAFRRateBasedRuleList (ListRateBasedRules API), Get-WAFRRateBasedRuleManagedKey (GetRateBasedRuleManagedKeys API), New-WAFRRateBasedRule (CreateRateBasedRule API), Remove-WAFRRateBasedRule (DeleteRateBasedRule API) and Update-WAFRRateBasedRule (UpdateRateBasedRule API).
  * Amazon WorkDocs
    - Added cmdlets Get-WDActivity (DescribeActivities API), Get-WDCurrentUser (GetCurrentUser API) and Get-WDRootFolder (DescribeRootFolders API) to retrieve the activities performed by WorkDocs users.
  * AWS CodePipeline
    - Added cmdlet Get-CDPipelineExecutionSummary to support the new ListPipelineExecutions API. This cmdlet enables you to retrieve summary information about the most recent executions in a pipeline, including pipeline execution ID, status, start time, and last updated time. You can request information for a maximum of 100 executions. Pipeline execution data is available for the most recent 12 months of activity.
    - Enabled automatic pagination of results for the Get-CPActionType and Get-CDPipelineList cmdlets.
  * Amazon Lightsail
    - The Get-LSOperationListForResource cmdlet now supports automatic pagination.
  * AWS Data Migration Service
    - Extended the Import-DSMCertificate cmdlet to support tagging.

### 3.3.109.0 (2017-06-19)
  * Amazon EC2
    - Added cmdlet Get-EC2FpgaImage to support the new DescribeFpgaImages API. This API enables customers to describe Amazon FPGA Images (AFIs) available to them, which includes public AFIs, private AFIs that you own, and AFIs owned by other AWS accounts for which you have load permissions.
  * Application AutoScaling
    - Updated the Write-AASScalingPolicy cmdlet to support automatic scaling of read and write throughput capacity for DynamoDB tables and global secondary indexes.
  * AWS IoT
    - [Breaking change] Updated the Get-IOTCertificate cmdlet to remove the parameter -CertificatePem, previously added in v3.3.104.0.
  * Amazon Relational Database Service
    - Updated the Copy-RDSDBSnapshot and Restore-RDSDBClusterToPointInTime cmdlets to support copy-on-write, a new Aurora MySQL Compatible Edition feature that allows users to restore their database, and support copy of TDE enabled snapshot cross region.
  * AWS Service Catalog
    - Added cmdlet Get-SCProvisionedProductDetail to support the new DescribeProvisionedProduct API.
    - Added parameter -ReturnCloudFormationTemplate to the Get-SCProvisioningArtifact cmdlet. This parameter maps to the 'Verbose' request property in the underlying DescribeProvisioningArtifact API call.

### 3.3.104.0 (2017-06-09)
  * Amazon S3
    - Fixed issue with the Remove-S3Object cmdlet not correctly binding version data when a collection of Amazon.S3.Model.S3ObjectVersion instances are piped to the -InputObject parameter. The examples for this cmdlet have been updated to illustrate usage scenarios deleting single and multiple objects.
  * AWS OpsWorks
    - Added support for resource tagging with new cmdlets Add-OPSResourceTag (TagResource API), Get-OPSResourceTag (ListTags API) and Remove-OPSResourceTag (UntagResource API).
  * AWS IoT
    - Updated the Get-IOTCertificate cmdlet with a new parameter -CertificatePem to support retrieving the description of a certificate with the certificate's PEM.
  * Amazon Pinpoint
    - Added cmdlets to support SMS Text and Email Messaging in addition to Mobile Push Notifications.
  * AWS Rekognition
    - Added cmdlets Get-REKCelebrityInfo (GetCelebrityInfo API) and Find-REKCelebrity (RecognizeCelebrities API).

### 3.3.99.0 (2017-06-05)
  * All services
    - Resolved issue causing the backwards-compatible aliases introduced recently to not be available on PowerShell v3 or v4 systems.
  * Amazon Kinesis Analytics
    - Added support for publishing error messages concerning application misconfigurations to to AWS CloudWatch Logs with new cmdlets Add-KINAApplicationCloudWatchLoggingOption (AddApplicationCloudWatchLoggingOption API) and Remove-KINAApplicationCloudWatchLoggingOption (DeleteApplicationCloudWatchLoggingOption API).
  * Amazon WorkDocs
    - Added support for managing tags and custom metadata on resources with new cmdlets New-WDCustomMetadata (CreateCustomMetadata API), New-WDLabel (CreateLabels API), Remove-WDCustomMetadata (DeleteCustomMetadata API) and Remove-WDLabel (DeleteLabels API).
    - Added new cmdlets to support adding and retrieving comments at the document level: Get-WDComment (DescribeComments API), New-WDComment (CreateComment API) and Remove-WDComment (DeleteComment API)

### 3.3.98.0 (2017-06-02)
  * Amazon Relational Database Service
    - Customers can now easily and quickly stop and start their DB instances using two new cmdlets, Start-RDSDBInstance (StartDBInstance API) and Stop-RDSDBInstance (StopDBInstance API).
  * AWS CodeDeploy
    - Added new cmdlet Get-CDGitHubAccountTokenNameList (ListGitHubAccountTokenNames API) to support improved GitHub account and repository connection management. You can now create and store up to 25 connections to GitHub accounts in order to associate AWS CodeDeploy applications with GitHub repositories. Each connection can support multiple repositories. You can create connections to up to 25 different GitHub accounts, or create more than one connection to a single account.
  * Amazon Cognito Identity Provider
    - Added cmdlets to support integration of external identity providers. The new cmdlets are Get-CGIPIdentityProvider (DescribeIdentityProvider API), Get-CGIPIdentityProviderByIdentifier (GetIdentityProviderByIdentifier API), Get-CGIPIdentityProviderList (ListIdentityProviders API), Get-CGIPUserPoolDomain (DescribeUserPoolDomain API), New-CGIPUserPoolDomain (CreateUserPoolDomain API), Remove-CGIPIdentityProvider (DeleteIdentityProvider API), Remove-CGIPUserPoolDomain (DeleteUserPoolDomain API) and Update-CGIPIdentityProvider (UpdateIdentityProvider API).

### 3.3.96.0 (2017-05-31)
  * All services
    - Cmdlet names for all services have been reviewed and those with plural nouns corrected to be singular to follow best practices. For more details see the blog post 'Updates to AWSPowerShell Cmdlet Names' on the AWS .NET Developer Blog https://aws.amazon.com/blogs/developer/category/net/. A new submodule, loaded automatically, contains backwards-compatible aliases to ensure current scripts will continue to work with the older cmdlet names.
  * Amazon Cloud Directory
    - Added support for Typed Links, enabling customers to create object-to-object relationships that are not hierarchical in nature. Typed Links enable customers to quickly query for data along these relationships. Customers can also enforce referential integrity using Typed Links, ensuring data in use is not inadvertently deleted.

### 3.3.95.0 (2017-05-26)
  * AWS AppStream
    - Updated the New-APSStack cmdlet with new parameter -StorageConnector, and the Update-APSStack with new parameters -StorageConnector and -DeleteStorageConnector, to add support for persistent user storage, backed by S3.
  * AWS Data Migration Service
    - Updated cmdlets to add support for using Amazon S3 and Amazon DynamoDB as targets for database migration, and using MongoDB as a source for database migration.
    - Added cmdlets to support event subscriptions: Edit-DMSEventSubscription (ModifyEventSubscription API), Get-DMSEvent (DescribeEvents API), Get-DMSEventCategory (DescribeEventCategories API), Get-DMSEventSubscription (DescribeEventSubscriptions API), New-DMSEventSubscription (CreateEventSubscription API), Remove-DMSEventSubscription (DeleteEventSubscription API).
    - Added cmdlet Restore-DMSTable to support the new ReloadTables API.

### 3.3.90.0 (2017-05-19)
  * AWSPowerShell.NetCore module
    - Added CompatiblePSEditions entry to the module manifest to mark the module as only being compatible with PowerShell Core environments.
  * Amazon Inspector
    - Added cmdlet Get-INSAssessmentReport to support the new GetAssessmentReport API. This new API adds the ability to produce an assessment report that includes detailed and comprehensive results of a specified assessment run.
  * Amazon Lightsail
    - Added cmdlet Set-LSInstancePublicPort to support the new PutInstancePublicPorts API, enabling a single request to both open and close public ports on an instance.
  * Amazon Athena
    - Added support for the new Amazon Athena service. Amazon Athena is an interactive query service that makes it easy to analyze data in Amazon S3 using standard SQL. Athena is serverless, so there is no infrastructure to manage, and you pay only for the queries that you run. Cmdlets for this service have the noun prefix 'ATH' and can be listed using the command 'Get-AWSCmdletName -Service ATH'.

### 3.3.86.0 (2017-05-12)
  * AWS Lambda
    - Added support for automatic pagination of all available results on service APIs that supported paging. Updated cmdlets are Get-LMAliasList, Get-LMEventSourceMappings, Get-LMFunctions and Get-LMVersionsByFunction.
  * Elastic Load Balancing
    - Added a new cmdlet, Get-ELBAccountLimit (DescribeAccountLimits API), enabling customers to describe their account limits, such as load balancer limit, target group limit etc.
  * Elastic Load Balancing v2
    - Added a new cmdlet, Get-ELB2AccountLimit (DescribeAccountLimits API), enabling customers to describe their account limits, such as load balancer limit, target group limit etc.
  * Amazon Lex Model Builder Service
    - Added support for new APIs with three new cmdlets: Remove-LMBBotVersion (DeleteBotVersion API), Remove-LMBIntentVersion (DeleteIntentVersion API) and Remove-LMBSlitTypeVersion (DeleteSlotTypeVersion API).
    - *Breaking Change*:  The -Version parameter has been removed from the Remove-LMBBot, Remove-LMBIntent and Remove-LMBSlotType cmdlets in favor of the specific cmdlets to delete versions.
  * Amazon Cognito Identity Provider
    - Added support for the new group support APIs with new cmdlets Add-CGIPUserToGroupAdmin (AdminAddUserToGroup API), Get-CGIPGroup (GetGroup API), Get-CGIPGroupList (ListGroups API), Get-CGIPGroupsForuserAdmin (AdminListGroupsForUser API), Get-CGIPUsersInGroup (ListUsersInGroup API), New-CGIPGroup (CreateGroup API), Remove-CGIPGroup (DeleteGroup API), Remove-CGIPuserFromGroup (AdminRemoveUserFromGroup API) and Update-CGIPGroup (UpdateGroup API).

### 3.3.84.0 (2017-05-05)
  * AWS Marketplace Entitlement Service
    - Added support for the new Marketplace Entitlement Service. The cmdlet noun prefix for this service is 'MES' and the cmdlets can be listed using the command 'Get-AWSCmdletName -Service MES'. Currently the service exposes one cmdlet, Get-MESEntitlement (GetEntitlements API).

### 3.3.83.0 (2017-05-01)
  * Amazon Kinesis Firehose
    - Fixed bug in handling of the -Text and -FilePath parameters that could cause a null reference exception.
  * AWS AppStream
    - Updated cmdlets to support the new 'Default Internet Access' service feature. This feature enables Internet access from AppStream 2.0 instances - image builders and fleet instances. Admins can enable this feature when creating an image builder or while creating/updating a fleet with the new -EnableDefaultInternetAccess parameter on the New-APSFleet and Update-APSFleet cmdlets.
  * Amazon Relational Database Service
    - Added the parameter -EnableIAMDatabaseAuthentication to the New-RDSDBCluster, Edit-RDSDBCluster, New-RDSDBInstance, Edit-RDSDBInstance, New-RDSDBInstanceReadReplica, Restore-RDSDBClusterFromS3, Restore-RDSDBClusterFromSnapshot, Restore-RDSDBClusterToPointInTime, Restore-RDSDBInstanceFromDBSnapshot and Restore-RDSDBInstanceToPointInTime cmdlets to enable authentication to your MySQL or Amazon Aurora DB instance using IAM authentication.
  * AWS CloudFormation
    - Added a new parameter, -ClientRequestToken, to the New-CFNStack, Remove-CFNStack, Resume-CFNUpdateRollback, Start-CFNChangeSet, Stop-CFNUpdateStack and Update-CFNStack cmdlets to enable supplying a customer-provided idempotency token to allow safely retrying operations.
  * AWS Import/Export Snowball
    - Added new parameter -ForwardingAddressId to the New-SNOWCluster, Update-SNOWCluster, New-SNOWJob and Update-SNOWJob cmdlets. The New-SNOWAddress cmdlet was updated with a new parameter -Address_IsRestricted to enable you to mark the primary address.

### 3.3.81.0 (2017-04-24)
  * All service API cmdlets
    - Cmdlets that invoke APIs on AWS services can now display a message stating the API and service endpoint or region the call is being dispatched to when the -Verbose switch is used. This can be used to help diagnose endpoint resolution failures.
  * AWS CodeStar
    - Added support for the new AWS CodeStar service. Cmdlets for the service have the noun prefix CST and can be listed with the command Get-AWSCmdletName -Service CST.
  * Amazon Lex Model Builder Service
    - Added support for the new Amazon Lex Model Builder Service. Cmdlets for the service have the noun prefix LMB and can be listed with the command Get-AWSCmdletName -Service LMB.
  * Amazon EC2
    - Added a new cmdlet, New-EC2FpgaImage (CreateFpgaImage API), to support creating an Amazon FPGA Image (AFI) from a specified design checkpoint (DCP).
  * AWS Rekognition
    - Added a new cmdlet, Find-REKModerationLabel (DetectModerationLabel API), to support detection of explicit or suggestive adult content in an image. The cmdlet a list of corresponding labels with confidence scores, as well as a taxonomy (parent-child relation) for each label.
  * AWS Identity and Access Management
    - Updated the New-IAMRole cmdlet with a new parameter, -Description, and added a new cmdlet Update-IAMRoleDescription (UpdateRoleDescription API) to support specifying a user-provided description for the role.
    - Added cmdlet New-IAMServiceLinkedRole (CreateServiceLinkedRole API). This cmdlet enables creation of a new role type, Service Linked Role, which works like a normal role but must be managed via services' control.
  * Amazon Lambda
    - Added new cmdlets to support the new service feature using tags to group and filter Lambda functions. The new cmdlets are Add-LMResourceTag (TagResource API), Get-LMResourceTag (ListTags API) and Remove-LMResourceTag (UntagResource API).
    - Added a new parameter, -TracingConfig_Mode, to the Update-LMFunctionConfiguration cmdlet to support integration with CloudDebugger service to enable customers to enable tracing for the Lambda functions and send trace information to the CloudDebugger service.
  * Amazon API Gateway
    - Extended the Get-AGDeployment, Get-AGResource and Get-AGResourceList cmdlets with a new parameter, -Embed, to support specifying embedded resources to retrieve.
  * Amazon Polly
    - Added a new parameter, -SpeechMarkType, to the Get-POLSpeech cmdlet to support defining the speech marks to be used in the returned text.
  * AWS DeviceFarm
    - Added support for the new service feature for deals and promotions with a new cmdlet, Get-DFOfferingPromotion (ListOfferingPromotions API).

### 3.3.76.0 (2017-04-11)
  * Amazon S3
    - Fixed issue with the Copy-S3Object cmdlet throwing 'access denied' error when attempting to copy objects between buckets in different regions.
  * Amazon EC2
    - Fixed issue with 'file not found' errors when using a relative path with the -PemFile parameter.
  * Amazon API Gateway
    - Added cmdlets to support the new request validators feature. The new cmdlets are: New-AGRequestValidator (CreateRequestValidator API), Get-AGRequestValidator (GetRequestValidator API), Get-AGRequestValidatorList (GetRequestValidators API), Update-AGRequestValidator (UpdateRequestValidator API) and Remove-AGRequestValidator (DeleteRequestValidator API). The Write-AGMethod cmdlet was also updated with a new parameter, -RequestValidatorId, enabling you to specify a request validator for the method.
  * AWS Batch
    - Updated the New-BATComputeEnvironment cmdlet with a new parameter, -ComputeResources_ImageId, to support specifying an AMI for MANAGED Compute Environment.
  * AWS GameLift
    - Updated the New-GMLGameSessionQueue and Update-GMLGameSessionQueue cmdlets with a new parameter, -PlayerLatencyPolicy, to enable developers to specify a maximum allowable latency per queue.
  * AWS OpsWorks
    - Updated the New-OPSLayer and Update-OPSLayer cmdlets with new parameters -CloudWatchLogsConfiguration_Enabled and -CloudWatchLogsConfiguration_LogStream to attaching a Cloudwatch Logs agent configuration to OpsWorks Layers. OpsWorks will then automatically install and manage the CloudWatch Logs agent on the instances that are part of the OpsWorks Layer.

### 3.3.75.0 (2017-04-10)
  * Fixed issue with cmdlets taking a long time to return when no region was specified.
  * Fixed issue with the argument completer for the -ProfileName parameter issuing a warning message about use of a deprecated switch on the Get-AWSCredentials cmdlet.
  * Amazon Redshift
    - Added a new cmdlet, Get-RSClusterCredential, to support the new GetClusterCredentials API.

### 3.3.74.0 (2017-04-07)
  * AWS CloudWatch
    - Updated the Write-CWMetricAlarm cmdlet with support for new alarm configurations for missing data treatment and percentile metrics. Missing data can now be treated as alarm threshold breached, alarm threshold not breached, maintain alarm state and the current default treatment. Percentile metric alarms are for alarms that can trigger unnecessarily if the percentile is calculated from a small number of samples. The new rule can treat percentiles with low sample counts as same as missing data. If the first rule is enabled, the same treatment will be applied when an alarm encounters a percentile with low sample counts.
  * Amazon ElastiCacheElastiCache
    - Added support for testing the Elasticache Multi-AZ feature with Automatic Failover. This support includes a new parameter, -NodeGroupId, for the Edit-ECReplicationGroup cmdlet and -ShowCacheClustersNotInReplicationGroup added to Get-ECCacheCluster and a new cmdlet, Test-ECFailover (TestFailover API).
  * Amazon Lex
    - Added a new cmdlet, Send-LEXContent, to support the new PostContent API.

### 3.3.71.0 (2017-03-31)
  * AWS Resource Groups Tagging API
    - Added support for the new Resource Groups Tagging API service. Cmdlets for the service have the noun prefix 'RGT' and can be listed using the command 'Get-AWSCmdletName -Service RGT': Add-RGTResourceTag (TagResources API), Get-RGTResource (GetResources API), Get-RGTTagKey (GetTagKeys API), Get-RGTTagValue (GetTagValues API) and Remove-RGTResourceTag (UntagResources API).
  * AWS Storage Gateway
    - Added a new cmdlet, Invoke-CacheRefresh (RefreshCache API), and extended the New-SGNFSFileShare and Update-SGNFSFileShare cmdlets with new parameters -ReadOnly and -Squash.
  * Amazon Cloud Directory
    - Updated the Get-CDIRObjectAttribute cmdlet with two new parameters, -FacetFilter_FacetName and -FacetFilter_SchemaArn, to support the new service feature enabling filtering by facet.

### 3.3.69.0 (2017-03-29)
  * AWS Batch
    - Added parameters to support specifying retry strategy for the Register-BATJobDefinition and Submit-BATJob cmdlets. The parameter, -RetryStrategy_Attempt, accepts a numeric value for attempts. This is the number of non successful executions before a job is considered FAILED. In addition, the JobDetail object returned by other cmdlets now has an attempts field and shows all execution attempts.
  * Amazon EC2
    - Added support for tagging Amazon EC2 Instances and Amazon EBS Volumes at the time of their creation with the addition of a parameter, -TagSpecification, to the New-EC2Volume and New-EC2Instance cmdlets. By tagging resources at the time of creation, you can eliminate the need to run custom tagging scripts after resource creation. In addition, you can now set resource-level permissions on the CreateVolume, CreateTags, DeleteTags, and the RunInstances APIs. This allows you to implement stronger security policies by giving you more granular control over which users and groups have access to these APIs. You can also enforce the use of tagging and control what tag keys and values are set on your resources. When you combine tag usage and resource-level IAM policies together, you can ensure your instances and volumes are properly secured upon creation and achieve more accurate cost allocation reporting. These new features are provided at no additional cost.
  * Added the legacy alias Get-SSMParameterNameList (an alias for Get-SSMParameterValue) to the AliasesToExport collection in the module manifest so that the alias is available without needing to explicitly import the module.

### 3.3.67.0 (2017-03-24)
  * AWS Application Discovery Service
    - Added two new cmdlets Get-ADSExportTask (DescribeExportTasks API) and Start-ADSExportTask (StartExportTask API) to support the new service feature for exporting configuration options.
  * AWS Lambda
    - Added argument completion support for the new Node.js v6.10 runtime option.

### 3.3.65.0 (2017-03-21)
  * Amazon S3
    - Fixed issue with the Write-S3Object cmdlet reporting error "The difference between the request time and the current time is too large" when uploading very large (> 100GB) files.
  * Amazon Pinpoint
    - Added cmdlets Get-PINEventStream (GetEventStream API), Remove-PINEventStream (DeleteEventStream API) and Write-PINEventStream (PutEventStream API) to support publishing of raw app analytics and campaign events data as events streams to Kinesis and Kinesis Firehose. The Update-PINSegment and New-PINSegment cmdlets were updated with a new parameter, -Dimensions_UserAttribute, to support the ability to segment endpoints by user attributes in addition to endpoint attributes.
  * All cmdlet names are now enumerated into the module manifest enabling tab-completion of command names without needing to explicitly import the module into the environment.

### 3.3.64.2 (2017-03-17)
  * Fixed issue with Initialize-AWSDefaults reporting 'source profile not found' error when run to load credentials from the 'default' profile.

### 3.3.64.1 (2017-03-15)
  * Added support for reading and writing credential profiles to both the AWS .NET SDK encrypted credential store and the shared credential store used by other AWS SDKs and tools. Previously credentials could only be read from both stores, and written to only the SDK's encrypted store.
  * Added support for new credential profile types supporting cross-account IAM roles (aka 'assume role' profiles) and credentials requiring use of an MFA. For more details on the updated credential support see the blog post announcing the update at https://aws.amazon.com/blogs/developer/aws-sdk-dot-net-credential-profiles/ and the credential setup topics in the user guide at http://docs.aws.amazon.com/powershell/latest/userguide/pstools-getting-started.html.
  * AWS Device Farm
    - Added support for network shaping. Network shaping allows users to simulate network connections and conditions while testing their Android, iOS, and web apps with AWS Device Farm. The update includes new cmdlets Get-DFNetworkProfile (GetNetworkProfile API), Get-DFNetworkProfileList (ListNetworkProfiles API), New-DFNetworkProfile (CreateNetworkProfile API), Remove-DFNetworkProfile (DeleteNetworkProfile API) and Update-DFNetworkProfile (UpdateNetworkProfile API).

### 3.3.62.0 (2017-03-13)
  * Fixed issue with Set-AWSSamlRoleProfile incorrectly formatting user identities specified in email format. The identity was being stored in the role profile with as \email@domain.com (domain\userid format) but with empty domain. The leading \ then had to be removed by the user each time a password demand was issued.
  * Amazon Relation Database Service
    - Updated the Copy-RDSDBClusterSnapshot and New-RDSDBCluster cmdlets to add support for using encrypted clusters as cross-region replication masters and encrypted cross region copy of Aurora cluster snapshots.
  * Amazon Simple Systems Management
    - Added help examples for all SSM cmdlets.
  * Amazon WorkDocs
    - Added support for the Amazon WorkDocs service. The Amazon WorkDocs SDK provides full administrator level access to WorkDocs site resources, allowing developers to integrate their applications to manage WorkDocs users, content and permissions programmatically. Cmd;lets for this service have the noun prefix 'WD' and can be listed using the command 'Get-AWSCmdletName -Service WD'.
  * AWS Organizations
    - *Breaking Change*
    Updated cmdlets to fix an issue with the wrong service model version being used. This may be a breaking change for some users. The Enable-ORGFullControl cmdlet has been removed, and the Enable-ORGAllFeatures cmdlet added in the corrected.
  * Amazon Cloud Directory
    - Added a new cmdlet, Get-CDIRObjectParentPath, to enable retrieval of all available parent paths for any type of object (a node, leaf node, policy node, and index node) in a hierarchy.
  * Amazon API Gateway
    - Updated the New-AGDomainName cmdlet to add support for ACM certificates on custom domain names. Both Amazon-issued certificates and uploaded third-part certificates are supported.
  * Amazon Elastic MapReduce
    - Added support for instance fleets with new cmdlets Add-EMRInstanceFleet (AddInstanceFleet API), Edit-EMRInstanceFleet (ModifyInstanceFleet API) and Get-EMRInstanceFleets (ListInstanceFleets API).

### 3.3.58.0 (2017-03-06)
  * Amazon EC2
    - Added two new keys, WINDOWS_2016_CORE and WINDOWS_2012R2_CORE, to the Get-EC2ImageByName cmdlet, to support retrieving the latest Windows Server 2016 Core and Windows Server 2012R2 Core AMIs.
  * AWS OpsWorks
    - OpsWorks for Chef Automate has added a new field "AssociatePublicIpAddress" to the New-OWCMServer cmdlet, "CloudFormationStackArn" to the Server model and "TERMINATED" server state.

### 3.3.57.0 (2017-02-27)
  * AWS Organizations
    - Added support for the new AWS Organizations service. AWS Organizations is a web service that enables you to consolidate your multiple AWS accounts into an organization and centrally manage your accounts and their resources. Cmdlets for this service have the noun prefix ORG and can be listed using the command Get-AWSCmdletName -Service ORG.
  * Amazon MTurk Service
    - Added support for Amazon Mechanical Turk (MTurk), a web service that provides an on-demand, scalable, human workforce to complete jobs that humans can do better than computers, for example, recognizing objects in photos. Cmdlets for this service have the noun prefix MTR and can be listed using the command Get-AWSCmdletName -Service MTR.
  * Amazon Elasticsearch
    - Added three cmdlets to support new APIs for exposing limits imposed by Elasticsearch. The new cmdlets are Get-ESInstanceTypeLimit (DescribeElasticsearchInstanceTypeLimits API), Get-ESInstanceTypeList (ListElasticsearchInstanceTypes API) and Get-ESVersionList (ListElasticsearchVersions API).
  * Amazon DynamoDB
    - Added two new cmdlets to support the new 'Time to Live' APIs. The new cmdlets are Get-DDBTimeToLive (DescribeTimeToLive API) and Update-DDBTimeToLive (UpdateTimeToLive API).

### 3.3.56.0 (2017-02-23)
  * Fixed issue with the Set-AWSSamlRoleProfile cmdlet reporting a null reference exception.
  * (NetCore module only) Fixed issue with cmdlet help not being available due to a misnamed help file.
  * Amazon EC2
    - Added -InstanceType completion support for the new I3 instance type.

### 3.3.55.0 (2017-02-22)
  * Amazon EC2
    - Updated the Register-EC2Image cmdlet with a new parameter, -BillingProduct.
  * Amazon GameLift
    - Added cmdlet support for the new service feature enabling developers to configure global queues for creating GameSessions and to allow PlayerData on PlayerSessions to store player-specific data.
  * AWS Elastic Beanstalk
    - Added support for creating and managing custom platforms with environments.
    - *Breaking Change*
      The update for custom platform support changed the service response data for the DescribeConfigurationOptions API (Get-EBConfigurationOption cmdlet) to include an additional field, PlatformArn. Previously the cmdlet was able to pipe the configuration options collection to the pipeline. In this release the output from the cmdlet has changed so that the entire service response data (Amazon.ElasticBeanstalk.Model.DescribeConfigurationOptionsResponse) is emitted to the pipeline, not the collection of configuration options. To obtain the previous behavior, add a select clause to your code, for example: 'Get-EBConfigurationOption ...parameters... | select -expandproperty Options | ...'.

### 3.3.53.1 (2017-02-20)
  * Fixed bug in Get-AWSCredentials. When the -ListProfiles switch was used the collection of profile names was not correctly enumerated to the pipeline.

### 3.3.53.0 (2017-02-17)
  * AWS Direct Connect
    - Added cmdlet support for the new ability for Direct Connect customers to take advantage of Link Aggregation (LAG). This allows you to bundle many individual physical interfaces into a single logical interface, referred to as a LAG. This makes administration much simpler as the majority of configuration is done on the LAG while you are free to add or remove physical interfaces from the bundle as bandwidth demand increases or decreases. A concrete example of the simplification added by LAG is that customers need only a single BGP session as opposed to one session per physical connection.

### 3.3.52.0 (2017-02-16)
  * This version was only distributed in the downloadable AWS Tools for Windows msi installer.
  * AWS Config
    - Updated the Write-CFGEvaluations cmdlet with a new parameter, -TestMode. Set the TestMode parameter to true in your custom rule to verify whether your AWS Lambda function will deliver evaluation results to AWS Config. No updates occur to your existing evaluations, and evaluation results are not sent to AWS Config.

### 3.3.51.0 (2017-02-15)
  * Amazon EC2
    - Added cmdlet support for the new Modify Volumes APIs. This includes two new cmdlets, Edit-EC2Volume (ModifyVolume API) and Get-EC2VolumeModification (DescribeVolumesModification API).
  * AWS Key Management Service
    - Added support for the new tagging apis with three new cmdlets: Add-KMSResourceTag (TagResource API), Get-KMSResourceTag (ListResourceTags API) and Remove-KMSResourceTag (UntagResource API). The New-KMSKey cmdlet was also extended to support a -Tag parameter.
  * AWS Storage Gateway
    - Updated the New-SGNFSFileShare and Update-SGNFSFileShare cmdlets to support acess to objects in S3 as files on a Network File System (NFS) mount point. Customers can restrict the clients that have read/write access to the gateway by specifying the list of clients as a list of IP addresses or CIDR blocks to the new -ClientList parameter on these cmdlets.

### 3.3.48.0 (2017-02-09)
  * Amazon EC2
    - Fixed issue with the Get-EC2Instance cmdlet not accepting instance IDs that were supplied as PSObject types. The cast to string on the supplied PSObject(s) failed, resulting in the cmdlet listing all instances on output, not the requested instances.
    - Added support for a new feature enabling users to associate an IAM profile with running instances that were not launched with a profile. The new cmdlets are Get-EC2IamInstanceProfileAssociation (DescribeIamInstanceProfileAssociations API), Register-EC2IamInstanceProfile (AssociateIamInstanceProfile API), Set-EC2IamInstanceProfileAssociation (ReplaceIamInstanceProfileAssociation API) and Unregister-EC2IamInstanceProfileAssociation (DisassociateIamInstanceProfileAssociation API).

### 3.3.47.0
  * This build was not released.

### 3.3.46.0 (2017-02-07)
  * Fixed issue with the Get-AWSCredentials cmdlet reporting a 'could not find part of path' error attempting to access the %userprofile%\.aws folder (default folder of the shared credentials file) when run on systems where the shared credential file was not in use and the folder did not exist. The cmdlet should instead have tested for folder existence and silently skipped over it when not present.
  * Fixed issue with using SAML credential profiles in regions where a region-specific Security Token Service endpoint is required, eg China (Beijing). After successfully authenticating with the ADFS endpoint the tools request temporary credentials from STS and this call was always directed against the global sts.amazonaws.com endpoint, not the regional endpoint, thus failing to obtain credentials. To enable SAML role profiles to specify that a regional endpoint must be used, the Set-AWSSAMLRoleProfile cmdlet has been extended with a new parameter, -STSEndpointRegion, that can be used to specify the region system name (eg -STSEndpointRegion cn-north-1), resulting in the correct STS endpoint being used to obtain credentials.
  * Amazon Lex
    - Added support for the new Amazon Lex service, for building conversational interactions into any application using voice or text. Cmdlets for this service have the noun prefix 'LEX' and can be viewed using the command 'Get-AWSCmdletName -Service LEX'. Currently the service contains a single cmdlet, Send-LEXText, corresponding to the service's PostText API.

### 3.3.45.0 (2017-01-26)
  * Amazon Cloud Directory
    - Added support for the new Amazon Cloud Directory service, a highly scalable, high performance, multi-tenant directory service in the cloud. Its web-based directories make it easy for you to organize and manage application resources such as users, groups, locations, devices, policies, and the rich relationships between them. Cmdlets for this service have the noun prefix 'CDIR' and can be viewed using the command 'Get-AWSCmdletName -Service CDIR'.
  * AWS CodeDeploy
    - Updated cmdlets to support the new service feature enabling blue/green deployments. In a blue/green deployment, the current set of instances in a deployment group is replaced by new instances that have the latest application revision installed on them. After traffic is rerouted behind a load balancer to the replacement instances, the original instances can be terminated automatically or kept running for other uses. In addition to additional parameters on existing cmdlets, two new cmdlets were added: Resume-CDDeployment (ContinueDeployment API) and Skip-CDWaitTimeForInstanceTermination (SkipWaitTimeForInstanceTermination API).
  * Amazon EC2
    - Updated the Request-EC2SpotFleet cmdlet with a new parameter, -SpotFleetRequestConfig_ReplaceUnhealthyInstance, to support instance health check functionality to replace EC2 spot fleet instances with new ones.
  * Amazon Relational Database Service
    - Updated cmdlets to support the new Snapshot Engine version upgrade. This update includes a new cmdlet, Edit-RDSDBSnapshot, mapped to the ModifyDBSnapshot API.

### 3.3.44.0 (2017-01-25)
  * Amazon WorkSpaces
    - *Breaking Change* Fixed issue with incorrect mapping of Stop-WKSWorkspace to the TerminateWorkspaces API, which could cause data loss if termination was not expected. A new cmdlet, Remove-WKSWorkspace, has been added which maps to the TerminateWorkspaces API. Stop-WKSWorkspace has been mapped to the StopWorkspaces API and the existing -Request parameter changed to accept types of Amazon.Workspaces.Model.StopRequest (previously it accepted Amazon.Workspaces.Model.TerminateRequest). For users employing New-Object to construct the parameters, this is a breaking change (customers known to have used this cmdlet in the past few months have been contacted about this change).
    - In addition to introducing a new cmdlet and correcting the mapping we have also taken steps to improve the usability of the cmdlets related to manipulating workspaces (Start-WKSWorkspace, Stop-WKSWorkspace, Remove-WKSWorkspace, Reset-WKSWorkspace and Rebuild-WKSWorkspace). These cmdlets all now support an additional –WorkspaceId parameter. This parameter accepts an array of strings that are the IDs of the workspaces to operate on, improving pipeline usability. Examples have been added to the cmdlet help to show the new simplified usages.
  * Elastic Load Balancing V2
    - Application Load Balancers now support native Internet Protocol version 6 (IPv6) in an Amazon Virtual Private Cloud (VPC). With this ability, clients can now connect to the Application Load Balancer in a dual-stack mode via either IPv4 or IPv6. The New-ELB2LoadBalancer was extended with a new parameter, -IpAddressType, to support this new feature and one new cmdlet was added, Set-ELB2IpAddressType (SetIpAddressType API).
  * Amazon Relational Database Service
    - Extended the New-RDSDBInstanceReadReplica cmdlet with parameters -KmsKeyId. -PresignedUrl and -SourceRegion to support cross-region read replica copying.

### 3.3.43.0 (2017-01-24)
  * AWS CodeCommit
    - Added new cmdlets Get-CCBlob (GetBlob API) and Get-CCDifferenceList (GetDifferences API) to support the new service feature for viewing differences between commits. The existing Get-CCBranchList and get-CCRepositoryList cmdlets have also been extended to support automatic pagination of all results now that it is supported on these API calls by the service.
  * Amazon EC2 Container Service (ECS)
    - Added a new cmdlet, Update-ECSContainerInstancesState (UpdateContainerInstancesState API) to support the new service feature enabling state for container instances that can be used to drain a container instance in preparation for maintenance or cluster scale down.

### 3.3.42.0 (2017-01-20)
  * This version was only distributed in the downloadable AWS Tools for Windows msi installer.
  * AWS Health
    - Updated the parameter documentation for several cmdlets to match latest service documentation updates.
  * AWS Certificate Manager
    - Updated the parameter documentation for several cmdlets to match latest service documentation updates.

### 3.3.41.0 (2017-01-19)
  * This version was only distributed in the downloadable AWS Tools for Windows msi installer.
  * Amazon EC2
    - Extended the Request-EC2SpotInstance cmdlet with a new parameter, Placement_Tenacy, to support the new service feature for dedicated tenancy, providing the ability to run Spot instances single-tenant manner on physically isolated hardware within a VPC to satisfy security, privacy, or other compliance requirements. Dedicated Spot instances can be requested using RequestSpotInstances and RequestSpotFleet.
  * AWS Health
    - Updated the parameter documentation for several cmdlets to match latest service documentation updates.

### 3.3.40.0 (2017-01-18)
  * This release contained only changes in the underlying AWS SDK for .NET and was not published to the gallery.

### 3.3.39.0 (2017-01-17)
  * Amazon DynamoDB
    - Added support for the new APIs to tag tables and indexes with three new cmdlets: Add-DDBResourceTag (TagResource API), Get-DDBResourceTag (ListTagsOfResource API) and Remove-DDBResourceTag (UntagResource API).

### 3.3.38.0 (2017-01-16)
  * AWS Cost and Usage Report
    - Added support for the new AWS Cost and Usage Report service. This service API allows you to enable and disable the Cost & Usage report, as well as modify the report name, the data granularity, and the delivery preferences. Cmdlets for this service have the noun prefix 'CUR' and can be viewed by running the command 'Get-AWSCmdletName -Service CUR'.

### 3.3.37.2 (2017-01-12)
  * Amazon EC2
    - Added new keys to the Get-EC2ImageByName cmdlet to support querying for Windows Server 2012R2 images with SQL Server 2016.

### 3.3.37.1 (2017-01-09)
  * AWS Health
    - Added support for the AWS Health service. The AWS Health API serves as the primary source for you to receive personalized information related to your AWS infrastructure, guiding your through scheduled changes, and accelerating the troubleshooting of issues impacting your AWS resources and accounts. Cmdlets for the service have the noun prefix 'HLTH' and can be viewed using the command 'Get-AWSCmdletName -Service HLTH'.
  * Get-AWSCmdletName
    - Fixed bug when invoking the cmdlet with no parameters. Instead of outputting the set of all service cmdlets an error 'Value cannot be null' was displayed.

### 3.3.37.0 (2017-01-05)
  * AWS Lambda
    - Updated the Publish-LMFunction and Update-LMFunctionCode with new parameters to support the latest features in these APIs (e.g. environment variable support, VPC configuration etc) and made both cmdlets consistent with support for specifying the function code to upload using an object in an Amazon S3 bucket. The parameter names used in both cmdlets have also been made consistent, with aliases applied for backwards compatibility. Help examples for the two cmdlets have also been added.
  * AWS Marketplace Commerce Analytics
    - Added argument completion support for the new data set disbursed_amount_by_instance_hours, with historical data available starting 2012-09-04. New data is published to this data set every 30 days.

### 3.3.36.0 (2016-12-29)
  * AWS CodeDeploy
    - Updated the Register-CDOnPremiseInstance cmdlet with a new parameter, -IamSessionArn, to support association of on-premise instances with IAM sessions.
  * Amazon EC2 Container Service (ECS)
    - Added and updated cmdlets to support the new service capability enabling placement of tasks on container instances and setting attributes on ECS resources. The new cmdlets are Get-ECSAttributeList (ListAttributes API), Remove-ECSAttribute (DeleteAttributes API) and Write-ECSAttribute (PutAttributes API).
  * Amazon Simple Systems Management
    - To better reflect its operation, the cmdlet Get-SSMParameterNameList has been renamed to Get-SSMParameterValue. An aliases submodule (AWSPowerShellLegacyAliases.psm1) has been added to the module that sets up a backwards compatible alias on module load for scripts that rely on the original cmdlet name.

### 3.3.35.0 (2016-12-22)
  * Amazon API Gateway
    - Added cmdlets to support the new service feature for generating SDKs in more languages. This update introduces two new operations used to dynamically discover these SDK types and what configuration each type accepts. The new cmdlets are: Get-AGSdkType (GetSdkType API), Get-AGSdkTypeList (GetSdkTypes API). In addition the existing cmdlet Write-AGMethod has been updated with a new parameter, -OperationName, enabling users to set a human-friendly operation identifier for the method.
  * AWS Identity and Access Management
    - Added new cmdlets to support service-specific credentials for IAM users. This makes it easier to onboard AWS CodeCommit customers. Service-specific credentials are username/password credentials that work with a single service (currently only AWS CodeCommit). The new cmdlets are: Get-IAMServiceSpecificCredentialList (ListServiceSpecificCredentials API), New-IAMServiceSpecificCredential (CreateServiceSpecificCredential API), Remove-IAMServiceSpecificCredential (DeleteServiceSpecificCredential API), Reset-IAMServiceSpecificCredential (ResetServiceSpecificCredential API) and Update-IAMServiceSpecificCredential (UpdateServiceSpecificCredential API).
  * AWS Elastic Beanstalk
    - Added a new cmdlet, Update-EBApplicationResourceLifecycle, to support the new UpdateApplicationVersionResourceLifecycle API.

### 3.3.34.0 (2016-12-22)
  * Amazon EC2 Container Registry
    - Updated cmdlets to support the service update to implement Docker Image Manifest V2, Schema 2 providing the ability to use multiple tags per image, support for storing Windows container images, and compatibility with the Open Container Initiative (OCI) image format. With this update, customers can also add tags to an image via PutImage and delete tags using BatchDeleteImage.
  * Amazon Relation Database Service
    - Updated the Copy-RDSDBSnapshot cmdlet to add support for cross region encrypted snapshot copying.

### 3.3.33.1 (2016-12-20)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Bug fix: Fixed issue with finding shared credentials file in user's home folder via %USERPROFILE% on some systems.
  * Amazon Kinesis Firehose
    - Extended the New-KINFDeliveryStream and Update-KINFDestination cmdlets to support the new service capability enabling users to process and modify records before Amazon Firehose delivers them to destinations.
  * Amazon Route53
    - Added enumeration completion for the new eu-west-2 and ca-central-1 regions.
  * AWS Storage Gateway
    - Added cmdlets to support the new File Gateway mode. File gateway is a new mode that supports a file interface into S3, alongside the current block-based volume and VTL storage. File gateway combines a service and virtual software appliance, enabling you to store and retrieve objects in Amazon S3 using industry standard file protocols such as NFS. The software appliance, or gateway, is deployed into your on-premises environment as a virtual machine (VM) running on VMware ESXi. The gateway provides access to objects in S3 as files on a Network File System (NFS) mount point. The new cmdlets are Get-SGFileShareList (ListFileShares API), Get-SGNFSFileShareList (DescribeNFSFileShares API), New-SGNFSFileShare (CreateNFSFileShare API), Remove-SGFileShare (DeleteFileShare API) and Update-SGNFSFileShare (UpdateNFSFileShare API). The existing New-SGCachediSCSIVolume cmdlet was also updated with a new parameter, -SourceVolumeARN, as part of this feature.

### 3.3.32.0 (2016-12-19)
  * AWS Application Discovery Service
    - Added cmdlets to support new APIs for grouping discovered servers into Applications with summary and neighbor data. Added support for additional filters enabled on the service's ListConfigurations and DescribeAgents APIs.

### 3.3.31.1 (2016-12-16)
  * Added support for the new EU West (London) region, eu-west-2.
  * AWS Batch
    - Added support for the new AWS Batch service, a batch computing service that lets customers define queues and compute environments and then submit work as batch jobs. Cmdlets for the service have the noun prefix 'BAT' and can be viewed using the command 'Get-AWSCmdletName -Service BAT'.
  * Amazon Simple System Management
    - Added new cmdlets to support the new patch baseline and patch compliance apis.
  * Amazon CloudWatch Logs
    - Added support for associating log groups with tags with new cmdlets: Add-CWLLogGroupTag (TagLogGroup API), Get-CWLLogGroupTag (ListTagLogGroups API) and Remove-CWLLogGroupTag (UntagLogGroup API). New-CWLLogGroup was also extended to support adding tags during group creation.
    - Extended the Write-CWLSubscriptionFilter cmdlet with a new parameter, -Distribution, enabling grouping of log data to an Amazon Kinesis stream in a more random distribution than the default grouping by log stream.
  * Amazon Relation Database Service
    - Added support for SSL enabled Oracle endpoints and task modification.
  * Bug fix: Fixed null reference error reported by Get-AWSCmdletName when run on latest versions of PowerShell 6 alpha.

### 3.3.30.0 (2016-12-09)
  * Added support for the new Canada (Central) region, ca-central-1.
  * AWS WAF Regional
    - Added support for the new AWS WAF Regional service, enabling customers to use AWS WAF directly on Application Load Balancers in a VPC within available regions to protect their websites and web services from malicious attacks such as SQL injection, Cross Site Scripting, bad bots, etc. Cmdlets for this service have the noun prefix 'WAFR' and can be viewed using the command 'Get-AWSCmdletName -Service WAFR'.
  * Amazon CloudFront
    - Updated the New-CFDistribution, New-CFDistributionWithTag and Update-CFDistribution cmdlets with support for adding Lambda function associations to cache behaviors.
  * Amazon Relation Database Service
    - Updates in the underlying AWS SDK for .NET support for Amazon RDS enable you to now specify cluster creation time in the DBCluster API cmdlets.

### 3.3.29.0 (2016-12-08)
  * Amazon S3
    - Added support for specifying object version id in the new object tagging cmdlets. If not supplied the tag values are set on or retrieved from the latest object version.
  * AWS Config Service
    - Updated the argument completers for the service to recognize the new support for Redshift Cluster, ClusterParameterGroup, ClusterSecurityGroup, ClusterSnapshot, ClusterSubnetGroup, and EventSubscription resource types for all customers.
  * Amazon SQS
    - Updates to cmdlet documentation.

### 3.3.28.0 (2016-12-07)
  * Amazon S3
    - Added support for the new object tagging apis with three new cmdlets: Get-S3ObjectTagSet (GetObjectTagging API), Write-S3ObjectTagSet (PutObjectTagging API) and Remove-S3ObjectTagSet (DeleteObjectTagging API).
  * Amazon EC2
    - Added argument completion support for the -InstanceType parameter for the new t2.xlarge, t2.2xlarge and R4 instance types.
  * AWS Config Service
    - The default number of config rules for users has been increased from 25 to 50. As part of this change the Get-CFGConfigRuleEvaluationStatus cmdlet has been extended to support pagination with the addition of -Limit and -NextToken parameters. By default the cmdlet will auto-paginate all available rules to the pipeline but if you want to manually iterate you can use these parameters to take full control of data retrieval.

### 3.3.27.0 (2016-12-02)
  Roll-up release of all new features and services added during AWS re:Invent 2016:
  * Amazon API Gateway
    - Updated and added cmdlets to support publishing your APIs on Amazon API Gateway as products on the AWS Marketplace. You can use cmdlets to associate your APIs on API Gateway with Marketplace Product Codes. API Gateway will then send metering data to the Marketplace Metering Service on your behalf. New cmdlets also enable documenting your API.
  * Amazon EC2
    - Updated cmdlets with support for IPv6 new F1 Instance types.
  * Amazon Pinpoint
    - Added support for the new Amazon Pinpoint service. Amazon Pinpoint makes it easy to run targeted campaigns to improve user engagement. Pinpoint helps you understand your users behavior, define who to target, what messages to send, when to deliver them, and tracks the results of the campaign. Cmdlets for the new service have the noun prefix 'PIN' and can be viewed using the command 'Get-AWSCmdletName -Service PIN'.
  * Amazon Simple Systems Management
    - Updated cmdlets to support all new features announced during the conference.
  * Amazon Lightsail
    - Added support for the new Amazon Lightsail service, a simplified VM creation and management service. Cmdlets for the new service have the noun prefix 'LS' and can be viewed with the command 'Get-AWSCmdletName -Service LS'.
  * Amazon Polly
    - Added suport for the new Amazon Polly service. Amazon Polly service turns text into lifelike speech, making it easy to develop applications that use high-quality speech to increase engagement and accessibility. Cmdlets for this service have a noun prefix of 'POL' and can be viewed with the command 'Get-AWSCmdletName -Service POL'.
  * Amazon Rekognition
    - Added support for the new Amazon Rekognition service, a deep-learning based service to search, verify and organize images. With Rekognition, you can detect objects, scenes, and faces in images. You can also search and compare faces. Cmdlets for the service have the noun prefix 'REK' and can be viewed with the command 'Get-AWSCmdletName -Service REK'.
  * AWS AppStream
    - Added support for AWS AppStream, a fully managed desktop application streaming service that provides users instant access to their apps from a web browser. The cmdlets for the new service have the noun prefix 'APS' and can be viewed using the command 'Get-AWSCmdletName -Service APS'.
  * AWS CodeBuild
    - Added support for the new AWS CodeBuild service, a fully-managed build service in the cloud. CodeBuild compiles source code, runs tests, and produces packages that are ready to deploy. Cmdlets for this service have a noun prefix of 'CB' and can be viewed with the command 'Get-AWSCmdletName -Service CB'.
  * AWS DirectConnect
    - Updated cmdlets to support IPv6. The update includes two new cmdlets, New-DCBGPPeer (CreateBGPPeer API) and Remove-DCBGPPeer (DeleteBGPPeer API).
  * AWS Elastic Beanstalk
    - Updated cmdlets to support the new integration with AWS CodeBuild.
  * AWS Lambda
    - Added cmdlet Get-LMAccountSetting to support the new GetAccountSettings API, added dotnetcore 1.0 as a supported runtime, and added support for DeadLetterConfig and event source mappings with Kinesis streams.
  * AWS OpsWorksCM
    - Added support for the new AWS OpsWorks Managed Chef service, enabling single tenant Chef Automate server. The Chef Automate server is fully managed by AWS and supports automatic backup, restore and upgrade operations. Cmdlets for the new service have the noun prefix 'OWCM' and can be viewed using the command 'Get-AWSCmdletName -Service OWCM'.
  * AWS Shield
    - Added support for the new AWS Shield service. AWS Shield is a managed Distributed Denial of Service (DDoS) protection for web applications running on AWS. Cmdlets for this service have a noun prefix of 'SHLD' and can be viewed with the command 'Get-AWSCmdletName -Service SHLD'.
  * AWS StepFunctions
    - Added support for the new AWS StepFunctions service. AWS StepFunctions allows developers to build cloud applications with breakthrough reliability using state machines. Cmdlets for the new service have the noun prefix 'SFN' and can be viewed using the command 'Get-AWSCmdletName -Service SFN'.
  * AWS X-Ray
    - Added support for the new AWS X-Ray service. AWS X-Ray helps developers analyze and debug distributed applications. With X-Ray, you can understand how your application and its underlying services are performing to identify and troubleshoot the root cause of performance issues and errors. Cmdlets for the new service have the noun prefix 'XR' and can be viewed with the command 'Get-AWSCmdletName -Service XR'.
  * AWS Import/Export Snowball
    - Updated cmdlets to support a new job type, added cmdlets to support the new cluster apis, and the new AWS Snowball Edge device to support local compute and storage use cases.

### 3.3.24.0 (2016-11-22)
  * Amazon S3
    - Added a new -Tier parameter to the Restore-S3Object cmdlet to support specifying the Amazon Glacier job retrieval tier.
  * AWS CloudFormation
    - Added a new cmdlet, Get-CFNImportList, to support the new ListImports API

### 3.3.23.0 (2016-11-21)
  * AWS CloudTrail
    - Added two new cmdlets to suppor configuring your trail with event selectors: Get-CTEventSelectors (GetEventSelectors API) and Write-CTEventSelectors (PutEventSelectors API).
  * Amazon S3
    - Extended the Get-S3ObjectMetadata and Restore-S3Object cmdlets with a new parameter to support requestor-pays.

### 3.3.22.0 (2016-11-18)
  * Amazon Gamelift
    - Added a new cmdlet, Get-GMLInstanceAccess (GetInstanceAccess API), providing the ability to remote access into GameLift managed servers.
  * AWS Lambda
    - Updated the Update-LMFunctionConfiguration cmdlet with a new parameter, -Environment_Variable, to support the new service functionality.
  * Amazon Elastic MapReduce
    - Added support for automatic Scaling of EMR clusters based on metrics. This update adds a new parameter -InstanceGroup to the Edit-EMRInstanceGroup cmdlet, adds parameters -AutoScalingRole and -ScaleDownBehavior to the Start-EMRJobFlow cmdlet, and adds new cmdlets Write-EMRAutoScalingPolicy (PutAutoScalingPolicy API), Stop-EMRStops (CancelSteps API) and Remove-EMRAutoScalingPolicy (RemoveAutoScalingPolicy API).
  * Amazon Elastic Transcoder
    - The Test-ETSRole cmdlet now emits a deprecation warning, due to the deprecation of the underlying TestRole service API.
    - Updated the New-ETSJob cmdlet with new parameters to add support for the new service feature emabling multiple media input files to be stitched together.
  * Application AutoScaling
    - Added support for setting a new target resource (EMR Instance Group) as a scalable target.

### 3.3.21.0 (2016-11-17)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon API Gateway
    - Added new parameters to several cmdlets to support custom encoding.
  * Amazon CloudWatch
    - Updated cmdlet documentation.
  * AWS Marketplace Metering
    - Added support for third party submission of metering records with two new cmdlets: Send-MMMeteringDataBatch (BatchMeterUsage API) and Get-MMCustomerMetadata (ResolveCustomer API).
  * Amazon SQS
    - Updated cmdlet documentation and added new parameters to Send-SQSMessage and Receive-SQSMessage cmdlets to support the new FIFO message queue feature.

### 3.3.20.0 (2016-11-16)
  * Amazon Route53
    - Added support for cross-account VPC assocation with new cmdlets: get-R53VPCAssociationAuthorizationList (ListVPCAssociationAuthorizations API), New-R53VPCAssociationAuthorization (CreateVPCAssociationAuthorization API) and Remove-R53VPCAssociationAuthorization (DeleteVPVAssociationAuthorization API).
    - Three cmdlets that were marked obsolete have now been removed due to the removal of the underlying service APIs (the service apis had also been set to return error states since being marked obsolete so no script would have been able to use them successfully). The cmdlets that have been removed were: Get-R53ChangeDetails, Get-R53ChangeBatchesByHostedZone and Get-R53ChangeBatchesByRRSet.
  * AWS Service Catalog
    - Added support for the new administrative operations with 32 new cmdlets. The full list of cmdlets for this service can be viewed with the command 'Get-AWSCmdletName -Service SC'.
    - [BREAKING CHANGE] With the addition of a new CreateProduct API for this service we have had to rename the original New-SCProduct cmdlet (which mapped to the ProvisionProduct API) to 'New-SCProvisionedProduct'. The New-SCProduct cmdlet now maps to the 'CreateProduct' API. We aplogize for any inconvenience this change may cause.

### 3.3.19.0 (2016-11-16)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon ElastiCache
    - Added a new parameter, -AuthToken, to the New-ECCacheCluster and New-ECReplicationGroup cmdlets to support provision of an authtoken for Redis.
  * AWS Directory Service
    - Added support for schema extensions with three new cmdlets: Get-DSSchemaExtension (ListSchemaExtensions API),  Start-DSSchemaExtension (StartSchemaExtension API) and Stop-DSSchemaExtension (CancelSchemaExtension API).
  * Amazon Kinesis
    - Updates to support describing shard limits, open shard count and stream creation timestamp. This includes two new cmdlets, Get-KINLimit (DescribeLimits API) and Update-KINShardCount (UpdateShardCount API).

### 3.3.18.0 (2016-11-15)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon Cognito Identity Provider
    - Added a new parameter, -Schema, to the New-CGIPIdentityPool cmdlet to support specifying schema attributes.

### 3.3.17.0 (2016-11-13)
  * AWS CloudFormation
    - Added a new cmdlet, Get-CFNExport, to support the new ListExports API. Also updated existing cmdlets to support resources to skip during rollback, and new ChangeSet types and transforms.
  * Amazon Simple Email Service
    - Added new cmdlets to support API updates enabling tracking of bounce, complaint, delivery, sent, and rejected email metrics with fine-grained granularity.
  * AWS Direct Connect
    - Added three new cmdlets to support tagging operations: Add-DCResourceTag (TagResource API), Get-DCResourceTag (DescribeTags API) and Remove-DCResourceTag (UntagResource API).
  * Amazon CloudWatch Logs
    - Updated cmdlets to add support for CloudWatch Metrics to Logs, a capability that helps pivot from your logs-extracted metrics directly to the corresponding logs.

### 3.3.14.0 (2016-10-25)
  * AWS Server Migration Service
    - Added support for the new Server Migration Service, an agentless service that makes it easier and faster for you to migrate thousands of on-premises workloads to AWS. Cmdlets for the service have the noun prefix 'SMS'. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "SMS"'.

### 3.3.13.0 (2016-10-20)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS Budgets
    - Added support for the new AWS Budgets service. Cmdlets for this service have the noun prefix 'BGT'. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "BGT"'.

### 3.3.12.0 (2016-10-19)
  * Amazon EC2
    - Added support for retrieving latest Windows Server 2016 images using the Get-EC2ImageByName cmdlet.

### 3.3.11.0 (2016-10-18)
  * Amazon EC2
    - Added HostId and Affinity parameters to the New-EC2Instance cmdlet to support launching instances on a dedicated host.
  * Bug fix: fixed issue in underlying AWS SDK for .NET that could lead to file corruption when updating the credential profile store file.
  * Amazon Relational Database Service
    - Added support for Amazon Aurora integration with other AWS services, allowing you to extend your Aurora DB cluster to utilize other capabilities in the AWS cloud. Permission to access other AWS services is granted by creating an IAM role with the necessary permissions, and then associating the role with your DB cluster. This support includes two new cmdlets, Add-RDSRoleToDBCluster (AddRoleToDBCluster API) and Remove-RDSRoleFromDBCluster (RemoveRoleFromDBCluster API).

### 3.3.10.0 (2016-10-17)
  * Added support for the new US East (Ohio) region. To select this region, specify the value 'us-east-2' for the -Region parameter when invoking a cmdlet.
  * Amazon Route53
    - Added support for specifying the new US East (Ohio) region when defining resource record sets.

### 3.3.9.0 (2016-10-13)
  * AWS Certificate Manager
    - Added a new cmdlet, Import-ACMCertificate, to support the new ImportCertificate API. This cmdlet enables users to import third-party SSL/TLS certificates into ACM.
  * Amazon Gamelift
    - Added a new cmdlet, Get-GMLInstance, to support the new DescribeInstances API. The existing cmdlets were also updated to support new service features to protect game developer resources (builds, alias, fleets, instances, game sessions and player sessions) against abuse.

### 3.3.8.0 (2016-10-12)
  * Amazon EC2 Container Registry
    - Added a new cmdlet, Get-ECRImageMetadata, to support the new DescribeImages API. This cmdlet can be used to expose image metadata which today includes image size and image creation timestamp.
  * Amazon ElastiCache
    - Updated cmdlets for service update adding support for a new major engine release of Redis, 3.2 (providing stability updates and new command sets over 2.8), as well as ElasticSupport for enabling Redis Cluster in 3.2, which provides support for multiple node groups to horizontally scale data, and superior engine failover capabilities.

### 3.3.6.2 (2016-10-11)
  * Added support for proxy bypass lists and 'bypass on local' mode for proxies configured using the Set-AWSproxy cmdlet. This enables use of proxies configured using this cmdlet in environments with SAML Federated Identity in an Active Directory Federated Services environment. Previously the proxy had to be configured at the system level.
  * Fixed issues with the Set-AWSCredentials cmdlet when attempting to store credential profiles on Nano Server instances. In previous releases the cmdlet would either display an error message about a missing CryptProtectData api or if the -ProfilesLocation parameter was used, the folder path used with the parameter had to exist before the credentials file could be created.

### 3.3.5.0 (2016-10-06)
  * Amazon Cognito Identity Provider
    - Added a cmdlet, New-CGIPUserAdmin, to support the new AdminCreateUser API. The New-CGIPUserPool and Update-CGIPUerPool cmdlets were also updated with new parameters related to email and administrator control of creating new users.

### 3.3.4.0 (2016-09-29)
  * Amazon EC2
    - Added support for convertible reserved instances with two new cmdlets: Get-EC2ReservedInstancesExchangeQuote (GetReservedInstancesExchangeQuote API) and Confirm-EC2ReservedInstancesExchangeQuote (AcceptReservedInstancesExchangeQuote API).
    - Added completion support for new m4.16xlarge, P2 and X1 instance types.

### 3.3.3.0 (2016-09-27)
  * AWS CloudFormation
    - Updated the New-CFNChangeSet, New-CFNStack, Remove-CFNStack, Resume-CFNUpdateRollback and UpdateStack with a new parameter, -RoleARN. When specified AWS CloudFormation uses the role's credentials to make calls on your behalf for future operations on the stack.

### 3.3.2.0 (2016-09-22)
  * Amazon API Gateway
    - Extended the argument completer for the -Type parameter on Write-AGIntegration to support the new values related to the Simple Proxy feature.

### 3.3.1.0 (2016-09-20)
  * Amazon Elastic MapReduce
    - Added support for Security Configurations which can be used to enable encryption at-rest and in-transit for certain applications on Amazon EMR with new cmdlets Get-EMRSecurityConfiguration (DescribeSecurityConfiguration API), Get-EMRSecurityConfigurationList (ListSecurityConfigurations API), New-EMRSecurityConfiguration (CreateSecurityConfiguration API) and Remove-EMRSecurityConfiguration (DeleteSecurityConfiguration API). The Start-EMRJobFlow cmdlet was also extended with a new '-SecurityConfiguration' parameter.
  * Amazon Relational Database Service
    - Added support for local time zones for AWS RDS SqlServer database instances: the Get-RDSDBEngineVersion was extended with a new parameter '-ListSupportedTimeZone' and the New-RDSDBInstance cmdlet was extended with a new parameter '-Timezone'.
  * Amazon Redshift
    - This release of Amazon Redshift introduces Enhanced VPC Routing. When you use Amazon Redshift Enhanced VPC Routing, Amazon Redshift forces all COPY and UNLOAD traffic between your cluster and your data repositories through your Amazon VPC. The Edit-RSCluster, New-RSCluster and Restore-RSFromClusterSnapshot cmdlets were extended with a new 'EnhancedVPCRouting' parameter.
  * AWS CodeDeploy
    - AWS CodeDeploy now integrates with Amazon CloudWatch alarms, making it possible to stop a deployment if there is a change in the state of a specified alarm for a number of consecutive periods, as specified in the alarm threshold. AWS CodeDeploy also now supports automatically rolling back a deployment if certain conditions are met, such as a deployment failure or an activated alarm. The New-CDDeployment cmdlet was extended with new parameters '-AutoRollbackConfiguration_Enabled' and '-AutoRollbackConfiguration_Event' and the Stop-CDDeployment cmdlet extended with a '-AutoRollbackEnabled' parameter. The New-CDDeploymentGroup and Update-CDDeploymentGroup cmdlets were extended with several parameters related to alarm configuration.

### 3.3.0.0 (2016-09-19)
  * This release marks the General Availability (GA) of the AWS Tools for PowerShell Core (AWSPowerShell.NetCore) and the underlying AWS SDK for .NET Core. Starting with this release both AWS modules for PowerShell will update in sync with new service releases and service updates. The product version has incremented to 3.3.0.0 to match the underlying product version of the SDK. For more information see the blog post at http://blogs.aws.amazon.com/net/post/Tx3O6TT4NKFM0FU/.
  * Set-AWSCredentials
    - Fixed an issue in the AWSPowerShell.NetCore version of the cmdlet that caused it to not update the credentials file on non-Windows systems.

### 3.1.101.0 (2016-09-15)
  * AWS Lambda
    - Extended the Update-LMFunctionCode cmdlet with a new parameter, -ZipFilename, that enables more a convenient way to specify the code to be updated. The original -ZipFile parameter, of type System.IO.MemoryStream, has been retained for backwards compatibility.
  * Amazon Relational Database Service
    - The Amazon.RDS.Model.DBCluster type in the underlying AWS SDK for .NET SDK has been extended with a new ReaderEndpoint property to support the new Aurora cluster reader end-point feature.

### 3.1.100.0 (2016-09-13)
  * Amazon S3
    - Extended the Amazon.S3.Model.S3Object type in the underlying AWS SDK for .NET with a new member containing the name of the bucket containing the object. This enables improved pipelining of the S3 cmdlets, for example you can now run a pipeline such as 'Get-S3Bucket | ? { $_.BucketName -like '*config*' } | Get-S3Object | ? { $_.Key -like '*.json' } | Read-S3Object -Folder C:\Temp'. Read-S3Object has been updated to accept an S3Object (or S3ObjectVersion) instance to allow for use downloading objects with the -File or -Folder parameters, the other S3 cmdlets will automatically bind BucketName, Key and VersionId parameters (where relevant) from the piped-in object.
  * AWS Service Catalog
    - Updated cmdlets to support the new Access Level Filtering feature.

### 3.1.99.0 (2016-09-08)
  * Amazon CloudFront
    - Updated the New-CFDistribution, New-CFDistributionWithTag and Update-CFDistribution to enable specifying HTTP2 support for distributions (-DistributionConfig_HttpVersion).

### [AWSPowerShell.NetCore] 3.2.8.0-RC (2016-09-08)
  * Updates the service API support in the module cmdlets to match the 3.1.98.0 release of the AWSPowerShell desktop edition.
  * Upgrades the underlying AWS SDK for .NET to the 2.3.8 RC version.

### 3.1.98.0 (2016-09-06)
  * Amazon Relation Database Service
    - Added support for the new DescribeSourceRegions API with new cmdlet Get-RDSSourceRegion. The DescribeSourceRegions API provides a list of all the source region names and endpoints for any region. Source regions are the regions where current region can get a replica or copy a snapshot from.
  * AWS CodePipeline
    -  Incorporated API revisions to correct naming of members in types used in the recently published view changes APIs. Please note these are breaking changes in the model shapes, but do not affect the published parameters of the cmdlets.

### 3.1.97.0 (2016-09-01)
  * Amazon Gamelift
    - Updated the New-GMLBuild cmdlet with a new parameter, -OperatingSystem, enabling customers to now use Linux in addition to Windows EC2 instances.
  * Amazon Cognito Identity Provider
    - Added support for bulk import of users with new cmdlets: Get-CGIPCSVHeader (GetCSVHeader API), Get-CGIPUserImportJob (DescribeUserImportJob API), Get-CGIPUserImportJobList (ListUserImportJobs API), New-CGIPUserImportJob (CreateUserImportJob API), Start-CGIPUserImportJob (StartUserImportJob API) and Stop-CGIPUserImportJob (StopUserImportJob API).
  * AWS Config
    - Updated the argument completer for parameters of type ResourceType to include support for specifying the application load balancer resource type.
  * Amazon Relation Database Service
    - Updates to the model types in the underlying AWS SDK for .NET to enable customers to add options to a RDS option group that are mutually exclusive. To avoid conflict issues while validating the request to add an option to the option group the API response now includes information about options that conflict with each other.

### 3.1.96.0 (2016-08-30)
  * Amazon CloudFront
    - Updated the New-CFDistribution, New-CFDistributionWithTag and Update-CFDistribution cmdlets with parameters to support querystring whitelisting. Customers can now choose to forward certain querystring keys instead of a.) all of them or b.) none of them.
  * Amazon Route53
    - Updated cmdlets to add support for new service features: support for the NAPTR DNS record type and support metric-based health check in ap-south-1 region. In addition a new cmdlet, Test-R53DNSAnswer, was added to support the new TestDNSAnswer API which enables customers to send a test query against a specific name server using spoofed delegation nameserver, resolver, and ECS IPs.
  * AWS CodePipeline
    - CodePipeline has introduced a new feature to return pipeline execution details. Execution details consists of source revisions that are running in the pipeline. Customers will be able to tell what source revisions that are running through the stages in pipeline by fetching execution details of each stage. This support includes a new cmdlet, Get-CPPipelineExecution (GetPipelineExecution API) and updates to the existing Write-CPJobSuccessResult and Write-CPThirdPartyJobSuccessResult cmdlets.

### 3.1.95.0 (2016-08-23)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * The Get-AWSPublicIpRange cmdlet was updated to return both IPv4 and IPv6 address range details.
  * Amazon Relation Database Service
    - The output objects in the from various Get-* (Describe* APIs) were updated to include resource ARNs.
  * AWS OpsWorks
    - Minor documentation update to support region expansion.

### [AWSPowerShell.NetCore] 3.2.7.0-Beta (2016-08-23)
  * First release of the AWS Tools for PowerShell Core ("AWSPowerShell.NetCore") module
    - The AWSPowerShell.NetCore module is built on top of the .NET Core version of the AWS SDK for .NET, which is in beta while we finish up testing and port a few more features from the .NET Framework version of the AWS SDK for .NET. Note that updates to this module for new service features may lag a little behind the sister AWS Tools for Windows PowerShell ("AWSPowerShell") module while the .NET Core version of the AWS SDK for .NET is in beta.
    - The services and service APIs supported in this release correspond to the 3.1.94.0 release of the AWSPowerShell module.
    - Installation Note:
      Some users are reporting issues with the Install-Module cmdlet built into PowerShell Core with errors related to semantic versioning (see https://github.com/OneGet/oneget/issues/202). Using the NuGet provider appears to resolve the issue currently. To install using this provider run this command, setting an appropriate destination folder (on Linux for example try -Destination ~/.local/share/powershell/Modules):

        Install-Package -Name AWSPowerShell.NetCore -Source https://www.powershellgallery.com/api/v2/ -ProviderName NuGet -ExcludeVersion -Destination <destination>

  * Unsupported cmdlets in this release
    - As noted in the blog post at http://blogs.aws.amazon.com/net/post/TxTUNCCDVSG05F/Introducing-AWS-Tools-for-PowerShell-Core-Edition there is a high degree of compatibility between the two AWS modules. A small number of cmdlets are not supported in this edition of the tools:
    -- Proxy cmdlets: Set-AWSProxy, Clear-AWSProxy
    -- Logging cmdlets: Add-AWSLoggingListener, Remove-AWSLoggingListener, Set-AWSResponseLogging, Enable-AWSMetricsLogging, Disable-AWSMetricsLogging
    -- SAML federated credentials cmdlets: Set-AWSSamlEndpoint, Set-AWSSamlRoleProfile
    -- Legacy EC2 import cmdlets: Import-EC2Instance, Import-EC2Volume
  * Known issues in this release
    - There are no known issues in this release of the tools.

### 3.1.94.0 (2016-08-18)
  * Amazon WorkSpaces
    - New cmdlets to support the launch and management of WorkSpaces that are paid for and used by the hour. The new cmdlets are Edit-WKSWorkspaceProperty (ModifyWorkspaceProperties API), Get-WKSWorkspacesConnectionStatus (DescribeWorkspacesConnectionStatus API) and Start-WKSWorkspace (StartWorkspaces API).
    NOTE: the new api to stop a workspace (StopWorkspace) is currently NOT supported as it clashes with an existing cmdlet, Stop-WKSWorkspace, which actually maps to the TerminateWorkspaces API. We are investigating correcting this with a new cmdlet, Remove-WKSWorkspace (which will map to TerminateWorkspaces) and updating the existing Stop-WKSWorkspace cmdlet to map to the new StopWorkspaces API. This is of course a breaking change.
  * Amazon EC2
    - Added support for dedicated host reservations with new cmdlets Get-EC2HostReservation (DescribeHostReservations API), Get-EC2HostReservationOffering (DescribeHostReservationOfferings API), Get-EC2HostReservationPurchasePreview (GetHostReservationPurchasePreview API) and New-EC2HostReservation (PurchaseHostReservation API).
  * Amazon S3
    - Added a -StorageClass parameter (type Amazon.S3.StorageClass) to the Copy-S3Object cmdlet. This parameter enables you to set the STANDARD_IA storage class in addition to the existing reduced redundancy and standard classes. The switch parameters used previously to set these classes have been retained for backwards compatibility but we encourage you to update your scripts to use the new parameter so that new classes Amazon S3 may add in future can be easily specified.
  * Fixed an issue in the Set-AWSSamlRoleProfile cmdlet that caused the user name to be stored with an initial \ if a domain name was not present in the supplied network credential. This could occur on systems where the user credential was created using user name in email format.
  * Added support for tab completion of region, credential profile and image keys (Get-EC2ImageByName).

### 3.1.93.0 (2016-08-16)
  * Authenticode signing has now been enabled for the module enabling it to be used in environments that mandate an 'AllSigned' execution policy. The module manifest (.psd1), new argument completion script module (.psm1) and type extension and formats files (.ps1xml) now all contain an Authenticode signature. For more information on execution policies see the Microsoft TechNet article at https://technet.microsoft.com/en-us/library/dd347641.aspx.
  * Custom argument completers have been added to the module to support service enumeration types in the underlying AWS SDK for .NET. When constructing a command at the console or in the Windows PowerShell ISE (or other PowerShell hosts) you can now access the valid values for an enumeration type using the Tab or Ctrl+Space key sequences. The ISE will automatically display the possible completions. For more information on this enhancement see the blog post "Argument Completion in Windows PowerShell" on the AWS .NET Development Blog, http://blogs.aws.amazon.com/net/.
  * Amazon API Gateway
    - Added cmdlets to support the new usage plan APIs. Usage plans allows you to easily manage and monetize your APIs for your API-based business.
    - [Breaking Change] The response data returned to the Get-AGApiKeyList cmdlet (GetApiKeys API) now contains a collection of warning messages for warnings logged during the import of API keys. This is incompatible with automatic pagination and therefore automatic pagination has been disabled for this cmdlet.

### 3.1.92.0 (2016-08-11)
  * Amazon Import/Export Snowball
    - Added cmdlets to support the new Import/Export Snowball service. The API for this service enables a customer to create and manage Snowball jobs without needing to use the AWS Console. The cmdlets for this service have the prefix 'SNOW' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "SNOW"'.
  * Amazon Kinesis Analytics
    - Added cmdlets to support the new Amazon Kinesis Analytics service, a fully managed service for continuously querying streaming data using standard SQL. With Kinesis Analytics, you can write standard SQL queries on streaming data and gain actionable insights in real-time, without having to learn any new programming skills. The service allows you to build applications that continuously read data from streaming data sources, process that data using standard SQL, and send the processed data to up to four destinations of your choice. Kinesis Analytics enables you to generate time-series analytics, feed a real-time dashboard, create real-time alarms and notifications, and much more. The cmdlets for this service have the prefix 'KINA' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "KINA"'.
  * Elastic Load Balancing V2
    - Added cmdlets to support the new V2 API for Elastic Load Balancing. The cmdlets for this service have the prefix 'ELB2' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "ELB2"'.
  * Auto Scaling
    - Added cmdlets to support the launch of the new V2 API for Elastic Load Balancing. The new cmdlets are Add-ASLoadBalancerTargetGroup (AttachLoadBalancerTargetGroups API), Dismount-ASLoadBalancerTargetGroup (DetachLoadBalancerTargetGroups API) and Get-ASLoadBalancerTargetGroup (DescribeLoadBalancerTargetGroups API).
  * AWS Key Management.
    - Added new cmdlets to support new import key features. This new support enables you to import keys from your own key management infrastructure to KMS for greater control over generation and storage of keys and meeting compliance requirements of sensitive workloads. The new cmdlets are Import-KMSKeyMaterial (ImportKeyMaterial API), Get-KMSParametersForImport (GetParametersForImport API) and Remove-KMSImportedKeyMaterial (DeleteImportedKeyMaterial API).
  * Amazon S3
    - Added support for dualstack (Ipv6) endpoints. All S3 cmdlets have been extended with a new -UseDualstackEndpoint switch parameter. If set, this parameter will cause the cmdlet to use the dualstack endpoint for the specified region. Note that not all regions support dualstack endpoints. You should consult S3 documentation to verify that a dualstack endpoint is available in the region you wish to use before specifying this switch.

### 3.1.91.0 (2016-08-09)
  * Amazon CloudFront
    - Added cmdlets to support tagging for Web and Streaming distributions. Tags make it easier for you to allocate costs and optimize spending by categorizing and grouping AWS resources. The new cmdlets are Add-CFResourceTag (TagResource API), Get-CFResourceTag (ListTagsForResource API), New-CFDistributionWithTag (CreateDistributionWithTags API), New-CFStreamingDistributionWithTags (CreateStreamingDistributionWithTags API) and Remove-CFResourceTag (UntagResource API).
  * Amazon EC2 Container Registry
    - Updated the Get-ECRImage cmdlet with a new parameter, -Filter_TagStatus, to support filtering of requests based on whether an image is tagged or untagged.
  * AWS Marketplace Commerce Analytics
    - Added a new cmdlet, Start-MCASupportDataExport, to support the new StartSupportDataExport API.

### 3.1.90.0 (2016-08-04)
  * Amazon Cognito Identity Provider
    - Updates to enable authentication support for Cognito User Pools. This update also added a number of new cmdlets: Approve-CGIPDevice (ConfirmDevice API), Disconnect-CGIPDeviceGlobal (GlobalSignOut API), Disconnect-CGIPUserGlobalAdmin (AdminUserGlobalSignOut API), Edit-CGIPDeviceStatus (UpdateDeviceStatus API), Edit-CGIP-DeviceStatusAdmin (AdminUpdateDeviceStatus API), Get-CGIPDeviceStatus (GetDevice API), Get-CGIPDeviceStatusAdmin (AdminGetDevice API), Get-CGIPDeviceList (ListDevices API), Get-CGIPDeviceListAdmin (AdminListDevices API), Send-CGIPAuthChallengeResponse (RespondToAuthChallenge API), Send-CGIPAuthChallengeResponseAdmin (AdminRespondToAuthChallenge API), Start-CGIPAuth (InitiateAuth API), Start-CGIPAuthAdmin (AdminInitiateAuth API), Stop-CGIPDeviceTracking (ForgetDevice API) and  Stop-CGIPDeviceTrackingAdmin (AdminForgetDevice API).
  * Amazon Gamelift
    - Added a new cmdlet, Find-GMLGameSession, to support the new SearchGameSessions API.
  * Amazon Relation Database Service
    - Added support for S3 snapshot ingestion with a new cmdlet, Restore-RDSDBClusterFromS3 (RestoreDBClusterFromS3 API). The Edit-RDSDBInstance cmdlet was also updated with a new parameter, -DBSubnetGroupName, to support moving DB instances between VPCs or different subnets within a VPC.

### 3.1.89.0 (2016-08-3)
  * Amazon Route53 Domains
    - Added new cmdlets to support new APIs: Update-R53DDomainRenewal (RenewDomain API, renew domains for a specified duration), Get-R53DDomainSuggestion (GetDomainSuggestions API) and Get-R53DBillingRecord (ViewBilling API).
  * Amazon Relation Database Service
    - Updated the Edit-RDSDBInstance cmdlet to support specifying license model. You can also now specify versioning of option groups.
  * AWS IoT
    - Added a new cmdlet Get-IOTOutgoingCertificate to support the new ListOutgoingCertificates API. Register-IOTCACertificate and Update-IOTCACertificate cmdlets were updated to support a new AllowAutoRegistration parameter.

### 3.1.88.0 (2016-07-30)
  * Amazon API Gateway
    - Updating the New-AGAuthorizer cmdlet to add support for Cognito User Pools Auth.
  * AWS Directory Service
    - Added support for new apis to manage routing with Microsoft AD. The new cmdlets are Add-DSIpRoutes (AddIpRoutes API), Get-DSIpRoutes (ListIpRoutes API) and Remove-DSIpRoutes (RemoveIpRoutes API).
  * Amazon Elasticsearch
    - Added a new parameter, -ElasticsearchVersion, to the New-ESDomain cmdlet to support selection of a new api version. Amazon Elasticsearch Version 2.3 offers improved performance, memory management, and security. It also offers several new features including: pipeline aggregations to perform advanced analytics like moving averages and derivatives, and enhancements to geospatial queries.

### 3.1.87.0 (2016-07-26)
  * AWS IoT
    - This update adds support for thing types. Thing types are entities that store a description of common features of Things that are of the same logical type. The new cmdlets to support Thing types are: Get-IOTThingType (DescribeThingType API), Get-IOTThingTypesList (ListThingTypes API), New-IOTThingType (CreateThingType API), Remove-IOTThingType (DeleteThingType API) and Set-IOTThingTypeDeprecation (DeprecateThingType API).

### 3.1.86.0 (2016-07-21)
  * AWS Config
    - Added new cmdlets Start-CFGConfigRulesEvaluation (StartConfigRulesEvaluation API) and Remove-CFGEvaluationResult (DeleteEvaluationResults API). For more information on rule evaluation see the release note at https://aws.amazon.com/about-aws/whats-new/2016/07/now-use-aws-config-to-record-changes-to-rds-and-acm-resources-and-write-config-rules-to-evaluate-their-state/.
  * AWS Certificate Manager
    - The output object (type Amazon.CertificateManager.Model.CertificateDetail) of the Get-CMCertificateDetail cmdlet (DescribeCertificate API) has been extended with a new field, FailureReason, indicating the reason why a certificate request failed.

### 3.1.85.1 (2016-07-19)
  * AWS Device Farm
    - Corrected a cmdlet name in the previous update. The cmdlet for the GetRemoteAccessSessions API should have been named Get-DFRemoteAccessSessionList.

### 3.1.85.0 (2016-07-19)
  * AWS Device Farm
    - Added support for new APIs for managing remote access sessions. This update adds the cmdlets Get-DFRemoteAccessSession (GetRemoteAccessSession API), Get-DFRemoteAccessSessions (ListRemoteAccessSessions API), Install-DFToRemoteAccessSession (InstallToRemoteAccessSession API), New-DFRemoteAccessSession (CreateRemoteAccessSession API), Remove-DFRemoteAccessSession (DeleteRemoteAccessSession API) and Stop-DFRemoteAccessSession (StopRemoteAccessSession API).
  * Amazon Simple Systems Management
    - Updated the Send-SSMCommand cmdlet with new parameters enabling notifications to be sent when a command terminates.

### 3.1.84.0 (2016-07-13)
  * Amazon RDS
    - Updated the Start-RDSDBClusterFailover (FailoverDBCluster API) cmdlet with a new parameter TargetDBInstanceIdentifier. Added a new cmdlet, Copy-RDSDBClusterParameterGroup, to support the new CopyDBClusterParameterGroup API.
  * Amazon ECS
    - Added a new parameter, Overrides_TaskRoleArn, to the New-ECSTask and Start-EC2Task cmdlets. Added a new parameter, TaskRoleArn, to the Register-ECSTaskDefinition cmdlet. These parameters enable you to specify an IAM role for tasks.
  * Amazon Database Migration Service
    - Updated various cmdlets with new CertificateArn and SslMode parameters enabling use of SSL-enabled endpoints. Added new cmdlets Get-DMSCertificate (DescribeCertificates API), Import-DSMCertificate (ImportCertificate API) and Remove-DSMCertificate (DeleteCertificate API).

### 3.1.83.0 (2016-07-07)
  * AWS Service Catalog
    - Added cmdlets to support the new AWS Service Catalog service. AWS Service Catalog allows organizations to create and manage catalogs of IT services that are approved for use on AWS. The cmdlets for this service have the prefix 'SC' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "Service Catalog"'.
  * AWS Config
    - Added a new cmdlet, Remove-CFGConfigurationRecorder, to support the new DeleteConfigurationRecorder API.
  * AWS Directory Service
    - Added new cmdlets to support resource tagging: Add-DSResourceTag (AddTagsToResource API), Get-DSResourceTag (ListTagsForResource API) and Remove-DSResourceTag (RemoveTagsFromResource API). Additionally, automatic pagination has been enabled for cmdlets in this service where the response data contains a single logical field that can be enumerated to the pipeline (Get-DSDirectory, Get-DSSnapshot and Get-DSTrust).

### 3.1.82.0 (2016-07-05)
  * AWS CodePipeline
    - Added support for manual approvals with a new cmdlet, Write-CPApprovalResult (PutApprovalResult API).

### 3.1.81.0 (2016-06-30)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS Database Migration Service
    - Added support to enable VpcSecurityGroupId to be specified for the replication instance.
  * Amazon Simple Systems Management
    - Added support for using Amazon SSM with any instance or virtual machine outside of AWS, including your own data centers or other clouds with cmdlets: Add-SSMResourceTag (AddTagsToResource API), Get-SSMActivation (DescribeActivations API), Get-SSMResourceTag (ListTagsForResource API), New-SSMActivation (CreateActivation API), Remove-SSMActivation (DeleteActivation API), Remove-SSMResourceTag (RemoveTagsFromResource API), Unregister-SSMManagedInstance (DeregisterManagedInstance API), Update-SSMManagedInstanceRole (UpdateManagedInstanceRole API).

### 3.1.80.0 (2016-06-28)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon EC2
    - Updated the Edit-EC2InstanceAttribute and Register-EC2Image cmdlets with new parameter -EnaSupport for specifying enhanced networking.
  * Amazon Elastic File System
    - Added new parameter -PerformanceMode to the New-EFSFileSystem cmdlet (CreateFileSystem API).
  * Amazon Gamelift
    - Added new cmdlets for multi-process support. The new cmdlets are Get-GMLGameSessionDetail (DescribeGameSessionDetails API), Get-GMLRuntimeConfiguration (DescribeRuntimeConfiguration API), Get-GMLScalingPolicy (DescribeScalingPolicies API), Remove-GMLScalingPolicy (DeleteScalingPolicy API), Update-GMLRuntimeConfiguration (UpdateRuntimeConfiguration API) and Write-GMLScalingPolicy (PutScalingPolicy API).

### 3.1.79.0 (2016-06-28)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.78.0 (2016-06-23)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon Cognito Identity
    - Added -CognitoIdentityProvider and -SamlProviderARN parameters to the New-CGIIdentityPool and Update-CGIIdentityPool cmdlets to support role customization.
  * AWS Direct Connect
    - Added two new cmdlets, Get-DCConnectionLoa (DescribeConnectionLoa API) and Get-DCInterconnectLoa (DescribeInterconnectLoa API).
  * Amazon EC2
    - Added support for IdentityId Format with new cmdlets Edit-EC2IdentityIdFormat (ModifyIdentityIdFormat API) and Get-EC2IdentityIdFormat (DescribeIdentityIdFormat API).

### 3.1.77.0 (2016-06-21)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS CodePipeline
    - Added a new cmdlet, Redo-CPStageExecution, to support the new RetryStageExecution API.

### 3.1.76.0 (2016-06-14)
  * Amazon Relational Database Service
    - Added a new cmdlet, Convert-RDSReadReplicaDBCluster, to support the new PromoteReadReplicaDBCluster API.
  * Amazon Simple Email Service
    - Added a new cmdlet, Set-SESIdentityHeadersInNotificationsEnable, to support the new SetIdentityHeadersInNotificationsEnabled API.

 ### 3.1.75.0 (2016-06-07)
  * AWS IoT
    - Added a new cmdlet, Get-IOTPolicyPrincipalsList, to support the new ListPolicyPrincipals API. ListPolicyPrincipals allows you to list all your principals (certificate or other credential, such as Amazon Cognito ID) attached to a given policy.
  * Amazon Machine Learning
    - Added support for new tagging APIs with new cmdlets Add-MLTag (AddTags API), Get-MLTag (DescribeTags API) and Remove-MLTag (DeleteTags API). Tags are commonly used for cost allocation and can be applied to Amazon Machine Learning datasources, models, evaluations, and batch predictions.

### 3.1.74.0 (2016-06-03)
  * AWS CodeDeploy
    - Added automatic pagination support to the Get-CDApplicationList, Get-CDApplicationRevisionList, Get-CDDeploymentConfigList, Get-CDDeploymentInstanceList, Get-CDDeploymentList and Get-CDOnPremiseInstanceList cmdlets.
  * Amazon Security Token Service (STS) and Identity and Access Management (IAM) Service
    - Corrected potential performance issue caused in the previous release by the automatic detection of region from EC2 instance metadata. If no region data was available locally (from parameter, shell variable or environment variable) the cmdlets could attempt to access metadata even when not running on an EC2 instance.
  * Amazon EC2
    - API update to the Request-EC2SpotFleet (RequestSpotFleet API) and Get-EC2SpotFleetRequest (DescribeSpotFleetRequests API). The RequestSpotFleet API can now indicate whether a Spot fleet will only 'request' the target capacity or also attempt to 'maintain' it. When you want to 'maintain' a certain target capacity, Spot fleet will place the required bids to meet this target capacity, and enable you to automatically replenish any interrupted instances. When you simply 'request' a certain target capacity, Spot fleet will only place the required bids but will not attempt to replenish Spot instances if capacity is diminished, nor will it submit bids in alternative Spot pools if capacity is not available. By default, the API is set to 'maintain'. The DescribeSpotFleetRequests API now returns two new parameters: the 'fulfilledCapacity' of a Spot fleet to indicate the capacity that has been successfully launched, and the 'type' parameter to indicate whether the fleet is meant to 'request' or 'maintain' capacity.

### 3.1.73.0 (2016-05-26)
  * Amazon EC2
    - Added a new cmdlet, Remove-EC2Instance (TerminateInstances API) following user suggestion. The existing -Terminate switch is still present on Stop-EC2Instance but is considered deprecated.
    - Added a new cmdlet, Get-EC2InstanceMetadata, to return instance metadata when running on EC2 instances. For more information see the blog post at http://blogs.aws.amazon.com/net/.
  * Added support for specifying AWS access key, secret key and session token values from environment variables. For more information see the blog post at http://blogs.aws.amazon.com/net/.
  * Added support for auto-detecting AWS region using instance metadata when cmdlets are run on EC2 instances. The Initialize-AWSDefaults cmdlets no longer prompts for region selection when run in this scenario. To set a region different to that in which the instance is running, specify the -Region parameter.

### 3.1.72.0 (2016-05-24)
  * Amazon EC2
    - Added the new cmdlet Get-EC2ConsoleSnapshot to support the new GetConsoleSnapshot API.
  * Amazon RDS
    - Added support for cross-account snapshot sharing with two new cmdlets Edit-RDSDBClusterSnapshot (ModifyDBClusterSnapshot API) and Get-RDSDBClusterSnapshot (DescribeDBClusterSnapshotAttributes API).

### 3.1.71.0 (2016-05-19)
  * AWS Application Discovery Service [Breaking Change]
    - The initial release for this service used an incorrect service model. The corrections involve two new new cmdlets, Get-ADSConfiguration (DescribeConfigurations API) and Get-ADSExportConfigurationsId (ExportConfigurations API). The existing Get-ADSExportConfiguration has been remapped to the correct DescribeExportConfigurations API.
  * Amazon ECS
    - Updated the ECSTaskDefinitionFamilies cmdlet to add a new Status parameter. This enables filtering on active, inactive, or all task definition families.

### 3.1.70.0 (2016-05-18)
  * Application Auto Scaling
    - Added support for Application Auto Scaling, a general purpose Auto Scaling service for supported elastic AWS resources. With Application Auto Scaling, you can automatically scale your AWS resources, with an experience similar to that of Auto Scaling. The cmdlets for this service have the prefix 'AAS' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service aas'.

### 3.1.69.0 (2016-05-17)
  * Amazon WorkSpaces
    - Added support for the new tagging APIs with three new cmdlets: Get-WKSTag (DescribeTags API), New-WKSTag (CreateTags API) and Remove-WKSTag (DeleteTags API).

### 3.1.68.0 (2016-05-12)
  * AWS Application Discovery Service [New Service]
    - Added cmdlets to support the new service. The AWS Application Discovery Service helps Systems Integrators quickly and reliably plan application migration projects by automatically identifying applications running in your data center, their associated dependencies, and their performance profile. Cmdlets for this service have the prefix 'ADS' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service ads'.
  * Amazon EC2 Simple Systems Management
    - Added support for the new document sharing features with two new cmdlets, Get-SSMDocumentPermission (DescribeDocumentPermission API) and Edit-SSMDocumentPermission (ModifyDocumentPermission API).
  * Amazon EC2
    - Added support for identitfying stale security groups with two new cmdlets, Get-EC2SecurityGroupReference (DescribeSecurityGroupReferences API) and Get-EC2StaleSecurityGroup (DescribeStaleSecurityGroups API).

### 3.1.67.0 (2016-05-10)
  * AWS Storage Gateway
    - Added a new cmdlet, Get-SGTape, to support the new ListTapes API.
  * Amazon Elastic MapReduce
    - Added parameter InstanceState to the Get-EMRInstances cmdlet to support filtering by state.

### 3.1.66.0 (2016-05-05)
  * Amazon EC2
    - The parameter '-Instance' on the Get-EC2Instance and Stop-EC2Instance cmdlets has been renamed to '-InstanceId' to match usage in other EC2 cmdlets (this is a backwards compatible change). The two affected cmdlets continue to accept collections of string instance ids, Amazon.EC2.Model.Instance objects or Amazon.EC2.Model.Reservation objects to specify the instances to operate on.
  * AWS Key Management, Amazon Security Token Service
    - Updated cmdlet documentation to match the latest service API reference.
  * Amazon API Gateway
    - Updated the Write-AGIntegration cmdlet to support a new parameter, -PassthroughBehavior. This parameter enables you to configure pass-through behavior for incoming requests based on the Content-Type header and the available request templates defined on the integration.

### 3.1.65.0 (2016-05-03)
  * Amazon Cognito Identity Provider
    - Added support for the new Cognito Identity Provider service. The cmdlets for this service have the noun prefix 'CGIP'; you can view the set of cmdlets available and the API functions they map to with the command 'Get-AWSCmdletName -Service cgip'.

### 3.1.64.0 (2016-04-28)
  * Amazon Route53 Domains
    - Add support for new service operations ResendContactReachabilityEmail (Send-R53DContactReachability cmdlet) and GetContactReachabilityStatus (Get-R53DContactReachabilityStatus).
  * AWS OpsWorks
    - Updated the New-OPSDeployment and New-OPSInstance cmdlets to add support for default tenancy selection.

### 3.1.63.0 (2016-04-26)
  * Amazon EC2
    - Added a new cmdlet, Edit-EC2VpcPeeringConnectionOption, to support the new ModifyVpcPeeringConnectionOptions API for VPC peering with ClassicLink.
  * Amazon EC2 Container Registry
    - The repository object output by Get-ECRRepository and other cmdlets has been extended to include the repository URL.

### 3.1.62.0 (2016-04-21)
  * AWS IoT
    - Added support for specifying the SQL rules engine to be used with new parameters on the New-IOTTopicRule and Set-IOTTopicRule cmdlets.
  * AWS Certificate Manager
    - Added support for tagging with new cmdlets Add-ACMCertificateTag (AddTagsToCertificate API), Get-ACMCertificateTagList (ListTagsForCertificate API) and Remove-ACMCertificateTag (RemoveTagsFromCertificate API).

### 3.1.61.0 (2016-04-19)
  * AWS Elastic Beanstalk
    - Added support for automatic platform version upgrades with managed updates with three new cmdlets: Get-EBEnvironmentManagedAction (DescribeEnvironmentManagedAction API), Get-EBEnvironmentManagedActionHistory (DescribeEnvironmentManagedActionHistory API) and Submit-EBEnvironmentManagedAction (ApplyEnvironmentManagedAction API).
  * Amazon Kinesis
    - Added support for enhanced monitoring with two new cmdlets: Enable-KINEnhancedMonitoring (EnableEnhancedMonitoring API) and Disable-KINEnhancedMonitoring (DisableEnhancedMonitoring API).
  * Amazon Kinesis Firehose
    - Updated the Update-KINFDestination and New-KINFDeliveryStream cmdlets with additional parameters to support Elastic Search and Cloudwatch Logs.
  * Amazon S3
    - Added support for S3 Accelerate. This adds two new cmdlets, Write-S3BucketAccelerateConfiguration (PutBucketAccelerateConfiguration API) and Get-S3BucketAccelerateConfiguration (GetBucketAccelerateConfiguration API). Cmdlets for S3 operations that support accelerated endpoints have a new parameter, -UseAccelerateEndpoint.

### 3.1.60.0 (2016-04-12)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS IoT
    - Added support for “Bring your own Certificate” with new cmdlets: Get-IOTCACertificate (DescribeCACertificate API), Get-IOTCACertificateList (ListCACertificates API), Get-IOTCertificateListByCA (ListCertificatesByCA API), Get-IOTRegistrationCode (GetRegistrationCode API), Register-IOTCACertificate (RegisterCACertificate API), Register-IOTCertificate (RegisterCertificate API), Remove-IOTCACertificate (DeleteCACertificate API), Remove-IOTRegistrationCode (DeleteRegistrationCode API) and Update-IOTCACertificate (UpdateCACertificate API).

### 3.1.59.0 (2016-04-08)
  * AWS Directory Service
    - Added support for conditional forwarding with new cmdlets New-DSConditionalForwarder (CreateConditionalForwarder API), Remove-DSConditionalForwarder (DeleteConditionalForwarder API), Get-DSConditionalForwarder (DescribeConditionalForwarders API), Remove-DSTrust (DeleteTrust API) and Update-DSConditionalForwarder (UpdateConditionalForwarder API).

### 3.1.58.0 (2016-04-06)
  * Amazon Security Token Service
    - Added a new cmdlet, Get-STSCallerIdentity, to support the new GetCallerIdentity API. This API returns details about the credentials used to make an API call.
  * Amazon Route 53
    - Updated the Update-R53HealthCheck cmdlet with new parameters, -InsufficientDataHealthStatus and -AlarmIdentifier_Name, to support CloudWatch metric-based health checks.
  * Amazon API Gateway
    - Added new cmdlets, Import-AGRestApi and Write-AGRestAopi, to support the ImportRestApi and PutRestApi operations.
  * Amazon Inspector
    - The cmdlets for this service have been recreated to match a major revision to the service API. Please note that existing scripts that use this service will need to be updated to work with the new API.

### 3.1.57.0 (2016-03-29)
  * AWS CloudFormation
    - Added support for ChangeSets. ChangeSets give users detailed information into what CloudFormation intends to perform when changes are executed to a stack, giving users the ability to preview and change the results before actually applying them. The new cmdlets are: Get-CFNChangeSet (DescribeChangeSet API), Get-CFNChangeSetList (ListChangeSets API), New-CFNChangeSet (CreateChangeSet API), Remove-CFNChangeSet (DeleteChangeSet API) and Start-CFNChangeSet (ExecuteChangeSet API).
  * Amazon ElastiCache
    - The Copy-ECSnapshot cmdlet has been updated to remove the -TargetBucket parameter. This parameter was included in a previous release due to an error in the service model.
  * Amazon Redshift
    - Added support for Cluster IAM Roles. Clusters can now assume an IAM Role to perform operations like COPY/UNLOAD as well as cryptographic operations involving KMS keys. This support includes a new cmdlet, Edit-RSClusterIamRoles, for the new ModifyClusterIamRoles API and the addition of an -IamRole parameter to the New-RSCluster and Restore-RSClusterFromSnapshot cmdlets.
  * AWS WAF
    - Added support for XSS (Cross-site scripting) protection in WAF with new cmdlets Get-WAFXssMatchSet (GetXssMatchSet API), Get-WAFXssMatchSetList (ListXssMatchSets API), New-WAFXssMatchSet (CreateXssMatchSet API), Remove-WAFXssMatchSet (DeleteXssMatchSet API) and Update-WAFXssMatchSet (UpdateXssMatchSet API).

### 3.1.56.0 (2016-03-25)
  * Amazon RDS
    - Extended the Edit-RDSDBInstance, New-RDSDBInstance and Restore-RDSDBInstanceFromDBSnapshot cmdlets with new parameters, -Domain and -DomainIAMRoleName, to support Windows Authentication for RDS SQL Server instances.
  * Amazon ElastiCache
    - Added support to allow vertically scaling from one instance type to another. This support consists of one new cmdlet, Get-ECAllowedNodeTypeModification (ListAllowedNodeTypeModifications API) and a new parameter, -CacheNodeType, added to the Edit-ECCacheCluster and Edit-ECReplicationGroup cmdlets.
  * AWS Storage Gateway
    - Added a new cmdlet, Set-SGLocalConsolePassword, to support the new SetLocalConsolePassword API.

### 3.1.55.0 (2016-03-22)
  * AWS Device Farm
    - Added new cmdlets to support purchasing and managing unmetered devices in a self service manner, and to stop runs which are currently executing. The new cmdlets are: Get-DFOffering (ListOfferings API), Get-DFOfferingStatus (GetOfferingStatus API), Get-DFOfferingTransaction (ListOfferingTransactions API), New-DFOfferingPurchase (PurchaseOffering API), New-DFOfferingRenewal (RenewOffering API) and Stop-DFRun (StopRun API).
  * Amazon RDS
    - Extended the New-RDSDBInstance and Edit-RDSDBInstance cmdlets with a new parameter, PromotionTier, to support customer specifiable fail-over order for read replicas in Amazon Aurora.
  * AWS Elastic Beanstalk
    - Updated the documentation for the cmdlets from the latest service documentation.

### 3.1.54.0 (2016-03-17)
  * AWS Cloud HSM
    - Added support for resource tagging with new cmdlets Set-HSMResourceTag (AddTagsToResource API), Get-HSMResourceTag (ListTagsForResource API) and  Remove-HSMResourceTag (RemoveTagsFromResource API).
  * AWS Marketplace Metering
    - Added support for the new service. Cmdlets for the service share the noun prefix 'MM' and can be listed with the command 'Get-AWSCmdletName -service mm'. At this time the service has a single cmdlet, Send-MMMeteringData (MeterUsage API).
  * Elastic Load Balancing
    - Corrected a help example for New-ELBLoadBalancerPolicy.

### 3.1.53.0 (2016-03-15)
  * AWS Database Migration Service
    - Added support for the new AWS Database Migration Service. Cmdlets for the service share the noun prefix 'DMS' and can be listed with the command 'Get-AWSCmdletName -Service dms'.
  * AWS CodeDeploy
    - Added new cmdlet Get-CDDeploymentGroupBatch to support the new BatchGetDeploymentGroups API.
  * Amazon Simple Email Service
    - Added new cmdlets Get-SESIdentityMailFromDomainAttributes (GetIdentityMailFromDomainAttributes API) and Set-SESIdentityMailFromDomain (SetIdentityMailFromDomain API) to support custom MAIL FROM domains. For more information see the service release notes at http://aws.amazon.com/releasenotes/Amazon-SES/8381987420423821.

### 3.1.52.1 (2016-03-11)
  * Amazon S3
    - Fixed issue with NullReferenceException error being reported when MFA serial and authentication values were supplied to the Remove-S3Object cmdlet.

### 3.1.52.0 (2016-03-10)
  * Amazon Redshift
    - Added support for restore tables from a cluster snapshot to a new table in an active cluster. The new cmdlets are Get-RSTableRestoreStatus (DescribeTableRestoreStatus API) and Restore-RSTableFromClusterSnapshot (RestoreTableFromClusterSnapshot API). For more information on this feature see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html#working-with-snapshot-restore-table-from-snapshot">Restoring a Table from a Snapshot</a>.

### 3.1.51.0 (2016-03-08)
  * Amazon Kineses
    - Added support for dataplane operations with new cmdlets Get-KINRecord (GetRecords API), Get-KINShardIterator (GetShardIterator API), Write-KINRecord (PutRecord API) and Write-KINMultipleRecord (PutRecords API). Write-KINRecord allows the data to be written to be specified using either a memory stream, simple text string or path to a file containing the data. Write-KINMultipleRecord currently supports only a memory stream within each individual record instance.
  * AWS CodeCommit
    - Added support for repository triggers and retrieving information about a commit. The new cmdlets are Get-CCCommit (GetCommit API), Get-CCRepositoryTrigger (GetRepositoryTriggers API), Set-CCRepositoryTrigger (PutRepositoryTriggers API) and Test-CCRepositoryTrigger (TestRepositoryTriggers API).

  * Amazon Kinesis Firehose
    - The Write-KINFRecord cmdlet has been updated to use the same parameter names for data sources as the new Write-KINRecord cmdlet for Amazon Kinesis. In addition support for supplying data in a file and supplying the name of the file to the cmdlet has been added. The new parameter names, -Blob (MemoryStream), -Text (simple text string) and -FilePath (fully qualified name of source data file) have had the original parameter names (Record_Data, Record_Text and Record_FilePath respectively) applied as aliases for backwards compatibility. These aliases have also been applied to the equivalent parameters in Write-KINRecord for consistency.

### 3.1.50.0 (2016-03-03)
  * AWS Directory Service
    - Added support for SNS topic notifications with new cmdlets Register-DSEventTopic (RegisterEventTopic API), Get-DSEventTopic (DescribeEventTopics API) and Unregister-DSEventTopic (DeregisterEventTopic API).

### 3.1.49.0 (2016-03-01)
  * Amazon API Gateway
    - Added new cmdlets, Clear-AGStageAuthorizerCache (FlushStageAuthorizersCache API) and Test-AGInvokeAuthorizer (TestInvokeAuthorizer API).
  * Amazon DynamoDB
    - Added new cmdlet, Get-DDBProvisionLimit (DescribeLimits API). This cmdlet enables you to query the current provisioning limits for your account.

### 3.1.48.0 (2016-02-26)
  * Auto Scaling
    - Added new InstanceId parameter to the Write-ASLifecycleActionHeartbeat and Complete-ASLifecycleAction cmdlets. Updated parameter documentation in several cmdlets to match latest service documentation.
  * AWS CloudFormation
    -  Added new RetainResource parameter to Remove-CFNStack for to allow the specification the logical IDs of resources that you want to retain after stack deletion.
    - Added Tag parameter to Update-CFNStack to enable updating of tags on stacks.
  * Amazon CloudFront
    - Minor help example and documentation updates.
  * Amazon CloudWatch Logs
    - Minor documentation update to several cmdlets.

### 3.1.47.0 (2016-02-23)
  * This version contained documentation updates for Amazon Route 53 and only released as part of the combined AWS SDK and Tools Windows Installer.

### 3.1.46.0 (2016-02-19)
  * This version contained minor documentation updates and only released as part of the combined AWS SDK and Tools Windows Installer.

### 3.1.45.0 (2016-02-18)
  * AWS Storage Gateway
    - Added a new cmdlet, New-SGTapeWithBarcode, to support the CreateTapeWithBarcode API.
  * AWS CodeDeploy
    - Added two new cmdlets, Get-CDApplicationRevisionBatch and Get-CDDeploymentInstanceBatch to support the BatchGetApplicationRevisions and BatchGetDeploymentInstances APIs.

### 3.1.44.0 (2016-02-17)
  * Amazon RDS
    - Updated the Copy-RDSDBSnapshot cmdlet with a new parameter, KmsKeyId, to support cross-account encrypted snapshot sharing and updated the documentation for several other cmdlets.

### 3.1.43.0 (2016-02-11)
  * Amazon API Gateway
    - Added new cmdlets to support custom request authorizers. With custom request authorizers, developers can authorize their APIs using bearer token authorization strategies, such as OAuth using an AWS Lambda function. The new cmdlets are Get-AGAuthorizer (GetAuthorizer API), Get-AGAuthorizerList (GetAuthorizers API), Get-AGExport (GetExport API), New-AGAuthorizer (CreateAuthorizer API), Remove-AGAuthorizer (DeleteAuthorizer API) and Update-AGAuthorizer (UpdateAuthorizer API).
  * AWS Lambda
    - Updated the Update-LMFunctionConfiguration cmdlet to add support for configuring a Lambda function to access resources in your VPC. These resources could be AWS service resources (for example, Amazon Redshift data warehouses, Amazon ElastiCache clusters, or Amazon RDS instances), or they could be your own services running on your own EC2 instances. For more information see http://docs.aws.amazon.com/lambda/latest/dg/vpc.html.

### 3.1.42.0 (2016-02-09)
  * Amazon Gamelift
    - Added support for Amazon Gamelift, a managed service that allows game developers the ability to deploy and configure their multiplayer games. The new cmdlets share the noun prefix 'GML'. The cmdlets and their mapping to the service APIs can be listed using the command 'Get-AWSCmdletName -Service gamelift' (or 'Get-AWSCmdletName -Service gml').
  * Amazon EC2
    - Updated the Get-EC2ImageByName cmdlet to fix an issue where the control file mapping the logical version-independent keys to filters could not be downloaded if a proxy was in use, causing the cmdlet to error out.
  * Amazon CloudFront
    - Added a new parameter ViewerCertificate_ACMCertificateARN to the New-CFDistribution and Update-CFDistribution cmdlets. This field replaces the ViewerCertificate_CertificateSource and ViewerCertificate_Certificate parameters that were recently added.
  * AWS Marketplace Commerce Analytics
    - Updated the New-MCADataSet cmdlet with a new parameter, CustomerDefinedValue. This parameter allows customers to submit arbitrary key/value pair strings which will be returned, as provided, in the response, enabling the user of customer-provided identifiers to correlate responses with their internal systems.
  * AWS Config
    - Documentation update for parameters in several cmdlets.

### 3.1.41.0 (2016-01-28)
  * AWS WAF
    - Added new cmdlets to support the constraint set APIs. These APIs can be used to block, allow, or monitor (count) requests based on the content in HTTP request bodies. This is the part of a request that contains any additional data that you want to send to your web server as the HTTP request body, such as data from an HTML form. The new cmdlets are: Get-WAFSizeConstraintSet (GetSizeConstraintSet API), Get-WAFSizeConstraintList (ListSizeConstraintSets API), New-WAFSizeConstraintSet (CreateSizeConstraintSet API), Remove-WAFSizeConstraintSet (DeleteSizeConstraintSet API) and Update-WAFSizeConstraintSet (UpdateSizeConstraintSet API).

### 3.1.40.0 (2016-01-21)
  * AWS Certificate Manager
    - New cmdlets have been added to support the new service. The cmdlets have the noun prefix 'ACM' and can be listed with the command 'Get-AWSCmdletName -Service ACM'. AWS Certificate Manager (ACM) is an AWS service that makes it easier for you to deploy secure SSL based websites and applications on the AWS platform.
  * AWS IoT
    - Added two new cmdlets, Enable-IOTTopicRule (EnableTopicRule API) and Disable-IOTTopicRule (DisableTopicRule API) to support the latest service updates.
  * AWS CloudFormation
    - Added a new cmdlet, Resume-CFNUpdateRollback to support the new ContinueUpdateRollback API.
  * all services
    - Updated the 'Related Links' data in the native PowerShell file to enable use of -Online with Get-Help. Previously this command and option would launch a browser onto the home page for the AWSPowerShell cmdlet reference. It now navigates to the online page for the cmdlet specified to Get-Help. Additional links pointing to the service API reference home page and user/developer guides, as appropriate, have also been added to the help file for the module (previously these were only present on the web-based help pages).

### 3.1.39.0 (2016-01-19)
  * This update contains some minor service and documentation updates (for AWS Device Farm, AWS OpsWorks and Amazon Security Token Service) to maintain versioning compatibility with the underlying AWS SDK for .NET release.

### 3.1.38.0 (2016-01-14)
  * Amazon CloudWatch Events
    - Added cmdlets to support the new Amazon CloudWatch Events service. CloudWatch Events allows you to monitor and rapidly react to changes in your AWS resources. The new cmdlets share the noun prefix 'CWE' and can be listed using the command 'Get-AWSCmdletName -Service CWE'.
  * Amazon EC2
    - Added cmdlets to support the new scheduled instances feature. The cmdlets are: Get-EC2ScheduledInstance (DescribeScheduledInstances API), Get-EC2ScheduledInstanceAvailability (DescribeScheduledInstanceAvailability), New-EC2ScheduledInstance (RunScheduledInstances API) and New-EC2ScheduledInstancePurchase (PurchaseScheduledInstances API).

### 3.1.37.0 (2016-01-12)
  * Amazon EC2
    - Added new cmdlets to support DNS resolution of public hostnames to private IP addresses when queried over ClassicLink. Additionally, you can now access private hosted zones associated with your VPC from a linked EC2-Classic instance. ClassicLink DNS support makes it easier for EC2-Classic instances to communicate with VPC resources using public DNS hostnames. The new cmdlets are: GetEC2VpcClassicLinkDnsSupport (DescribeVpcClassicLinkDnsSupport API), Enable-EC2VpcClassicLinkDnsSupport (EnableVpcClassicLinkDnsSupport API) and Disable-EC2VpcClassicLinkDnsSupport (DisableVpcClassicLinkDnsSupport API).
    - Extended help examples for EC2 cmdlets.

### 3.1.36.2 (2016-01-06)
  * Amazon EC2
    - Corrected parameters for the Get-EC2NetworkInterfaceAttribute cmdlet due to errors in the underlying SDK request class for the operation. The class and the cmdlet should have exposed a single Attribute parameter, not members for each value allowed for 'Attribute'.

### 3.1.36.1 (2015-12-22)
  * Initialize-AWSDefaults
    - Fixed further reported issue with the cmdlet reporting 'profile not found' error with no profile name detailed.
    - Fixed null reference error when running on EC2 instance launched with instance profile (for credentials), when trying to save profile containing only region data.

### 3.1.36.0 (2015-12-21)
  * Set-AWSSamlRoleProfile
    - Fixed issue in parsing SAML assertions containing role ARNs from different accounts with the same role names.
  * Amazon EC2 Container Registry (ECR)
    - Added support for the new EC2 Container Registry service, a secure, fully-managed Docker image registry that makes it easy for developers to store and retrieve Docker container images. The cmdlets for the service have the noun prefix 'ECR' and can be enumerated using the command 'Get-AWSCmdletName -Service ecr'.
  * Amazon ECS
    - Add support for deployment configurations to New/Update-ECSService cmdlets.
  * Amazon Elastic MapReduce
    - Update Start-EMRJobFLow cmdlet to accept the Instances_ServiceAccessSecurityGroup parameter.

### 3.1.35.0 (2015-12-17)
  * Fixed issue in AWS SDK for .NET causing 'Path cannot be the empty string or all whitespace' errors being output when running cmdlets on systems with account that had no home or profile folder (https://github.com/aws/aws-sdk-net/issues/287).
  * Amazon EC2
    - Added cmdlets Get-EC2NatGateway (DescribeNatGateways API), New-EC2NatGateway (CreateNatGateway API) and Remove-EC2NatGateway (DeleteNatGateway API) to support the new Managed NAT for VPCs feature.
  * AWS Config
    - Added RecordingGroup_IncludeGlobalResourceType parameter to Write-CFGConfigurationRecorder parameter to support Identity and Access Management (IAM) resource types.
  * Amazon CloudFront
    - Added new parameters to the New-CFDistribution and Update-CFDistribution cmdlets. For web distributions, you can now configure CloudFront to automatically compress files of certain types for both Amazon S3 and custom origins, so downloads are faster and your web pages render faster. Compression also reduces your CloudFront data transfer cost because you pay for the total amount of data served.
  * Amazon RDS
    - Add support for enhanced monitoring in RDS instances via new MonitoringInterval and MonitoringRoleArn parameters on the Edit-RDSDBInstance, New-RDSDBInstance and New-RDSDBInstanceReadReplica cmdlets.
  * AWS CloudTrail
    - Added support for trails that apply across all regions, and support for multiple trails per region.

### 3.1.34.0 (2015-12-15)
  * Fixed issue with Initialize-AWSDefaults reporting 'profile not found' error (with no profile name listed) when entering access and secret key credentials if the host system did not already have a profile named 'default'.
  * Amazon EC2
    - Added new parameters to Copy-EC2Image cmdlet (CopyImage API) enabling AMI copies where all the associated EBS snapshots are encrypted.

### 3.1.33.0 (2015-12-08)
  * Fixed issue with 'profile not found' errors when referencing credential profiles contained in the text-format credential files shared with the AWS CLI.
  * Auto Scaling
    - Added new cmdlet, Set-ASInstanceProtection to support the new SetInstanceProtection API.
  * Amazon RDS
    - Updated the New-RDSDBCluster, Restore-RDSDBClusterFromSnapshot and Restore-RDSDBClusterToPointInTime cmdlets to support encryption using keys managed through AWS Key Management System.

### 3.1.32.0 (2015-12-03)
  * AWS Directory Service
    - Added support for managed directories with new cmdlets Approve-DSTrust (VerifyTrust API), Get-DSTrust (DescribeTrusts API), New-DSMicrosoftAD (CreateMicrosoftAD API), New-DSTrust (CreateTrust API) and Remove-DSTrust (DeleteTrust API).
  * Amazon RDS
    - Added support for modifying DB port number with a new parameter, DBPortNumber, on the Edit-RDSDBInstance cmdlet.
  * Amazon Route 53
    - Added support for the new traffic policy APIs. Running the command 'Get-AWSCmdletName -Service R53 -ApiOperation Traffic -MatchWithRegex' will list the new cmdlets and the corresponding service APIs.
  * AWS Support ApiOperation
    - Fixed bug where the cmdlets did not fallback to assume us-east-1 region if no -Region parameter was supplied or a default region was set in the current shell. Note that if a default shell region is set up and it is not us-east-1 then the -Region parameter, with value us-east-1, must be supplied to the cmdlets when they are run.

### 3.1.31.0 (2015-12-01)
  * Added support for federated user identity with Active Directory Federation Services (AD FS). Two new cmdlets, Set-AWSSamlEndpoint and Set-AWSSamlRoleProfile, enable configuration of a provider endpoint (supporting SAML based identity federation) and one or more role profiles for roles a user is authorized to assume. Once configured the role profiles can then be used with the -ProfileName parameter to the Set-AWSCredentials cmdlet, or any cmdlet that makes AWS service operation calls, to obtain temporary time limited AWS credentials with automatic credential refresh on expiry.

### 3.1.30.0 (2015-11-23)
  * Amazon EC2 Container Service
    - Added support for task stopped reasons and task start/stop times. You can now see if a task was stopped by a user or stopped due to other reasons such as a failing Elastic Load Balancing health check, as well as the time the task was started and stopped. Service scheduler error messages have additional information that describe why tasks cannot be placed in the cluster.
  * AWS Elastic Beanstalk
    - Added support for composable web applications. Applications that consist of several linked modules (micro services architecture) can now deploy, manage, and scale their applications using EB with the new Group-EBEnvironments cmdlet (ComposeEnvironments API).
  * Amazon EC2
    - Added support for dedicated hosts. This feature enables the use of your own per-socket and per-core OS licenses in EC2. This release also supports two new cmdlets Edit-EC2IdFormat ()ModifyIdFormat API) and Get-EC2IdFormat (DescribeIdFormat API) that will be used to manage the transition to longer EC2 and EBS resource IDs. These APIs are reserved for future use.

### 3.1.29.0 (2015-11-19)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.28.0 (2015-11-13)
  * Amazon RDS
    - Updated the Edit-RDSDBInstance with a new parameter, -PubliclyAccessible, to support the new instance visibility service update. Also updated documentation on several cmdlets to note support for the new M4 instance types.

### 3.1.27.0 (2015-11-10)
  * Amazon API Gateway
    - Added suppport for stage variables to the New-AGDeployment, New-AGStage and Test-AGInvokeMethod cmdlets with a new parameter, -Variable, (of Hashtable type). Stage variables act like environment variables for use in your API setup and mapping templates and enable configuration of different deployment stages (e.g., alpha, beta, production) of your API.

### 3.1.26.0 (2015-11-07)
  * AWS IoT
    - Fixed an issue affecting New-IOTKeysAndCertificate, Update-IOTCertificate and others where 'signature mismatch' errors were being returned.

### 3.1.25.0 (2015-11-03)
  * AWS DeviceFarm
    - Added new cmdlets to support the AWS Device Farm APIs to manage projects, device pools, runs, and uploads.
  * Amazon S3
    - Added a new parameter, -StorageClass, to the Write-S3Object cmdlet. This parameter enables support for selecting the STANDARD_IA storage class as well as STANDARD and REDUCED_REDUNDANCY classes. The existing switch parameters for specifying storage class, -StandardStorage and -ReducedRedundancyStorage, have been marked as deprecated.
  * Get-AWSCmdletName
    - Fixed an issue with the -AwsCliCommand option throwing errors if the service identifier parsed from the command matched more than one service by prefix or name (for example 'ec2' matches both Amazon EC2 by prefix and EC2 Container Service by name). The option now looks at the prefix codes in preference and will only attempt to match on name terms if the prefix lookup yields no results.

### 3.1.24.0 (2015-11-02)
  * AWS Identity and Access Management
    - Updated cmdlets for the IAM policy simulator to help test, verify, and understand resource-level permissions.
  * Amazon API Gateway
    - Updated the Write-AGIntegration cmdlet to fix an issue with incorrect marshalling of requests to the service.

### 3.1.23.0 (2015-10-27)
  * Amazon API Gateway
    - Added support for Amazon API Gateway, a fully managed service that makes it easy for developers to create, publish, maintain, monitor, and secure APIs at any scale. The noun prefix for cmdlets belonging to the service is 'AG'.

### 3.1.22.0 (2015-10-26)
  * Amazon EC2 Simple Systems Management
    - Added support for EC2 Run Command APIs, a new EC2 feature that enables you to securely and remotely manage the configuration of your Amazon EC2 Windows instances. Run Command provides a simple way of automating common administrative tasks like executing scripts, running PowerShell commands, installing software or patches and more.
  * Amazon Kinesis Firehose
    - Added parameter 'Record_Text' to the Write-KINFRecord cmdlet to enable write of simple text records to the service.

### 3.1.21.0 (2015-10-22)
  * AutoScaling
    - Adding support for EBS encryption in block device mappings.
  * IdentityManagement
    - Enable Policy Simulator API to do simulation with resource-based policies.
  * Get-AWSCmdletName
    - Added support for listing all cmdlets for services matching the name/prefix supplied to the -Service parameter.

### 3.1.20.0 (2015-10-15)
  * KeyManagementService
    - Add support for deleting Customer Master Keys, including two new APIs for scheduling and canceling key deletion.

### 3.1.19.1 (2015-10-11)
  * AWS IoT
    - AWS IoT offering enables our users to leverage the AWS Cloud for their Internet of things use-cases. Cmdlets for the service are identified with a noun prefix code of 'IOT'.
  * AWS Lambda
    - Lambda now supports function versioning.
  * Amazon ECS
    - Task definitions now support more Docker options.

### 3.1.18.0 (2015-10-07)
  * Amazon Kinesis Firehose
    - Amazon Kinesis Firehose is a fully managed service for ingesting data streams directly into AWS data services such as Amazon S3 and Amazon Redshift. Cmdlets for the service are identified with a noun prefix code of 'KINF'
  * Amazon Inspector
    - Amazon Inspector is a new service from AWS that identifies security issues in your application deployments. Cmdlets for the service are identified with a noun prefix code of 'INS'
  * AWS Marketplace Commerce Analytics
    - The AWS Marketplace Commerce Analytics service allows marketplace partners to programmatically request business intelligence data from AWS Marketplace. Cmdlets for the service are identified with a noun prefix code of 'MCA'.
  * AWS Config
    - Added new cmdlets to support Config Rule and Evaluations.
  * Amazon Kinesis
    - Added two new Amazon Kinesis cmdlets Request-KINStreamRetentionPeriodDecrease, and Request-KINStreamRetentionPeriodIncrease that allow customers to choose how long their data records are stored in their Amazon Kinesis streams.

### 3.1.17.0 (2015-10-06)
  * Amazon
    - Added support for integrating CloudFront with AWS WAF
  * EC2
    - Added new property BlockDurationMinutes to Request-EC2SpotInstance cmdlet. This specifies the duration for which the instance is required.
  * WAF
    - Added support for the new service. Cmdlets for the service are identified with a noun prefix code of 'WAF'.

### 3.1.16.1 (2015-10-02)
  * Amazon Elasticsearch
    - Added support for the new service. Cmdlets for the service are identified with a noun prefix code of 'ES'.

### 3.1.16.0 (2015-10-01)
  * AWS CloudTrail
    - Added new cmdlets for AWS CloudTrail: Add-CTTag, Get-CTTag, Remove-CTTag, and Get-PublicKey. This release of CloudTrail includes support for log file integrity validation, log encryption with AWS KMS–Managed Keys (SSE-KMS), and trail tagging.
  * Amazon RDS
    - Added support for t2.large DB instance, support for copying tags to snapshot, and other minor updates.

### 3.1.15.0 (2015-09-28)
  * Amazon Simple Email Service
    - Amazon Simple Email Service can now accept incoming emails. You can configure Amazon SES to deliver messages to an Amazon S3 bucket, call an AWS Lambda function, publish notifications to Amazon SNS, drop messages, or bounce messages. Added new cmdlets to support this feature.
  * AWS CloudFormation
    - Added new Get-CFNAccountLimits cmdlet, added the ResourceType parameter to New-CFNStack and Update-CFNStack cmdlets.
  * Amazon EC2
    - Added a new cmdlet - Request-EC2SpotFleet.

### 3.1.14.0 (2015-09-17)
  * Amazon CloudWatch Logs
    - Added new cmdlets (Get-CWLExportTasks, New-CWLExportTask, Stop-CWLExportTask) to support exporting log data from Log Groups to Amazon S3 Buckets.

### 3.1.13.0 (2015-09-16)
  * SDK Update for Amazon S3
    - Updated the awssdk.s3.dll assembly to include the new STANDARD_IA storage class and support for multiple lifecycle transitions. There are no changes to the Amazon S3 cmdlets.

### 3.1.12.0 (2015-09-15)
  * Amazon EC2
    - Updated the Request-EC2SpotFleet cmdlet with support for specifying allocation strategy.
    - Get-EC2Snapshot now supports additional DataEncryptionKeyId and StateMessage parameters in the returned Snapshot object.
  * Amazon Elastic File System
    - Updated the Get-EFSMountTarget cmdlet to support a new MountTargetId parameter.
  * Amazon EC2 Simple Systems Manager
    - Fixed bug in the automatic pagination support in Get-SSMDocumentList cmdlet. The cmdlet caused the service to respond with an error message due to the MaxResults parameter being set higher than 25.
  * Amazon Route 53
    - Updated the New-R53HealthCheck and Update-R53HealthCheck cmdlets to add support for calculated and latency health checks.

### 3.1.11.0 (2015-09-10)
  * Amazon S3
    - Reworked progress indication for folder uploads so that the % progress bar tracks bytes uploaded versus total to send for all files. In previous versions it tracked the number of files uploaded which could lead to periods of no progress activity if the files were large.
  * AWS Identity and Access Management
    - Added new cmdlets (Get-IAMContextKeysForCustomPolicy, Get-IAMContextKeysForPrincipalPolicy, Test-IAMCustomPolicy and Test-IAMPrincipalPolicy) to support programmatic access to the IAM policy simulator. The SimulatePrincipalPolicy API (Test-IAMPrincipalPolicy) allows you to programmatically audit permissions in your account and validate a specific user’s permissions. The SimulateCustomPolicy API (Test-IAMCustomPolicy) provides a way to verify a new policy before applying it. These new APIs allow you to automate the validation and auditing of permissions for your IAM users, groups, and roles.

### 3.1.10.0 (2015-09-03)
  * Amazon S3
    - Fixed issue in AWS SDK for .NET that caused Read-S3Object to fail to download a hierarchy of files if zero length files were present in subfolders.
  * AWS Storage Gateway
    - Added new cmdlets (Add-SGResourceTag, Get-SGResourceTags and Remove-SGResourceTag) to support tagging Storage Gateway resources.

### 3.1.9.0 (2015-08-31)
  * Amazon S3
    - Fixed issue with -Verbose option reporting an incorrect count of uploaded files when Write-S3Object cmdlet completed processing.

### 3.1.8.0 (2015-08-27)
  * Amazon CloudFront
    - Added two cmdlets, New-CFSignedUrl and New-CFSignedCookie. These cmdlets enable you to generate signed urls and cookies, using canned or custom policies, to content in CloudFront distributions.
  * AWS Config
    - Added a new cmdlet, Get-CFGDiscoveredResource, to support the new ListDiscoveredResources service api.

### 3.1.7.0 (2015-08-27)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.6.0 (2015-08-25)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.5.1 (2015-08-17)
  * Amazon Cognito Identity
    - Added cmdlets for the control plane APIs. These new cmdlets have the noun prefix 'CGI'.

### 3.1.5.0 (2015-08-12)
  * Elastic Beanstalk
    - Added new cmdlets to support the new instance health APIs: Get-EBEnvironmentHealth (DescribeEnvironmentHealth API) and Get-EBInstanceHealth (DescribeInstancesHealth API).
  * Fixes
    - The Set-AWSCredentials and Initialize-AWSDefaults cmdlets have been updated to use the WriteVerbose api instead of directly writing to the console, allowing their output to be suppressed.

### 3.1.4.0 (2015-08-06)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.3.0 (2015-08-04)
  * DeviceFarm
    - Updated DeviceFarm cmdlets with latest service features, adding support for iOS and retrieving account settings.

### 3.1.2.0 (2015-07-30)
* RDS
    - Add support for Amazon Aurora.
* OpsWorks
    - Add support for ECS clusters.

### 3.1.1.0 (2015-07-28)
* CloudWatch Logs
    - Added cmdlets for 4 new APIs to support cross-account subscriptions. These allow you to collaborate with an owner of a different AWS account and receive their log events on your Amazon Kinesis stream (cross-account data sharing). The new cmdlets are Write-CWLDestination (PutDestination), Write-CWLDestinationPolicy (PutDestinationPolicy), Get-CWLDestination (DescribeDestinations) and Remove-CWLDestination (DeleteDestination).

### 3.1.0.0 (2015-07-28)
* The AWS Tools for Windows PowerShell have been updated to use the new version 3 of the AWS SDK for .NET. The version numbers for AWS SDK for .NET and AWS Tools for Windows PowerShell are kept in sync which is the reason for this major version bump to 3.1. There are otherwise no major changes to AWS Tools for Windows PowerShell.
