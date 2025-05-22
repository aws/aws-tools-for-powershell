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

