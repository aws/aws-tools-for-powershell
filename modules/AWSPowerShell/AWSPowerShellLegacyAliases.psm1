# Shell Configuration
Set-Alias -Name Clear-AWSCredentials -Value Clear-AWSCredential
Set-Alias -Name Clear-AWSDefaults -Value Clear-AWSDefaultConfiguration
Set-Alias -Name Get-AWSCredentials -Value Get-AWSCredential
Set-Alias -Name Initialize-AWSDefaults -Value Initialize-AWSDefaultConfiguration
Set-Alias -Name New-AWSCredentials -Value New-AWSCredential
Set-Alias -Name Set-AWSCredentials -Value Set-AWSCredential

# AlexaForBusiness
Set-Alias -Name Add-ALXBContactWithAddressBook -Value Add-ALXBContactToAddressBook
Set-Alias -Name Remove-ALXBSmartHomeAppliances -Value Remove-ALXBSmartHomeAppliance

# ApiGatewayV2
Set-Alias -Name Get-AG2ApiLis -Value Get-AG2ApiList

# ApplicationAutoScaling
Set-Alias -Name Write-AASScalingPolicy -Value Set-AASScalingPolicy

# ApplicationDiscoveryService
Set-Alias -Name Remove-ADSApplications -Value Remove-ADSApplication

# AutoScaling
Set-Alias -Name Add-ASInstances -Value Mount-ASInstance
Set-Alias -Name Dismount-ASInstances -Value Dismount-ASInstance
Set-Alias -Name Get-ASAccountLimits -Value Get-ASAccountLimit
Set-Alias -Name Get-ASLifecycleHooks -Value Get-ASLifecycleHook
Set-Alias -Name Get-ASLifecycleHookTypes -Value Get-ASLifecycleHookType

# AWSSupport
Set-Alias -Name Get-ASACases -Value Get-ASACase
Set-Alias -Name Get-ASACommunications -Value Get-ASACommunication
Set-Alias -Name Get-ASAServices -Value Get-ASAService
Set-Alias -Name Get-ASASeverityLevels -Value Get-ASASeverityLevel
Set-Alias -Name Get-ASATrustedAdvisorCheckRefreshStatuses -Value Get-ASATrustedAdvisorCheckRefreshStatus
Set-Alias -Name Get-ASATrustedAdvisorChecks -Value Get-ASATrustedAdvisorCheck
Set-Alias -Name Get-ASATrustedAdvisorCheckSummaries -Value Get-ASATrustedAdvisorCheckSummary

# Backup
Set-Alias -Name Remove-BAKBackupVaultNotifications -Value Remove-BAKBackupVaultNotification

# Batch
Set-Alias -Name Get-BATJobsList -Value Get-BATJobList

# CloudFormation
Set-Alias -Name Get-CFNAccountLimits -Value Get-CFNAccountLimit
Set-Alias -Name Get-CFNStackEvents -Value Get-CFNStackEvent
Set-Alias -Name Get-CFNStackResources -Value Get-CFNStackResourceList
Set-Alias -Name Get-CFNStackResourceSummaries -Value Get-CFNStackResourceSummary
Set-Alias -Name Get-CFNStackSummaries -Value Get-CFNStackSummary

# CloudFront
Set-Alias -Name Get-CFCloudFrontOriginAccessIdentities -Value Get-CFCloudFrontOriginAccessIdentityList
Set-Alias -Name Get-CFDistributions -Value Get-CFDistributionList
Set-Alias -Name Get-CFInvalidations -Value Get-CFInvalidationList
Set-Alias -Name Get-CFStreamingDistributions -Value Get-CFStreamingDistributionList

# CloudHSM
Set-Alias -Name Get-HSMAvailableZones -Value Get-HSMAvailableZone

