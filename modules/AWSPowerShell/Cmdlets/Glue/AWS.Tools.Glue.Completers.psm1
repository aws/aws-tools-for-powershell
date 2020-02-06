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
        "Set-GLUEDataCatalogEncryptionSetting/DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode"
        {
            $v = "DISABLED","SSE-KMS"
            break
        }

        # Amazon.Glue.CloudWatchEncryptionMode
        "New-GLUESecurityConfiguration/EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode"
        {
            $v = "DISABLED","SSE-KMS"
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

        # Amazon.Glue.ExistCondition
        "Set-GLUEResourcePolicy/PolicyExistsCondition"
        {
            $v = "MUST_EXIST","NONE","NOT_EXIST"
            break
        }

        # Amazon.Glue.JobBookmarksEncryptionMode
        "New-GLUESecurityConfiguration/EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode"
        {
            $v = "CSE-KMS","DISABLED"
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
            $v = "CONDITIONAL","ON_DEMAND","SCHEDULED"
            break
        }

        # Amazon.Glue.WorkerType
        {
            ($_ -eq "New-GLUEDevEndpoint/WorkerType") -Or
            ($_ -eq "New-GLUEJob/WorkerType") -Or
            ($_ -eq "New-GLUEMLTransform/WorkerType") -Or
            ($_ -eq "Start-GLUEJobRun/WorkerType") -Or
            ($_ -eq "Update-GLUEMLTransform/WorkerType")
        }
        {
            $v = "G.1X","G.2X","Standard"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GLUE_map = @{
    "CsvClassifier_ContainsHeader"=@("New-GLUEClassifier","Update-GLUEClassifier")
    "DataCatalogEncryptionSettings_EncryptionAtRest_CatalogEncryptionMode"=@("Set-GLUEDataCatalogEncryptionSetting")
    "EncryptionConfiguration_CloudWatchEncryption_CloudWatchEncryptionMode"=@("New-GLUESecurityConfiguration")
    "EncryptionConfiguration_JobBookmarksEncryption_JobBookmarksEncryptionMode"=@("New-GLUESecurityConfiguration")
    "Filter_Status"=@("Get-GLUEMLTaskRunList","Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "Filter_TaskRunType"=@("Get-GLUEMLTaskRunList")
    "Filter_TransformType"=@("Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "Language"=@("Get-GLUEPlan","New-GLUEScript")
    "Parameters_TransformType"=@("New-GLUEMLTransform","Update-GLUEMLTransform")
    "PolicyExistsCondition"=@("Set-GLUEResourcePolicy")
    "Sort_Column"=@("Get-GLUEMLTaskRunList","Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "Sort_SortDirection"=@("Get-GLUEMLTaskRunList","Get-GLUEMLTransformIdentifier","Get-GLUEMLTransformList")
    "Type"=@("New-GLUETrigger")
    "WorkerType"=@("New-GLUEDevEndpoint","New-GLUEJob","New-GLUEMLTransform","Start-GLUEJobRun","Update-GLUEMLTransform")
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
               "Get-GLUECrawlerBatch",
               "Get-GLUEDevEndpointBatch",
               "Get-GLUEJobBatch",
               "Get-GLUEPartitionBatch",
               "Get-GLUETriggerBatch",
               "Get-GLUEWorkflowBatch",
               "Stop-GLUEJobRunBatch",
               "Stop-GLUEMLTaskRun",
               "New-GLUEClassifier",
               "New-GLUEConnection",
               "New-GLUECrawler",
               "New-GLUEDatabase",
               "New-GLUEDevEndpoint",
               "New-GLUEJob",
               "New-GLUEMLTransform",
               "New-GLUEPartition",
               "New-GLUEScript",
               "New-GLUESecurityConfiguration",
               "New-GLUETable",
               "New-GLUETrigger",
               "New-GLUEUserDefinedFunction",
               "New-GLUEWorkflow",
               "Remove-GLUEClassifier",
               "Remove-GLUEConnection",
               "Remove-GLUECrawler",
               "Remove-GLUEDatabase",
               "Remove-GLUEDevEndpoint",
               "Remove-GLUEJob",
               "Remove-GLUEMLTransform",
               "Remove-GLUEPartition",
               "Remove-GLUEResourcePolicy",
               "Remove-GLUESecurityConfiguration",
               "Remove-GLUETable",
               "Remove-GLUETableVersion",
               "Remove-GLUETrigger",
               "Remove-GLUEUserDefinedFunction",
               "Remove-GLUEWorkflow",
               "Get-GLUECatalogImportStatus",
               "Get-GLUEClassifier",
               "Get-GLUEClassifierList",
               "Get-GLUEConnection",
               "Get-GLUEConnectionList",
               "Get-GLUECrawler",
               "Get-GLUECrawlerMetricList",
               "Get-GLUECrawlerList",
               "Get-GLUEDatabase",
               "Get-GLUEDatabaseList",
               "Get-GLUEDataCatalogEncryptionSetting",
               "Get-GLUEDataflowGraph",
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
               "Get-GLUEPartitionList",
               "Get-GLUEPlan",
               "Get-GLUEResourcePolicy",
               "Get-GLUESecurityConfiguration",
               "Get-GLUESecurityConfigurationList",
               "Get-GLUETable",
               "Get-GLUETableList",
               "Get-GLUETableVersion",
               "Get-GLUETableVersionList",
               "Get-GLUETag",
               "Get-GLUETrigger",
               "Get-GLUETriggerList",
               "Get-GLUEUserDefinedFunction",
               "Get-GLUEUserDefinedFunctionList",
               "Get-GLUEWorkflow",
               "Get-GLUEWorkflowRun",
               "Get-GLUEWorkflowRunProperty",
               "Get-GLUEWorkflowRunList",
               "Import-GLUECatalog",
               "Get-GLUECrawlerNameList",
               "Get-GLUEDevEndpointNameList",
               "Get-GLUEJobNameList",
               "Get-GLUEMLTransformIdentifier",
               "Get-GLUETriggerNameList",
               "Get-GLUEWorkflowList",
               "Set-GLUEDataCatalogEncryptionSetting",
               "Set-GLUEResourcePolicy",
               "Write-GLUEWorkflowRunProperty",
               "Reset-GLUEJobBookmark",
               "Find-GLUETable",
               "Start-GLUECrawler",
               "Start-GLUECrawlerSchedule",
               "Start-GLUEExportLabelsTaskRun",
               "Start-GLUEImportLabelsTaskRun",
               "Start-GLUEJobRun",
               "Start-GLUEMLEvaluationTaskRun",
               "Start-GLUEMLLabelingSetGenerationTaskRun",
               "Start-GLUETrigger",
               "Start-GLUEWorkflowRun",
               "Stop-GLUECrawler",
               "Stop-GLUECrawlerSchedule",
               "Stop-GLUETrigger",
               "Add-GLUEResourceTag",
               "Remove-GLUEResourceTag",
               "Update-GLUEClassifier",
               "Update-GLUEConnection",
               "Update-GLUECrawler",
               "Update-GLUECrawlerSchedule",
               "Update-GLUEDatabase",
               "Update-GLUEDevEndpoint",
               "Update-GLUEJob",
               "Update-GLUEMLTransform",
               "Update-GLUEPartition",
               "Update-GLUETable",
               "Update-GLUETrigger",
               "Update-GLUEUserDefinedFunction",
               "Update-GLUEWorkflow")
}

_awsArgumentCompleterRegistration $GLUE_SelectCompleters $GLUE_SelectMap

