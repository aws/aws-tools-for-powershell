param($RoleName)

$role = Get-IAMRole -RoleName $RoleName
$stsAssumeRole = Use-STSRole -RoleSessionName (New-Guid).Guid -RoleArn $role.Arn -DurationInSeconds 900