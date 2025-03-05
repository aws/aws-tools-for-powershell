#
# Module manifest for module 'AWS.Tools.B2bi'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.B2bi.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'bf74a2f8-f0c0-4ff3-b5f8-fec10ba02e8a'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The B2bi module of AWS Tools for PowerShell lets developers and administrators manage AWS B2B Data Interchange from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.B2bi.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.B2bi.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.B2bi.Completers.psm1',
        'AWS.Tools.B2bi.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-B2BIResourceTag', 
        'Get-B2BICapability', 
        'Get-B2BICapabilityList', 
        'Get-B2BIGeneratedMapping', 
        'Get-B2BIPartnership', 
        'Get-B2BIPartnershipList', 
        'Get-B2BIProfile', 
        'Get-B2BIProfileList', 
        'Get-B2BIResourceTag', 
        'Get-B2BITransformer', 
        'Get-B2BITransformerJob', 
        'Get-B2BITransformerList', 
        'New-B2BICapability', 
        'New-B2BIPartnership', 
        'New-B2BIProfile', 
        'New-B2BIStarterMappingTemplate', 
        'New-B2BITransformer', 
        'Remove-B2BICapability', 
        'Remove-B2BIPartnership', 
        'Remove-B2BIProfile', 
        'Remove-B2BIResourceTag', 
        'Remove-B2BITransformer', 
        'Start-B2BITransformerJob', 
        'Test-B2BIConversion', 
        'Test-B2BIMapping', 
        'Test-B2BIParsing', 
        'Update-B2BICapability', 
        'Update-B2BIPartnership', 
        'Update-B2BIProfile', 
        'Update-B2BITransformer')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.B2bi.dll-Help.xml'
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
