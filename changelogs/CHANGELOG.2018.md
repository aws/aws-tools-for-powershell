### 3.3.428.0 (2018-12-14)
  * AWSPowerShell and AWSPowerShell.NetCore now use AWS .NET SDK 3.3.428.0 and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.
  * Amazon Alexa For Business
    * Added cmdlet Add-ALXBSkillToUser leveraging the AssociateSkillWithUsers service API.
    * Added cmdlet Get-ALXBBusinessReportScheduleList leveraging the ListBusinessReportSchedules service API.
    * Added cmdlet New-ALXBBusinessReportSchedule leveraging the CreateBusinessReportSchedule service API.
    * Added cmdlet Remove-ALXBBusinessReportSchedule leveraging the DeleteBusinessReportSchedule service API.
    * Added cmdlet Remove-ALXBSkillFromUser leveraging the DisassociateSkillFromUsers service API.
    * Added cmdlet Update-ALXBBusinessReportSchedule leveraging the UpdateBusinessReportSchedule service API.
  * Amazon Amplify
    * Added support for AWS Amplify. AWS Amplify enables developers to develop and deploy cloud-powered mobile and web apps. Cmdlets for the service have the noun prefix AMP and can be listed using the command 'Get-AWSCmdletName -Service AMP'.
  * Amazon App Mesh
    * Added support for AWS App Mesh. AWS App Mesh makes it easy to monitor and control microservices running on AWS. Cmdlets for the service have the noun prefix AMSH and can be listed using the command 'Get-AWSCmdletName -Service AMSH'.
  * Amazon Auto Scaling Plans
    * Added support for AWS Auto Scaling Plans. Use AWS Auto Scaling to quickly discover all the scalable AWS resources for your application and configure dynamic scaling and predictive scaling for your resources using scaling plans. Cmdlets for the service have the noun prefix ASP and can be listed using the command 'Get-AWSCmdletName -Service ASP'.
  * Amazon Chime
    * Added support for Amazon Chime. Amazon Chime is a secure, real-time, unified communications service that transforms meetings by making them more efficient and easier to conduct. The Amazon Chime API (application programming interface) is designed for administrators to use to perform key tasks, such as creating and managing Amazon Chime accounts and users. Cmdlets for the service have the noun prefix CHM and can be listed using the command 'Get-AWSCmdletName -Service CHM'.
  * Amazon CodeBuild
    * Added cmdlet Get-CBSourceCredentialList leveraging the ListSourceCredentials service API.
    * Added cmdlet Import-CBSourceCredential leveraging the ImportSourceCredentials service API.
    * Added cmdlet Remove-CBSourceCredential leveraging the DeleteSourceCredentials service API.
  * Amazon Cognito Sync
    * Added support for Amazon Cognito Sync. Amazon Cognito Sync provides an AWS service and client library that enable cross-device syncing of application-related user data. High-level client libraries are available for both iOS and Android. You can use these libraries to persist data locally so that it's available even if the device is offline. Cmdlets for the service have the noun prefix CGIS and can be listed using the command 'Get-AWSCmdletName -Service CGIS'.
  * Amazon Comprehend Medical
    * Added support for AWS Comprehend Medical. Comprehend Medical extracts structured information from unstructured clinical text. Use these actions to gain insight in your documents. Cmdlets for the service have the noun prefix CMPM and can be listed using the command 'Get-AWSCmdletName -Service CMPM'.
  * Amazon Connect Service
    * Added support for Amazon Connect Service. Amazon Connect is a contact center as a service (CCaS) solution that offers easy, self-service configuration and enables dynamic, personal, and natural customer engagement at any scale. Cmdlets for the service have the noun prefix CONN and can be listed using the command 'Get-AWSCmdletName -Service CONN'.
  * Amazon DataSync
    * Added support for AWS DataSync. AWS DataSync is a managed data transfer service that makes it simpler for you to automate moving data between on-premises storage and Amazon Simple Storage Service (Amazon S3) or Amazon Elastic File System (Amazon EFS). Cmdlets for the service have the noun prefix DSYN and can be listed using the command 'Get-AWSCmdletName -Service DSYN'.
  * Amazon Elastic Container Service for Kubernetes
    * Added support for Amazon Elastic Container Service for Kubernetes. Amazon Elastic Container Service for Kubernetes (Amazon EKS) is a managed service that makes it easy for you to run Kubernetes on AWS without needing to stand up or maintain your own Kubernetes control plane. Kubernetes is an open-source system for automating the deployment, scaling, and management of containerized applications. Cmdlets for the service have the noun prefix EKS and can be listed using the command 'Get-AWSCmdletName -Service EKS'.
  * Amazon Elemental MediaConnect
    * Added support for AWS Elemental MediaConnect. AWS Elemental MediaConnect is a reliable, secure, and flexible transport service for live video. Using AWS Elemental MediaConnect, broadcasters and content owners can cost-effectively send high-value live content into the cloud, securely transmit it to partners for distribution, and replicate it to multiple destinations around the globe. Cmdlets for the service have the noun prefix EMCN and can be listed using the command 'Get-AWSCmdletName -Service EMCN'.
  * Amazon Elemental MediaLive
    * Modified cmdlet New-EMLInput: added parameters MediaConnectFlow and RoleArn.
    * Modified cmdlet Update-EMLInput: added parameters MediaConnectFlow and RoleArn.
  * Amazon Elemental MediaStore
    * Added cmdlet Get-EMSLifecyclePolicy leveraging the GetLifecyclePolicy service API.
    * Added cmdlet Remove-EMSLifecyclePolicy leveraging the DeleteLifecyclePolicy service API.
    * Added cmdlet Write-EMSLifecyclePolicy leveraging the PutLifecyclePolicy service API.
  * Amazon Elemental MediaTailor
    * Added support for AWS Elemental MediaTailor. AWS Elemental MediaTailor is a personalization and monetization service that allows scalable server-side ad insertion. The service enables you to serve targeted ads to viewers while maintaining broadcast quality in over-the-top (OTT) video applications. The service also enables you to track ad views for accurate ad reporting. Cmdlets for the service have the noun prefix EMT and can be listed using the command 'Get-AWSCmdletName -Service EMT'.
  * Amazon FSx
    * Added support for Amazon FSx. Amazon FSx is a fully managed service that makes it easy for storage and application administrators to launch and use shared file storage. Cmdlets for the service have the noun prefix FSX and can be listed using the command 'Get-AWSCmdletName -Service FSX'.
  * Amazon Glacier
    * Added support for Amazon Glacier. Amazon Glacier is a storage service optimized for infrequently used data, or "cold data." The service provides durable and extremely low-cost storage with security features for data archiving and backup. Cmdlets for the service have the noun prefix GLC and can be listed with the command 'Get-AWSCmdletName -Service GLC'.
  * Amazon Global Accelerator
    * Added support for AWS Global Accelerator. AWS Global Accelerator is a network layer service in which you create accelerators to improve availability and performance for internet applications used by a global audience. Cmdlets for the service have the noun prefix GACL and can be listed using the command 'Get-AWSCmdletName -Service GACL'.
  * Amazon Glue
    * Modified cmdlet Get-GLUEConnection: added parameter HidePassword.
    * Modified cmdlet Get-GLUEConnectionList: added parameter HidePassword.
    * Modified cmdlet Set-GLUEDataCatalogEncryptionSetting: added parameters ConnectionPasswordEncryption_AwsKmsKeyId and ConnectionPasswordEncryption_ReturnConnectionPasswordEncrypted.
  * Amazon Identity and Access Management
    * Added cmdlet Get-IAMPolicyGrantingServiceAccessList leveraging the ListPoliciesGrantingServiceAccess service API.
    * Added cmdlet Get-IAMServiceLastAccessedDetail leveraging the GetServiceLastAccessedDetails service API.
    * Added cmdlet Get-IAMServiceLastAccessedDetailWithEntity leveraging the GetServiceLastAccessedDetailsWithEntities service API.
    * Added cmdlet Request-IAMServiceLastAccessedDetail leveraging the GenerateServiceLastAccessedDetails service API.
  * Amazon Kinesis Analytics (V2)
    * Added support for V2 of Amazon Kinesis Analytics. Cmdlets for the service have the noun prefix KINA2 and can be listed using the command 'Get-AWSCmdletName -Service KINA2'.
  * Amazon License Manager
    * Added support for AWS License Manager. AWS License Manager streamlines the process of bringing software vendor licenses to the cloud. Cmdlets for the service have the noun prefix LICM and can be listed using the command 'Get-AWSCmdletName -Service LICM'.
  * Amazon Managed Streaming for Kafka (Preview)
    * Added support for Amazon Managed Streaming for Kafka. Amazon Managed Streaming for Kafka (Amazon MSK) is a fully managed service that makes it easy for you to build and run applications that use Apache Kafka to process streaming data. Cmdlets for the service have the noun prefix MSK and can be listed using the command 'Get-AWSCmdletName -Service MSK'.
  * Amazon Mobile
    * Added support for AWS Mobile. AWS Mobile Service provides mobile app and website developers with capabilities required to configure AWS resources and bootstrap their developer desktop projects with the necessary SDKs, constants, tools and samples to make use of those resources. Cmdlets for the service have the noun prefix MOBL and can be listed using the command 'Get-AWSCmdletName -Service MOBL'.
  * Amazon Neptune
    * Added support for Amazon Neptune. Amazon Neptune is a fast, reliable, fully managed graph database service that makes it easy to build and run applications that work with highly connected datasets. Cmdlets for the service have the noun prefix NPT and can be listed with the command 'Get-AWSCmdletName -Service NPT'.
  * Amazon Performance Insights
    * Added support for AWS Performance Insights. AWS Performance Insights enables you to monitor and explore different dimensions of database load based on data captured from a running RDS instance. Cmdlets for the service have the noun prefix PI and can be listed with the command 'Get-AWSCmdletName -Service PI'.
  * Amazon Pinpoint Email
    * Added cmdlet Get-PINEBlacklistReport leveraging the GetBlacklistReports service API.
    * Added cmdlet Get-PINEDeliverabilityDashboardOption leveraging the GetDeliverabilityDashboardOptions service API.
    * Added cmdlet Get-PINEDeliverabilityTestReport leveraging the GetDeliverabilityTestReport service API.
    * Added cmdlet Get-PINEDeliverabilityTestReportList leveraging the ListDeliverabilityTestReports service API.
    * Added cmdlet Get-PINEDomainStatisticsReport leveraging the GetDomainStatisticsReport service API.
    * Added cmdlet New-PINEDeliverabilityTestReport leveraging the CreateDeliverabilityTestReport service API.
    * Added cmdlet Write-PINEDeliverabilityDashboardOption leveraging the PutDeliverabilityDashboardOption service API.
  * Amazon QuickSight
    * Added support for Amazon QuickSight. Amazon QuickSight is a fast, cloud-powered BI service that makes it easy to build visualizations, perform ad hoc analysis, and quickly get business insights from your data. Cmdlets for the service have the noun prefix QS and can be listed using the command 'Get-AWSCmdletName -Service QS'.
  * Amazon RDS DataService
    * Added cmdlet Invoke-RDSDSqlExecution to support the AWS RDS DataService. The AWS RDS DataService provides a Http Endpoint to query RDS databases.  The noun prefix for this service is RDSD which will also be applied to any new APIs this service exposes.
  * Amazon Resource Access Manager
    * Added support for AWS Resource Manager. AWS Resource Access Manager (AWS RAM) enables you to share your resources with any AWS account or organization in AWS Organizations. Customers who operate multiple accounts can create resources centrally and use AWS RAM to share them with all of their accounts to reduce operational overhead. Cmdlets for the service have the noun prefix RAM and can be listed with the command 'Get-AWSCmdletName -Service RAM'.
  * Amazon RoboMaker
    * Added support for AWS RoboMaker. AWS RoboMaker is a service that makes it easy to develop, simulate, and deploy intelligent robotics applications at scale. Cmdlets for the service have the noun prefix ROBO and can be listed with the command 'Get-AWSCmdletName -Service ROBO'.
  * Amazon Route 53 Resolver
    * Added support for Amazon Route 53 Resolver. Cmdlets for the service have the noun prefix R53R and can be listed using the command 'Get-AWSCmdletName -Service R53R'.
  * Amazon SageMaker Service
    * Modified cmdlet New-SMHyperParameterTuningJob: added parameter HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType.
  * Amazon Security Hub
    * Added support for AWS Security Hub service (Preview). AWS Security Hub provides you with a comprehensive view of your security state within AWS and your compliance with the security industry standards and best practices. Security Hub collects security data from across AWS accounts, services, and supported third-party partners and helps you analyze your security trends and identify the highest priority security issues. Cmdlets for the service have the noun prefix SHUB and can be listed using the command 'Get-AWSCmdletName -Service SHUB'.
  * Amazon Transfer for SFTP
    * Added support for AWS Transfer for SFTP. AWS Transfer is a fully managed service that enables the transfer of files over the Secure File Transfer Protocol (SFTP) directly into and out of Amazon Simple Storage Service (Amazon S3). Cmdlets for the service have the noun prefix TFR and can be listed using the command 'Get-AWSCmdletName -Service TFR'.

