#
# Module manifest for module 'AWS.Tools.Route53Resolver'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Route53Resolver.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'f660ee15-58dd-45a7-ad54-3eaac2ad7e46'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Route53Resolver module of AWS Tools for PowerShell lets developers and administrators manage Amazon Route 53 Resolver from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Route53Resolver.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Route53Resolver.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Route53Resolver.Completers.psm1',
        'AWS.Tools.Route53Resolver.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-R53RResolverEndpointIpAddressAssociation', 
        'Add-R53RResolverQueryLogConfigAssociation', 
        'Add-R53RResolverRuleAssociation', 
        'Add-R53RResourceTag', 
        'Edit-R53RFirewallConfig', 
        'Edit-R53RFirewallDomain', 
        'Edit-R53RFirewallRule', 
        'Edit-R53RFirewallRuleGroupAssociation', 
        'Edit-R53RFirewallRuleGroupPolicy', 
        'Get-R53RFirewallConfig', 
        'Get-R53RFirewallConfigList', 
        'Get-R53RFirewallDomain', 
        'Get-R53RFirewallDomainList', 
        'Get-R53RFirewallDomainListList', 
        'Get-R53RFirewallRuleGroup', 
        'Get-R53RFirewallRuleGroupAssociation', 
        'Get-R53RFirewallRuleGroupAssociationList', 
        'Get-R53RFirewallRuleGroupList', 
        'Get-R53RFirewallRuleGroupPolicy', 
        'Get-R53RFirewallRuleList', 
        'Get-R53ROutpostResolver', 
        'Get-R53ROutpostResolverList', 
        'Get-R53RResolverConfig', 
        'Get-R53RResolverConfigList', 
        'Get-R53RResolverDnssecConfig', 
        'Get-R53RResolverDnssecConfigList', 
        'Get-R53RResolverEndpoint', 
        'Get-R53RResolverEndpointIpAddressList', 
        'Get-R53RResolverEndpointList', 
        'Get-R53RResolverQueryLogConfig', 
        'Get-R53RResolverQueryLogConfigAssociation', 
        'Get-R53RResolverQueryLogConfigAssociationList', 
        'Get-R53RResolverQueryLogConfigList', 
        'Get-R53RResolverQueryLogConfigPolicy', 
        'Get-R53RResolverRule', 
        'Get-R53RResolverRuleAssociation', 
        'Get-R53RResolverRuleAssociationList', 
        'Get-R53RResolverRuleList', 
        'Get-R53RResolverRulePolicy', 
        'Get-R53RResourceTagList', 
        'Import-R53RFirewallDomainList', 
        'New-R53RFirewallDomainList', 
        'New-R53RFirewallRule', 
        'New-R53RFirewallRuleGroup', 
        'New-R53RFirewallRuleGroupAssociation', 
        'New-R53ROutpostResolver', 
        'New-R53RResolverEndpoint', 
        'New-R53RResolverQueryLogConfig', 
        'New-R53RResolverRule', 
        'Remove-R53RFirewallDomainList', 
        'Remove-R53RFirewallRule', 
        'Remove-R53RFirewallRuleGroup', 
        'Remove-R53RFirewallRuleGroupAssociation', 
        'Remove-R53ROutpostResolver', 
        'Remove-R53RResolverEndpoint', 
        'Remove-R53RResolverEndpointIpAddressAssociation', 
        'Remove-R53RResolverQueryLogConfig', 
        'Remove-R53RResolverQueryLogConfigAssociation', 
        'Remove-R53RResolverRule', 
        'Remove-R53RResolverRuleAssociation', 
        'Remove-R53RResourceTag', 
        'Set-R53RResolverRulePolicy', 
        'Update-R53ROutpostResolver', 
        'Update-R53RResolverConfig', 
        'Update-R53RResolverDnssecConfig', 
        'Update-R53RResolverEndpoint', 
        'Update-R53RResolverRule', 
        'Write-R53RResolverQueryLogConfigPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Route53Resolver.dll-Help.xml'
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
