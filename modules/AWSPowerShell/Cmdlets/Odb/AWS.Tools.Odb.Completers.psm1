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

# Argument completions for service Oracle Database@Amazon Web Services


$ODB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Odb.Access
        {
            ($_ -eq "New-ODBOdbNetwork/KmsAccess") -Or
            ($_ -eq "Update-ODBOdbNetwork/KmsAccess") -Or
            ($_ -eq "New-ODBOdbNetwork/S3Access") -Or
            ($_ -eq "Update-ODBOdbNetwork/S3Access") -Or
            ($_ -eq "New-ODBOdbNetwork/StsAccess") -Or
            ($_ -eq "Update-ODBOdbNetwork/StsAccess") -Or
            ($_ -eq "New-ODBOdbNetwork/ZeroEtlAccess") -Or
            ($_ -eq "Update-ODBOdbNetwork/ZeroEtlAccess")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Odb.AutonomousDatabaseBackupStatus
        "Get-ODBAutonomousDatabaseBackupList/Status"
        {
            $v = "ACTIVE","CREATING","DELETING","FAILED","UPDATING"
            break
        }

        # Amazon.Odb.AutonomousDatabaseBackupType
        "Get-ODBAutonomousDatabaseBackupList/Type"
        {
            $v = "CUMULATIVE_INCREMENTAL","FULL","INCREMENTAL","LONGTERM","ROLL_FORWARD_IMAGE_COPY","VIRTUAL_FULL"
            break
        }

        # Amazon.Odb.AutonomousMaintenanceScheduleType
        {
            ($_ -eq "New-ODBAutonomousDatabase/AutonomousMaintenanceScheduleType") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/AutonomousMaintenanceScheduleType")
        }
        {
            $v = "EARLY","REGULAR"
            break
        }

        # Amazon.Odb.CharacterSetType
        "Get-ODBAutonomousDatabaseCharacterSetList/CharacterSetType"
        {
            $v = "DATABASE","NATIONAL"
            break
        }

        # Amazon.Odb.CloneType
        {
            ($_ -eq "New-ODBAutonomousDatabase/SourceConfiguration_CloneToRefreshable_CloneType") -Or
            ($_ -eq "New-ODBAutonomousDatabase/SourceConfiguration_DatabaseClone_CloneType") -Or
            ($_ -eq "New-ODBAutonomousDatabase/SourceConfiguration_PointInTimeRestore_CloneType") -Or
            ($_ -eq "New-ODBAutonomousDatabase/SourceConfiguration_RestoreFromBackup_CloneType")
        }
        {
            $v = "FULL","METADATA","PARTIAL"
            break
        }

        # Amazon.Odb.DatabaseEdition
        {
            ($_ -eq "New-ODBAutonomousDatabase/DatabaseEdition") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/DatabaseEdition")
        }
        {
            $v = "ENTERPRISE_EDITION","STANDARD_EDITION"
            break
        }

        # Amazon.Odb.DbWorkload
        {
            ($_ -eq "Get-ODBAutonomousDatabaseVersionList/DbWorkload") -Or
            ($_ -eq "New-ODBAutonomousDatabase/DbWorkload") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/DbWorkload")
        }
        {
            $v = "AJD","APEX","LH","OLTP"
            break
        }

        # Amazon.Odb.DisasterRecoveryType
        "New-ODBAutonomousDatabase/SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType"
        {
            $v = "ADG","BACKUP_BASED"
            break
        }

        # Amazon.Odb.EncryptionKeyProviderInput
        {
            ($_ -eq "New-ODBAutonomousDatabase/EncryptionKeyProvider") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/EncryptionKeyProvider")
        }
        {
            $v = "AWS_KMS","ORACLE_MANAGED"
            break
        }

        # Amazon.Odb.ExternalIdType
        {
            ($_ -eq "New-ODBAutonomousDatabase/EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType")
        }
        {
            $v = "compartment_ocid","database_ocid","tenant_ocid"
            break
        }

        # Amazon.Odb.LicenseModel
        {
            ($_ -eq "New-ODBAutonomousDatabase/LicenseModel") -Or
            ($_ -eq "New-ODBCloudAutonomousVmCluster/LicenseModel") -Or
            ($_ -eq "New-ODBCloudVmCluster/LicenseModel") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/LicenseModel")
        }
        {
            $v = "BRING_YOUR_OWN_LICENSE","LICENSE_INCLUDED"
            break
        }

        # Amazon.Odb.OpenMode
        {
            ($_ -eq "Update-ODBAutonomousDatabase/OpenMode") -Or
            ($_ -eq "New-ODBAutonomousDatabase/SourceConfiguration_CloneToRefreshable_OpenMode")
        }
        {
            $v = "READ_ONLY","READ_WRITE"
            break
        }

        # Amazon.Odb.PatchingModeType
        {
            ($_ -eq "New-ODBCloudAutonomousVmCluster/MaintenanceWindow_PatchingMode") -Or
            ($_ -eq "New-ODBCloudExadataInfrastructure/MaintenanceWindow_PatchingMode") -Or
            ($_ -eq "Update-ODBCloudExadataInfrastructure/MaintenanceWindow_PatchingMode")
        }
        {
            $v = "NONROLLING","ROLLING"
            break
        }

        # Amazon.Odb.PermissionLevel
        "Update-ODBAutonomousDatabase/PermissionLevel"
        {
            $v = "RESTRICTED","UNRESTRICTED"
            break
        }

        # Amazon.Odb.PreferenceType
        {
            ($_ -eq "New-ODBCloudAutonomousVmCluster/MaintenanceWindow_Preference") -Or
            ($_ -eq "New-ODBCloudExadataInfrastructure/MaintenanceWindow_Preference") -Or
            ($_ -eq "Update-ODBCloudExadataInfrastructure/MaintenanceWindow_Preference")
        }
        {
            $v = "CUSTOM_PREFERENCE","NO_PREFERENCE"
            break
        }

        # Amazon.Odb.RefreshableMode
        {
            ($_ -eq "Update-ODBAutonomousDatabase/RefreshableMode") -Or
            ($_ -eq "New-ODBAutonomousDatabase/SourceConfiguration_CloneToRefreshable_RefreshableMode")
        }
        {
            $v = "AUTOMATIC","MANUAL"
            break
        }

        # Amazon.Odb.RepeatCadence
        "Update-ODBAutonomousDatabase/LongTermBackupSchedule_RepeatCadence"
        {
            $v = "MONTHLY","ONE_TIME","WEEKLY","YEARLY"
            break
        }

        # Amazon.Odb.SourceType
        "New-ODBAutonomousDatabase/Source"
        {
            $v = "BACKUP_FROM_ID","BACKUP_FROM_TIMESTAMP","CLONE_TO_REFRESHABLE","CROSS_REGION_DATAGUARD","CROSS_REGION_DISASTER_RECOVERY","DATABASE","NONE"
            break
        }

        # Amazon.Odb.StandbyAllowlistedIpsSource
        {
            ($_ -eq "New-ODBAutonomousDatabase/StandbyAllowlistedIpsSource") -Or
            ($_ -eq "Update-ODBAutonomousDatabase/StandbyAllowlistedIpsSource")
        }
        {
            $v = "NOT_APPLICABLE","PRIMARY","SEPARATE"
            break
        }

        # Amazon.Odb.SupportedAwsIntegration
        {
            ($_ -eq "Add-ODBIamRoleToResource/AwsIntegration") -Or
            ($_ -eq "Remove-ODBIamRoleFromResource/AwsIntegration")
        }
        {
            $v = "KmsTde"
            break
        }

        # Amazon.Odb.WalletType
        "New-ODBAutonomousDatabaseWallet/WalletType"
        {
            $v = "INSTANCE","REGIONAL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ODB_map = @{
    "AutonomousMaintenanceScheduleType"=@("New-ODBAutonomousDatabase","Update-ODBAutonomousDatabase")
    "AwsIntegration"=@("Add-ODBIamRoleToResource","Remove-ODBIamRoleFromResource")
    "CharacterSetType"=@("Get-ODBAutonomousDatabaseCharacterSetList")
    "DatabaseEdition"=@("New-ODBAutonomousDatabase","Update-ODBAutonomousDatabase")
    "DbWorkload"=@("Get-ODBAutonomousDatabaseVersionList","New-ODBAutonomousDatabase","Update-ODBAutonomousDatabase")
    "EncryptionKeyConfiguration_AwsEncryptionKey_ExternalIdType"=@("New-ODBAutonomousDatabase","Update-ODBAutonomousDatabase")
    "EncryptionKeyProvider"=@("New-ODBAutonomousDatabase","Update-ODBAutonomousDatabase")
    "KmsAccess"=@("New-ODBOdbNetwork","Update-ODBOdbNetwork")
    "LicenseModel"=@("New-ODBAutonomousDatabase","New-ODBCloudAutonomousVmCluster","New-ODBCloudVmCluster","Update-ODBAutonomousDatabase")
    "LongTermBackupSchedule_RepeatCadence"=@("Update-ODBAutonomousDatabase")
    "MaintenanceWindow_PatchingMode"=@("New-ODBCloudAutonomousVmCluster","New-ODBCloudExadataInfrastructure","Update-ODBCloudExadataInfrastructure")
    "MaintenanceWindow_Preference"=@("New-ODBCloudAutonomousVmCluster","New-ODBCloudExadataInfrastructure","Update-ODBCloudExadataInfrastructure")
    "OpenMode"=@("Update-ODBAutonomousDatabase")
    "PermissionLevel"=@("Update-ODBAutonomousDatabase")
    "RefreshableMode"=@("Update-ODBAutonomousDatabase")
    "S3Access"=@("New-ODBOdbNetwork","Update-ODBOdbNetwork")
    "Source"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_CloneToRefreshable_CloneType"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_CloneToRefreshable_OpenMode"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_CloneToRefreshable_RefreshableMode"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_CrossRegionDisasterRecovery_RemoteDisasterRecoveryType"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_DatabaseClone_CloneType"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_PointInTimeRestore_CloneType"=@("New-ODBAutonomousDatabase")
    "SourceConfiguration_RestoreFromBackup_CloneType"=@("New-ODBAutonomousDatabase")
    "StandbyAllowlistedIpsSource"=@("New-ODBAutonomousDatabase","Update-ODBAutonomousDatabase")
    "Status"=@("Get-ODBAutonomousDatabaseBackupList")
    "StsAccess"=@("New-ODBOdbNetwork","Update-ODBOdbNetwork")
    "Type"=@("Get-ODBAutonomousDatabaseBackupList")
    "WalletType"=@("New-ODBAutonomousDatabaseWallet")
    "ZeroEtlAccess"=@("New-ODBOdbNetwork","Update-ODBOdbNetwork")
}

_awsArgumentCompleterRegistration $ODB_Completers $ODB_map

$ODB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ODB.$($commandName.Replace('-', ''))Cmdlet]"
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

