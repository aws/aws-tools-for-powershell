### 4.0.2.0 (2019-12-13)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.648.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Improving speed of AWS.Tools.Installer's Install-AWSPowerShellModule and Update-AWSPowerShellModule, adding support for running AWS.Tools in strict mode.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBProfile: added parameters EndOfMeetingReminder_Enabled, EndOfMeetingReminder_ReminderAtMinute, EndOfMeetingReminder_ReminderType, InstantBooking_DurationInMinute, InstantBooking_Enabled, MeetingRoomConfiguration_RoomUtilizationMetricsEnabled, RequireCheckIn_Enabled and RequireCheckIn_ReleaseAfterMinute.
    * Modified cmdlet Update-ALXBProfile: added parameters EndOfMeetingReminder_Enabled, EndOfMeetingReminder_ReminderAtMinute, EndOfMeetingReminder_ReminderType, InstantBooking_DurationInMinute, InstantBooking_Enabled, MeetingRoomConfiguration_RoomUtilizationMetricsEnabled, RequireCheckIn_Enabled and RequireCheckIn_ReleaseAfterMinute.
  * Amazon API Gateway V2
    * Added cmdlet Import-AG2Api leveraging the ImportApi service API.
    * Added cmdlet Remove-AG2CorsConfiguration leveraging the DeleteCorsConfiguration service API.
    * Added cmdlet Remove-AG2RouteSetting leveraging the DeleteRouteSettings service API.
    * Added cmdlet Update-AG2ApiImport leveraging the ReimportApi service API.
    * Modified cmdlet New-AG2Api: added parameters CorsConfiguration_AllowCredential, CorsConfiguration_AllowHeader, CorsConfiguration_AllowMethod, CorsConfiguration_AllowOrigin, CorsConfiguration_ExposeHeader, CorsConfiguration_MaxAge, CredentialsArn, RouteKey and Target.
    * [Breaking Change] Modified cmdlet New-AG2Authorizer: removed parameter ProviderArn; added parameters JwtConfiguration_Audience and JwtConfiguration_Issuer.
    * Modified cmdlet New-AG2Integration: added parameter PayloadFormatVersion.
    * Modified cmdlet New-AG2Stage: added parameter AutoDeploy.
    * Modified cmdlet Update-AG2Api: added parameters CorsConfiguration_AllowCredential, CorsConfiguration_AllowHeader, CorsConfiguration_AllowMethod, CorsConfiguration_AllowOrigin, CorsConfiguration_ExposeHeader, CorsConfiguration_MaxAge, CredentialsArn, RouteKey and Target.
    * [Breaking Change] Modified cmdlet Update-AG2Authorizer: removed parameter ProviderArn; added parameters JwtConfiguration_Audience and JwtConfiguration_Issuer.
    * Modified cmdlet Update-AG2Integration: added parameter PayloadFormatVersion.
    * Modified cmdlet Update-AG2Stage: added parameter AutoDeploy.
  * Amazon AppConfig. Added cmdlets to support the service. Cmdlets for the service have the noun prefix APPC and can be listed using the command 'Get-AWSCmdletName -Service APPC'. Introducing AWS AppConfig, a new service that enables customers to quickly deploy validated configurations to applications of any size in a controlled and monitored fashion.
  * Amazon Augmented AI (A2I) Runtime. Added cmdlets to support the service. Cmdlets for the service have the noun prefix A2IR and can be listed using the command 'Get-AWSCmdletName -Service A2IR'. This release adds support for Amazon Augmented AI, which makes it easy to build workflows for human review of machine learning predictions.
  * Amazon CloudWatch
    * Added cmdlet Disable-CWInsightRule leveraging the DisableInsightRules service API.
    * Added cmdlet Enable-CWInsightRule leveraging the EnableInsightRules service API.
    * Added cmdlet Get-CWInsightRule leveraging the DescribeInsightRules service API.
    * Added cmdlet Get-CWInsightRuleReport leveraging the GetInsightRuleReport service API.
    * Added cmdlet Remove-CWInsightRule leveraging the DeleteInsightRules service API.
    * Added cmdlet Write-CWInsightRule leveraging the PutInsightRule service API.
  * Amazon CloudWatch Application Insights
    * Added cmdlet Add-CWAIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWAILogPattern leveraging the DescribeLogPattern service API.
    * Added cmdlet Get-CWAILogPatternList leveraging the ListLogPatterns service API.
    * Added cmdlet Get-CWAILogPatternSetList leveraging the ListLogPatternSets service API.
    * Added cmdlet Get-CWAIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-CWAILogPattern leveraging the CreateLogPattern service API.
    * Added cmdlet Remove-CWAILogPattern leveraging the DeleteLogPattern service API.
    * Added cmdlet Remove-CWAIResourceTag leveraging the UntagResource service API.
    * Added cmdlet Update-CWAILogPattern leveraging the UpdateLogPattern service API.
    * Modified cmdlet New-CWAIApplication: added parameter Tag.
  * Amazon CodeBuild
    * Added cmdlet Get-CBReportBatch leveraging the BatchGetReports service API.
    * Added cmdlet Get-CBReportGroupBatch leveraging the BatchGetReportGroups service API.
    * Added cmdlet Get-CBReportGroupList leveraging the ListReportGroups service API.
    * Added cmdlet Get-CBReportList leveraging the ListReports service API.
    * Added cmdlet Get-CBReportsForReportGroupList leveraging the ListReportsForReportGroup service API.
    * Added cmdlet Get-CBTestCase leveraging the DescribeTestCases service API.
    * Added cmdlet New-CBReportGroup leveraging the CreateReportGroup service API.
    * Added cmdlet Remove-CBReport leveraging the DeleteReport service API.
    * Added cmdlet Remove-CBReportGroup leveraging the DeleteReportGroup service API.
    * Added cmdlet Update-CBReportGroup leveraging the UpdateReportGroup service API.
  * Amazon CodeGuru Profiler. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CGP and can be listed using the command 'Get-AWSCmdletName -Service CGP'. Amazon CodeGuru Profiler analyzes application CPU utilization and latency characteristics to show you where you are spending the most cycles in your application. This analysis is presented in an interactive flame graph that helps you easily understand which paths consume the most resources, verify that your application is performing as expected, and uncover areas that can be optimized further.
  * Amazon CodeGuru Reviewer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CGR and can be listed using the command 'Get-AWSCmdletName -Service CGR'. This is the preview release of Amazon CodeGuru Reviewer.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter AccountRecoverySetting_RecoveryMechanism.
    * Modified cmdlet Update-CGIPUserPool: added parameter AccountRecoverySetting_RecoveryMechanism.
  * Amazon Comprehend
    * Added cmdlet Get-COMPEndpoint leveraging the DescribeEndpoint service API.
    * Added cmdlet Get-COMPEndpointList leveraging the ListEndpoints service API.
    * Added cmdlet Invoke-COMPDocumentClassification leveraging the ClassifyDocument service API.
    * Added cmdlet New-COMPEndpoint leveraging the CreateEndpoint service API.
    * Added cmdlet Remove-COMPEndpoint leveraging the DeleteEndpoint service API.
    * Added cmdlet Update-COMPEndpoint leveraging the UpdateEndpoint service API.
  * Amazon Compute Optimizer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CO and can be listed using the command 'Get-AWSCmdletName -Service CO'. AWS Compute Optimizer recommends optimal AWS Compute resources to reduce costs and improve performance for your workloads.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostCategoryDefinition leveraging the DescribeCostCategoryDefinition service API.
    * Added cmdlet Get-CECostCategoryDefinitionList leveraging the ListCostCategoryDefinitions service API.
    * Added cmdlet New-CECostCategoryDefinition leveraging the CreateCostCategoryDefinition service API.
    * Added cmdlet Remove-CECostCategoryDefinition leveraging the DeleteCostCategoryDefinition service API.
    * Added cmdlet Update-CECostCategoryDefinition leveraging the UpdateCostCategoryDefinition service API.
  * Amazon Directory Service
    * Added cmdlet Disable-DSLDAPS leveraging the DisableLDAPS service API.
    * Added cmdlet Enable-DSLDAPS leveraging the EnableLDAPS service API.
    * Added cmdlet Get-DSCertificate leveraging the DescribeCertificate service API.
    * Added cmdlet Get-DSCertificateList leveraging the ListCertificates service API.
    * Added cmdlet Get-DSLDAPSSetting leveraging the DescribeLDAPSSettings service API.
    * Added cmdlet Register-DSCertificate leveraging the RegisterCertificate service API.
    * Added cmdlet Unregister-DSCertificate leveraging the DeregisterCertificate service API.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBContributorInsight leveraging the DescribeContributorInsights service API.
    * Added cmdlet Get-DDBContributorInsightList leveraging the ListContributorInsights service API.
    * Added cmdlet Update-DDBContributorInsight leveraging the UpdateContributorInsights service API.
  * Amazon EBS. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EBS and can be listed using the command 'Get-AWSCmdletName -Service EBS'. This release introduces the EBS direct APIs for Snapshots: 1. Get-EBSChangedBlockList, which lists the block indexes and block tokens for blocks in an Amazon EBS snapshot. 2. Get-EBSSnapshotBlockList, which lists the block indexes and block tokens for blocks that are different between two snapshots of the same volume/snapshot lineage. 3. Get-EBSSnapshotBlock, which returns the data in a block of an Amazon EBS snapshot.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSCapacityProvider leveraging the DescribeCapacityProviders service API.
    * Added cmdlet New-ECSCapacityProvider leveraging the CreateCapacityProvider service API.
    * Added cmdlet Write-ECSClusterCapacityProvider leveraging the PutClusterCapacityProviders service API.
    * Modified cmdlet New-ECSCluster: added parameters CapacityProvider and DefaultCapacityProviderStrategy.
    * Modified cmdlet New-ECSService: added parameter CapacityProviderStrategy.
    * Modified cmdlet New-ECSTask: added parameter CapacityProviderStrategy.
    * Modified cmdlet New-ECSTaskSet: added parameter CapacityProviderStrategy.
    * Modified cmdlet Update-ECSService: added parameter CapacityProviderStrategy.
  * Amazon EC2 Image Builder. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EC2IB and can be listed using the command 'Get-AWSCmdletName -Service EC2IB'. Image Builder provides a managed experience for automating the creation of EC2 AMIs.
  * EC2
    * Added cmdlet Approve-EC2TransitGatewayPeeringAttachment leveraging the AcceptTransitGatewayPeeringAttachment service API.
    * Added cmdlet Deny-EC2TransitGatewayPeeringAttachment leveraging the RejectTransitGatewayPeeringAttachment service API.
    * Added cmdlet Edit-EC2DefaultCreditSpecification leveraging the ModifyDefaultCreditSpecification service API.
    * Added cmdlet Get-EC2CoipPool leveraging the DescribeCoipPools service API.
    * Added cmdlet Get-EC2CoipPoolUsage leveraging the GetCoipPoolUsage service API.
    * Added cmdlet Get-EC2DefaultCreditSpecification leveraging the GetDefaultCreditSpecification service API.
    * Added cmdlet Get-EC2LocalGateway leveraging the DescribeLocalGateways service API.
    * Added cmdlet Get-EC2LocalGatewayRouteTable leveraging the DescribeLocalGatewayRouteTables service API.
    * Added cmdlet Get-EC2LocalGatewayRouteTableVirtualInterfaceGroupAssociation leveraging the DescribeLocalGatewayRouteTableVirtualInterfaceGroupAssociations service API.
    * Added cmdlet Get-EC2LocalGatewayRouteTableVpcAssociation leveraging the DescribeLocalGatewayRouteTableVpcAssociations service API.
    * Added cmdlet Get-EC2LocalGatewayVirtualInterface leveraging the DescribeLocalGatewayVirtualInterfaces service API.
    * Added cmdlet Get-EC2LocalGatewayVirtualInterfaceGroup leveraging the DescribeLocalGatewayVirtualInterfaceGroups service API.
    * Added cmdlet Get-EC2TransitGatewayMulticastDomain leveraging the DescribeTransitGatewayMulticastDomains service API.
    * Added cmdlet Get-EC2TransitGatewayMulticastDomainAssociation leveraging the GetTransitGatewayMulticastDomainAssociations service API.
    * Added cmdlet Get-EC2TransitGatewayPeeringAttachment leveraging the DescribeTransitGatewayPeeringAttachments service API.
    * Added cmdlet New-EC2LocalGatewayRoute leveraging the CreateLocalGatewayRoute service API.
    * Added cmdlet New-EC2LocalGatewayRouteTableVpcAssociation leveraging the CreateLocalGatewayRouteTableVpcAssociation service API.
    * Added cmdlet New-EC2TransitGatewayMulticastDomain leveraging the CreateTransitGatewayMulticastDomain service API.
    * Added cmdlet New-EC2TransitGatewayPeeringAttachment leveraging the CreateTransitGatewayPeeringAttachment service API.
    * Added cmdlet Register-EC2TransitGatewayMulticastDomain leveraging the AssociateTransitGatewayMulticastDomain service API.
    * Added cmdlet Register-EC2TransitGatewayMulticastGroupMember leveraging the RegisterTransitGatewayMulticastGroupMembers service API.
    * Added cmdlet Register-EC2TransitGatewayMulticastGroupSource leveraging the RegisterTransitGatewayMulticastGroupSources service API.
    * Added cmdlet Remove-EC2LocalGatewayRoute leveraging the DeleteLocalGatewayRoute service API.
    * Added cmdlet Remove-EC2LocalGatewayRouteTableVpcAssociation leveraging the DeleteLocalGatewayRouteTableVpcAssociation service API.
    * Added cmdlet Remove-EC2TransitGatewayMulticastDomain leveraging the DeleteTransitGatewayMulticastDomain service API.
    * Added cmdlet Remove-EC2TransitGatewayPeeringAttachment leveraging the DeleteTransitGatewayPeeringAttachment service API.
    * Added cmdlet Search-EC2LocalGatewayRoute leveraging the SearchLocalGatewayRoutes service API.
    * Added cmdlet Search-EC2TransitGatewayMulticastGroup leveraging the SearchTransitGatewayMulticastGroups service API.
    * Added cmdlet Unregister-EC2TransitGatewayMulticastDomain leveraging the DisassociateTransitGatewayMulticastDomain service API.
    * Added cmdlet Unregister-EC2TransitGatewayMulticastGroupMember leveraging the DeregisterTransitGatewayMulticastGroupMembers service API.
    * Added cmdlet Unregister-EC2TransitGatewayMulticastGroupSource leveraging the DeregisterTransitGatewayMulticastGroupSources service API.
    * Modified cmdlet New-EC2Instance: added parameter Placement_HostResourceGroupArn.
    * Modified cmdlet Edit-EC2InstancePlacement: added parameter HostResourceGroupArn.
    * Modified cmdlet Get-EC2AvailabilityZone: added parameter AllAvailabilityZone.
    * Modified cmdlet New-EC2Address: added parameters CustomerOwnedIpv4Pool and NetworkBorderGroup.
    * Modified cmdlet New-EC2Route: added parameter LocalGatewayId.
    * Modified cmdlet New-EC2Subnet: added parameter OutpostArn.
    * Modified cmdlet New-EC2TransitGateway: added parameter Options_MulticastSupport.
    * Modified cmdlet New-EC2Volume: added parameter OutpostArn.
    * Modified cmdlet New-EC2Vpc: added parameter Ipv6CidrBlockNetworkBorderGroup.
    * Modified cmdlet New-EC2VpnConnection: added parameter Options_EnableAcceleration.
    * Modified cmdlet Register-EC2RouteTable: added parameter GatewayId.
    * Modified cmdlet Register-EC2VpcCidrBlock: added parameter Ipv6CidrBlockNetworkBorderGroup.
    * Modified cmdlet Remove-EC2Address: added parameter NetworkBorderGroup.
    * Modified cmdlet Set-EC2Route: added parameters LocalGatewayId and LocalTarget.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSFargateProfile leveraging the DescribeFargateProfile service API.
    * Added cmdlet Get-EKSFargateProfileList leveraging the ListFargateProfiles service API.
    * Added cmdlet New-EKSFargateProfile leveraging the CreateFargateProfile service API.
    * Added cmdlet Remove-EKSFargateProfile leveraging the DeleteFargateProfile service API.
  * Amazon Elastic Inference. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EI and can be listed using the command 'Get-AWSCmdletName -Service EI'. Amazon Elastic Inference allows customers to attach Elastic Inference Accelerators to Amazon EC2 and Amazon ECS tasks, thus providing low-cost GPU-powered acceleration and reducing the cost of running deep learning inference. This release allows customers to add or remove tags for their Elastic Inference Accelerators.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameters ElasticsearchClusterConfig_WarmCount, ElasticsearchClusterConfig_WarmEnabled and ElasticsearchClusterConfig_WarmType.
    * Modified cmdlet Update-ESDomainConfig: added parameters ElasticsearchClusterConfig_WarmCount, ElasticsearchClusterConfig_WarmEnabled and ElasticsearchClusterConfig_WarmType.
  * Amazon Elemental MediaLive
    * Added cmdlet Get-EMLMultiplex leveraging the DescribeMultiplex service API.
    * Added cmdlet Get-EMLMultiplexList leveraging the ListMultiplexes service API.
    * Added cmdlet Get-EMLMultiplexProgram leveraging the DescribeMultiplexProgram service API.
    * Added cmdlet Get-EMLMultiplexProgramList leveraging the ListMultiplexPrograms service API.
    * Added cmdlet New-EMLMultiplex leveraging the CreateMultiplex service API.
    * Added cmdlet New-EMLMultiplexProgram leveraging the CreateMultiplexProgram service API.
    * Added cmdlet Remove-EMLMultiplex leveraging the DeleteMultiplex service API.
    * Added cmdlet Remove-EMLMultiplexProgram leveraging the DeleteMultiplexProgram service API.
    * Added cmdlet Start-EMLMultiplex leveraging the StartMultiplex service API.
    * Added cmdlet Stop-EMLMultiplex leveraging the StopMultiplex service API.
    * Added cmdlet Update-EMLMultiplex leveraging the UpdateMultiplex service API.
    * Added cmdlet Update-EMLMultiplexProgram leveraging the UpdateMultiplexProgram service API.
    * Modified cmdlet Get-EMLOfferingList: added parameter Duration.
  * Amazon Elemental MediaTailor
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameters LivePreRollConfiguration_AdDecisionServerUrl and LivePreRollConfiguration_MaxDurationSecond.
  * Amazon Fraud Detector. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FD and can be listed using the command 'Get-AWSCmdletName -Service FD'. Amazon Fraud Detector is a fully managed service that makes it easy to identify potentially fraudulent online activities such as online payment fraud and the creation of fake accounts. Amazon Fraud Detector uses your data, machine learning (ML), and more than 20 years of fraud detection expertise from Amazon to automatically identify potentially fraudulent online activity so you can catch more fraud faster.
  * Amazon IAM Access Analyzer. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IAMAA and can be listed using the command 'Get-AWSCmdletName -Service IAMAA'. IAM Access Analyzer is an IAM feature that makes it easy for AWS customers to ensure that their resource-based policies provide only the intended access to resources outside their AWS accounts.
  * Amazon IoT
    * Added cmdlet Get-IOTDomainConfiguration leveraging the DescribeDomainConfiguration service API.
    * Added cmdlet Get-IOTDomainConfigurationList leveraging the ListDomainConfigurations service API.
    * Added cmdlet Get-IOTProvisioningTemplate leveraging the DescribeProvisioningTemplate service API.
    * Added cmdlet Get-IOTProvisioningTemplateList leveraging the ListProvisioningTemplates service API.
    * Added cmdlet Get-IOTProvisioningTemplateVersion leveraging the DescribeProvisioningTemplateVersion service API.
    * Added cmdlet Get-IOTProvisioningTemplateVersionList leveraging the ListProvisioningTemplateVersions service API.
    * Added cmdlet New-IOTDomainConfiguration leveraging the CreateDomainConfiguration service API.
    * Added cmdlet New-IOTProvisioningClaim leveraging the CreateProvisioningClaim service API.
    * Added cmdlet New-IOTProvisioningTemplate leveraging the CreateProvisioningTemplate service API.
    * Added cmdlet New-IOTProvisioningTemplateVersion leveraging the CreateProvisioningTemplateVersion service API.
    * Added cmdlet Remove-IOTDomainConfiguration leveraging the DeleteDomainConfiguration service API.
    * Added cmdlet Remove-IOTProvisioningTemplate leveraging the DeleteProvisioningTemplate service API.
    * Added cmdlet Remove-IOTProvisioningTemplateVersion leveraging the DeleteProvisioningTemplateVersion service API.
    * Added cmdlet Update-IOTDomainConfiguration leveraging the UpdateDomainConfiguration service API.
    * Added cmdlet Update-IOTProvisioningTemplate leveraging the UpdateProvisioningTemplate service API.
    * Modified cmdlet Get-IOTAuditFindingList: added parameters ResourceIdentifier_IamRoleArn and ResourceIdentifier_RoleAliasArn.
    * Modified cmdlet New-IOTAuthorizer: added parameter SigningDisabled.
    * Modified cmdlet New-IOTTopicRule: added parameters IotSiteWise_PutAssetPropertyValueEntry and IotSiteWise_RoleArn.
    * Modified cmdlet Set-IOTTopicRule: added parameters IotSiteWise_PutAssetPropertyValueEntry and IotSiteWise_RoleArn.
    * Modified cmdlet Test-IOTInvokeAuthorizer: added parameters HttpContext_Header, HttpContext_QueryString, MqttContext_ClientId, MqttContext_Password, MqttContext_Username and TlsContext_ServerName.
  * Amazon IoT Secure Tunneling. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTST and can be listed using the command 'Get-AWSCmdletName -Service IOTST'. This release adds support for IoT Secure Tunneling to remote access devices behind restricted firewalls.
  * Amazon Kendra. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KNDR and can be listed using the command 'Get-AWSCmdletName -Service KNDR'. Amazon Kendra is a managed, highly accurate and easy to use enterprise search service that is powered by machine learning.
  * Amazon Key Management Service
    * Added cmdlet Get-KMSPublicKey leveraging the GetPublicKey service API.
    * Added cmdlet Invoke-KMSSigning leveraging the Sign service API.
    * Added cmdlet New-KMSDataKeyPair leveraging the GenerateDataKeyPair service API.
    * Added cmdlet New-KMSDataKeyPairWithoutPlaintext leveraging the GenerateDataKeyPairWithoutPlaintext service API.
    * Added cmdlet Test-KMSSignature leveraging the Verify service API.
    * Modified cmdlet Invoke-KMSDecrypt: added parameters EncryptionAlgorithm and KeyId.
    * Modified cmdlet Invoke-KMSEncrypt: added parameter EncryptionAlgorithm.
    * Modified cmdlet Invoke-KMSReEncrypt: added parameters DestinationEncryptionAlgorithm, SourceEncryptionAlgorithm and SourceKeyId.
    * Modified cmdlet New-KMSKey: added parameter CustomerMasterKeySpec.
  * Amazon Kinesis Analytics V2
    * Added cmdlet Add-KINA2ApplicationVpcConfiguration leveraging the AddApplicationVpcConfiguration service API.
    * Added cmdlet Remove-KINA2ApplicationVpcConfiguration leveraging the DeleteApplicationVpcConfiguration service API.
  * Amazon Kinesis Video Signaling Channels. Added cmdlets to support the service. Cmdlets for the service have the noun prefix KVSC and can be listed using the command 'Get-AWSCmdletName -Service KVSC'. Announcing support for WebRTC in Kinesis Video Streams, as fully managed capability. You can now use simple APIs to enable your connected devices, web, and mobile apps with real-time two-way media streaming capabilities.
  * Amazon Kinesis Video Streams
    * Added cmdlet Add-KVResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KVResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-KVSignalingChannel leveraging the DescribeSignalingChannel service API.
    * Added cmdlet Get-KVSignalingChannelEndpoint leveraging the GetSignalingChannelEndpoint service API.
    * Added cmdlet Get-KVSignalingChannelList leveraging the ListSignalingChannels service API.
    * Added cmdlet New-KVSignalingChannel leveraging the CreateSignalingChannel service API.
    * Added cmdlet Remove-KVResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-KVSignalingChannel leveraging the DeleteSignalingChannel service API.
    * Added cmdlet Update-KVSignalingChannel leveraging the UpdateSignalingChannel service API.
  * Amazon Lambda
    * Added cmdlet Get-LMFunctionConcurrency leveraging the GetFunctionConcurrency service API.
    * Added cmdlet Get-LMFunctionEventInvokeConfig leveraging the GetFunctionEventInvokeConfig service API.
    * Added cmdlet Get-LMFunctionEventInvokeConfigList leveraging the ListFunctionEventInvokeConfigs service API.
    * Added cmdlet Get-LMProvisionedConcurrencyConfig leveraging the GetProvisionedConcurrencyConfig service API.
    * Added cmdlet Get-LMProvisionedConcurrencyConfigList leveraging the ListProvisionedConcurrencyConfigs service API.
    * Added cmdlet Remove-LMFunctionEventInvokeConfig leveraging the DeleteFunctionEventInvokeConfig service API.
    * Added cmdlet Remove-LMProvisionedConcurrencyConfig leveraging the DeleteProvisionedConcurrencyConfig service API.
    * Added cmdlet Update-LMFunctionEventInvokeConfig leveraging the UpdateFunctionEventInvokeConfig service API.
    * Added cmdlet Write-LMFunctionEventInvokeConfig leveraging the PutFunctionEventInvokeConfig service API.
    * Added cmdlet Write-LMProvisionedConcurrencyConfig leveraging the PutProvisionedConcurrencyConfig service API.
    * Modified cmdlet New-LMEventSourceMapping: added parameters BisectBatchOnFunctionError, MaximumRecordAgeInSecond, MaximumRetryAttempt, OnFailure_Destination, OnSuccess_Destination and ParallelizationFactor.
    * Modified cmdlet Update-LMEventSourceMapping: added parameters BisectBatchOnFunctionError, MaximumRecordAgeInSecond, MaximumRetryAttempt, OnFailure_Destination, OnSuccess_Destination and ParallelizationFactor.
  * Amazon License Manager
    * Added cmdlet Get-LICMFailuresForLicenseConfigurationOperationList leveraging the ListFailuresForLicenseConfigurationOperations service API.
    * Modified cmdlet New-LICMLicenseConfiguration: added parameter ProductInformationList.
    * Modified cmdlet Update-LICMLicenseConfiguration: added parameter ProductInformationList.
  * Amazon Managed Streaming for Apache Kafka (MSK)
    * Added cmdlet Update-MSKMonitoring leveraging the UpdateMonitoring service API.
    * Modified cmdlet New-MSKCluster: added parameters JmxExporter_EnabledInBroker and NodeExporter_EnabledInBroker.
  * Amazon Network Manager. Added cmdlets to support the service. Cmdlets for the service have the noun prefix NMGR and can be listed using the command 'Get-AWSCmdletName -Service NMGR'.
  * Amazon Organizations
    * Added cmdlet Get-ORGEffectivePolicy leveraging the DescribeEffectivePolicy service API.
  * Amazon Outposts. Added cmdlets to support the service. Cmdlets for the service have the noun prefix OUTP and can be listed using the command 'Get-AWSCmdletName -Service OUTP'. AWS Outposts is a fully managed service that extends AWS infrastructure, services, APIs, and tools to customer sites. AWS Outposts enables you to launch and run EC2 instances and EBS volumes locally at your on-premises location. This release introduces new APIs for creating and viewing Outposts.
  * Amazon Redshift
    * Added cmdlet Edit-RSScheduledAction leveraging the ModifyScheduledAction service API.
    * Added cmdlet Get-RSScheduledAction leveraging the DescribeScheduledActions service API.
    * Added cmdlet New-RSScheduledAction leveraging the CreateScheduledAction service API.
    * Added cmdlet Remove-RSScheduledAction leveraging the DeleteScheduledAction service API.
    * Modified cmdlet Get-RSNodeConfigurationOption: added parameter ClusterIdentifier.
  * Amazon Rekognition
    * Added cmdlet Find-REKCustomLabel leveraging the DetectCustomLabels service API.
    * Added cmdlet Get-REKProject leveraging the DescribeProjects service API.
    * Added cmdlet Get-REKProjectVersion leveraging the DescribeProjectVersions service API.
    * Added cmdlet New-REKProject leveraging the CreateProject service API.
    * Added cmdlet New-REKProjectVersion leveraging the CreateProjectVersion service API.
    * Added cmdlet Start-REKProjectVersion leveraging the StartProjectVersion service API.
    * Added cmdlet Stop-REKProjectVersion leveraging the StopProjectVersion service API.
    * Modified cmdlet Find-REKModerationLabel: added parameters DataAttributes_ContentClassifier, HumanLoopConfig_FlowDefinitionArn and HumanLoopConfig_HumanLoopName.
  * Amazon Relational Database Service
    * Added cmdlet Edit-RDSDBProxy leveraging the ModifyDBProxy service API.
    * Added cmdlet Edit-RDSDBProxyTargetGroup leveraging the ModifyDBProxyTargetGroup service API.
    * Added cmdlet Get-RDSDBProxy leveraging the DescribeDBProxies service API.
    * Added cmdlet Get-RDSDBProxyTarget leveraging the DescribeDBProxyTargets service API.
    * Added cmdlet Get-RDSDBProxyTargetGroup leveraging the DescribeDBProxyTargetGroups service API.
    * Added cmdlet New-RDSDBProxy leveraging the CreateDBProxy service API.
    * Added cmdlet Register-RDSDBProxyTarget leveraging the RegisterDBProxyTargets service API.
    * Added cmdlet Remove-RDSDBProxy leveraging the DeleteDBProxy service API.
    * Added cmdlet Unregister-RDSDBProxyTarget leveraging the DeregisterDBProxyTargets service API.
    * Modified cmdlet New-RDSDBClusterEndpoint: added parameter Tag.
  * Amazon Resource Access Manager (RAM)
    * Added cmdlet Add-RAMPermissionToResourceShare leveraging the AssociateResourceSharePermission service API.
    * Added cmdlet Convert-RAMPolicyBasedResourceShareToPromoted leveraging the PromoteResourceShareCreatedFromPolicy service API.
    * Added cmdlet Get-RAMPermission leveraging the GetPermission service API.
    * Added cmdlet Get-RAMPermissionList leveraging the ListPermissions service API.
    * Added cmdlet Get-RAMResourceSharePermissionList leveraging the ListResourceSharePermissions service API.
    * Added cmdlet Remove-RAMPermissionFromResourceShare leveraging the DisassociateResourceSharePermission service API.
    * Modified cmdlet New-RAMResourceShare: added parameter PermissionArn.
  * Amazon Resource Groups Tagging API
    * Added cmdlet Get-RGTComplianceSummary leveraging the GetComplianceSummary service API.
    * Added cmdlet Get-RGTReportCreation leveraging the DescribeReportCreation service API.
    * Added cmdlet Start-RGTReportCreation leveraging the StartReportCreation service API.
    * Modified cmdlet Get-RGTResource: added parameters ExcludeCompliantResource and IncludeComplianceDetail.
  * Amazon S3 Control
    * Added cmdlet Get-S3CAccessPoint leveraging the GetAccessPoint service API.
    * Added cmdlet Get-S3CAccessPointList leveraging the ListAccessPoints service API.
    * Added cmdlet Get-S3CAccessPointPolicy leveraging the GetAccessPointPolicy service API.
    * Added cmdlet Get-S3CAccessPointPolicyStatus leveraging the GetAccessPointPolicyStatus service API.
    * Added cmdlet New-S3CAccessPoint leveraging the CreateAccessPoint service API.
    * Added cmdlet Remove-S3CAccessPoint leveraging the DeleteAccessPoint service API.
    * Added cmdlet Remove-S3CAccessPointPolicy leveraging the DeleteAccessPointPolicy service API.
    * Added cmdlet Write-S3CAccessPointPolicy leveraging the PutAccessPointPolicy service API.
  * Amazon SageMaker Runtime
    * Modified cmdlet Invoke-SMREndpoint: added parameter TargetModel.
  * Amazon SageMaker Service
    * Added cmdlet Get-SMApp leveraging the DescribeApp service API.
    * Added cmdlet Get-SMAppList leveraging the ListApps service API.
    * Added cmdlet Get-SMAutoMLJob leveraging the DescribeAutoMLJob service API.
    * Added cmdlet Get-SMAutoMLJobList leveraging the ListAutoMLJobs service API.
    * Added cmdlet Get-SMCandidatesForAutoMLJobList leveraging the ListCandidatesForAutoMLJob service API.
    * Added cmdlet Get-SMDomain leveraging the DescribeDomain service API.
    * Added cmdlet Get-SMDomainList leveraging the ListDomains service API.
    * Added cmdlet Get-SMExperiment leveraging the DescribeExperiment service API.
    * Added cmdlet Get-SMExperimentList leveraging the ListExperiments service API.
    * Added cmdlet Get-SMFlowDefinition leveraging the DescribeFlowDefinition service API.
    * Added cmdlet Get-SMFlowDefinitionList leveraging the ListFlowDefinitions service API.
    * Added cmdlet Get-SMHumanTaskUi leveraging the DescribeHumanTaskUi service API.
    * Added cmdlet Get-SMHumanTaskUiList leveraging the ListHumanTaskUis service API.
    * Added cmdlet Get-SMMonitoringExecutionList leveraging the ListMonitoringExecutions service API.
    * Added cmdlet Get-SMMonitoringSchedule leveraging the DescribeMonitoringSchedule service API.
    * Added cmdlet Get-SMMonitoringScheduleList leveraging the ListMonitoringSchedules service API.
    * Added cmdlet Get-SMProcessingJob leveraging the DescribeProcessingJob service API.
    * Added cmdlet Get-SMProcessingJobList leveraging the ListProcessingJobs service API.
    * Added cmdlet Get-SMTrial leveraging the DescribeTrial service API.
    * Added cmdlet Get-SMTrialComponent leveraging the DescribeTrialComponent service API.
    * Added cmdlet Get-SMTrialComponentList leveraging the ListTrialComponents service API.
    * Added cmdlet Get-SMTrialList leveraging the ListTrials service API.
    * Added cmdlet Get-SMUserProfile leveraging the DescribeUserProfile service API.
    * Added cmdlet Get-SMUserProfileList leveraging the ListUserProfiles service API.
    * Added cmdlet New-SMApp leveraging the CreateApp service API.
    * Added cmdlet New-SMAutoMLJob leveraging the CreateAutoMLJob service API.
    * Added cmdlet New-SMDomain leveraging the CreateDomain service API.
    * Added cmdlet New-SMExperiment leveraging the CreateExperiment service API.
    * Added cmdlet New-SMFlowDefinition leveraging the CreateFlowDefinition service API.
    * Added cmdlet New-SMHumanTaskUi leveraging the CreateHumanTaskUi service API.
    * Added cmdlet New-SMMonitoringSchedule leveraging the CreateMonitoringSchedule service API.
    * Added cmdlet New-SMPresignedDomainUrl leveraging the CreatePresignedDomainUrl service API.
    * Added cmdlet New-SMProcessingJob leveraging the CreateProcessingJob service API.
    * Added cmdlet New-SMTrial leveraging the CreateTrial service API.
    * Added cmdlet New-SMTrialComponent leveraging the CreateTrialComponent service API.
    * Added cmdlet New-SMUserProfile leveraging the CreateUserProfile service API.
    * Added cmdlet Register-SMTrialComponent leveraging the AssociateTrialComponent service API.
    * Added cmdlet Remove-SMApp leveraging the DeleteApp service API.
    * Added cmdlet Remove-SMDomain leveraging the DeleteDomain service API.
    * Added cmdlet Remove-SMExperiment leveraging the DeleteExperiment service API.
    * Added cmdlet Remove-SMFlowDefinition leveraging the DeleteFlowDefinition service API.
    * Added cmdlet Remove-SMMonitoringSchedule leveraging the DeleteMonitoringSchedule service API.
    * Added cmdlet Remove-SMTrial leveraging the DeleteTrial service API.
    * Added cmdlet Remove-SMTrialComponent leveraging the DeleteTrialComponent service API.
    * Added cmdlet Remove-SMUserProfile leveraging the DeleteUserProfile service API.
    * Added cmdlet Start-SMMonitoringSchedule leveraging the StartMonitoringSchedule service API.
    * Added cmdlet Stop-SMAutoMLJob leveraging the StopAutoMLJob service API.
    * Added cmdlet Stop-SMMonitoringSchedule leveraging the StopMonitoringSchedule service API.
    * Added cmdlet Stop-SMProcessingJob leveraging the StopProcessingJob service API.
    * Added cmdlet Unregister-SMTrialComponent leveraging the DisassociateTrialComponent service API.
    * Added cmdlet Update-SMDomain leveraging the UpdateDomain service API.
    * Added cmdlet Update-SMExperiment leveraging the UpdateExperiment service API.
    * Added cmdlet Update-SMMonitoringSchedule leveraging the UpdateMonitoringSchedule service API.
    * Added cmdlet Update-SMTrial leveraging the UpdateTrial service API.
    * Added cmdlet Update-SMTrialComponent leveraging the UpdateTrialComponent service API.
    * Added cmdlet Update-SMUserProfile leveraging the UpdateUserProfile service API.
    * Modified cmdlet New-SMEndpointConfig: added parameters CaptureContentTypeHeader_CsvContentType, CaptureContentTypeHeader_JsonContentType, DataCaptureConfig_CaptureOption, DataCaptureConfig_DestinationS3Uri, DataCaptureConfig_EnableCapture, DataCaptureConfig_InitialSamplingPercentage and DataCaptureConfig_KmsKeyId.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameters HyperParameterRanges_CategoricalParameterRange, HyperParameterRanges_ContinuousParameterRange, HyperParameterRanges_IntegerParameterRange, TrainingJobDefinition, TrainingJobDefinition_DefinitionName, TuningJobCompletionCriteria_TargetObjectiveMetricValue, TuningObjective_MetricName and TuningObjective_Type.
    * Modified cmdlet New-SMTrainingJob: added parameters DebugHookConfig_CollectionConfiguration, DebugHookConfig_HookParameter, DebugHookConfig_LocalPath, DebugHookConfig_S3OutputPath, DebugRuleConfiguration, ExperimentConfig_ExperimentName, ExperimentConfig_TrialComponentDisplayName, ExperimentConfig_TrialName, TensorBoardOutputConfig_LocalPath and TensorBoardOutputConfig_S3OutputPath.
    * Modified cmdlet New-SMTransformJob: added parameters ExperimentConfig_ExperimentName, ExperimentConfig_TrialComponentDisplayName and ExperimentConfig_TrialName.
  * Amazon Simple Email Service V2 (SES V2)
    * Added cmdlet Get-SES2SuppressedDestination leveraging the GetSuppressedDestination service API.
    * Added cmdlet Get-SES2SuppressedDestinationList leveraging the ListSuppressedDestinations service API.
    * Added cmdlet Remove-SES2SuppressedDestination leveraging the DeleteSuppressedDestination service API.
    * Added cmdlet Write-SES2AccountSuppressionAttribute leveraging the PutAccountSuppressionAttributes service API.
    * Added cmdlet Write-SES2ConfigurationSetSuppressionOption leveraging the PutConfigurationSetSuppressionOptions service API.
    * Added cmdlet Write-SES2SuppressedDestination leveraging the PutSuppressedDestination service API.
    * Modified cmdlet New-SES2ConfigurationSet: added parameter SuppressionOptions_SuppressedReason.
  * Amazon Step Functions
    * Modified cmdlet New-SFNStateMachine: added parameters LoggingConfiguration_Destination, LoggingConfiguration_IncludeExecutionData, LoggingConfiguration_Level and Type.
    * Modified cmdlet Update-SFNStateMachine: added parameters LoggingConfiguration_Destination, LoggingConfiguration_IncludeExecutionData and LoggingConfiguration_Level.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMCalendarState leveraging the GetCalendarState service API.
    * Modified cmdlet Edit-SSMDocumentPermission: added parameter SharedDocumentVersion.
    * Modified cmdlet New-SSMDocument: added parameter Require.
    * Modified cmdlet Remove-SSMDocument: added parameter Enforce.
  * Amazon Textract
    * Modified cmdlet Invoke-TXTDocumentAnalysis: added parameters DataAttributes_ContentClassifier, HumanLoopConfig_FlowDefinitionArn and HumanLoopConfig_HumanLoopName.
  * Amazon WAF V2. Added cmdlets to support the service. Cmdlets for the service have the noun prefix WAF2 and can be listed using the command 'Get-AWSCmdletName -Service WAF2'. This release introduces new set of APIs (wafv2) for AWS WAF. Major changes include single set of APIs for creating/updating resources in global and regional scope, and rules are configured directly into web ACL instead of being referenced. The previous APIs (waf and waf-regional) are now referred as AWS WAF Classic. For more information visit: https://docs.aws.amazon.com/waf/latest/APIReference/Welcome.html

