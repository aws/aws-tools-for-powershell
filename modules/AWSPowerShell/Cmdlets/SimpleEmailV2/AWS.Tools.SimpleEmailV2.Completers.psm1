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

# Argument completions for service Amazon Simple Email Service V2 (SES V2)


$SES2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SimpleEmailV2.BehaviorOnMxFailure
        "Write-SES2EmailIdentityMailFromAttribute/BehaviorOnMxFailure"
        {
            $v = "REJECT_MESSAGE","USE_DEFAULT_VALUE"
            break
        }

        # Amazon.SimpleEmailV2.ContactLanguage
        "Write-SES2AccountDetail/ContactLanguage"
        {
            $v = "EN","JA"
            break
        }

        # Amazon.SimpleEmailV2.ContactListImportAction
        "New-SES2ImportJob/ContactListDestination_ContactListImportAction"
        {
            $v = "DELETE","PUT"
            break
        }

        # Amazon.SimpleEmailV2.DataFormat
        {
            ($_ -eq "New-SES2ExportJob/ExportDestination_DataFormat") -Or
            ($_ -eq "New-SES2ImportJob/ImportDataSource_DataFormat")
        }
        {
            $v = "CSV","JSON"
            break
        }

        # Amazon.SimpleEmailV2.DkimSigningAttributesOrigin
        "Write-SES2EmailIdentityDkimSigningAttribute/SigningAttributesOrigin"
        {
            $v = "AWS_SES","EXTERNAL"
            break
        }

        # Amazon.SimpleEmailV2.DkimSigningKeyLength
        {
            ($_ -eq "New-SES2EmailIdentity/DkimSigningAttributes_NextSigningKeyLength") -Or
            ($_ -eq "Write-SES2EmailIdentityDkimSigningAttribute/SigningAttributes_NextSigningKeyLength")
        }
        {
            $v = "RSA_1024_BIT","RSA_2048_BIT"
            break
        }

        # Amazon.SimpleEmailV2.ExportSourceType
        "Get-SES2ExportJobList/ExportSourceType"
        {
            $v = "MESSAGE_INSIGHTS","METRICS_DATA"
            break
        }

        # Amazon.SimpleEmailV2.FeatureStatus
        {
            ($_ -eq "Write-SES2AccountVdmAttribute/DashboardAttributes_EngagementMetric") -Or
            ($_ -eq "New-SES2ConfigurationSet/DashboardOptions_EngagementMetric") -Or
            ($_ -eq "Write-SES2ConfigurationSetVdmOption/DashboardOptions_EngagementMetric") -Or
            ($_ -eq "Write-SES2AccountVdmAttribute/GuardianAttributes_OptimizedSharedDelivery") -Or
            ($_ -eq "New-SES2ConfigurationSet/GuardianOptions_OptimizedSharedDelivery") -Or
            ($_ -eq "Write-SES2ConfigurationSetVdmOption/GuardianOptions_OptimizedSharedDelivery") -Or
            ($_ -eq "Write-SES2AccountVdmAttribute/VdmAttributes_VdmEnabled")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SimpleEmailV2.ImportDestinationType
        "Get-SES2ImportJobList/ImportDestinationType"
        {
            $v = "CONTACT_LIST","SUPPRESSION_LIST"
            break
        }

        # Amazon.SimpleEmailV2.JobStatus
        "Get-SES2ExportJobList/JobStatus"
        {
            $v = "CANCELLED","COMPLETED","CREATED","FAILED","PROCESSING"
            break
        }

        # Amazon.SimpleEmailV2.MailType
        "Write-SES2AccountDetail/MailType"
        {
            $v = "MARKETING","TRANSACTIONAL"
            break
        }

        # Amazon.SimpleEmailV2.MetricNamespace
        "New-SES2ExportJob/MetricsDataSource_Namespace"
        {
            $v = "VDM"
            break
        }

        # Amazon.SimpleEmailV2.ScalingMode
        {
            ($_ -eq "New-SES2DedicatedIpPool/ScalingMode") -Or
            ($_ -eq "Write-SES2DedicatedIpPoolScalingAttribute/ScalingMode")
        }
        {
            $v = "MANAGED","STANDARD"
            break
        }

        # Amazon.SimpleEmailV2.SubscriptionStatus
        "Get-SES2ContactCollection/Filter_FilteredStatus"
        {
            $v = "OPT_IN","OPT_OUT"
            break
        }

        # Amazon.SimpleEmailV2.SuppressionListImportAction
        "New-SES2ImportJob/SuppressionListDestination_SuppressionListImportAction"
        {
            $v = "DELETE","PUT"
            break
        }

        # Amazon.SimpleEmailV2.SuppressionListReason
        "Write-SES2SuppressedDestination/Reason"
        {
            $v = "BOUNCE","COMPLAINT"
            break
        }

        # Amazon.SimpleEmailV2.TlsPolicy
        {
            ($_ -eq "New-SES2ConfigurationSet/DeliveryOptions_TlsPolicy") -Or
            ($_ -eq "Write-SES2ConfigurationSetDeliveryOption/TlsPolicy")
        }
        {
            $v = "OPTIONAL","REQUIRE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SES2_map = @{
    "BehaviorOnMxFailure"=@("Write-SES2EmailIdentityMailFromAttribute")
    "ContactLanguage"=@("Write-SES2AccountDetail")
    "ContactListDestination_ContactListImportAction"=@("New-SES2ImportJob")
    "DashboardAttributes_EngagementMetric"=@("Write-SES2AccountVdmAttribute")
    "DashboardOptions_EngagementMetric"=@("New-SES2ConfigurationSet","Write-SES2ConfigurationSetVdmOption")
    "DeliveryOptions_TlsPolicy"=@("New-SES2ConfigurationSet")
    "DkimSigningAttributes_NextSigningKeyLength"=@("New-SES2EmailIdentity")
    "ExportDestination_DataFormat"=@("New-SES2ExportJob")
    "ExportSourceType"=@("Get-SES2ExportJobList")
    "Filter_FilteredStatus"=@("Get-SES2ContactCollection")
    "GuardianAttributes_OptimizedSharedDelivery"=@("Write-SES2AccountVdmAttribute")
    "GuardianOptions_OptimizedSharedDelivery"=@("New-SES2ConfigurationSet","Write-SES2ConfigurationSetVdmOption")
    "ImportDataSource_DataFormat"=@("New-SES2ImportJob")
    "ImportDestinationType"=@("Get-SES2ImportJobList")
    "JobStatus"=@("Get-SES2ExportJobList")
    "MailType"=@("Write-SES2AccountDetail")
    "MetricsDataSource_Namespace"=@("New-SES2ExportJob")
    "Reason"=@("Write-SES2SuppressedDestination")
    "ScalingMode"=@("New-SES2DedicatedIpPool","Write-SES2DedicatedIpPoolScalingAttribute")
    "SigningAttributes_NextSigningKeyLength"=@("Write-SES2EmailIdentityDkimSigningAttribute")
    "SigningAttributesOrigin"=@("Write-SES2EmailIdentityDkimSigningAttribute")
    "SuppressionListDestination_SuppressionListImportAction"=@("New-SES2ImportJob")
    "TlsPolicy"=@("Write-SES2ConfigurationSetDeliveryOption")
    "VdmAttributes_VdmEnabled"=@("Write-SES2AccountVdmAttribute")
}

_awsArgumentCompleterRegistration $SES2_Completers $SES2_map

$SES2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SES2.$($commandName.Replace('-', ''))Cmdlet]"
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

