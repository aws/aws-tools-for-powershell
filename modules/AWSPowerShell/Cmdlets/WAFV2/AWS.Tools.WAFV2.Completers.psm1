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

# Argument completions for service AWS WAF V2


$WAF2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WAFV2.FilterBehavior
        "Write-WAF2LoggingConfiguration/LoggingConfiguration_LoggingFilter_DefaultBehavior"
        {
            $v = "DROP","KEEP"
            break
        }

        # Amazon.WAFV2.IPAddressVersion
        "New-WAF2IPSet/IPAddressVersion"
        {
            $v = "IPV4","IPV6"
            break
        }

        # Amazon.WAFV2.Platform
        {
            ($_ -eq "Get-WAF2MobileSdkRelease/Platform") -Or
            ($_ -eq "Get-WAF2MobileSdkReleaseList/Platform") -Or
            ($_ -eq "New-WAF2MobileSdkReleaseUrl/Platform")
        }
        {
            $v = "ANDROID","IOS"
            break
        }

        # Amazon.WAFV2.ResourceType
        "Get-WAF2ResourcesForWebACLList/ResourceType"
        {
            $v = "API_GATEWAY","APPLICATION_LOAD_BALANCER","APPSYNC","COGNITO_USER_POOL"
            break
        }

        # Amazon.WAFV2.Scope
        {
            ($_ -eq "Get-WAF2AvailableManagedRuleGroupList/Scope") -Or
            ($_ -eq "Get-WAF2AvailableManagedRuleGroupVersionList/Scope") -Or
            ($_ -eq "Get-WAF2IPSet/Scope") -Or
            ($_ -eq "Get-WAF2IPSetList/Scope") -Or
            ($_ -eq "Get-WAF2LoggingConfigurationList/Scope") -Or
            ($_ -eq "Get-WAF2ManagedRuleGroup/Scope") -Or
            ($_ -eq "Get-WAF2ManagedRuleSet/Scope") -Or
            ($_ -eq "Get-WAF2ManagedRuleSetList/Scope") -Or
            ($_ -eq "Get-WAF2RateBasedStatementManagedKey/Scope") -Or
            ($_ -eq "Get-WAF2RegexPatternSet/Scope") -Or
            ($_ -eq "Get-WAF2RegexPatternSetList/Scope") -Or
            ($_ -eq "Get-WAF2RuleGroup/Scope") -Or
            ($_ -eq "Get-WAF2RuleGroupList/Scope") -Or
            ($_ -eq "Get-WAF2SampledRequest/Scope") -Or
            ($_ -eq "Get-WAF2WebACL/Scope") -Or
            ($_ -eq "Get-WAF2WebACLsList/Scope") -Or
            ($_ -eq "New-WAF2IPSet/Scope") -Or
            ($_ -eq "New-WAF2RegexPatternSet/Scope") -Or
            ($_ -eq "New-WAF2RuleGroup/Scope") -Or
            ($_ -eq "New-WAF2WebACL/Scope") -Or
            ($_ -eq "Remove-WAF2IPSet/Scope") -Or
            ($_ -eq "Remove-WAF2RegexPatternSet/Scope") -Or
            ($_ -eq "Remove-WAF2RuleGroup/Scope") -Or
            ($_ -eq "Remove-WAF2WebACL/Scope") -Or
            ($_ -eq "Test-WAF2Capacity/Scope") -Or
            ($_ -eq "Update-WAF2IPSet/Scope") -Or
            ($_ -eq "Update-WAF2ManagedRuleSetVersionExpiryDate/Scope") -Or
            ($_ -eq "Update-WAF2RegexPatternSet/Scope") -Or
            ($_ -eq "Update-WAF2RuleGroup/Scope") -Or
            ($_ -eq "Update-WAF2WebACL/Scope") -Or
            ($_ -eq "Write-WAF2ManagedRuleSetVersion/Scope")
        }
        {
            $v = "CLOUDFRONT","REGIONAL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WAF2_map = @{
    "IPAddressVersion"=@("New-WAF2IPSet")
    "LoggingConfiguration_LoggingFilter_DefaultBehavior"=@("Write-WAF2LoggingConfiguration")
    "Platform"=@("Get-WAF2MobileSdkRelease","Get-WAF2MobileSdkReleaseList","New-WAF2MobileSdkReleaseUrl")
    "ResourceType"=@("Get-WAF2ResourcesForWebACLList")
    "Scope"=@("Get-WAF2AvailableManagedRuleGroupList","Get-WAF2AvailableManagedRuleGroupVersionList","Get-WAF2IPSet","Get-WAF2IPSetList","Get-WAF2LoggingConfigurationList","Get-WAF2ManagedRuleGroup","Get-WAF2ManagedRuleSet","Get-WAF2ManagedRuleSetList","Get-WAF2RateBasedStatementManagedKey","Get-WAF2RegexPatternSet","Get-WAF2RegexPatternSetList","Get-WAF2RuleGroup","Get-WAF2RuleGroupList","Get-WAF2SampledRequest","Get-WAF2WebACL","Get-WAF2WebACLsList","New-WAF2IPSet","New-WAF2RegexPatternSet","New-WAF2RuleGroup","New-WAF2WebACL","Remove-WAF2IPSet","Remove-WAF2RegexPatternSet","Remove-WAF2RuleGroup","Remove-WAF2WebACL","Test-WAF2Capacity","Update-WAF2IPSet","Update-WAF2ManagedRuleSetVersionExpiryDate","Update-WAF2RegexPatternSet","Update-WAF2RuleGroup","Update-WAF2WebACL","Write-WAF2ManagedRuleSetVersion")
}

