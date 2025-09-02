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

# Argument completions for service AWS User Notifications


$UNO_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Notifications.AccountContactType
        {
            ($_ -eq "Add-UNOManagedNotificationAccountContact/ContactIdentifier") -Or
            ($_ -eq "Remove-UNOManagedNotificationAccountContact/ContactIdentifier")
        }
        {
            $v = "ACCOUNT_ALTERNATE_BILLING","ACCOUNT_ALTERNATE_OPERATIONS","ACCOUNT_ALTERNATE_SECURITY","ACCOUNT_PRIMARY"
            break
        }

        # Amazon.Notifications.AggregationDuration
        {
            ($_ -eq "New-UNONotificationConfiguration/AggregationDuration") -Or
            ($_ -eq "Update-UNONotificationConfiguration/AggregationDuration")
        }
        {
            $v = "LONG","NONE","SHORT"
            break
        }

        # Amazon.Notifications.LocaleCode
        {
            ($_ -eq "Get-UNOManagedNotificationChildEvent/Locale") -Or
            ($_ -eq "Get-UNOManagedNotificationChildEventList/Locale") -Or
            ($_ -eq "Get-UNOManagedNotificationEvent/Locale") -Or
            ($_ -eq "Get-UNOManagedNotificationEventList/Locale") -Or
            ($_ -eq "Get-UNONotificationEvent/Locale") -Or
            ($_ -eq "Get-UNONotificationEventList/Locale")
        }
        {
            $v = "de_DE","en_CA","en_UK","en_US","es_ES","fr_CA","fr_FR","id_ID","it_IT","ja_JP","ko_KR","pt_BR","tr_TR","zh_CN","zh_TW"
            break
        }

        # Amazon.Notifications.MemberAccountNotificationConfigurationStatus
        "Get-UNOMemberAccountList/Status"
        {
            $v = "ACTIVE","CREATING","DELETING","INACTIVE","PENDING"
            break
        }

        # Amazon.Notifications.NotificationConfigurationStatus
        "Get-UNONotificationConfigurationList/Status"
        {
            $v = "ACTIVE","DELETING","INACTIVE","PARTIALLY_ACTIVE"
            break
        }

        # Amazon.Notifications.NotificationConfigurationSubtype
        "Get-UNONotificationConfigurationList/Subtype"
        {
            $v = "ACCOUNT","ADMIN_MANAGED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$UNO_map = @{
    "AggregationDuration"=@("New-UNONotificationConfiguration","Update-UNONotificationConfiguration")
    "ContactIdentifier"=@("Add-UNOManagedNotificationAccountContact","Remove-UNOManagedNotificationAccountContact")
    "Locale"=@("Get-UNOManagedNotificationChildEvent","Get-UNOManagedNotificationChildEventList","Get-UNOManagedNotificationEvent","Get-UNOManagedNotificationEventList","Get-UNONotificationEvent","Get-UNONotificationEventList")
    "Status"=@("Get-UNOMemberAccountList","Get-UNONotificationConfigurationList")
    "Subtype"=@("Get-UNONotificationConfigurationList")
}

_awsArgumentCompleterRegistration $UNO_Completers $UNO_map

$UNO_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.UNO.$($commandName.Replace('-', ''))Cmdlet]"
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

$UNO_SelectMap = @{
    "Select"=@("Add-UNOChannel",
               "Add-UNOManagedNotificationAccountContact",
               "Add-UNOManagedNotificationAdditionalChannel",
               "Add-UNOOrganizationalUnit",
               "New-UNOEventRule",
               "New-UNONotificationConfiguration",
               "Remove-UNOEventRule",
               "Remove-UNONotificationConfiguration",
               "Remove-UNONotificationHub",
               "Disable-UNONotificationsAccessForOrganization",
               "Remove-UNOChannel",
               "Remove-UNOManagedNotificationAccountContact",
               "Remove-UNOManagedNotificationAdditionalChannel",
               "Remove-UNOOrganizationalUnit",
               "Enable-UNONotificationsAccessForOrganization",
               "Get-UNOEventRule",
               "Get-UNOManagedNotificationChildEvent",
               "Get-UNOManagedNotificationConfiguration",
               "Get-UNOManagedNotificationEvent",
               "Get-UNONotificationConfiguration",
               "Get-UNONotificationEvent",
               "Get-UNONotificationsAccessForOrganization",
               "Get-UNOChannelList",
               "Get-UNOEventRuleList",
               "Get-UNOManagedNotificationChannelAssociationList",
               "Get-UNOManagedNotificationChildEventList",
               "Get-UNOManagedNotificationConfigurationList",
               "Get-UNOManagedNotificationEventList",
               "Get-UNOMemberAccountList",
               "Get-UNONotificationConfigurationList",
               "Get-UNONotificationEventList",
               "Get-UNONotificationHubList",
               "Get-UNOOrganizationalUnitList",
               "Get-UNOResourceTag",
               "Register-UNONotificationHub",
               "Add-UNOResourceTag",
               "Remove-UNOResourceTag",
               "Update-UNOEventRule",
               "Update-UNONotificationConfiguration")
}

_awsArgumentCompleterRegistration $UNO_SelectCompleters $UNO_SelectMap

