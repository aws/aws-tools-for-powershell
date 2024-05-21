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

# Argument completions for service Amazon SES Mail Manager


$MMGR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MailManager.AcceptAction
        {
            ($_ -eq "New-MMGRTrafficPolicy/DefaultAction") -Or
            ($_ -eq "Update-MMGRTrafficPolicy/DefaultAction")
        }
        {
            $v = "ALLOW","DENY"
            break
        }

        # Amazon.MailManager.IngressPointStatusToUpdate
        "Update-MMGRIngressPoint/StatusToUpdate"
        {
            $v = "ACTIVE","CLOSED"
            break
        }

        # Amazon.MailManager.IngressPointType
        "New-MMGRIngressPoint/Type"
        {
            $v = "AUTH","OPEN"
            break
        }

        # Amazon.MailManager.RetentionPeriod
        {
            ($_ -eq "New-MMGRArchive/Retention_RetentionPeriod") -Or
            ($_ -eq "Update-MMGRArchive/Retention_RetentionPeriod")
        }
        {
            $v = "EIGHTEEN_MONTHS","EIGHT_YEARS","FIVE_YEARS","FOUR_YEARS","NINE_MONTHS","NINE_YEARS","ONE_YEAR","PERMANENT","SEVEN_YEARS","SIX_MONTHS","SIX_YEARS","TEN_YEARS","THIRTY_MONTHS","THREE_MONTHS","THREE_YEARS","TWO_YEARS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MMGR_map = @{
    "DefaultAction"=@("New-MMGRTrafficPolicy","Update-MMGRTrafficPolicy")
    "Retention_RetentionPeriod"=@("New-MMGRArchive","Update-MMGRArchive")
    "StatusToUpdate"=@("Update-MMGRIngressPoint")
    "Type"=@("New-MMGRIngressPoint")
}

_awsArgumentCompleterRegistration $MMGR_Completers $MMGR_map

$MMGR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MMGR.$($commandName.Replace('-', ''))Cmdlet]"
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

$MMGR_SelectMap = @{
    "Select"=@("New-MMGRAddonInstance",
               "New-MMGRAddonSubscription",
               "New-MMGRArchive",
               "New-MMGRIngressPoint",
               "New-MMGRRelay",
               "New-MMGRRuleSet",
               "New-MMGRTrafficPolicy",
               "Remove-MMGRAddonInstance",
               "Remove-MMGRAddonSubscription",
               "Remove-MMGRArchive",
               "Remove-MMGRIngressPoint",
               "Remove-MMGRRelay",
               "Remove-MMGRRuleSet",
               "Remove-MMGRTrafficPolicy",
               "Get-MMGRAddonInstance",
               "Get-MMGRAddonSubscription",
               "Get-MMGRArchive",
               "Get-MMGRArchiveExport",
               "Get-MMGRArchiveMessage",
               "Get-MMGRArchiveMessageContent",
               "Get-MMGRArchiveSearch",
               "Get-MMGRArchiveSearchResult",
               "Get-MMGRIngressPoint",
               "Get-MMGRRelay",
               "Get-MMGRRuleSet",
               "Get-MMGRTrafficPolicy",
               "Get-MMGRAddonInstanceList",
               "Get-MMGRAddonSubscriptionList",
               "Get-MMGRArchiveExportList",
               "Get-MMGRArchiveList",
               "Get-MMGRArchiveSearchList",
               "Get-MMGRIngressPointList",
               "Get-MMGRRelayList",
               "Get-MMGRRuleSetList",
               "Get-MMGRResourceTag",
               "Get-MMGRTrafficPolicyList",
               "Start-MMGRArchiveExport",
               "Start-MMGRArchiveSearch",
               "Stop-MMGRArchiveExport",
               "Stop-MMGRArchiveSearch",
               "Add-MMGRResourceTag",
               "Remove-MMGRResourceTag",
               "Update-MMGRArchive",
               "Update-MMGRIngressPoint",
               "Update-MMGRRelay",
               "Update-MMGRRuleSet",
               "Update-MMGRTrafficPolicy")
}

_awsArgumentCompleterRegistration $MMGR_SelectCompleters $MMGR_SelectMap

