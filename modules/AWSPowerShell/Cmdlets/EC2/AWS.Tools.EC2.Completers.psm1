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

# Argument completions for service Amazon Elastic Compute Cloud (EC2)


$EC2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EC2.Affinity
        "Edit-EC2InstancePlacement/Affinity"
        {
            $v = "default","host"
            break
        }

        # Amazon.EC2.AllocationStrategy
        "Request-EC2SpotFleet/SpotFleetRequestConfig_AllocationStrategy"
        {
            $v = "capacityOptimized","diversified","lowestPrice"
            break
        }

        # Amazon.EC2.ArchitectureValues
        "Register-EC2Image/Architecture"
        {
            $v = "arm64","i386","x86_64"
            break
        }

        # Amazon.EC2.AutoAcceptSharedAttachmentsValue
        "New-EC2TransitGateway/Options_AutoAcceptSharedAttachments"
        {
            $v = "disable","enable"
            break
        }

        # Amazon.EC2.AutoPlacement
        {
            ($_ -eq "Edit-EC2Host/AutoPlacement") -Or
            ($_ -eq "New-EC2Host/AutoPlacement")
        }
        {
            $v = "off","on"
            break
        }

        # Amazon.EC2.CapacityReservationInstancePlatform
        "Add-EC2CapacityReservation/InstancePlatform"
        {
            $v = "Linux with SQL Server Enterprise","Linux with SQL Server Standard","Linux with SQL Server Web","Linux/UNIX","Red Hat Enterprise Linux","SUSE Linux","Windows","Windows with SQL Server","Windows with SQL Server Enterprise","Windows with SQL Server Standard","Windows with SQL Server Web"
            break
        }

        # Amazon.EC2.CapacityReservationPreference
        {
            ($_ -eq "Edit-EC2InstanceCapacityReservationAttribute/CapacityReservationSpecification_CapacityReservationPreference") -Or
            ($_ -eq "New-EC2Instance/CapacityReservationSpecification_CapacityReservationPreference")
        }
        {
            $v = "none","open"
            break
        }

        # Amazon.EC2.CapacityReservationTenancy
        "Add-EC2CapacityReservation/Tenancy"
        {
            $v = "dedicated","default"
            break
        }

        # Amazon.EC2.ContainerFormat
        "New-EC2InstanceExportTask/ExportToS3Task_ContainerFormat"
        {
            $v = "ova"
            break
        }

        # Amazon.EC2.CopyTagsFromSource
        "New-EC2SnapshotBatch/CopyTagsFromSource"
        {
            $v = "volume"
            break
        }

        # Amazon.EC2.CurrencyCodeValues
        {
            ($_ -eq "New-EC2HostReservation/CurrencyCode") -Or
            ($_ -eq "New-EC2ReservedInstance/LimitPrice_CurrencyCode")
        }
        {
            $v = "USD"
            break
        }

        # Amazon.EC2.DefaultRouteTableAssociationValue
        "New-EC2TransitGateway/Options_DefaultRouteTableAssociation"
        {
            $v = "disable","enable"
            break
        }

        # Amazon.EC2.DefaultRouteTablePropagationValue
        "New-EC2TransitGateway/Options_DefaultRouteTablePropagation"
        {
            $v = "disable","enable"
            break
        }

        # Amazon.EC2.DefaultTargetCapacityType
        {
            ($_ -eq "Edit-EC2Fleet/TargetCapacitySpecification_DefaultTargetCapacityType") -Or
            ($_ -eq "New-EC2Fleet/TargetCapacitySpecification_DefaultTargetCapacityType")
        }
        {
            $v = "on-demand","spot"
            break
        }

        # Amazon.EC2.DiskImageFormat
        {
            ($_ -eq "Export-EC2Image/DiskImageFormat") -Or
            ($_ -eq "New-EC2InstanceExportTask/ExportToS3Task_DiskImageFormat")
        }
        {
            $v = "RAW","VHD","VMDK"
            break
        }

        # Amazon.EC2.DnsSupportValue
        {
            ($_ -eq "Edit-EC2TransitGatewayVpcAttachment/Options_DnsSupport") -Or
            ($_ -eq "New-EC2TransitGateway/Options_DnsSupport") -Or
            ($_ -eq "New-EC2TransitGatewayVpcAttachment/Options_DnsSupport")
        }
        {
            $v = "disable","enable"
            break
        }

        # Amazon.EC2.DomainType
        "New-EC2Address/Domain"
        {
            $v = "standard","vpc"
            break
        }

        # Amazon.EC2.EndDateType
        {
            ($_ -eq "Add-EC2CapacityReservation/EndDateType") -Or
            ($_ -eq "Edit-EC2CapacityReservation/EndDateType")
        }
        {
            $v = "limited","unlimited"
            break
        }

        # Amazon.EC2.EventType
        "Get-EC2SpotFleetRequestHistory/EventType"
        {
            $v = "error","fleetRequestChange","information","instanceChange"
            break
        }

        # Amazon.EC2.ExcessCapacityTerminationPolicy
        {
            ($_ -eq "Edit-EC2SpotFleetRequest/ExcessCapacityTerminationPolicy") -Or
            ($_ -eq "Request-EC2SpotFleet/SpotFleetRequestConfig_ExcessCapacityTerminationPolicy")
        }
        {
            $v = "default","noTermination"
            break
        }

        # Amazon.EC2.ExportEnvironment
        "New-EC2InstanceExportTask/TargetEnvironment"
        {
            $v = "citrix","microsoft","vmware"
            break
        }

        # Amazon.EC2.FleetEventType
        "Get-EC2FleetHistory/EventType"
        {
            $v = "fleet-change","instance-change","service-error"
            break
        }

        # Amazon.EC2.FleetExcessCapacityTerminationPolicy
        {
            ($_ -eq "Edit-EC2Fleet/ExcessCapacityTerminationPolicy") -Or
            ($_ -eq "New-EC2Fleet/ExcessCapacityTerminationPolicy")
        }
        {
            $v = "no-termination","termination"
            break
        }

        # Amazon.EC2.FleetOnDemandAllocationStrategy
        "New-EC2Fleet/OnDemandOptions_AllocationStrategy"
        {
            $v = "lowest-price","prioritized"
            break
        }

        # Amazon.EC2.FleetType
        {
            ($_ -eq "Request-EC2SpotFleet/SpotFleetRequestConfig_Type") -Or
            ($_ -eq "New-EC2Fleet/Type")
        }
        {
            $v = "instant","maintain","request"
            break
        }

        # Amazon.EC2.FlowLogsResourceType
        "New-EC2FlowLog/ResourceType"
        {
            $v = "NetworkInterface","Subnet","VPC"
            break
        }

        # Amazon.EC2.FpgaImageAttributeName
        {
            ($_ -eq "Edit-EC2FpgaImageAttribute/Attribute") -Or
            ($_ -eq "Get-EC2FpgaImageAttribute/Attribute")
        }
        {
            $v = "description","loadPermission","name","productCodes"
            break
        }

        # Amazon.EC2.GatewayType
        {
            ($_ -eq "New-EC2CustomerGateway/Type") -Or
            ($_ -eq "New-EC2VpnGateway/Type")
        }
        {
            $v = "ipsec.1"
            break
        }

        # Amazon.EC2.HostRecovery
        {
            ($_ -eq "Edit-EC2Host/HostRecovery") -Or
            ($_ -eq "New-EC2Host/HostRecovery")
        }
        {
            $v = "off","on"
            break
        }

        # Amazon.EC2.HostTenancy
        "Edit-EC2InstancePlacement/Tenancy"
        {
            $v = "dedicated","host"
            break
        }

        # Amazon.EC2.HttpTokensState
        {
            ($_ -eq "Edit-EC2InstanceMetadataOption/HttpTokens") -Or
            ($_ -eq "New-EC2Instance/MetadataOptions_HttpTokens")
        }
        {
            $v = "optional","required"
            break
        }

        # Amazon.EC2.ImageAttributeName
        "Get-EC2ImageAttribute/Attribute"
        {
            $v = "blockDeviceMapping","description","kernel","launchPermission","productCodes","ramdisk","sriovNetSupport"
            break
        }

        # Amazon.EC2.InstanceAttributeName
        {
            ($_ -eq "Edit-EC2InstanceAttribute/Attribute") -Or
            ($_ -eq "Get-EC2InstanceAttribute/Attribute") -Or
            ($_ -eq "Reset-EC2InstanceAttribute/Attribute")
        }
        {
            $v = "blockDeviceMapping","disableApiTermination","ebsOptimized","enaSupport","groupSet","instanceInitiatedShutdownBehavior","instanceType","kernel","productCodes","ramdisk","rootDeviceName","sourceDestCheck","sriovNetSupport","userData"
            break
        }

        # Amazon.EC2.InstanceInterruptionBehavior
        {
            ($_ -eq "Request-EC2SpotInstance/InstanceInterruptionBehavior") -Or
            ($_ -eq "Request-EC2SpotFleet/SpotFleetRequestConfig_InstanceInterruptionBehavior")
        }
        {
            $v = "hibernate","stop","terminate"
            break
        }

        # Amazon.EC2.InstanceMatchCriteria
        "Add-EC2CapacityReservation/InstanceMatchCriteria"
        {
            $v = "open","targeted"
            break
        }

        # Amazon.EC2.InstanceMetadataEndpointState
        {
            ($_ -eq "Edit-EC2InstanceMetadataOption/HttpEndpoint") -Or
            ($_ -eq "New-EC2Instance/MetadataOptions_HttpEndpoint")
        }
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.EC2.InstanceType
        {
            ($_ -eq "Get-EC2ReservedInstancesOffering/InstanceType") -Or
            ($_ -eq "New-EC2Instance/InstanceType") -Or
            ($_ -eq "Request-EC2SpotInstance/LaunchSpecification_InstanceType")
        }
        {
            $v = "a1.2xlarge","a1.4xlarge","a1.large","a1.medium","a1.metal","a1.xlarge","c1.medium","c1.xlarge","c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","c5.12xlarge","c5.18xlarge","c5.24xlarge","c5.2xlarge","c5.4xlarge","c5.9xlarge","c5.large","c5.metal","c5.xlarge","c5d.12xlarge","c5d.18xlarge","c5d.24xlarge","c5d.2xlarge","c5d.4xlarge","c5d.9xlarge","c5d.large","c5d.metal","c5d.xlarge","c5n.18xlarge","c5n.2xlarge","c5n.4xlarge","c5n.9xlarge","c5n.large","c5n.xlarge","cc1.4xlarge","cc2.8xlarge","cg1.4xlarge","cr1.8xlarge","d2.2xlarge","d2.4xlarge","d2.8xlarge","d2.xlarge","f1.16xlarge","f1.2xlarge","f1.4xlarge","g2.2xlarge","g2.8xlarge","g3.16xlarge","g3.4xlarge","g3.8xlarge","g3s.xlarge","g4dn.12xlarge","g4dn.16xlarge","g4dn.2xlarge","g4dn.4xlarge","g4dn.8xlarge","g4dn.xlarge","h1.16xlarge","h1.2xlarge","h1.4xlarge","h1.8xlarge","hi1.4xlarge","hs1.8xlarge","i2.2xlarge","i2.4xlarge","i2.8xlarge","i2.xlarge","i3.16xlarge","i3.2xlarge","i3.4xlarge","i3.8xlarge","i3.large","i3.metal","i3.xlarge","i3en.12xlarge","i3en.24xlarge","i3en.2xlarge","i3en.3xlarge","i3en.6xlarge","i3en.large","i3en.metal","i3en.xlarge","inf1.24xlarge","inf1.2xlarge","inf1.6xlarge","inf1.xlarge","m1.large","m1.medium","m1.small","m1.xlarge","m2.2xlarge","m2.4xlarge","m2.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.16xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","m5.12xlarge","m5.16xlarge","m5.24xlarge","m5.2xlarge","m5.4xlarge","m5.8xlarge","m5.large","m5.metal","m5.xlarge","m5a.12xlarge","m5a.16xlarge","m5a.24xlarge","m5a.2xlarge","m5a.4xlarge","m5a.8xlarge","m5a.large","m5a.xlarge","m5ad.12xlarge","m5ad.16xlarge","m5ad.24xlarge","m5ad.2xlarge","m5ad.4xlarge","m5ad.8xlarge","m5ad.large","m5ad.xlarge","m5d.12xlarge","m5d.16xlarge","m5d.24xlarge","m5d.2xlarge","m5d.4xlarge","m5d.8xlarge","m5d.large","m5d.metal","m5d.xlarge","m5dn.12xlarge","m5dn.16xlarge","m5dn.24xlarge","m5dn.2xlarge","m5dn.4xlarge","m5dn.8xlarge","m5dn.large","m5dn.xlarge","m5n.12xlarge","m5n.16xlarge","m5n.24xlarge","m5n.2xlarge","m5n.4xlarge","m5n.8xlarge","m5n.large","m5n.xlarge","p2.16xlarge","p2.8xlarge","p2.xlarge","p3.16xlarge","p3.2xlarge","p3.8xlarge","p3dn.24xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","r4.16xlarge","r4.2xlarge","r4.4xlarge","r4.8xlarge","r4.large","r4.xlarge","r5.12xlarge","r5.16xlarge","r5.24xlarge","r5.2xlarge","r5.4xlarge","r5.8xlarge","r5.large","r5.metal","r5.xlarge","r5a.12xlarge","r5a.16xlarge","r5a.24xlarge","r5a.2xlarge","r5a.4xlarge","r5a.8xlarge","r5a.large","r5a.xlarge","r5ad.12xlarge","r5ad.16xlarge","r5ad.24xlarge","r5ad.2xlarge","r5ad.4xlarge","r5ad.8xlarge","r5ad.large","r5ad.xlarge","r5d.12xlarge","r5d.16xlarge","r5d.24xlarge","r5d.2xlarge","r5d.4xlarge","r5d.8xlarge","r5d.large","r5d.metal","r5d.xlarge","r5dn.12xlarge","r5dn.16xlarge","r5dn.24xlarge","r5dn.2xlarge","r5dn.4xlarge","r5dn.8xlarge","r5dn.large","r5dn.xlarge","r5n.12xlarge","r5n.16xlarge","r5n.24xlarge","r5n.2xlarge","r5n.4xlarge","r5n.8xlarge","r5n.large","r5n.xlarge","t1.micro","t2.2xlarge","t2.large","t2.medium","t2.micro","t2.nano","t2.small","t2.xlarge","t3.2xlarge","t3.large","t3.medium","t3.micro","t3.nano","t3.small","t3.xlarge","t3a.2xlarge","t3a.large","t3a.medium","t3a.micro","t3a.nano","t3a.small","t3a.xlarge","u-12tb1.metal","u-18tb1.metal","u-24tb1.metal","u-6tb1.metal","u-9tb1.metal","x1.16xlarge","x1.32xlarge","x1e.16xlarge","x1e.2xlarge","x1e.32xlarge","x1e.4xlarge","x1e.8xlarge","x1e.xlarge","z1d.12xlarge","z1d.2xlarge","z1d.3xlarge","z1d.6xlarge","z1d.large","z1d.metal","z1d.xlarge"
            break
        }

        # Amazon.EC2.InterfacePermissionType
        "New-EC2NetworkInterfacePermission/Permission"
        {
            $v = "EIP-ASSOCIATE","INSTANCE-ATTACH"
            break
        }

        # Amazon.EC2.Ipv6SupportValue
        {
            ($_ -eq "Edit-EC2TransitGatewayVpcAttachment/Options_Ipv6Support") -Or
            ($_ -eq "New-EC2TransitGatewayVpcAttachment/Options_Ipv6Support")
        }
        {
            $v = "disable","enable"
            break
        }

        # Amazon.EC2.LocationType
        "Get-EC2InstanceTypeOffering/LocationType"
        {
            $v = "availability-zone","availability-zone-id","region"
            break
        }

        # Amazon.EC2.LogDestinationType
        "New-EC2FlowLog/LogDestinationType"
        {
            $v = "cloud-watch-logs","s3"
            break
        }

        # Amazon.EC2.MulticastSupportValue
        "New-EC2TransitGateway/Options_MulticastSupport"
        {
            $v = "disable","enable"
            break
        }

        # Amazon.EC2.NetworkInterfaceAttribute
        "Get-EC2NetworkInterfaceAttribute/Attribute"
        {
            $v = "attachment","description","groupSet","sourceDestCheck"
            break
        }

        # Amazon.EC2.NetworkInterfaceCreationType
        "New-EC2NetworkInterface/InterfaceType"
        {
            $v = "efa"
            break
        }

        # Amazon.EC2.OfferingClassType
        {
            ($_ -eq "Get-EC2ReservedInstance/OfferingClass") -Or
            ($_ -eq "Get-EC2ReservedInstancesOffering/OfferingClass")
        }
        {
            $v = "convertible","standard"
            break
        }

        # Amazon.EC2.OfferingTypeValues
        {
            ($_ -eq "Get-EC2ReservedInstance/OfferingType") -Or
            ($_ -eq "Get-EC2ReservedInstancesOffering/OfferingType")
        }
        {
            $v = "All Upfront","Heavy Utilization","Light Utilization","Medium Utilization","No Upfront","Partial Upfront"
            break
        }

        # Amazon.EC2.OnDemandAllocationStrategy
        "Request-EC2SpotFleet/SpotFleetRequestConfig_OnDemandAllocationStrategy"
        {
            $v = "lowestPrice","prioritized"
            break
        }

        # Amazon.EC2.OperationType
        {
            ($_ -eq "Edit-EC2FpgaImageAttribute/OperationType") -Or
            ($_ -eq "Edit-EC2ImageAttribute/OperationType") -Or
            ($_ -eq "Edit-EC2SnapshotAttribute/OperationType")
        }
        {
            $v = "add","remove"
            break
        }

        # Amazon.EC2.PlacementStrategy
        "New-EC2PlacementGroup/Strategy"
        {
            $v = "cluster","partition","spread"
            break
        }

        # Amazon.EC2.ReportStatusType
        "Send-EC2InstanceStatus/Status"
        {
            $v = "impaired","ok"
            break
        }

        # Amazon.EC2.ResetFpgaImageAttributeName
        "Reset-EC2FpgaImageAttribute/Attribute"
        {
            $v = "loadPermission"
            break
        }

        # Amazon.EC2.ResetImageAttributeName
        "Reset-EC2ImageAttribute/Attribute"
        {
            $v = "launchPermission"
            break
        }

        # Amazon.EC2.RIProductDescription
        "Get-EC2ReservedInstancesOffering/ProductDescription"
        {
            $v = "Linux/UNIX","Linux/UNIX (Amazon VPC)","Windows","Windows (Amazon VPC)"
            break
        }

        # Amazon.EC2.RuleAction
        {
            ($_ -eq "New-EC2NetworkAclEntry/RuleAction") -Or
            ($_ -eq "Set-EC2NetworkAclEntry/RuleAction")
        }
        {
            $v = "allow","deny"
            break
        }

        # Amazon.EC2.ShutdownBehavior
        "New-EC2Instance/InstanceInitiatedShutdownBehavior"
        {
            $v = "stop","terminate"
            break
        }

        # Amazon.EC2.SnapshotAttributeName
        {
            ($_ -eq "Edit-EC2SnapshotAttribute/Attribute") -Or
            ($_ -eq "Get-EC2SnapshotAttribute/Attribute") -Or
            ($_ -eq "Reset-EC2SnapshotAttribute/Attribute")
        }
        {
            $v = "createVolumePermission","productCodes"
            break
        }

        # Amazon.EC2.SpotAllocationStrategy
        "New-EC2Fleet/SpotOptions_AllocationStrategy"
        {
            $v = "capacity-optimized","diversified","lowest-price"
            break
        }

        # Amazon.EC2.SpotInstanceInterruptionBehavior
        "New-EC2Fleet/SpotOptions_InstanceInterruptionBehavior"
        {
            $v = "hibernate","stop","terminate"
            break
        }

        # Amazon.EC2.SpotInstanceType
        "Request-EC2SpotInstance/Type"
        {
            $v = "one-time","persistent"
            break
        }

        # Amazon.EC2.Tenancy
        {
            ($_ -eq "Get-EC2ReservedInstancesOffering/InstanceTenancy") -Or
            ($_ -eq "New-EC2Vpc/InstanceTenancy") -Or
            ($_ -eq "Request-EC2SpotInstance/LaunchSpecification_Placement_Tenancy") -Or
            ($_ -eq "New-EC2Instance/Placement_Tenancy")
        }
        {
            $v = "dedicated","default","host"
            break
        }

        # Amazon.EC2.TrafficDirection
        {
            ($_ -eq "Edit-EC2TrafficMirrorFilterRule/TrafficDirection") -Or
            ($_ -eq "New-EC2TrafficMirrorFilterRule/TrafficDirection")
        }
        {
            $v = "egress","ingress"
            break
        }

        # Amazon.EC2.TrafficMirrorRuleAction
        {
            ($_ -eq "Edit-EC2TrafficMirrorFilterRule/RuleAction") -Or
            ($_ -eq "New-EC2TrafficMirrorFilterRule/RuleAction")
        }
        {
            $v = "accept","reject"
            break
        }

        # Amazon.EC2.TrafficType
        "New-EC2FlowLog/TrafficType"
        {
            $v = "ACCEPT","ALL","REJECT"
            break
        }

        # Amazon.EC2.TransportProtocol
        "New-EC2ClientVpnEndpoint/TransportProtocol"
        {
            $v = "tcp","udp"
            break
        }

        # Amazon.EC2.UnlimitedSupportedInstanceFamily
        {
            ($_ -eq "Edit-EC2DefaultCreditSpecification/InstanceFamily") -Or
            ($_ -eq "Get-EC2DefaultCreditSpecification/InstanceFamily")
        }
        {
            $v = "t2","t3","t3a"
            break
        }

        # Amazon.EC2.VolumeAttributeName
        "Get-EC2VolumeAttribute/Attribute"
        {
            $v = "autoEnableIO","productCodes"
            break
        }

        # Amazon.EC2.VolumeType
        {
            ($_ -eq "Edit-EC2Volume/VolumeType") -Or
            ($_ -eq "New-EC2Volume/VolumeType")
        }
        {
            $v = "gp2","io1","sc1","st1","standard"
            break
        }

        # Amazon.EC2.VpcAttributeName
        "Get-EC2VpcAttribute/Attribute"
        {
            $v = "enableDnsHostnames","enableDnsSupport"
            break
        }

        # Amazon.EC2.VpcEndpointType
        "New-EC2VpcEndpoint/VpcEndpointType"
        {
            $v = "Gateway","Interface"
            break
        }

        # Amazon.EC2.VpcTenancy
        "Edit-EC2VpcTenancy/InstanceTenancy"
        {
            $v = "default"
            break
        }

        # Amazon.EC2.VpnEcmpSupportValue
        "New-EC2TransitGateway/Options_VpnEcmpSupport"
        {
            $v = "disable","enable"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EC2_map = @{
    "Affinity"=@("Edit-EC2InstancePlacement")
    "Architecture"=@("Register-EC2Image")
    "Attribute"=@("Edit-EC2FpgaImageAttribute","Edit-EC2InstanceAttribute","Edit-EC2SnapshotAttribute","Get-EC2FpgaImageAttribute","Get-EC2ImageAttribute","Get-EC2InstanceAttribute","Get-EC2NetworkInterfaceAttribute","Get-EC2SnapshotAttribute","Get-EC2VolumeAttribute","Get-EC2VpcAttribute","Reset-EC2FpgaImageAttribute","Reset-EC2ImageAttribute","Reset-EC2InstanceAttribute","Reset-EC2SnapshotAttribute")
    "AutoPlacement"=@("Edit-EC2Host","New-EC2Host")
    "CapacityReservationSpecification_CapacityReservationPreference"=@("Edit-EC2InstanceCapacityReservationAttribute","New-EC2Instance")
    "CopyTagsFromSource"=@("New-EC2SnapshotBatch")
    "CurrencyCode"=@("New-EC2HostReservation")
    "DiskImageFormat"=@("Export-EC2Image")
    "Domain"=@("New-EC2Address")
    "EndDateType"=@("Add-EC2CapacityReservation","Edit-EC2CapacityReservation")
    "EventType"=@("Get-EC2FleetHistory","Get-EC2SpotFleetRequestHistory")
    "ExcessCapacityTerminationPolicy"=@("Edit-EC2Fleet","Edit-EC2SpotFleetRequest","New-EC2Fleet")
    "ExportToS3Task_ContainerFormat"=@("New-EC2InstanceExportTask")
    "ExportToS3Task_DiskImageFormat"=@("New-EC2InstanceExportTask")
    "HostRecovery"=@("Edit-EC2Host","New-EC2Host")
    "HttpEndpoint"=@("Edit-EC2InstanceMetadataOption")
    "HttpTokens"=@("Edit-EC2InstanceMetadataOption")
    "InstanceFamily"=@("Edit-EC2DefaultCreditSpecification","Get-EC2DefaultCreditSpecification")
    "InstanceInitiatedShutdownBehavior"=@("New-EC2Instance")
    "InstanceInterruptionBehavior"=@("Request-EC2SpotInstance")
    "InstanceMatchCriteria"=@("Add-EC2CapacityReservation")
    "InstancePlatform"=@("Add-EC2CapacityReservation")
    "InstanceTenancy"=@("Edit-EC2VpcTenancy","Get-EC2ReservedInstancesOffering","New-EC2Vpc")
    "InstanceType"=@("Get-EC2ReservedInstancesOffering","New-EC2Instance")
    "InterfaceType"=@("New-EC2NetworkInterface")
    "LaunchSpecification_InstanceType"=@("Request-EC2SpotInstance")
    "LaunchSpecification_Placement_Tenancy"=@("Request-EC2SpotInstance")
    "LimitPrice_CurrencyCode"=@("New-EC2ReservedInstance")
    "LocationType"=@("Get-EC2InstanceTypeOffering")
    "LogDestinationType"=@("New-EC2FlowLog")
    "MetadataOptions_HttpEndpoint"=@("New-EC2Instance")
    "MetadataOptions_HttpTokens"=@("New-EC2Instance")
    "OfferingClass"=@("Get-EC2ReservedInstance","Get-EC2ReservedInstancesOffering")
    "OfferingType"=@("Get-EC2ReservedInstance","Get-EC2ReservedInstancesOffering")
    "OnDemandOptions_AllocationStrategy"=@("New-EC2Fleet")
    "OperationType"=@("Edit-EC2FpgaImageAttribute","Edit-EC2ImageAttribute","Edit-EC2SnapshotAttribute")
    "Options_AutoAcceptSharedAttachments"=@("New-EC2TransitGateway")
    "Options_DefaultRouteTableAssociation"=@("New-EC2TransitGateway")
    "Options_DefaultRouteTablePropagation"=@("New-EC2TransitGateway")
    "Options_DnsSupport"=@("Edit-EC2TransitGatewayVpcAttachment","New-EC2TransitGateway","New-EC2TransitGatewayVpcAttachment")
    "Options_Ipv6Support"=@("Edit-EC2TransitGatewayVpcAttachment","New-EC2TransitGatewayVpcAttachment")
    "Options_MulticastSupport"=@("New-EC2TransitGateway")
    "Options_VpnEcmpSupport"=@("New-EC2TransitGateway")
    "Permission"=@("New-EC2NetworkInterfacePermission")
    "Placement_Tenancy"=@("New-EC2Instance")
    "ProductDescription"=@("Get-EC2ReservedInstancesOffering")
    "ResourceType"=@("New-EC2FlowLog")
    "RuleAction"=@("Edit-EC2TrafficMirrorFilterRule","New-EC2NetworkAclEntry","New-EC2TrafficMirrorFilterRule","Set-EC2NetworkAclEntry")
    "SpotFleetRequestConfig_AllocationStrategy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_ExcessCapacityTerminationPolicy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_InstanceInterruptionBehavior"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_OnDemandAllocationStrategy"=@("Request-EC2SpotFleet")
    "SpotFleetRequestConfig_Type"=@("Request-EC2SpotFleet")
    "SpotOptions_AllocationStrategy"=@("New-EC2Fleet")
    "SpotOptions_InstanceInterruptionBehavior"=@("New-EC2Fleet")
    "Status"=@("Send-EC2InstanceStatus")
    "Strategy"=@("New-EC2PlacementGroup")
    "TargetCapacitySpecification_DefaultTargetCapacityType"=@("Edit-EC2Fleet","New-EC2Fleet")
    "TargetEnvironment"=@("New-EC2InstanceExportTask")
    "Tenancy"=@("Add-EC2CapacityReservation","Edit-EC2InstancePlacement")
    "TrafficDirection"=@("Edit-EC2TrafficMirrorFilterRule","New-EC2TrafficMirrorFilterRule")
    "TrafficType"=@("New-EC2FlowLog")
    "TransportProtocol"=@("New-EC2ClientVpnEndpoint")
    "Type"=@("New-EC2CustomerGateway","New-EC2Fleet","New-EC2VpnGateway","Request-EC2SpotInstance")
    "VolumeType"=@("Edit-EC2Volume","New-EC2Volume")
    "VpcEndpointType"=@("New-EC2VpcEndpoint")
}

_awsArgumentCompleterRegistration $EC2_Completers $EC2_map

$EC2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EC2.$($commandName.Replace('-', ''))Cmdlet]"
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

