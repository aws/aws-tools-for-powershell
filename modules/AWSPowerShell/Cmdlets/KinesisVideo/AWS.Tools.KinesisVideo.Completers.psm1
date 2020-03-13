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

# Argument completions for service Amazon Kinesis Video Streams


$KV_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KinesisVideo.APIName
        "Get-KVDataEndpoint/APIName"
        {
            $v = "GET_CLIP","GET_DASH_STREAMING_SESSION_URL","GET_HLS_STREAMING_SESSION_URL","GET_MEDIA","GET_MEDIA_FOR_FRAGMENT_LIST","LIST_FRAGMENTS","PUT_MEDIA"
            break
        }

        # Amazon.KinesisVideo.ChannelRole
        "Get-KVSignalingChannelEndpoint/SingleMasterChannelEndpointConfiguration_Role"
        {
            $v = "MASTER","VIEWER"
            break
        }

        # Amazon.KinesisVideo.ChannelType
        "New-KVSignalingChannel/ChannelType"
        {
            $v = "SINGLE_MASTER"
            break
        }

        # Amazon.KinesisVideo.ComparisonOperator
        "Get-KVSignalingChannelList/ChannelNameCondition_ComparisonOperator"
        {
            $v = "BEGINS_WITH"
            break
        }

        # Amazon.KinesisVideo.UpdateDataRetentionOperation
        "Update-KVDataRetention/Operation"
        {
            $v = "DECREASE_DATA_RETENTION","INCREASE_DATA_RETENTION"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KV_map = @{
    "APIName"=@("Get-KVDataEndpoint")
    "ChannelNameCondition_ComparisonOperator"=@("Get-KVSignalingChannelList")
    "ChannelType"=@("New-KVSignalingChannel")
    "Operation"=@("Update-KVDataRetention")
    "SingleMasterChannelEndpointConfiguration_Role"=@("Get-KVSignalingChannelEndpoint")
}

_awsArgumentCompleterRegistration $KV_Completers $KV_map

$KV_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KV.$($commandName.Replace('-', ''))Cmdlet]"
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

$KV_SelectMap = @{
    "Select"=@("New-KVSignalingChannel",
               "New-KVStream",
               "Remove-KVSignalingChannel",
               "Remove-KVStream",
               "Get-KVSignalingChannel",
               "Get-KVStream",
               "Get-KVDataEndpoint",
               "Get-KVSignalingChannelEndpoint",
               "Get-KVSignalingChannelList",
               "Get-KVStreamList",
               "Get-KVResourceTag",
               "Get-KVTagsForStreamList",
               "Add-KVResourceTag",
               "Add-KVStreamTag",
               "Remove-KVResourceTag",
               "Remove-KVStreamTag",
               "Update-KVDataRetention",
               "Update-KVSignalingChannel",
               "Update-KVStream")
}

_awsArgumentCompleterRegistration $KV_SelectCompleters $KV_SelectMap

