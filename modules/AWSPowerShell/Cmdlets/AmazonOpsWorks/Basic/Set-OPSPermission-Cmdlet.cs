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
    /// Specifies a user's permissions. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingsecurity.html">Security
    /// and Permissions</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "OPSPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetPermission operation against AWS OpsWorks.", Operation = new[] {"SetPermission"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StackId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type SetPermissionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetOPSPermissionCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The user is allowed to use SSH to communicate with the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Boolean AllowSsh { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user is allowed to use <b>sudo</b> to elevate privileges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public Boolean AllowSudo { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user's IAM ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String IamUserArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user's permission level, which must be set to one of the following strings. You
        /// cannot set your own permissions level.</para><ul><li><code>deny</code></li><li><code>show</code></li><li><code>deploy</code></li><li><code>manage</code></li><li><code>iam_only</code></li></ul><para>For more information on the permissions associated with these levels, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
        /// User Permissions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Level { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackId { get; set; }
        
        /// <summary>
        /// Returns the value passed to the StackId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OPSPermission (SetPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AllowSsh"))
                context.AllowSsh = this.AllowSsh;
            if (ParameterWasBound("AllowSudo"))
                context.AllowSudo = this.AllowSudo;
            context.IamUserArn = this.IamUserArn;
            context.Level = this.Level;
            context.StackId = this.StackId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SetPermissionRequest();
            
            if (cmdletContext.AllowSsh != null)
            {
                request.AllowSsh = cmdletContext.AllowSsh.Value;
            }
            if (cmdletContext.AllowSudo != null)
            {
                request.AllowSudo = cmdletContext.AllowSudo.Value;
            }
            if (cmdletContext.IamUserArn != null)
            {
                request.IamUserArn = cmdletContext.IamUserArn;
            }
            if (cmdletContext.Level != null)
            {
                request.Level = cmdletContext.Level;
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
                var response = client.SetPermission(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StackId;
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
            public Boolean? AllowSsh { get; set; }
            public Boolean? AllowSudo { get; set; }
            public String IamUserArn { get; set; }
            public String Level { get; set; }
            public String StackId { get; set; }
        }
        
    }
}
