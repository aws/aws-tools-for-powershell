#
# Module manifest for module 'AWS.Tools.CloudWatchLogs'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.CloudWatchLogs.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '32feef3c-061d-4e8c-84a7-9e28fd2a7f3c'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The CloudWatchLogs module of AWS Tools for PowerShell lets developers and administrators manage Amazon CloudWatch Logs from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.CloudWatchLogs.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.CloudWatchLogs.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.CloudWatchLogs.Completers.psm1',
        'AWS.Tools.CloudWatchLogs.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-CWLLogGroupTag', 
        'Add-CWLResourceTag', 
        'Find-CWLConfigurationTemplate', 
        'Find-CWLDelivery', 
        'Find-CWLDeliveryDestination', 
        'Find-CWLDeliverySource', 
        'Get-CWLAccountPolicy', 
        'Get-CWLAnomalyList', 
        'Get-CWLDataProtectionPolicy', 
        'Get-CWLDelivery', 
        'Get-CWLDeliveryDestination', 
        'Get-CWLDeliveryDestinationPolicy', 
        'Get-CWLDeliverySource', 
        'Get-CWLDestination', 
        'Get-CWLExportTask', 
        'Get-CWLFieldIndex', 
        'Get-CWLFilteredLogEvent', 
        'Get-CWLIndexPolicy', 
        'Get-CWLIntegration', 
        'Get-CWLIntegrationList', 
        'Get-CWLLogAnomalyDetector', 
        'Get-CWLLogAnomalyDetectorList', 
        'Get-CWLLogEvent', 
        'Get-CWLLogGroup', 
        'Get-CWLLogGroupField', 
        'Get-CWLLogGroupList', 
        'Get-CWLLogGroupsForQueryList', 
        'Get-CWLLogGroupTag', 
        'Get-CWLLogObject', 
        'Get-CWLLogRecord', 
        'Get-CWLLogStream', 
        'Get-CWLMetricFilter', 
        'Get-CWLQuery', 
        'Get-CWLQueryDefinition', 
        'Get-CWLQueryResult', 
        'Get-CWLResourcePolicy', 
        'Get-CWLResourceTag', 
        'Get-CWLSubscriptionFilter', 
        'Get-CWLTransformer', 
        'New-CWLDelivery', 
        'New-CWLExportTask', 
        'New-CWLLogAnomalyDetector', 
        'New-CWLLogGroup', 
        'New-CWLLogStream', 
        'Register-CWLKmsKey', 
        'Remove-CWLAccountPolicy', 
        'Remove-CWLDataProtectionPolicy', 
        'Remove-CWLDelivery', 
        'Remove-CWLDeliveryDestination', 
        'Remove-CWLDeliveryDestinationPolicy', 
        'Remove-CWLDeliverySource', 
        'Remove-CWLDestination', 
        'Remove-CWLIndexPolicy', 
        'Remove-CWLIntegration', 
        'Remove-CWLLogAnomalyDetector', 
        'Remove-CWLLogGroup', 
        'Remove-CWLLogGroupTag', 
        'Remove-CWLLogStream', 
        'Remove-CWLMetricFilter', 
        'Remove-CWLQueryDefinition', 
        'Remove-CWLResourcePolicy', 
        'Remove-CWLResourceTag', 
        'Remove-CWLRetentionPolicy', 
        'Remove-CWLSubscriptionFilter', 
        'Remove-CWLTransformer', 
        'Start-CWLLiveTail', 
        'Start-CWLQuery', 
        'Stop-CWLExportTask', 
        'Stop-CWLQuery', 
        'Test-CWLMetricFilter', 
        'Test-CWLTransformer', 
        'Unregister-CWLKmsKey', 
        'Update-CWLAnomaly', 
        'Update-CWLDeliveryConfiguration', 
        'Update-CWLLogAnomalyDetector', 
        'Write-CWLAccountPolicy', 
        'Write-CWLDataProtectionPolicy', 
        'Write-CWLDeliveryDestination', 
        'Write-CWLDeliveryDestinationPolicy', 
        'Write-CWLDeliverySource', 
        'Write-CWLDestination', 
        'Write-CWLDestinationPolicy', 
        'Write-CWLIndexPolicy', 
        'Write-CWLIntegration', 
        'Write-CWLLogEvent', 
        'Write-CWLMetricFilter', 
        'Write-CWLQueryDefinition', 
        'Write-CWLResourcePolicy', 
        'Write-CWLRetentionPolicy', 
        'Write-CWLSubscriptionFilter', 
        'Write-CWLTransformer')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Get-CWLExportTasks', 
        'Get-CWLLogGroups', 
        'Get-CWLLogStreams', 
        'Get-CWLMetricFilters', 
        'Get-CWLSubscriptionFilters', 
        'Get-CWLLogEvents', 
        'Write-CWLLogEvents')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.CloudWatchLogs.dll-Help.xml'
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