### 3.3.422.0 (2018-12-06)
  * Amazon CloudDirectory
    * [Breaking Change] The service output for the APIs called by the Get-CDIRObjectParent cmdlet has been updated and it is no longer possible for these cmdlets to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon EC2
    * [Breaking Change] The response data from the service's CreateFleet API has been extended to emit the instances launched in the API response.
    * Added and updated cmdlets:
      * Transit Gateway helps easily scale connectivity across thousands of Amazon VPCs, AWS accounts, and on-premises networks.
      * Added the AvailabilityZoneId parameter to Get-AvailabilityZone cmdlet.
      * VM Import/Export now supports generating encrypted EBS snapshots, as well as AMIs backed by encrypted EBS snapshots during the import process.
      * With On-Demand Capacity Reservations, customers can reserve the exact EC2 capacity they need, and can keep it only for as long as they need it.
      * Provides customers the ability to Bring Your Own IP (BYOIP) prefix. You can bring part or all of your public IPv4 address range from your on-premises network to your AWS account. You continue to own the address range, but AWS advertises it on the internet.
    * Updated cmdlet Get-EC2ReservedInstancesModification to add pagination support.
  * Amazon ECS
    * [Breaking Change] The response data from the service's DescribeTaskDefinition API has been extended to emit both the task definition and the tags that are applied to it. The output from the corresponding Get-TaskDefinitionDetail cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-TaskDefinitionDetail).TaskDefinition_ in place of _Get-TaskDefinitionDetail_.
    * Added and updated cmdlets.
      * This release of Amazon Elastic Container Service (Amazon ECS) introduces support for additional Docker flags as Task Definition parameters. Customers can now configure their ECS Tasks to use pidMode (pid) and ipcMode (ipc) Docker flags.
      * ECS now supports integration with Systems Manager Parameter Store for injecting runtime secrets.
      * ECS introduces support for resources tagging.
      * ECS introduces a new ARN and ID Format for its resources, and provides new APIs for opt-in to the new formats.
      * ECS introduces support for blue/green deployment feature
  * Amazon ResourceGroups
    * [Breaking Change] The service output for the APIs called by the Get-RGGroupResourceList and Find-RGResource APIs cmdlets has been updated and it is no longer possible for these cmdlets to return all available data using automatic pagination. You script will need to be updated to manually paginate the returned data using the *NextToken* parameter and field in the returned service response.
  * Amazon Translate
    * [Breaking Change] The response data from the service's TranslateText API has been extended to emit both the translated text and terminology names. The output from the corresponding ConvertTo-TRNTargetLanguage cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(ConvertTo-TRNTargetLanguage).Text_ in place of _ConvertTo-TRNTargetLanguage_.
    * Added and updated cmdlet supporting custom terminology. Using custom terminology with your translation requests enables you to make sure that your brand names, character names, model names, and other unique content is translated exactly the way you need it, regardless of its context and the Amazon Translate algorithm's decision.
  * Amazon AlexaForBusiness
    * Added and updated cmdlets to extend the functionality of the Alexa for Business SDK, including additional support for third-party Alexa built-in devices, managing private and public skills, and conferencing setup.
  * Amazon AppSync
    * Added and updated cmdlets. AWS AppSync now supports:
      1. Pipeline Resolvers - Enables execution of one or more operations against multiple data sources in order, on a single GraphQL field. This allows orchestration of actions by composing code into a single Resolver, or share code across Resolvers.
      2. Aurora Serverless Data Source - Built-in resolver for executing GraphQL operations with the new Aurora Serverless Data API, including connection management functionality.
  * Amazon Auto Scaling
    * Updated cmdlets New-ASAutoScalingGroup and Update-ASAutoScalingGroup to allow users to provision and automatically scale instances across purchase options (Spot, On-Demand, and RIs) and instance types in a single Auto Scaling group (ASG).
  * Amazon Batch
    * Updated cmdlet New-BATComputeEnvironment adding EC2 Launch Template support.
    * Updated cmdlets Get-BATJobsList, New-BATComputeEnvironment, Register-BATJobDefinition and Submit-BATJob adding support for multinode parallel jobs, placement group support for compute environments.
  * Amazon Budgets
    * Added Get-BGTBudgetPerformanceHistory cmdlet enabling you to see how well your budgets matched your actual costs and usage.
    * Updated cmdlets adding budget performance history, notification state, and last updated time, enabling you to see how well your budgets matched your actual costs and usage, how often your budget alerts triggered, and when your budget was last updated.
  * Amazon CloudFormation
    * Added cmdlets Get-CFNDetectedStackResourceDrift, Get-CFNStackDriftDetectionStatus, Get-CFNStackResourceDrift and Start-CFNStackDriftDetection. The Drift Detection feature enables customers to detect whether a stack's actual configuration differs, or has drifted, from its expected configuration as defined within AWS CloudFormation.
  * Amazon CloudFront
    * Updated cmdlets New-CFDistribution, New-CFDistributionWithTag and Update-CFDistribution adding Origin Failover capability in CloudFront, you can setup two origins for your distributions - primary and secondary, such that your content is served from your secondary origin if CloudFront detects that your primary origin is unavailable. These origins can be any combination of AWS origins or non-AWS custom HTTP origins.
  * Amazon CloudTrail
    * Updated cmdlets New-CTTrail and Update-CTTrail supporting creation of a trail in CloudTrail that logs events for all AWS accounts in an organization in AWS Organizations.
  * Amazon CloudWatch
    * Updated cmdlets Get-EBEnvironmentManagedActionHistory and Get-EBInstanceHealth to add pagination support.
    * Updated cmdlet Write-CWMetricAlarm supporting alarms on metric math expressions.
  * Amazon CloudWatchEvents
    * Updated cmdlets Remove-CWERule and Remove-CWETarget by adding Enforce paramter
  * Amazon CloudWatchLogs
    * Added cmdlets Get-CWLQuery, Get-CWLLogGroupField, Get-CWLLogRecord, Get-CWLQueryResult, Start-CWLQuery, Stop-CWLQuery supporting CloudWatch Logs Insights
  * Amazon CodeBuild
    * Updated cmdlets New-CBProject, Start-CBBuild and Update-CBProject adding queue phase and configurable queue timeout to CodeBuild.
  * Amazon CodeDeploy
    * Added cmdlets Get-CDDeploymentTargetBatch, Get-CDDeploymentTarget, Get-CDDeploymentTargetList supporting Amazon ECS deployment.
  * Amazon CodePipeline
    * Updated cmdlet Start-CPPipelineExecution adding the ClientRequestToken parameter: the system-generated unique ID used to identify a unique execution request.
  * Amazon CodeStar
    * Added New-CSTProject cmdlet allowing to create projects from source code and a toolchain definition that you provide.
  * Amazon Comprehend
    * Added and updated cmdlets:
      * Custom Entities automatically trains entity recognition models using your entities and noun-based phrases.
      * Custom Classification automatically trains classification models using your text and custom labels.
  * Amazon ConfigService
    * Added cmdlets Get-CFGAggregateDiscoveredResourceCount, Get-CFGAggregateDiscoveredResourceList, Get-CFGAggregateResourceConfig and Get-CFGAggregateResourceConfigBatch providing support for aggregating the configuration data of AWS resources into multi-account and multi-region aggregators.
  * Amazon CostExplorer
    * Added cmdlet Get-CECostForecast which allows you to programmatically access AWS Cost Explorer's forecasting engine.
    * Updated cmdlet Get-CEReservationCoverage adding normalized unit support.
  * Amazon DatabaseMigrationService
    * Updated cmdlets Edit-DMSEndpoint, New-DMSEndpoint and New-DMSReplicationInstance to support Kinesis and Elasticsearch as targets.
  * Amazon DeviceFarm
    * Updated cmdlet Get-DFDeviceList and Submit-DFTestRun allowing to schedule runs without a need to create a Device Pool.
  * Amazon DirectConnect
    * Updated cmdlet Remove-DCBGPPeer adding BgpPeerId parameter.
  * Amazon DLM
    * Amazon Data Lifecycle Manager (DLM) for EBS Snapshots provides a simple, automated way to back up data stored on Amazon EBS volumes.
  * Amazon DynamoDB
    * Added cmdlets Write-DDBItemTransactionally and Get-DDBItemTransactionally to support ACID transactions which simplify the developer experience of making coordinated, all-or-nothing changes to multiple items both within and across tables.
    * Updated cmdlets Update-DDBGlobalTableSetting and Update-DDBTable-Cmdlet to support DynamoDB on-demand which offers simple pay-per-request pricing for read and write requests so that you only pay for what you use, making it easy to balance costs and performance.
  * Amazon Elastic Beanstalk
    * Updated cmdlet Get-EBEnvironmentManagedActionHistory and Get-EBInstanceHealth to add pagination support.
  * Amazon Elastic Load Balancing V2
    * Added and updated cmdlets
      * This release allows Application Load Balancers to route traffic to Lambda functions, in addition to instances and IP addresses.
      * ELBv2 now allows you to enable health checks.
  * Amazon Greengrass
    * Added and updated cmdlets supporting bulk deployment operations, Greengrass Connectors and allowing Lambda functions to run without Greengrass containers.
  * Amazon IdentityManagement
    * Added and updated cmdlets making it easier for you to manage your AWS Identity and Access Management (IAM) resources by enabling you to add tags to your IAM principals (users and roles). Adding tags on IAM principals will enable you to write fewer policies for permissions management and make policies easier to comprehend.  Additionally, tags will also make it easier for you to grant access to AWS resources.
  * Amazon IoT
    * Added and updated cmdlets.
      * We are extending capability of AWS IoT Rules Engine to support IoT Events rule action. The IoT Events rule action lets you send messages from IoT sensors and applications to IoT Events for pattern recognition and event detection.
      * IoT now supports resource tagging and tag based access control for Billing Groups, Thing Groups, Thing Types, Jobs, and Security Profiles. IoT Billing Groups help you group devices to categorize and track your costs.
      * AWS IoT Device Management introduces Dynamic thing groups, Jobs dynamic rollouts and Device connectivity indexing.
  * Amazon KinesisFirehose
    * Added cmdlets Start-KINFDeliveryStreamEncryption and Stop-KINFDeliveryStreamEncryption allowing you to enable/disable server-side encryption(SSE) for your delivery streams ensuring encryption of data at rest.
    * Updated cmdlet New-KINFDeliveryStream allowing to assign a set of tags to the delivery stream.
  * Amazon Kinesis Video
    * Updated cmdlets to add pagination support.
  * Amazon Kinesis Analytics
    * Updated cmdlets Add-KINAApplicationInput, Add-KINAApplicationOutput, and New-KINAApplication to add improvements to error messages, validations, and more to the Kinesis Data Analytics
  * Amazon KeyManagementService
    * Added and updated cmdlets enabling customers to create and manage dedicated, single-tenant key stores in addition to the default KMS key store. These are known as custom key stores and are deployed using AWS CloudHSM clusters. Keys that are created in a KMS custom key store can be used like any other customer master key in KMS.
  * AWS Lambda
    * Added and updated cmlets to support Lambda Layers and Ruby as a runtime. Lambda Layers are a new type of artifact that contains arbitrary code and data, and may be referenced by zero, one, or more functions at the same time. You can also now develop your AWS Lambda function code using the Ruby programming language.
  * Amazon Lightsail
    * Added and updated cmdlets.
      * Copy instance and disk snapshots within the same AWS Region or from one region to another in Amazon Lightsail.
      * Export Lightsail instance and disk snapshots to Amazon Elastic Compute Cloud (Amazon EC2).
      * Create an Amazon EC2 instance from an exported Lightsail instance snapshot using AWS CloudFormation stacks.
      * Apply tags to filter your Lightsail resources, or organize your costs, or control access.
  * AWS MarketPplace Metering
    * Added cmdlet Register-MMUsage allows sellers to meter and entitle Docker container software use with AWS Marketplace
  * Amazon Macie
    * Amazon Macie is a security service that uses machine learning to automatically discover, classify, and protect sensitive data in AWS.
  * Amazon MediaConvert
    * Added cmdlets Register-EMCCertificate and Unregister-EMCCertificate.
  * Amazon MediaPackage
    * Updated cmdlets EMPOriginEndpoint and EMPOriginEndpoint to support encrypted content keys.
  * Amazon MQ
    * Added cmdlets Get-MQTagList, New-MQTags and, Remove-MQTags and updated cmdlets New-MQBroker and New-MQConfiguration adding support for cost allocation tagging. You can now create, delete, and list tags for AmazonMQ resources.
  * Amazon Pinpoint
    * Added and updated cmdlets.
      * With Amazon Pinpoint Voice, you can use text-to-speech technology to deliver personalized voice messages to your customers. Amazon Pinpoint Voice is a great way to deliver transactional messages to customers. 2. Adding support for Campaign Event Triggers.
      * With Campaign Event Triggers you can now schedule campaigns to execute based on incoming event data and target just the source of the event.
    * Updated cmdlets Send-PINMessage, Send-PINUserMessageBatch and Update-PINEmailChannel allowing to send transactional email.
  * Amazon PinpointEmail
    * You can use Amazon Pinpoint Email to configure and send transactional email from your Amazon Pinpoint account to specific email addresses. Unlike campaign-based email that you send from Amazon Pinpoint, you don't have to create segments and campaigns in order to send transactional email.
  * Amazon Polly
    * Updated cmdlets Get-POLLexiconList and Get-POLVoice to add pagination support.
  * Amazon RDS
    * Added cmdlet Remove-RDSDBInstanceAutomatedBackup and updated cmdlet Remove-RDSDBInstance introducing DB Instance Automated Backups for the MySQL, MariaDB, PostgreSQL, Oracle and Microsoft SQL Server database engines. You can now retain Amazon RDS automated backups (system snapshots and transaction logs) when you delete a database instance. This allows you to restore a deleted database instance to a specified point in time within the backup retention period even after it has been deleted, protecting you against accidental deletion of data.
    * Updated cmdlet New-RDSDBInstanceReadReplica, Restore-RDSDBInstanceFromDBSnapshot and Restore-RDSDBInstanceToPointInTime allowing to specify VPC security groups.
    * Added cmdlets Edit-RDSDBClusterEndpoint, Get-RDSDBClusterEndpoint, New-RDSDBClusterEndpoint and Remove-RDSDBClusterEndpoint enabling Custom Endpoints, a new feature compatible with Aurora Mysql, Aurora PostgreSQL and Neptune that allows users to configure a customizable endpoint that will provide access to their instances in a cluster.
    * Added cmddlets New-RDSGlobalCluster, Get-RDSGlobalCluster, Edit-RDSGlobalCluster, Remove-RDSGlobalCluster and Remove-RDSFromGlobalCluster to support Amazon Aurora Global Database, a feature that allows a single Amazon Aurora database to span multiple AWS regions. Customers can use the feature to replicate data with no impact on database performance, enable fast local reads with low latency in each region, and improve disaster recovery from region-wide outages.
  * Amazon Redshift
    * Added and updated cmdlets. With this release, Redshift is providing API's for better snapshot management by supporting user defined automated snapshot schedules, retention periods for manual snapshots, and aggregate snapshot actions including batch deleting user snapshots, viewing account level snapshot storage metrics, and better filtering and sorting on the describe-cluster-snapshots API. Automated snapshots can be scheduled to be taken at a custom interval and the schedule created can be reused across clusters. Manual snapshot retention periods can be set at the cluster, snapshot, and cross-region-copy level. The retention period set on a manual snapshot indicates how many days the snapshot will be retained before being automatically deleted.
  * Amazon S3
    * Added and updated cmdlets.
      * S3 Object Lock enables customers to apply Write Once Read Many (WORM) protection to objects in S3 in order to prevent object deletion for a customer-defined retention period.
      * S3 Inventory now supports fields for reporting on S3 Object Lock. "ObjectLockRetainUntilDate", "ObjectLockMode", and "ObjectLockLegalHoldStatus" are now available as valid optional fields.
      * S3 Block Public Access bucket-level APIs. The new Block Public Access settings allow bucket owners to prevent public access to S3 data via bucket/object ACLs or bucket policies.
  * Amazon S3Control
    * Add support for new S3 Block Public Access account-level APIs. The Block Public Access settings allow account owners to prevent public access to S3 data via bucket/object ACLs or bucket policies.
  * Amazon SageMaker
    * Added and updated cmdlets.
      * Amazon SageMaker now has Algorithm and Model Package entities that can be used to create Training Jobs, Hyperparameter Tuning Jobs and hosted Models.
      *. Subscribed Marketplace products can be used on SageMaker to create Training Jobs, Hyperparameter Tuning Jobs and Models. Notebook Instances and Endpoints can leverage Elastic Inference accelerator types for on-demand GPU computing.
      * Model optimizations can be performed with Compilation Jobs. Labeling Jobs can be created and supported by a Workforce. Models can now contain up to 5 containers allowing for inference pipelines within Endpoints.
      * Code Repositories (such as Git) can be linked with SageMaker and loaded into Notebook Instances.
      * Network isolation is now possible on Models, Training Jobs, and Hyperparameter Tuning Jobs, which restricts inbound/outbound network calls for the container. However, containers can talk to their peers in distributed training mode within the same security group.
      * A Public Beta Search API was added that currently supports Training Jobs.
  * Amazon ServerMigrationService
    * Added and updated cmdlets supporting multi-server migration to simplify the application migration process. Customers can migrate all their application-specific servers together as a single unit as opposed to moving individual server one at a time.
  * Amazon Service Discovery
    * Added and updated cmlets.
      * Service Discovery now allows friendly names for your cloud resources so that your applications can quickly and dynamically discover them.
      * When a resource becomes available (for example, an Amazon EC2 instance running a web server), you can register a Service Discovery service instance. Then your application can discover service instances by submitting DNS queries or API calls.
  * Amazon SimpleSystemsManagement
    * Updated cmdlets Get-SSMDocument, Get-SSMDocumentDescription, New-SSMDocument, Start-SSMAutomationExecution and Update-SSMDocument.
  * ServerlessApplicationRepository
    * Added cmdlet New-SARCloudFormationTemplate and Get-SARCloudFormationTemplate and updated cmdlet New-SARCloudFormationChangeSet supporting creating and reading a broader set of AWS CloudFormation templates.
    * Added cmdlet Get-SARApplicationDependencyList supporting nested applications.
    * Updated cmdlets Get-SARApplicationList and Get-SARApplicationVersionList to add pagination support.
  * Amazon ServiceCatalog
    * Added and updated cmdlets allowing integration with AWS Organizations, enabling customers to more easily create and manage a portfolio of IT services across an organization. Administrators can now take advantage of the AWS account structure and account groupings configured in AWS Organizations to share Service Catalog Portfolios increasing agility and reducing risk. With this integration the admin user will leverage the trust relationship that exists within the accounts of the Organization to share portfolios to the entire Organization, a specific Organizational Unit or a specific Account.
  * Amazon Simple Email Service
    * Updated cmdlets Get-SESCustomVerificationEmailTemplateList and Get-SESReceiptRuleSetList to add pagination support.
  * Amazon SimpleNotificationService
    * Updated cmdlet New-SNSTopic adding optional Attributes parameter.
  * Amazon SimpleSystemsManagement
    * Updated cmdlets New-SSMAssociation and Update-SSMAssociation allowing users to select compliance severity to their association.
  * Amazon Step Functions
    * Updated cmdlets to integrate with eight additioanl AWS services:
      * Amazon ECS
      * AWS Fargate
      * Amazon DynamoDB
      * Amazon SNS
      * Amazon SQS
      * AWS Batch
      * AWS Glue
      * Amazon SageMaker
  * Amazon WAFRegional
    * Updated cmdlet Get-WAFRResourceForWebACLList allowing to configure protections for your Amazon API Gateway API.
  * Amazon WorkDocs
    * Added cmdlet Get-WDResource allowing to fetch files and folders from the user's SharedWithMe collection.
    * Updated cmdlet Get-WDActivity supporting additional filters such as the ActivityType and the ResourceId.
  * Amazon WorkSpaces
    * Added and updated cmdlets.
    * Added new APIs to Modify and Describe WorkSpaces client properties for users in a directory. With the new APIs, you can enable/disable remember me option in WorkSpaces client for users in a directory.
    * Added new Bring Your Own License (BYOL) automation APIs. With the new APIs, you can list available management CIDR ranges for dedicated tenancy, enable your account for BYOL, describe BYOL status of your account, and import BYOL images.
    * Added new APIs to describe and delete WorkSpaces images.
  * Amazon XRay
    * Added and updated cmdlets. Groups build upon X-Ray filter expressions to allow for fine tuning trace summaries and service graph results. You can configure groups by using the AWS X-Ray console or by using the New-XRGroup cmdlet. The addition of groups has extended the available request fields to the Get-XRServiceGraph cmdlet. You can now specify a group name or group ARN to retrieve its service graph.

