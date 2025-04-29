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
    /// Writes a single data record into an Amazon Kinesis data stream. Call <c>PutRecord</c>
    /// to send data into the stream for real-time ingestion and subsequent processing, one
    /// record at a time. Each shard can support writes up to 1,000 records per second, up
    /// to a maximum data write total of 1 MiB per second.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// You must specify the name of the stream that captures, stores, and transports the
    /// data; a partition key; and the data blob itself.
    /// </para><para>
    /// The data blob can be any type of data; for example, a segment from a log file, geographic/location
    /// data, website clickstream data, and so on.
    /// </para><para>
    /// The partition key is used by Kinesis Data Streams to distribute data across shards.
    /// Kinesis Data Streams segregates the data records that belong to a stream into multiple
    /// shards, using the partition key associated with each data record to determine the
    /// shard to which a given data record belongs.
    /// </para><para>
    /// Partition keys are Unicode strings, with a maximum length limit of 256 characters
    /// for each key. An MD5 hash function is used to map partition keys to 128-bit integer
    /// values and to map associated data records to shards using the hash key ranges of the
    /// shards. You can override hashing the partition key to determine the shard by explicitly
    /// specifying a hash value using the <c>ExplicitHashKey</c> parameter. For more information,
    /// see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-add-data-to-stream">Adding
    /// Data to a Stream</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><para><c>PutRecord</c> returns the shard ID of where the data record was placed and the
    /// sequence number that was assigned to the data record.
    /// </para><para>
    /// Sequence numbers increase over time and are specific to a shard within a stream, not
    /// across all shards within a stream. To guarantee strictly increasing ordering, write
    /// serially to a shard and use the <c>SequenceNumberForOrdering</c> parameter. For more
    /// information, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-add-data-to-stream">Adding
    /// Data to a Stream</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><important><para>
    /// After you write a record to a stream, you cannot modify that record or its order within
    /// the stream.
    /// </para></important><para>
    /// If a <c>PutRecord</c> request cannot be processed because of insufficient provisioned
    /// throughput on the shard involved in the request, <c>PutRecord</c> throws <c>ProvisionedThroughputExceededException</c>.
    /// 
    /// </para><para>
    /// By default, data records are accessible for 24 hours from the time that they are added
    /// to a stream. You can use <a>IncreaseStreamRetentionPeriod</a> or <a>DecreaseStreamRetentionPeriod</a>
    /// to modify this retention period.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KINRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="FromBlob")]
    [OutputType("Amazon.Kinesis.Model.PutRecordResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis PutRecord API operation.", Operation = new[] {"PutRecord"}, SelectReturnType = typeof(Amazon.Kinesis.Model.PutRecordResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.PutRecordResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.PutRecordResponse object containing multiple properties."
    )]
    public partial class WriteKINRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Data
        /// <summary>
        /// <para>
        /// <para>The data blob to put into the record, which is base64-encoded when the blob is serialized.
        /// When the data blob (the payload before base64-encoding) is added to the partition
        /// key size, the total size must not exceed the maximum record size (1 MiB).</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromBlob")]
        [Alias("Blob","Record_Data")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Data { get; set; }
        #endregion
        
        #region Parameter ExplicitHashKey
        /// <summary>
        /// <para>
        /// <para>The hash value used to explicitly determine the shard the data record is assigned
        /// to by overriding the partition key hash.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExplicitHashKey { get; set; }
        #endregion
        
        #region Parameter PartitionKey
        /// <summary>
        /// <para>
        /// <para>Determines which shard in the stream the data record is assigned to. Partition keys
        /// are Unicode strings with a maximum length limit of 256 characters for each key. Amazon
        /// Kinesis Data Streams uses the partition key as input to a hash function that maps
        /// the partition key and associated data to a specific shard. Specifically, an MD5 hash
        /// function is used to map partition keys to 128-bit integer values and to map associated
        /// data records to shards. As a result of this hashing mechanism, all data records with
        /// the same partition key map to the same shard within the stream.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PartitionKey { get; set; }
        #endregion
        
        #region Parameter SequenceNumberForOrdering
        /// <summary>
        /// <para>
        /// <para>Guarantees strictly increasing sequence numbers, for puts from the same client and
        /// to the same partition key. Usage: set the <c>SequenceNumberForOrdering</c> of record
        /// <i>n</i> to the sequence number of record <i>n-1</i> (as returned in the result when
        /// putting record <i>n-1</i>). If this parameter is not set, records are coarsely ordered
        /// based on arrival time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SequenceNumberForOrdering { get; set; }
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
        /// <para>The name of the stream to put the data record into.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.PutRecordResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.PutRecordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINRecord (PutRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.PutRecordResponse, WriteKINRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Data = this.Data;
            #if MODULAR
            if (this.Data == null && ParameterWasBound(nameof(this.Data)))
            {
                WriteWarning("You are passing $null as a value for parameter Data which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExplicitHashKey = this.ExplicitHashKey;
            context.PartitionKey = this.PartitionKey;
            #if MODULAR
            if (this.PartitionKey == null && ParameterWasBound(nameof(this.PartitionKey)))
            {
                WriteWarning("You are passing $null as a value for parameter PartitionKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SequenceNumberForOrdering = this.SequenceNumberForOrdering;
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
            System.IO.MemoryStream _DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Kinesis.Model.PutRecordRequest();
                
                if (cmdletContext.Data != null)
                {
                    _DataStream = new System.IO.MemoryStream(cmdletContext.Data);
                    request.Data = _DataStream;
                }
                if (cmdletContext.ExplicitHashKey != null)
                {
                    request.ExplicitHashKey = cmdletContext.ExplicitHashKey;
                }
                if (cmdletContext.PartitionKey != null)
                {
                    request.PartitionKey = cmdletContext.PartitionKey;
                }
                if (cmdletContext.SequenceNumberForOrdering != null)
                {
                    request.SequenceNumberForOrdering = cmdletContext.SequenceNumberForOrdering;
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
            finally
            {
                if( _DataStream != null)
                {
                    _DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Kinesis.Model.PutRecordResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.PutRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "PutRecord");
            try
            {
                return client.PutRecordAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] Data { get; set; }
            public System.String ExplicitHashKey { get; set; }
            public System.String PartitionKey { get; set; }
            public System.String SequenceNumberForOrdering { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.PutRecordResponse, WriteKINRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
