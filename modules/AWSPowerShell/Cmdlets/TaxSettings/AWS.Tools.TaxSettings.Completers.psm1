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

# Argument completions for service AWS Tax Settings


$TSA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.TaxSettings.Industries
        {
            ($_ -eq "Write-TSATaxRegistration/TurkeyAdditionalInfo_Industry") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/TurkeyAdditionalInfo_Industry")
        }
        {
            $v = "Banks","CirculatingOrg","DevelopmentAgencies","Insurance","PensionAndBenefitFunds","ProfessionalOrg"
            break
        }

        # Amazon.TaxSettings.IsraelCustomerType
        {
            ($_ -eq "Write-TSATaxRegistration/IsraelAdditionalInfo_CustomerType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/IsraelAdditionalInfo_CustomerType")
        }
        {
            $v = "Business","Individual"
            break
        }

        # Amazon.TaxSettings.IsraelDealerType
        {
            ($_ -eq "Write-TSATaxRegistration/IsraelAdditionalInfo_DealerType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/IsraelAdditionalInfo_DealerType")
        }
        {
            $v = "Authorized","Non-authorized"
            break
        }

        # Amazon.TaxSettings.PersonType
        {
            ($_ -eq "Write-TSATaxRegistration/GeorgiaAdditionalInfo_PersonType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/GeorgiaAdditionalInfo_PersonType") -Or
            ($_ -eq "Write-TSATaxRegistration/KenyaAdditionalInfo_PersonType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/KenyaAdditionalInfo_PersonType")
        }
        {
            $v = "Business","Legal Person","Physical Person"
            break
        }

        # Amazon.TaxSettings.RegistrationType
        {
            ($_ -eq "Write-TSATaxRegistration/SpainAdditionalInfo_RegistrationType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/SpainAdditionalInfo_RegistrationType")
        }
        {
            $v = "Intra-EU","Local"
            break
        }

        # Amazon.TaxSettings.SaudiArabiaTaxRegistrationNumberType
        {
            ($_ -eq "Write-TSATaxRegistration/SaudiArabiaAdditionalInfo_TaxRegistrationNumberType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/SaudiArabiaAdditionalInfo_TaxRegistrationNumberType")
        }
        {
            $v = "CommercialRegistrationNumber","TaxIdentificationNumber","TaxRegistrationNumber"
            break
        }

        # Amazon.TaxSettings.Sector
        {
            ($_ -eq "Write-TSATaxRegistration/TaxRegistrationEntry_Sector") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/TaxRegistrationEntry_Sector")
        }
        {
            $v = "Business","Government","Individual"
            break
        }

        # Amazon.TaxSettings.SupplementalTaxRegistrationType
        "Write-TSASupplementalTaxRegistration/TaxRegistrationEntry_RegistrationType"
        {
            $v = "VAT"
            break
        }

        # Amazon.TaxSettings.TaxRegistrationNumberType
        {
            ($_ -eq "Write-TSATaxRegistration/RomaniaAdditionalInfo_TaxRegistrationNumberType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/RomaniaAdditionalInfo_TaxRegistrationNumberType")
        }
        {
            $v = "LocalRegistrationNumber","TaxRegistrationNumber"
            break
        }

        # Amazon.TaxSettings.TaxRegistrationType
        {
            ($_ -eq "Write-TSATaxRegistration/TaxRegistrationEntry_RegistrationType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/TaxRegistrationEntry_RegistrationType")
        }
        {
            $v = "CNPJ","CPF","GST","NRIC","SST","TIN","VAT"
            break
        }

        # Amazon.TaxSettings.UkraineTrnType
        {
            ($_ -eq "Write-TSATaxRegistration/UkraineAdditionalInfo_UkraineTrnType") -Or
            ($_ -eq "Write-TSATaxRegistrationBatch/UkraineAdditionalInfo_UkraineTrnType")
        }
        {
            $v = "Business","Individual"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TSA_map = @{
    "GeorgiaAdditionalInfo_PersonType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "IsraelAdditionalInfo_CustomerType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "IsraelAdditionalInfo_DealerType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "KenyaAdditionalInfo_PersonType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "RomaniaAdditionalInfo_TaxRegistrationNumberType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "SaudiArabiaAdditionalInfo_TaxRegistrationNumberType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "SpainAdditionalInfo_RegistrationType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "TaxRegistrationEntry_RegistrationType"=@("Write-TSASupplementalTaxRegistration","Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "TaxRegistrationEntry_Sector"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "TurkeyAdditionalInfo_Industry"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
    "UkraineAdditionalInfo_UkraineTrnType"=@("Write-TSATaxRegistration","Write-TSATaxRegistrationBatch")
}

_awsArgumentCompleterRegistration $TSA_Completers $TSA_map

$TSA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TSA.$($commandName.Replace('-', ''))Cmdlet]"
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

$TSA_SelectMap = @{
    "Select"=@("Remove-TSATaxRegistrationBatch",
               "Write-TSATaxRegistrationBatch",
               "Remove-TSASupplementalTaxRegistration",
               "Remove-TSATaxRegistration",
               "Get-TSATaxRegistration",
               "Get-TSATaxRegistrationDocument",
               "Get-TSASupplementalTaxRegistrationList",
               "Get-TSATaxRegistrationList",
               "Write-TSASupplementalTaxRegistration",
               "Write-TSATaxRegistration")
}

_awsArgumentCompleterRegistration $TSA_SelectCompleters $TSA_SelectMap

