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

        # Amazon.DatabaseMigrationService.CannedAclForObjectsValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_CannedAclForObjects") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_CannedAclForObjects")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","none","private","public-read","public-read-write"
            break
        }

        # Amazon.DatabaseMigrationService.CharLengthSemantics
        {
            ($_ -eq "Edit-DMSEndpoint/OracleSettings_CharLengthSemantics") -Or
            ($_ -eq "New-DMSEndpoint/OracleSettings_CharLengthSemantics")
        }
        {
            $v = "byte","char","default"
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

        # Amazon.DatabaseMigrationService.DatabaseMode
        {
            ($_ -eq "Edit-DMSEndpoint/PostgreSQLSettings_DatabaseMode") -Or
            ($_ -eq "New-DMSEndpoint/PostgreSQLSettings_DatabaseMode")
        }
        {
            $v = "babelfish","default"
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

        # Amazon.DatabaseMigrationService.DatePartitionDelimiterValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_DatePartitionDelimiter") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_DatePartitionDelimiter")
        }
        {
            $v = "DASH","NONE","SLASH","UNDERSCORE"
            break
        }

        # Amazon.DatabaseMigrationService.DatePartitionSequenceValue
        {
            ($_ -eq "Edit-DMSEndpoint/S3Settings_DatePartitionSequence") -Or
            ($_ -eq "New-DMSEndpoint/S3Settings_DatePartitionSequence")
        }
        {
            $v = "DDMMYYYY","MMYYYYDD","YYYYMM","YYYYMMDD","YYYYMMDDHH"
            break
        }

        # Amazon.DatabaseMigrationService.DmsSslModeValue
        {
            ($_ -eq "Edit-DMSDataProvider/Settings_MicrosoftSqlServerSettings_SslMode") -Or
            ($_ -eq "New-DMSDataProvider/Settings_MicrosoftSqlServerSettings_SslMode") -Or
            ($_ -eq "Edit-DMSDataProvider/Settings_MySqlSettings_SslMode") -Or
            ($_ -eq "New-DMSDataProvider/Settings_MySqlSettings_SslMode") -Or
            ($_ -eq "Edit-DMSDataProvider/Settings_OracleSettings_SslMode") -Or
            ($_ -eq "New-DMSDataProvider/Settings_OracleSettings_SslMode") -Or
            ($_ -eq "Edit-DMSDataProvider/Settings_PostgreSqlSettings_SslMode") -Or
            ($_ -eq "New-DMSDataProvider/Settings_PostgreSqlSettings_SslMode") -Or
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

        # Amazon.DatabaseMigrationService.KafkaSaslMechanism
        {
            ($_ -eq "Edit-DMSEndpoint/KafkaSettings_SaslMechanism") -Or
            ($_ -eq "New-DMSEndpoint/KafkaSettings_SaslMechanism")
        }
        {
            $v = "plain","scram-sha-512"
            break
        }

        # Amazon.DatabaseMigrationService.KafkaSecurityProtocol
        {
            ($_ -eq "Edit-DMSEndpoint/KafkaSettings_SecurityProtocol") -Or
            ($_ -eq "New-DMSEndpoint/KafkaSettings_SecurityProtocol")
        }
        {
            $v = "plaintext","sasl-ssl","ssl-authentication","ssl-encryption"
            break
        }

        # Amazon.DatabaseMigrationService.KafkaSslEndpointIdentificationAlgorithm
        {
            ($_ -eq "Edit-DMSEndpoint/KafkaSettings_SslEndpointIdentificationAlgorithm") -Or
            ($_ -eq "New-DMSEndpoint/KafkaSettings_SslEndpointIdentificationAlgorithm")
        }
        {
            $v = "https","none"
            break
        }

        # Amazon.DatabaseMigrationService.LongVarcharMappingType
        {
            ($_ -eq "Edit-DMSEndpoint/PostgreSQLSettings_MapLongVarcharAs") -Or
            ($_ -eq "New-DMSEndpoint/PostgreSQLSettings_MapLongVarcharAs")
        }
        {
            $v = "clob","nclob","wstring"
            break
        }

        # Amazon.DatabaseMigrationService.MessageFormatValue
        {
            ($_ -eq "Edit-DMSEndpoint/KafkaSettings_MessageFormat") -Or
            ($_ -eq "New-DMSEndpoint/KafkaSettings_MessageFormat") -Or
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
            ($_ -eq "Get-DMSApplicableIndividualAssessment/MigrationType") -Or
            ($_ -eq "New-DMSReplicationTask/MigrationType") -Or
            ($_ -eq "Edit-DMSReplicationConfig/ReplicationType") -Or
            ($_ -eq "New-DMSReplicationConfig/ReplicationType")
        }
        {
            $v = "cdc","full-load","full-load-and-cdc"
            break
        }

        # Amazon.DatabaseMigrationService.NestingLevelValue
        {
            ($_ -eq "Edit-DMSEndpoint/DocDbSettings_NestingLevel") -Or
            ($_ -eq "New-DMSEndpoint/DocDbSettings_NestingLevel") -Or
            ($_ -eq "Edit-DMSEndpoint/MongoDbSettings_NestingLevel") -Or
            ($_ -eq "New-DMSEndpoint/MongoDbSettings_NestingLevel")
        }
        {
            $v = "none","one"
            break
        }

        # Amazon.DatabaseMigrationService.OriginTypeValue
        {
            ($_ -eq "Start-DMSMetadataModelExportAsScript/Origin") -Or
            ($_ -eq "Start-DMSMetadataModelImport/Origin")
        }
        {
            $v = "SOURCE","TARGET"
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

        # Amazon.DatabaseMigrationService.PluginNameValue
        {
            ($_ -eq "Edit-DMSEndpoint/PostgreSQLSettings_PluginName") -Or
            ($_ -eq "New-DMSEndpoint/PostgreSQLSettings_PluginName")
        }
        {
            $v = "no-preference","pglogical","test-decoding"
            break
        }

        # Amazon.DatabaseMigrationService.RedisAuthTypeValue
        {
            ($_ -eq "Edit-DMSEndpoint/RedisSettings_AuthType") -Or
            ($_ -eq "New-DMSEndpoint/RedisSettings_AuthType")
        }
        {
            $v = "auth-role","auth-token","none"
            break
        }

        # Amazon.DatabaseMigrationService.ReloadOptionValue
        {
            ($_ -eq "Restore-DMSReplicationTable/ReloadOption") -Or
            ($_ -eq "Restore-DMSTable/ReloadOption")
        }
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

        # Amazon.DatabaseMigrationService.SafeguardPolicy
        {
            ($_ -eq "Edit-DMSEndpoint/MicrosoftSQLServerSettings_SafeguardPolicy") -Or
            ($_ -eq "New-DMSEndpoint/MicrosoftSQLServerSettings_SafeguardPolicy")
        }
        {
            $v = "exclusive-automatic-truncation","rely-on-sql-server-replication-agent","shared-automatic-truncation"
            break
        }

        # Amazon.DatabaseMigrationService.SourceType
        "Get-DMSEvent/SourceType"
        {
            $v = "replication-instance"
            break
        }

        # Amazon.DatabaseMigrationService.SslSecurityProtocolValue
        {
            ($_ -eq "Edit-DMSEndpoint/RedisSettings_SslSecurityProtocol") -Or
            ($_ -eq "New-DMSEndpoint/RedisSettings_SslSecurityProtocol")
        }
        {
            $v = "plaintext","ssl-encryption"
            break
        }

        # Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue
        "Start-DMSReplicationTask/StartReplicationTaskType"
        {
            $v = "reload-target","resume-processing","start-replication"
            break
        }

        # Amazon.DatabaseMigrationService.TargetDbType
        {
            ($_ -eq "Edit-DMSEndpoint/GcpMySQLSettings_TargetDbType") -Or
            ($_ -eq "New-DMSEndpoint/GcpMySQLSettings_TargetDbType") -Or
            ($_ -eq "Edit-DMSEndpoint/MySQLSettings_TargetDbType") -Or
            ($_ -eq "New-DMSEndpoint/MySQLSettings_TargetDbType")
        }
        {
            $v = "multiple-databases","specific-database"
            break
        }

        # Amazon.DatabaseMigrationService.TlogAccessMode
        {
            ($_ -eq "Edit-DMSEndpoint/MicrosoftSQLServerSettings_TlogAccessMode") -Or
            ($_ -eq "New-DMSEndpoint/MicrosoftSQLServerSettings_TlogAccessMode")
        }
        {
            $v = "BackupOnly","PreferBackup","PreferTlog","TlogOnly"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DMS_map = @{
    "DocDbSettings_NestingLevel"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "EndpointType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "GcpMySQLSettings_TargetDbType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "KafkaSettings_MessageFormat"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "KafkaSettings_SaslMechanism"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "KafkaSettings_SecurityProtocol"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "KafkaSettings_SslEndpointIdentificationAlgorithm"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "KinesisSettings_MessageFormat"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MicrosoftSQLServerSettings_SafeguardPolicy"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MicrosoftSQLServerSettings_TlogAccessMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MigrationType"=@("Edit-DMSReplicationTask","Get-DMSApplicableIndividualAssessment","New-DMSReplicationTask")
    "MongoDbSettings_AuthMechanism"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MongoDbSettings_AuthType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MongoDbSettings_NestingLevel"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "MySQLSettings_TargetDbType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "OracleSettings_CharLengthSemantics"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "Origin"=@("Start-DMSMetadataModelExportAsScript","Start-DMSMetadataModelImport")
    "PostgreSQLSettings_DatabaseMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "PostgreSQLSettings_MapLongVarcharAs"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "PostgreSQLSettings_PluginName"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "RedisSettings_AuthType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "RedisSettings_SslSecurityProtocol"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "RedshiftSettings_EncryptionMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "ReloadOption"=@("Restore-DMSReplicationTable","Restore-DMSTable")
    "ReplicationType"=@("Edit-DMSReplicationConfig","New-DMSReplicationConfig")
    "S3Settings_CannedAclForObjects"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_CompressionType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_DataFormat"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_DatePartitionDelimiter"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_DatePartitionSequence"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_EncodingType"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_EncryptionMode"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "S3Settings_ParquetVersion"=@("Edit-DMSEndpoint","New-DMSEndpoint")
    "Settings_MicrosoftSqlServerSettings_SslMode"=@("Edit-DMSDataProvider","New-DMSDataProvider")
    "Settings_MySqlSettings_SslMode"=@("Edit-DMSDataProvider","New-DMSDataProvider")
    "Settings_OracleSettings_SslMode"=@("Edit-DMSDataProvider","New-DMSDataProvider")
    "Settings_PostgreSqlSettings_SslMode"=@("Edit-DMSDataProvider","New-DMSDataProvider")
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
               "Start-DMSBatchRecommendation",
               "Stop-DMSReplicationTaskAssessmentRun",
               "New-DMSDataProvider",
               "New-DMSEndpoint",
               "New-DMSEventSubscription",
               "New-DMSFleetAdvisorCollector",
               "New-DMSInstanceProfile",
               "New-DMSMigrationProject",
               "New-DMSReplicationConfig",
               "New-DMSReplicationInstance",
               "New-DMSReplicationSubnetGroup",
               "New-DMSReplicationTask",
               "Remove-DMSCertificate",
               "Remove-DMSConnection",
               "Remove-DMSDataProvider",
               "Remove-DMSEndpoint",
               "Remove-DMSEventSubscription",
               "Remove-DMSFleetAdvisorCollector",
               "Remove-DMSFleetAdvisorDatabaseId",
               "Remove-DMSInstanceProfile",
               "Remove-DMSMigrationProject",
               "Remove-DMSReplicationConfig",
               "Remove-DMSReplicationInstance",
               "Remove-DMSReplicationSubnetGroup",
               "Remove-DMSReplicationTask",
               "Remove-DMSReplicationTaskAssessmentRun",
               "Get-DMSAccountAttribute",
               "Get-DMSApplicableIndividualAssessment",
               "Get-DMSCertificate",
               "Get-DMSConnection",
               "Get-DMSConversionConfiguration",
               "Get-DMSDataProvider",
               "Get-DMSEndpoint",
               "Get-DMSEndpointSetting",
               "Get-DMSEndpointType",
               "Get-DMSEngineVersion",
               "Get-DMSEventCategory",
               "Get-DMSEvent",
               "Get-DMSEventSubscription",
               "Get-DMSExtensionPackAssociation",
               "Get-DMSFleetAdvisorCollector",
               "Get-DMSFleetAdvisorDatabase",
               "Get-DMSFleetAdvisorLsaAnalysis",
               "Get-DMSFleetAdvisorSchemaObjectSummary",
               "Get-DMSFleetAdvisorSchema",
               "Get-DMSInstanceProfile",
               "Get-DMSMetadataModelAssessment",
               "Get-DMSMetadataModelConversion",
               "Get-DMSMetadataModelExportsAsScript",
               "Get-DMSMetadataModelExportsToTarget",
               "Get-DMSMetadataModelImport",
               "Get-DMSMigrationProject",
               "Get-DMSOrderableReplicationInstance",
               "Get-DMSPendingMaintenanceAction",
               "Get-DMSRecommendationLimitation",
               "Get-DMSRecommendation",
               "Get-DMSRefreshSchemasStatus",
               "Get-DMSReplicationConfig",
               "Get-DMSReplicationInstance",
               "Get-DMSReplicationInstanceTaskLog",
               "Get-DMSReplication",
               "Get-DMSReplicationSubnetGroup",
               "Get-DMSReplicationTableStatistic",
               "Get-DMSReplicationTaskAssessmentResult",
               "Get-DMSReplicationTaskAssessmentRun",
               "Get-DMSReplicationTaskIndividualAssessment",
               "Get-DMSReplicationTask",
               "Get-DMSSchema",
               "Get-DMSTableStatistic",
               "Export-DMSMetadataModelAssessment",
               "Import-DMSCertificate",
               "Get-DMSResourceTag",
               "Edit-DMSConversionConfiguration",
               "Edit-DMSDataProvider",
               "Edit-DMSEndpoint",
               "Edit-DMSEventSubscription",
               "Edit-DMSInstanceProfile",
               "Edit-DMSMigrationProject",
               "Edit-DMSReplicationConfig",
               "Edit-DMSReplicationInstance",
               "Edit-DMSReplicationSubnetGroup",
               "Edit-DMSReplicationTask",
               "Move-DMSReplicationTask",
               "Restart-DMSReplicationInstance",
               "Invoke-DMSSchemaRefresh",
               "Restore-DMSReplicationTable",
               "Restore-DMSTable",
               "Remove-DMSResourceTag",
               "Start-DMSFleetAdvisorLsaAnalysis",
               "Start-DMSExtensionPackAssociation",
               "Start-DMSMetadataModelAssessment",
               "Start-DMSMetadataModelConversion",
               "Start-DMSMetadataModelExportAsScript",
               "Start-DMSMetadataModelExportToTarget",
               "Start-DMSMetadataModelImport",
               "Start-DMSRecommendation",
               "Start-DMSReplication",
               "Start-DMSReplicationTask",
               "Start-DMSReplicationTaskAssessment",
               "Start-DMSReplicationTaskAssessmentRun",
               "Stop-DMSReplication",
               "Stop-DMSReplicationTask",
               "Test-DMSConnection",
               "Update-DMSSubscriptionsToEventBridge")
}

_awsArgumentCompleterRegistration $DMS_SelectCompleters $DMS_SelectMap

