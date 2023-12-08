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

# Argument completions for service Amazon CloudWatch


$CW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudWatch.ComparisonOperator
        "Write-CWMetricAlarm/ComparisonOperator"
        {
            $v = "GreaterThanOrEqualToThreshold","GreaterThanThreshold","GreaterThanUpperThreshold","LessThanLowerOrGreaterThanUpperThreshold","LessThanLowerThreshold","LessThanOrEqualToThreshold","LessThanThreshold"
            break
        }

        # Amazon.CloudWatch.HistoryItemType
        "Get-CWAlarmHistory/HistoryItemType"
        {
            $v = "Action","ConfigurationUpdate","StateUpdate"
            break
        }

        # Amazon.CloudWatch.MetricStreamOutputFormat
        "Write-CWMetricStream/OutputFormat"
        {
            $v = "json","opentelemetry0.7","opentelemetry1.0"
            break
        }

        # Amazon.CloudWatch.RecentlyActive
        "Get-CWMetricList/RecentlyActive"
        {
            $v = "PT3H"
            break
        }

        # Amazon.CloudWatch.ScanBy
        {
            ($_ -eq "Get-CWAlarmHistory/ScanBy") -Or
            ($_ -eq "Get-CWMetricData/ScanBy")
        }
        {
            $v = "TimestampAscending","TimestampDescending"
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
    "OutputFormat"=@("Write-CWMetricStream")
    "RecentlyActive"=@("Get-CWMetricList")
    "ScanBy"=@("Get-CWAlarmHistory","Get-CWMetricData")
    "StateValue"=@("Get-CWAlarm","Set-CWAlarmState")
    "Statistic"=@("Get-CWAlarmForMetric","Write-CWMetricAlarm")
    "Unit"=@("Get-CWAlarmForMetric","Get-CWMetricStatistic","Write-CWMetricAlarm")
}

_awsArgumentCompleterRegistration $CW_Completers $CW_map

$CW_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CW.$($commandName.Replace('-', ''))Cmdlet]"
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

$CW_SelectMap = @{
    "Select"=@("Remove-CWAlarm",
               "Remove-CWAnomalyDetector",
               "Remove-CWDashboard",
               "Remove-CWInsightRule",
               "Remove-CWMetricStream",
               "Get-CWAlarmHistory",
               "Get-CWAlarm",
               "Get-CWAlarmForMetric",
               "Get-CWAnomalyDetector",
               "Get-CWInsightRule",
               "Disable-CWAlarmAction",
               "Disable-CWInsightRule",
               "Enable-CWAlarmAction",
               "Enable-CWInsightRule",
               "Get-CWDashboard",
               "Get-CWInsightRuleReport",
               "Get-CWMetricData",
               "Get-CWMetricStatistic",
               "Get-CWMetricStream",
               "Get-CWMetricWidgetImage",
               "Get-CWDashboardList",
               "Get-CWManagedInsightRule",
               "Get-CWMetricList",
               "Get-CWMetricStreamList",
               "Get-CWResourceTag",
               "Write-CWAnomalyDetector",
               "Write-CWCompositeAlarm",
               "Write-CWDashboard",
               "Write-CWInsightRule",
               "Write-CWManagedInsightRule",
               "Write-CWMetricAlarm",
               "Write-CWMetricData",
               "Write-CWMetricStream",
               "Set-CWAlarmState",
               "Start-CWMetricStream",
               "Stop-CWMetricStream",
               "Add-CWResourceTag",
               "Remove-CWResourceTag")
}

_awsArgumentCompleterRegistration $CW_SelectCompleters $CW_SelectMap

