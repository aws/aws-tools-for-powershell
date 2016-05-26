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
    /// Describes the specified Amazon Kinesis stream.
    /// 
    ///  
    /// <para>
    /// The information about the stream includes its current status, its Amazon Resource
    /// Name (ARN), and an array of shard objects. For each shard object, there is information
    /// about the hash key and sequence number ranges that the shard spans, and the IDs of
    /// any earlier shards that played in a role in creating the shard. A sequence number
    /// is the identifier associated with every record ingested in the stream. The sequence
    /// number is assigned when a record is put into the stream.
    /// </para><para>
    /// You can limit the number of returned shards using the <code>Limit</code> parameter.
    /// The number of shards in a stream may be too large to return from a single call to
    /// <code>DescribeStream</code>. You can detect this by using the <code>HasMoreShards</code>
    /// flag in the returned output. <code>HasMoreShards</code> is set to <code>true</code>
    /// when there is more data available. 
    /// </para><para><code>DescribeStream</code> is a paginated operation. If there are more shards available,
    /// you can request them using the shard ID of the last shard returned. Specify this ID
    /// in the <code>ExclusiveStartShardId</code> parameter in a subsequent request to <code>DescribeStream</code>.
    /// 
    /// </para><para>
    /// There are no guarantees about the chronological order shards returned in <code>DescribeStream</code>
    /// results. If you want to process shards in chronological order, use <code>ParentShardId</code>
    /// to track lineage to the oldest shard.
    /// </para><para><a>DescribeStream</a> has a limit of 10 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINStream")]
    [OutputType("Amazon.Kinesis.Model.StreamDescription")]
    [AWSCmdlet("Invokes the DescribeStream operation against Amazon Kinesis.", Operation = new[] {"DescribeStream"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.StreamDescription",
        "This cmdlet returns a StreamDescription object.",
        "The service call response (type Amazon.Kinesis.Model.DescribeStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetKINStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to start with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String ExclusiveStartShardId { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of shards to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 Limit { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ExclusiveStartShardId = this.ExclusiveStartShardId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.StreamName = this.StreamName;
            
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
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StreamDescription;
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
        
        private static Amazon.Kinesis.Model.DescribeStreamResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DescribeStreamRequest request)
        {
            return client.DescribeStream(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ExclusiveStartShardId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
