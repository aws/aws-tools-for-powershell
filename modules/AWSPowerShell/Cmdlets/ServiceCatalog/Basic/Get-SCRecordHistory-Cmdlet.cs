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
    /// Lists the specified requests or all performed requests.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SCRecordHistory")]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog ListRecordHistory API operation.", Operation = new[] {"ListRecordHistory"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.ListRecordHistoryResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail or Amazon.ServiceCatalog.Model.ListRecordHistoryResponse",
        "This cmdlet returns a collection of Amazon.ServiceCatalog.Model.RecordDetail objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.ListRecordHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSCRecordHistoryCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
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
        
        #region Parameter SearchFilter_Key
        /// <summary>
        /// <para>
        /// <para>The filter key.</para><ul><li><para><code>product</code> - Filter results based on the specified product identifier.</para></li><li><para><code>provisionedproduct</code> - Filter results based on the provisioned product
        /// identifier.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchFilter_Key { get; set; }
        #endregion
        
        #region Parameter AccessLevelFilter_Value
        /// <summary>
        /// <para>
        /// <para>The user to which the access level applies. The only supported value is <code>self</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLevelFilter_Value { get; set; }
        #endregion
        
        #region Parameter SearchFilter_Value
        /// <summary>
        /// <para>
        /// <para>The filter value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchFilter_Value { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecordDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.ListRecordHistoryResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.ListRecordHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecordDetails";
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
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.ListRecordHistoryResponse, GetSCRecordHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptLanguage = this.AcceptLanguage;
            context.AccessLevelFilter_Key = this.AccessLevelFilter_Key;
            context.AccessLevelFilter_Value = this.AccessLevelFilter_Value;
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
            context.SearchFilter_Key = this.SearchFilter_Key;
            context.SearchFilter_Value = this.SearchFilter_Value;
            
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
            var request = new Amazon.ServiceCatalog.Model.ListRecordHistoryRequest();
            
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
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.PageSize.Value);
            }
            
             // populate SearchFilter
            var requestSearchFilterIsNull = true;
            request.SearchFilter = new Amazon.ServiceCatalog.Model.ListRecordHistorySearchFilter();
            System.String requestSearchFilter_searchFilter_Key = null;
            if (cmdletContext.SearchFilter_Key != null)
            {
                requestSearchFilter_searchFilter_Key = cmdletContext.SearchFilter_Key;
            }
            if (requestSearchFilter_searchFilter_Key != null)
            {
                request.SearchFilter.Key = requestSearchFilter_searchFilter_Key;
                requestSearchFilterIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_Value = null;
            if (cmdletContext.SearchFilter_Value != null)
            {
                requestSearchFilter_searchFilter_Value = cmdletContext.SearchFilter_Value;
            }
            if (requestSearchFilter_searchFilter_Value != null)
            {
                request.SearchFilter.Value = requestSearchFilter_searchFilter_Value;
                requestSearchFilterIsNull = false;
            }
             // determine if request.SearchFilter should be set to null
            if (requestSearchFilterIsNull)
            {
                request.SearchFilter = null;
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
            var request = new Amazon.ServiceCatalog.Model.ListRecordHistoryRequest();
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
            
             // populate SearchFilter
            var requestSearchFilterIsNull = true;
            request.SearchFilter = new Amazon.ServiceCatalog.Model.ListRecordHistorySearchFilter();
            System.String requestSearchFilter_searchFilter_Key = null;
            if (cmdletContext.SearchFilter_Key != null)
            {
                requestSearchFilter_searchFilter_Key = cmdletContext.SearchFilter_Key;
            }
            if (requestSearchFilter_searchFilter_Key != null)
            {
                request.SearchFilter.Key = requestSearchFilter_searchFilter_Key;
                requestSearchFilterIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_Value = null;
            if (cmdletContext.SearchFilter_Value != null)
            {
                requestSearchFilter_searchFilter_Value = cmdletContext.SearchFilter_Value;
            }
            if (requestSearchFilter_searchFilter_Value != null)
            {
                request.SearchFilter.Value = requestSearchFilter_searchFilter_Value;
                requestSearchFilterIsNull = false;
            }
             // determine if request.SearchFilter should be set to null
            if (requestSearchFilterIsNull)
            {
                request.SearchFilter = null;
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
                // The service has a maximum page size of 20. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 20 items back. If a page size is set, that will
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
                    int correctPageSize = Math.Min(20, _emitLimit.Value);
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
                    int _receivedThisCall = response.RecordDetails.Count;
                    
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
        
        private Amazon.ServiceCatalog.Model.ListRecordHistoryResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.ListRecordHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "ListRecordHistory");
            try
            {
                #if DESKTOP
                return client.ListRecordHistory(request);
                #elif CORECLR
                return client.ListRecordHistoryAsync(request).GetAwaiter().GetResult();
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
            public int? PageSize { get; set; }
            public System.String PageToken { get; set; }
            public System.String SearchFilter_Key { get; set; }
            public System.String SearchFilter_Value { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.ListRecordHistoryResponse, GetSCRecordHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecordDetails;
        }
        
    }
}
