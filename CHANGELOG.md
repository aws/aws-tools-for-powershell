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