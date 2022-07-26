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

# Argument completions for service AWS Transfer for SFTP


$TFR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Transfer.AgreementStatusType
        {
            ($_ -eq "New-TFRAgreement/Status") -Or
            ($_ -eq "Update-TFRAgreement/Status")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.Transfer.CertificateUsageType
        "Import-TFRCertificate/Usage"
        {
            $v = "ENCRYPTION","SIGNING"
            break
        }

        # Amazon.Transfer.CompressionEnum
        {
            ($_ -eq "New-TFRConnector/As2Config_Compression") -Or
            ($_ -eq "Update-TFRConnector/As2Config_Compression")
        }
        {
            $v = "DISABLED","ZLIB"
            break
        }

        # Amazon.Transfer.CustomStepStatus
        "Send-TFRWorkflowStepState/Status"
        {
            $v = "FAILURE","SUCCESS"
            break
        }

        # Amazon.Transfer.Domain
        "New-TFRServer/Domain"
        {
            $v = "EFS","S3"
            break
        }

        # Amazon.Transfer.EncryptionAlg
        {
            ($_ -eq "New-TFRConnector/As2Config_EncryptionAlgorithm") -Or
            ($_ -eq "Update-TFRConnector/As2Config_EncryptionAlgorithm")
        }
        {
            $v = "AES128_CBC","AES192_CBC","AES256_CBC"
            break
        }

        # Amazon.Transfer.EndpointType
        {
            ($_ -eq "New-TFRServer/EndpointType") -Or
            ($_ -eq "Update-TFRServer/EndpointType")
        }
        {
            $v = "PUBLIC","VPC","VPC_ENDPOINT"
            break
        }

        # Amazon.Transfer.HomeDirectoryType
        {
            ($_ -eq "New-TFRAccess/HomeDirectoryType") -Or
            ($_ -eq "New-TFRUser/HomeDirectoryType") -Or
            ($_ -eq "Update-TFRAccess/HomeDirectoryType") -Or
            ($_ -eq "Update-TFRUser/HomeDirectoryType")
        }
        {
            $v = "LOGICAL","PATH"
            break
        }

        # Amazon.Transfer.IdentityProviderType
        "New-TFRServer/IdentityProviderType"
        {
            $v = "API_GATEWAY","AWS_DIRECTORY_SERVICE","AWS_LAMBDA","SERVICE_MANAGED"
            break
        }

        # Amazon.Transfer.MdnResponse
        {
            ($_ -eq "New-TFRConnector/As2Config_MdnResponse") -Or
            ($_ -eq "Update-TFRConnector/As2Config_MdnResponse")
        }
        {
            $v = "NONE","SYNC"
            break
        }

        # Amazon.Transfer.MdnSigningAlg
        {
            ($_ -eq "New-TFRConnector/As2Config_MdnSigningAlgorithm") -Or
            ($_ -eq "Update-TFRConnector/As2Config_MdnSigningAlgorithm")
        }
        {
            $v = "DEFAULT","NONE","SHA1","SHA256","SHA384","SHA512"
            break
        }

        # Amazon.Transfer.ProfileType
        {
            ($_ -eq "Get-TFRProfileList/ProfileType") -Or
            ($_ -eq "New-TFRProfile/ProfileType")
        }
        {
            $v = "LOCAL","PARTNER"
            break
        }

        # Amazon.Transfer.Protocol
        "Test-TFRIdentityProvider/ServerProtocol"
        {
            $v = "AS2","FTP","FTPS","SFTP"
            break
        }

        # Amazon.Transfer.SetStatOption
        {
            ($_ -eq "New-TFRServer/ProtocolDetails_SetStatOption") -Or
            ($_ -eq "Update-TFRServer/ProtocolDetails_SetStatOption")
        }
        {
            $v = "DEFAULT","ENABLE_NO_OP"
            break
        }

        # Amazon.Transfer.SigningAlg
        {
            ($_ -eq "New-TFRConnector/As2Config_SigningAlgorithm") -Or
            ($_ -eq "Update-TFRConnector/As2Config_SigningAlgorithm")
        }
        {
            $v = "NONE","SHA1","SHA256","SHA384","SHA512"
            break
        }

        # Amazon.Transfer.TlsSessionResumptionMode
        {
            ($_ -eq "New-TFRServer/ProtocolDetails_TlsSessionResumptionMode") -Or
            ($_ -eq "Update-TFRServer/ProtocolDetails_TlsSessionResumptionMode")
        }
        {
            $v = "DISABLED","ENABLED","ENFORCED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TFR_map = @{
    "As2Config_Compression"=@("New-TFRConnector","Update-TFRConnector")
    "As2Config_EncryptionAlgorithm"=@("New-TFRConnector","Update-TFRConnector")
    "As2Config_MdnResponse"=@("New-TFRConnector","Update-TFRConnector")
    "As2Config_MdnSigningAlgorithm"=@("New-TFRConnector","Update-TFRConnector")
    "As2Config_SigningAlgorithm"=@("New-TFRConnector","Update-TFRConnector")
    "Domain"=@("New-TFRServer")
    "EndpointType"=@("New-TFRServer","Update-TFRServer")
    "HomeDirectoryType"=@("New-TFRAccess","New-TFRUser","Update-TFRAccess","Update-TFRUser")
    "IdentityProviderType"=@("New-TFRServer")
    "ProfileType"=@("Get-TFRProfileList","New-TFRProfile")
    "ProtocolDetails_SetStatOption"=@("New-TFRServer","Update-TFRServer")
    "ProtocolDetails_TlsSessionResumptionMode"=@("New-TFRServer","Update-TFRServer")
    "ServerProtocol"=@("Test-TFRIdentityProvider")
    "Status"=@("New-TFRAgreement","Send-TFRWorkflowStepState","Update-TFRAgreement")
    "Usage"=@("Import-TFRCertificate")
}

_awsArgumentCompleterRegistration $TFR_Completers $TFR_map

$TFR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TFR.$($commandName.Replace('-', ''))Cmdlet]"
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

