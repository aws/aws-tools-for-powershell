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

# Argument completions for service Amazon FSx


$FSX_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.FSx.AutocommitPeriodType
        {
            ($_ -eq "New-FSXVolume/AutocommitPeriod_Type") -Or
            ($_ -eq "New-FSXVolumeFromBackup/AutocommitPeriod_Type") -Or
            ($_ -eq "Update-FSXVolume/AutocommitPeriod_Type")
        }
        {
            $v = "DAYS","HOURS","MINUTES","MONTHS","NONE","YEARS"
            break
        }

        # Amazon.FSx.DataRepositoryTaskType
        "New-FSXDataRepositoryTask/Type"
        {
            $v = "AUTO_RELEASE_DATA","EXPORT_TO_REPOSITORY","IMPORT_METADATA_FROM_REPOSITORY","RELEASE_DATA_FROM_FILESYSTEM"
            break
        }

        # Amazon.FSx.DiskIopsConfigurationMode
        {
            ($_ -eq "New-FSXFileSystemFromBackup/DiskIopsConfiguration_Mode") -Or
            ($_ -eq "New-FSXFileSystem/OntapConfiguration_DiskIopsConfiguration_Mode") -Or
            ($_ -eq "Update-FSXFileSystem/OntapConfiguration_DiskIopsConfiguration_Mode") -Or
            ($_ -eq "New-FSXFileSystem/OpenZFSConfiguration_DiskIopsConfiguration_Mode") -Or
            ($_ -eq "Update-FSXFileSystem/OpenZFSConfiguration_DiskIopsConfiguration_Mode")
        }
        {
            $v = "AUTOMATIC","USER_PROVISIONED"
            break
        }

        # Amazon.FSx.FileCacheLustreDeploymentType
        "New-FSXFileCache/LustreConfiguration_DeploymentType"
        {
            $v = "CACHE_1"
            break
        }

        # Amazon.FSx.FileCacheType
        "New-FSXFileCache/FileCacheType"
        {
            $v = "LUSTRE"
            break
        }

        # Amazon.FSx.FileSystemType
        "New-FSXFileSystem/FileSystemType"
        {
            $v = "LUSTRE","ONTAP","OPENZFS","WINDOWS"
            break
        }

        # Amazon.FSx.InputOntapVolumeType
        {
            ($_ -eq "New-FSXVolume/OntapConfiguration_OntapVolumeType") -Or
            ($_ -eq "New-FSXVolumeFromBackup/OntapConfiguration_OntapVolumeType")
        }
        {
            $v = "DP","RW"
            break
        }

        # Amazon.FSx.OntapDeploymentType
        "New-FSXFileSystem/OntapConfiguration_DeploymentType"
        {
            $v = "MULTI_AZ_1","MULTI_AZ_2","SINGLE_AZ_1","SINGLE_AZ_2"
            break
        }

        # Amazon.FSx.OpenZFSCopyStrategy
        {
            ($_ -eq "Copy-FSXSnapshotAndUpdateVolume/CopyStrategy") -Or
            ($_ -eq "New-FSXVolume/OriginSnapshot_CopyStrategy")
        }
        {
            $v = "CLONE","FULL_COPY","INCREMENTAL_COPY"
            break
        }

        # Amazon.FSx.OpenZFSDataCompressionType
        {
            ($_ -eq "New-FSXVolume/OpenZFSConfiguration_DataCompressionType") -Or
            ($_ -eq "Update-FSXVolume/OpenZFSConfiguration_DataCompressionType") -Or
            ($_ -eq "New-FSXFileSystem/RootVolumeConfiguration_DataCompressionType") -Or
            ($_ -eq "New-FSXFileSystemFromBackup/RootVolumeConfiguration_DataCompressionType")
        }
        {
            $v = "LZ4","NONE","ZSTD"
            break
        }

        # Amazon.FSx.OpenZFSDeploymentType
        {
            ($_ -eq "New-FSXFileSystem/OpenZFSConfiguration_DeploymentType") -Or
            ($_ -eq "New-FSXFileSystemFromBackup/OpenZFSConfiguration_DeploymentType")
        }
        {
            $v = "MULTI_AZ_1","SINGLE_AZ_1","SINGLE_AZ_2","SINGLE_AZ_HA_1","SINGLE_AZ_HA_2"
            break
        }

        # Amazon.FSx.OpenZFSFileSystemUserType
        "New-FSXAndAttachS3AccessPoint/FileSystemIdentity_Type"
        {
            $v = "POSIX"
            break
        }

        # Amazon.FSx.OpenZFSReadCacheSizingMode
        {
            ($_ -eq "New-FSXFileSystem/ReadCacheConfiguration_SizingMode") -Or
            ($_ -eq "New-FSXFileSystemFromBackup/ReadCacheConfiguration_SizingMode") -Or
            ($_ -eq "Update-FSXFileSystem/ReadCacheConfiguration_SizingMode")
        }
        {
            $v = "NO_CACHE","PROPORTIONAL_TO_THROUGHPUT_CAPACITY","USER_PROVISIONED"
            break
        }

        # Amazon.FSx.PrivilegedDelete
        {
            ($_ -eq "New-FSXVolume/SnaplockConfiguration_PrivilegedDelete") -Or
            ($_ -eq "New-FSXVolumeFromBackup/SnaplockConfiguration_PrivilegedDelete") -Or
            ($_ -eq "Update-FSXVolume/SnaplockConfiguration_PrivilegedDelete")
        }
        {
            $v = "DISABLED","ENABLED","PERMANENTLY_DISABLED"
            break
        }

        # Amazon.FSx.ReportFormat
        "New-FSXDataRepositoryTask/Report_Format"
        {
            $v = "REPORT_CSV_20191124"
            break
        }

        # Amazon.FSx.ReportScope
        "New-FSXDataRepositoryTask/Report_Scope"
        {
            $v = "FAILED_FILES_ONLY"
            break
        }

        # Amazon.FSx.RetentionPeriodType
        {
            ($_ -eq "New-FSXVolume/DefaultRetention_Type") -Or
            ($_ -eq "New-FSXVolumeFromBackup/DefaultRetention_Type") -Or
            ($_ -eq "Update-FSXVolume/DefaultRetention_Type") -Or
            ($_ -eq "New-FSXVolume/MaximumRetention_Type") -Or
            ($_ -eq "New-FSXVolumeFromBackup/MaximumRetention_Type") -Or
            ($_ -eq "Update-FSXVolume/MaximumRetention_Type") -Or
            ($_ -eq "New-FSXVolume/MinimumRetention_Type") -Or
            ($_ -eq "New-FSXVolumeFromBackup/MinimumRetention_Type") -Or
            ($_ -eq "Update-FSXVolume/MinimumRetention_Type")
        }
        {
            $v = "DAYS","HOURS","INFINITE","MINUTES","MONTHS","SECONDS","UNSPECIFIED","YEARS"
            break
        }

        # Amazon.FSx.S3AccessPointAttachmentType
        "New-FSXAndAttachS3AccessPoint/Type"
        {
            $v = "OPENZFS"
            break
        }

        # Amazon.FSx.SecurityStyle
        {
            ($_ -eq "New-FSXVolume/OntapConfiguration_SecurityStyle") -Or
            ($_ -eq "New-FSXVolumeFromBackup/OntapConfiguration_SecurityStyle") -Or
            ($_ -eq "Update-FSXVolume/OntapConfiguration_SecurityStyle")
        }
        {
            $v = "MIXED","NTFS","UNIX"
            break
        }

        # Amazon.FSx.SnaplockType
        {
            ($_ -eq "New-FSXVolume/SnaplockConfiguration_SnaplockType") -Or
            ($_ -eq "New-FSXVolumeFromBackup/SnaplockConfiguration_SnaplockType")
        }
        {
            $v = "COMPLIANCE","ENTERPRISE"
            break
        }

        # Amazon.FSx.StorageType
        {
            ($_ -eq "New-FSXFileSystem/StorageType") -Or
            ($_ -eq "New-FSXFileSystemFromBackup/StorageType") -Or
            ($_ -eq "Update-FSXFileSystem/StorageType")
        }
        {
            $v = "HDD","INTELLIGENT_TIERING","SSD"
            break
        }

        # Amazon.FSx.StorageVirtualMachineRootVolumeSecurityStyle
        "New-FSXStorageVirtualMachine/RootVolumeSecurityStyle"
        {
            $v = "MIXED","NTFS","UNIX"
            break
        }

        # Amazon.FSx.TieringPolicyName
        {
            ($_ -eq "New-FSXVolume/TieringPolicy_Name") -Or
            ($_ -eq "New-FSXVolumeFromBackup/TieringPolicy_Name") -Or
            ($_ -eq "Update-FSXVolume/TieringPolicy_Name")
        }
        {
            $v = "ALL","AUTO","NONE","SNAPSHOT_ONLY"
            break
        }

        # Amazon.FSx.Unit
        "New-FSXDataRepositoryTask/DurationSinceLastAccess_Unit"
        {
            $v = "DAYS"
            break
        }

        # Amazon.FSx.VolumeStyle
        {
            ($_ -eq "New-FSXVolume/OntapConfiguration_VolumeStyle") -Or
            ($_ -eq "New-FSXVolumeFromBackup/OntapConfiguration_VolumeStyle")
        }
        {
            $v = "FLEXGROUP","FLEXVOL"
            break
        }

        # Amazon.FSx.VolumeType
        "New-FSXVolume/VolumeType"
        {
            $v = "ONTAP","OPENZFS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$FSX_map = @{
    "AutocommitPeriod_Type"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "CopyStrategy"=@("Copy-FSXSnapshotAndUpdateVolume")
    "DefaultRetention_Type"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "DiskIopsConfiguration_Mode"=@("New-FSXFileSystemFromBackup")
    "DurationSinceLastAccess_Unit"=@("New-FSXDataRepositoryTask")
    "FileCacheType"=@("New-FSXFileCache")
    "FileSystemIdentity_Type"=@("New-FSXAndAttachS3AccessPoint")
    "FileSystemType"=@("New-FSXFileSystem")
    "LustreConfiguration_DeploymentType"=@("New-FSXFileCache")
    "MaximumRetention_Type"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "MinimumRetention_Type"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "OntapConfiguration_DeploymentType"=@("New-FSXFileSystem")
    "OntapConfiguration_DiskIopsConfiguration_Mode"=@("New-FSXFileSystem","Update-FSXFileSystem")
    "OntapConfiguration_OntapVolumeType"=@("New-FSXVolume","New-FSXVolumeFromBackup")
    "OntapConfiguration_SecurityStyle"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "OntapConfiguration_VolumeStyle"=@("New-FSXVolume","New-FSXVolumeFromBackup")
    "OpenZFSConfiguration_DataCompressionType"=@("New-FSXVolume","Update-FSXVolume")
    "OpenZFSConfiguration_DeploymentType"=@("New-FSXFileSystem","New-FSXFileSystemFromBackup")
    "OpenZFSConfiguration_DiskIopsConfiguration_Mode"=@("New-FSXFileSystem","Update-FSXFileSystem")
    "OriginSnapshot_CopyStrategy"=@("New-FSXVolume")
    "ReadCacheConfiguration_SizingMode"=@("New-FSXFileSystem","New-FSXFileSystemFromBackup","Update-FSXFileSystem")
    "Report_Format"=@("New-FSXDataRepositoryTask")
    "Report_Scope"=@("New-FSXDataRepositoryTask")
    "RootVolumeConfiguration_DataCompressionType"=@("New-FSXFileSystem","New-FSXFileSystemFromBackup")
    "RootVolumeSecurityStyle"=@("New-FSXStorageVirtualMachine")
    "SnaplockConfiguration_PrivilegedDelete"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "SnaplockConfiguration_SnaplockType"=@("New-FSXVolume","New-FSXVolumeFromBackup")
    "StorageType"=@("New-FSXFileSystem","New-FSXFileSystemFromBackup","Update-FSXFileSystem")
    "TieringPolicy_Name"=@("New-FSXVolume","New-FSXVolumeFromBackup","Update-FSXVolume")
    "Type"=@("New-FSXAndAttachS3AccessPoint","New-FSXDataRepositoryTask")
    "VolumeType"=@("New-FSXVolume")
}

