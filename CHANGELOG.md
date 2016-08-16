### 3.1.92.0 (2016-08-11)
  * Amazon Import/Export Snowball
    - Added cmdlets to support the new Import/Export Snowball service. The API for this service enables a customer to create and manage Snowball jobs without needing to use the AWS Console. The cmdlets for this service have the prefix 'SNOW' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "SNOW"'.
  * Amazon Kinesis Analytics
    - Added cmdlets to support the new Amazon Kinesis Analytics service, a fully managed service for continuously querying streaming data using standard SQL. With Kinesis Analytics, you can write standard SQL queries on streaming data and gain actionable insights in real-time, without having to learn any new programming skills. The service allows you to build applications that continuously read data from streaming data sources, process that data using standard SQL, and send the processed data to up to four destinations of your choice. Kinesis Analytics enables you to generate time-series analytics, feed a real-time dashboard, create real-time alarms and notifications, and much more. The cmdlets for this service have the prefix 'KINA' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "KINA"'.
  * Elastic Load Balancing V2
    - Added cmdlets to support the new V2 API for Elastic Load Balancing. The cmdlets for this service have the prefix 'ELB2' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "ELB2"'.
  * Auto Scaling
    - Added cmdlets to support the launch of the new V2 API for Elastic Load Balancing. The new cmdlets are Add-ASLoadBalancerTargetGroup (AttachLoadBalancerTargetGroups API), Dismount-ASLoadBalancerTargetGroup (DetachLoadBalancerTargetGroups API) and Get-ASLoadBalancerTargetGroup (DescribeLoadBalancerTargetGroups API).
  * AWS Key Management.
    - Added new cmdlets to support new import key features. This new support enables you to import keys from your own key management infrastructure to KMS for greater control over generation and storage of keys and meeting compliance requirements of sensitive workloads. The new cmdlets are Import-KMSKeyMaterial (ImportKeyMaterial API), Get-KMSParametersForImport (GetParametersForImport API) and Remove-KMSImportedKeyMaterial (DeleteImportedKeyMaterial API).
  * Amazon S3
    - Added support for dualstack (Ipv6) endpoints. All S3 cmdlets have been extended with a new -UseDualstackEndpoint switch parameter. If set, this parameter will cause the cmdlet to use the dualstack endpoint for the specified region. Note that not all regions support dualstack endpoints. You should consult S3 documentation to verify that a dualstack endpoint is available in the region you wish to use before specifying this switch.

### 3.1.91.0 (2016-08-09)
  * Amazon CloudFront
    - Added cmdlets to support tagging for Web and Streaming distributions. Tags make it easier for you to allocate costs and optimize spending by categorizing and grouping AWS resources. The new cmdlets are Add-CFResourceTag (TagResource API), Get-CFResourceTag (ListTagsForResource API), New-CFDistributionWithTag (CreateDistributionWithTags API), New-CFStreamingDistributionWithTags (CreateStreamingDistributionWithTags API) and Remove-CFResourceTag (UntagResource API).
  * Amazon EC2 Container Registry
    - Updated the Get-ECRImage cmdlet with a new parameter, -Filter_TagStatus, to support filtering of requests based on whether an image is tagged or untagged.
  * AWS Marketplace Commerce Analytics
    - Added a new cmdlet, Start-MCASupportDataExport, to support the new StartSupportDataExport API.

### 3.1.90.0 (2016-08-04)
  * Amazon Cognito Identity Provider
    - Updates to enable authentication support for Cognito User Pools. This update also added a number of new cmdlets: Approve-CGIPDevice (ConfirmDevice API), Disconnect-CGIPDeviceGlobal (GlobalSignOut API), Disconnect-CGIPUserGlobalAdmin (AdminUserGlobalSignOut API), Edit-CGIPDeviceStatus (UpdateDeviceStatus API), Edit-CGIP-DeviceStatusAdmin (AdminUpdateDeviceStatus API), Get-CGIPDeviceStatus (GetDevice API), Get-CGIPDeviceStatusAdmin (AdminGetDevice API), Get-CGIPDeviceList (ListDevices API), Get-CGIPDeviceListAdmin (AdminListDevices API), Send-CGIPAuthChallengeResponse (RespondToAuthChallenge API), Send-CGIPAuthChallengeResponseAdmin (AdminRespondToAuthChallenge API), Start-CGIPAuth (InitiateAuth API), Start-CGIPAuthAdmin (AdminInitiateAuth API), Stop-CGIPDeviceTracking (ForgetDevice API) and  Stop-CGIPDeviceTrackingAdmin (AdminForgetDevice API).
  * Amazon Gamelift
    - Added a new cmdlet, Find-GMLGameSession, to support the new SearchGameSessions API.
  * Amazon Relation Database Service
    - Added support for S3 snapshot ingestion with a new cmdlet, Restore-RDSDBClusterFromS3 (RestoreDBClusterFromS3 API). The Edit-RDSDBInstance cmdlet was also updated with a new parameter, -DBSubnetGroupName, to support moving DB instances between VPCs or different subnets within a VPC.

### 3.1.89.0 (2016-08-3)
  * Amazon Route53 Domains
    - Added new cmdlets to support new APIs: Update-R53DDomainRenewal (RenewDomain API, renew domains for a specified duration), Get-R53DDomainSuggestion (GetDomainSuggestions API) and Get-R53DBillingRecord (ViewBilling API).
  * Amazon Relation Database Service
    - Updated the Edit-RDSDBInstance cmdlet to support specifying license model. You can also now specify versioning of option groups.
  * AWS IoT
    - Added a new cmdlet Get-IOTOutgoingCertificate to support the new ListOutgoingCertificates API. Register-IOTCACertificate and Update-IOTCACertificate cmdlets were updated to support a new AllowAutoRegistration parameter.

### 3.1.88.0 (2016-07-30)
  * Amazon API Gateway
    - Updating the New-AGAuthorizer cmdlet to add support for Cognito User Pools Auth.
  * AWS Directory Service
    - Added support for new apis to manage routing with Microsoft AD. The new cmdlets are Add-DSIpRoutes (AddIpRoutes API), Get-DSIpRoutes (ListIpRoutes API) and Remove-DSIpRoutes (RemoveIpRoutes API).
  * Amazon Elasticsearch
    - Added a new parameter, -ElasticsearchVersion, to the New-ESDomain cmdlet to support selection of a new api version. Amazon Elasticsearch Version 2.3 offers improved performance, memory management, and security. It also offers several new features including: pipeline aggregations to perform advanced analytics like moving averages and derivatives, and enhancements to geospatial queries.

### 3.1.87.0 (2016-07-26)
  * AWS IoT
    - This update adds support for thing types. Thing types are entities that store a description of common features of Things that are of the same logical type. The new cmdlets to support Thing types are: Get-IOTThingType (DescribeThingType API), Get-IOTThingTypesList (ListThingTypes API), New-IOTThingType (CreateThingType API), Remove-IOTThingType (DeleteThingType API) and Set-IOTThingTypeDeprecation (DeprecateThingType API).

