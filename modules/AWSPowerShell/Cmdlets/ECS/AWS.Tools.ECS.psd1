#
# Module manifest for module 'AWS.Tools.ECS'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.ECS.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '2dbc30b1-a51e-43d2-ba26-b4dde5a65ac7'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The ECS module of AWS Tools for PowerShell lets developers and administrators manage Amazon EC2 Container Service from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }    )

# Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.ECS.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.ECS.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.ECS.Completers.psm1',
        'AWS.Tools.ECS.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-ECSResourceTag', 
        'Get-ECSAccountSetting', 
        'Get-ECSAttributeList', 
        'Get-ECSCapacityProvider', 
        'Get-ECSClusterDetail', 
        'Get-ECSClusterList', 
        'Get-ECSClusterService', 
        'Get-ECSContainerInstanceDetail', 
        'Get-ECSContainerInstanceList', 
        'Get-ECSService', 
        'Get-ECSServiceDeploymentDetail', 
        'Get-ECSServiceDeploymentList', 
        'Get-ECSServiceRevision', 
        'Get-ECSServicesByNamespace', 
        'Get-ECSTagsForResource', 
        'Get-ECSTaskDefinitionDetail', 
        'Get-ECSTaskDefinitionFamilyList', 
        'Get-ECSTaskDefinitionList', 
        'Get-ECSTaskDetail', 
        'Get-ECSTaskList', 
        'Get-ECSTaskProtection', 
        'Get-ECSTaskSet', 
        'Invoke-ECSCommand', 
        'New-ECSCapacityProvider', 
        'New-ECSCluster', 
        'New-ECSService', 
        'New-ECSTask', 
        'New-ECSTaskSet', 
        'Register-ECSTaskDefinition', 
        'Remove-ECSAccountSetting', 
        'Remove-ECSAttribute', 
        'Remove-ECSCapacityProvider', 
        'Remove-ECSCluster', 
        'Remove-ECSResourceTag', 
        'Remove-ECSService', 
        'Remove-ECSTaskDefinition', 
        'Remove-ECSTaskSet', 
        'Start-ECSTask', 
        'Stop-ECSServiceDeployment', 
        'Stop-ECSTask', 
        'Submit-ECSAttachmentStateChange', 
        'Unregister-ECSContainerInstance', 
        'Unregister-ECSTaskDefinition', 
        'Update-ECSCapacityProvider', 
        'Update-ECSCluster', 
        'Update-ECSClusterSetting', 
        'Update-ECSContainerAgent', 
        'Update-ECSContainerInstancesState', 
        'Update-ECSService', 
        'Update-ECSServicePrimaryTaskSet', 
        'Update-ECSTaskProtection', 
        'Update-ECSTaskSet', 
        'Write-ECSAccountSetting', 
        'Write-ECSAccountSettingDefault', 
        'Write-ECSAttribute', 
        'Write-ECSClusterCapacityProvider')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-ECSClusters', 
        'Get-ECSContainerInstances', 
        'Get-ECSTaskDefinitionFamilies', 
        'Get-ECSTaskDefinitions', 
        'Get-ECSTasks')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.ECS.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/main/CHANGELOG.md'
        }
    }
}
