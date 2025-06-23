#
# Module manifest for module 'AWS.Tools.Lightsail'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Lightsail.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'e377dc03-9220-472e-b867-022d50e3e328'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Lightsail module of AWS Tools for PowerShell lets developers and administrators manage Amazon Lightsail from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Lightsail.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Lightsail.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Lightsail.Completers.psm1',
        'AWS.Tools.Lightsail.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-LSAlarm', 
        'Add-LSDisk', 
        'Add-LSInstancesToLoadBalancer', 
        'Add-LSLoadBalancerTlsCertificate', 
        'Add-LSPeerVpc', 
        'Add-LSResourceTag', 
        'Close-LSInstancePublicPort', 
        'Copy-LSSnapshot', 
        'Disable-LSAddOn', 
        'Dismount-LSCertificateFromDistribution', 
        'Dismount-LSDisk', 
        'Dismount-LSInstancesFromLoadBalancer', 
        'Dismount-LSStaticIp', 
        'Enable-LSAddOn', 
        'Export-LSSnapshot', 
        'Get-LSActiveNameList', 
        'Get-LSAlarm', 
        'Get-LSAutoSnapshot', 
        'Get-LSBlueprintList', 
        'Get-LSBucket', 
        'Get-LSBucketAccessKey', 
        'Get-LSBucketBundle', 
        'Get-LSBucketMetricData', 
        'Get-LSBundleList', 
        'Get-LSCertificate', 
        'Get-LSCloudFormationStackRecord', 
        'Get-LSContactMethod', 
        'Get-LSContainerAPIMetadata', 
        'Get-LSContainerImage', 
        'Get-LSContainerLog', 
        'Get-LSContainerService', 
        'Get-LSContainerServiceDeployment', 
        'Get-LSContainerServiceMetricData', 
        'Get-LSContainerServicePower', 
        'Get-LSCostEstimate', 
        'Get-LSDisk', 
        'Get-LSDiskList', 
        'Get-LSDiskSnapshot', 
        'Get-LSDiskSnapshotList', 
        'Get-LSDistribution', 
        'Get-LSDistributionBundle', 
        'Get-LSDistributionLatestCacheReset', 
        'Get-LSDistributionMetricData', 
        'Get-LSDomain', 
        'Get-LSDomainList', 
        'Get-LSExportSnapshotRecord', 
        'Get-LSInstance', 
        'Get-LSInstanceAccessDetail', 
        'Get-LSInstanceList', 
        'Get-LSInstanceMetricData', 
        'Get-LSInstancePortStateList', 
        'Get-LSInstanceSnapshot', 
        'Get-LSInstanceSnapshotList', 
        'Get-LSInstanceState', 
        'Get-LSKeyPairInfo', 
        'Get-LSKeypairList', 
        'Get-LSLoadBalancer', 
        'Get-LSLoadBalancerList', 
        'Get-LSLoadBalancerMetricData', 
        'Get-LSLoadBalancerTlsCertificate', 
        'Get-LSLoadBalancerTlsPolicy', 
        'Get-LSOperation', 
        'Get-LSOperationList', 
        'Get-LSOperationListForResource', 
        'Get-LSRegionList', 
        'Get-LSRelationalDatabase', 
        'Get-LSRelationalDatabaseBlueprint', 
        'Get-LSRelationalDatabaseBundle', 
        'Get-LSRelationalDatabaseEvent', 
        'Get-LSRelationalDatabaseList', 
        'Get-LSRelationalDatabaseLogEvent', 
        'Get-LSRelationalDatabaseLogStream', 
        'Get-LSRelationalDatabaseMasterUserPassword', 
        'Get-LSRelationalDatabaseMetricData', 
        'Get-LSRelationalDatabaseParameter', 
        'Get-LSRelationalDatabaseSnapshot', 
        'Get-LSRelationalDatabaseSnapshotList', 
        'Get-LSSetupHistory', 
        'Get-LSStaticIp', 
        'Get-LSStaticIpList', 
        'Import-LSKeyPair', 
        'Mount-LSCertificateToDistribution', 
        'Mount-LSStaticIp', 
        'New-LSBucket', 
        'New-LSBucketAccessKey', 
        'New-LSCertificate', 
        'New-LSCloudFormationStack', 
        'New-LSContactMethod', 
        'New-LSContainerService', 
        'New-LSContainerServiceDeployment', 
        'New-LSContainerServiceRegistryLogin', 
        'New-LSDisk', 
        'New-LSDiskFromSnapshot', 
        'New-LSDiskSnapshot', 
        'New-LSDistribution', 
        'New-LSDomain', 
        'New-LSDomainEntry', 
        'New-LSGUISessionAccessDetail', 
        'New-LSInstance', 
        'New-LSInstancesFromSnapshot', 
        'New-LSInstanceSnapshot', 
        'New-LSKeyPair', 
        'New-LSLoadBalancer', 
        'New-LSLoadBalancerTlsCertificate', 
        'New-LSRelationalDatabase', 
        'New-LSRelationalDatabaseFromSnapshot', 
        'New-LSRelationalDatabaseSnapshot', 
        'New-LSStaticIp', 
        'Open-LSInstancePublicPort', 
        'Read-LSDefaultKeyPair', 
        'Register-LSContainerImage', 
        'Remove-LSAlarm', 
        'Remove-LSAutoSnapshot', 
        'Remove-LSBucket', 
        'Remove-LSBucketAccessKey', 
        'Remove-LSCertificate', 
        'Remove-LSContactMethod', 
        'Remove-LSContainerImage', 
        'Remove-LSContainerService', 
        'Remove-LSDisk', 
        'Remove-LSDiskSnapshot', 
        'Remove-LSDistribution', 
        'Remove-LSDomain', 
        'Remove-LSDomainEntry', 
        'Remove-LSInstance', 
        'Remove-LSInstanceSnapshot', 
        'Remove-LSKeyPair', 
        'Remove-LSKnownHostKey', 
        'Remove-LSLoadBalancer', 
        'Remove-LSLoadBalancerTlsCertificate', 
        'Remove-LSPeerVpc', 
        'Remove-LSRelationalDatabase', 
        'Remove-LSRelationalDatabaseSnapshot', 
        'Remove-LSResourceTag', 
        'Remove-LSStaticIp', 
        'Reset-LSDistributionCache', 
        'Restart-LSInstance', 
        'Restart-LSRelationalDatabase', 
        'Send-LSContactMethodVerification', 
        'Set-LSInstanceHttp', 
        'Set-LSInstancePublicPort', 
        'Set-LSIpAddressType', 
        'Set-LSResourceAccessForBucket', 
        'Start-LSGUISession', 
        'Start-LSInstance', 
        'Start-LSRelationalDatabase', 
        'Stop-LSGUISession', 
        'Stop-LSInstance', 
        'Stop-LSRelationalDatabase', 
        'Test-LSAlarm', 
        'Test-LSVpcPeered', 
        'Update-LSBucket', 
        'Update-LSBucketBundle', 
        'Update-LSContainerService', 
        'Update-LSDistribution', 
        'Update-LSDistributionBundle', 
        'Update-LSDomainEntry', 
        'Update-LSInstanceMetadataOption', 
        'Update-LSLoadBalancerAttribute', 
        'Update-LSRelationalDatabase', 
        'Update-LSRelationalDatabaseParameter')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Lightsail.dll-Help.xml'
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
