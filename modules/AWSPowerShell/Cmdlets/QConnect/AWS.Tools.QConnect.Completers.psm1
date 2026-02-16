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

# Argument completions for service Amazon Q Connect


$QC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.QConnect.AIAgentType
        {
            ($_ -eq "Remove-QCAssistantAIAgent/AiAgentType") -Or
            ($_ -eq "Update-QCAssistantAIAgent/AiAgentType") -Or
            ($_ -eq "New-QCAIAgent/Type")
        }
        {
            $v = "ANSWER_RECOMMENDATION","CASE_SUMMARIZATION","EMAIL_GENERATIVE_ANSWER","EMAIL_OVERVIEW","EMAIL_RESPONSE","MANUAL_SEARCH","NOTE_TAKING","ORCHESTRATION","SELF_SERVICE"
            break
        }

        # Amazon.QConnect.AIPromptAPIFormat
        "New-QCAIPrompt/ApiFormat"
        {
            $v = "ANTHROPIC_CLAUDE_MESSAGES","ANTHROPIC_CLAUDE_TEXT_COMPLETIONS","MESSAGES","TEXT_COMPLETIONS"
            break
        }

        # Amazon.QConnect.AIPromptTemplateType
        "New-QCAIPrompt/TemplateType"
        {
            $v = "TEXT"
            break
        }

        # Amazon.QConnect.AIPromptType
        "New-QCAIPrompt/Type"
        {
            $v = "ANSWER_GENERATION","CASE_SUMMARIZATION","EMAIL_GENERATIVE_ANSWER","EMAIL_OVERVIEW","EMAIL_QUERY_REFORMULATION","EMAIL_RESPONSE","INTENT_LABELING_GENERATION","NOTE_TAKING","ORCHESTRATION","QUERY_REFORMULATION","SELF_SERVICE_ANSWER_GENERATION","SELF_SERVICE_PRE_PROCESSING"
            break
        }

        # Amazon.QConnect.AssistantType
        "New-QCAssistant/Type"
        {
            $v = "AGENT"
            break
        }

        # Amazon.QConnect.AssociationType
        "New-QCAssistantAssociation/AssociationType"
        {
            $v = "EXTERNAL_BEDROCK_KNOWLEDGE_BASE","KNOWLEDGE_BASE"
            break
        }

        # Amazon.QConnect.ChannelSubtype
        "New-QCMessageTemplate/ChannelSubtype"
        {
            $v = "EMAIL","PUSH","SMS","WHATSAPP"
            break
        }

        # Amazon.QConnect.ChunkingStrategy
        "New-QCKnowledgeBase/ChunkingConfiguration_ChunkingStrategy"
        {
            $v = "FIXED_SIZE","HIERARCHICAL","NONE","SEMANTIC"
            break
        }

        # Amazon.QConnect.ContentAssociationType
        "New-QCContentAssociation/AssociationType"
        {
            $v = "AMAZON_CONNECT_GUIDE"
            break
        }

        # Amazon.QConnect.ContentDisposition
        "New-QCMessageTemplateAttachment/ContentDisposition"
        {
            $v = "ATTACHMENT"
            break
        }

        # Amazon.QConnect.ExternalSource
        "Start-QCImportJob/ExternalSourceConfiguration_Source"
        {
            $v = "AMAZON_CONNECT"
            break
        }

        # Amazon.QConnect.ImportJobType
        "Start-QCImportJob/ImportJobType"
        {
            $v = "QUICK_RESPONSES"
            break
        }

        # Amazon.QConnect.KnowledgeBaseSearchType
        {
            ($_ -eq "Search-QCAssistant/OverrideKnowledgeBaseSearchType") -Or
            ($_ -eq "Invoke-QCRetrieve/RetrievalConfiguration_OverrideKnowledgeBaseSearchType")
        }
        {
            $v = "HYBRID","SEMANTIC"
            break
        }

        # Amazon.QConnect.KnowledgeBaseType
        "New-QCKnowledgeBase/KnowledgeBaseType"
        {
            $v = "CUSTOM","EXTERNAL","MANAGED","MESSAGE_TEMPLATES","QUICK_RESPONSES"
            break
        }

        # Amazon.QConnect.MessageFilterType
        "Get-QCMessageList/Filter"
        {
            $v = "ALL","TEXT_ONLY"
            break
        }

        # Amazon.QConnect.MessageType
        "Send-QCMessage/Type"
        {
            $v = "TEXT","TOOL_USE_RESULT"
            break
        }

        # Amazon.QConnect.Order
        {
            ($_ -eq "Search-QCMessageTemplate/OrderOnField_Order") -Or
            ($_ -eq "Search-QCQuickResponse/OrderOnField_Order")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.QConnect.Origin
        {
            ($_ -eq "Get-QCAIAgentList/Origin") -Or
            ($_ -eq "Get-QCAIAgentVersionList/Origin") -Or
            ($_ -eq "Get-QCAIPromptList/Origin") -Or
            ($_ -eq "Get-QCAIPromptVersionList/Origin")
        }
        {
            $v = "CUSTOMER","SYSTEM"
            break
        }

        # Amazon.QConnect.ParsingStrategy
        "New-QCKnowledgeBase/ParsingConfiguration_ParsingStrategy"
        {
            $v = "BEDROCK_FOUNDATION_MODEL"
            break
        }

        # Amazon.QConnect.PushMessageAction
        {
            ($_ -eq "New-QCMessageTemplate/Adm_Action") -Or
            ($_ -eq "Update-QCMessageTemplate/Adm_Action") -Or
            ($_ -eq "New-QCMessageTemplate/Apns_Action") -Or
            ($_ -eq "Update-QCMessageTemplate/Apns_Action") -Or
            ($_ -eq "New-QCMessageTemplate/Baidu_Action") -Or
            ($_ -eq "Update-QCMessageTemplate/Baidu_Action") -Or
            ($_ -eq "New-QCMessageTemplate/Fcm_Action") -Or
            ($_ -eq "Update-QCMessageTemplate/Fcm_Action")
        }
        {
            $v = "DEEP_LINK","OPEN_APP","URL"
            break
        }

        # Amazon.QConnect.RecommendationType
        "Get-QCRecommendation/RecommendationType"
        {
            $v = "BLOCKED_CASE_SUMMARIZATION_CHUNK","BLOCKED_GENERATIVE_ANSWER_CHUNK","BLOCKED_INTENT_ANSWER_CHUNK","BLOCKED_NOTES_CHUNK","CASE_SUMMARIZATION_CHUNK","DETECTED_INTENT","EMAIL_GENERATIVE_ANSWER_CHUNK","EMAIL_OVERVIEW_CHUNK","EMAIL_RESPONSE_CHUNK","GENERATIVE_ANSWER","GENERATIVE_ANSWER_CHUNK","GENERATIVE_RESPONSE","INTENT_ANSWER_CHUNK","KNOWLEDGE_CONTENT","NOTES_CHUNK","SUGGESTED_MESSAGE"
            break
        }

        # Amazon.QConnect.Relevance
        "Write-QCFeedback/GenerativeContentFeedbackData_Relevance"
        {
            $v = "HELPFUL","NOT_HELPFUL"
            break
        }

        # Amazon.QConnect.SessionDataNamespace
        "Update-QCSessionData/Namespace"
        {
            $v = "Custom"
            break
        }

        # Amazon.QConnect.TargetType
        "Write-QCFeedback/TargetType"
        {
            $v = "MESSAGE","RECOMMENDATION","RESULT"
            break
        }

        # Amazon.QConnect.VisibilityStatus
        {
            ($_ -eq "New-QCAIAgent/VisibilityStatus") -Or
            ($_ -eq "New-QCAIGuardrail/VisibilityStatus") -Or
            ($_ -eq "New-QCAIPrompt/VisibilityStatus") -Or
            ($_ -eq "Update-QCAIAgent/VisibilityStatus") -Or
            ($_ -eq "Update-QCAIGuardrail/VisibilityStatus") -Or
            ($_ -eq "Update-QCAIPrompt/VisibilityStatus")
        }
        {
            $v = "PUBLISHED","SAVED"
            break
        }

        # Amazon.QConnect.WebScopeType
        "New-QCKnowledgeBase/WebCrawlerConfiguration_Scope"
        {
            $v = "HOST_ONLY","SUBDOMAINS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$QC_map = @{
    "Adm_Action"=@("New-QCMessageTemplate","Update-QCMessageTemplate")
    "AiAgentType"=@("Remove-QCAssistantAIAgent","Update-QCAssistantAIAgent")
    "ApiFormat"=@("New-QCAIPrompt")
    "Apns_Action"=@("New-QCMessageTemplate","Update-QCMessageTemplate")
    "AssociationType"=@("New-QCAssistantAssociation","New-QCContentAssociation")
    "Baidu_Action"=@("New-QCMessageTemplate","Update-QCMessageTemplate")
    "ChannelSubtype"=@("New-QCMessageTemplate")
    "ChunkingConfiguration_ChunkingStrategy"=@("New-QCKnowledgeBase")
    "ContentDisposition"=@("New-QCMessageTemplateAttachment")
    "ExternalSourceConfiguration_Source"=@("Start-QCImportJob")
    "Fcm_Action"=@("New-QCMessageTemplate","Update-QCMessageTemplate")
    "Filter"=@("Get-QCMessageList")
    "GenerativeContentFeedbackData_Relevance"=@("Write-QCFeedback")
    "ImportJobType"=@("Start-QCImportJob")
    "KnowledgeBaseType"=@("New-QCKnowledgeBase")
    "Namespace"=@("Update-QCSessionData")
    "OrderOnField_Order"=@("Search-QCMessageTemplate","Search-QCQuickResponse")
    "Origin"=@("Get-QCAIAgentList","Get-QCAIAgentVersionList","Get-QCAIPromptList","Get-QCAIPromptVersionList")
    "OverrideKnowledgeBaseSearchType"=@("Search-QCAssistant")
    "ParsingConfiguration_ParsingStrategy"=@("New-QCKnowledgeBase")
    "RecommendationType"=@("Get-QCRecommendation")
    "RetrievalConfiguration_OverrideKnowledgeBaseSearchType"=@("Invoke-QCRetrieve")
    "TargetType"=@("Write-QCFeedback")
    "TemplateType"=@("New-QCAIPrompt")
    "Type"=@("New-QCAIAgent","New-QCAIPrompt","New-QCAssistant","Send-QCMessage")
    "VisibilityStatus"=@("New-QCAIAgent","New-QCAIGuardrail","New-QCAIPrompt","Update-QCAIAgent","Update-QCAIGuardrail","Update-QCAIPrompt")
    "WebCrawlerConfiguration_Scope"=@("New-QCKnowledgeBase")
}

_awsArgumentCompleterRegistration $QC_Completers $QC_map

$QC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.QC.$($commandName.Replace('-', ''))Cmdlet]"
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