### 3.1.86.0 (2016-07-21)
  * AWS Config
    - Added new cmdlets Start-CFGConfigRulesEvaluation (StartConfigRulesEvaluation API) and Remove-CFGEvaluationResult (DeleteEvaluationResults API). For more information on rule evaluation see the release note at https://aws.amazon.com/about-aws/whats-new/2016/07/now-use-aws-config-to-record-changes-to-rds-and-acm-resources-and-write-config-rules-to-evaluate-their-state/.
  * AWS Certificate Manager
    - The output object (type Amazon.CertificateManager.Model.CertificateDetail) of the Get-CMCertificateDetail cmdlet (DescribeCertificate API) has been extended with a new field, FailureReason, indicating the reason why a certificate request failed.

### 3.1.85.1 (2016-07-19)
  * AWS Device Farm
    - Corrected a cmdlet name in the previous update. The cmdlet for the GetRemoteAccessSessions API should have been named Get-DFRemoteAccessSessionList.

### 3.1.85.0 (2016-07-19)
  * AWS Device Farm
    - Added support for new APIs for managing remote access sessions. This update adds the cmdlets Get-DFRemoteAccessSession (GetRemoteAccessSession API), Get-DFRemoteAccessSessions (ListRemoteAccessSessions API), Install-DFToRemoteAccessSession (InstallToRemoteAccessSession API), New-DFRemoteAccessSession (CreateRemoteAccessSession API), Remove-DFRemoteAccessSession (DeleteRemoteAccessSession API) and Stop-DFRemoteAccessSession (StopRemoteAccessSession API).
  * Amazon Simple Systems Management
    - Updated the Send-SSMCommand cmdlet with new parameters enabling notifications to be sent when a command terminates.

### 3.1.84.0 (2016-07-13)
  * Amazon RDS
    - Updated the Start-RDSDBClusterFailover (FailoverDBCluster API) cmdlet with a new parameter TargetDBInstanceIdentifier. Added a new cmdlet, Copy-RDSDBClusterParameterGroup, to support the new CopyDBClusterParameterGroup API.
  * Amazon ECS
    - Added a new parameter, Overrides_TaskRoleArn, to the New-ECSTask and Start-EC2Task cmdlets. Added a new parameter, TaskRoleArn, to the Register-ECSTaskDefinition cmdlet. These parameters enable you to specify an IAM role for tasks. 
  * Amazon Database Migration Service
    - Updated various cmdlets with new CertificateArn and SslMode parameters enabling use of SSL-enabled endpoints. Added new cmdlets Get-DMSCertificate (DescribeCertificates API), Import-DSMCertificate (ImportCertificate API) and Remove-DSMCertificate (DeleteCertificate API).

### 3.1.83.0 (2016-07-07)
  * AWS Service Catalog
    - Added cmdlets to support the new AWS Service Catalog service. AWS Service Catalog allows organizations to create and manage catalogs of IT services that are approved for use on AWS. The cmdlets for this service have the prefix 'SC' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service "Service Catalog"'.
  * AWS Config
    - Added a new cmdlet, Remove-CFGConfigurationRecorder, to support the new DeleteConfigurationRecorder API.
  * AWS Directory Service
    - Added new cmdlets to support resource tagging: Add-DSResourceTag (AddTagsToResource API), Get-DSResourceTag (ListTagsForResource API) and Remove-DSResourceTag (RemoveTagsFromResource API). Additionally, automatic pagination has been enabled for cmdlets in this service where the response data contains a single logical field that can be enumerated to the pipeline (Get-DSDirectory, Get-DSSnapshot and Get-DSTrust).

### 3.1.82.0 (2016-07-05)
  * AWS CodePipeline
    - Added support for manual approvals with a new cmdlet, Write-CPApprovalResult (PutApprovalResult API).

### 3.1.81.0 (2016-06-30)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS Database Migration Service
    - Added support to enable VpcSecurityGroupId to be specified for the replication instance.
  * Amazon Simple Systems Management
    - Added support for using Amazon SSM with any instance or virtual machine outside of AWS, including your own data centers or other clouds with cmdlets: Add-SSMResourceTag (AddTagsToResource API), Get-SSMActivation (DescribeActivations API), Get-SSMResourceTag (ListTagsForResource API), New-SSMActivation (CreateActivation API), Remove-SSMActivation (DeleteActivation API), Remove-SSMResourceTag (RemoveTagsFromResource API), Unregister-SSMManagedInstance (DeregisterManagedInstance API), Update-SSMManagedInstanceRole (UpdateManagedInstanceRole API).

### 3.1.80.0 (2016-06-28)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon EC2
    - Updated the Edit-EC2InstanceAttribute and Register-EC2Image cmdlets with new parameter -EnaSupport for specifying enhanced networking.
  * Amazon Elastic File System
    - Added new parameter -PerformanceMode to the New-EFSFileSystem cmdlet (CreateFileSystem API).
  * Amazon Gamelift
    - Added new cmdlets for multi-process support. The new cmdlets are Get-GMLGameSessionDetail (DescribeGameSessionDetails API), Get-GMLRuntimeConfiguration (DescribeRuntimeConfiguration API), Get-GMLScalingPolicy (DescribeScalingPolicies API), Remove-GMLScalingPolicy (DeleteScalingPolicy API), Update-GMLRuntimeConfiguration (UpdateRuntimeConfiguration API) and Write-GMLScalingPolicy (PutScalingPolicy API).

### 3.1.79.0 (2016-06-28)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.78.0 (2016-06-23)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * Amazon Cognito Identity
    - Added -CognitoIdentityProvider and -SamlProviderARN parameters to the New-CGIIdentityPool and Update-CGIIdentityPool cmdlets to support role customization.
  * AWS Direct Connect
    - Added two new cmdlets, Get-DCConnectionLoa (DescribeConnectionLoa API) and Get-DCInterconnectLoa (DescribeInterconnectLoa API).
  * Amazon EC2
    - Added support for IdentityId Format with new cmdlets Edit-EC2IdentityIdFormat (ModifyIdentityIdFormat API) and Get-EC2IdentityIdFormat (DescribeIdentityIdFormat API).

### 3.1.77.0 (2016-06-21)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS CodePipeline
    - Added a new cmdlet, Redo-CPStageExecution, to support the new RetryStageExecution API.

### 3.1.76.0 (2016-06-14)
  * Amazon Relational Database Service
    - Added a new cmdlet, Convert-RDSReadReplicaDBCluster, to support the new PromoteReadReplicaDBCluster API.
  * Amazon Simple Email Service
    - Added a new cmdlet, Set-SESIdentityHeadersInNotificationsEnable, to support the new SetIdentityHeadersInNotificationsEnabled API.

 ### 3.1.75.0 (2016-06-07)
  * AWS IoT
    - Added a new cmdlet, Get-IOTPolicyPrincipalsList, to support the new ListPolicyPrincipals API. ListPolicyPrincipals allows you to list all your principals (certificate or other credential, such as Amazon Cognito ID) attached to a given policy.
  * Amazon Machine Learning
    - Added support for new tagging APIs with new cmdlets Add-MLTag (AddTags API), Get-MLTag (DescribeTags API) and Remove-MLTag (DeleteTags API). Tags are commonly used for cost allocation and can be applied to Amazon Machine Learning datasources, models, evaluations, and batch predictions.

