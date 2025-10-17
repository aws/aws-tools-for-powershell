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

# Argument completions for service AWS Marketplace Catalog Service


$MCAT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MarketplaceCatalog.AmiProductSortBy
        "Get-MCATEntityList/AmiProductSort_SortBy"
        {
            $v = "EntityId","LastModifiedDate","ProductTitle","Visibility"
            break
        }

        # Amazon.MarketplaceCatalog.ContainerProductSortBy
        "Get-MCATEntityList/ContainerProductSort_SortBy"
        {
            $v = "CompatibleAWSServices","EntityId","LastModifiedDate","ProductTitle","Visibility"
            break
        }

        # Amazon.MarketplaceCatalog.DataProductSortBy
        "Get-MCATEntityList/DataProductSort_SortBy"
        {
            $v = "EntityId","LastModifiedDate","ProductTitle","Visibility"
            break
        }

        # Amazon.MarketplaceCatalog.Intent
        "Start-MCATChangeSet/Intent"
        {
            $v = "APPLY","VALIDATE"
            break
        }

        # Amazon.MarketplaceCatalog.MachineLearningProductSortBy
        "Get-MCATEntityList/MachineLearningProductSort_SortBy"
        {
            $v = "EntityId","LastModifiedDate","ProductTitle","Visibility"
            break
        }

        # Amazon.MarketplaceCatalog.OfferSortBy
        "Get-MCATEntityList/OfferSort_SortBy"
        {
            $v = "AvailabilityEndDate","BuyerAccounts","EntityId","LastModifiedDate","Name","ProductId","ReleaseDate","ResaleAuthorizationId","State","Targeting"
            break
        }

        # Amazon.MarketplaceCatalog.OwnershipType
        "Get-MCATEntityList/OwnershipType"
        {
            $v = "SELF","SHARED"
            break
        }

        # Amazon.MarketplaceCatalog.ResaleAuthorizationSortBy
        "Get-MCATEntityList/ResaleAuthorizationSort_SortBy"
        {
            $v = "AvailabilityEndDate","CreatedDate","EntityId","LastModifiedDate","ManufacturerAccountId","ManufacturerLegalName","Name","OfferExtendedStatus","ProductId","ProductName","ResellerAccountID","ResellerLegalName","Status"
            break
        }

        # Amazon.MarketplaceCatalog.SaaSProductSortBy
        "Get-MCATEntityList/SaaSProductSort_SortBy"
        {
            $v = "DeliveryOptionTypes","EntityId","LastModifiedDate","ProductTitle","Visibility"
            break
        }

        # Amazon.MarketplaceCatalog.SortOrder
        {
            ($_ -eq "Get-MCATEntityList/AmiProductSort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/ContainerProductSort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/DataProductSort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/MachineLearningProductSort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/OfferSort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/ResaleAuthorizationSort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/SaaSProductSort_SortOrder") -Or
            ($_ -eq "Get-MCATChangeSetList/Sort_SortOrder") -Or
            ($_ -eq "Get-MCATEntityList/Sort_SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MCAT_map = @{
    "AmiProductSort_SortBy"=@("Get-MCATEntityList")
    "AmiProductSort_SortOrder"=@("Get-MCATEntityList")
    "ContainerProductSort_SortBy"=@("Get-MCATEntityList")
    "ContainerProductSort_SortOrder"=@("Get-MCATEntityList")
    "DataProductSort_SortBy"=@("Get-MCATEntityList")
    "DataProductSort_SortOrder"=@("Get-MCATEntityList")
    "Intent"=@("Start-MCATChangeSet")
    "MachineLearningProductSort_SortBy"=@("Get-MCATEntityList")
    "MachineLearningProductSort_SortOrder"=@("Get-MCATEntityList")
    "OfferSort_SortBy"=@("Get-MCATEntityList")
    "OfferSort_SortOrder"=@("Get-MCATEntityList")
    "OwnershipType"=@("Get-MCATEntityList")
    "ResaleAuthorizationSort_SortBy"=@("Get-MCATEntityList")
    "ResaleAuthorizationSort_SortOrder"=@("Get-MCATEntityList")
    "SaaSProductSort_SortBy"=@("Get-MCATEntityList")
    "SaaSProductSort_SortOrder"=@("Get-MCATEntityList")
    "Sort_SortOrder"=@("Get-MCATChangeSetList","Get-MCATEntityList")
}

_awsArgumentCompleterRegistration $MCAT_Completers $MCAT_map

$MCAT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MCAT.$($commandName.Replace('-', ''))Cmdlet]"
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

$MCAT_SelectMap = @{
    "Select"=@("Get-MCATBatchEntity",
               "Stop-MCATChangeSet",
               "Remove-MCATResourcePolicy",
               "Get-MCATChangeSet",
               "Get-MCATEntity",
               "Get-MCATResourcePolicy",
               "Get-MCATChangeSetList",
               "Get-MCATEntityList",
               "Get-MCATResourceTag",
               "Write-MCATResourcePolicy",
               "Start-MCATChangeSet",
               "Add-MCATResourceTag",
               "Remove-MCATResourceTag")
}

_awsArgumentCompleterRegistration $MCAT_SelectCompleters $MCAT_SelectMap

