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

# Argument completions for service AWS Identity and Access Management


$IAM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IdentityManagement.AccessAdvisorUsageGranularityType
        "Request-IAMServiceLastAccessedDetail/Granularity"
        {
            $v = "ACTION_LEVEL","SERVICE_LEVEL"
            break
        }

        # Amazon.IdentityManagement.AssertionEncryptionModeType
        {
            ($_ -eq "New-IAMSAMLProvider/AssertionEncryptionMode") -Or
            ($_ -eq "Update-IAMSAMLProvider/AssertionEncryptionMode")
        }
        {
            $v = "Allowed","Required"
            break
        }

        # Amazon.IdentityManagement.AssignmentStatusType
        "Get-IAMVirtualMFADevice/AssignmentStatus"
        {
            $v = "Any","Assigned","Unassigned"
            break
        }

        # Amazon.IdentityManagement.EncodingType
        "Get-IAMSSHPublicKey/Encoding"
        {
            $v = "PEM","SSH"
            break
        }

        # Amazon.IdentityManagement.EntityType
        "Get-IAMEntitiesForPolicy/EntityFilter"
        {
            $v = "AWSManagedPolicy","Group","LocalManagedPolicy","Role","User"
            break
        }

        # Amazon.IdentityManagement.GlobalEndpointTokenVersion
        "Set-IAMSecurityTokenServicePreference/GlobalEndpointTokenVersion"
        {
            $v = "v1Token","v2Token"
            break
        }

        # Amazon.IdentityManagement.PolicyScopeType
        "Get-IAMPolicyList/Scope"
        {
            $v = "All","AWS","Local"
            break
        }

        # Amazon.IdentityManagement.PolicyUsageType
        {
            ($_ -eq "Get-IAMEntitiesForPolicy/PolicyUsageFilter") -Or
            ($_ -eq "Get-IAMPolicyList/PolicyUsageFilter")
        }
        {
            $v = "PermissionsBoundary","PermissionsPolicy"
            break
        }

        # Amazon.IdentityManagement.SortKeyType
        "Get-IAMOrganizationsAccessReport/SortKey"
        {
            $v = "LAST_AUTHENTICATED_TIME_ASCENDING","LAST_AUTHENTICATED_TIME_DESCENDING","SERVICE_NAMESPACE_ASCENDING","SERVICE_NAMESPACE_DESCENDING"
            break
        }

        # Amazon.IdentityManagement.StatusType
        {
            ($_ -eq "Update-IAMAccessKey/Status") -Or
            ($_ -eq "Update-IAMServiceSpecificCredential/Status") -Or
            ($_ -eq "Update-IAMSigningCertificate/Status") -Or
            ($_ -eq "Update-IAMSSHPublicKey/Status")
        }
        {
            $v = "Active","Expired","Inactive"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IAM_map = @{
    "AssertionEncryptionMode"=@("New-IAMSAMLProvider","Update-IAMSAMLProvider")
    "AssignmentStatus"=@("Get-IAMVirtualMFADevice")
    "Encoding"=@("Get-IAMSSHPublicKey")
    "EntityFilter"=@("Get-IAMEntitiesForPolicy")
    "GlobalEndpointTokenVersion"=@("Set-IAMSecurityTokenServicePreference")
    "Granularity"=@("Request-IAMServiceLastAccessedDetail")
    "PolicyUsageFilter"=@("Get-IAMEntitiesForPolicy","Get-IAMPolicyList")
    "Scope"=@("Get-IAMPolicyList")
    "SortKey"=@("Get-IAMOrganizationsAccessReport")
    "Status"=@("Update-IAMAccessKey","Update-IAMServiceSpecificCredential","Update-IAMSigningCertificate","Update-IAMSSHPublicKey")
}

_awsArgumentCompleterRegistration $IAM_Completers $IAM_map

$IAM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IAM.$($commandName.Replace('-', ''))Cmdlet]"
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

