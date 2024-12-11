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

# Argument completions for service Amazon Pinpoint SMS Voice V2


$SMSV_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PinpointSMSVoiceV2.KeywordAction
        "Set-SMSVKeyword/KeywordAction"
        {
            $v = "AUTOMATIC_RESPONSE","OPT_IN","OPT_OUT"
            break
        }

        # Amazon.PinpointSMSVoiceV2.LanguageCode
        "Send-SMSVDestinationNumberVerificationCode/LanguageCode"
        {
            $v = "DE_DE","EN_GB","EN_US","ES_419","ES_ES","FR_CA","FR_FR","IT_IT","JA_JP","KO_KR","PT_BR","ZH_CN","ZH_TW"
            break
        }

        # Amazon.PinpointSMSVoiceV2.MessageFeedbackStatus
        "Write-SMSVMessageFeedback/MessageFeedbackStatus"
        {
            $v = "FAILED","RECEIVED"
            break
        }

        # Amazon.PinpointSMSVoiceV2.MessageType
        {
            ($_ -eq "New-SMSVPhoneNumber/MessageType") -Or
            ($_ -eq "New-SMSVPool/MessageType") -Or
            ($_ -eq "Send-SMSVTextMessage/MessageType") -Or
            ($_ -eq "Set-SMSVDefaultMessageType/MessageType")
        }
        {
            $v = "PROMOTIONAL","TRANSACTIONAL"
            break
        }

        # Amazon.PinpointSMSVoiceV2.NumberCapability
        {
            ($_ -eq "Get-SMSVProtectConfigurationCountryRuleSet/NumberCapability") -Or
            ($_ -eq "Update-SMSVProtectConfigurationCountryRuleSet/NumberCapability")
        }
        {
            $v = "MMS","SMS","VOICE"
            break
        }

        # Amazon.PinpointSMSVoiceV2.Owner
        {
            ($_ -eq "Get-SMSVOptOutList/Owner") -Or
            ($_ -eq "Get-SMSVPhoneNumber/Owner") -Or
            ($_ -eq "Get-SMSVPool/Owner") -Or
            ($_ -eq "Get-SMSVSenderId/Owner")
        }
        {
            $v = "SELF","SHARED"
            break
        }

        # Amazon.PinpointSMSVoiceV2.ProtectConfigurationRuleOverrideAction
        "Write-SMSVProtectConfigurationRuleSetNumberOverride/Action"
        {
            $v = "ALLOW","BLOCK"
            break
        }

        # Amazon.PinpointSMSVoiceV2.RequestableNumberType
        "New-SMSVPhoneNumber/NumberType"
        {
            $v = "LONG_CODE","SIMULATOR","TEN_DLC","TOLL_FREE"
            break
        }

        # Amazon.PinpointSMSVoiceV2.VerificationChannel
        "Send-SMSVDestinationNumberVerificationCode/VerificationChannel"
        {
            $v = "TEXT","VOICE"
            break
        }

        # Amazon.PinpointSMSVoiceV2.VoiceId
        "Send-SMSVVoiceMessage/VoiceId"
        {
            $v = "AMY","ASTRID","BIANCA","BRIAN","CAMILA","CARLA","CARMEN","CELINE","CHANTAL","CONCHITA","CRISTIANO","DORA","EMMA","ENRIQUE","EWA","FILIZ","GERAINT","GIORGIO","GWYNETH","HANS","INES","IVY","JACEK","JAN","JOANNA","JOEY","JUSTIN","KARL","KENDRA","KIMBERLY","LEA","LIV","LOTTE","LUCIA","LUPE","MADS","MAJA","MARLENE","MATHIEU","MATTHEW","MAXIM","MIA","MIGUEL","MIZUKI","NAJA","NICOLE","PENELOPE","RAVEENA","RICARDO","RUBEN","RUSSELL","SALLI","SEOYEON","TAKUMI","TATYANA","VICKI","VITORIA","ZEINA","ZHIYU"
            break
        }

        # Amazon.PinpointSMSVoiceV2.VoiceMessageBodyTextType
        "Send-SMSVVoiceMessage/MessageBodyTextType"
        {
            $v = "SSML","TEXT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SMSV_map = @{
    "Action"=@("Write-SMSVProtectConfigurationRuleSetNumberOverride")
    "KeywordAction"=@("Set-SMSVKeyword")
    "LanguageCode"=@("Send-SMSVDestinationNumberVerificationCode")
    "MessageBodyTextType"=@("Send-SMSVVoiceMessage")
    "MessageFeedbackStatus"=@("Write-SMSVMessageFeedback")
    "MessageType"=@("New-SMSVPhoneNumber","New-SMSVPool","Send-SMSVTextMessage","Set-SMSVDefaultMessageType")
    "NumberCapability"=@("Get-SMSVProtectConfigurationCountryRuleSet","Update-SMSVProtectConfigurationCountryRuleSet")
    "NumberType"=@("New-SMSVPhoneNumber")
    "Owner"=@("Get-SMSVOptOutList","Get-SMSVPhoneNumber","Get-SMSVPool","Get-SMSVSenderId")
    "VerificationChannel"=@("Send-SMSVDestinationNumberVerificationCode")
    "VoiceId"=@("Send-SMSVVoiceMessage")
}

