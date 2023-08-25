### 4.1.402 (2023-08-25 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.630.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.401 (2023-08-24 22:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.629.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QuickSight
    * Modified cmdlet Get-QSFolderPermission: added parameters MaxResult, Namespace, NextToken and NoAutoIteration.
    * Modified cmdlet Get-QSFolderResolvedPermission: added parameters MaxResult, Namespace, NextToken and NoAutoIteration.
    * Modified cmdlet New-QSFolder: added parameter SharingModel.

### 4.1.400 (2023-08-23 21:40Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.628.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.399 (2023-08-22 22:49Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.627.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSCustomDBEngineVersion: added parameters SourceCustomDbEngineVersionIdentifier and UseAwsProvidedLatestImage.

### 4.1.398 (2023-08-21 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.626.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon FinSpace User Environment Management Service
    * Modified cmdlet Update-FINSPKxClusterDatabasis: added parameter DeploymentConfiguration_DeploymentStrategy.
    * Modified cmdlet Update-FINSPKxEnvironmentNetwork: added parameter TransitGatewayConfiguration_AttachmentNetworkAclConfiguration.
  * Amazon Relational Database Service
    * Added cmdlet Request-RDSSwitchoverGlobalCluster leveraging the SwitchoverGlobalCluster service API.
    * Modified cmdlet Start-RDSFailoverGlobalCluster: added parameters AllowDataLoss and Switchover.

### 4.1.397 (2023-08-18 21:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.625.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeCommit
    * Added cmdlet Get-CCFileCommitHistoryList leveraging the ListFileCommitHistory service API.

### 4.1.396 (2023-08-17 21:29Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.623.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2VpcEndpoint: added parameter SubnetConfiguration.
    * Modified cmdlet New-EC2VpcEndpoint: added parameter SubnetConfiguration.

### 4.1.395 (2023-08-16 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.622.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.394 (2023-08-15 21:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.621.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet New-GLUEClassifier: added parameter CsvClassifier_Serde.
    * Modified cmdlet Update-GLUEClassifier: added parameter CsvClassifier_Serde.
  * Amazon Performance Insights
    * Added cmdlet Add-PIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PIPerformanceAnalysisReport leveraging the GetPerformanceAnalysisReport service API.
    * Added cmdlet Get-PIPerformanceAnalysisReportList leveraging the ListPerformanceAnalysisReports service API.
    * Added cmdlet Get-PIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-PIPerformanceAnalysisReport leveraging the CreatePerformanceAnalysisReport service API.
    * Added cmdlet Remove-PIPerformanceAnalysisReport leveraging the DeletePerformanceAnalysisReport service API.
    * Added cmdlet Remove-PIResourceTag leveraging the UntagResource service API.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceRecommendationsJob: added parameter ContainerConfig_SupportedResponseMIMEType.

### 4.1.393 (2023-08-14 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.620.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Omics
    * Added cmdlet Get-OMICSAnnotationStoreVersion leveraging the GetAnnotationStoreVersion service API.
    * Added cmdlet Get-OMICSAnnotationStoreVersionList leveraging the ListAnnotationStoreVersions service API.
    * Added cmdlet Get-OMICSShare leveraging the GetShare service API.
    * Added cmdlet Get-OMICSShareList leveraging the ListShares service API.
    * Added cmdlet New-OMICSAnnotationStoreVersion leveraging the CreateAnnotationStoreVersion service API.
    * Added cmdlet New-OMICSShare leveraging the CreateShare service API.
    * Added cmdlet Receive-OMICSShare leveraging the AcceptShare service API.
    * Added cmdlet Remove-OMICSAnnotationStoreVersion leveraging the DeleteAnnotationStoreVersions service API.
    * Added cmdlet Remove-OMICSShare leveraging the DeleteShare service API.
    * Added cmdlet Update-OMICSAnnotationStoreVersion leveraging the UpdateAnnotationStoreVersion service API.
    * Modified cmdlet New-OMICSAnnotationStore: added parameter VersionName.
    * Modified cmdlet Start-OMICSAnnotationImportJob: added parameter VersionName.

### 4.1.392 (2023-08-11 21:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.619.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.391 (2023-08-10 21:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.618.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Add-CONNTrafficDistributionGroupUser leveraging the AssociateTrafficDistributionGroupUser service API.
    * Added cmdlet Get-CONNTrafficDistributionGroupUserList leveraging the ListTrafficDistributionGroupUsers service API.
    * Added cmdlet Remove-CONNTrafficDistributionGroupUser leveraging the DisassociateTrafficDistributionGroupUser service API.
    * Modified cmdlet Update-CONNTrafficDistribution: added parameters AgentConfig_Distribution and SignInConfig_Distribution.
  * Amazon Elastic Load Balancing V2
    * Modified cmdlet Set-ELB2SecurityGroup: added parameter EnforceSecurityGroupInboundRulesOnPrivateLinkTraffic.

### 4.1.390 (2023-08-09 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.617.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Voice
    * Modified cmdlet New-CHMVOPhoneNumberOrder: added parameter Name.
    * Modified cmdlet Update-CHMVOPhoneNumber: added parameter Name.
  * Amazon FSx
    * Modified cmdlet New-FSXDataRepositoryTask: added parameters DurationSinceLastAccess_Unit and DurationSinceLastAccess_Value.
    * Modified cmdlet New-FSXFileSystem: added parameters OpenZFSConfiguration_EndpointIpAddressRange, OpenZFSConfiguration_PreferredSubnetId and OpenZFSConfiguration_RouteTableId.
    * Modified cmdlet New-FSXFileSystemFromBackup: added parameters OpenZFSConfiguration_EndpointIpAddressRange, OpenZFSConfiguration_PreferredSubnetId and OpenZFSConfiguration_RouteTableId.
    * Modified cmdlet Update-FSXFileSystem: added parameters OpenZFSConfiguration_AddRouteTableId, OpenZFSConfiguration_RemoveRouteTableId and StorageType.

### 4.1.389 (2023-08-08 21:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.616.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Added cmdlet Get-BAKProtectedResourcesByBackupVaultList leveraging the ListProtectedResourcesByBackupVault service API.
    * Added cmdlet New-BAKLogicallyAirGappedBackupVault leveraging the CreateLogicallyAirGappedBackupVault service API.
    * Modified cmdlet Get-BAKBackupVault: added parameter BackupVaultAccountId.
    * Modified cmdlet Get-BAKBackupVaultList: added parameters ByShared and ByVaultType.
    * Modified cmdlet Get-BAKRecoveryPoint: added parameter BackupVaultAccountId.
    * Modified cmdlet Get-BAKRecoveryPointRestoreMetadata: added parameter BackupVaultAccountId.
    * Modified cmdlet Get-BAKRecoveryPointsByBackupVaultList: added parameter BackupVaultAccountId.
  * Amazon ElastiCache
    * Added cmdlet Test-ECMigration leveraging the TestMigration service API.

### 4.1.388 (2023-08-07 21:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.615.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.387 (2023-08-04 21:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.614.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Update-CONNRoutingProfileAgentAvailabilityTimer leveraging the UpdateRoutingProfileAgentAvailabilityTimer service API.
    * Modified cmdlet New-CONNRoutingProfile: added parameter AgentAvailabilityTimer.

### 4.1.386 (2023-08-03 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.613.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Database Migration Service
    * Added cmdlet Edit-DMSConversionConfiguration leveraging the ModifyConversionConfiguration service API.
    * Added cmdlet Edit-DMSDataProvider leveraging the ModifyDataProvider service API.
    * Added cmdlet Edit-DMSInstanceProfile leveraging the ModifyInstanceProfile service API.
    * Added cmdlet Edit-DMSMigrationProject leveraging the ModifyMigrationProject service API.
    * Added cmdlet Export-DMSMetadataModelAssessment leveraging the ExportMetadataModelAssessment service API.
    * Added cmdlet Get-DMSConversionConfiguration leveraging the DescribeConversionConfiguration service API.
    * Added cmdlet Get-DMSDataProvider leveraging the DescribeDataProviders service API.
    * Added cmdlet Get-DMSExtensionPackAssociation leveraging the DescribeExtensionPackAssociations service API.
    * Added cmdlet Get-DMSInstanceProfile leveraging the DescribeInstanceProfiles service API.
    * Added cmdlet Get-DMSMetadataModelAssessment leveraging the DescribeMetadataModelAssessments service API.
    * Added cmdlet Get-DMSMetadataModelConversion leveraging the DescribeMetadataModelConversions service API.
    * Added cmdlet Get-DMSMetadataModelExportsAsScript leveraging the DescribeMetadataModelExportsAsScript service API.
    * Added cmdlet Get-DMSMetadataModelExportsToTarget leveraging the DescribeMetadataModelExportsToTarget service API.
    * Added cmdlet Get-DMSMetadataModelImport leveraging the DescribeMetadataModelImports service API.
    * Added cmdlet Get-DMSMigrationProject leveraging the DescribeMigrationProjects service API.
    * Added cmdlet New-DMSDataProvider leveraging the CreateDataProvider service API.
    * Added cmdlet New-DMSInstanceProfile leveraging the CreateInstanceProfile service API.
    * Added cmdlet New-DMSMigrationProject leveraging the CreateMigrationProject service API.
    * Added cmdlet Remove-DMSDataProvider leveraging the DeleteDataProvider service API.
    * Added cmdlet Remove-DMSInstanceProfile leveraging the DeleteInstanceProfile service API.
    * Added cmdlet Remove-DMSMigrationProject leveraging the DeleteMigrationProject service API.
    * Added cmdlet Start-DMSExtensionPackAssociation leveraging the StartExtensionPackAssociation service API.
    * Added cmdlet Start-DMSMetadataModelAssessment leveraging the StartMetadataModelAssessment service API.
    * Added cmdlet Start-DMSMetadataModelConversion leveraging the StartMetadataModelConversion service API.
    * Added cmdlet Start-DMSMetadataModelExportAsScript leveraging the StartMetadataModelExportAsScript service API.
    * Added cmdlet Start-DMSMetadataModelExportToTarget leveraging the StartMetadataModelExportToTarget service API.
    * Added cmdlet Start-DMSMetadataModelImport leveraging the StartMetadataModelImport service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2Instance: added parameter EnablePrimaryIpv6.
    * Modified cmdlet Edit-EC2NetworkInterfaceAttribute: added parameter EnablePrimaryIpv6.
    * Modified cmdlet New-EC2NetworkInterface: added parameter EnablePrimaryIpv6.

### 4.1.385 (2023-08-02 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.612.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Cognito Identity Provider
    * Added cmdlet Get-CGIPLogDeliveryConfiguration leveraging the GetLogDeliveryConfiguration service API.
    * Added cmdlet Set-CGIPLogDeliveryConfiguration leveraging the SetLogDeliveryConfiguration service API.
  * Amazon Resilience Hub
    * Added cmdlet Get-RESHAppAssessmentComplianceDriftList leveraging the ListAppAssessmentComplianceDrifts service API.
    * Added cmdlet Set-RESHUpdateRecommendationStatus leveraging the BatchUpdateRecommendationStatus service API.
    * Modified cmdlet Get-RESHAppVersionList: added parameters EndTime and StartTime.
    * Modified cmdlet New-RESHApp: added parameters EventSubscription, PermissionModel_CrossAccountRoleArn, PermissionModel_InvokerRoleName and PermissionModel_Type.
    * Modified cmdlet Publish-RESHAppVersion: added parameter VersionName.
    * Modified cmdlet Update-RESHApp: added parameters EventSubscription, PermissionModel_CrossAccountRoleArn, PermissionModel_InvokerRoleName and PermissionModel_Type.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMScalingConfigurationRecommendation leveraging the GetScalingConfigurationRecommendation service API.

### 4.1.384 (2023-08-01 21:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.611.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Internet Monitor
    * Modified cmdlet New-CWIMMonitor: added parameters AvailabilityLocalHealthEventsConfig_HealthScoreThreshold, AvailabilityLocalHealthEventsConfig_MinTrafficImpact, AvailabilityLocalHealthEventsConfig_Status, PerformanceLocalHealthEventsConfig_HealthScoreThreshold, PerformanceLocalHealthEventsConfig_MinTrafficImpact and PerformanceLocalHealthEventsConfig_Status.
    * Modified cmdlet Update-CWIMMonitor: added parameters AvailabilityLocalHealthEventsConfig_HealthScoreThreshold, AvailabilityLocalHealthEventsConfig_MinTrafficImpact, AvailabilityLocalHealthEventsConfig_Status, PerformanceLocalHealthEventsConfig_HealthScoreThreshold, PerformanceLocalHealthEventsConfig_MinTrafficImpact and PerformanceLocalHealthEventsConfig_Status.
  * Amazon Database Migration Service
    * Added cmdlet Get-DMSEngineVersion leveraging the DescribeEngineVersions service API.
  * Amazon Elemental MediaLive
    * Modified cmdlet Update-EMLInputDevice: added parameter AvailabilityZone.
  * Amazon Relational Database Service
    * Added cmdlet Get-RDSDBClusterAutomatedBackup leveraging the DescribeDBClusterAutomatedBackups service API.
    * Added cmdlet Remove-RDSDBClusterAutomatedBackup leveraging the DeleteDBClusterAutomatedBackup service API.
    * Modified cmdlet Get-RDSDBClusterSnapshot: added parameter DbClusterResourceId.
    * Modified cmdlet Remove-RDSDBCluster: added parameter DeleteAutomatedBackup.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter SourceDbClusterResourceId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceRecommendationsJob: added parameters Stairs_DurationInSecond, Stairs_NumberOfStep, Stairs_UsersPerStep and StoppingConditions_FlatInvocation.

### 4.1.383 (2023-07-31 21:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.610.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify UI Builder
    * Modified cmdlet New-AMPUICodegenJob: added parameters ApiConfiguration_DataStoreConfig, ApiConfiguration_NoApiConfig, GraphQLConfig_FragmentsFilePath, GraphQLConfig_MutationsFilePath, GraphQLConfig_QueriesFilePath, GraphQLConfig_SubscriptionsFilePath and GraphQLConfig_TypesFilePath.
  * Amazon Auto Scaling
    * Modified cmdlet Start-ASInstanceRefresh: added parameter AlarmSpecification_Alarm.
  * Amazon Clean Rooms Service
    * Added cmdlet Get-CRSAnalysisTemplate leveraging the GetAnalysisTemplate service API.
    * Added cmdlet Get-CRSAnalysisTemplateList leveraging the ListAnalysisTemplates service API.
    * Added cmdlet Get-CRSBatchCollaborationAnalysisTemplate leveraging the BatchGetCollaborationAnalysisTemplate service API.
    * Added cmdlet Get-CRSCollaborationAnalysisTemplate leveraging the GetCollaborationAnalysisTemplate service API.
    * Added cmdlet Get-CRSCollaborationAnalysisTemplateList leveraging the ListCollaborationAnalysisTemplates service API.
    * Added cmdlet New-CRSAnalysisTemplate leveraging the CreateAnalysisTemplate service API.
    * Added cmdlet Remove-CRSAnalysisTemplate leveraging the DeleteAnalysisTemplate service API.
    * Added cmdlet Update-CRSAnalysisTemplate leveraging the UpdateAnalysisTemplate service API.
    * Modified cmdlet New-CRSConfiguredTableAnalysisRule: added parameters Custom_AllowedAnalysis and Custom_AllowedAnalysisProvider.
    * Modified cmdlet Start-CRSProtectedQuery: added parameters SqlParameters_AnalysisTemplateArn and SqlParameters_Parameter.
    * Modified cmdlet Update-CRSConfiguredTableAnalysisRule: added parameters Custom_AllowedAnalysis and Custom_AllowedAnalysisProvider.
  * Amazon EventBridge Scheduler
    * Modified cmdlet New-SCHSchedule: added parameter ActionAfterCompletion.
    * Modified cmdlet Update-SCHSchedule: added parameter ActionAfterCompletion.
  * Amazon Inspector2
    * Added cmdlet Get-INS2GetFindingDetail leveraging the BatchGetFindingDetails service API.
  * Amazon Lookout for Equipment
    * Added cmdlet Get-L4EModelVersion leveraging the DescribeModelVersion service API.
    * Added cmdlet Get-L4EModelVersionList leveraging the ListModelVersions service API.
    * Added cmdlet Get-L4EResourcePolicy leveraging the DescribeResourcePolicy service API.
    * Added cmdlet Import-L4EDataset leveraging the ImportDataset service API.
    * Added cmdlet Import-L4EModelVersion leveraging the ImportModelVersion service API.
    * Added cmdlet Remove-L4EResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Update-L4EActiveModelVersion leveraging the UpdateActiveModelVersion service API.
    * Added cmdlet Write-L4EResourcePolicy leveraging the PutResourcePolicy service API.
  * Amazon Omics
    * Modified cmdlet Get-OMICSReadSetList: added parameter Filter_CreationType.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter EnableLocalWriteForwarding.
    * Modified cmdlet New-RDSDBCluster: added parameter EnableLocalWriteForwarding.

### 4.1.382 (2023-07-28 21:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.609.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Modified cmdlet New-CFNStack: added parameter RetainExceptOnCreate.
    * Modified cmdlet Start-CFNChangeSet: added parameter RetainExceptOnCreate.
    * Modified cmdlet Undo-CFNStack: added parameter RetainExceptOnCreate.
    * Modified cmdlet Update-CFNStack: added parameter RetainExceptOnCreate.
  * Amazon CloudFront
    * Modified cmdlet Copy-CFDistribution: added parameter Enabled.
  * Amazon CloudWatch Application Insights
    * Added cmdlet Add-CWAIWorkload leveraging the AddWorkload service API.
    * Added cmdlet Get-CWAIWorkload leveraging the DescribeWorkload service API.
    * Added cmdlet Get-CWAIWorkloadList leveraging the ListWorkloads service API.
    * Added cmdlet Remove-CWAIWorkload leveraging the RemoveWorkload service API.
    * Added cmdlet Update-CWAIProblem leveraging the UpdateProblem service API.
    * Added cmdlet Update-CWAIWorkload leveraging the UpdateWorkload service API.
    * Modified cmdlet Get-CWAIApplication: added parameter AccountId.
    * Modified cmdlet Get-CWAIApplicationList: added parameter AccountId.
    * Modified cmdlet Get-CWAIComponent: added parameter AccountId.
    * Modified cmdlet Get-CWAIComponentConfiguration: added parameter AccountId.
    * Modified cmdlet Get-CWAIComponentConfigurationRecommendation: added parameter RecommendationType.
    * Modified cmdlet Get-CWAIComponentList: added parameter AccountId.
    * Modified cmdlet Get-CWAIConfigurationHistoryList: added parameter AccountId.
    * Modified cmdlet Get-CWAILogPattern: added parameter AccountId.
    * Modified cmdlet Get-CWAILogPatternList: added parameter AccountId.
    * Modified cmdlet Get-CWAILogPatternSetList: added parameter AccountId.
    * Modified cmdlet Get-CWAIObservation: added parameter AccountId.
    * Modified cmdlet Get-CWAIProblem: added parameter AccountId.
    * Modified cmdlet Get-CWAIProblemList: added parameters AccountId and Visibility.
    * Modified cmdlet Get-CWAIProblemObservation: added parameter AccountId.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Get-MSKClusterOperationsV2List leveraging the ListClusterOperationsV2 service API.
    * Added cmdlet Get-MSKClusterOperationV2 leveraging the DescribeClusterOperationV2 service API.
  * Amazon Pinpoint
    * Modified cmdlet New-PINCampaign: added parameters InAppTemplate_Name and InAppTemplate_Version.
    * Modified cmdlet New-PINJourney: added parameters Limits_TotalCap, TimeframeCap_Cap and TimeframeCap_Day.
    * Modified cmdlet Send-PINMessage: added parameters GCMMessage_PreferredAuthenticationMethod, InAppTemplate_Name and InAppTemplate_Version.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters GCMMessage_PreferredAuthenticationMethod, InAppTemplate_Name and InAppTemplate_Version.
    * Modified cmdlet Update-PINApplicationSettingList: added parameters JourneyLimits_DailyCap, JourneyLimits_TotalCap, TimeframeCap_Cap and TimeframeCap_Day.
    * Modified cmdlet Update-PINCampaign: added parameters InAppTemplate_Name and InAppTemplate_Version.
    * Modified cmdlet Update-PINGcmChannel: added parameters GCMChannelRequest_DefaultAuthenticationMethod and GCMChannelRequest_ServiceJson.
    * Modified cmdlet Update-PINJourney: added parameters Limits_TotalCap, TimeframeCap_Cap and TimeframeCap_Day.

### 4.1.381 (2023-07-28 03:29Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.608.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.380 (2023-07-27 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.608.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.379 (2023-07-26 21:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.607.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EntityResolution. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ERES and can be listed using the command 'Get-AWSCmdletName -Service ERES'.
  * Amazon Managed Blockchain Query. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MBCQ and can be listed using the command 'Get-AWSCmdletName -Service MBCQ'.

