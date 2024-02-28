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

# Argument completions for service Alexa For Business


$ALXB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AlexaForBusiness.BusinessReportFormat
        {
            ($_ -eq "New-ALXBBusinessReportSchedule/Format") -Or
            ($_ -eq "Update-ALXBBusinessReportSchedule/Format")
        }
        {
            $v = "CSV","CSV_ZIP"
            break
        }

        # Amazon.AlexaForBusiness.BusinessReportInterval
        "New-ALXBBusinessReportSchedule/ContentRange_Interval"
        {
            $v = "ONE_DAY","ONE_WEEK","THIRTY_DAYS"
            break
        }

        # Amazon.AlexaForBusiness.CommsProtocol
        {
            ($_ -eq "New-ALXBConferenceProvider/IPDialIn_CommsProtocol") -Or
            ($_ -eq "Update-ALXBConferenceProvider/IPDialIn_CommsProtocol")
        }
        {
            $v = "H323","SIP","SIPS"
            break
        }

        # Amazon.AlexaForBusiness.ConferenceProviderType
        {
            ($_ -eq "New-ALXBConferenceProvider/ConferenceProviderType") -Or
            ($_ -eq "Update-ALXBConferenceProvider/ConferenceProviderType")
        }
        {
            $v = "BLUEJEANS","CHIME","CUSTOM","FUZE","GOOGLE_HANGOUTS","POLYCOM","RINGCENTRAL","SKYPE_FOR_BUSINESS","WEBEX","ZOOM"
            break
        }

        # Amazon.AlexaForBusiness.DeviceEventType
        "Get-ALXBDeviceEventList/EventType"
        {
            $v = "CONNECTION_STATUS","DEVICE_STATUS"
            break
        }

        # Amazon.AlexaForBusiness.DeviceUsageType
        "Remove-ALXBDeviceUsageData/DeviceUsageType"
        {
            $v = "VOICE"
            break
        }

        # Amazon.AlexaForBusiness.DistanceUnit
        {
            ($_ -eq "New-ALXBProfile/DistanceUnit") -Or
            ($_ -eq "Update-ALXBProfile/DistanceUnit")
        }
        {
            $v = "IMPERIAL","METRIC"
            break
        }

        # Amazon.AlexaForBusiness.EnablementTypeFilter
        "Get-ALXBSkillList/EnablementType"
        {
            $v = "ENABLED","PENDING"
            break
        }

        # Amazon.AlexaForBusiness.EndOfMeetingReminderType
        {
            ($_ -eq "New-ALXBProfile/EndOfMeetingReminder_ReminderType") -Or
            ($_ -eq "Update-ALXBProfile/EndOfMeetingReminder_ReminderType")
        }
        {
            $v = "ANNOUNCEMENT_TIME_CHECK","ANNOUNCEMENT_VARIABLE_TIME_LEFT","CHIME","KNOCK"
            break
        }

        # Amazon.AlexaForBusiness.NetworkEapMethod
        "New-ALXBNetworkProfile/EapMethod"
        {
            $v = "EAP_TLS"
            break
        }

        # Amazon.AlexaForBusiness.NetworkSecurityType
        "New-ALXBNetworkProfile/SecurityType"
        {
            $v = "OPEN","WEP","WPA2_ENTERPRISE","WPA2_PSK","WPA_PSK"
            break
        }

        # Amazon.AlexaForBusiness.RequirePin
        {
            ($_ -eq "New-ALXBConferenceProvider/MeetingSetting_RequirePin") -Or
            ($_ -eq "Update-ALXBConferenceProvider/MeetingSetting_RequirePin")
        }
        {
            $v = "NO","OPTIONAL","YES"
            break
        }

        # Amazon.AlexaForBusiness.SkillTypeFilter
        "Get-ALXBSkillList/SkillType"
        {
            $v = "ALL","PRIVATE","PUBLIC"
            break
        }

        # Amazon.AlexaForBusiness.TemperatureUnit
        {
            ($_ -eq "New-ALXBProfile/TemperatureUnit") -Or
            ($_ -eq "Update-ALXBProfile/TemperatureUnit")
        }
        {
            $v = "CELSIUS","FAHRENHEIT"
            break
        }

        # Amazon.AlexaForBusiness.WakeWord
        {
            ($_ -eq "New-ALXBProfile/WakeWord") -Or
            ($_ -eq "Update-ALXBProfile/WakeWord")
        }
        {
            $v = "ALEXA","AMAZON","COMPUTER","ECHO"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ALXB_map = @{
    "ConferenceProviderType"=@("New-ALXBConferenceProvider","Update-ALXBConferenceProvider")
    "ContentRange_Interval"=@("New-ALXBBusinessReportSchedule")
    "DeviceUsageType"=@("Remove-ALXBDeviceUsageData")
    "DistanceUnit"=@("New-ALXBProfile","Update-ALXBProfile")
    "EapMethod"=@("New-ALXBNetworkProfile")
    "EnablementType"=@("Get-ALXBSkillList")
    "EndOfMeetingReminder_ReminderType"=@("New-ALXBProfile","Update-ALXBProfile")
    "EventType"=@("Get-ALXBDeviceEventList")
    "Format"=@("New-ALXBBusinessReportSchedule","Update-ALXBBusinessReportSchedule")
    "IPDialIn_CommsProtocol"=@("New-ALXBConferenceProvider","Update-ALXBConferenceProvider")
    "MeetingSetting_RequirePin"=@("New-ALXBConferenceProvider","Update-ALXBConferenceProvider")
    "SecurityType"=@("New-ALXBNetworkProfile")
    "SkillType"=@("Get-ALXBSkillList")
    "TemperatureUnit"=@("New-ALXBProfile","Update-ALXBProfile")
    "WakeWord"=@("New-ALXBProfile","Update-ALXBProfile")
}

_awsArgumentCompleterRegistration $ALXB_Completers $ALXB_map

$ALXB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ALXB.$($commandName.Replace('-', ''))Cmdlet]"
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

