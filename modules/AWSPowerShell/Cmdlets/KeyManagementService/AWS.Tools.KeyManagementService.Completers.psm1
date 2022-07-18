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

# Argument completions for service AWS Key Management Service


$KMS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.KeyManagementService.AlgorithmSpec
        "Get-KMSParametersForImport/WrappingAlgorithm"
        {
            $v = "RSAES_OAEP_SHA_1","RSAES_OAEP_SHA_256","RSAES_PKCS1_V1_5"
            break
        }

        # Amazon.KeyManagementService.CustomerMasterKeySpec
        "New-KMSKey/CustomerMasterKeySpec"
        {
            $v = "ECC_NIST_P256","ECC_NIST_P384","ECC_NIST_P521","ECC_SECG_P256K1","HMAC_224","HMAC_256","HMAC_384","HMAC_512","RSA_2048","RSA_3072","RSA_4096","SM2","SYMMETRIC_DEFAULT"
            break
        }

        # Amazon.KeyManagementService.DataKeyPairSpec
        {
            ($_ -eq "New-KMSDataKeyPair/KeyPairSpec") -Or
            ($_ -eq "New-KMSDataKeyPairWithoutPlaintext/KeyPairSpec")
        }
        {
            $v = "ECC_NIST_P256","ECC_NIST_P384","ECC_NIST_P521","ECC_SECG_P256K1","RSA_2048","RSA_3072","RSA_4096","SM2"
            break
        }

        # Amazon.KeyManagementService.DataKeySpec
        {
            ($_ -eq "New-KMSDataKey/KeySpec") -Or
            ($_ -eq "New-KMSDataKeyWithoutPlaintext/KeySpec")
        }
        {
            $v = "AES_128","AES_256"
            break
        }

        # Amazon.KeyManagementService.EncryptionAlgorithmSpec
        {
            ($_ -eq "Invoke-KMSReEncrypt/DestinationEncryptionAlgorithm") -Or
            ($_ -eq "Invoke-KMSDecrypt/EncryptionAlgorithm") -Or
            ($_ -eq "Invoke-KMSEncrypt/EncryptionAlgorithm") -Or
            ($_ -eq "Invoke-KMSReEncrypt/SourceEncryptionAlgorithm")
        }
        {
            $v = "RSAES_OAEP_SHA_1","RSAES_OAEP_SHA_256","SM2PKE","SYMMETRIC_DEFAULT"
            break
        }

        # Amazon.KeyManagementService.ExpirationModelType
        "Import-KMSKeyMaterial/ExpirationModel"
        {
            $v = "KEY_MATERIAL_DOES_NOT_EXPIRE","KEY_MATERIAL_EXPIRES"
            break
        }

        # Amazon.KeyManagementService.KeySpec
        "New-KMSKey/KeySpec"
        {
            $v = "ECC_NIST_P256","ECC_NIST_P384","ECC_NIST_P521","ECC_SECG_P256K1","HMAC_224","HMAC_256","HMAC_384","HMAC_512","RSA_2048","RSA_3072","RSA_4096","SM2","SYMMETRIC_DEFAULT"
            break
        }

        # Amazon.KeyManagementService.KeyUsageType
        "New-KMSKey/KeyUsage"
        {
            $v = "ENCRYPT_DECRYPT","GENERATE_VERIFY_MAC","SIGN_VERIFY"
            break
        }

        # Amazon.KeyManagementService.MacAlgorithmSpec
        {
            ($_ -eq "New-KMSMac/MacAlgorithm") -Or
            ($_ -eq "Test-KMSMac/MacAlgorithm")
        }
        {
            $v = "HMAC_SHA_224","HMAC_SHA_256","HMAC_SHA_384","HMAC_SHA_512"
            break
        }

        # Amazon.KeyManagementService.MessageType
        {
            ($_ -eq "Invoke-KMSSigning/MessageType") -Or
            ($_ -eq "Test-KMSSignature/MessageType")
        }
        {
            $v = "DIGEST","RAW"
            break
        }

        # Amazon.KeyManagementService.OriginType
        "New-KMSKey/Origin"
        {
            $v = "AWS_CLOUDHSM","AWS_KMS","EXTERNAL"
            break
        }

        # Amazon.KeyManagementService.SigningAlgorithmSpec
        {
            ($_ -eq "Invoke-KMSSigning/SigningAlgorithm") -Or
            ($_ -eq "Test-KMSSignature/SigningAlgorithm")
        }
        {
            $v = "ECDSA_SHA_256","ECDSA_SHA_384","ECDSA_SHA_512","RSASSA_PKCS1_V1_5_SHA_256","RSASSA_PKCS1_V1_5_SHA_384","RSASSA_PKCS1_V1_5_SHA_512","RSASSA_PSS_SHA_256","RSASSA_PSS_SHA_384","RSASSA_PSS_SHA_512","SM2DSA"
            break
        }

        # Amazon.KeyManagementService.WrappingKeySpec
        "Get-KMSParametersForImport/WrappingKeySpec"
        {
            $v = "RSA_2048"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$KMS_map = @{
    "CustomerMasterKeySpec"=@("New-KMSKey")
    "DestinationEncryptionAlgorithm"=@("Invoke-KMSReEncrypt")
    "EncryptionAlgorithm"=@("Invoke-KMSDecrypt","Invoke-KMSEncrypt")
    "ExpirationModel"=@("Import-KMSKeyMaterial")
    "KeyPairSpec"=@("New-KMSDataKeyPair","New-KMSDataKeyPairWithoutPlaintext")
    "KeySpec"=@("New-KMSDataKey","New-KMSDataKeyWithoutPlaintext","New-KMSKey")
    "KeyUsage"=@("New-KMSKey")
    "MacAlgorithm"=@("New-KMSMac","Test-KMSMac")
    "MessageType"=@("Invoke-KMSSigning","Test-KMSSignature")
    "Origin"=@("New-KMSKey")
    "SigningAlgorithm"=@("Invoke-KMSSigning","Test-KMSSignature")
    "SourceEncryptionAlgorithm"=@("Invoke-KMSReEncrypt")
    "WrappingAlgorithm"=@("Get-KMSParametersForImport")
    "WrappingKeySpec"=@("Get-KMSParametersForImport")
}

_awsArgumentCompleterRegistration $KMS_Completers $KMS_map

$KMS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.KMS.$($commandName.Replace('-', ''))Cmdlet]"
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

