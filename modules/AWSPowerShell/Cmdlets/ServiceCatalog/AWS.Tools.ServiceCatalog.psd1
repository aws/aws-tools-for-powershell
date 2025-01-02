#
# Module manifest for module 'AWS.Tools.ServiceCatalog'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.ServiceCatalog.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'f9e1f392-c3e6-44f4-9c61-998046483892'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The ServiceCatalog module of AWS Tools for PowerShell lets developers and administrators manage AWS Service Catalog from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.ServiceCatalog.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.ServiceCatalog.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.ServiceCatalog.Completers.psm1',
        'AWS.Tools.ServiceCatalog.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SCServiceActionAssociationWithProvisioningArtifact', 
        'Add-SCServiceActionAssociationWithProvisioningArtifactBatch', 
        'Add-SCTagOptionToResource', 
        'Copy-SCProduct', 
        'Deny-SCPortfolioShare', 
        'Disable-SCAWSOrganizationsAccess', 
        'Enable-SCAWSOrganizationsAccess', 
        'Find-SCProduct', 
        'Find-SCProductsAsAdmin', 
        'Find-SCProvisionedProduct', 
        'Get-SCAcceptedPortfolioShareList', 
        'Get-SCAWSOrganizationsAccessStatus', 
        'Get-SCBudgetsForResource', 
        'Get-SCConstrainsForPortfolioList', 
        'Get-SCConstraint', 
        'Get-SCCopyProductStatus', 
        'Get-SCLaunchPath', 
        'Get-SCOrganizationPortfolioAccessList', 
        'Get-SCPortfolio', 
        'Get-SCPortfolioAccessList', 
        'Get-SCPortfolioList', 
        'Get-SCPortfolioShare', 
        'Get-SCPortfolioShareStatus', 
        'Get-SCPrincipalsForPortfolio', 
        'Get-SCProduct', 
        'Get-SCProductAsAdmin', 
        'Get-SCProductPortfolioList', 
        'Get-SCProductView', 
        'Get-SCProvisionedProduct', 
        'Get-SCProvisionedProductDetail', 
        'Get-SCProvisionedProductOutput', 
        'Get-SCProvisionedProductPlan', 
        'Get-SCProvisionedProductPlanList', 
        'Get-SCProvisioningArtifact', 
        'Get-SCProvisioningArtifactList', 
        'Get-SCProvisioningArtifactsForServiceActionList', 
        'Get-SCProvisioningParameter', 
        'Get-SCRecord', 
        'Get-SCRecordHistory', 
        'Get-SCResourcesForTagOption', 
        'Get-SCServiceAction', 
        'Get-SCServiceActionExecutionParameter', 
        'Get-SCServiceActionList', 
        'Get-SCServiceActionsForProvisioningArtifactList', 
        'Get-SCStackInstancesForProvisionedProduct', 
        'Get-SCTagOption', 
        'Get-SCTagOptionList', 
        'Import-SCAsProvisionedProduct', 
        'New-SCConstraint', 
        'New-SCPortfolio', 
        'New-SCPortfolioShare', 
        'New-SCProduct', 
        'New-SCProvisionedProduct', 
        'New-SCProvisionedProductPlan', 
        'New-SCProvisioningArtifact', 
        'New-SCServiceAction', 
        'New-SCTagOption', 
        'Receive-SCPortfolioShare', 
        'Register-SCBudgetWithResource', 
        'Register-SCPrincipalWithPortfolio', 
        'Register-SCProductWithPortfolio', 
        'Remove-SCConstraint', 
        'Remove-SCPortfolio', 
        'Remove-SCPortfolioShare', 
        'Remove-SCProduct', 
        'Remove-SCProvisionedProduct', 
        'Remove-SCProvisionedProductPlan', 
        'Remove-SCProvisioningArtifact', 
        'Remove-SCServiceAction', 
        'Remove-SCServiceActionAssociationFromProvisioningArtifact', 
        'Remove-SCServiceActionAssociationFromProvisioningArtifactBatch', 
        'Remove-SCTagOption', 
        'Remove-SCTagOptionFromResource', 
        'Start-SCProvisionedProductPlanExecution', 
        'Start-SCProvisionedProductServiceActionExecution', 
        'Start-SCProvisionProductEngineWorkflowResult', 
        'Start-SCTerminateProvisionedProductEngineWorkflowResult', 
        'Start-SCUpdateProvisionedProductEngineWorkflowResult', 
        'Unregister-SCBudgetFromResource', 
        'Unregister-SCPrincipalFromPortfolio', 
        'Unregister-SCProductFromPortfolio', 
        'Update-SCConstraint', 
        'Update-SCPortfolio', 
        'Update-SCPortfolioShare', 
        'Update-SCProduct', 
        'Update-SCProvisionedProduct', 
        'Update-SCProvisionedProductProperty', 
        'Update-SCProvisioningArtifact', 
        'Update-SCServiceAction', 
        'Update-SCTagOption')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-SCAcceptedPortfolioSharesList', 
        'Get-SCProductPortfoliosList')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.ServiceCatalog.dll-Help.xml'
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
