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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Replaces the rule. You must specify all parameters for the new rule. Creating rules
    /// is an administrator-level action. Any user who has permission to create rules will
    /// be able to access data processed by the rule.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">ReplaceTopicRule</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "IOTTopicRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT ReplaceTopicRule API operation.", Operation = new[] {"ReplaceTopicRule"}, SelectReturnType = typeof(Amazon.IoT.Model.ReplaceTopicRuleResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.ReplaceTopicRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.ReplaceTopicRuleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetIOTTopicRuleCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter TopicRulePayload_Action
        /// <summary>
        /// <para>
        /// <para>The actions associated with the rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TopicRulePayload_Actions")]
        public Amazon.IoT.Model.Action[] TopicRulePayload_Action { get; set; }
        #endregion
        
        #region Parameter CloudwatchAlarm_AlarmName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch alarm name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchAlarm_AlarmName")]
        public System.String CloudwatchAlarm_AlarmName { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_AwsIotSqlVersion
        /// <summary>
        /// <para>
        /// <para>The version of the SQL rules engine to use when evaluating the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TopicRulePayload_AwsIotSqlVersion { get; set; }
        #endregion
        
        #region Parameter Firehose_BatchMode
        /// <summary>
        /// <para>
        /// <para>Whether to deliver the Kinesis Data Firehose stream as a batch by using <a href="https://docs.aws.amazon.com/firehose/latest/APIReference/API_PutRecordBatch.html"><code>PutRecordBatch</code></a>. The default value is <code>false</code>.</para><para>When <code>batchMode</code> is <code>true</code> and the rule's SQL statement evaluates
        /// to an Array, each Array element forms one record in the <a href="https://docs.aws.amazon.com/firehose/latest/APIReference/API_PutRecordBatch.html"><code>PutRecordBatch</code></a> request. The resulting array can't have more than
        /// 500 records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Firehose_BatchMode")]
        public System.Boolean? Firehose_BatchMode { get; set; }
        #endregion
        
        #region Parameter IotAnalytics_BatchMode
        /// <summary>
        /// <para>
        /// <para>Whether to process the action as a batch. The default value is <code>false</code>.</para><para>When <code>batchMode</code> is <code>true</code> and the rule SQL statement evaluates
        /// to an Array, each Array element is delivered as a separate message when passed by
        /// <a href="https://docs.aws.amazon.com/iotanalytics/latest/APIReference/API_BatchPutMessage.html"><code>BatchPutMessage</code></a> to the IoT Analytics channel. The resulting array
        /// can't have more than 100 messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotAnalytics_BatchMode")]
        public System.Boolean? IotAnalytics_BatchMode { get; set; }
        #endregion
        
        #region Parameter IotEvents_BatchMode
        /// <summary>
        /// <para>
        /// <para>Whether to process the event actions as a batch. The default value is <code>false</code>.</para><para>When <code>batchMode</code> is <code>true</code>, you can't specify a <code>messageId</code>.
        /// </para><para>When <code>batchMode</code> is <code>true</code> and the rule SQL statement evaluates
        /// to an Array, each Array element is treated as a separate message when it's sent to
        /// IoT Events by calling <a href="https://docs.aws.amazon.com/iotevents/latest/apireference/API_iotevents-data_BatchPutMessage.html"><code>BatchPutMessage</code></a>. The resulting array can't have more than 10 messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotEvents_BatchMode")]
        public System.Boolean? IotEvents_BatchMode { get; set; }
        #endregion
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_CannedAcl
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 canned ACL that controls access to the object identified by the object
        /// key. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/acl-overview.html#canned-acl">S3
        /// canned ACLs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_S3_CannedAcl")]
        [AWSConstantClassSource("Amazon.IoT.CannedAccessControlList")]
        public Amazon.IoT.CannedAccessControlList S3_CannedAcl { get; set; }
        #endregion
        
        #region Parameter IotAnalytics_ChannelArn
        /// <summary>
        /// <para>
        /// <para>(deprecated) The ARN of the IoT Analytics channel to which message data will be sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotAnalytics_ChannelArn")]
        public System.String IotAnalytics_ChannelArn { get; set; }
        #endregion
        
        #region Parameter IotAnalytics_ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT Analytics channel to which message data will be sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotAnalytics_ChannelName")]
        public System.String IotAnalytics_ChannelName { get; set; }
        #endregion
        
        #region Parameter Kafka_ClientProperty
        /// <summary>
        /// <para>
        /// <para>Properties of the Apache Kafka producer client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kafka_ClientProperties")]
        public System.Collections.Hashtable Kafka_ClientProperty { get; set; }
        #endregion
        
        #region Parameter Http_ConfirmationUrl
        /// <summary>
        /// <para>
        /// <para>The URL to which IoT sends a confirmation message. The value of the confirmation URL
        /// must be a prefix of the endpoint URL. If you do not specify a confirmation URL IoT
        /// uses the endpoint URL as the confirmation URL. If you use substitution templates in
        /// the confirmationUrl, you must create and enable topic rule destinations that match
        /// each possible value of the substitution template before traffic is allowed to your
        /// endpoint URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Http_ConfirmationUrl")]
        public System.String Http_ConfirmationUrl { get; set; }
        #endregion
        
        #region Parameter Headers_ContentType
        /// <summary>
        /// <para>
        /// <para>A UTF-8 encoded string that describes the content of the publishing message.</para><para>For more information, see <a href="https://docs.oasis-open.org/mqtt/mqtt/v5.0/os/mqtt-v5.0-os.html#_Toc3901118">
        /// Content Type</a> from the MQTT Version 5.0 specification.</para><para>Supports <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-substitution-templates.html">substitution
        /// templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Headers_ContentType")]
        public System.String Headers_ContentType { get; set; }
        #endregion
        
        #region Parameter Headers_CorrelationData
        /// <summary>
        /// <para>
        /// <para>The base64-encoded binary data used by the sender of the request message to identify
        /// which request the response message is for when it's received.</para><para>For more information, see <a href="https://docs.oasis-open.org/mqtt/mqtt/v5.0/os/mqtt-v5.0-os.html#_Toc3901115">
        /// Correlation Data</a> from the MQTT Version 5.0 specification.</para><note><para> This binary data must be based64-encoded. </para></note><para>Supports <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-substitution-templates.html">substitution
        /// templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Headers_CorrelationData")]
        public System.String Headers_CorrelationData { get; set; }
        #endregion
        
        #region Parameter Timestream_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon Timestream database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Timestream_DatabaseName")]
        public System.String Timestream_DatabaseName { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The delivery stream name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Firehose_DeliveryStreamName")]
        public System.String Firehose_DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_Description
        /// <summary>
        /// <para>
        /// <para>The description of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TopicRulePayload_Description { get; set; }
        #endregion
        
        #region Parameter Kafka_DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of Kafka action's VPC <code>TopicRuleDestination</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kafka_DestinationArn")]
        public System.String Kafka_DestinationArn { get; set; }
        #endregion
        
        #region Parameter Location_DeviceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the device providing the location data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Location_DeviceId")]
        public System.String Location_DeviceId { get; set; }
        #endregion
        
        #region Parameter Timestream_Dimension
        /// <summary>
        /// <para>
        /// <para>Metadata attributes of the time series that are written in each measure record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Timestream_Dimensions")]
        public Amazon.IoT.Model.TimestreamDimension[] Timestream_Dimension { get; set; }
        #endregion
        
        #region Parameter Elasticsearch_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of your OpenSearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Elasticsearch_Endpoint")]
        public System.String Elasticsearch_Endpoint { get; set; }
        #endregion
        
        #region Parameter OpenSearch_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of your OpenSearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_OpenSearch_Endpoint")]
        public System.String OpenSearch_Endpoint { get; set; }
        #endregion
        
        #region Parameter StepFunctions_ExecutionNamePrefix
        /// <summary>
        /// <para>
        /// <para>(Optional) A name will be given to the state machine execution consisting of this
        /// prefix followed by a UUID. Step Functions automatically creates a unique name for
        /// each state machine execution if one is not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_StepFunctions_ExecutionNamePrefix")]
        public System.String StepFunctions_ExecutionNamePrefix { get; set; }
        #endregion
        
        #region Parameter Lambda_FunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Lambda_FunctionArn")]
        public System.String Lambda_FunctionArn { get; set; }
        #endregion
        
        #region Parameter DynamoDB_HashKeyField
        /// <summary>
        /// <para>
        /// <para>The hash key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_HashKeyField")]
        public System.String DynamoDB_HashKeyField { get; set; }
        #endregion
        
        #region Parameter DynamoDB_HashKeyType
        /// <summary>
        /// <para>
        /// <para>The hash key type. Valid values are "STRING" or "NUMBER"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_HashKeyType")]
        [AWSConstantClassSource("Amazon.IoT.DynamoKeyType")]
        public Amazon.IoT.DynamoKeyType DynamoDB_HashKeyType { get; set; }
        #endregion
        
        #region Parameter DynamoDB_HashKeyValue
        /// <summary>
        /// <para>
        /// <para>The hash key value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_HashKeyValue")]
        public System.String DynamoDB_HashKeyValue { get; set; }
        #endregion
        
        #region Parameter Http_Header
        /// <summary>
        /// <para>
        /// <para>The HTTP headers to send with the message data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Http_Headers")]
        public Amazon.IoT.Model.HttpActionHeader[] Http_Header { get; set; }
        #endregion
        
        #region Parameter Elasticsearch_Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the document you are storing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Elasticsearch_Id")]
        public System.String Elasticsearch_Id { get; set; }
        #endregion
        
        #region Parameter OpenSearch_Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the document you are storing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_OpenSearch_Id")]
        public System.String OpenSearch_Id { get; set; }
        #endregion
        
        #region Parameter Elasticsearch_Index
        /// <summary>
        /// <para>
        /// <para>The index where you want to store your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Elasticsearch_Index")]
        public System.String Elasticsearch_Index { get; set; }
        #endregion
        
        #region Parameter OpenSearch_Index
        /// <summary>
        /// <para>
        /// <para>The OpenSearch index where you want to store your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_OpenSearch_Index")]
        public System.String OpenSearch_Index { get; set; }
        #endregion
        
        #region Parameter IotEvents_InputName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT Events input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotEvents_InputName")]
        public System.String IotEvents_InputName { get; set; }
        #endregion
        
        #region Parameter Kafka_Key
        /// <summary>
        /// <para>
        /// <para>The Kafka message key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kafka_Key")]
        public System.String Kafka_Key { get; set; }
        #endregion
        
        #region Parameter S3_Key
        /// <summary>
        /// <para>
        /// <para>The object key. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/list_amazons3.html">Actions,
        /// resources, and condition keys for Amazon S3</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_S3_Key")]
        public System.String S3_Key { get; set; }
        #endregion
        
        #region Parameter Location_Latitude
        /// <summary>
        /// <para>
        /// <para>A string that evaluates to a double value that represents the latitude of the device's
        /// location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Location_Latitude")]
        public System.String Location_Latitude { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log group to which the action sends data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchLogs_LogGroupName")]
        public System.String CloudwatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter Location_Longitude
        /// <summary>
        /// <para>
        /// <para>A string that evaluates to a double value that represents the longitude of the device's
        /// location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Location_Longitude")]
        public System.String Location_Longitude { get; set; }
        #endregion
        
        #region Parameter Headers_MessageExpiry
        /// <summary>
        /// <para>
        /// <para>A user-defined integer value that will persist a message at the message broker for
        /// a specified amount of time to ensure that the message will expire if it's no longer
        /// relevant to the subscriber. The value of <code>messageExpiry</code> represents the
        /// number of seconds before it expires. For more information about the limits of <code>messageExpiry</code>,
        /// see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/mqtt.html">Amazon
        /// Web Services IoT Core message broker and protocol limits and quotas </a> from the
        /// Amazon Web Services Reference Guide.</para><para>Supports <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-substitution-templates.html">substitution
        /// templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Headers_MessageExpiry")]
        public System.String Headers_MessageExpiry { get; set; }
        #endregion
        
        #region Parameter Sns_MessageFormat
        /// <summary>
        /// <para>
        /// <para>(Optional) The message format of the message to publish. Accepted values are "JSON"
        /// and "RAW". The default value of the attribute is "RAW". SNS uses this setting to determine
        /// if the payload should be parsed and relevant platform-specific bits of the payload
        /// should be extracted. To read more about SNS message formats, see <a href="https://docs.aws.amazon.com/sns/latest/dg/json-formats.html">https://docs.aws.amazon.com/sns/latest/dg/json-formats.html</a>
        /// refer to their official documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Sns_MessageFormat")]
        [AWSConstantClassSource("Amazon.IoT.MessageFormat")]
        public Amazon.IoT.MessageFormat Sns_MessageFormat { get; set; }
        #endregion
        
        #region Parameter IotEvents_MessageId
        /// <summary>
        /// <para>
        /// <para>The ID of the message. The default <code>messageId</code> is a new UUID value.</para><para>When <code>batchMode</code> is <code>true</code>, you can't specify a <code>messageId</code>--a
        /// new UUID value will be assigned.</para><para>Assign a value to this property to ensure that only one input (message) with a given
        /// <code>messageId</code> will be processed by an IoT Events detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotEvents_MessageId")]
        public System.String IotEvents_MessageId { get; set; }
        #endregion
        
        #region Parameter CloudwatchMetric_MetricName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch metric name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchMetric_MetricName")]
        public System.String CloudwatchMetric_MetricName { get; set; }
        #endregion
        
        #region Parameter CloudwatchMetric_MetricNamespace
        /// <summary>
        /// <para>
        /// <para>The CloudWatch metric namespace name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchMetric_MetricNamespace")]
        public System.String CloudwatchMetric_MetricNamespace { get; set; }
        #endregion
        
        #region Parameter CloudwatchMetric_MetricTimestamp
        /// <summary>
        /// <para>
        /// <para>An optional <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/cloudwatch_concepts.html#about_timestamp">Unix
        /// timestamp</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchMetric_MetricTimestamp")]
        public System.String CloudwatchMetric_MetricTimestamp { get; set; }
        #endregion
        
        #region Parameter CloudwatchMetric_MetricUnit
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/cloudwatch_concepts.html#Unit">metric
        /// unit</a> supported by CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchMetric_MetricUnit")]
        public System.String CloudwatchMetric_MetricUnit { get; set; }
        #endregion
        
        #region Parameter CloudwatchMetric_MetricValue
        /// <summary>
        /// <para>
        /// <para>The CloudWatch metric value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchMetric_MetricValue")]
        public System.String CloudwatchMetric_MetricValue { get; set; }
        #endregion
        
        #region Parameter DynamoDB_Operation
        /// <summary>
        /// <para>
        /// <para>The type of operation to be performed. This follows the substitution template, so
        /// it can be <code>${operation}</code>, but the substitution must result in one of the
        /// following: <code>INSERT</code>, <code>UPDATE</code>, or <code>DELETE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_Operation")]
        public System.String DynamoDB_Operation { get; set; }
        #endregion
        
        #region Parameter Kafka_Partition
        /// <summary>
        /// <para>
        /// <para>The Kafka message partition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kafka_Partition")]
        public System.String Kafka_Partition { get; set; }
        #endregion
        
        #region Parameter Kinesis_PartitionKey
        /// <summary>
        /// <para>
        /// <para>The partition key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kinesis_PartitionKey")]
        public System.String Kinesis_PartitionKey { get; set; }
        #endregion
        
        #region Parameter DynamoDB_PayloadField
        /// <summary>
        /// <para>
        /// <para>The action payload. This name can be customized.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_PayloadField")]
        public System.String DynamoDB_PayloadField { get; set; }
        #endregion
        
        #region Parameter Headers_PayloadFormatIndicator
        /// <summary>
        /// <para>
        /// <para>An <code>Enum</code> string value that indicates whether the payload is formatted
        /// as UTF-8.</para><para>Valid values are <code>UNSPECIFIED_BYTES</code> and <code>UTF8_DATA</code>.</para><para>For more information, see <a href="https://docs.oasis-open.org/mqtt/mqtt/v5.0/os/mqtt-v5.0-os.html#_Toc3901111">
        /// Payload Format Indicator</a> from the MQTT Version 5.0 specification.</para><para>Supports <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-substitution-templates.html">substitution
        /// templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Headers_PayloadFormatIndicator")]
        public System.String Headers_PayloadFormatIndicator { get; set; }
        #endregion
        
        #region Parameter IotSiteWise_PutAssetPropertyValueEntry
        /// <summary>
        /// <para>
        /// <para>A list of asset property value entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotSiteWise_PutAssetPropertyValueEntries")]
        public Amazon.IoT.Model.PutAssetPropertyValueEntry[] IotSiteWise_PutAssetPropertyValueEntry { get; set; }
        #endregion
        
        #region Parameter Republish_Qo
        /// <summary>
        /// <para>
        /// <para>The Quality of Service (QoS) level to use when republishing messages. The default
        /// value is 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Qos")]
        public System.Int32? Republish_Qo { get; set; }
        #endregion
        
        #region Parameter Sqs_QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Sqs_QueueUrl")]
        public System.String Sqs_QueueUrl { get; set; }
        #endregion
        
        #region Parameter DynamoDB_RangeKeyField
        /// <summary>
        /// <para>
        /// <para>The range key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_RangeKeyField")]
        public System.String DynamoDB_RangeKeyField { get; set; }
        #endregion
        
        #region Parameter DynamoDB_RangeKeyType
        /// <summary>
        /// <para>
        /// <para>The range key type. Valid values are "STRING" or "NUMBER"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_RangeKeyType")]
        [AWSConstantClassSource("Amazon.IoT.DynamoKeyType")]
        public Amazon.IoT.DynamoKeyType DynamoDB_RangeKeyType { get; set; }
        #endregion
        
        #region Parameter DynamoDB_RangeKeyValue
        /// <summary>
        /// <para>
        /// <para>The range key value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_RangeKeyValue")]
        public System.String DynamoDB_RangeKeyValue { get; set; }
        #endregion
        
        #region Parameter Headers_ResponseTopic
        /// <summary>
        /// <para>
        /// <para>A UTF-8 encoded string that's used as the topic name for a response message. The response
        /// topic is used to describe the topic which the receiver should publish to as part of
        /// the request-response flow. The topic must not contain wildcard characters.</para><para>For more information, see <a href="https://docs.oasis-open.org/mqtt/mqtt/v5.0/os/mqtt-v5.0-os.html#_Toc3901114">
        /// Response Topic</a> from the MQTT Version 5.0 specification.</para><para>Supports <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-substitution-templates.html">substitution
        /// templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Headers_ResponseTopic")]
        public System.String Headers_ResponseTopic { get; set; }
        #endregion
        
        #region Parameter CloudwatchAlarm_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that allows access to the CloudWatch alarm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchAlarm_RoleArn")]
        public System.String CloudwatchAlarm_RoleArn { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogs_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that allows access to the CloudWatch log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchLogs_RoleArn")]
        public System.String CloudwatchLogs_RoleArn { get; set; }
        #endregion
        
        #region Parameter CloudwatchMetric_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that allows access to the CloudWatch metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchMetric_RoleArn")]
        public System.String CloudwatchMetric_RoleArn { get; set; }
        #endregion
        
        #region Parameter DynamoDB_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access to the DynamoDB table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_RoleArn")]
        public System.String DynamoDB_RoleArn { get; set; }
        #endregion
        
        #region Parameter DynamoDBv2_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access to the DynamoDB table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDBv2_RoleArn")]
        public System.String DynamoDBv2_RoleArn { get; set; }
        #endregion
        
        #region Parameter Elasticsearch_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN that has access to OpenSearch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Elasticsearch_RoleArn")]
        public System.String Elasticsearch_RoleArn { get; set; }
        #endregion
        
        #region Parameter Firehose_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that grants access to the Amazon Kinesis Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Firehose_RoleArn")]
        public System.String Firehose_RoleArn { get; set; }
        #endregion
        
        #region Parameter Sigv4_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the signing role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Http_Auth_Sigv4_RoleArn")]
        public System.String Sigv4_RoleArn { get; set; }
        #endregion
        
        #region Parameter IotAnalytics_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role which has a policy that grants IoT Analytics permission to send
        /// message data via IoT Analytics (iotanalytics:BatchPutMessage).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotAnalytics_RoleArn")]
        public System.String IotAnalytics_RoleArn { get; set; }
        #endregion
        
        #region Parameter IotEvents_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants IoT permission to send an input to an IoT Events detector.
        /// ("Action":"iotevents:BatchPutMessage").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotEvents_RoleArn")]
        public System.String IotEvents_RoleArn { get; set; }
        #endregion
        
        #region Parameter IotSiteWise_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants IoT permission to send an asset property value to
        /// IoT SiteWise. (<code>"Action": "iotsitewise:BatchPutAssetPropertyValue"</code>). The
        /// trust policy can restrict access to specific asset hierarchy paths.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_IotSiteWise_RoleArn")]
        public System.String IotSiteWise_RoleArn { get; set; }
        #endregion
        
        #region Parameter Kinesis_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access to the Amazon Kinesis stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kinesis_RoleArn")]
        public System.String Kinesis_RoleArn { get; set; }
        #endregion
        
        #region Parameter Location_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that grants permission to write to the Amazon Location resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Location_RoleArn")]
        public System.String Location_RoleArn { get; set; }
        #endregion
        
        #region Parameter OpenSearch_RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN that has access to OpenSearch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_OpenSearch_RoleArn")]
        public System.String OpenSearch_RoleArn { get; set; }
        #endregion
        
        #region Parameter Republish_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_RoleArn")]
        public System.String Republish_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_S3_RoleArn")]
        public System.String S3_RoleArn { get; set; }
        #endregion
        
        #region Parameter Sns_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Sns_RoleArn")]
        public System.String Sns_RoleArn { get; set; }
        #endregion
        
        #region Parameter Sqs_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Sqs_RoleArn")]
        public System.String Sqs_RoleArn { get; set; }
        #endregion
        
        #region Parameter StepFunctions_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants IoT permission to start execution of a state machine
        /// ("Action":"states:StartExecution").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_StepFunctions_RoleArn")]
        public System.String StepFunctions_RoleArn { get; set; }
        #endregion
        
        #region Parameter Timestream_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants permission to write to the Amazon Timestream database
        /// table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Timestream_RoleArn")]
        public System.String Timestream_RoleArn { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_RuleDisabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the rule is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TopicRulePayload_RuleDisabled { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the rule.</para>
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
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter Firehose_Separator
        /// <summary>
        /// <para>
        /// <para>A character separator that will be used to separate records written to the Firehose
        /// stream. Valid values are: '\n' (newline), '\t' (tab), '\r\n' (Windows newline), ','
        /// (comma).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Firehose_Separator")]
        public System.String Firehose_Separator { get; set; }
        #endregion
        
        #region Parameter Sigv4_ServiceName
        /// <summary>
        /// <para>
        /// <para>The service name to use while signing with Sig V4.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Http_Auth_Sigv4_ServiceName")]
        public System.String Sigv4_ServiceName { get; set; }
        #endregion
        
        #region Parameter Sigv4_SigningRegion
        /// <summary>
        /// <para>
        /// <para>The signing region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Http_Auth_Sigv4_SigningRegion")]
        public System.String Sigv4_SigningRegion { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_Sql
        /// <summary>
        /// <para>
        /// <para>The SQL statement used to query the topic. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-sql-reference.html">IoT
        /// SQL Reference</a> in the <i>IoT Developer Guide</i>.</para>
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
        public System.String TopicRulePayload_Sql { get; set; }
        #endregion
        
        #region Parameter StepFunctions_StateMachineName
        /// <summary>
        /// <para>
        /// <para>The name of the Step Functions state machine whose execution will be started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_StepFunctions_StateMachineName")]
        public System.String StepFunctions_StateMachineName { get; set; }
        #endregion
        
        #region Parameter CloudwatchAlarm_StateReason
        /// <summary>
        /// <para>
        /// <para>The reason for the alarm change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchAlarm_StateReason")]
        public System.String CloudwatchAlarm_StateReason { get; set; }
        #endregion
        
        #region Parameter CloudwatchAlarm_StateValue
        /// <summary>
        /// <para>
        /// <para>The value of the alarm state. Acceptable values are: OK, ALARM, INSUFFICIENT_DATA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_CloudwatchAlarm_StateValue")]
        public System.String CloudwatchAlarm_StateValue { get; set; }
        #endregion
        
        #region Parameter Kinesis_StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Kinesis stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kinesis_StreamName")]
        public System.String Kinesis_StreamName { get; set; }
        #endregion
        
        #region Parameter DynamoDB_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the DynamoDB table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDB_TableName")]
        public System.String DynamoDB_TableName { get; set; }
        #endregion
        
        #region Parameter PutItem_TableName
        /// <summary>
        /// <para>
        /// <para>The table where the message data will be written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_DynamoDBv2_PutItem_TableName")]
        public System.String PutItem_TableName { get; set; }
        #endregion
        
        #region Parameter Timestream_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the database table into which to write the measure records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Timestream_TableName")]
        public System.String Timestream_TableName { get; set; }
        #endregion
        
        #region Parameter Sns_TargetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Sns_TargetArn")]
        public System.String Sns_TargetArn { get; set; }
        #endregion
        
        #region Parameter Salesforce_Token
        /// <summary>
        /// <para>
        /// <para>The token used to authenticate access to the Salesforce IoT Cloud Input Stream. The
        /// token is available from the Salesforce IoT Cloud platform after creation of the Input
        /// Stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Salesforce_Token")]
        public System.String Salesforce_Token { get; set; }
        #endregion
        
        #region Parameter Kafka_Topic
        /// <summary>
        /// <para>
        /// <para>The Kafka topic for messages to be sent to the Kafka broker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Kafka_Topic")]
        public System.String Kafka_Topic { get; set; }
        #endregion
        
        #region Parameter Republish_Topic
        /// <summary>
        /// <para>
        /// <para>The name of the MQTT topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Topic")]
        public System.String Republish_Topic { get; set; }
        #endregion
        
        #region Parameter Location_TrackerName
        /// <summary>
        /// <para>
        /// <para>The name of the tracker resource in Amazon Location in which the location is updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Location_TrackerName")]
        public System.String Location_TrackerName { get; set; }
        #endregion
        
        #region Parameter Elasticsearch_Type
        /// <summary>
        /// <para>
        /// <para>The type of document you are storing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Elasticsearch_Type")]
        public System.String Elasticsearch_Type { get; set; }
        #endregion
        
        #region Parameter OpenSearch_Type
        /// <summary>
        /// <para>
        /// <para>The type of document you are storing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_OpenSearch_Type")]
        public System.String OpenSearch_Type { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_ErrorAction_Location_Timestamp_Unit
        /// <summary>
        /// <para>
        /// <para>The precision of the timestamp value that results from the expression described in
        /// <code>value</code>.</para><para>Valid values: <code>SECONDS</code> | <code>MILLISECONDS</code> | <code>MICROSECONDS</code>
        /// | <code>NANOSECONDS</code>. The default is <code>MILLISECONDS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TopicRulePayload_ErrorAction_Location_Timestamp_Unit { get; set; }
        #endregion
        
        #region Parameter Timestamp_Unit
        /// <summary>
        /// <para>
        /// <para>The precision of the timestamp value that results from the expression described in
        /// <code>value</code>.</para><para>Valid values: <code>SECONDS</code> | <code>MILLISECONDS</code> | <code>MICROSECONDS</code>
        /// | <code>NANOSECONDS</code>. The default is <code>MILLISECONDS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Timestream_Timestamp_Unit")]
        public System.String Timestamp_Unit { get; set; }
        #endregion
        
        #region Parameter Http_Url
        /// <summary>
        /// <para>
        /// <para>The endpoint URL. If substitution templates are used in the URL, you must also specify
        /// a <code>confirmationUrl</code>. If this is a new destination, a new <code>TopicRuleDestination</code>
        /// is created if possible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Http_Url")]
        public System.String Http_Url { get; set; }
        #endregion
        
        #region Parameter Salesforce_Url
        /// <summary>
        /// <para>
        /// <para>The URL exposed by the Salesforce IoT Cloud Input Stream. The URL is available from
        /// the Salesforce IoT Cloud platform after creation of the Input Stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Salesforce_Url")]
        public System.String Salesforce_Url { get; set; }
        #endregion
        
        #region Parameter Sqs_UseBase64
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use Base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Sqs_UseBase64")]
        public System.Boolean? Sqs_UseBase64 { get; set; }
        #endregion
        
        #region Parameter Headers_UserProperty
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs that you define in the MQTT5 header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Republish_Headers_UserProperties")]
        public Amazon.IoT.Model.UserProperty[] Headers_UserProperty { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_ErrorAction_Location_Timestamp_Value
        /// <summary>
        /// <para>
        /// <para>An expression that returns a long epoch time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TopicRulePayload_ErrorAction_Location_Timestamp_Value { get; set; }
        #endregion
        
        #region Parameter Timestamp_Value
        /// <summary>
        /// <para>
        /// <para>An expression that returns a long epoch time value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicRulePayload_ErrorAction_Timestream_Timestamp_Value")]
        public System.String Timestamp_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.ReplaceTopicRuleResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTTopicRule (ReplaceTopicRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.ReplaceTopicRuleResponse, SetIOTTopicRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RuleName = this.RuleName;
            #if MODULAR
            if (this.RuleName == null && ParameterWasBound(nameof(this.RuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TopicRulePayload_Action != null)
            {
                context.TopicRulePayload_Action = new List<Amazon.IoT.Model.Action>(this.TopicRulePayload_Action);
            }
            #if MODULAR
            if (this.TopicRulePayload_Action == null && ParameterWasBound(nameof(this.TopicRulePayload_Action)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicRulePayload_Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TopicRulePayload_AwsIotSqlVersion = this.TopicRulePayload_AwsIotSqlVersion;
            context.TopicRulePayload_Description = this.TopicRulePayload_Description;
            context.CloudwatchAlarm_AlarmName = this.CloudwatchAlarm_AlarmName;
            context.CloudwatchAlarm_RoleArn = this.CloudwatchAlarm_RoleArn;
            context.CloudwatchAlarm_StateReason = this.CloudwatchAlarm_StateReason;
            context.CloudwatchAlarm_StateValue = this.CloudwatchAlarm_StateValue;
            context.CloudwatchLogs_LogGroupName = this.CloudwatchLogs_LogGroupName;
            context.CloudwatchLogs_RoleArn = this.CloudwatchLogs_RoleArn;
            context.CloudwatchMetric_MetricName = this.CloudwatchMetric_MetricName;
            context.CloudwatchMetric_MetricNamespace = this.CloudwatchMetric_MetricNamespace;
            context.CloudwatchMetric_MetricTimestamp = this.CloudwatchMetric_MetricTimestamp;
            context.CloudwatchMetric_MetricUnit = this.CloudwatchMetric_MetricUnit;
            context.CloudwatchMetric_MetricValue = this.CloudwatchMetric_MetricValue;
            context.CloudwatchMetric_RoleArn = this.CloudwatchMetric_RoleArn;
            context.DynamoDB_HashKeyField = this.DynamoDB_HashKeyField;
            context.DynamoDB_HashKeyType = this.DynamoDB_HashKeyType;
            context.DynamoDB_HashKeyValue = this.DynamoDB_HashKeyValue;
            context.DynamoDB_Operation = this.DynamoDB_Operation;
            context.DynamoDB_PayloadField = this.DynamoDB_PayloadField;
            context.DynamoDB_RangeKeyField = this.DynamoDB_RangeKeyField;
            context.DynamoDB_RangeKeyType = this.DynamoDB_RangeKeyType;
            context.DynamoDB_RangeKeyValue = this.DynamoDB_RangeKeyValue;
            context.DynamoDB_RoleArn = this.DynamoDB_RoleArn;
            context.DynamoDB_TableName = this.DynamoDB_TableName;
            context.PutItem_TableName = this.PutItem_TableName;
            context.DynamoDBv2_RoleArn = this.DynamoDBv2_RoleArn;
            context.Elasticsearch_Endpoint = this.Elasticsearch_Endpoint;
            context.Elasticsearch_Id = this.Elasticsearch_Id;
            context.Elasticsearch_Index = this.Elasticsearch_Index;
            context.Elasticsearch_RoleArn = this.Elasticsearch_RoleArn;
            context.Elasticsearch_Type = this.Elasticsearch_Type;
            context.Firehose_BatchMode = this.Firehose_BatchMode;
            context.Firehose_DeliveryStreamName = this.Firehose_DeliveryStreamName;
            context.Firehose_RoleArn = this.Firehose_RoleArn;
            context.Firehose_Separator = this.Firehose_Separator;
            context.Sigv4_RoleArn = this.Sigv4_RoleArn;
            context.Sigv4_ServiceName = this.Sigv4_ServiceName;
            context.Sigv4_SigningRegion = this.Sigv4_SigningRegion;
            context.Http_ConfirmationUrl = this.Http_ConfirmationUrl;
            if (this.Http_Header != null)
            {
                context.Http_Header = new List<Amazon.IoT.Model.HttpActionHeader>(this.Http_Header);
            }
            context.Http_Url = this.Http_Url;
            context.IotAnalytics_BatchMode = this.IotAnalytics_BatchMode;
            context.IotAnalytics_ChannelArn = this.IotAnalytics_ChannelArn;
            context.IotAnalytics_ChannelName = this.IotAnalytics_ChannelName;
            context.IotAnalytics_RoleArn = this.IotAnalytics_RoleArn;
            context.IotEvents_BatchMode = this.IotEvents_BatchMode;
            context.IotEvents_InputName = this.IotEvents_InputName;
            context.IotEvents_MessageId = this.IotEvents_MessageId;
            context.IotEvents_RoleArn = this.IotEvents_RoleArn;
            if (this.IotSiteWise_PutAssetPropertyValueEntry != null)
            {
                context.IotSiteWise_PutAssetPropertyValueEntry = new List<Amazon.IoT.Model.PutAssetPropertyValueEntry>(this.IotSiteWise_PutAssetPropertyValueEntry);
            }
            context.IotSiteWise_RoleArn = this.IotSiteWise_RoleArn;
            if (this.Kafka_ClientProperty != null)
            {
                context.Kafka_ClientProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Kafka_ClientProperty.Keys)
                {
                    context.Kafka_ClientProperty.Add((String)hashKey, (String)(this.Kafka_ClientProperty[hashKey]));
                }
            }
            context.Kafka_DestinationArn = this.Kafka_DestinationArn;
            context.Kafka_Key = this.Kafka_Key;
            context.Kafka_Partition = this.Kafka_Partition;
            context.Kafka_Topic = this.Kafka_Topic;
            context.Kinesis_PartitionKey = this.Kinesis_PartitionKey;
            context.Kinesis_RoleArn = this.Kinesis_RoleArn;
            context.Kinesis_StreamName = this.Kinesis_StreamName;
            context.Lambda_FunctionArn = this.Lambda_FunctionArn;
            context.Location_DeviceId = this.Location_DeviceId;
            context.Location_Latitude = this.Location_Latitude;
            context.Location_Longitude = this.Location_Longitude;
            context.Location_RoleArn = this.Location_RoleArn;
            context.TopicRulePayload_ErrorAction_Location_Timestamp_Unit = this.TopicRulePayload_ErrorAction_Location_Timestamp_Unit;
            context.TopicRulePayload_ErrorAction_Location_Timestamp_Value = this.TopicRulePayload_ErrorAction_Location_Timestamp_Value;
            context.Location_TrackerName = this.Location_TrackerName;
            context.OpenSearch_Endpoint = this.OpenSearch_Endpoint;
            context.OpenSearch_Id = this.OpenSearch_Id;
            context.OpenSearch_Index = this.OpenSearch_Index;
            context.OpenSearch_RoleArn = this.OpenSearch_RoleArn;
            context.OpenSearch_Type = this.OpenSearch_Type;
            context.Headers_ContentType = this.Headers_ContentType;
            context.Headers_CorrelationData = this.Headers_CorrelationData;
            context.Headers_MessageExpiry = this.Headers_MessageExpiry;
            context.Headers_PayloadFormatIndicator = this.Headers_PayloadFormatIndicator;
            context.Headers_ResponseTopic = this.Headers_ResponseTopic;
            if (this.Headers_UserProperty != null)
            {
                context.Headers_UserProperty = new List<Amazon.IoT.Model.UserProperty>(this.Headers_UserProperty);
            }
            context.Republish_Qo = this.Republish_Qo;
            context.Republish_RoleArn = this.Republish_RoleArn;
            context.Republish_Topic = this.Republish_Topic;
            context.S3_BucketName = this.S3_BucketName;
            context.S3_CannedAcl = this.S3_CannedAcl;
            context.S3_Key = this.S3_Key;
            context.S3_RoleArn = this.S3_RoleArn;
            context.Salesforce_Token = this.Salesforce_Token;
            context.Salesforce_Url = this.Salesforce_Url;
            context.Sns_MessageFormat = this.Sns_MessageFormat;
            context.Sns_RoleArn = this.Sns_RoleArn;
            context.Sns_TargetArn = this.Sns_TargetArn;
            context.Sqs_QueueUrl = this.Sqs_QueueUrl;
            context.Sqs_RoleArn = this.Sqs_RoleArn;
            context.Sqs_UseBase64 = this.Sqs_UseBase64;
            context.StepFunctions_ExecutionNamePrefix = this.StepFunctions_ExecutionNamePrefix;
            context.StepFunctions_RoleArn = this.StepFunctions_RoleArn;
            context.StepFunctions_StateMachineName = this.StepFunctions_StateMachineName;
            context.Timestream_DatabaseName = this.Timestream_DatabaseName;
            if (this.Timestream_Dimension != null)
            {
                context.Timestream_Dimension = new List<Amazon.IoT.Model.TimestreamDimension>(this.Timestream_Dimension);
            }
            context.Timestream_RoleArn = this.Timestream_RoleArn;
            context.Timestream_TableName = this.Timestream_TableName;
            context.Timestamp_Unit = this.Timestamp_Unit;
            context.Timestamp_Value = this.Timestamp_Value;
            context.TopicRulePayload_RuleDisabled = this.TopicRulePayload_RuleDisabled;
            context.TopicRulePayload_Sql = this.TopicRulePayload_Sql;
            #if MODULAR
            if (this.TopicRulePayload_Sql == null && ParameterWasBound(nameof(this.TopicRulePayload_Sql)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicRulePayload_Sql which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.ReplaceTopicRuleRequest();
            
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            
             // populate TopicRulePayload
            var requestTopicRulePayloadIsNull = true;
            request.TopicRulePayload = new Amazon.IoT.Model.TopicRulePayload();
            List<Amazon.IoT.Model.Action> requestTopicRulePayload_topicRulePayload_Action = null;
            if (cmdletContext.TopicRulePayload_Action != null)
            {
                requestTopicRulePayload_topicRulePayload_Action = cmdletContext.TopicRulePayload_Action;
            }
            if (requestTopicRulePayload_topicRulePayload_Action != null)
            {
                request.TopicRulePayload.Actions = requestTopicRulePayload_topicRulePayload_Action;
                requestTopicRulePayloadIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion = null;
            if (cmdletContext.TopicRulePayload_AwsIotSqlVersion != null)
            {
                requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion = cmdletContext.TopicRulePayload_AwsIotSqlVersion;
            }
            if (requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion != null)
            {
                request.TopicRulePayload.AwsIotSqlVersion = requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion;
                requestTopicRulePayloadIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_Description = null;
            if (cmdletContext.TopicRulePayload_Description != null)
            {
                requestTopicRulePayload_topicRulePayload_Description = cmdletContext.TopicRulePayload_Description;
            }
            if (requestTopicRulePayload_topicRulePayload_Description != null)
            {
                request.TopicRulePayload.Description = requestTopicRulePayload_topicRulePayload_Description;
                requestTopicRulePayloadIsNull = false;
            }
            System.Boolean? requestTopicRulePayload_topicRulePayload_RuleDisabled = null;
            if (cmdletContext.TopicRulePayload_RuleDisabled != null)
            {
                requestTopicRulePayload_topicRulePayload_RuleDisabled = cmdletContext.TopicRulePayload_RuleDisabled.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_RuleDisabled != null)
            {
                request.TopicRulePayload.RuleDisabled = requestTopicRulePayload_topicRulePayload_RuleDisabled.Value;
                requestTopicRulePayloadIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_Sql = null;
            if (cmdletContext.TopicRulePayload_Sql != null)
            {
                requestTopicRulePayload_topicRulePayload_Sql = cmdletContext.TopicRulePayload_Sql;
            }
            if (requestTopicRulePayload_topicRulePayload_Sql != null)
            {
                request.TopicRulePayload.Sql = requestTopicRulePayload_topicRulePayload_Sql;
                requestTopicRulePayloadIsNull = false;
            }
            Amazon.IoT.Model.Action requestTopicRulePayload_topicRulePayload_ErrorAction = null;
            
             // populate ErrorAction
            var requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction = new Amazon.IoT.Model.Action();
            Amazon.IoT.Model.LambdaAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda = null;
            
             // populate Lambda
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LambdaIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda = new Amazon.IoT.Model.LambdaAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda_lambda_FunctionArn = null;
            if (cmdletContext.Lambda_FunctionArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda_lambda_FunctionArn = cmdletContext.Lambda_FunctionArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda_lambda_FunctionArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda.FunctionArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda_lambda_FunctionArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LambdaIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LambdaIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Lambda = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Lambda;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.CloudwatchLogsAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs = null;
            
             // populate CloudwatchLogs
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogsIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs = new Amazon.IoT.Model.CloudwatchLogsAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_LogGroupName = null;
            if (cmdletContext.CloudwatchLogs_LogGroupName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_LogGroupName = cmdletContext.CloudwatchLogs_LogGroupName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_LogGroupName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs.LogGroupName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_LogGroupName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_RoleArn = null;
            if (cmdletContext.CloudwatchLogs_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_RoleArn = cmdletContext.CloudwatchLogs_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs_cloudwatchLogs_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogsIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogsIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.CloudwatchLogs = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchLogs;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.DynamoDBv2Action requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2 = null;
            
             // populate DynamoDBv2
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2IsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2 = new Amazon.IoT.Model.DynamoDBv2Action();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_dynamoDBv2_RoleArn = null;
            if (cmdletContext.DynamoDBv2_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_dynamoDBv2_RoleArn = cmdletContext.DynamoDBv2_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_dynamoDBv2_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_dynamoDBv2_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2IsNull = false;
            }
            Amazon.IoT.Model.PutItemInput requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem = null;
            
             // populate PutItem
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItemIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem = new Amazon.IoT.Model.PutItemInput();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem_putItem_TableName = null;
            if (cmdletContext.PutItem_TableName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem_putItem_TableName = cmdletContext.PutItem_TableName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem_putItem_TableName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem.TableName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem_putItem_TableName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItemIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItemIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2.PutItem = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2_topicRulePayload_ErrorAction_DynamoDBv2_PutItem;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2IsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2 should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2IsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2 = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2 != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.DynamoDBv2 = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBv2;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.IotSiteWiseAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise = null;
            
             // populate IotSiteWise
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWiseIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise = new Amazon.IoT.Model.IotSiteWiseAction();
            List<Amazon.IoT.Model.PutAssetPropertyValueEntry> requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_PutAssetPropertyValueEntry = null;
            if (cmdletContext.IotSiteWise_PutAssetPropertyValueEntry != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_PutAssetPropertyValueEntry = cmdletContext.IotSiteWise_PutAssetPropertyValueEntry;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_PutAssetPropertyValueEntry != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise.PutAssetPropertyValueEntries = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_PutAssetPropertyValueEntry;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWiseIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_RoleArn = null;
            if (cmdletContext.IotSiteWise_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_RoleArn = cmdletContext.IotSiteWise_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise_iotSiteWise_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWiseIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWiseIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.IotSiteWise = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotSiteWise;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.SalesforceAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce = null;
            
             // populate Salesforce
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SalesforceIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce = new Amazon.IoT.Model.SalesforceAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Token = null;
            if (cmdletContext.Salesforce_Token != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Token = cmdletContext.Salesforce_Token;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Token != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce.Token = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Token;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SalesforceIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Url = null;
            if (cmdletContext.Salesforce_Url != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Url = cmdletContext.Salesforce_Url;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Url != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce.Url = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce_salesforce_Url;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SalesforceIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SalesforceIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Salesforce = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Salesforce;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.KinesisAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis = null;
            
             // populate Kinesis
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KinesisIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis = new Amazon.IoT.Model.KinesisAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_PartitionKey = null;
            if (cmdletContext.Kinesis_PartitionKey != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_PartitionKey = cmdletContext.Kinesis_PartitionKey;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_PartitionKey != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis.PartitionKey = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_PartitionKey;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KinesisIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_RoleArn = null;
            if (cmdletContext.Kinesis_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_RoleArn = cmdletContext.Kinesis_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KinesisIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_StreamName = null;
            if (cmdletContext.Kinesis_StreamName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_StreamName = cmdletContext.Kinesis_StreamName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_StreamName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis.StreamName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis_kinesis_StreamName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KinesisIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KinesisIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Kinesis = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kinesis;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.SnsAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns = null;
            
             // populate Sns
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SnsIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns = new Amazon.IoT.Model.SnsAction();
            Amazon.IoT.MessageFormat requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_MessageFormat = null;
            if (cmdletContext.Sns_MessageFormat != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_MessageFormat = cmdletContext.Sns_MessageFormat;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_MessageFormat != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns.MessageFormat = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_MessageFormat;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SnsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_RoleArn = null;
            if (cmdletContext.Sns_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_RoleArn = cmdletContext.Sns_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SnsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_TargetArn = null;
            if (cmdletContext.Sns_TargetArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_TargetArn = cmdletContext.Sns_TargetArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_TargetArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns.TargetArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns_sns_TargetArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SnsIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SnsIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Sns = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sns;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.SqsAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs = null;
            
             // populate Sqs
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SqsIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs = new Amazon.IoT.Model.SqsAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_QueueUrl = null;
            if (cmdletContext.Sqs_QueueUrl != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_QueueUrl = cmdletContext.Sqs_QueueUrl;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_QueueUrl != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs.QueueUrl = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_QueueUrl;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SqsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_RoleArn = null;
            if (cmdletContext.Sqs_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_RoleArn = cmdletContext.Sqs_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SqsIsNull = false;
            }
            System.Boolean? requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_UseBase64 = null;
            if (cmdletContext.Sqs_UseBase64 != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_UseBase64 = cmdletContext.Sqs_UseBase64.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_UseBase64 != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs.UseBase64 = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs_sqs_UseBase64.Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SqsIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_SqsIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Sqs = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Sqs;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.StepFunctionsAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions = null;
            
             // populate StepFunctions
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctionsIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions = new Amazon.IoT.Model.StepFunctionsAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_ExecutionNamePrefix = null;
            if (cmdletContext.StepFunctions_ExecutionNamePrefix != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_ExecutionNamePrefix = cmdletContext.StepFunctions_ExecutionNamePrefix;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_ExecutionNamePrefix != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions.ExecutionNamePrefix = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_ExecutionNamePrefix;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctionsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_RoleArn = null;
            if (cmdletContext.StepFunctions_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_RoleArn = cmdletContext.StepFunctions_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctionsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_StateMachineName = null;
            if (cmdletContext.StepFunctions_StateMachineName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_StateMachineName = cmdletContext.StepFunctions_StateMachineName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_StateMachineName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions.StateMachineName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions_stepFunctions_StateMachineName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctionsIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctionsIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.StepFunctions = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_StepFunctions;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.CloudwatchAlarmAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm = null;
            
             // populate CloudwatchAlarm
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarmIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm = new Amazon.IoT.Model.CloudwatchAlarmAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_AlarmName = null;
            if (cmdletContext.CloudwatchAlarm_AlarmName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_AlarmName = cmdletContext.CloudwatchAlarm_AlarmName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_AlarmName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm.AlarmName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_AlarmName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarmIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_RoleArn = null;
            if (cmdletContext.CloudwatchAlarm_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_RoleArn = cmdletContext.CloudwatchAlarm_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarmIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateReason = null;
            if (cmdletContext.CloudwatchAlarm_StateReason != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateReason = cmdletContext.CloudwatchAlarm_StateReason;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateReason != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm.StateReason = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateReason;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarmIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateValue = null;
            if (cmdletContext.CloudwatchAlarm_StateValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateValue = cmdletContext.CloudwatchAlarm_StateValue;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm.StateValue = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm_cloudwatchAlarm_StateValue;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarmIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarmIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.CloudwatchAlarm = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchAlarm;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.FirehoseAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose = null;
            
             // populate Firehose
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_FirehoseIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose = new Amazon.IoT.Model.FirehoseAction();
            System.Boolean? requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_BatchMode = null;
            if (cmdletContext.Firehose_BatchMode != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_BatchMode = cmdletContext.Firehose_BatchMode.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_BatchMode != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose.BatchMode = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_BatchMode.Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_FirehoseIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_DeliveryStreamName = null;
            if (cmdletContext.Firehose_DeliveryStreamName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_DeliveryStreamName = cmdletContext.Firehose_DeliveryStreamName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_DeliveryStreamName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose.DeliveryStreamName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_DeliveryStreamName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_FirehoseIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_RoleArn = null;
            if (cmdletContext.Firehose_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_RoleArn = cmdletContext.Firehose_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_FirehoseIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_Separator = null;
            if (cmdletContext.Firehose_Separator != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_Separator = cmdletContext.Firehose_Separator;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_Separator != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose.Separator = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose_firehose_Separator;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_FirehoseIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_FirehoseIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Firehose = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Firehose;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.HttpAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http = null;
            
             // populate Http
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_HttpIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http = new Amazon.IoT.Model.HttpAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_ConfirmationUrl = null;
            if (cmdletContext.Http_ConfirmationUrl != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_ConfirmationUrl = cmdletContext.Http_ConfirmationUrl;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_ConfirmationUrl != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http.ConfirmationUrl = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_ConfirmationUrl;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_HttpIsNull = false;
            }
            List<Amazon.IoT.Model.HttpActionHeader> requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Header = null;
            if (cmdletContext.Http_Header != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Header = cmdletContext.Http_Header;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Header != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http.Headers = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Header;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_HttpIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Url = null;
            if (cmdletContext.Http_Url != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Url = cmdletContext.Http_Url;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Url != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http.Url = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_http_Url;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_HttpIsNull = false;
            }
            Amazon.IoT.Model.HttpAuthorization requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth = null;
            
             // populate Auth
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_AuthIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth = new Amazon.IoT.Model.HttpAuthorization();
            Amazon.IoT.Model.SigV4Authorization requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4 = null;
            
             // populate Sigv4
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4IsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4 = new Amazon.IoT.Model.SigV4Authorization();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_RoleArn = null;
            if (cmdletContext.Sigv4_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_RoleArn = cmdletContext.Sigv4_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4IsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_ServiceName = null;
            if (cmdletContext.Sigv4_ServiceName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_ServiceName = cmdletContext.Sigv4_ServiceName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_ServiceName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4.ServiceName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_ServiceName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4IsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_SigningRegion = null;
            if (cmdletContext.Sigv4_SigningRegion != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_SigningRegion = cmdletContext.Sigv4_SigningRegion;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_SigningRegion != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4.SigningRegion = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4_sigv4_SigningRegion;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4IsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4 should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4IsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4 = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4 != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth.Sigv4 = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth_topicRulePayload_ErrorAction_Http_Auth_Sigv4;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_AuthIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_AuthIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http.Auth = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http_topicRulePayload_ErrorAction_Http_Auth;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_HttpIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_HttpIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Http = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Http;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.IotAnalyticsAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics = null;
            
             // populate IotAnalytics
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalyticsIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics = new Amazon.IoT.Model.IotAnalyticsAction();
            System.Boolean? requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_BatchMode = null;
            if (cmdletContext.IotAnalytics_BatchMode != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_BatchMode = cmdletContext.IotAnalytics_BatchMode.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_BatchMode != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics.BatchMode = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_BatchMode.Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalyticsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelArn = null;
            if (cmdletContext.IotAnalytics_ChannelArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelArn = cmdletContext.IotAnalytics_ChannelArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics.ChannelArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalyticsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelName = null;
            if (cmdletContext.IotAnalytics_ChannelName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelName = cmdletContext.IotAnalytics_ChannelName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics.ChannelName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_ChannelName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalyticsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_RoleArn = null;
            if (cmdletContext.IotAnalytics_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_RoleArn = cmdletContext.IotAnalytics_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics_iotAnalytics_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalyticsIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalyticsIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.IotAnalytics = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotAnalytics;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.IotEventsAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents = null;
            
             // populate IotEvents
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEventsIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents = new Amazon.IoT.Model.IotEventsAction();
            System.Boolean? requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_BatchMode = null;
            if (cmdletContext.IotEvents_BatchMode != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_BatchMode = cmdletContext.IotEvents_BatchMode.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_BatchMode != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents.BatchMode = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_BatchMode.Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEventsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_InputName = null;
            if (cmdletContext.IotEvents_InputName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_InputName = cmdletContext.IotEvents_InputName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_InputName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents.InputName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_InputName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEventsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_MessageId = null;
            if (cmdletContext.IotEvents_MessageId != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_MessageId = cmdletContext.IotEvents_MessageId;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_MessageId != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents.MessageId = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_MessageId;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEventsIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_RoleArn = null;
            if (cmdletContext.IotEvents_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_RoleArn = cmdletContext.IotEvents_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents_iotEvents_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEventsIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEventsIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.IotEvents = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_IotEvents;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.RepublishAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish = null;
            
             // populate Republish
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_RepublishIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish = new Amazon.IoT.Model.RepublishAction();
            System.Int32? requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Qo = null;
            if (cmdletContext.Republish_Qo != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Qo = cmdletContext.Republish_Qo.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Qo != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish.Qos = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Qo.Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_RepublishIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_RoleArn = null;
            if (cmdletContext.Republish_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_RoleArn = cmdletContext.Republish_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_RepublishIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Topic = null;
            if (cmdletContext.Republish_Topic != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Topic = cmdletContext.Republish_Topic;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Topic != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish.Topic = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_republish_Topic;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_RepublishIsNull = false;
            }
            Amazon.IoT.Model.MqttHeaders requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers = null;
            
             // populate Headers
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers = new Amazon.IoT.Model.MqttHeaders();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ContentType = null;
            if (cmdletContext.Headers_ContentType != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ContentType = cmdletContext.Headers_ContentType;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ContentType != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers.ContentType = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ContentType;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_CorrelationData = null;
            if (cmdletContext.Headers_CorrelationData != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_CorrelationData = cmdletContext.Headers_CorrelationData;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_CorrelationData != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers.CorrelationData = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_CorrelationData;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_MessageExpiry = null;
            if (cmdletContext.Headers_MessageExpiry != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_MessageExpiry = cmdletContext.Headers_MessageExpiry;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_MessageExpiry != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers.MessageExpiry = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_MessageExpiry;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_PayloadFormatIndicator = null;
            if (cmdletContext.Headers_PayloadFormatIndicator != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_PayloadFormatIndicator = cmdletContext.Headers_PayloadFormatIndicator;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_PayloadFormatIndicator != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers.PayloadFormatIndicator = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_PayloadFormatIndicator;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ResponseTopic = null;
            if (cmdletContext.Headers_ResponseTopic != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ResponseTopic = cmdletContext.Headers_ResponseTopic;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ResponseTopic != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers.ResponseTopic = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_ResponseTopic;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = false;
            }
            List<Amazon.IoT.Model.UserProperty> requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_UserProperty = null;
            if (cmdletContext.Headers_UserProperty != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_UserProperty = cmdletContext.Headers_UserProperty;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_UserProperty != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers.UserProperties = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers_headers_UserProperty;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_HeadersIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish.Headers = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish_topicRulePayload_ErrorAction_Republish_Headers;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_RepublishIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_RepublishIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Republish = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Republish;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.S3Action requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3 = null;
            
             // populate S3
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3IsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3 = new Amazon.IoT.Model.S3Action();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_BucketName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3.BucketName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_BucketName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3IsNull = false;
            }
            Amazon.IoT.CannedAccessControlList requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_CannedAcl = null;
            if (cmdletContext.S3_CannedAcl != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_CannedAcl = cmdletContext.S3_CannedAcl;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_CannedAcl != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3.CannedAcl = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_CannedAcl;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3IsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_Key = null;
            if (cmdletContext.S3_Key != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_Key = cmdletContext.S3_Key;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_Key != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3.Key = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_Key;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3IsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_RoleArn = null;
            if (cmdletContext.S3_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_RoleArn = cmdletContext.S3_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3_s3_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3IsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3 should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3IsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3 = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3 != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.S3 = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_S3;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.ElasticsearchAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch = null;
            
             // populate Elasticsearch
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch = new Amazon.IoT.Model.ElasticsearchAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Endpoint = null;
            if (cmdletContext.Elasticsearch_Endpoint != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Endpoint = cmdletContext.Elasticsearch_Endpoint;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Endpoint != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch.Endpoint = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Endpoint;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Id = null;
            if (cmdletContext.Elasticsearch_Id != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Id = cmdletContext.Elasticsearch_Id;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Id != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch.Id = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Id;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Index = null;
            if (cmdletContext.Elasticsearch_Index != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Index = cmdletContext.Elasticsearch_Index;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Index != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch.Index = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Index;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_RoleArn = null;
            if (cmdletContext.Elasticsearch_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_RoleArn = cmdletContext.Elasticsearch_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Type = null;
            if (cmdletContext.Elasticsearch_Type != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Type = cmdletContext.Elasticsearch_Type;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Type != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch.Type = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch_elasticsearch_Type;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_ElasticsearchIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Elasticsearch = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Elasticsearch;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.KafkaAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka = null;
            
             // populate Kafka
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka = new Amazon.IoT.Model.KafkaAction();
            Dictionary<System.String, System.String> requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_ClientProperty = null;
            if (cmdletContext.Kafka_ClientProperty != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_ClientProperty = cmdletContext.Kafka_ClientProperty;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_ClientProperty != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka.ClientProperties = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_ClientProperty;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_DestinationArn = null;
            if (cmdletContext.Kafka_DestinationArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_DestinationArn = cmdletContext.Kafka_DestinationArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_DestinationArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka.DestinationArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_DestinationArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Key = null;
            if (cmdletContext.Kafka_Key != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Key = cmdletContext.Kafka_Key;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Key != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka.Key = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Key;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Partition = null;
            if (cmdletContext.Kafka_Partition != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Partition = cmdletContext.Kafka_Partition;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Partition != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka.Partition = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Partition;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Topic = null;
            if (cmdletContext.Kafka_Topic != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Topic = cmdletContext.Kafka_Topic;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Topic != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka.Topic = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka_kafka_Topic;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_KafkaIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Kafka = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Kafka;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.OpenSearchAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch = null;
            
             // populate OpenSearch
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch = new Amazon.IoT.Model.OpenSearchAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Endpoint = null;
            if (cmdletContext.OpenSearch_Endpoint != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Endpoint = cmdletContext.OpenSearch_Endpoint;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Endpoint != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch.Endpoint = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Endpoint;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Id = null;
            if (cmdletContext.OpenSearch_Id != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Id = cmdletContext.OpenSearch_Id;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Id != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch.Id = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Id;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Index = null;
            if (cmdletContext.OpenSearch_Index != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Index = cmdletContext.OpenSearch_Index;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Index != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch.Index = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Index;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_RoleArn = null;
            if (cmdletContext.OpenSearch_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_RoleArn = cmdletContext.OpenSearch_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Type = null;
            if (cmdletContext.OpenSearch_Type != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Type = cmdletContext.OpenSearch_Type;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Type != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch.Type = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch_openSearch_Type;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearchIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.OpenSearch = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_OpenSearch;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.TimestreamAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream = null;
            
             // populate Timestream
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream = new Amazon.IoT.Model.TimestreamAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_DatabaseName = null;
            if (cmdletContext.Timestream_DatabaseName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_DatabaseName = cmdletContext.Timestream_DatabaseName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_DatabaseName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream.DatabaseName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_DatabaseName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull = false;
            }
            List<Amazon.IoT.Model.TimestreamDimension> requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_Dimension = null;
            if (cmdletContext.Timestream_Dimension != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_Dimension = cmdletContext.Timestream_Dimension;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_Dimension != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream.Dimensions = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_Dimension;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_RoleArn = null;
            if (cmdletContext.Timestream_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_RoleArn = cmdletContext.Timestream_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_TableName = null;
            if (cmdletContext.Timestream_TableName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_TableName = cmdletContext.Timestream_TableName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_TableName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream.TableName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_timestream_TableName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull = false;
            }
            Amazon.IoT.Model.TimestreamTimestamp requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp = null;
            
             // populate Timestamp
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_TimestampIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp = new Amazon.IoT.Model.TimestreamTimestamp();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Unit = null;
            if (cmdletContext.Timestamp_Unit != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Unit = cmdletContext.Timestamp_Unit;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Unit != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp.Unit = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Unit;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_TimestampIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Value = null;
            if (cmdletContext.Timestamp_Value != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Value = cmdletContext.Timestamp_Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Value != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp.Value = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp_timestamp_Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_TimestampIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_TimestampIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream.Timestamp = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream_topicRulePayload_ErrorAction_Timestream_Timestamp;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_TimestreamIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Timestream = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Timestream;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.CloudwatchMetricAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric = null;
            
             // populate CloudwatchMetric
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric = new Amazon.IoT.Model.CloudwatchMetricAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricName = null;
            if (cmdletContext.CloudwatchMetric_MetricName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricName = cmdletContext.CloudwatchMetric_MetricName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric.MetricName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricNamespace = null;
            if (cmdletContext.CloudwatchMetric_MetricNamespace != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricNamespace = cmdletContext.CloudwatchMetric_MetricNamespace;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricNamespace != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric.MetricNamespace = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricNamespace;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricTimestamp = null;
            if (cmdletContext.CloudwatchMetric_MetricTimestamp != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricTimestamp = cmdletContext.CloudwatchMetric_MetricTimestamp;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricTimestamp != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric.MetricTimestamp = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricTimestamp;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricUnit = null;
            if (cmdletContext.CloudwatchMetric_MetricUnit != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricUnit = cmdletContext.CloudwatchMetric_MetricUnit;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricUnit != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric.MetricUnit = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricUnit;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricValue = null;
            if (cmdletContext.CloudwatchMetric_MetricValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricValue = cmdletContext.CloudwatchMetric_MetricValue;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric.MetricValue = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_MetricValue;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_RoleArn = null;
            if (cmdletContext.CloudwatchMetric_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_RoleArn = cmdletContext.CloudwatchMetric_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric_cloudwatchMetric_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetricIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.CloudwatchMetric = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_CloudwatchMetric;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.LocationAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location = null;
            
             // populate Location
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location = new Amazon.IoT.Model.LocationAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_DeviceId = null;
            if (cmdletContext.Location_DeviceId != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_DeviceId = cmdletContext.Location_DeviceId;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_DeviceId != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location.DeviceId = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_DeviceId;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Latitude = null;
            if (cmdletContext.Location_Latitude != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Latitude = cmdletContext.Location_Latitude;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Latitude != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location.Latitude = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Latitude;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Longitude = null;
            if (cmdletContext.Location_Longitude != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Longitude = cmdletContext.Location_Longitude;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Longitude != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location.Longitude = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_Longitude;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_RoleArn = null;
            if (cmdletContext.Location_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_RoleArn = cmdletContext.Location_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_TrackerName = null;
            if (cmdletContext.Location_TrackerName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_TrackerName = cmdletContext.Location_TrackerName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_TrackerName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location.TrackerName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_location_TrackerName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = false;
            }
            Amazon.IoT.Model.LocationTimestamp requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp = null;
            
             // populate Timestamp
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_TimestampIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp = new Amazon.IoT.Model.LocationTimestamp();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Unit = null;
            if (cmdletContext.TopicRulePayload_ErrorAction_Location_Timestamp_Unit != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Unit = cmdletContext.TopicRulePayload_ErrorAction_Location_Timestamp_Unit;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Unit != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp.Unit = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Unit;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_TimestampIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Value = null;
            if (cmdletContext.TopicRulePayload_ErrorAction_Location_Timestamp_Value != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Value = cmdletContext.TopicRulePayload_ErrorAction_Location_Timestamp_Value;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Value != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp.Value = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp_topicRulePayload_ErrorAction_Location_Timestamp_Value;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_TimestampIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_TimestampIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location.Timestamp = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location_topicRulePayload_ErrorAction_Location_Timestamp;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_LocationIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.Location = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_Location;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
            Amazon.IoT.Model.DynamoDBAction requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB = null;
            
             // populate DynamoDB
            var requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = true;
            requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB = new Amazon.IoT.Model.DynamoDBAction();
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyField = null;
            if (cmdletContext.DynamoDB_HashKeyField != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyField = cmdletContext.DynamoDB_HashKeyField;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyField != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.HashKeyField = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyField;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            Amazon.IoT.DynamoKeyType requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyType = null;
            if (cmdletContext.DynamoDB_HashKeyType != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyType = cmdletContext.DynamoDB_HashKeyType;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyType != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.HashKeyType = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyType;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyValue = null;
            if (cmdletContext.DynamoDB_HashKeyValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyValue = cmdletContext.DynamoDB_HashKeyValue;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.HashKeyValue = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_HashKeyValue;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_Operation = null;
            if (cmdletContext.DynamoDB_Operation != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_Operation = cmdletContext.DynamoDB_Operation;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_Operation != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.Operation = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_Operation;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_PayloadField = null;
            if (cmdletContext.DynamoDB_PayloadField != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_PayloadField = cmdletContext.DynamoDB_PayloadField;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_PayloadField != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.PayloadField = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_PayloadField;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyField = null;
            if (cmdletContext.DynamoDB_RangeKeyField != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyField = cmdletContext.DynamoDB_RangeKeyField;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyField != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.RangeKeyField = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyField;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            Amazon.IoT.DynamoKeyType requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyType = null;
            if (cmdletContext.DynamoDB_RangeKeyType != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyType = cmdletContext.DynamoDB_RangeKeyType;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyType != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.RangeKeyType = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyType;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyValue = null;
            if (cmdletContext.DynamoDB_RangeKeyValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyValue = cmdletContext.DynamoDB_RangeKeyValue;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyValue != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.RangeKeyValue = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RangeKeyValue;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RoleArn = null;
            if (cmdletContext.DynamoDB_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RoleArn = cmdletContext.DynamoDB_RoleArn;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RoleArn != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.RoleArn = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_RoleArn;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_TableName = null;
            if (cmdletContext.DynamoDB_TableName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_TableName = cmdletContext.DynamoDB_TableName;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_TableName != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB.TableName = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB_dynamoDB_TableName;
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDBIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB != null)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction.DynamoDB = requestTopicRulePayload_topicRulePayload_ErrorAction_topicRulePayload_ErrorAction_DynamoDB;
                requestTopicRulePayload_topicRulePayload_ErrorActionIsNull = false;
            }
             // determine if requestTopicRulePayload_topicRulePayload_ErrorAction should be set to null
            if (requestTopicRulePayload_topicRulePayload_ErrorActionIsNull)
            {
                requestTopicRulePayload_topicRulePayload_ErrorAction = null;
            }
            if (requestTopicRulePayload_topicRulePayload_ErrorAction != null)
            {
                request.TopicRulePayload.ErrorAction = requestTopicRulePayload_topicRulePayload_ErrorAction;
                requestTopicRulePayloadIsNull = false;
            }
             // determine if request.TopicRulePayload should be set to null
            if (requestTopicRulePayloadIsNull)
            {
                request.TopicRulePayload = null;
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
        
        private Amazon.IoT.Model.ReplaceTopicRuleResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ReplaceTopicRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ReplaceTopicRule");
            try
            {
                #if DESKTOP
                return client.ReplaceTopicRule(request);
                #elif CORECLR
                return client.ReplaceTopicRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String RuleName { get; set; }
            public List<Amazon.IoT.Model.Action> TopicRulePayload_Action { get; set; }
            public System.String TopicRulePayload_AwsIotSqlVersion { get; set; }
            public System.String TopicRulePayload_Description { get; set; }
            public System.String CloudwatchAlarm_AlarmName { get; set; }
            public System.String CloudwatchAlarm_RoleArn { get; set; }
            public System.String CloudwatchAlarm_StateReason { get; set; }
            public System.String CloudwatchAlarm_StateValue { get; set; }
            public System.String CloudwatchLogs_LogGroupName { get; set; }
            public System.String CloudwatchLogs_RoleArn { get; set; }
            public System.String CloudwatchMetric_MetricName { get; set; }
            public System.String CloudwatchMetric_MetricNamespace { get; set; }
            public System.String CloudwatchMetric_MetricTimestamp { get; set; }
            public System.String CloudwatchMetric_MetricUnit { get; set; }
            public System.String CloudwatchMetric_MetricValue { get; set; }
            public System.String CloudwatchMetric_RoleArn { get; set; }
            public System.String DynamoDB_HashKeyField { get; set; }
            public Amazon.IoT.DynamoKeyType DynamoDB_HashKeyType { get; set; }
            public System.String DynamoDB_HashKeyValue { get; set; }
            public System.String DynamoDB_Operation { get; set; }
            public System.String DynamoDB_PayloadField { get; set; }
            public System.String DynamoDB_RangeKeyField { get; set; }
            public Amazon.IoT.DynamoKeyType DynamoDB_RangeKeyType { get; set; }
            public System.String DynamoDB_RangeKeyValue { get; set; }
            public System.String DynamoDB_RoleArn { get; set; }
            public System.String DynamoDB_TableName { get; set; }
            public System.String PutItem_TableName { get; set; }
            public System.String DynamoDBv2_RoleArn { get; set; }
            public System.String Elasticsearch_Endpoint { get; set; }
            public System.String Elasticsearch_Id { get; set; }
            public System.String Elasticsearch_Index { get; set; }
            public System.String Elasticsearch_RoleArn { get; set; }
            public System.String Elasticsearch_Type { get; set; }
            public System.Boolean? Firehose_BatchMode { get; set; }
            public System.String Firehose_DeliveryStreamName { get; set; }
            public System.String Firehose_RoleArn { get; set; }
            public System.String Firehose_Separator { get; set; }
            public System.String Sigv4_RoleArn { get; set; }
            public System.String Sigv4_ServiceName { get; set; }
            public System.String Sigv4_SigningRegion { get; set; }
            public System.String Http_ConfirmationUrl { get; set; }
            public List<Amazon.IoT.Model.HttpActionHeader> Http_Header { get; set; }
            public System.String Http_Url { get; set; }
            public System.Boolean? IotAnalytics_BatchMode { get; set; }
            public System.String IotAnalytics_ChannelArn { get; set; }
            public System.String IotAnalytics_ChannelName { get; set; }
            public System.String IotAnalytics_RoleArn { get; set; }
            public System.Boolean? IotEvents_BatchMode { get; set; }
            public System.String IotEvents_InputName { get; set; }
            public System.String IotEvents_MessageId { get; set; }
            public System.String IotEvents_RoleArn { get; set; }
            public List<Amazon.IoT.Model.PutAssetPropertyValueEntry> IotSiteWise_PutAssetPropertyValueEntry { get; set; }
            public System.String IotSiteWise_RoleArn { get; set; }
            public Dictionary<System.String, System.String> Kafka_ClientProperty { get; set; }
            public System.String Kafka_DestinationArn { get; set; }
            public System.String Kafka_Key { get; set; }
            public System.String Kafka_Partition { get; set; }
            public System.String Kafka_Topic { get; set; }
            public System.String Kinesis_PartitionKey { get; set; }
            public System.String Kinesis_RoleArn { get; set; }
            public System.String Kinesis_StreamName { get; set; }
            public System.String Lambda_FunctionArn { get; set; }
            public System.String Location_DeviceId { get; set; }
            public System.String Location_Latitude { get; set; }
            public System.String Location_Longitude { get; set; }
            public System.String Location_RoleArn { get; set; }
            public System.String TopicRulePayload_ErrorAction_Location_Timestamp_Unit { get; set; }
            public System.String TopicRulePayload_ErrorAction_Location_Timestamp_Value { get; set; }
            public System.String Location_TrackerName { get; set; }
            public System.String OpenSearch_Endpoint { get; set; }
            public System.String OpenSearch_Id { get; set; }
            public System.String OpenSearch_Index { get; set; }
            public System.String OpenSearch_RoleArn { get; set; }
            public System.String OpenSearch_Type { get; set; }
            public System.String Headers_ContentType { get; set; }
            public System.String Headers_CorrelationData { get; set; }
            public System.String Headers_MessageExpiry { get; set; }
            public System.String Headers_PayloadFormatIndicator { get; set; }
            public System.String Headers_ResponseTopic { get; set; }
            public List<Amazon.IoT.Model.UserProperty> Headers_UserProperty { get; set; }
            public System.Int32? Republish_Qo { get; set; }
            public System.String Republish_RoleArn { get; set; }
            public System.String Republish_Topic { get; set; }
            public System.String S3_BucketName { get; set; }
            public Amazon.IoT.CannedAccessControlList S3_CannedAcl { get; set; }
            public System.String S3_Key { get; set; }
            public System.String S3_RoleArn { get; set; }
            public System.String Salesforce_Token { get; set; }
            public System.String Salesforce_Url { get; set; }
            public Amazon.IoT.MessageFormat Sns_MessageFormat { get; set; }
            public System.String Sns_RoleArn { get; set; }
            public System.String Sns_TargetArn { get; set; }
            public System.String Sqs_QueueUrl { get; set; }
            public System.String Sqs_RoleArn { get; set; }
            public System.Boolean? Sqs_UseBase64 { get; set; }
            public System.String StepFunctions_ExecutionNamePrefix { get; set; }
            public System.String StepFunctions_RoleArn { get; set; }
            public System.String StepFunctions_StateMachineName { get; set; }
            public System.String Timestream_DatabaseName { get; set; }
            public List<Amazon.IoT.Model.TimestreamDimension> Timestream_Dimension { get; set; }
            public System.String Timestream_RoleArn { get; set; }
            public System.String Timestream_TableName { get; set; }
            public System.String Timestamp_Unit { get; set; }
            public System.String Timestamp_Value { get; set; }
            public System.Boolean? TopicRulePayload_RuleDisabled { get; set; }
            public System.String TopicRulePayload_Sql { get; set; }
            public System.Func<Amazon.IoT.Model.ReplaceTopicRuleResponse, SetIOTTopicRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
