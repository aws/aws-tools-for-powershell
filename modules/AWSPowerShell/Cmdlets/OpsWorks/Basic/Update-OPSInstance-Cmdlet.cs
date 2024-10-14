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
    /// more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS OpsWorks UpdateInstance API operation.", Operation = new[] {"UpdateInstance"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.UpdateInstanceResponse))]
    [AWSCmdletOutput("None or Amazon.OpsWorks.Model.UpdateInstanceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.OpsWorks.Model.UpdateInstanceResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateOPSInstanceCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>The default OpsWorks Stacks agent version. You have the following options:</para><ul><li><para><c>INHERIT</c> - Use the stack's default agent version setting.</para></li><li><para><i>version_number</i> - Use the specified agent version. This value overrides the
        /// stack's default setting. To update the agent version, you must edit the instance configuration
        /// and specify a new version. OpsWorks Stacks installs that version on the instance.</para></li></ul><para>The default setting is <c>INHERIT</c>. To specify an agent version, you must use the
        /// complete version number, not the abbreviated number shown on the console. For a list
        /// of available agent version numbers, call <a>DescribeAgentVersions</a>.</para><para>AgentVersion cannot be set to Chef 12.2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmiId { get; set; }
        #endregion
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The instance architecture. Instance types do not necessarily support both architectures.
        /// For a list of the architectures that are supported by the different instance types,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpsWorks.AutoScalingType")]
        public Amazon.OpsWorks.AutoScalingType AutoScalingType { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>This property cannot be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EbsOptimized { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The instance host name. The following are character limits for instance host names.</para><ul><li><para>Linux-based instances: 63 characters</para></li><li><para>Windows-based instances: 15 characters</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter InstallUpdatesOnBoot
        /// <summary>
        /// <para>
        /// <para>Whether to install operating system and package updates when the instance boots. The
        /// default value is <c>true</c>. To control when updates are installed, set this value
        /// to <c>false</c>. You must then update your instances manually by using <a>CreateDeployment</a>
        /// to run the <c>update_dependencies</c> stack command or by manually running <c>yum</c>
        /// (Amazon Linux) or <c>apt-get</c> (Ubuntu) on the instances. </para><note><para>We strongly recommend using the default value of <c>true</c>, to ensure that your
        /// instances have the latest security updates.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstallUpdatesOnBoot { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance ID.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type, such as <c>t2.micro</c>. For a list of supported instance types,
        /// open the stack in the console, choose <b>Instances</b>, and choose <b>+ Instance</b>.
        /// The <b>Size</b> list contains the currently supported types. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Families and Types</a>. The parameter values that you use to specify the various types
        /// are in the <b>API Name</b> column of the <b>Available Instance Types</b> table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// update an instance that is using a custom AMI.</para><ul><li><para>A supported Linux operating system: An Amazon Linux version, such as <c>Amazon Linux
        /// 2</c>, <c>Amazon Linux 2018.03</c>, <c>Amazon Linux 2017.09</c>, <c>Amazon Linux 2017.03</c>,
        /// <c>Amazon Linux 2016.09</c>, <c>Amazon Linux 2016.03</c>, <c>Amazon Linux 2015.09</c>,
        /// or <c>Amazon Linux 2015.03</c>.</para></li><li><para>A supported Ubuntu operating system, such as <c>Ubuntu 18.04 LTS</c>, <c>Ubuntu 16.04
        /// LTS</c>, <c>Ubuntu 14.04 LTS</c>, or <c>Ubuntu 12.04 LTS</c>.</para></li><li><para><c>CentOS Linux 7</c></para></li><li><para><c>Red Hat Enterprise Linux 7</c></para></li><li><para>A supported Windows operating system, such as <c>Microsoft Windows Server 2012 R2
        /// Base</c>, <c>Microsoft Windows Server 2012 R2 with SQL Server Express</c>, <c>Microsoft
        /// Windows Server 2012 R2 with SQL Server Standard</c>, or <c>Microsoft Windows Server
        /// 2012 R2 with SQL Server Web</c>.</para></li></ul><para>Not all operating systems are supported with all versions of Chef. For more information
        /// about supported operating systems, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-os.html">OpsWorks
        /// Stacks Operating Systems</a>.</para><para>The default option is the current Amazon Linux version. If you set this parameter
        /// to <c>Custom</c>, you must use the AmiId parameter to specify the custom AMI that
        /// you want to use. For more information about how to use custom AMIs with OpsWorks,
        /// see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-custom-ami.html">Using
        /// Custom AMIs</a>.</para><note><para>You can specify a different Linux operating system for the updated stack, but you
        /// cannot change from Linux to Windows or Windows to Linux.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Os { get; set; }
        #endregion
        
        #region Parameter SshKeyName
        /// <summary>
        /// <para>
        /// <para>The instance's Amazon EC2 key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SshKeyName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.UpdateInstanceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSInstance (UpdateInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.UpdateInstanceResponse, UpdateOPSInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AgentVersion = this.AgentVersion;
            context.AmiId = this.AmiId;
            context.Architecture = this.Architecture;
            context.AutoScalingType = this.AutoScalingType;
            context.EbsOptimized = this.EbsOptimized;
            context.Hostname = this.Hostname;
            context.InstallUpdatesOnBoot = this.InstallUpdatesOnBoot;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceType = this.InstanceType;
            if (this.LayerId != null)
            {
                context.LayerId = new List<System.String>(this.LayerId);
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
            if (cmdletContext.LayerId != null)
            {
                request.LayerIds = cmdletContext.LayerId;
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
        
        private Amazon.OpsWorks.Model.UpdateInstanceResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.UpdateInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "UpdateInstance");
            try
            {
                #if DESKTOP
                return client.UpdateInstance(request);
                #elif CORECLR
                return client.UpdateInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentVersion { get; set; }
            public System.String AmiId { get; set; }
            public Amazon.OpsWorks.Architecture Architecture { get; set; }
            public Amazon.OpsWorks.AutoScalingType AutoScalingType { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public System.String Hostname { get; set; }
            public System.Boolean? InstallUpdatesOnBoot { get; set; }
            public System.String InstanceId { get; set; }
            public System.String InstanceType { get; set; }
            public List<System.String> LayerId { get; set; }
            public System.String Os { get; set; }
            public System.String SshKeyName { get; set; }
            public System.Func<Amazon.OpsWorks.Model.UpdateInstanceResponse, UpdateOPSInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
