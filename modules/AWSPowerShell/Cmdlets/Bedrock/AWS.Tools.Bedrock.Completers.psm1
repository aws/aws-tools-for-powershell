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

# Argument completions for service Amazon Bedrock


$BDR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Bedrock.ApplicationType
        {
            ($_ -eq "New-BDREvaluationJob/ApplicationType") -Or
            ($_ -eq "Get-BDREvaluationJobList/ApplicationTypeEqual")
        }
        {
            $v = "ModelEvaluation","RagEvaluation"
            break
        }

        # Amazon.Bedrock.CommitmentDuration
        "New-BDRProvisionedModelThroughput/CommitmentDuration"
        {
            $v = "OneMonth","SixMonths"
            break
        }

        # Amazon.Bedrock.CustomizationType
        "New-BDRModelCustomizationJob/CustomizationType"
        {
            $v = "CONTINUED_PRE_TRAINING","DISTILLATION","FINE_TUNING"
            break
        }

        # Amazon.Bedrock.EvaluationJobStatus
        "Get-BDREvaluationJobList/StatusEqual"
        {
            $v = "Completed","Deleting","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.Bedrock.FineTuningJobStatus
        "Get-BDRModelCustomizationJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.Bedrock.InferenceProfileType
        "Get-BDRInferenceProfileList/TypeEqual"
        {
            $v = "APPLICATION","SYSTEM_DEFINED"
            break
        }

        # Amazon.Bedrock.InferenceType
        "Get-BDRFoundationModelList/ByInferenceType"
        {
            $v = "ON_DEMAND","PROVISIONED"
            break
        }

        # Amazon.Bedrock.ModelCopyJobStatus
        "Get-BDRModelCopyJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress"
            break
        }

        # Amazon.Bedrock.ModelCustomization
        "Get-BDRFoundationModelList/ByCustomizationType"
        {
            $v = "CONTINUED_PRE_TRAINING","DISTILLATION","FINE_TUNING"
            break
        }

        # Amazon.Bedrock.ModelImportJobStatus
        "Get-BDRModelImportJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress"
            break
        }

        # Amazon.Bedrock.ModelInvocationJobStatus
        "Get-BDRModelInvocationJobList/StatusEqual"
        {
            $v = "Completed","Expired","Failed","InProgress","PartiallyCompleted","Scheduled","Stopped","Stopping","Submitted","Validating"
            break
        }

        # Amazon.Bedrock.ModelModality
        "Get-BDRFoundationModelList/ByOutputModality"
        {
            $v = "EMBEDDING","IMAGE","TEXT"
            break
        }

        # Amazon.Bedrock.PromptRouterType
        "Get-BDRPromptRouterList/Type"
        {
            $v = "custom","default"
            break
        }

        # Amazon.Bedrock.ProvisionedModelStatus
        "Get-BDRProvisionedModelThroughputList/StatusEqual"
        {
            $v = "Creating","Failed","InService","Updating"
            break
        }

        # Amazon.Bedrock.S3InputFormat
        "New-BDRModelInvocationJob/S3InputDataConfig_S3InputFormat"
        {
            $v = "JSONL"
            break
        }

        # Amazon.Bedrock.SortByProvisionedModels
        "Get-BDRProvisionedModelThroughputList/SortBy"
        {
            $v = "CreationTime"
            break
        }

        # Amazon.Bedrock.SortJobsBy
        {
            ($_ -eq "Get-BDREvaluationJobList/SortBy") -Or
            ($_ -eq "Get-BDRModelCopyJobList/SortBy") -Or
            ($_ -eq "Get-BDRModelCustomizationJobList/SortBy") -Or
            ($_ -eq "Get-BDRModelImportJobList/SortBy") -Or
            ($_ -eq "Get-BDRModelInvocationJobList/SortBy")
        }
        {
            $v = "CreationTime"
            break
        }

        # Amazon.Bedrock.SortModelsBy
        {
            ($_ -eq "Get-BDRCustomModelList/SortBy") -Or
            ($_ -eq "Get-BDRImportedModelList/SortBy")
        }
        {
            $v = "CreationTime"
            break
        }

        # Amazon.Bedrock.SortOrder
        {
            ($_ -eq "Get-BDRCustomModelList/SortOrder") -Or
            ($_ -eq "Get-BDREvaluationJobList/SortOrder") -Or
            ($_ -eq "Get-BDRImportedModelList/SortOrder") -Or
            ($_ -eq "Get-BDRModelCopyJobList/SortOrder") -Or
            ($_ -eq "Get-BDRModelCustomizationJobList/SortOrder") -Or
            ($_ -eq "Get-BDRModelImportJobList/SortOrder") -Or
            ($_ -eq "Get-BDRModelInvocationJobList/SortOrder") -Or
            ($_ -eq "Get-BDRProvisionedModelThroughputList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BDR_map = @{
    "ApplicationType"=@("New-BDREvaluationJob")
    "ApplicationTypeEqual"=@("Get-BDREvaluationJobList")
    "ByCustomizationType"=@("Get-BDRFoundationModelList")
    "ByInferenceType"=@("Get-BDRFoundationModelList")
    "ByOutputModality"=@("Get-BDRFoundationModelList")
    "CommitmentDuration"=@("New-BDRProvisionedModelThroughput")
    "CustomizationType"=@("New-BDRModelCustomizationJob")
    "S3InputDataConfig_S3InputFormat"=@("New-BDRModelInvocationJob")
    "SortBy"=@("Get-BDRCustomModelList","Get-BDREvaluationJobList","Get-BDRImportedModelList","Get-BDRModelCopyJobList","Get-BDRModelCustomizationJobList","Get-BDRModelImportJobList","Get-BDRModelInvocationJobList","Get-BDRProvisionedModelThroughputList")
    "SortOrder"=@("Get-BDRCustomModelList","Get-BDREvaluationJobList","Get-BDRImportedModelList","Get-BDRModelCopyJobList","Get-BDRModelCustomizationJobList","Get-BDRModelImportJobList","Get-BDRModelInvocationJobList","Get-BDRProvisionedModelThroughputList")
    "StatusEqual"=@("Get-BDREvaluationJobList","Get-BDRModelCopyJobList","Get-BDRModelCustomizationJobList","Get-BDRModelImportJobList","Get-BDRModelInvocationJobList","Get-BDRProvisionedModelThroughputList")
    "Type"=@("Get-BDRPromptRouterList")
    "TypeEqual"=@("Get-BDRInferenceProfileList")
}

_awsArgumentCompleterRegistration $BDR_Completers $BDR_map

$BDR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BDR.$($commandName.Replace('-', ''))Cmdlet]"
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

