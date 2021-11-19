#
# Module manifest for module 'AWS.Tools.SimpleEmailV2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.SimpleEmailV2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'c6fc5b1a-acc6-4101-a83f-b90966649352'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2022 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The SimpleEmailV2 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Simple Email Service V2 (SES V2) from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.SimpleEmailV2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.SimpleEmailV2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.SimpleEmailV2.Completers.psm1',
        'AWS.Tools.SimpleEmailV2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SES2ResourceTag', 
        'Get-SES2Account', 
        'Get-SES2BlacklistReport', 
        'Get-SES2ConfigurationSet', 
        'Get-SES2ConfigurationSetEventDestination', 
        'Get-SES2ConfigurationSetList', 
        'Get-SES2Contact', 
        'Get-SES2ContactCollection', 
        'Get-SES2ContactList', 
        'Get-SES2ContactListCollection', 
        'Get-SES2CustomVerificationEmailTemplate', 
        'Get-SES2CustomVerificationEmailTemplateList', 
        'Get-SES2DedicatedIp', 
        'Get-SES2DedicatedIpList', 
        'Get-SES2DedicatedIpPoolList', 
        'Get-SES2DeliverabilityDashboardOption', 
        'Get-SES2DeliverabilityTestReport', 
        'Get-SES2DeliverabilityTestReportList', 
        'Get-SES2DomainDeliverabilityCampaign', 
        'Get-SES2DomainDeliverabilityCampaignList', 
        'Get-SES2DomainStatisticsReport', 
        'Get-SES2EmailIdentity', 
        'Get-SES2EmailIdentityList', 
        'Get-SES2EmailIdentityPolicy', 
        'Get-SES2EmailTemplate', 
        'Get-SES2EmailTemplateList', 
        'Get-SES2ImportJob', 
        'Get-SES2ImportJobList', 
        'Get-SES2ResourceTag', 
        'Get-SES2SuppressedDestination', 
        'Get-SES2SuppressedDestinationList', 
        'New-SES2ConfigurationSet', 
        'New-SES2ConfigurationSetEventDestination', 
        'New-SES2Contact', 
        'New-SES2ContactList', 
        'New-SES2CustomVerificationEmailTemplate', 
        'New-SES2DedicatedIpPool', 
        'New-SES2DeliverabilityTestReport', 
        'New-SES2EmailIdentity', 
        'New-SES2EmailIdentityPolicy', 
        'New-SES2EmailTemplate', 
        'New-SES2ImportJob', 
        'Remove-SES2ConfigurationSet', 
        'Remove-SES2ConfigurationSetEventDestination', 
        'Remove-SES2Contact', 
        'Remove-SES2ContactList', 
        'Remove-SES2CustomVerificationEmailTemplate', 
        'Remove-SES2DedicatedIpPool', 
        'Remove-SES2EmailIdentity', 
        'Remove-SES2EmailIdentityPolicy', 
        'Remove-SES2EmailTemplate', 
        'Remove-SES2ResourceTag', 
        'Remove-SES2SuppressedDestination', 
        'Send-SES2BulkEmail', 
        'Send-SES2CustomVerificationEmail', 
        'Send-SES2Email', 
        'Test-SES2RenderEmailTemplate', 
        'Update-SES2ConfigurationSetEventDestination', 
        'Update-SES2Contact', 
        'Update-SES2ContactList', 
        'Update-SES2CustomVerificationEmailTemplate', 
        'Update-SES2EmailIdentityPolicy', 
        'Update-SES2EmailTemplate', 
        'Write-SES2AccountDedicatedIpWarmupAttribute', 
        'Write-SES2AccountDetail', 
        'Write-SES2AccountSendingAttribute', 
        'Write-SES2AccountSuppressionAttribute', 
        'Write-SES2ConfigurationSetDeliveryOption', 
        'Write-SES2ConfigurationSetReputationOption', 
        'Write-SES2ConfigurationSetSendingOption', 
        'Write-SES2ConfigurationSetSuppressionOption', 
        'Write-SES2ConfigurationSetTrackingOption', 
        'Write-SES2DedicatedIpInPool', 
        'Write-SES2DedicatedIpWarmupAttribute', 
        'Write-SES2DeliverabilityDashboardOption', 
        'Write-SES2EmailIdentityConfigurationSetAttribute', 
        'Write-SES2EmailIdentityDkimAttribute', 
        'Write-SES2EmailIdentityDkimSigningAttribute', 
        'Write-SES2EmailIdentityFeedbackAttribute', 
        'Write-SES2EmailIdentityMailFromAttribute', 
        'Write-SES2SuppressedDestination')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.SimpleEmailV2.dll-Help.xml'
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
