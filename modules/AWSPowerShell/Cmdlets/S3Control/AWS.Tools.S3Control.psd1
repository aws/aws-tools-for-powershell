#
# Module manifest for module 'AWS.Tools.S3Control'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.S3Control.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'a5a855ad-2fc3-44d4-ac47-e2fac3bfc0b3'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2025 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The S3Control module of AWS Tools for PowerShell lets developers and administrators manage Amazon S3 Control from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.S3Control.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.S3Control.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.S3Control.Completers.psm1',
        'AWS.Tools.S3Control.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-S3CJobTagging', 
        'Add-S3CPublicAccessBlock', 
        'Add-S3CResourceTag', 
        'Connect-S3CAccessGrantsIdentityCenter', 
        'Disconnect-S3CAccessGrantsIdentityCenter', 
        'Get-S3CAccessGrant', 
        'Get-S3CAccessGrantList', 
        'Get-S3CAccessGrantsInstance', 
        'Get-S3CAccessGrantsInstanceForPrefix', 
        'Get-S3CAccessGrantsInstanceList', 
        'Get-S3CAccessGrantsInstanceResourcePolicy', 
        'Get-S3CAccessGrantsLocation', 
        'Get-S3CAccessGrantsLocationList', 
        'Get-S3CAccessPoint', 
        'Get-S3CAccessPointConfigurationForObjectLambda', 
        'Get-S3CAccessPointForObjectLambda', 
        'Get-S3CAccessPointList', 
        'Get-S3CAccessPointPolicy', 
        'Get-S3CAccessPointPolicyForObjectLambda', 
        'Get-S3CAccessPointPolicyStatus', 
        'Get-S3CAccessPointPolicyStatusForObjectLambda', 
        'Get-S3CAccessPointsForObjectLambdaList', 
        'Get-S3CBucket', 
        'Get-S3CBucketLifecycleConfiguration', 
        'Get-S3CBucketPolicy', 
        'Get-S3CBucketReplication', 
        'Get-S3CBucketTagging', 
        'Get-S3CBucketVersioning', 
        'Get-S3CCallerAccessGrantList', 
        'Get-S3CDataAccess', 
        'Get-S3CJob', 
        'Get-S3CJobList', 
        'Get-S3CJobTagging', 
        'Get-S3CMultiRegionAccessPoint', 
        'Get-S3CMultiRegionAccessPointList', 
        'Get-S3CMultiRegionAccessPointOperation', 
        'Get-S3CMultiRegionAccessPointPolicy', 
        'Get-S3CMultiRegionAccessPointPolicyStatus', 
        'Get-S3CMultiRegionAccessPointRoute', 
        'Get-S3CPublicAccessBlock', 
        'Get-S3CRegionalBucketList', 
        'Get-S3CResourceTag', 
        'Get-S3CStorageLensConfiguration', 
        'Get-S3CStorageLensConfigurationList', 
        'Get-S3CStorageLensConfigurationTagging', 
        'Get-S3CStorageLensGroup', 
        'Get-S3CStorageLensGroupList', 
        'New-S3CAccessGrant', 
        'New-S3CAccessGrantsInstance', 
        'New-S3CAccessGrantsLocation', 
        'New-S3CAccessPoint', 
        'New-S3CAccessPointForObjectLambda', 
        'New-S3CBucket', 
        'New-S3CJob', 
        'New-S3CMultiRegionAccessPoint', 
        'New-S3CStorageLensGroup', 
        'Remove-S3CAccessGrant', 
        'Remove-S3CAccessGrantsInstance', 
        'Remove-S3CAccessGrantsInstanceResourcePolicy', 
        'Remove-S3CAccessGrantsLocation', 
        'Remove-S3CAccessPoint', 
        'Remove-S3CAccessPointForObjectLambda', 
        'Remove-S3CAccessPointPolicy', 
        'Remove-S3CAccessPointPolicyForObjectLambda', 
        'Remove-S3CBucket', 
        'Remove-S3CBucketLifecycleConfiguration', 
        'Remove-S3CBucketPolicy', 
        'Remove-S3CBucketReplication', 
        'Remove-S3CBucketTagging', 
        'Remove-S3CJobTagging', 
        'Remove-S3CMultiRegionAccessPoint', 
        'Remove-S3CPublicAccessBlock', 
        'Remove-S3CResourceTag', 
        'Remove-S3CStorageLensConfiguration', 
        'Remove-S3CStorageLensConfigurationTagging', 
        'Remove-S3CStorageLensGroup', 
        'Submit-S3CMultiRegionAccessPointRoute', 
        'Update-S3CAccessGrantsLocation', 
        'Update-S3CJobPriority', 
        'Update-S3CJobStatus', 
        'Update-S3CStorageLensGroup', 
        'Write-S3CAccessGrantsInstanceResourcePolicy', 
        'Write-S3CAccessPointConfigurationForObjectLambda', 
        'Write-S3CAccessPointPolicy', 
        'Write-S3CAccessPointPolicyForObjectLambda', 
        'Write-S3CBucketLifecycleConfiguration', 
        'Write-S3CBucketPolicy', 
        'Write-S3CBucketReplication', 
        'Write-S3CBucketTagging', 
        'Write-S3CBucketVersioning', 
        'Write-S3CMultiRegionAccessPointPolicy', 
        'Write-S3CStorageLensConfiguration', 
        'Write-S3CStorageLensConfigurationTagging')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.S3Control.dll-Help.xml'
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
