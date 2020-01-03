#
# Module manifest for module 'AWS.Tools.ApiGatewayV2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.ApiGatewayV2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '48ed9104-6399-47a1-9526-9270c827202a'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2020 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The ApiGatewayV2 module of AWS Tools for PowerShell lets developers and administrators manage Amazon API Gateway V2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.ApiGatewayV2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.ApiGatewayV2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.ApiGatewayV2.Completers.psm1',
        'AWS.Tools.ApiGatewayV2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-AG2ResourceTag', 
        'Get-AG2Api', 
        'Get-AG2ApiList', 
        'Get-AG2ApiMapping', 
        'Get-AG2ApiMappingList', 
        'Get-AG2Authorizer', 
        'Get-AG2AuthorizerList', 
        'Get-AG2Deployment', 
        'Get-AG2DeploymentList', 
        'Get-AG2DomainName', 
        'Get-AG2DomainNameList', 
        'Get-AG2Integration', 
        'Get-AG2IntegrationList', 
        'Get-AG2IntegrationResponse', 
        'Get-AG2IntegrationResponseList', 
        'Get-AG2Model', 
        'Get-AG2ModelList', 
        'Get-AG2ModelTemplate', 
        'Get-AG2Route', 
        'Get-AG2RouteList', 
        'Get-AG2RouteResponse', 
        'Get-AG2RouteResponseList', 
        'Get-AG2Stage', 
        'Get-AG2StageList', 
        'Get-AG2Tag', 
        'Import-AG2Api', 
        'New-AG2Api', 
        'New-AG2ApiMapping', 
        'New-AG2Authorizer', 
        'New-AG2Deployment', 
        'New-AG2DomainName', 
        'New-AG2Integration', 
        'New-AG2IntegrationResponse', 
        'New-AG2Model', 
        'New-AG2Route', 
        'New-AG2RouteResponse', 
        'New-AG2Stage', 
        'Remove-AG2Api', 
        'Remove-AG2ApiMapping', 
        'Remove-AG2Authorizer', 
        'Remove-AG2CorsConfiguration', 
        'Remove-AG2Deployment', 
        'Remove-AG2DomainName', 
        'Remove-AG2Integration', 
        'Remove-AG2IntegrationResponse', 
        'Remove-AG2Model', 
        'Remove-AG2ResourceTag', 
        'Remove-AG2Route', 
        'Remove-AG2RouteResponse', 
        'Remove-AG2RouteSetting', 
        'Remove-AG2Stage', 
        'Update-AG2Api', 
        'Update-AG2ApiImport', 
        'Update-AG2ApiMapping', 
        'Update-AG2Authorizer', 
        'Update-AG2Deployment', 
        'Update-AG2DomainName', 
        'Update-AG2Integration', 
        'Update-AG2IntegrationResponse', 
        'Update-AG2Model', 
        'Update-AG2Route', 
        'Update-AG2RouteResponse', 
        'Update-AG2Stage')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-AG2ApiLis')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.ApiGatewayV2.dll-Help.xml'
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