$QC_SelectMap = @{
    "Select"=@("Enable-QCMessageTemplate",
               "New-QCAIAgent",
               "New-QCAIAgentVersion",
               "New-QCAIGuardrail",
               "New-QCAIGuardrailVersion",
               "New-QCAIPrompt",
               "New-QCAIPromptVersion",
               "New-QCAssistant",
               "New-QCAssistantAssociation",
               "New-QCContent",
               "New-QCContentAssociation",
               "New-QCKnowledgeBase",
               "New-QCMessageTemplate",
               "New-QCMessageTemplateAttachment",
               "New-QCMessageTemplateVersion",
               "New-QCQuickResponse",
               "New-QCSession",
               "Disable-QCMessageTemplate",
               "Remove-QCAIAgent",
               "Remove-QCAIAgentVersion",
               "Remove-QCAIGuardrail",
               "Remove-QCAIGuardrailVersion",
               "Remove-QCAIPrompt",
               "Remove-QCAIPromptVersion",
               "Remove-QCAssistant",
               "Remove-QCAssistantAssociation",
               "Remove-QCContent",
               "Remove-QCContentAssociation",
               "Remove-QCImportJob",
               "Remove-QCKnowledgeBase",
               "Remove-QCMessageTemplate",
               "Remove-QCMessageTemplateAttachment",
               "Remove-QCQuickResponse",
               "Get-QCAIAgent",
               "Get-QCAIGuardrail",
               "Get-QCAIPrompt",
               "Get-QCAssistant",
               "Get-QCAssistantAssociation",
               "Get-QCContent",
               "Get-QCContentAssociation",
               "Get-QCContentSummary",
               "Get-QCImportJob",
               "Get-QCKnowledgeBase",
               "Get-QCMessageTemplate",
               "Get-QCNextMessage",
               "Get-QCQuickResponse",
               "Get-QCRecommendation",
               "Get-QCSession",
               "Get-QCAIAgentList",
               "Get-QCAIAgentVersionList",
               "Get-QCAIGuardrailList",
               "Get-QCAIGuardrailVersionList",
               "Get-QCAIPromptList",
               "Get-QCAIPromptVersionList",
               "Get-QCAssistantAssociationList",
               "Get-QCAssistantList",
               "Get-QCContentAssociationList",
               "Get-QCContentList",
               "Get-QCImportJobList",
               "Get-QCKnowledgeBasisList",
               "Get-QCMessageList",
               "Get-QCMessageTemplateList",
               "Get-QCMessageTemplateVersionList",
               "Get-QCQuickResponseList",
               "Get-QCSpanList",
               "Get-QCResourceTag",
               "Remove-QCRecommendationsReceived",
               "Write-QCFeedback",
               "Search-QCAssistant",
               "Remove-QCAssistantAIAgent",
               "Remove-QCKnowledgeBaseTemplateUri",
               "Invoke-QCMessageTemplate",
               "Invoke-QCRetrieve",
               "Search-QCContent",
               "Search-QCMessageTemplate",
               "Search-QCQuickResponse",
               "Search-QCSession",
               "Send-QCMessage",
               "Start-QCContentUpload",
               "Start-QCImportJob",
               "Add-QCResourceTag",
               "Remove-QCResourceTag",
               "Update-QCAIAgent",
               "Update-QCAIGuardrail",
               "Update-QCAIPrompt",
               "Update-QCAssistantAIAgent",
               "Update-QCContent",
               "Update-QCKnowledgeBaseTemplateUri",
               "Update-QCMessageTemplate",
               "Update-QCMessageTemplateMetadata",
               "Update-QCQuickResponse",
               "Update-QCSession",
               "Update-QCSessionData")
}

_awsArgumentCompleterRegistration $QC_SelectCompleters $QC_SelectMap

