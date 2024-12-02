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
        # Amazon.CustomerProfiles.AttributeMatchingModel
        {
            ($_ -eq "New-CPFDomain/AttributeTypesSelector_AttributeMatchingModel") -Or
            ($_ -eq "Update-CPFDomain/AttributeTypesSelector_AttributeMatchingModel")
        }
        {
            $v = "MANY_TO_MANY","ONE_TO_ONE"
            break
        }

        # Amazon.CustomerProfiles.ConflictResolvingModel
        {
            ($_ -eq "Get-CPFAutoMergingPreview/ConflictResolution_ConflictResolvingModel") -Or
            ($_ -eq "New-CPFDomain/ConflictResolution_ConflictResolvingModel") -Or
            ($_ -eq "Update-CPFDomain/ConflictResolution_ConflictResolvingModel") -Or
            ($_ -eq "New-CPFDomain/RuleBasedMatching_ConflictResolution_ConflictResolvingModel") -Or
            ($_ -eq "Update-CPFDomain/RuleBasedMatching_ConflictResolution_ConflictResolvingModel")
        }
        {
            $v = "RECENCY","SOURCE"
            break
        }

        # Amazon.CustomerProfiles.DataFormat
        "New-CPFSegmentSnapshot/DataFormat"
        {
            $v = "CSV","JSONL","ORC"
            break
        }

        # Amazon.CustomerProfiles.DataPullMode
        {
            ($_ -eq "New-CPFIntegrationWorkflow/Scheduled_DataPullMode") -Or
            ($_ -eq "Write-CPFIntegration/Scheduled_DataPullMode")
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

        # Amazon.CustomerProfiles.Include
        "New-CPFCalculatedAttributeDefinition/Filter_Include"
        {
            $v = "ALL","ANY","NONE"
            break
        }

        # Amazon.CustomerProfiles.IncludeOptions
        {
            ($_ -eq "New-CPFSegmentDefinition/SegmentGroups_Include") -Or
            ($_ -eq "New-CPFSegmentEstimate/SegmentQuery_Include")
        }
        {
            $v = "ALL","ANY","NONE"
            break
        }

        # Amazon.CustomerProfiles.JobScheduleDayOfTheWeek
        {
            ($_ -eq "New-CPFDomain/JobSchedule_DayOfTheWeek") -Or
            ($_ -eq "Update-CPFDomain/JobSchedule_DayOfTheWeek")
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

        # Amazon.CustomerProfiles.MatchType
        "Get-CPFSimilarProfile/MatchType"
        {
            $v = "ML_BASED_MATCHING","RULE_BASED_MATCHING"
            break
        }

        # Amazon.CustomerProfiles.Operator
        {
            ($_ -eq "New-CPFCalculatedAttributeDefinition/Threshold_Operator") -Or
            ($_ -eq "Update-CPFCalculatedAttributeDefinition/Threshold_Operator")
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

        # Amazon.CustomerProfiles.RangeUnit
        "Get-CPFGetCalculatedAttributeForProfile/Range_Unit"
        {
            $v = "DAYS"
            break
        }

        # Amazon.CustomerProfiles.SourceConnectorType
        {
            ($_ -eq "New-CPFIntegrationWorkflow/SourceFlowConfig_ConnectorType") -Or
            ($_ -eq "Write-CPFIntegration/SourceFlowConfig_ConnectorType")
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
            ($_ -eq "New-CPFIntegrationWorkflow/TriggerConfig_TriggerType") -Or
            ($_ -eq "Write-CPFIntegration/TriggerConfig_TriggerType")
        }
        {
            $v = "Event","OnDemand","Scheduled"
            break
        }

        # Amazon.CustomerProfiles.Unit
        {
            ($_ -eq "New-CPFCalculatedAttributeDefinition/Range_Unit") -Or
            ($_ -eq "Update-CPFCalculatedAttributeDefinition/Range_Unit")
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
    "AttributeTypesSelector_AttributeMatchingModel"=@("New-CPFDomain","Update-CPFDomain")
    "ConflictResolution_ConflictResolvingModel"=@("Get-CPFAutoMergingPreview","New-CPFDomain","Update-CPFDomain")
    "DataFormat"=@("New-CPFSegmentSnapshot")
    "Filter_Include"=@("New-CPFCalculatedAttributeDefinition")
    "Gender"=@("New-CPFProfile","Update-CPFProfile")
    "JobSchedule_DayOfTheWeek"=@("New-CPFDomain","Update-CPFDomain")
    "LogicalOperator"=@("Search-CPFProfile")
    "MatchType"=@("Get-CPFSimilarProfile")
    "PartyType"=@("New-CPFProfile","Update-CPFProfile")
    "Range_Unit"=@("Get-CPFGetCalculatedAttributeForProfile","New-CPFCalculatedAttributeDefinition","Update-CPFCalculatedAttributeDefinition")
    "RuleBasedMatching_ConflictResolution_ConflictResolvingModel"=@("New-CPFDomain","Update-CPFDomain")
    "Scheduled_DataPullMode"=@("New-CPFIntegrationWorkflow","Write-CPFIntegration")
    "SegmentGroups_Include"=@("New-CPFSegmentDefinition")
    "SegmentQuery_Include"=@("New-CPFSegmentEstimate")
    "SourceFlowConfig_ConnectorType"=@("New-CPFIntegrationWorkflow","Write-CPFIntegration")
    "Statistic"=@("New-CPFCalculatedAttributeDefinition")
    "Status"=@("Get-CPFWorkflowList")
    "Threshold_Operator"=@("New-CPFCalculatedAttributeDefinition","Update-CPFCalculatedAttributeDefinition")
    "TriggerConfig_TriggerType"=@("New-CPFIntegrationWorkflow","Write-CPFIntegration")
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
               "Get-CPFGetCalculatedAttributeForProfile",
               "Get-CPFGetProfile",
               "New-CPFCalculatedAttributeDefinition",
               "New-CPFDomain",
               "New-CPFEventStream",
               "New-CPFEventTrigger",
               "New-CPFIntegrationWorkflow",
               "New-CPFProfile",
               "New-CPFSegmentDefinition",
               "New-CPFSegmentEstimate",
               "New-CPFSegmentSnapshot",
               "Remove-CPFCalculatedAttributeDefinition",
               "Remove-CPFDomain",
               "Remove-CPFEventStream",
               "Remove-CPFEventTrigger",
               "Remove-CPFIntegration",
               "Remove-CPFProfile",
               "Remove-CPFProfileKey",
               "Remove-CPFProfileObject",
               "Remove-CPFProfileObjectType",
               "Remove-CPFSegmentDefinition",
               "Remove-CPFWorkflow",
               "Find-CPFProfileObjectType",
               "Get-CPFAutoMergingPreview",
               "Get-CPFCalculatedAttributeDefinition",
               "Get-CPFCalculatedAttributeForProfile",
               "Get-CPFDomain",
               "Get-CPFEventStream",
               "Get-CPFEventTrigger",
               "Get-CPFIdentityResolutionJob",
               "Get-CPFIntegration",
               "Get-CPFMatch",
               "Get-CPFProfileObjectType",
               "Get-CPFProfileObjectTypeTemplate",
               "Get-CPFSegmentDefinition",
               "Get-CPFSegmentEstimate",
               "Get-CPFSegmentMembership",
               "Get-CPFSegmentSnapshot",
               "Get-CPFSimilarProfile",
               "Get-CPFWorkflow",
               "Get-CPFWorkflowStep",
               "Get-CPFAccountIntegrationList",
               "Get-CPFCalculatedAttributeDefinitionList",
               "Get-CPFCalculatedAttributesForProfileList",
               "Get-CPFDomainList",
               "Get-CPFEventStreamList",
               "Get-CPFEventTriggerList",
               "Get-CPFIdentityResolutionJobList",
               "Get-CPFIntegrationList",
               "Get-CPFObjectTypeAttributeList",
               "Get-CPFProfileAttributeValueList",
               "Get-CPFProfileObjectList",
               "Get-CPFProfileObjectTypeList",
               "Get-CPFProfileObjectTypeTemplateList",
               "Get-CPFRuleBasedMatchList",
               "Get-CPFSegmentDefinitionList",
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
               "Update-CPFEventTrigger",
               "Update-CPFProfile")
}

_awsArgumentCompleterRegistration $CPF_SelectCompleters $CPF_SelectMap

