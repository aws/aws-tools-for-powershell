#
# Module manifest for module 'AWS.Tools.Inspector2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Inspector2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'ddd2140e-fe1b-4204-aff6-86c0171a3ab3'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Inspector2 module of AWS Tools for PowerShell lets developers and administrators manage Inspector2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Inspector2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Inspector2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Inspector2.Completers.psm1',
        'AWS.Tools.Inspector2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-INS2ResourceTag', 
        'Disable-INS2DelegatedAdminAccount', 
        'Enable-INS2DelegatedAdminAccount', 
        'Get-INS2AccountPermissionList', 
        'Get-INS2BatchGetCodeSnippet', 
        'Get-INS2BatchMemberEc2DeepInspectionStatus', 
        'Get-INS2CisScanConfigurationList', 
        'Get-INS2CisScanList', 
        'Get-INS2CisScanReport', 
        'Get-INS2CisScanResultDetail', 
        'Get-INS2CisScanResultsAggregatedByCheckList', 
        'Get-INS2CisScanResultsAggregatedByTargetResourceList', 
        'Get-INS2ClustersForImage', 
        'Get-INS2CodeSecurityIntegration', 
        'Get-INS2CodeSecurityIntegrationList', 
        'Get-INS2CodeSecurityScan', 
        'Get-INS2CodeSecurityScanConfiguration', 
        'Get-INS2CodeSecurityScanConfigurationAssociationList', 
        'Get-INS2CodeSecurityScanConfigurationList', 
        'Get-INS2Configuration', 
        'Get-INS2CoverageList', 
        'Get-INS2CoverageStatisticList', 
        'Get-INS2DelegatedAdminAccount', 
        'Get-INS2DelegatedAdminAccountList', 
        'Get-INS2Ec2DeepInspectionConfiguration', 
        'Get-INS2EncryptionKey', 
        'Get-INS2FilterList', 
        'Get-INS2FindingAggregationList', 
        'Get-INS2FindingList', 
        'Get-INS2FindingsReportStatus', 
        'Get-INS2GetAccountStatus', 
        'Get-INS2GetFindingDetail', 
        'Get-INS2GetFreeTrialInfo', 
        'Get-INS2Member', 
        'Get-INS2MemberList', 
        'Get-INS2OrganizationConfiguration', 
        'Get-INS2ResourceTag', 
        'Get-INS2SbomExport', 
        'Get-INS2UsageTotalList', 
        'New-INS2CisScanConfiguration', 
        'New-INS2CodeSecurityIntegration', 
        'New-INS2CodeSecurityScanConfiguration', 
        'New-INS2Filter', 
        'New-INS2FindingsReport', 
        'New-INS2SbomExport', 
        'Register-INS2CodeSecurityScanConfigurationBatch', 
        'Register-INS2Member', 
        'Remove-INS2CisScanConfiguration', 
        'Remove-INS2CodeSecurityIntegration', 
        'Remove-INS2CodeSecurityScanConfiguration', 
        'Remove-INS2Filter', 
        'Remove-INS2ResourceTag', 
        'Reset-INS2EncryptionKey', 
        'Search-INS2Vulnerability', 
        'Send-INS2CisSessionHealth', 
        'Send-INS2CisSessionTelemetry', 
        'Start-INS2CisSession', 
        'Start-INS2CodeSecurityScan', 
        'Stop-INS2CisSession', 
        'Stop-INS2FindingsReport', 
        'Stop-INS2Inspector', 
        'Stop-INS2SbomExport', 
        'Stop-INS2Service', 
        'Unregister-INS2CodeSecurityScanConfigurationBatch', 
        'Unregister-INS2Member', 
        'Update-INS2BatchMemberEc2DeepInspectionStatus', 
        'Update-INS2CisScanConfiguration', 
        'Update-INS2CodeSecurityIntegration', 
        'Update-INS2CodeSecurityScanConfiguration', 
        'Update-INS2Configuration', 
        'Update-INS2Ec2DeepInspectionConfiguration', 
        'Update-INS2EncryptionKey', 
        'Update-INS2Filter', 
        'Update-INS2OrganizationConfiguration', 
        'Update-INS2OrgEc2DeepInspectionConfiguration')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Inspector2.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v4.1/CHANGELOG.md'
        }
    }
}
