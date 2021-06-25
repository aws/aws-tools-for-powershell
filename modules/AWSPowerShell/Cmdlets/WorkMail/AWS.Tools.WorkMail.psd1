#
# Module manifest for module 'AWS.Tools.WorkMail'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.WorkMail.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'bd2a9bac-1831-41cc-aa54-2c89e30bbfac'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2021 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The WorkMail module of AWS Tools for PowerShell lets developers and administrators manage Amazon WorkMail from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.WorkMail.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.WorkMail.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.WorkMail.Completers.psm1',
        'AWS.Tools.WorkMail.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-WMDelegateToResource', 
        'Add-WMMemberToGroup', 
        'Add-WMResourceTag', 
        'Get-WMAccessControlEffect', 
        'Get-WMAccessControlRuleList', 
        'Get-WMAliasList', 
        'Get-WMDefaultRetentionPolicy', 
        'Get-WMDelegateList', 
        'Get-WMGroup', 
        'Get-WMGroupList', 
        'Get-WMMailboxDetail', 
        'Get-WMMailboxExportJob', 
        'Get-WMMailboxExportJobList', 
        'Get-WMMailboxPermissionList', 
        'Get-WMMemberList', 
        'Get-WMMobileDeviceAccessEffect', 
        'Get-WMMobileDeviceAccessOverride', 
        'Get-WMMobileDeviceAccessOverrideList', 
        'Get-WMMobileDeviceAccessRuleList', 
        'Get-WMOrganization', 
        'Get-WMOrganizationList', 
        'Get-WMResource', 
        'Get-WMResourceList', 
        'Get-WMResourceTag', 
        'Get-WMUser', 
        'Get-WMUserList', 
        'New-WMAlias', 
        'New-WMGroup', 
        'New-WMMobileDeviceAccessRule', 
        'New-WMOrganization', 
        'New-WMResource', 
        'New-WMUser', 
        'Register-WMToWorkMail', 
        'Remove-WMAccessControlRule', 
        'Remove-WMAlias', 
        'Remove-WMDelegateFromResource', 
        'Remove-WMFromWorkMail', 
        'Remove-WMGroup', 
        'Remove-WMMailboxPermission', 
        'Remove-WMMemberFromGroup', 
        'Remove-WMMobileDeviceAccessOverride', 
        'Remove-WMMobileDeviceAccessRule', 
        'Remove-WMOrganization', 
        'Remove-WMResource', 
        'Remove-WMResourceTag', 
        'Remove-WMRetentionPolicy', 
        'Remove-WMUser', 
        'Reset-WMPassword', 
        'Start-WMMailboxExportJob', 
        'Stop-WMMailboxExportJob', 
        'Update-WMMailboxQuota', 
        'Update-WMMobileDeviceAccessRule', 
        'Update-WMPrimaryEmailAddress', 
        'Update-WMResource', 
        'Write-WMAccessControlRule', 
        'Write-WMMailboxPermission', 
        'Write-WMMobileDeviceAccessOverride', 
        'Write-WMRetentionPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.WorkMail.dll-Help.xml'
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
