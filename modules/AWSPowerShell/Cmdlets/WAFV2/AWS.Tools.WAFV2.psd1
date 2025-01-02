#
# Module manifest for module 'AWS.Tools.WAFV2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.WAFV2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '75aed10a-77f8-4140-868d-919d54288678'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The WAFV2 module of AWS Tools for PowerShell lets developers and administrators manage AWS WAF V2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.WAFV2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.WAFV2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.WAFV2.Completers.psm1',
        'AWS.Tools.WAFV2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-WAF2ResourceTag', 
        'Add-WAF2WebACLToResource', 
        'Get-WAF2AllManagedProduct', 
        'Get-WAF2APIKeyList', 
        'Get-WAF2AvailableManagedRuleGroupList', 
        'Get-WAF2AvailableManagedRuleGroupVersionList', 
        'Get-WAF2DecryptedAPIKey', 
        'Get-WAF2IPSet', 
        'Get-WAF2IPSetList', 
        'Get-WAF2LoggingConfiguration', 
        'Get-WAF2LoggingConfigurationList', 
        'Get-WAF2ManagedProductsByVendor', 
        'Get-WAF2ManagedRuleGroup', 
        'Get-WAF2ManagedRuleSet', 
        'Get-WAF2ManagedRuleSetList', 
        'Get-WAF2MobileSdkRelease', 
        'Get-WAF2MobileSdkReleaseList', 
        'Get-WAF2PermissionPolicy', 
        'Get-WAF2RateBasedStatementManagedKey', 
        'Get-WAF2RegexPatternSet', 
        'Get-WAF2RegexPatternSetList', 
        'Get-WAF2ResourcesForWebACLList', 
        'Get-WAF2ResourceTag', 
        'Get-WAF2RuleGroup', 
        'Get-WAF2RuleGroupList', 
        'Get-WAF2SampledRequest', 
        'Get-WAF2WebACL', 
        'Get-WAF2WebACLForResource', 
        'Get-WAF2WebACLsList', 
        'New-WAF2APIKey', 
        'New-WAF2IPSet', 
        'New-WAF2MobileSdkReleaseUrl', 
        'New-WAF2RegexPatternSet', 
        'New-WAF2RuleGroup', 
        'New-WAF2WebACL', 
        'Remove-WAF2APIKey', 
        'Remove-WAF2FirewallManagerRuleGroup', 
        'Remove-WAF2IPSet', 
        'Remove-WAF2LoggingConfiguration', 
        'Remove-WAF2PermissionPolicy', 
        'Remove-WAF2RegexPatternSet', 
        'Remove-WAF2ResourceTag', 
        'Remove-WAF2RuleGroup', 
        'Remove-WAF2WebACL', 
        'Remove-WAF2WebACLFromResource', 
        'Test-WAF2Capacity', 
        'Update-WAF2IPSet', 
        'Update-WAF2ManagedRuleSetVersionExpiryDate', 
        'Update-WAF2RegexPatternSet', 
        'Update-WAF2RuleGroup', 
        'Update-WAF2WebACL', 
        'Write-WAF2LoggingConfiguration', 
        'Write-WAF2ManagedRuleSetVersion', 
        'Write-WAF2PermissionPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.WAFV2.dll-Help.xml'
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