### 3.1.74.0 (2016-06-03)
  * AWS CodeDeploy
    - Added automatic pagination support to the Get-CDApplicationList, Get-CDApplicationRevisionList, Get-CDDeploymentConfigList, Get-CDDeploymentInstanceList, Get-CDDeploymentList and Get-CDOnPremiseInstanceList cmdlets.
  * Amazon Security Token Service (STS) and Identity and Access Management (IAM) Service
    - Corrected potential performance issue caused in the previous release by the automatic detection of region from EC2 instance metadata. If no region data was available locally (from parameter, shell variable or environment variable) the cmdlets could attempt to access metadata even when not running on an EC2 instance.
  * Amazon EC2
    - API update to the Request-EC2SpotFleet (RequestSpotFleet API) and Get-EC2SpotFleetRequest (DescribeSpotFleetRequests API). The RequestSpotFleet API can now indicate whether a Spot fleet will only 'request' the target capacity or also attempt to 'maintain' it. When you want to 'maintain' a certain target capacity, Spot fleet will place the required bids to meet this target capacity, and enable you to automatically replenish any interrupted instances. When you simply 'request' a certain target capacity, Spot fleet will only place the required bids but will not attempt to replenish Spot instances if capacity is diminished, nor will it submit bids in alternative Spot pools if capacity is not available. By default, the API is set to 'maintain'. The DescribeSpotFleetRequests API now returns two new parameters: the 'fulfilledCapacity' of a Spot fleet to indicate the capacity that has been successfully launched, and the 'type' parameter to indicate whether the fleet is meant to 'request' or 'maintain' capacity.

### 3.1.73.0 (2016-05-26)
  * Amazon EC2
    - Added a new cmdlet, Remove-EC2Instance (TerminateInstances API) following user suggestion. The existing -Terminate switch is still present on Stop-EC2Instance but is considered deprecated.
    - Added a new cmdlet, Get-EC2InstanceMetadata, to return instance metadata when running on EC2 instances. For more information see the blog post at http://blogs.aws.amazon.com/net/.
  * Added support for specifying AWS access key, secret key and session token values from environment variables. For more information see the blog post at http://blogs.aws.amazon.com/net/.
  * Added support for auto-detecting AWS region using instance metadata when cmdlets are run on EC2 instances. The Initialize-AWSDefaults cmdlets no longer prompts for region selection when run in this scenario. To set a region different to that in which the instance is running, specify the -Region parameter.

### 3.1.72.0 (2016-05-24)
  * Amazon EC2
    - Added the new cmdlet Get-EC2ConsoleSnapshot to support the new GetConsoleSnapshot API.
  * Amazon RDS
    - Added support for cross-account snapshot sharing with two new cmdlets Edit-RDSDBClusterSnapshot (ModifyDBClusterSnapshot API) and Get-RDSDBClusterSnapshot (DescribeDBClusterSnapshotAttributes API).

### 3.1.71.0 (2016-05-19)
  * AWS Application Discovery Service [Breaking Change]
    - The initial release for this service used an incorrect service model. The corrections involve two new new cmdlets, Get-ADSConfiguration (DescribeConfigurations API) and Get-ADSExportConfigurationsId (ExportConfigurations API). The existing Get-ADSExportConfiguration has been remapped to the correct DescribeExportConfigurations API. 
  * Amazon ECS
    - Updated the ECSTaskDefinitionFamilies cmdlet to add a new Status parameter. This enables filtering on active, inactive, or all task definition families. 

### 3.1.70.0 (2016-05-18)
  * Application Auto Scaling
    - Added support for Application Auto Scaling, a general purpose Auto Scaling service for supported elastic AWS resources. With Application Auto Scaling, you can automatically scale your AWS resources, with an experience similar to that of Auto Scaling. The cmdlets for this service have the prefix 'AAS' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service aas'.

### 3.1.69.0 (2016-05-17)
  * Amazon WorkSpaces
    - Added support for the new tagging APIs with three new cmdlets: Get-WKSTag (DescribeTags API), New-WKSTag (CreateTags API) and Remove-WKSTag (DeleteTags API).

### 3.1.68.0 (2016-05-12)
  * AWS Application Discovery Service [New Service]
    - Added cmdlets to support the new service. The AWS Application Discovery Service helps Systems Integrators quickly and reliably plan application migration projects by automatically identifying applications running in your data center, their associated dependencies, and their performance profile. Cmdlets for this service have the prefix 'ADS' applied to the noun portion of the cmdlet name. The cmdlets and the service APIs they map to can be listed with the command 'Get-AWSCmdletName -Service ads'.
  * Amazon EC2 Simple Systems Management
    - Added support for the new document sharing features with two new cmdlets, Get-SSMDocumentPermission (DescribeDocumentPermission API) and Edit-SSMDocumentPermission (ModifyDocumentPermission API).
  * Amazon EC2
    - Added support for identitfying stale security groups with two new cmdlets, Get-EC2SecurityGroupReference (DescribeSecurityGroupReferences API) and Get-EC2StaleSecurityGroup (DescribeStaleSecurityGroups API).

### 3.1.67.0 (2016-05-10)
  * AWS Storage Gateway
    - Added a new cmdlet, Get-SGTape, to support the new ListTapes API.
  * Amazon Elastic MapReduce
    - Added parameter InstanceState to the Get-EMRInstances cmdlet to support filtering by state.

### 3.1.66.0 (2016-05-05)
  * Amazon EC2
    - The parameter '-Instance' on the Get-EC2Instance and Stop-EC2Instance cmdlets has been renamed to '-InstanceId' to match usage in other EC2 cmdlets (this is a backwards compatible change). The two affected cmdlets continue to accept collections of string instance ids, Amazon.EC2.Model.Instance objects or Amazon.EC2.Model.Reservation objects to specify the instances to operate on.
  * AWS Key Management, Amazon Security Token Service
    - Updated cmdlet documentation to match the latest service API reference.
  * Amazon API Gateway
    - Updated the Write-AGIntegration cmdlet to support a new parameter, -PassthroughBehavior. This parameter enables you to configure pass-through behavior for incoming requests based on the Content-Type header and the available request templates defined on the integration.

### 3.1.65.0 (2016-05-03)
  * Amazon Cognito Identity Provider
    - Added support for the new Cognito Identity Provider service. The cmdlets for this service have the noun prefix 'CGIP'; you can view the set of cmdlets available and the API functions they map to with the command 'Get-AWSCmdletName -Service cgip'.

### 3.1.64.0 (2016-04-28)
  * Amazon Route53 Domains
    - Add support for new service operations ResendContactReachabilityEmail (Send-R53DContactReachability cmdlet) and GetContactReachabilityStatus (Get-R53DContactReachabilityStatus).
  * AWS OpsWorks
    - Updated the New-OPSDeployment and New-OPSInstance cmdlets to add support for default tenancy selection.

### 3.1.63.0 (2016-04-26)
  * Amazon EC2
    - Added a new cmdlet, Edit-EC2VpcPeeringConnectionOption, to support the new ModifyVpcPeeringConnectionOptions API for VPC peering with ClassicLink.
  * Amazon EC2 Container Registry
    - The repository object output by Get-ECRRepository and other cmdlets has been extended to include the repository URL.

### 3.1.62.0 (2016-04-21)
  * AWS IoT
    - Added support for specifying the SQL rules engine to be used with new parameters on the New-IOTTopicRule and Set-IOTTopicRule cmdlets.
  * AWS Certificate Manager
    - Added support for tagging with new cmdlets Add-ACMCertificateTag (AddTagsToCertificate API), Get-ACMCertificateTagList (ListTagsForCertificate API) and Remove-ACMCertificateTag (RemoveTagsFromCertificate API).

