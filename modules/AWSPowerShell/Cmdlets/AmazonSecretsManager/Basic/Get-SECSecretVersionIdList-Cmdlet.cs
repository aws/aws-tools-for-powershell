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
    /// Lists all of the versions attached to the specified secret. The output does not include
    /// the <code>SecretString</code> or <code>SecretBinary</code> fields. By default, the
    /// list includes only versions that have at least one staging label in <code>VersionStage</code>
    /// attached.
    /// 
    ///  <note><para>
    /// Always check the <code>NextToken</code> response parameter when calling any of the
    /// <code>List*</code> operations. These operations can occasionally return an empty or
    /// shorter than expected list of results even when there are more results available.
    /// When this happens, the <code>NextToken</code> response parameter contains a value
    /// to pass to the next call to the same API to request the next part of the list.
    /// </para></note><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:ListSecretVersionIds
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To list the secrets in an account, use <a>ListSecrets</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "SECSecretVersionIdList")]
    [OutputType("Amazon.SecretsManager.Model.ListSecretVersionIdsResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager ListSecretVersionIds API operation.", Operation = new[] {"ListSecretVersionIds"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.ListSecretVersionIdsResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.ListSecretVersionIdsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSECSecretVersionIdListCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter IncludeDeprecated
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies that you want the results to include versions that do not have
        /// any staging labels attached to them. Such versions are considered deprecated and are
        /// subject to deletion by Secrets Manager as needed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludeDeprecated { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>The identifier for the secret containing the versions you want to list. You can specify
        /// either the Amazon Resource Name (ARN) or the friendly name of the secret.</para><note><para>If you specify an ARN, we generally recommend that you specify a complete ARN. You
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>(Optional) Limits the number of results that you want to include in the response.
        /// If you don't include this parameter, it defaults to a value that's specific to the
        /// operation. If additional items exist beyond the maximum you specify, the <code>NextToken</code>
        /// response element is present and has a value (isn't null). Include that value as the
        /// <code>NextToken</code> request parameter in the next call to the operation to get
        /// the next part of the results. Note that Secrets Manager might return fewer results
        /// than the maximum even when there are more results available. You should check <code>NextToken</code>
        /// after every operation to ensure that you receive all of the results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>(Optional) Use this parameter in a request if you receive a <code>NextToken</code>
        /// response in a previous request that indicates that there's more output available.
        /// In a subsequent call, set it to the value of the previous call's <code>NextToken</code>
        /// response to indicate where the output should continue from.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("IncludeDeprecated"))
                context.IncludeDeprecated = this.IncludeDeprecated;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
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
            var request = new Amazon.SecretsManager.Model.ListSecretVersionIdsRequest();
            
            if (cmdletContext.IncludeDeprecated != null)
            {
                request.IncludeDeprecated = cmdletContext.IncludeDeprecated.Value;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.SecretsManager.Model.ListSecretVersionIdsResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.ListSecretVersionIdsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "ListSecretVersionIds");
            try
            {
                #if DESKTOP
                return client.ListSecretVersionIds(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListSecretVersionIdsAsync(request);
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
            public System.Boolean? IncludeDeprecated { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String SecretId { get; set; }
        }
        
    }
}
