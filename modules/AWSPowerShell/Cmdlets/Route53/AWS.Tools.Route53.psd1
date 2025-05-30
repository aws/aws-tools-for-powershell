#
# Module manifest for module 'AWS.Tools.Route53'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Route53.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'cb4f18e6-65c6-416a-9d13-9233b88c850b'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Route53 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Route 53 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Route53.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Route53.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Route53.Completers.psm1',
        'AWS.Tools.Route53.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Disable-R53HostedZoneDNSSEC', 
        'Disable-R53KeySigningKey', 
        'Edit-R53CidrCollection', 
        'Edit-R53ResourceRecordSet', 
        'Edit-R53TagsForResource', 
        'Enable-R53HostedZoneDNSSEC', 
        'Enable-R53KeySigningKey', 
        'Get-R53AccountLimit', 
        'Get-R53Change', 
        'Get-R53CheckerIpRange', 
        'Get-R53CidrBlockList', 
        'Get-R53CidrCollectionList', 
        'Get-R53CidrLocationList', 
        'Get-R53DNSSEC', 
        'Get-R53GeoLocation', 
        'Get-R53GeoLocationList', 
        'Get-R53HealthCheck', 
        'Get-R53HealthCheckCount', 
        'Get-R53HealthCheckLastFailureReason', 
        'Get-R53HealthCheckList', 
        'Get-R53HealthCheckStatus', 
        'Get-R53HostedZone', 
        'Get-R53HostedZoneCount', 
        'Get-R53HostedZoneLimit', 
        'Get-R53HostedZoneList', 
        'Get-R53HostedZonesByName', 
        'Get-R53HostedZonesByVPC', 
        'Get-R53QueryLoggingConfig', 
        'Get-R53QueryLoggingConfigList', 
        'Get-R53ResourceRecordSet', 
        'Get-R53ReusableDelegationSet', 
        'Get-R53ReusableDelegationSetLimit', 
        'Get-R53ReusableDelegationSetList', 
        'Get-R53TagsForResource', 
        'Get-R53TagsForResourceList', 
        'Get-R53TrafficPolicy', 
        'Get-R53TrafficPolicyInstance', 
        'Get-R53TrafficPolicyInstanceCount', 
        'Get-R53TrafficPolicyInstanceList', 
        'Get-R53TrafficPolicyInstancesByHostedZone', 
        'Get-R53TrafficPolicyInstancesByPolicy', 
        'Get-R53TrafficPolicyList', 
        'Get-R53TrafficPolicyVersionList', 
        'Get-R53VPCAssociationAuthorizationList', 
        'New-R53CidrCollection', 
        'New-R53HealthCheck', 
        'New-R53HostedZone', 
        'New-R53KeySigningKey', 
        'New-R53QueryLoggingConfig', 
        'New-R53ReusableDelegationSet', 
        'New-R53TrafficPolicy', 
        'New-R53TrafficPolicyInstance', 
        'New-R53TrafficPolicyVersion', 
        'New-R53VPCAssociationAuthorization', 
        'Register-R53VPCWithHostedZone', 
        'Remove-R53CidrCollection', 
        'Remove-R53HealthCheck', 
        'Remove-R53HostedZone', 
        'Remove-R53KeySigningKey', 
        'Remove-R53QueryLoggingConfig', 
        'Remove-R53ReusableDelegationSet', 
        'Remove-R53TrafficPolicy', 
        'Remove-R53TrafficPolicyInstance', 
        'Remove-R53VPCAssociationAuthorization', 
        'Test-R53DNSAnswer', 
        'Unregister-R53VPCFromHostedZone', 
        'Update-R53HealthCheck', 
        'Update-R53HostedZoneComment', 
        'Update-R53TrafficPolicyComment', 
        'Update-R53TrafficPolicyInstance')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-R53CheckerIpRanges', 
        'Get-R53GeoLocations', 
        'Get-R53HealthChecks', 
        'Get-R53HostedZones', 
        'Get-R53ReusableDelegationSets', 
        'Get-R53TagsForResources', 
        'Get-R53TrafficPolicies', 
        'Get-R53TrafficPolicyInstances', 
        'Get-R53TrafficPolicyVersions')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Route53.dll-Help.xml'
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