# CloudSearch
Set-Alias -Name Get-CSAnalysisSchemes -Value Get-CSAnalysisScheme
Set-Alias -Name Get-CSAvailabilityOptions -Value Get-CSAvailabilityOption
Set-Alias -Name Get-CSIndexFields -Value Get-CSIndexField
Set-Alias -Name Get-CSListDomainNames -Value Get-CSDomainNameList
Set-Alias -Name Get-CSScalingParameters -Value Get-CSScalingParameter
Set-Alias -Name Get-CSServiceAccessPolicies -Value Get-CSServiceAccessPolicy
Set-Alias -Name Update-CSAvailabilityOptions -Value Update-CSAvailabilityOption
Set-Alias -Name Update-CSScalingParameters -Value Update-CSScalingParameter
Set-Alias -Name Update-CSServiceAccessPolicies -Value Update-CSServiceAccessPolicy

# CloudSearchDomain
Set-Alias -Name Get-CSDSuggestions -Value Get-CSDSuggestion
Set-Alias -Name Search-CSDDocuments -Value Search-CSDDocument
Set-Alias -Name Write-CSDDocuments -Value Write-CSDDocument

# CloudTrail
Set-Alias -Name Add-CTTag -Value Add-CTResourceTag
Set-Alias -Name Find-CTEvents -Value Find-CTEvent
Set-Alias -Name Get-CTEventSelectors -Value Get-CTEventSelector
Set-Alias -Name Get-CTTag -Value Get-CTResourceTag
Set-Alias -Name Remove-CTTag -Value Remove-CTResourceTag
Set-Alias -Name Write-CTEventSelectors -Value Write-CTEventSelector

# CloudWatch
Set-Alias -Name Get-CWMetrics -Value Get-CWMetricList
Set-Alias -Name Get-CWMetricStatistics -Value Get-CWMetricStatistic

# CloudWatchLogs
Set-Alias -Name Get-CWLExportTasks -Value Get-CWLExportTask
Set-Alias -Name Get-CWLLogEvents -Value Get-CWLLogEvent
Set-Alias -Name Get-CWLLogGroups -Value Get-CWLLogGroup
Set-Alias -Name Get-CWLLogStreams -Value Get-CWLLogStream
Set-Alias -Name Get-CWLMetricFilters -Value Get-CWLMetricFilter
Set-Alias -Name Get-CWLSubscriptionFilters -Value Get-CWLSubscriptionFilter
Set-Alias -Name Write-CWLLogEvents -Value Write-CWLLogEvent

# CodeDeploy
Set-Alias -Name Get-CDApplications -Value Get-CDApplicationBatch
Set-Alias -Name Get-CDDeployments -Value Get-CDDeploymentBatch

# CodePipeline
Set-Alias -Name Get-CPActionableJobs -Value Get-CPActionableJobList
Set-Alias -Name Get-CPActionableThirdPartyJobs -Value Get-CPActionableThirdPartyJobList
Set-Alias -Name Get-CPJobDetails -Value Get-CPJobDetail
Set-Alias -Name Get-CPThirdPartyJobDetails -Value Get-CPThirdPartyJobDetail

# ConfigService
Set-Alias -Name Get-CFGConfigRules -Value Get-CFGConfigRule
Set-Alias -Name Get-CFGConfigurationRecorders -Value Get-CFGConfigurationRecorder
Set-Alias -Name Get-CFGDeliveryChannels -Value Get-CFGDeliveryChannel
Set-Alias -Name Write-CFGEvaluations -Value Write-CFGEvaluation

# CostAndUsageReport
Set-Alias -Name Get-CURReportDefinitions -Value Get-CURReportDefinition

# DataPipeline
Set-Alias -Name Add-DPTags -Value Add-DPResourceTag
Set-Alias -Name Remove-DPTags -Value Remove-DPResourceTag

# DirectConnect
Set-Alias -Name Get-DCLocations -Value Get-DCLocation

# DirectoryService
Set-Alias -Name Add-DSIpRoutes -Value Add-DSIpRoute
Set-Alias -Name Get-DSIpRoutes -Value Get-DSIpRouteList
Set-Alias -Name Remove-DSIpRoutes -Value Remove-DSIpRoute

