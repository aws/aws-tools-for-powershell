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
    /// Creates a Spot Instance request.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-requests.html">Work
    /// with Spot Instance</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><important><para>
    /// We strongly discourage using the RequestSpotInstances API because it is a legacy API
    /// with no planned investment. For options for requesting Spot Instances, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-best-practices.html#which-spot-request-method-to-use">Which
    /// is the best Spot request method to use?</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Request", "EC2SpotInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.SpotInstanceRequest")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RequestSpotInstances API operation.", Operation = new[] {"RequestSpotInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.RequestSpotInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.SpotInstanceRequest or Amazon.EC2.Model.RequestSpotInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.SpotInstanceRequest objects.",
        "The service call response (type Amazon.EC2.Model.RequestSpotInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestEC2SpotInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LaunchSpecification_AddressingType
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_AddressingType { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_AllSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_AllSecurityGroups")]
        public Amazon.EC2.Model.GroupIdentifier[] LaunchSpecification_AllSecurityGroup { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_IamInstanceProfile_Arn")]
        public System.String IamInstanceProfile_Arn { get; set; }
        #endregion
        
        #region Parameter Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone.</para><para>[Spot Fleet only] To specify multiple Availability Zones, separate them using commas;
        /// for example, "us-west-2a, us-west-2b".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_Placement_AvailabilityZone")]
        public System.String Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneGroup
        /// <summary>
        /// <para>
        /// <para>The user-specified name for a logical grouping of requests.</para><para>When you specify an Availability Zone group in a Spot Instance request, all Spot Instances
        /// in the request are launched in the same Availability Zone. Instance proximity is maintained
        /// with this parameter, but the choice of Availability Zone is not. The group applies
        /// only to requests for Spot Instances of the same instance type. Any additional Spot
        /// Instance requests that are specified with the same Availability Zone group name are
        /// launched in that same Availability Zone, as long as at least one instance from the
        /// group is still active.</para><para>If there is no active instance running in the Availability Zone group that you specify
        /// for a new Spot Instance request (all instances are terminated, the request is expired,
        /// or the maximum price you specified falls below current Spot price), then Amazon EC2
        /// launches the instance in any Availability Zone where the constraint can be met. Consequently,
        /// the subsequent set of Spot Instances could be placed in a different zone from the
        /// original request, even if you specified the same Availability Zone group.</para><para>Default: Instances are launched in any available Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneGroup { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>The block device mapping entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] LaunchSpecification_BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter BlockDurationMinute
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockDurationMinutes")]
        public System.Int32? BlockDurationMinute { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instance is optimized for EBS I/O. This optimization provides
        /// dedicated throughput to Amazon EBS and an optimized configuration stack to provide
        /// optimal EBS I/O performance. This optimization isn't available with all instance types.
        /// Additional usage charges apply when using an EBS Optimized instance.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LaunchSpecification_EbsOptimized { get; set; }
        #endregion
        
        #region Parameter Placement_GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_Placement_GroupName")]
        public System.String Placement_GroupName { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_ImageId { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of Spot Instances to launch.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter InstanceInterruptionBehavior
        /// <summary>
        /// <para>
        /// <para>The behavior when a Spot Instance is interrupted. The default is <c>terminate</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceInterruptionBehavior")]
        public Amazon.EC2.InstanceInterruptionBehavior InstanceInterruptionBehavior { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type. Only one instance type can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceType")]
        public Amazon.EC2.InstanceType LaunchSpecification_InstanceType { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_KernelId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_KeyName { get; set; }
        #endregion
        
        #region Parameter LaunchGroup
        /// <summary>
        /// <para>
        /// <para>The instance launch group. Launch groups are Spot Instances that launch together and
        /// terminate together.</para><para>Default: Instances are launched and terminated individually</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchGroup { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_MonitoringEnabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LaunchSpecification_MonitoringEnabled { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Name
        /// <summary>
        /// <para>
        /// <para>The name of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_IamInstanceProfile_Name")]
        public System.String IamInstanceProfile_Name { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_NetworkInterface
        /// <summary>
        /// <para>
        /// <para>The network interfaces. If you specify a network interface, you must specify subnet
        /// IDs and security group IDs using the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_NetworkInterfaces")]
        public Amazon.EC2.Model.InstanceNetworkInterfaceSpecification[] LaunchSpecification_NetworkInterface { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_RamdiskId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>One or more security group names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_SecurityGroups")]
        public System.String[] LaunchSpecification_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SpotPrice
        /// <summary>
        /// <para>
        /// <para>The maximum price per unit hour that you are willing to pay for a Spot Instance. We
        /// do not recommend using this parameter because it can lead to increased interruptions.
        /// If you do not specify this parameter, you will pay the current Spot price.</para><important><para>If you specify a maximum price, your instances will be interrupted more frequently
        /// than if you do not specify this parameter.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SpotPrice { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in which to launch the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The key-value pair for tagging the Spot Instance request on creation. The value for
        /// <c>ResourceType</c> must be <c>spot-instances-request</c>, otherwise the Spot Instance
        /// request fails. To tag the Spot Instance request after it has been created, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateTags.html">CreateTags</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Placement_Tenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instance (if the instance is running in a VPC). An instance with
        /// a tenancy of <c>dedicated</c> runs on single-tenant hardware. The <c>host</c> tenancy
        /// is not supported for Spot Instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchSpecification_Placement_Tenancy")]
        [AWSConstantClassSource("Amazon.EC2.Tenancy")]
        public Amazon.EC2.Tenancy Placement_Tenancy { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The Spot Instance request type.</para><para>Default: <c>one-time</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.SpotInstanceType")]
        public Amazon.EC2.SpotInstanceType Type { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_UserData
        /// <summary>
        /// <para>
        /// <para>The base64-encoded user data that instances use when starting up. User data is limited
        /// to 16 KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchSpecification_UserData { get; set; }
        #endregion
        
        #region Parameter UtcValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date of the request. If this is a one-time request, the request becomes
        /// active at this date and time and remains active until all instances launch, the request
        /// expires, or the request is canceled. If the request is persistent, the request becomes
        /// active at this date and time and remains active until it expires or is canceled.</para><para>The specified start date and time cannot be equal to the current date and time. You
        /// must specify a start date and time that occurs after the current date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcValidFrom { get; set; }
        #endregion
        
        #region Parameter UtcValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date of the request, in UTC format (<i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para><ul><li><para>For a persistent request, the request remains active until the <c>ValidUntil</c> date
        /// and time is reached. Otherwise, the request remains active until you cancel it. </para></li><li><para>For a one-time request, the request remains active until all instances launch, the
        /// request is canceled, or the <c>ValidUntil</c> date and time is reached. By default,
        /// the request is valid for 7 days from the date the request was created.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcValidUntil { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">Ensuring
        /// idempotency in Amazon EC2 API requests</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ValidFrom
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ValidFromUtc instead. Setting either ValidFrom or
        /// ValidFromUtc results in both ValidFrom and ValidFromUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. ValidFrom
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The start date of the request. If this is a one-time request, the request becomes
        /// active at this date and time and remains active until all instances launch, the request
        /// expires, or the request is canceled. If the request is persistent, the request becomes
        /// active at this date and time and remains active until it expires or is canceled.</para><para>The specified start date and time cannot be equal to the current date and time. You
        /// must specify a start date and time that occurs after the current date and time.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcValidFrom instead.")]
        public System.DateTime? ValidFrom { get; set; }
        #endregion
        
        #region Parameter ValidUntil
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ValidUntilUtc instead. Setting either ValidUntil or
        /// ValidUntilUtc results in both ValidUntil and ValidUntilUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. ValidUntil
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The end date of the request, in UTC format (<i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para><ul><li><para>For a persistent request, the request remains active until the <c>ValidUntil</c> date
        /// and time is reached. Otherwise, the request remains active until you cancel it. </para></li><li><para>For a one-time request, the request remains active until all instances launch, the
        /// request is canceled, or the <c>ValidUntil</c> date and time is reached. By default,
        /// the request is valid for 7 days from the date the request was created.</para></li></ul>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcValidUntil instead.")]
        public System.DateTime? ValidUntil { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SpotInstanceRequests'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RequestSpotInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RequestSpotInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SpotInstanceRequests";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpotPrice), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-EC2SpotInstance (RequestSpotInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RequestSpotInstancesResponse, RequestEC2SpotInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZoneGroup = this.AvailabilityZoneGroup;
            context.BlockDurationMinute = this.BlockDurationMinute;
            context.ClientToken = this.ClientToken;
            context.InstanceCount = this.InstanceCount;
            context.InstanceInterruptionBehavior = this.InstanceInterruptionBehavior;
            context.LaunchGroup = this.LaunchGroup;
            context.LaunchSpecification_AddressingType = this.LaunchSpecification_AddressingType;
            if (this.LaunchSpecification_AllSecurityGroup != null)
            {
                context.LaunchSpecification_AllSecurityGroup = new List<Amazon.EC2.Model.GroupIdentifier>(this.LaunchSpecification_AllSecurityGroup);
            }
            if (this.LaunchSpecification_BlockDeviceMapping != null)
            {
                context.LaunchSpecification_BlockDeviceMapping = new List<Amazon.EC2.Model.BlockDeviceMapping>(this.LaunchSpecification_BlockDeviceMapping);
            }
            context.LaunchSpecification_EbsOptimized = this.LaunchSpecification_EbsOptimized;
            context.IamInstanceProfile_Arn = this.IamInstanceProfile_Arn;
            context.IamInstanceProfile_Name = this.IamInstanceProfile_Name;
            context.LaunchSpecification_ImageId = this.LaunchSpecification_ImageId;
            context.LaunchSpecification_InstanceType = this.LaunchSpecification_InstanceType;
            context.LaunchSpecification_KernelId = this.LaunchSpecification_KernelId;
            context.LaunchSpecification_KeyName = this.LaunchSpecification_KeyName;
            context.LaunchSpecification_MonitoringEnabled = this.LaunchSpecification_MonitoringEnabled;
            if (this.LaunchSpecification_NetworkInterface != null)
            {
                context.LaunchSpecification_NetworkInterface = new List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification>(this.LaunchSpecification_NetworkInterface);
            }
            context.Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.Placement_GroupName = this.Placement_GroupName;
            context.Placement_Tenancy = this.Placement_Tenancy;
            context.LaunchSpecification_RamdiskId = this.LaunchSpecification_RamdiskId;
            if (this.LaunchSpecification_SecurityGroup != null)
            {
                context.LaunchSpecification_SecurityGroup = new List<System.String>(this.LaunchSpecification_SecurityGroup);
            }
            context.LaunchSpecification_SubnetId = this.LaunchSpecification_SubnetId;
            context.LaunchSpecification_UserData = this.LaunchSpecification_UserData;
            context.SpotPrice = this.SpotPrice;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Type = this.Type;
            context.UtcValidFrom = this.UtcValidFrom;
            context.UtcValidUntil = this.UtcValidUntil;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ValidFrom = this.ValidFrom;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ValidUntil = this.ValidUntil;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.EC2.Model.RequestSpotInstancesRequest();
            
            if (cmdletContext.AvailabilityZoneGroup != null)
            {
                request.AvailabilityZoneGroup = cmdletContext.AvailabilityZoneGroup;
            }
            if (cmdletContext.BlockDurationMinute != null)
            {
                request.BlockDurationMinutes = cmdletContext.BlockDurationMinute.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.InstanceInterruptionBehavior != null)
            {
                request.InstanceInterruptionBehavior = cmdletContext.InstanceInterruptionBehavior;
            }
            if (cmdletContext.LaunchGroup != null)
            {
                request.LaunchGroup = cmdletContext.LaunchGroup;
            }
            
             // populate LaunchSpecification
            var requestLaunchSpecificationIsNull = true;
            request.LaunchSpecification = new Amazon.EC2.Model.LaunchSpecification();
            System.String requestLaunchSpecification_launchSpecification_AddressingType = null;
            if (cmdletContext.LaunchSpecification_AddressingType != null)
            {
                requestLaunchSpecification_launchSpecification_AddressingType = cmdletContext.LaunchSpecification_AddressingType;
            }
            if (requestLaunchSpecification_launchSpecification_AddressingType != null)
            {
                request.LaunchSpecification.AddressingType = requestLaunchSpecification_launchSpecification_AddressingType;
                requestLaunchSpecificationIsNull = false;
            }
            List<Amazon.EC2.Model.GroupIdentifier> requestLaunchSpecification_launchSpecification_AllSecurityGroup = null;
            if (cmdletContext.LaunchSpecification_AllSecurityGroup != null)
            {
                requestLaunchSpecification_launchSpecification_AllSecurityGroup = cmdletContext.LaunchSpecification_AllSecurityGroup;
            }
            if (requestLaunchSpecification_launchSpecification_AllSecurityGroup != null)
            {
                request.LaunchSpecification.AllSecurityGroups = requestLaunchSpecification_launchSpecification_AllSecurityGroup;
                requestLaunchSpecificationIsNull = false;
            }
            List<Amazon.EC2.Model.BlockDeviceMapping> requestLaunchSpecification_launchSpecification_BlockDeviceMapping = null;
            if (cmdletContext.LaunchSpecification_BlockDeviceMapping != null)
            {
                requestLaunchSpecification_launchSpecification_BlockDeviceMapping = cmdletContext.LaunchSpecification_BlockDeviceMapping;
            }
            if (requestLaunchSpecification_launchSpecification_BlockDeviceMapping != null)
            {
                request.LaunchSpecification.BlockDeviceMappings = requestLaunchSpecification_launchSpecification_BlockDeviceMapping;
                requestLaunchSpecificationIsNull = false;
            }
            System.Boolean? requestLaunchSpecification_launchSpecification_EbsOptimized = null;
            if (cmdletContext.LaunchSpecification_EbsOptimized != null)
            {
                requestLaunchSpecification_launchSpecification_EbsOptimized = cmdletContext.LaunchSpecification_EbsOptimized.Value;
            }
            if (requestLaunchSpecification_launchSpecification_EbsOptimized != null)
            {
                request.LaunchSpecification.EbsOptimized = requestLaunchSpecification_launchSpecification_EbsOptimized.Value;
                requestLaunchSpecificationIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_ImageId = null;
            if (cmdletContext.LaunchSpecification_ImageId != null)
            {
                requestLaunchSpecification_launchSpecification_ImageId = cmdletContext.LaunchSpecification_ImageId;
            }
            if (requestLaunchSpecification_launchSpecification_ImageId != null)
            {
                request.LaunchSpecification.ImageId = requestLaunchSpecification_launchSpecification_ImageId;
                requestLaunchSpecificationIsNull = false;
            }
            Amazon.EC2.InstanceType requestLaunchSpecification_launchSpecification_InstanceType = null;
            if (cmdletContext.LaunchSpecification_InstanceType != null)
            {
                requestLaunchSpecification_launchSpecification_InstanceType = cmdletContext.LaunchSpecification_InstanceType;
            }
            if (requestLaunchSpecification_launchSpecification_InstanceType != null)
            {
                request.LaunchSpecification.InstanceType = requestLaunchSpecification_launchSpecification_InstanceType;
                requestLaunchSpecificationIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_KernelId = null;
            if (cmdletContext.LaunchSpecification_KernelId != null)
            {
                requestLaunchSpecification_launchSpecification_KernelId = cmdletContext.LaunchSpecification_KernelId;
            }
            if (requestLaunchSpecification_launchSpecification_KernelId != null)
            {
                request.LaunchSpecification.KernelId = requestLaunchSpecification_launchSpecification_KernelId;
                requestLaunchSpecificationIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_KeyName = null;
            if (cmdletContext.LaunchSpecification_KeyName != null)
            {
                requestLaunchSpecification_launchSpecification_KeyName = cmdletContext.LaunchSpecification_KeyName;
            }
            if (requestLaunchSpecification_launchSpecification_KeyName != null)
            {
                request.LaunchSpecification.KeyName = requestLaunchSpecification_launchSpecification_KeyName;
                requestLaunchSpecificationIsNull = false;
            }
            System.Boolean? requestLaunchSpecification_launchSpecification_MonitoringEnabled = null;
            if (cmdletContext.LaunchSpecification_MonitoringEnabled != null)
            {
                requestLaunchSpecification_launchSpecification_MonitoringEnabled = cmdletContext.LaunchSpecification_MonitoringEnabled.Value;
            }
            if (requestLaunchSpecification_launchSpecification_MonitoringEnabled != null)
            {
                request.LaunchSpecification.MonitoringEnabled = requestLaunchSpecification_launchSpecification_MonitoringEnabled.Value;
                requestLaunchSpecificationIsNull = false;
            }
            List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification> requestLaunchSpecification_launchSpecification_NetworkInterface = null;
            if (cmdletContext.LaunchSpecification_NetworkInterface != null)
            {
                requestLaunchSpecification_launchSpecification_NetworkInterface = cmdletContext.LaunchSpecification_NetworkInterface;
            }
            if (requestLaunchSpecification_launchSpecification_NetworkInterface != null)
            {
                request.LaunchSpecification.NetworkInterfaces = requestLaunchSpecification_launchSpecification_NetworkInterface;
                requestLaunchSpecificationIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_RamdiskId = null;
            if (cmdletContext.LaunchSpecification_RamdiskId != null)
            {
                requestLaunchSpecification_launchSpecification_RamdiskId = cmdletContext.LaunchSpecification_RamdiskId;
            }
            if (requestLaunchSpecification_launchSpecification_RamdiskId != null)
            {
                request.LaunchSpecification.RamdiskId = requestLaunchSpecification_launchSpecification_RamdiskId;
                requestLaunchSpecificationIsNull = false;
            }
            List<System.String> requestLaunchSpecification_launchSpecification_SecurityGroup = null;
            if (cmdletContext.LaunchSpecification_SecurityGroup != null)
            {
                requestLaunchSpecification_launchSpecification_SecurityGroup = cmdletContext.LaunchSpecification_SecurityGroup;
            }
            if (requestLaunchSpecification_launchSpecification_SecurityGroup != null)
            {
                request.LaunchSpecification.SecurityGroups = requestLaunchSpecification_launchSpecification_SecurityGroup;
                requestLaunchSpecificationIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_SubnetId = null;
            if (cmdletContext.LaunchSpecification_SubnetId != null)
            {
                requestLaunchSpecification_launchSpecification_SubnetId = cmdletContext.LaunchSpecification_SubnetId;
            }
            if (requestLaunchSpecification_launchSpecification_SubnetId != null)
            {
                request.LaunchSpecification.SubnetId = requestLaunchSpecification_launchSpecification_SubnetId;
                requestLaunchSpecificationIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_UserData = null;
            if (cmdletContext.LaunchSpecification_UserData != null)
            {
                requestLaunchSpecification_launchSpecification_UserData = cmdletContext.LaunchSpecification_UserData;
            }
            if (requestLaunchSpecification_launchSpecification_UserData != null)
            {
                request.LaunchSpecification.UserData = requestLaunchSpecification_launchSpecification_UserData;
                requestLaunchSpecificationIsNull = false;
            }
            Amazon.EC2.Model.IamInstanceProfileSpecification requestLaunchSpecification_launchSpecification_IamInstanceProfile = null;
            
             // populate IamInstanceProfile
            var requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull = true;
            requestLaunchSpecification_launchSpecification_IamInstanceProfile = new Amazon.EC2.Model.IamInstanceProfileSpecification();
            System.String requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn = null;
            if (cmdletContext.IamInstanceProfile_Arn != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn = cmdletContext.IamInstanceProfile_Arn;
            }
            if (requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile.Arn = requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn;
                requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Name = null;
            if (cmdletContext.IamInstanceProfile_Name != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Name = cmdletContext.IamInstanceProfile_Name;
            }
            if (requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Name != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile.Name = requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Name;
                requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull = false;
            }
             // determine if requestLaunchSpecification_launchSpecification_IamInstanceProfile should be set to null
            if (requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile = null;
            }
            if (requestLaunchSpecification_launchSpecification_IamInstanceProfile != null)
            {
                request.LaunchSpecification.IamInstanceProfile = requestLaunchSpecification_launchSpecification_IamInstanceProfile;
                requestLaunchSpecificationIsNull = false;
            }
            Amazon.EC2.Model.SpotPlacement requestLaunchSpecification_launchSpecification_Placement = null;
            
             // populate Placement
            var requestLaunchSpecification_launchSpecification_PlacementIsNull = true;
            requestLaunchSpecification_launchSpecification_Placement = new Amazon.EC2.Model.SpotPlacement();
            System.String requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone = null;
            if (cmdletContext.Placement_AvailabilityZone != null)
            {
                requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone = cmdletContext.Placement_AvailabilityZone;
            }
            if (requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone != null)
            {
                requestLaunchSpecification_launchSpecification_Placement.AvailabilityZone = requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone;
                requestLaunchSpecification_launchSpecification_PlacementIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_Placement_placement_GroupName = null;
            if (cmdletContext.Placement_GroupName != null)
            {
                requestLaunchSpecification_launchSpecification_Placement_placement_GroupName = cmdletContext.Placement_GroupName;
            }
            if (requestLaunchSpecification_launchSpecification_Placement_placement_GroupName != null)
            {
                requestLaunchSpecification_launchSpecification_Placement.GroupName = requestLaunchSpecification_launchSpecification_Placement_placement_GroupName;
                requestLaunchSpecification_launchSpecification_PlacementIsNull = false;
            }
            Amazon.EC2.Tenancy requestLaunchSpecification_launchSpecification_Placement_placement_Tenancy = null;
            if (cmdletContext.Placement_Tenancy != null)
            {
                requestLaunchSpecification_launchSpecification_Placement_placement_Tenancy = cmdletContext.Placement_Tenancy;
            }
            if (requestLaunchSpecification_launchSpecification_Placement_placement_Tenancy != null)
            {
                requestLaunchSpecification_launchSpecification_Placement.Tenancy = requestLaunchSpecification_launchSpecification_Placement_placement_Tenancy;
                requestLaunchSpecification_launchSpecification_PlacementIsNull = false;
            }
             // determine if requestLaunchSpecification_launchSpecification_Placement should be set to null
            if (requestLaunchSpecification_launchSpecification_PlacementIsNull)
            {
                requestLaunchSpecification_launchSpecification_Placement = null;
            }
            if (requestLaunchSpecification_launchSpecification_Placement != null)
            {
                request.LaunchSpecification.Placement = requestLaunchSpecification_launchSpecification_Placement;
                requestLaunchSpecificationIsNull = false;
            }
             // determine if request.LaunchSpecification should be set to null
            if (requestLaunchSpecificationIsNull)
            {
                request.LaunchSpecification = null;
            }
            if (cmdletContext.SpotPrice != null)
            {
                request.SpotPrice = cmdletContext.SpotPrice;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.UtcValidFrom != null)
            {
                request.ValidFromUtc = cmdletContext.UtcValidFrom.Value;
            }
            if (cmdletContext.UtcValidUntil != null)
            {
                request.ValidUntilUtc = cmdletContext.UtcValidUntil.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ValidFrom != null)
            {
                if (cmdletContext.UtcValidFrom != null)
                {
                    throw new System.ArgumentException("Parameters ValidFrom and UtcValidFrom are mutually exclusive.", nameof(this.ValidFrom));
                }
                request.ValidFrom = cmdletContext.ValidFrom.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ValidUntil != null)
            {
                if (cmdletContext.UtcValidUntil != null)
                {
                    throw new System.ArgumentException("Parameters ValidUntil and UtcValidUntil are mutually exclusive.", nameof(this.ValidUntil));
                }
                request.ValidUntil = cmdletContext.ValidUntil.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.EC2.Model.RequestSpotInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RequestSpotInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RequestSpotInstances");
            try
            {
                #if DESKTOP
                return client.RequestSpotInstances(request);
                #elif CORECLR
                return client.RequestSpotInstancesAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZoneGroup { get; set; }
            public System.Int32? BlockDurationMinute { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public Amazon.EC2.InstanceInterruptionBehavior InstanceInterruptionBehavior { get; set; }
            public System.String LaunchGroup { get; set; }
            public System.String LaunchSpecification_AddressingType { get; set; }
            public List<Amazon.EC2.Model.GroupIdentifier> LaunchSpecification_AllSecurityGroup { get; set; }
            public List<Amazon.EC2.Model.BlockDeviceMapping> LaunchSpecification_BlockDeviceMapping { get; set; }
            public System.Boolean? LaunchSpecification_EbsOptimized { get; set; }
            public System.String IamInstanceProfile_Arn { get; set; }
            public System.String IamInstanceProfile_Name { get; set; }
            public System.String LaunchSpecification_ImageId { get; set; }
            public Amazon.EC2.InstanceType LaunchSpecification_InstanceType { get; set; }
            public System.String LaunchSpecification_KernelId { get; set; }
            public System.String LaunchSpecification_KeyName { get; set; }
            public System.Boolean? LaunchSpecification_MonitoringEnabled { get; set; }
            public List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification> LaunchSpecification_NetworkInterface { get; set; }
            public System.String Placement_AvailabilityZone { get; set; }
            public System.String Placement_GroupName { get; set; }
            public Amazon.EC2.Tenancy Placement_Tenancy { get; set; }
            public System.String LaunchSpecification_RamdiskId { get; set; }
            public List<System.String> LaunchSpecification_SecurityGroup { get; set; }
            public System.String LaunchSpecification_SubnetId { get; set; }
            public System.String LaunchSpecification_UserData { get; set; }
            public System.String SpotPrice { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.SpotInstanceType Type { get; set; }
            public System.DateTime? UtcValidFrom { get; set; }
            public System.DateTime? UtcValidUntil { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ValidFrom { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ValidUntil { get; set; }
            public System.Func<Amazon.EC2.Model.RequestSpotInstancesResponse, RequestEC2SpotInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SpotInstanceRequests;
        }
        
    }
}
