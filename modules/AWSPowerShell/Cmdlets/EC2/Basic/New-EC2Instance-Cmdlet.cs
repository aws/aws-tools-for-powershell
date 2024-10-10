/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Launches the specified number of instances using an AMI for which you have permissions.
    /// 
    ///  
    /// <para>
    /// You can specify a number of options, or leave the default options. The following rules
    /// apply:
    /// </para><ul><li><para>
    /// If you don't specify a subnet ID, we choose a default subnet from your default VPC
    /// for you. If you don't have a default VPC, you must specify a subnet ID in the request.
    /// </para></li><li><para>
    /// All instances have a network interface with a primary private IPv4 address. If you
    /// don't specify this address, we choose one from the IPv4 range of your subnet.
    /// </para></li><li><para>
    /// Not all instance types support IPv6 addresses. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
    /// types</a>.
    /// </para></li><li><para>
    /// If you don't specify a security group ID, we use the default security group for the
    /// VPC. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-network-security.html">Security
    /// groups</a>.
    /// </para></li><li><para>
    /// If any of the AMIs have a product code attached for which the user has not subscribed,
    /// the request fails.
    /// </para></li></ul><para>
    /// You can create a <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html">launch
    /// template</a>, which is a resource that contains the parameters to launch an instance.
    /// When you launch an instance using <a>RunInstances</a>, you can specify the launch
    /// template instead of specifying the launch parameters.
    /// </para><para>
    /// To ensure faster instance launches, break up large requests into smaller batches.
    /// For example, create five separate launch requests for 100 instances each instead of
    /// one launch request for 500 instances.
    /// </para><para><c>RunInstances</c> is subject to both request rate limiting and resource rate limiting.
    /// For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-throttling.html">Request
    /// throttling</a>.
    /// </para><para>
    /// An instance is ready for you to use when it's in the <c>running</c> state. You can
    /// check the state of your instance using <a>DescribeInstances</a>. You can tag instances
    /// and EBS volumes during launch, after launch, or both. For more information, see <a>CreateTags</a>
    /// and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html">Tagging
    /// your Amazon EC2 resources</a>.
    /// </para><para>
    /// Linux instances have access to the public key of the key pair at boot. You can use
    /// this key to provide secure access to the instance. Amazon EC2 public images use this
    /// feature to provide secure access without passwords. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Key
    /// pairs</a>.
    /// </para><para>
    /// For troubleshooting, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_InstanceStraightToTerminated.html">What
    /// to do if an instance immediately terminates</a>, and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/TroubleshootingInstancesConnecting.html">Troubleshooting
    /// connecting to your instance</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Instance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Reservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RunInstances API operation.", Operation = new[] {"RunInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.RunInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Reservation or Amazon.EC2.Model.RunInstancesResponse",
        "This cmdlet returns an Amazon.EC2.Model.Reservation object.",
        "The service call response (type Amazon.EC2.Model.RunInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalInfo
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalInfo { get; set; }
        #endregion
        
        #region Parameter Placement_Affinity
        /// <summary>
        /// <para>
        /// <para>The affinity setting for the instance on the Dedicated Host.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateFleet">CreateFleet</a>
        /// or <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ImportInstance.html">ImportInstance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Affinity")]
        public System.String Placement_Affinity { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceProfile_Arn")]
        public System.String IamInstanceProfile_Arn { get; set; }
        #endregion
        
        #region Parameter MaintenanceOptions_AutoRecovery
        /// <summary>
        /// <para>
        /// <para>Disables the automatic recovery behavior of your instance or sets it to default. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-recover.html#instance-configuration-recovery">Simplified
        /// automatic recovery</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceAutoRecoveryState")]
        public Amazon.EC2.InstanceAutoRecoveryState MaintenanceOptions_AutoRecovery { get; set; }
        #endregion
        
        #region Parameter Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone of the instance.</para><para>If not specified, an Availability Zone will be automatically chosen for you based
        /// on the load balancing criteria for the Region.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateFleet">CreateFleet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZone")]
        public System.String Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>The block device mapping, which defines the EBS volumes and instance store volumes
        /// to attach to the instance at launch. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block
        /// device mappings</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation in which to run the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId")]
        public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter CapacityReservationSpecification_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>Indicates the instance's Capacity Reservation preferences. Possible preferences include:</para><ul><li><para><c>open</c> - The instance can run in any <c>open</c> Capacity Reservation that has
        /// matching attributes (instance type, platform, Availability Zone).</para></li><li><para><c>none</c> - The instance avoids running in a Capacity Reservation even if one is
        /// available. The instance runs as an On-Demand Instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationPreference")]
        public Amazon.EC2.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Capacity Reservation resource group in which to run the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn")]
        public System.String CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter HibernationOptions_Configured
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to enable your instance for hibernation.</para><para>For Spot Instances, if you set <c>Configured</c> to <c>true</c>, either omit the <c>InstanceInterruptionBehavior</c>
        /// parameter (for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_SpotMarketOptions.html"><c>SpotMarketOptions</c></a>), or set it to <c>hibernate</c>. When <c>Configured</c>
        /// is true:</para><ul><li><para>If you omit <c>InstanceInterruptionBehavior</c>, it defaults to <c>hibernate</c>.</para></li><li><para>If you set <c>InstanceInterruptionBehavior</c> to a value other than <c>hibernate</c>,
        /// you'll get an error.</para></li></ul><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HibernationOptions_Configured { get; set; }
        #endregion
        
        #region Parameter CreditSpecification_CpuCredit
        /// <summary>
        /// <para>
        /// <para>The credit option for CPU usage of a T instance.</para><para>Valid values: <c>standard</c> | <c>unlimited</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CpuCredit","CreditSpecification_CpuCredits")]
        public System.String CreditSpecification_CpuCredit { get; set; }
        #endregion
        
        #region Parameter CpuOption
        /// <summary>
        /// <para>
        /// <para>The CPU options for the instance. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-optimize-cpu.html">Optimize
        /// CPU options</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CpuOptions")]
        public Amazon.EC2.Model.CpuOptionsRequest CpuOption { get; set; }
        #endregion
        
        #region Parameter DisableApiStop
        /// <summary>
        /// <para>
        /// <para>Indicates whether an instance is enabled for stop protection. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Stop_Start.html#Using_StopProtection">Stop
        /// protection</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableApiStop { get; set; }
        #endregion
        
        #region Parameter DisableApiTermination
        /// <summary>
        /// <para>
        /// <para>If you set this parameter to <c>true</c>, you can't terminate the instance using the
        /// Amazon EC2 console, CLI, or API; otherwise, you can. To change this attribute after
        /// launch, use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ModifyInstanceAttribute.html">ModifyInstanceAttribute</a>.
        /// Alternatively, if you set <c>InstanceInitiatedShutdownBehavior</c> to <c>terminate</c>,
        /// you can terminate the instance by running the shutdown command from the instance.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableApiTermination { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instance is optimized for Amazon EBS I/O. This optimization
        /// provides dedicated throughput to Amazon EBS and an optimized configuration stack to
        /// provide optimal Amazon EBS I/O performance. This optimization isn't available with
        /// all instance types. Additional usage charges apply when using an EBS-optimized instance.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EbsOptimized { get; set; }
        #endregion
        
        #region Parameter ElasticGpuSpecification
        /// <summary>
        /// <para>
        /// <para>An elastic GPU to associate with the instance.</para><note><para>Amazon Elastic Graphics reached end of life on January 8, 2024.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.ElasticGpuSpecification[] ElasticGpuSpecification { get; set; }
        #endregion
        
        #region Parameter ElasticInferenceAccelerator
        /// <summary>
        /// <para>
        /// <para>An elastic inference accelerator to associate with the instance.</para><note><para>Amazon Elastic Inference is no longer available.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticInferenceAccelerators")]
        public Amazon.EC2.Model.ElasticInferenceAccelerator[] ElasticInferenceAccelerator { get; set; }
        #endregion
        
        #region Parameter EnclaveOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>To enable the instance for Amazon Web Services Nitro Enclaves, set this parameter
        /// to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnclaveOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter EnablePrimaryIpv6
        /// <summary>
        /// <para>
        /// <para>If you’re launching an instance into a dual-stack or IPv6-only subnet, you can enable
        /// assigning a primary IPv6 address. A primary IPv6 address is an IPv6 GUA address associated
        /// with an ENI that you have enabled to use a primary IPv6 address. Use this option if
        /// an instance relies on its IPv6 address not changing. When you launch the instance,
        /// Amazon Web Services will automatically assign an IPv6 address associated with the
        /// ENI attached to your instance to be the primary IPv6 address. Once you enable an IPv6
        /// GUA address to be a primary IPv6, you cannot disable it. When you enable an IPv6 GUA
        /// address to be a primary IPv6, the first IPv6 GUA will be made the primary IPv6 address
        /// until the instance is terminated or the network interface is detached. If you have
        /// multiple IPv6 addresses associated with an ENI attached to your instance and you enable
        /// a primary IPv6 address, the first IPv6 GUA address associated with the ENI becomes
        /// the primary IPv6 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePrimaryIpv6 { get; set; }
        #endregion
        
        #region Parameter PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord
        /// <summary>
        /// <para>
        /// <para>Indicates whether to respond to DNS queries for instance hostnames with DNS AAAA records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord { get; set; }
        #endregion
        
        #region Parameter PrivateDnsNameOptions_EnableResourceNameDnsARecord
        /// <summary>
        /// <para>
        /// <para>Indicates whether to respond to DNS queries for instance hostnames with DNS A records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsARecord { get; set; }
        #endregion
        
        #region Parameter Placement_GroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the placement group that the instance is in. If you specify <c>GroupId</c>,
        /// you can't specify <c>GroupName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Placement_GroupId { get; set; }
        #endregion
        
        #region Parameter Placement_GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group that the instance is in. If you specify <c>GroupName</c>,
        /// you can't specify <c>GroupId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementGroup")]
        public System.String Placement_GroupName { get; set; }
        #endregion
        
        #region Parameter Placement_HostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Dedicated Host on which the instance resides.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateFleet">CreateFleet</a>
        /// or <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ImportInstance.html">ImportInstance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HostId","Placement_Host")]
        public System.String Placement_HostId { get; set; }
        #endregion
        
        #region Parameter PrivateDnsNameOptions_HostnameType
        /// <summary>
        /// <para>
        /// <para>The type of hostname for EC2 instances. For IPv4 only subnets, an instance DNS name
        /// must be based on the instance IPv4 address. For IPv6 only subnets, an instance DNS
        /// name must be based on the instance ID. For dual-stack subnets, you can specify whether
        /// DNS names use the instance IPv4 address or the instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostnameType")]
        public Amazon.EC2.HostnameType PrivateDnsNameOptions_HostnameType { get; set; }
        #endregion
        
        #region Parameter Placement_HostResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the host resource group in which to launch the instances.</para><para>If you specify this parameter, either omit the <b>Tenancy</b> parameter or set it
        /// to <c>host</c>.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateFleet">CreateFleet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Placement_HostResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>Enables or disables the HTTP metadata endpoint on your instances.</para><para>If you specify a value of <c>disabled</c>, you cannot access your instance metadata.</para><para>Default: <c>enabled</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceMetadataEndpointState")]
        public Amazon.EC2.InstanceMetadataEndpointState MetadataOptions_HttpEndpoint { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpProtocolIpv6
        /// <summary>
        /// <para>
        /// <para>Enables or disables the IPv6 endpoint for the instance metadata service.</para><para>Default: <c>disabled</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceMetadataProtocolState")]
        public Amazon.EC2.InstanceMetadataProtocolState MetadataOptions_HttpProtocolIpv6 { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of hops that the metadata token can travel.</para><para>Possible values: Integers from 1 to 64</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpToken
        /// <summary>
        /// <para>
        /// <para>Indicates whether IMDSv2 is required.</para><ul><li><para><c>optional</c> - IMDSv2 is optional, which means that you can use either IMDSv2
        /// or IMDSv1.</para></li><li><para><c>required</c> - IMDSv2 is required, which means that IMDSv1 is disabled, and you
        /// must use IMDSv2.</para></li></ul><para>Default:</para><ul><li><para>If the value of <c>ImdsSupport</c> for the Amazon Machine Image (AMI) for your instance
        /// is <c>v2.0</c> and the account level default is set to <c>no-preference</c>, the default
        /// is <c>required</c>.</para></li><li><para>If the value of <c>ImdsSupport</c> for the Amazon Machine Image (AMI) for your instance
        /// is <c>v2.0</c>, but the account level default is set to <c>V1 or V2</c>, the default
        /// is <c>optional</c>.</para></li></ul><para>The default value can also be affected by other combinations of parameters. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/configuring-instance-metadata-options.html#instance-metadata-options-order-of-precedence">Order
        /// of precedence for instance metadata options</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataOptions_HttpTokens")]
        [AWSConstantClassSource("Amazon.EC2.HttpTokensState")]
        public Amazon.EC2.HttpTokensState MetadataOptions_HttpToken { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI. An AMI ID is required to launch an instance and must be specified
        /// here or in a launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter InstanceInitiatedShutdownBehavior
        /// <summary>
        /// <para>
        /// <para>Indicates whether an instance stops or terminates when you initiate shutdown from
        /// the instance (using the operating system command for system shutdown).</para><para>Default: <c>stop</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ShutdownBehavior")]
        public Amazon.EC2.ShutdownBehavior InstanceInitiatedShutdownBehavior { get; set; }
        #endregion
        
        #region Parameter InstanceMarketOption
        /// <summary>
        /// <para>
        /// <para>The market (purchasing) option for the instances.</para><para>For <a>RunInstances</a>, persistent Spot Instance requests are only supported when
        /// <b>InstanceInterruptionBehavior</b> is set to either <c>hibernate</c> or <c>stop</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceMarketOptions")]
        public Amazon.EC2.Model.InstanceMarketOptionsRequest InstanceMarketOption { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_InstanceMetadataTag
        /// <summary>
        /// <para>
        /// <para>Set to <c>enabled</c> to allow access to instance tags from the instance metadata.
        /// Set to <c>disabled</c> to turn off access to instance tags from the instance metadata.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html#work-with-tags-in-IMDS">Work
        /// with instance tags using the instance metadata</a>.</para><para>Default: <c>disabled</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataOptions_InstanceMetadataTags")]
        [AWSConstantClassSource("Amazon.EC2.InstanceMetadataTagsState")]
        public Amazon.EC2.InstanceMetadataTagsState MetadataOptions_InstanceMetadataTag { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Amazon
        /// EC2 instance types</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceType")]
        public Amazon.EC2.InstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter Ipv6AddressCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv6 addresses to associate with the primary network interface. Amazon
        /// EC2 chooses the IPv6 addresses from the range of your subnet. You cannot specify this
        /// option and the option to assign specific IPv6 addresses in the same request. You can
        /// specify this option if you've specified a minimum number of instances to launch.</para><para>You cannot specify this option and the network interfaces option in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>The IPv6 addresses from the range of the subnet to associate with the primary network
        /// interface. You cannot specify this option and the option to assign a number of IPv6
        /// addresses in the same request. You cannot specify this option if you've specified
        /// a minimum number of instances to launch.</para><para>You cannot specify this option and the network interfaces option in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv6Addresses")]
        public Amazon.EC2.Model.InstanceIpv6Address[] Ipv6Address { get; set; }
        #endregion
        
        #region Parameter KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel.</para><important><para>We recommend that you use PV-GRUB instead of kernels and RAM disks. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedkernels.html">PV-GRUB</a>
        /// in the <i>Amazon EC2 User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KernelId { get; set; }
        #endregion
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the key pair. You can create a key pair using <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateKeyPair.html">CreateKeyPair</a>
        /// or <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ImportKeyPair.html">ImportKeyPair</a>.</para><important><para>If you do not specify a key pair, you can't connect to the instance unless you choose
        /// an AMI that is configured to allow users another way to log in.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyName { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate
        /// <summary>
        /// <para>
        /// <para>The launch template. Any additional parameters that you specify for the new instance
        /// overwrite the corresponding parameters included in the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.LaunchTemplateSpecification LaunchTemplate { get; set; }
        #endregion
        
        #region Parameter LicenseSpecification
        /// <summary>
        /// <para>
        /// <para>The license configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseSpecifications")]
        public Amazon.EC2.Model.LicenseConfigurationRequest[] LicenseSpecification { get; set; }
        #endregion
        
        #region Parameter MaxCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances to launch. If you specify a value that is more capacity
        /// than Amazon EC2 can launch in the target Availability Zone, Amazon EC2 launches the
        /// largest possible number of instances above the specified minimum count.</para><para>Constraints: Between 1 and the quota for the specified instance type for your account
        /// for this Region. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-instance-quotas.html">Amazon
        /// EC2 instance type quotas</a>.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>1</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCount { get; set; }
        #endregion
        
        #region Parameter MinCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of instances to launch. If you specify a value that is more capacity
        /// than Amazon EC2 can provide in the target Availability Zone, Amazon EC2 does not launch
        /// any instances.</para><para>Constraints: Between 1 and the quota for the specified instance type for your account
        /// for this Region. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/instancetypes/ec2-instance-quotas.html">Amazon
        /// EC2 instance type quotas</a>.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>1</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinCount { get; set; }
        #endregion
        
        #region Parameter Monitoring
        /// <summary>
        /// <para>
        /// <para>Specifies whether detailed monitoring is enabled for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Monitoring_Enabled")]
        public System.Boolean? Monitoring { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Name
        /// <summary>
        /// <para>
        /// <para>The name of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceProfile_Id","InstanceProfile_Name")]
        public System.String IamInstanceProfile_Name { get; set; }
        #endregion
        
        #region Parameter NetworkInterface
        /// <summary>
        /// <para>
        /// <para>The network interfaces to associate with the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkInterfaces","NetworkInterfaceSet")]
        public Amazon.EC2.Model.InstanceNetworkInterfaceSpecification[] NetworkInterface { get; set; }
        #endregion
        
        #region Parameter Placement_PartitionNumber
        /// <summary>
        /// <para>
        /// <para>The number of the partition that the instance is in. Valid only if the placement group
        /// strategy is set to <c>partition</c>.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateFleet">CreateFleet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Placement_PartitionNumber { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The primary IPv4 address. You must specify a value from the IPv4 address range of
        /// the subnet.</para><para>Only one private IP address can be designated as primary. You can't specify this option
        /// if you've specified the option to designate a private IP address as the primary IP
        /// address in a network interface specification. You cannot specify this option if you're
        /// launching more than one instance in the request.</para><para>You cannot specify this option and the network interfaces option in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk to select. Some kernels require additional drivers at launch.
        /// Check the kernel requirements for information about whether you need to specify a
        /// RAM disk. To find kernel requirements, go to the Amazon Web Services Resource Center
        /// and search for the kernel ID.</para><important><para>We recommend that you use PV-GRUB instead of kernels and RAM disks. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedkernels.html">PV-GRUB</a>
        /// in the <i>Amazon EC2 User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RamdiskId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups. You can create a security group using <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateSecurityGroup.html">CreateSecurityGroup</a>.</para><para>If you specify a network interface, you must specify any security groups as part of
        /// the network interface instead of using this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>[Default VPC] The names of the security groups.</para><para>If you specify a network interface, you must specify any security groups as part of
        /// the network interface instead of using this parameter.</para><para>Default: Amazon EC2 uses the default security group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Placement_SpreadDomain
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Placement_SpreadDomain { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to launch the instance into.</para><para>If you specify a network interface, you must specify any subnets as part of the network
        /// interface instead of using this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the resources that are created during instance launch.</para><para>You can specify tags for the following resources only:</para><ul><li><para>Instances</para></li><li><para>Volumes</para></li><li><para>Spot Instance requests</para></li><li><para>Network interfaces</para></li></ul><para>To tag a resource after it has been created, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateTags.html">CreateTags</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Placement_Tenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instance. An instance with a tenancy of <c>dedicated</c> runs on
        /// single-tenant hardware.</para><para>This parameter is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateFleet">CreateFleet</a>.
        /// The <c>host</c> tenancy is not supported for <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ImportInstance.html">ImportInstance</a>
        /// or for T3 instances that are configured for the <c>unlimited</c> CPU credit option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tenancy")]
        [AWSConstantClassSource("Amazon.EC2.Tenancy")]
        public Amazon.EC2.Tenancy Placement_Tenancy { get; set; }
        #endregion
        
        #region Parameter UserData
        /// <summary>
        /// The base64-encoded MIME user data for the instances. If the -EncodeUserData switch is also set, the value for this parameter can be supplied as normal ASCII text and will be base64-encoded by the cmdlet.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserData { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// If you do not specify a client token, a randomly generated token is used for the request
        /// to ensure idempotency.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para><para>Constraints: Maximum 64 ASCII characters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Reservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RunInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RunInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Reservation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Instance (RunInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RunInstancesResponse, NewEC2InstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdditionalInfo = this.AdditionalInfo;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMapping = new List<Amazon.EC2.Model.BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.CapacityReservationSpecification_CapacityReservationPreference = this.CapacityReservationSpecification_CapacityReservationPreference;
            context.CapacityReservationTarget_CapacityReservationId = this.CapacityReservationTarget_CapacityReservationId;
            context.CapacityReservationTarget_CapacityReservationResourceGroupArn = this.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            context.ClientToken = this.ClientToken;
            context.CpuOption = this.CpuOption;
            context.CreditSpecification_CpuCredit = this.CreditSpecification_CpuCredit;
            context.DisableApiStop = this.DisableApiStop;
            context.DisableApiTermination = this.DisableApiTermination;
            context.EbsOptimized = this.EbsOptimized;
            if (this.ElasticGpuSpecification != null)
            {
                context.ElasticGpuSpecification = new List<Amazon.EC2.Model.ElasticGpuSpecification>(this.ElasticGpuSpecification);
            }
            if (this.ElasticInferenceAccelerator != null)
            {
                context.ElasticInferenceAccelerator = new List<Amazon.EC2.Model.ElasticInferenceAccelerator>(this.ElasticInferenceAccelerator);
            }
            context.EnablePrimaryIpv6 = this.EnablePrimaryIpv6;
            context.EnclaveOptions_Enabled = this.EnclaveOptions_Enabled;
            context.HibernationOptions_Configured = this.HibernationOptions_Configured;
            context.IamInstanceProfile_Arn = this.IamInstanceProfile_Arn;
            context.IamInstanceProfile_Name = this.IamInstanceProfile_Name;
            context.ImageId = this.ImageId;
            context.InstanceInitiatedShutdownBehavior = this.InstanceInitiatedShutdownBehavior;
            context.InstanceMarketOption = this.InstanceMarketOption;
            context.InstanceType = this.InstanceType;
            context.Ipv6AddressCount = this.Ipv6AddressCount;
            if (this.Ipv6Address != null)
            {
                context.Ipv6Address = new List<Amazon.EC2.Model.InstanceIpv6Address>(this.Ipv6Address);
            }
            context.KernelId = this.KernelId;
            context.KeyName = this.KeyName;
            context.LaunchTemplate = this.LaunchTemplate;
            if (this.LicenseSpecification != null)
            {
                context.LicenseSpecification = new List<Amazon.EC2.Model.LicenseConfigurationRequest>(this.LicenseSpecification);
            }
            context.MaintenanceOptions_AutoRecovery = this.MaintenanceOptions_AutoRecovery;
            context.MaxCount = this.MaxCount;
            if (!ParameterWasBound(nameof(this.MaxCount)))
            {
                WriteVerbose("MaxCount parameter unset, using default value of '1'");
                context.MaxCount = 1;
            }
            #if MODULAR
            if (this.MaxCount == null && ParameterWasBound(nameof(this.MaxCount)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataOptions_HttpEndpoint = this.MetadataOptions_HttpEndpoint;
            context.MetadataOptions_HttpProtocolIpv6 = this.MetadataOptions_HttpProtocolIpv6;
            context.MetadataOptions_HttpPutResponseHopLimit = this.MetadataOptions_HttpPutResponseHopLimit;
            context.MetadataOptions_HttpToken = this.MetadataOptions_HttpToken;
            context.MetadataOptions_InstanceMetadataTag = this.MetadataOptions_InstanceMetadataTag;
            context.MinCount = this.MinCount;
            if (!ParameterWasBound(nameof(this.MinCount)))
            {
                WriteVerbose("MinCount parameter unset, using default value of '1'");
                context.MinCount = 1;
            }
            #if MODULAR
            if (this.MinCount == null && ParameterWasBound(nameof(this.MinCount)))
            {
                WriteWarning("You are passing $null as a value for parameter MinCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Monitoring = this.Monitoring;
            if (this.NetworkInterface != null)
            {
                context.NetworkInterface = new List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification>(this.NetworkInterface);
            }
            context.Placement_Affinity = this.Placement_Affinity;
            context.Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.Placement_GroupId = this.Placement_GroupId;
            context.Placement_GroupName = this.Placement_GroupName;
            context.Placement_HostId = this.Placement_HostId;
            context.Placement_HostResourceGroupArn = this.Placement_HostResourceGroupArn;
            context.Placement_PartitionNumber = this.Placement_PartitionNumber;
            context.Placement_SpreadDomain = this.Placement_SpreadDomain;
            context.Placement_Tenancy = this.Placement_Tenancy;
            context.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord = this.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord;
            context.PrivateDnsNameOptions_EnableResourceNameDnsARecord = this.PrivateDnsNameOptions_EnableResourceNameDnsARecord;
            context.PrivateDnsNameOptions_HostnameType = this.PrivateDnsNameOptions_HostnameType;
            context.PrivateIpAddress = this.PrivateIpAddress;
            context.RamdiskId = this.RamdiskId;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
            }
            context.SubnetId = this.SubnetId;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.UserData = this.UserData;
            
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
            var request = new Amazon.EC2.Model.RunInstancesRequest();
            
            if (cmdletContext.AdditionalInfo != null)
            {
                request.AdditionalInfo = cmdletContext.AdditionalInfo;
            }
            if (cmdletContext.BlockDeviceMapping != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMapping;
            }
            
             // populate CapacityReservationSpecification
            var requestCapacityReservationSpecificationIsNull = true;
            request.CapacityReservationSpecification = new Amazon.EC2.Model.CapacityReservationSpecification();
            Amazon.EC2.CapacityReservationPreference requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = cmdletContext.CapacityReservationSpecification_CapacityReservationPreference;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference != null)
            {
                request.CapacityReservationSpecification.CapacityReservationPreference = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference;
                requestCapacityReservationSpecificationIsNull = false;
            }
            Amazon.EC2.Model.CapacityReservationTarget requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            
             // populate CapacityReservationTarget
            var requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = true;
            requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = new Amazon.EC2.Model.CapacityReservationTarget();
            System.String requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = cmdletContext.CapacityReservationTarget_CapacityReservationId;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationId = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId;
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
            System.String requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationResourceGroupArn = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn;
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
             // determine if requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget should be set to null
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget != null)
            {
                request.CapacityReservationSpecification.CapacityReservationTarget = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget;
                requestCapacityReservationSpecificationIsNull = false;
            }
             // determine if request.CapacityReservationSpecification should be set to null
            if (requestCapacityReservationSpecificationIsNull)
            {
                request.CapacityReservationSpecification = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CpuOption != null)
            {
                request.CpuOptions = cmdletContext.CpuOption;
            }
            
             // populate CreditSpecification
            var requestCreditSpecificationIsNull = true;
            request.CreditSpecification = new Amazon.EC2.Model.CreditSpecificationRequest();
            System.String requestCreditSpecification_creditSpecification_CpuCredit = null;
            if (cmdletContext.CreditSpecification_CpuCredit != null)
            {
                requestCreditSpecification_creditSpecification_CpuCredit = cmdletContext.CreditSpecification_CpuCredit;
            }
            if (requestCreditSpecification_creditSpecification_CpuCredit != null)
            {
                request.CreditSpecification.CpuCredits = requestCreditSpecification_creditSpecification_CpuCredit;
                requestCreditSpecificationIsNull = false;
            }
             // determine if request.CreditSpecification should be set to null
            if (requestCreditSpecificationIsNull)
            {
                request.CreditSpecification = null;
            }
            if (cmdletContext.DisableApiStop != null)
            {
                request.DisableApiStop = cmdletContext.DisableApiStop.Value;
            }
            if (cmdletContext.DisableApiTermination != null)
            {
                request.DisableApiTermination = cmdletContext.DisableApiTermination.Value;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            if (cmdletContext.ElasticGpuSpecification != null)
            {
                request.ElasticGpuSpecification = cmdletContext.ElasticGpuSpecification;
            }
            if (cmdletContext.ElasticInferenceAccelerator != null)
            {
                request.ElasticInferenceAccelerators = cmdletContext.ElasticInferenceAccelerator;
            }
            if (cmdletContext.EnablePrimaryIpv6 != null)
            {
                request.EnablePrimaryIpv6 = cmdletContext.EnablePrimaryIpv6.Value;
            }
            
             // populate EnclaveOptions
            var requestEnclaveOptionsIsNull = true;
            request.EnclaveOptions = new Amazon.EC2.Model.EnclaveOptionsRequest();
            System.Boolean? requestEnclaveOptions_enclaveOptions_Enabled = null;
            if (cmdletContext.EnclaveOptions_Enabled != null)
            {
                requestEnclaveOptions_enclaveOptions_Enabled = cmdletContext.EnclaveOptions_Enabled.Value;
            }
            if (requestEnclaveOptions_enclaveOptions_Enabled != null)
            {
                request.EnclaveOptions.Enabled = requestEnclaveOptions_enclaveOptions_Enabled.Value;
                requestEnclaveOptionsIsNull = false;
            }
             // determine if request.EnclaveOptions should be set to null
            if (requestEnclaveOptionsIsNull)
            {
                request.EnclaveOptions = null;
            }
            
             // populate HibernationOptions
            var requestHibernationOptionsIsNull = true;
            request.HibernationOptions = new Amazon.EC2.Model.HibernationOptionsRequest();
            System.Boolean? requestHibernationOptions_hibernationOptions_Configured = null;
            if (cmdletContext.HibernationOptions_Configured != null)
            {
                requestHibernationOptions_hibernationOptions_Configured = cmdletContext.HibernationOptions_Configured.Value;
            }
            if (requestHibernationOptions_hibernationOptions_Configured != null)
            {
                request.HibernationOptions.Configured = requestHibernationOptions_hibernationOptions_Configured.Value;
                requestHibernationOptionsIsNull = false;
            }
             // determine if request.HibernationOptions should be set to null
            if (requestHibernationOptionsIsNull)
            {
                request.HibernationOptions = null;
            }
            
             // populate IamInstanceProfile
            var requestIamInstanceProfileIsNull = true;
            request.IamInstanceProfile = new Amazon.EC2.Model.IamInstanceProfileSpecification();
            System.String requestIamInstanceProfile_iamInstanceProfile_Arn = null;
            if (cmdletContext.IamInstanceProfile_Arn != null)
            {
                requestIamInstanceProfile_iamInstanceProfile_Arn = cmdletContext.IamInstanceProfile_Arn;
            }
            if (requestIamInstanceProfile_iamInstanceProfile_Arn != null)
            {
                request.IamInstanceProfile.Arn = requestIamInstanceProfile_iamInstanceProfile_Arn;
                requestIamInstanceProfileIsNull = false;
            }
            System.String requestIamInstanceProfile_iamInstanceProfile_Name = null;
            if (cmdletContext.IamInstanceProfile_Name != null)
            {
                requestIamInstanceProfile_iamInstanceProfile_Name = cmdletContext.IamInstanceProfile_Name;
            }
            if (requestIamInstanceProfile_iamInstanceProfile_Name != null)
            {
                request.IamInstanceProfile.Name = requestIamInstanceProfile_iamInstanceProfile_Name;
                requestIamInstanceProfileIsNull = false;
            }
             // determine if request.IamInstanceProfile should be set to null
            if (requestIamInstanceProfileIsNull)
            {
                request.IamInstanceProfile = null;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            if (cmdletContext.InstanceInitiatedShutdownBehavior != null)
            {
                request.InstanceInitiatedShutdownBehavior = cmdletContext.InstanceInitiatedShutdownBehavior;
            }
            if (cmdletContext.InstanceMarketOption != null)
            {
                request.InstanceMarketOptions = cmdletContext.InstanceMarketOption;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.Ipv6AddressCount != null)
            {
                request.Ipv6AddressCount = cmdletContext.Ipv6AddressCount.Value;
            }
            if (cmdletContext.Ipv6Address != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Address;
            }
            if (cmdletContext.KernelId != null)
            {
                request.KernelId = cmdletContext.KernelId;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.LaunchTemplate != null)
            {
                request.LaunchTemplate = cmdletContext.LaunchTemplate;
            }
            if (cmdletContext.LicenseSpecification != null)
            {
                request.LicenseSpecifications = cmdletContext.LicenseSpecification;
            }
            
             // populate MaintenanceOptions
            var requestMaintenanceOptionsIsNull = true;
            request.MaintenanceOptions = new Amazon.EC2.Model.InstanceMaintenanceOptionsRequest();
            Amazon.EC2.InstanceAutoRecoveryState requestMaintenanceOptions_maintenanceOptions_AutoRecovery = null;
            if (cmdletContext.MaintenanceOptions_AutoRecovery != null)
            {
                requestMaintenanceOptions_maintenanceOptions_AutoRecovery = cmdletContext.MaintenanceOptions_AutoRecovery;
            }
            if (requestMaintenanceOptions_maintenanceOptions_AutoRecovery != null)
            {
                request.MaintenanceOptions.AutoRecovery = requestMaintenanceOptions_maintenanceOptions_AutoRecovery;
                requestMaintenanceOptionsIsNull = false;
            }
             // determine if request.MaintenanceOptions should be set to null
            if (requestMaintenanceOptionsIsNull)
            {
                request.MaintenanceOptions = null;
            }
            if (cmdletContext.MaxCount != null)
            {
                request.MaxCount = cmdletContext.MaxCount.Value;
            }
            
             // populate MetadataOptions
            var requestMetadataOptionsIsNull = true;
            request.MetadataOptions = new Amazon.EC2.Model.InstanceMetadataOptionsRequest();
            Amazon.EC2.InstanceMetadataEndpointState requestMetadataOptions_metadataOptions_HttpEndpoint = null;
            if (cmdletContext.MetadataOptions_HttpEndpoint != null)
            {
                requestMetadataOptions_metadataOptions_HttpEndpoint = cmdletContext.MetadataOptions_HttpEndpoint;
            }
            if (requestMetadataOptions_metadataOptions_HttpEndpoint != null)
            {
                request.MetadataOptions.HttpEndpoint = requestMetadataOptions_metadataOptions_HttpEndpoint;
                requestMetadataOptionsIsNull = false;
            }
            Amazon.EC2.InstanceMetadataProtocolState requestMetadataOptions_metadataOptions_HttpProtocolIpv6 = null;
            if (cmdletContext.MetadataOptions_HttpProtocolIpv6 != null)
            {
                requestMetadataOptions_metadataOptions_HttpProtocolIpv6 = cmdletContext.MetadataOptions_HttpProtocolIpv6;
            }
            if (requestMetadataOptions_metadataOptions_HttpProtocolIpv6 != null)
            {
                request.MetadataOptions.HttpProtocolIpv6 = requestMetadataOptions_metadataOptions_HttpProtocolIpv6;
                requestMetadataOptionsIsNull = false;
            }
            System.Int32? requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit = null;
            if (cmdletContext.MetadataOptions_HttpPutResponseHopLimit != null)
            {
                requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit = cmdletContext.MetadataOptions_HttpPutResponseHopLimit.Value;
            }
            if (requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit != null)
            {
                request.MetadataOptions.HttpPutResponseHopLimit = requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit.Value;
                requestMetadataOptionsIsNull = false;
            }
            Amazon.EC2.HttpTokensState requestMetadataOptions_metadataOptions_HttpToken = null;
            if (cmdletContext.MetadataOptions_HttpToken != null)
            {
                requestMetadataOptions_metadataOptions_HttpToken = cmdletContext.MetadataOptions_HttpToken;
            }
            if (requestMetadataOptions_metadataOptions_HttpToken != null)
            {
                request.MetadataOptions.HttpTokens = requestMetadataOptions_metadataOptions_HttpToken;
                requestMetadataOptionsIsNull = false;
            }
            Amazon.EC2.InstanceMetadataTagsState requestMetadataOptions_metadataOptions_InstanceMetadataTag = null;
            if (cmdletContext.MetadataOptions_InstanceMetadataTag != null)
            {
                requestMetadataOptions_metadataOptions_InstanceMetadataTag = cmdletContext.MetadataOptions_InstanceMetadataTag;
            }
            if (requestMetadataOptions_metadataOptions_InstanceMetadataTag != null)
            {
                request.MetadataOptions.InstanceMetadataTags = requestMetadataOptions_metadataOptions_InstanceMetadataTag;
                requestMetadataOptionsIsNull = false;
            }
             // determine if request.MetadataOptions should be set to null
            if (requestMetadataOptionsIsNull)
            {
                request.MetadataOptions = null;
            }
            if (cmdletContext.MinCount != null)
            {
                request.MinCount = cmdletContext.MinCount.Value;
            }
            if (cmdletContext.Monitoring != null)
            {
                request.Monitoring = cmdletContext.Monitoring.Value;
            }
            if (cmdletContext.NetworkInterface != null)
            {
                request.NetworkInterfaces = cmdletContext.NetworkInterface;
            }
            
             // populate Placement
            var requestPlacementIsNull = true;
            request.Placement = new Amazon.EC2.Model.Placement();
            System.String requestPlacement_placement_Affinity = null;
            if (cmdletContext.Placement_Affinity != null)
            {
                requestPlacement_placement_Affinity = cmdletContext.Placement_Affinity;
            }
            if (requestPlacement_placement_Affinity != null)
            {
                request.Placement.Affinity = requestPlacement_placement_Affinity;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_AvailabilityZone = null;
            if (cmdletContext.Placement_AvailabilityZone != null)
            {
                requestPlacement_placement_AvailabilityZone = cmdletContext.Placement_AvailabilityZone;
            }
            if (requestPlacement_placement_AvailabilityZone != null)
            {
                request.Placement.AvailabilityZone = requestPlacement_placement_AvailabilityZone;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_GroupId = null;
            if (cmdletContext.Placement_GroupId != null)
            {
                requestPlacement_placement_GroupId = cmdletContext.Placement_GroupId;
            }
            if (requestPlacement_placement_GroupId != null)
            {
                request.Placement.GroupId = requestPlacement_placement_GroupId;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_GroupName = null;
            if (cmdletContext.Placement_GroupName != null)
            {
                requestPlacement_placement_GroupName = cmdletContext.Placement_GroupName;
            }
            if (requestPlacement_placement_GroupName != null)
            {
                request.Placement.GroupName = requestPlacement_placement_GroupName;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_HostId = null;
            if (cmdletContext.Placement_HostId != null)
            {
                requestPlacement_placement_HostId = cmdletContext.Placement_HostId;
            }
            if (requestPlacement_placement_HostId != null)
            {
                request.Placement.HostId = requestPlacement_placement_HostId;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_HostResourceGroupArn = null;
            if (cmdletContext.Placement_HostResourceGroupArn != null)
            {
                requestPlacement_placement_HostResourceGroupArn = cmdletContext.Placement_HostResourceGroupArn;
            }
            if (requestPlacement_placement_HostResourceGroupArn != null)
            {
                request.Placement.HostResourceGroupArn = requestPlacement_placement_HostResourceGroupArn;
                requestPlacementIsNull = false;
            }
            System.Int32? requestPlacement_placement_PartitionNumber = null;
            if (cmdletContext.Placement_PartitionNumber != null)
            {
                requestPlacement_placement_PartitionNumber = cmdletContext.Placement_PartitionNumber.Value;
            }
            if (requestPlacement_placement_PartitionNumber != null)
            {
                request.Placement.PartitionNumber = requestPlacement_placement_PartitionNumber.Value;
                requestPlacementIsNull = false;
            }
            System.String requestPlacement_placement_SpreadDomain = null;
            if (cmdletContext.Placement_SpreadDomain != null)
            {
                requestPlacement_placement_SpreadDomain = cmdletContext.Placement_SpreadDomain;
            }
            if (requestPlacement_placement_SpreadDomain != null)
            {
                request.Placement.SpreadDomain = requestPlacement_placement_SpreadDomain;
                requestPlacementIsNull = false;
            }
            Amazon.EC2.Tenancy requestPlacement_placement_Tenancy = null;
            if (cmdletContext.Placement_Tenancy != null)
            {
                requestPlacement_placement_Tenancy = cmdletContext.Placement_Tenancy;
            }
            if (requestPlacement_placement_Tenancy != null)
            {
                request.Placement.Tenancy = requestPlacement_placement_Tenancy;
                requestPlacementIsNull = false;
            }
             // determine if request.Placement should be set to null
            if (requestPlacementIsNull)
            {
                request.Placement = null;
            }
            
             // populate PrivateDnsNameOptions
            var requestPrivateDnsNameOptionsIsNull = true;
            request.PrivateDnsNameOptions = new Amazon.EC2.Model.PrivateDnsNameOptionsRequest();
            System.Boolean? requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord = null;
            if (cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord != null)
            {
                requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord = cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord.Value;
            }
            if (requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord != null)
            {
                request.PrivateDnsNameOptions.EnableResourceNameDnsAAAARecord = requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsAAAARecord.Value;
                requestPrivateDnsNameOptionsIsNull = false;
            }
            System.Boolean? requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord = null;
            if (cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsARecord != null)
            {
                requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord = cmdletContext.PrivateDnsNameOptions_EnableResourceNameDnsARecord.Value;
            }
            if (requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord != null)
            {
                request.PrivateDnsNameOptions.EnableResourceNameDnsARecord = requestPrivateDnsNameOptions_privateDnsNameOptions_EnableResourceNameDnsARecord.Value;
                requestPrivateDnsNameOptionsIsNull = false;
            }
            Amazon.EC2.HostnameType requestPrivateDnsNameOptions_privateDnsNameOptions_HostnameType = null;
            if (cmdletContext.PrivateDnsNameOptions_HostnameType != null)
            {
                requestPrivateDnsNameOptions_privateDnsNameOptions_HostnameType = cmdletContext.PrivateDnsNameOptions_HostnameType;
            }
            if (requestPrivateDnsNameOptions_privateDnsNameOptions_HostnameType != null)
            {
                request.PrivateDnsNameOptions.HostnameType = requestPrivateDnsNameOptions_privateDnsNameOptions_HostnameType;
                requestPrivateDnsNameOptionsIsNull = false;
            }
             // determine if request.PrivateDnsNameOptions should be set to null
            if (requestPrivateDnsNameOptionsIsNull)
            {
                request.PrivateDnsNameOptions = null;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddress = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.RamdiskId != null)
            {
                request.RamdiskId = cmdletContext.RamdiskId;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
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
        
        private Amazon.EC2.Model.RunInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RunInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RunInstances");
            try
            {
                #if DESKTOP
                return client.RunInstances(request);
                #elif CORECLR
                return client.RunInstancesAsync(request).GetAwaiter().GetResult();
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
            public System.String AdditionalInfo { get; set; }
            public List<Amazon.EC2.Model.BlockDeviceMapping> BlockDeviceMapping { get; set; }
            public Amazon.EC2.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
            public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
            public System.String CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.EC2.Model.CpuOptionsRequest CpuOption { get; set; }
            public System.String CreditSpecification_CpuCredit { get; set; }
            public System.Boolean? DisableApiStop { get; set; }
            public System.Boolean? DisableApiTermination { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public List<Amazon.EC2.Model.ElasticGpuSpecification> ElasticGpuSpecification { get; set; }
            public List<Amazon.EC2.Model.ElasticInferenceAccelerator> ElasticInferenceAccelerator { get; set; }
            public System.Boolean? EnablePrimaryIpv6 { get; set; }
            public System.Boolean? EnclaveOptions_Enabled { get; set; }
            public System.Boolean? HibernationOptions_Configured { get; set; }
            public System.String IamInstanceProfile_Arn { get; set; }
            public System.String IamInstanceProfile_Name { get; set; }
            public System.String ImageId { get; set; }
            public Amazon.EC2.ShutdownBehavior InstanceInitiatedShutdownBehavior { get; set; }
            public Amazon.EC2.Model.InstanceMarketOptionsRequest InstanceMarketOption { get; set; }
            public Amazon.EC2.InstanceType InstanceType { get; set; }
            public System.Int32? Ipv6AddressCount { get; set; }
            public List<Amazon.EC2.Model.InstanceIpv6Address> Ipv6Address { get; set; }
            public System.String KernelId { get; set; }
            public System.String KeyName { get; set; }
            public Amazon.EC2.Model.LaunchTemplateSpecification LaunchTemplate { get; set; }
            public List<Amazon.EC2.Model.LicenseConfigurationRequest> LicenseSpecification { get; set; }
            public Amazon.EC2.InstanceAutoRecoveryState MaintenanceOptions_AutoRecovery { get; set; }
            public System.Int32? MaxCount { get; set; }
            public Amazon.EC2.InstanceMetadataEndpointState MetadataOptions_HttpEndpoint { get; set; }
            public Amazon.EC2.InstanceMetadataProtocolState MetadataOptions_HttpProtocolIpv6 { get; set; }
            public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
            public Amazon.EC2.HttpTokensState MetadataOptions_HttpToken { get; set; }
            public Amazon.EC2.InstanceMetadataTagsState MetadataOptions_InstanceMetadataTag { get; set; }
            public System.Int32? MinCount { get; set; }
            public System.Boolean? Monitoring { get; set; }
            public List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification> NetworkInterface { get; set; }
            public System.String Placement_Affinity { get; set; }
            public System.String Placement_AvailabilityZone { get; set; }
            public System.String Placement_GroupId { get; set; }
            public System.String Placement_GroupName { get; set; }
            public System.String Placement_HostId { get; set; }
            public System.String Placement_HostResourceGroupArn { get; set; }
            public System.Int32? Placement_PartitionNumber { get; set; }
            public System.String Placement_SpreadDomain { get; set; }
            public Amazon.EC2.Tenancy Placement_Tenancy { get; set; }
            public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsAAAARecord { get; set; }
            public System.Boolean? PrivateDnsNameOptions_EnableResourceNameDnsARecord { get; set; }
            public Amazon.EC2.HostnameType PrivateDnsNameOptions_HostnameType { get; set; }
            public System.String PrivateIpAddress { get; set; }
            public System.String RamdiskId { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String UserData { get; set; }
            public System.Func<Amazon.EC2.Model.RunInstancesResponse, NewEC2InstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Reservation;
        }
        
    }
}
