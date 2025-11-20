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

# Argument completions for service AWS License Manager


$LICM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LicenseManager.ActivationOverrideBehavior
        "New-LICMGrantVersion/Options_ActivationOverrideBehavior"
        {
            $v = "ALL_GRANTS_PERMITTED_BY_ISSUER","DISTRIBUTED_GRANTS_ONLY"
            break
        }

        # Amazon.LicenseManager.CheckoutType
        "Invoke-LICMLicenseCheckout/CheckoutType"
        {
            $v = "PERPETUAL","PROVISIONAL"
            break
        }

        # Amazon.LicenseManager.DigitalSignatureMethod
        "Invoke-LICMLicenseCheckoutBorrow/DigitalSignatureMethod"
        {
            $v = "JWT_PS384"
            break
        }

        # Amazon.LicenseManager.GrantStatus
        "New-LICMGrantVersion/Status"
        {
            $v = "ACTIVE","DELETED","DISABLED","FAILED_WORKFLOW","PENDING_ACCEPT","PENDING_DELETE","PENDING_WORKFLOW","REJECTED","WORKFLOW_COMPLETED"
            break
        }

        # Amazon.LicenseManager.LicenseAssetGroupStatus
        "Update-LICMLicenseAssetGroup/Status"
        {
            $v = "ACTIVE","DELETED","DISABLED"
            break
        }

        # Amazon.LicenseManager.LicenseConfigurationStatus
        "Update-LICMLicenseConfiguration/LicenseConfigurationStatus"
        {
            $v = "AVAILABLE","DISABLED"
            break
        }

        # Amazon.LicenseManager.LicenseCountingType
        "New-LICMLicenseConfiguration/LicenseCountingType"
        {
            $v = "Core","Instance","Socket","vCPU"
            break
        }

        # Amazon.LicenseManager.LicenseStatus
        "New-LICMLicenseVersion/Status"
        {
            $v = "AVAILABLE","DEACTIVATED","DELETED","EXPIRED","PENDING_AVAILABLE","PENDING_DELETE","SUSPENDED"
            break
        }

        # Amazon.LicenseManager.RenewType
        {
            ($_ -eq "New-LICMLicense/ConsumptionConfiguration_RenewType") -Or
            ($_ -eq "New-LICMLicenseVersion/ConsumptionConfiguration_RenewType")
        }
        {
            $v = "Monthly","None","Weekly"
            break
        }

        # Amazon.LicenseManager.ReportFrequencyType
        {
            ($_ -eq "New-LICMLicenseManagerReportGenerator/ReportFrequency_Period") -Or
            ($_ -eq "Update-LICMLicenseManagerReportGenerator/ReportFrequency_Period")
        }
        {
            $v = "DAY","MONTH","ONE_TIME","WEEK"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LICM_map = @{
    "CheckoutType"=@("Invoke-LICMLicenseCheckout")
    "ConsumptionConfiguration_RenewType"=@("New-LICMLicense","New-LICMLicenseVersion")
    "DigitalSignatureMethod"=@("Invoke-LICMLicenseCheckoutBorrow")
    "LicenseConfigurationStatus"=@("Update-LICMLicenseConfiguration")
    "LicenseCountingType"=@("New-LICMLicenseConfiguration")
    "Options_ActivationOverrideBehavior"=@("New-LICMGrantVersion")
    "ReportFrequency_Period"=@("New-LICMLicenseManagerReportGenerator","Update-LICMLicenseManagerReportGenerator")
    "Status"=@("New-LICMGrantVersion","New-LICMLicenseVersion","Update-LICMLicenseAssetGroup")
}

_awsArgumentCompleterRegistration $LICM_Completers $LICM_map

$LICM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LICM.$($commandName.Replace('-', ''))Cmdlet]"
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

$LICM_SelectMap = @{
    "Select"=@("Approve-LICMGrant",
               "Invoke-LICMLicenseCheckIn",
               "Invoke-LICMLicenseCheckoutBorrow",
               "Invoke-LICMLicenseCheckout",
               "New-LICMGrant",
               "New-LICMGrantVersion",
               "New-LICMLicense",
               "New-LICMLicenseAssetGroup",
               "New-LICMLicenseAssetRuleset",
               "New-LICMLicenseConfiguration",
               "New-LICMLicenseConversionTaskForResource",
               "New-LICMLicenseManagerReportGenerator",
               "New-LICMLicenseVersion",
               "New-LICMToken",
               "Remove-LICMGrant",
               "Remove-LICMLicense",
               "Remove-LICMLicenseAssetGroup",
               "Remove-LICMLicenseAssetRuleset",
               "Remove-LICMLicenseConfiguration",
               "Remove-LICMLicenseManagerReportGenerator",
               "Remove-LICMToken",
               "Invoke-LICMExtendLicenseConsumption",
               "Get-LICMAccessToken",
               "Get-LICMGrant",
               "Get-LICMLicense",
               "Get-LICMLicenseAssetGroup",
               "Get-LICMLicenseAssetRuleset",
               "Get-LICMLicenseConfiguration",
               "Get-LICMLicenseConversionTask",
               "Get-LICMLicenseManagerReportGenerator",
               "Get-LICMLicenseUsage",
               "Get-LICMServiceSetting",
               "Get-LICMAssetsForLicenseAssetGroupList",
               "Get-LICMAssociationsForLicenseConfigurationList",
               "Get-LICMDistributedGrantList",
               "Get-LICMFailuresForLicenseConfigurationOperationList",
               "Get-LICMLicenseAssetGroupList",
               "Get-LICMLicenseAssetRulesetList",
               "Get-LICMLicenseConfigurationList",
               "Get-LICMLicenseConfigurationsForOrganizationList",
               "Get-LICMLicenseConversionTaskList",
               "Get-LICMLicenseManagerReportGeneratorList",
               "Get-LICMLicenseList",
               "Get-LICMLicenseSpecificationsForResourceList",
               "Get-LICMLicenseVersionList",
               "Get-LICMReceivedGrantList",
               "Get-LICMReceivedGrantsForOrganizationList",
               "Get-LICMReceivedLicenseList",
               "Get-LICMReceivedLicensesForOrganizationList",
               "Get-LICMResourceInventoryList",
               "Get-LICMResourceTagList",
               "Get-LICMTokenList",
               "Get-LICMUsageForLicenseConfigurationList",
               "Deny-LICMGrant",
               "Add-LICMResourceTag",
               "Remove-LICMResourceTag",
               "Update-LICMLicenseAssetGroup",
               "Update-LICMLicenseAssetRuleset",
               "Update-LICMLicenseConfiguration",
               "Update-LICMLicenseManagerReportGenerator",
               "Update-LICMLicenseSpecificationsForResource",
               "Update-LICMServiceSetting")
}

_awsArgumentCompleterRegistration $LICM_SelectCompleters $LICM_SelectMap

