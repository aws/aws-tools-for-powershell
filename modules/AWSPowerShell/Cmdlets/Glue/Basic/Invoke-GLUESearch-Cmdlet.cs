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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Searches for assets in Glue Data Catalog using full-text search, filters, sorting,
    /// and aggregations. Returns matching assets with relevance-ranked results.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Invoke", "GLUESearch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.SearchResultItem")]
    [AWSCmdlet("Calls the AWS Glue Search API operation.", Operation = new[] {"Search"}, SelectReturnType = typeof(Amazon.Glue.Model.SearchResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.SearchResultItem or Amazon.Glue.Model.SearchResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.SearchResultItem objects.",
        "The service call response (type Amazon.Glue.Model.SearchResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeGLUESearchCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterClause_AndAllFilter
        /// <summary>
        /// <para>
        /// <para>A list of filter clauses that must all match (logical AND).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterClause_AndAllFilters")]
        public Amazon.Glue.Model.SearchFilterClause[] FilterClause_AndAllFilter { get; set; }
        #endregion
        
        #region Parameter FilterClause_AttributeFilter_Attribute
        /// <summary>
        /// <para>
        /// <para>The attribute name to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterClause_AttributeFilter_Attribute { get; set; }
        #endregion
        
        #region Parameter FilterClause_MapFilter_Attribute
        /// <summary>
        /// <para>
        /// <para>The map attribute name to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterClause_MapFilter_Attribute { get; set; }
        #endregion
        
        #region Parameter Sort_Attribute
        /// <summary>
        /// <para>
        /// <para>The attribute to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sort_Attribute { get; set; }
        #endregion
        
        #region Parameter FilterClause_MapFilter_Key
        /// <summary>
        /// <para>
        /// <para>The key within the map attribute to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterClause_MapFilter_Key { get; set; }
        #endregion
        
        #region Parameter FilterClause_AttributeFilter_Value_LongValue
        /// <summary>
        /// <para>
        /// <para>A long integer filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? FilterClause_AttributeFilter_Value_LongValue { get; set; }
        #endregion
        
        #region Parameter FilterClause_AttributeFilter_Operator
        /// <summary>
        /// <para>
        /// <para>The comparison operator. Valid values are <c>equals</c>, <c>greaterThan</c>, <c>greaterThanOrEquals</c>,
        /// <c>lessThan</c>, <c>lessThanOrEquals</c>, and <c>notExists</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SearchFilterOperator")]
        public Amazon.Glue.SearchFilterOperator FilterClause_AttributeFilter_Operator { get; set; }
        #endregion
        
        #region Parameter FilterClause_OrAnyFilter
        /// <summary>
        /// <para>
        /// <para>A list of filter clauses where at least one must match (logical OR).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterClause_OrAnyFilters")]
        public Amazon.Glue.Model.SearchFilterClause[] FilterClause_OrAnyFilter { get; set; }
        #endregion
        
        #region Parameter Sort_Order
        /// <summary>
        /// <para>
        /// <para>The sort order. Valid values are <c>ASCENDING</c> and <c>DESCENDING</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SearchSortOrder")]
        public Amazon.Glue.SearchSortOrder Sort_Order { get; set; }
        #endregion
        
        #region Parameter SearchText
        /// <summary>
        /// <para>
        /// <para>The text to search for. At least one of <c>searchText</c> or <c>filterClause</c> must
        /// be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SearchText { get; set; }
        #endregion
        
        #region Parameter FilterClause_AttributeFilter_Value_StringValue
        /// <summary>
        /// <para>
        /// <para>A string filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterClause_AttributeFilter_Value_StringValue { get; set; }
        #endregion
        
        #region Parameter FilterClause_MapFilter_Value_StringValue
        /// <summary>
        /// <para>
        /// <para>A string filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterClause_MapFilter_Value_StringValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response.</para>
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
        /// <para>A continuation token, if this is a continuation call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.SearchResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.SearchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SearchText), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-GLUESearch (Search)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.SearchResponse, InvokeGLUESearchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterClause_AndAllFilter != null)
            {
                context.FilterClause_AndAllFilter = new List<Amazon.Glue.Model.SearchFilterClause>(this.FilterClause_AndAllFilter);
            }
            context.FilterClause_AttributeFilter_Attribute = this.FilterClause_AttributeFilter_Attribute;
            context.FilterClause_AttributeFilter_Operator = this.FilterClause_AttributeFilter_Operator;
            context.FilterClause_AttributeFilter_Value_LongValue = this.FilterClause_AttributeFilter_Value_LongValue;
            context.FilterClause_AttributeFilter_Value_StringValue = this.FilterClause_AttributeFilter_Value_StringValue;
            context.FilterClause_MapFilter_Attribute = this.FilterClause_MapFilter_Attribute;
            context.FilterClause_MapFilter_Key = this.FilterClause_MapFilter_Key;
            context.FilterClause_MapFilter_Value_StringValue = this.FilterClause_MapFilter_Value_StringValue;
            if (this.FilterClause_OrAnyFilter != null)
            {
                context.FilterClause_OrAnyFilter = new List<Amazon.Glue.Model.SearchFilterClause>(this.FilterClause_OrAnyFilter);
            }
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
            context.NextToken = this.NextToken;
            context.SearchText = this.SearchText;
            context.Sort_Attribute = this.Sort_Attribute;
            context.Sort_Order = this.Sort_Order;
            
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
            var request = new Amazon.Glue.Model.SearchRequest();
            
            
             // populate FilterClause
            var requestFilterClauseIsNull = true;
            request.FilterClause = new Amazon.Glue.Model.SearchFilterClause();
            List<Amazon.Glue.Model.SearchFilterClause> requestFilterClause_filterClause_AndAllFilter = null;
            if (cmdletContext.FilterClause_AndAllFilter != null)
            {
                requestFilterClause_filterClause_AndAllFilter = cmdletContext.FilterClause_AndAllFilter;
            }
            if (requestFilterClause_filterClause_AndAllFilter != null)
            {
                request.FilterClause.AndAllFilters = requestFilterClause_filterClause_AndAllFilter;
                requestFilterClauseIsNull = false;
            }
            List<Amazon.Glue.Model.SearchFilterClause> requestFilterClause_filterClause_OrAnyFilter = null;
            if (cmdletContext.FilterClause_OrAnyFilter != null)
            {
                requestFilterClause_filterClause_OrAnyFilter = cmdletContext.FilterClause_OrAnyFilter;
            }
            if (requestFilterClause_filterClause_OrAnyFilter != null)
            {
                request.FilterClause.OrAnyFilters = requestFilterClause_filterClause_OrAnyFilter;
                requestFilterClauseIsNull = false;
            }
            Amazon.Glue.Model.SearchAttributeFilter requestFilterClause_filterClause_AttributeFilter = null;
            
             // populate AttributeFilter
            var requestFilterClause_filterClause_AttributeFilterIsNull = true;
            requestFilterClause_filterClause_AttributeFilter = new Amazon.Glue.Model.SearchAttributeFilter();
            System.String requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Attribute = null;
            if (cmdletContext.FilterClause_AttributeFilter_Attribute != null)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Attribute = cmdletContext.FilterClause_AttributeFilter_Attribute;
            }
            if (requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Attribute != null)
            {
                requestFilterClause_filterClause_AttributeFilter.Attribute = requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Attribute;
                requestFilterClause_filterClause_AttributeFilterIsNull = false;
            }
            Amazon.Glue.SearchFilterOperator requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Operator = null;
            if (cmdletContext.FilterClause_AttributeFilter_Operator != null)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Operator = cmdletContext.FilterClause_AttributeFilter_Operator;
            }
            if (requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Operator != null)
            {
                requestFilterClause_filterClause_AttributeFilter.Operator = requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Operator;
                requestFilterClause_filterClause_AttributeFilterIsNull = false;
            }
            Amazon.Glue.Model.SearchFilterValue requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value = null;
            
             // populate Value
            var requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_ValueIsNull = true;
            requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value = new Amazon.Glue.Model.SearchFilterValue();
            System.Int64? requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_LongValue = null;
            if (cmdletContext.FilterClause_AttributeFilter_Value_LongValue != null)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_LongValue = cmdletContext.FilterClause_AttributeFilter_Value_LongValue.Value;
            }
            if (requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_LongValue != null)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value.LongValue = requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_LongValue.Value;
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_ValueIsNull = false;
            }
            System.String requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_StringValue = null;
            if (cmdletContext.FilterClause_AttributeFilter_Value_StringValue != null)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_StringValue = cmdletContext.FilterClause_AttributeFilter_Value_StringValue;
            }
            if (requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_StringValue != null)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value.StringValue = requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value_filterClause_AttributeFilter_Value_StringValue;
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_ValueIsNull = false;
            }
             // determine if requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value should be set to null
            if (requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_ValueIsNull)
            {
                requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value = null;
            }
            if (requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value != null)
            {
                requestFilterClause_filterClause_AttributeFilter.Value = requestFilterClause_filterClause_AttributeFilter_filterClause_AttributeFilter_Value;
                requestFilterClause_filterClause_AttributeFilterIsNull = false;
            }
             // determine if requestFilterClause_filterClause_AttributeFilter should be set to null
            if (requestFilterClause_filterClause_AttributeFilterIsNull)
            {
                requestFilterClause_filterClause_AttributeFilter = null;
            }
            if (requestFilterClause_filterClause_AttributeFilter != null)
            {
                request.FilterClause.AttributeFilter = requestFilterClause_filterClause_AttributeFilter;
                requestFilterClauseIsNull = false;
            }
            Amazon.Glue.Model.SearchMapFilter requestFilterClause_filterClause_MapFilter = null;
            
             // populate MapFilter
            var requestFilterClause_filterClause_MapFilterIsNull = true;
            requestFilterClause_filterClause_MapFilter = new Amazon.Glue.Model.SearchMapFilter();
            System.String requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Attribute = null;
            if (cmdletContext.FilterClause_MapFilter_Attribute != null)
            {
                requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Attribute = cmdletContext.FilterClause_MapFilter_Attribute;
            }
            if (requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Attribute != null)
            {
                requestFilterClause_filterClause_MapFilter.Attribute = requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Attribute;
                requestFilterClause_filterClause_MapFilterIsNull = false;
            }
            System.String requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Key = null;
            if (cmdletContext.FilterClause_MapFilter_Key != null)
            {
                requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Key = cmdletContext.FilterClause_MapFilter_Key;
            }
            if (requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Key != null)
            {
                requestFilterClause_filterClause_MapFilter.Key = requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Key;
                requestFilterClause_filterClause_MapFilterIsNull = false;
            }
            Amazon.Glue.Model.SearchMapFilterValue requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value = null;
            
             // populate Value
            var requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_ValueIsNull = true;
            requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value = new Amazon.Glue.Model.SearchMapFilterValue();
            System.String requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value_filterClause_MapFilter_Value_StringValue = null;
            if (cmdletContext.FilterClause_MapFilter_Value_StringValue != null)
            {
                requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value_filterClause_MapFilter_Value_StringValue = cmdletContext.FilterClause_MapFilter_Value_StringValue;
            }
            if (requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value_filterClause_MapFilter_Value_StringValue != null)
            {
                requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value.StringValue = requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value_filterClause_MapFilter_Value_StringValue;
                requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_ValueIsNull = false;
            }
             // determine if requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value should be set to null
            if (requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_ValueIsNull)
            {
                requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value = null;
            }
            if (requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value != null)
            {
                requestFilterClause_filterClause_MapFilter.Value = requestFilterClause_filterClause_MapFilter_filterClause_MapFilter_Value;
                requestFilterClause_filterClause_MapFilterIsNull = false;
            }
             // determine if requestFilterClause_filterClause_MapFilter should be set to null
            if (requestFilterClause_filterClause_MapFilterIsNull)
            {
                requestFilterClause_filterClause_MapFilter = null;
            }
            if (requestFilterClause_filterClause_MapFilter != null)
            {
                request.FilterClause.MapFilter = requestFilterClause_filterClause_MapFilter;
                requestFilterClauseIsNull = false;
            }
             // determine if request.FilterClause should be set to null
            if (requestFilterClauseIsNull)
            {
                request.FilterClause = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.SearchText != null)
            {
                request.SearchText = cmdletContext.SearchText;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.Glue.Model.SearchSort();
            System.String requestSort_sort_Attribute = null;
            if (cmdletContext.Sort_Attribute != null)
            {
                requestSort_sort_Attribute = cmdletContext.Sort_Attribute;
            }
            if (requestSort_sort_Attribute != null)
            {
                request.Sort.Attribute = requestSort_sort_Attribute;
                requestSortIsNull = false;
            }
            Amazon.Glue.SearchSortOrder requestSort_sort_Order = null;
            if (cmdletContext.Sort_Order != null)
            {
                requestSort_sort_Order = cmdletContext.Sort_Order;
            }
            if (requestSort_sort_Order != null)
            {
                request.Sort.Order = requestSort_sort_Order;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
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
        
        private Amazon.Glue.Model.SearchResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.SearchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "Search");
            try
            {
                return client.SearchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Glue.Model.SearchFilterClause> FilterClause_AndAllFilter { get; set; }
            public System.String FilterClause_AttributeFilter_Attribute { get; set; }
            public Amazon.Glue.SearchFilterOperator FilterClause_AttributeFilter_Operator { get; set; }
            public System.Int64? FilterClause_AttributeFilter_Value_LongValue { get; set; }
            public System.String FilterClause_AttributeFilter_Value_StringValue { get; set; }
            public System.String FilterClause_MapFilter_Attribute { get; set; }
            public System.String FilterClause_MapFilter_Key { get; set; }
            public System.String FilterClause_MapFilter_Value_StringValue { get; set; }
            public List<Amazon.Glue.Model.SearchFilterClause> FilterClause_OrAnyFilter { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String SearchText { get; set; }
            public System.String Sort_Attribute { get; set; }
            public Amazon.Glue.SearchSortOrder Sort_Order { get; set; }
            public System.Func<Amazon.Glue.Model.SearchResponse, InvokeGLUESearchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
