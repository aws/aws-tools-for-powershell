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

# Argument completions for service AWS Cost Explorer


$CE_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CostExplorer.AccountScope
        {
            ($_ -eq "Get-CEReservationPurchaseRecommendation/AccountScope") -Or
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/AccountScope")
        }
        {
            $v = "LINKED","PAYER"
            break
        }

        # Amazon.CostExplorer.Context
        "Get-CEDimensionValue/Context"
        {
            $v = "COST_AND_USAGE","RESERVATIONS","SAVINGS_PLANS"
            break
        }

        # Amazon.CostExplorer.CostCategoryRuleVersion
        {
            ($_ -eq "New-CECostCategoryDefinition/RuleVersion") -Or
            ($_ -eq "Update-CECostCategoryDefinition/RuleVersion")
        }
        {
            $v = "CostCategoryExpression.v1"
            break
        }

        # Amazon.CostExplorer.Dimension
        "Get-CEDimensionValue/Dimension"
        {
            $v = "AZ","BILLING_ENTITY","CACHE_ENGINE","DATABASE_ENGINE","DEPLOYMENT_OPTION","INSTANCE_TYPE","INSTANCE_TYPE_FAMILY","LEGAL_ENTITY_NAME","LINKED_ACCOUNT","LINKED_ACCOUNT_NAME","OPERATING_SYSTEM","OPERATION","PAYMENT_OPTION","PLATFORM","PURCHASE_TYPE","RECORD_TYPE","REGION","RESERVATION_ID","RESOURCE_ID","RIGHTSIZING_TYPE","SAVINGS_PLANS_TYPE","SAVINGS_PLAN_ARN","SCOPE","SERVICE","SERVICE_CODE","SUBSCRIPTION_ID","TENANCY","USAGE_TYPE","USAGE_TYPE_GROUP"
            break
        }

        # Amazon.CostExplorer.Granularity
        {
            ($_ -eq "Get-CECostAndUsage/Granularity") -Or
            ($_ -eq "Get-CECostAndUsageWithResource/Granularity") -Or
            ($_ -eq "Get-CECostForecast/Granularity") -Or
            ($_ -eq "Get-CEReservationCoverage/Granularity") -Or
            ($_ -eq "Get-CEReservationUtilization/Granularity") -Or
            ($_ -eq "Get-CESavingsPlansCoverage/Granularity") -Or
            ($_ -eq "Get-CESavingsPlansUtilization/Granularity") -Or
            ($_ -eq "Get-CEUsageForecast/Granularity")
        }
        {
            $v = "DAILY","HOURLY","MONTHLY"
            break
        }

        # Amazon.CostExplorer.LookbackPeriodInDays
        {
            ($_ -eq "Get-CEReservationPurchaseRecommendation/LookbackPeriodInDays") -Or
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/LookbackPeriodInDays")
        }
        {
            $v = "SEVEN_DAYS","SIXTY_DAYS","THIRTY_DAYS"
            break
        }

        # Amazon.CostExplorer.Metric
        {
            ($_ -eq "Get-CECostForecast/Metric") -Or
            ($_ -eq "Get-CEUsageForecast/Metric")
        }
        {
            $v = "AMORTIZED_COST","BLENDED_COST","NET_AMORTIZED_COST","NET_UNBLENDED_COST","NORMALIZED_USAGE_AMOUNT","UNBLENDED_COST","USAGE_QUANTITY"
            break
        }

        # Amazon.CostExplorer.OfferingClass
        "Get-CEReservationPurchaseRecommendation/ServiceSpecification_EC2Specification_OfferingClass"
        {
            $v = "CONVERTIBLE","STANDARD"
            break
        }

        # Amazon.CostExplorer.PaymentOption
        {
            ($_ -eq "Get-CEReservationPurchaseRecommendation/PaymentOption") -Or
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/PaymentOption")
        }
        {
            $v = "ALL_UPFRONT","HEAVY_UTILIZATION","LIGHT_UTILIZATION","MEDIUM_UTILIZATION","NO_UPFRONT","PARTIAL_UPFRONT"
            break
        }

        # Amazon.CostExplorer.RecommendationTarget
        "Get-CERightsizingRecommendation/Configuration_RecommendationTarget"
        {
            $v = "CROSS_INSTANCE_FAMILY","SAME_INSTANCE_FAMILY"
            break
        }

        # Amazon.CostExplorer.SupportedSavingsPlansType
        "Get-CESavingsPlansPurchaseRecommendation/SavingsPlansType"
        {
            $v = "COMPUTE_SP","EC2_INSTANCE_SP"
            break
        }

        # Amazon.CostExplorer.TermInYears
        {
            ($_ -eq "Get-CEReservationPurchaseRecommendation/TermInYears") -Or
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/TermInYears")
        }
        {
            $v = "ONE_YEAR","THREE_YEARS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CE_map = @{
    "AccountScope"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
    "Configuration_RecommendationTarget"=@("Get-CERightsizingRecommendation")
    "Context"=@("Get-CEDimensionValue")
    "Dimension"=@("Get-CEDimensionValue")
    "Granularity"=@("Get-CECostAndUsage","Get-CECostAndUsageWithResource","Get-CECostForecast","Get-CEReservationCoverage","Get-CEReservationUtilization","Get-CESavingsPlansCoverage","Get-CESavingsPlansUtilization","Get-CEUsageForecast")
    "LookbackPeriodInDays"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
    "Metric"=@("Get-CECostForecast","Get-CEUsageForecast")
    "PaymentOption"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
    "RuleVersion"=@("New-CECostCategoryDefinition","Update-CECostCategoryDefinition")
    "SavingsPlansType"=@("Get-CESavingsPlansPurchaseRecommendation")
    "ServiceSpecification_EC2Specification_OfferingClass"=@("Get-CEReservationPurchaseRecommendation")
    "TermInYears"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
}

_awsArgumentCompleterRegistration $CE_Completers $CE_map

$CE_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CE.$($commandName.Replace('-', ''))Cmdlet]"
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

$CE_SelectMap = @{
    "Select"=@("New-CECostCategoryDefinition",
               "Remove-CECostCategoryDefinition",
               "Get-CECostCategoryDefinition",
               "Get-CECostAndUsage",
               "Get-CECostAndUsageWithResource",
               "Get-CECostForecast",
               "Get-CEDimensionValue",
               "Get-CEReservationCoverage",
               "Get-CEReservationPurchaseRecommendation",
               "Get-CEReservationUtilization",
               "Get-CERightsizingRecommendation",
               "Get-CESavingsPlansCoverage",
               "Get-CESavingsPlansPurchaseRecommendation",
               "Get-CESavingsPlansUtilization",
               "Get-CESavingsPlansUtilizationDetail",
               "Get-CETag",
               "Get-CEUsageForecast",
               "Get-CECostCategoryDefinitionList",
               "Update-CECostCategoryDefinition")
}

_awsArgumentCompleterRegistration $CE_SelectCompleters $CE_SelectMap

