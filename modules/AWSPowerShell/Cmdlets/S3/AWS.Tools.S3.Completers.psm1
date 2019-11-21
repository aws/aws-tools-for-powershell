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
        # Amazon.S3.BucketAccelerateStatus
        "Write-S3BucketAccelerateConfiguration/AccelerateConfiguration_Status"
        {
            $v = "Enabled","Suspended"
            break
        }

        # Amazon.S3.EncodingType
        {
            ($_ -eq "Get-S3Object/Encoding") -Or
            ($_ -eq "Get-S3Version/Encoding")
        }
        {
            $v = "Url"
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

        # Amazon.S3.InventoryFormat
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat"
        {
            $v = "CSV","ORC","Parquet"
            break
        }

        # Amazon.S3.InventoryFrequency
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_Schedule_Frequency"
        {
            $v = "Daily","Weekly"
            break
        }

        # Amazon.S3.InventoryIncludedObjectVersions
        "Write-S3BucketInventoryConfiguration/InventoryConfiguration_IncludedObjectVersions"
        {
            $v = "All","Current"
            break
        }

        # Amazon.S3.ObjectLockEnabled
        "Write-S3ObjectLockConfiguration/ObjectLockConfiguration_ObjectLockEnabled"
        {
            $v = "Enabled"
            break
        }

        # Amazon.S3.ObjectLockLegalHoldStatus
        "Write-S3ObjectLegalHold/LegalHold_Status"
        {
            $v = "OFF","ON"
            break
        }

        # Amazon.S3.ObjectLockRetentionMode
        {
            ($_ -eq "Write-S3ObjectLockConfiguration/ObjectLockConfiguration_Rule_DefaultRetention_Mode") -Or
            ($_ -eq "Write-S3ObjectRetention/Retention_Mode")
        }
        {
            $v = "COMPLIANCE","GOVERNANCE"
            break
        }

        # Amazon.S3.RequestPayer
        {
            ($_ -eq "Get-S3Object/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectLegalHold/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectMetadata/RequestPayer") -Or
            ($_ -eq "Get-S3ObjectRetention/RequestPayer") -Or
            ($_ -eq "Restore-S3Object/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectLegalHold/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectLockConfiguration/RequestPayer") -Or
            ($_ -eq "Write-S3ObjectRetention/RequestPayer")
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
            ($_ -eq "Restore-S3Object/OutputLocation_S3_CannedACL")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","log-delivery-write","NoACL","private","public-read","public-read-write"
            break
        }

        # Amazon.S3.S3StorageClass
        "Restore-S3Object/OutputLocation_S3_StorageClass"
        {
            $v = "DEEP_ARCHIVE","GLACIER","INTELLIGENT_TIERING","ONEZONE_IA","REDUCED_REDUNDANCY","STANDARD","STANDARD_IA"
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
            ($_ -eq "Write-S3Object/ServerSideEncryptionCustomerMethod")
        }
        {
            $v = "","AES256"
            break
        }

        # Amazon.S3.ServerSideEncryptionMethod
        {
            ($_ -eq "Restore-S3Object/OutputLocation_S3_Encryption_EncryptionType") -Or
            ($_ -eq "Copy-S3Object/ServerSideEncryption") -Or
            ($_ -eq "Write-S3Object/ServerSideEncryption") -Or
            ($_ -eq "Get-S3PreSignedURL/ServerSideEncryptionMethod")
        }
        {
            $v = "","AES256","aws:kms"
            break
        }

        # Amazon.S3.StorageClassAnalysisSchemaVersion
        "Write-S3BucketAnalyticsConfiguration/AnalyticsConfiguration_StorageClassAnalysis_DataExport_OutputSchemaVersion"
        {
            $v = "V_1"
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
    "AccelerateConfiguration_Status"=@("Write-S3BucketAccelerateConfiguration")
    "AnalyticsConfiguration_StorageClassAnalysis_DataExport_OutputSchemaVersion"=@("Write-S3BucketAnalyticsConfiguration")
    "CannedACL"=@("Set-S3ACL")
    "CannedACLName"=@("Copy-S3Object","New-S3Bucket","Write-S3Object")
    "CopySourceServerSideEncryptionCustomerMethod"=@("Copy-S3Object")
    "Encoding"=@("Get-S3Object","Get-S3Version")
    "ExpressionType"=@("Select-S3ObjectContent")
    "InventoryConfiguration_Destination_S3BucketDestination_InventoryFormat"=@("Write-S3BucketInventoryConfiguration")
    "InventoryConfiguration_IncludedObjectVersions"=@("Write-S3BucketInventoryConfiguration")
    "InventoryConfiguration_Schedule_Frequency"=@("Write-S3BucketInventoryConfiguration")
    "LegalHold_Status"=@("Write-S3ObjectLegalHold")
    "ObjectLockConfiguration_ObjectLockEnabled"=@("Write-S3ObjectLockConfiguration")
    "ObjectLockConfiguration_Rule_DefaultRetention_Mode"=@("Write-S3ObjectLockConfiguration")
    "OutputLocation_S3_CannedACL"=@("Restore-S3Object")
    "OutputLocation_S3_Encryption_EncryptionType"=@("Restore-S3Object")
    "OutputLocation_S3_StorageClass"=@("Restore-S3Object")
    "RequestPayer"=@("Get-S3Object","Get-S3ObjectLegalHold","Get-S3ObjectMetadata","Get-S3ObjectRetention","Restore-S3Object","Write-S3ObjectLegalHold","Write-S3ObjectLockConfiguration","Write-S3ObjectRetention")
    "RestoreRequestType"=@("Restore-S3Object")
    "Retention_Mode"=@("Write-S3ObjectRetention")
    "RetrievalTier"=@("Restore-S3Object")
    "ServerSideCustomerEncryptionMethod"=@("Select-S3ObjectContent")
    "ServerSideEncryption"=@("Copy-S3Object","Write-S3Object")
    "ServerSideEncryptionCustomerMethod"=@("Copy-S3Object","Get-S3ObjectMetadata","Get-S3PreSignedURL","Read-S3Object","Write-S3Object")
    "ServerSideEncryptionMethod"=@("Get-S3PreSignedURL")
    "Tier"=@("Restore-S3Object")
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
    "Select"=@("Remove-S3BucketAnalyticsConfiguration",
               "Remove-S3BucketEncryption",
               "Remove-S3BucketInventoryConfiguration",
               "Remove-S3BucketMetricsConfiguration",
               "Remove-S3BucketPolicy",
               "Remove-S3BucketReplication",
               "Remove-S3BucketTagging",
               "Remove-S3BucketWebsite",
               "Remove-S3CORSConfiguration",
               "Remove-S3LifecycleConfiguration",
               "Remove-S3ObjectTagSet",
               "Remove-S3PublicAccessBlock",
               "Get-S3ACL",
               "Get-S3BucketAccelerateConfiguration",
               "Get-S3BucketAnalyticsConfiguration",
               "Get-S3BucketEncryption",
               "Get-S3BucketInventoryConfiguration",
               "Get-S3BucketLocation",
               "Get-S3BucketLogging",
               "Get-S3BucketMetricsConfiguration",
               "Get-S3BucketNotification",
               "Get-S3BucketPolicy",
               "Get-S3BucketPolicyStatus",
               "Get-S3BucketReplication",
               "Get-S3BucketRequestPayment",
               "Get-S3BucketTagging",
               "Get-S3BucketVersioning",
               "Get-S3BucketWebsite",
               "Get-S3CORSConfiguration",
               "Get-S3LifecycleConfiguration",
               "Get-S3ObjectLegalHold",
               "Get-S3ObjectLockConfiguration",
               "Get-S3ObjectMetadata",
               "Get-S3ObjectRetention",
               "Get-S3ObjectTagSet",
               "Get-S3PublicAccessBlock",
               "Get-S3BucketAnalyticsConfigurationList",
               "Get-S3BucketInventoryConfigurationList",
               "Get-S3BucketMetricsConfigurationList",
               "Get-S3Bucket",
               "Get-S3Object",
               "Get-S3Version",
               "Set-S3ACL",
               "Write-S3BucketAccelerateConfiguration",
               "Write-S3BucketAnalyticsConfiguration",
               "Set-S3BucketEncryption",
               "Write-S3BucketInventoryConfiguration",
               "Write-S3BucketLogging",
               "Write-S3BucketMetricsConfiguration",
               "Write-S3BucketNotification",
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
               "Restore-S3Object",
               "Select-S3ObjectContent",
               "Copy-S3Object",
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

