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
    /// Uploads an SSH public key and associates it with the specified IAM user.
    /// 
    ///  
    /// <para>
    /// The SSH public key uploaded by this action can be used only for authenticating the
    /// associated IAM user to an AWS CodeCommit repository. For more information about using
    /// SSH keys to authenticate to an AWS CodeCommit repository, see <a href="http://docs.aws.amazon.com/codecommit/latest/userguide/setting-up-credentials-ssh.html">Set
    /// up AWS CodeCommit for SSH Connections</a> in the <i>AWS CodeCommit User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "IAMSSHPublicKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.SSHPublicKey")]
    [AWSCmdlet("Invokes the UploadSSHPublicKey operation against AWS Identity and Access Management.", Operation = new[] {"UploadSSHPublicKey"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.SSHPublicKey",
        "This cmdlet returns a SSHPublicKey object.",
        "The service call response (type Amazon.IdentityManagement.Model.UploadSSHPublicKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishIAMSSHPublicKeyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter SSHPublicKeyBody
        /// <summary>
        /// <para>
        /// <para>The SSH public key. The public key must be encoded in ssh-rsa format or PEM format.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for this parameter
        /// is a string of characters consisting of any printable ASCII character ranging from
        /// the space character (\u0020) through end of the ASCII character range (\u00FF). It
        /// also includes the special characters tab (\u0009), line feed (\u000A), and carriage
        /// return (\u000D).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SSHPublicKeyBody { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM user to associate the SSH public key with.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for this parameter
        /// is a string of characters consisting of upper and lowercase alphanumeric characters
        /// with no spaces. You can also include any of the following characters: =,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-IAMSSHPublicKey (UploadSSHPublicKey)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SSHPublicKeyBody = this.SSHPublicKeyBody;
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.UploadSSHPublicKeyRequest();
            
            if (cmdletContext.SSHPublicKeyBody != null)
            {
                request.SSHPublicKeyBody = cmdletContext.SSHPublicKeyBody;
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
                var response = client.UploadSSHPublicKey(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SSHPublicKey;
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
            public System.String SSHPublicKeyBody { get; set; }
            public System.String UserName { get; set; }
        }
        
    }
}