$SES2_SelectMap = @{
    "Select"=@("Get-SES2BatchMetricData",
               "Stop-SES2ExportJob",
               "New-SES2ConfigurationSet",
               "New-SES2ConfigurationSetEventDestination",
               "New-SES2Contact",
               "New-SES2ContactList",
               "New-SES2CustomVerificationEmailTemplate",
               "New-SES2DedicatedIpPool",
               "New-SES2DeliverabilityTestReport",
               "New-SES2EmailIdentity",
               "New-SES2EmailIdentityPolicy",
               "New-SES2EmailTemplate",
               "New-SES2ExportJob",
               "New-SES2ImportJob",
               "Remove-SES2ConfigurationSet",
               "Remove-SES2ConfigurationSetEventDestination",
               "Remove-SES2Contact",
               "Remove-SES2ContactList",
               "Remove-SES2CustomVerificationEmailTemplate",
               "Remove-SES2DedicatedIpPool",
               "Remove-SES2EmailIdentity",
               "Remove-SES2EmailIdentityPolicy",
               "Remove-SES2EmailTemplate",
               "Remove-SES2SuppressedDestination",
               "Get-SES2Account",
               "Get-SES2BlacklistReport",
               "Get-SES2ConfigurationSet",
               "Get-SES2ConfigurationSetEventDestination",
               "Get-SES2Contact",
               "Get-SES2ContactList",
               "Get-SES2CustomVerificationEmailTemplate",
               "Get-SES2DedicatedIp",
               "Get-SES2DedicatedIpPool",
               "Get-SES2DedicatedIpList",
               "Get-SES2DeliverabilityDashboardOption",
               "Get-SES2DeliverabilityTestReport",
               "Get-SES2DomainDeliverabilityCampaign",
               "Get-SES2DomainStatisticsReport",
               "Get-SES2EmailIdentity",
               "Get-SES2EmailIdentityPolicy",
               "Get-SES2EmailTemplate",
               "Get-SES2ExportJob",
               "Get-SES2ImportJob",
               "Get-SES2MessageInsight",
               "Get-SES2SuppressedDestination",
               "Get-SES2ConfigurationSetList",
               "Get-SES2ContactListCollection",
               "Get-SES2ContactCollection",
               "Get-SES2CustomVerificationEmailTemplateList",
               "Get-SES2DedicatedIpPoolList",
               "Get-SES2DeliverabilityTestReportList",
               "Get-SES2DomainDeliverabilityCampaignList",
               "Get-SES2EmailIdentityList",
               "Get-SES2EmailTemplateList",
               "Get-SES2ExportJobList",
               "Get-SES2ImportJobList",
               "Get-SES2RecommendationList",
               "Get-SES2SuppressedDestinationList",
               "Get-SES2ResourceTag",
               "Write-SES2AccountDedicatedIpWarmupAttribute",
               "Write-SES2AccountDetail",
               "Write-SES2AccountSendingAttribute",
               "Write-SES2AccountSuppressionAttribute",
               "Write-SES2AccountVdmAttribute",
               "Write-SES2ConfigurationSetDeliveryOption",
               "Write-SES2ConfigurationSetReputationOption",
               "Write-SES2ConfigurationSetSendingOption",
               "Write-SES2ConfigurationSetSuppressionOption",
               "Write-SES2ConfigurationSetTrackingOption",
               "Write-SES2ConfigurationSetVdmOption",
               "Write-SES2DedicatedIpInPool",
               "Write-SES2DedicatedIpPoolScalingAttribute",
               "Write-SES2DedicatedIpWarmupAttribute",
               "Write-SES2DeliverabilityDashboardOption",
               "Write-SES2EmailIdentityConfigurationSetAttribute",
               "Write-SES2EmailIdentityDkimAttribute",
               "Write-SES2EmailIdentityDkimSigningAttribute",
               "Write-SES2EmailIdentityFeedbackAttribute",
               "Write-SES2EmailIdentityMailFromAttribute",
               "Write-SES2SuppressedDestination",
               "Send-SES2BulkEmail",
               "Send-SES2CustomVerificationEmail",
               "Send-SES2Email",
               "Add-SES2ResourceTag",
               "Test-SES2RenderEmailTemplate",
               "Remove-SES2ResourceTag",
               "Update-SES2ConfigurationSetEventDestination",
               "Update-SES2Contact",
               "Update-SES2ContactList",
               "Update-SES2CustomVerificationEmailTemplate",
               "Update-SES2EmailIdentityPolicy",
               "Update-SES2EmailTemplate")
}

_awsArgumentCompleterRegistration $SES2_SelectCompleters $SES2_SelectMap

