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
    /// Returns a list of recommendations.
    /// </summary>
    [Cmdlet("Get", "COHRecommendationList")]
    [OutputType("Amazon.CostOptimizationHub.Model.Recommendation")]
    [AWSCmdlet("Calls the Cost Optimization Hub ListRecommendations API operation.", Operation = new[] {"ListRecommendations"}, SelectReturnType = typeof(Amazon.CostOptimizationHub.Model.ListRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.CostOptimizationHub.Model.Recommendation or Amazon.CostOptimizationHub.Model.ListRecommendationsResponse",
        "This cmdlet returns a collection of Amazon.CostOptimizationHub.Model.Recommendation objects.",
        "The service call response (type Amazon.CostOptimizationHub.Model.ListRecommendationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOHRecommendationListCmdlet : AmazonCostOptimizationHubClientCmdlet, IExecutor
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
        
        #region Parameter OrderBy_Dimension
        /// <summary>
        /// <para>
        /// <para>Sorts by dimension values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrderBy_Dimension { get; set; }
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
        
        #region Parameter IncludeAllRecommendation
        /// <summary>
        /// <para>
        /// <para>List of all recommendations for a resource, or a single recommendation if de-duped
        /// by <c>resourceId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("IncludeAllRecommendations")]
        public System.Boolean? IncludeAllRecommendation { get; set; }
        #endregion
        
        #region Parameter OrderBy_Order
        /// <summary>
        /// <para>
        /// <para>The order that's used to sort the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.Order")]
        public Amazon.CostOptimizationHub.Order OrderBy_Order { get; set; }
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
        /// <para>The maximum number of recommendations that are returned for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostOptimizationHub.Model.ListRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.CostOptimizationHub.Model.ListRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.CostOptimizationHub.Model.ListRecommendationsResponse, GetCOHRecommendationListCmdlet>(Select) ??
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
            context.IncludeAllRecommendation = this.IncludeAllRecommendation;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OrderBy_Dimension = this.OrderBy_Dimension;
            context.OrderBy_Order = this.OrderBy_Order;
            
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
            var request = new Amazon.CostOptimizationHub.Model.ListRecommendationsRequest();
            
            
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
            if (cmdletContext.IncludeAllRecommendation != null)
            {
                request.IncludeAllRecommendations = cmdletContext.IncludeAllRecommendation.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate OrderBy
            var requestOrderByIsNull = true;
            request.OrderBy = new Amazon.CostOptimizationHub.Model.OrderBy();
            System.String requestOrderBy_orderBy_Dimension = null;
            if (cmdletContext.OrderBy_Dimension != null)
            {
                requestOrderBy_orderBy_Dimension = cmdletContext.OrderBy_Dimension;
            }
            if (requestOrderBy_orderBy_Dimension != null)
            {
                request.OrderBy.Dimension = requestOrderBy_orderBy_Dimension;
                requestOrderByIsNull = false;
            }
            Amazon.CostOptimizationHub.Order requestOrderBy_orderBy_Order = null;
            if (cmdletContext.OrderBy_Order != null)
            {
                requestOrderBy_orderBy_Order = cmdletContext.OrderBy_Order;
            }
            if (requestOrderBy_orderBy_Order != null)
            {
                request.OrderBy.Order = requestOrderBy_orderBy_Order;
                requestOrderByIsNull = false;
            }
             // determine if request.OrderBy should be set to null
            if (requestOrderByIsNull)
            {
                request.OrderBy = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.CostOptimizationHub.Model.ListRecommendationsResponse CallAWSServiceOperation(IAmazonCostOptimizationHub client, Amazon.CostOptimizationHub.Model.ListRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Cost Optimization Hub", "ListRecommendations");
            try
            {
                return client.ListRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IncludeAllRecommendation { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrderBy_Dimension { get; set; }
            public Amazon.CostOptimizationHub.Order OrderBy_Order { get; set; }
            public System.Func<Amazon.CostOptimizationHub.Model.ListRecommendationsResponse, GetCOHRecommendationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