### 4.1.378 (2023-07-25 21:42Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.606.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSBillingConductor
    * Modified cmdlet Get-ABCBillingGroupList: added parameter Filters_AutoAssociate.
    * Modified cmdlet New-ABCBillingGroup: added parameter AccountGrouping_AutoAssociate.
    * Modified cmdlet Update-ABCBillingGroup: added parameter AccountGrouping_AutoAssociate.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFRuleBasedMatchList leveraging the ListRuleBasedMatches service API.
    * Added cmdlet Get-CPFSimilarProfile leveraging the GetSimilarProfiles service API.
    * Modified cmdlet New-CPFDomain: added parameters AttributeTypesSelector_Address, AttributeTypesSelector_AttributeMatchingModel, AttributeTypesSelector_EmailAddress, AttributeTypesSelector_PhoneNumber, RuleBasedMatching_ConflictResolution_ConflictResolvingModel, RuleBasedMatching_ConflictResolution_SourceName, RuleBasedMatching_Enabled, RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName, RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName, RuleBasedMatching_MatchingRule, RuleBasedMatching_MaxAllowedRuleLevelForMatching and RuleBasedMatching_MaxAllowedRuleLevelForMerging.
    * Modified cmdlet Update-CPFDomain: added parameters AttributeTypesSelector_Address, AttributeTypesSelector_AttributeMatchingModel, AttributeTypesSelector_EmailAddress, AttributeTypesSelector_PhoneNumber, RuleBasedMatching_ConflictResolution_ConflictResolvingModel, RuleBasedMatching_ConflictResolution_SourceName, RuleBasedMatching_Enabled, RuleBasedMatching_ExportingConfig_S3Exporting_S3BucketName, RuleBasedMatching_ExportingConfig_S3Exporting_S3KeyName, RuleBasedMatching_MatchingRule, RuleBasedMatching_MaxAllowedRuleLevelForMatching and RuleBasedMatching_MaxAllowedRuleLevelForMerging.
  * Amazon DataSync
    * Added cmdlet Get-DSYNLocationAzureBlob leveraging the DescribeLocationAzureBlob service API.
    * Added cmdlet New-DSYNLocationAzureBlob leveraging the CreateLocationAzureBlob service API.
    * Added cmdlet Update-DSYNLocationAzureBlob leveraging the UpdateLocationAzureBlob service API.
  * Amazon EMR Serverless
    * Modified cmdlet Start-EMRServerlessJobRun: added parameters CloudWatchLoggingConfiguration_Enabled, CloudWatchLoggingConfiguration_EncryptionKeyArn, CloudWatchLoggingConfiguration_LogGroupName, CloudWatchLoggingConfiguration_LogStreamNamePrefix and CloudWatchLoggingConfiguration_LogType.
  * Amazon Security Token Service
    * Modified cmdlet Use-STSRole: added parameter ProvidedContext.
  * Amazon Transfer for SFTP
    * Added cmdlet Test-TFRConnection leveraging the TestConnection service API.
    * Modified cmdlet New-TFRConnector: added parameters SftpConfig_TrustedHostKey and SftpConfig_UserSecretId.
    * Modified cmdlet Start-TFRFileTransfer: added parameters LocalDirectoryPath, RemoteDirectoryPath and RetrieveFilePath.
    * Modified cmdlet Update-TFRConnector: added parameters SftpConfig_TrustedHostKey and SftpConfig_UserSecretId.

### 4.1.377 (2023-07-24 21:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.605.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Media Pipelines
    * Modified cmdlet New-CHMMPMediaCapturePipeline: added parameters ActiveSpeakerOnlyConfiguration_ActiveSpeakerPosition, GridViewConfiguration_CanvasOrientation, HorizontalLayoutConfiguration_TileAspectRatio, HorizontalLayoutConfiguration_TileCount, HorizontalLayoutConfiguration_TileOrder, HorizontalLayoutConfiguration_TilePosition, VerticalLayoutConfiguration_TileAspectRatio, VerticalLayoutConfiguration_TileCount, VerticalLayoutConfiguration_TileOrder, VerticalLayoutConfiguration_TilePosition, VideoAttribute_BorderColor, VideoAttribute_BorderThickness, VideoAttribute_CornerRadius and VideoAttribute_HighlightColor.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNStackInstanceResourceDrift leveraging the ListStackInstanceResourceDrifts service API.
  * Amazon Cost Explorer
    * Added cmdlet Get-CESavingsPlanPurchaseRecommendationDetail leveraging the GetSavingsPlanPurchaseRecommendationDetails service API.
  * Amazon QuickSight
    * Added cmdlet Get-QSDashboardSnapshotJob leveraging the DescribeDashboardSnapshotJob service API.
    * Added cmdlet Get-QSDashboardSnapshotJobResult leveraging the DescribeDashboardSnapshotJobResult service API.
    * Added cmdlet Start-QSDashboardSnapshotJob leveraging the StartDashboardSnapshotJob service API.

### 4.1.376 (2023-07-21 21:41Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.604.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstance: added parameter DBSystemId.

### 4.1.375 (2023-07-20 21:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.603.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeCatalyst
    * Added cmdlet Get-CCATSourceRepository leveraging the GetSourceRepository service API.
    * Added cmdlet New-CCATSourceRepository leveraging the CreateSourceRepository service API.
    * Added cmdlet Remove-CCATProject leveraging the DeleteProject service API.
    * Added cmdlet Remove-CCATSourceRepository leveraging the DeleteSourceRepository service API.
    * Added cmdlet Remove-CCATSpace leveraging the DeleteSpace service API.
    * Added cmdlet Update-CCATProject leveraging the UpdateProject service API.
    * Added cmdlet Update-CCATSpace leveraging the UpdateSpace service API.
  * Amazon Route 53 Resolver
    * Added cmdlet Get-R53ROutpostResolver leveraging the GetOutpostResolver service API.
    * Added cmdlet Get-R53ROutpostResolverList leveraging the ListOutpostResolvers service API.
    * Added cmdlet New-R53ROutpostResolver leveraging the CreateOutpostResolver service API.
    * Added cmdlet Remove-R53ROutpostResolver leveraging the DeleteOutpostResolver service API.
    * Added cmdlet Update-R53ROutpostResolver leveraging the UpdateOutpostResolver service API.
    * Modified cmdlet New-R53RResolverEndpoint: added parameters OutpostArn and PreferredInstanceType.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMResourceCatalogList leveraging the ListResourceCatalogs service API.
    * Modified cmdlet Search-SMResource: added parameter CrossAccountFilterOption.
  * Amazon Security Lake
    * Added cmdlet Add-SLKResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SLKResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SLKResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-SLKDataLake: added parameter Tag.
    * Modified cmdlet New-SLKSubscriber: added parameter Tag.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSTranscriptionJob: added parameter ToxicityDetection.

### 4.1.374 (2023-07-20 06:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.602.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.373 (2023-07-19 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.602.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Modified cmdlet Get-CFNTemplateSummary: added parameter TemplateSummaryConfig_TreatUnrecognizedResourceTypesAsWarning.
  * Amazon Managed Grafana
    * Added cmdlet Get-MGRFVersionList leveraging the ListVersions service API.
    * Modified cmdlet Update-MGRFWorkspaceConfiguration: added parameter GrafanaVersion.
  * Amazon Medical Imaging Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MIS and can be listed using the command 'Get-AWSCmdletName -Service MIS'.
  * Amazon Resource Access Manager (RAM)
    * Modified cmdlet Connect-RAMResourceShare: added parameter Source.
    * Modified cmdlet Disconnect-RAMResourceShare: added parameter Source.
    * Modified cmdlet New-RAMResourceShare: added parameter Source.
  * Amazon Systems Manager for SAP
    * Added cmdlet Start-SMSAPApplicationRefresh leveraging the StartApplicationRefresh service API.
    * Modified cmdlet Update-SMSAPApplicationSetting: added parameters Backint_BackintMode and Backint_EnsureNoBackupInProcess.

### 4.1.372 (2023-07-18 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.601.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWPickupLocation leveraging the ListPickupLocations service API.
    * Modified cmdlet New-SNOWAddress: added parameter Address_Type.
    * Modified cmdlet New-SNOWCluster: added parameter Notification_DevicePickupSnsTopicARN.
    * Modified cmdlet New-SNOWJob: added parameters ImpactLevel, Notification_DevicePickupSnsTopicARN, PickupDetails_DevicePickupId, PickupDetails_Email, PickupDetails_IdentificationExpirationDate, PickupDetails_IdentificationIssuingOrg, PickupDetails_IdentificationNumber, PickupDetails_Name and PickupDetails_PhoneNumber.
    * Modified cmdlet Update-SNOWCluster: added parameter Notification_DevicePickupSnsTopicARN.
    * Modified cmdlet Update-SNOWJob: added parameters Notification_DevicePickupSnsTopicARN, PickupDetails_DevicePickupId, PickupDetails_Email, PickupDetails_IdentificationExpirationDate, PickupDetails_IdentificationIssuingOrg, PickupDetails_IdentificationNumber, PickupDetails_Name and PickupDetails_PhoneNumber.
  * Amazon Lex Model Building V2
    * Added cmdlet Get-LMBV2IntentMetricList leveraging the ListIntentMetrics service API.
    * Added cmdlet Get-LMBV2IntentPathList leveraging the ListIntentPaths service API.
    * Added cmdlet Get-LMBV2IntentStageMetricList leveraging the ListIntentStageMetrics service API.
    * Added cmdlet Get-LMBV2SessionAnalyticsDataList leveraging the ListSessionAnalyticsData service API.
    * Added cmdlet Get-LMBV2SessionMetricList leveraging the ListSessionMetrics service API.
    * Added cmdlet Get-LMBV2UtteranceAnalyticsDataList leveraging the ListUtteranceAnalyticsData service API.
    * Added cmdlet Get-LMBV2UtteranceMetricList leveraging the ListUtteranceMetrics service API.
  * Amazon M2
    * Added cmdlet Get-AMMSignedBluinsightsUrl leveraging the GetSignedBluinsightsUrl service API.

### 4.1.371 (2023-07-17 21:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.589.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet Edit-DOCDBCluster: added parameter AllowMajorVersionUpgrade.
  * Amazon Interactive Video Service
    * Modified cmdlet New-IVSRecordingConfiguration: added parameters RenditionConfiguration_Rendition, RenditionConfiguration_RenditionSelection, ThumbnailConfiguration_Resolution and ThumbnailConfiguration_Storage.
  * Amazon Lake Formation
    * Modified cmdlet Write-LKFDataLakeSetting: added parameters DataLakeSettings_AllowFullTableExternalDataAccess and DataLakeSettings_ReadOnlyAdmin.

### 4.1.370 (2023-07-13 21:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.588.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Remove-CONNQueue leveraging the DeleteQueue service API.
    * Added cmdlet Remove-CONNRoutingProfile leveraging the DeleteRoutingProfile service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters PostgreSQLSettings_BabelfishDatabaseName and PostgreSQLSettings_DatabaseMode.
    * Modified cmdlet New-DMSEndpoint: added parameters PostgreSQLSettings_BabelfishDatabaseName and PostgreSQLSettings_DatabaseMode.
  * Amazon FSx
    * Modified cmdlet New-FSXVolume: added parameters AutocommitPeriod_Type, AutocommitPeriod_Value, DefaultRetention_Type, DefaultRetention_Value, MaximumRetention_Type, MaximumRetention_Value, MinimumRetention_Type, MinimumRetention_Value, SnaplockConfiguration_AuditLogVolume, SnaplockConfiguration_PrivilegedDelete, SnaplockConfiguration_SnaplockType and SnaplockConfiguration_VolumeAppendModeEnabled.
    * Modified cmdlet New-FSXVolumeFromBackup: added parameters AutocommitPeriod_Type, AutocommitPeriod_Value, DefaultRetention_Type, DefaultRetention_Value, MaximumRetention_Type, MaximumRetention_Value, MinimumRetention_Type, MinimumRetention_Value, SnaplockConfiguration_AuditLogVolume, SnaplockConfiguration_PrivilegedDelete, SnaplockConfiguration_SnaplockType and SnaplockConfiguration_VolumeAppendModeEnabled.
    * Modified cmdlet Remove-FSXVolume: added parameter OntapConfiguration_BypassSnaplockEnterpriseRetention.
    * Modified cmdlet Update-FSXVolume: added parameters AutocommitPeriod_Type, AutocommitPeriod_Value, DefaultRetention_Type, DefaultRetention_Value, MaximumRetention_Type, MaximumRetention_Value, MinimumRetention_Type, MinimumRetention_Value, SnaplockConfiguration_AuditLogVolume, SnaplockConfiguration_PrivilegedDelete and SnaplockConfiguration_VolumeAppendModeEnabled.
  * Amazon Personalize
    * Added cmdlet Update-PERSDataset leveraging the UpdateDataset service API.
  * Amazon Proton
    * Added cmdlet Get-PRODeployment leveraging the GetDeployment service API.
    * Added cmdlet Get-PRODeploymentList leveraging the ListDeployments service API.
    * Added cmdlet Remove-PRODeployment leveraging the DeleteDeployment service API.
    * Modified cmdlet Get-PROComponentOutputList: added parameter DeploymentId.
    * Modified cmdlet Get-PROEnvironmentOutputList: added parameter DeploymentId.
    * Modified cmdlet Get-PROServiceInstanceOutputList: added parameter DeploymentId.
    * Modified cmdlet Get-PROServicePipelineOutputList: added parameter DeploymentId.

### 4.1.369 (2023-07-11 07:30Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.587.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.368 (2023-07-07 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.586.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Modified cmdlet Register-CWLKmsKey: added parameter ResourceIdentifier.
    * Modified cmdlet Unregister-CWLKmsKey: added parameter ResourceIdentifier.
  * Amazon Database Migration Service
    * Added cmdlet Edit-DMSReplicationConfig leveraging the ModifyReplicationConfig service API.
    * Added cmdlet Get-DMSReplication leveraging the DescribeReplications service API.
    * Added cmdlet Get-DMSReplicationConfig leveraging the DescribeReplicationConfigs service API.
    * Added cmdlet Get-DMSReplicationTableStatistic leveraging the DescribeReplicationTableStatistics service API.
    * Added cmdlet New-DMSReplicationConfig leveraging the CreateReplicationConfig service API.
    * Added cmdlet Remove-DMSReplicationConfig leveraging the DeleteReplicationConfig service API.
    * Added cmdlet Restore-DMSReplicationTable leveraging the ReloadReplicationTables service API.
    * Added cmdlet Start-DMSReplication leveraging the StartReplication service API.
    * Added cmdlet Stop-DMSReplication leveraging the StopReplication service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameters DocDbSettings_ReplicateShardCollection, DocDbSettings_UseUpdateLookUp, KafkaSettings_SslEndpointIdentificationAlgorithm, MongoDbSettings_ReplicateShardCollection, MongoDbSettings_UseUpdateLookUp, OracleSettings_OpenTransactionWindow, PostgreSQLSettings_MapJsonbAsClob, PostgreSQLSettings_MapLongVarcharAs, TimestreamSettings_CdcInsertsAndUpdate, TimestreamSettings_DatabaseName, TimestreamSettings_EnableMagneticStoreWrite, TimestreamSettings_MagneticDuration and TimestreamSettings_MemoryDuration.
    * Modified cmdlet New-DMSEndpoint: added parameters DocDbSettings_ReplicateShardCollection, DocDbSettings_UseUpdateLookUp, KafkaSettings_SslEndpointIdentificationAlgorithm, MongoDbSettings_ReplicateShardCollection, MongoDbSettings_UseUpdateLookUp, OracleSettings_OpenTransactionWindow, PostgreSQLSettings_MapJsonbAsClob, PostgreSQLSettings_MapLongVarcharAs, TimestreamSettings_CdcInsertsAndUpdate, TimestreamSettings_DatabaseName, TimestreamSettings_EnableMagneticStoreWrite, TimestreamSettings_MagneticDuration and TimestreamSettings_MemoryDuration.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLAccountConfiguration leveraging the DescribeAccountConfiguration service API.
    * Added cmdlet Get-EMLThumbnail leveraging the DescribeThumbnails service API.
    * Added cmdlet Update-EMLAccountConfiguration leveraging the UpdateAccountConfiguration service API.
  * Amazon Glue
    * Modified cmdlet New-GLUETable: added parameters IcebergInput_MetadataOperation and IcebergInput_Version.

### 4.1.367 (2023-07-06 21:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.584.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Location Service
    * Modified cmdlet Edit-LOCTracker: added parameter EventBridgeEnabled.
    * Modified cmdlet Get-LOCPlace: added parameter Key.
    * Modified cmdlet Get-LOCRoute: added parameter Key.
    * Modified cmdlet Get-LOCRouteMatrix: added parameter Key.
    * Modified cmdlet New-LOCTracker: added parameter EventBridgeEnabled.
    * Modified cmdlet Search-LOCPlaceIndexForPosition: added parameter Key.
    * Modified cmdlet Search-LOCPlaceIndexForSuggestion: added parameter Key.
    * Modified cmdlet Search-LOCPlaceIndexForText: added parameter Key.

### 4.1.366 (2023-07-05 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.583.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Migration Service
    * Added cmdlet Get-MGNManagedAccountList leveraging the ListManagedAccounts service API.
    * Added cmdlet Resume-MGNReplication leveraging the ResumeReplication service API.
    * Added cmdlet Stop-MGNReplication leveraging the StopReplication service API.
    * Added cmdlet Suspend-MGNReplication leveraging the PauseReplication service API.
    * Modified cmdlet Add-MGNApplicationsToWave: added parameter AccountID.
    * Modified cmdlet Add-MGNSourceServersToApplication: added parameter AccountID.
    * Modified cmdlet Complete-MGNCutover: added parameter AccountID.
    * Modified cmdlet Disconnect-MGNFromService: added parameter AccountID.
    * Modified cmdlet Get-MGNApplicationList: added parameter AccountID.
    * Modified cmdlet Get-MGNJob: added parameter AccountID.
    * Modified cmdlet Get-MGNJobLogItem: added parameter AccountID.
    * Modified cmdlet Get-MGNLaunchConfiguration: added parameter AccountID.
    * Modified cmdlet Get-MGNReplicationConfiguration: added parameter AccountID.
    * Modified cmdlet Get-MGNSourceServer: added parameter AccountID.
    * Modified cmdlet Get-MGNSourceServerActionList: added parameter AccountID.
    * Modified cmdlet Get-MGNWaveList: added parameter AccountID.
    * Modified cmdlet New-MGNApplication: added parameter AccountID.
    * Modified cmdlet New-MGNReplicationConfigurationTemplate: added parameter UseFipsEndpoint.
    * Modified cmdlet New-MGNWave: added parameter AccountID.
    * Modified cmdlet Remove-MGNApplication: added parameter AccountID.
    * Modified cmdlet Remove-MGNApplicationsFromWave: added parameter AccountID.
    * Modified cmdlet Remove-MGNJob: added parameter AccountID.
    * Modified cmdlet Remove-MGNSourceServer: added parameter AccountID.
    * Modified cmdlet Remove-MGNSourceServerAction: added parameter AccountID.
    * Modified cmdlet Remove-MGNSourceServersFromApplication: added parameter AccountID.
    * Modified cmdlet Remove-MGNTargetInstance: added parameters AccountID and PassThru.
    * Modified cmdlet Remove-MGNWave: added parameter AccountID.
    * Modified cmdlet Resume-MGNDataReplication: added parameter AccountID.
    * Modified cmdlet Set-MGNApplicationAsArchived: added parameter AccountID.
    * Modified cmdlet Set-MGNApplicationAsUnarchived: added parameter AccountID.
    * Modified cmdlet Set-MGNAsArchived: added parameter AccountID.
    * Modified cmdlet Set-MGNServerLifeCycleState: added parameter AccountID.
    * Modified cmdlet Set-MGNWaveAsArchived: added parameter AccountID.
    * Modified cmdlet Set-MGNWaveAsUnarchived: added parameter AccountID.
    * Modified cmdlet Start-MGNCutover: added parameters AccountID and PassThru.
    * Modified cmdlet Start-MGNReplication: added parameter AccountID.
    * Modified cmdlet Start-MGNTest: added parameters AccountID and PassThru.
    * Modified cmdlet Update-MGNApplication: added parameter AccountID.
    * Modified cmdlet Update-MGNLaunchConfiguration: added parameter AccountID.
    * Modified cmdlet Update-MGNReplicationConfiguration: added parameters AccountID and UseFipsEndpoint.
    * Modified cmdlet Update-MGNReplicationConfigurationTemplate: added parameter UseFipsEndpoint.
    * Modified cmdlet Update-MGNSourceServerReplicationType: added parameter AccountID.
    * Modified cmdlet Update-MGNWave: added parameter AccountID.
    * Modified cmdlet Write-MGNSourceServerAction: added parameter AccountID.
  * Amazon Key Management Service
    * Modified cmdlet Disable-KMSGrant: added parameter DryRun.
    * Modified cmdlet Invoke-KMSDecrypt: added parameter DryRun.
    * Modified cmdlet Invoke-KMSEncrypt: added parameter DryRun.
    * Modified cmdlet Invoke-KMSReEncrypt: added parameter DryRun.
    * Modified cmdlet Invoke-KMSSigning: added parameter DryRun.
    * Modified cmdlet New-KMSDataKey: added parameter DryRun.
    * Modified cmdlet New-KMSDataKeyPair: added parameter DryRun.
    * Modified cmdlet New-KMSDataKeyPairWithoutPlaintext: added parameter DryRun.
    * Modified cmdlet New-KMSDataKeyWithoutPlaintext: added parameter DryRun.
    * Modified cmdlet New-KMSGrant: added parameter DryRun.
    * Modified cmdlet New-KMSMac: added parameter DryRun.
    * Modified cmdlet Revoke-KMSGrant: added parameter DryRun.
    * Modified cmdlet Test-KMSMac: added parameter DryRun.
    * Modified cmdlet Test-KMSSignature: added parameter DryRun.

