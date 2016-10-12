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
	$profiles = Get-AWSCredentials -ListProfiles
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
            $v = "COGNITO_USER_POOLS","TOKEN"
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
        
        # Amazon.APIGateway.IntegrationType
        "Write-AGIntegration/Type"
        {
            $v = "AWS","AWS_PROXY","HTTP","HTTP_PROXY","MOCK"
            break
        }
        
        # Amazon.APIGateway.PutMode
        "Write-AGRestApi/Mode"
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
    "Format"=@("Import-AGApiKey")
    "Mode"=@("Write-AGRestApi")
    "Quota_Period"=@("New-AGUsagePlan")
    "Type"=@("New-AGAuthorizer","Write-AGIntegration")
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
        
        # Amazon.ApplicationAutoScaling.PolicyType
        "Write-AASScalingPolicy/PolicyType"
        {
            $v = "StepScaling"
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
            $v = "ec2:spot-fleet-request:TargetCapacity","ecs:service:DesiredCount"
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
            $v = "ec2","ecs"
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
            $v = "CONNECTION","PROCESS","SERVER"
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
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EB_map = @{
    "InfoType"=@("Get-EBEnvironmentInfo","Request-EBEnvironmentInfo")
    "Severity"=@("Get-EBEvent")
    "Status"=@("Get-EBEnvironmentManagedAction")
}

_awsArgumentCompleterRegistration $EB_Completers $EB_map


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
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CFN_map = @{
    "OnFailure"=@("New-CFNStack")
    "Status"=@("Send-CFNResourceSignal")
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
            ($_ -eq "Get-CWMetricStatistics/Unit") -Or
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
    "Unit"=@("Get-CWAlarmForMetric","Get-CWMetricStatistics","Write-CWMetricAlarm")
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
        # Amazon.CloudWatchLogs.ExportTaskStatusCode
        "Get-CWLExportTasks/StatusCode"
        {
            $v = "CANCELLED","COMPLETED","FAILED","PENDING","PENDING_CANCEL","RUNNING"
            break
        }
        
        # Amazon.CloudWatchLogs.OrderBy
        "Get-CWLLogStreams/OrderBy"
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
    "OrderBy"=@("Get-CWLLogStreams")
    "StatusCode"=@("Get-CWLExportTasks")
}

_awsArgumentCompleterRegistration $CWL_Completers $CWL_map


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
    "Deployed"=@("Get-CDApplicationRevisionList")
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
            ($_ -eq "Get-CPActionableJobs/ActionTypeId_Category") -Or
            ($_ -eq "Get-CPActionableThirdPartyJobs/ActionTypeId_Category") -Or
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
            ($_ -eq "Get-CPActionableJobs/ActionTypeId_Owner") -Or
            ($_ -eq "Get-CPActionableThirdPartyJobs/ActionTypeId_Owner")
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
    "ActionTypeId_Category"=@("Get-CPActionableJobs","Get-CPActionableThirdPartyJobs")
    "ActionTypeId_Owner"=@("Get-CPActionableJobs","Get-CPActionableThirdPartyJobs")
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
        
        # Amazon.CognitoIdentityProvider.DeviceRememberedStatusType
        {
            ($_ -eq "Edit-CGIPDeviceStatus/DeviceRememberedStatus") -Or
            ($_ -eq "Edit-CGIPDeviceStatusAdmin/DeviceRememberedStatus")
        }
        {
            $v = "not_remembered","remembered"
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
            $v = "AWS::ACM::Certificate","AWS::CloudTrail::Trail","AWS::EC2::CustomerGateway","AWS::EC2::EIP","AWS::EC2::Host","AWS::EC2::Instance","AWS::EC2::InternetGateway","AWS::EC2::NetworkAcl","AWS::EC2::NetworkInterface","AWS::EC2::RouteTable","AWS::EC2::SecurityGroup","AWS::EC2::Subnet","AWS::EC2::Volume","AWS::EC2::VPC","AWS::EC2::VPNConnection","AWS::EC2::VPNGateway","AWS::ElasticLoadBalancingV2::LoadBalancer","AWS::IAM::Group","AWS::IAM::Policy","AWS::IAM::Role","AWS::IAM::User","AWS::RDS::DBInstance","AWS::RDS::DBSecurityGroup","AWS::RDS::DBSnapshot","AWS::RDS::DBSubnetGroup","AWS::RDS::EventSubscription"
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


# Argument completions for service AWS Database Migration Service
$DMS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
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
        "New-DMSReplicationTask/MigrationType"
        {
            $v = "cdc","full-load","full-load-and-cdc"
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
    "MigrationType"=@("New-DMSReplicationTask")
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
        
        # Amazon.DeviceFarm.TestType
        {
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
    "Test_Type"=@("Submit-DFTestRun")
    "TestType"=@("Get-DFDevicePoolCompatibility")
    "Type"=@("Get-DFArtifactList","Get-DFDevicePoolList","New-DFUpload")
}

_awsArgumentCompleterRegistration $DF_Completers $DF_map


# Argument completions for service AWS Direct Connect
$DC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DirectConnect.LoaContentType
        {
            ($_ -eq "Get-DCConnectionLoa/LoaContentType") -Or
            ($_ -eq "Get-DCInterconnectLoa/LoaContentType")
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
    "LoaContentType"=@("Get-DCConnectionLoa","Get-DCInterconnectLoa")
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
            ($_ -eq "Edit-EC2Hosts/AutoPlacement") -Or
            ($_ -eq "New-EC2Hosts/AutoPlacement")
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
        "New-EC2FlowLogs/ResourceType"
        {
            $v = "NetworkInterface","Subnet","VPC"
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
        
        # Amazon.EC2.InstanceType
        {
            ($_ -eq "Get-EC2ReservedInstancesOffering/InstanceType") -Or
            ($_ -eq "New-EC2Instance/InstanceType") -Or
            ($_ -eq "Request-EC2SpotInstance/LaunchSpecification_InstanceType")
        }
        {
            $v = "c1.medium","c1.xlarge","c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","cc1.4xlarge","cc2.8xlarge","cg1.4xlarge","cr1.8xlarge","d2.2xlarge","d2.4xlarge","d2.8xlarge","d2.xlarge","g2.2xlarge","g2.8xlarge","hi1.4xlarge","hs1.8xlarge","i2.2xlarge","i2.4xlarge","i2.8xlarge","i2.xlarge","m1.large","m1.medium","m1.small","m1.xlarge","m2.2xlarge","m2.4xlarge","m2.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.16xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","p2.16xlarge","p2.8xlarge","p2.xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","t1.micro","t2.large","t2.medium","t2.micro","t2.nano","t2.small","x1.16xlarge","x1.32xlarge"
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
            ($_ -eq "New-EC2Instance/Tenancy")
        }
        {
            $v = "dedicated","default","host"
            break
        }
        
        # Amazon.EC2.TrafficType
        "New-EC2FlowLogs/TrafficType"
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
        "New-EC2Volume/VolumeType"
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
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EC2_map = @{
    "Affinity"=@("Edit-EC2InstancePlacement")
    "Architecture"=@("Register-EC2Image")
    "Attribute"=@("Edit-EC2InstanceAttribute","Edit-EC2SnapshotAttribute","Get-EC2ImageAttribute","Get-EC2InstanceAttribute","Get-EC2NetworkInterfaceAttribute","Get-EC2SnapshotAttribute","Get-EC2VolumeAttribute","Get-EC2VpcAttribute","Reset-EC2ImageAttribute","Reset-EC2InstanceAttribute","Reset-EC2SnapshotAttribute")
    "AutoPlacement"=@("Edit-EC2Hosts","New-EC2Hosts")
    "CurrencyCode"=@("New-EC2HostReservation")
    "Domain"=@("New-EC2Address")
    "EventType"=@("Get-EC2SpotFleetRequestHistory")
    "ExcessCapacityTerminationPolicy"=@("Edit-EC2SpotFleetRequest")
    "ExportToS3Task_ContainerFormat"=@("New-EC2InstanceExportTask")
    "ExportToS3Task_DiskImageFormat"=@("New-EC2InstanceExportTask")
    "InstanceInitiatedShutdownBehavior"=@("New-EC2Instance")
    "InstanceTenancy"=@("Get-EC2ReservedInstancesOffering","New-EC2Vpc")
    "InstanceType"=@("Get-EC2ReservedInstancesOffering","New-EC2Instance")
    "LaunchSpecification_InstanceType"=@("Request-EC2SpotInstance")
    "LimitPrice_CurrencyCode"=@("New-EC2ReservedInstance")
    "OfferingClass"=@("Get-EC2ReservedInstance","Get-EC2ReservedInstancesOffering")
    "OfferingType"=@("Get-EC2ReservedInstance","Get-EC2ReservedInstancesOffering")
    "OperationType"=@("Edit-EC2ImageAttribute","Edit-EC2SnapshotAttribute")
    "ProductDescription"=@("Get-EC2ReservedInstancesOffering")
    "ResourceType"=@("New-EC2FlowLogs")
    "RuleAction"=@("New-EC2NetworkAclEntry","Set-EC2NetworkAclEntry")
    "SpotFleetRequestConfig_AllocationStrategy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_ExcessCapacityTerminationPolicy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_Type"=@("Request-EC2SpotFleet")
    "Status"=@("Send-EC2InstanceStatus")
    "Strategy"=@("New-EC2PlacementGroup")
    "TargetEnvironment"=@("New-EC2InstanceExportTask")
    "Tenancy"=@("Edit-EC2InstancePlacement","New-EC2Instance")
    "TrafficType"=@("New-EC2FlowLogs")
    "Type"=@("New-EC2CustomerGateway","New-EC2VpnGateway","Request-EC2SpotInstance")
    "VolumeType"=@("New-EC2Volume")
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
            ($_ -eq "Get-ECRImageMetadata/Filter_TagStatus")
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
    "Filter_TagStatus"=@("Get-ECRImage","Get-ECRImageMetadata")
}

_awsArgumentCompleterRegistration $ECR_Completers $ECR_map


# Argument completions for service Amazon EC2 Container Service
$ECS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ECS.DesiredStatus
        "Get-ECSTasks/DesiredStatus"
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
        "Get-ECSTaskDefinitions/Sort"
        {
            $v = "ASC","DESC"
            break
        }
        
        # Amazon.ECS.TaskDefinitionFamilyStatus
        "Get-ECSTaskDefinitionFamilies/Status"
        {
            $v = "ACTIVE","ALL","INACTIVE"
            break
        }
        
        # Amazon.ECS.TaskDefinitionStatus
        "Get-ECSTaskDefinitions/Status"
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
    "DesiredStatus"=@("Get-ECSTasks")
    "NetworkMode"=@("Register-ECSTaskDefinition")
    "Sort"=@("Get-ECSTaskDefinitions")
    "Status"=@("Get-ECSTaskDefinitionFamilies","Get-ECSTaskDefinitions")
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
            $v = "cache-cluster","cache-parameter-group","cache-security-group","cache-subnet-group"
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
        # Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum
        "New-ELB2LoadBalancer/Scheme"
        {
            $v = "internal","internet-facing"
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
            $v = "HTTP","HTTPS"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ELB2_map = @{
    "HealthCheckProtocol"=@("Edit-ELB2TargetGroup","New-ELB2TargetGroup")
    "Protocol"=@("Edit-ELB2Listener","New-ELB2Listener","New-ELB2TargetGroup")
    "Scheme"=@("New-ELB2LoadBalancer")
}

_awsArgumentCompleterRegistration $ELB2_Completers $ELB2_map


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
            ($_ -eq "Update-ESDomainConfig/ElasticsearchClusterConfig_InstanceType")
        }
        {
            $v = "i2.2xlarge.elasticsearch","i2.xlarge.elasticsearch","m3.2xlarge.elasticsearch","m3.large.elasticsearch","m3.medium.elasticsearch","m3.xlarge.elasticsearch","m4.10xlarge.elasticsearch","m4.2xlarge.elasticsearch","m4.4xlarge.elasticsearch","m4.large.elasticsearch","m4.xlarge.elasticsearch","r3.2xlarge.elasticsearch","r3.4xlarge.elasticsearch","r3.8xlarge.elasticsearch","r3.large.elasticsearch","r3.xlarge.elasticsearch","t2.medium.elasticsearch","t2.micro.elasticsearch","t2.small.elasticsearch"
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
}

_awsArgumentCompleterRegistration $ES_Completers $ES_map


# Argument completions for service Amazon GameLift Service
$GML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
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
            $v = "c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","t2.large","t2.medium","t2.micro","t2.small"
            break
        }
        
        # Amazon.GameLift.MetricName
        "Write-GMLScalingPolicy/MetricName"
        {
            $v = "ActivatingGameSessions","ActiveGameSessions","ActiveInstances","AvailablePlayerSessions","CurrentPlayerSessions","IdleInstances"
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
        "Get-IAMPolicies/Scope"
        {
            $v = "All","AWS","Local"
            break
        }
        
        # Amazon.IdentityManagement.StatusType
        {
            ($_ -eq "Update-IAMAccessKey/Status") -Or
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
    "Scope"=@("Get-IAMPolicies")
    "Status"=@("Update-IAMAccessKey","Update-IAMSigningCertificate","Update-IAMSSHPublicKey")
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
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$INS_map = @{
    "Event"=@("Add-INSEventSubscription","Remove-INSEventSubscription")
    "Locale"=@("Get-INSFinding","Get-INSRulesPackage")
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
        "Set-IOTLoggingOptions/LoggingOptionsPayload_LogLevel"
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
    "LoggingOptionsPayload_LogLevel"=@("Set-IOTLoggingOptions")
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
            $v = "LATEST","TRIM_HORIZON"
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
            $v = "java8","nodejs","nodejs4.3","python2.7"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LM_map = @{
    "InvocationType"=@("Invoke-LMFunction")
    "LogType"=@("Invoke-LMFunction")
    "Runtime"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "StartingPosition"=@("New-LMEventSourceMapping")
}

_awsArgumentCompleterRegistration $LM_Completers $LM_map


# Argument completions for service AWS Marketplace Commerce Analytics
$MCA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AWSMarketplaceCommerceAnalytics.DataSetType
        "New-MCADataSet/DataSetType"
        {
            $v = "customer_profile_by_geography","customer_profile_by_industry","customer_profile_by_revenue","customer_subscriber_annual_subscriptions","customer_subscriber_hourly_monthly_subscriptions","daily_business_canceled_product_subscribers","daily_business_fees","daily_business_free_trial_conversions","daily_business_new_instances","daily_business_new_product_subscribers","daily_business_usage_by_instance_type","disbursed_amount_by_age_of_disbursed_funds","disbursed_amount_by_age_of_uncollected_funds","disbursed_amount_by_customer_geo","disbursed_amount_by_product","disbursed_amount_by_product_with_uncollected_funds","monthly_revenue_annual_subscriptions","monthly_revenue_billing_and_revenue_data"
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
        "Get-MLBatchPredictions/FilterVariable"
        {
            $v = "CreatedAt","DataSourceId","DataURI","IAMUser","LastUpdatedAt","MLModelId","Name","Status"
            break
        }
        
        # Amazon.MachineLearning.DataSourceFilterVariable
        "Get-MLDataSources/FilterVariable"
        {
            $v = "CreatedAt","DataLocationS3","IAMUser","LastUpdatedAt","Name","Status"
            break
        }
        
        # Amazon.MachineLearning.EvaluationFilterVariable
        "Get-MLEvaluations/FilterVariable"
        {
            $v = "CreatedAt","DataSourceId","DataURI","IAMUser","LastUpdatedAt","MLModelId","Name","Status"
            break
        }
        
        # Amazon.MachineLearning.MLModelFilterVariable
        "Get-MLModels/FilterVariable"
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
            ($_ -eq "Get-MLBatchPredictions/SortOrder") -Or
            ($_ -eq "Get-MLDataSources/SortOrder") -Or
            ($_ -eq "Get-MLEvaluations/SortOrder") -Or
            ($_ -eq "Get-MLModels/SortOrder")
        }
        {
            $v = "asc","dsc"
            break
        }
        
        # Amazon.MachineLearning.TaggableResourceType
        {
            ($_ -eq "Add-MLTag/ResourceType") -Or
            ($_ -eq "Get-MLTag/ResourceType") -Or
            ($_ -eq "Remove-MLTag/ResourceType")
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
    "FilterVariable"=@("Get-MLBatchPredictions","Get-MLDataSources","Get-MLEvaluations","Get-MLModels")
    "MLModelType"=@("New-MLModel")
    "ResourceType"=@("Add-MLTag","Get-MLTag","Remove-MLTag")
    "SortOrder"=@("Get-MLBatchPredictions","Get-MLDataSources","Get-MLEvaluations","Get-MLModels")
}

_awsArgumentCompleterRegistration $ML_Completers $ML_map


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
        "Get-RSEvents/SourceType"
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
    "SourceType"=@("Get-RSEvents")
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
            $v = "ap-northeast-1","ap-northeast-2","ap-south-1","ap-southeast-1","ap-southeast-2","eu-central-1","eu-west-1","sa-east-1","us-east-1","us-west-1","us-west-2"
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
            ($_ -eq "Get-R53TrafficPolicyInstances/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53TrafficPolicyInstancesByHostedZone/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53TrafficPolicyInstancesByPolicy/TrafficPolicyInstanceTypeMarker") -Or
            ($_ -eq "Get-R53ChangeBatchesByRRSet/Type")
        }
        {
            $v = "A","AAAA","CNAME","MX","NAPTR","NS","PTR","SOA","SPF","SRV","TXT"
            break
        }
        
        # Amazon.Route53.TagResourceType
        {
            ($_ -eq "Edit-R53TagsForResource/ResourceType") -Or
            ($_ -eq "Get-R53TagsForResource/ResourceType") -Or
            ($_ -eq "Get-R53TagsForResources/ResourceType")
        }
        {
            $v = "healthcheck","hostedzone"
            break
        }
        
        # Amazon.Route53.VPCRegion
        {
            ($_ -eq "New-R53HostedZone/VPC_VPCRegion") -Or
            ($_ -eq "Register-R53VPCWithHostedZone/VPC_VPCRegion") -Or
            ($_ -eq "Unregister-R53VPCFromHostedZone/VPC_VPCRegion")
        }
        {
            $v = "ap-northeast-1","ap-northeast-2","ap-south-1","ap-southeast-1","ap-southeast-2","cn-north-1","eu-central-1","eu-west-1","sa-east-1","us-east-1","us-west-1","us-west-2"
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
    "ResourceType"=@("Edit-R53TagsForResource","Get-R53TagsForResource","Get-R53TagsForResources")
    "StartRecordType"=@("Get-R53ResourceRecordSet")
    "TrafficPolicyInstanceTypeMarker"=@("Get-R53TrafficPolicyInstances","Get-R53TrafficPolicyInstancesByHostedZone","Get-R53TrafficPolicyInstancesByPolicy")
    "Type"=@("Get-R53ChangeBatchesByRRSet")
    "VPC_VPCRegion"=@("New-R53HostedZone","Register-R53VPCWithHostedZone","Unregister-R53VPCFromHostedZone")
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
    "CannedACLName"=@("Copy-S3Object","New-S3Bucket","Set-S3ACL","Write-S3Object")
    "CopySourceServerSideEncryptionCustomerMethod"=@("Copy-S3Object")
    "Encoding"=@("Get-S3Object","Get-S3Version")
    "ServerSideEncryption"=@("Copy-S3Object","Write-S3Object")
    "ServerSideEncryptionCustomerMethod"=@("Copy-S3Object","Get-S3ObjectMetadata","Get-S3PreSignedURL","Read-S3Object","Write-S3Object")
    "ServerSideEncryptionMethod"=@("Get-S3PreSignedURL")
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
        
        # Amazon.ServiceCatalog.ProductViewSortBy
        "Find-SCProduct/SortBy"
        {
            $v = "CreationDate","Title","VersionCount"
            break
        }
        
        # Amazon.ServiceCatalog.SortOrder
        "Find-SCProduct/SortOrder"
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
    "SortBy"=@("Find-SCProduct")
    "SortOrder"=@("Find-SCProduct")
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


# Argument completions for service AWS Import/Export Snowball
$SNOW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Snowball.JobType
        "New-SNOWJob/JobType"
        {
            $v = "EXPORT","IMPORT"
            break
        }
        
        # Amazon.Snowball.ShippingOption
        {
            ($_ -eq "New-SNOWJob/ShippingOption") -Or
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
            $v = "NoPreference","T50","T80"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SNOW_map = @{
    "JobType"=@("New-SNOWJob")
    "ShippingOption"=@("New-SNOWJob","Update-SNOWJob")
    "SnowballCapacityPreference"=@("New-SNOWJob","Update-SNOWJob")
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
        "Send-SSMCommand/DocumentHashType"
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
        
        # Amazon.SimpleSystemsManagement.NotificationType
        "Send-SSMCommand/NotificationConfig_NotificationType"
        {
            $v = "Command","Invocation"
            break
        }
        
        # Amazon.SimpleSystemsManagement.ResourceTypeForTagging
        {
            ($_ -eq "Add-SSMResourceTag/ResourceType") -Or
            ($_ -eq "Get-SSMResourceTag/ResourceType") -Or
            ($_ -eq "Remove-SSMResourceTag/ResourceType")
        }
        {
            $v = "ManagedInstance"
            break
        }
        
    }
    
    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SSM_map = @{
    "AssociationStatus_Name"=@("Update-SSMAssociationStatus")
    "DocumentHashType"=@("Send-SSMCommand")
    "NotificationConfig_NotificationType"=@("Send-SSMCommand")
    "PermissionType"=@("Edit-SSMDocumentPermission","Get-SSMDocumentPermission")
    "ResourceType"=@("Add-SSMResourceTag","Get-SSMResourceTag","Remove-SSMResourceTag")
}

_awsArgumentCompleterRegistration $SSM_Completers $SSM_map


# Argument completions for service AWS WAF
$WAF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
    
    switch ($("$commandName/$parameterName"))
    {
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
}

_awsArgumentCompleterRegistration $WAF_Completers $WAF_map


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
