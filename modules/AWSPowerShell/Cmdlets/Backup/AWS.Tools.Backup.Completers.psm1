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

# Argument completions for service AWS Backup


$BAK_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Backup.AggregationPeriod
        {
            ($_ -eq "Get-BAKBackupJobSummaryList/AggregationPeriod") -Or
            ($_ -eq "Get-BAKCopyJobSummaryList/AggregationPeriod") -Or
            ($_ -eq "Get-BAKRestoreJobSummaryList/AggregationPeriod")
        }
        {
            $v = "FOURTEEN_DAYS","ONE_DAY","SEVEN_DAYS"
            break
        }

        # Amazon.Backup.BackupJobState
        "Get-BAKBackupJobList/ByState"
        {
            $v = "ABORTED","ABORTING","COMPLETED","CREATED","EXPIRED","FAILED","PARTIAL","PENDING","RUNNING"
            break
        }

        # Amazon.Backup.BackupJobStatus
        "Get-BAKBackupJobSummaryList/State"
        {
            $v = "ABORTED","ABORTING","AGGREGATE_ALL","ANY","COMPLETED","CREATED","EXPIRED","FAILED","PARTIAL","PENDING","RUNNING"
            break
        }

        # Amazon.Backup.CopyJobState
        "Get-BAKCopyJobList/ByState"
        {
            $v = "COMPLETED","CREATED","FAILED","PARTIAL","RUNNING"
            break
        }

        # Amazon.Backup.CopyJobStatus
        "Get-BAKCopyJobSummaryList/State"
        {
            $v = "ABORTED","ABORTING","AGGREGATE_ALL","ANY","COMPLETED","COMPLETING","CREATED","FAILED","FAILING","PARTIAL","RUNNING"
            break
        }

        # Amazon.Backup.RestoreJobState
        "Get-BAKRestoreJobSummaryList/State"
        {
            $v = "ABORTED","AGGREGATE_ALL","ANY","COMPLETED","CREATED","FAILED","PENDING","RUNNING"
            break
        }

        # Amazon.Backup.RestoreJobStatus
        {
            ($_ -eq "Get-BAKRestoreJobList/ByStatus") -Or
            ($_ -eq "Get-BAKRestoreJobsByProtectedResourceList/ByStatus")
        }
        {
            $v = "ABORTED","COMPLETED","FAILED","PENDING","RUNNING"
            break
        }

        # Amazon.Backup.RestoreTestingRecoveryPointSelectionAlgorithm
        {
            ($_ -eq "New-BAKRestoreTestingPlan/RestoreTestingPlan_RecoveryPointSelection_Algorithm") -Or
            ($_ -eq "Update-BAKRestoreTestingPlan/RestoreTestingPlan_RecoveryPointSelection_Algorithm")
        }
        {
            $v = "LATEST_WITHIN_WINDOW","RANDOM_WITHIN_WINDOW"
            break
        }

        # Amazon.Backup.RestoreValidationStatus
        "Write-BAKRestoreValidationResult/ValidationStatus"
        {
            $v = "FAILED","SUCCESSFUL","TIMED_OUT","VALIDATING"
            break
        }

        # Amazon.Backup.VaultType
        "Get-BAKBackupVaultList/ByVaultType"
        {
            $v = "BACKUP_VAULT","LOGICALLY_AIR_GAPPED_BACKUP_VAULT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BAK_map = @{
    "AggregationPeriod"=@("Get-BAKBackupJobSummaryList","Get-BAKCopyJobSummaryList","Get-BAKRestoreJobSummaryList")
    "ByState"=@("Get-BAKBackupJobList","Get-BAKCopyJobList")
    "ByStatus"=@("Get-BAKRestoreJobList","Get-BAKRestoreJobsByProtectedResourceList")
    "ByVaultType"=@("Get-BAKBackupVaultList")
    "RestoreTestingPlan_RecoveryPointSelection_Algorithm"=@("New-BAKRestoreTestingPlan","Update-BAKRestoreTestingPlan")
    "State"=@("Get-BAKBackupJobSummaryList","Get-BAKCopyJobSummaryList","Get-BAKRestoreJobSummaryList")
    "ValidationStatus"=@("Write-BAKRestoreValidationResult")
}

_awsArgumentCompleterRegistration $BAK_Completers $BAK_map

$BAK_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BAK.$($commandName.Replace('-', ''))Cmdlet]"
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