# DynamoDBv2
Set-Alias -Name Get-DDBBackupsList -Value Get-DDBBackupList
Set-Alias -Name Get-DDBTables -Value Get-DDBTableList
Set-Alias -Name Get-GlobalTablesList -Value Get-GlobalTableList

# EC2
Set-Alias -Name Confirm-EC2EndpointConnection -Value Approve-EC2EndpointConnection
Set-Alias -Name Confirm-EC2ReservedInstancesExchangeQuote -Value Approve-EC2ReservedInstancesExchangeQuote
Set-Alias -Name Confirm-EC2TransitGatewayPeeringAttachment -Value Approve-EC2TransitGatewayPeeringAttachment
Set-Alias -Name Confirm-EC2TransitGatewayVpcAttachment -Value Approve-EC2TransitGatewayVpcAttachment
Set-Alias -Name Confirm-EC2VpcPeeringConnection -Value Approve-EC2VpcPeeringConnection
Set-Alias -Name Edit-EC2Hosts -Value Edit-EC2Host
Set-Alias -Name Get-EC2AccountAttributes -Value Get-EC2AccountAttribute
Set-Alias -Name Get-EC2ExportTasks -Value Get-EC2ExportTask
Set-Alias -Name Get-EC2FlowLogs -Value Get-EC2FlowLog
Set-Alias -Name Get-EC2Hosts -Value Get-EC2Host
Set-Alias -Name Get-EC2ReservedInstancesModifications -Value Get-EC2ReservedInstancesModification
Set-Alias -Name Get-EC2Snapshots -Value Get-EC2Snapshot
Set-Alias -Name Get-EC2VpcPeeringConnections -Value Get-EC2VpcPeeringConnection
Set-Alias -Name New-EC2FlowLogs -Value New-EC2FlowLog
Set-Alias -Name New-EC2Hosts -Value New-EC2Host
Set-Alias -Name ReleaseHosts -Value Remove-EC2Host
Set-Alias -Name Remove-EC2FlowLogs -Value Remove-EC2FlowLog

# ECS
Set-Alias -Name Get-ECSClusters -Value Get-ECSClusterList
Set-Alias -Name Get-ECSContainerInstances -Value Get-ECSContainerInstanceList
Set-Alias -Name Get-ECSTaskDefinitionFamilies -Value Get-ECSTaskDefinitionFamilyList
Set-Alias -Name Get-ECSTaskDefinitions -Value Get-ECSTaskDefinitionList
Set-Alias -Name Get-ECSTasks -Value Get-ECSTaskList

# ElastiCache
Set-Alias -Name Get-ECCacheEngineVersions -Value Get-ECCacheEngineVersion
Set-Alias -Name Get-ECCacheSubnetGroups -Value Get-ECCacheSubnetGroup
Set-Alias -Name Get-ECReplicationGroups -Value Get-ECReplicationGroup
Set-Alias -Name Get-ECSnapshots -Value Get-ECSnapshot

# ElasticBeanstalk
Set-Alias -Name Get-EBApplications -Value Get-EBApplication
Set-Alias -Name Get-EBApplicationVersions -Value Get-EBApplicationVersion
Set-Alias -Name Get-EBAvailableSolutionStack -Value Get-EBAvailableSolutionStackList
Set-Alias -Name Get-EBConfigurationOptions -Value Get-EBConfigurationOption
Set-Alias -Name Get-EBConfigurationSettings -Value Get-EBConfigurationSetting
Set-Alias -Name Get-EBEnvironmentResources -Value Get-EBEnvironmentResource
Set-Alias -Name Set-EBEnvironmentCNAMEs -Value Set-EBEnvironmentCNAME
Set-Alias -Name Test-EBConfigurationSettings -Value Test-EBConfigurationSetting

# ElasticLoadBalancing
Set-Alias -Name Add-ELBTags -Value Add-ELBResourceTag
Set-Alias -Name Get-ELBTags -Value Get-ELBResourceTag
Set-Alias -Name Remove-ELBTags -Value Remove-ELBResourceTag

