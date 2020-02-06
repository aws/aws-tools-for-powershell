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

# Argument completions for service AWS Database Migration Service


$DMS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DatabaseMigrationService.AuthMechanismValue
        {
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_AuthMechanism") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_AuthMechanism")
        }
        {
            $v = "default","mongodb_cr","scram_sha_1"
            break
        }

        # Amazon.DatabaseMigrationService.AuthTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_AuthType") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_AuthType")
        }
        {
            $v = "no","password"
            break
        }

        # Amazon.DatabaseMigrationService.CompressionTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_CompressionType") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_CompressionType")
        }
        {
            $v = "gzip","none"
            break
        }

        # Amazon.DatabaseMigrationService.DataFormatValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_DataFormat") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_DataFormat")
        }
        {
            $v = "csv","parquet"
            break
        }

        # Amazon.DatabaseMigrationService.DmsSslModeValue
        {
            ($_ -eq "Edit-DMSEndpoint/SslMode") -Or
            ($_ -eq "New-DMSEndpoint/SslMode")
        }
        {
            $v = "none","require","verify-ca","verify-full"
            break
        }

        # Amazon.DatabaseMigrationService.EncodingTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_EncodingType") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_EncodingType")
        }
        {
            $v = "plain","plain-dictionary","rle-dictionary"
            break
        }

        # Amazon.DatabaseMigrationService.EncryptionModeValue
        {
            ($_ -eq "Edit-DMSEndpoint/RedshiftSettings_EncryptionMode") -Or
            ($_ -eq "New-DMSEndpoint/RedshiftSettings_EncryptionMode") -Or
            ($_ -eq "Edit-DMSEndpoint/S3Settings_EncryptionMode") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_EncryptionMode")
        }
        {
            $v = "sse-kms","sse-s3"
            break
        }

        # Amazon.DatabaseMigrationService.MessageFormatValue
        {
            ($_ -eq "Edit-DMSEndpoint/KinesisSettings_MessageFormat") -Or
            ($_ -eq "New-DMSEndpoint/KinesisSettings_MessageFormat")
        }
        {
            $v = "json","json-unformatted"
            break
        }

        # Amazon.DatabaseMigrationService.MigrationTypeValue
        {
            ($_ -eq "Edit-DMSReplicationTask/MigrationType") -Or
            ($_ -eq "New-DMSReplicationTask/MigrationType")
        }
        {
            $v = "cdc","full-load","full-load-and-cdc"
            break
        }

        # Amazon.DatabaseMigrationService.NestingLevelValue
        {
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_NestingLevel") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_NestingLevel")
        }
        {
            $v = "none","one"
            break
        }

        # Amazon.DatabaseMigrationService.ParquetVersionValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_ParquetVersion") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_ParquetVersion")
        }
        {
            $v = "parquet-1-0","parquet-2-0"
            break
        }

        # Amazon.DatabaseMigrationService.ReloadOptionValue
        "Restore-DMSTable/ReloadOption"
        {
            $v = "data-reload","validate-only"
            break
        }

        # Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/EndpointType") -Or
            ($_ -eq "New-DMSEndpoint/EndpointType")
        }
        {
            $v = "source","target"
            break
        }

        # Amazon.DatabaseMigrationService.SourceType
        "Get-DMSEvent/SourceType"
        {
            $v = "replication-instance"
            break
        }

        # Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue
        "Start-DMSReplicationTask/StartReplicationTaskType"
        {
            $v = "reload-target","resume-processing","start-replication"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DMS_map = @{
    "EndpointType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "KinesisSettings_MessageFormat"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MigrationType"=@("Edit-DMSReplicationTask","New-DMSReplicationTask")
    "MongoDbSettings_AuthMechanism"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MongoDbSettings_AuthType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MongoDbSettings_NestingLevel"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "RedshiftSettings_EncryptionMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "ReloadOption"=@("Restore-DMSTable")
    "S3Settings_CompressionType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_DataFormat"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_EncodingType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_EncryptionMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_ParquetVersion"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "SourceType"=@("Get-DMSEvent")
    "SslMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "StartReplicationTaskType"=@("Start-DMSReplicationTask")
}

_awsArgumentCompleterRegistration $DMS_Completers $DMS_map

$DMS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DMS.$($commandName.Replace('-', ''))Cmdlet]"
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

$DMS_SelectMap = @{
    "Select"=@("Set-DMSResourceTag",
               "Complete-DMSPendingMaintenanceAction",
               "New-DMSEndpoint",
               "New-DMSEventSubscription",
               "New-DMSReplicationInstance",
               "New-DMSReplicationSubnetGroup",
               "New-DMSReplicationTask",
               "Remove-DMSCertificate",
               "Remove-DMSConnection",
               "Remove-DMSEndpoint",
               "Remove-DMSEventSubscription",
               "Remove-DMSReplicationInstance",
               "Remove-DMSReplicationSubnetGroup",
               "Remove-DMSReplicationTask",
               "Get-DMSAccountAttribute",
               "Get-DMSCertificate",
               "Get-DMSConnection",
               "Get-DMSEndpoint",
               "Get-DMSEndpointType",
               "Get-DMSEventCategory",
               "Get-DMSEvent",
               "Get-DMSEventSubscription",
               "Get-DMSOrderableReplicationInstance",
               "Get-DMSPendingMaintenanceAction",
               "Get-DMSRefreshSchemasStatus",
               "Get-DMSReplicationInstance",
               "Get-DMSReplicationInstanceTaskLog",
               "Get-DMSReplicationSubnetGroup",
               "Get-DMSReplicationTaskAssessmentResult",
               "Get-DMSReplicationTask",
               "Get-DMSSchema",
               "Get-DMSTableStatistic",
               "Import-DMSCertificate",
               "Get-DMSResourceTag",
               "Edit-DMSEndpoint",
               "Edit-DMSEventSubscription",
               "Edit-DMSReplicationInstance",
               "Edit-DMSReplicationSubnetGroup",
               "Edit-DMSReplicationTask",
               "Restart-DMSReplicationInstance",
               "Invoke-DMSSchemaRefresh",
               "Restore-DMSTable",
               "Remove-DMSResourceTag",
               "Start-DMSReplicationTask",
               "Start-DMSReplicationTaskAssessment",
               "Stop-DMSReplicationTask",
               "Test-DMSConnection")
}

_awsArgumentCompleterRegistration $DMS_SelectCompleters $DMS_SelectMap

