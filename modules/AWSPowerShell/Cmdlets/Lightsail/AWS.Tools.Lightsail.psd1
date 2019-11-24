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
    Copyright = 'Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

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
        'Add-LSDisk', 
        'Add-LSInstancesToLoadBalancer', 
        'Add-LSLoadBalancerTlsCertificate', 
        'Add-LSPeerVpc', 
        'Add-LSResourceTag', 
        'Close-LSInstancePublicPort', 
        'Copy-LSSnapshot', 
        'Disable-LSAddOn', 
        'Dismount-LSDisk', 
        'Dismount-LSInstancesFromLoadBalancer', 
        'Dismount-LSStaticIp', 
        'Enable-LSAddOn', 
        'Export-LSSnapshot', 
        'Get-LSActiveNameList', 
        'Get-LSAutoSnapshot', 
        'Get-LSBlueprintList', 
        'Get-LSBundleList', 
        'Get-LSCloudFormationStackRecord', 
        'Get-LSDisk', 
        'Get-LSDiskList', 
        'Get-LSDiskSnapshot', 
        'Get-LSDiskSnapshotList', 
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
        'Get-LSStaticIp', 
        'Get-LSStaticIpList', 
        'Import-LSKeyPair', 
        'Mount-LSStaticIp', 
        'New-LSCloudFormationStack', 
        'New-LSDisk', 
        'New-LSDiskFromSnapshot', 
        'New-LSDiskSnapshot', 
        'New-LSDomain', 
        'New-LSDomainEntry', 
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
        'Remove-LSAutoSnapshot', 
        'Remove-LSDisk', 
        'Remove-LSDiskSnapshot', 
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
        'Restart-LSInstance', 
        'Restart-LSRelationalDatabase', 
        'Set-LSInstancePublicPort', 
        'Start-LSInstance', 
        'Start-LSRelationalDatabase', 
        'Stop-LSInstance', 
        'Stop-LSRelationalDatabase', 
        'Test-LSVpcPeered', 
        'Update-LSDomainEntry', 
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
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md'
        }
    }
}
