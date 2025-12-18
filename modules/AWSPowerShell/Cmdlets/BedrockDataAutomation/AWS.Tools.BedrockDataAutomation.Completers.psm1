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

# Argument completions for service Data Automation for Amazon Bedrock


$BDA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BedrockDataAutomation.AudioGenerativeOutputLanguage
        {
            ($_ -eq "New-BDADataAutomationProject/LanguageConfiguration_GenerativeOutputLanguage") -Or
            ($_ -eq "Update-BDADataAutomationProject/LanguageConfiguration_GenerativeOutputLanguage")
        }
        {
            $v = "DEFAULT","EN"
            break
        }

        # Amazon.BedrockDataAutomation.BlueprintStage
        {
            ($_ -eq "Invoke-BDABlueprintOptimizationAsync/Blueprint_Stage") -Or
            ($_ -eq "Get-BDADataAutomationProjectList/BlueprintFilter_BlueprintStage") -Or
            ($_ -eq "Get-BDABlueprint/BlueprintStage") -Or
            ($_ -eq "New-BDABlueprint/BlueprintStage") -Or
            ($_ -eq "Update-BDABlueprint/BlueprintStage") -Or
            ($_ -eq "Copy-BDABlueprintStage/SourceStage") -Or
            ($_ -eq "Copy-BDABlueprintStage/TargetStage")
        }
        {
            $v = "DEVELOPMENT","LIVE"
            break
        }

        # Amazon.BedrockDataAutomation.BlueprintStageFilter
        "Get-BDABlueprintList/BlueprintStageFilter"
        {
            $v = "ALL","DEVELOPMENT","LIVE"
            break
        }

        # Amazon.BedrockDataAutomation.DataAutomationProjectStage
        {
            ($_ -eq "Get-BDABlueprintList/ProjectFilter_ProjectStage") -Or
            ($_ -eq "Get-BDADataAutomationProject/ProjectStage") -Or
            ($_ -eq "New-BDADataAutomationProject/ProjectStage") -Or
            ($_ -eq "Update-BDADataAutomationProject/ProjectStage")
        }
        {
            $v = "DEVELOPMENT","LIVE"
            break
        }

        # Amazon.BedrockDataAutomation.DataAutomationProjectStageFilter
        "Get-BDADataAutomationProjectList/ProjectStageFilter"
        {
            $v = "ALL","DEVELOPMENT","LIVE"
            break
        }

        # Amazon.BedrockDataAutomation.DataAutomationProjectType
        "New-BDADataAutomationProject/ProjectType"
        {
            $v = "ASYNC","SYNC"
            break
        }

        # Amazon.BedrockDataAutomation.DesiredModality
        {
            ($_ -eq "New-BDADataAutomationProject/ModalityRouting_Jpeg") -Or
            ($_ -eq "Update-BDADataAutomationProject/ModalityRouting_Jpeg") -Or
            ($_ -eq "New-BDADataAutomationProject/ModalityRouting_Mov") -Or
            ($_ -eq "Update-BDADataAutomationProject/ModalityRouting_Mov") -Or
            ($_ -eq "New-BDADataAutomationProject/ModalityRouting_Mp4") -Or
            ($_ -eq "Update-BDADataAutomationProject/ModalityRouting_Mp4") -Or
            ($_ -eq "New-BDADataAutomationProject/ModalityRouting_Png") -Or
            ($_ -eq "Update-BDADataAutomationProject/ModalityRouting_Png")
        }
        {
            $v = "AUDIO","DOCUMENT","IMAGE","VIDEO"
            break
        }

        # Amazon.BedrockDataAutomation.PIIRedactionMaskMode
        {
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode")
        }
        {
            $v = "ENTITY_TYPE","PII"
            break
        }

        # Amazon.BedrockDataAutomation.ResourceOwner
        {
            ($_ -eq "Get-BDABlueprintList/ResourceOwner") -Or
            ($_ -eq "Get-BDADataAutomationProjectList/ResourceOwner")
        }
        {
            $v = "ACCOUNT","SERVICE"
            break
        }

        # Amazon.BedrockDataAutomation.SensitiveDataDetectionMode
        {
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode")
        }
        {
            $v = "DETECTION","DETECTION_AND_REDACTION"
            break
        }

        # Amazon.BedrockDataAutomation.State
        {
            ($_ -eq "New-BDADataAutomationProject/AdditionalFileFormat_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/AdditionalFileFormat_State") -Or
            ($_ -eq "New-BDADataAutomationProject/ChannelLabeling_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/ChannelLabeling_State") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Audio_ModalityProcessing_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Audio_ModalityProcessing_State") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Document_ModalityProcessing_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Document_ModalityProcessing_State") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Image_ModalityProcessing_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Image_ModalityProcessing_State") -Or
            ($_ -eq "New-BDADataAutomationProject/OverrideConfiguration_Video_ModalityProcessing_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/OverrideConfiguration_Video_ModalityProcessing_State") -Or
            ($_ -eq "New-BDADataAutomationProject/SpeakerLabeling_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/SpeakerLabeling_State") -Or
            ($_ -eq "New-BDADataAutomationProject/Splitter_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/Splitter_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Audio_Extraction_Category_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Audio_Extraction_Category_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Audio_GenerativeField_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Audio_GenerativeField_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Document_Extraction_BoundingBox_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Document_Extraction_BoundingBox_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Document_GenerativeField_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Document_GenerativeField_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Image_Extraction_BoundingBox_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Image_Extraction_BoundingBox_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Image_Extraction_Category_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Image_Extraction_Category_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Image_GenerativeField_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Image_GenerativeField_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Video_Extraction_BoundingBox_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Video_Extraction_BoundingBox_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Video_Extraction_Category_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Video_Extraction_Category_State") -Or
            ($_ -eq "New-BDADataAutomationProject/StandardOutputConfiguration_Video_GenerativeField_State") -Or
            ($_ -eq "Update-BDADataAutomationProject/StandardOutputConfiguration_Video_GenerativeField_State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.BedrockDataAutomation.Type
        "New-BDABlueprint/Type"
        {
            $v = "AUDIO","DOCUMENT","IMAGE","VIDEO"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BDA_map = @{
    "AdditionalFileFormat_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "Blueprint_Stage"=@("Invoke-BDABlueprintOptimizationAsync")
    "BlueprintFilter_BlueprintStage"=@("Get-BDADataAutomationProjectList")
    "BlueprintStage"=@("Get-BDABlueprint","New-BDABlueprint","Update-BDABlueprint")
    "BlueprintStageFilter"=@("Get-BDABlueprintList")
    "ChannelLabeling_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "LanguageConfiguration_GenerativeOutputLanguage"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "ModalityRouting_Jpeg"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "ModalityRouting_Mov"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "ModalityRouting_Mp4"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "ModalityRouting_Png"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Audio_ModalityProcessing_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Audio_SensitiveDataConfiguration_DetectionMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Audio_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Document_ModalityProcessing_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Document_SensitiveDataConfiguration_DetectionMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Document_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Image_ModalityProcessing_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Image_SensitiveDataConfiguration_DetectionMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Image_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Video_ModalityProcessing_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Video_SensitiveDataConfiguration_DetectionMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "OverrideConfiguration_Video_SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "ProjectFilter_ProjectStage"=@("Get-BDABlueprintList")
    "ProjectStage"=@("Get-BDADataAutomationProject","New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "ProjectStageFilter"=@("Get-BDADataAutomationProjectList")
    "ProjectType"=@("New-BDADataAutomationProject")
    "ResourceOwner"=@("Get-BDABlueprintList","Get-BDADataAutomationProjectList")
    "SourceStage"=@("Copy-BDABlueprintStage")
    "SpeakerLabeling_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "Splitter_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Audio_Extraction_Category_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Audio_GenerativeField_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Document_Extraction_BoundingBox_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Document_GenerativeField_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Image_Extraction_BoundingBox_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Image_Extraction_Category_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Image_GenerativeField_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Video_Extraction_BoundingBox_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Video_Extraction_Category_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "StandardOutputConfiguration_Video_GenerativeField_State"=@("New-BDADataAutomationProject","Update-BDADataAutomationProject")
    "TargetStage"=@("Copy-BDABlueprintStage")
    "Type"=@("New-BDABlueprint")
}

_awsArgumentCompleterRegistration $BDA_Completers $BDA_map

$BDA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BDA.$($commandName.Replace('-', ''))Cmdlet]"
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

$BDA_SelectMap = @{
    "Select"=@("Copy-BDABlueprintStage",
               "New-BDABlueprint",
               "New-BDABlueprintVersion",
               "New-BDADataAutomationProject",
               "Remove-BDABlueprint",
               "Remove-BDADataAutomationProject",
               "Get-BDABlueprint",
               "Get-BDABlueprintOptimizationStatus",
               "Get-BDADataAutomationProject",
               "Invoke-BDABlueprintOptimizationAsync",
               "Get-BDABlueprintList",
               "Get-BDADataAutomationProjectList",
               "Get-BDAResourceTag",
               "Add-BDAResourceTag",
               "Remove-BDAResourceTag",
               "Update-BDABlueprint",
               "Update-BDADataAutomationProject")
}

_awsArgumentCompleterRegistration $BDA_SelectCompleters $BDA_SelectMap