### 4.1.365 (2023-07-03 21:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.582.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameters RuntimePlatform_CpuArchitecture and RuntimePlatform_OperatingSystemFamily.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceRecommendationsJob: added parameter ContainerConfig_SupportedEndpointType.

### 4.1.364 (2023-06-30 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.581.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMEndpoint: added parameters MaximumBatchSize_Type, MaximumBatchSize_Value, RollbackMaximumBatchSize_Type, RollbackMaximumBatchSize_Value, RollingUpdatePolicy_MaximumExecutionTimeoutInSecond and RollingUpdatePolicy_WaitIntervalInSecond.
    * Modified cmdlet Update-SMEndpoint: added parameters MaximumBatchSize_Type, MaximumBatchSize_Value, RollbackMaximumBatchSize_Type, RollbackMaximumBatchSize_Value, RollingUpdatePolicy_MaximumExecutionTimeoutInSecond and RollingUpdatePolicy_WaitIntervalInSecond.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRConnector: added parameter As2Config_BasicAuthSecretId.
    * Modified cmdlet Update-TFRConnector: added parameter As2Config_BasicAuthSecretId.

### 4.1.363 (2023-06-29 22:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.580.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppStream
    * Added cmdlet Add-APSAppBlockBuilderAppBlock leveraging the AssociateAppBlockBuilderAppBlock service API.
    * Added cmdlet Get-APSAppBlockBuilder leveraging the DescribeAppBlockBuilders service API.
    * Added cmdlet Get-APSAppBlockBuilderAppBlockAssociation leveraging the DescribeAppBlockBuilderAppBlockAssociations service API.
    * Added cmdlet New-APSAppBlockBuilder leveraging the CreateAppBlockBuilder service API.
    * Added cmdlet New-APSAppBlockBuilderStreamingURL leveraging the CreateAppBlockBuilderStreamingURL service API.
    * Added cmdlet Remove-APSAppBlockBuilder leveraging the DeleteAppBlockBuilder service API.
    * Added cmdlet Remove-APSAppBlockBuilderAppBlock leveraging the DisassociateAppBlockBuilderAppBlock service API.
    * Added cmdlet Start-APSAppBlockBuilder leveraging the StartAppBlockBuilder service API.
    * Added cmdlet Stop-APSAppBlockBuilder leveraging the StopAppBlockBuilder service API.
    * Added cmdlet Update-APSAppBlockBuilder leveraging the UpdateAppBlockBuilder service API.
    * Modified cmdlet New-APSAppBlock: added parameters PackagingType, PostSetupScriptDetails_ExecutableParameter, PostSetupScriptDetails_ExecutablePath, PostSetupScriptDetails_ScriptS3Location_S3Bucket, PostSetupScriptDetails_ScriptS3Location_S3Key and PostSetupScriptDetails_TimeoutInSecond.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSConfiguredTableAnalysisRule: added parameters Aggregation_AllowedJoinOperator and List_AllowedJoinOperator.
    * Modified cmdlet Update-CRSConfiguredTableAnalysisRule: added parameters Aggregation_AllowedJoinOperator and List_AllowedJoinOperator.
  * Amazon DynamoDB
    * Modified cmdlet Invoke-DDBDDBExecuteStatement: added parameter ReturnValuesOnConditionCheckFailure.
    * Modified cmdlet Remove-DDBItem: added parameter ReturnValuesOnConditionCheckFailure.
    * Modified cmdlet Set-DDBItem: added parameter ReturnValuesOnConditionCheckFailure.
    * Modified cmdlet Update-DDBItem: added parameter ReturnValuesOnConditionCheckFailure.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAutoMLJobV2: added parameters AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxAutoMLJobRuntimeInSecond, AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxCandidate, AutoMLProblemTypeConfig_TimeSeriesForecastingJobConfig_CompletionCriteria_MaxRuntimePerTrainingJobInSecond, TimeSeriesConfig_GroupingAttributeName, TimeSeriesConfig_ItemIdentifierAttributeName, TimeSeriesConfig_TargetAttributeName, TimeSeriesConfig_TimestampAttributeName, TimeSeriesForecastingJobConfig_FeatureSpecificationS3Uri, TimeSeriesForecastingJobConfig_ForecastFrequency, TimeSeriesForecastingJobConfig_ForecastHorizon, TimeSeriesForecastingJobConfig_ForecastQuantile, Transformations_Aggregation and Transformations_Filling.

### 4.1.362 (2023-06-28 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.579.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Internet Monitor
    * Modified cmdlet New-CWIMMonitor: added parameters HealthEventsConfig_AvailabilityScoreThreshold and HealthEventsConfig_PerformanceScoreThreshold.
    * Modified cmdlet Update-CWIMMonitor: added parameters HealthEventsConfig_AvailabilityScoreThreshold and HealthEventsConfig_PerformanceScoreThreshold.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBInstance: added parameters DisableDomain, DomainAuthSecretArn, DomainDnsIp, DomainFqdn and DomainOu.
    * Modified cmdlet New-RDSDBInstance: added parameters DomainAuthSecretArn, DomainDnsIp, DomainFqdn and DomainOu.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameters DomainAuthSecretArn, DomainDnsIp, DomainFqdn and DomainOu.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameters DomainAuthSecretArn, DomainDnsIp, DomainFqdn and DomainOu.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameters DomainAuthSecretArn, DomainDnsIp, DomainFqdn and DomainOu.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3Object: added parameter OptionalObjectAttribute.
    * Modified cmdlet Get-S3ObjectV2: added parameter OptionalObjectAttribute.
    * Modified cmdlet Get-S3Version: added parameter OptionalObjectAttribute.

### 4.1.361 (2023-06-27 21:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.578.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet Update-EMRServerlessApplication: added parameter ReleaseLabel.
  * Amazon Interactive Video Service
    * Added cmdlet Start-IVSStartViewerSessionRevocation leveraging the BatchStartViewerSessionRevocation service API.
    * Added cmdlet Start-IVSViewerSessionRevocation leveraging the StartViewerSessionRevocation service API.
  * Amazon Kinesis Video Streams
    * Added cmdlet Get-KVEdgeAgentConfigurationList leveraging the ListEdgeAgentConfigurations service API.
    * Added cmdlet Remove-KVEdgeConfiguration leveraging the DeleteEdgeConfiguration service API.
  * Amazon Private 5G
    * Modified cmdlet Enable-PV5GNetworkSite: added parameters CommitmentConfiguration_AutomaticRenewal, CommitmentConfiguration_CommitmentLength and ShippingAddress_EmailAddress.
    * Modified cmdlet Start-PV5GNetworkResourceUpdate: added parameters CommitmentConfiguration_AutomaticRenewal, CommitmentConfiguration_CommitmentLength and ShippingAddress_EmailAddress.
  * Amazon SageMaker Feature Store Runtime
    * Modified cmdlet Get-SMFSRecord: added parameter ExpirationTimeResponse.
    * Modified cmdlet Get-SMFSRecordBatch: added parameters ExpirationTimeResponse and PassThru.
    * Modified cmdlet Write-SMFSRecord: added parameters TtlDuration_Unit and TtlDuration_Value.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMFeatureGroup: added parameters TtlDuration_Unit and TtlDuration_Value.
    * Modified cmdlet Update-SMFeatureGroup: added parameters TtlDuration_Unit and TtlDuration_Value.
  * Amazon Web Services AppFabric. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AFAB and can be listed using the command 'Get-AWSCmdletName -Service AFAB'.

### 4.1.360 (2023-06-26 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.577.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Search-CONNResourceTag leveraging the SearchResourceTags service API.
  * Amazon Identity and Access Management
    * Added cmdlet Get-IAMMFADeviceMetadata leveraging the GetMFADevice service API.
  * Amazon Pinpoint
    * Modified cmdlet New-PINJourney: added parameter WriteJourneyRequest_TimezoneEstimationMethod.
    * Modified cmdlet Update-PINJourney: added parameter WriteJourneyRequest_TimezoneEstimationMethod.

### 4.1.359 (2023-06-23 20:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.576.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DevOps Guru
    * Modified cmdlet Update-DGURUServiceIntegration: added parameters KMSServerSideEncryption_KMSKeyId, KMSServerSideEncryption_OptInStatus and KMSServerSideEncryption_Type.

### 4.1.358 (2023-06-22 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.575.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Identity
    * Modified cmdlet New-CHMIDAppInstanceBot: added parameters InvokedBy_StandardMessage and InvokedBy_TargetedMessage.
    * Modified cmdlet Update-CHMIDAppInstanceBot: added parameters InvokedBy_StandardMessage, InvokedBy_TargetedMessage, Lex_LexBotAliasArn, Lex_LocaleId, Lex_RespondsTo and Lex_WelcomeIntent.
  * Amazon Chime SDK Messaging
    * Modified cmdlet Send-CHMMGChannelMessage: added parameter Target.
  * Amazon Kendra
    * Added cmdlet Invoke-KNDRRetrieve leveraging the Retrieve service API.
  * Amazon Step Functions
    * Added cmdlet Get-SFNStateMachineAlias leveraging the DescribeStateMachineAlias service API.
    * Added cmdlet Get-SFNStateMachineAliasList leveraging the ListStateMachineAliases service API.
    * Added cmdlet Get-SFNStateMachineVersionList leveraging the ListStateMachineVersions service API.
    * Added cmdlet New-SFNStateMachineAlias leveraging the CreateStateMachineAlias service API.
    * Added cmdlet Publish-SFNStateMachineVersion leveraging the PublishStateMachineVersion service API.
    * Added cmdlet Remove-SFNStateMachineAlias leveraging the DeleteStateMachineAlias service API.
    * Added cmdlet Remove-SFNStateMachineVersion leveraging the DeleteStateMachineVersion service API.
    * Added cmdlet Update-SFNStateMachineAlias leveraging the UpdateStateMachineAlias service API.
    * Modified cmdlet New-SFNStateMachine: added parameters Publish and VersionDescription.
    * Modified cmdlet Update-SFNStateMachine: added parameters Publish and VersionDescription.

### 4.1.357 (2023-06-21 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.574.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMRSupportedInstanceType leveraging the ListSupportedInstanceTypes service API.
  * Amazon Inspector2
    * Added cmdlet Get-INS2BatchGetCodeSnippet leveraging the BatchGetCodeSnippet service API.
    * Added cmdlet Get-INS2EncryptionKey leveraging the GetEncryptionKey service API.
    * Added cmdlet Get-INS2SbomExport leveraging the GetSbomExport service API.
    * Added cmdlet New-INS2SbomExport leveraging the CreateSbomExport service API.
    * Added cmdlet Reset-INS2EncryptionKey leveraging the ResetEncryptionKey service API.
    * Added cmdlet Stop-INS2SbomExport leveraging the CancelSbomExport service API.
    * Added cmdlet Update-INS2EncryptionKey leveraging the UpdateEncryptionKey service API.
    * Modified cmdlet Get-INS2FindingAggregationList: added parameter TitleAggregation_FindingType.
    * Modified cmdlet Get-INS2FindingList: added parameters FilterCriteria_CodeVulnerabilityDetectorName, FilterCriteria_CodeVulnerabilityDetectorTag, FilterCriteria_CodeVulnerabilityFilePath and FilterCriteria_EpssScore.
    * Modified cmdlet New-INS2Filter: added parameters FilterCriteria_CodeVulnerabilityDetectorName, FilterCriteria_CodeVulnerabilityDetectorTag, FilterCriteria_CodeVulnerabilityFilePath and FilterCriteria_EpssScore.
    * Modified cmdlet New-INS2FindingsReport: added parameters FilterCriteria_CodeVulnerabilityDetectorName, FilterCriteria_CodeVulnerabilityDetectorTag, FilterCriteria_CodeVulnerabilityFilePath and FilterCriteria_EpssScore.
    * Modified cmdlet Update-INS2Filter: added parameters FilterCriteria_CodeVulnerabilityDetectorName, FilterCriteria_CodeVulnerabilityDetectorTag, FilterCriteria_CodeVulnerabilityFilePath and FilterCriteria_EpssScore.
    * Modified cmdlet Update-INS2OrganizationConfiguration: added parameter AutoEnable_LambdaCode.
  * Amazon MQ
    * Added cmdlet Invoke-MQPromote leveraging the Promote service API.
    * Modified cmdlet New-MQBroker: added parameters DataReplicationMode and DataReplicationPrimaryBrokerArn.
    * Modified cmdlet New-MQUser: added parameter ReplicationUser.
    * Modified cmdlet Update-MQBroker: added parameter DataReplicationMode.
    * Modified cmdlet Update-MQUser: added parameter ReplicationUser.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter StructuredLogDestination.
    * Modified cmdlet Update-TFRServer: added parameter StructuredLogDestination.

### 4.1.356 (2023-06-20 22:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.572.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Appflow
    * Added cmdlet Reset-AFConnectorMetadataCache leveraging the ResetConnectorMetadataCache service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2Host: added parameter AssetId.
  * Amazon Redshift
    * Added cmdlet Edit-RSCustomDomainAssociation leveraging the ModifyCustomDomainAssociation service API.
    * Added cmdlet Get-RSCustomDomainAssociation leveraging the DescribeCustomDomainAssociations service API.
    * Added cmdlet New-RSCustomDomainAssociation leveraging the CreateCustomDomainAssociation service API.
    * Added cmdlet Remove-RSCustomDomainAssociation leveraging the DeleteCustomDomainAssociation service API.
    * Modified cmdlet Get-RSClusterCredential: added parameter CustomDomainName.
    * Modified cmdlet Get-RSClusterCredentialsWithIAM: added parameter CustomDomainName.

### 4.1.355 (2023-06-19 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.571.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Modified cmdlet New-CFNChangeSet: added parameter OnStackFailure.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2VerifiedAccessInstanceLoggingConfiguration: added parameters AccessLogs_IncludeTrustContext and AccessLogs_LogVersion.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAutoMLJobV2: added parameters CandidateGenerationConfig_AlgorithmsConfig, CompletionCriteria_MaxAutoMLJobRuntimeInSecond, CompletionCriteria_MaxCandidate, CompletionCriteria_MaxRuntimePerTrainingJobInSecond, TabularJobConfig_FeatureSpecificationS3Uri, TabularJobConfig_GenerateCandidateDefinitionsOnly, TabularJobConfig_Mode, TabularJobConfig_ProblemType, TabularJobConfig_SampleWeightAttributeName and TabularJobConfig_TargetAttributeName.

### 4.1.354 (2023-06-16 21:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.570.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Discovery Service
    * Modified cmdlet Start-ADSExportTask: added parameters CpuPerformanceMetricBasis_Name, CpuPerformanceMetricBasis_PercentageAdjust, Ec2RecommendationsPreferences_Enabled, Ec2RecommendationsPreferences_ExcludedInstanceType, Ec2RecommendationsPreferences_PreferredRegion, Ec2RecommendationsPreferences_Tenancy, RamPerformanceMetricBasis_Name, RamPerformanceMetricBasis_PercentageAdjust, ReservedInstanceOptions_OfferingClass, ReservedInstanceOptions_PurchasingOption and ReservedInstanceOptions_TermLength.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3BucketAccelerateConfiguration: added parameter RequestPayer.
    * Modified cmdlet Get-S3Version: added parameter RequestPayer.

### 4.1.353 (2023-06-15 21:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.569.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Audit Manager
    * Added cmdlet Get-AUDMEvidenceFileUploadUrl leveraging the GetEvidenceFileUploadUrl service API.
    * Modified cmdlet Edit-AUDMSetting: added parameters DefaultExportDestination_Destination and DefaultExportDestination_DestinationType.
  * Amazon Location Service
    * Modified cmdlet Search-LOCPlaceIndexForSuggestion: added parameter FilterCategory.
    * Modified cmdlet Search-LOCPlaceIndexForText: added parameter FilterCategory.
    * Modified cmdlet Set-LOCGeofence: added parameter GeofenceProperty.

### 4.1.352 (2023-06-13 23:36Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.568.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudTrail
    * Modified cmdlet Get-CTQuery: added parameter QueryAlias.
    * Modified cmdlet Start-CTQuery: added parameters QueryAlias and QueryParameter.
  * Amazon CodeGuru Security. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CGS and can be listed using the command 'Get-AWSCmdletName -Service CGS'.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2InstanceConnectEndpoint leveraging the DescribeInstanceConnectEndpoints service API.
    * Added cmdlet New-EC2InstanceConnectEndpoint leveraging the CreateInstanceConnectEndpoint service API.
    * Added cmdlet Remove-EC2InstanceConnectEndpoint leveraging the DeleteInstanceConnectEndpoint service API.
  * Amazon Elastic Disaster Recovery Service
    * Added cmdlet Export-EDRSSourceNetworkCfnTemplate leveraging the ExportSourceNetworkCfnTemplate service API.
    * Added cmdlet Get-EDRSSourceNetwork leveraging the DescribeSourceNetworks service API.
    * Added cmdlet New-EDRSSourceNetwork leveraging the CreateSourceNetwork service API.
    * Added cmdlet Register-EDRSSourceNetworkStack leveraging the AssociateSourceNetworkStack service API.
    * Added cmdlet Remove-EDRSSourceNetwork leveraging the DeleteSourceNetwork service API.
    * Added cmdlet Start-EDRSSourceNetworkRecovery leveraging the StartSourceNetworkRecovery service API.
    * Added cmdlet Start-EDRSSourceNetworkReplication leveraging the StartSourceNetworkReplication service API.
    * Added cmdlet Stop-EDRSSourceNetworkReplication leveraging the StopSourceNetworkReplication service API.
    * Modified cmdlet New-EDRSLaunchConfigurationTemplate: added parameter ExportBucketArn.
    * Modified cmdlet Update-EDRSLaunchConfigurationTemplate: added parameter ExportBucketArn.
  * Amazon Lightsail
    * Modified cmdlet Get-LSCertificate: added parameters NoAutoIteration and PageToken.
  * Amazon Security Hub
    * Added cmdlet Edit-SHUBUpdateAutomationRule leveraging the BatchUpdateAutomationRules service API.
    * Added cmdlet Get-SHUBAutomationRuleList leveraging the ListAutomationRules service API.
    * Added cmdlet Get-SHUBGetAutomationRule leveraging the BatchGetAutomationRules service API.
    * Added cmdlet New-SHUBAutomationRule leveraging the CreateAutomationRule service API.
    * Added cmdlet Remove-SHUBDeleteAutomationRule leveraging the BatchDeleteAutomationRules service API.
  * Amazon Verified Permissions. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AVP and can be listed using the command 'Get-AWSCmdletName -Service AVP'.
  * Amazon Well-Architected Tool
    * Added cmdlet Get-WATProfile leveraging the GetProfile service API.
    * Added cmdlet Get-WATProfileList leveraging the ListProfiles service API.
    * Added cmdlet Get-WATProfileNotificationList leveraging the ListProfileNotifications service API.
    * Added cmdlet Get-WATProfileShareList leveraging the ListProfileShares service API.
    * Added cmdlet Get-WATProfileTemplate leveraging the GetProfileTemplate service API.
    * Added cmdlet New-WATProfile leveraging the CreateProfile service API.
    * Added cmdlet New-WATProfileShare leveraging the CreateProfileShare service API.
    * Added cmdlet Register-WATProfile leveraging the AssociateProfiles service API.
    * Added cmdlet Remove-WATProfile leveraging the DeleteProfile service API.
    * Added cmdlet Remove-WATProfileShare leveraging the DeleteProfileShare service API.
    * Added cmdlet Unregister-WATProfile leveraging the DisassociateProfiles service API.
    * Added cmdlet Update-WATProfile leveraging the UpdateProfile service API.
    * Added cmdlet Update-WATProfileVersion leveraging the UpgradeProfileVersion service API.
    * Modified cmdlet Get-WATAnswerList: added parameter QuestionPriority.
    * Modified cmdlet Get-WATLensReviewImprovementList: added parameter QuestionPriority.
    * Modified cmdlet Get-WATShareInvitationList: added parameter ProfileNamePrefix.
    * Modified cmdlet New-WATWorkload: added parameter ProfileArn.

