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

# Argument completions for service Payment Cryptography Control Plane


$PAYCC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PaymentCryptography.As2805KeyVariant
        {
            ($_ -eq "Export-PAYCCKey/KeyMaterial_As2805KeyCryptogram_As2805KeyVariant") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_As2805KeyCryptogram_As2805KeyVariant")
        }
        {
            $v = "DATA_ENCRYPTION_KEY_VARIANT_22","MESSAGE_AUTHENTICATION_KEY_VARIANT_24","PIN_ENCRYPTION_KEY_VARIANT_28","TERMINAL_MAJOR_KEY_VARIANT_00"
            break
        }

        # Amazon.PaymentCryptography.DeriveKeyUsage
        "New-PAYCCKey/DeriveKeyUsage"
        {
            $v = "TR31_B0_BASE_DERIVATION_KEY","TR31_C0_CARD_VERIFICATION_KEY","TR31_D0_SYMMETRIC_DATA_ENCRYPTION_KEY","TR31_E0_EMV_MKEY_APP_CRYPTOGRAMS","TR31_E1_EMV_MKEY_CONFIDENTIALITY","TR31_E2_EMV_MKEY_INTEGRITY","TR31_E4_EMV_MKEY_DYNAMIC_NUMBERS","TR31_E5_EMV_MKEY_CARD_PERSONALIZATION","TR31_E6_EMV_MKEY_OTHER","TR31_K0_KEY_ENCRYPTION_KEY","TR31_K1_KEY_BLOCK_PROTECTION_KEY","TR31_M1_ISO_9797_1_MAC_KEY","TR31_M3_ISO_9797_3_MAC_KEY","TR31_M6_ISO_9797_5_CMAC_KEY","TR31_M7_HMAC_KEY","TR31_P0_PIN_ENCRYPTION_KEY","TR31_P1_PIN_GENERATION_KEY","TR31_V1_IBM3624_PIN_VERIFICATION_KEY","TR31_V2_VISA_PIN_VERIFICATION_KEY"
            break
        }

        # Amazon.PaymentCryptography.KeyAlgorithm
        {
            ($_ -eq "Import-PAYCCKey/KeyAttributes_KeyAlgorithm") -Or
            ($_ -eq "New-PAYCCKey/KeyAttributes_KeyAlgorithm") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_As2805KeyCryptogram_KeyAlgorithm") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm") -Or
            ($_ -eq "Get-PAYCCParametersForExport/SigningKeyAlgorithm") -Or
            ($_ -eq "Get-PAYCCParametersForImport/WrappingKeyAlgorithm")
        }
        {
            $v = "AES_128","AES_192","AES_256","ECC_NIST_P256","ECC_NIST_P384","ECC_NIST_P521","HMAC_SHA224","HMAC_SHA256","HMAC_SHA384","HMAC_SHA512","RSA_2048","RSA_3072","RSA_4096","TDES_2KEY","TDES_3KEY"
            break
        }

        # Amazon.PaymentCryptography.KeyCheckValueAlgorithm
        {
            ($_ -eq "Export-PAYCCKey/ExportAttributes_KeyCheckValueAlgorithm") -Or
            ($_ -eq "Import-PAYCCKey/KeyCheckValueAlgorithm") -Or
            ($_ -eq "New-PAYCCKey/KeyCheckValueAlgorithm")
        }
        {
            $v = "ANSI_X9_24","CMAC","HMAC","SHA_1"
            break
        }

        # Amazon.PaymentCryptography.KeyClass
        {
            ($_ -eq "Import-PAYCCKey/KeyAttributes_KeyClass") -Or
            ($_ -eq "New-PAYCCKey/KeyAttributes_KeyClass") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass")
        }
        {
            $v = "ASYMMETRIC_KEY_PAIR","PRIVATE_KEY","PUBLIC_KEY","SYMMETRIC_KEY"
            break
        }

        # Amazon.PaymentCryptography.KeyDerivationFunction
        {
            ($_ -eq "Export-PAYCCKey/DiffieHellmanTr31KeyBlock_KeyDerivationFunction") -Or
            ($_ -eq "Import-PAYCCKey/DiffieHellmanTr31KeyBlock_KeyDerivationFunction")
        }
        {
            $v = "ANSI_X963","NIST_SP800"
            break
        }

        # Amazon.PaymentCryptography.KeyDerivationHashAlgorithm
        {
            ($_ -eq "Export-PAYCCKey/DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm") -Or
            ($_ -eq "Import-PAYCCKey/DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm")
        }
        {
            $v = "SHA_256","SHA_384","SHA_512"
            break
        }

        # Amazon.PaymentCryptography.KeyExportability
        {
            ($_ -eq "Export-PAYCCKey/KeyBlockHeaders_KeyExportability") -Or
            ($_ -eq "Export-PAYCCKey/KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability") -Or
            ($_ -eq "Export-PAYCCKey/KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability")
        }
        {
            $v = "EXPORTABLE","NON_EXPORTABLE","SENSITIVE"
            break
        }

        # Amazon.PaymentCryptography.KeyMaterialType
        {
            ($_ -eq "Get-PAYCCParametersForExport/KeyMaterialType") -Or
            ($_ -eq "Get-PAYCCParametersForImport/KeyMaterialType")
        }
        {
            $v = "KEY_CRYPTOGRAM","ROOT_PUBLIC_KEY_CERTIFICATE","TR31_KEY_BLOCK","TR34_KEY_BLOCK","TRUSTED_PUBLIC_KEY_CERTIFICATE"
            break
        }

        # Amazon.PaymentCryptography.KeyState
        "Get-PAYCCKeyList/KeyState"
        {
            $v = "CREATE_COMPLETE","CREATE_IN_PROGRESS","DELETE_COMPLETE","DELETE_PENDING"
            break
        }

        # Amazon.PaymentCryptography.KeyUsage
        {
            ($_ -eq "Import-PAYCCKey/KeyAttributes_KeyUsage") -Or
            ($_ -eq "New-PAYCCKey/KeyAttributes_KeyUsage") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage") -Or
            ($_ -eq "Import-PAYCCKey/KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage")
        }
        {
            $v = "TR31_B0_BASE_DERIVATION_KEY","TR31_C0_CARD_VERIFICATION_KEY","TR31_D0_SYMMETRIC_DATA_ENCRYPTION_KEY","TR31_D1_ASYMMETRIC_KEY_FOR_DATA_ENCRYPTION","TR31_E0_EMV_MKEY_APP_CRYPTOGRAMS","TR31_E1_EMV_MKEY_CONFIDENTIALITY","TR31_E2_EMV_MKEY_INTEGRITY","TR31_E4_EMV_MKEY_DYNAMIC_NUMBERS","TR31_E5_EMV_MKEY_CARD_PERSONALIZATION","TR31_E6_EMV_MKEY_OTHER","TR31_K0_KEY_ENCRYPTION_KEY","TR31_K1_KEY_BLOCK_PROTECTION_KEY","TR31_K2_TR34_ASYMMETRIC_KEY","TR31_K3_ASYMMETRIC_KEY_FOR_KEY_AGREEMENT","TR31_M0_ISO_16609_MAC_KEY","TR31_M1_ISO_9797_1_MAC_KEY","TR31_M3_ISO_9797_3_MAC_KEY","TR31_M6_ISO_9797_5_CMAC_KEY","TR31_M7_HMAC_KEY","TR31_P0_PIN_ENCRYPTION_KEY","TR31_P1_PIN_GENERATION_KEY","TR31_S0_ASYMMETRIC_KEY_FOR_DIGITAL_SIGNATURE","TR31_V1_IBM3624_PIN_VERIFICATION_KEY","TR31_V2_VISA_PIN_VERIFICATION_KEY"
            break
        }

        # Amazon.PaymentCryptography.SigningAlgorithmType
        "Get-PAYCCCertificateSigningRequest/SigningAlgorithm"
        {
            $v = "SHA224","SHA256","SHA384","SHA512"
            break
        }

        # Amazon.PaymentCryptography.SymmetricKeyAlgorithm
        {
            ($_ -eq "Export-PAYCCKey/DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm") -Or
            ($_ -eq "Import-PAYCCKey/DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm")
        }
        {
            $v = "AES_128","AES_192","AES_256","HMAC_SHA224","HMAC_SHA256","HMAC_SHA384","HMAC_SHA512","TDES_2KEY","TDES_3KEY"
            break
        }

        # Amazon.PaymentCryptography.Tr34KeyBlockFormat
        {
            ($_ -eq "Export-PAYCCKey/Tr34KeyBlock_KeyBlockFormat") -Or
            ($_ -eq "Import-PAYCCKey/Tr34KeyBlock_KeyBlockFormat")
        }
        {
            $v = "X9_TR34_2012"
            break
        }

        # Amazon.PaymentCryptography.WrappingKeySpec
        {
            ($_ -eq "Export-PAYCCKey/KeyCryptogram_WrappingSpec") -Or
            ($_ -eq "Import-PAYCCKey/KeyCryptogram_WrappingSpec")
        }
        {
            $v = "RSA_OAEP_SHA_256","RSA_OAEP_SHA_512"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PAYCC_map = @{
    "DeriveKeyUsage"=@("New-PAYCCKey")
    "DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm"=@("Export-PAYCCKey","Import-PAYCCKey")
    "DiffieHellmanTr31KeyBlock_KeyDerivationFunction"=@("Export-PAYCCKey","Import-PAYCCKey")
    "DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm"=@("Export-PAYCCKey","Import-PAYCCKey")
    "ExportAttributes_KeyCheckValueAlgorithm"=@("Export-PAYCCKey")
    "KeyAttributes_KeyAlgorithm"=@("Import-PAYCCKey","New-PAYCCKey")
    "KeyAttributes_KeyClass"=@("Import-PAYCCKey","New-PAYCCKey")
    "KeyAttributes_KeyUsage"=@("Import-PAYCCKey","New-PAYCCKey")
    "KeyBlockHeaders_KeyExportability"=@("Export-PAYCCKey")
    "KeyCheckValueAlgorithm"=@("Import-PAYCCKey","New-PAYCCKey")
    "KeyCryptogram_WrappingSpec"=@("Export-PAYCCKey","Import-PAYCCKey")
    "KeyMaterial_As2805KeyCryptogram_As2805KeyVariant"=@("Export-PAYCCKey","Import-PAYCCKey")
    "KeyMaterial_As2805KeyCryptogram_KeyAlgorithm"=@("Import-PAYCCKey")
    "KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability"=@("Export-PAYCCKey")
    "KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm"=@("Import-PAYCCKey")
    "KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass"=@("Import-PAYCCKey")
    "KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage"=@("Import-PAYCCKey")
    "KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm"=@("Import-PAYCCKey")
    "KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass"=@("Import-PAYCCKey")
    "KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage"=@("Import-PAYCCKey")
    "KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability"=@("Export-PAYCCKey")
    "KeyMaterialType"=@("Get-PAYCCParametersForExport","Get-PAYCCParametersForImport")
    "KeyState"=@("Get-PAYCCKeyList")
    "SigningAlgorithm"=@("Get-PAYCCCertificateSigningRequest")
    "SigningKeyAlgorithm"=@("Get-PAYCCParametersForExport")
    "Tr34KeyBlock_KeyBlockFormat"=@("Export-PAYCCKey","Import-PAYCCKey")
    "WrappingKeyAlgorithm"=@("Get-PAYCCParametersForImport")
}

_awsArgumentCompleterRegistration $PAYCC_Completers $PAYCC_map

$PAYCC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PAYCC.$($commandName.Replace('-', ''))Cmdlet]"
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

