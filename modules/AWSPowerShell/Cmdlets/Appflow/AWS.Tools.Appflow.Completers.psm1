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

# Argument completions for service Amazon Appflow


$AF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Appflow.ConnectionMode
        {
            ($_ -eq "New-AFConnectorProfile/ConnectionMode") -Or
            ($_ -eq "Update-AFConnectorProfile/ConnectionMode")
        }
        {
            $v = "Private","Public"
            break
        }

        # Amazon.Appflow.ConnectorProvisioningType
        "Register-AFConnector/ConnectorProvisioningType"
        {
            $v = "LAMBDA"
            break
        }

        # Amazon.Appflow.ConnectorType
        {
            ($_ -eq "Get-AFConnector/ConnectorType") -Or
            ($_ -eq "Get-AFConnectorEntity/ConnectorType") -Or
            ($_ -eq "Get-AFConnectorEntityList/ConnectorType") -Or
            ($_ -eq "Get-AFConnectorProfile/ConnectorType") -Or
            ($_ -eq "New-AFConnectorProfile/ConnectorType") -Or
            ($_ -eq "Reset-AFConnectorMetadataCache/ConnectorType") -Or
            ($_ -eq "New-AFFlow/SourceFlowConfig_ConnectorType") -Or
            ($_ -eq "Update-AFFlow/SourceFlowConfig_ConnectorType")
        }
        {
            $v = "Amplitude","CustomConnector","CustomerProfiles","Datadog","Dynatrace","EventBridge","Googleanalytics","Honeycode","Infornexus","LookoutMetrics","Marketo","Pardot","Redshift","S3","Salesforce","SAPOData","Servicenow","Singular","Slack","Snowflake","Trendmicro","Upsolver","Veeva","Zendesk"
            break
        }

        # Amazon.Appflow.DataPullMode
        {
            ($_ -eq "New-AFFlow/Scheduled_DataPullMode") -Or
            ($_ -eq "Update-AFFlow/Scheduled_DataPullMode")
        }
        {
            $v = "Complete","Incremental"
            break
        }

        # Amazon.Appflow.DataTransferApiType
        {
            ($_ -eq "New-AFFlow/DataTransferApi_Type") -Or
            ($_ -eq "Update-AFFlow/DataTransferApi_Type")
        }
        {
            $v = "ASYNC","AUTOMATIC","SYNC"
            break
        }

        # Amazon.Appflow.S3InputFileType
        {
            ($_ -eq "New-AFFlow/S3InputFormatConfig_S3InputFileType") -Or
            ($_ -eq "Update-AFFlow/S3InputFormatConfig_S3InputFileType")
        }
        {
            $v = "CSV","JSON"
            break
        }

        # Amazon.Appflow.SalesforceDataTransferApi
        {
            ($_ -eq "New-AFFlow/Salesforce_DataTransferApi") -Or
            ($_ -eq "Update-AFFlow/Salesforce_DataTransferApi")
        }
        {
            $v = "AUTOMATIC","BULKV2","REST_SYNC"
            break
        }

        # Amazon.Appflow.TriggerType
        {
            ($_ -eq "New-AFFlow/TriggerConfig_TriggerType") -Or
            ($_ -eq "Update-AFFlow/TriggerConfig_TriggerType")
        }
        {
            $v = "Event","OnDemand","Scheduled"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AF_map = @{
    "ConnectionMode"=@("New-AFConnectorProfile","Update-AFConnectorProfile")
    "ConnectorProvisioningType"=@("Register-AFConnector")
    "ConnectorType"=@("Get-AFConnector","Get-AFConnectorEntity","Get-AFConnectorEntityList","Get-AFConnectorProfile","New-AFConnectorProfile","Reset-AFConnectorMetadataCache")
    "DataTransferApi_Type"=@("New-AFFlow","Update-AFFlow")
    "S3InputFormatConfig_S3InputFileType"=@("New-AFFlow","Update-AFFlow")
    "Salesforce_DataTransferApi"=@("New-AFFlow","Update-AFFlow")
    "Scheduled_DataPullMode"=@("New-AFFlow","Update-AFFlow")
    "SourceFlowConfig_ConnectorType"=@("New-AFFlow","Update-AFFlow")
    "TriggerConfig_TriggerType"=@("New-AFFlow","Update-AFFlow")
}

_awsArgumentCompleterRegistration $AF_Completers $AF_map

$AF_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AF.$($commandName.Replace('-', ''))Cmdlet]"
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

$AF_SelectMap = @{
    "Select"=@("Stop-AFFlowExecution",
               "New-AFConnectorProfile",
               "New-AFFlow",
               "Remove-AFConnectorProfile",
               "Remove-AFFlow",
               "Get-AFConnector",
               "Get-AFConnectorEntity",
               "Get-AFConnectorProfile",
               "Get-AFConnectorConfigurationList",
               "Get-AFFlow",
               "Get-AFFlowExecutionRecord",
               "Get-AFConnectorEntityList",
               "Get-AFConnectorList",
               "Get-AFFlowList",
               "Get-AFResourceTag",
               "Register-AFConnector",
               "Reset-AFConnectorMetadataCache",
               "Start-AFFlow",
               "Stop-AFFlow",
               "Add-AFResourceTag",
               "Unregister-AFConnector",
               "Remove-AFResourceTag",
               "Update-AFConnectorProfile",
               "Update-AFConnectorRegistration",
               "Update-AFFlow")
}

_awsArgumentCompleterRegistration $AF_SelectCompleters $AF_SelectMap