$EC2_SelectMap = @{
    "Select"=@("Approve-EC2ReservedInstancesExchangeQuote",
               "Approve-EC2TransitGatewayPeeringAttachment",
               "Approve-EC2TransitGatewayVpcAttachment",
               "Approve-EC2EndpointConnection",
               "Approve-EC2VpcPeeringConnection",
               "Start-EC2ByoipCidrAdvertisement",
               "New-EC2Address",
               "New-EC2Host",
               "Add-EC2SecurityGroupToClientVpnTargetNetwork",
               "Register-EC2Ipv6AddressList",
               "Register-EC2PrivateIpAddress",
               "Register-EC2Address",
               "Register-EC2ClientVpnTargetNetwork",
               "Register-EC2DhcpOption",
               "Register-EC2IamInstanceProfile",
               "Register-EC2RouteTable",
               "Register-EC2SubnetCidrBlock",
               "Register-EC2TransitGatewayMulticastDomain",
               "Register-EC2TransitGatewayRouteTable",
               "Register-EC2VpcCidrBlock",
               "Add-EC2ClassicLinkVpc",
               "Add-EC2InternetGateway",
               "Add-EC2NetworkInterface",
               "Add-EC2Volume",
               "Add-EC2VpnGateway",
               "Grant-EC2ClientVpnIngress",
               "Grant-EC2SecurityGroupEgress",
               "Grant-EC2SecurityGroupIngress",
               "New-EC2InstanceBundle",
               "Stop-EC2BundleTask",
               "Remove-EC2CapacityReservation",
               "Stop-EC2ExportTask",
               "Stop-EC2ImportTask",
               "Stop-EC2ReservedInstancesListing",
               "Stop-EC2SpotFleetRequest",
               "Stop-EC2SpotInstanceRequest",
               "Confirm-EC2ProductInstance",
               "Copy-EC2FpgaImage",
               "Copy-EC2Image",
               "Copy-EC2Snapshot",
               "Add-EC2CapacityReservation",
               "New-EC2ClientVpnEndpoint",
               "New-EC2ClientVpnRoute",
               "New-EC2CustomerGateway",
               "New-EC2DefaultSubnet",
               "New-EC2DefaultVpc",
               "New-EC2DhcpOption",
               "New-EC2EgressOnlyInternetGateway",
               "New-EC2Fleet",
               "New-EC2FlowLog",
               "New-EC2FpgaImage",
               "New-EC2Image",
               "New-EC2InstanceExportTask",
               "New-EC2InternetGateway",
               "New-EC2KeyPair",
               "New-EC2LaunchTemplate",
               "New-EC2LaunchTemplateVersion",
               "New-EC2LocalGatewayRoute",
               "New-EC2LocalGatewayRouteTableVpcAssociation",
               "New-EC2NatGateway",
               "New-EC2NetworkAcl",
               "New-EC2NetworkAclEntry",
               "New-EC2NetworkInterface",
               "New-EC2NetworkInterfacePermission",
               "New-EC2PlacementGroup",
               "New-EC2ReservedInstancesListing",
               "New-EC2Route",
               "New-EC2RouteTable",
               "New-EC2SecurityGroup",
               "New-EC2Snapshot",
               "New-EC2SnapshotBatch",
               "New-EC2SpotDatafeedSubscription",
               "New-EC2Subnet",
               "New-EC2Tag",
               "New-EC2TrafficMirrorFilter",
               "New-EC2TrafficMirrorFilterRule",
               "New-EC2TrafficMirrorSession",
               "New-EC2TrafficMirrorTarget",
               "New-EC2TransitGateway",
               "New-EC2TransitGatewayMulticastDomain",
               "New-EC2TransitGatewayPeeringAttachment",
               "New-EC2TransitGatewayRoute",
               "New-EC2TransitGatewayRouteTable",
               "New-EC2TransitGatewayVpcAttachment",
               "New-EC2Volume",
               "New-EC2Vpc",
               "New-EC2VpcEndpoint",
               "New-EC2VpcEndpointConnectionNotification",
               "New-EC2VpcEndpointServiceConfiguration",
               "New-EC2VpcPeeringConnection",
               "New-EC2VpnConnection",
               "New-EC2VpnConnectionRoute",
               "New-EC2VpnGateway",
               "Remove-EC2ClientVpnEndpoint",
               "Remove-EC2ClientVpnRoute",
               "Remove-EC2CustomerGateway",
               "Remove-EC2DhcpOption",
               "Remove-EC2EgressOnlyInternetGateway",
               "Remove-EC2Fleet",
               "Remove-EC2FlowLog",
               "Remove-EC2FpgaImage",
               "Remove-EC2InternetGateway",
               "Remove-EC2KeyPair",
               "Remove-EC2LaunchTemplate",
               "Remove-EC2TemplateVersion",
               "Remove-EC2LocalGatewayRoute",
               "Remove-EC2LocalGatewayRouteTableVpcAssociation",
               "Remove-EC2NatGateway",
               "Remove-EC2NetworkAcl",
               "Remove-EC2NetworkAclEntry",
               "Remove-EC2NetworkInterface",
               "Remove-EC2NetworkInterfacePermission",
               "Remove-EC2PlacementGroup",
               "Remove-EC2QueuedReservedInstance",
               "Remove-EC2Route",
               "Remove-EC2RouteTable",
               "Remove-EC2SecurityGroup",
               "Remove-EC2Snapshot",
               "Remove-EC2SpotDatafeedSubscription",
               "Remove-EC2Subnet",
               "Remove-EC2Tag",
               "Remove-EC2TrafficMirrorFilter",
               "Remove-EC2TrafficMirrorFilterRule",
               "Remove-EC2TrafficMirrorSession",
               "Remove-EC2TrafficMirrorTarget",
               "Remove-EC2TransitGateway",
               "Remove-EC2TransitGatewayMulticastDomain",
               "Remove-EC2TransitGatewayPeeringAttachment",
               "Remove-EC2TransitGatewayRoute",
               "Remove-EC2TransitGatewayRouteTable",
               "Remove-EC2TransitGatewayVpcAttachment",
               "Remove-EC2Volume",
               "Remove-EC2Vpc",
               "Remove-EC2EndpointConnectionNotification",
               "Remove-EC2VpcEndpoint",
               "Remove-EC2EndpointServiceConfiguration",
               "Remove-EC2VpcPeeringConnection",
               "Remove-EC2VpnConnection",
               "Remove-EC2VpnConnectionRoute",
               "Remove-EC2VpnGateway",
               "Unregister-EC2ByoipCidr",
               "Unregister-EC2Image",
               "Unregister-EC2TransitGatewayMulticastGroupMember",
               "Unregister-EC2TransitGatewayMulticastGroupSource",
               "Get-EC2AccountAttribute",
               "Get-EC2Address",
               "Get-EC2AggregateIdFormat",
               "Get-EC2AvailabilityZone",
               "Get-EC2BundleTask",
               "Get-EC2ByoipCidr",
               "Get-EC2CapacityReservation",
               "Get-EC2ClassicLinkInstance",
               "Get-EC2ClientVpnAuthorizationRule",
               "Get-EC2ClientVpnConnection",
               "Get-EC2ClientVpnEndpoint",
               "Get-EC2ClientVpnRoute",
               "Get-EC2ClientVpnTargetNetwork",
               "Get-EC2CoipPool",
               "Get-EC2CustomerGateway",
               "Get-EC2DhcpOption",
               "Get-EC2EgressOnlyInternetGatewayList",
               "Get-EC2ElasticGpu",
               "Get-EC2ExportImageTask",
               "Get-EC2ExportTask",
               "Get-EC2FastSnapshotRestore",
               "Get-EC2FleetHistory",
               "Get-EC2FleetInstanceList",
               "Get-EC2FleetList",
               "Get-EC2FlowLog",
               "Get-EC2FpgaImageAttribute",
               "Get-EC2FpgaImage",
               "Get-EC2HostReservationOffering",
               "Get-EC2HostReservation",
               "Get-EC2Host",
               "Get-EC2IamInstanceProfileAssociation",
               "Get-EC2IdentityIdFormat",
               "Get-EC2IdFormat",
               "Get-EC2ImageAttribute",
               "Get-EC2Image",
               "Get-EC2ImportImageTask",
               "Get-EC2ImportSnapshotTask",
               "Get-EC2InstanceAttribute",
               "Get-EC2CreditSpecification",
               "Get-EC2Instance",
               "Get-EC2InstanceStatus",
               "Get-EC2InstanceTypeOffering",
               "Get-EC2InstanceType",
               "Get-EC2InternetGateway",
               "Get-EC2KeyPair",
               "Get-EC2Template",
               "Get-EC2TemplateVersion",
               "Get-EC2LocalGatewayRouteTable",
               "Get-EC2LocalGatewayRouteTableVirtualInterfaceGroupAssociation",
               "Get-EC2LocalGatewayRouteTableVpcAssociation",
               "Get-EC2LocalGateway",
               "Get-EC2LocalGatewayVirtualInterfaceGroup",
               "Get-EC2LocalGatewayVirtualInterface",
               "Get-EC2MovingAddress",
               "Get-EC2NatGateway",
               "Get-EC2NetworkAcl",
               "Get-EC2NetworkInterfaceAttribute",
               "Get-EC2NetworkInterfacePermission",
               "Get-EC2NetworkInterface",
               "Get-EC2PlacementGroup",
               "Get-EC2PrefixList",
               "Get-EC2PrincipalIdFormat",
               "Get-EC2PublicIpv4Pool",
               "Get-EC2Region",
               "Get-EC2ReservedInstance",
               "Get-EC2ReservedInstancesListing",
               "Get-EC2ReservedInstancesModification",
               "Get-EC2ReservedInstancesOffering",
               "Get-EC2RouteTable",
               "Get-EC2ScheduledInstanceAvailability",
               "Get-EC2ScheduledInstance",
               "Get-EC2SecurityGroupReference",
               "Get-EC2SecurityGroup",
               "Get-EC2SnapshotAttribute",
               "Get-EC2Snapshot",
               "Get-EC2SpotDatafeedSubscription",
               "Get-EC2SpotFleetInstance",
               "Get-EC2SpotFleetRequestHistory",
               "Get-EC2SpotFleetRequest",
               "Get-EC2SpotInstanceRequest",
               "Get-EC2SpotPriceHistory",
               "Get-EC2StaleSecurityGroup",
               "Get-EC2Subnet",
               "Get-EC2Tag",
               "Get-EC2TrafficMirrorFilter",
               "Get-EC2TrafficMirrorSession",
               "Get-EC2TrafficMirrorTarget",
               "Get-EC2TransitGatewayAttachment",
               "Get-EC2TransitGatewayMulticastDomain",
               "Get-EC2TransitGatewayPeeringAttachment",
               "Get-EC2TransitGatewayRouteTable",
               "Get-EC2TransitGateway",
               "Get-EC2TransitGatewayVpcAttachment",
               "Get-EC2VolumeAttribute",
               "Get-EC2Volume",
               "Get-EC2VolumeModification",
               "Get-EC2VolumeStatus",
               "Get-EC2VpcAttribute",
               "Get-EC2VpcClassicLink",
               "Get-EC2VpcClassicLinkDnsSupport",
               "Get-EC2EndpointConnectionNotification",
               "Get-EC2EndpointConnection",
               "Get-EC2VpcEndpoint",
               "Get-EC2EndpointServiceConfiguration",
               "Get-EC2EndpointServicePermission",
               "Get-EC2VpcEndpointService",
               "Get-EC2VpcPeeringConnection",
               "Get-EC2Vpc",
               "Get-EC2VpnConnection",
               "Get-EC2VpnGateway",
               "Dismount-EC2ClassicLinkVpc",
               "Dismount-EC2InternetGateway",
               "Dismount-EC2NetworkInterface",
               "Dismount-EC2Volume",
               "Dismount-EC2VpnGateway",
               "Disable-EC2EbsEncryptionByDefault",
               "Disable-EC2FastSnapshotRestore",
               "Disable-EC2TransitGatewayRouteTablePropagation",
               "Disable-EC2VgwRoutePropagation",
               "Disable-EC2VpcClassicLink",
               "Disable-EC2VpcClassicLinkDnsSupport",
               "Unregister-EC2Address",
               "Unregister-EC2ClientVpnTargetNetwork",
               "Unregister-EC2IamInstanceProfile",
               "Unregister-EC2RouteTable",
               "Unregister-EC2SubnetCidrBlock",
               "Unregister-EC2TransitGatewayMulticastDomain",
               "Unregister-EC2TransitGatewayRouteTable",
               "Unregister-EC2VpcCidrBlock",
               "Enable-EC2EbsEncryptionByDefault",
               "Enable-EC2FastSnapshotRestore",
               "Enable-EC2TransitGatewayRouteTablePropagation",
               "Enable-EC2VgwRoutePropagation",
               "Enable-EC2VolumeIO",
               "Enable-EC2VpcClassicLink",
               "Enable-EC2VpcClassicLinkDnsSupport",
               "Export-EC2ClientVpnClientCertificateRevocationList",
               "Export-EC2ClientVpnClientConfiguration",
               "Export-EC2Image",
               "Export-EC2TransitGatewayRoute",
               "Get-EC2CapacityReservationUsage",
               "Get-EC2CoipPoolUsage",
               "Get-EC2ConsoleOutput",
               "Get-EC2ConsoleScreenshot",
               "Get-EC2DefaultCreditSpecification",
               "Get-EC2EbsDefaultKmsKeyId",
               "Get-EC2EbsEncryptionByDefault",
               "Get-EC2HostReservationPurchasePreview",
               "Get-EC2LaunchTemplateData",
               "Get-EC2ReservedInstancesExchangeQuote",
               "Get-EC2TransitGatewayAttachmentPropagation",
               "Get-EC2TransitGatewayMulticastDomainAssociation",
               "Get-EC2TransitGatewayRouteTableAssociation",
               "Get-EC2TransitGatewayRouteTablePropagation",
               "Import-EC2ClientVpnClientCertificateRevocationList",
               "Import-EC2Image",
               "Import-EC2KeyPair",
               "Import-EC2Snapshot",
               "Edit-EC2CapacityReservation",
               "Edit-EC2ClientVpnEndpoint",
               "Edit-EC2DefaultCreditSpecification",
               "Edit-EC2EbsDefaultKmsKeyId",
               "Edit-EC2Fleet",
               "Edit-EC2FpgaImageAttribute",
               "Edit-EC2Host",
               "Edit-EC2IdentityIdFormat",
               "Edit-EC2IdFormat",
               "Edit-EC2ImageAttribute",
               "Edit-EC2InstanceAttribute",
               "Edit-EC2InstanceCapacityReservationAttribute",
               "Edit-EC2InstanceCreditSpecification",
               "Edit-EC2InstanceEventStartTime",
               "Edit-EC2InstanceMetadataOption",
               "Edit-EC2InstancePlacement",
               "Edit-EC2LaunchTemplate",
               "Edit-EC2NetworkInterfaceAttribute",
               "Edit-EC2ReservedInstance",
               "Edit-EC2SnapshotAttribute",
               "Edit-EC2SpotFleetRequest",
               "Edit-EC2SubnetAttribute",
               "Edit-EC2TrafficMirrorFilterNetworkService",
               "Edit-EC2TrafficMirrorFilterRule",
               "Edit-EC2TrafficMirrorSession",
               "Edit-EC2TransitGatewayVpcAttachment",
               "Edit-EC2Volume",
               "Edit-EC2VolumeAttribute",
               "Edit-EC2VpcAttribute",
               "Edit-EC2VpcEndpoint",
               "Edit-EC2VpcEndpointConnectionNotification",
               "Edit-EC2VpcEndpointServiceConfiguration",
               "Edit-EC2EndpointServicePermission",
               "Edit-EC2VpcPeeringConnectionOption",
               "Edit-EC2VpcTenancy",
               "Edit-EC2VpnConnection",
               "Edit-EC2VpnTunnelCertificate",
               "Edit-EC2VpnTunnelOption",
               "Start-EC2InstanceMonitoring",
               "Move-EC2AddressToVpc",
               "Register-EC2ByoipCidr",
               "New-EC2HostReservation",
               "New-EC2ReservedInstance",
               "New-EC2ScheduledInstancePurchase",
               "Restart-EC2Instance",
               "Register-EC2Image",
               "Register-EC2TransitGatewayMulticastGroupMember",
               "Register-EC2TransitGatewayMulticastGroupSource",
               "Deny-EC2TransitGatewayPeeringAttachment",
               "Deny-EC2TransitGatewayVpcAttachment",
               "Deny-EC2EndpointConnection",
               "Deny-EC2VpcPeeringConnection",
               "Remove-EC2Address",
               "Remove-EC2Host",
               "Set-EC2IamInstanceProfileAssociation",
               "Set-EC2NetworkAclAssociation",
               "Set-EC2NetworkAclEntry",
               "Set-EC2Route",
               "Set-EC2RouteTableAssociation",
               "Set-EC2TransitGatewayRoute",
               "Send-EC2InstanceStatus",
               "Request-EC2SpotFleet",
               "Request-EC2SpotInstance",
               "Reset-EC2EbsDefaultKmsKeyId",
               "Reset-EC2FpgaImageAttribute",
               "Reset-EC2ImageAttribute",
               "Reset-EC2InstanceAttribute",
               "Reset-EC2NetworkInterfaceAttribute",
               "Reset-EC2SnapshotAttribute",
               "Restore-EC2AddressToClassic",
               "Revoke-EC2ClientVpnIngress",
               "Revoke-EC2SecurityGroupEgress",
               "Revoke-EC2SecurityGroupIngress",
               "New-EC2Instance",
               "New-EC2ScheduledInstance",
               "Search-EC2LocalGatewayRoute",
               "Search-EC2TransitGatewayMulticastGroup",
               "Search-EC2TransitGatewayRoute",
               "Send-EC2DiagnosticInterrupt",
               "Start-EC2Instance",
               "Stop-EC2Instance",
               "Stop-EC2ClientVpnConnection",
               "Remove-EC2Instance",
               "Unregister-EC2Ipv6AddressList",
               "Unregister-EC2PrivateIpAddress",
               "Stop-EC2InstanceMonitoring",
               "Update-EC2SecurityGroupRuleEgressDescription",
               "Update-EC2SecurityGroupRuleIngressDescription",
               "Stop-EC2ByoipCidrAdvertisement",
               "Get-EC2ImageByName",
               "Get-EC2InstanceMetadata",
               "Get-EC2PasswordData")
}

