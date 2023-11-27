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

# Argument completions for service Amazon Lex Model Building V2


$LMBV2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LexModelsV2.AggregatedUtterancesSortAttribute
        "Get-LMBV2AggregatedUtteranceList/SortBy_Attribute"
        {
            $v = "HitCount","MissedCount"
            break
        }

        # Amazon.LexModelsV2.AnalyticsSessionSortByName
        "Get-LMBV2SessionAnalyticsDataList/SortBy_Name"
        {
            $v = "ConversationStartTime","Duration","NumberOfTurns"
            break
        }

        # Amazon.LexModelsV2.AnalyticsSortOrder
        {
            ($_ -eq "Get-LMBV2SessionAnalyticsDataList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2UtteranceAnalyticsDataList/SortBy_Order")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.LexModelsV2.AnalyticsUtteranceSortByName
        "Get-LMBV2UtteranceAnalyticsDataList/SortBy_Name"
        {
            $v = "UtteranceTimestamp"
            break
        }

        # Amazon.LexModelsV2.AudioRecognitionStrategy
        {
            ($_ -eq "New-LMBV2SlotType/ValueSelectionSetting_AdvancedRecognitionSetting_AudioRecognitionStrategy") -Or
            ($_ -eq "Update-LMBV2SlotType/ValueSelectionSetting_AdvancedRecognitionSetting_AudioRecognitionStrategy")
        }
        {
            $v = "UseSlotValuesAsCustomVocabulary"
            break
        }

        # Amazon.LexModelsV2.BotLocaleSortAttribute
        "Get-LMBV2BotLocaleList/SortBy_Attribute"
        {
            $v = "BotLocaleName"
            break
        }

        # Amazon.LexModelsV2.BotSortAttribute
        "Get-LMBV2BotList/SortBy_Attribute"
        {
            $v = "BotName"
            break
        }

        # Amazon.LexModelsV2.BotType
        {
            ($_ -eq "New-LMBV2Bot/BotType") -Or
            ($_ -eq "Update-LMBV2Bot/BotType")
        }
        {
            $v = "Bot","BotNetwork"
            break
        }

        # Amazon.LexModelsV2.BotVersionSortAttribute
        "Get-LMBV2BotVersionList/SortBy_Attribute"
        {
            $v = "BotVersion"
            break
        }

        # Amazon.LexModelsV2.BuiltInIntentSortAttribute
        "Get-LMBV2BuiltInIntentList/SortBy_Attribute"
        {
            $v = "IntentSignature"
            break
        }

        # Amazon.LexModelsV2.BuiltInSlotTypeSortAttribute
        "Get-LMBV2BuiltInSlotTypeList/SortBy_Attribute"
        {
            $v = "SlotTypeSignature"
            break
        }

        # Amazon.LexModelsV2.ConversationLogsInputModeFilter
        "Start-LMBV2TestSetGeneration/GenerationDataSource_ConversationLogsDataSource_Filter_InputMode"
        {
            $v = "Speech","Text"
            break
        }

        # Amazon.LexModelsV2.DialogActionType
        {
            ($_ -eq "New-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_Conditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_Conditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/InitialResponseSetting_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/InitialResponseSetting_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentClosingSetting_Conditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentClosingSetting_Conditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentClosingSetting_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentClosingSetting_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_ConfirmationConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_ConfirmationConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_ConfirmationNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_ConfirmationNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_DeclinationConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_DeclinationConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_DeclinationNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_DeclinationNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type")
        }
        {
            $v = "CloseIntent","ConfirmIntent","ElicitIntent","ElicitSlot","EndConversation","EvaluateConditional","FulfillIntent","InvokeDialogCodeHook","StartIntent"
            break
        }

        # Amazon.LexModelsV2.Effect
        "New-LMBV2ResourcePolicyStatement/Effect"
        {
            $v = "Allow","Deny"
            break
        }

        # Amazon.LexModelsV2.ExportSortAttribute
        "Get-LMBV2ExportList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime"
            break
        }

        # Amazon.LexModelsV2.GenerationSortByAttribute
        "Get-LMBV2BotResourceGenerationList/SortBy_Attribute"
        {
            $v = "creationStartTime","lastUpdatedTime"
            break
        }

        # Amazon.LexModelsV2.ImportExportFileFormat
        "New-LMBV2Export/FileFormat"
        {
            $v = "CSV","LexJson","TSV"
            break
        }

        # Amazon.LexModelsV2.ImportSortAttribute
        "Get-LMBV2ImportList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime"
            break
        }

        # Amazon.LexModelsV2.IntentSortAttribute
        "Get-LMBV2IntentList/SortBy_Attribute"
        {
            $v = "IntentName","LastUpdatedDateTime"
            break
        }

        # Amazon.LexModelsV2.MergeStrategy
        "Start-LMBV2Import/MergeStrategy"
        {
            $v = "Append","FailOnConflict","Overwrite"
            break
        }

        # Amazon.LexModelsV2.MessageSelectionStrategy
        {
            ($_ -eq "New-LMBV2Intent/IntentConfirmationSetting_PromptSpecification_MessageSelectionStrategy") -Or
            ($_ -eq "Update-LMBV2Intent/IntentConfirmationSetting_PromptSpecification_MessageSelectionStrategy") -Or
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_PromptSpecification_MessageSelectionStrategy") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_PromptSpecification_MessageSelectionStrategy")
        }
        {
            $v = "Ordered","Random"
            break
        }

        # Amazon.LexModelsV2.ObfuscationSettingType
        {
            ($_ -eq "New-LMBV2Slot/ObfuscationSetting_ObfuscationSettingType") -Or
            ($_ -eq "Update-LMBV2Slot/ObfuscationSetting_ObfuscationSettingType")
        }
        {
            $v = "DefaultObfuscation","None"
            break
        }

        # Amazon.LexModelsV2.SearchOrder
        "Search-LMBV2AssociatedTranscript/SearchOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.LexModelsV2.SlotConstraint
        {
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotConstraint") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotConstraint")
        }
        {
            $v = "Optional","Required"
            break
        }

        # Amazon.LexModelsV2.SlotResolutionStrategy
        {
            ($_ -eq "New-LMBV2Slot/ValueElicitationSetting_SlotResolutionSetting_SlotResolutionStrategy") -Or
            ($_ -eq "Update-LMBV2Slot/ValueElicitationSetting_SlotResolutionSetting_SlotResolutionStrategy")
        }
        {
            $v = "Default","EnhancedFallback"
            break
        }

        # Amazon.LexModelsV2.SlotSortAttribute
        "Get-LMBV2SlotList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime","SlotName"
            break
        }

        # Amazon.LexModelsV2.SlotTypeSortAttribute
        "Get-LMBV2SlotTypeList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime","SlotTypeName"
            break
        }

        # Amazon.LexModelsV2.SlotValueResolutionStrategy
        {
            ($_ -eq "New-LMBV2SlotType/ValueSelectionSetting_ResolutionStrategy") -Or
            ($_ -eq "Update-LMBV2SlotType/ValueSelectionSetting_ResolutionStrategy")
        }
        {
            $v = "Concatenation","OriginalValue","TopResolution"
            break
        }

        # Amazon.LexModelsV2.SortOrder
        {
            ($_ -eq "Get-LMBV2AggregatedUtteranceList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotLocaleList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotResourceGenerationList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BotVersionList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BuiltInIntentList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2BuiltInSlotTypeList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2ExportList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2ImportList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2IntentList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2SlotList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2SlotTypeList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2TestExecutionList/SortBy_Order") -Or
            ($_ -eq "Get-LMBV2TestSetList/SortBy_Order")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.LexModelsV2.TestExecutionApiMode
        "Start-LMBV2TestExecution/ApiMode"
        {
            $v = "NonStreaming","Streaming"
            break
        }

        # Amazon.LexModelsV2.TestExecutionModality
        "Start-LMBV2TestExecution/TestExecutionModality"
        {
            $v = "Audio","Text"
            break
        }

        # Amazon.LexModelsV2.TestExecutionSortAttribute
        "Get-LMBV2TestExecutionList/SortBy_Attribute"
        {
            $v = "CreationDateTime","TestSetName"
            break
        }

        # Amazon.LexModelsV2.TestResultMatchStatus
        "Get-LMBV2TestExecutionResultItemList/ResultFilterBy_ConversationLevelTestResultsFilterBy_EndToEndResult"
        {
            $v = "ExecutionError","Matched","Mismatched"
            break
        }

        # Amazon.LexModelsV2.TestResultTypeFilter
        "Get-LMBV2TestExecutionResultItemList/ResultFilterBy_ResultTypeFilter"
        {
            $v = "ConversationLevelTestResults","IntentClassificationTestResults","OverallTestResults","SlotResolutionTestResults","UtteranceLevelResults"
            break
        }

        # Amazon.LexModelsV2.TestSetModality
        "Start-LMBV2Import/ResourceSpecification_TestSetImportResourceSpecification_Modality"
        {
            $v = "Audio","Text"
            break
        }

        # Amazon.LexModelsV2.TestSetSortAttribute
        "Get-LMBV2TestSetList/SortBy_Attribute"
        {
            $v = "LastUpdatedDateTime","TestSetName"
            break
        }

        # Amazon.LexModelsV2.TimeDimension
        "Get-LMBV2AggregatedUtteranceList/AggregationDuration_RelativeAggregationDuration_TimeDimension"
        {
            $v = "Days","Hours","Weeks"
            break
        }

        # Amazon.LexModelsV2.TranscriptFormat
        "Start-LMBV2BotRecommendation/TranscriptSourceSetting_S3BucketTranscriptSource_TranscriptFormat"
        {
            $v = "Lex"
            break
        }

        # Amazon.LexModelsV2.VoiceEngine
        {
            ($_ -eq "Start-LMBV2Import/ResourceSpecification_BotLocaleImportSpecification_VoiceSettings_Engine") -Or
            ($_ -eq "New-LMBV2BotLocale/VoiceSettings_Engine") -Or
            ($_ -eq "Update-LMBV2BotLocale/VoiceSettings_Engine")
        }
        {
            $v = "neural","standard"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LMBV2_map = @{
    "AggregationDuration_RelativeAggregationDuration_TimeDimension"=@("Get-LMBV2AggregatedUtteranceList")
    "ApiMode"=@("Start-LMBV2TestExecution")
    "BotType"=@("New-LMBV2Bot","Update-LMBV2Bot")
    "Effect"=@("New-LMBV2ResourcePolicyStatement")
    "FileFormat"=@("New-LMBV2Export")
    "FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "FulfillmentCodeHook_PostFulfillmentStatusSpecification_FailureNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "FulfillmentCodeHook_PostFulfillmentStatusSpecification_SuccessNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "FulfillmentCodeHook_PostFulfillmentStatusSpecification_TimeoutNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "GenerationDataSource_ConversationLogsDataSource_Filter_InputMode"=@("Start-LMBV2TestSetGeneration")
    "InitialResponseSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_Conditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "InitialResponseSetting_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentClosingSetting_Conditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentClosingSetting_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_ConfirmationConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_ConfirmationNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_DeclinationConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_DeclinationNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_FailureNextStep_DialogAction_Type"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "IntentConfirmationSetting_PromptSpecification_MessageSelectionStrategy"=@("New-LMBV2Intent","Update-LMBV2Intent")
    "MergeStrategy"=@("Start-LMBV2Import")
    "ObfuscationSetting_ObfuscationSettingType"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ResourceSpecification_BotLocaleImportSpecification_VoiceSettings_Engine"=@("Start-LMBV2Import")
    "ResourceSpecification_TestSetImportResourceSpecification_Modality"=@("Start-LMBV2Import")
    "ResultFilterBy_ConversationLevelTestResultsFilterBy_EndToEndResult"=@("Get-LMBV2TestExecutionResultItemList")
    "ResultFilterBy_ResultTypeFilter"=@("Get-LMBV2TestExecutionResultItemList")
    "SearchOrder"=@("Search-LMBV2AssociatedTranscript")
    "SortBy_Attribute"=@("Get-LMBV2AggregatedUtteranceList","Get-LMBV2BotList","Get-LMBV2BotLocaleList","Get-LMBV2BotResourceGenerationList","Get-LMBV2BotVersionList","Get-LMBV2BuiltInIntentList","Get-LMBV2BuiltInSlotTypeList","Get-LMBV2ExportList","Get-LMBV2ImportList","Get-LMBV2IntentList","Get-LMBV2SlotList","Get-LMBV2SlotTypeList","Get-LMBV2TestExecutionList","Get-LMBV2TestSetList")
    "SortBy_Name"=@("Get-LMBV2SessionAnalyticsDataList","Get-LMBV2UtteranceAnalyticsDataList")
    "SortBy_Order"=@("Get-LMBV2AggregatedUtteranceList","Get-LMBV2BotList","Get-LMBV2BotLocaleList","Get-LMBV2BotResourceGenerationList","Get-LMBV2BotVersionList","Get-LMBV2BuiltInIntentList","Get-LMBV2BuiltInSlotTypeList","Get-LMBV2ExportList","Get-LMBV2ImportList","Get-LMBV2IntentList","Get-LMBV2SessionAnalyticsDataList","Get-LMBV2SlotList","Get-LMBV2SlotTypeList","Get-LMBV2TestExecutionList","Get-LMBV2TestSetList","Get-LMBV2UtteranceAnalyticsDataList")
    "TestExecutionModality"=@("Start-LMBV2TestExecution")
    "TranscriptSourceSetting_S3BucketTranscriptSource_TranscriptFormat"=@("Start-LMBV2BotRecommendation")
    "ValueElicitationSetting_PromptSpecification_MessageSelectionStrategy"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CaptureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CaptureNextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_FailureNextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_SuccessNextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_CodeHook_PostCodeHookSpecification_TimeoutNextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_FailureConditional_DefaultBranch_NextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotCaptureSetting_FailureNextStep_DialogAction_Type"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotConstraint"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueElicitationSetting_SlotResolutionSetting_SlotResolutionStrategy"=@("New-LMBV2Slot","Update-LMBV2Slot")
    "ValueSelectionSetting_AdvancedRecognitionSetting_AudioRecognitionStrategy"=@("New-LMBV2SlotType","Update-LMBV2SlotType")
    "ValueSelectionSetting_ResolutionStrategy"=@("New-LMBV2SlotType","Update-LMBV2SlotType")
    "VoiceSettings_Engine"=@("New-LMBV2BotLocale","Update-LMBV2BotLocale")
}

_awsArgumentCompleterRegistration $LMBV2_Completers $LMBV2_map

$LMBV2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LMBV2.$($commandName.Replace('-', ''))Cmdlet]"
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

$LMBV2_SelectMap = @{
    "Select"=@("New-LMBV2CustomVocabularyItem",
               "Remove-LMBV2CustomVocabularyItem",
               "Edit-LMBV2CustomVocabularyItem",
               "Invoke-LMBV2BuildBotLocale",
               "New-LMBV2Bot",
               "New-LMBV2BotAlias",
               "New-LMBV2BotLocale",
               "New-LMBV2BotVersion",
               "New-LMBV2Export",
               "New-LMBV2Intent",
               "New-LMBV2ResourcePolicy",
               "New-LMBV2ResourcePolicyStatement",
               "New-LMBV2Slot",
               "New-LMBV2SlotType",
               "New-LMBV2TestSetDiscrepancyReport",
               "New-LMBV2UploadUrl",
               "Remove-LMBV2Bot",
               "Remove-LMBV2BotAlias",
               "Remove-LMBV2BotLocale",
               "Remove-LMBV2BotVersion",
               "Remove-LMBV2CustomVocabulary",
               "Remove-LMBV2Export",
               "Remove-LMBV2Import",
               "Remove-LMBV2Intent",
               "Remove-LMBV2ResourcePolicy",
               "Remove-LMBV2ResourcePolicyStatement",
               "Remove-LMBV2Slot",
               "Remove-LMBV2SlotType",
               "Remove-LMBV2TestSet",
               "Remove-LMBV2Utterance",
               "Get-LMBV2Bot",
               "Get-LMBV2BotAlias",
               "Get-LMBV2BotLocale",
               "Get-LMBV2BotRecommendation",
               "Get-LMBV2BotResourceGeneration",
               "Get-LMBV2BotVersion",
               "Get-LMBV2CustomVocabularyMetadata",
               "Get-LMBV2Export",
               "Get-LMBV2Import",
               "Get-LMBV2Intent",
               "Get-LMBV2ResourcePolicy",
               "Get-LMBV2Slot",
               "Get-LMBV2SlotType",
               "Get-LMBV2TestExecution",
               "Get-LMBV2TestSet",
               "Get-LMBV2TestSetDiscrepancyReport",
               "Get-LMBV2TestSetGeneration",
               "Get-LMBV2BotElement",
               "Get-LMBV2TestExecutionArtifactsUrl",
               "Get-LMBV2AggregatedUtteranceList",
               "Get-LMBV2BotAliasList",
               "Get-LMBV2BotLocaleList",
               "Get-LMBV2BotRecommendationList",
               "Get-LMBV2BotResourceGenerationList",
               "Get-LMBV2BotList",
               "Get-LMBV2BotVersionList",
               "Get-LMBV2BuiltInIntentList",
               "Get-LMBV2BuiltInSlotTypeList",
               "Get-LMBV2CustomVocabularyItemList",
               "Get-LMBV2ExportList",
               "Get-LMBV2ImportList",
               "Get-LMBV2IntentMetricList",
               "Get-LMBV2IntentPathList",
               "Get-LMBV2IntentList",
               "Get-LMBV2IntentStageMetricList",
               "Get-LMBV2RecommendedIntentList",
               "Get-LMBV2SessionAnalyticsDataList",
               "Get-LMBV2SessionMetricList",
               "Get-LMBV2SlotList",
               "Get-LMBV2SlotTypeList",
               "Get-LMBV2ResourceTag",
               "Get-LMBV2TestExecutionResultItemList",
               "Get-LMBV2TestExecutionList",
               "Get-LMBV2TestSetRecordList",
               "Get-LMBV2TestSetList",
               "Get-LMBV2UtteranceAnalyticsDataList",
               "Get-LMBV2UtteranceMetricList",
               "Search-LMBV2AssociatedTranscript",
               "Start-LMBV2BotRecommendation",
               "Start-LMBV2BotResourceGeneration",
               "Start-LMBV2Import",
               "Start-LMBV2TestExecution",
               "Start-LMBV2TestSetGeneration",
               "Stop-LMBV2BotRecommendation",
               "Add-LMBV2ResourceTag",
               "Remove-LMBV2ResourceTag",
               "Update-LMBV2Bot",
               "Update-LMBV2BotAlias",
               "Update-LMBV2BotLocale",
               "Update-LMBV2BotRecommendation",
               "Update-LMBV2Export",
               "Update-LMBV2Intent",
               "Update-LMBV2ResourcePolicy",
               "Update-LMBV2Slot",
               "Update-LMBV2SlotType",
               "Update-LMBV2TestSet")
}

_awsArgumentCompleterRegistration $LMBV2_SelectCompleters $LMBV2_SelectMap