### 4.0.1.1 (2019-11-25)
  * Fixed an issue where an older version of AWSSDK.SageMakerRuntime was included in the modules resulting in the MSI installer being non functional.

### 4.0.1.0 (2019-11-25)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.637.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Fixed Get-AWSCmdletName returning wrong cmdlet names.
  * Fixed error in AWS.Tools.Installer.
  * Amazon Amplify
    * Added cmdlet Get-AMPBackendEnvironment leveraging the GetBackendEnvironment service API.
    * Added cmdlet Get-AMPBackendEnvironmentList leveraging the ListBackendEnvironments service API.
    * Added cmdlet New-AMPBackendEnvironment leveraging the CreateBackendEnvironment service API.
    * Added cmdlet Remove-AMPBackendEnvironment leveraging the DeleteBackendEnvironment service API.
    * Modified cmdlet New-AMPApp: added parameter AutoBranchCreationConfig_PullRequestEnvironmentName.
    * Modified cmdlet New-AMPBranch: added parameters BackendEnvironmentArn and PullRequestEnvironmentName.
    * Modified cmdlet Update-AMPApp: added parameter AutoBranchCreationConfig_PullRequestEnvironmentName.
    * Modified cmdlet Update-AMPBranch: added parameters BackendEnvironmentArn and PullRequestEnvironmentName.
  * Amazon AppSync
    * Added cmdlet Clear-ASYNApiCache leveraging the FlushApiCache service API.
    * Added cmdlet Get-ASYNApiCache leveraging the GetApiCache service API.
    * Added cmdlet New-ASYNApiCache leveraging the CreateApiCache service API.
    * Added cmdlet Remove-ASYNApiCache leveraging the DeleteApiCache service API.
    * Added cmdlet Update-ASYNApiCache leveraging the UpdateApiCache service API.
    * Modified cmdlet New-ASYNResolver: added parameters CachingConfig_CachingKey, CachingConfig_Ttl, LambdaConflictHandlerConfig_LambdaConflictHandlerArn, SyncConfig_ConflictDetection and SyncConfig_ConflictHandler.
    * Modified cmdlet Update-ASYNResolver: added parameters CachingConfig_CachingKey, CachingConfig_Ttl, LambdaConflictHandlerConfig_LambdaConflictHandlerArn, SyncConfig_ConflictDetection and SyncConfig_ConflictHandler.
  * Amazon Auto Scaling
    * Modified cmdlet New-ASAutoScalingGroup: added parameter MaxInstanceLifetime.
    * Modified cmdlet Update-ASAutoScalingGroup: added parameter MaxInstanceLifetime.
  * Amazon Certificate Manager
    * Modified cmdlet Import-ACMCertificate: added parameter Tag.
    * Modified cmdlet New-ACMCertificate: added parameter Tag.
  * Amazon Chime
    * Added cmdlet Get-CHMAttendee leveraging the GetAttendee service API.
    * Added cmdlet Get-CHMAttendeeList leveraging the ListAttendees service API.
    * Added cmdlet Get-CHMMeeting leveraging the GetMeeting service API.
    * Added cmdlet Get-CHMMeetingList leveraging the ListMeetings service API.
    * Added cmdlet Get-CHMRoom leveraging the GetRoom service API.
    * Added cmdlet Get-CHMRoomList leveraging the ListRooms service API.
    * Added cmdlet Get-CHMRoomMembershipList leveraging the ListRoomMemberships service API.
    * Added cmdlet New-CHMAttendee leveraging the CreateAttendee service API.
    * Added cmdlet New-CHMAttendeeBatch leveraging the BatchCreateAttendee service API.
    * Added cmdlet New-CHMMeeting leveraging the CreateMeeting service API.
    * Added cmdlet New-CHMRoom leveraging the CreateRoom service API.
    * Added cmdlet New-CHMRoomMembership leveraging the CreateRoomMembership service API.
    * Added cmdlet New-CHMRoomMembershipBatch leveraging the BatchCreateRoomMembership service API.
    * Added cmdlet Remove-CHMAttendee leveraging the DeleteAttendee service API.
    * Added cmdlet Remove-CHMMeeting leveraging the DeleteMeeting service API.
    * Added cmdlet Remove-CHMRoom leveraging the DeleteRoom service API.
    * Added cmdlet Remove-CHMRoomMembership leveraging the DeleteRoomMembership service API.
    * Added cmdlet Update-CHMRoom leveraging the UpdateRoom service API.
    * Added cmdlet Update-CHMRoomMembership leveraging the UpdateRoomMembership service API.
  * Amazon CloudFormation
    * Added cmdlet Get-CFNType leveraging the DescribeType service API.
    * Added cmdlet Get-CFNTypeList leveraging the ListTypes service API.
    * Added cmdlet Get-CFNTypeRegistration leveraging the DescribeTypeRegistration service API.
    * Added cmdlet Get-CFNTypeRegistrationList leveraging the ListTypeRegistrations service API.
    * Added cmdlet Get-CFNTypeVersion leveraging the ListTypeVersions service API.
    * Added cmdlet Register-CFNType leveraging the RegisterType service API.
    * Added cmdlet Set-CFNTypeDefaultVersion leveraging the SetTypeDefaultVersion service API.
    * Added cmdlet Start-CFNStackSetDriftDetection leveraging the DetectStackSetDrift service API.
    * Added cmdlet Unregister-CFNType leveraging the DeregisterType service API.
    * Added cmdlet Write-CFNHandlerProgress leveraging the RecordHandlerProgress service API.
    * Modified cmdlet New-CFNChangeSet: added parameter ResourcesToImport.
  * Amazon CloudSearch
    * Added cmdlet Get-CSDomainEndpointOption leveraging the DescribeDomainEndpointOptions service API.
    * Added cmdlet Update-CSDomainEndpointOption leveraging the UpdateDomainEndpointOptions service API.
  * Amazon CloudTrail
    * Added cmdlet Get-CTInsightSelector leveraging the GetInsightSelectors service API.
    * Added cmdlet Get-CTTrailByName leveraging the GetTrail service API.
    * Added cmdlet Get-CTTrailSummary leveraging the ListTrails service API.
    * Added cmdlet Write-CTInsightSelector leveraging the PutInsightSelectors service API.
    * Modified cmdlet Find-CTEvent: added parameter EventCategory.
    * Modified cmdlet New-CTTrail: added parameter TagsList.
  * Amazon CodeCommit
    * Added cmdlet Add-CCApprovalRuleTemplateToRepository leveraging the AssociateApprovalRuleTemplateWithRepository service API.
    * Added cmdlet Add-CCApprovalRuleTemplateToRepositoryBatch leveraging the BatchAssociateApprovalRuleTemplateWithRepositories service API.
    * Added cmdlet Get-CCApprovalRuleTemplate leveraging the GetApprovalRuleTemplate service API.
    * Added cmdlet Get-CCApprovalRuleTemplateList leveraging the ListApprovalRuleTemplates service API.
    * Added cmdlet Get-CCAssociatedApprovalRuleTemplatesForRepositoryList leveraging the ListAssociatedApprovalRuleTemplatesForRepository service API.
    * Added cmdlet Get-CCPullRequestApprovalState leveraging the GetPullRequestApprovalStates service API.
    * Added cmdlet Get-CCPullRequestOverrideState leveraging the GetPullRequestOverrideState service API.
    * Added cmdlet Get-CCRepositoriesForApprovalRuleTemplateList leveraging the ListRepositoriesForApprovalRuleTemplate service API.
    * Added cmdlet Invoke-CCPullRequestApprovalRule leveraging the EvaluatePullRequestApprovalRules service API.
    * Added cmdlet New-CCApprovalRuleTemplate leveraging the CreateApprovalRuleTemplate service API.
    * Added cmdlet New-CCPullRequestApprovalRule leveraging the CreatePullRequestApprovalRule service API.
    * Added cmdlet Remove-CCApprovalRuleTemplate leveraging the DeleteApprovalRuleTemplate service API.
    * Added cmdlet Remove-CCApprovalRuleTemplateFromRepository leveraging the DisassociateApprovalRuleTemplateFromRepository service API.
    * Added cmdlet Remove-CCApprovalRuleTemplateFromRepositoryBatch leveraging the BatchDisassociateApprovalRuleTemplateFromRepositories service API.
    * Added cmdlet Remove-CCPullRequestApprovalRule leveraging the DeletePullRequestApprovalRule service API.
    * Added cmdlet Skip-CCPullRequestApprovalRule leveraging the OverridePullRequestApprovalRules service API.
    * Added cmdlet Update-CCApprovalRuleTemplateContent leveraging the UpdateApprovalRuleTemplateContent service API.
    * Added cmdlet Update-CCApprovalRuleTemplateDescription leveraging the UpdateApprovalRuleTemplateDescription service API.
    * Added cmdlet Update-CCApprovalRuleTemplateName leveraging the UpdateApprovalRuleTemplateName service API.
    * Added cmdlet Update-CCPullRequestApprovalRuleContent leveraging the UpdatePullRequestApprovalRuleContent service API.
    * Added cmdlet Update-CCPullRequestApprovalState leveraging the UpdatePullRequestApprovalState service API.
  * Amazon CodePipeline
    * Modified cmdlet Write-CPJobSuccessResult: added parameter OutputVariable.
  * Amazon CodeStar Notifications. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CSTN and can be listed using the command 'Get-AWSCmdletName -Service CSTN'. You can now configure rules and receive notifications about events that occur for resources. Each notification includes a status message as well as a link to the resource (repository, build project, deployment application, or pipeline) whose event generated the notification.
  * Amazon Cognito Identity
    * Modified cmdlet New-CGIIdentityPool: added parameter AllowClassicFlow.
    * Modified cmdlet Update-CGIIdentityPool: added parameter AllowClassicFlow.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameters EmailConfiguration_ConfigurationSet and EmailConfiguration_From.
    * Modified cmdlet New-CGIPUserPoolClient: added parameter PreventUserExistenceError.
    * Modified cmdlet Update-CGIPUserPool: added parameters EmailConfiguration_ConfigurationSet and EmailConfiguration_From.
    * Modified cmdlet Update-CGIPUserPoolClient: added parameter PreventUserExistenceError.
  * Amazon Config
    * Added cmdlet Get-CFGConformancePack leveraging the DescribeConformancePacks service API.
    * Added cmdlet Get-CFGConformancePackCompliance leveraging the DescribeConformancePackCompliance service API.
    * Added cmdlet Get-CFGConformancePackComplianceDetail leveraging the GetConformancePackComplianceDetails service API.
    * Added cmdlet Get-CFGConformancePackComplianceSummary leveraging the GetConformancePackComplianceSummary service API.
    * Added cmdlet Get-CFGConformancePackStatus leveraging the DescribeConformancePackStatus service API.
    * Added cmdlet Get-CFGOrganizationConformancePack leveraging the DescribeOrganizationConformancePacks service API.
    * Added cmdlet Get-CFGOrganizationConformancePackDetailedStatus leveraging the GetOrganizationConformancePackDetailedStatus service API.
    * Added cmdlet Get-CFGOrganizationConformancePackStatus leveraging the DescribeOrganizationConformancePackStatuses service API.
    * Added cmdlet Remove-CFGConformancePack leveraging the DeleteConformancePack service API.
    * Added cmdlet Remove-CFGOrganizationConformancePack leveraging the DeleteOrganizationConformancePack service API.
    * Added cmdlet Remove-CFGResourceConfig leveraging the DeleteResourceConfig service API.
    * Added cmdlet Write-CFGConformancePack leveraging the PutConformancePack service API.
    * Added cmdlet Write-CFGOrganizationConformancePack leveraging the PutOrganizationConformancePack service API.
    * Added cmdlet Write-CFGResourceConfig leveraging the PutResourceConfig service API.
  * Amazon Connect Participant Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CONNP and can be listed using the command 'Get-AWSCmdletName -Service CONNP'. You can use them to programmatically perform participant actions on the configured Amazon Connect instance.
  * Amazon Connect Service
    * Added cmdlet Add-CONNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CONNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CONNResourceTag leveraging the UntagResource service API.
    * Added cmdlet Start-CONNChatContact leveraging the StartChatContact service API.
    * Modified cmdlet New-CONNUser: added parameter Tag.
  * Amazon Cost Explorer
    * Added cmdlet Get-CECostAndUsageWithResource leveraging the GetCostAndUsageWithResources service API.
    * Added cmdlet Get-CESavingsPlansCoverage leveraging the GetSavingsPlansCoverage service API.
    * Added cmdlet Get-CESavingsPlansPurchaseRecommendation leveraging the GetSavingsPlansPurchaseRecommendation service API.
    * Added cmdlet Get-CESavingsPlansUtilization leveraging the GetSavingsPlansUtilization service API.
    * Added cmdlet Get-CESavingsPlansUtilizationDetail leveraging the GetSavingsPlansUtilizationDetails service API.
  * Amazon Data Exchange. Added cmdlets to support the service. Cmdlets for the service have the noun prefix DTEX and can be listed using the command 'Get-AWSCmdletName -Service DTEX'. AWS Data Exchange is a service that makes it easy for AWS customers to securely create, manage, access, and exchange data sets in the cloud.
  * Amazon Data Lifecycle Manager
    * Added cmdlet Add-DLMResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-DLMResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-DLMResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-DLMLifecyclePolicy: added parameter Tag.
  * Amazon DataSync
    * Modified cmdlet New-DSYNTask: added parameter Schedule_ScheduleExpression.
    * Modified cmdlet Update-DSYNTask: added parameter Schedule_ScheduleExpression.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBTableReplicaAutoScaling leveraging the DescribeTableReplicaAutoScaling service API.
    * Added cmdlet Update-DDBTableReplicaAutoScaling leveraging the UpdateTableReplicaAutoScaling service API.
    * Modified cmdlet Restore-DDBTableFromBackup: added parameters BillingModeOverride, GlobalSecondaryIndexOverride, LocalSecondaryIndexOverride, ProvisionedThroughputOverride_ReadCapacityUnit and ProvisionedThroughputOverride_WriteCapacityUnit.
    * Modified cmdlet Restore-DDBTableToPointInTime: added parameters BillingModeOverride, GlobalSecondaryIndexOverride, LocalSecondaryIndexOverride, ProvisionedThroughputOverride_ReadCapacityUnit and ProvisionedThroughputOverride_WriteCapacityUnit.
    * Modified cmdlet Update-DDBTable: added parameter ReplicaUpdate.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSTask: added parameters Overrides_Cpu, Overrides_Memory and ReferenceId.
    * Modified cmdlet Start-ECSTask: added parameters Overrides_Cpu, Overrides_Memory and ReferenceId.
  * Amazon Elastic Compute Cloud (EC2)
    * Added cmdlet Disable-EC2FastSnapshotRestore leveraging the DisableFastSnapshotRestores service API.
    * Added cmdlet Edit-EC2InstanceMetadataOption leveraging the ModifyInstanceMetadataOptions service API.
    * Added cmdlet Enable-EC2FastSnapshotRestore leveraging the EnableFastSnapshotRestores service API.
    * Added cmdlet Get-EC2FastSnapshotRestore leveraging the DescribeFastSnapshotRestores service API.
    * Added cmdlet Get-EC2InstanceType leveraging the DescribeInstanceTypes service API.
    * Added cmdlet Get-EC2InstanceTypeOffering leveraging the DescribeInstanceTypeOfferings service API.
    * Modified cmdlet New-EC2Instance: added parameters MetadataOptions_HttpEndpoint, MetadataOptions_HttpPutResponseHopLimit and MetadataOptions_HttpToken.
    * Modified cmdlet Copy-EC2Snapshot: added parameter TagSpecification.
    * Modified cmdlet Edit-EC2Host: added parameters InstanceFamily and InstanceType.
    * Modified cmdlet Import-EC2Image: added parameter LicenseSpecification.
    * Modified cmdlet New-EC2CustomerGateway: added parameter DeviceName.
    * Modified cmdlet New-EC2Host: added parameter InstanceFamily.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Get-EKSNodegroup leveraging the DescribeNodegroup service API.
    * Added cmdlet Get-EKSNodegroupList leveraging the ListNodegroups service API.
    * Added cmdlet New-EKSNodegroup leveraging the CreateNodegroup service API.
    * Added cmdlet Remove-EKSNodegroup leveraging the DeleteNodegroup service API.
    * Added cmdlet Update-EKSNodegroupConfig leveraging the UpdateNodegroupConfig service API.
    * Added cmdlet Update-EKSNodegroupVersion leveraging the UpdateNodegroupVersion service API.
    * Modified cmdlet Get-EKSUpdate: added parameter NodegroupName.
    * Modified cmdlet Get-EKSUpdateList: added parameter NodegroupName.
  * Amazon Elastic MapReduce
    * Added cmdlet Edit-EMRCluster leveraging the ModifyCluster service API.
    * Modified cmdlet Start-EMRJobFlow: added parameter StepConcurrencyLevel.
    * Modified cmdlet Stop-EMRStep: added parameter StepCancellationOption.
  * Amazon ElastiCache
    * Modified cmdlet Edit-ECCacheCluster: added parameters AuthToken and AuthTokenUpdateStrategy.
    * Modified cmdlet Edit-ECReplicationGroup: added parameters AuthToken and AuthTokenUpdateStrategy.
  * Amazon Forecast Service
    * Modified cmdlet New-FRCForecast: added parameter ForecastType.
  * Amazon Glue
    * Modified cmdlet Get-GLUEMLTransformList: added parameter Filter_GlueVersion.
    * Modified cmdlet New-GLUEMLTransform: added parameter GlueVersion.
    * Modified cmdlet Update-GLUEMLTransform: added parameter GlueVersion.
  * Amazon GuardDuty
    * Added cmdlet Get-GDPublishingDestination leveraging the DescribePublishingDestination service API.
    * Added cmdlet Get-GDPublishingDestinationList leveraging the ListPublishingDestinations service API.
    * Added cmdlet New-GDPublishingDestination leveraging the CreatePublishingDestination service API.
    * Added cmdlet Remove-GDPublishingDestination leveraging the DeletePublishingDestination service API.
    * Added cmdlet Update-GDPublishingDestination leveraging the UpdatePublishingDestination service API.
  * Amazon IoT
    * Added cmdlet Confirm-IOTTopicRuleDestination leveraging the ConfirmTopicRuleDestination service API.
    * Added cmdlet Get-IOTCardinality leveraging the GetCardinality service API.
    * Added cmdlet Get-IOTPercentile leveraging the GetPercentiles service API.
    * Added cmdlet Get-IOTTopicRuleDestination leveraging the GetTopicRuleDestination service API.
    * Added cmdlet Get-IOTTopicRuleDestinationList leveraging the ListTopicRuleDestinations service API.
    * Added cmdlet New-IOTTopicRuleDestination leveraging the CreateTopicRuleDestination service API.
    * Added cmdlet Remove-IOTTopicRuleDestination leveraging the DeleteTopicRuleDestination service API.
    * Added cmdlet Update-IOTTopicRuleDestination leveraging the UpdateTopicRuleDestination service API.
    * Modified cmdlet New-IOTTopicRule: added parameters Http_ConfirmationUrl, Http_Header, Http_Url, Sigv4_RoleArn, Sigv4_ServiceName and Sigv4_SigningRegion.
    * Modified cmdlet Set-IOTTopicRule: added parameters Http_ConfirmationUrl, Http_Header, Http_Url, Sigv4_RoleArn, Sigv4_ServiceName and Sigv4_SigningRegion.
    * Modified cmdlet Update-IOTIndexingConfiguration: added parameters ThingGroupIndexingConfiguration_CustomField, ThingGroupIndexingConfiguration_ManagedField, ThingIndexingConfiguration_CustomField and ThingIndexingConfiguration_ManagedField.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameters DeliveryStreamEncryptionConfigurationInput_KeyARN and DeliveryStreamEncryptionConfigurationInput_KeyType.
    * Modified cmdlet Remove-KINFDeliveryStream: added parameter AllowForceDelete.
    * Modified cmdlet Start-KINFDeliveryStreamEncryption: added parameters DeliveryStreamEncryptionConfigurationInput_KeyARN and DeliveryStreamEncryptionConfigurationInput_KeyType.
  * Amazon Lambda
    * Modified cmdlet Publish-LMFunction: added parameter Environment_IsVariablesSet.
    * Modified cmdlet Update-LMFunctionConfiguration: added parameter Environment_IsVariablesSet.
  * Amazon Lex Model Building Service
    * Modified cmdlet Write-LMBBot: added parameter DetectSentiment.
  * Amazon Marketplace Catalog Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MCAT and can be listed using the command 'Get-AWSCmdletName -Service MCAT'. AWS Marketplace Catalog service allows you to list, describe and manage change requests on your published entities on AWS Marketplace.
  * Amazon Migration Hub
    * Modified cmdlet Send-MHApplicationStateNotification: added parameter UpdateDateTime.
  * Amazon Migration Hub Config. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MHC and can be listed using the command 'Get-AWSCmdletName -Service MHC'. AWS Migration Hub Config Service allows you to get and set the Migration Hub home region for use with AWS Migration Hub and Application Discovery Service.
  * Amazon Personalize
    * Added cmdlet Get-PERSBatchInferenceJob leveraging the DescribeBatchInferenceJob service API.
    * Added cmdlet Get-PERSBatchInferenceJobList leveraging the ListBatchInferenceJobs service API.
    * Added cmdlet New-PERSBatchInferenceJob leveraging the CreateBatchInferenceJob service API.
  * Amazon Pinpoint
    * Added cmdlet Get-PINJourney leveraging the GetJourney service API.
    * Added cmdlet Get-PINJourneyDateRangeKpi leveraging the GetJourneyDateRangeKpi service API.
    * Added cmdlet Get-PINJourneyExecutionActivityMetric leveraging the GetJourneyExecutionActivityMetrics service API.
    * Added cmdlet Get-PINJourneyExecutionMetric leveraging the GetJourneyExecutionMetrics service API.
    * Added cmdlet Get-PINJourneyList leveraging the ListJourneys service API.
    * Added cmdlet Get-PINVoiceTemplate leveraging the GetVoiceTemplate service API.
    * Added cmdlet New-PINJourney leveraging the CreateJourney service API.
    * Added cmdlet New-PINVoiceTemplate leveraging the CreateVoiceTemplate service API.
    * Added cmdlet Remove-PINJourney leveraging the DeleteJourney service API.
    * Added cmdlet Remove-PINVoiceTemplate leveraging the DeleteVoiceTemplate service API.
    * Added cmdlet Update-PINJourney leveraging the UpdateJourney service API.
    * Added cmdlet Update-PINJourneyState leveraging the UpdateJourneyState service API.
    * Added cmdlet Update-PINVoiceTemplate leveraging the UpdateVoiceTemplate service API.
    * Modified cmdlet New-PINCampaign: added parameter VoiceTemplate_Name.
    * Modified cmdlet New-PINEmailTemplate: added parameters EmailTemplateRequest_DefaultSubstitution and EmailTemplateRequest_TemplateDescription.
    * Modified cmdlet New-PINPushTemplate: added parameters ADM_RawContent, APNS_RawContent, Baidu_RawContent, GCM_RawContent, PushNotificationTemplateRequest_DefaultSubstitution and PushNotificationTemplateRequest_TemplateDescription.
    * Modified cmdlet New-PINSmsTemplate: added parameters SMSTemplateRequest_DefaultSubstitution and SMSTemplateRequest_TemplateDescription.
    * Modified cmdlet Send-PINMessage: added parameters APNSMessage_APNSPushType and VoiceTemplate_Name.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters APNSMessage_APNSPushType and VoiceTemplate_Name.
    * Modified cmdlet Update-PINCampaign: added parameter VoiceTemplate_Name.
    * Modified cmdlet Update-PINEmailTemplate: added parameters EmailTemplateRequest_DefaultSubstitution and EmailTemplateRequest_TemplateDescription.
    * Modified cmdlet Update-PINPushTemplate: added parameters ADM_RawContent, APNS_RawContent, Baidu_RawContent, GCM_RawContent, PushNotificationTemplateRequest_DefaultSubstitution and PushNotificationTemplateRequest_TemplateDescription.
    * Modified cmdlet Update-PINSmsTemplate: added parameters SMSTemplateRequest_DefaultSubstitution and SMSTemplateRequest_TemplateDescription.
  * Amazon QuickSight
    * Added cmdlet Add-QSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-QSDashboard leveraging the DescribeDashboard service API.
    * Added cmdlet Get-QSDashboardList leveraging the ListDashboards service API.
    * Added cmdlet Get-QSDashboardPermission leveraging the DescribeDashboardPermissions service API.
    * Added cmdlet Get-QSDashboardVersionList leveraging the ListDashboardVersions service API.
    * Added cmdlet Get-QSDataSet leveraging the DescribeDataSet service API.
    * Added cmdlet Get-QSDataSetList leveraging the ListDataSets service API.
    * Added cmdlet Get-QSDataSetPermission leveraging the DescribeDataSetPermissions service API.
    * Added cmdlet Get-QSDataSource leveraging the DescribeDataSource service API.
    * Added cmdlet Get-QSDataSourceList leveraging the ListDataSources service API.
    * Added cmdlet Get-QSDataSourcePermission leveraging the DescribeDataSourcePermissions service API.
    * Added cmdlet Get-QSIAMPolicyAssignment leveraging the DescribeIAMPolicyAssignment service API.
    * Added cmdlet Get-QSIAMPolicyAssignmentList leveraging the ListIAMPolicyAssignments service API.
    * Added cmdlet Get-QSIAMPolicyAssignmentsForUserList leveraging the ListIAMPolicyAssignmentsForUser service API.
    * Added cmdlet Get-QSIngestion leveraging the DescribeIngestion service API.
    * Added cmdlet Get-QSIngestionList leveraging the ListIngestions service API.
    * Added cmdlet Get-QSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-QSTemplate leveraging the DescribeTemplate service API.
    * Added cmdlet Get-QSTemplateAlias leveraging the DescribeTemplateAlias service API.
    * Added cmdlet Get-QSTemplateAliasList leveraging the ListTemplateAliases service API.
    * Added cmdlet Get-QSTemplateList leveraging the ListTemplates service API.
    * Added cmdlet Get-QSTemplatePermission leveraging the DescribeTemplatePermissions service API.
    * Added cmdlet Get-QSTemplateVersionList leveraging the ListTemplateVersions service API.
    * Added cmdlet New-QSDashboard leveraging the CreateDashboard service API.
    * Added cmdlet New-QSDataSet leveraging the CreateDataSet service API.
    * Added cmdlet New-QSDataSource leveraging the CreateDataSource service API.
    * Added cmdlet New-QSIAMPolicyAssignment leveraging the CreateIAMPolicyAssignment service API.
    * Added cmdlet New-QSIngestion leveraging the CreateIngestion service API.
    * Added cmdlet New-QSTemplate leveraging the CreateTemplate service API.
    * Added cmdlet New-QSTemplateAlias leveraging the CreateTemplateAlias service API.
    * Added cmdlet Remove-QSDashboard leveraging the DeleteDashboard service API.
    * Added cmdlet Remove-QSDataSet leveraging the DeleteDataSet service API.
    * Added cmdlet Remove-QSDataSource leveraging the DeleteDataSource service API.
    * Added cmdlet Remove-QSIAMPolicyAssignment leveraging the DeleteIAMPolicyAssignment service API.
    * Added cmdlet Remove-QSResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-QSTemplate leveraging the DeleteTemplate service API.
    * Added cmdlet Remove-QSTemplateAlias leveraging the DeleteTemplateAlias service API.
    * Added cmdlet Stop-QSIngestion leveraging the CancelIngestion service API.
    * Added cmdlet Update-QSDashboard leveraging the UpdateDashboard service API.
    * Added cmdlet Update-QSDashboardPermission leveraging the UpdateDashboardPermissions service API.
    * Added cmdlet Update-QSDashboardPublishedVersion leveraging the UpdateDashboardPublishedVersion service API.
    * Added cmdlet Update-QSDataSet leveraging the UpdateDataSet service API.
    * Added cmdlet Update-QSDataSetPermission leveraging the UpdateDataSetPermissions service API.
    * Added cmdlet Update-QSDataSource leveraging the UpdateDataSource service API.
    * Added cmdlet Update-QSDataSourcePermission leveraging the UpdateDataSourcePermissions service API.
    * Added cmdlet Update-QSIAMPolicyAssignment leveraging the UpdateIAMPolicyAssignment service API.
    * Added cmdlet Update-QSTemplate leveraging the UpdateTemplate service API.
    * Added cmdlet Update-QSTemplateAlias leveraging the UpdateTemplateAlias service API.
    * Added cmdlet Update-QSTemplatePermission leveraging the UpdateTemplatePermissions service API.
  * Amazon Rekognition
    * Modified cmdlet Compare-REKFace: added parameter QualityFilter.
    * Modified cmdlet Search-REKFacesByImage: added parameter QualityFilter.
  * Amazon Savings Plans. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SP and can be listed using the command 'Get-AWSCmdletName -Service SP'. Savings Plans is a new flexible pricing model that offers low prices on Amazon EC2 and AWS Fargate usage.
  * Amazon Security Token Service
    * Modified cmdlet Get-STSFederationToken: added parameter Tag.
    * Modified cmdlet Use-STSRole: added parameters Tag and TransitiveTagKey.
  * Amazon Simple Email Service V2 (SES V2). Added cmdlets to support the service. Cmdlets for the service have the noun prefix SES2 and can be listed using the command 'Get-AWSCmdletName -Service SES2'. You can use this API to configure your Amazon SES account, and to send email. This API extends the functionality that exists in the previous version of the Amazon SES API.
  * Amazon Simple Storage Service (S3)
    * Modified cmdlets adding parameter ForcePathStyleAddressing.
  * Amazon Single Sign-On. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSO and can be listed using the command 'Get-AWSCmdletName -Service SSO'. This release adds support for accessing AWS accounts assigned in AWS SSO using short term credentials.
  * Amazon Single Sign-On OIDC. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SSOOIDC and can be listed using the command 'Get-AWSCmdletName -Service SSOOIDC'. This is an initial release of AWS Single Sign-On OAuth device code authorization service.
  * Amazon Storage Gateway
    * Added cmdlet Get-SGAvailabilityMonitorTest leveraging the DescribeAvailabilityMonitorTest service API.
    * Added cmdlet Start-SGAvailabilityMonitorTest leveraging the StartAvailabilityMonitorTest service API.
    * Modified cmdlet Join-SGDomain: added parameter TimeoutInSecond.
  * Amazon Systems Manager
    * Added cmdlet Update-SSMResourceDataSync leveraging the UpdateResourceDataSync service API.
    * Modified cmdlet Get-SSMOpsSummary: added parameters ResultAttribute and SyncName.
    * Modified cmdlet Get-SSMResourceDataSync: added parameters PassThru and SyncType.
    * Modified cmdlet New-SSMOpsItem: added parameters Category and Severity.
    * Modified cmdlet New-SSMResourceDataSync: added parameters AwsOrganizationsSource_OrganizationalUnit, AwsOrganizationsSource_OrganizationSourceType, SyncSource_IncludeFutureRegion, SyncSource_SourceRegion, SyncSource_SourceType and SyncType.
    * Modified cmdlet Remove-SSMResourceDataSync: added parameter SyncType.
    * Modified cmdlet Update-SSMOpsItem: added parameters Category and Severity.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSTranscriptionJob: added parameters Settings_MaxAlternative and Settings_ShowAlternative.
  * Amazon WorkSpaces
    * Added cmdlet Edit-WKSSelfservicePermission leveraging the ModifySelfservicePermissions service API.
    * Added cmdlet Edit-WKSWorkspaceAccessProperty leveraging the ModifyWorkspaceAccessProperties service API.
    * Added cmdlet Edit-WKSWorkspaceCreationProperty leveraging the ModifyWorkspaceCreationProperties service API.
    * Added cmdlet Register-WKSWorkspaceDirectory leveraging the RegisterWorkspaceDirectory service API.
    * Added cmdlet Unregister-WKSWorkspaceDirectory leveraging the DeregisterWorkspaceDirectory service API.
    * Modified cmdlet Get-WKSWorkspaceDirectory: added parameter Limit.

