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

# Argument completions for service Amazon Chime SDK Voice


$CHMVO_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ChimeSDKVoice.AlexaSkillStatus
        "Write-CHMVOSipMediaApplicationAlexaSkillConfiguration/SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus"
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.ChimeSDKVoice.CallLegType
        "Start-CHMVOSpeakerSearchTask/CallLeg"
        {
            $v = "Callee","Caller"
            break
        }

        # Amazon.ChimeSDKVoice.GeoMatchLevel
        "New-CHMVOProxySession/GeoMatchLevel"
        {
            $v = "AreaCode","Country"
            break
        }

        # Amazon.ChimeSDKVoice.LanguageCode
        "Start-CHMVOVoiceToneAnalysisTask/LanguageCode"
        {
            $v = "en-US"
            break
        }

        # Amazon.ChimeSDKVoice.NetworkType
        "New-CHMVOVoiceConnector/NetworkType"
        {
            $v = "DUAL_STACK","IPV4_ONLY"
            break
        }

        # Amazon.ChimeSDKVoice.NumberSelectionBehavior
        "New-CHMVOProxySession/NumberSelectionBehavior"
        {
            $v = "AvoidSticky","PreferSticky"
            break
        }

        # Amazon.ChimeSDKVoice.PhoneNumberAssociationName
        "Get-CHMVOPhoneNumberList/FilterName"
        {
            $v = "SipRuleId","VoiceConnectorGroupId","VoiceConnectorId"
            break
        }

        # Amazon.ChimeSDKVoice.PhoneNumberProductType
        {
            ($_ -eq "Get-CHMVOPhoneNumberList/ProductType") -Or
            ($_ -eq "Get-CHMVOSupportedPhoneNumberCountryList/ProductType") -Or
            ($_ -eq "New-CHMVOPhoneNumberOrder/ProductType") -Or
            ($_ -eq "Update-CHMVOPhoneNumber/ProductType")
        }
        {
            $v = "SipMediaApplicationDialIn","VoiceConnector"
            break
        }

        # Amazon.ChimeSDKVoice.PhoneNumberType
        "Search-CHMVOAvailablePhoneNumber/PhoneNumberType"
        {
            $v = "Local","TollFree"
            break
        }

        # Amazon.ChimeSDKVoice.ProxySessionStatus
        "Get-CHMVOProxySessionList/Status"
        {
            $v = "Closed","InProgress","Open"
            break
        }

        # Amazon.ChimeSDKVoice.SipRuleTriggerType
        "New-CHMVOSipRule/TriggerType"
        {
            $v = "RequestUriHostname","ToPhoneNumber"
            break
        }

        # Amazon.ChimeSDKVoice.VoiceConnectorAwsRegion
        "New-CHMVOVoiceConnector/AwsRegion"
        {
            $v = "ap-northeast-1","ap-northeast-2","ap-southeast-1","ap-southeast-2","ca-central-1","eu-central-1","eu-west-1","eu-west-2","us-east-1","us-west-2"
            break
        }

        # Amazon.ChimeSDKVoice.VoiceConnectorIntegrationType
        "New-CHMVOVoiceConnector/IntegrationType"
        {
            $v = "CONNECT_ANALYTICS_CONNECTOR","CONNECT_CALL_TRANSFER_CONNECTOR"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CHMVO_map = @{
    "AwsRegion"=@("New-CHMVOVoiceConnector")
    "CallLeg"=@("Start-CHMVOSpeakerSearchTask")
    "FilterName"=@("Get-CHMVOPhoneNumberList")
    "GeoMatchLevel"=@("New-CHMVOProxySession")
    "IntegrationType"=@("New-CHMVOVoiceConnector")
    "LanguageCode"=@("Start-CHMVOVoiceToneAnalysisTask")
    "NetworkType"=@("New-CHMVOVoiceConnector")
    "NumberSelectionBehavior"=@("New-CHMVOProxySession")
    "PhoneNumberType"=@("Search-CHMVOAvailablePhoneNumber")
    "ProductType"=@("Get-CHMVOPhoneNumberList","Get-CHMVOSupportedPhoneNumberCountryList","New-CHMVOPhoneNumberOrder","Update-CHMVOPhoneNumber")
    "SipMediaApplicationAlexaSkillConfiguration_AlexaSkillStatus"=@("Write-CHMVOSipMediaApplicationAlexaSkillConfiguration")
    "Status"=@("Get-CHMVOProxySessionList")
    "TriggerType"=@("New-CHMVOSipRule")
}

_awsArgumentCompleterRegistration $CHMVO_Completers $CHMVO_map

$CHMVO_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CHMVO.$($commandName.Replace('-', ''))Cmdlet]"
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

