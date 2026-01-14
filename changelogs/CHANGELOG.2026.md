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

