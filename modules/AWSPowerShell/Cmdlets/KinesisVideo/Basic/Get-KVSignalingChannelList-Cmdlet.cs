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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Returns an array of <c>ChannelInfo</c> objects. Each object describes a signaling
    /// channel. To retrieve only those channels that satisfy a specific condition, you can
    /// specify a <c>ChannelNameCondition</c>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KVSignalingChannelList")]
    [OutputType("Amazon.KinesisVideo.Model.ChannelInfo")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams ListSignalingChannels API operation.", Operation = new[] {"ListSignalingChannels"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.ListSignalingChannelsResponse))]
    [AWSCmdletOutput("Amazon.KinesisVideo.Model.ChannelInfo or Amazon.KinesisVideo.Model.ListSignalingChannelsResponse",
        "This cmdlet returns a collection of Amazon.KinesisVideo.Model.ChannelInfo objects.",
        "The service call response (type Amazon.KinesisVideo.Model.ListSignalingChannelsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKVSignalingChannelListCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelNameCondition_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>A comparison operator. Currently, you can only specify the <c>BEGINS_WITH</c> operator,
        /// which finds signaling channels whose names begin with a given prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.ComparisonOperator")]
        public Amazon.KinesisVideo.ComparisonOperator ChannelNameCondition_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter ChannelNameCondition_ComparisonValue
        /// <summary>
        /// <para>
        /// <para>A value to compare.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelNameCondition_ComparisonValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of channels to return in the response. The default is 500.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>10000</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If you specify this parameter, when the result of a <c>ListSignalingChannels</c> operation
        /// is truncated, the call returns the <c>NextToken</c> in the response. To get another
        /// batch of channels, provide this token in your next request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelInfoList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.ListSignalingChannelsResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.ListSignalingChannelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelInfoList";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.ListSignalingChannelsResponse, GetKVSignalingChannelListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelNameCondition_ComparisonOperator = this.ChannelNameCondition_ComparisonOperator;
            context.ChannelNameCondition_ComparisonValue = this.ChannelNameCondition_ComparisonValue;
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '10000'");
                context.MaxResult = 10000;
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
            var request = new Amazon.KinesisVideo.Model.ListSignalingChannelsRequest();
            
            
             // populate ChannelNameCondition
            var requestChannelNameConditionIsNull = true;
            request.ChannelNameCondition = new Amazon.KinesisVideo.Model.ChannelNameCondition();
            Amazon.KinesisVideo.ComparisonOperator requestChannelNameCondition_channelNameCondition_ComparisonOperator = null;
            if (cmdletContext.ChannelNameCondition_ComparisonOperator != null)
            {
                requestChannelNameCondition_channelNameCondition_ComparisonOperator = cmdletContext.ChannelNameCondition_ComparisonOperator;
            }
            if (requestChannelNameCondition_channelNameCondition_ComparisonOperator != null)
            {
                request.ChannelNameCondition.ComparisonOperator = requestChannelNameCondition_channelNameCondition_ComparisonOperator;
                requestChannelNameConditionIsNull = false;
            }
            System.String requestChannelNameCondition_channelNameCondition_ComparisonValue = null;
            if (cmdletContext.ChannelNameCondition_ComparisonValue != null)
            {
                requestChannelNameCondition_channelNameCondition_ComparisonValue = cmdletContext.ChannelNameCondition_ComparisonValue;
            }
            if (requestChannelNameCondition_channelNameCondition_ComparisonValue != null)
            {
                request.ChannelNameCondition.ComparisonValue = requestChannelNameCondition_channelNameCondition_ComparisonValue;
                requestChannelNameConditionIsNull = false;
            }
             // determine if request.ChannelNameCondition should be set to null
            if (requestChannelNameConditionIsNull)
            {
                request.ChannelNameCondition = null;
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
            var request = new Amazon.KinesisVideo.Model.ListSignalingChannelsRequest();
            
             // populate ChannelNameCondition
            var requestChannelNameConditionIsNull = true;
            request.ChannelNameCondition = new Amazon.KinesisVideo.Model.ChannelNameCondition();
            Amazon.KinesisVideo.ComparisonOperator requestChannelNameCondition_channelNameCondition_ComparisonOperator = null;
            if (cmdletContext.ChannelNameCondition_ComparisonOperator != null)
            {
                requestChannelNameCondition_channelNameCondition_ComparisonOperator = cmdletContext.ChannelNameCondition_ComparisonOperator;
            }
            if (requestChannelNameCondition_channelNameCondition_ComparisonOperator != null)
            {
                request.ChannelNameCondition.ComparisonOperator = requestChannelNameCondition_channelNameCondition_ComparisonOperator;
                requestChannelNameConditionIsNull = false;
            }
            System.String requestChannelNameCondition_channelNameCondition_ComparisonValue = null;
            if (cmdletContext.ChannelNameCondition_ComparisonValue != null)
            {
                requestChannelNameCondition_channelNameCondition_ComparisonValue = cmdletContext.ChannelNameCondition_ComparisonValue;
            }
            if (requestChannelNameCondition_channelNameCondition_ComparisonValue != null)
            {
                request.ChannelNameCondition.ComparisonValue = requestChannelNameCondition_channelNameCondition_ComparisonValue;
                requestChannelNameConditionIsNull = false;
            }
             // determine if request.ChannelNameCondition should be set to null
            if (requestChannelNameConditionIsNull)
            {
                request.ChannelNameCondition = null;
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
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(10000);
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
                    int _receivedThisCall = response.ChannelInfoList.Count;
                    
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
        
        private Amazon.KinesisVideo.Model.ListSignalingChannelsResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.ListSignalingChannelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "ListSignalingChannels");
            try
            {
                #if DESKTOP
                return client.ListSignalingChannels(request);
                #elif CORECLR
                return client.ListSignalingChannelsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisVideo.ComparisonOperator ChannelNameCondition_ComparisonOperator { get; set; }
            public System.String ChannelNameCondition_ComparisonValue { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.ListSignalingChannelsResponse, GetKVSignalingChannelListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelInfoList;
        }
        
    }
}
