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

# Argument completions for service AWS Elemental MediaPackage v2


$MPV2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaPackageV2.CmafEncryptionMethod
        {
            ($_ -eq "New-MPV2OriginEndpoint/EncryptionMethod_CmafEncryptionMethod") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/EncryptionMethod_CmafEncryptionMethod")
        }
        {
            $v = "CBCS","CENC"
            break
        }

        # Amazon.MediaPackageV2.ContainerType
        {
            ($_ -eq "New-MPV2OriginEndpoint/ContainerType") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/ContainerType")
        }
        {
            $v = "CMAF","ISM","TS"
            break
        }

        # Amazon.MediaPackageV2.HarvestJobStatus
        "Get-MPV2HarvestJobList/Status"
        {
            $v = "CANCELLED","COMPLETED","FAILED","IN_PROGRESS","QUEUED"
            break
        }

        # Amazon.MediaPackageV2.InputType
        "New-MPV2Channel/InputType"
        {
            $v = "CMAF","HLS"
            break
        }

        # Amazon.MediaPackageV2.IsmEncryptionMethod
        {
            ($_ -eq "New-MPV2OriginEndpoint/EncryptionMethod_IsmEncryptionMethod") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/EncryptionMethod_IsmEncryptionMethod")
        }
        {
            $v = "CENC"
            break
        }

        # Amazon.MediaPackageV2.PresetSpeke20Audio
        {
            ($_ -eq "New-MPV2OriginEndpoint/EncryptionContractConfiguration_PresetSpeke20Audio") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/EncryptionContractConfiguration_PresetSpeke20Audio")
        }
        {
            $v = "PRESET_AUDIO_1","PRESET_AUDIO_2","PRESET_AUDIO_3","SHARED","UNENCRYPTED"
            break
        }

        # Amazon.MediaPackageV2.PresetSpeke20Video
        {
            ($_ -eq "New-MPV2OriginEndpoint/EncryptionContractConfiguration_PresetSpeke20Video") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/EncryptionContractConfiguration_PresetSpeke20Video")
        }
        {
            $v = "PRESET_VIDEO_1","PRESET_VIDEO_2","PRESET_VIDEO_3","PRESET_VIDEO_4","PRESET_VIDEO_5","PRESET_VIDEO_6","PRESET_VIDEO_7","PRESET_VIDEO_8","SHARED","UNENCRYPTED"
            break
        }

        # Amazon.MediaPackageV2.ScteInSegments
        {
            ($_ -eq "New-MPV2OriginEndpoint/Scte_ScteInSegment") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/Scte_ScteInSegment")
        }
        {
            $v = "ALL","NONE"
            break
        }

        # Amazon.MediaPackageV2.TsEncryptionMethod
        {
            ($_ -eq "New-MPV2OriginEndpoint/EncryptionMethod_TsEncryptionMethod") -Or
            ($_ -eq "Update-MPV2OriginEndpoint/EncryptionMethod_TsEncryptionMethod")
        }
        {
            $v = "AES_128","SAMPLE_AES"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MPV2_map = @{
    "ContainerType"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "EncryptionContractConfiguration_PresetSpeke20Audio"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "EncryptionContractConfiguration_PresetSpeke20Video"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "EncryptionMethod_CmafEncryptionMethod"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "EncryptionMethod_IsmEncryptionMethod"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "EncryptionMethod_TsEncryptionMethod"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "InputType"=@("New-MPV2Channel")
    "Scte_ScteInSegment"=@("New-MPV2OriginEndpoint","Update-MPV2OriginEndpoint")
    "Status"=@("Get-MPV2HarvestJobList")
}

_awsArgumentCompleterRegistration $MPV2_Completers $MPV2_map

$MPV2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MPV2.$($commandName.Replace('-', ''))Cmdlet]"
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

$MPV2_SelectMap = @{
    "Select"=@("Stop-MPV2HarvestJob",
               "New-MPV2Channel",
               "New-MPV2ChannelGroup",
               "New-MPV2HarvestJob",
               "New-MPV2OriginEndpoint",
               "Remove-MPV2Channel",
               "Remove-MPV2ChannelGroup",
               "Remove-MPV2ChannelPolicy",
               "Remove-MPV2OriginEndpoint",
               "Remove-MPV2OriginEndpointPolicy",
               "Get-MPV2Channel",
               "Get-MPV2ChannelGroup",
               "Get-MPV2ChannelPolicy",
               "Get-MPV2HarvestJob",
               "Get-MPV2OriginEndpoint",
               "Get-MPV2OriginEndpointPolicy",
               "Get-MPV2ChannelGroupList",
               "Get-MPV2ChannelList",
               "Get-MPV2HarvestJobList",
               "Get-MPV2OriginEndpointList",
               "Get-MPV2ResourceTag",
               "Write-MPV2ChannelPolicy",
               "Write-MPV2OriginEndpointPolicy",
               "Reset-MPV2ChannelState",
               "Reset-MPV2OriginEndpointState",
               "Add-MPV2ResourceTag",
               "Remove-MPV2ResourceTag",
               "Update-MPV2Channel",
               "Update-MPV2ChannelGroup",
               "Update-MPV2OriginEndpoint")
}

_awsArgumentCompleterRegistration $MPV2_SelectCompleters $MPV2_SelectMap

