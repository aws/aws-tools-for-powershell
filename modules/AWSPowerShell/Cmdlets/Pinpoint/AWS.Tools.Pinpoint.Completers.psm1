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

# Argument completions for service Amazon Pinpoint


$PIN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Pinpoint.Action
        {
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_ADMMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_BaiduMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action") -Or
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_GCMMessage_Action") -Or
            ($_ -eq "New-PINPushTemplate/PushNotificationTemplateRequest_ADM_Action") -Or
            ($_ -eq "Update-PINPushTemplate/PushNotificationTemplateRequest_ADM_Action") -Or
            ($_ -eq "New-PINPushTemplate/PushNotificationTemplateRequest_APNS_Action") -Or
            ($_ -eq "Update-PINPushTemplate/PushNotificationTemplateRequest_APNS_Action") -Or
            ($_ -eq "New-PINPushTemplate/PushNotificationTemplateRequest_Baidu_Action") -Or
            ($_ -eq "Update-PINPushTemplate/PushNotificationTemplateRequest_Baidu_Action") -Or
            ($_ -eq "New-PINPushTemplate/PushNotificationTemplateRequest_Default_Action") -Or
            ($_ -eq "Update-PINPushTemplate/PushNotificationTemplateRequest_Default_Action") -Or
            ($_ -eq "New-PINPushTemplate/PushNotificationTemplateRequest_GCM_Action") -Or
            ($_ -eq "Update-PINPushTemplate/PushNotificationTemplateRequest_GCM_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_ADMMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_ADMMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_APNSMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_BaiduMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_BaiduMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_GCMMessage_Action") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_GCMMessage_Action")
        }
        {
            $v = "DEEP_LINK","OPEN_APP","URL"
            break
        }

        # Amazon.Pinpoint.ChannelType
        "Update-PINEndpoint/EndpointRequest_ChannelType"
        {
            $v = "ADM","APNS","APNS_SANDBOX","APNS_VOIP","APNS_VOIP_SANDBOX","BAIDU","CUSTOM","EMAIL","GCM","SMS","VOICE"
            break
        }

        # Amazon.Pinpoint.DimensionType
        {
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_Schedule_EventFilter_Dimensions_EventType_DimensionType") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_Schedule_EventFilter_Dimensions_EventType_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType") -Or
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Location_Country_DimensionType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Location_Country_DimensionType")
        }
        {
            $v = "EXCLUSIVE","INCLUSIVE"
            break
        }

        # Amazon.Pinpoint.Duration
        {
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_Duration") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_Duration")
        }
        {
            $v = "DAY_14","DAY_30","DAY_7","HR_24"
            break
        }

        # Amazon.Pinpoint.FilterType
        {
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_Schedule_EventFilter_FilterType") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_Schedule_EventFilter_FilterType")
        }
        {
            $v = "ENDPOINT","SYSTEM"
            break
        }

        # Amazon.Pinpoint.Format
        "New-PINImportJob/ImportJobRequest_Format"
        {
            $v = "CSV","JSON"
            break
        }

        # Amazon.Pinpoint.Frequency
        {
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_Schedule_Frequency") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_Schedule_Frequency")
        }
        {
            $v = "DAILY","EVENT","HOURLY","MONTHLY","ONCE","WEEKLY"
            break
        }

        # Amazon.Pinpoint.Include
        {
            ($_ -eq "New-PINSegment/WriteSegmentRequest_SegmentGroups_Include") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_SegmentGroups_Include")
        }
        {
            $v = "ALL","ANY","NONE"
            break
        }

        # Amazon.Pinpoint.MessageType
        {
            ($_ -eq "Send-PINMessage/MessageRequest_MessageConfiguration_SMSMessage_MessageType") -Or
            ($_ -eq "Send-PINUserMessageBatch/SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType")
        }
        {
            $v = "PROMOTIONAL","TRANSACTIONAL"
            break
        }

        # Amazon.Pinpoint.Mode
        {
            ($_ -eq "Update-PINApplicationSettingList/WriteApplicationSettingsRequest_CampaignHook_Mode") -Or
            ($_ -eq "New-PINCampaign/WriteCampaignRequest_Hook_Mode") -Or
            ($_ -eq "Update-PINCampaign/WriteCampaignRequest_Hook_Mode")
        }
        {
            $v = "DELIVERY","FILTER"
            break
        }

        # Amazon.Pinpoint.RecencyType
        {
            ($_ -eq "New-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType") -Or
            ($_ -eq "Update-PINSegment/WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.Pinpoint.State
        {
            ($_ -eq "Update-PINJourneyState/JourneyStateRequest_State") -Or
            ($_ -eq "New-PINJourney/WriteJourneyRequest_State") -Or
            ($_ -eq "Update-PINJourney/WriteJourneyRequest_State")
        }
        {
            $v = "ACTIVE","CANCELLED","CLOSED","COMPLETED","DRAFT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PIN_map = @{
    "EndpointRequest_ChannelType"=@("Update-PINEndpoint")
    "ImportJobRequest_Format"=@("New-PINImportJob")
    "JourneyStateRequest_State"=@("Update-PINJourneyState")
    "MessageRequest_MessageConfiguration_ADMMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_APNSMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_BaiduMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_GCMMessage_Action"=@("Send-PINMessage")
    "MessageRequest_MessageConfiguration_SMSMessage_MessageType"=@("Send-PINMessage")
    "PushNotificationTemplateRequest_ADM_Action"=@("New-PINPushTemplate","Update-PINPushTemplate")
    "PushNotificationTemplateRequest_APNS_Action"=@("New-PINPushTemplate","Update-PINPushTemplate")
    "PushNotificationTemplateRequest_Baidu_Action"=@("New-PINPushTemplate","Update-PINPushTemplate")
    "PushNotificationTemplateRequest_Default_Action"=@("New-PINPushTemplate","Update-PINPushTemplate")
    "PushNotificationTemplateRequest_GCM_Action"=@("New-PINPushTemplate","Update-PINPushTemplate")
    "SendUsersMessageRequest_MessageConfiguration_ADMMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_APNSMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_BaiduMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_DefaultPushNotificationMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_GCMMessage_Action"=@("Send-PINUserMessageBatch")
    "SendUsersMessageRequest_MessageConfiguration_SMSMessage_MessageType"=@("Send-PINUserMessageBatch")
    "WriteApplicationSettingsRequest_CampaignHook_Mode"=@("Update-PINApplicationSettingList")
    "WriteCampaignRequest_Hook_Mode"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_ADMMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_APNSMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_BaiduMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_DefaultMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_GCMMessage_Action"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_MessageConfiguration_SMSMessage_MessageType"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_Schedule_EventFilter_Dimensions_EventType_DimensionType"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_Schedule_EventFilter_FilterType"=@("New-PINCampaign","Update-PINCampaign")
    "WriteCampaignRequest_Schedule_Frequency"=@("New-PINCampaign","Update-PINCampaign")
    "WriteJourneyRequest_State"=@("New-PINJourney","Update-PINJourney")
    "WriteSegmentRequest_Dimensions_Behavior_Recency_Duration"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Behavior_Recency_RecencyType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_AppVersion_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Channel_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_DeviceType_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Make_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Model_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Demographic_Platform_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_Dimensions_Location_Country_DimensionType"=@("New-PINSegment","Update-PINSegment")
    "WriteSegmentRequest_SegmentGroups_Include"=@("New-PINSegment","Update-PINSegment")
}

_awsArgumentCompleterRegistration $PIN_Completers $PIN_map

$PIN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PIN.$($commandName.Replace('-', ''))Cmdlet]"
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

$PIN_SelectMap = @{
    "Select"=@("New-PINApp",
               "New-PINCampaign",
               "New-PINEmailTemplate",
               "New-PINExportJob",
               "New-PINImportJob",
               "New-PINJourney",
               "New-PINPushTemplate",
               "New-PINRecommenderConfiguration",
               "New-PINSegment",
               "New-PINSmsTemplate",
               "New-PINVoiceTemplate",
               "Remove-PINAdmChannel",
               "Remove-PINApnsChannel",
               "Remove-PINApnsSandboxChannel",
               "Remove-PINApnsVoipChannel",
               "Remove-PINApnsVoipSandboxChannel",
               "Remove-PINApp",
               "Remove-PINBaiduChannel",
               "Remove-PINCampaign",
               "Remove-PINEmailChannel",
               "Remove-PINEmailTemplate",
               "Remove-PINEndpoint",
               "Remove-PINEventStream",
               "Remove-PINGcmChannel",
               "Remove-PINJourney",
               "Remove-PINPushTemplate",
               "Remove-PINRecommenderConfiguration",
               "Remove-PINSegment",
               "Remove-PINSmsChannel",
               "Remove-PINSmsTemplate",
               "Remove-PINUserEndpoint",
               "Remove-PINVoiceChannel",
               "Remove-PINVoiceTemplate",
               "Get-PINAdmChannel",
               "Get-PINApnsChannel",
               "Get-PINApnsSandboxChannel",
               "Get-PINApnsVoipChannel",
               "Get-PINApnsVoipSandboxChannel",
               "Get-PINApp",
               "Get-PINApplicationDateRangeKpi",
               "Get-PINApplicationSettingList",
               "Get-PINAppList",
               "Get-PINBaiduChannel",
               "Get-PINCampaign",
               "Get-PINCampaignActivityList",
               "Get-PINCampaignDateRangeKpi",
               "Get-PINCampaignList",
               "Get-PINCampaignVersion",
               "Get-PINCampaignVersionList",
               "Get-PINChannel",
               "Get-PINEmailChannel",
               "Get-PINEmailTemplate",
               "Get-PINEndpoint",
               "Get-PINEventStream",
               "Get-PINExportJob",
               "Get-PINExportJobList",
               "Get-PINGcmChannel",
               "Get-PINImportJob",
               "Get-PINImportJobList",
               "Get-PINJourney",
               "Get-PINJourneyDateRangeKpi",
               "Get-PINJourneyExecutionActivityMetric",
               "Get-PINJourneyExecutionMetric",
               "Get-PINPushTemplate",
               "Get-PINRecommenderConfiguration",
               "Get-PINRecommenderConfigurationList",
               "Get-PINSegment",
               "Get-PINSegmentExportJobList",
               "Get-PINSegmentImportJobList",
               "Get-PINSegmentList",
               "Get-PINSegmentVersion",
               "Get-PINSegmentVersionList",
               "Get-PINSmsChannel",
               "Get-PINSmsTemplate",
               "Get-PINUserEndpoint",
               "Get-PINVoiceChannel",
               "Get-PINVoiceTemplate",
               "Get-PINJourneyList",
               "Get-PINResourceTag",
               "Get-PINTemplateList",
               "Get-PINTemplateVersionList",
               "Confirm-PINPhoneNumber",
               "Write-PINEvent",
               "Write-PINEventStream",
               "Remove-PINAttribute",
               "Send-PINMessage",
               "Send-PINUserMessageBatch",
               "Add-PINResourceTag",
               "Remove-PINResourceTag",
               "Update-PINAdmChannel",
               "Update-PINApnsChannel",
               "Update-PINApnsSandboxChannel",
               "Update-PINApnsVoipChannel",
               "Update-PINApnsVoipSandboxChannel",
               "Update-PINApplicationSettingList",
               "Update-PINBaiduChannel",
               "Update-PINCampaign",
               "Update-PINEmailChannel",
               "Update-PINEmailTemplate",
               "Update-PINEndpoint",
               "Update-PINEndpointsBatch",
               "Update-PINGcmChannel",
               "Update-PINJourney",
               "Update-PINJourneyState",
               "Update-PINPushTemplate",
               "Update-PINRecommenderConfiguration",
               "Update-PINSegment",
               "Update-PINSmsChannel",
               "Update-PINSmsTemplate",
               "Update-PINTemplateActiveVersion",
               "Update-PINVoiceChannel",
               "Update-PINVoiceTemplate")
}

_awsArgumentCompleterRegistration $PIN_SelectCompleters $PIN_SelectMap

