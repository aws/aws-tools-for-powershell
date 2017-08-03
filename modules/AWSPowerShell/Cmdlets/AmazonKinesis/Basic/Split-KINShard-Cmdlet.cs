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
    /// Splits a shard into two new shards in the Amazon Kinesis stream to increase the stream's
    /// capacity to ingest and transport data. <code>SplitShard</code> is called when there
    /// is a need to increase the overall capacity of a stream because of an expected increase
    /// in the volume of data records being ingested. 
    /// 
    ///  
    /// <para>
    /// You can also use <code>SplitShard</code> when a shard appears to be approaching its
    /// maximum utilization; for example, the producers sending data into the specific shard
    /// are suddenly sending more than previously anticipated. You can also call <code>SplitShard</code>
    /// to increase stream capacity, so that more Amazon Kinesis applications can simultaneously
    /// read data from the stream for real-time processing. 
    /// </para><para>
    /// You must specify the shard to be split and the new hash key, which is the position
    /// in the shard where the shard gets split in two. In many cases, the new hash key might
    /// simply be the average of the beginning and ending hash key, but it can be any hash
    /// key value in the range being mapped into the shard. For more information about splitting
    /// shards, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-resharding-split.html">Split
    /// a Shard</a> in the <i>Amazon Kinesis Streams Developer Guide</i>.
    /// </para><para>
    /// You can use <a>DescribeStream</a> to determine the shard ID and hash key values for
    /// the <code>ShardToSplit</code> and <code>NewStartingHashKey</code> parameters that
    /// are specified in the <code>SplitShard</code> request.
    /// </para><para><code>SplitShard</code> is an asynchronous operation. Upon receiving a <code>SplitShard</code>
    /// request, Amazon Kinesis immediately returns a response and sets the stream status
    /// to <code>UPDATING</code>. After the operation is completed, Amazon Kinesis sets the
    /// stream status to <code>ACTIVE</code>. Read and write operations continue to work while
    /// the stream is in the <code>UPDATING</code> state. 
    /// </para><para>
    /// You can use <code>DescribeStream</code> to check the status of the stream, which is
    /// returned in <code>StreamStatus</code>. If the stream is in the <code>ACTIVE</code>
    /// state, you can call <code>SplitShard</code>. If a stream is in <code>CREATING</code>
    /// or <code>UPDATING</code> or <code>DELETING</code> states, <code>DescribeStream</code>
    /// returns a <code>ResourceInUseException</code>.
    /// </para><para>
    /// If the specified stream does not exist, <code>DescribeStream</code> returns a <code>ResourceNotFoundException</code>.
    /// If you try to create more shards than are authorized for your account, you receive
    /// a <code>LimitExceededException</code>. 
    /// </para><para>
    /// For the default shard limit for an AWS account, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Streams
    /// Limits</a> in the <i>Amazon Kinesis Streams Developer Guide</i>. If you need to increase
    /// this limit, <a href="http://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">contact
    /// AWS Support</a>.
    /// </para><para>
    /// If you try to operate on too many streams simultaneously using <a>CreateStream</a>,
    /// <a>DeleteStream</a>, <a>MergeShards</a>, and/or <a>SplitShard</a>, you receive a <code>LimitExceededException</code>.
    /// 
    /// </para><para><code>SplitShard</code> has limit of 5 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Split", "KINShard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SplitShard operation against Amazon Kinesis.", Operation = new[] {"SplitShard"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Kinesis.Model.SplitShardResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SplitKINShardCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter NewStartingHashKey
        /// <summary>
        /// <para>
        /// <para>A hash key value for the starting hash key of one of the child shards created by the
        /// split. The hash key range for a given shard constitutes a set of ordered contiguous
        /// positive integers. The value for <code>NewStartingHashKey</code> must be in the range
        /// of hash keys being mapped into the shard. The <code>NewStartingHashKey</code> hash
        /// key value and all higher hash key values in hash key range are distributed to one
        /// of the child shards. All the lower hash key values in the range are distributed to
        /// the other child shard.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String NewStartingHashKey { get; set; }
        #endregion
        
        #region Parameter ShardToSplit
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to split.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String ShardToSplit { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream for the shard split.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the StreamName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Split-KINShard (SplitShard)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.NewStartingHashKey = this.NewStartingHashKey;
            context.ShardToSplit = this.ShardToSplit;
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
            var request = new Amazon.Kinesis.Model.SplitShardRequest();
            
            if (cmdletContext.NewStartingHashKey != null)
            {
                request.NewStartingHashKey = cmdletContext.NewStartingHashKey;
            }
            if (cmdletContext.ShardToSplit != null)
            {
                request.ShardToSplit = cmdletContext.ShardToSplit;
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
        
        #region AWS Service Operation Call
        
        private Amazon.Kinesis.Model.SplitShardResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.SplitShardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "SplitShard");
            #if DESKTOP
            return client.SplitShard(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SplitShardAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String NewStartingHashKey { get; set; }
            public System.String ShardToSplit { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
