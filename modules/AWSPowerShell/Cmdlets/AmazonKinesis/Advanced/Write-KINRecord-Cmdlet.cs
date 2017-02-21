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
using System.IO;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Writes a single data record from a producer into an Amazon Kinesis stream. Call <code>PutRecord</code>
    /// to send data from the producer into the Amazon Kinesis stream for real-time ingestion
    /// and subsequent processing, one record at a time. Each shard can support writes up
    /// to 1,000 records per second, up to a maximum data write total of 1 MB per second.
    /// 
    ///  
    /// <para>
    /// You must specify the name of the stream that captures, stores, and transports the
    /// data; a partition key; and the data blob itself.
    /// </para><para>
    /// The data blob can be any type of data; for example, a segment from a log file, geographic/location
    /// data, website clickstream data, and so on.
    /// </para><para>
    /// The partition key is used by Amazon Kinesis to distribute data across shards. Amazon
    /// Kinesis segregates the data records that belong to a data stream into multiple shards,
    /// using the partition key associated with each data record to determine which shard
    /// a given data record belongs to. 
    /// </para><para>
    /// Partition keys are Unicode strings, with a maximum length limit of 256 characters
    /// for each key. An MD5 hash function is used to map partition keys to 128-bit integer
    /// values and to map associated data records to shards using the hash key ranges of the
    /// shards. You can override hashing the partition key to determine the shard by explicitly
    /// specifying a hash value using the <code>ExplicitHashKey</code> parameter. For more
    /// information, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-add-data-to-stream">Adding
    /// Data to a Stream</a> in the <i>Amazon Kinesis Developer Guide</i>.
    /// </para><para><code>PutRecord</code> returns the shard ID of where the data record was placed and
    /// the sequence number that was assigned to the data record.
    /// </para><para>
    /// Sequence numbers generally increase over time. To guarantee strictly increasing ordering,
    /// use the <code>SequenceNumberForOrdering</code> parameter. For more information, see
    /// <a href="http://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-add-data-to-stream">Adding
    /// Data to a Stream</a> in the <i>Amazon Kinesis Developer Guide</i>.
    /// </para><para>
    /// If a <code>PutRecord</code> request cannot be processed because of insufficient provisioned
    /// throughput on the shard involved in the request, <code>PutRecord</code> throws <code>ProvisionedThroughputExceededException</code>.
    /// 
    /// </para><para>
    /// By default, data records are accessible for only 24 hours from the time that they
    /// are added to an Amazon Kinesis stream. This retention period can be modified using
    /// the <a>DecreaseStreamRetentionPeriod</a> and <a>IncreaseStreamRetentionPeriod</a>
    /// operations.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KINRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = DataFromText)]
    [OutputType("Amazon.Kinesis.Model.PutRecordResponse")]
    [AWSCmdlet("Invokes the PutRecord operation against Amazon Kinesis.", Operation = new[] {"PutRecord"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.PutRecordResponse",
        "This cmdlet returns a Amazon.Kinesis.Model.PutRecordResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteKINRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        const string DataFromBlob = "FromBlob";
        const string DataFromText = "FromText";
        const string DataFromFile = "FromFile";

        #region Parameter Blob
        /// <summary>
        /// <para>
        /// The data blob to put into the record, which is base64-encoded when serialized.
        /// When the data blob (the payload before base64-encoding) is added to the partition
        /// key size, the total size must not exceed the maximum record size (1 MB).
        /// </para>
        /// <para>
        /// Use this parameter, or -Text or -FilePath to define the data to be written into the record.
        /// </para>
        /// <para>
        /// This parameter can also be referenced using the alias '-Record_Data' for consistency with the
        /// Write-KINFRecord cmdlet for Kinesis Firehose.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = true, ParameterSetName = DataFromBlob)]
        [Alias("Record_Data")]
        public System.IO.MemoryStream Blob { get; set; }
        #endregion

        #region Parameter Text
        /// <summary>
        /// <para>
        /// Text string containing the data to send, which is base64-encoded when the 
        /// blob is serialized. When the data blob (the payload before base64-encoding) is added to 
        /// the partition key size, the total size must not exceed the maximum record size (1 MB).
        /// </para>
        /// <para>
        /// Use this parameter, or -FilePath or -Blob, to define the data to be written into the
        /// record.
        /// </para>
        /// <para>
        /// This parameter can also be referenced using the alias '-Record_Text' for consistency with the
        /// Write-KINFRecord cmdlet for Kinesis Firehose.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory =true, ParameterSetName = DataFromText)]
        [Alias("Record_Text")]
        public System.String Text { get; set; }
        #endregion

        #region Parameter FilePath
        /// <summary>
        /// <para>
        /// The fully qualified name to a file containing the data to send, which is base64-encoded 
        /// when the blob is serialized. When the data blob (the payload before base64-encoding) is 
        /// added to the partition key size, the total size must not exceed the maximum record size (1 MB).
        /// </para>
        /// <para>
        /// Use this parameter, or -Text or -Blob, to define the data to be written into the record.
        /// </para>
        /// <para>
        /// This parameter can also be referenced using the alias '-Record_FilePath' for consistency with the
        /// Write-KINFRecord cmdlet for Kinesis Firehose.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Mandatory = true, ParameterSetName = DataFromFile)]
        [Alias("Record_FilePath")]
        public System.String FilePath { get; set; }
        #endregion

        #region Parameter ExplicitHashKey
        /// <summary>
        /// <para>
        /// <para>The hash value used to explicitly determine the shard the data record is assigned
        /// to by overriding the partition key hash.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExplicitHashKey { get; set; }
        #endregion
        
        #region Parameter PartitionKey
        /// <summary>
        /// <para>
        /// <para>Determines which shard in the stream the data record is assigned to. Partition keys
        /// are Unicode strings with a maximum length limit of 256 characters for each key. Amazon
        /// Kinesis uses the partition key as input to a hash function that maps the partition
        /// key and associated data to a specific shard. Specifically, an MD5 hash function is
        /// used to map partition keys to 128-bit integer values and to map associated data records
        /// to shards. As a result of this hashing mechanism, all data records with the same partition
        /// key will map to the same shard within the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PartitionKey { get; set; }
        #endregion
        
        #region Parameter SequenceNumberForOrdering
        /// <summary>
        /// <para>
        /// <para>Guarantees strictly increasing sequence numbers, for puts from the same client and
        /// to the same partition key. Usage: set the <code>SequenceNumberForOrdering</code> of
        /// record <i>n</i> to the sequence number of record <i>n-1</i> (as returned in the result
        /// when putting record <i>n-1</i>). If this parameter is not set, records will be coarsely
        /// ordered based on arrival time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SequenceNumberForOrdering { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to put the data record into.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINRecord (PutRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };

            if (ParameterSetName.Equals(DataFromBlob, StringComparison.OrdinalIgnoreCase))
                context.Blob = this.Blob;
            else if (ParameterSetName.Equals(DataFromText, StringComparison.OrdinalIgnoreCase))
                context.Text = this.Text;
            else
            {
                if (File.Exists(this.FilePath))
                    context.FilePath = this.FilePath;
                else
                    ThrowArgumentError("File not found", this.FilePath);
            }

            context.ExplicitHashKey = this.ExplicitHashKey;
            context.PartitionKey = this.PartitionKey;
            context.SequenceNumberForOrdering = this.SequenceNumberForOrdering;
            context.StreamName = this.StreamName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.PutRecordRequest();

            try
            {
                if (cmdletContext.Blob == null)
                {
                    byte[] content;
                    if (!string.IsNullOrEmpty(cmdletContext.Text))
                        content = Encoding.UTF8.GetBytes(cmdletContext.Text);
                    else
                        content = File.ReadAllBytes(cmdletContext.FilePath);

                    var ms = new MemoryStream(content);
                    request.Data = ms;
                }
                else
                    request.Data = cmdletContext.Blob;

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
                if (cmdletContext.StreamName != null)
                {
                    request.StreamName = cmdletContext.StreamName;
                }

                var client = Client ?? CreateClient(context.Credentials, context.Region);
                CmdletOutput output;

                // issue call
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
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
            finally
            {
                if (cmdletContext.Blob == null)
                {
                    request.Data.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        #region AWS Service Operation Call

        private static Amazon.Kinesis.Model.PutRecordResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.PutRecordRequest request)
        {
#if DESKTOP
            return client.PutRecord(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutRecordAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public System.IO.MemoryStream Blob { get; set; }
            public System.String Text { get; set; }
            public System.String FilePath { get; set; }
            public System.String ExplicitHashKey { get; set; }
            public System.String PartitionKey { get; set; }
            public System.String SequenceNumberForOrdering { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
