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
        # Amazon.DynamoDBv2.ApproximateCreationDateTimePrecision
        {
            ($_ -eq "Disable-DDBKinesisStreamingDestination/EnableKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision") -Or
            ($_ -eq "Enable-DDBKinesisStreamingDestination/EnableKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision") -Or
            ($_ -eq "Update-DDBKinesisStreamingDestination/UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision")
        }
        {
            $v = "MICROSECOND","MILLISECOND"
            break
        }

        # Amazon.DynamoDBv2.BackupTypeFilter
        "Get-DDBBackupList/BackupType"
        {
            $v = "ALL","AWS_BACKUP","SYSTEM","USER"
            break
        }

        # Amazon.DynamoDBv2.BillingMode
        {
            ($_ -eq "New-DDBTable/BillingMode") -Or
            ($_ -eq "Update-DDBTable/BillingMode") -Or
            ($_ -eq "Restore-DDBTableFromBackup/BillingModeOverride") -Or
            ($_ -eq "Restore-DDBTableToPointInTime/BillingModeOverride") -Or
            ($_ -eq "Update-DDBGlobalTableSetting/GlobalTableBillingMode") -Or
            ($_ -eq "Import-DDBTable/TableCreationParameters_BillingMode")
        }
        {
            $v = "PAY_PER_REQUEST","PROVISIONED"
            break
        }

        # Amazon.DynamoDBv2.ConditionalOperator
        {
            ($_ -eq "Invoke-DDBQuery/ConditionalOperator") -Or
            ($_ -eq "Invoke-DDBScan/ConditionalOperator") -Or
            ($_ -eq "Remove-DDBItem/ConditionalOperator") -Or
            ($_ -eq "Set-DDBItem/ConditionalOperator") -Or
            ($_ -eq "Update-DDBItem/ConditionalOperator")
        }
        {
            $v = "AND","OR"
            break
        }

        # Amazon.DynamoDBv2.ContributorInsightsAction
        "Update-DDBContributorInsight/ContributorInsightsAction"
        {
            $v = "DISABLE","ENABLE"
            break
        }

        # Amazon.DynamoDBv2.ExportFormat
        "Export-DDBTableToPointInTime/ExportFormat"
        {
            $v = "DYNAMODB_JSON","ION"
            break
        }

        # Amazon.DynamoDBv2.ExportType
        "Export-DDBTableToPointInTime/ExportType"
        {
            $v = "FULL_EXPORT","INCREMENTAL_EXPORT"
            break
        }

        # Amazon.DynamoDBv2.ExportViewType
        "Export-DDBTableToPointInTime/IncrementalExportSpecification_ExportViewType"
        {
            $v = "NEW_AND_OLD_IMAGES","NEW_IMAGE"
            break
        }

        # Amazon.DynamoDBv2.InputCompressionType
        "Import-DDBTable/InputCompressionType"
        {
            $v = "GZIP","NONE","ZSTD"
            break
        }

        # Amazon.DynamoDBv2.InputFormat
        "Import-DDBTable/InputFormat"
        {
            $v = "CSV","DYNAMODB_JSON","ION"
            break
        }

        # Amazon.DynamoDBv2.KeyType
        "Add-DDBKeySchema/KeyType"
        {
            $v = "HASH","RANGE"
            break
        }

        # Amazon.DynamoDBv2.MultiRegionConsistency
        "Update-DDBTable/MultiRegionConsistency"
        {
            $v = "EVENTUAL","STRONG"
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
            ($_ -eq "Get-DDBBatchItem/ReturnConsumedCapacity") -Or
            ($_ -eq "Get-DDBItem/ReturnConsumedCapacity") -Or
            ($_ -eq "Get-DDBItemTransactionally/ReturnConsumedCapacity") -Or
            ($_ -eq "Invoke-DDBDDBBatchExecuteStatement/ReturnConsumedCapacity") -Or
            ($_ -eq "Invoke-DDBDDBExecuteStatement/ReturnConsumedCapacity") -Or
            ($_ -eq "Invoke-DDBDDBExecuteTransaction/ReturnConsumedCapacity") -Or
            ($_ -eq "Invoke-DDBQuery/ReturnConsumedCapacity") -Or
            ($_ -eq "Invoke-DDBScan/ReturnConsumedCapacity") -Or
            ($_ -eq "Remove-DDBItem/ReturnConsumedCapacity") -Or
            ($_ -eq "Set-DDBBatchItem/ReturnConsumedCapacity") -Or
            ($_ -eq "Set-DDBItem/ReturnConsumedCapacity") -Or
            ($_ -eq "Update-DDBItem/ReturnConsumedCapacity") -Or
            ($_ -eq "Write-DDBItemTransactionally/ReturnConsumedCapacity")
        }
        {
            $v = "INDEXES","NONE","TOTAL"
            break
        }

        # Amazon.DynamoDBv2.ReturnItemCollectionMetrics
        {
            ($_ -eq "Remove-DDBItem/ReturnItemCollectionMetric") -Or
            ($_ -eq "Set-DDBBatchItem/ReturnItemCollectionMetric") -Or
            ($_ -eq "Set-DDBItem/ReturnItemCollectionMetric") -Or
            ($_ -eq "Update-DDBItem/ReturnItemCollectionMetric") -Or
            ($_ -eq "Write-DDBItemTransactionally/ReturnItemCollectionMetric")
        }
        {
            $v = "NONE","SIZE"
            break
        }

        # Amazon.DynamoDBv2.ReturnValue
        {
            ($_ -eq "Remove-DDBItem/ReturnValue") -Or
            ($_ -eq "Set-DDBItem/ReturnValue") -Or
            ($_ -eq "Update-DDBItem/ReturnValue")
        }
        {
            $v = "ALL_NEW","ALL_OLD","NONE","UPDATED_NEW","UPDATED_OLD"
            break
        }

        # Amazon.DynamoDBv2.ReturnValuesOnConditionCheckFailure
        {
            ($_ -eq "Invoke-DDBDDBExecuteStatement/ReturnValuesOnConditionCheckFailure") -Or
            ($_ -eq "Remove-DDBItem/ReturnValuesOnConditionCheckFailure") -Or
            ($_ -eq "Set-DDBItem/ReturnValuesOnConditionCheckFailure") -Or
            ($_ -eq "Update-DDBItem/ReturnValuesOnConditionCheckFailure")
        }
        {
            $v = "ALL_OLD","NONE"
            break
        }

        # Amazon.DynamoDBv2.S3SseAlgorithm
        "Export-DDBTableToPointInTime/S3SseAlgorithm"
        {
            $v = "AES256","KMS"
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

        # Amazon.DynamoDBv2.Select
        {
            ($_ -eq "Invoke-DDBQuery/SelectItem") -Or
            ($_ -eq "Invoke-DDBScan/SelectItem")
        }
        {
            $v = "ALL_ATTRIBUTES","ALL_PROJECTED_ATTRIBUTES","COUNT","SPECIFIC_ATTRIBUTES"
            break
        }

        # Amazon.DynamoDBv2.SSEType
        {
            ($_ -eq "Import-DDBTable/SSESpecification_SSEType") -Or
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

        # Amazon.DynamoDBv2.TableClass
        "Update-DDBTable/TableClass"
        {
            $v = "STANDARD","STANDARD_INFREQUENT_ACCESS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DDB_map = @{
    "BackupType"=@("Get-DDBBackupList")
    "BillingMode"=@("New-DDBTable","Update-DDBTable")
    "BillingModeOverride"=@("Restore-DDBTableFromBackup","Restore-DDBTableToPointInTime")
    "ConditionalOperator"=@("Invoke-DDBQuery","Invoke-DDBScan","Remove-DDBItem","Set-DDBItem","Update-DDBItem")
    "ContributorInsightsAction"=@("Update-DDBContributorInsight")
    "EnableKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision"=@("Disable-DDBKinesisStreamingDestination","Enable-DDBKinesisStreamingDestination")
    "ExportFormat"=@("Export-DDBTableToPointInTime")
    "ExportType"=@("Export-DDBTableToPointInTime")
    "GlobalTableBillingMode"=@("Update-DDBGlobalTableSetting")
    "HashKeyDataType"=@("Add-DDBIndexSchema")
    "IncrementalExportSpecification_ExportViewType"=@("Export-DDBTableToPointInTime")
    "InputCompressionType"=@("Import-DDBTable")
    "InputFormat"=@("Import-DDBTable")
    "KeyDataType"=@("Add-DDBKeySchema")
    "KeyType"=@("Add-DDBKeySchema")
    "MultiRegionConsistency"=@("Update-DDBTable")
    "ProjectionType"=@("Add-DDBIndexSchema")
    "RangeKeyDataType"=@("Add-DDBIndexSchema")
    "ReturnConsumedCapacity"=@("Get-DDBBatchItem","Get-DDBItem","Get-DDBItemTransactionally","Invoke-DDBDDBBatchExecuteStatement","Invoke-DDBDDBExecuteStatement","Invoke-DDBDDBExecuteTransaction","Invoke-DDBQuery","Invoke-DDBScan","Remove-DDBItem","Set-DDBBatchItem","Set-DDBItem","Update-DDBItem","Write-DDBItemTransactionally")
    "ReturnItemCollectionMetric"=@("Remove-DDBItem","Set-DDBBatchItem","Set-DDBItem","Update-DDBItem","Write-DDBItemTransactionally")
    "ReturnValue"=@("Remove-DDBItem","Set-DDBItem","Update-DDBItem")
    "ReturnValuesOnConditionCheckFailure"=@("Invoke-DDBDDBExecuteStatement","Remove-DDBItem","Set-DDBItem","Update-DDBItem")
    "S3SseAlgorithm"=@("Export-DDBTableToPointInTime")
    "SelectItem"=@("Invoke-DDBQuery","Invoke-DDBScan")
    "SSESpecification_SSEType"=@("Import-DDBTable","Update-DDBTable")
    "SSESpecificationOverride_SSEType"=@("Restore-DDBTableFromBackup","Restore-DDBTableToPointInTime")
    "StreamSpecification_StreamViewType"=@("Update-DDBTable")
    "TableClass"=@("Update-DDBTable")
    "TableCreationParameters_BillingMode"=@("Import-DDBTable")
    "UpdateKinesisStreamingConfiguration_ApproximateCreationDateTimePrecision"=@("Update-DDBKinesisStreamingDestination")
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
    "Select"=@("Invoke-DDBDDBBatchExecuteStatement",
               "Get-DDBBatchItem",
               "Set-DDBBatchItem",
               "New-DDBBackup",
               "New-DDBGlobalTable",
               "Remove-DDBBackup",
               "Remove-DDBItem",
               "Remove-DDBResourcePolicy",
               "Remove-DDBTable",
               "Get-DDBBackup",
               "Get-DDBContinuousBackup",
               "Get-DDBContributorInsight",
               "Get-DDBEndpoint",
               "Get-DDBExport",
               "Get-DDBGlobalTable",
               "Get-DDBGlobalTableSetting",
               "Get-DDBImport",
               "Get-DDBKinesisStreamingDestination",
               "Get-DDBProvisionLimit",
               "Get-DDBTable",
               "Get-DDBTableReplicaAutoScaling",
               "Get-DDBTimeToLive",
               "Disable-DDBKinesisStreamingDestination",
               "Enable-DDBKinesisStreamingDestination",
               "Invoke-DDBDDBExecuteStatement",
               "Invoke-DDBDDBExecuteTransaction",
               "Export-DDBTableToPointInTime",
               "Get-DDBItem",
               "Get-DDBResourcePolicy",
               "Import-DDBTable",
               "Get-DDBBackupList",
               "Get-DDBContributorInsightList",
               "Get-DDBExportList",
               "Get-DDBGlobalTableList",
               "Get-DDBImportList",
               "Get-DDBTableList",
               "Get-DDBResourceTag",
               "Set-DDBItem",
               "Write-DDBResourcePolicy",
               "Invoke-DDBQuery",
               "Restore-DDBTableFromBackup",
               "Restore-DDBTableToPointInTime",
               "Invoke-DDBScan",
               "Add-DDBResourceTag",
               "Get-DDBItemTransactionally",
               "Write-DDBItemTransactionally",
               "Remove-DDBResourceTag",
               "Update-DDBContinuousBackup",
               "Update-DDBContributorInsight",
               "Update-DDBGlobalTable",
               "Update-DDBGlobalTableSetting",
               "Update-DDBItem",
               "Update-DDBKinesisStreamingDestination",
               "Update-DDBTable",
               "Update-DDBTableReplicaAutoScaling",
               "Update-DDBTimeToLive",
               "Add-DDBIndexSchema",
               "Add-DDBKeySchema",
               "ConvertFrom-DDBItem",
               "ConvertTo-DDBItem",
               "New-DDBTable",
               "New-DDBTableSchema")
}

_awsArgumentCompleterRegistration $DDB_SelectCompleters $DDB_SelectMap
# Argument completions for service Amazon DynamoDB


$DDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DynamoDBv2.BillingMode
        "New-DDBTable/BillingMode"
        {
            $v = "PAY_PER_REQUEST","PROVISIONED"
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
    "BillingMode"=@("New-DDBTable")
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
               "ConvertFrom-DDBItem",
               "ConvertTo-DDBItem",
               "New-DDBTable",
               "New-DDBTableSchema")
}

_awsArgumentCompleterRegistration $DDB_SelectCompleters $DDB_SelectMap

