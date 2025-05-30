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
using Amazon.CostOptimizationHub;
using Amazon.CostOptimizationHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.COH
{
    /// <summary>
    /// Returns a concise representation of savings estimates for resources. Also returns
    /// de-duped savings across different types of recommendations.
    /// 
    ///  <note><para>
    /// The following filters are not supported for this API: <c>recommendationIds</c>, <c>resourceArns</c>,
    /// and <c>resourceIds</c>.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "COHRecommendationSummaryList")]
    [OutputType("Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse")]
    [AWSCmdlet("Calls the Cost Optimization Hub ListRecommendationSummaries API operation.", Operation = new[] {"ListRecommendationSummaries"}, SelectReturnType = typeof(Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse))]
    [AWSCmdletOutput("Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse",
        "This cmdlet returns an Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse object containing multiple properties."
    )]
    public partial class GetCOHRecommendationSummaryListCmdlet : AmazonCostOptimizationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter_AccountId
        /// <summary>
        /// <para>
        /// <para>The account to which the recommendation applies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_AccountIds")]
        public System.String[] Filter_AccountId { get; set; }
        #endregion
        
        #region Parameter Filter_ActionType
        /// <summary>
        /// <para>
        /// <para>The type of action you can take by adopting the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ActionTypes")]
        public System.String[] Filter_ActionType { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The grouping of recommendations by a dimension.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String GroupBy { get; set; }
        #endregion
        
        #region Parameter Filter_ImplementationEffort
        /// <summary>
        /// <para>
        /// <para>The effort required to implement the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ImplementationEfforts")]
        public System.String[] Filter_ImplementationEffort { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>Additional metrics to be returned for the request. The only valid value is <c>savingsPercentage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public System.String[] Metric { get; set; }
        #endregion
        
        #region Parameter Filter_RecommendationId
        /// <summary>
        /// <para>
        /// <para>The IDs for the recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_RecommendationIds")]
        public System.String[] Filter_RecommendationId { get; set; }
        #endregion
        
        #region Parameter Filter_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Regions")]
        public System.String[] Filter_Region { get; set; }
        #endregion
        
        #region Parameter Filter_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ResourceArns")]
        public System.String[] Filter_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Filter_ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource ID of the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ResourceIds")]
        public System.String[] Filter_ResourceId { get; set; }
        #endregion
        
        #region Parameter Filter_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type of the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ResourceTypes")]
        public System.String[] Filter_ResourceType { get; set; }
        #endregion
        
        #region Parameter Filter_RestartNeeded
        /// <summary>
        /// <para>
        /// <para>Whether or not implementing the recommendation requires a restart.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Filter_RestartNeeded { get; set; }
        #endregion
        
        #region Parameter Filter_RollbackPossible
        /// <summary>
        /// <para>
        /// <para>Whether or not implementing the recommendation can be rolled back.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Filter_RollbackPossible { get; set; }
        #endregion
        
        #region Parameter Filter_Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags assigned to the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Tags")]
        public Amazon.CostOptimizationHub.Model.Tag[] Filter_Tag { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of recommendations to be returned for the request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse).
        /// Specifying the name of a property of type Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse will result in that property being returned.
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
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse, GetCOHRecommendationSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_AccountId != null)
            {
                context.Filter_AccountId = new List<System.String>(this.Filter_AccountId);
            }
            if (this.Filter_ActionType != null)
            {
                context.Filter_ActionType = new List<System.String>(this.Filter_ActionType);
            }
            if (this.Filter_ImplementationEffort != null)
            {
                context.Filter_ImplementationEffort = new List<System.String>(this.Filter_ImplementationEffort);
            }
            if (this.Filter_RecommendationId != null)
            {
                context.Filter_RecommendationId = new List<System.String>(this.Filter_RecommendationId);
            }
            if (this.Filter_Region != null)
            {
                context.Filter_Region = new List<System.String>(this.Filter_Region);
            }
            if (this.Filter_ResourceArn != null)
            {
                context.Filter_ResourceArn = new List<System.String>(this.Filter_ResourceArn);
            }
            if (this.Filter_ResourceId != null)
            {
                context.Filter_ResourceId = new List<System.String>(this.Filter_ResourceId);
            }
            if (this.Filter_ResourceType != null)
            {
                context.Filter_ResourceType = new List<System.String>(this.Filter_ResourceType);
            }
            context.Filter_RestartNeeded = this.Filter_RestartNeeded;
            context.Filter_RollbackPossible = this.Filter_RollbackPossible;
            if (this.Filter_Tag != null)
            {
                context.Filter_Tag = new List<Amazon.CostOptimizationHub.Model.Tag>(this.Filter_Tag);
            }
            context.GroupBy = this.GroupBy;
            #if MODULAR
            if (this.GroupBy == null && ParameterWasBound(nameof(this.GroupBy)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupBy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            if (this.Metric != null)
            {
                context.Metric = new List<System.String>(this.Metric);
            }
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
            var request = new Amazon.CostOptimizationHub.Model.ListRecommendationSummariesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.CostOptimizationHub.Model.Filter();
            List<System.String> requestFilter_filter_AccountId = null;
            if (cmdletContext.Filter_AccountId != null)
            {
                requestFilter_filter_AccountId = cmdletContext.Filter_AccountId;
            }
            if (requestFilter_filter_AccountId != null)
            {
                request.Filter.AccountIds = requestFilter_filter_AccountId;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ActionType = null;
            if (cmdletContext.Filter_ActionType != null)
            {
                requestFilter_filter_ActionType = cmdletContext.Filter_ActionType;
            }
            if (requestFilter_filter_ActionType != null)
            {
                request.Filter.ActionTypes = requestFilter_filter_ActionType;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ImplementationEffort = null;
            if (cmdletContext.Filter_ImplementationEffort != null)
            {
                requestFilter_filter_ImplementationEffort = cmdletContext.Filter_ImplementationEffort;
            }
            if (requestFilter_filter_ImplementationEffort != null)
            {
                request.Filter.ImplementationEfforts = requestFilter_filter_ImplementationEffort;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RecommendationId = null;
            if (cmdletContext.Filter_RecommendationId != null)
            {
                requestFilter_filter_RecommendationId = cmdletContext.Filter_RecommendationId;
            }
            if (requestFilter_filter_RecommendationId != null)
            {
                request.Filter.RecommendationIds = requestFilter_filter_RecommendationId;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Region = null;
            if (cmdletContext.Filter_Region != null)
            {
                requestFilter_filter_Region = cmdletContext.Filter_Region;
            }
            if (requestFilter_filter_Region != null)
            {
                request.Filter.Regions = requestFilter_filter_Region;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ResourceArn = null;
            if (cmdletContext.Filter_ResourceArn != null)
            {
                requestFilter_filter_ResourceArn = cmdletContext.Filter_ResourceArn;
            }
            if (requestFilter_filter_ResourceArn != null)
            {
                request.Filter.ResourceArns = requestFilter_filter_ResourceArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ResourceId = null;
            if (cmdletContext.Filter_ResourceId != null)
            {
                requestFilter_filter_ResourceId = cmdletContext.Filter_ResourceId;
            }
            if (requestFilter_filter_ResourceId != null)
            {
                request.Filter.ResourceIds = requestFilter_filter_ResourceId;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ResourceType = null;
            if (cmdletContext.Filter_ResourceType != null)
            {
                requestFilter_filter_ResourceType = cmdletContext.Filter_ResourceType;
            }
            if (requestFilter_filter_ResourceType != null)
            {
                request.Filter.ResourceTypes = requestFilter_filter_ResourceType;
                requestFilterIsNull = false;
            }
            System.Boolean? requestFilter_filter_RestartNeeded = null;
            if (cmdletContext.Filter_RestartNeeded != null)
            {
                requestFilter_filter_RestartNeeded = cmdletContext.Filter_RestartNeeded.Value;
            }
            if (requestFilter_filter_RestartNeeded != null)
            {
                request.Filter.RestartNeeded = requestFilter_filter_RestartNeeded.Value;
                requestFilterIsNull = false;
            }
            System.Boolean? requestFilter_filter_RollbackPossible = null;
            if (cmdletContext.Filter_RollbackPossible != null)
            {
                requestFilter_filter_RollbackPossible = cmdletContext.Filter_RollbackPossible.Value;
            }
            if (requestFilter_filter_RollbackPossible != null)
            {
                request.Filter.RollbackPossible = requestFilter_filter_RollbackPossible.Value;
                requestFilterIsNull = false;
            }
            List<Amazon.CostOptimizationHub.Model.Tag> requestFilter_filter_Tag = null;
            if (cmdletContext.Filter_Tag != null)
            {
                requestFilter_filter_Tag = cmdletContext.Filter_Tag;
            }
            if (requestFilter_filter_Tag != null)
            {
                request.Filter.Tags = requestFilter_filter_Tag;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse CallAWSServiceOperation(IAmazonCostOptimizationHub client, Amazon.CostOptimizationHub.Model.ListRecommendationSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Cost Optimization Hub", "ListRecommendationSummaries");
            try
            {
                return client.ListRecommendationSummariesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filter_AccountId { get; set; }
            public List<System.String> Filter_ActionType { get; set; }
            public List<System.String> Filter_ImplementationEffort { get; set; }
            public List<System.String> Filter_RecommendationId { get; set; }
            public List<System.String> Filter_Region { get; set; }
            public List<System.String> Filter_ResourceArn { get; set; }
            public List<System.String> Filter_ResourceId { get; set; }
            public List<System.String> Filter_ResourceType { get; set; }
            public System.Boolean? Filter_RestartNeeded { get; set; }
            public System.Boolean? Filter_RollbackPossible { get; set; }
            public List<Amazon.CostOptimizationHub.Model.Tag> Filter_Tag { get; set; }
            public System.String GroupBy { get; set; }
            public int? MaxResult { get; set; }
            public List<System.String> Metric { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CostOptimizationHub.Model.ListRecommendationSummariesResponse, GetCOHRecommendationSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
