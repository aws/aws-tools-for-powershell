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

# Argument completions for service AWS Invoicing


$INV_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Invoicing.BuyerDomain
        {
            ($_ -eq "New-INVProcurementPortalPreference/BuyerDomain") -Or
            ($_ -eq "New-INVProcurementPortalPreference/TestEnvPreference_BuyerDomain") -Or
            ($_ -eq "Write-INVProcurementPortalPreference/TestEnvPreference_BuyerDomain")
        }
        {
            $v = "NetworkID"
            break
        }

        # Amazon.Invoicing.ConnectionTestingMethod
        {
            ($_ -eq "New-INVProcurementPortalPreference/EinvoiceDeliveryPreference_ConnectionTestingMethod") -Or
            ($_ -eq "Write-INVProcurementPortalPreference/EinvoiceDeliveryPreference_ConnectionTestingMethod")
        }
        {
            $v = "PROD_ENV_DOLLAR_TEST","TEST_ENV_REPLAY_TEST"
            break
        }

        # Amazon.Invoicing.ListInvoiceSummariesResourceType
        "Get-INVInvoiceSummaryList/Selector_ResourceType"
        {
            $v = "ACCOUNT_ID","INVOICE_ID"
            break
        }

        # Amazon.Invoicing.ProcurementPortalName
        "New-INVProcurementPortalPreference/ProcurementPortalName"
        {
            $v = "COUPA","SAP_BUSINESS_NETWORK"
            break
        }

        # Amazon.Invoicing.ProcurementPortalPreferenceStatus
        {
            ($_ -eq "Update-INVProcurementPortalPreferenceStatus/EinvoiceDeliveryPreferenceStatus") -Or
            ($_ -eq "Update-INVProcurementPortalPreferenceStatus/PurchaseOrderRetrievalPreferenceStatus")
        }
        {
            $v = "ACTIVE","PENDING_VERIFICATION","SUSPENDED","TEST_FAILED","TEST_INITIALIZATION_FAILED","TEST_INITIALIZED"
            break
        }

        # Amazon.Invoicing.Protocol
        {
            ($_ -eq "New-INVProcurementPortalPreference/EinvoiceDeliveryPreference_Protocol") -Or
            ($_ -eq "Write-INVProcurementPortalPreference/EinvoiceDeliveryPreference_Protocol")
        }
        {
            $v = "CXML"
            break
        }

        # Amazon.Invoicing.SupplierDomain
        {
            ($_ -eq "New-INVProcurementPortalPreference/SupplierDomain") -Or
            ($_ -eq "New-INVProcurementPortalPreference/TestEnvPreference_SupplierDomain") -Or
            ($_ -eq "Write-INVProcurementPortalPreference/TestEnvPreference_SupplierDomain")
        }
        {
            $v = "NetworkID"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$INV_map = @{
    "BuyerDomain"=@("New-INVProcurementPortalPreference")
    "EinvoiceDeliveryPreference_ConnectionTestingMethod"=@("New-INVProcurementPortalPreference","Write-INVProcurementPortalPreference")
    "EinvoiceDeliveryPreference_Protocol"=@("New-INVProcurementPortalPreference","Write-INVProcurementPortalPreference")
    "EinvoiceDeliveryPreferenceStatus"=@("Update-INVProcurementPortalPreferenceStatus")
    "ProcurementPortalName"=@("New-INVProcurementPortalPreference")
    "PurchaseOrderRetrievalPreferenceStatus"=@("Update-INVProcurementPortalPreferenceStatus")
    "Selector_ResourceType"=@("Get-INVInvoiceSummaryList")
    "SupplierDomain"=@("New-INVProcurementPortalPreference")
    "TestEnvPreference_BuyerDomain"=@("New-INVProcurementPortalPreference","Write-INVProcurementPortalPreference")
    "TestEnvPreference_SupplierDomain"=@("New-INVProcurementPortalPreference","Write-INVProcurementPortalPreference")
}

_awsArgumentCompleterRegistration $INV_Completers $INV_map

$INV_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.INV.$($commandName.Replace('-', ''))Cmdlet]"
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

$INV_SelectMap = @{
    "Select"=@("Get-INVBatchInvoiceProfile",
               "New-INVInvoiceUnit",
               "New-INVProcurementPortalPreference",
               "Remove-INVInvoiceUnit",
               "Remove-INVProcurementPortalPreference",
               "Get-INVInvoicePDF",
               "Get-INVInvoiceUnit",
               "Get-INVProcurementPortalPreference",
               "Get-INVInvoiceSummaryList",
               "Get-INVInvoiceUnitList",
               "Get-INVProcurementPortalPreferenceList",
               "Get-INVResourceTag",
               "Write-INVProcurementPortalPreference",
               "Add-INVResourceTag",
               "Remove-INVResourceTag",
               "Update-INVInvoiceUnit",
               "Update-INVProcurementPortalPreferenceStatus")
}

_awsArgumentCompleterRegistration $INV_SelectCompleters $INV_SelectMap

