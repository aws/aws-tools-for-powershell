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
            ($_ -eq "New-ODBOdbNetwork/S3Access") -Or
            ($_ -eq "Update-ODBOdbNetwork/S3Access") -Or
            ($_ -eq "New-ODBOdbNetwork/ZeroEtlAccess") -Or
            ($_ -eq "Update-ODBOdbNetwork/ZeroEtlAccess")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Odb.LicenseModel
        {
            ($_ -eq "New-ODBCloudAutonomousVmCluster/LicenseModel") -Or
            ($_ -eq "New-ODBCloudVmCluster/LicenseModel")
        }
        {
            $v = "BRING_YOUR_OWN_LICENSE","LICENSE_INCLUDED"
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


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ODB_map = @{
    "LicenseModel"=@("New-ODBCloudAutonomousVmCluster","New-ODBCloudVmCluster")
    "MaintenanceWindow_PatchingMode"=@("New-ODBCloudAutonomousVmCluster","New-ODBCloudExadataInfrastructure","Update-ODBCloudExadataInfrastructure")
    "MaintenanceWindow_Preference"=@("New-ODBCloudAutonomousVmCluster","New-ODBCloudExadataInfrastructure","Update-ODBCloudExadataInfrastructure")
    "S3Access"=@("New-ODBOdbNetwork","Update-ODBOdbNetwork")
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
               "New-ODBCloudAutonomousVmCluster",
               "New-ODBCloudExadataInfrastructure",
               "New-ODBCloudVmCluster",
               "New-ODBOdbNetwork",
               "New-ODBOdbPeeringConnection",
               "Remove-ODBCloudAutonomousVmCluster",
               "Remove-ODBCloudExadataInfrastructure",
               "Remove-ODBCloudVmCluster",
               "Remove-ODBOdbNetwork",
               "Remove-ODBOdbPeeringConnection",
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
               "Restart-ODBDbNode",
               "Start-ODBDbNode",
               "Stop-ODBDbNode",
               "Add-ODBResourceTag",
               "Remove-ODBResourceTag",
               "Update-ODBCloudExadataInfrastructure",
               "Update-ODBOdbNetwork")
}

_awsArgumentCompleterRegistration $ODB_SelectCompleters $ODB_SelectMap