$ALXB_SelectMap = @{
    "Select"=@("Approve-ALXBSkill",
               "Add-ALXBContactToAddressBook",
               "Add-ALXBDeviceToNetworkProfile",
               "Add-ALXBDeviceToRoom",
               "Add-ALXBSkillGroupToRoom",
               "Add-ALXBSkillToSkillGroup",
               "Add-ALXBSkillToUser",
               "New-ALXBAddressBook",
               "New-ALXBBusinessReportSchedule",
               "New-ALXBConferenceProvider",
               "New-ALXBContact",
               "New-ALXBGatewayGroup",
               "New-ALXBNetworkProfile",
               "New-ALXBProfile",
               "New-ALXBRoom",
               "New-ALXBSkillGroup",
               "New-ALXBUser",
               "Remove-ALXBAddressBook",
               "Remove-ALXBBusinessReportSchedule",
               "Remove-ALXBConferenceProvider",
               "Remove-ALXBContact",
               "Remove-ALXBDevice",
               "Remove-ALXBDeviceUsageData",
               "Remove-ALXBGatewayGroup",
               "Remove-ALXBNetworkProfile",
               "Remove-ALXBProfile",
               "Remove-ALXBRoom",
               "Remove-ALXBRoomSkillParameter",
               "Remove-ALXBSkillAuthorization",
               "Remove-ALXBSkillGroup",
               "Remove-ALXBUser",
               "Remove-ALXBContactFromAddressBook",
               "Remove-ALXBDeviceFromRoom",
               "Remove-ALXBSkillFromSkillGroup",
               "Remove-ALXBSkillFromUser",
               "Remove-ALXBSkillGroupFromRoom",
               "Remove-ALXBSmartHomeAppliance",
               "Get-ALXBAddressBook",
               "Get-ALXBConferencePreference",
               "Get-ALXBConferenceProvider",
               "Get-ALXBContact",
               "Get-ALXBDevice",
               "Get-ALXBGateway",
               "Get-ALXBGatewayGroup",
               "Get-ALXBInvitationConfiguration",
               "Get-ALXBNetworkProfile",
               "Get-ALXBProfile",
               "Get-ALXBRoom",
               "Get-ALXBRoomSkillParameter",
               "Get-ALXBSkillGroup",
               "Get-ALXBBusinessReportScheduleList",
               "Get-ALXBConferenceProviderList",
               "Get-ALXBDeviceEventList",
               "Get-ALXBGatewayGroupList",
               "Get-ALXBGatewayList",
               "Get-ALXBSkillList",
               "Get-ALXBSkillsStoreCategoryList",
               "Get-ALXBSkillsStoreSkillListByCategory",
               "Get-ALXBSmartHomeApplianceList",
               "Get-ALXBTagList",
               "Write-ALXBConferencePreference",
               "Write-ALXBInvitationConfiguration",
               "Set-ALXBRoomSkillParameter",
               "Write-ALXBSkillAuthorization",
               "Register-ALXBAVSDevice",
               "Deny-ALXBSkill",
               "Resolve-ALXBRoom",
               "Revoke-ALXBInvitation",
               "Search-ALXBAddressBook",
               "Search-ALXBContact",
               "Find-ALXBDevice",
               "Search-ALXBNetworkProfile",
               "Find-ALXBProfile",
               "Find-ALXBRoom",
               "Find-ALXBSkillGroup",
               "Find-ALXBUser",
               "Send-ALXBAnnouncement",
               "Send-ALXBInvitation",
               "Start-ALXBDeviceSync",
               "Start-ALXBSmartHomeApplianceDiscovery",
               "Add-ALXBResourceTag",
               "Remove-ALXBResourceTag",
               "Update-ALXBAddressBook",
               "Update-ALXBBusinessReportSchedule",
               "Update-ALXBConferenceProvider",
               "Update-ALXBContact",
               "Update-ALXBDevice",
               "Update-ALXBGateway",
               "Update-ALXBGatewayGroup",
               "Update-ALXBNetworkProfile",
               "Update-ALXBProfile",
               "Update-ALXBRoom",
               "Update-ALXBSkillGroup")
}

_awsArgumentCompleterRegistration $ALXB_SelectCompleters $ALXB_SelectMap

