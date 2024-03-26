$parameters = @{}
$parameterValues = New-Object Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression
$parameterValues.Values = @("Install")
$parameters.Add("Operation", $parameterValues)

Register-SSMTaskWithMaintenanceWindow -WindowId "mw-03a342e62c96d31b0" -ServiceRoleArn "arn:aws:iam::123456789012:role/MaintenanceWindowsRole" -MaxConcurrency 1 -MaxError 1 -TaskArn "AWS-RunShellScript" -Target @{ Key="InstanceIds";Values="i-0000293ffd8c57862" } -TaskType "RUN_COMMAND" -Priority 10 -TaskParameter $parameters