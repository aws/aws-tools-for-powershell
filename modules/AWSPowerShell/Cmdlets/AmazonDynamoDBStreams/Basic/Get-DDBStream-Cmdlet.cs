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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Returns information about a stream, including the current status of the stream, its
    /// Amazon Resource Name (ARN), the composition of its shards, and its corresponding DynamoDB
    /// table.
    /// 
    ///  <note><para>
    /// You can call <i>DescribeStream</i> at a maximum rate of 10 times per second.
    /// </para></note><para>
    /// Each shard in the stream has a <code>SequenceNumberRange</code> associated with it.
    /// If the <code>SequenceNumberRange</code> has a <code>StartingSequenceNumber</code>
    /// but no <code>EndingSequenceNumber</code>, then the shard is still open (able to receive
    /// more stream records). If both <code>StartingSequenceNumber</code> and <code>EndingSequenceNumber</code>
    /// are present, the that shared is closed and can no longer receive more data.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBStream")]
    [OutputType("Amazon.DynamoDBv2.Model.StreamDescription")]
    [AWSCmdlet("Invokes the DescribeStream operation against Amazon DynamoDB.", Operation = new[] {"DescribeStream"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.StreamDescription",
        "This cmdlet returns a StreamDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DescribeStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetDDBStreamCmdlet : AmazonDynamoDBStreamsClientCmdlet, IExecutor
    {
        
        #region Parameter ExclusiveStartShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the first item that this operation will evaluate. Use the value that
        /// was returned for <code>LastEvaluatedShardId</code> in the previous operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String ExclusiveStartShardId { get; set; }
        #endregion
        
        #region Parameter StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamArn { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of shard objects to return. The upper limit is 100.</para>
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
            context.StreamArn = this.StreamArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DynamoDBv2.Model.DescribeStreamRequest();
            
            if (cmdletContext.ExclusiveStartShardId != null)
            {
                request.ExclusiveStartShardId = cmdletContext.ExclusiveStartShardId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.StreamArn != null)
            {
                request.StreamArn = cmdletContext.StreamArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeStream(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ExclusiveStartShardId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String StreamArn { get; set; }
        }
        
    }
}
