﻿### 5.0.19 (2025-07-25 19:59Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.56.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AppIntegrations Service
    * Modified cmdlet New-AISApplication: added parameters ContactHandling_Scope, IframeConfig_Allow, IframeConfig_Sandbox, InitializationTimeout and IsService.
    * Modified cmdlet Update-AISApplication: added parameters ContactHandling_Scope, IframeConfig_Allow, IframeConfig_Sandbox, InitializationTimeout and IsService.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2Channel: added parameter InputSwitchConfiguration_PreferredInput.
    * Modified cmdlet Update-MPV2Channel: added parameter InputSwitchConfiguration_PreferredInput.
  * Amazon End User Messaging Social
    * Added cmdlet Get-SOCIALWhatsAppMessageTemplate leveraging the GetWhatsAppMessageTemplate service API.
    * Added cmdlet Get-SOCIALWhatsAppMessageTemplateList leveraging the ListWhatsAppMessageTemplates service API.
    * Added cmdlet Get-SOCIALWhatsAppTemplateLibraryList leveraging the ListWhatsAppTemplateLibrary service API.
    * Added cmdlet New-SOCIALWhatsAppMessageTemplate leveraging the CreateWhatsAppMessageTemplate service API.
    * Added cmdlet New-SOCIALWhatsAppMessageTemplateFromLibrary leveraging the CreateWhatsAppMessageTemplateFromLibrary service API.
    * Added cmdlet New-SOCIALWhatsAppMessageTemplateMedia leveraging the CreateWhatsAppMessageTemplateMedia service API.
    * Added cmdlet Remove-SOCIALWhatsAppMessageTemplate leveraging the DeleteWhatsAppMessageTemplate service API.
    * Added cmdlet Update-SOCIALWhatsAppMessageTemplate leveraging the UpdateWhatsAppMessageTemplate service API.
    * Modified cmdlet Connect-SOCIALWhatsAppBusinessAccount: added parameter SignupCallback_CallbackUrl.

### 5.0.18 (2025-07-24 19:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.55.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon DataZone
    * Modified cmdlet Search-DZListing: added parameter Aggregation.
  * Amazon Omics
    * Modified cmdlet New-OMICSWorkflow: added parameters DefinitionRepository_ConnectionArn, DefinitionRepository_ExcludeFilePattern, DefinitionRepository_FullRepositoryId, ParameterTemplatePath, ReadmeMarkdown, ReadmePath, ReadmeUri, SourceReference_Type, SourceReference_Value and WorkflowBucketOwnerId.
    * Modified cmdlet New-OMICSWorkflowVersion: added parameters DefinitionRepository_ConnectionArn, DefinitionRepository_ExcludeFilePattern, DefinitionRepository_FullRepositoryId, ParameterTemplatePath, ReadmeMarkdown, ReadmePath, ReadmeUri, SourceReference_Type and SourceReference_Value.
    * Modified cmdlet Update-OMICSWorkflow: added parameter ReadmeMarkdown.
    * Modified cmdlet Update-OMICSWorkflowVersion: added parameter ReadmeMarkdown.

### 5.0.17 (2025-07-23 20:02Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.54.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Stop-EC2Instance: added parameter SkipOsShutdown.
    * Modified cmdlet Remove-EC2Instance: added parameter SkipOsShutdown.
  * Amazon Glue
    * Modified cmdlet Start-GLUEJobRun: added parameter ExecutionRoleSessionPolicy.

### 5.0.16 (2025-07-22 19:55Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.53.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EC2 Container Registry
    * Modified cmdlet New-ECRRepository: added parameter ImageTagMutabilityExclusionFilter.
    * Modified cmdlet New-ECRRepositoryCreationTemplate: added parameter ImageTagMutabilityExclusionFilter.
    * Modified cmdlet Update-ECRRepositoryCreationTemplate: added parameter ImageTagMutabilityExclusionFilter.
    * Modified cmdlet Write-ECRImageTagMutability: added parameter ImageTagMutabilityExclusionFilter.
  * Amazon Elastic MapReduce
    * Modified cmdlet Edit-EMRCluster: added parameter ExtendedSupport.
    * Modified cmdlet Start-EMRJobFlow: added parameter ExtendedSupport.

### 5.0.15 (2025-07-21 20:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.52.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameter VpcConfiguration_ResourceConfigurationArn.
    * Modified cmdlet Update-ADCFleet: added parameter VpcConfiguration_ResourceConfigurationArn.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMWorkforce: added parameter IpAddressType.
    * Modified cmdlet Update-SMWorkforce: added parameter IpAddressType.

### 5.0.14 (2025-07-18 20:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.51.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Logs
    * Added cmdlet Get-CWLLogObject leveraging the GetLogObject service API.
  * Amazon Outposts
    * Added cmdlet Get-OUTPOutpostBillingInformation leveraging the GetOutpostBillingInformation service API.

### 5.0.13 (2025-07-17 19:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.50.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CleanRoomsML
    * Modified cmdlet New-CRMLMLInputChannel: added parameter ProtectedQueryInputParameters_ResultFormat.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter Code_Dependency.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameter Code_Dependency.
    * Modified cmdlet Update-CWSYNCanary: added parameter Code_Dependency.

### 5.0.12 (2025-07-16 17:19Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.49.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet Get-BDRCustomModelDeployment leveraging the GetCustomModelDeployment service API.
    * Added cmdlet Get-BDRCustomModelDeploymentList leveraging the ListCustomModelDeployments service API.
    * Added cmdlet New-BDRCustomModelDeployment leveraging the CreateCustomModelDeployment service API.
    * Added cmdlet Remove-BDRCustomModelDeployment leveraging the DeleteCustomModelDeployment service API.
  * Amazon Bedrock Agent Core Control Plane Fronting Layer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BACC and can be listed using the command 'Get-AWSCmdletName -Service BACC'.
  * Amazon Bedrock AgentCore Data Plane Fronting Layer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix BAC and can be listed using the command 'Get-AWSCmdletName -Service BAC'.
  * Amazon CloudWatch Logs
    * Modified cmdlet Get-CWLResourcePolicy: added parameters PolicyScope and ResourceArn.
    * Modified cmdlet Remove-CWLResourcePolicy: added parameters ExpectedRevisionId and ResourceArn.
    * Modified cmdlet Write-CWLDeliveryDestination: added parameter DeliveryDestinationType.
    * Modified cmdlet Write-CWLResourcePolicy: added parameters ExpectedRevisionId and ResourceArn.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet Write-MPV2OriginEndpointPolicy: added parameters CdnAuthConfiguration_CdnIdentifierSecretArn and CdnAuthConfiguration_SecretsRoleArn.
  * Amazon GuardDuty
    * Modified cmdlet New-GDIPSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet New-GDThreatIntelSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet Update-GDIPSet: added parameter ExpectedBucketOwner.
    * Modified cmdlet Update-GDThreatIntelSet: added parameter ExpectedBucketOwner.