### 3.3.390.0 (2018-10-22)
  * Cmdlets and parameters are now marked as obsolete if the corresponding service operation or parameter are deprecated.
  * Added support for Set-AWSProxy and Clear-AWSProxy cmdlets to AWSPowerShell.NetCore
  * Amazon Storage Gateway
    * [Breaking Change] The response data from the service's RefreshCache API has been extended to emit both the file share ARN and the notification id.
  * Amazon APIGateway
    * Updated cmdlets Test-AGInvokeMethod and Test-AGInvokeAuthorizer adding support for multi-value parameters.
  * Amazon AppStream
    * Added cmdlets providing support for creating, managing, and deleting users in the AppStream 2.0 user pool.
  * Amazon Auto Scaling
    * DateTime parameters of Get-ASScheduledAction and Write-ASScheduledUpdateGroupAction were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon CloudWatch
    * DateTime parameters of Get-CWAlarmHistory and Get-CWMetricData, Get-CWMetricStatistic were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon CodeCommit
    * Added cmdlets Get-CCFile, Get-CCFolder and Remove-CCFile allowing to get the contents of a file, get the contents of a folder, and delete a file in an AWS CodeCommit repository.
  * Amazon CodeStar
    * Updated cmdlet New-CSTProject enabling to tag CodeStar Projects at creation.
  * Amazon DirectConnect
    * Added cmdlet Update-DCVirtualInterfaceAttribute allowing to modify the MTU value of existing virtual interfaces.
  * Amazon Directory Service
    * Added and updated cmdlets related to launch of cross account for Directory Service and to create a new type of trust for active directory.
  * Amazon EC2
    * DateTime parameters of multiple cmdlets were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
    * Updated cmdlet Get-EC2RouteTable to add pagination support.
  * Amazon Elastic Beanstalk
    * DateTime parameters of Get-EBEnvironment and Get-EBEvent were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon ElastiCache
    * DateTime parameters of Get-ECEvent were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon Elasticsearch
    * Added cmdlets Start-ESElasticsearchServiceSoftwareUpdate and Stop-ESElasticsearchServiceSoftwareUpdate to support customer-scheduled service software updates. When new service software becomes available, you can request an update to your domain and benefit from new features more quickly. If you take no action, we update the service software automatically after a certain time frame.
  * Amazon Glue
    * Added cmdlet Get-GLUEDataCatalogEncryptionSetting. AWS Glue now supports data encryption at rest for ETL jobs and development endpoints. With encryption enabled, when you run ETL jobs, or development endpoints, Glue will use AWS KMS keys to write encrypted data at rest. You can also encrypt the metadata stored in the Glue Data Catalog using keys that you manage with AWS KMS. Additionally, you can use AWS KMS keys to encrypt the logs generated by crawlers and ETL jobs as well as encrypt ETL job bookmarks. Encryption settings for Glue crawlers, ETL jobs, and development endpoints can be configured using the security configurations in Glue. Glue Data Catalog encryption can be enabled via the settings for the Glue Data Catalog.
    * Added cmdlets Set-GLUEResourcePolicy, Get-GLUEResourcePolicy and Remove-GLUEResourcePolicy for creating, updating, reading and deleting Data Catalog resource-based policies.
  * Amazon GuardDuty
    * Updated cmdlets New-GDDetector and Update-GDDetector to support optional FindingPublishingFrequency parameter.
    * Updated cmdlets New-GDThreatIntelSet, New-GDIPSet and New-GDDetector to add an idempotency token parameter.
  * Amazon IoT
    * DateTime parameters of Get-IOTTaskList and Get-IOTViolationEventsList were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
    * Updated cmdlets New-IOTJob, Start-IOTJNextPendingJobExecution and Update-IOTJJobExecution to support job execution timeout functionalities. Customer now can set job execution timeout on the job level when creating a job.
  * Amazon Lightsail
    * Added cmdlets supporting Lightsail managed databases.
  * Amazon MediaConvert
    * Updated New-EMCQueue and Update-EMCQueue to support offering lower prices for predictable, non-urgent workloads, we propose the concept of Reserved Transcode pricing.
  * Amazon MQ
    * Updated cmdlet Update-MQBroker with new parameters AutoMinorVersionUpgrade and EngineVersion to support ActiveMQ 5.15.6, in addition to 5.15.0.
  * Amazon OpsWorksCM
    * Added cmdlet Export-OWCMServerEngineAttribute allowing to export engine specific attributes like the UserData script used for unattended bootstrapping of new nodes that connect to the server.
  * Amazon RDS
    * DateTime parameters of Get-RDSEvent, Reset-RDSDBCluster, Restore-RDSDBClusterToPointInTime and Restore-RDSDBInstanceToPointInTime were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
    * Updated cmdlets to support Deletion Protection for RDS databases.
  * Amazon Redshift
    * DateTime parameters of Get-RSClusterSnapshot and Get-RSEvent were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon S3
    * DateTime parameters of Copy-S3Object, Get-S3ObjectMetadata and Read-S3Object were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon ServiceCatalog
    * Added cmdlets to support Service Actions. With service actions, you as the administrator can enable end users to perform operational tasks, troubleshoot issues, run approved commands, or request permissions within Service Catalog. Service actions are defined using AWS Systems Manager documents, where you have access to pre-defined actions that implement AWS best practices, such asEC2 stop and reboot, as well as the ability to define custom actions.
  * Amazon Simple Email Service
    * DateTime parameters of Send-SESBounce were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.
  * Amazon SimpleSystemsManagement
    * Added and updated cmdlets allowing to interact with maintenance windows.
    * Updated cmdlets New-SSMPatchBaseline and Update-SSMPatchBaseline adding RejectedPatchesAction to enable stricted validation of the rejected Patches List.
  * Amazon StorageGateway
    * Updated cmdlet Invoke-SGCacheRefresh allowing to specify folders and subfolders.
  * Amazon  TranscribeService
    * Added cmdlet Remove-TRSTranscriptionJob allowing to delete completed transcription jobs.
  * Amazon WorkDocs
    * DateTime parameters of Get-WDActivity were marked as obsolete as they may result in the wrong timestamp being passed to the service, please use the new parameters marked with the "Utc" prefix.

