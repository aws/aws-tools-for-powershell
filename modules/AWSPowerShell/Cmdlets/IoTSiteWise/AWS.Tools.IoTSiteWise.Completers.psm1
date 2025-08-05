# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service AWS IoT SiteWise


$IOTSW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IoTSiteWise.AssetModelType
        "New-IOTSWAssetModel/AssetModelType"
        {
            $v = "ASSET_MODEL","COMPONENT_MODEL","INTERFACE"
            break
        }

        # Amazon.IoTSiteWise.AssetModelVersionType
        {
            ($_ -eq "New-IOTSWAssetModelCompositeModel/MatchForVersionType") -Or
            ($_ -eq "Remove-IOTSWAssetModel/MatchForVersionType") -Or
            ($_ -eq "Remove-IOTSWAssetModelCompositeModel/MatchForVersionType") -Or
            ($_ -eq "Update-IOTSWAssetModel/MatchForVersionType") -Or
            ($_ -eq "Update-IOTSWAssetModelCompositeModel/MatchForVersionType")
        }
        {
            $v = "ACTIVE","LATEST"
            break
        }

        # Amazon.IoTSiteWise.AuthMode
        "New-IOTSWPortal/PortalAuthMode"
        {
            $v = "IAM","SSO"
            break
        }

        # Amazon.IoTSiteWise.ComputationModelType
        "Get-IOTSWComputationModelList/ComputationModelType"
        {
            $v = "ANOMALY_DETECTION"
            break
        }

        # Amazon.IoTSiteWise.CoreDeviceOperatingSystem
        "New-IOTSWGateway/GreengrassV2_CoreDeviceOperatingSystem"
        {
            $v = "LINUX_AARCH64","LINUX_AMD64","WINDOWS_AMD64"
            break
        }

        # Amazon.IoTSiteWise.DatasetSourceFormat
        {
            ($_ -eq "New-IOTSWDataset/DatasetSource_SourceFormat") -Or
            ($_ -eq "Update-IOTSWDataset/DatasetSource_SourceFormat")
        }
        {
            $v = "KNOWLEDGE_BASE"
            break
        }

        # Amazon.IoTSiteWise.DatasetSourceType
        {
            ($_ -eq "New-IOTSWDataset/DatasetSource_SourceType") -Or
            ($_ -eq "Update-IOTSWDataset/DatasetSource_SourceType") -Or
            ($_ -eq "Get-IOTSWDatasetList/SourceType")
        }
        {
            $v = "KENDRA"
            break
        }

        # Amazon.IoTSiteWise.DisassociatedDataStorageState
        "Write-IOTSWStorageConfiguration/DisassociatedDataStorage"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.IoTSiteWise.EncryptionType
        "Write-IOTSWDefaultEncryptionConfiguration/EncryptionType"
        {
            $v = "KMS_BASED_ENCRYPTION","SITEWISE_DEFAULT_ENCRYPTION"
            break
        }

        # Amazon.IoTSiteWise.IdentityType
        "Get-IOTSWAccessPolicyList/IdentityType"
        {
            $v = "GROUP","IAM","USER"
            break
        }

        # Amazon.IoTSiteWise.ImageFileType
        {
            ($_ -eq "Update-IOTSWPortal/File_Type") -Or
            ($_ -eq "New-IOTSWPortal/PortalLogoImageFile_Type")
        }
        {
            $v = "PNG"
            break
        }

        # Amazon.IoTSiteWise.ListAssetModelPropertiesFilter
        "Get-IOTSWAssetModelPropertyList/Filter"
        {
            $v = "ALL","BASE"
            break
        }

        # Amazon.IoTSiteWise.ListAssetPropertiesFilter
        "Get-IOTSWAssetPropertyList/Filter"
        {
            $v = "ALL","BASE"
            break
        }

        # Amazon.IoTSiteWise.ListAssetsFilter
        "Get-IOTSWAssetList/Filter"
        {
            $v = "ALL","TOP_LEVEL"
            break
        }

        # Amazon.IoTSiteWise.ListBulkImportJobsFilter
        "Get-IOTSWBulkImportJobList/Filter"
        {
            $v = "ALL","CANCELLED","COMPLETED","COMPLETED_WITH_FAILURES","FAILED","PENDING","RUNNING"
            break
        }

        # Amazon.IoTSiteWise.ListTimeSeriesType
        "Get-IOTSWTimeSeriesList/TimeSeriesType"
        {
            $v = "ASSOCIATED","DISASSOCIATED"
            break
        }

        # Amazon.IoTSiteWise.LoggingLevel
        "Write-IOTSWLoggingOption/LoggingOptions_Level"
        {
            $v = "ERROR","INFO","OFF"
            break
        }

        # Amazon.IoTSiteWise.Permission
        {
            ($_ -eq "New-IOTSWAccessPolicy/AccessPolicyPermission") -Or
            ($_ -eq "Update-IOTSWAccessPolicy/AccessPolicyPermission")
        }
        {
            $v = "ADMINISTRATOR","VIEWER"
            break
        }

        # Amazon.IoTSiteWise.PortalType
        {
            ($_ -eq "New-IOTSWPortal/PortalType") -Or
            ($_ -eq "Update-IOTSWPortal/PortalType")
        }
        {
            $v = "SITEWISE_PORTAL_V1","SITEWISE_PORTAL_V2"
            break
        }

        # Amazon.IoTSiteWise.PropertyNotificationState
        "Update-IOTSWAssetProperty/PropertyNotificationState"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.IoTSiteWise.Quality
        "Get-IOTSWInterpolatedAssetPropertyValue/Quality"
        {
            $v = "BAD","GOOD","UNCERTAIN"
            break
        }

        # Amazon.IoTSiteWise.ResolveToResourceType
        {
            ($_ -eq "Get-IOTSWActionList/ResolveToResourceType") -Or
            ($_ -eq "Get-IOTSWComputationModelExecutionSummary/ResolveToResourceType") -Or
            ($_ -eq "Get-IOTSWExecutionList/ResolveToResourceType")
        }
        {
            $v = "ASSET"
            break
        }

        # Amazon.IoTSiteWise.ResourceType
        "Get-IOTSWAccessPolicyList/ResourceType"
        {
            $v = "PORTAL","PROJECT"
            break
        }

        # Amazon.IoTSiteWise.StorageType
        "Write-IOTSWStorageConfiguration/StorageType"
        {
            $v = "MULTI_LAYER_STORAGE","SITEWISE_DEFAULT_STORAGE"
            break
        }

        # Amazon.IoTSiteWise.TargetResourceType
        {
            ($_ -eq "Get-IOTSWActionList/TargetResourceType") -Or
            ($_ -eq "Get-IOTSWExecutionList/TargetResourceType")
        }
        {
            $v = "ASSET","COMPUTATION_MODEL"
            break
        }

        # Amazon.IoTSiteWise.TimeOrdering
        {
            ($_ -eq "Get-IOTSWAssetPropertyAggregate/TimeOrdering") -Or
            ($_ -eq "Get-IOTSWAssetPropertyValueHistory/TimeOrdering")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.IoTSiteWise.TraversalDirection
        "Get-IOTSWAssociatedAssetList/TraversalDirection"
        {
            $v = "CHILD","PARENT"
            break
        }

        # Amazon.IoTSiteWise.TraversalType
        "Get-IOTSWAssetRelationshipList/TraversalType"
        {
            $v = "PATH_TO_ROOT"
            break
        }

        # Amazon.IoTSiteWise.WarmTierState
        "Write-IOTSWStorageConfiguration/WarmTier"
        {
            $v = "DISABLED","ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IOTSW_map = @{
    "AccessPolicyPermission"=@("New-IOTSWAccessPolicy","Update-IOTSWAccessPolicy")
    "AssetModelType"=@("New-IOTSWAssetModel")
    "ComputationModelType"=@("Get-IOTSWComputationModelList")
    "DatasetSource_SourceFormat"=@("New-IOTSWDataset","Update-IOTSWDataset")
    "DatasetSource_SourceType"=@("New-IOTSWDataset","Update-IOTSWDataset")
    "DisassociatedDataStorage"=@("Write-IOTSWStorageConfiguration")
    "EncryptionType"=@("Write-IOTSWDefaultEncryptionConfiguration")
    "File_Type"=@("Update-IOTSWPortal")
    "Filter"=@("Get-IOTSWAssetList","Get-IOTSWAssetModelPropertyList","Get-IOTSWAssetPropertyList","Get-IOTSWBulkImportJobList")
    "GreengrassV2_CoreDeviceOperatingSystem"=@("New-IOTSWGateway")
    "IdentityType"=@("Get-IOTSWAccessPolicyList")
    "LoggingOptions_Level"=@("Write-IOTSWLoggingOption")
    "MatchForVersionType"=@("New-IOTSWAssetModelCompositeModel","Remove-IOTSWAssetModel","Remove-IOTSWAssetModelCompositeModel","Update-IOTSWAssetModel","Update-IOTSWAssetModelCompositeModel")
    "PortalAuthMode"=@("New-IOTSWPortal")
    "PortalLogoImageFile_Type"=@("New-IOTSWPortal")
    "PortalType"=@("New-IOTSWPortal","Update-IOTSWPortal")
    "PropertyNotificationState"=@("Update-IOTSWAssetProperty")
    "Quality"=@("Get-IOTSWInterpolatedAssetPropertyValue")
    "ResolveToResourceType"=@("Get-IOTSWActionList","Get-IOTSWComputationModelExecutionSummary","Get-IOTSWExecutionList")
    "ResourceType"=@("Get-IOTSWAccessPolicyList")
    "SourceType"=@("Get-IOTSWDatasetList")
    "StorageType"=@("Write-IOTSWStorageConfiguration")
    "TargetResourceType"=@("Get-IOTSWActionList","Get-IOTSWExecutionList")
    "TimeOrdering"=@("Get-IOTSWAssetPropertyAggregate","Get-IOTSWAssetPropertyValueHistory")
    "TimeSeriesType"=@("Get-IOTSWTimeSeriesList")
    "TraversalDirection"=@("Get-IOTSWAssociatedAssetList")
    "TraversalType"=@("Get-IOTSWAssetRelationshipList")
    "WarmTier"=@("Write-IOTSWStorageConfiguration")
}

_awsArgumentCompleterRegistration $IOTSW_Completers $IOTSW_map

$IOTSW_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IOTSW.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IOTSW_SelectMap = @{
    "Select"=@("Connect-IOTSWAsset",
               "Add-IOTSWTimeSeriesToAssetProperty",
               "Connect-IOTSWAssociateProjectAsset",
               "Disconnect-IOTSWDisassociateProjectAsset",
               "Get-IOTSWBatchAssetPropertyAggregate",
               "Get-IOTSWBatchAssetPropertyValue",
               "Get-IOTSWBatchAssetPropertyValueHistory",
               "Import-IOTSWPutAssetPropertyValue",
               "New-IOTSWAccessPolicy",
               "New-IOTSWAsset",
               "New-IOTSWAssetModel",
               "New-IOTSWAssetModelCompositeModel",
               "New-IOTSWBulkImportJob",
               "New-IOTSWComputationModel",
               "New-IOTSWDashboard",
               "New-IOTSWDataset",
               "New-IOTSWGateway",
               "New-IOTSWPortal",
               "New-IOTSWProject",
               "Remove-IOTSWAccessPolicy",
               "Remove-IOTSWAsset",
               "Remove-IOTSWAssetModel",
               "Remove-IOTSWAssetModelCompositeModel",
               "Remove-IOTSWAssetModelInterfaceRelationship",
               "Remove-IOTSWComputationModel",
               "Remove-IOTSWDashboard",
               "Remove-IOTSWDataset",
               "Remove-IOTSWGateway",
               "Remove-IOTSWPortal",
               "Remove-IOTSWProject",
               "Remove-IOTSWTimeSeries",
               "Get-IOTSWAccessPolicy",
               "Get-IOTSWAction",
               "Get-IOTSWAsset",
               "Get-IOTSWAssetCompositeModel",
               "Get-IOTSWAssetModel",
               "Get-IOTSWAssetModelCompositeModel",
               "Get-IOTSWAssetModelInterfaceRelationship",
               "Get-IOTSWAssetProperty",
               "Get-IOTSWBulkImportJob",
               "Get-IOTSWComputationModel",
               "Get-IOTSWComputationModelExecutionSummary",
               "Get-IOTSWDashboard",
               "Get-IOTSWDataset",
               "Get-IOTSWDefaultEncryptionConfiguration",
               "Get-IOTSWExecution",
               "Get-IOTSWGateway",
               "Get-IOTSWGatewayCapabilityConfiguration",
               "Get-IOTSWLoggingOption",
               "Get-IOTSWPortal",
               "Get-IOTSWProject",
               "Get-IOTSWStorageConfiguration",
               "Get-IOTSWTimeSeries",
               "Disconnect-IOTSWAsset",
               "Remove-IOTSWTimeSeriesFromAssetProperty",
               "Start-IOTSWAction",
               "Start-IOTSWQuery",
               "Get-IOTSWAssetPropertyAggregate",
               "Get-IOTSWAssetPropertyValue",
               "Get-IOTSWAssetPropertyValueHistory",
               "Get-IOTSWInterpolatedAssetPropertyValue",
               "Invoke-IOTSWAssistant",
               "Get-IOTSWAccessPolicyList",
               "Get-IOTSWActionList",
               "Get-IOTSWAssetModelCompositeModelList",
               "Get-IOTSWAssetModelPropertyList",
               "Get-IOTSWAssetModelList",
               "Get-IOTSWAssetPropertyList",
               "Get-IOTSWAssetRelationshipList",
               "Get-IOTSWAssetList",
               "Get-IOTSWAssociatedAssetList",
               "Get-IOTSWBulkImportJobList",
               "Get-IOTSWCompositionRelationshipList",
               "Get-IOTSWComputationModelDataBindingUsageList",
               "Get-IOTSWComputationModelResolveToResourceList",
               "Get-IOTSWComputationModelList",
               "Get-IOTSWDashboardList",
               "Get-IOTSWDatasetList",
               "Get-IOTSWExecutionList",
               "Get-IOTSWGatewayList",
               "Get-IOTSWInterfaceRelationshipList",
               "Get-IOTSWPortalList",
               "Get-IOTSWProjectAssetList",
               "Get-IOTSWProjectList",
               "Get-IOTSWResourceTag",
               "Get-IOTSWTimeSeriesList",
               "Write-IOTSWAssetModelInterfaceRelationship",
               "Write-IOTSWDefaultEncryptionConfiguration",
               "Write-IOTSWLoggingOption",
               "Write-IOTSWStorageConfiguration",
               "Add-IOTSWResourceTag",
               "Remove-IOTSWResourceTag",
               "Update-IOTSWAccessPolicy",
               "Update-IOTSWAsset",
               "Update-IOTSWAssetModel",
               "Update-IOTSWAssetModelCompositeModel",
               "Update-IOTSWAssetProperty",
               "Update-IOTSWComputationModel",
               "Update-IOTSWDashboard",
               "Update-IOTSWDataset",
               "Update-IOTSWGateway",
               "Update-IOTSWGatewayCapabilityConfiguration",
               "Update-IOTSWPortal",
               "Update-IOTSWProject")
}

_awsArgumentCompleterRegistration $IOTSW_SelectCompleters $IOTSW_SelectMap

