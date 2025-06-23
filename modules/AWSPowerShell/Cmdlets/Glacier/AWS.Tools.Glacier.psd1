#
# Module manifest for module 'AWS.Tools.Glacier'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Glacier.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '263f91f3-1f6e-4071-8045-4e08f77b643d'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Glacier module of AWS Tools for PowerShell lets developers and administrators manage Amazon Glacier from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
            ModuleName = 'AWS.Tools.SimpleNotificationService';
            RequiredVersion = '0.0.0.0';
            Guid = 'ed882123-ae45-43fd-ba31-5348331a8020' },
        @{
            ModuleName = 'AWS.Tools.SQS';
            RequiredVersion = '0.0.0.0';
            Guid = '467e3fc8-3585-4668-bbef-a6eee7f7a29b' },
        @{
            ModuleName = 'AWS.Tools.Common';
            RequiredVersion = '0.0.0.0';
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }
    )

    # Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.Glacier.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Glacier.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Glacier.Completers.psm1',
        'AWS.Tools.Glacier.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-GLCTagsToVault', 
        'Complete-GLCVaultLock', 
        'Get-GLCDataRetrievalPolicy', 
        'Get-GLCJob', 
        'Get-GLCJobList', 
        'Get-GLCMultipartUploadList', 
        'Get-GLCProvisionedCapacityList', 
        'Get-GLCVault', 
        'Get-GLCVaultAccessPolicy', 
        'Get-GLCVaultList', 
        'Get-GLCVaultLock', 
        'Get-GLCVaultNotification', 
        'Get-GLCVaultTagList', 
        'New-GLCProvisionedCapacityPurchase', 
        'New-GLCVault', 
        'Read-GLCJobOutput', 
        'Remove-GLCArchive', 
        'Remove-GLCMultipartUpload', 
        'Remove-GLCTagsFromVault', 
        'Remove-GLCVault', 
        'Remove-GLCVaultAccessPolicy', 
        'Remove-GLCVaultNotification', 
        'Set-GLCDataRetrievalPolicy', 
        'Set-GLCVaultAccessPolicy', 
        'Set-GLCVaultNotification', 
        'Start-GLCJob', 
        'Start-GLCVaultLock', 
        'Stop-GLCVaultLock', 
        'Write-GLCArchive')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-GLCVaultTagsList')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Glacier.dll-Help.xml'
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
