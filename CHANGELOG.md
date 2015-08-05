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