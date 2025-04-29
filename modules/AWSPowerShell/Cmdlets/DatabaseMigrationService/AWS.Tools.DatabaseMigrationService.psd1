#
# Module manifest for module 'AWS.Tools.DatabaseMigrationService'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.DatabaseMigrationService.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '0d978e1b-dcd2-4c89-8bf3-aae5b490f22b'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The DatabaseMigrationService module of AWS Tools for PowerShell lets developers and administrators manage AWS Database Migration Service from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.DatabaseMigrationService.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.DatabaseMigrationService.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.DatabaseMigrationService.Completers.psm1',
        'AWS.Tools.DatabaseMigrationService.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Complete-DMSPendingMaintenanceAction', 
        'Edit-DMSConversionConfiguration', 
        'Edit-DMSDataMigration', 
        'Edit-DMSDataProvider', 
        'Edit-DMSEndpoint', 
        'Edit-DMSEventSubscription', 
        'Edit-DMSInstanceProfile', 
        'Edit-DMSMigrationProject', 
        'Edit-DMSReplicationConfig', 
        'Edit-DMSReplicationInstance', 
        'Edit-DMSReplicationSubnetGroup', 
        'Edit-DMSReplicationTask', 
        'Export-DMSMetadataModelAssessment', 
        'Get-DMSAccountAttribute', 
        'Get-DMSApplicableIndividualAssessment', 
        'Get-DMSCertificate', 
        'Get-DMSConnection', 
        'Get-DMSConversionConfiguration', 
        'Get-DMSDataMigration', 
        'Get-DMSDataProvider', 
        'Get-DMSEndpoint', 
        'Get-DMSEndpointSetting', 
        'Get-DMSEndpointType', 
        'Get-DMSEngineVersion', 
        'Get-DMSEvent', 
        'Get-DMSEventCategory', 
        'Get-DMSEventSubscription', 
        'Get-DMSExtensionPackAssociation', 
        'Get-DMSFleetAdvisorCollector', 
        'Get-DMSFleetAdvisorDatabase', 
        'Get-DMSFleetAdvisorLsaAnalysis', 
        'Get-DMSFleetAdvisorSchema', 
        'Get-DMSFleetAdvisorSchemaObjectSummary', 
        'Get-DMSInstanceProfile', 
        'Get-DMSMetadataModelAssessment', 
        'Get-DMSMetadataModelConversion', 
        'Get-DMSMetadataModelExportsAsScript', 
        'Get-DMSMetadataModelExportsToTarget', 
        'Get-DMSMetadataModelImport', 
        'Get-DMSMigrationProject', 
        'Get-DMSOrderableReplicationInstance', 
        'Get-DMSPendingMaintenanceAction', 
        'Get-DMSRecommendation', 
        'Get-DMSRecommendationLimitation', 
        'Get-DMSRefreshSchemasStatus', 
        'Get-DMSReplication', 
        'Get-DMSReplicationConfig', 
        'Get-DMSReplicationInstance', 
        'Get-DMSReplicationInstanceTaskLog', 
        'Get-DMSReplicationSubnetGroup', 
        'Get-DMSReplicationTableStatistic', 
        'Get-DMSReplicationTask', 
        'Get-DMSReplicationTaskAssessmentResult', 
        'Get-DMSReplicationTaskAssessmentRun', 
        'Get-DMSReplicationTaskIndividualAssessment', 
        'Get-DMSResourceTag', 
        'Get-DMSSchema', 
        'Get-DMSTableStatistic', 
        'Import-DMSCertificate', 
        'Invoke-DMSSchemaRefresh', 
        'Move-DMSReplicationTask', 
        'New-DMSDataMigration', 
        'New-DMSDataProvider', 
        'New-DMSEndpoint', 
        'New-DMSEventSubscription', 
        'New-DMSFleetAdvisorCollector', 
        'New-DMSInstanceProfile', 
        'New-DMSMigrationProject', 
        'New-DMSReplicationConfig', 
        'New-DMSReplicationInstance', 
        'New-DMSReplicationSubnetGroup', 
        'New-DMSReplicationTask', 
        'Remove-DMSCertificate', 
        'Remove-DMSConnection', 
        'Remove-DMSDataMigration', 
        'Remove-DMSDataProvider', 
        'Remove-DMSEndpoint', 
        'Remove-DMSEventSubscription', 
        'Remove-DMSFleetAdvisorCollector', 
        'Remove-DMSFleetAdvisorDatabaseId', 
        'Remove-DMSInstanceProfile', 
        'Remove-DMSMigrationProject', 
        'Remove-DMSReplicationConfig', 
        'Remove-DMSReplicationInstance', 
        'Remove-DMSReplicationSubnetGroup', 
        'Remove-DMSReplicationTask', 
        'Remove-DMSReplicationTaskAssessmentRun', 
        'Remove-DMSResourceTag', 
        'Restart-DMSReplicationInstance', 
        'Restore-DMSReplicationTable', 
        'Restore-DMSTable', 
        'Set-DMSResourceTag', 
        'Start-DMSBatchRecommendation', 
        'Start-DMSDataMigration', 
        'Start-DMSExtensionPackAssociation', 
        'Start-DMSFleetAdvisorLsaAnalysis', 
        'Start-DMSMetadataModelAssessment', 
        'Start-DMSMetadataModelConversion', 
        'Start-DMSMetadataModelExportAsScript', 
        'Start-DMSMetadataModelExportToTarget', 
        'Start-DMSMetadataModelImport', 
        'Start-DMSRecommendation', 
        'Start-DMSReplication', 
        'Start-DMSReplicationTask', 
        'Start-DMSReplicationTaskAssessment', 
        'Start-DMSReplicationTaskAssessmentRun', 
        'Stop-DMSDataMigration', 
        'Stop-DMSReplication', 
        'Stop-DMSReplicationTask', 
        'Stop-DMSReplicationTaskAssessmentRun', 
        'Test-DMSConnection', 
        'Update-DMSSubscriptionsToEventBridge')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.DatabaseMigrationService.dll-Help.xml'
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
