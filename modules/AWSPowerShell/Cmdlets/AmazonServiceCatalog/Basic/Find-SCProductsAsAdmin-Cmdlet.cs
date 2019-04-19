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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Gets information about the products for the specified portfolio or all products.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Find", "SCProductsAsAdmin")]
    [OutputType("Amazon.ServiceCatalog.Model.ProductViewDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog SearchProductsAsAdmin API operation.", Operation = new[] {"SearchProductsAsAdmin"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.ProductViewDetail",
        "This cmdlet returns a collection of ProductViewDetail objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.SearchProductsAsAdminResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageToken (type System.String)"
    )]
    public partial class FindSCProductsAsAdminCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>en</code> - English (default)</para></li><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The search filters. If no search filters are specified, the output includes all products
        /// to which the administrator has access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public System.Collections.Hashtable Filter { get; set; }
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
        /// <para>The sort field. If no value is specified, the results are not sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.ProductViewSortBy")]
        public Amazon.ServiceCatalog.ProductViewSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order. If no value is specified, the results are not sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServiceCatalog.SortOrder")]
        public Amazon.ServiceCatalog.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return with this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int PageSize { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The page token for the next set of results. To retrieve the first set of results,
        /// use null.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextPageToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
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
                // The service has a maximum page size of 20. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 20 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.PageSize;
            }
            bool _userControllingPaging = ParameterWasBound("PageToken");
            
            try
            {
                do
                {
                    request.PageToken = _nextMarker;
                    int correctPageSize = 20;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(20, _emitLimit.Value);
                    }
                    request.PageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
                
            }
            finally
            {
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ServiceCatalog.Model.SearchProductsAsAdminResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.SearchProductsAsAdminRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "SearchProductsAsAdmin");
            try
            {
                #if DESKTOP
                return client.SearchProductsAsAdmin(request);
                #elif CORECLR
                return client.SearchProductsAsAdminAsync(request).GetAwaiter().GetResult();
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
