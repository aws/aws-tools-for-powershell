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

