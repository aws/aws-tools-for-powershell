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

# Argument completions for service AWS Compute Optimizer


$CO_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ComputeOptimizer.EnhancedInfrastructureMetrics
        "Write-CORecommendationPreference/EnhancedInfrastructureMetrics"
        {
            $v = "Active","Inactive"
            break
        }

        # Amazon.ComputeOptimizer.ExternalMetricsSource
        "Write-CORecommendationPreference/ExternalMetricsPreference_Source"
        {
            $v = "Datadog","Dynatrace","Instana","NewRelic"
            break
        }

        # Amazon.ComputeOptimizer.FileFormat
        {
            ($_ -eq "Export-COAutoScalingGroupRecommendation/FileFormat") -Or
            ($_ -eq "Export-COEBSVolumeRecommendation/FileFormat") -Or
            ($_ -eq "Export-COEC2InstanceRecommendation/FileFormat") -Or
            ($_ -eq "Export-COECSServiceRecommendation/FileFormat") -Or
            ($_ -eq "Export-COLambdaFunctionRecommendation/FileFormat") -Or
            ($_ -eq "Export-COLicenseRecommendation/FileFormat")
        }
        {
            $v = "Csv"
            break
        }

        # Amazon.ComputeOptimizer.InferredWorkloadTypesPreference
        "Write-CORecommendationPreference/InferredWorkloadTypes"
        {
            $v = "Active","Inactive"
            break
        }

        # Amazon.ComputeOptimizer.MetricStatistic
        {
            ($_ -eq "Get-COEC2RecommendationProjectedMetric/Stat") -Or
            ($_ -eq "Get-COECSServiceRecommendationProjectedMetric/Stat")
        }
        {
            $v = "Average","Maximum"
            break
        }

        # Amazon.ComputeOptimizer.ResourceType
        {
            ($_ -eq "Get-CORecommendationPreference/ResourceType") -Or
            ($_ -eq "Remove-CORecommendationPreference/ResourceType") -Or
            ($_ -eq "Write-CORecommendationPreference/ResourceType")
        }
        {
            $v = "AutoScalingGroup","EbsVolume","Ec2Instance","EcsService","LambdaFunction","License","NotApplicable"
            break
        }

        # Amazon.ComputeOptimizer.ScopeName
        {
            ($_ -eq "Get-CORecommendationPreference/Scope_Name") -Or
            ($_ -eq "Remove-CORecommendationPreference/Scope_Name") -Or
            ($_ -eq "Write-CORecommendationPreference/Scope_Name")
        }
        {
            $v = "AccountId","Organization","ResourceArn"
            break
        }

        # Amazon.ComputeOptimizer.Status
        "Update-COEnrollmentStatus/Status"
        {
            $v = "Active","Failed","Inactive","Pending"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CO_map = @{
    "EnhancedInfrastructureMetrics"=@("Write-CORecommendationPreference")
    "ExternalMetricsPreference_Source"=@("Write-CORecommendationPreference")
    "FileFormat"=@("Export-COAutoScalingGroupRecommendation","Export-COEBSVolumeRecommendation","Export-COEC2InstanceRecommendation","Export-COECSServiceRecommendation","Export-COLambdaFunctionRecommendation","Export-COLicenseRecommendation")
    "InferredWorkloadTypes"=@("Write-CORecommendationPreference")
    "ResourceType"=@("Get-CORecommendationPreference","Remove-CORecommendationPreference","Write-CORecommendationPreference")
    "Scope_Name"=@("Get-CORecommendationPreference","Remove-CORecommendationPreference","Write-CORecommendationPreference")
    "Stat"=@("Get-COEC2RecommendationProjectedMetric","Get-COECSServiceRecommendationProjectedMetric")
    "Status"=@("Update-COEnrollmentStatus")
}

_awsArgumentCompleterRegistration $CO_Completers $CO_map

$CO_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CO.$($commandName.Replace('-', ''))Cmdlet]"
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

$CO_SelectMap = @{
    "Select"=@("Remove-CORecommendationPreference",
               "Get-CORecommendationExportJob",
               "Export-COAutoScalingGroupRecommendation",
               "Export-COEBSVolumeRecommendation",
               "Export-COEC2InstanceRecommendation",
               "Export-COECSServiceRecommendation",
               "Export-COLambdaFunctionRecommendation",
               "Export-COLicenseRecommendation",
               "Get-COAutoScalingGroupRecommendation",
               "Get-COEBSVolumeRecommendation",
               "Get-COEC2InstanceRecommendation",
               "Get-COEC2RecommendationProjectedMetric",
               "Get-COECSServiceRecommendationProjectedMetric",
               "Get-COECSServiceRecommendation",
               "Get-COEffectiveRecommendationPreference",
               "Get-COEnrollmentStatus",
               "Get-COEnrollmentStatusesForOrganization",
               "Get-COLambdaFunctionRecommendation",
               "Get-COLicenseRecommendation",
               "Get-CORecommendationPreference",
               "Get-CORecommendationSummary",
               "Write-CORecommendationPreference",
               "Update-COEnrollmentStatus")
}

_awsArgumentCompleterRegistration $CO_SelectCompleters $CO_SelectMap

