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
        "The service response (type Amazon.OpsWorks.Model.UpdateInstanceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateOPSInstanceCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>The default AWS OpsWorks Stacks agent version. You have the following options:</para><ul><li><para><code>INHERIT</code> - Use the stack's default agent version setting.</para></li><li><para><i>version_number</i> - Use the specified agent version. This value overrides the
        /// stack's default setting. To update the agent version, you must edit the instance configuration
        /// and specify a new version. AWS OpsWorks Stacks then automatically installs that version
        /// on the instance.</para></li></ul><para>The default setting is <code>INHERIT</code>. To specify an agent version, you must
        /// use the complete version number, not the abbreviated number shown on the console.
        /// For a list of available agent version numbers, call <a>DescribeAgentVersions</a>.</para><para>AgentVersion cannot be set to Chef 12.2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AgentVersion { get; set; }
        #endregion
        
        #region Parameter AmiId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI that was used to create the instance. The value of this parameter
        /// must be the same AMI ID that the instance is already using. You cannot apply a new
        /// AMI to an instance by running UpdateInstance. UpdateInstance does not work on instances
        /// that are using custom AMIs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmiId { get; set; }
        #endregion
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The instance architecture. Instance types do not necessarily support both architectures.
        /// For a list of the architectures that are supported by the different instance types,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.OpsWorks.Architecture")]
        public Amazon.OpsWorks.Architecture Architecture { get; set; }
        #endregion
        
        #region Parameter AutoScalingType
        /// <summary>
        /// <para>
        /// <para>For load-based or time-based instances, the type. Windows stacks can use only time-based
        /// instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.OpsWorks.AutoScalingType")]
        public Amazon.OpsWorks.AutoScalingType AutoScalingType { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>This property cannot be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EbsOptimized { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The instance host name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter InstallUpdatesOnBoot
        /// <summary>
        /// <para>
        /// <para>Whether to install operating system and package updates when the instance boots. The
        /// default value is <code>true</code>. To control when updates are installed, set this
        /// value to <code>false</code>. You must then update your instances manually by using
        /// <a>CreateDeployment</a> to run the <code>update_dependencies</code> stack command
        /// or by manually running <code>yum</code> (Amazon Linux) or <code>apt-get</code> (Ubuntu)
        /// on the instances. </para><note><para>We strongly recommend using the default value of <code>true</code>, to ensure that
        /// your instances have the latest security updates.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean InstallUpdatesOnBoot { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type, such as <code>t2.micro</code>. For a list of supported instance
        /// types, open the stack in the console, choose <b>Instances</b>, and choose <b>+ Instance</b>.
        /// The <b>Size</b> list contains the currently supported types. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>. The parameter values that you use to specify the various types
        /// are in the <b>API Name</b> column of the <b>Available Instance Types</b> table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter LayerId
        /// <summary>
        /// <para>
        /// <para>The instance's layer IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LayerIds")]
        public System.String[] LayerId { get; set; }
        #endregion
        
        #region Parameter Os
        /// <summary>
        /// <para>
        /// <para>The instance's operating system, which must be set to one of the following. You cannot
        /// update an instance that is using a custom AMI.</para><ul><li><para>A supported Linux operating system: An Amazon Linux version, such as <code>Amazon
        /// Linux 2017.03</code>, <code>Amazon Linux 2016.09</code>, <code>Amazon Linux 2016.03</code>,
        /// <code>Amazon Linux 2015.09</code>, or <code>Amazon Linux 2015.03</code>.</para></li><li><para>A supported Ubuntu operating system, such as <code>Ubuntu 16.04 LTS</code>, <code>Ubuntu
        /// 14.04 LTS</code>, or <code>Ubuntu 12.04 LTS</code>.</para></li><li><para><code>CentOS Linux 7</code></para></li><li><para><code>Red Hat Enterprise Linux 7</code></para></li><li><para>A supported Windows operating system, such as <code>Microsoft Windows Server 2012
        /// R2 Base</code>, <code>Microsoft Windows Server 2012 R2 with SQL Server Express</code>,
        /// <code>Microsoft Windows Server 2012 R2 with SQL Server Standard</code>, or <code>Microsoft
        /// Windows Server 2012 R2 with SQL Server Web</code>.</para></li></ul><para>For more information on the supported operating systems, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-os.html">AWS
        /// OpsWorks Stacks Operating Systems</a>.</para><para>The default option is the current Amazon Linux version. If you set this parameter
        /// to <code>Custom</code>, you must use the AmiId parameter to specify the custom AMI
        /// that you want to use. For more information on the supported operating systems, see
        /// <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-os.html">Operating
        /// Systems</a>. For more information on how to use custom AMIs with OpsWorks, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-custom-ami.html">Using
        /// Custom AMIs</a>.</para><note><para>You can specify a different Linux operating system for the updated stack, but you
        /// cannot change from Linux to Windows or Windows to Linux.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Os { get; set; }
        #endregion
        
        #region Parameter SshKeyName
        /// <summary>
        /// <para>
        /// <para>The instance's Amazon EC2 key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SshKeyName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the InstanceId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AgentVersion = this.AgentVersion;
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
                context.LayerIds = new List<System.String>(this.LayerId);
            }
            context.Os = this.Os;
            context.SshKeyName = this.SshKeyName;
            
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
            var request = new Amazon.OpsWorks.Model.UpdateInstanceRequest();
            
            if (cmdletContext.AgentVersion != null)
            {
                request.AgentVersion = cmdletContext.AgentVersion;
            }
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.OpsWorks.Model.UpdateInstanceResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.UpdateInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "UpdateInstance");
            #if DESKTOP
            return client.UpdateInstance(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateInstanceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AgentVersion { get; set; }
            public System.String AmiId { get; set; }
            public Amazon.OpsWorks.Architecture Architecture { get; set; }
            public Amazon.OpsWorks.AutoScalingType AutoScalingType { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public System.String Hostname { get; set; }
            public System.Boolean? InstallUpdatesOnBoot { get; set; }
            public System.String InstanceId { get; set; }
            public System.String InstanceType { get; set; }
            public List<System.String> LayerIds { get; set; }
            public System.String Os { get; set; }
            public System.String SshKeyName { get; set; }
        }
        
    }
}
