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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns the event types that meet the specified filter criteria. You can use this
    /// API operation to find information about the Health event, such as the category, Amazon
    /// Web Service, and event code. The metadata for each event appears in the <a href="https://docs.aws.amazon.com/health/latest/APIReference/API_EventType.html">EventType</a>
    /// object. 
    /// 
    ///  
    /// <para>
    /// If you don't specify a filter criteria, the API operation returns all event types,
    /// in no particular order. 
    /// </para><note><para>
    /// This API operation uses pagination. Specify the <c>nextToken</c> parameter in the
    /// next request to return more results.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "HLTHEventType")]
    [OutputType("Amazon.AWSHealth.Model.EventType")]
    [AWSCmdlet("Calls the AWS Health DescribeEventTypes API operation.", Operation = new[] {"DescribeEventTypes"}, SelectReturnType = typeof(Amazon.AWSHealth.Model.DescribeEventTypesResponse))]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.EventType or Amazon.AWSHealth.Model.DescribeEventTypesResponse",
        "This cmdlet returns a collection of Amazon.AWSHealth.Model.EventType objects.",
        "The service call response (type Amazon.AWSHealth.Model.DescribeEventTypesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetHLTHEventTypeCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_EventTypeCategory
        /// <summary>
        /// <para>
        /// <para>A list of event type category codes. Possible values are <c>issue</c>, <c>accountNotification</c>,
        /// or <c>scheduledChange</c>. Currently, the <c>investigation</c> value isn't supported
        /// at this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EventTypeCategories")]
        public System.String[] Filter_EventTypeCategory { get; set; }
        #endregion
        
        #region Parameter Filter_EventTypeCode
        /// <summary>
        /// <para>
        /// <para>A list of event type codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_EventTypeCodes")]
        public System.String[] Filter_EventTypeCode { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale (language) to return information in. English (en) is the default and the
        /// only supported value at this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Filter_Service
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services associated with the event. For example, <c>EC2</c>, <c>RDS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Services")]
        public System.String[] Filter_Service { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in one batch, between 10 and 100, inclusive.</para><note><para>If you don't specify the <c>maxResults</c> parameter, this operation returns a maximum
        /// of 30 items by default.</para></note>
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
        /// <para>If the results of a search are large, only a portion of the results are returned,
        /// and a <c>nextToken</c> pagination token is returned in the response. To retrieve the
        /// next batch of results, reissue the search request and include the returned token.
        /// When all results have been returned, the response does not contain a pagination token
        /// value.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventTypes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSHealth.Model.DescribeEventTypesResponse).
        /// Specifying the name of a property of type Amazon.AWSHealth.Model.DescribeEventTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventTypes";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSHealth.Model.DescribeEventTypesResponse, GetHLTHEventTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter_EventTypeCategory != null)
            {
                context.Filter_EventTypeCategory = new List<System.String>(this.Filter_EventTypeCategory);
            }
            if (this.Filter_EventTypeCode != null)
            {
                context.Filter_EventTypeCode = new List<System.String>(this.Filter_EventTypeCode);
            }
            if (this.Filter_Service != null)
            {
                context.Filter_Service = new List<System.String>(this.Filter_Service);
            }
            context.Locale = this.Locale;
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
            var request = new Amazon.AWSHealth.Model.DescribeEventTypesRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EventTypeFilter();
            List<System.String> requestFilter_filter_EventTypeCategory = null;
            if (cmdletContext.Filter_EventTypeCategory != null)
            {
                requestFilter_filter_EventTypeCategory = cmdletContext.Filter_EventTypeCategory;
            }
            if (requestFilter_filter_EventTypeCategory != null)
            {
                request.Filter.EventTypeCategories = requestFilter_filter_EventTypeCategory;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCode = null;
            if (cmdletContext.Filter_EventTypeCode != null)
            {
                requestFilter_filter_EventTypeCode = cmdletContext.Filter_EventTypeCode;
            }
            if (requestFilter_filter_EventTypeCode != null)
            {
                request.Filter.EventTypeCodes = requestFilter_filter_EventTypeCode;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Service = null;
            if (cmdletContext.Filter_Service != null)
            {
                requestFilter_filter_Service = cmdletContext.Filter_Service;
            }
            if (requestFilter_filter_Service != null)
            {
                request.Filter.Services = requestFilter_filter_Service;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
            var request = new Amazon.AWSHealth.Model.DescribeEventTypesRequest();
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EventTypeFilter();
            List<System.String> requestFilter_filter_EventTypeCategory = null;
            if (cmdletContext.Filter_EventTypeCategory != null)
            {
                requestFilter_filter_EventTypeCategory = cmdletContext.Filter_EventTypeCategory;
            }
            if (requestFilter_filter_EventTypeCategory != null)
            {
                request.Filter.EventTypeCategories = requestFilter_filter_EventTypeCategory;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCode = null;
            if (cmdletContext.Filter_EventTypeCode != null)
            {
                requestFilter_filter_EventTypeCode = cmdletContext.Filter_EventTypeCode;
            }
            if (requestFilter_filter_EventTypeCode != null)
            {
                request.Filter.EventTypeCodes = requestFilter_filter_EventTypeCode;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Service = null;
            if (cmdletContext.Filter_Service != null)
            {
                requestFilter_filter_Service = cmdletContext.Filter_Service;
            }
            if (requestFilter_filter_Service != null)
            {
                request.Filter.Services = requestFilter_filter_Service;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
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
                    int _receivedThisCall = response.EventTypes?.Count ?? 0;
                    
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 10));
            
            
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
        
        private Amazon.AWSHealth.Model.DescribeEventTypesResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEventTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEventTypes");
            try
            {
                #if DESKTOP
                return client.DescribeEventTypes(request);
                #elif CORECLR
                return client.DescribeEventTypesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filter_EventTypeCategory { get; set; }
            public List<System.String> Filter_EventTypeCode { get; set; }
            public List<System.String> Filter_Service { get; set; }
            public System.String Locale { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.AWSHealth.Model.DescribeEventTypesResponse, GetHLTHEventTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventTypes;
        }
        
    }
}
