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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Describes the specified Kinesis data stream.
    /// 
    ///  <note><para>
    /// This API has been revised. It's highly recommended that you use the <a>DescribeStreamSummary</a>
    /// API to get a summarized description of the specified Kinesis data stream and the <a>ListShards</a>
    /// API to list the shards in a specified data stream and obtain information about each
    /// shard. 
    /// </para></note><note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// The information returned includes the stream name, Amazon Resource Name (ARN), creation
    /// time, enhanced metric configuration, and shard map. The shard map is an array of shard
    /// objects. For each shard object, there is the hash key and sequence number ranges that
    /// the shard spans, and the IDs of any earlier shards that played in a role in creating
    /// the shard. Every record ingested in the stream is identified by a sequence number,
    /// which is assigned when the record is put into the stream.
    /// </para><para>
    /// You can limit the number of shards returned by each call. For more information, see
    /// <a href="https://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-retrieve-shards.html">Retrieving
    /// Shards from a Stream</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><para>
    /// There are no guarantees about the chronological order shards returned. To process
    /// shards in chronological order, use the ID of the parent shard to track the lineage
    /// to the oldest shard.
    /// </para><para>
    /// This operation has a limit of 10 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINStream")]
    [OutputType("Amazon.Kinesis.Model.StreamDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis DescribeStream API operation.", Operation = new[] {"DescribeStream"}, SelectReturnType = typeof(Amazon.Kinesis.Model.DescribeStreamResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.StreamDescription or Amazon.Kinesis.Model.DescribeStreamResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.StreamDescription object.",
        "The service call response (type Amazon.Kinesis.Model.DescribeStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKINStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExclusiveStartShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to start with.</para><para>Specify this parameter to indicate that you want to describe the stream starting with
        /// the shard whose ID immediately follows <c>ExclusiveStartShardId</c>.</para><para>If you don't specify this parameter, the default behavior for <c>DescribeStream</c>
        /// is to describe the stream starting with the first shard in the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartShardId { get; set; }
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
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of shards to return in a single call. The default value is 100.
        /// If you specify a value greater than 100, at most 100 results are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.DescribeStreamResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.DescribeStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamDescription";
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
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.DescribeStreamResponse, GetKINStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExclusiveStartShardId = this.ExclusiveStartShardId;
            context.Limit = this.Limit;
            context.StreamARN = this.StreamARN;
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
            // create request
            var request = new Amazon.Kinesis.Model.DescribeStreamRequest();
            
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Kinesis.Model.DescribeStreamResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DescribeStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DescribeStream");
            try
            {
                return client.DescribeStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Limit { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.DescribeStreamResponse, GetKINStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamDescription;
        }
        
    }
}
