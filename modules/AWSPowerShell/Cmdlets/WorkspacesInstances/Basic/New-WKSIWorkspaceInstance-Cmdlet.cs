/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.WorkspacesInstances;
using Amazon.WorkspacesInstances.Model;

namespace Amazon.PowerShell.Cmdlets.WKSI
{
    /// <summary>
    /// Launches a new WorkSpace Instance with specified configuration parameters, enabling
    /// programmatic workspace deployment.
    /// </summary>
    [Cmdlet("New", "WKSIWorkspaceInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Workspaces Instances CreateWorkspaceInstance API operation.", Operation = new[] {"CreateWorkspaceInstance"}, SelectReturnType = typeof(Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWKSIWorkspaceInstanceCmdlet : AmazonWorkspacesInstancesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Placement_Affinity
        /// <summary>
        /// <para>
        /// <para>Specifies host affinity for dedicated instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_Affinity")]
        public System.String Placement_Affinity { get; set; }
        #endregion
        
        #region Parameter CpuOptions_AmdSevSnp
        /// <summary>
        /// <para>
        /// <para>AMD Secure Encrypted Virtualization configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CpuOptions_AmdSevSnp")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.AmdSevSnpEnum")]
        public Amazon.WorkspacesInstances.AmdSevSnpEnum CpuOptions_AmdSevSnp { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Arn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the IAM instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_IamInstanceProfile_Arn")]
        public System.String IamInstanceProfile_Arn { get; set; }
        #endregion
        
        #region Parameter MaintenanceOptions_AutoRecovery
        /// <summary>
        /// <para>
        /// <para>Enables or disables automatic instance recovery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_MaintenanceOptions_AutoRecovery")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.AutoRecoveryEnum")]
        public Amazon.WorkspacesInstances.AutoRecoveryEnum MaintenanceOptions_AutoRecovery { get; set; }
        #endregion
        
        #region Parameter Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Identifies the specific AWS availability zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_AvailabilityZone")]
        public System.String Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter NetworkPerformanceOptions_BandwidthWeighting
        /// <summary>
        /// <para>
        /// <para>Defines bandwidth allocation strategy for network interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_NetworkPerformanceOptions_BandwidthWeighting")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.BandwidthWeightingEnum")]
        public Amazon.WorkspacesInstances.BandwidthWeightingEnum NetworkPerformanceOptions_BandwidthWeighting { get; set; }
        #endregion
        
        #region Parameter BillingConfiguration_BillingMode
        /// <summary>
        /// <para>
        /// <para>Specifies the billing mode for WorkSpace Instances. MONTHLY provides fixed monthly
        /// rates for predictable budgeting, while HOURLY enables pay-per-second billing for actual
        /// usage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.BillingMode")]
        public Amazon.WorkspacesInstances.BillingMode BillingConfiguration_BillingMode { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>Configures block device mappings for storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_BlockDeviceMappings")]
        public Amazon.WorkspacesInstances.Model.BlockDeviceMappingRequest[] ManagedInstance_BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter SpotOptions_BlockDurationMinute
        /// <summary>
        /// <para>
        /// <para>Duration of spot instance block reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_InstanceMarketOptions_SpotOptions_BlockDurationMinutes")]
        public System.Int32? SpotOptions_BlockDurationMinute { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the capacity reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId")]
        public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter CapacityReservationSpecification_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>Preference for using capacity reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CapacityReservationSpecification_CapacityReservationPreference")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.CapacityReservationPreferenceEnum")]
        public Amazon.WorkspacesInstances.CapacityReservationPreferenceEnum CapacityReservationSpecification_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>ARN of the capacity reservation resource group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn")]
        public System.String CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter HibernationOptions_Configured
        /// <summary>
        /// <para>
        /// <para>Enables or disables instance hibernation capability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_HibernationOptions_Configured")]
        public System.Boolean? HibernationOptions_Configured { get; set; }
        #endregion
        
        #region Parameter CpuOptions_CoreCount
        /// <summary>
        /// <para>
        /// <para>Number of CPU cores to allocate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CpuOptions_CoreCount")]
        public System.Int32? CpuOptions_CoreCount { get; set; }
        #endregion
        
        #region Parameter CreditSpecification_CpuCredit
        /// <summary>
        /// <para>
        /// <para>CPU credit specification mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CreditSpecification_CpuCredits")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.CpuCreditsEnum")]
        public Amazon.WorkspacesInstances.CpuCreditsEnum CreditSpecification_CpuCredit { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_DisableApiStop
        /// <summary>
        /// <para>
        /// <para>Prevents API-initiated instance stop.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedInstance_DisableApiStop { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Enables optimized EBS performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedInstance_EbsOptimized { get; set; }
        #endregion
        
        #region Parameter EnclaveOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables AWS Nitro Enclaves for enhanced security.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_EnclaveOptions_Enabled")]
        public System.Boolean? EnclaveOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter Monitoring_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables detailed instance monitoring.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Monitoring_Enabled")]
        public System.Boolean? Monitoring_Enabled { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_EnablePrimaryIpv6
        /// <summary>
        /// <para>
        /// <para>Enables primary IPv6 address configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedInstance_EnablePrimaryIpv6 { get; set; }
        #endregion
        
        #region Parameter PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord
        /// <summary>
        /// <para>
        /// <para>Enables DNS AAAA record for resource name resolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord")]
        public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord { get; set; }
        #endregion
        
        #region Parameter PrivateDnsNameOptions_EnableResourceNameDnsARecord
        /// <summary>
        /// <para>
        /// <para>Enables DNS A record for resource name resolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_PrivateDnsNameOptions_EnableResourceNameDnsARecord")]
        public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsARecord { get; set; }
        #endregion
        
        #region Parameter Placement_GroupId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for placement group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_GroupId")]
        public System.String Placement_GroupId { get; set; }
        #endregion
        
        #region Parameter Placement_GroupName
        /// <summary>
        /// <para>
        /// <para>Name of the placement group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_GroupName")]
        public System.String Placement_GroupName { get; set; }
        #endregion
        
        #region Parameter Placement_HostId
        /// <summary>
        /// <para>
        /// <para>Identifies the specific dedicated host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_HostId")]
        public System.String Placement_HostId { get; set; }
        #endregion
        
        #region Parameter PrivateDnsNameOptions_HostnameType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of hostname configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_PrivateDnsNameOptions_HostnameType")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.HostnameTypeEnum")]
        public Amazon.WorkspacesInstances.HostnameTypeEnum PrivateDnsNameOptions_HostnameType { get; set; }
        #endregion
        
        #region Parameter Placement_HostResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>ARN of the host resource group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_HostResourceGroupArn")]
        public System.String Placement_HostResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>Enables or disables HTTP endpoint for instance metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_MetadataOptions_HttpEndpoint")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.HttpEndpointEnum")]
        public Amazon.WorkspacesInstances.HttpEndpointEnum MetadataOptions_HttpEndpoint { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpProtocolIpv6
        /// <summary>
        /// <para>
        /// <para>Configures IPv6 support for instance metadata HTTP protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_MetadataOptions_HttpProtocolIpv6")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.HttpProtocolIpv6Enum")]
        public Amazon.WorkspacesInstances.HttpProtocolIpv6Enum MetadataOptions_HttpProtocolIpv6 { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>Sets maximum number of network hops for metadata PUT responses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_MetadataOptions_HttpPutResponseHopLimit")]
        public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpToken
        /// <summary>
        /// <para>
        /// <para>Configures token requirement for instance metadata retrieval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_MetadataOptions_HttpTokens")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.HttpTokensEnum")]
        public Amazon.WorkspacesInstances.HttpTokensEnum MetadataOptions_HttpToken { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_ImageId
        /// <summary>
        /// <para>
        /// <para>Identifies the Amazon Machine Image (AMI) for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_ImageId { get; set; }
        #endregion
        
        #region Parameter SpotOptions_InstanceInterruptionBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies behavior when spot instance is interrupted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_InstanceMarketOptions_SpotOptions_InstanceInterruptionBehavior")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.InstanceInterruptionBehaviorEnum")]
        public Amazon.WorkspacesInstances.InstanceInterruptionBehaviorEnum SpotOptions_InstanceInterruptionBehavior { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_InstanceMetadataTag
        /// <summary>
        /// <para>
        /// <para>Enables or disables instance metadata tags retrieval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_MetadataOptions_InstanceMetadataTags")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.InstanceMetadataTagsEnum")]
        public Amazon.WorkspacesInstances.InstanceMetadataTagsEnum MetadataOptions_InstanceMetadataTag { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_InstanceType
        /// <summary>
        /// <para>
        /// <para>Specifies the WorkSpace Instance type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_InstanceType { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_Ipv6AddressCount
        /// <summary>
        /// <para>
        /// <para>Specifies number of IPv6 addresses to assign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ManagedInstance_Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_Ipv6Address
        /// <summary>
        /// <para>
        /// <para>Configures specific IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Ipv6Addresses")]
        public Amazon.WorkspacesInstances.Model.InstanceIpv6Address[] ManagedInstance_Ipv6Address { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_KernelId
        /// <summary>
        /// <para>
        /// <para>Identifies the kernel for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_KernelId { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_KeyName
        /// <summary>
        /// <para>
        /// <para>Specifies the key pair for instance access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_KeyName { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_LicenseSpecification
        /// <summary>
        /// <para>
        /// <para>Configures license-related settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_LicenseSpecifications")]
        public Amazon.WorkspacesInstances.Model.LicenseConfigurationRequest[] ManagedInstance_LicenseSpecification { get; set; }
        #endregion
        
        #region Parameter InstanceMarketOptions_MarketType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of marketplace for instance deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_InstanceMarketOptions_MarketType")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.MarketTypeEnum")]
        public Amazon.WorkspacesInstances.MarketTypeEnum InstanceMarketOptions_MarketType { get; set; }
        #endregion
        
        #region Parameter SpotOptions_MaxPrice
        /// <summary>
        /// <para>
        /// <para>Maximum hourly price for spot instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_InstanceMarketOptions_SpotOptions_MaxPrice")]
        public System.String SpotOptions_MaxPrice { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Name
        /// <summary>
        /// <para>
        /// <para>Name of the IAM instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_IamInstanceProfile_Name")]
        public System.String IamInstanceProfile_Name { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_NetworkInterface
        /// <summary>
        /// <para>
        /// <para>Configures network interface settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_NetworkInterfaces")]
        public Amazon.WorkspacesInstances.Model.InstanceNetworkInterfaceSpecification[] ManagedInstance_NetworkInterface { get; set; }
        #endregion
        
        #region Parameter Placement_PartitionNumber
        /// <summary>
        /// <para>
        /// <para>Specifies partition number for partition placement groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_PartitionNumber")]
        public System.Int32? Placement_PartitionNumber { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>Specifies the primary private IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_RamdiskId
        /// <summary>
        /// <para>
        /// <para>Identifies the ramdisk for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_RamdiskId { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies security group identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_SecurityGroupIds")]
        public System.String[] ManagedInstance_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>Configures security group settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_SecurityGroups")]
        public System.String[] ManagedInstance_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SpotOptions_SpotInstanceType
        /// <summary>
        /// <para>
        /// <para>Defines the type of spot instance request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_InstanceMarketOptions_SpotOptions_SpotInstanceType")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.SpotInstanceTypeEnum")]
        public Amazon.WorkspacesInstances.SpotInstanceTypeEnum SpotOptions_SpotInstanceType { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_SubnetId
        /// <summary>
        /// <para>
        /// <para>Identifies the subnet for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata tags for categorizing and managing WorkSpaces Instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkspacesInstances.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_TagSpecification
        /// <summary>
        /// <para>
        /// <para>Configures resource tagging specifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_TagSpecifications")]
        public Amazon.WorkspacesInstances.Model.TagSpecification[] ManagedInstance_TagSpecification { get; set; }
        #endregion
        
        #region Parameter Placement_Tenancy
        /// <summary>
        /// <para>
        /// <para>Defines instance tenancy configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_Placement_Tenancy")]
        [AWSConstantClassSource("Amazon.WorkspacesInstances.TenancyEnum")]
        public Amazon.WorkspacesInstances.TenancyEnum Placement_Tenancy { get; set; }
        #endregion
        
        #region Parameter CpuOptions_ThreadsPerCore
        /// <summary>
        /// <para>
        /// <para>Number of threads per CPU core.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_CpuOptions_ThreadsPerCore")]
        public System.Int32? CpuOptions_ThreadsPerCore { get; set; }
        #endregion
        
        #region Parameter ManagedInstance_UserData
        /// <summary>
        /// <para>
        /// <para>Provides custom initialization data for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedInstance_UserData { get; set; }
        #endregion
        
        #region Parameter SpotOptions_ValidUntilUtc
        /// <summary>
        /// <para>
        /// <para>Timestamp until which spot instance request is valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedInstance_InstanceMarketOptions_SpotOptions_ValidUntilUtc")]
        public System.DateTime? SpotOptions_ValidUntilUtc { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique token to ensure idempotent instance creation, preventing duplicate workspace
        /// launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkspaceInstanceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse).
        /// Specifying the name of a property of type Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkspaceInstanceId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WKSIWorkspaceInstance (CreateWorkspaceInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse, NewWKSIWorkspaceInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingConfiguration_BillingMode = this.BillingConfiguration_BillingMode;
            context.ClientToken = this.ClientToken;
            if (this.ManagedInstance_BlockDeviceMapping != null)
            {
                context.ManagedInstance_BlockDeviceMapping = new List<Amazon.WorkspacesInstances.Model.BlockDeviceMappingRequest>(this.ManagedInstance_BlockDeviceMapping);
            }
            context.CapacityReservationSpecification_CapacityReservationPreference = this.CapacityReservationSpecification_CapacityReservationPreference;
            context.CapacityReservationTarget_CapacityReservationId = this.CapacityReservationTarget_CapacityReservationId;
            context.CapacityReservationTarget_CapacityReservationResourceGroupArn = this.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            context.CpuOptions_AmdSevSnp = this.CpuOptions_AmdSevSnp;
            context.CpuOptions_CoreCount = this.CpuOptions_CoreCount;
            context.CpuOptions_ThreadsPerCore = this.CpuOptions_ThreadsPerCore;
            context.CreditSpecification_CpuCredit = this.CreditSpecification_CpuCredit;
            context.ManagedInstance_DisableApiStop = this.ManagedInstance_DisableApiStop;
            context.ManagedInstance_EbsOptimized = this.ManagedInstance_EbsOptimized;
            context.ManagedInstance_EnablePrimaryIpv6 = this.ManagedInstance_EnablePrimaryIpv6;
            context.EnclaveOptions_Enabled = this.EnclaveOptions_Enabled;
            context.HibernationOptions_Configured = this.HibernationOptions_Configured;
            context.IamInstanceProfile_Arn = this.IamInstanceProfile_Arn;
            context.IamInstanceProfile_Name = this.IamInstanceProfile_Name;
            context.ManagedInstance_ImageId = this.ManagedInstance_ImageId;
            context.InstanceMarketOptions_MarketType = this.InstanceMarketOptions_MarketType;
            context.SpotOptions_BlockDurationMinute = this.SpotOptions_BlockDurationMinute;
            context.SpotOptions_InstanceInterruptionBehavior = this.SpotOptions_InstanceInterruptionBehavior;
            context.SpotOptions_MaxPrice = this.SpotOptions_MaxPrice;
            context.SpotOptions_SpotInstanceType = this.SpotOptions_SpotInstanceType;
            context.SpotOptions_ValidUntilUtc = this.SpotOptions_ValidUntilUtc;
            context.ManagedInstance_InstanceType = this.ManagedInstance_InstanceType;
            context.ManagedInstance_Ipv6AddressCount = this.ManagedInstance_Ipv6AddressCount;
            if (this.ManagedInstance_Ipv6Address != null)
            {
                context.ManagedInstance_Ipv6Address = new List<Amazon.WorkspacesInstances.Model.InstanceIpv6Address>(this.ManagedInstance_Ipv6Address);
            }
            context.ManagedInstance_KernelId = this.ManagedInstance_KernelId;
            context.ManagedInstance_KeyName = this.ManagedInstance_KeyName;
            if (this.ManagedInstance_LicenseSpecification != null)
            {
                context.ManagedInstance_LicenseSpecification = new List<Amazon.WorkspacesInstances.Model.LicenseConfigurationRequest>(this.ManagedInstance_LicenseSpecification);
            }
            context.MaintenanceOptions_AutoRecovery = this.MaintenanceOptions_AutoRecovery;
            context.MetadataOptions_HttpEndpoint = this.MetadataOptions_HttpEndpoint;
            context.MetadataOptions_HttpProtocolIpv6 = this.MetadataOptions_HttpProtocolIpv6;
            context.MetadataOptions_HttpPutResponseHopLimit = this.MetadataOptions_HttpPutResponseHopLimit;
            context.MetadataOptions_HttpToken = this.MetadataOptions_HttpToken;
            context.MetadataOptions_InstanceMetadataTag = this.MetadataOptions_InstanceMetadataTag;
            context.Monitoring_Enabled = this.Monitoring_Enabled;
            if (this.ManagedInstance_NetworkInterface != null)
            {
                context.ManagedInstance_NetworkInterface = new List<Amazon.WorkspacesInstances.Model.InstanceNetworkInterfaceSpecification>(this.ManagedInstance_NetworkInterface);
            }
            context.NetworkPerformanceOptions_BandwidthWeighting = this.NetworkPerformanceOptions_BandwidthWeighting;
            context.Placement_Affinity = this.Placement_Affinity;
            context.Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.Placement_GroupId = this.Placement_GroupId;
            context.Placement_GroupName = this.Placement_GroupName;
            context.Placement_HostId = this.Placement_HostId;
            context.Placement_HostResourceGroupArn = this.Placement_HostResourceGroupArn;
            context.Placement_PartitionNumber = this.Placement_PartitionNumber;
            context.Placement_Tenancy = this.Placement_Tenancy;
            context.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord = this.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord;
            context.PrivateDnsNameOptions_EnableResourceNameDnsARecord = this.PrivateDnsNameOptions_EnableResourceNameDnsARecord;
            context.PrivateDnsNameOptions_HostnameType = this.PrivateDnsNameOptions_HostnameType;
            context.ManagedInstance_PrivateIpAddress = this.ManagedInstance_PrivateIpAddress;
            context.ManagedInstance_RamdiskId = this.ManagedInstance_RamdiskId;
            if (this.ManagedInstance_SecurityGroupId != null)
            {
                context.ManagedInstance_SecurityGroupId = new List<System.String>(this.ManagedInstance_SecurityGroupId);
            }
            if (this.ManagedInstance_SecurityGroup != null)
            {
                context.ManagedInstance_SecurityGroup = new List<System.String>(this.ManagedInstance_SecurityGroup);
            }
            context.ManagedInstance_SubnetId = this.ManagedInstance_SubnetId;
            if (this.ManagedInstance_TagSpecification != null)
            {
                context.ManagedInstance_TagSpecification = new List<Amazon.WorkspacesInstances.Model.TagSpecification>(this.ManagedInstance_TagSpecification);
            }
            context.ManagedInstance_UserData = this.ManagedInstance_UserData;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WorkspacesInstances.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceRequest();
            
            
             // populate BillingConfiguration
            var requestBillingConfigurationIsNull = true;
            request.BillingConfiguration = new Amazon.WorkspacesInstances.Model.BillingConfiguration();
            Amazon.WorkspacesInstances.BillingMode requestBillingConfiguration_billingConfiguration_BillingMode = null;
            if (cmdletContext.BillingConfiguration_BillingMode != null)
            {
                requestBillingConfiguration_billingConfiguration_BillingMode = cmdletContext.BillingConfiguration_BillingMode;
            }
            if (requestBillingConfiguration_billingConfiguration_BillingMode != null)
            {
                request.BillingConfiguration.BillingMode = requestBillingConfiguration_billingConfiguration_BillingMode;
                requestBillingConfigurationIsNull = false;
            }
             // determine if request.BillingConfiguration should be set to null
            if (requestBillingConfigurationIsNull)
            {
                request.BillingConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ManagedInstance
            var requestManagedInstanceIsNull = true;
            request.ManagedInstance = new Amazon.WorkspacesInstances.Model.ManagedInstanceRequest();
            List<Amazon.WorkspacesInstances.Model.BlockDeviceMappingRequest> requestManagedInstance_managedInstance_BlockDeviceMapping = null;
            if (cmdletContext.ManagedInstance_BlockDeviceMapping != null)
            {
                requestManagedInstance_managedInstance_BlockDeviceMapping = cmdletContext.ManagedInstance_BlockDeviceMapping;
            }
            if (requestManagedInstance_managedInstance_BlockDeviceMapping != null)
            {
                request.ManagedInstance.BlockDeviceMappings = requestManagedInstance_managedInstance_BlockDeviceMapping;
                requestManagedInstanceIsNull = false;
            }
            System.Boolean? requestManagedInstance_managedInstance_DisableApiStop = null;
            if (cmdletContext.ManagedInstance_DisableApiStop != null)
            {
                requestManagedInstance_managedInstance_DisableApiStop = cmdletContext.ManagedInstance_DisableApiStop.Value;
            }
            if (requestManagedInstance_managedInstance_DisableApiStop != null)
            {
                request.ManagedInstance.DisableApiStop = requestManagedInstance_managedInstance_DisableApiStop.Value;
                requestManagedInstanceIsNull = false;
            }
            System.Boolean? requestManagedInstance_managedInstance_EbsOptimized = null;
            if (cmdletContext.ManagedInstance_EbsOptimized != null)
            {
                requestManagedInstance_managedInstance_EbsOptimized = cmdletContext.ManagedInstance_EbsOptimized.Value;
            }
            if (requestManagedInstance_managedInstance_EbsOptimized != null)
            {
                request.ManagedInstance.EbsOptimized = requestManagedInstance_managedInstance_EbsOptimized.Value;
                requestManagedInstanceIsNull = false;
            }
            System.Boolean? requestManagedInstance_managedInstance_EnablePrimaryIpv6 = null;
            if (cmdletContext.ManagedInstance_EnablePrimaryIpv6 != null)
            {
                requestManagedInstance_managedInstance_EnablePrimaryIpv6 = cmdletContext.ManagedInstance_EnablePrimaryIpv6.Value;
            }
            if (requestManagedInstance_managedInstance_EnablePrimaryIpv6 != null)
            {
                request.ManagedInstance.EnablePrimaryIpv6 = requestManagedInstance_managedInstance_EnablePrimaryIpv6.Value;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_ImageId = null;
            if (cmdletContext.ManagedInstance_ImageId != null)
            {
                requestManagedInstance_managedInstance_ImageId = cmdletContext.ManagedInstance_ImageId;
            }
            if (requestManagedInstance_managedInstance_ImageId != null)
            {
                request.ManagedInstance.ImageId = requestManagedInstance_managedInstance_ImageId;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_InstanceType = null;
            if (cmdletContext.ManagedInstance_InstanceType != null)
            {
                requestManagedInstance_managedInstance_InstanceType = cmdletContext.ManagedInstance_InstanceType;
            }
            if (requestManagedInstance_managedInstance_InstanceType != null)
            {
                request.ManagedInstance.InstanceType = requestManagedInstance_managedInstance_InstanceType;
                requestManagedInstanceIsNull = false;
            }
            System.Int32? requestManagedInstance_managedInstance_Ipv6AddressCount = null;
            if (cmdletContext.ManagedInstance_Ipv6AddressCount != null)
            {
                requestManagedInstance_managedInstance_Ipv6AddressCount = cmdletContext.ManagedInstance_Ipv6AddressCount.Value;
            }
            if (requestManagedInstance_managedInstance_Ipv6AddressCount != null)
            {
                request.ManagedInstance.Ipv6AddressCount = requestManagedInstance_managedInstance_Ipv6AddressCount.Value;
                requestManagedInstanceIsNull = false;
            }
            List<Amazon.WorkspacesInstances.Model.InstanceIpv6Address> requestManagedInstance_managedInstance_Ipv6Address = null;
            if (cmdletContext.ManagedInstance_Ipv6Address != null)
            {
                requestManagedInstance_managedInstance_Ipv6Address = cmdletContext.ManagedInstance_Ipv6Address;
            }
            if (requestManagedInstance_managedInstance_Ipv6Address != null)
            {
                request.ManagedInstance.Ipv6Addresses = requestManagedInstance_managedInstance_Ipv6Address;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_KernelId = null;
            if (cmdletContext.ManagedInstance_KernelId != null)
            {
                requestManagedInstance_managedInstance_KernelId = cmdletContext.ManagedInstance_KernelId;
            }
            if (requestManagedInstance_managedInstance_KernelId != null)
            {
                request.ManagedInstance.KernelId = requestManagedInstance_managedInstance_KernelId;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_KeyName = null;
            if (cmdletContext.ManagedInstance_KeyName != null)
            {
                requestManagedInstance_managedInstance_KeyName = cmdletContext.ManagedInstance_KeyName;
            }
            if (requestManagedInstance_managedInstance_KeyName != null)
            {
                request.ManagedInstance.KeyName = requestManagedInstance_managedInstance_KeyName;
                requestManagedInstanceIsNull = false;
            }
            List<Amazon.WorkspacesInstances.Model.LicenseConfigurationRequest> requestManagedInstance_managedInstance_LicenseSpecification = null;
            if (cmdletContext.ManagedInstance_LicenseSpecification != null)
            {
                requestManagedInstance_managedInstance_LicenseSpecification = cmdletContext.ManagedInstance_LicenseSpecification;
            }
            if (requestManagedInstance_managedInstance_LicenseSpecification != null)
            {
                request.ManagedInstance.LicenseSpecifications = requestManagedInstance_managedInstance_LicenseSpecification;
                requestManagedInstanceIsNull = false;
            }
            List<Amazon.WorkspacesInstances.Model.InstanceNetworkInterfaceSpecification> requestManagedInstance_managedInstance_NetworkInterface = null;
            if (cmdletContext.ManagedInstance_NetworkInterface != null)
            {
                requestManagedInstance_managedInstance_NetworkInterface = cmdletContext.ManagedInstance_NetworkInterface;
            }
            if (requestManagedInstance_managedInstance_NetworkInterface != null)
            {
                request.ManagedInstance.NetworkInterfaces = requestManagedInstance_managedInstance_NetworkInterface;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_PrivateIpAddress = null;
            if (cmdletContext.ManagedInstance_PrivateIpAddress != null)
            {
                requestManagedInstance_managedInstance_PrivateIpAddress = cmdletContext.ManagedInstance_PrivateIpAddress;
            }
            if (requestManagedInstance_managedInstance_PrivateIpAddress != null)
            {
                request.ManagedInstance.PrivateIpAddress = requestManagedInstance_managedInstance_PrivateIpAddress;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_RamdiskId = null;
            if (cmdletContext.ManagedInstance_RamdiskId != null)
            {
                requestManagedInstance_managedInstance_RamdiskId = cmdletContext.ManagedInstance_RamdiskId;
            }
            if (requestManagedInstance_managedInstance_RamdiskId != null)
            {
                request.ManagedInstance.RamdiskId = requestManagedInstance_managedInstance_RamdiskId;
                requestManagedInstanceIsNull = false;
            }
            List<System.String> requestManagedInstance_managedInstance_SecurityGroupId = null;
            if (cmdletContext.ManagedInstance_SecurityGroupId != null)
            {
                requestManagedInstance_managedInstance_SecurityGroupId = cmdletContext.ManagedInstance_SecurityGroupId;
            }
            if (requestManagedInstance_managedInstance_SecurityGroupId != null)
            {
                request.ManagedInstance.SecurityGroupIds = requestManagedInstance_managedInstance_SecurityGroupId;
                requestManagedInstanceIsNull = false;
            }
            List<System.String> requestManagedInstance_managedInstance_SecurityGroup = null;
            if (cmdletContext.ManagedInstance_SecurityGroup != null)
            {
                requestManagedInstance_managedInstance_SecurityGroup = cmdletContext.ManagedInstance_SecurityGroup;
            }
            if (requestManagedInstance_managedInstance_SecurityGroup != null)
            {
                request.ManagedInstance.SecurityGroups = requestManagedInstance_managedInstance_SecurityGroup;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_SubnetId = null;
            if (cmdletContext.ManagedInstance_SubnetId != null)
            {
                requestManagedInstance_managedInstance_SubnetId = cmdletContext.ManagedInstance_SubnetId;
            }
            if (requestManagedInstance_managedInstance_SubnetId != null)
            {
                request.ManagedInstance.SubnetId = requestManagedInstance_managedInstance_SubnetId;
                requestManagedInstanceIsNull = false;
            }
            List<Amazon.WorkspacesInstances.Model.TagSpecification> requestManagedInstance_managedInstance_TagSpecification = null;
            if (cmdletContext.ManagedInstance_TagSpecification != null)
            {
                requestManagedInstance_managedInstance_TagSpecification = cmdletContext.ManagedInstance_TagSpecification;
            }
            if (requestManagedInstance_managedInstance_TagSpecification != null)
            {
                request.ManagedInstance.TagSpecifications = requestManagedInstance_managedInstance_TagSpecification;
                requestManagedInstanceIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_UserData = null;
            if (cmdletContext.ManagedInstance_UserData != null)
            {
                requestManagedInstance_managedInstance_UserData = cmdletContext.ManagedInstance_UserData;
            }
            if (requestManagedInstance_managedInstance_UserData != null)
            {
                request.ManagedInstance.UserData = requestManagedInstance_managedInstance_UserData;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.CreditSpecificationRequest requestManagedInstance_managedInstance_CreditSpecification = null;
            
             // populate CreditSpecification
            var requestManagedInstance_managedInstance_CreditSpecificationIsNull = true;
            requestManagedInstance_managedInstance_CreditSpecification = new Amazon.WorkspacesInstances.Model.CreditSpecificationRequest();
            Amazon.WorkspacesInstances.CpuCreditsEnum requestManagedInstance_managedInstance_CreditSpecification_creditSpecification_CpuCredit = null;
            if (cmdletContext.CreditSpecification_CpuCredit != null)
            {
                requestManagedInstance_managedInstance_CreditSpecification_creditSpecification_CpuCredit = cmdletContext.CreditSpecification_CpuCredit;
            }
            if (requestManagedInstance_managedInstance_CreditSpecification_creditSpecification_CpuCredit != null)
            {
                requestManagedInstance_managedInstance_CreditSpecification.CpuCredits = requestManagedInstance_managedInstance_CreditSpecification_creditSpecification_CpuCredit;
                requestManagedInstance_managedInstance_CreditSpecificationIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_CreditSpecification should be set to null
            if (requestManagedInstance_managedInstance_CreditSpecificationIsNull)
            {
                requestManagedInstance_managedInstance_CreditSpecification = null;
            }
            if (requestManagedInstance_managedInstance_CreditSpecification != null)
            {
                request.ManagedInstance.CreditSpecification = requestManagedInstance_managedInstance_CreditSpecification;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.EnclaveOptionsRequest requestManagedInstance_managedInstance_EnclaveOptions = null;
            
             // populate EnclaveOptions
            var requestManagedInstance_managedInstance_EnclaveOptionsIsNull = true;
            requestManagedInstance_managedInstance_EnclaveOptions = new Amazon.WorkspacesInstances.Model.EnclaveOptionsRequest();
            System.Boolean? requestManagedInstance_managedInstance_EnclaveOptions_enclaveOptions_Enabled = null;
            if (cmdletContext.EnclaveOptions_Enabled != null)
            {
                requestManagedInstance_managedInstance_EnclaveOptions_enclaveOptions_Enabled = cmdletContext.EnclaveOptions_Enabled.Value;
            }
            if (requestManagedInstance_managedInstance_EnclaveOptions_enclaveOptions_Enabled != null)
            {
                requestManagedInstance_managedInstance_EnclaveOptions.Enabled = requestManagedInstance_managedInstance_EnclaveOptions_enclaveOptions_Enabled.Value;
                requestManagedInstance_managedInstance_EnclaveOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_EnclaveOptions should be set to null
            if (requestManagedInstance_managedInstance_EnclaveOptionsIsNull)
            {
                requestManagedInstance_managedInstance_EnclaveOptions = null;
            }
            if (requestManagedInstance_managedInstance_EnclaveOptions != null)
            {
                request.ManagedInstance.EnclaveOptions = requestManagedInstance_managedInstance_EnclaveOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.HibernationOptionsRequest requestManagedInstance_managedInstance_HibernationOptions = null;
            
             // populate HibernationOptions
            var requestManagedInstance_managedInstance_HibernationOptionsIsNull = true;
            requestManagedInstance_managedInstance_HibernationOptions = new Amazon.WorkspacesInstances.Model.HibernationOptionsRequest();
            System.Boolean? requestManagedInstance_managedInstance_HibernationOptions_hibernationOptions_Configured = null;
            if (cmdletContext.HibernationOptions_Configured != null)
            {
                requestManagedInstance_managedInstance_HibernationOptions_hibernationOptions_Configured = cmdletContext.HibernationOptions_Configured.Value;
            }
            if (requestManagedInstance_managedInstance_HibernationOptions_hibernationOptions_Configured != null)
            {
                requestManagedInstance_managedInstance_HibernationOptions.Configured = requestManagedInstance_managedInstance_HibernationOptions_hibernationOptions_Configured.Value;
                requestManagedInstance_managedInstance_HibernationOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_HibernationOptions should be set to null
            if (requestManagedInstance_managedInstance_HibernationOptionsIsNull)
            {
                requestManagedInstance_managedInstance_HibernationOptions = null;
            }
            if (requestManagedInstance_managedInstance_HibernationOptions != null)
            {
                request.ManagedInstance.HibernationOptions = requestManagedInstance_managedInstance_HibernationOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.InstanceMaintenanceOptionsRequest requestManagedInstance_managedInstance_MaintenanceOptions = null;
            
             // populate MaintenanceOptions
            var requestManagedInstance_managedInstance_MaintenanceOptionsIsNull = true;
            requestManagedInstance_managedInstance_MaintenanceOptions = new Amazon.WorkspacesInstances.Model.InstanceMaintenanceOptionsRequest();
            Amazon.WorkspacesInstances.AutoRecoveryEnum requestManagedInstance_managedInstance_MaintenanceOptions_maintenanceOptions_AutoRecovery = null;
            if (cmdletContext.MaintenanceOptions_AutoRecovery != null)
            {
                requestManagedInstance_managedInstance_MaintenanceOptions_maintenanceOptions_AutoRecovery = cmdletContext.MaintenanceOptions_AutoRecovery;
            }
            if (requestManagedInstance_managedInstance_MaintenanceOptions_maintenanceOptions_AutoRecovery != null)
            {
                requestManagedInstance_managedInstance_MaintenanceOptions.AutoRecovery = requestManagedInstance_managedInstance_MaintenanceOptions_maintenanceOptions_AutoRecovery;
                requestManagedInstance_managedInstance_MaintenanceOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_MaintenanceOptions should be set to null
            if (requestManagedInstance_managedInstance_MaintenanceOptionsIsNull)
            {
                requestManagedInstance_managedInstance_MaintenanceOptions = null;
            }
            if (requestManagedInstance_managedInstance_MaintenanceOptions != null)
            {
                request.ManagedInstance.MaintenanceOptions = requestManagedInstance_managedInstance_MaintenanceOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.RunInstancesMonitoringEnabled requestManagedInstance_managedInstance_Monitoring = null;
            
             // populate Monitoring
            var requestManagedInstance_managedInstance_MonitoringIsNull = true;
            requestManagedInstance_managedInstance_Monitoring = new Amazon.WorkspacesInstances.Model.RunInstancesMonitoringEnabled();
            System.Boolean? requestManagedInstance_managedInstance_Monitoring_monitoring_Enabled = null;
            if (cmdletContext.Monitoring_Enabled != null)
            {
                requestManagedInstance_managedInstance_Monitoring_monitoring_Enabled = cmdletContext.Monitoring_Enabled.Value;
            }
            if (requestManagedInstance_managedInstance_Monitoring_monitoring_Enabled != null)
            {
                requestManagedInstance_managedInstance_Monitoring.Enabled = requestManagedInstance_managedInstance_Monitoring_monitoring_Enabled.Value;
                requestManagedInstance_managedInstance_MonitoringIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_Monitoring should be set to null
            if (requestManagedInstance_managedInstance_MonitoringIsNull)
            {
                requestManagedInstance_managedInstance_Monitoring = null;
            }
            if (requestManagedInstance_managedInstance_Monitoring != null)
            {
                request.ManagedInstance.Monitoring = requestManagedInstance_managedInstance_Monitoring;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.InstanceNetworkPerformanceOptionsRequest requestManagedInstance_managedInstance_NetworkPerformanceOptions = null;
            
             // populate NetworkPerformanceOptions
            var requestManagedInstance_managedInstance_NetworkPerformanceOptionsIsNull = true;
            requestManagedInstance_managedInstance_NetworkPerformanceOptions = new Amazon.WorkspacesInstances.Model.InstanceNetworkPerformanceOptionsRequest();
            Amazon.WorkspacesInstances.BandwidthWeightingEnum requestManagedInstance_managedInstance_NetworkPerformanceOptions_networkPerformanceOptions_BandwidthWeighting = null;
            if (cmdletContext.NetworkPerformanceOptions_BandwidthWeighting != null)
            {
                requestManagedInstance_managedInstance_NetworkPerformanceOptions_networkPerformanceOptions_BandwidthWeighting = cmdletContext.NetworkPerformanceOptions_BandwidthWeighting;
            }
            if (requestManagedInstance_managedInstance_NetworkPerformanceOptions_networkPerformanceOptions_BandwidthWeighting != null)
            {
                requestManagedInstance_managedInstance_NetworkPerformanceOptions.BandwidthWeighting = requestManagedInstance_managedInstance_NetworkPerformanceOptions_networkPerformanceOptions_BandwidthWeighting;
                requestManagedInstance_managedInstance_NetworkPerformanceOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_NetworkPerformanceOptions should be set to null
            if (requestManagedInstance_managedInstance_NetworkPerformanceOptionsIsNull)
            {
                requestManagedInstance_managedInstance_NetworkPerformanceOptions = null;
            }
            if (requestManagedInstance_managedInstance_NetworkPerformanceOptions != null)
            {
                request.ManagedInstance.NetworkPerformanceOptions = requestManagedInstance_managedInstance_NetworkPerformanceOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.CapacityReservationSpecification requestManagedInstance_managedInstance_CapacityReservationSpecification = null;
            
             // populate CapacityReservationSpecification
            var requestManagedInstance_managedInstance_CapacityReservationSpecificationIsNull = true;
            requestManagedInstance_managedInstance_CapacityReservationSpecification = new Amazon.WorkspacesInstances.Model.CapacityReservationSpecification();
            Amazon.WorkspacesInstances.CapacityReservationPreferenceEnum requestManagedInstance_managedInstance_CapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = cmdletContext.CapacityReservationSpecification_CapacityReservationPreference;
            }
            if (requestManagedInstance_managedInstance_CapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification.CapacityReservationPreference = requestManagedInstance_managedInstance_CapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference;
                requestManagedInstance_managedInstance_CapacityReservationSpecificationIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.CapacityReservationTarget requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget = null;
            
             // populate CapacityReservationTarget
            var requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTargetIsNull = true;
            requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget = new Amazon.WorkspacesInstances.Model.CapacityReservationTarget();
            System.String requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationId != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = cmdletContext.CapacityReservationTarget_CapacityReservationId;
            }
            if (requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget.CapacityReservationId = requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId;
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            }
            if (requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget.CapacityReservationResourceGroupArn = requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn;
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget should be set to null
            if (requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTargetIsNull)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget = null;
            }
            if (requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget != null)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification.CapacityReservationTarget = requestManagedInstance_managedInstance_CapacityReservationSpecification_managedInstance_CapacityReservationSpecification_CapacityReservationTarget;
                requestManagedInstance_managedInstance_CapacityReservationSpecificationIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_CapacityReservationSpecification should be set to null
            if (requestManagedInstance_managedInstance_CapacityReservationSpecificationIsNull)
            {
                requestManagedInstance_managedInstance_CapacityReservationSpecification = null;
            }
            if (requestManagedInstance_managedInstance_CapacityReservationSpecification != null)
            {
                request.ManagedInstance.CapacityReservationSpecification = requestManagedInstance_managedInstance_CapacityReservationSpecification;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.IamInstanceProfileSpecification requestManagedInstance_managedInstance_IamInstanceProfile = null;
            
             // populate IamInstanceProfile
            var requestManagedInstance_managedInstance_IamInstanceProfileIsNull = true;
            requestManagedInstance_managedInstance_IamInstanceProfile = new Amazon.WorkspacesInstances.Model.IamInstanceProfileSpecification();
            System.String requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Arn = null;
            if (cmdletContext.IamInstanceProfile_Arn != null)
            {
                requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Arn = cmdletContext.IamInstanceProfile_Arn;
            }
            if (requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Arn != null)
            {
                requestManagedInstance_managedInstance_IamInstanceProfile.Arn = requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Arn;
                requestManagedInstance_managedInstance_IamInstanceProfileIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Name = null;
            if (cmdletContext.IamInstanceProfile_Name != null)
            {
                requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Name = cmdletContext.IamInstanceProfile_Name;
            }
            if (requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Name != null)
            {
                requestManagedInstance_managedInstance_IamInstanceProfile.Name = requestManagedInstance_managedInstance_IamInstanceProfile_iamInstanceProfile_Name;
                requestManagedInstance_managedInstance_IamInstanceProfileIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_IamInstanceProfile should be set to null
            if (requestManagedInstance_managedInstance_IamInstanceProfileIsNull)
            {
                requestManagedInstance_managedInstance_IamInstanceProfile = null;
            }
            if (requestManagedInstance_managedInstance_IamInstanceProfile != null)
            {
                request.ManagedInstance.IamInstanceProfile = requestManagedInstance_managedInstance_IamInstanceProfile;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.InstanceMarketOptionsRequest requestManagedInstance_managedInstance_InstanceMarketOptions = null;
            
             // populate InstanceMarketOptions
            var requestManagedInstance_managedInstance_InstanceMarketOptionsIsNull = true;
            requestManagedInstance_managedInstance_InstanceMarketOptions = new Amazon.WorkspacesInstances.Model.InstanceMarketOptionsRequest();
            Amazon.WorkspacesInstances.MarketTypeEnum requestManagedInstance_managedInstance_InstanceMarketOptions_instanceMarketOptions_MarketType = null;
            if (cmdletContext.InstanceMarketOptions_MarketType != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_instanceMarketOptions_MarketType = cmdletContext.InstanceMarketOptions_MarketType;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_instanceMarketOptions_MarketType != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions.MarketType = requestManagedInstance_managedInstance_InstanceMarketOptions_instanceMarketOptions_MarketType;
                requestManagedInstance_managedInstance_InstanceMarketOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.SpotMarketOptions requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions = null;
            
             // populate SpotOptions
            var requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull = true;
            requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions = new Amazon.WorkspacesInstances.Model.SpotMarketOptions();
            System.Int32? requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_BlockDurationMinute = null;
            if (cmdletContext.SpotOptions_BlockDurationMinute != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_BlockDurationMinute = cmdletContext.SpotOptions_BlockDurationMinute.Value;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_BlockDurationMinute != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions.BlockDurationMinutes = requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_BlockDurationMinute.Value;
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.InstanceInterruptionBehaviorEnum requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_InstanceInterruptionBehavior = null;
            if (cmdletContext.SpotOptions_InstanceInterruptionBehavior != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_InstanceInterruptionBehavior = cmdletContext.SpotOptions_InstanceInterruptionBehavior;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_InstanceInterruptionBehavior != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions.InstanceInterruptionBehavior = requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_InstanceInterruptionBehavior;
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_MaxPrice = null;
            if (cmdletContext.SpotOptions_MaxPrice != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_MaxPrice = cmdletContext.SpotOptions_MaxPrice;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_MaxPrice != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions.MaxPrice = requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_MaxPrice;
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.SpotInstanceTypeEnum requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_SpotInstanceType = null;
            if (cmdletContext.SpotOptions_SpotInstanceType != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_SpotInstanceType = cmdletContext.SpotOptions_SpotInstanceType;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_SpotInstanceType != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions.SpotInstanceType = requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_SpotInstanceType;
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull = false;
            }
            System.DateTime? requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_ValidUntilUtc = null;
            if (cmdletContext.SpotOptions_ValidUntilUtc != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_ValidUntilUtc = cmdletContext.SpotOptions_ValidUntilUtc.Value;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_ValidUntilUtc != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions.ValidUntilUtc = requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions_spotOptions_ValidUntilUtc.Value;
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions should be set to null
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptionsIsNull)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions = null;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions != null)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions.SpotOptions = requestManagedInstance_managedInstance_InstanceMarketOptions_managedInstance_InstanceMarketOptions_SpotOptions;
                requestManagedInstance_managedInstance_InstanceMarketOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_InstanceMarketOptions should be set to null
            if (requestManagedInstance_managedInstance_InstanceMarketOptionsIsNull)
            {
                requestManagedInstance_managedInstance_InstanceMarketOptions = null;
            }
            if (requestManagedInstance_managedInstance_InstanceMarketOptions != null)
            {
                request.ManagedInstance.InstanceMarketOptions = requestManagedInstance_managedInstance_InstanceMarketOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.CpuOptionsRequest requestManagedInstance_managedInstance_CpuOptions = null;
            
             // populate CpuOptions
            var requestManagedInstance_managedInstance_CpuOptionsIsNull = true;
            requestManagedInstance_managedInstance_CpuOptions = new Amazon.WorkspacesInstances.Model.CpuOptionsRequest();
            Amazon.WorkspacesInstances.AmdSevSnpEnum requestManagedInstance_managedInstance_CpuOptions_cpuOptions_AmdSevSnp = null;
            if (cmdletContext.CpuOptions_AmdSevSnp != null)
            {
                requestManagedInstance_managedInstance_CpuOptions_cpuOptions_AmdSevSnp = cmdletContext.CpuOptions_AmdSevSnp;
            }
            if (requestManagedInstance_managedInstance_CpuOptions_cpuOptions_AmdSevSnp != null)
            {
                requestManagedInstance_managedInstance_CpuOptions.AmdSevSnp = requestManagedInstance_managedInstance_CpuOptions_cpuOptions_AmdSevSnp;
                requestManagedInstance_managedInstance_CpuOptionsIsNull = false;
            }
            System.Int32? requestManagedInstance_managedInstance_CpuOptions_cpuOptions_CoreCount = null;
            if (cmdletContext.CpuOptions_CoreCount != null)
            {
                requestManagedInstance_managedInstance_CpuOptions_cpuOptions_CoreCount = cmdletContext.CpuOptions_CoreCount.Value;
            }
            if (requestManagedInstance_managedInstance_CpuOptions_cpuOptions_CoreCount != null)
            {
                requestManagedInstance_managedInstance_CpuOptions.CoreCount = requestManagedInstance_managedInstance_CpuOptions_cpuOptions_CoreCount.Value;
                requestManagedInstance_managedInstance_CpuOptionsIsNull = false;
            }
            System.Int32? requestManagedInstance_managedInstance_CpuOptions_cpuOptions_ThreadsPerCore = null;
            if (cmdletContext.CpuOptions_ThreadsPerCore != null)
            {
                requestManagedInstance_managedInstance_CpuOptions_cpuOptions_ThreadsPerCore = cmdletContext.CpuOptions_ThreadsPerCore.Value;
            }
            if (requestManagedInstance_managedInstance_CpuOptions_cpuOptions_ThreadsPerCore != null)
            {
                requestManagedInstance_managedInstance_CpuOptions.ThreadsPerCore = requestManagedInstance_managedInstance_CpuOptions_cpuOptions_ThreadsPerCore.Value;
                requestManagedInstance_managedInstance_CpuOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_CpuOptions should be set to null
            if (requestManagedInstance_managedInstance_CpuOptionsIsNull)
            {
                requestManagedInstance_managedInstance_CpuOptions = null;
            }
            if (requestManagedInstance_managedInstance_CpuOptions != null)
            {
                request.ManagedInstance.CpuOptions = requestManagedInstance_managedInstance_CpuOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.PrivateDnsNameOptionsRequest requestManagedInstance_managedInstance_PrivateDnsNameOptions = null;
            
             // populate PrivateDnsNameOptions
            var requestManagedInstance_managedInstance_PrivateDnsNameOptionsIsNull = true;
            requestManagedInstance_managedInstance_PrivateDnsNameOptions = new Amazon.WorkspacesInstances.Model.PrivateDnsNameOptionsRequest();
            System.Boolean? requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord = null;
            if (cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord != null)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord = cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord.Value;
            }
            if (requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord != null)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions.EnableResourceNameDnsAAAARecord = requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord.Value;
                requestManagedInstance_managedInstance_PrivateDnsNameOptionsIsNull = false;
            }
            System.Boolean? requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord = null;
            if (cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsARecord != null)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord = cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsARecord.Value;
            }
            if (requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord != null)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions.EnableResourceNameDnsARecord = requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord.Value;
                requestManagedInstance_managedInstance_PrivateDnsNameOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.HostnameTypeEnum requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_HostnameType = null;
            if (cmdletContext.PrivateDnsNameOptions_HostnameType != null)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_HostnameType = cmdletContext.PrivateDnsNameOptions_HostnameType;
            }
            if (requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_HostnameType != null)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions.HostnameType = requestManagedInstance_managedInstance_PrivateDnsNameOptions_privateDnsNameOptions_HostnameType;
                requestManagedInstance_managedInstance_PrivateDnsNameOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_PrivateDnsNameOptions should be set to null
            if (requestManagedInstance_managedInstance_PrivateDnsNameOptionsIsNull)
            {
                requestManagedInstance_managedInstance_PrivateDnsNameOptions = null;
            }
            if (requestManagedInstance_managedInstance_PrivateDnsNameOptions != null)
            {
                request.ManagedInstance.PrivateDnsNameOptions = requestManagedInstance_managedInstance_PrivateDnsNameOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.InstanceMetadataOptionsRequest requestManagedInstance_managedInstance_MetadataOptions = null;
            
             // populate MetadataOptions
            var requestManagedInstance_managedInstance_MetadataOptionsIsNull = true;
            requestManagedInstance_managedInstance_MetadataOptions = new Amazon.WorkspacesInstances.Model.InstanceMetadataOptionsRequest();
            Amazon.WorkspacesInstances.HttpEndpointEnum requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpEndpoint = null;
            if (cmdletContext.MetadataOptions_HttpEndpoint != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpEndpoint = cmdletContext.MetadataOptions_HttpEndpoint;
            }
            if (requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpEndpoint != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions.HttpEndpoint = requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpEndpoint;
                requestManagedInstance_managedInstance_MetadataOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.HttpProtocolIpv6Enum requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpProtocolIpv6 = null;
            if (cmdletContext.MetadataOptions_HttpProtocolIpv6 != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpProtocolIpv6 = cmdletContext.MetadataOptions_HttpProtocolIpv6;
            }
            if (requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpProtocolIpv6 != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions.HttpProtocolIpv6 = requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpProtocolIpv6;
                requestManagedInstance_managedInstance_MetadataOptionsIsNull = false;
            }
            System.Int32? requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpPutResponseHopLimit = null;
            if (cmdletContext.MetadataOptions_HttpPutResponseHopLimit != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpPutResponseHopLimit = cmdletContext.MetadataOptions_HttpPutResponseHopLimit.Value;
            }
            if (requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpPutResponseHopLimit != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions.HttpPutResponseHopLimit = requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpPutResponseHopLimit.Value;
                requestManagedInstance_managedInstance_MetadataOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.HttpTokensEnum requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpToken = null;
            if (cmdletContext.MetadataOptions_HttpToken != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpToken = cmdletContext.MetadataOptions_HttpToken;
            }
            if (requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpToken != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions.HttpTokens = requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_HttpToken;
                requestManagedInstance_managedInstance_MetadataOptionsIsNull = false;
            }
            Amazon.WorkspacesInstances.InstanceMetadataTagsEnum requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_InstanceMetadataTag = null;
            if (cmdletContext.MetadataOptions_InstanceMetadataTag != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_InstanceMetadataTag = cmdletContext.MetadataOptions_InstanceMetadataTag;
            }
            if (requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_InstanceMetadataTag != null)
            {
                requestManagedInstance_managedInstance_MetadataOptions.InstanceMetadataTags = requestManagedInstance_managedInstance_MetadataOptions_metadataOptions_InstanceMetadataTag;
                requestManagedInstance_managedInstance_MetadataOptionsIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_MetadataOptions should be set to null
            if (requestManagedInstance_managedInstance_MetadataOptionsIsNull)
            {
                requestManagedInstance_managedInstance_MetadataOptions = null;
            }
            if (requestManagedInstance_managedInstance_MetadataOptions != null)
            {
                request.ManagedInstance.MetadataOptions = requestManagedInstance_managedInstance_MetadataOptions;
                requestManagedInstanceIsNull = false;
            }
            Amazon.WorkspacesInstances.Model.Placement requestManagedInstance_managedInstance_Placement = null;
            
             // populate Placement
            var requestManagedInstance_managedInstance_PlacementIsNull = true;
            requestManagedInstance_managedInstance_Placement = new Amazon.WorkspacesInstances.Model.Placement();
            System.String requestManagedInstance_managedInstance_Placement_placement_Affinity = null;
            if (cmdletContext.Placement_Affinity != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_Affinity = cmdletContext.Placement_Affinity;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_Affinity != null)
            {
                requestManagedInstance_managedInstance_Placement.Affinity = requestManagedInstance_managedInstance_Placement_placement_Affinity;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_Placement_placement_AvailabilityZone = null;
            if (cmdletContext.Placement_AvailabilityZone != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_AvailabilityZone = cmdletContext.Placement_AvailabilityZone;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_AvailabilityZone != null)
            {
                requestManagedInstance_managedInstance_Placement.AvailabilityZone = requestManagedInstance_managedInstance_Placement_placement_AvailabilityZone;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_Placement_placement_GroupId = null;
            if (cmdletContext.Placement_GroupId != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_GroupId = cmdletContext.Placement_GroupId;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_GroupId != null)
            {
                requestManagedInstance_managedInstance_Placement.GroupId = requestManagedInstance_managedInstance_Placement_placement_GroupId;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_Placement_placement_GroupName = null;
            if (cmdletContext.Placement_GroupName != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_GroupName = cmdletContext.Placement_GroupName;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_GroupName != null)
            {
                requestManagedInstance_managedInstance_Placement.GroupName = requestManagedInstance_managedInstance_Placement_placement_GroupName;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_Placement_placement_HostId = null;
            if (cmdletContext.Placement_HostId != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_HostId = cmdletContext.Placement_HostId;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_HostId != null)
            {
                requestManagedInstance_managedInstance_Placement.HostId = requestManagedInstance_managedInstance_Placement_placement_HostId;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            System.String requestManagedInstance_managedInstance_Placement_placement_HostResourceGroupArn = null;
            if (cmdletContext.Placement_HostResourceGroupArn != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_HostResourceGroupArn = cmdletContext.Placement_HostResourceGroupArn;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_HostResourceGroupArn != null)
            {
                requestManagedInstance_managedInstance_Placement.HostResourceGroupArn = requestManagedInstance_managedInstance_Placement_placement_HostResourceGroupArn;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            System.Int32? requestManagedInstance_managedInstance_Placement_placement_PartitionNumber = null;
            if (cmdletContext.Placement_PartitionNumber != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_PartitionNumber = cmdletContext.Placement_PartitionNumber.Value;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_PartitionNumber != null)
            {
                requestManagedInstance_managedInstance_Placement.PartitionNumber = requestManagedInstance_managedInstance_Placement_placement_PartitionNumber.Value;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
            Amazon.WorkspacesInstances.TenancyEnum requestManagedInstance_managedInstance_Placement_placement_Tenancy = null;
            if (cmdletContext.Placement_Tenancy != null)
            {
                requestManagedInstance_managedInstance_Placement_placement_Tenancy = cmdletContext.Placement_Tenancy;
            }
            if (requestManagedInstance_managedInstance_Placement_placement_Tenancy != null)
            {
                requestManagedInstance_managedInstance_Placement.Tenancy = requestManagedInstance_managedInstance_Placement_placement_Tenancy;
                requestManagedInstance_managedInstance_PlacementIsNull = false;
            }
             // determine if requestManagedInstance_managedInstance_Placement should be set to null
            if (requestManagedInstance_managedInstance_PlacementIsNull)
            {
                requestManagedInstance_managedInstance_Placement = null;
            }
            if (requestManagedInstance_managedInstance_Placement != null)
            {
                request.ManagedInstance.Placement = requestManagedInstance_managedInstance_Placement;
                requestManagedInstanceIsNull = false;
            }
             // determine if request.ManagedInstance should be set to null
            if (requestManagedInstanceIsNull)
            {
                request.ManagedInstance = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse CallAWSServiceOperation(IAmazonWorkspacesInstances client, Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Workspaces Instances", "CreateWorkspaceInstance");
            try
            {
                #if DESKTOP
                return client.CreateWorkspaceInstance(request);
                #elif CORECLR
                return client.CreateWorkspaceInstanceAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.WorkspacesInstances.BillingMode BillingConfiguration_BillingMode { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.WorkspacesInstances.Model.BlockDeviceMappingRequest> ManagedInstance_BlockDeviceMapping { get; set; }
            public Amazon.WorkspacesInstances.CapacityReservationPreferenceEnum CapacityReservationSpecification_CapacityReservationPreference { get; set; }
            public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
            public System.String CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
            public Amazon.WorkspacesInstances.AmdSevSnpEnum CpuOptions_AmdSevSnp { get; set; }
            public System.Int32? CpuOptions_CoreCount { get; set; }
            public System.Int32? CpuOptions_ThreadsPerCore { get; set; }
            public Amazon.WorkspacesInstances.CpuCreditsEnum CreditSpecification_CpuCredit { get; set; }
            public System.Boolean? ManagedInstance_DisableApiStop { get; set; }
            public System.Boolean? ManagedInstance_EbsOptimized { get; set; }
            public System.Boolean? ManagedInstance_EnablePrimaryIpv6 { get; set; }
            public System.Boolean? EnclaveOptions_Enabled { get; set; }
            public System.Boolean? HibernationOptions_Configured { get; set; }
            public System.String IamInstanceProfile_Arn { get; set; }
            public System.String IamInstanceProfile_Name { get; set; }
            public System.String ManagedInstance_ImageId { get; set; }
            public Amazon.WorkspacesInstances.MarketTypeEnum InstanceMarketOptions_MarketType { get; set; }
            public System.Int32? SpotOptions_BlockDurationMinute { get; set; }
            public Amazon.WorkspacesInstances.InstanceInterruptionBehaviorEnum SpotOptions_InstanceInterruptionBehavior { get; set; }
            public System.String SpotOptions_MaxPrice { get; set; }
            public Amazon.WorkspacesInstances.SpotInstanceTypeEnum SpotOptions_SpotInstanceType { get; set; }
            public System.DateTime? SpotOptions_ValidUntilUtc { get; set; }
            public System.String ManagedInstance_InstanceType { get; set; }
            public System.Int32? ManagedInstance_Ipv6AddressCount { get; set; }
            public List<Amazon.WorkspacesInstances.Model.InstanceIpv6Address> ManagedInstance_Ipv6Address { get; set; }
            public System.String ManagedInstance_KernelId { get; set; }
            public System.String ManagedInstance_KeyName { get; set; }
            public List<Amazon.WorkspacesInstances.Model.LicenseConfigurationRequest> ManagedInstance_LicenseSpecification { get; set; }
            public Amazon.WorkspacesInstances.AutoRecoveryEnum MaintenanceOptions_AutoRecovery { get; set; }
            public Amazon.WorkspacesInstances.HttpEndpointEnum MetadataOptions_HttpEndpoint { get; set; }
            public Amazon.WorkspacesInstances.HttpProtocolIpv6Enum MetadataOptions_HttpProtocolIpv6 { get; set; }
            public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
            public Amazon.WorkspacesInstances.HttpTokensEnum MetadataOptions_HttpToken { get; set; }
            public Amazon.WorkspacesInstances.InstanceMetadataTagsEnum MetadataOptions_InstanceMetadataTag { get; set; }
            public System.Boolean? Monitoring_Enabled { get; set; }
            public List<Amazon.WorkspacesInstances.Model.InstanceNetworkInterfaceSpecification> ManagedInstance_NetworkInterface { get; set; }
            public Amazon.WorkspacesInstances.BandwidthWeightingEnum NetworkPerformanceOptions_BandwidthWeighting { get; set; }
            public System.String Placement_Affinity { get; set; }
            public System.String Placement_AvailabilityZone { get; set; }
            public System.String Placement_GroupId { get; set; }
            public System.String Placement_GroupName { get; set; }
            public System.String Placement_HostId { get; set; }
            public System.String Placement_HostResourceGroupArn { get; set; }
            public System.Int32? Placement_PartitionNumber { get; set; }
            public Amazon.WorkspacesInstances.TenancyEnum Placement_Tenancy { get; set; }
            public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord { get; set; }
            public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsARecord { get; set; }
            public Amazon.WorkspacesInstances.HostnameTypeEnum PrivateDnsNameOptions_HostnameType { get; set; }
            public System.String ManagedInstance_PrivateIpAddress { get; set; }
            public System.String ManagedInstance_RamdiskId { get; set; }
            public List<System.String> ManagedInstance_SecurityGroupId { get; set; }
            public List<System.String> ManagedInstance_SecurityGroup { get; set; }
            public System.String ManagedInstance_SubnetId { get; set; }
            public List<Amazon.WorkspacesInstances.Model.TagSpecification> ManagedInstance_TagSpecification { get; set; }
            public System.String ManagedInstance_UserData { get; set; }
            public List<Amazon.WorkspacesInstances.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WorkspacesInstances.Model.CreateWorkspaceInstanceResponse, NewWKSIWorkspaceInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkspaceInstanceId;
        }
        
    }
}
