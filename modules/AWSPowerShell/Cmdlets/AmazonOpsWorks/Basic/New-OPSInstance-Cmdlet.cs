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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Creates an instance in a specified stack. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-add.html">Adding
    /// an Instance to a Layer</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OPSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateInstance operation against AWS OpsWorks.", Operation = new[] {"CreateInstance"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CreateInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewOPSInstanceCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A custom AMI ID to be used to create the instance. The AMI should be based on one
        /// of the standard AWS OpsWorks AMIs: Amazon Linux, Ubuntu 12.04 LTS, or Ubuntu 14.04
        /// LTS. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances.html">Instances</a>.</para><note>If you specify a custom AMI, you must set <code>Os</code> to <code>Custom</code>.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AmiId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance architecture. The default option is <code>x86_64</code>. Instance types
        /// do not necessarily support both architectures. For a list of the architectures that
        /// are supported by the different instance types, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Architecture Architecture { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For load-based or time-based instances, the type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public AutoScalingType AutoScalingType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance Availability Zone. For more information, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html">Regions
        /// and Endpoints</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array of <code>BlockDeviceMapping</code> objects that specify the instance's block
        /// devices. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block
        /// Device Mapping</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BlockDeviceMappings")]
        public Amazon.OpsWorks.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to create an Amazon EBS-optimized instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean EbsOptimized { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance host name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Hostname { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to install operating system and package updates when the instance boots. The
        /// default value is <code>true</code>. To control when updates are installed, set this
        /// value to <code>false</code>. You must then update your instances manually by using
        /// <a>CreateDeployment</a> to run the <code>update_dependencies</code> stack command
        /// or manually running <code>yum</code> (Amazon Linux) or <code>apt-get</code> (Ubuntu)
        /// on the instances. </para><note><para>We strongly recommend using the default value of <code>true</code> to ensure that
        /// your instances have the latest security updates.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean InstallUpdatesOnBoot { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance type. AWS OpsWorks supports all instance types except Cluster Compute,
        /// Cluster GPU, and High Memory Cluster. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>. The parameter values that you use to specify the various types
        /// are in the API Name column of the Available Instance Types table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String InstanceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An array that contains the instance layer IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("LayerIds")]
        public System.String[] LayerId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's operating system, which must be set to one of the following.</para><ul><li>Standard operating systems: an Amazon Linux version such as <code>Amazon
        /// Linux 2014.09</code>, <code>Ubuntu 12.04 LTS</code>, or <code>Ubuntu 14.04 LTS</code>.</li><li>Custom AMIs: <code>Custom</code></li></ul><para>The default option is the current Amazon Linux version. If you set this parameter
        /// to <code>Custom</code>, you must use the <a>CreateInstance</a> action's AmiId parameter
        /// to specify the custom AMI that you want to use. For more information on the standard
        /// operating systems, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-os.html">Operating
        /// Systems</a>For more information on how to use custom AMIs with OpsWorks, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-custom-ami.html">Using
        /// Custom AMIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Os { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance root device type. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ComponentsAMIs.html#storage-for-the-root-device">Storage
        /// for the Root Device</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public RootDeviceType RootDeviceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's Amazon EC2 key pair name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SshKeyName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the instance's subnet. If the stack is running in a VPC, you can use this
        /// parameter to override the stack's default subnet ID value and direct AWS OpsWorks
        /// to launch the instance in a different subnet. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SubnetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's virtualization type, <code>paravirtual</code> or <code>hvm</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public VirtualizationType VirtualizationType { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSInstance (CreateInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AmiId = this.AmiId;
            context.Architecture = this.Architecture;
            context.AutoScalingType = this.AutoScalingType;
            context.AvailabilityZone = this.AvailabilityZone;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMappings = new List<BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            if (ParameterWasBound("EbsOptimized"))
                context.EbsOptimized = this.EbsOptimized;
            context.Hostname = this.Hostname;
            if (ParameterWasBound("InstallUpdatesOnBoot"))
                context.InstallUpdatesOnBoot = this.InstallUpdatesOnBoot;
            context.InstanceType = this.InstanceType;
            if (this.LayerId != null)
            {
                context.LayerIds = new List<String>(this.LayerId);
            }
            context.Os = this.Os;
            context.RootDeviceType = this.RootDeviceType;
            context.SshKeyName = this.SshKeyName;
            context.StackId = this.StackId;
            context.SubnetId = this.SubnetId;
            context.VirtualizationType = this.VirtualizationType;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateInstanceRequest();
            
            if (cmdletContext.AmiId != null)
            {
                request.AmiId = cmdletContext.AmiId;
            }
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            if (cmdletContext.AutoScalingType != null)
            {
                request.AutoScalingType = cmdletContext.AutoScalingType;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.BlockDeviceMappings != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMappings;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            if (cmdletContext.InstallUpdatesOnBoot != null)
            {
                request.InstallUpdatesOnBoot = cmdletContext.InstallUpdatesOnBoot.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.LayerIds != null)
            {
                request.LayerIds = cmdletContext.LayerIds;
            }
            if (cmdletContext.Os != null)
            {
                request.Os = cmdletContext.Os;
            }
            if (cmdletContext.RootDeviceType != null)
            {
                request.RootDeviceType = cmdletContext.RootDeviceType;
            }
            if (cmdletContext.SshKeyName != null)
            {
                request.SshKeyName = cmdletContext.SshKeyName;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.VirtualizationType != null)
            {
                request.VirtualizationType = cmdletContext.VirtualizationType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceId;
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
            public String AmiId { get; set; }
            public Architecture Architecture { get; set; }
            public AutoScalingType AutoScalingType { get; set; }
            public String AvailabilityZone { get; set; }
            public List<BlockDeviceMapping> BlockDeviceMappings { get; set; }
            public Boolean? EbsOptimized { get; set; }
            public String Hostname { get; set; }
            public Boolean? InstallUpdatesOnBoot { get; set; }
            public String InstanceType { get; set; }
            public List<String> LayerIds { get; set; }
            public String Os { get; set; }
            public RootDeviceType RootDeviceType { get; set; }
            public String SshKeyName { get; set; }
            public String StackId { get; set; }
            public String SubnetId { get; set; }
            public VirtualizationType VirtualizationType { get; set; }
        }
        
    }
}
