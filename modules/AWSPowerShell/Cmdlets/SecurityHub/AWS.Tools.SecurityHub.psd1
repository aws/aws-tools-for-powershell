#
# Module manifest for module 'AWS.Tools.SecurityHub'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.SecurityHub.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'af56b77c-0f06-4578-8714-9f4df4cf894e'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The SecurityHub module of AWS Tools for PowerShell lets developers and administrators manage AWS Security Hub from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.SecurityHub.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.SecurityHub.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.SecurityHub.Completers.psm1',
        'AWS.Tools.SecurityHub.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SHUBResourceTag', 
        'Confirm-SHUBAdministratorInvitation', 
        'Confirm-SHUBInvitation', 
        'Deny-SHUBInvitation', 
        'Disable-SHUBImportFindingsForProduct', 
        'Disable-SHUBOrganizationAdminAccount', 
        'Disable-SHUBSecurityHub', 
        'Disable-SHUBStandardsBatch', 
        'Edit-SHUBUpdateAutomationRule', 
        'Edit-SHUBUpdateStandardsControlAssociation', 
        'Enable-SHUBImportFindingsForProduct', 
        'Enable-SHUBOrganizationAdminAccount', 
        'Enable-SHUBSecurityHub', 
        'Enable-SHUBStandardsBatch', 
        'Get-SHUBActionTarget', 
        'Get-SHUBAdministratorAccount', 
        'Get-SHUBAutomationRuleList', 
        'Get-SHUBConfigurationPolicy', 
        'Get-SHUBConfigurationPolicyAssociation', 
        'Get-SHUBConfigurationPolicyAssociationList', 
        'Get-SHUBConfigurationPolicyList', 
        'Get-SHUBEnabledProductsForImportList', 
        'Get-SHUBEnabledStandard', 
        'Get-SHUBFinding', 
        'Get-SHUBFindingAggregator', 
        'Get-SHUBFindingAggregatorList', 
        'Get-SHUBFindingHistory', 
        'Get-SHUBGetAutomationRule', 
        'Get-SHUBGetConfigurationPolicyAssociation', 
        'Get-SHUBGetSecurityControl', 
        'Get-SHUBGetStandardsControlAssociation', 
        'Get-SHUBHub', 
        'Get-SHUBInsight', 
        'Get-SHUBInsightResult', 
        'Get-SHUBInvitationList', 
        'Get-SHUBInvitationsCount', 
        'Get-SHUBMasterAccount', 
        'Get-SHUBMember', 
        'Get-SHUBMemberList', 
        'Get-SHUBOrganizationAdminAccountList', 
        'Get-SHUBOrganizationConfiguration', 
        'Get-SHUBProduct', 
        'Get-SHUBResourceTag', 
        'Get-SHUBSecurityControlDefinition', 
        'Get-SHUBSecurityControlDefinitionList', 
        'Get-SHUBStandard', 
        'Get-SHUBStandardsControl', 
        'Get-SHUBStandardsControlAssociationList', 
        'Import-SHUBFindingsBatch', 
        'New-SHUBActionTarget', 
        'New-SHUBAutomationRule', 
        'New-SHUBConfigurationPolicy', 
        'New-SHUBFindingAggregator', 
        'New-SHUBInsight', 
        'New-SHUBMember', 
        'Remove-SHUBActionTarget', 
        'Remove-SHUBConfigurationPolicy', 
        'Remove-SHUBDeleteAutomationRule', 
        'Remove-SHUBFindingAggregator', 
        'Remove-SHUBFromAdministratorAccount', 
        'Remove-SHUBInsight', 
        'Remove-SHUBInvitation', 
        'Remove-SHUBMasterAccountAssociation', 
        'Remove-SHUBMember', 
        'Remove-SHUBMemberAssociation', 
        'Remove-SHUBResourceTag', 
        'Send-SHUBMemberInvitation', 
        'Start-SHUBConfigurationPolicyAssociation', 
        'Start-SHUBConfigurationPolicyDisassociation', 
        'Update-SHUBActionTarget', 
        'Update-SHUBConfigurationPolicy', 
        'Update-SHUBFinding', 
        'Update-SHUBFindingAggregator', 
        'Update-SHUBFindingsBatch', 
        'Update-SHUBInsight', 
        'Update-SHUBOrganizationConfiguration', 
        'Update-SHUBSecurityControl', 
        'Update-SHUBSecurityHubConfiguration', 
        'Update-SHUBStandardsControl')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.SecurityHub.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview001'
        }
    }
}
