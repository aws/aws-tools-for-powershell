#
# Module manifest for module 'AWS.Tools.SimpleSystemsManagement'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.SimpleSystemsManagement.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'edb5d1c1-b090-47b3-a133-a36321592456'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The SimpleSystemsManagement module of AWS Tools for PowerShell lets developers and administrators manage AWS Systems Manager from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.SimpleSystemsManagement.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.SimpleSystemsManagement.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.SimpleSystemsManagement.Completers.psm1',
        'AWS.Tools.SimpleSystemsManagement.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-SSMResourceTag', 
        'Edit-SSMDocumentPermission', 
        'Get-SSMActivation', 
        'Get-SSMAssociation', 
        'Get-SSMAssociationExecution', 
        'Get-SSMAssociationExecutionTarget', 
        'Get-SSMAssociationList', 
        'Get-SSMAssociationVersionList', 
        'Get-SSMAutomationExecution', 
        'Get-SSMAutomationExecutionList', 
        'Get-SSMAutomationStepExecution', 
        'Get-SSMAvailablePatch', 
        'Get-SSMCommand', 
        'Get-SSMCommandInvocation', 
        'Get-SSMCommandInvocationDetail', 
        'Get-SSMComplianceItemList', 
        'Get-SSMComplianceSummaryList', 
        'Get-SSMConnectionStatus', 
        'Get-SSMDefaultPatchBaseline', 
        'Get-SSMDeployablePatchSnapshotForInstance', 
        'Get-SSMDocument', 
        'Get-SSMDocumentDescription', 
        'Get-SSMDocumentList', 
        'Get-SSMDocumentPermission', 
        'Get-SSMDocumentVersionList', 
        'Get-SSMEffectiveInstanceAssociationList', 
        'Get-SSMEffectivePatchesForPatchBaseline', 
        'Get-SSMInstanceAssociationsStatus', 
        'Get-SSMInstanceInformation', 
        'Get-SSMInstancePatch', 
        'Get-SSMInstancePatchState', 
        'Get-SSMInstancePatchStatesForPatchGroup', 
        'Get-SSMInventory', 
        'Get-SSMInventoryDeletionList', 
        'Get-SSMInventoryEntryList', 
        'Get-SSMInventorySchema', 
        'Get-SSMLatestEC2Image', 
        'Get-SSMMaintenanceWindow', 
        'Get-SSMMaintenanceWindowExecution', 
        'Get-SSMMaintenanceWindowExecutionList', 
        'Get-SSMMaintenanceWindowExecutionTask', 
        'Get-SSMMaintenanceWindowExecutionTaskInvocation', 
        'Get-SSMMaintenanceWindowExecutionTaskInvocationList', 
        'Get-SSMMaintenanceWindowExecutionTaskList', 
        'Get-SSMMaintenanceWindowList', 
        'Get-SSMMaintenanceWindowSchedule', 
        'Get-SSMMaintenanceWindowsForTarget', 
        'Get-SSMMaintenanceWindowTarget', 
        'Get-SSMMaintenanceWindowTask', 
        'Get-SSMMaintenanceWindowTaskList', 
        'Get-SSMOpsItem', 
        'Get-SSMOpsItemSummary', 
        'Get-SSMOpsSummary', 
        'Get-SSMParameter', 
        'Get-SSMParameterHistory', 
        'Get-SSMParameterList', 
        'Get-SSMParametersByPath', 
        'Get-SSMParameterValue', 
        'Get-SSMPatchBaseline', 
        'Get-SSMPatchBaselineDetail', 
        'Get-SSMPatchBaselineForPatchGroup', 
        'Get-SSMPatchGroup', 
        'Get-SSMPatchGroupState', 
        'Get-SSMPatchProperty', 
        'Get-SSMResourceComplianceSummaryList', 
        'Get-SSMResourceDataSync', 
        'Get-SSMResourceTag', 
        'Get-SSMServiceSetting', 
        'Get-SSMSession', 
        'New-SSMActivation', 
        'New-SSMAssociation', 
        'New-SSMAssociationFromBatch', 
        'New-SSMDocument', 
        'New-SSMMaintenanceWindow', 
        'New-SSMOpsItem', 
        'New-SSMPatchBaseline', 
        'New-SSMResourceDataSync', 
        'Register-SSMDefaultPatchBaseline', 
        'Register-SSMPatchBaselineForPatchGroup', 
        'Register-SSMTargetWithMaintenanceWindow', 
        'Register-SSMTaskWithMaintenanceWindow', 
        'Remove-SSMActivation', 
        'Remove-SSMAssociation', 
        'Remove-SSMDocument', 
        'Remove-SSMInventory', 
        'Remove-SSMMaintenanceWindow', 
        'Remove-SSMParameter', 
        'Remove-SSMParameterCollection', 
        'Remove-SSMPatchBaseline', 
        'Remove-SSMResourceDataSync', 
        'Remove-SSMResourceTag', 
        'Reset-SSMServiceSetting', 
        'Resume-SSMSession', 
        'Send-SSMAutomationSignal', 
        'Send-SSMCommand', 
        'Set-SSMParameterVersionLabel', 
        'Start-SSMAssociationsOnce', 
        'Start-SSMAutomationExecution', 
        'Start-SSMSession', 
        'Stop-SSMAutomationExecution', 
        'Stop-SSMCommand', 
        'Stop-SSMMaintenanceWindowExecution', 
        'Stop-SSMSession', 
        'Unregister-SSMManagedInstance', 
        'Unregister-SSMPatchBaselineForPatchGroup', 
        'Unregister-SSMTargetFromMaintenanceWindow', 
        'Unregister-SSMTaskFromMaintenanceWindow', 
        'Update-SSMAssociation', 
        'Update-SSMAssociationStatus', 
        'Update-SSMDocument', 
        'Update-SSMDocumentDefaultVersion', 
        'Update-SSMMaintenanceWindow', 
        'Update-SSMMaintenanceWindowTarget', 
        'Update-SSMMaintenanceWindowTask', 
        'Update-SSMManagedInstanceRole', 
        'Update-SSMOpsItem', 
        'Update-SSMPatchBaseline', 
        'Update-SSMResourceDataSync', 
        'Update-SSMServiceSetting', 
        'Write-SSMComplianceItem', 
        'Write-SSMInventory', 
        'Write-SSMParameter')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-SSMMaintenanceWindowTargets', 
        'Get-SSMParameterNameList', 
        'Get-SSMComplianceItemsList', 
        'Get-SSMComplianceSummariesList', 
        'Get-SSMInventoryEntriesList', 
        'Get-SSMResourceComplianceSummariesList')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.SimpleSystemsManagement.dll-Help.xml'
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
