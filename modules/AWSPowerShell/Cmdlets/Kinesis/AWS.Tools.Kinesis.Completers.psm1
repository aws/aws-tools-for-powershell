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

# Argument completions for service Amazon Kinesis


$KIN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Kinesis.EncryptionType
        {
            ($_ -eq "Start-KINStreamEncryption/EncryptionType") -Or
            ($_ -eq "Stop-KINStreamEncryption/EncryptionType")
        }
        {
            $v = "KMS","NONE"
            break
        }

        # Amazon.Kinesis.ScalingType
        "Update-KINShardCount/ScalingType"
        {
            $v = "UNIFORM_SCALING"
            break
        }

        # Amazon.Kinesis.ShardFilterType
        "Get-KINShardList/ShardFilter_Type"
        {
            $v = "AFTER_SHARD_ID","AT_LATEST","AT_TIMESTAMP","AT_TRIM_HORIZON","FROM_TIMESTAMP","FROM_TRIM_HORIZON"
            break
        }

        # Amazon.Kinesis.ShardIteratorType
        "Get-KINShardIterator/ShardIteratorType"
        {
            $v = "AFTER_SEQUENCE_NUMBER","AT_SEQUENCE_NUMBER","AT_TIMESTAMP","LATEST","TRIM_HORIZON"
            break
        }

        # Amazon.Kinesis.StreamMode
        {
            ($_ -eq "New-KINStream/StreamModeDetails_StreamMode") -Or
            ($_ -eq "Update-KINStreamMode/StreamModeDetails_StreamMode")
        }
        {
            $v = "ON_DEMAND","PROVISIONED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KIN_map = @{
    "EncryptionType"=@("Start-KINStreamEncryption","Stop-KINStreamEncryption")
    "ScalingType"=@("Update-KINShardCount")
    "ShardFilter_Type"=@("Get-KINShardList")
    "ShardIteratorType"=@("Get-KINShardIterator")
    "StreamModeDetails_StreamMode"=@("New-KINStream","Update-KINStreamMode")
}

_awsArgumentCompleterRegistration $KIN_Completers $KIN_map

$KIN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KIN.$($commandName.Replace('-', ''))Cmdlet]"
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

$KIN_SelectMap = @{
    "Select"=@("Add-KINTagsToStream",
               "New-KINStream",
               "Request-KINStreamRetentionPeriodDecrease",
               "Remove-KINResourcePolicy",
               "Remove-KINStream",
               "Unregister-KINStreamConsumer",
               "Get-KINLimit",
               "Get-KINStream",
               "Get-KINStreamConsumer",
               "Get-KINStreamSummary",
               "Disable-KINEnhancedMonitoring",
               "Enable-KINEnhancedMonitoring",
               "Get-KINRecord",
               "Get-KINResourcePolicy",
               "Get-KINShardIterator",
               "Request-KINStreamRetentionPeriodIncrease",
               "Get-KINShardList",
               "Get-KINStreamConsumerList",
               "Get-KINStreamList",
               "Get-KINResourceTag",
               "Get-KINTagsForStream",
               "Merge-KINShard",
               "Write-KINRecord",
               "Write-KINMultipleRecord",
               "Write-KINResourcePolicy",
               "Register-KINStreamConsumer",
               "Remove-KINTagsFromStream",
               "Split-KINShard",
               "Start-KINStreamEncryption",
               "Stop-KINStreamEncryption",
               "Add-KINResourceTag",
               "Remove-KINResourceTag",
               "Update-KINShardCount",
               "Update-KINStreamMode")
}

_awsArgumentCompleterRegistration $KIN_SelectCompleters $KIN_SelectMap

