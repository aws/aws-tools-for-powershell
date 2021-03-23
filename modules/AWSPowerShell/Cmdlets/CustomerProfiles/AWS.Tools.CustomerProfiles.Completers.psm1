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

# Argument completions for service Amazon Connect Customer Profiles


$CPF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CustomerProfiles.DataPullMode
        "Write-CPFIntegration/FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode"
        {
            $v = "Complete","Incremental"
            break
        }

        # Amazon.CustomerProfiles.Gender
        {
            ($_ -eq "New-CPFProfile/Gender") -Or
            ($_ -eq "Update-CPFProfile/Gender")
        }
        {
            $v = "FEMALE","MALE","UNSPECIFIED"
            break
        }

        # Amazon.CustomerProfiles.PartyType
        {
            ($_ -eq "New-CPFProfile/PartyType") -Or
            ($_ -eq "Update-CPFProfile/PartyType")
        }
        {
            $v = "BUSINESS","INDIVIDUAL","OTHER"
            break
        }

        # Amazon.CustomerProfiles.SourceConnectorType
        "Write-CPFIntegration/FlowDefinition_SourceFlowConfig_ConnectorType"
        {
            $v = "Marketo","S3","Salesforce","Servicenow","Zendesk"
            break
        }

        # Amazon.CustomerProfiles.TriggerType
        "Write-CPFIntegration/FlowDefinition_TriggerConfig_TriggerType"
        {
            $v = "Event","OnDemand","Scheduled"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CPF_map = @{
    "FlowDefinition_SourceFlowConfig_ConnectorType"=@("Write-CPFIntegration")
    "FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode"=@("Write-CPFIntegration")
    "FlowDefinition_TriggerConfig_TriggerType"=@("Write-CPFIntegration")
    "Gender"=@("New-CPFProfile","Update-CPFProfile")
    "PartyType"=@("New-CPFProfile","Update-CPFProfile")
}

_awsArgumentCompleterRegistration $CPF_Completers $CPF_map

$CPF_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CPF.$($commandName.Replace('-', ''))Cmdlet]"
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

$CPF_SelectMap = @{
    "Select"=@("Add-CPFProfileKey",
               "New-CPFDomain",
               "New-CPFProfile",
               "Remove-CPFDomain",
               "Remove-CPFIntegration",
               "Remove-CPFProfile",
               "Remove-CPFProfileKey",
               "Remove-CPFProfileObject",
               "Remove-CPFProfileObjectType",
               "Get-CPFDomain",
               "Get-CPFIntegration",
               "Get-CPFProfileObjectType",
               "Get-CPFProfileObjectTypeTemplate",
               "Get-CPFAccountIntegrationList",
               "Get-CPFDomainList",
               "Get-CPFIntegrationList",
               "Get-CPFProfileObjectList",
               "Get-CPFProfileObjectTypeList",
               "Get-CPFProfileObjectTypeTemplateList",
               "Get-CPFResourceTag",
               "Write-CPFIntegration",
               "Write-CPFProfileObject",
               "Write-CPFProfileObjectType",
               "Search-CPFProfile",
               "Add-CPFResourceTag",
               "Remove-CPFResourceTag",
               "Update-CPFDomain",
               "Update-CPFProfile")
}

_awsArgumentCompleterRegistration $CPF_SelectCompleters $CPF_SelectMap