### 3.1.61.0 (2016-04-19)
  * AWS Elastic Beanstalk
    - Added support for automatic platform version upgrades with managed updates with three new cmdlets: Get-EBEnvironmentManagedAction (DescribeEnvironmentManagedAction API), Get-EBEnvironmentManagedActionHistory (DescribeEnvironmentManagedActionHistory API) and Submit-EBEnvironmentManagedAction (ApplyEnvironmentManagedAction API).
  * Amazon Kinesis
    - Added support for enhanced monitoring with two new cmdlets: Enable-KINEnhancedMonitoring (EnableEnhancedMonitoring API) and Disable-KINEnhancedMonitoring (DisableEnhancedMonitoring API). 
  * Amazon Kinesis Firehose
    - Updated the Update-KINFDestination and New-KINFDeliveryStream cmdlets with additional parameters to support Elastic Search and Cloudwatch Logs.
  * Amazon S3
    - Added support for S3 Accelerate. This adds two new cmdlets, Write-S3BucketAccelerateConfiguration (PutBucketAccelerateConfiguration API) and Get-S3BucketAccelerateConfiguration (GetBucketAccelerateConfiguration API). Cmdlets for S3 operations that support accelerated endpoints have a new parameter, -UseAccelerateEndpoint.

### 3.1.60.0 (2016-04-12)
  (This version was only released as part of the combined AWS SDK and Tools Windows Installer, and not published to the PowerShell Gallery.)
  * AWS IoT
    - Added support for “Bring your own Certificate” with new cmdlets: Get-IOTCACertificate (DescribeCACertificate API), Get-IOTCACertificateList (ListCACertificates API), Get-IOTCertificateListByCA (ListCertificatesByCA API), Get-IOTRegistrationCode (GetRegistrationCode API), Register-IOTCACertificate (RegisterCACertificate API), Register-IOTCertificate (RegisterCertificate API), Remove-IOTCACertificate (DeleteCACertificate API), Remove-IOTRegistrationCode (DeleteRegistrationCode API) and Update-IOTCACertificate (UpdateCACertificate API).

### 3.1.59.0 (2016-04-08)
  * AWS Directory Service
    - Added support for conditional forwarding with new cmdlets New-DSConditionalForwarder (CreateConditionalForwarder API), Remove-DSConditionalForwarder (DeleteConditionalForwarder API), Get-DSConditionalForwarder (DescribeConditionalForwarders API), Remove-DSTrust (DeleteTrust API) and Update-DSConditionalForwarder (UpdateConditionalForwarder API).

### 3.1.58.0 (2016-04-06)
  * Amazon Security Token Service
    - Added a new cmdlet, Get-STSCallerIdentity, to support the new GetCallerIdentity API. This API returns details about the credentials used to make an API call.
  * Amazon Route 53
    - Updated the Update-R53HealthCheck cmdlet with new parameters, -InsufficientDataHealthStatus and -AlarmIdentifier_Name, to support CloudWatch metric-based health checks.
  * Amazon API Gateway
    - Added new cmdlets, Import-AGRestApi and Write-AGRestAopi, to support the ImportRestApi and PutRestApi operations. 
  * Amazon Inspector
    - The cmdlets for this service have been recreated to match a major revision to the service API. Please note that existing scripts that use this service will need to be updated to work with the new API.
    
### 3.1.57.0 (2016-03-29)
  * AWS CloudFormation
    - Added support for ChangeSets. ChangeSets give users detailed information into what CloudFormation intends to perform when changes are executed to a stack, giving users the ability to preview and change the results before actually applying them. The new cmdlets are: Get-CFNChangeSet (DescribeChangeSet API), Get-CFNChangeSetList (ListChangeSets API), New-CFNChangeSet (CreateChangeSet API), Remove-CFNChangeSet (DeleteChangeSet API) and Start-CFNChangeSet (ExecuteChangeSet API).
  * Amazon ElastiCache
    - The Copy-ECSnapshot cmdlet has been updated to remove the -TargetBucket parameter. This parameter was included in a previous release due to an error in the service model.
  * Amazon Redshift
    - Added support for Cluster IAM Roles. Clusters can now assume an IAM Role to perform operations like COPY/UNLOAD as well as cryptographic operations involving KMS keys. This support includes a new cmdlet, Edit-RSClusterIamRoles, for the new ModifyClusterIamRoles API and the addition of an -IamRole parameter to the New-RSCluster and Restore-RSClusterFromSnapshot cmdlets.
  * AWS WAF
    - Added support for XSS (Cross-site scripting) protection in WAF with new cmdlets Get-WAFXssMatchSet (GetXssMatchSet API), Get-WAFXssMatchSetList (ListXssMatchSets API), New-WAFXssMatchSet (CreateXssMatchSet API), Remove-WAFXssMatchSet (DeleteXssMatchSet API) and Update-WAFXssMatchSet (UpdateXssMatchSet API).

### 3.1.56.0 (2016-03-25)
  * Amazon RDS
    - Extended the Edit-RDSDBInstance, New-RDSDBInstance and Restore-RDSDBInstanceFromDBSnapshot cmdlets with new parameters, -Domain and -DomainIAMRoleName, to support Windows Authentication for RDS SQL Server instances.
  * Amazon ElastiCache
    - Added support to allow vertically scaling from one instance type to another. This support consists of one new cmdlet, Get-ECAllowedNodeTypeModification (ListAllowedNodeTypeModifications API) and a new parameter, -CacheNodeType, added to the Edit-ECCacheCluster and Edit-ECReplicationGroup cmdlets.
  * AWS Storage Gateway
    - Added a new cmdlet, Set-SGLocalConsolePassword, to support the new SetLocalConsolePassword API.

### 3.1.55.0 (2016-03-22)
  * AWS Device Farm
    - Added new cmdlets to support purchasing and managing unmetered devices in a self service manner, and to stop runs which are currently executing. The new cmdlets are: Get-DFOffering (ListOfferings API), Get-DFOfferingStatus (GetOfferingStatus API), Get-DFOfferingTransaction (ListOfferingTransactions API), New-DFOfferingPurchase (PurchaseOffering API), New-DFOfferingRenewal (RenewOffering API) and Stop-DFRun (StopRun API).
  * Amazon RDS
    - Extended the New-RDSDBInstance and Edit-RDSDBInstance cmdlets with a new parameter, PromotionTier, to support customer specifiable fail-over order for read replicas in Amazon Aurora.
  * AWS Elastic Beanstalk
    - Updated the documentation for the cmdlets from the latest service documentation.

### 3.1.54.0 (2016-03-17)
  * AWS Cloud HSM
    - Added support for resource tagging with new cmdlets Set-HSMResourceTag (AddTagsToResource API), Get-HSMResourceTag (ListTagsForResource API) and  Remove-HSMResourceTag (RemoveTagsFromResource API).
  * AWS Marketplace Metering
    - Added support for the new service. Cmdlets for the service share the noun prefix 'MM' and can be listed with the command 'Get-AWSCmdletName -service mm'. At this time the service has a single cmdlet, Send-MMMeteringData (MeterUsage API). 
  * Elastic Load Balancing
    - Corrected a help example for New-ELBLoadBalancerPolicy.

