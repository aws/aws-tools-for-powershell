#
# Module manifest for module 'AWS.Tools.Kendra'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Kendra.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '7dc1021b-517a-45a9-98c7-058586daa566'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Kendra module of AWS Tools for PowerShell lets developers and administrators manage Amazon Kendra from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.Kendra.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Kendra.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Kendra.Completers.psm1',
        'AWS.Tools.Kendra.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-KNDREntitiesToExperience', 
        'Add-KNDRPersonasToEntity', 
        'Add-KNDRResourceTag', 
        'Clear-KNDRQuerySuggestion', 
        'Get-KNDRAccessControlConfiguration', 
        'Get-KNDRAccessControlConfigurationList', 
        'Get-KNDRDataSource', 
        'Get-KNDRDataSourceList', 
        'Get-KNDRDataSourceSyncJobList', 
        'Get-KNDREntityPersonaList', 
        'Get-KNDRExperience', 
        'Get-KNDRExperienceEntityList', 
        'Get-KNDRExperienceList', 
        'Get-KNDRFaq', 
        'Get-KNDRFaqList', 
        'Get-KNDRFeaturedResultsSet', 
        'Get-KNDRFeaturedResultsSetList', 
        'Get-KNDRGetDocumentStatus', 
        'Get-KNDRGroupsOlderThanOrderingIdList', 
        'Get-KNDRIndex', 
        'Get-KNDRIndexList', 
        'Get-KNDRPrincipalMapping', 
        'Get-KNDRQuerySuggestion', 
        'Get-KNDRQuerySuggestionsBlockList', 
        'Get-KNDRQuerySuggestionsBlockListList', 
        'Get-KNDRQuerySuggestionsConfig', 
        'Get-KNDRResourceTag', 
        'Get-KNDRSnapshot', 
        'Get-KNDRThesauriList', 
        'Get-KNDRThesaurus', 
        'Invoke-KNDRQuery', 
        'Invoke-KNDRRetrieve', 
        'New-KNDRAccessControlConfiguration', 
        'New-KNDRDataSource', 
        'New-KNDRExperience', 
        'New-KNDRFaq', 
        'New-KNDRFeaturedResultsSet', 
        'New-KNDRIndex', 
        'New-KNDRQuerySuggestionsBlockList', 
        'New-KNDRThesaurus', 
        'Remove-KNDRAccessControlConfiguration', 
        'Remove-KNDRDataSource', 
        'Remove-KNDRDocumentBatch', 
        'Remove-KNDREntitiesFromExperience', 
        'Remove-KNDRExperience', 
        'Remove-KNDRFaq', 
        'Remove-KNDRFeaturedResultsSetBatch', 
        'Remove-KNDRIndex', 
        'Remove-KNDRPersonasFromEntity', 
        'Remove-KNDRPrincipalMapping', 
        'Remove-KNDRQuerySuggestionsBlockList', 
        'Remove-KNDRResourceTag', 
        'Remove-KNDRThesaurus', 
        'Send-KNDRFeedback', 
        'Start-KNDRDataSourceSyncJob', 
        'Stop-KNDRDataSourceSyncJob', 
        'Update-KNDRAccessControlConfiguration', 
        'Update-KNDRDataSource', 
        'Update-KNDRExperience', 
        'Update-KNDRFeaturedResultsSet', 
        'Update-KNDRIndex', 
        'Update-KNDRQuerySuggestionsBlockList', 
        'Update-KNDRQuerySuggestionsConfig', 
        'Update-KNDRThesaurus', 
        'Write-KNDRDocumentBatch', 
        'Write-KNDRPrincipalMapping')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Kendra.dll-Help.xml'
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
