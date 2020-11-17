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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Creates a mapping between an event source and an AWS Lambda function. Lambda reads
    /// items from the event source and triggers the function.
    /// 
    ///  
    /// <para>
    /// For details about each event source type, see the following topics.
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html">Using AWS Lambda
    /// with Amazon DynamoDB</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html">Using AWS
    /// Lambda with Amazon Kinesis</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-sqs.html">Using AWS Lambda
    /// with Amazon SQS</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-mq.html">Using AWS Lambda
    /// with Amazon MQ</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-msk.html">Using AWS Lambda
    /// with Amazon MSK</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/kafka-smaa.html">Using AWS
    /// Lambda with Self-Managed Apache Kafka</a></para></li></ul><para>
    /// The following error handling options are only available for stream sources (DynamoDB
    /// and Kinesis):
    /// </para><ul><li><para><code>BisectBatchOnFunctionError</code> - If the function returns an error, split
    /// the batch in two and retry.
    /// </para></li><li><para><code>DestinationConfig</code> - Send discarded records to an Amazon SQS queue or
    /// Amazon SNS topic.
    /// </para></li><li><para><code>MaximumRecordAgeInSeconds</code> - Discard records older than the specified
    /// age. The default value is infinite (-1). When set to infinite (-1), failed records
    /// are retried until the record expires
    /// </para></li><li><para><code>MaximumRetryAttempts</code> - Discard records after the specified number of
    /// retries. The default value is infinite (-1). When set to infinite (-1), failed records
    /// are retried until the record expires.
    /// </para></li><li><para><code>ParallelizationFactor</code> - Process multiple batches from each shard concurrently.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateEventSourceMappingResponse")]
    [AWSCmdlet("Calls the AWS Lambda CreateEventSourceMapping API operation.", Operation = new[] {"CreateEventSourceMapping"}, SelectReturnType = typeof(Amazon.Lambda.Model.CreateEventSourceMappingResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateEventSourceMappingResponse",
        "This cmdlet returns an Amazon.Lambda.Model.CreateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to retrieve in a single batch.</para><ul><li><para><b>Amazon Kinesis</b> - Default 100. Max 10,000.</para></li><li><para><b>Amazon DynamoDB Streams</b> - Default 100. Max 1,000.</para></li><li><para><b>Amazon Simple Queue Service</b> - Default 10. For standard queues the max is 10,000.
        /// For FIFO queues the max is 10.</para></li><li><para><b>Amazon Managed Streaming for Apache Kafka</b> - Default 100. Max 10,000.</para></li><li><para><b>Self-Managed Apache Kafka</b> - Default 100. Max 10,000.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BatchSize { get; set; }
        #endregion
        
        #region Parameter BisectBatchOnFunctionError
        /// <summary>
        /// <para>
        /// <para>(Streams) If the function returns an error, split the batch in two and retry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BisectBatchOnFunctionError { get; set; }
        #endregion
        
        #region Parameter OnFailure_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfig_OnFailure_Destination")]
        public System.String OnFailure_Destination { get; set; }
        #endregion
        
        #region Parameter OnSuccess_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfig_OnSuccess_Destination")]
        public System.String OnSuccess_Destination { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>If true, the event source mapping is active. Set to false to pause polling and invocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter SelfManagedEventSource_Endpoint
        /// <summary>
        /// <para>
        /// <para>The list of bootstrap servers for your Kafka brokers in the following format: <code>"KAFKA_BOOTSTRAP_SERVERS":
        /// ["abc.xyz.com:xxxx","abc2.xyz.com:xxxx"]</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedEventSource_Endpoints")]
        public System.Collections.Hashtable SelfManagedEventSource_Endpoint { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the event source.</para><ul><li><para><b>Amazon Kinesis</b> - The ARN of the data stream or a stream consumer.</para></li><li><para><b>Amazon DynamoDB Streams</b> - The ARN of the stream.</para></li><li><para><b>Amazon Simple Queue Service</b> - The ARN of the queue.</para></li><li><para><b>Amazon Managed Streaming for Apache Kafka</b> - The ARN of the cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.CreateEventSourceMappingRequest.FunctionName
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionResponseType
        /// <summary>
        /// <para>
        /// <para>(Streams) A list of current response type enums applied to the event source mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionResponseTypes")]
        public System.String[] FunctionResponseType { get; set; }
        #endregion
        
        #region Parameter MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>(Streams and SQS standard queues) The maximum amount of time to gather records before
        /// invoking the function, in seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumBatchingWindowInSeconds")]
        public System.Int32? MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter MaximumRecordAgeInSecond
        /// <summary>
        /// <para>
        /// <para>(Streams) Discard records older than the specified age. The default value is infinite
        /// (-1).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRecordAgeInSeconds")]
        public System.Int32? MaximumRecordAgeInSecond { get; set; }
        #endregion
        
        #region Parameter MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>(Streams) Discard records after the specified number of retries. The default value
        /// is infinite (-1). When set to infinite (-1), failed records will be retried until
        /// the record expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRetryAttempts")]
        public System.Int32? MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter ParallelizationFactor
        /// <summary>
        /// <para>
        /// <para>(Streams) The number of batches to process from each shard concurrently.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ParallelizationFactor { get; set; }
        #endregion
        
        #region Parameter Queue
        /// <summary>
        /// <para>
        /// <para> (MQ) The name of the Amazon MQ broker destination queue to consume. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Queues")]
        public System.String[] Queue { get; set; }
        #endregion
        
        #region Parameter SourceAccessConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of the authentication protocol, or the VPC components to secure your event
        /// source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceAccessConfigurations")]
        public Amazon.Lambda.Model.SourceAccessConfiguration[] SourceAccessConfiguration { get; set; }
        #endregion
        
        #region Parameter StartingPosition
        /// <summary>
        /// <para>
        /// <para>The position in a stream from which to start reading. Required for Amazon Kinesis,
        /// Amazon DynamoDB, and Amazon MSK Streams sources. <code>AT_TIMESTAMP</code> is only
        /// supported for Amazon Kinesis streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.EventSourcePosition")]
        public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
        #endregion
        
        #region Parameter StartingPositionTimestamp
        /// <summary>
        /// <para>
        /// <para>With <code>StartingPosition</code> set to <code>AT_TIMESTAMP</code>, the time from
        /// which to start reading.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartingPositionTimestamp { get; set; }
        #endregion
        
        #region Parameter Topic
        /// <summary>
        /// <para>
        /// <para>The name of the Kafka topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Topics")]
        public System.String[] Topic { get; set; }
        #endregion
        
        #region Parameter TumblingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>(Streams) The duration of a processing window in seconds. The range is between 1 second
        /// up to 15 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TumblingWindowInSeconds")]
        public System.Int32? TumblingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.CreateEventSourceMappingResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.CreateEventSourceMappingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMEventSourceMapping (CreateEventSourceMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.CreateEventSourceMappingResponse, NewLMEventSourceMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BatchSize = this.BatchSize;
            context.BisectBatchOnFunctionError = this.BisectBatchOnFunctionError;
            context.OnFailure_Destination = this.OnFailure_Destination;
            context.OnSuccess_Destination = this.OnSuccess_Destination;
            context.Enabled = this.Enabled;
            context.EventSourceArn = this.EventSourceArn;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FunctionResponseType != null)
            {
                context.FunctionResponseType = new List<System.String>(this.FunctionResponseType);
            }
            context.MaximumBatchingWindowInSecond = this.MaximumBatchingWindowInSecond;
            context.MaximumRecordAgeInSecond = this.MaximumRecordAgeInSecond;
            context.MaximumRetryAttempt = this.MaximumRetryAttempt;
            context.ParallelizationFactor = this.ParallelizationFactor;
            if (this.Queue != null)
            {
                context.Queue = new List<System.String>(this.Queue);
            }
            if (this.SelfManagedEventSource_Endpoint != null)
            {
                context.SelfManagedEventSource_Endpoint = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.SelfManagedEventSource_Endpoint.Keys)
                {
                    object hashValue = this.SelfManagedEventSource_Endpoint[hashKey];
                    if (hashValue == null)
                    {
                        context.SelfManagedEventSource_Endpoint.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.SelfManagedEventSource_Endpoint.Add((String)hashKey, valueSet);
                }
            }
            if (this.SourceAccessConfiguration != null)
            {
                context.SourceAccessConfiguration = new List<Amazon.Lambda.Model.SourceAccessConfiguration>(this.SourceAccessConfiguration);
            }
            context.StartingPosition = this.StartingPosition;
            context.StartingPositionTimestamp = this.StartingPositionTimestamp;
            if (this.Topic != null)
            {
                context.Topic = new List<System.String>(this.Topic);
            }
            context.TumblingWindowInSecond = this.TumblingWindowInSecond;
            
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
            var request = new Amazon.Lambda.Model.CreateEventSourceMappingRequest();
            
            if (cmdletContext.BatchSize != null)
            {
                request.BatchSize = cmdletContext.BatchSize.Value;
            }
            if (cmdletContext.BisectBatchOnFunctionError != null)
            {
                request.BisectBatchOnFunctionError = cmdletContext.BisectBatchOnFunctionError.Value;
            }
            
             // populate DestinationConfig
            var requestDestinationConfigIsNull = true;
            request.DestinationConfig = new Amazon.Lambda.Model.DestinationConfig();
            Amazon.Lambda.Model.OnFailure requestDestinationConfig_destinationConfig_OnFailure = null;
            
             // populate OnFailure
            var requestDestinationConfig_destinationConfig_OnFailureIsNull = true;
            requestDestinationConfig_destinationConfig_OnFailure = new Amazon.Lambda.Model.OnFailure();
            System.String requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination = null;
            if (cmdletContext.OnFailure_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination = cmdletContext.OnFailure_Destination;
            }
            if (requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnFailure.Destination = requestDestinationConfig_destinationConfig_OnFailure_onFailure_Destination;
                requestDestinationConfig_destinationConfig_OnFailureIsNull = false;
            }
             // determine if requestDestinationConfig_destinationConfig_OnFailure should be set to null
            if (requestDestinationConfig_destinationConfig_OnFailureIsNull)
            {
                requestDestinationConfig_destinationConfig_OnFailure = null;
            }
            if (requestDestinationConfig_destinationConfig_OnFailure != null)
            {
                request.DestinationConfig.OnFailure = requestDestinationConfig_destinationConfig_OnFailure;
                requestDestinationConfigIsNull = false;
            }
            Amazon.Lambda.Model.OnSuccess requestDestinationConfig_destinationConfig_OnSuccess = null;
            
             // populate OnSuccess
            var requestDestinationConfig_destinationConfig_OnSuccessIsNull = true;
            requestDestinationConfig_destinationConfig_OnSuccess = new Amazon.Lambda.Model.OnSuccess();
            System.String requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination = null;
            if (cmdletContext.OnSuccess_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination = cmdletContext.OnSuccess_Destination;
            }
            if (requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination != null)
            {
                requestDestinationConfig_destinationConfig_OnSuccess.Destination = requestDestinationConfig_destinationConfig_OnSuccess_onSuccess_Destination;
                requestDestinationConfig_destinationConfig_OnSuccessIsNull = false;
            }
             // determine if requestDestinationConfig_destinationConfig_OnSuccess should be set to null
            if (requestDestinationConfig_destinationConfig_OnSuccessIsNull)
            {
                requestDestinationConfig_destinationConfig_OnSuccess = null;
            }
            if (requestDestinationConfig_destinationConfig_OnSuccess != null)
            {
                request.DestinationConfig.OnSuccess = requestDestinationConfig_destinationConfig_OnSuccess;
                requestDestinationConfigIsNull = false;
            }
             // determine if request.DestinationConfig should be set to null
            if (requestDestinationConfigIsNull)
            {
                request.DestinationConfig = null;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.FunctionResponseType != null)
            {
                request.FunctionResponseTypes = cmdletContext.FunctionResponseType;
            }
            if (cmdletContext.MaximumBatchingWindowInSecond != null)
            {
                request.MaximumBatchingWindowInSeconds = cmdletContext.MaximumBatchingWindowInSecond.Value;
            }
            if (cmdletContext.MaximumRecordAgeInSecond != null)
            {
                request.MaximumRecordAgeInSeconds = cmdletContext.MaximumRecordAgeInSecond.Value;
            }
            if (cmdletContext.MaximumRetryAttempt != null)
            {
                request.MaximumRetryAttempts = cmdletContext.MaximumRetryAttempt.Value;
            }
            if (cmdletContext.ParallelizationFactor != null)
            {
                request.ParallelizationFactor = cmdletContext.ParallelizationFactor.Value;
            }
            if (cmdletContext.Queue != null)
            {
                request.Queues = cmdletContext.Queue;
            }
            
             // populate SelfManagedEventSource
            var requestSelfManagedEventSourceIsNull = true;
            request.SelfManagedEventSource = new Amazon.Lambda.Model.SelfManagedEventSource();
            Dictionary<System.String, List<System.String>> requestSelfManagedEventSource_selfManagedEventSource_Endpoint = null;
            if (cmdletContext.SelfManagedEventSource_Endpoint != null)
            {
                requestSelfManagedEventSource_selfManagedEventSource_Endpoint = cmdletContext.SelfManagedEventSource_Endpoint;
            }
            if (requestSelfManagedEventSource_selfManagedEventSource_Endpoint != null)
            {
                request.SelfManagedEventSource.Endpoints = requestSelfManagedEventSource_selfManagedEventSource_Endpoint;
                requestSelfManagedEventSourceIsNull = false;
            }
             // determine if request.SelfManagedEventSource should be set to null
            if (requestSelfManagedEventSourceIsNull)
            {
                request.SelfManagedEventSource = null;
            }
            if (cmdletContext.SourceAccessConfiguration != null)
            {
                request.SourceAccessConfigurations = cmdletContext.SourceAccessConfiguration;
            }
            if (cmdletContext.StartingPosition != null)
            {
                request.StartingPosition = cmdletContext.StartingPosition;
            }
            if (cmdletContext.StartingPositionTimestamp != null)
            {
                request.StartingPositionTimestamp = cmdletContext.StartingPositionTimestamp.Value;
            }
            if (cmdletContext.Topic != null)
            {
                request.Topics = cmdletContext.Topic;
            }
            if (cmdletContext.TumblingWindowInSecond != null)
            {
                request.TumblingWindowInSeconds = cmdletContext.TumblingWindowInSecond.Value;
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
        
        private Amazon.Lambda.Model.CreateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.CreateEventSourceMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "CreateEventSourceMapping");
            try
            {
                #if DESKTOP
                return client.CreateEventSourceMapping(request);
                #elif CORECLR
                return client.CreateEventSourceMappingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? BatchSize { get; set; }
            public System.Boolean? BisectBatchOnFunctionError { get; set; }
            public System.String OnFailure_Destination { get; set; }
            public System.String OnSuccess_Destination { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.String FunctionName { get; set; }
            public List<System.String> FunctionResponseType { get; set; }
            public System.Int32? MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? MaximumRecordAgeInSecond { get; set; }
            public System.Int32? MaximumRetryAttempt { get; set; }
            public System.Int32? ParallelizationFactor { get; set; }
            public List<System.String> Queue { get; set; }
            public Dictionary<System.String, List<System.String>> SelfManagedEventSource_Endpoint { get; set; }
            public List<Amazon.Lambda.Model.SourceAccessConfiguration> SourceAccessConfiguration { get; set; }
            public Amazon.Lambda.EventSourcePosition StartingPosition { get; set; }
            public System.DateTime? StartingPositionTimestamp { get; set; }
            public List<System.String> Topic { get; set; }
            public System.Int32? TumblingWindowInSecond { get; set; }
            public System.Func<Amazon.Lambda.Model.CreateEventSourceMappingResponse, NewLMEventSourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