### 4.1.351 (2023-06-12 22:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.567.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify UI Builder
    * Added cmdlet Get-AMPUICodegenJob leveraging the GetCodegenJob service API.
    * Added cmdlet Get-AMPUICodegenJobList leveraging the ListCodegenJobs service API.
    * Added cmdlet New-AMPUICodegenJob leveraging the StartCodegenJob service API.
  * Amazon FSx
    * Modified cmdlet Update-FSXStorageVirtualMachine: added parameters ActiveDirectoryConfiguration_NetBiosName, SelfManagedActiveDirectoryConfiguration_DomainName, SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup and SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSOutboundConnection: added parameters ConnectionProperties_Endpoint and CrossClusterSearch_SkipUnavailable.
  * Amazon Rekognition
    * Added cmdlet Add-REKREKFacesToUser leveraging the AssociateFaces service API.
    * Added cmdlet Get-REKUserList leveraging the ListUsers service API.
    * Added cmdlet New-REKUser leveraging the CreateUser service API.
    * Added cmdlet Remove-REKREKFacesFromUser leveraging the DisassociateFaces service API.
    * Added cmdlet Remove-REKUser leveraging the DeleteUser service API.
    * Added cmdlet Search-REKUser leveraging the SearchUsers service API.
    * Added cmdlet Search-REKUsersByImage leveraging the SearchUsersByImage service API.
    * Modified cmdlet Get-REKFaceList: added parameters FaceId and UserId.

### 4.1.350 (2023-06-09 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.566.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet Search-CONNHoursOfOperation leveraging the SearchHoursOfOperations service API.
    * Added cmdlet Search-CONNPrompt leveraging the SearchPrompts service API.
    * Added cmdlet Search-CONNQuickConnect leveraging the SearchQuickConnects service API.

### 4.1.349 (2023-06-08 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.565.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * Modified cmdlet Start-ATHSession: added parameter EngineConfiguration_SparkProperty.
  * Amazon Payment Cryptography Control Plane. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PAYCC and can be listed using the command 'Get-AWSCmdletName -Service PAYCC'.
  * Amazon Payment Cryptography Data. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PAYCD and can be listed using the command 'Get-AWSCmdletName -Service PAYCD'.
  * Amazon Service Catalog
    * Modified cmdlet Get-SCProvisioningArtifact: added parameter IncludeProvisioningArtifactParameter.
  * Amazon Timestream Write
    * Modified cmdlet New-TSWTable: added parameter Schema_CompositePartitionKey.
    * Modified cmdlet Update-TSWTable: added parameter Schema_CompositePartitionKey.

### 4.1.348 (2023-06-07 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.564.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLAccountPolicy leveraging the DescribeAccountPolicies service API.
    * Added cmdlet Remove-CWLAccountPolicy leveraging the DeleteAccountPolicy service API.
    * Added cmdlet Write-CWLAccountPolicy leveraging the PutAccountPolicy service API.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFEventStream leveraging the GetEventStream service API.
    * Added cmdlet Get-CPFEventStreamList leveraging the ListEventStreams service API.
    * Added cmdlet New-CPFEventStream leveraging the CreateEventStream service API.
    * Added cmdlet Remove-CPFEventStream leveraging the DeleteEventStream service API.
  * Amazon EMR Containers
    * Modified cmdlet New-EMRCManagedEndpoint: added parameters ContainerLogRotationConfiguration_MaxFilesToKeep and ContainerLogRotationConfiguration_RotationSize.
    * Modified cmdlet Start-EMRCJobRun: added parameters ContainerLogRotationConfiguration_MaxFilesToKeep and ContainerLogRotationConfiguration_RotationSize.

### 4.1.347 (2023-06-06 21:17Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.563.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Inspector2
    * Modified cmdlet Get-INS2CoverageList: added parameter FilterCriteria_LastScannedAt.
    * Modified cmdlet Get-INS2CoverageStatisticList: added parameter FilterCriteria_LastScannedAt.
  * Amazon IoT
    * Added cmdlet Get-IOTPackage leveraging the GetPackage service API.
    * Added cmdlet Get-IOTPackageConfiguration leveraging the GetPackageConfiguration service API.
    * Added cmdlet Get-IOTPackageList leveraging the ListPackages service API.
    * Added cmdlet Get-IOTPackageVersion leveraging the GetPackageVersion service API.
    * Added cmdlet Get-IOTPackageVersionList leveraging the ListPackageVersions service API.
    * Added cmdlet New-IOTPackage leveraging the CreatePackage service API.
    * Added cmdlet New-IOTPackageVersion leveraging the CreatePackageVersion service API.
    * Added cmdlet Remove-IOTPackage leveraging the DeletePackage service API.
    * Added cmdlet Remove-IOTPackageVersion leveraging the DeletePackageVersion service API.
    * Added cmdlet Update-IOTPackage leveraging the UpdatePackage service API.
    * Added cmdlet Update-IOTPackageConfiguration leveraging the UpdatePackageConfiguration service API.
    * Added cmdlet Update-IOTPackageVersion leveraging the UpdatePackageVersion service API.
    * Modified cmdlet New-IOTJob: added parameter DestinationPackageVersion.
    * Modified cmdlet New-IOTJobTemplate: added parameter DestinationPackageVersion.
  * Amazon Lex Model Building V2
    * Added cmdlet Get-LMBV2TestExecution leveraging the DescribeTestExecution service API.
    * Added cmdlet Get-LMBV2TestExecutionArtifactsUrl leveraging the GetTestExecutionArtifactsUrl service API.
    * Added cmdlet Get-LMBV2TestExecutionList leveraging the ListTestExecutions service API.
    * Added cmdlet Get-LMBV2TestExecutionResultItemList leveraging the ListTestExecutionResultItems service API.
    * Added cmdlet Get-LMBV2TestSet leveraging the DescribeTestSet service API.
    * Added cmdlet Get-LMBV2TestSetDiscrepancyReport leveraging the DescribeTestSetDiscrepancyReport service API.
    * Added cmdlet Get-LMBV2TestSetGeneration leveraging the DescribeTestSetGeneration service API.
    * Added cmdlet Get-LMBV2TestSetList leveraging the ListTestSets service API.
    * Added cmdlet Get-LMBV2TestSetRecordList leveraging the ListTestSetRecords service API.
    * Added cmdlet New-LMBV2TestSetDiscrepancyReport leveraging the CreateTestSetDiscrepancyReport service API.
    * Added cmdlet Remove-LMBV2TestSet leveraging the DeleteTestSet service API.
    * Added cmdlet Start-LMBV2TestExecution leveraging the StartTestExecution service API.
    * Added cmdlet Start-LMBV2TestSetGeneration leveraging the StartTestSetGeneration service API.
    * Added cmdlet Update-LMBV2TestSet leveraging the UpdateTestSet service API.
    * Modified cmdlet New-LMBV2Export: added parameter TestSetExportSpecification_TestSetId.
    * Modified cmdlet Start-LMBV2Import: added parameters ImportInputLocation_S3BucketName, ImportInputLocation_S3Path, StorageLocation_KmsKeyArn, StorageLocation_S3BucketName, StorageLocation_S3Path, TestSetImportResourceSpecification_Description, TestSetImportResourceSpecification_Modality, TestSetImportResourceSpecification_RoleArn, TestSetImportResourceSpecification_TestSetName and TestSetImportResourceSpecification_TestSetTag.
  * Amazon Simple Queue Service (SQS)
    * Added cmdlet Get-SQSMessageMoveTask leveraging the ListMessageMoveTasks service API.
    * Added cmdlet Start-SQSMessageMoveTask leveraging the StartMessageMoveTask service API.
    * Added cmdlet Stop-SQSMessageMoveTask leveraging the CancelMessageMoveTask service API.

### 4.1.346 (2023-06-05 22:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.562.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudFormation
    * Added cmdlet Disable-CFNOrganizationsAccess leveraging the DeactivateOrganizationsAccess service API.
    * Added cmdlet Enable-CFNOrganizationsAccess leveraging the ActivateOrganizationsAccess service API.
    * Added cmdlet Get-CFNOrganizationsAccess leveraging the DescribeOrganizationsAccess service API.
  * Amazon FinSpace User Environment Management Service
    * Added cmdlet Get-FINSPKxChangeset leveraging the GetKxChangeset service API.
    * Added cmdlet Get-FINSPKxChangesetList leveraging the ListKxChangesets service API.
    * Added cmdlet Get-FINSPKxCluster leveraging the GetKxCluster service API.
    * Added cmdlet Get-FINSPKxClusterList leveraging the ListKxClusters service API.
    * Added cmdlet Get-FINSPKxClusterNodeList leveraging the ListKxClusterNodes service API.
    * Added cmdlet Get-FINSPKxConnectionString leveraging the GetKxConnectionString service API.
    * Added cmdlet Get-FINSPKxDatabase leveraging the GetKxDatabase service API.
    * Added cmdlet Get-FINSPKxDatabasisList leveraging the ListKxDatabases service API.
    * Added cmdlet Get-FINSPKxEnvironment leveraging the GetKxEnvironment service API.
    * Added cmdlet Get-FINSPKxEnvironmentList leveraging the ListKxEnvironments service API.
    * Added cmdlet Get-FINSPKxUser leveraging the GetKxUser service API.
    * Added cmdlet Get-FINSPKxUserList leveraging the ListKxUsers service API.
    * Added cmdlet New-FINSPKxChangeset leveraging the CreateKxChangeset service API.
    * Added cmdlet New-FINSPKxCluster leveraging the CreateKxCluster service API.
    * Added cmdlet New-FINSPKxDatabase leveraging the CreateKxDatabase service API.
    * Added cmdlet New-FINSPKxEnvironment leveraging the CreateKxEnvironment service API.
    * Added cmdlet New-FINSPKxUser leveraging the CreateKxUser service API.
    * Added cmdlet Remove-FINSPKxCluster leveraging the DeleteKxCluster service API.
    * Added cmdlet Remove-FINSPKxDatabase leveraging the DeleteKxDatabase service API.
    * Added cmdlet Remove-FINSPKxEnvironment leveraging the DeleteKxEnvironment service API.
    * Added cmdlet Remove-FINSPKxUser leveraging the DeleteKxUser service API.
    * Added cmdlet Update-FINSPKxClusterDatabasis leveraging the UpdateKxClusterDatabases service API.
    * Added cmdlet Update-FINSPKxDatabase leveraging the UpdateKxDatabase service API.
    * Added cmdlet Update-FINSPKxEnvironment leveraging the UpdateKxEnvironment service API.
    * Added cmdlet Update-FINSPKxEnvironmentNetwork leveraging the UpdateKxEnvironmentNetwork service API.
    * Added cmdlet Update-FINSPKxUser leveraging the UpdateKxUser service API.
  * Amazon Keyspaces
    * Modified cmdlet New-KSKeyspace: added parameters ReplicationSpecification_RegionList and ReplicationSpecification_ReplicationStrategy.

### 4.1.345 (2023-06-02 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.561.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * Added cmdlet Remove-ATHCapacityReservation leveraging the DeleteCapacityReservation service API.
  * Amazon CloudTrail
    * Added cmdlet Start-CTEventDataStoreIngestion leveraging the StartEventDataStoreIngestion service API.
    * Added cmdlet Stop-CTEventDataStoreIngestion leveraging the StopEventDataStoreIngestion service API.
    * Modified cmdlet New-CTEventDataStore: added parameter StartIngestion.
  * Amazon SageMaker Service
    * Modified cmdlet Start-SMPipelineExecution: added parameters SelectiveExecutionConfig_SelectedStep and SelectiveExecutionConfig_SourcePipelineExecutionArn.
  * Amazon WAF V2
    * Added cmdlet Get-WAF2AllManagedProduct leveraging the DescribeAllManagedProducts service API.
    * Added cmdlet Get-WAF2ManagedProductsByVendor leveraging the DescribeManagedProductsByVendor service API.

### 4.1.344 (2023-06-01 21:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.559.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBProfile: added parameter ProactiveJoin_EnabledByMotion.
    * Modified cmdlet Update-ALXBProfile: added parameter ProactiveJoin_EnabledByMotion.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameters DataTransferApi_Name and DataTransferApi_Type.
    * Modified cmdlet Update-AFFlow: added parameters DataTransferApi_Name and DataTransferApi_Type.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFCalculatedAttributeDefinition leveraging the GetCalculatedAttributeDefinition service API.
    * Added cmdlet Get-CPFCalculatedAttributeDefinitionList leveraging the ListCalculatedAttributeDefinitions service API.
    * Added cmdlet Get-CPFCalculatedAttributeForProfile leveraging the GetCalculatedAttributeForProfile service API.
    * Added cmdlet Get-CPFCalculatedAttributesForProfileList leveraging the ListCalculatedAttributesForProfile service API.
    * Added cmdlet New-CPFCalculatedAttributeDefinition leveraging the CreateCalculatedAttributeDefinition service API.
    * Added cmdlet Remove-CPFCalculatedAttributeDefinition leveraging the DeleteCalculatedAttributeDefinition service API.
    * Added cmdlet Update-CPFCalculatedAttributeDefinition leveraging the UpdateCalculatedAttributeDefinition service API.
  * Amazon Interactive Video Service
    * Modified cmdlet New-IVSChannel: added parameter Preset.
    * Modified cmdlet Update-IVSChannel: added parameter Preset.

### 4.1.343 (2023-05-31 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.558.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Config
    * Modified cmdlet Write-CFGConfigurationRecorder: added parameters ExclusionByResourceTypes_ResourceType and RecordingStrategy_UseOnly.
  * Amazon Fraud Detector
    * Modified cmdlet Write-FDEventType: added parameter EventOrchestration_EventBridgeEnabled.
  * Amazon HealthLake
    * Modified cmdlet New-AHLFHIRDatastore: added parameters IdentityProviderConfiguration_AuthorizationStrategy, IdentityProviderConfiguration_FineGrainedAuthorizationEnabled, IdentityProviderConfiguration_IdpLambdaArn and IdentityProviderConfiguration_Metadata.
  * Amazon M2
    * Modified cmdlet New-AMMApplication: added parameter RoleArn.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBInstance: added parameter Engine.
  * Amazon WorkSpaces Web
    * Added cmdlet Get-WSWIpAccessSetting leveraging the GetIpAccessSettings service API.
    * Added cmdlet Get-WSWIpAccessSettingList leveraging the ListIpAccessSettings service API.
    * Added cmdlet New-WSWIpAccessSetting leveraging the CreateIpAccessSettings service API.
    * Added cmdlet Register-WSWIpAccessSetting leveraging the AssociateIpAccessSettings service API.
    * Added cmdlet Remove-WSWIpAccessSetting leveraging the DeleteIpAccessSettings service API.
    * Added cmdlet Unregister-WSWIpAccessSetting leveraging the DisassociateIpAccessSettings service API.
    * Added cmdlet Update-WSWIpAccessSetting leveraging the UpdateIpAccessSettings service API.

### 4.1.342 (2023-05-30 21:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.557.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Voice
    * Modified cmdlet Start-CHMVOSpeakerSearchTask: added parameter CallLeg.
  * Amazon IoT FleetWise
    * Modified cmdlet New-IFWCampaign: added parameter DataDestinationConfig.
  * Amazon Location Service
    * Modified cmdlet Edit-LOCMap: added parameter ConfigurationUpdate_PoliticalView.
    * Modified cmdlet New-LOCMap: added parameter Configuration_PoliticalView.
  * Amazon Personalize
    * Modified cmdlet New-PERSRecommender: added parameter TrainingDataConfig_ExcludedDatasetColumn.
    * Modified cmdlet New-PERSSolution: added parameter TrainingDataConfig_ExcludedDatasetColumn.
    * Modified cmdlet Update-PERSRecommender: added parameter TrainingDataConfig_ExcludedDatasetColumn.
  * SLK
    * [Breaking Change] Removed cmdlets Get-SLKDatalake, Get-SLKDatalakeAutoEnable, Get-SLKDatalakeExceptionList, Get-SLKDatalakeExceptionsExpiry, Get-SLKDatalakeExceptionsSubscription, Get-SLKDatalakeStatus, New-SLKDatalake, New-SLKDatalakeAutoEnable, New-SLKDatalakeDelegatedAdmin, New-SLKDatalakeExceptionsSubscription, New-SLKSubscriptionNotificationConfiguration, Remove-SLKDatalake, Remove-SLKDatalakeAutoEnable, Remove-SLKDatalakeDelegatedAdmin, Remove-SLKDatalakeExceptionsSubscription, Remove-SLKSubscriptionNotificationConfiguration, Update-SLKDatalake, Update-SLKDatalakeExceptionsExpiry, Update-SLKDatalakeExceptionsSubscription and Update-SLKSubscriptionNotificationConfiguration.
    * Added cmdlet Get-SLKDataLakeExceptionList leveraging the ListDataLakeExceptions service API.
    * Added cmdlet Get-SLKDataLakeExceptionSubscription leveraging the GetDataLakeExceptionSubscription service API.
    * Added cmdlet Get-SLKDataLakeList leveraging the ListDataLakes service API.
    * Added cmdlet Get-SLKDataLakeOrganizationConfiguration leveraging the GetDataLakeOrganizationConfiguration service API.
    * Added cmdlet Get-SLKDataLakeSource leveraging the GetDataLakeSources service API.
    * Added cmdlet New-SLKDataLake leveraging the CreateDataLake service API.
    * Added cmdlet New-SLKDataLakeExceptionSubscription leveraging the CreateDataLakeExceptionSubscription service API.
    * Added cmdlet New-SLKDataLakeOrganizationConfiguration leveraging the CreateDataLakeOrganizationConfiguration service API.
    * Added cmdlet New-SLKSubscriberNotification leveraging the CreateSubscriberNotification service API.
    * Added cmdlet Register-SLKDataLakeDelegatedAdministrator leveraging the RegisterDataLakeDelegatedAdministrator service API.
    * Added cmdlet Remove-SLKDataLake leveraging the DeleteDataLake service API.
    * Added cmdlet Remove-SLKDataLakeDelegatedAdministrator leveraging the DeregisterDataLakeDelegatedAdministrator service API.
    * Added cmdlet Remove-SLKDataLakeExceptionSubscription leveraging the DeleteDataLakeExceptionSubscription service API.
    * Added cmdlet Remove-SLKDataLakeOrganizationConfiguration leveraging the DeleteDataLakeOrganizationConfiguration service API.
    * Added cmdlet Remove-SLKSubscriberNotification leveraging the DeleteSubscriberNotification service API.
    * Added cmdlet Update-SLKDataLake leveraging the UpdateDataLake service API.
    * Added cmdlet Update-SLKDataLakeExceptionSubscription leveraging the UpdateDataLakeExceptionSubscription service API.
    * Added cmdlet Update-SLKSubscriberNotification leveraging the UpdateSubscriberNotification service API.
    * [Breaking Change] Modified cmdlet Get-SLKLogSourceList: output changed from System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>> to Amazon.SecurityLake.Model.LogSource; removed parameters InputOrder, ListAllDimension, ListSingleDimension and ListTwoDimension; added parameters Account, Source and SourceRegions.
    * [Breaking Change] Modified cmdlet Get-SLKSubscriber: removed parameter Id; added parameter SubscriberId.
    * [Breaking Change] Modified cmdlet New-SLKAwsLogSource: removed parameters EnableAllDimension, EnableSingleDimension, EnableTwoDimension and InputOrder; added parameter Source.
    * [Breaking Change] Modified cmdlet New-SLKCustomLogSource: removed parameters CustomSourceName, GlueInvocationRoleArn and LogProviderAccountId; the type of parameter EventClass changed from Amazon.SecurityLake.OcsfEventClass to System.String[]; added parameters CrawlerConfiguration_RoleArn, ProviderIdentity_ExternalId, ProviderIdentity_Principal, SourceName and SourceVersion.
    * [Breaking Change] Modified cmdlet New-SLKSubscriber: removed parameters AccountId, ExternalId and SourceType; added parameters Source, SubscriberIdentity_ExternalId and SubscriberIdentity_Principal.
    * [Breaking Change] Modified cmdlet Remove-SLKAwsLogSource: removed parameters DisableAllDimension, DisableSingleDimension, DisableTwoDimension and InputOrder; added parameter Source.
    * [Breaking Change] Modified cmdlet Remove-SLKCustomLogSource: output changed from System.String to None; removed parameter CustomSourceName; added parameters SourceName and SourceVersion.
    * [Breaking Change] Modified cmdlet Remove-SLKSubscriber: removed parameter Id; added parameter SubscriberId.
    * [Breaking Change] Modified cmdlet Update-SLKSubscriber: removed parameters ExternalId, Id and SourceType; added parameters Source, SubscriberId, SubscriberIdentity_ExternalId and SubscriberIdentity_Principal.

### 4.1.341 (2023-05-26 21:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.556.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWNetworkAnalyzerConfiguration: added parameters MulticastGroup and TraceContent_MulticastFrameInfo.
    * Modified cmdlet Update-IOTWNetworkAnalyzerConfiguration: added parameters MulticastGroupsToAdd, MulticastGroupsToRemove and TraceContent_MulticastFrameInfo.

