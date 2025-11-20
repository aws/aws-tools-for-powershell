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

# Argument completions for service AWS Security Hub


$SHUB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SecurityHub.AllowedOperators
        {
            ($_ -eq "Get-SHUBFindingsTrendsV2/Filters_CompositeOperator") -Or
            ($_ -eq "Get-SHUBFindingsV2/Filters_CompositeOperator") -Or
            ($_ -eq "Get-SHUBResourcesTrendsV2/Filters_CompositeOperator") -Or
            ($_ -eq "Get-SHUBResourcesV2/Filters_CompositeOperator") -Or
            ($_ -eq "New-SHUBAutomationRuleV2/OcsfFindingCriteria_CompositeOperator") -Or
            ($_ -eq "Update-SHUBAutomationRuleV2/OcsfFindingCriteria_CompositeOperator")
        }
        {
            $v = "AND","OR"
            break
        }

        # Amazon.SecurityHub.AssociationType
        "Get-SHUBConfigurationPolicyAssociationList/Filters_AssociationType"
        {
            $v = "APPLIED","INHERITED"
            break
        }

        # Amazon.SecurityHub.AutoEnableStandards
        "Update-SHUBOrganizationConfiguration/AutoEnableStandard"
        {
            $v = "DEFAULT","NONE"
            break
        }

        # Amazon.SecurityHub.ConfigurationPolicyAssociationStatus
        "Get-SHUBConfigurationPolicyAssociationList/Filters_AssociationStatus"
        {
            $v = "FAILED","PENDING","SUCCESS"
            break
        }

        # Amazon.SecurityHub.ConnectorProviderName
        "Get-SHUBConnectorsV2List/ProviderName"
        {
            $v = "JIRA_CLOUD","SERVICENOW"
            break
        }

        # Amazon.SecurityHub.ConnectorStatus
        "Get-SHUBConnectorsV2List/ConnectorStatus"
        {
            $v = "CONNECTED","FAILED_TO_CONNECT","PENDING_AUTHORIZATION","PENDING_CONFIGURATION"
            break
        }

        # Amazon.SecurityHub.ControlFindingGenerator
        {
            ($_ -eq "Enable-SHUBSecurityHub/ControlFindingGenerator") -Or
            ($_ -eq "Update-SHUBSecurityHubConfiguration/ControlFindingGenerator")
        }
        {
            $v = "SECURITY_CONTROL","STANDARD_CONTROL"
            break
        }

        # Amazon.SecurityHub.ControlStatus
        "Update-SHUBStandardsControl/ControlStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SecurityHub.OrganizationConfigurationConfigurationType
        "Update-SHUBOrganizationConfiguration/OrganizationConfiguration_ConfigurationType"
        {
            $v = "CENTRAL","LOCAL"
            break
        }

        # Amazon.SecurityHub.OrganizationConfigurationStatus
        "Update-SHUBOrganizationConfiguration/OrganizationConfiguration_Status"
        {
            $v = "ENABLED","FAILED","PENDING"
            break
        }

        # Amazon.SecurityHub.RecordState
        "Update-SHUBFinding/RecordState"
        {
            $v = "ACTIVE","ARCHIVED"
            break
        }

        # Amazon.SecurityHub.RuleStatus
        "New-SHUBAutomationRule/RuleStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SecurityHub.RuleStatusV2
        {
            ($_ -eq "New-SHUBAutomationRuleV2/RuleStatus") -Or
            ($_ -eq "Update-SHUBAutomationRuleV2/RuleStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SecurityHub.SecurityHubFeature
        {
            ($_ -eq "Disable-SHUBOrganizationAdminAccount/Feature") -Or
            ($_ -eq "Enable-SHUBOrganizationAdminAccount/Feature") -Or
            ($_ -eq "Get-SHUBOrganizationAdminAccountList/Feature")
        }
        {
            $v = "SecurityHub","SecurityHubV2"
            break
        }

        # Amazon.SecurityHub.SeverityLabel
        "Update-SHUBFindingsBatch/Severity_Label"
        {
            $v = "CRITICAL","HIGH","INFORMATIONAL","LOW","MEDIUM"
            break
        }

        # Amazon.SecurityHub.SortOrder
        {
            ($_ -eq "Get-SHUBFindingStatisticsV2/SortOrder") -Or
            ($_ -eq "Get-SHUBResourcesStatisticsV2/SortOrder")
        }
        {
            $v = "asc","desc"
            break
        }

        # Amazon.SecurityHub.VerificationState
        "Update-SHUBFindingsBatch/VerificationState"
        {
            $v = "BENIGN_POSITIVE","FALSE_POSITIVE","TRUE_POSITIVE","UNKNOWN"
            break
        }

        # Amazon.SecurityHub.WorkflowStatus
        "Update-SHUBFindingsBatch/Workflow_Status"
        {
            $v = "NEW","NOTIFIED","RESOLVED","SUPPRESSED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SHUB_map = @{
    "AutoEnableStandard"=@("Update-SHUBOrganizationConfiguration")
    "ConnectorStatus"=@("Get-SHUBConnectorsV2List")
    "ControlFindingGenerator"=@("Enable-SHUBSecurityHub","Update-SHUBSecurityHubConfiguration")
    "ControlStatus"=@("Update-SHUBStandardsControl")
    "Feature"=@("Disable-SHUBOrganizationAdminAccount","Enable-SHUBOrganizationAdminAccount","Get-SHUBOrganizationAdminAccountList")
    "Filters_AssociationStatus"=@("Get-SHUBConfigurationPolicyAssociationList")
    "Filters_AssociationType"=@("Get-SHUBConfigurationPolicyAssociationList")
    "Filters_CompositeOperator"=@("Get-SHUBFindingsTrendsV2","Get-SHUBFindingsV2","Get-SHUBResourcesTrendsV2","Get-SHUBResourcesV2")
    "OcsfFindingCriteria_CompositeOperator"=@("New-SHUBAutomationRuleV2","Update-SHUBAutomationRuleV2")
    "OrganizationConfiguration_ConfigurationType"=@("Update-SHUBOrganizationConfiguration")
    "OrganizationConfiguration_Status"=@("Update-SHUBOrganizationConfiguration")
    "ProviderName"=@("Get-SHUBConnectorsV2List")
    "RecordState"=@("Update-SHUBFinding")
    "RuleStatus"=@("New-SHUBAutomationRule","New-SHUBAutomationRuleV2","Update-SHUBAutomationRuleV2")
    "Severity_Label"=@("Update-SHUBFindingsBatch")
    "SortOrder"=@("Get-SHUBFindingStatisticsV2","Get-SHUBResourcesStatisticsV2")
    "VerificationState"=@("Update-SHUBFindingsBatch")
    "Workflow_Status"=@("Update-SHUBFindingsBatch")
}

_awsArgumentCompleterRegistration $SHUB_Completers $SHUB_map

$SHUB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SHUB.$($commandName.Replace('-', ''))Cmdlet]"
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

$SHUB_SelectMap = @{
    "Select"=@("Confirm-SHUBAdministratorInvitation",
               "Confirm-SHUBInvitation",
               "Remove-SHUBDeleteAutomationRule",
               "Disable-SHUBStandardsBatch",
               "Enable-SHUBStandardsBatch",
               "Get-SHUBGetAutomationRule",
               "Get-SHUBGetConfigurationPolicyAssociation",
               "Get-SHUBGetSecurityControl",
               "Get-SHUBGetStandardsControlAssociation",
               "Import-SHUBFindingsBatch",
               "Edit-SHUBUpdateAutomationRule",
               "Update-SHUBFindingsBatch",
               "Set-SHUBBatchFindingsV2",
               "Edit-SHUBUpdateStandardsControlAssociation",
               "Register-SHUBConnectorV2",
               "New-SHUBActionTarget",
               "New-SHUBAggregatorV2",
               "New-SHUBAutomationRule",
               "New-SHUBAutomationRuleV2",
               "New-SHUBConfigurationPolicy",
               "New-SHUBConnectorV2",
               "New-SHUBFindingAggregator",
               "New-SHUBInsight",
               "New-SHUBMember",
               "New-SHUBTicketV2",
               "Deny-SHUBInvitation",
               "Remove-SHUBActionTarget",
               "Remove-SHUBAggregatorV2",
               "Remove-SHUBAutomationRuleV2",
               "Remove-SHUBConfigurationPolicy",
               "Remove-SHUBConnectorV2",
               "Remove-SHUBFindingAggregator",
               "Remove-SHUBInsight",
               "Remove-SHUBInvitation",
               "Remove-SHUBMember",
               "Get-SHUBActionTarget",
               "Get-SHUBHub",
               "Get-SHUBOrganizationConfiguration",
               "Get-SHUBProduct",
               "Get-SHUBProductsV2",
               "Get-SHUBSecurityHubV2",
               "Get-SHUBStandard",
               "Get-SHUBStandardsControl",
               "Disable-SHUBImportFindingsForProduct",
               "Disable-SHUBOrganizationAdminAccount",
               "Disable-SHUBSecurityHub",
               "Disable-SHUBSecurityHubV2",
               "Remove-SHUBFromAdministratorAccount",
               "Remove-SHUBMasterAccountAssociation",
               "Remove-SHUBMemberAssociation",
               "Enable-SHUBImportFindingsForProduct",
               "Enable-SHUBOrganizationAdminAccount",
               "Enable-SHUBSecurityHub",
               "Enable-SHUBSecurityHubV2",
               "Get-SHUBAdministratorAccount",
               "Get-SHUBAggregatorV2",
               "Get-SHUBAutomationRuleV2",
               "Get-SHUBConfigurationPolicy",
               "Get-SHUBConfigurationPolicyAssociation",
               "Get-SHUBConnectorV2",
               "Get-SHUBEnabledStandard",
               "Get-SHUBFindingAggregator",
               "Get-SHUBFindingHistory",
               "Get-SHUBFinding",
               "Get-SHUBFindingStatisticsV2",
               "Get-SHUBFindingsTrendsV2",
               "Get-SHUBFindingsV2",
               "Get-SHUBInsightResult",
               "Get-SHUBInsight",
               "Get-SHUBInvitationsCount",
               "Get-SHUBMasterAccount",
               "Get-SHUBMember",
               "Get-SHUBResourcesStatisticsV2",
               "Get-SHUBResourcesTrendsV2",
               "Get-SHUBResourcesV2",
               "Get-SHUBSecurityControlDefinition",
               "Send-SHUBMemberInvitation",
               "Get-SHUBAggregatorsV2List",
               "Get-SHUBAutomationRuleList",
               "Get-SHUBAutomationRulesV2List",
               "Get-SHUBConfigurationPolicyList",
               "Get-SHUBConfigurationPolicyAssociationList",
               "Get-SHUBConnectorsV2List",
               "Get-SHUBEnabledProductsForImportList",
               "Get-SHUBFindingAggregatorList",
               "Get-SHUBInvitationList",
               "Get-SHUBMemberList",
               "Get-SHUBOrganizationAdminAccountList",
               "Get-SHUBSecurityControlDefinitionList",
               "Get-SHUBStandardsControlAssociationList",
               "Get-SHUBResourceTag",
               "Start-SHUBConfigurationPolicyAssociation",
               "Start-SHUBConfigurationPolicyDisassociation",
               "Add-SHUBResourceTag",
               "Remove-SHUBResourceTag",
               "Update-SHUBActionTarget",
               "Update-SHUBAggregatorV2",
               "Update-SHUBAutomationRuleV2",
               "Update-SHUBConfigurationPolicy",
               "Update-SHUBConnectorV2",
               "Update-SHUBFindingAggregator",
               "Update-SHUBFinding",
               "Update-SHUBInsight",
               "Update-SHUBOrganizationConfiguration",
               "Update-SHUBSecurityControl",
               "Update-SHUBSecurityHubConfiguration",
               "Update-SHUBStandardsControl")
}

_awsArgumentCompleterRegistration $SHUB_SelectCompleters $SHUB_SelectMap

