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

# Argument completions for service Amazon Chime SDK Messaging


$CHMMG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ChimeSDKMessaging.AllowNotifications
        "Write-CHMMGChannelMembershipPreference/Preferences_PushNotifications_AllowNotifications"
        {
            $v = "ALL","FILTERED","NONE"
            break
        }

        # Amazon.ChimeSDKMessaging.ChannelMembershipType
        {
            ($_ -eq "Get-CHMMGChannelMembershipList/Type") -Or
            ($_ -eq "New-CHMMGChannelMembership/Type") -Or
            ($_ -eq "New-CHMMGCreateChannelMembership/Type")
        }
        {
            $v = "DEFAULT","HIDDEN"
            break
        }

        # Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType
        "Send-CHMMGChannelMessage/Persistence"
        {
            $v = "NON_PERSISTENT","PERSISTENT"
            break
        }

        # Amazon.ChimeSDKMessaging.ChannelMessageType
        "Send-CHMMGChannelMessage/Type"
        {
            $v = "CONTROL","STANDARD"
            break
        }

        # Amazon.ChimeSDKMessaging.ChannelMode
        {
            ($_ -eq "New-CHMMGChannel/Mode") -Or
            ($_ -eq "Update-CHMMGChannel/Mode")
        }
        {
            $v = "RESTRICTED","UNRESTRICTED"
            break
        }

        # Amazon.ChimeSDKMessaging.ChannelPrivacy
        {
            ($_ -eq "Get-CHMMGChannelList/Privacy") -Or
            ($_ -eq "New-CHMMGChannel/Privacy")
        }
        {
            $v = "PRIVATE","PUBLIC"
            break
        }

        # Amazon.ChimeSDKMessaging.PushNotificationType
        {
            ($_ -eq "Send-CHMMGChannelFlowCallback/ChannelMessage_PushNotification_Type") -Or
            ($_ -eq "Send-CHMMGChannelMessage/PushNotification_Type")
        }
        {
            $v = "DEFAULT","VOIP"
            break
        }

        # Amazon.ChimeSDKMessaging.SortOrder
        "Get-CHMMGChannelMessageList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CHMMG_map = @{
    "ChannelMessage_PushNotification_Type"=@("Send-CHMMGChannelFlowCallback")
    "Mode"=@("New-CHMMGChannel","Update-CHMMGChannel")
    "Persistence"=@("Send-CHMMGChannelMessage")
    "Preferences_PushNotifications_AllowNotifications"=@("Write-CHMMGChannelMembershipPreference")
    "Privacy"=@("Get-CHMMGChannelList","New-CHMMGChannel")
    "PushNotification_Type"=@("Send-CHMMGChannelMessage")
    "SortOrder"=@("Get-CHMMGChannelMessageList")
    "Type"=@("Get-CHMMGChannelMembershipList","New-CHMMGChannelMembership","New-CHMMGCreateChannelMembership","Send-CHMMGChannelMessage")
}

_awsArgumentCompleterRegistration $CHMMG_Completers $CHMMG_map

$CHMMG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CHMMG.$($commandName.Replace('-', ''))Cmdlet]"
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

$CHMMG_SelectMap = @{
    "Select"=@("Register-CHMMGChannelFlow",
               "New-CHMMGCreateChannelMembership",
               "Send-CHMMGChannelFlowCallback",
               "New-CHMMGChannel",
               "New-CHMMGChannelBan",
               "New-CHMMGChannelFlow",
               "New-CHMMGChannelMembership",
               "New-CHMMGChannelModerator",
               "Remove-CHMMGChannel",
               "Remove-CHMMGChannelBan",
               "Remove-CHMMGChannelFlow",
               "Remove-CHMMGChannelMembership",
               "Remove-CHMMGChannelMessage",
               "Remove-CHMMGChannelModerator",
               "Get-CHMMGChannel",
               "Get-CHMMGChannelBan",
               "Get-CHMMGChannelFlow",
               "Get-CHMMGChannelMembership",
               "Get-CHMMGChannelMembershipForAppInstanceUser",
               "Get-CHMMGChannelModeratedByAppInstanceUser",
               "Get-CHMMGChannelModerator",
               "Unregister-CHMMGChannelFlow",
               "Get-CHMMGChannelMembershipPreference",
               "Get-CHMMGChannelMessage",
               "Get-CHMMGChannelMessageStatus",
               "Get-CHMMGMessagingSessionEndpoint",
               "Get-CHMMGChannelBanList",
               "Get-CHMMGChannelFlowList",
               "Get-CHMMGChannelMembershipList",
               "Get-CHMMGChannelMembershipsForAppInstanceUserList",
               "Get-CHMMGChannelMessageList",
               "Get-CHMMGChannelModeratorList",
               "Get-CHMMGChannelList",
               "Get-CHMMGChannelsAssociatedWithChannelFlowList",
               "Get-CHMMGChannelsModeratedByAppInstanceUserList",
               "Get-CHMMGResourceTag",
               "Write-CHMMGChannelMembershipPreference",
               "Hide-CHMMGChannelMessage",
               "Send-CHMMGChannelMessage",
               "Add-CHMMGResourceTag",
               "Remove-CHMMGResourceTag",
               "Update-CHMMGChannel",
               "Update-CHMMGChannelFlow",
               "Update-CHMMGChannelMessage",
               "Update-CHMMGChannelReadMarker")
}

_awsArgumentCompleterRegistration $CHMMG_SelectCompleters $CHMMG_SelectMap

