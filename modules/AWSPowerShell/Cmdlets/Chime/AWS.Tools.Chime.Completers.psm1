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

# Argument completions for service Amazon Chime


$CHM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Chime.GeoMatchLevel
        "New-CHMProxySession/GeoMatchLevel"
        {
            $v = "AreaCode","Country"
            break
        }

        # Amazon.Chime.License
        "Update-CHMUser/LicenseType"
        {
            $v = "Basic","Plus","Pro","ProTrial"
            break
        }

        # Amazon.Chime.NumberSelectionBehavior
        "New-CHMProxySession/NumberSelectionBehavior"
        {
            $v = "AvoidSticky","PreferSticky"
            break
        }

        # Amazon.Chime.PhoneNumberAssociationName
        "Get-CHMPhoneNumberList/FilterName"
        {
            $v = "AccountId","UserId","VoiceConnectorGroupId","VoiceConnectorId"
            break
        }

        # Amazon.Chime.PhoneNumberProductType
        {
            ($_ -eq "Get-CHMPhoneNumberList/ProductType") -Or
            ($_ -eq "New-CHMPhoneNumberOrder/ProductType") -Or
            ($_ -eq "Update-CHMPhoneNumber/ProductType")
        }
        {
            $v = "BusinessCalling","VoiceConnector"
            break
        }

        # Amazon.Chime.PhoneNumberStatus
        "Get-CHMPhoneNumberList/Status"
        {
            $v = "AcquireFailed","AcquireInProgress","Assigned","DeleteFailed","DeleteInProgress","ReleaseFailed","ReleaseInProgress","Unassigned"
            break
        }

        # Amazon.Chime.ProxySessionStatus
        "Get-CHMProxySessionList/Status"
        {
            $v = "Closed","InProgress","Open"
            break
        }

        # Amazon.Chime.RoomMembershipRole
        {
            ($_ -eq "New-CHMRoomMembership/Role") -Or
            ($_ -eq "Update-CHMRoomMembership/Role")
        }
        {
            $v = "Administrator","Member"
            break
        }

        # Amazon.Chime.UserType
        {
            ($_ -eq "Get-CHMUserList/UserType") -Or
            ($_ -eq "New-CHMUser/UserType") -Or
            ($_ -eq "Send-CHMUserInvitation/UserType") -Or
            ($_ -eq "Update-CHMUser/UserType")
        }
        {
            $v = "PrivateUser","SharedDevice"
            break
        }

        # Amazon.Chime.VoiceConnectorAwsRegion
        "New-CHMVoiceConnector/AwsRegion"
        {
            $v = "us-east-1","us-west-2"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CHM_map = @{
    "AwsRegion"=@("New-CHMVoiceConnector")
    "FilterName"=@("Get-CHMPhoneNumberList")
    "GeoMatchLevel"=@("New-CHMProxySession")
    "LicenseType"=@("Update-CHMUser")
    "NumberSelectionBehavior"=@("New-CHMProxySession")
    "ProductType"=@("Get-CHMPhoneNumberList","New-CHMPhoneNumberOrder","Update-CHMPhoneNumber")
    "Role"=@("New-CHMRoomMembership","Update-CHMRoomMembership")
    "Status"=@("Get-CHMPhoneNumberList","Get-CHMProxySessionList")
    "UserType"=@("Get-CHMUserList","New-CHMUser","Send-CHMUserInvitation","Update-CHMUser")
}

_awsArgumentCompleterRegistration $CHM_Completers $CHM_map

$CHM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CHM.$($commandName.Replace('-', ''))Cmdlet]"
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