### 5.0.11 (2025-07-16 02:34Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.48.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.

### 5.0.10 (2025-07-15 20:27Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.47.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet New-AABKnowledgeBase: added parameters S3VectorsConfiguration_IndexArn, S3VectorsConfiguration_IndexName and S3VectorsConfiguration_VectorBucketArn.
    * Modified cmdlet Update-AABKnowledgeBase: added parameters S3VectorsConfiguration_IndexArn, S3VectorsConfiguration_IndexName and S3VectorsConfiguration_VectorBucketArn.
  * Amazon DataZone
    * Modified cmdlet New-DZConnection: added parameters S3Properties_S3AccessGrantLocationId and S3Properties_S3Uri.
    * Modified cmdlet Update-DZConnection: added parameters S3Properties_S3AccessGrantLocationId and S3Properties_S3Uri.
  * Amazon DynamoDB Streams
    * Modified cmdlet Get-DDBSStream: added parameters ShardFilter_ShardId and ShardFilter_Type.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSService: added parameters DeploymentConfiguration_BakeTimeInMinute, DeploymentConfiguration_LifecycleHook and DeploymentConfiguration_Strategy.
    * Modified cmdlet Update-ECSService: added parameters DeploymentConfiguration_BakeTimeInMinute, DeploymentConfiguration_LifecycleHook, DeploymentConfiguration_Strategy and DeploymentController_Type.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2InstanceConnectEndpoint: added parameter IpAddressType.
  * Amazon EventBridge
    * Modified cmdlet New-EVBEventBus: added parameters LogConfig_IncludeDetail and LogConfig_Level.
    * Modified cmdlet Update-EVBEventBus: added parameters LogConfig_IncludeDetail and LogConfig_Level.
  * Amazon OpenSearch Service
    * Modified cmdlet New-OSDomain: added parameter S3VectorsEngine_Enabled.
    * Modified cmdlet Update-OSDomainConfig: added parameter S3VectorsEngine_Enabled.
  * Amazon QuickSight
    * Modified cmdlet New-QSTopic: added parameter CustomInstructions_CustomInstructionsString.
    * Modified cmdlet Update-QSTopic: added parameter CustomInstructions_CustomInstructionsString.
  * Amazon re:Post Private
    * Added cmdlet Add-RESPBatchChannelRoleToAccessor leveraging the BatchAddChannelRoleToAccessors service API.
    * Added cmdlet Get-RESPChannel leveraging the GetChannel service API.
    * Added cmdlet Get-RESPChannelList leveraging the ListChannels service API.
    * Added cmdlet New-RESPChannel leveraging the CreateChannel service API.
    * Added cmdlet Remove-RESPBatchChannelRoleFromAccessor leveraging the BatchRemoveChannelRoleFromAccessors service API.
    * Added cmdlet Update-RESPChannel leveraging the UpdateChannel service API.
    * Modified cmdlet New-RESPSpace: added parameters SupportedEmailDomains_AllowedDomain and SupportedEmailDomains_Enabled.
    * Modified cmdlet Update-RESPSpace: added parameters SupportedEmailDomains_AllowedDomain and SupportedEmailDomains_Enabled.
  * Amazon S3 Tables
    * Modified cmdlet Get-S3TTableBucketList: added parameter Type.
  * Amazon S3 Vectors. Added cmdlets to support the service. Cmdlets for the service have the noun prefix S3V and can be listed using the command 'Get-AWSCmdletName -Service S3V'.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMPipelineVersionList leveraging the ListPipelineVersions service API.
    * Added cmdlet Update-SMPipelineVersion leveraging the UpdatePipelineVersion service API.
    * Modified cmdlet Get-SMPipeline: added parameter PipelineVersionId.
    * Modified cmdlet New-SMCluster: added parameter RestrictedInstanceGroup.
    * Modified cmdlet Start-SMPipelineExecution: added parameter PipelineVersionId.
    * Modified cmdlet Update-SMCluster: added parameter RestrictedInstanceGroup.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Get-S3BucketMetadataConfiguration leveraging the GetBucketMetadataConfiguration service API.
    * Added cmdlet Get-S3HeadBucket leveraging the HeadBucket service API.
    * Added cmdlet New-S3BucketMetadataConfiguration leveraging the CreateBucketMetadataConfiguration service API.
    * Added cmdlet Remove-S3BucketMetadataConfiguration leveraging the DeleteBucketMetadataConfiguration service API.
    * Added cmdlet Update-S3BucketMetadataInventoryTableConfiguration leveraging the UpdateBucketMetadataInventoryTableConfiguration service API.
    * Added cmdlet Update-S3BucketMetadataJournalTableConfiguration leveraging the UpdateBucketMetadataJournalTableConfiguration service API.
  * Enabled support for generating Get-S3HeadBucket CmdLet corresponding to S3 HeadBucket service API operation.

### 5.0.9 (2025-07-09 20:22Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.46.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2CapacityBlock leveraging the DescribeCapacityBlocks service API.
    * Added cmdlet Get-EC2CapacityBlockStatus leveraging the DescribeCapacityBlockStatus service API.
    * Modified cmdlet Get-EC2CapacityBlockOffering: added parameters UltraserverCount and UltraserverType.
  * Amazon Free Tier
    * Added cmdlet Get-FTAccountActivity leveraging the GetAccountActivity service API.
    * Added cmdlet Get-FTAccountActivityList leveraging the ListAccountActivities service API.
    * Added cmdlet Get-FTAccountPlanState leveraging the GetAccountPlanState service API.
    * Added cmdlet Set-FTAccountPlan leveraging the UpgradeAccountPlan service API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3ObjectTagSet: added parameter ContentMD5.

### 5.0.8 (2025-07-03 20:04Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.45.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFUploadJob leveraging the GetUploadJob service API.
    * Added cmdlet Get-CPFUploadJobList leveraging the ListUploadJobs service API.
    * Added cmdlet Get-CPFUploadJobPath leveraging the GetUploadJobPath service API.
    * Added cmdlet New-CPFUploadJob leveraging the CreateUploadJob service API.
    * Added cmdlet Start-CPFUploadJob leveraging the StartUploadJob service API.
    * Added cmdlet Stop-CPFUploadJob leveraging the StopUploadJob service API.
  * Amazon Elemental MediaPackage v2
    * Modified cmdlet New-MPV2OriginEndpoint: added parameters Encryption_CmafExcludeSegmentDrmMetadata, EncryptionMethod_IsmEncryptionMethod and MssManifest.
    * Modified cmdlet Update-MPV2OriginEndpoint: added parameters Encryption_CmafExcludeSegmentDrmMetadata, EncryptionMethod_IsmEncryptionMethod and MssManifest.
  * Amazon SageMaker Service
    * Added cmdlet New-SMHubContentPresignedUrl leveraging the CreateHubContentPresignedUrls service API.
    * Added cmdlet Start-SMSession leveraging the StartSession service API.
    * Modified cmdlet New-SMSpace: added parameter SpaceSettings_RemoteAccess.
    * Modified cmdlet Update-SMSpace: added parameter SpaceSettings_RemoteAccess.

