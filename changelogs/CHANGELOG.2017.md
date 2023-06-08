### 3.3.210.0 (2017-12-19)
  * Amazon AppStream
    * Added support add tags to Amazon AppStream 2.0 resources with new cmdlets Add-APSResourceTag (TagResource API) and Remove-APSResourceTag (UntagResource API).
  * Amazon S3
    * Extended the Copy-S3Object cmdlet to support copying of objects larger than 5GB within S3. The cmdlet previously used the CopyObject API which is limited to objects up to 5GB in size. With this release the cmdlet inspects the object size and switches automatically to multi-part copy if necessary. The output of the cmdlet when copying objects within S3 has also changed; previously the output of the CopyObject API was emitted. With this update an Amazon.S3.Model.S3Object, referencing the newly copied object, is emitted to the pipeline.
  * Added tab completion support for the new EU (Paris), eu-west-3, region to the -Region parameter for cmdlets.

### 3.3.208.1 (2017-12-13)
  * Amazon EC2
    * Fixed issue with Get-EC2PasswordData cmdlet reporting a null reference when invoked without the -PemFile parameter. This parameter is not required if the keypair data for the instance is saved in the configuration store for the AWS Toolkit for Visual Studio.
  * All cmdlets
    * Added support for the new China (Ningxia) region (cn-northwest-1).

### 3.3.208.0 (2017-12-13)
  * AWS Cost Explorer
    * Added support for the AWS Cost Explorer service. AWS Cost Explorer helps you visualize, understand, and manage your AWS costs and usage over time. The Cost Explorer API gives you programmatic access to the full Cost Explorer dataset, including advanced metrics (e.g., Reserved Instance utilization) and your cost allocation tags. Cmdlets for the service have the noun prefix 'CE' and can be listed with the command *Get-AWSCmdletName -Service CE*.
  * AWS Resource Groups
    * Added support for the AWS Resource Groups service announced at AWS re:Invent 2017. A resource group is a collection of AWS resources that are all in the same AWS region, and that match criteria provided in a query. Queries include lists of resources that are specified in the following format *AWS::service::resource*, and tags. Tags are keys that help identify and sort your resources within your organization; optionally, tags include values for keys. Cmdlets for the service have the noun prefix 'RG' and can be listed with the command *Get-AWSCmdletName -Service RG*.
  * Amazon Kinesis Video Streams
    * Added support for the Amazon Kinesis Video Streams service announced at AWS re:Invent 2017. Amazon Kinesis Video Streams is a fully managed AWS service that you can use to stream live video from devices to the AWS Cloud, or build applications for real-time video processing or batch-oriented video analytics. Cmdlets for the service have the noun prefix 'KV' and can be listed with the command *Get-AWSCmdletName -Service KV*.
  * Amazon Kinesis Video Streams Media
    * Added support for the Amazon Kinesis Video Streams Media service announced at AWS re:Invent 2017. Cmdlets for the service have the noun prefix 'KVM' and can be listed with the command *Get-AWSCmdletName -Service KVM*.
  * AWS IoT Jobs Data Plane
    * Added support for the AWS IoT Jobs Data Plane service announced at AWS re:Invent 2017. Cmdlets for the service have the noun prefix 'IOTJ' and can be listed with the command *Get-AWSCmdletName -Service IOTJ*.
  * AWS AppSync
    * Added support for the AWS AppSync service announced at AWS re:Invent 2017. AWS AppSync is an enterprise level, fully managed GraphQL service with real-time data synchronization and offline programming features. Cmdlets for the service have the noun prefix 'ASYN' and can be listed with the command *Get-AWSCmdletName -Service ASYN*.
  * Alexa for Business
    * Added support for the Alexa for Business service announced at AWS re:Invent 2017. Alexa for Business gives you the tools you need to manage Alexa devices, enroll users, and assign skills. You can build your own voice skills using the Alexa Skills Kit and the Alexa for Business API. You can also make them available as private skills for your organization. Cmdlets for the service have the noun prefix 'ALXB' and can be listed with the command *Get-AWSCmdletName -Service ALXB*.
  * AWS Cloud9
    * Added support for the AWS Cloud9 service announced at AWS re:Invent 2017. AWS Cloud9 is a cloud-based integrated development environment (IDE) that you use to write, run, and debug code. Cmdlets for the service have the noun prefix 'C9' and can be listed with the command *Get-AWSCmdletName -Service C9*.
  * AWS Serverless Application Repository
    * Added support for the AWS Serverless Application Repository. With AWS Serverless Application Repository, you can quickly find and deploy serverless applications in the AWS Cloud. You can browse applications by category, or search for them by name, publisher, or event source. Cmdlets for the service have the noun prefix 'SAR' and can be listed with the command *Get-AWSCmdletName -Service SAR*.
  * Amazon SageMaker Service
    * Added support for Amazon SageMaker Service, announced at AWS re:Invent 2017. Amazon SageMaker is a fully managed machine learning service. With Amazon SageMaker, data scientists and developers can quickly and easily build and train machine learning models, and then directly deploy them into a production-ready hosted environment. Cmdlets for the service have the noun prefix 'SM' and can be listed with the command *Get-AWSCmdletName -Service SM*. Cmdlets for the Amazon SameMaker Runtime service have the noun prefix 'SMR' and can be listed with the command *Get-AWSCmdletName -Service SMR*.