$BAK_SelectMap = @{
    "Select"=@("Stop-BAKLegalHold",
               "New-BAKBackupPlan",
               "New-BAKBackupSelection",
               "New-BAKBackupVault",
               "New-BAKFramework",
               "New-BAKLegalHold",
               "New-BAKLogicallyAirGappedBackupVault",
               "New-BAKReportPlan",
               "New-BAKRestoreTestingPlan",
               "New-BAKRestoreTestingSelection",
               "Remove-BAKBackupPlan",
               "Remove-BAKBackupSelection",
               "Remove-BAKBackupVault",
               "Remove-BAKBackupVaultAccessPolicy",
               "Remove-BAKBackupVaultLockConfiguration",
               "Remove-BAKBackupVaultNotification",
               "Remove-BAKFramework",
               "Remove-BAKRecoveryPoint",
               "Remove-BAKReportPlan",
               "Remove-BAKRestoreTestingPlan",
               "Remove-BAKRestoreTestingSelection",
               "Get-BAKBackupJob",
               "Get-BAKBackupVault",
               "Get-BAKCopyJob",
               "Get-BAKFramework",
               "Get-BAKGlobalSetting",
               "Get-BAKProtectedResource",
               "Get-BAKRecoveryPoint",
               "Get-BAKRegionSetting",
               "Get-BAKReportJob",
               "Get-BAKReportPlan",
               "Get-BAKRestoreJob",
               "Unlock-BAKRecoveryPoint",
               "Move-BAKRecoveryPoint",
               "Export-BAKBackupPlanTemplate",
               "Get-BAKBackupPlan",
               "Get-BAKBackupPlanFromJSON",
               "Get-BAKBackupPlanFromTemplate",
               "Get-BAKBackupSelection",
               "Get-BAKBackupVaultAccessPolicy",
               "Get-BAKBackupVaultNotification",
               "Get-BAKLegalHold",
               "Get-BAKRecoveryPointRestoreMetadata",
               "Get-BAKRestoreJobMetadata",
               "Get-BAKRestoreTestingInferredMetadata",
               "Get-BAKRestoreTestingPlan",
               "Get-BAKRestoreTestingSelection",
               "Get-BAKSupportedResourceType",
               "Get-BAKBackupJobList",
               "Get-BAKBackupJobSummaryList",
               "Get-BAKBackupPlanList",
               "Get-BAKBackupPlanTemplateList",
               "Get-BAKBackupPlanVersionList",
               "Get-BAKBackupSelectionList",
               "Get-BAKBackupVaultList",
               "Get-BAKCopyJobList",
               "Get-BAKCopyJobSummaryList",
               "Get-BAKFrameworkList",
               "Get-BAKLegalHoldList",
               "Get-BAKProtectedResourceList",
               "Get-BAKProtectedResourcesByBackupVaultList",
               "Get-BAKRecoveryPointsByBackupVaultList",
               "Get-BAKRecoveryPointsByLegalHoldList",
               "Get-BAKRecoveryPointsByResourceList",
               "Get-BAKReportJobList",
               "Get-BAKReportPlanList",
               "Get-BAKRestoreJobList",
               "Get-BAKRestoreJobsByProtectedResourceList",
               "Get-BAKRestoreJobSummaryList",
               "Get-BAKRestoreTestingPlanList",
               "Get-BAKRestoreTestingSelectionList",
               "Get-BAKResourceTag",
               "Write-BAKBackupVaultAccessPolicy",
               "Write-BAKBackupVaultLockConfiguration",
               "Write-BAKBackupVaultNotification",
               "Write-BAKRestoreValidationResult",
               "Start-BAKBackupJob",
               "Start-BAKCopyJob",
               "Start-BAKReportJob",
               "Start-BAKRestoreJob",
               "Stop-BAKBackupJob",
               "Add-BAKResourceTag",
               "Remove-BAKResourceTag",
               "Update-BAKBackupPlan",
               "Update-BAKFramework",
               "Update-BAKGlobalSetting",
               "Update-BAKRecoveryPointLifecycle",
               "Update-BAKRegionSetting",
               "Update-BAKReportPlan",
               "Update-BAKRestoreTestingPlan",
               "Update-BAKRestoreTestingSelection")
}

_awsArgumentCompleterRegistration $BAK_SelectCompleters $BAK_SelectMap

