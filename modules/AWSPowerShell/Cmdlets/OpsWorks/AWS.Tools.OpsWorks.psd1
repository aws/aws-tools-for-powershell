#
# Module manifest for module 'AWS.Tools.OpsWorks'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.OpsWorks.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '681db8f7-26c1-48de-a24e-fee2f6c95c85'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The OpsWorks module of AWS Tools for PowerShell lets developers and administrators manage AWS OpsWorks from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.OpsWorks.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.OpsWorks.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.OpsWorks.Completers.psm1',
        'AWS.Tools.OpsWorks.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-OPSElasticIp', 
        'Add-OPSElasticLoadBalancer', 
        'Add-OPSResourceTag', 
        'Add-OPSVolume', 
        'Copy-OPSStack', 
        'Dismount-OPSElasticLoadBalancer', 
        'Get-OPSAgentVersion', 
        'Get-OPSApp', 
        'Get-OPSCommand', 
        'Get-OPSDeployment', 
        'Get-OPSEcsCluster', 
        'Get-OPSElasticIp', 
        'Get-OPSElasticLoadBalancer', 
        'Get-OPSHostnameSuggestion', 
        'Get-OPSInstance', 
        'Get-OPSLayer', 
        'Get-OPSLoadBasedAutoScaling', 
        'Get-OPSMyUserProfile', 
        'Get-OPSOperatingSystem', 
        'Get-OPSPermission', 
        'Get-OPSRaidArray', 
        'Get-OPSRdsDbInstance', 
        'Get-OPSResourceTag', 
        'Get-OPSServiceError', 
        'Get-OPSStack', 
        'Get-OPSStackProvisioningParameter', 
        'Get-OPSStackSummary', 
        'Get-OPSTimeBasedAutoScaling', 
        'Get-OPSUserProfile', 
        'Get-OPSVolume', 
        'Grant-OPSAccess', 
        'New-OPSApp', 
        'New-OPSDeployment', 
        'New-OPSInstance', 
        'New-OPSLayer', 
        'New-OPSStack', 
        'New-OPSUserProfile', 
        'Register-OPSEcsCluster', 
        'Register-OPSElasticIp', 
        'Register-OPSInstance', 
        'Register-OPSInstanceAssignment', 
        'Register-OPSRdsDbInstance', 
        'Register-OPSVolume', 
        'Remove-OPSApp', 
        'Remove-OPSElasticIp', 
        'Remove-OPSInstance', 
        'Remove-OPSLayer', 
        'Remove-OPSResourceTag', 
        'Remove-OPSStack', 
        'Remove-OPSUserProfile', 
        'Remove-OPSVolume', 
        'Restart-OPSInstance', 
        'Set-OPSLoadBasedAutoScaling', 
        'Set-OPSPermission', 
        'Set-OPSTimeBasedAutoScaling', 
        'Start-OPSInstance', 
        'Start-OPSStack', 
        'Stop-OPSInstance', 
        'Stop-OPSStack', 
        'Unregister-OPSEcsCluster', 
        'Unregister-OPSElasticIp', 
        'Unregister-OPSInstance', 
        'Unregister-OPSInstanceAssignment', 
        'Unregister-OPSRdsDbInstance', 
        'Unregister-OPSVolume', 
        'Update-OPSApp', 
        'Update-OPSElasticIp', 
        'Update-OPSInstance', 
        'Update-OPSLayer', 
        'Update-OPSMyUserProfile', 
        'Update-OPSRdsDbInstance', 
        'Update-OPSStack', 
        'Update-OPSUserProfile', 
        'Update-OPSVolume')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-OPSApps', 
        'Get-OPSCommands', 
        'Get-OPSDeployments', 
        'Get-OPSElasticIps', 
        'Get-OPSElasticLoadBalancers', 
        'Get-OPSInstances', 
        'Get-OPSLayers', 
        'Get-OPSPermissions', 
        'Get-OPSRaidArrays', 
        'Get-OPSRdsDbInstances', 
        'Get-OPSServiceErrors', 
        'Get-OPSStackProvisioningParameters', 
        'Get-OPSStacks', 
        'Get-OPSUserProfiles', 
        'Get-OPSVolumes')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.OpsWorks.dll-Help.xml'
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
