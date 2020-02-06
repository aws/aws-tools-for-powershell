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

# Argument completions for service Amazon DynamoDB


$DDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DynamoDBv2.BackupTypeFilter
        "Get-DDBBackupList/BackupType"
        {
            $v = "ALL","AWS_BACKUP","SYSTEM","USER"
            break
        }

        # Amazon.DynamoDBv2.BillingMode
        {
            ($_ -eq "Update-DDBTable/BillingMode") -Or
            ($_ -eq "Restore-DDBTableFromBackup/BillingModeOverride") -Or
            ($_ -eq "Restore-DDBTableToPointInTime/BillingModeOverride") -Or
            ($_ -eq "Update-DDBGlobalTableSetting/GlobalTableBillingMode")
        }
        {
            $v = "PAY_PER_REQUEST","PROVISIONED"
            break
        }

        # Amazon.DynamoDBv2.ContributorInsightsAction
        "Update-DDBContributorInsight/ContributorInsightsAction"
        {
            $v = "DISABLE","ENABLE"
            break
        }

        # Amazon.DynamoDBv2.KeyType
        "Add-DDBKeySchema/KeyType"
        {
            $v = "HASH","RANGE"
            break
        }

        # Amazon.DynamoDBv2.ProjectionType
        "Add-DDBIndexSchema/ProjectionType"
        {
            $v = "ALL","INCLUDE","KEYS_ONLY"
            break
        }

        # Amazon.DynamoDBv2.ReturnConsumedCapacity
        {
            ($_ -eq "Get-DDBItemTransactionally/ReturnConsumedCapacity") -Or
            ($_ -eq "Write-DDBItemTransactionally/ReturnConsumedCapacity")
        }
        {
            $v = "INDEXES","NONE","TOTAL"
            break
        }

        # Amazon.DynamoDBv2.ReturnItemCollectionMetrics
        "Write-DDBItemTransactionally/ReturnItemCollectionMetrics"
        {
            $v = "NONE","SIZE"
            break
        }

        # Amazon.DynamoDBv2.ScalarAttributeType
        {
            ($_ -eq "Add-DDBIndexSchema/HashKeyDataType") -Or
            ($_ -eq "Add-DDBKeySchema/KeyDataType") -Or
            ($_ -eq "Add-DDBIndexSchema/RangeKeyDataType")
        }
        {
            $v = "B","N","S"
            break
        }

        # Amazon.DynamoDBv2.SSEType
        {
            ($_ -eq "Update-DDBTable/SSESpecification_SSEType") -Or
            ($_ -eq "Restore-DDBTableFromBackup/SSESpecificationOverride_SSEType") -Or
            ($_ -eq "Restore-DDBTableToPointInTime/SSESpecificationOverride_SSEType")
        }
        {
            $v = "AES256","KMS"
            break
        }

        # Amazon.DynamoDBv2.StreamViewType
        "Update-DDBTable/StreamSpecification_StreamViewType"
        {
            $v = "KEYS_ONLY","NEW_AND_OLD_IMAGES","NEW_IMAGE","OLD_IMAGE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DDB_map = @{
    "BackupType"=@("Get-DDBBackupList")
    "BillingMode"=@("Update-DDBTable")
    "BillingModeOverride"=@("Restore-DDBTableFromBackup","Restore-DDBTableToPointInTime")
    "ContributorInsightsAction"=@("Update-DDBContributorInsight")
    "GlobalTableBillingMode"=@("Update-DDBGlobalTableSetting")
    "HashKeyDataType"=@("Add-DDBIndexSchema")
    "KeyDataType"=@("Add-DDBKeySchema")
    "KeyType"=@("Add-DDBKeySchema")
    "ProjectionType"=@("Add-DDBIndexSchema")
    "RangeKeyDataType"=@("Add-DDBIndexSchema")
    "ReturnConsumedCapacity"=@("Get-DDBItemTransactionally","Write-DDBItemTransactionally")
    "ReturnItemCollectionMetrics"=@("Write-DDBItemTransactionally")
    "SSESpecification_SSEType"=@("Update-DDBTable")
    "SSESpecificationOverride_SSEType"=@("Restore-DDBTableFromBackup","Restore-DDBTableToPointInTime")
    "StreamSpecification_StreamViewType"=@("Update-DDBTable")
}

_awsArgumentCompleterRegistration $DDB_Completers $DDB_map

$DDB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DDB.$($commandName.Replace('-', ''))Cmdlet]"
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

$DDB_SelectMap = @{
    "Select"=@("New-DDBBackup",
               "New-DDBGlobalTable",
               "Remove-DDBBackup",
               "Remove-DDBTable",
               "Get-DDBBackup",
               "Get-DDBContinuousBackup",
               "Get-DDBContributorInsight",
               "Get-DDBEndpoint",
               "Get-DDBGlobalTable",
               "Get-DDBGlobalTableSetting",
               "Get-DDBProvisionLimit",
               "Get-DDBTable",
               "Get-DDBTableReplicaAutoScaling",
               "Get-DDBTimeToLive",
               "Get-DDBBackupList",
               "Get-DDBContributorInsightList",
               "Get-DDBGlobalTableList",
               "Get-DDBTableList",
               "Get-DDBResourceTag",
               "Restore-DDBTableFromBackup",
               "Restore-DDBTableToPointInTime",
               "Add-DDBResourceTag",
               "Get-DDBItemTransactionally",
               "Write-DDBItemTransactionally",
               "Remove-DDBResourceTag",
               "Update-DDBContinuousBackup",
               "Update-DDBContributorInsight",
               "Update-DDBGlobalTable",
               "Update-DDBGlobalTableSetting",
               "Update-DDBTable",
               "Update-DDBTableReplicaAutoScaling",
               "Update-DDBTimeToLive",
               "Add-DDBIndexSchema",
               "Add-DDBKeySchema",
               "New-DDBTable",
               "New-DDBTableSchema")
}

_awsArgumentCompleterRegistration $DDB_SelectCompleters $DDB_SelectMap
# Argument completions for service Amazon DynamoDB


$DDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DynamoDBv2.KeyType
        "Add-DDBKeySchema/KeyType"
        {
            $v = "HASH","RANGE"
            break
        }

        # Amazon.DynamoDBv2.ProjectionType
        "Add-DDBIndexSchema/ProjectionType"
        {
            $v = "ALL","INCLUDE","KEYS_ONLY"
            break
        }

        # Amazon.DynamoDBv2.ScalarAttributeType
        {
            ($_ -eq "Add-DDBIndexSchema/HashKeyDataType") -Or
            ($_ -eq "Add-DDBKeySchema/KeyDataType") -Or
            ($_ -eq "Add-DDBIndexSchema/RangeKeyDataType")
        }
        {
            $v = "B","N","S"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DDB_map = @{
    "HashKeyDataType"=@("Add-DDBIndexSchema")
    "KeyDataType"=@("Add-DDBKeySchema")
    "KeyType"=@("Add-DDBKeySchema")
    "ProjectionType"=@("Add-DDBIndexSchema")
    "RangeKeyDataType"=@("Add-DDBIndexSchema")
}

_awsArgumentCompleterRegistration $DDB_Completers $DDB_map

$DDB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DDB.$($commandName.Replace('-', ''))Cmdlet]"
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

$DDB_SelectMap = @{
    "Select"=@("Get-DDBStream",
               "Get-DDBStreamList",
               "Add-DDBIndexSchema",
               "Add-DDBKeySchema",
               "New-DDBTable",
               "New-DDBTableSchema")
}

_awsArgumentCompleterRegistration $DDB_SelectCompleters $DDB_SelectMap

