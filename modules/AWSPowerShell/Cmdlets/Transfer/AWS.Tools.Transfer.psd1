#
# Module manifest for module 'AWS.Tools.Transfer'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Transfer.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '9ee8ec18-09e3-4bc9-8263-c5747a7c526d'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Transfer module of AWS Tools for PowerShell lets developers and administrators manage AWS Transfer for SFTP from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Transfer.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Transfer.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Transfer.Completers.psm1',
        'AWS.Tools.Transfer.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-TFRResourceTag', 
        'Get-TFRAccess', 
        'Get-TFRAccessList', 
        'Get-TFRAgreement', 
        'Get-TFRAgreementList', 
        'Get-TFRCertificate', 
        'Get-TFRCertificateList', 
        'Get-TFRConnector', 
        'Get-TFRConnectorList', 
        'Get-TFRExecution', 
        'Get-TFRExecutionList', 
        'Get-TFRFileTransferResultList', 
        'Get-TFRHostKey', 
        'Get-TFRHostKeyList', 
        'Get-TFRProfile', 
        'Get-TFRProfileList', 
        'Get-TFRResourceTagList', 
        'Get-TFRSecurityPolicy', 
        'Get-TFRSecurityPolicyList', 
        'Get-TFRServer', 
        'Get-TFRServerList', 
        'Get-TFRUser', 
        'Get-TFRUserList', 
        'Get-TFRWebApp', 
        'Get-TFRWebAppCustomization', 
        'Get-TFRWebAppList', 
        'Get-TFRWorkflow', 
        'Get-TFRWorkflowList', 
        'Import-TFRCertificate', 
        'Import-TFRHostKey', 
        'Import-TFRSshPublicKey', 
        'New-TFRAccess', 
        'New-TFRAgreement', 
        'New-TFRConnector', 
        'New-TFRProfile', 
        'New-TFRServer', 
        'New-TFRUser', 
        'New-TFRWebApp', 
        'New-TFRWorkflow', 
        'Remove-TFRAccess', 
        'Remove-TFRAgreement', 
        'Remove-TFRCertificate', 
        'Remove-TFRConnector', 
        'Remove-TFRHostKey', 
        'Remove-TFRProfile', 
        'Remove-TFRResourceTag', 
        'Remove-TFRServer', 
        'Remove-TFRSshPublicKey', 
        'Remove-TFRUser', 
        'Remove-TFRWebApp', 
        'Remove-TFRWebAppCustomization', 
        'Remove-TFRWorkflow', 
        'Send-TFRWorkflowStepState', 
        'Start-TFRDirectoryListing', 
        'Start-TFRFileTransfer', 
        'Start-TFRRemoteDelete', 
        'Start-TFRRemoteMove', 
        'Start-TFRServer', 
        'Stop-TFRServer', 
        'Test-TFRConnection', 
        'Test-TFRIdentityProvider', 
        'Update-TFRAccess', 
        'Update-TFRAgreement', 
        'Update-TFRCertificate', 
        'Update-TFRConnector', 
        'Update-TFRHostKey', 
        'Update-TFRProfile', 
        'Update-TFRServer', 
        'Update-TFRUser', 
        'Update-TFRWebApp', 
        'Update-TFRWebAppCustomization')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Transfer.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview005'
        }
    }
}