$ODB_SelectMap = @{
    "Select"=@("Approve-ODBMarketplaceRegistration",
               "Add-ODBIamRoleToResource",
               "New-ODBAutonomousDatabase",
               "New-ODBAutonomousDatabaseBackup",
               "New-ODBAutonomousDatabaseWallet",
               "New-ODBCloudAutonomousVmCluster",
               "New-ODBCloudExadataInfrastructure",
               "New-ODBCloudVmCluster",
               "New-ODBOdbNetwork",
               "New-ODBOdbPeeringConnection",
               "Remove-ODBAutonomousDatabase",
               "Remove-ODBAutonomousDatabaseBackup",
               "Remove-ODBCloudAutonomousVmCluster",
               "Remove-ODBCloudExadataInfrastructure",
               "Remove-ODBCloudVmCluster",
               "Remove-ODBOdbNetwork",
               "Remove-ODBOdbPeeringConnection",
               "Remove-ODBIamRoleFromResource",
               "Start-ODBAutonomousDatabaseFailover",
               "Get-ODBAutonomousDatabase",
               "Get-ODBAutonomousDatabaseBackup",
               "Get-ODBAutonomousDatabaseWalletDetail",
               "Get-ODBCloudAutonomousVmCluster",
               "Get-ODBCloudExadataInfrastructure",
               "Get-ODBCloudExadataInfrastructureUnallocatedResource",
               "Get-ODBCloudVmCluster",
               "Get-ODBDbNode",
               "Get-ODBDbServer",
               "Get-ODBOciOnboardingStatus",
               "Get-ODBOdbNetwork",
               "Get-ODBOdbPeeringConnection",
               "Initialize-ODBService",
               "Get-ODBAutonomousDatabaseBackupList",
               "Get-ODBAutonomousDatabaseCharacterSetList",
               "Get-ODBAutonomousDatabaseCloneList",
               "Get-ODBAutonomousDatabasePeerList",
               "Get-ODBAutonomousDatabaseList",
               "Get-ODBAutonomousDatabaseVersionList",
               "Get-ODBAutonomousVirtualMachineList",
               "Get-ODBCloudAutonomousVmClusterList",
               "Get-ODBCloudExadataInfrastructureList",
               "Get-ODBCloudVmClusterList",
               "Get-ODBDbNodeList",
               "Get-ODBDbServerList",
               "Get-ODBDbSystemShapeList",
               "Get-ODBGiVersionList",
               "Get-ODBOdbNetworkList",
               "Get-ODBOdbPeeringConnectionList",
               "Get-ODBSystemVersionList",
               "Get-ODBResourceTag",
               "Restart-ODBAutonomousDatabase",
               "Restart-ODBDbNode",
               "Restore-ODBAutonomousDatabase",
               "Invoke-ODBAutonomousDatabaseShrink",
               "Start-ODBAutonomousDatabase",
               "Start-ODBDbNode",
               "Stop-ODBAutonomousDatabase",
               "Stop-ODBDbNode",
               "Start-ODBAutonomousDatabaseSwitchover",
               "Add-ODBResourceTag",
               "Remove-ODBResourceTag",
               "Update-ODBAutonomousDatabase",
               "Update-ODBAutonomousDatabaseBackup",
               "Update-ODBCloudExadataInfrastructure",
               "Update-ODBOdbNetwork",
               "Update-ODBOdbPeeringConnection")
}

_awsArgumentCompleterRegistration $ODB_SelectCompleters $ODB_SelectMap