### 3.1.53.0 (2016-03-15)
  * AWS Database Migration Service
    - Added support for the new AWS Database Migration Service. Cmdlets for the service share the noun prefix 'DMS' and can be listed with the command 'Get-AWSCmdletName -Service dms'.
  * AWS CodeDeploy
    - Added new cmdlet Get-CDDeploymentGroupBatch to support the new BatchGetDeploymentGroups API.
  * Amazon Simple Email Service
    - Added new cmdlets Get-SESIdentityMailFromDomainAttributes (GetIdentityMailFromDomainAttributes API) and Set-SESIdentityMailFromDomain (SetIdentityMailFromDomain API) to support custom MAIL FROM domains. For more information see the service release notes at http://aws.amazon.com/releasenotes/Amazon-SES/8381987420423821.

### 3.1.52.1 (2016-03-11)
  * Amazon S3
    - Fixed issue with NullReferenceException error being reported when MFA serial and authentication values were supplied to the Remove-S3Object cmdlet.

### 3.1.52.0 (2016-03-10)
  * Amazon Redshift
    - Added support for restore tables from a cluster snapshot to a new table in an active cluster. The new cmdlets are Get-RSTableRestoreStatus (DescribeTableRestoreStatus API) and Restore-RSTableFromClusterSnapshot (RestoreTableFromClusterSnapshot API). For more information on this feature see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html#working-with-snapshot-restore-table-from-snapshot">Restoring a Table from a Snapshot</a>.

### 3.1.51.0 (2016-03-08)
  * Amazon Kineses
    - Added support for dataplane operations with new cmdlets Get-KINRecord (GetRecords API), Get-KINShardIterator (GetShardIterator API), Write-KINRecord (PutRecord API) and Write-KINMultipleRecord (PutRecords API). Write-KINRecord allows the data to be written to be specified using either a memory stream, simple text string or path to a file containing the data. Write-KINMultipleRecord currently supports only a memory stream within each individual record instance.
  * AWS CodeCommit
    - Added support for repository triggers and retrieving information about a commit. The new cmdlets are Get-CCCommit (GetCommit API), Get-CCRepositoryTrigger (GetRepositoryTriggers API), Set-CCRepositoryTrigger (PutRepositoryTriggers API) and Test-CCRepositoryTrigger (TestRepositoryTriggers API).

  * Amazon Kinesis Firehose
    - The Write-KINFRecord cmdlet has been updated to use the same parameter names for data sources as the new Write-KINRecord cmdlet for Amazon Kinesis. In addition support for supplying data in a file and supplying the name of the file to the cmdlet has been added. The new parameter names, -Blob (MemoryStream), -Text (simple text string) and -FilePath (fully qualified name of source data file) have had the original parameter names (Record_Data, Record_Text and Record_FilePath respectively) applied as aliases for backwards compatibility. These aliases have also been applied to the equivalent parameters in Write-KINRecord for consistency.

### 3.1.50.0 (2016-03-03)
  * AWS Directory Service
    - Added support for SNS topic notifications with new cmdlets Register-DSEventTopic (RegisterEventTopic API), Get-DSEventTopic (DescribeEventTopics API) and Unregister-DSEventTopic (DeregisterEventTopic API).

### 3.1.49.0 (2016-03-01)
  * Amazon API Gateway
    - Added new cmdlets, Clear-AGStageAuthorizerCache (FlushStageAuthorizersCache API) and Test-AGInvokeAuthorizer (TestInvokeAuthorizer API).
  * Amazon DynamoDB
    - Added new cmdlet, Get-DDBProvisionLimit (DescribeLimits API). This cmdlet enables you to query the current provisioning limits for your account.

### 3.1.48.0 (2016-02-26)
  * Auto Scaling
    - Added new InstanceId parameter to the Write-ASLifecycleActionHeartbeat and Complete-ASLifecycleAction cmdlets. Updated parameter documentation in several cmdlets to match latest service documentation.
  * AWS CloudFormation
    -  Added new RetainResource parameter to Remove-CFNStack for to allow the specification the logical IDs of resources that you want to retain after stack deletion.
    - Added Tag parameter to Update-CFNStack to enable updating of tags on stacks.
  * Amazon CloudFront
    - Minor help example and documentation updates.
  * Amazon CloudWatch Logs
    - Minor documentation update to several cmdlets.

### 3.1.47.0 (2016-02-23)
  * This version contained documentation updates for Amazon Route 53 and only released as part of the combined AWS SDK and Tools Windows Installer.

### 3.1.46.0 (2016-02-19)
  * This version contained minor documentation updates and only released as part of the combined AWS SDK and Tools Windows Installer.

### 3.1.45.0 (2016-02-18)
  * AWS Storage Gateway
    - Added a new cmdlet, New-SGTapeWithBarcode, to support the CreateTapeWithBarcode API.
  * AWS CodeDeploy
    - Added two new cmdlets, Get-CDApplicationRevisionBatch and Get-CDDeploymentInstanceBatch to support the BatchGetApplicationRevisions and BatchGetDeploymentInstances APIs.

### 3.1.44.0 (2016-02-17)
  * Amazon RDS
    - Updated the Copy-RDSDBSnapshot cmdlet with a new parameter, KmsKeyId, to support cross-account encrypted snapshot sharing and updated the documentation for several other cmdlets.

### 3.1.43.0 (2016-02-11)
  * Amazon API Gateway
    - Added new cmdlets to support custom request authorizers. With custom request authorizers, developers can authorize their APIs using bearer token authorization strategies, such as OAuth using an AWS Lambda function. The new cmdlets are Get-AGAuthorizer (GetAuthorizer API), Get-AGAuthorizerList (GetAuthorizers API), Get-AGExport (GetExport API), New-AGAuthorizer (CreateAuthorizer API), Remove-AGAuthorizer (DeleteAuthorizer API) and Update-AGAuthorizer (UpdateAuthorizer API).
  * AWS Lambda
    - Updated the Update-LMFunctionConfiguration cmdlet to add support for configuring a Lambda function to access resources in your VPC. These resources could be AWS service resources (for example, Amazon Redshift data warehouses, Amazon ElastiCache clusters, or Amazon RDS instances), or they could be your own services running on your own EC2 instances. For more information see http://docs.aws.amazon.com/lambda/latest/dg/vpc.html.

### 3.1.42.0 (2016-02-09)
  * Amazon Gamelift
    - Added support for Amazon Gamelift, a managed service that allows game developers the ability to deploy and configure their multiplayer games. The new cmdlets share the noun prefix 'GML'. The cmdlets and their mapping to the service APIs can be listed using the command 'Get-AWSCmdletName -Service gamelift' (or 'Get-AWSCmdletName -Service gml').
  * Amazon EC2
    - Updated the Get-EC2ImageByName cmdlet to fix an issue where the control file mapping the logical version-independent keys to filters could not be downloaded if a proxy was in use, causing the cmdlet to error out.
  * Amazon CloudFront
    - Added a new parameter ViewerCertificate_ACMCertificateARN to the New-CFDistribution and Update-CFDistribution cmdlets. This field replaces the ViewerCertificate_CertificateSource and ViewerCertificate_Certificate parameters that were recently added.
  * AWS Marketplace Commerce Analytics
    - Updated the New-MCADataSet cmdlet with a new parameter, CustomerDefinedValue. This parameter allows customers to submit arbitrary key/value pair strings which will be returned, as provided, in the response, enabling the user of customer-provided identifiers to correlate responses with their internal systems.
  * AWS Config
    - Documentation update for parameters in several cmdlets.

