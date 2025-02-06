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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Finds SageMaker resources that match a search query. Matching resources are returned
    /// as a list of <c>SearchRecord</c> objects in the response. You can sort the search
    /// results by any resource property in a ascending or descending order.
    /// 
    ///  
    /// <para>
    /// You can query against the following value types: numeric, text, Boolean, and timestamp.
    /// </para><note><para>
    /// The Search API may provide access to otherwise restricted data. See <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/api-permissions-reference.html">Amazon
    /// SageMaker API Permissions: Actions, Permissions, and Resources Reference</a> for more
    /// information.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "SMResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.SearchRecord")]
    [AWSCmdlet("Calls the Amazon SageMaker Service Search API operation.", Operation = new[] {"Search"}, SelectReturnType = typeof(Amazon.SageMaker.Model.SearchResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.SearchRecord or Amazon.SageMaker.Model.SearchResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.SearchRecord objects.",
        "The service call response (type Amazon.SageMaker.Model.SearchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchSMResourceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CrossAccountFilterOption
        /// <summary>
        /// <para>
        /// <para> A cross account filter option. When the value is <c>"CrossAccount"</c> the search
        /// results will only include resources made discoverable to you from other accounts.
        /// When the value is <c>"SameAccount"</c> or <c>null</c> the search results will only
        /// include resources from your account. Default is <c>null</c>. For more information
        /// on searching for resources made discoverable to your account, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/feature-store-cross-account-discoverability-use.html">
        /// Search discoverable resources</a> in the SageMaker Developer Guide. The maximum number
        /// of <c>ResourceCatalog</c>s viewable is 1000. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.CrossAccountFilterOption")]
        public Amazon.SageMaker.CrossAccountFilterOption CrossAccountFilterOption { get; set; }
        #endregion
        
        #region Parameter SearchExpression_Filter
        /// <summary>
        /// <para>
        /// <para>A list of filter objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_Filters")]
        public Amazon.SageMaker.Model.Filter[] SearchExpression_Filter { get; set; }
        #endregion
        
        #region Parameter SearchExpression_NestedFilter
        /// <summary>
        /// <para>
        /// <para>A list of nested filter objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_NestedFilters")]
        public Amazon.SageMaker.Model.NestedFilters[] SearchExpression_NestedFilter { get; set; }
        #endregion
        
        #region Parameter SearchExpression_Operator
        /// <summary>
        /// <para>
        /// <para>A Boolean operator used to evaluate the search expression. If you want every conditional
        /// statement in all lists to be satisfied for the entire search expression to be true,
        /// specify <c>And</c>. If only a single conditional statement needs to be true for the
        /// entire search expression to be true, specify <c>Or</c>. The default value is <c>And</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.BooleanOperator")]
        public Amazon.SageMaker.BooleanOperator SearchExpression_Operator { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The name of the SageMaker resource to search for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.ResourceType")]
        public Amazon.SageMaker.ResourceType Resource { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The name of the resource property used to sort the <c>SearchResults</c>. The default
        /// is <c>LastModifiedTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>How <c>SearchResults</c> are ordered. Valid values are <c>Ascending</c> or <c>Descending</c>.
        /// The default is <c>Descending</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SearchSortOrder")]
        public Amazon.SageMaker.SearchSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter SearchExpression_SubExpression
        /// <summary>
        /// <para>
        /// <para>A list of search expression objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchExpression_SubExpressions")]
        public Amazon.SageMaker.Model.SearchExpression[] SearchExpression_SubExpression { get; set; }
        #endregion
        
        #region Parameter VisibilityCondition
        /// <summary>
        /// <para>
        /// <para> Limits the results of your search request to the resources that you can access. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisibilityConditions")]
        public Amazon.SageMaker.Model.VisibilityConditions[] VisibilityCondition { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If more than <c>MaxResults</c> resources match the specified <c>SearchExpression</c>,
        /// the response includes a <c>NextToken</c>. The <c>NextToken</c> can be passed to the
        /// next <c>SearchRequest</c> to continue retrieving results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.SearchResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.SearchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Resource), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-SMResource (Search)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.SearchResponse, SearchSMResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CrossAccountFilterOption = this.CrossAccountFilterOption;
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '100'");
                context.MaxResult = 100;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Resource = this.Resource;
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SearchExpression_Filter != null)
            {
                context.SearchExpression_Filter = new List<Amazon.SageMaker.Model.Filter>(this.SearchExpression_Filter);
            }
            if (this.SearchExpression_NestedFilter != null)
            {
                context.SearchExpression_NestedFilter = new List<Amazon.SageMaker.Model.NestedFilters>(this.SearchExpression_NestedFilter);
            }
            context.SearchExpression_Operator = this.SearchExpression_Operator;
            if (this.SearchExpression_SubExpression != null)
            {
                context.SearchExpression_SubExpression = new List<Amazon.SageMaker.Model.SearchExpression>(this.SearchExpression_SubExpression);
            }
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            if (this.VisibilityCondition != null)
            {
                context.VisibilityCondition = new List<Amazon.SageMaker.Model.VisibilityConditions>(this.VisibilityCondition);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.SearchRequest();
            
            if (cmdletContext.CrossAccountFilterOption != null)
            {
                request.CrossAccountFilterOption = cmdletContext.CrossAccountFilterOption;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            
             // populate SearchExpression
            var requestSearchExpressionIsNull = true;
            request.SearchExpression = new Amazon.SageMaker.Model.SearchExpression();
            List<Amazon.SageMaker.Model.Filter> requestSearchExpression_searchExpression_Filter = null;
            if (cmdletContext.SearchExpression_Filter != null)
            {
                requestSearchExpression_searchExpression_Filter = cmdletContext.SearchExpression_Filter;
            }
            if (requestSearchExpression_searchExpression_Filter != null)
            {
                request.SearchExpression.Filters = requestSearchExpression_searchExpression_Filter;
                requestSearchExpressionIsNull = false;
            }
            List<Amazon.SageMaker.Model.NestedFilters> requestSearchExpression_searchExpression_NestedFilter = null;
            if (cmdletContext.SearchExpression_NestedFilter != null)
            {
                requestSearchExpression_searchExpression_NestedFilter = cmdletContext.SearchExpression_NestedFilter;
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
            if (cmdletContext.SearchExpression_SubExpression != null)
            {
                requestSearchExpression_searchExpression_SubExpression = cmdletContext.SearchExpression_SubExpression;
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
            if (cmdletContext.VisibilityCondition != null)
            {
                request.VisibilityConditions = cmdletContext.VisibilityCondition;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.SearchRequest();
            if (cmdletContext.CrossAccountFilterOption != null)
            {
                request.CrossAccountFilterOption = cmdletContext.CrossAccountFilterOption;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            
             // populate SearchExpression
            var requestSearchExpressionIsNull = true;
            request.SearchExpression = new Amazon.SageMaker.Model.SearchExpression();
            List<Amazon.SageMaker.Model.Filter> requestSearchExpression_searchExpression_Filter = null;
            if (cmdletContext.SearchExpression_Filter != null)
            {
                requestSearchExpression_searchExpression_Filter = cmdletContext.SearchExpression_Filter;
            }
            if (requestSearchExpression_searchExpression_Filter != null)
            {
                request.SearchExpression.Filters = requestSearchExpression_searchExpression_Filter;
                requestSearchExpressionIsNull = false;
            }
            List<Amazon.SageMaker.Model.NestedFilters> requestSearchExpression_searchExpression_NestedFilter = null;
            if (cmdletContext.SearchExpression_NestedFilter != null)
            {
                requestSearchExpression_searchExpression_NestedFilter = cmdletContext.SearchExpression_NestedFilter;
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
            if (cmdletContext.SearchExpression_SubExpression != null)
            {
                requestSearchExpression_searchExpression_SubExpression = cmdletContext.SearchExpression_SubExpression;
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
            if (cmdletContext.VisibilityCondition != null)
            {
                request.VisibilityConditions = cmdletContext.VisibilityCondition;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(100);
                }
                
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
                    int _receivedThisCall = response.Results?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
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
                return client.SearchAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.CrossAccountFilterOption CrossAccountFilterOption { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.ResourceType Resource { get; set; }
            public List<Amazon.SageMaker.Model.Filter> SearchExpression_Filter { get; set; }
            public List<Amazon.SageMaker.Model.NestedFilters> SearchExpression_NestedFilter { get; set; }
            public Amazon.SageMaker.BooleanOperator SearchExpression_Operator { get; set; }
            public List<Amazon.SageMaker.Model.SearchExpression> SearchExpression_SubExpression { get; set; }
            public System.String SortBy { get; set; }
            public Amazon.SageMaker.SearchSortOrder SortOrder { get; set; }
            public List<Amazon.SageMaker.Model.VisibilityConditions> VisibilityCondition { get; set; }
            public System.Func<Amazon.SageMaker.Model.SearchResponse, SearchSMResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
