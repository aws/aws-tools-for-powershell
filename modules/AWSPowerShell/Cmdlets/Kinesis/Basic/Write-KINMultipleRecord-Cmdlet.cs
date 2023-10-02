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
    /// Writes multiple data records into a Kinesis data stream in a single call (also referred
    /// to as a <code>PutRecords</code> request). Use this operation to send data into the
    /// stream for data ingestion and processing. 
    /// 
    ///  <note><para>
    /// When invoking this API, it is recommended you use the <code>StreamARN</code> input
    /// parameter rather than the <code>StreamName</code> input parameter.
    /// </para></note><para>
    /// Each <code>PutRecords</code> request can support up to 500 records. Each record in
    /// the request can be as large as 1 MiB, up to a limit of 5 MiB for the entire request,
    /// including partition keys. Each shard can support writes up to 1,000 records per second,
    /// up to a maximum data write total of 1 MiB per second.
    /// </para><para>
    /// You must specify the name of the stream that captures, stores, and transports the
    /// data; and an array of request <code>Records</code>, with each record in the array
    /// requiring a partition key and data blob. The record size limit applies to the total
    /// size of the partition key and data blob.
    /// </para><para>
    /// The data blob can be any type of data; for example, a segment from a log file, geographic/location
    /// data, website clickstream data, and so on.
    /// </para><para>
    /// The partition key is used by Kinesis Data Streams as input to a hash function that
    /// maps the partition key and associated data to a specific shard. An MD5 hash function
    /// is used to map partition keys to 128-bit integer values and to map associated data
    /// records to shards. As a result of this hashing mechanism, all data records with the
    /// same partition key map to the same shard within the stream. For more information,
    /// see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-add-data-to-stream">Adding
    /// Data to a Stream</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// </para><para>
    /// Each record in the <code>Records</code> array may include an optional parameter, <code>ExplicitHashKey</code>,
    /// which overrides the partition key to shard mapping. This parameter allows a data producer
    /// to determine explicitly the shard where the record is stored. For more information,
    /// see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-putrecords">Adding
    /// Multiple Records with PutRecords</a> in the <i>Amazon Kinesis Data Streams Developer
    /// Guide</i>.
    /// </para><para>
    /// The <code>PutRecords</code> response includes an array of response <code>Records</code>.
    /// Each record in the response array directly correlates with a record in the request
    /// array using natural ordering, from the top to the bottom of the request and response.
    /// The response <code>Records</code> array always includes the same number of records
    /// as the request array.
    /// </para><para>
    /// The response <code>Records</code> array includes both successfully and unsuccessfully
    /// processed records. Kinesis Data Streams attempts to process all records in each <code>PutRecords</code>
    /// request. A single record failure does not stop the processing of subsequent records.
    /// As a result, PutRecords doesn't guarantee the ordering of records. If you need to
    /// read records in the same order they are written to the stream, use <a>PutRecord</a>
    /// instead of <code>PutRecords</code>, and write to the same shard.
    /// </para><para>
    /// A successfully processed record includes <code>ShardId</code> and <code>SequenceNumber</code>
    /// values. The <code>ShardId</code> parameter identifies the shard in the stream where
    /// the record is stored. The <code>SequenceNumber</code> parameter is an identifier assigned
    /// to the put record, unique to all records in the stream.
    /// </para><para>
    /// An unsuccessfully processed record includes <code>ErrorCode</code> and <code>ErrorMessage</code>
    /// values. <code>ErrorCode</code> reflects the type of error and can be one of the following
    /// values: <code>ProvisionedThroughputExceededException</code> or <code>InternalFailure</code>.
    /// <code>ErrorMessage</code> provides more detailed information about the <code>ProvisionedThroughputExceededException</code>
    /// exception including the account ID, stream name, and shard ID of the record that was
    /// throttled. For more information about partially successful responses, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-add-data-to-stream.html#kinesis-using-sdk-java-putrecords">Adding
    /// Multiple Records with PutRecords</a> in the <i>Amazon Kinesis Data Streams Developer
    /// Guide</i>.
    /// </para><important><para>
    /// After you write a record to a stream, you cannot modify that record or its order within
    /// the stream.
    /// </para></important><para>
    /// By default, data records are accessible for 24 hours from the time that they are added
    /// to a stream. You can use <a>IncreaseStreamRetentionPeriod</a> or <a>DecreaseStreamRetentionPeriod</a>
    /// to modify this retention period.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KINMultipleRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.PutRecordsResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis PutRecords API operation.", Operation = new[] {"PutRecords"}, SelectReturnType = typeof(Amazon.Kinesis.Model.PutRecordsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.PutRecordsResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.PutRecordsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteKINMultipleRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>The records associated with the request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Records")]
        public Amazon.Kinesis.Model.PutRecordsRequestEntry[] Record { get; set; }
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
        /// <para>The stream name associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.PutRecordsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.PutRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Record parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Record' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Record' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINMultipleRecord (PutRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.PutRecordsResponse, WriteKINMultipleRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Record;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Record != null)
            {
                context.Record = new List<Amazon.Kinesis.Model.PutRecordsRequestEntry>(this.Record);
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.PutRecordsRequest();
            
            if (cmdletContext.Record != null)
            {
                request.Records = cmdletContext.Record;
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
        
        private Amazon.Kinesis.Model.PutRecordsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.PutRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "PutRecords");
            try
            {
                #if DESKTOP
                return client.PutRecords(request);
                #elif CORECLR
                return client.PutRecordsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Kinesis.Model.PutRecordsRequestEntry> Record { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.PutRecordsResponse, WriteKINMultipleRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
