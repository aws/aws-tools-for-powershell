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

# Argument completions for service Amazon Braket


$BRKT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Braket.CompressionType
        "New-BRKTJob/ScriptModeConfig_CompressionType"
        {
            $v = "GZIP","NONE"
            break
        }

        # Amazon.Braket.ExperimentalCapabilitiesEnablementType
        "New-BRKTQuantumTask/ExperimentalCapabilities_Enabled"
        {
            $v = "ALL","NONE"
            break
        }

        # Amazon.Braket.InstanceType
        "New-BRKTJob/InstanceConfig_InstanceType"
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c5n.18xlarge","ml.c5n.2xlarge","ml.c5n.4xlarge","ml.c5n.9xlarge","ml.c5n.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.p3dn.24xlarge","ml.p4d.24xlarge"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BRKT_map = @{
    "ExperimentalCapabilities_Enabled"=@("New-BRKTQuantumTask")
    "InstanceConfig_InstanceType"=@("New-BRKTJob")
    "ScriptModeConfig_CompressionType"=@("New-BRKTJob")
}

_awsArgumentCompleterRegistration $BRKT_Completers $BRKT_map

$BRKT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BRKT.$($commandName.Replace('-', ''))Cmdlet]"
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

$BRKT_SelectMap = @{
    "Select"=@("Stop-BRKTJob",
               "Stop-BRKTQuantumTask",
               "New-BRKTJob",
               "New-BRKTQuantumTask",
               "Get-BRKTDevice",
               "Get-BRKTJob",
               "Get-BRKTQuantumTask",
               "Get-BRKTResourceTag",
               "Search-BRKTDevice",
               "Search-BRKTJob",
               "Search-BRKTQuantumTask",
               "Add-BRKTResourceTag",
               "Remove-BRKTResourceTag")
}

_awsArgumentCompleterRegistration $BRKT_SelectCompleters $BRKT_SelectMap

