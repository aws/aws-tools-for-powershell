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

# Argument completions for service AWS Well-Architected Tool


$WAT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WellArchitected.AnswerReason
        "Update-WATAnswer/Reason"
        {
            $v = "ARCHITECTURE_CONSTRAINTS","BUSINESS_PRIORITIES","NONE","OTHER","OUT_OF_SCOPE"
            break
        }

        # Amazon.WellArchitected.DiscoveryIntegrationStatus
        "Update-WATGlobalSetting/DiscoveryIntegrationStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WellArchitected.LensStatusType
        {
            ($_ -eq "Get-WATLensList/LensStatus") -Or
            ($_ -eq "Remove-WATLens/LensStatus")
        }
        {
            $v = "ALL","DRAFT","PUBLISHED"
            break
        }

        # Amazon.WellArchitected.LensType
        "Get-WATLensList/LensType"
        {
            $v = "AWS_OFFICIAL","CUSTOM_SELF","CUSTOM_SHARED"
            break
        }

        # Amazon.WellArchitected.OrganizationSharingStatus
        "Update-WATGlobalSetting/OrganizationSharingStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WellArchitected.PermissionType
        {
            ($_ -eq "New-WATWorkloadShare/PermissionType") -Or
            ($_ -eq "Update-WATWorkloadShare/PermissionType")
        }
        {
            $v = "CONTRIBUTOR","READONLY"
            break
        }

        # Amazon.WellArchitected.ProfileOwnerType
        "Get-WATProfileList/ProfileOwnerType"
        {
            $v = "SELF","SHARED"
            break
        }

        # Amazon.WellArchitected.QuestionPriority
        {
            ($_ -eq "Get-WATAnswerList/QuestionPriority") -Or
            ($_ -eq "Get-WATLensReviewImprovementList/QuestionPriority")
        }
        {
            $v = "NONE","PRIORITIZED"
            break
        }

        # Amazon.WellArchitected.ReportFormat
        "Get-WATConsolidatedReport/Format"
        {
            $v = "JSON","PDF"
            break
        }

        # Amazon.WellArchitected.ShareInvitationAction
        "Update-WATShareInvitation/ShareInvitationAction"
        {
            $v = "ACCEPT","REJECT"
            break
        }

        # Amazon.WellArchitected.ShareResourceType
        "Get-WATShareInvitationList/ShareResourceType"
        {
            $v = "LENS","PROFILE","WORKLOAD"
            break
        }

        # Amazon.WellArchitected.ShareStatus
        {
            ($_ -eq "Get-WATLensShareList/Status") -Or
            ($_ -eq "Get-WATProfileShareList/Status") -Or
            ($_ -eq "Get-WATWorkloadShareList/Status")
        }
        {
            $v = "ACCEPTED","ASSOCIATED","ASSOCIATING","EXPIRED","FAILED","PENDING","REJECTED","REVOKED"
            break
        }

        # Amazon.WellArchitected.TrustedAdvisorIntegrationStatus
        {
            ($_ -eq "New-WATWorkload/DiscoveryConfig_TrustedAdvisorIntegrationStatus") -Or
            ($_ -eq "Update-WATWorkload/DiscoveryConfig_TrustedAdvisorIntegrationStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WellArchitected.WorkloadEnvironment
        {
            ($_ -eq "New-WATWorkload/Environment") -Or
            ($_ -eq "Update-WATWorkload/Environment")
        }
        {
            $v = "PREPRODUCTION","PRODUCTION"
            break
        }

        # Amazon.WellArchitected.WorkloadImprovementStatus
        "Update-WATWorkload/ImprovementStatus"
        {
            $v = "COMPLETE","IN_PROGRESS","NOT_APPLICABLE","NOT_STARTED","RISK_ACKNOWLEDGED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WAT_map = @{
    "DiscoveryConfig_TrustedAdvisorIntegrationStatus"=@("New-WATWorkload","Update-WATWorkload")
    "DiscoveryIntegrationStatus"=@("Update-WATGlobalSetting")
    "Environment"=@("New-WATWorkload","Update-WATWorkload")
    "Format"=@("Get-WATConsolidatedReport")
    "ImprovementStatus"=@("Update-WATWorkload")
    "LensStatus"=@("Get-WATLensList","Remove-WATLens")
    "LensType"=@("Get-WATLensList")
    "OrganizationSharingStatus"=@("Update-WATGlobalSetting")
    "PermissionType"=@("New-WATWorkloadShare","Update-WATWorkloadShare")
    "ProfileOwnerType"=@("Get-WATProfileList")
    "QuestionPriority"=@("Get-WATAnswerList","Get-WATLensReviewImprovementList")
    "Reason"=@("Update-WATAnswer")
    "ShareInvitationAction"=@("Update-WATShareInvitation")
    "ShareResourceType"=@("Get-WATShareInvitationList")
    "Status"=@("Get-WATLensShareList","Get-WATProfileShareList","Get-WATWorkloadShareList")
}

_awsArgumentCompleterRegistration $WAT_Completers $WAT_map

$WAT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WAT.$($commandName.Replace('-', ''))Cmdlet]"
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

$WAT_SelectMap = @{
    "Select"=@("Register-WATLens",
               "Register-WATProfile",
               "New-WATLensShare",
               "New-WATLensVersion",
               "New-WATMilestone",
               "New-WATProfile",
               "New-WATProfileShare",
               "New-WATWorkload",
               "New-WATWorkloadShare",
               "Remove-WATLens",
               "Remove-WATLensShare",
               "Remove-WATProfile",
               "Remove-WATProfileShare",
               "Remove-WATWorkload",
               "Remove-WATWorkloadShare",
               "Unregister-WATLens",
               "Unregister-WATProfile",
               "Export-WATLens",
               "Get-WATAnswer",
               "Get-WATConsolidatedReport",
               "Get-WATLens",
               "Get-WATLensReview",
               "Get-WATLensReviewReport",
               "Get-WATLensVersionDifference",
               "Get-WATMilestone",
               "Get-WATProfile",
               "Get-WATProfileTemplate",
               "Get-WATWorkload",
               "Import-WATLens",
               "Get-WATAnswerList",
               "Get-WATCheckDetailList",
               "Get-WATCheckSummaryList",
               "Get-WATLensList",
               "Get-WATLensReviewImprovementList",
               "Get-WATLensReviewList",
               "Get-WATLensShareList",
               "Get-WATMilestoneList",
               "Get-WATNotificationList",
               "Get-WATProfileNotificationList",
               "Get-WATProfileList",
               "Get-WATProfileShareList",
               "Get-WATShareInvitationList",
               "Get-WATResourceTag",
               "Get-WATWorkloadList",
               "Get-WATWorkloadShareList",
               "Add-WATResourceTag",
               "Remove-WATResourceTag",
               "Update-WATAnswer",
               "Update-WATGlobalSetting",
               "Update-WATLensReview",
               "Update-WATProfile",
               "Update-WATShareInvitation",
               "Update-WATWorkload",
               "Update-WATWorkloadShare",
               "Convert-WATLensReview",
               "Update-WATProfileVersion")
}

_awsArgumentCompleterRegistration $WAT_SelectCompleters $WAT_SelectMap

