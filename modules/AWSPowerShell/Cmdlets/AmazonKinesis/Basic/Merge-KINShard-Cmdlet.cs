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
    /// Merges two adjacent shards in a stream and combines them into a single shard to reduce
    /// the stream's capacity to ingest and transport data. Two shards are considered adjacent
    /// if the union of the hash key ranges for the two shards form a contiguous set with
    /// no gaps. For example, if you have two shards, one with a hash key range of 276...381
    /// and the other with a hash key range of 382...454, then you could merge these two shards
    /// into a single shard that would have a hash key range of 276...454. After the merge,
    /// the single child shard receives data for all hash key values covered by the two parent
    /// shards.
    /// 
    ///  
    /// <para><code>MergeShards</code> is called when there is a need to reduce the overall capacity
    /// of a stream because of excess capacity that is not being used. You must specify the
    /// shard to be merged and the adjacent shard for a stream. For more information about
    /// merging shards, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-resharding-merge.html">Merge
    /// Two Shards</a> in the <i>Amazon Kinesis Developer Guide</i>.
    /// </para><para>
    /// If the stream is in the <code>ACTIVE</code> state, you can call <code>MergeShards</code>.
    /// If a stream is in the <code>CREATING</code>, <code>UPDATING</code>, or <code>DELETING</code>
    /// state, <code>MergeShards</code> returns a <code>ResourceInUseException</code>. If
    /// the specified stream does not exist, <code>MergeShards</code> returns a <code>ResourceNotFoundException</code>.
    /// 
    /// </para><para>
    /// You can use <a>DescribeStream</a> to check the state of the stream, which is returned
    /// in <code>StreamStatus</code>.
    /// </para><para><code>MergeShards</code> is an asynchronous operation. Upon receiving a <code>MergeShards</code>
    /// request, Amazon Kinesis immediately returns a response and sets the <code>StreamStatus</code>
    /// to <code>UPDATING</code>. After the operation is completed, Amazon Kinesis sets the
    /// <code>StreamStatus</code> to <code>ACTIVE</code>. Read and write operations continue
    /// to work while the stream is in the <code>UPDATING</code> state. 
    /// </para><para>
    /// You use <a>DescribeStream</a> to determine the shard IDs that are specified in the
    /// <code>MergeShards</code> request. 
    /// </para><para>
    /// If you try to operate on too many streams in parallel using <a>CreateStream</a>, <a>DeleteStream</a>,
    /// <code>MergeShards</code> or <a>SplitShard</a>, you will receive a <code>LimitExceededException</code>.
    /// 
    /// </para><para><code>MergeShards</code> has limit of 5 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Merge", "KINShard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the MergeShards operation against Amazon Kinesis.", Operation = new[] {"MergeShards"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Kinesis.Model.MergeShardsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class MergeKINShardCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The shard ID of the adjacent shard for the merge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String AdjacentShardToMerge { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to combine with the adjacent shard for the merge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ShardToMerge { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the stream for the merge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the StreamName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Merge-KINShard (MergeShards)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AdjacentShardToMerge = this.AdjacentShardToMerge;
            context.ShardToMerge = this.ShardToMerge;
            context.StreamName = this.StreamName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.MergeShardsRequest();
            
            if (cmdletContext.AdjacentShardToMerge != null)
            {
                request.AdjacentShardToMerge = cmdletContext.AdjacentShardToMerge;
            }
            if (cmdletContext.ShardToMerge != null)
            {
                request.ShardToMerge = cmdletContext.ShardToMerge;
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
                var response = client.MergeShards(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StreamName;
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
            public System.String AdjacentShardToMerge { get; set; }
            public System.String ShardToMerge { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