### 5.0.7 (2025-07-02 19:45Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.44.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Cases
    * Added cmdlet Remove-CCASCase leveraging the DeleteCase service API.
    * Added cmdlet Remove-CCASRelatedItem leveraging the DeleteRelatedItem service API.

### 5.0.6 (2025-07-01 22:28Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.43.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CleanRoomsML
    * Added cmdlet Get-CRMLTrainedModelVersionList leveraging the ListTrainedModelVersions service API.
    * Modified cmdlet Get-CRMLCollaborationTrainedModel: added parameter VersionIdentifier.
    * Modified cmdlet Get-CRMLCollaborationTrainedModelExportJobList: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Get-CRMLCollaborationTrainedModelInferenceJobList: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Get-CRMLTrainedModel: added parameter VersionIdentifier.
    * Modified cmdlet Get-CRMLTrainedModelInferenceJobList: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet New-CRMLConfiguredModelAlgorithmAssociation: added parameters MaxArtifactSize_Unit and MaxArtifactSize_Value.
    * Modified cmdlet New-CRMLTrainedModel: added parameters IncrementalTrainingDataChannel and TrainingInputMode.
    * Modified cmdlet Remove-CRMLTrainedModelOutput: added parameter VersionIdentifier.
    * Modified cmdlet Start-CRMLTrainedModelExportJob: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Start-CRMLTrainedModelInferenceJob: added parameter TrainedModelVersionIdentifier.
    * Modified cmdlet Stop-CRMLTrainedModel: added parameter VersionIdentifier.
  * Amazon DataZone
    * Modified cmdlet Update-DZProject: added parameter DomainUnitId.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Get-EC2InstanceTypesFromInstanceRequirement: added parameter Context.
  * Amazon Oracle Database@Amazon Web Services. Added cmdlets to support the service. Cmdlets for the service have the noun prefix ODB and can be listed using the command 'Get-AWSCmdletName -Service ODB'.
  * Amazon QBusiness
    * Added cmdlet Get-QBUSChatResponseConfiguration leveraging the GetChatResponseConfiguration service API.
    * Added cmdlet Get-QBUSChatResponseConfigurationList leveraging the ListChatResponseConfigurations service API.
    * Added cmdlet New-QBUSChatResponseConfiguration leveraging the CreateChatResponseConfiguration service API.
    * Added cmdlet Remove-QBUSChatResponseConfiguration leveraging the DeleteChatResponseConfiguration service API.
    * Added cmdlet Update-QBUSChatResponseConfiguration leveraging the UpdateChatResponseConfiguration service API.
    * Modified cmdlet New-QBUSRetriever: added parameter NativeIndexConfiguration_Version.
    * Modified cmdlet Update-QBUSRetriever: added parameter NativeIndexConfiguration_Version.

### 5.0.5 (2025-06-30 20:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.42.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon ARC - Zonal Shift
    * Added cmdlet Start-AZSPracticeRun leveraging the StartPracticeRun service API.
    * Added cmdlet Stop-AZSPracticeRun leveraging the CancelPracticeRun service API.
  * Amazon B2B Data Interchange
    * Modified cmdlet New-B2BIPartnership: added parameters AcknowledgmentOptions_FunctionalAcknowledgment, AcknowledgmentOptions_TechnicalAcknowledgment, Common_Gs05TimeFormat, ControlNumbers_StartingFunctionalGroupControlNumber, ControlNumbers_StartingInterchangeControlNumber, ControlNumbers_StartingTransactionSetControlNumber, WrapOptions_LineLength, WrapOptions_LineTerminator and WrapOptions_WrapBy.
    * Modified cmdlet New-B2BITransformer: added parameter SplitOptions_SplitBy.
    * Modified cmdlet Test-B2BIParsing: added parameter SplitOptions_SplitBy.
    * Modified cmdlet Update-B2BIPartnership: added parameters AcknowledgmentOptions_FunctionalAcknowledgment, AcknowledgmentOptions_TechnicalAcknowledgment, Common_Gs05TimeFormat, ControlNumbers_StartingFunctionalGroupControlNumber, ControlNumbers_StartingInterchangeControlNumber, ControlNumbers_StartingTransactionSetControlNumber, WrapOptions_LineLength, WrapOptions_LineTerminator and WrapOptions_WrapBy.
    * Modified cmdlet Update-B2BITransformer: added parameter SplitOptions_SplitBy.
  * Amazon DynamoDB
    * Modified cmdlet Update-DDBTable: added parameter GlobalTableWitnessUpdate.
  * Amazon Glue
    * Modified cmdlet New-GLUEIntegration: added parameter IntegrationConfig_SourceProperty.
  * Amazon Identity and Access Management
    * Modified cmdlet Get-IAMServiceSpecificCredentialList: added parameters AllUser, Marker, MaxItem and NoAutoIteration.
    * Modified cmdlet New-IAMServiceSpecificCredential: added parameter CredentialAgeDay.
  * Amazon Medical Imaging Service
    * Modified cmdlet Copy-MISImageSet: added parameter PromoteToPrimary.
  * Amazon QuickSight
    * Modified cmdlet New-QSCustomPermission: added parameters Capabilities_ExportToCsvInScheduledReport, Capabilities_ExportToExcelInScheduledReport, Capabilities_ExportToPdf, Capabilities_ExportToPdfInScheduledReport, Capabilities_IncludeContentInScheduledReportsEmail and Capabilities_PrintReport.
    * Modified cmdlet New-QSDataSource: added parameter DataSourceParameters_AthenaParameters_IdentityCenterConfiguration_EnableIdentityPropagation.
    * Modified cmdlet Update-QSCustomPermission: added parameters Capabilities_ExportToCsvInScheduledReport, Capabilities_ExportToExcelInScheduledReport, Capabilities_ExportToPdf, Capabilities_ExportToPdfInScheduledReport, Capabilities_IncludeContentInScheduledReportsEmail and Capabilities_PrintReport.
    * Modified cmdlet Update-QSDataSource: added parameter DataSourceParameters_AthenaParameters_IdentityCenterConfiguration_EnableIdentityPropagation.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter IpAddressType.
    * Modified cmdlet Update-TFRServer: added parameter IpAddressType.

### 5.0.4 (2025-06-27 22:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.41.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Glue
    * Modified cmdlet New-GLUECatalog: added parameter FederatedCatalog_ConnectionType.
    * Modified cmdlet New-GLUETable: added parameters CreateIcebergTableInput_Location, CreateIcebergTableInput_Property, Name, PartitionSpec_Field, PartitionSpec_SpecId, Schema_Field, Schema_IdentifierFieldId, Schema_SchemaId, Schema_Type, WriteOrder_Field and WriteOrder_OrderId.
    * Modified cmdlet Update-GLUECatalog: added parameter FederatedCatalog_ConnectionType.
    * Modified cmdlet Update-GLUETable: added parameters Name and UpdateIcebergTableInput_Update.

