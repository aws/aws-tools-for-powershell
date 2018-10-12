/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Deletes the resource-based permission policy that's attached to the secret.
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:DeleteResourcePolicy
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To attach a resource policy to a secret, use <a>PutResourcePolicy</a>.
    /// </para></li><li><para>
    /// To retrieve the current resource-based policy that's attached to a secret, use <a>GetResourcePolicy</a>.
    /// </para></li><li><para>
    /// To list all of the currently available secrets, use <a>ListSecrets</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "SECResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.SecretsManager.Model.DeleteResourcePolicyResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager DeleteResourcePolicy API operation.", Operation = new[] {"DeleteResourcePolicy"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.DeleteResourcePolicyResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.DeleteResourcePolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSECResourcePolicyCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret that you want to delete the attached resource-based policy for.
        /// You can specify either the Amazon Resource Name (ARN) or the friendly name of the
        /// secret.</para><note><para>If you specify an ARN, we generally recommend that you specify a complete ARN. You
        /// can specify a partial ARN too—for example, if you don’t include the final hyphen and
        /// six random characters that Secrets Manager adds at the end of the ARN when you created
        /// the secret. A partial ARN match can work as long as it uniquely matches only one secret.
        /// However, if your secret has a name that ends in a hyphen followed by six characters
        /// (before Secrets Manager adds the hyphen and six characters to the ARN) and you try
        /// to use that as a partial ARN, then those characters cause Secrets Manager to assume
        /// that you’re specifying a complete ARN. This confusion can cause unexpected results.
        /// To avoid this situation, we recommend that you don’t create secret names that end
        /// with a hyphen followed by six characters.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SecretId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SECResourcePolicy (DeleteResourcePolicy)"))
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
            
            context.SecretId = this.SecretId;
            
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
            var request = new Amazon.SecretsManager.Model.DeleteResourcePolicyRequest();
            
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.SecretsManager.Model.DeleteResourcePolicyResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.DeleteResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "DeleteResourcePolicy");
            try
            {
                #if DESKTOP
                return client.DeleteResourcePolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteResourcePolicyAsync(request);
                return task.Result;
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
            public System.String SecretId { get; set; }
        }
        
    }
}
