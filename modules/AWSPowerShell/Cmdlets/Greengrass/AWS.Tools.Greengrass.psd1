#
# Module manifest for module 'AWS.Tools.Greengrass'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Greengrass.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '229c46fd-32a0-4931-9f7a-e880682a989a'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Greengrass module of AWS Tools for PowerShell lets developers and administrators manage AWS Greengrass from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Greengrass.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Greengrass.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Greengrass.Completers.psm1',
        'AWS.Tools.Greengrass.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-GGResourceTag', 
        'Add-GGRoleToGroup', 
        'Add-GGServiceRoleToAccount', 
        'Get-GGAssociatedRole', 
        'Get-GGBulkDeploymentDetailedReportList', 
        'Get-GGBulkDeploymentList', 
        'Get-GGBulkDeploymentStatus', 
        'Get-GGConnectivityInfo', 
        'Get-GGConnectorDefinition', 
        'Get-GGConnectorDefinitionList', 
        'Get-GGConnectorDefinitionVersion', 
        'Get-GGConnectorDefinitionVersionList', 
        'Get-GGCoreDefinition', 
        'Get-GGCoreDefinitionList', 
        'Get-GGCoreDefinitionVersion', 
        'Get-GGCoreDefinitionVersionList', 
        'Get-GGDeploymentList', 
        'Get-GGDeploymentStatus', 
        'Get-GGDeviceDefinition', 
        'Get-GGDeviceDefinitionList', 
        'Get-GGDeviceDefinitionVersion', 
        'Get-GGDeviceDefinitionVersionList', 
        'Get-GGFunctionDefinition', 
        'Get-GGFunctionDefinitionList', 
        'Get-GGFunctionDefinitionVersion', 
        'Get-GGFunctionDefinitionVersionList', 
        'Get-GGGroup', 
        'Get-GGGroupCertificateAuthority', 
        'Get-GGGroupCertificateAuthorityList', 
        'Get-GGGroupCertificateConfiguration', 
        'Get-GGGroupList', 
        'Get-GGGroupVersion', 
        'Get-GGGroupVersionList', 
        'Get-GGLoggerDefinition', 
        'Get-GGLoggerDefinitionList', 
        'Get-GGLoggerDefinitionVersion', 
        'Get-GGLoggerDefinitionVersionList', 
        'Get-GGResourceDefinition', 
        'Get-GGResourceDefinitionList', 
        'Get-GGResourceDefinitionVersion', 
        'Get-GGResourceDefinitionVersionList', 
        'Get-GGResourceTag', 
        'Get-GGServiceRoleForAccount', 
        'Get-GGSubscriptionDefinition', 
        'Get-GGSubscriptionDefinitionList', 
        'Get-GGSubscriptionDefinitionVersion', 
        'Get-GGSubscriptionDefinitionVersionList', 
        'Get-GGThingRuntimeConfiguration', 
        'New-GGConnectorDefinition', 
        'New-GGConnectorDefinitionVersion', 
        'New-GGCoreDefinition', 
        'New-GGCoreDefinitionVersion', 
        'New-GGDeployment', 
        'New-GGDeviceDefinition', 
        'New-GGDeviceDefinitionVersion', 
        'New-GGFunctionDefinition', 
        'New-GGFunctionDefinitionVersion', 
        'New-GGGroup', 
        'New-GGGroupCertificateAuthority', 
        'New-GGGroupVersion', 
        'New-GGLoggerDefinition', 
        'New-GGLoggerDefinitionVersion', 
        'New-GGResourceDefinition', 
        'New-GGResourceDefinitionVersion', 
        'New-GGSoftwareUpdateJob', 
        'New-GGSubscriptionDefinition', 
        'New-GGSubscriptionDefinitionVersion', 
        'Remove-GGConnectorDefinition', 
        'Remove-GGCoreDefinition', 
        'Remove-GGDeviceDefinition', 
        'Remove-GGFunctionDefinition', 
        'Remove-GGGroup', 
        'Remove-GGLoggerDefinition', 
        'Remove-GGResourceDefinition', 
        'Remove-GGResourceTag', 
        'Remove-GGRoleFromGroup', 
        'Remove-GGServiceRoleFromAccount', 
        'Remove-GGSubscriptionDefinition', 
        'Reset-GGDeployment', 
        'Start-GGBulkDeployment', 
        'Stop-GGBulkDeployment', 
        'Update-GGConnectivityInfo', 
        'Update-GGConnectorDefinition', 
        'Update-GGCoreDefinition', 
        'Update-GGDeviceDefinition', 
        'Update-GGFunctionDefinition', 
        'Update-GGGroup', 
        'Update-GGGroupCertificateConfiguration', 
        'Update-GGLoggerDefinition', 
        'Update-GGResourceDefinition', 
        'Update-GGSubscriptionDefinition', 
        'Update-GGThingRuntimeConfiguration')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Greengrass.dll-Help.xml'
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
