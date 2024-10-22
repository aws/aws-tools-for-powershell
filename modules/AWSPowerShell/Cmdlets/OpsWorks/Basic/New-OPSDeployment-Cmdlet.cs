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
    /// Runs deployment or stack commands. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingapps-deploying.html">Deploying
    /// Apps</a> and <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-commands.html">Run
    /// Stack Commands</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Deploy or
    /// Manage permissions level for the stack, or an attached policy that explicitly grants
    /// permissions. For more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OPSDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS OpsWorks CreateDeployment API operation.", Operation = new[] {"CreateDeployment"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.CreateDeploymentResponse))]
    [AWSCmdletOutput("System.String or Amazon.OpsWorks.Model.CreateDeploymentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.OpsWorks.Model.CreateDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOPSDeploymentCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The app ID. This parameter is required for app deployments, but not for other deployment
        /// commands.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter Command_Arg
        /// <summary>
        /// <para>
        /// <para>The arguments of those commands that take arguments. It should be set to a JSON object
        /// with the following format:</para><para><c>{"arg_name1" : ["value1", "value2", ...], "arg_name2" : ["value1", "value2", ...],
        /// ...}</c></para><para>The <c>update_dependencies</c> command takes two arguments:</para><ul><li><para><c>upgrade_os_to</c> - Specifies the Amazon Linux version that you want instances
        /// to run, such as <c>Amazon Linux 2</c>. You must also set the <c>allow_reboot</c> argument
        /// to true.</para></li><li><para><c>allow_reboot</c> - Specifies whether to allow OpsWorks Stacks to reboot the instances
        /// if necessary, after installing the updates. This argument can be set to either <c>true</c>
        /// or <c>false</c>. The default value is <c>false</c>.</para></li></ul><para>For example, to upgrade an instance to Amazon Linux 2018.03, set <c>Args</c> to the
        /// following.</para><para><c> { "upgrade_os_to":["Amazon Linux 2018.03"], "allow_reboot":["true"] } </c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Command_Args")]
        public System.Collections.Hashtable Command_Arg { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>A user-defined comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter CustomJson
        /// <summary>
        /// <para>
        /// <para>A string that contains user-defined, custom JSON. You can use this parameter to override
        /// some corresponding default stack configuration JSON values. The string should be in
        /// the following format:</para><para><c>"{\"key1\": \"value1\", \"key2\": \"value2\",...}"</c></para><para>For more information about custom JSON, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-json.html">Use
        /// Custom JSON to Modify the Stack Configuration Attributes</a> and <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingcookbook-json-override.html">Overriding
        /// Attributes With Custom JSON</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String CustomJson { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance IDs for the deployment targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter LayerId
        /// <summary>
        /// <para>
        /// <para>The layer IDs for the deployment targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LayerIds")]
        public System.String[] LayerId { get; set; }
        #endregion
        
        #region Parameter Command_Name
        /// <summary>
        /// <para>
        /// <para>Specifies the operation. You can specify only one command.</para><para>For stacks, the following commands are available:</para><ul><li><para><c>execute_recipes</c>: Execute one or more recipes. To specify the recipes, set
        /// an <c>Args</c> parameter named <c>recipes</c> to the list of recipes to be executed.
        /// For example, to execute <c>phpapp::appsetup</c>, set <c>Args</c> to <c>{"recipes":["phpapp::appsetup"]}</c>.</para></li><li><para><c>install_dependencies</c>: Install the stack's dependencies.</para></li><li><para><c>update_custom_cookbooks</c>: Update the stack's custom cookbooks.</para></li><li><para><c>update_dependencies</c>: Update the stack's dependencies.</para></li></ul><note><para>The update_dependencies and install_dependencies commands are supported only for Linux
        /// instances. You can run the commands successfully on Windows instances, but they do
        /// nothing.</para></note><para>For apps, the following commands are available:</para><ul><li><para><c>deploy</c>: Deploy an app. Ruby on Rails apps have an optional <c>Args</c> parameter
        /// named <c>migrate</c>. Set <c>Args</c> to {"migrate":["true"]} to migrate the database.
        /// The default setting is {"migrate":["false"]}.</para></li><li><para><c>rollback</c> Roll the app back to the previous version. When you update an app,
        /// OpsWorks Stacks stores the previous version, up to a maximum of five versions. You
        /// can use this command to roll an app back as many as four versions.</para></li><li><para><c>start</c>: Start the app's web or application server.</para></li><li><para><c>stop</c>: Stop the app's web or application server.</para></li><li><para><c>restart</c>: Restart the app's web or application server.</para></li><li><para><c>undeploy</c>: Undeploy the app.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpsWorks.DeploymentCommandName")]
        public Amazon.OpsWorks.DeploymentCommandName Command_Name { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
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
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeploymentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.CreateDeploymentResponse).
        /// Specifying the name of a property of type Amazon.OpsWorks.Model.CreateDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeploymentId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSDeployment (CreateDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.CreateDeploymentResponse, NewOPSDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            if (this.Command_Arg != null)
            {
                context.Command_Arg = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Command_Arg.Keys)
                {
                    object hashValue = this.Command_Arg[hashKey];
                    if (hashValue == null)
                    {
                        context.Command_Arg.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Command_Arg.Add((String)hashKey, valueSet);
                }
            }
            context.Command_Name = this.Command_Name;
            #if MODULAR
            if (this.Command_Name == null && ParameterWasBound(nameof(this.Command_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Command_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Comment = this.Comment;
            context.CustomJson = this.CustomJson;
            if (this.InstanceId != null)
            {
                context.InstanceId = new List<System.String>(this.InstanceId);
            }
            if (this.LayerId != null)
            {
                context.LayerId = new List<System.String>(this.LayerId);
            }
            context.StackId = this.StackId;
            #if MODULAR
            if (this.StackId == null && ParameterWasBound(nameof(this.StackId)))
            {
                WriteWarning("You are passing $null as a value for parameter StackId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.OpsWorks.Model.CreateDeploymentRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            
             // populate Command
            var requestCommandIsNull = true;
            request.Command = new Amazon.OpsWorks.Model.DeploymentCommand();
            Dictionary<System.String, List<System.String>> requestCommand_command_Arg = null;
            if (cmdletContext.Command_Arg != null)
            {
                requestCommand_command_Arg = cmdletContext.Command_Arg;
            }
            if (requestCommand_command_Arg != null)
            {
                request.Command.Args = requestCommand_command_Arg;
                requestCommandIsNull = false;
            }
            Amazon.OpsWorks.DeploymentCommandName requestCommand_command_Name = null;
            if (cmdletContext.Command_Name != null)
            {
                requestCommand_command_Name = cmdletContext.Command_Name;
            }
            if (requestCommand_command_Name != null)
            {
                request.Command.Name = requestCommand_command_Name;
                requestCommandIsNull = false;
            }
             // determine if request.Command should be set to null
            if (requestCommandIsNull)
            {
                request.Command = null;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.CustomJson != null)
            {
                request.CustomJson = cmdletContext.CustomJson;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.LayerId != null)
            {
                request.LayerIds = cmdletContext.LayerId;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
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
        
        private Amazon.OpsWorks.Model.CreateDeploymentResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.CreateDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "CreateDeployment");
            try
            {
                #if DESKTOP
                return client.CreateDeployment(request);
                #elif CORECLR
                return client.CreateDeploymentAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public Dictionary<System.String, List<System.String>> Command_Arg { get; set; }
            public Amazon.OpsWorks.DeploymentCommandName Command_Name { get; set; }
            public System.String Comment { get; set; }
            public System.String CustomJson { get; set; }
            public List<System.String> InstanceId { get; set; }
            public List<System.String> LayerId { get; set; }
            public System.String StackId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.CreateDeploymentResponse, NewOPSDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeploymentId;
        }
        
    }
}
