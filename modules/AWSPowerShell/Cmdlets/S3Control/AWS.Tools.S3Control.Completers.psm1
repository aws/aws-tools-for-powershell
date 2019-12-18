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

# Argument completions for service Amazon S3 Control


$S3C_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.S3Control.JobManifestFormat
        "New-S3CJob/Manifest_Spec_Format"
        {
            $v = "S3BatchOperations_CSV_20180820","S3InventoryReport_CSV_20161130"
            break
        }

        # Amazon.S3Control.JobReportFormat
        "New-S3CJob/Report_Format"
        {
            $v = "Report_CSV_20180820"
            break
        }

        # Amazon.S3Control.JobReportScope
        "New-S3CJob/Report_ReportScope"
        {
            $v = "AllTasks","FailedTasksOnly"
            break
        }

        # Amazon.S3Control.RequestedJobStatus
        "Update-S3CJobStatus/RequestedJobStatus"
        {
            $v = "Cancelled","Ready"
            break
        }

        # Amazon.S3Control.S3CannedAccessControlList
        {
            ($_ -eq "New-S3CJob/Operation_S3PutObjectAcl_AccessControlPolicy_CannedAccessControlList") -Or
            ($_ -eq "New-S3CJob/Operation_S3PutObjectCopy_CannedAccessControlList")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","private","public-read","public-read-write"
            break
        }

        # Amazon.S3Control.S3GlacierJobTier
        "New-S3CJob/Operation_S3InitiateRestoreObject_GlacierJobTier"
        {
            $v = "BULK","STANDARD"
            break
        }

        # Amazon.S3Control.S3MetadataDirective
        "New-S3CJob/Operation_S3PutObjectCopy_MetadataDirective"
        {
            $v = "COPY","REPLACE"
            break
        }

        # Amazon.S3Control.S3ObjectLockLegalHoldStatus
        "New-S3CJob/Operation_S3PutObjectCopy_ObjectLockLegalHoldStatus"
        {
            $v = "OFF","ON"
            break
        }

        # Amazon.S3Control.S3ObjectLockMode
        "New-S3CJob/Operation_S3PutObjectCopy_ObjectLockMode"
        {
            $v = "COMPLIANCE","GOVERNANCE"
            break
        }

        # Amazon.S3Control.S3SSEAlgorithm
        "New-S3CJob/Operation_S3PutObjectCopy_NewObjectMetadata_SSEAlgorithm"
        {
            $v = "AES256","KMS"
            break
        }

        # Amazon.S3Control.S3StorageClass
        "New-S3CJob/Operation_S3PutObjectCopy_StorageClass"
        {
            $v = "DEEP_ARCHIVE","GLACIER","INTELLIGENT_TIERING","ONEZONE_IA","STANDARD","STANDARD_IA"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$S3C_map = @{
    "Manifest_Spec_Format"=@("New-S3CJob")
    "Operation_S3InitiateRestoreObject_GlacierJobTier"=@("New-S3CJob")
    "Operation_S3PutObjectAcl_AccessControlPolicy_CannedAccessControlList"=@("New-S3CJob")
    "Operation_S3PutObjectCopy_CannedAccessControlList"=@("New-S3CJob")
    "Operation_S3PutObjectCopy_MetadataDirective"=@("New-S3CJob")
    "Operation_S3PutObjectCopy_NewObjectMetadata_SSEAlgorithm"=@("New-S3CJob")
    "Operation_S3PutObjectCopy_ObjectLockLegalHoldStatus"=@("New-S3CJob")
    "Operation_S3PutObjectCopy_ObjectLockMode"=@("New-S3CJob")
    "Operation_S3PutObjectCopy_StorageClass"=@("New-S3CJob")
    "Report_Format"=@("New-S3CJob")
    "Report_ReportScope"=@("New-S3CJob")
    "RequestedJobStatus"=@("Update-S3CJobStatus")
}

_awsArgumentCompleterRegistration $S3C_Completers $S3C_map

$S3C_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.S3C.$($commandName.Replace('-', ''))Cmdlet]"
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

$S3C_SelectMap = @{
    "Select"=@("New-S3CAccessPoint",
               "New-S3CJob",
               "Remove-S3CAccessPoint",
               "Remove-S3CAccessPointPolicy",
               "Remove-S3CPublicAccessBlock",
               "Get-S3CJob",
               "Get-S3CAccessPoint",
               "Get-S3CAccessPointPolicy",
               "Get-S3CAccessPointPolicyStatus",
               "Get-S3CPublicAccessBlock",
               "Get-S3CAccessPointList",
               "Get-S3CJobList",
               "Write-S3CAccessPointPolicy",
               "Add-S3CPublicAccessBlock",
               "Update-S3CJobPriority",
               "Update-S3CJobStatus")
}

_awsArgumentCompleterRegistration $S3C_SelectCompleters $S3C_SelectMap