$IAM_SelectMap = @{
    "Select"=@("Add-IAMClientIDToOpenIDConnectProvider",
               "Add-IAMRoleToInstanceProfile",
               "Add-IAMUserToGroup",
               "Register-IAMGroupPolicy",
               "Register-IAMRolePolicy",
               "Register-IAMUserPolicy",
               "Edit-IAMPassword",
               "New-IAMAccessKey",
               "New-IAMAccountAlias",
               "New-IAMGroup",
               "New-IAMInstanceProfile",
               "New-IAMLoginProfile",
               "New-IAMOpenIDConnectProvider",
               "New-IAMPolicy",
               "New-IAMPolicyVersion",
               "New-IAMRole",
               "New-IAMSAMLProvider",
               "New-IAMServiceLinkedRole",
               "New-IAMServiceSpecificCredential",
               "New-IAMUser",
               "New-IAMVirtualMFADevice",
               "Disable-IAMMFADevice",
               "Remove-IAMAccessKey",
               "Remove-IAMAccountAlias",
               "Remove-IAMAccountPasswordPolicy",
               "Remove-IAMGroup",
               "Remove-IAMGroupPolicy",
               "Remove-IAMInstanceProfile",
               "Remove-IAMLoginProfile",
               "Remove-IAMOpenIDConnectProvider",
               "Remove-IAMPolicy",
               "Remove-IAMPolicyVersion",
               "Remove-IAMRole",
               "Remove-IAMRolePermissionsBoundary",
               "Remove-IAMRolePolicy",
               "Remove-IAMSAMLProvider",
               "Remove-IAMServerCertificate",
               "Remove-IAMServiceLinkedRole",
               "Remove-IAMServiceSpecificCredential",
               "Remove-IAMSigningCertificate",
               "Remove-IAMSSHPublicKey",
               "Remove-IAMUser",
               "Remove-IAMUserPermissionsBoundary",
               "Remove-IAMUserPolicy",
               "Remove-IAMVirtualMFADevice",
               "Unregister-IAMGroupPolicy",
               "Unregister-IAMRolePolicy",
               "Unregister-IAMUserPolicy",
               "Disable-IAMOrganizationsRootCredentialsManagement",
               "Disable-IAMOrganizationsRootSession",
               "Enable-IAMMFADevice",
               "Enable-IAMOrganizationsRootCredentialsManagement",
               "Enable-IAMOrganizationsRootSession",
               "Request-IAMCredentialReport",
               "New-IAMOrganizationsAccessReport",
               "Request-IAMServiceLastAccessedDetail",
               "Get-IAMAccessKeyLastUsed",
               "Get-IAMAccountAuthorizationDetail",
               "Get-IAMAccountPasswordPolicy",
               "Get-IAMAccountSummary",
               "Get-IAMContextKeysForCustomPolicy",
               "Get-IAMContextKeysForPrincipalPolicy",
               "Get-IAMCredentialReport",
               "Get-IAMGroup",
               "Get-IAMGroupPolicy",
               "Get-IAMInstanceProfile",
               "Get-IAMLoginProfile",
               "Get-IAMMFADeviceMetadata",
               "Get-IAMOpenIDConnectProvider",
               "Get-IAMOrganizationsAccessReport",
               "Get-IAMPolicy",
               "Get-IAMPolicyVersion",
               "Get-IAMRole",
               "Get-IAMRolePolicy",
               "Get-IAMSAMLProvider",
               "Get-IAMServerCertificate",
               "Get-IAMServiceLastAccessedDetail",
               "Get-IAMServiceLastAccessedDetailWithEntity",
               "Get-IAMServiceLinkedRoleDeletionStatus",
               "Get-IAMSSHPublicKey",
               "Get-IAMUser",
               "Get-IAMUserPolicy",
               "Get-IAMAccessKey",
               "Get-IAMAccountAlias",
               "Get-IAMAttachedGroupPolicyList",
               "Get-IAMAttachedRolePolicyList",
               "Get-IAMAttachedUserPolicyList",
               "Get-IAMEntitiesForPolicy",
               "Get-IAMGroupPolicyList",
               "Get-IAMGroupList",
               "Get-IAMGroupForUser",
               "Get-IAMInstanceProfileList",
               "Get-IAMInstanceProfileForRole",
               "Get-IAMInstanceProfileTagList",
               "Get-IAMMFADevice",
               "Get-IAMMFADeviceTagList",
               "Get-IAMOpenIDConnectProviderList",
               "Get-IAMOpenIDConnectProviderTagList",
               "Get-IAMOrganizationsFeature",
               "Get-IAMPolicyList",
               "Get-IAMPolicyGrantingServiceAccessList",
               "Get-IAMPolicyTagList",
               "Get-IAMPolicyVersionList",
               "Get-IAMRolePolicyList",
               "Get-IAMRoleList",
               "Get-IAMRoleTagList",
               "Get-IAMSAMLProviderList",
               "Get-IAMSAMLProviderTagList",
               "Get-IAMServerCertificateList",
               "Get-IAMServerCertificateTagList",
               "Get-IAMServiceSpecificCredentialList",
               "Get-IAMSigningCertificate",
               "Get-IAMSSHPublicKeyList",
               "Get-IAMUserPolicyList",
               "Get-IAMUserList",
               "Get-IAMUserTagList",
               "Get-IAMVirtualMFADevice",
               "Write-IAMGroupPolicy",
               "Set-IAMRolePermissionsBoundary",
               "Write-IAMRolePolicy",
               "Set-IAMUserPermissionsBoundary",
               "Write-IAMUserPolicy",
               "Remove-IAMClientIDFromOpenIDConnectProvider",
               "Remove-IAMRoleFromInstanceProfile",
               "Remove-IAMUserFromGroup",
               "Reset-IAMServiceSpecificCredential",
               "Sync-IAMMFADevice",
               "Set-IAMDefaultPolicyVersion",
               "Set-IAMSecurityTokenServicePreference",
               "Test-IAMCustomPolicy",
               "Test-IAMPrincipalPolicy",
               "Add-IAMInstanceProfileTag",
               "Add-IAMMFADeviceTag",
               "Add-IAMOpenIDConnectProviderTag",
               "Add-IAMPolicyTag",
               "Add-IAMRoleTag",
               "Add-IAMSAMLProviderTag",
               "Add-IAMServerCertificateTag",
               "Add-IAMUserTag",
               "Remove-IAMInstanceProfileTag",
               "Remove-IAMMFADeviceTag",
               "Remove-IAMOpenIDConnectProviderTag",
               "Remove-IAMPolicyTag",
               "Remove-IAMRoleTag",
               "Remove-IAMSAMLProviderTag",
               "Remove-IAMServerCertificateTag",
               "Remove-IAMUserTag",
               "Update-IAMAccessKey",
               "Update-IAMAccountPasswordPolicy",
               "Update-IAMAssumeRolePolicy",
               "Update-IAMGroup",
               "Update-IAMLoginProfile",
               "Update-IAMOpenIDConnectProviderThumbprint",
               "Update-IAMRole",
               "Update-IAMRoleDescription",
               "Update-IAMSAMLProvider",
               "Update-IAMServerCertificate",
               "Update-IAMServiceSpecificCredential",
               "Update-IAMSigningCertificate",
               "Update-IAMSSHPublicKey",
               "Update-IAMUser",
               "Publish-IAMServerCertificate",
               "Publish-IAMSigningCertificate",
               "Publish-IAMSSHPublicKey")
}

_awsArgumentCompleterRegistration $IAM_SelectCompleters $IAM_SelectMap