### 5.0.3 (2025-06-26 20:25Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.40.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2Route: added parameter OdbNetworkArn.
    * Modified cmdlet Set-EC2Route: added parameter OdbNetworkArn.
  * Amazon Keyspaces
    * Modified cmdlet New-KSTable: added parameters CdcSpecification_PropagateTag, CdcSpecification_Status, CdcSpecification_Tag and CdcSpecification_ViewType.
    * Modified cmdlet Update-KSTable: added parameters CdcSpecification_PropagateTag, CdcSpecification_Status, CdcSpecification_Tag and CdcSpecification_ViewType.
  * Amazon Keyspaces Streams. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KST and can be listed using the command 'Get-AWSCmdletName -Service KST'.
  * Amazon Managed integrations for AWS IoT Device Management
    * Added cmdlet Add-IOTMIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-IOTMIAccountAssociation leveraging the GetAccountAssociation service API.
    * Added cmdlet Get-IOTMIAccountAssociationList leveraging the ListAccountAssociations service API.
    * Added cmdlet Get-IOTMICloudConnector leveraging the GetCloudConnector service API.
    * Added cmdlet Get-IOTMICloudConnectorList leveraging the ListCloudConnectors service API.
    * Added cmdlet Get-IOTMIConnectorDestination leveraging the GetConnectorDestination service API.
    * Added cmdlet Get-IOTMIConnectorDestinationList leveraging the ListConnectorDestinations service API.
    * Added cmdlet Get-IOTMIDeviceDiscoveryList leveraging the ListDeviceDiscoveries service API.
    * Added cmdlet Get-IOTMIDiscoveredDeviceList leveraging the ListDiscoveredDevices service API.
    * Added cmdlet Get-IOTMIManagedThingAccountAssociationList leveraging the ListManagedThingAccountAssociations service API.
    * Added cmdlet Get-IOTMIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-IOTMIAccountAssociation leveraging the CreateAccountAssociation service API.
    * Added cmdlet New-IOTMICloudConnector leveraging the CreateCloudConnector service API.
    * Added cmdlet New-IOTMIConnectorDestination leveraging the CreateConnectorDestination service API.
    * Added cmdlet Register-IOTMIAccountAssociation leveraging the RegisterAccountAssociation service API.
    * Added cmdlet Remove-IOTMIAccountAssociation leveraging the DeleteAccountAssociation service API.
    * Added cmdlet Remove-IOTMICloudConnector leveraging the DeleteCloudConnector service API.
    * Added cmdlet Remove-IOTMIConnectorDestination leveraging the DeleteConnectorDestination service API.
    * Added cmdlet Remove-IOTMIResourceTag leveraging the UntagResource service API.
    * Added cmdlet Send-IOTMIConnectorEvent leveraging the SendConnectorEvent service API.
    * Added cmdlet Start-IOTMIAccountAssociationRefresh leveraging the StartAccountAssociationRefresh service API.
    * Added cmdlet Unregister-IOTMIAccountAssociation leveraging the DeregisterAccountAssociation service API.
    * Added cmdlet Update-IOTMIAccountAssociation leveraging the UpdateAccountAssociation service API.
    * Added cmdlet Update-IOTMICloudConnector leveraging the UpdateCloudConnector service API.
    * Added cmdlet Update-IOTMIConnectorDestination leveraging the UpdateConnectorDestination service API.
    * Modified cmdlet Get-IOTMIManagedThingList: added parameters ConnectorDestinationIdFilter and ConnectorDeviceIdFilter.
    * Modified cmdlet New-IOTMIManagedThing: added parameter CapabilitySchema.
    * Modified cmdlet Send-IOTMIManagedThingCommand: added parameter AccountAssociationId.
    * Modified cmdlet Start-IOTMIDeviceDiscovery: added parameters AccountAssociationId and CustomProtocolDetail.
    * Modified cmdlet Update-IOTMIManagedThing: added parameter CapabilitySchema.
  * Amazon QBusiness
    * Modified cmdlet Add-QBUSPermission: added parameter Condition.
    * Modified cmdlet New-QBUSDataAccessor: added parameters AuthenticationDetail_AuthenticationType, AuthenticationDetail_ExternalId and IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn.
    * Modified cmdlet Update-QBUSDataAccessor: added parameters AuthenticationDetail_AuthenticationType, AuthenticationDetail_ExternalId and IdcTrustedTokenIssuerConfiguration_IdcTrustedTokenIssuerArn.
  * Amazon WorkSpaces
    * Modified cmdlet Edit-WKSWorkspaceAccessProperty: added parameters AccessEndpointConfig_AccessEndpoint and AccessEndpointConfig_InternetFallbackProtocol.

### 5.0.2 (2025-06-25 20:14Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.39.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon FSx
    * Added cmdlet Dismount-FSXAndDeleteS3AccessPoint leveraging the DetachAndDeleteS3AccessPoint service API.
    * Added cmdlet Get-FSXS3AccessPointAttachment leveraging the DescribeS3AccessPointAttachments service API.
    * Added cmdlet New-FSXAndAttachS3AccessPoint leveraging the CreateAndAttachS3AccessPoint service API.
  * Amazon S3 Control
    * Modified cmdlet Get-S3CAccessPointList: added parameters DataSourceId and DataSourceType.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Get-S3BucketIntelligentTieringConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Get-S3BucketIntelligentTieringConfigurationList: added parameter ExpectedBucketOwner.
    * Modified cmdlet Remove-S3BucketIntelligentTieringConfiguration: added parameter ExpectedBucketOwner.
    * Modified cmdlet Write-S3BucketIntelligentTieringConfiguration: added parameter ExpectedBucketOwner.

### 5.0.1 (2025-06-24 20:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.38.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AI Ops
    * Modified cmdlet New-AIOpsInvestigationGroup: added parameter CrossAccountConfiguration.
    * Modified cmdlet Update-AIOpsInvestigationGroup: added parameter CrossAccountConfiguration.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter LaunchTemplate_UserdataType.
    * Modified cmdlet Update-BATComputeEnvironment: added parameter LaunchTemplate_UserdataType.
  * Amazon Bedrock
    * Added cmdlet Get-BDRFoundationModelAgreementOfferList leveraging the ListFoundationModelAgreementOffers service API.
    * Added cmdlet Get-BDRFoundationModelAvailability leveraging the GetFoundationModelAvailability service API.
    * Added cmdlet Get-BDRUseCaseForModelAccess leveraging the GetUseCaseForModelAccess service API.
    * Added cmdlet New-BDRFoundationModelAgreement leveraging the CreateFoundationModelAgreement service API.
    * Added cmdlet Remove-BDRFoundationModelAgreement leveraging the DeleteFoundationModelAgreement service API.
    * Added cmdlet Write-BDRUseCaseForModelAccess leveraging the PutUseCaseForModelAccess service API.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2Image: added parameter SnapshotLocation.
  * Amazon License Manager
    * Modified cmdlet New-LICMLicenseConversionTaskForResource: added parameters DestinationLicenseContext_ProductCode and SourceLicenseContext_ProductCode.
  * Amazon Relational Database Service
    * Modified cmdlet Copy-RDSDBSnapshot: added parameters SnapshotAvailabilityZone and SnapshotTarget.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter BackupTarget.
  * Amazon Route 53 Resolver
    * Modified cmdlet New-R53RResolverRule: added parameter DelegationRecord.

