#
# Module manifest for module 'AWS.Tools.MediaLive'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.MediaLive.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'bab3a303-2dee-470c-8dab-1ac821c015cf'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2023 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The MediaLive module of AWS Tools for PowerShell lets developers and administrators manage AWS Elemental MediaLive from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.MediaLive.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.MediaLive.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.MediaLive.Completers.psm1',
        'AWS.Tools.MediaLive.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-EMLResourceTag', 
        'Deny-EMLInputDeviceTransfer', 
        'Get-EMLChannel', 
        'Get-EMLChannelList', 
        'Get-EMLInput', 
        'Get-EMLInputDevice', 
        'Get-EMLInputDeviceList', 
        'Get-EMLInputDeviceThumbnail', 
        'Get-EMLInputDeviceTransferList', 
        'Get-EMLInputList', 
        'Get-EMLInputSecurityGroup', 
        'Get-EMLInputSecurityGroupList', 
        'Get-EMLMultiplex', 
        'Get-EMLMultiplexList', 
        'Get-EMLMultiplexProgram', 
        'Get-EMLMultiplexProgramList', 
        'Get-EMLOffering', 
        'Get-EMLOfferingList', 
        'Get-EMLReservation', 
        'Get-EMLReservationList', 
        'Get-EMLResourceTag', 
        'Get-EMLSchedule', 
        'Move-EMLInputDevice', 
        'New-EMLChannel', 
        'New-EMLInput', 
        'New-EMLInputSecurityGroup', 
        'New-EMLMultiplex', 
        'New-EMLMultiplexProgram', 
        'New-EMLOfferingPurchase', 
        'New-EMLPartnerInput', 
        'Receive-EMLInputDeviceTransfer', 
        'Remove-EMLChannel', 
        'Remove-EMLInput', 
        'Remove-EMLInputSecurityGroup', 
        'Remove-EMLMultiplex', 
        'Remove-EMLMultiplexProgram', 
        'Remove-EMLReservation', 
        'Remove-EMLResourceBatch', 
        'Remove-EMLResourceTag', 
        'Remove-EMLSchedule', 
        'Request-EMLDevice', 
        'Restart-EMLInputDevice', 
        'Start-EMLChannel', 
        'Start-EMLInputDeviceMaintenanceWindow', 
        'Start-EMLMultiplex', 
        'Start-EMLResourceBatch', 
        'Stop-EMLChannel', 
        'Stop-EMLInputDeviceTransfer', 
        'Stop-EMLMultiplex', 
        'Stop-EMLResourceBatch', 
        'Update-EMLChannel', 
        'Update-EMLChannelClass', 
        'Update-EMLInput', 
        'Update-EMLInputDevice', 
        'Update-EMLInputSecurityGroup', 
        'Update-EMLMultiplex', 
        'Update-EMLMultiplexProgram', 
        'Update-EMLReservation', 
        'Update-EMLScheduleBatch')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.MediaLive.dll-Help.xml'
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
