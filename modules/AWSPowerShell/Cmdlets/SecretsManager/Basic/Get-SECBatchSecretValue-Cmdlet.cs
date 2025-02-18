/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Retrieves the contents of the encrypted fields <c>SecretString</c> or <c>SecretBinary</c>
    /// for up to 20 secrets. To retrieve a single secret, call <a>GetSecretValue</a>. 
    /// 
    ///  
    /// <para>
    /// To choose which secrets to retrieve, you can specify a list of secrets by name or
    /// ARN, or you can use filters. If Secrets Manager encounters errors such as <c>AccessDeniedException</c>
    /// while attempting to retrieve any of the secrets, you can see the errors in <c>Errors</c>
    /// in the response.
    /// </para><para>
    /// Secrets Manager generates CloudTrail <c>GetSecretValue</c> log entries for each secret
    /// you request when you call this action. Do not include sensitive information in request
    /// parameters because it might be logged. For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieve-ct-entries.html">Logging
    /// Secrets Manager events with CloudTrail</a>.
    /// </para><para><b>Required permissions: </b><c>secretsmanager:BatchGetSecretValue</c>, and you
    /// must have <c>secretsmanager:GetSecretValue</c> for each secret. If you use filters,
    /// you must also have <c>secretsmanager:ListSecrets</c>. If the secrets are encrypted
    /// using customer-managed keys instead of the Amazon Web Services managed key <c>aws/secretsmanager</c>,
    /// then you also need <c>kms:Decrypt</c> permissions for the keys. For more information,
    /// see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/reference_iam-permissions.html#reference_iam-permissions_actions">
    /// IAM policy actions for Secrets Manager</a> and <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access.html">Authentication
    /// and access control in Secrets Manager</a>. 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SECBatchSecretValue")]
    [OutputType("Amazon.SecretsManager.Model.BatchGetSecretValueResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager BatchGetSecretValue API operation.", Operation = new[] {"BatchGetSecretValue"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.BatchGetSecretValueResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.BatchGetSecretValueResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.BatchGetSecretValueResponse object containing multiple properties."
    )]
    public partial class GetSECBatchSecretValueCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters to choose which secrets to retrieve. You must include <c>Filters</c> or
        /// <c>SecretIdList</c>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SecretsManager.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SecretIdList
        /// <summary>
        /// <para>
        /// <para>The ARN or names of the secrets to retrieve. You must include <c>Filters</c> or <c>SecretIdList</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String[] SecretIdList { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The number of results to include in the response.</para><para>If there are more results available, in the response, Secrets Manager includes <c>NextToken</c>.
        /// To get the next results, call <c>BatchGetSecretValue</c> again with the value from
        /// <c>NextToken</c>. To use this parameter, you must also use the <c>Filters</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token that indicates where the output should continue from, if a previous call did
        /// not show all results. To get the next results, call <c>BatchGetSecretValue</c> again
        /// with this value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.BatchGetSecretValueResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.BatchGetSecretValueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.BatchGetSecretValueResponse, GetSECBatchSecretValueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SecretsManager.Model.Filter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SecretIdList != null)
            {
                context.SecretIdList = new List<System.String>(this.SecretIdList);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SecretsManager.Model.BatchGetSecretValueRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SecretIdList != null)
            {
                request.SecretIdList = cmdletContext.SecretIdList;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SecretsManager.Model.BatchGetSecretValueResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.BatchGetSecretValueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "BatchGetSecretValue");
            try
            {
                return client.BatchGetSecretValueAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecretsManager.Model.Filter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> SecretIdList { get; set; }
            public System.Func<Amazon.SecretsManager.Model.BatchGetSecretValueResponse, GetSECBatchSecretValueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
