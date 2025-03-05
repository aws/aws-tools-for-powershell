#
# Module manifest for module 'AWS.Tools.SSOAdmin'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.SSOAdmin.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '740e18d5-9595-4361-8485-6b3371ad1099'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The SSOAdmin module of AWS Tools for PowerShell lets developers and administrators manage AWS Single Sign-On Admin from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
    )

# Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.SSOAdmin.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.SSOAdmin.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.SSOAdmin.Completers.psm1',
        'AWS.Tools.SSOAdmin.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SSOADMNPermissionSetProvision', 
        'Add-SSOADMNResourceTag', 
        'Dismount-SSOADMNCustomerManagedPolicyReferenceFromPermissionSet', 
        'Dismount-SSOADMNManagedPolicyFromPermissionSet', 
        'Get-SSOADMNAccountAssignmentCreationStatus', 
        'Get-SSOADMNAccountAssignmentCreationStatusList', 
        'Get-SSOADMNAccountAssignmentDeletionStatus', 
        'Get-SSOADMNAccountAssignmentDeletionStatusList', 
        'Get-SSOADMNAccountAssignmentList', 
        'Get-SSOADMNAccountAssignmentsForPrincipalList', 
        'Get-SSOADMNAccountsForProvisionedPermissionSetList', 
        'Get-SSOADMNApplication', 
        'Get-SSOADMNApplicationAccessScope', 
        'Get-SSOADMNApplicationAccessScopeList', 
        'Get-SSOADMNApplicationAssignment', 
        'Get-SSOADMNApplicationAssignmentConfiguration', 
        'Get-SSOADMNApplicationAssignmentList', 
        'Get-SSOADMNApplicationAssignmentsForPrincipalList', 
        'Get-SSOADMNApplicationAuthenticationMethod', 
        'Get-SSOADMNApplicationAuthenticationMethodList', 
        'Get-SSOADMNApplicationGrant', 
        'Get-SSOADMNApplicationGrantList', 
        'Get-SSOADMNApplicationList', 
        'Get-SSOADMNApplicationProvider', 
        'Get-SSOADMNApplicationProviderList', 
        'Get-SSOADMNCustomerManagedPolicyReferencesInPermissionSetList', 
        'Get-SSOADMNInlinePolicyForPermissionSet', 
        'Get-SSOADMNInstance', 
        'Get-SSOADMNInstanceAccessControlAttributeConfiguration', 
        'Get-SSOADMNInstanceList', 
        'Get-SSOADMNManagedPoliciesInPermissionSetList', 
        'Get-SSOADMNPermissionsBoundaryForPermissionSet', 
        'Get-SSOADMNPermissionSet', 
        'Get-SSOADMNPermissionSetList', 
        'Get-SSOADMNPermissionSetProvisioningStatus', 
        'Get-SSOADMNPermissionSetProvisioningStatusList', 
        'Get-SSOADMNPermissionSetsProvisionedToAccountList', 
        'Get-SSOADMNResourceTag', 
        'Get-SSOADMNTrustedTokenIssuer', 
        'Get-SSOADMNTrustedTokenIssuerList', 
        'Mount-SSOADMNCustomerManagedPolicyReferenceToPermissionSet', 
        'Mount-SSOADMNManagedPolicyToPermissionSet', 
        'New-SSOADMNAccountAssignment', 
        'New-SSOADMNApplication', 
        'New-SSOADMNApplicationAssignment', 
        'New-SSOADMNInstance', 
        'New-SSOADMNInstanceAccessControlAttributeConfiguration', 
        'New-SSOADMNPermissionSet', 
        'New-SSOADMNTrustedTokenIssuer', 
        'Remove-SSOADMNAccountAssignment', 
        'Remove-SSOADMNApplication', 
        'Remove-SSOADMNApplicationAccessScope', 
        'Remove-SSOADMNApplicationAssignment', 
        'Remove-SSOADMNApplicationAuthenticationMethod', 
        'Remove-SSOADMNApplicationGrant', 
        'Remove-SSOADMNInlinePolicyFromPermissionSet', 
        'Remove-SSOADMNInstance', 
        'Remove-SSOADMNInstanceAccessControlAttributeConfiguration', 
        'Remove-SSOADMNPermissionsBoundaryFromPermissionSet', 
        'Remove-SSOADMNPermissionSet', 
        'Remove-SSOADMNResourceTag', 
        'Remove-SSOADMNTrustedTokenIssuer', 
        'Update-SSOADMNApplication', 
        'Update-SSOADMNInstance', 
        'Update-SSOADMNInstanceAccessControlAttributeConfiguration', 
        'Update-SSOADMNPermissionSet', 
        'Update-SSOADMNTrustedTokenIssuer', 
        'Write-SSOADMNApplicationAccessScope', 
        'Write-SSOADMNApplicationAssignmentConfiguration', 
        'Write-SSOADMNApplicationAuthenticationMethod', 
        'Write-SSOADMNApplicationGrant', 
        'Write-SSOADMNInlinePolicyToPermissionSet', 
        'Write-SSOADMNPermissionsBoundaryToPermissionSet')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.SSOAdmin.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview002'
        }
    }
}
