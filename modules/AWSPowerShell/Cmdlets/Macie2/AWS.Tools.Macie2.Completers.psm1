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

# Argument completions for service Amazon Macie 2


$MAC2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Macie2.DayOfWeek
        "New-MAC2ClassificationJob/ScheduleFrequency_WeeklySchedule_DayOfWeek"
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.Macie2.FindingPublishingFrequency
        {
            ($_ -eq "Enable-MAC2Macie/FindingPublishingFrequency") -Or
            ($_ -eq "Update-MAC2MacieSession/FindingPublishingFrequency")
        }
        {
            $v = "FIFTEEN_MINUTES","ONE_HOUR","SIX_HOURS"
            break
        }

        # Amazon.Macie2.FindingsFilterAction
        {
            ($_ -eq "New-MAC2FindingsFilter/Action") -Or
            ($_ -eq "Update-MAC2FindingsFilter/Action")
        }
        {
            $v = "ARCHIVE","NOOP"
            break
        }

        # Amazon.Macie2.FindingStatisticsSortAttributeName
        "Get-MAC2FindingStatistic/SortCriteria_AttributeName"
        {
            $v = "count","groupKey"
            break
        }

        # Amazon.Macie2.GroupBy
        "Get-MAC2FindingStatistic/GroupBy"
        {
            $v = "classificationDetails.jobId","resourcesAffected.s3Bucket.name","severity.description","type"
            break
        }

        # Amazon.Macie2.JobStatus
        "Update-MAC2ClassificationJob/JobStatus"
        {
            $v = "CANCELLED","COMPLETE","IDLE","PAUSED","RUNNING"
            break
        }

        # Amazon.Macie2.JobType
        "New-MAC2ClassificationJob/JobType"
        {
            $v = "ONE_TIME","SCHEDULED"
            break
        }

        # Amazon.Macie2.ListJobsSortAttributeName
        "Get-MAC2ClassificationJobList/SortCriteria_AttributeName"
        {
            $v = "createdAt","jobStatus","jobType","name"
            break
        }

        # Amazon.Macie2.MacieStatus
        {
            ($_ -eq "Enable-MAC2Macie/Status") -Or
            ($_ -eq "Update-MAC2MacieSession/Status") -Or
            ($_ -eq "Update-MAC2MemberSession/Status")
        }
        {
            $v = "ENABLED","PAUSED"
            break
        }

        # Amazon.Macie2.OrderBy
        {
            ($_ -eq "Get-MAC2UsageStatistic/SortBy_OrderBy") -Or
            ($_ -eq "Get-MAC2Bucket/SortCriteria_OrderBy") -Or
            ($_ -eq "Get-MAC2ClassificationJobList/SortCriteria_OrderBy") -Or
            ($_ -eq "Get-MAC2Finding/SortCriteria_OrderBy") -Or
            ($_ -eq "Get-MAC2FindingList/SortCriteria_OrderBy") -Or
            ($_ -eq "Get-MAC2FindingStatistic/SortCriteria_OrderBy")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Macie2.UsageStatisticsSortKey
        "Get-MAC2UsageStatistic/SortBy_Key"
        {
            $v = "accountId","freeTrialStartDate","serviceLimitValue","total"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MAC2_map = @{
    "Action"=@("New-MAC2FindingsFilter","Update-MAC2FindingsFilter")
    "FindingPublishingFrequency"=@("Enable-MAC2Macie","Update-MAC2MacieSession")
    "GroupBy"=@("Get-MAC2FindingStatistic")
    "JobStatus"=@("Update-MAC2ClassificationJob")
    "JobType"=@("New-MAC2ClassificationJob")
    "ScheduleFrequency_WeeklySchedule_DayOfWeek"=@("New-MAC2ClassificationJob")
    "SortBy_Key"=@("Get-MAC2UsageStatistic")
    "SortBy_OrderBy"=@("Get-MAC2UsageStatistic")
    "SortCriteria_AttributeName"=@("Get-MAC2ClassificationJobList","Get-MAC2FindingStatistic")
    "SortCriteria_OrderBy"=@("Get-MAC2Bucket","Get-MAC2ClassificationJobList","Get-MAC2Finding","Get-MAC2FindingList","Get-MAC2FindingStatistic")
    "Status"=@("Enable-MAC2Macie","Update-MAC2MacieSession","Update-MAC2MemberSession")
}

_awsArgumentCompleterRegistration $MAC2_Completers $MAC2_map

$MAC2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MAC2.$($commandName.Replace('-', ''))Cmdlet]"
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

$MAC2_SelectMap = @{
    "Select"=@("Approve-MAC2Invitation",
               "Get-MAC2GetCustomDataIdentifier",
               "New-MAC2ClassificationJob",
               "New-MAC2CustomDataIdentifier",
               "New-MAC2FindingsFilter",
               "New-MAC2Invitation",
               "New-MAC2Member",
               "New-MAC2SampleFinding",
               "Deny-MAC2Invitation",
               "Remove-MAC2CustomDataIdentifier",
               "Remove-MAC2FindingsFilter",
               "Remove-MAC2Invitation",
               "Remove-MAC2Member",
               "Get-MAC2Bucket",
               "Get-MAC2ClassificationJob",
               "Get-MAC2OrganizationConfiguration",
               "Disable-MAC2Macie",
               "Disable-MAC2OrganizationAdminAccount",
               "Unregister-MAC2FromMasterAccount",
               "Unregister-MAC2Member",
               "Enable-MAC2Macie",
               "Enable-MAC2OrganizationAdminAccount",
               "Get-MAC2BucketStatistic",
               "Get-MAC2ClassificationExportConfiguration",
               "Get-MAC2CustomDataIdentifier",
               "Get-MAC2Finding",
               "Get-MAC2FindingsFilter",
               "Get-MAC2FindingStatistic",
               "Get-MAC2InvitationsCount",
               "Get-MAC2MacieSession",
               "Get-MAC2MasterAccount",
               "Get-MAC2Member",
               "Get-MAC2UsageStatistic",
               "Get-MAC2UsageTotal",
               "Get-MAC2ClassificationJobList",
               "Get-MAC2CustomDataIdentifierList",
               "Get-MAC2FindingList",
               "Get-MAC2FindingsFilterList",
               "Get-MAC2InvitationList",
               "Get-MAC2MemberList",
               "Get-MAC2OrganizationAdminAccountList",
               "Get-MAC2ResourceTag",
               "Write-MAC2ClassificationExportConfiguration",
               "Add-MAC2ResourceTag",
               "Test-MAC2CustomDataIdentifier",
               "Remove-MAC2ResourceTag",
               "Update-MAC2ClassificationJob",
               "Update-MAC2FindingsFilter",
               "Update-MAC2MacieSession",
               "Update-MAC2MemberSession",
               "Update-MAC2OrganizationConfiguration")
}

_awsArgumentCompleterRegistration $MAC2_SelectCompleters $MAC2_SelectMap