$KMS_SelectMap = @{
    "Select"=@("Stop-KMSKeyDeletion",
               "Connect-KMSCustomKeyStore",
               "New-KMSAlias",
               "New-KMSCustomKeyStore",
               "New-KMSGrant",
               "New-KMSKey",
               "Invoke-KMSDecrypt",
               "Remove-KMSAlias",
               "Remove-KMSCustomKeyStore",
               "Remove-KMSImportedKeyMaterial",
               "Get-KMSCustomKeyStore",
               "Get-KMSKey",
               "Disable-KMSKey",
               "Disable-KMSKeyRotation",
               "Disconnect-KMSCustomKeyStore",
               "Enable-KMSKey",
               "Enable-KMSKeyRotation",
               "Invoke-KMSEncrypt",
               "New-KMSDataKey",
               "New-KMSDataKeyPair",
               "New-KMSDataKeyPairWithoutPlaintext",
               "New-KMSDataKeyWithoutPlaintext",
               "New-KMSMac",
               "New-KMSRandom",
               "Get-KMSKeyPolicy",
               "Get-KMSKeyRotationStatus",
               "Get-KMSParametersForImport",
               "Get-KMSPublicKey",
               "Import-KMSKeyMaterial",
               "Get-KMSAliasList",
               "Get-KMSGrantList",
               "Get-KMSKeyPolicyList",
               "Get-KMSKeyList",
               "Get-KMSResourceTag",
               "Get-KMSRetirableGrant",
               "Write-KMSKeyPolicy",
               "Invoke-KMSReEncrypt",
               "New-KMSReplicaKey",
               "Disable-KMSGrant",
               "Revoke-KMSGrant",
               "Request-KMSKeyDeletion",
               "Invoke-KMSSigning",
               "Add-KMSResourceTag",
               "Remove-KMSResourceTag",
               "Update-KMSAlias",
               "Update-KMSCustomKeyStore",
               "Update-KMSKeyDescription",
               "Update-KMSPrimaryRegion",
               "Test-KMSSignature",
               "Test-KMSMac")
}

_awsArgumentCompleterRegistration $KMS_SelectCompleters $KMS_SelectMap

