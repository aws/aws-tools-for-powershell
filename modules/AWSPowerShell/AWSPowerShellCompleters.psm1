# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

$AWS_RegionCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$regionHash = @{ }

    # Similar to Get-AWSRegion
	$regions = [Amazon.RegionEndpoint]::EnumerableAllRegions
	foreach ($r in $regions)
	{
		$regionHash.Add($r.SystemName, $r.DisplayName)
	}

	$regionHash.Keys |
	Sort-Object |
	Where-Object { $_ -like "$wordToComplete*" } |
	ForEach-Object {
		New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $regionHash[$_]
	}
}

_awsArgumentCompleterRegistration $AWS_RegionCompleter @{ "Region"=@() }

$AWS_EC2ImageByNameCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$keys = [Amazon.EC2.Util.ImageUtilities]::ImageKeys

	$keys |
	Sort-Object -Descending |
	Where-Object { $_ -like "$wordToComplete*" } |
	ForEach-Object {
		New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_
	}
}

_awsArgumentCompleterRegistration $AWS_EC2ImageByNameCompleter @{ "Name"=@("Get-EC2ImageByName") }

$AWS_ProfileNameCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	# allow for new user with no profiles set up yet
	$profiles = Get-AWSCredentials -ListProfileDetail | select -expandproperty ProfileName
	if ($profiles)
	{
		$profiles |
		Sort-Object |
		Where-Object { $_ -like "$wordToComplete*" } |
		ForEach-Object {
			New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_
		}
	}
}

_awsArgumentCompleterRegistration $AWS_ProfileNameCompleter @{ "ProfileName"=@() }

# The attribute name parameter for EC2 apis such as ModifyImageAttribute is modeled as a string
# in the service model rather than an enum type, which means by default we cannot auto-generate
# an argument completer. Api's use as DescribeImageAttribute do use an enum type (ImageAttributeName)
# and so don't have this problem.
$AWS_EC2ImageAttributeCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Taken from Amazon.EC2.ImageAttributeName
        "Edit-EC2ImageAttribute/Attribute"
        {
            $v = "description","kernel","ramdisk","launchPermission","productCodes","blockDeviceMapping","sriovNetSupport"
            break
        }
    }

    $v |
    Where-Object { $_ -like "$wordToComplete*" } |
    ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

_awsArgumentCompleterRegistration $AWS_EC2ImageAttributeCompleter @{ "Attribute"=@("Edit-EC2ImageAttribute") }