### 4.0.0.0 (2019-11-21)
  * Version 4.0 is highly backwards compatible with version 3.3 of AWS Tools for PowerShell and, in most scenarios, you can expect a seamless upgrade. As a good practice we always recommend thorough testing before upgrading production environments.
  * A detailed list of changes included in version 4.0 of AWS Tools for PowerShell is available in [our announcment](https://github.com/aws/aws-tools-for-powershell/issues/67).
  * AWS.Tools modules
    * [AWS.Tools](https://www.powershellgallery.com/packages/AWS.Tools.Common) modules are now available for production use. AWS.Tools is the new modular variant of AWS Tools for PowerShell, which is preferred for most use cases. It has the same capabilities as AWSPowerShell and AWSPowerShell.NetCore and is compatible with all modern platforms: Windows PowerShell 5.1 (when .NET Framework 4.7.2 is installed) and PowerShell Core 6.0-6.2 on Windows, Linux and macOS. AWS.Tools has a modular architecture with a separate PowerShell module for each service. You can reduce download time, import time and memory usage by only installing modules your application requires.
    * The [AWS.Tools.Installer](https://www.powershellgallery.com/packages/AWS.Tools.Installer) module can be used to simplify installing, updating and removing the _AWS.Tools_ modules. New versions of all the modules are released together with the same version number, different versions of the AWS.Tools modules cannot be imported at the same time. Running, for example, `Install-AWSToolsModule AWS.Tools.EC2,AWS.Tools.S3 -CleanUp` will install the latest versions of the EC2 and S3 modules, sync existing modules to the current version and remove older versions.
    * The new AWS.Tools modules now declare and enforce mandatory cmdlet parameters. When an AWS Service declares that an API parameter is required, PowerShell will prompt you for the missing corresponding cmdlet parameter. For backward compatibility reasons we did not extend this feature to the AWSPowerShell.NetCore or AWSPowerShell modules.
    * [Breaking Change] AWS Tools for PowerShell support auto-pagination. Cmdlets like `Get-S3Object` will internally use, if necessary, multiple service calls in order to retrieve all the values. In AWSPowerShell.NetCore and AWSPowerShell the `-MaxItems` parameter allows to limit the number of items returned by some cmdlets. This behavior is now considered obsolete and is not available in AWS.Tools. You can instead pipe the output of the cmdlet into `| select -first $n`. Leveraging the new `-Select` parameter and this simplified pagination approach, we were able to enable auto-pagination in AWS.Tools for an additional 70 cmdlets that require manual pagination in AWSPowerShell.NetCore and AWSPowerShell.
    * AWS.Tools doesn’t include [undocumented type extension](https://www.powershellgallery.com/packages/AWSPowerShell/3.3.618.0/Content/AWSPowerShell.TypeExtensions.ps1xml) which are available in AWSPowerShell and AWSPowerShell.NetCore. These type extensions provide aliases for fields of .NET objects, mostly related to the EC2 service.
  * AWS.Tools, AWSPowerShell.NetCore and AWSPowerShell modules
    * Added cmdlet Get-AWSService to improve discoverability of supported AWS services and the corresponding AWS.Tools module names.
    * Most cmdlets have a new parameter: `-Select`. Select can be used to change the value returned by the cmdlet. For example the [service API](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/index.html?page=S3/MS3ListObjectsListObjectsRequest.html) used by `Get-S3Object` returns a [ListObjectsResponse](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/index.html?page=S3/TListObjectsResponse.html&tocid=Amazon_S3_Model_ListObjectsResponse) object but the cmdlet is configured to return only the `S3Objects` field. Now you can specify `-Select *` to receive the full API response. You can also specify the path to a nested result property like `-Select S3Objects.Key`. In certain situations it may be useful to return a cmdlet parameter, this can be achieved with `-Select ^ParameterName`.
    * Parameters of type `Stream` or `byte[]` can now accept `string`, `string[]` or `FileInfo` values. All strings are converted to `byte[]` using UTF8 encoding.
    * In order to provide a consistent user experience pipeline input by Property Name is now enabled for all parameters.
    * [Breaking Change] In previous versions of AWS Tools for PowerShell, common parameters (`AccessKey`, `SecretKey`, `ProfileName`, `Region`, etc.) used to be [dynamic](https://docs.microsoft.com/en-us/dotnet/api/system.management.automation.idynamicparameters) while all other parameters were static. This could create problems because PowerShell binds static parameters before dynamic ones. For example, when calling `Get-EC2Region -Region us-west-2`, PowerShell used to bind `us-west-2` to the `-RegionName` static parameter instead of the `-Region` dynamic parameter. In order to improve consistency in version 4.0 of AWS Tools for PowerShell all parameters are static. This may have an effect on the behavior of scripts if they are using:
      * `AccessKey` parameter of `Remove-IAMAccessKey`, `Get-IAMAccessKeyLastUsed` and Update-IAMAccessKey
      * `Credential` parameter of `New-AG2Integration`, `Update-AG2Integration``, `New-IOTRoleAlias` and `Update-IOTRoleAlias`
      * `Region` parameter of `New-AGDomainName`, `Get-DDBGlobalTableList`, `Get-EC2Region`, `Get-RDSSourceRegion` and `Update-R53HealthCheck`.
    * [Breaking Change] Removed the deprecated `-ProfileName` parameter from the `Clear-AWSCredential` cmdlet. Use `Remove-AWSCredentialProfile` instead.
    * Amazon Elastic Compute Cloud (EC2)
      * [Breaking Change] Removed the deprecated `-Terminate` parameter from the `Stop-EC2Instance` cmdlet. Use `Remove-EC2Instance` instead.
      * [Breaking Change] Removed deprecated cmdlets `Import-EC2Instance` and `Import-EC2Volume` from the AWSPowerShell module.
      * Modified cmdlet `Import-EC2KeyPair` to automatically perform Base64 encoding of the key when using the new parameter PublicKey.
    * Amazon Systems Manager
      * Added cmdlet `Get-SSMLatestEC2Image` replacing the functionality of `Get-EC2ImageByName` which is now marked as obsolete.

### 3.3.618.1 (2019-11-18)
  * This is a minor update to AWS.Tools only, the following changes don't apply to AWSPowerShell and AWSPowerShell.NetCore.
  * Released an updated preview of [AWS.Tools.Installer](https://www.powershellgallery.com/packages/AWS.Tools.Installer) which makes it easier to install, update and uninstall other AWS.Tools modules. You can use a single command like `Install-AWSToolsModule AWS.Tools.EC2,AWS.Tools.S3` to install multiple modules. You can also update all your installed AWS.Tools modules and remove old versions by running `Update-AWSToolsModule -CleanUp`.
  * Fixed behavior of `Get-AWSPowerShellVersion -ListServiceVersionInfo` and Get-AWSCmdletName: the cmdlets now report services and cmdlets also for modules that are not imported.
  * Added cmdlet Get-AWSService to improve discoverability of supported AWS services and the corresponding AWS.Tools module names.
  * Amazon Elastic Compute Cloud (EC2)
    * Modified cmdlet Import-EC2KeyPair to automatically perform Base64 encoding of the key when using the new parameter PublicKey.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMLatestEC2Image replacing the functionality of Get-EC2ImageByName which is now marked as obsolete.

### 3.3.618.0 (2019-11-04)
  * The modular version of AWS Tools for PowerShell (AWS.Tools) includes a preview of the upcoming changes from AWS Tools for Powershell v4. You can find detailed information in the [GitHub announcement](https://github.com/aws/aws-tools-for-powershell/issues/61).
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.618.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHRoute: added parameters Match_Metadata, Match_ServiceName, RetryPolicy_GrpcRetryEvent, Spec_GrpcRoute_Action_WeightedTarget, Spec_GrpcRoute_Match_MethodName, Spec_GrpcRoute_RetryPolicy_HttpRetryEvent, Spec_GrpcRoute_RetryPolicy_MaxRetry, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value, Spec_GrpcRoute_RetryPolicy_TcpRetryEvent, Spec_Http2Route_Action_WeightedTarget, Spec_Http2Route_Match_Header, Spec_Http2Route_Match_Method, Spec_Http2Route_Match_Prefix, Spec_Http2Route_Match_Scheme, Spec_Http2Route_RetryPolicy_HttpRetryEvent, Spec_Http2Route_RetryPolicy_MaxRetry, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value, Spec_Http2Route_RetryPolicy_TcpRetryEvent, Spec_HttpRoute_Match_Header, Spec_HttpRoute_Match_Method, Spec_HttpRoute_Match_Prefix, Spec_HttpRoute_Match_Scheme, Spec_HttpRoute_RetryPolicy_HttpRetryEvent, Spec_HttpRoute_RetryPolicy_MaxRetry, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value and Spec_HttpRoute_RetryPolicy_TcpRetryEvent.
    * Modified cmdlet Update-AMSHRoute: added parameters Match_Metadata, Match_ServiceName, RetryPolicy_GrpcRetryEvent, Spec_GrpcRoute_Action_WeightedTarget, Spec_GrpcRoute_Match_MethodName, Spec_GrpcRoute_RetryPolicy_HttpRetryEvent, Spec_GrpcRoute_RetryPolicy_MaxRetry, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Value, Spec_GrpcRoute_RetryPolicy_TcpRetryEvent, Spec_Http2Route_Action_WeightedTarget, Spec_Http2Route_Match_Header, Spec_Http2Route_Match_Method, Spec_Http2Route_Match_Prefix, Spec_Http2Route_Match_Scheme, Spec_Http2Route_RetryPolicy_HttpRetryEvent, Spec_Http2Route_RetryPolicy_MaxRetry, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit, Spec_Http2Route_RetryPolicy_PerRetryTimeout_Value, Spec_Http2Route_RetryPolicy_TcpRetryEvent, Spec_HttpRoute_Match_Header, Spec_HttpRoute_Match_Method, Spec_HttpRoute_Match_Prefix, Spec_HttpRoute_Match_Scheme, Spec_HttpRoute_RetryPolicy_HttpRetryEvent, Spec_HttpRoute_RetryPolicy_MaxRetry, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit, Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Value and Spec_HttpRoute_RetryPolicy_TcpRetryEvent.
  * Amazon AppStream
    * Modified cmdlet New-APSStack: added parameter EmbedHostDomain.
    * Modified cmdlet Update-APSStack: added parameter EmbedHostDomain.
  * Amazon Batch
    * Modified cmdlet New-BATComputeEnvironment: added parameter ComputeResources_AllocationStrategy.
  * Amazon Chime
    * Added cmdlet Add-CHMPhoneNumbersToVoiceConnectorGroup leveraging the AssociatePhoneNumbersWithVoiceConnectorGroup service API.
    * Added cmdlet Get-CHMPhoneNumberSetting leveraging the GetPhoneNumberSettings service API.
    * Added cmdlet Get-CHMVoiceConnectorGroup leveraging the GetVoiceConnectorGroup service API.
    * Added cmdlet Get-CHMVoiceConnectorGroupList leveraging the ListVoiceConnectorGroups service API.
    * Added cmdlet Get-CHMVoiceConnectorLoggingConfiguration leveraging the GetVoiceConnectorLoggingConfiguration service API.
    * Added cmdlet Get-CHMVoiceConnectorStreamingConfiguration leveraging the GetVoiceConnectorStreamingConfiguration service API.
    * Added cmdlet New-CHMVoiceConnectorGroup leveraging the CreateVoiceConnectorGroup service API.
    * Added cmdlet Remove-CHMPhoneNumbersFromVoiceConnectorGroup leveraging the DisassociatePhoneNumbersFromVoiceConnectorGroup service API.
    * Added cmdlet Remove-CHMVoiceConnectorGroup leveraging the DeleteVoiceConnectorGroup service API.
    * Added cmdlet Remove-CHMVoiceConnectorStreamingConfiguration leveraging the DeleteVoiceConnectorStreamingConfiguration service API.
    * Added cmdlet Update-CHMPhoneNumberSetting leveraging the UpdatePhoneNumberSettings service API.
    * Added cmdlet Update-CHMVoiceConnectorGroup leveraging the UpdateVoiceConnectorGroup service API.
    * Added cmdlet Write-CHMVoiceConnectorLoggingConfiguration leveraging the PutVoiceConnectorLoggingConfiguration service API.
    * Added cmdlet Write-CHMVoiceConnectorStreamingConfiguration leveraging the PutVoiceConnectorStreamingConfiguration service API.
    * Modified cmdlet Add-CHMPhoneNumbersToVoiceConnector: added parameter ForceAssociate.
    * Modified cmdlet New-CHMVoiceConnector: added parameter AwsRegion.
    * Modified cmdlet Update-CHMPhoneNumber: added parameter CallingName.
  * Amazon Connect Service
    * Added cmdlet Get-CONNContactFlowList leveraging the ListContactFlows service API.
    * Added cmdlet Get-CONNHoursOfOperationList leveraging the ListHoursOfOperations service API.
    * Added cmdlet Get-CONNPhoneNumberList leveraging the ListPhoneNumbers service API.
    * Added cmdlet Get-CONNQueueList leveraging the ListQueues service API.
  * Amazon EC2 Container Registry
    * Added cmdlet Get-ECRImageScanFinding leveraging the DescribeImageScanFindings service API.
    * Added cmdlet Start-ECRImageScan leveraging the StartImageScan service API.
    * Added cmdlet Write-ECRImageScanningConfiguration leveraging the PutImageScanningConfiguration service API.
    * Modified cmdlet New-ECRRepository: added parameter ImageScanningConfiguration_ScanOnPush.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2FpgaImage: added parameter TagSpecification.
  * Amazon ElastiCache
    * Added cmdlet Complete-ECMigration leveraging the CompleteMigration service API.
    * Added cmdlet Start-ECMigration leveraging the StartMigration service API.
  * Amazon IoT Events
    * Modified cmdlet New-IOTEDetectorModel: added parameter EvaluationMethod.
    * Modified cmdlet Update-IOTEDetectorModel: added parameter EvaluationMethod.
  * Amazon Lex
    * Modified cmdlet Get-LEXSession: added parameter CheckpointLabelFilter.
    * Modified cmdlet Write-LEXSession: added parameter RecentIntentSummaryView.
  * Amazon Managed Streaming for Kafka
    * Added cmdlet Update-MSKBrokerCount leveraging the UpdateBrokerCount service API.
  * Amazon OpsWorksCM
    * Modified cmdlet New-OWCMServer: added parameters CustomCertificate, CustomDomain and CustomPrivateKey.
  * Amazon Personalize
    * Modified cmdlet New-PERSSolutionVersion: added parameter TrainingMode.
  * Amazon Relational Database Service
    * Added cmdlet Get-RDSCustomAvailabilityZone leveraging the DescribeCustomAvailabilityZones service API.
    * Added cmdlet Get-RDSInstallationMedia leveraging the DescribeInstallationMedia service API.
    * Added cmdlet Import-RDSInstallationMedia leveraging the ImportInstallationMedia service API.
    * Added cmdlet New-RDSCustomAvailabilityZone leveraging the CreateCustomAvailabilityZone service API.
    * Added cmdlet Remove-RDSCustomAvailabilityZone leveraging the DeleteCustomAvailabilityZone service API.
    * Added cmdlet Remove-RDSInstallationMedia leveraging the DeleteInstallationMedia service API.
  * Amazon Simple Storage Service
    * Modified cmdlet Select-S3ObjectContent: added parameters ScanRange_End and ScanRange_Start.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRUser: added parameters HomeDirectoryMapping and HomeDirectoryType.
    * Modified cmdlet Update-TFRUser: added parameters HomeDirectoryMapping and HomeDirectoryType.

### 3.3.604.0 (2019-10-11)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.604.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Added cmdlet Get-AMPArtifactList leveraging the ListArtifacts service API.
    * Added cmdlet Get-AMPArtifactUrl leveraging the GetArtifactUrl service API.
    * Added cmdlet New-AMPAccessLog leveraging the GenerateAccessLogs service API.
    * Modified cmdlet New-AMPApp: added parameter AutoBranchCreationConfig_EnablePullRequestPreview.
    * Modified cmdlet New-AMPBranch: added parameter EnablePullRequestPreview.
    * Modified cmdlet Update-AMPApp: added parameters AccessToken, AutoBranchCreationConfig_EnablePullRequestPreview, OauthToken and Repository.
    * Modified cmdlet Update-AMPBranch: added parameter EnablePullRequestPreview.
  * Amazon Cognito Identity Provider
    * Modified cmdlet Confirm-CGIPForgotPassword: added parameter ClientMetadata.
    * Modified cmdlet Confirm-CGIPUserRegistration: added parameter ClientMetadata.
    * Modified cmdlet Confirm-CGIPUserRegistrationAdmin: added parameter ClientMetadata.
    * Modified cmdlet Get-CGIPUserAttributeVerificationCode: added parameter ClientMetadata.
    * Modified cmdlet New-CGIPUserAdmin: added parameter ClientMetadata.
    * Modified cmdlet Register-CGIPUserInPool: added parameter ClientMetadata.
    * Modified cmdlet Reset-CGIPForgottenPassword: added parameter ClientMetadata.
    * Modified cmdlet Reset-CGIPUserPasswordAdmin: added parameter ClientMetadata.
    * Modified cmdlet Send-CGIPAuthChallengeResponse: added parameter ClientMetadata.
    * Modified cmdlet Send-CGIPAuthChallengeResponseAdmin: added parameter ClientMetadata.
    * Modified cmdlet Send-CGIPConfirmationCode: added parameter ClientMetadata.
    * Modified cmdlet Update-CGIPUserAttribute: added parameter ClientMetadata.
    * Modified cmdlet Update-CGIPUserAttributeAdmin: added parameter ClientMetadata.
  * Amazon Comprehend Medical
    * Added cmdlet Find-CMPMMedicalEntityV2 leveraging the DetectEntitiesV2 service API.
    * Added cmdlet Get-CMPMEntitiesDetectionV2Job leveraging the DescribeEntitiesDetectionV2Job service API.
    * Added cmdlet Get-CMPMEntitiesDetectionV2JobList leveraging the ListEntitiesDetectionV2Jobs service API.
    * Added cmdlet Get-CMPMPersonalHealthInformationDetectionJob leveraging the DescribePHIDetectionJob service API.
    * Added cmdlet Get-CMPMPersonalHealthInformationDetectionJobList leveraging the ListPHIDetectionJobs service API.
    * Added cmdlet Start-CMPMEntitiesDetectionV2Job leveraging the StartEntitiesDetectionV2Job service API.
    * Added cmdlet Start-CMPMPersonalHealthInformationDetectionJob leveraging the StartPHIDetectionJob service API.
    * Added cmdlet Stop-CMPMEntitiesDetectionV2Job leveraging the StopEntitiesDetectionV2Job service API.
    * Added cmdlet Stop-CMPMPersonalHealthInformationDetectionJob leveraging the StopPHIDetectionJob service API.
  * Amazon Database Migration Service
    * Added cmdlet Remove-DMSConnection leveraging the DeleteConnection service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameter S3Settings_ParquetTimestampInMillisecond.
    * Modified cmdlet New-DMSEndpoint: added parameter S3Settings_ParquetTimestampInMillisecond.
  * Amazon DataSync
    * Modified cmdlet New-DSYNLocationS3: added parameter S3StorageClass.
  * Amazon Direct Connect
    * Modified cmdlet New-DCConnection: added parameter ProviderName.
    * Modified cmdlet New-DCInterconnect: added parameter ProviderName.
    * Modified cmdlet New-DCLag: added parameter ProviderName.
  * Amazon DocumentDB
    * Added cmdlet Get-DOCCertificate leveraging the DescribeCertificates service API.
    * Modified cmdlet Edit-DOCDBInstance: added parameter CACertificateIdentifier.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Remove-EC2QueuedReservedInstance leveraging the DeleteQueuedReservedInstances service API.
    * Modified cmdlet New-EC2Instance: added parameter HibernationOptions_Configured.
    * Modified cmdlet Stop-EC2Instance: added parameter Hibernate.
    * Modified cmdlet New-EC2ReservedInstance: added parameter PurchaseTime.
  * Amazon ElastiCache
    * Modified cmdlet Get-ECUpdateAction: added parameters CacheClusterId and Engine.
    * Modified cmdlet Start-ECUpdateActionBatch: added parameter CacheClusterId.
    * Modified cmdlet Stop-ECUpdateActionBatch: added parameter CacheClusterId.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameters DomainEndpointOptions_EnforceHTTPS and DomainEndpointOptions_TLSSecurityPolicy.
    * Modified cmdlet Update-ESDomainConfig: added parameters DomainEndpointOptions_EnforceHTTPS and DomainEndpointOptions_TLSSecurityPolicy.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter Tag.
  * Amazon Elemental MediaPackage
    * Added cmdlet Get-EMPHarvestJob leveraging the DescribeHarvestJob service API.
    * Added cmdlet Get-EMPHarvestJobList leveraging the ListHarvestJobs service API.
    * Added cmdlet New-EMPHarvestJob leveraging the CreateHarvestJob service API.
    * Modified cmdlet New-EMPOriginEndpoint: added parameter Origination.
    * Modified cmdlet Update-EMPOriginEndpoint: added parameter Origination.
  * Amazon Import/Export Snowball
    * Added cmdlet Get-SNOWSoftwareUpdate leveraging the GetSoftwareUpdates service API.
  * Amazon Kinesis Firehose
    * Modified cmdlet New-KINFDeliveryStream: added parameter ElasticsearchDestinationConfiguration_ClusterEndpoint.
    * Modified cmdlet Update-KINFDestination: added parameter ElasticsearchDestinationUpdate_ClusterEndpoint.
  * Amazon Lightsail
    * Added cmdlet Disable-LSAddOn leveraging the DisableAddOn service API.
    * Added cmdlet Enable-LSAddOn leveraging the EnableAddOn service API.
    * Added cmdlet Get-LSAutoSnapshot leveraging the GetAutoSnapshots service API.
    * Added cmdlet Remove-LSAutoSnapshot leveraging the DeleteAutoSnapshot service API.
    * Modified cmdlet Add-LSResourceTag: added parameter ResourceArn.
    * Modified cmdlet Copy-LSSnapshot: added parameters RestoreDate, SourceResourceName and UseLatestRestorableAutoSnapshot.
    * Modified cmdlet New-LSDisk: added parameter AddOn.
    * Modified cmdlet New-LSDiskFromSnapshot: added parameters AddOn, RestoreDate, SourceDiskName and UseLatestRestorableAutoSnapshot.
    * Modified cmdlet New-LSInstance: added parameter AddOn.
    * Modified cmdlet New-LSInstancesFromSnapshot: added parameters AddOn, RestoreDate, SourceInstanceName and UseLatestRestorableAutoSnapshot.
    * Modified cmdlet Remove-LSDisk: added parameter ForceDeleteAddOn.
    * Modified cmdlet Remove-LSInstance: added parameter ForceDeleteAddOn.
    * Modified cmdlet Remove-LSResourceTag: added parameter ResourceArn.
  * Amazon MQ
    * Modified cmdlet Update-MQBroker: added parameter HostInstanceType.
  * Amazon Pinpoint
    * Added cmdlet Get-PINEmailTemplate leveraging the GetEmailTemplate service API.
    * Added cmdlet Get-PINPushTemplate leveraging the GetPushTemplate service API.
    * Added cmdlet Get-PINSmsTemplate leveraging the GetSmsTemplate service API.
    * Added cmdlet Get-PINTemplateList leveraging the ListTemplates service API.
    * Added cmdlet New-PINEmailTemplate leveraging the CreateEmailTemplate service API.
    * Added cmdlet New-PINPushTemplate leveraging the CreatePushTemplate service API.
    * Added cmdlet New-PINSmsTemplate leveraging the CreateSmsTemplate service API.
    * Added cmdlet Remove-PINEmailTemplate leveraging the DeleteEmailTemplate service API.
    * Added cmdlet Remove-PINPushTemplate leveraging the DeletePushTemplate service API.
    * Added cmdlet Remove-PINSmsTemplate leveraging the DeleteSmsTemplate service API.
    * Added cmdlet Update-PINEmailTemplate leveraging the UpdateEmailTemplate service API.
    * Added cmdlet Update-PINPushTemplate leveraging the UpdatePushTemplate service API.
    * Added cmdlet Update-PINSmsTemplate leveraging the UpdateSmsTemplate service API.
    * Modified cmdlet New-PINCampaign: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
    * Modified cmdlet Send-PINMessage: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
    * Modified cmdlet Send-PINUserMessageBatch: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
    * Modified cmdlet Update-PINCampaign: added parameters EmailTemplate_Name, PushTemplate_Name and SMSTemplate_Name.
  * Amazon Pinpoint Email
    * Modified cmdlet New-PINEDeliverabilityTestReport: added parameters Template_TemplateArn and Template_TemplateData.
    * Modified cmdlet Send-PINEEmail: added parameters Template_TemplateArn and Template_TemplateData.
  * Amazon RDS DataService
    * Modified cmdlet Invoke-RDSDStatement: added parameter ResultSetOptions_DecimalReturnType.
  * Amazon Redshift
    * Added cmdlet Get-RSNodeConfigurationOption leveraging the DescribeNodeConfigurationOptions service API.
    * Modified cmdlet Restore-RSFromClusterSnapshot: added parameter NumberOfNode.
  * Amazon Relational Database Service
    * Modified cmdlet Get-RDSReservedDBInstance: added parameter LeaseId.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameters Domain and DomainIAMRoleName.
  * Amazon Transcribe Service
    * Modified cmdlet Start-TRSTranscriptionJob: added parameter OutputEncryptionKMSKeyId.
  * Amazon WorkSpaces
    * Added cmdlet Get-WKSWorkspaceSnapshot leveraging the DescribeWorkspaceSnapshots service API.
    * Added cmdlet Restore-WKSWorkspace leveraging the RestoreWorkspace service API.

### 3.3.590.0 (2019-09-23)
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.590.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBProfile: added parameter Locale.
    * Modified cmdlet Update-ALXBProfile: added parameter Locale.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter EndpointConfiguration_VpcEndpointId.
    * Modified cmdlet New-AGRestApi: added parameter EndpointConfiguration_VpcEndpointId.
  * Amazon API Gateway Management API
    * Added cmdlet Get-AGMConnection leveraging the GetConnection service API.
    * Added cmdlet Remove-AGMConnection leveraging the DeleteConnection service API.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHRoute: added parameters Match_Header, Match_Method, Match_Scheme, PerRetryTimeout_Unit, PerRetryTimeout_Value, RetryPolicy_HttpRetryEvent, RetryPolicy_MaxRetry, RetryPolicy_TcpRetryEvent and Spec_Priority.
    * Modified cmdlet Update-AMSHRoute: added parameters Match_Header, Match_Method, Match_Scheme, PerRetryTimeout_Unit, PerRetryTimeout_Value, RetryPolicy_HttpRetryEvent, RetryPolicy_MaxRetry, RetryPolicy_TcpRetryEvent and Spec_Priority.
  * Amazon Application Auto Scaling
    * Modified cmdlet Add-AASScalableTarget: added parameters SuspendedState_DynamicScalingInSuspended, SuspendedState_DynamicScalingOutSuspended and SuspendedState_ScheduledScalingSuspended.
  * Amazon AppStream
    * Modified cmdlet New-APSFleet: added parameter IamRoleArn.
    * Modified cmdlet New-APSImageBuilder: added parameters AccessEndpoint and IamRoleArn.
    * Modified cmdlet New-APSStack: added parameter AccessEndpoint.
    * Modified cmdlet Update-APSFleet: added parameter IamRoleArn.
    * Modified cmdlet Update-APSStack: added parameter AccessEndpoint.
  * Amazon AppSync
    * Modified cmdlet New-ASYNGraphqlApi: added parameter LogConfig_ExcludeVerboseContent.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameter LogConfig_ExcludeVerboseContent.
  * Amazon Athena
    * Modified cmdlet New-ATHWorkGroup: added parameter Configuration_RequesterPaysEnabled.
    * Modified cmdlet Update-ATHWorkGroup: added parameter ConfigurationUpdates_RequesterPaysEnabled.
  * Amazon CodeBuild
    * Modified cmdlet Import-CBSourceCredential: added parameter ShouldOverwrite.
  * Amazon CodeCommit
    * Added cmdlet Get-CCCommitBatch leveraging the BatchGetCommits service API.
  * Amazon Config
    * Added cmdlet Get-CFGRemediationException leveraging the DescribeRemediationExceptions service API.
    * Added cmdlet Remove-CFGRemediationException leveraging the DeleteRemediationExceptions service API.
    * Added cmdlet Write-CFGRemediationException leveraging the PutRemediationExceptions service API.
  * Amazon Cost and Usage Report
    * Added cmdlet Edit-CURReportDefinition leveraging the ModifyReportDefinition service API.
  * Amazon DataSync
    * Added cmdlet Get-DSYNLocationSmb leveraging the DescribeLocationSmb service API.
    * Added cmdlet New-DSYNLocationSmb leveraging the CreateLocationSmb service API.
  * Amazon EC2 Container Service
    * Added cmdlet Update-ECSClusterSetting leveraging the UpdateClusterSettings service API.
    * Modified cmdlet New-ECSTask: added parameter Overrides_InferenceAcceleratorOverride.
    * Modified cmdlet Register-ECSTaskDefinition: added parameter InferenceAccelerator.
    * Modified cmdlet Start-ECSTask: added parameter Overrides_InferenceAcceleratorOverride.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2VpnTunnelCertificate leveraging the ModifyVpnTunnelCertificate service API.
    * Added cmdlet Edit-EC2VpnTunnelOption leveraging the ModifyVpnTunnelOptions service API.
    * Added cmdlet Export-EC2Image leveraging the ExportImage service API.
    * Added cmdlet Get-EC2ExportImageTask leveraging the DescribeExportImageTasks service API.
    * Added cmdlet Send-EC2DiagnosticInterrupt leveraging the SendDiagnosticInterrupt service API.
    * Modified cmdlet Edit-EC2VpnConnection: added parameter CustomerGatewayId.
    * Modified cmdlet New-EC2CustomerGateway: added parameter CertificateArn.
    * Modified cmdlet New-EC2FlowLog: added parameter LogFormat.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Add-EKSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EKSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EKSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-EKSCluster: added parameter Tag.
  * Amazon Elastic MapReduce
    * Added cmdlet Get-EMRBlockPublicAccessConfiguration leveraging the GetBlockPublicAccessConfiguration service API.
    * Added cmdlet Write-EMRBlockPublicAccessConfiguration leveraging the PutBlockPublicAccessConfiguration service API.
  * Amazon ElastiCache
    * Modified cmdlet Copy-ECSnapshot: added parameter KmsKeyId.
    * Modified cmdlet New-ECReplicationGroup: added parameter KmsKeyId.
    * Modified cmdlet New-ECSnapshot: added parameter KmsKeyId.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter SimulateReservedQueue.
    * Modified cmdlet New-EMCQueue: added parameter Status.
  * Amazon Forecast Query Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FRCQ and can be listed using the command 'Get-AWSCmdletName -Service FRCQ'.
  * Amazon Forecast Service. Added cmdlets to support the service. Cmdlets for the service have the noun prefix FRC and can be listed using the command 'Get-AWSCmdletName -Service FRC'.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLFleet: added parameter CertificateConfiguration_CertificateType.
  * Amazon Glacier
    * Modified cmdlet Start-GLCJob: renamed parameter Select as SelectParameter.
  * Amazon Glue
    * Added cmdlet Find-GLUETable leveraging the SearchTables service API.
    * Added cmdlet Get-GLUEMLTaskRun leveraging the GetMLTaskRun service API.
    * Added cmdlet Get-GLUEMLTaskRunList leveraging the GetMLTaskRuns service API.
    * Added cmdlet Get-GLUEMLTransform leveraging the GetMLTransform service API.
    * Added cmdlet Get-GLUEMLTransformList leveraging the GetMLTransforms service API.
    * Added cmdlet New-GLUEMLTransform leveraging the CreateMLTransform service API.
    * Added cmdlet Remove-GLUEMLTransform leveraging the DeleteMLTransform service API.
    * Added cmdlet Start-GLUEExportLabelsTaskRun leveraging the StartExportLabelsTaskRun service API.
    * Added cmdlet Start-GLUEImportLabelsTaskRun leveraging the StartImportLabelsTaskRun service API.
    * Added cmdlet Start-GLUEMLEvaluationTaskRun leveraging the StartMLEvaluationTaskRun service API.
    * Added cmdlet Start-GLUEMLLabelingSetGenerationTaskRun leveraging the StartMLLabelingSetGenerationTaskRun service API.
    * Added cmdlet Stop-GLUEMLTaskRun leveraging the CancelMLTaskRun service API.
    * Added cmdlet Update-GLUEMLTransform leveraging the UpdateMLTransform service API.
    * Modified cmdlet New-GLUEDevEndpoint: added parameter GlueVersion.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameter Republish_Qo.
    * Modified cmdlet Set-IOTTopicRule: added parameter Republish_Qo.
  * Amazon Lake Formation. Added cmdlets to support the service. Cmdlets for the service have the noun prefix LKF and can be listed using the command 'Get-AWSCmdletName -Service LKF'.
  * Amazon Lambda
    * Modified cmdlet New-LMEventSourceMapping: added parameter MaximumBatchingWindowInSecond.
    * Modified cmdlet Update-LMEventSourceMapping: added parameter MaximumBatchingWindowInSecond.
  * Amazon Lex
    * Added cmdlet Get-LEXSession leveraging the GetSession service API.
    * Added cmdlet Remove-LEXSession leveraging the DeleteSession service API.
    * Added cmdlet Write-LEXSession leveraging the PutSession service API.
  * Amazon MQ
    * Modified cmdlet Update-MQBroker: added parameter SecurityGroup.
  * Amazon QLDB. Added cmdlets to support the service. Cmdlets for the service have the noun prefix QLDB and can be listed using the command 'Get-AWSCmdletName -Service QLDB'.
  * Amazon QLDB Session. Added cmdlets to support the service. Cmdlets for the service have the noun prefix QLDBS and can be listed using the command 'Get-AWSCmdletName -Service QLDBS'.
  * Amazon Relational Database Service
    * Modified cmdlet New-RDSDBCluster: added parameter EnableHttpEndpoint.
    * Modified cmdlet New-RDSDBInstanceReadReplica: added parameter DBParameterGroupName.
  * Amazon Resource Access Manager
    * Added cmdlet Get-RAMPendingInvitationResourceList leveraging the ListPendingInvitationResources service API.
  * Amazon RoboMaker
    * Modified cmdlet New-ROBOSimulationJob: added parameters DataSource and LoggingConfig_RecordAllRosTopic.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMCompilationJob: added parameter StoppingCondition_MaxWaitTimeInSecond.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameters CheckpointConfig_LocalPath, CheckpointConfig_S3Uri, StoppingCondition_MaxWaitTimeInSecond and TrainingJobDefinition_EnableManagedSpotTraining.
    * Modified cmdlet New-SMTrainingJob: added parameters CheckpointConfig_LocalPath, CheckpointConfig_S3Uri, EnableManagedSpotTraining and StoppingCondition_MaxWaitTimeInSecond.
  * Amazon Simple Queue Service
    * Modified cmdlet New-SQSQueue: added parameter Tag.
    * Modified cmdlet Send-SQSMessage: added parameter MessageSystemAttribute.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGSnapshotFromVolumeRecoveryPoint: added parameter Tag.
    * Modified cmdlet Update-SGGatewayInformation: added parameter CloudWatchLogGroupARN.
  * Amazon WorkMail Message Flow. Added cmdlets to support the service. Cmdlets for the service have the noun prefix WMMF and can be listed using the command 'Get-AWSCmdletName -Service WMMF'.

### 3.3.563.1 (2019-08-09)
  * Fixing bug introduced in 3.3.563.0 resulting in variables being set in the local scope importing AWS Tools for PowerShell modules.

### 3.3.563.0 (2019-08-08)
  * A new new modular variant of AWS Tools for PowerShell ([AWS.Tools](https://www.powershellgallery.com/packages/AWS.Tools.Common)) is now offered in prerelease. Please provide feedback by opening a GitHub issue [here](https://github.com/aws/aws-tools-for-powershell/issues) if you encounter any problem using it. In order to manage each AWS service, install from [PowerShell Gallery](https://www.powershellgallery.com/) the corresponding module (e.g. [AWS.Tools.EC2](https://www.powershellgallery.com/packages/AWS.Tools.EC2), [AWS.Tools.S3](https://www.powershellgallery.com/packages/AWS.Tools.S3)...).
  * AWS Tools for PowerShell now use AWS .NET SDK 3.3.563.1 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter LinuxParameters_Device.
  * Amazon CloudWatch Application Insights
    * Added cmdlet Update-CWAIApplication leveraging the UpdateApplication service API.
    * Modified cmdlet New-CWAIApplication: added parameters OpsCenterEnabled and OpsItemSNSTopicArn.
  * Amazon CloudWatch Logs
    * Modified cmdlet Start-CWLQuery: added parameter LogGroupNameList.
  * Amazon Cost Explorer
    * Added cmdlet Get-CERightsizingRecommendation leveraging the GetRightsizingRecommendation service API.
  * Amazon DataSync
    * Modified cmdlet New-DSYNAgent: added parameters SecurityGroupArn, SubnetArn and VpcEndpointId.
  * Amazon EC2 Container Registry
    * Added cmdlet Write-ECRImageTagMutability leveraging the PutImageTagMutability service API.
    * Modified cmdlet New-ECRRepository: added parameter ImageTagMutability.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Get-EC2CapacityReservationUsage leveraging the GetCapacityReservationUsage service API.
    * Modified cmdlet New-EC2LaunchTemplate: added parameter TagSpecification.
    * Modified cmdlet Add-EC2CapacityReservation: added parameter AvailabilityZoneId.
    * Modified cmdlet Edit-EC2ClientVpnEndpoint: added parameter SplitTunnel.
    * Modified cmdlet Get-EC2Region: added parameter AllRegion.
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter SplitTunnel.
  * Amazon Elemental MediaConnect
    * Modified cmdlet Update-EMCNFlowOutput: added parameters CidrAllowList and RemoteId.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter Priority.
    * Modified cmdlet New-EMCJobTemplate: added parameter Priority.
    * Modified cmdlet Update-EMCJobTemplate: added parameter Priority.
  * Amazon Glue
    * Added cmdlet Get-GLUEJobBookmark leveraging the GetJobBookmark service API.
    * Modified cmdlet New-GLUEDevEndpoint: added parameters NumberOfWorker and WorkerType.
    * Modified cmdlet New-GLUEJob: added parameter GlueVersion.
    * Modified cmdlet Reset-GLUEJobBookmark: added parameter RunId.
  * Amazon IoT
    * Added cmdlet Get-IOTAuditFinding leveraging the DescribeAuditFinding service API.
    * Added cmdlet Get-IOTAuditMitigationActionsExecutionList leveraging the ListAuditMitigationActionsExecutions service API.
    * Added cmdlet Get-IOTAuditMitigationActionsTask leveraging the DescribeAuditMitigationActionsTask service API.
    * Added cmdlet Get-IOTAuditMitigationActionsTaskList leveraging the ListAuditMitigationActionsTasks service API.
    * Added cmdlet Get-IOTMitigationAction leveraging the DescribeMitigationAction service API.
    * Added cmdlet Get-IOTMitigationActionList leveraging the ListMitigationActions service API.
    * Added cmdlet New-IOTMitigationAction leveraging the CreateMitigationAction service API.
    * Added cmdlet Remove-IOTMitigationAction leveraging the DeleteMitigationAction service API.
    * Added cmdlet Start-IOTAuditMitigationActionsTask leveraging the StartAuditMitigationActionsTask service API.
    * Added cmdlet Stop-IOTAuditMitigationActionsTask leveraging the CancelAuditMitigationActionsTask service API.
    * Added cmdlet Update-IOTMitigationAction leveraging the UpdateMitigationAction service API.
  * Amazon MQ
    * Modified cmdlet New-MQBroker: added parameters EncryptionOptions_KmsKeyId and EncryptionOptions_UseAwsOwnedKey.
  * Amazon Pinpoint
    * Added cmdlet Get-PINApplicationDateRangeKpi leveraging the GetApplicationDateRangeKpi service API.
    * Added cmdlet Get-PINCampaignDateRangeKpi leveraging the GetCampaignDateRangeKpi service API.
  * Amazon Polly
    * Modified cmdlet Get-POLSpeech: added parameter Engine.
    * Modified cmdlet Get-POLVoice: added parameter Engine.
    * Modified cmdlet Start-POLSpeechSynthesisTask: added parameter Engine.
  * Amazon Security Token Service
    * Added cmdlet Get-STSAccessKeyInfo leveraging the GetAccessKeyInfo service API.

### 3.3.553.0 (2019-07-19)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.553.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Amplify
    * Added cmdlet Add-AMPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AMPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-AMPWebhook leveraging the GetWebhook service API.
    * Added cmdlet Get-AMPWebhookList leveraging the ListWebhooks service API.
    * Added cmdlet New-AMPDeployment leveraging the CreateDeployment service API.
    * Added cmdlet New-AMPWebhook leveraging the CreateWebhook service API.
    * Added cmdlet Remove-AMPResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-AMPWebhook leveraging the DeleteWebhook service API.
    * Added cmdlet Start-AMPDeployment leveraging the StartDeployment service API.
    * Added cmdlet Update-AMPWebhook leveraging the UpdateWebhook service API.
    * Modified cmdlet New-AMPApp: added parameters AccessToken, AutoBranchCreationConfig_BasicAuthCredential, AutoBranchCreationConfig_BuildSpec, AutoBranchCreationConfig_EnableAutoBuild, AutoBranchCreationConfig_EnableBasicAuth, AutoBranchCreationConfig_EnvironmentVariable, AutoBranchCreationConfig_Framework, AutoBranchCreationConfig_Stage, AutoBranchCreationPattern and EnableAutoBranchCreation.
    * Modified cmdlet New-AMPBranch: added parameter DisplayName.
    * Modified cmdlet Update-AMPApp: added parameters AutoBranchCreationConfig_BasicAuthCredential, AutoBranchCreationConfig_BuildSpec, AutoBranchCreationConfig_EnableAutoBuild, AutoBranchCreationConfig_EnableBasicAuth, AutoBranchCreationConfig_EnvironmentVariable, AutoBranchCreationConfig_Framework, AutoBranchCreationConfig_Stage, AutoBranchCreationPattern and EnableAutoBranchCreation.
    * Modified cmdlet Update-AMPBranch: added parameter DisplayName.
  * Amazon CloudWatch
    * Added cmdlet Get-CWAnomalyDetector leveraging the DescribeAnomalyDetectors service API.
    * Added cmdlet Remove-CWAnomalyDetector leveraging the DeleteAnomalyDetector service API.
    * Added cmdlet Write-CWAnomalyDetector leveraging the PutAnomalyDetector service API.
    * Modified cmdlet Write-CWMetricAlarm: added parameter ThresholdMetricId.
  * Amazon CloudWatch Events
    * Added cmdlet Disable-CWEEventSource leveraging the DeactivateEventSource service API.
    * Added cmdlet Enable-CWEEventSource leveraging the ActivateEventSource service API.
    * Added cmdlet Get-CWEEventBusList leveraging the ListEventBuses service API.
    * Added cmdlet Get-CWEEventSource leveraging the DescribeEventSource service API.
    * Added cmdlet Get-CWEEventSourceList leveraging the ListEventSources service API.
    * Added cmdlet Get-CWEPartnerEventSource leveraging the DescribePartnerEventSource service API.
    * Added cmdlet Get-CWEPartnerEventSourceAccountList leveraging the ListPartnerEventSourceAccounts service API.
    * Added cmdlet Get-CWEPartnerEventSourceList leveraging the ListPartnerEventSources service API.
    * Added cmdlet New-CWEEventBus leveraging the CreateEventBus service API.
    * Added cmdlet New-CWEPartnerEventSource leveraging the CreatePartnerEventSource service API.
    * Added cmdlet Remove-CWEEventBus leveraging the DeleteEventBus service API.
    * Added cmdlet Remove-CWEPartnerEventSource leveraging the DeletePartnerEventSource service API.
    * Added cmdlet Write-CWEPartnerEvent leveraging the PutPartnerEvents service API.
    * Modified cmdlet Disable-CWERule: added parameter EventBusName.
    * Modified cmdlet Enable-CWERule: added parameter EventBusName.
    * Modified cmdlet Get-CWEEventBus: added parameter Name.
    * Modified cmdlet Get-CWERule: added parameter EventBusName.
    * Modified cmdlet Get-CWERuleDetail: added parameter EventBusName.
    * Modified cmdlet Get-CWERuleNamesByTarget: added parameter EventBusName.
    * Modified cmdlet Get-CWETargetsByRule: added parameter EventBusName.
    * Modified cmdlet Remove-CWEPermission: added parameter EventBusName.
    * Modified cmdlet Remove-CWERule: added parameter EventBusName.
    * Modified cmdlet Remove-CWETarget: added parameter EventBusName.
    * Modified cmdlet Write-CWEPermission: added parameter EventBusName.
    * Modified cmdlet Write-CWERule: added parameter EventBusName.
    * Modified cmdlet Write-CWETarget: added parameter EventBusName.
  * Amazon Config
    * Added cmdlet Get-CFGOrganizationConfigRule leveraging the DescribeOrganizationConfigRules service API.
    * Added cmdlet Get-CFGOrganizationConfigRuleDetailedStatus leveraging the GetOrganizationConfigRuleDetailedStatus service API.
    * Added cmdlet Get-CFGOrganizationConfigRuleStatus leveraging the DescribeOrganizationConfigRuleStatuses service API.
    * Added cmdlet Remove-CFGOrganizationConfigRule leveraging the DeleteOrganizationConfigRule service API.
    * Added cmdlet Write-CFGOrganizationConfigRule leveraging the PutOrganizationConfigRule service API.
  * Amazon Cost Explorer
    * Added cmdlet Get-CEUsageForecast leveraging the GetUsageForecast service API.
  * Amazon Database Migration Service
    * Modified cmdlet Edit-DMSEndpoint: added parameters S3Settings_IncludeOpForFullLoad and S3Settings_TimestampColumnName.
    * [Breaking Change] Modified cmdlet Get-DMSAccountAttribute: output changed from Amazon.DatabaseMigrationService.Model.AccountQuota to Amazon.DatabaseMigrationService.Model.DescribeAccountAttributesResponse.
    * Modified cmdlet New-DMSEndpoint: added parameters S3Settings_IncludeOpForFullLoad and S3Settings_TimestampColumnName.
  * Amazon DocumentDB
    * Added cmdlet Start-DOCDBCluster leveraging the StartDBCluster service API.
    * Added cmdlet Stop-DOCDBCluster leveraging the StopDBCluster service API.
    * Modified cmdlet Edit-DOCDBCluster: added parameter DeletionProtection.
    * Modified cmdlet New-DOCDBCluster: added parameter DeletionProtection.
    * Modified cmdlet Restore-DOCDBClusterFromSnapshot: added parameter DeletionProtection.
    * Modified cmdlet Restore-DOCDBClusterToPointInTime: added parameter DeletionProtection.
  * Amazon EC2 Container Service
    * Modified cmdlet New-ECSCluster: added parameter Setting.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet Edit-EC2SpotFleetRequest: added parameter OnDemandTargetCapacity.
    * Modified cmdlet New-EC2Fleet: added parameters OnDemandOptions_MaxTotalPrice and SpotOptions_MaxTotalPrice.
    * [Breaking Change] Modified cmdlet Register-EC2PrivateIpAddress: output changed from None and System.String to Amazon.EC2.Model.AssignedPrivateIpAddress; removed parameter PassThru.
    * Modified cmdlet Request-EC2SpotFleet: added parameters SpotFleetRequestConfig_OnDemandMaxTotalPrice and SpotFleetRequestConfig_SpotMaxTotalPrice.
  * Amazon Elemental MediaStore
    * Added cmdlet Add-EMSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-EMSContainer: added parameter Tag.
  * Amazon EventBridge. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EVB and can be listed using the command 'Get-AWSCmdletName -Service EVB'. Amazon EventBridge is a serverless event bus service that makes it easy to connect your applications with data from a variety of sources, including AWS services, partner applications, and your own applications.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLMatchmakingConfiguration: added parameter BackfillMode.
    * Modified cmdlet Update-GMLMatchmakingConfiguration: added parameter BackfillMode.
  * Amazon QuickSight
    * Modified cmdlet Get-QSDashboardEmbedUrl: added parameter UserArn.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameters AllowMajorVersionUpgrade and DBInstanceParameterGroupName.
    * Modified cmdlet Get-RDSDBCluster: added parameter IncludeShared.
  * Amazon Service Catalog
    * Added cmdlet Get-SCServiceActionExecutionParameter leveraging the DescribeServiceActionExecutionParameters service API.
    * Modified cmdlet Start-SCProvisionedProductServiceActionExecution: added parameter Parameter.
  * Amazon Simple Workflow Service
    * Added cmdlet Add-SWFResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SWFResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SWFResourceTag leveraging the UntagResource service API.
    * Added cmdlet Restore-SWFActivityType leveraging the UndeprecateActivityType service API.
    * Added cmdlet Restore-SWFDomain leveraging the UndeprecateDomain service API.
    * Added cmdlet Restore-SWFWorkflowType leveraging the UndeprecateWorkflowType service API.
    * Modified cmdlet New-SWFDomain: added parameter Tag.
  * Amazon WAF
    * Added cmdlet Add-WAFResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WAFResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WAFResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-WAFRateBasedRule: added parameter Tag.
    * Modified cmdlet New-WAFRule: added parameter Tag.
    * Modified cmdlet New-WAFRuleGroup: added parameter Tag.
    * Modified cmdlet New-WAFWebACL: added parameter Tag.
  * Amazon WAF Regional
    * Added cmdlet Add-WAFRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-WAFRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-WAFRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-WAFRRateBasedRule: added parameter Tag.
    * Modified cmdlet New-WAFRRule: added parameter Tag.
    * Modified cmdlet New-WAFRRuleGroup: added parameter Tag.
    * Modified cmdlet New-WAFRWebACL: added parameter Tag.

### 3.3.542.0 (2019-06-28)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.542.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Modified cmdlet New-ALXBContact: added parameters PhoneNumberList and SipAddress.
    * Modified cmdlet Update-ALXBContact: added parameters PhoneNumberList and SipAddress.
  * Amazon API Gateway
    * Modified cmdlet New-AGDomainName: added parameter SecurityPolicy.
  * Amazon API Gateway V2
    * Added cmdlet Add-AG2ResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AG2Tag leveraging the GetTags service API.
    * Added cmdlet Remove-AG2ResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-AG2Api: added parameter Tag.
    * Modified cmdlet New-AG2DomainName: added parameter Tag.
    * Modified cmdlet New-AG2Stage: added parameter Tag.
  * Amazon App Mesh
    * Modified cmdlet New-AMSHVirtualNode: added parameters AwsCloudMap_Attribute, AwsCloudMap_NamespaceName and AwsCloudMap_ServiceName.
    * Modified cmdlet Update-AMSHVirtualNode: added parameters AwsCloudMap_Attribute, AwsCloudMap_NamespaceName and AwsCloudMap_ServiceName.
  * Amazon Certificate Manager Private Certificate Authority
    * Modified cmdlet New-PCACertificate: added parameter TemplateArn.
  * Amazon CloudWatch Application Insights. Added cmdlets to support the service. Cmdlets for the service have the noun prefix CWAI and can be listed using the command 'Get-AWSCmdletName -Service CWAI'. CloudWatch Application Insights detects errors and exceptions from logs, including .NET custom application logs, SQL Server logs, IIS logs, and more, and uses a combination of built-in rules and machine learning, such as dynamic baselining, to identify common problems. You can then easily drill into specific issues with CloudWatch Automatic Dashboards that are dynamically generated. These dashboards contain the most recent alarms, a summary of relevant metrics, and log snippets to help you identify root cause.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters SecondarySourceVersion and SourceVersion.
    * Modified cmdlet Update-CBProject: added parameters SecondarySourceVersion and SourceVersion.
  * Amazon CodeCommit
    * Added cmdlet Get-CCFileMergeConflict leveraging the DescribeMergeConflicts service API.
    * Added cmdlet Get-CCFileMergeConflictBatch leveraging the BatchDescribeMergeConflicts service API.
    * Added cmdlet Get-CCMergeCommit leveraging the GetMergeCommit service API.
    * Added cmdlet Get-CCMergeOption leveraging the GetMergeOptions service API.
    * Added cmdlet Merge-CCBranchesByFastForward leveraging the MergeBranchesByFastForward service API.
    * Added cmdlet Merge-CCBranchesBySquash leveraging the MergeBranchesBySquash service API.
    * Added cmdlet Merge-CCBranchesByThreeWay leveraging the MergeBranchesByThreeWay service API.
    * Added cmdlet Merge-CCPullRequestBySquash leveraging the MergePullRequestBySquash service API.
    * Added cmdlet Merge-CCPullRequestByThreeWay leveraging the MergePullRequestByThreeWay service API.
    * Added cmdlet New-CCUnreferencedMergeCommit leveraging the CreateUnreferencedMergeCommit service API.
    * Modified cmdlet Get-CCMergeConflict: added parameters ConflictDetailLevel, ConflictResolutionStrategy, MaxConflictFile and NextToken.
  * Amazon Direct Connect
    * Modified cmdlet Enable-DCPrivateVirtualInterface: added parameter NewPrivateVirtualInterfaceAllocation_Tag.
    * Modified cmdlet Enable-DCPublicVirtualInterface: added parameter NewPublicVirtualInterfaceAllocation_Tag.
    * Modified cmdlet Enable-DCTransitVirtualInterface: added parameter NewTransitVirtualInterfaceAllocation_Tag.
    * Modified cmdlet New-DCConnection: added parameter Tag.
    * Modified cmdlet New-DCHostedConnection: added parameter Tag.
    * Modified cmdlet New-DCInterconnect: added parameter Tag.
    * Modified cmdlet New-DCLag: added parameters ChildConnectionTag and Tag.
    * Modified cmdlet New-DCPrivateVirtualInterface: added parameter NewPrivateVirtualInterface_Tag.
    * Modified cmdlet New-DCPublicVirtualInterface: added parameter NewPublicVirtualInterface_Tag.
    * Modified cmdlet New-DCTransitVirtualInterface: added parameter NewTransitVirtualInterface_Tag.
  * Amazon EC2 Container Service
    * Added cmdlet Submit-ECSAttachmentStateChange leveraging the SubmitAttachmentStateChanges service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2TrafficMirrorFilterNetworkService leveraging the ModifyTrafficMirrorFilterNetworkServices service API.
    * Added cmdlet Edit-EC2TrafficMirrorFilterRule leveraging the ModifyTrafficMirrorFilterRule service API.
    * Added cmdlet Edit-EC2TrafficMirrorSession leveraging the ModifyTrafficMirrorSession service API.
    * Added cmdlet Get-EC2TrafficMirrorFilter leveraging the DescribeTrafficMirrorFilters service API.
    * Added cmdlet Get-EC2TrafficMirrorSession leveraging the DescribeTrafficMirrorSessions service API.
    * Added cmdlet Get-EC2TrafficMirrorTarget leveraging the DescribeTrafficMirrorTargets service API.
    * Added cmdlet New-EC2TrafficMirrorFilter leveraging the CreateTrafficMirrorFilter service API.
    * Added cmdlet New-EC2TrafficMirrorFilterRule leveraging the CreateTrafficMirrorFilterRule service API.
    * Added cmdlet New-EC2TrafficMirrorSession leveraging the CreateTrafficMirrorSession service API.
    * Added cmdlet New-EC2TrafficMirrorTarget leveraging the CreateTrafficMirrorTarget service API.
    * Added cmdlet Remove-EC2TrafficMirrorFilter leveraging the DeleteTrafficMirrorFilter service API.
    * Added cmdlet Remove-EC2TrafficMirrorFilterRule leveraging the DeleteTrafficMirrorFilterRule service API.
    * Added cmdlet Remove-EC2TrafficMirrorSession leveraging the DeleteTrafficMirrorSession service API.
    * Added cmdlet Remove-EC2TrafficMirrorTarget leveraging the DeleteTrafficMirrorTarget service API.
    * Modified cmdlet Edit-EC2Host: added parameter HostRecovery.
    * Modified cmdlet New-EC2Host: added parameter HostRecovery.
  * Amazon ElastiCache
    * Added cmdlet Get-ECServiceUpdate leveraging the DescribeServiceUpdates service API.
    * Added cmdlet Get-ECUpdateAction leveraging the DescribeUpdateActions service API.
    * Added cmdlet Start-ECUpdateActionBatch leveraging the BatchApplyUpdateAction service API.
    * Added cmdlet Stop-ECUpdateActionBatch leveraging the BatchStopUpdateAction service API.
  * Amazon Glue
    * Added cmdlet Get-GLUEWorkflow leveraging the GetWorkflow service API.
    * Added cmdlet Get-GLUEWorkflowBatch leveraging the BatchGetWorkflows service API.
    * Added cmdlet Get-GLUEWorkflowList leveraging the ListWorkflows service API.
    * Added cmdlet Get-GLUEWorkflowRun leveraging the GetWorkflowRun service API.
    * Added cmdlet Get-GLUEWorkflowRunList leveraging the GetWorkflowRuns service API.
    * Added cmdlet Get-GLUEWorkflowRunProperty leveraging the GetWorkflowRunProperties service API.
    * Added cmdlet New-GLUEWorkflow leveraging the CreateWorkflow service API.
    * Added cmdlet Remove-GLUEWorkflow leveraging the DeleteWorkflow service API.
    * Added cmdlet Start-GLUEWorkflowRun leveraging the StartWorkflowRun service API.
    * Added cmdlet Update-GLUEWorkflow leveraging the UpdateWorkflow service API.
    * Added cmdlet Write-GLUEWorkflowRunProperty leveraging the PutWorkflowRunProperties service API.
    * Modified cmdlet New-GLUETrigger: added parameter WorkflowName.
  * Amazon GuardDuty
    * Added cmdlet Add-GDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-GDResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GDDetector: added parameter Tag.
    * Modified cmdlet New-GDFilter: added parameter Tag.
    * Modified cmdlet New-GDIPSet: added parameter Tag.
    * Modified cmdlet New-GDThreatIntelSet: added parameter Tag.
  * Amazon Identity and Access Management
    * Added cmdlet Get-IAMOrganizationsAccessReport leveraging the GetOrganizationsAccessReport service API.
    * Added cmdlet New-IAMOrganizationsAccessReport leveraging the GenerateOrganizationsAccessReport service API.
  * Amazon Neptune
    * Modified cmdlet Edit-NPTDBCluster: added parameters CloudwatchLogsExportConfiguration_DisableLogType and CloudwatchLogsExportConfiguration_EnableLogType.
    * Modified cmdlet New-NPTDBCluster: added parameter EnableCloudwatchLogsExport.
    * Modified cmdlet Restore-NPTDBClusterFromSnapshot: added parameter EnableCloudwatchLogsExport.
    * Modified cmdlet Restore-NPTDBClusterToPointInTime: added parameter EnableCloudwatchLogsExport.
  * Amazon Organizations
    * Added cmdlet Add-ORGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ORGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ORGResourceTag leveraging the UntagResource service API.
  * Amazon Personalize. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PERS and can be listed using the command 'Get-AWSCmdletName -Service PERS'. Amazon Personalize is a machine learning service that makes it easy for developers to create individualized recommendations for customers using their applications.
  * Amazon Personalize Events. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PERSE and can be listed using the command 'Get-AWSCmdletName -Service PERSE'.
  * Amazon Personalize Runtime. Added cmdlets to support the service. Cmdlets for the service have the noun prefix PERSR and can be listed using the command 'Get-AWSCmdletName -Service PERSR'.
  * Amazon RDS DataService
    * Added cmdlet Start-RDSDTransaction leveraging the BeginTransaction service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBInstance: added parameter MaxAllocatedStorage.
    * Modified cmdlet New-RDSDBInstance: added parameter MaxAllocatedStorage.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMTransformJob: added parameters DataProcessing_InputFilter, DataProcessing_JoinSource and DataProcessing_OutputFilter.
  * Amazon Security Hub
    * [Breaking Change] Removed cmdlet Get-SHUBProductSubscriberList.
    * Added cmdlet Add-SHUBResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SHUBActionTarget leveraging the DescribeActionTargets service API.
    * Added cmdlet Get-SHUBHub leveraging the DescribeHub service API.
    * Added cmdlet Get-SHUBResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet New-SHUBActionTarget leveraging the CreateActionTarget service API.
    * Added cmdlet Remove-SHUBActionTarget leveraging the DeleteActionTarget service API.
    * Added cmdlet Remove-SHUBResourceTag leveraging the UntagResource service API.
    * Added cmdlet Update-SHUBActionTarget leveraging the UpdateActionTarget service API.
    * Modified cmdlet Enable-SHUBSecurityHub: added parameter Tag.
  * Amazon Service Catalog
    * Modified cmdlet Update-SCProvisioningArtifact: added parameter Guidance.
  * Amazon Service Quotas. Added cmdlets to support the service. Cmdlets for the service have the noun prefix SQ and can be listed using the command 'Get-AWSCmdletName -Service SQ'. Service Quotas enables you to view and manage your quotas for AWS services from a central location.
  * Amazon Simple Email Service
    * Added cmdlet Write-SESConfigurationSetDeliveryOption leveraging the PutConfigurationSetDeliveryOptions service API.
  * Amazon Storage Gateway
    * Added cmdlet Update-SGSMBSecurityStrategy leveraging the UpdateSMBSecurityStrategy service API.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMOpsItem leveraging the GetOpsItem service API.
    * Added cmdlet Get-SSMOpsItemSummary leveraging the DescribeOpsItems service API.
    * Added cmdlet Get-SSMOpsSummary leveraging the GetOpsSummary service API.
    * Added cmdlet New-SSMOpsItem leveraging the CreateOpsItem service API.
    * Added cmdlet Update-SSMOpsItem leveraging the UpdateOpsItem service API.
    * Modified cmdlet Remove-SSMDocument: added parameters DocumentVersion and VersionName.
  * Amazon WorkSpaces
    * Added cmdlet Copy-WKSWorkspaceImage leveraging the CopyWorkspaceImage service API.

### 3.3.522.0 (2019-05-31)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.522.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Added cmdlet Add-ALXBContactToAddressBook leveraging the AssociateContactWithAddressBook service API.
    * Added cmdlet Add-ALXBDeviceToNetworkProfile leveraging the AssociateDeviceWithNetworkProfile service API.
    * Added cmdlet Get-ALXBNetworkProfile leveraging the GetNetworkProfile service API.
    * Added cmdlet New-ALXBNetworkProfile leveraging the CreateNetworkProfile service API.
    * Added cmdlet Remove-ALXBNetworkProfile leveraging the DeleteNetworkProfile service API.
    * Added cmdlet Search-ALXBNetworkProfile leveraging the SearchNetworkProfiles service API.
    * Added cmdlet Update-ALXBNetworkProfile leveraging the UpdateNetworkProfile service API.
  * Amazon API Gateway
    * Modified cmdlet New-AGApiKey: added parameter Tag.
    * Modified cmdlet New-AGClientCertificate: added parameter Tag.
    * Modified cmdlet New-AGDomainName: added parameter Tag.
    * Modified cmdlet New-AGRestApi: added parameter Tag.
    * Modified cmdlet New-AGUsagePlan: added parameter Tag.
    * Modified cmdlet New-AGVpcLink: added parameter Tag.
  * Amazon AppStream
    * Added cmdlet Get-APSUsageReportSubscription leveraging the DescribeUsageReportSubscriptions service API.
    * Added cmdlet New-APSUsageReportSubscription leveraging the CreateUsageReportSubscription service API.
    * Added cmdlet Remove-APSUsageReportSubscription leveraging the DeleteUsageReportSubscription service API.
    * Modified cmdlet New-APSFleet: added parameter IdleDisconnectTimeoutInSecond.
    * Modified cmdlet Update-APSFleet: added parameter IdleDisconnectTimeoutInSecond.
  * Amazon Budgets
    * Modified cmdlet New-BGTBudget: added parameter Budget_PlannedBudgetLimit.
    * Modified cmdlet Update-BGTBudget: added parameter NewBudget_PlannedBudgetLimit.
  * Amazon Chime
    * Added cmdlet Get-CHMBot leveraging the GetBot service API.
    * Added cmdlet Get-CHMBotList leveraging the ListBots service API.
    * Added cmdlet Get-CHMEventsConfiguration leveraging the GetEventsConfiguration service API.
    * Added cmdlet New-CHMBot leveraging the CreateBot service API.
    * Added cmdlet Remove-CHMEventsConfiguration leveraging the DeleteEventsConfiguration service API.
    * Added cmdlet Update-CHMBot leveraging the UpdateBot service API.
    * Added cmdlet Update-CHMSecurityToken leveraging the RegenerateSecurityToken service API.
    * Added cmdlet Write-CHMEventsConfiguration leveraging the PutEventsConfiguration service API.
    * Modified cmdlet Search-CHMAvailablePhoneNumber: added parameter TollFreePrefix.
  * Amazon CodeCommit
    * Added cmdlet Add-CCResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CCResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CCResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CCRepository: added parameter Tag.
  * Amazon CodeDeploy
    * Added cmdlet Add-CDResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CDResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CDResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CDApplication: added parameter Tag.
    * Modified cmdlet New-CDDeploymentGroup: added parameter Tag.
  * Amazon CodePipeline
    * Added cmdlet Add-CPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CPCustomActionType: added parameter Tag.
    * Modified cmdlet New-CPPipeline: added parameter Tag.
    * Modified cmdlet Write-CPWebhook: added parameter Tag.
  * Amazon Comprehend
    * Modified cmdlet New-COMPDocumentClassifier: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet New-COMPEntityRecognizer: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPDocumentClassificationJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPDominantLanguageDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPEntitiesDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPKeyPhrasesDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPSentimentDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
    * Modified cmdlet Start-COMPTopicsDetectionJob: added parameters VpcConfig_SecurityGroupId and VpcConfig_Subnet.
  * Amazon Data Lifecycle Manager
    * Modified cmdlet New-DLMLifecyclePolicy: added parameters Parameters_ExcludeBootVolume and PolicyDetails_PolicyType.
    * Modified cmdlet Update-DLMLifecyclePolicy: added parameters Parameters_ExcludeBootVolume and PolicyDetails_PolicyType.
  * Amazon Device Farm
    * Added cmdlet Add-DFResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-DFResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-DFResourceTag leveraging the UntagResource service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Disable-EC2EbsEncryptionByDefault leveraging the DisableEbsEncryptionByDefault service API.
    * Added cmdlet Edit-EC2EbsDefaultKmsKeyId leveraging the ModifyEbsDefaultKmsKeyId service API.
    * Added cmdlet Enable-EC2EbsEncryptionByDefault leveraging the EnableEbsEncryptionByDefault service API.
    * Added cmdlet Get-EC2EbsDefaultKmsKeyId leveraging the GetEbsDefaultKmsKeyId service API.
    * Added cmdlet Get-EC2EbsEncryptionByDefault leveraging the GetEbsEncryptionByDefault service API.
    * Added cmdlet New-EC2SnapshotBatch leveraging the CreateSnapshots service API.
    * Added cmdlet Reset-EC2EbsDefaultKmsKeyId leveraging the ResetEbsDefaultKmsKeyId service API.
    * Modified cmdlet Get-EC2DhcpOption: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-EC2Subnet: added parameters MaxResult and NextToken.
    * Modified cmdlet Grant-EC2ClientVpnIngress: added parameter ClientToken.
    * Modified cmdlet New-EC2ClientVpnRoute: added parameter ClientToken.
    * Modified cmdlet Register-EC2ClientVpnTargetNetwork: added parameter ClientToken.
  * Amazon Elemental MediaPackage VOD. Added cmdlets to support the service. Cmdlets for the service have the noun prefix EMPV and can be listed using the command 'Get-AWSCmdletName -Service EMPV'. AWS Elemental MediaPackage now supports Video-on-Demand (VOD) workflows. These new features allow you to easily deliver a vast library of source video Assets stored in your own S3 buckets using a small set of simple to set up Packaging Configurations and Packaging Groups.
  * Amazon Ground Station. Added cmdlets to support the service. Cmdlets for the service have the noun prefix GS and can be listed using the command 'Get-AWSCmdletName -Service GS'. AWS Ground Station is a fully managed service that enables you to control satellite communications, downlink and process satellite data, and scale your satellite operations efficiently and cost-effectively without having to build or manage your own ground station infrastructure.
  * Amazon IoT Events. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTE and can be listed using the command 'Get-AWSCmdletName -Service IOTE'. The AWS IoT Events service allows customers to monitor their IoT devices and sensors to detect failures or changes in operation and to trigger actions when these events occur.
  * Amazon IoT Events Data. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTED and can be listed using the command 'Get-AWSCmdletName -Service IOTED'.
  * Amazon IoT Things Graph. Added cmdlets to support the service. Cmdlets for the service have the noun prefix IOTTG and can be listed using the command 'Get-AWSCmdletName -Service IOTTG'.
  * Amazon Managed Streaming for Kafka
    * Added cmdlet Get-MSKClusterOperation leveraging the DescribeClusterOperation service API.
    * Added cmdlet Get-MSKClusterOperationList leveraging the ListClusterOperations service API.
    * Added cmdlet Get-MSKConfiguration leveraging the DescribeConfiguration service API.
    * Added cmdlet Get-MSKConfigurationList leveraging the ListConfigurations service API.
    * Added cmdlet Get-MSKConfigurationRevision leveraging the DescribeConfigurationRevision service API.
    * Added cmdlet Get-MSKConfigurationRevisionList leveraging the ListConfigurationRevisions service API.
    * Added cmdlet New-MSKConfiguration leveraging the CreateConfiguration service API.
    * Added cmdlet Update-MSKBrokerStorage leveraging the UpdateBrokerStorage service API.
    * Added cmdlet Update-MSKClusterConfiguration leveraging the UpdateClusterConfiguration service API.
    * Modified cmdlet New-MSKCluster: added parameters ConfigurationInfo_Arn, ConfigurationInfo_Revision, EncryptionInTransit_ClientBroker, EncryptionInTransit_InCluster, Tag and Tls_CertificateAuthorityArnList.
  * Amazon Pinpoint Email
    * Added cmdlet Get-PINEDomainDeliverabilityCampaign leveraging the GetDomainDeliverabilityCampaign service API.
    * Added cmdlet Get-PINEDomainDeliverabilityCampaignList leveraging the ListDomainDeliverabilityCampaigns service API.
    * [Breaking Change] Modified cmdlet Get-PINEDeliverabilityDashboardOption: output changed from System.Boolean to Amazon.PinpointEmail.Model.GetDeliverabilityDashboardOptionsResponse.
    * Modified cmdlet New-PINEConfigurationSet: added parameter DeliveryOptions_TlsPolicy.
    * Modified cmdlet Write-PINEConfigurationSetDeliveryOption: added parameter TlsPolicy.
    * Modified cmdlet Write-PINEDeliverabilityDashboardOption: added parameter SubscribedDomain.
  * Amazon RDS DataService
    * Added cmdlet Confirm-RDSDTransaction leveraging the CommitTransaction service API.
    * Added cmdlet Invoke-RDSDStatement leveraging the ExecuteStatement service API.
    * Added cmdlet Invoke-RDSDStatementBatch leveraging the BatchExecuteStatement service API.
    * Added cmdlet Reset-RDSDTransaction leveraging the RollbackTransaction service API.
  * Amazon Relational Database Service
    * Added cmdlet Start-RDSActivityStream leveraging the StartActivityStream service API.
    * Added cmdlet Stop-RDSActivityStream leveraging the StopActivityStream service API.
    * Modified cmdlet Get-RDSDBEngineVersion: added parameter IncludeAll.
  * Amazon RoboMaker
    * Added cmdlet Stop-ROBODeploymentJob leveraging the CancelDeploymentJob service API.
  * Amazon Security Hub
    * Added cmdlet Get-SHUBProduct leveraging the DescribeProducts service API.
    * Added cmdlet Get-SHUBProductSubscriberList leveraging the ListProductSubscribers service API.
  * Amazon Service Catalog
    * Added cmdlet Get-SCStackInstancesForProvisionedProduct leveraging the ListStackInstancesForProvisionedProduct service API.
    * Added cmdlet Update-SCProvisionedProductProperty leveraging the UpdateProvisionedProductProperties service API.
  * Amazon Simple Storage Service
    * Modified cmdlet Write-S3BucketReplication: added parameter Token.
  * Amazon Storage Gateway
    * Added cmdlet Add-SGTapeToTapePool leveraging the AssignTapePool service API.
    * Modified cmdlet New-SGSnapshot: added parameter Tag.
    * Modified cmdlet Update-SGSnapshotSchedule: added parameter Tag.
  * Amazon WorkLink
    * Added cmdlet Add-WLWebsiteAuthorizationProviderToFleet leveraging the AssociateWebsiteAuthorizationProvider service API.
    * Added cmdlet Get-WLWebsiteAuthorizationProviderList leveraging the ListWebsiteAuthorizationProviders service API.
    * Added cmdlet Remove-WLWebsiteAuthorizationProviderFromFleet leveraging the DisassociateWebsiteAuthorizationProvider service API.

### 3.3.509.0 (2019-05-14)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.509.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * AWSPowerShell cmdlets
    * [Breaking Change] Modified cmdlets Use-STSRoleWithSAML and Use-STSWebIdentityRole to honor the Set-AWSProxy configuration.
    * Modified cmdlets Clear-AWSDefaultConfiguration, Clear-AWSCredential, Set-AWSProxy, Clear-AWSProxy, Set-DefaultAWSRegion and Clear-DefaultAWSRegion: added parameter Scope.
  * Amazon Alexa For Business
    * Added cmdlet Remove-ALXBDeviceUsageData leveraging the DeleteDeviceUsageData service API.
    * Added cmdlet Send-ALXBAnnouncement leveraging the SendAnnouncement service API.
  * Amazon AppSync
    * Added cmdlet Add-ASYNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ASYNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ASYNResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Get-ASYNIntrospectionSchema: added parameter IncludeDirective.
    * Modified cmdlet New-ASYNGraphqlApi: added parameters AdditionalAuthenticationProvider and Tag.
    * Modified cmdlet Update-ASYNGraphqlApi: added parameter AdditionalAuthenticationProvider.
  * Amazon Cognito Identity Provider
    * Added cmdlet Set-CGIPUserPasswordAdmin leveraging the AdminSetUserPassword service API.
    * Modified cmdlet New-CGIPUserPool: added parameter PasswordPolicy_TemporaryPasswordValidityDay.
    * Modified cmdlet Update-CGIPUserPool: added parameter PasswordPolicy_TemporaryPasswordValidityDay.
  * Amazon Config
    * Modified cmdlet Write-CFGAggregationAuthorization: added parameter Tag.
    * Modified cmdlet Write-CFGConfigRule: added parameter Tag.
    * Modified cmdlet Write-CFGConfigurationAggregator: added parameter Tag.
  * Amazon Direct Connect
    * Added cmdlet Confirm-DCTransitVirtualInterface leveraging the ConfirmTransitVirtualInterface service API.
    * Added cmdlet Enable-DCTransitVirtualInterface leveraging the AllocateTransitVirtualInterface service API.
    * Added cmdlet New-DCTransitVirtualInterface leveraging the CreateTransitVirtualInterface service API.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2VpnConnection leveraging the ModifyVpnConnection service API.
    * Modified cmdlet New-EC2NetworkInterface: added parameter InterfaceType.
  * Amazon Elemental MediaLive
    * Added cmdlet Remove-EMLSchedule leveraging the DeleteSchedule service API.
    * Added cmdlet Update-EMLChannelClass leveraging the UpdateChannelClass service API.
  * Amazon GameLift Service
    * Added cmdlet Get-GMLScript leveraging the DescribeScript service API.
    * Added cmdlet Get-GMLScriptList leveraging the ListScripts service API.
    * Added cmdlet New-GMLScript leveraging the CreateScript service API.
    * Added cmdlet Remove-GMLScript leveraging the DeleteScript service API.
    * Added cmdlet Update-GMLScript leveraging the UpdateScript service API.
    * Modified cmdlet Get-GMLFleet: added parameter ScriptId.
    * Modified cmdlet New-GMLBuild: added parameter StorageLocation_ObjectVersion.
    * Modified cmdlet New-GMLFleet: added parameter ScriptId.
  * Amazon Identity and Access Management
    * Added cmdlet Set-IAMSecurityTokenServicePreference leveraging the SetSecurityTokenServicePreferences service API.
  * Amazon Kinesis Analytics
    * Added cmdlet Add-KINAResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KINAResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-KINAResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-KINAApplication: added parameter Tag.
  * Amazon Kinesis Analytics (v2)
    * Added cmdlet Add-KINA2ResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-KINA2ResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-KINA2ResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-KINA2Application: added parameter Tag.
  * Amazon Lambda
    * Added cmdlet Get-LMLayerVersionByArn leveraging the GetLayerVersionByArn service API.
  * Amazon Managed Blockchain. Added cmdlets to support the service. Cmdlets for the service have the noun prefix MBC and can be listed using the command 'Get-AWSCmdletName -Service MBC'. Amazon Managed Blockchain is a fully managed service that makes it easy to create and manage scalable blockchain networks using popular open source frameworks.
  * Amazon Neptune
    * Modified cmdlet Restore-NPTDBClusterFromSnapshot: added parameter DBClusterParameterGroupName.
    * Modified cmdlet Restore-NPTDBClusterToPointInTime: added parameter DBClusterParameterGroupName.
  * Amazon S3 Control
    * Added cmdlet Get-S3CJob leveraging the DescribeJob service API.
    * Added cmdlet Get-S3CJobList leveraging the ListJobs service API.
    * Added cmdlet New-S3CJob leveraging the CreateJob service API.
    * Added cmdlet Update-S3CJobPriority leveraging the UpdateJobPriority service API.
    * Added cmdlet Update-S3CJobStatus leveraging the UpdateJobStatus service API.
  * Amazon Service Catalog
    * Added cmdlet Get-SCBudgetsForResource leveraging the ListBudgetsForResource service API.
    * Added cmdlet Register-SCBudgetWithResource leveraging the AssociateBudgetWithResource service API.
    * Added cmdlet Unregister-SCBudgetFromResource leveraging the DisassociateBudgetFromResource service API.
    * Modified cmdlet New-SCProduct: added parameter ProvisioningArtifactParameters_DisableTemplateValidation.
    * Modified cmdlet New-SCProvisioningArtifact: added parameter Parameters_DisableTemplateValidation.
  * Amazon Simple Notification Service
    * Added cmdlet Add-SNSResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SNSResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SNSResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-SNSTopic: added parameter Tag.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGSMBFileShare: added parameter AdminUserList.
    * Modified cmdlet Update-SGSMBFileShare: added parameter AdminUserList.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMPatchProperty leveraging the DescribePatchProperties service API.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameter HostKey.
    * Modified cmdlet Update-TFRServer: added parameter HostKey.
  * Amazon WorkMail
    * Added cmdlet Get-WMMailboxDetail leveraging the GetMailboxDetails service API.
    * Added cmdlet Update-WMMailboxQuota leveraging the UpdateMailboxQuota service API.
  * Amazon X-Ray
    * Added cmdlet Get-XRTimeSeriesServiceStatistic leveraging the GetTimeSeriesServiceStatistics service API.
    * Modified cmdlet Get-XRTraceSummary: added parameters SamplingStrategy_Name, SamplingStrategy_Value and TimeRangeType.

### 3.3.498.0 (2019-04-24)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.498.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * SAML Configuration Cmdlets Set-AWSSamlEndpoint and Set-AWSSamlRoleProfile are now available in the AWSPowerShell.NetCore module when used under Windows.
  * Modified cmdlet Set-AWSCredential: added parameters Scope. Using Set-AWSCredential with _-Scope Global_ allows to make credentials available to the whole PowerShell session.
  * Amazon Alexa For Business
    * Added cmdlet Get-ALXBGateway leveraging the GetGateway service API.
    * Added cmdlet Get-ALXBGatewayGroup leveraging the GetGatewayGroup service API.
    * Added cmdlet Get-ALXBGatewayGroupList leveraging the ListGatewayGroups service API.
    * Added cmdlet Get-ALXBGatewayList leveraging the ListGateways service API.
    * Added cmdlet New-ALXBGatewayGroup leveraging the CreateGatewayGroup service API.
    * Added cmdlet Remove-ALXBGatewayGroup leveraging the DeleteGatewayGroup service API.
    * Added cmdlet Update-ALXBGateway leveraging the UpdateGateway service API.
    * Added cmdlet Update-ALXBGatewayGroup leveraging the UpdateGatewayGroup service API.
  * Amazon Batch
    * Modified cmdlet Register-BATJobDefinition: added parameter ContainerProperties_ResourceRequirement.
    * Modified cmdlet Submit-BATJob: added parameters ContainerOverrides_ResourceRequirement and NodeOverrides_NumNode.
  * Amazon CloudWatch
    * Added cmdlet Add-CWResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CWResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Write-CWMetricAlarm: added parameter Tag.
  * Amazon Cognito Identity Provider
    * Modified cmdlet New-CGIPUserPool: added parameter EmailConfiguration_EmailSendingAccount.
    * Modified cmdlet Update-CGIPUserPool: added parameter EmailConfiguration_EmailSendingAccount.
  * Amazon Comprehend
    * Added cmdlet Add-COMPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-COMPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-COMPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-COMPDocumentClassifier: added parameters OutputDataConfig_KmsKeyId, OutputDataConfig_S3Uri, Tag and VolumeKmsKeyId.
    * Modified cmdlet New-COMPEntityRecognizer: added parameters Tag and VolumeKmsKeyId.
    * Modified cmdlet Start-COMPDocumentClassificationJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPDominantLanguageDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPEntitiesDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPKeyPhrasesDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPSentimentDetectionJob: added parameter VolumeKmsKeyId.
    * Modified cmdlet Start-COMPTopicsDetectionJob: added parameter VolumeKmsKeyId.
  * Amazon Elastic Container Service for Kubernetes
    * Modified cmdlet New-EKSCluster: added parameter Logging_ClusterLogging.
    * Modified cmdlet Update-EKSClusterConfig: added parameter Logging_ClusterLogging.
  * Amazon Elemental MediaLive
    * Added cmdlet Update-EMLReservation leveraging the UpdateReservation service API.
    * Modified cmdlet Get-EMLOfferingList: added parameter ChannelClass.
    * Modified cmdlet Get-EMLReservationList: added parameter ChannelClass.
    * Modified cmdlet New-EMLChannel: added parameter ChannelClass.
    * Modified cmdlet New-EMLOfferingPurchase: added parameter Tag.
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameters NumberOfWorker and WorkerType.
    * Modified cmdlet Start-GLUEJobRun: added parameters NumberOfWorker and WorkerType.
  * Amazon Greengrass
    * Added cmdlet Add-GGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-GGResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GGConnectorDefinition: added parameter Tag.
    * Modified cmdlet New-GGCoreDefinition: added parameter Tag.
    * Modified cmdlet New-GGDeviceDefinition: added parameter Tag.
    * Modified cmdlet New-GGFunctionDefinition: added parameter Tag.
    * Modified cmdlet New-GGGroup: added parameter Tag.
    * Modified cmdlet New-GGLoggerDefinition: added parameter Tag.
    * Modified cmdlet New-GGResourceDefinition: added parameter Tag.
    * Modified cmdlet New-GGSubscriptionDefinition: added parameter Tag.
    * Modified cmdlet Start-GGBulkDeployment: added parameter Tag.
  * Amazon Managed Streaming for Kafka
    * Added cmdlet Add-MSKResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-MSKResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-MSKResourceTag leveraging the UntagResource service API.
  * Amazon MQ
    * Added cmdlet Get-MQBrokerEngineType leveraging the DescribeBrokerEngineTypes service API.
    * Added cmdlet Get-MQBrokerInstanceOption leveraging the DescribeBrokerInstanceOptions service API.
  * Amazon Organizations
    * Added cmdlet New-ORGGovCloudAccount leveraging the CreateGovCloudAccount service API.
  * Amazon Pinpoint Email
    * Added cmdlet Add-PINEResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PINEResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-PINEResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-PINEConfigurationSet: added parameter Tag.
    * Modified cmdlet New-PINEDedicatedIpPool: added parameter Tag.
    * Modified cmdlet New-PINEDeliverabilityTestReport: added parameter Tag.
    * Modified cmdlet New-PINEEmailIdentity: added parameter Tag.
  * Amazon Relational Database Service
    * Modified cmdlet Add-RDSRoleToDBCluster: added parameter FeatureName.
    * Modified cmdlet Edit-RDSDBCluster: added parameter ScalingConfiguration_TimeoutAction.
    * Modified cmdlet New-RDSDBCluster: added parameter ScalingConfiguration_TimeoutAction.
    * Modified cmdlet Remove-RDSRoleFromDBCluster: added parameter FeatureName.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter ScalingConfiguration_TimeoutAction.
  * Amazon Route 53
    * Modified cmdlet Update-R53HealthCheck: added parameters Disabled and ResetElement.
  * Amazon Service Catalog
    * Modified cmdlet Update-SCProvisionedProduct: added parameter Tag.
  * Amazon Storage Gateway
    * Modified cmdlet New-SGCachediSCSIVolume: added parameter Tag.
    * Modified cmdlet New-SGSMBFileShare: added parameter SMBACLEnabled.
    * Modified cmdlet New-SGStorediSCSIVolume: added parameter Tag.
    * Modified cmdlet New-SGTape: added parameter Tag.
    * Modified cmdlet New-SGTapeWithBarcode: added parameter Tag.
    * Modified cmdlet Update-SGMaintenanceStartTime: added parameter DayOfMonth.
    * Modified cmdlet Update-SGSMBFileShare: added parameter SMBACLEnabled.
  * Amazon Systems Manager
    * Modified cmdlet Write-SSMParameter: added parameters Policy and Tier.
  * Amazon WorkLink
    * Added cmdlet Get-WLDomain leveraging the DescribeDomain service API.
    * Added cmdlet Get-WLDomainList leveraging the ListDomains service API.
    * Added cmdlet Register-WLDomain leveraging the AssociateDomain service API.
    * Added cmdlet Restore-WLDomainAccess leveraging the RestoreDomainAccess service API.
    * Added cmdlet Revoke-WLDomainAccess leveraging the RevokeDomainAccess service API.
    * Added cmdlet Unregister-WLDomain leveraging the DisassociateDomain service API.
    * Added cmdlet Update-WLDomainMetadata leveraging the UpdateDomainMetadata service API.
  * Amazon WorkSpaces
    * Modified cmdlet Import-WKSWorkspaceImage: added parameter Tag.
    * Modified cmdlet New-WKSIpGroup: added parameter Tag.

### 3.3.485.0 (2019-03-28)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.485.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * AWSPowerShell.NetCore now targets PowerShell Standard (https://github.com/PowerShell/PowerShellStandard). As a preview feature, you can test using the AWSPowerShell.NetCore module under older version of PowerShell starting with PowerShell 3.0 when at least .NET Framework 4.7.2 is installed.
  * AWSPowerShell.NetCore now targets AWS .NET SDK for NetStandard 2.0.
  * This changelog is now available on GitHub at https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md. Users are also invited to create GitHub issues at https://github.com/aws/aws-tools-for-powershell/issues to report bugs or make feature requests.
  * [Breaking Change] AWSPowerShell.NetCore now unwraps AggregateException (https://docs.microsoft.com/en-us/dotnet/api/system.aggregateexception) when returning errors, following the same behavior as the AWSPowerShell module.
  * Amazon Alexa For Business
    * Added cmdlet Get-ALXBInvitationConfiguration leveraging the GetInvitationConfiguration service API.
    * Added cmdlet Write-ALXBInvitationConfiguration leveraging the PutInvitationConfiguration service API.
    * [Breaking Change] Modified cmdlet Add-ALXBSkillToUser: removed parameter OrganizationArn.
    * [Breaking Change] Modified cmdlet Remove-ALXBSkillFromUser: removed parameter OrganizationArn.
  * Amazon API Gateway V2
    * [Breaking Change] Modified cmdlet Get-AG2ApiMapping: removed parameter ApiId; parameter ApiMappingId now supports pipeline ByValue.
    * [Breaking Change] Modified cmdlet Remove-AG2ApiMapping: removed parameter ApiId; parameter ApiMappingId now supports pipeline ByValue.
  * Amazon App Mesh
    * Added cmdlet Add-AMSHResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-AMSHResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-AMSHVirtualService leveraging the DescribeVirtualService service API.
    * Added cmdlet Get-AMSHVirtualServiceList leveraging the ListVirtualServices service API.
    * Added cmdlet New-AMSHVirtualService leveraging the CreateVirtualService service API.
    * Added cmdlet Remove-AMSHResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-AMSHVirtualService leveraging the DeleteVirtualService service API.
    * Added cmdlet Update-AMSHMesh leveraging the UpdateMesh service API.
    * Added cmdlet Update-AMSHVirtualService leveraging the UpdateVirtualService service API.
    * Modified cmdlet New-AMSHMesh: added parameters EgressFilter_Type and Tag.
    * Modified cmdlet New-AMSHRoute: added parameters Spec_TcpRoute_Action_WeightedTarget and Tag.
    * Modified cmdlet Update-AMSHRoute: added parameter Spec_TcpRoute_Action_WeightedTarget.
    * [Breaking Change] Modified cmdlet New-AMSHVirtualNode: removed parameter Dns_ServiceName; added parameters Dns_Hostname, File_Path and Tag.
    * [Breaking Change] Modified cmdlet New-AMSHVirtualRouter: removed parameter Spec_ServiceName; added parameters Spec_Listener and Tag.
    * [Breaking Change] Modified cmdlet Update-AMSHVirtualNode: removed parameter Dns_ServiceName; added parameters Dns_Hostname and File_Path.
    * [Breaking Change] Modified cmdlet Update-AMSHVirtualRouter: removed parameter Spec_ServiceName; added parameter Spec_Listener.
  * Amazon Certificate Manager
    * Added cmdlet Invoke-ACMCertificateRenewal leveraging the RenewCertificate service API.
  * Amazon Certificate Manager Private Certificate Authority
    * Added cmdlet Get-PCAPermissionList leveraging the ListPermissions service API.
    * Added cmdlet New-PCAPermission leveraging the CreatePermission service API.
    * Added cmdlet Remove-PCAPermission leveraging the DeletePermission service API.
  * Amazon Chime
    * Added cmdlet Add-CHMPhoneNumbersToVoiceConnector leveraging the AssociatePhoneNumbersWithVoiceConnector service API.
    * Added cmdlet Add-CHMPhoneNumberToUser leveraging the AssociatePhoneNumberWithUser service API.
    * Added cmdlet Get-CHMGlobalSetting leveraging the GetGlobalSettings service API.
    * Added cmdlet Get-CHMPhoneNumber leveraging the GetPhoneNumber service API.
    * Added cmdlet Get-CHMPhoneNumberList leveraging the ListPhoneNumbers service API.
    * Added cmdlet Get-CHMPhoneNumberOrder leveraging the GetPhoneNumberOrder service API.
    * Added cmdlet Get-CHMPhoneNumberOrderList leveraging the ListPhoneNumberOrders service API.
    * Added cmdlet Get-CHMUserSetting leveraging the GetUserSettings service API.
    * Added cmdlet Get-CHMVoiceConnector leveraging the GetVoiceConnector service API.
    * Added cmdlet Get-CHMVoiceConnectorList leveraging the ListVoiceConnectors service API.
    * Added cmdlet Get-CHMVoiceConnectorOrigination leveraging the GetVoiceConnectorOrigination service API.
    * Added cmdlet Get-CHMVoiceConnectorTermination leveraging the GetVoiceConnectorTermination service API.
    * Added cmdlet Get-CHMVoiceConnectorTerminationCredentialList leveraging the ListVoiceConnectorTerminationCredentials service API.
    * Added cmdlet Get-CHMVoiceConnectorTerminationHealth leveraging the GetVoiceConnectorTerminationHealth service API.
    * Added cmdlet New-CHMPhoneNumberOrder leveraging the CreatePhoneNumberOrder service API.
    * Added cmdlet New-CHMVoiceConnector leveraging the CreateVoiceConnector service API.
    * Added cmdlet Remove-CHMPhoneNumber leveraging the DeletePhoneNumber service API.
    * Added cmdlet Remove-CHMPhoneNumberBatch leveraging the BatchDeletePhoneNumber service API.
    * Added cmdlet Remove-CHMPhoneNumberFromUser leveraging the DisassociatePhoneNumberFromUser service API.
    * Added cmdlet Remove-CHMPhoneNumbersFromVoiceConnector leveraging the DisassociatePhoneNumbersFromVoiceConnector service API.
    * Added cmdlet Remove-CHMVoiceConnector leveraging the DeleteVoiceConnector service API.
    * Added cmdlet Remove-CHMVoiceConnectorOrigination leveraging the DeleteVoiceConnectorOrigination service API.
    * Added cmdlet Remove-CHMVoiceConnectorTermination leveraging the DeleteVoiceConnectorTermination service API.
    * Added cmdlet Remove-CHMVoiceConnectorTerminationCredential leveraging the DeleteVoiceConnectorTerminationCredentials service API.
    * Added cmdlet Restore-CHMPhoneNumber leveraging the RestorePhoneNumber service API.
    * Added cmdlet Search-CHMAvailablePhoneNumber leveraging the SearchAvailablePhoneNumbers service API.
    * Added cmdlet Update-CHMGlobalSetting leveraging the UpdateGlobalSettings service API.
    * Added cmdlet Update-CHMPhoneNumber leveraging the UpdatePhoneNumber service API.
    * Added cmdlet Update-CHMPhoneNumberBatch leveraging the BatchUpdatePhoneNumber service API.
    * Added cmdlet Update-CHMUserSetting leveraging the UpdateUserSettings service API.
    * Added cmdlet Update-CHMVoiceConnector leveraging the UpdateVoiceConnector service API.
    * Added cmdlet Write-CHMVoiceConnectorOrigination leveraging the PutVoiceConnectorOrigination service API.
    * Added cmdlet Write-CHMVoiceConnectorTermination leveraging the PutVoiceConnectorTermination service API.
    * Added cmdlet Write-CHMVoiceConnectorTerminationCredential leveraging the PutVoiceConnectorTerminationCredentials service API.
  * Amazon CloudFormation
    * [Breaking Change] Fixed a bug in Test-CFNStack causing the cmdlet to throw an exception instead of returning false, as described in the documentation, when the stack doesn't exist.
  * Amazon CloudWatch
    * [Breaking Change] The service output for the API called by the Get-CWMetricData cmdlet has been updated and it is no longer possible for this cmdlet to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon CloudWatch Events
    * Added cmdlet Add-CWEResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CWEResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CWEResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Write-CWERule: added parameter Tag.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters GitSubmodulesConfig_FetchSubmodule and S3Logs_EncryptionDisabled.
    * Modified cmdlet Start-CBBuild: added parameters GitSubmodulesConfigOverride_FetchSubmodule and S3Logs_EncryptionDisabled.
    * Modified cmdlet Update-CBProject: added parameters GitSubmodulesConfig_FetchSubmodule and S3Logs_EncryptionDisabled.
  * Amazon CodePipeline
    * Added cmdlet Get-CPActionExecutionList leveraging the ListActionExecutions service API.
  * Amazon Cognito Identity
    * Added cmdlet Add-CGIResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CGIResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CGIResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-CGIIdentityPool: added parameter IdentityPoolTag.
    * Modified cmdlet Update-CGIIdentityPool: added parameter IdentityPoolTag.
  * Amazon Cognito Identity Provider
    * Added cmdlet Add-CGIPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CGIPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CGIPResourceTag leveraging the UntagResource service API.
  * Amazon Config
    * Added cmdlet Add-CFGResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-CFGRemediationConfiguration leveraging the DescribeRemediationConfigurations service API.
    * Added cmdlet Get-CFGRemediationExecutionStatus leveraging the DescribeRemediationExecutionStatus service API.
    * Added cmdlet Get-CFGResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-CFGRemediationConfiguration leveraging the DeleteRemediationConfiguration service API.
    * Added cmdlet Remove-CFGResourceTag leveraging the UntagResource service API.
    * Added cmdlet Select-CFGResourceConfig leveraging the SelectResourceConfig service API.
    * Added cmdlet Start-CFGRemediationExecution leveraging the StartRemediationExecution service API.
    * Added cmdlet Write-CFGRemediationConfiguration leveraging the PutRemediationConfigurations service API.
  * Amazon Cost and Usage Report
    * Modified cmdlet Write-CURReportDefinition: added parameters ReportDefinition_RefreshClosedReport and ReportDefinition_ReportVersioning.
  * Amazon Database Migration Service
    * Added cmdlet Complete-DMSPendingMaintenanceAction leveraging the ApplyPendingMaintenanceAction service API.
    * Added cmdlet Get-DMSPendingMaintenanceAction leveraging the DescribePendingMaintenanceActions service API.
    * Modified cmdlet Edit-DMSEndpoint: added parameters RedshiftSettings_AcceptAnyDate, RedshiftSettings_AfterConnectScript, RedshiftSettings_BucketFolder, RedshiftSettings_BucketName, RedshiftSettings_ConnectionTimeout, RedshiftSettings_DatabaseName, RedshiftSettings_DateFormat, RedshiftSettings_EmptyAsNull, RedshiftSettings_EncryptionMode, RedshiftSettings_FileTransferUploadStream, RedshiftSettings_LoadTimeout, RedshiftSettings_MaxFileSize, RedshiftSettings_Password, RedshiftSettings_Port, RedshiftSettings_RemoveQuote, RedshiftSettings_ReplaceChar, RedshiftSettings_ReplaceInvalidChar, RedshiftSettings_ServerName, RedshiftSettings_ServerSideEncryptionKmsKeyId, RedshiftSettings_ServiceAccessRoleArn, RedshiftSettings_TimeFormat, RedshiftSettings_TrimBlank, RedshiftSettings_TruncateColumn, RedshiftSettings_Username, RedshiftSettings_WriteBufferSize, S3Settings_CdcInsertsOnly, S3Settings_DataFormat, S3Settings_DataPageSize, S3Settings_DictPageSizeLimit, S3Settings_EnableStatistic, S3Settings_EncodingType, S3Settings_EncryptionMode, S3Settings_ParquetVersion, S3Settings_RowGroupLength and S3Settings_ServerSideEncryptionKmsKeyId.
    * Modified cmdlet Get-DMSReplicationTask: added parameter WithoutSetting.
    * Modified cmdlet New-DMSEndpoint: added parameters RedshiftSettings_AcceptAnyDate, RedshiftSettings_AfterConnectScript, RedshiftSettings_BucketFolder, RedshiftSettings_BucketName, RedshiftSettings_ConnectionTimeout, RedshiftSettings_DatabaseName, RedshiftSettings_DateFormat, RedshiftSettings_EmptyAsNull, RedshiftSettings_EncryptionMode, RedshiftSettings_FileTransferUploadStream, RedshiftSettings_LoadTimeout, RedshiftSettings_MaxFileSize, RedshiftSettings_Password, RedshiftSettings_Port, RedshiftSettings_RemoveQuote, RedshiftSettings_ReplaceChar, RedshiftSettings_ReplaceInvalidChar, RedshiftSettings_ServerName, RedshiftSettings_ServerSideEncryptionKmsKeyId, RedshiftSettings_ServiceAccessRoleArn, RedshiftSettings_TimeFormat, RedshiftSettings_TrimBlank, RedshiftSettings_TruncateColumn, RedshiftSettings_Username, RedshiftSettings_WriteBufferSize, S3Settings_CdcInsertsOnly, S3Settings_DataFormat, S3Settings_DataPageSize, S3Settings_DictPageSizeLimit, S3Settings_EnableStatistic, S3Settings_EncodingType, S3Settings_EncryptionMode, S3Settings_ParquetVersion, S3Settings_RowGroupLength and S3Settings_ServerSideEncryptionKmsKeyId.
  * Amazon Direct Connect
    * Added cmdlet Confirm-DCDirectConnectGatewayAssociationProposal leveraging the AcceptDirectConnectGatewayAssociationProposal service API.
    * Added cmdlet Get-DCDirectConnectGatewayAssociationProposal leveraging the DescribeDirectConnectGatewayAssociationProposals service API.
    * Added cmdlet New-DCDirectConnectGatewayAssociationProposal leveraging the CreateDirectConnectGatewayAssociationProposal service API.
    * Added cmdlet Remove-DCDirectConnectGatewayAssociationProposal leveraging the DeleteDirectConnectGatewayAssociationProposal service API.
    * Added cmdlet Update-DCDirectConnectGatewayAssociation leveraging the UpdateDirectConnectGatewayAssociation service API.
    * Modified cmdlet Get-DCGatewayAssociation: added parameters AssociatedGatewayId and AssociationId.
    * Modified cmdlet New-DCGatewayAssociation: added parameters AddAllowedPrefixesToDirectConnectGateway and GatewayId.
    * Modified cmdlet Remove-DCGatewayAssociation: added parameter AssociationId.
  * Amazon EC2 Container Service
    * Added cmdlet Get-ECSTaskSet leveraging the DescribeTaskSets service API.
    * Added cmdlet New-ECSTaskSet leveraging the CreateTaskSet service API.
    * Added cmdlet Remove-ECSTaskSet leveraging the DeleteTaskSet service API.
    * Added cmdlet Update-ECSServicePrimaryTaskSet leveraging the UpdateServicePrimaryTaskSet service API.
    * Added cmdlet Update-ECSTaskSet leveraging the UpdateTaskSet service API.
    * Modified cmdlet Register-ECSTaskDefinition: added parameters ProxyConfiguration_ContainerName, ProxyConfiguration_Property and ProxyConfiguration_Type.
  * Amazon Elastic Beanstalk
    * Modified cmdlet New-EBApplication: added parameter Tag.
    * Modified cmdlet New-EBApplicationVersion: added parameter Tag.
    * Modified cmdlet New-EBConfigurationTemplate: added parameter Tag.
    * Modified cmdlet New-EBPlatformVersion: added parameter Tag.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Edit-EC2InstanceEventStartTime leveraging the ModifyInstanceEventStartTime service API.
    * Modified cmdlet Get-EC2InternetGateway: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-EC2NetworkAcl: added parameters MaxResult and NextToken.
    * Modified cmdlet Get-EC2Vpc: added parameters MaxResult and NextToken.
  * Amazon Elastic Container Service for Kubernetes
    * Added cmdlet Update-EKSClusterConfig leveraging the UpdateClusterConfig service API.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter StatusUpdateIntervalInSec.
    * Modified cmdlet New-EMCJobTemplate: added parameter StatusUpdateIntervalInSec.
    * Modified cmdlet Update-EMCJobTemplate: added parameter StatusUpdateIntervalInSec.
  * Amazon Elemental MediaPackage
    * Added cmdlet Add-EMPResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMPResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMPResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-EMPChannel: added parameter Tag.
    * Modified cmdlet New-EMPOriginEndpoint: added parameter Tag.
  * Amazon Elemental MediaStore
    * Added cmdlet Start-EMSAccessLogging leveraging the StartAccessLogging service API.
    * Added cmdlet Stop-EMSAccessLogging leveraging the StopAccessLogging service API.
  * Amazon Firewall Management Service
    * Added cmdlet Get-FMSProtectionStatus leveraging the GetProtectionStatus service API.
  * Amazon GameLift Service
    * Modified cmdlet New-GMLFleet: added parameter InstanceRoleArn.
  * Amazon Glue
    * Modified cmdlet New-GLUEClassifier: added parameters CsvClassifier_AllowSingleColumn, CsvClassifier_ContainsHeader, CsvClassifier_Delimiter, CsvClassifier_DisableValueTrimming, CsvClassifier_Header, CsvClassifier_Name and CsvClassifier_QuoteSymbol.
    * Modified cmdlet New-GLUEDevEndpoint: added parameter Argument.
    * Modified cmdlet Update-GLUEClassifier: added parameters CsvClassifier_AllowSingleColumn, CsvClassifier_ContainsHeader, CsvClassifier_Delimiter, CsvClassifier_DisableValueTrimming, CsvClassifier_Header, CsvClassifier_Name and CsvClassifier_QuoteSymbol.
    * Modified cmdlet Update-GLUEDevEndpoint: added parameters AddArgument and DeleteArgument.
  * Amazon Greengrass
    * Modified cmdlet New-GGFunctionDefinition: added parameters RunAs_Gid and RunAs_Uid.
    * Modified cmdlet New-GGFunctionDefinitionVersion: added parameters RunAs_Gid and RunAs_Uid.
  * Amazon IoT
    * Added cmdlet Get-IOTStatistic leveraging the GetStatistics service API.
    * Modified cmdlet New-IOTOTAUpdate: added parameter Tag.
    * Modified cmdlet New-IOTStream: added parameter Tag.
  * Amazon Lightsail
    * Added cmdlet Remove-LSKnownHostKey leveraging the DeleteKnownHostKeys service API.
  * Amazon Mobile
    * Fixed cmdlet New-MOBLProject not loading.
  * Amazon Pinpoint
    * Added cmdlet Add-PINResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-PINResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-PINResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-PINApp: added parameter CreateApplicationRequest_Tag.
    * Modified cmdlet New-PINCampaign: added parameter WriteCampaignRequest_Tag.
    * Modified cmdlet New-PINSegment: added parameter WriteSegmentRequest_Tag.
    * Modified cmdlet Update-PINCampaign: added parameter WriteCampaignRequest_Tag.
    * Modified cmdlet Update-PINSegment: added parameter WriteSegmentRequest_Tag.
  * Amazon QuickSight
    * Added cmdlet Remove-QSUserByPrincipalId leveraging the DeleteUserByPrincipalId service API.
  * Amazon Relational Database Service
    * Modified cmdlet Edit-RDSDBCluster: added parameter CopyTagsToSnapshot.
    * Modified cmdlet New-RDSDBCluster: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-RDSDBClusterFromS3: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-RDSDBClusterFromSnapshot: added parameter CopyTagsToSnapshot.
    * Modified cmdlet Restore-RDSDBClusterToPointInTime: added parameter CopyTagsToSnapshot.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMNotebookInstance: added parameter RootAccess.
    * Modified cmdlet Update-SMNotebookInstance: added parameter RootAccess.
  * Amazon Serverless Application Repository
    * Modified cmdlet New-SARApplication: added parameter SourceCodeArchiveUrl.
    * Modified cmdlet New-SARApplicationVersion: added parameter SourceCodeArchiveUrl.
  * Amazon Storage Gateway
    * Modified cmdlet Enable-SGGateway: added parameter Tag.
    * Modified cmdlet New-SGNFSFileShare: added parameter Tag.
    * Modified cmdlet New-SGSMBFileShare: added parameter Tag.
    * Modified cmdlet New-SGTape: added parameter PoolId.
    * Modified cmdlet New-SGTapeWithBarcode: added parameter PoolId.
  * Amazon Systems Manager
    * Added cmdlet Get-SSMServiceSetting leveraging the GetServiceSetting service API.
    * Added cmdlet Reset-SSMServiceSetting leveraging the ResetServiceSetting service API.
    * Added cmdlet Update-SSMServiceSetting leveraging the UpdateServiceSetting service API.
  * Amazon Textract. Added cmdlets to support the service. Cmdlets for the service have the noun prefix TXT and can be listed using the command 'Get-AWSCmdletName -Service TXT'.
  * Amazon Transcribe Service
    * Modified cmdlet New-TRSVocabulary: added parameter VocabularyFileUri.
    * Modified cmdlet Update-TRSVocabulary: added parameter VocabularyFileUri.
  * Amazon Transfer for SFTP
    * Modified cmdlet New-TFRServer: added parameters EndpointDetails_VpcEndpointId and EndpointType.
    * Modified cmdlet Update-TFRServer: added parameters EndpointDetails_VpcEndpointId and EndpointType.

### 3.3.462.0 (2019-02-25)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.462.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Updated AWSPowerShell.NetCore manifest to reference missing assemblies.
  * Enabled pagination support for multiple cmdlets.
  * Amazon Athena
    * Added cmdlet Add-ATHResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ATHResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Get-ATHWorkGroup leveraging the GetWorkGroup service API.
    * Added cmdlet Get-ATHWorkGroupList leveraging the ListWorkGroups service API.
    * Added cmdlet New-ATHWorkGroup leveraging the CreateWorkGroup service API.
    * Added cmdlet Remove-ATHResourceTag leveraging the UntagResource service API.
    * Added cmdlet Remove-ATHWorkGroup leveraging the DeleteWorkGroup service API.
    * Added cmdlet Update-ATHWorkGroup leveraging the UpdateWorkGroup service API.
    * Modified cmdlet Get-ATHNamedQueryList: added parameter WorkGroup.
    * Modified cmdlet Get-ATHQueryExecutionList: added parameter WorkGroup.
    * Modified cmdlet New-ATHNamedQuery: added parameter WorkGroup.
    * Modified cmdlet Start-ATHQueryExecution: added parameter WorkGroup.
  * Amazon CloudFront
    * [Breaking Change] Modified cmdlets Get-CFFieldLevelEncryptionConfigList, Get-CFFieldLevelEncryptionProfileList and Get-CFPublicKeyList: enabled pagination support, this required a change of the cmdlets result type.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameter Cache_Mode.
    * Modified cmdlet New-CBWebhook: added parameter FilterGroup.
    * Modified cmdlet Start-CBBuild: added parameter CacheOverride_Mode.
    * Modified cmdlet Update-CBProject: added parameter Cache_Mode.
    * Modified cmdlet Update-CBWebhook: added parameter FilterGroup.
  * Amazon CodeCommit
    * Added cmdlet New-CCCommit leveraging the CreateCommit service API.
  * Amazon EC2 Container Service
    * Added cmdlet Write-ECSAccountSettingDefault leveraging the PutAccountSettingDefault service API.
  * Amazon Elastic Compute Cloud
    * Modified cmdlet New-EC2ClientVpnEndpoint: added parameter TagSpecification.
  * Amazon Directory Service
    * Modified cmdlet Connect-DSDirectory: added parameter Tag.
    * Modified cmdlet New-DSDirectory: added parameter Tag.
    * Modified cmdlet New-DSMicrosoftAD: added parameter Tag.
  * Amazon Elastic File System
    * Added cmdlet Get-EFSLifecycleConfiguration leveraging the DescribeLifecycleConfiguration service API.
    * Added cmdlet Write-EFSLifecycleConfiguration leveraging the PutLifecycleConfiguration service API.
    * Modified cmdlet New-EFSFileSystem: added parameter Tag.
  * Amazon Elasticsearch
    * Modified cmdlet New-ESDomain: added parameter ZoneAwarenessConfig_AvailabilityZoneCount.
    * Modified cmdlet Update-ESDomainConfig: added parameter ZoneAwarenessConfig_AvailabilityZoneCount.
  * Amazon Elemental MediaLive
    * Added cmdlet Add-EMLResourceTag leveraging the CreateTags service API.
    * Added cmdlet Get-EMLResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMLResourceTag leveraging the DeleteTags service API.
    * Modified cmdlet New-EMLChannel: added parameter Tag.
    * Modified cmdlet New-EMLInput: added parameters Tag, Vpc_SecurityGroupId and Vpc_SubnetId.
    * Modified cmdlet New-EMLInputSecurityGroup: added parameter Tag.
    * Modified cmdlet Update-EMLInputSecurityGroup: added parameter Tag.
  * Amazon Elemental MediaTailor
    * Added cmdlet Add-EMTResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMTResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMTResourceTag leveraging the UntagResource service API.
    * Modified cmdlet Set-EMTPlaybackConfiguration: added parameter Tag.
  * Amazon GameLift Service
    * Added cmdlet Remove-GMLMatchmakingRuleSet leveraging the DeleteMatchmakingRuleSet service API.
  * Amazon DynamoDB
    * [Breaking Change] Modified cmdlets Get-DDBBackupList and Get-DDBGlobalTableList: enabled pagination support, this required a change of the cmdlets result type.
  * Amazon Glue
    * Added cmdlet Add-GLUEResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-GLUECrawlerBatch leveraging the BatchGetCrawlers service API.
    * Added cmdlet Get-GLUECrawlerNameList leveraging the ListCrawlers service API.
    * Added cmdlet Get-GLUEDevEndpointBatch leveraging the BatchGetDevEndpoints service API.
    * Added cmdlet Get-GLUEDevEndpointNameList leveraging the ListDevEndpoints service API.
    * Added cmdlet Get-GLUEJobBatch leveraging the BatchGetJobs service API.
    * Added cmdlet Get-GLUEJobNameList leveraging the ListJobs service API.
    * Added cmdlet Get-GLUETag leveraging the GetTags service API.
    * Added cmdlet Get-GLUETriggerBatch leveraging the BatchGetTriggers service API.
    * Added cmdlet Get-GLUETriggerNameList leveraging the ListTriggers service API.
    * Added cmdlet Remove-GLUEResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-GLUECrawler: added parameter Tag.
    * Modified cmdlet New-GLUEDevEndpoint: added parameter Tag.
    * Modified cmdlet New-GLUEJob: added parameter Tag.
    * Modified cmdlet New-GLUETrigger: added parameter Tag.
  * Amazon IoT
    * [Breaking Change] Modified cmdlet Get-IOTThingRegistrationTaskReportList: enabled pagination support, this required a change of the cmdlet result type.
    * Modified cmdlet New-IOTScheduledAudit: added parameter Tag.
    * Modified cmdlet New-IOTSecurityProfile: added parameter AdditionalMetricsToRetain.
    * Modified cmdlet Update-IOTSecurityProfile: added parameters AdditionalMetricsToRetain, DeleteAdditionalMetricsToRetain, DeleteAlertTarget and DeleteBehavior.
  * Amazon Kinesis Video Streams
    * Modified cmdlet New-KVStream: added parameter Tag.
  * Amazon Redshift
    * [Breaking Change] Modified cmdlet Get-RSDefaultClusterParameter: enabled pagination support, this required a change of the cmdlet result type.
  * Amazon Relational Database Service
    * [Breaking Change] Modified cmdlet Get-RDSEngineDefaultParameter: enabled pagination support, this required a change of the cmdlet result type.
  * Amazon RoboMaker
    * Added cmdlet Add-ROBOResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ROBOResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ROBOResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-ROBODeploymentJob: added parameter Tag.
    * Modified cmdlet New-ROBOFleet: added parameter Tag.
    * Modified cmdlet New-ROBORobot: added parameter Tag.
    * Modified cmdlet New-ROBORobotApplication: added parameter Tag.
    * Modified cmdlet New-ROBOSimulationApplication: added parameter Tag.
    * Modified cmdlet New-ROBOSimulationJob: added parameter Tag.
  * Amazon Step Functions
    * Modified cmdlet New-SFNActivity: added parameter Tag.
    * Modified cmdlet New-SFNStateMachine: added parameter Tag.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMActivation: added parameter Tag.
    * Modified cmdlet New-SSMDocument: added parameter Tag.
    * Modified cmdlet New-SSMMaintenanceWindow: added parameter Tag.
    * Modified cmdlet New-SSMPatchBaseline: added parameter Tag.
    * Modified cmdlet Write-SSMParameter: added parameter Tag.

### 3.3.450.0 (2019-02-06)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.450.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/changelogs/SDK.CHANGELOG.ALL.md.
  * Fixed all autopaginating cmdlets so that specifying -NextToken $null correctly enables manual control of pagination.
  * Amazon API Gateway Management API. Added cmdlets to support the service. Amazon API Gateway Management API allows you to directly manage runtime aspects of your APIs. Cmdlets for the service have the noun prefix AGM and can be listed using the command 'Get-AWSCmdletName -Service AGM'.
  * Amazon API Gateway V2. Added cmdlets to support the service. Amazon API Gateway V2 allows you to programmatically setup and manage WebSocket APIs end to end. Cmdlets for the service have the noun prefix AG2 and can be listed using the command 'Get-AWSCmdletName -Service AG2'.
  * Amazon Application Discovery Service
    * Added cmdlet Get-ADSImportTask leveraging the DescribeImportTasks service API.
    * Added cmdlet Remove-ADSImportDataBatch leveraging the BatchDeleteImportData service API.
    * Added cmdlet Start-ADSImportTask leveraging the StartImportTask service API.
  * Amazon AppStream
    * Modified cmdlet New-APSFleet: added parameter Tag.
    * Modified cmdlet New-APSImageBuilder: added parameter Tag.
    * Modified cmdlet New-APSStack: added parameter Tag.
  * Amazon Backup. Added cmdlets to support the service. Amazon Backup is a unified backup service designed to protect AWS services and their associated data. Amazon Backup simplifies the creation, migration, restoration, and deletion of backups, while also providing reporting and auditing. Cmdlets for the service have the noun prefix BAK and can be listed using the command 'Get-AWSCmdletName -Service BAK'.
  * Amazon Certificate Manager Private Certificate Authority
    * Modified cmdlet New-PCACertificateAuthority: added parameter Tag.
  * Amazon CodeBuild
    * Modified cmdlet New-CBProject: added parameters Environment_ImagePullCredentialsType, RegistryCredential_Credential and RegistryCredential_CredentialProvider.
    * Modified cmdlet Start-CBBuild: added parameters ImagePullCredentialsTypeOverride, RegistryCredentialOverride_Credential and RegistryCredentialOverride_CredentialProvider.
    * Modified cmdlet Update-CBProject: added parameters Environment_ImagePullCredentialsType, RegistryCredential_Credential and RegistryCredential_CredentialProvider.
  * Amazon Cognito Identity Provider
    * Added cmdlet Update-CGIPUserPoolDomain leveraging the UpdateUserPoolDomain service API.
  * Amazon Comprehend
    * Added cmdlet Stop-COMPTrainingDocumentClassifier leveraging the StopTrainingDocumentClassifier service API.
    * Added cmdlet Stop-COMPTrainingEntityRecognizer leveraging the StopTrainingEntityRecognizer service API.
  * Amazon Device Farm
    * Modified cmdlet New-DFDevicePool: added parameter MaxDevice.
    * Modified cmdlet Update-DFDevicePool: added parameters ClearMaxDevice and MaxDevice.
  * Amazon DocumentDB. Added cmdlets to support the service. Amazon DocumentDB (with MongoDB compatibility) is a fast, reliable, and fully-managed database service. Amazon DocumentDB makes it easy for developers to set up, run, and scale MongoDB-compatible databases in the cloud. Cmdlets for the service have the noun prefix DOC and can be listed using the command 'Get-AWSCmdletName -Service DOC'.
  * Amazon EC2 Container Registry
    * Added cmdlet Add-ECRResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-ECRResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-ECRResourceTag leveraging the UntagResource service API.
    * Modified cmdlet New-ECRRepository: added parameter Tag.
  * Amazon Elastic Compute Cloud
    * Added cmdlet Add-EC2SecurityGroupToClientVpnTargetNetwork leveraging the ApplySecurityGroupsToClientVpnTargetNetwork service API.
    * Added cmdlet Edit-EC2ClientVpnEndpoint leveraging the ModifyClientVpnEndpoint service API.
    * Added cmdlet Export-EC2ClientVpnClientCertificateRevocationList leveraging the ExportClientVpnClientCertificateRevocationList service API.
    * Added cmdlet Export-EC2ClientVpnClientConfiguration leveraging the ExportClientVpnClientConfiguration service API.
    * Added cmdlet Get-EC2ClientVpnAuthorizationRule leveraging the DescribeClientVpnAuthorizationRules service API.
    * Added cmdlet Get-EC2ClientVpnConnection leveraging the DescribeClientVpnConnections service API.
    * Added cmdlet Get-EC2ClientVpnEndpoint leveraging the DescribeClientVpnEndpoints service API.
    * Added cmdlet Get-EC2ClientVpnRoute leveraging the DescribeClientVpnRoutes service API.
    * Added cmdlet Get-EC2ClientVpnTargetNetwork leveraging the DescribeClientVpnTargetNetworks service API.
    * Added cmdlet Grant-EC2ClientVpnIngress leveraging the AuthorizeClientVpnIngress service API.
    * Added cmdlet Import-EC2ClientVpnClientCertificateRevocationList leveraging the ImportClientVpnClientCertificateRevocationList service API.
    * Added cmdlet New-EC2ClientVpnEndpoint leveraging the CreateClientVpnEndpoint service API.
    * Added cmdlet New-EC2ClientVpnRoute leveraging the CreateClientVpnRoute service API.
    * Added cmdlet Register-EC2ClientVpnTargetNetwork leveraging the AssociateClientVpnTargetNetwork service API.
    * Added cmdlet Remove-EC2ClientVpnEndpoint leveraging the DeleteClientVpnEndpoint service API.
    * Added cmdlet Remove-EC2ClientVpnRoute leveraging the DeleteClientVpnRoute service API.
    * Added cmdlet Revoke-EC2ClientVpnIngress leveraging the RevokeClientVpnIngress service API.
    * Added cmdlet Stop-EC2ClientVpnConnection leveraging the TerminateClientVpnConnections service API.
    * Added cmdlet Unregister-EC2ClientVpnTargetNetwork leveraging the DisassociateClientVpnTargetNetwork service API.
    * Modified cmdlet Edit-EC2InstancePlacement: added parameter PartitionNumber.
    * Modified cmdlet Get-EC2SpotInstanceRequest: enabled pagination support.
    * Modified cmdlet Get-EC2VpcPeeringConnection: enabled pagination support.
    * Modified cmdlet New-EC2Fleet: added parameters OnDemandOptions_SingleAvailabilityZone and SpotOptions_SingleAvailabilityZone.
    * Modified cmdlet New-EC2PlacementGroup: added parameter PartitionCount.
  * Amazon Elemental MediaConnect
    * Added cmdlet Add-EMCNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-EMCNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-EMCNResourceTag leveraging the UntagResource service API.
  * Amazon Elemental MediaConvert
    * Modified cmdlet New-EMCJob: added parameter AccelerationSettings_Mode.
    * Modified cmdlet New-EMCJobTemplate: added parameter AccelerationSettings_Mode.
    * Modified cmdlet Update-EMCJobTemplate: added parameter AccelerationSettings_Mode.
  * Amazon Firewall Management Service
    * Modified cmdlet Remove-FMSPolicy: added parameter DeleteAllPolicyResource.
  * Amazon Glue
    * Modified cmdlet New-GLUEJob: added parameter MaxCapacity.
    * Modified cmdlet Start-GLUEJobRun: added parameter MaxCapacity.
  * Amazon IoT
    * Modified cmdlet New-IOTTopicRule: added parameter Tag.
  * Amazon Lightsail
    * Modified cmdlet New-LSDiskSnapshot: added parameter InstanceName.
  * Amazon QuickSight
    * [Breaking Change] The response data from the corresponding service's API has been extended. The output from the corresponding Register-QSUser cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Register-QSUser).User_ in place of _Register-QSUser_.
  * Amazon Rekognition
    * [Breaking Change] The response data from the corresponding service's API has been extended. The output from the corresponding Find-REKModerationLabel cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Find-REKModerationLabel).ModerationLabels_ in place of _Find-REKModerationLabel_.
  * Amazon Relational Database Service
    * Added cmdlet Add-RDSRoleToDBInstance leveraging the AddRoleToDBInstance service API.
    * Added cmdlet Remove-RDSRoleFromDBInstance leveraging the RemoveRoleFromDBInstance service API.
  * Amazon SageMaker Service
    * Modified cmdlet Get-SMCompilationJobList: added parameters SortBy and SortOrder.
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameter TrainingJobDefinition_EnableInterContainerTrafficEncryption.
    * Modified cmdlet New-SMTrainingJob: added parameter EnableInterContainerTrafficEncryption.
  * Amazon Shield
    * Modified cmdlet Get-SHLDProtection: added parameter ResourceArn.
  * Amazon Step Functions
    * Added cmdlet Add-SFNResourceTag leveraging the TagResource service API.
    * Added cmdlet Get-SFNResourceTag leveraging the ListTagsForResource service API.
    * Added cmdlet Remove-SFNResourceTag leveraging the UntagResource service API.
  * Amazon Storage Gateway
    * Added cmdlet Dismount-SGVolume leveraging the DetachVolume service API.
    * Added cmdlet Mount-SGVolume leveraging the AttachVolume service API.
    * Modified cmdlet Join-SGDomain: added parameters DomainController and OrganizationalUnit.
  * Amazon Systems Manager
    * Modified cmdlet New-SSMAssociation: added parameter AutomationTargetParameterName.
    * Modified cmdlet Update-SSMAssociation: added parameter AutomationTargetParameterName.
  * Amazon Simple Workflow Service. Added cmdlets to support the service. Amazon Simple Workflow Service helps developers build, run, and scale background jobs that have parallel or sequential steps. You can think of Amazon SWF as a fully-managed state tracker and task coordinator in the Cloud. Cmdlets for the service have the noun prefix SWF and can be listed using the command 'Get-AWSCmdletName -Service SWF'.
  * Amazon WorkLink. Added cmdlets to support the service. Amazon WorkLink is a fully managed, cloud-based service that enables secure, one-click access to internal websites and web apps from mobile phones. With Amazon WorkLink, employees can access internal websites as seamlessly as they access any other website. IT administrators can manage users, devices, and domains by enforcing their own security and access policies via the AWS Console or the AWS SDK. Cmdlets for the service have the noun prefix WL and can be listed using the command 'Get-AWSCmdletName -Service WL'.
