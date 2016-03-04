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
    /// Writes multiple data records from a producer into an Amazon Kinesis stream in a single
    /// call (also referred to as a <code>PutRecords</code> request). Use this operation to
    /// send data from a data producer into the Amazon Kinesis stream for data ingestion and
    /// processing. 
    /// 
    ///  
    /// <para>
    /// Each <code>PutRecords</code> request can support up to 500 records. Each record in
    /// the request can be as large as 1 MB, up to a limit of 5 MB for the entire request,
    /// including partition keys. Each shard can support writes up to 1,000 records per second,
    /// up to a maximum data write total of 1 MB per second.
    /// </para><para>
    /// You must specify the name of the stream that captures, stores, and transports the
    /// data; and an array of request <code>Records</code>, with each record in the array
    /// requiring a partition key and data blob. The record size limit applies to the total
    /// size of the partition key and data blob.
    /// </para><para>
    /// The data blob can be any type of data; for example, a segment from a log file, geographic/location
    /// data, website clickstream data, and so on.
    /// </para><para>
    /// The partition key is used by Amazon Kinesis as input to a hash function that maps
    /// the partition key and associated data to a specific shard. An MD5 hash function is
    /// used to map partition keys to 128-bit integer values and to map associated data records
    /// to shards. As a result of this hashing mechanism, all data records with the same partition
    /// key map to the same shard within the stream. For more information, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-add-data-to-stream">Adding
    /// Data to a Stream</a> in the <i>Amazon Kinesis Developer Guide</i>.
    /// </para><para>
    /// Each record in the <code>Records</code> array may include an optional parameter, <code>ExplicitHashKey</code>,
    /// which overrides the partition key to shard mapping. This parameter allows a data producer
    /// to determine explicitly the shard where the record is stored. For more information,
    /// see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/developing-producers-with-sdk.html#kinesis-using-sdk-java-putrecords">Adding
    /// Multiple Records with PutRecords</a> in the <i>Amazon Kinesis Developer Guide</i>.
    /// </para><para>
    /// The <code>PutRecords</code> response includes an array of response <code>Records</code>.
    /// Each record in the response array directly correlates with a record in the request
    /// array using natural ordering, from the top to the bottom of the request and response.
    /// The response <code>Records</code> array always includes the same number of records
    /// as the request array.
    /// </para><para>
    /// The response <code>Records</code> array includes both successfully and unsuccessfully
    /// processed records. Amazon Kinesis attempts to process all records in each <code>PutRecords</code>
    /// request. A single record failure does not stop the processing of subsequent records.
    /// </para><para>
    /// A successfully-processed record includes <code>ShardId</code> and <code>SequenceNumber</code>
    /// values. The <code>ShardId</code> parameter identifies the shard in the stream where
    /// the record is stored. The <code>SequenceNumber</code> parameter is an identifier assigned
    /// to the put record, unique to all records in the stream.
    /// </para><para>
    /// An unsuccessfully-processed record includes <code>ErrorCode</code> and <code>ErrorMessage</code>
    /// values. <code>ErrorCode</code> reflects the type of error and can be one of the following
    /// values: <code>ProvisionedThroughputExceededException</code> or <code>InternalFailure</code>.
    /// <code>ErrorMessage</code> provides more detailed information about the <code>ProvisionedThroughputExceededException</code>
    /// exception including the account ID, stream name, and shard ID of the record that was
    /// throttled. For more information about partially successful responses, see <a href="http://docs.aws.amazon.com/kinesis/latest/dev/kinesis-using-sdk-java-add-data-to-stream.html#kinesis-using-sdk-java-putrecords">Adding
    /// Multiple Records with PutRecords</a> in the <i>Amazon Kinesis Developer Guide</i>.
    /// </para><para>
    /// By default, data records are accessible for only 24 hours from the time that they
    /// are added to an Amazon Kinesis stream. This retention period can be modified using
    /// the <a>DecreaseStreamRetentionPeriod</a> and <a>IncreaseStreamRetentionPeriod</a>
    /// operations.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KINMultipleRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.PutRecordsResponse")]
    [AWSCmdlet("Invokes the PutRecords operation against Amazon Kinesis.", Operation = new[] {"PutRecords"})]
    [AWSCmdletOutput("Amazon.Kinesis.Model.PutRecordsResponse",
        "This cmdlet returns a Amazon.Kinesis.Model.PutRecordsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteKINMultipleRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>The records associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Records")]
        public Amazon.Kinesis.Model.PutRecordsRequestEntry[] Record { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The stream name associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINMultipleRecord (PutRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Record != null)
            {
                context.Records = new List<Amazon.Kinesis.Model.PutRecordsRequestEntry>(this.Record);
            }
            context.StreamName = this.StreamName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.PutRecordsRequest();
            
            if (cmdletContext.Records != null)
            {
                request.Records = cmdletContext.Records;
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
                var response = client.PutRecords(request);
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.Kinesis.Model.PutRecordsRequestEntry> Records { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
