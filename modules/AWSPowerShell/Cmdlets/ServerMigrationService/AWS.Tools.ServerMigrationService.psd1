#
# Module manifest for module 'AWS.Tools.ServerMigrationService'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.ServerMigrationService.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'd8baf3df-2cbc-446d-93ed-5ca467f61b8d'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The ServerMigrationService module of AWS Tools for PowerShell lets developers and administrators manage AWS Server Migration Service from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.ServerMigrationService.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.ServerMigrationService.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.ServerMigrationService.Completers.psm1',
        'AWS.Tools.ServerMigrationService.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Get-SMSApp', 
        'Get-SMSAppLaunchConfiguration', 
        'Get-SMSAppList', 
        'Get-SMSAppReplicationConfiguration', 
        'Get-SMSAppValidationConfiguration', 
        'Get-SMSAppValidationOutput', 
        'Get-SMSConnector', 
        'Get-SMSReplicationJob', 
        'Get-SMSReplicationRun', 
        'Get-SMSServer', 
        'Import-SMSAppCatalog', 
        'Import-SMSServerCatalog', 
        'New-SMSApp', 
        'New-SMSChangeSet', 
        'New-SMSReplicationJob', 
        'New-SMSTemplate', 
        'Remove-SMSApp', 
        'Remove-SMSAppLaunchConfiguration', 
        'Remove-SMSAppReplicationConfiguration', 
        'Remove-SMSAppValidationConfiguration', 
        'Remove-SMSReplicationJob', 
        'Remove-SMSServerCatalog', 
        'Start-SMSApp', 
        'Start-SMSAppReplication', 
        'Start-SMSOnDemandAppReplication', 
        'Start-SMSOnDemandReplicationRun', 
        'Stop-SMSApp', 
        'Stop-SMSAppReplication', 
        'Unregister-SMSConnector', 
        'Update-SMSApp', 
        'Update-SMSReplicationJob', 
        'Write-SMSAppLaunchConfiguration', 
        'Write-SMSAppReplicationConfiguration', 
        'Write-SMSAppValidationConfiguration', 
        'Write-SMSAppValidationOutput')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.ServerMigrationService.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview004'
        }
    }
}
