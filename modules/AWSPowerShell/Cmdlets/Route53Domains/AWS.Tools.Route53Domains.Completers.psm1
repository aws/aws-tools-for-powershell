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

# Argument completions for service Amazon Route 53 Domains


$R53D_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Route53Domains.ContactType
        {
            ($_ -eq "Invoke-R53DDomainTransfer/AdminContact_ContactType") -Or
            ($_ -eq "Register-R53DDomain/AdminContact_ContactType") -Or
            ($_ -eq "Update-R53DDomainContact/AdminContact_ContactType") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/RegistrantContact_ContactType") -Or
            ($_ -eq "Register-R53DDomain/RegistrantContact_ContactType") -Or
            ($_ -eq "Update-R53DDomainContact/RegistrantContact_ContactType") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/TechContact_ContactType") -Or
            ($_ -eq "Register-R53DDomain/TechContact_ContactType") -Or
            ($_ -eq "Update-R53DDomainContact/TechContact_ContactType")
        }
        {
            $v = "ASSOCIATION","COMPANY","PERSON","PUBLIC_BODY","RESELLER"
            break
        }

        # Amazon.Route53Domains.CountryCode
        {
            ($_ -eq "Invoke-R53DDomainTransfer/AdminContact_CountryCode") -Or
            ($_ -eq "Register-R53DDomain/AdminContact_CountryCode") -Or
            ($_ -eq "Update-R53DDomainContact/AdminContact_CountryCode") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/RegistrantContact_CountryCode") -Or
            ($_ -eq "Register-R53DDomain/RegistrantContact_CountryCode") -Or
            ($_ -eq "Update-R53DDomainContact/RegistrantContact_CountryCode") -Or
            ($_ -eq "Invoke-R53DDomainTransfer/TechContact_CountryCode") -Or
            ($_ -eq "Register-R53DDomain/TechContact_CountryCode") -Or
            ($_ -eq "Update-R53DDomainContact/TechContact_CountryCode")
        }
        {
            $v = "AD","AE","AF","AG","AI","AL","AM","AN","AO","AQ","AR","AS","AT","AU","AW","AZ","BA","BB","BD","BE","BF","BG","BH","BI","BJ","BL","BM","BN","BO","BR","BS","BT","BW","BY","BZ","CA","CC","CD","CF","CG","CH","CI","CK","CL","CM","CN","CO","CR","CU","CV","CX","CY","CZ","DE","DJ","DK","DM","DO","DZ","EC","EE","EG","ER","ES","ET","FI","FJ","FK","FM","FO","FR","GA","GB","GD","GE","GH","GI","GL","GM","GN","GQ","GR","GT","GU","GW","GY","HK","HN","HR","HT","HU","ID","IE","IL","IM","IN","IQ","IR","IS","IT","JM","JO","JP","KE","KG","KH","KI","KM","KN","KP","KR","KW","KY","KZ","LA","LB","LC","LI","LK","LR","LS","LT","LU","LV","LY","MA","MC","MD","ME","MF","MG","MH","MK","ML","MM","MN","MO","MP","MR","MS","MT","MU","MV","MW","MX","MY","MZ","NA","NC","NE","NG","NI","NL","NO","NP","NR","NU","NZ","OM","PA","PE","PF","PG","PH","PK","PL","PM","PN","PR","PT","PW","PY","QA","RO","RS","RU","RW","SA","SB","SC","SD","SE","SG","SH","SI","SK","SL","SM","SN","SO","SR","ST","SV","SY","SZ","TC","TD","TG","TH","TJ","TK","TL","TM","TN","TO","TR","TT","TV","TW","TZ","UA","UG","US","UY","UZ","VA","VC","VE","VG","VI","VN","VU","WF","WS","YE","YT","ZA","ZM","ZW"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$R53D_map = @{
    "AdminContact_ContactType"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "AdminContact_CountryCode"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "RegistrantContact_ContactType"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "RegistrantContact_CountryCode"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "TechContact_ContactType"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
    "TechContact_CountryCode"=@("Invoke-R53DDomainTransfer","Register-R53DDomain","Update-R53DDomainContact")
}

_awsArgumentCompleterRegistration $R53D_Completers $R53D_map

$R53D_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.R53D.$($commandName.Replace('-', ''))Cmdlet]"
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

$R53D_SelectMap = @{
    "Select"=@("Approve-R53DDomainTransferFromAnotherAwsAccount",
               "Stop-R53DDomainTransferToAnotherAwsAccount",
               "Test-R53DDomainAvailability",
               "Test-R53DDomainTransferability",
               "Remove-R53DTagsForDomain",
               "Disable-R53DDomainAutoRenew",
               "Disable-R53DDomainTransferLock",
               "Enable-R53DDomainAutoRenew",
               "Enable-R53DDomainTransferLock",
               "Get-R53DContactReachabilityStatus",
               "Get-R53DDomainDetail",
               "Get-R53DDomainSuggestion",
               "Get-R53DOperationDetail",
               "Get-R53DDomainList",
               "Get-R53DOperationList",
               "Get-R53DTagsForDomain",
               "Register-R53DDomain",
               "Deny-R53DDomainTransferFromAnotherAwsAccount",
               "Update-R53DDomainRenewal",
               "Send-R53DContactReachabilityEmail",
               "Get-R53DDomainAuthCode",
               "Invoke-R53DDomainTransfer",
               "Move-R53DDomainToAnotherAwsAccount",
               "Update-R53DDomainContact",
               "Update-R53DDomainContactPrivacy",
               "Update-R53DDomainNameserver",
               "Update-R53DTagsForDomain",
               "Get-R53DBillingRecord")
}

_awsArgumentCompleterRegistration $R53D_SelectCompleters $R53D_SelectMap

