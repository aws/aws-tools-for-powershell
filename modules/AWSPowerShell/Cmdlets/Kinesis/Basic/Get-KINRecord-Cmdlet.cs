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
    /// Gets data records from a Kinesis data stream's shard.
    /// 
    ///  
    /// <para>
    /// Specify a shard iterator using the <code>ShardIterator</code> parameter. The shard
    /// iterator specifies the position in the shard from which you want to start reading
    /// data records sequentially. If there are no records available in the portion of the
    /// shard that the iterator points to, <a>GetRecords</a> returns an empty list. It might
    /// take multiple calls to get to a portion of the shard that contains records.
    /// </para><para>
    /// You can scale by provisioning multiple shards per stream while considering service
    /// limits (for more information, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Amazon
    /// Kinesis Data Streams Limits</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>).
    /// Your application should have one thread per shard, each reading continuously from
    /// its stream. To read from a stream continually, call <a>GetRecords</a> in a loop. Use
    /// <a>GetShardIterator</a> to get the shard iterator to specify in the first <a>GetRecords</a>
    /// call. <a>GetRecords</a> returns a new shard iterator in <code>NextShardIterator</code>.
    /// Specify the shard iterator returned in <code>NextShardIterator</code> in subsequent
    /// calls to <a>GetRecords</a>. If the shard has been closed, the shard iterator can't
    /// return more data and <a>GetRecords</a> returns <code>null</code> in <code>NextShardIterator</code>.
    /// You can terminate the loop when the shard is closed, or when the shard iterator reaches
    /// the record with the sequence number or other attribute that marks it as the last record
    /// to process.
    /// </para><para>
    /// Each data record can be up to 1 MiB in size, and each shard can read up to 2 MiB per
    /// second. You can ensure that your calls don't exceed the maximum supported size or
    /// throughput by using the <code>Limit</code> parameter to specify the maximum number
    /// of records that <a>GetRecords</a> can return. Consider your average record size when
    /// determining this limit. The maximum number of records that can be returned per call
    /// is 10,000.
    /// </para><para>
    /// The size of the data returned by <a>GetRecords</a> varies depending on the utilization
    /// of the shard. The maximum size of data that <a>GetRecords</a> can return is 10 MiB.
    /// If a call returns this amount of data, subsequent calls made within the next 5 seconds
    /// throw <code>ProvisionedThroughputExceededException</code>. If there is insufficient
    /// provisioned throughput on the stream, subsequent calls made within the next 1 second
    /// throw <code>ProvisionedThroughputExceededException</code>. <a>GetRecords</a> doesn't
    /// return any data when it throws an exception. For this reason, we recommend that you
    /// wait 1 second between calls to <a>GetRecords</a>. However, it's possible that the
    /// application will get exceptions for longer than 1 second.
    /// </para><para>
    /// To detect whether the application is falling behind in processing, you can use the
    /// <code>MillisBehindLatest</code> response attribute. You can also monitor the stream
    /// using CloudWatch metrics and other mechanisms (see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/monitoring.html">Monitoring</a>
    /// in the <i>Amazon Kinesis Data Streams Developer Guide</i>).
    /// </para><para>
    /// Each Amazon Kinesis record includes a value, <code>ApproximateArrivalTimestamp</code>,
    /// that is set when a stream successfully receives and stores a record. This is commonly
    /// referred to as a server-side time stamp, whereas a client-side time stamp is set when
    /// a data producer creates or sends the record to a stream (a data producer is any data
    /// source putting data records into a stream, for example with <a>PutRecords</a>). The
    /// time stamp has millisecond precision. There are no guarantees about the time stamp
    /// accuracy, or that the time stamp is always increasing. For example, records in a shard
    /// or across a stream might have time stamps that are out of order.
    /// </para><para>
    /// This operation has a limit of five transactions per second per shard.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINRecord")]
    [OutputType("Amazon.Kinesis.Model.GetRecordsResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis GetRecords API operation.", Operation = new[] {"GetRecords"}, SelectReturnType = typeof(Amazon.Kinesis.Model.GetRecordsResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.GetRecordsResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.GetRecordsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINRecordCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter ShardIterator
        /// <summary>
        /// <para>
        /// <para>The position in the shard from which you want to start sequentially reading data records.
        /// A shard iterator specifies this position using the sequence number of a data record
        /// in the shard.</para>
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
        public System.String ShardIterator { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to return. Specify a value of up to 10,000. If you specify
        /// a value that is greater than 10,000, <a>GetRecords</a> throws <code>InvalidArgumentException</code>.
        /// The default value is 10,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.GetRecordsResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.GetRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ShardIterator parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ShardIterator' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ShardIterator' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.GetRecordsResponse, GetKINRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ShardIterator;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Limit = this.Limit;
            context.ShardIterator = this.ShardIterator;
            #if MODULAR
            if (this.ShardIterator == null && ParameterWasBound(nameof(this.ShardIterator)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardIterator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Kinesis.Model.GetRecordsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.ShardIterator != null)
            {
                request.ShardIterator = cmdletContext.ShardIterator;
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
        
        private Amazon.Kinesis.Model.GetRecordsResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.GetRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "GetRecords");
            try
            {
                #if DESKTOP
                return client.GetRecords(request);
                #elif CORECLR
                return client.GetRecordsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Limit { get; set; }
            public System.String ShardIterator { get; set; }
            public System.Func<Amazon.Kinesis.Model.GetRecordsResponse, GetKINRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