### 5.0.0 (2025-06-23 20:21Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.37.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Please refer to the migration guide for a list of breaking changes and workarounds at https://docs.aws.amazon.com/powershell/v5/userguide/migrating-v5.html

### 5.0.0-preview005 (2025-05-30 15:16Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.22.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview005 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 5.0.0-preview004 (2025-04-29 14:53Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.0.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview004 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 5.0.0-preview003 (2025-03-17 16:54Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.0.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/v4-release/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview003 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 5.0.0-preview002 (2025-02-18 15:37Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 4.0.0.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/v4-release/changelogs/SDK.CHANGELOG.ALL.md.
  * Please find a description of the changes for 5.0.0-preview002 at https://github.com/aws/aws-tools-for-powershell/issues/357

### 4.1.845 (2025-06-20 20:47Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1068.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Modified cmdlet New-BDRGuardrail: added parameters ContentPolicyConfig_TierConfig_TierName and TopicPolicyConfig_TierConfig_TierName.
    * Modified cmdlet Update-BDRGuardrail: added parameters ContentPolicyConfig_TierConfig_TierName and TopicPolicyConfig_TierConfig_TierName.

### 4.1.844 (2025-06-19 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1067.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet New-EMRServerlessApplication: added parameter IdentityCenterConfiguration_IdentityCenterInstanceArn.
    * Modified cmdlet Update-EMRServerlessApplication: added parameter IdentityCenterConfiguration_IdentityCenterInstanceArn.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameters AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs, SchemaRegistryConfig_AccessConfig, SchemaRegistryConfig_EventRecordFormat, SchemaRegistryConfig_SchemaRegistryURI and SchemaRegistryConfig_SchemaValidationConfig.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters AmazonManagedKafkaEventSourceConfig_ConsumerGroupId, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI, AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs, SchemaRegistryConfig_AccessConfig, SchemaRegistryConfig_EventRecordFormat, SchemaRegistryConfig_SchemaRegistryURI, SchemaRegistryConfig_SchemaValidationConfig and SelfManagedKafkaEventSourceConfig_ConsumerGroupId.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMProject: added parameter TemplateProvider.
    * Modified cmdlet Update-SMProject: added parameter TemplateProvidersToUpdate.

### 4.1.843 (2025-06-18 21:12Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1066.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AI Ops. Added cmdlets to support the service. Cmdlets for the service have the noun prefix AIOps and can be listed using the command 'Get-AWSCmdletName -Service AIOps'.
  * Amazon Auto Scaling
    * Modified cmdlet Get-ASAutoScalingGroup: added parameter IncludeInstance.
  * Amazon Simple Storage Service (S3)
    * Added cmdlet Rename-S3Object leveraging the RenameObject service API.