### 4.1.340 (2023-05-25 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.555.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GameLift Service
    * Modified cmdlet Request-GMLGameServer: added parameter FilterOption_InstanceStatus.
  * Amazon Glue
    * Modified cmdlet Get-GLUEDataQualityRulesetList: added parameter TargetTable_CatalogId.
    * Modified cmdlet New-GLUEDataQualityRuleset: added parameter TargetTable_CatalogId.
    * Modified cmdlet Start-GLUEDataQualityRulesetEvaluationRun: added parameter AdditionalDataSource.
  * Amazon Migration Hub Refactor Spaces
    * Modified cmdlet New-MHRSRoute: added parameter UriPathRoute_AppendSourcePath.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameters Autotune_Mode, HyperParameterRanges_AutoParameter and ParameterRanges_AutoParameter.

### 4.1.339 (2023-05-24 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.554.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Added cmdlet Get-ASYNSourceApiAssociation leveraging the GetSourceApiAssociation service API.
    * Added cmdlet Get-ASYNSourceApiAssociationList leveraging the ListSourceApiAssociations service API.
    * Added cmdlet Get-ASYNTypesByAssociationList leveraging the ListTypesByAssociation service API.
    * Added cmdlet Start-ASYNMergedGraphqlApi leveraging the AssociateMergedGraphqlApi service API.
    * Added cmdlet Start-ASYNSchemaMerge leveraging the StartSchemaMerge service API.
    * Added cmdlet Start-ASYNSourceGraphqlApi leveraging the AssociateSourceGraphqlApi service API.
    * Added cmdlet Stop-ASYNMergedGraphqlApi leveraging the DisassociateMergedGraphqlApi service API.
    * Added cmdlet Stop-ASYNSourceGraphqlApi leveraging the DisassociateSourceGraphqlApi service API.
    * Added cmdlet Update-ASYNSourceApiAssociation leveraging the UpdateSourceApiAssociation service API.
    * Modified cmdlet Get-ASYNGraphqlApiList: added parameters ApiType, Owner and PassThru.
    * Modified cmdlet New-ASYNGraphqlApi: added parameters ApiType, MergedApiExecutionRoleArn and OwnerContact.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameters MergedApiExecutionRoleArn and OwnerContact.

### 4.1.338 (2023-05-23 21:32Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.553.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon SageMaker Service
    * Modified cmdlet Get-SMInferenceRecommendationsJobList: added parameters ModelNameEqual and ModelPackageVersionArnEqual.
  * Amazon Translate
    * Added cmdlet ConvertTo-TRNDocument leveraging the TranslateDocument service API.

### 4.1.337 (2023-05-22 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.552.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Modified cmdlet Start-BAKRestoreJob: added parameter CopySourceTagsToRestoredResource.
  * Amazon QuickSight
    * Added cmdlet Get-QSAssetBundleExportJob leveraging the DescribeAssetBundleExportJob service API.
    * Added cmdlet Get-QSAssetBundleExportJobList leveraging the ListAssetBundleExportJobs service API.
    * Added cmdlet Get-QSAssetBundleImportJob leveraging the DescribeAssetBundleImportJob service API.
    * Added cmdlet Get-QSAssetBundleImportJobList leveraging the ListAssetBundleImportJobs service API.
    * Added cmdlet Start-QSAssetBundleExportJob leveraging the StartAssetBundleExportJob service API.
    * Added cmdlet Start-QSAssetBundleImportJob leveraging the StartAssetBundleImportJob service API.

### 4.1.336 (2023-05-19 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.551.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaPackage v2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MPV2 and can be listed using the command 'Get-AWSCmdletName -Service MPV2'.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Write-SES2DedicatedIpPoolScalingAttribute leveraging the PutDedicatedIpPoolScalingAttributes service API.

### 4.1.335 (2023-05-18 21:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.549.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * [Breaking Change] Modified cmdlet Start-ATHSession: removed parameter EngineConfiguration_SparkProperty.
  * Amazon Connect Service
    * Added cmdlet Get-CONNPrompt leveraging the DescribePrompt service API.
    * Added cmdlet Get-CONNPromptFile leveraging the GetPromptFile service API.
    * Added cmdlet New-CONNPrompt leveraging the CreatePrompt service API.
    * Added cmdlet Remove-CONNPrompt leveraging the DeletePrompt service API.
    * Added cmdlet Update-CONNPrompt leveraging the UpdatePrompt service API.
  * Amazon SageMaker Geospatial
    * [Breaking Change] Modified cmdlet Start-SMGSEarthObservationJob: removed parameters S3Data_KmsKeyId, S3Data_MetadataProvider and S3Data_S3Uri.

### 4.1.334 (2023-05-16 21:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.548.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet Get-GLUECustomEntityTypeList: added parameter Tag.
    * Modified cmdlet New-GLUECustomEntityType: added parameter Tag.

### 4.1.333 (2023-05-15 21:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.547.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * Modified cmdlet Start-ATHSession: added parameter EngineConfiguration_SparkProperty.
  * Amazon CodeCatalyst
    * Added cmdlet Get-CCATDevEnvironmentSessionList leveraging the ListDevEnvironmentSessions service API.
  * Amazon IAM Roles Anywhere
    * Added cmdlet Reset-IAMRANotificationSetting leveraging the ResetNotificationSettings service API.
    * Added cmdlet Write-IAMRANotificationSetting leveraging the PutNotificationSettings service API.
    * Modified cmdlet New-IAMRATrustAnchor: added parameter NotificationSetting.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter IdentityProviderDetails_SftpAuthenticationMethod.
    * Modified cmdlet Update-TFRServer: added parameter IdentityProviderDetails_SftpAuthenticationMethod.

### 4.1.332 (2023-05-11 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.546.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECReplicationGroup: added parameter ClusterMode.
    * Modified cmdlet New-ECReplicationGroup: added parameter ClusterMode.
  * Amazon Interactive Video Service RealTime
    * Added cmdlet Get-IVSRTParticipant leveraging the GetParticipant service API.
    * Added cmdlet Get-IVSRTParticipantEventList leveraging the ListParticipantEvents service API.
    * Added cmdlet Get-IVSRTParticipantList leveraging the ListParticipants service API.
    * Added cmdlet Get-IVSRTStageSession leveraging the GetStageSession service API.
    * Added cmdlet Get-IVSRTStageSessionList leveraging the ListStageSessions service API.
  * Amazon Omics
    * Added cmdlet Complete-OMICSMultipartReadSetUpload leveraging the CompleteMultipartReadSetUpload service API.
    * Added cmdlet Get-OMICSMultipartReadSetUploadList leveraging the ListMultipartReadSetUploads service API.
    * Added cmdlet Get-OMICSReadSetUploadPartList leveraging the ListReadSetUploadParts service API.
    * Added cmdlet New-OMICSMultipartReadSetUpload leveraging the CreateMultipartReadSetUpload service API.
    * Added cmdlet Remove-OMICSMultipartReadSetUpload leveraging the AbortMultipartReadSetUpload service API.
    * Added cmdlet Set-OMICSReadSetPart leveraging the UploadReadSetPart service API.
    * Modified cmdlet Get-OMICSReadSetList: added parameters Filter_GeneratedFrom, Filter_SampleId and Filter_SubjectId.
    * Modified cmdlet Get-OMICSRunList: added parameter Status.
    * Modified cmdlet New-OMICSRunGroup: added parameter MaxGpus.
    * Modified cmdlet New-OMICSSequenceStore: added parameter FallbackLocation.
    * Modified cmdlet New-OMICSWorkflow: added parameter Accelerator.
    * Modified cmdlet Start-OMICSAnnotationImportJob: added parameter AnnotationField.
    * Modified cmdlet Start-OMICSVariantImportJob: added parameter AnnotationField.
    * Modified cmdlet Update-OMICSRunGroup: added parameter MaxGpus.
  * Amazon Support
    * Added cmdlet Get-ASACreateCaseOption leveraging the DescribeCreateCaseOptions service API.
    * Added cmdlet Get-ASASupportedLanguage leveraging the DescribeSupportedLanguages service API.

### 4.1.331 (2023-05-10 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.545.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic MapReduce
    * Modified cmdlet Get-EMRNotebookExecutionList: added parameter ExecutionEngineId.
    * Modified cmdlet Start-EMRNotebookExecution: added parameters EnvironmentVariable, ExecutionEngine_ExecutionRoleArn, NotebookS3Location_Bucket, NotebookS3Location_Key, OutputNotebookFormat, OutputNotebookS3Location_Bucket and OutputNotebookS3Location_Key.
  * Amazon Relational Database Service
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameter StorageType.

### 4.1.330 (2023-05-09 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.544.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.329 (2023-05-08 21:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.543.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.328 (2023-05-05 22:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.542.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter AvailSuppression_FillPolicy.
  * Amazon Inspector2
    * Added cmdlet Search-INS2Vulnerability leveraging the SearchVulnerabilities service API.

### 4.1.327 (2023-05-04 23:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.540.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSDomainNode leveraging the DescribeDomainNodes service API.
  * Amazon QuickSight
    * Added cmdlet Get-QSTopic leveraging the DescribeTopic service API.
    * Added cmdlet Get-QSTopicList leveraging the ListTopics service API.
    * Added cmdlet Get-QSTopicPermission leveraging the DescribeTopicPermissions service API.
    * Added cmdlet Get-QSTopicRefresh leveraging the DescribeTopicRefresh service API.
    * Added cmdlet Get-QSTopicRefreshSchedule leveraging the DescribeTopicRefreshSchedule service API.
    * Added cmdlet Get-QSTopicRefreshScheduleList leveraging the ListTopicRefreshSchedules service API.
    * Added cmdlet Get-QSVPCConnection leveraging the DescribeVPCConnection service API.
    * Added cmdlet Get-QSVPCConnectionList leveraging the ListVPCConnections service API.
    * Added cmdlet New-QSTopic leveraging the CreateTopic service API.
    * Added cmdlet New-QSTopicRefreshSchedule leveraging the CreateTopicRefreshSchedule service API.
    * Added cmdlet New-QSVPCConnection leveraging the CreateVPCConnection service API.
    * Added cmdlet Remove-QSTopic leveraging the DeleteTopic service API.
    * Added cmdlet Remove-QSTopicRefreshSchedule leveraging the DeleteTopicRefreshSchedule service API.
    * Added cmdlet Remove-QSVPCConnection leveraging the DeleteVPCConnection service API.
    * Added cmdlet Update-QSTopic leveraging the UpdateTopic service API.
    * Added cmdlet Update-QSTopicPermission leveraging the UpdateTopicPermissions service API.
    * Added cmdlet Update-QSTopicRefreshSchedule leveraging the UpdateTopicRefreshSchedule service API.
    * Added cmdlet Update-QSVPCConnection leveraging the UpdateVPCConnection service API.
    * Modified cmdlet New-QSDataSet: added parameter DatasetParameter.
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameter ExperienceConfiguration_Dashboard_FeatureConfigurations_Bookmarks_Enabled.
    * Modified cmdlet Update-QSDataSet: added parameter DatasetParameter.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBFindingHistory leveraging the GetFindingHistory service API.

### 4.1.326 (2023-05-03 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.539.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Modified cmdlet New-ASYNGraphqlApi: added parameter Visibility.
  * Amazon Inspector2
    * Added cmdlet Get-INS2BatchMemberEc2DeepInspectionStatus leveraging the BatchGetMemberEc2DeepInspectionStatus service API.
    * Added cmdlet Get-INS2Ec2DeepInspectionConfiguration leveraging the GetEc2DeepInspectionConfiguration service API.
    * Added cmdlet Update-INS2BatchMemberEc2DeepInspectionStatus leveraging the BatchUpdateMemberEc2DeepInspectionStatus service API.
    * Added cmdlet Update-INS2Ec2DeepInspectionConfiguration leveraging the UpdateEc2DeepInspectionConfiguration service API.
    * Added cmdlet Update-INS2OrgEc2DeepInspectionConfiguration leveraging the UpdateOrgEc2DeepInspectionConfiguration service API.
  * Amazon Network Firewall
    * Modified cmdlet New-NWFWFirewallPolicy: added parameter PolicyVariables_RuleVariable.
    * Modified cmdlet Update-NWFWFirewallPolicy: added parameter PolicyVariables_RuleVariable.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSDomainHealth leveraging the DescribeDomainHealth service API.
    * Modified cmdlet Get-OSInstanceTypeDetailList: added parameters InstanceType and RetrieveAZs.
    * Modified cmdlet New-OSDomain: added parameter ClusterConfig_MultiAZWithStandbyEnabled.
    * Modified cmdlet Update-OSDomainConfig: added parameter ClusterConfig_MultiAZWithStandbyEnabled.
  * Amazon Well-Architected Tool
    * Modified cmdlet New-WATWorkload: added parameter DiscoveryConfig_WorkloadResourceDefinition.
    * Modified cmdlet Update-WATGlobalSetting: added parameter DiscoveryIntegrationStatus.
    * Modified cmdlet Update-WATWorkload: added parameter DiscoveryConfig_WorkloadResourceDefinition.

### 4.1.325 (2023-05-02 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.538.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Appflow
    * Added cmdlet Stop-AFFlowExecution leveraging the CancelFlowExecutions service API.
  * Amazon Kendra
    * Modified cmdlet Get-KNDRQuerySuggestion: added parameters AttributeSuggestionsConfig_AdditionalResponseAttribute, AttributeSuggestionsConfig_AttributeFilter, AttributeSuggestionsConfig_SuggestionAttribute, SuggestionType, UserContext_DataSourceGroup, UserContext_Group, UserContext_Token and UserContext_UserId.
    * Modified cmdlet Update-KNDRQuerySuggestionsConfig: added parameters AttributeSuggestionsConfig_AttributeSuggestionsMode and AttributeSuggestionsConfig_SuggestableConfigList.

### 4.1.324 (2023-05-01 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.537.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Key Management Service
    * Modified cmdlet Invoke-KMSDecrypt: added parameters Recipient_AttestationDocument and Recipient_KeyEncryptionAlgorithm.
    * Modified cmdlet New-KMSDataKey: added parameters Recipient_AttestationDocument and Recipient_KeyEncryptionAlgorithm.
    * Modified cmdlet New-KMSDataKeyPair: added parameters Recipient_AttestationDocument and Recipient_KeyEncryptionAlgorithm.
    * Modified cmdlet New-KMSRandom: added parameters Recipient_AttestationDocument and Recipient_KeyEncryptionAlgorithm.

### 4.1.323 (2023-04-28 23:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.536.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * Added cmdlet Get-ATHCapacityAssignmentConfiguration leveraging the GetCapacityAssignmentConfiguration service API.
    * Added cmdlet Get-ATHCapacityReservation leveraging the GetCapacityReservation service API.
    * Added cmdlet Get-ATHCapacityReservationList leveraging the ListCapacityReservations service API.
    * Added cmdlet New-ATHCapacityReservation leveraging the CreateCapacityReservation service API.
    * Added cmdlet Stop-ATHCapacityReservation leveraging the CancelCapacityReservation service API.
    * Added cmdlet Update-ATHCapacityReservation leveraging the UpdateCapacityReservation service API.
    * Added cmdlet Write-ATHCapacityAssignmentConfiguration leveraging the PutCapacityAssignmentConfiguration service API.
  * Amazon IoT
    * Modified cmdlet New-IOTDomainConfiguration: added parameter TlsConfig_SecurityPolicy.
    * Modified cmdlet Update-IOTDomainConfiguration: added parameter TlsConfig_SecurityPolicy.
  * Amazon Managed Grafana
    * Modified cmdlet New-MGRFWorkspace: added parameter GrafanaVersion.
  * Amazon Rekognition
    * Modified cmdlet Get-REKContentModeration: added parameter AggregateBy.
  * Amazon SimSpace Weaver
    * Added cmdlet New-SSWSnapshot leveraging the CreateSnapshot service API.
    * Modified cmdlet Start-SSWSimulation: added parameters SnapshotS3Location_BucketName and SnapshotS3Location_ObjectKey.
  * Amazon WAF V2
    * [Breaking Change] Modified cmdlet Get-WAF2DecryptedAPIKey: parameter Scope doesn't support pipeline ByValue anymore; parameter Scope cannot be used positionally anymore.

### 4.1.322 (2023-04-27 21:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.535.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Containers
    * Added cmdlet Get-EMRCManagedEndpointSessionCredential leveraging the GetManagedEndpointSessionCredentials service API.
  * Amazon GuardDuty
    * Added cmdlet Start-GDMalwareScan leveraging the StartMalwareScan service API.
  * Amazon IoT Core Device Advisor
    * Modified cmdlet Get-IOTDAEndpoint: added parameters AuthenticationMethod and DeviceRoleArn.
    * Modified cmdlet Start-IOTDASuiteRun: added parameter PrimaryDevice_DeviceRoleArn.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Deny-MSKClientVpcConnection leveraging the RejectClientVpcConnection service API.
    * Added cmdlet Get-MSKClientVpcConnectionList leveraging the ListClientVpcConnections service API.
    * Added cmdlet Get-MSKClusterPolicy leveraging the GetClusterPolicy service API.
    * Added cmdlet Get-MSKVpcConnection leveraging the DescribeVpcConnection service API.
    * Added cmdlet Get-MSKVpcConnectionList leveraging the ListVpcConnections service API.
    * Added cmdlet New-MSKVpcConnection leveraging the CreateVpcConnection service API.
    * Added cmdlet Remove-MSKClusterPolicy leveraging the DeleteClusterPolicy service API.
    * Added cmdlet Remove-MSKVpcConnection leveraging the DeleteVpcConnection service API.
    * Added cmdlet Write-MSKClusterPolicy leveraging the PutClusterPolicy service API.
    * Modified cmdlet Update-MSKConnectivity: added parameters Iam_Enabled, Scram_Enabled and Tls_Enabled.

### 4.1.321 (2023-04-26 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.534.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon OpenSearch Ingestion. Added cmdlets to support the service. Cmdlets for the service have the noun prefix OSIS and can be listed using the command 'Get-AWSCmdletName -Service OSIS'.

### 4.1.320 (2023-04-25 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.533.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Messaging
    * [Breaking Change] Modified cmdlet Remove-CHMMGChannel: removed parameter SubChannelId.
    * [Breaking Change] Modified cmdlet Update-CHMMGChannelReadMarker: removed parameter SubChannelId.
  * Amazon Connect Service
    * Added cmdlet Disable-CONNEvaluationForm leveraging the DeactivateEvaluationForm service API.
    * Added cmdlet Enable-CONNEvaluationForm leveraging the ActivateEvaluationForm service API.
    * Added cmdlet Get-CONNContactEvaluation leveraging the DescribeContactEvaluation service API.
    * Added cmdlet Get-CONNContactEvaluationList leveraging the ListContactEvaluations service API.
    * Added cmdlet Get-CONNEvaluationForm leveraging the DescribeEvaluationForm service API.
    * Added cmdlet Get-CONNEvaluationFormList leveraging the ListEvaluationForms service API.
    * Added cmdlet Get-CONNEvaluationFormVersionList leveraging the ListEvaluationFormVersions service API.
    * Added cmdlet New-CONNEvaluationForm leveraging the CreateEvaluationForm service API.
    * Added cmdlet Remove-CONNContactEvaluation leveraging the DeleteContactEvaluation service API.
    * Added cmdlet Remove-CONNEvaluationForm leveraging the DeleteEvaluationForm service API.
    * Added cmdlet Start-CONNContactEvaluation leveraging the StartContactEvaluation service API.
    * Added cmdlet Submit-CONNContactEvaluation leveraging the SubmitContactEvaluation service API.
    * Added cmdlet Update-CONNContactEvaluation leveraging the UpdateContactEvaluation service API.
    * Added cmdlet Update-CONNEvaluationForm leveraging the UpdateEvaluationForm service API.
  * Amazon DataSync
    * Added cmdlet Add-DSYNStorageSystem leveraging the AddStorageSystem service API.
    * Added cmdlet Get-DSYNDiscoveryJob leveraging the DescribeDiscoveryJob service API.
    * Added cmdlet Get-DSYNDiscoveryJobList leveraging the ListDiscoveryJobs service API.
    * Added cmdlet Get-DSYNStorageSystem leveraging the DescribeStorageSystem service API.
    * Added cmdlet Get-DSYNStorageSystemList leveraging the ListStorageSystems service API.
    * Added cmdlet Get-DSYNStorageSystemResource leveraging the DescribeStorageSystemResources service API.
    * Added cmdlet Get-DSYNStorageSystemResourceMetric leveraging the DescribeStorageSystemResourceMetrics service API.
    * Added cmdlet New-DSYNRecommendation leveraging the GenerateRecommendations service API.
    * Added cmdlet Remove-DSYNStorageSystem leveraging the RemoveStorageSystem service API.
    * Added cmdlet Start-DSYNDiscoveryJob leveraging the StartDiscoveryJob service API.
    * Added cmdlet Stop-DSYNDiscoveryJob leveraging the StopDiscoveryJob service API.
    * Added cmdlet Update-DSYNDiscoveryJob leveraging the UpdateDiscoveryJob service API.
    * Added cmdlet Update-DSYNStorageSystem leveraging the UpdateStorageSystem service API.
  * Amazon Pinpoint
    * Added cmdlet Get-PINJourneyRun leveraging the GetJourneyRuns service API.
    * Added cmdlet Get-PINJourneyRunExecutionActivityMetric leveraging the GetJourneyRunExecutionActivityMetrics service API.
    * Added cmdlet Get-PINJourneyRunExecutionMetric leveraging the GetJourneyRunExecutionMetrics service API.

