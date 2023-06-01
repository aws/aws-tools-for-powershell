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
        # Amazon.CustomerProfiles.ConflictResolvingModel
        {
            ($_ -eq "Get-CPFAutoMergingPreview/ConflictResolution_ConflictResolvingModel") -Or
            ($_ -eq "New-CPFDomain/Matching_AutoMerging_ConflictResolution_ConflictResolvingModel") -Or
            ($_ -eq "Update-CPFDomain/Matching_AutoMerging_ConflictResolution_ConflictResolvingModel")
        }
        {
            $v = "RECENCY","SOURCE"
            break
        }

        # Amazon.CustomerProfiles.DataPullMode
        {
            ($_ -eq "Write-CPFIntegration/FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode") -Or
            ($_ -eq "New-CPFIntegrationWorkflow/IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode")
        }
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

        # Amazon.CustomerProfiles.JobScheduleDayOfTheWeek
        {
            ($_ -eq "New-CPFDomain/Matching_JobSchedule_DayOfTheWeek") -Or
            ($_ -eq "Update-CPFDomain/Matching_JobSchedule_DayOfTheWeek")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.CustomerProfiles.LogicalOperator
        "Search-CPFProfile/LogicalOperator"
        {
            $v = "AND","OR"
            break
        }

        # Amazon.CustomerProfiles.Operator
        {
            ($_ -eq "New-CPFCalculatedAttributeDefinition/Conditions_Threshold_Operator") -Or
            ($_ -eq "Update-CPFCalculatedAttributeDefinition/Conditions_Threshold_Operator")
        }
        {
            $v = "EQUAL_TO","GREATER_THAN","LESS_THAN","NOT_EQUAL_TO"
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
        {
            ($_ -eq "Write-CPFIntegration/FlowDefinition_SourceFlowConfig_ConnectorType") -Or
            ($_ -eq "New-CPFIntegrationWorkflow/IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_ConnectorType")
        }
        {
            $v = "Marketo","S3","Salesforce","Servicenow","Zendesk"
            break
        }

        # Amazon.CustomerProfiles.Statistic
        "New-CPFCalculatedAttributeDefinition/Statistic"
        {
            $v = "AVERAGE","COUNT","FIRST_OCCURRENCE","LAST_OCCURRENCE","MAXIMUM","MAX_OCCURRENCE","MINIMUM","SUM"
            break
        }

        # Amazon.CustomerProfiles.Status
        "Get-CPFWorkflowList/Status"
        {
            $v = "CANCELLED","COMPLETE","FAILED","IN_PROGRESS","NOT_STARTED","RETRY","SPLIT"
            break
        }

        # Amazon.CustomerProfiles.TriggerType
        {
            ($_ -eq "Write-CPFIntegration/FlowDefinition_TriggerConfig_TriggerType") -Or
            ($_ -eq "New-CPFIntegrationWorkflow/IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerType")
        }
        {
            $v = "Event","OnDemand","Scheduled"
            break
        }

        # Amazon.CustomerProfiles.Unit
        {
            ($_ -eq "New-CPFCalculatedAttributeDefinition/Conditions_Range_Unit") -Or
            ($_ -eq "Update-CPFCalculatedAttributeDefinition/Conditions_Range_Unit")
        }
        {
            $v = "DAYS"
            break
        }

        # Amazon.CustomerProfiles.WorkflowType
        {
            ($_ -eq "Get-CPFWorkflowList/WorkflowType") -Or
            ($_ -eq "New-CPFIntegrationWorkflow/WorkflowType")
        }
        {
            $v = "APPFLOW_INTEGRATION"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CPF_map = @{
    "Conditions_Range_Unit"=@("New-CPFCalculatedAttributeDefinition","Update-CPFCalculatedAttributeDefinition")
    "Conditions_Threshold_Operator"=@("New-CPFCalculatedAttributeDefinition","Update-CPFCalculatedAttributeDefinition")
    "ConflictResolution_ConflictResolvingModel"=@("Get-CPFAutoMergingPreview")
    "FlowDefinition_SourceFlowConfig_ConnectorType"=@("Write-CPFIntegration")
    "FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode"=@("Write-CPFIntegration")
    "FlowDefinition_TriggerConfig_TriggerType"=@("Write-CPFIntegration")
    "Gender"=@("New-CPFProfile","Update-CPFProfile")
    "IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_ConnectorType"=@("New-CPFIntegrationWorkflow")
    "IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode"=@("New-CPFIntegrationWorkflow")
    "IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerType"=@("New-CPFIntegrationWorkflow")
    "LogicalOperator"=@("Search-CPFProfile")
    "Matching_AutoMerging_ConflictResolution_ConflictResolvingModel"=@("New-CPFDomain","Update-CPFDomain")
    "Matching_JobSchedule_DayOfTheWeek"=@("New-CPFDomain","Update-CPFDomain")
    "PartyType"=@("New-CPFProfile","Update-CPFProfile")
    "Statistic"=@("New-CPFCalculatedAttributeDefinition")
    "Status"=@("Get-CPFWorkflowList")
    "WorkflowType"=@("Get-CPFWorkflowList","New-CPFIntegrationWorkflow")
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
               "New-CPFCalculatedAttributeDefinition",
               "New-CPFDomain",
               "New-CPFIntegrationWorkflow",
               "New-CPFProfile",
               "Remove-CPFCalculatedAttributeDefinition",
               "Remove-CPFDomain",
               "Remove-CPFIntegration",
               "Remove-CPFProfile",
               "Remove-CPFProfileKey",
               "Remove-CPFProfileObject",
               "Remove-CPFProfileObjectType",
               "Remove-CPFWorkflow",
               "Get-CPFAutoMergingPreview",
               "Get-CPFCalculatedAttributeDefinition",
               "Get-CPFCalculatedAttributeForProfile",
               "Get-CPFDomain",
               "Get-CPFIdentityResolutionJob",
               "Get-CPFIntegration",
               "Get-CPFMatch",
               "Get-CPFProfileObjectType",
               "Get-CPFProfileObjectTypeTemplate",
               "Get-CPFWorkflow",
               "Get-CPFWorkflowStep",
               "Get-CPFAccountIntegrationList",
               "Get-CPFCalculatedAttributeDefinitionList",
               "Get-CPFCalculatedAttributesForProfileList",
               "Get-CPFDomainList",
               "Get-CPFIdentityResolutionJobList",
               "Get-CPFIntegrationList",
               "Get-CPFProfileObjectList",
               "Get-CPFProfileObjectTypeList",
               "Get-CPFProfileObjectTypeTemplateList",
               "Get-CPFResourceTag",
               "Get-CPFWorkflowList",
               "Merge-CPFProfile",
               "Write-CPFIntegration",
               "Write-CPFProfileObject",
               "Write-CPFProfileObjectType",
               "Search-CPFProfile",
               "Add-CPFResourceTag",
               "Remove-CPFResourceTag",
               "Update-CPFCalculatedAttributeDefinition",
               "Update-CPFDomain",
               "Update-CPFProfile")
}

_awsArgumentCompleterRegistration $CPF_SelectCompleters $CPF_SelectMap

