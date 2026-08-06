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
using System.Threading;
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a capacity provider. A capacity provider defines the Amazon EC2 infrastructure
    /// for AgentCore Runtime, including the operating system, allowed instance types, networking,
    /// and storage. It also specifies the IAM permissions that AgentCore uses to manage those
    /// instances.
    /// 
    ///  
    /// <para>
    /// The capacity provider name must be unique within your account. After you create the
    /// capacity provider, it enters a <c>CREATING</c> state and transitions to <c>READY</c>
    /// when it is available for use.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BACCCapacityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateCapacityProvider API operation.", Operation = new[] {"CreateCapacityProvider"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse object containing multiple properties."
    )]
    public partial class NewBACCCapacityProviderCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>The list of allowed instance types. You can specify up to 30 instance types.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter PermissionsConfiguration_CapacityProviderOperatorRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that AgentCore assumes to manage the
        /// capacity provider, including launching, tagging, and terminating instances and their
        /// network interfaces. We recommend scoping this role to the minimum permissions that
        /// your workloads require.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PermissionsConfiguration_CapacityProviderOperatorRoleArn { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation in which to run the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>The Capacity Reservation preference for the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.CapacityReservationPreference")]
        public Amazon.BedrockAgentCoreControl.CapacityReservationPreference ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Capacity Reservation resource group in which
        /// to run the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the capacity provider. If you don't specify a description,
        /// the service creates the capacity provider without one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether to encrypt the volume. Encrypted volumes can be attached only to
        /// instances that support Amazon EBS encryption. If you create a volume from a snapshot,
        /// you cannot specify an encryption value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume
        /// <summary>
        /// <para>
        /// <para>The block device mappings for instance store (ephemeral) volumes. You can specify
        /// up to five mappings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolumes")]
        public Amazon.BedrockAgentCoreControl.Model.EphemeralBlockDeviceMapping[] ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB
        /// <summary>
        /// <para>
        /// <para>The free space guaranteed on the root volume, in GiB. AgentCore adds the operating
        /// system overhead on top of this value. The default is 8 GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout
        /// <summary>
        /// <para>
        /// <para>The number of seconds an instance can remain idle before it is stopped. An instance
        /// is considered idle when all of its agents are idle. The default is 900 seconds (15
        /// minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM instance profile to associate with launched
        /// instances. If provided, this overrides the default instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_RootVolume_Iops
        /// <summary>
        /// <para>
        /// <para>The number of IOPS to provision. For <c>gp3</c>, <c>io1</c>, and <c>io2</c> volumes,
        /// this is the number of IOPS provisioned for the volume. For <c>gp2</c> volumes, this
        /// sets the baseline IOPS performance. It also controls the rate at which the volume
        /// accumulates I/O credits for bursting. Supported values: <c>gp3</c>, 3,000–80,000;
        /// <c>io1</c>, 100–64,000; <c>io2</c>, 100–256,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_Ec2Configuration_RootVolume_Iops { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier (key ID, key alias, key ARN, or alias ARN) of the customer managed
        /// KMS key to use for Amazon EBS encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification
        /// <summary>
        /// <para>
        /// <para>The license configurations to associate with the instances. You can specify up to
        /// five configurations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecifications")]
        public Amazon.BedrockAgentCoreControl.Model.LicenseSpecification[] ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime
        /// <summary>
        /// <para>
        /// <para>The maximum lifetime of an instance, in seconds. When an instance reaches this limit,
        /// the service terminates it regardless of activity. The default is 28800 seconds (8
        /// hours). The maximum is 1209600 seconds (14 days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring
        /// <summary>
        /// <para>
        /// <para>The monitoring level for the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.Monitoring")]
        public Amazon.BedrockAgentCoreControl.Monitoring ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the capacity provider. The name must be unique within your account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem
        /// <summary>
        /// <para>
        /// <para>The operating system and CPU architecture for the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.OperatingSystem")]
        public Amazon.BedrockAgentCoreControl.OperatingSystem ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag
        /// <summary>
        /// <para>
        /// <para>The tags to propagate to all Amazon EC2 resources (instances, volumes, and network
        /// interfaces) that the capacity provider creates.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTags")]
        public System.Collections.Hashtable ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to associate with the instances. You must specify at
        /// least one security group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroups")]
        public System.String[] ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName
        /// <summary>
        /// <para>
        /// <para>The name of the SSH key pair to configure on the instances for SSH connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets in which to launch instances. You must specify at least one
        /// subnet.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnets")]
        public System.String[] ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to associate with the capacity provider. If you don't
        /// specify tags, the capacity provider is created with no tags.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_RootVolume_Throughput
        /// <summary>
        /// <para>
        /// <para>The throughput to provision, in MiB/s. Valid only for <c>gp3</c> volumes. Valid range:
        /// 125–2,000 MiB/s.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_Ec2Configuration_RootVolume_Throughput { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_Volume
        /// <summary>
        /// <para>
        /// <para>The named persistent Amazon EBS volumes for the capacity provider. A capacity provider
        /// can define up to five volumes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfiguration_Ec2Configuration_Volumes")]
        public Amazon.BedrockAgentCoreControl.Model.VolumeConfiguration[] ComputeConfiguration_Ec2Configuration_Volume { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType
        /// <summary>
        /// <para>
        /// <para>The Amazon EBS volume type. If you do not specify a type, the default is <c>gp3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.EbsVolumeType")]
        public Amazon.BedrockAgentCoreControl.EbsVolumeType ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If you don't specify this field, a value is randomly generated for
        /// you. If this token matches a previous request, the service ignores the request, but
        /// doesn't return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCCapacityProvider (CreateCapacityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse, NewBACCCapacityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference;
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId;
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn;
            if (this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume != null)
            {
                context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume = new List<Amazon.BedrockAgentCoreControl.Model.EphemeralBlockDeviceMapping>(this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume);
            }
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn;
            if (this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType != null)
            {
                context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType = new List<System.String>(this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType);
            }
            if (this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification != null)
            {
                context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification = new List<Amazon.BedrockAgentCoreControl.Model.LicenseSpecification>(this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification);
            }
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring;
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem;
            if (this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag != null)
            {
                context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag.Keys)
                {
                    context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag.Add((String)hashKey, (System.String)(this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag[hashKey]));
                }
            }
            context.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName = this.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName;
            context.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout = this.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout;
            context.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime = this.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime;
            context.ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted = this.ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted;
            context.ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB = this.ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB;
            context.ComputeConfiguration_Ec2Configuration_RootVolume_Iops = this.ComputeConfiguration_Ec2Configuration_RootVolume_Iops;
            context.ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId = this.ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId;
            context.ComputeConfiguration_Ec2Configuration_RootVolume_Throughput = this.ComputeConfiguration_Ec2Configuration_RootVolume_Throughput;
            context.ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType = this.ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType;
            if (this.ComputeConfiguration_Ec2Configuration_Volume != null)
            {
                context.ComputeConfiguration_Ec2Configuration_Volume = new List<Amazon.BedrockAgentCoreControl.Model.VolumeConfiguration>(this.ComputeConfiguration_Ec2Configuration_Volume);
            }
            if (this.ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup != null)
            {
                context.ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup = new List<System.String>(this.ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup);
            }
            if (this.ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet != null)
            {
                context.ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet = new List<System.String>(this.ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet);
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionsConfiguration_CapacityProviderOperatorRoleArn = this.PermissionsConfiguration_CapacityProviderOperatorRoleArn;
            #if MODULAR
            if (this.PermissionsConfiguration_CapacityProviderOperatorRoleArn == null && ParameterWasBound(nameof(this.PermissionsConfiguration_CapacityProviderOperatorRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionsConfiguration_CapacityProviderOperatorRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ComputeConfiguration
            var requestComputeConfigurationIsNull = true;
            request.ComputeConfiguration = new Amazon.BedrockAgentCoreControl.Model.ComputeConfiguration();
            Amazon.BedrockAgentCoreControl.Model.Ec2Configuration requestComputeConfiguration_computeConfiguration_Ec2Configuration = null;
            
             // populate Ec2Configuration
            var requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration = new Amazon.BedrockAgentCoreControl.Model.Ec2Configuration();
            List<Amazon.BedrockAgentCoreControl.Model.VolumeConfiguration> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_Volume = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_Volume != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_Volume = cmdletContext.ComputeConfiguration_Ec2Configuration_Volume;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_Volume != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration.Volumes = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_Volume;
                requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.LaunchTemplateSource requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource = null;
            
             // populate LaunchTemplateSource
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSourceIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource = new Amazon.BedrockAgentCoreControl.Model.LaunchTemplateSource();
            Amazon.BedrockAgentCoreControl.Model.LaunchParameters requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters = null;
            
             // populate LaunchParameters
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters = new Amazon.BedrockAgentCoreControl.Model.LaunchParameters();
            List<Amazon.BedrockAgentCoreControl.Model.EphemeralBlockDeviceMapping> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.EphemeralVolumes = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            System.String requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.InstanceProfileArn = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            List<Amazon.BedrockAgentCoreControl.Model.LicenseSpecification> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.LicenseSpecifications = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Monitoring requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.Monitoring = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.OperatingSystem requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.OperatingSystem = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.PropagatedTags = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            System.String requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.SshKeyName = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.InstanceRequirements requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements = null;
            
             // populate InstanceRequirements
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirementsIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements = new Amazon.BedrockAgentCoreControl.Model.InstanceRequirements();
            List<System.String> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements.AllowedInstanceTypes = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirementsIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirementsIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.InstanceRequirements = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.CapacityReservationSpecification requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification = null;
            
             // populate CapacityReservationSpecification
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecificationIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification = new Amazon.BedrockAgentCoreControl.Model.CapacityReservationSpecification();
            Amazon.BedrockAgentCoreControl.CapacityReservationPreference requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification.CapacityReservationPreference = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecificationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.CapacityReservationTarget requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget = null;
            
             // populate CapacityReservationTarget
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTargetIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget = new Amazon.BedrockAgentCoreControl.Model.CapacityReservationTarget();
            System.String requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget.CapacityReservationId = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
            System.String requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn = cmdletContext.ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget.CapacityReservationResourceGroupArn = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTargetIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification.CapacityReservationTarget = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecificationIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecificationIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters.CapacityReservationSpecification = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParametersIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource.LaunchParameters = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource_computeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSourceIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSourceIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration.LaunchTemplateSource = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LaunchTemplateSource;
                requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.InstanceLifecycleConfiguration requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration = null;
            
             // populate LifecycleConfiguration
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfigurationIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration = new Amazon.BedrockAgentCoreControl.Model.InstanceLifecycleConfiguration();
            System.Int32? requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout = cmdletContext.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration.IdleInstanceTimeout = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout.Value;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfigurationIsNull = false;
            }
            System.Int32? requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime = cmdletContext.ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration.MaxLifetime = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_computeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime.Value;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfigurationIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfigurationIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration.LifecycleConfiguration = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_LifecycleConfiguration;
                requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.VpcConfiguration requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfigurationIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration = new Amazon.BedrockAgentCoreControl.Model.VpcConfiguration();
            List<System.String> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup = cmdletContext.ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration.SecurityGroups = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_Subnet = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_Subnet = cmdletContext.ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_Subnet != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration.Subnets = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration_computeConfiguration_Ec2Configuration_VpcConfiguration_Subnet;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfigurationIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfigurationIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration.VpcConfiguration = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_VpcConfiguration;
                requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.RootVolumeConfiguration requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume = null;
            
             // populate RootVolume
            var requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = true;
            requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume = new Amazon.BedrockAgentCoreControl.Model.RootVolumeConfiguration();
            System.Boolean? requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Encrypted = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Encrypted = cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Encrypted != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume.Encrypted = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Encrypted.Value;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = false;
            }
            System.Int32? requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB = cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume.FreeSpaceGiB = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB.Value;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = false;
            }
            System.Int32? requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Iops = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_Iops != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Iops = cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_Iops.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Iops != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume.Iops = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Iops.Value;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = false;
            }
            System.String requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_KmsKeyId = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_KmsKeyId = cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_KmsKeyId != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume.KmsKeyId = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_KmsKeyId;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = false;
            }
            System.Int32? requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Throughput = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_Throughput != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Throughput = cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_Throughput.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Throughput != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume.Throughput = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_Throughput.Value;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.EbsVolumeType requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_VolumeType = null;
            if (cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_VolumeType = cmdletContext.ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_VolumeType != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume.VolumeType = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume_computeConfiguration_Ec2Configuration_RootVolume_VolumeType;
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolumeIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume != null)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration.RootVolume = requestComputeConfiguration_computeConfiguration_Ec2Configuration_computeConfiguration_Ec2Configuration_RootVolume;
                requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_Ec2Configuration should be set to null
            if (requestComputeConfiguration_computeConfiguration_Ec2ConfigurationIsNull)
            {
                requestComputeConfiguration_computeConfiguration_Ec2Configuration = null;
            }
            if (requestComputeConfiguration_computeConfiguration_Ec2Configuration != null)
            {
                request.ComputeConfiguration.Ec2Configuration = requestComputeConfiguration_computeConfiguration_Ec2Configuration;
                requestComputeConfigurationIsNull = false;
            }
             // determine if request.ComputeConfiguration should be set to null
            if (requestComputeConfigurationIsNull)
            {
                request.ComputeConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PermissionsConfiguration
            var requestPermissionsConfigurationIsNull = true;
            request.PermissionsConfiguration = new Amazon.BedrockAgentCoreControl.Model.PermissionsConfiguration();
            System.String requestPermissionsConfiguration_permissionsConfiguration_CapacityProviderOperatorRoleArn = null;
            if (cmdletContext.PermissionsConfiguration_CapacityProviderOperatorRoleArn != null)
            {
                requestPermissionsConfiguration_permissionsConfiguration_CapacityProviderOperatorRoleArn = cmdletContext.PermissionsConfiguration_CapacityProviderOperatorRoleArn;
            }
            if (requestPermissionsConfiguration_permissionsConfiguration_CapacityProviderOperatorRoleArn != null)
            {
                request.PermissionsConfiguration.CapacityProviderOperatorRoleArn = requestPermissionsConfiguration_permissionsConfiguration_CapacityProviderOperatorRoleArn;
                requestPermissionsConfigurationIsNull = false;
            }
             // determine if request.PermissionsConfiguration should be set to null
            if (requestPermissionsConfigurationIsNull)
            {
                request.PermissionsConfiguration = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateCapacityProvider");
            try
            {
                return client.CreateCapacityProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.BedrockAgentCoreControl.CapacityReservationPreference ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationPreference { get; set; }
            public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId { get; set; }
            public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.EphemeralBlockDeviceMapping> ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_EphemeralVolume { get; set; }
            public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceProfileArn { get; set; }
            public List<System.String> ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_InstanceRequirements_AllowedInstanceType { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.LicenseSpecification> ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_LicenseSpecification { get; set; }
            public Amazon.BedrockAgentCoreControl.Monitoring ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_Monitoring { get; set; }
            public Amazon.BedrockAgentCoreControl.OperatingSystem ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_OperatingSystem { get; set; }
            public Dictionary<System.String, System.String> ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_PropagatedTag { get; set; }
            public System.String ComputeConfiguration_Ec2Configuration_LaunchTemplateSource_LaunchParameters_SshKeyName { get; set; }
            public System.Int32? ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_IdleInstanceTimeout { get; set; }
            public System.Int32? ComputeConfiguration_Ec2Configuration_LifecycleConfiguration_MaxLifetime { get; set; }
            public System.Boolean? ComputeConfiguration_Ec2Configuration_RootVolume_Encrypted { get; set; }
            public System.Int32? ComputeConfiguration_Ec2Configuration_RootVolume_FreeSpaceGiB { get; set; }
            public System.Int32? ComputeConfiguration_Ec2Configuration_RootVolume_Iops { get; set; }
            public System.String ComputeConfiguration_Ec2Configuration_RootVolume_KmsKeyId { get; set; }
            public System.Int32? ComputeConfiguration_Ec2Configuration_RootVolume_Throughput { get; set; }
            public Amazon.BedrockAgentCoreControl.EbsVolumeType ComputeConfiguration_Ec2Configuration_RootVolume_VolumeType { get; set; }
            public List<Amazon.BedrockAgentCoreControl.Model.VolumeConfiguration> ComputeConfiguration_Ec2Configuration_Volume { get; set; }
            public List<System.String> ComputeConfiguration_Ec2Configuration_VpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> ComputeConfiguration_Ec2Configuration_VpcConfiguration_Subnet { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String PermissionsConfiguration_CapacityProviderOperatorRoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateCapacityProviderResponse, NewBACCCapacityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
