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

# Argument completions for service AWS Glue


$GLUE_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Glue.CatalogEncryptionMode
        "Set-GLUEDataCatalogEncryptionSetting/EncryptionAtRest_CatalogEncryptionMode"
        {
            $v = "DISABLED","SSE-KMS","SSE-KMS-WITH-SERVICE-ROLE"
            break
        }

        # Amazon.Glue.CloudWatchEncryptionMode
        "New-GLUESecurityConfiguration/CloudWatchEncryption_CloudWatchEncryptionMode"
        {
            $v = "DISABLED","SSE-KMS"
            break
        }

        # Amazon.Glue.Compatibility
        {
            ($_ -eq "New-GLUESchema/Compatibility") -Or
            ($_ -eq "Update-GLUESchema/Compatibility")
        }
        {
            $v = "BACKWARD","BACKWARD_ALL","DISABLED","FORWARD","FORWARD_ALL","FULL","FULL_ALL","NONE"
            break
        }

        # Amazon.Glue.CrawlerLineageSettings
        {
            ($_ -eq "New-GLUECrawler/LineageConfiguration_CrawlerLineageSetting") -Or
            ($_ -eq "Update-GLUECrawler/LineageConfiguration_CrawlerLineageSetting")
        }
        {
            $v = "DISABLE","ENABLE"
            break
        }

        # Amazon.Glue.CsvHeaderOption
        {
            ($_ -eq "New-GLUEClassifier/CsvClassifier_ContainsHeader") -Or
            ($_ -eq "Update-GLUEClassifier/CsvClassifier_ContainsHeader")
        }
        {
            $v = "ABSENT","PRESENT","UNKNOWN"
            break
        }

        # Amazon.Glue.CsvSerdeOption
        {
            ($_ -eq "New-GLUEClassifier/CsvClassifier_Serde") -Or
            ($_ -eq "Update-GLUEClassifier/CsvClassifier_Serde")
        }
        {
            $v = "LazySimpleSerDe","None","OpenCSVSerDe"
            break
        }

        # Amazon.Glue.DataFormat
        {
            ($_ -eq "Get-GLUESchemaVersionValidity/DataFormat") -Or
            ($_ -eq "New-GLUESchema/DataFormat")
        }
        {
            $v = "AVRO","JSON","PROTOBUF"
            break
        }

        # Amazon.Glue.DQCompositeRuleEvaluationMethod
        "Start-GLUEDataQualityRulesetEvaluationRun/AdditionalRunOptions_CompositeRuleEvaluationMethod"
        {
            $v = "COLUMN","ROW"
            break
        }

        # Amazon.Glue.EnableHybridValues
        "Set-GLUEResourcePolicy/EnableHybrid"
        {
            $v = "FALSE","TRUE"
            break
        }

        # Amazon.Glue.ExecutionClass
        {
            ($_ -eq "New-GLUEJob/ExecutionClass") -Or
            ($_ -eq "Start-GLUEJobRun/ExecutionClass")
        }
        {
            $v = "FLEX","STANDARD"
            break
        }

        # Amazon.Glue.ExistCondition
        "Set-GLUEResourcePolicy/PolicyExistsCondition"
        {
            $v = "MUST_EXIST","NONE","NOT_EXIST"
            break
        }

        # Amazon.Glue.JobBookmarksEncryptionMode
        "New-GLUESecurityConfiguration/JobBookmarksEncryption_JobBookmarksEncryptionMode"
        {
            $v = "CSE-KMS","DISABLED"
            break
        }

        # Amazon.Glue.JobMode
        "New-GLUEJob/JobMode"
        {
            $v = "NOTEBOOK","SCRIPT","VISUAL"
            break
        }

        # Amazon.Glue.Language
        {
            ($_ -eq "Get-GLUEPlan/Language") -Or
            ($_ -eq "New-GLUEScript/Language")
        }
        {
            $v = "PYTHON","SCALA"
            break
        }

        # Amazon.Glue.MetadataOperation
        "New-GLUETable/IcebergInput_MetadataOperation"
        {
            $v = "CREATE"
            break
        }

        # Amazon.Glue.MLUserDataEncryptionModeString
        "New-GLUEMLTransform/MlUserDataEncryption_MlUserDataEncryptionMode"
        {
            $v = "DISABLED","SSE-KMS"
            break
        }

        # Amazon.Glue.RecrawlBehavior
        {
            ($_ -eq "New-GLUECrawler/RecrawlPolicy_RecrawlBehavior") -Or
            ($_ -eq "Update-GLUECrawler/RecrawlPolicy_RecrawlBehavior")
        }
        {
            $v = "CRAWL_EVENT_MODE","CRAWL_EVERYTHING","CRAWL_NEW_FOLDERS_ONLY"
            break
        }

        # Amazon.Glue.ResourceShareType
        {
            ($_ -eq "Find-GLUETable/ResourceShareType") -Or
            ($_ -eq "Get-GLUEDatabaseList/ResourceShareType")
        }
        {
            $v = "ALL","FEDERATED","FOREIGN"
            break
        }

        # Amazon.Glue.SchemaDiffType
        "Get-GLUESchemaVersionsDiff/SchemaDiffType"
        {
            $v = "SYNTAX_DIFF"
            break
        }

        # Amazon.Glue.SortDirectionType
        {
            ($_ -eq "Get-GLUEMLTaskRunList/Sort_SortDirection") -Or
            ($_ -eq "Get-GLUEMLTransformIdentifier/Sort_SortDirection") -Or
            ($_ -eq "Get-GLUEMLTransformList/Sort_SortDirection")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.Glue.SourceControlAuthStrategy
        {
            ($_ -eq "Update-GLUEJobFromSourceControl/AuthStrategy") -Or
            ($_ -eq "Update-GLUESourceControlFromJob/AuthStrategy") -Or
            ($_ -eq "New-GLUEJob/SourceControlDetails_AuthStrategy")
        }
        {
            $v = "AWS_SECRETS_MANAGER","PERSONAL_ACCESS_TOKEN"
            break
        }

        # Amazon.Glue.SourceControlProvider
        {
            ($_ -eq "Update-GLUEJobFromSourceControl/Provider") -Or
            ($_ -eq "Update-GLUESourceControlFromJob/Provider") -Or
            ($_ -eq "New-GLUEJob/SourceControlDetails_Provider")
        }
        {
            $v = "AWS_CODE_COMMIT","BITBUCKET","GITHUB","GITLAB"
            break
        }

        # Amazon.Glue.TableOptimizerType
        {
            ($_ -eq "Get-GLUETableOptimizer/Type") -Or
            ($_ -eq "Get-GLUETableOptimizerRunList/Type") -Or
            ($_ -eq "New-GLUETableOptimizer/Type") -Or
            ($_ -eq "Remove-GLUETableOptimizer/Type") -Or
            ($_ -eq "Update-GLUETableOptimizer/Type")
        }
        {
            $v = "compaction"
            break
        }

        # Amazon.Glue.TaskRunSortColumnType
        "Get-GLUEMLTaskRunList/Sort_Column"
        {
            $v = "STARTED","STATUS","TASK_RUN_TYPE"
            break
        }

        # Amazon.Glue.TaskStatusType
        "Get-GLUEMLTaskRunList/Filter_Status"
        {
            $v = "FAILED","RUNNING","STARTING","STOPPED","STOPPING","SUCCEEDED","TIMEOUT"
            break
        }

        # Amazon.Glue.TaskType
        "Get-GLUEMLTaskRunList/Filter_TaskRunType"
        {
            $v = "EVALUATION","EXPORT_LABELS","FIND_MATCHES","IMPORT_LABELS","LABELING_SET_GENERATION"
            break
        }

        # Amazon.Glue.TransformSortColumnType
        {
            ($_ -eq "Get-GLUEMLTransformIdentifier/Sort_Column") -Or
            ($_ -eq "Get-GLUEMLTransformList/Sort_Column")
        }
        {
            $v = "CREATED","LAST_MODIFIED","NAME","STATUS","TRANSFORM_TYPE"
            break
        }

        # Amazon.Glue.TransformStatusType
        {
            ($_ -eq "Get-GLUEMLTransformIdentifier/Filter_Status") -Or
            ($_ -eq "Get-GLUEMLTransformList/Filter_Status")
        }
        {
            $v = "DELETING","NOT_READY","READY"
            break
        }

        # Amazon.Glue.TransformType
        {
            ($_ -eq "Get-GLUEMLTransformIdentifier/Filter_TransformType") -Or
            ($_ -eq "Get-GLUEMLTransformList/Filter_TransformType") -Or
            ($_ -eq "New-GLUEMLTransform/Parameters_TransformType") -Or
            ($_ -eq "Update-GLUEMLTransform/Parameters_TransformType")
        }
        {
            $v = "FIND_MATCHES"
            break
        }

        # Amazon.Glue.TriggerType
        "New-GLUETrigger/Type"
        {
            $v = "CONDITIONAL","EVENT","ON_DEMAND","SCHEDULED"
            break
        }

        # Amazon.Glue.ViewDialect
        "Get-GLUEUnfilteredTableMetadata/SupportedDialect_Dialect"
        {
            $v = "ATHENA","REDSHIFT","SPARK"
            break
        }

        # Amazon.Glue.ViewUpdateAction
        "Update-GLUETable/ViewUpdateAction"
        {
            $v = "ADD","ADD_OR_REPLACE","DROP","REPLACE"
            break
        }

        # Amazon.Glue.WorkerType
        {
            ($_ -eq "New-GLUEDevEndpoint/WorkerType") -Or
            ($_ -eq "New-GLUEJob/WorkerType") -Or
            ($_ -eq "New-GLUEMLTransform/WorkerType") -Or
            ($_ -eq "New-GLUESession/WorkerType") -Or
            ($_ -eq "Start-GLUEJobRun/WorkerType") -Or
            ($_ -eq "Update-GLUEMLTransform/WorkerType")
        }
        {
            $v = "G.025X","G.1X","G.2X","G.4X","G.8X","Standard","Z.2X"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GLUE_map = @{
    "AdditionalRunOptions_CompositeRuleEvaluationMethod"=@("Start-GLUEDataQualityRulesetEvaluationRun")
    "AuthStrategy"=@("Update-GLUEJobFromSourceControl","Update-GLUESourceControlFromJob")
    "CloudWatchEncryption_CloudWatchEncryptionMode"=@("New-GLUESecurityConfiguration")
    "Compatibility"=@("New-GLUESchema","Update-GLUESchema")
    "CsvClassifier_ContainsHeader"=@("New-GLUEClassifier","Update-GLUEClassifier")
    "CsvClassifier_Serde"=@("New-GLUEClassifier","Update-GLUEClassifier")
    "DataFormat"=@("Get-GLUESchemaVersionValidity","New-GLUESchema")
    "EnableHybrid"=@("Set-GLUEResourcePolicy")
    "EncryptionAtRest_CatalogEncryptionMode"=@("Set-GLUEDataCatalogEncryptionSetting")
    "ExecutionClass"=@("New-GLUEJob","Start-GLUEJobRun")
    "Filter_Status"=@("Get-GLUEMLTaskRunList","Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "Filter_TaskRunType"=@("Get-GLUEMLTaskRunList")
    "Filter_TransformType"=@("Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "IcebergInput_MetadataOperation"=@("New-GLUETable")
    "JobBookmarksEncryption_JobBookmarksEncryptionMode"=@("New-GLUESecurityConfiguration")
    "JobMode"=@("New-GLUEJob")
    "Language"=@("Get-GLUEPlan","New-GLUEScript")
    "LineageConfiguration_CrawlerLineageSetting"=@("New-GLUECrawler","Update-GLUECrawler")
    "MlUserDataEncryption_MlUserDataEncryptionMode"=@("New-GLUEMLTransform")
    "Parameters_TransformType"=@("New-GLUEMLTransform","Update-GLUEMLTransform")
    "PolicyExistsCondition"=@("Set-GLUEResourcePolicy")
    "Provider"=@("Update-GLUEJobFromSourceControl","Update-GLUESourceControlFromJob")
    "RecrawlPolicy_RecrawlBehavior"=@("New-GLUECrawler","Update-GLUECrawler")
    "ResourceShareType"=@("Find-GLUETable","Get-GLUEDatabaseList")
    "SchemaDiffType"=@("Get-GLUESchemaVersionsDiff")
    "Sort_Column"=@("Get-GLUEMLTaskRunList","Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "Sort_SortDirection"=@("Get-GLUEMLTaskRunList","Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "SourceControlDetails_AuthStrategy"=@("New-GLUEJob")
    "SourceControlDetails_Provider"=@("New-GLUEJob")
    "SupportedDialect_Dialect"=@("Get-GLUEUnfilteredTableMetadata")
    "Type"=@("Get-GLUETableOptimizer","Get-GLUETableOptimizerRunList","New-GLUETableOptimizer","New-GLUETrigger","Remove-GLUETableOptimizer","Update-GLUETableOptimizer")
    "ViewUpdateAction"=@("Update-GLUETable")
    "WorkerType"=@("New-GLUEDevEndpoint","New-GLUEJob","New-GLUEMLTransform","New-GLUESession","Start-GLUEJobRun","Update-GLUEMLTransform")
}

_awsArgumentCompleterRegistration $GLUE_Completers $GLUE_map

$GLUE_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GLUE.$($commandName.Replace('-', ''))Cmdlet]"
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

$GLUE_SelectMap = @{
    "Select"=@("New-GLUEPartitionBatch",
               "Remove-GLUEConnectionBatch",
               "Remove-GLUEPartitionBatch",
               "Remove-GLUETableBatch",
               "Remove-GLUETableVersionBatch",
               "Get-GLUEBlueprintBatch",
               "Get-GLUECrawlerBatch",
               "Get-GLUEGetCustomEntityType",
               "Get-GLUEDataQualityResultBatch",
               "Get-GLUEDevEndpointBatch",
               "Get-GLUEJobBatch",
               "Get-GLUEPartitionBatch",
               "Get-GLUETableOptimizerBatch",
               "Get-GLUETriggerBatch",
               "Get-GLUEWorkflowBatch",
               "Stop-GLUEJobRunBatch",
               "Update-GLUEPartitionBatch",
               "Stop-GLUEDataQualityRuleRecommendationRun",
               "Stop-GLUEDataQualityRulesetEvaluationRun",
               "Stop-GLUEMLTaskRun",
               "Stop-GLUEStatement",
               "Get-GLUESchemaVersionValidity",
               "New-GLUEBlueprint",
               "New-GLUEClassifier",
               "New-GLUEConnection",
               "New-GLUECrawler",
               "New-GLUECustomEntityType",
               "New-GLUEDatabase",
               "New-GLUEDataQualityRuleset",
               "New-GLUEDevEndpoint",
               "New-GLUEJob",
               "New-GLUEMLTransform",
               "New-GLUEPartition",
               "New-GLUEPartitionIndex",
               "New-GLUERegistry",
               "New-GLUESchema",
               "New-GLUEScript",
               "New-GLUESecurityConfiguration",
               "New-GLUESession",
               "New-GLUETable",
               "New-GLUETableOptimizer",
               "New-GLUETrigger",
               "New-GLUEUserDefinedFunction",
               "New-GLUEWorkflow",
               "Remove-GLUEBlueprint",
               "Remove-GLUEClassifier",
               "Remove-GLUEColumnStatisticsForPartition",
               "Remove-GLUEColumnStatisticsForTable",
               "Remove-GLUEConnection",
               "Remove-GLUECrawler",
               "Remove-GLUECustomEntityType",
               "Remove-GLUEDatabase",
               "Remove-GLUEDataQualityRuleset",
               "Remove-GLUEDevEndpoint",
               "Remove-GLUEJob",
               "Remove-GLUEMLTransform",
               "Remove-GLUEPartition",
               "Remove-GLUEPartitionIndex",
               "Remove-GLUERegistry",
               "Remove-GLUEResourcePolicy",
               "Remove-GLUESchema",
               "Remove-GLUESchemaVersion",
               "Remove-GLUESecurityConfiguration",
               "Remove-GLUESession",
               "Remove-GLUETable",
               "Remove-GLUETableOptimizer",
               "Remove-GLUETableVersion",
               "Remove-GLUETrigger",
               "Remove-GLUEUserDefinedFunction",
               "Remove-GLUEWorkflow",
               "Get-GLUEBlueprint",
               "Get-GLUEBlueprintRun",
               "Get-GLUEBlueprintRunList",
               "Get-GLUECatalogImportStatus",
               "Get-GLUEClassifier",
               "Get-GLUEClassifierList",
               "Get-GLUEColumnStatisticsForPartition",
               "Get-GLUEColumnStatisticsForTable",
               "Get-GLUEColumnStatisticsTaskRun",
               "Get-GLUEColumnStatisticsTaskList",
               "Get-GLUEConnection",
               "Get-GLUEConnectionList",
               "Get-GLUECrawler",
               "Get-GLUECrawlerMetricList",
               "Get-GLUECrawlerList",
               "Get-GLUECustomEntityType",
               "Get-GLUEDatabase",
               "Get-GLUEDatabaseList",
               "Get-GLUEDataCatalogEncryptionSetting",
               "Get-GLUEDataflowGraph",
               "Get-GLUEDataQualityResult",
               "Get-GLUEDataQualityRuleRecommendationRun",
               "Get-GLUEDataQualityRuleset",
               "Get-GLUEDataQualityRulesetEvaluationRun",
               "Get-GLUEDevEndpoint",
               "Get-GLUEDevEndpointList",
               "Get-GLUEJob",
               "Get-GLUEJobBookmark",
               "Get-GLUEJobRun",
               "Get-GLUEJobRunList",
               "Get-GLUEJobList",
               "Get-GLUEMapping",
               "Get-GLUEMLTaskRun",
               "Get-GLUEMLTaskRunList",
               "Get-GLUEMLTransform",
               "Get-GLUEMLTransformList",
               "Get-GLUEPartition",
               "Get-GLUEPartitionIndex",
               "Get-GLUEPartitionList",
               "Get-GLUEPlan",
               "Get-GLUERegistry",
               "Get-GLUEGluePolicyList",
               "Get-GLUEResourcePolicy",
               "Get-GLUESchema",
               "Get-GLUESchemaByDefinition",
               "Get-GLUESchemaVersion",
               "Get-GLUESchemaVersionsDiff",
               "Get-GLUESecurityConfiguration",
               "Get-GLUESecurityConfigurationList",
               "Get-GLUESession",
               "Get-GLUEStatement",
               "Get-GLUETable",
               "Get-GLUETableOptimizer",
               "Get-GLUETableList",
               "Get-GLUETableVersion",
               "Get-GLUETableVersionList",
               "Get-GLUETag",
               "Get-GLUETrigger",
               "Get-GLUETriggerList",
               "Get-GLUEUnfilteredPartitionMetadata",
               "Get-GLUEUnfilteredPartitionsMetadata",
               "Get-GLUEUnfilteredTableMetadata",
               "Get-GLUEUserDefinedFunction",
               "Get-GLUEUserDefinedFunctionList",
               "Get-GLUEWorkflow",
               "Get-GLUEWorkflowRun",
               "Get-GLUEWorkflowRunProperty",
               "Get-GLUEWorkflowRunList",
               "Import-GLUECatalog",
               "Get-GLUEBlueprintList",
               "Get-GLUEColumnStatisticsTaskRunList",
               "Get-GLUECrawlerNameList",
               "Get-GLUECrawlList",
               "Get-GLUECustomEntityTypeList",
               "Get-GLUEDataQualityResultList",
               "Get-GLUEDataQualityRuleRecommendationRunList",
               "Get-GLUEDataQualityRulesetEvaluationRunList",
               "Get-GLUEDataQualityRulesetList",
               "Get-GLUEDevEndpointNameList",
               "Get-GLUEJobNameList",
               "Get-GLUEMLTransformIdentifier",
               "Get-GLUERegistryList",
               "Get-GLUESchemaList",
               "Get-GLUESchemaVersionList",
               "Get-GLUESessionList",
               "Get-GLUEStatementList",
               "Get-GLUETableOptimizerRunList",
               "Get-GLUETriggerNameList",
               "Get-GLUEWorkflowList",
               "Set-GLUEDataCatalogEncryptionSetting",
               "Set-GLUEResourcePolicy",
               "Write-GLUESchemaVersionMetadata",
               "Write-GLUEWorkflowRunProperty",
               "Find-GLUESchemaVersionMetadata",
               "Register-GLUESchemaVersion",
               "Remove-GLUESchemaVersionMetadata",
               "Reset-GLUEJobBookmark",
               "Resume-GLUEWorkflowRun",
               "Invoke-GLUEStatement",
               "Find-GLUETable",
               "Start-GLUEBlueprintRun",
               "Start-GLUEColumnStatisticsTaskRun",
               "Start-GLUECrawler",
               "Start-GLUECrawlerSchedule",
               "Start-GLUEDataQualityRuleRecommendationRun",
               "Start-GLUEDataQualityRulesetEvaluationRun",
               "Start-GLUEExportLabelsTaskRun",
               "Start-GLUEImportLabelsTaskRun",
               "Start-GLUEJobRun",
               "Start-GLUEMLEvaluationTaskRun",
               "Start-GLUEMLLabelingSetGenerationTaskRun",
               "Start-GLUETrigger",
               "Start-GLUEWorkflowRun",
               "Stop-GLUEColumnStatisticsTaskRun",
               "Stop-GLUECrawler",
               "Stop-GLUECrawlerSchedule",
               "Stop-GLUESession",
               "Stop-GLUETrigger",
               "Stop-GLUEWorkflowRun",
               "Add-GLUEResourceTag",
               "Remove-GLUEResourceTag",
               "Update-GLUEBlueprint",
               "Update-GLUEClassifier",
               "Update-GLUEColumnStatisticsForPartition",
               "Update-GLUEColumnStatisticsForTable",
               "Update-GLUEConnection",
               "Update-GLUECrawler",
               "Update-GLUECrawlerSchedule",
               "Update-GLUEDatabase",
               "Update-GLUEDataQualityRuleset",
               "Update-GLUEDevEndpoint",
               "Update-GLUEJob",
               "Update-GLUEJobFromSourceControl",
               "Update-GLUEMLTransform",
               "Update-GLUEPartition",
               "Update-GLUERegistry",
               "Update-GLUESchema",
               "Update-GLUESourceControlFromJob",
               "Update-GLUETable",
               "Update-GLUETableOptimizer",
               "Update-GLUETrigger",
               "Update-GLUEUserDefinedFunction",
               "Update-GLUEWorkflow")
}

_awsArgumentCompleterRegistration $GLUE_SelectCompleters $GLUE_SelectMap

