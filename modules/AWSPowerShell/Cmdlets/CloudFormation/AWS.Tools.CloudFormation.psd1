#
# Module manifest for module 'AWS.Tools.CloudFormation'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.CloudFormation.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '25a56d59-4904-4dde-a346-7fe941d04baa'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2023 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The CloudFormation module of AWS Tools for PowerShell lets developers and administrators manage AWS CloudFormation from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.CloudFormation.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.CloudFormation.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.CloudFormation.Completers.psm1',
        'AWS.Tools.CloudFormation.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Disable-CFNOrganizationsAccess', 
        'Disable-CFNType', 
        'Enable-CFNOrganizationsAccess', 
        'Enable-CFNType', 
        'Get-CFNAccountLimit', 
        'Get-CFNChangeSet', 
        'Get-CFNChangeSetHook', 
        'Get-CFNChangeSetList', 
        'Get-CFNDescribeTypeConfiguration', 
        'Get-CFNDetectedStackResourceDrift', 
        'Get-CFNExport', 
        'Get-CFNImportList', 
        'Get-CFNOrganizationsAccess', 
        'Get-CFNPublisher', 
        'Get-CFNStack', 
        'Get-CFNStackDriftDetectionStatus', 
        'Get-CFNStackEvent', 
        'Get-CFNStackInstance', 
        'Get-CFNStackInstanceList', 
        'Get-CFNStackPolicy', 
        'Get-CFNStackResource', 
        'Get-CFNStackResourceDrift', 
        'Get-CFNStackResourceList', 
        'Get-CFNStackResourceSummary', 
        'Get-CFNStackSet', 
        'Get-CFNStackSetList', 
        'Get-CFNStackSetOperation', 
        'Get-CFNStackSetOperationList', 
        'Get-CFNStackSetOperationResultList', 
        'Get-CFNStackSummary', 
        'Get-CFNTemplate', 
        'Get-CFNTemplateSummary', 
        'Get-CFNType', 
        'Get-CFNTypeList', 
        'Get-CFNTypeRegistration', 
        'Get-CFNTypeRegistrationList', 
        'Get-CFNTypeVersion', 
        'Import-CFNStacksToStackSet', 
        'Measure-CFNTemplateCost', 
        'New-CFNChangeSet', 
        'New-CFNStack', 
        'New-CFNStackInstance', 
        'New-CFNStackSet', 
        'Publish-CFNType', 
        'Register-CFNPublisher', 
        'Register-CFNType', 
        'Remove-CFNChangeSet', 
        'Remove-CFNStack', 
        'Remove-CFNStackInstance', 
        'Remove-CFNStackSet', 
        'Resume-CFNUpdateRollback', 
        'Send-CFNResourceSignal', 
        'Set-CFNStackPolicy', 
        'Set-CFNTypeConfiguration', 
        'Set-CFNTypeDefaultVersion', 
        'Start-CFNChangeSet', 
        'Start-CFNStackDriftDetection', 
        'Start-CFNStackSetDriftDetection', 
        'Stop-CFNStackSetOperation', 
        'Stop-CFNUpdateStack', 
        'Test-CFNStack', 
        'Test-CFNTemplate', 
        'Test-CFNType', 
        'Undo-CFNStack', 
        'Unregister-CFNType', 
        'Update-CFNStack', 
        'Update-CFNStackInstance', 
        'Update-CFNStackSet', 
        'Update-CFNTerminationProtection', 
        'Wait-CFNStack', 
        'Write-CFNHandlerProgress')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-CFNAccountLimits', 
        'Get-CFNStackEvents', 
        'Get-CFNStackResources', 
        'Get-CFNStackResourceSummaries', 
        'Get-CFNStackSummaries')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.CloudFormation.dll-Help.xml'
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
