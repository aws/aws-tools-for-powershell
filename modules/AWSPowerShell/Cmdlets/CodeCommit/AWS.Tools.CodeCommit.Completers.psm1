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

# Argument completions for service AWS CodeCommit


$CC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeCommit.ApprovalState
        "Update-CCPullRequestApprovalState/ApprovalState"
        {
            $v = "APPROVE","REVOKE"
            break
        }

        # Amazon.CodeCommit.ConflictDetailLevelTypeEnum
        {
            ($_ -eq "Get-CCFileMergeConflict/ConflictDetailLevel") -Or
            ($_ -eq "Get-CCFileMergeConflictBatch/ConflictDetailLevel") -Or
            ($_ -eq "Get-CCMergeCommit/ConflictDetailLevel") -Or
            ($_ -eq "Get-CCMergeConflict/ConflictDetailLevel") -Or
            ($_ -eq "Get-CCMergeOption/ConflictDetailLevel") -Or
            ($_ -eq "Merge-CCBranchesBySquash/ConflictDetailLevel") -Or
            ($_ -eq "Merge-CCBranchesByThreeWay/ConflictDetailLevel") -Or
            ($_ -eq "Merge-CCPullRequestBySquash/ConflictDetailLevel") -Or
            ($_ -eq "Merge-CCPullRequestByThreeWay/ConflictDetailLevel") -Or
            ($_ -eq "New-CCUnreferencedMergeCommit/ConflictDetailLevel")
        }
        {
            $v = "FILE_LEVEL","LINE_LEVEL"
            break
        }

        # Amazon.CodeCommit.ConflictResolutionStrategyTypeEnum
        {
            ($_ -eq "Get-CCFileMergeConflict/ConflictResolutionStrategy") -Or
            ($_ -eq "Get-CCFileMergeConflictBatch/ConflictResolutionStrategy") -Or
            ($_ -eq "Get-CCMergeCommit/ConflictResolutionStrategy") -Or
            ($_ -eq "Get-CCMergeConflict/ConflictResolutionStrategy") -Or
            ($_ -eq "Get-CCMergeOption/ConflictResolutionStrategy") -Or
            ($_ -eq "Merge-CCBranchesBySquash/ConflictResolutionStrategy") -Or
            ($_ -eq "Merge-CCBranchesByThreeWay/ConflictResolutionStrategy") -Or
            ($_ -eq "Merge-CCPullRequestBySquash/ConflictResolutionStrategy") -Or
            ($_ -eq "Merge-CCPullRequestByThreeWay/ConflictResolutionStrategy") -Or
            ($_ -eq "New-CCUnreferencedMergeCommit/ConflictResolutionStrategy")
        }
        {
            $v = "ACCEPT_DESTINATION","ACCEPT_SOURCE","AUTOMERGE","NONE"
            break
        }

        # Amazon.CodeCommit.FileModeTypeEnum
        "Write-CCFile/FileMode"
        {
            $v = "EXECUTABLE","NORMAL","SYMLINK"
            break
        }

        # Amazon.CodeCommit.MergeOptionTypeEnum
        {
            ($_ -eq "Get-CCFileMergeConflict/MergeOption") -Or
            ($_ -eq "Get-CCFileMergeConflictBatch/MergeOption") -Or
            ($_ -eq "Get-CCMergeConflict/MergeOption") -Or
            ($_ -eq "New-CCUnreferencedMergeCommit/MergeOption")
        }
        {
            $v = "FAST_FORWARD_MERGE","SQUASH_MERGE","THREE_WAY_MERGE"
            break
        }

        # Amazon.CodeCommit.OrderEnum
        "Get-CCRepositoryList/Order"
        {
            $v = "ascending","descending"
            break
        }

        # Amazon.CodeCommit.OverrideStatus
        "Skip-CCPullRequestApprovalRule/OverrideStatus"
        {
            $v = "OVERRIDE","REVOKE"
            break
        }

        # Amazon.CodeCommit.PullRequestEventType
        "Get-CCPullRequestEvent/PullRequestEventType"
        {
            $v = "PULL_REQUEST_APPROVAL_RULE_CREATED","PULL_REQUEST_APPROVAL_RULE_DELETED","PULL_REQUEST_APPROVAL_RULE_OVERRIDDEN","PULL_REQUEST_APPROVAL_RULE_UPDATED","PULL_REQUEST_APPROVAL_STATE_CHANGED","PULL_REQUEST_CREATED","PULL_REQUEST_MERGE_STATE_CHANGED","PULL_REQUEST_SOURCE_REFERENCE_UPDATED","PULL_REQUEST_STATUS_CHANGED"
            break
        }

        # Amazon.CodeCommit.PullRequestStatusEnum
        {
            ($_ -eq "Get-CCPullRequestList/PullRequestStatus") -Or
            ($_ -eq "Update-CCPullRequestStatus/PullRequestStatus")
        }
        {
            $v = "CLOSED","OPEN"
            break
        }

        # Amazon.CodeCommit.RelativeFileVersionEnum
        {
            ($_ -eq "Send-CCCommentForComparedCommit/Location_RelativeFileVersion") -Or
            ($_ -eq "Send-CCCommentForPullRequest/Location_RelativeFileVersion")
        }
        {
            $v = "AFTER","BEFORE"
            break
        }

        # Amazon.CodeCommit.SortByEnum
        "Get-CCRepositoryList/SortBy"
        {
            $v = "lastModifiedDate","repositoryName"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CC_map = @{
    "ApprovalState"=@("Update-CCPullRequestApprovalState")
    "ConflictDetailLevel"=@("Get-CCFileMergeConflict","Get-CCFileMergeConflictBatch","Get-CCMergeCommit","Get-CCMergeConflict","Get-CCMergeOption","Merge-CCBranchesBySquash","Merge-CCBranchesByThreeWay","Merge-CCPullRequestBySquash","Merge-CCPullRequestByThreeWay","New-CCUnreferencedMergeCommit")
    "ConflictResolutionStrategy"=@("Get-CCFileMergeConflict","Get-CCFileMergeConflictBatch","Get-CCMergeCommit","Get-CCMergeConflict","Get-CCMergeOption","Merge-CCBranchesBySquash","Merge-CCBranchesByThreeWay","Merge-CCPullRequestBySquash","Merge-CCPullRequestByThreeWay","New-CCUnreferencedMergeCommit")
    "FileMode"=@("Write-CCFile")
    "Location_RelativeFileVersion"=@("Send-CCCommentForComparedCommit","Send-CCCommentForPullRequest")
    "MergeOption"=@("Get-CCFileMergeConflict","Get-CCFileMergeConflictBatch","Get-CCMergeConflict","New-CCUnreferencedMergeCommit")
    "Order"=@("Get-CCRepositoryList")
    "OverrideStatus"=@("Skip-CCPullRequestApprovalRule")
    "PullRequestEventType"=@("Get-CCPullRequestEvent")
    "PullRequestStatus"=@("Get-CCPullRequestList","Update-CCPullRequestStatus")
    "SortBy"=@("Get-CCRepositoryList")
}

_awsArgumentCompleterRegistration $CC_Completers $CC_map

$CC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CC.$($commandName.Replace('-', ''))Cmdlet]"
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

