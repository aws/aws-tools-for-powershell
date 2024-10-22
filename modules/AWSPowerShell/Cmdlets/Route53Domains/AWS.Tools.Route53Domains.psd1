#
# Module manifest for module 'AWS.Tools.Route53Domains'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Route53Domains.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'c0474a09-7b41-457a-8291-e1cb9b87b7b3'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Route53Domains module of AWS Tools for PowerShell lets developers and administrators manage Amazon Route 53 Domains from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Route53Domains.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Route53Domains.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Route53Domains.Completers.psm1',
        'AWS.Tools.Route53Domains.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-R53DDelegationSignerToDomain', 
        'Approve-R53DDomainTransferFromAnotherAwsAccount', 
        'Deny-R53DDomainTransferFromAnotherAwsAccount', 
        'Disable-R53DDomainAutoRenew', 
        'Disable-R53DDomainTransferLock', 
        'Enable-R53DDomainAutoRenew', 
        'Enable-R53DDomainTransferLock', 
        'Get-R53DBillingRecord', 
        'Get-R53DContactReachabilityStatus', 
        'Get-R53DDomainAuthCode', 
        'Get-R53DDomainDetail', 
        'Get-R53DDomainList', 
        'Get-R53DDomainSuggestion', 
        'Get-R53DOperationDetail', 
        'Get-R53DOperationList', 
        'Get-R53DPriceList', 
        'Get-R53DTagsForDomain', 
        'Invoke-R53DDomainTransfer', 
        'Move-R53DDomainToAnotherAwsAccount', 
        'Push-R53DDomain', 
        'Register-R53DDomain', 
        'Remove-R53DDelegationSignerFromDomain', 
        'Remove-R53DDomain', 
        'Remove-R53DTagsForDomain', 
        'Send-R53DContactReachabilityEmail', 
        'Send-R53DOperationAuthorization', 
        'Stop-R53DDomainTransferToAnotherAwsAccount', 
        'Test-R53DDomainAvailability', 
        'Test-R53DDomainTransferability', 
        'Update-R53DDomainContact', 
        'Update-R53DDomainContactPrivacy', 
        'Update-R53DDomainNameserver', 
        'Update-R53DDomainRenewal', 
        'Update-R53DTagsForDomain')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-R53DDomainAvailability', 
        'Get-R53DDomains', 
        'Get-R53DOperations', 
        'Update-R53DDomainNameservers')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Route53Domains.dll-Help.xml'
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
