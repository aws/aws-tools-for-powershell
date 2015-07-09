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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Sets the status of the specified SSH public key to active or inactive. SSH public
    /// keys that are inactive cannot be used for authentication. This action can be used
    /// to disable a user's SSH public key as part of a key rotation work flow. 
    /// 
    ///  
    /// <para>
    /// The SSH public key affected by this action is used only for authenticating the associated
    /// IAM user to an AWS CodeCommit repository. For more information about using SSH keys
    /// to authenticate to an AWS CodeCommit repository, see <a href="http://docs.aws.amazon.com/codecommit/latest/userguide/setting-up-credentials-ssh.html">Set
    /// up AWS CodeCommit for SSH Connections</a> in the <i>AWS CodeCommit User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMSSHPublicKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateSSHPublicKey operation against AWS Identity and Access Management.", Operation = new[] {"UpdateSSHPublicKey"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the SSHPublicKeyId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type UpdateSSHPublicKeyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateIAMSSHPublicKeyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the SSH public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String SSHPublicKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The status to assign to the SSH public key. <code>Active</code> means the key can
        /// be used for authentication with an AWS CodeCommit repository. <code>Inactive</code>
        /// means the key cannot be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public StatusType Status { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the IAM user associated with the SSH public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String UserName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the SSHPublicKeyId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SSHPublicKeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMSSHPublicKey (UpdateSSHPublicKey)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SSHPublicKeyId = this.SSHPublicKeyId;
            context.Status = this.Status;
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateSSHPublicKeyRequest();
            
            if (cmdletContext.SSHPublicKeyId != null)
            {
                request.SSHPublicKeyId = cmdletContext.SSHPublicKeyId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateSSHPublicKey(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.SSHPublicKeyId;
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
            public String SSHPublicKeyId { get; set; }
            public StatusType Status { get; set; }
            public String UserName { get; set; }
        }
        
    }
}
