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

# Argument completions for service Amazon Simple Email Service (SES)


$SES_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SimpleEmail.BehaviorOnMXFailure
        "Set-SESIdentityMailFromDomain/BehaviorOnMXFailure"
        {
            $v = "RejectMessage","UseDefaultValue"
            break
        }

        # Amazon.SimpleEmail.IdentityType
        "Get-SESIdentity/IdentityType"
        {
            $v = "Domain","EmailAddress"
            break
        }

        # Amazon.SimpleEmail.NotificationType
        {
            ($_ -eq "Set-SESIdentityHeadersInNotificationsEnabled/NotificationType") -Or
            ($_ -eq "Set-SESIdentityNotificationTopic/NotificationType")
        }
        {
            $v = "Bounce","Complaint","Delivery"
            break
        }

        # Amazon.SimpleEmail.ReceiptFilterPolicy
        "New-SESReceiptFilter/Filter_IpFilter_Policy"
        {
            $v = "Allow","Block"
            break
        }

        # Amazon.SimpleEmail.TlsPolicy
        {
            ($_ -eq "Write-SESConfigurationSetDeliveryOption/DeliveryOptions_TlsPolicy") -Or
            ($_ -eq "New-SESReceiptRule/Rule_TlsPolicy") -Or
            ($_ -eq "Update-SESReceiptRule/Rule_TlsPolicy")
        }
        {
            $v = "Optional","Require"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SES_map = @{
    "BehaviorOnMXFailure"=@("Set-SESIdentityMailFromDomain")
    "DeliveryOptions_TlsPolicy"=@("Write-SESConfigurationSetDeliveryOption")
    "Filter_IpFilter_Policy"=@("New-SESReceiptFilter")
    "IdentityType"=@("Get-SESIdentity")
    "NotificationType"=@("Set-SESIdentityHeadersInNotificationsEnabled","Set-SESIdentityNotificationTopic")
    "Rule_TlsPolicy"=@("New-SESReceiptRule","Update-SESReceiptRule")
}

_awsArgumentCompleterRegistration $SES_Completers $SES_map

$SES_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SES.$($commandName.Replace('-', ''))Cmdlet]"
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

$SES_SelectMap = @{
    "Select"=@("Copy-SESReceiptRuleSet",
               "New-SESConfigurationSet",
               "New-SESConfigurationSetEventDestination",
               "New-SESConfigurationSetTrackingOption",
               "New-SESCustomVerificationEmailTemplate",
               "New-SESReceiptFilter",
               "New-SESReceiptRule",
               "New-SESReceiptRuleSet",
               "New-SESTemplate",
               "Remove-SESConfigurationSet",
               "Remove-SESConfigurationSetEventDestination",
               "Remove-SESConfigurationSetTrackingOption",
               "Remove-SESCustomVerificationEmailTemplate",
               "Remove-SESIdentity",
               "Remove-SESIdentityPolicy",
               "Remove-SESReceiptFilter",
               "Remove-SESReceiptRule",
               "Remove-SESReceiptRuleSet",
               "Remove-SESTemplate",
               "Remove-SESVerifiedEmailAddress",
               "Get-SESActiveReceiptRuleSet",
               "Get-SESConfigurationSet",
               "Get-SESReceiptRule",
               "Get-SESReceiptRuleSet",
               "Get-SESAccountSendingEnabled",
               "Get-SESCustomVerificationEmailTemplate",
               "Get-SESIdentityDkimAttribute",
               "Get-SESIdentityMailFromDomainAttribute",
               "Get-SESIdentityNotificationAttribute",
               "Get-SESIdentityPolicy",
               "Get-SESIdentityVerificationAttribute",
               "Get-SESSendQuota",
               "Get-SESSendStatistic",
               "Get-SESTemplate",
               "Get-SESConfigurationSetList",
               "Get-SESCustomVerificationEmailTemplateList",
               "Get-SESIdentity",
               "Get-SESIdentityPolicyList",
               "Get-SESReceiptFilterList",
               "Get-SESReceiptRuleSetList",
               "Get-SESTemplateList",
               "Get-SESVerifiedEmailAddress",
               "Write-SESConfigurationSetDeliveryOption",
               "Write-SESIdentityPolicy",
               "Set-SESReceiptRuleSetOrder",
               "Send-SESBounce",
               "Send-SESBulkTemplatedEmail",
               "Send-SESCustomVerificationEmail",
               "Send-SESEmail",
               "Send-SESRawEmail",
               "Send-SESTemplatedEmail",
               "Set-SESActiveReceiptRuleSet",
               "Set-SESIdentityDkimEnabled",
               "Set-SESIdentityFeedbackForwardingEnabled",
               "Set-SESIdentityHeadersInNotificationsEnabled",
               "Set-SESIdentityMailFromDomain",
               "Set-SESIdentityNotificationTopic",
               "Set-SESReceiptRulePosition",
               "Test-SESRenderTemplate",
               "Update-SESAccountSendingEnabled",
               "Update-SESConfigurationSetEventDestination",
               "Update-SESConfigurationSetReputationMetricsEnabled",
               "Update-SESConfigurationSetSendingEnabled",
               "Update-SESConfigurationSetTrackingOption",
               "Update-SESCustomVerificationEmailTemplate",
               "Update-SESReceiptRule",
               "Update-SESTemplate",
               "Confirm-SESDomainDkim",
               "Confirm-SESDomainIdentity",
               "Confirm-SESEmailAddress",
               "Confirm-SESEmailIdentity")
}

_awsArgumentCompleterRegistration $SES_SelectCompleters $SES_SelectMap

