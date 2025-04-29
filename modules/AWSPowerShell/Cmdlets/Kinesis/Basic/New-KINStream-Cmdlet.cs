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
    /// Creates a Kinesis data stream. A stream captures and transports data records that
    /// are continuously emitted from different data sources or <i>producers</i>. Scale-out
    /// within a stream is explicitly supported by means of shards, which are uniquely identified
    /// groups of data records in a stream.
    /// 
    ///  
    /// <para>
    /// You can create your data stream using either on-demand or provisioned capacity mode.
    /// Data streams with an on-demand mode require no capacity planning and automatically
    /// scale to handle gigabytes of write and read throughput per minute. With the on-demand
    /// mode, Kinesis Data Streams automatically manages the shards in order to provide the
    /// necessary throughput. For the data streams with a provisioned mode, you must specify
    /// the number of shards for the data stream. Each shard can support reads up to five
    /// transactions per second, up to a maximum data read total of 2 MiB per second. Each
    /// shard can support writes up to 1,000 records per second, up to a maximum data write
    /// total of 1 MiB per second. If the amount of data input increases or decreases, you
    /// can add or remove shards.
    /// </para><para>
    /// The stream name identifies the stream. The name is scoped to the Amazon Web Services
    /// account used by the application. It is also scoped by Amazon Web Services Region.
    /// That is, two streams in two different accounts can have the same name, and two streams
    /// in the same account, but in two different Regions, can have the same name.
    /// </para><para><c>CreateStream</c> is an asynchronous operation. Upon receiving a <c>CreateStream</c>
    /// request, Kinesis Data Streams immediately returns and sets the stream status to <c>CREATING</c>.
    /// After the stream is created, Kinesis Data Streams sets the stream status to <c>ACTIVE</c>.
    /// You should perform read and write operations only on an <c>ACTIVE</c> stream. 
    /// </para><para>
    /// You receive a <c>LimitExceededException</c> when making a <c>CreateStream</c> request
    /// when you try to do one of the following:
    /// </para><ul><li><para>
    /// Have more than five streams in the <c>CREATING</c> state at any point in time.
    /// </para></li><li><para>
    /// Create more shards than are authorized for your account.
    /// </para></li></ul><para>
    /// For the default shard limit for an Amazon Web Services account, see <a href="https://docs.aws.amazon.com/kinesis/latest/dev/service-sizes-and-limits.html">Amazon
    /// Kinesis Data Streams Limits</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.
    /// To increase this limit, <a href="https://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">contact
    /// Amazon Web Services Support</a>.
    /// </para><para>
    /// You can use <a>DescribeStreamSummary</a> to check the stream status, which is returned
    /// in <c>StreamStatus</c>.
    /// </para><para><a>CreateStream</a> has a limit of five transactions per second per account.
    /// </para><para>
    /// You can add tags to the stream when making a <c>CreateStream</c> request by setting
    /// the <c>Tags</c> parameter. If you pass <c>Tags</c> parameter, in addition to having
    /// <c>kinesis:createStream</c> permission, you must also have <c>kinesis:addTagsToStream</c>
    /// permission for the stream that will be created. Tags will take effect from the <c>CREATING</c>
    /// status of the stream. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis CreateStream API operation.", Operation = new[] {"CreateStream"}, SelectReturnType = typeof(Amazon.Kinesis.Model.CreateStreamResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.CreateStreamResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.CreateStreamResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewKINStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ShardCount
        /// <summary>
        /// <para>
        /// <para>The number of shards that the stream will use. The throughput of the stream is a function
        /// of the number of shards; more shards are required for greater provisioned throughput.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? ShardCount { get; set; }
        #endregion
        
        #region Parameter StreamModeDetails_StreamMode
        /// <summary>
        /// <para>
        /// <para> Specifies the capacity mode to which you want to set your data stream. Currently,
        /// in Kinesis Data Streams, you can choose between an <b>on-demand</b> capacity mode
        /// and a <b>provisioned</b> capacity mode for your data streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kinesis.StreamMode")]
        public Amazon.Kinesis.StreamMode StreamModeDetails_StreamMode { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>A name to identify the stream. The stream name is scoped to the Amazon Web Services
        /// account used by the application that creates the stream. It is also scoped by Amazon
        /// Web Services Region. That is, two streams in two different Amazon Web Services accounts
        /// can have the same name. Two streams in the same Amazon Web Services account but in
        /// two different Regions can also have the same name.</para>
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
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of up to 10 key-value pairs to use to create the tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.CreateStreamResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINStream (CreateStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.CreateStreamResponse, NewKINStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ShardCount = this.ShardCount;
            context.StreamModeDetails_StreamMode = this.StreamModeDetails_StreamMode;
            context.StreamName = this.StreamName;
            #if MODULAR
            if (this.StreamName == null && ParameterWasBound(nameof(this.StreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Kinesis.Model.CreateStreamRequest();
            
            if (cmdletContext.ShardCount != null)
            {
                request.ShardCount = cmdletContext.ShardCount.Value;
            }
            
             // populate StreamModeDetails
            var requestStreamModeDetailsIsNull = true;
            request.StreamModeDetails = new Amazon.Kinesis.Model.StreamModeDetails();
            Amazon.Kinesis.StreamMode requestStreamModeDetails_streamModeDetails_StreamMode = null;
            if (cmdletContext.StreamModeDetails_StreamMode != null)
            {
                requestStreamModeDetails_streamModeDetails_StreamMode = cmdletContext.StreamModeDetails_StreamMode;
            }
            if (requestStreamModeDetails_streamModeDetails_StreamMode != null)
            {
                request.StreamModeDetails.StreamMode = requestStreamModeDetails_streamModeDetails_StreamMode;
                requestStreamModeDetailsIsNull = false;
            }
             // determine if request.StreamModeDetails should be set to null
            if (requestStreamModeDetailsIsNull)
            {
                request.StreamModeDetails = null;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Kinesis.Model.CreateStreamResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.CreateStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "CreateStream");
            try
            {
                return client.CreateStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ShardCount { get; set; }
            public Amazon.Kinesis.StreamMode StreamModeDetails_StreamMode { get; set; }
            public System.String StreamName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kinesis.Model.CreateStreamResponse, NewKINStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
