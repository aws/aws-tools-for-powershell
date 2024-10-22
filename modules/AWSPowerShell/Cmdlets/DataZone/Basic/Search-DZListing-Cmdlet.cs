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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Searches listings (records of an asset at a given time) in Amazon DataZone.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "DZListing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.SearchListingsResponse")]
    [AWSCmdlet("Calls the Amazon DataZone SearchListings API operation.", Operation = new[] {"SearchListings"}, SelectReturnType = typeof(Amazon.DataZone.Model.SearchListingsResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.SearchListingsResponse",
        "This cmdlet returns an Amazon.DataZone.Model.SearchListingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchDZListingCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
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
        /// <para>A search filter value in Amazon DataZone.</para>
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.SearchListingsResponse, SearchDZListingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalAttribute != null)
            {
                context.AdditionalAttribute = new List<System.String>(this.AdditionalAttribute);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.DataZone.Model.SearchListingsRequest();
            
            if (cmdletContext.AdditionalAttribute != null)
            {
                request.AdditionalAttributes = cmdletContext.AdditionalAttribute;
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
            public System.String DomainIdentifier { get; set; }
            public List<Amazon.DataZone.Model.FilterClause> Filters_And { get; set; }
            public System.String Filter_Attribute { get; set; }
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
