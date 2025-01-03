#
# Module manifest for module 'AWS.Tools.DataZone'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.DataZone.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'd010e85f-7292-4d5a-ac46-fc86e6837814'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The DataZone module of AWS Tools for PowerShell lets developers and administrators manage Amazon DataZone from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.DataZone.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.DataZone.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.DataZone.Completers.psm1',
        'AWS.Tools.DataZone.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-DZEntityOwner', 
        'Add-DZPolicyGrant', 
        'Add-DZResourceTag', 
        'Approve-DZPrediction', 
        'Approve-DZSubscriptionRequest', 
        'Deny-DZPrediction', 
        'Deny-DZSubscriptionRequest', 
        'Get-DZAsset', 
        'Get-DZAssetFilter', 
        'Get-DZAssetFilterList', 
        'Get-DZAssetRevisionList', 
        'Get-DZAssetType', 
        'Get-DZConnection', 
        'Get-DZConnectionList', 
        'Get-DZDataProduct', 
        'Get-DZDataProductRevisionList', 
        'Get-DZDataSource', 
        'Get-DZDataSourceList', 
        'Get-DZDataSourceRun', 
        'Get-DZDataSourceRunActivityList', 
        'Get-DZDataSourceRunList', 
        'Get-DZDomain', 
        'Get-DZDomainList', 
        'Get-DZDomainUnit', 
        'Get-DZDomainUnitsForParentList', 
        'Get-DZEntityOwnerList', 
        'Get-DZEnvironment', 
        'Get-DZEnvironmentAction', 
        'Get-DZEnvironmentActionList', 
        'Get-DZEnvironmentBlueprint', 
        'Get-DZEnvironmentBlueprintConfiguration', 
        'Get-DZEnvironmentBlueprintConfigurationList', 
        'Get-DZEnvironmentBlueprintList', 
        'Get-DZEnvironmentCredential', 
        'Get-DZEnvironmentList', 
        'Get-DZEnvironmentProfile', 
        'Get-DZEnvironmentProfileList', 
        'Get-DZFormType', 
        'Get-DZGlossary', 
        'Get-DZGlossaryTerm', 
        'Get-DZGroupProfile', 
        'Get-DZIamPortalLoginUrl', 
        'Get-DZJobRun', 
        'Get-DZJobRunList', 
        'Get-DZLineageEvent', 
        'Get-DZLineageEventList', 
        'Get-DZLineageNode', 
        'Get-DZLineageNodeHistoryList', 
        'Get-DZListing', 
        'Get-DZMetadataGenerationRun', 
        'Get-DZMetadataGenerationRunList', 
        'Get-DZNotificationList', 
        'Get-DZPolicyGrantList', 
        'Get-DZProject', 
        'Get-DZProjectList', 
        'Get-DZProjectMembershipList', 
        'Get-DZProjectProfile', 
        'Get-DZProjectProfileList', 
        'Get-DZResourceTag', 
        'Get-DZRule', 
        'Get-DZRuleList', 
        'Get-DZSubscription', 
        'Get-DZSubscriptionGrant', 
        'Get-DZSubscriptionGrantList', 
        'Get-DZSubscriptionList', 
        'Get-DZSubscriptionRequestDetail', 
        'Get-DZSubscriptionRequestList', 
        'Get-DZSubscriptionTarget', 
        'Get-DZSubscriptionTargetList', 
        'Get-DZTimeSeriesDataPoint', 
        'Get-DZTimeSeriesDataPointList', 
        'Get-DZUserProfile', 
        'New-DZAsset', 
        'New-DZAssetFilter', 
        'New-DZAssetRevision', 
        'New-DZAssetType', 
        'New-DZConnection', 
        'New-DZDataProduct', 
        'New-DZDataProductRevision', 
        'New-DZDataSource', 
        'New-DZDomain', 
        'New-DZDomainUnit', 
        'New-DZEnvironment', 
        'New-DZEnvironmentAction', 
        'New-DZEnvironmentProfile', 
        'New-DZFormType', 
        'New-DZGlossary', 
        'New-DZGlossaryTerm', 
        'New-DZGroupProfile', 
        'New-DZListingChangeSet', 
        'New-DZProject', 
        'New-DZProjectMembership', 
        'New-DZProjectProfile', 
        'New-DZRule', 
        'New-DZSubscriptionGrant', 
        'New-DZSubscriptionRequest', 
        'New-DZSubscriptionTarget', 
        'New-DZTimeSeriesDataPoint', 
        'New-DZUserProfile', 
        'Remove-DZAsset', 
        'Remove-DZAssetFilter', 
        'Remove-DZAssetType', 
        'Remove-DZConnection', 
        'Remove-DZDataProduct', 
        'Remove-DZDataSource', 
        'Remove-DZDomain', 
        'Remove-DZDomainUnit', 
        'Remove-DZEntityOwner', 
        'Remove-DZEnvironment', 
        'Remove-DZEnvironmentAction', 
        'Remove-DZEnvironmentBlueprintConfiguration', 
        'Remove-DZEnvironmentProfile', 
        'Remove-DZFormType', 
        'Remove-DZGlossary', 
        'Remove-DZGlossaryTerm', 
        'Remove-DZListing', 
        'Remove-DZPolicyGrant', 
        'Remove-DZProject', 
        'Remove-DZProjectMembership', 
        'Remove-DZProjectProfile', 
        'Remove-DZResourceTag', 
        'Remove-DZRule', 
        'Remove-DZSubscriptionGrant', 
        'Remove-DZSubscriptionRequest', 
        'Remove-DZSubscriptionTarget', 
        'Remove-DZTimeSeriesDataPoint', 
        'Reset-DZEnvironmentRole', 
        'Revoke-DZSubscription', 
        'Search-DZGroupProfile', 
        'Search-DZListing', 
        'Search-DZResource', 
        'Search-DZType', 
        'Search-DZUserProfile', 
        'Set-DZEnvironmentRole', 
        'Start-DZDataSourceRun', 
        'Start-DZMetadataGenerationRun', 
        'Stop-DZMetadataGenerationRun', 
        'Stop-DZSubscription', 
        'Submit-DZLineageEvent', 
        'Update-DZAssetFilter', 
        'Update-DZConnection', 
        'Update-DZDataSource', 
        'Update-DZDomain', 
        'Update-DZDomainUnit', 
        'Update-DZEnvironment', 
        'Update-DZEnvironmentAction', 
        'Update-DZEnvironmentProfile', 
        'Update-DZGlossary', 
        'Update-DZGlossaryTerm', 
        'Update-DZGroupProfile', 
        'Update-DZProject', 
        'Update-DZProjectProfile', 
        'Update-DZRule', 
        'Update-DZSubscriptionGrantStatus', 
        'Update-DZSubscriptionRequest', 
        'Update-DZSubscriptionTarget', 
        'Update-DZUserProfile', 
        'Write-DZEnvironmentBlueprintConfiguration')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.DataZone.dll-Help.xml'
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
