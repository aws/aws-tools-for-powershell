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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Searches metadata and the content of folders, documents, document versions, and comments.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "WDResource")]
    [OutputType("Amazon.WorkDocs.Model.ResponseItem")]
    [AWSCmdlet("Calls the Amazon WorkDocs SearchResources API operation.", Operation = new[] {"SearchResources"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.SearchResourcesResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.ResponseItem or Amazon.WorkDocs.Model.SearchResourcesResponse",
        "This cmdlet returns a collection of Amazon.WorkDocs.Model.ResponseItem objects.",
        "The service call response (type Amazon.WorkDocs.Model.SearchResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchWDResourceCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalResponseField
        /// <summary>
        /// <para>
        /// <para>A list of attributes to include in the response. Used to request fields that are not
        /// normally returned in a standard response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalResponseFields")]
        public System.String[] AdditionalResponseField { get; set; }
        #endregion
        
        #region Parameter Filters_AncestorId
        /// <summary>
        /// <para>
        /// <para>Filter based on resource’s path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_AncestorIds")]
        public System.String[] Filters_AncestorId { get; set; }
        #endregion
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Not required when using Amazon Web Services
        /// administrator credentials to access the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter Filters_ContentCategory
        /// <summary>
        /// <para>
        /// <para>Filters by content category.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ContentCategories")]
        public System.String[] Filters_ContentCategory { get; set; }
        #endregion
        
        #region Parameter CreatedRange_EndValue
        /// <summary>
        /// <para>
        /// <para>Timestamp range end value (in epochs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_CreatedRange_EndValue")]
        public System.DateTime? CreatedRange_EndValue { get; set; }
        #endregion
        
        #region Parameter ModifiedRange_EndValue
        /// <summary>
        /// <para>
        /// <para>Timestamp range end value (in epochs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ModifiedRange_EndValue")]
        public System.DateTime? ModifiedRange_EndValue { get; set; }
        #endregion
        
        #region Parameter SizeRange_EndValue
        /// <summary>
        /// <para>
        /// <para>The size end range (in bytes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_SizeRange_EndValue")]
        public System.Int64? SizeRange_EndValue { get; set; }
        #endregion
        
        #region Parameter Filters_Label
        /// <summary>
        /// <para>
        /// <para>Filter by labels using exact match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Labels")]
        public System.String[] Filters_Label { get; set; }
        #endregion
        
        #region Parameter OrderBy
        /// <summary>
        /// <para>
        /// <para>Order by results in one or more categories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WorkDocs.Model.SearchSortResult[] OrderBy { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>Filters based on the resource owner OrgId. This is a mandatory parameter when using
        /// Admin SigV4 credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Filters_Principal
        /// <summary>
        /// <para>
        /// <para>Filter based on UserIds or GroupIds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Principals")]
        public Amazon.WorkDocs.Model.SearchPrincipalType[] Filters_Principal { get; set; }
        #endregion
        
        #region Parameter QueryScope
        /// <summary>
        /// <para>
        /// <para>Filter based on the text field type. A Folder has only a name and no content. A Comment
        /// has only content and no name. A Document or Document Version has a name and content</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryScopes")]
        public System.String[] QueryScope { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The String to search for. Searches across different text fields based on request parameters.
        /// Use double quotes around the query string for exact phrase matches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceType
        /// <summary>
        /// <para>
        /// <para>Filters based on entity type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ResourceTypes")]
        public System.String[] Filters_ResourceType { get; set; }
        #endregion
        
        #region Parameter Filters_SearchCollectionType
        /// <summary>
        /// <para>
        /// <para>Filter based on file groupings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_SearchCollectionTypes")]
        public System.String[] Filters_SearchCollectionType { get; set; }
        #endregion
        
        #region Parameter CreatedRange_StartValue
        /// <summary>
        /// <para>
        /// <para>Timestamp range start value (in epochs)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_CreatedRange_StartValue")]
        public System.DateTime? CreatedRange_StartValue { get; set; }
        #endregion
        
        #region Parameter ModifiedRange_StartValue
        /// <summary>
        /// <para>
        /// <para>Timestamp range start value (in epochs)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ModifiedRange_StartValue")]
        public System.DateTime? ModifiedRange_StartValue { get; set; }
        #endregion
        
        #region Parameter SizeRange_StartValue
        /// <summary>
        /// <para>
        /// <para>The size start range (in bytes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_SizeRange_StartValue")]
        public System.Int64? SizeRange_StartValue { get; set; }
        #endregion
        
        #region Parameter Filters_TextLocale
        /// <summary>
        /// <para>
        /// <para>Filters by the locale of the content or comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_TextLocales")]
        public System.String[] Filters_TextLocale { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Max results count per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The marker for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.SearchResourcesResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.SearchResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.SearchResourcesResponse, SearchWDResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalResponseField != null)
            {
                context.AdditionalResponseField = new List<System.String>(this.AdditionalResponseField);
            }
            context.AuthenticationToken = this.AuthenticationToken;
            if (this.Filters_AncestorId != null)
            {
                context.Filters_AncestorId = new List<System.String>(this.Filters_AncestorId);
            }
            if (this.Filters_ContentCategory != null)
            {
                context.Filters_ContentCategory = new List<System.String>(this.Filters_ContentCategory);
            }
            context.CreatedRange_EndValue = this.CreatedRange_EndValue;
            context.CreatedRange_StartValue = this.CreatedRange_StartValue;
            if (this.Filters_Label != null)
            {
                context.Filters_Label = new List<System.String>(this.Filters_Label);
            }
            context.ModifiedRange_EndValue = this.ModifiedRange_EndValue;
            context.ModifiedRange_StartValue = this.ModifiedRange_StartValue;
            if (this.Filters_Principal != null)
            {
                context.Filters_Principal = new List<Amazon.WorkDocs.Model.SearchPrincipalType>(this.Filters_Principal);
            }
            if (this.Filters_ResourceType != null)
            {
                context.Filters_ResourceType = new List<System.String>(this.Filters_ResourceType);
            }
            if (this.Filters_SearchCollectionType != null)
            {
                context.Filters_SearchCollectionType = new List<System.String>(this.Filters_SearchCollectionType);
            }
            context.SizeRange_EndValue = this.SizeRange_EndValue;
            context.SizeRange_StartValue = this.SizeRange_StartValue;
            if (this.Filters_TextLocale != null)
            {
                context.Filters_TextLocale = new List<System.String>(this.Filters_TextLocale);
            }
            context.Limit = this.Limit;
            context.Marker = this.Marker;
            if (this.OrderBy != null)
            {
                context.OrderBy = new List<Amazon.WorkDocs.Model.SearchSortResult>(this.OrderBy);
            }
            context.OrganizationId = this.OrganizationId;
            if (this.QueryScope != null)
            {
                context.QueryScope = new List<System.String>(this.QueryScope);
            }
            context.QueryText = this.QueryText;
            
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
            var request = new Amazon.WorkDocs.Model.SearchResourcesRequest();
            
            if (cmdletContext.AdditionalResponseField != null)
            {
                request.AdditionalResponseFields = cmdletContext.AdditionalResponseField;
            }
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.WorkDocs.Model.Filters();
            List<System.String> requestFilters_filters_AncestorId = null;
            if (cmdletContext.Filters_AncestorId != null)
            {
                requestFilters_filters_AncestorId = cmdletContext.Filters_AncestorId;
            }
            if (requestFilters_filters_AncestorId != null)
            {
                request.Filters.AncestorIds = requestFilters_filters_AncestorId;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ContentCategory = null;
            if (cmdletContext.Filters_ContentCategory != null)
            {
                requestFilters_filters_ContentCategory = cmdletContext.Filters_ContentCategory;
            }
            if (requestFilters_filters_ContentCategory != null)
            {
                request.Filters.ContentCategories = requestFilters_filters_ContentCategory;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Label = null;
            if (cmdletContext.Filters_Label != null)
            {
                requestFilters_filters_Label = cmdletContext.Filters_Label;
            }
            if (requestFilters_filters_Label != null)
            {
                request.Filters.Labels = requestFilters_filters_Label;
                requestFiltersIsNull = false;
            }
            List<Amazon.WorkDocs.Model.SearchPrincipalType> requestFilters_filters_Principal = null;
            if (cmdletContext.Filters_Principal != null)
            {
                requestFilters_filters_Principal = cmdletContext.Filters_Principal;
            }
            if (requestFilters_filters_Principal != null)
            {
                request.Filters.Principals = requestFilters_filters_Principal;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ResourceType = null;
            if (cmdletContext.Filters_ResourceType != null)
            {
                requestFilters_filters_ResourceType = cmdletContext.Filters_ResourceType;
            }
            if (requestFilters_filters_ResourceType != null)
            {
                request.Filters.ResourceTypes = requestFilters_filters_ResourceType;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_SearchCollectionType = null;
            if (cmdletContext.Filters_SearchCollectionType != null)
            {
                requestFilters_filters_SearchCollectionType = cmdletContext.Filters_SearchCollectionType;
            }
            if (requestFilters_filters_SearchCollectionType != null)
            {
                request.Filters.SearchCollectionTypes = requestFilters_filters_SearchCollectionType;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_TextLocale = null;
            if (cmdletContext.Filters_TextLocale != null)
            {
                requestFilters_filters_TextLocale = cmdletContext.Filters_TextLocale;
            }
            if (requestFilters_filters_TextLocale != null)
            {
                request.Filters.TextLocales = requestFilters_filters_TextLocale;
                requestFiltersIsNull = false;
            }
            Amazon.WorkDocs.Model.DateRangeType requestFilters_filters_CreatedRange = null;
            
             // populate CreatedRange
            var requestFilters_filters_CreatedRangeIsNull = true;
            requestFilters_filters_CreatedRange = new Amazon.WorkDocs.Model.DateRangeType();
            System.DateTime? requestFilters_filters_CreatedRange_createdRange_EndValue = null;
            if (cmdletContext.CreatedRange_EndValue != null)
            {
                requestFilters_filters_CreatedRange_createdRange_EndValue = cmdletContext.CreatedRange_EndValue.Value;
            }
            if (requestFilters_filters_CreatedRange_createdRange_EndValue != null)
            {
                requestFilters_filters_CreatedRange.EndValue = requestFilters_filters_CreatedRange_createdRange_EndValue.Value;
                requestFilters_filters_CreatedRangeIsNull = false;
            }
            System.DateTime? requestFilters_filters_CreatedRange_createdRange_StartValue = null;
            if (cmdletContext.CreatedRange_StartValue != null)
            {
                requestFilters_filters_CreatedRange_createdRange_StartValue = cmdletContext.CreatedRange_StartValue.Value;
            }
            if (requestFilters_filters_CreatedRange_createdRange_StartValue != null)
            {
                requestFilters_filters_CreatedRange.StartValue = requestFilters_filters_CreatedRange_createdRange_StartValue.Value;
                requestFilters_filters_CreatedRangeIsNull = false;
            }
             // determine if requestFilters_filters_CreatedRange should be set to null
            if (requestFilters_filters_CreatedRangeIsNull)
            {
                requestFilters_filters_CreatedRange = null;
            }
            if (requestFilters_filters_CreatedRange != null)
            {
                request.Filters.CreatedRange = requestFilters_filters_CreatedRange;
                requestFiltersIsNull = false;
            }
            Amazon.WorkDocs.Model.DateRangeType requestFilters_filters_ModifiedRange = null;
            
             // populate ModifiedRange
            var requestFilters_filters_ModifiedRangeIsNull = true;
            requestFilters_filters_ModifiedRange = new Amazon.WorkDocs.Model.DateRangeType();
            System.DateTime? requestFilters_filters_ModifiedRange_modifiedRange_EndValue = null;
            if (cmdletContext.ModifiedRange_EndValue != null)
            {
                requestFilters_filters_ModifiedRange_modifiedRange_EndValue = cmdletContext.ModifiedRange_EndValue.Value;
            }
            if (requestFilters_filters_ModifiedRange_modifiedRange_EndValue != null)
            {
                requestFilters_filters_ModifiedRange.EndValue = requestFilters_filters_ModifiedRange_modifiedRange_EndValue.Value;
                requestFilters_filters_ModifiedRangeIsNull = false;
            }
            System.DateTime? requestFilters_filters_ModifiedRange_modifiedRange_StartValue = null;
            if (cmdletContext.ModifiedRange_StartValue != null)
            {
                requestFilters_filters_ModifiedRange_modifiedRange_StartValue = cmdletContext.ModifiedRange_StartValue.Value;
            }
            if (requestFilters_filters_ModifiedRange_modifiedRange_StartValue != null)
            {
                requestFilters_filters_ModifiedRange.StartValue = requestFilters_filters_ModifiedRange_modifiedRange_StartValue.Value;
                requestFilters_filters_ModifiedRangeIsNull = false;
            }
             // determine if requestFilters_filters_ModifiedRange should be set to null
            if (requestFilters_filters_ModifiedRangeIsNull)
            {
                requestFilters_filters_ModifiedRange = null;
            }
            if (requestFilters_filters_ModifiedRange != null)
            {
                request.Filters.ModifiedRange = requestFilters_filters_ModifiedRange;
                requestFiltersIsNull = false;
            }
            Amazon.WorkDocs.Model.LongRangeType requestFilters_filters_SizeRange = null;
            
             // populate SizeRange
            var requestFilters_filters_SizeRangeIsNull = true;
            requestFilters_filters_SizeRange = new Amazon.WorkDocs.Model.LongRangeType();
            System.Int64? requestFilters_filters_SizeRange_sizeRange_EndValue = null;
            if (cmdletContext.SizeRange_EndValue != null)
            {
                requestFilters_filters_SizeRange_sizeRange_EndValue = cmdletContext.SizeRange_EndValue.Value;
            }
            if (requestFilters_filters_SizeRange_sizeRange_EndValue != null)
            {
                requestFilters_filters_SizeRange.EndValue = requestFilters_filters_SizeRange_sizeRange_EndValue.Value;
                requestFilters_filters_SizeRangeIsNull = false;
            }
            System.Int64? requestFilters_filters_SizeRange_sizeRange_StartValue = null;
            if (cmdletContext.SizeRange_StartValue != null)
            {
                requestFilters_filters_SizeRange_sizeRange_StartValue = cmdletContext.SizeRange_StartValue.Value;
            }
            if (requestFilters_filters_SizeRange_sizeRange_StartValue != null)
            {
                requestFilters_filters_SizeRange.StartValue = requestFilters_filters_SizeRange_sizeRange_StartValue.Value;
                requestFilters_filters_SizeRangeIsNull = false;
            }
             // determine if requestFilters_filters_SizeRange should be set to null
            if (requestFilters_filters_SizeRangeIsNull)
            {
                requestFilters_filters_SizeRange = null;
            }
            if (requestFilters_filters_SizeRange != null)
            {
                request.Filters.SizeRange = requestFilters_filters_SizeRange;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.OrderBy != null)
            {
                request.OrderBy = cmdletContext.OrderBy;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.QueryScope != null)
            {
                request.QueryScopes = cmdletContext.QueryScope;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.WorkDocs.Model.SearchResourcesResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.SearchResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "SearchResources");
            try
            {
                return client.SearchResourcesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalResponseField { get; set; }
            public System.String AuthenticationToken { get; set; }
            public List<System.String> Filters_AncestorId { get; set; }
            public List<System.String> Filters_ContentCategory { get; set; }
            public System.DateTime? CreatedRange_EndValue { get; set; }
            public System.DateTime? CreatedRange_StartValue { get; set; }
            public List<System.String> Filters_Label { get; set; }
            public System.DateTime? ModifiedRange_EndValue { get; set; }
            public System.DateTime? ModifiedRange_StartValue { get; set; }
            public List<Amazon.WorkDocs.Model.SearchPrincipalType> Filters_Principal { get; set; }
            public List<System.String> Filters_ResourceType { get; set; }
            public List<System.String> Filters_SearchCollectionType { get; set; }
            public System.Int64? SizeRange_EndValue { get; set; }
            public System.Int64? SizeRange_StartValue { get; set; }
            public List<System.String> Filters_TextLocale { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String Marker { get; set; }
            public List<Amazon.WorkDocs.Model.SearchSortResult> OrderBy { get; set; }
            public System.String OrganizationId { get; set; }
            public List<System.String> QueryScope { get; set; }
            public System.String QueryText { get; set; }
            public System.Func<Amazon.WorkDocs.Model.SearchResourcesResponse, SearchWDResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