$PAYCC_SelectMap = @{
    "Select"=@("Add-PAYCCKeyReplicationRegion",
               "New-PAYCCAlias",
               "New-PAYCCKey",
               "Remove-PAYCCAlias",
               "Remove-PAYCCKey",
               "Disable-PAYCCDefaultKeyReplicationRegion",
               "Enable-PAYCCDefaultKeyReplicationRegion",
               "Export-PAYCCKey",
               "Get-PAYCCAlias",
               "Get-PAYCCCertificateSigningRequest",
               "Get-PAYCCDefaultKeyReplicationRegion",
               "Get-PAYCCKey",
               "Get-PAYCCParametersForExport",
               "Get-PAYCCParametersForImport",
               "Get-PAYCCPublicKeyCertificate",
               "Import-PAYCCKey",
               "Get-PAYCCAliasList",
               "Get-PAYCCKeyList",
               "Get-PAYCCResourceTag",
               "Remove-PAYCCKeyReplicationRegion",
               "Restore-PAYCCKey",
               "Start-PAYCCKeyUsage",
               "Stop-PAYCCKeyUsage",
               "Add-PAYCCResourceTag",
               "Remove-PAYCCResourceTag",
               "Update-PAYCCAlias")
}

_awsArgumentCompleterRegistration $PAYCC_SelectCompleters $PAYCC_SelectMap

