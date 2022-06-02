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

# Argument completions for service Amazon Kendra


$KNDR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Kendra.ConditionOperator
        {
            ($_ -eq "New-KNDRDataSource/CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "Update-KNDRDataSource/CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "Write-KNDRDocumentBatch/CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "New-KNDRDataSource/CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "Update-KNDRDataSource/CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "Write-KNDRDocumentBatch/CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator")
        }
        {
            $v = "BeginsWith","Contains","Equals","Exists","GreaterThan","GreaterThanOrEquals","LessThan","LessThanOrEquals","NotContains","NotEquals","NotExists"
            break
        }

        # Amazon.Kendra.DataSourceSyncJobStatus
        "Get-KNDRDataSourceSyncJobList/StatusFilter"
        {
            $v = "ABORTED","FAILED","INCOMPLETE","STOPPING","SUCCEEDED","SYNCING","SYNCING_INDEXING"
            break
        }

        # Amazon.Kendra.DataSourceType
        "New-KNDRDataSource/Type"
        {
            $v = "BOX","CONFLUENCE","CUSTOM","DATABASE","FSX","GITHUB","GOOGLEDRIVE","JIRA","ONEDRIVE","QUIP","S3","SALESFORCE","SERVICENOW","SHAREPOINT","SLACK","WEBCRAWLER","WORKDOCS"
            break
        }

        # Amazon.Kendra.FaqFileFormat
        "New-KNDRFaq/FileFormat"
        {
            $v = "CSV","CSV_WITH_HEADER","JSON"
            break
        }

        # Amazon.Kendra.IndexEdition
        "New-KNDRIndex/Edition"
        {
            $v = "DEVELOPER_EDITION","ENTERPRISE_EDITION"
            break
        }

        # Amazon.Kendra.Interval
        "Get-KNDRSnapshot/Interval"
        {
            $v = "ONE_MONTH_AGO","ONE_WEEK_AGO","THIS_MONTH","THIS_WEEK","TWO_MONTHS_AGO","TWO_WEEKS_AGO"
            break
        }

        # Amazon.Kendra.MetricType
        "Get-KNDRSnapshot/MetricType"
        {
            $v = "AGG_QUERY_DOC_METRICS","DOCS_BY_CLICK_COUNT","QUERIES_BY_COUNT","QUERIES_BY_ZERO_CLICK_RATE","QUERIES_BY_ZERO_RESULT_RATE","TREND_QUERY_DOC_METRICS"
            break
        }

        # Amazon.Kendra.Mode
        "Update-KNDRQuerySuggestionsConfig/Mode"
        {
            $v = "ENABLED","LEARN_ONLY"
            break
        }

        # Amazon.Kendra.QueryResultType
        "Invoke-KNDRQuery/QueryResultTypeFilter"
        {
            $v = "ANSWER","DOCUMENT","QUESTION_ANSWER"
            break
        }

        # Amazon.Kendra.SortOrder
        "Invoke-KNDRQuery/SortingConfiguration_SortOrder"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Kendra.UserContextPolicy
        {
            ($_ -eq "New-KNDRIndex/UserContextPolicy") -Or
            ($_ -eq "Update-KNDRIndex/UserContextPolicy")
        }
        {
            $v = "ATTRIBUTE_FILTER","USER_TOKEN"
            break
        }

        # Amazon.Kendra.UserGroupResolutionMode
        {
            ($_ -eq "New-KNDRIndex/UserGroupResolutionConfiguration_UserGroupResolutionMode") -Or
            ($_ -eq "Update-KNDRIndex/UserGroupResolutionConfiguration_UserGroupResolutionMode")
        }
        {
            $v = "AWS_SSO","NONE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KNDR_map = @{
    "CustomDocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator"=@("New-KNDRDataSource","Update-KNDRDataSource","Write-KNDRDocumentBatch")
    "CustomDocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator"=@("New-KNDRDataSource","Update-KNDRDataSource","Write-KNDRDocumentBatch")
    "Edition"=@("New-KNDRIndex")
    "FileFormat"=@("New-KNDRFaq")
    "Interval"=@("Get-KNDRSnapshot")
    "MetricType"=@("Get-KNDRSnapshot")
    "Mode"=@("Update-KNDRQuerySuggestionsConfig")
    "QueryResultTypeFilter"=@("Invoke-KNDRQuery")
    "SortingConfiguration_SortOrder"=@("Invoke-KNDRQuery")
    "StatusFilter"=@("Get-KNDRDataSourceSyncJobList")
    "Type"=@("New-KNDRDataSource")
    "UserContextPolicy"=@("New-KNDRIndex","Update-KNDRIndex")
    "UserGroupResolutionConfiguration_UserGroupResolutionMode"=@("New-KNDRIndex","Update-KNDRIndex")
}

_awsArgumentCompleterRegistration $KNDR_Completers $KNDR_map

$KNDR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KNDR.$($commandName.Replace('-', ''))Cmdlet]"
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

$KNDR_SelectMap = @{
    "Select"=@("Add-KNDREntitiesToExperience",
               "Add-KNDRPersonasToEntity",
               "Remove-KNDRDocumentBatch",
               "Get-KNDRGetDocumentStatus",
               "Write-KNDRDocumentBatch",
               "Clear-KNDRQuerySuggestion",
               "New-KNDRDataSource",
               "New-KNDRExperience",
               "New-KNDRFaq",
               "New-KNDRIndex",
               "New-KNDRQuerySuggestionsBlockList",
               "New-KNDRThesaurus",
               "Remove-KNDRDataSource",
               "Remove-KNDRExperience",
               "Remove-KNDRFaq",
               "Remove-KNDRIndex",
               "Remove-KNDRPrincipalMapping",
               "Remove-KNDRQuerySuggestionsBlockList",
               "Remove-KNDRThesaurus",
               "Get-KNDRDataSource",
               "Get-KNDRExperience",
               "Get-KNDRFaq",
               "Get-KNDRIndex",
               "Get-KNDRPrincipalMapping",
               "Get-KNDRQuerySuggestionsBlockList",
               "Get-KNDRQuerySuggestionsConfig",
               "Get-KNDRThesaurus",
               "Remove-KNDREntitiesFromExperience",
               "Remove-KNDRPersonasFromEntity",
               "Get-KNDRQuerySuggestion",
               "Get-KNDRSnapshot",
               "Get-KNDRDataSourceList",
               "Get-KNDRDataSourceSyncJobList",
               "Get-KNDREntityPersonaList",
               "Get-KNDRExperienceEntityList",
               "Get-KNDRExperienceList",
               "Get-KNDRFaqList",
               "Get-KNDRGroupsOlderThanOrderingIdList",
               "Get-KNDRIndexList",
               "Get-KNDRQuerySuggestionsBlockListList",
               "Get-KNDRResourceTag",
               "Get-KNDRThesauriList",
               "Write-KNDRPrincipalMapping",
               "Invoke-KNDRQuery",
               "Start-KNDRDataSourceSyncJob",
               "Stop-KNDRDataSourceSyncJob",
               "Send-KNDRFeedback",
               "Add-KNDRResourceTag",
               "Remove-KNDRResourceTag",
               "Update-KNDRDataSource",
               "Update-KNDRExperience",
               "Update-KNDRIndex",
               "Update-KNDRQuerySuggestionsBlockList",
               "Update-KNDRQuerySuggestionsConfig",
               "Update-KNDRThesaurus")
}

_awsArgumentCompleterRegistration $KNDR_SelectCompleters $KNDR_SelectMap

