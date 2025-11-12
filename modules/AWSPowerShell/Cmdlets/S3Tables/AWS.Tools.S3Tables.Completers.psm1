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

# Argument completions for service Amazon S3 Tables


$S3T_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.S3Tables.IcebergCompactionStrategy
        "Write-S3TTableMaintenanceConfiguration/IcebergCompaction_Strategy"
        {
            $v = "auto","binpack","sort","z-order"
            break
        }

        # Amazon.S3Tables.MaintenanceStatus
        {
            ($_ -eq "Write-S3TTableBucketMaintenanceConfiguration/Value_Status") -Or
            ($_ -eq "Write-S3TTableMaintenanceConfiguration/Value_Status")
        }
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.S3Tables.OpenTableFormat
        "New-S3TTable/Format"
        {
            $v = "ICEBERG"
            break
        }

        # Amazon.S3Tables.SSEAlgorithm
        {
            ($_ -eq "New-S3TTable/EncryptionConfiguration_SseAlgorithm") -Or
            ($_ -eq "New-S3TTableBucket/EncryptionConfiguration_SseAlgorithm") -Or
            ($_ -eq "Write-S3TTableBucketEncryption/EncryptionConfiguration_SseAlgorithm")
        }
        {
            $v = "AES256","aws:kms"
            break
        }

        # Amazon.S3Tables.TableBucketMaintenanceType
        "Write-S3TTableBucketMaintenanceConfiguration/Type"
        {
            $v = "icebergUnreferencedFileRemoval"
            break
        }

        # Amazon.S3Tables.TableBucketType
        "Get-S3TTableBucketList/Type"
        {
            $v = "aws","customer"
            break
        }

        # Amazon.S3Tables.TableMaintenanceType
        "Write-S3TTableMaintenanceConfiguration/Type"
        {
            $v = "icebergCompaction","icebergSnapshotManagement"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$S3T_map = @{
    "EncryptionConfiguration_SseAlgorithm"=@("New-S3TTable","New-S3TTableBucket","Write-S3TTableBucketEncryption")
    "Format"=@("New-S3TTable")
    "IcebergCompaction_Strategy"=@("Write-S3TTableMaintenanceConfiguration")
    "Type"=@("Get-S3TTableBucketList","Write-S3TTableBucketMaintenanceConfiguration","Write-S3TTableMaintenanceConfiguration")
    "Value_Status"=@("Write-S3TTableBucketMaintenanceConfiguration","Write-S3TTableMaintenanceConfiguration")
}

_awsArgumentCompleterRegistration $S3T_Completers $S3T_map

$S3T_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.S3T.$($commandName.Replace('-', ''))Cmdlet]"
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

$S3T_SelectMap = @{
    "Select"=@("New-S3TNamespace",
               "New-S3TTable",
               "New-S3TTableBucket",
               "Remove-S3TNamespace",
               "Remove-S3TTable",
               "Remove-S3TTableBucket",
               "Remove-S3TTableBucketEncryption",
               "Remove-S3TTableBucketMetricsConfiguration",
               "Remove-S3TTableBucketPolicy",
               "Remove-S3TTablePolicy",
               "Get-S3TNamespace",
               "Get-S3TTable",
               "Get-S3TTableBucket",
               "Get-S3TTableBucketEncryption",
               "Get-S3TTableBucketMaintenanceConfiguration",
               "Get-S3TTableBucketMetricsConfiguration",
               "Get-S3TTableBucketPolicy",
               "Get-S3TTableEncryption",
               "Get-S3TTableMaintenanceConfiguration",
               "Get-S3TTableMaintenanceJobStatus",
               "Get-S3TTableMetadataLocation",
               "Get-S3TTablePolicy",
               "Get-S3TNamespaceList",
               "Get-S3TTableBucketList",
               "Get-S3TTableList",
               "Get-S3TResourceTag",
               "Write-S3TTableBucketEncryption",
               "Write-S3TTableBucketMaintenanceConfiguration",
               "Write-S3TTableBucketMetricsConfiguration",
               "Write-S3TTableBucketPolicy",
               "Write-S3TTableMaintenanceConfiguration",
               "Write-S3TTablePolicy",
               "Rename-S3TTable",
               "Add-S3TResourceTag",
               "Remove-S3TResourceTag",
               "Update-S3TTableMetadataLocation")
}

_awsArgumentCompleterRegistration $S3T_SelectCompleters $S3T_SelectMap

