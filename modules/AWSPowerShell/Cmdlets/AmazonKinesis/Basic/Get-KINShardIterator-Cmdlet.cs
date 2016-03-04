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
    /// Gets a shard iterator. A shard iterator expires five minutes after it is returned
    /// to the requester.
    /// 
    ///  
    /// <para>
    /// A shard iterator specifies the position in the shard from which to start reading data
    /// records sequentially. A shard iterator specifies this position using the sequence
    /// number of a data record in a shard. A sequence number is the identifier associated
    /// with every record ingested in the Amazon Kinesis stream. The sequence number is assigned
    /// when a record is put into the stream. 
    /// </para><para>
    /// You must specify the shard iterator type. For example, you can set the <code>ShardIteratorType</code>
    /// parameter to read exactly from the position denoted by a specific sequence number
    /// by using the <code>AT_SEQUENCE_NUMBER</code> shard iterator type, or right after the
    /// sequence number by using the <code>AFTER_SEQUENCE_NUMBER</code> shard iterator type,
    /// using sequence numbers returned by earlier calls to <a>PutRecord</a>, <a>PutRecords</a>,
    /// <a>GetRecords</a>, or <a>DescribeStream</a>. You can specify the shard iterator type
    /// <code>TRIM_HORIZON</code> in the request to cause <code>ShardIterator</code> to point
    /// to the last untrimmed record in the shard in the system, which is the oldest data
    /// record in the shard. Or you can point to just after the most recent record in the
    /// shard, by using the shard iterator type <code>LATEST</code>, so that you always read
    /// the most recent data in the shard. 
    /// </para><para>
    /// When you repeatedly read from an Amazon Kinesis stream use a <a>GetShardIterator</a>
    /// request to get the first shard iterator for use in your first <a>GetRecords</a> request
    /// and then use the shard iterator returned by the <a>GetRecords</a> request in <code>NextShardIterator</code>
    /// for subsequent reads. A new shard iterator is returned by every <a>GetRecords</a>
    /// request in <code>NextShardIterator</code>, which you use in the <code>ShardIterator</code>
    /// parameter of the next <a>GetRecords</a> request. 
    /// </para><para>
    /// If a <a>GetShardIterator</a> request is made too often, you receive a <code>ProvisionedThroughputExceededException</code>.
    /// For more information about throughput limits, see <a>GetRecords</a>.
    /// </para><para>
    /// If the shard is closed, the iterator can't return more data, and <a>GetShardIterator</a>
    /// returns <code>null</code> for its <code>ShardIterator</code>. A shard can be closed
    /// using <a>SplitShard</a> or <a>MergeShards</a>.
    /// </para><para><a>GetShardIterator</a> has a limit of 5 transactions per second per account per open
    /// shard.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINShardIterator")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetShardIterator operation against Amazon Kinesis.", Operation = new[] {"GetShardIterator"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Kinesis.Model.GetShardIteratorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINShardIteratorCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to get the iterator for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ShardId { get; set; }
        #endregion
        
        #region Parameter ShardIteratorType
        /// <summary>
        /// <para>
        /// <para>Determines how the shard iterator is used to start reading data records from the shard.</para><para>The following are the valid shard iterator types:</para><ul><li>AT_SEQUENCE_NUMBER - Start reading exactly from the position denoted by
        /// a specific sequence number.</li><li>AFTER_SEQUENCE_NUMBER - Start reading right after
        /// the position denoted by a specific sequence number.</li><li>TRIM_HORIZON - Start
        /// reading at the last untrimmed record in the shard in the system, which is the oldest
        /// data record in the shard.</li><li>LATEST - Start reading just after the most recent
        /// record in the shard, so that you always read the most recent data in the shard.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Kinesis.ShardIteratorType")]
        public Amazon.Kinesis.ShardIteratorType ShardIteratorType { get; set; }
        #endregion
        
        #region Parameter StartingSequenceNumber
        /// <summary>
        /// <para>
        /// <para>The sequence number of the data record in the shard from which to start reading from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartingSequenceNumber { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ShardId = this.ShardId;
            context.ShardIteratorType = this.ShardIteratorType;
            context.StartingSequenceNumber = this.StartingSequenceNumber;
            context.StreamName = this.StreamName;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetShardIterator(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ShardId { get; set; }
            public Amazon.Kinesis.ShardIteratorType ShardIteratorType { get; set; }
            public System.String StartingSequenceNumber { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