### 3.3.205.0 (2017-12-08)
  * Amazon EC2
    * Updated the New-EC2Instance cmdlet to support the new [T2 Unlimited](http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/t2-unlimited.html#launch-t2) feature.
  * Amazon Cloud Directory
    * Added support for new APIs to enable schema changes across your directories with in-place schema upgrades. Your directories now remain available while backward-compatible schema changes are being applied, such as the addition of new fields. You also can view the history of your schema changes in Cloud Directory by using both major and minor version identifiers, which can help you track and audit schema versions across directories. The new cmdlets are Get-CDIRAppliedSchemaVersion (GetAppliedSchemaVersion API), Update-CDIRAppliedSchema (UpgradeAppliedSchema API) and Update-CDIRPublishedSchema (UpgradePublishedSchema API).
  * AWS Budgets
    * Added support for additional cost types to support finer control for different charges included in a cost budget.
  * Amazon Elasticsearch
    * Updated the New-ESDomain cmdlet to add support for encryption of data at rest on Amazon Elasticsearch Service using AWS KMS.
  * Amazon Simple Email Service
    * Added cmdlets to support new service features for customization of the emails that Amazon SES sends when verifying new identities. This feature is helpful for developers whose applications send email through Amazon SES on behalf of their customers.
  * Amazon MQ
    * Added support for the Amazon MQ service launched at AWS re:Invent 2017. Amazon MQ is a managed message broker service for [Apache ActiveMQ](http://activemq.apache.org/) that makes it easy to set up and operate message brokers in the cloud. Cmdlets for the service have the noun prefix 'MQ' and can be listed with the command *Get-AWSCmdletName -Service MQ*.
  * Amazon GuardDuty
    * Added support for the Amazon GuardDuty service launched at AWS re:Invent 2017. Amazon GuardDuty is a continuous security monitoring service that analyzes and processes VPC Flow Logs, AWS CloudTrail event logs, and DNS logs. It uses threat intelligence feeds, such as lists of malicious IPs and domains, and machine learning to identify unexpected and potentially unauthorized and malicious activity within your AWS environment. Cmdlets for the service have the noun prefix 'GD' and can be listed with the command *Get-AWSCmdletName -Service GD*.
  * Amazon Comprehend
    * Added support for the Amazon Comprehend service launched at AWS re:Invent 2017. Amazon Comprehend uses natural language processing (NLP) to extract insights about the content of documents. Amazon Comprehend processes any text file in UTF-8 format. It develops insights by recognizing the entities, key phrases, language, sentiments, and other common elements in a document. Use Amazon Comprehend to create new products based on understanding the structure of documents. For example, using Amazon Comprehend you can search social networking feeds for mentions of products or scan an entire document repository for key phrases. Cmdlets for the service have the noun prefix 'COMP' and can be listed with the command *Get-AWSCmdletName -Service COMP*.
  * Amazon Translate
    * Added support for Amazon Translate service launched at AWS re:Invent 2017. Amazon Translate translates documents from the following six languages into English, and from English into these languages:
        * Arabic
        * Chinese
        * French
        * German
        * Portuguese
        * Spanish
      Cmdlets for the service have the noun prefix 'TRN' and can be listed with the command *Get-AWSCmdletName -Service TRN*.

### 3.3.201.0 (2017-12-02)
  * Updated cmdlets for multiple services to include new APIs and API updates released during AWS re:Invent 2017, for services already supported by the tools. New services launched at the conference will be added to the tools in the coming days. The updated services are:
    * Auto Scaling
    * Amazon API GatewayGateway
    * Amazon DynamoDB
    * Amazon Cognito
    * Amazon Cognito Identity Provider
    * Amazon EC2
    * Amazon Elastic Container Service
    * Amazon Lightsail
    * Amazon Rekognition
    * Amazon Systems Manager
    * AWS Batch
    * AWS CloudFormation
    * AWS CodeDeploy
    * AWS Greengrass
    * AWS IoT
    * AWS Lambda
    * AWS WAF
    * AWS WAF Regional

### 3.3.197.0 (2017-11-27)
  * AWS Elemental Media Convert
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMC'.
  * AWS Elemental Media Live
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EML'.
  * AWS Elemental Media Package
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMP'.
  * AWS Elemental Media Store
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMS'.
  * AWS Elemental Media Data Plane
    * Added support for the new service. Cmdlets for the service have the noun prefix 'EMSD'.

### 3.3.196.0 (2017-11-25)
  * AWS Certificate Manager
    * Updated the New-ACMCertificate and Get-ACMCertificateList cmdlets for new service features enabling the ability to import domainless certs and additional Key Types as well as an additional validation method for DNS.
  * Amazon API Gateway
    * Updated the Get-AGDocumentationPartList and Write-AGIntegration cmdlets for new service features enabling support for access logs and customizable integration timeouts.
  * AWS CloudFormation
    * Updated the New-CFNStackInstance cmdlet to support instance-level parameter overrides.
    * Added new cmdlet Update-CFNStackInstance to support the new UpdateStackInstances API.
  * AWS CodeBuild
    * Updated the New-CBProject and Update-CBProject cmdlets to support new service features for accessing Amazon VPC resources from AWS CodeBuild, dependency caching and build badges.
    * Added the cmdlet Reset-CBProjectCache to support the new InvalidateProjectCache API.
  * AWS CodeCommit
    * Added new cmdlets for the new service feature supporting pull requests.
  * AWS Database Migration Service
    * Added cmdlet Start-DMSReplicationTaskAssessment to support the new StartReplicationTaskAssessment API.
  * Amazon ECS
    * Updated the New-ECSTask, New-ECSService, Start-ECSTask and Update-ECSService cmdlets to add support for new mode for Task Networking in ECS, called awsvpc mode.
  * Amazon Elastic Map Reduce
    * Updated the Start-EMRJobFlow cmdlet to support new service feature enabling Kerberos.
  * Amazon Kinesis
    * Added cmdlet Get-KINStreamSummary to support the new DescribeStreamSummary API.
  * Amazon Kinesis Firehose
    * Updated the New-KINFDeliveryStream and Update-KINFDestination cmdlets to support Splunk as Kinesis Firehose delivery destination. You can now use Kinesis Firehose to ingest real-time data to Splunk in a serverless, reliable, and salable manner. This release also includes a new feature that allows you to configure Lambda buffer size in Kinesis Firehose data transformation feature. You can now customize the data buffer size before invoking Lambda function in Kinesis Firehose for data transformation. This feature allows you to flexibly trade-off processing and delivery latency with cost and efficiency based on your specific use cases and requirements.
  * Amazon Lightsail
    * Added cmdlets to support the new service feature enabling attached block storage, which allows you to scale your applications and protect application data with additional SSD-backed storage disks. This feature allows Lightsail customers to attach secure storage disks to their Lightsail instances and manage their attached disks, including creating and deleting disks, attaching and detaching disks from instances, and backing up disks via snapshot.
  * AWS Organizations
    * Added cmdlets to support new service APIs to enable and disable integration with AWS services designed to work with AWS Organizations. This integration allows the AWS service to perform operations on your behalf on all of the accounts in your organization. Although you can use these APIs yourself, we recommend that you instead use the commands provided in the other AWS service to enable integration with AWS Organizations.
  * Amazon Relational Database Service
    * Added new cmdlet Restore-RDSDBInstanceFromS3 to support the new RestoreDBInstanceFromS3 API. This feature supports importing MySQL databases by using backup files from Amazon S3.
  * Amazon Rekognition
    * Added new cmdlet Find-REKText to support the new DetectText service API. This API allows you to recognize and extract textual content from images.
    * Updated cmdlets related to face detection to support the new Face Model Versioning feature.
    * [BREAKING CHANGE] The service output for the APIs called by the Get-REKCollectionIdList and Get-REKFaceList cmdlet has been updated and it is no longer possible for these cmdlets to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon Route53
    * Added cmdlets Get-R53AccountLimit (GetAccountLimit API), Get-R53HostedZoneLimit (GetHostedZoneLimit API) and Get-R53ReusableDelegationSetLimit (GetReusableDelegationSetLimit API). These cmdlets enable you to view your current limits (including custom set limits) on Route 53 resources such as hosted zones and health checks. These APIs also return the number of each resource you're currently using to enable comparison against your current limits.
  * AWS Shield
    * Added cmdlet Get-SHLDSubscriptionState to support the new GetSubscriptionState API.
  * Amazon Simple Email Service
    * Added and updated cmdlets to support new service features enabling Reputation Metrics and Email Pausing Today, two features that build upon the capabilities of the reputation dashboard. The first is the ability to export reputation metrics for individual configuration sets. The second is the ability to temporarily pause email sending, either at the configuration set level, or across your entire Amazon SES account.
  * Amazon EC2 Systems Manager
    * Updated the Get-SSMInventory and Get-SSMInventorySchema cmdlets to support aggregation.
  * Amazon Set Functions
    * Added cmdlets Get-SFNStateMachineForExecution (DescribeStateMachineForExecution API) and Update-SFNStateMachine (UpdateStateMachine API). The new APIs enable you to update your state machine definition and role ARN. Existing executions will continue to use the previous definition and role ARN. You can use the DescribeStateMachineForExecution API to determine which state machine definition and role ARN is associated with an execution.
  * AWS Storage Gateway
    * Updated the New-SGNFileShare and Update-SGNFileShare cmdlets to enable guessing of MIME types for uploaded files based on the file extension.
    * Added cmdlet Send-SGUploadedNotification (NotifyWhenUploaded API). This API enables you to get notification when all your files written to your NFS file share have been uploaded.
  * Amazon WorkDocs
    * Added cmdlet Get-WDGroup to support the new DescribeGroups API.
    * Updated cmdlets to support new service features.

### 3.3.189.1 (2017-11-13)
  * Amazon EC2
    * Added cmdlet New-EC2DefaultSubnet (CreateDefaultSubnet API) enabling creation of a default subnet in an Availability Zone if no default subnet exists.
  * Amazon S3
    * Added parameter -RequesterPay to the Get-S3PresignedUrl cmdlet to support 'requester pays' mode when generating a presigned url.
    * Fixed issue with Test-S3Bucket reporting an exception 'x-amz-security-token cannot be used as both a header and a parameter' when invoked from an EC2 instance launched with an instance profile (this bug was introduced into the 3.3.189.0 release of the AWS SDK for .NET and affected v3.3.189.0 of the AWS Tools for Windows PowerShell, released only as part of the combined AWS Tools for Windows installer).

### 3.3.187.0 (2017-11-09)
  * AWS CloudFormation
    * Fixed issue with the Wait-CFNStack cmdlet not exiting when testing for 'DELETE_COMPLETE' status on a deleted stack.
  * Amazon S3
    * Added support for new bucket encryption APIs with three new cmdlets: Get-S3BucketEncryption (GetBucketEnryption API), Set-S3BucketEncryption (PutBucketEncryption API) and Remove-S3BucketEncryption (DeleteBucketEncryption API).
  * AWS Price List Service
    * Added cmdlets to support the new service. AWS Price List Service API is a centralized and convenient way to programmatically query Amazon Web Services for services, products, and pricing information. Cmdlets for the service have the noun prefix 'PLS' and can be listed using the command 'Get-AWSCmdletName -Service PLS'.
  * AWS Cloud HSM V2
    * Added cmdlets to support the Cloud HSM V2 service. Cmdlets for the service have the noun prefix 'HSM2' and can be listed using the command 'Get-AWSCmdletName -Service HSM2'.
  * Amazon API Gateway
    * Added support for new service features to create and manage regional and edge-optimized API endpoints.
  * Amazon EC2
    * [BREAKING CHANGE] The DescribeVpcEndpointServices service API, called by the cmdlet Get-EC2VpcEndpointService, has been extended to include an extra collection of service names. This additional collection is incompatible with automatic pagination therefore this cmdlet has had to be updated to disable automatic pagination of all results.
  * Application Auto Scaling
    * Added support for new service APIs to enable scheduling adjustments to MinCapacity and MaxCapacity, which makes it possible to pre-provision adequate capacity for anticipated demand and then reduce the provisioned capacity as demand lulls. The new cmdlets are Get-AASScheduledAction (DescribeScheduledActions API), Remove-AASScheduledAction (DeleteScheduledAction API) and Set-AASScheduledAction (PutScheduledAction API).
    * Renamed the existing Write-AASScalingPolicy cmdlet has been renamed to a more appropriate verb, Set-AASScalingPolicy. An alias for backwards compatibility is automatically enabled by the module.
  * Amazon ElastiCacheElastiCache
    * Added cmdlet Edit-ECReplicationGroupShardConfiguration to support the new ModifyReplicationGroupShardConfiguration service API.

### 3.3.181.0 (2017-11-01)
  * Amazon EC2 Systems Manager
    * Fixed bug in the Get-SSMParametersByPath cmdlet preventing automatic pagination.

### 3.3.180.0 (2017-10-30)
  * Amazon CloudFront
    * Added cmdlet Remove-CFServiceLinkedRole for the new DeleteServiceLinkedRole API.
  * AWS Migration Hub
    * Added cmdlets to support the AWS Migration Hub service. Cmdlets for the service have the noun prefix 'MH' and can be listed using the command 'Get-AWSCmdletName -Service MH'. For more information on the service please refer to the service user guide [here](http://docs.aws.amazon.com/migrationhub/latest/ug/whatishub.html).
  * Amazon Pinpoint
    * Added cmdlets to support the new service APIs for APNs VoIP messages.

### 3.3.178.0 (2017-10-24)
  * Amazon EC2
    * The Get-EC2SecurityGroup cmdlet has been updated to support automatic pagination of all groups to match the corresponding enhancement in the underlying DescribeSecurityGroups API.
  * Amazon Elasticsearch
    * Added cmdlet Remove-ESElasticsearchServiceRole (DeleteElasticsearchServiceRole API).
  * Amazon EC2 Systems Manager
    * Updated the Write-SSMParameter cmdlet to return the version of the parameter. Previously the cmdlet, and the underlying service PutParameter API, generated no output.
  * Amazon SQS
    * Added new cmdlets to support tracking cost allocation by adding, updating, removing, and listing the metadata tags of Amazon SQS queues. The new cmdlets are Add-SQSResourceTag (TagQueue API), Get-SQSResourceTag (ListQueueTags API) and Remove-SQSResourceTag (UntagQueue API).

### 3.3.173.0 (2017-10-16)
  * AWS Elastic Beanstalk
    * Added support for tagging environments, including two additional cmdlets Get-EBResourceTag (ListResourceTags API) and Update-EBResourceTag (UpdateResourceTags API).
  * AWS CodeCommit
    * Added support for the new DeleteBranch API with cmdlet Remove-CCBranch.
  * Amazon EC2 Container Registry
    * Added cmdlets to support new APIs for repository lifecycle policies. Lifecycle policies enable you to specify the lifecycle management of images in a repository. The configuration is a set of one or more rules, where each rule defines an action for Amazon ECR to apply to an image. This allows the automation of cleaning up unused images, for example expiring images based on age or status. A lifecycle policy preview API is provided as well, which allows you to see the impact of a lifecycle policy on an image repository before you execute it.
  * Elastic Load Balancing v2
    * Added cmdlets to support Server Name Indication (SNI). Server Name Indication (SNI) is an extension to the TLS protocol by which a client indicates the hostname to connect to at the start of the TLS handshake. The load balancer can present multiple certificates through the same secure listener, which enables it to support multiple secure websites using a single secure listener. Application Load Balancers also support a smart certificate selection algorithm with SNI. If the hostname indicated by a client matches multiple certificates, the load balancer determines the best certificate to use based on multiple factors including the capabilities of the client. The new cmdlets are Add-ELB2ListenerCertificate (AddListenerCertificates API), Get-ELB2ListenerCertificate (DescribeListenerCertificates API) and Remove-ELB2ListenerCertificate (RemoveListenerCertificates API).
  * AWS OpsWorks CM
    * [BREAKING CHANGE] The service response data from the DescribeNodeAssociationStatus API (Get-OWCMNodeAssociationStatus cmdlet) has been updated to include additional fields. This cmdlet therefore now emits the service response object to the pipeline.
  * Amazon Relational Database Service
    * Added new cmdlet Get-RDSValidDBInstanceModification (DescribeValidDBInstanceModifications API) enabling you to query what modifications can be made to your DB instance.
  * Amazon Simple Email Service
    * Added cmdlets to support new service APIs related to email template management and templated email sending operations.
  * Amazon EC2
    * Added new cmdlet Edit-EC2VpcTenancy (ModifyVpcTenancy API) enabling you to change the tenancy of your VPC from dedicated to default with a single API operation. For more details refer to the documentation for changing VPC tenancy.
  * AWS WAF
    * Added cmdlets to support regular expressions as match conditions in rules, and support for geographical location by country of request IP address as a match condition in rules.
  * AWS WAF Regional
    * Added cmdlets to support regular expressions as match conditions in rules, and support for geographical location by country of request IP address as a match condition in rules.

### 3.3.169.0 (2017-10-09)
  * AWS Lambda
    * Revised parameter sets and mandatory parameters for the Update-LMFunctionCode and Publish-LMFunction cmdlets based on user feedback. Also made the options for how the function code can be supplied the same.
  * Amazon AppStream
    * Added cmdlets to support new service APIs for APIs for managing and accessing image builders, and deleting images. The new cmdlets are: Get-APSImageBuilderList (DescribeImageBuilders API), New-APSImageBuilder (CreateImageBuilder API), New-APSImageBuilderStreamingURL (CreateImageBuilderStreamingURL API), Start-APSImageBuilder (StartImageBuilder API), Stop-APSImageBuilder (StopImageBuilder API), Remove-APSImage (DeleteImage API) and Remove-APSImageBuilder (DeleteImageBuilder API).
  * AWS CodeBuild
    * Added cmdlets New-CBWebHook (CreateWebHook API) and Remove-CBWebHook (DeleteWebHook API) to support the new service update for building GitHub pull requests.
  * Amazon Kinesis Analytics
    * Added support for schema discovery on objects in S3 and the ability to support configure input data preprocessing through Lambda with new cmdletsAdd-KINAApplicationInputProcessingConfiguration (AddApplicationInputProcessingConfiguration API) and Remove-KINAApplicationInputProcessingConfiguration (DeleteApplicationInputProcessingConfiguration API).
  * Amazon Route 53 Domains
    * Added cmdlet Test-R53DDomainTransferability to support the new CheckDomainTransferability API.

### 3.3.164.0 (2017-09-29)
  * Amazon EC2 Container Registry
    * Implemented a new helper cmdlet, Get-ECRLoginCommand, to return the login command to the pipeline for your default or specified registry or registries. This command is similar to the AWS CLI's 'ecr get-login' command.
  * AWS CloudFormation
    * Added cmdlet Update-CFNTerminationProtection to support the new UpdateTerminationProtection API enabling you to prevent a stack from being accidentally deleted. If you attempt to delete a stack with termination protection enabled, the deletion fails and the stack, including its status, remains unchanged. You can also enable termination protection on a stack when you create it using the new -EnableTerminationProtection parameter on the New-CFNStack cmdlet. Termination protection on stacks is disabled by default. After creation, you can set termination protection on a stack whose status is CREATE_COMPLETE, UPDATE_COMPLETE, or UPDATE_ROLLBACK_COMPLETE.
  * Amazon EC2
    * Added argument completion support for the Attribute parameter of the Edit-EC2ImageAttribute cmdlet, enabling tab completion of the possible attribute names. The service models this parameter as a simple string type, rather than a service enumeration, so tab completion was not available by default.
  * Amazon S3
    * Updated the Copy-S3Object cmdlet to support copying (downloading) multiple objects, identified by common key prefix, to a folder on the local file system. Previously the cmdlet could only process single object download to a file or folder. You may therefore use either Read-S3Object or Copy-S3Object to download one or multiple files from S3 to the local system (the functionality is the same). To copy files within S3, use the Copy-S3Object cmdlet.
  * Amazon Pinpoint
    * Added new cmdlets to support new APIs for new push notification channels: Amazon Device Messaging (ADM) and, for push notification support in China, Baidu Cloud Push.
    * Added new cmdlet for direct message deliveries to user IDs, enabling you to message an individual user on multiple endpoints.

### 3.3.161.0 (2017-09-22)
  * AWS CodePipeline
    * [BREAKING CHANGE]
      The output of the Get-CPPipeline cmdlet has changed as a result of a service update to the underlying GetPipeline API. The api response data now includes pipeline metadata info in addition to the pipeline declaration data (which was the previous output). To access the original data, use the '.Pipeline' member of the output object. To access the new metadata use the the '.Metadata' member of the output object.
  * AWS Greengrass
    * Added new cmdlet Reset-GGDeployment to support the new ResetDeployments API.
  * AWS CloudWatchLogs
    * Added support for associating LogGroups with KMS Keys with new cmdlets Register-CWLKmsKey (AssociateKmsKey API) and Unregister-CWLKmsKey (DisassociateKmsKey API).
  * Amazon EC2
    * Added support for new operations on Amazon FPGA Images (AFIs), within the same region and across multiple regions, with new cmdlets Get-EC2FpgaImageAttribute (DescribeFpgaImageAttribute API), Edit-EC2FpgaImageAttribute (ModifyFpgaImageAttribute API), Reset-EC2FpgaImageAttribute (ResetFpgaImageAttribute API),  Remove-EC2FpgaImage (DeleteFpgaImage API) and Copy-EC2FpgaImage (CopyFpgaImage API). AFI attributes include name, description and granting/denying other AWS accounts to load the AFI.
  * AWS Identity and Access Management
    * Added support for new APIs to submit a service-linked role deletion request and querying the status of the deletion with new cmdlets Remove-IAMServiceLinkedRole (DeleteServiceLinkedRole API) and Get-IAMServiceLinkedRoleDeletionStatus (GetServiceLinkedRoleDeletionStatus API).
  * Amazon Simple Email Service
    * Added support for new APIs enabling domain customization for tracking open and click events with new cmdlets New-SESConfigurationSetTrackingOption (CreateConfigurationSetTrackingOptions API), Update-SESConfigurationSetTrackingOption (UpdateConfigurationSetTrackingOptions API) and Remove-SESConfigurationSetTrackingOption (DeleteConfigurationSetTrackingOptions API).

### 3.3.158.0 (2017-09-17)
  * AWS Service Catalog
    - Added cmdlets to support the new CopyProduct and DescribeCopyProductStatus apis.

### 3.3.152.0 (2017-09-09)
  * Amazon CloudWatch Logs
    - Added cmdlets for managing resource polices
  * Amazon EC2
    - Added new cmdlets Update-EC2SecurityGroupRuleIngressDescription and Update-EC2SecurityGroupRuleEgressDescription
  * Amazon Lex Model Building Service
	- Added new cmdlet Get-LMBExport
  * Amazon Route53
    - Added new cmdlets to manage query logging config.

### 3.3.150.0 (2017-09-07)
  * AWS CodeBuild
    - Added new cmdlet RemoveCBBuildBatch
  * AWS CodeStar
    - Added new cmdlets Add-CSTTagsForProject, Remove-CSTTagsForProject and Get-CSTTagsForProject
  * Amazon GameLift
    - Added new cmdlets for setting up EC2 VPC peering.

### 3.3.143.0 (2017-08-24)
  * Amazon Simple Systems Management
    - Added new cmdlet, Get-SSMAssociationVersionList (ListAssociationVersions API), to returns versioned associations.
  * Amazon Kinesis Firehose
    - Added new cmdlet, Get-KINFKinesisStream (GetKinesisStream API).

### 3.3.140.0 (2017-08-16)
  * All services
    - Improved error messaging for 'name resolution failure' errors. The cmdlets now detail the endpoint they attempted to access and list some possible causes (for example, use of an availability zone instead of a region code).
  * Amazon Simple Systems Management
    - Added and updated cmdlets to support new service features. Maintenance Windows include the following changes or enhancements: New task options using Systems Manager Automation, AWS Lambda, and AWS Step Functions; enhanced ability to edit the targets of a Maintenance Window, including specifying a target name and description, and ability to edit the owner field; enhanced ability to edits tasks; enhanced support for Run Command parameters; and you can now use a --safe flag when attempting to deregister a target. If this flag is enabled when you attempt to deregister a target, the system returns an error if the target is referenced by any task. Also, Systems Manager now includes Configuration Compliance to scan your fleet of managed instances for patch compliance and configuration inconsistencies. You can collect and aggregate data from multiple AWS accounts and Regions, and then drill down into specific resources that aren't compliant.
  * AWS Elastic File System
    - Extended the New-EFSFileSystem cmdlet to support encrypted EFS file systems and specifying a KMS master key to encrypt it with.
  * AWS Storage Gateway
    - Extended the Remove-SGFileShare with new parameter -ForceDelete. If set, the file share is immediately deleted and all data uploads aborted immediately otherwise the share is not deleted until all uploads complete.
  * AWS CodeDeploy
    - Updated the New-CDDeploymentGroup and Update-CDDeploymentGroup cmdlets with parameters to support specifying Application Load Balancers in deployment groups, for both in-place and blue/green deployments.
  * Amazon Cognito Identity Provider
    - Updated and added cmdlets to support new features for Amazon Cognito User Pools that enable application developers to easily add and customize a sign-up and sign-in user experience, use OAuth 2.0, and integrate with Facebook, Google, Login with Amazon, and SAML-based identity providers.
  * Amazon EC2
    - Updated the New-EC2Address cmdlet with a new parameter, -Address, to support the new service feature enabling recovery of an elastic IP address (EIP) that was released.
  * AWS Elastic Beanstalk
    - Updated the Get-EBEnvironment cmdlet to support automatic pagination now that the underlying service API, DescribeEnvironments, can paginate output.
  * Amazon Route 53
    - Applied parameter alias "Id" to all cmdlets that accept a -HostedZoneId parameter to make pipeline scenarios more convenient, for example Get-R53HostedZoneList | Get-R53ResourceRecordSet. The change avoids the need for an intermediate 'Select-Object -ExpandProperty Id' clause in the pipeline to extract the zone ID from the output of Get-R53ResourceRecordSet to pass to Get-R53ResourceRecordSet.
  * Amazon S3
    - Extended the Write-S3Object cmdlet to accept tags for all operating modes. Previously tags could only be specified for single file or object uploads, now they can also be specified when uploading multiple objects from a folder hierarchy. The specified tags will be applied to all uploaded objects.
  * Amazon GameLift
    - New and updated cmdlets to support the Matchmaking Grouping Service, a new feature that groups player match requests for a given game together into game sessions based on developer configured rules.

### 3.3.133.0 (2017-08-04)
  * AWS CodeDeploy
    - Updated the New-CDDeployment, New-CDDeploymentGroup and Update-CDDeploymentGroup with parameters to support the use of multiple tag groups in a single deployment group (an intersection of tags) to identify the instances for a deployment. When you create or update a deployment group, use the new -Ec2TagSetList and -OnPremisesTagSetList parameters to specify up to three groups of tags. Only instances that are identified by at least one tag in each of the tag groups are included in the deployment group.
    - Revised some parameter names in the New-CDDeployment, New-CDDeploymentGroup and Update-CDDeploymentGroup to improve usability. Backwards compatible aliases were also applied to the affected parameters.
  * Amazon Pinpoint
    - Added support for the new app management APIs with new cmdlets Get-PINApp (GetApp API), Get-PINAppList (GetApps API), New-PINApp (CreateApp API) and Remove-PINApp (DeleteApp API).
  * AWS Config Service
    - Added new cmdlet, Get-CFGDiscoveredResourceCount (GetDiscoveredResourceCounts API), to returns the resource types and the number of each resource type in your AWS account.
  * Amazon Simple Systems Management
    - Added new cmdlet, Send-SSMAutomationSignal (SendAutomationSignal API). This API is used to send a signal to an automation execution to change the current behavior or status of the execution.

### 3.3.130.0 (2017-07-28)
  * Fixed issue using Kerberos authentication when obtaining SAML federated credentials. The authentication process failed for some users with a '401 unauthorized' exception.
  * Added new output format templates for the LogGroup and LogStream types for Amazon CloudWatch Logs.
  * AWS Directory Service
    - You can now improve the resilience and performance of your Microsoft AD directory by deploying additional domain controllers with the new Set-DSDomainControllerCount cmdlet (UpdateNumberofDomainControllers API). This cmdlet enables you to update the number of domain controllers you want for your directory. The new Get-DSDomainControllerList cmdlet (DescribeDomainControllers API) enables you to describe the detailed information of each domain controller of your directory. The output of the Get-Directory cmdlet was also extended to contain a new field,  'DesiredNumberOfDomainControllers'.
  * Amazon Kinesis
    - You can now encrypt your data at rest within an Amazon Kinesis Stream using server-side encryption using new cmdlets Start-KINStreamEncryption (StartStreamEncryption API) and Stop-KINStreamEncryption (StopStreamEncryption API). Server-side encryption via AWS KMS makes it easy for customers to meet strict data management requirements by encrypting their data at rest within the Amazon Kinesis Streams, a fully managed real-time data processing service.
  * Amazon EC2 Simple Systems Management
    - Added parameters to support patching for Amazon Linux, Red Hat and Ubuntu systems.
  * Amazon API Gateway
    - Added new cmdlets Get-AGGatewayResponse (GetGatewayResponse API), Get-AG-GatewayResponseList (GetGatewayResponses API), Update-AGGatewayResponse(UpdateGatewayResponse API), Remove-AGGatewayResponse (DeleteGatewayResponse API) and Write-AGGatewayResponse (PutGatewayResponse API) to support management of gateway responses.
  * AWS AppStream
    - Amazon AppStream 2.0 image builders and fleets can now access applications and network resources that rely on Microsoft Active Directory (AD) for authentication and permissions. This new feature allows you to join your streaming instances to your AD, so you can use your existing AD user management tools. New cmdlets to support this feature are Get-APSDirectoryConfigList (DescribeDirectoryConfigs API), New-APSDirectoryConfig (CreateDirectoryConfig API), Remove-APSDirectoryConfig (DeleteDirectoryConfig API) and Update-APSDirectoryConfig (UpdateDirectoryConfig API). New-APSFleet was updated with new parameters to support specifying domain information.
  * Application Discovery Service
    - Updated the Get-ADSExportTask and Start-ADSExportTask cmdlets to support filters, allow export based on per agent id.
  * Auto Scaling
    - Updated the Write-ASScalingPolicy to support a new type of scaling policy called target tracking scaling policies that you can use to set up dynamic scaling for your application.
  * Amazon Cognito Identity Provider
    - Updated the New-CGIPUserPool cmdlet to support configuration of user pools for email/phone based signup and sign-in.
  * Amazon EC2
    - X-ENI (or Cross-Account ENI) is a new feature that allows the attachment or association of Elastic Network Interfaces (ENI) between VPCs in different AWS accounts located in the same availability zone. With this new capability, service providers and partners can deliver managed solutions in a variety of new architectural patterns where the provider and consumer of the service are in different AWS accounts. To support this new feature the cmdlets Get-EC2NetworkInterfacePermission (DescribeNetworkInterfacePermissions API), New-EC2NetworkInterfacePermission (CreateNetworkInterfacePermission API) and Remove-EC2NetworkInterfacePermission (DeleteNetworkInterfacePermission) were added.
    - Added cmdlet Get-EC2ElasticGpu (DescribeElasticGpus API). Amazon EC2 Elastic GPUs allow you to easily attach low-cost graphics acceleration to current generation EC2 instances. With Amazon EC2 Elastic GPUs, you can configure the right amount of graphics acceleration to your particular workload without being constrained by fixed hardware configurations and limited GPU selection.
    - Added cmdlet New-EC2DefaultVpc (CreateDefaultVpc API). You no longer need to contact AWS support, if your default VPC has been deleted.
  * Amazon Elastic MapReduce
    - Added support for the ability to use a custom Amazon Linux AMI and adjustable root volume size when launching a cluster.
  * Amazon Lambda
    - Updated the Get-LMFunctionList cmdlet to support the latest Lambda@Edge enhancements.
  * AWS CloudFormation
    - Added and updated cmdlets to support StackSets, enabling users to manage stacks across multiple accounts and regions.

### 3.3.119.0 (2017-07-07)
  * AWS CloudFormation
    - Added new helper cmdlets Test-CFNStack, which tests a CloudFormation stack to determine if it's in a certain status and Wait-CFNStack which Pauses execution of the script until the desired CloudFormation Stack status has been reached or timeout occurs.
  * Added new format definitions for several types to improve output usability. The new formats take effect on objects of type:
    - Amazon.AutoScaling.Model.AutoScalingGroup
    - Amazon.AutoScaling.Model.LaunchConfiguration
    - Amazon.CloudFormation.Model.Stack
    - Amazon.CloudFormation.Model.StackEvent
    - Amazon.CloudWatch.Model.MetricAlarm
    - Amazon.CloudWatchEvents.Model.Rule
    - Amazon.EC2.Model.Instance
    - Amazon.IdentityManagement.Model.Role
    - Amazon.Lambda.Model.FunctionConfiguration
    - Amazon.SimpleSystemsManagement.Model.AssociationDescription
    - Amazon.WorkSpaces.Model.Workspace
  * AWS Service Catalog
    - Added support for the new TagOption library with new cmdlets Add-SCTagOptionToResource (AssociateTagOptionWithResource API), Get-SCTagOptionList (ListTagOptions API), Get-SCResourcesForTagOption (ListResourcesForTagOption API), Get-SCTagOption (DescribeTagOption API), New-SCTagOption (CreateTagOption API), Remove-SCTagOptionFromResource (DisassociateTagOptionFromResource API) and Update-SCTagOption (UpdateTagOption API).
  * Amazon Simple Systems Management
    - Added cmdlets for Resource Data Sync support with SSM Inventory. The new cmdlets are New-SSMResourceDataSync (CreateResourceDataSync API)- creates a new resource data sync configuration, Get-SSMResourceDataSync (ListResourceDataSync API) - lists existing resource data sync configurations, and Remove-SSMResourceDataSync (DeleteResourceDataSync API) - deletes an existing resource data sync configuration.
  * Amazon DynamoDB Accelerator (DAX)
    - Added cmdlet support for the new Amazon DynamoDB Accelerator (DAX) service. DAX is a managed caching service engineered for Amazon DynamoDB. DAX dramatically speeds up database reads by caching frequently-accessed data from DynamoDB, so applications can access that data with sub-millisecond latency. You can create a DAX cluster easily, using the AWS Management Console. With a few simple modifications to your code, your application can begin taking advantage of the DAX cluster and realize significant improvements in read performance. Cmdlets for the new service have the noun prefix 'DAX' and can be listed with the command 'Get-AWSCmdletName -Service DAX'.
  * Amazon CloudWatch Events
    - CloudWatch Events now allows different AWS accounts to share events with each other through a new resource called event bus. Event buses accept events from AWS services, other AWS accounts and Write-CWEEvent (PutEvents API) calls. Currently all AWS accounts have one default event bus. To send events to another account, customers simply write rules to match the events of interest and attach an event bus in the receiving account as the target to the rule. The new cmdlets are Get-CWEEventBus (DescribeEventBus API), Write-CWEPermission (PutPermission API) and Remove-CWEPermission (RemovePermission).
  * Amazon S3
    - Added new parameter -TagSet to the Write-S3Object and Copy-S3Object cmdlets to support specifying tags when uploading individual files to a bucket or copying objects within S3.
    - Updated cmdlets to switch to using path style addressing if the -EndpointUrl parameter is used. The default behavior without the parameter is to prefer virtual host style addressing unless the bucket name is not DNS compatible.
  * AWS Greengrass
    - Added cmdlet support for the new AWS Greengrass service. AWS Greengrass seamlessly extends AWS onto physical devices so they can act locally on the data they generate, while still using the cloud for management, analytics, and durable storage. AWS Greengrass ensures your devices can respond quickly to local events and operate with intermittent connectivity. AWS Greengrass minimizes the cost of transmitting data to the cloud by allowing you to author AWS Lambda functions that execute locally. Cmdlets for the service have the noun prefix 'GG' and can be listed with the command 'Get-AWSCmdletName -Service GG'.
  * AWS CloudWatch
    - Added cmdlets to support the new functionality for dynamically building and maintaining dashboards to monitor your infrastructure and applications. The new cmdlets are Get-CWDashboard (GetDashboard API), Get-CWDashboardList (ListDashboards API), Remove-CWDashboard (DeleteDashboard API) and Write-CWDashboard (PutDashboard API).

### 3.3.113.0 (2017-06-23)
  * Amazon Simple Systems Management
    - Added cmdlets Get-SSMParameter (GetParameter API), Get-SSMParametersByPath (GetParametersByPath API), Remove-SSMParameterCollection (DeleteParameters API).
    - Updated Get-SSMParameterList with a new parameter, -ParameterFilter, to support filtering of the results.
    - Updated Write-SSMParameter with a new parameter, -AllowedPattern, to support enforcement of the parameter value by applying a regex.
  * AWS WAF
    - Added new cmdlets to support creation, editing, updating, and deleting a new type of WAF rule with a rate tracking component. The new cmdlets are Get-WAFRateBasedRule (GetRateBasedRule API), Get-WAFRateBasedRuleList (ListRateBasedRules API), Get-WAFRateBasedRuleManagedKey (GetRateBasedRuleManagedKeys API), New-WAFRateBasedRule (CreateRateBasedRule API), Remove-WAFRateBasedRule (DeleteRateBasedRule API) and Update-WAFRateBasedRule (UpdateRateBasedRule API).
  * AWS WAF Regional
    - Added new cmdlets to support creation, editing, updating, and deleting a new type of WAF rule with a rate tracking component. The new cmdlets are Get-WAFRRateBasedRule (GetRateBasedRule API), Get-WAFRRateBasedRuleList (ListRateBasedRules API), Get-WAFRRateBasedRuleManagedKey (GetRateBasedRuleManagedKeys API), New-WAFRRateBasedRule (CreateRateBasedRule API), Remove-WAFRRateBasedRule (DeleteRateBasedRule API) and Update-WAFRRateBasedRule (UpdateRateBasedRule API).
  * Amazon WorkDocs
    - Added cmdlets Get-WDActivity (DescribeActivities API), Get-WDCurrentUser (GetCurrentUser API) and Get-WDRootFolder (DescribeRootFolders API) to retrieve the activities performed by WorkDocs users.
  * AWS CodePipeline
    - Added cmdlet Get-CDPipelineExecutionSummary to support the new ListPipelineExecutions API. This cmdlet enables you to retrieve summary information about the most recent executions in a pipeline, including pipeline execution ID, status, start time, and last updated time. You can request information for a maximum of 100 executions. Pipeline execution data is available for the most recent 12 months of activity.
    - Enabled automatic pagination of results for the Get-CPActionType and Get-CDPipelineList cmdlets.
  * Amazon Lightsail
    - The Get-LSOperationListForResource cmdlet now supports automatic pagination.
  * AWS Data Migration Service
    - Extended the Import-DSMCertificate cmdlet to support tagging.

### 3.3.109.0 (2017-06-19)
  * Amazon EC2
    - Added cmdlet Get-EC2FpgaImage to support the new DescribeFpgaImages API. This API enables customers to describe Amazon FPGA Images (AFIs) available to them, which includes public AFIs, private AFIs that you own, and AFIs owned by other AWS accounts for which you have load permissions.
  * Application AutoScaling
    - Updated the Write-AASScalingPolicy cmdlet to support automatic scaling of read and write throughput capacity for DynamoDB tables and global secondary indexes.
  * AWS IoT
    - [Breaking change] Updated the Get-IOTCertificate cmdlet to remove the parameter -CertificatePem, previously added in v3.3.104.0.
  * Amazon Relational Database Service
    - Updated the Copy-RDSDBSnapshot and Restore-RDSDBClusterToPointInTime cmdlets to support copy-on-write, a new Aurora MySQL Compatible Edition feature that allows users to restore their database, and support copy of TDE enabled snapshot cross region.
  * AWS Service Catalog
    - Added cmdlet Get-SCProvisionedProductDetail to support the new DescribeProvisionedProduct API.
    - Added parameter -ReturnCloudFormationTemplate to the Get-SCProvisioningArtifact cmdlet. This parameter maps to the 'Verbose' request property in the underlying DescribeProvisioningArtifact API call.

### 3.3.104.0 (2017-06-09)
  * Amazon S3
    - Fixed issue with the Remove-S3Object cmdlet not correctly binding version data when a collection of Amazon.S3.Model.S3ObjectVersion instances are piped to the -InputObject parameter. The examples for this cmdlet have been updated to illustrate usage scenarios deleting single and multiple objects.
  * AWS OpsWorks
    - Added support for resource tagging with new cmdlets Add-OPSResourceTag (TagResource API), Get-OPSResourceTag (ListTags API) and Remove-OPSResourceTag (UntagResource API).
  * AWS IoT
    - Updated the Get-IOTCertificate cmdlet with a new parameter -CertificatePem to support retrieving the description of a certificate with the certificate's PEM.
  * Amazon Pinpoint
    - Added cmdlets to support SMS Text and Email Messaging in addition to Mobile Push Notifications.
  * AWS Rekognition
    - Added cmdlets Get-REKCelebrityInfo (GetCelebrityInfo API) and Find-REKCelebrity (RecognizeCelebrities API).

### 3.3.99.0 (2017-06-05)
  * All services
    - Resolved issue causing the backwards-compatible aliases introduced recently to not be available on PowerShell v3 or v4 systems.
  * Amazon Kinesis Analytics
    - Added support for publishing error messages concerning application misconfigurations to to AWS CloudWatch Logs with new cmdlets Add-KINAApplicationCloudWatchLoggingOption (AddApplicationCloudWatchLoggingOption API) and Remove-KINAApplicationCloudWatchLoggingOption (DeleteApplicationCloudWatchLoggingOption API).
  * Amazon WorkDocs
    - Added support for managing tags and custom metadata on resources with new cmdlets New-WDCustomMetadata (CreateCustomMetadata API), New-WDLabel (CreateLabels API), Remove-WDCustomMetadata (DeleteCustomMetadata API) and Remove-WDLabel (DeleteLabels API).
    - Added new cmdlets to support adding and retrieving comments at the document level: Get-WDComment (DescribeComments API), New-WDComment (CreateComment API) and Remove-WDComment (DeleteComment API)

### 3.3.98.0 (2017-06-02)
  * Amazon Relational Database Service
    - Customers can now easily and quickly stop and start their DB instances using two new cmdlets, Start-RDSDBInstance (StartDBInstance API) and Stop-RDSDBInstance (StopDBInstance API).
  * AWS CodeDeploy
    - Added new cmdlet Get-CDGitHubAccountTokenNameList (ListGitHubAccountTokenNames API) to support improved GitHub account and repository connection management. You can now create and store up to 25 connections to GitHub accounts in order to associate AWS CodeDeploy applications with GitHub repositories. Each connection can support multiple repositories. You can create connections to up to 25 different GitHub accounts, or create more than one connection to a single account.
  * Amazon Cognito Identity Provider
    - Added cmdlets to support integration of external identity providers. The new cmdlets are Get-CGIPIdentityProvider (DescribeIdentityProvider API), Get-CGIPIdentityProviderByIdentifier (GetIdentityProviderByIdentifier API), Get-CGIPIdentityProviderList (ListIdentityProviders API), Get-CGIPUserPoolDomain (DescribeUserPoolDomain API), New-CGIPUserPoolDomain (CreateUserPoolDomain API), Remove-CGIPIdentityProvider (DeleteIdentityProvider API), Remove-CGIPUserPoolDomain (DeleteUserPoolDomain API) and Update-CGIPIdentityProvider (UpdateIdentityProvider API).

### 3.3.96.0 (2017-05-31)
  * All services
    - Cmdlet names for all services have been reviewed and those with plural nouns corrected to be singular to follow best practices. For more details see the blog post 'Updates to AWSPowerShell Cmdlet Names' on the AWS .NET Developer Blog https://aws.amazon.com/blogs/developer/category/net/. A new submodule, loaded automatically, contains backwards-compatible aliases to ensure current scripts will continue to work with the older cmdlet names.
  * Amazon Cloud Directory
    - Added support for Typed Links, enabling customers to create object-to-object relationships that are not hierarchical in nature. Typed Links enable customers to quickly query for data along these relationships. Customers can also enforce referential integrity using Typed Links, ensuring data in use is not inadvertently deleted.

### 3.3.95.0 (2017-05-26)
  * AWS AppStream
    - Updated the New-APSStack cmdlet with new parameter -StorageConnector, and the Update-APSStack with new parameters -StorageConnector and -DeleteStorageConnector, to add support for persistent user storage, backed by S3.
  * AWS Data Migration Service
    - Updated cmdlets to add support for using Amazon S3 and Amazon DynamoDB as targets for database migration, and using MongoDB as a source for database migration.
    - Added cmdlets to support event subscriptions: Edit-DMSEventSubscription (ModifyEventSubscription API), Get-DMSEvent (DescribeEvents API), Get-DMSEventCategory (DescribeEventCategories API), Get-DMSEventSubscription (DescribeEventSubscriptions API), New-DMSEventSubscription (CreateEventSubscription API), Remove-DMSEventSubscription (DeleteEventSubscription API).
    - Added cmdlet Restore-DMSTable to support the new ReloadTables API.

### 3.3.90.0 (2017-05-19)
  * AWSPowerShell.NetCore module
    - Added CompatiblePSEditions entry to the module manifest to mark the module as only being compatible with PowerShell Core environments.
  * Amazon Inspector
    - Added cmdlet Get-INSAssessmentReport to support the new GetAssessmentReport API. This new API adds the ability to produce an assessment report that includes detailed and comprehensive results of a specified assessment run.
  * Amazon Lightsail
    - Added cmdlet Set-LSInstancePublicPort to support the new PutInstancePublicPorts API, enabling a single request to both open and close public ports on an instance.
  * Amazon Athena
    - Added support for the new Amazon Athena service. Amazon Athena is an interactive query service that makes it easy to analyze data in Amazon S3 using standard SQL. Athena is serverless, so there is no infrastructure to manage, and you pay only for the queries that you run. Cmdlets for this service have the noun prefix 'ATH' and can be listed using the command 'Get-AWSCmdletName -Service ATH'.

### 3.3.86.0 (2017-05-12)
  * AWS Lambda
    - Added support for automatic pagination of all available results on service APIs that supported paging. Updated cmdlets are Get-LMAliasList, Get-LMEventSourceMappings, Get-LMFunctions and Get-LMVersionsByFunction.
  * Elastic Load Balancing
    - Added a new cmdlet, Get-ELBAccountLimit (DescribeAccountLimits API), enabling customers to describe their account limits, such as load balancer limit, target group limit etc.
  * Elastic Load Balancing v2
    - Added a new cmdlet, Get-ELB2AccountLimit (DescribeAccountLimits API), enabling customers to describe their account limits, such as load balancer limit, target group limit etc.
  * Amazon Lex Model Builder Service
    - Added support for new APIs with three new cmdlets: Remove-LMBBotVersion (DeleteBotVersion API), Remove-LMBIntentVersion (DeleteIntentVersion API) and Remove-LMBSlitTypeVersion (DeleteSlotTypeVersion API).
    - *Breaking Change*:  The -Version parameter has been removed from the Remove-LMBBot, Remove-LMBIntent and Remove-LMBSlotType cmdlets in favor of the specific cmdlets to delete versions.
  * Amazon Cognito Identity Provider
    - Added support for the new group support APIs with new cmdlets Add-CGIPUserToGroupAdmin (AdminAddUserToGroup API), Get-CGIPGroup (GetGroup API), Get-CGIPGroupList (ListGroups API), Get-CGIPGroupsForuserAdmin (AdminListGroupsForUser API), Get-CGIPUsersInGroup (ListUsersInGroup API), New-CGIPGroup (CreateGroup API), Remove-CGIPGroup (DeleteGroup API), Remove-CGIPuserFromGroup (AdminRemoveUserFromGroup API) and Update-CGIPGroup (UpdateGroup API).

### 3.3.84.0 (2017-05-05)
  * AWS Marketplace Entitlement Service
    - Added support for the new Marketplace Entitlement Service. The cmdlet noun prefix for this service is 'MES' and the cmdlets can be listed using the command 'Get-AWSCmdletName -Service MES'. Currently the service exposes one cmdlet, Get-MESEntitlement (GetEntitlements API).

### 3.3.83.0 (2017-05-01)
  * Amazon Kinesis Firehose
    - Fixed bug in handling of the -Text and -FilePath parameters that could cause a null reference exception.
  * AWS AppStream
    - Updated cmdlets to support the new 'Default Internet Access' service feature. This feature enables Internet access from AppStream 2.0 instances - image builders and fleet instances. Admins can enable this feature when creating an image builder or while creating/updating a fleet with the new -EnableDefaultInternetAccess parameter on the New-APSFleet and Update-APSFleet cmdlets.
  * Amazon Relational Database Service
    - Added the parameter -EnableIAMDatabaseAuthentication to the New-RDSDBCluster, Edit-RDSDBCluster, New-RDSDBInstance, Edit-RDSDBInstance, New-RDSDBInstanceReadReplica, Restore-RDSDBClusterFromS3, Restore-RDSDBClusterFromSnapshot, Restore-RDSDBClusterToPointInTime, Restore-RDSDBInstanceFromDBSnapshot and Restore-RDSDBInstanceToPointInTime cmdlets to enable authentication to your MySQL or Amazon Aurora DB instance using IAM authentication.
  * AWS CloudFormation
    - Added a new parameter, -ClientRequestToken, to the New-CFNStack, Remove-CFNStack, Resume-CFNUpdateRollback, Start-CFNChangeSet, Stop-CFNUpdateStack and Update-CFNStack cmdlets to enable supplying a customer-provided idempotency token to allow safely retrying operations.
  * AWS Import/Export Snowball
    - Added new parameter -ForwardingAddressId to the New-SNOWCluster, Update-SNOWCluster, New-SNOWJob and Update-SNOWJob cmdlets. The New-SNOWAddress cmdlet was updated with a new parameter -Address_IsRestricted to enable you to mark the primary address.

### 3.3.81.0 (2017-04-24)
  * All service API cmdlets
    - Cmdlets that invoke APIs on AWS services can now display a message stating the API and service endpoint or region the call is being dispatched to when the -Verbose switch is used. This can be used to help diagnose endpoint resolution failures.
  * AWS CodeStar
    - Added support for the new AWS CodeStar service. Cmdlets for the service have the noun prefix CST and can be listed with the command Get-AWSCmdletName -Service CST.
  * Amazon Lex Model Builder Service
    - Added support for the new Amazon Lex Model Builder Service. Cmdlets for the service have the noun prefix LMB and can be listed with the command Get-AWSCmdletName -Service LMB.
  * Amazon EC2
    - Added a new cmdlet, New-EC2FpgaImage (CreateFpgaImage API), to support creating an Amazon FPGA Image (AFI) from a specified design checkpoint (DCP).
  * AWS Rekognition
    - Added a new cmdlet, Find-REKModerationLabel (DetectModerationLabel API), to support detection of explicit or suggestive adult content in an image. The cmdlet a list of corresponding labels with confidence scores, as well as a taxonomy (parent-child relation) for each label.
  * AWS Identity and Access Management
    - Updated the New-IAMRole cmdlet with a new parameter, -Description, and added a new cmdlet Update-IAMRoleDescription (UpdateRoleDescription API) to support specifying a user-provided description for the role.
    - Added cmdlet New-IAMServiceLinkedRole (CreateServiceLinkedRole API). This cmdlet enables creation of a new role type, Service Linked Role, which works like a normal role but must be managed via services' control.
  * Amazon Lambda
    - Added new cmdlets to support the new service feature using tags to group and filter Lambda functions. The new cmdlets are Add-LMResourceTag (TagResource API), Get-LMResourceTag (ListTags API) and Remove-LMResourceTag (UntagResource API).
    - Added a new parameter, -TracingConfig_Mode, to the Update-LMFunctionConfiguration cmdlet to support integration with CloudDebugger service to enable customers to enable tracing for the Lambda functions and send trace information to the CloudDebugger service.
  * Amazon API Gateway
    - Extended the Get-AGDeployment, Get-AGResource and Get-AGResourceList cmdlets with a new parameter, -Embed, to support specifying embedded resources to retrieve.
  * Amazon Polly
    - Added a new parameter, -SpeechMarkType, to the Get-POLSpeech cmdlet to support defining the speech marks to be used in the returned text.
  * AWS DeviceFarm
    - Added support for the new service feature for deals and promotions with a new cmdlet, Get-DFOfferingPromotion (ListOfferingPromotions API).

### 3.3.76.0 (2017-04-11)
  * Amazon S3
    - Fixed issue with the Copy-S3Object cmdlet throwing 'access denied' error when attempting to copy objects between buckets in different regions.
  * Amazon EC2
    - Fixed issue with 'file not found' errors when using a relative path with the -PemFile parameter.
  * Amazon API Gateway
    - Added cmdlets to support the new request validators feature. The new cmdlets are: New-AGRequestValidator (CreateRequestValidator API), Get-AGRequestValidator (GetRequestValidator API), Get-AGRequestValidatorList (GetRequestValidators API), Update-AGRequestValidator (UpdateRequestValidator API) and Remove-AGRequestValidator (DeleteRequestValidator API). The Write-AGMethod cmdlet was also updated with a new parameter, -RequestValidatorId, enabling you to specify a request validator for the method.
  * AWS Batch
    - Updated the New-BATComputeEnvironment cmdlet with a new parameter, -ComputeResources_ImageId, to support specifying an AMI for MANAGED Compute Environment.
  * AWS GameLift
    - Updated the New-GMLGameSessionQueue and Update-GMLGameSessionQueue cmdlets with a new parameter, -PlayerLatencyPolicy, to enable developers to specify a maximum allowable latency per queue.
  * AWS OpsWorks
    - Updated the New-OPSLayer and Update-OPSLayer cmdlets with new parameters -CloudWatchLogsConfiguration_Enabled and -CloudWatchLogsConfiguration_LogStream to attaching a Cloudwatch Logs agent configuration to OpsWorks Layers. OpsWorks will then automatically install and manage the CloudWatch Logs agent on the instances that are part of the OpsWorks Layer.

### 3.3.75.0 (2017-04-10)
  * Fixed issue with cmdlets taking a long time to return when no region was specified.
  * Fixed issue with the argument completer for the -ProfileName parameter issuing a warning message about use of a deprecated switch on the Get-AWSCredentials cmdlet.
  * Amazon Redshift
    - Added a new cmdlet, Get-RSClusterCredential, to support the new GetClusterCredentials API.

### 3.3.74.0 (2017-04-07)
  * AWS CloudWatch
    - Updated the Write-CWMetricAlarm cmdlet with support for new alarm configurations for missing data treatment and percentile metrics. Missing data can now be treated as alarm threshold breached, alarm threshold not breached, maintain alarm state and the current default treatment. Percentile metric alarms are for alarms that can trigger unnecessarily if the percentile is calculated from a small number of samples. The new rule can treat percentiles with low sample counts as same as missing data. If the first rule is enabled, the same treatment will be applied when an alarm encounters a percentile with low sample counts.
  * Amazon ElastiCacheElastiCache
    - Added support for testing the Elasticache Multi-AZ feature with Automatic Failover. This support includes a new parameter, -NodeGroupId, for the Edit-ECReplicationGroup cmdlet and -ShowCacheClustersNotInReplicationGroup added to Get-ECCacheCluster and a new cmdlet, Test-ECFailover (TestFailover API).
  * Amazon Lex
    - Added a new cmdlet, Send-LEXContent, to support the new PostContent API.

### 3.3.71.0 (2017-03-31)
  * AWS Resource Groups Tagging API
    - Added support for the new Resource Groups Tagging API service. Cmdlets for the service have the noun prefix 'RGT' and can be listed using the command 'Get-AWSCmdletName -Service RGT': Add-RGTResourceTag (TagResources API), Get-RGTResource (GetResources API), Get-RGTTagKey (GetTagKeys API), Get-RGTTagValue (GetTagValues API) and Remove-RGTResourceTag (UntagResources API).
  * AWS Storage Gateway
    - Added a new cmdlet, Invoke-CacheRefresh (RefreshCache API), and extended the New-SGNFSFileShare and Update-SGNFSFileShare cmdlets with new parameters -ReadOnly and -Squash.
  * Amazon Cloud Directory
    - Updated the Get-CDIRObjectAttribute cmdlet with two new parameters, -FacetFilter_FacetName and -FacetFilter_SchemaArn, to support the new service feature enabling filtering by facet.

### 3.3.69.0 (2017-03-29)
  * AWS Batch
    - Added parameters to support specifying retry strategy for the Register-BATJobDefinition and Submit-BATJob cmdlets. The parameter, -RetryStrategy_Attempt, accepts a numeric value for attempts. This is the number of non successful executions before a job is considered FAILED. In addition, the JobDetail object returned by other cmdlets now has an attempts field and shows all execution attempts.
  * Amazon EC2
    - Added support for tagging Amazon EC2 Instances and Amazon EBS Volumes at the time of their creation with the addition of a parameter, -TagSpecification, to the New-EC2Volume and New-EC2Instance cmdlets. By tagging resources at the time of creation, you can eliminate the need to run custom tagging scripts after resource creation. In addition, you can now set resource-level permissions on the CreateVolume, CreateTags, DeleteTags, and the RunInstances APIs. This allows you to implement stronger security policies by giving you more granular control over which users and groups have access to these APIs. You can also enforce the use of tagging and control what tag keys and values are set on your resources. When you combine tag usage and resource-level IAM policies together, you can ensure your instances and volumes are properly secured upon creation and achieve more accurate cost allocation reporting. These new features are provided at no additional cost.
  * Added the legacy alias Get-SSMParameterNameList (an alias for Get-SSMParameterValue) to the AliasesToExport collection in the module manifest so that the alias is available without needing to explicitly import the module.

### 3.3.67.0 (2017-03-24)
  * AWS Application Discovery Service
    - Added two new cmdlets Get-ADSExportTask (DescribeExportTasks API) and Start-ADSExportTask (StartExportTask API) to support the new service feature for exporting configuration options.
  * AWS Lambda
    - Added argument completion support for the new Node.js v6.10 runtime option.

### 3.3.65.0 (2017-03-21)
  * Amazon S3
    - Fixed issue with the Write-S3Object cmdlet reporting error "The difference between the request time and the current time is too large" when uploading very large (> 100GB) files.
  * Amazon Pinpoint
    - Added cmdlets Get-PINEventStream (GetEventStream API), Remove-PINEventStream (DeleteEventStream API) and Write-PINEventStream (PutEventStream API) to support publishing of raw app analytics and campaign events data as events streams to Kinesis and Kinesis Firehose. The Update-PINSegment and New-PINSegment cmdlets were updated with a new parameter, -Dimensions_UserAttribute, to support the ability to segment endpoints by user attributes in addition to endpoint attributes.
  * All cmdlet names are now enumerated into the module manifest enabling tab-completion of command names without needing to explicitly import the module into the environment.

### 3.3.64.2 (2017-03-17)
  * Fixed issue with Initialize-AWSDefaults reporting 'source profile not found' error when run to load credentials from the 'default' profile.

### 3.3.64.1 (2017-03-15)
  * Added support for reading and writing credential profiles to both the AWS .NET SDK encrypted credential store and the shared credential store used by other AWS SDKs and tools. Previously credentials could only be read from both stores, and written to only the SDK's encrypted store.
  * Added support for new credential profile types supporting cross-account IAM roles (aka 'assume role' profiles) and credentials requiring use of an MFA. For more details on the updated credential support see the blog post announcing the update at https://aws.amazon.com/blogs/developer/aws-sdk-dot-net-credential-profiles/ and the credential setup topics in the user guide at http://docs.aws.amazon.com/powershell/latest/userguide/pstools-getting-started.html.
  * AWS Device Farm
    - Added support for network shaping. Network shaping allows users to simulate network connections and conditions while testing their Android, iOS, and web apps with AWS Device Farm. The update includes new cmdlets Get-DFNetworkProfile (GetNetworkProfile API), Get-DFNetworkProfileList (ListNetworkProfiles API), New-DFNetworkProfile (CreateNetworkProfile API), Remove-DFNetworkProfile (DeleteNetworkProfile API) and Update-DFNetworkProfile (UpdateNetworkProfile API).

### 3.3.62.0 (2017-03-13)
  * Fixed issue with Set-AWSSamlRoleProfile incorrectly formatting user identities specified in email format. The identity was being stored in the role profile with as \email@domain.com (domain\userid format) but with empty domain. The leading \ then had to be removed by the user each time a password demand was issued.
  * Amazon Relation Database Service
    - Updated the Copy-RDSDBClusterSnapshot and New-RDSDBCluster cmdlets to add support for using encrypted clusters as cross-region replication masters and encrypted cross region copy of Aurora cluster snapshots.
  * Amazon Simple Systems Management
    - Added help examples for all SSM cmdlets.
  * Amazon WorkDocs
    - Added support for the Amazon WorkDocs service. The Amazon WorkDocs SDK provides full administrator level access to WorkDocs site resources, allowing developers to integrate their applications to manage WorkDocs users, content and permissions programmatically. Cmd;lets for this service have the noun prefix 'WD' and can be listed using the command 'Get-AWSCmdletName -Service WD'.
  * AWS Organizations
    - *Breaking Change*
    Updated cmdlets to fix an issue with the wrong service model version being used. This may be a breaking change for some users. The Enable-ORGFullControl cmdlet has been removed, and the Enable-ORGAllFeatures cmdlet added in the corrected.
  * Amazon Cloud Directory
    - Added a new cmdlet, Get-CDIRObjectParentPath, to enable retrieval of all available parent paths for any type of object (a node, leaf node, policy node, and index node) in a hierarchy.
  * Amazon API Gateway
    - Updated the New-AGDomainName cmdlet to add support for ACM certificates on custom domain names. Both Amazon-issued certificates and uploaded third-part certificates are supported.
  * Amazon Elastic MapReduce
    - Added support for instance fleets with new cmdlets Add-EMRInstanceFleet (AddInstanceFleet API), Edit-EMRInstanceFleet (ModifyInstanceFleet API) and Get-EMRInstanceFleets (ListInstanceFleets API).

### 3.3.58.0 (2017-03-06)
  * Amazon EC2
    - Added two new keys, WINDOWS_2016_CORE and WINDOWS_2012R2_CORE, to the Get-EC2ImageByName cmdlet, to support retrieving the latest Windows Server 2016 Core and Windows Server 2012R2 Core AMIs.
  * AWS OpsWorks
    - OpsWorks for Chef Automate has added a new field "AssociatePublicIpAddress" to the New-OWCMServer cmdlet, "CloudFormationStackArn" to the Server model and "TERMINATED" server state.

### 3.3.57.0 (2017-02-27)
  * AWS Organizations
    - Added support for the new AWS Organizations service. AWS Organizations is a web service that enables you to consolidate your multiple AWS accounts into an organization and centrally manage your accounts and their resources. Cmdlets for this service have the noun prefix ORG and can be listed using the command Get-AWSCmdletName -Service ORG.
  * Amazon MTurk Service
    - Added support for Amazon Mechanical Turk (MTurk), a web service that provides an on-demand, scalable, human workforce to complete jobs that humans can do better than computers, for example, recognizing objects in photos. Cmdlets for this service have the noun prefix MTR and can be listed using the command Get-AWSCmdletName -Service MTR.
  * Amazon Elasticsearch
    - Added three cmdlets to support new APIs for exposing limits imposed by Elasticsearch. The new cmdlets are Get-ESInstanceTypeLimit (DescribeElasticsearchInstanceTypeLimits API), Get-ESInstanceTypeList (ListElasticsearchInstanceTypes API) and Get-ESVersionList (ListElasticsearchVersions API).
  * Amazon DynamoDB
    - Added two new cmdlets to support the new 'Time to Live' APIs. The new cmdlets are Get-DDBTimeToLive (DescribeTimeToLive API) and Update-DDBTimeToLive (UpdateTimeToLive API).

### 3.3.56.0 (2017-02-23)
  * Fixed issue with the Set-AWSSamlRoleProfile cmdlet reporting a null reference exception.
  * (NetCore module only) Fixed issue with cmdlet help not being available due to a misnamed help file.
  * Amazon EC2
    - Added -InstanceType completion support for the new I3 instance type.

### 3.3.55.0 (2017-02-22)
  * Amazon EC2
    - Updated the Register-EC2Image cmdlet with a new parameter, -BillingProduct.
  * Amazon GameLift
    - Added cmdlet support for the new service feature enabling developers to configure global queues for creating GameSessions and to allow PlayerData on PlayerSessions to store player-specific data.
  * AWS Elastic Beanstalk
    - Added support for creating and managing custom platforms with environments.
    - *Breaking Change*
      The update for custom platform support changed the service response data for the DescribeConfigurationOptions API (Get-EBConfigurationOption cmdlet) to include an additional field, PlatformArn. Previously the cmdlet was able to pipe the configuration options collection to the pipeline. In this release the output from the cmdlet has changed so that the entire service response data (Amazon.ElasticBeanstalk.Model.DescribeConfigurationOptionsResponse) is emitted to the pipeline, not the collection of configuration options. To obtain the previous behavior, add a select clause to your code, for example: 'Get-EBConfigurationOption ...parameters... | select -expandproperty Options | ...'.

### 3.3.53.1 (2017-02-20)
  * Fixed bug in Get-AWSCredentials. When the -ListProfiles switch was used the collection of profile names was not correctly enumerated to the pipeline.

### 3.3.53.0 (2017-02-17)
  * AWS Direct Connect
    - Added cmdlet support for the new ability for Direct Connect customers to take advantage of Link Aggregation (LAG). This allows you to bundle many individual physical interfaces into a single logical interface, referred to as a LAG. This makes administration much simpler as the majority of configuration is done on the LAG while you are free to add or remove physical interfaces from the bundle as bandwidth demand increases or decreases. A concrete example of the simplification added by LAG is that customers need only a single BGP session as opposed to one session per physical connection.

### 3.3.52.0 (2017-02-16)
  * This version was only distributed in the downloadable AWS Tools for Windows msi installer.
  * AWS Config
    - Updated the Write-CFGEvaluations cmdlet with a new parameter, -TestMode. Set the TestMode parameter to true in your custom rule to verify whether your AWS Lambda function will deliver evaluation results to AWS Config. No updates occur to your existing evaluations, and evaluation results are not sent to AWS Config.

### 3.3.51.0 (2017-02-15)
  * Amazon EC2
    - Added cmdlet support for the new Modify Volumes APIs. This includes two new cmdlets, Edit-EC2Volume (ModifyVolume API) and Get-EC2VolumeModification (DescribeVolumesModification API).
  * AWS Key Management Service
    - Added support for the new tagging apis with three new cmdlets: Add-KMSResourceTag (TagResource API), Get-KMSResourceTag (ListResourceTags API) and Remove-KMSResourceTag (UntagResource API). The New-KMSKey cmdlet was also extended to support a -Tag parameter.
  * AWS Storage Gateway
    - Updated the New-SGNFSFileShare and Update-SGNFSFileShare cmdlets to support acess to objects in S3 as files on a Network File System (NFS) mount point. Customers can restrict the clients that have read/write access to the gateway by specifying the list of clients as a list of IP addresses or CIDR blocks to the new -ClientList parameter on these cmdlets.

### 3.3.48.0 (2017-02-09)
  * Amazon EC2
    - Fixed issue with the Get-EC2Instance cmdlet not accepting instance IDs that were supplied as PSObject types. The cast to string on the supplied PSObject(s) failed, resulting in the cmdlet listing all instances on output, not the requested instances.
    - Added support for a new feature enabling users to associate an IAM profile with running instances that were not launched with a profile. The new cmdlets are Get-EC2IamInstanceProfileAssociation (DescribeIamInstanceProfileAssociations API), Register-EC2IamInstanceProfile (AssociateIamInstanceProfile API), Set-EC2IamInstanceProfileAssociation (ReplaceIamInstanceProfileAssociation API) and Unregister-EC2IamInstanceProfileAssociation (DisassociateIamInstanceProfileAssociation API).

### 3.3.47.0
  * This build was not released.

### 3.3.46.0 (2017-02-07)
  * Fixed issue with the Get-AWSCredentials cmdlet reporting a 'could not find part of path' error attempting to access the %userprofile%\.aws folder (default folder of the shared credentials file) when run on systems where the shared credential file was not in use and the folder did not exist. The cmdlet should instead have tested for folder existence and silently skipped over it when not present.
  * Fixed issue with using SAML credential profiles in regions where a region-specific Security Token Service endpoint is required, eg China (Beijing). After successfully authenticating with the ADFS endpoint the tools request temporary credentials from STS and this call was always directed against the global sts.amazonaws.com endpoint, not the regional endpoint, thus failing to obtain credentials. To enable SAML role profiles to specify that a regional endpoint must be used, the Set-AWSSAMLRoleProfile cmdlet has been extended with a new parameter, -STSEndpointRegion, that can be used to specify the region system name (eg -STSEndpointRegion cn-north-1), resulting in the correct STS endpoint being used to obtain credentials.
  * Amazon Lex
    - Added support for the new Amazon Lex service, for building conversational interactions into any application using voice or text. Cmdlets for this service have the noun prefix 'LEX' and can be viewed using the command 'Get-AWSCmdletName -Service LEX'. Currently the service contains a single cmdlet, Send-LEXText, corresponding to the service's PostText API.

### 3.3.45.0 (2017-01-26)
  * Amazon Cloud Directory
    - Added support for the new Amazon Cloud Directory service, a highly scalable, high performance, multi-tenant directory service in the cloud. Its web-based directories make it easy for you to organize and manage application resources such as users, groups, locations, devices, policies, and the rich relationships between them. Cmdlets for this service have the noun prefix 'CDIR' and can be viewed using the command 'Get-AWSCmdletName -Service CDIR'.
  * AWS CodeDeploy
    - Updated cmdlets to support the new service feature enabling blue/green deployments. In a blue/green deployment, the current set of instances in a deployment group is replaced by new instances that have the latest application revision installed on them. After traffic is rerouted behind a load balancer to the replacement instances, the original instances can be terminated automatically or kept running for other uses. In addition to additional parameters on existing cmdlets, two new cmdlets were added: Resume-CDDeployment (ContinueDeployment API) and Skip-CDWaitTimeForInstanceTermination (SkipWaitTimeForInstanceTermination API).
  * Amazon EC2
    - Updated the Request-EC2SpotFleet cmdlet with a new parameter, -SpotFleetRequestConfig_ReplaceUnhealthyInstance, to support instance health check functionality to replace EC2 spot fleet instances with new ones.
  * Amazon Relational Database Service
    - Updated cmdlets to support the new Snapshot Engine version upgrade. This update includes a new cmdlet, Edit-RDSDBSnapshot, mapped to the ModifyDBSnapshot API.

### 3.3.44.0 (2017-01-25)
  * Amazon WorkSpaces
    - *Breaking Change* Fixed issue with incorrect mapping of Stop-WKSWorkspace to the TerminateWorkspaces API, which could cause data loss if termination was not expected. A new cmdlet, Remove-WKSWorkspace, has been added which maps to the TerminateWorkspaces API. Stop-WKSWorkspace has been mapped to the StopWorkspaces API and the existing -Request parameter changed to accept types of Amazon.Workspaces.Model.StopRequest (previously it accepted Amazon.Workspaces.Model.TerminateRequest). For users employing New-Object to construct the parameters, this is a breaking change (customers known to have used this cmdlet in the past few months have been contacted about this change).
    - In addition to introducing a new cmdlet and correcting the mapping we have also taken steps to improve the usability of the cmdlets related to manipulating workspaces (Start-WKSWorkspace, Stop-WKSWorkspace, Remove-WKSWorkspace, Reset-WKSWorkspace and Rebuild-WKSWorkspace). These cmdlets all now support an additional –WorkspaceId parameter. This parameter accepts an array of strings that are the IDs of the workspaces to operate on, improving pipeline usability. Examples have been added to the cmdlet help to show the new simplified usages.
  * Elastic Load Balancing V2
    - Application Load Balancers now support native Internet Protocol version 6 (IPv6) in an Amazon Virtual Private Cloud (VPC). With this ability, clients can now connect to the Application Load Balancer in a dual-stack mode via either IPv4 or IPv6. The New-ELB2LoadBalancer was extended with a new parameter, -IpAddressType, to support this new feature and one new cmdlet was added, Set-ELB2IpAddressType (SetIpAddressType API).
  * Amazon Relational Database Service
    - Extended the New-RDSDBInstanceReadReplica cmdlet with parameters -KmsKeyId. -PresignedUrl and -SourceRegion to support cross-region read replica copying.

### 3.3.43.0 (2017-01-24)
  * AWS CodeCommit
    - Added new cmdlets Get-CCBlob (GetBlob API) and Get-CCDifferenceList (GetDifferences API) to support the new service feature for viewing differences between commits. The existing Get-CCBranchList and get-CCRepositoryList cmdlets have also been extended to support automatic pagination of all results now that it is supported on these API calls by the service.
  * Amazon EC2 Container Service (ECS)
    - Added a new cmdlet, Update-ECSContainerInstancesState (UpdateContainerInstancesState API) to support the new service feature enabling state for container instances that can be used to drain a container instance in preparation for maintenance or cluster scale down.

### 3.3.42.0 (2017-01-20)
  * This version was only distributed in the downloadable AWS Tools for Windows msi installer.
  * AWS Health
    - Updated the parameter documentation for several cmdlets to match latest service documentation updates.
  * AWS Certificate Manager
    - Updated the parameter documentation for several cmdlets to match latest service documentation updates.

### 3.3.41.0 (2017-01-19)
  * This version was only distributed in the downloadable AWS Tools for Windows msi installer.
  * Amazon EC2
    - Extended the Request-EC2SpotInstance cmdlet with a new parameter, Placement_Tenacy, to support the new service feature for dedicated tenancy, providing the ability to run Spot instances single-tenant manner on physically isolated hardware within a VPC to satisfy security, privacy, or other compliance requirements. Dedicated Spot instances can be requested using RequestSpotInstances and RequestSpotFleet.
  * AWS Health
    - Updated the parameter documentation for several cmdlets to match latest service documentation updates.

### 3.3.40.0 (2017-01-18)
  * This release contained only changes in the underlying AWS SDK for .NET and was not published to the gallery.

### 3.3.39.0 (2017-01-17)
  * Amazon DynamoDB
    - Added support for the new APIs to tag tables and indexes with three new cmdlets: Add-DDBResourceTag (TagResource API), Get-DDBResourceTag (ListTagsOfResource API) and Remove-DDBResourceTag (UntagResource API).

### 3.3.38.0 (2017-01-16)
  * AWS Cost and Usage Report
    - Added support for the new AWS Cost and Usage Report service. This service API allows you to enable and disable the Cost & Usage report, as well as modify the report name, the data granularity, and the delivery preferences. Cmdlets for this service have the noun prefix 'CUR' and can be viewed by running the command 'Get-AWSCmdletName -Service CUR'.

### 3.3.37.2 (2017-01-12)
  * Amazon EC2
    - Added new keys to the Get-EC2ImageByName cmdlet to support querying for Windows Server 2012R2 images with SQL Server 2016.

### 3.3.37.1 (2017-01-09)
  * AWS Health
    - Added support for the AWS Health service. The AWS Health API serves as the primary source for you to receive personalized information related to your AWS infrastructure, guiding your through scheduled changes, and accelerating the troubleshooting of issues impacting your AWS resources and accounts. Cmdlets for the service have the noun prefix 'HLTH' and can be viewed using the command 'Get-AWSCmdletName -Service HLTH'.
  * Get-AWSCmdletName
    - Fixed bug when invoking the cmdlet with no parameters. Instead of outputting the set of all service cmdlets an error 'Value cannot be null' was displayed.

### 3.3.37.0 (2017-01-05)
  * AWS Lambda
    - Updated the Publish-LMFunction and Update-LMFunctionCode with new parameters to support the latest features in these APIs (e.g. environment variable support, VPC configuration etc) and made both cmdlets consistent with support for specifying the function code to upload using an object in an Amazon S3 bucket. The parameter names used in both cmdlets have also been made consistent, with aliases applied for backwards compatibility. Help examples for the two cmdlets have also been added.
  * AWS Marketplace Commerce Analytics
    - Added argument completion support for the new data set disbursed_amount_by_instance_hours, with historical data available starting 2012-09-04. New data is published to this data set every 30 days.
