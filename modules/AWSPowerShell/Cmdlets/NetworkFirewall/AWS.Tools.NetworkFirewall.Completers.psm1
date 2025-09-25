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

# Argument completions for service AWS Network Firewall


$NWFW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.NetworkFirewall.EnabledAnalysisType
        "Start-NWFWAnalysisReport/AnalysisType"
        {
            $v = "HTTP_HOST","TLS_SNI"
            break
        }

        # Amazon.NetworkFirewall.EncryptionType
        {
            ($_ -eq "New-NWFWFirewall/EncryptionConfiguration_Type") -Or
            ($_ -eq "New-NWFWFirewallPolicy/EncryptionConfiguration_Type") -Or
            ($_ -eq "New-NWFWRuleGroup/EncryptionConfiguration_Type") -Or
            ($_ -eq "New-NWFWTLSInspectionConfiguration/EncryptionConfiguration_Type") -Or
            ($_ -eq "Update-NWFWFirewallEncryptionConfiguration/EncryptionConfiguration_Type") -Or
            ($_ -eq "Update-NWFWFirewallPolicy/EncryptionConfiguration_Type") -Or
            ($_ -eq "Update-NWFWRuleGroup/EncryptionConfiguration_Type") -Or
            ($_ -eq "Update-NWFWTLSInspectionConfiguration/EncryptionConfiguration_Type")
        }
        {
            $v = "AWS_OWNED_KMS_KEY","CUSTOMER_KMS"
            break
        }

        # Amazon.NetworkFirewall.FlowOperationType
        "Get-NWFWFlowOperationList/FlowOperationType"
        {
            $v = "FLOW_CAPTURE","FLOW_FLUSH"
            break
        }

        # Amazon.NetworkFirewall.GeneratedRulesType
        {
            ($_ -eq "New-NWFWRuleGroup/RulesSourceList_GeneratedRulesType") -Or
            ($_ -eq "Update-NWFWRuleGroup/RulesSourceList_GeneratedRulesType")
        }
        {
            $v = "ALERTLIST","ALLOWLIST","DENYLIST","REJECTLIST"
            break
        }

        # Amazon.NetworkFirewall.IPAddressType
        "New-NWFWVpcEndpointAssociation/SubnetMapping_IPAddressType"
        {
            $v = "DUALSTACK","IPV4","IPV6"
            break
        }

        # Amazon.NetworkFirewall.ResourceManagedStatus
        "Get-NWFWRuleGroupList/Scope"
        {
            $v = "ACCOUNT","MANAGED"
            break
        }

        # Amazon.NetworkFirewall.ResourceManagedType
        "Get-NWFWRuleGroupList/ManagedType"
        {
            $v = "ACTIVE_THREAT_DEFENSE","AWS_MANAGED_DOMAIN_LISTS","AWS_MANAGED_THREAT_SIGNATURES"
            break
        }

        # Amazon.NetworkFirewall.RuleGroupType
        {
            ($_ -eq "Get-NWFWRuleGroup/Type") -Or
            ($_ -eq "Get-NWFWRuleGroupList/Type") -Or
            ($_ -eq "Get-NWFWRuleGroupMetadata/Type") -Or
            ($_ -eq "Get-NWFWRuleGroupSummary/Type") -Or
            ($_ -eq "New-NWFWRuleGroup/Type") -Or
            ($_ -eq "Remove-NWFWRuleGroup/Type") -Or
            ($_ -eq "Update-NWFWRuleGroup/Type")
        }
        {
            $v = "STATEFUL","STATELESS"
            break
        }

        # Amazon.NetworkFirewall.RuleOrder
        {
            ($_ -eq "New-NWFWFirewallPolicy/StatefulEngineOptions_RuleOrder") -Or
            ($_ -eq "Update-NWFWFirewallPolicy/StatefulEngineOptions_RuleOrder") -Or
            ($_ -eq "New-NWFWRuleGroup/StatefulRuleOptions_RuleOrder") -Or
            ($_ -eq "Update-NWFWRuleGroup/StatefulRuleOptions_RuleOrder")
        }
        {
            $v = "DEFAULT_ACTION_ORDER","STRICT_ORDER"
            break
        }

        # Amazon.NetworkFirewall.StreamExceptionPolicy
        {
            ($_ -eq "New-NWFWFirewallPolicy/StatefulEngineOptions_StreamExceptionPolicy") -Or
            ($_ -eq "Update-NWFWFirewallPolicy/StatefulEngineOptions_StreamExceptionPolicy")
        }
        {
            $v = "CONTINUE","DROP","REJECT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NWFW_map = @{
    "AnalysisType"=@("Start-NWFWAnalysisReport")
    "EncryptionConfiguration_Type"=@("New-NWFWFirewall","New-NWFWFirewallPolicy","New-NWFWRuleGroup","New-NWFWTLSInspectionConfiguration","Update-NWFWFirewallEncryptionConfiguration","Update-NWFWFirewallPolicy","Update-NWFWRuleGroup","Update-NWFWTLSInspectionConfiguration")
    "FlowOperationType"=@("Get-NWFWFlowOperationList")
    "ManagedType"=@("Get-NWFWRuleGroupList")
    "RulesSourceList_GeneratedRulesType"=@("New-NWFWRuleGroup","Update-NWFWRuleGroup")
    "Scope"=@("Get-NWFWRuleGroupList")
    "StatefulEngineOptions_RuleOrder"=@("New-NWFWFirewallPolicy","Update-NWFWFirewallPolicy")
    "StatefulEngineOptions_StreamExceptionPolicy"=@("New-NWFWFirewallPolicy","Update-NWFWFirewallPolicy")
    "StatefulRuleOptions_RuleOrder"=@("New-NWFWRuleGroup","Update-NWFWRuleGroup")
    "SubnetMapping_IPAddressType"=@("New-NWFWVpcEndpointAssociation")
    "Type"=@("Get-NWFWRuleGroup","Get-NWFWRuleGroupList","Get-NWFWRuleGroupMetadata","Get-NWFWRuleGroupSummary","New-NWFWRuleGroup","Remove-NWFWRuleGroup","Update-NWFWRuleGroup")
}

