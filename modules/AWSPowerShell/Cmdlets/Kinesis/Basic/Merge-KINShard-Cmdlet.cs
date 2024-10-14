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
    /// Merges two adjacent shards in a Kinesis data stream and combines them into a single
    /// shard to reduce the stream's capacity to ingest and transport data. This API is only
    /// supported for the data streams with the provisioned capacity mode. Two shards are
    /// considered adjacent if the union of the hash key ranges for the two shards form a
    /// contiguous set with no gaps. For example, if you have two shards, one with a hash
    /// key range of 276...381 and the other with a hash key range of 382...454, then you
    /// could merge these two shards into a single shard that would have a hash key range
    /// of 276...454. After the merge, the single child shard receives data for all hash key
    /// values covered by the two parent shards.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para><c>MergeShards</c> is called when there is a need to reduce the overall capacity
    /// of a stream because of excess capacity that is not being used. You must specify the
    /// shard to be merged and the adjacent shard for a stream. For more information about
    /// merging shards, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-resharding-merge.html">Merge
    /// Two Shards</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><para>
    /// If the stream is in the <c>ACTIVE</c> state, you can call <c>MergeShards</c>. If a
    /// stream is in the <c>CREATING</c>, <c>UPDATING</c>, or <c>DELETING</c> state, <c>MergeShards</c>
    /// returns a <c>ResourceInUseException</c>. If the specified stream does not exist, <c>MergeShards</c>
    /// returns a <c>ResourceNotFoundException</c>. 
    /// </para><para>
    /// You can use <a>DescribeStreamSummary</a> to check the state of the stream, which is
    /// returned in <c>StreamStatus</c>.
    /// </para><para><c>MergeShards</c> is an asynchronous operation. Upon receiving a <c>MergeShards</c>
    /// request, Amazon Kinesis Data Streams immediately returns a response and sets the <c>StreamStatus</c>
    /// to <c>UPDATING</c>. After the operation is completed, Kinesis Data Streams sets the
    /// <c>StreamStatus</c> to <c>ACTIVE</c>. Read and write operations continue to work while
    /// the stream is in the <c>UPDATING</c> state. 
    /// </para><para>
    /// You use <a>DescribeStreamSummary</a> and the <a>ListShards</a> APIs to determine the
    /// shard IDs that are specified in the <c>MergeShards</c> request. 
    /// </para><para>
    /// If you try to operate on too many streams in parallel using <a>CreateStream</a>, <a>DeleteStream</a>,
    /// <c>MergeShards</c>, or <a>SplitShard</a>, you receive a <c>LimitExceededException</c>.
    /// 
    /// </para><para><c>MergeShards</c> has a limit of five transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Merge", "KINShard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis MergeShards API operation.", Operation = new[] {"MergeShards"}, SelectReturnType = typeof(Amazon.Kinesis.Model.MergeShardsResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.MergeShardsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.MergeShardsResponse) be returned by specifying '-Select *'."
    )]
    public partial class MergeKINShardCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdjacentShardToMerge
        /// <summary>
        /// <para>
        /// <para>The shard ID of the adjacent shard for the merge.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AdjacentShardToMerge { get; set; }
        #endregion
        
        #region Parameter ShardToMerge
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to combine with the adjacent shard for the merge.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ShardToMerge { get; set; }
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
        /// <para>The name of the stream for the merge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.MergeShardsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Merge-KINShard (MergeShards)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.MergeShardsResponse, MergeKINShardCmdlet>(Select) ??
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
            context.AdjacentShardToMerge = this.AdjacentShardToMerge;
            #if MODULAR
            if (this.AdjacentShardToMerge == null && ParameterWasBound(nameof(this.AdjacentShardToMerge)))
            {
                WriteWarning("You are passing $null as a value for parameter AdjacentShardToMerge which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShardToMerge = this.ShardToMerge;
            #if MODULAR
            if (this.ShardToMerge == null && ParameterWasBound(nameof(this.ShardToMerge)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardToMerge which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Kinesis.Model.MergeShardsRequest();
            
            if (cmdletContext.AdjacentShardToMerge != null)
            {
                request.AdjacentShardToMerge = cmdletContext.AdjacentShardToMerge;
            }
            if (cmdletContext.ShardToMerge != null)
            {
                request.ShardToMerge = cmdletContext.ShardToMerge;
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
        
        private Amazon.Kinesis.Model.MergeShardsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.MergeShardsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "MergeShards");
            try
            {
                #if DESKTOP
                return client.MergeShards(request);
                #elif CORECLR
                return client.MergeShardsAsync(request).GetAwaiter().GetResult();
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
            public System.String AdjacentShardToMerge { get; set; }
            public System.String ShardToMerge { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.MergeShardsResponse, MergeKINShardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
