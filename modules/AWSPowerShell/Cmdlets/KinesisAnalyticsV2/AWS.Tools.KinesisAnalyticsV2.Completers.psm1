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

# Argument completions for service Amazon Kinesis Analytics V2


$KINA2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KinesisAnalyticsV2.ApplicationMode
        "New-KINA2Application/ApplicationMode"
        {
            $v = "INTERACTIVE","STREAMING"
            break
        }

        # Amazon.KinesisAnalyticsV2.KeyType
        {
            ($_ -eq "Import-KINA2Snapshot/DestinationEncryptionConfiguration_KeyType") -Or
            ($_ -eq "Export-KINA2Snapshot/ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType") -Or
            ($_ -eq "Import-KINA2Snapshot/ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType")
        }
        {
            $v = "AWS_OWNED_KEY","CUSTOMER_MANAGED_KEY"
            break
        }

        # Amazon.KinesisAnalyticsV2.OperationStatus
        "Get-KINA2ApplicationOperationList/OperationStatus"
        {
            $v = "CANCELLED","FAILED","IN_PROGRESS","SUCCESSFUL"
            break
        }

        # Amazon.KinesisAnalyticsV2.RuntimeEnvironment
        {
            ($_ -eq "New-KINA2Application/RuntimeEnvironment") -Or
            ($_ -eq "Update-KINA2Application/RuntimeEnvironmentUpdate")
        }
        {
            $v = "FLINK-1_11","FLINK-1_13","FLINK-1_15","FLINK-1_18","FLINK-1_19","FLINK-1_20","FLINK-1_6","FLINK-1_8","FLINK-2_2","FLINK-2_3","SQL-1_0","ZEPPELIN-FLINK-1_0","ZEPPELIN-FLINK-2_0","ZEPPELIN-FLINK-3_0"
            break
        }

        # Amazon.KinesisAnalyticsV2.SnapshotFormat
        "Import-KINA2Snapshot/SnapshotFormat"
        {
            $v = "CANONICAL"
            break
        }

        # Amazon.KinesisAnalyticsV2.SnapshotInitiator
        "Get-KINA2SnapshotList/SnapshotInitiator"
        {
            $v = "SYSTEM","USER"
            break
        }

        # Amazon.KinesisAnalyticsV2.SnapshotInitiatorOperation
        "Get-KINA2SnapshotList/SnapshotInitiatorOperation"
        {
            $v = "CreateSnapshot","ImportSnapshot","SystemCreateSnapshot"
            break
        }

        # Amazon.KinesisAnalyticsV2.SnapshotOperation
        "Get-KINA2SnapshotOperationList/SnapshotOperation"
        {
            $v = "CreateSnapshot","DeleteSnapshot","ExportSnapshot","ImportSnapshot","SystemCreateSnapshot"
            break
        }

        # Amazon.KinesisAnalyticsV2.SnapshotOperationStatus
        "Get-KINA2SnapshotOperationList/SnapshotOperationStatus"
        {
            $v = "CANCELLED","FAILED","IN_PROGRESS","SUCCESSFUL"
            break
        }

        # Amazon.KinesisAnalyticsV2.SnapshotStatus
        "Get-KINA2SnapshotList/SnapshotStatus"
        {
            $v = "CREATING","DELETING","FAILED","READY"
            break
        }

        # Amazon.KinesisAnalyticsV2.StorageLocationType
        {
            ($_ -eq "Export-KINA2Snapshot/ExportDestinationConfiguration_DestinationType") -Or
            ($_ -eq "Import-KINA2Snapshot/ImportSourceConfiguration_SourceType")
        }
        {
            $v = "S3"
            break
        }

        # Amazon.KinesisAnalyticsV2.UrlType
        "New-KINA2ApplicationPresignedUrl/UrlType"
        {
            $v = "FLINK_DASHBOARD_URL","ZEPPELIN_UI_URL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KINA2_map = @{
    "ApplicationMode"=@("New-KINA2Application")
    "DestinationEncryptionConfiguration_KeyType"=@("Import-KINA2Snapshot")
    "ExportDestinationConfiguration_DestinationEncryptionConfiguration_KeyType"=@("Export-KINA2Snapshot")
    "ExportDestinationConfiguration_DestinationType"=@("Export-KINA2Snapshot")
    "ImportSourceConfiguration_SourceEncryptionConfiguration_KeyType"=@("Import-KINA2Snapshot")
    "ImportSourceConfiguration_SourceType"=@("Import-KINA2Snapshot")
    "OperationStatus"=@("Get-KINA2ApplicationOperationList")
    "RuntimeEnvironment"=@("New-KINA2Application")
    "RuntimeEnvironmentUpdate"=@("Update-KINA2Application")
    "SnapshotFormat"=@("Import-KINA2Snapshot")
    "SnapshotInitiator"=@("Get-KINA2SnapshotList")
    "SnapshotInitiatorOperation"=@("Get-KINA2SnapshotList")
    "SnapshotOperation"=@("Get-KINA2SnapshotOperationList")
    "SnapshotOperationStatus"=@("Get-KINA2SnapshotOperationList")
    "SnapshotStatus"=@("Get-KINA2SnapshotList")
    "UrlType"=@("New-KINA2ApplicationPresignedUrl")
}

_awsArgumentCompleterRegistration $KINA2_Completers $KINA2_map

$KINA2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KINA2.$($commandName.Replace('-', ''))Cmdlet]"
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

$KINA2_SelectMap = @{
    "Select"=@("Add-KINA2ApplicationCloudWatchLoggingOption",
               "Add-KINA2ApplicationInput",
               "Add-KINA2ApplicationInputProcessingConfiguration",
               "Add-KINA2ApplicationOutput",
               "Add-KINA2ApplicationReferenceDataSource",
               "Add-KINA2ApplicationVpcConfiguration",
               "New-KINA2Application",
               "New-KINA2ApplicationPresignedUrl",
               "New-KINA2ApplicationSnapshot",
               "New-KINA2Snapshot",
               "Remove-KINA2Application",
               "Remove-KINA2ApplicationCloudWatchLoggingOption",
               "Remove-KINA2ApplicationInputProcessingConfiguration",
               "Remove-KINA2ApplicationOutput",
               "Remove-KINA2ApplicationReferenceDataSource",
               "Remove-KINA2ApplicationSnapshot",
               "Remove-KINA2ApplicationVpcConfiguration",
               "Remove-KINA2Snapshot",
               "Get-KINA2Application",
               "Get-KINA2ApplicationOperation",
               "Get-KINA2ApplicationSnapshot",
               "Get-KINA2ApplicationVersion",
               "Get-KINA2SnapshotDetail",
               "Get-KINA2SnapshotOperationDetail",
               "Find-KINA2InputSchema",
               "Export-KINA2Snapshot",
               "Import-KINA2Snapshot",
               "Get-KINA2ApplicationOperationList",
               "Get-KINA2ApplicationList",
               "Get-KINA2ApplicationSnapshotList",
               "Get-KINA2ApplicationVersionList",
               "Get-KINA2SnapshotOperationList",
               "Get-KINA2SnapshotList",
               "Get-KINA2ResourceTag",
               "Undo-KINA2Application",
               "Start-KINA2Application",
               "Stop-KINA2Application",
               "Add-KINA2ResourceTag",
               "Remove-KINA2ResourceTag",
               "Update-KINA2Application",
               "Update-KINA2ApplicationMaintenanceConfiguration")
}

_awsArgumentCompleterRegistration $KINA2_SelectCompleters $KINA2_SelectMap

