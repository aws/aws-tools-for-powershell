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
    /// Attaches the contents of the specified resource-based permission policy to a secret.
    /// A resource-based policy is optional. Alternatively, you can use IAM identity-based
    /// policies that specify the secret's Amazon Resource Name (ARN) in the policy statement's
    /// <code>Resources</code> element. You can also use a combination of both identity-based
    /// and resource-based policies. The affected users and roles receive the permissions
    /// that are permitted by all of the relevant policies. For more information, see <a href="http://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access_resource-based-policies.html">Using
    /// Resource-Based Policies for AWS Secrets Manager</a>. For the complete description
    /// of the AWS policy syntax and grammar, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies.html">IAM
    /// JSON Policy Reference</a> in the <i>IAM User Guide</i>.
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:PutResourcePolicy
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To retrieve the resource policy that's attached to a secret, use <a>GetResourcePolicy</a>.
    /// </para></li><li><para>
    /// To delete the resource-based policy that's attached to a secret, use <a>DeleteResourcePolicy</a>.
    /// </para></li><li><para>
    /// To list all of the currently available secrets, use <a>ListSecrets</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "SECResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.PutResourcePolicyResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager PutResourcePolicy API operation.", Operation = new[] {"PutResourcePolicy"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.PutResourcePolicyResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.PutResourcePolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSECResourcePolicyCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ResourcePolicy
        /// <summary>
        /// <para>
        /// <para>A JSON-formatted string that's constructed according to the grammar and syntax for
        /// an AWS resource-based policy. The policy in the string identifies who can access or
        /// manage this secret and its versions. For information on how to format a JSON parameter
        /// for the various command line tool environments, see <a href="http://docs.aws.amazon.com/cli/latest/userguide/cli-using-param.html#cli-using-param-json">Using
        /// JSON for Parameters</a> in the <i>AWS CLI User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourcePolicy { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret that you want to attach the resource-based policy to. You can
        /// specify either the ARN or the friendly name of the secret.</para><note><para>If you specify an ARN, we generally recommend that you specify a complete ARN. You
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
        [System.Management.Automation.Parameter]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SECResourcePolicy (PutResourcePolicy)"))
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
            
            context.ResourcePolicy = this.ResourcePolicy;
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
            var request = new Amazon.SecretsManager.Model.PutResourcePolicyRequest();
            
            if (cmdletContext.ResourcePolicy != null)
            {
                request.ResourcePolicy = cmdletContext.ResourcePolicy;
            }
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
        
        private Amazon.SecretsManager.Model.PutResourcePolicyResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.PutResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "PutResourcePolicy");
            try
            {
                #if DESKTOP
                return client.PutResourcePolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutResourcePolicyAsync(request);
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
            public System.String ResourcePolicy { get; set; }
            public System.String SecretId { get; set; }
        }
        
    }
}