_awsArgumentCompleterRegistration $SMSV_Completers $SMSV_map

$SMSV_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SMSV.$($commandName.Replace('-', ''))Cmdlet]"
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

$SMSV_SelectMap = @{
    "Select"=@("Register-SMSVOriginationIdentity",
               "Register-SMSVProtectConfiguration",
               "New-SMSVConfigurationSet",
               "New-SMSVEventDestination",
               "New-SMSVOptOutList",
               "New-SMSVPool",
               "New-SMSVProtectConfiguration",
               "New-SMSVRegistration",
               "New-SMSVRegistrationAssociation",
               "New-SMSVRegistrationAttachment",
               "New-SMSVRegistrationVersion",
               "New-SMSVVerifiedDestinationNumber",
               "Remove-SMSVAccountDefaultProtectConfiguration",
               "Remove-SMSVConfigurationSet",
               "Remove-SMSVDefaultMessageType",
               "Remove-SMSVDefaultSenderId",
               "Remove-SMSVEventDestination",
               "Remove-SMSVKeyword",
               "Remove-SMSVMediaMessageSpendLimitOverride",
               "Remove-SMSVOptedOutNumber",
               "Remove-SMSVOptOutList",
               "Remove-SMSVPool",
               "Remove-SMSVProtectConfiguration",
               "Remove-SMSVProtectConfigurationRuleSetNumberOverride",
               "Remove-SMSVRegistration",
               "Remove-SMSVRegistrationAttachment",
               "Remove-SMSVRegistrationFieldValue",
               "Remove-SMSVResourcePolicy",
               "Remove-SMSVTextMessageSpendLimitOverride",
               "Remove-SMSVVerifiedDestinationNumber",
               "Remove-SMSVVoiceMessageSpendLimitOverride",
               "Get-SMSVAccountAttribute",
               "Get-SMSVAccountLimit",
               "Get-SMSVConfigurationSet",
               "Get-SMSVKeyword",
               "Get-SMSVOptedOutNumber",
               "Get-SMSVOptOutList",
               "Get-SMSVPhoneNumber",
               "Get-SMSVPool",
               "Get-SMSVProtectConfiguration",
               "Get-SMSVRegistrationAttachment",
               "Get-SMSVRegistrationFieldDefinition",
               "Get-SMSVRegistrationFieldValue",
               "Get-SMSVRegistration",
               "Get-SMSVRegistrationSectionDefinition",
               "Get-SMSVRegistrationTypeDefinition",
               "Get-SMSVRegistrationVersion",
               "Get-SMSVSenderId",
               "Get-SMSVSpendLimit",
               "Get-SMSVVerifiedDestinationNumber",
               "Unregister-SMSVOriginationIdentity",
               "Unregister-SMSVProtectConfiguration",
               "Close-SMSVRegistrationVersion",
               "Get-SMSVProtectConfigurationCountryRuleSet",
               "Get-SMSVResourcePolicy",
               "Get-SMSVPoolOriginationIdentityList",
               "Get-SMSVProtectConfigurationRuleSetNumberOverrideList",
               "Get-SMSVRegistrationAssociationList",
               "Get-SMSVResourceTagList",
               "Set-SMSVKeyword",
               "Write-SMSVMessageFeedback",
               "Set-SMSVOptedOutNumber",
               "Write-SMSVProtectConfigurationRuleSetNumberOverride",
               "Set-SMSVRegistrationFieldValue",
               "Write-SMSVResourcePolicy",
               "Remove-SMSVPhoneNumber",
               "Remove-SMSVSenderId",
               "New-SMSVPhoneNumber",
               "Request-SMSVSenderId",
               "Send-SMSVDestinationNumberVerificationCode",
               "Send-SMSVMediaMessage",
               "Send-SMSVTextMessage",
               "Send-SMSVVoiceMessage",
               "Set-SMSVAccountDefaultProtectConfiguration",
               "Set-SMSVDefaultMessageFeedbackEnabled",
               "Set-SMSVDefaultMessageType",
               "Set-SMSVDefaultSenderId",
               "Set-SMSVMediaMessageSpendLimitOverride",
               "Set-SMSVTextMessageSpendLimitOverride",
               "Set-SMSVVoiceMessageSpendLimitOverride",
               "Submit-SMSVRegistrationVersion",
               "Add-SMSVResourceTag",
               "Remove-SMSVResourceTag",
               "Update-SMSVEventDestination",
               "Update-SMSVPhoneNumber",
               "Update-SMSVPool",
               "Update-SMSVProtectConfiguration",
               "Update-SMSVProtectConfigurationCountryRuleSet",
               "Update-SMSVSenderId",
               "Confirm-SMSVDestinationNumber")
}

_awsArgumentCompleterRegistration $SMSV_SelectCompleters $SMSV_SelectMap