_awsArgumentCompleterRegistration $FSX_Completers $FSX_map

$FSX_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.FSX.$($commandName.Replace('-', ''))Cmdlet]"
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

$FSX_SelectMap = @{
    "Select"=@("Register-FSXFileSystemAlias",
               "Stop-FSXDataRepositoryTask",
               "Copy-FSXBackup",
               "Copy-FSXSnapshotAndUpdateVolume",
               "New-FSXAndAttachS3AccessPoint",
               "New-FSXBackup",
               "New-FSXDataRepositoryAssociation",
               "New-FSXDataRepositoryTask",
               "New-FSXFileCache",
               "New-FSXFileSystem",
               "New-FSXFileSystemFromBackup",
               "New-FSXSnapshot",
               "New-FSXStorageVirtualMachine",
               "New-FSXVolume",
               "New-FSXVolumeFromBackup",
               "Remove-FSXBackup",
               "Remove-FSXDataRepositoryAssociation",
               "Remove-FSXFileCache",
               "Remove-FSXFileSystem",
               "Remove-FSXSnapshot",
               "Remove-FSXStorageVirtualMachine",
               "Remove-FSXVolume",
               "Get-FSXBackup",
               "Get-FSXDataRepositoryAssociation",
               "Get-FSXDataRepositoryTask",
               "Get-FSXFileCach",
               "Get-FSXFileSystemAlias",
               "Get-FSXFileSystem",
               "Get-FSXS3AccessPointAttachment",
               "Get-FSXSharedVpcConfiguration",
               "Get-FSXSnapshot",
               "Get-FSXStorageVirtualMachine",
               "Get-FSXVolume",
               "Dismount-FSXAndDeleteS3AccessPoint",
               "Unregister-FSXFileSystemAlias",
               "Get-FSXResourceTagList",
               "Clear-FSXFileSystemNfsV3Lock",
               "Restore-FSXVolumeFromSnapshot",
               "Start-FSXMisconfiguredStateRecovery",
               "Add-FSXResourceTag",
               "Remove-FSXResourceTag",
               "Update-FSXDataRepositoryAssociation",
               "Update-FSXFileCache",
               "Update-FSXFileSystem",
               "Update-FSXSharedVpcConfiguration",
               "Update-FSXSnapshot",
               "Update-FSXStorageVirtualMachine",
               "Update-FSXVolume")
}

_awsArgumentCompleterRegistration $FSX_SelectCompleters $FSX_SelectMap

