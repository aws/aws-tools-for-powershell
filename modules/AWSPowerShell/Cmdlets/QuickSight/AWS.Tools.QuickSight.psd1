#
# Module manifest for module 'AWS.Tools.QuickSight'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.QuickSight.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '9d3e39fd-cff2-4bf7-9248-e383e43d93d0'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The QuickSight module of AWS Tools for PowerShell lets developers and administrators manage Amazon QuickSight from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.QuickSight.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.QuickSight.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.QuickSight.Completers.psm1',
        'AWS.Tools.QuickSight.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-QSResourceTag', 
        'Find-QSGroup', 
        'Get-QSAccountCustomization', 
        'Get-QSAccountSetting', 
        'Get-QSAccountSubscription', 
        'Get-QSAnalysis', 
        'Get-QSAnalysisDefinition', 
        'Get-QSAnalysisList', 
        'Get-QSAnalysisPermission', 
        'Get-QSAssetBundleExportJob', 
        'Get-QSAssetBundleExportJobList', 
        'Get-QSAssetBundleImportJob', 
        'Get-QSAssetBundleImportJobList', 
        'Get-QSBrand', 
        'Get-QSBrandAssignment', 
        'Get-QSBrandList', 
        'Get-QSBrandPublishedVersion', 
        'Get-QSCustomPermission', 
        'Get-QSCustomPermissionList', 
        'Get-QSDashboard', 
        'Get-QSDashboardDefinition', 
        'Get-QSDashboardEmbedUrl', 
        'Get-QSDashboardList', 
        'Get-QSDashboardPermission', 
        'Get-QSDashboardSnapshotJob', 
        'Get-QSDashboardSnapshotJobResult', 
        'Get-QSDashboardsQAConfiguration', 
        'Get-QSDashboardVersionList', 
        'Get-QSDataSet', 
        'Get-QSDataSetList', 
        'Get-QSDataSetPermission', 
        'Get-QSDataSetRefreshProperty', 
        'Get-QSDataSource', 
        'Get-QSDataSourceList', 
        'Get-QSDataSourcePermission', 
        'Get-QSDefaultQBusinessApplication', 
        'Get-QSFolder', 
        'Get-QSFolderList', 
        'Get-QSFolderMemberList', 
        'Get-QSFolderPermission', 
        'Get-QSFolderResolvedPermission', 
        'Get-QSFoldersForResourceList', 
        'Get-QSGroup', 
        'Get-QSGroupList', 
        'Get-QSGroupMembership', 
        'Get-QSGroupMembershipList', 
        'Get-QSIAMPolicyAssignment', 
        'Get-QSIAMPolicyAssignmentList', 
        'Get-QSIAMPolicyAssignmentsForUserList', 
        'Get-QSIdentityPropagationConfigList', 
        'Get-QSIngestion', 
        'Get-QSIngestionList', 
        'Get-QSIpRestriction', 
        'Get-QSKeyRegistration', 
        'Get-QSNamespace', 
        'Get-QSNamespaceList', 
        'Get-QSQPersonalizationConfiguration', 
        'Get-QSQuickSightQSearchConfiguration', 
        'Get-QSRefreshSchedule', 
        'Get-QSRefreshScheduleList', 
        'Get-QSResourceTag', 
        'Get-QSRoleCustomPermission', 
        'Get-QSRoleMembershipList', 
        'Get-QSSessionEmbedUrl', 
        'Get-QSTemplate', 
        'Get-QSTemplateAlias', 
        'Get-QSTemplateAliasList', 
        'Get-QSTemplateDefinition', 
        'Get-QSTemplateList', 
        'Get-QSTemplatePermission', 
        'Get-QSTemplateVersionList', 
        'Get-QSTheme', 
        'Get-QSThemeAlias', 
        'Get-QSThemeAliasList', 
        'Get-QSThemeList', 
        'Get-QSThemePermission', 
        'Get-QSThemeVersionList', 
        'Get-QSTopic', 
        'Get-QSTopicList', 
        'Get-QSTopicPermission', 
        'Get-QSTopicRefresh', 
        'Get-QSTopicRefreshSchedule', 
        'Get-QSTopicRefreshScheduleList', 
        'Get-QSTopicReviewedAnswerList', 
        'Get-QSUser', 
        'Get-QSUserGroupList', 
        'Get-QSUserList', 
        'Get-QSVPCConnection', 
        'Get-QSVPCConnectionList', 
        'Initialize-QSEmbedUrlForRegisteredUserWithIdentity', 
        'New-QSAccountCustomization', 
        'New-QSAccountSubscription', 
        'New-QSAnalysis', 
        'New-QSBrand', 
        'New-QSCustomPermission', 
        'New-QSDashboard', 
        'New-QSDataSet', 
        'New-QSDataSource', 
        'New-QSEmbedUrlForAnonymousUser', 
        'New-QSEmbedUrlForRegisteredUser', 
        'New-QSFolder', 
        'New-QSFolderMembership', 
        'New-QSGroup', 
        'New-QSGroupMembership', 
        'New-QSIAMPolicyAssignment', 
        'New-QSIngestion', 
        'New-QSNamespace', 
        'New-QSRefreshSchedule', 
        'New-QSRoleMembership', 
        'New-QSTemplate', 
        'New-QSTemplateAlias', 
        'New-QSTheme', 
        'New-QSThemeAlias', 
        'New-QSTopic', 
        'New-QSTopicRefreshSchedule', 
        'New-QSVPCConnection', 
        'Register-QSUser', 
        'Remove-QSAccountCustomization', 
        'Remove-QSAccountSubscription', 
        'Remove-QSAnalysis', 
        'Remove-QSBrand', 
        'Remove-QSBrandAssignment', 
        'Remove-QSCustomPermission', 
        'Remove-QSDashboard', 
        'Remove-QSDataSet', 
        'Remove-QSDataSetRefreshProperty', 
        'Remove-QSDataSource', 
        'Remove-QSDefaultQBusinessApplication', 
        'Remove-QSFolder', 
        'Remove-QSFolderMembership', 
        'Remove-QSGroup', 
        'Remove-QSGroupMembership', 
        'Remove-QSIAMPolicyAssignment', 
        'Remove-QSIdentityPropagationConfig', 
        'Remove-QSNamespace', 
        'Remove-QSRefreshSchedule', 
        'Remove-QSResourceTag', 
        'Remove-QSRoleCustomPermission', 
        'Remove-QSRoleMembership', 
        'Remove-QSTemplate', 
        'Remove-QSTemplateAlias', 
        'Remove-QSTheme', 
        'Remove-QSThemeAlias', 
        'Remove-QSTopic', 
        'Remove-QSTopicRefreshSchedule', 
        'Remove-QSUser', 
        'Remove-QSUserByPrincipalId', 
        'Remove-QSUserCustomPermission', 
        'Remove-QSVPCConnection', 
        'Restore-QSAnalysis', 
        'Search-QSAnalysis', 
        'Search-QSDashboard', 
        'Search-QSDataSet', 
        'Search-QSDataSource', 
        'Search-QSFolder', 
        'Search-QSQAResult', 
        'Search-QSTopic', 
        'Set-QSBatchCreateTopicReviewedAnswer', 
        'Set-QSBatchDeleteTopicReviewedAnswer', 
        'Start-QSAssetBundleExportJob', 
        'Start-QSAssetBundleImportJob', 
        'Start-QSDashboardSnapshotJob', 
        'Start-QSDashboardSnapshotJobSchedule', 
        'Stop-QSIngestion', 
        'Update-QSAccountCustomization', 
        'Update-QSAccountSetting', 
        'Update-QSAnalysis', 
        'Update-QSAnalysisPermission', 
        'Update-QSApplicationWithTokenExchangeGrant', 
        'Update-QSBrand', 
        'Update-QSBrandAssignment', 
        'Update-QSBrandPublishedVersion', 
        'Update-QSCustomPermission', 
        'Update-QSDashboard', 
        'Update-QSDashboardLink', 
        'Update-QSDashboardPermission', 
        'Update-QSDashboardPublishedVersion', 
        'Update-QSDashboardsQAConfiguration', 
        'Update-QSDataSet', 
        'Update-QSDataSetPermission', 
        'Update-QSDataSource', 
        'Update-QSDataSourcePermission', 
        'Update-QSDefaultQBusinessApplication', 
        'Update-QSFolder', 
        'Update-QSFolderPermission', 
        'Update-QSGroup', 
        'Update-QSIAMPolicyAssignment', 
        'Update-QSIdentityPropagationConfig', 
        'Update-QSIpRestriction', 
        'Update-QSKeyRegistration', 
        'Update-QSPublicSharingSetting', 
        'Update-QSQPersonalizationConfiguration', 
        'Update-QSQuickSightQSearchConfiguration', 
        'Update-QSRefreshSchedule', 
        'Update-QSRoleCustomPermission', 
        'Update-QSSPICECapacityConfiguration', 
        'Update-QSTemplate', 
        'Update-QSTemplateAlias', 
        'Update-QSTemplatePermission', 
        'Update-QSTheme', 
        'Update-QSThemeAlias', 
        'Update-QSThemePermission', 
        'Update-QSTopic', 
        'Update-QSTopicPermission', 
        'Update-QSTopicRefreshSchedule', 
        'Update-QSUser', 
        'Update-QSUserCustomPermission', 
        'Update-QSVPCConnection', 
        'Write-QSDataSetRefreshProperty')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.QuickSight.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview005'
        }
    }
}
