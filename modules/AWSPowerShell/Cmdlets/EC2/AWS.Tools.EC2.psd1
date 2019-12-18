#
# Module manifest for module 'AWS.Tools.EC2'
#

@{
    # Script module or binary module file associated with this manifest
    RootModule = 'AWS.Tools.EC2.dll'

    # Supported PSEditions
    CompatiblePSEditions = @('Core', 'Desktop')

    # Version number of this module.
    ModuleVersion = '0.0.0.0'

    # ID used to uniquely identify this module
    GUID = 'beb2445c-fd90-4fda-adf1-f8c955ce16dc'

    # Author of this module
    Author = 'Amazon.com, Inc'

    # Company or vendor of this module
    CompanyName = 'Amazon.com, Inc'

    # Copyright statement for this module
    Copyright = 'Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.'

    # Description of the functionality provided by this module
    Description = 'The EC2 module of AWS Tools for PowerShell lets developers and administrators manage Amazon Elastic Compute Cloud (EC2) from the PowerShell scripting environment. In order to manage each AWS service, install the corresponding module (e.g. AWS.Tools.EC2, AWS.Tools.S3...).
The module AWS.Tools.Installer (https://www.powershellgallery.com/packages/AWS.Tools.Installer/) makes it easier to install, update and uninstall the AWS.Tools modules.
This version of AWS Tools for PowerShell is compatible with Windows PowerShell 5.1+ and PowerShell Core 6+ on Windows, Linux and macOS. When running on Windows PowerShell, .NET Framework 4.7.2 or newer is required. Alternative modules AWSPowerShell.NetCore and AWSPowerShell, provide support for all AWS services from a single module and also support older versions of Windows PowerShell and .NET Framework.'

    # Minimum version of the PowerShell engine required by this module
    PowerShellVersion = '5.1'

    # Name of the PowerShell host required by this module
    PowerShellHostName = ''

    # Minimum version of the PowerShell host required by this module
    PowerShellHostVersion = ''

    # Minimum version of the .NET Framework required by this module
    DotNetFrameworkVersion = '4.7.2'

    # Minimum version of the common language runtime (CLR) required by this module
    CLRVersion = ''

    # Processor architecture (None, X86, Amd64, IA64) required by this module
    ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    RequiredModules = @(
        @{
            ModuleName = 'AWS.Tools.Common';
            RequiredVersion = '0.0.0.0';
            Guid = 'e5b05bf3-9eee-47b2-81f2-41ddc0501b86' }
    )

    # Assemblies that must be loaded prior to importing this module.
    RequiredAssemblies = @(
        'AWSSDK.EC2.dll'
    )

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    ScriptsToProcess = @(

    )

    # Type files (.ps1xml) to be loaded when importing this module
    TypesToProcess = @(

    )

    # Format files (.ps1xml) to be loaded when importing this module
    FormatsToProcess = @(
        'AWS.Tools.EC2.Format.ps1xml'
    )

    # Modules to import as nested modules of the module specified in ModuleToProcess
    NestedModules = @(
        'AWS.Tools.EC2.Completers.psm1',
        'AWS.Tools.EC2.Aliases.psm1'
    )

    # Functions to export from this module
    FunctionsToExport = ''

    # Cmdlets to export from this module
    CmdletsToExport = @(
        'Add-EC2CapacityReservation', 
        'Add-EC2ClassicLinkVpc', 
        'Add-EC2InternetGateway', 
        'Add-EC2NetworkInterface', 
        'Add-EC2SecurityGroupToClientVpnTargetNetwork', 
        'Add-EC2Volume', 
        'Add-EC2VpnGateway', 
        'Approve-EC2EndpointConnection', 
        'Approve-EC2ReservedInstancesExchangeQuote', 
        'Approve-EC2TransitGatewayPeeringAttachment', 
        'Approve-EC2TransitGatewayVpcAttachment', 
        'Approve-EC2VpcPeeringConnection', 
        'Confirm-EC2ProductInstance', 
        'Copy-EC2FpgaImage', 
        'Copy-EC2Image', 
        'Copy-EC2Snapshot', 
        'Deny-EC2EndpointConnection', 
        'Deny-EC2TransitGatewayPeeringAttachment', 
        'Deny-EC2TransitGatewayVpcAttachment', 
        'Deny-EC2VpcPeeringConnection', 
        'Disable-EC2EbsEncryptionByDefault', 
        'Disable-EC2FastSnapshotRestore', 
        'Disable-EC2TransitGatewayRouteTablePropagation', 
        'Disable-EC2VgwRoutePropagation', 
        'Disable-EC2VpcClassicLink', 
        'Disable-EC2VpcClassicLinkDnsSupport', 
        'Dismount-EC2ClassicLinkVpc', 
        'Dismount-EC2InternetGateway', 
        'Dismount-EC2NetworkInterface', 
        'Dismount-EC2Volume', 
        'Dismount-EC2VpnGateway', 
        'Edit-EC2CapacityReservation', 
        'Edit-EC2ClientVpnEndpoint', 
        'Edit-EC2DefaultCreditSpecification', 
        'Edit-EC2EbsDefaultKmsKeyId', 
        'Edit-EC2EndpointServicePermission', 
        'Edit-EC2Fleet', 
        'Edit-EC2FpgaImageAttribute', 
        'Edit-EC2Host', 
        'Edit-EC2IdentityIdFormat', 
        'Edit-EC2IdFormat', 
        'Edit-EC2ImageAttribute', 
        'Edit-EC2InstanceAttribute', 
        'Edit-EC2InstanceCapacityReservationAttribute', 
        'Edit-EC2InstanceCreditSpecification', 
        'Edit-EC2InstanceEventStartTime', 
        'Edit-EC2InstanceMetadataOption', 
        'Edit-EC2InstancePlacement', 
        'Edit-EC2LaunchTemplate', 
        'Edit-EC2NetworkInterfaceAttribute', 
        'Edit-EC2ReservedInstance', 
        'Edit-EC2SnapshotAttribute', 
        'Edit-EC2SpotFleetRequest', 
        'Edit-EC2SubnetAttribute', 
        'Edit-EC2TrafficMirrorFilterNetworkService', 
        'Edit-EC2TrafficMirrorFilterRule', 
        'Edit-EC2TrafficMirrorSession', 
        'Edit-EC2TransitGatewayVpcAttachment', 
        'Edit-EC2Volume', 
        'Edit-EC2VolumeAttribute', 
        'Edit-EC2VpcAttribute', 
        'Edit-EC2VpcEndpoint', 
        'Edit-EC2VpcEndpointConnectionNotification', 
        'Edit-EC2VpcEndpointServiceConfiguration', 
        'Edit-EC2VpcPeeringConnectionOption', 
        'Edit-EC2VpcTenancy', 
        'Edit-EC2VpnConnection', 
        'Edit-EC2VpnTunnelCertificate', 
        'Edit-EC2VpnTunnelOption', 
        'Enable-EC2EbsEncryptionByDefault', 
        'Enable-EC2FastSnapshotRestore', 
        'Enable-EC2TransitGatewayRouteTablePropagation', 
        'Enable-EC2VgwRoutePropagation', 
        'Enable-EC2VolumeIO', 
        'Enable-EC2VpcClassicLink', 
        'Enable-EC2VpcClassicLinkDnsSupport', 
        'Export-EC2ClientVpnClientCertificateRevocationList', 
        'Export-EC2ClientVpnClientConfiguration', 
        'Export-EC2Image', 
        'Export-EC2TransitGatewayRoute', 
        'Get-EC2AccountAttribute', 
        'Get-EC2Address', 
        'Get-EC2AggregateIdFormat', 
        'Get-EC2AvailabilityZone', 
        'Get-EC2BundleTask', 
        'Get-EC2ByoipCidr', 
        'Get-EC2CapacityReservation', 
        'Get-EC2CapacityReservationUsage', 
        'Get-EC2ClassicLinkInstance', 
        'Get-EC2ClientVpnAuthorizationRule', 
        'Get-EC2ClientVpnConnection', 
        'Get-EC2ClientVpnEndpoint', 
        'Get-EC2ClientVpnRoute', 
        'Get-EC2ClientVpnTargetNetwork', 
        'Get-EC2CoipPool', 
        'Get-EC2CoipPoolUsage', 
        'Get-EC2ConsoleOutput', 
        'Get-EC2ConsoleScreenshot', 
        'Get-EC2CreditSpecification', 
        'Get-EC2CustomerGateway', 
        'Get-EC2DefaultCreditSpecification', 
        'Get-EC2DhcpOption', 
        'Get-EC2EbsDefaultKmsKeyId', 
        'Get-EC2EbsEncryptionByDefault', 
        'Get-EC2EgressOnlyInternetGatewayList', 
        'Get-EC2ElasticGpu', 
        'Get-EC2EndpointConnection', 
        'Get-EC2EndpointConnectionNotification', 
        'Get-EC2EndpointServiceConfiguration', 
        'Get-EC2EndpointServicePermission', 
        'Get-EC2ExportImageTask', 
        'Get-EC2ExportTask', 
        'Get-EC2FastSnapshotRestore', 
        'Get-EC2FleetHistory', 
        'Get-EC2FleetInstanceList', 
        'Get-EC2FleetList', 
        'Get-EC2FlowLog', 
        'Get-EC2FpgaImage', 
        'Get-EC2FpgaImageAttribute', 
        'Get-EC2Host', 
        'Get-EC2HostReservation', 
        'Get-EC2HostReservationOffering', 
        'Get-EC2HostReservationPurchasePreview', 
        'Get-EC2IamInstanceProfileAssociation', 
        'Get-EC2IdentityIdFormat', 
        'Get-EC2IdFormat', 
        'Get-EC2Image', 
        'Get-EC2ImageAttribute', 
        'Get-EC2ImageByName', 
        'Get-EC2ImportImageTask', 
        'Get-EC2ImportSnapshotTask', 
        'Get-EC2Instance', 
        'Get-EC2InstanceAttribute', 
        'Get-EC2InstanceMetadata', 
        'Get-EC2InstanceStatus', 
        'Get-EC2InstanceType', 
        'Get-EC2InstanceTypeOffering', 
        'Get-EC2InternetGateway', 
        'Get-EC2KeyPair', 
        'Get-EC2LaunchTemplateData', 
        'Get-EC2LocalGateway', 
        'Get-EC2LocalGatewayRouteTable', 
        'Get-EC2LocalGatewayRouteTableVirtualInterfaceGroupAssociation', 
        'Get-EC2LocalGatewayRouteTableVpcAssociation', 
        'Get-EC2LocalGatewayVirtualInterface', 
        'Get-EC2LocalGatewayVirtualInterfaceGroup', 
        'Get-EC2MovingAddress', 
        'Get-EC2NatGateway', 
        'Get-EC2NetworkAcl', 
        'Get-EC2NetworkInterface', 
        'Get-EC2NetworkInterfaceAttribute', 
        'Get-EC2NetworkInterfacePermission', 
        'Get-EC2PasswordData', 
        'Get-EC2PlacementGroup', 
        'Get-EC2PrefixList', 
        'Get-EC2PrincipalIdFormat', 
        'Get-EC2PublicIpv4Pool', 
        'Get-EC2Region', 
        'Get-EC2ReservedInstance', 
        'Get-EC2ReservedInstancesExchangeQuote', 
        'Get-EC2ReservedInstancesListing', 
        'Get-EC2ReservedInstancesModification', 
        'Get-EC2ReservedInstancesOffering', 
        'Get-EC2RouteTable', 
        'Get-EC2ScheduledInstance', 
        'Get-EC2ScheduledInstanceAvailability', 
        'Get-EC2SecurityGroup', 
        'Get-EC2SecurityGroupReference', 
        'Get-EC2Snapshot', 
        'Get-EC2SnapshotAttribute', 
        'Get-EC2SpotDatafeedSubscription', 
        'Get-EC2SpotFleetInstance', 
        'Get-EC2SpotFleetRequest', 
        'Get-EC2SpotFleetRequestHistory', 
        'Get-EC2SpotInstanceRequest', 
        'Get-EC2SpotPriceHistory', 
        'Get-EC2StaleSecurityGroup', 
        'Get-EC2Subnet', 
        'Get-EC2Tag', 
        'Get-EC2Template', 
        'Get-EC2TemplateVersion', 
        'Get-EC2TrafficMirrorFilter', 
        'Get-EC2TrafficMirrorSession', 
        'Get-EC2TrafficMirrorTarget', 
        'Get-EC2TransitGateway', 
        'Get-EC2TransitGatewayAttachment', 
        'Get-EC2TransitGatewayAttachmentPropagation', 
        'Get-EC2TransitGatewayMulticastDomain', 
        'Get-EC2TransitGatewayMulticastDomainAssociation', 
        'Get-EC2TransitGatewayPeeringAttachment', 
        'Get-EC2TransitGatewayRouteTable', 
        'Get-EC2TransitGatewayRouteTableAssociation', 
        'Get-EC2TransitGatewayRouteTablePropagation', 
        'Get-EC2TransitGatewayVpcAttachment', 
        'Get-EC2Volume', 
        'Get-EC2VolumeAttribute', 
        'Get-EC2VolumeModification', 
        'Get-EC2VolumeStatus', 
        'Get-EC2Vpc', 
        'Get-EC2VpcAttribute', 
        'Get-EC2VpcClassicLink', 
        'Get-EC2VpcClassicLinkDnsSupport', 
        'Get-EC2VpcEndpoint', 
        'Get-EC2VpcEndpointService', 
        'Get-EC2VpcPeeringConnection', 
        'Get-EC2VpnConnection', 
        'Get-EC2VpnGateway', 
        'Grant-EC2ClientVpnIngress', 
        'Grant-EC2SecurityGroupEgress', 
        'Grant-EC2SecurityGroupIngress', 
        'Import-EC2ClientVpnClientCertificateRevocationList', 
        'Import-EC2Image', 
        'Import-EC2KeyPair', 
        'Import-EC2Snapshot', 
        'Move-EC2AddressToVpc', 
        'New-EC2Address', 
        'New-EC2ClientVpnEndpoint', 
        'New-EC2ClientVpnRoute', 
        'New-EC2CustomerGateway', 
        'New-EC2DefaultSubnet', 
        'New-EC2DefaultVpc', 
        'New-EC2DhcpOption', 
        'New-EC2EgressOnlyInternetGateway', 
        'New-EC2Fleet', 
        'New-EC2FlowLog', 
        'New-EC2FpgaImage', 
        'New-EC2Host', 
        'New-EC2HostReservation', 
        'New-EC2Image', 
        'New-EC2Instance', 
        'New-EC2InstanceBundle', 
        'New-EC2InstanceExportTask', 
        'New-EC2InternetGateway', 
        'New-EC2KeyPair', 
        'New-EC2LaunchTemplate', 
        'New-EC2LaunchTemplateVersion', 
        'New-EC2LocalGatewayRoute', 
        'New-EC2LocalGatewayRouteTableVpcAssociation', 
        'New-EC2NatGateway', 
        'New-EC2NetworkAcl', 
        'New-EC2NetworkAclEntry', 
        'New-EC2NetworkInterface', 
        'New-EC2NetworkInterfacePermission', 
        'New-EC2PlacementGroup', 
        'New-EC2ReservedInstance', 
        'New-EC2ReservedInstancesListing', 
        'New-EC2Route', 
        'New-EC2RouteTable', 
        'New-EC2ScheduledInstance', 
        'New-EC2ScheduledInstancePurchase', 
        'New-EC2SecurityGroup', 
        'New-EC2Snapshot', 
        'New-EC2SnapshotBatch', 
        'New-EC2SpotDatafeedSubscription', 
        'New-EC2Subnet', 
        'New-EC2Tag', 
        'New-EC2TrafficMirrorFilter', 
        'New-EC2TrafficMirrorFilterRule', 
        'New-EC2TrafficMirrorSession', 
        'New-EC2TrafficMirrorTarget', 
        'New-EC2TransitGateway', 
        'New-EC2TransitGatewayMulticastDomain', 
        'New-EC2TransitGatewayPeeringAttachment', 
        'New-EC2TransitGatewayRoute', 
        'New-EC2TransitGatewayRouteTable', 
        'New-EC2TransitGatewayVpcAttachment', 
        'New-EC2Volume', 
        'New-EC2Vpc', 
        'New-EC2VpcEndpoint', 
        'New-EC2VpcEndpointConnectionNotification', 
        'New-EC2VpcEndpointServiceConfiguration', 
        'New-EC2VpcPeeringConnection', 
        'New-EC2VpnConnection', 
        'New-EC2VpnConnectionRoute', 
        'New-EC2VpnGateway', 
        'Register-EC2Address', 
        'Register-EC2ByoipCidr', 
        'Register-EC2ClientVpnTargetNetwork', 
        'Register-EC2DhcpOption', 
        'Register-EC2IamInstanceProfile', 
        'Register-EC2Image', 
        'Register-EC2Ipv6AddressList', 
        'Register-EC2PrivateIpAddress', 
        'Register-EC2RouteTable', 
        'Register-EC2SubnetCidrBlock', 
        'Register-EC2TransitGatewayMulticastDomain', 
        'Register-EC2TransitGatewayMulticastGroupMember', 
        'Register-EC2TransitGatewayMulticastGroupSource', 
        'Register-EC2TransitGatewayRouteTable', 
        'Register-EC2VpcCidrBlock', 
        'Remove-EC2Address', 
        'Remove-EC2CapacityReservation', 
        'Remove-EC2ClientVpnEndpoint', 
        'Remove-EC2ClientVpnRoute', 
        'Remove-EC2CustomerGateway', 
        'Remove-EC2DhcpOption', 
        'Remove-EC2EgressOnlyInternetGateway', 
        'Remove-EC2EndpointConnectionNotification', 
        'Remove-EC2EndpointServiceConfiguration', 
        'Remove-EC2Fleet', 
        'Remove-EC2FlowLog', 
        'Remove-EC2FpgaImage', 
        'Remove-EC2Host', 
        'Remove-EC2Instance', 
        'Remove-EC2InternetGateway', 
        'Remove-EC2KeyPair', 
        'Remove-EC2LaunchTemplate', 
        'Remove-EC2LocalGatewayRoute', 
        'Remove-EC2LocalGatewayRouteTableVpcAssociation', 
        'Remove-EC2NatGateway', 
        'Remove-EC2NetworkAcl', 
        'Remove-EC2NetworkAclEntry', 
        'Remove-EC2NetworkInterface', 
        'Remove-EC2NetworkInterfacePermission', 
        'Remove-EC2PlacementGroup', 
        'Remove-EC2QueuedReservedInstance', 
        'Remove-EC2Route', 
        'Remove-EC2RouteTable', 
        'Remove-EC2SecurityGroup', 
        'Remove-EC2Snapshot', 
        'Remove-EC2SpotDatafeedSubscription', 
        'Remove-EC2Subnet', 
        'Remove-EC2Tag', 
        'Remove-EC2TemplateVersion', 
        'Remove-EC2TrafficMirrorFilter', 
        'Remove-EC2TrafficMirrorFilterRule', 
        'Remove-EC2TrafficMirrorSession', 
        'Remove-EC2TrafficMirrorTarget', 
        'Remove-EC2TransitGateway', 
        'Remove-EC2TransitGatewayMulticastDomain', 
        'Remove-EC2TransitGatewayPeeringAttachment', 
        'Remove-EC2TransitGatewayRoute', 
        'Remove-EC2TransitGatewayRouteTable', 
        'Remove-EC2TransitGatewayVpcAttachment', 
        'Remove-EC2Volume', 
        'Remove-EC2Vpc', 
        'Remove-EC2VpcEndpoint', 
        'Remove-EC2VpcPeeringConnection', 
        'Remove-EC2VpnConnection', 
        'Remove-EC2VpnConnectionRoute', 
        'Remove-EC2VpnGateway', 
        'Request-EC2SpotFleet', 
        'Request-EC2SpotInstance', 
        'Reset-EC2EbsDefaultKmsKeyId', 
        'Reset-EC2FpgaImageAttribute', 
        'Reset-EC2ImageAttribute', 
        'Reset-EC2InstanceAttribute', 
        'Reset-EC2NetworkInterfaceAttribute', 
        'Reset-EC2SnapshotAttribute', 
        'Restart-EC2Instance', 
        'Restore-EC2AddressToClassic', 
        'Revoke-EC2ClientVpnIngress', 
        'Revoke-EC2SecurityGroupEgress', 
        'Revoke-EC2SecurityGroupIngress', 
        'Search-EC2LocalGatewayRoute', 
        'Search-EC2TransitGatewayMulticastGroup', 
        'Search-EC2TransitGatewayRoute', 
        'Send-EC2DiagnosticInterrupt', 
        'Send-EC2InstanceStatus', 
        'Set-EC2IamInstanceProfileAssociation', 
        'Set-EC2NetworkAclAssociation', 
        'Set-EC2NetworkAclEntry', 
        'Set-EC2Route', 
        'Set-EC2RouteTableAssociation', 
        'Set-EC2TransitGatewayRoute', 
        'Start-EC2ByoipCidrAdvertisement', 
        'Start-EC2Instance', 
        'Start-EC2InstanceMonitoring', 
        'Stop-EC2BundleTask', 
        'Stop-EC2ByoipCidrAdvertisement', 
        'Stop-EC2ClientVpnConnection', 
        'Stop-EC2ExportTask', 
        'Stop-EC2ImportTask', 
        'Stop-EC2Instance', 
        'Stop-EC2InstanceMonitoring', 
        'Stop-EC2ReservedInstancesListing', 
        'Stop-EC2SpotFleetRequest', 
        'Stop-EC2SpotInstanceRequest', 
        'Unregister-EC2Address', 
        'Unregister-EC2ByoipCidr', 
        'Unregister-EC2ClientVpnTargetNetwork', 
        'Unregister-EC2IamInstanceProfile', 
        'Unregister-EC2Image', 
        'Unregister-EC2Ipv6AddressList', 
        'Unregister-EC2PrivateIpAddress', 
        'Unregister-EC2RouteTable', 
        'Unregister-EC2SubnetCidrBlock', 
        'Unregister-EC2TransitGatewayMulticastDomain', 
        'Unregister-EC2TransitGatewayMulticastGroupMember', 
        'Unregister-EC2TransitGatewayMulticastGroupSource', 
        'Unregister-EC2TransitGatewayRouteTable', 
        'Unregister-EC2VpcCidrBlock', 
        'Update-EC2SecurityGroupRuleEgressDescription', 
        'Update-EC2SecurityGroupRuleIngressDescription')

    # Variables to export from this module
    VariablesToExport = '*'

    # Aliases to export from this module
    AliasesToExport = @(
        'Confirm-EC2ReservedInstancesExchangeQuote', 
        'Confirm-EC2TransitGatewayPeeringAttachment', 
        'Confirm-EC2TransitGatewayVpcAttachment', 
        'Confirm-EC2EndpointConnection', 
        'Confirm-EC2VpcPeeringConnection', 
        'New-EC2Hosts', 
        'New-EC2FlowLogs', 
        'Remove-EC2FlowLogs', 
        'Get-EC2AccountAttributes', 
        'Get-EC2ExportTasks', 
        'Get-EC2FlowLogs', 
        'Get-EC2Hosts', 
        'Get-EC2ReservedInstancesModifications', 
        'Get-EC2Snapshots', 
        'Get-EC2VpcPeeringConnections', 
        'Edit-EC2Hosts', 
        'ReleaseHosts')

    # List of all modules packaged with this module
    ModuleList = @()

    # List of all files packaged with this module
    FileList = @(
        'AWS.Tools.EC2.dll-Help.xml'
    )

    # Private data to pass to the module specified in ModuleToProcess
    PrivateData = @{

        PSData = @{
            Tags = @('AWS', 'cloud', 'Windows', 'PSEdition_Desktop', 'PSEdition_Core', 'Linux', 'MacOS', 'Mac')
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'https://github.com/aws/aws-tools-for-powershell/blob/master/CHANGELOG.md'
        }
    }
}
