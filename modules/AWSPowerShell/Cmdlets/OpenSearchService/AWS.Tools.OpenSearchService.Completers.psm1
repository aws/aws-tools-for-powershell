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

# Argument completions for service Amazon OpenSearch Service


$OS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.OpenSearchService.ActionType
        "Update-OSScheduledAction/ActionType"
        {
            $v = "JVM_HEAP_SIZE_TUNING","JVM_YOUNG_GEN_TUNING","SERVICE_SOFTWARE_UPDATE"
            break
        }

        # Amazon.OpenSearchService.AutoTuneDesiredState
        {
            ($_ -eq "New-OSDomain/AutoTuneOptions_DesiredState") -Or
            ($_ -eq "Update-OSDomainConfig/AutoTuneOptions_DesiredState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.OpenSearchService.AWSServicePrincipal
        {
            ($_ -eq "Approve-OSVpcEndpointAccess/Service") -Or
            ($_ -eq "Revoke-OSVpcEndpointAccess/Service")
        }
        {
            $v = "application.opensearchservice.amazonaws.com"
            break
        }

        # Amazon.OpenSearchService.ConnectionMode
        "New-OSOutboundConnection/ConnectionMode"
        {
            $v = "DIRECT","VPC_ENDPOINT"
            break
        }

        # Amazon.OpenSearchService.DataSourceStatus
        "Update-OSDataSource/Status"
        {
            $v = "ACTIVE","DISABLED"
            break
        }

        # Amazon.OpenSearchService.DryRunMode
        "Update-OSDomainConfig/DryRunMode"
        {
            $v = "Basic","Verbose"
            break
        }

        # Amazon.OpenSearchService.EngineType
        "Get-OSDomainNameList/EngineType"
        {
            $v = "Elasticsearch","OpenSearch"
            break
        }

        # Amazon.OpenSearchService.IPAddressType
        {
            ($_ -eq "New-OSDomain/IPAddressType") -Or
            ($_ -eq "Update-OSDomainConfig/IPAddressType")
        }
        {
            $v = "dualstack","ipv4"
            break
        }

        # Amazon.OpenSearchService.MaintenanceStatus
        "Get-OSDomainMaintenanceList/Status"
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS","PENDING","TIMED_OUT"
            break
        }

        # Amazon.OpenSearchService.MaintenanceType
        {
            ($_ -eq "Get-OSDomainMaintenanceList/Action") -Or
            ($_ -eq "Start-OSDomainMaintenance/Action")
        }
        {
            $v = "REBOOT_NODE","RESTART_DASHBOARD","RESTART_SEARCH_PROCESS"
            break
        }

        # Amazon.OpenSearchService.NaturalLanguageQueryGenerationDesiredState
        {
            ($_ -eq "New-OSDomain/NaturalLanguageQueryGenerationOptions_DesiredState") -Or
            ($_ -eq "Update-OSDomainConfig/NaturalLanguageQueryGenerationOptions_DesiredState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.OpenSearchService.OpenSearchPartitionInstanceType
        {
            ($_ -eq "New-OSDomain/ClusterConfig_DedicatedMasterType") -Or
            ($_ -eq "Update-OSDomainConfig/ClusterConfig_DedicatedMasterType") -Or
            ($_ -eq "New-OSDomain/ClusterConfig_InstanceType") -Or
            ($_ -eq "Update-OSDomainConfig/ClusterConfig_InstanceType") -Or
            ($_ -eq "Get-OSInstanceTypeLimit/InstanceType")
        }
        {
            $v = "c4.2xlarge.search","c4.4xlarge.search","c4.8xlarge.search","c4.large.search","c4.xlarge.search","c5.18xlarge.search","c5.2xlarge.search","c5.4xlarge.search","c5.9xlarge.search","c5.large.search","c5.xlarge.search","c6g.12xlarge.search","c6g.2xlarge.search","c6g.4xlarge.search","c6g.8xlarge.search","c6g.large.search","c6g.xlarge.search","d2.2xlarge.search","d2.4xlarge.search","d2.8xlarge.search","d2.xlarge.search","i2.2xlarge.search","i2.xlarge.search","i3.16xlarge.search","i3.2xlarge.search","i3.4xlarge.search","i3.8xlarge.search","i3.large.search","i3.xlarge.search","m3.2xlarge.search","m3.large.search","m3.medium.search","m3.xlarge.search","m4.10xlarge.search","m4.2xlarge.search","m4.4xlarge.search","m4.large.search","m4.xlarge.search","m5.12xlarge.search","m5.24xlarge.search","m5.2xlarge.search","m5.4xlarge.search","m5.large.search","m5.xlarge.search","m6g.12xlarge.search","m6g.2xlarge.search","m6g.4xlarge.search","m6g.8xlarge.search","m6g.large.search","m6g.xlarge.search","or1.12xlarge.search","or1.16xlarge.search","or1.2xlarge.search","or1.4xlarge.search","or1.8xlarge.search","or1.large.search","or1.medium.search","or1.xlarge.search","r3.2xlarge.search","r3.4xlarge.search","r3.8xlarge.search","r3.large.search","r3.xlarge.search","r4.16xlarge.search","r4.2xlarge.search","r4.4xlarge.search","r4.8xlarge.search","r4.large.search","r4.xlarge.search","r5.12xlarge.search","r5.24xlarge.search","r5.2xlarge.search","r5.4xlarge.search","r5.large.search","r5.xlarge.search","r6g.12xlarge.search","r6g.2xlarge.search","r6g.4xlarge.search","r6g.8xlarge.search","r6g.large.search","r6g.xlarge.search","r6gd.12xlarge.search","r6gd.16xlarge.search","r6gd.2xlarge.search","r6gd.4xlarge.search","r6gd.8xlarge.search","r6gd.large.search","r6gd.xlarge.search","t2.medium.search","t2.micro.search","t2.small.search","t3.2xlarge.search","t3.large.search","t3.medium.search","t3.micro.search","t3.nano.search","t3.small.search","t3.xlarge.search","t4g.medium.search","t4g.small.search","ultrawarm1.large.search","ultrawarm1.medium.search","ultrawarm1.xlarge.search"
            break
        }

        # Amazon.OpenSearchService.OpenSearchWarmPartitionInstanceType
        {
            ($_ -eq "New-OSDomain/ClusterConfig_WarmType") -Or
            ($_ -eq "Update-OSDomainConfig/ClusterConfig_WarmType")
        }
        {
            $v = "ultrawarm1.large.search","ultrawarm1.medium.search","ultrawarm1.xlarge.search"
            break
        }

        # Amazon.OpenSearchService.PackageScopeOperationEnum
        "Update-OSOSPackageScope/Operation"
        {
            $v = "ADD","OVERRIDE","REMOVE"
            break
        }

        # Amazon.OpenSearchService.PackageType
        "New-OSPackage/PackageType"
        {
            $v = "PACKAGE-CONFIG","PACKAGE-LICENSE","TXT-DICTIONARY","ZIP-PLUGIN"
            break
        }

        # Amazon.OpenSearchService.RequirementLevel
        {
            ($_ -eq "New-OSPackage/PackageConfiguration_ConfigurationRequirement") -Or
            ($_ -eq "Update-OSPackage/PackageConfiguration_ConfigurationRequirement") -Or
            ($_ -eq "New-OSPackage/PackageConfiguration_LicenseRequirement") -Or
            ($_ -eq "Update-OSPackage/PackageConfiguration_LicenseRequirement")
        }
        {
            $v = "NONE","OPTIONAL","REQUIRED"
            break
        }

        # Amazon.OpenSearchService.RolesKeyIdCOption
        {
            ($_ -eq "New-OSDomain/IdentityCenterOptions_RolesKey") -Or
            ($_ -eq "Update-OSDomainConfig/IdentityCenterOptions_RolesKey")
        }
        {
            $v = "GroupId","GroupName"
            break
        }

        # Amazon.OpenSearchService.RollbackOnDisable
        "Update-OSDomainConfig/AutoTuneOptions_RollbackOnDisable"
        {
            $v = "DEFAULT_ROLLBACK","NO_ROLLBACK"
            break
        }

        # Amazon.OpenSearchService.ScheduleAt
        {
            ($_ -eq "Start-OSServiceSoftwareUpdate/ScheduleAt") -Or
            ($_ -eq "Update-OSScheduledAction/ScheduleAt")
        }
        {
            $v = "NOW","OFF_PEAK_WINDOW","TIMESTAMP"
            break
        }

        # Amazon.OpenSearchService.SkipUnavailableStatus
        "New-OSOutboundConnection/CrossClusterSearch_SkipUnavailable"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.OpenSearchService.SubjectKeyIdCOption
        {
            ($_ -eq "New-OSDomain/IdentityCenterOptions_SubjectKey") -Or
            ($_ -eq "Update-OSDomainConfig/IdentityCenterOptions_SubjectKey")
        }
        {
            $v = "Email","UserId","UserName"
            break
        }

        # Amazon.OpenSearchService.TLSSecurityPolicy
        {
            ($_ -eq "New-OSDomain/DomainEndpointOptions_TLSSecurityPolicy") -Or
            ($_ -eq "Update-OSDomainConfig/DomainEndpointOptions_TLSSecurityPolicy")
        }
        {
            $v = "Policy-Min-TLS-1-0-2019-07","Policy-Min-TLS-1-2-2019-07","Policy-Min-TLS-1-2-PFS-2023-10"
            break
        }

        # Amazon.OpenSearchService.VolumeType
        {
            ($_ -eq "New-OSDomain/EBSOptions_VolumeType") -Or
            ($_ -eq "Update-OSDomainConfig/EBSOptions_VolumeType")
        }
        {
            $v = "gp2","gp3","io1","standard"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$OS_map = @{
    "Action"=@("Get-OSDomainMaintenanceList","Start-OSDomainMaintenance")
    "ActionType"=@("Update-OSScheduledAction")
    "AutoTuneOptions_DesiredState"=@("New-OSDomain","Update-OSDomainConfig")
    "AutoTuneOptions_RollbackOnDisable"=@("Update-OSDomainConfig")
    "ClusterConfig_DedicatedMasterType"=@("New-OSDomain","Update-OSDomainConfig")
    "ClusterConfig_InstanceType"=@("New-OSDomain","Update-OSDomainConfig")
    "ClusterConfig_WarmType"=@("New-OSDomain","Update-OSDomainConfig")
    "ConnectionMode"=@("New-OSOutboundConnection")
    "CrossClusterSearch_SkipUnavailable"=@("New-OSOutboundConnection")
    "DomainEndpointOptions_TLSSecurityPolicy"=@("New-OSDomain","Update-OSDomainConfig")
    "DryRunMode"=@("Update-OSDomainConfig")
    "EBSOptions_VolumeType"=@("New-OSDomain","Update-OSDomainConfig")
    "EngineType"=@("Get-OSDomainNameList")
    "IdentityCenterOptions_RolesKey"=@("New-OSDomain","Update-OSDomainConfig")
    "IdentityCenterOptions_SubjectKey"=@("New-OSDomain","Update-OSDomainConfig")
    "InstanceType"=@("Get-OSInstanceTypeLimit")
    "IPAddressType"=@("New-OSDomain","Update-OSDomainConfig")
    "NaturalLanguageQueryGenerationOptions_DesiredState"=@("New-OSDomain","Update-OSDomainConfig")
    "Operation"=@("Update-OSOSPackageScope")
    "PackageConfiguration_ConfigurationRequirement"=@("New-OSPackage","Update-OSPackage")
    "PackageConfiguration_LicenseRequirement"=@("New-OSPackage","Update-OSPackage")
    "PackageType"=@("New-OSPackage")
    "ScheduleAt"=@("Start-OSServiceSoftwareUpdate","Update-OSScheduledAction")
    "Service"=@("Approve-OSVpcEndpointAccess","Revoke-OSVpcEndpointAccess")
    "Status"=@("Get-OSDomainMaintenanceList","Update-OSDataSource")
}

_awsArgumentCompleterRegistration $OS_Completers $OS_map

$OS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.OS.$($commandName.Replace('-', ''))Cmdlet]"
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

$OS_SelectMap = @{
    "Select"=@("Approve-OSInboundConnection",
               "Add-OSDataSource",
               "Add-OSResourceTag",
               "Start-OSAssociatePackage",
               "Start-OSOSAssociatePackageList",
               "Approve-OSVpcEndpointAccess",
               "Stop-OSDomainConfigChange",
               "Stop-OSServiceSoftwareUpdate",
               "New-OSApplication",
               "New-OSDomain",
               "New-OSOutboundConnection",
               "New-OSPackage",
               "New-OSVpcEndpoint",
               "Remove-OSApplication",
               "Remove-OSDataSource",
               "Remove-OSDomain",
               "Remove-OSInboundConnection",
               "Remove-OSOutboundConnection",
               "Remove-OSPackage",
               "Remove-OSVpcEndpoint",
               "Get-OSDomain",
               "Get-OSDomainAutoTune",
               "Get-OSDomainChangeProgress",
               "Get-OSDomainConfig",
               "Get-OSDomainHealth",
               "Get-OSDomainNode",
               "Get-OSDomainList",
               "Get-OSDryRunProgress",
               "Get-OSInboundConnection",
               "Get-OSInstanceTypeLimit",
               "Get-OSOutboundConnection",
               "Get-OSPackage",
               "Get-OSReservedInstanceOfferingList",
               "Get-OSReservedInstanceList",
               "Get-OSVpcEndpoint",
               "Start-OSDissociatePackage",
               "Start-OSOSDissociatePackageList",
               "Get-OSApplication",
               "Get-OSCompatibleVersion",
               "Get-OSDataSource",
               "Get-OSDomainMaintenanceStatus",
               "Get-OSPackageVersionHistory",
               "Get-OSUpgradeHistory",
               "Get-OSUpgradeStatus",
               "Get-OSApplicationList",
               "Get-OSDataSourceList",
               "Get-OSDomainMaintenanceList",
               "Get-OSDomainNameList",
               "Get-OSDomainsForPackageList",
               "Get-OSInstanceTypeDetailList",
               "Get-OSPackagesForDomainList",
               "Get-OSScheduledActionList",
               "Get-OSResourceTag",
               "Get-OSVersionList",
               "Get-OSVpcEndpointAccessList",
               "Get-OSVpcEndpointList",
               "Get-OSVpcEndpointsForDomainList",
               "New-OSReservedInstanceOffering",
               "Deny-OSInboundConnection",
               "Remove-OSResourceTag",
               "Revoke-OSVpcEndpointAccess",
               "Start-OSDomainMaintenance",
               "Start-OSServiceSoftwareUpdate",
               "Update-OSApplication",
               "Update-OSDataSource",
               "Update-OSDomainConfig",
               "Update-OSPackage",
               "Update-OSOSPackageScope",
               "Update-OSScheduledAction",
               "Update-OSVpcEndpoint",
               "Update-OSDomain")
}

_awsArgumentCompleterRegistration $OS_SelectCompleters $OS_SelectMap