$CC_SelectMap = @{
    "Select"=@("Add-CCApprovalRuleTemplateToRepository",
               "Add-CCApprovalRuleTemplateToRepositoryBatch",
               "Get-CCFileMergeConflictBatch",
               "Remove-CCApprovalRuleTemplateFromRepositoryBatch",
               "Get-CCCommitBatch",
               "Get-CCRepositoryBatch",
               "New-CCApprovalRuleTemplate",
               "New-CCBranch",
               "New-CCCommit",
               "New-CCPullRequest",
               "New-CCPullRequestApprovalRule",
               "New-CCRepository",
               "New-CCUnreferencedMergeCommit",
               "Remove-CCApprovalRuleTemplate",
               "Remove-CCBranch",
               "Remove-CCCommentContent",
               "Remove-CCFile",
               "Remove-CCPullRequestApprovalRule",
               "Remove-CCRepository",
               "Get-CCFileMergeConflict",
               "Get-CCPullRequestEvent",
               "Remove-CCApprovalRuleTemplateFromRepository",
               "Invoke-CCPullRequestApprovalRule",
               "Get-CCApprovalRuleTemplate",
               "Get-CCBlob",
               "Get-CCBranch",
               "Get-CCComment",
               "Get-CCCommentReaction",
               "Get-CCCommentsForComparedCommit",
               "Get-CCCommentsForPullRequest",
               "Get-CCCommit",
               "Get-CCDifferenceList",
               "Get-CCFile",
               "Get-CCFolder",
               "Get-CCMergeCommit",
               "Get-CCMergeConflict",
               "Get-CCMergeOption",
               "Get-CCPullRequest",
               "Get-CCPullRequestApprovalState",
               "Get-CCPullRequestOverrideState",
               "Get-CCRepository",
               "Get-CCRepositoryTrigger",
               "Get-CCApprovalRuleTemplateList",
               "Get-CCAssociatedApprovalRuleTemplatesForRepositoryList",
               "Get-CCBranchList",
               "Get-CCFileCommitHistoryList",
               "Get-CCPullRequestList",
               "Get-CCRepositoryList",
               "Get-CCRepositoriesForApprovalRuleTemplateList",
               "Get-CCResourceTag",
               "Merge-CCBranchesByFastForward",
               "Merge-CCBranchesBySquash",
               "Merge-CCBranchesByThreeWay",
               "Merge-CCPullRequestByFastForward",
               "Merge-CCPullRequestBySquash",
               "Merge-CCPullRequestByThreeWay",
               "Skip-CCPullRequestApprovalRule",
               "Send-CCCommentForComparedCommit",
               "Send-CCCommentForPullRequest",
               "Send-CCCommentReply",
               "Write-CCCommentReaction",
               "Write-CCFile",
               "Set-CCRepositoryTrigger",
               "Add-CCResourceTag",
               "Test-CCRepositoryTrigger",
               "Remove-CCResourceTag",
               "Update-CCApprovalRuleTemplateContent",
               "Update-CCApprovalRuleTemplateDescription",
               "Update-CCApprovalRuleTemplateName",
               "Update-CCComment",
               "Update-CCDefaultBranch",
               "Update-CCPullRequestApprovalRuleContent",
               "Update-CCPullRequestApprovalState",
               "Update-CCPullRequestDescription",
               "Update-CCPullRequestStatus",
               "Update-CCPullRequestTitle",
               "Update-CCRepositoryDescription",
               "Update-CCRepositoryName")
}

_awsArgumentCompleterRegistration $CC_SelectCompleters $CC_SelectMap

