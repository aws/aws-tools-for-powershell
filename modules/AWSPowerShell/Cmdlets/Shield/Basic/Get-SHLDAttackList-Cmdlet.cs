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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Returns all ongoing DDoS attacks or all DDoS attacks during a specified time period.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SHLDAttackList")]
    [OutputType("Amazon.Shield.Model.AttackSummary")]
    [AWSCmdlet("Calls the AWS Shield ListAttacks API operation.", Operation = new[] {"ListAttacks"}, SelectReturnType = typeof(Amazon.Shield.Model.ListAttacksResponse))]
    [AWSCmdletOutput("Amazon.Shield.Model.AttackSummary or Amazon.Shield.Model.ListAttacksResponse",
        "This cmdlet returns a collection of Amazon.Shield.Model.AttackSummary objects.",
        "The service call response (type Amazon.Shield.Model.ListAttacksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSHLDAttackListCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime_FromInclusive
        /// <summary>
        /// <para>
        /// <para>The start time, in Unix time in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime_FromInclusive { get; set; }
        #endregion
        
        #region Parameter StartTime_FromInclusive
        /// <summary>
        /// <para>
        /// <para>The start time, in Unix time in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime_FromInclusive { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARNs (Amazon Resource Names) of the resources that were attacked. If you leave
        /// this blank, all applicable resources for this account will be included.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceArns")]
        public System.String[] ResourceArn { get; set; }
        #endregion
        
        #region Parameter EndTime_ToExclusive
        /// <summary>
        /// <para>
        /// <para>The end time, in Unix time in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime_ToExclusive { get; set; }
        #endregion
        
        #region Parameter StartTime_ToExclusive
        /// <summary>
        /// <para>
        /// <para>The end time, in Unix time in seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime_ToExclusive { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AttackSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.ListAttacksResponse).
        /// Specifying the name of a property of type Amazon.Shield.Model.ListAttacksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AttackSummaries";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.ListAttacksResponse, GetSHLDAttackListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime_FromInclusive = this.EndTime_FromInclusive;
            context.EndTime_ToExclusive = this.EndTime_ToExclusive;
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
            if (this.ResourceArn != null)
            {
                context.ResourceArn = new List<System.String>(this.ResourceArn);
            }
            context.StartTime_FromInclusive = this.StartTime_FromInclusive;
            context.StartTime_ToExclusive = this.StartTime_ToExclusive;
            
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
            var request = new Amazon.Shield.Model.ListAttacksRequest();
            
            
             // populate EndTime
            var requestEndTimeIsNull = true;
            request.EndTime = new Amazon.Shield.Model.TimeRange();
            System.DateTime? requestEndTime_endTime_FromInclusive = null;
            if (cmdletContext.EndTime_FromInclusive != null)
            {
                requestEndTime_endTime_FromInclusive = cmdletContext.EndTime_FromInclusive.Value;
            }
            if (requestEndTime_endTime_FromInclusive != null)
            {
                request.EndTime.FromInclusive = requestEndTime_endTime_FromInclusive.Value;
                requestEndTimeIsNull = false;
            }
            System.DateTime? requestEndTime_endTime_ToExclusive = null;
            if (cmdletContext.EndTime_ToExclusive != null)
            {
                requestEndTime_endTime_ToExclusive = cmdletContext.EndTime_ToExclusive.Value;
            }
            if (requestEndTime_endTime_ToExclusive != null)
            {
                request.EndTime.ToExclusive = requestEndTime_endTime_ToExclusive.Value;
                requestEndTimeIsNull = false;
            }
             // determine if request.EndTime should be set to null
            if (requestEndTimeIsNull)
            {
                request.EndTime = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            
             // populate StartTime
            var requestStartTimeIsNull = true;
            request.StartTime = new Amazon.Shield.Model.TimeRange();
            System.DateTime? requestStartTime_startTime_FromInclusive = null;
            if (cmdletContext.StartTime_FromInclusive != null)
            {
                requestStartTime_startTime_FromInclusive = cmdletContext.StartTime_FromInclusive.Value;
            }
            if (requestStartTime_startTime_FromInclusive != null)
            {
                request.StartTime.FromInclusive = requestStartTime_startTime_FromInclusive.Value;
                requestStartTimeIsNull = false;
            }
            System.DateTime? requestStartTime_startTime_ToExclusive = null;
            if (cmdletContext.StartTime_ToExclusive != null)
            {
                requestStartTime_startTime_ToExclusive = cmdletContext.StartTime_ToExclusive.Value;
            }
            if (requestStartTime_startTime_ToExclusive != null)
            {
                request.StartTime.ToExclusive = requestStartTime_startTime_ToExclusive.Value;
                requestStartTimeIsNull = false;
            }
             // determine if request.StartTime should be set to null
            if (requestStartTimeIsNull)
            {
                request.StartTime = null;
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
            var request = new Amazon.Shield.Model.ListAttacksRequest();
            
             // populate EndTime
            var requestEndTimeIsNull = true;
            request.EndTime = new Amazon.Shield.Model.TimeRange();
            System.DateTime? requestEndTime_endTime_FromInclusive = null;
            if (cmdletContext.EndTime_FromInclusive != null)
            {
                requestEndTime_endTime_FromInclusive = cmdletContext.EndTime_FromInclusive.Value;
            }
            if (requestEndTime_endTime_FromInclusive != null)
            {
                request.EndTime.FromInclusive = requestEndTime_endTime_FromInclusive.Value;
                requestEndTimeIsNull = false;
            }
            System.DateTime? requestEndTime_endTime_ToExclusive = null;
            if (cmdletContext.EndTime_ToExclusive != null)
            {
                requestEndTime_endTime_ToExclusive = cmdletContext.EndTime_ToExclusive.Value;
            }
            if (requestEndTime_endTime_ToExclusive != null)
            {
                request.EndTime.ToExclusive = requestEndTime_endTime_ToExclusive.Value;
                requestEndTimeIsNull = false;
            }
             // determine if request.EndTime should be set to null
            if (requestEndTimeIsNull)
            {
                request.EndTime = null;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArns = cmdletContext.ResourceArn;
            }
            
             // populate StartTime
            var requestStartTimeIsNull = true;
            request.StartTime = new Amazon.Shield.Model.TimeRange();
            System.DateTime? requestStartTime_startTime_FromInclusive = null;
            if (cmdletContext.StartTime_FromInclusive != null)
            {
                requestStartTime_startTime_FromInclusive = cmdletContext.StartTime_FromInclusive.Value;
            }
            if (requestStartTime_startTime_FromInclusive != null)
            {
                request.StartTime.FromInclusive = requestStartTime_startTime_FromInclusive.Value;
                requestStartTimeIsNull = false;
            }
            System.DateTime? requestStartTime_startTime_ToExclusive = null;
            if (cmdletContext.StartTime_ToExclusive != null)
            {
                requestStartTime_startTime_ToExclusive = cmdletContext.StartTime_ToExclusive.Value;
            }
            if (requestStartTime_startTime_ToExclusive != null)
            {
                request.StartTime.ToExclusive = requestStartTime_startTime_ToExclusive.Value;
                requestStartTimeIsNull = false;
            }
             // determine if request.StartTime should be set to null
            if (requestStartTimeIsNull)
            {
                request.StartTime = null;
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
                    int _receivedThisCall = response.AttackSummaries?.Count ?? 0;
                    
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
        
        private Amazon.Shield.Model.ListAttacksResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.ListAttacksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "ListAttacks");
            try
            {
                return client.ListAttacksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime_FromInclusive { get; set; }
            public System.DateTime? EndTime_ToExclusive { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> ResourceArn { get; set; }
            public System.DateTime? StartTime_FromInclusive { get; set; }
            public System.DateTime? StartTime_ToExclusive { get; set; }
            public System.Func<Amazon.Shield.Model.ListAttacksResponse, GetSHLDAttackListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AttackSummaries;
        }
        
    }
}
