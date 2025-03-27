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

# Argument completions for service Amazon CloudWatch Application Signals


$CWAS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ApplicationSignals.DurationUnit
        {
            ($_ -eq "New-CWASServiceLevelObjective/CalendarInterval_DurationUnit") -Or
            ($_ -eq "Update-CWASServiceLevelObjective/CalendarInterval_DurationUnit") -Or
            ($_ -eq "New-CWASServiceLevelObjective/RollingInterval_DurationUnit") -Or
            ($_ -eq "Update-CWASServiceLevelObjective/RollingInterval_DurationUnit")
        }
        {
            $v = "DAY","HOUR","MINUTE","MONTH"
            break
        }

        # Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator
        {
            ($_ -eq "New-CWASServiceLevelObjective/RequestBasedSliConfig_ComparisonOperator") -Or
            ($_ -eq "Update-CWASServiceLevelObjective/RequestBasedSliConfig_ComparisonOperator") -Or
            ($_ -eq "New-CWASServiceLevelObjective/SliConfig_ComparisonOperator") -Or
            ($_ -eq "Update-CWASServiceLevelObjective/SliConfig_ComparisonOperator")
        }
        {
            $v = "GreaterThan","GreaterThanOrEqualTo","LessThan","LessThanOrEqualTo"
            break
        }

        # Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType
        {
            ($_ -eq "New-CWASServiceLevelObjective/RequestBasedSliMetricConfig_MetricType") -Or
            ($_ -eq "Update-CWASServiceLevelObjective/RequestBasedSliMetricConfig_MetricType") -Or
            ($_ -eq "New-CWASServiceLevelObjective/SliMetricConfig_MetricType") -Or
            ($_ -eq "Update-CWASServiceLevelObjective/SliMetricConfig_MetricType")
        }
        {
            $v = "AVAILABILITY","LATENCY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWAS_map = @{
    "CalendarInterval_DurationUnit"=@("New-CWASServiceLevelObjective","Update-CWASServiceLevelObjective")
    "RequestBasedSliConfig_ComparisonOperator"=@("New-CWASServiceLevelObjective","Update-CWASServiceLevelObjective")
    "RequestBasedSliMetricConfig_MetricType"=@("New-CWASServiceLevelObjective","Update-CWASServiceLevelObjective")
    "RollingInterval_DurationUnit"=@("New-CWASServiceLevelObjective","Update-CWASServiceLevelObjective")
    "SliConfig_ComparisonOperator"=@("New-CWASServiceLevelObjective","Update-CWASServiceLevelObjective")
    "SliMetricConfig_MetricType"=@("New-CWASServiceLevelObjective","Update-CWASServiceLevelObjective")
}

_awsArgumentCompleterRegistration $CWAS_Completers $CWAS_map

$CWAS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CWAS.$($commandName.Replace('-', ''))Cmdlet]"
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

$CWAS_SelectMap = @{
    "Select"=@("Get-CWASBatchServiceLevelObjectiveBudgetReport",
               "Update-CWASUpdateExclusionWindow",
               "New-CWASServiceLevelObjective",
               "Remove-CWASServiceLevelObjective",
               "Get-CWASService",
               "Get-CWASServiceLevelObjective",
               "Get-CWASServiceDependencyList",
               "Get-CWASServiceDependentList",
               "Get-CWASServiceLevelObjectiveExclusionWindowList",
               "Get-CWASServiceLevelObjectiveList",
               "Get-CWASServiceOperationList",
               "Get-CWASServiceList",
               "Get-CWASResourceTag",
               "Start-CWASDiscovery",
               "Add-CWASResourceTag",
               "Remove-CWASResourceTag",
               "Update-CWASServiceLevelObjective")
}

_awsArgumentCompleterRegistration $CWAS_SelectCompleters $CWAS_SelectMap

