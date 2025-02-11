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

