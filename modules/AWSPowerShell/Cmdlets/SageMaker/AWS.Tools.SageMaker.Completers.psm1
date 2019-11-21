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

# Argument completions for service Amazon SageMaker Service


$SM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SageMaker.AlgorithmSortBy
        "Get-SMAlgorithmList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.AssemblyType
        "New-SMTransformJob/TransformOutput_AssembleWith"
        {
            $v = "Line","None"
            break
        }

        # Amazon.SageMaker.BatchStrategy
        "New-SMTransformJob/BatchStrategy"
        {
            $v = "MultiRecord","SingleRecord"
            break
        }

        # Amazon.SageMaker.BooleanOperator
        "Search-SMResource/SearchExpression_Operator"
        {
            $v = "And","Or"
            break
        }

        # Amazon.SageMaker.CodeRepositorySortBy
        "Get-SMCodeRepositoryList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime","Name"
            break
        }

        # Amazon.SageMaker.CodeRepositorySortOrder
        "Get-SMCodeRepositoryList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.CompilationJobStatus
        "Get-SMCompilationJobList/StatusEquals"
        {
            $v = "COMPLETED","FAILED","INPROGRESS","STARTING","STOPPED","STOPPING"
            break
        }

        # Amazon.SageMaker.CompressionType
        "New-SMTransformJob/TransformInput_CompressionType"
        {
            $v = "Gzip","None"
            break
        }

        # Amazon.SageMaker.DirectInternetAccess
        "New-SMNotebookInstance/DirectInternetAccess"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.EndpointConfigSortKey
        "Get-SMConfigList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.EndpointSortKey
        "Get-SMEndpointList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.EndpointStatus
        "Get-SMEndpointList/StatusEquals"
        {
            $v = "Creating","Deleting","Failed","InService","OutOfService","RollingBack","SystemUpdating","Updating"
            break
        }

        # Amazon.SageMaker.Framework
        "New-SMCompilationJob/InputConfig_Framework"
        {
            $v = "MXNET","ONNX","PYTORCH","TENSORFLOW","XGBOOST"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobObjectiveType
        "New-SMHyperParameterTuningJob/HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type"
        {
            $v = "Maximize","Minimize"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobSortByOptions
        "Get-SMHyperParameterTuningJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobStatus
        "Get-SMHyperParameterTuningJobList/StatusEquals"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobStrategyType
        "New-SMHyperParameterTuningJob/HyperParameterTuningJobConfig_Strategy"
        {
            $v = "Bayesian","Random"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobWarmStartType
        "New-SMHyperParameterTuningJob/WarmStartConfig_WarmStartType"
        {
            $v = "IdenticalDataAndAlgorithm","TransferLearning"
            break
        }

        # Amazon.SageMaker.InstanceType
        {
            ($_ -eq "New-SMNotebookInstance/InstanceType") -Or
            ($_ -eq "Update-SMNotebookInstance/InstanceType")
        }
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c5d.18xlarge","ml.c5d.2xlarge","ml.c5d.4xlarge","ml.c5d.9xlarge","ml.c5d.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.t2.2xlarge","ml.t2.large","ml.t2.medium","ml.t2.xlarge","ml.t3.2xlarge","ml.t3.large","ml.t3.medium","ml.t3.xlarge"
            break
        }

        # Amazon.SageMaker.JoinSource
        "New-SMTransformJob/DataProcessing_JoinSource"
        {
            $v = "Input","None"
            break
        }

        # Amazon.SageMaker.LabelingJobStatus
        "Get-SMLabelingJobList/StatusEquals"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.ListCompilationJobsSortBy
        "Get-SMCompilationJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.ListLabelingJobsForWorkteamSortByOptions
        "Get-SMLabelingJobListForWorkteam/SortBy"
        {
            $v = "CreationTime"
            break
        }

        # Amazon.SageMaker.ListWorkteamsSortByOptions
        "Get-SMWorkteamList/SortBy"
        {
            $v = "CreateDate","Name"
            break
        }

        # Amazon.SageMaker.ModelPackageSortBy
        "Get-SMModelPackageList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.ModelSortKey
        "Get-SMModelList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.NotebookInstanceLifecycleConfigSortKey
        "Get-SMNotebookInstanceLifecycleConfigList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime","Name"
            break
        }

        # Amazon.SageMaker.NotebookInstanceLifecycleConfigSortOrder
        "Get-SMNotebookInstanceLifecycleConfigList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.NotebookInstanceSortKey
        "Get-SMNotebookInstanceList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.NotebookInstanceSortOrder
        "Get-SMNotebookInstanceList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.NotebookInstanceStatus
        "Get-SMNotebookInstanceList/StatusEquals"
        {
            $v = "Deleting","Failed","InService","Pending","Stopped","Stopping","Updating"
            break
        }

        # Amazon.SageMaker.OrderKey
        {
            ($_ -eq "Get-SMConfigList/SortOrder") -Or
            ($_ -eq "Get-SMEndpointList/SortOrder") -Or
            ($_ -eq "Get-SMModelList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.ResourceType
        {
            ($_ -eq "Get-SMSearchSuggestion/Resource") -Or
            ($_ -eq "Search-SMResource/Resource")
        }
        {
            $v = "TrainingJob"
            break
        }

        # Amazon.SageMaker.RootAccess
        {
            ($_ -eq "New-SMNotebookInstance/RootAccess") -Or
            ($_ -eq "Update-SMNotebookInstance/RootAccess")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.S3DataType
        "New-SMTransformJob/TransformInput_DataSource_S3DataSource_S3DataType"
        {
            $v = "AugmentedManifestFile","ManifestFile","S3Prefix"
            break
        }

        # Amazon.SageMaker.SearchSortOrder
        "Search-SMResource/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.SortBy
        {
            ($_ -eq "Get-SMLabelingJobList/SortBy") -Or
            ($_ -eq "Get-SMTrainingJobList/SortBy") -Or
            ($_ -eq "Get-SMTransformJobList/SortBy")
        }
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.SortOrder
        {
            ($_ -eq "Get-SMAlgorithmList/SortOrder") -Or
            ($_ -eq "Get-SMCompilationJobList/SortOrder") -Or
            ($_ -eq "Get-SMHyperParameterTuningJobList/SortOrder") -Or
            ($_ -eq "Get-SMLabelingJobList/SortOrder") -Or
            ($_ -eq "Get-SMLabelingJobListForWorkteam/SortOrder") -Or
            ($_ -eq "Get-SMModelPackageList/SortOrder") -Or
            ($_ -eq "Get-SMTrainingJobList/SortOrder") -Or
            ($_ -eq "Get-SMTrainingJobsForHyperParameterTuningJobList/SortOrder") -Or
            ($_ -eq "Get-SMTransformJobList/SortOrder") -Or
            ($_ -eq "Get-SMWorkteamList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.SplitType
        "New-SMTransformJob/TransformInput_SplitType"
        {
            $v = "Line","None","RecordIO","TFRecord"
            break
        }

        # Amazon.SageMaker.TargetDevice
        "New-SMCompilationJob/OutputConfig_TargetDevice"
        {
            $v = "aisage","deeplens","jetson_nano","jetson_tx1","jetson_tx2","lambda","ml_c4","ml_c5","ml_m4","ml_m5","ml_p2","ml_p3","qcs603","qcs605","rasp3b","rk3288","rk3399","sbe_c"
            break
        }

        # Amazon.SageMaker.TrainingInputMode
        "New-SMHyperParameterTuningJob/TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode"
        {
            $v = "File","Pipe"
            break
        }

        # Amazon.SageMaker.TrainingJobEarlyStoppingType
        "New-SMHyperParameterTuningJob/HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType"
        {
            $v = "Auto","Off"
            break
        }

        # Amazon.SageMaker.TrainingJobSortByOptions
        "Get-SMTrainingJobsForHyperParameterTuningJobList/SortBy"
        {
            $v = "CreationTime","FinalObjectiveMetricValue","Name","Status"
            break
        }

        # Amazon.SageMaker.TrainingJobStatus
        {
            ($_ -eq "Get-SMTrainingJobList/StatusEquals") -Or
            ($_ -eq "Get-SMTrainingJobsForHyperParameterTuningJobList/StatusEquals")
        }
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.TransformInstanceType
        "New-SMTransformJob/TransformResources_InstanceType"
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge"
            break
        }

        # Amazon.SageMaker.TransformJobStatus
        "Get-SMTransformJobList/StatusEquals"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SM_map = @{
    "BatchStrategy"=@("New-SMTransformJob")
    "DataProcessing_JoinSource"=@("New-SMTransformJob")
    "DirectInternetAccess"=@("New-SMNotebookInstance")
    "HyperParameterTuningJobConfig_HyperParameterTuningJobObjective_Type"=@("New-SMHyperParameterTuningJob")
    "HyperParameterTuningJobConfig_Strategy"=@("New-SMHyperParameterTuningJob")
    "HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType"=@("New-SMHyperParameterTuningJob")
    "InputConfig_Framework"=@("New-SMCompilationJob")
    "InstanceType"=@("New-SMNotebookInstance","Update-SMNotebookInstance")
    "OutputConfig_TargetDevice"=@("New-SMCompilationJob")
    "Resource"=@("Get-SMSearchSuggestion","Search-SMResource")
    "RootAccess"=@("New-SMNotebookInstance","Update-SMNotebookInstance")
    "SearchExpression_Operator"=@("Search-SMResource")
    "SortBy"=@("Get-SMAlgorithmList","Get-SMCodeRepositoryList","Get-SMCompilationJobList","Get-SMConfigList","Get-SMEndpointList","Get-SMHyperParameterTuningJobList","Get-SMLabelingJobList","Get-SMLabelingJobListForWorkteam","Get-SMModelList","Get-SMModelPackageList","Get-SMNotebookInstanceLifecycleConfigList","Get-SMNotebookInstanceList","Get-SMTrainingJobList","Get-SMTrainingJobsForHyperParameterTuningJobList","Get-SMTransformJobList","Get-SMWorkteamList")
    "SortOrder"=@("Get-SMAlgorithmList","Get-SMCodeRepositoryList","Get-SMCompilationJobList","Get-SMConfigList","Get-SMEndpointList","Get-SMHyperParameterTuningJobList","Get-SMLabelingJobList","Get-SMLabelingJobListForWorkteam","Get-SMModelList","Get-SMModelPackageList","Get-SMNotebookInstanceLifecycleConfigList","Get-SMNotebookInstanceList","Get-SMTrainingJobList","Get-SMTrainingJobsForHyperParameterTuningJobList","Get-SMTransformJobList","Get-SMWorkteamList","Search-SMResource")
    "StatusEquals"=@("Get-SMCompilationJobList","Get-SMEndpointList","Get-SMHyperParameterTuningJobList","Get-SMLabelingJobList","Get-SMNotebookInstanceList","Get-SMTrainingJobList","Get-SMTrainingJobsForHyperParameterTuningJobList","Get-SMTransformJobList")
    "TrainingJobDefinition_AlgorithmSpecification_TrainingInputMode"=@("New-SMHyperParameterTuningJob")
    "TransformInput_CompressionType"=@("New-SMTransformJob")
    "TransformInput_DataSource_S3DataSource_S3DataType"=@("New-SMTransformJob")
    "TransformInput_SplitType"=@("New-SMTransformJob")
    "TransformOutput_AssembleWith"=@("New-SMTransformJob")
    "TransformResources_InstanceType"=@("New-SMTransformJob")
    "WarmStartConfig_WarmStartType"=@("New-SMHyperParameterTuningJob")
}

_awsArgumentCompleterRegistration $SM_Completers $SM_map

$SM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SM.$($commandName.Replace('-', ''))Cmdlet]"
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

$SM_SelectMap = @{
    "Select"=@("Add-SMResourceTag",
               "New-SMAlgorithm",
               "New-SMCodeRepository",
               "New-SMCompilationJob",
               "New-SMEndpoint",
               "New-SMEndpointConfig",
               "New-SMHyperParameterTuningJob",
               "New-SMLabelingJob",
               "New-SMModel",
               "New-SMModelPackage",
               "New-SMNotebookInstance",
               "New-SMNotebookInstanceLifecycleConfig",
               "New-SMPresignedNotebookInstanceUrl",
               "New-SMTrainingJob",
               "New-SMTransformJob",
               "New-SMWorkteam",
               "Remove-SMAlgorithm",
               "Remove-SMCodeRepository",
               "Remove-SMEndpoint",
               "Remove-SMEndpointConfig",
               "Remove-SMModel",
               "Remove-SMModelPackage",
               "Remove-SMNotebookInstance",
               "Remove-SMNotebookInstanceLifecycleConfig",
               "Remove-SMResourceTag",
               "Remove-SMWorkteam",
               "Get-SMAlgorithm",
               "Get-SMCodeRepository",
               "Get-SMCompilationJob",
               "Get-SMEndpoint",
               "Get-SMEndpointConfig",
               "Get-SMHyperParameterTuningJob",
               "Get-SMLabelingJob",
               "Get-SMModel",
               "Get-SMModelPackage",
               "Get-SMNotebookInstance",
               "Get-SMNotebookInstanceLifecycleConfig",
               "Get-SMSubscribedWorkteam",
               "Get-SMTrainingJob",
               "Get-SMTransformJob",
               "Get-SMWorkteam",
               "Get-SMSearchSuggestion",
               "Get-SMAlgorithmList",
               "Get-SMCodeRepositoryList",
               "Get-SMCompilationJobList",
               "Get-SMConfigList",
               "Get-SMEndpointList",
               "Get-SMHyperParameterTuningJobList",
               "Get-SMLabelingJobList",
               "Get-SMLabelingJobListForWorkteam",
               "Get-SMModelPackageList",
               "Get-SMModelList",
               "Get-SMNotebookInstanceLifecycleConfigList",
               "Get-SMNotebookInstanceList",
               "Get-SMSubscribedWorkteamList",
               "Get-SMResourceTagList",
               "Get-SMTrainingJobList",
               "Get-SMTrainingJobsForHyperParameterTuningJobList",
               "Get-SMTransformJobList",
               "Get-SMWorkteamList",
               "Invoke-SMUiTemplateRendering",
               "Search-SMResource",
               "Start-SMNotebookInstance",
               "Stop-SMCompilationJob",
               "Stop-SMHyperParameterTuningJob",
               "Stop-SMLabelingJob",
               "Stop-SMNotebookInstance",
               "Stop-SMTrainingJob",
               "Stop-SMTransformJob",
               "Update-SMCodeRepository",
               "Update-SMEndpoint",
               "Update-SMEndpointWeightAndCapacity",
               "Update-SMNotebookInstance",
               "Update-SMNotebookInstanceLifecycleConfig",
               "Update-SMWorkteam")
}

_awsArgumentCompleterRegistration $SM_SelectCompleters $SM_SelectMap

