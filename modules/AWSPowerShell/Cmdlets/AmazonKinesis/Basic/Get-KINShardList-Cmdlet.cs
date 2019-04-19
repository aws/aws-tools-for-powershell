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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Lists the shards in a stream and provides information about each shard. This operation
    /// has a limit of 100 transactions per second per data stream.
    /// 
    ///  <important><para>
    /// This API is a new operation that is used by the Amazon Kinesis Client Library (KCL).
    /// If you have a fine-grained IAM policy that only allows specific operations, you must
    /// update your policy to allow calls to this API. For more information, see <a href="https://docs.aws.amazon.com/streams/latest/dev/controlling-access.html">Controlling
    /// Access to Amazon Kinesis Data Streams Resources Using IAM</a>.
    /// </para></important><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "KINShardList")]
    [OutputType("Amazon.Kinesis.Model.Shard")]
    [AWSCmdlet("Calls the Amazon Kinesis ListShards API operation.", Operation = new[] {"ListShards"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.Shard",
        "This cmdlet returns a collection of Shard objects.",
        "The service call response (type Amazon.Kinesis.Model.ListShardsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetKINShardListCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartShardId
        /// <summary>
        /// <para>
        /// <para>Specify this parameter to indicate that you want to list the shards starting with
        /// the shard whose ID immediately follows <code>ExclusiveStartShardId</code>.</para><para>If you don't specify this parameter, the default behavior is for <code>ListShards</code>
        /// to list the shards starting with the first one in the stream.</para><para>You cannot specify this parameter if you specify <code>NextToken</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartShardId { get; set; }
        #endregion
        
        #region Parameter StreamCreationTimestamp
        /// <summary>
        /// <para>
        /// <para>Specify this input parameter to distinguish data streams that have the same name.
        /// For example, if you create a data stream and then delete it, and you later create
        /// another data stream with the same name, you can use this input parameter to specify
        /// which of the two streams you want to list the shards for.</para><para>You cannot specify this parameter if you specify the <code>NextToken</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StreamCreationTimestamp { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the data stream whose shards you want to list. </para><para>You cannot specify this parameter if you specify the <code>NextToken</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of shards to return in a single call to <code>ListShards</code>.
        /// The minimum value you can specify for this parameter is 1, and the maximum is 1,000,
        /// which is also the default.</para><para>When the number of shards to be listed is greater than the value of <code>MaxResults</code>,
        /// the response contains a <code>NextToken</code> value that you can use in a subsequent
        /// call to <code>ListShards</code> to list the next set of shards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>When the number of shards in the data stream is greater than the default value for
        /// the <code>MaxResults</code> parameter, or if you explicitly specify a value for <code>MaxResults</code>
        /// that is less than the number of shards in the data stream, the response includes a
        /// pagination token named <code>NextToken</code>. You can specify this <code>NextToken</code>
        /// value in a subsequent call to <code>ListShards</code> to list the next set of shards.</para><para>Don't specify <code>StreamName</code> or <code>StreamCreationTimestamp</code> if you
        /// specify <code>NextToken</code> because the latter unambiguously identifies the stream.</para><para>You can optionally specify a value for the <code>MaxResults</code> parameter when
        /// you specify <code>NextToken</code>. If you specify a <code>MaxResults</code> value
        /// that is less than the number of shards that the operation returns if you don't specify
        /// <code>MaxResults</code>, the response will contain a new <code>NextToken</code> value.
        /// You can use the new <code>NextToken</code> value in a subsequent call to the <code>ListShards</code>
        /// operation.</para><important><para>Tokens expire after 300 seconds. When you obtain a value for <code>NextToken</code>
        /// in the response to a call to <code>ListShards</code>, you have 300 seconds to use
        /// that value. If you specify an expired token in a call to <code>ListShards</code>,
        /// you get <code>ExpiredNextTokenException</code>.</para></important>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            context.ExclusiveStartShardId = this.ExclusiveStartShardId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("StreamCreationTimestamp"))
                context.StreamCreationTimestamp = this.StreamCreationTimestamp;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.Kinesis.Model.ListShardsRequest();
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 10000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 10000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken");
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    int correctPageSize = 10000;
                    if (_emitLimit.HasValue)
                    {
                        correctPageSize = AutoIterationHelpers.Min(10000, _emitLimit.Value);
                    }
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Shards;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Shards.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
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
                } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextMarker) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
                
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
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StreamCreationTimestamp { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
