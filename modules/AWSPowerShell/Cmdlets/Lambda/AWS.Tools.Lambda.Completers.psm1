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
        # Amazon.Lambda.ApplicationLogLevel
        {
            ($_ -eq "Publish-LMFunction/LoggingConfig_ApplicationLogLevel") -Or
            ($_ -eq "Update-LMFunctionConfiguration/LoggingConfig_ApplicationLogLevel")
        }
        {
            $v = "DEBUG","ERROR","FATAL","INFO","TRACE","WARN"
            break
        }

        # Amazon.Lambda.Architecture
        {
            ($_ -eq "Get-LMLayerList/CompatibleArchitecture") -Or
            ($_ -eq "Get-LMLayerVersionList/CompatibleArchitecture")
        }
        {
            $v = "arm64","x86_64"
            break
        }

        # Amazon.Lambda.CodeSigningPolicy
        {
            ($_ -eq "New-LMCodeSigningConfig/CodeSigningPolicies_UntrustedArtifactOnDeployment") -Or
            ($_ -eq "Update-LMCodeSigningConfig/CodeSigningPolicies_UntrustedArtifactOnDeployment")
        }
        {
            $v = "Enforce","Warn"
            break
        }

        # Amazon.Lambda.EventSourcePosition
        "New-LMEventSourceMapping/StartingPosition"
        {
            $v = "AT_TIMESTAMP","LATEST","TRIM_HORIZON"
            break
        }

        # Amazon.Lambda.FullDocument
        {
            ($_ -eq "New-LMEventSourceMapping/DocumentDBEventSourceConfig_FullDocument") -Or
            ($_ -eq "Update-LMEventSourceMapping/DocumentDBEventSourceConfig_FullDocument")
        }
        {
            $v = "Default","UpdateLookup"
            break
        }

        # Amazon.Lambda.FunctionUrlAuthType
        {
            ($_ -eq "New-LMFunctionUrlConfig/AuthType") -Or
            ($_ -eq "Update-LMFunctionUrlConfig/AuthType") -Or
            ($_ -eq "Add-LMPermission/FunctionUrlAuthType")
        }
        {
            $v = "AWS_IAM","NONE"
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

        # Amazon.Lambda.InvokeMode
        {
            ($_ -eq "New-LMFunctionUrlConfig/InvokeMode") -Or
            ($_ -eq "Update-LMFunctionUrlConfig/InvokeMode")
        }
        {
            $v = "BUFFERED","RESPONSE_STREAM"
            break
        }

        # Amazon.Lambda.LogFormat
        {
            ($_ -eq "Publish-LMFunction/LoggingConfig_LogFormat") -Or
            ($_ -eq "Update-LMFunctionConfiguration/LoggingConfig_LogFormat")
        }
        {
            $v = "JSON","Text"
            break
        }

        # Amazon.Lambda.LogType
        {
            ($_ -eq "Invoke-LMFunction/LogType") -Or
            ($_ -eq "Invoke-LMWithResponseStream/LogType")
        }
        {
            $v = "None","Tail"
            break
        }

        # Amazon.Lambda.PackageType
        "Publish-LMFunction/PackageType"
        {
            $v = "Image","Zip"
            break
        }

        # Amazon.Lambda.RecursiveLoop
        "Write-LMFunctionRecursionConfig/RecursiveLoop"
        {
            $v = "Allow","Terminate"
            break
        }

        # Amazon.Lambda.ResponseStreamingInvocationType
        "Invoke-LMWithResponseStream/InvocationType"
        {
            $v = "DryRun","RequestResponse"
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
            $v = "dotnet6","dotnet8","dotnetcore1.0","dotnetcore2.0","dotnetcore2.1","dotnetcore3.1","go1.x","java11","java17","java21","java8","java8.al2","nodejs","nodejs10.x","nodejs12.x","nodejs14.x","nodejs16.x","nodejs18.x","nodejs20.x","nodejs22.x","nodejs4.3","nodejs4.3-edge","nodejs6.10","nodejs8.10","provided","provided.al2","provided.al2023","python2.7","python3.10","python3.11","python3.12","python3.13","python3.6","python3.7","python3.8","python3.9","ruby2.5","ruby2.7","ruby3.2","ruby3.3","ruby3.4"
            break
        }

        # Amazon.Lambda.SchemaRegistryEventRecordFormat
        {
            ($_ -eq "New-LMEventSourceMapping/AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat") -Or
            ($_ -eq "Update-LMEventSourceMapping/AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat") -Or
            ($_ -eq "New-LMEventSourceMapping/SchemaRegistryConfig_EventRecordFormat") -Or
            ($_ -eq "Update-LMEventSourceMapping/SchemaRegistryConfig_EventRecordFormat")
        }
        {
            $v = "JSON","SOURCE"
            break
        }

        # Amazon.Lambda.SnapStartApplyOn
        {
            ($_ -eq "Publish-LMFunction/SnapStart_ApplyOn") -Or
            ($_ -eq "Update-LMFunctionConfiguration/SnapStart_ApplyOn")
        }
        {
            $v = "None","PublishedVersions"
            break
        }

        # Amazon.Lambda.SystemLogLevel
        {
            ($_ -eq "Publish-LMFunction/LoggingConfig_SystemLogLevel") -Or
            ($_ -eq "Update-LMFunctionConfiguration/LoggingConfig_SystemLogLevel")
        }
        {
            $v = "DEBUG","INFO","WARN"
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

        # Amazon.Lambda.UpdateRuntimeOn
        "Write-LMRuntimeManagementConfig/UpdateRuntimeOn"
        {
            $v = "Auto","FunctionUpdate","Manual"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LM_map = @{
    "AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat"=@("New-LMEventSourceMapping","Update-LMEventSourceMapping")
    "AuthType"=@("New-LMFunctionUrlConfig","Update-LMFunctionUrlConfig")
    "CodeSigningPolicies_UntrustedArtifactOnDeployment"=@("New-LMCodeSigningConfig","Update-LMCodeSigningConfig")
    "CompatibleArchitecture"=@("Get-LMLayerList","Get-LMLayerVersionList")
    "CompatibleRuntime"=@("Get-LMLayerList","Get-LMLayerVersionList")
    "DocumentDBEventSourceConfig_FullDocument"=@("New-LMEventSourceMapping","Update-LMEventSourceMapping")
    "FunctionUrlAuthType"=@("Add-LMPermission")
    "FunctionVersion"=@("Get-LMFunctionList")
    "InvocationType"=@("Invoke-LMFunction","Invoke-LMWithResponseStream")
    "InvokeMode"=@("New-LMFunctionUrlConfig","Update-LMFunctionUrlConfig")
    "LoggingConfig_ApplicationLogLevel"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "LoggingConfig_LogFormat"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "LoggingConfig_SystemLogLevel"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "LogType"=@("Invoke-LMFunction","Invoke-LMWithResponseStream")
    "PackageType"=@("Publish-LMFunction")
    "RecursiveLoop"=@("Write-LMFunctionRecursionConfig")
    "Runtime"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "SchemaRegistryConfig_EventRecordFormat"=@("New-LMEventSourceMapping","Update-LMEventSourceMapping")
    "SnapStart_ApplyOn"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "StartingPosition"=@("New-LMEventSourceMapping")
    "TracingConfig_Mode"=@("Publish-LMFunction","Update-LMFunctionConfiguration")
    "UpdateRuntimeOn"=@("Write-LMRuntimeManagementConfig")
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
               "New-LMCodeSigningConfig",
               "New-LMEventSourceMapping",
               "Publish-LMFunction",
               "New-LMFunctionUrlConfig",
               "Remove-LMAlias",
               "Remove-LMCodeSigningConfig",
               "Remove-LMEventSourceMapping",
               "Remove-LMFunction",
               "Remove-LMFunctionCodeSigningConfig",
               "Remove-LMFunctionConcurrency",
               "Remove-LMFunctionEventInvokeConfig",
               "Remove-LMFunctionUrlConfig",
               "Remove-LMLayerVersion",
               "Remove-LMProvisionedConcurrencyConfig",
               "Get-LMAccountSetting",
               "Get-LMAlias",
               "Get-LMCodeSigningConfig",
               "Get-LMEventSourceMapping",
               "Get-LMFunction",
               "Get-LMFunctionCodeSigningConfig",
               "Get-LMFunctionConcurrency",
               "Get-LMFunctionConfiguration",
               "Get-LMFunctionEventInvokeConfig",
               "Get-LMFunctionRecursionConfig",
               "Get-LMFunctionUrlConfig",
               "Get-LMLayerVersion",
               "Get-LMLayerVersionByArn",
               "Get-LMLayerVersionPolicy",
               "Get-LMPolicy",
               "Get-LMProvisionedConcurrencyConfig",
               "Get-LMRuntimeManagementConfig",
               "Invoke-LMFunction",
               "Invoke-LMWithResponseStream",
               "Get-LMAliasList",
               "Get-LMCodeSigningConfigList",
               "Get-LMEventSourceMappingList",
               "Get-LMFunctionEventInvokeConfigList",
               "Get-LMFunctionList",
               "Get-LMFunctionsByCodeSigningConfigList",
               "Get-LMFunctionUrlConfigList",
               "Get-LMLayerList",
               "Get-LMLayerVersionList",
               "Get-LMProvisionedConcurrencyConfigList",
               "Get-LMResourceTag",
               "Get-LMVersionsByFunction",
               "Publish-LMLayerVersion",
               "Publish-LMVersion",
               "Write-LMFunctionCodeSigningConfig",
               "Write-LMFunctionConcurrency",
               "Write-LMFunctionEventInvokeConfig",
               "Write-LMFunctionRecursionConfig",
               "Write-LMProvisionedConcurrencyConfig",
               "Write-LMRuntimeManagementConfig",
               "Remove-LMLayerVersionPermission",
               "Remove-LMPermission",
               "Add-LMResourceTag",
               "Remove-LMResourceTag",
               "Update-LMAlias",
               "Update-LMCodeSigningConfig",
               "Update-LMEventSourceMapping",
               "Update-LMFunctionCode",
               "Update-LMFunctionConfiguration",
               "Update-LMFunctionEventInvokeConfig",
               "Update-LMFunctionUrlConfig")
}

_awsArgumentCompleterRegistration $LM_SelectCompleters $LM_SelectMap

