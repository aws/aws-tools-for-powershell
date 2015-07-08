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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates a launch configuration.
    /// 
    ///  
    /// <para>
    /// If you exceed your maximum limit of launch configurations, which by default is 100
    /// per region, the call fails. For information about viewing and updating this limit,
    /// see <a>DescribeAccountLimits</a>.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/LaunchConfiguration.html">Launch
    /// Configurations</a> in the <i>Auto Scaling Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASLaunchConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateLaunchConfiguration operation against Auto Scaling.", Operation = new[] {"CreateLaunchConfiguration"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LaunchConfigurationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type CreateLaunchConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewASLaunchConfigurationCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Used for groups that launch instances into a virtual private cloud (VPC). Specifies
        /// whether to assign a public IP address to each instance. For more information, see
        /// <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/autoscalingsubnets.html">Auto
        /// Scaling and Amazon Virtual Private Cloud</a> in the <i>Auto Scaling Developer Guide</i>.</para><para>If you specify a value for this parameter, be sure to specify at least one subnet
        /// using the <i>VPCZoneIdentifier</i> parameter when you create your group. </para><para>Default: If the instance is launched into a default subnet, the default is <code>true</code>.
        /// If the instance is launched into a nondefault subnet, the default is <code>false</code>.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AssociatePublicIpAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more mappings that specify how block devices are exposed to the instance. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block
        /// Device Mapping</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlockDeviceMappings")]
        public Amazon.AutoScaling.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of a ClassicLink-enabled VPC to link your EC2-Classic instances to. This parameter
        /// is supported only if you are launching EC2-Classic instances. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-classiclink.html">ClassicLink</a>
        /// in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ClassicLinkVPCId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups for the VPC specified in <code>ClassicLinkVPCId</code>.
        /// This parameter is required if <code>ClassicLinkVPCId</code> is specified, and is not
        /// supported otherwise. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-classiclink.html">ClassicLink</a>
        /// in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ClassicLinkVPCSecurityGroups")]
        public System.String[] ClassicLinkVPCSecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Indicates whether the instance is optimized for Amazon EBS I/O. By default, the instance
        /// is not optimized for EBS I/O. The optimization provides dedicated throughput to Amazon
        /// EBS and an optimized configuration stack to provide optimal I/O performance. This
        /// optimization is not available with all instance types. Additional usage charges apply.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSOptimized.html">Amazon
        /// EBS-Optimized Instances</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean EbsOptimized { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If <code>True</code>, instance monitoring is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean InstanceMonitoring_Enabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name or the Amazon Resource Name (ARN) of the instance profile associated with
        /// the IAM role for the instance.</para><para>EC2 instances launched with an IAM role will automatically have AWS security credentials
        /// available. You can use IAM roles with Auto Scaling to automatically enable applications
        /// running on your EC2 instances to securely access other AWS resources. For more information,
        /// see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/us-iam-role.html">Launch
        /// Auto Scaling Instances with an IAM Role</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String IamInstanceProfile { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Machine Image (AMI) to use to launch your EC2 instances. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/finding-an-ami.html">Finding
        /// an AMI</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String ImageId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 instance to use to create the launch configuration.</para><para>The new launch configuration derives attributes from the instance, with the exception
        /// of the block device mapping.</para><para>To create a launch configuration with a block device mapping or override any other
        /// instance attributes, specify them as part of the same request.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/create-lc-with-instanceID.html">Create
        /// a Launch Configuration Using an EC2 Instance</a> in the <i>Auto Scaling Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The instance type of the EC2 instance. For information about available instance types,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html#AvailableInstanceTypes">
        /// Available Instance Types</a> in the <i>Amazon Elastic Cloud Compute User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String InstanceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The ID of the kernel associated with the AMI. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String KernelId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the key pair. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Amazon
        /// EC2 Key Pairs</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String KeyName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration. This name must be unique within the scope of
        /// your AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String LaunchConfigurationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instance. An instance with a tenancy of <code>dedicated</code>
        /// runs on single-tenant hardware and can only be launched into a VPC.</para><para>You must set the value of this parameter to <code>dedicated</code> if want to launch
        /// Dedicated Instances into a shared tenancy VPC (VPC with instance placement tenancy
        /// attribute set to <code>default</code>).</para><para>If you specify a value for this parameter, be sure to specify at least one subnet
        /// using the <i>VPCZoneIdentifier</i> parameter when you create your group.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/autoscalingsubnets.html">Auto
        /// Scaling and Amazon Virtual Private Cloud</a> in the <i>Auto Scaling Developer Guide</i>.
        /// </para><para>Valid values: <code>default</code> | <code>dedicated</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PlacementTenancy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The ID of the RAM disk associated with the AMI. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RamdiskId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more security groups with which to associate the instances.</para><para>If your instances are launched in EC2-Classic, you can either specify security group
        /// names or the security group IDs. For more information about security groups for EC2-Classic,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-network-security.html">Amazon
        /// EC2 Security Groups</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para><para>If your instances are launched into a VPC, specify security group IDs. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_SecurityGroups.html">Security
        /// Groups for Your VPC</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum hourly price to be paid for any Spot Instance launched to fulfill the
        /// request. Spot Instances are launched when the price you specify exceeds the current
        /// Spot market price. For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/US-SpotInstances.html">Launch
        /// Spot Instances in Your Auto Scaling Group</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SpotPrice { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user data to make available to the launched EC2 instances. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-metadata.html">Instance
        /// Metadata and User Data</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para><para>At this time, launch configurations don't support compressed (zipped) user data files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String UserData { get; set; }
        
        /// <summary>
        /// Returns the value passed to the LaunchConfigurationName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LaunchConfigurationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASLaunchConfiguration (CreateLaunchConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AssociatePublicIpAddress"))
                context.AssociatePublicIpAddress = this.AssociatePublicIpAddress;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMappings = new List<BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.ClassicLinkVPCId = this.ClassicLinkVPCId;
            if (this.ClassicLinkVPCSecurityGroup != null)
            {
                context.ClassicLinkVPCSecurityGroups = new List<String>(this.ClassicLinkVPCSecurityGroup);
            }
            if (ParameterWasBound("EbsOptimized"))
                context.EbsOptimized = this.EbsOptimized;
            context.IamInstanceProfile = this.IamInstanceProfile;
            context.ImageId = this.ImageId;
            context.InstanceId = this.InstanceId;
            if (ParameterWasBound("InstanceMonitoring_Enabled"))
                context.InstanceMonitoring_Enabled = this.InstanceMonitoring_Enabled;
            context.InstanceType = this.InstanceType;
            context.KernelId = this.KernelId;
            context.KeyName = this.KeyName;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            context.PlacementTenancy = this.PlacementTenancy;
            context.RamdiskId = this.RamdiskId;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroups = new List<String>(this.SecurityGroup);
            }
            context.SpotPrice = this.SpotPrice;
            context.UserData = this.UserData;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateLaunchConfigurationRequest();
            
            if (cmdletContext.AssociatePublicIpAddress != null)
            {
                request.AssociatePublicIpAddress = cmdletContext.AssociatePublicIpAddress.Value;
            }
            if (cmdletContext.BlockDeviceMappings != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMappings;
            }
            if (cmdletContext.ClassicLinkVPCId != null)
            {
                request.ClassicLinkVPCId = cmdletContext.ClassicLinkVPCId;
            }
            if (cmdletContext.ClassicLinkVPCSecurityGroups != null)
            {
                request.ClassicLinkVPCSecurityGroups = cmdletContext.ClassicLinkVPCSecurityGroups;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            if (cmdletContext.IamInstanceProfile != null)
            {
                request.IamInstanceProfile = cmdletContext.IamInstanceProfile;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate InstanceMonitoring
            bool requestInstanceMonitoringIsNull = true;
            request.InstanceMonitoring = new InstanceMonitoring();
            Boolean? requestInstanceMonitoring_instanceMonitoring_Enabled = null;
            if (cmdletContext.InstanceMonitoring_Enabled != null)
            {
                requestInstanceMonitoring_instanceMonitoring_Enabled = cmdletContext.InstanceMonitoring_Enabled.Value;
            }
            if (requestInstanceMonitoring_instanceMonitoring_Enabled != null)
            {
                request.InstanceMonitoring.Enabled = requestInstanceMonitoring_instanceMonitoring_Enabled.Value;
                requestInstanceMonitoringIsNull = false;
            }
             // determine if request.InstanceMonitoring should be set to null
            if (requestInstanceMonitoringIsNull)
            {
                request.InstanceMonitoring = null;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.KernelId != null)
            {
                request.KernelId = cmdletContext.KernelId;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.LaunchConfigurationName != null)
            {
                request.LaunchConfigurationName = cmdletContext.LaunchConfigurationName;
            }
            if (cmdletContext.PlacementTenancy != null)
            {
                request.PlacementTenancy = cmdletContext.PlacementTenancy;
            }
            if (cmdletContext.RamdiskId != null)
            {
                request.RamdiskId = cmdletContext.RamdiskId;
            }
            if (cmdletContext.SecurityGroups != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroups;
            }
            if (cmdletContext.SpotPrice != null)
            {
                request.SpotPrice = cmdletContext.SpotPrice;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateLaunchConfiguration(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.LaunchConfigurationName;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Boolean? AssociatePublicIpAddress { get; set; }
            public List<BlockDeviceMapping> BlockDeviceMappings { get; set; }
            public String ClassicLinkVPCId { get; set; }
            public List<String> ClassicLinkVPCSecurityGroups { get; set; }
            public Boolean? EbsOptimized { get; set; }
            public String IamInstanceProfile { get; set; }
            public String ImageId { get; set; }
            public String InstanceId { get; set; }
            public Boolean? InstanceMonitoring_Enabled { get; set; }
            public String InstanceType { get; set; }
            public String KernelId { get; set; }
            public String KeyName { get; set; }
            public String LaunchConfigurationName { get; set; }
            public String PlacementTenancy { get; set; }
            public String RamdiskId { get; set; }
            public List<String> SecurityGroups { get; set; }
            public String SpotPrice { get; set; }
            public String UserData { get; set; }
        }
        
    }
}
