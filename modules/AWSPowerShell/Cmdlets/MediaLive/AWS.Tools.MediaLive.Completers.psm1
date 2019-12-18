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

# Argument completions for service AWS Elemental MediaLive


$EML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaLive.ChannelClass
        {
            ($_ -eq "New-EMLChannel/ChannelClass") -Or
            ($_ -eq "Update-EMLChannelClass/ChannelClass")
        }
        {
            $v = "SINGLE_PIPELINE","STANDARD"
            break
        }

        # Amazon.MediaLive.InputCodec
        {
            ($_ -eq "New-EMLChannel/InputSpecification_Codec") -Or
            ($_ -eq "Update-EMLChannel/InputSpecification_Codec")
        }
        {
            $v = "AVC","HEVC","MPEG2"
            break
        }

        # Amazon.MediaLive.InputMaximumBitrate
        {
            ($_ -eq "New-EMLChannel/InputSpecification_MaximumBitrate") -Or
            ($_ -eq "Update-EMLChannel/InputSpecification_MaximumBitrate")
        }
        {
            $v = "MAX_10_MBPS","MAX_20_MBPS","MAX_50_MBPS"
            break
        }

        # Amazon.MediaLive.InputResolution
        {
            ($_ -eq "New-EMLChannel/InputSpecification_Resolution") -Or
            ($_ -eq "Update-EMLChannel/InputSpecification_Resolution")
        }
        {
            $v = "HD","SD","UHD"
            break
        }

        # Amazon.MediaLive.InputType
        "New-EMLInput/Type"
        {
            $v = "MEDIACONNECT","MP4_FILE","RTMP_PULL","RTMP_PUSH","RTP_PUSH","UDP_PUSH","URL_PULL"
            break
        }

        # Amazon.MediaLive.LogLevel
        {
            ($_ -eq "New-EMLChannel/LogLevel") -Or
            ($_ -eq "Update-EMLChannel/LogLevel")
        }
        {
            $v = "DEBUG","DISABLED","ERROR","INFO","WARNING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EML_map = @{
    "ChannelClass"=@("New-EMLChannel","Update-EMLChannelClass")
    "InputSpecification_Codec"=@("New-EMLChannel","Update-EMLChannel")
    "InputSpecification_MaximumBitrate"=@("New-EMLChannel","Update-EMLChannel")
    "InputSpecification_Resolution"=@("New-EMLChannel","Update-EMLChannel")
    "LogLevel"=@("New-EMLChannel","Update-EMLChannel")
    "Type"=@("New-EMLInput")
}

_awsArgumentCompleterRegistration $EML_Completers $EML_map

$EML_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EML.$($commandName.Replace('-', ''))Cmdlet]"
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

$EML_SelectMap = @{
    "Select"=@("Update-EMLScheduleBatch",
               "New-EMLChannel",
               "New-EMLInput",
               "New-EMLInputSecurityGroup",
               "New-EMLMultiplex",
               "New-EMLMultiplexProgram",
               "Add-EMLResourceTag",
               "Remove-EMLChannel",
               "Remove-EMLInput",
               "Remove-EMLInputSecurityGroup",
               "Remove-EMLMultiplex",
               "Remove-EMLMultiplexProgram",
               "Remove-EMLReservation",
               "Remove-EMLSchedule",
               "Remove-EMLResourceTag",
               "Get-EMLChannel",
               "Get-EMLInput",
               "Get-EMLInputSecurityGroup",
               "Get-EMLMultiplex",
               "Get-EMLMultiplexProgram",
               "Get-EMLOffering",
               "Get-EMLReservation",
               "Get-EMLSchedule",
               "Get-EMLChannelList",
               "Get-EMLInputList",
               "Get-EMLInputSecurityGroupList",
               "Get-EMLMultiplexList",
               "Get-EMLMultiplexProgramList",
               "Get-EMLOfferingList",
               "Get-EMLReservationList",
               "Get-EMLResourceTag",
               "New-EMLOfferingPurchase",
               "Start-EMLChannel",
               "Start-EMLMultiplex",
               "Stop-EMLChannel",
               "Stop-EMLMultiplex",
               "Update-EMLChannel",
               "Update-EMLChannelClass",
               "Update-EMLInput",
               "Update-EMLInputSecurityGroup",
               "Update-EMLMultiplex",
               "Update-EMLMultiplexProgram",
               "Update-EMLReservation")
}

_awsArgumentCompleterRegistration $EML_SelectCompleters $EML_SelectMap

