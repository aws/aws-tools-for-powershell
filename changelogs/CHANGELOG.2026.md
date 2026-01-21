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

