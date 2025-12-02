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

# Argument completions for service Amazon Simple Storage Service (S3)


$S3_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.S3.BucketAbacStatus
        "Write-S3BucketAbac/AbacStatus_Status"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.S3.BucketAccelerateStatus
        "Write-S3BucketAccelerateConfiguration/AccelerateConfiguration_Status"
        {
            $v = "Enabled","Suspended"
            break
        }

        # Amazon.S3.ChecksumAlgorithm
        {
            ($_ -eq "Add-S3PublicAccessBlock/ChecksumAlgorithm") -Or
            ($_ -eq "Copy-S3Object/ChecksumAlgorithm") -Or
            ($_ -eq "New-S3BucketMetadataConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "New-S3BucketMetadataTableConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Remove-S3Object/ChecksumAlgorithm") -Or
            ($_ -eq "Restore-S3Object/ChecksumAlgorithm") -Or
            ($_ -eq "Set-S3ACL/ChecksumAlgorithm") -Or
            ($_ -eq "Set-S3BucketEncryption/ChecksumAlgorithm") -Or
            ($_ -eq "Update-S3BucketMetadataInventoryTableConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Update-S3BucketMetadataJournalTableConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketAbac/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketAccelerateConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketLogging/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketNotification/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketOwnershipControl/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketPolicy/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketReplication/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketRequestPayment/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketTagging/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketVersioning/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3BucketWebsite/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3CORSConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3LifecycleConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3Object/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3ObjectLegalHold/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3ObjectLockConfiguration/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3ObjectRetention/ChecksumAlgorithm") -Or
            ($_ -eq "Write-S3ObjectTagSet/ChecksumAlgorithm")
        }
        {
            $v = "CRC32","CRC32C","CRC64NVME","SHA1","SHA256"
            break
        }

        # Amazon.S3.ChecksumMode
        {
            ($_ -eq "Copy-S3Object/ChecksumMode") -Or
            ($_ -eq "Get-S3ObjectMetadata/ChecksumMode") -Or
            ($_ -eq "Read-S3Object/ChecksumMode")
        }
        {
            $v = "ENABLED"
            break
        }

        # Amazon.S3.EncodingType
        {
            ($_ -eq "Get-S3MultipartUpload/Encoding") -Or
            ($_ -eq "Get-S3Object/Encoding") -Or
            ($_ -eq "Get-S3ObjectV2/Encoding") -Or
            ($_ -eq "Get-S3Version/Encoding")
        }
        {
            $v = "Url"
            break
        }

        # Amazon.S3.ExpirationState
        "New-S3BucketMetadataConfiguration/RecordExpiration_Expiration"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.S3.ExpressionType
        "Select-S3ObjectContent/ExpressionType"
        {
            $v = "SQL"
            break
        }

        # Amazon.S3.GlacierJobTier
        {
            ($_ -eq "Restore-S3Object/RetrievalTier") -Or
            ($_ -eq "Restore-S3Object/Tier")
        }
        {
            $v = "Bulk","Expedited","Standard"
            break
        }

        # Amazon.S3.IntelligentTieringStatus
        "Write-S3BucketIntelligentTieringConfiguration/IntelligentTieringConfiguration_Status"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.S3.InventoryConfigurationState
        {
            ($_ -eq "New-S3BucketMetadataConfiguration/InventoryTableConfiguration_ConfigurationState") -Or
            ($_ -eq "Update-S3BucketMetadataInventoryTableConfiguration/InventoryTableConfiguration_ConfigurationState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.S3.InventoryFormat
        "Write-S3BucketInventoryConfiguration/S3BucketDestination_InventoryFormat"
        {
            $v = "CSV","ORC","Parquet"
            break
        }

        # Amazon.S3.InventoryFrequency
        "Write-S3BucketInventoryConfiguration/Schedule_Frequency"
        {
            $v = "Daily","Weekly"
            break
        }

        # Amazon.S3.InventoryIncludedObjectVersions
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_IncludedObjectVersion"
        {
            $v = "All","Current"
            break
        }

        # Amazon.S3.JournalConfigurationState
        "Update-S3BucketMetadataJournalTableConfiguration/JournalTableConfiguration_ConfigurationState"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.S3.ObjectLockEnabled
        "Write-S3ObjectLockConfiguration/ObjectLockConfiguration_ObjectLockEnabled"
        {
            $v = "Enabled"
            break
        }

        # Amazon.S3.ObjectLockLegalHoldStatus
        {
            ($_ -eq "Write-S3ObjectLegalHold/LegalHold_Status") -Or
            ($_ -eq "Write-S3GetObjectResponse/ObjectLockLegalHoldStatus")
        }
        {
            $v = "OFF","ON"
            break
        }

        # Amazon.S3.ObjectLockMode
        "Write-S3GetObjectResponse/ObjectLockMode"
        {
            $v = "COMPLIANCE","GOVERNANCE"
            break
        }

        # Amazon.S3.ObjectLockRetentionMode
        {
            ($_ -eq "Write-S3ObjectLockConfiguration/DefaultRetention_Mode") -Or
            ($_ -eq "Write-S3ObjectRetention/Retention_Mode")
        }
        {
            $v = "COMPLIANCE","GOVERNANCE"
            break
        }

        # Amazon.S3.PartitionDateSource
        "Write-S3BucketLogging/PartitionedPrefix_PartitionDateSource"
        {
            $v = "DeliveryTime","EventTime"
            break
        }

        # Amazon.S3.ReplicationStatus
        "Write-S3GetObjectResponse/ReplicationStatus"
        {
            $v = "COMPLETED","FAILED","PENDING","REPLICA"
            break
        }

        # Amazon.S3.RequestCharged
        "Write-S3GetObjectResponse/RequestCharged"
        {
            $v = "requester"
            break
        }

        # Amazon.S3.RequestPayer
        {
            ($_ -eq "Copy-S3Object/RequestPayer") -Or
            ($_ -eq "Get-S3BucketAccelerateConfiguration/RequestPayer") -Or
            ($_ -eq "Get-S3Object/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectAttribute/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectLegalHold/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectMetadata/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectRetention/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectTagSet/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectV2/RequestPayer") -Or
            ($_ -eq "Get-S3Version/RequestPayer") -Or
            ($_ -eq "Remove-S3Object/RequestPayer") -Or
            ($_ -eq "Restore-S3Object/RequestPayer") -Or
            ($_ -eq "Write-S3Object/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectLegalHold/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectLockConfiguration/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectRetention/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectTagSet/RequestPayer")
        }
        {
            $v = "requester"
            break
        }

        # Amazon.S3.RestoreRequestType
        "Restore-S3Object/RestoreRequestType"
        {
            $v = "SELECT"
            break
        }

        # Amazon.S3.S3CannedACL
        {
            ($_ -eq "Set-S3ACL/CannedACL") -Or
            ($_ -eq "Copy-S3Object/CannedACLName") -Or
            ($_ -eq "New-S3Bucket/CannedACLName") -Or
            ($_ -eq "Write-S3Object/CannedACLName") -Or
            ($_ -eq "Restore-S3Object/S3_CannedACL")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","log-delivery-write","NoACL","private","public-read","public-read-write"
            break
        }

        # Amazon.S3.S3StorageClass
        {
            ($_ -eq "Restore-S3Object/S3_StorageClass") -Or
            ($_ -eq "Write-S3GetObjectResponse/StorageClass")
        }
        {
            $v = "DEEP_ARCHIVE","EXPRESS_ONEZONE","FSX_ONTAP","FSX_OPENZFS","GLACIER","GLACIER_IR","INTELLIGENT_TIERING","ONEZONE_IA","OUTPOSTS","REDUCED_REDUNDANCY","SNOW","STANDARD","STANDARD_IA"
            break
        }

        # Amazon.S3.ServerSideEncryptionCustomerMethod
        {
            ($_ -eq "Copy-S3Object/CopySourceServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Select-S3ObjectContent/ServerSideCustomerEncryptionMethod") -Or
            ($_ -eq "Copy-S3Object/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Get-S3ObjectMetadata/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Get-S3PreSignedURL/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Read-S3Object/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Write-S3Object/ServerSideEncryptionCustomerMethod") -Or
            ($_ -eq "Write-S3GetObjectResponse/SSECustomerAlgorithm")
        }
        {
            $v = "","AES256"
            break
        }

        # Amazon.S3.ServerSideEncryptionMethod
        {
            ($_ -eq "Restore-S3Object/Encryption_EncryptionType") -Or
            ($_ -eq "Copy-S3Object/ServerSideEncryption") -Or
            ($_ -eq "New-S3Session/ServerSideEncryption") -Or
            ($_ -eq "Write-S3Object/ServerSideEncryption") -Or
            ($_ -eq "Get-S3PreSignedURL/ServerSideEncryptionMethod") -Or
            ($_ -eq "Write-S3GetObjectResponse/ServerSideEncryptionMethod")
        }
        {
            $v = "","AES256","aws:fsx","aws:kms","aws:kms:dsse"
            break
        }

        # Amazon.S3.SessionMode
        "New-S3Session/SessionMode"
        {
            $v = "ReadOnly","ReadWrite"
            break
        }

        # Amazon.S3.StorageClassAnalysisSchemaVersion
        "Write-S3BucketAnalyticsConfiguration/DataExport_OutputSchemaVersion"
        {
            $v = "V_1"
            break
        }

        # Amazon.S3.TableSseAlgorithm
        {
            ($_ -eq "Update-S3BucketMetadataInventoryTableConfiguration/EncryptionConfiguration_SseAlgorithm") -Or
            ($_ -eq "Update-S3BucketMetadataJournalTableConfiguration/EncryptionConfiguration_SseAlgorithm") -Or
            ($_ -eq "New-S3BucketMetadataConfiguration/MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm") -Or
            ($_ -eq "New-S3BucketMetadataConfiguration/MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm")
        }
        {
            $v = "AES256","aws:kms"
            break
        }

        # Amazon.S3.TransitionDefaultMinimumObjectSize
        "Write-S3LifecycleConfiguration/TransitionDefaultMinimumObjectSize"
        {
            $v = "all_storage_classes_128K","varies_by_storage_class"
            break
        }

        # Amazon.S3.VersionStatus
        "Write-S3BucketVersioning/VersioningConfig_Status"
        {
            $v = "Enabled","Off","Suspended"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$S3_map = @{
    "AbacStatus_Status"=@("Write-S3BucketAbac")
    "AccelerateConfiguration_Status"=@("Write-S3BucketAccelerateConfiguration")
    "CannedACL"=@("Set-S3ACL")
    "CannedACLName"=@("Copy-S3Object","New-S3Bucket","Write-S3Object")
    "ChecksumAlgorithm"=@("Add-S3PublicAccessBlock","Copy-S3Object","New-S3BucketMetadataConfiguration","New-S3BucketMetadataTableConfiguration","Remove-S3Object","Restore-S3Object","Set-S3ACL","Set-S3BucketEncryption","Update-S3BucketMetadataInventoryTableConfiguration","Update-S3BucketMetadataJournalTableConfiguration","Write-S3BucketAbac","Write-S3BucketAccelerateConfiguration","Write-S3BucketLogging","Write-S3BucketNotification","Write-S3BucketOwnershipControl","Write-S3BucketPolicy","Write-S3BucketReplication","Write-S3BucketRequestPayment","Write-S3BucketTagging","Write-S3BucketVersioning","Write-S3BucketWebsite","Write-S3CORSConfiguration","Write-S3LifecycleConfiguration","Write-S3Object","Write-S3ObjectLegalHold","Write-S3ObjectLockConfiguration","Write-S3ObjectRetention","Write-S3ObjectTagSet")
    "ChecksumMode"=@("Copy-S3Object","Get-S3ObjectMetadata","Read-S3Object")
    "CopySourceServerSideEncryptionCustomerMethod"=@("Copy-S3Object")
    "DataExport_OutputSchemaVersion"=@("Write-S3BucketAnalyticsConfiguration")
    "DefaultRetention_Mode"=@("Write-S3ObjectLockConfiguration")
    "Encoding"=@("Get-S3MultipartUpload","Get-S3Object","Get-S3ObjectV2","Get-S3Version")
    "Encryption_EncryptionType"=@("Restore-S3Object")
    "EncryptionConfiguration_SseAlgorithm"=@("Update-S3BucketMetadataInventoryTableConfiguration","Update-S3BucketMetadataJournalTableConfiguration")
    "ExpressionType"=@("Select-S3ObjectContent")
    "IntelligentTieringConfiguration_Status"=@("Write-S3BucketIntelligentTieringConfiguration")
    "InventoryConfiguration_IncludedObjectVersion"=@("Write-S3BucketInventoryConfiguration")
    "InventoryTableConfiguration_ConfigurationState"=@("New-S3BucketMetadataConfiguration","Update-S3BucketMetadataInventoryTableConfiguration")
    "JournalTableConfiguration_ConfigurationState"=@("Update-S3BucketMetadataJournalTableConfiguration")
    "LegalHold_Status"=@("Write-S3ObjectLegalHold")
    "MetadataConfiguration_InventoryTableConfiguration_EncryptionConfiguration_SseAlgorithm"=@("New-S3BucketMetadataConfiguration")
    "MetadataConfiguration_JournalTableConfiguration_EncryptionConfiguration_SseAlgorithm"=@("New-S3BucketMetadataConfiguration")
    "ObjectLockConfiguration_ObjectLockEnabled"=@("Write-S3ObjectLockConfiguration")
    "ObjectLockLegalHoldStatus"=@("Write-S3GetObjectResponse")
    "ObjectLockMode"=@("Write-S3GetObjectResponse")
    "PartitionedPrefix_PartitionDateSource"=@("Write-S3BucketLogging")
    "RecordExpiration_Expiration"=@("New-S3BucketMetadataConfiguration")
    "ReplicationStatus"=@("Write-S3GetObjectResponse")
    "RequestCharged"=@("Write-S3GetObjectResponse")
    "RequestPayer"=@("Copy-S3Object","Get-S3BucketAccelerateConfiguration","Get-S3Object","Get-S3ObjectAttribute","Get-S3ObjectLegalHold","Get-S3ObjectMetadata","Get-S3ObjectRetention","Get-S3ObjectTagSet","Get-S3ObjectV2","Get-S3Version","Remove-S3Object","Restore-S3Object","Write-S3Object","Write-S3ObjectLegalHold","Write-S3ObjectLockConfiguration","Write-S3ObjectRetention","Write-S3ObjectTagSet")
    "RestoreRequestType"=@("Restore-S3Object")
    "Retention_Mode"=@("Write-S3ObjectRetention")
    "RetrievalTier"=@("Restore-S3Object")
    "S3_CannedACL"=@("Restore-S3Object")
    "S3_StorageClass"=@("Restore-S3Object")
    "S3BucketDestination_InventoryFormat"=@("Write-S3BucketInventoryConfiguration")
    "Schedule_Frequency"=@("Write-S3BucketInventoryConfiguration")
    "ServerSideCustomerEncryptionMethod"=@("Select-S3ObjectContent")
    "ServerSideEncryption"=@("Copy-S3Object","New-S3Session","Write-S3Object")
    "ServerSideEncryptionCustomerMethod"=@("Copy-S3Object","Get-S3ObjectMetadata","Get-S3PreSignedURL","Read-S3Object","Write-S3Object")
    "ServerSideEncryptionMethod"=@("Get-S3PreSignedURL","Write-S3GetObjectResponse")
    "SessionMode"=@("New-S3Session")
    "SSECustomerAlgorithm"=@("Write-S3GetObjectResponse")
    "StorageClass"=@("Write-S3GetObjectResponse")
    "Tier"=@("Restore-S3Object")
    "TransitionDefaultMinimumObjectSize"=@("Write-S3LifecycleConfiguration")
    "VersioningConfig_Status"=@("Write-S3BucketVersioning")
}

_awsArgumentCompleterRegistration $S3_Completers $S3_map

$S3_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.S3.$($commandName.Replace('-', ''))Cmdlet]"
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

$S3_SelectMap = @{
    "Select"=@("New-S3BucketMetadataConfiguration",
               "New-S3BucketMetadataTableConfiguration",
               "New-S3Session",
               "Remove-S3BucketAnalyticsConfiguration",
               "Remove-S3BucketEncryption",
               "Remove-S3BucketIntelligentTieringConfiguration",
               "Remove-S3BucketInventoryConfiguration",
               "Remove-S3BucketMetadataConfiguration",
               "Remove-S3BucketMetadataTableConfiguration",
               "Remove-S3BucketMetricsConfiguration",
               "Remove-S3BucketOwnershipControl",
               "Remove-S3BucketPolicy",
               "Remove-S3BucketReplication",
               "Remove-S3BucketTagging",
               "Remove-S3BucketWebsite",
               "Remove-S3CORSConfiguration",
               "Remove-S3LifecycleConfiguration",
               "Remove-S3ObjectTagSet",
               "Remove-S3PublicAccessBlock",
               "Get-S3ACL",
               "Get-S3BucketAbac",
               "Get-S3BucketAccelerateConfiguration",
               "Get-S3BucketAnalyticsConfiguration",
               "Get-S3BucketEncryption",
               "Get-S3BucketIntelligentTieringConfiguration",
               "Get-S3BucketInventoryConfiguration",
               "Get-S3BucketLocation",
               "Get-S3BucketLogging",
               "Get-S3BucketMetadataConfiguration",
               "Get-S3BucketMetadataTableConfiguration",
               "Get-S3BucketMetricsConfiguration",
               "Get-S3BucketNotification",
               "Get-S3BucketOwnershipControl",
               "Get-S3BucketPolicy",
               "Get-S3BucketPolicyStatus",
               "Get-S3BucketReplication",
               "Get-S3BucketRequestPayment",
               "Get-S3BucketTagging",
               "Get-S3BucketVersioning",
               "Get-S3BucketWebsite",
               "Get-S3CORSConfiguration",
               "Get-S3LifecycleConfiguration",
               "Get-S3ObjectAttribute",
               "Get-S3ObjectLegalHold",
               "Get-S3ObjectLockConfiguration",
               "Get-S3ObjectMetadata",
               "Get-S3ObjectRetention",
               "Get-S3ObjectTagSet",
               "Get-S3PublicAccessBlock",
               "Get-S3BucketAnalyticsConfigurationList",
               "Get-S3BucketIntelligentTieringConfigurationList",
               "Get-S3BucketInventoryConfigurationList",
               "Get-S3BucketMetricsConfigurationList",
               "Get-S3Bucket",
               "Get-S3DirectoryBucket",
               "Get-S3Object",
               "Get-S3ObjectV2",
               "Get-S3Version",
               "Set-S3ACL",
               "Write-S3BucketAbac",
               "Write-S3BucketAccelerateConfiguration",
               "Write-S3BucketAnalyticsConfiguration",
               "Set-S3BucketEncryption",
               "Write-S3BucketIntelligentTieringConfiguration",
               "Write-S3BucketInventoryConfiguration",
               "Write-S3BucketLogging",
               "Write-S3BucketMetricsConfiguration",
               "Write-S3BucketNotification",
               "Write-S3BucketOwnershipControl",
               "Write-S3BucketPolicy",
               "Write-S3BucketReplication",
               "Write-S3BucketRequestPayment",
               "Write-S3BucketTagging",
               "Write-S3BucketVersioning",
               "Write-S3BucketWebsite",
               "Write-S3CORSConfiguration",
               "Write-S3LifecycleConfiguration",
               "Write-S3ObjectLegalHold",
               "Write-S3ObjectLockConfiguration",
               "Write-S3ObjectRetention",
               "Write-S3ObjectTagSet",
               "Add-S3PublicAccessBlock",
               "Rename-S3Object",
               "Restore-S3Object",
               "Select-S3ObjectContent",
               "Update-S3BucketMetadataInventoryTableConfiguration",
               "Update-S3BucketMetadataJournalTableConfiguration",
               "Write-S3GetObjectResponse",
               "Copy-S3Object",
               "Get-S3MultipartUpload",
               "Get-S3PreSignedURL",
               "New-S3Bucket",
               "Read-S3Object",
               "Remove-S3Bucket",
               "Remove-S3MultipartUpload",
               "Remove-S3Object",
               "Test-S3Bucket",
               "Write-S3Object")
}

_awsArgumentCompleterRegistration $S3_SelectCompleters $S3_SelectMap