_awsArgumentCompleterRegistration $WAF2_Completers $WAF2_map

$WAF2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WAF2.$($commandName.Replace('-', ''))Cmdlet]"
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

$WAF2_SelectMap = @{
    "Select"=@("Add-WAF2WebACLToResource",
               "Test-WAF2Capacity",
               "New-WAF2IPSet",
               "New-WAF2RegexPatternSet",
               "New-WAF2RuleGroup",
               "New-WAF2WebACL",
               "Remove-WAF2FirewallManagerRuleGroup",
               "Remove-WAF2IPSet",
               "Remove-WAF2LoggingConfiguration",
               "Remove-WAF2PermissionPolicy",
               "Remove-WAF2RegexPatternSet",
               "Remove-WAF2RuleGroup",
               "Remove-WAF2WebACL",
               "Get-WAF2ManagedRuleGroup",
               "Remove-WAF2WebACLFromResource",
               "New-WAF2MobileSdkReleaseUrl",
               "Get-WAF2IPSet",
               "Get-WAF2LoggingConfiguration",
               "Get-WAF2ManagedRuleSet",
               "Get-WAF2MobileSdkRelease",
               "Get-WAF2PermissionPolicy",
               "Get-WAF2RateBasedStatementManagedKey",
               "Get-WAF2RegexPatternSet",
               "Get-WAF2RuleGroup",
               "Get-WAF2SampledRequest",
               "Get-WAF2WebACL",
               "Get-WAF2WebACLForResource",
               "Get-WAF2AvailableManagedRuleGroupList",
               "Get-WAF2AvailableManagedRuleGroupVersionList",
               "Get-WAF2IPSetList",
               "Get-WAF2LoggingConfigurationList",
               "Get-WAF2ManagedRuleSetList",
               "Get-WAF2MobileSdkReleaseList",
               "Get-WAF2RegexPatternSetList",
               "Get-WAF2ResourcesForWebACLList",
               "Get-WAF2RuleGroupList",
               "Get-WAF2ResourceTag",
               "Get-WAF2WebACLsList",
               "Write-WAF2LoggingConfiguration",
               "Write-WAF2ManagedRuleSetVersion",
               "Write-WAF2PermissionPolicy",
               "Add-WAF2ResourceTag",
               "Remove-WAF2ResourceTag",
               "Update-WAF2IPSet",
               "Update-WAF2ManagedRuleSetVersionExpiryDate",
               "Update-WAF2RegexPatternSet",
               "Update-WAF2RuleGroup",
               "Update-WAF2WebACL")
}

_awsArgumentCompleterRegistration $WAF2_SelectCompleters $WAF2_SelectMap

