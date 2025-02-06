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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Gets a list of all existing endpoints that you've created. For information about endpoints,
    /// see <a href="https://docs.aws.amazon.com/comprehend/latest/dg/manage-endpoints.html">Managing
    /// endpoints</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COMPEndpointList")]
    [OutputType("Amazon.Comprehend.Model.EndpointProperties")]
    [AWSCmdlet("Calls the Amazon Comprehend ListEndpoints API operation.", Operation = new[] {"ListEndpoints"}, SelectReturnType = typeof(Amazon.Comprehend.Model.ListEndpointsResponse))]
    [AWSCmdletOutput("Amazon.Comprehend.Model.EndpointProperties or Amazon.Comprehend.Model.ListEndpointsResponse",
        "This cmdlet returns a collection of Amazon.Comprehend.Model.EndpointProperties objects.",
        "The service call response (type Amazon.Comprehend.Model.ListEndpointsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOMPEndpointListCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>Specifies a date after which the returned endpoint or endpoints were created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>Specifies a date before which the returned endpoint or endpoints were created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter Filter_ModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the model to which the endpoint is attached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_ModelArn { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>Specifies the status of the endpoint being returned. Possible values are: Creating,
        /// Ready, Updating, Deleting, Failed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Comprehend.EndpointStatus")]
        public Amazon.Comprehend.EndpointStatus Filter_Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in each page. The default is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>500</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Identifies the next page of results to return.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointPropertiesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.ListEndpointsResponse).
        /// Specifying the name of a property of type Amazon.Comprehend.Model.ListEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointPropertiesList";
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
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.ListEndpointsResponse, GetCOMPEndpointListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter_CreationTimeAfter = this.Filter_CreationTimeAfter;
            context.Filter_CreationTimeBefore = this.Filter_CreationTimeBefore;
            context.Filter_ModelArn = this.Filter_ModelArn;
            context.Filter_Status = this.Filter_Status;
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '500'");
                context.MaxResult = 500;
            }
            #endif
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
            var request = new Amazon.Comprehend.Model.ListEndpointsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Comprehend.Model.EndpointFilter();
            System.DateTime? requestFilter_filter_CreationTimeAfter = null;
            if (cmdletContext.Filter_CreationTimeAfter != null)
            {
                requestFilter_filter_CreationTimeAfter = cmdletContext.Filter_CreationTimeAfter.Value;
            }
            if (requestFilter_filter_CreationTimeAfter != null)
            {
                request.Filter.CreationTimeAfter = requestFilter_filter_CreationTimeAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreationTimeBefore = null;
            if (cmdletContext.Filter_CreationTimeBefore != null)
            {
                requestFilter_filter_CreationTimeBefore = cmdletContext.Filter_CreationTimeBefore.Value;
            }
            if (requestFilter_filter_CreationTimeBefore != null)
            {
                request.Filter.CreationTimeBefore = requestFilter_filter_CreationTimeBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_ModelArn = null;
            if (cmdletContext.Filter_ModelArn != null)
            {
                requestFilter_filter_ModelArn = cmdletContext.Filter_ModelArn;
            }
            if (requestFilter_filter_ModelArn != null)
            {
                request.Filter.ModelArn = requestFilter_filter_ModelArn;
                requestFilterIsNull = false;
            }
            Amazon.Comprehend.EndpointStatus requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
            var request = new Amazon.Comprehend.Model.ListEndpointsRequest();
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Comprehend.Model.EndpointFilter();
            System.DateTime? requestFilter_filter_CreationTimeAfter = null;
            if (cmdletContext.Filter_CreationTimeAfter != null)
            {
                requestFilter_filter_CreationTimeAfter = cmdletContext.Filter_CreationTimeAfter.Value;
            }
            if (requestFilter_filter_CreationTimeAfter != null)
            {
                request.Filter.CreationTimeAfter = requestFilter_filter_CreationTimeAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreationTimeBefore = null;
            if (cmdletContext.Filter_CreationTimeBefore != null)
            {
                requestFilter_filter_CreationTimeBefore = cmdletContext.Filter_CreationTimeBefore.Value;
            }
            if (requestFilter_filter_CreationTimeBefore != null)
            {
                request.Filter.CreationTimeBefore = requestFilter_filter_CreationTimeBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_ModelArn = null;
            if (cmdletContext.Filter_ModelArn != null)
            {
                requestFilter_filter_ModelArn = cmdletContext.Filter_ModelArn;
            }
            if (requestFilter_filter_ModelArn != null)
            {
                request.Filter.ModelArn = requestFilter_filter_ModelArn;
                requestFilterIsNull = false;
            }
            Amazon.Comprehend.EndpointStatus requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
                // The service has a maximum page size of 500. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 500 items back. If a page size is set, that will
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
                    int correctPageSize = Math.Min(500, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(500);
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
                    int _receivedThisCall = response.EndpointPropertiesList?.Count ?? 0;
                    
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
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
        
        private Amazon.Comprehend.Model.ListEndpointsResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.ListEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "ListEndpoints");
            try
            {
                #if DESKTOP
                return client.ListEndpoints(request);
                #elif CORECLR
                return client.ListEndpointsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_CreationTimeAfter { get; set; }
            public System.DateTime? Filter_CreationTimeBefore { get; set; }
            public System.String Filter_ModelArn { get; set; }
            public Amazon.Comprehend.EndpointStatus Filter_Status { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Comprehend.Model.ListEndpointsResponse, GetCOMPEndpointListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointPropertiesList;
        }
        
    }
}
