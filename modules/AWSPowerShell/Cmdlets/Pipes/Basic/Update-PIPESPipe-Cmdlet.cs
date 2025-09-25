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
using Amazon.Pipes;
using Amazon.Pipes.Model;

namespace Amazon.PowerShell.Cmdlets.PIPES
{
    /// <summary>
    /// Update an existing pipe. When you call <c>UpdatePipe</c>, EventBridge only the updates
    /// fields you have specified in the request; the rest remain unchanged. The exception
    /// to this is if you modify any Amazon Web Services-service specific fields in the <c>SourceParameters</c>,
    /// <c>EnrichmentParameters</c>, or <c>TargetParameters</c> objects. For example, <c>DynamoDBStreamParameters</c>
    /// or <c>EventBridgeEventBusParameters</c>. EventBridge updates the fields in these objects
    /// atomically as one and overrides existing values. This is by design, and means that
    /// if you don't specify an optional field in one of these <c>Parameters</c> objects,
    /// EventBridge sets that field to its system-default value during the update.
    /// 
    ///  
    /// <para>
    /// For more information about pipes, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-pipes.html">
    /// Amazon EventBridge Pipes</a> in the Amazon EventBridge User Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PIPESPipe", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pipes.Model.UpdatePipeResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge Pipes UpdatePipe API operation.", Operation = new[] {"UpdatePipe"}, SelectReturnType = typeof(Amazon.Pipes.Model.UpdatePipeResponse))]
    [AWSCmdletOutput("Amazon.Pipes.Model.UpdatePipeResponse",
        "This cmdlet returns an Amazon.Pipes.Model.UpdatePipeResponse object containing multiple properties."
    )]
    public partial class UpdatePIPESPipeCmdlet : AmazonPipesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the specified target for the dead-letter queue. </para><para>For Amazon Kinesis stream and Amazon DynamoDB stream sources, specify either an Amazon
        /// SNS topic or Amazon SQS queue ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_DynamoDBStream_DeadLetterConfig_Arn")]
        public System.String SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn { get; set; }
        #endregion
        
        #region Parameter SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the specified target for the dead-letter queue. </para><para>For Amazon Kinesis stream and Amazon DynamoDB stream sources, specify either an Amazon
        /// SNS topic or Amazon SQS queue ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_KinesisStream_DeadLetterConfig_Arn")]
        public System.String SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Specifies whether the task's elastic network interface receives a public IP address.
        /// You can specify <c>ENABLED</c> only when <c>LaunchType</c> in <c>EcsParameters</c>
        /// is set to <c>FARGATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.Pipes.AssignPublicIp")]
        public Amazon.Pipes.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter RetryStrategy_Attempt
        /// <summary>
        /// <para>
        /// <para>The number of times to move a job to the <c>RUNNABLE</c> status. If the value of <c>attempts</c>
        /// is greater than one, the job is retried on failure the same number of attempts as
        /// the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_RetryStrategy_Attempts")]
        public System.Int32? RetryStrategy_Attempt { get; set; }
        #endregion
        
        #region Parameter SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_ActiveMQBrokerParameters_Credentials_BasicAuth")]
        public System.String SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth { get; set; }
        #endregion
        
        #region Parameter SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_RabbitMQBrokerParameters_Credentials_BasicAuth")]
        public System.String SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth { get; set; }
        #endregion
        
        #region Parameter SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SelfManagedKafkaParameters_Credentials_BasicAuth")]
        public System.String SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth { get; set; }
        #endregion
        
        #region Parameter ActiveMQBrokerParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_ActiveMQBrokerParameters_BatchSize")]
        public System.Int32? ActiveMQBrokerParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter DynamoDBStreamParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_DynamoDBStreamParameters_BatchSize")]
        public System.Int32? DynamoDBStreamParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_KinesisStreamParameters_BatchSize")]
        public System.Int32? KinesisStreamParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter ManagedStreamingKafkaParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_ManagedStreamingKafkaParameters_BatchSize")]
        public System.Int32? ManagedStreamingKafkaParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter RabbitMQBrokerParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_RabbitMQBrokerParameters_BatchSize")]
        public System.Int32? RabbitMQBrokerParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter SelfManagedKafkaParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_BatchSize")]
        public System.Int32? SelfManagedKafkaParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter SqsQueueParameters_BatchSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of records to include in each batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SqsQueueParameters_BatchSize")]
        public System.Int32? SqsQueueParameters_BatchSize { get; set; }
        #endregion
        
        #region Parameter S3LogDestination_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket to which EventBridge delivers the log records
        /// for the pipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3LogDestination_BucketName")]
        public System.String S3LogDestination_BucketName { get; set; }
        #endregion
        
