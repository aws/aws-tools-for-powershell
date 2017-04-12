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
    /// Runs deployment or stack commands. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingapps-deploying.html">Deploying
    /// Apps</a> and <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-commands.html">Run
    /// Stack Commands</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Deploy or
    /// Manage permissions level for the stack, or an attached policy that explicitly grants
    /// permissions. For more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OPSDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDeployment operation against AWS OpsWorks.", Operation = new[] {"CreateDeployment"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.OpsWorks.Model.CreateDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOPSDeploymentCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
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
        /// with the following format:</para><para><code>{"arg_name1" : ["value1", "value2", ...], "arg_name2" : ["value1", "value2",
        /// ...], ...}</code></para><para>The <code>update_dependencies</code> command takes two arguments:</para><ul><li><para><code>upgrade_os_to</code> - Specifies the desired Amazon Linux version for instances
        /// whose OS you want to upgrade, such as <code>Amazon Linux 2014.09</code>. You must
        /// also set the <code>allow_reboot</code> argument to true.</para></li><li><para><code>allow_reboot</code> - Specifies whether to allow AWS OpsWorks Stacks to reboot
        /// the instances if necessary, after installing the updates. This argument can be set
        /// to either <code>true</code> or <code>false</code>. The default value is <code>false</code>.</para></li></ul><para>For example, to upgrade an instance to Amazon Linux 2014.09, set <code>Args</code>
        /// to the following.</para><para><code> { "upgrade_os_to":["Amazon Linux 2014.09"], "allow_reboot":["true"] } </code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Command_Args")]
        public System.Collections.Hashtable Command_Arg { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>A user-defined comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter CustomJson
        /// <summary>
        /// <para>
        /// <para>A string that contains user-defined, custom JSON. It is used to override the corresponding
        /// default stack configuration JSON values. The string should be in the following format:</para><para><code>"{\"key1\": \"value1\", \"key2\": \"value2\",...}"</code></para><para>For more information on custom JSON, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-json.html">Use
        /// Custom JSON to Modify the Stack Configuration Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
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
        /// <para>Specifies the operation. You can specify only one command.</para><para>For stacks, the following commands are available:</para><ul><li><para><code>execute_recipes</code>: Execute one or more recipes. To specify the recipes,
        /// set an <code>Args</code> parameter named <code>recipes</code> to the list of recipes
        /// to be executed. For example, to execute <code>phpapp::appsetup</code>, set <code>Args</code>
        /// to <code>{"recipes":["phpapp::appsetup"]}</code>.</para></li><li><para><code>install_dependencies</code>: Install the stack's dependencies.</para></li><li><para><code>update_custom_cookbooks</code>: Update the stack's custom cookbooks.</para></li><li><para><code>update_dependencies</code>: Update the stack's dependencies.</para></li></ul><note><para>The update_dependencies and install_dependencies commands are supported only for Linux
        /// instances. You can run the commands successfully on Windows instances, but they do
        /// nothing.</para></note><para>For apps, the following commands are available:</para><ul><li><para><code>deploy</code>: Deploy an app. Ruby on Rails apps have an optional <code>Args</code>
        /// parameter named <code>migrate</code>. Set <code>Args</code> to {"migrate":["true"]}
        /// to migrate the database. The default setting is {"migrate":["false"]}.</para></li><li><para><code>rollback</code> Roll the app back to the previous version. When you update
        /// an app, AWS OpsWorks Stacks stores the previous version, up to a maximum of five versions.
        /// You can use this command to roll an app back as many as four versions.</para></li><li><para><code>start</code>: Start the app's web or application server.</para></li><li><para><code>stop</code>: Stop the app's web or application server.</para></li><li><para><code>restart</code>: Restart the app's web or application server.</para></li><li><para><code>undeploy</code>: Undeploy the app.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.OpsWorks.DeploymentCommandName")]
        public Amazon.OpsWorks.DeploymentCommandName Command_Name { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSDeployment (CreateDeployment)"))
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
            
            context.AppId = this.AppId;
            if (this.Command_Arg != null)
            {
                context.Command_Args = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Command_Arg.Keys)
                {
                    object hashValue = this.Command_Arg[hashKey];
                    if (hashValue == null)
                    {
                        context.Command_Args.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Command_Args.Add((String)hashKey, valueSet);
                }
            }
            context.Command_Name = this.Command_Name;
            context.Comment = this.Comment;
            context.CustomJson = this.CustomJson;
            if (this.InstanceId != null)
            {
                context.InstanceIds = new List<System.String>(this.InstanceId);
            }
            if (this.LayerId != null)
            {
                context.LayerIds = new List<System.String>(this.LayerId);
            }
            context.StackId = this.StackId;
            
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
            bool requestCommandIsNull = true;
            request.Command = new Amazon.OpsWorks.Model.DeploymentCommand();
            Dictionary<System.String, List<System.String>> requestCommand_command_Arg = null;
            if (cmdletContext.Command_Args != null)
            {
                requestCommand_command_Arg = cmdletContext.Command_Args;
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
            if (cmdletContext.InstanceIds != null)
            {
                request.InstanceIds = cmdletContext.InstanceIds;
            }
            if (cmdletContext.LayerIds != null)
            {
                request.LayerIds = cmdletContext.LayerIds;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeploymentId;
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
        
        private static Amazon.OpsWorks.Model.CreateDeploymentResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.CreateDeploymentRequest request)
        {
            #if DESKTOP
            return client.CreateDeployment(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateDeploymentAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AppId { get; set; }
            public Dictionary<System.String, List<System.String>> Command_Args { get; set; }
            public Amazon.OpsWorks.DeploymentCommandName Command_Name { get; set; }
            public System.String Comment { get; set; }
            public System.String CustomJson { get; set; }
            public List<System.String> InstanceIds { get; set; }
            public List<System.String> LayerIds { get; set; }
            public System.String StackId { get; set; }
        }
        
    }
}
