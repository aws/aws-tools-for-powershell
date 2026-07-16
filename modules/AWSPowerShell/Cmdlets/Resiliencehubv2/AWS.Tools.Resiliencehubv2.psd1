#
# Module manifest for module 'AWS.Tools.Resiliencehubv2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.Resiliencehubv2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'ae22292e-63e4-470e-829c-75c18ed212d8'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The Resiliencehubv2 module of AWS Tools for PowerShell lets developers and administrators manage AWS Resilience Hub V2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }    )

# Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.Resiliencehubv2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.Resiliencehubv2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.Resiliencehubv2.Completers.psm1',
        'AWS.Tools.Resiliencehubv2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-RH2ResourceTag', 
        'Get-RH2AssertionList', 
        'Get-RH2DependencyList', 
        'Get-RH2FailureModeAssessmentList', 
        'Get-RH2FailureModeFinding', 
        'Get-RH2FailureModeFindingList', 
        'Get-RH2InputSourceList', 
        'Get-RH2Policy', 
        'Get-RH2PolicyList', 
        'Get-RH2ReportList', 
        'Get-RH2ResourceList', 
        'Get-RH2ResourceTag', 
        'Get-RH2Service', 
        'Get-RH2ServiceEventList', 
        'Get-RH2ServiceFunctionList', 
        'Get-RH2ServiceList', 
        'Get-RH2ServiceTopologyEdgeList', 
        'Get-RH2System', 
        'Get-RH2SystemEventList', 
        'Get-RH2SystemList', 
        'Get-RH2UserJourney', 
        'Get-RH2UserJourneyList', 
        'Import-RH2App', 
        'Import-RH2Policy', 
        'New-RH2Assertion', 
        'New-RH2InputSource', 
        'New-RH2Policy', 
        'New-RH2Report', 
        'New-RH2Service', 
        'New-RH2ServiceFunction', 
        'New-RH2ServiceFunctionResource', 
        'New-RH2System', 
        'New-RH2UserJourney', 
        'Remove-RH2Assertion', 
        'Remove-RH2InputSource', 
        'Remove-RH2Policy', 
        'Remove-RH2ResourceTag', 
        'Remove-RH2Service', 
        'Remove-RH2ServiceFunction', 
        'Remove-RH2ServiceFunctionResource', 
        'Remove-RH2System', 
        'Remove-RH2UserJourney', 
        'Start-RH2FailureModeAssessment', 
        'Update-RH2Assertion', 
        'Update-RH2Dependency', 
        'Update-RH2FailureModeFinding', 
        'Update-RH2Policy', 
        'Update-RH2Service', 
        'Update-RH2ServiceFunction', 
        'Update-RH2System', 
        'Update-RH2UserJourney')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.Resiliencehubv2.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/main/CHANGELOG.md'
        }
    }
}
