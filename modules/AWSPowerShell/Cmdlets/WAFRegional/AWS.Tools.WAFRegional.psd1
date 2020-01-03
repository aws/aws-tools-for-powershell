#
# Module manifest for module 'AWS.Tools.WAFRegional'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.WAFRegional.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'a4195c43-7f7c-4448-ad18-56b0d7988aea'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2020 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The WAFRegional module of AWS Tools for PowerShell lets developers and administrators manage AWS WAF Regional from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.WAFRegional.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.WAFRegional.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.WAFRegional.Completers.psm1',
        'AWS.Tools.WAFRegional.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-WAFRResourceTag', 
        'Get-WAFRActivatedRulesInRuleGroupList', 
        'Get-WAFRByteMatchSet', 
        'Get-WAFRByteMatchSetList', 
        'Get-WAFRChangeToken', 
        'Get-WAFRChangeTokenStatus', 
        'Get-WAFRGeoMatchSet', 
        'Get-WAFRGeoMatchSetList', 
        'Get-WAFRIPSet', 
        'Get-WAFRIPSetList', 
        'Get-WAFRLoggingConfiguration', 
        'Get-WAFRLoggingConfigurationList', 
        'Get-WAFRPermissionPolicy', 
        'Get-WAFRRateBasedRule', 
        'Get-WAFRRateBasedRuleList', 
        'Get-WAFRRateBasedRuleManagedKey', 
        'Get-WAFRRegexMatchSet', 
        'Get-WAFRRegexMatchSetList', 
        'Get-WAFRRegexPatternSet', 
        'Get-WAFRRegexPatternSetList', 
        'Get-WAFRResourceForWebACLList', 
        'Get-WAFRResourceTag', 
        'Get-WAFRRule', 
        'Get-WAFRRuleGroup', 
        'Get-WAFRRuleGroupList', 
        'Get-WAFRRuleList', 
        'Get-WAFRSampledRequestList', 
        'Get-WAFRSizeConstraintSet', 
        'Get-WAFRSizeConstraintSetList', 
        'Get-WAFRSqlInjectionMatchSet', 
        'Get-WAFRSqlInjectionMatchSetList', 
        'Get-WAFRSubscribedRuleGroup', 
        'Get-WAFRWebACL', 
        'Get-WAFRWebACLForResource', 
        'Get-WAFRWebACLList', 
        'Get-WAFRXssMatchSet', 
        'Get-WAFRXssMatchSetList', 
        'New-WAFRByteMatchSet', 
        'New-WAFRGeoMatchSet', 
        'New-WAFRIPSet', 
        'New-WAFRRateBasedRule', 
        'New-WAFRRegexMatchSet', 
        'New-WAFRRegexPatternSet', 
        'New-WAFRRule', 
        'New-WAFRRuleGroup', 
        'New-WAFRSizeConstraintSet', 
        'New-WAFRSqlInjectionMatchSet', 
        'New-WAFRWebACL', 
        'New-WAFRXssMatchSet', 
        'Register-WAFRWebACL', 
        'Remove-WAFRByteMatchSet', 
        'Remove-WAFRGeoMatchSet', 
        'Remove-WAFRIPSet', 
        'Remove-WAFRLoggingConfiguration', 
        'Remove-WAFRPermissionPolicy', 
        'Remove-WAFRRateBasedRule', 
        'Remove-WAFRRegexMatchSet', 
        'Remove-WAFRRegexPatternSet', 
        'Remove-WAFRResourceTag', 
        'Remove-WAFRRule', 
        'Remove-WAFRRuleGroup', 
        'Remove-WAFRSizeConstraintSet', 
        'Remove-WAFRSqlInjectionMatchSet', 
        'Remove-WAFRWebACL', 
        'Remove-WAFRXssMatchSet', 
        'Unregister-WAFRWebACL', 
        'Update-WAFRByteMatchSet', 
        'Update-WAFRGeoMatchSet', 
        'Update-WAFRIPSet', 
        'Update-WAFRRateBasedRule', 
        'Update-WAFRRegexMatchSet', 
        'Update-WAFRRegexPatternSet', 
        'Update-WAFRRule', 
        'Update-WAFRRuleGroup', 
        'Update-WAFRSizeConstraintSet', 
        'Update-WAFRSqlInjectionMatchSet', 
        'Update-WAFRWebACL', 
        'Update-WAFRXssMatchSet', 
        'Write-WAFRLoggingConfiguration', 
        'Write-WAFRPermissionPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.WAFRegional.dll-Help.xml'
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
