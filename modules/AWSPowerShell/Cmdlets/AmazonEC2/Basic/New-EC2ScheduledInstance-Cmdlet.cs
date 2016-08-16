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
    /// Launches the specified Scheduled Instances.
    /// 
    ///  
    /// <para>
    /// Before you can launch a Scheduled Instance, you must purchase it and obtain an identifier
    /// using <a>PurchaseScheduledInstances</a>.
    /// </para><para>
    /// You must launch a Scheduled Instance during its scheduled time period. You can't stop
    /// or reboot a Scheduled Instance, but you can terminate it as needed. If you terminate
    /// a Scheduled Instance before the current scheduled time period ends, you can launch
    /// it again after a few minutes. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-scheduled-instances.html">Scheduled
    /// Instances</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2ScheduledInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RunScheduledInstances operation against Amazon Elastic Compute Cloud.", Operation = new[] {"RunScheduledInstances"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.EC2.Model.RunScheduledInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ScheduledInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter IamInstanceProfile_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_IamInstanceProfile_Arn")]
        public System.String IamInstanceProfile_Arn { get; set; }
        #endregion
        
        #region Parameter Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_Placement_AvailabilityZone")]
        public System.String Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>One or more block device mapping entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_BlockDeviceMappings")]
        public Amazon.EC2.Model.ScheduledInstancesBlockDeviceMapping[] LaunchSpecification_BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that ensures the idempotency of the request. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instances are optimized for EBS I/O. This optimization provides
        /// dedicated throughput to Amazon EBS and an optimized configuration stack to provide
        /// optimal EBS I/O performance. This optimization isn't available with all instance types.
        /// Additional usage charges apply when using an EBS-optimized instance.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean LaunchSpecification_EbsOptimized { get; set; }
        #endregion
        
        #region Parameter Monitoring_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether monitoring is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_Monitoring_Enabled")]
        public System.Boolean Monitoring_Enabled { get; set; }
        #endregion
        
        #region Parameter Placement_GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_Placement_GroupName")]
        public System.String Placement_GroupName { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Machine Image (AMI).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_ImageId { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances.</para><para>Default: 1</para>
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
        public System.String LaunchSpecification_InstanceType { get; set; }
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
        
        #region Parameter IamInstanceProfile_Name
        /// <summary>
        /// <para>
        /// <para>The name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_IamInstanceProfile_Name")]
        public System.String IamInstanceProfile_Name { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_NetworkInterface
        /// <summary>
        /// <para>
        /// <para>One or more network interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_NetworkInterfaces")]
        public Amazon.EC2.Model.ScheduledInstancesNetworkInterface[] LaunchSpecification_NetworkInterface { get; set; }
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
        
        #region Parameter ScheduledInstanceId
        /// <summary>
        /// <para>
        /// <para>The Scheduled Instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledInstanceId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LaunchSpecification_SecurityGroupIds")]
        public System.String[] LaunchSpecification_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in which to launch the instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_SubnetId { get; set; }
        #endregion
        
        #region Parameter LaunchSpecification_UserData
        /// <summary>
        /// <para>
        /// <para>The base64-encoded MIME user data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LaunchSpecification_UserData { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ScheduledInstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ScheduledInstance (RunScheduledInstances)"))
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
            
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            if (this.LaunchSpecification_BlockDeviceMapping != null)
            {
                context.LaunchSpecification_BlockDeviceMappings = new List<Amazon.EC2.Model.ScheduledInstancesBlockDeviceMapping>(this.LaunchSpecification_BlockDeviceMapping);
            }
            if (ParameterWasBound("LaunchSpecification_EbsOptimized"))
                context.LaunchSpecification_EbsOptimized = this.LaunchSpecification_EbsOptimized;
            context.LaunchSpecification_IamInstanceProfile_Arn = this.IamInstanceProfile_Arn;
            context.LaunchSpecification_IamInstanceProfile_Name = this.IamInstanceProfile_Name;
            context.LaunchSpecification_ImageId = this.LaunchSpecification_ImageId;
            context.LaunchSpecification_InstanceType = this.LaunchSpecification_InstanceType;
            context.LaunchSpecification_KernelId = this.LaunchSpecification_KernelId;
            context.LaunchSpecification_KeyName = this.LaunchSpecification_KeyName;
            if (ParameterWasBound("Monitoring_Enabled"))
                context.LaunchSpecification_Monitoring_Enabled = this.Monitoring_Enabled;
            if (this.LaunchSpecification_NetworkInterface != null)
            {
                context.LaunchSpecification_NetworkInterfaces = new List<Amazon.EC2.Model.ScheduledInstancesNetworkInterface>(this.LaunchSpecification_NetworkInterface);
            }
            context.LaunchSpecification_Placement_AvailabilityZone = this.Placement_AvailabilityZone;
            context.LaunchSpecification_Placement_GroupName = this.Placement_GroupName;
            context.LaunchSpecification_RamdiskId = this.LaunchSpecification_RamdiskId;
            if (this.LaunchSpecification_SecurityGroupId != null)
            {
                context.LaunchSpecification_SecurityGroupIds = new List<System.String>(this.LaunchSpecification_SecurityGroupId);
            }
            context.LaunchSpecification_SubnetId = this.LaunchSpecification_SubnetId;
            context.LaunchSpecification_UserData = this.LaunchSpecification_UserData;
            context.ScheduledInstanceId = this.ScheduledInstanceId;
            
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
            var request = new Amazon.EC2.Model.RunScheduledInstancesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            
             // populate LaunchSpecification
            bool requestLaunchSpecificationIsNull = true;
            request.LaunchSpecification = new Amazon.EC2.Model.ScheduledInstancesLaunchSpecification();
            List<Amazon.EC2.Model.ScheduledInstancesBlockDeviceMapping> requestLaunchSpecification_launchSpecification_BlockDeviceMapping = null;
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
            System.String requestLaunchSpecification_launchSpecification_InstanceType = null;
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
            List<Amazon.EC2.Model.ScheduledInstancesNetworkInterface> requestLaunchSpecification_launchSpecification_NetworkInterface = null;
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
            List<System.String> requestLaunchSpecification_launchSpecification_SecurityGroupId = null;
            if (cmdletContext.LaunchSpecification_SecurityGroupIds != null)
            {
                requestLaunchSpecification_launchSpecification_SecurityGroupId = cmdletContext.LaunchSpecification_SecurityGroupIds;
            }
            if (requestLaunchSpecification_launchSpecification_SecurityGroupId != null)
            {
                request.LaunchSpecification.SecurityGroupIds = requestLaunchSpecification_launchSpecification_SecurityGroupId;
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
            Amazon.EC2.Model.ScheduledInstancesMonitoring requestLaunchSpecification_launchSpecification_Monitoring = null;
            
             // populate Monitoring
            bool requestLaunchSpecification_launchSpecification_MonitoringIsNull = true;
            requestLaunchSpecification_launchSpecification_Monitoring = new Amazon.EC2.Model.ScheduledInstancesMonitoring();
            System.Boolean? requestLaunchSpecification_launchSpecification_Monitoring_monitoring_Enabled = null;
            if (cmdletContext.LaunchSpecification_Monitoring_Enabled != null)
            {
                requestLaunchSpecification_launchSpecification_Monitoring_monitoring_Enabled = cmdletContext.LaunchSpecification_Monitoring_Enabled.Value;
            }
            if (requestLaunchSpecification_launchSpecification_Monitoring_monitoring_Enabled != null)
            {
                requestLaunchSpecification_launchSpecification_Monitoring.Enabled = requestLaunchSpecification_launchSpecification_Monitoring_monitoring_Enabled.Value;
                requestLaunchSpecification_launchSpecification_MonitoringIsNull = false;
            }
             // determine if requestLaunchSpecification_launchSpecification_Monitoring should be set to null
            if (requestLaunchSpecification_launchSpecification_MonitoringIsNull)
            {
                requestLaunchSpecification_launchSpecification_Monitoring = null;
            }
            if (requestLaunchSpecification_launchSpecification_Monitoring != null)
            {
                request.LaunchSpecification.Monitoring = requestLaunchSpecification_launchSpecification_Monitoring;
                requestLaunchSpecificationIsNull = false;
            }
            Amazon.EC2.Model.ScheduledInstancesIamInstanceProfile requestLaunchSpecification_launchSpecification_IamInstanceProfile = null;
            
             // populate IamInstanceProfile
            bool requestLaunchSpecification_launchSpecification_IamInstanceProfileIsNull = true;
            requestLaunchSpecification_launchSpecification_IamInstanceProfile = new Amazon.EC2.Model.ScheduledInstancesIamInstanceProfile();
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
            Amazon.EC2.Model.ScheduledInstancesPlacement requestLaunchSpecification_launchSpecification_Placement = null;
            
             // populate Placement
            bool requestLaunchSpecification_launchSpecification_PlacementIsNull = true;
            requestLaunchSpecification_launchSpecification_Placement = new Amazon.EC2.Model.ScheduledInstancesPlacement();
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
            if (cmdletContext.ScheduledInstanceId != null)
            {
                request.ScheduledInstanceId = cmdletContext.ScheduledInstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceIdSet;
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
        
        private static Amazon.EC2.Model.RunScheduledInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RunScheduledInstancesRequest request)
        {
            #if DESKTOP
            return client.RunScheduledInstances(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RunScheduledInstancesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public List<Amazon.EC2.Model.ScheduledInstancesBlockDeviceMapping> LaunchSpecification_BlockDeviceMappings { get; set; }
            public System.Boolean? LaunchSpecification_EbsOptimized { get; set; }
            public System.String LaunchSpecification_IamInstanceProfile_Arn { get; set; }
            public System.String LaunchSpecification_IamInstanceProfile_Name { get; set; }
            public System.String LaunchSpecification_ImageId { get; set; }
            public System.String LaunchSpecification_InstanceType { get; set; }
            public System.String LaunchSpecification_KernelId { get; set; }
            public System.String LaunchSpecification_KeyName { get; set; }
            public System.Boolean? LaunchSpecification_Monitoring_Enabled { get; set; }
            public List<Amazon.EC2.Model.ScheduledInstancesNetworkInterface> LaunchSpecification_NetworkInterfaces { get; set; }
            public System.String LaunchSpecification_Placement_AvailabilityZone { get; set; }
            public System.String LaunchSpecification_Placement_GroupName { get; set; }
            public System.String LaunchSpecification_RamdiskId { get; set; }
            public List<System.String> LaunchSpecification_SecurityGroupIds { get; set; }
            public System.String LaunchSpecification_SubnetId { get; set; }
            public System.String LaunchSpecification_UserData { get; set; }
            public System.String ScheduledInstanceId { get; set; }
        }
        
    }
}
