param($RoleName)
#Create Role that can be assumed as part of Performance Tests
Import-Module 'AWS.Tools.Common', 'AWS.Tools.SecurityToken', 'AWS.Tools.IdentityManagement'
$caller = Get-STSCallerIdentity

$assumeRolePolicyDocument = '{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Principal": {
                "AWS": [
                    "'+ $caller.Arn + '"
                ]
            },
            "Action": [
                "sts:AssumeRole",
                "sts:TagSession"
            ],
            "Condition": {}
        }
    ]
}'

$role = New-IAMRole -RoleName $RoleName -AssumeRolePolicyDocument $assumeRolePolicyDocument
# Even though the IAM Role is created fast, Assuming a Role seems to take some time.
# Try Assuming Role until timeout of 300 seconds
$timeoutSeconds = 300
$sleepSeconds = 10
$totalIterations = $timeoutSeconds / $sleepSeconds
$i = 0
$assumeRoleSuccessful = $false
while (-not $assumeRoleSuccessful) {
    try {
        $stsAssumeRole = Use-STSRole -RoleSessionName (New-Guid).Guid -RoleArn $role.Arn -DurationInSeconds 900
        $assumeRoleSuccessful = $true
    }
    catch {
    }
    Start-Sleep -Seconds $sleepSeconds
    $i++
    if ($i -eq $totalIterations) {
        throw "timed out ($timeoutSeconds) waiting for DeliverStream Status to be ACTIVE"
    }
}