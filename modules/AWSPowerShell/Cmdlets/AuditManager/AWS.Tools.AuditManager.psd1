#
# Module manifest for module 'AWS.Tools.AuditManager'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.AuditManager.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'BCDC0213-2FDC-4B58-9EDF-DB2C3DBFDBF1'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The AuditManager module of AWS Tools for PowerShell lets developers and administrators manage AWS Audit Manager from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.AuditManager.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.AuditManager.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.AuditManager.Completers.psm1',
        'AWS.Tools.AuditManager.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-AUDMAssessmentReportEvidence', 
        'Add-AUDMAssessmentReportEvidenceFolder', 
        'Add-AUDMEvidenceToAssessmentControl', 
        'Add-AUDMResourceTag', 
        'Confirm-AUDMAssessmentReportIntegrity', 
        'Edit-AUDMAssessment', 
        'Edit-AUDMAssessmentControl', 
        'Edit-AUDMAssessmentControlSetStatus', 
        'Edit-AUDMAssessmentFramework', 
        'Edit-AUDMAssessmentStatus', 
        'Edit-AUDMControl', 
        'Edit-AUDMSetting', 
        'Get-AUDMAccountStatus', 
        'Get-AUDMAssessment', 
        'Get-AUDMAssessmentControlInsightsByControlDomainList', 
        'Get-AUDMAssessmentFramework', 
        'Get-AUDMAssessmentFrameworkList', 
        'Get-AUDMAssessmentFrameworkShareRequestList', 
        'Get-AUDMAssessmentList', 
        'Get-AUDMAssessmentReportList', 
        'Get-AUDMAssessmentReportUrl', 
        'Get-AUDMChangeLog', 
        'Get-AUDMControl', 
        'Get-AUDMControlDomainInsightList', 
        'Get-AUDMControlDomainInsightsByAssessmentList', 
        'Get-AUDMControlInsightsByControlDomainList', 
        'Get-AUDMControlList', 
        'Get-AUDMDelegation', 
        'Get-AUDMEvidence', 
        'Get-AUDMEvidenceByEvidenceFolder', 
        'Get-AUDMEvidenceFileUploadUrl', 
        'Get-AUDMEvidenceFolder', 
        'Get-AUDMEvidenceFolderByAssessment', 
        'Get-AUDMEvidenceFolderByAssessmentControl', 
        'Get-AUDMInsight', 
        'Get-AUDMInsightsByAssessment', 
        'Get-AUDMKeywordForDataSourceList', 
        'Get-AUDMNotificationList', 
        'Get-AUDMOrganizationAdminAccount', 
        'Get-AUDMResourceTagList', 
        'Get-AUDMServiceInScope', 
        'Get-AUDMSetting', 
        'New-AUDMAssessment', 
        'New-AUDMAssessmentFramework', 
        'New-AUDMAssessmentReport', 
        'New-AUDMControl', 
        'New-AUDMCreateDelegationByAssessment', 
        'Register-AUDMAccount', 
        'Register-AUDMOrganizationAdminAccount', 
        'Remove-AUDMAssessment', 
        'Remove-AUDMAssessmentFramework', 
        'Remove-AUDMAssessmentFrameworkShare', 
        'Remove-AUDMAssessmentReport', 
        'Remove-AUDMAssessmentReportEvidence', 
        'Remove-AUDMAssessmentReportEvidenceFolder', 
        'Remove-AUDMControl', 
        'Remove-AUDMDelegationByAssessment', 
        'Remove-AUDMResourceTag', 
        'Start-AUDMAssessmentFrameworkShare', 
        'Unregister-AUDMAccount', 
        'Unregister-AUDMOrganizationAdminAccount', 
        'Update-AUDMAssessmentFrameworkShare')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.AuditManager.dll-Help.xml'
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