### 4.1.842 (2025-06-17 22:38Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1065.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Backup
    * Added cmdlet Add-BAKBackupVaultMpaApprovalTeam leveraging the AssociateBackupVaultMpaApprovalTeam service API.
    * Added cmdlet Get-BAKRestoreAccessBackupVaultList leveraging the ListRestoreAccessBackupVaults service API.
    * Added cmdlet New-BAKRestoreAccessBackupVault leveraging the CreateRestoreAccessBackupVault service API.
    * Added cmdlet Remove-BAKBackupVaultMpaApprovalTeam leveraging the DisassociateBackupVaultMpaApprovalTeam service API.
    * Added cmdlet Revoke-BAKRestoreAccessBackupVault leveraging the RevokeRestoreAccessBackupVault service API.
  * Amazon Certificate Manager
    * Added cmdlet Revoke-ACMCertificate leveraging the RevokeCertificate service API.
    * Modified cmdlet Get-ACMCertificateList: added parameter Includes_ExportOption.
    * Modified cmdlet New-ACMCertificate: added parameter Options_Export.
    * Modified cmdlet Update-ACMCertificateOption: added parameter Options_Export.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSDataProvider: added parameters IbmDb2LuwSettings_S3AccessRoleArn, IbmDb2LuwSettings_S3Path, IbmDb2zOsSettings_S3AccessRoleArn, IbmDb2zOsSettings_S3Path, MariaDbSettings_S3AccessRoleArn, MariaDbSettings_S3Path, MicrosoftSqlServerSettings_S3AccessRoleArn, MicrosoftSqlServerSettings_S3Path, MySqlSettings_S3AccessRoleArn, MySqlSettings_S3Path, OracleSettings_S3AccessRoleArn, OracleSettings_S3Path, PostgreSqlSettings_S3AccessRoleArn, PostgreSqlSettings_S3Path, RedshiftSettings_S3AccessRoleArn, RedshiftSettings_S3Path and Virtual.
    * Modified cmdlet New-DMSDataProvider: added parameters IbmDb2LuwSettings_S3AccessRoleArn, IbmDb2LuwSettings_S3Path, IbmDb2zOsSettings_S3AccessRoleArn, IbmDb2zOsSettings_S3Path, MariaDbSettings_S3AccessRoleArn, MariaDbSettings_S3Path, MicrosoftSqlServerSettings_S3AccessRoleArn, MicrosoftSqlServerSettings_S3Path, MySqlSettings_S3AccessRoleArn, MySqlSettings_S3Path, OracleSettings_S3AccessRoleArn, OracleSettings_S3Path, PostgreSqlSettings_S3AccessRoleArn, PostgreSqlSettings_S3Path, RedshiftSettings_S3AccessRoleArn, RedshiftSettings_S3Path and Virtual.
  * Amazon IAM Access Analyzer
    * Modified cmdlet New-IAMAAAnalyzer: added parameter AnalysisRule_Inclusion.
    * Modified cmdlet Update-IAMAAAnalyzer: added parameter AnalysisRule_Inclusion.
  * Amazon Inspector2
    * Added cmdlet Get-INS2CodeSecurityIntegration leveraging the GetCodeSecurityIntegration service API.
    * Added cmdlet Get-INS2CodeSecurityIntegrationList leveraging the ListCodeSecurityIntegrations service API.
    * Added cmdlet Get-INS2CodeSecurityScan leveraging the GetCodeSecurityScan service API.
    * Added cmdlet Get-INS2CodeSecurityScanConfiguration leveraging the GetCodeSecurityScanConfiguration service API.
    * Added cmdlet Get-INS2CodeSecurityScanConfigurationAssociationList leveraging the ListCodeSecurityScanConfigurationAssociations service API.
    * Added cmdlet Get-INS2CodeSecurityScanConfigurationList leveraging the ListCodeSecurityScanConfigurations service API.
    * Added cmdlet New-INS2CodeSecurityIntegration leveraging the CreateCodeSecurityIntegration service API.
    * Added cmdlet New-INS2CodeSecurityScanConfiguration leveraging the CreateCodeSecurityScanConfiguration service API.
    * Added cmdlet Register-INS2CodeSecurityScanConfigurationBatch leveraging the BatchAssociateCodeSecurityScanConfiguration service API.
    * Added cmdlet Remove-INS2CodeSecurityIntegration leveraging the DeleteCodeSecurityIntegration service API.
    * Added cmdlet Remove-INS2CodeSecurityScanConfiguration leveraging the DeleteCodeSecurityScanConfiguration service API.
    * Added cmdlet Start-INS2CodeSecurityScan leveraging the StartCodeSecurityScan service API.
    * Added cmdlet Unregister-INS2CodeSecurityScanConfigurationBatch leveraging the BatchDisassociateCodeSecurityScanConfiguration service API.
    * Added cmdlet Update-INS2CodeSecurityIntegration leveraging the UpdateCodeSecurityIntegration service API.
    * Added cmdlet Update-INS2CodeSecurityScanConfiguration leveraging the UpdateCodeSecurityScanConfiguration service API.
    * Modified cmdlet Get-INS2CoverageList: added parameters FilterCriteria_CodeRepositoryProjectName, FilterCriteria_CodeRepositoryProviderType, FilterCriteria_CodeRepositoryProviderTypeVisibility and FilterCriteria_LastScannedCommitId.
    * Modified cmdlet Get-INS2CoverageStatisticList: added parameters FilterCriteria_CodeRepositoryProjectName, FilterCriteria_CodeRepositoryProviderType, FilterCriteria_CodeRepositoryProviderTypeVisibility and FilterCriteria_LastScannedCommitId.
    * Modified cmdlet Get-INS2FindingAggregationList: added parameters CodeRepositoryAggregation_ProjectName, CodeRepositoryAggregation_ProviderType, CodeRepositoryAggregation_ResourceId, CodeRepositoryAggregation_SortBy and CodeRepositoryAggregation_SortOrder.
    * Modified cmdlet Get-INS2FindingList: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet New-INS2Filter: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet New-INS2FindingsReport: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet Update-INS2Filter: added parameters FilterCriteria_CodeRepositoryProjectName and FilterCriteria_CodeRepositoryProviderType.
    * Modified cmdlet Update-INS2OrganizationConfiguration: added parameter AutoEnable_CodeRepository.
  * Amazon Multi-party Approval. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MPA and can be listed using the command 'Get-AWSCmdletName -Service MPA'.
  * NWFW
    * [Breaking Change] Removed cmdlets Approve-NWFWNetworkFirewallTransitGatewayAttachment, Register-NWFWAvailabilityZone and Unregister-NWFWAvailabilityZone.
    * Added cmdlet Get-NWFWRuleGroupSummary leveraging the DescribeRuleGroupSummary service API.
    * Added cmdlet Join-NWFWAvailabilityZone leveraging the AssociateAvailabilityZones service API.
    * Added cmdlet Receive-NWFWNetworkFirewallTransitGatewayAttachment leveraging the AcceptNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Remove-NWFWAvailabilityZone leveraging the DisassociateAvailabilityZones service API.
    * Modified cmdlet New-NWFWRuleGroup: added parameter SummaryConfiguration_RuleOption.
    * Modified cmdlet Update-NWFWRuleGroup: added parameter SummaryConfiguration_RuleOption.
  * Amazon Security Hub
    * Added cmdlet Disable-SHUBSecurityHubV2 leveraging the DisableSecurityHubV2 service API.
    * Added cmdlet Enable-SHUBSecurityHubV2 leveraging the EnableSecurityHubV2 service API.
    * Added cmdlet Get-SHUBAggregatorsV2List leveraging the ListAggregatorsV2 service API.
    * Added cmdlet Get-SHUBAggregatorV2 leveraging the GetAggregatorV2 service API.
    * Added cmdlet Get-SHUBAutomationRulesV2List leveraging the ListAutomationRulesV2 service API.
    * Added cmdlet Get-SHUBAutomationRuleV2 leveraging the GetAutomationRuleV2 service API.
    * Added cmdlet Get-SHUBConnectorsV2List leveraging the ListConnectorsV2 service API.
    * Added cmdlet Get-SHUBConnectorV2 leveraging the GetConnectorV2 service API.
    * Added cmdlet Get-SHUBFindingStatisticsV2 leveraging the GetFindingStatisticsV2 service API.
    * Added cmdlet Get-SHUBFindingsV2 leveraging the GetFindingsV2 service API.
    * Added cmdlet Get-SHUBProductsV2 leveraging the DescribeProductsV2 service API.
    * Added cmdlet Get-SHUBResourcesStatisticsV2 leveraging the GetResourcesStatisticsV2 service API.
    * Added cmdlet Get-SHUBResourcesV2 leveraging the GetResourcesV2 service API.
    * Added cmdlet Get-SHUBSecurityHubV2 leveraging the DescribeSecurityHubV2 service API.
    * Added cmdlet New-SHUBAggregatorV2 leveraging the CreateAggregatorV2 service API.
    * Added cmdlet New-SHUBAutomationRuleV2 leveraging the CreateAutomationRuleV2 service API.
    * Added cmdlet New-SHUBConnectorV2 leveraging the CreateConnectorV2 service API.
    * Added cmdlet New-SHUBTicketV2 leveraging the CreateTicketV2 service API.
    * Added cmdlet Register-SHUBConnectorV2 leveraging the ConnectorRegistrationsV2 service API.
    * Added cmdlet Remove-SHUBAggregatorV2 leveraging the DeleteAggregatorV2 service API.
    * Added cmdlet Remove-SHUBAutomationRuleV2 leveraging the DeleteAutomationRuleV2 service API.
    * Added cmdlet Remove-SHUBConnectorV2 leveraging the DeleteConnectorV2 service API.
    * Added cmdlet Set-SHUBBatchFindingsV2 leveraging the BatchUpdateFindingsV2 service API.
    * Added cmdlet Update-SHUBAggregatorV2 leveraging the UpdateAggregatorV2 service API.
    * Added cmdlet Update-SHUBAutomationRuleV2 leveraging the UpdateAutomationRuleV2 service API.
    * Added cmdlet Update-SHUBConnectorV2 leveraging the UpdateConnectorV2 service API.
    * Modified cmdlet Disable-SHUBOrganizationAdminAccount: added parameter Feature.
    * Modified cmdlet Enable-SHUBOrganizationAdminAccount: added parameter Feature.
    * Modified cmdlet Get-SHUBOrganizationAdminAccountList: added parameter Feature.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter ApplicationConfig_Attribute.