$CHMVO_SelectMap = @{
    "Select"=@("Add-CHMVOPhoneNumbersWithVoiceConnector",
               "Add-CHMVOPhoneNumbersWithVoiceConnectorGroup",
               "Group-CHMVODeletePhoneNumber",
               "Group-CHMVOUpdatePhoneNumber",
               "New-CHMVOPhoneNumberOrder",
               "New-CHMVOProxySession",
               "New-CHMVOSipMediaApplication",
               "New-CHMVOSipMediaApplicationCall",
               "New-CHMVOSipRule",
               "New-CHMVOVoiceConnector",
               "New-CHMVOVoiceConnectorGroup",
               "New-CHMVOVoiceProfile",
               "New-CHMVOVoiceProfileDomain",
               "Remove-CHMVOPhoneNumber",
               "Remove-CHMVOProxySession",
               "Remove-CHMVOSipMediaApplication",
               "Remove-CHMVOSipRule",
               "Remove-CHMVOVoiceConnector",
               "Remove-CHMVOVoiceConnectorEmergencyCallingConfiguration",
               "Remove-CHMVOVoiceConnectorExternalSystemsConfiguration",
               "Remove-CHMVOVoiceConnectorGroup",
               "Remove-CHMVOVoiceConnectorOrigination",
               "Remove-CHMVOVoiceConnectorProxy",
               "Remove-CHMVOVoiceConnectorStreamingConfiguration",
               "Remove-CHMVOVoiceConnectorTermination",
               "Remove-CHMVOVoiceConnectorTerminationCredential",
               "Remove-CHMVOVoiceProfile",
               "Remove-CHMVOVoiceProfileDomain",
               "Remove-CHMVOPhoneNumbersFromVoiceConnector",
               "Remove-CHMVOPhoneNumbersFromVoiceConnectorGroup",
               "Get-CHMVOGlobalSetting",
               "Get-CHMVOPhoneNumber",
               "Get-CHMVOPhoneNumberOrder",
               "Get-CHMVOPhoneNumberSetting",
               "Get-CHMVOProxySession",
               "Get-CHMVOSipMediaApplication",
               "Get-CHMVOSipMediaApplicationAlexaSkillConfiguration",
               "Get-CHMVOSipMediaApplicationLoggingConfiguration",
               "Get-CHMVOSipRule",
               "Get-CHMVOSpeakerSearchTask",
               "Get-CHMVOVoiceConnector",
               "Get-CHMVOVoiceConnectorEmergencyCallingConfiguration",
               "Get-CHMVOVoiceConnectorExternalSystemsConfiguration",
               "Get-CHMVOVoiceConnectorGroup",
               "Get-CHMVOVoiceConnectorLoggingConfiguration",
               "Get-CHMVOVoiceConnectorOrigination",
               "Get-CHMVOVoiceConnectorProxy",
               "Get-CHMVOVoiceConnectorStreamingConfiguration",
               "Get-CHMVOVoiceConnectorTermination",
               "Get-CHMVOVoiceConnectorTerminationHealth",
               "Get-CHMVOVoiceProfile",
               "Get-CHMVOVoiceProfileDomain",
               "Get-CHMVOVoiceToneAnalysisTask",
               "Get-CHMVOAvailableVoiceConnectorRegionList",
               "Get-CHMVOPhoneNumberOrderList",
               "Get-CHMVOPhoneNumberList",
               "Get-CHMVOProxySessionList",
               "Get-CHMVOSipMediaApplicationList",
               "Get-CHMVOSipRuleList",
               "Get-CHMVOSupportedPhoneNumberCountryList",
               "Get-CHMVOResourceTag",
               "Get-CHMVOVoiceConnectorGroupList",
               "Get-CHMVOVoiceConnectorList",
               "Get-CHMVOVoiceConnectorTerminationCredentialList",
               "Get-CHMVOVoiceProfileDomainList",
               "Get-CHMVOVoiceProfileList",
               "Write-CHMVOSipMediaApplicationAlexaSkillConfiguration",
               "Write-CHMVOSipMediaApplicationLoggingConfiguration",
               "Write-CHMVOVoiceConnectorEmergencyCallingConfiguration",
               "Write-CHMVOVoiceConnectorExternalSystemsConfiguration",
               "Write-CHMVOVoiceConnectorLoggingConfiguration",
               "Write-CHMVOVoiceConnectorOrigination",
               "Write-CHMVOVoiceConnectorProxy",
               "Write-CHMVOVoiceConnectorStreamingConfiguration",
               "Write-CHMVOVoiceConnectorTermination",
               "Write-CHMVOVoiceConnectorTerminationCredential",
               "Restore-CHMVOPhoneNumber",
               "Search-CHMVOAvailablePhoneNumber",
               "Start-CHMVOSpeakerSearchTask",
               "Start-CHMVOVoiceToneAnalysisTask",
               "Stop-CHMVOSpeakerSearchTask",
               "Stop-CHMVOVoiceToneAnalysisTask",
               "Add-CHMVOResourceTag",
               "Remove-CHMVOResourceTag",
               "Update-CHMVOGlobalSetting",
               "Update-CHMVOPhoneNumber",
               "Update-CHMVOPhoneNumberSetting",
               "Update-CHMVOProxySession",
               "Update-CHMVOSipMediaApplication",
               "Update-CHMVOSipMediaApplicationCall",
               "Update-CHMVOSipRule",
               "Update-CHMVOVoiceConnector",
               "Update-CHMVOVoiceConnectorGroup",
               "Update-CHMVOVoiceProfile",
               "Update-CHMVOVoiceProfileDomain",
               "Confirm-CHMVOE911Address")
}

_awsArgumentCompleterRegistration $CHMVO_SelectCompleters $CHMVO_SelectMap