### 3.3.365.0 (2018-09-21)
  * Get-AWSPublicIpAddressRange has been changed to honor proxy configurations provided through Set-AWSProxy.
  * Amazon Firewall Management Service
    * [Breaking Change] The response data from the service's GetAdminAccount API has been extended to emit both the administrator account and the status of the account. The output from the corresponding Get-FMSAdminAccount cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-FMSAdminAccount).AdminAccount_ in place of _Get-FMSAdminAccount_.
    * Added cmdlet Get-FMSMemberAccountList which allows to get all the member accounts belonging to a certain Fire Wall Manager admin account.
  * Amazon IOT
    * [Breaking Change] The response data from the service's GetIndexingConfiguration API has been extended to emit both the index configuration and the thing indexing configuration. The output from the corresponding Get-IOTIndexingConfiguration cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-IOTIndexingConfiguration).ThingIndexingConfiguration_ in place of _Get-IOTIndexingConfiguration_.
    * [Breaking Change] The response data from the service's SearchIndex API has been extended to emit both the things and the thing groups that match the search query. The output from the corresponding Search-IOTIndex cmdlet has therefore been changed to emit the service
 response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Search-IOTIndex).Things_ in place of _Search-IOTIndex_.
    * Updated cmdlet New-IOTOTAUpdate to allow specifying maximum number of OTA update job executions started per minute.
    * Updated cmdlet Update-IOTIndexingConfiguration to allow specifying the thing group indexing mode.
  * Amazon Cloud HSM V2
    * Added cmdlets Remove-HSM2Backup and Restore-HSM2Backup allowing to delete or restore a specified AWS CloudHSM backup.
  * Amazon CloudWatch
    * Added cmdlet Get-CWMetricWidgetImage which provides the ability to request png image snapshots of metric widgets.
  * Amazon Cognito Identity Provider
    * Updated cmdlet New-CGIPUserPoolDomain adding support for creating custom domains for our hosted UI for User Pools.
  * Amazon Directory Service
    * Added cmdlets New-DSLogSubscription, Remove-DSLogSubscription and Get-DSLogSubscriptionList. Customers can now opt in to have Windows security event logs from the domain controllers forwarded to a log group in their account.
  * Amazon DynamoDB
    * Added cmdlet Get-DDBEndpoint.
  * Amazon ElastiCache
    * Added cmdlets Request-ECReplicaCountDecrease and Request-ECReplicaCountIncrease which allow adding and removing read-replicas from any cluster with no cluster downtime.
  * Amazon Elemental MediaLive
    * Added cmdlets Update-EMLScheduleBatch and Get-EMLSchedule allowing scheduling actions for SCTE-35 message insertion and for static image overlays.
  * Amazon Elemental MediaPackage
    * Added cmdlet Invoke-EMPIngestEndpointCredentialRotation allowing to rotate the IngestEndpoint's username and password.
  * Amazon Glue
    * Added cmdlets New-GLUESecurityConfiguration, Remove-GLUESecurityConfiguration, Get-GLUESecurityConfiguration and Get-GLUESecurityConfigurationList for creating, updating, reading and deleting Data Catalog resource-based policies.
    * Updated cmdlets New-GLUECrawler, New-GLUEJob and New-GLUEDevEndpoint to allow specifying Encryption settings for Glue crawlers, ETL jobs, and development endpoints.
  * Amazon Rekognition
    * Added cmdlet Get-REKCollection allowing to get information about an existing face collection.
    * Updated cmdlet Add-REKDetectedFacesToCollection introducing a MaxFaces parameter and a QualityFilter parameter that allows you to automatically filter out detected faces that are deemed to be of low quality by Amazon Rekognition.
  * Amazon Relational Database Service
    * Added cmdlets Start-RDSDBCluster, Stop-RDSDBCluster. Stopping and starting Amazon Aurora clusters helps you manage costs for development and test environments. You can temporarily stop all the DB instances in your cluster, instead of setting up and tearing down all the DB instances each time that you use the cluster.
  * Amazon Systems Manager
    * Added cmdlets Get-SSMSession, Get-SSMConnectionStatus, Resume-SSMSession, Start-SSMSession and Stop-SSMSession. Session Manager is a fully managed AWS Systems Manager capability that provides interactive one-click access to Amazon EC2 Linux and Windows instances.
  * Amazon WAF
    * Added cmdlets Remove-WAFLoggingConfiguration, Get-WAFLoggingConfiguration, Get-WAFLoggingConfigurationList and Write-WAFLoggingConfiguration to provide access to all the logs of requests that are inspected by a WAF WebACL.
  * Amazon WAF Regional
    * Added cmdlets Remove-WAFRLoggingConfiguration, Get-WAFRLoggingConfiguration, Get-WAFRLoggingConfigurationList and Write-WAFRLoggingConfiguration to provide access to all the logs of requests that are inspected by a WAF WebACL.
  * Amazon X-Ray
    * Added cmdlets to support managing sampling rules

