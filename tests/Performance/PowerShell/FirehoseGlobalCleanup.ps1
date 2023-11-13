param($DeliveryStreamName, $S3BucketName, $RoleName, $PolicyName)
Import-Module "AWS.Tools.Common", "AWS.Tools.S3", "AWS.Tools.IdentityManagement", "AWS.Tools.KinesisFirehose"

Remove-KINFDeliveryStream -AllowForceDelete $true -DeliveryStreamName $DeliveryStreamName -Force

$iamPolicy = Get-IAMPolicyList -OnlyAttached $true -Scope Local | Where-Object {$_.PolicyName -eq $PolicyName}

Unregister-IAMRolePolicy -PolicyArn $iampolicy.Arn -RoleName $RoleName

Remove-IAMPolicy -PolicyArn $iampolicy.Arn -Force

Remove-IAMRole -RoleName $RoleName -Force

$bucket = Remove-S3Bucket -BucketName $S3BucketName -Force
