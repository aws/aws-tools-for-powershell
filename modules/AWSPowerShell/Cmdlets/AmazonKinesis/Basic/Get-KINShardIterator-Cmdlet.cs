/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Gets an Amazon Kinesis shard iterator. A shard iterator expires five minutes after
    /// it is returned to the requester.
    /// 
    ///  
    /// <para>
    /// A shard iterator specifies the shard position from which to start reading data records
    /// sequentially. The position is specified using the sequence number of a data record
    /// in a shard. A sequence number is the identifier associated with every record ingested
    /// in the stream, and is assigned when a record is put into the stream. Each stream has
    /// one or more shards.
    /// </para><para>
    /// You must specify the shard iterator type. For example, you can set the <code>ShardIteratorType</code>
    /// parameter to read exactly from the position denoted by a specific sequence number
    /// by using the <code>AT_SEQUENCE_NUMBER</code> shard iterator type. Alternatively, the
    /// parameter can read right after the sequence number by using the <code>AFTER_SEQUENCE_NUMBER</code>
    /// shard iterator type, using sequence numbers returned by earlier calls to <a>PutRecord</a>,
    /// <a>PutRecords</a>, <a>GetRecords</a>, or <a>DescribeStream</a>. In the request, you
    /// can specify the shard iterator type <code>AT_TIMESTAMP</code> to read records from
    /// an arbitrary point in time, <code>TRIM_HORIZON</code> to cause <code>ShardIterator</code>
    /// to point to the last untrimmed record in the shard in the system (the oldest data
    /// record in the shard), or <code>LATEST</code> so that you always read the most recent
    /// data in the shard. 
    /// </para><para>
    /// When you read repeatedly from a stream, use a <a>GetShardIterator</a> request to get
    /// the first shard iterator for use in your first <a>GetRecords</a> request and for subsequent
    /// reads use the shard iterator returned by the <a>GetRecords</a> request in <code>NextShardIterator</code>.
    /// A new shard iterator is returned by every <a>GetRecords</a> request in <code>NextShardIterator</code>,
    /// which you use in the <code>ShardIterator</code> parameter of the next <a>GetRecords</a>
    /// request. 
    /// </para><para>
    /// If a <a>GetShardIterator</a> request is made too often, you receive a <code>ProvisionedThroughputExceededException</code>.
    /// For more information about throughput limits, see <a>GetRecords</a>, and <a href="http://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Streams
    /// Limits</a> in the <i>Amazon Kinesis Streams Developer Guide</i>.
    /// </para><para>
    /// If the shard is closed, <a>GetShardIterator</a> returns a valid iterator for the last
    /// sequence number of the shard. A shard can be closed as a result of using <a>SplitShard</a>
    /// or <a>MergeShards</a>.
    /// </para><para><a>GetShardIterator</a> has a limit of 5 transactions per second per account per
    /// open shard.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINShardIterator")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis GetShardIterator API operation.", Operation = new[] {"GetShardIterator"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Kinesis.Model.GetShardIteratorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINShardIteratorCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the Kinesis Streams shard to get the iterator for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ShardId { get; set; }
        #endregion
        
        #region Parameter ShardIteratorType
        /// <summary>
        /// <para>
        /// <para>Determines how the shard iterator is used to start reading data records from the shard.</para><para>The following are the valid Amazon Kinesis shard iterator types:</para><ul><li><para>AT_SEQUENCE_NUMBER - Start reading from the position denoted by a specific sequence
        /// number, provided in the value <code>StartingSequenceNumber</code>.</para></li><li><para>AFTER_SEQUENCE_NUMBER - Start reading right after the position denoted by a specific
        /// sequence number, provided in the value <code>StartingSequenceNumber</code>.</para></li><li><para>AT_TIMESTAMP - Start reading from the position denoted by a specific time stamp, provided
        /// in the value <code>Timestamp</code>.</para></li><li><para>TRIM_HORIZON - Start reading at the last untrimmed record in the shard in the system,
        /// which is the oldest data record in the shard.</para></li><li><para>LATEST - Start reading just after the most recent record in the shard, so that you
        /// always read the most recent data in the shard.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Kinesis.ShardIteratorType")]
        public Amazon.Kinesis.ShardIteratorType ShardIteratorType { get; set; }
        #endregion
        
        #region Parameter StartingSequenceNumber
        /// <summary>
        /// <para>
        /// <para>The sequence number of the data record in the shard from which to start reading. Used
        /// with shard iterator type AT_SEQUENCE_NUMBER and AFTER_SEQUENCE_NUMBER.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartingSequenceNumber { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Kinesis stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Timestamp
        /// <summary>
        /// <para>
        /// <para>The time stamp of the data record from which to start reading. Used with shard iterator
        /// type AT_TIMESTAMP. A time stamp is the Unix epoch date with precision in milliseconds.
        /// For example, <code>2016-04-04T19:58:46.480-00:00</code> or <code>1459799926.480</code>.
        /// If a record with this exact time stamp does not exist, the iterator returned is for
        /// the next (later) record. If the time stamp is older than the current trim horizon,
        /// the iterator returned is for the oldest untrimmed data record (TRIM_HORIZON).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime Timestamp { get; set; }
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
            
            context.ShardId = this.ShardId;
            context.ShardIteratorType = this.ShardIteratorType;
            context.StartingSequenceNumber = this.StartingSequenceNumber;
            context.StreamName = this.StreamName;
            if (ParameterWasBound("Timestamp"))
                context.Timestamp = this.Timestamp;
            
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
            var request = new Amazon.Kinesis.Model.GetShardIteratorRequest();
            
            if (cmdletContext.ShardId != null)
            {
                request.ShardId = cmdletContext.ShardId;
            }
            if (cmdletContext.ShardIteratorType != null)
            {
                request.ShardIteratorType = cmdletContext.ShardIteratorType;
            }
            if (cmdletContext.StartingSequenceNumber != null)
            {
                request.StartingSequenceNumber = cmdletContext.StartingSequenceNumber;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            if (cmdletContext.Timestamp != null)
            {
                request.Timestamp = cmdletContext.Timestamp.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ShardIterator;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Kinesis.Model.GetShardIteratorResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.GetShardIteratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "GetShardIterator");
            try
            {
                #if DESKTOP
                return client.GetShardIterator(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetShardIteratorAsync(request);
                return task.Result;
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
            public System.String ShardId { get; set; }
            public Amazon.Kinesis.ShardIteratorType ShardIteratorType { get; set; }
            public System.String StartingSequenceNumber { get; set; }
            public System.String StreamName { get; set; }
            public System.DateTime? Timestamp { get; set; }
        }
        
    }
}