# ElasticMapReduce
Set-Alias -Name Add-EMRTag -Value Add-EMRResourceTag
Set-Alias -Name Get-EMRBootstrapActions -Value Get-EMRBootstrapActionList
Set-Alias -Name Get-EMRClusters -Value Get-EMRClusterList
Set-Alias -Name Get-EMRInstanceFleets -Value Get-EMRInstanceFleetList
Set-Alias -Name Get-EMRInstanceGroups -Value Get-EMRInstanceGroupList
Set-Alias -Name Get-EMRInstances -Value Get-EMRInstanceList
Set-Alias -Name Get-EMRSteps -Value Get-EMRStepList
Set-Alias -Name Remove-EMRTag -Value Remove-EMRResourceTag
Set-Alias -Name Set-EMRVisibleToAllUsers -Value Set-EMRVisibleToAllUser
Set-Alias -Name Stop-EMRSteps -Value Stop-EMRStep

# Elasticsearch
Set-Alias -Name Add-ESTag -Value Add-ESResourceTag
Set-Alias -Name Get-ESTag -Value Get-ESResourceTag
Set-Alias -Name Remove-ESTag -Value Remove-ESResourceTag

# ElasticTranscoder
Set-Alias -Name Update-ETSPipelineNotifications -Value Update-ETSPipelineNotification

# Glacier
Set-Alias -Name Get-GLCVaultTagsList -Value Get-GLCVaultTagList

# Glue
Set-Alias -Name Get-GLUECrawlerMetricsList -Value Get-GLUECrawlerMetricList

# IdentityManagement
Set-Alias -Name Get-IAMAccountAuthorizationDetails -Value Get-IAMAccountAuthorizationDetail
Set-Alias -Name Get-IAMAttachedGroupPolicies -Value Get-IAMAttachedGroupPolicyList
Set-Alias -Name Get-IAMAttachedRolePolicies -Value Get-IAMAttachedRolePolicyList
Set-Alias -Name Get-IAMAttachedUserPolicies -Value Get-IAMAttachedUserPolicyList
Set-Alias -Name Get-IAMGroupPolicies -Value Get-IAMGroupPolicyList
Set-Alias -Name Get-IAMGroups -Value Get-IAMGroupList
Set-Alias -Name Get-IAMInstanceProfiles -Value Get-IAMInstanceProfileList
Set-Alias -Name Get-IAMOpenIDConnectProviders -Value Get-IAMOpenIDConnectProviderList
Set-Alias -Name Get-IAMPolicies -Value Get-IAMPolicyList
Set-Alias -Name Get-IAMPolicyVersions -Value Get-IAMPolicyVersionList
Set-Alias -Name Get-IAMRolePolicies -Value Get-IAMRolePolicyList
Set-Alias -Name Get-IAMRoles -Value Get-IAMRoleList
Set-Alias -Name Get-IAMSAMLProviders -Value Get-IAMSAMLProviderList
Set-Alias -Name Get-IAMServerCertificates -Value Get-IAMServerCertificateList
Set-Alias -Name Get-IAMUserPolicies -Value Get-IAMUserPolicyList
Set-Alias -Name Get-IAMUsers -Value Get-IAMUserList

