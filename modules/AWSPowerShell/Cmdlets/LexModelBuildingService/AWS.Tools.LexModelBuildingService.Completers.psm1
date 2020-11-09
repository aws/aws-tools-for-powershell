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

# Argument completions for service Amazon Lex Model Building Service


$LMB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LexModelBuildingService.ExportType
        "Get-LMBExport/ExportType"
        {
            $v = "ALEXA_SKILLS_KIT","LEX"
            break
        }

        # Amazon.LexModelBuildingService.FulfillmentActivityType
        "Write-LMBIntent/FulfillmentActivity_Type"
        {
            $v = "CodeHook","ReturnIntent"
            break
        }

        # Amazon.LexModelBuildingService.Locale
        {
            ($_ -eq "Get-LMBBuiltinIntentList/Locale") -Or
            ($_ -eq "Get-LMBBuiltinSlotType/Locale") -Or
            ($_ -eq "Write-LMBBot/Locale")
        }
        {
            $v = "de-DE","en-AU","en-GB","en-US","es-ES","es-US","fr-CA","fr-FR","it-IT"
            break
        }

        # Amazon.LexModelBuildingService.MergeStrategy
        "Start-LMBImport/MergeStrategy"
        {
            $v = "FAIL_ON_CONFLICT","OVERWRITE_LATEST"
            break
        }

        # Amazon.LexModelBuildingService.ProcessBehavior
        "Write-LMBBot/ProcessBehavior"
        {
            $v = "BUILD","SAVE"
            break
        }

        # Amazon.LexModelBuildingService.ResourceType
        {
            ($_ -eq "Get-LMBExport/ResourceType") -Or
            ($_ -eq "Start-LMBImport/ResourceType")
        }
        {
            $v = "BOT","INTENT","SLOT_TYPE"
            break
        }

        # Amazon.LexModelBuildingService.SlotValueSelectionStrategy
        "Write-LMBSlotType/ValueSelectionStrategy"
        {
            $v = "ORIGINAL_VALUE","TOP_RESOLUTION"
            break
        }

        # Amazon.LexModelBuildingService.StatusType
        "Get-LMBUtterancesView/StatusType"
        {
            $v = "Detected","Missed"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LMB_map = @{
    "ExportType"=@("Get-LMBExport")
    "FulfillmentActivity_Type"=@("Write-LMBIntent")
    "Locale"=@("Get-LMBBuiltinIntentList","Get-LMBBuiltinSlotType","Write-LMBBot")
    "MergeStrategy"=@("Start-LMBImport")
    "ProcessBehavior"=@("Write-LMBBot")
    "ResourceType"=@("Get-LMBExport","Start-LMBImport")
    "StatusType"=@("Get-LMBUtterancesView")
    "ValueSelectionStrategy"=@("Write-LMBSlotType")
}

_awsArgumentCompleterRegistration $LMB_Completers $LMB_map

$LMB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LMB.$($commandName.Replace('-', ''))Cmdlet]"
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

$LMB_SelectMap = @{
    "Select"=@("New-LMBBotVersion",
               "New-LMBIntentVersion",
               "New-LMBSlotTypeVersion",
               "Remove-LMBBot",
               "Remove-LMBBotAlias",
               "Remove-LMBBotChannelAssociation",
               "Remove-LMBBotVersion",
               "Remove-LMBIntent",
               "Remove-LMBIntentVersion",
               "Remove-LMBSlotType",
               "Remove-LMBSlotTypeVersion",
               "Remove-LMBUtterance",
               "Get-LMBBot",
               "Get-LMBBotAlias",
               "Get-LMBBotAliasList",
               "Get-LMBBotChannelAssociation",
               "Get-LMBBotChannelAssociationList",
               "Get-LMBBotList",
               "Get-LMBBotVersionList",
               "Get-LMBBuiltinIntent",
               "Get-LMBBuiltinIntentList",
               "Get-LMBBuiltinSlotType",
               "Get-LMBExport",
               "Get-LMBImport",
               "Get-LMBIntent",
               "Get-LMBIntentList",
               "Get-LMBIntentVersion",
               "Get-LMBSlotType",
               "Get-LMBSlotTypeList",
               "Get-LMBSlotTypeVersionList",
               "Get-LMBUtterancesView",
               "Get-LMBResourceTag",
               "Write-LMBBot",
               "Write-LMBBotAlias",
               "Write-LMBIntent",
               "Write-LMBSlotType",
               "Start-LMBImport",
               "Add-LMBResourceTag",
               "Remove-LMBResourceTag")
}

_awsArgumentCompleterRegistration $LMB_SelectCompleters $LMB_SelectMap

