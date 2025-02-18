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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about the latest version for every traffic policy that is associated
    /// with the current Amazon Web Services account. Policies are listed in the order that
    /// they were created in. 
    /// 
    ///  
    /// <para>
    /// For information about how of deleting a traffic policy affects the response from <c>ListTrafficPolicies</c>,
    /// see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_DeleteTrafficPolicy.html">DeleteTrafficPolicy</a>.
    /// 
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyList")]
    [OutputType("Amazon.Route53.Model.TrafficPolicySummary")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicies API operation.", Operation = new[] {"ListTrafficPolicies"}, SelectReturnType = typeof(Amazon.Route53.Model.ListTrafficPoliciesResponse), LegacyAlias="Get-R53TrafficPolicies")]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicySummary or Amazon.Route53.Model.ListTrafficPoliciesResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.TrafficPolicySummary objects.",
        "The service call response (type Amazon.Route53.Model.ListTrafficPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53TrafficPolicyListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of traffic policies that you want Amazon Route 53 to
        /// return in response to this request. If you have more than <c>MaxItems</c> traffic
        /// policies, the value of <c>IsTruncated</c> in the response is <c>true</c>, and the
        /// value of <c>TrafficPolicyIdMarker</c> is the ID of the first traffic policy that Route
        /// 53 will return if you submit another request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? MaxItem { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyIdMarker
        /// <summary>
        /// <para>
        /// <para>(Conditional) For your first request to <c>ListTrafficPolicies</c>, don't include
        /// the <c>TrafficPolicyIdMarker</c> parameter.</para><para>If you have more traffic policies than the value of <c>MaxItems</c>, <c>ListTrafficPolicies</c>
        /// returns only the first <c>MaxItems</c> traffic policies. To get the next group of
        /// policies, submit another request to <c>ListTrafficPolicies</c>. For the value of <c>TrafficPolicyIdMarker</c>,
        /// specify the value of <c>TrafficPolicyIdMarker</c> that was returned in the previous
        /// response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'TrafficPolicyIdMarker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-TrafficPolicyIdMarker' to null for the first call then set the 'TrafficPolicyIdMarker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String TrafficPolicyIdMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficPolicySummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListTrafficPoliciesResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListTrafficPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficPolicySummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of TrafficPolicyIdMarker
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListTrafficPoliciesResponse, GetR53TrafficPolicyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TrafficPolicyIdMarker = this.TrafficPolicyIdMarker;
            context.MaxItem = this.MaxItem;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxItem)))
            {
                WriteVerbose("MaxItem parameter unset, using default value of '100'");
                context.MaxItem = 100;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxItem)) && this.MaxItem.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxItem parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxItem" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            
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
            var request = new Amazon.Route53.Model.ListTrafficPoliciesRequest();
            
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeString(cmdletContext.MaxItem.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.TrafficPolicyIdMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.TrafficPolicyIdMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.TrafficPolicyIdMarker = _nextToken;
                
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
                    
                    _nextToken = response.TrafficPolicyIdMarker;
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
            var request = new Amazon.Route53.Model.ListTrafficPoliciesRequest();
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyIdMarker))
            {
                _nextToken = cmdletContext.TrafficPolicyIdMarker;
            }
            if (cmdletContext.MaxItem.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxItem;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.TrafficPolicyIdMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.TrafficPolicyIdMarker = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxItem)))
                {
                    request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToString(100);
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
                    int _receivedThisCall = response.TrafficPolicySummaries?.Count ?? 0;
                    
                    _nextToken = response.TrafficPolicyIdMarker;
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
        
        private Amazon.Route53.Model.ListTrafficPoliciesResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListTrafficPolicies");
            try
            {
                return client.ListTrafficPoliciesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TrafficPolicyIdMarker { get; set; }
            public int? MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListTrafficPoliciesResponse, GetR53TrafficPolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficPolicySummaries;
        }
        
    }
}
