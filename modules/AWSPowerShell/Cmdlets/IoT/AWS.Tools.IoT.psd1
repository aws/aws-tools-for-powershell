#
# Module manifest for module 'AWS.Tools.IoT'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.IoT.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'd75b8399-46ee-434e-8fe4-43ef3faa5780'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The IoT module of AWS Tools for PowerShell lets developers and administrators manage AWS IoT from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.IoT.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.IoT.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.IoT.Completers.psm1',
        'AWS.Tools.IoT.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-IOTPolicy', 
        'Add-IOTPrincipalPolicy', 
        'Add-IOTResourceTag', 
        'Add-IOTTargetsWithJob', 
        'Add-IOTThingPrincipal', 
        'Add-IOTThingToBillingGroup', 
        'Add-IOTThingToThingGroup', 
        'Clear-IOTDefaultAuthorizer', 
        'Confirm-IOTCertificateTransfer', 
        'Confirm-IOTTopicRuleDestination', 
        'Deny-IOTCertificateTransfer', 
        'Disable-IOTTopicRule', 
        'Dismount-IOTPolicy', 
        'Dismount-IOTSecurityProfile', 
        'Enable-IOTTopicRule', 
        'Get-IOTAccountAuditConfiguration', 
        'Get-IOTActiveViolationList', 
        'Get-IOTAttachedPolicyList', 
        'Get-IOTAuditFinding', 
        'Get-IOTAuditFindingList', 
        'Get-IOTAuditMitigationActionsExecutionList', 
        'Get-IOTAuditMitigationActionsTask', 
        'Get-IOTAuditMitigationActionsTaskList', 
        'Get-IOTAuditTask', 
        'Get-IOTAuthorizer', 
        'Get-IOTAuthorizerList', 
        'Get-IOTBillingGroup', 
        'Get-IOTBillingGroupList', 
        'Get-IOTCACertificate', 
        'Get-IOTCACertificateList', 
        'Get-IOTCardinality', 
        'Get-IOTCertificate', 
        'Get-IOTCertificateList', 
        'Get-IOTCertificateListByCA', 
        'Get-IOTDefaultAuthorizer', 
        'Get-IOTDomainConfiguration', 
        'Get-IOTDomainConfigurationList', 
        'Get-IOTEffectivePolicy', 
        'Get-IOTEndpoint', 
        'Get-IOTEventConfiguration', 
        'Get-IOTIndex', 
        'Get-IOTIndexingConfiguration', 
        'Get-IOTIndexList', 
        'Get-IOTJob', 
        'Get-IOTJobDocument', 
        'Get-IOTJobExecution', 
        'Get-IOTJobExecutionsForJobList', 
        'Get-IOTJobExecutionsForThingList', 
        'Get-IOTJobList', 
        'Get-IOTLoggingOption', 
        'Get-IOTMitigationAction', 
        'Get-IOTMitigationActionList', 
        'Get-IOTOTAUpdate', 
        'Get-IOTOTAUpdateList', 
        'Get-IOTOutgoingCertificate', 
        'Get-IOTPercentile', 
        'Get-IOTPolicy', 
        'Get-IOTPolicyList', 
        'Get-IOTPolicyPrincipalList', 
        'Get-IOTPolicyVersion', 
        'Get-IOTPolicyVersionList', 
        'Get-IOTPrincipalPolicyList', 
        'Get-IOTPrincipalThingList', 
        'Get-IOTProvisioningTemplate', 
        'Get-IOTProvisioningTemplateList', 
        'Get-IOTProvisioningTemplateVersion', 
        'Get-IOTProvisioningTemplateVersionList', 
        'Get-IOTRegistrationCode', 
        'Get-IOTRoleAlias', 
        'Get-IOTRoleAliasList', 
        'Get-IOTScheduledAudit', 
        'Get-IOTScheduledAuditList', 
        'Get-IOTSecurityProfile', 
        'Get-IOTSecurityProfileList', 
        'Get-IOTSecurityProfilesForTargetList', 
        'Get-IOTStatistic', 
        'Get-IOTStream', 
        'Get-IOTStreamList', 
        'Get-IOTTagListForResource', 
        'Get-IOTTargetsForPolicyList', 
        'Get-IOTTargetsForSecurityProfileList', 
        'Get-IOTTaskList', 
        'Get-IOTThing', 
        'Get-IOTThingGroup', 
        'Get-IOTThingGroupList', 
        'Get-IOTThingGroupsForThingList', 
        'Get-IOTThingList', 
        'Get-IOTThingPrincipalList', 
        'Get-IOTThingRegistrationTask', 
        'Get-IOTThingRegistrationTaskList', 
        'Get-IOTThingRegistrationTaskReportList', 
        'Get-IOTThingsInBillingGroupList', 
        'Get-IOTThingsInThingGroupList', 
        'Get-IOTThingType', 
        'Get-IOTThingTypeList', 
        'Get-IOTTopicRule', 
        'Get-IOTTopicRuleDestination', 
        'Get-IOTTopicRuleDestinationList', 
        'Get-IOTTopicRuleList', 
        'Get-IOTV2LoggingLevelList', 
        'Get-IOTV2LoggingOption', 
        'Get-IOTViolationEventList', 
        'Mount-IOTSecurityProfile', 
        'New-IOTAuthorizer', 
        'New-IOTBillingGroup', 
        'New-IOTCertificateFromCsr', 
        'New-IOTDomainConfiguration', 
        'New-IOTDynamicThingGroup', 
        'New-IOTJob', 
        'New-IOTKeysAndCertificate', 
        'New-IOTMitigationAction', 
        'New-IOTOTAUpdate', 
        'New-IOTPolicy', 
        'New-IOTPolicyVersion', 
        'New-IOTProvisioningClaim', 
        'New-IOTProvisioningTemplate', 
        'New-IOTProvisioningTemplateVersion', 
        'New-IOTRoleAlias', 
        'New-IOTScheduledAudit', 
        'New-IOTSecurityProfile', 
        'New-IOTStream', 
        'New-IOTThing', 
        'New-IOTThingGroup', 
        'New-IOTThingType', 
        'New-IOTTopicRule', 
        'New-IOTTopicRuleDestination', 
        'Register-IOTCACertificate', 
        'Register-IOTCertificate', 
        'Register-IOTThing', 
        'Remove-IOTAccountAuditConfiguration', 
        'Remove-IOTAuthorizer', 
        'Remove-IOTBillingGroup', 
        'Remove-IOTCACertificate', 
        'Remove-IOTCertificate', 
        'Remove-IOTDomainConfiguration', 
        'Remove-IOTDynamicThingGroup', 
        'Remove-IOTJob', 
        'Remove-IOTJobExecution', 
        'Remove-IOTMitigationAction', 
        'Remove-IOTOTAUpdate', 
        'Remove-IOTPolicy', 
        'Remove-IOTPolicyVersion', 
        'Remove-IOTPrincipalPolicy', 
        'Remove-IOTProvisioningTemplate', 
        'Remove-IOTProvisioningTemplateVersion', 
        'Remove-IOTRegistrationCode', 
        'Remove-IOTResourceTag', 
        'Remove-IOTRoleAlias', 
        'Remove-IOTScheduledAudit', 
        'Remove-IOTSecurityProfile', 
        'Remove-IOTStream', 
        'Remove-IOTThing', 
        'Remove-IOTThingFromBillingGroup', 
        'Remove-IOTThingFromThingGroup', 
        'Remove-IOTThingGroup', 
        'Remove-IOTThingPrincipal', 
        'Remove-IOTThingType', 
        'Remove-IOTTopicRule', 
        'Remove-IOTTopicRuleDestination', 
        'Remove-IOTV2LoggingLevel', 
        'Request-IOTCertificateTransfer', 
        'Search-IOTIndex', 
        'Set-IOTDefaultAuthorizer', 
        'Set-IOTDefaultPolicyVersion', 
        'Set-IOTLoggingOption', 
        'Set-IOTThingTypeDeprecation', 
        'Set-IOTTopicRule', 
        'Set-IOTV2LoggingLevel', 
        'Set-IOTV2LoggingOption', 
        'Start-IOTAuditMitigationActionsTask', 
        'Start-IOTOnDemandAuditTask', 
        'Start-IOTThingRegistrationTask', 
        'Stop-IOTAuditMitigationActionsTask', 
        'Stop-IOTAuditTask', 
        'Stop-IOTCertificateTransfer', 
        'Stop-IOTJob', 
        'Stop-IOTJobExecution', 
        'Stop-IOTThingRegistrationTask', 
        'Test-IOTAuthorization', 
        'Test-IOTInvokeAuthorizer', 
        'Test-IOTValidSecurityProfileBehavior', 
        'Update-IOTAccountAuditConfiguration', 
        'Update-IOTAuthorizer', 
        'Update-IOTBillingGroup', 
        'Update-IOTCACertificate', 
        'Update-IOTCertificate', 
        'Update-IOTDomainConfiguration', 
        'Update-IOTDynamicThingGroup', 
        'Update-IOTEventConfiguration', 
        'Update-IOTIndexingConfiguration', 
        'Update-IOTJob', 
        'Update-IOTMitigationAction', 
        'Update-IOTProvisioningTemplate', 
        'Update-IOTRoleAlias', 
        'Update-IOTScheduledAudit', 
        'Update-IOTSecurityProfile', 
        'Update-IOTStream', 
        'Update-IOTThing', 
        'Update-IOTThingGroup', 
        'Update-IOTThingGroupsForThing', 
        'Update-IOTTopicRuleDestination')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-IOTLoggingOptions', 
        'Set-IOTLoggingOptions', 
        'Get-IOTAuthorizersList', 
        'Get-IOTAttachedPoliciesList', 
        'Get-IOTIndicesList', 
        'Get-IOTJobsList', 
        'Get-IOTPolicyPrincipalsList', 
        'Get-IOTRoleAliasesList', 
        'Get-IOTThingGroupsList', 
        'Get-IOTThingRegistrationTaskReportsList', 
        'Get-IOTThingRegistrationTasksList', 
        'Get-IOTThingTypesList', 
        'Get-IOTV2LoggingLevelsList', 
        'Get-IOTViolationEventsList')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.IoT.dll-Help.xml'
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
