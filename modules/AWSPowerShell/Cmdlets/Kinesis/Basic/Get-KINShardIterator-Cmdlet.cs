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
    /// Gets an Amazon Kinesis shard iterator. A shard iterator expires 5 minutes after it
    /// is returned to the requester.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// A shard iterator specifies the shard position from which to start reading data records
    /// sequentially. The position is specified using the sequence number of a data record
    /// in a shard. A sequence number is the identifier associated with every record ingested
    /// in the stream, and is assigned when a record is put into the stream. Each stream has
    /// one or more shards.
    /// </para><para>
    /// You must specify the shard iterator type. For example, you can set the <c>ShardIteratorType</c>
    /// parameter to read exactly from the position denoted by a specific sequence number
    /// by using the <c>AT_SEQUENCE_NUMBER</c> shard iterator type. Alternatively, the parameter
    /// can read right after the sequence number by using the <c>AFTER_SEQUENCE_NUMBER</c>
    /// shard iterator type, using sequence numbers returned by earlier calls to <a>PutRecord</a>,
    /// <a>PutRecords</a>, <a>GetRecords</a>, or <a>DescribeStream</a>. In the request, you
    /// can specify the shard iterator type <c>AT_TIMESTAMP</c> to read records from an arbitrary
    /// point in time, <c>TRIM_HORIZON</c> to cause <c>ShardIterator</c> to point to the last
    /// untrimmed record in the shard in the system (the oldest data record in the shard),
    /// or <c>LATEST</c> so that you always read the most recent data in the shard. 
    /// </para><para>
    /// When you read repeatedly from a stream, use a <a>GetShardIterator</a> request to get
    /// the first shard iterator for use in your first <a>GetRecords</a> request and for subsequent
    /// reads use the shard iterator returned by the <a>GetRecords</a> request in <c>NextShardIterator</c>.
    /// A new shard iterator is returned by every <a>GetRecords</a> request in <c>NextShardIterator</c>,
    /// which you use in the <c>ShardIterator</c> parameter of the next <a>GetRecords</a>
    /// request. 
    /// </para><para>
    /// If a <a>GetShardIterator</a> request is made too often, you receive a <c>ProvisionedThroughputExceededException</c>.
    /// For more information about throughput limits, see <a>GetRecords</a>, and <a href="https://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Streams
    /// Limits</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><para>
    /// If the shard is closed, <a>GetShardIterator</a> returns a valid iterator for the last
    /// sequence number of the shard. A shard can be closed as a result of using <a>SplitShard</a>
    /// or <a>MergeShards</a>.
    /// </para><para><a>GetShardIterator</a> has a limit of five transactions per second per account per
    /// open shard.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINShardIterator")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis GetShardIterator API operation.", Operation = new[] {"GetShardIterator"}, SelectReturnType = typeof(Amazon.Kinesis.Model.GetShardIteratorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Kinesis.Model.GetShardIteratorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Kinesis.Model.GetShardIteratorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINShardIteratorCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ShardId
        /// <summary>
        /// <para>
        /// <para>The shard ID of the Kinesis Data Streams shard to get the iterator for.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ShardId { get; set; }
        #endregion
        
        #region Parameter ShardIteratorType
        /// <summary>
        /// <para>
        /// <para>Determines how the shard iterator is used to start reading data records from the shard.</para><para>The following are the valid Amazon Kinesis shard iterator types:</para><ul><li><para>AT_SEQUENCE_NUMBER - Start reading from the position denoted by a specific sequence
        /// number, provided in the value <c>StartingSequenceNumber</c>.</para></li><li><para>AFTER_SEQUENCE_NUMBER - Start reading right after the position denoted by a specific
        /// sequence number, provided in the value <c>StartingSequenceNumber</c>.</para></li><li><para>AT_TIMESTAMP - Start reading from the position denoted by a specific time stamp, provided
        /// in the value <c>Timestamp</c>.</para></li><li><para>TRIM_HORIZON - Start reading at the last untrimmed record in the shard in the system,
        /// which is the oldest data record in the shard.</para></li><li><para>LATEST - Start reading just after the most recent record in the shard, so that you
        /// always read the most recent data in the shard.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartingSequenceNumber { get; set; }
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
        /// <para>The name of the Amazon Kinesis data stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Timestamp
        /// <summary>
        /// <para>
        /// <para>The time stamp of the data record from which to start reading. Used with shard iterator
        /// type AT_TIMESTAMP. A time stamp is the Unix epoch date with precision in milliseconds.
        /// For example, <c>2016-04-04T19:58:46.480-00:00</c> or <c>1459799926.480</c>. If a record
        /// with this exact time stamp does not exist, the iterator returned is for the next (later)
        /// record. If the time stamp is older than the current trim horizon, the iterator returned
        /// is for the oldest untrimmed data record (TRIM_HORIZON).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Timestamp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ShardIterator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.GetShardIteratorResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.GetShardIteratorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ShardIterator";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.GetShardIteratorResponse, GetKINShardIteratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ShardId = this.ShardId;
            #if MODULAR
            if (this.ShardId == null && ParameterWasBound(nameof(this.ShardId)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShardIteratorType = this.ShardIteratorType;
            #if MODULAR
            if (this.ShardIteratorType == null && ParameterWasBound(nameof(this.ShardIteratorType)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardIteratorType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartingSequenceNumber = this.StartingSequenceNumber;
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
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
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
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
        
        private Amazon.Kinesis.Model.GetShardIteratorResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.GetShardIteratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "GetShardIterator");
            try
            {
                #if DESKTOP
                return client.GetShardIterator(request);
                #elif CORECLR
                return client.GetShardIteratorAsync(request).GetAwaiter().GetResult();
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
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.DateTime? Timestamp { get; set; }
            public System.Func<Amazon.Kinesis.Model.GetShardIteratorResponse, GetKINShardIteratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ShardIterator;
        }
        
    }
}
