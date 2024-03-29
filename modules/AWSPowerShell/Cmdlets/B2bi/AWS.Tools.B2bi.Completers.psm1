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

# Argument completions for service AWS B2B Data Interchange


$B2BI_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.B2bi.CapabilityType
        "New-B2BICapability/Type"
        {
            $v = "edi"
            break
        }

        # Amazon.B2bi.FileFormat
        {
            ($_ -eq "New-B2BITransformer/FileFormat") -Or
            ($_ -eq "Test-B2BIMapping/FileFormat") -Or
            ($_ -eq "Test-B2BIParsing/FileFormat") -Or
            ($_ -eq "Update-B2BITransformer/FileFormat")
        }
        {
            $v = "JSON","XML"
            break
        }

        # Amazon.B2bi.Logging
        "New-B2BIProfile/Logging"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.B2bi.TransformerStatus
        "Update-B2BITransformer/Status"
        {
            $v = "active","inactive"
            break
        }

        # Amazon.B2bi.X12TransactionSet
        {
            ($_ -eq "New-B2BICapability/X12Details_TransactionSet") -Or
            ($_ -eq "New-B2BITransformer/X12Details_TransactionSet") -Or
            ($_ -eq "Test-B2BIParsing/X12Details_TransactionSet") -Or
            ($_ -eq "Update-B2BICapability/X12Details_TransactionSet") -Or
            ($_ -eq "Update-B2BITransformer/X12Details_TransactionSet")
        }
        {
            $v = "X12_110","X12_180","X12_204","X12_210","X12_211","X12_214","X12_215","X12_259","X12_260","X12_266","X12_269","X12_270","X12_271","X12_274","X12_275","X12_276","X12_277","X12_278","X12_310","X12_315","X12_322","X12_404","X12_410","X12_417","X12_421","X12_426","X12_810","X12_820","X12_824","X12_830","X12_832","X12_834","X12_835","X12_837","X12_844","X12_846","X12_849","X12_850","X12_852","X12_855","X12_856","X12_860","X12_861","X12_864","X12_865","X12_869","X12_870","X12_940","X12_945","X12_990","X12_997","X12_999"
            break
        }

        # Amazon.B2bi.X12Version
        {
            ($_ -eq "New-B2BICapability/X12Details_Version") -Or
            ($_ -eq "New-B2BITransformer/X12Details_Version") -Or
            ($_ -eq "Test-B2BIParsing/X12Details_Version") -Or
            ($_ -eq "Update-B2BICapability/X12Details_Version") -Or
            ($_ -eq "Update-B2BITransformer/X12Details_Version")
        }
        {
            $v = "VERSION_4010","VERSION_4030","VERSION_5010"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$B2BI_map = @{
    "FileFormat"=@("New-B2BITransformer","Test-B2BIMapping","Test-B2BIParsing","Update-B2BITransformer")
    "Logging"=@("New-B2BIProfile")
    "Status"=@("Update-B2BITransformer")
    "Type"=@("New-B2BICapability")
    "X12Details_TransactionSet"=@("New-B2BICapability","New-B2BITransformer","Test-B2BIParsing","Update-B2BICapability","Update-B2BITransformer")
    "X12Details_Version"=@("New-B2BICapability","New-B2BITransformer","Test-B2BIParsing","Update-B2BICapability","Update-B2BITransformer")
}

_awsArgumentCompleterRegistration $B2BI_Completers $B2BI_map

$B2BI_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.B2BI.$($commandName.Replace('-', ''))Cmdlet]"
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

$B2BI_SelectMap = @{
    "Select"=@("New-B2BICapability",
               "New-B2BIPartnership",
               "New-B2BIProfile",
               "New-B2BITransformer",
               "Remove-B2BICapability",
               "Remove-B2BIPartnership",
               "Remove-B2BIProfile",
               "Remove-B2BITransformer",
               "Get-B2BICapability",
               "Get-B2BIPartnership",
               "Get-B2BIProfile",
               "Get-B2BITransformer",
               "Get-B2BITransformerJob",
               "Get-B2BICapabilityList",
               "Get-B2BIPartnershipList",
               "Get-B2BIProfileList",
               "Get-B2BIResourceTag",
               "Get-B2BITransformerList",
               "Start-B2BITransformerJob",
               "Add-B2BIResourceTag",
               "Test-B2BIMapping",
               "Test-B2BIParsing",
               "Remove-B2BIResourceTag",
               "Update-B2BICapability",
               "Update-B2BIPartnership",
               "Update-B2BIProfile",
               "Update-B2BITransformer")
}

_awsArgumentCompleterRegistration $B2BI_SelectCompleters $B2BI_SelectMap

