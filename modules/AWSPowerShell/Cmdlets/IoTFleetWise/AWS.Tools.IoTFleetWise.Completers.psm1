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

# Argument completions for service AWS IoT FleetWise


$IFW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IoTFleetWise.Compression
        "New-IFWCampaign/Compression"
        {
            $v = "OFF","SNAPPY"
            break
        }

        # Amazon.IoTFleetWise.DiagnosticsMode
        "New-IFWCampaign/DiagnosticsMode"
        {
            $v = "OFF","SEND_ACTIVE_DTCS"
            break
        }

        # Amazon.IoTFleetWise.EncryptionType
        "Write-IFWEncryptionConfiguration/EncryptionType"
        {
            $v = "FLEETWISE_DEFAULT_ENCRYPTION","KMS_BASED_ENCRYPTION"
            break
        }

        # Amazon.IoTFleetWise.LogType
        "Write-IFWLoggingOption/CloudWatchLogDelivery_LogType"
        {
            $v = "ERROR","OFF"
            break
        }

        # Amazon.IoTFleetWise.ManifestStatus
        {
            ($_ -eq "Update-IFWDecoderManifest/Status") -Or
            ($_ -eq "Update-IFWModelManifest/Status")
        }
        {
            $v = "ACTIVE","DRAFT"
            break
        }

        # Amazon.IoTFleetWise.SpoolingMode
        "New-IFWCampaign/SpoolingMode"
        {
            $v = "OFF","TO_DISK"
            break
        }

        # Amazon.IoTFleetWise.TriggerMode
        "New-IFWCampaign/CollectionScheme_ConditionBasedCollectionScheme_TriggerMode"
        {
            $v = "ALWAYS","RISING_EDGE"
            break
        }

        # Amazon.IoTFleetWise.UpdateCampaignAction
        "Update-IFWCampaign/Action"
        {
            $v = "APPROVE","RESUME","SUSPEND","UPDATE"
            break
        }

        # Amazon.IoTFleetWise.UpdateMode
        "Update-IFWVehicle/AttributeUpdateMode"
        {
            $v = "Merge","Overwrite"
            break
        }

        # Amazon.IoTFleetWise.VehicleAssociationBehavior
        "New-IFWVehicle/AssociationBehavior"
        {
            $v = "CreateIotThing","ValidateIotThingExists"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IFW_map = @{
    "Action"=@("Update-IFWCampaign")
    "AssociationBehavior"=@("New-IFWVehicle")
    "AttributeUpdateMode"=@("Update-IFWVehicle")
    "CloudWatchLogDelivery_LogType"=@("Write-IFWLoggingOption")
    "CollectionScheme_ConditionBasedCollectionScheme_TriggerMode"=@("New-IFWCampaign")
    "Compression"=@("New-IFWCampaign")
    "DiagnosticsMode"=@("New-IFWCampaign")
    "EncryptionType"=@("Write-IFWEncryptionConfiguration")
    "SpoolingMode"=@("New-IFWCampaign")
    "Status"=@("Update-IFWDecoderManifest","Update-IFWModelManifest")
}

_awsArgumentCompleterRegistration $IFW_Completers $IFW_map

$IFW_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IFW.$($commandName.Replace('-', ''))Cmdlet]"
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

$IFW_SelectMap = @{
    "Select"=@("New-IFWVehicleFleet",
               "New-IFWCreateVehicle",
               "New-IFWUpdateVehicle",
               "New-IFWCampaign",
               "New-IFWDecoderManifest",
               "New-IFWFleet",
               "New-IFWModelManifest",
               "New-IFWSignalCatalog",
               "New-IFWVehicle",
               "Remove-IFWCampaign",
               "Remove-IFWDecoderManifest",
               "Remove-IFWFleet",
               "Remove-IFWModelManifest",
               "Remove-IFWSignalCatalog",
               "Remove-IFWVehicle",
               "Remove-IFWVehicleFleet",
               "Get-IFWCampaign",
               "Get-IFWDecoderManifest",
               "Get-IFWEncryptionConfiguration",
               "Get-IFWFleet",
               "Get-IFWLoggingOption",
               "Get-IFWModelManifest",
               "Get-IFWRegisterAccountStatus",
               "Get-IFWSignalCatalog",
               "Get-IFWVehicle",
               "Get-IFWVehicleStatus",
               "Import-IFWDecoderManifest",
               "Import-IFWSignalCatalog",
               "Get-IFWCampaignList",
               "Get-IFWDecoderManifestNetworkInterfaceList",
               "Get-IFWDecoderManifestList",
               "Get-IFWDecoderManifestSignalList",
               "Get-IFWFleetList",
               "Get-IFWFleetsForVehicleList",
               "Get-IFWModelManifestNodeList",
               "Get-IFWModelManifestList",
               "Get-IFWSignalCatalogNodeList",
               "Get-IFWSignalCatalogList",
               "Get-IFWResourceTag",
               "Get-IFWVehicleList",
               "Get-IFWVehiclesInFleetList",
               "Write-IFWEncryptionConfiguration",
               "Write-IFWLoggingOption",
               "Register-IFWAccount",
               "Add-IFWResourceTag",
               "Remove-IFWResourceTag",
               "Update-IFWCampaign",
               "Update-IFWDecoderManifest",
               "Update-IFWFleet",
               "Update-IFWModelManifest",
               "Update-IFWSignalCatalog",
               "Update-IFWVehicle")
}

_awsArgumentCompleterRegistration $IFW_SelectCompleters $IFW_SelectMap

