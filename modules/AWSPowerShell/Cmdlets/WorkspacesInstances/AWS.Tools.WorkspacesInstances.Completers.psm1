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

# Argument completions for service Amazon Workspaces Instances


$WKSI_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkspacesInstances.AmdSevSnpEnum
        "New-WKSIWorkspaceInstance/CpuOptions_AmdSevSnp"
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.WorkspacesInstances.AutoRecoveryEnum
        "New-WKSIWorkspaceInstance/MaintenanceOptions_AutoRecovery"
        {
            $v = "default","disabled"
            break
        }

        # Amazon.WorkspacesInstances.BandwidthWeightingEnum
        "New-WKSIWorkspaceInstance/NetworkPerformanceOptions_BandwidthWeighting"
        {
            $v = "default","ebs-1","vpc-1"
            break
        }

        # Amazon.WorkspacesInstances.BillingMode
        {
            ($_ -eq "New-WKSIWorkspaceInstance/BillingConfiguration_BillingMode") -Or
            ($_ -eq "Get-WKSIInstanceTypeList/InstanceConfigurationFilter_BillingMode")
        }
        {
            $v = "HOURLY","MONTHLY"
            break
        }

        # Amazon.WorkspacesInstances.CapacityReservationPreferenceEnum
        "New-WKSIWorkspaceInstance/CapacityReservationSpecification_CapacityReservationPreference"
        {
            $v = "capacity-reservations-only","none","open"
            break
        }

        # Amazon.WorkspacesInstances.CpuCreditsEnum
        "New-WKSIWorkspaceInstance/CreditSpecification_CpuCredit"
        {
            $v = "standard","unlimited"
            break
        }

        # Amazon.WorkspacesInstances.DisassociateModeEnum
        "Dismount-WKSIVolume/DisassociateMode"
        {
            $v = "FORCE","NO_FORCE"
            break
        }

        # Amazon.WorkspacesInstances.HostnameTypeEnum
        "New-WKSIWorkspaceInstance/PrivateDnsNameOptions_HostnameType"
        {
            $v = "ip-name","resource-name"
            break
        }

        # Amazon.WorkspacesInstances.HttpEndpointEnum
        "New-WKSIWorkspaceInstance/MetadataOptions_HttpEndpoint"
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.WorkspacesInstances.HttpProtocolIpv6Enum
        "New-WKSIWorkspaceInstance/MetadataOptions_HttpProtocolIpv6"
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.WorkspacesInstances.HttpTokensEnum
        "New-WKSIWorkspaceInstance/MetadataOptions_HttpToken"
        {
            $v = "optional","required"
            break
        }

        # Amazon.WorkspacesInstances.InstanceConfigurationTenancyEnum
        "Get-WKSIInstanceTypeList/InstanceConfigurationFilter_Tenancy"
        {
            $v = "DEDICATED","SHARED"
            break
        }

        # Amazon.WorkspacesInstances.InstanceInterruptionBehaviorEnum
        "New-WKSIWorkspaceInstance/SpotOptions_InstanceInterruptionBehavior"
        {
            $v = "hibernate","stop"
            break
        }

        # Amazon.WorkspacesInstances.InstanceMetadataTagsEnum
        "New-WKSIWorkspaceInstance/MetadataOptions_InstanceMetadataTag"
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.WorkspacesInstances.MarketTypeEnum
        "New-WKSIWorkspaceInstance/InstanceMarketOptions_MarketType"
        {
            $v = "capacity-block","spot"
            break
        }

        # Amazon.WorkspacesInstances.PlatformTypeEnum
        "Get-WKSIInstanceTypeList/InstanceConfigurationFilter_PlatformType"
        {
            $v = "Linux/UNIX","Red Hat BYOL Linux","Red Hat Enterprise Linux","SUSE Linux","Ubuntu Pro Linux","Windows","Windows BYOL"
            break
        }

        # Amazon.WorkspacesInstances.SpotInstanceTypeEnum
        "New-WKSIWorkspaceInstance/SpotOptions_SpotInstanceType"
        {
            $v = "one-time","persistent"
            break
        }

        # Amazon.WorkspacesInstances.TenancyEnum
        "New-WKSIWorkspaceInstance/Placement_Tenancy"
        {
            $v = "dedicated","default","host"
            break
        }

        # Amazon.WorkspacesInstances.VolumeTypeEnum
        "New-WKSIVolume/VolumeType"
        {
            $v = "gp2","gp3","io1","io2","sc1","st1","standard"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WKSI_map = @{
    "BillingConfiguration_BillingMode"=@("New-WKSIWorkspaceInstance")
    "CapacityReservationSpecification_CapacityReservationPreference"=@("New-WKSIWorkspaceInstance")
    "CpuOptions_AmdSevSnp"=@("New-WKSIWorkspaceInstance")
    "CreditSpecification_CpuCredit"=@("New-WKSIWorkspaceInstance")
    "DisassociateMode"=@("Dismount-WKSIVolume")
    "InstanceConfigurationFilter_BillingMode"=@("Get-WKSIInstanceTypeList")
    "InstanceConfigurationFilter_PlatformType"=@("Get-WKSIInstanceTypeList")
    "InstanceConfigurationFilter_Tenancy"=@("Get-WKSIInstanceTypeList")
    "InstanceMarketOptions_MarketType"=@("New-WKSIWorkspaceInstance")
    "MaintenanceOptions_AutoRecovery"=@("New-WKSIWorkspaceInstance")
    "MetadataOptions_HttpEndpoint"=@("New-WKSIWorkspaceInstance")
    "MetadataOptions_HttpProtocolIpv6"=@("New-WKSIWorkspaceInstance")
    "MetadataOptions_HttpToken"=@("New-WKSIWorkspaceInstance")
    "MetadataOptions_InstanceMetadataTag"=@("New-WKSIWorkspaceInstance")
    "NetworkPerformanceOptions_BandwidthWeighting"=@("New-WKSIWorkspaceInstance")
    "Placement_Tenancy"=@("New-WKSIWorkspaceInstance")
    "PrivateDnsNameOptions_HostnameType"=@("New-WKSIWorkspaceInstance")
    "SpotOptions_InstanceInterruptionBehavior"=@("New-WKSIWorkspaceInstance")
    "SpotOptions_SpotInstanceType"=@("New-WKSIWorkspaceInstance")
    "VolumeType"=@("New-WKSIVolume")
}

_awsArgumentCompleterRegistration $WKSI_Completers $WKSI_map

$WKSI_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WKSI.$($commandName.Replace('-', ''))Cmdlet]"
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

$WKSI_SelectMap = @{
    "Select"=@("Mount-WKSIVolume",
               "New-WKSIVolume",
               "New-WKSIWorkspaceInstance",
               "Remove-WKSIVolume",
               "Remove-WKSIWorkspaceInstance",
               "Dismount-WKSIVolume",
               "Get-WKSIWorkspaceInstance",
               "Get-WKSIInstanceTypeList",
               "Get-WKSIRegionList",
               "Get-WKSIResourceTag",
               "Get-WKSIWorkspaceInstanceList",
               "Add-WKSIResourceTag",
               "Remove-WKSIResourceTag")
}

_awsArgumentCompleterRegistration $WKSI_SelectCompleters $WKSI_SelectMap

