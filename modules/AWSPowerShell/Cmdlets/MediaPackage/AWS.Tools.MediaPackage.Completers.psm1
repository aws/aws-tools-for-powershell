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

# Argument completions for service AWS Elemental MediaPackage


$EMP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaPackage.CmafEncryptionMethod
        {
            ($_ -eq "New-EMPOriginEndpoint/CmafPackage_Encryption_EncryptionMethod") -Or
            ($_ -eq "Update-EMPOriginEndpoint/CmafPackage_Encryption_EncryptionMethod")
        }
        {
            $v = "AES_CTR","SAMPLE_AES"
            break
        }

        # Amazon.MediaPackage.Origination
        {
            ($_ -eq "New-EMPOriginEndpoint/Origination") -Or
            ($_ -eq "Update-EMPOriginEndpoint/Origination")
        }
        {
            $v = "ALLOW","DENY"
            break
        }

        # Amazon.MediaPackage.PresetSpeke20Audio
        {
            ($_ -eq "New-EMPOriginEndpoint/CmafPackage_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Audio") -Or
            ($_ -eq "Update-EMPOriginEndpoint/CmafPackage_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Audio")
        }
        {
            $v = "PRESET-AUDIO-1","PRESET-AUDIO-2","PRESET-AUDIO-3","SHARED","UNENCRYPTED"
            break
        }

        # Amazon.MediaPackage.PresetSpeke20Video
        {
            ($_ -eq "New-EMPOriginEndpoint/CmafPackage_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Video") -Or
            ($_ -eq "Update-EMPOriginEndpoint/CmafPackage_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Video")
        }
        {
            $v = "PRESET-VIDEO-1","PRESET-VIDEO-2","PRESET-VIDEO-3","PRESET-VIDEO-4","PRESET-VIDEO-5","PRESET-VIDEO-6","PRESET-VIDEO-7","PRESET-VIDEO-8","SHARED","UNENCRYPTED"
            break
        }

        # Amazon.MediaPackage.StreamOrder
        {
            ($_ -eq "New-EMPOriginEndpoint/CmafPackage_StreamSelection_StreamOrder") -Or
            ($_ -eq "Update-EMPOriginEndpoint/CmafPackage_StreamSelection_StreamOrder")
        }
        {
            $v = "ORIGINAL","VIDEO_BITRATE_ASCENDING","VIDEO_BITRATE_DESCENDING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMP_map = @{
    "CmafPackage_Encryption_EncryptionMethod"=@("New-EMPOriginEndpoint","Update-EMPOriginEndpoint")
    "CmafPackage_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Audio"=@("New-EMPOriginEndpoint","Update-EMPOriginEndpoint")
    "CmafPackage_Encryption_SpekeKeyProvider_EncryptionContractConfiguration_PresetSpeke20Video"=@("New-EMPOriginEndpoint","Update-EMPOriginEndpoint")
    "CmafPackage_StreamSelection_StreamOrder"=@("New-EMPOriginEndpoint","Update-EMPOriginEndpoint")
    "Origination"=@("New-EMPOriginEndpoint","Update-EMPOriginEndpoint")
}

_awsArgumentCompleterRegistration $EMP_Completers $EMP_map

$EMP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EMP.$($commandName.Replace('-', ''))Cmdlet]"
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

$EMP_SelectMap = @{
    "Select"=@("Update-EMPLogConfiguration",
               "New-EMPChannel",
               "New-EMPHarvestJob",
               "New-EMPOriginEndpoint",
               "Remove-EMPChannel",
               "Remove-EMPOriginEndpoint",
               "Get-EMPChannel",
               "Get-EMPHarvestJob",
               "Get-EMPOriginEndpoint",
               "Get-EMPChannelList",
               "Get-EMPHarvestJobList",
               "Get-EMPOriginEndpointList",
               "Get-EMPResourceTag",
               "Invoke-EMPChannelCredentialRotation",
               "Invoke-EMPIngestEndpointCredentialRotation",
               "Add-EMPResourceTag",
               "Remove-EMPResourceTag",
               "Update-EMPChannel",
               "Update-EMPOriginEndpoint")
}

_awsArgumentCompleterRegistration $EMP_SelectCompleters $EMP_SelectMap

