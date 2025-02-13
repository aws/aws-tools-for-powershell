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

# Argument completions for service AWS Storage Gateway


$SG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.StorageGateway.AutomaticUpdatePolicy
        "Update-SGMaintenanceStartTime/SoftwareUpdatePreferences_AutomaticUpdatePolicy"
        {
            $v = "ALL_VERSIONS","EMERGENCY_VERSIONS_ONLY"
            break
        }

        # Amazon.StorageGateway.CaseSensitivity
        {
            ($_ -eq "New-SGSMBFileShare/CaseSensitivity") -Or
            ($_ -eq "Update-SGSMBFileShare/CaseSensitivity")
        }
        {
            $v = "CaseSensitive","ClientSpecified"
            break
        }

        # Amazon.StorageGateway.EncryptionType
        {
            ($_ -eq "New-SGNFSFileShare/EncryptionType") -Or
            ($_ -eq "New-SGSMBFileShare/EncryptionType") -Or
            ($_ -eq "Update-SGNFSFileShare/EncryptionType") -Or
            ($_ -eq "Update-SGSMBFileShare/EncryptionType")
        }
        {
            $v = "DsseKms","SseKms","SseS3"
            break
        }

        # Amazon.StorageGateway.GatewayCapacity
        "Update-SGGatewayInformation/GatewayCapacity"
        {
            $v = "Large","Medium","Small"
            break
        }

        # Amazon.StorageGateway.ObjectACL
        {
            ($_ -eq "New-SGNFSFileShare/ObjectACL") -Or
            ($_ -eq "New-SGSMBFileShare/ObjectACL") -Or
            ($_ -eq "Update-SGNFSFileShare/ObjectACL") -Or
            ($_ -eq "Update-SGSMBFileShare/ObjectACL")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","private","public-read","public-read-write"
            break
        }

        # Amazon.StorageGateway.RetentionLockType
        "New-SGTapePool/RetentionLockType"
        {
            $v = "COMPLIANCE","GOVERNANCE","NONE"
            break
        }

        # Amazon.StorageGateway.SMBSecurityStrategy
        "Update-SGSMBSecurityStrategy/SMBSecurityStrategy"
        {
            $v = "ClientSpecified","MandatoryEncryption","MandatoryEncryptionNoAes128","MandatorySigning"
            break
        }

        # Amazon.StorageGateway.TapeStorageClass
        "New-SGTapePool/StorageClass"
        {
            $v = "DEEP_ARCHIVE","GLACIER"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SG_map = @{
    "CaseSensitivity"=@("New-SGSMBFileShare","Update-SGSMBFileShare")
    "EncryptionType"=@("New-SGNFSFileShare","New-SGSMBFileShare","Update-SGNFSFileShare","Update-SGSMBFileShare")
    "GatewayCapacity"=@("Update-SGGatewayInformation")
    "ObjectACL"=@("New-SGNFSFileShare","New-SGSMBFileShare","Update-SGNFSFileShare","Update-SGSMBFileShare")
    "RetentionLockType"=@("New-SGTapePool")
    "SMBSecurityStrategy"=@("Update-SGSMBSecurityStrategy")
    "SoftwareUpdatePreferences_AutomaticUpdatePolicy"=@("Update-SGMaintenanceStartTime")
    "StorageClass"=@("New-SGTapePool")
}

_awsArgumentCompleterRegistration $SG_Completers $SG_map

$SG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SG.$($commandName.Replace('-', ''))Cmdlet]"
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

$SG_SelectMap = @{
    "Select"=@("Enable-SGGateway",
               "Add-SGCache",
               "Add-SGResourceTag",
               "Add-SGUploadBuffer",
               "Add-SGWorkingStorage",
               "Add-SGTapeToTapePool",
               "New-SGSGFileSystemAssociation",
               "Mount-SGVolume",
               "Stop-SGArchival",
               "Stop-SGCacheReport",
               "Stop-SGRetrieval",
               "New-SGCachediSCSIVolume",
               "New-SGNFSFileShare",
               "New-SGSMBFileShare",
               "New-SGSnapshot",
               "New-SGSnapshotFromVolumeRecoveryPoint",
               "New-SGStorediSCSIVolume",
               "New-SGTapePool",
               "New-SGTape",
               "New-SGTapeWithBarcode",
               "Remove-SGAutomaticTapeCreationPolicy",
               "Remove-SGBandwidthRateLimit",
               "Remove-SGCacheReport",
               "Remove-SGChapCredential",
               "Remove-SGFileShare",
               "Remove-SGGateway",
               "Remove-SGSnapshotSchedule",
               "Remove-SGTape",
               "Remove-SGTapeArchive",
               "Remove-SGTapePool",
               "Remove-SGVolume",
               "Get-SGAvailabilityMonitorTest",
               "Get-SGBandwidthRateLimit",
               "Get-SGBandwidthRateLimitSchedule",
               "Get-SGCache",
               "Get-SGCachediSCSIVolume",
               "Get-SGCacheReport",
               "Get-SGChapCredential",
               "Get-SGSGFileSystemAssociation",
               "Get-SGGatewayInformation",
               "Get-SGMaintenanceStartTime",
               "Get-SGNFSFileShareList",
               "Get-SGSMBFileShare",
               "Get-SGSMBSetting",
               "Get-SGSnapshotSchedule",
               "Get-SGStorediSCSIVolume",
               "Get-SGTapeArchiveList",
               "Get-SGTapeRecoveryPointList",
               "Get-SGTapeList",
               "Get-SGUploadBuffer",
               "Get-SGVTLDevice",
               "Get-SGWorkingStorage",
               "Dismount-SGVolume",
               "Disable-SGGateway",
               "Remove-SGSGFileSystemAssociation",
               "Join-SGDomain",
               "Get-SGAutomaticTapeCreationPolicy",
               "Get-SGCacheReportList",
               "Get-SGFileShareList",
               "Get-SGSGFileSystemAssociationList",
               "Get-SGGateway",
               "Get-SGLocalDisk",
               "Get-SGResourceTag",
               "Get-SGTapePool",
               "Get-SGTape",
               "Get-SGVolumeInitiatorList",
               "Get-SGVolumeRecoveryPoint",
               "Get-SGVolume",
               "Send-SGUploadedNotification",
               "Invoke-SGCacheRefresh",
               "Remove-SGResourceTag",
               "Reset-SGCache",
               "Get-SGTapeArchive",
               "Get-SGTapeRecoveryPoint",
               "Set-SGLocalConsolePassword",
               "Set-SGSMBGuestPassword",
               "Stop-SGGateway",
               "Start-SGAvailabilityMonitorTest",
               "Start-SGCacheReport",
               "Start-SGGateway",
               "Update-SGAutomaticTapeCreationPolicy",
               "Update-SGBandwidthRateLimit",
               "Update-SGBandwidthRateLimitSchedule",
               "Update-SGChapCredential",
               "Update-SGSGFileSystemAssociation",
               "Update-SGGatewayInformation",
               "Update-SGGatewaySoftwareNow",
               "Update-SGMaintenanceStartTime",
               "Update-SGNFSFileShare",
               "Update-SGSMBFileShare",
               "Update-SGSMBFileShareVisibility",
               "Update-SGSGSMBLocalGroup",
               "Update-SGSMBSecurityStrategy",
               "Update-SGSnapshotSchedule",
               "Update-SGVTLDeviceType")
}

_awsArgumentCompleterRegistration $SG_SelectCompleters $SG_SelectMap

