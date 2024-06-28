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

# Argument completions for service AWS Certificate Manager Private Certificate Authority


$PCA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ACMPCA.AuditReportResponseFormat
        "New-PCACertificateAuthorityAuditReport/AuditReportResponseFormat"
        {
            $v = "CSV","JSON"
            break
        }

        # Amazon.ACMPCA.CertificateAuthorityStatus
        "Update-PCACertificateAuthority/Status"
        {
            $v = "ACTIVE","CREATING","DELETED","DISABLED","EXPIRED","FAILED","PENDING_CERTIFICATE"
            break
        }

        # Amazon.ACMPCA.CertificateAuthorityType
        "New-PCACertificateAuthority/CertificateAuthorityType"
        {
            $v = "ROOT","SUBORDINATE"
            break
        }

        # Amazon.ACMPCA.CertificateAuthorityUsageMode
        "New-PCACertificateAuthority/UsageMode"
        {
            $v = "GENERAL_PURPOSE","SHORT_LIVED_CERTIFICATE"
            break
        }

        # Amazon.ACMPCA.KeyStorageSecurityStandard
        "New-PCACertificateAuthority/KeyStorageSecurityStandard"
        {
            $v = "CCPC_LEVEL_1_OR_HIGHER","FIPS_140_2_LEVEL_2_OR_HIGHER","FIPS_140_2_LEVEL_3_OR_HIGHER"
            break
        }

        # Amazon.ACMPCA.ResourceOwner
        "Get-PCACertificateAuthorityList/ResourceOwner"
        {
            $v = "OTHER_ACCOUNTS","SELF"
            break
        }

        # Amazon.ACMPCA.RevocationReason
        "Revoke-PCACertificate/RevocationReason"
        {
            $v = "AFFILIATION_CHANGED","A_A_COMPROMISE","CERTIFICATE_AUTHORITY_COMPROMISE","CESSATION_OF_OPERATION","KEY_COMPROMISE","PRIVILEGE_WITHDRAWN","SUPERSEDED","UNSPECIFIED"
            break
        }

        # Amazon.ACMPCA.SigningAlgorithm
        "New-PCACertificate/SigningAlgorithm"
        {
            $v = "SHA256WITHECDSA","SHA256WITHRSA","SHA384WITHECDSA","SHA384WITHRSA","SHA512WITHECDSA","SHA512WITHRSA","SM3WITHSM2"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PCA_map = @{
    "AuditReportResponseFormat"=@("New-PCACertificateAuthorityAuditReport")
    "CertificateAuthorityType"=@("New-PCACertificateAuthority")
    "KeyStorageSecurityStandard"=@("New-PCACertificateAuthority")
    "ResourceOwner"=@("Get-PCACertificateAuthorityList")
    "RevocationReason"=@("Revoke-PCACertificate")
    "SigningAlgorithm"=@("New-PCACertificate")
    "Status"=@("Update-PCACertificateAuthority")
    "UsageMode"=@("New-PCACertificateAuthority")
}

_awsArgumentCompleterRegistration $PCA_Completers $PCA_map

$PCA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PCA.$($commandName.Replace('-', ''))Cmdlet]"
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

$PCA_SelectMap = @{
    "Select"=@("New-PCACertificateAuthority",
               "New-PCACertificateAuthorityAuditReport",
               "New-PCAPermission",
               "Remove-PCACertificateAuthority",
               "Remove-PCAPermission",
               "Remove-PCAPolicy",
               "Get-PCACertificateAuthority",
               "Get-PCACertificateAuthorityAuditReport",
               "Get-PCACertificate",
               "Get-PCACertificateAuthorityCertificate",
               "Get-PCACertificateAuthorityCsr",
               "Get-PCAPolicy",
               "Import-PCACertificateAuthorityCertificate",
               "New-PCACertificate",
               "Get-PCACertificateAuthorityList",
               "Get-PCAPermissionList",
               "Get-PCACertificateAuthorityTagList",
               "Set-PCAPolicy",
               "Restore-PCACertificateAuthority",
               "Revoke-PCACertificate",
               "Add-PCACertificateAuthorityTag",
               "Remove-PCACertificateAuthorityTag",
               "Update-PCACertificateAuthority")
}

_awsArgumentCompleterRegistration $PCA_SelectCompleters $PCA_SelectMap