### 3.3.343.0 (2018-08-23)
  * Application Discovery Service
    * Added cmdlets to support the service's new Continuous Export APIs. Continuous Export APIs allow you to analyze your on-premises server inventory data, including system performance and network dependencies, in Amazon Athena. The new cmdlets are Get-ADSContinousExport (DescribeContinuousExports API), Start-ADSContinuousExport (StartContinuousExport API) and Stop-ADSContinuousExport (StopContinuousExport API).
  * Auto Scaling
    * Added cmdlets to support new batch operations for creating/updating and deleting scheduled scaling actions. The new cmdlets are Remove-ASScheduledActionBatch (BatchDeleteScheduledAction API) and Set-ASScheduledUpdateGroupActionBatch (BatchPutScheduledUpdateGroupAction API).
  * Amazon DynamoDB
    * Updated cmdlets to support new service features for modifying table Server-Side Encryption settings.
  * Amazon Redshift
    * Added cmdlet Set-RSClusterSize to support the new ResizeCluster API. With the new ResizeCluster action, your cluster is available for read and write operations within minutes.
  * Amazon SageMaker
    * Updated cmdlets to support new service feature allowing lifecycle configurations to be associated and disassociated.
  * AWS Device Farm
    * Added and updated cmdlets to support running tests in a custom environment with live logs/video streaming, full test features parity and reduction in overall test execution time. The new cmdlets are Stop-DFJob (StopJob API) and Update-DFUpload (UpdateUpload API).
  * AWS Elasticsearch
    *  Added support for no downtime, in-place upgrade for Elasticsearch version 5.1 and above. The new cmdlets are Get-ESCompatibleElasticsearchVersion (GetCompatibleElasticsearchVersions API), Get-ESUpgradeHistory (GetUpgradeHistory API), Get-ESUpgradeStatus (GetUpgradeStatus API) and Update-ESElasticsearchDomain (UpgradeElasticsearchDomain API).

### 3.3.335.0 (2018-08-13)
  * Amazon DynamoDB
    * Updated the Get-DDBBackupsList cmdlet with new parameter -BackupType to filter the returned backups.
  * Amazon DynamoDB Accelerator (DAX)
    * Updated New-DAXCluster cmdlet to support creation of clusters with server-side encryption.
  * Amazon EC2
    * Updated the New-EC2FlowLog cmdlet to support delivering flow logs directly to Amazon S3.
  * Amazon Pinpoint
    * Updated cmdlets to support updating endpoints.
    * Added Write-PINEvent (PutEvents API) cmdlet to support submission of events.
  * Amazon Relational Database Service
    * Added Edit-RDSCurrentDBClusterCapacity cmdlet, and updated others, to support the new ModifyCurrentDBClusterCapacity API for Aurora Serverless.
  * AWS CloudFormation
    * Fixed issue with missing parameters for ChangeSetType and RollbackConfiguration in New-CFNChangeSet cmdlet.
  * AWS CodeBuild
    * Updated cmdlets to support new service feature enabling semantic versioning.
  * AWS Secrets Manager
    * Updated the Remove-SECSecret cmdlet with parameter -DeleteWithNoRecovery. This enables forcing deletion of a secret without any recovery window and maps to the ForceDeleteWithoutRecovery property in the DeleteSecret API.
  * AWS Systems Manager
    * Updated the Start-SSMAutomationExecution cmdlet to support Automation Execution Rate Control based on tags and customized parameter maps. With Automation Execution Rate Control customers can target their resources by specifying a Tag with Key/Value. With customized parameter maps rate control customers can benefit from customization of input parameters.

### 3.3.330.0 (2018-08-06)
  * Amazon Comprehend
    * Updated and added cmdlets to support the new service ability to tokenize (find word boundaries) text and for each word provide a label for the part of speech, using the DetectSyntax operation. This API is useful to analyze text for specific conditions like for example finding nouns and the correlating adjectives to understand customer feedback. The new cmdlets are Find-COMPSyntax (DetectSyntax API) and Find-COMPSyntaxBatch (BatchDetectSyntax API).
  * Amazon DynamoDB
    * Updated the Update-DDBGlobalTableSetting cmdlet to add support for configuring AutoScaling settings for a DynamoDB global table.
  * Amazon EC2
    * Updated cmdlets to add support for two new allocation strategies for EC2/Spot customers -- LowestN for Spot instances, and OD priority for on-demand instances.
  * Amazon Kinesis
    * Updated and added cmdlets to support the new SubscribeToShard and RegisterStreamConsumer APIs which allows for retrieving records on a data stream over HTTP2 with enhanced fan-out capabilities. With this new feature the Java SDK now supports event streaming natively which will allow you to define payload and exception structures on the client over a persistent connection. For more information, see Developing Consumers with Enhanced Fan-Out in the Kinesis Developer Guide. The new cmdlets are Get-KINStreamConsumer (DescribeStreamConsumer API), Get-KINStreamConsumerList (ListStreamConsumers API), Register-KINStreamConsumer (RegisterStreamConsumer API) and Unregister-KINStreamConsumer (DeregisterStreamConsumer API).
  * Amazon MQ
    * Updated cmdlets to support integration with Amazon CloudWatch Logs.
  * Amazon Polly
    * Updated and added cmdlets to support asynchronous synthesis to Amazon S3. The new cmdlets are Get-POLSpeechSynthesisTask (GetSpeechSynthesisTask API), Get-POLSpeechSynthesisTaskList (ListSpeechSynthesisTasks API) and Start-POLSpeechSynthesisTask (StartSpeechSynthesisTask API).
  * Amazon Redshift
    * Updated and added cmdlets to support maintenance tracks. When we make a new version of Amazon Redshift available, we update your cluster during its maintenance window. By selecting a maintenance track, you control whether we update your cluster with the most recent approved release, or with the previous release. The two values for maintenance track are current and trailing. If you choose the current track, your cluster is updated with the latest approved release. If you choose the trailing track, your cluster is updated with the release that was approved previously. The new cmdlet is Get-RSClusterTrack (DescribeClusterTracks API).
  * Amazon S3
    * Added cmdlet Select-S3ObjectContent (SelectObjectContent API) to support Amazon S3 Select. Amazon S3 Select is an Amazon S3 feature that makes it easy to retrieve specific data from the contents of an object using simple SQL expressions without having to retrieve the entire object. With this release the S3 Select API is now generally available in all public regions and supports retrieval of a subset of data using SQL clauses, like SELECT and WHERE, from delimited text files and JSON objects.
  * Amazon SageMaker
    * Updated and added cmdlets to support the capability for customers to run fully-managed, high-throughput batch transform machine learning models with a simple API call. Batch Transform is ideal for high-throughput workloads and predictions in non-real-time scenarios where data is accumulated over a period of time for offline processing.
  * Amazon Transcribe
    * Updated the Start-TRSTranscribeJob cmdlet to support specifying an Amazon S3 output bucket to store the transcription of your audio file.
  * AWS AppStream
    * Updated and added cmdlets to support the new service feature enabling sharing AppStream images across AWS accounts within the same region. The new cmdlet are Get-APSImagePermission (DescribeImagePermissions API), Remove-APSImagePermission (DeleteImagePermission API) and Update-APSImagePermission (UpdateImagePermissions API).
  * AWS AppSync
    * Updated cmdlets to support configuring HTTP endpoints as data sources for your AWS AppSync GraphQL API.
  * AWS Cloud HSM V2
    * Updated and added cmdlets to support copy-backup-to-region, which allows you to copy a backup of a cluster from one region to another. The copied backup can be used in the destination region to create a new AWS CloudHSM cluster as a clone of the original cluster. The new cmdlet is Copy-HSM2BackupToRegion (CopyBackupToRegion API).
  * AWS CodeBuild
    * Updated cmdlets to support disabling encryption and specifying encryption key on build artifacts.
  * AWS Database Migration Service
    * Updated cmdlets to add support for DmsTransfer endpoint type and support for re-validate option in table reload API.
  * AWS Elastic File System
    * Updated and added cmdlets to support instant provisioning of the throughput required for your applications independent of the amount of data stored in your file system, allowing you to optimize throughput for your applications performance needs. The new cmdlet is Update-EFSFileSystem (UpdateFileSystem API).
  * AWS Glue
    * Updated cmdlets to support association of multiple SSH public keys with a development endpoints.
  * AWS Identity and Access Management
    * Updated and added cmdlets to support the IAM delegated administrator feature. This feature enables customers to attach permissions boundary to IAM principals. The IAM principals cannot operate exceeding the permission specified in permissions boundary. The new cmdlets for this feature are Set-IAMRolePermissionsBoundary (PutRolePermissionsBoundary), Set-IAMUserPermissionsBoundary (PutUserPermissionsBoundary API), Remove-IAMRolePermissionsBoundary (DeleteRolePermissionsBoundary API) and Remove-IAMUserPermissionsBoundary (DeleteUserPermissionsBoundary API).
  * AWS Import/Export Snowball
    * Updated and added cmdlets to support the availability of Amazon EC2 compute instances that run on the device. AWS Snowball Edge is a 100-TB ruggedized device built to transfer data into and out of AWS with optional support for local Lambda-based compute functions. With this feature, developers and administrators can run their EC2-based applications on the device providing them with an end to end vertically integrated AWS experience. Designed for data pre-processing, compression, machine learning, and data collection applications, these new instances, called SBE1 instances, feature 1.8 GHz Intel Xeon D processors up to 16 vCPUs, and 32 GB of memory. The SBE1 instance type is available in four sizes and multiple instances can be run on the device at the same time. Customers can now run compute instances using the same Amazon Machine Images (AMIs) that are used in Amazon EC2.
  * AWS IoT
    * Updated and added cmdlets to support the new IoT security service, AWS IoT Device Defender, and extending the capability of AWS IoT to support Step Functions rule action. The AWS IoT Device Defender is a fully managed service that helps you secure your fleet of IoT devices. For more details on this new service, go to https://aws.amazon.com/iot-device-defender. The Step Functions rule action lets you start an execution of AWS Step Functions state machine from a rule.
  * AWS Storage Gateway
    * Updated cmdlets to support creation of stored volumes using AWS KMS keys.
  * AWS Systems Manager
    * Updated and added cmdlets to support attaching labels to history parameter records and reference history parameter records via labels. It also adds Parameter Store integration with AWS Secrets Manager to allow referencing and retrieving AWS Secrets Manager's secrets from Parameter Store.
    * Updated and added cmdlets to support creation and use of service-linked roles to register and edit Maintenance Window tasks.