$CHM_SelectMap = @{
    "Select"=@("Add-CHMPhoneNumbersToVoiceConnector",
               "Add-CHMPhoneNumbersToVoiceConnectorGroup",
               "Add-CHMPhoneNumberToUser",
               "Add-CHMSigninDelegateGroupsToAccount",
               "New-CHMAttendeeBatch",
               "New-CHMRoomMembershipBatch",
               "Remove-CHMPhoneNumberBatch",
               "Enable-CHMUserSuspensionBatch",
               "Disable-CHMUserSuspensionBatch",
               "Update-CHMPhoneNumberBatch",
               "Update-CHMUserBatch",
               "New-CHMAccount",
               "New-CHMAttendee",
               "New-CHMBot",
               "New-CHMMeeting",
               "New-CHMMeetingWithAttendee",
               "New-CHMPhoneNumberOrder",
               "New-CHMProxySession",
               "New-CHMRoom",
               "New-CHMRoomMembership",
               "New-CHMUser",
               "New-CHMVoiceConnector",
               "New-CHMVoiceConnectorGroup",
               "Remove-CHMAccount",
               "Remove-CHMAttendee",
               "Remove-CHMEventsConfiguration",
               "Remove-CHMMeeting",
               "Remove-CHMPhoneNumber",
               "Remove-CHMProxySession",
               "Remove-CHMRoom",
               "Remove-CHMRoomMembership",
               "Remove-CHMVoiceConnector",
               "Remove-CHMVoiceConnectorEmergencyCallingConfiguration",
               "Remove-CHMVoiceConnectorGroup",
               "Remove-CHMVoiceConnectorOrigination",
               "Remove-CHMVoiceConnectorProxy",
               "Remove-CHMVoiceConnectorStreamingConfiguration",
               "Remove-CHMVoiceConnectorTermination",
               "Remove-CHMVoiceConnectorTerminationCredential",
               "Remove-CHMPhoneNumberFromUser",
               "Remove-CHMPhoneNumbersFromVoiceConnector",
               "Remove-CHMPhoneNumbersFromVoiceConnectorGroup",
               "Remove-CHMSigninDelegateGroupsFromAccount",
               "Get-CHMAccount",
               "Get-CHMAccountSetting",
               "Get-CHMAttendee",
               "Get-CHMBot",
               "Get-CHMEventsConfiguration",
               "Get-CHMGlobalSetting",
               "Get-CHMMeeting",
               "Get-CHMPhoneNumber",
               "Get-CHMPhoneNumberOrder",
               "Get-CHMPhoneNumberSetting",
               "Get-CHMProxySession",
               "Get-CHMRetentionSetting",
               "Get-CHMRoom",
               "Get-CHMUser",
               "Get-CHMUserSetting",
               "Get-CHMVoiceConnector",
               "Get-CHMVoiceConnectorEmergencyCallingConfiguration",
               "Get-CHMVoiceConnectorGroup",
               "Get-CHMVoiceConnectorLoggingConfiguration",
               "Get-CHMVoiceConnectorOrigination",
               "Get-CHMVoiceConnectorProxy",
               "Get-CHMVoiceConnectorStreamingConfiguration",
               "Get-CHMVoiceConnectorTermination",
               "Get-CHMVoiceConnectorTerminationHealth",
               "Send-CHMUserInvitation",
               "Get-CHMAccountList",
               "Get-CHMAttendeeList",
               "Get-CHMAttendeeTagList",
               "Get-CHMBotList",
               "Get-CHMMeetingList",
               "Get-CHMMeetingTagList",
               "Get-CHMPhoneNumberOrderList",
               "Get-CHMPhoneNumberList",
               "Get-CHMProxySessionList",
               "Get-CHMRoomMembershipList",
               "Get-CHMRoomList",
               "Get-CHMResourceTag",
               "Get-CHMUserList",
               "Get-CHMVoiceConnectorGroupList",
               "Get-CHMVoiceConnectorList",
               "Get-CHMVoiceConnectorTerminationCredentialList",
               "Invoke-CHMUserLogout",
               "Write-CHMEventsConfiguration",
               "Write-CHMRetentionSetting",
               "Write-CHMVoiceConnectorEmergencyCallingConfiguration",
               "Write-CHMVoiceConnectorLoggingConfiguration",
               "Write-CHMVoiceConnectorOrigination",
               "Write-CHMVoiceConnectorProxy",
               "Write-CHMVoiceConnectorStreamingConfiguration",
               "Write-CHMVoiceConnectorTermination",
               "Write-CHMVoiceConnectorTerminationCredential",
               "Hide-CHMConversationMessage",
               "Hide-CHMRoomMessage",
               "Update-CHMSecurityToken",
               "Reset-CHMPersonalPIN",
               "Restore-CHMPhoneNumber",
               "Search-CHMAvailablePhoneNumber",
               "Add-CHMAttendee",
               "Add-CHMMeeting",
               "Add-CHMResourceTag",
               "Remove-CHMAttendeeTag",
               "Remove-CHMMeetingTag",
               "Remove-CHMResourceTag",
               "Update-CHMAccount",
               "Update-CHMAccountSetting",
               "Update-CHMBot",
               "Update-CHMGlobalSetting",
               "Update-CHMPhoneNumber",
               "Update-CHMPhoneNumberSetting",
               "Update-CHMProxySession",
               "Update-CHMRoom",
               "Update-CHMRoomMembership",
               "Update-CHMUser",
               "Update-CHMUserSetting",
               "Update-CHMVoiceConnector",
               "Update-CHMVoiceConnectorGroup")
}

_awsArgumentCompleterRegistration $CHM_SelectCompleters $CHM_SelectMap

