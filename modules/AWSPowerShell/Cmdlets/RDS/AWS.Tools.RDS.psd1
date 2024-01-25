#
# Module manifest for module 'AWS.Tools.RDS'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.RDS.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'c444a7d7-a916-407d-b56f-43e38c2b1365'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The RDS module of AWS Tools for PowerShell lets developers and administrators manage Amazon Relational Database Service from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.RDS.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.RDS.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.RDS.Completers.psm1',
        'AWS.Tools.RDS.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-RDSRoleToDBCluster', 
        'Add-RDSRoleToDBInstance', 
        'Add-RDSSourceIdentifierToSubscription', 
        'Add-RDSTagsToResource', 
        'Convert-RDSReadReplicaDBCluster', 
        'Convert-RDSReadReplicaToNewPrimary', 
        'Convert-RDSReadReplicaToStandalone', 
        'Copy-RDSDBClusterParameterGroup', 
        'Copy-RDSDBClusterSnapshot', 
        'Copy-RDSDBParameterGroup', 
        'Copy-RDSDBSnapshot', 
        'Copy-RDSOptionGroup', 
        'Disable-RDSHttpEndpoint', 
        'Edit-RDSActivityStream', 
        'Edit-RDSCertificate', 
        'Edit-RDSCurrentDBClusterCapacity', 
        'Edit-RDSCustomDBEngineVersion', 
        'Edit-RDSDBCluster', 
        'Edit-RDSDBClusterEndpoint', 
        'Edit-RDSDBClusterParameterGroup', 
        'Edit-RDSDBClusterSnapshotAttribute', 
        'Edit-RDSDBInstance', 
        'Edit-RDSDBParameterGroup', 
        'Edit-RDSDBProxy', 
        'Edit-RDSDBProxyEndpoint', 
        'Edit-RDSDBProxyTargetGroup', 
        'Edit-RDSDBRecommendation', 
        'Edit-RDSDBShardGroup', 
        'Edit-RDSDBSnapshot', 
        'Edit-RDSDBSnapshotAttribute', 
        'Edit-RDSDBSubnetGroup', 
        'Edit-RDSEventSubscription', 
        'Edit-RDSGlobalCluster', 
        'Edit-RDSOptionGroup', 
        'Edit-RDSTenantDatabase', 
        'Enable-RDSDBSecurityGroupIngress', 
        'Enable-RDSHttpEndpoint', 
        'Get-RDSAccountAttribute', 
        'Get-RDSBlueGreenDeployment', 
        'Get-RDSCertificate', 
        'Get-RDSDBCluster', 
        'Get-RDSDBClusterAutomatedBackup', 
        'Get-RDSDBClusterBacktrackList', 
        'Get-RDSDBClusterEndpoint', 
        'Get-RDSDBClusterParameter', 
        'Get-RDSDBClusterParameterGroup', 
        'Get-RDSDBClusterSnapshot', 
        'Get-RDSDBClusterSnapshotAttribute', 
        'Get-RDSDBEngineVersion', 
        'Get-RDSDBInstance', 
        'Get-RDSDBInstanceAutomatedBackup', 
        'Get-RDSDBLogFile', 
        'Get-RDSDBLogFilePortion', 
        'Get-RDSDBParameter', 
        'Get-RDSDBParameterGroup', 
        'Get-RDSDBProxy', 
        'Get-RDSDBProxyEndpoint', 
        'Get-RDSDBProxyTarget', 
        'Get-RDSDBProxyTargetGroup', 
        'Get-RDSDBRecommendation', 
        'Get-RDSDBSecurityGroup', 
        'Get-RDSDBShardGroup', 
        'Get-RDSDBSnapshot', 
        'Get-RDSDBSnapshotAttribute', 
        'Get-RDSDBSnapshotTenantDatabasis', 
        'Get-RDSDBSubnetGroup', 
        'Get-RDSEngineDefaultClusterParameter', 
        'Get-RDSEngineDefaultParameter', 
        'Get-RDSEvent', 
        'Get-RDSEventCategory', 
        'Get-RDSEventSubscription', 
        'Get-RDSExportTask', 
        'Get-RDSGlobalCluster', 
        'Get-RDSIntegration', 
        'Get-RDSOptionGroup', 
        'Get-RDSOptionGroupOption', 
        'Get-RDSOrderableDBInstanceOption', 
        'Get-RDSPendingMaintenanceAction', 
        'Get-RDSReservedDBInstance', 
        'Get-RDSReservedDBInstancesOfferingList', 
        'Get-RDSSourceRegion', 
        'Get-RDSTagForResource', 
        'Get-RDSTenantDatabasis', 
        'Get-RDSValidDBInstanceModification', 
        'New-RDSBlueGreenDeployment', 
        'New-RDSCustomDBEngineVersion', 
        'New-RDSDBCluster', 
        'New-RDSDBClusterEndpoint', 
        'New-RDSDBClusterParameterGroup', 
        'New-RDSDBClusterSnapshot', 
        'New-RDSDBInstance', 
        'New-RDSDBInstanceReadReplica', 
        'New-RDSDBParameterGroup', 
        'New-RDSDBProxy', 
        'New-RDSDBProxyEndpoint', 
        'New-RDSDBSecurityGroup', 
        'New-RDSDBShardGroup', 
        'New-RDSDBSnapshot', 
        'New-RDSDBSubnetGroup', 
        'New-RDSEventSubscription', 
        'New-RDSGlobalCluster', 
        'New-RDSIntegration', 
        'New-RDSOptionGroup', 
        'New-RDSReservedDBInstancesOfferingPurchase', 
        'New-RDSTenantDatabase', 
        'Register-RDSDBProxyTarget', 
        'Remove-RDSBlueGreenDeployment', 
        'Remove-RDSCustomDBEngineVersion', 
        'Remove-RDSDBCluster', 
        'Remove-RDSDBClusterAutomatedBackup', 
        'Remove-RDSDBClusterEndpoint', 
        'Remove-RDSDBClusterParameterGroup', 
        'Remove-RDSDBClusterSnapshot', 
        'Remove-RDSDBInstance', 
        'Remove-RDSDBInstanceAutomatedBackup', 
        'Remove-RDSDBParameterGroup', 
        'Remove-RDSDBProxy', 
        'Remove-RDSDBProxyEndpoint', 
        'Remove-RDSDBSecurityGroup', 
        'Remove-RDSDBShardGroup', 
        'Remove-RDSDBSnapshot', 
        'Remove-RDSDBSubnetGroup', 
        'Remove-RDSEventSubscription', 
        'Remove-RDSFromGlobalCluster', 
        'Remove-RDSGlobalCluster', 
        'Remove-RDSIntegration', 
        'Remove-RDSOptionGroup', 
        'Remove-RDSRoleFromDBCluster', 
        'Remove-RDSRoleFromDBInstance', 
        'Remove-RDSSourceIdentifierFromSubscription', 
        'Remove-RDSTagFromResource', 
        'Remove-RDSTenantDatabase', 
        'Request-RDSSwitchoverGlobalCluster', 
        'Reset-RDSDBCluster', 
        'Reset-RDSDBClusterParameterGroup', 
        'Reset-RDSDBParameterGroup', 
        'Restart-RDSDBCluster', 
        'Restart-RDSDBInstance', 
        'Restart-RDSDBShardGroup', 
        'Restore-RDSDBClusterFromS3', 
        'Restore-RDSDBClusterFromSnapshot', 
        'Restore-RDSDBClusterToPointInTime', 
        'Restore-RDSDBInstanceFromDBSnapshot', 
        'Restore-RDSDBInstanceFromS3', 
        'Restore-RDSDBInstanceToPointInTime', 
        'Revoke-RDSDBSecurityGroupIngress', 
        'Start-RDSActivityStream', 
        'Start-RDSDBCluster', 
        'Start-RDSDBClusterFailover', 
        'Start-RDSDBInstance', 
        'Start-RDSDBInstanceAutomatedBackupsReplication', 
        'Start-RDSExportTask', 
        'Start-RDSFailoverGlobalCluster', 
        'Stop-RDSActivityStream', 
        'Stop-RDSDBCluster', 
        'Stop-RDSDBInstance', 
        'Stop-RDSDBInstanceAutomatedBackupsReplication', 
        'Stop-RDSExportTask', 
        'Submit-RDSPendingMaintenanceAction', 
        'Switch-RDSBlueGreenDeployment', 
        'Unregister-RDSDBProxyTarget')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-RDSAccountAttributes', 
        'Get-RDSCertificates', 
        'Get-RDSDBLogFiles', 
        'Get-RDSDBSnapshotAttributes', 
        'Get-RDSEventCategories', 
        'Get-RDSEventSubscriptions', 
        'Get-RDSPendingMaintenanceActions', 
        'Get-RDSReservedDBInstancesOfferings', 
        'Get-RDSReservedDBInstancesOffering')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.RDS.dll-Help.xml'
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
