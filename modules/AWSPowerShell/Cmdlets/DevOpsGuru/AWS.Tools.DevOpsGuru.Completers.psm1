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

# Argument completions for service Amazon DevOps Guru


$DGURU_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DevOpsGuru.EventClass
        "Get-DGURUEventList/Filters_EventClass"
        {
            $v = "CONFIG_CHANGE","DEPLOYMENT","INFRASTRUCTURE","SCHEMA_CHANGE","SECURITY_CHANGE"
            break
        }

        # Amazon.DevOpsGuru.EventDataSource
        "Get-DGURUEventList/Filters_DataSource"
        {
            $v = "AWS_CLOUD_TRAIL","AWS_CODE_DEPLOY"
            break
        }

        # Amazon.DevOpsGuru.InsightType
        {
            ($_ -eq "Get-DGURUOrganizationInsightList/StatusFilter_Any_Type") -Or
            ($_ -eq "Get-DGURUOrganizationInsightList/StatusFilter_Closed_Type") -Or
            ($_ -eq "Get-DGURUOrganizationInsightList/StatusFilter_Ongoing_Type") -Or
            ($_ -eq "Search-DGURUInsight/Type") -Or
            ($_ -eq "Search-DGURUOrganizationInsight/Type")
        }
        {
            $v = "PROACTIVE","REACTIVE"
            break
        }

        # Amazon.DevOpsGuru.Locale
        "Get-DGURURecommendationList/Locale"
        {
            $v = "DE_DE","EN_GB","EN_US","ES_ES","FR_FR","IT_IT","JA_JP","KO_KR","PT_BR","ZH_CN","ZH_TW"
            break
        }

        # Amazon.DevOpsGuru.OrganizationResourceCollectionType
        "Get-DGURUOrganizationResourceCollectionHealth/OrganizationResourceCollectionType"
        {
            $v = "AWS_ACCOUNT","AWS_CLOUD_FORMATION","AWS_SERVICE","AWS_TAGS"
            break
        }

        # Amazon.DevOpsGuru.ResourceCollectionType
        {
            ($_ -eq "Get-DGURUResourceCollection/ResourceCollectionType") -Or
            ($_ -eq "Get-DGURUResourceCollectionHealth/ResourceCollectionType")
        }
        {
            $v = "AWS_CLOUD_FORMATION","AWS_SERVICE","AWS_TAGS"
            break
        }

        # Amazon.DevOpsGuru.UpdateResourceCollectionAction
        "Update-DGURUResourceCollection/Action"
        {
            $v = "ADD","REMOVE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DGURU_map = @{
    "Action"=@("Update-DGURUResourceCollection")
    "Filters_DataSource"=@("Get-DGURUEventList")
    "Filters_EventClass"=@("Get-DGURUEventList")
    "Locale"=@("Get-DGURURecommendationList")
    "OrganizationResourceCollectionType"=@("Get-DGURUOrganizationResourceCollectionHealth")
    "ResourceCollectionType"=@("Get-DGURUResourceCollection","Get-DGURUResourceCollectionHealth")
    "StatusFilter_Any_Type"=@("Get-DGURUOrganizationInsightList")
    "StatusFilter_Closed_Type"=@("Get-DGURUOrganizationInsightList")
    "StatusFilter_Ongoing_Type"=@("Get-DGURUOrganizationInsightList")
    "Type"=@("Search-DGURUInsight","Search-DGURUOrganizationInsight")
}

_awsArgumentCompleterRegistration $DGURU_Completers $DGURU_map

$DGURU_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DGURU.$($commandName.Replace('-', ''))Cmdlet]"
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

$DGURU_SelectMap = @{
    "Select"=@("Add-DGURUNotificationChannel",
               "Get-DGURUAccountHealth",
               "Get-DGURUAccountOverview",
               "Get-DGURUAnomaly",
               "Get-DGURUFeedback",
               "Get-DGURUInsight",
               "Get-DGURUOrganizationHealth",
               "Get-DGURUOrganizationOverview",
               "Get-DGURUOrganizationResourceCollectionHealth",
               "Get-DGURUResourceCollectionHealth",
               "Get-DGURUServiceIntegration",
               "Get-DGURUCostEstimation",
               "Get-DGURUResourceCollection",
               "Get-DGURUAnomaliesForInsightList",
               "Get-DGURUEventList",
               "Get-DGURUInsightList",
               "Get-DGURUNotificationChannelList",
               "Get-DGURUOrganizationInsightList",
               "Get-DGURURecommendationList",
               "Write-DGURUFeedback",
               "Remove-DGURUNotificationChannel",
               "Search-DGURUInsight",
               "Search-DGURUOrganizationInsight",
               "Start-DGURUCostEstimation",
               "Update-DGURUResourceCollection",
               "Update-DGURUServiceIntegration")
}

_awsArgumentCompleterRegistration $DGURU_SelectCompleters $DGURU_SelectMap