### 3.1.41.0 (2016-01-28)
  * AWS WAF
    - Added new cmdlets to support the constraint set APIs. These APIs can be used to block, allow, or monitor (count) requests based on the content in HTTP request bodies. This is the part of a request that contains any additional data that you want to send to your web server as the HTTP request body, such as data from an HTML form. The new cmdlets are: Get-WAFSizeConstraintSet (GetSizeConstraintSet API), Get-WAFSizeConstraintList (ListSizeConstraintSets API), New-WAFSizeConstraintSet (CreateSizeConstraintSet API), Remove-WAFSizeConstraintSet (DeleteSizeConstraintSet API) and Update-WAFSizeConstraintSet (UpdateSizeConstraintSet API).

### 3.1.40.0 (2016-01-21)
  * AWS Certificate Manager
    - New cmdlets have been added to support the new service. The cmdlets have the noun prefix 'ACM' and can be listed with the command 'Get-AWSCmdletName -Service ACM'. AWS Certificate Manager (ACM) is an AWS service that makes it easier for you to deploy secure SSL based websites and applications on the AWS platform.
  * AWS IoT
    - Added two new cmdlets, Enable-IOTTopicRule (EnableTopicRule API) and Disable-IOTTopicRule (DisableTopicRule API) to support the latest service updates.
  * AWS CloudFormation
    - Added a new cmdlet, Resume-CFNUpdateRollback to support the new ContinueUpdateRollback API.
  * all services
    - Updated the 'Related Links' data in the native PowerShell file to enable use of -Online with Get-Help. Previously this command and option would launch a browser onto the home page for the AWSPowerShell cmdlet reference. It now navigates to the online page for the cmdlet specified to Get-Help. Additional links pointing to the service API reference home page and user/developer guides, as appropriate, have also been added to the help file for the module (previously these were only present on the web-based help pages).

### 3.1.39.0 (2016-01-19)
  * This update contains some minor service and documentation updates (for AWS Device Farm, AWS OpsWorks and Amazon Security Token Service) to maintain versioning compatibility with the underlying AWS SDK for .NET release.

### 3.1.38.0 (2016-01-14)
  * Amazon CloudWatch Events
    - Added cmdlets to support the new Amazon CloudWatch Events service. CloudWatch Events allows you to monitor and rapidly react to changes in your AWS resources. The new cmdlets share the noun prefix 'CWE' and can be listed using the command 'Get-AWSCmdletName -Service CWE'.
  * Amazon EC2
    - Added cmdlets to support the new scheduled instances feature. The cmdlets are: Get-EC2ScheduledInstance (DescribeScheduledInstances API), Get-EC2ScheduledInstanceAvailability (DescribeScheduledInstanceAvailability), New-EC2ScheduledInstance (RunScheduledInstances API) and New-EC2ScheduledInstancePurchase (PurchaseScheduledInstances API).

### 3.1.37.0 (2016-01-12)
  * Amazon EC2
    - Added new cmdlets to support DNS resolution of public hostnames to private IP addresses when queried over ClassicLink. Additionally, you can now access private hosted zones associated with your VPC from a linked EC2-Classic instance. ClassicLink DNS support makes it easier for EC2-Classic instances to communicate with VPC resources using public DNS hostnames. The new cmdlets are: GetEC2VpcClassicLinkDnsSupport (DescribeVpcClassicLinkDnsSupport API), Enable-EC2VpcClassicLinkDnsSupport (EnableVpcClassicLinkDnsSupport API) and Disable-EC2VpcClassicLinkDnsSupport (DisableVpcClassicLinkDnsSupport API).
    - Extended help examples for EC2 cmdlets.

### 3.1.36.2 (2016-01-06)
  * Amazon EC2
    - Corrected parameters for the Get-EC2NetworkInterfaceAttribute cmdlet due to errors in the underlying SDK request class for the operation. The class and the cmdlet should have exposed a single Attribute parameter, not members for each value allowed for 'Attribute'.

### 3.1.36.1 (2015-12-22)
  * Initialize-AWSDefaults
    - Fixed further reported issue with the cmdlet reporting 'profile not found' error with no profile name detailed.
    - Fixed null reference error when running on EC2 instance launched with instance profile (for credentials), when trying to save profile containing only region data.

### 3.1.36.0 (2015-12-21)
  * Set-AWSSamlRoleProfile
    - Fixed issue in parsing SAML assertions containing role ARNs from different accounts with the same role names.
  * Amazon EC2 Container Registry (ECR)
    - Added support for the new EC2 Container Registry service, a secure, fully-managed Docker image registry that makes it easy for developers to store and retrieve Docker container images. The cmdlets for the service have the noun prefix 'ECR' and can be enumerated using the command 'Get-AWSCmdletName -Service ecr'.
  * Amazon ECS
    - Add support for deployment configurations to New/Update-ECSService cmdlets.
  * Amazon Elastic MapReduce
    - Update Start-EMRJobFLow cmdlet to accept the Instances_ServiceAccessSecurityGroup parameter.

