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

# Argument completions for service AWS Wickr Admin API


$WIC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Wickr.AccessLevel
        "New-WICNetwork/AccessLevel"
        {
            $v = "PREMIUM","STANDARD"
            break
        }

        # Amazon.Wickr.DataRetentionActionType
        "Update-WICDataRetention/ActionType"
        {
            $v = "DISABLE","ENABLE","PUBKEY_MSG_ACK"
            break
        }

        # Amazon.Wickr.SortDirection
        {
            ($_ -eq "Get-WICBlockedGuestUserList/SortDirection") -Or
            ($_ -eq "Get-WICBotList/SortDirection") -Or
            ($_ -eq "Get-WICDevicesForUserList/SortDirection") -Or
            ($_ -eq "Get-WICGuestUserList/SortDirection") -Or
            ($_ -eq "Get-WICNetworkList/SortDirection") -Or
            ($_ -eq "Get-WICSecurityGroupList/SortDirection") -Or
            ($_ -eq "Get-WICSecurityGroupUserList/SortDirection") -Or
            ($_ -eq "Get-WICUserList/SortDirection")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Wickr.Status
        "Update-WICNetworkSetting/Settings_ReadReceiptConfig_Status"
        {
            $v = "DISABLED","ENABLED","FORCE_ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WIC_map = @{
    "AccessLevel"=@("New-WICNetwork")
    "ActionType"=@("Update-WICDataRetention")
    "Settings_ReadReceiptConfig_Status"=@("Update-WICNetworkSetting")
    "SortDirection"=@("Get-WICBlockedGuestUserList","Get-WICBotList","Get-WICDevicesForUserList","Get-WICGuestUserList","Get-WICNetworkList","Get-WICSecurityGroupList","Get-WICSecurityGroupUserList","Get-WICUserList")
}

_awsArgumentCompleterRegistration $WIC_Completers $WIC_map

$WIC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WIC.$($commandName.Replace('-', ''))Cmdlet]"
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

$WIC_SelectMap = @{
    "Select"=@("New-WICUserBatch",
               "Remove-WICUserBatch",
               "Find-WICUserUnameBatch",
               "Send-WICUserReinvitationBatch",
               "Reset-WICDevicesForUserBatch",
               "Switch-WICUserSuspendStatusBatch",
               "New-WICBot",
               "New-WICDataRetentionBot",
               "New-WICDataRetentionBotChallenge",
               "New-WICNetwork",
               "New-WICSecurityGroup",
               "Remove-WICBot",
               "Remove-WICDataRetentionBot",
               "Remove-WICNetwork",
               "Remove-WICSecurityGroup",
               "Get-WICBot",
               "Get-WICBotsCount",
               "Get-WICDataRetentionBot",
               "Get-WICGuestUserHistoryCount",
               "Get-WICNetwork",
               "Get-WICNetworkSetting",
               "Get-WICOidcInfo",
               "Get-WICSecurityGroup",
               "Get-WICUser",
               "Get-WICUsersCount",
               "Get-WICBlockedGuestUserList",
               "Get-WICBotList",
               "Get-WICDevicesForUserList",
               "Get-WICGuestUserList",
               "Get-WICNetworkList",
               "Get-WICSecurityGroupList",
               "Get-WICSecurityGroupUserList",
               "Get-WICUserList",
               "Register-WICOidcConfig",
               "Register-WICOidcConfigTest",
               "Update-WICBot",
               "Update-WICDataRetention",
               "Update-WICGuestUser",
               "Update-WICNetwork",
               "Update-WICNetworkSetting",
               "Update-WICSecurityGroup",
               "Update-WICUser")
}

_awsArgumentCompleterRegistration $WIC_SelectCompleters $WIC_SelectMap

