#
# Module manifest for module 'AWS.Tools.SimpleEmail'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.SimpleEmail.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '7956fac9-07cc-43b4-8dd1-de9a3dd8f1a0'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The SimpleEmail module of AWS Tools for PowerShell lets developers and administrators manage Amazon Simple Email Service (SES) from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.SimpleEmail.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.SimpleEmail.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.SimpleEmail.Completers.psm1',
        'AWS.Tools.SimpleEmail.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Confirm-SESDomainDkim', 
        'Confirm-SESDomainIdentity', 
        'Confirm-SESEmailAddress', 
        'Confirm-SESEmailIdentity', 
        'Copy-SESReceiptRuleSet', 
        'Get-SESAccountSendingEnabled', 
        'Get-SESActiveReceiptRuleSet', 
        'Get-SESConfigurationSet', 
        'Get-SESConfigurationSetList', 
        'Get-SESCustomVerificationEmailTemplate', 
        'Get-SESCustomVerificationEmailTemplateList', 
        'Get-SESIdentity', 
        'Get-SESIdentityDkimAttribute', 
        'Get-SESIdentityMailFromDomainAttribute', 
        'Get-SESIdentityNotificationAttribute', 
        'Get-SESIdentityPolicy', 
        'Get-SESIdentityPolicyList', 
        'Get-SESIdentityVerificationAttribute', 
        'Get-SESReceiptFilterList', 
        'Get-SESReceiptRule', 
        'Get-SESReceiptRuleSet', 
        'Get-SESReceiptRuleSetList', 
        'Get-SESSendQuota', 
        'Get-SESSendStatistic', 
        'Get-SESTemplate', 
        'Get-SESTemplateList', 
        'Get-SESVerifiedEmailAddress', 
        'New-SESConfigurationSet', 
        'New-SESConfigurationSetEventDestination', 
        'New-SESConfigurationSetTrackingOption', 
        'New-SESCustomVerificationEmailTemplate', 
        'New-SESReceiptFilter', 
        'New-SESReceiptRule', 
        'New-SESReceiptRuleSet', 
        'New-SESTemplate', 
        'Remove-SESConfigurationSet', 
        'Remove-SESConfigurationSetEventDestination', 
        'Remove-SESConfigurationSetTrackingOption', 
        'Remove-SESCustomVerificationEmailTemplate', 
        'Remove-SESIdentity', 
        'Remove-SESIdentityPolicy', 
        'Remove-SESReceiptFilter', 
        'Remove-SESReceiptRule', 
        'Remove-SESReceiptRuleSet', 
        'Remove-SESTemplate', 
        'Remove-SESVerifiedEmailAddress', 
        'Send-SESBounce', 
        'Send-SESBulkTemplatedEmail', 
        'Send-SESCustomVerificationEmail', 
        'Send-SESEmail', 
        'Send-SESRawEmail', 
        'Send-SESTemplatedEmail', 
        'Set-SESActiveReceiptRuleSet', 
        'Set-SESIdentityDkimEnabled', 
        'Set-SESIdentityFeedbackForwardingEnabled', 
        'Set-SESIdentityHeadersInNotificationsEnabled', 
        'Set-SESIdentityMailFromDomain', 
        'Set-SESIdentityNotificationTopic', 
        'Set-SESReceiptRulePosition', 
        'Set-SESReceiptRuleSetOrder', 
        'Test-SESRenderTemplate', 
        'Update-SESAccountSendingEnabled', 
        'Update-SESConfigurationSetEventDestination', 
        'Update-SESConfigurationSetReputationMetricsEnabled', 
        'Update-SESConfigurationSetSendingEnabled', 
        'Update-SESConfigurationSetTrackingOption', 
        'Update-SESCustomVerificationEmailTemplate', 
        'Update-SESReceiptRule', 
        'Update-SESTemplate', 
        'Write-SESConfigurationSetDeliveryOption', 
        'Write-SESIdentityPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-SESIdentityMailFromDomainAttributes', 
        'Get-SESSendStatistics', 
        'Get-SESReceiptFilters', 
        'Get-SESReceiptRuleSets')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.SimpleEmail.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v4.1/CHANGELOG.md'
        }
    }
}
