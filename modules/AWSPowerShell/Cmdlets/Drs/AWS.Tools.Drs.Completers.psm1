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

# Argument completions for service Elastic Disaster Recovery Service


$EDRS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Drs.LaunchDisposition
        {
            ($_ -eq "New-EDRSLaunchConfigurationTemplate/LaunchDisposition") -Or
            ($_ -eq "Update-EDRSLaunchConfiguration/LaunchDisposition") -Or
            ($_ -eq "Update-EDRSLaunchConfigurationTemplate/LaunchDisposition")
        }
        {
            $v = "STARTED","STOPPED"
            break
        }

        # Amazon.Drs.RecoverySnapshotsOrder
        "Get-EDRSRecoverySnapshot/Order"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Drs.ReplicationConfigurationDataPlaneRouting
        {
            ($_ -eq "New-EDRSReplicationConfigurationTemplate/DataPlaneRouting") -Or
            ($_ -eq "Update-EDRSReplicationConfiguration/DataPlaneRouting") -Or
            ($_ -eq "Update-EDRSReplicationConfigurationTemplate/DataPlaneRouting")
        }
        {
            $v = "PRIVATE_IP","PUBLIC_IP"
            break
        }

        # Amazon.Drs.ReplicationConfigurationDefaultLargeStagingDiskType
        {
            ($_ -eq "New-EDRSReplicationConfigurationTemplate/DefaultLargeStagingDiskType") -Or
            ($_ -eq "Update-EDRSReplicationConfiguration/DefaultLargeStagingDiskType") -Or
            ($_ -eq "Update-EDRSReplicationConfigurationTemplate/DefaultLargeStagingDiskType")
        }
        {
            $v = "AUTO","GP2","GP3","ST1"
            break
        }

        # Amazon.Drs.ReplicationConfigurationEbsEncryption
        {
            ($_ -eq "New-EDRSReplicationConfigurationTemplate/EbsEncryption") -Or
            ($_ -eq "Update-EDRSReplicationConfiguration/EbsEncryption") -Or
            ($_ -eq "Update-EDRSReplicationConfigurationTemplate/EbsEncryption")
        }
        {
            $v = "CUSTOM","DEFAULT"
            break
        }

        # Amazon.Drs.TargetInstanceTypeRightSizingMethod
        {
            ($_ -eq "New-EDRSLaunchConfigurationTemplate/TargetInstanceTypeRightSizingMethod") -Or
            ($_ -eq "Update-EDRSLaunchConfiguration/TargetInstanceTypeRightSizingMethod") -Or
            ($_ -eq "Update-EDRSLaunchConfigurationTemplate/TargetInstanceTypeRightSizingMethod")
        }
        {
            $v = "BASIC","NONE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EDRS_map = @{
    "DataPlaneRouting"=@("New-EDRSReplicationConfigurationTemplate","Update-EDRSReplicationConfiguration","Update-EDRSReplicationConfigurationTemplate")
    "DefaultLargeStagingDiskType"=@("New-EDRSReplicationConfigurationTemplate","Update-EDRSReplicationConfiguration","Update-EDRSReplicationConfigurationTemplate")
    "EbsEncryption"=@("New-EDRSReplicationConfigurationTemplate","Update-EDRSReplicationConfiguration","Update-EDRSReplicationConfigurationTemplate")
    "LaunchDisposition"=@("New-EDRSLaunchConfigurationTemplate","Update-EDRSLaunchConfiguration","Update-EDRSLaunchConfigurationTemplate")
    "Order"=@("Get-EDRSRecoverySnapshot")
    "TargetInstanceTypeRightSizingMethod"=@("New-EDRSLaunchConfigurationTemplate","Update-EDRSLaunchConfiguration","Update-EDRSLaunchConfigurationTemplate")
}

_awsArgumentCompleterRegistration $EDRS_Completers $EDRS_map

$EDRS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EDRS.$($commandName.Replace('-', ''))Cmdlet]"
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

$EDRS_SelectMap = @{
    "Select"=@("New-EDRSExtendedSourceServer",
               "New-EDRSLaunchConfigurationTemplate",
               "New-EDRSReplicationConfigurationTemplate",
               "Remove-EDRSJob",
               "Remove-EDRSLaunchConfigurationTemplate",
               "Remove-EDRSRecoveryInstance",
               "Remove-EDRSReplicationConfigurationTemplate",
               "Remove-EDRSSourceServer",
               "Get-EDRSJobLogItem",
               "Get-EDRSJob",
               "Get-EDRSLaunchConfigurationTemplate",
               "Get-EDRSRecoveryInstance",
               "Get-EDRSRecoverySnapshot",
               "Get-EDRSReplicationConfigurationTemplate",
               "Get-EDRSSourceServer",
               "Disconnect-EDRSRecoveryInstance",
               "Disconnect-EDRSSourceServer",
               "Get-EDRSFailbackReplicationConfiguration",
               "Get-EDRSLaunchConfiguration",
               "Get-EDRSReplicationConfiguration",
               "Initialize-EDRSService",
               "Get-EDRSExtensibleSourceServerList",
               "Get-EDRSStagingAccountList",
               "Get-EDRSResourceTag",
               "Restart-EDRSDataReplication",
               "Start-EDRSReversedReplication",
               "Start-EDRSFailbackLaunch",
               "Start-EDRSRecovery",
               "Start-EDRSReplication",
               "Stop-EDRSFailback",
               "Stop-EDRSReplication",
               "Add-EDRSResourceTag",
               "Stop-EDRSRecoveryInstance",
               "Remove-EDRSResourceTag",
               "Update-EDRSFailbackReplicationConfiguration",
               "Update-EDRSLaunchConfiguration",
               "Update-EDRSLaunchConfigurationTemplate",
               "Update-EDRSReplicationConfiguration",
               "Update-EDRSReplicationConfigurationTemplate")
}

_awsArgumentCompleterRegistration $EDRS_SelectCompleters $EDRS_SelectMap

