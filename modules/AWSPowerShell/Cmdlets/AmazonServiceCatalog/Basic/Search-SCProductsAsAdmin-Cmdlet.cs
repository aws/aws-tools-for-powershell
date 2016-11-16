/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Retrieves summary and status information about all products created within the caller's
    /// account. If a portfolio ID is provided, this operation retrieves information for only
    /// those products that are associated with the specified portfolio.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Search", "SCProductsAsAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.ProductViewDetail")]
    [AWSCmdlet("Invokes the SearchProductsAsAdmin operation against AWS Service Catalog.", Operation = new[] {"SearchProductsAsAdmin"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.ProductViewDetail",
        "This cmdlet returns a collection of ProductViewDetail objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.SearchProductsAsAdminResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageToken (type System.String)"
    )]
    public partial class SearchSCProductsAsAdminCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code to use for this operation. Supported language codes are as follows:</para><para>"en" (English)</para><para>"jp" (Japanese)</para><para>"zh" (Chinese)</para><para>If no code is specified, "en" is used as the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The list of filters with which to limit search results. If no search filters are specified,
        /// the output is all the products to which the administrator has access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the results. If more results exist than fit
        /// in the specified <code>PageSize</code>, the value of <code>NextPageToken</code> in
        /// the response is non-null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int PageSize { get; set; }
        #endregion
        
        #region Parameter PortfolioId
        /// <summary>
        /// <para>
        /// <para>The portfolio identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PortfolioId { get; set; }
        #endregion
        
        #region Parameter ProductSource
        /// <summary>
        /// <para>
        /// <para>Access level of the source of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProductSource")]
        public Amazon.ServiceCatalog.ProductSource ProductSource { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The sort field specifier. If no value is specified, results are not sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProductViewSortBy")]
        public Amazon.ServiceCatalog.ProductViewSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order specifier. If no value is specified, results are not sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.SortOrder")]
        public Amazon.ServiceCatalog.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The page token of the first page retrieved. If null, this retrieves the first page
        /// of size <code>PageSize</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PortfolioId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-SCProductsAsAdmin (SearchProductsAsAdmin)"))
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
            
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.Filter != null)
            {
                context.Filters = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    object hashValue = this.Filter[hashKey];
                    if (hashValue == null)
                    {
                        context.Filters.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Filters.Add((String)hashKey, valueSet);
                }
            }
            if (ParameterWasBound("PageSize"))
                context.PageSize = this.PageSize;
            context.PageToken = this.PageToken;
            context.PortfolioId = this.PortfolioId;
            context.ProductSource = this.ProductSource;
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
            var request = new Amazon.ServiceCatalog.Model.SearchProductsAsAdminRequest();
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.PortfolioId != null)
            {
                request.PortfolioId = cmdletContext.PortfolioId;
            }
            if (cmdletContext.ProductSource != null)
            {
                request.ProductSource = cmdletContext.ProductSource;
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
            if (AutoIterationHelpers.HasValue(cmdletContext.PageToken))
            {
                _nextMarker = cmdletContext.PageToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.PageSize))
            {
                _emitLimit = cmdletContext.PageSize;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.PageToken) || AutoIterationHelpers.HasValue(cmdletContext.PageSize);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.PageToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.PageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ProductViewDetails;
                        notes = new Dictionary<string, object>();
                        notes["NextPageToken"] = response.NextPageToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ProductViewDetails.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.PageToken));
                        }
                        
                        _nextMarker = response.NextPageToken;
                        
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
        
        private static Amazon.ServiceCatalog.Model.SearchProductsAsAdminResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.SearchProductsAsAdminRequest request)
        {
            #if DESKTOP
            return client.SearchProductsAsAdmin(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SearchProductsAsAdminAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AcceptLanguage { get; set; }
            public Dictionary<System.String, List<System.String>> Filters { get; set; }
            public int? PageSize { get; set; }
            public System.String PageToken { get; set; }
            public System.String PortfolioId { get; set; }
            public Amazon.ServiceCatalog.ProductSource ProductSource { get; set; }
            public Amazon.ServiceCatalog.ProductViewSortBy SortBy { get; set; }
            public Amazon.ServiceCatalog.SortOrder SortOrder { get; set; }
        }
        
    }
}
