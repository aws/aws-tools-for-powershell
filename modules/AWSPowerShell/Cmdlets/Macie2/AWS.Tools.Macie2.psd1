#
# Module manifest for module 'AWS.Tools.Macie2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Macie2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'F051B64A-9E6E-4A10-A2F7-F513FBCDCC6E'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Macie2 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Macie 2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }    )

# Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.Macie2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Macie2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Macie2.Completers.psm1',
        'AWS.Tools.Macie2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-MAC2ResourceTag', 
        'Approve-MAC2Invitation', 
        'Deny-MAC2Invitation', 
        'Disable-MAC2Macie', 
        'Disable-MAC2OrganizationAdminAccount', 
        'Enable-MAC2Macie', 
        'Enable-MAC2OrganizationAdminAccount', 
        'Get-MAC2AdministratorAccount', 
        'Get-MAC2AllowList', 
        'Get-MAC2AllowListList', 
        'Get-MAC2AutomatedDiscoveryAccountList', 
        'Get-MAC2AutomatedDiscoveryConfiguration', 
        'Get-MAC2Bucket', 
        'Get-MAC2BucketStatistic', 
        'Get-MAC2ClassificationExportConfiguration', 
        'Get-MAC2ClassificationJob', 
        'Get-MAC2ClassificationJobList', 
        'Get-MAC2ClassificationScope', 
        'Get-MAC2ClassificationScopeList', 
        'Get-MAC2CustomDataIdentifier', 
        'Get-MAC2CustomDataIdentifierList', 
        'Get-MAC2Finding', 
        'Get-MAC2FindingList', 
        'Get-MAC2FindingsFilter', 
        'Get-MAC2FindingsFilterList', 
        'Get-MAC2FindingsPublicationConfiguration', 
        'Get-MAC2FindingStatistic', 
        'Get-MAC2GetCustomDataIdentifier', 
        'Get-MAC2InvitationList', 
        'Get-MAC2InvitationsCount', 
        'Get-MAC2MacieSession', 
        'Get-MAC2ManagedDataIdentifierList', 
        'Get-MAC2MasterAccount', 
        'Get-MAC2Member', 
        'Get-MAC2MemberList', 
        'Get-MAC2OrganizationAdminAccountList', 
        'Get-MAC2OrganizationConfiguration', 
        'Get-MAC2ResourceProfile', 
        'Get-MAC2ResourceProfileArtifactList', 
        'Get-MAC2ResourceProfileDetectionList', 
        'Get-MAC2ResourceTag', 
        'Get-MAC2RevealConfiguration', 
        'Get-MAC2SensitiveDataOccurrence', 
        'Get-MAC2SensitiveDataOccurrencesAvailability', 
        'Get-MAC2SensitivityInspectionTemplate', 
        'Get-MAC2SensitivityInspectionTemplateList', 
        'Get-MAC2UsageStatistic', 
        'Get-MAC2UsageTotal', 
        'New-MAC2AllowList', 
        'New-MAC2ClassificationJob', 
        'New-MAC2CustomDataIdentifier', 
        'New-MAC2FindingsFilter', 
        'New-MAC2Invitation', 
        'New-MAC2Member', 
        'New-MAC2SampleFinding', 
        'Remove-MAC2AllowList', 
        'Remove-MAC2CustomDataIdentifier', 
        'Remove-MAC2FindingsFilter', 
        'Remove-MAC2Invitation', 
        'Remove-MAC2Member', 
        'Remove-MAC2ResourceTag', 
        'Search-MAC2Resource', 
        'Test-MAC2CustomDataIdentifier', 
        'Unregister-MAC2FromAdministratorAccount', 
        'Unregister-MAC2FromMasterAccount', 
        'Unregister-MAC2Member', 
        'Update-MAC2AllowList', 
        'Update-MAC2AutomatedDiscoveryConfiguration', 
        'Update-MAC2ClassificationJob', 
        'Update-MAC2ClassificationScope', 
        'Update-MAC2FindingsFilter', 
        'Update-MAC2MacieSession', 
        'Update-MAC2MemberSession', 
        'Update-MAC2OrganizationConfiguration', 
        'Update-MAC2ResourceProfile', 
        'Update-MAC2ResourceProfileDetection', 
        'Update-MAC2RevealConfiguration', 
        'Update-MAC2SensitivityInspectionTemplate', 
        'Update-MAC2UpdateAutomatedDiscoveryAccount', 
        'Write-MAC2ClassificationExportConfiguration', 
        'Write-MAC2FindingsPublicationConfiguration')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Macie2.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/main/CHANGELOG.md'
        }
    }
}
