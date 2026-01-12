### 4.1.977 (2026-01-12 21:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1200.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Billing
    * Modified cmdlet New-AWSBBillingView: added parameters DataFilterExpression_CostCategories_Key and DataFilterExpression_CostCategories_Value.
    * Modified cmdlet Update-AWSBBillingView: added parameters DataFilterExpression_CostCategories_Key and DataFilterExpression_CostCategories_Value.
  * Amazon Managed integrations for AWS IoT Device Management
    * Modified cmdlet New-IOTMIManagedThing: added parameters WiFiSimpleSetupConfiguration_EnableAsProvisionee, WiFiSimpleSetupConfiguration_EnableAsProvisioner and WiFiSimpleSetupConfiguration_TimeoutInMinute.
    * Modified cmdlet Start-IOTMIDeviceDiscovery: added parameters EndDeviceIdentifier and Protocol.
    * Modified cmdlet Update-IOTMIManagedThing: added parameters WiFiSimpleSetupConfiguration_EnableAsProvisionee, WiFiSimpleSetupConfiguration_EnableAsProvisioner and WiFiSimpleSetupConfiguration_TimeoutInMinute.

### 4.1.976 (2026-01-09 21:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1199.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer
    * Modified cmdlet Get-BACCMemory: added parameter View.
  * Amazon Glue
    * Added cmdlet Get-GLUEMaterializedViewRefreshTaskRun leveraging the GetMaterializedViewRefreshTaskRun service API.
    * Added cmdlet Get-GLUEMaterializedViewRefreshTaskRunList leveraging the ListMaterializedViewRefreshTaskRuns service API.
    * Added cmdlet Start-GLUEMaterializedViewRefreshTaskRun leveraging the StartMaterializedViewRefreshTaskRun service API.
    * Added cmdlet Stop-GLUEMaterializedViewRefreshTaskRun leveraging the StopMaterializedViewRefreshTaskRun service API.

### 4.1.975 (2026-01-07 21:05Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1198.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.974 (2026-01-06 21:15Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1197.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameters DiskEncryptionConfiguration_EncryptionContext and DiskEncryptionConfiguration_EncryptionKeyArn.
    * Modified cmdlet Start-EMRServerlessJobRun: added parameters ConfigurationOverrides_DiskEncryptionConfiguration_EncryptionContext and ConfigurationOverrides_DiskEncryptionConfiguration_EncryptionKeyArn.
    * Modified cmdlet Update-EMRServerlessApplication: added parameters DiskEncryptionConfiguration_EncryptionContext and DiskEncryptionConfiguration_EncryptionKeyArn.

### 4.1.973 (2026-01-05 21:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1196.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CleanRoomsML
    * Modified cmdlet New-CRMLMLInputChannel: added parameter InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark.
    * Modified cmdlet Start-CRMLAudienceGenerationJob: added parameter SeedAudience_SqlComputeConfiguration_Worker_Properties_Spark.

### 4.1.972 (2026-01-02 21:08Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1195.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Clean Rooms Service
    * Modified cmdlet New-CRSCollaboration: added parameter IsMetricsEnabled.
    * Modified cmdlet New-CRSMembership: added parameter IsMetricsEnabled.
  * Amazon Identity Store
    * Modified cmdlet New-IDSUser: added parameter Role.

