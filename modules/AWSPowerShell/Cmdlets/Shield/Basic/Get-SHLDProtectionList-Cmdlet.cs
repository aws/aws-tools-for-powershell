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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Retrieves <a>Protection</a> objects for the account. You can retrieve all protections
    /// or you can provide filtering criteria and retrieve just the subset of protections
    /// that match the criteria.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHLDProtectionList")]
    [OutputType("Amazon.Shield.Model.Protection")]
    [AWSCmdlet("Calls the AWS Shield ListProtections API operation.", Operation = new[] {"ListProtections"}, SelectReturnType = typeof(Amazon.Shield.Model.ListProtectionsResponse))]
    [AWSCmdletOutput("Amazon.Shield.Model.Protection or Amazon.Shield.Model.ListProtectionsResponse",
        "This cmdlet returns a collection of Amazon.Shield.Model.Protection objects.",
        "The service call response (type Amazon.Shield.Model.ListProtectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHLDProtectionListCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InclusionFilters_ProtectionName
        /// <summary>
        /// <para>
        /// <para>The name of the protection that you want to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_ProtectionNames")]
        public System.String[] InclusionFilters_ProtectionName { get; set; }
        #endregion
        
        #region Parameter InclusionFilters_ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the resource whose protection you want to retrieve.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_ResourceArns")]
        public System.String[] InclusionFilters_ResourceArn { get; set; }
        #endregion
        
        #region Parameter InclusionFilters_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of protected resource whose protections you want to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters_ResourceTypes")]
        public System.String[] InclusionFilters_ResourceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The greatest number of objects that you want Shield Advanced to return to the list
        /// request. Shield Advanced might return fewer objects than you indicate in this setting,
        /// even if more objects are available. If there are more objects remaining, Shield Advanced
        /// will always also return a <c>NextToken</c> value in the response.</para><para>The default setting is 20.</para>
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
        /// <para>When you request a list of objects from Shield Advanced, if the response does not
        /// include all of the remaining available objects, Shield Advanced includes a <c>NextToken</c>
        /// value in the response. You can retrieve the next batch of objects by requesting the
        /// list again and providing the token that was returned by the prior call in your request.
        /// </para><para>You can indicate the maximum number of objects that you want Shield Advanced to return
        /// for a single call with the <c>MaxResults</c> setting. Shield Advanced will not return
        /// more than <c>MaxResults</c> objects, but may return fewer, even if more objects are
        /// still available.</para><para>Whenever more objects remain that Shield Advanced has not yet returned to you, the
        /// response will include a <c>NextToken</c> value.</para><para>On your first call to a list operation, leave this setting empty.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Protections'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.ListProtectionsResponse).
        /// Specifying the name of a property of type Amazon.Shield.Model.ListProtectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Protections";
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
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.ListProtectionsResponse, GetSHLDProtectionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.InclusionFilters_ProtectionName != null)
            {
                context.InclusionFilters_ProtectionName = new List<System.String>(this.InclusionFilters_ProtectionName);
            }
            if (this.InclusionFilters_ResourceArn != null)
            {
                context.InclusionFilters_ResourceArn = new List<System.String>(this.InclusionFilters_ResourceArn);
            }
            if (this.InclusionFilters_ResourceType != null)
            {
                context.InclusionFilters_ResourceType = new List<System.String>(this.InclusionFilters_ResourceType);
            }
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
            var request = new Amazon.Shield.Model.ListProtectionsRequest();
            
            
             // populate InclusionFilters
            var requestInclusionFiltersIsNull = true;
            request.InclusionFilters = new Amazon.Shield.Model.InclusionProtectionFilters();
            List<System.String> requestInclusionFilters_inclusionFilters_ProtectionName = null;
            if (cmdletContext.InclusionFilters_ProtectionName != null)
            {
                requestInclusionFilters_inclusionFilters_ProtectionName = cmdletContext.InclusionFilters_ProtectionName;
            }
            if (requestInclusionFilters_inclusionFilters_ProtectionName != null)
            {
                request.InclusionFilters.ProtectionNames = requestInclusionFilters_inclusionFilters_ProtectionName;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_ResourceArn = null;
            if (cmdletContext.InclusionFilters_ResourceArn != null)
            {
                requestInclusionFilters_inclusionFilters_ResourceArn = cmdletContext.InclusionFilters_ResourceArn;
            }
            if (requestInclusionFilters_inclusionFilters_ResourceArn != null)
            {
                request.InclusionFilters.ResourceArns = requestInclusionFilters_inclusionFilters_ResourceArn;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_ResourceType = null;
            if (cmdletContext.InclusionFilters_ResourceType != null)
            {
                requestInclusionFilters_inclusionFilters_ResourceType = cmdletContext.InclusionFilters_ResourceType;
            }
            if (requestInclusionFilters_inclusionFilters_ResourceType != null)
            {
                request.InclusionFilters.ResourceTypes = requestInclusionFilters_inclusionFilters_ResourceType;
                requestInclusionFiltersIsNull = false;
            }
             // determine if request.InclusionFilters should be set to null
            if (requestInclusionFiltersIsNull)
            {
                request.InclusionFilters = null;
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
            var request = new Amazon.Shield.Model.ListProtectionsRequest();
            
             // populate InclusionFilters
            var requestInclusionFiltersIsNull = true;
            request.InclusionFilters = new Amazon.Shield.Model.InclusionProtectionFilters();
            List<System.String> requestInclusionFilters_inclusionFilters_ProtectionName = null;
            if (cmdletContext.InclusionFilters_ProtectionName != null)
            {
                requestInclusionFilters_inclusionFilters_ProtectionName = cmdletContext.InclusionFilters_ProtectionName;
            }
            if (requestInclusionFilters_inclusionFilters_ProtectionName != null)
            {
                request.InclusionFilters.ProtectionNames = requestInclusionFilters_inclusionFilters_ProtectionName;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_ResourceArn = null;
            if (cmdletContext.InclusionFilters_ResourceArn != null)
            {
                requestInclusionFilters_inclusionFilters_ResourceArn = cmdletContext.InclusionFilters_ResourceArn;
            }
            if (requestInclusionFilters_inclusionFilters_ResourceArn != null)
            {
                request.InclusionFilters.ResourceArns = requestInclusionFilters_inclusionFilters_ResourceArn;
                requestInclusionFiltersIsNull = false;
            }
            List<System.String> requestInclusionFilters_inclusionFilters_ResourceType = null;
            if (cmdletContext.InclusionFilters_ResourceType != null)
            {
                requestInclusionFilters_inclusionFilters_ResourceType = cmdletContext.InclusionFilters_ResourceType;
            }
            if (requestInclusionFilters_inclusionFilters_ResourceType != null)
            {
                request.InclusionFilters.ResourceTypes = requestInclusionFilters_inclusionFilters_ResourceType;
                requestInclusionFiltersIsNull = false;
            }
             // determine if request.InclusionFilters should be set to null
            if (requestInclusionFiltersIsNull)
            {
                request.InclusionFilters = null;
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
                // The service has a maximum page size of 10000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 10000 items back. If a page size is set, that will
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
                    int correctPageSize = Math.Min(10000, _emitLimit.Value);
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
                    int _receivedThisCall = response.Protections?.Count ?? 0;
                    
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
        
        private Amazon.Shield.Model.ListProtectionsResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.ListProtectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "ListProtections");
            try
            {
                return client.ListProtectionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> InclusionFilters_ProtectionName { get; set; }
            public List<System.String> InclusionFilters_ResourceArn { get; set; }
            public List<System.String> InclusionFilters_ResourceType { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Shield.Model.ListProtectionsResponse, GetSHLDProtectionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Protections;
        }
        
    }
}
