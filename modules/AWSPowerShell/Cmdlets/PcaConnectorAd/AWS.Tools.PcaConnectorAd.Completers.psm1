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

# Argument completions for service Pca Connector Ad


$PCAAD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PcaConnectorAd.AccessRight
        {
            ($_ -eq "New-PCAADTemplateGroupAccessControlEntry/AccessRights_AutoEnroll") -Or
            ($_ -eq "Update-PCAADTemplateGroupAccessControlEntry/AccessRights_AutoEnroll") -Or
            ($_ -eq "New-PCAADTemplateGroupAccessControlEntry/AccessRights_Enroll") -Or
            ($_ -eq "Update-PCAADTemplateGroupAccessControlEntry/AccessRights_Enroll")
        }
        {
            $v = "ALLOW","DENY"
            break
        }

        # Amazon.PcaConnectorAd.ClientCompatibilityV2
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV2_PrivateKeyFlags_ClientVersion") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV2_PrivateKeyFlags_ClientVersion")
        }
        {
            $v = "WINDOWS_SERVER_2003","WINDOWS_SERVER_2008","WINDOWS_SERVER_2008_R2","WINDOWS_SERVER_2012","WINDOWS_SERVER_2012_R2","WINDOWS_SERVER_2016"
            break
        }

        # Amazon.PcaConnectorAd.ClientCompatibilityV3
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_PrivateKeyFlags_ClientVersion") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_PrivateKeyFlags_ClientVersion")
        }
        {
            $v = "WINDOWS_SERVER_2008","WINDOWS_SERVER_2008_R2","WINDOWS_SERVER_2012","WINDOWS_SERVER_2012_R2","WINDOWS_SERVER_2016"
            break
        }

        # Amazon.PcaConnectorAd.ClientCompatibilityV4
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_PrivateKeyFlags_ClientVersion") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_PrivateKeyFlags_ClientVersion")
        }
        {
            $v = "WINDOWS_SERVER_2012","WINDOWS_SERVER_2012_R2","WINDOWS_SERVER_2016"
            break
        }

        # Amazon.PcaConnectorAd.HashAlgorithm
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_HashAlgorithm") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_HashAlgorithm") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_HashAlgorithm") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_HashAlgorithm")
        }
        {
            $v = "SHA256","SHA384","SHA512"
            break
        }

        # Amazon.PcaConnectorAd.KeySpec
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV2_PrivateKeyAttributes_KeySpec") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV2_PrivateKeyAttributes_KeySpec") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_PrivateKeyAttributes_KeySpec") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_PrivateKeyAttributes_KeySpec") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_PrivateKeyAttributes_KeySpec") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_PrivateKeyAttributes_KeySpec")
        }
        {
            $v = "KEY_EXCHANGE","SIGNATURE"
            break
        }

        # Amazon.PcaConnectorAd.KeyUsagePropertyType
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType")
        }
        {
            $v = "ALL"
            break
        }

        # Amazon.PcaConnectorAd.PrivateKeyAlgorithm
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_PrivateKeyAttributes_Algorithm") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_PrivateKeyAttributes_Algorithm") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_PrivateKeyAttributes_Algorithm") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_PrivateKeyAttributes_Algorithm")
        }
        {
            $v = "ECDH_P256","ECDH_P384","ECDH_P521","RSA"
            break
        }

        # Amazon.PcaConnectorAd.ValidityPeriodType
        {
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType") -Or
            ($_ -eq "New-PCAADTemplate/Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType") -Or
            ($_ -eq "Update-PCAADTemplate/Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType")
        }
        {
            $v = "DAYS","HOURS","MONTHS","WEEKS","YEARS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PCAAD_map = @{
    "AccessRights_AutoEnroll"=@("New-PCAADTemplateGroupAccessControlEntry","Update-PCAADTemplateGroupAccessControlEntry")
    "AccessRights_Enroll"=@("New-PCAADTemplateGroupAccessControlEntry","Update-PCAADTemplateGroupAccessControlEntry")
    "Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV2_PrivateKeyAttributes_KeySpec"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV2_PrivateKeyFlags_ClientVersion"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_HashAlgorithm"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_PrivateKeyAttributes_Algorithm"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_PrivateKeyAttributes_KeySpec"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV3_PrivateKeyFlags_ClientVersion"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_HashAlgorithm"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_PrivateKeyAttributes_Algorithm"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_PrivateKeyAttributes_KeySpec"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType"=@("New-PCAADTemplate","Update-PCAADTemplate")
    "Definition_TemplateV4_PrivateKeyFlags_ClientVersion"=@("New-PCAADTemplate","Update-PCAADTemplate")
}

_awsArgumentCompleterRegistration $PCAAD_Completers $PCAAD_map

$PCAAD_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PCAAD.$($commandName.Replace('-', ''))Cmdlet]"
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

$PCAAD_SelectMap = @{
    "Select"=@("New-PCAADConnector",
               "New-PCAADDirectoryRegistration",
               "New-PCAADServicePrincipalName",
               "New-PCAADTemplate",
               "New-PCAADTemplateGroupAccessControlEntry",
               "Remove-PCAADConnector",
               "Remove-PCAADDirectoryRegistration",
               "Remove-PCAADServicePrincipalName",
               "Remove-PCAADTemplate",
               "Remove-PCAADTemplateGroupAccessControlEntry",
               "Get-PCAADConnector",
               "Get-PCAADDirectoryRegistration",
               "Get-PCAADServicePrincipalName",
               "Get-PCAADTemplate",
               "Get-PCAADTemplateGroupAccessControlEntry",
               "Get-PCAADConnectorList",
               "Get-PCAADDirectoryRegistrationList",
               "Get-PCAADServicePrincipalNameList",
               "Get-PCAADResourceTagList",
               "Get-PCAADTemplateGroupAccessControlEntryList",
               "Get-PCAADTemplateList",
               "Add-PCAADResourceTag",
               "Remove-PCAADResourceTag",
               "Update-PCAADTemplate",
               "Update-PCAADTemplateGroupAccessControlEntry")
}

_awsArgumentCompleterRegistration $PCAAD_SelectCompleters $PCAAD_SelectMap

