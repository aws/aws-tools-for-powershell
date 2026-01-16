### 4.1.981 (2026-01-16 21:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1204.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
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

### 4.1.980 (2026-01-15 21:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1203.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
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

### 4.1.979 (2026-01-14 21:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1202.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
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

### 4.1.978 (2026-01-13 21:01Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1201.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Get-DZSubscriptionGrantList: added parameter OwningIamPrincipalArn.
    * Modified cmdlet Get-DZSubscriptionList: added parameter OwningIamPrincipalArn.
    * Modified cmdlet Get-DZSubscriptionRequestList: added parameter OwningIamPrincipalArn.
    * Modified cmdlet New-DZSubscriptionTarget: added parameter SubscriptionGrantCreationMode.
    * Modified cmdlet Update-DZSubscriptionTarget: added parameter SubscriptionGrantCreationMode.

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

