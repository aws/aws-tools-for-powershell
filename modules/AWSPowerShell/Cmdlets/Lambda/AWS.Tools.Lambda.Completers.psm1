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

# Argument completions for service AWS Lambda


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
            ($_ -eq "Get-LMLayerList/CompatibleRuntime") -Or
            ($_ -eq "Get-LMLayerVersionList/CompatibleRuntime") -Or
            ($_ -eq "Publish-LMFunction/Runtime") -Or
            ($_ -eq "Update-LMFunctionConfiguration/Runtime")
        }
        {
            $v = "dotnetcore1.0","dotnetcore2.0","dotnetcore2.1","go1.x","java11","java8","nodejs","nodejs10.x","nodejs12.x","nodejs4.3","nodejs4.3-edge","nodejs6.10","nodejs8.10","provided","python2.7","python3.6","python3.7","python3.8","ruby2.5"
            break
        }

        # Amazon.Lambda.TracingMode
        {
            ($_ -eq "Publish-LMFunction/TracingConfig_Mode") -Or
            ($_ -eq "Update-LMFunctionConfiguration/TracingConfig_Mode")
        }
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
    "CompatibleRuntime"=@("Get-LMLayerList","Get-LMLayerVersionList")
    "FunctionVersion"=@("Get-LMFunctionList")
    "InvocationType"=@("Invoke-LMFunction")
    "LogType"=@("Invoke-LMFunction")
    "Runtime"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "StartingPosition"=@("New-LMEventSourceMapping")
    "TracingConfig_Mode"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
}

_awsArgumentCompleterRegistration $LM_Completers $LM_map

$LM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LM.$($commandName.Replace('-', ''))Cmdlet]"
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

$LM_SelectMap = @{
    "Select"=@("Add-LMLayerVersionPermission",
               "Add-LMPermission",
               "New-LMAlias",
               "New-LMEventSourceMapping",
               "Publish-LMFunction",
               "Remove-LMAlias",
               "Remove-LMEventSourceMapping",
               "Remove-LMFunction",
               "Remove-LMFunctionConcurrency",
               "Remove-LMFunctionEventInvokeConfig",
               "Remove-LMLayerVersion",
               "Remove-LMProvisionedConcurrencyConfig",
               "Get-LMAccountSetting",
               "Get-LMAlias",
               "Get-LMEventSourceMapping",
               "Get-LMFunction",
               "Get-LMFunctionConcurrency",
               "Get-LMFunctionConfiguration",
               "Get-LMFunctionEventInvokeConfig",
               "Get-LMLayerVersion",
               "Get-LMLayerVersionByArn",
               "Get-LMLayerVersionPolicy",
               "Get-LMPolicy",
               "Get-LMProvisionedConcurrencyConfig",
               "Invoke-LMFunction",
               "Invoke-LMFunctionAsync",
               "Get-LMAliasList",
               "Get-LMEventSourceMappingList",
               "Get-LMFunctionEventInvokeConfigList",
               "Get-LMFunctionList",
               "Get-LMLayerList",
               "Get-LMLayerVersionList",
               "Get-LMProvisionedConcurrencyConfigList",
               "Get-LMResourceTag",
               "Get-LMVersionsByFunction",
               "Publish-LMLayerVersion",
               "Publish-LMVersion",
               "Write-LMFunctionConcurrency",
               "Write-LMFunctionEventInvokeConfig",
               "Write-LMProvisionedConcurrencyConfig",
               "Remove-LMLayerVersionPermission",
               "Remove-LMPermission",
               "Add-LMResourceTag",
               "Remove-LMResourceTag",
               "Update-LMAlias",
               "Update-LMEventSourceMapping",
               "Update-LMFunctionCode",
               "Update-LMFunctionConfiguration",
               "Update-LMFunctionEventInvokeConfig")
}

_awsArgumentCompleterRegistration $LM_SelectCompleters $LM_SelectMap

