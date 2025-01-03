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

# Argument completions for service Amazon EventBridge


$EVB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EventBridge.ApiDestinationHttpMethod
        {
            ($_ -eq "New-EVBApiDestination/HttpMethod") -Or
            ($_ -eq "Update-EVBApiDestination/HttpMethod")
        }
        {
            $v = "DELETE","GET","HEAD","OPTIONS","PATCH","POST","PUT"
            break
        }

        # Amazon.EventBridge.ArchiveState
        "Get-EVBArchiveList/State"
        {
            $v = "CREATE_FAILED","CREATING","DISABLED","ENABLED","UPDATE_FAILED","UPDATING"
            break
        }

        # Amazon.EventBridge.ConnectionAuthorizationType
        {
            ($_ -eq "New-EVBConnection/AuthorizationType") -Or
            ($_ -eq "Update-EVBConnection/AuthorizationType")
        }
        {
            $v = "API_KEY","BASIC","OAUTH_CLIENT_CREDENTIALS"
            break
        }

        # Amazon.EventBridge.ConnectionOAuthHttpMethod
        {
            ($_ -eq "New-EVBConnection/OAuthParameters_HttpMethod") -Or
            ($_ -eq "Update-EVBConnection/OAuthParameters_HttpMethod")
        }
        {
            $v = "GET","POST","PUT"
            break
        }

        # Amazon.EventBridge.ConnectionState
        "Get-EVBConnectionList/ConnectionState"
        {
            $v = "ACTIVE","AUTHORIZED","AUTHORIZING","CREATING","DEAUTHORIZED","DEAUTHORIZING","DELETING","FAILED_CONNECTIVITY","UPDATING"
            break
        }

        # Amazon.EventBridge.ReplayState
        "Get-EVBReplayList/State"
        {
            $v = "CANCELLED","CANCELLING","COMPLETED","FAILED","RUNNING","STARTING"
            break
        }

        # Amazon.EventBridge.ReplicationState
        {
            ($_ -eq "New-EVBEndpoint/ReplicationConfig_State") -Or
            ($_ -eq "Update-EVBEndpoint/ReplicationConfig_State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.EventBridge.RuleState
        "Write-EVBRule/State"
        {
            $v = "DISABLED","ENABLED","ENABLED_WITH_ALL_CLOUDTRAIL_MANAGEMENT_EVENTS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EVB_map = @{
    "AuthorizationType"=@("New-EVBConnection","Update-EVBConnection")
    "ConnectionState"=@("Get-EVBConnectionList")
    "HttpMethod"=@("New-EVBApiDestination","Update-EVBApiDestination")
    "OAuthParameters_HttpMethod"=@("New-EVBConnection","Update-EVBConnection")
    "ReplicationConfig_State"=@("New-EVBEndpoint","Update-EVBEndpoint")
    "State"=@("Get-EVBArchiveList","Get-EVBReplayList","Write-EVBRule")
}

_awsArgumentCompleterRegistration $EVB_Completers $EVB_map

$EVB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EVB.$($commandName.Replace('-', ''))Cmdlet]"
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

$EVB_SelectMap = @{
    "Select"=@("Enable-EVBEventSource",
               "Stop-EVBReplay",
               "New-EVBApiDestination",
               "New-EVBArchive",
               "New-EVBConnection",
               "New-EVBEndpoint",
               "New-EVBEventBus",
               "New-EVBPartnerEventSource",
               "Disable-EVBEventSource",
               "Clear-EVBConnection",
               "Remove-EVBApiDestination",
               "Remove-EVBArchive",
               "Remove-EVBConnection",
               "Remove-EVBEndpoint",
               "Remove-EVBEventBus",
               "Remove-EVBPartnerEventSource",
               "Remove-EVBRule",
               "Get-EVBApiDestination",
               "Get-EVBArchive",
               "Get-EVBConnection",
               "Get-EVBEndpoint",
               "Get-EVBEventBus",
               "Get-EVBEventSource",
               "Get-EVBPartnerEventSource",
               "Get-EVBReplay",
               "Get-EVBRuleDetail",
               "Disable-EVBRule",
               "Enable-EVBRule",
               "Get-EVBApiDestinationList",
               "Get-EVBArchiveList",
               "Get-EVBConnectionList",
               "Get-EVBEndpointList",
               "Get-EVBEventBusList",
               "Get-EVBEventSourceList",
               "Get-EVBPartnerEventSourceAccountList",
               "Get-EVBPartnerEventSourceList",
               "Get-EVBReplayList",
               "Get-EVBRuleNamesByTarget",
               "Get-EVBRule",
               "Get-EVBResourceTag",
               "Get-EVBTargetsByRule",
               "Write-EVBEvent",
               "Write-EVBPartnerEvent",
               "Write-EVBPermission",
               "Write-EVBRule",
               "Write-EVBTarget",
               "Remove-EVBPermission",
               "Remove-EVBTarget",
               "Start-EVBReplay",
               "Add-EVBResourceTag",
               "Test-EVBEventPattern",
               "Remove-EVBResourceTag",
               "Update-EVBApiDestination",
               "Update-EVBArchive",
               "Update-EVBConnection",
               "Update-EVBEndpoint",
               "Update-EVBEventBus")
}

_awsArgumentCompleterRegistration $EVB_SelectCompleters $EVB_SelectMap