# IoT
Set-Alias -Name Get-IOTAttachedPoliciesList -Value Get-IOTAttachedPolicyList
Set-Alias -Name Get-IOTAuthorizersList -Value Get-IOTAuthorizerList
Set-Alias -Name Get-IOTIndicesList -Value Get-IOTIndexList
Set-Alias -Name Get-IOTJobsList -Value Get-IOTJobList
Set-Alias -Name Get-IOTLoggingOptions -Value Get-IOTLoggingOption
Set-Alias -Name Get-IOTPolicyPrincipalsList -Value Get-IOTPolicyPrincipalList
Set-Alias -Name Get-IOTRoleAliasesList -Value Get-IOTRoleAliasList
Set-Alias -Name Get-IOTThingGroupsList -Value Get-IOTThingGroupList
Set-Alias -Name Get-IOTThingRegistrationTaskReportsList -Value Get-IOTThingRegistrationTaskReportList
Set-Alias -Name Get-IOTThingRegistrationTasksList -Value Get-IOTThingRegistrationTaskList
Set-Alias -Name Get-IOTThingTypesList -Value Get-IOTThingTypeList
Set-Alias -Name Get-IOTV2LoggingLevelsList -Value Get-IOTV2LoggingLevelList
Set-Alias -Name Get-IOTViolationEventsList -Value Get-IOTViolationEventList
Set-Alias -Name Set-IOTLoggingOptions -Value Set-IOTLoggingOption

# KeyManagementService
Set-Alias -Name Get-KMSAliases -Value Get-KMSAliasList
Set-Alias -Name Get-KMSGrants -Value Get-KMSGrantList
Set-Alias -Name Get-KMSKeyPolicies -Value Get-KMSKeyPolicyList
Set-Alias -Name Get-KMSKeys -Value Get-KMSKeyList

# Kinesis
Set-Alias -Name Get-KINStreams -Value Get-KINStreamList

# Lambda
Set-Alias -Name Get-LMEventSourceMappings -Value Get-LMEventSourceMappingList
Set-Alias -Name Get-LMFunctions -Value Get-LMFunctionList

# LexModelsV2
Set-Alias -Name Build-LMBV2BotLocale -Value Invoke-LMBV2BuildBotLocale

# MachineLearning
Set-Alias -Name Add-MLTag -Value Add-MLResourceTag
Set-Alias -Name Get-MLBatchPredictions -Value Get-MLBatchPredictionList
Set-Alias -Name Get-MLDataSources -Value Get-MLDataSourceList
Set-Alias -Name Get-MLEvaluations -Value Get-MLEvaluationList
Set-Alias -Name Get-MLModels -Value Get-MLModelList
Set-Alias -Name Get-MLTag -Value Get-MLResourceTag
Set-Alias -Name Remove-MLTag -Value Remove-MLResourceTag

# OpsWorks
Set-Alias -Name Get-OPSApps -Value Get-OPSApp
Set-Alias -Name Get-OPSCommands -Value Get-OPSCommand
Set-Alias -Name Get-OPSDeployments -Value Get-OPSDeployment
Set-Alias -Name Get-OPSElasticIps -Value Get-OPSElasticIp
Set-Alias -Name Get-OPSElasticLoadBalancers -Value Get-OPSElasticLoadBalancer
Set-Alias -Name Get-OPSInstances -Value Get-OPSInstance
Set-Alias -Name Get-OPSLayers -Value Get-OPSLayer
Set-Alias -Name Get-OPSPermissions -Value Get-OPSPermission
Set-Alias -Name Get-OPSRaidArrays -Value Get-OPSRaidArray
Set-Alias -Name Get-OPSRdsDbInstances -Value Get-OPSRdsDbInstance
Set-Alias -Name Get-OPSServiceErrors -Value Get-OPSServiceError
Set-Alias -Name Get-OPSStackProvisioningParameters -Value Get-OPSStackProvisioningParameter
Set-Alias -Name Get-OPSStacks -Value Get-OPSStack
Set-Alias -Name Get-OPSUserProfiles -Value Get-OPSUserProfile
Set-Alias -Name Get-OPSVolumes -Value Get-OPSVolume

# Organizations
Set-Alias -Name Enable-ORGAllFeatures -Value Enable-ORGAllFeature

