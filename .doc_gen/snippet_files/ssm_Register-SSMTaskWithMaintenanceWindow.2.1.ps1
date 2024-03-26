$parameters = @{}
$parameterValues = New-Object Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression
$parameterValues.Values = @("Install")
$parameters.Add("Operation", $parameterValues)

register-ssmtaskwithmaintenancewindow -WindowId "mw-03a342e62c96d31b0" -ServiceRoleArn "arn:aws:iam::123456789012:role/MaintenanceWindowsRole" -MaxConcurrency 1 -MaxError 1 -TaskArn "AWS-RunShellScript" -Target @{ Key="WindowTargetIds";Values="350d44e6-28cc-44e2-951f-4b2c985838f6" } -TaskType "RUN_COMMAND" -Priority 10 -TaskParameter $parameters