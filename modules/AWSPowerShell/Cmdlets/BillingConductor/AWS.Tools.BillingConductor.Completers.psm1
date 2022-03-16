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

# Argument completions for service AWSBillingConductor


$ABC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BillingConductor.BillingGroupStatus
        "Update-ABCBillingGroup/Status"
        {
            $v = "ACTIVE","PRIMARY_ACCOUNT_MISSING"
            break
        }

        # Amazon.BillingConductor.CustomLineItemRelationship
        "Get-ABCResourcesAssociatedToCustomLineItemList/Filters_Relationship"
        {
            $v = "CHILD","PARENT"
            break
        }

        # Amazon.BillingConductor.CustomLineItemType
        "New-ABCCustomLineItem/ChargeDetails_Type"
        {
            $v = "CREDIT","FEE"
            break
        }

        # Amazon.BillingConductor.PricingRuleScope
        "New-ABCPricingRule/Scope"
        {
            $v = "GLOBAL","SERVICE"
            break
        }

        # Amazon.BillingConductor.PricingRuleType
        {
            ($_ -eq "New-ABCPricingRule/Type") -Or
            ($_ -eq "Update-ABCPricingRule/Type")
        }
        {
            $v = "DISCOUNT","MARKUP"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ABC_map = @{
    "ChargeDetails_Type"=@("New-ABCCustomLineItem")
    "Filters_Relationship"=@("Get-ABCResourcesAssociatedToCustomLineItemList")
    "Scope"=@("New-ABCPricingRule")
    "Status"=@("Update-ABCBillingGroup")
    "Type"=@("New-ABCPricingRule","Update-ABCPricingRule")
}

_awsArgumentCompleterRegistration $ABC_Completers $ABC_map

$ABC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ABC.$($commandName.Replace('-', ''))Cmdlet]"
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

$ABC_SelectMap = @{
    "Select"=@("Register-ABCAccount",
               "Register-ABCPricingRule",
               "Register-ABCResourceBatchToCustomLineItem",
               "Unregister-ABCResourceBatchFromCustomLineItem",
               "New-ABCBillingGroup",
               "New-ABCCustomLineItem",
               "New-ABCPricingPlan",
               "New-ABCPricingRule",
               "Remove-ABCBillingGroup",
               "Remove-ABCCustomLineItem",
               "Remove-ABCPricingPlan",
               "Remove-ABCPricingRule",
               "Unregister-ABCAccount",
               "Unregister-ABCPricingRule",
               "Get-ABCAccountAssociationList",
               "Get-ABCBillingGroupCostReportList",
               "Get-ABCBillingGroupList",
               "Get-ABCCustomLineItemList",
               "Get-ABCPricingPlanList",
               "Get-ABCPricingPlansAssociatedWithPricingRuleList",
               "Get-ABCPricingRuleList",
               "Get-ABCPricingRulesAssociatedToPricingPlanList",
               "Get-ABCResourcesAssociatedToCustomLineItemList",
               "Get-ABCResourceTag",
               "Add-ABCResourceTag",
               "Remove-ABCResourceTag",
               "Update-ABCBillingGroup",
               "Update-ABCCustomLineItem",
               "Update-ABCPricingPlan",
               "Update-ABCPricingRule")
}

_awsArgumentCompleterRegistration $ABC_SelectCompleters $ABC_SelectMap

