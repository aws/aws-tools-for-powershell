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

# Argument completions for service AWS Outposts


$OUTP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Outposts.AddressType
        {
            ($_ -eq "Get-OUTPSiteAddress/AddressType") -Or
            ($_ -eq "Update-OUTPSiteAddress/AddressType")
        }
        {
            $v = "OPERATING_ADDRESS","SHIPPING_ADDRESS"
            break
        }

        # Amazon.Outposts.FiberOpticCableType
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/FiberOpticCableType") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_FiberOpticCableType")
        }
        {
            $v = "MULTI_MODE","SINGLE_MODE"
            break
        }

        # Amazon.Outposts.MaximumSupportedWeightLbs
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/MaximumSupportedWeightLbs") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_MaximumSupportedWeightLbs")
        }
        {
            $v = "MAX_1400_LBS","MAX_1600_LBS","MAX_1800_LBS","MAX_2000_LBS","NO_LIMIT"
            break
        }

        # Amazon.Outposts.OpticalStandard
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/OpticalStandard") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_OpticalStandard")
        }
        {
            $v = "OPTIC_1000BASE_LX","OPTIC_1000BASE_SX","OPTIC_100GBASE_CWDM4","OPTIC_100GBASE_LR4","OPTIC_100GBASE_SR4","OPTIC_100G_PSM4_MSA","OPTIC_10GBASE_IR","OPTIC_10GBASE_LR","OPTIC_10GBASE_SR","OPTIC_40GBASE_ESR","OPTIC_40GBASE_IR4_LR4L","OPTIC_40GBASE_LR4","OPTIC_40GBASE_SR"
            break
        }

        # Amazon.Outposts.PaymentOption
        "New-OUTPOrder/PaymentOption"
        {
            $v = "ALL_UPFRONT","NO_UPFRONT","PARTIAL_UPFRONT"
            break
        }

        # Amazon.Outposts.PaymentTerm
        "New-OUTPOrder/PaymentTerm"
        {
            $v = "ONE_YEAR","THREE_YEARS"
            break
        }

        # Amazon.Outposts.PowerConnector
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/PowerConnector") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_PowerConnector")
        }
        {
            $v = "AH530P7W","AH532P6W","IEC309","L6_30P"
            break
        }

        # Amazon.Outposts.PowerDrawKva
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/PowerDrawKva") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_PowerDrawKva")
        }
        {
            $v = "POWER_10_KVA","POWER_15_KVA","POWER_5_KVA"
            break
        }

        # Amazon.Outposts.PowerFeedDrop
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/PowerFeedDrop") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_PowerFeedDrop")
        }
        {
            $v = "ABOVE_RACK","BELOW_RACK"
            break
        }

        # Amazon.Outposts.PowerPhase
        {
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/PowerPhase") -Or
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_PowerPhase")
        }
        {
            $v = "SINGLE_PHASE","THREE_PHASE"
            break
        }

        # Amazon.Outposts.SupportedHardwareType
        {
            ($_ -eq "New-OUTPOutpost/SupportedHardwareType") -Or
            ($_ -eq "Update-OUTPOutpost/SupportedHardwareType")
        }
        {
            $v = "RACK","SERVER"
            break
        }

        # Amazon.Outposts.UplinkCount
        {
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_UplinkCount") -Or
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/UplinkCount")
        }
        {
            $v = "UPLINK_COUNT_1","UPLINK_COUNT_12","UPLINK_COUNT_16","UPLINK_COUNT_2","UPLINK_COUNT_3","UPLINK_COUNT_4","UPLINK_COUNT_5","UPLINK_COUNT_6","UPLINK_COUNT_7","UPLINK_COUNT_8"
            break
        }

        # Amazon.Outposts.UplinkGbps
        {
            ($_ -eq "New-OUTPSite/RackPhysicalProperties_UplinkGbps") -Or
            ($_ -eq "Update-OUTPSiteRackPhysicalProperty/UplinkGbps")
        }
        {
            $v = "UPLINK_100G","UPLINK_10G","UPLINK_1G","UPLINK_40G"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$OUTP_map = @{
    "AddressType"=@("Get-OUTPSiteAddress","Update-OUTPSiteAddress")
    "FiberOpticCableType"=@("Update-OUTPSiteRackPhysicalProperty")
    "MaximumSupportedWeightLbs"=@("Update-OUTPSiteRackPhysicalProperty")
    "OpticalStandard"=@("Update-OUTPSiteRackPhysicalProperty")
    "PaymentOption"=@("New-OUTPOrder")
    "PaymentTerm"=@("New-OUTPOrder")
    "PowerConnector"=@("Update-OUTPSiteRackPhysicalProperty")
    "PowerDrawKva"=@("Update-OUTPSiteRackPhysicalProperty")
    "PowerFeedDrop"=@("Update-OUTPSiteRackPhysicalProperty")
    "PowerPhase"=@("Update-OUTPSiteRackPhysicalProperty")
    "RackPhysicalProperties_FiberOpticCableType"=@("New-OUTPSite")
    "RackPhysicalProperties_MaximumSupportedWeightLbs"=@("New-OUTPSite")
    "RackPhysicalProperties_OpticalStandard"=@("New-OUTPSite")
    "RackPhysicalProperties_PowerConnector"=@("New-OUTPSite")
    "RackPhysicalProperties_PowerDrawKva"=@("New-OUTPSite")
    "RackPhysicalProperties_PowerFeedDrop"=@("New-OUTPSite")
    "RackPhysicalProperties_PowerPhase"=@("New-OUTPSite")
    "RackPhysicalProperties_UplinkCount"=@("New-OUTPSite")
    "RackPhysicalProperties_UplinkGbps"=@("New-OUTPSite")
    "SupportedHardwareType"=@("New-OUTPOutpost","Update-OUTPOutpost")
    "UplinkCount"=@("Update-OUTPSiteRackPhysicalProperty")
    "UplinkGbps"=@("Update-OUTPSiteRackPhysicalProperty")
}

_awsArgumentCompleterRegistration $OUTP_Completers $OUTP_map

$OUTP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.OUTP.$($commandName.Replace('-', ''))Cmdlet]"
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

$OUTP_SelectMap = @{
    "Select"=@("Stop-OUTPOrder",
               "New-OUTPOrder",
               "New-OUTPOutpost",
               "New-OUTPSite",
               "Remove-OUTPOutpost",
               "Remove-OUTPSite",
               "Get-OUTPCatalogItem",
               "Get-OUTPConnection",
               "Get-OUTPOrder",
               "Get-OUTPOutpost",
               "Get-OUTPOutpostInstanceType",
               "Get-OUTPSite",
               "Get-OUTPSiteAddress",
               "Get-OUTPAssetList",
               "Get-OUTPCatalogItemList",
               "Get-OUTPOrderList",
               "Get-OUTPOutpostList",
               "Get-OUTPSiteList",
               "Get-OUTPResourceTag",
               "Start-OUTPConnection",
               "Add-OUTPResourceTag",
               "Remove-OUTPResourceTag",
               "Update-OUTPOutpost",
               "Update-OUTPSite",
               "Update-OUTPSiteAddress",
               "Update-OUTPSiteRackPhysicalProperty")
}

_awsArgumentCompleterRegistration $OUTP_SelectCompleters $OUTP_SelectMap

