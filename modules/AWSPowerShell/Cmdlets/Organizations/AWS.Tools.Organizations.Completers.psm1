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

# Argument completions for service AWS Organizations


$ORG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Organizations.ActionType
        {
            ($_ -eq "Get-ORGAccountHandshakeList/Filter_ActionType") -Or
            ($_ -eq "Get-ORGOrganizationHandshakeList/Filter_ActionType")
        }
        {
            $v = "ADD_ORGANIZATIONS_SERVICE_LINKED_ROLE","APPROVE_ALL_FEATURES","ENABLE_ALL_FEATURES","INVITE"
            break
        }

        # Amazon.Organizations.ChildType
        "Get-ORGChild/ChildType"
        {
            $v = "ACCOUNT","ORGANIZATIONAL_UNIT"
            break
        }

        # Amazon.Organizations.EffectivePolicyType
        "Get-ORGEffectivePolicy/PolicyType"
        {
            $v = "TAG_POLICY"
            break
        }

        # Amazon.Organizations.HandshakePartyType
        "New-ORGAccountInvitation/Target_Type"
        {
            $v = "ACCOUNT","EMAIL","ORGANIZATION"
            break
        }

        # Amazon.Organizations.IAMUserAccessToBilling
        {
            ($_ -eq "New-ORGAccount/IamUserAccessToBilling") -Or
            ($_ -eq "New-ORGGovCloudAccount/IamUserAccessToBilling")
        }
        {
            $v = "ALLOW","DENY"
            break
        }

        # Amazon.Organizations.OrganizationFeatureSet
        "New-ORGOrganization/FeatureSet"
        {
            $v = "ALL","CONSOLIDATED_BILLING"
            break
        }

        # Amazon.Organizations.PolicyType
        {
            ($_ -eq "Get-ORGPolicyForTarget/Filter") -Or
            ($_ -eq "Get-ORGPolicyList/Filter") -Or
            ($_ -eq "Disable-ORGPolicyType/PolicyType") -Or
            ($_ -eq "Enable-ORGPolicyType/PolicyType") -Or
            ($_ -eq "New-ORGPolicy/Type")
        }
        {
            $v = "SERVICE_CONTROL_POLICY","TAG_POLICY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ORG_map = @{
    "ChildType"=@("Get-ORGChild")
    "FeatureSet"=@("New-ORGOrganization")
    "Filter"=@("Get-ORGPolicyForTarget","Get-ORGPolicyList")
    "Filter_ActionType"=@("Get-ORGAccountHandshakeList","Get-ORGOrganizationHandshakeList")
    "IamUserAccessToBilling"=@("New-ORGAccount","New-ORGGovCloudAccount")
    "PolicyType"=@("Disable-ORGPolicyType","Enable-ORGPolicyType","Get-ORGEffectivePolicy")
    "Target_Type"=@("New-ORGAccountInvitation")
    "Type"=@("New-ORGPolicy")
}

_awsArgumentCompleterRegistration $ORG_Completers $ORG_map

$ORG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ORG.$($commandName.Replace('-', ''))Cmdlet]"
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

$ORG_SelectMap = @{
    "Select"=@("Confirm-ORGHandshake",
               "Add-ORGPolicy",
               "Stop-ORGHandshake",
               "New-ORGAccount",
               "New-ORGGovCloudAccount",
               "New-ORGOrganization",
               "New-ORGOrganizationalUnit",
               "New-ORGPolicy",
               "Deny-ORGHandshake",
               "Remove-ORGOrganization",
               "Remove-ORGOrganizationalUnit",
               "Remove-ORGPolicy",
               "Unregister-ORGDelegatedAdministrator",
               "Get-ORGAccount",
               "Get-ORGAccountCreationStatus",
               "Get-ORGEffectivePolicy",
               "Get-ORGHandshake",
               "Get-ORGOrganization",
               "Get-ORGOrganizationalUnit",
               "Get-ORGPolicy",
               "Dismount-ORGPolicy",
               "Disable-ORGAWSServiceAccess",
               "Disable-ORGPolicyType",
               "Enable-ORGAllFeature",
               "Enable-ORGAWSServiceAccess",
               "Enable-ORGPolicyType",
               "New-ORGAccountInvitation",
               "Remove-ORGOrganizationAssociation",
               "Get-ORGAccountList",
               "Get-ORGAccountForParent",
               "Get-ORGAWSServiceAccessForOrganization",
               "Get-ORGChild",
               "Get-ORGAccountCreationStatusList",
               "Get-ORGDelegatedAdministratorList",
               "Get-ORGDelegatedServicesForAccountList",
               "Get-ORGAccountHandshakeList",
               "Get-ORGOrganizationHandshakeList",
               "Get-ORGOrganizationalUnitList",
               "Get-ORGParent",
               "Get-ORGPolicyList",
               "Get-ORGPolicyForTarget",
               "Get-ORGRoot",
               "Get-ORGResourceTag",
               "Get-ORGTargetForPolicy",
               "Move-ORGAccount",
               "Register-ORGDelegatedAdministrator",
               "Remove-ORGAccountFromOrganization",
               "Add-ORGResourceTag",
               "Remove-ORGResourceTag",
               "Update-ORGOrganizationalUnit",
               "Update-ORGPolicy")
}

_awsArgumentCompleterRegistration $ORG_SelectCompleters $ORG_SelectMap

