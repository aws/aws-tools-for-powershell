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

# Argument completions for service AWS Resilience Hub


$RESH_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ResilienceHub.AppAssessmentScheduleType
        {
            ($_ -eq "New-RESHApp/AssessmentSchedule") -Or
            ($_ -eq "Update-RESHApp/AssessmentSchedule")
        }
        {
            $v = "Daily","Disabled"
            break
        }

        # Amazon.ResilienceHub.AssessmentInvoker
        "Get-RESHAppAssessmentList/Invoker"
        {
            $v = "System","User"
            break
        }

        # Amazon.ResilienceHub.ComplianceStatus
        "Get-RESHAppAssessmentList/ComplianceStatus"
        {
            $v = "PolicyBreached","PolicyMet"
            break
        }

        # Amazon.ResilienceHub.DataLocationConstraint
        {
            ($_ -eq "New-RESHResiliencyPolicy/DataLocationConstraint") -Or
            ($_ -eq "Update-RESHResiliencyPolicy/DataLocationConstraint")
        }
        {
            $v = "AnyLocation","SameContinent","SameCountry"
            break
        }

        # Amazon.ResilienceHub.ResiliencyPolicyTier
        {
            ($_ -eq "New-RESHResiliencyPolicy/Tier") -Or
            ($_ -eq "Update-RESHResiliencyPolicy/Tier")
        }
        {
            $v = "CoreServices","Critical","Important","MissionCritical","NonCritical"
            break
        }

        # Amazon.ResilienceHub.ResourceImportStrategyType
        "Import-RESHResourcesToDraftAppVersion/ImportStrategy"
        {
            $v = "AddOnly","ReplaceAll"
            break
        }

        # Amazon.ResilienceHub.TemplateFormat
        "New-RESHRecommendationTemplate/Format"
        {
            $v = "CfnJson","CfnYaml"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RESH_map = @{
    "AssessmentSchedule"=@("New-RESHApp","Update-RESHApp")
    "ComplianceStatus"=@("Get-RESHAppAssessmentList")
    "DataLocationConstraint"=@("New-RESHResiliencyPolicy","Update-RESHResiliencyPolicy")
    "Format"=@("New-RESHRecommendationTemplate")
    "ImportStrategy"=@("Import-RESHResourcesToDraftAppVersion")
    "Invoker"=@("Get-RESHAppAssessmentList")
    "Tier"=@("New-RESHResiliencyPolicy","Update-RESHResiliencyPolicy")
}

_awsArgumentCompleterRegistration $RESH_Completers $RESH_map

$RESH_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.RESH.$($commandName.Replace('-', ''))Cmdlet]"
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

$RESH_SelectMap = @{
    "Select"=@("Add-RESHDraftAppVersionResourceMapping",
               "New-RESHApp",
               "New-RESHAppVersionAppComponent",
               "New-RESHAppVersionResource",
               "New-RESHRecommendationTemplate",
               "New-RESHResiliencyPolicy",
               "Remove-RESHApp",
               "Remove-RESHAppAssessment",
               "Remove-RESHAppInputSource",
               "Remove-RESHAppVersionAppComponent",
               "Remove-RESHAppVersionResource",
               "Remove-RESHRecommendationTemplate",
               "Remove-RESHResiliencyPolicy",
               "Get-RESHApp",
               "Get-RESHAppAssessment",
               "Get-RESHAppVersion",
               "Get-RESHAppVersionAppComponent",
               "Get-RESHAppVersionResource",
               "Get-RESHAppVersionResourcesResolutionStatus",
               "Get-RESHAppVersionTemplate",
               "Get-RESHDraftAppVersionResourcesImportStatus",
               "Get-RESHResiliencyPolicy",
               "Import-RESHResourcesToDraftAppVersion",
               "Get-RESHAlarmRecommendationList",
               "Get-RESHAppAssessmentList",
               "Get-RESHAppComponentComplianceList",
               "Get-RESHAppComponentRecommendationList",
               "Get-RESHAppInputSourceList",
               "Get-RESHAppList",
               "Get-RESHAppVersionAppComponentList",
               "Get-RESHAppVersionResourceMappingList",
               "Get-RESHAppVersionResourceList",
               "Get-RESHAppVersionList",
               "Get-RESHRecommendationTemplateList",
               "Get-RESHResiliencyPolicyList",
               "Get-RESHSopRecommendationList",
               "Get-RESHSuggestedResiliencyPolicyList",
               "Get-RESHResourceTag",
               "Get-RESHTestRecommendationList",
               "Get-RESHUnsupportedAppVersionResourceList",
               "Publish-RESHAppVersion",
               "Write-RESHDraftAppVersionTemplate",
               "Remove-RESHDraftAppVersionResourceMapping",
               "Resolve-RESHAppVersionResource",
               "Start-RESHAppAssessment",
               "Add-RESHResourceTag",
               "Remove-RESHResourceTag",
               "Update-RESHApp",
               "Update-RESHAppVersion",
               "Update-RESHAppVersionAppComponent",
               "Update-RESHAppVersionResource",
               "Update-RESHResiliencyPolicy")
}

_awsArgumentCompleterRegistration $RESH_SelectCompleters $RESH_SelectMap

