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
    /// Updates a specified instance.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateInstance operation against AWS OpsWorks.", Operation = new[] {"UpdateInstance"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the InstanceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type UpdateInstanceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateOPSInstanceCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A custom AMI ID to be used to create the instance. The AMI should be based on one
        /// of the standard AWS OpsWorks AMIs: Amazon Linux, Ubuntu 12.04 LTS, or Ubuntu 14.04
        /// LTS. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances.html">Instances</a></para><note>If you specify a custom AMI, you must set <code>Os</code> to <code>Custom</code>.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AmiId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance architecture. Instance types do not necessarily support both architectures.
        /// For a list of the architectures that are supported by the different instance types,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Architecture Architecture { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For load-based or time-based instances, the type. Windows stacks can use only time-based
        /// instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public AutoScalingType AutoScalingType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether this is an Amazon EBS-optimized instance.</para>
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
        /// on the instances. </para><note><para>We strongly recommend using the default value of <code>true</code>, to ensure that
        /// your instances have the latest security updates.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean InstallUpdatesOnBoot { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance type. AWS OpsWorks supports all instance types except Cluster Compute,
        /// Cluster GPU, and High Memory Cluster. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>. The parameter values that you use to specify the various types
        /// are in the API Name column of the Available Instance Types table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String InstanceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's layer IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LayerIds")]
        public System.String[] LayerId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance's operating system, which must be set to one of the following.</para><para>For Windows stacks: Microsoft Windows Server 2012 R2.</para><para>For Linux stacks:</para><ul><li>Standard operating systems: an Amazon Linux version such as <code>Amazon
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
        /// <para>The instance's Amazon EC2 key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SshKeyName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the InstanceId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSInstance (UpdateInstance)"))
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
            if (ParameterWasBound("EbsOptimized"))
                context.EbsOptimized = this.EbsOptimized;
            context.Hostname = this.Hostname;
            if (ParameterWasBound("InstallUpdatesOnBoot"))
                context.InstallUpdatesOnBoot = this.InstallUpdatesOnBoot;
            context.InstanceId = this.InstanceId;
            context.InstanceType = this.InstanceType;
            if (this.LayerId != null)
            {
                context.LayerIds = new List<String>(this.LayerId);
            }
            context.Os = this.Os;
            context.SshKeyName = this.SshKeyName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateInstanceRequest();
            
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
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
            if (cmdletContext.SshKeyName != null)
            {
                request.SshKeyName = cmdletContext.SshKeyName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.InstanceId;
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
            public Boolean? EbsOptimized { get; set; }
            public String Hostname { get; set; }
            public Boolean? InstallUpdatesOnBoot { get; set; }
            public String InstanceId { get; set; }
            public String InstanceType { get; set; }
            public List<String> LayerIds { get; set; }
            public String Os { get; set; }
            public String SshKeyName { get; set; }
        }
        
    }
}
