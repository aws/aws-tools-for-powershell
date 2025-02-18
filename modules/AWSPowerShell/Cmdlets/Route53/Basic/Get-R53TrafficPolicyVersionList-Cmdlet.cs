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
    /// Gets information about all of the versions for a specified traffic policy.
    /// 
    ///  
    /// <para>
    /// Traffic policy versions are listed in numerical order by <c>VersionNumber</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyVersionList")]
    [OutputType("Amazon.Route53.Model.TrafficPolicy")]
    [AWSCmdlet("Calls the Amazon Route 53 ListTrafficPolicyVersions API operation.", Operation = new[] {"ListTrafficPolicyVersions"}, SelectReturnType = typeof(Amazon.Route53.Model.ListTrafficPolicyVersionsResponse), LegacyAlias="Get-R53TrafficPolicyVersions")]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicy or Amazon.Route53.Model.ListTrafficPolicyVersionsResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.TrafficPolicy objects.",
        "The service call response (type Amazon.Route53.Model.ListTrafficPolicyVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53TrafficPolicyVersionListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>Specify the value of <c>Id</c> of the traffic policy for which you want to list all
        /// versions.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of traffic policy versions that you want Amazon Route 53 to include
        /// in the response body for this request. If the specified traffic policy has more than
        /// <c>MaxItems</c> versions, the value of <c>IsTruncated</c> in the response is <c>true</c>,
        /// and the value of the <c>TrafficPolicyVersionMarker</c> element is the ID of the first
        /// version that Route 53 will return if you submit another request.</para>
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
        
        #region Parameter TrafficPolicyVersionMarker
        /// <summary>
        /// <para>
        /// <para>For your first request to <c>ListTrafficPolicyVersions</c>, don't include the <c>TrafficPolicyVersionMarker</c>
        /// parameter.</para><para>If you have more traffic policy versions than the value of <c>MaxItems</c>, <c>ListTrafficPolicyVersions</c>
        /// returns only the first group of <c>MaxItems</c> versions. To get more traffic policy
        /// versions, submit another <c>ListTrafficPolicyVersions</c> request. For the value of
        /// <c>TrafficPolicyVersionMarker</c>, specify the value of <c>TrafficPolicyVersionMarker</c>
        /// in the previous response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'TrafficPolicyVersionMarker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-TrafficPolicyVersionMarker' to null for the first call then set the 'TrafficPolicyVersionMarker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String TrafficPolicyVersionMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficPolicies'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListTrafficPolicyVersionsResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListTrafficPolicyVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficPolicies";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of TrafficPolicyVersionMarker
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListTrafficPolicyVersionsResponse, GetR53TrafficPolicyVersionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficPolicyVersionMarker = this.TrafficPolicyVersionMarker;
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
            var request = new Amazon.Route53.Model.ListTrafficPolicyVersionsRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeString(cmdletContext.MaxItem.Value);
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.TrafficPolicyVersionMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.TrafficPolicyVersionMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.TrafficPolicyVersionMarker = _nextToken;
                
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
                    
                    _nextToken = response.TrafficPolicyVersionMarker;
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
            var request = new Amazon.Route53.Model.ListTrafficPolicyVersionsRequest();
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.TrafficPolicyVersionMarker))
            {
                _nextToken = cmdletContext.TrafficPolicyVersionMarker;
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
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.TrafficPolicyVersionMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.TrafficPolicyVersionMarker = _nextToken;
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
                    int _receivedThisCall = response.TrafficPolicies?.Count ?? 0;
                    
                    _nextToken = response.TrafficPolicyVersionMarker;
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
        
        private Amazon.Route53.Model.ListTrafficPolicyVersionsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListTrafficPolicyVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListTrafficPolicyVersions");
            try
            {
                return client.ListTrafficPolicyVersionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String TrafficPolicyVersionMarker { get; set; }
            public int? MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListTrafficPolicyVersionsResponse, GetR53TrafficPolicyVersionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficPolicies;
        }
        
    }
}
