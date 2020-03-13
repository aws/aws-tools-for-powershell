/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Returns the optimization findings for an account.
    /// 
    ///  
    /// <para>
    /// For example, it returns the number of Amazon EC2 instances in an account that are
    /// under-provisioned, over-provisioned, or optimized. It also returns the number of Auto
    /// Scaling groups in an account that are not optimized, or optimized.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CORecommendationSummary")]
    [OutputType("Amazon.ComputeOptimizer.Model.RecommendationSummary")]
    [AWSCmdlet("Calls the AWS Compute Optimizer GetRecommendationSummaries API operation.", Operation = new[] {"GetRecommendationSummaries"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.RecommendationSummary or Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse",
        "This cmdlet returns a collection of Amazon.ComputeOptimizer.Model.RecommendationSummary objects.",
        "The service call response (type Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCORecommendationSummaryCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The IDs of the AWS accounts for which to return recommendation summaries.</para><para>If your account is the master account of an organization, use this parameter to specify
        /// the member accounts for which you want to return recommendation summaries.</para><para>Only one account ID can be specified per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommendation summaries to return with a single request.</para><para>To retrieve the remaining results, make another request with the returned <code>NextToken</code>
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of recommendation summaries.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecommendationSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecommendationSummaries";
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse, GetCORecommendationSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.ComputeOptimizer.Model.GetRecommendationSummariesRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.GetRecommendationSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "GetRecommendationSummaries");
            try
            {
                #if DESKTOP
                return client.GetRecommendationSummaries(request);
                #elif CORECLR
                return client.GetRecommendationSummariesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.GetRecommendationSummariesResponse, GetCORecommendationSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecommendationSummaries;
        }
        
    }
}