# begin auto-generated service completers
# Argument completions for service Amazon API Gateway
$AG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.APIGateway.ApiKeysFormat
        "Import-AGApiKey/Format"
        {
            $v = "csv"
            break
        }
        
        # Amazon.APIGateway.AuthorizerType
        "New-AGAuthorizer/Type"
        {
            $v = "COGNITO_USER_POOLS","REQUEST","TOKEN"
            break
        }
        
        # Amazon.APIGateway.CacheClusterSize
        {
            ($_ -eq "New-AGDeployment/CacheClusterSize") -Or
            ($_ -eq "New-AGStage/CacheClusterSize")
        }
        {
            $v = "0.5","1.6","118","13.5","237","28.4","58.2","6.1"
            break
        }
        
        # Amazon.APIGateway.ContentHandlingStrategy
        {
            ($_ -eq "Write-AGIntegration/ContentHandling") -Or
            ($_ -eq "Write-AGIntegrationResponse/ContentHandling")
        }
        {
            $v = "CONVERT_TO_BINARY","CONVERT_TO_TEXT"
            break
        }
        
        # Amazon.APIGateway.DocumentationPartType
        {
            ($_ -eq "New-AGDocumentationPart/Location_Type") -Or
            ($_ -eq "Get-AGDocumentationPartList/Type")
        }
        {
            $v = "API","AUTHORIZER","METHOD","MODEL","PATH_PARAMETER","QUERY_PARAMETER","REQUEST_BODY","REQUEST_HEADER","RESOURCE","RESPONSE","RESPONSE_BODY","RESPONSE_HEADER"
            break
        }
        
        # Amazon.APIGateway.GatewayResponseType
        {
            ($_ -eq "Get-AGGatewayResponse/ResponseType") -Or
            ($_ -eq "Remove-AGGatewayResponse/ResponseType") -Or
            ($_ -eq "Update-AGGatewayResponse/ResponseType") -Or
            ($_ -eq "Write-AGGatewayResponse/ResponseType")
        }
        {
            $v = "ACCESS_DENIED","API_CONFIGURATION_ERROR","AUTHORIZER_CONFIGURATION_ERROR","AUTHORIZER_FAILURE","BAD_REQUEST_BODY","BAD_REQUEST_PARAMETERS","DEFAULT_4XX","DEFAULT_5XX","EXPIRED_TOKEN","INTEGRATION_FAILURE","INTEGRATION_TIMEOUT","INVALID_API_KEY","INVALID_SIGNATURE","MISSING_AUTHENTICATION_TOKEN","QUOTA_EXCEEDED","REQUEST_TOO_LARGE","RESOURCE_NOT_FOUND","THROTTLED","UNAUTHORIZED","UNSUPPORTED_MEDIA_TYPE"
            break
        }
        
        # Amazon.APIGateway.IntegrationType
        "Write-AGIntegration/Type"
        {
            $v = "AWS","AWS_PROXY","HTTP","HTTP_PROXY","MOCK"
            break
        }
        
        # Amazon.APIGateway.PutMode
        {
            ($_ -eq "Import-AGDocumentationPartList/Mode") -Or
            ($_ -eq "Write-AGRestApi/Mode")
        }
        {
            $v = "merge","overwrite"
            break
        }
        
        # Amazon.APIGateway.QuotaPeriodType
        "New-AGUsagePlan/Quota_Period"
        {
            $v = "DAY","MONTH","WEEK"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AG_map = @{
    "CacheClusterSize"=@("New-AGDeployment","New-AGStage")
    "ContentHandling"=@("Write-AGIntegration","Write-AGIntegrationResponse")
    "Format"=@("Import-AGApiKey")
    "Location_Type"=@("New-AGDocumentationPart")
    "Mode"=@("Import-AGDocumentationPartList","Write-AGRestApi")
    "Quota_Period"=@("New-AGUsagePlan")
    "ResponseType"=@("Get-AGGatewayResponse","Remove-AGGatewayResponse","Update-AGGatewayResponse","Write-AGGatewayResponse")
    "Type"=@("Get-AGDocumentationPartList","New-AGAuthorizer","Write-AGIntegration")
}

_awsArgumentCompleterRegistration $AG_Completers $AG_map


# Argument completions for service Application Auto Scaling
$AAS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ApplicationAutoScaling.AdjustmentType
        "Write-AASScalingPolicy/StepScalingPolicyConfiguration_AdjustmentType"
        {
            $v = "ChangeInCapacity","ExactCapacity","PercentChangeInCapacity"
            break
        }
        
        # Amazon.ApplicationAutoScaling.MetricAggregationType
        "Write-AASScalingPolicy/StepScalingPolicyConfiguration_MetricAggregationType"
        {
            $v = "Average","Maximum","Minimum"
            break
        }
        
        # Amazon.ApplicationAutoScaling.MetricStatistic
        "Write-AASScalingPolicy/TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic"
        {
            $v = "Average","Maximum","Minimum","SampleCount","Sum"
            break
        }
        
        # Amazon.ApplicationAutoScaling.MetricType
        "Write-AASScalingPolicy/TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType"
        {
            $v = "DynamoDBReadCapacityUtilization","DynamoDBWriteCapacityUtilization"
            break
        }
        
        # Amazon.ApplicationAutoScaling.PolicyType
        "Write-AASScalingPolicy/PolicyType"
        {
            $v = "StepScaling","TargetTrackingScaling"
            break
        }
        
        # Amazon.ApplicationAutoScaling.ScalableDimension
        {
            ($_ -eq "Add-AASScalableTarget/ScalableDimension") -Or
            ($_ -eq "Get-AASScalableTarget/ScalableDimension") -Or
            ($_ -eq "Get-AASScalingActivity/ScalableDimension") -Or
            ($_ -eq "Get-AASScalingPolicy/ScalableDimension") -Or
            ($_ -eq "Remove-AASScalableTarget/ScalableDimension") -Or
            ($_ -eq "Remove-AASScalingPolicy/ScalableDimension") -Or
            ($_ -eq "Write-AASScalingPolicy/ScalableDimension")
        }
        {
            $v = "appstream:fleet:DesiredCapacity","dynamodb:index:ReadCapacityUnits","dynamodb:index:WriteCapacityUnits","dynamodb:table:ReadCapacityUnits","dynamodb:table:WriteCapacityUnits","ec2:spot-fleet-request:TargetCapacity","ecs:service:DesiredCount","elasticmapreduce:instancegroup:InstanceCount"
            break
        }
        
        # Amazon.ApplicationAutoScaling.ServiceNamespace
        {
            ($_ -eq "Add-AASScalableTarget/ServiceNamespace") -Or
            ($_ -eq "Get-AASScalableTarget/ServiceNamespace") -Or
            ($_ -eq "Get-AASScalingActivity/ServiceNamespace") -Or
            ($_ -eq "Get-AASScalingPolicy/ServiceNamespace") -Or
            ($_ -eq "Remove-AASScalableTarget/ServiceNamespace") -Or
            ($_ -eq "Remove-AASScalingPolicy/ServiceNamespace") -Or
            ($_ -eq "Write-AASScalingPolicy/ServiceNamespace")
        }
        {
            $v = "appstream","dynamodb","ec2","ecs","elasticmapreduce"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AAS_map = @{
    "PolicyType"=@("Write-AASScalingPolicy")
    "ScalableDimension"=@("Add-AASScalableTarget","Get-AASScalableTarget","Get-AASScalingActivity","Get-AASScalingPolicy","Remove-AASScalableTarget","Remove-AASScalingPolicy","Write-AASScalingPolicy")
    "ServiceNamespace"=@("Add-AASScalableTarget","Get-AASScalableTarget","Get-AASScalingActivity","Get-AASScalingPolicy","Remove-AASScalableTarget","Remove-AASScalingPolicy","Write-AASScalingPolicy")
    "StepScalingPolicyConfiguration_AdjustmentType"=@("Write-AASScalingPolicy")
    "StepScalingPolicyConfiguration_MetricAggregationType"=@("Write-AASScalingPolicy")
    "TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic"=@("Write-AASScalingPolicy")
    "TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType"=@("Write-AASScalingPolicy")
}

_awsArgumentCompleterRegistration $AAS_Completers $AAS_map


# Argument completions for service Application Discovery Service
$ADS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ApplicationDiscoveryService.ConfigurationItemType
        "Get-ADSConfigurationList/ConfigurationType"
        {
            $v = "APPLICATION","CONNECTION","PROCESS","SERVER"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ADS_map = @{
    "ConfigurationType"=@("Get-ADSConfigurationList")
}

_awsArgumentCompleterRegistration $ADS_Completers $ADS_map


# Argument completions for service AWS AppStream
$APS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AppStream.AuthenticationType
        "Get-APSSessionList/AuthenticationType"
        {
            $v = "API","SAML","USERPOOL"
            break
        }
        
        # Amazon.AppStream.FleetType
        "New-APSFleet/FleetType"
        {
            $v = "ALWAYS_ON","ON_DEMAND"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$APS_map = @{
    "AuthenticationType"=@("Get-APSSessionList")
    "FleetType"=@("New-APSFleet")
}

_awsArgumentCompleterRegistration $APS_Completers $APS_map


# Argument completions for service Amazon Athena
$ATH_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Athena.EncryptionOption
        "Start-ATHQueryExecution/ResultConfiguration_EncryptionConfiguration_EncryptionOption"
        {
            $v = "CSE_KMS","SSE_KMS","SSE_S3"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ATH_map = @{
    "ResultConfiguration_EncryptionConfiguration_EncryptionOption"=@("Start-ATHQueryExecution")
}

_awsArgumentCompleterRegistration $ATH_Completers $ATH_map


# Argument completions for service Auto Scaling
$AS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AutoScaling.MetricStatistic
        "Write-ASScalingPolicy/TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic"
        {
            $v = "Average","Maximum","Minimum","SampleCount","Sum"
            break
        }
        
        # Amazon.AutoScaling.MetricType
        "Write-ASScalingPolicy/TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType"
        {
            $v = "ALBRequestCountPerTarget","ASGAverageCPUUtilization","ASGAverageNetworkIn","ASGAverageNetworkOut"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AS_map = @{
    "TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic"=@("Write-ASScalingPolicy")
    "TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType"=@("Write-ASScalingPolicy")
}

_awsArgumentCompleterRegistration $AS_Completers $AS_map


# Argument completions for service AWS Batch
$BAT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Batch.CEState
        {
            ($_ -eq "New-BATComputeEnvironment/State") -Or
            ($_ -eq "Update-BATComputeEnvironment/State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }
        
        # Amazon.Batch.CEType
        "New-BATComputeEnvironment/Type"
        {
            $v = "MANAGED","UNMANAGED"
            break
        }
        
        # Amazon.Batch.CRType
        "New-BATComputeEnvironment/ComputeResources_Type"
        {
            $v = "EC2","SPOT"
            break
        }
        
        # Amazon.Batch.JobDefinitionType
        "Register-BATJobDefinition/Type"
        {
            $v = "container"
            break
        }
        
        # Amazon.Batch.JobStatus
        "Get-BATJobsList/JobStatus"
        {
            $v = "FAILED","PENDING","RUNNABLE","RUNNING","STARTING","SUBMITTED","SUCCEEDED"
            break
        }
        
        # Amazon.Batch.JQState
        {
            ($_ -eq "New-BATJobQueue/State") -Or
            ($_ -eq "Update-BATJobQueue/State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BAT_map = @{
    "ComputeResources_Type"=@("New-BATComputeEnvironment")
    "JobStatus"=@("Get-BATJobsList")
    "State"=@("New-BATComputeEnvironment","New-BATJobQueue","Update-BATComputeEnvironment","Update-BATJobQueue")
    "Type"=@("New-BATComputeEnvironment","Register-BATJobDefinition")
}

_awsArgumentCompleterRegistration $BAT_Completers $BAT_map


# Argument completions for service AWS Elastic Beanstalk
$EB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticBeanstalk.ActionStatus
        "Get-EBEnvironmentManagedAction/Status"
        {
            $v = "Pending","Running","Scheduled","Unknown"
            break
        }
        
        # Amazon.ElasticBeanstalk.ComputeType
        "New-EBApplicationVersion/BuildConfiguration_ComputeType"
        {
            $v = "BUILD_GENERAL1_LARGE","BUILD_GENERAL1_MEDIUM","BUILD_GENERAL1_SMALL"
            break
        }
        
        # Amazon.ElasticBeanstalk.EnvironmentInfoType
        {
            ($_ -eq "Get-EBEnvironmentInfo/InfoType") -Or
            ($_ -eq "Request-EBEnvironmentInfo/InfoType")
        }
        {
            $v = "bundle","tail"
            break
        }
        
        # Amazon.ElasticBeanstalk.EventSeverity
        "Get-EBEvent/Severity"
        {
            $v = "DEBUG","ERROR","FATAL","INFO","TRACE","WARN"
            break
        }
        
        # Amazon.ElasticBeanstalk.SourceRepository
        "New-EBApplicationVersion/SourceBuildInformation_SourceRepository"
        {
            $v = "CodeCommit","S3"
            break
        }
        
        # Amazon.ElasticBeanstalk.SourceType
        "New-EBApplicationVersion/SourceBuildInformation_SourceType"
        {
            $v = "Git","Zip"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EB_map = @{
    "BuildConfiguration_ComputeType"=@("New-EBApplicationVersion")
    "InfoType"=@("Get-EBEnvironmentInfo","Request-EBEnvironmentInfo")
    "Severity"=@("Get-EBEvent")
    "SourceBuildInformation_SourceRepository"=@("New-EBApplicationVersion")
    "SourceBuildInformation_SourceType"=@("New-EBApplicationVersion")
    "Status"=@("Get-EBEnvironmentManagedAction")
}

_awsArgumentCompleterRegistration $EB_Completers $EB_map


# Argument completions for service AWS Budgets
$BGT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Budgets.BudgetType
        {
            ($_ -eq "New-BGTBudget/Budget_BudgetType") -Or
            ($_ -eq "Update-BGTBudget/NewBudget_BudgetType")
        }
        {
            $v = "COST","RI_UTILIZATION","USAGE"
            break
        }
        
        # Amazon.Budgets.ComparisonOperator
        {
            ($_ -eq "Update-BGTNotification/NewNotification_ComparisonOperator") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_ComparisonOperator") -Or
            ($_ -eq "New-BGTNotification/Notification_ComparisonOperator") -Or
            ($_ -eq "New-BGTSubscriber/Notification_ComparisonOperator") -Or
            ($_ -eq "Remove-BGTNotification/Notification_ComparisonOperator") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_ComparisonOperator") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_ComparisonOperator") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_ComparisonOperator")
        }
        {
            $v = "EQUAL_TO","GREATER_THAN","LESS_THAN"
            break
        }
        
        # Amazon.Budgets.NotificationType
        {
            ($_ -eq "Update-BGTNotification/NewNotification_NotificationType") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_NotificationType") -Or
            ($_ -eq "New-BGTNotification/Notification_NotificationType") -Or
            ($_ -eq "New-BGTSubscriber/Notification_NotificationType") -Or
            ($_ -eq "Remove-BGTNotification/Notification_NotificationType") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_NotificationType") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_NotificationType") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_NotificationType")
        }
        {
            $v = "ACTUAL","FORECASTED"
            break
        }
        
        # Amazon.Budgets.SubscriptionType
        {
            ($_ -eq "Update-BGTSubscriber/NewSubscriber_SubscriptionType") -Or
            ($_ -eq "Update-BGTSubscriber/OldSubscriber_SubscriptionType") -Or
            ($_ -eq "New-BGTSubscriber/Subscriber_SubscriptionType") -Or
            ($_ -eq "Remove-BGTSubscriber/Subscriber_SubscriptionType")
        }
        {
            $v = "EMAIL","SNS"
            break
        }
        
        # Amazon.Budgets.ThresholdType
        {
            ($_ -eq "Update-BGTNotification/NewNotification_ThresholdType") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_ThresholdType") -Or
            ($_ -eq "New-BGTNotification/Notification_ThresholdType") -Or
            ($_ -eq "New-BGTSubscriber/Notification_ThresholdType") -Or
            ($_ -eq "Remove-BGTNotification/Notification_ThresholdType") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_ThresholdType") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_ThresholdType") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_ThresholdType")
        }
        {
            $v = "ABSOLUTE_VALUE","PERCENTAGE"
            break
        }
        
        # Amazon.Budgets.TimeUnit
        {
            ($_ -eq "New-BGTBudget/Budget_TimeUnit") -Or
            ($_ -eq "Update-BGTBudget/NewBudget_TimeUnit")
        }
        {
            $v = "ANNUALLY","DAILY","MONTHLY","QUARTERLY"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BGT_map = @{
    "Budget_BudgetType"=@("New-BGTBudget")
    "Budget_TimeUnit"=@("New-BGTBudget")
    "NewBudget_BudgetType"=@("Update-BGTBudget")
    "NewBudget_TimeUnit"=@("Update-BGTBudget")
    "NewNotification_ComparisonOperator"=@("Update-BGTNotification")
    "NewNotification_NotificationType"=@("Update-BGTNotification")
    "NewNotification_ThresholdType"=@("Update-BGTNotification")
    "NewSubscriber_SubscriptionType"=@("Update-BGTSubscriber")
    "Notification_ComparisonOperator"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "Notification_NotificationType"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "Notification_ThresholdType"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "OldNotification_ComparisonOperator"=@("Update-BGTNotification")
    "OldNotification_NotificationType"=@("Update-BGTNotification")
    "OldNotification_ThresholdType"=@("Update-BGTNotification")
    "OldSubscriber_SubscriptionType"=@("Update-BGTSubscriber")
    "Subscriber_SubscriptionType"=@("New-BGTSubscriber","Remove-BGTSubscriber")
}

_awsArgumentCompleterRegistration $BGT_Completers $BGT_map


# Argument completions for service AWS Cloud Directory
$CDIR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudDirectory.ConsistencyLevel
        {
            ($_ -eq "Get-CDIRIncomingTypedLink/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRIndex/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectAttribute/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectChild/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectIndex/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectInformation/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectParent/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectPolicy/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIROutgoingTypedLink/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRPolicyAttachment/ConsistencyLevel") -Or
            ($_ -eq "Read-CDIRDirectoryBatch/ConsistencyLevel")
        }
        {
            $v = "EVENTUAL","SERIALIZABLE"
            break
        }
        
        # Amazon.CloudDirectory.DirectoryState
        "Get-CDIRDirectory/State"
        {
            $v = "DELETED","DISABLED","ENABLED"
            break
        }
        
        # Amazon.CloudDirectory.ObjectType
        {
            ($_ -eq "New-CDIRFacet/ObjectType") -Or
            ($_ -eq "Update-CDIRFacet/ObjectType")
        }
        {
            $v = "INDEX","LEAF_NODE","NODE","POLICY"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CDIR_map = @{
    "ConsistencyLevel"=@("Get-CDIRIncomingTypedLink","Get-CDIRIndex","Get-CDIRObjectAttribute","Get-CDIRObjectChild","Get-CDIRObjectIndex","Get-CDIRObjectInformation","Get-CDIRObjectParent","Get-CDIRObjectPolicy","Get-CDIROutgoingTypedLink","Get-CDIRPolicyAttachment","Read-CDIRDirectoryBatch")
    "ObjectType"=@("New-CDIRFacet","Update-CDIRFacet")
    "State"=@("Get-CDIRDirectory")
}

_awsArgumentCompleterRegistration $CDIR_Completers $CDIR_map


# Argument completions for service AWS CloudFormation
$CFN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudFormation.OnFailure
        "New-CFNStack/OnFailure"
        {
            $v = "DELETE","DO_NOTHING","ROLLBACK"
            break
        }
        
        # Amazon.CloudFormation.ResourceSignalStatus
        "Send-CFNResourceSignal/Status"
        {
            $v = "FAILURE","SUCCESS"
            break
        }
        
        # Amazon.CloudFormation.StackSetStatus
        "Get-CFNStackSetList/Status"
        {
            $v = "ACTIVE","DELETED"
            break
        }
        
        # Amazon.CloudFormation.StackStatus
        {
            ($_ -eq "Test-CFNStack/Status") -Or
            ($_ -eq "Wait-CFNStack/Status") -Or
            ($_ -eq "Watch-CFNStackEvent/Status")
        }
        {
            $v = "CREATE_COMPLETE","CREATE_FAILED","CREATE_IN_PROGRESS","DELETE_COMPLETE","DELETE_FAILED","DELETE_IN_PROGRESS","REVIEW_IN_PROGRESS","ROLLBACK_COMPLETE","ROLLBACK_FAILED","ROLLBACK_IN_PROGRESS","UPDATE_COMPLETE","UPDATE_COMPLETE_CLEANUP_IN_PROGRESS","UPDATE_IN_PROGRESS","UPDATE_ROLLBACK_COMPLETE","UPDATE_ROLLBACK_COMPLETE_CLEANUP_IN_PROGRESS","UPDATE_ROLLBACK_FAILED","UPDATE_ROLLBACK_IN_PROGRESS"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CFN_map = @{
    "OnFailure"=@("New-CFNStack")
    "Status"=@("Get-CFNStackSetList","Send-CFNResourceSignal","Test-CFNStack","Wait-CFNStack","Watch-CFNStackEvent")
}

_awsArgumentCompleterRegistration $CFN_Completers $CFN_map


# Argument completions for service Amazon CloudFront
$CF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudFront.CertificateSource
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_ViewerCertificate_CertificateSource") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ViewerCertificate_CertificateSource") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource")
        }
        {
            $v = "acm","cloudfront","iam"
            break
        }
        
        # Amazon.CloudFront.GeoRestrictionType
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_Restrictions_GeoRestriction_RestrictionType") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_Restrictions_GeoRestriction_RestrictionType") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType")
        }
        {
            $v = "blacklist","none","whitelist"
            break
        }
        
        # Amazon.CloudFront.HttpVersion
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_HttpVersion") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_HttpVersion") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_HttpVersion")
        }
        {
            $v = "http1.1","http2"
            break
        }
        
        # Amazon.CloudFront.ItemSelection
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward")
        }
        {
            $v = "all","none","whitelist"
            break
        }
        
        # Amazon.CloudFront.MinimumProtocolVersion
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_ViewerCertificate_MinimumProtocolVersion") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ViewerCertificate_MinimumProtocolVersion") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion")
        }
        {
            $v = "SSLv3","TLSv1"
            break
        }
        
        # Amazon.CloudFront.PriceClass
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_PriceClass") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFStreamingDistribution/StreamingDistributionConfig_PriceClass") -Or
            ($_ -eq "Update-CFStreamingDistribution/StreamingDistributionConfig_PriceClass") -Or
            ($_ -eq "New-CFStreamingDistributionWithTag/StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass")
        }
        {
            $v = "PriceClass_100","PriceClass_200","PriceClass_All"
            break
        }
        
        # Amazon.CloudFront.SSLSupportMethod
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_ViewerCertificate_SSLSupportMethod") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_ViewerCertificate_SSLSupportMethod") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod")
        }
        {
            $v = "sni-only","vip"
            break
        }
        
        # Amazon.CloudFront.ViewerProtocolPolicy
        {
            ($_ -eq "New-CFDistribution/DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy") -Or
            ($_ -eq "Update-CFDistribution/DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy") -Or
            ($_ -eq "New-CFDistributionWithTag/DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy")
        }
        {
            $v = "allow-all","https-only","redirect-to-https"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CF_map = @{
    "DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_HttpVersion"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_PriceClass"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_Restrictions_GeoRestriction_RestrictionType"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_ViewerCertificate_CertificateSource"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_ViewerCertificate_MinimumProtocolVersion"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfig_ViewerCertificate_SSLSupportMethod"=@("New-CFDistribution","Update-CFDistribution")
    "DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ForwardedValues_Cookies_Forward"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_DefaultCacheBehavior_ViewerProtocolPolicy"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_HttpVersion"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_PriceClass"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_Restrictions_GeoRestriction_RestrictionType"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_ViewerCertificate_CertificateSource"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_ViewerCertificate_MinimumProtocolVersion"=@("New-CFDistributionWithTag")
    "DistributionConfigWithTags_DistributionConfig_ViewerCertificate_SSLSupportMethod"=@("New-CFDistributionWithTag")
    "StreamingDistributionConfig_PriceClass"=@("New-CFStreamingDistribution","Update-CFStreamingDistribution")
    "StreamingDistributionConfigWithTags_StreamingDistributionConfig_PriceClass"=@("New-CFStreamingDistributionWithTag")
}

_awsArgumentCompleterRegistration $CF_Completers $CF_map


# Argument completions for service Amazon CloudSearch
$CS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudSearch.AlgorithmicStemming
        "Set-CSAnalysisScheme/AnalysisScheme_AnalysisOptions_AlgorithmicStemming"
        {
            $v = "full","light","minimal","none"
            break
        }
        
        # Amazon.CloudSearch.AnalysisSchemeLanguage
        "Set-CSAnalysisScheme/AnalysisScheme_AnalysisSchemeLanguage"
        {
            $v = "ar","bg","ca","cs","da","de","el","en","es","eu","fa","fi","fr","ga","gl","he","hi","hu","hy","id","it","ja","ko","lv","mul","nl","no","pt","ro","ru","sv","th","tr","zh-Hans","zh-Hant"
            break
        }
        
        # Amazon.CloudSearch.IndexFieldType
        "Set-CSIndexField/IndexField_IndexFieldType"
        {
            $v = "date","date-array","double","double-array","int","int-array","latlon","literal","literal-array","text","text-array"
            break
        }
        
        # Amazon.CloudSearch.PartitionInstanceType
        "Update-CSScalingParameter/ScalingParameters_DesiredInstanceType"
        {
            $v = "search.m1.large","search.m1.small","search.m2.2xlarge","search.m2.xlarge","search.m3.2xlarge","search.m3.large","search.m3.medium","search.m3.xlarge"
            break
        }
        
        # Amazon.CloudSearch.SuggesterFuzzyMatching
        "Set-CSSuggester/Suggester_DocumentSuggesterOptions_FuzzyMatching"
        {
            $v = "high","low","none"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CS_map = @{
    "AnalysisScheme_AnalysisOptions_AlgorithmicStemming"=@("Set-CSAnalysisScheme")
    "AnalysisScheme_AnalysisSchemeLanguage"=@("Set-CSAnalysisScheme")
    "IndexField_IndexFieldType"=@("Set-CSIndexField")
    "ScalingParameters_DesiredInstanceType"=@("Update-CSScalingParameter")
    "Suggester_DocumentSuggesterOptions_FuzzyMatching"=@("Set-CSSuggester")
}

_awsArgumentCompleterRegistration $CS_Completers $CS_map


# Argument completions for service Amazon CloudSearchDomain
$CSD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudSearchDomain.ContentType
        "Write-CSDDocument/ContentType"
        {
            $v = "application/json","application/xml"
            break
        }
        
        # Amazon.CloudSearchDomain.QueryParser
        "Search-CSDDocument/QueryParser"
        {
            $v = "dismax","lucene","simple","structured"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CSD_map = @{
    "ContentType"=@("Write-CSDDocument")
    "QueryParser"=@("Search-CSDDocument")
}

_awsArgumentCompleterRegistration $CSD_Completers $CSD_map


# Argument completions for service Amazon CloudWatch
$CW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudWatch.ComparisonOperator
        "Write-CWMetricAlarm/ComparisonOperator"
        {
            $v = "GreaterThanOrEqualToThreshold","GreaterThanThreshold","LessThanOrEqualToThreshold","LessThanThreshold"
            break
        }
        
        # Amazon.CloudWatch.HistoryItemType
        "Get-CWAlarmHistory/HistoryItemType"
        {
            $v = "Action","ConfigurationUpdate","StateUpdate"
            break
        }
        
        # Amazon.CloudWatch.StandardUnit
        {
            ($_ -eq "Get-CWAlarmForMetric/Unit") -Or
            ($_ -eq "Get-CWMetricStatistic/Unit") -Or
            ($_ -eq "Write-CWMetricAlarm/Unit")
        }
        {
            $v = "Bits","Bits/Second","Bytes","Bytes/Second","Count","Count/Second","Gigabits","Gigabits/Second","Gigabytes","Gigabytes/Second","Kilobits","Kilobits/Second","Kilobytes","Kilobytes/Second","Megabits","Megabits/Second","Megabytes","Megabytes/Second","Microseconds","Milliseconds","None","Percent","Seconds","Terabits","Terabits/Second","Terabytes","Terabytes/Second"
            break
        }
        
        # Amazon.CloudWatch.StateValue
        {
            ($_ -eq "Get-CWAlarm/StateValue") -Or
            ($_ -eq "Set-CWAlarmState/StateValue")
        }
        {
            $v = "ALARM","INSUFFICIENT_DATA","OK"
            break
        }
        
        # Amazon.CloudWatch.Statistic
        {
            ($_ -eq "Get-CWAlarmForMetric/Statistic") -Or
            ($_ -eq "Write-CWMetricAlarm/Statistic")
        }
        {
            $v = "Average","Maximum","Minimum","SampleCount","Sum"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CW_map = @{
    "ComparisonOperator"=@("Write-CWMetricAlarm")
    "HistoryItemType"=@("Get-CWAlarmHistory")
    "StateValue"=@("Get-CWAlarm","Set-CWAlarmState")
    "Statistic"=@("Get-CWAlarmForMetric","Write-CWMetricAlarm")
    "Unit"=@("Get-CWAlarmForMetric","Get-CWMetricStatistic","Write-CWMetricAlarm")
}

_awsArgumentCompleterRegistration $CW_Completers $CW_map


# Argument completions for service Amazon CloudWatch Events
$CWE_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudWatchEvents.RuleState
        "Write-CWERule/State"
        {
            $v = "DISABLED","ENABLED"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWE_map = @{
    "State"=@("Write-CWERule")
}

_awsArgumentCompleterRegistration $CWE_Completers $CWE_map


# Argument completions for service Amazon CloudWatch Logs
$CWL_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudWatchLogs.Distribution
        "Write-CWLSubscriptionFilter/Distribution"
        {
            $v = "ByLogStream","Random"
            break
        }
        
        # Amazon.CloudWatchLogs.ExportTaskStatusCode
        "Get-CWLExportTask/StatusCode"
        {
            $v = "CANCELLED","COMPLETED","FAILED","PENDING","PENDING_CANCEL","RUNNING"
            break
        }
        
        # Amazon.CloudWatchLogs.OrderBy
        "Get-CWLLogStream/OrderBy"
        {
            $v = "LastEventTime","LogStreamName"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWL_map = @{
    "Distribution"=@("Write-CWLSubscriptionFilter")
    "OrderBy"=@("Get-CWLLogStream")
    "StatusCode"=@("Get-CWLExportTask")
}

_awsArgumentCompleterRegistration $CWL_Completers $CWL_map


# Argument completions for service AWS CodeBuild
$CB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeBuild.ArtifactNamespace
        {
            ($_ -eq "New-CBProject/Artifacts_NamespaceType") -Or
            ($_ -eq "Update-CBProject/Artifacts_NamespaceType") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_NamespaceType")
        }
        {
            $v = "BUILD_ID","NONE"
            break
        }
        
        # Amazon.CodeBuild.ArtifactPackaging
        {
            ($_ -eq "New-CBProject/Artifacts_Packaging") -Or
            ($_ -eq "Update-CBProject/Artifacts_Packaging") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_Packaging")
        }
        {
            $v = "NONE","ZIP"
            break
        }
        
        # Amazon.CodeBuild.ArtifactsType
        {
            ($_ -eq "New-CBProject/Artifacts_Type") -Or
            ($_ -eq "Update-CBProject/Artifacts_Type") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_Type")
        }
        {
            $v = "CODEPIPELINE","NO_ARTIFACTS","S3"
            break
        }
        
        # Amazon.CodeBuild.ComputeType
        {
            ($_ -eq "New-CBProject/Environment_ComputeType") -Or
            ($_ -eq "Update-CBProject/Environment_ComputeType")
        }
        {
            $v = "BUILD_GENERAL1_LARGE","BUILD_GENERAL1_MEDIUM","BUILD_GENERAL1_SMALL"
            break
        }
        
        # Amazon.CodeBuild.EnvironmentType
        {
            ($_ -eq "New-CBProject/Environment_Type") -Or
            ($_ -eq "Update-CBProject/Environment_Type")
        }
        {
            $v = "LINUX_CONTAINER"
            break
        }
        
        # Amazon.CodeBuild.ProjectSortByType
        "Get-CBProjectList/SortBy"
        {
            $v = "CREATED_TIME","LAST_MODIFIED_TIME","NAME"
            break
        }
        
        # Amazon.CodeBuild.SortOrderType
        {
            ($_ -eq "Get-CBBuildIdList/SortOrder") -Or
            ($_ -eq "Get-CBBuildIdListForProject/SortOrder") -Or
            ($_ -eq "Get-CBProjectList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }
        
        # Amazon.CodeBuild.SourceAuthType
        {
            ($_ -eq "New-CBProject/Source_Auth_Type") -Or
            ($_ -eq "Update-CBProject/Source_Auth_Type")
        }
        {
            $v = "OAUTH"
            break
        }
        
        # Amazon.CodeBuild.SourceType
        {
            ($_ -eq "New-CBProject/Source_Type") -Or
            ($_ -eq "Update-CBProject/Source_Type")
        }
        {
            $v = "BITBUCKET","CODECOMMIT","CODEPIPELINE","GITHUB","S3"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CB_map = @{
    "Artifacts_NamespaceType"=@("New-CBProject","Update-CBProject")
    "Artifacts_Packaging"=@("New-CBProject","Update-CBProject")
    "Artifacts_Type"=@("New-CBProject","Update-CBProject")
    "ArtifactsOverride_NamespaceType"=@("Start-CBBuild")
    "ArtifactsOverride_Packaging"=@("Start-CBBuild")
    "ArtifactsOverride_Type"=@("Start-CBBuild")
    "Environment_ComputeType"=@("New-CBProject","Update-CBProject")
    "Environment_Type"=@("New-CBProject","Update-CBProject")
    "SortBy"=@("Get-CBProjectList")
    "SortOrder"=@("Get-CBBuildIdList","Get-CBBuildIdListForProject","Get-CBProjectList")
    "Source_Auth_Type"=@("New-CBProject","Update-CBProject")
    "Source_Type"=@("New-CBProject","Update-CBProject")
}

_awsArgumentCompleterRegistration $CB_Completers $CB_map


# Argument completions for service AWS CodeCommit
$CC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeCommit.OrderEnum
        "Get-CCRepositoryList/Order"
        {
            $v = "ascending","descending"
            break
        }
        
        # Amazon.CodeCommit.SortByEnum
        "Get-CCRepositoryList/SortBy"
        {
            $v = "lastModifiedDate","repositoryName"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CC_map = @{
    "Order"=@("Get-CCRepositoryList")
    "SortBy"=@("Get-CCRepositoryList")
}

_awsArgumentCompleterRegistration $CC_Completers $CC_map


# Argument completions for service AWS CodeDeploy
$CD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeDeploy.ApplicationRevisionSortBy
        "Get-CDApplicationRevisionList/SortBy"
        {
            $v = "firstUsedTime","lastUsedTime","registerTime"
            break
        }
        
        # Amazon.CodeDeploy.BundleType
        {
            ($_ -eq "Get-CDApplicationRevision/Revision_S3Location_BundleType") -Or
            ($_ -eq "New-CDDeployment/Revision_S3Location_BundleType") -Or
            ($_ -eq "Register-CDApplicationRevision/Revision_S3Location_BundleType")
        }
        {
            $v = "tar","tgz","zip"
            break
        }
        
        # Amazon.CodeDeploy.DeploymentOption
        {
            ($_ -eq "New-CDDeploymentGroup/DeploymentStyle_DeploymentOption") -Or
            ($_ -eq "Update-CDDeploymentGroup/DeploymentStyle_DeploymentOption")
        }
        {
            $v = "WITHOUT_TRAFFIC_CONTROL","WITH_TRAFFIC_CONTROL"
            break
        }
        
        # Amazon.CodeDeploy.DeploymentReadyAction
        {
            ($_ -eq "New-CDDeploymentGroup/BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout") -Or
            ($_ -eq "Update-CDDeploymentGroup/BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout")
        }
        {
            $v = "CONTINUE_DEPLOYMENT","STOP_DEPLOYMENT"
            break
        }
        
        # Amazon.CodeDeploy.DeploymentType
        {
            ($_ -eq "New-CDDeploymentGroup/DeploymentStyle_DeploymentType") -Or
            ($_ -eq "Update-CDDeploymentGroup/DeploymentStyle_DeploymentType")
        }
        {
            $v = "BLUE_GREEN","IN_PLACE"
            break
        }
        
        # Amazon.CodeDeploy.FileExistsBehavior
        "New-CDDeployment/FileExistsBehavior"
        {
            $v = "DISALLOW","OVERWRITE","RETAIN"
            break
        }
        
        # Amazon.CodeDeploy.GreenFleetProvisioningAction
        {
            ($_ -eq "New-CDDeploymentGroup/BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action") -Or
            ($_ -eq "Update-CDDeploymentGroup/BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action")
        }
        {
            $v = "COPY_AUTO_SCALING_GROUP","DISCOVER_EXISTING"
            break
        }
        
        # Amazon.CodeDeploy.InstanceAction
        {
            ($_ -eq "New-CDDeploymentGroup/BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action") -Or
            ($_ -eq "Update-CDDeploymentGroup/BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action")
        }
        {
            $v = "KEEP_ALIVE","TERMINATE"
            break
        }
        
        # Amazon.CodeDeploy.ListStateFilterAction
        "Get-CDApplicationRevisionList/Deployed"
        {
            $v = "exclude","ignore","include"
            break
        }
        
        # Amazon.CodeDeploy.MinimumHealthyHostsType
        "New-CDDeploymentConfig/MinimumHealthyHosts_Type"
        {
            $v = "FLEET_PERCENT","HOST_COUNT"
            break
        }
        
        # Amazon.CodeDeploy.RegistrationStatus
        "Get-CDOnPremiseInstanceList/RegistrationStatus"
        {
            $v = "Deregistered","Registered"
            break
        }
        
        # Amazon.CodeDeploy.RevisionLocationType
        {
            ($_ -eq "Get-CDApplicationRevision/Revision_RevisionType") -Or
            ($_ -eq "New-CDDeployment/Revision_RevisionType") -Or
            ($_ -eq "Register-CDApplicationRevision/Revision_RevisionType")
        }
        {
            $v = "GitHub","S3"
            break
        }
        
        # Amazon.CodeDeploy.SortOrder
        "Get-CDApplicationRevisionList/SortOrder"
        {
            $v = "ascending","descending"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CD_map = @{
    "BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "Deployed"=@("Get-CDApplicationRevisionList")
    "DeploymentStyle_DeploymentOption"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "DeploymentStyle_DeploymentType"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "FileExistsBehavior"=@("New-CDDeployment")
    "MinimumHealthyHosts_Type"=@("New-CDDeploymentConfig")
    "RegistrationStatus"=@("Get-CDOnPremiseInstanceList")
    "Revision_RevisionType"=@("Get-CDApplicationRevision","New-CDDeployment","Register-CDApplicationRevision")
    "Revision_S3Location_BundleType"=@("Get-CDApplicationRevision","New-CDDeployment","Register-CDApplicationRevision")
    "SortBy"=@("Get-CDApplicationRevisionList")
    "SortOrder"=@("Get-CDApplicationRevisionList")
}

_awsArgumentCompleterRegistration $CD_Completers $CD_map


# Argument completions for service AWS CodePipeline
$CP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodePipeline.ActionCategory
        {
            ($_ -eq "Get-CPActionableJobList/ActionTypeId_Category") -Or
            ($_ -eq "Get-CPActionableThirdPartyJobList/ActionTypeId_Category") -Or
            ($_ -eq "New-CPCustomActionType/Category") -Or
            ($_ -eq "Remove-CPCustomActionType/Category")
        }
        {
            $v = "Approval","Build","Deploy","Invoke","Source","Test"
            break
        }
        
        # Amazon.CodePipeline.ActionOwner
        {
            ($_ -eq "Get-CPActionType/ActionOwnerFilter") -Or
            ($_ -eq "Get-CPActionableJobList/ActionTypeId_Owner") -Or
            ($_ -eq "Get-CPActionableThirdPartyJobList/ActionTypeId_Owner")
        }
        {
            $v = "AWS","Custom","ThirdParty"
            break
        }
        
        # Amazon.CodePipeline.ApprovalStatus
        "Write-CPApprovalResult/Result_Status"
        {
            $v = "Approved","Rejected"
            break
        }
        
        # Amazon.CodePipeline.FailureType
        {
            ($_ -eq "Write-CPJobFailureResult/FailureDetails_Type") -Or
            ($_ -eq "Write-CPThirdPartyJobFailureResult/FailureDetails_Type")
        }
        {
            $v = "ConfigurationError","JobFailed","PermissionError","RevisionOutOfSync","RevisionUnavailable","SystemUnavailable"
            break
        }
        
        # Amazon.CodePipeline.StageRetryMode
        "Redo-CPStageExecution/RetryMode"
        {
            $v = "FAILED_ACTIONS"
            break
        }
        
        # Amazon.CodePipeline.StageTransitionType
        {
            ($_ -eq "Disable-CPStageTransition/TransitionType") -Or
            ($_ -eq "Enable-CPStageTransition/TransitionType")
        }
        {
            $v = "Inbound","Outbound"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CP_map = @{
    "ActionOwnerFilter"=@("Get-CPActionType")
    "ActionTypeId_Category"=@("Get-CPActionableJobList","Get-CPActionableThirdPartyJobList")
    "ActionTypeId_Owner"=@("Get-CPActionableJobList","Get-CPActionableThirdPartyJobList")
    "Category"=@("New-CPCustomActionType","Remove-CPCustomActionType")
    "FailureDetails_Type"=@("Write-CPJobFailureResult","Write-CPThirdPartyJobFailureResult")
    "Result_Status"=@("Write-CPApprovalResult")
    "RetryMode"=@("Redo-CPStageExecution")
    "TransitionType"=@("Disable-CPStageTransition","Enable-CPStageTransition")
}

_awsArgumentCompleterRegistration $CP_Completers $CP_map


# Argument completions for service Amazon Cognito Identity Provider
$CGIP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CognitoIdentityProvider.AuthFlowType
        {
            ($_ -eq "Start-CGIPAuth/AuthFlow") -Or
            ($_ -eq "Start-CGIPAuthAdmin/AuthFlow")
        }
        {
            $v = "ADMIN_NO_SRP_AUTH","CUSTOM_AUTH","REFRESH_TOKEN","REFRESH_TOKEN_AUTH","USER_SRP_AUTH"
            break
        }
        
        # Amazon.CognitoIdentityProvider.ChallengeNameType
        {
            ($_ -eq "Send-CGIPAuthChallengeResponse/ChallengeName") -Or
            ($_ -eq "Send-CGIPAuthChallengeResponseAdmin/ChallengeName")
        }
        {
            $v = "ADMIN_NO_SRP_AUTH","CUSTOM_CHALLENGE","DEVICE_PASSWORD_VERIFIER","DEVICE_SRP_AUTH","NEW_PASSWORD_REQUIRED","PASSWORD_VERIFIER","SMS_MFA"
            break
        }
        
        # Amazon.CognitoIdentityProvider.DefaultEmailOptionType
        {
            ($_ -eq "New-CGIPUserPool/VerificationMessageTemplate_DefaultEmailOption") -Or
            ($_ -eq "Update-CGIPUserPool/VerificationMessageTemplate_DefaultEmailOption")
        }
        {
            $v = "CONFIRM_WITH_CODE","CONFIRM_WITH_LINK"
            break
        }
        
        # Amazon.CognitoIdentityProvider.DeviceRememberedStatusType
        {
            ($_ -eq "Edit-CGIPDeviceStatus/DeviceRememberedStatus") -Or
            ($_ -eq "Edit-CGIPDeviceStatusAdmin/DeviceRememberedStatus")
        }
        {
            $v = "not_remembered","remembered"
            break
        }
        
        # Amazon.CognitoIdentityProvider.IdentityProviderTypeType
        "New-CGIPIdentityProvider/ProviderType"
        {
            $v = "Facebook","Google","LoginWithAmazon","SAML"
            break
        }
        
        # Amazon.CognitoIdentityProvider.MessageActionType
        "New-CGIPUserAdmin/MessageAction"
        {
            $v = "RESEND","SUPPRESS"
            break
        }
        
        # Amazon.CognitoIdentityProvider.UserPoolMfaType
        {
            ($_ -eq "New-CGIPUserPool/MfaConfiguration") -Or
            ($_ -eq "Update-CGIPUserPool/MfaConfiguration")
        }
        {
            $v = "OFF","ON","OPTIONAL"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CGIP_map = @{
    "AuthFlow"=@("Start-CGIPAuth","Start-CGIPAuthAdmin")
    "ChallengeName"=@("Send-CGIPAuthChallengeResponse","Send-CGIPAuthChallengeResponseAdmin")
    "DeviceRememberedStatus"=@("Edit-CGIPDeviceStatus","Edit-CGIPDeviceStatusAdmin")
    "MessageAction"=@("New-CGIPUserAdmin")
    "MfaConfiguration"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "ProviderType"=@("New-CGIPIdentityProvider")
    "VerificationMessageTemplate_DefaultEmailOption"=@("New-CGIPUserPool","Update-CGIPUserPool")
}

_awsArgumentCompleterRegistration $CGIP_Completers $CGIP_map


# Argument completions for service AWS Config
$CFG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ConfigService.ChronologicalOrder
        "Get-CFGResourceConfigHistory/ChronologicalOrder"
        {
            $v = "Forward","Reverse"
            break
        }
        
        # Amazon.ConfigService.ConfigRuleState
        "Write-CFGConfigRule/ConfigRule_ConfigRuleState"
        {
            $v = "ACTIVE","DELETING","DELETING_RESULTS","EVALUATING"
            break
        }
        
        # Amazon.ConfigService.MaximumExecutionFrequency
        {
            ($_ -eq "Write-CFGConfigRule/ConfigRule_MaximumExecutionFrequency") -Or
            ($_ -eq "Write-CFGDeliveryChannel/DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency")
        }
        {
            $v = "One_Hour","Six_Hours","Three_Hours","Twelve_Hours","TwentyFour_Hours"
            break
        }
        
        # Amazon.ConfigService.Owner
        "Write-CFGConfigRule/ConfigRule_Source_Owner"
        {
            $v = "AWS","CUSTOM_LAMBDA"
            break
        }
        
        # Amazon.ConfigService.ResourceType
        {
            ($_ -eq "Get-CFGDiscoveredResource/ResourceType") -Or
            ($_ -eq "Get-CFGResourceConfigHistory/ResourceType")
        }
        {
            $v = "AWS::ACM::Certificate","AWS::AutoScaling::AutoScalingGroup","AWS::AutoScaling::LaunchConfiguration","AWS::AutoScaling::ScalingPolicy","AWS::AutoScaling::ScheduledAction","AWS::CloudFormation::Stack","AWS::CloudTrail::Trail","AWS::CloudWatch::Alarm","AWS::DynamoDB::Table","AWS::EC2::CustomerGateway","AWS::EC2::EIP","AWS::EC2::Host","AWS::EC2::Instance","AWS::EC2::InternetGateway","AWS::EC2::NetworkAcl","AWS::EC2::NetworkInterface","AWS::EC2::RouteTable","AWS::EC2::SecurityGroup","AWS::EC2::Subnet","AWS::EC2::Volume","AWS::EC2::VPC","AWS::EC2::VPNConnection","AWS::EC2::VPNGateway","AWS::ElasticLoadBalancingV2::LoadBalancer","AWS::IAM::Group","AWS::IAM::Policy","AWS::IAM::Role","AWS::IAM::User","AWS::RDS::DBInstance","AWS::RDS::DBSecurityGroup","AWS::RDS::DBSnapshot","AWS::RDS::DBSubnetGroup","AWS::RDS::EventSubscription","AWS::Redshift::Cluster","AWS::Redshift::ClusterParameterGroup","AWS::Redshift::ClusterSecurityGroup","AWS::Redshift::ClusterSnapshot","AWS::Redshift::ClusterSubnetGroup","AWS::Redshift::EventSubscription","AWS::S3::Bucket","AWS::SSM::ManagedInstanceInventory"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CFG_map = @{
    "ChronologicalOrder"=@("Get-CFGResourceConfigHistory")
    "ConfigRule_ConfigRuleState"=@("Write-CFGConfigRule")
    "ConfigRule_MaximumExecutionFrequency"=@("Write-CFGConfigRule")
    "ConfigRule_Source_Owner"=@("Write-CFGConfigRule")
    "DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency"=@("Write-CFGDeliveryChannel")
    "ResourceType"=@("Get-CFGDiscoveredResource","Get-CFGResourceConfigHistory")
}

_awsArgumentCompleterRegistration $CFG_Completers $CFG_map


# Argument completions for service AWS Cost and Usage Report
$CUR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CostAndUsageReport.AWSRegion
        "Write-CURReportDefinition/ReportDefinition_S3Region"
        {
            $v = "ap-northeast-1","ap-southeast-1","ap-southeast-2","eu-central-1","eu-west-1","us-east-1","us-west-1","us-west-2"
            break
        }
        
        # Amazon.CostAndUsageReport.CompressionFormat
        "Write-CURReportDefinition/ReportDefinition_Compression"
        {
            $v = "GZIP","ZIP"
            break
        }
        
        # Amazon.CostAndUsageReport.ReportFormat
        "Write-CURReportDefinition/ReportDefinition_Format"
        {
            $v = "textORcsv"
            break
        }
        
        # Amazon.CostAndUsageReport.TimeUnit
        "Write-CURReportDefinition/ReportDefinition_TimeUnit"
        {
            $v = "DAILY","HOURLY"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CUR_map = @{
    "ReportDefinition_Compression"=@("Write-CURReportDefinition")
    "ReportDefinition_Format"=@("Write-CURReportDefinition")
    "ReportDefinition_S3Region"=@("Write-CURReportDefinition")
    "ReportDefinition_TimeUnit"=@("Write-CURReportDefinition")
}

_awsArgumentCompleterRegistration $CUR_Completers $CUR_map


# Argument completions for service AWS Database Migration Service
$DMS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DatabaseMigrationService.AuthMechanismValue
        {
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_AuthMechanism") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_AuthMechanism")
        }
        {
            $v = "default","mongodb_cr","scram_sha_1"
            break
        }
        
        # Amazon.DatabaseMigrationService.AuthTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_AuthType") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_AuthType")
        }
        {
            $v = "no","password"
            break
        }
        
        # Amazon.DatabaseMigrationService.CompressionTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_CompressionType") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_CompressionType")
        }
        {
            $v = "gzip","none"
            break
        }
        
        # Amazon.DatabaseMigrationService.DmsSslModeValue
        {
            ($_ -eq "Edit-DMSEndpoint/SslMode") -Or
            ($_ -eq "New-DMSEndpoint/SslMode")
        }
        {
            $v = "none","require","verify-ca","verify-full"
            break
        }
        
        # Amazon.DatabaseMigrationService.MigrationTypeValue
        {
            ($_ -eq "Edit-DMSReplicationTask/MigrationType") -Or
            ($_ -eq "New-DMSReplicationTask/MigrationType")
        }
        {
            $v = "cdc","full-load","full-load-and-cdc"
            break
        }
        
        # Amazon.DatabaseMigrationService.NestingLevelValue
        {
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_NestingLevel") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_NestingLevel")
        }
        {
            $v = "none","one"
            break
        }
        
        # Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/EndpointType") -Or
            ($_ -eq "New-DMSEndpoint/EndpointType")
        }
        {
            $v = "source","target"
            break
        }
        
        # Amazon.DatabaseMigrationService.SourceType
        "Get-DMSEvent/SourceType"
        {
            $v = "replication-instance"
            break
        }
        
        # Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue
        "Start-DMSReplicationTask/StartReplicationTaskType"
        {
            $v = "reload-target","resume-processing","start-replication"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DMS_map = @{
    "EndpointType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MigrationType"=@("Edit-DMSReplicationTask","New-DMSReplicationTask")
    "MongoDbSettings_AuthMechanism"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MongoDbSettings_AuthType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MongoDbSettings_NestingLevel"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_CompressionType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "SourceType"=@("Get-DMSEvent")
    "SslMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "StartReplicationTaskType"=@("Start-DMSReplicationTask")
}

_awsArgumentCompleterRegistration $DMS_Completers $DMS_map


# Argument completions for service AWS Data Pipeline
$DP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DataPipeline.TaskStatus
        "Set-DPTaskStatus/TaskStatus"
        {
            $v = "FAILED","FALSE","FINISHED"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DP_map = @{
    "TaskStatus"=@("Set-DPTaskStatus")
}

_awsArgumentCompleterRegistration $DP_Completers $DP_map


# Argument completions for service Amazon DynamoDB Accelerator (DAX)
$DAX_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DAX.SourceType
        "Get-DAXEvent/SourceType"
        {
            $v = "CLUSTER","PARAMETER_GROUP","SUBNET_GROUP"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DAX_map = @{
    "SourceType"=@("Get-DAXEvent")
}

_awsArgumentCompleterRegistration $DAX_Completers $DAX_map


# Argument completions for service AWS Device Farm
$DF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DeviceFarm.ArtifactCategory
        "Get-DFArtifactList/Type"
        {
            $v = "FILE","LOG","SCREENSHOT"
            break
        }
        
        # Amazon.DeviceFarm.BillingMethod
        {
            ($_ -eq "New-DFRemoteAccessSession/Configuration_BillingMethod") -Or
            ($_ -eq "Submit-DFTestRun/Configuration_BillingMethod")
        }
        {
            $v = "METERED","UNMETERED"
            break
        }
        
        # Amazon.DeviceFarm.DevicePoolType
        "Get-DFDevicePoolList/Type"
        {
            $v = "CURATED","PRIVATE"
            break
        }
        
        # Amazon.DeviceFarm.NetworkProfileType
        {
            ($_ -eq "Get-DFNetworkProfileList/Type") -Or
            ($_ -eq "New-DFNetworkProfile/Type") -Or
            ($_ -eq "Update-DFNetworkProfile/Type")
        }
        {
            $v = "CURATED","PRIVATE"
            break
        }
        
        # Amazon.DeviceFarm.TestType
        {
            ($_ -eq "Get-DFDevicePoolCompatibility/Test_Type") -Or
            ($_ -eq "Submit-DFTestRun/Test_Type") -Or
            ($_ -eq "Get-DFDevicePoolCompatibility/TestType")
        }
        {
            $v = "APPIUM_JAVA_JUNIT","APPIUM_JAVA_TESTNG","APPIUM_PYTHON","APPIUM_WEB_JAVA_JUNIT","APPIUM_WEB_JAVA_TESTNG","APPIUM_WEB_PYTHON","BUILTIN_EXPLORER","BUILTIN_FUZZ","CALABASH","INSTRUMENTATION","UIAUTOMATION","UIAUTOMATOR","XCTEST","XCTEST_UI"
            break
        }
        
        # Amazon.DeviceFarm.UploadType
        "New-DFUpload/Type"
        {
            $v = "ANDROID_APP","APPIUM_JAVA_JUNIT_TEST_PACKAGE","APPIUM_JAVA_TESTNG_TEST_PACKAGE","APPIUM_PYTHON_TEST_PACKAGE","APPIUM_WEB_JAVA_JUNIT_TEST_PACKAGE","APPIUM_WEB_JAVA_TESTNG_TEST_PACKAGE","APPIUM_WEB_PYTHON_TEST_PACKAGE","CALABASH_TEST_PACKAGE","EXTERNAL_DATA","INSTRUMENTATION_TEST_PACKAGE","IOS_APP","UIAUTOMATION_TEST_PACKAGE","UIAUTOMATOR_TEST_PACKAGE","WEB_APP","XCTEST_TEST_PACKAGE","XCTEST_UI_TEST_PACKAGE"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DF_map = @{
    "Configuration_BillingMethod"=@("New-DFRemoteAccessSession","Submit-DFTestRun")
    "Test_Type"=@("Get-DFDevicePoolCompatibility","Submit-DFTestRun")
    "TestType"=@("Get-DFDevicePoolCompatibility")
    "Type"=@("Get-DFArtifactList","Get-DFDevicePoolList","Get-DFNetworkProfileList","New-DFNetworkProfile","New-DFUpload","Update-DFNetworkProfile")
}

_awsArgumentCompleterRegistration $DF_Completers $DF_map


# Argument completions for service AWS Direct Connect
$DC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DirectConnect.AddressFamily
        {
            ($_ -eq "New-DCBGPPeer/NewBGPPeer_AddressFamily") -Or
            ($_ -eq "New-DCPrivateVirtualInterface/NewPrivateVirtualInterface_AddressFamily") -Or
            ($_ -eq "Enable-DCPrivateVirtualInterface/NewPrivateVirtualInterfaceAllocation_AddressFamily") -Or
            ($_ -eq "New-DCPublicVirtualInterface/NewPublicVirtualInterface_AddressFamily") -Or
            ($_ -eq "Enable-DCPublicVirtualInterface/NewPublicVirtualInterfaceAllocation_AddressFamily")
        }
        {
            $v = "ipv4","ipv6"
            break
        }
        
        # Amazon.DirectConnect.LoaContentType
        {
            ($_ -eq "Get-DCConnectionLoa/LoaContentType") -Or
            ($_ -eq "Get-DCInterconnectLoa/LoaContentType") -Or
            ($_ -eq "Get-DCLoa/LoaContentType")
        }
        {
            $v = "application/pdf"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DC_map = @{
    "LoaContentType"=@("Get-DCConnectionLoa","Get-DCInterconnectLoa","Get-DCLoa")
    "NewBGPPeer_AddressFamily"=@("New-DCBGPPeer")
    "NewPrivateVirtualInterface_AddressFamily"=@("New-DCPrivateVirtualInterface")
    "NewPrivateVirtualInterfaceAllocation_AddressFamily"=@("Enable-DCPrivateVirtualInterface")
    "NewPublicVirtualInterface_AddressFamily"=@("New-DCPublicVirtualInterface")
    "NewPublicVirtualInterfaceAllocation_AddressFamily"=@("Enable-DCPublicVirtualInterface")
}

_awsArgumentCompleterRegistration $DC_Completers $DC_map


# Argument completions for service AWS Directory Service
$DS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DirectoryService.DirectorySize
        {
            ($_ -eq "Connect-DSDirectory/Size") -Or
            ($_ -eq "New-DSDirectory/Size")
        }
        {
            $v = "Large","Small"
            break
        }
        
        # Amazon.DirectoryService.RadiusAuthenticationProtocol
        {
            ($_ -eq "Enable-DSRadius/RadiusSettings_AuthenticationProtocol") -Or
            ($_ -eq "Update-DSRadius/RadiusSettings_AuthenticationProtocol")
        }
        {
            $v = "CHAP","MS-CHAPv1","MS-CHAPv2","PAP"
            break
        }
        
        # Amazon.DirectoryService.TrustDirection
        "New-DSTrust/TrustDirection"
        {
            $v = "One-Way: Incoming","One-Way: Outgoing","Two-Way"
            break
        }
        
        # Amazon.DirectoryService.TrustType
        "New-DSTrust/TrustType"
        {
            $v = "Forest"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DS_map = @{
    "RadiusSettings_AuthenticationProtocol"=@("Enable-DSRadius","Update-DSRadius")
    "Size"=@("Connect-DSDirectory","New-DSDirectory")
    "TrustDirection"=@("New-DSTrust")
    "TrustType"=@("New-DSTrust")
}

_awsArgumentCompleterRegistration $DS_Completers $DS_map


# Argument completions for service Amazon DynamoDB
$DDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DynamoDBv2.KeyType
        "Add-DDBKeySchema/KeyType"
        {
            $v = "HASH","RANGE"
            break
        }
        
        # Amazon.DynamoDBv2.ProjectionType
        "Add-DDBIndexSchema/ProjectionType"
        {
            $v = "ALL","INCLUDE","KEYS_ONLY"
            break
        }
        
        # Amazon.DynamoDBv2.ScalarAttributeType
        {
            ($_ -eq "Add-DDBIndexSchema/HashKeyDataType") -Or
            ($_ -eq "Add-DDBKeySchema/KeyDataType") -Or
            ($_ -eq "Add-DDBIndexSchema/RangeKeyDataType")
        }
        {
            $v = "B","N","S"
            break
        }
        
        # Amazon.DynamoDBv2.StreamViewType
        "Update-DDBTable/StreamSpecification_StreamViewType"
        {
            $v = "KEYS_ONLY","NEW_AND_OLD_IMAGES","NEW_IMAGE","OLD_IMAGE"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DDB_map = @{
    "HashKeyDataType"=@("Add-DDBIndexSchema")
    "KeyDataType"=@("Add-DDBKeySchema")
    "KeyType"=@("Add-DDBKeySchema")
    "ProjectionType"=@("Add-DDBIndexSchema")
    "RangeKeyDataType"=@("Add-DDBIndexSchema")
    "StreamSpecification_StreamViewType"=@("Update-DDBTable")
}

_awsArgumentCompleterRegistration $DDB_Completers $DDB_map


# Argument completions for service Amazon Elastic Compute Cloud
$EC2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EC2.Affinity
        "Edit-EC2InstancePlacement/Affinity"
        {
            $v = "default","host"
            break
        }
        
        # Amazon.EC2.AllocationStrategy
        "Request-EC2SpotFleet/SpotFleetRequestConfig_AllocationStrategy"
        {
            $v = "diversified","lowestPrice"
            break
        }
        
        # Amazon.EC2.ArchitectureValues
        "Register-EC2Image/Architecture"
        {
            $v = "i386","x86_64"
            break
        }
        
        # Amazon.EC2.AutoPlacement
        {
            ($_ -eq "Edit-EC2Host/AutoPlacement") -Or
            ($_ -eq "New-EC2Host/AutoPlacement")
        }
        {
            $v = "off","on"
            break
        }
        
        # Amazon.EC2.ContainerFormat
        "New-EC2InstanceExportTask/ExportToS3Task_ContainerFormat"
        {
            $v = "ova"
            break
        }
        
        # Amazon.EC2.CurrencyCodeValues
        {
            ($_ -eq "New-EC2HostReservation/CurrencyCode") -Or
            ($_ -eq "New-EC2ReservedInstance/LimitPrice_CurrencyCode")
        }
        {
            $v = "USD"
            break
        }
        
        # Amazon.EC2.DiskImageFormat
        "New-EC2InstanceExportTask/ExportToS3Task_DiskImageFormat"
        {
            $v = "RAW","VHD","VMDK"
            break
        }
        
        # Amazon.EC2.DomainType
        "New-EC2Address/Domain"
        {
            $v = "standard","vpc"
            break
        }
        
        # Amazon.EC2.EventType
        "Get-EC2SpotFleetRequestHistory/EventType"
        {
            $v = "error","fleetRequestChange","instanceChange"
            break
        }
        
        # Amazon.EC2.ExcessCapacityTerminationPolicy
        {
            ($_ -eq "Edit-EC2SpotFleetRequest/ExcessCapacityTerminationPolicy") -Or
            ($_ -eq "Request-EC2SpotFleet/SpotFleetRequestConfig_ExcessCapacityTerminationPolicy")
        }
        {
            $v = "default","noTermination"
            break
        }
        
        # Amazon.EC2.ExportEnvironment
        "New-EC2InstanceExportTask/TargetEnvironment"
        {
            $v = "citrix","microsoft","vmware"
            break
        }
        
        # Amazon.EC2.FleetType
        "Request-EC2SpotFleet/SpotFleetRequestConfig_Type"
        {
            $v = "maintain","request"
            break
        }
        
        # Amazon.EC2.FlowLogsResourceType
        "New-EC2FlowLog/ResourceType"
        {
            $v = "NetworkInterface","Subnet","VPC"
            break
        }
        
        # Amazon.EC2.FpgaImageAttributeName
        {
            ($_ -eq "Edit-EC2FpgaImageAttribute/Attribute") -Or
            ($_ -eq "Get-EC2FpgaImageAttribute/Attribute")
        }
        {
            $v = "description","loadPermission","name","productCodes"
            break
        }
        
        # Amazon.EC2.GatewayType
        {
            ($_ -eq "New-EC2CustomerGateway/Type") -Or
            ($_ -eq "New-EC2VpnGateway/Type")
        }
        {
            $v = "ipsec.1"
            break
        }
        
        # Amazon.EC2.HostTenancy
        "Edit-EC2InstancePlacement/Tenancy"
        {
            $v = "dedicated","host"
            break
        }
        
        # Amazon.EC2.ImageAttributeName
        "Get-EC2ImageAttribute/Attribute"
        {
            $v = "blockDeviceMapping","description","kernel","launchPermission","productCodes","ramdisk","sriovNetSupport"
            break
        }
        
        # Amazon.EC2.InstanceAttributeName
        {
            ($_ -eq "Edit-EC2InstanceAttribute/Attribute") -Or
            ($_ -eq "Get-EC2InstanceAttribute/Attribute") -Or
            ($_ -eq "Reset-EC2InstanceAttribute/Attribute")
        }
        {
            $v = "blockDeviceMapping","disableApiTermination","ebsOptimized","enaSupport","groupSet","instanceInitiatedShutdownBehavior","instanceType","kernel","productCodes","ramdisk","rootDeviceName","sourceDestCheck","sriovNetSupport","userData"
            break
        }
        
        # Amazon.EC2.InstanceInterruptionBehavior
        {
            ($_ -eq "Request-EC2SpotInstance/InstanceInterruptionBehavior") -Or
            ($_ -eq "Request-EC2SpotFleet/SpotFleetRequestConfig_InstanceInterruptionBehavior")
        }
        {
            $v = "stop","terminate"
            break
        }
        
        # Amazon.EC2.InstanceType
        {
            ($_ -eq "Get-EC2ReservedInstancesOffering/InstanceType") -Or
            ($_ -eq "New-EC2Instance/InstanceType") -Or
            ($_ -eq "Request-EC2SpotInstance/LaunchSpecification_InstanceType")
        }
        {
            $v = "c1.medium","c1.xlarge","c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","cc1.4xlarge","cc2.8xlarge","cg1.4xlarge","cr1.8xlarge","d2.2xlarge","d2.4xlarge","d2.8xlarge","d2.xlarge","f1.16xlarge","f1.2xlarge","g2.2xlarge","g2.8xlarge","g3.16xlarge","g3.4xlarge","g3.8xlarge","hi1.4xlarge","hs1.8xlarge","i2.2xlarge","i2.4xlarge","i2.8xlarge","i2.xlarge","i3.16xlarge","i3.2xlarge","i3.4xlarge","i3.8xlarge","i3.large","i3.xlarge","m1.large","m1.medium","m1.small","m1.xlarge","m2.2xlarge","m2.4xlarge","m2.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.16xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","p2.16xlarge","p2.8xlarge","p2.xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","r4.16xlarge","r4.2xlarge","r4.4xlarge","r4.8xlarge","r4.large","r4.xlarge","t1.micro","t2.2xlarge","t2.large","t2.medium","t2.micro","t2.nano","t2.small","t2.xlarge","x1.16xlarge","x1.32xlarge","x1e.32xlarge"
            break
        }
        
        # Amazon.EC2.InterfacePermissionType
        "New-EC2NetworkInterfacePermission/Permission"
        {
            $v = "EIP-ASSOCIATE","INSTANCE-ATTACH"
            break
        }
        
        # Amazon.EC2.NetworkInterfaceAttribute
        "Get-EC2NetworkInterfaceAttribute/Attribute"
        {
            $v = "attachment","description","groupSet","sourceDestCheck"
            break
        }
        
        # Amazon.EC2.OfferingClassType
        {
            ($_ -eq "Get-EC2ReservedInstance/OfferingClass") -Or
            ($_ -eq "Get-EC2ReservedInstancesOffering/OfferingClass")
        }
        {
            $v = "convertible","standard"
            break
        }
        
        # Amazon.EC2.OfferingTypeValues
        {
            ($_ -eq "Get-EC2ReservedInstance/OfferingType") -Or
            ($_ -eq "Get-EC2ReservedInstancesOffering/OfferingType")
        }
        {
            $v = "All Upfront","Heavy Utilization","Light Utilization","Medium Utilization","No Upfront","Partial Upfront"
            break
        }
        
        # Amazon.EC2.OperationType
        {
            ($_ -eq "Edit-EC2FpgaImageAttribute/OperationType") -Or
            ($_ -eq "Edit-EC2ImageAttribute/OperationType") -Or
            ($_ -eq "Edit-EC2SnapshotAttribute/OperationType")
        }
        {
            $v = "add","remove"
            break
        }
        
        # Amazon.EC2.PlacementStrategy
        "New-EC2PlacementGroup/Strategy"
        {
            $v = "cluster"
            break
        }
        
        # Amazon.EC2.ReportStatusType
        "Send-EC2InstanceStatus/Status"
        {
            $v = "impaired","ok"
            break
        }
        
        # Amazon.EC2.ResetFpgaImageAttributeName
        "Reset-EC2FpgaImageAttribute/Attribute"
        {
            $v = "loadPermission"
            break
        }
        
        # Amazon.EC2.ResetImageAttributeName
        "Reset-EC2ImageAttribute/Attribute"
        {
            $v = "launchPermission"
            break
        }
        
        # Amazon.EC2.RIProductDescription
        "Get-EC2ReservedInstancesOffering/ProductDescription"
        {
            $v = "Linux/UNIX","Linux/UNIX (Amazon VPC)","Windows","Windows (Amazon VPC)"
            break
        }
        
        # Amazon.EC2.RuleAction
        {
            ($_ -eq "New-EC2NetworkAclEntry/RuleAction") -Or
            ($_ -eq "Set-EC2NetworkAclEntry/RuleAction")
        }
        {
            $v = "allow","deny"
            break
        }
        
        # Amazon.EC2.ShutdownBehavior
        "New-EC2Instance/InstanceInitiatedShutdownBehavior"
        {
            $v = "stop","terminate"
            break
        }
        
        # Amazon.EC2.SnapshotAttributeName
        {
            ($_ -eq "Edit-EC2SnapshotAttribute/Attribute") -Or
            ($_ -eq "Get-EC2SnapshotAttribute/Attribute") -Or
            ($_ -eq "Reset-EC2SnapshotAttribute/Attribute")
        }
        {
            $v = "createVolumePermission","productCodes"
            break
        }
        
        # Amazon.EC2.SpotInstanceType
        "Request-EC2SpotInstance/Type"
        {
            $v = "one-time","persistent"
            break
        }
        
        # Amazon.EC2.Tenancy
        {
            ($_ -eq "Get-EC2ReservedInstancesOffering/InstanceTenancy") -Or
            ($_ -eq "New-EC2Vpc/InstanceTenancy") -Or
            ($_ -eq "Request-EC2SpotInstance/LaunchSpecification_Placement_Tenancy") -Or
            ($_ -eq "New-EC2Instance/Tenancy")
        }
        {
            $v = "dedicated","default","host"
            break
        }
        
        # Amazon.EC2.TrafficType
        "New-EC2FlowLog/TrafficType"
        {
            $v = "ACCEPT","ALL","REJECT"
            break
        }
        
        # Amazon.EC2.VolumeAttributeName
        "Get-EC2VolumeAttribute/Attribute"
        {
            $v = "autoEnableIO","productCodes"
            break
        }
        
        # Amazon.EC2.VolumeType
        {
            ($_ -eq "Edit-EC2Volume/VolumeType") -Or
            ($_ -eq "New-EC2Volume/VolumeType")
        }
        {
            $v = "gp2","io1","sc1","st1","standard"
            break
        }
        
        # Amazon.EC2.VpcAttributeName
        "Get-EC2VpcAttribute/Attribute"
        {
            $v = "enableDnsHostnames","enableDnsSupport"
            break
        }
        
        # Amazon.EC2.VpcTenancy
        "Edit-EC2VpcTenancy/InstanceTenancy"
        {
            $v = "default"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EC2_map = @{
    "Affinity"=@("Edit-EC2InstancePlacement")
    "Architecture"=@("Register-EC2Image")
    "Attribute"=@("Edit-EC2FpgaImageAttribute","Edit-EC2InstanceAttribute","Edit-EC2SnapshotAttribute","Get-EC2FpgaImageAttribute","Get-EC2ImageAttribute","Get-EC2InstanceAttribute","Get-EC2NetworkInterfaceAttribute","Get-EC2SnapshotAttribute","Get-EC2VolumeAttribute","Get-EC2VpcAttribute","Reset-EC2FpgaImageAttribute","Reset-EC2ImageAttribute","Reset-EC2InstanceAttribute","Reset-EC2SnapshotAttribute")
    "AutoPlacement"=@("Edit-EC2Host","New-EC2Host")
    "CurrencyCode"=@("New-EC2HostReservation")
    "Domain"=@("New-EC2Address")
    "EventType"=@("Get-EC2SpotFleetRequestHistory")
    "ExcessCapacityTerminationPolicy"=@("Edit-EC2SpotFleetRequest")
    "ExportToS3Task_ContainerFormat"=@("New-EC2InstanceExportTask")
    "ExportToS3Task_DiskImageFormat"=@("New-EC2InstanceExportTask")
    "InstanceInitiatedShutdownBehavior"=@("New-EC2Instance")
    "InstanceInterruptionBehavior"=@("Request-EC2SpotInstance")
    "InstanceTenancy"=@("Edit-EC2VpcTenancy","Get-EC2ReservedInstancesOffering","New-EC2Vpc")
    "InstanceType"=@("Get-EC2ReservedInstancesOffering","New-EC2Instance")
    "LaunchSpecification_InstanceType"=@("Request-EC2SpotInstance")
    "LaunchSpecification_Placement_Tenancy"=@("Request-EC2SpotInstance")
    "LimitPrice_CurrencyCode"=@("New-EC2ReservedInstance")
    "OfferingClass"=@("Get-EC2ReservedInstance","Get-EC2ReservedInstancesOffering")
    "OfferingType"=@("Get-EC2ReservedInstance","Get-EC2ReservedInstancesOffering")
    "OperationType"=@("Edit-EC2FpgaImageAttribute","Edit-EC2ImageAttribute","Edit-EC2SnapshotAttribute")
    "Permission"=@("New-EC2NetworkInterfacePermission")
    "ProductDescription"=@("Get-EC2ReservedInstancesOffering")
    "ResourceType"=@("New-EC2FlowLog")
    "RuleAction"=@("New-EC2NetworkAclEntry","Set-EC2NetworkAclEntry")
    "SpotFleetRequestConfig_AllocationStrategy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_ExcessCapacityTerminationPolicy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_InstanceInterruptionBehavior"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_Type"=@("Request-EC2SpotFleet")
    "Status"=@("Send-EC2InstanceStatus")
    "Strategy"=@("New-EC2PlacementGroup")
    "TargetEnvironment"=@("New-EC2InstanceExportTask")
    "Tenancy"=@("Edit-EC2InstancePlacement","New-EC2Instance")
    "TrafficType"=@("New-EC2FlowLog")
    "Type"=@("New-EC2CustomerGateway","New-EC2VpnGateway","Request-EC2SpotInstance")
    "VolumeType"=@("Edit-EC2Volume","New-EC2Volume")
}

_awsArgumentCompleterRegistration $EC2_Completers $EC2_map


# Argument completions for service Amazon EC2 Container Registry
$ECR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ECR.TagStatus
        {
            ($_ -eq "Get-ECRImage/Filter_TagStatus") -Or
            ($_ -eq "Get-ECRImageMetadata/Filter_TagStatus") -Or
            ($_ -eq "Get-ECRLifecyclePolicyPreview/Filter_TagStatus")
        }
        {
            $v = "TAGGED","UNTAGGED"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ECR_map = @{
    "Filter_TagStatus"=@("Get-ECRImage","Get-ECRImageMetadata","Get-ECRLifecyclePolicyPreview")
}

_awsArgumentCompleterRegistration $ECR_Completers $ECR_map


# Argument completions for service Amazon EC2 Container Service
$ECS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ECS.ContainerInstanceStatus
        {
            ($_ -eq "Get-ECSContainerInstanceList/Status") -Or
            ($_ -eq "Update-ECSContainerInstancesState/Status")
        }
        {
            $v = "ACTIVE","DRAINING"
            break
        }
        
        # Amazon.ECS.DesiredStatus
        "Get-ECSTaskList/DesiredStatus"
        {
            $v = "PENDING","RUNNING","STOPPED"
            break
        }
        
        # Amazon.ECS.NetworkMode
        "Register-ECSTaskDefinition/NetworkMode"
        {
            $v = "bridge","host","none"
            break
        }
        
        # Amazon.ECS.SortOrder
        "Get-ECSTaskDefinitionList/Sort"
        {
            $v = "ASC","DESC"
            break
        }
        
        # Amazon.ECS.TargetType
        "Get-ECSAttributeList/TargetType"
        {
            $v = "container-instance"
            break
        }
        
        # Amazon.ECS.TaskDefinitionFamilyStatus
        "Get-ECSTaskDefinitionFamilyList/Status"
        {
            $v = "ACTIVE","ALL","INACTIVE"
            break
        }
        
        # Amazon.ECS.TaskDefinitionStatus
        "Get-ECSTaskDefinitionList/Status"
        {
            $v = "ACTIVE","INACTIVE"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ECS_map = @{
    "DesiredStatus"=@("Get-ECSTaskList")
    "NetworkMode"=@("Register-ECSTaskDefinition")
    "Sort"=@("Get-ECSTaskDefinitionList")
    "Status"=@("Get-ECSContainerInstanceList","Get-ECSTaskDefinitionFamilyList","Get-ECSTaskDefinitionList","Update-ECSContainerInstancesState")
    "TargetType"=@("Get-ECSAttributeList")
}

_awsArgumentCompleterRegistration $ECS_Completers $ECS_map


# Argument completions for service Amazon Elastic File System
$EFS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticFileSystem.PerformanceMode
        "New-EFSFileSystem/PerformanceMode"
        {
            $v = "generalPurpose","maxIO"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EFS_map = @{
    "PerformanceMode"=@("New-EFSFileSystem")
}

_awsArgumentCompleterRegistration $EFS_Completers $EFS_map


# Argument completions for service Amazon ElastiCache
$EC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElastiCache.AZMode
        {
            ($_ -eq "Edit-ECCacheCluster/AZMode") -Or
            ($_ -eq "New-ECCacheCluster/AZMode")
        }
        {
            $v = "cross-az","single-az"
            break
        }
        
        # Amazon.ElastiCache.SourceType
        "Get-ECEvent/SourceType"
        {
            $v = "cache-cluster","cache-parameter-group","cache-security-group","cache-subnet-group","replication-group"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EC_map = @{
    "AZMode"=@("Edit-ECCacheCluster","New-ECCacheCluster")
    "SourceType"=@("Get-ECEvent")
}

_awsArgumentCompleterRegistration $EC_Completers $EC_map


# Argument completions for service Elastic Load Balancing V2
$ELB2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticLoadBalancingV2.IpAddressType
        {
            ($_ -eq "New-ELB2LoadBalancer/IpAddressType") -Or
            ($_ -eq "Set-ELB2IpAddressType/IpAddressType")
        }
        {
            $v = "dualstack","ipv4"
            break
        }
        
        # Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum
        "New-ELB2LoadBalancer/Scheme"
        {
            $v = "internal","internet-facing"
            break
        }
        
        # Amazon.ElasticLoadBalancingV2.LoadBalancerTypeEnum
        "New-ELB2LoadBalancer/Type"
        {
            $v = "application","network"
            break
        }
        
        # Amazon.ElasticLoadBalancingV2.ProtocolEnum
        {
            ($_ -eq "Edit-ELB2TargetGroup/HealthCheckProtocol") -Or
            ($_ -eq "New-ELB2TargetGroup/HealthCheckProtocol") -Or
            ($_ -eq "Edit-ELB2Listener/Protocol") -Or
            ($_ -eq "New-ELB2Listener/Protocol") -Or
            ($_ -eq "New-ELB2TargetGroup/Protocol")
        }
        {
            $v = "HTTP","HTTPS","TCP"
            break
        }
        
        # Amazon.ElasticLoadBalancingV2.TargetTypeEnum
        "New-ELB2TargetGroup/TargetType"
        {
            $v = "instance","ip"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ELB2_map = @{
    "HealthCheckProtocol"=@("Edit-ELB2TargetGroup","New-ELB2TargetGroup")
    "IpAddressType"=@("New-ELB2LoadBalancer","Set-ELB2IpAddressType")
    "Protocol"=@("Edit-ELB2Listener","New-ELB2Listener","New-ELB2TargetGroup")
    "Scheme"=@("New-ELB2LoadBalancer")
    "TargetType"=@("New-ELB2TargetGroup")
    "Type"=@("New-ELB2LoadBalancer")
}

_awsArgumentCompleterRegistration $ELB2_Completers $ELB2_map


# Argument completions for service Amazon Elastic MapReduce
$EMR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticMapReduce.InstanceFleetType
        {
            ($_ -eq "Add-EMRInstanceFleet/InstanceFleet_InstanceFleetType") -Or
            ($_ -eq "Get-EMRInstanceList/InstanceFleetType")
        }
        {
            $v = "CORE","MASTER","TASK"
            break
        }
        
        # Amazon.ElasticMapReduce.RepoUpgradeOnBoot
        "Start-EMRJobFlow/RepoUpgradeOnBoot"
        {
            $v = "NONE","SECURITY"
            break
        }
        
        # Amazon.ElasticMapReduce.ScaleDownBehavior
        "Start-EMRJobFlow/ScaleDownBehavior"
        {
            $v = "TERMINATE_AT_INSTANCE_HOUR","TERMINATE_AT_TASK_COMPLETION"
            break
        }
        
        # Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction
        "Add-EMRInstanceFleet/InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction"
        {
            $v = "SWITCH_TO_ON_DEMAND","TERMINATE_CLUSTER"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMR_map = @{
    "InstanceFleet_InstanceFleetType"=@("Add-EMRInstanceFleet")
    "InstanceFleet_LaunchSpecifications_SpotSpecification_TimeoutAction"=@("Add-EMRInstanceFleet")
    "InstanceFleetType"=@("Get-EMRInstanceList")
    "RepoUpgradeOnBoot"=@("Start-EMRJobFlow")
    "ScaleDownBehavior"=@("Start-EMRJobFlow")
}

_awsArgumentCompleterRegistration $EMR_Completers $EMR_map


# Argument completions for service Amazon Elasticsearch
$ES_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Elasticsearch.ESPartitionInstanceType
        {
            ($_ -eq "New-ESDomain/ElasticsearchClusterConfig_DedicatedMasterType") -Or
            ($_ -eq "Update-ESDomainConfig/ElasticsearchClusterConfig_DedicatedMasterType") -Or
            ($_ -eq "New-ESDomain/ElasticsearchClusterConfig_InstanceType") -Or
            ($_ -eq "Update-ESDomainConfig/ElasticsearchClusterConfig_InstanceType") -Or
            ($_ -eq "Get-ESInstanceTypeLimit/InstanceType")
        }
        {
            $v = "c4.2xlarge.elasticsearch","c4.4xlarge.elasticsearch","c4.8xlarge.elasticsearch","c4.large.elasticsearch","c4.xlarge.elasticsearch","d2.2xlarge.elasticsearch","d2.4xlarge.elasticsearch","d2.8xlarge.elasticsearch","d2.xlarge.elasticsearch","i2.2xlarge.elasticsearch","i2.xlarge.elasticsearch","m3.2xlarge.elasticsearch","m3.large.elasticsearch","m3.medium.elasticsearch","m3.xlarge.elasticsearch","m4.10xlarge.elasticsearch","m4.2xlarge.elasticsearch","m4.4xlarge.elasticsearch","m4.large.elasticsearch","m4.xlarge.elasticsearch","r3.2xlarge.elasticsearch","r3.4xlarge.elasticsearch","r3.8xlarge.elasticsearch","r3.large.elasticsearch","r3.xlarge.elasticsearch","r4.16xlarge.elasticsearch","r4.2xlarge.elasticsearch","r4.4xlarge.elasticsearch","r4.8xlarge.elasticsearch","r4.large.elasticsearch","r4.xlarge.elasticsearch","t2.medium.elasticsearch","t2.micro.elasticsearch","t2.small.elasticsearch"
            break
        }
        
        # Amazon.Elasticsearch.VolumeType
        {
            ($_ -eq "New-ESDomain/EBSOptions_VolumeType") -Or
            ($_ -eq "Update-ESDomainConfig/EBSOptions_VolumeType")
        }
        {
            $v = "gp2","io1","standard"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ES_map = @{
    "EBSOptions_VolumeType"=@("New-ESDomain","Update-ESDomainConfig")
    "ElasticsearchClusterConfig_DedicatedMasterType"=@("New-ESDomain","Update-ESDomainConfig")
    "ElasticsearchClusterConfig_InstanceType"=@("New-ESDomain","Update-ESDomainConfig")
    "InstanceType"=@("Get-ESInstanceTypeLimit")
}

_awsArgumentCompleterRegistration $ES_Completers $ES_map


# Argument completions for service Amazon GameLift Service
$GML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GameLift.AcceptanceType
        "Confirm-GMLMatch/AcceptanceType"
        {
            $v = "ACCEPT","REJECT"
            break
        }
        
        # Amazon.GameLift.BuildStatus
        "Get-GMLBuild/Status"
        {
            $v = "FAILED","INITIALIZED","READY"
            break
        }
        
        # Amazon.GameLift.ComparisonOperatorType
        "Write-GMLScalingPolicy/ComparisonOperator"
        {
            $v = "GreaterThanOrEqualToThreshold","GreaterThanThreshold","LessThanOrEqualToThreshold","LessThanThreshold"
            break
        }
        
        # Amazon.GameLift.EC2InstanceType
        {
            ($_ -eq "Get-GMLEC2InstanceLimit/EC2InstanceType") -Or
            ($_ -eq "New-GMLFleet/EC2InstanceType")
        }
        {
            $v = "c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","r4.16xlarge","r4.2xlarge","r4.4xlarge","r4.8xlarge","r4.large","r4.xlarge","t2.large","t2.medium","t2.micro","t2.small"
            break
        }
        
        # Amazon.GameLift.MetricName
        "Write-GMLScalingPolicy/MetricName"
        {
            $v = "ActivatingGameSessions","ActiveGameSessions","ActiveInstances","AvailableGameSessions","AvailablePlayerSessions","CurrentPlayerSessions","IdleInstances","PercentAvailableGameSessions","PercentIdleInstances","QueueDepth","WaitTime"
            break
        }
        
        # Amazon.GameLift.OperatingSystem
        "New-GMLBuild/OperatingSystem"
        {
            $v = "AMAZON_LINUX","WINDOWS_2012"
            break
        }
        
        # Amazon.GameLift.PlayerSessionCreationPolicy
        "Update-GMLGameSession/PlayerSessionCreationPolicy"
        {
            $v = "ACCEPT_ALL","DENY_ALL"
            break
        }
        
        # Amazon.GameLift.ProtectionPolicy
        {
            ($_ -eq "New-GMLFleet/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLFleetAttribute/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLGameSession/ProtectionPolicy")
        }
        {
            $v = "FullProtection","NoProtection"
            break
        }
        
        # Amazon.GameLift.RoutingStrategyType
        {
            ($_ -eq "New-GMLAlias/RoutingStrategy_Type") -Or
            ($_ -eq "Update-GMLAlias/RoutingStrategy_Type") -Or
            ($_ -eq "Get-GMLAlias/RoutingStrategyType")
        }
        {
            $v = "SIMPLE","TERMINAL"
            break
        }
        
        # Amazon.GameLift.ScalingAdjustmentType
        "Write-GMLScalingPolicy/ScalingAdjustmentType"
        {
            $v = "ChangeInCapacity","ExactCapacity","PercentChangeInCapacity"
            break
        }
        
        # Amazon.GameLift.ScalingStatusType
        "Get-GMLScalingPolicy/StatusFilter"
        {
            $v = "ACTIVE","DELETED","DELETE_REQUESTED","DELETING","ERROR","UPDATE_REQUESTED","UPDATING"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GML_map = @{
    "AcceptanceType"=@("Confirm-GMLMatch")
    "ComparisonOperator"=@("Write-GMLScalingPolicy")
    "EC2InstanceType"=@("Get-GMLEC2InstanceLimit","New-GMLFleet")
    "MetricName"=@("Write-GMLScalingPolicy")
    "NewGameSessionProtectionPolicy"=@("New-GMLFleet","Update-GMLFleetAttribute")
    "OperatingSystem"=@("New-GMLBuild")
    "PlayerSessionCreationPolicy"=@("Update-GMLGameSession")
    "ProtectionPolicy"=@("Update-GMLGameSession")
    "RoutingStrategy_Type"=@("New-GMLAlias","Update-GMLAlias")
    "RoutingStrategyType"=@("Get-GMLAlias")
    "ScalingAdjustmentType"=@("Write-GMLScalingPolicy")
    "Status"=@("Get-GMLBuild")
    "StatusFilter"=@("Get-GMLScalingPolicy")
}

_awsArgumentCompleterRegistration $GML_Completers $GML_map


# Argument completions for service AWS Greengrass
$GG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Greengrass.DeploymentType
        "New-GGDeployment/DeploymentType"
        {
            $v = "ForceResetDeployment","NewDeployment","Redeployment","ResetDeployment"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GG_map = @{
    "DeploymentType"=@("New-GGDeployment")
}

_awsArgumentCompleterRegistration $GG_Completers $GG_map


# Argument completions for service AWS Health
$HLTH_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AWSHealth.EventAggregateField
        "Get-HLTHEventAggregate/AggregateField"
        {
            $v = "eventTypeCategory"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$HLTH_map = @{
    "AggregateField"=@("Get-HLTHEventAggregate")
}

_awsArgumentCompleterRegistration $HLTH_Completers $HLTH_map


# Argument completions for service AWS Cloud HSM
$HSM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudHSM.ClientVersion
        "Get-HSMConfig/ClientVersion"
        {
            $v = "5.1","5.3"
            break
        }
        
        # Amazon.CloudHSM.SubscriptionType
        "New-HSMItem/SubscriptionType"
        {
            $v = "PRODUCTION"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$HSM_map = @{
    "ClientVersion"=@("Get-HSMConfig")
    "SubscriptionType"=@("New-HSMItem")
}

_awsArgumentCompleterRegistration $HSM_Completers $HSM_map


# Argument completions for service AWS Identity and Access Management
$IAM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IdentityManagement.AssignmentStatusType
        "Get-IAMVirtualMFADevice/AssignmentStatus"
        {
            $v = "Any","Assigned","Unassigned"
            break
        }
        
        # Amazon.IdentityManagement.EncodingType
        "Get-IAMSSHPublicKey/Encoding"
        {
            $v = "PEM","SSH"
            break
        }
        
        # Amazon.IdentityManagement.EntityType
        "Get-IAMEntitiesForPolicy/EntityFilter"
        {
            $v = "AWSManagedPolicy","Group","LocalManagedPolicy","Role","User"
            break
        }
        
        # Amazon.IdentityManagement.PolicyScopeType
        "Get-IAMPolicyList/Scope"
        {
            $v = "All","AWS","Local"
            break
        }
        
        # Amazon.IdentityManagement.StatusType
        {
            ($_ -eq "Update-IAMAccessKey/Status") -Or
            ($_ -eq "Update-IAMServiceSpecificCredential/Status") -Or
            ($_ -eq "Update-IAMSigningCertificate/Status") -Or
            ($_ -eq "Update-IAMSSHPublicKey/Status")
        }
        {
            $v = "Active","Inactive"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IAM_map = @{
    "AssignmentStatus"=@("Get-IAMVirtualMFADevice")
    "Encoding"=@("Get-IAMSSHPublicKey")
    "EntityFilter"=@("Get-IAMEntitiesForPolicy")
    "Scope"=@("Get-IAMPolicyList")
    "Status"=@("Update-IAMAccessKey","Update-IAMServiceSpecificCredential","Update-IAMSigningCertificate","Update-IAMSSHPublicKey")
}

_awsArgumentCompleterRegistration $IAM_Completers $IAM_map


# Argument completions for service AWS Import/Export
$IE_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ImportExport.JobType
        {
            ($_ -eq "New-IEJob/JobType") -Or
            ($_ -eq "Update-IEJob/JobType")
        }
        {
            $v = "Export","Import"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IE_map = @{
    "JobType"=@("New-IEJob","Update-IEJob")
}

_awsArgumentCompleterRegistration $IE_Completers $IE_map


# Argument completions for service Amazon Inspector
$INS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Inspector.InspectorEvent
        {
            ($_ -eq "Add-INSEventSubscription/Event") -Or
            ($_ -eq "Remove-INSEventSubscription/Event")
        }
        {
            $v = "ASSESSMENT_RUN_COMPLETED","ASSESSMENT_RUN_STARTED","ASSESSMENT_RUN_STATE_CHANGED","FINDING_REPORTED","OTHER"
            break
        }
        
        # Amazon.Inspector.Locale
        {
            ($_ -eq "Get-INSFinding/Locale") -Or
            ($_ -eq "Get-INSRulesPackage/Locale")
        }
        {
            $v = "EN_US"
            break
        }
        
        # Amazon.Inspector.ReportFileFormat
        "Get-INSAssessmentReport/ReportFileFormat"
        {
            $v = "HTML","PDF"
            break
        }
        
        # Amazon.Inspector.ReportType
        "Get-INSAssessmentReport/ReportType"
        {
            $v = "FINDING","FULL"
            break
        }
        
        # Amazon.Inspector.StopAction
        "Stop-INSAssessmentRun/StopAction"
        {
            $v = "SKIP_EVALUATION","START_EVALUATION"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$INS_map = @{
    "Event"=@("Add-INSEventSubscription","Remove-INSEventSubscription")
    "Locale"=@("Get-INSFinding","Get-INSRulesPackage")
    "ReportFileFormat"=@("Get-INSAssessmentReport")
    "ReportType"=@("Get-INSAssessmentReport")
    "StopAction"=@("Stop-INSAssessmentRun")
}

_awsArgumentCompleterRegistration $INS_Completers $INS_map


# Argument completions for service AWS IoT
$IOT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IoT.AutoRegistrationStatus
        "Update-IOTCACertificate/NewAutoRegistrationStatus"
        {
            $v = "DISABLE","ENABLE"
            break
        }
        
        # Amazon.IoT.CACertificateStatus
        "Update-IOTCACertificate/NewStatus"
        {
            $v = "ACTIVE","INACTIVE"
            break
        }
        
        # Amazon.IoT.CertificateStatus
        {
            ($_ -eq "Update-IOTCertificate/NewStatus") -Or
            ($_ -eq "Register-IOTCertificate/Status")
        }
        {
            $v = "ACTIVE","INACTIVE","PENDING_ACTIVATION","PENDING_TRANSFER","REGISTER_INACTIVE","REVOKED"
            break
        }
        
        # Amazon.IoT.LogLevel
        "Set-IOTLoggingOption/LoggingOptionsPayload_LogLevel"
        {
            $v = "DEBUG","DISABLED","ERROR","INFO","WARN"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IOT_map = @{
    "LoggingOptionsPayload_LogLevel"=@("Set-IOTLoggingOption")
    "NewAutoRegistrationStatus"=@("Update-IOTCACertificate")
    "NewStatus"=@("Update-IOTCACertificate","Update-IOTCertificate")
    "Status"=@("Register-IOTCertificate")
}

_awsArgumentCompleterRegistration $IOT_Completers $IOT_map


# Argument completions for service Amazon Kinesis
$KIN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Kinesis.EncryptionType
        {
            ($_ -eq "Start-KINStreamEncryption/EncryptionType") -Or
            ($_ -eq "Stop-KINStreamEncryption/EncryptionType")
        }
        {
            $v = "KMS","NONE"
            break
        }
        
        # Amazon.Kinesis.ScalingType
        "Update-KINShardCount/ScalingType"
        {
            $v = "UNIFORM_SCALING"
            break
        }
        
        # Amazon.Kinesis.ShardIteratorType
        "Get-KINShardIterator/ShardIteratorType"
        {
            $v = "AFTER_SEQUENCE_NUMBER","AT_SEQUENCE_NUMBER","AT_TIMESTAMP","LATEST","TRIM_HORIZON"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KIN_map = @{
    "EncryptionType"=@("Start-KINStreamEncryption","Stop-KINStreamEncryption")
    "ScalingType"=@("Update-KINShardCount")
    "ShardIteratorType"=@("Get-KINShardIterator")
}

_awsArgumentCompleterRegistration $KIN_Completers $KIN_map


# Argument completions for service Amazon Kinesis Analytics
$KINA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KinesisAnalytics.InputStartingPosition
        "Find-KINAInputSchema/InputStartingPositionConfiguration_InputStartingPosition"
        {
            $v = "LAST_STOPPED_POINT","NOW","TRIM_HORIZON"
            break
        }
        
        # Amazon.KinesisAnalytics.RecordFormatType
        {
            ($_ -eq "Add-KINAApplicationInput/Input_InputSchema_RecordFormat_RecordFormatType") -Or
            ($_ -eq "Add-KINAApplicationOutput/Output_DestinationSchema_RecordFormatType") -Or
            ($_ -eq "Add-KINAApplicationReferenceDataSource/ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType")
        }
        {
            $v = "CSV","JSON"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KINA_map = @{
    "Input_InputSchema_RecordFormat_RecordFormatType"=@("Add-KINAApplicationInput")
    "InputStartingPositionConfiguration_InputStartingPosition"=@("Find-KINAInputSchema")
    "Output_DestinationSchema_RecordFormatType"=@("Add-KINAApplicationOutput")
    "ReferenceDataSource_ReferenceSchema_RecordFormat_RecordFormatType"=@("Add-KINAApplicationReferenceDataSource")
}

_awsArgumentCompleterRegistration $KINA_Completers $KINA_map


# Argument completions for service Amazon Kinesis Firehose
$KINF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KinesisFirehose.DeliveryStreamType
        {
            ($_ -eq "Get-KINFDeliveryStreamList/DeliveryStreamType") -Or
            ($_ -eq "New-KINFDeliveryStream/DeliveryStreamType")
        }
        {
            $v = "DirectPut","KinesisStreamAsSource"
            break
        }
        
        # Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod
        {
            ($_ -eq "New-KINFDeliveryStream/ElasticsearchDestinationConfiguration_IndexRotationPeriod") -Or
            ($_ -eq "Update-KINFDestination/ElasticsearchDestinationUpdate_IndexRotationPeriod")
        }
        {
            $v = "NoRotation","OneDay","OneHour","OneMonth","OneWeek"
            break
        }
        
        # Amazon.KinesisFirehose.ElasticsearchS3BackupMode
        "New-KINFDeliveryStream/ElasticsearchDestinationConfiguration_S3BackupMode"
        {
            $v = "AllDocuments","FailedDocumentsOnly"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KINF_map = @{
    "DeliveryStreamType"=@("Get-KINFDeliveryStreamList","New-KINFDeliveryStream")
    "ElasticsearchDestinationConfiguration_IndexRotationPeriod"=@("New-KINFDeliveryStream")
    "ElasticsearchDestinationConfiguration_S3BackupMode"=@("New-KINFDeliveryStream")
    "ElasticsearchDestinationUpdate_IndexRotationPeriod"=@("Update-KINFDestination")
}

_awsArgumentCompleterRegistration $KINF_Completers $KINF_map


# Argument completions for service AWS Key Management Service
$KMS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KeyManagementService.AlgorithmSpec
        "Get-KMSParametersForImport/WrappingAlgorithm"
        {
            $v = "RSAES_OAEP_SHA_1","RSAES_OAEP_SHA_256","RSAES_PKCS1_V1_5"
            break
        }
        
        # Amazon.KeyManagementService.DataKeySpec
        {
            ($_ -eq "New-KMSDataKey/KeySpec") -Or
            ($_ -eq "New-KMSDataKeyWithoutPlaintext/KeySpec")
        }
        {
            $v = "AES_128","AES_256"
            break
        }
        
        # Amazon.KeyManagementService.ExpirationModelType
        "Import-KMSKeyMaterial/ExpirationModel"
        {
            $v = "KEY_MATERIAL_DOES_NOT_EXPIRE","KEY_MATERIAL_EXPIRES"
            break
        }
        
        # Amazon.KeyManagementService.KeyUsageType
        "New-KMSKey/KeyUsage"
        {
            $v = "ENCRYPT_DECRYPT"
            break
        }
        
        # Amazon.KeyManagementService.OriginType
        "New-KMSKey/Origin"
        {
            $v = "AWS_KMS","EXTERNAL"
            break
        }
        
        # Amazon.KeyManagementService.WrappingKeySpec
        "Get-KMSParametersForImport/WrappingKeySpec"
        {
            $v = "RSA_2048"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KMS_map = @{
    "ExpirationModel"=@("Import-KMSKeyMaterial")
    "KeySpec"=@("New-KMSDataKey","New-KMSDataKeyWithoutPlaintext")
    "KeyUsage"=@("New-KMSKey")
    "Origin"=@("New-KMSKey")
    "WrappingAlgorithm"=@("Get-KMSParametersForImport")
    "WrappingKeySpec"=@("Get-KMSParametersForImport")
}

_awsArgumentCompleterRegistration $KMS_Completers $KMS_map


# Argument completions for service Amazon Lambda
$LM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Lambda.EventSourcePosition
        "New-LMEventSourceMapping/StartingPosition"
        {
            $v = "AT_TIMESTAMP","LATEST","TRIM_HORIZON"
            break
        }
        
        # Amazon.Lambda.FunctionVersion
        "Get-LMFunctionList/FunctionVersion"
        {
            $v = "ALL"
            break
        }
        
        # Amazon.Lambda.InvocationType
        "Invoke-LMFunction/InvocationType"
        {
            $v = "DryRun","Event","RequestResponse"
            break
        }
        
        # Amazon.Lambda.LogType
        "Invoke-LMFunction/LogType"
        {
            $v = "None","Tail"
            break
        }
        
        # Amazon.Lambda.Runtime
        {
            ($_ -eq "Publish-LMFunction/Runtime") -Or
            ($_ -eq "Update-LMFunctionConfiguration/Runtime")
        }
        {
            $v = "dotnetcore1.0","java8","nodejs","nodejs4.3","nodejs4.3-edge","nodejs6.10","python2.7","python3.6"
            break
        }
        
        # Amazon.Lambda.TracingMode
        "Update-LMFunctionConfiguration/TracingConfig_Mode"
        {
            $v = "Active","PassThrough"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LM_map = @{
    "FunctionVersion"=@("Get-LMFunctionList")
    "InvocationType"=@("Invoke-LMFunction")
    "LogType"=@("Invoke-LMFunction")
    "Runtime"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "StartingPosition"=@("New-LMEventSourceMapping")
    "TracingConfig_Mode"=@("Update-LMFunctionConfiguration")
}

_awsArgumentCompleterRegistration $LM_Completers $LM_map


# Argument completions for service Amazon Lex Model Building Service
$LMB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LexModelBuildingService.ExportType
        "Get-LMBExport/ExportType"
        {
            $v = "ALEXA_SKILLS_KIT"
            break
        }
        
        # Amazon.LexModelBuildingService.FulfillmentActivityType
        "Write-LMBIntent/FulfillmentActivity_Type"
        {
            $v = "CodeHook","ReturnIntent"
            break
        }
        
        # Amazon.LexModelBuildingService.Locale
        {
            ($_ -eq "Get-LMBBuiltinIntentList/Locale") -Or
            ($_ -eq "Get-LMBBuiltinSlotType/Locale") -Or
            ($_ -eq "Write-LMBBot/Locale")
        }
        {
            $v = "en-US"
            break
        }
        
        # Amazon.LexModelBuildingService.ProcessBehavior
        "Write-LMBBot/ProcessBehavior"
        {
            $v = "BUILD","SAVE"
            break
        }
        
        # Amazon.LexModelBuildingService.ResourceType
        "Get-LMBExport/ResourceType"
        {
            $v = "BOT"
            break
        }
        
        # Amazon.LexModelBuildingService.SlotValueSelectionStrategy
        "Write-LMBSlotType/ValueSelectionStrategy"
        {
            $v = "ORIGINAL_VALUE","TOP_RESOLUTION"
            break
        }
        
        # Amazon.LexModelBuildingService.StatusType
        "Get-LMBUtterancesView/StatusType"
        {
            $v = "Detected","Missed"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LMB_map = @{
    "ExportType"=@("Get-LMBExport")
    "FulfillmentActivity_Type"=@("Write-LMBIntent")
    "Locale"=@("Get-LMBBuiltinIntentList","Get-LMBBuiltinSlotType","Write-LMBBot")
    "ProcessBehavior"=@("Write-LMBBot")
    "ResourceType"=@("Get-LMBExport")
    "StatusType"=@("Get-LMBUtterancesView")
    "ValueSelectionStrategy"=@("Write-LMBSlotType")
}

_awsArgumentCompleterRegistration $LMB_Completers $LMB_map


# Argument completions for service Amazon Lightsail
$LS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Lightsail.InstanceAccessProtocol
        "Get-LSInstanceAccessDetail/Protocol"
        {
            $v = "rdp","ssh"
            break
        }
        
        # Amazon.Lightsail.InstanceMetricName
        "Get-LSInstanceMetricData/MetricName"
        {
            $v = "CPUUtilization","NetworkIn","NetworkOut","StatusCheckFailed","StatusCheckFailed_Instance","StatusCheckFailed_System"
            break
        }
        
        # Amazon.Lightsail.MetricUnit
        "Get-LSInstanceMetricData/Unit"
        {
            $v = "Bits","Bits/Second","Bytes","Bytes/Second","Count","Count/Second","Gigabits","Gigabits/Second","Gigabytes","Gigabytes/Second","Kilobits","Kilobits/Second","Kilobytes","Kilobytes/Second","Megabits","Megabits/Second","Megabytes","Megabytes/Second","Microseconds","Milliseconds","None","Percent","Seconds","Terabits","Terabits/Second","Terabytes","Terabytes/Second"
            break
        }
        
        # Amazon.Lightsail.NetworkProtocol
        {
            ($_ -eq "Close-LSInstancePublicPort/PortInfo_Protocol") -Or
            ($_ -eq "Open-LSInstancePublicPort/PortInfo_Protocol")
        }
        {
            $v = "all","tcp","udp"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LS_map = @{
    "MetricName"=@("Get-LSInstanceMetricData")
    "PortInfo_Protocol"=@("Close-LSInstancePublicPort","Open-LSInstancePublicPort")
    "Protocol"=@("Get-LSInstanceAccessDetail")
    "Unit"=@("Get-LSInstanceMetricData")
}

_awsArgumentCompleterRegistration $LS_Completers $LS_map


# Argument completions for service AWS Marketplace Commerce Analytics
$MCA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AWSMarketplaceCommerceAnalytics.DataSetType
        "New-MCADataSet/DataSetType"
        {
            $v = "customer_profile_by_geography","customer_profile_by_industry","customer_profile_by_revenue","customer_subscriber_annual_subscriptions","customer_subscriber_hourly_monthly_subscriptions","daily_business_canceled_product_subscribers","daily_business_fees","daily_business_free_trial_conversions","daily_business_new_instances","daily_business_new_product_subscribers","daily_business_usage_by_instance_type","disbursed_amount_by_age_of_disbursed_funds","disbursed_amount_by_age_of_uncollected_funds","disbursed_amount_by_customer_geo","disbursed_amount_by_instance_hours","disbursed_amount_by_product","disbursed_amount_by_product_with_uncollected_funds","monthly_revenue_annual_subscriptions","monthly_revenue_billing_and_revenue_data","sales_compensation_billed_revenue","us_sales_and_use_tax_records"
            break
        }
        
        # Amazon.AWSMarketplaceCommerceAnalytics.SupportDataSetType
        "Start-MCASupportDataExport/DataSetType"
        {
            $v = "customer_support_contacts_data","test_customer_support_contacts_data"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MCA_map = @{
    "DataSetType"=@("New-MCADataSet","Start-MCASupportDataExport")
}

_awsArgumentCompleterRegistration $MCA_Completers $MCA_map


# Argument completions for service Amazon Machine Learning
$ML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MachineLearning.BatchPredictionFilterVariable
        "Get-MLBatchPredictionList/FilterVariable"
        {
            $v = "CreatedAt","DataSourceId","DataURI","IAMUser","LastUpdatedAt","MLModelId","Name","Status"
            break
        }
        
        # Amazon.MachineLearning.DataSourceFilterVariable
        "Get-MLDataSourceList/FilterVariable"
        {
            $v = "CreatedAt","DataLocationS3","IAMUser","LastUpdatedAt","Name","Status"
            break
        }
        
        # Amazon.MachineLearning.EvaluationFilterVariable
        "Get-MLEvaluationList/FilterVariable"
        {
            $v = "CreatedAt","DataSourceId","DataURI","IAMUser","LastUpdatedAt","MLModelId","Name","Status"
            break
        }
        
        # Amazon.MachineLearning.MLModelFilterVariable
        "Get-MLModelList/FilterVariable"
        {
            $v = "Algorithm","CreatedAt","IAMUser","LastUpdatedAt","MLModelType","Name","RealtimeEndpointStatus","Status","TrainingDataSourceId","TrainingDataURI"
            break
        }
        
        # Amazon.MachineLearning.MLModelType
        "New-MLModel/MLModelType"
        {
            $v = "BINARY","MULTICLASS","REGRESSION"
            break
        }
        
        # Amazon.MachineLearning.SortOrder
        {
            ($_ -eq "Get-MLBatchPredictionList/SortOrder") -Or
            ($_ -eq "Get-MLDataSourceList/SortOrder") -Or
            ($_ -eq "Get-MLEvaluationList/SortOrder") -Or
            ($_ -eq "Get-MLModelList/SortOrder")
        }
        {
            $v = "asc","dsc"
            break
        }
        
        # Amazon.MachineLearning.TaggableResourceType
        {
            ($_ -eq "Add-MLResourceTag/ResourceType") -Or
            ($_ -eq "Get-MLResourceTag/ResourceType") -Or
            ($_ -eq "Remove-MLResourceTag/ResourceType")
        }
        {
            $v = "BatchPrediction","DataSource","Evaluation","MLModel"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ML_map = @{
    "FilterVariable"=@("Get-MLBatchPredictionList","Get-MLDataSourceList","Get-MLEvaluationList","Get-MLModelList")
    "MLModelType"=@("New-MLModel")
    "ResourceType"=@("Add-MLResourceTag","Get-MLResourceTag","Remove-MLResourceTag")
    "SortOrder"=@("Get-MLBatchPredictionList","Get-MLDataSourceList","Get-MLEvaluationList","Get-MLModelList")
}

_awsArgumentCompleterRegistration $ML_Completers $ML_map


# Argument completions for service Amazon MTurk Service
$MTR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MTurk.EventType
        "Send-MTRTestEventNotification/TestEventType"
        {
            $v = "AssignmentAbandoned","AssignmentAccepted","AssignmentApproved","AssignmentRejected","AssignmentReturned","AssignmentSubmitted","HITCreated","HITDisposed","HITExpired","HITExtended","HITReviewable","Ping"
            break
        }
        
        # Amazon.MTurk.NotificationTransport
        {
            ($_ -eq "Send-MTRTestEventNotification/Notification_Transport") -Or
            ($_ -eq "Update-MTRNotificationSetting/Notification_Transport")
        }
        {
            $v = "Email","SNS","SQS"
            break
        }
        
        # Amazon.MTurk.QualificationStatus
        "Get-MTRWorkersWithQualificationType/Status"
        {
            $v = "Granted","Revoked"
            break
        }
        
        # Amazon.MTurk.QualificationTypeStatus
        {
            ($_ -eq "New-MTRQualificationType/QualificationTypeStatus") -Or
            ($_ -eq "Update-MTRQualificationType/QualificationTypeStatus")
        }
        {
            $v = "Active","Inactive"
            break
        }
        
        # Amazon.MTurk.ReviewableHITStatus
        "Get-MTRReviewableHITList/Status"
        {
            $v = "Reviewable","Reviewing"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MTR_map = @{
    "Notification_Transport"=@("Send-MTRTestEventNotification","Update-MTRNotificationSetting")
    "QualificationTypeStatus"=@("New-MTRQualificationType","Update-MTRQualificationType")
    "Status"=@("Get-MTRReviewableHITList","Get-MTRWorkersWithQualificationType")
    "TestEventType"=@("Send-MTRTestEventNotification")
}

_awsArgumentCompleterRegistration $MTR_Completers $MTR_map


# Argument completions for service AWS OpsWorks
$OPS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.OpsWorks.AppType
        {
            ($_ -eq "New-OPSApp/Type") -Or
            ($_ -eq "Update-OPSApp/Type")
        }
        {
            $v = "aws-flow-ruby","java","nodejs","other","php","rails","static"
            break
        }
        
        # Amazon.OpsWorks.Architecture
        {
            ($_ -eq "New-OPSInstance/Architecture") -Or
            ($_ -eq "Update-OPSInstance/Architecture")
        }
        {
            $v = "i386","x86_64"
            break
        }
        
        # Amazon.OpsWorks.AutoScalingType
        {
            ($_ -eq "New-OPSInstance/AutoScalingType") -Or
            ($_ -eq "Update-OPSInstance/AutoScalingType")
        }
        {
            $v = "load","timer"
            break
        }
        
        # Amazon.OpsWorks.DeploymentCommandName
        "New-OPSDeployment/Command_Name"
        {
            $v = "configure","deploy","execute_recipes","install_dependencies","restart","rollback","setup","start","stop","undeploy","update_custom_cookbooks","update_dependencies"
            break
        }
        
        # Amazon.OpsWorks.LayerType
        "New-OPSLayer/Type"
        {
            $v = "aws-flow-ruby","custom","db-master","ecs-cluster","java-app","lb","memcached","monitoring-master","nodejs-app","php-app","rails-app","web"
            break
        }
        
        # Amazon.OpsWorks.RootDeviceType
        {
            ($_ -eq "Copy-OPSStack/DefaultRootDeviceType") -Or
            ($_ -eq "New-OPSStack/DefaultRootDeviceType") -Or
            ($_ -eq "Update-OPSStack/DefaultRootDeviceType") -Or
            ($_ -eq "New-OPSInstance/RootDeviceType")
        }
        {
            $v = "ebs","instance-store"
            break
        }
        
        # Amazon.OpsWorks.SourceType
        {
            ($_ -eq "New-OPSApp/AppSource_Type") -Or
            ($_ -eq "Update-OPSApp/AppSource_Type") -Or
            ($_ -eq "Copy-OPSStack/CustomCookbooksSource_Type") -Or
            ($_ -eq "New-OPSStack/CustomCookbooksSource_Type") -Or
            ($_ -eq "Update-OPSStack/CustomCookbooksSource_Type")
        }
        {
            $v = "archive","git","s3","svn"
            break
        }
        
        # Amazon.OpsWorks.VirtualizationType
        "New-OPSInstance/VirtualizationType"
        {
            $v = "hvm","paravirtual"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$OPS_map = @{
    "AppSource_Type"=@("New-OPSApp","Update-OPSApp")
    "Architecture"=@("New-OPSInstance","Update-OPSInstance")
    "AutoScalingType"=@("New-OPSInstance","Update-OPSInstance")
    "Command_Name"=@("New-OPSDeployment")
    "CustomCookbooksSource_Type"=@("Copy-OPSStack","New-OPSStack","Update-OPSStack")
    "DefaultRootDeviceType"=@("Copy-OPSStack","New-OPSStack","Update-OPSStack")
    "RootDeviceType"=@("New-OPSInstance")
    "Type"=@("New-OPSApp","New-OPSLayer","Update-OPSApp")
    "VirtualizationType"=@("New-OPSInstance")
}

_awsArgumentCompleterRegistration $OPS_Completers $OPS_map


# Argument completions for service AWS Organizations
$ORG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Organizations.ActionType
        {
            ($_ -eq "Get-ORGAccountHandshakeList/Filter_ActionType") -Or
            ($_ -eq "Get-ORGOrganizationHandshakeList/Filter_ActionType")
        }
        {
            $v = "APPROVE_ALL_FEATURES","ENABLE_ALL_FEATURES","INVITE"
            break
        }
        
        # Amazon.Organizations.ChildType
        "Get-ORGChild/ChildType"
        {
            $v = "ACCOUNT","ORGANIZATIONAL_UNIT"
            break
        }
        
        # Amazon.Organizations.HandshakePartyType
        "New-ORGAccountInvitation/Target_Type"
        {
            $v = "ACCOUNT","EMAIL","ORGANIZATION"
            break
        }
        
        # Amazon.Organizations.IAMUserAccessToBilling
        "New-ORGAccount/IamUserAccessToBilling"
        {
            $v = "ALLOW","DENY"
            break
        }
        
        # Amazon.Organizations.OrganizationFeatureSet
        "New-ORGOrganization/FeatureSet"
        {
            $v = "ALL","CONSOLIDATED_BILLING"
            break
        }
        
        # Amazon.Organizations.PolicyType
        {
            ($_ -eq "Get-ORGPolicyForTarget/Filter") -Or
            ($_ -eq "Get-ORGPolicyList/Filter") -Or
            ($_ -eq "Disable-ORGPolicyType/PolicyType") -Or
            ($_ -eq "Enable-ORGPolicyType/PolicyType") -Or
            ($_ -eq "New-ORGPolicy/Type")
        }
        {
            $v = "SERVICE_CONTROL_POLICY"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ORG_map = @{
    "ChildType"=@("Get-ORGChild")
    "FeatureSet"=@("New-ORGOrganization")
    "Filter"=@("Get-ORGPolicyForTarget","Get-ORGPolicyList")
    "Filter_ActionType"=@("Get-ORGAccountHandshakeList","Get-ORGOrganizationHandshakeList")
    "IamUserAccessToBilling"=@("New-ORGAccount")
    "PolicyType"=@("Disable-ORGPolicyType","Enable-ORGPolicyType")
    "Target_Type"=@("New-ORGAccountInvitation")
    "Type"=@("New-ORGPolicy")
}

_awsArgumentCompleterRegistration $ORG_Completers $ORG_map


# Argument completions for service Amazon Pinpoint
$PIN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Pinpoint.Action
        {
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_ADMMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_BaiduMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_GCMMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_GCMMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_GCMMessage_Action")
        }
        {
            $v = "DEEP_LINK","OPEN_APP","URL"
            break
        }
        
        # Amazon.Pinpoint.ChannelType
        "Update-PINEndpoint/EndpointRequest_ChannelType"
        {
            $v = "ADM","APNS","APNS_SANDBOX","BAIDU","EMAIL","GCM","SMS"
            break
        }
        
        # Amazon.Pinpoint.DimensionType
        {
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Location_Country_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Location_Country_DimensionType")
        }
        {
            $v = "EXCLUSIVE","INCLUSIVE"
            break
        }
        
        # Amazon.Pinpoint.Duration
        {
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_Duration") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_Duration")
        }
        {
            $v = "DAY_14","DAY_30","DAY_7","HR_24"
            break
        }
        
        # Amazon.Pinpoint.Format
        "New-PINImportJob/ImportJobRequest_Format"
        {
            $v = "CSV","JSON"
            break
        }
        
        # Amazon.Pinpoint.Frequency
        {
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_Schedule_Frequency") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_Schedule_Frequency")
        }
        {
            $v = "DAILY","HOURLY","MONTHLY","ONCE","WEEKLY"
            break
        }
        
        # Amazon.Pinpoint.MessageType
        {
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_SMSMessage_MessageType") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType")
        }
        {
            $v = "PROMOTIONAL","TRANSACTIONAL"
            break
        }
        
        # Amazon.Pinpoint.RecencyType
        {
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PIN_map = @{
    "EndpointRequest_ChannelType"=@("Update-PINEndpoint")
    "ImportJobRequest_Format"=@("New-PINImportJob")
    "MessageRequest_MessageConfiguration_ADMMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_APNSMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_BaiduMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_GCMMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_SMSMessage_MessageType"=@("Send-PINMessage")
    "SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType"=@("Send-PINUserMessageBatch")
    "WriteCampaignRequest_MessageConfiguration_APNSMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_GCMMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_Schedule_Frequency"=@("New-PINCampaign","Update-PINCampaign")
    "WriteSegmentRequest_Dimensions_Behavior_Recency_Duration"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Location_Country_DimensionType"=@("New-PINSegment","Update-PINSegment")
}

_awsArgumentCompleterRegistration $PIN_Completers $PIN_map


# Argument completions for service Amazon Polly
$POL_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Polly.LanguageCode
        "Get-POLVoice/LanguageCode"
        {
            $v = "cy-GB","da-DK","de-DE","en-AU","en-GB","en-GB-WLS","en-IN","en-US","es-ES","es-US","fr-CA","fr-FR","is-IS","it-IT","ja-JP","nb-NO","nl-NL","pl-PL","pt-BR","pt-PT","ro-RO","ru-RU","sv-SE","tr-TR"
            break
        }
        
        # Amazon.Polly.OutputFormat
        "Get-POLSpeech/OutputFormat"
        {
            $v = "json","mp3","ogg_vorbis","pcm"
            break
        }
        
        # Amazon.Polly.TextType
        "Get-POLSpeech/TextType"
        {
            $v = "ssml","text"
            break
        }
        
        # Amazon.Polly.VoiceId
        "Get-POLSpeech/VoiceId"
        {
            $v = "Amy","Astrid","Brian","Carla","Carmen","Celine","Chantal","Conchita","Cristiano","Dora","Emma","Enrique","Ewa","Filiz","Geraint","Giorgio","Gwyneth","Hans","Ines","Ivy","Jacek","Jan","Joanna","Joey","Justin","Karl","Kendra","Kimberly","Liv","Lotte","Mads","Maja","Marlene","Mathieu","Matthew","Maxim","Miguel","Mizuki","Naja","Nicole","Penelope","Raveena","Ricardo","Ruben","Russell","Salli","Takumi","Tatyana","Vicki","Vitoria"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$POL_map = @{
    "LanguageCode"=@("Get-POLVoice")
    "OutputFormat"=@("Get-POLSpeech")
    "TextType"=@("Get-POLSpeech")
    "VoiceId"=@("Get-POLSpeech")
}

_awsArgumentCompleterRegistration $POL_Completers $POL_map


# Argument completions for service Amazon Relational Database Service
$RDS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.RDS.SourceType
        "Get-RDSEvent/SourceType"
        {
            $v = "db-cluster","db-cluster-snapshot","db-instance","db-parameter-group","db-security-group","db-snapshot"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RDS_map = @{
    "SourceType"=@("Get-RDSEvent")
}

_awsArgumentCompleterRegistration $RDS_Completers $RDS_map


# Argument completions for service Amazon Redshift
$RS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Redshift.SourceType
        "Get-RSEvent/SourceType"
        {
            $v = "cluster","cluster-parameter-group","cluster-security-group","cluster-snapshot"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RS_map = @{
    "SourceType"=@("Get-RSEvent")
}

_awsArgumentCompleterRegistration $RS_Completers $RS_map


# Argument completions for service Amazon Route 53
$R53_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Route53.CloudWatchRegion
        {
            ($_ -eq "Update-R53HealthCheck/AlarmIdentifier_Region") -Or
            ($_ -eq "New-R53HealthCheck/HealthCheckConfig_AlarmIdentifier_Region")
        }
        {
            $v = "ap-northeast-1","ap-northeast-2","ap-south-1","ap-southeast-1","ap-southeast-2","ca-central-1","eu-central-1","eu-west-1","eu-west-2","sa-east-1","us-east-1","us-east-2","us-west-1","us-west-2"
            break
        }
        
        # Amazon.Route53.HealthCheckType
        "New-R53HealthCheck/HealthCheckConfig_Type"
        {
            $v = "CALCULATED","CLOUDWATCH_METRIC","HTTP","HTTPS","HTTPS_STR_MATCH","HTTP_STR_MATCH","TCP"
            break
        }
        
        # Amazon.Route53.InsufficientDataHealthStatus
        {
            ($_ -eq "New-R53HealthCheck/HealthCheckConfig_InsufficientDataHealthStatus") -Or
            ($_ -eq "Update-R53HealthCheck/InsufficientDataHealthStatus")
        }
        {
            $v = "Healthy","LastKnownStatus","Unhealthy"
            break
        }
        
        # Amazon.Route53.RRType
        {
            ($_ -eq "Test-R53DNSAnswer/RecordType") -Or
            ($_ -eq "Get-R53ResourceRecordSet/StartRecordType") -Or
            ($_ -eq "Get-R53TrafficPolicyInstanceList/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53TrafficPolicyInstancesByHostedZone/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53TrafficPolicyInstancesByPolicy/TrafficPolicyInstanceTypeMarker")
        }
        {
            $v = "A","AAAA","CAA","CNAME","MX","NAPTR","NS","PTR","SOA","SPF","SRV","TXT"
            break
        }
        
        # Amazon.Route53.TagResourceType
        {
            ($_ -eq "Edit-R53TagsForResource/ResourceType") -Or
            ($_ -eq "Get-R53TagsForResource/ResourceType") -Or
            ($_ -eq "Get-R53TagsForResourceList/ResourceType")
        }
        {
            $v = "healthcheck","hostedzone"
            break
        }
        
        # Amazon.Route53.VPCRegion
        {
            ($_ -eq "New-R53HostedZone/VPC_VPCRegion") -Or
            ($_ -eq "New-R53VPCAssociationAuthorization/VPC_VPCRegion") -Or
            ($_ -eq "Register-R53VPCWithHostedZone/VPC_VPCRegion") -Or
            ($_ -eq "Remove-R53VPCAssociationAuthorization/VPC_VPCRegion") -Or
            ($_ -eq "Unregister-R53VPCFromHostedZone/VPC_VPCRegion")
        }
        {
            $v = "ap-northeast-1","ap-northeast-2","ap-south-1","ap-southeast-1","ap-southeast-2","ca-central-1","cn-north-1","eu-central-1","eu-west-1","eu-west-2","sa-east-1","us-east-1","us-east-2","us-west-1","us-west-2"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$R53_map = @{
    "AlarmIdentifier_Region"=@("Update-R53HealthCheck")
    "HealthCheckConfig_AlarmIdentifier_Region"=@("New-R53HealthCheck")
    "HealthCheckConfig_InsufficientDataHealthStatus"=@("New-R53HealthCheck")
    "HealthCheckConfig_Type"=@("New-R53HealthCheck")
    "InsufficientDataHealthStatus"=@("Update-R53HealthCheck")
    "RecordType"=@("Test-R53DNSAnswer")
    "ResourceType"=@("Edit-R53TagsForResource","Get-R53TagsForResource","Get-R53TagsForResourceList")
    "StartRecordType"=@("Get-R53ResourceRecordSet")
    "TrafficPolicyInstanceTypeMarker"=@("Get-R53TrafficPolicyInstanceList","Get-R53TrafficPolicyInstancesByHostedZone","Get-R53TrafficPolicyInstancesByPolicy")
    "VPC_VPCRegion"=@("New-R53HostedZone","New-R53VPCAssociationAuthorization","Register-R53VPCWithHostedZone","Remove-R53VPCAssociationAuthorization","Unregister-R53VPCFromHostedZone")
}

_awsArgumentCompleterRegistration $R53_Completers $R53_map


# Argument completions for service Amazon Route 53 Domains
$R53D_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Route53Domains.ContactType
        {
            ($_ -eq "Invoke-R53DDomainTransfer/AdminContact_ContactType") -Or
            ($_ -eq "Register-R53DDomain/AdminContact_ContactType") -Or
            ($_ -eq "Update-R53DDomainContact/AdminContact_ContactType") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/RegistrantContact_ContactType") -Or
            ($_ -eq "Register-R53DDomain/RegistrantContact_ContactType") -Or
            ($_ -eq "Update-R53DDomainContact/RegistrantContact_ContactType") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/TechContact_ContactType") -Or
            ($_ -eq "Register-R53DDomain/TechContact_ContactType") -Or
            ($_ -eq "Update-R53DDomainContact/TechContact_ContactType")
        }
        {
            $v = "ASSOCIATION","COMPANY","PERSON","PUBLIC_BODY","RESELLER"
            break
        }
        
        # Amazon.Route53Domains.CountryCode
        {
            ($_ -eq "Invoke-R53DDomainTransfer/AdminContact_CountryCode") -Or
            ($_ -eq "Register-R53DDomain/AdminContact_CountryCode") -Or
            ($_ -eq "Update-R53DDomainContact/AdminContact_CountryCode") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/RegistrantContact_CountryCode") -Or
            ($_ -eq "Register-R53DDomain/RegistrantContact_CountryCode") -Or
            ($_ -eq "Update-R53DDomainContact/RegistrantContact_CountryCode") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/TechContact_CountryCode") -Or
            ($_ -eq "Register-R53DDomain/TechContact_CountryCode") -Or
            ($_ -eq "Update-R53DDomainContact/TechContact_CountryCode")
        }
        {
            $v = "AD","AE","AF","AG","AI","AL","AM","AN","AO","AQ","AR","AS","AT","AU","AW","AZ","BA","BB","BD","BE","BF","BG","BH","BI","BJ","BL","BM","BN","BO","BR","BS","BT","BW","BY","BZ","CA","CC","CD","CF","CG","CH","CI","CK","CL","CM","CN","CO","CR","CU","CV","CX","CY","CZ","DE","DJ","DK","DM","DO","DZ","EC","EE","EG","ER","ES","ET","FI","FJ","FK","FM","FO","FR","GA","GB","GD","GE","GH","GI","GL","GM","GN","GQ","GR","GT","GU","GW","GY","HK","HN","HR","HT","HU","ID","IE","IL","IM","IN","IQ","IR","IS","IT","JM","JO","JP","KE","KG","KH","KI","KM","KN","KP","KR","KW","KY","KZ","LA","LB","LC","LI","LK","LR","LS","LT","LU","LV","LY","MA","MC","MD","ME","MF","MG","MH","MK","ML","MM","MN","MO","MP","MR","MS","MT","MU","MV","MW","MX","MY","MZ","NA","NC","NE","NG","NI","NL","NO","NP","NR","NU","NZ","OM","PA","PE","PF","PG","PH","PK","PL","PM","PN","PR","PT","PW","PY","QA","RO","RS","RU","RW","SA","SB","SC","SD","SE","SG","SH","SI","SK","SL","SM","SN","SO","SR","ST","SV","SY","SZ","TC","TD","TG","TH","TJ","TK","TL","TM","TN","TO","TR","TT","TV","TW","TZ","UA","UG","US","UY","UZ","VA","VC","VE","VG","VI","VN","VU","WF","WS","YE","YT","ZA","ZM","ZW"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$R53D_map = @{
    "AdminContact_ContactType"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "AdminContact_CountryCode"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "RegistrantContact_ContactType"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "RegistrantContact_CountryCode"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "TechContact_ContactType"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "TechContact_CountryCode"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
}

_awsArgumentCompleterRegistration $R53D_Completers $R53D_map


# Argument completions for service Amazon Simple Storage Service
$S3_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.S3.BucketAccelerateStatus
        "Write-S3BucketAccelerateConfiguration/AccelerateConfiguration_Status"
        {
            $v = "Enabled","Suspended"
            break
        }
        
        # Amazon.S3.EncodingType
        {
            ($_ -eq "Get-S3Object/Encoding") -Or
            ($_ -eq "Get-S3Version/Encoding")
        }
        {
            $v = "Url"
            break
        }
        
        # Amazon.S3.GlacierJobTier
        "Restore-S3Object/Tier"
        {
            $v = "Bulk","Expedited","Standard"
            break
        }
        
        # Amazon.S3.InventoryFormat
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat"
        {
            $v = "CSV"
            break
        }
        
        # Amazon.S3.InventoryFrequency
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_Schedule_Frequency"
        {
            $v = "Daily","Weekly"
            break
        }
        
        # Amazon.S3.InventoryIncludedObjectVersions
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_IncludedObjectVersions"
        {
            $v = "All","Current"
            break
        }
        
        # Amazon.S3.RequestPayer
        {
            ($_ -eq "Get-S3ObjectMetadata/RequestPayer") -Or
            ($_ -eq "Restore-S3Object/RequestPayer")
        }
        {
            $v = "requester"
            break
        }
        
        # Amazon.S3.S3CannedACL
        {
            ($_ -eq "Copy-S3Object/CannedACLName") -Or
            ($_ -eq "New-S3Bucket/CannedACLName") -Or
            ($_ -eq "Set-S3ACL/CannedACLName") -Or
            ($_ -eq "Write-S3Object/CannedACLName")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","log-delivery-write","NoACL","private","public-read","public-read-write"
            break
        }
        
        # Amazon.S3.ServerSideEncryptionCustomerMethod
        {
            ($_ -eq "Copy-S3Object/CopySourceServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Copy-S3Object/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Get-S3ObjectMetadata/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Get-S3PreSignedURL/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Read-S3Object/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Write-S3Object/ServerSideEncryptionCustomerMethod")
        }
        {
            $v = "","AES256"
            break
        }
        
        # Amazon.S3.ServerSideEncryptionMethod
        {
            ($_ -eq "Copy-S3Object/ServerSideEncryption") -Or
            ($_ -eq "Write-S3Object/ServerSideEncryption") -Or
            ($_ -eq "Get-S3PreSignedURL/ServerSideEncryptionMethod")
        }
        {
            $v = "","AES256","aws:kms"
            break
        }
        
        # Amazon.S3.StorageClassAnalysisSchemaVersion
        "Write-S3BucketAnalyticsConfiguration/AnalyticsConfiguration_StorageClassAnalysis_DataExport_OutputSchemaVersion"
        {
            $v = "V_1"
            break
        }
        
        # Amazon.S3.VersionStatus
        "Write-S3BucketVersioning/VersioningConfig_Status"
        {
            $v = "Enabled","Off","Suspended"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$S3_map = @{
    "AccelerateConfiguration_Status"=@("Write-S3BucketAccelerateConfiguration")
    "AnalyticsConfiguration_StorageClassAnalysis_DataExport_OutputSchemaVersion"=@("Write-S3BucketAnalyticsConfiguration")
    "CannedACLName"=@("Copy-S3Object","New-S3Bucket","Set-S3ACL","Write-S3Object")
    "CopySourceServerSideEncryptionCustomerMethod"=@("Copy-S3Object")
    "Encoding"=@("Get-S3Object","Get-S3Version")
    "InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat"=@("Write-S3BucketInventoryConfiguration")
    "InventoryConfiguration_IncludedObjectVersions"=@("Write-S3BucketInventoryConfiguration")
    "InventoryConfiguration_Schedule_Frequency"=@("Write-S3BucketInventoryConfiguration")
    "RequestPayer"=@("Get-S3ObjectMetadata","Restore-S3Object")
    "ServerSideEncryption"=@("Copy-S3Object","Write-S3Object")
    "ServerSideEncryptionCustomerMethod"=@("Copy-S3Object","Get-S3ObjectMetadata","Get-S3PreSignedURL","Read-S3Object","Write-S3Object")
    "ServerSideEncryptionMethod"=@("Get-S3PreSignedURL")
    "Tier"=@("Restore-S3Object")
    "VersioningConfig_Status"=@("Write-S3BucketVersioning")
}

_awsArgumentCompleterRegistration $S3_Completers $S3_map


# Argument completions for service AWS Service Catalog
$SC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ServiceCatalog.AccessLevelFilterKey
        {
            ($_ -eq "Get-SCProvisionedProduct/AccessLevelFilter_Key") -Or
            ($_ -eq "Get-SCRecordHistory/AccessLevelFilter_Key")
        }
        {
            $v = "Account","Role","User"
            break
        }
        
        # Amazon.ServiceCatalog.PrincipalType
        "Register-SCPrincipalWithPortfolio/PrincipalType"
        {
            $v = "IAM"
            break
        }
        
        # Amazon.ServiceCatalog.ProductSource
        "Search-SCProductsAsAdmin/ProductSource"
        {
            $v = "ACCOUNT"
            break
        }
        
        # Amazon.ServiceCatalog.ProductType
        "New-SCProduct/ProductType"
        {
            $v = "CLOUD_FORMATION_TEMPLATE","MARKETPLACE"
            break
        }
        
        # Amazon.ServiceCatalog.ProductViewSortBy
        {
            ($_ -eq "Find-SCProduct/SortBy") -Or
            ($_ -eq "Search-SCProductsAsAdmin/SortBy")
        }
        {
            $v = "CreationDate","Title","VersionCount"
            break
        }
        
        # Amazon.ServiceCatalog.ProvisioningArtifactType
        {
            ($_ -eq "New-SCProvisioningArtifact/Parameters_Type") -Or
            ($_ -eq "New-SCProduct/ProvisioningArtifactParameters_Type")
        }
        {
            $v = "CLOUD_FORMATION_TEMPLATE","MARKETPLACE_AMI","MARKETPLACE_CAR"
            break
        }
        
        # Amazon.ServiceCatalog.SortOrder
        {
            ($_ -eq "Find-SCProduct/SortOrder") -Or
            ($_ -eq "Search-SCProductsAsAdmin/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SC_map = @{
    "AccessLevelFilter_Key"=@("Get-SCProvisionedProduct","Get-SCRecordHistory")
    "Parameters_Type"=@("New-SCProvisioningArtifact")
    "PrincipalType"=@("Register-SCPrincipalWithPortfolio")
    "ProductSource"=@("Search-SCProductsAsAdmin")
    "ProductType"=@("New-SCProduct")
    "ProvisioningArtifactParameters_Type"=@("New-SCProduct")
    "SortBy"=@("Find-SCProduct","Search-SCProductsAsAdmin")
    "SortOrder"=@("Find-SCProduct","Search-SCProductsAsAdmin")
}

_awsArgumentCompleterRegistration $SC_Completers $SC_map


# Argument completions for service Amazon Simple Email Service
$SES_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SimpleEmail.BehaviorOnMXFailure
        "Set-SESIdentityMailFromDomain/BehaviorOnMXFailure"
        {
            $v = "RejectMessage","UseDefaultValue"
            break
        }
        
        # Amazon.SimpleEmail.IdentityType
        "Get-SESIdentity/IdentityType"
        {
            $v = "Domain","EmailAddress"
            break
        }
        
        # Amazon.SimpleEmail.NotificationType
        {
            ($_ -eq "Set-SESIdentityHeadersInNotificationsEnabled/NotificationType") -Or
            ($_ -eq "Set-SESIdentityNotificationTopic/NotificationType")
        }
        {
            $v = "Bounce","Complaint","Delivery"
            break
        }
        
        # Amazon.SimpleEmail.ReceiptFilterPolicy
        "New-SESReceiptFilter/Filter_IpFilter_Policy"
        {
            $v = "Allow","Block"
            break
        }
        
        # Amazon.SimpleEmail.TlsPolicy
        {
            ($_ -eq "New-SESReceiptRule/Rule_TlsPolicy") -Or
            ($_ -eq "Update-SESReceiptRule/Rule_TlsPolicy")
        }
        {
            $v = "Optional","Require"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SES_map = @{
    "BehaviorOnMXFailure"=@("Set-SESIdentityMailFromDomain")
    "Filter_IpFilter_Policy"=@("New-SESReceiptFilter")
    "IdentityType"=@("Get-SESIdentity")
    "NotificationType"=@("Set-SESIdentityHeadersInNotificationsEnabled","Set-SESIdentityNotificationTopic")
    "Rule_TlsPolicy"=@("New-SESReceiptRule","Update-SESReceiptRule")
}

_awsArgumentCompleterRegistration $SES_Completers $SES_map


# Argument completions for service Amazon Step Functions
$SFN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.StepFunctions.ExecutionStatus
        "Get-SFNExecutionList/StatusFilter"
        {
            $v = "ABORTED","FAILED","RUNNING","SUCCEEDED","TIMED_OUT"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SFN_map = @{
    "StatusFilter"=@("Get-SFNExecutionList")
}

_awsArgumentCompleterRegistration $SFN_Completers $SFN_map


# Argument completions for service Amazon Server Migration Service
$SMS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ServerMigrationService.LicenseType
        {
            ($_ -eq "New-SMSReplicationJob/LicenseType") -Or
            ($_ -eq "Update-SMSReplicationJob/LicenseType")
        }
        {
            $v = "AWS","BYOL"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SMS_map = @{
    "LicenseType"=@("New-SMSReplicationJob","Update-SMSReplicationJob")
}

_awsArgumentCompleterRegistration $SMS_Completers $SMS_map


# Argument completions for service AWS Import/Export Snowball
$SNOW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Snowball.JobType
        {
            ($_ -eq "New-SNOWCluster/JobType") -Or
            ($_ -eq "New-SNOWJob/JobType")
        }
        {
            $v = "EXPORT","IMPORT","LOCAL_USE"
            break
        }
        
        # Amazon.Snowball.ShippingOption
        {
            ($_ -eq "New-SNOWCluster/ShippingOption") -Or
            ($_ -eq "New-SNOWJob/ShippingOption") -Or
            ($_ -eq "Update-SNOWCluster/ShippingOption") -Or
            ($_ -eq "Update-SNOWJob/ShippingOption")
        }
        {
            $v = "EXPRESS","NEXT_DAY","SECOND_DAY","STANDARD"
            break
        }
        
        # Amazon.Snowball.SnowballCapacity
        {
            ($_ -eq "New-SNOWJob/SnowballCapacityPreference") -Or
            ($_ -eq "Update-SNOWJob/SnowballCapacityPreference")
        }
        {
            $v = "NoPreference","T100","T50","T80"
            break
        }
        
        # Amazon.Snowball.SnowballType
        {
            ($_ -eq "New-SNOWCluster/SnowballType") -Or
            ($_ -eq "New-SNOWJob/SnowballType")
        }
        {
            $v = "EDGE","STANDARD"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SNOW_map = @{
    "JobType"=@("New-SNOWCluster","New-SNOWJob")
    "ShippingOption"=@("New-SNOWCluster","New-SNOWJob","Update-SNOWCluster","Update-SNOWJob")
    "SnowballCapacityPreference"=@("New-SNOWJob","Update-SNOWJob")
    "SnowballType"=@("New-SNOWCluster","New-SNOWJob")
}

_awsArgumentCompleterRegistration $SNOW_Completers $SNOW_map


# Argument completions for service Amazon Simple Systems Management
$SSM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SimpleSystemsManagement.AssociationStatusName
        "Update-SSMAssociationStatus/AssociationStatus_Name"
        {
            $v = "Failed","Pending","Success"
            break
        }
        
        # Amazon.SimpleSystemsManagement.DocumentHashType
        {
            ($_ -eq "Send-SSMCommand/DocumentHashType") -Or
            ($_ -eq "Register-SSMTaskWithMaintenanceWindow/TaskInvocationParameters_RunCommand_DocumentHashType") -Or
            ($_ -eq "Update-SSMMaintenanceWindowTask/TaskInvocationParameters_RunCommand_DocumentHashType")
        }
        {
            $v = "Sha1","Sha256"
            break
        }
        
        # Amazon.SimpleSystemsManagement.DocumentPermissionType
        {
            ($_ -eq "Edit-SSMDocumentPermission/PermissionType") -Or
            ($_ -eq "Get-SSMDocumentPermission/PermissionType")
        }
        {
            $v = "Share"
            break
        }
        
        # Amazon.SimpleSystemsManagement.DocumentType
        "New-SSMDocument/DocumentType"
        {
            $v = "Automation","Command","Policy"
            break
        }
        
        # Amazon.SimpleSystemsManagement.MaintenanceWindowResourceType
        "Register-SSMTargetWithMaintenanceWindow/ResourceType"
        {
            $v = "INSTANCE"
            break
        }
        
        # Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType
        "Register-SSMTaskWithMaintenanceWindow/TaskType"
        {
            $v = "AUTOMATION","LAMBDA","RUN_COMMAND","STEP_FUNCTIONS"
            break
        }
        
        # Amazon.SimpleSystemsManagement.NotificationType
        {
            ($_ -eq "Send-SSMCommand/NotificationConfig_NotificationType") -Or
            ($_ -eq "Register-SSMTaskWithMaintenanceWindow/TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType") -Or
            ($_ -eq "Update-SSMMaintenanceWindowTask/TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType")
        }
        {
            $v = "Command","Invocation"
            break
        }
        
        # Amazon.SimpleSystemsManagement.OperatingSystem
        {
            ($_ -eq "Get-SSMDefaultPatchBaseline/OperatingSystem") -Or
            ($_ -eq "Get-SSMPatchBaselineForPatchGroup/OperatingSystem") -Or
            ($_ -eq "New-SSMPatchBaseline/OperatingSystem")
        }
        {
            $v = "AMAZON_LINUX","REDHAT_ENTERPRISE_LINUX","UBUNTU","WINDOWS"
            break
        }
        
        # Amazon.SimpleSystemsManagement.ParameterType
        "Write-SSMParameter/Type"
        {
            $v = "SecureString","String","StringList"
            break
        }
        
        # Amazon.SimpleSystemsManagement.PatchComplianceLevel
        {
            ($_ -eq "New-SSMPatchBaseline/ApprovedPatchesComplianceLevel") -Or
            ($_ -eq "Update-SSMPatchBaseline/ApprovedPatchesComplianceLevel")
        }
        {
            $v = "CRITICAL","HIGH","INFORMATIONAL","LOW","MEDIUM","UNSPECIFIED"
            break
        }
        
        # Amazon.SimpleSystemsManagement.ResourceDataSyncS3Format
        "New-SSMResourceDataSync/S3Destination_SyncFormat"
        {
            $v = "JsonSerDe"
            break
        }
        
        # Amazon.SimpleSystemsManagement.ResourceTypeForTagging
        {
            ($_ -eq "Add-SSMResourceTag/ResourceType") -Or
            ($_ -eq "Get-SSMResourceTag/ResourceType") -Or
            ($_ -eq "Remove-SSMResourceTag/ResourceType")
        }
        {
            $v = "Document","MaintenanceWindow","ManagedInstance","Parameter","PatchBaseline"
            break
        }
        
        # Amazon.SimpleSystemsManagement.SignalType
        "Send-SSMAutomationSignal/SignalType"
        {
            $v = "Approve","Reject"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SSM_map = @{
    "ApprovedPatchesComplianceLevel"=@("New-SSMPatchBaseline","Update-SSMPatchBaseline")
    "AssociationStatus_Name"=@("Update-SSMAssociationStatus")
    "DocumentHashType"=@("Send-SSMCommand")
    "DocumentType"=@("New-SSMDocument")
    "NotificationConfig_NotificationType"=@("Send-SSMCommand")
    "OperatingSystem"=@("Get-SSMDefaultPatchBaseline","Get-SSMPatchBaselineForPatchGroup","New-SSMPatchBaseline")
    "PermissionType"=@("Edit-SSMDocumentPermission","Get-SSMDocumentPermission")
    "ResourceType"=@("Add-SSMResourceTag","Get-SSMResourceTag","Register-SSMTargetWithMaintenanceWindow","Remove-SSMResourceTag")
    "S3Destination_SyncFormat"=@("New-SSMResourceDataSync")
    "SignalType"=@("Send-SSMAutomationSignal")
    "TaskInvocationParameters_RunCommand_DocumentHashType"=@("Register-SSMTaskWithMaintenanceWindow","Update-SSMMaintenanceWindowTask")
    "TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType"=@("Register-SSMTaskWithMaintenanceWindow","Update-SSMMaintenanceWindowTask")
    "TaskType"=@("Register-SSMTaskWithMaintenanceWindow")
    "Type"=@("Write-SSMParameter")
}

_awsArgumentCompleterRegistration $SSM_Completers $SSM_map


# Argument completions for service AWS WAF
$WAF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WAF.RateKey
        "New-WAFRateBasedRule/RateKey"
        {
            $v = "IP"
            break
        }
        
        # Amazon.WAF.WafActionType
        {
            ($_ -eq "New-WAFWebACL/DefaultAction_Type") -Or
            ($_ -eq "Update-WAFWebACL/DefaultAction_Type")
        }
        {
            $v = "ALLOW","BLOCK","COUNT"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WAF_map = @{
    "DefaultAction_Type"=@("New-WAFWebACL","Update-WAFWebACL")
    "RateKey"=@("New-WAFRateBasedRule")
}

_awsArgumentCompleterRegistration $WAF_Completers $WAF_map


# Argument completions for service AWS WAF Regional
$WAFR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WAFRegional.RateKey
        "New-WAFRRateBasedRule/RateKey"
        {
            $v = "IP"
            break
        }
        
        # Amazon.WAFRegional.WafActionType
        {
            ($_ -eq "New-WAFRWebACL/DefaultAction_Type") -Or
            ($_ -eq "Update-WAFRWebACL/DefaultAction_Type")
        }
        {
            $v = "ALLOW","BLOCK","COUNT"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WAFR_map = @{
    "DefaultAction_Type"=@("New-WAFRWebACL","Update-WAFRWebACL")
    "RateKey"=@("New-WAFRRateBasedRule")
}

_awsArgumentCompleterRegistration $WAFR_Completers $WAFR_map


# Argument completions for service Amazon WorkDocs
$WD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkDocs.CommentVisibilityType
        "New-WDComment/Visibility"
        {
            $v = "PRIVATE","PUBLIC"
            break
        }
        
        # Amazon.WorkDocs.DocumentVersionStatus
        "Update-WDDocumentVersion/VersionStatus"
        {
            $v = "ACTIVE"
            break
        }
        
        # Amazon.WorkDocs.FolderContentType
        "Get-WDFolderContent/Type"
        {
            $v = "ALL","DOCUMENT","FOLDER"
            break
        }
        
        # Amazon.WorkDocs.LocaleType
        "Update-WDUser/Locale"
        {
            $v = "de","default","en","es","fr","ja","ko","pt_BR","ru","zh_CN","zh_TW"
            break
        }
        
        # Amazon.WorkDocs.OrderType
        {
            ($_ -eq "Get-WDFolderContent/Order") -Or
            ($_ -eq "Get-WDUserList/Order")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }
        
        # Amazon.WorkDocs.PrincipalType
        "Remove-WDResourcePermission/PrincipalType"
        {
            $v = "ANONYMOUS","GROUP","INVITE","ORGANIZATION","USER"
            break
        }
        
        # Amazon.WorkDocs.ResourceSortType
        "Get-WDFolderContent/Sort"
        {
            $v = "DATE","NAME"
            break
        }
        
        # Amazon.WorkDocs.ResourceStateType
        {
            ($_ -eq "Update-WDDocument/ResourceState") -Or
            ($_ -eq "Update-WDFolder/ResourceState")
        }
        {
            $v = "ACTIVE","RECYCLED","RECYCLING","RESTORING"
            break
        }
        
        # Amazon.WorkDocs.StorageType
        {
            ($_ -eq "New-WDUser/StorageRule_StorageType") -Or
            ($_ -eq "Update-WDUser/StorageRule_StorageType")
        }
        {
            $v = "QUOTA","UNLIMITED"
            break
        }
        
        # Amazon.WorkDocs.SubscriptionProtocolType
        "New-WDNotificationSubscription/Protocol"
        {
            $v = "HTTPS"
            break
        }
        
        # Amazon.WorkDocs.SubscriptionType
        "New-WDNotificationSubscription/SubscriptionType"
        {
            $v = "ALL"
            break
        }
        
        # Amazon.WorkDocs.UserFilterType
        "Get-WDUserList/Include"
        {
            $v = "ACTIVE_PENDING","ALL"
            break
        }
        
        # Amazon.WorkDocs.UserSortType
        "Get-WDUserList/Sort"
        {
            $v = "FULL_NAME","STORAGE_LIMIT","STORAGE_USED","USER_NAME","USER_STATUS"
            break
        }
        
        # Amazon.WorkDocs.UserType
        "Update-WDUser/Type"
        {
            $v = "ADMIN","USER"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WD_map = @{
    "Include"=@("Get-WDUserList")
    "Locale"=@("Update-WDUser")
    "Order"=@("Get-WDFolderContent","Get-WDUserList")
    "PrincipalType"=@("Remove-WDResourcePermission")
    "Protocol"=@("New-WDNotificationSubscription")
    "ResourceState"=@("Update-WDDocument","Update-WDFolder")
    "Sort"=@("Get-WDFolderContent","Get-WDUserList")
    "StorageRule_StorageType"=@("New-WDUser","Update-WDUser")
    "SubscriptionType"=@("New-WDNotificationSubscription")
    "Type"=@("Get-WDFolderContent","Update-WDUser")
    "VersionStatus"=@("Update-WDDocumentVersion")
    "Visibility"=@("New-WDComment")
}

_awsArgumentCompleterRegistration $WD_Completers $WD_map


# Argument completions for service Amazon WorkSpaces
$WKS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkSpaces.RunningMode
        "Edit-WKSWorkspaceProperty/WorkspaceProperties_RunningMode"
        {
            $v = "ALWAYS_ON","AUTO_STOP"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WKS_map = @{
    "WorkspaceProperties_RunningMode"=@("Edit-WKSWorkspaceProperty")
}

_awsArgumentCompleterRegistration $WKS_Completers $WKS_map

# end auto-generated service completers