# RDS
Set-Alias -Name Get-RDSAccountAttributes -Value Get-RDSAccountAttribute
Set-Alias -Name Get-RDSCertificates -Value Get-RDSCertificate
Set-Alias -Name Get-RDSDBLogFiles -Value Get-RDSDBLogFile
Set-Alias -Name Get-RDSDBSnapshotAttributes -Value Get-RDSDBSnapshotAttribute
Set-Alias -Name Get-RDSEventCategories -Value Get-RDSEventCategory
Set-Alias -Name Get-RDSEventSubscriptions -Value Get-RDSEventSubscription
Set-Alias -Name Get-RDSPendingMaintenanceActions -Value Get-RDSPendingMaintenanceAction
Set-Alias -Name Get-RDSReservedDBInstancesOffering -Value New-RDSReservedDBInstancesOfferingPurchase
Set-Alias -Name Get-RDSReservedDBInstancesOfferings -Value Get-RDSReservedDBInstancesOfferingList

# RDSDataService
Set-Alias -Name Begin-RDSDTransaction -Value Start-RDSDTransaction
Set-Alias -Name Commit-RDSDTransaction -Value Confirm-RDSDTransaction
Set-Alias -Name Rollback-RDSDTransaction -Value Reset-RDSDTransaction

# Redshift
Set-Alias -Name Edit-RSClusterIamRoles -Value Edit-RSClusterIamRole
Set-Alias -Name Get-RSClusterParameterGroups -Value Get-RSClusterParameterGroup
Set-Alias -Name Get-RSClusterParameters -Value Get-RSClusterParameter
Set-Alias -Name Get-RSClusters -Value Get-RSCluster
Set-Alias -Name Get-RSClusterSecurityGroups -Value Get-RSClusterSecurityGroup
Set-Alias -Name Get-RSClusterSnapshots -Value Get-RSClusterSnapshot
Set-Alias -Name Get-RSClusterSubnetGroups -Value Get-RSClusterSubnetGroup
Set-Alias -Name Get-RSClusterVersions -Value Get-RSClusterVersion
Set-Alias -Name Get-RSDefaultClusterParameters -Value Get-RSDefaultClusterParameter
Set-Alias -Name Get-RSEventCategories -Value Get-RSEventCategory
Set-Alias -Name Get-RSEvents -Value Get-RSEvent
Set-Alias -Name Get-RSEventSubscriptions -Value Get-RSEventSubscription
Set-Alias -Name Get-RSHsmClientCertificates -Value Get-RSHsmClientCertificate
Set-Alias -Name Get-RSHsmConfigurations -Value Get-RSHsmConfiguration
Set-Alias -Name Get-RSOrderableClusterOptions -Value Get-RSOrderableClusterOption
Set-Alias -Name Get-RSReservedNodeOfferings -Value Get-RSReservedNodeOffering
Set-Alias -Name Get-RSReservedNodes -Value Get-RSReservedNode
Set-Alias -Name Get-RSTags -Value Get-RSResourceTag
Set-Alias -Name New-RSTags -Value New-RSResourceTag
Set-Alias -Name Remove-RSTags -Value Remove-RSResourceTag

# Rekognition
Set-Alias -Name Get-REKStreamProcessorsList -Value Get-REKStreamProcessorList

# Route53
Set-Alias -Name Get-R53CheckerIpRanges -Value Get-R53CheckerIpRange
Set-Alias -Name Get-R53GeoLocations -Value Get-R53GeoLocationList
Set-Alias -Name Get-R53HealthChecks -Value Get-R53HealthCheckList
Set-Alias -Name Get-R53HostedZones -Value Get-R53HostedZoneList
Set-Alias -Name Get-R53ReusableDelegationSets -Value Get-R53ReusableDelegationSetList
Set-Alias -Name Get-R53TagsForResources -Value Get-R53TagsForResourceList
Set-Alias -Name Get-R53TrafficPolicies -Value Get-R53TrafficPolicyList
Set-Alias -Name Get-R53TrafficPolicyInstances -Value Get-R53TrafficPolicyInstanceList
Set-Alias -Name Get-R53TrafficPolicyVersions -Value Get-R53TrafficPolicyVersionList

# Route53Domains
Set-Alias -Name Get-R53DDomainAvailability -Value Test-R53DDomainAvailability
Set-Alias -Name Get-R53DDomains -Value Get-R53DDomainList
Set-Alias -Name Get-R53DOperations -Value Get-R53DOperationList
Set-Alias -Name Update-R53DDomainNameservers -Value Update-R53DDomainNameserver

