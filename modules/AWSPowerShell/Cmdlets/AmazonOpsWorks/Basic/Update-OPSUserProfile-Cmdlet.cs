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
    /// Updates a specified user profile.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have an attached
    /// policy that explicitly grants permissions. For more information on user permissions,
    /// see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSUserProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateUserProfile operation against AWS OpsWorks.", Operation = new[] {"UpdateUserProfile"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the IamUserArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type UpdateUserProfileResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateOPSUserProfileCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Whether users can specify their own SSH public key through the My Settings page. For
        /// more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/security-settingsshkey.html">Managing
        /// User Permissions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AllowSelfManagement { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user IAM ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String IamUserArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user's new SSH public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SshPublicKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The user's SSH user name. The allowable characters are [a-z], [A-Z], [0-9], '-', and
        /// '_'. If the specified name includes other punctuation marks, AWS OpsWorks removes
        /// them. For example, <code>my.name</code> will be changed to <code>myname</code>. If
        /// you do not specify an SSH user name, AWS OpsWorks generates one from the IAM user
        /// name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SshUsername { get; set; }
        
        /// <summary>
        /// Returns the value passed to the IamUserArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("IamUserArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSUserProfile (UpdateUserProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AllowSelfManagement"))
                context.AllowSelfManagement = this.AllowSelfManagement;
            context.IamUserArn = this.IamUserArn;
            context.SshPublicKey = this.SshPublicKey;
            context.SshUsername = this.SshUsername;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateUserProfileRequest();
            
            if (cmdletContext.AllowSelfManagement != null)
            {
                request.AllowSelfManagement = cmdletContext.AllowSelfManagement.Value;
            }
            if (cmdletContext.IamUserArn != null)
            {
                request.IamUserArn = cmdletContext.IamUserArn;
            }
            if (cmdletContext.SshPublicKey != null)
            {
                request.SshPublicKey = cmdletContext.SshPublicKey;
            }
            if (cmdletContext.SshUsername != null)
            {
                request.SshUsername = cmdletContext.SshUsername;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateUserProfile(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.IamUserArn;
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
            public Boolean? AllowSelfManagement { get; set; }
            public String IamUserArn { get; set; }
            public String SshPublicKey { get; set; }
            public String SshUsername { get; set; }
        }
        
    }
}
