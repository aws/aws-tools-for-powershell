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

# Argument completions for service Amazon GuardDuty


$GD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GuardDuty.DestinationType
        "New-GDPublishingDestination/DestinationType"
        {
            $v = "S3"
            break
        }

        # Amazon.GuardDuty.Feedback
        "Update-GDFindingFeedback/Feedback"
        {
            $v = "NOT_USEFUL","USEFUL"
            break
        }

        # Amazon.GuardDuty.FilterAction
        {
            ($_ -eq "New-GDFilter/Action") -Or
            ($_ -eq "Update-GDFilter/Action")
        }
        {
            $v = "ARCHIVE","NOOP"
            break
        }

        # Amazon.GuardDuty.FindingPublishingFrequency
        {
            ($_ -eq "New-GDDetector/FindingPublishingFrequency") -Or
            ($_ -eq "Update-GDDetector/FindingPublishingFrequency")
        }
        {
            $v = "FIFTEEN_MINUTES","ONE_HOUR","SIX_HOURS"
            break
        }

        # Amazon.GuardDuty.IpSetFormat
        "New-GDIPSet/Format"
        {
            $v = "ALIEN_VAULT","FIRE_EYE","OTX_CSV","PROOF_POINT","STIX","TXT"
            break
        }

        # Amazon.GuardDuty.ThreatIntelSetFormat
        "New-GDThreatIntelSet/Format"
        {
            $v = "ALIEN_VAULT","FIRE_EYE","OTX_CSV","PROOF_POINT","STIX","TXT"
            break
        }

        # Amazon.GuardDuty.UsageStatisticType
        "Get-GDUsageStatistic/UsageStatisticType"
        {
            $v = "SUM_BY_ACCOUNT","SUM_BY_DATA_SOURCE","SUM_BY_RESOURCE","TOP_RESOURCES"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GD_map = @{
    "Action"=@("New-GDFilter","Update-GDFilter")
    "DestinationType"=@("New-GDPublishingDestination")
    "Feedback"=@("Update-GDFindingFeedback")
    "FindingPublishingFrequency"=@("New-GDDetector","Update-GDDetector")
    "Format"=@("New-GDIPSet","New-GDThreatIntelSet")
    "UsageStatisticType"=@("Get-GDUsageStatistic")
}

_awsArgumentCompleterRegistration $GD_Completers $GD_map

$GD_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GD.$($commandName.Replace('-', ''))Cmdlet]"
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

$GD_SelectMap = @{
    "Select"=@("Receive-GDAdministratorInvitation",
               "Confirm-GDInvitation",
               "Backup-GDFinding",
               "New-GDDetector",
               "New-GDFilter",
               "New-GDIPSet",
               "New-GDMember",
               "New-GDPublishingDestination",
               "New-GDSampleFinding",
               "New-GDThreatIntelSet",
               "Deny-GDInvitation",
               "Remove-GDDetector",
               "Remove-GDFilter",
               "Remove-GDInvitation",
               "Remove-GDIPSet",
               "Remove-GDMember",
               "Remove-GDPublishingDestination",
               "Remove-GDThreatIntelSet",
               "Get-GDOrganizationConfiguration",
               "Get-GDPublishingDestination",
               "Disable-GDOrganizationAdminAccount",
               "Remove-GDFromAdministratorAccount",
               "Unregister-GDFromMasterAccount",
               "Unregister-GDMember",
               "Enable-GDOrganizationAdminAccount",
               "Get-GDAdministratorAccount",
               "Get-GDDetector",
               "Get-GDFilter",
               "Get-GDFinding",
               "Get-GDFindingStatistic",
               "Get-GDInvitationCount",
               "Get-GDIPSet",
               "Get-GDMasterAccount",
               "Get-GDMemberDetector",
               "Get-GDMember",
               "Get-GDRemainingFreeTrialDay",
               "Get-GDThreatIntelSet",
               "Get-GDUsageStatistic",
               "Send-GDMemberInvitation",
               "Get-GDDetectorList",
               "Get-GDFilterList",
               "Get-GDFindingList",
               "Get-GDInvitationList",
               "Get-GDIPSetList",
               "Get-GDMemberList",
               "Get-GDOrganizationAdminAccountList",
               "Get-GDPublishingDestinationList",
               "Get-GDResourceTag",
               "Get-GDThreatIntelSetList",
               "Start-GDMonitoringMember",
               "Stop-GDMonitoringMember",
               "Add-GDResourceTag",
               "Restore-GDFinding",
               "Remove-GDResourceTag",
               "Update-GDDetector",
               "Update-GDFilter",
               "Update-GDFindingFeedback",
               "Update-GDIPSet",
               "Update-GDMemberDetector",
               "Update-GDOrganizationConfiguration",
               "Update-GDPublishingDestination",
               "Update-GDThreatIntelSet")
}

_awsArgumentCompleterRegistration $GD_SelectCompleters $GD_SelectMap

