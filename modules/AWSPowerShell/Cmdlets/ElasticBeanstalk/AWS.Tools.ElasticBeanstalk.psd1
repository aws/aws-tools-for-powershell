#
# Module manifest for module 'AWS.Tools.ElasticBeanstalk'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.ElasticBeanstalk.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'fa2177f6-257f-4316-b628-b56f26b02fb7'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2021 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The ElasticBeanstalk module of AWS Tools for PowerShell lets developers and administrators manage AWS Elastic Beanstalk from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.ElasticBeanstalk.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.ElasticBeanstalk.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.ElasticBeanstalk.Completers.psm1',
        'AWS.Tools.ElasticBeanstalk.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Get-EBAccountAttribute', 
        'Get-EBApplication', 
        'Get-EBApplicationVersion', 
        'Get-EBAvailableSolutionStackList', 
        'Get-EBConfigurationOption', 
        'Get-EBConfigurationSetting', 
        'Get-EBDNSAvailability', 
        'Get-EBEnvironment', 
        'Get-EBEnvironmentHealth', 
        'Get-EBEnvironmentInfo', 
        'Get-EBEnvironmentManagedAction', 
        'Get-EBEnvironmentManagedActionHistory', 
        'Get-EBEnvironmentResource', 
        'Get-EBEvent', 
        'Get-EBInstanceHealth', 
        'Get-EBPlatformBranch', 
        'Get-EBPlatformVersion', 
        'Get-EBPlatformVersionDetail', 
        'Get-EBResourceTag', 
        'Group-EBEnvironment', 
        'New-EBApplication', 
        'New-EBApplicationVersion', 
        'New-EBConfigurationTemplate', 
        'New-EBEnvironment', 
        'New-EBPlatformVersion', 
        'New-EBStorageLocation', 
        'Register-EBEnvironmentOperationsRole', 
        'Remove-EBApplication', 
        'Remove-EBApplicationVersion', 
        'Remove-EBConfigurationTemplate', 
        'Remove-EBEnvironmentConfiguration', 
        'Remove-EBPlatformVersion', 
        'Request-EBEnvironmentInfo', 
        'Restart-EBAppServer', 
        'Set-EBEnvironmentCNAME', 
        'Start-EBEnvironmentRebuild', 
        'Stop-EBEnvironment', 
        'Stop-EBEnvironmentUpdate', 
        'Submit-EBEnvironmentManagedAction', 
        'Test-EBConfigurationSetting', 
        'Unregister-EBEnvironmentOperationsRole', 
        'Update-EBApplication', 
        'Update-EBApplicationResourceLifecycle', 
        'Update-EBApplicationVersion', 
        'Update-EBConfigurationTemplate', 
        'Update-EBEnvironment', 
        'Update-EBResourceTag')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-EBApplications', 
        'Get-EBApplicationVersions', 
        'Get-EBConfigurationOptions', 
        'Get-EBConfigurationSettings', 
        'Get-EBEnvironmentResources', 
        'Get-EBAvailableSolutionStack', 
        'Set-EBEnvironmentCNAMEs', 
        'Test-EBConfigurationSettings')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.ElasticBeanstalk.dll-Help.xml'
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
