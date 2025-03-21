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

# Argument completions for service Amazon CloudWatch Application Insights


$CWAI_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ApplicationInsights.ConfigurationEventStatus
        "Get-CWAIConfigurationHistoryList/EventStatus"
        {
            $v = "ERROR","INFO","WARN"
            break
        }

        # Amazon.ApplicationInsights.GroupingType
        "New-CWAIApplication/GroupingType"
        {
            $v = "ACCOUNT_BASED"
            break
        }

        # Amazon.ApplicationInsights.RecommendationType
        "Get-CWAIComponentConfigurationRecommendation/RecommendationType"
        {
            $v = "ALL","INFRA_ONLY","WORKLOAD_ONLY"
            break
        }

        # Amazon.ApplicationInsights.Tier
        {
            ($_ -eq "Get-CWAIComponentConfigurationRecommendation/Tier") -Or
            ($_ -eq "Update-CWAIComponentConfiguration/Tier") -Or
            ($_ -eq "Add-CWAIWorkload/WorkloadConfiguration_Tier") -Or
            ($_ -eq "Update-CWAIWorkload/WorkloadConfiguration_Tier")
        }
        {
            $v = "ACTIVE_DIRECTORY","CUSTOM","DEFAULT","DOT_NET_CORE","DOT_NET_WEB","DOT_NET_WEB_TIER","DOT_NET_WORKER","JAVA_JMX","MYSQL","ORACLE","POSTGRESQL","SAP_ASE_HIGH_AVAILABILITY","SAP_ASE_SINGLE_NODE","SAP_HANA_HIGH_AVAILABILITY","SAP_HANA_MULTI_NODE","SAP_HANA_SINGLE_NODE","SAP_NETWEAVER_DISTRIBUTED","SAP_NETWEAVER_HIGH_AVAILABILITY","SAP_NETWEAVER_STANDARD","SHAREPOINT","SQL_SERVER","SQL_SERVER_ALWAYSON_AVAILABILITY_GROUP","SQL_SERVER_FAILOVER_CLUSTER_INSTANCE"
            break
        }

        # Amazon.ApplicationInsights.UpdateStatus
        "Update-CWAIProblem/UpdateStatus"
        {
            $v = "RESOLVED"
            break
        }

        # Amazon.ApplicationInsights.Visibility
        {
            ($_ -eq "Get-CWAIProblemList/Visibility") -Or
            ($_ -eq "Update-CWAIProblem/Visibility")
        }
        {
            $v = "IGNORED","VISIBLE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWAI_map = @{
    "EventStatus"=@("Get-CWAIConfigurationHistoryList")
    "GroupingType"=@("New-CWAIApplication")
    "RecommendationType"=@("Get-CWAIComponentConfigurationRecommendation")
    "Tier"=@("Get-CWAIComponentConfigurationRecommendation","Update-CWAIComponentConfiguration")
    "UpdateStatus"=@("Update-CWAIProblem")
    "Visibility"=@("Get-CWAIProblemList","Update-CWAIProblem")
    "WorkloadConfiguration_Tier"=@("Add-CWAIWorkload","Update-CWAIWorkload")
}

_awsArgumentCompleterRegistration $CWAI_Completers $CWAI_map

$CWAI_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CWAI.$($commandName.Replace('-', ''))Cmdlet]"
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

$CWAI_SelectMap = @{
    "Select"=@("Add-CWAIWorkload",
               "New-CWAIApplication",
               "New-CWAIComponent",
               "New-CWAILogPattern",
               "Remove-CWAIApplication",
               "Remove-CWAIComponent",
               "Remove-CWAILogPattern",
               "Get-CWAIApplication",
               "Get-CWAIComponent",
               "Get-CWAIComponentConfiguration",
               "Get-CWAIComponentConfigurationRecommendation",
               "Get-CWAILogPattern",
               "Get-CWAIObservation",
               "Get-CWAIProblem",
               "Get-CWAIProblemObservation",
               "Get-CWAIWorkload",
               "Get-CWAIApplicationList",
               "Get-CWAIComponentList",
               "Get-CWAIConfigurationHistoryList",
               "Get-CWAILogPatternList",
               "Get-CWAILogPatternSetList",
               "Get-CWAIProblemList",
               "Get-CWAIResourceTag",
               "Get-CWAIWorkloadList",
               "Remove-CWAIWorkload",
               "Add-CWAIResourceTag",
               "Remove-CWAIResourceTag",
               "Update-CWAIApplication",
               "Update-CWAIComponent",
               "Update-CWAIComponentConfiguration",
               "Update-CWAILogPattern",
               "Update-CWAIProblem",
               "Update-CWAIWorkload")
}

_awsArgumentCompleterRegistration $CWAI_SelectCompleters $CWAI_SelectMap

