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
    /// Splits a shard into two new shards in the Kinesis data stream, to increase the stream's
    /// capacity to ingest and transport data. <code>SplitShard</code> is called when there
    /// is a need to increase the overall capacity of a stream because of an expected increase
    /// in the volume of data records being ingested. This API is only supported for the data
    /// streams with the provisioned capacity mode.
    /// 
    ///  <note><para>
    /// When invoking this API, it is recommended you use the <code>StreamARN</code> input
    /// parameter rather than the <code>StreamName</code> input parameter.
    /// </para></note><para>
    /// You can also use <code>SplitShard</code> when a shard appears to be approaching its
    /// maximum utilization; for example, the producers sending data into the specific shard
    /// are suddenly sending more than previously anticipated. You can also call <code>SplitShard</code>
    /// to increase stream capacity, so that more Kinesis Data Streams applications can simultaneously
    /// read data from the stream for real-time processing. 
    /// </para><para>
    /// You must specify the shard to be split and the new hash key, which is the position
    /// in the shard where the shard gets split in two. In many cases, the new hash key might
    /// be the average of the beginning and ending hash key, but it can be any hash key value
    /// in the range being mapped into the shard. For more information, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-resharding-split.html">Split
    /// a Shard</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><para>
    /// You can use <a>DescribeStreamSummary</a> and the <a>ListShards</a> APIs to determine
    /// the shard ID and hash key values for the <code>ShardToSplit</code> and <code>NewStartingHashKey</code>
    /// parameters that are specified in the <code>SplitShard</code> request.
    /// </para><para><code>SplitShard</code> is an asynchronous operation. Upon receiving a <code>SplitShard</code>
    /// request, Kinesis Data Streams immediately returns a response and sets the stream status
    /// to <code>UPDATING</code>. After the operation is completed, Kinesis Data Streams sets
    /// the stream status to <code>ACTIVE</code>. Read and write operations continue to work
    /// while the stream is in the <code>UPDATING</code> state. 
    /// </para><para>
    /// You can use <a>DescribeStreamSummary</a> to check the status of the stream, which
    /// is returned in <code>StreamStatus</code>. If the stream is in the <code>ACTIVE</code>
    /// state, you can call <code>SplitShard</code>. 
    /// </para><para>
    /// If the specified stream does not exist, <a>DescribeStreamSummary</a> returns a <code>ResourceNotFoundException</code>.
    /// If you try to create more shards than are authorized for your account, you receive
    /// a <code>LimitExceededException</code>. 
    /// </para><para>
    /// For the default shard limit for an Amazon Web Services account, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Kinesis
    /// Data Streams Limits</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// To increase this limit, <a href="https://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">contact
    /// Amazon Web Services Support</a>.
    /// </para><para>
    /// If you try to operate on too many streams simultaneously using <a>CreateStream</a>,
    /// <a>DeleteStream</a>, <a>MergeShards</a>, and/or <a>SplitShard</a>, you receive a <code>LimitExceededException</code>.
    /// 
    /// </para><para><code>SplitShard</code> has a limit of five transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Split", "KINShard", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis SplitShard API operation.", Operation = new[] {"SplitShard"}, SelectReturnType = typeof(Amazon.Kinesis.Model.SplitShardResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.SplitShardResponse",
        "This cmdlet does not generate any output." +
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NewStartingHashKey { get; set; }
        #endregion
        
        #region Parameter ShardToSplit
        /// <summary>
        /// <para>
        /// <para>The shard ID of the shard to split.</para>
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
        public System.String ShardToSplit { get; set; }
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
        /// <para>The name of the stream for the shard split.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.SplitShardResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Split-KINShard (SplitShard)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.SplitShardResponse, SplitKINShardCmdlet>(Select) ??
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
            context.NewStartingHashKey = this.NewStartingHashKey;
            #if MODULAR
            if (this.NewStartingHashKey == null && ParameterWasBound(nameof(this.NewStartingHashKey)))
            {
                WriteWarning("You are passing $null as a value for parameter NewStartingHashKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShardToSplit = this.ShardToSplit;
            #if MODULAR
            if (this.ShardToSplit == null && ParameterWasBound(nameof(this.ShardToSplit)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardToSplit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.SplitShardRequest();
            
            if (cmdletContext.NewStartingHashKey != null)
            {
                request.NewStartingHashKey = cmdletContext.NewStartingHashKey;
            }
            if (cmdletContext.ShardToSplit != null)
            {
                request.ShardToSplit = cmdletContext.ShardToSplit;
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
        
        private Amazon.Kinesis.Model.SplitShardResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.SplitShardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "SplitShard");
            try
            {
                #if DESKTOP
                return client.SplitShard(request);
                #elif CORECLR
                return client.SplitShardAsync(request).GetAwaiter().GetResult();
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
            public System.String NewStartingHashKey { get; set; }
            public System.String ShardToSplit { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.SplitShardResponse, SplitKINShardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
