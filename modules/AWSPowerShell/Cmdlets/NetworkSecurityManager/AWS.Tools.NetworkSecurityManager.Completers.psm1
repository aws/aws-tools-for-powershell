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

# Argument completions for service AWS Network Security Manager Customer API


$NSM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.NetworkSecurityManager.EntityStatusFilter
        {
            ($_ -eq "Get-NSMDeploymentList/Status") -Or
            ($_ -eq "Get-NSMPolicyList/Status") -Or
            ($_ -eq "Get-NSMRuleList/Status") -Or
            ($_ -eq "Get-NSMScopeList/Status") -Or
            ($_ -eq "Get-NSMTemplateList/Status")
        }
        {
            $v = "ACTIVE","DISABLED","DRAFT"
            break
        }

        # Amazon.NetworkSecurityManager.ExistingCustomerWebACLResolution
        {
            ($_ -eq "New-NSMPolicy/PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution") -Or
            ($_ -eq "Update-NSMPolicy/PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution")
        }
        {
            $v = "NO_REMEDIATION","OVERRIDE_ASSOCIATION","RETROFIT"
            break
        }

        # Amazon.NetworkSecurityManager.PolicyFirewallType
        "New-NSMPolicy/FirewallType"
        {
            $v = "SHIELD_ADVANCED","WAF"
            break
        }

        # Amazon.NetworkSecurityManager.RuleFirewallType
        {
            ($_ -eq "New-NSMRule/FirewallType") -Or
            ($_ -eq "New-NSMRuleConfiguration/RuleFirewallType")
        }
        {
            $v = "WAF"
            break
        }

        # Amazon.NetworkSecurityManager.RuleType
        {
            ($_ -eq "New-NSMRule/RuleType") -Or
            ($_ -eq "New-NSMRuleConfiguration/RuleType") -Or
            ($_ -eq "Update-NSMRule/RuleType")
        }
        {
            $v = "CONFIGURATION","INSPECTION"
            break
        }

        # Amazon.NetworkSecurityManager.SynchronizationStatus
        {
            ($_ -eq "Get-NSMAggregateResourceSynchronizationStatusList/SynchronizationStatus") -Or
            ($_ -eq "Get-NSMResourceSynchronizationStatusList/SynchronizationStatus")
        }
        {
            $v = "IN_SYNC","NOT_APPLICABLE","OUT_OF_SYNC"
            break
        }

        # Amazon.NetworkSecurityManager.TemplateFirewallType
        "New-NSMTemplate/FirewallType"
        {
            $v = "WAF"
            break
        }

        # Amazon.NetworkSecurityManager.WAFConfigDataType
        "New-NSMRuleConfiguration/WafConfigDataType"
        {
            $v = "AssociationConfig","CaptchaConfig","ChallengeConfig","CustomResponseBodies","DataProtectionConfig","DefaultAction","LoggingConfiguration","OnSourceDDoSProtectionConfig","TokenDomains","VisibilityConfig"
            break
        }

        # Amazon.NetworkSecurityManager.WAFConflictResolutionOptions
        {
            ($_ -eq "New-NSMPolicy/PolicyConfiguration_WafConfig_ConflictResolution") -Or
            ($_ -eq "Update-NSMPolicy/PolicyConfiguration_WafConfig_ConflictResolution")
        }
        {
            $v = "MERGE_WHERE_APPLICABLE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NSM_map = @{
    "FirewallType"=@("New-NSMPolicy","New-NSMRule","New-NSMTemplate")
    "PolicyConfiguration_WafConfig_ConflictResolution"=@("New-NSMPolicy","Update-NSMPolicy")
    "PolicyConfiguration_WafConfig_ExistingCustomerWebACLResolution"=@("New-NSMPolicy","Update-NSMPolicy")
    "RuleFirewallType"=@("New-NSMRuleConfiguration")
    "RuleType"=@("New-NSMRule","New-NSMRuleConfiguration","Update-NSMRule")
    "Status"=@("Get-NSMDeploymentList","Get-NSMPolicyList","Get-NSMRuleList","Get-NSMScopeList","Get-NSMTemplateList")
    "SynchronizationStatus"=@("Get-NSMAggregateResourceSynchronizationStatusList","Get-NSMResourceSynchronizationStatusList")
    "WafConfigDataType"=@("New-NSMRuleConfiguration")
}

_awsArgumentCompleterRegistration $NSM_Completers $NSM_map

$NSM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NSM.$($commandName.Replace('-', ''))Cmdlet]"
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

$NSM_SelectMap = @{
    "Select"=@("New-NSMDeployment",
               "New-NSMDeploymentSnapshot",
               "New-NSMPolicy",
               "New-NSMPolicySnapshot",
               "New-NSMRule",
               "New-NSMRuleSnapshot",
               "New-NSMScope",
               "New-NSMScopeSnapshot",
               "New-NSMTemplate",
               "New-NSMTemplateSnapshot",
               "Remove-NSMAdminAccount",
               "Remove-NSMDeployment",
               "Remove-NSMPolicy",
               "Remove-NSMRule",
               "Remove-NSMScope",
               "Remove-NSMTemplate",
               "New-NSMRuleConfiguration",
               "Get-NSMAdminAccount",
               "Get-NSMDeployment",
               "Get-NSMPolicy",
               "Get-NSMRule",
               "Get-NSMScope",
               "Get-NSMTemplate",
               "Get-NSMAdminAccountList",
               "Get-NSMAggregateResourceSynchronizationStatusList",
               "Get-NSMDeploymentList",
               "Get-NSMDeploymentSnapshotList",
               "Get-NSMPolicyList",
               "Get-NSMPolicySnapshotList",
               "Get-NSMResourceAssociationList",
               "Get-NSMResourceSynchronizationStatusList",
               "Get-NSMRuleList",
               "Get-NSMRuleSnapshotList",
               "Get-NSMScopeList",
               "Get-NSMScopeSnapshotList",
               "Get-NSMResourceTag",
               "Get-NSMTemplateList",
               "Get-NSMTemplateSnapshotList",
               "Write-NSMAdminAccount",
               "Add-NSMResourceTag",
               "Remove-NSMResourceTag",
               "Update-NSMDeployment",
               "Update-NSMPolicy",
               "Update-NSMRule",
               "Update-NSMScope",
               "Update-NSMTemplate")
}

_awsArgumentCompleterRegistration $NSM_SelectCompleters $NSM_SelectMap

