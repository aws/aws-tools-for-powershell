#
# Module manifest for module 'AWS.Tools.S3'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.S3.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'b4e504bd-3d14-4563-918a-91025140eba4'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2021 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The S3 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Simple Storage Service (S3) from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.S3.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.S3.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.S3.Completers.psm1',
        'AWS.Tools.S3.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-S3PublicAccessBlock', 
        'Copy-S3Object', 
        'Get-S3ACL', 
        'Get-S3Bucket', 
        'Get-S3BucketAccelerateConfiguration', 
        'Get-S3BucketAnalyticsConfiguration', 
        'Get-S3BucketAnalyticsConfigurationList', 
        'Get-S3BucketEncryption', 
        'Get-S3BucketIntelligentTieringConfiguration', 
        'Get-S3BucketIntelligentTieringConfigurationList', 
        'Get-S3BucketInventoryConfiguration', 
        'Get-S3BucketInventoryConfigurationList', 
        'Get-S3BucketLocation', 
        'Get-S3BucketLogging', 
        'Get-S3BucketMetricsConfiguration', 
        'Get-S3BucketMetricsConfigurationList', 
        'Get-S3BucketNotification', 
        'Get-S3BucketOwnershipControl', 
        'Get-S3BucketPolicy', 
        'Get-S3BucketPolicyStatus', 
        'Get-S3BucketReplication', 
        'Get-S3BucketRequestPayment', 
        'Get-S3BucketTagging', 
        'Get-S3BucketVersioning', 
        'Get-S3BucketWebsite', 
        'Get-S3CORSConfiguration', 
        'Get-S3LifecycleConfiguration', 
        'Get-S3Object', 
        'Get-S3ObjectLegalHold', 
        'Get-S3ObjectLockConfiguration', 
        'Get-S3ObjectMetadata', 
        'Get-S3ObjectRetention', 
        'Get-S3ObjectTagSet', 
        'Get-S3PreSignedURL', 
        'Get-S3PublicAccessBlock', 
        'Get-S3Version', 
        'New-S3Bucket', 
        'Read-S3Object', 
        'Remove-S3Bucket', 
        'Remove-S3BucketAnalyticsConfiguration', 
        'Remove-S3BucketEncryption', 
        'Remove-S3BucketIntelligentTieringConfiguration', 
        'Remove-S3BucketInventoryConfiguration', 
        'Remove-S3BucketMetricsConfiguration', 
        'Remove-S3BucketOwnershipControl', 
        'Remove-S3BucketPolicy', 
        'Remove-S3BucketReplication', 
        'Remove-S3BucketTagging', 
        'Remove-S3BucketWebsite', 
        'Remove-S3CORSConfiguration', 
        'Remove-S3LifecycleConfiguration', 
        'Remove-S3MultipartUpload', 
        'Remove-S3Object', 
        'Remove-S3ObjectTagSet', 
        'Remove-S3PublicAccessBlock', 
        'Restore-S3Object', 
        'Select-S3ObjectContent', 
        'Set-S3ACL', 
        'Set-S3BucketEncryption', 
        'Test-S3Bucket', 
        'Write-S3BucketAccelerateConfiguration', 
        'Write-S3BucketAnalyticsConfiguration', 
        'Write-S3BucketIntelligentTieringConfiguration', 
        'Write-S3BucketInventoryConfiguration', 
        'Write-S3BucketLogging', 
        'Write-S3BucketMetricsConfiguration', 
        'Write-S3BucketNotification', 
        'Write-S3BucketOwnershipControl', 
        'Write-S3BucketPolicy', 
        'Write-S3BucketReplication', 
        'Write-S3BucketRequestPayment', 
        'Write-S3BucketTagging', 
        'Write-S3BucketVersioning', 
        'Write-S3BucketWebsite', 
        'Write-S3CORSConfiguration', 
        'Write-S3LifecycleConfiguration', 
        'Write-S3Object', 
        'Write-S3ObjectLegalHold', 
        'Write-S3ObjectLockConfiguration', 
        'Write-S3ObjectRetention', 
        'Write-S3ObjectTagSet')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Remove-S3MultipartUploads')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.S3.dll-Help.xml'
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