### 4.1.841 (2025-06-16 19:58Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1064.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock
    * Added cmdlet New-BDRCustomModel leveraging the CreateCustomModel service API.
    * Modified cmdlet Get-BDRCustomModelList: added parameter ModelStatus.
  * Amazon Network Firewall
    * Added cmdlet Approve-NWFWNetworkFirewallTransitGatewayAttachment leveraging the AcceptNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Deny-NWFWNetworkFirewallTransitGatewayAttachment leveraging the RejectNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Register-NWFWAvailabilityZone leveraging the AssociateAvailabilityZones service API.
    * Added cmdlet Remove-NWFWNetworkFirewallTransitGatewayAttachment leveraging the DeleteNetworkFirewallTransitGatewayAttachment service API.
    * Added cmdlet Unregister-NWFWAvailabilityZone leveraging the DisassociateAvailabilityZones service API.
    * Added cmdlet Update-NWFWAvailabilityZoneChangeProtection leveraging the UpdateAvailabilityZoneChangeProtection service API.
    * Modified cmdlet New-NWFWFirewall: added parameters AvailabilityZoneChangeProtection, AvailabilityZoneMapping and TransitGatewayId.

### 4.1.840 (2025-06-12 20:09Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1063.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonConnectCampaignServiceV2
    * Added cmdlet Get-CCS2InstanceCommunicationLimit leveraging the GetInstanceCommunicationLimits service API.
    * Added cmdlet Write-CCS2InstanceCommunicationLimit leveraging the PutInstanceCommunicationLimits service API.
    * Modified cmdlet New-CCS2Campaign: added parameter CommunicationLimitsOverride_InstanceLimitsHandling.
    * Modified cmdlet Update-CCS2CampaignCommunicationLimit: added parameter CommunicationLimitsOverride_InstanceLimitsHandling.

### 4.1.839 (2025-06-11 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1062.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Control Catalog
    * Added cmdlet Get-CLCATControlMappingList leveraging the ListControlMappings service API.
    * Modified cmdlet Get-CLCATControlList: added parameters Implementations_Identifier and Implementations_Type.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSPodIdentityAssociation: added parameters DisableSessionTag and TargetRoleArn.
    * Modified cmdlet Update-EKSPodIdentityAssociation: added parameters DisableSessionTag and TargetRoleArn.
  * Amazon Lex Model Building V2
    * Modified cmdlet New-LMBV2BotLocale: added parameter NluImprovement_Enabled.
    * Modified cmdlet Update-LMBV2BotLocale: added parameter NluImprovement_Enabled.
  * Amazon Network Manager
    * Modified cmdlet New-NMGRVpcAttachment: added parameters Options_DnsSupport and Options_SecurityGroupReferencingSupport.
    * Modified cmdlet Update-NMGRVpcAttachment: added parameters Options_DnsSupport and Options_SecurityGroupReferencingSupport.
  * Amazon WAF V2
    * Modified cmdlet New-WAF2WebACL: added parameter OnSourceDDoSProtectionConfig_ALBLowReputationMode.
    * Modified cmdlet Update-WAF2WebACL: added parameter OnSourceDDoSProtectionConfig_ALBLowReputationMode.

### 4.1.838 (2025-06-10 20:06Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1061.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.

### 4.1.837 (2025-06-09 20:39Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1061.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Connect Customer Profiles
    * Added cmdlet Get-CPFDomainLayout leveraging the GetDomainLayout service API.
    * Added cmdlet Get-CPFDomainLayoutList leveraging the ListDomainLayouts service API.
    * Added cmdlet New-CPFDomainLayout leveraging the CreateDomainLayout service API.
    * Added cmdlet Remove-CPFDomainLayout leveraging the DeleteDomainLayout service API.
    * Added cmdlet Update-CPFDomainLayout leveraging the UpdateDomainLayout service API.
    * Modified cmdlet New-CPFCalculatedAttributeDefinition: added parameters Range_TimestampFormat, Range_TimestampSource, UseHistoricalData, ValueRange_End and ValueRange_Start.
    * Modified cmdlet Update-CPFCalculatedAttributeDefinition: added parameters Range_TimestampFormat, Range_TimestampSource, ValueRange_End and ValueRange_Start.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Edit-EC2NetworkInterfaceAttribute: added parameter AssociatedSubnetId.
  * Amazon Elastic File System
    * Modified cmdlet New-EFSMountTarget: added parameters IpAddressType and Ipv6Address.
  * Amazon Marketplace Catalog Service
    * Modified cmdlet Get-MCATEntityList: added parameters DateRange_AfterValue, DateRange_BeforeValue, EntityId_ValueList, MachineLearningProductSort_SortBy, MachineLearningProductSort_SortOrder, ProductTitle_ValueList, ProductTitle_WildCardValue and Visibility_ValueList.

### 4.1.836 (2025-06-06 20:23Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1060.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Bedrock Agent Runtime
    * Modified cmdlet Invoke-BARAgent: added parameters PromptCreationConfigurations_ExcludePreviousThinkingStep and PromptCreationConfigurations_PreviousConversationTurnsToInclude.
    * Modified cmdlet Invoke-BARInlineAgent: added parameters PromptCreationConfigurations_ExcludePreviousThinkingStep and PromptCreationConfigurations_PreviousConversationTurnsToInclude.
  * Amazon Rekognition
    * Modified cmdlet New-REKFaceLivenessSession: added parameter Settings_ChallengePreference.
  * Amazon S3 Tables
    * Modified cmdlet Get-S3TTable: added parameter TableArn.

### 4.1.835 (2025-06-05 20:31Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1059.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Key Management Service
    * Modified cmdlet Get-KMSKeyRotation: added parameter IncludeKeyMaterial.
    * Modified cmdlet Import-KMSKeyMaterial: added parameters ImportType, KeyMaterialDescription and KeyMaterialId.
    * Modified cmdlet Remove-KMSImportedKeyMaterial: added parameter KeyMaterialId.

### 4.1.834 (2025-06-04 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1058.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Elastic VMware Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EVS and can be listed using the command 'Get-AWSCmdletName -Service EVS'.
  * Amazon Invoicing
    * Added cmdlet Get-INVInvoiceSummaryList leveraging the ListInvoiceSummaries service API.
  * Amazon Network Firewall
    * Modified cmdlet Update-NWFWLoggingConfiguration: added parameter EnableMonitoringDashboard.

