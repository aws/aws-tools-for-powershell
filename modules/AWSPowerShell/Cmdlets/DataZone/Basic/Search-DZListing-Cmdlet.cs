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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Searches listings in Amazon DataZone.
    /// 
    ///  
    /// <para>
    /// SearchListings is a powerful capability that enables users to discover and explore
    /// published assets and data products across their organization. It provides both basic
    /// and advanced search functionality, allowing users to find resources based on names,
    /// descriptions, metadata, and other attributes. SearchListings also supports filtering
    /// using various criteria such as creation date, owner, or status. This API is essential
    /// for making the wealth of data resources in an organization discoverable and usable,
    /// helping users find the right data for their needs quickly and efficiently.
    /// </para><para>
    /// SearchListings returns results in a paginated format. When the result set is large,
    /// the response will include a nextToken, which can be used to retrieve the next page
    /// of results.
    /// </para><para>
    /// The SearchListings API gives users flexibility in specifying what kind of search is
    /// run.
    /// </para><para>
    /// To run a standard free-text search, the <c>searchText</c> parameter must be supplied.
    /// By default, all searchable fields are indexed for semantic search and will return
    /// semantic matches for SearchListings queries. To prevent semantic search indexing for
    /// a custom form attribute, see the <a href="https://docs.aws.amazon.com/datazone/latest/APIReference/API_CreateFormType.html">CreateFormType
    /// API documentation</a>. To run a lexical search query, enclose the query with double
    /// quotes (""). This will disable semantic search even for fields that have semantic
    /// search enabled and will only return results that contain the keywords wrapped by double
    /// quotes (order of tokens in the query is not enforced). Free-text search is supported
    /// for all attributes annotated with @amazon.datazone#searchable.
    /// </para><para>
    /// To run a filtered search, provide filter clause using the <c>filters</c> parameter.
    /// To filter on glossary terms, use the special attribute <c>__DataZoneGlossaryTerms</c>.
    /// To filter on an indexed numeric attribute (i.e., a numeric attribute annotated with
    /// <c>@amazon.datazone#sortable</c>), provide a filter using the <c>intValue</c> parameter.
    /// The filters parameter can also be used to run more advanced free-text searches that
    /// target specific attributes (attributes must be annotated with <c>@amazon.datazone#searchable</c>
    /// for free-text search). Create/update timestamp filtering is supported using the special
    /// <c>creationTime</c>/<c>lastUpdatedTime</c> attributes. Filter types can be mixed and
    /// matched to power complex queries.
    /// </para><para>
    ///  To find out whether an attribute has been annotated and indexed for a given search
    /// type, use the GetFormType API to retrieve the form containing the attribute.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "DZListing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.SearchListingsResponse")]
    [AWSCmdlet("Calls the Amazon DataZone SearchListings API operation.", Operation = new[] {"SearchListings"}, SelectReturnType = typeof(Amazon.DataZone.Model.SearchListingsResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.SearchListingsResponse",
        "This cmdlet returns an Amazon.DataZone.Model.SearchListingsResponse object containing multiple properties."
    )]
    public partial class SearchDZListingCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalAttribute
        /// <summary>
        /// <para>
        /// <para>Specifies additional attributes for the search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalAttributes")]
        public System.String[] AdditionalAttribute { get; set; }
        #endregion
        
        #region Parameter Aggregation
        /// <summary>
        /// <para>
        /// <para>Enables you to specify one or more attributes to compute and return counts grouped
        /// by field values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Aggregations")]
        public Amazon.DataZone.Model.AggregationListItem[] Aggregation { get; set; }
        #endregion
        
        #region Parameter Filters_And
        /// <summary>
        /// <para>
        /// <para>The 'and' search filter clause in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.FilterClause[] Filters_And { get; set; }
        #endregion
        
        #region Parameter Filter_Attribute
        /// <summary>
        /// <para>
        /// <para>A search filter attribute in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Filter_Attribute")]
        public System.String Filter_Attribute { get; set; }
        #endregion
        
        #region Parameter Sort_Attribute
        /// <summary>
        /// <para>
        /// <para>The attribute detail of the way to sort search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sort_Attribute { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the domain in which to search listings.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter Filters_Filter_IntValue
        /// <summary>
        /// <para>
        /// <para>A search filter integer value in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Filters_Filter_IntValue { get; set; }
        #endregion
        
        #region Parameter Filters_Filter_Operator
        /// <summary>
        /// <para>
        /// <para>Specifies the search filter operator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.FilterOperator")]
        public Amazon.DataZone.FilterOperator Filters_Filter_Operator { get; set; }
        #endregion
        
        #region Parameter Filters_Or
        /// <summary>
        /// <para>
        /// <para>The 'or' search filter clause in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.FilterClause[] Filters_Or { get; set; }
        #endregion
        
        #region Parameter Sort_Order
        /// <summary>
        /// <para>
        /// <para>The order detail of the wya to sort search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.SortOrder")]
        public Amazon.DataZone.SortOrder Sort_Order { get; set; }
        #endregion
        
        #region Parameter SearchIn
        /// <summary>
        /// <para>
        /// <para>The details of the search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.SearchInItem[] SearchIn { get; set; }
        #endregion
        
        #region Parameter SearchText
        /// <summary>
        /// <para>
        /// <para>Specifies the text for which to search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchText { get; set; }
        #endregion
        
        #region Parameter Filter_Value
        /// <summary>
        /// <para>
        /// <para>A search filter string value in Amazon DataZone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Filter_Value")]
        public System.String Filter_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call to <c>SearchListings</c>.
        /// When the number of results to be listed is greater than the value of <c>MaxResults</c>,
        /// the response contains a <c>NextToken</c> value that you can use in a subsequent call
        /// to <c>SearchListings</c> to list the next set of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When the number of results is greater than the default value for the <c>MaxResults</c>
        /// parameter, or if you explicitly specify a value for <c>MaxResults</c> that is less
        /// than the number of results, the response includes a pagination token named <c>NextToken</c>.
        /// You can specify this <c>NextToken</c> value in a subsequent call to <c>SearchListings</c>
        /// to list the next set of results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.SearchListingsResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.SearchListingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-DZListing (SearchListings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.SearchListingsResponse, SearchDZListingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalAttribute != null)
            {
                context.AdditionalAttribute = new List<System.String>(this.AdditionalAttribute);
            }
            if (this.Aggregation != null)
            {
                context.Aggregation = new List<Amazon.DataZone.Model.AggregationListItem>(this.Aggregation);
            }
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filters_And != null)
            {
                context.Filters_And = new List<Amazon.DataZone.Model.FilterClause>(this.Filters_And);
            }
            context.Filter_Attribute = this.Filter_Attribute;
            context.Filters_Filter_IntValue = this.Filters_Filter_IntValue;
            context.Filters_Filter_Operator = this.Filters_Filter_Operator;
            context.Filter_Value = this.Filter_Value;
            if (this.Filters_Or != null)
            {
                context.Filters_Or = new List<Amazon.DataZone.Model.FilterClause>(this.Filters_Or);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SearchIn != null)
            {
                context.SearchIn = new List<Amazon.DataZone.Model.SearchInItem>(this.SearchIn);
            }
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.DataZone.Model.SearchListingsRequest();
            
            if (cmdletContext.AdditionalAttribute != null)
            {
                request.AdditionalAttributes = cmdletContext.AdditionalAttribute;
            }
            if (cmdletContext.Aggregation != null)
            {
                request.Aggregations = cmdletContext.Aggregation;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DataZone.Model.FilterClause();
            List<Amazon.DataZone.Model.FilterClause> requestFilters_filters_And = null;
            if (cmdletContext.Filters_And != null)
            {
                requestFilters_filters_And = cmdletContext.Filters_And;
            }
            if (requestFilters_filters_And != null)
            {
                request.Filters.And = requestFilters_filters_And;
                requestFiltersIsNull = false;
            }
            List<Amazon.DataZone.Model.FilterClause> requestFilters_filters_Or = null;
            if (cmdletContext.Filters_Or != null)
            {
                requestFilters_filters_Or = cmdletContext.Filters_Or;
            }
            if (requestFilters_filters_Or != null)
            {
                request.Filters.Or = requestFilters_filters_Or;
                requestFiltersIsNull = false;
            }
            Amazon.DataZone.Model.Filter requestFilters_filters_Filter = null;
            
             // populate Filter
            var requestFilters_filters_FilterIsNull = true;
            requestFilters_filters_Filter = new Amazon.DataZone.Model.Filter();
            System.String requestFilters_filters_Filter_filter_Attribute = null;
            if (cmdletContext.Filter_Attribute != null)
            {
                requestFilters_filters_Filter_filter_Attribute = cmdletContext.Filter_Attribute;
            }
            if (requestFilters_filters_Filter_filter_Attribute != null)
            {
                requestFilters_filters_Filter.Attribute = requestFilters_filters_Filter_filter_Attribute;
                requestFilters_filters_FilterIsNull = false;
            }
            System.Int64? requestFilters_filters_Filter_filters_Filter_IntValue = null;
            if (cmdletContext.Filters_Filter_IntValue != null)
            {
                requestFilters_filters_Filter_filters_Filter_IntValue = cmdletContext.Filters_Filter_IntValue.Value;
            }
            if (requestFilters_filters_Filter_filters_Filter_IntValue != null)
            {
                requestFilters_filters_Filter.IntValue = requestFilters_filters_Filter_filters_Filter_IntValue.Value;
                requestFilters_filters_FilterIsNull = false;
            }
            Amazon.DataZone.FilterOperator requestFilters_filters_Filter_filters_Filter_Operator = null;
            if (cmdletContext.Filters_Filter_Operator != null)
            {
                requestFilters_filters_Filter_filters_Filter_Operator = cmdletContext.Filters_Filter_Operator;
            }
            if (requestFilters_filters_Filter_filters_Filter_Operator != null)
            {
                requestFilters_filters_Filter.Operator = requestFilters_filters_Filter_filters_Filter_Operator;
                requestFilters_filters_FilterIsNull = false;
            }
            System.String requestFilters_filters_Filter_filter_Value = null;
            if (cmdletContext.Filter_Value != null)
            {
                requestFilters_filters_Filter_filter_Value = cmdletContext.Filter_Value;
            }
            if (requestFilters_filters_Filter_filter_Value != null)
            {
                requestFilters_filters_Filter.Value = requestFilters_filters_Filter_filter_Value;
                requestFilters_filters_FilterIsNull = false;
            }
             // determine if requestFilters_filters_Filter should be set to null
            if (requestFilters_filters_FilterIsNull)
            {
                requestFilters_filters_Filter = null;
            }
            if (requestFilters_filters_Filter != null)
            {
                request.Filters.Filter = requestFilters_filters_Filter;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SearchIn != null)
            {
                request.SearchIn = cmdletContext.SearchIn;
            }
            if (cmdletContext.SearchText != null)
            {
                request.SearchText = cmdletContext.SearchText;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.DataZone.Model.SearchSort();
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
            Amazon.DataZone.SortOrder requestSort_sort_Order = null;
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
        
        private Amazon.DataZone.Model.SearchListingsResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.SearchListingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "SearchListings");
            try
            {
                #if DESKTOP
                return client.SearchListings(request);
                #elif CORECLR
                return client.SearchListingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalAttribute { get; set; }
            public List<Amazon.DataZone.Model.AggregationListItem> Aggregation { get; set; }
            public System.String DomainIdentifier { get; set; }
            public List<Amazon.DataZone.Model.FilterClause> Filters_And { get; set; }
            public System.String Filter_Attribute { get; set; }
            public System.Int64? Filters_Filter_IntValue { get; set; }
            public Amazon.DataZone.FilterOperator Filters_Filter_Operator { get; set; }
            public System.String Filter_Value { get; set; }
            public List<Amazon.DataZone.Model.FilterClause> Filters_Or { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.DataZone.Model.SearchInItem> SearchIn { get; set; }
            public System.String SearchText { get; set; }
            public System.String Sort_Attribute { get; set; }
            public Amazon.DataZone.SortOrder Sort_Order { get; set; }
            public System.Func<Amazon.DataZone.Model.SearchListingsResponse, SearchDZListingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
