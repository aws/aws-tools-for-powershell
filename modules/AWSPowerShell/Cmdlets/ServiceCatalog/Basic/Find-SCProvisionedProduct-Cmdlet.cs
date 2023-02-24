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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Gets information about the provisioned products that meet the specified criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Find", "SCProvisionedProduct")]
    [OutputType("Amazon.ServiceCatalog.Model.ProvisionedProductAttribute")]
    [AWSCmdlet("Calls the AWS Service Catalog SearchProvisionedProducts API operation.", Operation = new[] {"SearchProvisionedProducts"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.ProvisionedProductAttribute or Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse",
        "This cmdlet returns a collection of Amazon.ServiceCatalog.Model.ProvisionedProductAttribute objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindSCProvisionedProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>en</code> - English (default)</para></li><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The search filters.</para><para>When the key is <code>SearchQuery</code>, the searchable fields are <code>arn</code>,
        /// <code>createdTime</code>, <code>id</code>, <code>lastRecordId</code>, <code>idempotencyToken</code>,
        /// <code>name</code>, <code>physicalId</code>, <code>productId</code>, <code>provisioningArtifact</code>,
        /// <code>type</code>, <code>status</code>, <code>tags</code>, <code>userArn</code>, <code>userArnSession</code>,
        /// <code>lastProvisioningRecordId</code>, <code>lastSuccessfulProvisioningRecordId</code>,
        /// <code>productName</code>, and <code>provisioningArtifactName</code>.</para><para>Example: <code>"SearchQuery":["status:AVAILABLE"]</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter AccessLevelFilter_Key
        /// <summary>
        /// <para>
        /// <para>The access level.</para><ul><li><para><code>Account</code> - Filter results based on the account.</para></li><li><para><code>Role</code> - Filter results based on the federated role of the specified user.</para></li><li><para><code>User</code> - Filter results based on the specified user.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.AccessLevelFilterKey")]
        public Amazon.ServiceCatalog.AccessLevelFilterKey AccessLevelFilter_Key { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The sort field. If no value is specified, the results are not sorted. The valid values
        /// are <code>arn</code>, <code>id</code>, <code>name</code>, and <code>lastRecordId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order. If no value is specified, the results are not sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServiceCatalog.SortOrder")]
        public Amazon.ServiceCatalog.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter AccessLevelFilter_Value
        /// <summary>
        /// <para>
        /// <para>The user to which the access level applies. The only supported value is <code>Self</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLevelFilter_Value { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return with this call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? PageSize { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>The page token for the next set of results. To retrieve the first set of results,
        /// use null.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-PageToken $null' for the first call and '-PageToken $AWSHistory.LastServiceResponse.NextPageToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProvisionedProducts'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProvisionedProducts";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of PageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse, FindSCProvisionedProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            context.AccessLevelFilter_Key = this.AccessLevelFilter_Key;
            context.AccessLevelFilter_Value = this.AccessLevelFilter_Value;
            if (this.Filter != null)
            {
                context.Filter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    object hashValue = this.Filter[hashKey];
                    if (hashValue == null)
                    {
                        context.Filter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Filter.Add((String)hashKey, valueSet);
                }
            }
            context.PageSize = this.PageSize;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.PageSize)) && this.PageSize.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the PageSize parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing PageSize" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.PageToken = this.PageToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.ServiceCatalog.Model.SearchProvisionedProductsRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            
             // populate AccessLevelFilter
            var requestAccessLevelFilterIsNull = true;
            request.AccessLevelFilter = new Amazon.ServiceCatalog.Model.AccessLevelFilter();
            Amazon.ServiceCatalog.AccessLevelFilterKey requestAccessLevelFilter_accessLevelFilter_Key = null;
            if (cmdletContext.AccessLevelFilter_Key != null)
            {
                requestAccessLevelFilter_accessLevelFilter_Key = cmdletContext.AccessLevelFilter_Key;
            }
            if (requestAccessLevelFilter_accessLevelFilter_Key != null)
            {
                request.AccessLevelFilter.Key = requestAccessLevelFilter_accessLevelFilter_Key;
                requestAccessLevelFilterIsNull = false;
            }
            System.String requestAccessLevelFilter_accessLevelFilter_Value = null;
            if (cmdletContext.AccessLevelFilter_Value != null)
            {
                requestAccessLevelFilter_accessLevelFilter_Value = cmdletContext.AccessLevelFilter_Value;
            }
            if (requestAccessLevelFilter_accessLevelFilter_Value != null)
            {
                request.AccessLevelFilter.Value = requestAccessLevelFilter_accessLevelFilter_Value;
                requestAccessLevelFilterIsNull = false;
            }
             // determine if request.AccessLevelFilter should be set to null
            if (requestAccessLevelFilterIsNull)
            {
                request.AccessLevelFilter = null;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.PageSize.Value);
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.PageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.PageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.PageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
            var request = new Amazon.ServiceCatalog.Model.SearchProvisionedProductsRequest();
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            
             // populate AccessLevelFilter
            var requestAccessLevelFilterIsNull = true;
            request.AccessLevelFilter = new Amazon.ServiceCatalog.Model.AccessLevelFilter();
            Amazon.ServiceCatalog.AccessLevelFilterKey requestAccessLevelFilter_accessLevelFilter_Key = null;
            if (cmdletContext.AccessLevelFilter_Key != null)
            {
                requestAccessLevelFilter_accessLevelFilter_Key = cmdletContext.AccessLevelFilter_Key;
            }
            if (requestAccessLevelFilter_accessLevelFilter_Key != null)
            {
                request.AccessLevelFilter.Key = requestAccessLevelFilter_accessLevelFilter_Key;
                requestAccessLevelFilterIsNull = false;
            }
            System.String requestAccessLevelFilter_accessLevelFilter_Value = null;
            if (cmdletContext.AccessLevelFilter_Value != null)
            {
                requestAccessLevelFilter_accessLevelFilter_Value = cmdletContext.AccessLevelFilter_Value;
            }
            if (requestAccessLevelFilter_accessLevelFilter_Value != null)
            {
                request.AccessLevelFilter.Value = requestAccessLevelFilter_accessLevelFilter_Value;
                requestAccessLevelFilterIsNull = false;
            }
             // determine if request.AccessLevelFilter should be set to null
            if (requestAccessLevelFilterIsNull)
            {
                request.AccessLevelFilter = null;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.PageToken))
            {
                _nextToken = cmdletContext.PageToken;
            }
            if (cmdletContext.PageSize.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.PageSize;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.PageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.PageToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.PageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.ProvisionedProducts.Count;
                    
                    _nextToken = response.NextPageToken;
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
            
            
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
        
        private Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.SearchProvisionedProductsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "SearchProvisionedProducts");
            try
            {
                #if DESKTOP
                return client.SearchProvisionedProducts(request);
                #elif CORECLR
                return client.SearchProvisionedProductsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ServiceCatalog.AccessLevelFilterKey AccessLevelFilter_Key { get; set; }
            public System.String AccessLevelFilter_Value { get; set; }
            public Dictionary<System.String, List<System.String>> Filter { get; set; }
            public int? PageSize { get; set; }
            public System.String PageToken { get; set; }
            public System.String SortBy { get; set; }
            public Amazon.ServiceCatalog.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.SearchProvisionedProductsResponse, FindSCProvisionedProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProvisionedProducts;
        }
        
    }
}
