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

# Argument completions for service Amazon Omics


$OMICS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Omics.Accelerators
        "New-OMICSWorkflow/Accelerator"
        {
            $v = "GPU"
            break
        }

        # Amazon.Omics.AnnotationType
        {
            ($_ -eq "New-OMICSAnnotationStore/TsvStoreOptions_AnnotationType") -Or
            ($_ -eq "New-OMICSAnnotationStoreVersion/TsvVersionOptions_AnnotationType")
        }
        {
            $v = "CHR_POS","CHR_POS_REF_ALT","CHR_START_END_ONE_BASE","CHR_START_END_REF_ALT_ONE_BASE","CHR_START_END_REF_ALT_ZERO_BASE","CHR_START_END_ZERO_BASE","GENERIC"
            break
        }

        # Amazon.Omics.CreationType
        "Get-OMICSReadSetList/Filter_CreationType"
        {
            $v = "IMPORT","UPLOAD"
            break
        }

        # Amazon.Omics.EncryptionType
        {
            ($_ -eq "New-OMICSAnnotationStore/SseConfig_Type") -Or
            ($_ -eq "New-OMICSReferenceStore/SseConfig_Type") -Or
            ($_ -eq "New-OMICSSequenceStore/SseConfig_Type") -Or
            ($_ -eq "New-OMICSVariantStore/SseConfig_Type")
        }
        {
            $v = "KMS"
            break
        }

        # Amazon.Omics.ETagAlgorithmFamily
        "New-OMICSSequenceStore/ETagAlgorithmFamily"
        {
            $v = "MD5up","SHA256up","SHA512up"
            break
        }

        # Amazon.Omics.FileType
        "New-OMICSMultipartReadSetUpload/SourceFileType"
        {
            $v = "BAM","CRAM","FASTQ","UBAM"
            break
        }

        # Amazon.Omics.JobStatus
        {
            ($_ -eq "Get-OMICSAnnotationImportJobList/Filter_Status") -Or
            ($_ -eq "Get-OMICSVariantImportJobList/Filter_Status")
        }
        {
            $v = "CANCELLED","COMPLETED","COMPLETED_WITH_FAILURES","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }

        # Amazon.Omics.ReadSetActivationJobStatus
        "Get-OMICSReadSetActivationJobList/Filter_Status"
        {
            $v = "CANCELLED","CANCELLING","COMPLETED","COMPLETED_WITH_FAILURES","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }

        # Amazon.Omics.ReadSetExportJobStatus
        "Get-OMICSReadSetExportJobList/Filter_Status"
        {
            $v = "CANCELLED","CANCELLING","COMPLETED","COMPLETED_WITH_FAILURES","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }

        # Amazon.Omics.ReadSetFile
        "Get-OMICSReadSet/File"
        {
            $v = "INDEX","SOURCE1","SOURCE2"
            break
        }

        # Amazon.Omics.ReadSetImportJobStatus
        "Get-OMICSReadSetImportJobList/Filter_Status"
        {
            $v = "CANCELLED","CANCELLING","COMPLETED","COMPLETED_WITH_FAILURES","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }

        # Amazon.Omics.ReadSetPartSource
        {
            ($_ -eq "Get-OMICSReadSetUploadPartList/PartSource") -Or
            ($_ -eq "Set-OMICSReadSetPart/PartSource")
        }
        {
            $v = "SOURCE1","SOURCE2"
            break
        }

        # Amazon.Omics.ReadSetStatus
        "Get-OMICSReadSetList/Filter_Status"
        {
            $v = "ACTIVATING","ACTIVE","ARCHIVED","DELETED","DELETING","PROCESSING_UPLOAD","UPLOAD_FAILED"
            break
        }

        # Amazon.Omics.ReferenceFile
        "Get-OMICSReference/File"
        {
            $v = "INDEX","SOURCE"
            break
        }

        # Amazon.Omics.ReferenceImportJobStatus
        "Get-OMICSReferenceImportJobList/Filter_Status"
        {
            $v = "CANCELLED","CANCELLING","COMPLETED","COMPLETED_WITH_FAILURES","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }

        # Amazon.Omics.ResourceOwner
        "Get-OMICSShareList/ResourceOwner"
        {
            $v = "OTHER","SELF"
            break
        }

        # Amazon.Omics.RunLogLevel
        "Start-OMICSRun/LogLevel"
        {
            $v = "ALL","ERROR","FATAL","OFF"
            break
        }

        # Amazon.Omics.RunRetentionMode
        "Start-OMICSRun/RetentionMode"
        {
            $v = "REMOVE","RETAIN"
            break
        }

        # Amazon.Omics.RunStatus
        "Get-OMICSRunList/Status"
        {
            $v = "CANCELLED","COMPLETED","DELETED","FAILED","PENDING","RUNNING","STARTING","STOPPING"
            break
        }

        # Amazon.Omics.StorageType
        "Start-OMICSRun/StorageType"
        {
            $v = "DYNAMIC","STATIC"
            break
        }

        # Amazon.Omics.StoreFormat
        "New-OMICSAnnotationStore/StoreFormat"
        {
            $v = "GFF","TSV","VCF"
            break
        }

        # Amazon.Omics.StoreStatus
        {
            ($_ -eq "Get-OMICSAnnotationStoreList/Filter_Status") -Or
            ($_ -eq "Get-OMICSVariantStoreList/Filter_Status")
        }
        {
            $v = "ACTIVE","CREATING","DELETING","FAILED","UPDATING"
            break
        }

        # Amazon.Omics.TaskStatus
        "Get-OMICSRunTaskList/Status"
        {
            $v = "CANCELLED","COMPLETED","FAILED","PENDING","RUNNING","STARTING","STOPPING"
            break
        }

        # Amazon.Omics.VersionStatus
        "Get-OMICSAnnotationStoreVersionList/Filter_Status"
        {
            $v = "ACTIVE","CREATING","DELETING","FAILED","UPDATING"
            break
        }

        # Amazon.Omics.WorkflowEngine
        "New-OMICSWorkflow/Engine"
        {
            $v = "CWL","NEXTFLOW","WDL"
            break
        }

        # Amazon.Omics.WorkflowType
        {
            ($_ -eq "Get-OMICSWorkflow/Type") -Or
            ($_ -eq "Get-OMICSWorkflowList/Type") -Or
            ($_ -eq "Start-OMICSRun/WorkflowType")
        }
        {
            $v = "PRIVATE","READY2RUN"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$OMICS_map = @{
    "Accelerator"=@("New-OMICSWorkflow")
    "Engine"=@("New-OMICSWorkflow")
    "ETagAlgorithmFamily"=@("New-OMICSSequenceStore")
    "File"=@("Get-OMICSReadSet","Get-OMICSReference")
    "Filter_CreationType"=@("Get-OMICSReadSetList")
    "Filter_Status"=@("Get-OMICSAnnotationImportJobList","Get-OMICSAnnotationStoreList","Get-OMICSAnnotationStoreVersionList","Get-OMICSReadSetActivationJobList","Get-OMICSReadSetExportJobList","Get-OMICSReadSetImportJobList","Get-OMICSReadSetList","Get-OMICSReferenceImportJobList","Get-OMICSVariantImportJobList","Get-OMICSVariantStoreList")
    "LogLevel"=@("Start-OMICSRun")
    "PartSource"=@("Get-OMICSReadSetUploadPartList","Set-OMICSReadSetPart")
    "ResourceOwner"=@("Get-OMICSShareList")
    "RetentionMode"=@("Start-OMICSRun")
    "SourceFileType"=@("New-OMICSMultipartReadSetUpload")
    "SseConfig_Type"=@("New-OMICSAnnotationStore","New-OMICSReferenceStore","New-OMICSSequenceStore","New-OMICSVariantStore")
    "Status"=@("Get-OMICSRunList","Get-OMICSRunTaskList")
    "StorageType"=@("Start-OMICSRun")
    "StoreFormat"=@("New-OMICSAnnotationStore")
    "TsvStoreOptions_AnnotationType"=@("New-OMICSAnnotationStore")
    "TsvVersionOptions_AnnotationType"=@("New-OMICSAnnotationStoreVersion")
    "Type"=@("Get-OMICSWorkflow","Get-OMICSWorkflowList")
    "WorkflowType"=@("Start-OMICSRun")
}

_awsArgumentCompleterRegistration $OMICS_Completers $OMICS_map

$OMICS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.OMICS.$($commandName.Replace('-', ''))Cmdlet]"
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

$OMICS_SelectMap = @{
    "Select"=@("Remove-OMICSMultipartReadSetUpload",
               "Receive-OMICSShare",
               "Remove-OMICSReadSet",
               "Stop-OMICSAnnotationImportJob",
               "Stop-OMICSRun",
               "Stop-OMICSVariantImportJob",
               "Complete-OMICSMultipartReadSetUpload",
               "New-OMICSAnnotationStore",
               "New-OMICSAnnotationStoreVersion",
               "New-OMICSMultipartReadSetUpload",
               "New-OMICSReferenceStore",
               "New-OMICSRunGroup",
               "New-OMICSSequenceStore",
               "New-OMICSShare",
               "New-OMICSVariantStore",
               "New-OMICSWorkflow",
               "Remove-OMICSAnnotationStore",
               "Remove-OMICSAnnotationStoreVersion",
               "Remove-OMICSReference",
               "Remove-OMICSReferenceStore",
               "Remove-OMICSRun",
               "Remove-OMICSRunGroup",
               "Remove-OMICSSequenceStore",
               "Remove-OMICSShare",
               "Remove-OMICSVariantStore",
               "Remove-OMICSWorkflow",
               "Get-OMICSAnnotationImportJob",
               "Get-OMICSAnnotationStore",
               "Get-OMICSAnnotationStoreVersion",
               "Get-OMICSReadSet",
               "Get-OMICSReadSetActivationJob",
               "Get-OMICSReadSetExportJob",
               "Get-OMICSReadSetImportJob",
               "Get-OMICSReadSetMetadata",
               "Get-OMICSReference",
               "Get-OMICSReferenceImportJob",
               "Get-OMICSReferenceMetadata",
               "Get-OMICSReferenceStore",
               "Get-OMICSRun",
               "Get-OMICSRunGroup",
               "Get-OMICSRunTask",
               "Get-OMICSSequenceStore",
               "Get-OMICSShare",
               "Get-OMICSVariantImportJob",
               "Get-OMICSVariantStore",
               "Get-OMICSWorkflow",
               "Get-OMICSAnnotationImportJobList",
               "Get-OMICSAnnotationStoreList",
               "Get-OMICSAnnotationStoreVersionList",
               "Get-OMICSMultipartReadSetUploadList",
               "Get-OMICSReadSetActivationJobList",
               "Get-OMICSReadSetExportJobList",
               "Get-OMICSReadSetImportJobList",
               "Get-OMICSReadSetList",
               "Get-OMICSReadSetUploadPartList",
               "Get-OMICSReferenceImportJobList",
               "Get-OMICSReferenceList",
               "Get-OMICSReferenceStoreList",
               "Get-OMICSRunGroupList",
               "Get-OMICSRunList",
               "Get-OMICSRunTaskList",
               "Get-OMICSSequenceStoreList",
               "Get-OMICSShareList",
               "Get-OMICSResourceTag",
               "Get-OMICSVariantImportJobList",
               "Get-OMICSVariantStoreList",
               "Get-OMICSWorkflowList",
               "Start-OMICSAnnotationImportJob",
               "Start-OMICSReadSetActivationJob",
               "Start-OMICSReadSetExportJob",
               "Start-OMICSReadSetImportJob",
               "Start-OMICSReferenceImportJob",
               "Start-OMICSRun",
               "Start-OMICSVariantImportJob",
               "Add-OMICSResourceTag",
               "Remove-OMICSResourceTag",
               "Update-OMICSAnnotationStore",
               "Update-OMICSAnnotationStoreVersion",
               "Update-OMICSRunGroup",
               "Update-OMICSVariantStore",
               "Update-OMICSWorkflow",
               "Set-OMICSReadSetPart")
}

_awsArgumentCompleterRegistration $OMICS_SelectCompleters $OMICS_SelectMap

