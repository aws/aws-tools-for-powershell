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

# Argument completions for service AWS Resilience Hub V2


$RH2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Resiliencehubv2.AssertionSource
        "Get-RH2AssertionList/Source"
        {
            $v = "AI_GENERATED","USER"
            break
        }

        # Amazon.Resiliencehubv2.AssessmentSortField
        "Get-RH2FailureModeAssessmentList/SortBy"
        {
            $v = "STARTED_AT"
            break
        }

        # Amazon.Resiliencehubv2.AssessmentStatus
        "Get-RH2ServiceList/AssessmentStatus"
        {
            $v = "FAILED","IN_PROGRESS","NOT_STARTED","PENDING","SUCCESS"
            break
        }

        # Amazon.Resiliencehubv2.DependencyCriticality
        "Update-RH2Dependency/Criticality"
        {
            $v = "HARD","SOFT","UNKNOWN"
            break
        }

        # Amazon.Resiliencehubv2.DependencyDiscoveryInput
        {
            ($_ -eq "New-RH2Service/DependencyDiscovery") -Or
            ($_ -eq "Update-RH2Service/DependencyDiscovery")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Resiliencehubv2.FailureCategory
        "Get-RH2FailureModeFindingList/FailureCategory"
        {
            $v = "EXCESSIVE_LATENCY","EXCESSIVE_LOAD","MISCONFIGURATION_AND_BUGS","SHARED_FATE","SINGLE_POINT_OF_FAILURE"
            break
        }

        # Amazon.Resiliencehubv2.FindingSeverity
        "Get-RH2FailureModeFindingList/Severity"
        {
            $v = "HIGH","LOW","MEDIUM"
            break
        }

        # Amazon.Resiliencehubv2.FindingStatus
        {
            ($_ -eq "Get-RH2FailureModeFindingList/Status") -Or
            ($_ -eq "Update-RH2FailureModeFinding/Status")
        }
        {
            $v = "IRRELEVANT","OPEN","RESOLVED"
            break
        }

        # Amazon.Resiliencehubv2.InputSourceType
        "Get-RH2InputSourceList/Type"
        {
            $v = "CFN_STACK","DESIGN_FILE","EKS","MONITORING","TAGS","TERRAFORM"
            break
        }

        # Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach
        {
            ($_ -eq "New-RH2Policy/MultiAz_DisasterRecoveryApproach") -Or
            ($_ -eq "Update-RH2Policy/MultiAz_DisasterRecoveryApproach") -Or
            ($_ -eq "Import-RH2Policy/MultiAzDisasterRecoveryApproach")
        }
        {
            $v = "ACTIVE_ACTIVE","BACKUP_AND_RESTORE","HOT_STANDBY","PILOT_LIGHT","WARM_STANDBY"
            break
        }

        # Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach
        {
            ($_ -eq "New-RH2Policy/MultiRegion_DisasterRecoveryApproach") -Or
            ($_ -eq "Update-RH2Policy/MultiRegion_DisasterRecoveryApproach") -Or
            ($_ -eq "Import-RH2Policy/MultiRegionDisasterRecoveryApproach")
        }
        {
            $v = "ACTIVE_ACTIVE","BACKUP_AND_RESTORE","HOT_STANDBY","PILOT_LIGHT","WARM_STANDBY"
            break
        }

        # Amazon.Resiliencehubv2.QueryGranularity
        "Get-RH2DependencyList/QueryRangeGranularity"
        {
            $v = "DAILY","HOURLY"
            break
        }

        # Amazon.Resiliencehubv2.ReportType
        {
            ($_ -eq "Get-RH2ReportList/ReportType") -Or
            ($_ -eq "New-RH2Report/ReportType")
        }
        {
            $v = "FAILURE_MODE"
            break
        }

        # Amazon.Resiliencehubv2.ServiceFunctionCriticality
        {
            ($_ -eq "New-RH2ServiceFunction/Criticality") -Or
            ($_ -eq "Update-RH2ServiceFunction/Criticality")
        }
        {
            $v = "PRIMARY","SUPPLEMENTAL"
            break
        }

        # Amazon.Resiliencehubv2.SortOrder
        "Get-RH2FailureModeAssessmentList/SortOrder"
        {
            $v = "ASC","DESC"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RH2_map = @{
    "AssessmentStatus"=@("Get-RH2ServiceList")
    "Criticality"=@("New-RH2ServiceFunction","Update-RH2Dependency","Update-RH2ServiceFunction")
    "DependencyDiscovery"=@("New-RH2Service","Update-RH2Service")
    "FailureCategory"=@("Get-RH2FailureModeFindingList")
    "MultiAz_DisasterRecoveryApproach"=@("New-RH2Policy","Update-RH2Policy")
    "MultiAzDisasterRecoveryApproach"=@("Import-RH2Policy")
    "MultiRegion_DisasterRecoveryApproach"=@("New-RH2Policy","Update-RH2Policy")
    "MultiRegionDisasterRecoveryApproach"=@("Import-RH2Policy")
    "QueryRangeGranularity"=@("Get-RH2DependencyList")
    "ReportType"=@("Get-RH2ReportList","New-RH2Report")
    "Severity"=@("Get-RH2FailureModeFindingList")
    "SortBy"=@("Get-RH2FailureModeAssessmentList")
    "SortOrder"=@("Get-RH2FailureModeAssessmentList")
    "Source"=@("Get-RH2AssertionList")
    "Status"=@("Get-RH2FailureModeFindingList","Update-RH2FailureModeFinding")
    "Type"=@("Get-RH2InputSourceList")
}

_awsArgumentCompleterRegistration $RH2_Completers $RH2_map

$RH2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.RH2.$($commandName.Replace('-', ''))Cmdlet]"
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

$RH2_SelectMap = @{
    "Select"=@("New-RH2Assertion",
               "New-RH2InputSource",
               "New-RH2Policy",
               "New-RH2Report",
               "New-RH2Service",
               "New-RH2ServiceFunction",
               "New-RH2ServiceFunctionResource",
               "New-RH2System",
               "New-RH2UserJourney",
               "Remove-RH2Assertion",
               "Remove-RH2InputSource",
               "Remove-RH2Policy",
               "Remove-RH2Service",
               "Remove-RH2ServiceFunction",
               "Remove-RH2ServiceFunctionResource",
               "Remove-RH2System",
               "Remove-RH2UserJourney",
               "Get-RH2FailureModeFinding",
               "Get-RH2Policy",
               "Get-RH2Service",
               "Get-RH2System",
               "Get-RH2UserJourney",
               "Import-RH2App",
               "Import-RH2Policy",
               "Get-RH2AssertionList",
               "Get-RH2DependencyList",
               "Get-RH2FailureModeAssessmentList",
               "Get-RH2FailureModeFindingList",
               "Get-RH2InputSourceList",
               "Get-RH2PolicyList",
               "Get-RH2ReportList",
               "Get-RH2ResourceList",
               "Get-RH2ServiceEventList",
               "Get-RH2ServiceFunctionList",
               "Get-RH2ServiceList",
               "Get-RH2ServiceTopologyEdgeList",
               "Get-RH2SystemEventList",
               "Get-RH2SystemList",
               "Get-RH2ResourceTag",
               "Get-RH2UserJourneyList",
               "Start-RH2FailureModeAssessment",
               "Add-RH2ResourceTag",
               "Remove-RH2ResourceTag",
               "Update-RH2Assertion",
               "Update-RH2Dependency",
               "Update-RH2FailureModeFinding",
               "Update-RH2Policy",
               "Update-RH2Service",
               "Update-RH2ServiceFunction",
               "Update-RH2System",
               "Update-RH2UserJourney")
}

_awsArgumentCompleterRegistration $RH2_SelectCompleters $RH2_SelectMap