### 3.1.35.0 (2015-12-17)
  * Fixed issue in AWS SDK for .NET causing 'Path cannot be the empty string or all whitespace' errors being output when running cmdlets on systems with account that had no home or profile folder (https://github.com/aws/aws-sdk-net/issues/287).
  * Amazon EC2
    - Added cmdlets Get-EC2NatGateway (DescribeNatGateways API), New-EC2NatGateway (CreateNatGateway API) and Remove-EC2NatGateway (DeleteNatGateway API) to support the new Managed NAT for VPCs feature.
  * AWS Config
    - Added RecordingGroup_IncludeGlobalResourceType parameter to Write-CFGConfigurationRecorder parameter to support Identity and Access Management (IAM) resource types.
  * Amazon CloudFront
    - Added new parameters to the New-CFDistribution and Update-CFDistribution cmdlets. For web distributions, you can now configure CloudFront to automatically compress files of certain types for both Amazon S3 and custom origins, so downloads are faster and your web pages render faster. Compression also reduces your CloudFront data transfer cost because you pay for the total amount of data served.
  * Amazon RDS
    - Add support for enhanced monitoring in RDS instances via new MonitoringInterval and MonitoringRoleArn parameters on the Edit-RDSDBInstance, New-RDSDBInstance and New-RDSDBInstanceReadReplica cmdlets.
  * AWS CloudTrail
    - Added support for trails that apply across all regions, and support for multiple trails per region.

### 3.1.34.0 (2015-12-15)
  * Fixed issue with Initialize-AWSDefaults reporting 'profile not found' error (with no profile name listed) when entering access and secret key credentials if the host system did not already have a profile named 'default'.
  * Amazon EC2
    - Added new parameters to Copy-EC2Image cmdlet (CopyImage API) enabling AMI copies where all the associated EBS snapshots are encrypted.

### 3.1.33.0 (2015-12-08)
  * Fixed issue with 'profile not found' errors when referencing credential profiles contained in the text-format credential files shared with the AWS CLI.
  * Auto Scaling
    - Added new cmdlet, Set-ASInstanceProtection to support the new SetInstanceProtection API.
  * Amazon RDS
    - Updated the New-RDSDBCluster, Restore-RDSDBClusterFromSnapshot and Restore-RDSDBClusterToPointInTime cmdlets to support encryption using keys managed through AWS Key Management System.

### 3.1.32.0 (2015-12-03)
  * AWS Directory Service
    - Added support for managed directories with new cmdlets Approve-DSTrust (VerifyTrust API), Get-DSTrust (DescribeTrusts API), New-DSMicrosoftAD (CreateMicrosoftAD API), New-DSTrust (CreateTrust API) and Remove-DSTrust (DeleteTrust API).
  * Amazon RDS
    - Added support for modifying DB port number with a new parameter, DBPortNumber, on the Edit-RDSDBInstance cmdlet.
  * Amazon Route 53
    - Added support for the new traffic policy APIs. Running the command 'Get-AWSCmdletName -Service R53 -ApiOperation Traffic -MatchWithRegex' will list the new cmdlets and the corresponding service APIs.
  * AWS Support ApiOperation
    - Fixed bug where the cmdlets did not fallback to assume us-east-1 region if no -Region parameter was supplied or a default region was set in the current shell. Note that if a default shell region is set up and it is not us-east-1 then the -Region parameter, with value us-east-1, must be supplied to the cmdlets when they are run.

### 3.1.31.0 (2015-12-01)
  * Added support for federated user identity with Active Directory Federation Services (AD FS). Two new cmdlets, Set-AWSSamlEndpoint and Set-AWSSamlRoleProfile, enable configuration of a provider endpoint (supporting SAML based identity federation) and one or more role profiles for roles a user is authorized to assume. Once configured the role profiles can then be used with the -ProfileName parameter to the Set-AWSCredentials cmdlet, or any cmdlet that makes AWS service operation calls, to obtain temporary time limited AWS credentials with automatic credential refresh on expiry.

### 3.1.30.0 (2015-11-23)
  * Amazon EC2 Container Service
    - Added support for task stopped reasons and task start/stop times. You can now see if a task was stopped by a user or stopped due to other reasons such as a failing Elastic Load Balancing health check, as well as the time the task was started and stopped. Service scheduler error messages have additional information that describe why tasks cannot be placed in the cluster.
  * AWS Elastic Beanstalk
    - Added support for composable web applications. Applications that consist of several linked modules (micro services architecture) can now deploy, manage, and scale their applications using EB with the new Group-EBEnvironments cmdlet (ComposeEnvironments API).
  * Amazon EC2
    - Added support for dedicated hosts. This feature enables the use of your own per-socket and per-core OS licenses in EC2. This release also supports two new cmdlets Edit-EC2IdFormat ()ModifyIdFormat API) and Get-EC2IdFormat (DescribeIdFormat API) that will be used to manage the transition to longer EC2 and EBS resource IDs. These APIs are reserved for future use.

### 3.1.29.0 (2015-11-19)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.28.0 (2015-11-13)
  * Amazon RDS
    - Updated the Edit-RDSDBInstance with a new parameter, -PubliclyAccessible, to support the new instance visibility service update. Also updated documentation on several cmdlets to note support for the new M4 instance types.

### 3.1.27.0 (2015-11-10)
  * Amazon API Gateway
    - Added suppport for stage variables to the New-AGDeployment, New-AGStage and Test-AGInvokeMethod cmdlets with a new parameter, -Variable, (of Hashtable type). Stage variables act like environment variables for use in your API setup and mapping templates and enable configuration of different deployment stages (e.g., alpha, beta, production) of your API.

### 3.1.26.0 (2015-11-07)
  * AWS IoT
    - Fixed an issue affecting New-IOTKeysAndCertificate, Update-IOTCertificate and others where 'signature mismatch' errors were being returned.

### 3.1.25.0 (2015-11-03)
  * AWS DeviceFarm
    - Added new cmdlets to support the AWS Device Farm APIs to manage projects, device pools, runs, and uploads.
  * Amazon S3
    - Added a new parameter, -StorageClass, to the Write-S3Object cmdlet. This parameter enables support for selecting the STANDARD_IA storage class as well as STANDARD and REDUCED_REDUNDANCY classes. The existing switch parameters for specifying storage class, -StandardStorage and -ReducedRedundancyStorage, have been marked as deprecated.
  * Get-AWSCmdletName
    - Fixed an issue with the -AwsCliCommand option throwing errors if the service identifier parsed from the command matched more than one service by prefix or name (for example 'ec2' matches both Amazon EC2 by prefix and EC2 Container Service by name). The option now looks at the prefix codes in preference and will only attempt to match on name terms if the prefix lookup yields no results.

### 3.1.24.0 (2015-11-02)
  * AWS Identity and Access Management
    - Updated cmdlets for the IAM policy simulator to help test, verify, and understand resource-level permissions.
  * Amazon API Gateway
    - Updated the Write-AGIntegration cmdlet to fix an issue with incorrect marshalling of requests to the service.

### 3.1.23.0 (2015-10-27)
  * Amazon API Gateway
    - Added support for Amazon API Gateway, a fully managed service that makes it easy for developers to create, publish, maintain, monitor, and secure APIs at any scale. The noun prefix for cmdlets belonging to the service is 'AG'.

### 3.1.22.0 (2015-10-26)
  * Amazon EC2 Simple Systems Management
    - Added support for EC2 Run Command APIs, a new EC2 feature that enables you to securely and remotely manage the configuration of your Amazon EC2 Windows instances. Run Command provides a simple way of automating common administrative tasks like executing scripts, running PowerShell commands, installing software or patches and more.
  * Amazon Kinesis Firehose
    - Added parameter 'Record_Text' to the Write-KINFRecord cmdlet to enable write of simple text records to the service.

### 3.1.21.0 (2015-10-22)
  * AutoScaling
    - Adding support for EBS encryption in block device mappings.
  * IdentityManagement
    - Enable Policy Simulator API to do simulation with resource-based policies.
  * Get-AWSCmdletName
    - Added support for listing all cmdlets for services matching the name/prefix supplied to the -Service parameter.

### 3.1.20.0 (2015-10-15)
  * KeyManagementService
    - Add support for deleting Customer Master Keys, including two new APIs for scheduling and canceling key deletion.

### 3.1.19.1 (2015-10-11)
  * AWS IoT
    - AWS IoT offering enables our users to leverage the AWS Cloud for their Internet of things use-cases. Cmdlets for the service are identified with a noun prefix code of 'IOT'.
  * AWS Lambda
    - Lambda now supports function versioning.
  * Amazon ECS
    - Task definitions now support more Docker options.

### 3.1.18.0 (2015-10-07)
  * Amazon Kinesis Firehose
    - Amazon Kinesis Firehose is a fully managed service for ingesting data streams directly into AWS data services such as Amazon S3 and Amazon Redshift. Cmdlets for the service are identified with a noun prefix code of 'KINF'
  * Amazon Inspector
    - Amazon Inspector is a new service from AWS that identifies security issues in your application deployments. Cmdlets for the service are identified with a noun prefix code of 'INS'
  * AWS Marketplace Commerce Analytics
    - The AWS Marketplace Commerce Analytics service allows marketplace partners to programmatically request business intelligence data from AWS Marketplace. Cmdlets for the service are identified with a noun prefix code of 'MCA'.
  * AWS Config
    - Added new cmdlets to support Config Rule and Evaluations.
  * Amazon Kinesis
    - Added two new Amazon Kinesis cmdlets Request-KINStreamRetentionPeriodDecrease, and Request-KINStreamRetentionPeriodIncrease that allow customers to choose how long their data records are stored in their Amazon Kinesis streams.