### 4.1.833 (2025-06-03 20:00Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1057.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter RoutingMode.
  * Amazon API Gateway V2
    * Added cmdlet Get-AG2RoutingRule leveraging the GetRoutingRule service API.
    * Added cmdlet Get-AG2RoutingRuleList leveraging the ListRoutingRules service API.
    * Added cmdlet New-AG2RoutingRule leveraging the CreateRoutingRule service API.
    * Added cmdlet Remove-AG2RoutingRule leveraging the DeleteRoutingRule service API.
    * Added cmdlet Write-AG2RoutingRule leveraging the PutRoutingRule service API.
    * Modified cmdlet New-AG2DomainName: added parameter RoutingMode.
    * Modified cmdlet Update-AG2DomainName: added parameter RoutingMode.
  * Amazon EMR Serverless
    * Modified cmdlet Stop-EMRServerlessJobRun: added parameter ShutdownGracePeriodInSecond.

### 4.1.832 (2025-06-02 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1056.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Agents for Amazon Bedrock
    * Modified cmdlet Update-AABAgentAlias: added parameter AliasInvocationState.
  * Amazon Athena
    * Modified cmdlet Get-ATHQueryResult: added parameter QueryResultType.
    * Modified cmdlet New-ATHWorkGroup: added parameters Configuration_ManagedQueryResultsConfiguration_EncryptionConfiguration_KmsKey and ManagedQueryResultsConfiguration_Enabled.
    * Modified cmdlet Update-ATHWorkGroup: added parameters ConfigurationUpdates_ManagedQueryResultsConfigurationUpdates_EncryptionConfiguration_KmsKey, ManagedQueryResultsConfigurationUpdates_Enabled and ManagedQueryResultsConfigurationUpdates_RemoveEncryptionConfiguration.
  * Amazon EntityResolution
    * Added cmdlet Set-ERESMatchId leveraging the GenerateMatchId service API.

### 4.1.831 (2025-05-30 20:35Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1055.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon EMR Serverless
    * Modified cmdlet Start-EMRServerlessJobRun: added parameters ExecutionIamPolicy_Policy and ExecutionIamPolicy_PolicyArn.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMDomain: added parameter UnifiedStudioSettings_SingleSignOnApplicationArn.
    * Modified cmdlet Update-SMDomain: added parameter UnifiedStudioSettings_SingleSignOnApplicationArn.

### 4.1.830 (2025-05-29 20:24Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1054.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AmazonMWAA
    * Modified cmdlet Update-MWAAEnvironment: added parameter WorkerReplacementStrategy.
  * Amazon Amplify
    * Modified cmdlet New-AMPApp: added parameter JobConfig_BuildComputeType.
    * Modified cmdlet Update-AMPApp: added parameter JobConfig_BuildComputeType.
  * Amazon CloudTrail
    * Added cmdlet Get-CTEventConfiguration leveraging the GetEventConfiguration service API.
    * Added cmdlet Write-CTEventConfiguration leveraging the PutEventConfiguration service API.
  * Amazon Data Exchange
    * Modified cmdlet New-DTEXEventAction: added parameter Tag.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationAzureBlob: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet New-DSYNLocationObjectStorage: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationAzureBlob: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
    * Modified cmdlet Update-DSYNLocationObjectStorage: added parameters CmkSecretConfig_KmsKeyArn, CmkSecretConfig_SecretArn, CustomSecretConfig_SecretAccessRoleArn and CustomSecretConfig_SecretArn.
  * Amazon Interactive Video Service RealTime
    * Added cmdlet Get-IVSRTParticipantReplicaList leveraging the ListParticipantReplicas service API.
    * Added cmdlet Start-IVSRTParticipantReplication leveraging the StartParticipantReplication service API.
    * Added cmdlet Stop-IVSRTParticipantReplication leveraging the StopParticipantReplication service API.
    * Modified cmdlet New-IVSRTStage: added parameter AutoParticipantRecordingConfiguration_RecordParticipantReplica.
    * Modified cmdlet Update-IVSRTStage: added parameter AutoParticipantRecordingConfiguration_RecordParticipantReplica.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlet Write-S3BucketOwnershipControl: added parameter ChecksumAlgorithm.

### 4.1.829 (2025-05-28 20:44Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1053.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon CloudWatch Synthetics
    * Modified cmdlet New-CWSYNCanary: added parameter RunConfig_EphemeralStorage.
    * Modified cmdlet Start-CWSYNCanaryDryRun: added parameter RunConfig_EphemeralStorage.
    * Modified cmdlet Update-CWSYNCanary: added parameter RunConfig_EphemeralStorage.
  * Amazon Cost Optimization Hub
    * Modified cmdlet Update-COHPreference: added parameters PreferredCommitment_PaymentOption and PreferredCommitment_Term.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Unregister-EC2Image: added parameter DeleteAssociatedSnapshot.
  * Amazon Network Firewall
    * Added cmdlet Get-NWFWFirewallMetadata leveraging the DescribeFirewallMetadata service API.
    * Added cmdlet Get-NWFWVpcEndpointAssociation leveraging the DescribeVpcEndpointAssociation service API.
    * Added cmdlet Get-NWFWVpcEndpointAssociationList leveraging the ListVpcEndpointAssociations service API.
    * Added cmdlet New-NWFWVpcEndpointAssociation leveraging the CreateVpcEndpointAssociation service API.
    * Added cmdlet Remove-NWFWVpcEndpointAssociation leveraging the DeleteVpcEndpointAssociation service API.
    * Modified cmdlet Get-NWFWFlowOperation: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Get-NWFWFlowOperationList: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Get-NWFWFlowOperationResultList: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Start-NWFWFlowCapture: added parameters VpcEndpointAssociationArn and VpcEndpointId.
    * Modified cmdlet Start-NWFWFlowFlush: added parameters VpcEndpointAssociationArn and VpcEndpointId.

### 4.1.828 (2025-05-27 20:20Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1052.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon AWSDeadlineCloud
    * Modified cmdlet New-ADCFleet: added parameter ServiceManagedEc2_StorageProfileId.
    * Modified cmdlet Update-ADCFleet: added parameter ServiceManagedEc2_StorageProfileId.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostAndUsageComparison leveraging the GetCostAndUsageComparisons service API.
    * Added cmdlet Get-CECostComparisonDriver leveraging the GetCostComparisonDrivers service API.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Get-EC2ActiveVpnTunnelStatus leveraging the GetActiveVpnTunnelStatus service API.
    * Modified cmdlet Edit-EC2VpnTunnelOption: added parameter PreSharedKeyStorage.
    * Modified cmdlet Get-EC2VpnConnectionDeviceSampleConfiguration: added parameter SampleType.
    * Modified cmdlet New-EC2VpnConnection: added parameter PreSharedKeyStorage.

### 4.1.827 (2025-05-23 20:33Z)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.7.1051.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/aws-sdk-net-v3.7/changelogs/SDK.CHANGELOG.ALL.md.

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

