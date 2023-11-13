param($DeliveryStreamName, $S3BucketName, $RoleName, $PolicyName)
Import-Module 'AWS.Tools.Common', 'AWS.Tools.S3', 'AWS.Tools.IdentityManagement', 'AWS.Tools.KinesisFirehose'
$fireHoseFound = $true
try {
    $fireHose = Get-KINFDeliveryStream -DeliveryStreamName $DeliveryStreamName
}
catch {
    $fireHoseFound = $false
}

$bucket = New-S3Bucket -BucketName $S3BucketName
if ($fireHoseFound) {
    return
}
$assumeRolePolicyDocument = '{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Principal": {
                "Service": "firehose.amazonaws.com"
            },
            "Action": "sts:AssumeRole"
        }
    ]
}'
$policyDocument = '{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Action": [
                "s3:AbortMultipartUpload",
                "s3:GetBucketLocation",
                "s3:GetObject",
                "s3:ListBucket",
                "s3:ListBucketMultipartUploads",
                "s3:PutObject"
            ],
            "Resource": [
                "arn:aws:s3:::'+ $S3BucketName + '",
                "arn:aws:s3:::'+ $S3BucketName + '/*"
            ],
            "Effect": "Allow"
        }
    ]
}'
$role = New-IAMRole -RoleName $RoleName -AssumeRolePolicyDocument $assumeRolePolicyDocument

$iamPolicy = New-IAMPolicy -PolicyDocument $policyDocument -PolicyName $PolicyName
Register-IAMRolePolicy -PolicyArn $iampolicy.Arn -RoleName $role.RoleName

$s3config = [Amazon.KinesisFirehose.Model.S3DestinationConfiguration]::new()
$s3config.BucketARN = "arn:aws:s3:::$S3BucketName"
$s3config.RoleARN = $role.Arn

Write-Host "DeliveryStreamName $DeliveryStreamName s3config.BucketARN $($s3config.BucketARN) s3config.RoleARN $($s3config.RoleARN)"
Write-Host "Wait for IAM Role to propagate"
Start-Sleep -Seconds 15
New-KINFDeliveryStream -DeliveryStreamName $DeliveryStreamName -DeliveryStreamType DirectPut -S3DestinationConfiguration $s3config

Write-Host "Wait before checking for DeliveryStreamStatus"
Start-Sleep -Seconds 15

# timeout after 5 minutes
$timeoutSeconds = 300
$sleepSeconds = 10
$totalIterations = $timeoutSeconds / $sleepSeconds
$i = 0
while ((get-kINFDeliveryStream -DeliveryStreamName $DeliveryStreamName).DeliveryStreamStatus -ne 'ACTIVE') {
    Start-Sleep -Seconds $sleepSeconds
    $i++
    if ($i -eq $totalIterations) {
        throw "timed out ($timeoutSeconds) waiting for DeliverStream Status to be ACTIVE"
    }
}