### 4.1.319 (2023-04-25 08:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.532.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2VerifiedAccessTrustProvider: added parameters OidcOptions_AuthorizationEndpoint, OidcOptions_ClientId, OidcOptions_ClientSecret, OidcOptions_Issuer, OidcOptions_TokenEndpoint and OidcOptions_UserInfoEndpoint.

### 4.1.318 (2023-04-21 21:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.531.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Service
    * Added cmdlet New-CONNParticipant leveraging the CreateParticipant service API.
  * Amazon Firewall Management Service
    * Added cmdlet Get-FMSAdminAccountsForOrganizationList leveraging the ListAdminAccountsForOrganization service API.
    * Added cmdlet Get-FMSAdminScope leveraging the GetAdminScope service API.
    * Added cmdlet Get-FMSAdminsManagingAccountList leveraging the ListAdminsManagingAccount service API.
    * Added cmdlet Write-FMSAdminAccount leveraging the PutAdminAccount service API.
    * Modified cmdlet Write-FMSResourceSet: added parameter ResourceSet_ResourceSetStatus.

### 4.1.317 (2023-04-21 02:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.530.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime
    * Modified cmdlet Start-CHMMeetingTranscription: added parameters EngineTranscribeSettings_IdentifyLanguage, EngineTranscribeSettings_LanguageOption, EngineTranscribeSettings_PreferredLanguage, TranscriptionConfiguration_EngineTranscribeSettings_VocabularyFilterNames and TranscriptionConfiguration_EngineTranscribeSettings_VocabularyNames.
  * Amazon Chime SDK Meetings
    * Modified cmdlet Start-CHMTGMeetingTranscription: added parameters TranscriptionConfiguration_EngineTranscribeSettings_VocabularyFilterNames and TranscriptionConfiguration_EngineTranscribeSettings_VocabularyNames.
  * Amazon Import/Export Snowball
    * Modified cmdlet New-SNOWCluster: added parameters ForceCreateJob, InitialClusterSize, LongTermPricingId, S3OnDeviceService_FaultTolerance, S3OnDeviceService_ServiceSize, S3OnDeviceService_StorageLimit, S3OnDeviceService_StorageUnit and SnowballCapacityPreference.
    * Modified cmdlet New-SNOWJob: added parameters S3OnDeviceService_FaultTolerance, S3OnDeviceService_ServiceSize, S3OnDeviceService_StorageLimit and S3OnDeviceService_StorageUnit.
    * Modified cmdlet Update-SNOWCluster: added parameters S3OnDeviceService_FaultTolerance, S3OnDeviceService_ServiceSize, S3OnDeviceService_StorageLimit and S3OnDeviceService_StorageUnit.
    * Modified cmdlet Update-SNOWJob: added parameters S3OnDeviceService_FaultTolerance, S3OnDeviceService_ServiceSize, S3OnDeviceService_StorageLimit and S3OnDeviceService_StorageUnit.
  * Amazon WAF V2
    * Added cmdlet Get-WAF2APIKeyList leveraging the ListAPIKeys service API.
    * Added cmdlet Get-WAF2DecryptedAPIKey leveraging the GetDecryptedAPIKey service API.
    * Added cmdlet New-WAF2APIKey leveraging the CreateAPIKey service API.

### 4.1.316 (2023-04-19 21:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.529.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Comprehend
    * Modified cmdlet New-COMPDocumentClassifier: added parameters DocumentReaderConfig_DocumentReadAction, DocumentReaderConfig_DocumentReadMode, DocumentReaderConfig_FeatureType, Documents_S3Uri, Documents_TestS3Uri and InputDataConfig_DocumentType.
  * Amazon Resource Access Manager (RAM)
    * Added cmdlet Convert-RAMPermissionCreatedFromPolicy leveraging the PromotePermissionCreatedFromPolicy service API.
    * Added cmdlet Edit-RAMPermissionAssociation leveraging the ReplacePermissionAssociations service API.
    * Added cmdlet Get-RAMPermissionAssociationList leveraging the ListPermissionAssociations service API.
    * Added cmdlet Get-RAMReplacePermissionAssociationsWorkList leveraging the ListReplacePermissionAssociationsWork service API.
    * Added cmdlet New-RAMPermission leveraging the CreatePermission service API.
    * Added cmdlet New-RAMPermissionVersion leveraging the CreatePermissionVersion service API.
    * Added cmdlet Remove-RAMPermission leveraging the DeletePermission service API.
    * Added cmdlet Remove-RAMPermissionVersion leveraging the DeletePermissionVersion service API.
    * Added cmdlet Set-RAMDefaultPermissionVersion leveraging the SetDefaultPermissionVersion service API.
    * Modified cmdlet Add-RAMResourceTag: added parameter ResourceArn.
    * Modified cmdlet Get-RAMPermissionList: added parameter PermissionType.
    * Modified cmdlet Get-RAMResourceShare: added parameter PermissionVersion.
    * Modified cmdlet Remove-RAMResourceTag: added parameter ResourceArn.

### 4.1.315 (2023-04-17 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.528.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Appflow
    * Modified cmdlet New-AFConnectorProfile: added parameter ClientToken.
    * Modified cmdlet New-AFFlow: added parameter ClientToken.
    * Modified cmdlet Register-AFConnector: added parameter ClientToken.
    * Modified cmdlet Start-AFFlow: added parameter ClientToken.
    * Modified cmdlet Update-AFConnectorProfile: added parameter ClientToken.
    * Modified cmdlet Update-AFConnectorRegistration: added parameter ClientToken.
    * Modified cmdlet Update-AFFlow: added parameter ClientToken.
  * Amazon CloudWatch Internet Monitor
    * Modified cmdlet New-CWIMMonitor: added parameter TrafficPercentageToMonitor.
    * Modified cmdlet Update-CWIMMonitor: added parameter TrafficPercentageToMonitor.
  * Amazon Elastic Disaster Recovery Service
    * Added cmdlet Get-EDRSLaunchConfigurationTemplate leveraging the DescribeLaunchConfigurationTemplates service API.
    * Added cmdlet New-EDRSLaunchConfigurationTemplate leveraging the CreateLaunchConfigurationTemplate service API.
    * Added cmdlet Remove-EDRSLaunchConfigurationTemplate leveraging the DeleteLaunchConfigurationTemplate service API.
    * Added cmdlet Update-EDRSLaunchConfigurationTemplate leveraging the UpdateLaunchConfigurationTemplate service API.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWServiceProfile: added parameters LoRaWAN_PrAllowed and LoRaWAN_RaAllowed.
    * Modified cmdlet New-IOTWWirelessGateway: added parameter LoRaWAN_MaxEirp.
    * Modified cmdlet Start-IOTWMulticastGroupSession: added parameter LoRaWAN_PingSlotPeriod.
    * Modified cmdlet Update-IOTWWirelessGateway: added parameter MaxEirp.

### 4.1.314 (2023-04-14 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.527.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameters AllowEngineModeChange and EngineMode.

### 4.1.313 (2023-04-13 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.526.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Voice
    * Modified cmdlet New-CHMVOSipMediaApplication: added parameter Tag.
    * Modified cmdlet New-CHMVOVoiceConnector: added parameter Tag.
  * Amazon Elemental MediaConnect
    * Added cmdlet Add-EMCNBridgeOutput leveraging the AddBridgeOutputs service API.
    * Added cmdlet Add-EMCNBridgeSource leveraging the AddBridgeSources service API.
    * Added cmdlet Get-EMCNBridge leveraging the DescribeBridge service API.
    * Added cmdlet Get-EMCNBridgeList leveraging the ListBridges service API.
    * Added cmdlet Get-EMCNGateway leveraging the DescribeGateway service API.
    * Added cmdlet Get-EMCNGatewayInstance leveraging the DescribeGatewayInstance service API.
    * Added cmdlet Get-EMCNGatewayInstanceList leveraging the ListGatewayInstances service API.
    * Added cmdlet Get-EMCNGatewayList leveraging the ListGateways service API.
    * Added cmdlet New-EMCNBridge leveraging the CreateBridge service API.
    * Added cmdlet New-EMCNGateway leveraging the CreateGateway service API.
    * Added cmdlet Remove-EMCNBridge leveraging the DeleteBridge service API.
    * Added cmdlet Remove-EMCNBridgeOutput leveraging the RemoveBridgeOutput service API.
    * Added cmdlet Remove-EMCNBridgeSource leveraging the RemoveBridgeSource service API.
    * Added cmdlet Remove-EMCNGateway leveraging the DeleteGateway service API.
    * Added cmdlet Remove-EMCNGatewayInstance leveraging the DeregisterGatewayInstance service API.
    * Added cmdlet Update-EMCNBridge leveraging the UpdateBridge service API.
    * Added cmdlet Update-EMCNBridgeOutput leveraging the UpdateBridgeOutput service API.
    * Added cmdlet Update-EMCNBridgeSource leveraging the UpdateBridgeSource service API.
    * Added cmdlet Update-EMCNBridgeState leveraging the UpdateBridgeState service API.
    * Added cmdlet Update-EMCNGatewayInstance leveraging the UpdateGatewayInstance service API.
    * Modified cmdlet Update-EMCNFlowSource: added parameters GatewayBridgeSource_BridgeArn and VpcInterfaceAttachment_VpcInterfaceName.

### 4.1.312 (2023-04-12 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.525.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Ground Station
    * Modified cmdlet Register-GSAgent: added parameter AgentDetails_AgentCpuCore.

### 4.1.311 (2023-04-11 22:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.524.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter AssociationConfig_RequestBody.
    * Modified cmdlet Update-WAF2WebACL: added parameter AssociationConfig_RequestBody.

### 4.1.310 (2023-04-10 21:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.523.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Marketplace Catalog Service
    * Added cmdlet Get-MCATResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet Remove-MCATResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Write-MCATResourcePolicy leveraging the PutResourcePolicy service API.
    * Modified cmdlet Get-MCATEntityList: added parameter OwnershipType.
  * Amazon Rekognition
    * Added cmdlet Get-REKFaceLivenessSessionResult leveraging the GetFaceLivenessSessionResults service API.
    * Added cmdlet New-REKFaceLivenessSession leveraging the CreateFaceLivenessSession service API.

### 4.1.309 (2023-04-07 20:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.522.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DocumentDB (with MongoDB compatibility)
    * Modified cmdlet Restore-DOCDBClusterFromSnapshot: added parameter DBClusterParameterGroupName.
  * Amazon Lambda
    * Added cmdlet Invoke-LMWithResponseStream leveraging the InvokeWithResponseStream service API.
    * Modified cmdlet New-LMFunctionUrlConfig: added parameter InvokeMode.
    * Modified cmdlet Update-LMFunctionUrlConfig: added parameter InvokeMode.
  * Amazon QuickSight
    * Added cmdlet Get-QSDataSetRefreshProperty leveraging the DescribeDataSetRefreshProperties service API.
    * Added cmdlet Get-QSRefreshSchedule leveraging the DescribeRefreshSchedule service API.
    * Added cmdlet Get-QSRefreshScheduleList leveraging the ListRefreshSchedules service API.
    * Added cmdlet New-QSRefreshSchedule leveraging the CreateRefreshSchedule service API.
    * Added cmdlet Remove-QSDataSetRefreshProperty leveraging the DeleteDataSetRefreshProperties service API.
    * Added cmdlet Remove-QSRefreshSchedule leveraging the DeleteRefreshSchedule service API.
    * Added cmdlet Update-QSRefreshSchedule leveraging the UpdateRefreshSchedule service API.
    * Added cmdlet Write-QSDataSetRefreshProperty leveraging the PutDataSetRefreshProperties service API.
    * Modified cmdlet New-QSDataSet: added parameter RowLevelPermissionTagConfiguration_TagRuleConfiguration.
    * Modified cmdlet Update-QSDataSet: added parameter RowLevelPermissionTagConfiguration_TagRuleConfiguration.

### 4.1.308 (2023-04-06 21:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.521.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * 
    * Added cmdlet ConvertFrom-DDBItem.
    * Added cmdlet ConvertTo-DDBItem.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBBatchItem leveraging the BatchGetItem service API.
    * Added cmdlet Get-DDBItem leveraging the GetItem service API.
    * Added cmdlet Invoke-DDBQuery leveraging the Query service API.
    * Added cmdlet Invoke-DDBScan leveraging the Scan service API.
    * Added cmdlet Remove-DDBItem leveraging the DeleteItem service API.
    * Added cmdlet Set-DDBBatchItem leveraging the BatchWriteItem service API.
    * Added cmdlet Set-DDBItem leveraging the PutItem service API.
    * Added cmdlet Update-DDBItem leveraging the UpdateItem service API.
  * Amazon Proton
    * Added cmdlet Get-PROServiceInstanceSyncStatus leveraging the GetServiceInstanceSyncStatus service API.
    * Added cmdlet Get-PROServiceSyncBlockerSummary leveraging the GetServiceSyncBlockerSummary service API.
    * Added cmdlet Get-PROServiceSyncConfig leveraging the GetServiceSyncConfig service API.
    * Added cmdlet New-PROServiceInstance leveraging the CreateServiceInstance service API.
    * Added cmdlet New-PROServiceSyncConfig leveraging the CreateServiceSyncConfig service API.
    * Added cmdlet Remove-PROServiceSyncConfig leveraging the DeleteServiceSyncConfig service API.
    * Added cmdlet Update-PROServiceSyncBlocker leveraging the UpdateServiceSyncBlocker service API.
    * Added cmdlet Update-PROServiceSyncConfig leveraging the UpdateServiceSyncConfig service API.
    * Modified cmdlet New-PROComponent: added parameter ClientToken.
    * Modified cmdlet Update-PROComponent: added parameter ClientToken.
    * Modified cmdlet Update-PROServiceInstance: added parameter ClientToken.

### 4.1.307 (2023-04-05 21:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.520.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.306 (2023-04-04 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.519.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify UI Builder
    * Modified cmdlet Convert-AMPUICodeForToken: added parameter Request_ClientId.
    * Modified cmdlet New-AMPUIForm: added parameter FormToCreate_LabelDecorator.
    * Modified cmdlet Update-AMPUIForm: added parameter UpdatedForm_LabelDecorator.
    * Modified cmdlet Update-AMPUIToken: added parameter RefreshTokenBody_ClientId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMEndpointConfig: added parameters NotificationConfig_IncludeInferenceResponseIn and OutputConfig_S3FailurePath.
  * Amazon WAF V2
    * [Breaking Change] Modified cmdlet New-WAF2WebACL: removed parameter AssociationConfig_RequestBody.
    * [Breaking Change] Modified cmdlet Update-WAF2WebACL: removed parameter AssociationConfig_RequestBody.

### 4.1.305 (2023-04-03 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.518.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAA
    * Modified cmdlet New-MWAAEnvironment: added parameters StartupScriptS3ObjectVersion and StartupScriptS3Path.
    * Modified cmdlet Update-MWAAEnvironment: added parameters StartupScriptS3ObjectVersion and StartupScriptS3Path.
  * Amazon Lake Formation
    * Modified cmdlet Register-LKFResource: added parameter WithFederation.
    * Modified cmdlet Update-LKFResource: added parameter WithFederation.
  * Amazon License Manager
    * Modified cmdlet New-LICMGrantVersion: added parameter Options_ActivationOverrideBehavior.
  * Amazon Service Catalog
    * Added cmdlet Start-SCProvisionProductEngineWorkflowResult leveraging the NotifyProvisionProductEngineWorkflowResult service API.
    * Added cmdlet Start-SCTerminateProvisionedProductEngineWorkflowResult leveraging the NotifyTerminateProvisionedProductEngineWorkflowResult service API.
    * Added cmdlet Start-SCUpdateProvisionedProductEngineWorkflowResult leveraging the NotifyUpdateProvisionedProductEngineWorkflowResult service API.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter AssociationConfig_RequestBody.
    * Modified cmdlet Update-WAF2WebACL: added parameter AssociationConfig_RequestBody.

### 4.1.304 (2023-03-31 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.517.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Internet Monitor
    * Modified cmdlet New-CWIMMonitor: added parameters S3Config_BucketName, S3Config_BucketPrefix and S3Config_LogDeliveryStatus.
    * Modified cmdlet Update-CWIMMonitor: added parameters S3Config_BucketName, S3Config_BucketPrefix and S3Config_LogDeliveryStatus.
  * Amazon SageMaker Feature Store Runtime
    * Modified cmdlet Remove-SMFSRecord: added parameter DeletionMode.

### 4.1.303 (2023-03-30 21:13Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.516.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Image Builder
    * Added cmdlet Get-EC2IBImageScanFindingAggregationList leveraging the ListImageScanFindingAggregations service API.
    * Added cmdlet Get-EC2IBImageScanFindingList leveraging the ListImageScanFindings service API.
    * Added cmdlet Get-EC2IBWorkflowExecution leveraging the GetWorkflowExecution service API.
    * Added cmdlet Get-EC2IBWorkflowExecutionList leveraging the ListWorkflowExecutions service API.
    * Added cmdlet Get-EC2IBWorkflowStepExecution leveraging the GetWorkflowStepExecution service API.
    * Added cmdlet Get-EC2IBWorkflowStepExecutionList leveraging the ListWorkflowStepExecutions service API.
    * Modified cmdlet New-EC2IBImage: added parameters EcrConfiguration_ContainerTag, EcrConfiguration_RepositoryName and ImageScanningConfiguration_ImageScanningEnabled.
    * Modified cmdlet New-EC2IBImagePipeline: added parameters EcrConfiguration_ContainerTag, EcrConfiguration_RepositoryName and ImageScanningConfiguration_ImageScanningEnabled.
    * Modified cmdlet Update-EC2IBImagePipeline: added parameters EcrConfiguration_ContainerTag, EcrConfiguration_RepositoryName and ImageScanningConfiguration_ImageScanningEnabled.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2VpnTunnelReplacementStatus leveraging the GetVpnTunnelReplacementStatus service API.
    * Added cmdlet Set-EC2VpnTunnel leveraging the ReplaceVpnTunnel service API.
    * Modified cmdlet Edit-EC2VpnTunnelOption: added parameters SkipTunnelReplacement and TunnelOptions_EnableTunnelLifecycleControl.
  * Amazon Elastic Disaster Recovery Service
    * Modified cmdlet New-EDRSReplicationConfigurationTemplate: added parameter AutoReplicateNewDisk.
    * Modified cmdlet Update-EDRSReplicationConfiguration: added parameter AutoReplicateNewDisk.
    * Modified cmdlet Update-EDRSReplicationConfigurationTemplate: added parameter AutoReplicateNewDisk.
  * Amazon Glue
    * [Breaking Change] Modified cmdlet Update-GLUEDataQualityRuleset: removed parameter UpdatedName.
  * Amazon GuardDuty
    * Added cmdlet Get-GDCoverageList leveraging the ListCoverage service API.
    * Added cmdlet Get-GDCoverageStatistic leveraging the GetCoverageStatistics service API.
  * Amazon Interactive Video Service
    * Modified cmdlet New-IVSChannel: added parameter InsecureIngest.
    * Modified cmdlet Update-IVSChannel: added parameter InsecureIngest.
  * Amazon Kendra
    * Added cmdlet Get-KNDRFeaturedResultsSet leveraging the DescribeFeaturedResultsSet service API.
    * Added cmdlet Get-KNDRFeaturedResultsSetList leveraging the ListFeaturedResultsSets service API.
    * Added cmdlet New-KNDRFeaturedResultsSet leveraging the CreateFeaturedResultsSet service API.
    * Added cmdlet Remove-KNDRFeaturedResultsSetBatch leveraging the BatchDeleteFeaturedResultsSet service API.
    * Added cmdlet Update-KNDRFeaturedResultsSet leveraging the UpdateFeaturedResultsSet service API.
  * Amazon Network Firewall
    * Added cmdlet Get-NWFWTLSInspectionConfiguration leveraging the DescribeTLSInspectionConfiguration service API.
    * Added cmdlet Get-NWFWTLSInspectionConfigurationList leveraging the ListTLSInspectionConfigurations service API.
    * Added cmdlet New-NWFWTLSInspectionConfiguration leveraging the CreateTLSInspectionConfiguration service API.
    * Added cmdlet Remove-NWFWTLSInspectionConfiguration leveraging the DeleteTLSInspectionConfiguration service API.
    * Added cmdlet Update-NWFWTLSInspectionConfiguration leveraging the UpdateTLSInspectionConfiguration service API.
    * Modified cmdlet New-NWFWFirewallPolicy: added parameter FirewallPolicy_TLSInspectionConfigurationArn.
    * Modified cmdlet Update-NWFWFirewallPolicy: added parameter FirewallPolicy_TLSInspectionConfigurationArn.
  * Amazon SageMaker Geospatial
    * Modified cmdlet Export-SMGSEarthObservationJob: added parameter ClientToken.
    * Modified cmdlet Export-SMGSVectorEnrichmentJob: added parameter ClientToken.
    * Modified cmdlet Get-SMGSTile: added parameter ExecutionRoleArn.
    * Modified cmdlet Start-SMGSEarthObservationJob: added parameter ZonalStatisticsConfig_ZoneS3PathKmsKeyId.
  * Amazon VPC Lattice. Added cmdlets to support the service. Cmdlets for the service have the noun prefix VPCL and can be listed using the command 'Get-AWSCmdletName -Service VPCL'.
  * Amazon Well-Architected Tool
    * Added cmdlet Get-WATConsolidatedReport leveraging the GetConsolidatedReport service API.