### 3.3.313.0 (2018-07-09)
  * Amazon Route 53 Auto Naming
    * Added support for the Amazon Route 53 Auto Naming service (Service Discovery). Amazon Route 53 auto naming lets you configure public or private namespaces that your microservice applications run in. When instances of the service become available, you can call the auto naming API to register the instance, and Route 53 automatically creates up to five DNS records and an optional health check. Clients that submit DNS queries for the service receive an answer that contains up to eight healthy records. Cmdlets for the service have the noun prefix SD and can be listed with the command *Get-AWSCmdletName -Service SD*.
  * Amazon CloudFront
    * [Breaking Change] The DeleteServiceLinkedRole api was released in error and has now been removed by the service. Accordingly the Remove-CFServiceLinkedRole cmdlet has been removed from the module. We apologize for any inconvenience caused.
  * Amazon EC2
    * Added parameter -CpuOption to the New-EC2Instance cmdlet to enable optimizing CPU options for your new instance(s). For more details see [Optimizing CPU Options](https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-optimize-cpu.html) in the Amazon EC2 User Guide.
    * Added revised examples for the Get-EC2ConsoleOutput and Grant-EC2SecurityGroupIngress cmdets based on user feedback.
  * Amazon Workpaces
    * Renamed the _-ResourceId_ parameter for the New-WKSTag and Get-WKSTag cmdlets to _-WorkspaceId_ to improve consistency with other Amazon Workspaces cmdlets. A backwards compatible alias of ResourceId has also been applied to this parameter to support existing scripts.
  * Amazon Relational Database Service
    * The name of the cmdlet _Get-RDSReservedDBInstancesOffering_, which maps to the service API _PurchaseReservedDBInstancesOffering_, has been corrected to _New-RDSReservedDBInstancesOfferingPurchase_. The Get verb had been applied incorrectly as this cmdlet/API actually performs a purchase and does not simply return information. An alias for the old name has been included in the module for backwards compatibility but we encourage users of this cmdlet to adopt the new name at their earliest convenience.
    * Updated cmdlets to support new service feature enabling users to specify the retention period for Performance Insights data for RDS instances. You can either choose 7 days (default) or 731 days.
  * Amazon Comprehend
    * Updated cmdlets to support new service feature enabling batch processing of a set of documents stored within an S3 bucket.
  * Amazon ECS
    * Updated cmdlets to support new service feature enabling daemon scheduling capability to deploy one task per instance on selected instances in a cluster.
    * Added parameter _-Enforce_ flag to the Remove-ECSService cmdlet to allow deleting a service without requiring to scale down the number of tasks to zero. This parameter maps to the _Force_ value in the underlying DeleteService API.
  * Amazon Inspector
    * Added cmdlets to support new service feature for viewing and previewing exclusions. Exclusions show which intended security checks are excluded from an assessment, along with reasons and recommendations to fix.
  * Amazon Pinpoint
    * Updated cmdlets to support new service features for creating complex segments and validating phone numbers for SMS messages. It also adds the ability to get or delete endpoints based on user IDs, remove attributes from endpoints, and list the defined channels for an app.
  * Amazon Redshift
    * Updated cmdlets to support new service features. (1) On-demand cluster release version: When Amazon Redshift releases a new cluster version, you can choose to upgrade to that version immediately instead of waiting until your next maintenance window. You can also choose to roll back to a previous version. (2) Upgradeable reserved instance - You can now exchange one Reserved Instance for a new Reserved Instance with no changes to the terms of your existing Reserved Instance (term, payment type, or number of nodes).
  * Amazon SageMaker
    * Added support for Notebook instances and the ability to run hyperparameter tuning jobs. A hyperparameter tuning job will create and evaluate multiple training jobs while tuning algorithm hyperparameters, to optimize a customer specified objective metric.
  * AWS Secrets Manager
    * Updated cmdlets to support new service feature for esource-based policies that attach directly to your secrets. These policies provide an additional way to control who can access your secrets and what they can do with them. For more information, see https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access_resource-based-policies.html in the Secrets Manager User Guide.
  * AWS Shield
    * Added support for DDoS Response Team access management.
  * AWS Storage Gateway
    * Updated cmdlets to support new service features for using Server Message Block (SMB) protocol to store and access objects in Amazon Simple Storage Service (S3).
  * AWS CloudFormation
    * Updated the New-CFNStackSet and Update-CFNStack set with parameters to support filtered updates for StackSets based on accounts and regions (this feature will allow flexibility for the customers to roll out updates on a StackSet based on specific accounts and regions) and to support customized ExecutionRoleName (this feature will allow customers to attach ExecutionRoleName to the StackSet thus ensuring more security and controlling the behavior of any AWS resources in the target accounts).
  * AWS IoT
    * Added cmdlets to support new APIs released by the service: Remove-IOTJob (DeleteJob API) and Remove-IOTJobExecution (DeleteJobExecution API).
    * Updated the Stop-IOTJob cmdlet to support forced cancellation.
    * Added cmdlet Stop-IOTJobExecution (CancelJobExecution API).
  * AWS Systems Manager
    * Added example for the New-SSMAssociation cmdlet.
    * Updated cmdlets to support new service features around sending RunCommand output to CloudWatch Logs, add the ability to view association execution history and execute an association.
  * AWS AppStream
    * Updated cmdlets to support new service feature enabling customers to find their VPC private IP address and ENI ID associated with AppStream streaming sessions.
  * AWS Certificate Manager Private Certificate Authority
    * Updated cmdlets to support new service 'Restore' feature, enabling users to restore a private certificate authority that has been deleted. When you use the Remove-PCACertificateAuthority cmdlet, you can now specify the number of days (7-30, with 30 being the default) in which the private certificate authority will remain in the DELETED state. During this time, the private certificate authority can be restored with the new Restore-PCACertificateAuthority (RestoreCertificateAuthority API) cmdlet and then be returned to the PENDING_CERTIFICATE or DISABLED state, depending upon the state prior to deletion.
  * AWS Cloud Directory
    * Updated cmdlets to support new service 'Flexible Schema' feature. This feature lets customers using new capabilities like: variant typed attributes, dynamic facets and AWS managed Cloud Directory schemas.
  * AWS Glue
    * Updated cmdlets to support new service feature for sending delay notification to Amazon CloudWatch Events when an ETL job runs longer than the specified delay notification threshold.
  * AWS Elemental MediaLive
    * Added and updated cmdlets to support new service features for reserved inputs and outputs. You can reserve inputs and outputs with a 12 month commitment in exchange for discounted hourly rates. Pricing is available at https://aws.amazon.com/medialive/pricing/.
  * AWS Elemental MediaConvert
    * Added cmdlets to support tagging queues, presets, and templates during creation of those resources on MediaConvert.
  * AWS Config
    * Updated cmdlets to support new service feature for retention, allowing you to specify a retention period for your AWS Config configuration items.
  * AWS Directory Service
    * Added cmdlet Reset-DSUserPassword (ResetUserPassword API). Customers can now reset their users' passwords without providing the old passwords in Simple AD and Microsoft AD.

### 3.3.283.0 (2018-05-18)
  * AWS Service Catalog
    * Users can now pass a new option to Get-SCAcceptedPortfolioSharesList called PortfolioShareType with a value of AWS_SERVICECATALOG in order to access Getting Started Portfolios that contain selected products representing common customer use cases.
  * Alexa for Business
    * Added operations for creating and managing address books of phone contacts for use in A4B managed shared devices.
    * Added Get-ALXBDeviceEventList to paginated list of device events (such as ConnectionStatus).
    * Added ConnectionStatus param to Find-ALXBDevice and Start-ALXBDeviceSync.
    * Added new Device status "DEREGISTERED". This release also adds DEVICE_STATUS as the new DeviceEventType.
  * AWS Certificate Manager
    * Updated documentation notes to
      * Replace incorrect userguide links in Add-ACMCertificateTag, Import-ACMCertificate, New-ACMCertificate, Send-ACMValidationEmail and Update-ACMCertificateOption with the correct links.
      * Added comments in Export-ACMCertificate detailing the issuer of a private certificate as the Private Certificate Authority (CA).
  * AWS CodeBuild
    * Added support for more override fields such as CertificateOverride, EnvironmentTypeOverride for Start-CBBuild
    * Added support for idempotency token field (IdempotencyToken) for Start-CBBuild
  * AWS CodePipeline
    * Added new cmdlets to support webhooks in AWS CodePipeline. A webhook is an HTTP notification that detects events in another tool, such as a GitHub repository, and connects those external events to a pipeline. AWS CodePipeline creates a webhook when you use the console to create or edit your GitHub pipeline and deletes your webhook when you delete your pipeline.
  * Amazon DynamoDB
    * Adds two new cmdlets Get-DDBGlobalTableSetting and Update-DDBGlobalTableSetting to get region specific settings for a global table and update settings for a global table respectively. This update introduces new constraints in the New-DDBGlobalTable and Update-DDBGlobalTable. Tables must have the same write capacity units. If Global Secondary Indexes exist then they must have the same write capacity units and key schema.
  * Amazon EC2
    * Added EC2 Fleet cmdlets. Amazon EC2 Fleet is a new feature that simplifies the provisioning of Amazon EC2 capacity across different EC2 instance types, Availability Zones, and the On-Demand, Reserved Instance, and Spot Instance purchase models. With a single call, you can now provision capacity to achieve desired scale, performance, and cost.
  * Amazon Elasticsearch
    * Added Get-ESReservedElasticsearchInstanceList, Get-ESReservedElasticsearchInstanceOfferingList and New-ESReservedElasticsearchInstanceOffering to support Reserved Instances on AWS Elasticsearch.
  * Amazon GameLift
    * AutoScaling Target Tracking scaling simplification along with Start-GMLFleetAction and Stop-GMLFleetAction to suspend and resume automatic scaling at will.
  * Amazon Guard Duty
    * Added new cmdlets for Amazon GuardDuty for creating and managing filters. For each filter, you can specify a criteria and an action. The action you specify is applied to findings that match the specified criteria.
  * Amazon Kinesis Firehose
    * With this release, Amazon Kinesis Data Firehose can convert the format of your input data from JSON to Apache Parquet or Apache ORC before storing the data in Amazon S3. Parquet and ORC are columnar data formats that save space and enable faster queries compared to row-oriented formats like JSON.
  * AWS Organizations
    * Documentation updates for organizations
  * Amazon Relational Database Service
    * Changes to support the Aurora MySQL Backtrack feature. Cmdlets added are Reset-RDSDBCluster and Get-RDSDBClusterBacktrackList
    * Correction to the documentation about copying unencrypted snapshots.
  * Amazon Route53 Domains
    * This release adds a SubmittedSince attribute to Get-R53DOperationList, so you can list operations that were submitted after a specified date and time.
  * Amazon SageMaker
    * SageMaker has added support for VPC configuration for both Endpoints and Training Jobs. This allows you to connect from the instances running the Endpoint or Training Job to your VPC and any resources reachable in the VPC rather than being restricted to resources that were internet accessible.
  * AWS Secrets Manager
    * Documentation updates for Secret Manager
  * Amazon Simple Systems Management
    * Added support for new parameter, DocumentVersion, for Send-SSMCommand. Users can now specify version of SSM document to be executed on the target(s).
  * Amazon WorkSpaces
    * Added new IP Access Control cmdlets. You can now create/delete IP Access Control Groups, add/delete/update rules for IP Access Control Groups, Associate/Disassociate IP Access Control Groups to/from a WorkSpaces Directory, and Describe IP Based Access Control Groups.
    * Added cmdlet Edit-WKSWorkspaceState to change the state of a Workspace, and the ADMIN_MAINTENANCE WorkSpace state.

