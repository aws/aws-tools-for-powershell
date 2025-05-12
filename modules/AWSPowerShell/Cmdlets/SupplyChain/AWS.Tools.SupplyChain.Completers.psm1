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

# Argument completions for service AWS Supply Chain


$SUPCH_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SupplyChain.DataIntegrationEventDatasetOperationType
        "Send-SUPCHDataIntegrationEvent/DatasetTarget_OperationType"
        {
            $v = "APPEND","DELETE","UPSERT"
            break
        }

        # Amazon.SupplyChain.DataIntegrationEventType
        {
            ($_ -eq "Get-SUPCHDataIntegrationEventList/EventType") -Or
            ($_ -eq "Send-SUPCHDataIntegrationEvent/EventType")
        }
        {
            $v = "scn.data.dataset","scn.data.forecast","scn.data.inboundorder","scn.data.inboundorderline","scn.data.inboundorderlineschedule","scn.data.inventorylevel","scn.data.outboundorderline","scn.data.outboundshipment","scn.data.processheader","scn.data.processoperation","scn.data.processproduct","scn.data.reservation","scn.data.shipment","scn.data.shipmentstop","scn.data.shipmentstoporder","scn.data.supplyplan"
            break
        }

        # Amazon.SupplyChain.DataIntegrationFlowDedupeStrategyType
        {
            ($_ -eq "New-SUPCHDataIntegrationFlow/DedupeStrategy_Type") -Or
            ($_ -eq "Update-SUPCHDataIntegrationFlow/DedupeStrategy_Type")
        }
        {
            $v = "FIELD_PRIORITY"
            break
        }

        # Amazon.SupplyChain.DataIntegrationFlowFileType
        {
            ($_ -eq "New-SUPCHDataIntegrationFlow/Options_FileType") -Or
            ($_ -eq "Update-SUPCHDataIntegrationFlow/Options_FileType")
        }
        {
            $v = "CSV","JSON","PARQUET"
            break
        }

        # Amazon.SupplyChain.DataIntegrationFlowLoadType
        {
            ($_ -eq "New-SUPCHDataIntegrationFlow/Options_LoadType") -Or
            ($_ -eq "Update-SUPCHDataIntegrationFlow/Options_LoadType")
        }
        {
            $v = "INCREMENTAL","REPLACE"
            break
        }

        # Amazon.SupplyChain.DataIntegrationFlowTargetType
        {
            ($_ -eq "New-SUPCHDataIntegrationFlow/Target_TargetType") -Or
            ($_ -eq "Update-SUPCHDataIntegrationFlow/Target_TargetType")
        }
        {
            $v = "DATASET","S3"
            break
        }

        # Amazon.SupplyChain.DataIntegrationFlowTransformationType
        {
            ($_ -eq "New-SUPCHDataIntegrationFlow/Transformation_TransformationType") -Or
            ($_ -eq "Update-SUPCHDataIntegrationFlow/Transformation_TransformationType")
        }
        {
            $v = "NONE","SQL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SUPCH_map = @{
    "DatasetTarget_OperationType"=@("Send-SUPCHDataIntegrationEvent")
    "DedupeStrategy_Type"=@("New-SUPCHDataIntegrationFlow","Update-SUPCHDataIntegrationFlow")
    "EventType"=@("Get-SUPCHDataIntegrationEventList","Send-SUPCHDataIntegrationEvent")
    "Options_FileType"=@("New-SUPCHDataIntegrationFlow","Update-SUPCHDataIntegrationFlow")
    "Options_LoadType"=@("New-SUPCHDataIntegrationFlow","Update-SUPCHDataIntegrationFlow")
    "Target_TargetType"=@("New-SUPCHDataIntegrationFlow","Update-SUPCHDataIntegrationFlow")
    "Transformation_TransformationType"=@("New-SUPCHDataIntegrationFlow","Update-SUPCHDataIntegrationFlow")
}

_awsArgumentCompleterRegistration $SUPCH_Completers $SUPCH_map

$SUPCH_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SUPCH.$($commandName.Replace('-', ''))Cmdlet]"
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

$SUPCH_SelectMap = @{
    "Select"=@("New-SUPCHBillOfMaterialsImportJob",
               "New-SUPCHDataIntegrationFlow",
               "New-SUPCHDataLakeDataset",
               "New-SUPCHDataLakeNamespace",
               "New-SUPCHInstance",
               "Remove-SUPCHDataIntegrationFlow",
               "Remove-SUPCHDataLakeDataset",
               "Remove-SUPCHDataLakeNamespace",
               "Remove-SUPCHInstance",
               "Get-SUPCHBillOfMaterialsImportJob",
               "Get-SUPCHDataIntegrationEvent",
               "Get-SUPCHDataIntegrationFlow",
               "Get-SUPCHDataIntegrationFlowExecution",
               "Get-SUPCHDataLakeDataset",
               "Get-SUPCHDataLakeNamespace",
               "Get-SUPCHInstance",
               "Get-SUPCHDataIntegrationEventList",
               "Get-SUPCHDataIntegrationFlowExecutionList",
               "Get-SUPCHDataIntegrationFlowList",
               "Get-SUPCHDataLakeDatasetList",
               "Get-SUPCHDataLakeNamespaceList",
               "Get-SUPCHInstanceList",
               "Get-SUPCHResourceTag",
               "Send-SUPCHDataIntegrationEvent",
               "Add-SUPCHResourceTag",
               "Remove-SUPCHResourceTag",
               "Update-SUPCHDataIntegrationFlow",
               "Update-SUPCHDataLakeDataset",
               "Update-SUPCHDataLakeNamespace",
               "Update-SUPCHInstance")
}

_awsArgumentCompleterRegistration $SUPCH_SelectCompleters $SUPCH_SelectMap

