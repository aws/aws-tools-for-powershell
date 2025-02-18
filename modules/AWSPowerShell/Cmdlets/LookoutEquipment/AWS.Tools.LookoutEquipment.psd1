#
# Module manifest for module 'AWS.Tools.LookoutEquipment'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.LookoutEquipment.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '6CCCE282-6B31-4EF1-B3DA-2097E7E09DCF'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The LookoutEquipment module of AWS Tools for PowerShell lets developers and administrators manage Amazon Lookout for Equipment from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.LookoutEquipment.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.LookoutEquipment.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.LookoutEquipment.Completers.psm1',
        'AWS.Tools.LookoutEquipment.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-L4EResourceTag', 
        'Get-L4EDataIngestionJob', 
        'Get-L4EDataIngestionJobList', 
        'Get-L4EDataset', 
        'Get-L4EDatasetList', 
        'Get-L4EInferenceEventList', 
        'Get-L4EInferenceExecutionList', 
        'Get-L4EInferenceScheduler', 
        'Get-L4EInferenceSchedulerList', 
        'Get-L4ELabel', 
        'Get-L4ELabelGroup', 
        'Get-L4ELabelGroupList', 
        'Get-L4ELabelList', 
        'Get-L4EModel', 
        'Get-L4EModelList', 
        'Get-L4EModelVersion', 
        'Get-L4EModelVersionList', 
        'Get-L4EResourcePolicy', 
        'Get-L4EResourceTag', 
        'Get-L4ERetrainingScheduler', 
        'Get-L4ERetrainingSchedulerList', 
        'Get-L4ESensorStatisticList', 
        'Import-L4EDataset', 
        'Import-L4EModelVersion', 
        'New-L4EDataset', 
        'New-L4EInferenceScheduler', 
        'New-L4ELabel', 
        'New-L4ELabelGroup', 
        'New-L4EModel', 
        'New-L4ERetrainingScheduler', 
        'Remove-L4EDataset', 
        'Remove-L4EInferenceScheduler', 
        'Remove-L4ELabel', 
        'Remove-L4ELabelGroup', 
        'Remove-L4EModel', 
        'Remove-L4EResourcePolicy', 
        'Remove-L4EResourceTag', 
        'Remove-L4ERetrainingScheduler', 
        'Start-L4EDataIngestionJob', 
        'Start-L4EInferenceScheduler', 
        'Start-L4ERetrainingScheduler', 
        'Stop-L4EInferenceScheduler', 
        'Stop-L4ERetrainingScheduler', 
        'Update-L4EActiveModelVersion', 
        'Update-L4EInferenceScheduler', 
        'Update-L4ELabelGroup', 
        'Update-L4EModel', 
        'Update-L4ERetrainingScheduler', 
        'Write-L4EResourcePolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.LookoutEquipment.dll-Help.xml'
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
