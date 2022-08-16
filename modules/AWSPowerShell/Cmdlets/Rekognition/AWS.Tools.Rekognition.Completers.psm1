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

# Argument completions for service Amazon Rekognition


$REK_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Rekognition.CelebrityRecognitionSortBy
        "Get-REKCelebrityRecognition/SortBy"
        {
            $v = "ID","TIMESTAMP"
            break
        }

        # Amazon.Rekognition.ContentModerationSortBy
        "Get-REKContentModeration/SortBy"
        {
            $v = "NAME","TIMESTAMP"
            break
        }

        # Amazon.Rekognition.DatasetType
        "New-REKDataset/DatasetType"
        {
            $v = "TEST","TRAIN"
            break
        }

        # Amazon.Rekognition.FaceAttributes
        "Start-REKFaceDetection/FaceAttributes"
        {
            $v = "ALL","DEFAULT"
            break
        }

        # Amazon.Rekognition.FaceSearchSortBy
        "Get-REKFaceSearch/SortBy"
        {
            $v = "INDEX","TIMESTAMP"
            break
        }

        # Amazon.Rekognition.LabelDetectionSortBy
        "Get-REKLabelDetection/SortBy"
        {
            $v = "NAME","TIMESTAMP"
            break
        }

        # Amazon.Rekognition.PersonTrackingSortBy
        "Get-REKPersonTracking/SortBy"
        {
            $v = "INDEX","TIMESTAMP"
            break
        }

        # Amazon.Rekognition.QualityFilter
        {
            ($_ -eq "Add-REKDetectedFacesToCollection/QualityFilter") -Or
            ($_ -eq "Compare-REKFace/QualityFilter") -Or
            ($_ -eq "Search-REKFacesByImage/QualityFilter")
        }
        {
            $v = "AUTO","HIGH","LOW","MEDIUM","NONE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$REK_map = @{
    "DatasetType"=@("New-REKDataset")
    "FaceAttributes"=@("Start-REKFaceDetection")
    "QualityFilter"=@("Add-REKDetectedFacesToCollection","Compare-REKFace","Search-REKFacesByImage")
    "SortBy"=@("Get-REKCelebrityRecognition","Get-REKContentModeration","Get-REKFaceSearch","Get-REKLabelDetection","Get-REKPersonTracking")
}

_awsArgumentCompleterRegistration $REK_Completers $REK_map

$REK_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.REK.$($commandName.Replace('-', ''))Cmdlet]"
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

$REK_SelectMap = @{
    "Select"=@("Compare-REKFace",
               "Copy-REKProjectVersion",
               "New-REKCollection",
               "New-REKDataset",
               "New-REKProject",
               "New-REKProjectVersion",
               "New-REKStreamProcessor",
               "Remove-REKCollection",
               "Remove-REKDataset",
               "Remove-REKFace",
               "Remove-REKProject",
               "Remove-REKProjectPolicy",
               "Remove-REKProjectVersion",
               "Remove-REKStreamProcessor",
               "Get-REKCollection",
               "Get-REKDataset",
               "Get-REKProject",
               "Get-REKProjectVersion",
               "Get-REKStreamProcessor",
               "Find-REKCustomLabel",
               "Find-REKFace",
               "Find-REKLabel",
               "Find-REKModerationLabel",
               "Find-REKProtectiveEquipment",
               "Find-REKText",
               "Invoke-REKDistributeDatasetEntry",
               "Get-REKCelebrityInfo",
               "Get-REKCelebrityRecognition",
               "Get-REKContentModeration",
               "Get-REKFaceDetection",
               "Get-REKFaceSearch",
               "Get-REKLabelDetection",
               "Get-REKPersonTracking",
               "Get-REKSegmentDetection",
               "Get-REKTextDetection",
               "Add-REKDetectedFacesToCollection",
               "Get-REKCollectionIdList",
               "Get-REKDatasetEntryList",
               "Get-REKDatasetLabelList",
               "Get-REKFaceList",
               "Get-REKProjectPolicyList",
               "Get-REKStreamProcessorList",
               "Get-REKResourceTag",
               "Write-REKProjectPolicy",
               "Find-REKCelebrity",
               "Search-REKFace",
               "Search-REKFacesByImage",
               "Start-REKCelebrityRecognition",
               "Start-REKContentModeration",
               "Start-REKFaceDetection",
               "Start-REKFaceSearch",
               "Start-REKLabelDetection",
               "Start-REKPersonTracking",
               "Start-REKProjectVersion",
               "Start-REKSegmentDetection",
               "Start-REKStreamProcessor",
               "Start-REKTextDetection",
               "Stop-REKProjectVersion",
               "Stop-REKStreamProcessor",
               "Add-REKResourceTag",
               "Remove-REKResourceTag",
               "Update-REKDatasetEntry",
               "Update-REKStreamProcessor")
}

_awsArgumentCompleterRegistration $REK_SelectCompleters $REK_SelectMap

