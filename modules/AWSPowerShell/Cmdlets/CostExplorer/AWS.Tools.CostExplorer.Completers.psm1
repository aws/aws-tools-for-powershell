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
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/AccountScope") -Or
            ($_ -eq "Start-CECommitmentPurchaseAnalysis/SavingsPlansPurchaseAnalysisConfiguration_AccountScope")
        }
        {
            $v = "LINKED","PAYER"
            break
        }

        # Amazon.CostExplorer.AnalysisStatus
        "Get-CECommitmentPurchaseAnalysisList/AnalysisStatus"
        {
            $v = "FAILED","PROCESSING","SUCCEEDED"
            break
        }

        # Amazon.CostExplorer.AnalysisType
        "Start-CECommitmentPurchaseAnalysis/SavingsPlansPurchaseAnalysisConfiguration_AnalysisType"
        {
            $v = "CUSTOM_COMMITMENT","MAX_SAVINGS"
            break
        }

        # Amazon.CostExplorer.AnomalyFeedbackType
        {
            ($_ -eq "Get-CEAnomaly/Feedback") -Or
            ($_ -eq "Set-CEAnomalyFeedback/Feedback")
        }
        {
            $v = "NO","PLANNED_ACTIVITY","YES"
            break
        }

        # Amazon.CostExplorer.AnomalySubscriptionFrequency
        {
            ($_ -eq "New-CEAnomalySubscription/AnomalySubscription_Frequency") -Or
            ($_ -eq "Update-CEAnomalySubscription/Frequency")
        }
        {
            $v = "DAILY","IMMEDIATE","WEEKLY"
            break
        }

        # Amazon.CostExplorer.ApproximationDimension
        "Get-CEApproximateUsageRecord/ApproximationDimension"
        {
            $v = "RESOURCE","SERVICE"
            break
        }

        # Amazon.CostExplorer.Context
        "Get-CEDimensionValue/Context"
        {
            $v = "COST_AND_USAGE","RESERVATIONS","SAVINGS_PLANS"
            break
        }

        # Amazon.CostExplorer.CostAllocationTagStatus
        "Get-CECostAllocationTagList/Status"
        {
            $v = "Active","Inactive"
            break
        }

        # Amazon.CostExplorer.CostAllocationTagType
        "Get-CECostAllocationTagList/Type"
        {
            $v = "AWSGenerated","UserDefined"
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
            $v = "AGREEMENT_END_DATE_TIME_AFTER","AGREEMENT_END_DATE_TIME_BEFORE","ANOMALY_TOTAL_IMPACT_ABSOLUTE","ANOMALY_TOTAL_IMPACT_PERCENTAGE","AZ","BILLING_ENTITY","CACHE_ENGINE","DATABASE_ENGINE","DEPLOYMENT_OPTION","INSTANCE_TYPE","INSTANCE_TYPE_FAMILY","INVOICING_ENTITY","LEGAL_ENTITY_NAME","LINKED_ACCOUNT","LINKED_ACCOUNT_NAME","OPERATING_SYSTEM","OPERATION","PAYER_ACCOUNT","PAYMENT_OPTION","PLATFORM","PURCHASE_TYPE","RECORD_TYPE","REGION","RESERVATION_ID","RESOURCE_ID","RIGHTSIZING_TYPE","SAVINGS_PLANS_TYPE","SAVINGS_PLAN_ARN","SCOPE","SERVICE","SERVICE_CODE","SUBSCRIPTION_ID","TENANCY","USAGE_TYPE","USAGE_TYPE_GROUP"
            break
        }

        # Amazon.CostExplorer.GenerationStatus
        "Get-CESavingsPlansPurchaseRecommendationGenerationList/GenerationStatus"
        {
            $v = "FAILED","PROCESSING","SUCCEEDED"
            break
        }

        # Amazon.CostExplorer.Granularity
        {
            ($_ -eq "Get-CEApproximateUsageRecord/Granularity") -Or
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
            ($_ -eq "Get-CEReservationPurchaseRecommendation/LookbackPeriodInDay") -Or
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/LookbackPeriodInDay")
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

        # Amazon.CostExplorer.MonitorDimension
        "New-CEAnomalyMonitor/AnomalyMonitor_MonitorDimension"
        {
            $v = "COST_CATEGORY","LINKED_ACCOUNT","SERVICE","TAG"
            break
        }

        # Amazon.CostExplorer.MonitorType
        "New-CEAnomalyMonitor/AnomalyMonitor_MonitorType"
        {
            $v = "CUSTOM","DIMENSIONAL"
            break
        }

        # Amazon.CostExplorer.NumericOperator
        "Get-CEAnomaly/TotalImpact_NumericOperator"
        {
            $v = "BETWEEN","EQUAL","GREATER_THAN","GREATER_THAN_OR_EQUAL","LESS_THAN","LESS_THAN_OR_EQUAL"
            break
        }

        # Amazon.CostExplorer.OfferingClass
        "Get-CEReservationPurchaseRecommendation/EC2Specification_OfferingClass"
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

        # Amazon.CostExplorer.SortOrder
        {
            ($_ -eq "Get-CEReservationCoverage/SortBy_SortOrder") -Or
            ($_ -eq "Get-CEReservationUtilization/SortBy_SortOrder") -Or
            ($_ -eq "Get-CESavingsPlansCoverage/SortBy_SortOrder") -Or
            ($_ -eq "Get-CESavingsPlansUtilization/SortBy_SortOrder") -Or
            ($_ -eq "Get-CESavingsPlansUtilizationDetail/SortBy_SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.CostExplorer.SupportedSavingsPlansType
        "Get-CESavingsPlansPurchaseRecommendation/SavingsPlansType"
        {
            $v = "COMPUTE_SP","DATABASE_SP","EC2_INSTANCE_SP","SAGEMAKER_SP"
            break
        }

        # Amazon.CostExplorer.TermInYears
        {
            ($_ -eq "Get-CEReservationPurchaseRecommendation/TermInYear") -Or
            ($_ -eq "Get-CESavingsPlansPurchaseRecommendation/TermInYear")
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
    "AnalysisStatus"=@("Get-CECommitmentPurchaseAnalysisList")
    "AnomalyMonitor_MonitorDimension"=@("New-CEAnomalyMonitor")
    "AnomalyMonitor_MonitorType"=@("New-CEAnomalyMonitor")
    "AnomalySubscription_Frequency"=@("New-CEAnomalySubscription")
    "ApproximationDimension"=@("Get-CEApproximateUsageRecord")
    "Configuration_RecommendationTarget"=@("Get-CERightsizingRecommendation")
    "Context"=@("Get-CEDimensionValue")
    "Dimension"=@("Get-CEDimensionValue")
    "EC2Specification_OfferingClass"=@("Get-CEReservationPurchaseRecommendation")
    "Feedback"=@("Get-CEAnomaly","Set-CEAnomalyFeedback")
    "Frequency"=@("Update-CEAnomalySubscription")
    "GenerationStatus"=@("Get-CESavingsPlansPurchaseRecommendationGenerationList")
    "Granularity"=@("Get-CEApproximateUsageRecord","Get-CECostAndUsage","Get-CECostAndUsageWithResource","Get-CECostForecast","Get-CEReservationCoverage","Get-CEReservationUtilization","Get-CESavingsPlansCoverage","Get-CESavingsPlansUtilization","Get-CEUsageForecast")
    "LookbackPeriodInDay"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
    "Metric"=@("Get-CECostForecast","Get-CEUsageForecast")
    "PaymentOption"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
    "RuleVersion"=@("New-CECostCategoryDefinition","Update-CECostCategoryDefinition")
    "SavingsPlansPurchaseAnalysisConfiguration_AccountScope"=@("Start-CECommitmentPurchaseAnalysis")
    "SavingsPlansPurchaseAnalysisConfiguration_AnalysisType"=@("Start-CECommitmentPurchaseAnalysis")
    "SavingsPlansType"=@("Get-CESavingsPlansPurchaseRecommendation")
    "SortBy_SortOrder"=@("Get-CEReservationCoverage","Get-CEReservationUtilization","Get-CESavingsPlansCoverage","Get-CESavingsPlansUtilization","Get-CESavingsPlansUtilizationDetail")
    "Status"=@("Get-CECostAllocationTagList")
    "TermInYear"=@("Get-CEReservationPurchaseRecommendation","Get-CESavingsPlansPurchaseRecommendation")
    "TotalImpact_NumericOperator"=@("Get-CEAnomaly")
    "Type"=@("Get-CECostAllocationTagList")
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
    "Select"=@("New-CEAnomalyMonitor",
               "New-CEAnomalySubscription",
               "New-CECostCategoryDefinition",
               "Remove-CEAnomalyMonitor",
               "Remove-CEAnomalySubscription",
               "Remove-CECostCategoryDefinition",
               "Get-CECostCategoryDefinition",
               "Get-CEAnomaly",
               "Get-CEAnomalyMonitor",
               "Get-CEAnomalySubscription",
               "Get-CEApproximateUsageRecord",
               "Get-CECommitmentPurchaseAnalysis",
               "Get-CECostAndUsage",
               "Get-CECostAndUsageComparison",
               "Get-CECostAndUsageWithResource",
               "Get-CECostCategory",
               "Get-CECostComparisonDriver",
               "Get-CECostForecast",
               "Get-CEDimensionValue",
               "Get-CEReservationCoverage",
               "Get-CEReservationPurchaseRecommendation",
               "Get-CEReservationUtilization",
               "Get-CERightsizingRecommendation",
               "Get-CESavingsPlanPurchaseRecommendationDetail",
               "Get-CESavingsPlansCoverage",
               "Get-CESavingsPlansPurchaseRecommendation",
               "Get-CESavingsPlansUtilization",
               "Get-CESavingsPlansUtilizationDetail",
               "Get-CETag",
               "Get-CEUsageForecast",
               "Get-CECommitmentPurchaseAnalysisList",
               "Get-CECostAllocationTagBackfillHistoryList",
               "Get-CECostAllocationTagList",
               "Get-CECostCategoryDefinitionList",
               "Get-CECostCategoryResourceAssociationList",
               "Get-CESavingsPlansPurchaseRecommendationGenerationList",
               "Get-CEResourceTag",
               "Set-CEAnomalyFeedback",
               "Start-CECommitmentPurchaseAnalysis",
               "Start-CECostAllocationTagBackfill",
               "Start-CESavingsPlansPurchaseRecommendationGeneration",
               "Add-CEResourceTag",
               "Remove-CEResourceTag",
               "Update-CEAnomalyMonitor",
               "Update-CEAnomalySubscription",
               "Update-CECostAllocationTagsStatus",
               "Update-CECostCategoryDefinition")
}

_awsArgumentCompleterRegistration $CE_SelectCompleters $CE_SelectMap

