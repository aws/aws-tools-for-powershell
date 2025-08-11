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

# Argument completions for service AWS Single Sign-On Admin


$SSOADMN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SSOAdmin.ApplicationStatus
        {
            ($_ -eq "New-SSOADMNApplication/Status") -Or
            ($_ -eq "Update-SSOADMNApplication/Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SSOAdmin.ApplicationVisibility
        "New-SSOADMNApplication/PortalOptions_Visibility"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SSOAdmin.AuthenticationMethodType
        {
            ($_ -eq "Get-SSOADMNApplicationAuthenticationMethod/AuthenticationMethodType") -Or
            ($_ -eq "Remove-SSOADMNApplicationAuthenticationMethod/AuthenticationMethodType") -Or
            ($_ -eq "Write-SSOADMNApplicationAuthenticationMethod/AuthenticationMethodType")
        }
        {
            $v = "IAM"
            break
        }

        # Amazon.SSOAdmin.GrantType
        {
            ($_ -eq "Get-SSOADMNApplicationGrant/GrantType") -Or
            ($_ -eq "Remove-SSOADMNApplicationGrant/GrantType") -Or
            ($_ -eq "Write-SSOADMNApplicationGrant/GrantType")
        }
        {
            $v = "authorization_code","refresh_token","urn:ietf:params:oauth:grant-type:jwt-bearer","urn:ietf:params:oauth:grant-type:token-exchange"
            break
        }

        # Amazon.SSOAdmin.JwksRetrievalOption
        {
            ($_ -eq "New-SSOADMNTrustedTokenIssuer/OidcJwtConfiguration_JwksRetrievalOption") -Or
            ($_ -eq "Update-SSOADMNTrustedTokenIssuer/OidcJwtConfiguration_JwksRetrievalOption")
        }
        {
            $v = "OPEN_ID_DISCOVERY"
            break
        }

        # Amazon.SSOAdmin.PrincipalType
        {
            ($_ -eq "Get-SSOADMNAccountAssignmentsForPrincipalList/PrincipalType") -Or
            ($_ -eq "Get-SSOADMNApplicationAssignment/PrincipalType") -Or
            ($_ -eq "Get-SSOADMNApplicationAssignmentsForPrincipalList/PrincipalType") -Or
            ($_ -eq "New-SSOADMNAccountAssignment/PrincipalType") -Or
            ($_ -eq "New-SSOADMNApplicationAssignment/PrincipalType") -Or
            ($_ -eq "Remove-SSOADMNAccountAssignment/PrincipalType") -Or
            ($_ -eq "Remove-SSOADMNApplicationAssignment/PrincipalType")
        }
        {
            $v = "GROUP","USER"
            break
        }

        # Amazon.SSOAdmin.ProvisioningStatus
        {
            ($_ -eq "Get-SSOADMNAccountsForProvisionedPermissionSetList/ProvisioningStatus") -Or
            ($_ -eq "Get-SSOADMNPermissionSetsProvisionedToAccountList/ProvisioningStatus")
        }
        {
            $v = "LATEST_PERMISSION_SET_NOT_PROVISIONED","LATEST_PERMISSION_SET_PROVISIONED"
            break
        }

        # Amazon.SSOAdmin.ProvisionTargetType
        "Add-SSOADMNPermissionSetProvision/TargetType"
        {
            $v = "ALL_PROVISIONED_ACCOUNTS","AWS_ACCOUNT"
            break
        }

        # Amazon.SSOAdmin.SignInOrigin
        {
            ($_ -eq "New-SSOADMNApplication/SignInOptions_Origin") -Or
            ($_ -eq "Update-SSOADMNApplication/SignInOptions_Origin")
        }
        {
            $v = "APPLICATION","IDENTITY_CENTER"
            break
        }

        # Amazon.SSOAdmin.StatusValues
        {
            ($_ -eq "Get-SSOADMNAccountAssignmentCreationStatusList/Filter_Status") -Or
            ($_ -eq "Get-SSOADMNAccountAssignmentDeletionStatusList/Filter_Status") -Or
            ($_ -eq "Get-SSOADMNPermissionSetProvisioningStatusList/Filter_Status")
        }
        {
            $v = "FAILED","IN_PROGRESS","SUCCEEDED"
            break
        }

        # Amazon.SSOAdmin.TargetType
        {
            ($_ -eq "New-SSOADMNAccountAssignment/TargetType") -Or
            ($_ -eq "Remove-SSOADMNAccountAssignment/TargetType")
        }
        {
            $v = "AWS_ACCOUNT"
            break
        }

        # Amazon.SSOAdmin.TrustedTokenIssuerType
        "New-SSOADMNTrustedTokenIssuer/TrustedTokenIssuerType"
        {
            $v = "OIDC_JWT"
            break
        }

        # Amazon.SSOAdmin.UserBackgroundSessionApplicationStatus
        "Write-SSOADMNApplicationSessionConfiguration/UserBackgroundSessionApplicationStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SSOADMN_map = @{
    "AuthenticationMethodType"=@("Get-SSOADMNApplicationAuthenticationMethod","Remove-SSOADMNApplicationAuthenticationMethod","Write-SSOADMNApplicationAuthenticationMethod")
    "Filter_Status"=@("Get-SSOADMNAccountAssignmentCreationStatusList","Get-SSOADMNAccountAssignmentDeletionStatusList","Get-SSOADMNPermissionSetProvisioningStatusList")
    "GrantType"=@("Get-SSOADMNApplicationGrant","Remove-SSOADMNApplicationGrant","Write-SSOADMNApplicationGrant")
    "OidcJwtConfiguration_JwksRetrievalOption"=@("New-SSOADMNTrustedTokenIssuer","Update-SSOADMNTrustedTokenIssuer")
    "PortalOptions_Visibility"=@("New-SSOADMNApplication")
    "PrincipalType"=@("Get-SSOADMNAccountAssignmentsForPrincipalList","Get-SSOADMNApplicationAssignment","Get-SSOADMNApplicationAssignmentsForPrincipalList","New-SSOADMNAccountAssignment","New-SSOADMNApplicationAssignment","Remove-SSOADMNAccountAssignment","Remove-SSOADMNApplicationAssignment")
    "ProvisioningStatus"=@("Get-SSOADMNAccountsForProvisionedPermissionSetList","Get-SSOADMNPermissionSetsProvisionedToAccountList")
    "SignInOptions_Origin"=@("New-SSOADMNApplication","Update-SSOADMNApplication")
    "Status"=@("New-SSOADMNApplication","Update-SSOADMNApplication")
    "TargetType"=@("Add-SSOADMNPermissionSetProvision","New-SSOADMNAccountAssignment","Remove-SSOADMNAccountAssignment")
    "TrustedTokenIssuerType"=@("New-SSOADMNTrustedTokenIssuer")
    "UserBackgroundSessionApplicationStatus"=@("Write-SSOADMNApplicationSessionConfiguration")
}

_awsArgumentCompleterRegistration $SSOADMN_Completers $SSOADMN_map

$SSOADMN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SSOADMN.$($commandName.Replace('-', ''))Cmdlet]"
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

