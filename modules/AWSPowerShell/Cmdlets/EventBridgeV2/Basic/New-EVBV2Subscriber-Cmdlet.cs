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
using Amazon.EventBridgeV2;
using Amazon.EventBridgeV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVBV2
{
    /// <summary>
    /// Creates a subscriber on an event bus, which delivers matching events to the configured
    /// target. The bus must be ACTIVE. Retries carrying the same ClientToken are idempotent.
    /// </summary>
    [Cmdlet("New", "EVBV2Subscriber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridgeV2.Model.CreateSubscriberResponse")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 CreateSubscriber API operation.", Operation = new[] {"CreateSubscriber"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.CreateSubscriberResponse))]
    [AWSCmdletOutput("Amazon.EventBridgeV2.Model.CreateSubscriberResponse",
        "This cmdlet returns an Amazon.EventBridgeV2.Model.CreateSubscriberResponse object containing multiple properties."
    )]
    public partial class NewEVBV2SubscriberCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OnFailureConfiguration_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination that receives events that could not be delivered. An Amazon
        /// SQS queue is the supported destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OnFailureConfiguration_Arn { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId
        /// <summary>
        /// <para>
        /// <para>Deduplication ID for FIFO deduplication on the downstream bus. Accepts a literal or
        /// a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.DeduplicationType")]
        public Amazon.EventBridgeV2.DeduplicationType InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SqsParameters_DelaySecond
        /// <summary>
        /// <para>
        /// <para>Delay in seconds before the message becomes visible, standard queues only. Accepts
        /// JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_SqsParameters_DelaySeconds")]
        public System.String InvokeConfiguration_SqsParameters_DelaySecond { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_LambdaParameters_DurableExecutionName
        /// <summary>
        /// <para>
        /// <para>Durable execution name. Accepts a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_LambdaParameters_DurableExecutionName { get; set; }
        #endregion
        
        #region Parameter PointInTimeConfiguration_EndPoint
        /// <summary>
        /// <para>
        /// <para>Timestamp to stop at. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PointInTimeConfiguration_EndPoint { get; set; }
        #endregion
        
        #region Parameter EventBusArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String EventBusArn { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId
        /// <summary>
        /// <para>
        /// <para>Event group ID for FIFO ordering on the downstream bus. Accepts a literal or a JSONata
        /// expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_KinesisParameters_ExplicitHashKey
        /// <summary>
        /// <para>
        /// <para>Explicit hash key forwarded to PutRecords unchanged. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_KinesisParameters_ExplicitHashKey { get; set; }
        #endregion
        
        #region Parameter Transformer_JsonataConfiguration_Expression
        /// <summary>
        /// <para>
        /// <para>JSONata expression to transform the event. Must be wrapped in {% %} delimiters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Transformer_JsonataConfiguration_Expression { get; set; }
        #endregion
        
        #region Parameter FilterConfiguration_Filter
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterConfiguration_Filters")]
        public Amazon.EventBridgeV2.Model.Filter[] FilterConfiguration_Filter { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_HttpParameters_HeaderParameter
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_HttpParameters_HeaderParameters")]
        public System.Collections.Hashtable InvokeConfiguration_HttpParameters_HeaderParameter { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_IncludePayload
        /// <summary>
        /// <para>
        /// <para>Whether the customer event payload is embedded in log records. Defaults to ON_ERROR_ONLY.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.IncludePayload")]
        public Amazon.EventBridgeV2.IncludePayload LogConfiguration_IncludePayload { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_UniversalTargetParameters_Input
        /// <summary>
        /// <para>
        /// <para>JSON string or JSONata expression that produces the API request. Supports {% ... %}
        /// JSONata expressions for dynamic values from the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_UniversalTargetParameters_Input { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_HttpParameters_InvocationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Timeout in seconds for each invocation of the target (1-30). String-typed (not integer)
        /// so the value may be a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_HttpParameters_InvocationTimeoutSeconds")]
        public System.String InvokeConfiguration_HttpParameters_InvocationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Timeout in seconds for each invocation of the target. String-typed so the value may
        /// be a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_LambdaParameters_InvocationTimeoutSeconds")]
        public System.String InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Timeout in seconds for each invocation of the target (1-30). String-typed (not integer)
        /// so the value may be a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSeconds")]
        public System.String InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Timeout in seconds for each invocation of the target (1-30, default 30). Accepts a
        /// literal integer or a {% ... %} JSONata expression evaluated against the event at invocation
        /// time. A JSONata expression is syntax-checked at create time. Resolved values outside
        /// of the range [1, 30] will be constrained to the nearest bound at delivery time. Defaults
        /// to 30 seconds when unset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSeconds")]
        public System.String InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_LambdaParameters_InvocationType
        /// <summary>
        /// <para>
        /// <para>Lambda invocation type. EVENT invokes the function asynchronously; REQUEST_RESPONSE
        /// waits for its result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.InvocationType")]
        public Amazon.EventBridgeV2.InvocationType InvokeConfiguration_LambdaParameters_InvocationType { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_StepFunctionsParameters_InvocationType
        /// <summary>
        /// <para>
        /// <para>Selects StartExecution (EVENT) or StartSyncExecution (REQUEST_RESPONSE) at delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.InvocationType")]
        public Amazon.EventBridgeV2.InvocationType InvokeConfiguration_StepFunctionsParameters_InvocationType { get; set; }
        #endregion
        
        #region Parameter FilterConfiguration_Language
        /// <summary>
        /// <para>
        /// <para>Defaults to EVENT_BRIDGE_PATTERN when not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.FilterLanguage")]
        public Amazon.EventBridgeV2.FilterLanguage FilterConfiguration_Language { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_Level
        /// <summary>
        /// <para>
        /// <para>Minimum log level. Records below this level are not emitted. Defaults to OFF.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.LogLevel")]
        public Amazon.EventBridgeV2.LogLevel LogConfiguration_Level { get; set; }
        #endregion
        
        #region Parameter BatchConfiguration_MaxBatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of events to include in a single batch delivered to the target.
        /// The service delivers up to this many events per batch; fewer may be delivered when
        /// the batch window elapses or the target's per-batch limit is smaller. This is a maximum,
        /// not a guaranteed count. Valid range is 1-500 (default: 10, or the target API's per-batch
        /// maximum). The resolved value applied by the service is returned on read.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BatchConfiguration_MaxBatchSize { get; set; }
        #endregion
        
        #region Parameter BatchConfiguration_MaxBatchWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time in seconds to wait for a batch to fill before delivering it to the
        /// target. This is a maximum; a batch may be delivered sooner if it reaches MaxBatchSize
        /// or another delivery condition is met. Valid range is 0-300 (default: 0, meaning no
        /// wait). The resolved value applied by the service is always returned on read.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BatchConfiguration_MaxBatchWindowInSeconds")]
        public System.Int32? BatchConfiguration_MaxBatchWindowInSecond { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_MaxEventAgeInSecond
        /// <summary>
        /// <para>
        /// <para>Maximum age of an event in seconds before it is discarded (60-86400, default: 300).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicy_MaxEventAgeInSeconds")]
        public System.Int32? RetryPolicy_MaxEventAgeInSecond { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_MaxRetryAttempt
        /// <summary>
        /// <para>
        /// <para>Maximum number of retry attempts (0-185, default: 5).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicy_MaxRetryAttempts")]
        public System.Int32? RetryPolicy_MaxRetryAttempt { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SnsParameters_MessageAttribute
        /// <summary>
        /// <para>
        /// <para>Custom message attributes for SNS filtering.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_SnsParameters_MessageAttributes")]
        public System.Collections.Hashtable InvokeConfiguration_SnsParameters_MessageAttribute { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SqsParameters_MessageAttribute
        /// <summary>
        /// <para>
        /// <para>Custom message attributes (name/type/value).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_SqsParameters_MessageAttributes")]
        public System.Collections.Hashtable InvokeConfiguration_SqsParameters_MessageAttribute { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SnsParameters_MessageDeduplicationId
        /// <summary>
        /// <para>
        /// <para>Message deduplication ID for FIFO topics. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_SnsParameters_MessageDeduplicationId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SqsParameters_MessageDeduplicationId
        /// <summary>
        /// <para>
        /// <para>Message deduplication ID for FIFO queues. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_SqsParameters_MessageDeduplicationId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SnsParameters_MessageGroupId
        /// <summary>
        /// <para>
        /// <para>Message group ID for FIFO topics. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_SnsParameters_MessageGroupId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SqsParameters_MessageGroupId
        /// <summary>
        /// <para>
        /// <para>Message group ID for FIFO queues. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_SqsParameters_MessageGroupId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SnsParameters_MessageStructure
        /// <summary>
        /// <para>
        /// <para>Per-protocol message formatting mode, forwarded to SNS Publish unchanged. Accepts
        /// JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_SnsParameters_MessageStructure { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SqsParameters_MessageSystemAttribute
        /// <summary>
        /// <para>
        /// <para>System message attributes (e.g., AWSTraceHeader).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_SqsParameters_MessageSystemAttributes")]
        public System.Collections.Hashtable InvokeConfiguration_SqsParameters_MessageSystemAttribute { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_EventBusV2Parameters_Metadata
        /// <summary>
        /// <para>
        /// <para>Customer-defined metadata forwarded with each event.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable InvokeConfiguration_EventBusV2Parameters_Metadata { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_StepFunctionsParameters_Name
        /// <summary>
        /// <para>
        /// <para>Name for the execution. Must be unique per account/region/state machine. Accepts JSONata
        /// expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_StepFunctionsParameters_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_KinesisParameters_PartitionKey
        /// <summary>
        /// <para>
        /// <para>Required by PutRecords even when an explicit hash key is supplied. Accepts JSONata
        /// expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_KinesisParameters_PartitionKey { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_HttpParameters_PathParameterValue
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_HttpParameters_PathParameterValues")]
        public System.String[] InvokeConfiguration_HttpParameters_PathParameterValue { get; set; }
        #endregion
        
        #region Parameter PointInTimeConfiguration_PointType
        /// <summary>
        /// <para>
        /// <para>Whether to start from the horizon or a specific timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.PointType")]
        public Amazon.EventBridgeV2.PointType PointInTimeConfiguration_PointType { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_LambdaParameters_Qualifier
        /// <summary>
        /// <para>
        /// <para>Lambda qualifier: $LATEST, $LATEST.PUBLISHED, a numeric version, or an alias. Accepts
        /// a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_LambdaParameters_Qualifier { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_HttpParameters_QueryStringParameter
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeConfiguration_HttpParameters_QueryStringParameters")]
        public System.Collections.Hashtable InvokeConfiguration_HttpParameters_QueryStringParameter { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_RetryStrategy
        /// <summary>
        /// <para>
        /// <para>Strategy for determining which exceptions are retried. Default: ALL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.RetryStrategy")]
        public Amazon.EventBridgeV2.RetryStrategy RetryPolicy_RetryStrategy { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>IAM role the service assumes to invoke the target. Must belong to the calling account.</para>
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
        public System.String InvokeConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter PointInTimeConfiguration_StartingPoint
        /// <summary>
        /// <para>
        /// <para>Timestamp to start from. Required when PointType is TIMESTAMP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PointInTimeConfiguration_StartingPoint { get; set; }
        #endregion
        
        #region Parameter StartingPosition
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.StartingPosition")]
        public Amazon.EventBridgeV2.StartingPosition StartingPosition { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.SubscriberState")]
        public Amazon.EventBridgeV2.SubscriberState State { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_SnsParameters_Subject
        /// <summary>
        /// <para>
        /// <para>Subject line for email protocol subscriptions. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_SnsParameters_Subject { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_TargetArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String InvokeConfiguration_TargetArn { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_LambdaParameters_TenantId
        /// <summary>
        /// <para>
        /// <para>Tenant identifier. Accepts a JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_LambdaParameters_TenantId { get; set; }
        #endregion
        
        #region Parameter InvokeConfiguration_StepFunctionsParameters_TraceHeader
        /// <summary>
        /// <para>
        /// <para>X-Ray trace header for distributed tracing. Accepts JSONata expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvokeConfiguration_StepFunctionsParameters_TraceHeader { get; set; }
        #endregion
        
        #region Parameter Transformer_Type
        /// <summary>
        /// <para>
        /// <para>Transform type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.TransformerType")]
        public Amazon.EventBridgeV2.TransformerType Transformer_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.OrderingType")]
        public Amazon.EventBridgeV2.OrderingType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.CreateSubscriberResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.CreateSubscriberResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.EventBusArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVBV2Subscriber (CreateSubscriber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.CreateSubscriberResponse, NewEVBV2SubscriberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BatchConfiguration_MaxBatchSize = this.BatchConfiguration_MaxBatchSize;
            context.BatchConfiguration_MaxBatchWindowInSecond = this.BatchConfiguration_MaxBatchWindowInSecond;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EventBusArn = this.EventBusArn;
            #if MODULAR
            if (this.EventBusArn == null && ParameterWasBound(nameof(this.EventBusArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventBusArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FilterConfiguration_Filter != null)
            {
                context.FilterConfiguration_Filter = new List<Amazon.EventBridgeV2.Model.Filter>(this.FilterConfiguration_Filter);
            }
            context.FilterConfiguration_Language = this.FilterConfiguration_Language;
            context.InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType = this.InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType;
            if (this.InvokeConfiguration_EventBusV2Parameters_Metadata != null)
            {
                context.InvokeConfiguration_EventBusV2Parameters_Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InvokeConfiguration_EventBusV2Parameters_Metadata.Keys)
                {
                    context.InvokeConfiguration_EventBusV2Parameters_Metadata.Add((String)hashKey, (System.String)(this.InvokeConfiguration_EventBusV2Parameters_Metadata[hashKey]));
                }
            }
            context.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId = this.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId;
            context.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId = this.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId;
            if (this.InvokeConfiguration_HttpParameters_HeaderParameter != null)
            {
                context.InvokeConfiguration_HttpParameters_HeaderParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InvokeConfiguration_HttpParameters_HeaderParameter.Keys)
                {
                    context.InvokeConfiguration_HttpParameters_HeaderParameter.Add((String)hashKey, (System.String)(this.InvokeConfiguration_HttpParameters_HeaderParameter[hashKey]));
                }
            }
            context.InvokeConfiguration_HttpParameters_InvocationTimeoutSecond = this.InvokeConfiguration_HttpParameters_InvocationTimeoutSecond;
            if (this.InvokeConfiguration_HttpParameters_PathParameterValue != null)
            {
                context.InvokeConfiguration_HttpParameters_PathParameterValue = new List<System.String>(this.InvokeConfiguration_HttpParameters_PathParameterValue);
            }
            if (this.InvokeConfiguration_HttpParameters_QueryStringParameter != null)
            {
                context.InvokeConfiguration_HttpParameters_QueryStringParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InvokeConfiguration_HttpParameters_QueryStringParameter.Keys)
                {
                    context.InvokeConfiguration_HttpParameters_QueryStringParameter.Add((String)hashKey, (System.String)(this.InvokeConfiguration_HttpParameters_QueryStringParameter[hashKey]));
                }
            }
            context.InvokeConfiguration_KinesisParameters_ExplicitHashKey = this.InvokeConfiguration_KinesisParameters_ExplicitHashKey;
            context.InvokeConfiguration_KinesisParameters_PartitionKey = this.InvokeConfiguration_KinesisParameters_PartitionKey;
            context.InvokeConfiguration_LambdaParameters_DurableExecutionName = this.InvokeConfiguration_LambdaParameters_DurableExecutionName;
            context.InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond = this.InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond;
            context.InvokeConfiguration_LambdaParameters_InvocationType = this.InvokeConfiguration_LambdaParameters_InvocationType;
            context.InvokeConfiguration_LambdaParameters_Qualifier = this.InvokeConfiguration_LambdaParameters_Qualifier;
            context.InvokeConfiguration_LambdaParameters_TenantId = this.InvokeConfiguration_LambdaParameters_TenantId;
            context.InvokeConfiguration_RoleArn = this.InvokeConfiguration_RoleArn;
            #if MODULAR
            if (this.InvokeConfiguration_RoleArn == null && ParameterWasBound(nameof(this.InvokeConfiguration_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InvokeConfiguration_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InvokeConfiguration_SnsParameters_MessageAttribute != null)
            {
                context.InvokeConfiguration_SnsParameters_MessageAttribute = new Dictionary<System.String, Amazon.EventBridgeV2.Model.SnsMessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.InvokeConfiguration_SnsParameters_MessageAttribute.Keys)
                {
                    context.InvokeConfiguration_SnsParameters_MessageAttribute.Add((String)hashKey, (Amazon.EventBridgeV2.Model.SnsMessageAttributeValue)(this.InvokeConfiguration_SnsParameters_MessageAttribute[hashKey]));
                }
            }
            context.InvokeConfiguration_SnsParameters_MessageDeduplicationId = this.InvokeConfiguration_SnsParameters_MessageDeduplicationId;
            context.InvokeConfiguration_SnsParameters_MessageGroupId = this.InvokeConfiguration_SnsParameters_MessageGroupId;
            context.InvokeConfiguration_SnsParameters_MessageStructure = this.InvokeConfiguration_SnsParameters_MessageStructure;
            context.InvokeConfiguration_SnsParameters_Subject = this.InvokeConfiguration_SnsParameters_Subject;
            context.InvokeConfiguration_SqsParameters_DelaySecond = this.InvokeConfiguration_SqsParameters_DelaySecond;
            if (this.InvokeConfiguration_SqsParameters_MessageAttribute != null)
            {
                context.InvokeConfiguration_SqsParameters_MessageAttribute = new Dictionary<System.String, Amazon.EventBridgeV2.Model.SqsMessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.InvokeConfiguration_SqsParameters_MessageAttribute.Keys)
                {
                    context.InvokeConfiguration_SqsParameters_MessageAttribute.Add((String)hashKey, (Amazon.EventBridgeV2.Model.SqsMessageAttributeValue)(this.InvokeConfiguration_SqsParameters_MessageAttribute[hashKey]));
                }
            }
            context.InvokeConfiguration_SqsParameters_MessageDeduplicationId = this.InvokeConfiguration_SqsParameters_MessageDeduplicationId;
            context.InvokeConfiguration_SqsParameters_MessageGroupId = this.InvokeConfiguration_SqsParameters_MessageGroupId;
            if (this.InvokeConfiguration_SqsParameters_MessageSystemAttribute != null)
            {
                context.InvokeConfiguration_SqsParameters_MessageSystemAttribute = new Dictionary<System.String, Amazon.EventBridgeV2.Model.SqsMessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.InvokeConfiguration_SqsParameters_MessageSystemAttribute.Keys)
                {
                    context.InvokeConfiguration_SqsParameters_MessageSystemAttribute.Add((String)hashKey, (Amazon.EventBridgeV2.Model.SqsMessageAttributeValue)(this.InvokeConfiguration_SqsParameters_MessageSystemAttribute[hashKey]));
                }
            }
            context.InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond = this.InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond;
            context.InvokeConfiguration_StepFunctionsParameters_InvocationType = this.InvokeConfiguration_StepFunctionsParameters_InvocationType;
            context.InvokeConfiguration_StepFunctionsParameters_Name = this.InvokeConfiguration_StepFunctionsParameters_Name;
            context.InvokeConfiguration_StepFunctionsParameters_TraceHeader = this.InvokeConfiguration_StepFunctionsParameters_TraceHeader;
            context.InvokeConfiguration_TargetArn = this.InvokeConfiguration_TargetArn;
            #if MODULAR
            if (this.InvokeConfiguration_TargetArn == null && ParameterWasBound(nameof(this.InvokeConfiguration_TargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InvokeConfiguration_TargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvokeConfiguration_UniversalTargetParameters_Input = this.InvokeConfiguration_UniversalTargetParameters_Input;
            context.InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond = this.InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond;
            context.LogConfiguration_IncludePayload = this.LogConfiguration_IncludePayload;
            context.LogConfiguration_Level = this.LogConfiguration_Level;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnFailureConfiguration_Arn = this.OnFailureConfiguration_Arn;
            context.PointInTimeConfiguration_EndPoint = this.PointInTimeConfiguration_EndPoint;
            context.PointInTimeConfiguration_PointType = this.PointInTimeConfiguration_PointType;
            context.PointInTimeConfiguration_StartingPoint = this.PointInTimeConfiguration_StartingPoint;
            context.RetryPolicy_MaxEventAgeInSecond = this.RetryPolicy_MaxEventAgeInSecond;
            context.RetryPolicy_MaxRetryAttempt = this.RetryPolicy_MaxRetryAttempt;
            context.RetryPolicy_RetryStrategy = this.RetryPolicy_RetryStrategy;
            context.StartingPosition = this.StartingPosition;
            context.State = this.State;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Transformer_JsonataConfiguration_Expression = this.Transformer_JsonataConfiguration_Expression;
            context.Transformer_Type = this.Transformer_Type;
            context.Type = this.Type;
            
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
            var request = new Amazon.EventBridgeV2.Model.CreateSubscriberRequest();
            
            
             // populate BatchConfiguration
            var requestBatchConfigurationIsNull = true;
            request.BatchConfiguration = new Amazon.EventBridgeV2.Model.BatchConfiguration();
            System.Int32? requestBatchConfiguration_batchConfiguration_MaxBatchSize = null;
            if (cmdletContext.BatchConfiguration_MaxBatchSize != null)
            {
                requestBatchConfiguration_batchConfiguration_MaxBatchSize = cmdletContext.BatchConfiguration_MaxBatchSize.Value;
            }
            if (requestBatchConfiguration_batchConfiguration_MaxBatchSize != null)
            {
                request.BatchConfiguration.MaxBatchSize = requestBatchConfiguration_batchConfiguration_MaxBatchSize.Value;
                requestBatchConfigurationIsNull = false;
            }
            System.Int32? requestBatchConfiguration_batchConfiguration_MaxBatchWindowInSecond = null;
            if (cmdletContext.BatchConfiguration_MaxBatchWindowInSecond != null)
            {
                requestBatchConfiguration_batchConfiguration_MaxBatchWindowInSecond = cmdletContext.BatchConfiguration_MaxBatchWindowInSecond.Value;
            }
            if (requestBatchConfiguration_batchConfiguration_MaxBatchWindowInSecond != null)
            {
                request.BatchConfiguration.MaxBatchWindowInSeconds = requestBatchConfiguration_batchConfiguration_MaxBatchWindowInSecond.Value;
                requestBatchConfigurationIsNull = false;
            }
             // determine if request.BatchConfiguration should be set to null
            if (requestBatchConfigurationIsNull)
            {
                request.BatchConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventBusArn != null)
            {
                request.EventBusArn = cmdletContext.EventBusArn;
            }
            
             // populate FilterConfiguration
            var requestFilterConfigurationIsNull = true;
            request.FilterConfiguration = new Amazon.EventBridgeV2.Model.FilterConfiguration();
            List<Amazon.EventBridgeV2.Model.Filter> requestFilterConfiguration_filterConfiguration_Filter = null;
            if (cmdletContext.FilterConfiguration_Filter != null)
            {
                requestFilterConfiguration_filterConfiguration_Filter = cmdletContext.FilterConfiguration_Filter;
            }
            if (requestFilterConfiguration_filterConfiguration_Filter != null)
            {
                request.FilterConfiguration.Filters = requestFilterConfiguration_filterConfiguration_Filter;
                requestFilterConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.FilterLanguage requestFilterConfiguration_filterConfiguration_Language = null;
            if (cmdletContext.FilterConfiguration_Language != null)
            {
                requestFilterConfiguration_filterConfiguration_Language = cmdletContext.FilterConfiguration_Language;
            }
            if (requestFilterConfiguration_filterConfiguration_Language != null)
            {
                request.FilterConfiguration.Language = requestFilterConfiguration_filterConfiguration_Language;
                requestFilterConfigurationIsNull = false;
            }
             // determine if request.FilterConfiguration should be set to null
            if (requestFilterConfigurationIsNull)
            {
                request.FilterConfiguration = null;
            }
            
             // populate InvokeConfiguration
            var requestInvokeConfigurationIsNull = true;
            request.InvokeConfiguration = new Amazon.EventBridgeV2.Model.InvokeConfiguration();
            System.String requestInvokeConfiguration_invokeConfiguration_RoleArn = null;
            if (cmdletContext.InvokeConfiguration_RoleArn != null)
            {
                requestInvokeConfiguration_invokeConfiguration_RoleArn = cmdletContext.InvokeConfiguration_RoleArn;
            }
            if (requestInvokeConfiguration_invokeConfiguration_RoleArn != null)
            {
                request.InvokeConfiguration.RoleArn = requestInvokeConfiguration_invokeConfiguration_RoleArn;
                requestInvokeConfigurationIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_TargetArn = null;
            if (cmdletContext.InvokeConfiguration_TargetArn != null)
            {
                requestInvokeConfiguration_invokeConfiguration_TargetArn = cmdletContext.InvokeConfiguration_TargetArn;
            }
            if (requestInvokeConfiguration_invokeConfiguration_TargetArn != null)
            {
                request.InvokeConfiguration.TargetArn = requestInvokeConfiguration_invokeConfiguration_TargetArn;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.KinesisParameters requestInvokeConfiguration_invokeConfiguration_KinesisParameters = null;
            
             // populate KinesisParameters
            var requestInvokeConfiguration_invokeConfiguration_KinesisParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_KinesisParameters = new Amazon.EventBridgeV2.Model.KinesisParameters();
            System.String requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_ExplicitHashKey = null;
            if (cmdletContext.InvokeConfiguration_KinesisParameters_ExplicitHashKey != null)
            {
                requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_ExplicitHashKey = cmdletContext.InvokeConfiguration_KinesisParameters_ExplicitHashKey;
            }
            if (requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_ExplicitHashKey != null)
            {
                requestInvokeConfiguration_invokeConfiguration_KinesisParameters.ExplicitHashKey = requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_ExplicitHashKey;
                requestInvokeConfiguration_invokeConfiguration_KinesisParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_PartitionKey = null;
            if (cmdletContext.InvokeConfiguration_KinesisParameters_PartitionKey != null)
            {
                requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_PartitionKey = cmdletContext.InvokeConfiguration_KinesisParameters_PartitionKey;
            }
            if (requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_PartitionKey != null)
            {
                requestInvokeConfiguration_invokeConfiguration_KinesisParameters.PartitionKey = requestInvokeConfiguration_invokeConfiguration_KinesisParameters_invokeConfiguration_KinesisParameters_PartitionKey;
                requestInvokeConfiguration_invokeConfiguration_KinesisParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_KinesisParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_KinesisParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_KinesisParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_KinesisParameters != null)
            {
                request.InvokeConfiguration.KinesisParameters = requestInvokeConfiguration_invokeConfiguration_KinesisParameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.UniversalTargetParameters requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters = null;
            
             // populate UniversalTargetParameters
            var requestInvokeConfiguration_invokeConfiguration_UniversalTargetParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters = new Amazon.EventBridgeV2.Model.UniversalTargetParameters();
            System.String requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_Input = null;
            if (cmdletContext.InvokeConfiguration_UniversalTargetParameters_Input != null)
            {
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_Input = cmdletContext.InvokeConfiguration_UniversalTargetParameters_Input;
            }
            if (requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_Input != null)
            {
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters.Input = requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_Input;
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond = null;
            if (cmdletContext.InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond = cmdletContext.InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond;
            }
            if (requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters.InvocationTimeoutSeconds = requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters_invokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond;
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_UniversalTargetParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters != null)
            {
                request.InvokeConfiguration.UniversalTargetParameters = requestInvokeConfiguration_invokeConfiguration_UniversalTargetParameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.EventBusV2Parameters requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters = null;
            
             // populate EventBusV2Parameters
            var requestInvokeConfiguration_invokeConfiguration_EventBusV2ParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters = new Amazon.EventBridgeV2.Model.EventBusV2Parameters();
            Dictionary<System.String, System.String> requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_Metadata = null;
            if (cmdletContext.InvokeConfiguration_EventBusV2Parameters_Metadata != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_Metadata = cmdletContext.InvokeConfiguration_EventBusV2Parameters_Metadata;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_Metadata != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters.Metadata = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_Metadata;
                requestInvokeConfiguration_invokeConfiguration_EventBusV2ParametersIsNull = false;
            }
            Amazon.EventBridgeV2.Model.DeduplicationConfiguration requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration = null;
            
             // populate DeduplicationConfiguration
            var requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfigurationIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration = new Amazon.EventBridgeV2.Model.DeduplicationConfiguration();
            Amazon.EventBridgeV2.DeduplicationType requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType = null;
            if (cmdletContext.InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType = cmdletContext.InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration.DeduplicationType = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType;
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfigurationIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfigurationIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters.DeduplicationConfiguration = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration;
                requestInvokeConfiguration_invokeConfiguration_EventBusV2ParametersIsNull = false;
            }
            Amazon.EventBridgeV2.Model.EventBusV2SystemMetadata requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata = null;
            
             // populate SystemMetadata
            var requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadataIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata = new Amazon.EventBridgeV2.Model.EventBusV2SystemMetadata();
            System.String requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId = null;
            if (cmdletContext.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId = cmdletContext.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata.DeduplicationId = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId;
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadataIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId = null;
            if (cmdletContext.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId = cmdletContext.InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata.EventGroupId = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata_invokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId;
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadataIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadataIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata != null)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters.SystemMetadata = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters_invokeConfiguration_EventBusV2Parameters_SystemMetadata;
                requestInvokeConfiguration_invokeConfiguration_EventBusV2ParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2ParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters != null)
            {
                request.InvokeConfiguration.EventBusV2Parameters = requestInvokeConfiguration_invokeConfiguration_EventBusV2Parameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.HttpParameters requestInvokeConfiguration_invokeConfiguration_HttpParameters = null;
            
             // populate HttpParameters
            var requestInvokeConfiguration_invokeConfiguration_HttpParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_HttpParameters = new Amazon.EventBridgeV2.Model.HttpParameters();
            Dictionary<System.String, System.String> requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_HeaderParameter = null;
            if (cmdletContext.InvokeConfiguration_HttpParameters_HeaderParameter != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_HeaderParameter = cmdletContext.InvokeConfiguration_HttpParameters_HeaderParameter;
            }
            if (requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_HeaderParameter != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters.HeaderParameters = requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_HeaderParameter;
                requestInvokeConfiguration_invokeConfiguration_HttpParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_InvocationTimeoutSecond = null;
            if (cmdletContext.InvokeConfiguration_HttpParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_InvocationTimeoutSecond = cmdletContext.InvokeConfiguration_HttpParameters_InvocationTimeoutSecond;
            }
            if (requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters.InvocationTimeoutSeconds = requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_InvocationTimeoutSecond;
                requestInvokeConfiguration_invokeConfiguration_HttpParametersIsNull = false;
            }
            List<System.String> requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_PathParameterValue = null;
            if (cmdletContext.InvokeConfiguration_HttpParameters_PathParameterValue != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_PathParameterValue = cmdletContext.InvokeConfiguration_HttpParameters_PathParameterValue;
            }
            if (requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_PathParameterValue != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters.PathParameterValues = requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_PathParameterValue;
                requestInvokeConfiguration_invokeConfiguration_HttpParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_QueryStringParameter = null;
            if (cmdletContext.InvokeConfiguration_HttpParameters_QueryStringParameter != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_QueryStringParameter = cmdletContext.InvokeConfiguration_HttpParameters_QueryStringParameter;
            }
            if (requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_QueryStringParameter != null)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters.QueryStringParameters = requestInvokeConfiguration_invokeConfiguration_HttpParameters_invokeConfiguration_HttpParameters_QueryStringParameter;
                requestInvokeConfiguration_invokeConfiguration_HttpParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_HttpParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_HttpParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_HttpParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_HttpParameters != null)
            {
                request.InvokeConfiguration.HttpParameters = requestInvokeConfiguration_invokeConfiguration_HttpParameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.StepFunctionsParameters requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters = null;
            
             // populate StepFunctionsParameters
            var requestInvokeConfiguration_invokeConfiguration_StepFunctionsParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters = new Amazon.EventBridgeV2.Model.StepFunctionsParameters();
            System.String requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond = null;
            if (cmdletContext.InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond = cmdletContext.InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond;
            }
            if (requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters.InvocationTimeoutSeconds = requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond;
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParametersIsNull = false;
            }
            Amazon.EventBridgeV2.InvocationType requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationType = null;
            if (cmdletContext.InvokeConfiguration_StepFunctionsParameters_InvocationType != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationType = cmdletContext.InvokeConfiguration_StepFunctionsParameters_InvocationType;
            }
            if (requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationType != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters.InvocationType = requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_InvocationType;
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_Name = null;
            if (cmdletContext.InvokeConfiguration_StepFunctionsParameters_Name != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_Name = cmdletContext.InvokeConfiguration_StepFunctionsParameters_Name;
            }
            if (requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_Name != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters.Name = requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_Name;
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_TraceHeader = null;
            if (cmdletContext.InvokeConfiguration_StepFunctionsParameters_TraceHeader != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_TraceHeader = cmdletContext.InvokeConfiguration_StepFunctionsParameters_TraceHeader;
            }
            if (requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_TraceHeader != null)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters.TraceHeader = requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters_invokeConfiguration_StepFunctionsParameters_TraceHeader;
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_StepFunctionsParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters != null)
            {
                request.InvokeConfiguration.StepFunctionsParameters = requestInvokeConfiguration_invokeConfiguration_StepFunctionsParameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.LambdaParameters requestInvokeConfiguration_invokeConfiguration_LambdaParameters = null;
            
             // populate LambdaParameters
            var requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_LambdaParameters = new Amazon.EventBridgeV2.Model.LambdaParameters();
            System.String requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_DurableExecutionName = null;
            if (cmdletContext.InvokeConfiguration_LambdaParameters_DurableExecutionName != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_DurableExecutionName = cmdletContext.InvokeConfiguration_LambdaParameters_DurableExecutionName;
            }
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_DurableExecutionName != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters.DurableExecutionName = requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_DurableExecutionName;
                requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationTimeoutSecond = null;
            if (cmdletContext.InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationTimeoutSecond = cmdletContext.InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond;
            }
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationTimeoutSecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters.InvocationTimeoutSeconds = requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationTimeoutSecond;
                requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull = false;
            }
            Amazon.EventBridgeV2.InvocationType requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationType = null;
            if (cmdletContext.InvokeConfiguration_LambdaParameters_InvocationType != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationType = cmdletContext.InvokeConfiguration_LambdaParameters_InvocationType;
            }
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationType != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters.InvocationType = requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_InvocationType;
                requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_Qualifier = null;
            if (cmdletContext.InvokeConfiguration_LambdaParameters_Qualifier != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_Qualifier = cmdletContext.InvokeConfiguration_LambdaParameters_Qualifier;
            }
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_Qualifier != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters.Qualifier = requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_Qualifier;
                requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_TenantId = null;
            if (cmdletContext.InvokeConfiguration_LambdaParameters_TenantId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_TenantId = cmdletContext.InvokeConfiguration_LambdaParameters_TenantId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_TenantId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters.TenantId = requestInvokeConfiguration_invokeConfiguration_LambdaParameters_invokeConfiguration_LambdaParameters_TenantId;
                requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_LambdaParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_LambdaParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_LambdaParameters != null)
            {
                request.InvokeConfiguration.LambdaParameters = requestInvokeConfiguration_invokeConfiguration_LambdaParameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.SnsParameters requestInvokeConfiguration_invokeConfiguration_SnsParameters = null;
            
             // populate SnsParameters
            var requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_SnsParameters = new Amazon.EventBridgeV2.Model.SnsParameters();
            Dictionary<System.String, Amazon.EventBridgeV2.Model.SnsMessageAttributeValue> requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageAttribute = null;
            if (cmdletContext.InvokeConfiguration_SnsParameters_MessageAttribute != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageAttribute = cmdletContext.InvokeConfiguration_SnsParameters_MessageAttribute;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageAttribute != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters.MessageAttributes = requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageAttribute;
                requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageDeduplicationId = null;
            if (cmdletContext.InvokeConfiguration_SnsParameters_MessageDeduplicationId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageDeduplicationId = cmdletContext.InvokeConfiguration_SnsParameters_MessageDeduplicationId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageDeduplicationId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters.MessageDeduplicationId = requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageDeduplicationId;
                requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageGroupId = null;
            if (cmdletContext.InvokeConfiguration_SnsParameters_MessageGroupId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageGroupId = cmdletContext.InvokeConfiguration_SnsParameters_MessageGroupId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageGroupId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters.MessageGroupId = requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageGroupId;
                requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageStructure = null;
            if (cmdletContext.InvokeConfiguration_SnsParameters_MessageStructure != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageStructure = cmdletContext.InvokeConfiguration_SnsParameters_MessageStructure;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageStructure != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters.MessageStructure = requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_MessageStructure;
                requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_Subject = null;
            if (cmdletContext.InvokeConfiguration_SnsParameters_Subject != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_Subject = cmdletContext.InvokeConfiguration_SnsParameters_Subject;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_Subject != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters.Subject = requestInvokeConfiguration_invokeConfiguration_SnsParameters_invokeConfiguration_SnsParameters_Subject;
                requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_SnsParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_SnsParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_SnsParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SnsParameters != null)
            {
                request.InvokeConfiguration.SnsParameters = requestInvokeConfiguration_invokeConfiguration_SnsParameters;
                requestInvokeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.SqsParameters requestInvokeConfiguration_invokeConfiguration_SqsParameters = null;
            
             // populate SqsParameters
            var requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull = true;
            requestInvokeConfiguration_invokeConfiguration_SqsParameters = new Amazon.EventBridgeV2.Model.SqsParameters();
            System.String requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_DelaySecond = null;
            if (cmdletContext.InvokeConfiguration_SqsParameters_DelaySecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_DelaySecond = cmdletContext.InvokeConfiguration_SqsParameters_DelaySecond;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_DelaySecond != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters.DelaySeconds = requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_DelaySecond;
                requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull = false;
            }
            Dictionary<System.String, Amazon.EventBridgeV2.Model.SqsMessageAttributeValue> requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageAttribute = null;
            if (cmdletContext.InvokeConfiguration_SqsParameters_MessageAttribute != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageAttribute = cmdletContext.InvokeConfiguration_SqsParameters_MessageAttribute;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageAttribute != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters.MessageAttributes = requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageAttribute;
                requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageDeduplicationId = null;
            if (cmdletContext.InvokeConfiguration_SqsParameters_MessageDeduplicationId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageDeduplicationId = cmdletContext.InvokeConfiguration_SqsParameters_MessageDeduplicationId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageDeduplicationId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters.MessageDeduplicationId = requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageDeduplicationId;
                requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull = false;
            }
            System.String requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageGroupId = null;
            if (cmdletContext.InvokeConfiguration_SqsParameters_MessageGroupId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageGroupId = cmdletContext.InvokeConfiguration_SqsParameters_MessageGroupId;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageGroupId != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters.MessageGroupId = requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageGroupId;
                requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull = false;
            }
            Dictionary<System.String, Amazon.EventBridgeV2.Model.SqsMessageAttributeValue> requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageSystemAttribute = null;
            if (cmdletContext.InvokeConfiguration_SqsParameters_MessageSystemAttribute != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageSystemAttribute = cmdletContext.InvokeConfiguration_SqsParameters_MessageSystemAttribute;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageSystemAttribute != null)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters.MessageSystemAttributes = requestInvokeConfiguration_invokeConfiguration_SqsParameters_invokeConfiguration_SqsParameters_MessageSystemAttribute;
                requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull = false;
            }
             // determine if requestInvokeConfiguration_invokeConfiguration_SqsParameters should be set to null
            if (requestInvokeConfiguration_invokeConfiguration_SqsParametersIsNull)
            {
                requestInvokeConfiguration_invokeConfiguration_SqsParameters = null;
            }
            if (requestInvokeConfiguration_invokeConfiguration_SqsParameters != null)
            {
                request.InvokeConfiguration.SqsParameters = requestInvokeConfiguration_invokeConfiguration_SqsParameters;
                requestInvokeConfigurationIsNull = false;
            }
             // determine if request.InvokeConfiguration should be set to null
            if (requestInvokeConfigurationIsNull)
            {
                request.InvokeConfiguration = null;
            }
            
             // populate LogConfiguration
            var requestLogConfigurationIsNull = true;
            request.LogConfiguration = new Amazon.EventBridgeV2.Model.LogConfiguration();
            Amazon.EventBridgeV2.IncludePayload requestLogConfiguration_logConfiguration_IncludePayload = null;
            if (cmdletContext.LogConfiguration_IncludePayload != null)
            {
                requestLogConfiguration_logConfiguration_IncludePayload = cmdletContext.LogConfiguration_IncludePayload;
            }
            if (requestLogConfiguration_logConfiguration_IncludePayload != null)
            {
                request.LogConfiguration.IncludePayload = requestLogConfiguration_logConfiguration_IncludePayload;
                requestLogConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.LogLevel requestLogConfiguration_logConfiguration_Level = null;
            if (cmdletContext.LogConfiguration_Level != null)
            {
                requestLogConfiguration_logConfiguration_Level = cmdletContext.LogConfiguration_Level;
            }
            if (requestLogConfiguration_logConfiguration_Level != null)
            {
                request.LogConfiguration.Level = requestLogConfiguration_logConfiguration_Level;
                requestLogConfigurationIsNull = false;
            }
             // determine if request.LogConfiguration should be set to null
            if (requestLogConfigurationIsNull)
            {
                request.LogConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OnFailureConfiguration
            var requestOnFailureConfigurationIsNull = true;
            request.OnFailureConfiguration = new Amazon.EventBridgeV2.Model.OnFailureConfiguration();
            System.String requestOnFailureConfiguration_onFailureConfiguration_Arn = null;
            if (cmdletContext.OnFailureConfiguration_Arn != null)
            {
                requestOnFailureConfiguration_onFailureConfiguration_Arn = cmdletContext.OnFailureConfiguration_Arn;
            }
            if (requestOnFailureConfiguration_onFailureConfiguration_Arn != null)
            {
                request.OnFailureConfiguration.Arn = requestOnFailureConfiguration_onFailureConfiguration_Arn;
                requestOnFailureConfigurationIsNull = false;
            }
             // determine if request.OnFailureConfiguration should be set to null
            if (requestOnFailureConfigurationIsNull)
            {
                request.OnFailureConfiguration = null;
            }
            
             // populate PointInTimeConfiguration
            var requestPointInTimeConfigurationIsNull = true;
            request.PointInTimeConfiguration = new Amazon.EventBridgeV2.Model.PointInTimeConfiguration();
            System.DateTime? requestPointInTimeConfiguration_pointInTimeConfiguration_EndPoint = null;
            if (cmdletContext.PointInTimeConfiguration_EndPoint != null)
            {
                requestPointInTimeConfiguration_pointInTimeConfiguration_EndPoint = cmdletContext.PointInTimeConfiguration_EndPoint.Value;
            }
            if (requestPointInTimeConfiguration_pointInTimeConfiguration_EndPoint != null)
            {
                request.PointInTimeConfiguration.EndPoint = requestPointInTimeConfiguration_pointInTimeConfiguration_EndPoint.Value;
                requestPointInTimeConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.PointType requestPointInTimeConfiguration_pointInTimeConfiguration_PointType = null;
            if (cmdletContext.PointInTimeConfiguration_PointType != null)
            {
                requestPointInTimeConfiguration_pointInTimeConfiguration_PointType = cmdletContext.PointInTimeConfiguration_PointType;
            }
            if (requestPointInTimeConfiguration_pointInTimeConfiguration_PointType != null)
            {
                request.PointInTimeConfiguration.PointType = requestPointInTimeConfiguration_pointInTimeConfiguration_PointType;
                requestPointInTimeConfigurationIsNull = false;
            }
            System.DateTime? requestPointInTimeConfiguration_pointInTimeConfiguration_StartingPoint = null;
            if (cmdletContext.PointInTimeConfiguration_StartingPoint != null)
            {
                requestPointInTimeConfiguration_pointInTimeConfiguration_StartingPoint = cmdletContext.PointInTimeConfiguration_StartingPoint.Value;
            }
            if (requestPointInTimeConfiguration_pointInTimeConfiguration_StartingPoint != null)
            {
                request.PointInTimeConfiguration.StartingPoint = requestPointInTimeConfiguration_pointInTimeConfiguration_StartingPoint.Value;
                requestPointInTimeConfigurationIsNull = false;
            }
             // determine if request.PointInTimeConfiguration should be set to null
            if (requestPointInTimeConfigurationIsNull)
            {
                request.PointInTimeConfiguration = null;
            }
            
             // populate RetryPolicy
            var requestRetryPolicyIsNull = true;
            request.RetryPolicy = new Amazon.EventBridgeV2.Model.RetryPolicy();
            System.Int32? requestRetryPolicy_retryPolicy_MaxEventAgeInSecond = null;
            if (cmdletContext.RetryPolicy_MaxEventAgeInSecond != null)
            {
                requestRetryPolicy_retryPolicy_MaxEventAgeInSecond = cmdletContext.RetryPolicy_MaxEventAgeInSecond.Value;
            }
            if (requestRetryPolicy_retryPolicy_MaxEventAgeInSecond != null)
            {
                request.RetryPolicy.MaxEventAgeInSeconds = requestRetryPolicy_retryPolicy_MaxEventAgeInSecond.Value;
                requestRetryPolicyIsNull = false;
            }
            System.Int32? requestRetryPolicy_retryPolicy_MaxRetryAttempt = null;
            if (cmdletContext.RetryPolicy_MaxRetryAttempt != null)
            {
                requestRetryPolicy_retryPolicy_MaxRetryAttempt = cmdletContext.RetryPolicy_MaxRetryAttempt.Value;
            }
            if (requestRetryPolicy_retryPolicy_MaxRetryAttempt != null)
            {
                request.RetryPolicy.MaxRetryAttempts = requestRetryPolicy_retryPolicy_MaxRetryAttempt.Value;
                requestRetryPolicyIsNull = false;
            }
            Amazon.EventBridgeV2.RetryStrategy requestRetryPolicy_retryPolicy_RetryStrategy = null;
            if (cmdletContext.RetryPolicy_RetryStrategy != null)
            {
                requestRetryPolicy_retryPolicy_RetryStrategy = cmdletContext.RetryPolicy_RetryStrategy;
            }
            if (requestRetryPolicy_retryPolicy_RetryStrategy != null)
            {
                request.RetryPolicy.RetryStrategy = requestRetryPolicy_retryPolicy_RetryStrategy;
                requestRetryPolicyIsNull = false;
            }
             // determine if request.RetryPolicy should be set to null
            if (requestRetryPolicyIsNull)
            {
                request.RetryPolicy = null;
            }
            if (cmdletContext.StartingPosition != null)
            {
                request.StartingPosition = cmdletContext.StartingPosition;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Transformer
            var requestTransformerIsNull = true;
            request.Transformer = new Amazon.EventBridgeV2.Model.Transformer();
            Amazon.EventBridgeV2.TransformerType requestTransformer_transformer_Type = null;
            if (cmdletContext.Transformer_Type != null)
            {
                requestTransformer_transformer_Type = cmdletContext.Transformer_Type;
            }
            if (requestTransformer_transformer_Type != null)
            {
                request.Transformer.Type = requestTransformer_transformer_Type;
                requestTransformerIsNull = false;
            }
            Amazon.EventBridgeV2.Model.JsonataConfiguration requestTransformer_transformer_JsonataConfiguration = null;
            
             // populate JsonataConfiguration
            var requestTransformer_transformer_JsonataConfigurationIsNull = true;
            requestTransformer_transformer_JsonataConfiguration = new Amazon.EventBridgeV2.Model.JsonataConfiguration();
            System.String requestTransformer_transformer_JsonataConfiguration_transformer_JsonataConfiguration_Expression = null;
            if (cmdletContext.Transformer_JsonataConfiguration_Expression != null)
            {
                requestTransformer_transformer_JsonataConfiguration_transformer_JsonataConfiguration_Expression = cmdletContext.Transformer_JsonataConfiguration_Expression;
            }
            if (requestTransformer_transformer_JsonataConfiguration_transformer_JsonataConfiguration_Expression != null)
            {
                requestTransformer_transformer_JsonataConfiguration.Expression = requestTransformer_transformer_JsonataConfiguration_transformer_JsonataConfiguration_Expression;
                requestTransformer_transformer_JsonataConfigurationIsNull = false;
            }
             // determine if requestTransformer_transformer_JsonataConfiguration should be set to null
            if (requestTransformer_transformer_JsonataConfigurationIsNull)
            {
                requestTransformer_transformer_JsonataConfiguration = null;
            }
            if (requestTransformer_transformer_JsonataConfiguration != null)
            {
                request.Transformer.JsonataConfiguration = requestTransformer_transformer_JsonataConfiguration;
                requestTransformerIsNull = false;
            }
             // determine if request.Transformer should be set to null
            if (requestTransformerIsNull)
            {
                request.Transformer = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.EventBridgeV2.Model.CreateSubscriberResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.CreateSubscriberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "CreateSubscriber");
            try
            {
                return client.CreateSubscriberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? BatchConfiguration_MaxBatchSize { get; set; }
            public System.Int32? BatchConfiguration_MaxBatchWindowInSecond { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String EventBusArn { get; set; }
            public List<Amazon.EventBridgeV2.Model.Filter> FilterConfiguration_Filter { get; set; }
            public Amazon.EventBridgeV2.FilterLanguage FilterConfiguration_Language { get; set; }
            public Amazon.EventBridgeV2.DeduplicationType InvokeConfiguration_EventBusV2Parameters_DeduplicationConfiguration_DeduplicationType { get; set; }
            public Dictionary<System.String, System.String> InvokeConfiguration_EventBusV2Parameters_Metadata { get; set; }
            public System.String InvokeConfiguration_EventBusV2Parameters_SystemMetadata_DeduplicationId { get; set; }
            public System.String InvokeConfiguration_EventBusV2Parameters_SystemMetadata_EventGroupId { get; set; }
            public Dictionary<System.String, System.String> InvokeConfiguration_HttpParameters_HeaderParameter { get; set; }
            public System.String InvokeConfiguration_HttpParameters_InvocationTimeoutSecond { get; set; }
            public List<System.String> InvokeConfiguration_HttpParameters_PathParameterValue { get; set; }
            public Dictionary<System.String, System.String> InvokeConfiguration_HttpParameters_QueryStringParameter { get; set; }
            public System.String InvokeConfiguration_KinesisParameters_ExplicitHashKey { get; set; }
            public System.String InvokeConfiguration_KinesisParameters_PartitionKey { get; set; }
            public System.String InvokeConfiguration_LambdaParameters_DurableExecutionName { get; set; }
            public System.String InvokeConfiguration_LambdaParameters_InvocationTimeoutSecond { get; set; }
            public Amazon.EventBridgeV2.InvocationType InvokeConfiguration_LambdaParameters_InvocationType { get; set; }
            public System.String InvokeConfiguration_LambdaParameters_Qualifier { get; set; }
            public System.String InvokeConfiguration_LambdaParameters_TenantId { get; set; }
            public System.String InvokeConfiguration_RoleArn { get; set; }
            public Dictionary<System.String, Amazon.EventBridgeV2.Model.SnsMessageAttributeValue> InvokeConfiguration_SnsParameters_MessageAttribute { get; set; }
            public System.String InvokeConfiguration_SnsParameters_MessageDeduplicationId { get; set; }
            public System.String InvokeConfiguration_SnsParameters_MessageGroupId { get; set; }
            public System.String InvokeConfiguration_SnsParameters_MessageStructure { get; set; }
            public System.String InvokeConfiguration_SnsParameters_Subject { get; set; }
            public System.String InvokeConfiguration_SqsParameters_DelaySecond { get; set; }
            public Dictionary<System.String, Amazon.EventBridgeV2.Model.SqsMessageAttributeValue> InvokeConfiguration_SqsParameters_MessageAttribute { get; set; }
            public System.String InvokeConfiguration_SqsParameters_MessageDeduplicationId { get; set; }
            public System.String InvokeConfiguration_SqsParameters_MessageGroupId { get; set; }
            public Dictionary<System.String, Amazon.EventBridgeV2.Model.SqsMessageAttributeValue> InvokeConfiguration_SqsParameters_MessageSystemAttribute { get; set; }
            public System.String InvokeConfiguration_StepFunctionsParameters_InvocationTimeoutSecond { get; set; }
            public Amazon.EventBridgeV2.InvocationType InvokeConfiguration_StepFunctionsParameters_InvocationType { get; set; }
            public System.String InvokeConfiguration_StepFunctionsParameters_Name { get; set; }
            public System.String InvokeConfiguration_StepFunctionsParameters_TraceHeader { get; set; }
            public System.String InvokeConfiguration_TargetArn { get; set; }
            public System.String InvokeConfiguration_UniversalTargetParameters_Input { get; set; }
            public System.String InvokeConfiguration_UniversalTargetParameters_InvocationTimeoutSecond { get; set; }
            public Amazon.EventBridgeV2.IncludePayload LogConfiguration_IncludePayload { get; set; }
            public Amazon.EventBridgeV2.LogLevel LogConfiguration_Level { get; set; }
            public System.String Name { get; set; }
            public System.String OnFailureConfiguration_Arn { get; set; }
            public System.DateTime? PointInTimeConfiguration_EndPoint { get; set; }
            public Amazon.EventBridgeV2.PointType PointInTimeConfiguration_PointType { get; set; }
            public System.DateTime? PointInTimeConfiguration_StartingPoint { get; set; }
            public System.Int32? RetryPolicy_MaxEventAgeInSecond { get; set; }
            public System.Int32? RetryPolicy_MaxRetryAttempt { get; set; }
            public Amazon.EventBridgeV2.RetryStrategy RetryPolicy_RetryStrategy { get; set; }
            public Amazon.EventBridgeV2.StartingPosition StartingPosition { get; set; }
            public Amazon.EventBridgeV2.SubscriberState State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Transformer_JsonataConfiguration_Expression { get; set; }
            public Amazon.EventBridgeV2.TransformerType Transformer_Type { get; set; }
            public Amazon.EventBridgeV2.OrderingType Type { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.CreateSubscriberResponse, NewEVBV2SubscriberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
