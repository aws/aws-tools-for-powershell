/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a Spot instance request. Spot instances are instances that Amazon EC2 launches
    /// when the bid price that you specify exceeds the current Spot price. Amazon EC2 periodically
    /// sets the Spot price based on available Spot Instance capacity and current Spot instance
    /// requests. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-requests.html">Spot
    /// Instance Requests</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </summary>
    [Cmdlet("Request", "EC2SpotInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.SpotInstanceRequest")]
    [AWSCmdlet("Invokes the RequestSpotInstances operation against Amazon Elastic Compute Cloud.", Operation = new[] {"RequestSpotInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.SpotInstanceRequest",
        "This cmdlet returns a collection of SpotInstanceRequest objects.",
        "The service call response (type Amazon.EC2.Model.RequestSpotInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestEC2SpotInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter LaunchSpecification_AddressingType
        /// <summary>
        /// <para>
        /// <para>Deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_AddressingType { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_AllSecurityGroup
        /// <summary>
        /// <para>
        /// <para>One or more security groups. When requesting instances in a VPC, you must specify
        /// the IDs of the security groups. When requesting instances in EC2-Classic, you can
        /// specify the names or the IDs of the security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_AllSecurityGroups")]
        public Amazon.EC2.Model.GroupIdentifier[] LaunchSpecification_AllSecurityGroup { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_IamInstanceProfile_Arn")]
        public System.String IamInstanceProfile_Arn { get; set; }
        #endregion
        
        #region Parameter Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone.</para><para>[Spot fleet only] To specify multiple Availability Zones, separate them using commas;
        /// for example, "us-west-2a, us-west-2b".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_Placement_AvailabilityZone")]
        public System.String Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneGroup
        /// <summary>
        /// <para>
        /// <para>The user-specified name for a logical grouping of bids.</para><para>When you specify an Availability Zone group in a Spot Instance request, all Spot instances
        /// in the request are launched in the same Availability Zone. Instance proximity is maintained
        /// with this parameter, but the choice of Availability Zone is not. The group applies
        /// only to bids for Spot Instances of the same instance type. Any additional Spot instance
        /// requests that are specified with the same Availability Zone group name are launched
        /// in that same Availability Zone, as long as at least one instance from the group is
        /// still active.</para><para>If there is no active instance running in the Availability Zone group that you specify
        /// for a new Spot instance request (all instances are terminated, the bid is expired,
        /// or the bid falls below current market), then Amazon EC2 launches the instance in any
        /// Availability Zone where the constraint can be met. Consequently, the subsequent set
        /// of Spot instances could be placed in a different zone from the original request, even
        /// if you specified the same Availability Zone group.</para><para>Default: Instances are launched in any available Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZoneGroup { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>One or more block device mapping entries.</para><para>Although you can specify encrypted EBS volumes in this block device mapping for your
        /// Spot Instances, these volumes are not encrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] LaunchSpecification_BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter BlockDurationMinute
        /// <summary>
        /// <para>
        /// <para>The required duration for the Spot instances (also known as Spot blocks), in minutes.
        /// This value must be a multiple of 60 (60, 120, 180, 240, 300, or 360).</para><para>The duration period starts as soon as your Spot instance receives its instance ID.
        /// At the end of the duration period, Amazon EC2 marks the Spot instance for termination
        /// and provides a Spot instance termination notice, which gives the instance a two-minute
        /// warning before it terminates.</para><para>Note that you can't specify an Availability Zone group or a launch group if you specify
        /// a duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlockDurationMinutes")]
        public System.Int32 BlockDurationMinute { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instance is optimized for EBS I/O. This optimization provides
        /// dedicated throughput to Amazon EBS and an optimized configuration stack to provide
        /// optimal EBS I/O performance. This optimization isn't available with all instance types.
        /// Additional usage charges apply when using an EBS Optimized instance.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean LaunchSpecification_EbsOptimized { get; set; }
        #endregion
        
        #region Parameter Placement_GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group (for cluster instances).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_Placement_GroupName")]
        public System.String Placement_GroupName { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_ImageId { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of Spot instances to launch.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InstanceCount { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.InstanceType")]
        public Amazon.EC2.InstanceType LaunchSpecification_InstanceType { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_KernelId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_KeyName { get; set; }
        #endregion
        
        #region Parameter LaunchGroup
        /// <summary>
        /// <para>
        /// <para>The instance launch group. Launch groups are Spot instances that launch together and
        /// terminate together.</para><para>Default: Instances are launched and terminated individually</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchGroup { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_MonitoringEnabled
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean LaunchSpecification_MonitoringEnabled { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile_Name
        /// <summary>
        /// <para>
        /// <para>The name of the instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_IamInstanceProfile_Name")]
        public System.String IamInstanceProfile_Name { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_NetworkInterface
        /// <summary>
        /// <para>
        /// <para>One or more network interfaces. If you specify a network interface, you must specify
        /// subnet IDs and security group IDs using the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_NetworkInterfaces")]
        public Amazon.EC2.Model.InstanceNetworkInterfaceSpecification[] LaunchSpecification_NetworkInterface { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_RamdiskId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>One or more security group names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_SecurityGroups")]
        public System.String[] LaunchSpecification_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SpotPrice
        /// <summary>
        /// <para>
        /// <para>The maximum hourly price (bid) for any Spot instance launched to fulfill the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpotPrice { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in which to launch the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_SubnetId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The Spot instance request type.</para><para>Default: <code>one-time</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.SpotInstanceType")]
        public Amazon.EC2.SpotInstanceType Type { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_UserData
        /// <summary>
        /// <para>
        /// <para>The user data to make available to the instances. If you are using an AWS SDK or command
        /// line tool, Base64-encoding is performed for you, and you can load the text from a
        /// file. Otherwise, you must provide Base64-encoded text.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_UserData { get; set; }
        #endregion
        
        #region Parameter ValidFrom
        /// <summary>
        /// <para>
        /// <para>The start date of the request. If this is a one-time request, the request becomes
        /// active at this date and time and remains active until all instances launch, the request
        /// expires, or the request is canceled. If the request is persistent, the request becomes
        /// active at this date and time and remains active until it expires or is canceled.</para><para>Default: The request is effective indefinitely.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ValidFrom { get; set; }
        #endregion
        
        #region Parameter ValidUntil
        /// <summary>
        /// <para>
        /// <para>The end date of the request. If this is a one-time request, the request remains active
        /// until all instances launch, the request is canceled, or this date is reached. If the
        /// request is persistent, it remains active until it is canceled or this date and time
        /// is reached.</para><para>Default: The request is effective indefinitely.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ValidUntil { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SpotPrice", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-EC2SpotInstance (RequestSpotInstances)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AvailabilityZoneGroup = this.AvailabilityZoneGroup;
            if (ParameterWasBound("BlockDurationMinute"))
                context.BlockDurationMinutes = this.BlockDurationMinute;
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            context.LaunchGroup = this.LaunchGroup;
            context.LaunchSpecification_AddressingType = this.LaunchSpecification_AddressingType;
            if (this.LaunchSpecification_AllSecurityGroup != null)
            {
                context.LaunchSpecification_AllSecurityGroups = new List<Amazon.EC2.Model.GroupIdentifier>(this.LaunchSpecification_AllSecurityGroup);
            }
            if (this.LaunchSpecification_BlockDeviceMapping != null)
            {
                context.LaunchSpecification_BlockDeviceMappings = new List<Amazon.EC2.Model.BlockDeviceMapping>(this.LaunchSpecification_BlockDeviceMapping);
            }
            if (ParameterWasBound("LaunchSpecification_EbsOptimized"))
                context.LaunchSpecification_EbsOptimized = this.LaunchSpecification_EbsOptimized;
            context.LaunchSpecification_IamInstanceProfile_Arn = this.IamInstanceProfile_Arn;
            context.LaunchSpecification_IamInstanceProfile_Name = this.IamInstanceProfile_Name;
            context.LaunchSpecification_ImageId = this.LaunchSpecification_ImageId;
            context.LaunchSpecification_InstanceType = this.LaunchSpecification_InstanceType;
            context.LaunchSpecification_KernelId = this.LaunchSpecification_KernelId;
            context.LaunchSpecification_KeyName = this.LaunchSpecification_KeyName;
            if (ParameterWasBound("LaunchSpecification_MonitoringEnabled"))
                context.LaunchSpecification_MonitoringEnabled = this.LaunchSpecification_MonitoringEnabled;
            if (this.LaunchSpecification_NetworkInterface != null)
            {
                context.LaunchSpecification_NetworkInterfaces = new List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification>(this.LaunchSpecification_NetworkInterface);
            }
            context.LaunchSpecification_Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.LaunchSpecification_Placement_GroupName = this.Placement_GroupName;
            context.LaunchSpecification_RamdiskId = this.LaunchSpecification_RamdiskId;
            if (this.LaunchSpecification_SecurityGroup != null)
            {
                context.LaunchSpecification_SecurityGroups = new List<System.String>(this.LaunchSpecification_SecurityGroup);
            }
            context.LaunchSpecification_SubnetId = this.LaunchSpecification_SubnetId;
            context.LaunchSpecification_UserData = this.LaunchSpecification_UserData;
            context.SpotPrice = this.SpotPrice;
            context.Type = this.Type;
            if (ParameterWasBound("ValidFrom"))
                context.ValidFrom = this.ValidFrom;
            if (ParameterWasBound("ValidUntil"))
                context.ValidUntil = this.ValidUntil;
            
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
            if (cmdletContext.BlockDurationMinutes != null)
            {
                request.BlockDurationMinutes = cmdletContext.BlockDurationMinutes.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.LaunchGroup != null)
            {
                request.LaunchGroup = cmdletContext.LaunchGroup;
            }
            
             // populate LaunchSpecification
            bool requestLaunchSpecificationIsNull = true;
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
            if (cmdletContext.LaunchSpecification_AllSecurityGroups != null)
            {
                requestLaunchSpecification_launchSpecification_AllSecurityGroup = cmdletContext.LaunchSpecification_AllSecurityGroups;
            }
            if (requestLaunchSpecification_launchSpecification_AllSecurityGroup != null)
            {
                request.LaunchSpecification.AllSecurityGroups = requestLaunchSpecification_launchSpecification_AllSecurityGroup;
                requestLaunchSpecificationIsNull = false;
            }
            List<Amazon.EC2.Model.BlockDeviceMapping> requestLaunchSpecification_launchSpecification_BlockDeviceMapping = null;
            if (cmdletContext.LaunchSpecification_BlockDeviceMappings != null)
            {
                requestLaunchSpecification_launchSpecification_BlockDeviceMapping = cmdletContext.LaunchSpecification_BlockDeviceMappings;
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
            if (cmdletContext.LaunchSpecification_NetworkInterfaces != null)
            {
                requestLaunchSpecification_launchSpecification_NetworkInterface = cmdletContext.LaunchSpecification_NetworkInterfaces;
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
            if (cmdletContext.LaunchSpecification_SecurityGroups != null)
            {
                requestLaunchSpecification_launchSpecification_SecurityGroup = cmdletContext.LaunchSpecification_SecurityGroups;
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
            bool requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull = true;
            requestLaunchSpecification_launchSpecification_IamInstanceProfile = new Amazon.EC2.Model.IamInstanceProfileSpecification();
            System.String requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn = null;
            if (cmdletContext.LaunchSpecification_IamInstanceProfile_Arn != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn = cmdletContext.LaunchSpecification_IamInstanceProfile_Arn;
            }
            if (requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile.Arn = requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Arn;
                requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Name = null;
            if (cmdletContext.LaunchSpecification_IamInstanceProfile_Name != null)
            {
                requestLaunchSpecification_launchSpecification_IamInstanceProfile_iamInstanceProfile_Name = cmdletContext.LaunchSpecification_IamInstanceProfile_Name;
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
            bool requestLaunchSpecification_launchSpecification_PlacementIsNull = true;
            requestLaunchSpecification_launchSpecification_Placement = new Amazon.EC2.Model.SpotPlacement();
            System.String requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone = null;
            if (cmdletContext.LaunchSpecification_Placement_AvailabilityZone != null)
            {
                requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone = cmdletContext.LaunchSpecification_Placement_AvailabilityZone;
            }
            if (requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone != null)
            {
                requestLaunchSpecification_launchSpecification_Placement.AvailabilityZone = requestLaunchSpecification_launchSpecification_Placement_placement_AvailabilityZone;
                requestLaunchSpecification_launchSpecification_PlacementIsNull = false;
            }
            System.String requestLaunchSpecification_launchSpecification_Placement_placement_GroupName = null;
            if (cmdletContext.LaunchSpecification_Placement_GroupName != null)
            {
                requestLaunchSpecification_launchSpecification_Placement_placement_GroupName = cmdletContext.LaunchSpecification_Placement_GroupName;
            }
            if (requestLaunchSpecification_launchSpecification_Placement_placement_GroupName != null)
            {
                requestLaunchSpecification_launchSpecification_Placement.GroupName = requestLaunchSpecification_launchSpecification_Placement_placement_GroupName;
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
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.ValidFrom != null)
            {
                request.ValidFrom = cmdletContext.ValidFrom.Value;
            }
            if (cmdletContext.ValidUntil != null)
            {
                request.ValidUntil = cmdletContext.ValidUntil.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SpotInstanceRequests;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.EC2.Model.RequestSpotInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RequestSpotInstancesRequest request)
        {
            #if DESKTOP
            return client.RequestSpotInstances(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RequestSpotInstancesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AvailabilityZoneGroup { get; set; }
            public System.Int32? BlockDurationMinutes { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public System.String LaunchGroup { get; set; }
            public System.String LaunchSpecification_AddressingType { get; set; }
            public List<Amazon.EC2.Model.GroupIdentifier> LaunchSpecification_AllSecurityGroups { get; set; }
            public List<Amazon.EC2.Model.BlockDeviceMapping> LaunchSpecification_BlockDeviceMappings { get; set; }
            public System.Boolean? LaunchSpecification_EbsOptimized { get; set; }
            public System.String LaunchSpecification_IamInstanceProfile_Arn { get; set; }
            public System.String LaunchSpecification_IamInstanceProfile_Name { get; set; }
            public System.String LaunchSpecification_ImageId { get; set; }
            public Amazon.EC2.InstanceType LaunchSpecification_InstanceType { get; set; }
            public System.String LaunchSpecification_KernelId { get; set; }
            public System.String LaunchSpecification_KeyName { get; set; }
            public System.Boolean? LaunchSpecification_MonitoringEnabled { get; set; }
            public List<Amazon.EC2.Model.InstanceNetworkInterfaceSpecification> LaunchSpecification_NetworkInterfaces { get; set; }
            public System.String LaunchSpecification_Placement_AvailabilityZone { get; set; }
            public System.String LaunchSpecification_Placement_GroupName { get; set; }
            public System.String LaunchSpecification_RamdiskId { get; set; }
            public List<System.String> LaunchSpecification_SecurityGroups { get; set; }
            public System.String LaunchSpecification_SubnetId { get; set; }
            public System.String LaunchSpecification_UserData { get; set; }
            public System.String SpotPrice { get; set; }
            public Amazon.EC2.SpotInstanceType Type { get; set; }
            public System.DateTime? ValidFrom { get; set; }
            public System.DateTime? ValidUntil { get; set; }
        }
        
    }
}
