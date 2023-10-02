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
    /// Updates an event source mapping. You can change the function that Lambda invokes,
    /// or pause invocation and resume later from the same location.
    /// 
    ///  
    /// <para>
    /// For details about how to configure different event sources, see the following topics.
    /// 
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html#services-dynamodb-eventsourcemapping">
    /// Amazon DynamoDB Streams</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html#services-kinesis-eventsourcemapping">
    /// Amazon Kinesis</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-sqs.html#events-sqs-eventsource">
    /// Amazon SQS</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-mq.html#services-mq-eventsourcemapping">
    /// Amazon MQ and RabbitMQ</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-msk.html"> Amazon MSK</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/kafka-smaa.html"> Apache Kafka</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-documentdb.html"> Amazon
    /// DocumentDB</a></para></li></ul><para>
    /// The following error handling options are available only for stream sources (DynamoDB
    /// and Kinesis):
    /// </para><ul><li><para><code>BisectBatchOnFunctionError</code> – If the function returns an error, split
    /// the batch in two and retry.
    /// </para></li><li><para><code>DestinationConfig</code> – Send discarded records to an Amazon SQS queue or
    /// Amazon SNS topic.
    /// </para></li><li><para><code>MaximumRecordAgeInSeconds</code> – Discard records older than the specified
    /// age. The default value is infinite (-1). When set to infinite (-1), failed records
    /// are retried until the record expires
    /// </para></li><li><para><code>MaximumRetryAttempts</code> – Discard records after the specified number of
    /// retries. The default value is infinite (-1). When set to infinite (-1), failed records
    /// are retried until the record expires.
    /// </para></li><li><para><code>ParallelizationFactor</code> – Process multiple batches from each shard concurrently.
    /// </para></li></ul><para>
    /// For information about which configuration parameters apply to each event source, see
    /// the following topics.
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html#services-ddb-params">
    /// Amazon DynamoDB Streams</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html#services-kinesis-params">
    /// Amazon Kinesis</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-sqs.html#services-sqs-params">
    /// Amazon SQS</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-mq.html#services-mq-params">
    /// Amazon MQ and RabbitMQ</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-msk.html#services-msk-parms">
    /// Amazon MSK</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kafka.html#services-kafka-parms">
    /// Apache Kafka</a></para></li><li><para><a href="https://docs.aws.amazon.com/lambda/latest/dg/with-documentdb.html#docdb-configuration">
    /// Amazon DocumentDB</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateEventSourceMappingResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateEventSourceMapping API operation.", Operation = new[] {"UpdateEventSourceMapping"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateEventSourceMappingResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateEventSourceMappingResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records in each batch that Lambda pulls from your stream or
        /// queue and sends to your function. Lambda passes all of the records in the batch to
        /// the function in a single call, up to the payload limit for synchronous invocation
        /// (6 MB).</para><ul><li><para><b>Amazon Kinesis</b> – Default 100. Max 10,000.</para></li><li><para><b>Amazon DynamoDB Streams</b> – Default 100. Max 10,000.</para></li><li><para><b>Amazon Simple Queue Service</b> – Default 10. For standard queues the max is 10,000.
        /// For FIFO queues the max is 10.</para></li><li><para><b>Amazon Managed Streaming for Apache Kafka</b> – Default 100. Max 10,000.</para></li><li><para><b>Self-managed Apache Kafka</b> – Default 100. Max 10,000.</para></li><li><para><b>Amazon MQ (ActiveMQ and RabbitMQ)</b> – Default 100. Max 10,000.</para></li><li><para><b>DocumentDB</b> – Default 100. Max 10,000.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BatchSize { get; set; }
        #endregion
        
        #region Parameter BisectBatchOnFunctionError
        /// <summary>
        /// <para>
        /// <para>(Kinesis and DynamoDB Streams only) If the function returns an error, split the batch
        /// in two and retry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BisectBatchOnFunctionError { get; set; }
        #endregion
        
        #region Parameter DocumentDBEventSourceConfig_CollectionName
        /// <summary>
        /// <para>
        /// <para> The name of the collection to consume within the database. If you do not specify
        /// a collection, Lambda consumes all collections. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentDBEventSourceConfig_CollectionName { get; set; }
        #endregion
        
        #region Parameter DocumentDBEventSourceConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para> The name of the database to consume within the DocumentDB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentDBEventSourceConfig_DatabaseName { get; set; }
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
        /// <para>When true, the event source mapping is active. When false, Lambda pauses polling and
        /// invocation.</para><para>Default: True</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Filter
        /// <summary>
        /// <para>
        /// <para> A list of filters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Filters")]
        public Amazon.Lambda.Model.Filter[] FilterCriteria_Filter { get; set; }
        #endregion
        
        #region Parameter DocumentDBEventSourceConfig_FullDocument
        /// <summary>
        /// <para>
        /// <para> Determines what DocumentDB sends to your event stream during document update operations.
        /// If set to UpdateLookup, DocumentDB sends a delta describing the changes, along with
        /// a copy of the entire document. Otherwise, DocumentDB sends only a partial document
        /// that contains the changes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.FullDocument")]
        public Amazon.Lambda.FullDocument DocumentDBEventSourceConfig_FullDocument { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the Lambda function.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <code>MyFunction</code>.</para></li><li><para><b>Function ARN</b> – <code>arn:aws:lambda:us-west-2:123456789012:function:MyFunction</code>.</para></li><li><para><b>Version or Alias ARN</b> – <code>arn:aws:lambda:us-west-2:123456789012:function:MyFunction:PROD</code>.</para></li><li><para><b>Partial ARN</b> – <code>123456789012:function:MyFunction</code>.</para></li></ul><para>The length constraint applies only to the full ARN. If you specify only the function
        /// name, it's limited to 64 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionResponseType
        /// <summary>
        /// <para>
        /// <para>(Kinesis, DynamoDB Streams, and Amazon SQS) A list of current response type enums
        /// applied to the event source mapping.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionResponseTypes")]
        public System.String[] FunctionResponseType { get; set; }
        #endregion
        
        #region Parameter MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that Lambda spends gathering records before
        /// invoking the function. You can configure <code>MaximumBatchingWindowInSeconds</code>
        /// to any value from 0 seconds to 300 seconds in increments of seconds.</para><para>For streams and Amazon SQS event sources, the default batching window is 0 seconds.
        /// For Amazon MSK, Self-managed Apache Kafka, Amazon MQ, and DocumentDB event sources,
        /// the default batching window is 500 ms. Note that because you can only change <code>MaximumBatchingWindowInSeconds</code>
        /// in increments of seconds, you cannot revert back to the 500 ms default batching window
        /// after you have changed it. To restore the default batching window, you must create
        /// a new event source mapping.</para><para>Related setting: For streams and Amazon SQS event sources, when you set <code>BatchSize</code>
        /// to a value greater than 10, you must set <code>MaximumBatchingWindowInSeconds</code>
        /// to at least 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumBatchingWindowInSeconds")]
        public System.Int32? MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_MaximumConcurrency
        /// <summary>
        /// <para>
        /// <para>Limits the number of concurrent instances that the Amazon SQS event source can invoke.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_MaximumConcurrency { get; set; }
        #endregion
        
        #region Parameter MaximumRecordAgeInSecond
        /// <summary>
        /// <para>
        /// <para>(Kinesis and DynamoDB Streams only) Discard records older than the specified age.
        /// The default value is infinite (-1).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRecordAgeInSeconds")]
        public System.Int32? MaximumRecordAgeInSecond { get; set; }
        #endregion
        
        #region Parameter MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>(Kinesis and DynamoDB Streams only) Discard records after the specified number of
        /// retries. The default value is infinite (-1). When set to infinite (-1), failed records
        /// are retried until the record expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaximumRetryAttempts")]
        public System.Int32? MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter ParallelizationFactor
        /// <summary>
        /// <para>
        /// <para>(Kinesis and DynamoDB Streams only) The number of batches to process from each shard
        /// concurrently.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ParallelizationFactor { get; set; }
        #endregion
        
        #region Parameter SourceAccessConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of authentication protocols or VPC components required to secure your event
        /// source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceAccessConfigurations")]
        public Amazon.Lambda.Model.SourceAccessConfiguration[] SourceAccessConfiguration { get; set; }
        #endregion
        
        #region Parameter TumblingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>(Kinesis and DynamoDB Streams only) The duration in seconds of a processing window
        /// for DynamoDB and Kinesis Streams event sources. A value of 0 seconds indicates no
        /// tumbling window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TumblingWindowInSeconds")]
        public System.Int32? TumblingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter UUID
        /// <summary>
        /// <para>
        /// <para>The identifier of the event source mapping.</para>
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
        public System.String UUID { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateEventSourceMappingResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateEventSourceMappingResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMEventSourceMapping (UpdateEventSourceMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateEventSourceMappingResponse, UpdateLMEventSourceMappingCmdlet>(Select) ??
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
            context.DocumentDBEventSourceConfig_CollectionName = this.DocumentDBEventSourceConfig_CollectionName;
            context.DocumentDBEventSourceConfig_DatabaseName = this.DocumentDBEventSourceConfig_DatabaseName;
            context.DocumentDBEventSourceConfig_FullDocument = this.DocumentDBEventSourceConfig_FullDocument;
            context.Enabled = this.Enabled;
            if (this.FilterCriteria_Filter != null)
            {
                context.FilterCriteria_Filter = new List<Amazon.Lambda.Model.Filter>(this.FilterCriteria_Filter);
            }
            context.FunctionName = this.FunctionName;
            if (this.FunctionResponseType != null)
            {
                context.FunctionResponseType = new List<System.String>(this.FunctionResponseType);
            }
            context.MaximumBatchingWindowInSecond = this.MaximumBatchingWindowInSecond;
            context.MaximumRecordAgeInSecond = this.MaximumRecordAgeInSecond;
            context.MaximumRetryAttempt = this.MaximumRetryAttempt;
            context.ParallelizationFactor = this.ParallelizationFactor;
            context.ScalingConfig_MaximumConcurrency = this.ScalingConfig_MaximumConcurrency;
            if (this.SourceAccessConfiguration != null)
            {
                context.SourceAccessConfiguration = new List<Amazon.Lambda.Model.SourceAccessConfiguration>(this.SourceAccessConfiguration);
            }
            context.TumblingWindowInSecond = this.TumblingWindowInSecond;
            context.UUID = this.UUID;
            #if MODULAR
            if (this.UUID == null && ParameterWasBound(nameof(this.UUID)))
            {
                WriteWarning("You are passing $null as a value for parameter UUID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.UpdateEventSourceMappingRequest();
            
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
            
             // populate DocumentDBEventSourceConfig
            var requestDocumentDBEventSourceConfigIsNull = true;
            request.DocumentDBEventSourceConfig = new Amazon.Lambda.Model.DocumentDBEventSourceConfig();
            System.String requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_CollectionName = null;
            if (cmdletContext.DocumentDBEventSourceConfig_CollectionName != null)
            {
                requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_CollectionName = cmdletContext.DocumentDBEventSourceConfig_CollectionName;
            }
            if (requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_CollectionName != null)
            {
                request.DocumentDBEventSourceConfig.CollectionName = requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_CollectionName;
                requestDocumentDBEventSourceConfigIsNull = false;
            }
            System.String requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_DatabaseName = null;
            if (cmdletContext.DocumentDBEventSourceConfig_DatabaseName != null)
            {
                requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_DatabaseName = cmdletContext.DocumentDBEventSourceConfig_DatabaseName;
            }
            if (requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_DatabaseName != null)
            {
                request.DocumentDBEventSourceConfig.DatabaseName = requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_DatabaseName;
                requestDocumentDBEventSourceConfigIsNull = false;
            }
            Amazon.Lambda.FullDocument requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_FullDocument = null;
            if (cmdletContext.DocumentDBEventSourceConfig_FullDocument != null)
            {
                requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_FullDocument = cmdletContext.DocumentDBEventSourceConfig_FullDocument;
            }
            if (requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_FullDocument != null)
            {
                request.DocumentDBEventSourceConfig.FullDocument = requestDocumentDBEventSourceConfig_documentDBEventSourceConfig_FullDocument;
                requestDocumentDBEventSourceConfigIsNull = false;
            }
             // determine if request.DocumentDBEventSourceConfig should be set to null
            if (requestDocumentDBEventSourceConfigIsNull)
            {
                request.DocumentDBEventSourceConfig = null;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Lambda.Model.FilterCriteria();
            List<Amazon.Lambda.Model.Filter> requestFilterCriteria_filterCriteria_Filter = null;
            if (cmdletContext.FilterCriteria_Filter != null)
            {
                requestFilterCriteria_filterCriteria_Filter = cmdletContext.FilterCriteria_Filter;
            }
            if (requestFilterCriteria_filterCriteria_Filter != null)
            {
                request.FilterCriteria.Filters = requestFilterCriteria_filterCriteria_Filter;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
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
            
             // populate ScalingConfig
            var requestScalingConfigIsNull = true;
            request.ScalingConfig = new Amazon.Lambda.Model.ScalingConfig();
            System.Int32? requestScalingConfig_scalingConfig_MaximumConcurrency = null;
            if (cmdletContext.ScalingConfig_MaximumConcurrency != null)
            {
                requestScalingConfig_scalingConfig_MaximumConcurrency = cmdletContext.ScalingConfig_MaximumConcurrency.Value;
            }
            if (requestScalingConfig_scalingConfig_MaximumConcurrency != null)
            {
                request.ScalingConfig.MaximumConcurrency = requestScalingConfig_scalingConfig_MaximumConcurrency.Value;
                requestScalingConfigIsNull = false;
            }
             // determine if request.ScalingConfig should be set to null
            if (requestScalingConfigIsNull)
            {
                request.ScalingConfig = null;
            }
            if (cmdletContext.SourceAccessConfiguration != null)
            {
                request.SourceAccessConfigurations = cmdletContext.SourceAccessConfiguration;
            }
            if (cmdletContext.TumblingWindowInSecond != null)
            {
                request.TumblingWindowInSeconds = cmdletContext.TumblingWindowInSecond.Value;
            }
            if (cmdletContext.UUID != null)
            {
                request.UUID = cmdletContext.UUID;
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
        
        private Amazon.Lambda.Model.UpdateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateEventSourceMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateEventSourceMapping");
            try
            {
                #if DESKTOP
                return client.UpdateEventSourceMapping(request);
                #elif CORECLR
                return client.UpdateEventSourceMappingAsync(request).GetAwaiter().GetResult();
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
            public System.String DocumentDBEventSourceConfig_CollectionName { get; set; }
            public System.String DocumentDBEventSourceConfig_DatabaseName { get; set; }
            public Amazon.Lambda.FullDocument DocumentDBEventSourceConfig_FullDocument { get; set; }
            public System.Boolean? Enabled { get; set; }
            public List<Amazon.Lambda.Model.Filter> FilterCriteria_Filter { get; set; }
            public System.String FunctionName { get; set; }
            public List<System.String> FunctionResponseType { get; set; }
            public System.Int32? MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? MaximumRecordAgeInSecond { get; set; }
            public System.Int32? MaximumRetryAttempt { get; set; }
            public System.Int32? ParallelizationFactor { get; set; }
            public System.Int32? ScalingConfig_MaximumConcurrency { get; set; }
            public List<Amazon.Lambda.Model.SourceAccessConfiguration> SourceAccessConfiguration { get; set; }
            public System.Int32? TumblingWindowInSecond { get; set; }
            public System.String UUID { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateEventSourceMappingResponse, UpdateLMEventSourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
