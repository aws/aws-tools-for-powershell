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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Writes a single data record into an Amazon Kinesis Data Firehose delivery stream.
    /// To write multiple data records into a delivery stream, use <a>PutRecordBatch</a>.
    /// Applications using these operations are referred to as producers.
    /// 
    ///  
    /// <para>
    /// By default, each delivery stream can take in up to 2,000 transactions per second,
    /// 5,000 records per second, or 5 MB per second. If you use <a>PutRecord</a> and <a>PutRecordBatch</a>,
    /// the limits are an aggregate across these two operations for each delivery stream.
    /// For more information about limits and how to request an increase, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/limits.html">Amazon
    /// Kinesis Data Firehose Limits</a>. 
    /// </para><para>
    /// You must specify the name of the delivery stream and the data record when using <a>PutRecord</a>.
    /// The data record consists of a data blob that can be up to 1,000 KiB in size, and any
    /// kind of data. For example, it can be a segment from a log file, geographic location
    /// data, website clickstream data, and so on.
    /// </para><para>
    /// Kinesis Data Firehose buffers records before delivering them to the destination. To
    /// disambiguate the data blobs at the destination, a common solution is to use delimiters
    /// in the data, such as a newline (<code>\n</code>) or some other character unique within
    /// the data. This allows the consumer application to parse individual data items when
    /// reading the data from the destination.
    /// </para><para>
    /// The <code>PutRecord</code> operation returns a <code>RecordId</code>, which is a unique
    /// string assigned to each record. Producer applications can use this ID for purposes
    /// such as auditability and investigation.
    /// </para><para>
    /// If the <code>PutRecord</code> operation throws a <code>ServiceUnavailableException</code>,
    /// back off and retry. If the exception persists, it is possible that the throughput
    /// limits have been exceeded for the delivery stream. 
    /// </para><para>
    /// Data records sent to Kinesis Data Firehose are stored for 24 hours from the time they
    /// are added to a delivery stream as it tries to send the records to the destination.
    /// If the destination is unreachable for more than 24 hours, the data is no longer available.
    /// </para><important><para>
    /// Don't concatenate two or more base64 strings to form the data fields of your records.
    /// Instead, concatenate the raw data, then perform base64 encoding.
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "KINFRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="FromBlob")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose PutRecord API operation.", Operation = new[] {"PutRecord"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.PutRecordResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisFirehose.Model.PutRecordResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisFirehose.Model.PutRecordResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteKINFRecordCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter Record_Data
        /// <summary>
        /// <para>
        /// <para>The data blob, which is base64-encoded when the blob is serialized. The maximum size
        /// of the data blob, before base64-encoding, is 1,000 KiB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = "FromBlob")]
        [Alias("Blob")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Record_Data { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecordId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.PutRecordResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.PutRecordResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecordId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KINFRecord (PutRecord)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.PutRecordResponse, WriteKINFRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryStreamName = this.DeliveryStreamName;
            #if MODULAR
            if (this.DeliveryStreamName == null && ParameterWasBound(nameof(this.DeliveryStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Record_Data = this.Record_Data;
            #if MODULAR
            if (this.Record_Data == null && ParameterWasBound(nameof(this.Record_Data)))
            {
                WriteWarning("You are passing $null as a value for parameter Record_Data which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Record_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KinesisFirehose.Model.PutRecordRequest();
                
                if (cmdletContext.DeliveryStreamName != null)
                {
                    request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
                }
                
                 // populate Record
                var requestRecordIsNull = true;
                request.Record = new Amazon.KinesisFirehose.Model.Record();
                System.IO.MemoryStream requestRecord_record_Data = null;
                if (cmdletContext.Record_Data != null)
                {
                    _Record_DataStream = new System.IO.MemoryStream(cmdletContext.Record_Data);
                    requestRecord_record_Data = _Record_DataStream;
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
                if( _Record_DataStream != null)
                {
                    _Record_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KinesisFirehose.Model.PutRecordResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.PutRecordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "PutRecord");
            try
            {
                #if DESKTOP
                return client.PutRecord(request);
                #elif CORECLR
                return client.PutRecordAsync(request).GetAwaiter().GetResult();
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
            public System.String DeliveryStreamName { get; set; }
            public byte[] Record_Data { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.PutRecordResponse, WriteKINFRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecordId;
        }
        
    }
}