$BDR_SelectMap = @{
    "Select"=@("Set-BDRBatchDeleteEvaluationJob",
               "New-BDREvaluationJob",
               "New-BDRGuardrail",
               "New-BDRGuardrailVersion",
               "New-BDRInferenceProfile",
               "New-BDRMarketplaceModelEndpoint",
               "New-BDRModelCopyJob",
               "New-BDRModelCustomizationJob",
               "New-BDRModelImportJob",
               "New-BDRModelInvocationJob",
               "New-BDRPromptRouter",
               "New-BDRProvisionedModelThroughput",
               "Remove-BDRCustomModel",
               "Remove-BDRGuardrail",
               "Remove-BDRImportedModel",
               "Remove-BDRInferenceProfile",
               "Remove-BDRMarketplaceModelEndpoint",
               "Remove-BDRModelInvocationLoggingConfiguration",
               "Remove-BDRPromptRouter",
               "Remove-BDRProvisionedModelThroughput",
               "Unregister-BDRMarketplaceModelEndpoint",
               "Get-BDRCustomModel",
               "Get-BDREvaluationJob",
               "Get-BDRFoundationModel",
               "Get-BDRGuardrail",
               "Get-BDRImportedModel",
               "Get-BDRInferenceProfile",
               "Get-BDRMarketplaceModelEndpoint",
               "Get-BDRModelCopyJob",
               "Get-BDRModelCustomizationJob",
               "Get-BDRModelImportJob",
               "Get-BDRModelInvocationJob",
               "Get-BDRModelInvocationLoggingConfiguration",
               "Get-BDRPromptRouter",
               "Get-BDRProvisionedModelThroughput",
               "Get-BDRCustomModelList",
               "Get-BDREvaluationJobList",
               "Get-BDRFoundationModelList",
               "Get-BDRGuardrailList",
               "Get-BDRImportedModelList",
               "Get-BDRInferenceProfileList",
               "Get-BDRMarketplaceModelEndpointList",
               "Get-BDRModelCopyJobList",
               "Get-BDRModelCustomizationJobList",
               "Get-BDRModelImportJobList",
               "Get-BDRModelInvocationJobList",
               "Get-BDRPromptRouterList",
               "Get-BDRProvisionedModelThroughputList",
               "Get-BDRResourceTag",
               "Write-BDRModelInvocationLoggingConfiguration",
               "Register-BDRMarketplaceModelEndpoint",
               "Stop-BDREvaluationJob",
               "Stop-BDRModelCustomizationJob",
               "Stop-BDRModelInvocationJob",
               "Add-BDRResourceTag",
               "Remove-BDRResourceTag",
               "Update-BDRGuardrail",
               "Update-BDRMarketplaceModelEndpoint",
               "Update-BDRProvisionedModelThroughput")
}

_awsArgumentCompleterRegistration $BDR_SelectCompleters $BDR_SelectMap

