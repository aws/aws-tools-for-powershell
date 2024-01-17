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

# Argument completions for service Amazon Keyspaces


$KS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Keyspaces.ClientSideTimestampsStatus
        {
            ($_ -eq "New-KSTable/ClientSideTimestamps_Status") -Or
            ($_ -eq "Update-KSTable/ClientSideTimestamps_Status")
        }
        {
            $v = "ENABLED"
            break
        }

        # Amazon.Keyspaces.EncryptionType
        {
            ($_ -eq "New-KSTable/EncryptionSpecification_Type") -Or
            ($_ -eq "Update-KSTable/EncryptionSpecification_Type") -Or
            ($_ -eq "Restore-KSTable/EncryptionSpecificationOverride_Type")
        }
        {
            $v = "AWS_OWNED_KMS_KEY","CUSTOMER_MANAGED_KMS_KEY"
            break
        }

        # Amazon.Keyspaces.PointInTimeRecoveryStatus
        {
            ($_ -eq "New-KSTable/PointInTimeRecovery_Status") -Or
            ($_ -eq "Update-KSTable/PointInTimeRecovery_Status") -Or
            ($_ -eq "Restore-KSTable/PointInTimeRecoveryOverride_Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Keyspaces.Rs
        "New-KSKeyspace/ReplicationSpecification_ReplicationStrategy"
        {
            $v = "MULTI_REGION","SINGLE_REGION"
            break
        }

        # Amazon.Keyspaces.ThroughputMode
        {
            ($_ -eq "New-KSTable/CapacitySpecification_ThroughputMode") -Or
            ($_ -eq "Update-KSTable/CapacitySpecification_ThroughputMode") -Or
            ($_ -eq "Restore-KSTable/CapacitySpecificationOverride_ThroughputMode")
        }
        {
            $v = "PAY_PER_REQUEST","PROVISIONED"
            break
        }

        # Amazon.Keyspaces.TimeToLiveStatus
        {
            ($_ -eq "New-KSTable/Ttl_Status") -Or
            ($_ -eq "Update-KSTable/Ttl_Status")
        }
        {
            $v = "ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KS_map = @{
    "CapacitySpecification_ThroughputMode"=@("New-KSTable","Update-KSTable")
    "CapacitySpecificationOverride_ThroughputMode"=@("Restore-KSTable")
    "ClientSideTimestamps_Status"=@("New-KSTable","Update-KSTable")
    "EncryptionSpecification_Type"=@("New-KSTable","Update-KSTable")
    "EncryptionSpecificationOverride_Type"=@("Restore-KSTable")
    "PointInTimeRecovery_Status"=@("New-KSTable","Update-KSTable")
    "PointInTimeRecoveryOverride_Status"=@("Restore-KSTable")
    "ReplicationSpecification_ReplicationStrategy"=@("New-KSKeyspace")
    "Ttl_Status"=@("New-KSTable","Update-KSTable")
}

_awsArgumentCompleterRegistration $KS_Completers $KS_map

$KS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KS.$($commandName.Replace('-', ''))Cmdlet]"
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

$KS_SelectMap = @{
    "Select"=@("New-KSKeyspace",
               "New-KSTable",
               "Remove-KSKeyspace",
               "Remove-KSTable",
               "Get-KSKeyspace",
               "Get-KSTable",
               "Get-KSTableAutoScalingSetting",
               "Get-KSKeyspaceList",
               "Get-KSTableList",
               "Get-KSResourceTag",
               "Restore-KSTable",
               "Add-KSResourceTag",
               "Remove-KSResourceTag",
               "Update-KSTable")
}

_awsArgumentCompleterRegistration $KS_SelectCompleters $KS_SelectMap