### 3.3.270.0 (2018-04-25)
  * The CmdletsToExport property in the module manifest has been temporarily set to '*-*' instead of the individual cmdlet names to work around a limitation publishing modules that contain over 4000 cmdlets to the PowerShell Gallery. The net effect of this change is to disable tab completion for cmdlet names unless the module is explicitly imported. We are investigating approaches to work around or fix this issue and will re-instate the list of cmdlets as soon as possible.
  * AWS Secrets Manager
    * Added cmdlets to support the new AWS Secrets Manager service that enables you to store, manage, and retrieve, secrets. Cmdlets for the service have the noun prefix SEC and can be listed with the command *Get-AWSCmdletName -Service SEC*.
  * AWS Certificate Manager Private Certificate Authority
    * Added cmdlets to support the new AWS Certificate Manager (ACM) Private Certificate Authority (CA), a managed private CA service that helps you easily and securely manage the lifecycle of your private certificates. ACM Private CA provides you a highly-available private CA service without the upfront investment and ongoing maintenance costs of operating your own private CA. ACM Private CA extends ACM's certificate management capabilities to private certificates, enabling you to manage public and private certificates centrally. Cmdlets for the service have the noun prefix PCA and can be listed with the command *Get-AWSCmdletName -Service PCA*.
  * Firewall Management Service
    * Added cmdlets to support the Firewall Management Service, a new AWS service that makes it easy for customers to centrally configure WAF rules across all their resources (ALBs and CloudFront distributions) and across accounts. Cmdlets for the service have the noun prefix FMS and can be listed with the command *Get-AWSCmdletName -Service FMS*.
  * AWS Certificate Manager
    * Updated the New-ACMCertificate and added new cmdlet Update-ACMCertificateOption (UpdateCertificateOption API) to support disabling Certificate Transparency logging on a per-certificate basis.
    * Added support for new service features for requesting and exporting private certificates. This API enables you to collect batch amounts of metric data and optionally perform math expressions on the data. With one GetMetricData call you can retrieve as many as 100 different metrics and a total of 100,800 data points.
  * Amazon CloudWatch
    * Added cmdlet Get-CWMetricData to support the new GetMetricData API.
  * Amazon DynamoDB
    * Added cmdlets restore-DDBTableToPointInTime (RestoreTableToPointInTime API) and Update-DDBContinuousBackup (UpdateContinuousBackups API) t o support Point-in-time recovery (PITR) continuous backups of your DynamoDB table data. With PITR, you do not have to worry about creating, maintaining, or scheduling backups. You enable PITR on your table and your backup is available for restore at any point in time from the moment you enable it, up to a maximum of the 35 preceding days. PITR provides continuous backups until you explicitly disable it.
  * AWS Identity and Access Management
    * Updated the New-IAMRole cmdlet with parameter -MaxSessionDuration, and added cmdlet Update-IAMRole (UpdateRole API) to support the new longer role sessions.
  * AWS Cloudwatch Logs
    * Fixed bad links to the service API references in the help details for the service's cmdlets.
  * Amazon Inspector
    * Fixed bad links to the service API references in the help details for the service's cmdlets.
  * Alexa for Business
    * Added cmdlets to support new operations related to creating and managing address books of contacts for use in A4B managed shared devices.
  * AWS CloudFormation
    * Updated cmdlets to support use of a customized AdministrationRole to create security boundaries between different users.
  * Amazon CloudFront
    * Added cmdlets to support Field-Level Encryption to further enhance the security of sensitive data, such as credit card numbers or personally identifiable information (PII) like social security numbers. CloudFront's field-level encryption further encrypts sensitive data in an HTTPS form using field-specific encryption keys (which you supply) before a POST request is forwarded to your origin. This ensures that sensitive data can only be decrypted and viewed by certain components or services in your application stack. Field-level encryption is easy to setup. Simply configure the fields that have to be further encrypted by CloudFront using the public keys you specify and you can reduce attack surface for your sensitive data.
  * Amazon Elasticsearch
    * Updated cmdlets to support Amazon Cognito authentication support to Kibana.
  * AWS Config Service
    * Added support for multi-account multi-region data aggregation features. Customers can create an aggregator (a new resource type) in AWS Config that collects AWS Config data from multiple source accounts and regions into an aggregator account. Customers can aggregate data from individual account(s) or an organization and multiple regions. In this release, AWS Config adds several API's for multi-account multi-region data aggregation.
  * AWS Device Farm
    * Added support for Private Device Management feature. Customers can now manage their private devices efficiently - view their status, set labels and apply profiles on them. Customers can also schedule automated tests and remote access sessions on individual instances in their private device fleet.
    * Added cmdlets to support new service features for VPC endpoints.
  * Amazon WorkMail
    * Added cmdlets to support granting users and groups with "Full Access", "Send As" and "Send on Behalf" permissions on a given mailbox.
  * AWS Glue
    * Updated cmdlets to support timeout values for ETL jobs. With this release, all new ETL jobs have a default timeout value of 48 hours. AWS Glue also now supports the ability to start a schedule or job events trigger when it is created.
  * Amazon Cloud Directory
    * Added cmdlets to support new APIs to fetch attributes within a facet on an object or multiple facets or objects.
  * AWS Batch
    * Added support for specifying timeout when submitting jobs or registering job definitions.
  * AWS Systems Manager
    * Added cmdlets Get-SSMInventoryDeletionList (DescribeInventoryDeletions API) and Remove-SSMInventory (DeleteInventory API).
  * AWS X-Ray
    * Added cmdlets Get-XREncryptionConfig (GetEncryptionConfig API) and Write-XREncryptionConfig (PutEncryptionConfig API) to support managing data encryption settings. Use Write-XREncryptionConfig to configure X-Ray to use an AWS Key Management Service customer master key to encrypt trace data at rest.

### 3.3.253.0 (2018-03-26)
  * Amazon WorkMail
    * Added cmdlets to support the Amazon WorkMail service. Cmdlets for the service have the noun prefix WM and can be listed with the command *Get-AWSCmdletName -Service WM*.
  * Amazon Pinpoint
    * Added cmdlets to support the new service feature enabling endpoint exports from your Amazon Pinpoint projects. The new cmdlets are Get-PINExportJobList (GetExportJobs API), Get-PINSegmentExportJobList (GetSegmentExportJobs API) and New-PINExportJob (CreateExportJob API).
    * Added cmdlet Remove-PINEndpoint to support the new DeleteEndpoint API.
  * Amazon SageMaker
    * Added cmdlets to support the new customizable notebook instance lifecycle configuration APIs. The new cmdlets are Get-SMNotebookInstanceLifecycleConfig (DescribeNotebookInstanceLifecycleConfig API), Get-SMNotebookInstanceLifecycleConfig (ListNotebookInstanceLifecycleConfigs API), New-SMNotebookInstanceLifecycleConfig (CreateNotebookInstanceLifecycleConfig API), Remove-SMNotebookInstanceLifecycleConfig (DeleteNotebookInstanceLifecycleConfig API) and Update-SMNotebookInstanceLifecycleConfig (UpdateNotebookInstanceLifecycleConfig API).
  * AWS Elastic Beanstalk
    * Added new cmdlet Get-EBAccountAttribute to support the new DescribeAccountAttributes API. In this release the API will support quotas for resources such as applications, application versions, and environments.

### 3.3.245.0 (2018-03-02)
  * AWS AppStream
    * Added cmdlet Copy-APSImage to support the new CopyImage API. This API enables customers to copy their Amazon AppStream 2.0 images within and between AWS Regions.
  * Auto Scaling
    * Updated the New-ASAutoScalingGroup and Update-ASAutoScalingGroup cmdlets with a new parameter, -ServiceLinkedRoleARN, to support service linked roles.
  * AWS CodeCommit
    * Added cmdlet Write-CFFile to support the new PutFile API. This API enables customers to add a file directly to an AWS CodeCommit repository without requiring a Git client.
  * AWS Cost Explorer
    * Added cmdlet Get-CEReservationCoverage to support the new GetReservationCoverage API.
  * Amazon EC2
    * Updated the New-EC2Snapshot cmdlet to add suport for tagging EBS snapshots.
  * Serverless Application Repository
    * Updated the New-SARApplication and Update-SARApplication cmdlets to support setting a home page URL for the application.
    * Added cmdlet Remove-SARApplication to support the new DeleteApplication API.
  * AWS WAF
    * Added cmdlets Get-WAFPermissionPolicy (GetPermissionPolicy API) and Remove-WAFPermissionPolicy (DeletePermissionPolicy API).
  * AWS WAF Regional
    * Added cmdlets Get-WAFRPermissionPolicy (GetPermissionPolicy API) and Remove-WAFRPermissionPolicy (DeletePermissionPolicy API).
  * AWS Service Catalog
    * Added cmdlet Remove-SCTagOption to support the new DeleteTagOption API.
  * AWS Storage Gateway
    * Updated the New-SGNFSFileShare and Update-SGNFSFileShare cmdlets to support new service features for file share attributes. Users can now specify the S3 Canned ACL to use for new objects created in the file share and create file shares for requester-pays buckets.

### 3.3.234.0 (2018-02-14)
  (This version was only released as part of the combined AWS Tools for Windows installer. It was not released to the PowerShell Gallery.)
  * AWS AppSync
    * Added cmdlet Update-ASYNApiKey to support the new UpdateApiKey API.
  * Amazon Lex Model Builder Service
    * Added cmdlets Get-LMBImport (GetImport API) and Start-LMBImport (StartImport API) to support the new to export and import your Amazon Lex chatbot definition as a JSON file.

