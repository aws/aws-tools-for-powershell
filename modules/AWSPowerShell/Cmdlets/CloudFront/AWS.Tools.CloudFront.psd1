#
# Module manifest for module 'AWS.Tools.CloudFront'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.CloudFront.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'ff551d47-e813-4ce6-b82a-d605816d6632'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The CloudFront module of AWS Tools for PowerShell lets developers and administrators manage Amazon CloudFront from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.CloudFront.dll',
        'AWSSDK.Extensions.CloudFront.Signers.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.CloudFront.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.CloudFront.Completers.psm1',
        'AWS.Tools.CloudFront.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-CFDistributionTenantWebACL', 
        'Add-CFDistributionWebACL', 
        'Add-CFResourceTag', 
        'Copy-CFDistribution', 
        'Get-CFAnycastIpList', 
        'Get-CFAnycastIpListList', 
        'Get-CFCachePolicy', 
        'Get-CFCachePolicyConfig', 
        'Get-CFCachePolicyList', 
        'Get-CFCloudFrontOriginAccessIdentity', 
        'Get-CFCloudFrontOriginAccessIdentityConfig', 
        'Get-CFCloudFrontOriginAccessIdentityList', 
        'Get-CFConflictingAlias', 
        'Get-CFConnectionGroup', 
        'Get-CFConnectionGroupByRoutingEndpoint', 
        'Get-CFConnectionGroupList', 
        'Get-CFContinuousDeploymentPolicy', 
        'Get-CFContinuousDeploymentPolicyConfig', 
        'Get-CFContinuousDeploymentPolicyList', 
        'Get-CFDistribution', 
        'Get-CFDistributionConfig', 
        'Get-CFDistributionList', 
        'Get-CFDistributionListByWebACLId', 
        'Get-CFDistributionsByAnycastIpListId', 
        'Get-CFDistributionsByCachePolicyId', 
        'Get-CFDistributionsByConnectionMode', 
        'Get-CFDistributionsByKeyGroup', 
        'Get-CFDistributionsByOriginRequestPolicyId', 
        'Get-CFDistributionsByRealtimeLogConfig', 
        'Get-CFDistributionsByResponseHeadersPolicyId', 
        'Get-CFDistributionsByVpcOriginId', 
        'Get-CFDistributionTenant', 
        'Get-CFDistributionTenantByDomain', 
        'Get-CFDistributionTenantList', 
        'Get-CFDistributionTenantsByCustomization', 
        'Get-CFDomainConflict', 
        'Get-CFFieldLevelEncryption', 
        'Get-CFFieldLevelEncryptionConfig', 
        'Get-CFFieldLevelEncryptionConfigList', 
        'Get-CFFieldLevelEncryptionProfile', 
        'Get-CFFieldLevelEncryptionProfileConfig', 
        'Get-CFFieldLevelEncryptionProfileList', 
        'Get-CFFunction', 
        'Get-CFFunctionList', 
        'Get-CFFunctionSummary', 
        'Get-CFInvalidation', 
        'Get-CFInvalidationForDistributionTenant', 
        'Get-CFInvalidationList', 
        'Get-CFInvalidationsForDistributionTenant', 
        'Get-CFKeyGroup', 
        'Get-CFKeyGroupConfig', 
        'Get-CFKeyGroupList', 
        'Get-CFKeyValueStore', 
        'Get-CFKeyValueStoreListItem', 
        'Get-CFManagedCertificateDetail', 
        'Get-CFMonitoringSubscription', 
        'Get-CFOriginAccessControl', 
        'Get-CFOriginAccessControlConfig', 
        'Get-CFOriginAccessControlList', 
        'Get-CFOriginRequestPolicy', 
        'Get-CFOriginRequestPolicyConfig', 
        'Get-CFOriginRequestPolicyList', 
        'Get-CFPublicKey', 
        'Get-CFPublicKeyConfig', 
        'Get-CFPublicKeyList', 
        'Get-CFRealtimeLogConfig', 
        'Get-CFRealtimeLogConfigList', 
        'Get-CFResourceTag', 
        'Get-CFResponseHeadersPolicy', 
        'Get-CFResponseHeadersPolicyConfig', 
        'Get-CFResponseHeadersPolicyList', 
        'Get-CFStreamingDistribution', 
        'Get-CFStreamingDistributionConfig', 
        'Get-CFStreamingDistributionList', 
        'Get-CFVpcOrigin', 
        'Get-CFVpcOriginList', 
        'Move-CFAlias', 
        'New-CFAnycastIpList', 
        'New-CFCachePolicy', 
        'New-CFCloudFrontOriginAccessIdentity', 
        'New-CFConnectionGroup', 
        'New-CFContinuousDeploymentPolicy', 
        'New-CFDistribution', 
        'New-CFDistributionTenant', 
        'New-CFDistributionWithTag', 
        'New-CFFieldLevelEncryptionConfig', 
        'New-CFFieldLevelEncryptionProfile', 
        'New-CFFunction', 
        'New-CFInvalidation', 
        'New-CFInvalidationForDistributionTenant', 
        'New-CFKeyGroup', 
        'New-CFKeyValueStore', 
        'New-CFMonitoringSubscription', 
        'New-CFOriginAccessControl', 
        'New-CFOriginRequestPolicy', 
        'New-CFPublicKey', 
        'New-CFRealtimeLogConfig', 
        'New-CFResponseHeadersPolicy', 
        'New-CFSignedCookie', 
        'New-CFSignedUrl', 
        'New-CFStreamingDistribution', 
        'New-CFStreamingDistributionWithTag', 
        'New-CFVpcOrigin', 
        'Publish-CFFunction', 
        'Remove-CFAnycastIpList', 
        'Remove-CFCachePolicy', 
        'Remove-CFCloudFrontOriginAccessIdentity', 
        'Remove-CFConnectionGroup', 
        'Remove-CFContinuousDeploymentPolicy', 
        'Remove-CFDistribution', 
        'Remove-CFDistributionTenant', 
        'Remove-CFDistributionTenantWebACL', 
        'Remove-CFDistributionWebACL', 
        'Remove-CFFieldLevelEncryptionConfig', 
        'Remove-CFFieldLevelEncryptionProfile', 
        'Remove-CFFunction', 
        'Remove-CFKeyGroup', 
        'Remove-CFKeyValueStore', 
        'Remove-CFMonitoringSubscription', 
        'Remove-CFOriginAccessControl', 
        'Remove-CFOriginRequestPolicy', 
        'Remove-CFPublicKey', 
        'Remove-CFRealtimeLogConfig', 
        'Remove-CFResourceTag', 
        'Remove-CFResponseHeadersPolicy', 
        'Remove-CFStreamingDistribution', 
        'Remove-CFVpcOrigin', 
        'Test-CFDnsConfiguration', 
        'Test-CFFunction', 
        'Update-CFCachePolicy', 
        'Update-CFCloudFrontOriginAccessIdentity', 
        'Update-CFConnectionGroup', 
        'Update-CFContinuousDeploymentPolicy', 
        'Update-CFDistribution', 
        'Update-CFDistributionTenant', 
        'Update-CFDistributionWithStagingConfig', 
        'Update-CFDomainAssociation', 
        'Update-CFFieldLevelEncryptionConfig', 
        'Update-CFFieldLevelEncryptionProfile', 
        'Update-CFFunction', 
        'Update-CFKeyGroup', 
        'Update-CFKeyValueStore', 
        'Update-CFOriginAccessControl', 
        'Update-CFOriginRequestPolicy', 
        'Update-CFPublicKey', 
        'Update-CFRealtimeLogConfig', 
        'Update-CFResponseHeadersPolicy', 
        'Update-CFStreamingDistribution', 
        'Update-CFVpcOrigin')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-CFCloudFrontOriginAccessIdentities', 
        'Get-CFDistributions', 
        'Get-CFInvalidations', 
        'Get-CFStreamingDistributions')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.CloudFront.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/v5-main/CHANGELOG.md'
            Prerelease = 'preview003'
        }
    }
}
