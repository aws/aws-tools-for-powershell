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
    /// Creates a new AWS secret access key and corresponding AWS access key ID for the specified
    /// user. The default status for new keys is <code>Active</code>.
    /// 
    ///  
    /// <para>
    /// If you do not specify a user name, IAM determines the user name implicitly based on
    /// the AWS access key ID signing the request. Because this action works for access keys
    /// under the AWS account, you can use this action to manage root credentials even if
    /// the AWS account has no associated users.
    /// </para><para>
    ///  For information about limits on the number of keys you can create, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/LimitationsOnEntities.html">Limitations
    /// on IAM Entities</a> in the <i>IAM User Guide</i>.
    /// </para><important><para>
    /// To ensure the security of your AWS account, the secret access key is accessible only
    /// during key and user creation. You must save the key (for example, in a text file)
    /// if you want to be able to access it again. If a secret key is lost, you can delete
    /// the access keys for the associated user and then create new keys.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "IAMAccessKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.AccessKey")]
    [AWSCmdlet("Invokes the CreateAccessKey operation against AWS Identity and Access Management.", Operation = new[] {"CreateAccessKey"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.AccessKey",
        "This cmdlet returns a AccessKey object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateAccessKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewIAMAccessKeyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM user that the new key will belong to.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for this parameter
        /// is a string of characters consisting of upper and lowercase alphanumeric characters
        /// with no spaces. You can also include any of the following characters: =,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMAccessKey (CreateAccessKey)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.CreateAccessKeyRequest();
            
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateAccessKey(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AccessKey;
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
            public System.String UserName { get; set; }
        }
        
    }
}
