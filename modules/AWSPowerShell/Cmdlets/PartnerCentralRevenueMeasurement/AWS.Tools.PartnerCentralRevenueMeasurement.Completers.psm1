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

# Argument completions for service Partner Central Revenue Measurement API


$PCRM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PartnerCentralRevenueMeasurement.AllocationStatus
        {
            ($_ -eq "Get-PCRMMarketplaceRevenueShareAllocationList/Status") -Or
            ($_ -eq "Update-PCRMMarketplaceRevenueShareAllocation/Status") -Or
            ($_ -eq "Get-PCRMRevenueAttributionAllocationList/StatusFilter")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.AttributionSortBy
        "Get-PCRMRevenueAttributionList/SortBy"
        {
            $v = "LastModifiedDate"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.CatalogName
        {
            ($_ -eq "Get-PCRMMarketplaceRevenueShare/Catalog") -Or
            ($_ -eq "Get-PCRMMarketplaceRevenueShareAllocation/Catalog") -Or
            ($_ -eq "Get-PCRMMarketplaceRevenueShareAllocationList/Catalog") -Or
            ($_ -eq "Get-PCRMMarketplaceRevenueShareList/Catalog") -Or
            ($_ -eq "Get-PCRMRevenueAttribution/Catalog") -Or
            ($_ -eq "Get-PCRMRevenueAttributionAllocation/Catalog") -Or
            ($_ -eq "Get-PCRMRevenueAttributionAllocationList/Catalog") -Or
            ($_ -eq "Get-PCRMRevenueAttributionAllocationsTask/Catalog") -Or
            ($_ -eq "Get-PCRMRevenueAttributionList/Catalog") -Or
            ($_ -eq "New-PCRMMarketplaceRevenueShare/Catalog") -Or
            ($_ -eq "New-PCRMMarketplaceRevenueShareAllocation/Catalog") -Or
            ($_ -eq "New-PCRMRevenueAttribution/Catalog") -Or
            ($_ -eq "Start-PCRMRevenueAttributionAllocationsTask/Catalog") -Or
            ($_ -eq "Update-PCRMMarketplaceRevenueShareAllocation/Catalog") -Or
            ($_ -eq "Update-PCRMRevenueAttribution/Catalog")
        }
        {
            $v = "AWS","Sandbox"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.MarketplaceRevenueShareAllocationSortField
        "Get-PCRMMarketplaceRevenueShareAllocationList/SortBy"
        {
            $v = "EffectiveFrom"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.MarketplaceRevenueShareSortBy
        "Get-PCRMMarketplaceRevenueShareList/SortBy"
        {
            $v = "LastModifiedDate"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.RevenueAttributionAllocationSortField
        "Get-PCRMRevenueAttributionAllocationList/SortBy"
        {
            $v = "EffectiveFrom"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.SortOrder
        {
            ($_ -eq "Get-PCRMMarketplaceRevenueShareAllocationList/SortOrder") -Or
            ($_ -eq "Get-PCRMMarketplaceRevenueShareList/SortOrder") -Or
            ($_ -eq "Get-PCRMRevenueAttributionAllocationList/SortOrder") -Or
            ($_ -eq "Get-PCRMRevenueAttributionList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.PartnerCentralRevenueMeasurement.TenancyModel
        "New-PCRMRevenueAttribution/TenancyModel"
        {
            $v = "MULTI_TENANT","SINGLE_TENANT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PCRM_map = @{
    "Catalog"=@("Get-PCRMMarketplaceRevenueShare","Get-PCRMMarketplaceRevenueShareAllocation","Get-PCRMMarketplaceRevenueShareAllocationList","Get-PCRMMarketplaceRevenueShareList","Get-PCRMRevenueAttribution","Get-PCRMRevenueAttributionAllocation","Get-PCRMRevenueAttributionAllocationList","Get-PCRMRevenueAttributionAllocationsTask","Get-PCRMRevenueAttributionList","New-PCRMMarketplaceRevenueShare","New-PCRMMarketplaceRevenueShareAllocation","New-PCRMRevenueAttribution","Start-PCRMRevenueAttributionAllocationsTask","Update-PCRMMarketplaceRevenueShareAllocation","Update-PCRMRevenueAttribution")
    "SortBy"=@("Get-PCRMMarketplaceRevenueShareAllocationList","Get-PCRMMarketplaceRevenueShareList","Get-PCRMRevenueAttributionAllocationList","Get-PCRMRevenueAttributionList")
    "SortOrder"=@("Get-PCRMMarketplaceRevenueShareAllocationList","Get-PCRMMarketplaceRevenueShareList","Get-PCRMRevenueAttributionAllocationList","Get-PCRMRevenueAttributionList")
    "Status"=@("Get-PCRMMarketplaceRevenueShareAllocationList","Update-PCRMMarketplaceRevenueShareAllocation")
    "StatusFilter"=@("Get-PCRMRevenueAttributionAllocationList")
    "TenancyModel"=@("New-PCRMRevenueAttribution")
}

_awsArgumentCompleterRegistration $PCRM_Completers $PCRM_map

$PCRM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PCRM.$($commandName.Replace('-', ''))Cmdlet]"
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

$PCRM_SelectMap = @{
    "Select"=@("New-PCRMMarketplaceRevenueShare",
               "New-PCRMMarketplaceRevenueShareAllocation",
               "New-PCRMRevenueAttribution",
               "Get-PCRMMarketplaceRevenueShare",
               "Get-PCRMMarketplaceRevenueShareAllocation",
               "Get-PCRMRevenueAttribution",
               "Get-PCRMRevenueAttributionAllocation",
               "Get-PCRMRevenueAttributionAllocationsTask",
               "Get-PCRMMarketplaceRevenueShareAllocationList",
               "Get-PCRMMarketplaceRevenueShareList",
               "Get-PCRMRevenueAttributionAllocationList",
               "Get-PCRMRevenueAttributionList",
               "Get-PCRMResourceTag",
               "Start-PCRMRevenueAttributionAllocationsTask",
               "Add-PCRMResourceTag",
               "Remove-PCRMResourceTag",
               "Update-PCRMMarketplaceRevenueShareAllocation",
               "Update-PCRMRevenueAttribution")
}

_awsArgumentCompleterRegistration $PCRM_SelectCompleters $PCRM_SelectMap

