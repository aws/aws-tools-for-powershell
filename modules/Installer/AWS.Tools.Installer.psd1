#
# Module manifest for module 'AWS.Tools.Installer'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Installer.psm1'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '1.0.2.0'

    # ID used to uniquely identify this module
    GUID = '450031c1-9177-4fc1-9518-93166b1a926b'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The AWS.Tools.Installer module makes it easier to install, update and uninstall other AWS.Tools modules (see https://www.powershellgallery.com/packages/AWS.Tools.Common/).
You can use a single command like ''Install-AWSToolsModule EC2,S3'' to install multiple modules.
You can also update all your installed AWS.Tools modules and remove old versions by running `Update-AWSToolsModule -CleanUp`.'

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
            ModuleName = 'PowerShellGet';
            ModuleVersion = '2.2.1' }
    )

    # Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @( )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @( )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @( )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @( )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @( )

    # Functions to export from this module
    FunctionsToExport = @(
        'Uninstall-AWSToolsModule', 
        'Install-AWSToolsModule', 
        'Update-AWSToolsModule' )

    # Cmdlets to export from this module
    CmdletsToExport = @( )

    # Variables to export from this module
    VariablesToExport = @( )

    # Aliases to export from this module
    AliasesToExport = @( )

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @( )

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
