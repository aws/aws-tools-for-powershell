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

# Argument completions for service Application Migration Service


$MGN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Mgn.ChangeServerLifeCycleStateSourceServerLifecycleState
        "Set-MGNServerLifeCycleState/LifeCycle_State"
        {
            $v = "CUTOVER","READY_FOR_CUTOVER","READY_FOR_TEST"
            break
        }

        # Amazon.Mgn.LaunchDisposition
        "Update-MGNLaunchConfiguration/LaunchDisposition"
        {
            $v = "STARTED","STOPPED"
            break
        }

        # Amazon.Mgn.ReplicationConfigurationDataPlaneRouting
        {
            ($_ -eq "New-MGNReplicationConfigurationTemplate/DataPlaneRouting") -Or
            ($_ -eq "Update-MGNReplicationConfiguration/DataPlaneRouting") -Or
            ($_ -eq "Update-MGNReplicationConfigurationTemplate/DataPlaneRouting")
        }
        {
            $v = "PRIVATE_IP","PUBLIC_IP"
            break
        }

        # Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType
        {
            ($_ -eq "New-MGNReplicationConfigurationTemplate/DefaultLargeStagingDiskType") -Or
            ($_ -eq "Update-MGNReplicationConfiguration/DefaultLargeStagingDiskType") -Or
            ($_ -eq "Update-MGNReplicationConfigurationTemplate/DefaultLargeStagingDiskType")
        }
        {
            $v = "GP2","ST1"
            break
        }

        # Amazon.Mgn.ReplicationConfigurationEbsEncryption
        {
            ($_ -eq "New-MGNReplicationConfigurationTemplate/EbsEncryption") -Or
            ($_ -eq "Update-MGNReplicationConfiguration/EbsEncryption") -Or
            ($_ -eq "Update-MGNReplicationConfigurationTemplate/EbsEncryption")
        }
        {
            $v = "CUSTOM","DEFAULT","NONE"
            break
        }

        # Amazon.Mgn.TargetInstanceTypeRightSizingMethod
        "Update-MGNLaunchConfiguration/TargetInstanceTypeRightSizingMethod"
        {
            $v = "BASIC","NONE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MGN_map = @{
    "DataPlaneRouting"=@("New-MGNReplicationConfigurationTemplate","Update-MGNReplicationConfiguration","Update-MGNReplicationConfigurationTemplate")
    "DefaultLargeStagingDiskType"=@("New-MGNReplicationConfigurationTemplate","Update-MGNReplicationConfiguration","Update-MGNReplicationConfigurationTemplate")
    "EbsEncryption"=@("New-MGNReplicationConfigurationTemplate","Update-MGNReplicationConfiguration","Update-MGNReplicationConfigurationTemplate")
    "LaunchDisposition"=@("Update-MGNLaunchConfiguration")
    "LifeCycle_State"=@("Set-MGNServerLifeCycleState")
    "TargetInstanceTypeRightSizingMethod"=@("Update-MGNLaunchConfiguration")
}

_awsArgumentCompleterRegistration $MGN_Completers $MGN_map

$MGN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MGN.$($commandName.Replace('-', ''))Cmdlet]"
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

$MGN_SelectMap = @{
    "Select"=@("Set-MGNServerLifeCycleState",
               "New-MGNReplicationConfigurationTemplate",
               "Remove-MGNJob",
               "Remove-MGNReplicationConfigurationTemplate",
               "Remove-MGNSourceServer",
               "Get-MGNJobLogItem",
               "Get-MGNJob",
               "Get-MGNReplicationConfigurationTemplate",
               "Get-MGNSourceServer",
               "Disconnect-MGNFromService",
               "Complete-MGNCutover",
               "Get-MGNLaunchConfiguration",
               "Get-MGNReplicationConfiguration",
               "Initialize-MGNService",
               "Get-MGNResourceTag",
               "Set-MGNAsArchived",
               "Resume-MGNDataReplication",
               "Start-MGNCutover",
               "Start-MGNTest",
               "Add-MGNResourceTag",
               "Remove-MGNTargetInstance",
               "Remove-MGNResourceTag",
               "Update-MGNLaunchConfiguration",
               "Update-MGNReplicationConfiguration",
               "Update-MGNReplicationConfigurationTemplate")
}

_awsArgumentCompleterRegistration $MGN_SelectCompleters $MGN_SelectMap

