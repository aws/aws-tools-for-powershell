#
# Module manifest for module 'AWS.Tools.PinpointSMSVoiceV2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.PinpointSMSVoiceV2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '4e9d7c27-64e2-43d9-8d6c-5e0432b99e7b'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The PinpointSMSVoiceV2 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Pinpoint SMS Voice V2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.PinpointSMSVoiceV2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.PinpointSMSVoiceV2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.PinpointSMSVoiceV2.Completers.psm1',
        'AWS.Tools.PinpointSMSVoiceV2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SMSVResourceTag', 
        'Close-SMSVRegistrationVersion', 
        'Confirm-SMSVDestinationNumber', 
        'Get-SMSVAccountAttribute', 
        'Get-SMSVAccountLimit', 
        'Get-SMSVConfigurationSet', 
        'Get-SMSVKeyword', 
        'Get-SMSVOptedOutNumber', 
        'Get-SMSVOptOutList', 
        'Get-SMSVPhoneNumber', 
        'Get-SMSVPool', 
        'Get-SMSVPoolOriginationIdentityList', 
        'Get-SMSVProtectConfiguration', 
        'Get-SMSVProtectConfigurationCountryRuleSet', 
        'Get-SMSVRegistration', 
        'Get-SMSVRegistrationAssociationList', 
        'Get-SMSVRegistrationAttachment', 
        'Get-SMSVRegistrationFieldDefinition', 
        'Get-SMSVRegistrationFieldValue', 
        'Get-SMSVRegistrationSectionDefinition', 
        'Get-SMSVRegistrationTypeDefinition', 
        'Get-SMSVRegistrationVersion', 
        'Get-SMSVResourcePolicy', 
        'Get-SMSVResourceTagList', 
        'Get-SMSVSenderId', 
        'Get-SMSVSpendLimit', 
        'Get-SMSVVerifiedDestinationNumber', 
        'New-SMSVConfigurationSet', 
        'New-SMSVEventDestination', 
        'New-SMSVOptOutList', 
        'New-SMSVPhoneNumber', 
        'New-SMSVPool', 
        'New-SMSVProtectConfiguration', 
        'New-SMSVRegistration', 
        'New-SMSVRegistrationAssociation', 
        'New-SMSVRegistrationAttachment', 
        'New-SMSVRegistrationVersion', 
        'New-SMSVVerifiedDestinationNumber', 
        'Register-SMSVOriginationIdentity', 
        'Register-SMSVProtectConfiguration', 
        'Remove-SMSVAccountDefaultProtectConfiguration', 
        'Remove-SMSVConfigurationSet', 
        'Remove-SMSVDefaultMessageType', 
        'Remove-SMSVDefaultSenderId', 
        'Remove-SMSVEventDestination', 
        'Remove-SMSVKeyword', 
        'Remove-SMSVMediaMessageSpendLimitOverride', 
        'Remove-SMSVOptedOutNumber', 
        'Remove-SMSVOptOutList', 
        'Remove-SMSVPhoneNumber', 
        'Remove-SMSVPool', 
        'Remove-SMSVProtectConfiguration', 
        'Remove-SMSVRegistration', 
        'Remove-SMSVRegistrationAttachment', 
        'Remove-SMSVRegistrationFieldValue', 
        'Remove-SMSVResourcePolicy', 
        'Remove-SMSVResourceTag', 
        'Remove-SMSVSenderId', 
        'Remove-SMSVTextMessageSpendLimitOverride', 
        'Remove-SMSVVerifiedDestinationNumber', 
        'Remove-SMSVVoiceMessageSpendLimitOverride', 
        'Request-SMSVSenderId', 
        'Send-SMSVDestinationNumberVerificationCode', 
        'Send-SMSVMediaMessage', 
        'Send-SMSVTextMessage', 
        'Send-SMSVVoiceMessage', 
        'Set-SMSVAccountDefaultProtectConfiguration', 
        'Set-SMSVDefaultMessageType', 
        'Set-SMSVDefaultSenderId', 
        'Set-SMSVKeyword', 
        'Set-SMSVMediaMessageSpendLimitOverride', 
        'Set-SMSVOptedOutNumber', 
        'Set-SMSVRegistrationFieldValue', 
        'Set-SMSVTextMessageSpendLimitOverride', 
        'Set-SMSVVoiceMessageSpendLimitOverride', 
        'Submit-SMSVRegistrationVersion', 
        'Unregister-SMSVOriginationIdentity', 
        'Unregister-SMSVProtectConfiguration', 
        'Update-SMSVEventDestination', 
        'Update-SMSVPhoneNumber', 
        'Update-SMSVPool', 
        'Update-SMSVProtectConfiguration', 
        'Update-SMSVProtectConfigurationCountryRuleSet', 
        'Update-SMSVSenderId', 
        'Write-SMSVResourcePolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.PinpointSMSVoiceV2.dll-Help.xml'
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
