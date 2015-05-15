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
        "The service call response (type CreateDeploymentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewOPSDeploymentCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The app ID. This parameter is required for app deployments, but not for other deployment
        /// commands.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String AppId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The arguments of those commands that take arguments. It should be set to a JSON object
        /// with the following format:</para><para><code>{"arg_name1" : ["value1", "value2", ...], "arg_name2" : ["value1", "value2",
        /// ...], ...}</code></para><para>The <code>update_dependencies</code> command takes two arguments:</para><ul><li><code>upgrade_os_to</code> - Specifies the desired Amazon Linux version
        /// for instances whose OS you want to upgrade, such as <code>Amazon Linux 2014.09</code>.
        /// You must also set the <code>allow_reboot</code> argument to true.</li><li><code>allow_reboot</code>
        /// - Specifies whether to allow AWS OpsWorks to reboot the instances if necessary, after
        /// installing the updates. This argument can be set to either <code>true</code> or <code>false</code>.
        /// The default value is <code>false</code>.</li></ul><para>For example, to upgrade an instance to Amazon Linux 2014.09, set <code>Args</code>
        /// to the following.</para><code> { "upgrade_os_to":["Amazon Linux 2014.09"], "allow_reboot":["true"] } </code>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Command_Args")]
        public System.Collections.Hashtable Command_Arg { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-defined comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String Comment { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A string that contains user-defined, custom JSON. It is used to override the corresponding
        /// default stack configuration JSON values. The string should be in the following format
        /// and must escape characters such as '"'.:</para><para><code>"{\"key1\": \"value1\", \"key2\": \"value2\",...}"</code></para><para>For more information on custom JSON, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-json.html">Use
        /// Custom JSON to Modify the Stack Configuration JSON</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public String CustomJson { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance IDs for the deployment targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the operation. You can specify only one command.</para><para>For stacks, the following commands are available:</para><ul><li><code>execute_recipes</code>: Execute one or more recipes. To specify the
        /// recipes, set an <code>Args</code> parameter named <code>recipes</code> to the list
        /// of recipes to be executed. For example, to execute <code>phpapp::appsetup</code>,
        /// set <code>Args</code> to <code>{"recipes":["phpapp::appsetup"]}</code>.</li><li><code>install_dependencies</code>: Install the stack's dependencies.</li><li><code>update_custom_cookbooks</code>:
        /// Update the stack's custom cookbooks.</li><li><code>update_dependencies</code>: Update
        /// the stack's dependencies.</li></ul><para>For apps, the following commands are available:</para><ul><li><code>deploy</code>: Deploy an app. Rails apps have an optional <code>Args</code>
        /// parameter named <code>migrate</code>. Set <code>Args</code> to {"migrate":["true"]}
        /// to migrate the database. The default setting is {"migrate":["false"]}.</li><li><code>rollback</code>
        /// Roll the app back to the previous version. When you update an app, AWS OpsWorks stores
        /// the previous version, up to a maximum of five versions. You can use this command to
        /// roll an app back as many as four versions.</li><li><code>start</code>: Start the
        /// app's web or application server.</li><li><code>stop</code>: Stop the app's web or
        /// application server.</li><li><code>restart</code>: Restart the app's web or application
        /// server.</li><li><code>undeploy</code>: Undeploy the app.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DeploymentCommandName Command_Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSDeployment (CreateDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AppId = this.AppId;
            if (this.Command_Arg != null)
            {
                context.Command_Args = new Dictionary<String, List<String>>(StringComparer.Ordinal);
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
                context.InstanceIds = new List<String>(this.InstanceId);
            }
            context.StackId = this.StackId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDeploymentRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            
             // populate Command
            bool requestCommandIsNull = true;
            request.Command = new DeploymentCommand();
            Dictionary<String, List<String>> requestCommand_command_Arg = null;
            if (cmdletContext.Command_Args != null)
            {
                requestCommand_command_Arg = cmdletContext.Command_Args;
            }
            if (requestCommand_command_Arg != null)
            {
                request.Command.Args = requestCommand_command_Arg;
                requestCommandIsNull = false;
            }
            DeploymentCommandName requestCommand_command_Name = null;
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
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDeployment(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AppId { get; set; }
            public Dictionary<String, List<String>> Command_Args { get; set; }
            public DeploymentCommandName Command_Name { get; set; }
            public String Comment { get; set; }
            public String CustomJson { get; set; }
            public List<String> InstanceIds { get; set; }
            public String StackId { get; set; }
        }
        
    }
}
