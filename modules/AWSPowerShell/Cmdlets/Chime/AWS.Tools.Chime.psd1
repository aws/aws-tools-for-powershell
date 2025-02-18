#
# Module manifest for module 'AWS.Tools.Chime'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Chime.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'd7ccf373-c58f-4d45-859f-173a57c9a9a3'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Chime module of AWS Tools for PowerShell lets developers and administrators manage Amazon Chime from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Chime.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Chime.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Chime.Completers.psm1',
        'AWS.Tools.Chime.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-CHMAttendee', 
        'Add-CHMMeeting', 
        'Add-CHMPhoneNumbersToVoiceConnector', 
        'Add-CHMPhoneNumbersToVoiceConnectorGroup', 
        'Add-CHMPhoneNumberToUser', 
        'Add-CHMResourceTag', 
        'Add-CHMSigninDelegateGroupsToAccount', 
        'Confirm-CHME911Address', 
        'Disable-CHMUserSuspensionBatch', 
        'Enable-CHMUserSuspensionBatch', 
        'Get-CHMAccount', 
        'Get-CHMAccountList', 
        'Get-CHMAccountSetting', 
        'Get-CHMAppInstance', 
        'Get-CHMAppInstanceAdmin', 
        'Get-CHMAppInstanceAdminList', 
        'Get-CHMAppInstanceList', 
        'Get-CHMAppInstanceRetentionSetting', 
        'Get-CHMAppInstanceStreamingConfiguration', 
        'Get-CHMAppInstanceUser', 
        'Get-CHMAppInstanceUserList', 
        'Get-CHMAttendee', 
        'Get-CHMAttendeeList', 
        'Get-CHMAttendeeTagList', 
        'Get-CHMBot', 
        'Get-CHMBotList', 
        'Get-CHMChannel', 
        'Get-CHMChannelBan', 
        'Get-CHMChannelBanList', 
        'Get-CHMChannelList', 
        'Get-CHMChannelMembership', 
        'Get-CHMChannelMembershipForAppInstanceUser', 
        'Get-CHMChannelMembershipList', 
        'Get-CHMChannelMembershipsForAppInstanceUserList', 
        'Get-CHMChannelMessage', 
        'Get-CHMChannelMessageList', 
        'Get-CHMChannelModeratedByAppInstanceUser', 
        'Get-CHMChannelModerator', 
        'Get-CHMChannelModeratorList', 
        'Get-CHMChannelsModeratedByAppInstanceUserList', 
        'Get-CHMEventsConfiguration', 
        'Get-CHMGlobalSetting', 
        'Get-CHMMediaCapturePipeline', 
        'Get-CHMMediaCapturePipelineList', 
        'Get-CHMMeeting', 
        'Get-CHMMeetingList', 
        'Get-CHMMeetingTagList', 
        'Get-CHMMessagingSessionEndpoint', 
        'Get-CHMPhoneNumber', 
        'Get-CHMPhoneNumberList', 
        'Get-CHMPhoneNumberOrder', 
        'Get-CHMPhoneNumberOrderList', 
        'Get-CHMPhoneNumberSetting', 
        'Get-CHMProxySession', 
        'Get-CHMProxySessionList', 
        'Get-CHMResourceTag', 
        'Get-CHMRetentionSetting', 
        'Get-CHMRoom', 
        'Get-CHMRoomList', 
        'Get-CHMRoomMembershipList', 
        'Get-CHMSipMediaApplication', 
        'Get-CHMSipMediaApplicationList', 
        'Get-CHMSipMediaApplicationLoggingConfiguration', 
        'Get-CHMSipRule', 
        'Get-CHMSipRuleList', 
        'Get-CHMSupportedPhoneNumberCountryList', 
        'Get-CHMUser', 
        'Get-CHMUserList', 
        'Get-CHMUserSetting', 
        'Get-CHMVoiceConnector', 
        'Get-CHMVoiceConnectorEmergencyCallingConfiguration', 
        'Get-CHMVoiceConnectorGroup', 
        'Get-CHMVoiceConnectorGroupList', 
        'Get-CHMVoiceConnectorList', 
        'Get-CHMVoiceConnectorLoggingConfiguration', 
        'Get-CHMVoiceConnectorOrigination', 
        'Get-CHMVoiceConnectorProxy', 
        'Get-CHMVoiceConnectorStreamingConfiguration', 
        'Get-CHMVoiceConnectorTermination', 
        'Get-CHMVoiceConnectorTerminationCredentialList', 
        'Get-CHMVoiceConnectorTerminationHealth', 
        'Hide-CHMChannelMessage', 
        'Hide-CHMConversationMessage', 
        'Hide-CHMRoomMessage', 
        'Invoke-CHMUserLogout', 
        'New-CHMAccount', 
        'New-CHMAppInstance', 
        'New-CHMAppInstanceAdmin', 
        'New-CHMAppInstanceUser', 
        'New-CHMAttendee', 
        'New-CHMAttendeeBatch', 
        'New-CHMBot', 
        'New-CHMChannel', 
        'New-CHMChannelBan', 
        'New-CHMChannelMembership', 
        'New-CHMChannelModerator', 
        'New-CHMCreateChannelMembership', 
        'New-CHMMediaCapturePipeline', 
        'New-CHMMeeting', 
        'New-CHMMeetingDialOut', 
        'New-CHMMeetingWithAttendee', 
        'New-CHMPhoneNumberOrder', 
        'New-CHMProxySession', 
        'New-CHMRoom', 
        'New-CHMRoomMembership', 
        'New-CHMRoomMembershipBatch', 
        'New-CHMSipMediaApplication', 
        'New-CHMSipMediaApplicationCall', 
        'New-CHMSipRule', 
        'New-CHMUser', 
        'New-CHMVoiceConnector', 
        'New-CHMVoiceConnectorGroup', 
        'Remove-CHMAccount', 
        'Remove-CHMAppInstance', 
        'Remove-CHMAppInstanceAdmin', 
        'Remove-CHMAppInstanceStreamingConfiguration', 
        'Remove-CHMAppInstanceUser', 
        'Remove-CHMAttendee', 
        'Remove-CHMAttendeeTag', 
        'Remove-CHMChannel', 
        'Remove-CHMChannelBan', 
        'Remove-CHMChannelMembership', 
        'Remove-CHMChannelMessage', 
        'Remove-CHMChannelModerator', 
        'Remove-CHMEventsConfiguration', 
        'Remove-CHMMediaCapturePipeline', 
        'Remove-CHMMeeting', 
        'Remove-CHMMeetingTag', 
        'Remove-CHMPhoneNumber', 
        'Remove-CHMPhoneNumberBatch', 
        'Remove-CHMPhoneNumberFromUser', 
        'Remove-CHMPhoneNumbersFromVoiceConnector', 
        'Remove-CHMPhoneNumbersFromVoiceConnectorGroup', 
        'Remove-CHMProxySession', 
        'Remove-CHMResourceTag', 
        'Remove-CHMRoom', 
        'Remove-CHMRoomMembership', 
        'Remove-CHMSigninDelegateGroupsFromAccount', 
        'Remove-CHMSipMediaApplication', 
        'Remove-CHMSipRule', 
        'Remove-CHMVoiceConnector', 
        'Remove-CHMVoiceConnectorEmergencyCallingConfiguration', 
        'Remove-CHMVoiceConnectorGroup', 
        'Remove-CHMVoiceConnectorOrigination', 
        'Remove-CHMVoiceConnectorProxy', 
        'Remove-CHMVoiceConnectorStreamingConfiguration', 
        'Remove-CHMVoiceConnectorTermination', 
        'Remove-CHMVoiceConnectorTerminationCredential', 
        'Reset-CHMPersonalPIN', 
        'Restore-CHMPhoneNumber', 
        'Search-CHMAvailablePhoneNumber', 
        'Send-CHMChannelMessage', 
        'Send-CHMUserInvitation', 
        'Start-CHMMeetingTranscription', 
        'Stop-CHMMeetingTranscription', 
        'Update-CHMAccount', 
        'Update-CHMAccountSetting', 
        'Update-CHMAppInstance', 
        'Update-CHMAppInstanceUser', 
        'Update-CHMBot', 
        'Update-CHMChannel', 
        'Update-CHMChannelMessage', 
        'Update-CHMChannelReadMarker', 
        'Update-CHMGlobalSetting', 
        'Update-CHMPhoneNumber', 
        'Update-CHMPhoneNumberBatch', 
        'Update-CHMPhoneNumberSetting', 
        'Update-CHMProxySession', 
        'Update-CHMRoom', 
        'Update-CHMRoomMembership', 
        'Update-CHMSecurityToken', 
        'Update-CHMSipMediaApplication', 
        'Update-CHMSipMediaApplicationCall', 
        'Update-CHMSipRule', 
        'Update-CHMUser', 
        'Update-CHMUserBatch', 
        'Update-CHMUserSetting', 
        'Update-CHMVoiceConnector', 
        'Update-CHMVoiceConnectorGroup', 
        'Write-CHMAppInstanceRetentionSetting', 
        'Write-CHMAppInstanceStreamingConfiguration', 
        'Write-CHMEventsConfiguration', 
        'Write-CHMRetentionSetting', 
        'Write-CHMSipMediaApplicationLoggingConfiguration', 
        'Write-CHMVoiceConnectorEmergencyCallingConfiguration', 
        'Write-CHMVoiceConnectorLoggingConfiguration', 
        'Write-CHMVoiceConnectorOrigination', 
        'Write-CHMVoiceConnectorProxy', 
        'Write-CHMVoiceConnectorStreamingConfiguration', 
        'Write-CHMVoiceConnectorTermination', 
        'Write-CHMVoiceConnectorTerminationCredential')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Chime.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview002'
        }
    }
}
