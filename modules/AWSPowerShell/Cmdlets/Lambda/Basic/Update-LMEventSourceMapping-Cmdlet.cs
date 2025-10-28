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
using Amazon.Lambda;
using Amazon.Lambda.Model;

#pragma warning disable CS0618, CS0612
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
    /// The following error handling options are available only for DynamoDB and Kinesis event
    /// sources:
    /// </para><ul><li><para><c>BisectBatchOnFunctionError</c> – If the function returns an error, split the batch
    /// in two and retry.
    /// </para></li><li><para><c>MaximumRecordAgeInSeconds</c> – Discard records older than the specified age.
    /// The default value is infinite (-1). When set to infinite (-1), failed records are
    /// retried until the record expires
    /// </para></li><li><para><c>MaximumRetryAttempts</c> – Discard records after the specified number of retries.
    /// The default value is infinite (-1). When set to infinite (-1), failed records are
    /// retried until the record expires.
    /// </para></li><li><para><c>ParallelizationFactor</c> – Process multiple batches from each shard concurrently.
    /// </para></li></ul><para>
    /// For stream sources (DynamoDB, Kinesis, Amazon MSK, and self-managed Apache Kafka),
    /// the following option is also available:
    /// </para><ul><li><para><c>OnFailure</c> – Send discarded records to an Amazon SQS queue, Amazon SNS topic,
    /// or Amazon S3 bucket. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async-retain-records.html#invocation-async-destinations">Adding
    /// a destination</a>.
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
        "This cmdlet returns an Amazon.Lambda.Model.UpdateEventSourceMappingResponse object containing multiple properties."
    )]
    public partial class UpdateLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs
        /// <summary>
        /// <para>
        /// <para>An array of access configuration objects that tell Lambda how to authenticate with
        /// your schema registry.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig[] AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs { get; set; }
        #endregion
        
        #region Parameter SchemaRegistryConfig_AccessConfig
        /// <summary>
        /// <para>
        /// <para>An array of access configuration objects that tell Lambda how to authenticate with
        /// your schema registry.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs")]
        public Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig[] SchemaRegistryConfig_AccessConfig { get; set; }
        #endregion
        
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
        
        #region Parameter AmazonManagedKafkaEventSourceConfig_ConsumerGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier for the Kafka consumer group to join. The consumer group ID must be
        /// unique among all your Kafka event sources. After creating a Kafka event source mapping
        /// with the consumer group ID specified, you cannot update this value. For more information,
        /// see <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-msk.html#services-msk-consumer-group-id">Customizable
        /// consumer group ID</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonManagedKafkaEventSourceConfig_ConsumerGroupId { get; set; }
        #endregion
        
        #region Parameter SelfManagedKafkaEventSourceConfig_ConsumerGroupId
        /// <summary>
        /// <para>
        /// <para> The identifier for the Kafka consumer group to join. The consumer group ID must be
        /// unique among all your Kafka event sources. After creating a Kafka event source mapping
        /// with the consumer group ID specified, you cannot update this value. For more information,
        /// see <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kafka-process.html#services-smaa-topic-add">Customizable
        /// consumer group ID</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SelfManagedKafkaEventSourceConfig_ConsumerGroupId { get; set; }
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
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para><para>To retain records of unsuccessful <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async.html#invocation-async-destinations">asynchronous
        /// invocations</a>, you can configure an Amazon SNS topic, Amazon SQS queue, Amazon S3
        /// bucket, Lambda function, or Amazon EventBridge event bus as the destination.</para><note><para>Amazon SNS destinations have a message size limit of 256 KB. If the combined size
        /// of the function request and response payload exceeds the limit, Lambda will drop the
        /// payload when sending <c>OnFailure</c> event to the destination. For details on this
        /// behavior, refer to <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async-retain-records.html">Retaining
        /// records of asynchronous invocations</a>.</para></note><para>To retain records of failed invocations from <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kinesis.html">Kinesis</a>,
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-ddb.html">DynamoDB</a>,
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-kafka.html#services-smaa-onfailure-destination">self-managed
        /// Kafka</a> or <a href="https://docs.aws.amazon.com/lambda/latest/dg/with-msk.html#services-msk-onfailure-destination">Amazon
        /// MSK</a>, you can configure an Amazon SNS topic, Amazon SQS queue, or Amazon S3 bucket
        /// as the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfig_OnFailure_Destination")]
        public System.String OnFailure_Destination { get; set; }
        #endregion
        
        #region Parameter OnSuccess_Destination
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination resource.</para><note><para>Amazon SNS destinations have a message size limit of 256 KB. If the combined size
        /// of the function request and response payload exceeds the limit, Lambda will drop the
        /// payload when sending <c>OnFailure</c> event to the destination. For details on this
        /// behavior, refer to <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async-retain-records.html">Retaining
        /// records of asynchronous invocations</a>.</para></note>
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
        
        #region Parameter AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat
        /// <summary>
        /// <para>
        /// <para>The record format that Lambda delivers to your function after schema validation.</para><ul><li><para>Choose <c>JSON</c> to have Lambda deliver the record to your function as a standard
        /// JSON object.</para></li><li><para>Choose <c>SOURCE</c> to have Lambda deliver the record to your function in its original
        /// source format. Lambda removes all schema metadata, such as the schema ID, before sending
        /// the record to your function.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.SchemaRegistryEventRecordFormat")]
        public Amazon.Lambda.SchemaRegistryEventRecordFormat AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat { get; set; }
        #endregion
        
        #region Parameter SchemaRegistryConfig_EventRecordFormat
        /// <summary>
        /// <para>
        /// <para>The record format that Lambda delivers to your function after schema validation.</para><ul><li><para>Choose <c>JSON</c> to have Lambda deliver the record to your function as a standard
        /// JSON object.</para></li><li><para>Choose <c>SOURCE</c> to have Lambda deliver the record to your function in its original
        /// source format. Lambda removes all schema metadata, such as the schema ID, before sending
        /// the record to your function.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat")]
        [AWSConstantClassSource("Amazon.Lambda.SchemaRegistryEventRecordFormat")]
        public Amazon.Lambda.SchemaRegistryEventRecordFormat SchemaRegistryConfig_EventRecordFormat { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Filter
        /// <summary>
        /// <para>
        /// <para> A list of filters. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The name or ARN of the Lambda function.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <c>MyFunction</c>.</para></li><li><para><b>Function ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:MyFunction</c>.</para></li><li><para><b>Version or Alias ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:MyFunction:PROD</c>.</para></li><li><para><b>Partial ARN</b> – <c>123456789012:function:MyFunction</c>.</para></li></ul><para>The length constraint applies only to the full ARN. If you specify only the function
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
        /// applied to the event source mapping.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FunctionResponseTypes")]
        public System.String[] FunctionResponseType { get; set; }
        #endregion
        
        #region Parameter KMSKeyArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the Key Management Service (KMS) customer managed key that Lambda uses
        /// to encrypt your function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-eventfiltering.html#filtering-basics">filter
        /// criteria</a>. By default, Lambda does not encrypt your filter criteria object. Specify
        /// this property to encrypt data using your own customer managed key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyArn { get; set; }
        #endregion
        
        #region Parameter MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that Lambda spends gathering records before
        /// invoking the function. You can configure <c>MaximumBatchingWindowInSeconds</c> to
        /// any value from 0 seconds to 300 seconds in increments of seconds.</para><para>For Kinesis, DynamoDB, and Amazon SQS event sources, the default batching window is
        /// 0 seconds. For Amazon MSK, Self-managed Apache Kafka, Amazon MQ, and DocumentDB event
        /// sources, the default batching window is 500 ms. Note that because you can only change
        /// <c>MaximumBatchingWindowInSeconds</c> in increments of seconds, you cannot revert
        /// back to the 500 ms default batching window after you have changed it. To restore the
        /// default batching window, you must create a new event source mapping.</para><para>Related setting: For Kinesis, DynamoDB, and Amazon SQS event sources, when you set
        /// <c>BatchSize</c> to a value greater than 10, you must set <c>MaximumBatchingWindowInSeconds</c>
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
        
        #region Parameter ProvisionedPollerConfig_MaximumPoller
        /// <summary>
        /// <para>
        /// <para>The maximum number of event pollers this event source can scale up to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedPollerConfig_MaximumPollers")]
        public System.Int32? ProvisionedPollerConfig_MaximumPoller { get; set; }
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
        
        #region Parameter MetricsConfig_Metric
        /// <summary>
        /// <para>
        /// <para> The metrics you want your event source mapping to produce. Include <c>EventCount</c>
        /// to receive event source mapping metrics related to the number of events processed
        /// by your event source mapping. For more information about these metrics, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/monitoring-metrics-types.html#event-source-mapping-metrics">
        /// Event source mapping metrics</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricsConfig_Metrics")]
        public System.String[] MetricsConfig_Metric { get; set; }
        #endregion
        
        #region Parameter ProvisionedPollerConfig_MinimumPoller
        /// <summary>
        /// <para>
        /// <para>The minimum number of event pollers this event source can scale down to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProvisionedPollerConfig_MinimumPollers")]
        public System.Int32? ProvisionedPollerConfig_MinimumPoller { get; set; }
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
        
        #region Parameter AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI
        /// <summary>
        /// <para>
        /// <para>The URI for your schema registry. The correct URI format depends on the type of schema
        /// registry you're using.</para><ul><li><para>For Glue schema registries, use the ARN of the registry.</para></li><li><para>For Confluent schema registries, use the URL of the registry.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI { get; set; }
        #endregion
        
        #region Parameter SchemaRegistryConfig_SchemaRegistryURI
        /// <summary>
        /// <para>
        /// <para>The URI for your schema registry. The correct URI format depends on the type of schema
        /// registry you're using.</para><ul><li><para>For Glue schema registries, use the ARN of the registry.</para></li><li><para>For Confluent schema registries, use the URL of the registry.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI")]
        public System.String SchemaRegistryConfig_SchemaRegistryURI { get; set; }
        #endregion
        
        #region Parameter AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs
        /// <summary>
        /// <para>
        /// <para>An array of schema validation configuration objects, which tell Lambda the message
        /// attributes you want to validate and filter using your schema registry.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Lambda.Model.KafkaSchemaValidationConfig[] AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs { get; set; }
        #endregion
        
        #region Parameter SchemaRegistryConfig_SchemaValidationConfig
        /// <summary>
        /// <para>
        /// <para>An array of schema validation configuration objects, which tell Lambda the message
        /// attributes you want to validate and filter using your schema registry.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelfManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs")]
        public Amazon.Lambda.Model.KafkaSchemaValidationConfig[] SchemaRegistryConfig_SchemaValidationConfig { get; set; }
        #endregion
        
        #region Parameter SourceAccessConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of authentication protocols or VPC components required to secure your event
        /// source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMEventSourceMapping (UpdateEventSourceMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateEventSourceMappingResponse, UpdateLMEventSourceMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmazonManagedKafkaEventSourceConfig_ConsumerGroupId = this.AmazonManagedKafkaEventSourceConfig_ConsumerGroupId;
            if (this.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs != null)
            {
                context.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs = new List<Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig>(this.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs);
            }
            context.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat = this.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat;
            context.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI = this.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI;
            if (this.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs != null)
            {
                context.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs = new List<Amazon.Lambda.Model.KafkaSchemaValidationConfig>(this.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs);
            }
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
            context.KMSKeyArn = this.KMSKeyArn;
            context.MaximumBatchingWindowInSecond = this.MaximumBatchingWindowInSecond;
            context.MaximumRecordAgeInSecond = this.MaximumRecordAgeInSecond;
            context.MaximumRetryAttempt = this.MaximumRetryAttempt;
            if (this.MetricsConfig_Metric != null)
            {
                context.MetricsConfig_Metric = new List<System.String>(this.MetricsConfig_Metric);
            }
            context.ParallelizationFactor = this.ParallelizationFactor;
            context.ProvisionedPollerConfig_MaximumPoller = this.ProvisionedPollerConfig_MaximumPoller;
            context.ProvisionedPollerConfig_MinimumPoller = this.ProvisionedPollerConfig_MinimumPoller;
            context.ScalingConfig_MaximumConcurrency = this.ScalingConfig_MaximumConcurrency;
            context.SelfManagedKafkaEventSourceConfig_ConsumerGroupId = this.SelfManagedKafkaEventSourceConfig_ConsumerGroupId;
            if (this.SchemaRegistryConfig_AccessConfig != null)
            {
                context.SchemaRegistryConfig_AccessConfig = new List<Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig>(this.SchemaRegistryConfig_AccessConfig);
            }
            context.SchemaRegistryConfig_EventRecordFormat = this.SchemaRegistryConfig_EventRecordFormat;
            context.SchemaRegistryConfig_SchemaRegistryURI = this.SchemaRegistryConfig_SchemaRegistryURI;
            if (this.SchemaRegistryConfig_SchemaValidationConfig != null)
            {
                context.SchemaRegistryConfig_SchemaValidationConfig = new List<Amazon.Lambda.Model.KafkaSchemaValidationConfig>(this.SchemaRegistryConfig_SchemaValidationConfig);
            }
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
            
            
             // populate AmazonManagedKafkaEventSourceConfig
            var requestAmazonManagedKafkaEventSourceConfigIsNull = true;
            request.AmazonManagedKafkaEventSourceConfig = new Amazon.Lambda.Model.AmazonManagedKafkaEventSourceConfig();
            System.String requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_ConsumerGroupId = null;
            if (cmdletContext.AmazonManagedKafkaEventSourceConfig_ConsumerGroupId != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_ConsumerGroupId = cmdletContext.AmazonManagedKafkaEventSourceConfig_ConsumerGroupId;
            }
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_ConsumerGroupId != null)
            {
                request.AmazonManagedKafkaEventSourceConfig.ConsumerGroupId = requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_ConsumerGroupId;
                requestAmazonManagedKafkaEventSourceConfigIsNull = false;
            }
            Amazon.Lambda.Model.KafkaSchemaRegistryConfig requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig = null;
            
             // populate SchemaRegistryConfig
            var requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = true;
            requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig = new Amazon.Lambda.Model.KafkaSchemaRegistryConfig();
            List<Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig> requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs = null;
            if (cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs = cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs;
            }
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig.AccessConfigs = requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs;
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
            Amazon.Lambda.SchemaRegistryEventRecordFormat requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat = null;
            if (cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat = cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat;
            }
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig.EventRecordFormat = requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat;
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
            System.String requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI = null;
            if (cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI = cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI;
            }
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig.SchemaRegistryURI = requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI;
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
            List<Amazon.Lambda.Model.KafkaSchemaValidationConfig> requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs = null;
            if (cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs = cmdletContext.AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs;
            }
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs != null)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig.SchemaValidationConfigs = requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs;
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
             // determine if requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig should be set to null
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull)
            {
                requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig = null;
            }
            if (requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig != null)
            {
                request.AmazonManagedKafkaEventSourceConfig.SchemaRegistryConfig = requestAmazonManagedKafkaEventSourceConfig_amazonManagedKafkaEventSourceConfig_SchemaRegistryConfig;
                requestAmazonManagedKafkaEventSourceConfigIsNull = false;
            }
             // determine if request.AmazonManagedKafkaEventSourceConfig should be set to null
            if (requestAmazonManagedKafkaEventSourceConfigIsNull)
            {
                request.AmazonManagedKafkaEventSourceConfig = null;
            }
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
            if (cmdletContext.KMSKeyArn != null)
            {
                request.KMSKeyArn = cmdletContext.KMSKeyArn;
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
            
             // populate MetricsConfig
            var requestMetricsConfigIsNull = true;
            request.MetricsConfig = new Amazon.Lambda.Model.EventSourceMappingMetricsConfig();
            List<System.String> requestMetricsConfig_metricsConfig_Metric = null;
            if (cmdletContext.MetricsConfig_Metric != null)
            {
                requestMetricsConfig_metricsConfig_Metric = cmdletContext.MetricsConfig_Metric;
            }
            if (requestMetricsConfig_metricsConfig_Metric != null)
            {
                request.MetricsConfig.Metrics = requestMetricsConfig_metricsConfig_Metric;
                requestMetricsConfigIsNull = false;
            }
             // determine if request.MetricsConfig should be set to null
            if (requestMetricsConfigIsNull)
            {
                request.MetricsConfig = null;
            }
            if (cmdletContext.ParallelizationFactor != null)
            {
                request.ParallelizationFactor = cmdletContext.ParallelizationFactor.Value;
            }
            
             // populate ProvisionedPollerConfig
            var requestProvisionedPollerConfigIsNull = true;
            request.ProvisionedPollerConfig = new Amazon.Lambda.Model.ProvisionedPollerConfig();
            System.Int32? requestProvisionedPollerConfig_provisionedPollerConfig_MaximumPoller = null;
            if (cmdletContext.ProvisionedPollerConfig_MaximumPoller != null)
            {
                requestProvisionedPollerConfig_provisionedPollerConfig_MaximumPoller = cmdletContext.ProvisionedPollerConfig_MaximumPoller.Value;
            }
            if (requestProvisionedPollerConfig_provisionedPollerConfig_MaximumPoller != null)
            {
                request.ProvisionedPollerConfig.MaximumPollers = requestProvisionedPollerConfig_provisionedPollerConfig_MaximumPoller.Value;
                requestProvisionedPollerConfigIsNull = false;
            }
            System.Int32? requestProvisionedPollerConfig_provisionedPollerConfig_MinimumPoller = null;
            if (cmdletContext.ProvisionedPollerConfig_MinimumPoller != null)
            {
                requestProvisionedPollerConfig_provisionedPollerConfig_MinimumPoller = cmdletContext.ProvisionedPollerConfig_MinimumPoller.Value;
            }
            if (requestProvisionedPollerConfig_provisionedPollerConfig_MinimumPoller != null)
            {
                request.ProvisionedPollerConfig.MinimumPollers = requestProvisionedPollerConfig_provisionedPollerConfig_MinimumPoller.Value;
                requestProvisionedPollerConfigIsNull = false;
            }
             // determine if request.ProvisionedPollerConfig should be set to null
            if (requestProvisionedPollerConfigIsNull)
            {
                request.ProvisionedPollerConfig = null;
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
            
             // populate SelfManagedKafkaEventSourceConfig
            var requestSelfManagedKafkaEventSourceConfigIsNull = true;
            request.SelfManagedKafkaEventSourceConfig = new Amazon.Lambda.Model.SelfManagedKafkaEventSourceConfig();
            System.String requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_ConsumerGroupId = null;
            if (cmdletContext.SelfManagedKafkaEventSourceConfig_ConsumerGroupId != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_ConsumerGroupId = cmdletContext.SelfManagedKafkaEventSourceConfig_ConsumerGroupId;
            }
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_ConsumerGroupId != null)
            {
                request.SelfManagedKafkaEventSourceConfig.ConsumerGroupId = requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_ConsumerGroupId;
                requestSelfManagedKafkaEventSourceConfigIsNull = false;
            }
            Amazon.Lambda.Model.KafkaSchemaRegistryConfig requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig = null;
            
             // populate SchemaRegistryConfig
            var requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = true;
            requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig = new Amazon.Lambda.Model.KafkaSchemaRegistryConfig();
            List<Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig> requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_AccessConfig = null;
            if (cmdletContext.SchemaRegistryConfig_AccessConfig != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_AccessConfig = cmdletContext.SchemaRegistryConfig_AccessConfig;
            }
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_AccessConfig != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig.AccessConfigs = requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_AccessConfig;
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
            Amazon.Lambda.SchemaRegistryEventRecordFormat requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_EventRecordFormat = null;
            if (cmdletContext.SchemaRegistryConfig_EventRecordFormat != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_EventRecordFormat = cmdletContext.SchemaRegistryConfig_EventRecordFormat;
            }
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_EventRecordFormat != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig.EventRecordFormat = requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_EventRecordFormat;
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
            System.String requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaRegistryURI = null;
            if (cmdletContext.SchemaRegistryConfig_SchemaRegistryURI != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaRegistryURI = cmdletContext.SchemaRegistryConfig_SchemaRegistryURI;
            }
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaRegistryURI != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig.SchemaRegistryURI = requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaRegistryURI;
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
            List<Amazon.Lambda.Model.KafkaSchemaValidationConfig> requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaValidationConfig = null;
            if (cmdletContext.SchemaRegistryConfig_SchemaValidationConfig != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaValidationConfig = cmdletContext.SchemaRegistryConfig_SchemaValidationConfig;
            }
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaValidationConfig != null)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig.SchemaValidationConfigs = requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig_schemaRegistryConfig_SchemaValidationConfig;
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull = false;
            }
             // determine if requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig should be set to null
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfigIsNull)
            {
                requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig = null;
            }
            if (requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig != null)
            {
                request.SelfManagedKafkaEventSourceConfig.SchemaRegistryConfig = requestSelfManagedKafkaEventSourceConfig_selfManagedKafkaEventSourceConfig_SchemaRegistryConfig;
                requestSelfManagedKafkaEventSourceConfigIsNull = false;
            }
             // determine if request.SelfManagedKafkaEventSourceConfig should be set to null
            if (requestSelfManagedKafkaEventSourceConfigIsNull)
            {
                request.SelfManagedKafkaEventSourceConfig = null;
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
                return client.UpdateEventSourceMappingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AmazonManagedKafkaEventSourceConfig_ConsumerGroupId { get; set; }
            public List<Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig> AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_AccessConfigs { get; set; }
            public Amazon.Lambda.SchemaRegistryEventRecordFormat AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_EventRecordFormat { get; set; }
            public System.String AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaRegistryURI { get; set; }
            public List<Amazon.Lambda.Model.KafkaSchemaValidationConfig> AmazonManagedKafkaEventSourceConfig_SchemaRegistryConfig_SchemaValidationConfigs { get; set; }
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
            public System.String KMSKeyArn { get; set; }
            public System.Int32? MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? MaximumRecordAgeInSecond { get; set; }
            public System.Int32? MaximumRetryAttempt { get; set; }
            public List<System.String> MetricsConfig_Metric { get; set; }
            public System.Int32? ParallelizationFactor { get; set; }
            public System.Int32? ProvisionedPollerConfig_MaximumPoller { get; set; }
            public System.Int32? ProvisionedPollerConfig_MinimumPoller { get; set; }
            public System.Int32? ScalingConfig_MaximumConcurrency { get; set; }
            public System.String SelfManagedKafkaEventSourceConfig_ConsumerGroupId { get; set; }
            public List<Amazon.Lambda.Model.KafkaSchemaRegistryAccessConfig> SchemaRegistryConfig_AccessConfig { get; set; }
            public Amazon.Lambda.SchemaRegistryEventRecordFormat SchemaRegistryConfig_EventRecordFormat { get; set; }
            public System.String SchemaRegistryConfig_SchemaRegistryURI { get; set; }
            public List<Amazon.Lambda.Model.KafkaSchemaValidationConfig> SchemaRegistryConfig_SchemaValidationConfig { get; set; }
            public List<Amazon.Lambda.Model.SourceAccessConfiguration> SourceAccessConfiguration { get; set; }
            public System.Int32? TumblingWindowInSecond { get; set; }
            public System.String UUID { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateEventSourceMappingResponse, UpdateLMEventSourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
