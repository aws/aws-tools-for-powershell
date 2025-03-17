#
# Module manifest for module 'AWS.Tools.Deadline'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Deadline.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '7f9f3eb8-fd98-4744-a5cc-4b479717f16b'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Deadline module of AWS Tools for PowerShell lets developers and administrators manage AWSDeadlineCloud from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Deadline.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Deadline.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Deadline.Completers.psm1',
        'AWS.Tools.Deadline.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-ADCMemberToFarm', 
        'Add-ADCMemberToFleet', 
        'Add-ADCMemberToJob', 
        'Add-ADCMemberToQueue', 
        'Add-ADCResourceTag', 
        'Copy-ADCJobTemplate', 
        'Get-ADCAvailableMeteredProductList', 
        'Get-ADCBatchJobEntity', 
        'Get-ADCBudget', 
        'Get-ADCBudgetList', 
        'Get-ADCFarm', 
        'Get-ADCFarmList', 
        'Get-ADCFarmMemberList', 
        'Get-ADCFleet', 
        'Get-ADCFleetList', 
        'Get-ADCFleetMemberList', 
        'Get-ADCFleetRoleForRead', 
        'Get-ADCFleetRoleForWorker', 
        'Get-ADCJob', 
        'Get-ADCJobList', 
        'Get-ADCJobMemberList', 
        'Get-ADCJobParameterDefinitionList', 
        'Get-ADCLicenseEndpoint', 
        'Get-ADCLicenseEndpointList', 
        'Get-ADCLimit', 
        'Get-ADCLimitList', 
        'Get-ADCMeteredProductList', 
        'Get-ADCMonitor', 
        'Get-ADCMonitorList', 
        'Get-ADCQueue', 
        'Get-ADCQueueEnvironment', 
        'Get-ADCQueueEnvironmentList', 
        'Get-ADCQueueFleetAssociation', 
        'Get-ADCQueueFleetAssociationList', 
        'Get-ADCQueueLimitAssociation', 
        'Get-ADCQueueLimitAssociationList', 
        'Get-ADCQueueList', 
        'Get-ADCQueueMemberList', 
        'Get-ADCQueueRoleForRead', 
        'Get-ADCQueueRoleForUser', 
        'Get-ADCQueueRoleForWorker', 
        'Get-ADCResourceTag', 
        'Get-ADCSession', 
        'Get-ADCSessionAction', 
        'Get-ADCSessionActionList', 
        'Get-ADCSessionList', 
        'Get-ADCSessionsForWorkerList', 
        'Get-ADCSessionsStatisticsAggregation', 
        'Get-ADCStep', 
        'Get-ADCStepConsumerList', 
        'Get-ADCStepDependencyList', 
        'Get-ADCStepList', 
        'Get-ADCStorageProfile', 
        'Get-ADCStorageProfileForQueue', 
        'Get-ADCStorageProfileList', 
        'Get-ADCStorageProfilesForQueueList', 
        'Get-ADCTask', 
        'Get-ADCTaskList', 
        'Get-ADCWorker', 
        'Get-ADCWorkerList', 
        'New-ADCBudget', 
        'New-ADCFarm', 
        'New-ADCFleet', 
        'New-ADCJob', 
        'New-ADCLicenseEndpoint', 
        'New-ADCLimit', 
        'New-ADCMonitor', 
        'New-ADCQueue', 
        'New-ADCQueueEnvironment', 
        'New-ADCQueueFleetAssociation', 
        'New-ADCQueueLimitAssociation', 
        'New-ADCStorageProfile', 
        'New-ADCWorker', 
        'Remove-ADCBudget', 
        'Remove-ADCFarm', 
        'Remove-ADCFleet', 
        'Remove-ADCLicenseEndpoint', 
        'Remove-ADCLimit', 
        'Remove-ADCMemberFromFarm', 
        'Remove-ADCMemberFromFleet', 
        'Remove-ADCMemberFromJob', 
        'Remove-ADCMemberFromQueue', 
        'Remove-ADCMeteredProduct', 
        'Remove-ADCMonitor', 
        'Remove-ADCQueue', 
        'Remove-ADCQueueEnvironment', 
        'Remove-ADCQueueFleetAssociation', 
        'Remove-ADCQueueLimitAssociation', 
        'Remove-ADCResourceTag', 
        'Remove-ADCStorageProfile', 
        'Remove-ADCWorker', 
        'Search-ADCJob', 
        'Search-ADCStep', 
        'Search-ADCTask', 
        'Search-ADCWorker', 
        'Start-ADCSessionsStatisticsAggregation', 
        'Update-ADCBudget', 
        'Update-ADCFarm', 
        'Update-ADCFleet', 
        'Update-ADCJob', 
        'Update-ADCLimit', 
        'Update-ADCMonitor', 
        'Update-ADCQueue', 
        'Update-ADCQueueEnvironment', 
        'Update-ADCQueueFleetAssociation', 
        'Update-ADCQueueLimitAssociation', 
        'Update-ADCSession', 
        'Update-ADCStep', 
        'Update-ADCStorageProfile', 
        'Update-ADCTask', 
        'Update-ADCWorker', 
        'Update-ADCWorkerSchedule', 
        'Write-ADCMeteredProduct')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Deadline.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview003'
        }
    }
}