_awsArgumentCompleterRegistration $NWFW_Completers $NWFW_map

$NWFW_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NWFW.$($commandName.Replace('-', ''))Cmdlet]"
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

$NWFW_SelectMap = @{
    "Select"=@("Receive-NWFWNetworkFirewallTransitGatewayAttachment",
               "Join-NWFWAvailabilityZone",
               "Register-NWFWFirewallPolicy",
               "Register-NWFWSubnet",
               "New-NWFWFirewall",
               "New-NWFWFirewallPolicy",
               "New-NWFWRuleGroup",
               "New-NWFWTLSInspectionConfiguration",
               "New-NWFWVpcEndpointAssociation",
               "Remove-NWFWFirewall",
               "Remove-NWFWFirewallPolicy",
               "Remove-NWFWNetworkFirewallTransitGatewayAttachment",
               "Remove-NWFWResourcePolicy",
               "Remove-NWFWRuleGroup",
               "Remove-NWFWTLSInspectionConfiguration",
               "Remove-NWFWVpcEndpointAssociation",
               "Get-NWFWFirewall",
               "Get-NWFWFirewallMetadata",
               "Get-NWFWFirewallPolicy",
               "Get-NWFWFlowOperation",
               "Get-NWFWLoggingConfiguration",
               "Get-NWFWResourcePolicy",
               "Get-NWFWRuleGroup",
               "Get-NWFWRuleGroupMetadata",
               "Get-NWFWRuleGroupSummary",
               "Get-NWFWTLSInspectionConfiguration",
               "Get-NWFWVpcEndpointAssociation",
               "Remove-NWFWAvailabilityZone",
               "Unregister-NWFWSubnet",
               "Get-NWFWAnalysisReportResult",
               "Get-NWFWAnalysisReportList",
               "Get-NWFWFirewallPolicyList",
               "Get-NWFWFirewallList",
               "Get-NWFWFlowOperationResultList",
               "Get-NWFWFlowOperationList",
               "Get-NWFWRuleGroupList",
               "Get-NWFWResourceTag",
               "Get-NWFWTLSInspectionConfigurationList",
               "Get-NWFWVpcEndpointAssociationList",
               "Write-NWFWResourcePolicy",
               "Deny-NWFWNetworkFirewallTransitGatewayAttachment",
               "Start-NWFWAnalysisReport",
               "Start-NWFWFlowCapture",
               "Start-NWFWFlowFlush",
               "Add-NWFWResourceTag",
               "Remove-NWFWResourceTag",
               "Update-NWFWAvailabilityZoneChangeProtection",
               "Update-NWFWFirewallAnalysisSetting",
               "Update-NWFWFirewallDeleteProtection",
               "Update-NWFWFirewallDescription",
               "Update-NWFWFirewallEncryptionConfiguration",
               "Update-NWFWFirewallPolicy",
               "Update-NWFWFirewallPolicyChangeProtection",
               "Update-NWFWLoggingConfiguration",
               "Update-NWFWRuleGroup",
               "Update-NWFWSubnetChangeProtection",
               "Update-NWFWTLSInspectionConfiguration")
}

_awsArgumentCompleterRegistration $NWFW_SelectCompleters $NWFW_SelectMap

