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
    /// Lists the specified TagOptions or all TagOptions.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "SCTagOptionList")]
    [OutputType("Amazon.ServiceCatalog.Model.TagOptionDetail")]
    [AWSCmdlet("Calls the AWS Service Catalog ListTagOptions API operation.", Operation = new[] {"ListTagOptions"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.TagOptionDetail",
        "This cmdlet returns a collection of TagOptionDetail objects.",
        "The service call response (type Amazon.ServiceCatalog.Model.ListTagOptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: PageToken (type System.String)"
    )]
    public partial class GetSCTagOptionListCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_Active
        /// <summary>
        /// <para>
        /// <para>The active state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Filters_Active { get; set; }
        #endregion
        
        #region Parameter Filters_Key
        /// <summary>
        /// <para>
        /// <para>The TagOption key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_Key { get; set; }
        #endregion
        
        #region Parameter Filters_Value
        /// <summary>
        /// <para>
        /// <para>The TagOption value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_Value { get; set; }
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
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.PageToken, for subsequent calls, to this parameter.
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
            
            if (ParameterWasBound("Filters_Active"))
                context.Filters_Active = this.Filters_Active;
            context.Filters_Key = this.Filters_Key;
            context.Filters_Value = this.Filters_Value;
            if (ParameterWasBound("PageSize"))
                context.PageSize = this.PageSize;
            context.PageToken = this.PageToken;
            
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
            var request = new Amazon.ServiceCatalog.Model.ListTagOptionsRequest();
            
             // populate Filters
            bool requestFiltersIsNull = true;
            request.Filters = new Amazon.ServiceCatalog.Model.ListTagOptionsFilters();
            System.Boolean? requestFilters_filters_Active = null;
            if (cmdletContext.Filters_Active != null)
            {
                requestFilters_filters_Active = cmdletContext.Filters_Active.Value;
            }
            if (requestFilters_filters_Active != null)
            {
                request.Filters.Active = requestFilters_filters_Active.Value;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_Key = null;
            if (cmdletContext.Filters_Key != null)
            {
                requestFilters_filters_Key = cmdletContext.Filters_Key;
            }
            if (requestFilters_filters_Key != null)
            {
                request.Filters.Key = requestFilters_filters_Key;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_Value = null;
            if (cmdletContext.Filters_Value != null)
            {
                requestFilters_filters_Value = cmdletContext.Filters_Value;
            }
            if (requestFilters_filters_Value != null)
            {
                request.Filters.Value = requestFilters_filters_Value;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
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
                        object pipelineOutput = response.TagOptionDetails;
                        notes = new Dictionary<string, object>();
                        notes["PageToken"] = response.PageToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.TagOptionDetails.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.PageToken));
                        }
                        
                        _nextMarker = response.PageToken;
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
        
        private Amazon.ServiceCatalog.Model.ListTagOptionsResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.ListTagOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "ListTagOptions");
            try
            {
                #if DESKTOP
                return client.ListTagOptions(request);
                #elif CORECLR
                return client.ListTagOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Filters_Active { get; set; }
            public System.String Filters_Key { get; set; }
            public System.String Filters_Value { get; set; }
            public int? PageSize { get; set; }
            public System.String PageToken { get; set; }
        }
        
    }
}
