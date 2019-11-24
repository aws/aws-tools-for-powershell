#
# Module manifest for module 'AWS.Tools.APIGateway'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.APIGateway.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'b0287c34-c969-44e0-b786-3ea8356c2934'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The APIGateway module of AWS Tools for PowerShell lets developers and administrators manage Amazon API Gateway from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.APIGateway.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.APIGateway.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.APIGateway.Completers.psm1',
        'AWS.Tools.APIGateway.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-AGResourceTag', 
        'Clear-AGStageAuthorizersCache', 
        'Clear-AGStageCache', 
        'Get-AGAccount', 
        'Get-AGApiKey', 
        'Get-AGApiKeyList', 
        'Get-AGAuthorizer', 
        'Get-AGAuthorizerList', 
        'Get-AGBasePathMapping', 
        'Get-AGBasePathMappingList', 
        'Get-AGClientCertificate', 
        'Get-AGClientCertificateList', 
        'Get-AGDeployment', 
        'Get-AGDeploymentList', 
        'Get-AGDocumentationPart', 
        'Get-AGDocumentationPartList', 
        'Get-AGDocumentationVersion', 
        'Get-AGDocumentationVersionList', 
        'Get-AGDomainName', 
        'Get-AGDomainNameList', 
        'Get-AGExport', 
        'Get-AGGatewayResponse', 
        'Get-AGGatewayResponseList', 
        'Get-AGIntegration', 
        'Get-AGIntegrationResponse', 
        'Get-AGMethod', 
        'Get-AGMethodResponse', 
        'Get-AGModel', 
        'Get-AGModelList', 
        'Get-AGModelTemplate', 
        'Get-AGRequestValidator', 
        'Get-AGResource', 
        'Get-AGResourceList', 
        'Get-AGResourceTag', 
        'Get-AGRestApi', 
        'Get-AGRestApiList', 
        'Get-AGSdk', 
        'Get-AGSdkType', 
        'Get-AGSdkTypeList', 
        'Get-AGStage', 
        'Get-AGStageList', 
        'Get-AGUsage', 
        'Get-AGUsagePlan', 
        'Get-AGUsagePlanKey', 
        'Get-AGUsagePlanKeyList', 
        'Get-AGUsagePlanList', 
        'Get-AGValidatorList', 
        'Get-AGVpcLink', 
        'Get-AGVpcLinkList', 
        'Import-AGApiKey', 
        'Import-AGDocumentationPartList', 
        'Import-AGRestApi', 
        'New-AGApiKey', 
        'New-AGAuthorizer', 
        'New-AGBasePathMapping', 
        'New-AGClientCertificate', 
        'New-AGDeployment', 
        'New-AGDocumentationPart', 
        'New-AGDocumentationVersion', 
        'New-AGDomainName', 
        'New-AGModel', 
        'New-AGRequestValidator', 
        'New-AGResource', 
        'New-AGRestApi', 
        'New-AGStage', 
        'New-AGUsagePlan', 
        'New-AGUsagePlanKey', 
        'New-AGVpcLink', 
        'Remove-AGApiKey', 
        'Remove-AGAuthorizer', 
        'Remove-AGBasePathMapping', 
        'Remove-AGClientCertificate', 
        'Remove-AGDeployment', 
        'Remove-AGDocumentationPart', 
        'Remove-AGDocumentationVersion', 
        'Remove-AGDomainName', 
        'Remove-AGGatewayResponse', 
        'Remove-AGIntegration', 
        'Remove-AGIntegrationResponse', 
        'Remove-AGMethod', 
        'Remove-AGMethodResponse', 
        'Remove-AGModel', 
        'Remove-AGRequestValidator', 
        'Remove-AGResource', 
        'Remove-AGResourceTag', 
        'Remove-AGRestApi', 
        'Remove-AGStage', 
        'Remove-AGUsagePlan', 
        'Remove-AGUsagePlanKey', 
        'Remove-AGVpcLink', 
        'Test-AGInvokeAuthorizer', 
        'Test-AGInvokeMethod', 
        'Update-AGAccount', 
        'Update-AGApiKey', 
        'Update-AGAuthorizer', 
        'Update-AGBasePathMapping', 
        'Update-AGClientCertificate', 
        'Update-AGDeployment', 
        'Update-AGDocumentationPart', 
        'Update-AGDocumentationVersion', 
        'Update-AGDomainName', 
        'Update-AGGatewayResponse', 
        'Update-AGIntegration', 
        'Update-AGIntegrationResponse', 
        'Update-AGMethod', 
        'Update-AGMethodResponse', 
        'Update-AGModel', 
        'Update-AGRequestValidator', 
        'Update-AGResource', 
        'Update-AGRestApi', 
        'Update-AGStage', 
        'Update-AGUsage', 
        'Update-AGUsagePlan', 
        'Update-AGVpcLink', 
        'Write-AGGatewayResponse', 
        'Write-AGIntegration', 
        'Write-AGIntegrationResponse', 
        'Write-AGMethod', 
        'Write-AGMethodResponse', 
        'Write-AGRestApi')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.APIGateway.dll-Help.xml'
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
