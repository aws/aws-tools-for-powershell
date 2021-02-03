#
# Module manifest for module 'AWS.Tools.IdentityManagement'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.IdentityManagement.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '1748b4bc-1117-4cfb-9b5e-b80026f1b165'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2021 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The IdentityManagement module of AWS Tools for PowerShell lets developers and administrators manage AWS Identity and Access Management from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
The module AWS.Tools.Installer (https://www.powershellgallery.com/packages/AWS.Tools.Installer/) makes it easier to install, update and uninstall the AWS.Tools modules.
This version of AWS Tools for PowerShell is compatible with Windows PowerShell 5.1+ and PowerShell Core 6+ on Windows, Linux and macOS. When running on Windows PowerShell, .NET Framework 4.7.2 or newer is required. Alternative modules AWSPowerShell.NetCore and AWSPowerShell, provide support for all AWS services from a single module and also support older versions of Windows PowerShell and .NET Framework.'

    # Minimum version of the PowerShell engine required by this module
    PowerShellVersion = '5.1'

    # Name of the PowerShell host required by this module
    PowerShellHostName = ''

    # Minimum version of the PowerShell host required by this module
    PowerShellHostVersion = ''

    # Minimum version of the .NET Framework required by this module
    DotNetFrameworkVersion = '4.7.2'

    # Minimum version of the common language runtime (CLR) required by this module
    CLRVersion = ''

    # Processor architecture (None, X86, Amd64, IA64) required by this module
    ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    RequiredModules = @(
        @{
            ModuleName = 'AWS.Tools.Common';
            RequiredVersion = '0.0.0.0';
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }
    )

    # Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.IdentityManagement.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.IdentityManagement.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.IdentityManagement.Completers.psm1',
        'AWS.Tools.IdentityManagement.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-IAMClientIDToOpenIDConnectProvider', 
        'Add-IAMInstanceProfileTag', 
        'Add-IAMMFADeviceTag', 
        'Add-IAMOpenIDConnectProviderTag', 
        'Add-IAMPolicyTag', 
        'Add-IAMRoleTag', 
        'Add-IAMRoleToInstanceProfile', 
        'Add-IAMSAMLProviderTag', 
        'Add-IAMServerCertificateTag', 
        'Add-IAMUserTag', 
        'Add-IAMUserToGroup', 
        'Disable-IAMMFADevice', 
        'Edit-IAMPassword', 
        'Enable-IAMMFADevice', 
        'Get-IAMAccessKey', 
        'Get-IAMAccessKeyLastUsed', 
        'Get-IAMAccountAlias', 
        'Get-IAMAccountAuthorizationDetail', 
        'Get-IAMAccountPasswordPolicy', 
        'Get-IAMAccountSummary', 
        'Get-IAMAttachedGroupPolicyList', 
        'Get-IAMAttachedRolePolicyList', 
        'Get-IAMAttachedUserPolicyList', 
        'Get-IAMContextKeysForCustomPolicy', 
        'Get-IAMContextKeysForPrincipalPolicy', 
        'Get-IAMCredentialReport', 
        'Get-IAMEntitiesForPolicy', 
        'Get-IAMGroup', 
        'Get-IAMGroupForUser', 
        'Get-IAMGroupList', 
        'Get-IAMGroupPolicy', 
        'Get-IAMGroupPolicyList', 
        'Get-IAMInstanceProfile', 
        'Get-IAMInstanceProfileForRole', 
        'Get-IAMInstanceProfileList', 
        'Get-IAMInstanceProfileTagList', 
        'Get-IAMLoginProfile', 
        'Get-IAMMFADevice', 
        'Get-IAMMFADeviceTagList', 
        'Get-IAMOpenIDConnectProvider', 
        'Get-IAMOpenIDConnectProviderList', 
        'Get-IAMOpenIDConnectProviderTagList', 
        'Get-IAMOrganizationsAccessReport', 
        'Get-IAMPolicy', 
        'Get-IAMPolicyGrantingServiceAccessList', 
        'Get-IAMPolicyList', 
        'Get-IAMPolicyTagList', 
        'Get-IAMPolicyVersion', 
        'Get-IAMPolicyVersionList', 
        'Get-IAMRole', 
        'Get-IAMRoleList', 
        'Get-IAMRolePolicy', 
        'Get-IAMRolePolicyList', 
        'Get-IAMRoleTagList', 
        'Get-IAMSAMLProvider', 
        'Get-IAMSAMLProviderList', 
        'Get-IAMSAMLProviderTagList', 
        'Get-IAMServerCertificate', 
        'Get-IAMServerCertificateList', 
        'Get-IAMServerCertificateTagList', 
        'Get-IAMServiceLastAccessedDetail', 
        'Get-IAMServiceLastAccessedDetailWithEntity', 
        'Get-IAMServiceLinkedRoleDeletionStatus', 
        'Get-IAMServiceSpecificCredentialList', 
        'Get-IAMSigningCertificate', 
        'Get-IAMSSHPublicKey', 
        'Get-IAMSSHPublicKeyList', 
        'Get-IAMUser', 
        'Get-IAMUserList', 
        'Get-IAMUserPolicy', 
        'Get-IAMUserPolicyList', 
        'Get-IAMUserTagList', 
        'Get-IAMVirtualMFADevice', 
        'New-IAMAccessKey', 
        'New-IAMAccountAlias', 
        'New-IAMGroup', 
        'New-IAMInstanceProfile', 
        'New-IAMLoginProfile', 
        'New-IAMOpenIDConnectProvider', 
        'New-IAMOrganizationsAccessReport', 
        'New-IAMPolicy', 
        'New-IAMPolicyVersion', 
        'New-IAMRole', 
        'New-IAMSAMLProvider', 
        'New-IAMServiceLinkedRole', 
        'New-IAMServiceSpecificCredential', 
        'New-IAMUser', 
        'New-IAMVirtualMFADevice', 
        'Publish-IAMServerCertificate', 
        'Publish-IAMSigningCertificate', 
        'Publish-IAMSSHPublicKey', 
        'Register-IAMGroupPolicy', 
        'Register-IAMRolePolicy', 
        'Register-IAMUserPolicy', 
        'Remove-IAMAccessKey', 
        'Remove-IAMAccountAlias', 
        'Remove-IAMAccountPasswordPolicy', 
        'Remove-IAMClientIDFromOpenIDConnectProvider', 
        'Remove-IAMGroup', 
        'Remove-IAMGroupPolicy', 
        'Remove-IAMInstanceProfile', 
        'Remove-IAMInstanceProfileTag', 
        'Remove-IAMLoginProfile', 
        'Remove-IAMMFADeviceTag', 
        'Remove-IAMOpenIDConnectProvider', 
        'Remove-IAMOpenIDConnectProviderTag', 
        'Remove-IAMPolicy', 
        'Remove-IAMPolicyTag', 
        'Remove-IAMPolicyVersion', 
        'Remove-IAMRole', 
        'Remove-IAMRoleFromInstanceProfile', 
        'Remove-IAMRolePermissionsBoundary', 
        'Remove-IAMRolePolicy', 
        'Remove-IAMRoleTag', 
        'Remove-IAMSAMLProvider', 
        'Remove-IAMSAMLProviderTag', 
        'Remove-IAMServerCertificate', 
        'Remove-IAMServerCertificateTag', 
        'Remove-IAMServiceLinkedRole', 
        'Remove-IAMServiceSpecificCredential', 
        'Remove-IAMSigningCertificate', 
        'Remove-IAMSSHPublicKey', 
        'Remove-IAMUser', 
        'Remove-IAMUserFromGroup', 
        'Remove-IAMUserPermissionsBoundary', 
        'Remove-IAMUserPolicy', 
        'Remove-IAMUserTag', 
        'Remove-IAMVirtualMFADevice', 
        'Request-IAMCredentialReport', 
        'Request-IAMServiceLastAccessedDetail', 
        'Reset-IAMServiceSpecificCredential', 
        'Set-IAMDefaultPolicyVersion', 
        'Set-IAMRolePermissionsBoundary', 
        'Set-IAMSecurityTokenServicePreference', 
        'Set-IAMUserPermissionsBoundary', 
        'Sync-IAMMFADevice', 
        'Test-IAMCustomPolicy', 
        'Test-IAMPrincipalPolicy', 
        'Unregister-IAMGroupPolicy', 
        'Unregister-IAMRolePolicy', 
        'Unregister-IAMUserPolicy', 
        'Update-IAMAccessKey', 
        'Update-IAMAccountPasswordPolicy', 
        'Update-IAMAssumeRolePolicy', 
        'Update-IAMGroup', 
        'Update-IAMLoginProfile', 
        'Update-IAMOpenIDConnectProviderThumbprint', 
        'Update-IAMRole', 
        'Update-IAMRoleDescription', 
        'Update-IAMSAMLProvider', 
        'Update-IAMServerCertificate', 
        'Update-IAMServiceSpecificCredential', 
        'Update-IAMSigningCertificate', 
        'Update-IAMSSHPublicKey', 
        'Update-IAMUser', 
        'Write-IAMGroupPolicy', 
        'Write-IAMRolePolicy', 
        'Write-IAMUserPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-IAMAccountAuthorizationDetails', 
        'Get-IAMAttachedGroupPolicies', 
        'Get-IAMAttachedRolePolicies', 
        'Get-IAMAttachedUserPolicies', 
        'Get-IAMGroupPolicies', 
        'Get-IAMGroups', 
        'Get-IAMInstanceProfiles', 
        'Get-IAMOpenIDConnectProviders', 
        'Get-IAMPolicies', 
        'Get-IAMPolicyVersions', 
        'Get-IAMRolePolicies', 
        'Get-IAMRoles', 
        'Get-IAMSAMLProviders', 
        'Get-IAMServerCertificates', 
        'Get-IAMUserPolicies', 
        'Get-IAMUsers')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.IdentityManagement.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md'
        }
    }
}
