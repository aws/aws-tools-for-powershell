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
    /// Retrieves the specified SSH public key, including metadata about the key.
    /// 
    ///  
    /// <para>
    /// The SSH public key retrieved by this action is used only for authenticating the associated
    /// IAM user to an AWS CodeCommit repository. For more information about using SSH keys
    /// to authenticate to an AWS CodeCommit repository, see <a href="http://docs.aws.amazon.com/codecommit/latest/userguide/setting-up-credentials-ssh.html">Set
    /// up AWS CodeCommit for SSH Connections</a> in the <i>AWS CodeCommit User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMSSHPublicKey")]
    [OutputType("Amazon.IdentityManagement.Model.SSHPublicKey")]
    [AWSCmdlet("Invokes the GetSSHPublicKey operation against AWS Identity and Access Management.", Operation = new[] {"GetSSHPublicKey"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.SSHPublicKey",
        "This cmdlet returns a SSHPublicKey object.",
        "The service call response (type Amazon.IdentityManagement.Model.GetSSHPublicKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetIAMSSHPublicKeyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Specifies the public key encoding format to use in the response. To retrieve the public
        /// key in ssh-rsa format, use <code>SSH</code>. To retrieve the public key in PEM format,
        /// use <code>PEM</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.IdentityManagement.EncodingType Encoding { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the SSH public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SSHPublicKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the IAM user associated with the SSH public key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Encoding = this.Encoding;
            context.SSHPublicKeyId = this.SSHPublicKeyId;
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.GetSSHPublicKeyRequest();
            
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
            }
            if (cmdletContext.SSHPublicKeyId != null)
            {
                request.SSHPublicKeyId = cmdletContext.SSHPublicKeyId;
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
                var response = client.GetSSHPublicKey(request);
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
            public Amazon.IdentityManagement.EncodingType Encoding { get; set; }
            public System.String SSHPublicKeyId { get; set; }
            public System.String UserName { get; set; }
        }
        
    }
}