### 3.3.232.0 (2018-02-13)
  * AWS Lambda
    * [Breaking Change] The response data from the service's GetPolicy API has been extended to emit both the policy and revision ID of the policy. The output from the corresponding Get-LMPolicy cmdlet has therefore been changed to emit the service response to the pipeline. To keep the original behavior your scripts need to be changed to use _(Get-LMPolicy).Policy_ in place of _Get-LMPolicy_.
    * Updated the Add-LMPermission, Publish-LMVersion, Remove-LMPermission, Update-LMAlias and Update-LMFunctionConfiguration cmdlets to support setting Revision ID on your function versions and aliases, to track and apply conditional updates when you are updating your function version or alias resources.
  * AWS Key Management Service.
    * [Breaking Change] The cmdlet for the service's ListKeyPolicies API had been named in error as Get-KMSKysPolicyList due to a typo. This has now been corrected and the cmdlet name updated to Get-KMSKeyPolicyList.
  * AWS CodeBuild
    * Added new parameters to the Start-CBBuild and Update-CBProject cmdlets to support shallow clone and GitHub Enterprise.
  * AWS Device Farm
    * Updated the New-DFRemoteAccessSession cmdlet to support the service's new InteractionMode setting for the DirectDeviceAccess feature.
  * AWS Elemental MediaLive
    * Updated the New-EMLChannel cmdlet to support the new InputSpecification settings (specification of input attributes is used for channel sizing and affects pricing).
  * Amazon CloudFront
    * Updated the Get-CFCloudFrontOriginAccessIdentityList, Get-CFDistributionList, Get-CFDistributionListByWebACLId, Get-CFInvalidationList and Get-CFStreamDistributionList cmdlets to support automatic pagination of result output. The cmdlets will now make repeated calls to obtain all available data and no longer require users to implement their own pagination logic in scripts or at the command line.
  * Amazon Kinesis
    * Added new cmdlet Get-KINShardList to support the new ListShards service API. Using ListShards a Kinesis Data Streams customer or client can get information about shards in a data stream (including meta-data for each shard) without obtaining data stream level information.
  * AWS OpsWorks
    * Added new cmdlet Get-OPSOperatingSystem to support the new DescribeOperatingSystems API.
  * AWS Glue
    * Added parameters to the New-GLUClassifier and Update-GLUEClassifier cmdlets to support specifying the json paths for customized classifiers. The custom path indicates the object, array or field of the json documents the user would like crawlers to inspect when they crawl json files.
  * AWS Service Catalog
    * [Breaking Change] The response data from the service's DescribeProvisionedProduct api has been changed to emit additional data. The output from the corresponding Get-SCProvisionedProduct cmdlet has therefore been changed to now emit the full service response to the pipeline. To keep the original behavior your scriprs need to be changed to use _(Get-SCProvisionedProduct).ProvisionedProductDetail_ in place of _Get-SCProvisionedProduct_.
    * Added cmdlets to support new APIs: Find-SCProvisionedProduct (SearchProvisionedProduct API), Get-SCProvisionedProductPlan (DescribeProvisionedPlan API), Get-SCProvisionedPlanList (ListProvisionedproductPlans API), New-SCProvisionedproductPlan (CreateProvisionedproductPlan API), Remove-SCProvisionedProductPlan (DeleteProvisionedProductPlan API) and Start-SCProvisionedProductPlanExecution (ExecuteProvisionedProductPlan API).
    * Amazon Systems Manager
      * Updated cmdlets with parameters to support Patch Manager enhancements for configuring Linux repos as part of patch baselines, controlling updates of non-OS security packages and also creating patch baselines for SUSE12.
      * Updated service name in cmdlet help documentation.
  * Amazon AppStream
      * Added parameter -RedirectURL to the New-APSStack and Update-APSStack cmdlets enabling a redirect url to be provided for a stack. Users will be redirected to the link provided by the admin at the end of their streaming session. Update-APSStack also now supports a new parameter enabling attributes to be deleted from a stack.
  * AWS Database Migration Service
    * Added cmdlets to support new APIs for replication instance task logs and rebooting instances. Replication instance task logs allows users to see how much storage each log for a task on a given instance is occupying. The reboot API gives users the option to reboot the application software on the instance and force a fail over for MAZ instances to test robustness of their integration with our service. The new cmdlets are Get-DMSReplicationInstanceTaskLog (DescribeReplicationInstanceTaskLogs API) and Restart-DMSReplicationInstance (RebootReplicationInstance API).
  * Amazon EC2
    * Added cmdlets for new APIs to support determining the longer ID opt-in status of their account. The new cmdlets are Get-EC2AggregatedIdFormat (DescribeAggregatedIdFormat API) and Get-EC2PrincipalIdFormat (DescribePrincipalIdFormat API).
  * Amazon GameLift
    * Added cmdlet Start-GMLMatchBackfill to support the new StartMatchBackfill API. This API allows developers to add new players to an existing game session using the same matchmaking rules and player data that were used to initially create the session.
  * AWS Elemental Media Live
    * Added cmdlet Update-EMLChannel to support the new UpdateChannel API. For idle channels you can now update channel name, channel outputs and output destinations, encoder settings, user role ARN, and input specifications. Channel settings can be updated in the console or with API calls. Please note that running channels need to be stopped before they can be updated. We've also deprecated the 'Reserved' field.
  * AWS Elemental Media Store
    * Added cmdlets Get-EMSCorsPolicy (GetCorsPolicy API), Write-EMSCorsPolicy (PutCorsPolicy API) and Remove-EMSCorsPolicy (DeleteCorsPolicy API) to support per-container CORS configuration.
  * Amazon Cognito Identity Provider
    * Added cmdlet Get-CGIPSigningCertificate to support the new  GetSigningCertificate API.
    * Updated the New-CGIPUserPool and Update-CGIPUserPool cmdlets to support user migration using an AWS Lambda trigger.

### 3.3.225.1 (2018-01-24)
  * Amazon Guard Duty
    * Fixed issue with error 'The request is rejected because an invalid or out-of-range value is specified as an input parameter' being emitted when running cmdlets that map to service apis that support pagination (eg Get-GDDetectorList).

### 3.3.225.0 (2018-01-23)
  * Amazon Transcribe
    * Added cmdlets to support the public preview release of the new Amazon Transcribe service. Cmdlets for the service have the noun prefix TRS and can be listed with the command *Get-AWSCmdletName -Service TRS*.
  * AWS Glue
    * Added cmdlets to support the AWS Glue service. Cmdlets for the service have the noun prefix GLUE and can be listed with the command *Get-AWSCmdletName -Service GLUE*.
  * AWS Cloud9
    * Added examples for all Cloud9 cmdlets.
  * Amazon Relational Database Service
    * Updated the Edit-RDSDBInstance, New-RDSDBInstance, New-RDSDBInstanceReadReplica, Restore-RDSDBInstanceFromDBSnapshot, Restore-RDSDBInstanceFromS3 and Restore-RDSDBInstanceToPointInTime cmdlets with new parameters to support integration with CloudWatch Logs.
  * Amazon SageMaker Service
    * Updated the New-SMEndpointConfig cmdlet with support for specifying a KMS key for volume encryption.
  * AWS Budgets
    * Updated the New-BGTBudget and Update-BGTBudget cmdlets to support additional cost types (IncludeDiscount and UseAmortized) to support finer control for different charges included in a cost budget.

### 3.3.221.0 (2018-01-15)
  * Amazon S3
    * Fixed issue with the Copy-S3Object displaying an error when copying objects between buckets and the object keys started with the '/' character.
  * AWS Lambda
    * Updated cmdlets and argument completers to support the newly released dotnetcore2.0 and go1.x runtimes for Lamba functions.

### 3.3.219.0 (2018-01-12)
  * Amazon EC2
    * Updated the Get-EC2Snapshot and Get-EC2Volume cmdlets to use pagination to process data when a snapshot id or volume id is not supplied. This update should help customers with large numbers of snapshots or volumes who were experiencing timeout issues in previous versions which attempted to use a single call to obtain all data.
    * Added support for pipelining the output launch template object types returned by the the New-EC2LaunchTemplate and New-EC2LaunchTemplateVersion into the same cmdlets, and also into the New-EC2Instance cmdlet.
    * Updated the Get-EC2PasswordData cmdlet to display better error message if used to obtain password before the instance is ready.
  * Get-AWSRegion
    * Updated documentation notes and examples to address confusion as to how this cmdlet handles regions launched after the module is released. The cmdlet uses built-in data to display the list of regions, so won't show new regions launched subsequently, but those new regions can still be used with all cmdlets without requiring an update to the tools.
  * AWS CodeDeploy
    * Added cmdlet Remove-CDGitHubAccountToken to support the new DeleteGitHubAccountToken API.
  * AWS Directory Service
    * Updated the New-DSMicrosoftAD cmdlet to add support for an -Edition parameter. The service now supports Standard and Enterprise (the default) editions of Microsoft Active Directory. Microsoft Active Directory (Standard Edition), also known as AWS Microsoft AD (Standard Edition), is a managed Microsoft Active Directory (AD) that is optimized for small and midsize businesses (SMBs). With this SDK release, you can now create an AWS Microsoft AD directory using API. This enables you to run typical SMB workloads using a cost-effective, highly available, and managed Microsoft AD in the AWS Cloud.
  * Amazon Relational Database Service
    * Updated the New-RDSDBInstanceReadReplica cmdlet with support for Multi AZ deployments.

### 3.3.215.0 (2018-01-02)
  * Amazon API Gateway
    * Added support for tagging resources for cost allocation with new cmdlets Add-AGResourceTag (TagResource API), Get-AGResourceTag (GetTags API) and Remove-AGResourceTag (UntagResource API). The New-AGStage cmdlet was also updated with a new -Tag parameter.
    * Updated the New-AGRestApi cmdlet with parameters to support setting minimum compression size and returning API keys from a custom authorizer for use with a usage plan.
  * Amazon ECS
    * Updated the New-ECSService and Update-ECSService cmdlets to support the new service feature enabling a grace period for health checks to be specified.
  * AWS IoT
    * Added cmdlets to support the new service feature for code signed Over-the-air update functionality for Amazon FreeRTOS. Users can now create and schedule Over-the-air updates to their Amazon FreeRTOS devices using these new APIs.
  * Amazon Kinesis Analytics
    * Updated the Add-KINAApplicationOutput cmdlet to support the new service feature enabling AWS Lambda functions as output.
  * Amazon SageMaker Service
    * *BREAKING CHANGE* The -SupplementalContainer parameter for the New-SMModel cmdlet has been removed as it is no longer supported by the service.
  * Amazon WorkSpaces
    * Updated the Edit-WKSWorkspaceProperty cmdlet to support new service features for flexible storage and switching of hardware bundles.
