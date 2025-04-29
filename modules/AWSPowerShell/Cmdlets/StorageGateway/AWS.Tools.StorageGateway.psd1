#
# Module manifest for module 'AWS.Tools.StorageGateway'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.StorageGateway.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'd286e57e-c129-44c1-918b-041ba56c2a44'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The StorageGateway module of AWS Tools for PowerShell lets developers and administrators manage AWS Storage Gateway from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.StorageGateway.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.StorageGateway.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.StorageGateway.Completers.psm1',
        'AWS.Tools.StorageGateway.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SGCache', 
        'Add-SGResourceTag', 
        'Add-SGTapeToTapePool', 
        'Add-SGUploadBuffer', 
        'Add-SGWorkingStorage', 
        'Disable-SGGateway', 
        'Dismount-SGVolume', 
        'Enable-SGGateway', 
        'Get-SGAutomaticTapeCreationPolicy', 
        'Get-SGAvailabilityMonitorTest', 
        'Get-SGBandwidthRateLimit', 
        'Get-SGBandwidthRateLimitSchedule', 
        'Get-SGCache', 
        'Get-SGCachediSCSIVolume', 
        'Get-SGCacheReport', 
        'Get-SGCacheReportList', 
        'Get-SGChapCredential', 
        'Get-SGFileShareList', 
        'Get-SGGateway', 
        'Get-SGGatewayInformation', 
        'Get-SGLocalDisk', 
        'Get-SGMaintenanceStartTime', 
        'Get-SGNFSFileShareList', 
        'Get-SGResourceTag', 
        'Get-SGSGFileSystemAssociation', 
        'Get-SGSGFileSystemAssociationList', 
        'Get-SGSMBFileShare', 
        'Get-SGSMBSetting', 
        'Get-SGSnapshotSchedule', 
        'Get-SGStorediSCSIVolume', 
        'Get-SGTape', 
        'Get-SGTapeArchive', 
        'Get-SGTapeArchiveList', 
        'Get-SGTapeList', 
        'Get-SGTapePool', 
        'Get-SGTapeRecoveryPoint', 
        'Get-SGTapeRecoveryPointList', 
        'Get-SGUploadBuffer', 
        'Get-SGVolume', 
        'Get-SGVolumeInitiatorList', 
        'Get-SGVolumeRecoveryPoint', 
        'Get-SGVTLDevice', 
        'Get-SGWorkingStorage', 
        'Invoke-SGCacheRefresh', 
        'Invoke-SGEvictFilesFailingUpload', 
        'Join-SGDomain', 
        'Mount-SGVolume', 
        'New-SGCachediSCSIVolume', 
        'New-SGNFSFileShare', 
        'New-SGSGFileSystemAssociation', 
        'New-SGSMBFileShare', 
        'New-SGSnapshot', 
        'New-SGSnapshotFromVolumeRecoveryPoint', 
        'New-SGStorediSCSIVolume', 
        'New-SGTape', 
        'New-SGTapePool', 
        'New-SGTapeWithBarcode', 
        'Remove-SGAutomaticTapeCreationPolicy', 
        'Remove-SGBandwidthRateLimit', 
        'Remove-SGCacheReport', 
        'Remove-SGChapCredential', 
        'Remove-SGFileShare', 
        'Remove-SGGateway', 
        'Remove-SGResourceTag', 
        'Remove-SGSGFileSystemAssociation', 
        'Remove-SGSnapshotSchedule', 
        'Remove-SGTape', 
        'Remove-SGTapeArchive', 
        'Remove-SGTapePool', 
        'Remove-SGVolume', 
        'Reset-SGCache', 
        'Send-SGUploadedNotification', 
        'Set-SGLocalConsolePassword', 
        'Set-SGSMBGuestPassword', 
        'Start-SGAvailabilityMonitorTest', 
        'Start-SGCacheReport', 
        'Start-SGGateway', 
        'Stop-SGArchival', 
        'Stop-SGCacheReport', 
        'Stop-SGGateway', 
        'Stop-SGRetrieval', 
        'Update-SGAutomaticTapeCreationPolicy', 
        'Update-SGBandwidthRateLimit', 
        'Update-SGBandwidthRateLimitSchedule', 
        'Update-SGChapCredential', 
        'Update-SGGatewayInformation', 
        'Update-SGGatewaySoftwareNow', 
        'Update-SGMaintenanceStartTime', 
        'Update-SGNFSFileShare', 
        'Update-SGSGFileSystemAssociation', 
        'Update-SGSGSMBLocalGroup', 
        'Update-SGSMBFileShare', 
        'Update-SGSMBFileShareVisibility', 
        'Update-SGSMBSecurityStrategy', 
        'Update-SGSnapshotSchedule', 
        'Update-SGVTLDeviceType')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'New-SGTapes', 
        'Remove-SGChapCredentials', 
        'Get-SGChapCredentials', 
        'Get-SGTapeArchives', 
        'Get-SGTapeRecoveryPoints', 
        'Get-SGTapes', 
        'Get-SGVTLDevices', 
        'Get-SGResourceTags', 
        'Get-SGVolumeInitiators', 
        'Update-SGChapCredentials')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.StorageGateway.dll-Help.xml'
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
