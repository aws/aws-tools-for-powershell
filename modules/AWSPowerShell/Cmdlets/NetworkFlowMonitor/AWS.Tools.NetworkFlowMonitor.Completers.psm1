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

# Argument completions for service Network Flow Monitor


$NFM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.NetworkFlowMonitor.DestinationCategory
        {
            ($_ -eq "Start-NFMQueryMonitorTopContributor/DestinationCategory") -Or
            ($_ -eq "Start-NFMQueryWorkloadInsightsTopContributor/DestinationCategory") -Or
            ($_ -eq "Start-NFMQueryWorkloadInsightsTopContributorsData/DestinationCategory")
        }
        {
            $v = "AMAZON_DYNAMODB","AMAZON_S3","INTER_AZ","INTER_VPC","INTRA_AZ","UNCLASSIFIED"
            break
        }

        # Amazon.NetworkFlowMonitor.MonitorMetric
        "Start-NFMQueryMonitorTopContributor/MetricName"
        {
            $v = "DATA_TRANSFERRED","RETRANSMISSIONS","ROUND_TRIP_TIME","TIMEOUTS"
            break
        }

        # Amazon.NetworkFlowMonitor.MonitorStatus
        "Get-NFMMonitorList/MonitorStatus"
        {
            $v = "ACTIVE","DELETING","ERROR","INACTIVE","PENDING"
            break
        }

        # Amazon.NetworkFlowMonitor.WorkloadInsightsMetric
        {
            ($_ -eq "Start-NFMQueryWorkloadInsightsTopContributor/MetricName") -Or
            ($_ -eq "Start-NFMQueryWorkloadInsightsTopContributorsData/MetricName")
        }
        {
            $v = "DATA_TRANSFERRED","RETRANSMISSIONS","TIMEOUTS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NFM_map = @{
    "DestinationCategory"=@("Start-NFMQueryMonitorTopContributor","Start-NFMQueryWorkloadInsightsTopContributor","Start-NFMQueryWorkloadInsightsTopContributorsData")
    "MetricName"=@("Start-NFMQueryMonitorTopContributor","Start-NFMQueryWorkloadInsightsTopContributor","Start-NFMQueryWorkloadInsightsTopContributorsData")
    "MonitorStatus"=@("Get-NFMMonitorList")
}

_awsArgumentCompleterRegistration $NFM_Completers $NFM_map

$NFM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NFM.$($commandName.Replace('-', ''))Cmdlet]"
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

$NFM_SelectMap = @{
    "Select"=@("New-NFMMonitor",
               "New-NFMScope",
               "Remove-NFMMonitor",
               "Remove-NFMScope",
               "Get-NFMMonitor",
               "Get-NFMQueryResultsMonitorTopContributor",
               "Get-NFMQueryResultsWorkloadInsightsTopContributor",
               "Get-NFMQueryResultsWorkloadInsightsTopContributorsData",
               "Get-NFMQueryStatusMonitorTopContributor",
               "Get-NFMQueryStatusWorkloadInsightsTopContributor",
               "Get-NFMQueryStatusWorkloadInsightsTopContributorsData",
               "Get-NFMScope",
               "Get-NFMMonitorList",
               "Get-NFMScopeList",
               "Get-NFMResourceTag",
               "Start-NFMQueryMonitorTopContributor",
               "Start-NFMQueryWorkloadInsightsTopContributor",
               "Start-NFMQueryWorkloadInsightsTopContributorsData",
               "Stop-NFMQueryMonitorTopContributor",
               "Stop-NFMQueryWorkloadInsightsTopContributor",
               "Stop-NFMQueryWorkloadInsightsTopContributorsData",
               "Add-NFMResourceTag",
               "Remove-NFMResourceTag",
               "Update-NFMMonitor",
               "Update-NFMScope")
}

_awsArgumentCompleterRegistration $NFM_SelectCompleters $NFM_SelectMap