_awsArgumentCompleterRegistration $EC2_SelectCompleters $EC2_SelectMap


$AWS_EC2ImageByNameCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

	$keys = [Amazon.EC2.Util.ImageUtilities]::ImageKeys

	$keys |
	Sort-Object -Descending |
	Where-Object { $_ -like "$wordToComplete*" } |
	ForEach-Object {
		New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_
	}
}

_awsArgumentCompleterRegistration $AWS_EC2ImageByNameCompleter @{ "Name"=@("Get-EC2ImageByName") }

# The attribute name parameter for EC2 apis such as ModifyImageAttribute is modeled as a string
# in the service model rather than an enum type, which means by default we cannot auto-generate
# an argument completer. Api's use as DescribeImageAttribute do use an enum type (ImageAttributeName)
# and so don't have this problem.
$AWS_EC2ImageAttributeCompleter = {
	param ($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Taken from Amazon.EC2.ImageAttributeName
        "Edit-EC2ImageAttribute/Attribute"
        {
            $v = "description","kernel","ramdisk","launchPermission","productCodes","blockDeviceMapping","sriovNetSupport"
            break
        }
    }

    $v |
    Where-Object { $_ -like "$wordToComplete*" } |
    ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

_awsArgumentCompleterRegistration $AWS_EC2ImageAttributeCompleter @{ "Attribute"=@("Edit-EC2ImageAttribute") }