#
# Module manifest for module 'AWS.Tools.LexModelsV2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.LexModelsV2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '33dda8fd-ff80-48ea-98c3-aff899fae1a0'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The LexModelsV2 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Lex Model Building V2 from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.LexModelsV2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.LexModelsV2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.LexModelsV2.Completers.psm1',
        'AWS.Tools.LexModelsV2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-LMBV2ResourceTag', 
        'Edit-LMBV2CustomVocabularyItem', 
        'Get-LMBV2AggregatedUtteranceList', 
        'Get-LMBV2Bot', 
        'Get-LMBV2BotAlias', 
        'Get-LMBV2BotAliasList', 
        'Get-LMBV2BotAliasReplicaList', 
        'Get-LMBV2BotElement', 
        'Get-LMBV2BotList', 
        'Get-LMBV2BotLocale', 
        'Get-LMBV2BotLocaleList', 
        'Get-LMBV2BotRecommendation', 
        'Get-LMBV2BotRecommendationList', 
        'Get-LMBV2BotReplica', 
        'Get-LMBV2BotReplicaList', 
        'Get-LMBV2BotResourceGeneration', 
        'Get-LMBV2BotResourceGenerationList', 
        'Get-LMBV2BotVersion', 
        'Get-LMBV2BotVersionList', 
        'Get-LMBV2BotVersionReplicaList', 
        'Get-LMBV2BuiltInIntentList', 
        'Get-LMBV2BuiltInSlotTypeList', 
        'Get-LMBV2CustomVocabularyItemList', 
        'Get-LMBV2CustomVocabularyMetadata', 
        'Get-LMBV2Export', 
        'Get-LMBV2ExportList', 
        'Get-LMBV2Import', 
        'Get-LMBV2ImportList', 
        'Get-LMBV2Intent', 
        'Get-LMBV2IntentList', 
        'Get-LMBV2IntentMetricList', 
        'Get-LMBV2IntentPathList', 
        'Get-LMBV2IntentStageMetricList', 
        'Get-LMBV2RecommendedIntentList', 
        'Get-LMBV2ResourcePolicy', 
        'Get-LMBV2ResourceTag', 
        'Get-LMBV2SessionAnalyticsDataList', 
        'Get-LMBV2SessionMetricList', 
        'Get-LMBV2Slot', 
        'Get-LMBV2SlotList', 
        'Get-LMBV2SlotType', 
        'Get-LMBV2SlotTypeList', 
        'Get-LMBV2TestExecution', 
        'Get-LMBV2TestExecutionArtifactsUrl', 
        'Get-LMBV2TestExecutionList', 
        'Get-LMBV2TestExecutionResultItemList', 
        'Get-LMBV2TestSet', 
        'Get-LMBV2TestSetDiscrepancyReport', 
        'Get-LMBV2TestSetGeneration', 
        'Get-LMBV2TestSetList', 
        'Get-LMBV2TestSetRecordList', 
        'Get-LMBV2UtteranceAnalyticsDataList', 
        'Get-LMBV2UtteranceMetricList', 
        'Invoke-LMBV2BuildBotLocale', 
        'New-LMBV2Bot', 
        'New-LMBV2BotAlias', 
        'New-LMBV2BotLocale', 
        'New-LMBV2BotReplica', 
        'New-LMBV2BotVersion', 
        'New-LMBV2CustomVocabularyItem', 
        'New-LMBV2Export', 
        'New-LMBV2Intent', 
        'New-LMBV2ResourcePolicy', 
        'New-LMBV2ResourcePolicyStatement', 
        'New-LMBV2Slot', 
        'New-LMBV2SlotType', 
        'New-LMBV2TestSetDiscrepancyReport', 
        'New-LMBV2UploadUrl', 
        'Remove-LMBV2Bot', 
        'Remove-LMBV2BotAlias', 
        'Remove-LMBV2BotLocale', 
        'Remove-LMBV2BotReplica', 
        'Remove-LMBV2BotVersion', 
        'Remove-LMBV2CustomVocabulary', 
        'Remove-LMBV2CustomVocabularyItem', 
        'Remove-LMBV2Export', 
        'Remove-LMBV2Import', 
        'Remove-LMBV2Intent', 
        'Remove-LMBV2ResourcePolicy', 
        'Remove-LMBV2ResourcePolicyStatement', 
        'Remove-LMBV2ResourceTag', 
        'Remove-LMBV2Slot', 
        'Remove-LMBV2SlotType', 
        'Remove-LMBV2TestSet', 
        'Remove-LMBV2Utterance', 
        'Search-LMBV2AssociatedTranscript', 
        'Start-LMBV2BotRecommendation', 
        'Start-LMBV2BotResourceGeneration', 
        'Start-LMBV2Import', 
        'Start-LMBV2TestExecution', 
        'Start-LMBV2TestSetGeneration', 
        'Stop-LMBV2BotRecommendation', 
        'Update-LMBV2Bot', 
        'Update-LMBV2BotAlias', 
        'Update-LMBV2BotLocale', 
        'Update-LMBV2BotRecommendation', 
        'Update-LMBV2Export', 
        'Update-LMBV2Intent', 
        'Update-LMBV2ResourcePolicy', 
        'Update-LMBV2Slot', 
        'Update-LMBV2SlotType', 
        'Update-LMBV2TestSet')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Build-LMBV2BotLocale')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.LexModelsV2.dll-Help.xml'
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
