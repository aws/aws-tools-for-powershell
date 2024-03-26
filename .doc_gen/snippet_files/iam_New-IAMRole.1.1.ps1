$results = New-IAMRole -AssumeRolePolicyDocument (Get-Content -raw NewRoleTrustPolicy.json) -RoleName MyNewRole
$results