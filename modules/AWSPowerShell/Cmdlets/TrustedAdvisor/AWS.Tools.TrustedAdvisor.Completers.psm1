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

# Argument completions for service Trusted Advisor


$TA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.TrustedAdvisor.ExclusionStatus
        {
            ($_ -eq "Get-TAOrganizationRecommendationResourceList/ExclusionStatus") -Or
            ($_ -eq "Get-TARecommendationResourceList/ExclusionStatus")
        }
        {
            $v = "excluded","included"
            break
        }

        # Amazon.TrustedAdvisor.RecommendationLanguage
        {
            ($_ -eq "Get-TACheckList/Language") -Or
            ($_ -eq "Get-TARecommendation/Language") -Or
            ($_ -eq "Get-TARecommendationList/Language") -Or
            ($_ -eq "Get-TARecommendationResourceList/Language")
        }
        {
            $v = "de","en","es","fr","id","it","ja","ko","pt_BR","zh","zh_TW"
            break
        }

        # Amazon.TrustedAdvisor.RecommendationPillar
        {
            ($_ -eq "Get-TACheckList/Pillar") -Or
            ($_ -eq "Get-TAOrganizationRecommendationList/Pillar") -Or
            ($_ -eq "Get-TARecommendationList/Pillar")
        }
        {
            $v = "cost_optimizing","fault_tolerance","operational_excellence","performance","security","service_limits"
            break
        }

        # Amazon.TrustedAdvisor.RecommendationSource
        {
            ($_ -eq "Get-TACheckList/Source") -Or
            ($_ -eq "Get-TAOrganizationRecommendationList/Source") -Or
            ($_ -eq "Get-TARecommendationList/Source")
        }
        {
            $v = "aws_config","compute_optimizer","cost_explorer","cost_optimization_hub","lse","manual","pse","rds","resilience","resilience_hub","security_hub","stir","ta_check","well_architected"
            break
        }

        # Amazon.TrustedAdvisor.RecommendationStatus
        {
            ($_ -eq "Get-TAOrganizationRecommendationList/Status") -Or
            ($_ -eq "Get-TARecommendationList/Status")
        }
        {
            $v = "error","ok","warning"
            break
        }

        # Amazon.TrustedAdvisor.RecommendationType
        {
            ($_ -eq "Get-TAOrganizationRecommendationList/Type") -Or
            ($_ -eq "Get-TARecommendationList/Type")
        }
        {
            $v = "priority","standard"
            break
        }

        # Amazon.TrustedAdvisor.ResourceStatus
        {
            ($_ -eq "Get-TAOrganizationRecommendationResourceList/Status") -Or
            ($_ -eq "Get-TARecommendationResourceList/Status")
        }
        {
            $v = "error","ok","warning"
            break
        }

        # Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStage
        {
            ($_ -eq "Update-TAOrganizationRecommendationLifecycle/LifecycleStage") -Or
            ($_ -eq "Update-TARecommendationLifecycle/LifecycleStage")
        }
        {
            $v = "dismissed","in_progress","pending_response","resolved"
            break
        }

        # Amazon.TrustedAdvisor.UpdateRecommendationLifecycleStageReasonCode
        {
            ($_ -eq "Update-TAOrganizationRecommendationLifecycle/UpdateReasonCode") -Or
            ($_ -eq "Update-TARecommendationLifecycle/UpdateReasonCode")
        }
        {
            $v = "low_priority","non_critical_account","not_applicable","other","other_methods_available","temporary_account","valid_business_case"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TA_map = @{
    "ExclusionStatus"=@("Get-TAOrganizationRecommendationResourceList","Get-TARecommendationResourceList")
    "Language"=@("Get-TACheckList","Get-TARecommendation","Get-TARecommendationList","Get-TARecommendationResourceList")
    "LifecycleStage"=@("Update-TAOrganizationRecommendationLifecycle","Update-TARecommendationLifecycle")
    "Pillar"=@("Get-TACheckList","Get-TAOrganizationRecommendationList","Get-TARecommendationList")
    "Source"=@("Get-TACheckList","Get-TAOrganizationRecommendationList","Get-TARecommendationList")
    "Status"=@("Get-TAOrganizationRecommendationList","Get-TAOrganizationRecommendationResourceList","Get-TARecommendationList","Get-TARecommendationResourceList")
    "Type"=@("Get-TAOrganizationRecommendationList","Get-TARecommendationList")
    "UpdateReasonCode"=@("Update-TAOrganizationRecommendationLifecycle","Update-TARecommendationLifecycle")
}

_awsArgumentCompleterRegistration $TA_Completers $TA_map

$TA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TA.$($commandName.Replace('-', ''))Cmdlet]"
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

$TA_SelectMap = @{
    "Select"=@("Update-TAUpdateRecommendationResourceExclusionBatch",
               "Get-TAOrganizationRecommendation",
               "Get-TARecommendation",
               "Get-TACheckList",
               "Get-TAOrganizationRecommendationAccountList",
               "Get-TAOrganizationRecommendationResourceList",
               "Get-TAOrganizationRecommendationList",
               "Get-TARecommendationResourceList",
               "Get-TARecommendationList",
               "Update-TAOrganizationRecommendationLifecycle",
               "Update-TARecommendationLifecycle")
}

_awsArgumentCompleterRegistration $TA_SelectCompleters $TA_SelectMap

