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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Lists the shards in a stream and provides information about each shard. This operation
    /// has a limit of 1000 transactions per second per data stream.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// This action does not list expired shards. For information about expired shards, see
    /// <a href="https://docs.aws.amazon.com/streams/latest/dev/kinesis-using-sdk-java-after-resharding.html#kinesis-using-sdk-java-resharding-data-routing">Data
    /// Routing, Data Persistence, and Shard State after a Reshard</a>. 
    /// </para><important><para>
    /// This API is a new operation that is used by the Amazon Kinesis Client Library (KCL).
    /// If you have a fine-grained IAM policy that only allows specific operations, you must
    /// update your policy to allow calls to this API. For more information, see <a href="https://docs.aws.amazon.com/streams/latest/dev/controlling-access.html">Controlling
    /// Access to Amazon Kinesis Data Streams Resources Using IAM</a>.
    /// </para></important><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KINShardList")]
    [OutputType("Amazon.Kinesis.Model.Shard")]
    [AWSCmdlet("Calls the Amazon Kinesis ListShards API operation.", Operation = new[] {"ListShards"}, SelectReturnType = typeof(Amazon.Kinesis.Model.ListShardsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.Shard or Amazon.Kinesis.Model.ListShardsResponse",
        "This cmdlet returns a collection of Amazon.Kinesis.Model.Shard objects.",
        "The service call response (type Amazon.Kinesis.Model.ListShardsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINShardListCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExclusiveStartShardId
        /// <summary>
        /// <para>
        /// <para>Specify this parameter to indicate that you want to list the shards starting with
        /// the shard whose ID immediately follows <c>ExclusiveStartShardId</c>.</para><para>If you don't specify this parameter, the default behavior is for <c>ListShards</c>
        /// to list the shards starting with the first one in the stream.</para><para>You cannot specify this parameter if you specify <c>NextToken</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartShardId { get; set; }
        #endregion
        
        #region Parameter ShardFilter_ShardId
        /// <summary>
        /// <para>
        /// <para>The exclusive start <c>shardID</c> speified in the <c>ShardFilter</c> parameter. This
        /// property can only be used if the <c>AFTER_SHARD_ID</c> shard type is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShardFilter_ShardId { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamCreationTimestamp
        /// <summary>
        /// <para>
        /// <para>Specify this input parameter to distinguish data streams that have the same name.
        /// For example, if you create a data stream and then delete it, and you later create
        /// another data stream with the same name, you can use this input parameter to specify
        /// which of the two streams you want to list the shards for.</para><para>You cannot specify this parameter if you specify the <c>NextToken</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StreamCreationTimestamp { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the data stream whose shards you want to list. </para><para>You cannot specify this parameter if you specify the <c>NextToken</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter ShardFilter_Timestamp
        /// <summary>
        /// <para>
        /// <para>The timestamps specified in the <c>ShardFilter</c> parameter. A timestamp is a Unix
        /// epoch date with precision in milliseconds. For example, 2016-04-04T19:58:46.480-00:00
        /// or 1459799926.480. This property can only be used if <c>FROM_TIMESTAMP</c> or <c>AT_TIMESTAMP</c>
        /// shard types are specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ShardFilter_Timestamp { get; set; }
        #endregion
        
        #region Parameter ShardFilter_Type
        /// <summary>
        /// <para>
        /// <para>The shard type specified in the <c>ShardFilter</c> parameter. This is a required property
        /// of the <c>ShardFilter</c> parameter.</para><para>You can specify the following valid values: </para><ul><li><para><c>AFTER_SHARD_ID</c> - the response includes all the shards, starting with the shard
        /// whose ID immediately follows the <c>ShardId</c> that you provided. </para></li><li><para><c>AT_TRIM_HORIZON</c> - the response includes all the shards that were open at <c>TRIM_HORIZON</c>.</para></li><li><para><c>FROM_TRIM_HORIZON</c> - (default), the response includes all the shards within
        /// the retention period of the data stream (trim to tip).</para></li><li><para><c>AT_LATEST</c> - the response includes only the currently open shards of the data
        /// stream.</para></li><li><para><c>AT_TIMESTAMP</c> - the response includes all shards whose start timestamp is less
        /// than or equal to the given timestamp and end timestamp is greater than or equal to
        /// the given timestamp or still open. </para></li><li><para><c>FROM_TIMESTAMP</c> - the response incldues all closed shards whose end timestamp
        /// is greater than or equal to the given timestamp and also all open shards. Corrected
        /// to <c>TRIM_HORIZON</c> of the data stream if <c>FROM_TIMESTAMP</c> is less than the
        /// <c>TRIM_HORIZON</c> value.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kinesis.ShardFilterType")]
        public Amazon.Kinesis.ShardFilterType ShardFilter_Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of shards to return in a single call to <c>ListShards</c>. The
        /// maximum number of shards to return in a single call. The default value is 1000. If
        /// you specify a value greater than 1000, at most 1000 results are returned. </para><para>When the number of shards to be listed is greater than the value of <c>MaxResults</c>,
        /// the response contains a <c>NextToken</c> value that you can use in a subsequent call
        /// to <c>ListShards</c> to list the next set of shards.</para>
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
        /// <para>When the number of shards in the data stream is greater than the default value for
        /// the <c>MaxResults</c> parameter, or if you explicitly specify a value for <c>MaxResults</c>
        /// that is less than the number of shards in the data stream, the response includes a
        /// pagination token named <c>NextToken</c>. You can specify this <c>NextToken</c> value
        /// in a subsequent call to <c>ListShards</c> to list the next set of shards.</para><para>Don't specify <c>StreamName</c> or <c>StreamCreationTimestamp</c> if you specify <c>NextToken</c>
        /// because the latter unambiguously identifies the stream.</para><para>You can optionally specify a value for the <c>MaxResults</c> parameter when you specify
        /// <c>NextToken</c>. If you specify a <c>MaxResults</c> value that is less than the number
        /// of shards that the operation returns if you don't specify <c>MaxResults</c>, the response
        /// will contain a new <c>NextToken</c> value. You can use the new <c>NextToken</c> value
        /// in a subsequent call to the <c>ListShards</c> operation.</para><important><para>Tokens expire after 300 seconds. When you obtain a value for <c>NextToken</c> in the
        /// response to a call to <c>ListShards</c>, you have 300 seconds to use that value. If
        /// you specify an expired token in a call to <c>ListShards</c>, you get <c>ExpiredNextTokenException</c>.</para></important>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Shards'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.ListShardsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.ListShardsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Shards";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.ListShardsResponse, GetKINShardListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExclusiveStartShardId = this.ExclusiveStartShardId;
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
            context.ShardFilter_ShardId = this.ShardFilter_ShardId;
            context.ShardFilter_Timestamp = this.ShardFilter_Timestamp;
            context.ShardFilter_Type = this.ShardFilter_Type;
            context.StreamARN = this.StreamARN;
            context.StreamCreationTimestamp = this.StreamCreationTimestamp;
            context.StreamName = this.StreamName;
            
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Kinesis.Model.ListShardsRequest();
            
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate ShardFilter
            var requestShardFilterIsNull = true;
            request.ShardFilter = new Amazon.Kinesis.Model.ShardFilter();
            System.String requestShardFilter_shardFilter_ShardId = null;
            if (cmdletContext.ShardFilter_ShardId != null)
            {
                requestShardFilter_shardFilter_ShardId = cmdletContext.ShardFilter_ShardId;
            }
            if (requestShardFilter_shardFilter_ShardId != null)
            {
                request.ShardFilter.ShardId = requestShardFilter_shardFilter_ShardId;
                requestShardFilterIsNull = false;
            }
            System.DateTime? requestShardFilter_shardFilter_Timestamp = null;
            if (cmdletContext.ShardFilter_Timestamp != null)
            {
                requestShardFilter_shardFilter_Timestamp = cmdletContext.ShardFilter_Timestamp.Value;
            }
            if (requestShardFilter_shardFilter_Timestamp != null)
            {
                request.ShardFilter.Timestamp = requestShardFilter_shardFilter_Timestamp.Value;
                requestShardFilterIsNull = false;
            }
            Amazon.Kinesis.ShardFilterType requestShardFilter_shardFilter_Type = null;
            if (cmdletContext.ShardFilter_Type != null)
            {
                requestShardFilter_shardFilter_Type = cmdletContext.ShardFilter_Type;
            }
            if (requestShardFilter_shardFilter_Type != null)
            {
                request.ShardFilter.Type = requestShardFilter_shardFilter_Type;
                requestShardFilterIsNull = false;
            }
             // determine if request.ShardFilter should be set to null
            if (requestShardFilterIsNull)
            {
                request.ShardFilter = null;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamCreationTimestamp != null)
            {
                request.StreamCreationTimestamp = cmdletContext.StreamCreationTimestamp.Value;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.Kinesis.Model.ListShardsRequest();
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
            }
            
             // populate ShardFilter
            var requestShardFilterIsNull = true;
            request.ShardFilter = new Amazon.Kinesis.Model.ShardFilter();
            System.String requestShardFilter_shardFilter_ShardId = null;
            if (cmdletContext.ShardFilter_ShardId != null)
            {
                requestShardFilter_shardFilter_ShardId = cmdletContext.ShardFilter_ShardId;
            }
            if (requestShardFilter_shardFilter_ShardId != null)
            {
                request.ShardFilter.ShardId = requestShardFilter_shardFilter_ShardId;
                requestShardFilterIsNull = false;
            }
            System.DateTime? requestShardFilter_shardFilter_Timestamp = null;
            if (cmdletContext.ShardFilter_Timestamp != null)
            {
                requestShardFilter_shardFilter_Timestamp = cmdletContext.ShardFilter_Timestamp.Value;
            }
            if (requestShardFilter_shardFilter_Timestamp != null)
            {
                request.ShardFilter.Timestamp = requestShardFilter_shardFilter_Timestamp.Value;
                requestShardFilterIsNull = false;
            }
            Amazon.Kinesis.ShardFilterType requestShardFilter_shardFilter_Type = null;
            if (cmdletContext.ShardFilter_Type != null)
            {
                requestShardFilter_shardFilter_Type = cmdletContext.ShardFilter_Type;
            }
            if (requestShardFilter_shardFilter_Type != null)
            {
                request.ShardFilter.Type = requestShardFilter_shardFilter_Type;
                requestShardFilterIsNull = false;
            }
             // determine if request.ShardFilter should be set to null
            if (requestShardFilterIsNull)
            {
                request.ShardFilter = null;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamCreationTimestamp != null)
            {
                request.StreamCreationTimestamp = cmdletContext.StreamCreationTimestamp.Value;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
                    int _receivedThisCall = response.Shards.Count;
                    
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
        
        private Amazon.Kinesis.Model.ListShardsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.ListShardsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "ListShards");
            try
            {
                #if DESKTOP
                return client.ListShards(request);
                #elif CORECLR
                return client.ListShardsAsync(request).GetAwaiter().GetResult();
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
            public System.String ExclusiveStartShardId { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ShardFilter_ShardId { get; set; }
            public System.DateTime? ShardFilter_Timestamp { get; set; }
            public Amazon.Kinesis.ShardFilterType ShardFilter_Type { get; set; }
            public System.String StreamARN { get; set; }
            public System.DateTime? StreamCreationTimestamp { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.ListShardsResponse, GetKINShardListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Shards;
        }
        
    }
}