### 3.1.17.0 (2015-10-06)
  * Amazon
    - Added support for integrating CloudFront with AWS WAF
  * EC2
    - Added new property BlockDurationMinutes to Request-EC2SpotInstance cmdlet. This specifies the duration for which the instance is required.
  * WAF
    - Added support for the new service. Cmdlets for the service are identified with a noun prefix code of 'WAF'.

### 3.1.16.1 (2015-10-02)
  * Amazon Elasticsearch
    - Added support for the new service. Cmdlets for the service are identified with a noun prefix code of 'ES'.

### 3.1.16.0 (2015-10-01)
  * AWS CloudTrail
    - Added new cmdlets for AWS CloudTrail: Add-CTTag, Get-CTTag, Remove-CTTag, and Get-PublicKey. This release of CloudTrail includes support for log file integrity validation, log encryption with AWS KMS–Managed Keys (SSE-KMS), and trail tagging.
  * Amazon RDS
    - Added support for t2.large DB instance, support for copying tags to snapshot, and other minor updates.

### 3.1.15.0 (2015-09-28)
  * Amazon Simple Email Service
    - Amazon Simple Email Service can now accept incoming emails. You can configure Amazon SES to deliver messages to an Amazon S3 bucket, call an AWS Lambda function, publish notifications to Amazon SNS, drop messages, or bounce messages. Added new cmdlets to support this feature.
  * AWS CloudFormation
    - Added new Get-CFNAccountLimits cmdlet, added the ResourceType parameter to New-CFNStack and Update-CFNStack cmdlets.
  * Amazon EC2
    - Added a new cmdlet - Request-EC2SpotFleet.

### 3.1.14.0 (2015-09-17)
  * Amazon CloudWatch Logs
    - Added new cmdlets (Get-CWLExportTasks, New-CWLExportTask, Stop-CWLExportTask) to support exporting log data from Log Groups to Amazon S3 Buckets.

### 3.1.13.0 (2015-09-16)
  * SDK Update for Amazon S3
    - Updated the awssdk.s3.dll assembly to include the new STANDARD_IA storage class and support for multiple lifecycle transitions. There are no changes to the Amazon S3 cmdlets.

### 3.1.12.0 (2015-09-15)
  * Amazon EC2
    - Updated the Request-EC2SpotFleet cmdlet with support for specifying allocation strategy.
    - Get-EC2Snapshot now supports additional DataEncryptionKeyId and StateMessage parameters in the returned Snapshot object.
  * Amazon Elastic File System
    - Updated the Get-EFSMountTarget cmdlet to support a new MountTargetId parameter.
  * Amazon EC2 Simple Systems Manager
    - Fixed bug in the automatic pagination support in Get-SSMDocumentList cmdlet. The cmdlet caused the service to respond with an error message due to the MaxResults parameter being set higher than 25.
  * Amazon Route 53
    - Updated the New-R53HealthCheck and Update-R53HealthCheck cmdlets to add support for calculated and latency health checks.

### 3.1.11.0 (2015-09-10)
  * Amazon S3
    - Reworked progress indication for folder uploads so that the % progress bar tracks bytes uploaded versus total to send for all files. In previous versions it tracked the number of files uploaded which could lead to periods of no progress activity if the files were large.
  * AWS Identity and Access Management
    - Added new cmdlets (Get-IAMContextKeysForCustomPolicy, Get-IAMContextKeysForPrincipalPolicy, Test-IAMCustomPolicy and Test-IAMPrincipalPolicy) to support programmatic access to the IAM policy simulator. The SimulatePrincipalPolicy API (Test-IAMPrincipalPolicy) allows you to programmatically audit permissions in your account and validate a specific user’s permissions. The SimulateCustomPolicy API (Test-IAMCustomPolicy) provides a way to verify a new policy before applying it. These new APIs allow you to automate the validation and auditing of permissions for your IAM users, groups, and roles.

### 3.1.10.0 (2015-09-03)
  * Amazon S3
    - Fixed issue in AWS SDK for .NET that caused Read-S3Object to fail to download a hierarchy of files if zero length files were present in subfolders.
  * AWS Storage Gateway
    - Added new cmdlets (Add-SGResourceTag, Get-SGResourceTags and Remove-SGResourceTag) to support tagging Storage Gateway resources.

### 3.1.9.0 (2015-08-31)
  * Amazon S3
    - Fixed issue with -Verbose option reporting an incorrect count of uploaded files when Write-S3Object cmdlet completed processing.

### 3.1.8.0 (2015-08-27)
  * Amazon CloudFront
    - Added two cmdlets, New-CFSignedUrl and New-CFSignedCookie. These cmdlets enable you to generate signed urls and cookies, using canned or custom policies, to content in CloudFront distributions.
  * AWS Config
    - Added a new cmdlet, Get-CFGDiscoveredResource, to support the new ListDiscoveredResources service api.

### 3.1.7.0 (2015-08-27)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.6.0 (2015-08-25)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.5.1 (2015-08-17)
  * Amazon Cognito Identity
    - Added cmdlets for the control plane APIs. These new cmdlets have the noun prefix 'CGI'.

### 3.1.5.0 (2015-08-12)
  * Elastic Beanstalk
    - Added new cmdlets to support the new instance health APIs: Get-EBEnvironmentHealth (DescribeEnvironmentHealth API) and Get-EBInstanceHealth (DescribeInstancesHealth API).
  * Fixes
    - The Set-AWSCredentials and Initialize-AWSDefaults cmdlets have been updated to use the WriteVerbose api instead of directly writing to the console, allowing their output to be suppressed.

### 3.1.4.0 (2015-08-06)
  * This version contained updates to the underlying AWS SDK for .NET components and was only distributed in the downloadable AWS Tools for Windows msi installer.

### 3.1.3.0 (2015-08-04)
  * DeviceFarm
    - Updated DeviceFarm cmdlets with latest service features, adding support for iOS and retrieving account settings.

### 3.1.2.0 (2015-07-30)
* RDS
    - Add support for Amazon Aurora.
* OpsWorks
    - Add support for ECS clusters.

### 3.1.1.0 (2015-07-28)
* CloudWatch Logs
    - Added cmdlets for 4 new APIs to support cross-account subscriptions. These allow you to collaborate with an owner of a different AWS account and receive their log events on your Amazon Kinesis stream (cross-account data sharing). The new cmdlets are Write-CWLDestination (PutDestination), Write-CWLDestinationPolicy (PutDestinationPolicy), Get-CWLDestination (DescribeDestinations) and Remove-CWLDestination (DeleteDestination).

### 3.1.0.0 (2015-07-28)
* The AWS Tools for Windows PowerShell have been updated to use the new version 3 of the AWS SDK for .NET. The version numbers for AWS SDK for .NET and AWS Tools for Windows PowerShell are kept in sync which is the reason for this major version bump to 3.1. There are otherwise no major changes to AWS Tools for Windows PowerShell.
