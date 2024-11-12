#
# Module manifest for module 'AWS.Tools.GameLift'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.GameLift.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = '44a60bb5-a0ae-4d09-a478-9ed730458cef'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2024 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The GameLift module of AWS Tools for PowerShell lets developers and administrators manage Amazon GameLift Service from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
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
        'AWSSDK.GameLift.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.GameLift.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.GameLift.Completers.psm1',
        'AWS.Tools.GameLift.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-GMLResourceTag', 
        'Confirm-GMLMatch', 
        'Find-GMLGameSession', 
        'Get-GMLAlias', 
        'Get-GMLAliasDetail', 
        'Get-GMLBuild', 
        'Get-GMLBuildDetail', 
        'Get-GMLCompute', 
        'Get-GMLComputeAccess', 
        'Get-GMLComputeAuthToken', 
        'Get-GMLComputeList', 
        'Get-GMLContainerFleet', 
        'Get-GMLContainerFleetList', 
        'Get-GMLContainerGroupDefinition', 
        'Get-GMLContainerGroupDefinitionList', 
        'Get-GMLContainerGroupDefinitionVersionList', 
        'Get-GMLEC2InstanceLimit', 
        'Get-GMLFleet', 
        'Get-GMLFleetAttribute', 
        'Get-GMLFleetCapacity', 
        'Get-GMLFleetDeployment', 
        'Get-GMLFleetDeploymentList', 
        'Get-GMLFleetEvent', 
        'Get-GMLFleetLocationAttribute', 
        'Get-GMLFleetLocationCapacity', 
        'Get-GMLFleetLocationUtilization', 
        'Get-GMLFleetPortSetting', 
        'Get-GMLFleetUtilization', 
        'Get-GMLGameServer', 
        'Get-GMLGameServerGroup', 
        'Get-GMLGameServerGroupList', 
        'Get-GMLGameServerInstance', 
        'Get-GMLGameServerList', 
        'Get-GMLGameSession', 
        'Get-GMLGameSessionDetail', 
        'Get-GMLGameSessionLogUrl', 
        'Get-GMLGameSessionPlacement', 
        'Get-GMLGameSessionQueue', 
        'Get-GMLInstance', 
        'Get-GMLInstanceAccess', 
        'Get-GMLLocationList', 
        'Get-GMLMatchmaking', 
        'Get-GMLMatchmakingConfiguration', 
        'Get-GMLMatchmakingRuleSet', 
        'Get-GMLPlayerSession', 
        'Get-GMLResourceTag', 
        'Get-GMLRuntimeConfiguration', 
        'Get-GMLScalingPolicy', 
        'Get-GMLScript', 
        'Get-GMLScriptList', 
        'Get-GMLVpcPeeringAuthorization', 
        'Get-GMLVpcPeeringConnection', 
        'New-GMLAlias', 
        'New-GMLBuild', 
        'New-GMLContainerFleet', 
        'New-GMLContainerGroupDefinition', 
        'New-GMLFleet', 
        'New-GMLFleetLocation', 
        'New-GMLGameServerGroup', 
        'New-GMLGameSession', 
        'New-GMLGameSessionQueue', 
        'New-GMLLocation', 
        'New-GMLMatchmakingConfiguration', 
        'New-GMLMatchmakingRuleSet', 
        'New-GMLPlayerSession', 
        'New-GMLScript', 
        'New-GMLVpcPeeringAuthorization', 
        'New-GMLVpcPeeringConnection', 
        'Register-GMLCompute', 
        'Register-GMLGameServer', 
        'Remove-GMLAlias', 
        'Remove-GMLBuild', 
        'Remove-GMLContainerFleet', 
        'Remove-GMLContainerGroupDefinition', 
        'Remove-GMLFleet', 
        'Remove-GMLFleetLocation', 
        'Remove-GMLGameServerGroup', 
        'Remove-GMLGameSessionQueue', 
        'Remove-GMLLocation', 
        'Remove-GMLMatchmakingConfiguration', 
        'Remove-GMLMatchmakingRuleSet', 
        'Remove-GMLResourceTag', 
        'Remove-GMLScalingPolicy', 
        'Remove-GMLScript', 
        'Remove-GMLVpcPeeringAuthorization', 
        'Remove-GMLVpcPeeringConnection', 
        'Request-GMLGameServer', 
        'Request-GMLUploadCredential', 
        'Resolve-GMLAlias', 
        'Resume-GMLGameServerGroup', 
        'Start-GMLFleetAction', 
        'Start-GMLGameSessionPlacement', 
        'Start-GMLMatchBackfill', 
        'Start-GMLMatchmaking', 
        'Stop-GMLFleetAction', 
        'Stop-GMLGameSessionPlacement', 
        'Stop-GMLMatchmaking', 
        'Suspend-GMLGameServerGroup', 
        'Test-GMLMatchmakingRuleSetValidity', 
        'Unregister-GMLCompute', 
        'Unregister-GMLGameServer', 
        'Update-GMLAlias', 
        'Update-GMLBuild', 
        'Update-GMLContainerFleet', 
        'Update-GMLContainerGroupDefinition', 
        'Update-GMLFleetAttribute', 
        'Update-GMLFleetCapacity', 
        'Update-GMLFleetPortSetting', 
        'Update-GMLGameServer', 
        'Update-GMLGameServerGroup', 
        'Update-GMLGameSession', 
        'Update-GMLGameSessionQueue', 
        'Update-GMLMatchmakingConfiguration', 
        'Update-GMLRuntimeConfiguration', 
        'Update-GMLScript', 
        'Write-GMLScalingPolicy')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @()

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.GameLift.dll-Help.xml'
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