### 4.1.302 (2023-03-29 21:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.515.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter SourceDBClusterIdentifier.

### 4.1.301 (2023-03-28 20:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.514.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon System Manager Contacts
    * Added cmdlet Get-SMCPageResolutionList leveraging the ListPageResolutions service API.
    * Added cmdlet Get-SMCPreviewRotationShiftList leveraging the ListPreviewRotationShifts service API.
    * Added cmdlet Get-SMCRotation leveraging the GetRotation service API.
    * Added cmdlet Get-SMCRotationList leveraging the ListRotations service API.
    * Added cmdlet Get-SMCRotationOverride leveraging the GetRotationOverride service API.
    * Added cmdlet Get-SMCRotationOverrideList leveraging the ListRotationOverrides service API.
    * Added cmdlet Get-SMCRotationShiftList leveraging the ListRotationShifts service API.
    * Added cmdlet New-SMCRotation leveraging the CreateRotation service API.
    * Added cmdlet New-SMCRotationOverride leveraging the CreateRotationOverride service API.
    * Added cmdlet Remove-SMCRotation leveraging the DeleteRotation service API.
    * Added cmdlet Remove-SMCRotationOverride leveraging the DeleteRotationOverride service API.
    * Added cmdlet Update-SMCRotation leveraging the UpdateRotation service API.
    * Modified cmdlet New-SMCContact: added parameter Plan_RotationId.
    * Modified cmdlet Update-SMCContact: added parameter Plan_RotationId.

### 4.1.300 (2023-03-27 20:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.513.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Athena
    * Modified cmdlet New-ATHWorkGroup: added parameter Configuration_EnableMinimumEncryptionConfiguration.
    * Modified cmdlet Update-ATHWorkGroup: added parameter ConfigurationUpdates_EnableMinimumEncryptionConfiguration.
  * Amazon Connect Service
    * Modified cmdlet Start-CONNChatContact: added parameter RelatedContactId.
  * Amazon IoT Wireless
    * Added cmdlet Get-IOTWDevicesForWirelessDeviceImportTaskList leveraging the ListDevicesForWirelessDeviceImportTask service API.
    * Added cmdlet Get-IOTWWirelessDeviceImportTask leveraging the GetWirelessDeviceImportTask service API.
    * Added cmdlet Get-IOTWWirelessDeviceImportTaskList leveraging the ListWirelessDeviceImportTasks service API.
    * Added cmdlet Remove-IOTWWirelessDeviceImportTask leveraging the DeleteWirelessDeviceImportTask service API.
    * Added cmdlet Start-IOTWSingleWirelessDeviceImportTask leveraging the StartSingleWirelessDeviceImportTask service API.
    * Added cmdlet Start-IOTWWirelessDeviceImportTask leveraging the StartWirelessDeviceImportTask service API.
    * Added cmdlet Unregister-IOTWWirelessDevice leveraging the DeregisterWirelessDevice service API.
    * Added cmdlet Update-IOTWWirelessDeviceImportTask leveraging the UpdateWirelessDeviceImportTask service API.
    * Modified cmdlet Get-IOTWDeviceProfileList: added parameter DeviceProfileType.
    * Modified cmdlet New-IOTWDeviceProfile: added parameter Sidewalk.
    * Modified cmdlet New-IOTWWirelessDevice: added parameter Sidewalk_DeviceProfileId.
  * Amazon Voice ID
    * Added cmdlet Add-VIDFraudsterAssociation leveraging the AssociateFraudster service API.
    * Added cmdlet Get-VIDFraudsterList leveraging the ListFraudsters service API.
    * Added cmdlet Get-VIDWatchlist leveraging the DescribeWatchlist service API.
    * Added cmdlet Get-VIDWatchlistList leveraging the ListWatchlists service API.
    * Added cmdlet New-VIDWatchlist leveraging the CreateWatchlist service API.
    * Added cmdlet Remove-VIDFraudsterAssociation leveraging the DisassociateFraudster service API.
    * Added cmdlet Remove-VIDWatchlist leveraging the DeleteWatchlist service API.
    * Added cmdlet Update-VIDWatchlist leveraging the UpdateWatchlist service API.
    * Modified cmdlet Start-VIDFraudsterRegistrationJob: added parameter RegistrationConfig_WatchlistId.
    * Modified cmdlet Start-VIDSpeakerEnrollmentJob: added parameter FraudDetectionConfig_WatchlistId.

### 4.1.299 (2023-03-24 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.512.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.298 (2023-03-23 21:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.511.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameters EphemeralStorage_SizeInGiB and Metadata_Label.
    * Modified cmdlet Submit-BATJob: added parameter Metadata_Label.
  * Amazon Chime SDK Identity
    * Added cmdlet Get-CHMIDAppInstanceBot leveraging the DescribeAppInstanceBot service API.
    * Added cmdlet Get-CHMIDAppInstanceBotList leveraging the ListAppInstanceBots service API.
    * Added cmdlet New-CHMIDAppInstanceBot leveraging the CreateAppInstanceBot service API.
    * Added cmdlet Remove-CHMIDAppInstanceBot leveraging the DeleteAppInstanceBot service API.
    * Added cmdlet Update-CHMIDAppInstanceBot leveraging the UpdateAppInstanceBot service API.
    * Added cmdlet Write-CHMIDAppInstanceUserExpirationSetting leveraging the PutAppInstanceUserExpirationSettings service API.
    * Modified cmdlet New-CHMIDAppInstanceUser: added parameters ExpirationSettings_ExpirationCriterion and ExpirationSettings_ExpirationDay.
  * Amazon Chime SDK Media Pipelines
    * Added cmdlet Get-CHMMPMediaInsightsPipelineConfiguration leveraging the GetMediaInsightsPipelineConfiguration service API.
    * Added cmdlet Get-CHMMPMediaInsightsPipelineConfigurationList leveraging the ListMediaInsightsPipelineConfigurations service API.
    * Added cmdlet New-CHMMPMediaInsightsPipeline leveraging the CreateMediaInsightsPipeline service API.
    * Added cmdlet New-CHMMPMediaInsightsPipelineConfiguration leveraging the CreateMediaInsightsPipelineConfiguration service API.
    * Added cmdlet Remove-CHMMPMediaInsightsPipelineConfiguration leveraging the DeleteMediaInsightsPipelineConfiguration service API.
    * Added cmdlet Update-CHMMPMediaInsightsPipelineConfiguration leveraging the UpdateMediaInsightsPipelineConfiguration service API.
    * Added cmdlet Update-CHMMPMediaInsightsPipelineStatus leveraging the UpdateMediaInsightsPipelineStatus service API.
  * Amazon Chime SDK Messaging
    * Added cmdlet Write-CHMMGChannelExpirationSetting leveraging the PutChannelExpirationSettings service API.
    * Modified cmdlet New-CHMMGChannel: added parameters ExpirationSettings_ExpirationCriterion and ExpirationSettings_ExpirationDay.
    * Modified cmdlet Send-CHMMGChannelFlowCallback: added parameter ChannelMessage_ContentType.
    * Modified cmdlet Send-CHMMGChannelMessage: added parameter ContentType.
    * Modified cmdlet Update-CHMMGChannelMessage: added parameter ContentType.
  * Amazon Chime SDK Voice
    * Added cmdlet Add-CHMVOResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CHMVOResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-CHMVOSpeakerSearchTask leveraging the GetSpeakerSearchTask service API.
    * Added cmdlet Get-CHMVOVoiceProfile leveraging the GetVoiceProfile service API.
    * Added cmdlet Get-CHMVOVoiceProfileDomain leveraging the GetVoiceProfileDomain service API.
    * Added cmdlet Get-CHMVOVoiceProfileDomainList leveraging the ListVoiceProfileDomains service API.
    * Added cmdlet Get-CHMVOVoiceProfileList leveraging the ListVoiceProfiles service API.
    * Added cmdlet Get-CHMVOVoiceToneAnalysisTask leveraging the GetVoiceToneAnalysisTask service API.
    * Added cmdlet New-CHMVOVoiceProfile leveraging the CreateVoiceProfile service API.
    * Added cmdlet New-CHMVOVoiceProfileDomain leveraging the CreateVoiceProfileDomain service API.
    * Added cmdlet Remove-CHMVOResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-CHMVOVoiceProfile leveraging the DeleteVoiceProfile service API.
    * Added cmdlet Remove-CHMVOVoiceProfileDomain leveraging the DeleteVoiceProfileDomain service API.
    * Added cmdlet Start-CHMVOSpeakerSearchTask leveraging the StartSpeakerSearchTask service API.
    * Added cmdlet Start-CHMVOVoiceToneAnalysisTask leveraging the StartVoiceToneAnalysisTask service API.
    * Added cmdlet Stop-CHMVOSpeakerSearchTask leveraging the StopSpeakerSearchTask service API.
    * Added cmdlet Stop-CHMVOVoiceToneAnalysisTask leveraging the StopVoiceToneAnalysisTask service API.
    * Added cmdlet Update-CHMVOVoiceProfile leveraging the UpdateVoiceProfile service API.
    * Added cmdlet Update-CHMVOVoiceProfileDomain leveraging the UpdateVoiceProfileDomain service API.
    * Modified cmdlet Write-CHMVOVoiceConnectorStreamingConfiguration: added parameters MediaInsightsConfiguration_ConfigurationArn and MediaInsightsConfiguration_Disabled.
  * Amazon GuardDuty
    * Modified cmdlet Update-GDOrganizationConfiguration: added parameter AutoEnableOrganizationMember.
  * Amazon Interactive Video Service RealTime. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IVSRT and can be listed using the command 'Get-AWSCmdletName -Service IVSRT'.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMAutoMLJobV2 leveraging the DescribeAutoMLJobV2 service API.
    * Added cmdlet New-SMAutoMLJobV2 leveraging the CreateAutoMLJobV2 service API.

### 4.1.297 (2023-03-22 21:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.510.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT TwinMaker
    * Modified cmdlet New-IOTTMScene: added parameter SceneMetadata.
    * Modified cmdlet Update-IOTTMScene: added parameter SceneMetadata.
  * Amazon Resilience Hub
    * Modified cmdlet Get-RESHAppVersionResource: added parameter LogicalResourceId_EksSourceName.
    * Modified cmdlet Import-RESHResourcesToDraftAppVersion: added parameter EksSource.
    * Modified cmdlet New-RESHAppVersionResource: added parameter LogicalResourceId_EksSourceName.
    * Modified cmdlet Remove-RESHAppInputSource: added parameters EksSourceClusterNamespace_EksClusterArn and EksSourceClusterNamespace_Namespace.
    * Modified cmdlet Remove-RESHAppVersionResource: added parameter LogicalResourceId_EksSourceName.
    * Modified cmdlet Remove-RESHDraftAppVersionResourceMapping: added parameter EksSourceName.
    * Modified cmdlet Update-RESHAppVersionResource: added parameter LogicalResourceId_EksSourceName.

### 4.1.296 (2023-03-21 23:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.509.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.295 (2023-03-20 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.508.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Auto Scaling
    * Added cmdlet Add-AASResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AASResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-AASResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Add-AASScalableTarget: added parameter Tag.
  * Amazon WorkDocs
    * Added cmdlet Search-WDResource leveraging the SearchResources service API.

### 4.1.294 (2023-03-17 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.507.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSBillingConductor
    * Modified cmdlet Get-ABCAccountAssociationList: added parameter Filters_AccountIds.
    * Modified cmdlet Get-ABCBillingGroupList: added parameter Filters_Status.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters KafkaSettings_SaslMechanism, MicrosoftSQLServerSettings_ForceLobLookup, MicrosoftSQLServerSettings_TlogAccessMode, OracleSettings_ConvertTimestampWithZoneToUTC, PostgreSQLSettings_MapBooleanAsBoolean, RedshiftSettings_MapBooleanAsBoolean and S3Settings_GlueCatalogGeneration.
    * Modified cmdlet New-DMSEndpoint: added parameters KafkaSettings_SaslMechanism, MicrosoftSQLServerSettings_ForceLobLookup, MicrosoftSQLServerSettings_TlogAccessMode, OracleSettings_ConvertTimestampWithZoneToUTC, PostgreSQLSettings_MapBooleanAsBoolean, RedshiftSettings_MapBooleanAsBoolean and S3Settings_GlueCatalogGeneration.

### 4.1.293 (2023-03-16 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.505.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon GuardDuty
    * Modified cmdlet Get-GDOrganizationConfiguration: added parameters MaxResult, NextToken and NoAutoIteration.
    * Modified cmdlet Get-GDUsageStatistic: added parameter UsageCriteria_Feature.
    * Modified cmdlet New-GDDetector: added parameter Feature.
    * Modified cmdlet Update-GDDetector: added parameter Feature.
    * Modified cmdlet Update-GDMemberDetector: added parameter Feature.
    * Modified cmdlet Update-GDOrganizationConfiguration: added parameter Feature.

### 4.1.292 (2023-03-15 21:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.504.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.291 (2023-03-14 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.503.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Auto Scaling
    * Modified cmdlet Set-AASScalingPolicy: added parameter CustomizedMetricSpecification_Metric.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXJob: added parameter AssetSource_KmsKeysToGrant.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2VpcEndpoint: added parameter DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint.
    * Modified cmdlet New-EC2VpcEndpoint: added parameter DnsOptions_PrivateDnsOnlyForInboundResolverEndpoint.
  * Amazon Keyspaces
    * Modified cmdlet New-KSTable: added parameter ClientSideTimestamps_Status.
    * Modified cmdlet Update-KSTable: added parameter ClientSideTimestamps_Status.

### 4.1.290 (2023-03-13 21:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.502.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppIntegrations Service
    * Modified cmdlet New-AISDataIntegration: added parameters FileConfiguration_Filter, FileConfiguration_Folder and ObjectConfiguration.
  * Amazon S3 Control
    * Added cmdlet Get-S3CBucketReplication leveraging the GetBucketReplication service API.
    * Added cmdlet Remove-S3CBucketReplication leveraging the DeleteBucketReplication service API.
    * Added cmdlet Write-S3CBucketReplication leveraging the PutBucketReplication service API.
  * Amazon Telco Network Builder
    * Modified cmdlet Start-TNBSolNetworkInstance: added parameter Tag.
    * Modified cmdlet Stop-TNBSolNetworkInstance: added parameter Tag.
    * Modified cmdlet Update-TNBSolNetworkInstance: added parameter Tag.

### 4.1.289 (2023-03-10 22:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.501.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * 
    * Modified cmdlet Set-AWSHistoryConfiguration: added parameter IncludeSensitiveData.

### 4.1.288 (2023-03-09 22:11Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.500.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeArtifact
    * Added cmdlet Publish-CAPackageVersion leveraging the PublishPackageVersion service API.
  * Amazon Connect Service
    * Added cmdlet Get-CONNMetricDataV2 leveraging the GetMetricDataV2 service API.
  * Amazon QuickSight
    * Modified cmdlet New-QSEmbedUrlForRegisteredUser: added parameters ExperienceConfiguration_Dashboard_FeatureConfigurations_StatePersistence_Enabled and ExperienceConfiguration_QuickSightConsole_FeatureConfigurations_StatePersistence_Enabled.

### 4.1.287 (2023-03-08 22:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.499.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBTable: added parameter DeletionProtectionEnabled.
  * Amazon Lake Formation
    * Added cmdlet Get-LKFDataCellsFilter leveraging the GetDataCellsFilter service API.
    * Added cmdlet Update-LKFDataCellsFilter leveraging the UpdateDataCellsFilter service API.
    * Modified cmdlet New-LKFDataCellsFilter: added parameter TableData_VersionId.
  * Amazon Route 53 Resolver
    * Modified cmdlet New-R53RResolverEndpoint: added parameter ResolverEndpointType.
    * Modified cmdlet Update-R53RResolverEndpoint: added parameters ResolverEndpointType and UpdateIpAddress.

### 4.1.286 (2023-03-07 22:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.498.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Database Migration Service
    * Added cmdlet Get-DMSRecommendation leveraging the DescribeRecommendations service API.
    * Added cmdlet Get-DMSRecommendationLimitation leveraging the DescribeRecommendationLimitations service API.
    * Added cmdlet Start-DMSBatchRecommendation leveraging the BatchStartRecommendations service API.
    * Added cmdlet Start-DMSRecommendation leveraging the StartRecommendations service API.

### 4.1.285 (2023-03-06 21:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.497.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.284 (2023-03-03 22:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.496.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Transcribe Service
    * Modified cmdlet New-TRSVocabulary: added parameter DataAccessRoleArn.
    * Modified cmdlet New-TRSVocabularyFilter: added parameter DataAccessRoleArn.
    * Modified cmdlet Update-TRSVocabulary: added parameter DataAccessRoleArn.
    * Modified cmdlet Update-TRSVocabularyFilter: added parameter DataAccessRoleArn.

### 4.1.283 (2023-03-02 22:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.495.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon IoT
    * Modified cmdlet New-IOTJob: added parameter SchedulingConfig_MaintenanceWindow.
    * Modified cmdlet New-IOTJobTemplate: added parameter MaintenanceWindow.
  * Amazon Performance Insights
    * Modified cmdlet Get-PIResourceMetric: added parameter PeriodAlignment.

### 4.1.282 (2023-03-01 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.494.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CodeCatalyst
    * Added cmdlet Stop-CCATDevEnvironmentSession leveraging the StopDevEnvironmentSession service API.
  * Amazon Price List Service
    * Added cmdlet Get-PLSPriceListFileUrl leveraging the GetPriceListFileUrl service API.
    * Added cmdlet Get-PLSPriceListList leveraging the ListPriceLists service API.
  * Amazon S3 Outposts
    * Added cmdlet Get-S3OOutpostsWithS3List leveraging the ListOutpostsWithS3 service API.

### 4.1.281 (2023-02-28 21:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.493.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Comprehend
    * Added cmdlet Get-COMPDataset leveraging the DescribeDataset service API.
    * Added cmdlet Get-COMPDatasetList leveraging the ListDatasets service API.
    * Added cmdlet Get-COMPFlywheel leveraging the DescribeFlywheel service API.
    * Added cmdlet Get-COMPFlywheelIteration leveraging the DescribeFlywheelIteration service API.
    * Added cmdlet Get-COMPFlywheelIterationHistoryList leveraging the ListFlywheelIterationHistory service API.
    * Added cmdlet Get-COMPFlywheelList leveraging the ListFlywheels service API.
    * Added cmdlet New-COMPDataset leveraging the CreateDataset service API.
    * Added cmdlet New-COMPFlywheel leveraging the CreateFlywheel service API.
    * Added cmdlet Remove-COMPFlywheel leveraging the DeleteFlywheel service API.
    * Added cmdlet Start-COMPFlywheelIteration leveraging the StartFlywheelIteration service API.
    * Added cmdlet Update-COMPFlywheel leveraging the UpdateFlywheel service API.
    * Modified cmdlet New-COMPDocumentClassifier: added parameter OutputDataConfig_FlywheelStatsS3Prefix.
    * Modified cmdlet New-COMPEndpoint: added parameter FlywheelArn.
    * Modified cmdlet Start-COMPDocumentClassificationJob: added parameter FlywheelArn.
    * Modified cmdlet Start-COMPEntitiesDetectionJob: added parameter FlywheelArn.
    * Modified cmdlet Update-COMPEndpoint: added parameter FlywheelArn.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2ImageAttribute: added parameter ImdsSupport.
  * Amazon Lightsail
    * Added cmdlet Get-LSCostEstimate leveraging the GetCostEstimate service API.
    * Added cmdlet New-LSGUISessionAccessDetail leveraging the CreateGUISessionAccessDetails service API.
    * Added cmdlet Start-LSGUISession leveraging the StartGUISession service API.
    * Added cmdlet Stop-LSGUISession leveraging the StopGUISession service API.
    * Modified cmdlet Add-LSDisk: added parameter AutoMounting.
    * Modified cmdlet Enable-LSAddOn: added parameters StopInstanceOnIdleRequest_Duration and StopInstanceOnIdleRequest_Threshold.
    * Modified cmdlet Get-LSBlueprintList: added parameter AppCategory.
    * Modified cmdlet Get-LSBundleList: added parameter AppCategory.
  * Amazon Managed Blockchain
    * Modified cmdlet New-MBCAccessor: added parameter Tag.

