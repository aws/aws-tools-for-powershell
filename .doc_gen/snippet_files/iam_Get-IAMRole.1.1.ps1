$results = Get-IamRole -RoleName lambda_exec_role
$results | Format-List