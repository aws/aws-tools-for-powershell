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

# Argument completions for service Amazon EventBridgeV2


$EVBV2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EventBridgeV2.DeduplicationType
        {
            ($_ -eq "Write-EVBV2Event/DeduplicationConfiguration_DeduplicationType") -Or
            ($_ -eq "Write-EVBV2RawEvent/DeduplicationConfiguration_DeduplicationType") -Or
            ($_ -eq "New-EVBV2Subscriber/InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType") -Or
            ($_ -eq "Update-EVBV2Subscriber/InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType")
        }
        {
            $v = "CONTENT_BASED"
            break
        }

        # Amazon.EventBridgeV2.FilterLanguage
        {
            ($_ -eq "New-EVBV2Subscriber/FilterConfiguration_Language") -Or
            ($_ -eq "Update-EVBV2Subscriber/FilterConfiguration_Language")
        }
        {
            $v = "EVENT_BRIDGE_PATTERN"
            break
        }

        # Amazon.EventBridgeV2.IncludePayload
        {
            ($_ -eq "New-EVBV2Subscriber/LogConfiguration_IncludePayload") -Or
            ($_ -eq "Update-EVBV2Subscriber/LogConfiguration_IncludePayload")
        }
        {
            $v = "FULL","ON_ERROR_ONLY"
            break
        }

        # Amazon.EventBridgeV2.InvocationType
        {
            ($_ -eq "New-EVBV2Subscriber/InvokeConfiguration_LambdaParameters_InvocationType") -Or
            ($_ -eq "Update-EVBV2Subscriber/InvokeConfiguration_LambdaParameters_InvocationType") -Or
            ($_ -eq "New-EVBV2Subscriber/InvokeConfiguration_StepFunctionsParameters_InvocationType") -Or
            ($_ -eq "Update-EVBV2Subscriber/InvokeConfiguration_StepFunctionsParameters_InvocationType")
        }
        {
            $v = "EVENT","REQUEST_RESPONSE"
            break
        }

        # Amazon.EventBridgeV2.LogLevel
        {
            ($_ -eq "New-EVBV2Subscriber/LogConfiguration_Level") -Or
            ($_ -eq "Update-EVBV2Subscriber/LogConfiguration_Level")
        }
        {
            $v = "ERROR","INFO","OFF"
            break
        }

        # Amazon.EventBridgeV2.OrderingType
        "New-EVBV2Subscriber/Type"
        {
            $v = "FIFO","UNORDERED"
            break
        }

        # Amazon.EventBridgeV2.PointType
        "New-EVBV2Subscriber/PointInTimeConfiguration_PointType"
        {
            $v = "HORIZON","TIMESTAMP"
            break
        }

        # Amazon.EventBridgeV2.ResumePosition
        "Update-EVBV2Subscriber/ResumePosition"
        {
            $v = "LAST_PROCESSED","LATEST"
            break
        }

        # Amazon.EventBridgeV2.RetryStrategy
        {
            ($_ -eq "New-EVBV2Subscriber/RetryPolicy_RetryStrategy") -Or
            ($_ -eq "Update-EVBV2Subscriber/RetryPolicy_RetryStrategy")
        }
        {
            $v = "ALL"
            break
        }

        # Amazon.EventBridgeV2.StartingPosition
        "New-EVBV2Subscriber/StartingPosition"
        {
            $v = "LATEST","POINT_IN_TIME"
            break
        }

        # Amazon.EventBridgeV2.SubscriberState
        {
            ($_ -eq "New-EVBV2Subscriber/State") -Or
            ($_ -eq "Update-EVBV2Subscriber/State")
        }
        {
            $v = "RUNNING","STOPPED"
            break
        }

        # Amazon.EventBridgeV2.TransformerType
        {
            ($_ -eq "New-EVBV2Subscriber/Transformer_Type") -Or
            ($_ -eq "Update-EVBV2Subscriber/Transformer_Type")
        }
        {
            $v = "JSONATA","RAW","WITH_METADATA"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EVBV2_map = @{
    "DeduplicationConfiguration_DeduplicationType"=@("Write-EVBV2Event","Write-EVBV2RawEvent")
    "FilterConfiguration_Language"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "InvokeConfiguration_LambdaParameters_InvocationType"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "InvokeConfiguration_StepFunctionsParameters_InvocationType"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "LogConfiguration_IncludePayload"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "LogConfiguration_Level"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "PointInTimeConfiguration_PointType"=@("New-EVBV2Subscriber")
    "ResumePosition"=@("Update-EVBV2Subscriber")
    "RetryPolicy_RetryStrategy"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "StartingPosition"=@("New-EVBV2Subscriber")
    "State"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "Transformer_Type"=@("New-EVBV2Subscriber","Update-EVBV2Subscriber")
    "Type"=@("New-EVBV2Subscriber")
}

_awsArgumentCompleterRegistration $EVBV2_Completers $EVBV2_map

$EVBV2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EVBV2.$($commandName.Replace('-', ''))Cmdlet]"
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

$EVBV2_SelectMap = @{
    "Select"=@("New-EVBV2EventBus",
               "New-EVBV2EventSource",
               "New-EVBV2Subscriber",
               "Remove-EVBV2EventBus",
               "Remove-EVBV2EventSource",
               "Remove-EVBV2ResourcePolicy",
               "Remove-EVBV2Subscriber",
               "Get-EVBV2EventBusDetail",
               "Get-EVBV2EventSourceDetail",
               "Get-EVBV2SubscriberDetail",
               "Get-EVBV2ResourcePolicy",
               "Get-EVBV2EventBusList",
               "Get-EVBV2EventSourceList",
               "Get-EVBV2ResourcePolicyList",
               "Get-EVBV2SubscriberList",
               "Get-EVBV2ResourceTag",
               "Write-EVBV2Event",
               "Write-EVBV2RawEvent",
               "Write-EVBV2ResourcePolicy",
               "Revoke-EVBV2Resource",
               "Add-EVBV2ResourceTag",
               "Remove-EVBV2ResourceTag",
               "Update-EVBV2EventBus",
               "Update-EVBV2EventSource",
               "Update-EVBV2Subscriber")
}

_awsArgumentCompleterRegistration $EVBV2_SelectCompleters $EVBV2_SelectMap

