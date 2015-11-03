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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;
using System.IO;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Writes a single data record into an Amazon Kinesis Firehose delivery stream. To write
    /// multiple data records into a delivery stream, use <a>PutRecordBatch</a>. Applications
    /// using these operations are referred to as producers.
    /// 
    ///  
    /// <para>
    /// By default, each delivery stream can take in up to 2,000 transactions per second,
    /// 5,000 records per second, or 5 MB per second. Note that if you use <a>PutRecord</a>
    /// and <a>PutRecordBatch</a>, the limits are an aggregate across these two operations
    /// for each delivery stream. For more information about limits and how to request an
    /// increase, see <a href="http://docs.aws.amazon.com/firehose/latest/dev/limits.html">Amazon
    /// Kinesis Firehose Limits</a>. 
    /// </para><para>
    /// You must specify the name of the delivery stream and the data record when using <a>PutRecord</a>.
    /// The data record consists of a data blob that can be up to 1,000 KB in size, and any
    /// kind of data, for example, a segment from a log file, geographic location data, web
    /// site clickstream data, etc.
    /// </para><para>
    /// Amazon Kinesis Firehose buffers records before delivering them to the destination.
    /// To disambiguate the data blobs at the destination, a common solution is to use delimiters
    /// in the data, such as a newline (<code>\n</code>) or some other character unique within
    /// the data. This allows the consumer application(s) to parse individual data items when
    /// reading the data from the destination.
    /// </para><para>
    /// Amazon Kinesis Firehose does not maintain data record ordering. If the destination
    /// data needs to be re-ordered by the consumer application, the producer should include
    /// some form of sequence number in each data record. 
    /// </para><para>
    /// The <a>PutRecord</a> operation returns a <code>RecordId</code>, which is a unique
    /// string assigned to each record. Producer applications can use this ID for purposes
    /// such as auditability and investigation.
    /// </para><para>
    /// If the <a>PutRecord</a> operation throws a <code>ServiceUnavailableException</code>,
    /// back off and retry. If the exception persists, it is possible that the throughput
    /// limits have been exceeded for the delivery stream. 
    /// </para><para>
    /// Data records sent to Amazon Kinesis Firehose are stored for 24 hours from the time
    /// they are added to a delivery stream as it attempts to send the records to the destination.
    /// If the destination is unreachable for more than 24 hours, the data is no longer available.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KINFRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the PutRecord operation against Amazon Kinesis Firehose.", Operation = new[] {"PutRecord"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.KinesisFirehose.Model.PutRecordResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteKINFRecordCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        #region Parameter Record_Data
        /// <summary>
        /// <para>
        /// <para>The data blob, which is base64-encoded when the blob is serialized. The maximum size
        /// of the data blob, before base64-encoding, is 1,000 KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream Record_Data { get; set; }
        #endregion

        #region Parameter Record_Text 
        /// <summary>
        /// Text string containing the data to send. Use this parameter, or
        /// Record_Data, to define the data to be written.
        /// </summary>
        [System.Management.Automation.Parameter]

        public System.String Record_Text { get; set; }
        #endregion

        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryStreamName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeliveryStreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINFRecord (PutRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };

            context.DeliveryStreamName = this.DeliveryStreamName;
            if (ParameterWasBound("Record_Text"))
                context.Record_Text = Record_Text;
            else
                context.Record_Data = this.Record_Data;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KinesisFirehose.Model.PutRecordRequest();
            
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            
             // populate Record
            bool requestRecordIsNull = true;
            request.Record = new Amazon.KinesisFirehose.Model.Record();
            System.IO.MemoryStream requestRecord_record_Data = null;
            if (cmdletContext.Record_Text != null)
            {
                var ms = new MemoryStream();
                var stringBytes = System.Text.Encoding.UTF8.GetBytes(cmdletContext.Record_Text);
                ms.Write(stringBytes, 0, stringBytes.Length);
                ms.Seek(0, SeekOrigin.Begin);

                requestRecord_record_Data = ms;
            }
            else if (cmdletContext.Record_Data != null)
            {
                requestRecord_record_Data = cmdletContext.Record_Data;
            }

            if (requestRecord_record_Data != null)
            {
                request.Record.Data = requestRecord_record_Data;
                requestRecordIsNull = false;
            }
             // determine if request.Record should be set to null
            if (requestRecordIsNull)
            {
                request.Record = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutRecord(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RecordId;
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
            public System.String DeliveryStreamName { get; set; }
            public System.IO.MemoryStream Record_Data { get; set; }
            public System.String Record_Text { get; set; }
        }
        
    }
}
