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

