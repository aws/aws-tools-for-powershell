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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Finds Amazon SageMaker resources that match a search query. Matching resource objects
    /// are returned as a list of <code>SearchResult</code> objects in the response. The search
    /// results can be sorted by any resrouce property in a ascending or descending order.
    /// 
    ///  
    /// <para>
    /// You can query against the following value types: numerical, text, Booleans, and timestamps.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Search", "SMResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.SearchRecord")]
    [AWSCmdlet("Calls the Amazon SageMaker Service Search API operation.", Operation = new[] {"Search"})]
    [AWSCmdletOutput("Amazon.SageMaker.Model.SearchRecord",
        "This cmdlet returns a collection of SearchRecord objects.",
        "The service call response (type Amazon.SageMaker.Model.SearchResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class SearchSMResourceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter SearchExpression_Filter
        /// <summary>
        /// <para>
        /// <para>A list of filter objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SearchExpression_Filters")]
        public Amazon.SageMaker.Model.Filter[] SearchExpression_Filter { get; set; }
        #endregion
        
        #region Parameter SearchExpression_NestedFilter
        /// <summary>
        /// <para>
        /// <para>A list of nested filter objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SearchExpression_NestedFilters")]
        public Amazon.SageMaker.Model.NestedFilters[] SearchExpression_NestedFilter { get; set; }
        #endregion
        
        #region Parameter SearchExpression_Operator
        /// <summary>
        /// <para>
        /// <para>A Boolean operator used to evaluate the search expression. If you want every conditional
        /// statement in all lists to be satisfied for the entire search expression to be true,
        /// specify <code>And</code>. If only a single conditional statement needs to be true
        /// for the entire search expression to be true, specify <code>Or</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.BooleanOperator")]
        public Amazon.SageMaker.BooleanOperator SearchExpression_Operator { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon SageMaker resource to search for. Currently, the only valid
        /// <code>Resource</code> value is <code>TrainingJob</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ResourceType")]
        public Amazon.SageMaker.ResourceType Resource { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The name of the resource property used to sort the <code>SearchResults</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>How <code>SearchResults</code> are ordered. Valid values are <code>Ascending</code>
        /// or <code>Descending</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SageMaker.SearchSortOrder")]
        public Amazon.SageMaker.SearchSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter SearchExpression_SubExpression
        /// <summary>
        /// <para>
        /// <para>A list of search expression objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SearchExpression_SubExpressions")]
        public Amazon.SageMaker.Model.SearchExpression[] SearchExpression_SubExpression { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a <code>SearchResponse</code>.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If more than <code>MaxResults</code> resource objects match the specified <code>SearchExpression</code>,
        /// the <code>SearchResponse</code> includes a <code>NextToken</code>. The <code>NextToken</code>
        /// can be passed to the next <code>SearchRequest</code> to continue retrieving results
        /// for the specified <code>SearchExpression</code> and <code>Sort</code> parameters.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Resource", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-SMResource (Search)"))
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
            
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Resource = this.Resource;
            if (this.SearchExpression_Filter != null)
            {
                context.SearchExpression_Filters = new List<Amazon.SageMaker.Model.Filter>(this.SearchExpression_Filter);
            }
            if (this.SearchExpression_NestedFilter != null)
            {
                context.SearchExpression_NestedFilters = new List<Amazon.SageMaker.Model.NestedFilters>(this.SearchExpression_NestedFilter);
            }
            context.SearchExpression_Operator = this.SearchExpression_Operator;
            if (this.SearchExpression_SubExpression != null)
            {
                context.SearchExpression_SubExpressions = new List<Amazon.SageMaker.Model.SearchExpression>(this.SearchExpression_SubExpression);
            }
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.SearchRequest();
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            
             // populate SearchExpression
            bool requestSearchExpressionIsNull = true;
            request.SearchExpression = new Amazon.SageMaker.Model.SearchExpression();
            List<Amazon.SageMaker.Model.Filter> requestSearchExpression_searchExpression_Filter = null;
            if (cmdletContext.SearchExpression_Filters != null)
            {
                requestSearchExpression_searchExpression_Filter = cmdletContext.SearchExpression_Filters;
            }
            if (requestSearchExpression_searchExpression_Filter != null)
            {
                request.SearchExpression.Filters = requestSearchExpression_searchExpression_Filter;
                requestSearchExpressionIsNull = false;
            }
            List<Amazon.SageMaker.Model.NestedFilters> requestSearchExpression_searchExpression_NestedFilter = null;
            if (cmdletContext.SearchExpression_NestedFilters != null)
            {
                requestSearchExpression_searchExpression_NestedFilter = cmdletContext.SearchExpression_NestedFilters;
            }
            if (requestSearchExpression_searchExpression_NestedFilter != null)
            {
                request.SearchExpression.NestedFilters = requestSearchExpression_searchExpression_NestedFilter;
                requestSearchExpressionIsNull = false;
            }
            Amazon.SageMaker.BooleanOperator requestSearchExpression_searchExpression_Operator = null;
            if (cmdletContext.SearchExpression_Operator != null)
            {
                requestSearchExpression_searchExpression_Operator = cmdletContext.SearchExpression_Operator;
            }
            if (requestSearchExpression_searchExpression_Operator != null)
            {
                request.SearchExpression.Operator = requestSearchExpression_searchExpression_Operator;
                requestSearchExpressionIsNull = false;
            }
            List<Amazon.SageMaker.Model.SearchExpression> requestSearchExpression_searchExpression_SubExpression = null;
            if (cmdletContext.SearchExpression_SubExpressions != null)
            {
                requestSearchExpression_searchExpression_SubExpression = cmdletContext.SearchExpression_SubExpressions;
            }
            if (requestSearchExpression_searchExpression_SubExpression != null)
            {
                request.SearchExpression.SubExpressions = requestSearchExpression_searchExpression_SubExpression;
                requestSearchExpressionIsNull = false;
            }
             // determine if request.SearchExpression should be set to null
            if (requestSearchExpressionIsNull)
            {
                request.SearchExpression = null;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 100;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxResults))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxResults);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Results;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Results.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    // The service has a maximum page size of 100 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SageMaker.Model.SearchResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.SearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "Search");
            try
            {
                #if DESKTOP
                return client.Search(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SearchAsync(request);
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
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.ResourceType Resource { get; set; }
            public List<Amazon.SageMaker.Model.Filter> SearchExpression_Filters { get; set; }
            public List<Amazon.SageMaker.Model.NestedFilters> SearchExpression_NestedFilters { get; set; }
            public Amazon.SageMaker.BooleanOperator SearchExpression_Operator { get; set; }
            public List<Amazon.SageMaker.Model.SearchExpression> SearchExpression_SubExpressions { get; set; }
            public System.String SortBy { get; set; }
            public Amazon.SageMaker.SearchSortOrder SortOrder { get; set; }
        }
        
    }
}