### 4.1.280 (2023-02-27 22:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.492.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Internet Monitor. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CWIM and can be listed using the command 'Get-AWSCmdletName -Service CWIM'.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameters DocumentDBEventSourceConfig_CollectionName, DocumentDBEventSourceConfig_DatabaseName and DocumentDBEventSourceConfig_FullDocument.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters DocumentDBEventSourceConfig_CollectionName, DocumentDBEventSourceConfig_DatabaseName and DocumentDBEventSourceConfig_FullDocument.
  * Amazon Timestream Write
    * Added cmdlet Get-TSWBatchLoadTask leveraging the DescribeBatchLoadTask service API.
    * Added cmdlet Get-TSWBatchLoadTaskList leveraging the ListBatchLoadTasks service API.
    * Added cmdlet New-TSWBatchLoadTask leveraging the CreateBatchLoadTask service API.
    * Added cmdlet Resume-TSWBatchLoadTask leveraging the ResumeBatchLoadTask service API.

### 4.1.279 (2023-02-24 21:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.491.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Added cmdlet Remove-CCASDomain leveraging the DeleteDomain service API.
  * Amazon Connect Service
    * Modified cmdlet Start-CONNTaskContact: added parameter RelatedContactId.
  * Amazon Security Hub
    * Added cmdlet Edit-SHUBUpdateStandardsControlAssociation leveraging the BatchUpdateStandardsControlAssociations service API.
    * Added cmdlet Get-SHUBGetSecurityControl leveraging the BatchGetSecurityControls service API.
    * Added cmdlet Get-SHUBGetStandardsControlAssociation leveraging the BatchGetStandardsControlAssociations service API.
    * Added cmdlet Get-SHUBSecurityControlDefinitionList leveraging the ListSecurityControlDefinitions service API.
    * Added cmdlet Get-SHUBStandardsControlAssociationList leveraging the ListStandardsControlAssociations service API.
    * Modified cmdlet Enable-SHUBSecurityHub: added parameter ControlFindingGenerator.
    * Modified cmdlet Update-SHUBSecurityHubConfiguration: added parameter ControlFindingGenerator.

### 4.1.278 (2023-02-23 22:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.490.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Service
    * Added cmdlet Remove-ECSTaskDefinition leveraging the DeleteTaskDefinitions service API.
  * Amazon IoT Wireless
    * Modified cmdlet New-IOTWFuotaTask: added parameters FragmentIntervalMS, FragmentSizeByte and RedundancyPercent.
    * Modified cmdlet Update-IOTWFuotaTask: added parameters FragmentIntervalMS, FragmentSizeByte and RedundancyPercent.
  * Amazon Location Service
    * Added cmdlet Get-LOCKey leveraging the DescribeKey service API.
    * Added cmdlet Get-LOCKeyList leveraging the ListKeys service API.
    * Added cmdlet New-LOCKey leveraging the CreateKey service API.
    * Added cmdlet Remove-LOCKey leveraging the DeleteKey service API.
    * Added cmdlet Update-LOCKey leveraging the UpdateKey service API.
    * Modified cmdlet Get-LOCMapGlyph: added parameter Key.
    * Modified cmdlet Get-LOCMapSprite: added parameter Key.
    * Modified cmdlet Get-LOCMapStyleDescriptor: added parameter Key.
    * Modified cmdlet Get-LOCMapTile: added parameter Key.

### 4.1.277 (2023-02-22 21:50Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.489.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Chime SDK Voice
    * Modified cmdlet Write-CHMVOVoiceConnectorLoggingConfiguration: added parameter LoggingConfiguration_EnableMediaMetricLog.
  * Amazon CloudWatch RUM
    * Modified cmdlet Update-CWRUMRumMetricDefinition: added parameter MetricDefinition_Namespace.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSScheduledActionList leveraging the ListScheduledActions service API.
    * Added cmdlet Update-OSScheduledAction leveraging the UpdateScheduledAction service API.
    * Modified cmdlet New-OSDomain: added parameters AutoTuneOptions_UseOffPeakWindow, OffPeakWindowOptions_Enabled, SoftwareUpdateOptions_AutoSoftwareUpdateEnabled, WindowStartTime_Hour and WindowStartTime_Minute.
    * Modified cmdlet Start-OSServiceSoftwareUpdate: added parameters DesiredStartTime and ScheduleAt.
    * Modified cmdlet Update-OSDomainConfig: added parameters AutoTuneOptions_UseOffPeakWindow, OffPeakWindowOptions_Enabled, SoftwareUpdateOptions_AutoSoftwareUpdateEnabled, WindowStartTime_Hour and WindowStartTime_Minute.

### 4.1.276 (2023-02-21 22:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.488.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon QuickSight
    * Modified cmdlet New-QSDataSource: added parameter S3Parameters_RoleArn.
    * Modified cmdlet Update-QSDataSource: added parameter S3Parameters_RoleArn.
  * Amazon Resilience Hub
    * Added cmdlet Get-RESHAppInputSourceList leveraging the ListAppInputSources service API.
    * Added cmdlet Get-RESHAppVersion leveraging the DescribeAppVersion service API.
    * Added cmdlet Get-RESHAppVersionAppComponent leveraging the DescribeAppVersionAppComponent service API.
    * Added cmdlet Get-RESHAppVersionAppComponentList leveraging the ListAppVersionAppComponents service API.
    * Added cmdlet Get-RESHAppVersionResource leveraging the DescribeAppVersionResource service API.
    * Added cmdlet New-RESHAppVersionAppComponent leveraging the CreateAppVersionAppComponent service API.
    * Added cmdlet New-RESHAppVersionResource leveraging the CreateAppVersionResource service API.
    * Added cmdlet Remove-RESHAppInputSource leveraging the DeleteAppInputSource service API.
    * Added cmdlet Remove-RESHAppVersionAppComponent leveraging the DeleteAppVersionAppComponent service API.
    * Added cmdlet Remove-RESHAppVersionResource leveraging the DeleteAppVersionResource service API.
    * Added cmdlet Update-RESHAppVersion leveraging the UpdateAppVersion service API.
    * Added cmdlet Update-RESHAppVersionAppComponent leveraging the UpdateAppVersionAppComponent service API.
    * Added cmdlet Update-RESHAppVersionResource leveraging the UpdateAppVersionResource service API.
    * Modified cmdlet Import-RESHResourcesToDraftAppVersion: added parameter ImportStrategy.
  * Amazon Telco Network Builder. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TNB and can be listed using the command 'Get-AWSCmdletName -Service TNB'.

### 4.1.275 (2023-02-20 21:43Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.487.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.274 (2023-02-17 21:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.486.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.273 (2023-02-16 23:18Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.485.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic MapReduce
    * Modified cmdlet Add-EMRInstanceFleet: added parameters OnDemandResizeSpecification_TimeoutDurationMinute and SpotResizeSpecification_TimeoutDurationMinute.
    * Modified cmdlet Edit-EMRInstanceFleet: added parameters OnDemandResizeSpecification_TimeoutDurationMinute and SpotResizeSpecification_TimeoutDurationMinute.
  * Amazon Managed Grafana
    * Modified cmdlet New-MGRFWorkspace: added parameters NetworkAccessControl_PrefixListId and NetworkAccessControl_VpceId.
    * Modified cmdlet Update-MGRFWorkspace: added parameters NetworkAccessControl_PrefixListId, NetworkAccessControl_VpceId and RemoveNetworkAccessConfiguration.

### 4.1.272 (2023-02-15 22:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.484.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Fraud Detector
    * Added cmdlet Get-FDListElement leveraging the GetListElements service API.
    * Added cmdlet Get-FDListsMetadata leveraging the GetListsMetadata service API.
    * Added cmdlet New-FDList leveraging the CreateList service API.
    * Added cmdlet Remove-FDList leveraging the DeleteList service API.
    * Added cmdlet Update-FDList leveraging the UpdateList service API.
  * Amazon Private 5G
    * Added cmdlet Start-PV5GNetworkResourceUpdate leveraging the StartNetworkResourceUpdate service API.

### 4.1.271 (2023-02-14 23:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.483.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppConfig
    * Modified cmdlet Get-APPCHostedConfigurationVersionList: added parameter VersionLabel.
    * Modified cmdlet New-APPCHostedConfigurationVersion: added parameter VersionLabel.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2Host: added parameter HostMaintenance.
    * Modified cmdlet New-EC2Host: added parameter HostMaintenance.

### 4.1.270 (2023-02-13 21:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.482.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Account
    * Added cmdlet Disable-ACCTRegion leveraging the DisableRegion service API.
    * Added cmdlet Enable-ACCTRegion leveraging the EnableRegion service API.
    * Added cmdlet Get-ACCTRegionList leveraging the ListRegions service API.
    * Added cmdlet Get-ACCTRegionOptStatus leveraging the GetRegionOptStatus service API.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWServiceVersion leveraging the ListServiceVersions service API.
    * Modified cmdlet New-SNOWCluster: added parameters EKSOnDeviceService_EKSAnywhereVersion and EKSOnDeviceService_KubernetesVersion.
    * Modified cmdlet New-SNOWJob: added parameters EKSOnDeviceService_EKSAnywhereVersion and EKSOnDeviceService_KubernetesVersion.
    * Modified cmdlet Update-SNOWCluster: added parameters EKSOnDeviceService_EKSAnywhereVersion and EKSOnDeviceService_KubernetesVersion.
    * Modified cmdlet Update-SNOWJob: added parameters EKSOnDeviceService_EKSAnywhereVersion and EKSOnDeviceService_KubernetesVersion.

### 4.1.269 (2023-02-10 21:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.481.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Auto Scaling
    * Added cmdlet Undo-ASInstanceRefresh leveraging the RollbackInstanceRefresh service API.
    * Modified cmdlet Start-ASInstanceRefresh: added parameters Preferences_AutoRollback, Preferences_ScaleInProtectedInstance and Preferences_StandbyInstance.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMAutoMLJob: added parameter CandidateGenerationConfig_AlgorithmsConfig.

### 4.1.268 (2023-02-09 22:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.479.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Containers
    * Modified cmdlet Start-EMRCJobRun: added parameter RetryPolicyConfiguration_MaxAttempt.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2Bot: added parameters BotMember and BotType.
    * Modified cmdlet Update-LMBV2Bot: added parameters BotMember and BotType.

### 4.1.267 (2023-02-08 22:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.478.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.266 (2023-02-07 21:57Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.477.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.265 (2023-02-06 22:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.477.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.264 (2023-02-03 22:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.476.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Proton
    * Added cmdlet Get-PROResourcesSummary leveraging the GetResourcesSummary service API.

### 4.1.263 (2023-02-02 22:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.475.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppConfig
    * Modified cmdlet Start-APPCDeployment: added parameter KmsKeyIdentifier.
  * Amazon QuickSight
    * Modified cmdlet New-QSDashboard: added parameters DataPointDrillUpDownOption_AvailabilityStatus, DataPointMenuLabelOption_AvailabilityStatus, DataPointTooltipOption_AvailabilityStatus, ExportWithHiddenFieldsOption_AvailabilityStatus, SheetLayoutElementMaximizationOption_AvailabilityStatus, VisualAxisSortOption_AvailabilityStatus and VisualMenuOption_AvailabilityStatus.
    * Modified cmdlet Update-QSDashboard: added parameters DataPointDrillUpDownOption_AvailabilityStatus, DataPointMenuLabelOption_AvailabilityStatus, DataPointTooltipOption_AvailabilityStatus, ExportWithHiddenFieldsOption_AvailabilityStatus, SheetLayoutElementMaximizationOption_AvailabilityStatus, VisualAxisSortOption_AvailabilityStatus and VisualMenuOption_AvailabilityStatus.

### 4.1.262 (2023-02-01 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.473.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DevOps Guru
    * Modified cmdlet Get-DGURUAnomaliesForInsightList: added parameter ServiceCollection_ServiceName.
  * Amazon Elemental MediaTailor
    * Added cmdlet Update-EMTProgram leveraging the UpdateProgram service API.
    * Modified cmdlet New-EMTProgram: added parameter ClipRange_EndOffsetMilli.
  * Amazon Forecast Service
    * Modified cmdlet New-FRCDatasetImportJob: added parameter ImportMode.

### 4.1.261 (2023-01-31 22:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.472.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppSync
    * Modified cmdlet New-ASYNDataSource: added parameter EventBridgeConfig_EventBusArn.
    * Modified cmdlet Update-ASYNDataSource: added parameter EventBridgeConfig_EventBusArn.
  * Amazon CloudTrail
    * Added cmdlet Get-CTResourcePolicy leveraging the GetResourcePolicy service API.
    * Added cmdlet New-CTChannel leveraging the CreateChannel service API.
    * Added cmdlet Remove-CTChannel leveraging the DeleteChannel service API.
    * Added cmdlet Remove-CTResourcePolicy leveraging the DeleteResourcePolicy service API.
    * Added cmdlet Update-CTChannel leveraging the UpdateChannel service API.
    * Added cmdlet Write-CTResourcePolicy leveraging the PutResourcePolicy service API.
  * Amazon CloudTrail Data Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CTD and can be listed using the command 'Get-AWSCmdletName -Service CTD'.
  * Amazon CodeArtifact
    * Added cmdlet Remove-CAPackage leveraging the DeletePackage service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Register-EC2NatGatewayAddress leveraging the AssociateNatGatewayAddress service API.
    * Added cmdlet Register-EC2PrivateNatGatewayAddress leveraging the AssignPrivateNatGatewayAddress service API.
    * Added cmdlet Unregister-EC2NatGatewayAddress leveraging the DisassociateNatGatewayAddress service API.
    * Added cmdlet Unregister-EC2PrivateNatGatewayAddress leveraging the UnassignPrivateNatGatewayAddress service API.
    * Modified cmdlet New-EC2NatGateway: added parameters SecondaryAllocationId, SecondaryPrivateIpAddress and SecondaryPrivateIpAddressCount.
  * Amazon Ground Station
    * Added cmdlet Get-GSAgentConfiguration leveraging the GetAgentConfiguration service API.
    * Added cmdlet Register-GSAgent leveraging the RegisterAgent service API.
    * Added cmdlet Update-GSAgentStatus leveraging the UpdateAgentStatus service API.
    * Modified cmdlet New-GSMissionProfile: added parameters StreamsKmsKey_KmsAliasArn, StreamsKmsKey_KmsKeyArn and StreamsKmsRole.
    * Modified cmdlet Update-GSMissionProfile: added parameters StreamsKmsKey_KmsAliasArn, StreamsKmsKey_KmsKeyArn and StreamsKmsRole.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameter CloudwatchLogs_BatchMode.
    * Modified cmdlet Set-IOTTopicRule: added parameter CloudwatchLogs_BatchMode.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSOutboundConnection: added parameter ConnectionMode.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameters BestObjectiveNotImproving_MaxNumberOfTrainingJobsNotImproving, ConvergenceDetected_CompleteOnConvergence and ResourceLimits_MaxRuntimeInSecond.

### 4.1.260 (2023-01-30 22:10Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.471.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2LocalGatewayRoute: added parameter DestinationPrefixListId.
    * Modified cmdlet New-EC2LocalGatewayRoute: added parameter DestinationPrefixListId.
    * Modified cmdlet Remove-EC2LocalGatewayRoute: added parameter DestinationPrefixListId.

### 4.1.259 (2023-01-27 22:03Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.470.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elemental MediaTailor
    * Added cmdlet Add-EMTLogsForChannel leveraging the ConfigureLogsForChannel service API.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpointAsync: added parameter InvocationTimeoutSecond.

### 4.1.258 (2023-01-26 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.469.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.257 (2023-01-25 22:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.468.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Edit-EC2IpamResourceDiscovery leveraging the ModifyIpamResourceDiscovery service API.
    * Added cmdlet Get-EC2IpamDiscoveredAccount leveraging the GetIpamDiscoveredAccounts service API.
    * Added cmdlet Get-EC2IpamDiscoveredResourceCidr leveraging the GetIpamDiscoveredResourceCidrs service API.
    * Added cmdlet Get-EC2IpamResourceDiscovery leveraging the DescribeIpamResourceDiscoveries service API.
    * Added cmdlet Get-EC2IpamResourceDiscoveryAssociation leveraging the DescribeIpamResourceDiscoveryAssociations service API.
    * Added cmdlet New-EC2IpamResourceDiscovery leveraging the CreateIpamResourceDiscovery service API.
    * Added cmdlet Register-EC2IpamResourceDiscovery leveraging the AssociateIpamResourceDiscovery service API.
    * Added cmdlet Remove-EC2IpamResourceDiscovery leveraging the DeleteIpamResourceDiscovery service API.
    * Added cmdlet Unregister-EC2IpamResourceDiscovery leveraging the DisassociateIpamResourceDiscovery service API.
    * Modified cmdlet New-EC2IpamPool: added parameter PublicIpSource.
    * Modified cmdlet Register-EC2IpamPoolCidr: added parameters ClientToken and NetmaskLength.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMInferenceRecommendationsJob: added parameters ContainerConfig_DataInputConfig and InputConfig_ModelName.

### 4.1.256 (2023-01-24 22:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.467.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Systems Manager for SAP
    * Added cmdlet Get-SMSAPOperationList leveraging the ListOperations service API.
    * Modified cmdlet Get-SMSAPApplication: added parameter AppRegistryArn.

### 4.1.255 (2023-01-23 22:07Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.466.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Lambda
    * Added cmdlet Get-LMRuntimeManagementConfig leveraging the GetRuntimeManagementConfig service API.
    * Added cmdlet Write-LMRuntimeManagementConfig leveraging the PutRuntimeManagementConfig service API.

### 4.1.254 (2023-01-20 22:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.465.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.253 (2023-01-20 02:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.464.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Appflow
    * Modified cmdlet New-AFFlow: added parameter Pardot_Object.
    * Modified cmdlet Update-AFFlow: added parameter Pardot_Object.
  * Amazon Connect Service
    * Modified cmdlet Start-CONNChatContact: added parameters PersistentChat_RehydrationType and PersistentChat_SourceContactId.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet New-EC2LaunchTemplateVersion: added parameter ResolveAlias.
    * Modified cmdlet Get-EC2TemplateVersion: added parameter ResolveAlias.
  * Amazon Ground Station
    * Modified cmdlet New-GSDataflowEndpointGroup: added parameters ContactPostPassDurationSecond and ContactPrePassDurationSecond.
  * Amazon OpenSearch Service
    * Added cmdlet Get-OSDryRunProgress leveraging the DescribeDryRunProgress service API.
    * Modified cmdlet Update-OSDomainConfig: added parameter DryRunMode.
  * Amazon Panorama
    * Modified cmdlet New-PANJobForDevice: added parameter OTAJobConfig_AllowMajorVersionUpdate.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameter TrainingJobDefinition_Environment.

### 4.1.252 (2023-01-18 22:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.463.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch
    * Modified cmdlet Write-CWMetricStream: added parameter IncludeLinkedAccountsMetric.

### 4.1.251 (2023-01-17 21:51Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.462.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSBillingConductor
    * Modified cmdlet New-ABCPricingRule: added parameters Operation and UsageType.

### 4.1.250 (2023-01-13 22:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.461.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Resource Groups
    * Added cmdlet Get-RGAccountSetting leveraging the GetAccountSettings service API.
    * Added cmdlet Update-RGAccountSetting leveraging the UpdateAccountSettings service API.

### 4.1.249 (2023-01-12 22:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.460.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CRS and can be listed using the command 'Get-AWSCmdletName -Service CRS'.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter ScalingConfig_MaximumConcurrency.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter ScalingConfig_MaximumConcurrency.

### 4.1.248 (2023-01-11 21:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.459.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.247 (2023-01-10 21:56Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.458.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter AllocatedStorage.
    * Modified cmdlet Restore-RDSDBInstanceFromDBSnapshot: added parameter AllocatedStorage.
    * Modified cmdlet Restore-RDSDBInstanceToPointInTime: added parameter AllocatedStorage.

### 4.1.246 (2023-01-09 22:26Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.457.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Kendra Intelligent Ranking. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KNRK and can be listed using the command 'Get-AWSCmdletName -Service KNRK'.
  * Amazon WorkSpaces Web
    * Modified cmdlet New-WSWPortal: added parameter AuthenticationType.
    * Modified cmdlet Update-WSWPortal: added parameter AuthenticationType.

### 4.1.245 (2023-01-06 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.456.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Audit Manager
    * Modified cmdlet Edit-AUDMSetting: added parameter DeregistrationPolicy_DeleteResource.

### 4.1.244 (2023-01-05 21:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.455.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon App Runner
    * Modified cmdlet New-AARService: added parameters CodeConfigurationValues_RuntimeEnvironmentSecret and ImageConfiguration_RuntimeEnvironmentSecret.
    * Modified cmdlet Update-AARService: added parameters CodeConfigurationValues_RuntimeEnvironmentSecret and ImageConfiguration_RuntimeEnvironmentSecret.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameters ImageConfiguration_ImageUri and WorkerTypeSpecification.
    * Modified cmdlet Update-EMRServerlessApplication: added parameters ImageConfiguration_ImageUri and WorkerTypeSpecification.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBInstance: added parameter CACertificateIdentifier.

### 4.1.243 (2023-01-04 21:46Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.454.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Application Auto Scaling
    * Modified cmdlet Get-AASScalingActivity: added parameter IncludeNotScaledActivity.

### 4.1.242 (2023-01-03 21:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.453.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