# S3
Set-Alias -Name Remove-S3MultipartUploads -Value Remove-S3MultipartUpload

# ServiceCatalog
Set-Alias -Name Get-SCAcceptedPortfolioSharesList -Value Get-SCAcceptedPortfolioShareList
Set-Alias -Name Get-SCProductPortfoliosList -Value Get-SCProductPortfolioList

# SimpleEmail
Set-Alias -Name Get-SESIdentityMailFromDomainAttributes -Value Get-SESIdentityMailFromDomainAttribute
Set-Alias -Name Get-SESReceiptFilters -Value Get-SESReceiptFilterList
Set-Alias -Name Get-SESReceiptRuleSets -Value Get-SESReceiptRuleSetList
Set-Alias -Name Get-SESSendStatistics -Value Get-SESSendStatistic

# SimpleNotificationService
Set-Alias -Name Get-SNSEndpointAttributes -Value Get-SNSEndpointAttribute
Set-Alias -Name Get-SNSPlatformApplicationAttributes -Value Get-SNSPlatformApplicationAttribute
Set-Alias -Name Get-SNSPlatformApplications -Value Get-SNSPlatformApplicationList
Set-Alias -Name Get-SNSSMSAttributes -Value Get-SNSSMSAttribute
Set-Alias -Name Set-SNSEndpointAttributes -Value Set-SNSEndpointAttribute
Set-Alias -Name Set-SNSPlatformApplicationAttributes -Value Set-SNSPlatformApplicationAttribute
Set-Alias -Name Set-SNSSMSAttributes -Value Set-SNSSMSAttribute

# SimpleSystemsManagement
Set-Alias -Name Get-SSMComplianceItemsList -Value Get-SSMComplianceItemList
Set-Alias -Name Get-SSMComplianceSummariesList -Value Get-SSMComplianceSummaryList
Set-Alias -Name Get-SSMInventoryEntriesList -Value Get-SSMInventoryEntryList
Set-Alias -Name Get-SSMMaintenanceWindowTargets -Value Get-SSMMaintenanceWindowTarget
Set-Alias -Name Get-SSMParameterNameList -Value Get-SSMParameterValue
Set-Alias -Name Get-SSMResourceComplianceSummariesList -Value Get-SSMResourceComplianceSummaryList

# Snowball
Set-Alias -Name Get-SNOWJobsList -Value Get-SNOWJobList

# SQS
Set-Alias -Name Get-SQSDeadLetterSourceQueues -Value Get-SQSDeadLetterSourceQueue

# StorageGateway
Set-Alias -Name Get-SGChapCredentials -Value Get-SGChapCredential
Set-Alias -Name Get-SGResourceTags -Value Get-SGResourceTag
Set-Alias -Name Get-SGTapeArchives -Value Get-SGTapeArchiveList
Set-Alias -Name Get-SGTapeRecoveryPoints -Value Get-SGTapeRecoveryPointList
Set-Alias -Name Get-SGTapes -Value Get-SGTapeList
Set-Alias -Name Get-SGVolumeInitiators -Value Get-SGVolumeInitiatorList
Set-Alias -Name Get-SGVTLDevices -Value Get-SGVTLDevice
Set-Alias -Name New-SGTapes -Value New-SGTape
Set-Alias -Name Remove-SGChapCredentials -Value Remove-SGChapCredential
Set-Alias -Name Update-SGChapCredentials -Value Update-SGChapCredential

# WorkSpaces
Set-Alias -Name Get-WKSWorkspaceBundles -Value Get-WKSWorkspaceBundle
Set-Alias -Name Get-WKSWorkspaceDirectories -Value Get-WKSWorkspaceDirectory
Set-Alias -Name Get-WKSWorkspaces -Value Get-WKSWorkspace

Export-ModuleMember -Alias *