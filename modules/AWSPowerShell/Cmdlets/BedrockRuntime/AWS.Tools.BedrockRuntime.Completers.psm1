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

# Argument completions for service Amazon Bedrock Runtime


$BDRR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BedrockRuntime.AsyncInvokeStatus
        "Get-BDRRAsyncInvokeList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress"
            break
        }

        # Amazon.BedrockRuntime.GuardrailContentSource
        "Invoke-BDRRGuardrail/Source"
        {
            $v = "INPUT","OUTPUT"
            break
        }

        # Amazon.BedrockRuntime.GuardrailOutputScope
        "Invoke-BDRRGuardrail/OutputScope"
        {
            $v = "FULL","INTERVENTIONS"
            break
        }

        # Amazon.BedrockRuntime.GuardrailStreamProcessingMode
        "Invoke-BDRRConverseStream/GuardrailConfig_StreamProcessingMode"
        {
            $v = "async","sync"
            break
        }

        # Amazon.BedrockRuntime.GuardrailTrace
        {
            ($_ -eq "Invoke-BDRRConverse/GuardrailConfig_Trace") -Or
            ($_ -eq "Invoke-BDRRConverseStream/GuardrailConfig_Trace")
        }
        {
            $v = "disabled","enabled","enabled_full"
            break
        }

        # Amazon.BedrockRuntime.OutputFormatType
        {
            ($_ -eq "Invoke-BDRRConverse/OutputConfig_TextFormat_Type") -Or
            ($_ -eq "Invoke-BDRRConverseStream/OutputConfig_TextFormat_Type")
        }
        {
            $v = "json_schema"
            break
        }

        # Amazon.BedrockRuntime.PerformanceConfigLatency
        {
            ($_ -eq "Invoke-BDRRConverse/PerformanceConfig_Latency") -Or
            ($_ -eq "Invoke-BDRRConverseStream/PerformanceConfig_Latency") -Or
            ($_ -eq "Invoke-BDRRModel/PerformanceConfigLatency") -Or
            ($_ -eq "Invoke-BDRRModelWithResponseStream/PerformanceConfigLatency")
        }
        {
            $v = "optimized","standard"
            break
        }

        # Amazon.BedrockRuntime.ServiceTierType
        {
            ($_ -eq "Invoke-BDRRModel/ServiceTier") -Or
            ($_ -eq "Invoke-BDRRModelWithResponseStream/ServiceTier") -Or
            ($_ -eq "Invoke-BDRRConverse/ServiceTier_Type") -Or
            ($_ -eq "Invoke-BDRRConverseStream/ServiceTier_Type")
        }
        {
            $v = "default","flex","priority","reserved"
            break
        }

        # Amazon.BedrockRuntime.SortAsyncInvocationBy
        "Get-BDRRAsyncInvokeList/SortBy"
        {
            $v = "SubmissionTime"
            break
        }

        # Amazon.BedrockRuntime.SortOrder
        "Get-BDRRAsyncInvokeList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.BedrockRuntime.Trace
        {
            ($_ -eq "Invoke-BDRRModel/Trace") -Or
            ($_ -eq "Invoke-BDRRModelWithResponseStream/Trace")
        }
        {
            $v = "DISABLED","ENABLED","ENABLED_FULL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BDRR_map = @{
    "GuardrailConfig_StreamProcessingMode"=@("Invoke-BDRRConverseStream")
    "GuardrailConfig_Trace"=@("Invoke-BDRRConverse","Invoke-BDRRConverseStream")
    "OutputConfig_TextFormat_Type"=@("Invoke-BDRRConverse","Invoke-BDRRConverseStream")
    "OutputScope"=@("Invoke-BDRRGuardrail")
    "PerformanceConfig_Latency"=@("Invoke-BDRRConverse","Invoke-BDRRConverseStream")
    "PerformanceConfigLatency"=@("Invoke-BDRRModel","Invoke-BDRRModelWithResponseStream")
    "ServiceTier"=@("Invoke-BDRRModel","Invoke-BDRRModelWithResponseStream")
    "ServiceTier_Type"=@("Invoke-BDRRConverse","Invoke-BDRRConverseStream")
    "SortBy"=@("Get-BDRRAsyncInvokeList")
    "SortOrder"=@("Get-BDRRAsyncInvokeList")
    "Source"=@("Invoke-BDRRGuardrail")
    "StatusEqual"=@("Get-BDRRAsyncInvokeList")
    "Trace"=@("Invoke-BDRRModel","Invoke-BDRRModelWithResponseStream")
}

_awsArgumentCompleterRegistration $BDRR_Completers $BDRR_map

$BDRR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BDRR.$($commandName.Replace('-', ''))Cmdlet]"
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

$BDRR_SelectMap = @{
    "Select"=@("Invoke-BDRRGuardrail",
               "Invoke-BDRRConverse",
               "Invoke-BDRRConverseStream",
               "Get-BDRRCountToken",
               "Get-BDRRAsyncInvoke",
               "Invoke-BDRRModel",
               "Invoke-BDRRModelWithResponseStream",
               "Get-BDRRAsyncInvokeList",
               "Start-BDRRAsyncInvoke")
}

_awsArgumentCompleterRegistration $BDRR_SelectCompleters $BDRR_SelectMap