$SSOADMN_SelectMap = @{
    "Select"=@("Mount-SSOADMNCustomerManagedPolicyReferenceToPermissionSet",
               "Mount-SSOADMNManagedPolicyToPermissionSet",
               "New-SSOADMNAccountAssignment",
               "New-SSOADMNApplication",
               "New-SSOADMNApplicationAssignment",
               "New-SSOADMNInstance",
               "New-SSOADMNInstanceAccessControlAttributeConfiguration",
               "New-SSOADMNPermissionSet",
               "New-SSOADMNTrustedTokenIssuer",
               "Remove-SSOADMNAccountAssignment",
               "Remove-SSOADMNApplication",
               "Remove-SSOADMNApplicationAccessScope",
               "Remove-SSOADMNApplicationAssignment",
               "Remove-SSOADMNApplicationAuthenticationMethod",
               "Remove-SSOADMNApplicationGrant",
               "Remove-SSOADMNInlinePolicyFromPermissionSet",
               "Remove-SSOADMNInstance",
               "Remove-SSOADMNInstanceAccessControlAttributeConfiguration",
               "Remove-SSOADMNPermissionsBoundaryFromPermissionSet",
               "Remove-SSOADMNPermissionSet",
               "Remove-SSOADMNTrustedTokenIssuer",
               "Get-SSOADMNAccountAssignmentCreationStatus",
               "Get-SSOADMNAccountAssignmentDeletionStatus",
               "Get-SSOADMNApplication",
               "Get-SSOADMNApplicationAssignment",
               "Get-SSOADMNApplicationProvider",
               "Get-SSOADMNInstance",
               "Get-SSOADMNInstanceAccessControlAttributeConfiguration",
               "Get-SSOADMNPermissionSet",
               "Get-SSOADMNPermissionSetProvisioningStatus",
               "Get-SSOADMNTrustedTokenIssuer",
               "Dismount-SSOADMNCustomerManagedPolicyReferenceFromPermissionSet",
               "Dismount-SSOADMNManagedPolicyFromPermissionSet",
               "Get-SSOADMNApplicationAccessScope",
               "Get-SSOADMNApplicationAssignmentConfiguration",
               "Get-SSOADMNApplicationAuthenticationMethod",
               "Get-SSOADMNApplicationGrant",
               "Get-SSOADMNApplicationSessionConfiguration",
               "Get-SSOADMNInlinePolicyForPermissionSet",
               "Get-SSOADMNPermissionsBoundaryForPermissionSet",
               "Get-SSOADMNAccountAssignmentCreationStatusList",
               "Get-SSOADMNAccountAssignmentDeletionStatusList",
               "Get-SSOADMNAccountAssignmentList",
               "Get-SSOADMNAccountAssignmentsForPrincipalList",
               "Get-SSOADMNAccountsForProvisionedPermissionSetList",
               "Get-SSOADMNApplicationAccessScopeList",
               "Get-SSOADMNApplicationAssignmentList",
               "Get-SSOADMNApplicationAssignmentsForPrincipalList",
               "Get-SSOADMNApplicationAuthenticationMethodList",
               "Get-SSOADMNApplicationGrantList",
               "Get-SSOADMNApplicationProviderList",
               "Get-SSOADMNApplicationList",
               "Get-SSOADMNCustomerManagedPolicyReferencesInPermissionSetList",
               "Get-SSOADMNInstanceList",
               "Get-SSOADMNManagedPoliciesInPermissionSetList",
               "Get-SSOADMNPermissionSetProvisioningStatusList",
               "Get-SSOADMNPermissionSetList",
               "Get-SSOADMNPermissionSetsProvisionedToAccountList",
               "Get-SSOADMNResourceTag",
               "Get-SSOADMNTrustedTokenIssuerList",
               "Add-SSOADMNPermissionSetProvision",
               "Write-SSOADMNApplicationAccessScope",
               "Write-SSOADMNApplicationAssignmentConfiguration",
               "Write-SSOADMNApplicationAuthenticationMethod",
               "Write-SSOADMNApplicationGrant",
               "Write-SSOADMNApplicationSessionConfiguration",
               "Write-SSOADMNInlinePolicyToPermissionSet",
               "Write-SSOADMNPermissionsBoundaryToPermissionSet",
               "Add-SSOADMNResourceTag",
               "Remove-SSOADMNResourceTag",
               "Update-SSOADMNApplication",
               "Update-SSOADMNInstance",
               "Update-SSOADMNInstanceAccessControlAttributeConfiguration",
               "Update-SSOADMNPermissionSet",
               "Update-SSOADMNTrustedTokenIssuer")
}

_awsArgumentCompleterRegistration $SSOADMN_SelectCompleters $SSOADMN_SelectMap