        #region Parameter S3LogDestination_BucketOwner
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Web Services account that owns the Amazon S3 bucket to which
        /// EventBridge delivers the log records for the pipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3LogDestination_BucketOwner")]
        public System.String S3LogDestination_BucketOwner { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_CapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to use for the task.</para><para>If a <c>capacityProviderStrategy</c> is specified, the <c>launchType</c> parameter
        /// must be omitted. If no <c>capacityProviderStrategy</c> or launchType is specified,
        /// the <c>defaultCapacityProviderStrategy</c> for the cluster is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_CapacityProviderStrategy")]
        public Amazon.Pipes.Model.CapacityProviderStrategyItem[] EcsTaskParameters_CapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_ManagedStreamingKafka_Credentials_ClientCertificateTlsAuth")]
        public System.String SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth { get; set; }
        #endregion
        
        #region Parameter SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SelfStreamingKafka_Credentials_ClientCertificateTlsAuth")]
        public System.String SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Command
        /// <summary>
        /// <para>
        /// <para>The command to send to the container that overrides the default command from the Docker
        /// image or the task definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_ContainerOverrides_Command")]
        public System.String[] ContainerOverrides_Command { get; set; }
        #endregion
        
        #region Parameter Overrides_ContainerOverride
        /// <summary>
        /// <para>
        /// <para>One or more container overrides that are sent to a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_ContainerOverrides")]
        public Amazon.Pipes.Model.EcsContainerOverride[] Overrides_ContainerOverride { get; set; }
        #endregion
        
        #region Parameter Overrides_Cpu
        /// <summary>
        /// <para>
        /// <para>The cpu override for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_Cpu")]
        public System.String Overrides_Cpu { get; set; }
        #endregion
        
        #region Parameter RedshiftDataParameters_Database
        /// <summary>
        /// <para>
        /// <para>The name of the database. Required when authenticating using temporary credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_RedshiftDataParameters_Database")]
        public System.String RedshiftDataParameters_Database { get; set; }
        #endregion
        
        #region Parameter RedshiftDataParameters_DbUser
        /// <summary>
        /// <para>
        /// <para>The database user name. Required when authenticating using temporary credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_RedshiftDataParameters_DbUser")]
        public System.String RedshiftDataParameters_DbUser { get; set; }
        #endregion
        
        #region Parameter FirehoseLogDestination_DeliveryStreamArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the Firehose delivery stream to which
        /// EventBridge delivers the pipe log records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_FirehoseLogDestination_DeliveryStreamArn")]
        public System.String FirehoseLogDestination_DeliveryStreamArn { get; set; }
        #endregion
        
        #region Parameter BatchJobParameters_DependsOn
        /// <summary>
        /// <para>
        /// <para>A list of dependencies for the job. A job can depend upon a maximum of 20 jobs. You
        /// can specify a <c>SEQUENTIAL</c> type dependency without specifying a job ID for array
        /// jobs so that each child array job completes sequentially, starting at index 0. You
        /// can also specify an <c>N_TO_N</c> type dependency with a job ID for array jobs. In
        /// that case, each index child of this job must wait for the corresponding index child
        /// of each dependency to complete before it can begin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_DependsOn")]
        public Amazon.Pipes.Model.BatchJobDependency[] BatchJobParameters_DependsOn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the pipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DesiredState
        /// <summary>
        /// <para>
        /// <para>The state the pipe should be in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Pipes.RequestedPipeState")]
        public Amazon.Pipes.RequestedPipeState DesiredState { get; set; }
        #endregion
        
        #region Parameter EventBridgeEventBusParameters_DetailType
        /// <summary>
        /// <para>
        /// <para>A free-form string, with a maximum of 128 characters, used to decide what fields to
        /// expect in the event detail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EventBridgeEventBusParameters_DetailType")]
        public System.String EventBridgeEventBusParameters_DetailType { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_DimensionMapping
        /// <summary>
        /// <para>
        /// <para>Map source data to dimensions in the target Timestream for LiveAnalytics table.</para><para>For more information, see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/concepts.html">Amazon
        /// Timestream for LiveAnalytics concepts</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_DimensionMappings")]
        public Amazon.Pipes.Model.DimensionMapping[] TimestreamParameters_DimensionMapping { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Amazon ECS managed tags for the task. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the Amazon Elastic Container Service Developer Guide.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_EnableECSManagedTags")]
        public System.Boolean? EcsTaskParameters_EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_EnableExecuteCommand
        /// <summary>
        /// <para>
        /// <para>Whether or not to enable the execute command functionality for the containers in this
        /// task. If true, this enables execute command functionality on all containers in the
        /// task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_EnableExecuteCommand")]
        public System.Boolean? EcsTaskParameters_EnableExecuteCommand { get; set; }
        #endregion
        
        #region Parameter EventBridgeEventBusParameters_EndpointId
        /// <summary>
        /// <para>
        /// <para>The URL subdomain of the endpoint. For example, if the URL for Endpoint is https://abcde.veo.endpoints.event.amazonaws.com,
        /// then the EndpointId is <c>abcde.veo</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EventBridgeEventBusParameters_EndpointId")]
        public System.String EventBridgeEventBusParameters_EndpointId { get; set; }
        #endregion
        
        #region Parameter Enrichment
        /// <summary>
        /// <para>
        /// <para>The ARN of the enrichment resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Enrichment { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_Environment
        /// <summary>
        /// <para>
        /// <para>The environment variables to send to the container. You can add new environment variables,
        /// which are added to the container at launch, or you can override the existing environment
        /// variables from the Docker image or the task definition.</para><note><para>Environment variables cannot start with "<c>Batch</c>". This naming convention is
        /// reserved for variables that Batch sets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_ContainerOverrides_Environment")]
        public Amazon.Pipes.Model.BatchEnvironmentVariable[] ContainerOverrides_Environment { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_EpochTimeUnit
        /// <summary>
        /// <para>
        /// <para>The granularity of the time units used. Default is <c>MILLISECONDS</c>.</para><para>Required if <c>TimeFieldType</c> is specified as <c>EPOCH</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_EpochTimeUnit")]
        [AWSConstantClassSource("Amazon.Pipes.EpochTimeUnit")]
        public Amazon.Pipes.EpochTimeUnit TimestreamParameters_EpochTimeUnit { get; set; }
        #endregion
        
        #region Parameter Overrides_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution IAM role override for the task.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_execution_IAM_role.html">Amazon
        /// ECS task execution IAM role</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_ExecutionRoleArn")]
        public System.String Overrides_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Filter
        /// <summary>
        /// <para>
        /// <para>The event patterns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_FilterCriteria_Filters")]
        public Amazon.Pipes.Model.Filter[] FilterCriteria_Filter { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_Group
        /// <summary>
        /// <para>
        /// <para>Specifies an Amazon ECS task group for the task. The maximum length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Group")]
        public System.String EcsTaskParameters_Group { get; set; }
        #endregion
        
        #region Parameter EnrichmentParameters_HttpParameters_HeaderParameters
        /// <summary>
        /// <para>
        /// <para>The headers that need to be sent as part of request invoking the API Gateway REST
        /// API or EventBridge ApiDestination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Enrichment_HttpParameters_HeaderParameters")]
        public System.Collections.Hashtable EnrichmentParameters_HttpParameters_HeaderParameters { get; set; }
        #endregion
        
        #region Parameter TargetParameters_HttpParameters_HeaderParameters
        /// <summary>
        /// <para>
        /// <para>The headers that need to be sent as part of request invoking the API Gateway REST
        /// API or EventBridge ApiDestination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_HttpParameters_HeaderParameters")]
        public System.Collections.Hashtable TargetParameters_HttpParameters_HeaderParameters { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_IncludeExecutionData
        /// <summary>
        /// <para>
        /// <para>Specify <c>ALL</c> to include the execution data (specifically, the <c>payload</c>,
        /// <c>awsRequest</c>, and <c>awsResponse</c> fields) in the log messages for this pipe.</para><para>This applies to all log destinations for the pipe.</para><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-pipes-logs.html#eb-pipes-logs-execution-data">Including
        /// execution data in logs</a> in the <i>Amazon EventBridge User Guide</i>.</para><para>By default, execution data is not included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] LogConfiguration_IncludeExecutionData { get; set; }
        #endregion
        
        #region Parameter Overrides_InferenceAcceleratorOverride
        /// <summary>
        /// <para>
        /// <para>The Elastic Inference accelerator override for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_InferenceAcceleratorOverrides")]
        public Amazon.Pipes.Model.EcsInferenceAcceleratorOverride[] Overrides_InferenceAcceleratorOverride { get; set; }
        #endregion
        
        #region Parameter EnrichmentParameters_InputTemplate
        /// <summary>
        /// <para>
        /// <para>Valid JSON text passed to the enrichment. In this case, nothing from the event itself
        /// is passed to the enrichment. For more information, see <a href="http://www.rfc-editor.org/rfc/rfc7159.txt">The
        /// JavaScript Object Notation (JSON) Data Interchange Format</a>.</para><para>To remove an input template, specify an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnrichmentParameters_InputTemplate { get; set; }
        #endregion
        
        #region Parameter TargetParameters_InputTemplate
        /// <summary>
        /// <para>
        /// <para>Valid JSON text passed to the target. In this case, nothing from the event itself
        /// is passed to the target. For more information, see <a href="http://www.rfc-editor.org/rfc/rfc7159.txt">The
        /// JavaScript Object Notation (JSON) Data Interchange Format</a>.</para><para>To remove an input template, specify an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetParameters_InputTemplate { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use for a multi-node parallel job.</para><note><para>This parameter isn't applicable to single-node container jobs or jobs that run on
        /// Fargate resources, and shouldn't be provided.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_ContainerOverrides_InstanceType")]
        public System.String ContainerOverrides_InstanceType { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionParameters_InvocationType
        /// <summary>
        /// <para>
        /// <para>Specify whether to invoke the function synchronously or asynchronously.</para><ul><li><para><c>REQUEST_RESPONSE</c> (default) - Invoke synchronously. This corresponds to the
        /// <c>RequestResponse</c> option in the <c>InvocationType</c> parameter for the Lambda
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/API_Invoke.html#API_Invoke_RequestSyntax">Invoke</a>
        /// API.</para></li><li><para><c>FIRE_AND_FORGET</c> - Invoke asynchronously. This corresponds to the <c>Event</c>
        /// option in the <c>InvocationType</c> parameter for the Lambda <a href="https://docs.aws.amazon.com/lambda/latest/dg/API_Invoke.html#API_Invoke_RequestSyntax">Invoke</a>
        /// API.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-pipes.html#pipes-invocation">Invocation
        /// types</a> in the <i>Amazon EventBridge User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_LambdaFunctionParameters_InvocationType")]
        [AWSConstantClassSource("Amazon.Pipes.PipeTargetInvocationType")]
        public Amazon.Pipes.PipeTargetInvocationType LambdaFunctionParameters_InvocationType { get; set; }
        #endregion
        
        #region Parameter StepFunctionStateMachineParameters_InvocationType
        /// <summary>
        /// <para>
        /// <para>Specify whether to invoke the Step Functions state machine synchronously or asynchronously.</para><ul><li><para><c>REQUEST_RESPONSE</c> (default) - Invoke synchronously. For more information, see
        /// <a href="https://docs.aws.amazon.com/step-functions/latest/apireference/API_StartSyncExecution.html">StartSyncExecution</a>
        /// in the <i>Step Functions API Reference</i>.</para><note><para><c>REQUEST_RESPONSE</c> is not supported for <c>STANDARD</c> state machine workflows.</para></note></li><li><para><c>FIRE_AND_FORGET</c> - Invoke asynchronously. For more information, see <a href="https://docs.aws.amazon.com/step-functions/latest/apireference/API_StartExecution.html">StartExecution</a>
        /// in the <i>Step Functions API Reference</i>.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-pipes.html#pipes-invocation">Invocation
        /// types</a> in the <i>Amazon EventBridge User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_StepFunctionStateMachineParameters_InvocationType")]
        [AWSConstantClassSource("Amazon.Pipes.PipeTargetInvocationType")]
        public Amazon.Pipes.PipeTargetInvocationType StepFunctionStateMachineParameters_InvocationType { get; set; }
        #endregion
        
        #region Parameter BatchJobParameters_JobDefinition
        /// <summary>
        /// <para>
        /// <para>The job definition used by this job. This value can be one of <c>name</c>, <c>name:revision</c>,
        /// or the Amazon Resource Name (ARN) for the job definition. If name is specified without
        /// a revision then the latest active revision is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_JobDefinition")]
        public System.String BatchJobParameters_JobDefinition { get; set; }
        #endregion
        
        #region Parameter BatchJobParameters_JobName
        /// <summary>
        /// <para>
        /// <para>The name of the job. It can be up to 128 letters long. The first character must be
        /// alphanumeric, can contain uppercase and lowercase letters, numbers, hyphens (-), and
        /// underscores (_).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_JobName")]
        public System.String BatchJobParameters_JobName { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS customer managed key for EventBridge to use, if you choose
        /// to use a customer managed key to encrypt pipe data. The identifier can be the key
        /// Amazon Resource Name (ARN), KeyId, key alias, or key alias ARN.</para><para>To update a pipe that is using the default Amazon Web Services owned key to use a
        /// customer managed key instead, or update a pipe that is using a customer managed key
        /// to use a different customer managed key, specify a customer managed key identifier.</para><para>To update a pipe that is using a customer managed key to use the default Amazon Web
        /// Services owned key, specify an empty string.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/getting-started.html">Managing
        /// keys</a> in the <i>Key Management Service Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_LaunchType
        /// <summary>
        /// <para>
        /// <para>Specifies the launch type on which your task is running. The launch type that you
        /// specify here must match one of the launch type (compatibilities) of the target task.
        /// The <c>FARGATE</c> value is supported only in the Regions where Fargate with Amazon
        /// ECS is supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/AWS-Fargate.html">Fargate
        /// on Amazon ECS</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_LaunchType")]
        [AWSConstantClassSource("Amazon.Pipes.LaunchType")]
        public Amazon.Pipes.LaunchType EcsTaskParameters_LaunchType { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_Level
        /// <summary>
        /// <para>
        /// <para>The level of logging detail to include. This applies to all log destinations for the
        /// pipe.</para><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-pipes-logs.html#eb-pipes-logs-level">Specifying
        /// EventBridge Pipes log level</a> in the <i>Amazon EventBridge User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Pipes.LogLevel")]
        public Amazon.Pipes.LogLevel LogConfiguration_Level { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogsLogDestination_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Resource Name (ARN) for the CloudWatch log group to which
        /// EventBridge sends the log records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_CloudwatchLogsLogDestination_LogGroupArn")]
        public System.String CloudwatchLogsLogDestination_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsParameters_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the log stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_CloudWatchLogsParameters_LogStreamName")]
        public System.String CloudWatchLogsParameters_LogStreamName { get; set; }
        #endregion
        
        #region Parameter ActiveMQBrokerParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_ActiveMQBrokerParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? ActiveMQBrokerParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter DynamoDBStreamParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_DynamoDBStreamParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? DynamoDBStreamParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_KinesisStreamParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? KinesisStreamParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_ManagedStreamingKafkaParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter RabbitMQBrokerParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_RabbitMQBrokerParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? RabbitMQBrokerParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter SelfManagedKafkaParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? SelfManagedKafkaParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter SqsQueueParameters_MaximumBatchingWindowInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of a time to wait for events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SqsQueueParameters_MaximumBatchingWindowInSeconds")]
        public System.Int32? SqsQueueParameters_MaximumBatchingWindowInSecond { get; set; }
        #endregion
        
        #region Parameter DynamoDBStreamParameters_MaximumRecordAgeInSecond
        /// <summary>
        /// <para>
        /// <para>Discard records older than the specified age. The default value is -1, which sets
        /// the maximum age to infinite. When the value is set to infinite, EventBridge never
        /// discards old records. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_DynamoDBStreamParameters_MaximumRecordAgeInSeconds")]
        public System.Int32? DynamoDBStreamParameters_MaximumRecordAgeInSecond { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_MaximumRecordAgeInSecond
        /// <summary>
        /// <para>
        /// <para>Discard records older than the specified age. The default value is -1, which sets
        /// the maximum age to infinite. When the value is set to infinite, EventBridge never
        /// discards old records. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_KinesisStreamParameters_MaximumRecordAgeInSeconds")]
        public System.Int32? KinesisStreamParameters_MaximumRecordAgeInSecond { get; set; }
        #endregion
        
        #region Parameter DynamoDBStreamParameters_MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>Discard records after the specified number of retries. The default value is -1, which
        /// sets the maximum number of retries to infinite. When MaximumRetryAttempts is infinite,
        /// EventBridge retries failed records until the record expires in the event source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_DynamoDBStreamParameters_MaximumRetryAttempts")]
        public System.Int32? DynamoDBStreamParameters_MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>Discard records after the specified number of retries. The default value is -1, which
        /// sets the maximum number of retries to infinite. When MaximumRetryAttempts is infinite,
        /// EventBridge retries failed records until the record expires in the event source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_KinesisStreamParameters_MaximumRetryAttempts")]
        public System.Int32? KinesisStreamParameters_MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter Overrides_Memory
        /// <summary>
        /// <para>
        /// <para>The memory override for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_Memory")]
        public System.String Overrides_Memory { get; set; }
        #endregion
        
        #region Parameter SqsQueueParameters_MessageDeduplicationId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The token used for deduplication of sent messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_SqsQueueParameters_MessageDeduplicationId")]
        public System.String SqsQueueParameters_MessageDeduplicationId { get; set; }
        #endregion
        
        #region Parameter SqsQueueParameters_MessageGroupId
        /// <summary>
        /// <para>
        /// <para>The FIFO message group ID to use as the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_SqsQueueParameters_MessageGroupId")]
        public System.String SqsQueueParameters_MessageGroupId { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_MultiMeasureMapping
        /// <summary>
        /// <para>
        /// <para>Maps multiple measures from the source event to the same record in the specified Timestream
        /// for LiveAnalytics table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_MultiMeasureMappings")]
        public Amazon.Pipes.Model.MultiMeasureMapping[] TimestreamParameters_MultiMeasureMapping { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the pipe.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DynamoDBStreamParameters_OnPartialBatchItemFailure
        /// <summary>
        /// <para>
        /// <para>Define how to handle item process failures. <c>AUTOMATIC_BISECT</c> halves each batch
        /// and retry each half until all the records are processed or there is one failed message
        /// left in the batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_DynamoDBStreamParameters_OnPartialBatchItemFailure")]
        [AWSConstantClassSource("Amazon.Pipes.OnPartialBatchItemFailureStreams")]
        public Amazon.Pipes.OnPartialBatchItemFailureStreams DynamoDBStreamParameters_OnPartialBatchItemFailure { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_OnPartialBatchItemFailure
        /// <summary>
        /// <para>
        /// <para>Define how to handle item process failures. <c>AUTOMATIC_BISECT</c> halves each batch
        /// and retry each half until all the records are processed or there is one failed message
        /// left in the batch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_KinesisStreamParameters_OnPartialBatchItemFailure")]
        [AWSConstantClassSource("Amazon.Pipes.OnPartialBatchItemFailureStreams")]
        public Amazon.Pipes.OnPartialBatchItemFailureStreams KinesisStreamParameters_OnPartialBatchItemFailure { get; set; }
        #endregion
        
        #region Parameter S3LogDestination_OutputFormat
        /// <summary>
        /// <para>
        /// <para>How EventBridge should format the log records.</para><para>EventBridge currently only supports <c>json</c> formatting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3LogDestination_OutputFormat")]
        [AWSConstantClassSource("Amazon.Pipes.S3OutputFormat")]
        public Amazon.Pipes.S3OutputFormat S3LogDestination_OutputFormat { get; set; }
        #endregion
        
        #region Parameter DynamoDBStreamParameters_ParallelizationFactor
        /// <summary>
        /// <para>
        /// <para>The number of batches to process concurrently from each shard. The default value is
        /// 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_DynamoDBStreamParameters_ParallelizationFactor")]
        public System.Int32? DynamoDBStreamParameters_ParallelizationFactor { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_ParallelizationFactor
        /// <summary>
        /// <para>
        /// <para>The number of batches to process concurrently from each shard. The default value is
        /// 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_KinesisStreamParameters_ParallelizationFactor")]
        public System.Int32? KinesisStreamParameters_ParallelizationFactor { get; set; }
        #endregion
        
        #region Parameter BatchJobParameters_Parameter
        /// <summary>
        /// <para>
        /// <para>Additional parameters passed to the job that replace parameter substitution placeholders
        /// that are set in the job definition. Parameters are specified as a key and value pair
        /// mapping. Parameters included here override any corresponding parameter defaults from
        /// the job definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_Parameters")]
        public System.Collections.Hashtable BatchJobParameters_Parameter { get; set; }
        #endregion
        
        #region Parameter KinesisStreamParameters_PartitionKey
        /// <summary>
        /// <para>
        /// <para>Determines which shard in the stream the data record is assigned to. Partition keys
        /// are Unicode strings with a maximum length limit of 256 characters for each key. Amazon
        /// Kinesis Data Streams uses the partition key as input to a hash function that maps
        /// the partition key and associated data to a specific shard. Specifically, an MD5 hash
        /// function is used to map partition keys to 128-bit integer values and to map associated
        /// data records to shards. As a result of this hashing mechanism, all data records with
        /// the same partition key map to the same shard within the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_KinesisStreamParameters_PartitionKey")]
        public System.String KinesisStreamParameters_PartitionKey { get; set; }
        #endregion
        
        #region Parameter EnrichmentParameters_HttpParameters_PathParameterValues
        /// <summary>
        /// <para>
        /// <para>The path parameter values to be used to populate API Gateway REST API or EventBridge
        /// ApiDestination path wildcards ("*").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Enrichment_HttpParameters_PathParameterValues")]
        public System.String[] EnrichmentParameters_HttpParameters_PathParameterValues { get; set; }
        #endregion
        
        #region Parameter TargetParameters_HttpParameters_PathParameterValues
        /// <summary>
        /// <para>
        /// <para>The path parameter values to be used to populate API Gateway REST API or EventBridge
        /// ApiDestination path wildcards ("*").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_HttpParameters_PathParameterValues")]
        public System.String[] TargetParameters_HttpParameters_PathParameterValues { get; set; }
        #endregion
        
        #region Parameter SageMakerPipelineParameters_PipelineParameterList
        /// <summary>
        /// <para>
        /// <para>List of Parameter names and values for SageMaker Model Building Pipeline execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_SageMakerPipelineParameters_PipelineParameterList")]
        public Amazon.Pipes.Model.SageMakerPipelineParameter[] SageMakerPipelineParameters_PipelineParameterList { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for the task. You can specify up to
        /// 10 constraints per task (including constraints in the task definition and those specified
        /// at runtime).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_PlacementConstraints")]
        public Amazon.Pipes.Model.PlacementConstraint[] EcsTaskParameters_PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The placement strategy objects to use for the task. You can specify a maximum of five
        /// strategy rules per task. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_PlacementStrategy")]
        public Amazon.Pipes.Model.PlacementStrategy[] EcsTaskParameters_PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_PlatformVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the platform version for the task. Specify only the numeric portion of the
        /// platform version, such as <c>1.1.0</c>.</para><para>This structure is used only if <c>LaunchType</c> is <c>FARGATE</c>. For more information
        /// about valid platform versions, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">Fargate
        /// Platform Versions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_PlatformVersion")]
        public System.String EcsTaskParameters_PlatformVersion { get; set; }
        #endregion
        
        #region Parameter S3LogDestination_Prefix
        /// <summary>
        /// <para>
        /// <para>Specifies any prefix text with which to begin Amazon S3 log object names.</para><para>You can use prefixes to organize the data that you store in Amazon S3 buckets. A prefix
        /// is a string of characters at the beginning of the object key name. A prefix can be
        /// any length, subject to the maximum length of the object key name (1,024 bytes). For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-prefixes.html">Organizing
        /// objects using prefixes</a> in the <i>Amazon Simple Storage Service User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogConfiguration_S3LogDestination_Prefix")]
        public System.String S3LogDestination_Prefix { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the task definition to the task. If no
        /// value is specified, the tags are not propagated. Tags can only be propagated to the
        /// task during task creation. To add tags to a task after task creation, use the <c>TagResource</c>
        /// API action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_PropagateTags")]
        [AWSConstantClassSource("Amazon.Pipes.PropagateTags")]
        public Amazon.Pipes.PropagateTags EcsTaskParameters_PropagateTag { get; set; }
        #endregion
        
        #region Parameter EnrichmentParameters_HttpParameters_QueryStringParameters
        /// <summary>
        /// <para>
        /// <para>The query string keys/values that need to be sent as part of request invoking the
        /// API Gateway REST API or EventBridge ApiDestination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Enrichment_HttpParameters_QueryStringParameters")]
        public System.Collections.Hashtable EnrichmentParameters_HttpParameters_QueryStringParameters { get; set; }
        #endregion
        
        #region Parameter TargetParameters_HttpParameters_QueryStringParameters
        /// <summary>
        /// <para>
        /// <para>The query string keys/values that need to be sent as part of request invoking the
        /// API Gateway REST API or EventBridge ApiDestination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_HttpParameters_QueryStringParameters")]
        public System.Collections.Hashtable TargetParameters_HttpParameters_QueryStringParameters { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_ReferenceId
        /// <summary>
        /// <para>
        /// <para>The reference ID to use for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_ReferenceId")]
        public System.String EcsTaskParameters_ReferenceId { get; set; }
        #endregion
        
        #region Parameter ContainerOverrides_ResourceRequirement
        /// <summary>
        /// <para>
        /// <para>The type and amount of resources to assign to a container. This overrides the settings
        /// in the job definition. The supported resources include <c>GPU</c>, <c>MEMORY</c>,
        /// and <c>VCPU</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_ContainerOverrides_ResourceRequirements")]
        public Amazon.Pipes.Model.BatchResourceRequirement[] ContainerOverrides_ResourceRequirement { get; set; }
        #endregion
        
        #region Parameter EventBridgeEventBusParameters_Resource
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services resources, identified by Amazon Resource Name (ARN), which the
        /// event primarily concerns. Any number, including zero, may be present.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EventBridgeEventBusParameters_Resources")]
        public System.String[] EventBridgeEventBusParameters_Resource { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that allows the pipe to send data to the target.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Credentials_SaslScram256Auth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_Credentials_SaslScram256Auth")]
        public System.String Credentials_SaslScram256Auth { get; set; }
        #endregion
        
        #region Parameter SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth")]
        public System.String SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth { get; set; }
        #endregion
        
        #region Parameter Credentials_SaslScram512Auth
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_Credentials_SaslScram512Auth")]
        public System.String Credentials_SaslScram512Auth { get; set; }
        #endregion
        
        #region Parameter RedshiftDataParameters_SecretManagerArn
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the secret that enables access to the database. Required when authenticating
        /// using Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_RedshiftDataParameters_SecretManagerArn")]
        public System.String RedshiftDataParameters_SecretManagerArn { get; set; }
        #endregion
        
        #region Parameter Vpc_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>Specifies the security groups associated with the stream. These security groups must
        /// all be in the same VPC. You can specify as many as five security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_Vpc_SecurityGroup")]
        public System.String[] Vpc_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>Specifies the security groups associated with the task. These security groups must
        /// all be in the same VPC. You can specify as many as five security groups. If you do
        /// not specify a security group, the default security group for the VPC is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SelfManagedKafkaParameters_ServerRootCaCertificate
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret used for certification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_ServerRootCaCertificate")]
        public System.String SelfManagedKafkaParameters_ServerRootCaCertificate { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_SingleMeasureMapping
        /// <summary>
        /// <para>
        /// <para>Mappings of single source data fields to individual records in the specified Timestream
        /// for LiveAnalytics table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_SingleMeasureMappings")]
        public Amazon.Pipes.Model.SingleMeasureMapping[] TimestreamParameters_SingleMeasureMapping { get; set; }
        #endregion
        
        #region Parameter ArrayProperties_Size
        /// <summary>
        /// <para>
        /// <para>The size of the array, if this is an array batch job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_BatchJobParameters_ArrayProperties_Size")]
        public System.Int32? ArrayProperties_Size { get; set; }
        #endregion
        
        #region Parameter EphemeralStorage_SizeInGiB
        /// <summary>
        /// <para>
        /// <para>The total amount, in GiB, of ephemeral storage to set for the task. The minimum supported
        /// value is <c>21</c> GiB and the maximum supported value is <c>200</c> GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_EphemeralStorage_SizeInGiB")]
        public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
        #endregion
        
        #region Parameter EventBridgeEventBusParameters_Source
        /// <summary>
        /// <para>
        /// <para>The source of the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EventBridgeEventBusParameters_Source")]
        public System.String EventBridgeEventBusParameters_Source { get; set; }
        #endregion
        
        #region Parameter RedshiftDataParameters_Sql
        /// <summary>
        /// <para>
        /// <para>The SQL statement text to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_RedshiftDataParameters_Sqls")]
        public System.String[] RedshiftDataParameters_Sql { get; set; }
        #endregion
        
        #region Parameter RedshiftDataParameters_StatementName
        /// <summary>
        /// <para>
        /// <para>The name of the SQL statement. You can name the SQL statement when you create it to
        /// identify the query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_RedshiftDataParameters_StatementName")]
        public System.String RedshiftDataParameters_StatementName { get; set; }
        #endregion
        
        #region Parameter Vpc_Subnet
        /// <summary>
        /// <para>
        /// <para>Specifies the subnets associated with the stream. These subnets must all be in the
        /// same VPC. You can specify as many as 16 subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceParameters_SelfManagedKafkaParameters_Vpc_Subnets")]
        public System.String[] Vpc_Subnet { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>Specifies the subnets associated with the task. These subnets must all be in the same
        /// VPC. You can specify as many as 16 subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_Subnets")]
        public System.String[] AwsvpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define. To learn
        /// more, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_RunTask.html#ECS-RunTask-request-tags">RunTask</a>
        /// in the Amazon ECS API Reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Tags")]
        public Amazon.Pipes.Model.Tag[] EcsTaskParameters_Tag { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The ARN of the target resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_TaskCount
        /// <summary>
        /// <para>
        /// <para>The number of tasks to create based on <c>TaskDefinition</c>. The default is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_TaskCount")]
        public System.Int32? EcsTaskParameters_TaskCount { get; set; }
        #endregion
        
        #region Parameter EcsTaskParameters_TaskDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the task definition to use if the event target is an Amazon ECS task. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_TaskDefinitionArn")]
        public System.String EcsTaskParameters_TaskDefinitionArn { get; set; }
        #endregion
        
        #region Parameter Overrides_TaskRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that containers in this task can assume.
        /// All containers in this task are granted the permissions that are specified in this
        /// role. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
        /// Role for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EcsTaskParameters_Overrides_TaskRoleArn")]
        public System.String Overrides_TaskRoleArn { get; set; }
        #endregion
        
        #region Parameter EventBridgeEventBusParameters_Time
        /// <summary>
        /// <para>
        /// <para>The time stamp of the event, per <a href="https://www.rfc-editor.org/rfc/rfc3339.txt">RFC3339</a>.
        /// If no time stamp is provided, the time stamp of the <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_PutEvents.html">PutEvents</a>
        /// call is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_EventBridgeEventBusParameters_Time")]
        public System.String EventBridgeEventBusParameters_Time { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_TimeFieldType
        /// <summary>
        /// <para>
        /// <para>The type of time value used.</para><para>The default is <c>EPOCH</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_TimeFieldType")]
        [AWSConstantClassSource("Amazon.Pipes.TimeFieldType")]
        public Amazon.Pipes.TimeFieldType TimestreamParameters_TimeFieldType { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsParameters_Timestamp
        /// <summary>
        /// <para>
        /// <para>The time the event occurred, expressed as the number of milliseconds after Jan 1,
        /// 1970 00:00:00 UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_CloudWatchLogsParameters_Timestamp")]
        public System.String CloudWatchLogsParameters_Timestamp { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_TimestampFormat
        /// <summary>
        /// <para>
        /// <para>How to format the timestamps. For example, <c>yyyy-MM-dd'T'HH:mm:ss'Z'</c>.</para><para>Required if <c>TimeFieldType</c> is specified as <c>TIMESTAMP_FORMAT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_TimestampFormat")]
        public System.String TimestreamParameters_TimestampFormat { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_TimeValue
        /// <summary>
        /// <para>
        /// <para>Dynamic path to the source data field that represents the time value for your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_TimeValue")]
        public System.String TimestreamParameters_TimeValue { get; set; }
        #endregion
        
        #region Parameter TimestreamParameters_VersionValue
        /// <summary>
        /// <para>
        /// <para>64 bit version value or source data field that represents the version value for your
        /// data.</para><para>Write requests with a higher version number will update the existing measure values
        /// of the record and version. In cases where the measure value is the same, the version
        /// will still be updated. </para><para>Default value is 1. </para><para>Timestream for LiveAnalytics does not support updating partial measure values in a
        /// record.</para><para>Write requests for duplicate data with a higher version number will update the existing
        /// measure value and version. In cases where the measure value is the same, <c>Version</c>
        /// will still be updated. Default value is <c>1</c>.</para><note><para><c>Version</c> must be <c>1</c> or greater, or you will receive a <c>ValidationException</c>
        /// error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_TimestreamParameters_VersionValue")]
        public System.String TimestreamParameters_VersionValue { get; set; }
        #endregion
        
        #region Parameter RedshiftDataParameters_WithEvent
        /// <summary>
        /// <para>
        /// <para>Indicates whether to send an event back to EventBridge after the SQL statement runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetParameters_RedshiftDataParameters_WithEvent")]
        public System.Boolean? RedshiftDataParameters_WithEvent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pipes.Model.UpdatePipeResponse).
        /// Specifying the name of a property of type Amazon.Pipes.Model.UpdatePipeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PIPESPipe (UpdatePipe)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pipes.Model.UpdatePipeResponse, UpdatePIPESPipeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.DesiredState = this.DesiredState;
            context.Enrichment = this.Enrichment;
            if (this.EnrichmentParameters_HttpParameters_HeaderParameters != null)
            {
                context.EnrichmentParameters_HttpParameters_HeaderParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnrichmentParameters_HttpParameters_HeaderParameters.Keys)
                {
                    context.EnrichmentParameters_HttpParameters_HeaderParameters.Add((String)hashKey, (System.String)(this.EnrichmentParameters_HttpParameters_HeaderParameters[hashKey]));
                }
            }
            if (this.EnrichmentParameters_HttpParameters_PathParameterValues != null)
            {
                context.EnrichmentParameters_HttpParameters_PathParameterValues = new List<System.String>(this.EnrichmentParameters_HttpParameters_PathParameterValues);
            }
            if (this.EnrichmentParameters_HttpParameters_QueryStringParameters != null)
            {
                context.EnrichmentParameters_HttpParameters_QueryStringParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnrichmentParameters_HttpParameters_QueryStringParameters.Keys)
                {
                    context.EnrichmentParameters_HttpParameters_QueryStringParameters.Add((String)hashKey, (System.String)(this.EnrichmentParameters_HttpParameters_QueryStringParameters[hashKey]));
                }
            }
            context.EnrichmentParameters_InputTemplate = this.EnrichmentParameters_InputTemplate;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.CloudwatchLogsLogDestination_LogGroupArn = this.CloudwatchLogsLogDestination_LogGroupArn;
            context.FirehoseLogDestination_DeliveryStreamArn = this.FirehoseLogDestination_DeliveryStreamArn;
            if (this.LogConfiguration_IncludeExecutionData != null)
            {
                context.LogConfiguration_IncludeExecutionData = new List<System.String>(this.LogConfiguration_IncludeExecutionData);
            }
            context.LogConfiguration_Level = this.LogConfiguration_Level;
            context.S3LogDestination_BucketName = this.S3LogDestination_BucketName;
            context.S3LogDestination_BucketOwner = this.S3LogDestination_BucketOwner;
            context.S3LogDestination_OutputFormat = this.S3LogDestination_OutputFormat;
            context.S3LogDestination_Prefix = this.S3LogDestination_Prefix;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActiveMQBrokerParameters_BatchSize = this.ActiveMQBrokerParameters_BatchSize;
            context.SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth = this.SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth;
            context.ActiveMQBrokerParameters_MaximumBatchingWindowInSecond = this.ActiveMQBrokerParameters_MaximumBatchingWindowInSecond;
            context.DynamoDBStreamParameters_BatchSize = this.DynamoDBStreamParameters_BatchSize;
            context.SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn = this.SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn;
            context.DynamoDBStreamParameters_MaximumBatchingWindowInSecond = this.DynamoDBStreamParameters_MaximumBatchingWindowInSecond;
            context.DynamoDBStreamParameters_MaximumRecordAgeInSecond = this.DynamoDBStreamParameters_MaximumRecordAgeInSecond;
            context.DynamoDBStreamParameters_MaximumRetryAttempt = this.DynamoDBStreamParameters_MaximumRetryAttempt;
            context.DynamoDBStreamParameters_OnPartialBatchItemFailure = this.DynamoDBStreamParameters_OnPartialBatchItemFailure;
            context.DynamoDBStreamParameters_ParallelizationFactor = this.DynamoDBStreamParameters_ParallelizationFactor;
            if (this.FilterCriteria_Filter != null)
            {
                context.FilterCriteria_Filter = new List<Amazon.Pipes.Model.Filter>(this.FilterCriteria_Filter);
            }
            context.KinesisStreamParameters_BatchSize = this.KinesisStreamParameters_BatchSize;
            context.SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn = this.SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn;
            context.KinesisStreamParameters_MaximumBatchingWindowInSecond = this.KinesisStreamParameters_MaximumBatchingWindowInSecond;
            context.KinesisStreamParameters_MaximumRecordAgeInSecond = this.KinesisStreamParameters_MaximumRecordAgeInSecond;
            context.KinesisStreamParameters_MaximumRetryAttempt = this.KinesisStreamParameters_MaximumRetryAttempt;
            context.KinesisStreamParameters_OnPartialBatchItemFailure = this.KinesisStreamParameters_OnPartialBatchItemFailure;
            context.KinesisStreamParameters_ParallelizationFactor = this.KinesisStreamParameters_ParallelizationFactor;
            context.ManagedStreamingKafkaParameters_BatchSize = this.ManagedStreamingKafkaParameters_BatchSize;
            context.SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth = this.SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth;
            context.SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth = this.SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth;
            context.ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond = this.ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond;
            context.RabbitMQBrokerParameters_BatchSize = this.RabbitMQBrokerParameters_BatchSize;
            context.SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth = this.SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth;
            context.RabbitMQBrokerParameters_MaximumBatchingWindowInSecond = this.RabbitMQBrokerParameters_MaximumBatchingWindowInSecond;
            context.SelfManagedKafkaParameters_BatchSize = this.SelfManagedKafkaParameters_BatchSize;
            context.SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth = this.SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth;
            context.SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth = this.SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth;
            context.Credentials_SaslScram256Auth = this.Credentials_SaslScram256Auth;
            context.Credentials_SaslScram512Auth = this.Credentials_SaslScram512Auth;
            context.SelfManagedKafkaParameters_MaximumBatchingWindowInSecond = this.SelfManagedKafkaParameters_MaximumBatchingWindowInSecond;
            context.SelfManagedKafkaParameters_ServerRootCaCertificate = this.SelfManagedKafkaParameters_ServerRootCaCertificate;
            if (this.Vpc_SecurityGroup != null)
            {
                context.Vpc_SecurityGroup = new List<System.String>(this.Vpc_SecurityGroup);
            }
            if (this.Vpc_Subnet != null)
            {
                context.Vpc_Subnet = new List<System.String>(this.Vpc_Subnet);
            }
            context.SqsQueueParameters_BatchSize = this.SqsQueueParameters_BatchSize;
            context.SqsQueueParameters_MaximumBatchingWindowInSecond = this.SqsQueueParameters_MaximumBatchingWindowInSecond;
            context.Target = this.Target;
            context.ArrayProperties_Size = this.ArrayProperties_Size;
            if (this.ContainerOverrides_Command != null)
            {
                context.ContainerOverrides_Command = new List<System.String>(this.ContainerOverrides_Command);
            }
            if (this.ContainerOverrides_Environment != null)
            {
                context.ContainerOverrides_Environment = new List<Amazon.Pipes.Model.BatchEnvironmentVariable>(this.ContainerOverrides_Environment);
            }
            context.ContainerOverrides_InstanceType = this.ContainerOverrides_InstanceType;
            if (this.ContainerOverrides_ResourceRequirement != null)
            {
                context.ContainerOverrides_ResourceRequirement = new List<Amazon.Pipes.Model.BatchResourceRequirement>(this.ContainerOverrides_ResourceRequirement);
            }
            if (this.BatchJobParameters_DependsOn != null)
            {
                context.BatchJobParameters_DependsOn = new List<Amazon.Pipes.Model.BatchJobDependency>(this.BatchJobParameters_DependsOn);
            }
            context.BatchJobParameters_JobDefinition = this.BatchJobParameters_JobDefinition;
            context.BatchJobParameters_JobName = this.BatchJobParameters_JobName;
            if (this.BatchJobParameters_Parameter != null)
            {
                context.BatchJobParameters_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BatchJobParameters_Parameter.Keys)
                {
                    context.BatchJobParameters_Parameter.Add((String)hashKey, (System.String)(this.BatchJobParameters_Parameter[hashKey]));
                }
            }
            context.RetryStrategy_Attempt = this.RetryStrategy_Attempt;
            context.CloudWatchLogsParameters_LogStreamName = this.CloudWatchLogsParameters_LogStreamName;
            context.CloudWatchLogsParameters_Timestamp = this.CloudWatchLogsParameters_Timestamp;
            if (this.EcsTaskParameters_CapacityProviderStrategy != null)
            {
                context.EcsTaskParameters_CapacityProviderStrategy = new List<Amazon.Pipes.Model.CapacityProviderStrategyItem>(this.EcsTaskParameters_CapacityProviderStrategy);
            }
            context.EcsTaskParameters_EnableECSManagedTag = this.EcsTaskParameters_EnableECSManagedTag;
            context.EcsTaskParameters_EnableExecuteCommand = this.EcsTaskParameters_EnableExecuteCommand;
            context.EcsTaskParameters_Group = this.EcsTaskParameters_Group;
            context.EcsTaskParameters_LaunchType = this.EcsTaskParameters_LaunchType;
            context.AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.AwsvpcConfiguration_SecurityGroup = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.AwsvpcConfiguration_Subnet = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.Overrides_ContainerOverride != null)
            {
                context.Overrides_ContainerOverride = new List<Amazon.Pipes.Model.EcsContainerOverride>(this.Overrides_ContainerOverride);
            }
            context.Overrides_Cpu = this.Overrides_Cpu;
            context.EphemeralStorage_SizeInGiB = this.EphemeralStorage_SizeInGiB;
            context.Overrides_ExecutionRoleArn = this.Overrides_ExecutionRoleArn;
            if (this.Overrides_InferenceAcceleratorOverride != null)
            {
                context.Overrides_InferenceAcceleratorOverride = new List<Amazon.Pipes.Model.EcsInferenceAcceleratorOverride>(this.Overrides_InferenceAcceleratorOverride);
            }
            context.Overrides_Memory = this.Overrides_Memory;
            context.Overrides_TaskRoleArn = this.Overrides_TaskRoleArn;
            if (this.EcsTaskParameters_PlacementConstraint != null)
            {
                context.EcsTaskParameters_PlacementConstraint = new List<Amazon.Pipes.Model.PlacementConstraint>(this.EcsTaskParameters_PlacementConstraint);
            }
            if (this.EcsTaskParameters_PlacementStrategy != null)
            {
                context.EcsTaskParameters_PlacementStrategy = new List<Amazon.Pipes.Model.PlacementStrategy>(this.EcsTaskParameters_PlacementStrategy);
            }
            context.EcsTaskParameters_PlatformVersion = this.EcsTaskParameters_PlatformVersion;
            context.EcsTaskParameters_PropagateTag = this.EcsTaskParameters_PropagateTag;
            context.EcsTaskParameters_ReferenceId = this.EcsTaskParameters_ReferenceId;
            if (this.EcsTaskParameters_Tag != null)
            {
                context.EcsTaskParameters_Tag = new List<Amazon.Pipes.Model.Tag>(this.EcsTaskParameters_Tag);
            }
            context.EcsTaskParameters_TaskCount = this.EcsTaskParameters_TaskCount;
            context.EcsTaskParameters_TaskDefinitionArn = this.EcsTaskParameters_TaskDefinitionArn;
            context.EventBridgeEventBusParameters_DetailType = this.EventBridgeEventBusParameters_DetailType;
            context.EventBridgeEventBusParameters_EndpointId = this.EventBridgeEventBusParameters_EndpointId;
            if (this.EventBridgeEventBusParameters_Resource != null)
            {
                context.EventBridgeEventBusParameters_Resource = new List<System.String>(this.EventBridgeEventBusParameters_Resource);
            }
            context.EventBridgeEventBusParameters_Source = this.EventBridgeEventBusParameters_Source;
            context.EventBridgeEventBusParameters_Time = this.EventBridgeEventBusParameters_Time;
            if (this.TargetParameters_HttpParameters_HeaderParameters != null)
            {
                context.TargetParameters_HttpParameters_HeaderParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TargetParameters_HttpParameters_HeaderParameters.Keys)
                {
                    context.TargetParameters_HttpParameters_HeaderParameters.Add((String)hashKey, (System.String)(this.TargetParameters_HttpParameters_HeaderParameters[hashKey]));
                }
            }
            if (this.TargetParameters_HttpParameters_PathParameterValues != null)
            {
                context.TargetParameters_HttpParameters_PathParameterValues = new List<System.String>(this.TargetParameters_HttpParameters_PathParameterValues);
            }
            if (this.TargetParameters_HttpParameters_QueryStringParameters != null)
            {
                context.TargetParameters_HttpParameters_QueryStringParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TargetParameters_HttpParameters_QueryStringParameters.Keys)
                {
                    context.TargetParameters_HttpParameters_QueryStringParameters.Add((String)hashKey, (System.String)(this.TargetParameters_HttpParameters_QueryStringParameters[hashKey]));
                }
            }
            context.TargetParameters_InputTemplate = this.TargetParameters_InputTemplate;
            context.KinesisStreamParameters_PartitionKey = this.KinesisStreamParameters_PartitionKey;
            context.LambdaFunctionParameters_InvocationType = this.LambdaFunctionParameters_InvocationType;
            context.RedshiftDataParameters_Database = this.RedshiftDataParameters_Database;
            context.RedshiftDataParameters_DbUser = this.RedshiftDataParameters_DbUser;
            context.RedshiftDataParameters_SecretManagerArn = this.RedshiftDataParameters_SecretManagerArn;
            if (this.RedshiftDataParameters_Sql != null)
            {
                context.RedshiftDataParameters_Sql = new List<System.String>(this.RedshiftDataParameters_Sql);
            }
            context.RedshiftDataParameters_StatementName = this.RedshiftDataParameters_StatementName;
            context.RedshiftDataParameters_WithEvent = this.RedshiftDataParameters_WithEvent;
            if (this.SageMakerPipelineParameters_PipelineParameterList != null)
            {
                context.SageMakerPipelineParameters_PipelineParameterList = new List<Amazon.Pipes.Model.SageMakerPipelineParameter>(this.SageMakerPipelineParameters_PipelineParameterList);
            }
            context.SqsQueueParameters_MessageDeduplicationId = this.SqsQueueParameters_MessageDeduplicationId;
            context.SqsQueueParameters_MessageGroupId = this.SqsQueueParameters_MessageGroupId;
            context.StepFunctionStateMachineParameters_InvocationType = this.StepFunctionStateMachineParameters_InvocationType;
            if (this.TimestreamParameters_DimensionMapping != null)
            {
                context.TimestreamParameters_DimensionMapping = new List<Amazon.Pipes.Model.DimensionMapping>(this.TimestreamParameters_DimensionMapping);
            }
            context.TimestreamParameters_EpochTimeUnit = this.TimestreamParameters_EpochTimeUnit;
            if (this.TimestreamParameters_MultiMeasureMapping != null)
            {
                context.TimestreamParameters_MultiMeasureMapping = new List<Amazon.Pipes.Model.MultiMeasureMapping>(this.TimestreamParameters_MultiMeasureMapping);
            }
            if (this.TimestreamParameters_SingleMeasureMapping != null)
            {
                context.TimestreamParameters_SingleMeasureMapping = new List<Amazon.Pipes.Model.SingleMeasureMapping>(this.TimestreamParameters_SingleMeasureMapping);
            }
            context.TimestreamParameters_TimeFieldType = this.TimestreamParameters_TimeFieldType;
            context.TimestreamParameters_TimestampFormat = this.TimestreamParameters_TimestampFormat;
            context.TimestreamParameters_TimeValue = this.TimestreamParameters_TimeValue;
            context.TimestreamParameters_VersionValue = this.TimestreamParameters_VersionValue;
            
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
            var request = new Amazon.Pipes.Model.UpdatePipeRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DesiredState != null)
            {
                request.DesiredState = cmdletContext.DesiredState;
            }
            if (cmdletContext.Enrichment != null)
            {
                request.Enrichment = cmdletContext.Enrichment;
            }
            
             // populate EnrichmentParameters
            var requestEnrichmentParametersIsNull = true;
            request.EnrichmentParameters = new Amazon.Pipes.Model.PipeEnrichmentParameters();
            System.String requestEnrichmentParameters_enrichmentParameters_InputTemplate = null;
            if (cmdletContext.EnrichmentParameters_InputTemplate != null)
            {
                requestEnrichmentParameters_enrichmentParameters_InputTemplate = cmdletContext.EnrichmentParameters_InputTemplate;
            }
            if (requestEnrichmentParameters_enrichmentParameters_InputTemplate != null)
            {
                request.EnrichmentParameters.InputTemplate = requestEnrichmentParameters_enrichmentParameters_InputTemplate;
                requestEnrichmentParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeEnrichmentHttpParameters requestEnrichmentParameters_enrichmentParameters_HttpParameters = null;
            
             // populate HttpParameters
            var requestEnrichmentParameters_enrichmentParameters_HttpParametersIsNull = true;
            requestEnrichmentParameters_enrichmentParameters_HttpParameters = new Amazon.Pipes.Model.PipeEnrichmentHttpParameters();
            Dictionary<System.String, System.String> requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_HeaderParameters = null;
            if (cmdletContext.EnrichmentParameters_HttpParameters_HeaderParameters != null)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_HeaderParameters = cmdletContext.EnrichmentParameters_HttpParameters_HeaderParameters;
            }
            if (requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_HeaderParameters != null)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters.HeaderParameters = requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_HeaderParameters;
                requestEnrichmentParameters_enrichmentParameters_HttpParametersIsNull = false;
            }
            List<System.String> requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_PathParameterValues = null;
            if (cmdletContext.EnrichmentParameters_HttpParameters_PathParameterValues != null)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_PathParameterValues = cmdletContext.EnrichmentParameters_HttpParameters_PathParameterValues;
            }
            if (requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_PathParameterValues != null)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters.PathParameterValues = requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_PathParameterValues;
                requestEnrichmentParameters_enrichmentParameters_HttpParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_QueryStringParameters = null;
            if (cmdletContext.EnrichmentParameters_HttpParameters_QueryStringParameters != null)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_QueryStringParameters = cmdletContext.EnrichmentParameters_HttpParameters_QueryStringParameters;
            }
            if (requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_QueryStringParameters != null)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters.QueryStringParameters = requestEnrichmentParameters_enrichmentParameters_HttpParameters_enrichmentParameters_HttpParameters_QueryStringParameters;
                requestEnrichmentParameters_enrichmentParameters_HttpParametersIsNull = false;
            }
             // determine if requestEnrichmentParameters_enrichmentParameters_HttpParameters should be set to null
            if (requestEnrichmentParameters_enrichmentParameters_HttpParametersIsNull)
            {
                requestEnrichmentParameters_enrichmentParameters_HttpParameters = null;
            }
            if (requestEnrichmentParameters_enrichmentParameters_HttpParameters != null)
            {
                request.EnrichmentParameters.HttpParameters = requestEnrichmentParameters_enrichmentParameters_HttpParameters;
                requestEnrichmentParametersIsNull = false;
            }
             // determine if request.EnrichmentParameters should be set to null
            if (requestEnrichmentParametersIsNull)
            {
                request.EnrichmentParameters = null;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            
             // populate LogConfiguration
            var requestLogConfigurationIsNull = true;
            request.LogConfiguration = new Amazon.Pipes.Model.PipeLogConfigurationParameters();
            List<System.String> requestLogConfiguration_logConfiguration_IncludeExecutionData = null;
            if (cmdletContext.LogConfiguration_IncludeExecutionData != null)
            {
                requestLogConfiguration_logConfiguration_IncludeExecutionData = cmdletContext.LogConfiguration_IncludeExecutionData;
            }
            if (requestLogConfiguration_logConfiguration_IncludeExecutionData != null)
            {
                request.LogConfiguration.IncludeExecutionData = requestLogConfiguration_logConfiguration_IncludeExecutionData;
                requestLogConfigurationIsNull = false;
            }
            Amazon.Pipes.LogLevel requestLogConfiguration_logConfiguration_Level = null;
            if (cmdletContext.LogConfiguration_Level != null)
            {
                requestLogConfiguration_logConfiguration_Level = cmdletContext.LogConfiguration_Level;
            }
            if (requestLogConfiguration_logConfiguration_Level != null)
            {
                request.LogConfiguration.Level = requestLogConfiguration_logConfiguration_Level;
                requestLogConfigurationIsNull = false;
            }
            Amazon.Pipes.Model.CloudwatchLogsLogDestinationParameters requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination = null;
            
             // populate CloudwatchLogsLogDestination
            var requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestinationIsNull = true;
            requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination = new Amazon.Pipes.Model.CloudwatchLogsLogDestinationParameters();
            System.String requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination_cloudwatchLogsLogDestination_LogGroupArn = null;
            if (cmdletContext.CloudwatchLogsLogDestination_LogGroupArn != null)
            {
                requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination_cloudwatchLogsLogDestination_LogGroupArn = cmdletContext.CloudwatchLogsLogDestination_LogGroupArn;
            }
            if (requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination_cloudwatchLogsLogDestination_LogGroupArn != null)
            {
                requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination.LogGroupArn = requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination_cloudwatchLogsLogDestination_LogGroupArn;
                requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestinationIsNull = false;
            }
             // determine if requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination should be set to null
            if (requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestinationIsNull)
            {
                requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination = null;
            }
            if (requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination != null)
            {
                request.LogConfiguration.CloudwatchLogsLogDestination = requestLogConfiguration_logConfiguration_CloudwatchLogsLogDestination;
                requestLogConfigurationIsNull = false;
            }
            Amazon.Pipes.Model.FirehoseLogDestinationParameters requestLogConfiguration_logConfiguration_FirehoseLogDestination = null;
            
             // populate FirehoseLogDestination
            var requestLogConfiguration_logConfiguration_FirehoseLogDestinationIsNull = true;
            requestLogConfiguration_logConfiguration_FirehoseLogDestination = new Amazon.Pipes.Model.FirehoseLogDestinationParameters();
            System.String requestLogConfiguration_logConfiguration_FirehoseLogDestination_firehoseLogDestination_DeliveryStreamArn = null;
            if (cmdletContext.FirehoseLogDestination_DeliveryStreamArn != null)
            {
                requestLogConfiguration_logConfiguration_FirehoseLogDestination_firehoseLogDestination_DeliveryStreamArn = cmdletContext.FirehoseLogDestination_DeliveryStreamArn;
            }
            if (requestLogConfiguration_logConfiguration_FirehoseLogDestination_firehoseLogDestination_DeliveryStreamArn != null)
            {
                requestLogConfiguration_logConfiguration_FirehoseLogDestination.DeliveryStreamArn = requestLogConfiguration_logConfiguration_FirehoseLogDestination_firehoseLogDestination_DeliveryStreamArn;
                requestLogConfiguration_logConfiguration_FirehoseLogDestinationIsNull = false;
            }
             // determine if requestLogConfiguration_logConfiguration_FirehoseLogDestination should be set to null
            if (requestLogConfiguration_logConfiguration_FirehoseLogDestinationIsNull)
            {
                requestLogConfiguration_logConfiguration_FirehoseLogDestination = null;
            }
            if (requestLogConfiguration_logConfiguration_FirehoseLogDestination != null)
            {
                request.LogConfiguration.FirehoseLogDestination = requestLogConfiguration_logConfiguration_FirehoseLogDestination;
                requestLogConfigurationIsNull = false;
            }
            Amazon.Pipes.Model.S3LogDestinationParameters requestLogConfiguration_logConfiguration_S3LogDestination = null;
            
             // populate S3LogDestination
            var requestLogConfiguration_logConfiguration_S3LogDestinationIsNull = true;
            requestLogConfiguration_logConfiguration_S3LogDestination = new Amazon.Pipes.Model.S3LogDestinationParameters();
            System.String requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketName = null;
            if (cmdletContext.S3LogDestination_BucketName != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketName = cmdletContext.S3LogDestination_BucketName;
            }
            if (requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketName != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination.BucketName = requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketName;
                requestLogConfiguration_logConfiguration_S3LogDestinationIsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketOwner = null;
            if (cmdletContext.S3LogDestination_BucketOwner != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketOwner = cmdletContext.S3LogDestination_BucketOwner;
            }
            if (requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketOwner != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination.BucketOwner = requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_BucketOwner;
                requestLogConfiguration_logConfiguration_S3LogDestinationIsNull = false;
            }
            Amazon.Pipes.S3OutputFormat requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_OutputFormat = null;
            if (cmdletContext.S3LogDestination_OutputFormat != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_OutputFormat = cmdletContext.S3LogDestination_OutputFormat;
            }
            if (requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_OutputFormat != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination.OutputFormat = requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_OutputFormat;
                requestLogConfiguration_logConfiguration_S3LogDestinationIsNull = false;
            }
            System.String requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_Prefix = null;
            if (cmdletContext.S3LogDestination_Prefix != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_Prefix = cmdletContext.S3LogDestination_Prefix;
            }
            if (requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_Prefix != null)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination.Prefix = requestLogConfiguration_logConfiguration_S3LogDestination_s3LogDestination_Prefix;
                requestLogConfiguration_logConfiguration_S3LogDestinationIsNull = false;
            }
             // determine if requestLogConfiguration_logConfiguration_S3LogDestination should be set to null
            if (requestLogConfiguration_logConfiguration_S3LogDestinationIsNull)
            {
                requestLogConfiguration_logConfiguration_S3LogDestination = null;
            }
            if (requestLogConfiguration_logConfiguration_S3LogDestination != null)
            {
                request.LogConfiguration.S3LogDestination = requestLogConfiguration_logConfiguration_S3LogDestination;
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
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate SourceParameters
            var requestSourceParametersIsNull = true;
            request.SourceParameters = new Amazon.Pipes.Model.UpdatePipeSourceParameters();
            Amazon.Pipes.Model.FilterCriteria requestSourceParameters_sourceParameters_FilterCriteria = null;
            
             // populate FilterCriteria
            var requestSourceParameters_sourceParameters_FilterCriteriaIsNull = true;
            requestSourceParameters_sourceParameters_FilterCriteria = new Amazon.Pipes.Model.FilterCriteria();
            List<Amazon.Pipes.Model.Filter> requestSourceParameters_sourceParameters_FilterCriteria_filterCriteria_Filter = null;
            if (cmdletContext.FilterCriteria_Filter != null)
            {
                requestSourceParameters_sourceParameters_FilterCriteria_filterCriteria_Filter = cmdletContext.FilterCriteria_Filter;
            }
            if (requestSourceParameters_sourceParameters_FilterCriteria_filterCriteria_Filter != null)
            {
                requestSourceParameters_sourceParameters_FilterCriteria.Filters = requestSourceParameters_sourceParameters_FilterCriteria_filterCriteria_Filter;
                requestSourceParameters_sourceParameters_FilterCriteriaIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_FilterCriteria should be set to null
            if (requestSourceParameters_sourceParameters_FilterCriteriaIsNull)
            {
                requestSourceParameters_sourceParameters_FilterCriteria = null;
            }
            if (requestSourceParameters_sourceParameters_FilterCriteria != null)
            {
                request.SourceParameters.FilterCriteria = requestSourceParameters_sourceParameters_FilterCriteria;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceSqsQueueParameters requestSourceParameters_sourceParameters_SqsQueueParameters = null;
            
             // populate SqsQueueParameters
            var requestSourceParameters_sourceParameters_SqsQueueParametersIsNull = true;
            requestSourceParameters_sourceParameters_SqsQueueParameters = new Amazon.Pipes.Model.UpdatePipeSourceSqsQueueParameters();
            System.Int32? requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_BatchSize = null;
            if (cmdletContext.SqsQueueParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_BatchSize = cmdletContext.SqsQueueParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_SqsQueueParameters.BatchSize = requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_SqsQueueParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.SqsQueueParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_MaximumBatchingWindowInSecond = cmdletContext.SqsQueueParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_SqsQueueParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_SqsQueueParameters_sqsQueueParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_SqsQueueParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_SqsQueueParameters should be set to null
            if (requestSourceParameters_sourceParameters_SqsQueueParametersIsNull)
            {
                requestSourceParameters_sourceParameters_SqsQueueParameters = null;
            }
            if (requestSourceParameters_sourceParameters_SqsQueueParameters != null)
            {
                request.SourceParameters.SqsQueueParameters = requestSourceParameters_sourceParameters_SqsQueueParameters;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceActiveMQBrokerParameters requestSourceParameters_sourceParameters_ActiveMQBrokerParameters = null;
            
             // populate ActiveMQBrokerParameters
            var requestSourceParameters_sourceParameters_ActiveMQBrokerParametersIsNull = true;
            requestSourceParameters_sourceParameters_ActiveMQBrokerParameters = new Amazon.Pipes.Model.UpdatePipeSourceActiveMQBrokerParameters();
            System.Int32? requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_BatchSize = null;
            if (cmdletContext.ActiveMQBrokerParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_BatchSize = cmdletContext.ActiveMQBrokerParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters.BatchSize = requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_ActiveMQBrokerParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.ActiveMQBrokerParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_MaximumBatchingWindowInSecond = cmdletContext.ActiveMQBrokerParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_activeMQBrokerParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_ActiveMQBrokerParametersIsNull = false;
            }
            Amazon.Pipes.Model.MQBrokerAccessCredentials requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials = null;
            
             // populate Credentials
            var requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_CredentialsIsNull = true;
            requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials = new Amazon.Pipes.Model.MQBrokerAccessCredentials();
            System.String requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials_sourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth = null;
            if (cmdletContext.SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials_sourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth = cmdletContext.SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth;
            }
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials_sourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials.BasicAuth = requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials_sourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth;
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_CredentialsIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials should be set to null
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_CredentialsIsNull)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials = null;
            }
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials != null)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters.Credentials = requestSourceParameters_sourceParameters_ActiveMQBrokerParameters_sourceParameters_ActiveMQBrokerParameters_Credentials;
                requestSourceParameters_sourceParameters_ActiveMQBrokerParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_ActiveMQBrokerParameters should be set to null
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParametersIsNull)
            {
                requestSourceParameters_sourceParameters_ActiveMQBrokerParameters = null;
            }
            if (requestSourceParameters_sourceParameters_ActiveMQBrokerParameters != null)
            {
                request.SourceParameters.ActiveMQBrokerParameters = requestSourceParameters_sourceParameters_ActiveMQBrokerParameters;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceManagedStreamingKafkaParameters requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters = null;
            
             // populate ManagedStreamingKafkaParameters
            var requestSourceParameters_sourceParameters_ManagedStreamingKafkaParametersIsNull = true;
            requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters = new Amazon.Pipes.Model.UpdatePipeSourceManagedStreamingKafkaParameters();
            System.Int32? requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_BatchSize = null;
            if (cmdletContext.ManagedStreamingKafkaParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_BatchSize = cmdletContext.ManagedStreamingKafkaParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters.BatchSize = requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_MaximumBatchingWindowInSecond = cmdletContext.ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_managedStreamingKafkaParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParametersIsNull = false;
            }
            Amazon.Pipes.Model.MSKAccessCredentials requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials = null;
            
             // populate Credentials
            var requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_CredentialsIsNull = true;
            requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials = new Amazon.Pipes.Model.MSKAccessCredentials();
            System.String requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth = null;
            if (cmdletContext.SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth = cmdletContext.SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth;
            }
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials.ClientCertificateTlsAuth = requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth;
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_CredentialsIsNull = false;
            }
            System.String requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth = null;
            if (cmdletContext.SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth = cmdletContext.SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth;
            }
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials.SaslScram512Auth = requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials_sourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth;
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_CredentialsIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials should be set to null
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_CredentialsIsNull)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials = null;
            }
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials != null)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters.Credentials = requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters_sourceParameters_ManagedStreamingKafkaParameters_Credentials;
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters should be set to null
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParametersIsNull)
            {
                requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters = null;
            }
            if (requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters != null)
            {
                request.SourceParameters.ManagedStreamingKafkaParameters = requestSourceParameters_sourceParameters_ManagedStreamingKafkaParameters;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceRabbitMQBrokerParameters requestSourceParameters_sourceParameters_RabbitMQBrokerParameters = null;
            
             // populate RabbitMQBrokerParameters
            var requestSourceParameters_sourceParameters_RabbitMQBrokerParametersIsNull = true;
            requestSourceParameters_sourceParameters_RabbitMQBrokerParameters = new Amazon.Pipes.Model.UpdatePipeSourceRabbitMQBrokerParameters();
            System.Int32? requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_BatchSize = null;
            if (cmdletContext.RabbitMQBrokerParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_BatchSize = cmdletContext.RabbitMQBrokerParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters.BatchSize = requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_RabbitMQBrokerParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.RabbitMQBrokerParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_MaximumBatchingWindowInSecond = cmdletContext.RabbitMQBrokerParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_rabbitMQBrokerParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_RabbitMQBrokerParametersIsNull = false;
            }
            Amazon.Pipes.Model.MQBrokerAccessCredentials requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials = null;
            
             // populate Credentials
            var requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_CredentialsIsNull = true;
            requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials = new Amazon.Pipes.Model.MQBrokerAccessCredentials();
            System.String requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials_sourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth = null;
            if (cmdletContext.SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials_sourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth = cmdletContext.SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth;
            }
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials_sourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials.BasicAuth = requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials_sourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth;
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_CredentialsIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials should be set to null
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_CredentialsIsNull)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials = null;
            }
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials != null)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters.Credentials = requestSourceParameters_sourceParameters_RabbitMQBrokerParameters_sourceParameters_RabbitMQBrokerParameters_Credentials;
                requestSourceParameters_sourceParameters_RabbitMQBrokerParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_RabbitMQBrokerParameters should be set to null
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParametersIsNull)
            {
                requestSourceParameters_sourceParameters_RabbitMQBrokerParameters = null;
            }
            if (requestSourceParameters_sourceParameters_RabbitMQBrokerParameters != null)
            {
                request.SourceParameters.RabbitMQBrokerParameters = requestSourceParameters_sourceParameters_RabbitMQBrokerParameters;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceSelfManagedKafkaParameters requestSourceParameters_sourceParameters_SelfManagedKafkaParameters = null;
            
             // populate SelfManagedKafkaParameters
            var requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull = true;
            requestSourceParameters_sourceParameters_SelfManagedKafkaParameters = new Amazon.Pipes.Model.UpdatePipeSourceSelfManagedKafkaParameters();
            System.Int32? requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_BatchSize = null;
            if (cmdletContext.SelfManagedKafkaParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_BatchSize = cmdletContext.SelfManagedKafkaParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters.BatchSize = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.SelfManagedKafkaParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_MaximumBatchingWindowInSecond = cmdletContext.SelfManagedKafkaParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull = false;
            }
            System.String requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_ServerRootCaCertificate = null;
            if (cmdletContext.SelfManagedKafkaParameters_ServerRootCaCertificate != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_ServerRootCaCertificate = cmdletContext.SelfManagedKafkaParameters_ServerRootCaCertificate;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_ServerRootCaCertificate != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters.ServerRootCaCertificate = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_selfManagedKafkaParameters_ServerRootCaCertificate;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull = false;
            }
            Amazon.Pipes.Model.SelfManagedKafkaAccessConfigurationVpc requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc = null;
            
             // populate Vpc
            var requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_VpcIsNull = true;
            requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc = new Amazon.Pipes.Model.SelfManagedKafkaAccessConfigurationVpc();
            List<System.String> requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_SecurityGroup = null;
            if (cmdletContext.Vpc_SecurityGroup != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_SecurityGroup = cmdletContext.Vpc_SecurityGroup;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_SecurityGroup != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc.SecurityGroup = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_SecurityGroup;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_VpcIsNull = false;
            }
            List<System.String> requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_Subnet = null;
            if (cmdletContext.Vpc_Subnet != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_Subnet = cmdletContext.Vpc_Subnet;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_Subnet != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc.Subnets = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc_vpc_Subnet;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_VpcIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc should be set to null
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_VpcIsNull)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc = null;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters.Vpc = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Vpc;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull = false;
            }
            Amazon.Pipes.Model.SelfManagedKafkaAccessConfigurationCredentials requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials = null;
            
             // populate Credentials
            var requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_CredentialsIsNull = true;
            requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials = new Amazon.Pipes.Model.SelfManagedKafkaAccessConfigurationCredentials();
            System.String requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth = null;
            if (cmdletContext.SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth = cmdletContext.SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials.BasicAuth = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_CredentialsIsNull = false;
            }
            System.String requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth = null;
            if (cmdletContext.SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth = cmdletContext.SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials.ClientCertificateTlsAuth = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_sourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_CredentialsIsNull = false;
            }
            System.String requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram256Auth = null;
            if (cmdletContext.Credentials_SaslScram256Auth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram256Auth = cmdletContext.Credentials_SaslScram256Auth;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram256Auth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials.SaslScram256Auth = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram256Auth;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_CredentialsIsNull = false;
            }
            System.String requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram512Auth = null;
            if (cmdletContext.Credentials_SaslScram512Auth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram512Auth = cmdletContext.Credentials_SaslScram512Auth;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram512Auth != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials.SaslScram512Auth = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials_credentials_SaslScram512Auth;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_CredentialsIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials should be set to null
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_CredentialsIsNull)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials = null;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials != null)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters.Credentials = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters_sourceParameters_SelfManagedKafkaParameters_Credentials;
                requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_SelfManagedKafkaParameters should be set to null
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParametersIsNull)
            {
                requestSourceParameters_sourceParameters_SelfManagedKafkaParameters = null;
            }
            if (requestSourceParameters_sourceParameters_SelfManagedKafkaParameters != null)
            {
                request.SourceParameters.SelfManagedKafkaParameters = requestSourceParameters_sourceParameters_SelfManagedKafkaParameters;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceDynamoDBStreamParameters requestSourceParameters_sourceParameters_DynamoDBStreamParameters = null;
            
             // populate DynamoDBStreamParameters
            var requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = true;
            requestSourceParameters_sourceParameters_DynamoDBStreamParameters = new Amazon.Pipes.Model.UpdatePipeSourceDynamoDBStreamParameters();
            System.Int32? requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_BatchSize = null;
            if (cmdletContext.DynamoDBStreamParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_BatchSize = cmdletContext.DynamoDBStreamParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.BatchSize = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.DynamoDBStreamParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumBatchingWindowInSecond = cmdletContext.DynamoDBStreamParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRecordAgeInSecond = null;
            if (cmdletContext.DynamoDBStreamParameters_MaximumRecordAgeInSecond != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRecordAgeInSecond = cmdletContext.DynamoDBStreamParameters_MaximumRecordAgeInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRecordAgeInSecond != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.MaximumRecordAgeInSeconds = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRecordAgeInSecond.Value;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRetryAttempt = null;
            if (cmdletContext.DynamoDBStreamParameters_MaximumRetryAttempt != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRetryAttempt = cmdletContext.DynamoDBStreamParameters_MaximumRetryAttempt.Value;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRetryAttempt != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.MaximumRetryAttempts = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_MaximumRetryAttempt.Value;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
            Amazon.Pipes.OnPartialBatchItemFailureStreams requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_OnPartialBatchItemFailure = null;
            if (cmdletContext.DynamoDBStreamParameters_OnPartialBatchItemFailure != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_OnPartialBatchItemFailure = cmdletContext.DynamoDBStreamParameters_OnPartialBatchItemFailure;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_OnPartialBatchItemFailure != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.OnPartialBatchItemFailure = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_OnPartialBatchItemFailure;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_ParallelizationFactor = null;
            if (cmdletContext.DynamoDBStreamParameters_ParallelizationFactor != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_ParallelizationFactor = cmdletContext.DynamoDBStreamParameters_ParallelizationFactor.Value;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_ParallelizationFactor != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.ParallelizationFactor = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_dynamoDBStreamParameters_ParallelizationFactor.Value;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
            Amazon.Pipes.Model.DeadLetterConfig requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig = null;
            
             // populate DeadLetterConfig
            var requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfigIsNull = true;
            requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig = new Amazon.Pipes.Model.DeadLetterConfig();
            System.String requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn = null;
            if (cmdletContext.SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn = cmdletContext.SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig.Arn = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn;
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfigIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig should be set to null
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfigIsNull)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig = null;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig != null)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters.DeadLetterConfig = requestSourceParameters_sourceParameters_DynamoDBStreamParameters_sourceParameters_DynamoDBStreamParameters_DeadLetterConfig;
                requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_DynamoDBStreamParameters should be set to null
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParametersIsNull)
            {
                requestSourceParameters_sourceParameters_DynamoDBStreamParameters = null;
            }
            if (requestSourceParameters_sourceParameters_DynamoDBStreamParameters != null)
            {
                request.SourceParameters.DynamoDBStreamParameters = requestSourceParameters_sourceParameters_DynamoDBStreamParameters;
                requestSourceParametersIsNull = false;
            }
            Amazon.Pipes.Model.UpdatePipeSourceKinesisStreamParameters requestSourceParameters_sourceParameters_KinesisStreamParameters = null;
            
             // populate KinesisStreamParameters
            var requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = true;
            requestSourceParameters_sourceParameters_KinesisStreamParameters = new Amazon.Pipes.Model.UpdatePipeSourceKinesisStreamParameters();
            System.Int32? requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_BatchSize = null;
            if (cmdletContext.KinesisStreamParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_BatchSize = cmdletContext.KinesisStreamParameters_BatchSize.Value;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_BatchSize != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.BatchSize = requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_BatchSize.Value;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumBatchingWindowInSecond = null;
            if (cmdletContext.KinesisStreamParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumBatchingWindowInSecond = cmdletContext.KinesisStreamParameters_MaximumBatchingWindowInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumBatchingWindowInSecond != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.MaximumBatchingWindowInSeconds = requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumBatchingWindowInSecond.Value;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRecordAgeInSecond = null;
            if (cmdletContext.KinesisStreamParameters_MaximumRecordAgeInSecond != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRecordAgeInSecond = cmdletContext.KinesisStreamParameters_MaximumRecordAgeInSecond.Value;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRecordAgeInSecond != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.MaximumRecordAgeInSeconds = requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRecordAgeInSecond.Value;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRetryAttempt = null;
            if (cmdletContext.KinesisStreamParameters_MaximumRetryAttempt != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRetryAttempt = cmdletContext.KinesisStreamParameters_MaximumRetryAttempt.Value;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRetryAttempt != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.MaximumRetryAttempts = requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_MaximumRetryAttempt.Value;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
            Amazon.Pipes.OnPartialBatchItemFailureStreams requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_OnPartialBatchItemFailure = null;
            if (cmdletContext.KinesisStreamParameters_OnPartialBatchItemFailure != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_OnPartialBatchItemFailure = cmdletContext.KinesisStreamParameters_OnPartialBatchItemFailure;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_OnPartialBatchItemFailure != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.OnPartialBatchItemFailure = requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_OnPartialBatchItemFailure;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
            System.Int32? requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_ParallelizationFactor = null;
            if (cmdletContext.KinesisStreamParameters_ParallelizationFactor != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_ParallelizationFactor = cmdletContext.KinesisStreamParameters_ParallelizationFactor.Value;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_ParallelizationFactor != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.ParallelizationFactor = requestSourceParameters_sourceParameters_KinesisStreamParameters_kinesisStreamParameters_ParallelizationFactor.Value;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
            Amazon.Pipes.Model.DeadLetterConfig requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig = null;
            
             // populate DeadLetterConfig
            var requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfigIsNull = true;
            requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig = new Amazon.Pipes.Model.DeadLetterConfig();
            System.String requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig_sourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn = null;
            if (cmdletContext.SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig_sourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn = cmdletContext.SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig_sourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig.Arn = requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig_sourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn;
                requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfigIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig should be set to null
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfigIsNull)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig = null;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig != null)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters.DeadLetterConfig = requestSourceParameters_sourceParameters_KinesisStreamParameters_sourceParameters_KinesisStreamParameters_DeadLetterConfig;
                requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull = false;
            }
             // determine if requestSourceParameters_sourceParameters_KinesisStreamParameters should be set to null
            if (requestSourceParameters_sourceParameters_KinesisStreamParametersIsNull)
            {
                requestSourceParameters_sourceParameters_KinesisStreamParameters = null;
            }
            if (requestSourceParameters_sourceParameters_KinesisStreamParameters != null)
            {
                request.SourceParameters.KinesisStreamParameters = requestSourceParameters_sourceParameters_KinesisStreamParameters;
                requestSourceParametersIsNull = false;
            }
             // determine if request.SourceParameters should be set to null
            if (requestSourceParametersIsNull)
            {
                request.SourceParameters = null;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
            }
            
             // populate TargetParameters
            var requestTargetParametersIsNull = true;
            request.TargetParameters = new Amazon.Pipes.Model.PipeTargetParameters();
            System.String requestTargetParameters_targetParameters_InputTemplate = null;
            if (cmdletContext.TargetParameters_InputTemplate != null)
            {
                requestTargetParameters_targetParameters_InputTemplate = cmdletContext.TargetParameters_InputTemplate;
            }
            if (requestTargetParameters_targetParameters_InputTemplate != null)
            {
                request.TargetParameters.InputTemplate = requestTargetParameters_targetParameters_InputTemplate;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetKinesisStreamParameters requestTargetParameters_targetParameters_KinesisStreamParameters = null;
            
             // populate KinesisStreamParameters
            var requestTargetParameters_targetParameters_KinesisStreamParametersIsNull = true;
            requestTargetParameters_targetParameters_KinesisStreamParameters = new Amazon.Pipes.Model.PipeTargetKinesisStreamParameters();
            System.String requestTargetParameters_targetParameters_KinesisStreamParameters_kinesisStreamParameters_PartitionKey = null;
            if (cmdletContext.KinesisStreamParameters_PartitionKey != null)
            {
                requestTargetParameters_targetParameters_KinesisStreamParameters_kinesisStreamParameters_PartitionKey = cmdletContext.KinesisStreamParameters_PartitionKey;
            }
            if (requestTargetParameters_targetParameters_KinesisStreamParameters_kinesisStreamParameters_PartitionKey != null)
            {
                requestTargetParameters_targetParameters_KinesisStreamParameters.PartitionKey = requestTargetParameters_targetParameters_KinesisStreamParameters_kinesisStreamParameters_PartitionKey;
                requestTargetParameters_targetParameters_KinesisStreamParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_KinesisStreamParameters should be set to null
            if (requestTargetParameters_targetParameters_KinesisStreamParametersIsNull)
            {
                requestTargetParameters_targetParameters_KinesisStreamParameters = null;
            }
            if (requestTargetParameters_targetParameters_KinesisStreamParameters != null)
            {
                request.TargetParameters.KinesisStreamParameters = requestTargetParameters_targetParameters_KinesisStreamParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetLambdaFunctionParameters requestTargetParameters_targetParameters_LambdaFunctionParameters = null;
            
             // populate LambdaFunctionParameters
            var requestTargetParameters_targetParameters_LambdaFunctionParametersIsNull = true;
            requestTargetParameters_targetParameters_LambdaFunctionParameters = new Amazon.Pipes.Model.PipeTargetLambdaFunctionParameters();
            Amazon.Pipes.PipeTargetInvocationType requestTargetParameters_targetParameters_LambdaFunctionParameters_lambdaFunctionParameters_InvocationType = null;
            if (cmdletContext.LambdaFunctionParameters_InvocationType != null)
            {
                requestTargetParameters_targetParameters_LambdaFunctionParameters_lambdaFunctionParameters_InvocationType = cmdletContext.LambdaFunctionParameters_InvocationType;
            }
            if (requestTargetParameters_targetParameters_LambdaFunctionParameters_lambdaFunctionParameters_InvocationType != null)
            {
                requestTargetParameters_targetParameters_LambdaFunctionParameters.InvocationType = requestTargetParameters_targetParameters_LambdaFunctionParameters_lambdaFunctionParameters_InvocationType;
                requestTargetParameters_targetParameters_LambdaFunctionParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_LambdaFunctionParameters should be set to null
            if (requestTargetParameters_targetParameters_LambdaFunctionParametersIsNull)
            {
                requestTargetParameters_targetParameters_LambdaFunctionParameters = null;
            }
            if (requestTargetParameters_targetParameters_LambdaFunctionParameters != null)
            {
                request.TargetParameters.LambdaFunctionParameters = requestTargetParameters_targetParameters_LambdaFunctionParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetSageMakerPipelineParameters requestTargetParameters_targetParameters_SageMakerPipelineParameters = null;
            
             // populate SageMakerPipelineParameters
            var requestTargetParameters_targetParameters_SageMakerPipelineParametersIsNull = true;
            requestTargetParameters_targetParameters_SageMakerPipelineParameters = new Amazon.Pipes.Model.PipeTargetSageMakerPipelineParameters();
            List<Amazon.Pipes.Model.SageMakerPipelineParameter> requestTargetParameters_targetParameters_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList = null;
            if (cmdletContext.SageMakerPipelineParameters_PipelineParameterList != null)
            {
                requestTargetParameters_targetParameters_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList = cmdletContext.SageMakerPipelineParameters_PipelineParameterList;
            }
            if (requestTargetParameters_targetParameters_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList != null)
            {
                requestTargetParameters_targetParameters_SageMakerPipelineParameters.PipelineParameterList = requestTargetParameters_targetParameters_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList;
                requestTargetParameters_targetParameters_SageMakerPipelineParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_SageMakerPipelineParameters should be set to null
            if (requestTargetParameters_targetParameters_SageMakerPipelineParametersIsNull)
            {
                requestTargetParameters_targetParameters_SageMakerPipelineParameters = null;
            }
            if (requestTargetParameters_targetParameters_SageMakerPipelineParameters != null)
            {
                request.TargetParameters.SageMakerPipelineParameters = requestTargetParameters_targetParameters_SageMakerPipelineParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetStateMachineParameters requestTargetParameters_targetParameters_StepFunctionStateMachineParameters = null;
            
             // populate StepFunctionStateMachineParameters
            var requestTargetParameters_targetParameters_StepFunctionStateMachineParametersIsNull = true;
            requestTargetParameters_targetParameters_StepFunctionStateMachineParameters = new Amazon.Pipes.Model.PipeTargetStateMachineParameters();
            Amazon.Pipes.PipeTargetInvocationType requestTargetParameters_targetParameters_StepFunctionStateMachineParameters_stepFunctionStateMachineParameters_InvocationType = null;
            if (cmdletContext.StepFunctionStateMachineParameters_InvocationType != null)
            {
                requestTargetParameters_targetParameters_StepFunctionStateMachineParameters_stepFunctionStateMachineParameters_InvocationType = cmdletContext.StepFunctionStateMachineParameters_InvocationType;
            }
            if (requestTargetParameters_targetParameters_StepFunctionStateMachineParameters_stepFunctionStateMachineParameters_InvocationType != null)
            {
                requestTargetParameters_targetParameters_StepFunctionStateMachineParameters.InvocationType = requestTargetParameters_targetParameters_StepFunctionStateMachineParameters_stepFunctionStateMachineParameters_InvocationType;
                requestTargetParameters_targetParameters_StepFunctionStateMachineParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_StepFunctionStateMachineParameters should be set to null
            if (requestTargetParameters_targetParameters_StepFunctionStateMachineParametersIsNull)
            {
                requestTargetParameters_targetParameters_StepFunctionStateMachineParameters = null;
            }
            if (requestTargetParameters_targetParameters_StepFunctionStateMachineParameters != null)
            {
                request.TargetParameters.StepFunctionStateMachineParameters = requestTargetParameters_targetParameters_StepFunctionStateMachineParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetCloudWatchLogsParameters requestTargetParameters_targetParameters_CloudWatchLogsParameters = null;
            
             // populate CloudWatchLogsParameters
            var requestTargetParameters_targetParameters_CloudWatchLogsParametersIsNull = true;
            requestTargetParameters_targetParameters_CloudWatchLogsParameters = new Amazon.Pipes.Model.PipeTargetCloudWatchLogsParameters();
            System.String requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_LogStreamName = null;
            if (cmdletContext.CloudWatchLogsParameters_LogStreamName != null)
            {
                requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_LogStreamName = cmdletContext.CloudWatchLogsParameters_LogStreamName;
            }
            if (requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_LogStreamName != null)
            {
                requestTargetParameters_targetParameters_CloudWatchLogsParameters.LogStreamName = requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_LogStreamName;
                requestTargetParameters_targetParameters_CloudWatchLogsParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_Timestamp = null;
            if (cmdletContext.CloudWatchLogsParameters_Timestamp != null)
            {
                requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_Timestamp = cmdletContext.CloudWatchLogsParameters_Timestamp;
            }
            if (requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_Timestamp != null)
            {
                requestTargetParameters_targetParameters_CloudWatchLogsParameters.Timestamp = requestTargetParameters_targetParameters_CloudWatchLogsParameters_cloudWatchLogsParameters_Timestamp;
                requestTargetParameters_targetParameters_CloudWatchLogsParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_CloudWatchLogsParameters should be set to null
            if (requestTargetParameters_targetParameters_CloudWatchLogsParametersIsNull)
            {
                requestTargetParameters_targetParameters_CloudWatchLogsParameters = null;
            }
            if (requestTargetParameters_targetParameters_CloudWatchLogsParameters != null)
            {
                request.TargetParameters.CloudWatchLogsParameters = requestTargetParameters_targetParameters_CloudWatchLogsParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetSqsQueueParameters requestTargetParameters_targetParameters_SqsQueueParameters = null;
            
             // populate SqsQueueParameters
            var requestTargetParameters_targetParameters_SqsQueueParametersIsNull = true;
            requestTargetParameters_targetParameters_SqsQueueParameters = new Amazon.Pipes.Model.PipeTargetSqsQueueParameters();
            System.String requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageDeduplicationId = null;
            if (cmdletContext.SqsQueueParameters_MessageDeduplicationId != null)
            {
                requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageDeduplicationId = cmdletContext.SqsQueueParameters_MessageDeduplicationId;
            }
            if (requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageDeduplicationId != null)
            {
                requestTargetParameters_targetParameters_SqsQueueParameters.MessageDeduplicationId = requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageDeduplicationId;
                requestTargetParameters_targetParameters_SqsQueueParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageGroupId = null;
            if (cmdletContext.SqsQueueParameters_MessageGroupId != null)
            {
                requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageGroupId = cmdletContext.SqsQueueParameters_MessageGroupId;
            }
            if (requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageGroupId != null)
            {
                requestTargetParameters_targetParameters_SqsQueueParameters.MessageGroupId = requestTargetParameters_targetParameters_SqsQueueParameters_sqsQueueParameters_MessageGroupId;
                requestTargetParameters_targetParameters_SqsQueueParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_SqsQueueParameters should be set to null
            if (requestTargetParameters_targetParameters_SqsQueueParametersIsNull)
            {
                requestTargetParameters_targetParameters_SqsQueueParameters = null;
            }
            if (requestTargetParameters_targetParameters_SqsQueueParameters != null)
            {
                request.TargetParameters.SqsQueueParameters = requestTargetParameters_targetParameters_SqsQueueParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetHttpParameters requestTargetParameters_targetParameters_HttpParameters = null;
            
             // populate HttpParameters
            var requestTargetParameters_targetParameters_HttpParametersIsNull = true;
            requestTargetParameters_targetParameters_HttpParameters = new Amazon.Pipes.Model.PipeTargetHttpParameters();
            Dictionary<System.String, System.String> requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_HeaderParameters = null;
            if (cmdletContext.TargetParameters_HttpParameters_HeaderParameters != null)
            {
                requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_HeaderParameters = cmdletContext.TargetParameters_HttpParameters_HeaderParameters;
            }
            if (requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_HeaderParameters != null)
            {
                requestTargetParameters_targetParameters_HttpParameters.HeaderParameters = requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_HeaderParameters;
                requestTargetParameters_targetParameters_HttpParametersIsNull = false;
            }
            List<System.String> requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_PathParameterValues = null;
            if (cmdletContext.TargetParameters_HttpParameters_PathParameterValues != null)
            {
                requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_PathParameterValues = cmdletContext.TargetParameters_HttpParameters_PathParameterValues;
            }
            if (requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_PathParameterValues != null)
            {
                requestTargetParameters_targetParameters_HttpParameters.PathParameterValues = requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_PathParameterValues;
                requestTargetParameters_targetParameters_HttpParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_QueryStringParameters = null;
            if (cmdletContext.TargetParameters_HttpParameters_QueryStringParameters != null)
            {
                requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_QueryStringParameters = cmdletContext.TargetParameters_HttpParameters_QueryStringParameters;
            }
            if (requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_QueryStringParameters != null)
            {
                requestTargetParameters_targetParameters_HttpParameters.QueryStringParameters = requestTargetParameters_targetParameters_HttpParameters_targetParameters_HttpParameters_QueryStringParameters;
                requestTargetParameters_targetParameters_HttpParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_HttpParameters should be set to null
            if (requestTargetParameters_targetParameters_HttpParametersIsNull)
            {
                requestTargetParameters_targetParameters_HttpParameters = null;
            }
            if (requestTargetParameters_targetParameters_HttpParameters != null)
            {
                request.TargetParameters.HttpParameters = requestTargetParameters_targetParameters_HttpParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetEventBridgeEventBusParameters requestTargetParameters_targetParameters_EventBridgeEventBusParameters = null;
            
             // populate EventBridgeEventBusParameters
            var requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull = true;
            requestTargetParameters_targetParameters_EventBridgeEventBusParameters = new Amazon.Pipes.Model.PipeTargetEventBridgeEventBusParameters();
            System.String requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_DetailType = null;
            if (cmdletContext.EventBridgeEventBusParameters_DetailType != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_DetailType = cmdletContext.EventBridgeEventBusParameters_DetailType;
            }
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_DetailType != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters.DetailType = requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_DetailType;
                requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_EndpointId = null;
            if (cmdletContext.EventBridgeEventBusParameters_EndpointId != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_EndpointId = cmdletContext.EventBridgeEventBusParameters_EndpointId;
            }
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_EndpointId != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters.EndpointId = requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_EndpointId;
                requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull = false;
            }
            List<System.String> requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Resource = null;
            if (cmdletContext.EventBridgeEventBusParameters_Resource != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Resource = cmdletContext.EventBridgeEventBusParameters_Resource;
            }
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Resource != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters.Resources = requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Resource;
                requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Source = null;
            if (cmdletContext.EventBridgeEventBusParameters_Source != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Source = cmdletContext.EventBridgeEventBusParameters_Source;
            }
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Source != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters.Source = requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Source;
                requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Time = null;
            if (cmdletContext.EventBridgeEventBusParameters_Time != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Time = cmdletContext.EventBridgeEventBusParameters_Time;
            }
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Time != null)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters.Time = requestTargetParameters_targetParameters_EventBridgeEventBusParameters_eventBridgeEventBusParameters_Time;
                requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_EventBridgeEventBusParameters should be set to null
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParametersIsNull)
            {
                requestTargetParameters_targetParameters_EventBridgeEventBusParameters = null;
            }
            if (requestTargetParameters_targetParameters_EventBridgeEventBusParameters != null)
            {
                request.TargetParameters.EventBridgeEventBusParameters = requestTargetParameters_targetParameters_EventBridgeEventBusParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetRedshiftDataParameters requestTargetParameters_targetParameters_RedshiftDataParameters = null;
            
             // populate RedshiftDataParameters
            var requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = true;
            requestTargetParameters_targetParameters_RedshiftDataParameters = new Amazon.Pipes.Model.PipeTargetRedshiftDataParameters();
            System.String requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Database = null;
            if (cmdletContext.RedshiftDataParameters_Database != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Database = cmdletContext.RedshiftDataParameters_Database;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Database != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters.Database = requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Database;
                requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_DbUser = null;
            if (cmdletContext.RedshiftDataParameters_DbUser != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_DbUser = cmdletContext.RedshiftDataParameters_DbUser;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_DbUser != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters.DbUser = requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_DbUser;
                requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_SecretManagerArn = null;
            if (cmdletContext.RedshiftDataParameters_SecretManagerArn != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_SecretManagerArn = cmdletContext.RedshiftDataParameters_SecretManagerArn;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_SecretManagerArn != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters.SecretManagerArn = requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_SecretManagerArn;
                requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = false;
            }
            List<System.String> requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Sql = null;
            if (cmdletContext.RedshiftDataParameters_Sql != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Sql = cmdletContext.RedshiftDataParameters_Sql;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Sql != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters.Sqls = requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_Sql;
                requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_StatementName = null;
            if (cmdletContext.RedshiftDataParameters_StatementName != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_StatementName = cmdletContext.RedshiftDataParameters_StatementName;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_StatementName != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters.StatementName = requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_StatementName;
                requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = false;
            }
            System.Boolean? requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_WithEvent = null;
            if (cmdletContext.RedshiftDataParameters_WithEvent != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_WithEvent = cmdletContext.RedshiftDataParameters_WithEvent.Value;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_WithEvent != null)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters.WithEvent = requestTargetParameters_targetParameters_RedshiftDataParameters_redshiftDataParameters_WithEvent.Value;
                requestTargetParameters_targetParameters_RedshiftDataParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_RedshiftDataParameters should be set to null
            if (requestTargetParameters_targetParameters_RedshiftDataParametersIsNull)
            {
                requestTargetParameters_targetParameters_RedshiftDataParameters = null;
            }
            if (requestTargetParameters_targetParameters_RedshiftDataParameters != null)
            {
                request.TargetParameters.RedshiftDataParameters = requestTargetParameters_targetParameters_RedshiftDataParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetBatchJobParameters requestTargetParameters_targetParameters_BatchJobParameters = null;
            
             // populate BatchJobParameters
            var requestTargetParameters_targetParameters_BatchJobParametersIsNull = true;
            requestTargetParameters_targetParameters_BatchJobParameters = new Amazon.Pipes.Model.PipeTargetBatchJobParameters();
            List<Amazon.Pipes.Model.BatchJobDependency> requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_DependsOn = null;
            if (cmdletContext.BatchJobParameters_DependsOn != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_DependsOn = cmdletContext.BatchJobParameters_DependsOn;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_DependsOn != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.DependsOn = requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_DependsOn;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobDefinition = null;
            if (cmdletContext.BatchJobParameters_JobDefinition != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobDefinition = cmdletContext.BatchJobParameters_JobDefinition;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobDefinition != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.JobDefinition = requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobDefinition;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobName = null;
            if (cmdletContext.BatchJobParameters_JobName != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobName = cmdletContext.BatchJobParameters_JobName;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobName != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.JobName = requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_JobName;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_Parameter = null;
            if (cmdletContext.BatchJobParameters_Parameter != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_Parameter = cmdletContext.BatchJobParameters_Parameter;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_Parameter != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.Parameters = requestTargetParameters_targetParameters_BatchJobParameters_batchJobParameters_Parameter;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
            Amazon.Pipes.Model.BatchArrayProperties requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties = null;
            
             // populate ArrayProperties
            var requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayPropertiesIsNull = true;
            requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties = new Amazon.Pipes.Model.BatchArrayProperties();
            System.Int32? requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties_arrayProperties_Size = null;
            if (cmdletContext.ArrayProperties_Size != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties_arrayProperties_Size = cmdletContext.ArrayProperties_Size.Value;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties_arrayProperties_Size != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties.Size = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties_arrayProperties_Size.Value;
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayPropertiesIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties should be set to null
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayPropertiesIsNull)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties = null;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.ArrayProperties = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ArrayProperties;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
            Amazon.Pipes.Model.BatchRetryStrategy requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy = null;
            
             // populate RetryStrategy
            var requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategyIsNull = true;
            requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy = new Amazon.Pipes.Model.BatchRetryStrategy();
            System.Int32? requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy_retryStrategy_Attempt = null;
            if (cmdletContext.RetryStrategy_Attempt != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy_retryStrategy_Attempt = cmdletContext.RetryStrategy_Attempt.Value;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy_retryStrategy_Attempt != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy.Attempts = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy_retryStrategy_Attempt.Value;
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategyIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy should be set to null
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategyIsNull)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy = null;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.RetryStrategy = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_RetryStrategy;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
            Amazon.Pipes.Model.BatchContainerOverrides requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides = null;
            
             // populate ContainerOverrides
            var requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverridesIsNull = true;
            requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides = new Amazon.Pipes.Model.BatchContainerOverrides();
            List<System.String> requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Command = null;
            if (cmdletContext.ContainerOverrides_Command != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Command = cmdletContext.ContainerOverrides_Command;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Command != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides.Command = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Command;
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverridesIsNull = false;
            }
            List<Amazon.Pipes.Model.BatchEnvironmentVariable> requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Environment = null;
            if (cmdletContext.ContainerOverrides_Environment != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Environment = cmdletContext.ContainerOverrides_Environment;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Environment != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides.Environment = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_Environment;
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverridesIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_InstanceType = null;
            if (cmdletContext.ContainerOverrides_InstanceType != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_InstanceType = cmdletContext.ContainerOverrides_InstanceType;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_InstanceType != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides.InstanceType = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_InstanceType;
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverridesIsNull = false;
            }
            List<Amazon.Pipes.Model.BatchResourceRequirement> requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_ResourceRequirement = null;
            if (cmdletContext.ContainerOverrides_ResourceRequirement != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_ResourceRequirement = cmdletContext.ContainerOverrides_ResourceRequirement;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_ResourceRequirement != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides.ResourceRequirements = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides_containerOverrides_ResourceRequirement;
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverridesIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides should be set to null
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverridesIsNull)
            {
                requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides = null;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides != null)
            {
                requestTargetParameters_targetParameters_BatchJobParameters.ContainerOverrides = requestTargetParameters_targetParameters_BatchJobParameters_targetParameters_BatchJobParameters_ContainerOverrides;
                requestTargetParameters_targetParameters_BatchJobParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_BatchJobParameters should be set to null
            if (requestTargetParameters_targetParameters_BatchJobParametersIsNull)
            {
                requestTargetParameters_targetParameters_BatchJobParameters = null;
            }
            if (requestTargetParameters_targetParameters_BatchJobParameters != null)
            {
                request.TargetParameters.BatchJobParameters = requestTargetParameters_targetParameters_BatchJobParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetTimestreamParameters requestTargetParameters_targetParameters_TimestreamParameters = null;
            
             // populate TimestreamParameters
            var requestTargetParameters_targetParameters_TimestreamParametersIsNull = true;
            requestTargetParameters_targetParameters_TimestreamParameters = new Amazon.Pipes.Model.PipeTargetTimestreamParameters();
            List<Amazon.Pipes.Model.DimensionMapping> requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_DimensionMapping = null;
            if (cmdletContext.TimestreamParameters_DimensionMapping != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_DimensionMapping = cmdletContext.TimestreamParameters_DimensionMapping;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_DimensionMapping != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.DimensionMappings = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_DimensionMapping;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            Amazon.Pipes.EpochTimeUnit requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_EpochTimeUnit = null;
            if (cmdletContext.TimestreamParameters_EpochTimeUnit != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_EpochTimeUnit = cmdletContext.TimestreamParameters_EpochTimeUnit;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_EpochTimeUnit != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.EpochTimeUnit = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_EpochTimeUnit;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            List<Amazon.Pipes.Model.MultiMeasureMapping> requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_MultiMeasureMapping = null;
            if (cmdletContext.TimestreamParameters_MultiMeasureMapping != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_MultiMeasureMapping = cmdletContext.TimestreamParameters_MultiMeasureMapping;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_MultiMeasureMapping != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.MultiMeasureMappings = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_MultiMeasureMapping;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            List<Amazon.Pipes.Model.SingleMeasureMapping> requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_SingleMeasureMapping = null;
            if (cmdletContext.TimestreamParameters_SingleMeasureMapping != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_SingleMeasureMapping = cmdletContext.TimestreamParameters_SingleMeasureMapping;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_SingleMeasureMapping != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.SingleMeasureMappings = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_SingleMeasureMapping;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            Amazon.Pipes.TimeFieldType requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeFieldType = null;
            if (cmdletContext.TimestreamParameters_TimeFieldType != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeFieldType = cmdletContext.TimestreamParameters_TimeFieldType;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeFieldType != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.TimeFieldType = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeFieldType;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimestampFormat = null;
            if (cmdletContext.TimestreamParameters_TimestampFormat != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimestampFormat = cmdletContext.TimestreamParameters_TimestampFormat;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimestampFormat != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.TimestampFormat = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimestampFormat;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeValue = null;
            if (cmdletContext.TimestreamParameters_TimeValue != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeValue = cmdletContext.TimestreamParameters_TimeValue;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeValue != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.TimeValue = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_TimeValue;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_VersionValue = null;
            if (cmdletContext.TimestreamParameters_VersionValue != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_VersionValue = cmdletContext.TimestreamParameters_VersionValue;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_VersionValue != null)
            {
                requestTargetParameters_targetParameters_TimestreamParameters.VersionValue = requestTargetParameters_targetParameters_TimestreamParameters_timestreamParameters_VersionValue;
                requestTargetParameters_targetParameters_TimestreamParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_TimestreamParameters should be set to null
            if (requestTargetParameters_targetParameters_TimestreamParametersIsNull)
            {
                requestTargetParameters_targetParameters_TimestreamParameters = null;
            }
            if (requestTargetParameters_targetParameters_TimestreamParameters != null)
            {
                request.TargetParameters.TimestreamParameters = requestTargetParameters_targetParameters_TimestreamParameters;
                requestTargetParametersIsNull = false;
            }
            Amazon.Pipes.Model.PipeTargetEcsTaskParameters requestTargetParameters_targetParameters_EcsTaskParameters = null;
            
             // populate EcsTaskParameters
            var requestTargetParameters_targetParameters_EcsTaskParametersIsNull = true;
            requestTargetParameters_targetParameters_EcsTaskParameters = new Amazon.Pipes.Model.PipeTargetEcsTaskParameters();
            List<Amazon.Pipes.Model.CapacityProviderStrategyItem> requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_CapacityProviderStrategy = null;
            if (cmdletContext.EcsTaskParameters_CapacityProviderStrategy != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_CapacityProviderStrategy = cmdletContext.EcsTaskParameters_CapacityProviderStrategy;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_CapacityProviderStrategy != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.CapacityProviderStrategy = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_CapacityProviderStrategy;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.Boolean? requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableECSManagedTag = null;
            if (cmdletContext.EcsTaskParameters_EnableECSManagedTag != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableECSManagedTag = cmdletContext.EcsTaskParameters_EnableECSManagedTag.Value;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableECSManagedTag != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.EnableECSManagedTags = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableECSManagedTag.Value;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.Boolean? requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableExecuteCommand = null;
            if (cmdletContext.EcsTaskParameters_EnableExecuteCommand != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableExecuteCommand = cmdletContext.EcsTaskParameters_EnableExecuteCommand.Value;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableExecuteCommand != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.EnableExecuteCommand = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_EnableExecuteCommand.Value;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Group = null;
            if (cmdletContext.EcsTaskParameters_Group != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Group = cmdletContext.EcsTaskParameters_Group;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Group != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.Group = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Group;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            Amazon.Pipes.LaunchType requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_LaunchType = null;
            if (cmdletContext.EcsTaskParameters_LaunchType != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_LaunchType = cmdletContext.EcsTaskParameters_LaunchType;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_LaunchType != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.LaunchType = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_LaunchType;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            List<Amazon.Pipes.Model.PlacementConstraint> requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementConstraint = null;
            if (cmdletContext.EcsTaskParameters_PlacementConstraint != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementConstraint = cmdletContext.EcsTaskParameters_PlacementConstraint;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementConstraint != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.PlacementConstraints = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementConstraint;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            List<Amazon.Pipes.Model.PlacementStrategy> requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementStrategy = null;
            if (cmdletContext.EcsTaskParameters_PlacementStrategy != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementStrategy = cmdletContext.EcsTaskParameters_PlacementStrategy;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementStrategy != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.PlacementStrategy = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlacementStrategy;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlatformVersion = null;
            if (cmdletContext.EcsTaskParameters_PlatformVersion != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlatformVersion = cmdletContext.EcsTaskParameters_PlatformVersion;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlatformVersion != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.PlatformVersion = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PlatformVersion;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            Amazon.Pipes.PropagateTags requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PropagateTag = null;
            if (cmdletContext.EcsTaskParameters_PropagateTag != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PropagateTag = cmdletContext.EcsTaskParameters_PropagateTag;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PropagateTag != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.PropagateTags = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_PropagateTag;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_ReferenceId = null;
            if (cmdletContext.EcsTaskParameters_ReferenceId != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_ReferenceId = cmdletContext.EcsTaskParameters_ReferenceId;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_ReferenceId != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.ReferenceId = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_ReferenceId;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            List<Amazon.Pipes.Model.Tag> requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Tag = null;
            if (cmdletContext.EcsTaskParameters_Tag != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Tag = cmdletContext.EcsTaskParameters_Tag;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Tag != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.Tags = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_Tag;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.Int32? requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskCount = null;
            if (cmdletContext.EcsTaskParameters_TaskCount != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskCount = cmdletContext.EcsTaskParameters_TaskCount.Value;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskCount != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.TaskCount = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskCount.Value;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskDefinitionArn = null;
            if (cmdletContext.EcsTaskParameters_TaskDefinitionArn != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskDefinitionArn = cmdletContext.EcsTaskParameters_TaskDefinitionArn;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskDefinitionArn != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.TaskDefinitionArn = requestTargetParameters_targetParameters_EcsTaskParameters_ecsTaskParameters_TaskDefinitionArn;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            Amazon.Pipes.Model.NetworkConfiguration requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfigurationIsNull = true;
            requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration = new Amazon.Pipes.Model.NetworkConfiguration();
            Amazon.Pipes.Model.AwsVpcConfiguration requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration = null;
            
             // populate AwsvpcConfiguration
            var requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = true;
            requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration = new Amazon.Pipes.Model.AwsVpcConfiguration();
            Amazon.Pipes.AssignPublicIp requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = null;
            if (cmdletContext.AwsvpcConfiguration_AssignPublicIp != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = cmdletContext.AwsvpcConfiguration_AssignPublicIp;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration.AssignPublicIp = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = null;
            if (cmdletContext.AwsvpcConfiguration_SecurityGroup != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = cmdletContext.AwsvpcConfiguration_SecurityGroup;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration.SecurityGroups = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = null;
            if (cmdletContext.AwsvpcConfiguration_Subnet != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = cmdletContext.AwsvpcConfiguration_Subnet;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration.Subnets = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration should be set to null
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfigurationIsNull)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration = null;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration.AwsvpcConfiguration = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration_targetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfigurationIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration should be set to null
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfigurationIsNull)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration = null;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.NetworkConfiguration = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_NetworkConfiguration;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
            Amazon.Pipes.Model.EcsTaskOverride requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides = null;
            
             // populate Overrides
            var requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = true;
            requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides = new Amazon.Pipes.Model.EcsTaskOverride();
            List<Amazon.Pipes.Model.EcsContainerOverride> requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ContainerOverride = null;
            if (cmdletContext.Overrides_ContainerOverride != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ContainerOverride = cmdletContext.Overrides_ContainerOverride;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ContainerOverride != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.ContainerOverrides = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ContainerOverride;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Cpu = null;
            if (cmdletContext.Overrides_Cpu != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Cpu = cmdletContext.Overrides_Cpu;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Cpu != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.Cpu = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Cpu;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ExecutionRoleArn = null;
            if (cmdletContext.Overrides_ExecutionRoleArn != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ExecutionRoleArn = cmdletContext.Overrides_ExecutionRoleArn;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ExecutionRoleArn != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.ExecutionRoleArn = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_ExecutionRoleArn;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
            List<Amazon.Pipes.Model.EcsInferenceAcceleratorOverride> requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_InferenceAcceleratorOverride = null;
            if (cmdletContext.Overrides_InferenceAcceleratorOverride != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_InferenceAcceleratorOverride = cmdletContext.Overrides_InferenceAcceleratorOverride;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_InferenceAcceleratorOverride != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.InferenceAcceleratorOverrides = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_InferenceAcceleratorOverride;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Memory = null;
            if (cmdletContext.Overrides_Memory != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Memory = cmdletContext.Overrides_Memory;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Memory != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.Memory = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_Memory;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
            System.String requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_TaskRoleArn = null;
            if (cmdletContext.Overrides_TaskRoleArn != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_TaskRoleArn = cmdletContext.Overrides_TaskRoleArn;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_TaskRoleArn != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.TaskRoleArn = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_overrides_TaskRoleArn;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
            Amazon.Pipes.Model.EcsEphemeralStorage requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage = null;
            
             // populate EphemeralStorage
            var requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorageIsNull = true;
            requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage = new Amazon.Pipes.Model.EcsEphemeralStorage();
            System.Int32? requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage_ephemeralStorage_SizeInGiB = null;
            if (cmdletContext.EphemeralStorage_SizeInGiB != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage_ephemeralStorage_SizeInGiB = cmdletContext.EphemeralStorage_SizeInGiB.Value;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage_ephemeralStorage_SizeInGiB != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage.SizeInGiB = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage_ephemeralStorage_SizeInGiB.Value;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorageIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage should be set to null
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorageIsNull)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage = null;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides.EphemeralStorage = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides_targetParameters_EcsTaskParameters_Overrides_EphemeralStorage;
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides should be set to null
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_OverridesIsNull)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides = null;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides != null)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters.Overrides = requestTargetParameters_targetParameters_EcsTaskParameters_targetParameters_EcsTaskParameters_Overrides;
                requestTargetParameters_targetParameters_EcsTaskParametersIsNull = false;
            }
             // determine if requestTargetParameters_targetParameters_EcsTaskParameters should be set to null
            if (requestTargetParameters_targetParameters_EcsTaskParametersIsNull)
            {
                requestTargetParameters_targetParameters_EcsTaskParameters = null;
            }
            if (requestTargetParameters_targetParameters_EcsTaskParameters != null)
            {
                request.TargetParameters.EcsTaskParameters = requestTargetParameters_targetParameters_EcsTaskParameters;
                requestTargetParametersIsNull = false;
            }
             // determine if request.TargetParameters should be set to null
            if (requestTargetParametersIsNull)
            {
                request.TargetParameters = null;
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
        
        private Amazon.Pipes.Model.UpdatePipeResponse CallAWSServiceOperation(IAmazonPipes client, Amazon.Pipes.Model.UpdatePipeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge Pipes", "UpdatePipe");
            try
            {
                #if DESKTOP
                return client.UpdatePipe(request);
                #elif CORECLR
                return client.UpdatePipeAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.Pipes.RequestedPipeState DesiredState { get; set; }
            public System.String Enrichment { get; set; }
            public Dictionary<System.String, System.String> EnrichmentParameters_HttpParameters_HeaderParameters { get; set; }
            public List<System.String> EnrichmentParameters_HttpParameters_PathParameterValues { get; set; }
            public Dictionary<System.String, System.String> EnrichmentParameters_HttpParameters_QueryStringParameters { get; set; }
            public System.String EnrichmentParameters_InputTemplate { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.String CloudwatchLogsLogDestination_LogGroupArn { get; set; }
            public System.String FirehoseLogDestination_DeliveryStreamArn { get; set; }
            public List<System.String> LogConfiguration_IncludeExecutionData { get; set; }
            public Amazon.Pipes.LogLevel LogConfiguration_Level { get; set; }
            public System.String S3LogDestination_BucketName { get; set; }
            public System.String S3LogDestination_BucketOwner { get; set; }
            public Amazon.Pipes.S3OutputFormat S3LogDestination_OutputFormat { get; set; }
            public System.String S3LogDestination_Prefix { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? ActiveMQBrokerParameters_BatchSize { get; set; }
            public System.String SourceParameters_ActiveMQBrokerParameters_Credentials_BasicAuth { get; set; }
            public System.Int32? ActiveMQBrokerParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? DynamoDBStreamParameters_BatchSize { get; set; }
            public System.String SourceParameters_DynamoDBStreamParameters_DeadLetterConfig_Arn { get; set; }
            public System.Int32? DynamoDBStreamParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? DynamoDBStreamParameters_MaximumRecordAgeInSecond { get; set; }
            public System.Int32? DynamoDBStreamParameters_MaximumRetryAttempt { get; set; }
            public Amazon.Pipes.OnPartialBatchItemFailureStreams DynamoDBStreamParameters_OnPartialBatchItemFailure { get; set; }
            public System.Int32? DynamoDBStreamParameters_ParallelizationFactor { get; set; }
            public List<Amazon.Pipes.Model.Filter> FilterCriteria_Filter { get; set; }
            public System.Int32? KinesisStreamParameters_BatchSize { get; set; }
            public System.String SourceParameters_KinesisStreamParameters_DeadLetterConfig_Arn { get; set; }
            public System.Int32? KinesisStreamParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? KinesisStreamParameters_MaximumRecordAgeInSecond { get; set; }
            public System.Int32? KinesisStreamParameters_MaximumRetryAttempt { get; set; }
            public Amazon.Pipes.OnPartialBatchItemFailureStreams KinesisStreamParameters_OnPartialBatchItemFailure { get; set; }
            public System.Int32? KinesisStreamParameters_ParallelizationFactor { get; set; }
            public System.Int32? ManagedStreamingKafkaParameters_BatchSize { get; set; }
            public System.String SourceParameters_ManagedStreamingKafkaParameters_Credentials_ClientCertificateTlsAuth { get; set; }
            public System.String SourceParameters_ManagedStreamingKafkaParameters_Credentials_SaslScram512Auth { get; set; }
            public System.Int32? ManagedStreamingKafkaParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? RabbitMQBrokerParameters_BatchSize { get; set; }
            public System.String SourceParameters_RabbitMQBrokerParameters_Credentials_BasicAuth { get; set; }
            public System.Int32? RabbitMQBrokerParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.Int32? SelfManagedKafkaParameters_BatchSize { get; set; }
            public System.String SourceParameters_SelfManagedKafkaParameters_Credentials_BasicAuth { get; set; }
            public System.String SourceParameters_SelfManagedKafkaParameters_Credentials_ClientCertificateTlsAuth { get; set; }
            public System.String Credentials_SaslScram256Auth { get; set; }
            public System.String Credentials_SaslScram512Auth { get; set; }
            public System.Int32? SelfManagedKafkaParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.String SelfManagedKafkaParameters_ServerRootCaCertificate { get; set; }
            public List<System.String> Vpc_SecurityGroup { get; set; }
            public List<System.String> Vpc_Subnet { get; set; }
            public System.Int32? SqsQueueParameters_BatchSize { get; set; }
            public System.Int32? SqsQueueParameters_MaximumBatchingWindowInSecond { get; set; }
            public System.String Target { get; set; }
            public System.Int32? ArrayProperties_Size { get; set; }
            public List<System.String> ContainerOverrides_Command { get; set; }
            public List<Amazon.Pipes.Model.BatchEnvironmentVariable> ContainerOverrides_Environment { get; set; }
            public System.String ContainerOverrides_InstanceType { get; set; }
            public List<Amazon.Pipes.Model.BatchResourceRequirement> ContainerOverrides_ResourceRequirement { get; set; }
            public List<Amazon.Pipes.Model.BatchJobDependency> BatchJobParameters_DependsOn { get; set; }
            public System.String BatchJobParameters_JobDefinition { get; set; }
            public System.String BatchJobParameters_JobName { get; set; }
            public Dictionary<System.String, System.String> BatchJobParameters_Parameter { get; set; }
            public System.Int32? RetryStrategy_Attempt { get; set; }
            public System.String CloudWatchLogsParameters_LogStreamName { get; set; }
            public System.String CloudWatchLogsParameters_Timestamp { get; set; }
            public List<Amazon.Pipes.Model.CapacityProviderStrategyItem> EcsTaskParameters_CapacityProviderStrategy { get; set; }
            public System.Boolean? EcsTaskParameters_EnableECSManagedTag { get; set; }
            public System.Boolean? EcsTaskParameters_EnableExecuteCommand { get; set; }
            public System.String EcsTaskParameters_Group { get; set; }
            public Amazon.Pipes.LaunchType EcsTaskParameters_LaunchType { get; set; }
            public Amazon.Pipes.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.Pipes.Model.EcsContainerOverride> Overrides_ContainerOverride { get; set; }
            public System.String Overrides_Cpu { get; set; }
            public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
            public System.String Overrides_ExecutionRoleArn { get; set; }
            public List<Amazon.Pipes.Model.EcsInferenceAcceleratorOverride> Overrides_InferenceAcceleratorOverride { get; set; }
            public System.String Overrides_Memory { get; set; }
            public System.String Overrides_TaskRoleArn { get; set; }
            public List<Amazon.Pipes.Model.PlacementConstraint> EcsTaskParameters_PlacementConstraint { get; set; }
            public List<Amazon.Pipes.Model.PlacementStrategy> EcsTaskParameters_PlacementStrategy { get; set; }
            public System.String EcsTaskParameters_PlatformVersion { get; set; }
            public Amazon.Pipes.PropagateTags EcsTaskParameters_PropagateTag { get; set; }
            public System.String EcsTaskParameters_ReferenceId { get; set; }
            public List<Amazon.Pipes.Model.Tag> EcsTaskParameters_Tag { get; set; }
            public System.Int32? EcsTaskParameters_TaskCount { get; set; }
            public System.String EcsTaskParameters_TaskDefinitionArn { get; set; }
            public System.String EventBridgeEventBusParameters_DetailType { get; set; }
            public System.String EventBridgeEventBusParameters_EndpointId { get; set; }
            public List<System.String> EventBridgeEventBusParameters_Resource { get; set; }
            public System.String EventBridgeEventBusParameters_Source { get; set; }
            public System.String EventBridgeEventBusParameters_Time { get; set; }
            public Dictionary<System.String, System.String> TargetParameters_HttpParameters_HeaderParameters { get; set; }
            public List<System.String> TargetParameters_HttpParameters_PathParameterValues { get; set; }
            public Dictionary<System.String, System.String> TargetParameters_HttpParameters_QueryStringParameters { get; set; }
            public System.String TargetParameters_InputTemplate { get; set; }
            public System.String KinesisStreamParameters_PartitionKey { get; set; }
            public Amazon.Pipes.PipeTargetInvocationType LambdaFunctionParameters_InvocationType { get; set; }
            public System.String RedshiftDataParameters_Database { get; set; }
            public System.String RedshiftDataParameters_DbUser { get; set; }
            public System.String RedshiftDataParameters_SecretManagerArn { get; set; }
            public List<System.String> RedshiftDataParameters_Sql { get; set; }
            public System.String RedshiftDataParameters_StatementName { get; set; }
            public System.Boolean? RedshiftDataParameters_WithEvent { get; set; }
            public List<Amazon.Pipes.Model.SageMakerPipelineParameter> SageMakerPipelineParameters_PipelineParameterList { get; set; }
            public System.String SqsQueueParameters_MessageDeduplicationId { get; set; }
            public System.String SqsQueueParameters_MessageGroupId { get; set; }
            public Amazon.Pipes.PipeTargetInvocationType StepFunctionStateMachineParameters_InvocationType { get; set; }
            public List<Amazon.Pipes.Model.DimensionMapping> TimestreamParameters_DimensionMapping { get; set; }
            public Amazon.Pipes.EpochTimeUnit TimestreamParameters_EpochTimeUnit { get; set; }
            public List<Amazon.Pipes.Model.MultiMeasureMapping> TimestreamParameters_MultiMeasureMapping { get; set; }
            public List<Amazon.Pipes.Model.SingleMeasureMapping> TimestreamParameters_SingleMeasureMapping { get; set; }
            public Amazon.Pipes.TimeFieldType TimestreamParameters_TimeFieldType { get; set; }
            public System.String TimestreamParameters_TimestampFormat { get; set; }
            public System.String TimestreamParameters_TimeValue { get; set; }
            public System.String TimestreamParameters_VersionValue { get; set; }
            public System.Func<Amazon.Pipes.Model.UpdatePipeResponse, UpdatePIPESPipeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
