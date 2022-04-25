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

# Argument completions for service Amazon Connect Service


$CONN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Connect.AgentStatusState
        {
            ($_ -eq "New-CONNAgentStatus/State") -Or
            ($_ -eq "Update-CONNAgentStatus/State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Connect.ContactFlowModuleState
        {
            ($_ -eq "Get-CONNContactFlowModuleList/ContactFlowModuleState") -Or
            ($_ -eq "Update-CONNContactFlowModuleMetadata/State")
        }
        {
            $v = "ACTIVE","ARCHIVED"
            break
        }

        # Amazon.Connect.ContactFlowState
        "Update-CONNContactFlowMetadata/ContactFlowState"
        {
            $v = "ACTIVE","ARCHIVED"
            break
        }

        # Amazon.Connect.ContactFlowType
        "New-CONNContactFlow/Type"
        {
            $v = "AGENT_HOLD","AGENT_TRANSFER","AGENT_WHISPER","CONTACT_FLOW","CUSTOMER_HOLD","CUSTOMER_QUEUE","CUSTOMER_WHISPER","OUTBOUND_WHISPER","QUEUE_TRANSFER"
            break
        }

        # Amazon.Connect.DirectoryType
        "New-CONNInstance/IdentityManagementType"
        {
            $v = "CONNECT_MANAGED","EXISTING_DIRECTORY","SAML"
            break
        }

        # Amazon.Connect.EncryptionType
        {
            ($_ -eq "Add-CONNInstanceStorageConfig/StorageConfig_KinesisVideoStreamConfig_EncryptionConfig_EncryptionType") -Or
            ($_ -eq "Update-CONNInstanceStorageConfig/StorageConfig_KinesisVideoStreamConfig_EncryptionConfig_EncryptionType") -Or
            ($_ -eq "Add-CONNInstanceStorageConfig/StorageConfig_S3Config_EncryptionConfig_EncryptionType") -Or
            ($_ -eq "Update-CONNInstanceStorageConfig/StorageConfig_S3Config_EncryptionConfig_EncryptionType")
        }
        {
            $v = "KMS"
            break
        }

        # Amazon.Connect.HierarchyGroupMatchType
        "Search-CONNUser/SearchCriteria_HierarchyGroupCondition_HierarchyGroupMatchType"
        {
            $v = "EXACT","WITH_CHILD_GROUPS"
            break
        }

        # Amazon.Connect.InstanceAttributeType
        {
            ($_ -eq "Get-CONNInstanceAttribute/AttributeType") -Or
            ($_ -eq "Update-CONNInstanceAttribute/AttributeType")
        }
        {
            $v = "AUTO_RESOLVE_BEST_VOICES","CONTACTFLOW_LOGS","CONTACT_LENS","EARLY_MEDIA","INBOUND_CALLS","MULTI_PARTY_CONFERENCE","OUTBOUND_CALLS","USE_CUSTOM_TTS_VOICES"
            break
        }

        # Amazon.Connect.InstanceStorageResourceType
        {
            ($_ -eq "Add-CONNInstanceStorageConfig/ResourceType") -Or
            ($_ -eq "Get-CONNInstanceStorageConfig/ResourceType") -Or
            ($_ -eq "Get-CONNInstanceStorageConfigList/ResourceType") -Or
            ($_ -eq "Remove-CONNInstanceStorageConfig/ResourceType") -Or
            ($_ -eq "Update-CONNInstanceStorageConfig/ResourceType")
        }
        {
            $v = "AGENT_EVENTS","CALL_RECORDINGS","CHAT_TRANSCRIPTS","CONTACT_TRACE_RECORDS","MEDIA_STREAMS","REAL_TIME_CONTACT_ANALYSIS_SEGMENTS","SCHEDULED_REPORTS"
            break
        }

        # Amazon.Connect.IntegrationType
        {
            ($_ -eq "Get-CONNIntegrationAssociationList/IntegrationType") -Or
            ($_ -eq "New-CONNIntegrationAssociation/IntegrationType")
        }
        {
            $v = "EVENT","PINPOINT_APP","VOICE_ID","WISDOM_ASSISTANT","WISDOM_KNOWLEDGE_BASE"
            break
        }

        # Amazon.Connect.LexVersion
        "Get-CONNBotList/LexVersion"
        {
            $v = "V1","V2"
            break
        }

        # Amazon.Connect.PhoneNumberCountryCode
        "Search-CONNAvailablePhoneNumber/PhoneNumberCountryCode"
        {
            $v = "AD","AE","AF","AG","AI","AL","AM","AN","AO","AQ","AR","AS","AT","AU","AW","AZ","BA","BB","BD","BE","BF","BG","BH","BI","BJ","BL","BM","BN","BO","BR","BS","BT","BW","BY","BZ","CA","CC","CD","CF","CG","CH","CI","CK","CL","CM","CN","CO","CR","CU","CV","CW","CX","CY","CZ","DE","DJ","DK","DM","DO","DZ","EC","EE","EG","EH","ER","ES","ET","FI","FJ","FK","FM","FO","FR","GA","GB","GD","GE","GG","GH","GI","GL","GM","GN","GQ","GR","GT","GU","GW","GY","HK","HN","HR","HT","HU","ID","IE","IL","IM","IN","IO","IQ","IR","IS","IT","JE","JM","JO","JP","KE","KG","KH","KI","KM","KN","KP","KR","KW","KY","KZ","LA","LB","LC","LI","LK","LR","LS","LT","LU","LV","LY","MA","MC","MD","ME","MF","MG","MH","MK","ML","MM","MN","MO","MP","MR","MS","MT","MU","MV","MW","MX","MY","MZ","NA","NC","NE","NG","NI","NL","NO","NP","NR","NU","NZ","OM","PA","PE","PF","PG","PH","PK","PL","PM","PN","PR","PT","PW","PY","QA","RE","RO","RS","RU","RW","SA","SB","SC","SD","SE","SG","SH","SI","SJ","SK","SL","SM","SN","SO","SR","ST","SV","SX","SY","SZ","TC","TD","TG","TH","TJ","TK","TL","TM","TN","TO","TR","TT","TV","TW","TZ","UA","UG","US","UY","UZ","VA","VC","VE","VG","VI","VN","VU","WF","WS","YE","YT","ZA","ZM","ZW"
            break
        }

        # Amazon.Connect.PhoneNumberType
        "Search-CONNAvailablePhoneNumber/PhoneNumberType"
        {
            $v = "DID","TOLL_FREE"
            break
        }

        # Amazon.Connect.QueueStatus
        "Update-CONNQueueStatus/Status"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Connect.QuickConnectType
        {
            ($_ -eq "New-CONNQuickConnect/QuickConnectConfig_QuickConnectType") -Or
            ($_ -eq "Update-CONNQuickConnectConfig/QuickConnectConfig_QuickConnectType")
        }
        {
            $v = "PHONE_NUMBER","QUEUE","USER"
            break
        }

        # Amazon.Connect.SourceType
        "New-CONNIntegrationAssociation/SourceType"
        {
            $v = "SALESFORCE","ZENDESK"
            break
        }

        # Amazon.Connect.StorageType
        {
            ($_ -eq "Add-CONNInstanceStorageConfig/StorageConfig_StorageType") -Or
            ($_ -eq "Update-CONNInstanceStorageConfig/StorageConfig_StorageType")
        }
        {
            $v = "KINESIS_FIREHOSE","KINESIS_STREAM","KINESIS_VIDEO_STREAM","S3"
            break
        }

        # Amazon.Connect.StringComparisonType
        "Search-CONNUser/SearchCriteria_StringCondition_ComparisonType"
        {
            $v = "CONTAINS","EXACT","STARTS_WITH"
            break
        }

        # Amazon.Connect.TrafficType
        "Start-CONNOutboundVoiceContact/TrafficType"
        {
            $v = "CAMPAIGN","GENERAL"
            break
        }

        # Amazon.Connect.UseCaseType
        "New-CONNUseCase/UseCaseType"
        {
            $v = "CONNECT_CAMPAIGNS","RULES_EVALUATION"
            break
        }

        # Amazon.Connect.VocabularyLanguageCode
        {
            ($_ -eq "Add-CONNDefaultVocabulary/LanguageCode") -Or
            ($_ -eq "Get-CONNDefaultVocabularyList/LanguageCode") -Or
            ($_ -eq "New-CONNVocabulary/LanguageCode") -Or
            ($_ -eq "Search-CONNVocabulary/LanguageCode")
        }
        {
            $v = "ar-AE","de-CH","de-DE","en-AB","en-AU","en-GB","en-IE","en-IN","en-US","en-WL","es-ES","es-US","fr-CA","fr-FR","hi-IN","it-IT","ja-JP","ko-KR","pt-BR","pt-PT","zh-CN"
            break
        }

        # Amazon.Connect.VocabularyState
        "Search-CONNVocabulary/State"
        {
            $v = "ACTIVE","CREATION_FAILED","CREATION_IN_PROGRESS","DELETE_IN_PROGRESS"
            break
        }

        # Amazon.Connect.VoiceRecordingTrack
        "Start-CONNContactRecording/VoiceRecordingConfiguration_VoiceRecordingTrack"
        {
            $v = "ALL","FROM_AGENT","TO_AGENT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CONN_map = @{
    "AttributeType"=@("Get-CONNInstanceAttribute","Update-CONNInstanceAttribute")
    "ContactFlowModuleState"=@("Get-CONNContactFlowModuleList")
    "ContactFlowState"=@("Update-CONNContactFlowMetadata")
    "IdentityManagementType"=@("New-CONNInstance")
    "IntegrationType"=@("Get-CONNIntegrationAssociationList","New-CONNIntegrationAssociation")
    "LanguageCode"=@("Add-CONNDefaultVocabulary","Get-CONNDefaultVocabularyList","New-CONNVocabulary","Search-CONNVocabulary")
    "LexVersion"=@("Get-CONNBotList")
    "PhoneNumberCountryCode"=@("Search-CONNAvailablePhoneNumber")
    "PhoneNumberType"=@("Search-CONNAvailablePhoneNumber")
    "QuickConnectConfig_QuickConnectType"=@("New-CONNQuickConnect","Update-CONNQuickConnectConfig")
    "ResourceType"=@("Add-CONNInstanceStorageConfig","Get-CONNInstanceStorageConfig","Get-CONNInstanceStorageConfigList","Remove-CONNInstanceStorageConfig","Update-CONNInstanceStorageConfig")
    "SearchCriteria_HierarchyGroupCondition_HierarchyGroupMatchType"=@("Search-CONNUser")
    "SearchCriteria_StringCondition_ComparisonType"=@("Search-CONNUser")
    "SourceType"=@("New-CONNIntegrationAssociation")
    "State"=@("New-CONNAgentStatus","Search-CONNVocabulary","Update-CONNAgentStatus","Update-CONNContactFlowModuleMetadata")
    "Status"=@("Update-CONNQueueStatus")
    "StorageConfig_KinesisVideoStreamConfig_EncryptionConfig_EncryptionType"=@("Add-CONNInstanceStorageConfig","Update-CONNInstanceStorageConfig")
    "StorageConfig_S3Config_EncryptionConfig_EncryptionType"=@("Add-CONNInstanceStorageConfig","Update-CONNInstanceStorageConfig")
    "StorageConfig_StorageType"=@("Add-CONNInstanceStorageConfig","Update-CONNInstanceStorageConfig")
    "TrafficType"=@("Start-CONNOutboundVoiceContact")
    "Type"=@("New-CONNContactFlow")
    "UseCaseType"=@("New-CONNUseCase")
    "VoiceRecordingConfiguration_VoiceRecordingTrack"=@("Start-CONNContactRecording")
}

_awsArgumentCompleterRegistration $CONN_Completers $CONN_map

$CONN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CONN.$($commandName.Replace('-', ''))Cmdlet]"
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

$CONN_SelectMap = @{
    "Select"=@("Add-CONNApprovedOrigin",
               "Add-CONNBot",
               "Add-CONNDefaultVocabulary",
               "Add-CONNInstanceStorageConfig",
               "Add-CONNLambdaFunction",
               "Add-CONNLexBot",
               "Add-CONNPhoneNumberContactFlow",
               "Add-CONNQueueQuickConnect",
               "Join-CONNRoutingProfileQueue",
               "Add-CONNSecurityKey",
               "Request-CONNPhoneNumber",
               "New-CONNAgentStatus",
               "New-CONNContactFlow",
               "New-CONNContactFlowModule",
               "New-CONNHoursOfOperation",
               "New-CONNInstance",
               "New-CONNIntegrationAssociation",
               "New-CONNQueue",
               "New-CONNQuickConnect",
               "New-CONNRoutingProfile",
               "New-CONNSecurityProfile",
               "New-CONNUseCase",
               "New-CONNUser",
               "New-CONNUserHierarchyGroup",
               "New-CONNVocabulary",
               "Remove-CONNContactFlow",
               "Remove-CONNContactFlowModule",
               "Remove-CONNHoursOfOperation",
               "Remove-CONNInstance",
               "Remove-CONNIntegrationAssociation",
               "Remove-CONNQuickConnect",
               "Remove-CONNSecurityProfile",
               "Remove-CONNUseCase",
               "Remove-CONNUser",
               "Remove-CONNUserHierarchyGroup",
               "Remove-CONNVocabulary",
               "Get-CONNAgentStatus",
               "Get-CONNContact",
               "Get-CONNContactFlow",
               "Get-CONNContactFlowModule",
               "Get-CONNHoursOfOperation",
               "Get-CONNInstance",
               "Get-CONNInstanceAttribute",
               "Get-CONNInstanceStorageConfig",
               "Get-CONNPhoneNumber",
               "Get-CONNQueue",
               "Get-CONNQuickConnect",
               "Get-CONNRoutingProfile",
               "Get-CONNSecurityProfile",
               "Get-CONNUser",
               "Get-CONNUserHierarchyGroup",
               "Get-CONNUserHierarchyStructure",
               "Get-CONNVocabulary",
               "Remove-CONNApprovedOrigin",
               "Remove-CONNBot",
               "Remove-CONNInstanceStorageConfig",
               "Remove-CONNLambdaFunction",
               "Remove-CONNLexBot",
               "Remove-CONNPhoneNumberContactFlow",
               "Remove-CONNQueueQuickConnect",
               "Disconnect-CONNRoutingProfileQueue",
               "Remove-CONNSecurityKey",
               "Get-CONNContactAttribute",
               "Get-CONNCurrentMetricData",
               "Get-CONNFederationToken",
               "Get-CONNMetricData",
               "Get-CONNAgentStatusList",
               "Get-CONNApprovedOriginList",
               "Get-CONNBotList",
               "Get-CONNContactFlowModuleList",
               "Get-CONNContactFlowList",
               "Get-CONNContactReferenceList",
               "Get-CONNDefaultVocabularyList",
               "Get-CONNHoursOfOperationList",
               "Get-CONNInstanceAttributeList",
               "Get-CONNInstanceList",
               "Get-CONNInstanceStorageConfigList",
               "Get-CONNIntegrationAssociationList",
               "Get-CONNLambdaFunctionList",
               "Get-CONNLexBotList",
               "Get-CONNPhoneNumberList",
               "Get-CONNPhoneNumbersV2List",
               "Get-CONNPromptList",
               "Get-CONNQueueQuickConnectList",
               "Get-CONNQueueList",
               "Get-CONNQuickConnectList",
               "Get-CONNRoutingProfileQueueList",
               "Get-CONNRoutingProfileList",
               "Get-CONNSecurityKeyList",
               "Get-CONNSecurityProfilePermissionList",
               "Get-CONNSecurityProfileList",
               "Get-CONNResourceTag",
               "Get-CONNUseCaseList",
               "Get-CONNUserHierarchyGroupList",
               "Get-CONNUserList",
               "Remove-CONNPhoneNumber",
               "Resume-CONNContactRecording",
               "Search-CONNAvailablePhoneNumber",
               "Search-CONNUser",
               "Search-CONNVocabulary",
               "Start-CONNChatContact",
               "Start-CONNContactRecording",
               "Start-CONNContactStreaming",
               "Start-CONNOutboundVoiceContact",
               "Start-CONNTaskContact",
               "Stop-CONNContact",
               "Stop-CONNContactRecording",
               "Stop-CONNContactStreaming",
               "Suspend-CONNContactRecording",
               "Add-CONNResourceTag",
               "Remove-CONNResourceTag",
               "Update-CONNAgentStatus",
               "Update-CONNContact",
               "Update-CONNContactAttribute",
               "Update-CONNContactFlowContent",
               "Update-CONNContactFlowMetadata",
               "Update-CONNContactFlowModuleContent",
               "Update-CONNContactFlowModuleMetadata",
               "Update-CONNContactFlowName",
               "Update-CONNContactSchedule",
               "Update-CONNHoursOfOperation",
               "Update-CONNInstanceAttribute",
               "Update-CONNInstanceStorageConfig",
               "Update-CONNPhoneNumber",
               "Update-CONNQueueHoursOfOperation",
               "Update-CONNQueueMaxContact",
               "Update-CONNQueueName",
               "Update-CONNQueueOutboundCallerConfig",
               "Update-CONNQueueStatus",
               "Update-CONNQuickConnectConfig",
               "Update-CONNQuickConnectName",
               "Update-CONNRoutingProfileConcurrency",
               "Update-CONNRoutingProfileDefaultOutboundQueue",
               "Update-CONNRoutingProfileName",
               "Update-CONNRoutingProfileQueue",
               "Update-CONNSecurityProfile",
               "Update-CONNUserHierarchy",
               "Update-CONNUserHierarchyGroupName",
               "Update-CONNUserHierarchyStructure",
               "Update-CONNUserIdentityInfo",
               "Update-CONNUserPhoneConfig",
               "Update-CONNUserRoutingProfile",
               "Update-CONNUserSecurityProfile")
}

_awsArgumentCompleterRegistration $CONN_SelectCompleters $CONN_SelectMap

