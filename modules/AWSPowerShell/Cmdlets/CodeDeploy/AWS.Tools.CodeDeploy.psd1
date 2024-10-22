#
# Module manifest for module 'AWS.Tools.CodeDeploy'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.CodeDeploy.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'e2d40bab-1c44-4806-a685-67b779e1723b'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The CodeDeploy module of AWS Tools for PowerShell lets developers and administrators manage AWS CodeDeploy from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.CodeDeploy.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.CodeDeploy.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.CodeDeploy.Completers.psm1',
        'AWS.Tools.CodeDeploy.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-CDOnPremiseInstanceTag', 
        'Add-CDResourceTag', 
        'Get-CDApplication', 
        'Get-CDApplicationBatch', 
        'Get-CDApplicationList', 
        'Get-CDApplicationRevision', 
        'Get-CDApplicationRevisionBatch', 
        'Get-CDApplicationRevisionList', 
        'Get-CDDeployment', 
        'Get-CDDeploymentBatch', 
        'Get-CDDeploymentConfig', 
        'Get-CDDeploymentConfigList', 
        'Get-CDDeploymentGroup', 
        'Get-CDDeploymentGroupBatch', 
        'Get-CDDeploymentGroupList', 
        'Get-CDDeploymentInstance', 
        'Get-CDDeploymentInstanceBatch', 
        'Get-CDDeploymentInstanceList', 
        'Get-CDDeploymentList', 
        'Get-CDDeploymentTarget', 
        'Get-CDDeploymentTargetBatch', 
        'Get-CDDeploymentTargetList', 
        'Get-CDGitHubAccountTokenNameList', 
        'Get-CDOnPremiseInstance', 
        'Get-CDOnPremiseInstanceBatch', 
        'Get-CDOnPremiseInstanceList', 
        'Get-CDResourceTag', 
        'New-CDApplication', 
        'New-CDDeployment', 
        'New-CDDeploymentConfig', 
        'New-CDDeploymentGroup', 
        'Register-CDApplicationRevision', 
        'Register-CDOnPremiseInstance', 
        'Remove-CDApplication', 
        'Remove-CDDeploymentConfig', 
        'Remove-CDDeploymentGroup', 
        'Remove-CDGitHubAccountToken', 
        'Remove-CDOnPremiseInstanceTag', 
        'Remove-CDResourcesByExternalId', 
        'Remove-CDResourceTag', 
        'Resume-CDDeployment', 
        'Skip-CDWaitTimeForInstanceTermination', 
        'Stop-CDDeployment', 
        'Unregister-CDOnPremiseInstance', 
        'Update-CDApplication', 
        'Update-CDDeploymentGroup', 
        'Write-CDLifecycleEventHookExecutionStatus')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-CDApplications', 
        'Get-CDDeployments')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.CodeDeploy.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview001'
        }
    }
}
