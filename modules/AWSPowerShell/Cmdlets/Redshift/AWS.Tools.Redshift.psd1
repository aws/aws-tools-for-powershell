#
# Module manifest for module 'AWS.Tools.Redshift'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Redshift.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '3c401a3d-ba96-41a6-aa3a-594256917358'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Redshift module of AWS Tools for PowerShell lets developers and administrators manage Amazon Redshift from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Redshift.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Redshift.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Redshift.Completers.psm1',
        'AWS.Tools.Redshift.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Approve-RSClusterSecurityGroupIngress', 
        'Approve-RSSnapshotAccess', 
        'Copy-RSClusterSnapshot', 
        'Disable-RSLogging', 
        'Disable-RSSnapshotCopy', 
        'Edit-RSCluster', 
        'Edit-RSClusterDbRevision', 
        'Edit-RSClusterIamRole', 
        'Edit-RSClusterMaintenance', 
        'Edit-RSClusterParameterGroup', 
        'Edit-RSClusterSnapshot', 
        'Edit-RSClusterSnapshotBatch', 
        'Edit-RSClusterSnapshotSchedule', 
        'Edit-RSClusterSubnetGroup', 
        'Edit-RSEventSubscription', 
        'Edit-RSScheduledAction', 
        'Edit-RSSnapshotCopyRetentionPeriod', 
        'Edit-RSSnapshotSchedule', 
        'Enable-RSLogging', 
        'Enable-RSSnapshotCopy', 
        'Get-RSAccountAttribute', 
        'Get-RSCluster', 
        'Get-RSClusterCredential', 
        'Get-RSClusterDbRevision', 
        'Get-RSClusterParameter', 
        'Get-RSClusterParameterGroup', 
        'Get-RSClusterSecurityGroup', 
        'Get-RSClusterSnapshot', 
        'Get-RSClusterSubnetGroup', 
        'Get-RSClusterTrack', 
        'Get-RSClusterVersion', 
        'Get-RSDefaultClusterParameter', 
        'Get-RSEvent', 
        'Get-RSEventCategory', 
        'Get-RSEventSubscription', 
        'Get-RSHsmClientCertificate', 
        'Get-RSHsmConfiguration', 
        'Get-RSLoggingStatus', 
        'Get-RSNodeConfigurationOption', 
        'Get-RSOrderableClusterOption', 
        'Get-RSReservedNode', 
        'Get-RSReservedNodeExchangeOffering', 
        'Get-RSReservedNodeOffering', 
        'Get-RSResize', 
        'Get-RSResourceTag', 
        'Get-RSScheduledAction', 
        'Get-RSSnapshotCopyGrant', 
        'Get-RSSnapshotSchedule', 
        'Get-RSStorage', 
        'Get-RSTableRestoreStatus', 
        'New-RSCluster', 
        'New-RSClusterParameterGroup', 
        'New-RSClusterSecurityGroup', 
        'New-RSClusterSnapshot', 
        'New-RSClusterSubnetGroup', 
        'New-RSEventSubscription', 
        'New-RSHsmClientCertificate', 
        'New-RSHsmConfiguration', 
        'New-RSResourceTag', 
        'New-RSScheduledAction', 
        'New-RSSnapshotCopyGrant', 
        'New-RSSnapshotSchedule', 
        'Remove-RSCluster', 
        'Remove-RSClusterParameterGroup', 
        'Remove-RSClusterSecurityGroup', 
        'Remove-RSClusterSnapshot', 
        'Remove-RSClusterSnapshotBatch', 
        'Remove-RSClusterSubnetGroup', 
        'Remove-RSEventSubscription', 
        'Remove-RSHsmClientCertificate', 
        'Remove-RSHsmConfiguration', 
        'Remove-RSResourceTag', 
        'Remove-RSScheduledAction', 
        'Remove-RSSnapshotCopyGrant', 
        'Remove-RSSnapshotSchedule', 
        'Request-RSReservedNodeOffering', 
        'Reset-RSClusterParameterGroup', 
        'Restart-RSCluster', 
        'Restore-RSFromClusterSnapshot', 
        'Restore-RSTableFromClusterSnapshot', 
        'Revoke-RSClusterSecurityGroupIngress', 
        'Revoke-RSSnapshotAccess', 
        'Set-RSClusterSize', 
        'Stop-RSResize', 
        'Switch-RSEncryptionKey', 
        'Switch-RSReservedNode')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'New-RSTags', 
        'Remove-RSTags', 
        'Get-RSClusterParameterGroups', 
        'Get-RSClusterParameters', 
        'Get-RSClusters', 
        'Get-RSClusterSecurityGroups', 
        'Get-RSClusterSnapshots', 
        'Get-RSClusterSubnetGroups', 
        'Get-RSClusterVersions', 
        'Get-RSDefaultClusterParameters', 
        'Get-RSEventCategories', 
        'Get-RSEvents', 
        'Get-RSEventSubscriptions', 
        'Get-RSHsmClientCertificates', 
        'Get-RSHsmConfigurations', 
        'Get-RSOrderableClusterOptions', 
        'Get-RSReservedNodeOfferings', 
        'Get-RSReservedNodes', 
        'Get-RSTags', 
        'Edit-RSClusterIamRoles')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Redshift.dll-Help.xml'
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
