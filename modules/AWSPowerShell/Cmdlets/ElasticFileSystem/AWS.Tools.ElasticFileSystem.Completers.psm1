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

# Argument completions for service Amazon Elastic File System


$EFS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticFileSystem.DeletionMode
        "Remove-EFSReplicationConfiguration/DeletionMode"
        {
            $v = "ALL_CONFIGURATIONS","LOCAL_CONFIGURATION_ONLY"
            break
        }

        # Amazon.ElasticFileSystem.IpAddressType
        "New-EFSMountTarget/IpAddressType"
        {
            $v = "DUAL_STACK","IPV4_ONLY","IPV6_ONLY"
            break
        }

        # Amazon.ElasticFileSystem.PerformanceMode
        "New-EFSFileSystem/PerformanceMode"
        {
            $v = "generalPurpose","maxIO"
            break
        }

        # Amazon.ElasticFileSystem.ReplicationOverwriteProtection
        "Update-EFSFileSystemProtection/ReplicationOverwriteProtection"
        {
            $v = "DISABLED","ENABLED","REPLICATING"
            break
        }

        # Amazon.ElasticFileSystem.ResourceIdType
        "Write-EFSAccountPreference/ResourceIdType"
        {
            $v = "LONG_ID","SHORT_ID"
            break
        }

        # Amazon.ElasticFileSystem.Status
        "Write-EFSBackupPolicy/BackupPolicy_Status"
        {
            $v = "DISABLED","DISABLING","ENABLED","ENABLING"
            break
        }

        # Amazon.ElasticFileSystem.ThroughputMode
        {
            ($_ -eq "New-EFSFileSystem/ThroughputMode") -Or
            ($_ -eq "Update-EFSFileSystem/ThroughputMode")
        }
        {
            $v = "bursting","elastic","provisioned"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EFS_map = @{
    "BackupPolicy_Status"=@("Write-EFSBackupPolicy")
    "DeletionMode"=@("Remove-EFSReplicationConfiguration")
    "IpAddressType"=@("New-EFSMountTarget")
    "PerformanceMode"=@("New-EFSFileSystem")
    "ReplicationOverwriteProtection"=@("Update-EFSFileSystemProtection")
    "ResourceIdType"=@("Write-EFSAccountPreference")
    "ThroughputMode"=@("New-EFSFileSystem","Update-EFSFileSystem")
}

_awsArgumentCompleterRegistration $EFS_Completers $EFS_map

$EFS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EFS.$($commandName.Replace('-', ''))Cmdlet]"
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

$EFS_SelectMap = @{
    "Select"=@("New-EFSAccessPoint",
               "New-EFSFileSystem",
               "New-EFSMountTarget",
               "New-EFSReplicationConfiguration",
               "New-EFSTag",
               "Remove-EFSAccessPoint",
               "Remove-EFSFileSystem",
               "Remove-EFSFileSystemPolicy",
               "Remove-EFSMountTarget",
               "Remove-EFSReplicationConfiguration",
               "Remove-EFSTag",
               "Get-EFSAccessPoint",
               "Get-EFSAccountPreference",
               "Get-EFSBackupPolicy",
               "Get-EFSFileSystemPolicy",
               "Get-EFSFileSystem",
               "Get-EFSLifecycleConfiguration",
               "Get-EFSMountTarget",
               "Get-EFSMountTargetSecurityGroup",
               "Get-EFSReplicationConfiguration",
               "Get-EFSTag",
               "Get-EFSResourceTag",
               "Edit-EFSMountTargetSecurityGroup",
               "Write-EFSAccountPreference",
               "Write-EFSBackupPolicy",
               "Write-EFSFileSystemPolicy",
               "Write-EFSLifecycleConfiguration",
               "Add-EFSResourceTag",
               "Remove-EFSResourceTag",
               "Update-EFSFileSystem",
               "Update-EFSFileSystemProtection")
}

_awsArgumentCompleterRegistration $EFS_SelectCompleters $EFS_SelectMap

