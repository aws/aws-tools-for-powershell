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

# Argument completions for service AWS Budgets


$BGT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Budgets.BudgetType
        {
            ($_ -eq "New-BGTBudget/Budget_BudgetType") -Or
            ($_ -eq "Update-BGTBudget/NewBudget_BudgetType")
        }
        {
            $v = "COST","RI_COVERAGE","RI_UTILIZATION","SAVINGS_PLANS_COVERAGE","SAVINGS_PLANS_UTILIZATION","USAGE"
            break
        }

        # Amazon.Budgets.ComparisonOperator
        {
            ($_ -eq "Update-BGTNotification/NewNotification_ComparisonOperator") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_ComparisonOperator") -Or
            ($_ -eq "New-BGTNotification/Notification_ComparisonOperator") -Or
            ($_ -eq "New-BGTSubscriber/Notification_ComparisonOperator") -Or
            ($_ -eq "Remove-BGTNotification/Notification_ComparisonOperator") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_ComparisonOperator") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_ComparisonOperator") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_ComparisonOperator")
        }
        {
            $v = "EQUAL_TO","GREATER_THAN","LESS_THAN"
            break
        }

        # Amazon.Budgets.NotificationState
        {
            ($_ -eq "Update-BGTNotification/NewNotification_NotificationState") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_NotificationState") -Or
            ($_ -eq "New-BGTNotification/Notification_NotificationState") -Or
            ($_ -eq "New-BGTSubscriber/Notification_NotificationState") -Or
            ($_ -eq "Remove-BGTNotification/Notification_NotificationState") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_NotificationState") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_NotificationState") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_NotificationState")
        }
        {
            $v = "ALARM","OK"
            break
        }

        # Amazon.Budgets.NotificationType
        {
            ($_ -eq "Update-BGTNotification/NewNotification_NotificationType") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_NotificationType") -Or
            ($_ -eq "New-BGTNotification/Notification_NotificationType") -Or
            ($_ -eq "New-BGTSubscriber/Notification_NotificationType") -Or
            ($_ -eq "Remove-BGTNotification/Notification_NotificationType") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_NotificationType") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_NotificationType") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_NotificationType")
        }
        {
            $v = "ACTUAL","FORECASTED"
            break
        }

        # Amazon.Budgets.SubscriptionType
        {
            ($_ -eq "Update-BGTSubscriber/NewSubscriber_SubscriptionType") -Or
            ($_ -eq "Update-BGTSubscriber/OldSubscriber_SubscriptionType") -Or
            ($_ -eq "New-BGTSubscriber/Subscriber_SubscriptionType") -Or
            ($_ -eq "Remove-BGTSubscriber/Subscriber_SubscriptionType")
        }
        {
            $v = "EMAIL","SNS"
            break
        }

        # Amazon.Budgets.ThresholdType
        {
            ($_ -eq "Update-BGTNotification/NewNotification_ThresholdType") -Or
            ($_ -eq "Get-BGTSubscribersForNotification/Notification_ThresholdType") -Or
            ($_ -eq "New-BGTNotification/Notification_ThresholdType") -Or
            ($_ -eq "New-BGTSubscriber/Notification_ThresholdType") -Or
            ($_ -eq "Remove-BGTNotification/Notification_ThresholdType") -Or
            ($_ -eq "Remove-BGTSubscriber/Notification_ThresholdType") -Or
            ($_ -eq "Update-BGTSubscriber/Notification_ThresholdType") -Or
            ($_ -eq "Update-BGTNotification/OldNotification_ThresholdType")
        }
        {
            $v = "ABSOLUTE_VALUE","PERCENTAGE"
            break
        }

        # Amazon.Budgets.TimeUnit
        {
            ($_ -eq "New-BGTBudget/Budget_TimeUnit") -Or
            ($_ -eq "Update-BGTBudget/NewBudget_TimeUnit")
        }
        {
            $v = "ANNUALLY","DAILY","MONTHLY","QUARTERLY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BGT_map = @{
    "Budget_BudgetType"=@("New-BGTBudget")
    "Budget_TimeUnit"=@("New-BGTBudget")
    "NewBudget_BudgetType"=@("Update-BGTBudget")
    "NewBudget_TimeUnit"=@("Update-BGTBudget")
    "NewNotification_ComparisonOperator"=@("Update-BGTNotification")
    "NewNotification_NotificationState"=@("Update-BGTNotification")
    "NewNotification_NotificationType"=@("Update-BGTNotification")
    "NewNotification_ThresholdType"=@("Update-BGTNotification")
    "NewSubscriber_SubscriptionType"=@("Update-BGTSubscriber")
    "Notification_ComparisonOperator"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "Notification_NotificationState"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "Notification_NotificationType"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "Notification_ThresholdType"=@("Get-BGTSubscribersForNotification","New-BGTNotification","New-BGTSubscriber","Remove-BGTNotification","Remove-BGTSubscriber","Update-BGTSubscriber")
    "OldNotification_ComparisonOperator"=@("Update-BGTNotification")
    "OldNotification_NotificationState"=@("Update-BGTNotification")
    "OldNotification_NotificationType"=@("Update-BGTNotification")
    "OldNotification_ThresholdType"=@("Update-BGTNotification")
    "OldSubscriber_SubscriptionType"=@("Update-BGTSubscriber")
    "Subscriber_SubscriptionType"=@("New-BGTSubscriber","Remove-BGTSubscriber")
}

_awsArgumentCompleterRegistration $BGT_Completers $BGT_map

$BGT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BGT.$($commandName.Replace('-', ''))Cmdlet]"
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

$BGT_SelectMap = @{
    "Select"=@("New-BGTBudget",
               "New-BGTNotification",
               "New-BGTSubscriber",
               "Remove-BGTBudget",
               "Remove-BGTNotification",
               "Remove-BGTSubscriber",
               "Get-BGTBudget",
               "Get-BGTBudgetPerformanceHistory",
               "Get-BGTBudgetList",
               "Get-BGTNotificationsForBudget",
               "Get-BGTSubscribersForNotification",
               "Update-BGTBudget",
               "Update-BGTNotification",
               "Update-BGTSubscriber")
}

_awsArgumentCompleterRegistration $BGT_SelectCompleters $BGT_SelectMap

