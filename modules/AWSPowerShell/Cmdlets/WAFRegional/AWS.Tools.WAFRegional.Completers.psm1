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

# Argument completions for service AWS WAF Regional


$WAFR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WAFRegional.RateKey
        "New-WAFRRateBasedRule/RateKey"
        {
            $v = "IP"
            break
        }

        # Amazon.WAFRegional.ResourceType
        "Get-WAFRResourceForWebACLList/ResourceType"
        {
            $v = "API_GATEWAY","APPLICATION_LOAD_BALANCER"
            break
        }

        # Amazon.WAFRegional.WafActionType
        {
            ($_ -eq "New-WAFRWebACL/DefaultAction_Type") -Or
            ($_ -eq "Update-WAFRWebACL/DefaultAction_Type")
        }
        {
            $v = "ALLOW","BLOCK","COUNT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WAFR_map = @{
    "DefaultAction_Type"=@("New-WAFRWebACL","Update-WAFRWebACL")
    "RateKey"=@("New-WAFRRateBasedRule")
    "ResourceType"=@("Get-WAFRResourceForWebACLList")
}

_awsArgumentCompleterRegistration $WAFR_Completers $WAFR_map

$WAFR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WAFR.$($commandName.Replace('-', ''))Cmdlet]"
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

$WAFR_SelectMap = @{
    "Select"=@("Register-WAFRWebACL",
               "New-WAFRByteMatchSet",
               "New-WAFRGeoMatchSet",
               "New-WAFRIPSet",
               "New-WAFRRateBasedRule",
               "New-WAFRRegexMatchSet",
               "New-WAFRRegexPatternSet",
               "New-WAFRRule",
               "New-WAFRRuleGroup",
               "New-WAFRSizeConstraintSet",
               "New-WAFRSqlInjectionMatchSet",
               "New-WAFRWebACL",
               "New-WAFRWebACLMigrationStack",
               "New-WAFRXssMatchSet",
               "Remove-WAFRByteMatchSet",
               "Remove-WAFRGeoMatchSet",
               "Remove-WAFRIPSet",
               "Remove-WAFRLoggingConfiguration",
               "Remove-WAFRPermissionPolicy",
               "Remove-WAFRRateBasedRule",
               "Remove-WAFRRegexMatchSet",
               "Remove-WAFRRegexPatternSet",
               "Remove-WAFRRule",
               "Remove-WAFRRuleGroup",
               "Remove-WAFRSizeConstraintSet",
               "Remove-WAFRSqlInjectionMatchSet",
               "Remove-WAFRWebACL",
               "Remove-WAFRXssMatchSet",
               "Unregister-WAFRWebACL",
               "Get-WAFRByteMatchSet",
               "Get-WAFRChangeToken",
               "Get-WAFRChangeTokenStatus",
               "Get-WAFRGeoMatchSet",
               "Get-WAFRIPSet",
               "Get-WAFRLoggingConfiguration",
               "Get-WAFRPermissionPolicy",
               "Get-WAFRRateBasedRule",
               "Get-WAFRRateBasedRuleManagedKey",
               "Get-WAFRRegexMatchSet",
               "Get-WAFRRegexPatternSet",
               "Get-WAFRRule",
               "Get-WAFRRuleGroup",
               "Get-WAFRSampledRequestList",
               "Get-WAFRSizeConstraintSet",
               "Get-WAFRSqlInjectionMatchSet",
               "Get-WAFRWebACL",
               "Get-WAFRWebACLForResource",
               "Get-WAFRXssMatchSet",
               "Get-WAFRActivatedRulesInRuleGroupList",
               "Get-WAFRByteMatchSetList",
               "Get-WAFRGeoMatchSetList",
               "Get-WAFRIPSetList",
               "Get-WAFRLoggingConfigurationList",
               "Get-WAFRRateBasedRuleList",
               "Get-WAFRRegexMatchSetList",
               "Get-WAFRRegexPatternSetList",
               "Get-WAFRResourceForWebACLList",
               "Get-WAFRRuleGroupList",
               "Get-WAFRRuleList",
               "Get-WAFRSizeConstraintSetList",
               "Get-WAFRSqlInjectionMatchSetList",
               "Get-WAFRSubscribedRuleGroup",
               "Get-WAFRResourceTag",
               "Get-WAFRWebACLList",
               "Get-WAFRXssMatchSetList",
               "Write-WAFRLoggingConfiguration",
               "Write-WAFRPermissionPolicy",
               "Add-WAFRResourceTag",
               "Remove-WAFRResourceTag",
               "Update-WAFRByteMatchSet",
               "Update-WAFRGeoMatchSet",
               "Update-WAFRIPSet",
               "Update-WAFRRateBasedRule",
               "Update-WAFRRegexMatchSet",
               "Update-WAFRRegexPatternSet",
               "Update-WAFRRule",
               "Update-WAFRRuleGroup",
               "Update-WAFRSizeConstraintSet",
               "Update-WAFRSqlInjectionMatchSet",
               "Update-WAFRWebACL",
               "Update-WAFRXssMatchSet")
}

_awsArgumentCompleterRegistration $WAFR_SelectCompleters $WAFR_SelectMap

