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

# Argument completions for service Amazon Kinesis Firehose


$KINF_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KinesisFirehose.AmazonOpenSearchServerlessS3BackupMode
        "New-KINFDeliveryStream/AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode"
        {
            $v = "AllDocuments","FailedDocumentsOnly"
            break
        }

        # Amazon.KinesisFirehose.AmazonopensearchserviceIndexRotationPeriod
        {
            ($_ -eq "New-KINFDeliveryStream/AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod") -Or
            ($_ -eq "Update-KINFDestination/AmazonopensearchserviceDestinationUpdate_IndexRotationPeriod")
        }
        {
            $v = "NoRotation","OneDay","OneHour","OneMonth","OneWeek"
            break
        }

        # Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode
        "New-KINFDeliveryStream/AmazonopensearchserviceDestinationConfiguration_S3BackupMode"
        {
            $v = "AllDocuments","FailedDocumentsOnly"
            break
        }

        # Amazon.KinesisFirehose.ContentEncoding
        {
            ($_ -eq "New-KINFDeliveryStream/HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding") -Or
            ($_ -eq "Update-KINFDestination/HttpEndpointDestinationUpdate_RequestConfiguration_ContentEncoding")
        }
        {
            $v = "GZIP","NONE"
            break
        }

        # Amazon.KinesisFirehose.DeliveryStreamType
        {
            ($_ -eq "Get-KINFDeliveryStreamList/DeliveryStreamType") -Or
            ($_ -eq "New-KINFDeliveryStream/DeliveryStreamType")
        }
        {
            $v = "DirectPut","KinesisStreamAsSource"
            break
        }

        # Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod
        {
            ($_ -eq "New-KINFDeliveryStream/ElasticsearchDestinationConfiguration_IndexRotationPeriod") -Or
            ($_ -eq "Update-KINFDestination/ElasticsearchDestinationUpdate_IndexRotationPeriod")
        }
        {
            $v = "NoRotation","OneDay","OneHour","OneMonth","OneWeek"
            break
        }

        # Amazon.KinesisFirehose.ElasticsearchS3BackupMode
        "New-KINFDeliveryStream/ElasticsearchDestinationConfiguration_S3BackupMode"
        {
            $v = "AllDocuments","FailedDocumentsOnly"
            break
        }

        # Amazon.KinesisFirehose.HttpEndpointS3BackupMode
        {
            ($_ -eq "New-KINFDeliveryStream/HttpEndpointDestinationConfiguration_S3BackupMode") -Or
            ($_ -eq "Update-KINFDestination/HttpEndpointDestinationUpdate_S3BackupMode")
        }
        {
            $v = "AllData","FailedDataOnly"
            break
        }

        # Amazon.KinesisFirehose.KeyType
        {
            ($_ -eq "New-KINFDeliveryStream/DeliveryStreamEncryptionConfigurationInput_KeyType") -Or
            ($_ -eq "Start-KINFDeliveryStreamEncryption/DeliveryStreamEncryptionConfigurationInput_KeyType")
        }
        {
            $v = "AWS_OWNED_CMK","CUSTOMER_MANAGED_CMK"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KINF_map = @{
    "AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode"=@("New-KINFDeliveryStream")
    "AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod"=@("New-KINFDeliveryStream")
    "AmazonopensearchserviceDestinationConfiguration_S3BackupMode"=@("New-KINFDeliveryStream")
    "AmazonopensearchserviceDestinationUpdate_IndexRotationPeriod"=@("Update-KINFDestination")
    "DeliveryStreamEncryptionConfigurationInput_KeyType"=@("New-KINFDeliveryStream","Start-KINFDeliveryStreamEncryption")
    "DeliveryStreamType"=@("Get-KINFDeliveryStreamList","New-KINFDeliveryStream")
    "ElasticsearchDestinationConfiguration_IndexRotationPeriod"=@("New-KINFDeliveryStream")
    "ElasticsearchDestinationConfiguration_S3BackupMode"=@("New-KINFDeliveryStream")
    "ElasticsearchDestinationUpdate_IndexRotationPeriod"=@("Update-KINFDestination")
    "HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding"=@("New-KINFDeliveryStream")
    "HttpEndpointDestinationConfiguration_S3BackupMode"=@("New-KINFDeliveryStream")
    "HttpEndpointDestinationUpdate_RequestConfiguration_ContentEncoding"=@("Update-KINFDestination")
    "HttpEndpointDestinationUpdate_S3BackupMode"=@("Update-KINFDestination")
}

_awsArgumentCompleterRegistration $KINF_Completers $KINF_map

$KINF_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KINF.$($commandName.Replace('-', ''))Cmdlet]"
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

$KINF_SelectMap = @{
    "Select"=@("New-KINFDeliveryStream",
               "Remove-KINFDeliveryStream",
               "Get-KINFDeliveryStream",
               "Get-KINFDeliveryStreamList",
               "Get-KINFTagsForDeliveryStream",
               "Write-KINFRecord",
               "Write-KINFRecordBatch",
               "Start-KINFDeliveryStreamEncryption",
               "Stop-KINFDeliveryStreamEncryption",
               "Add-KINFDeliveryStreamTag",
               "Remove-KINFDeliveryStreamTag",
               "Update-KINFDestination")
}

_awsArgumentCompleterRegistration $KINF_SelectCompleters $KINF_SelectMap

