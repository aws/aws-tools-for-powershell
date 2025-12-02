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

# Argument completions for service Amazon CloudWatch Logs


$CWL_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudWatchLogs.DeliveryDestinationType
        "Write-CWLDeliveryDestination/DeliveryDestinationType"
        {
            $v = "CWL","FH","S3","XRAY"
            break
        }

        # Amazon.CloudWatchLogs.Distribution
        "Write-CWLSubscriptionFilter/Distribution"
        {
            $v = "ByLogStream","Random"
            break
        }

        # Amazon.CloudWatchLogs.EvaluationFrequency
        {
            ($_ -eq "New-CWLLogAnomalyDetector/EvaluationFrequency") -Or
            ($_ -eq "Update-CWLLogAnomalyDetector/EvaluationFrequency")
        }
        {
            $v = "FIFTEEN_MIN","FIVE_MIN","ONE_HOUR","ONE_MIN","TEN_MIN","THIRTY_MIN"
            break
        }

        # Amazon.CloudWatchLogs.ExportTaskStatusCode
        "Get-CWLExportTask/StatusCode"
        {
            $v = "CANCELLED","COMPLETED","FAILED","PENDING","PENDING_CANCEL","RUNNING"
            break
        }

        # Amazon.CloudWatchLogs.IntegrationStatus
        "Get-CWLIntegrationList/IntegrationStatus"
        {
            $v = "ACTIVE","FAILED","PROVISIONING"
            break
        }

        # Amazon.CloudWatchLogs.IntegrationType
        {
            ($_ -eq "Get-CWLIntegrationList/IntegrationType") -Or
            ($_ -eq "Write-CWLIntegration/IntegrationType")
        }
        {
            $v = "OPENSEARCH"
            break
        }

        # Amazon.CloudWatchLogs.ListAggregateLogGroupSummariesGroupBy
        "Get-CWLAggregateLogGroupSummaryList/GroupBy"
        {
            $v = "DATA_SOURCE_NAME_AND_TYPE","DATA_SOURCE_NAME_TYPE_AND_FORMAT"
            break
        }

        # Amazon.CloudWatchLogs.LogGroupClass
        {
            ($_ -eq "Get-CWLAggregateLogGroupSummaryList/LogGroupClass") -Or
            ($_ -eq "Get-CWLLogGroup/LogGroupClass") -Or
            ($_ -eq "Get-CWLLogGroupList/LogGroupClass") -Or
            ($_ -eq "New-CWLLogGroup/LogGroupClass")
        }
        {
            $v = "DELIVERY","INFREQUENT_ACCESS","STANDARD"
            break
        }

        # Amazon.CloudWatchLogs.OrderBy
        "Get-CWLLogStream/OrderBy"
        {
            $v = "LastEventTime","LogStreamName"
            break
        }

        # Amazon.CloudWatchLogs.OutputFormat
        "Write-CWLDeliveryDestination/OutputFormat"
        {
            $v = "json","parquet","plain","raw","w3c"
            break
        }

        # Amazon.CloudWatchLogs.PolicyScope
        "Get-CWLResourcePolicy/PolicyScope"
        {
            $v = "ACCOUNT","RESOURCE"
            break
        }

        # Amazon.CloudWatchLogs.PolicyType
        {
            ($_ -eq "Get-CWLAccountPolicy/PolicyType") -Or
            ($_ -eq "Remove-CWLAccountPolicy/PolicyType") -Or
            ($_ -eq "Write-CWLAccountPolicy/PolicyType")
        }
        {
            $v = "DATA_PROTECTION_POLICY","FIELD_INDEX_POLICY","METRIC_EXTRACTION_POLICY","SUBSCRIPTION_FILTER_POLICY","TRANSFORMER_POLICY"
            break
        }

        # Amazon.CloudWatchLogs.QueryLanguage
        {
            ($_ -eq "Get-CWLQuery/QueryLanguage") -Or
            ($_ -eq "Get-CWLQueryDefinition/QueryLanguage") -Or
            ($_ -eq "New-CWLScheduledQuery/QueryLanguage") -Or
            ($_ -eq "Start-CWLQuery/QueryLanguage") -Or
            ($_ -eq "Update-CWLScheduledQuery/QueryLanguage") -Or
            ($_ -eq "Write-CWLQueryDefinition/QueryLanguage")
        }
        {
            $v = "CWLI","PPL","SQL"
            break
        }

        # Amazon.CloudWatchLogs.QueryStatus
        "Get-CWLQuery/Status"
        {
            $v = "Cancelled","Complete","Failed","Running","Scheduled","Timeout","Unknown"
            break
        }

        # Amazon.CloudWatchLogs.ScheduledQueryState
        {
            ($_ -eq "Get-CWLScheduledQueryList/State") -Or
            ($_ -eq "New-CWLScheduledQuery/State") -Or
            ($_ -eq "Update-CWLScheduledQuery/State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CloudWatchLogs.Scope
        "Write-CWLAccountPolicy/Scope"
        {
            $v = "ALL"
            break
        }

        # Amazon.CloudWatchLogs.SuppressionState
        "Get-CWLAnomalyList/SuppressionState"
        {
            $v = "SUPPRESSED","UNSUPPRESSED"
            break
        }

        # Amazon.CloudWatchLogs.SuppressionType
        "Update-CWLAnomaly/SuppressionType"
        {
            $v = "INFINITE","LIMITED"
            break
        }

        # Amazon.CloudWatchLogs.SuppressionUnit
        "Update-CWLAnomaly/SuppressionPeriod_SuppressionUnit"
        {
            $v = "HOURS","MINUTES","SECONDS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWL_map = @{
    "DeliveryDestinationType"=@("Write-CWLDeliveryDestination")
    "Distribution"=@("Write-CWLSubscriptionFilter")
    "EvaluationFrequency"=@("New-CWLLogAnomalyDetector","Update-CWLLogAnomalyDetector")
    "GroupBy"=@("Get-CWLAggregateLogGroupSummaryList")
    "IntegrationStatus"=@("Get-CWLIntegrationList")
    "IntegrationType"=@("Get-CWLIntegrationList","Write-CWLIntegration")
    "LogGroupClass"=@("Get-CWLAggregateLogGroupSummaryList","Get-CWLLogGroup","Get-CWLLogGroupList","New-CWLLogGroup")
    "OrderBy"=@("Get-CWLLogStream")
    "OutputFormat"=@("Write-CWLDeliveryDestination")
    "PolicyScope"=@("Get-CWLResourcePolicy")
    "PolicyType"=@("Get-CWLAccountPolicy","Remove-CWLAccountPolicy","Write-CWLAccountPolicy")
    "QueryLanguage"=@("Get-CWLQuery","Get-CWLQueryDefinition","New-CWLScheduledQuery","Start-CWLQuery","Update-CWLScheduledQuery","Write-CWLQueryDefinition")
    "Scope"=@("Write-CWLAccountPolicy")
    "State"=@("Get-CWLScheduledQueryList","New-CWLScheduledQuery","Update-CWLScheduledQuery")
    "Status"=@("Get-CWLQuery")
    "StatusCode"=@("Get-CWLExportTask")
    "SuppressionPeriod_SuppressionUnit"=@("Update-CWLAnomaly")
    "SuppressionState"=@("Get-CWLAnomalyList")
    "SuppressionType"=@("Update-CWLAnomaly")
}

_awsArgumentCompleterRegistration $CWL_Completers $CWL_map

$CWL_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CWL.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWL_SelectMap = @{
    "Select"=@("Register-CWLKmsKey",
               "Register-CWLSourceToS3TableIntegration",
               "Stop-CWLExportTask",
               "New-CWLDelivery",
               "New-CWLExportTask",
               "New-CWLLogAnomalyDetector",
               "New-CWLLogGroup",
               "New-CWLLogStream",
               "New-CWLScheduledQuery",
               "Remove-CWLAccountPolicy",
               "Remove-CWLDataProtectionPolicy",
               "Remove-CWLDelivery",
               "Remove-CWLDeliveryDestination",
               "Remove-CWLDeliveryDestinationPolicy",
               "Remove-CWLDeliverySource",
               "Remove-CWLDestination",
               "Remove-CWLIndexPolicy",
               "Remove-CWLIntegration",
               "Remove-CWLLogAnomalyDetector",
               "Remove-CWLLogGroup",
               "Remove-CWLLogStream",
               "Remove-CWLMetricFilter",
               "Remove-CWLQueryDefinition",
               "Remove-CWLResourcePolicy",
               "Remove-CWLRetentionPolicy",
               "Remove-CWLScheduledQuery",
               "Remove-CWLSubscriptionFilter",
               "Remove-CWLTransformer",
               "Get-CWLAccountPolicy",
               "Find-CWLConfigurationTemplate",
               "Find-CWLDelivery",
               "Find-CWLDeliveryDestination",
               "Find-CWLDeliverySource",
               "Get-CWLDestination",
               "Get-CWLExportTask",
               "Get-CWLFieldIndex",
               "Get-CWLIndexPolicy",
               "Get-CWLLogGroup",
               "Get-CWLLogStream",
               "Get-CWLMetricFilter",
               "Get-CWLQuery",
               "Get-CWLQueryDefinition",
               "Get-CWLResourcePolicy",
               "Get-CWLSubscriptionFilter",
               "Unregister-CWLKmsKey",
               "Unregister-CWLSourceFromS3TableIntegration",
               "Get-CWLFilteredLogEvent",
               "Get-CWLDataProtectionPolicy",
               "Get-CWLDelivery",
               "Get-CWLDeliveryDestination",
               "Get-CWLDeliveryDestinationPolicy",
               "Get-CWLDeliverySource",
               "Get-CWLIntegration",
               "Get-CWLLogAnomalyDetector",
               "Get-CWLLogEvent",
               "Get-CWLLogField",
               "Get-CWLLogGroupField",
               "Get-CWLLogObject",
               "Get-CWLLogRecord",
               "Get-CWLQueryResult",
               "Get-CWLScheduledQuery",
               "Get-CWLScheduledQueryHistory",
               "Get-CWLTransformer",
               "Get-CWLAggregateLogGroupSummaryList",
               "Get-CWLAnomalyList",
               "Get-CWLIntegrationList",
               "Get-CWLLogAnomalyDetectorList",
               "Get-CWLLogGroupList",
               "Get-CWLLogGroupsForQueryList",
               "Get-CWLScheduledQueryList",
               "Get-CWLSourcesForS3TableIntegrationList",
               "Get-CWLResourceTag",
               "Get-CWLLogGroupTag",
               "Write-CWLAccountPolicy",
               "Write-CWLDataProtectionPolicy",
               "Write-CWLDeliveryDestination",
               "Write-CWLDeliveryDestinationPolicy",
               "Write-CWLDeliverySource",
               "Write-CWLDestination",
               "Write-CWLDestinationPolicy",
               "Write-CWLIndexPolicy",
               "Write-CWLIntegration",
               "Write-CWLLogEvent",
               "Write-CWLLogGroupDeletionProtection",
               "Write-CWLMetricFilter",
               "Write-CWLQueryDefinition",
               "Write-CWLResourcePolicy",
               "Write-CWLRetentionPolicy",
               "Write-CWLSubscriptionFilter",
               "Write-CWLTransformer",
               "Start-CWLLiveTail",
               "Start-CWLQuery",
               "Stop-CWLQuery",
               "Add-CWLLogGroupTag",
               "Add-CWLResourceTag",
               "Test-CWLMetricFilter",
               "Test-CWLTransformer",
               "Remove-CWLLogGroupTag",
               "Remove-CWLResourceTag",
               "Update-CWLAnomaly",
               "Update-CWLDeliveryConfiguration",
               "Update-CWLLogAnomalyDetector",
               "Update-CWLScheduledQuery")
}

_awsArgumentCompleterRegistration $CWL_SelectCompleters $CWL_SelectMap

