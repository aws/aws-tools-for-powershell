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

# Argument completions for service Amazon CloudWatch Internet Monitor


$CWIM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.InternetMonitor.HealthEventStatus
        "Get-CWIMHealthEventList/EventStatus"
        {
            $v = "ACTIVE","RESOLVED"
            break
        }

        # Amazon.InternetMonitor.LocalHealthEventsConfigStatus
        {
            ($_ -eq "New-CWIMMonitor/AvailabilityLocalHealthEventsConfig_Status") -Or
            ($_ -eq "Update-CWIMMonitor/AvailabilityLocalHealthEventsConfig_Status") -Or
            ($_ -eq "New-CWIMMonitor/PerformanceLocalHealthEventsConfig_Status") -Or
            ($_ -eq "Update-CWIMMonitor/PerformanceLocalHealthEventsConfig_Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.InternetMonitor.LogDeliveryStatus
        {
            ($_ -eq "New-CWIMMonitor/S3Config_LogDeliveryStatus") -Or
            ($_ -eq "Update-CWIMMonitor/S3Config_LogDeliveryStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.InternetMonitor.MonitorConfigState
        "Update-CWIMMonitor/Status"
        {
            $v = "ACTIVE","ERROR","INACTIVE","PENDING"
            break
        }

        # Amazon.InternetMonitor.QueryType
        "Start-CWIMQuery/QueryType"
        {
            $v = "MEASUREMENTS","TOP_LOCATIONS","TOP_LOCATION_DETAILS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWIM_map = @{
    "AvailabilityLocalHealthEventsConfig_Status"=@("New-CWIMMonitor","Update-CWIMMonitor")
    "EventStatus"=@("Get-CWIMHealthEventList")
    "PerformanceLocalHealthEventsConfig_Status"=@("New-CWIMMonitor","Update-CWIMMonitor")
    "QueryType"=@("Start-CWIMQuery")
    "S3Config_LogDeliveryStatus"=@("New-CWIMMonitor","Update-CWIMMonitor")
    "Status"=@("Update-CWIMMonitor")
}

_awsArgumentCompleterRegistration $CWIM_Completers $CWIM_map

$CWIM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CWIM.$($commandName.Replace('-', ''))Cmdlet]"
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

$CWIM_SelectMap = @{
    "Select"=@("New-CWIMMonitor",
               "Remove-CWIMMonitor",
               "Get-CWIMHealthEvent",
               "Get-CWIMMonitor",
               "Get-CWIMQueryResult",
               "Get-CWIMQueryStatus",
               "Get-CWIMHealthEventList",
               "Get-CWIMMonitorList",
               "Get-CWIMResourceTag",
               "Start-CWIMQuery",
               "Stop-CWIMQuery",
               "Add-CWIMResourceTag",
               "Remove-CWIMResourceTag",
               "Update-CWIMMonitor")
}

_awsArgumentCompleterRegistration $CWIM_SelectCompleters $CWIM_SelectMap

