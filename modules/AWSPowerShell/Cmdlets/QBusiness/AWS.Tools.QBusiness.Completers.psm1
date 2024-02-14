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

# Argument completions for service Amazon QBusiness


$QBUS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.QBusiness.AttachmentsControlMode
        {
            ($_ -eq "New-QBUSApplication/AttachmentsConfiguration_AttachmentsControlMode") -Or
            ($_ -eq "Update-QBUSApplication/AttachmentsConfiguration_AttachmentsControlMode")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QBusiness.DataSourceSyncJobStatus
        "Get-QBUSDataSourceSyncJobList/StatusFilter"
        {
            $v = "ABORTED","FAILED","INCOMPLETE","STOPPING","SUCCEEDED","SYNCING","SYNCING_INDEXING"
            break
        }

        # Amazon.QBusiness.DocumentEnrichmentConditionOperator
        {
            ($_ -eq "New-QBUSDataSource/DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "Update-QBUSDataSource/DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "New-QBUSDataSource/DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator") -Or
            ($_ -eq "Update-QBUSDataSource/DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator")
        }
        {
            $v = "BEGINS_WITH","CONTAINS","EQUALS","EXISTS","GREATER_THAN","GREATER_THAN_OR_EQUALS","LESS_THAN","LESS_THAN_OR_EQUALS","NOT_CONTAINS","NOT_EQUALS","NOT_EXISTS"
            break
        }

        # Amazon.QBusiness.MembershipType
        "Write-QBUSGroup/Type"
        {
            $v = "DATASOURCE","INDEX"
            break
        }

        # Amazon.QBusiness.MessageUsefulness
        "Write-QBUSFeedback/MessageUsefulness_Usefulness"
        {
            $v = "NOT_USEFUL","USEFUL"
            break
        }

        # Amazon.QBusiness.MessageUsefulnessReason
        "Write-QBUSFeedback/MessageUsefulness_Reason"
        {
            $v = "COMPLETE","FACTUALLY_CORRECT","HARMFUL_OR_UNSAFE","HELPFUL","INCORRECT_OR_MISSING_SOURCES","NOT_BASED_ON_DOCUMENTS","NOT_COMPLETE","NOT_CONCISE","NOT_FACTUALLY_CORRECT","NOT_HELPFUL","OTHER","RELEVANT_SOURCES"
            break
        }

        # Amazon.QBusiness.PluginState
        "Update-QBUSPlugin/State"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QBusiness.PluginType
        "New-QBUSPlugin/Type"
        {
            $v = "JIRA","SALESFORCE","SERVICE_NOW","ZENDESK"
            break
        }

        # Amazon.QBusiness.ResponseScope
        "Update-QBUSChatControlsConfiguration/ResponseScope"
        {
            $v = "ENTERPRISE_CONTENT_ONLY","EXTENDED_KNOWLEDGE_ENABLED"
            break
        }

        # Amazon.QBusiness.RetrieverType
        "New-QBUSRetriever/Type"
        {
            $v = "KENDRA_INDEX","NATIVE_INDEX"
            break
        }

        # Amazon.QBusiness.WebExperienceSamplePromptsControlMode
        {
            ($_ -eq "New-QBUSWebExperience/SamplePromptsControlMode") -Or
            ($_ -eq "Update-QBUSWebExperience/SamplePromptsControlMode")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$QBUS_map = @{
    "AttachmentsConfiguration_AttachmentsControlMode"=@("New-QBUSApplication","Update-QBUSApplication")
    "DocumentEnrichmentConfiguration_PostExtractionHookConfiguration_InvocationCondition_Operator"=@("New-QBUSDataSource","Update-QBUSDataSource")
    "DocumentEnrichmentConfiguration_PreExtractionHookConfiguration_InvocationCondition_Operator"=@("New-QBUSDataSource","Update-QBUSDataSource")
    "MessageUsefulness_Reason"=@("Write-QBUSFeedback")
    "MessageUsefulness_Usefulness"=@("Write-QBUSFeedback")
    "ResponseScope"=@("Update-QBUSChatControlsConfiguration")
    "SamplePromptsControlMode"=@("New-QBUSWebExperience","Update-QBUSWebExperience")
    "State"=@("Update-QBUSPlugin")
    "StatusFilter"=@("Get-QBUSDataSourceSyncJobList")
    "Type"=@("New-QBUSPlugin","New-QBUSRetriever","Write-QBUSGroup")
}

_awsArgumentCompleterRegistration $QBUS_Completers $QBUS_map

$QBUS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.QBUS.$($commandName.Replace('-', ''))Cmdlet]"
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

$QBUS_SelectMap = @{
    "Select"=@("Remove-QBUSBatchDeleteDocument",
               "Set-QBUSBatchPutDocument",
               "Set-QBUSChatSync",
               "New-QBUSApplication",
               "New-QBUSDataSource",
               "New-QBUSIndex",
               "New-QBUSPlugin",
               "New-QBUSRetriever",
               "New-QBUSUser",
               "New-QBUSWebExperience",
               "Remove-QBUSApplication",
               "Remove-QBUSChatControlsConfiguration",
               "Remove-QBUSConversation",
               "Remove-QBUSDataSource",
               "Remove-QBUSGroup",
               "Remove-QBUSIndex",
               "Remove-QBUSPlugin",
               "Remove-QBUSRetriever",
               "Remove-QBUSUser",
               "Remove-QBUSWebExperience",
               "Get-QBUSApplication",
               "Get-QBUSChatControlsConfiguration",
               "Get-QBUSDataSource",
               "Get-QBUSGroup",
               "Get-QBUSIndex",
               "Get-QBUSPlugin",
               "Get-QBUSRetriever",
               "Get-QBUSUser",
               "Get-QBUSWebExperience",
               "Get-QBUSApplicationList",
               "Get-QBUSConversationList",
               "Get-QBUSDataSourceList",
               "Get-QBUSDataSourceSyncJobList",
               "Get-QBUSDocumentList",
               "Get-QBUSGroupList",
               "Get-QBUSIndexList",
               "Get-QBUSMessageList",
               "Get-QBUSPluginList",
               "Get-QBUSRetrieverList",
               "Get-QBUSResourceTag",
               "Get-QBUSWebExperienceList",
               "Write-QBUSFeedback",
               "Write-QBUSGroup",
               "Start-QBUSDataSourceSyncJob",
               "Stop-QBUSDataSourceSyncJob",
               "Add-QBUSResourceTag",
               "Remove-QBUSResourceTag",
               "Update-QBUSApplication",
               "Update-QBUSChatControlsConfiguration",
               "Update-QBUSDataSource",
               "Update-QBUSIndex",
               "Update-QBUSPlugin",
               "Update-QBUSRetriever",
               "Update-QBUSUser",
               "Update-QBUSWebExperience")
}

_awsArgumentCompleterRegistration $QBUS_SelectCompleters $QBUS_SelectMap