$TFR_SelectMap = @{
    "Select"=@("New-TFRAccess",
               "New-TFRAgreement",
               "New-TFRConnector",
               "New-TFRProfile",
               "New-TFRServer",
               "New-TFRUser",
               "New-TFRWorkflow",
               "Remove-TFRAccess",
               "Remove-TFRAgreement",
               "Remove-TFRCertificate",
               "Remove-TFRConnector",
               "Remove-TFRProfile",
               "Remove-TFRServer",
               "Remove-TFRSshPublicKey",
               "Remove-TFRUser",
               "Remove-TFRWorkflow",
               "Get-TFRAccess",
               "Get-TFRAgreement",
               "Get-TFRCertificate",
               "Get-TFRConnector",
               "Get-TFRExecution",
               "Get-TFRProfile",
               "Get-TFRSecurityPolicy",
               "Get-TFRServer",
               "Get-TFRUser",
               "Get-TFRWorkflow",
               "Import-TFRCertificate",
               "Import-TFRSshPublicKey",
               "Get-TFRAccessList",
               "Get-TFRAgreementList",
               "Get-TFRCertificateList",
               "Get-TFRConnectorList",
               "Get-TFRExecutionList",
               "Get-TFRProfileList",
               "Get-TFRSecurityPolicyList",
               "Get-TFRServerList",
               "Get-TFRResourceTagList",
               "Get-TFRUserList",
               "Get-TFRWorkflowList",
               "Send-TFRWorkflowStepState",
               "Start-TFRFileTransfer",
               "Start-TFRServer",
               "Stop-TFRServer",
               "Add-TFRResourceTag",
               "Test-TFRIdentityProvider",
               "Remove-TFRResourceTag",
               "Update-TFRAccess",
               "Update-TFRAgreement",
               "Update-TFRCertificate",
               "Update-TFRConnector",
               "Update-TFRProfile",
               "Update-TFRServer",
               "Update-TFRUser")
}

_awsArgumentCompleterRegistration $TFR_SelectCompleters $TFR_SelectMap

