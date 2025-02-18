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
using Amazon.Scheduler;
using Amazon.Scheduler.Model;

namespace Amazon.PowerShell.Cmdlets.SCH
{
    /// <summary>
    /// Updates the specified schedule. When you call <c>UpdateSchedule</c>, EventBridge
    /// Scheduler uses all values, including empty values, specified in the request and overrides
    /// the existing schedule. This is by design. This means that if you do not set an optional
    /// field in your request, that field will be set to its system-default value after the
    /// update. 
    /// 
    ///  
    /// <para>
    ///  Before calling this operation, we recommend that you call the <c>GetSchedule</c>
    /// API operation and make a note of all optional parameters for your <c>UpdateSchedule</c>
    /// call. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SCHSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EventBridge Scheduler UpdateSchedule API operation.", Operation = new[] {"UpdateSchedule"}, SelectReturnType = typeof(Amazon.Scheduler.Model.UpdateScheduleResponse))]
    [AWSCmdletOutput("System.String or Amazon.Scheduler.Model.UpdateScheduleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Scheduler.Model.UpdateScheduleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSCHScheduleCmdlet : AmazonSchedulerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionAfterCompletion
        /// <summary>
        /// <para>
        /// <para>Specifies the action that EventBridge Scheduler applies to the schedule after the
        /// schedule completes invoking the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Scheduler.ActionAfterCompletion")]
        public Amazon.Scheduler.ActionAfterCompletion ActionAfterCompletion { get; set; }
        #endregion
        
        #region Parameter Target_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target.</para>
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
        public System.String Target_Arn { get; set; }
        #endregion
        
        #region Parameter DeadLetterConfig_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SQS queue specified as the destination for the
        /// dead-letter queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_DeadLetterConfig_Arn")]
        public System.String DeadLetterConfig_Arn { get; set; }
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
        [Alias("Target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.Scheduler.AssignPublicIp")]
        public Amazon.Scheduler.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter EcsParameters_CapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to use for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_CapacityProviderStrategy")]
        public Amazon.Scheduler.Model.CapacityProviderStrategyItem[] EcsParameters_CapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description you specify for the schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBridgeParameters_DetailType
        /// <summary>
        /// <para>
        /// <para>A free-form string, with a maximum of 128 characters, used to decide what fields to
        /// expect in the event detail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EventBridgeParameters_DetailType")]
        public System.String EventBridgeParameters_DetailType { get; set; }
        #endregion
        
        #region Parameter EcsParameters_EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Amazon ECS managed tags for the task. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the <i>Amazon ECS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_EnableECSManagedTags")]
        public System.Boolean? EcsParameters_EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter EcsParameters_EnableExecuteCommand
        /// <summary>
        /// <para>
        /// <para>Whether or not to enable the execute command functionality for the containers in this
        /// task. If true, this enables execute command functionality on all containers in the
        /// task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_EnableExecuteCommand")]
        public System.Boolean? EcsParameters_EnableExecuteCommand { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date, in UTC, before which the schedule can invoke its target. Depending on the
        /// schedule's recurrence expression, invocations might stop on, or before, the <c>EndDate</c>
        /// you specify. EventBridge Scheduler ignores <c>EndDate</c> for one-time schedules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter EcsParameters_Group
        /// <summary>
        /// <para>
        /// <para>Specifies an ECS task group for the task. The maximum length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_Group")]
        public System.String EcsParameters_Group { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the schedule group with which the schedule is associated. You must provide
        /// this value in order for EventBridge Scheduler to find the schedule you want to update.
        /// If you omit this value, EventBridge Scheduler assumes the group is associated to the
        /// default group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter Target_Input
        /// <summary>
        /// <para>
        /// <para>The text, or well-formed JSON, passed to the target. If you are configuring a templated
        /// Lambda, AWS Step Functions, or Amazon EventBridge target, the input must be a well-formed
        /// JSON. For all other target types, a JSON is not required. If you do not specify anything
        /// for this field, EventBridge Scheduler delivers a default notification to the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_Input { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the customer managed KMS key that that you want EventBridge Scheduler
        /// to use to encrypt and decrypt your data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter EcsParameters_LaunchType
        /// <summary>
        /// <para>
        /// <para>Specifies the launch type on which your task is running. The launch type that you
        /// specify here must match one of the launch type (compatibilities) of the target task.
        /// The <c>FARGATE</c> value is supported only in the Regions where Fargate with Amazon
        /// ECS is supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/AWS_Fargate.html">AWS
        /// Fargate on Amazon ECS</a> in the <i>Amazon ECS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_LaunchType")]
        [AWSConstantClassSource("Amazon.Scheduler.LaunchType")]
        public Amazon.Scheduler.LaunchType EcsParameters_LaunchType { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_MaximumEventAgeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, to continue to make retry attempts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_RetryPolicy_MaximumEventAgeInSeconds")]
        public System.Int32? RetryPolicy_MaximumEventAgeInSecond { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_MaximumRetryAttempt
        /// <summary>
        /// <para>
        /// <para>The maximum number of retry attempts to make before the request fails. Retry attempts
        /// with exponential backoff continue until either the maximum number of attempts is made
        /// or until the duration of the <c>MaximumEventAgeInSeconds</c> is reached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_RetryPolicy_MaximumRetryAttempts")]
        public System.Int32? RetryPolicy_MaximumRetryAttempt { get; set; }
        #endregion
        
        #region Parameter FlexibleTimeWindow_MaximumWindowInMinute
        /// <summary>
        /// <para>
        /// <para>The maximum time window during which a schedule can be invoked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlexibleTimeWindow_MaximumWindowInMinutes")]
        public System.Int32? FlexibleTimeWindow_MaximumWindowInMinute { get; set; }
        #endregion
        
        #region Parameter SqsParameters_MessageGroupId
        /// <summary>
        /// <para>
        /// <para>The FIFO message group ID to use as the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_SqsParameters_MessageGroupId")]
        public System.String SqsParameters_MessageGroupId { get; set; }
        #endregion
        
        #region Parameter FlexibleTimeWindow_Mode
        /// <summary>
        /// <para>
        /// <para>Determines whether the schedule is invoked within a flexible time window.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Scheduler.FlexibleTimeWindowMode")]
        public Amazon.Scheduler.FlexibleTimeWindowMode FlexibleTimeWindow_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the schedule that you are updating.</para>
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
        
        #region Parameter KinesisParameters_PartitionKey
        /// <summary>
        /// <para>
        /// <para>Specifies the shard to which EventBridge Scheduler sends the event. For more information,
        /// see <a href="https://docs.aws.amazon.com/streams/latest/dev/key-concepts.html">Amazon
        /// Kinesis Data Streams terminology and concepts</a> in the <i>Amazon Kinesis Streams
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_KinesisParameters_PartitionKey")]
        public System.String KinesisParameters_PartitionKey { get; set; }
        #endregion
        
        #region Parameter SageMakerPipelineParameters_PipelineParameterList
        /// <summary>
        /// <para>
        /// <para>List of parameter names and values to use when executing the SageMaker Model Building
        /// Pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_SageMakerPipelineParameters_PipelineParameterList")]
        public Amazon.Scheduler.Model.SageMakerPipelineParameter[] SageMakerPipelineParameters_PipelineParameterList { get; set; }
        #endregion
        
        #region Parameter EcsParameters_PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for the task. You can specify up to
        /// 10 constraints per task (including constraints in the task definition and those specified
        /// at runtime).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_PlacementConstraints")]
        public Amazon.Scheduler.Model.PlacementConstraint[] EcsParameters_PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter EcsParameters_PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The task placement strategy for a task or service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_PlacementStrategy")]
        public Amazon.Scheduler.Model.PlacementStrategy[] EcsParameters_PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter EcsParameters_PlatformVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the platform version for the task. Specify only the numeric portion of the
        /// platform version, such as <c>1.1.0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_PlatformVersion")]
        public System.String EcsParameters_PlatformVersion { get; set; }
        #endregion
        
        #region Parameter EcsParameters_PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the task definition to the task. If no
        /// value is specified, the tags are not propagated. Tags can only be propagated to the
        /// task during task creation. To add tags to a task after task creation, use Amazon ECS's
        /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_TagResource.html"><c>TagResource</c></a> API action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_PropagateTags")]
        [AWSConstantClassSource("Amazon.Scheduler.PropagateTags")]
        public Amazon.Scheduler.PropagateTags EcsParameters_PropagateTag { get; set; }
        #endregion
        
        #region Parameter EcsParameters_ReferenceId
        /// <summary>
        /// <para>
        /// <para>The reference ID to use for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_ReferenceId")]
        public System.String EcsParameters_ReferenceId { get; set; }
        #endregion
        
        #region Parameter Target_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that EventBridge Scheduler will use
        /// for this target when the schedule is invoked.</para>
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
        public System.String Target_RoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para> The expression that defines when the schedule runs. The following formats are supported.
        /// </para><ul><li><para><c>at</c> expression - <c>at(yyyy-mm-ddThh:mm:ss)</c></para></li><li><para><c>rate</c> expression - <c>rate(value unit)</c></para></li><li><para><c>cron</c> expression - <c>cron(fields)</c></para></li></ul><para> You can use <c>at</c> expressions to create one-time schedules that invoke a target
        /// once, at the time and in the time zone, that you specify. You can use <c>rate</c>
        /// and <c>cron</c> expressions to create recurring schedules. Rate-based schedules are
        /// useful when you want to invoke a target at regular intervals, such as every 15 minutes
        /// or every five days. Cron-based schedules are useful when you want to invoke a target
        /// periodically at a specific time, such as at 8:00 am (UTC+0) every 1st day of the month.
        /// </para><para> A <c>cron</c> expression consists of six fields separated by white spaces: <c>(minutes
        /// hours day_of_month month day_of_week year)</c>. </para><para> A <c>rate</c> expression consists of a <i>value</i> as a positive integer, and a
        /// <i>unit</i> with the following options: <c>minute</c> | <c>minutes</c> | <c>hour</c>
        /// | <c>hours</c> | <c>day</c> | <c>days</c></para><para> For more information and examples, see <a href="https://docs.aws.amazon.com/scheduler/latest/UserGuide/schedule-types.html">Schedule
        /// types on EventBridge Scheduler</a> in the <i>EventBridge Scheduler User Guide</i>.
        /// </para>
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
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter ScheduleExpressionTimezone
        /// <summary>
        /// <para>
        /// <para>The timezone in which the scheduling expression is evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleExpressionTimezone { get; set; }
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
        [Alias("Target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter EventBridgeParameters_Source
        /// <summary>
        /// <para>
        /// <para>The source of the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EventBridgeParameters_Source")]
        public System.String EventBridgeParameters_Source { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The date, in UTC, after which the schedule can begin invoking its target. Depending
        /// on the schedule's recurrence expression, invocations might occur on, or after, the
        /// <c>StartDate</c> you specify. EventBridge Scheduler ignores <c>StartDate</c> for one-time
        /// schedules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Specifies whether the schedule is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Scheduler.ScheduleState")]
        public Amazon.Scheduler.ScheduleState State { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>Specifies the subnets associated with the task. These subnets must all be in the same
        /// VPC. You can specify as many as 16 subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_Subnets")]
        public System.String[] AwsvpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter EcsParameters_Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_RunTask.html"><c>RunTask</c></a> in the <i>Amazon ECS API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_Tags")]
        public System.Collections.Hashtable[] EcsParameters_Tag { get; set; }
        #endregion
        
        #region Parameter EcsParameters_TaskCount
        /// <summary>
        /// <para>
        /// <para>The number of tasks to create based on <c>TaskDefinition</c>. The default is <c>1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_TaskCount")]
        public System.Int32? EcsParameters_TaskCount { get; set; }
        #endregion
        
        #region Parameter EcsParameters_TaskDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task definition to use if the event target is
        /// an Amazon ECS task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_EcsParameters_TaskDefinitionArn")]
        public System.String EcsParameters_TaskDefinitionArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// If you do not specify a client token, EventBridge Scheduler uses a randomly generated
        /// token for the request to ensure idempotency. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Scheduler.Model.UpdateScheduleResponse).
        /// Specifying the name of a property of type Amazon.Scheduler.Model.UpdateScheduleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduleArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SCHSchedule (UpdateSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Scheduler.Model.UpdateScheduleResponse, UpdateSCHScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionAfterCompletion = this.ActionAfterCompletion;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EndDate = this.EndDate;
            context.FlexibleTimeWindow_MaximumWindowInMinute = this.FlexibleTimeWindow_MaximumWindowInMinute;
            context.FlexibleTimeWindow_Mode = this.FlexibleTimeWindow_Mode;
            #if MODULAR
            if (this.FlexibleTimeWindow_Mode == null && ParameterWasBound(nameof(this.FlexibleTimeWindow_Mode)))
            {
                WriteWarning("You are passing $null as a value for parameter FlexibleTimeWindow_Mode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupName = this.GroupName;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleExpression = this.ScheduleExpression;
            #if MODULAR
            if (this.ScheduleExpression == null && ParameterWasBound(nameof(this.ScheduleExpression)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleExpression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleExpressionTimezone = this.ScheduleExpressionTimezone;
            context.StartDate = this.StartDate;
            context.State = this.State;
            context.Target_Arn = this.Target_Arn;
            #if MODULAR
            if (this.Target_Arn == null && ParameterWasBound(nameof(this.Target_Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeadLetterConfig_Arn = this.DeadLetterConfig_Arn;
            if (this.EcsParameters_CapacityProviderStrategy != null)
            {
                context.EcsParameters_CapacityProviderStrategy = new List<Amazon.Scheduler.Model.CapacityProviderStrategyItem>(this.EcsParameters_CapacityProviderStrategy);
            }
            context.EcsParameters_EnableECSManagedTag = this.EcsParameters_EnableECSManagedTag;
            context.EcsParameters_EnableExecuteCommand = this.EcsParameters_EnableExecuteCommand;
            context.EcsParameters_Group = this.EcsParameters_Group;
            context.EcsParameters_LaunchType = this.EcsParameters_LaunchType;
            context.AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.AwsvpcConfiguration_SecurityGroup = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.AwsvpcConfiguration_Subnet = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.EcsParameters_PlacementConstraint != null)
            {
                context.EcsParameters_PlacementConstraint = new List<Amazon.Scheduler.Model.PlacementConstraint>(this.EcsParameters_PlacementConstraint);
            }
            if (this.EcsParameters_PlacementStrategy != null)
            {
                context.EcsParameters_PlacementStrategy = new List<Amazon.Scheduler.Model.PlacementStrategy>(this.EcsParameters_PlacementStrategy);
            }
            context.EcsParameters_PlatformVersion = this.EcsParameters_PlatformVersion;
            context.EcsParameters_PropagateTag = this.EcsParameters_PropagateTag;
            context.EcsParameters_ReferenceId = this.EcsParameters_ReferenceId;
            if (this.EcsParameters_Tag != null)
            {
                context.EcsParameters_Tag = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.EcsParameters_Tag)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.EcsParameters_Tag.Add(d);
                }
            }
            context.EcsParameters_TaskCount = this.EcsParameters_TaskCount;
            context.EcsParameters_TaskDefinitionArn = this.EcsParameters_TaskDefinitionArn;
            context.EventBridgeParameters_DetailType = this.EventBridgeParameters_DetailType;
            context.EventBridgeParameters_Source = this.EventBridgeParameters_Source;
            context.Target_Input = this.Target_Input;
            context.KinesisParameters_PartitionKey = this.KinesisParameters_PartitionKey;
            context.RetryPolicy_MaximumEventAgeInSecond = this.RetryPolicy_MaximumEventAgeInSecond;
            context.RetryPolicy_MaximumRetryAttempt = this.RetryPolicy_MaximumRetryAttempt;
            context.Target_RoleArn = this.Target_RoleArn;
            #if MODULAR
            if (this.Target_RoleArn == null && ParameterWasBound(nameof(this.Target_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SageMakerPipelineParameters_PipelineParameterList != null)
            {
                context.SageMakerPipelineParameters_PipelineParameterList = new List<Amazon.Scheduler.Model.SageMakerPipelineParameter>(this.SageMakerPipelineParameters_PipelineParameterList);
            }
            context.SqsParameters_MessageGroupId = this.SqsParameters_MessageGroupId;
            
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
            var request = new Amazon.Scheduler.Model.UpdateScheduleRequest();
            
            if (cmdletContext.ActionAfterCompletion != null)
            {
                request.ActionAfterCompletion = cmdletContext.ActionAfterCompletion;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            
             // populate FlexibleTimeWindow
            var requestFlexibleTimeWindowIsNull = true;
            request.FlexibleTimeWindow = new Amazon.Scheduler.Model.FlexibleTimeWindow();
            System.Int32? requestFlexibleTimeWindow_flexibleTimeWindow_MaximumWindowInMinute = null;
            if (cmdletContext.FlexibleTimeWindow_MaximumWindowInMinute != null)
            {
                requestFlexibleTimeWindow_flexibleTimeWindow_MaximumWindowInMinute = cmdletContext.FlexibleTimeWindow_MaximumWindowInMinute.Value;
            }
            if (requestFlexibleTimeWindow_flexibleTimeWindow_MaximumWindowInMinute != null)
            {
                request.FlexibleTimeWindow.MaximumWindowInMinutes = requestFlexibleTimeWindow_flexibleTimeWindow_MaximumWindowInMinute.Value;
                requestFlexibleTimeWindowIsNull = false;
            }
            Amazon.Scheduler.FlexibleTimeWindowMode requestFlexibleTimeWindow_flexibleTimeWindow_Mode = null;
            if (cmdletContext.FlexibleTimeWindow_Mode != null)
            {
                requestFlexibleTimeWindow_flexibleTimeWindow_Mode = cmdletContext.FlexibleTimeWindow_Mode;
            }
            if (requestFlexibleTimeWindow_flexibleTimeWindow_Mode != null)
            {
                request.FlexibleTimeWindow.Mode = requestFlexibleTimeWindow_flexibleTimeWindow_Mode;
                requestFlexibleTimeWindowIsNull = false;
            }
             // determine if request.FlexibleTimeWindow should be set to null
            if (requestFlexibleTimeWindowIsNull)
            {
                request.FlexibleTimeWindow = null;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.ScheduleExpressionTimezone != null)
            {
                request.ScheduleExpressionTimezone = cmdletContext.ScheduleExpressionTimezone;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.Scheduler.Model.Target();
            System.String requestTarget_target_Arn = null;
            if (cmdletContext.Target_Arn != null)
            {
                requestTarget_target_Arn = cmdletContext.Target_Arn;
            }
            if (requestTarget_target_Arn != null)
            {
                request.Target.Arn = requestTarget_target_Arn;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_Input = null;
            if (cmdletContext.Target_Input != null)
            {
                requestTarget_target_Input = cmdletContext.Target_Input;
            }
            if (requestTarget_target_Input != null)
            {
                request.Target.Input = requestTarget_target_Input;
                requestTargetIsNull = false;
            }
            System.String requestTarget_target_RoleArn = null;
            if (cmdletContext.Target_RoleArn != null)
            {
                requestTarget_target_RoleArn = cmdletContext.Target_RoleArn;
            }
            if (requestTarget_target_RoleArn != null)
            {
                request.Target.RoleArn = requestTarget_target_RoleArn;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.DeadLetterConfig requestTarget_target_DeadLetterConfig = null;
            
             // populate DeadLetterConfig
            var requestTarget_target_DeadLetterConfigIsNull = true;
            requestTarget_target_DeadLetterConfig = new Amazon.Scheduler.Model.DeadLetterConfig();
            System.String requestTarget_target_DeadLetterConfig_deadLetterConfig_Arn = null;
            if (cmdletContext.DeadLetterConfig_Arn != null)
            {
                requestTarget_target_DeadLetterConfig_deadLetterConfig_Arn = cmdletContext.DeadLetterConfig_Arn;
            }
            if (requestTarget_target_DeadLetterConfig_deadLetterConfig_Arn != null)
            {
                requestTarget_target_DeadLetterConfig.Arn = requestTarget_target_DeadLetterConfig_deadLetterConfig_Arn;
                requestTarget_target_DeadLetterConfigIsNull = false;
            }
             // determine if requestTarget_target_DeadLetterConfig should be set to null
            if (requestTarget_target_DeadLetterConfigIsNull)
            {
                requestTarget_target_DeadLetterConfig = null;
            }
            if (requestTarget_target_DeadLetterConfig != null)
            {
                request.Target.DeadLetterConfig = requestTarget_target_DeadLetterConfig;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.KinesisParameters requestTarget_target_KinesisParameters = null;
            
             // populate KinesisParameters
            var requestTarget_target_KinesisParametersIsNull = true;
            requestTarget_target_KinesisParameters = new Amazon.Scheduler.Model.KinesisParameters();
            System.String requestTarget_target_KinesisParameters_kinesisParameters_PartitionKey = null;
            if (cmdletContext.KinesisParameters_PartitionKey != null)
            {
                requestTarget_target_KinesisParameters_kinesisParameters_PartitionKey = cmdletContext.KinesisParameters_PartitionKey;
            }
            if (requestTarget_target_KinesisParameters_kinesisParameters_PartitionKey != null)
            {
                requestTarget_target_KinesisParameters.PartitionKey = requestTarget_target_KinesisParameters_kinesisParameters_PartitionKey;
                requestTarget_target_KinesisParametersIsNull = false;
            }
             // determine if requestTarget_target_KinesisParameters should be set to null
            if (requestTarget_target_KinesisParametersIsNull)
            {
                requestTarget_target_KinesisParameters = null;
            }
            if (requestTarget_target_KinesisParameters != null)
            {
                request.Target.KinesisParameters = requestTarget_target_KinesisParameters;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.SageMakerPipelineParameters requestTarget_target_SageMakerPipelineParameters = null;
            
             // populate SageMakerPipelineParameters
            var requestTarget_target_SageMakerPipelineParametersIsNull = true;
            requestTarget_target_SageMakerPipelineParameters = new Amazon.Scheduler.Model.SageMakerPipelineParameters();
            List<Amazon.Scheduler.Model.SageMakerPipelineParameter> requestTarget_target_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList = null;
            if (cmdletContext.SageMakerPipelineParameters_PipelineParameterList != null)
            {
                requestTarget_target_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList = cmdletContext.SageMakerPipelineParameters_PipelineParameterList;
            }
            if (requestTarget_target_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList != null)
            {
                requestTarget_target_SageMakerPipelineParameters.PipelineParameterList = requestTarget_target_SageMakerPipelineParameters_sageMakerPipelineParameters_PipelineParameterList;
                requestTarget_target_SageMakerPipelineParametersIsNull = false;
            }
             // determine if requestTarget_target_SageMakerPipelineParameters should be set to null
            if (requestTarget_target_SageMakerPipelineParametersIsNull)
            {
                requestTarget_target_SageMakerPipelineParameters = null;
            }
            if (requestTarget_target_SageMakerPipelineParameters != null)
            {
                request.Target.SageMakerPipelineParameters = requestTarget_target_SageMakerPipelineParameters;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.SqsParameters requestTarget_target_SqsParameters = null;
            
             // populate SqsParameters
            var requestTarget_target_SqsParametersIsNull = true;
            requestTarget_target_SqsParameters = new Amazon.Scheduler.Model.SqsParameters();
            System.String requestTarget_target_SqsParameters_sqsParameters_MessageGroupId = null;
            if (cmdletContext.SqsParameters_MessageGroupId != null)
            {
                requestTarget_target_SqsParameters_sqsParameters_MessageGroupId = cmdletContext.SqsParameters_MessageGroupId;
            }
            if (requestTarget_target_SqsParameters_sqsParameters_MessageGroupId != null)
            {
                requestTarget_target_SqsParameters.MessageGroupId = requestTarget_target_SqsParameters_sqsParameters_MessageGroupId;
                requestTarget_target_SqsParametersIsNull = false;
            }
             // determine if requestTarget_target_SqsParameters should be set to null
            if (requestTarget_target_SqsParametersIsNull)
            {
                requestTarget_target_SqsParameters = null;
            }
            if (requestTarget_target_SqsParameters != null)
            {
                request.Target.SqsParameters = requestTarget_target_SqsParameters;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.EventBridgeParameters requestTarget_target_EventBridgeParameters = null;
            
             // populate EventBridgeParameters
            var requestTarget_target_EventBridgeParametersIsNull = true;
            requestTarget_target_EventBridgeParameters = new Amazon.Scheduler.Model.EventBridgeParameters();
            System.String requestTarget_target_EventBridgeParameters_eventBridgeParameters_DetailType = null;
            if (cmdletContext.EventBridgeParameters_DetailType != null)
            {
                requestTarget_target_EventBridgeParameters_eventBridgeParameters_DetailType = cmdletContext.EventBridgeParameters_DetailType;
            }
            if (requestTarget_target_EventBridgeParameters_eventBridgeParameters_DetailType != null)
            {
                requestTarget_target_EventBridgeParameters.DetailType = requestTarget_target_EventBridgeParameters_eventBridgeParameters_DetailType;
                requestTarget_target_EventBridgeParametersIsNull = false;
            }
            System.String requestTarget_target_EventBridgeParameters_eventBridgeParameters_Source = null;
            if (cmdletContext.EventBridgeParameters_Source != null)
            {
                requestTarget_target_EventBridgeParameters_eventBridgeParameters_Source = cmdletContext.EventBridgeParameters_Source;
            }
            if (requestTarget_target_EventBridgeParameters_eventBridgeParameters_Source != null)
            {
                requestTarget_target_EventBridgeParameters.Source = requestTarget_target_EventBridgeParameters_eventBridgeParameters_Source;
                requestTarget_target_EventBridgeParametersIsNull = false;
            }
             // determine if requestTarget_target_EventBridgeParameters should be set to null
            if (requestTarget_target_EventBridgeParametersIsNull)
            {
                requestTarget_target_EventBridgeParameters = null;
            }
            if (requestTarget_target_EventBridgeParameters != null)
            {
                request.Target.EventBridgeParameters = requestTarget_target_EventBridgeParameters;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.RetryPolicy requestTarget_target_RetryPolicy = null;
            
             // populate RetryPolicy
            var requestTarget_target_RetryPolicyIsNull = true;
            requestTarget_target_RetryPolicy = new Amazon.Scheduler.Model.RetryPolicy();
            System.Int32? requestTarget_target_RetryPolicy_retryPolicy_MaximumEventAgeInSecond = null;
            if (cmdletContext.RetryPolicy_MaximumEventAgeInSecond != null)
            {
                requestTarget_target_RetryPolicy_retryPolicy_MaximumEventAgeInSecond = cmdletContext.RetryPolicy_MaximumEventAgeInSecond.Value;
            }
            if (requestTarget_target_RetryPolicy_retryPolicy_MaximumEventAgeInSecond != null)
            {
                requestTarget_target_RetryPolicy.MaximumEventAgeInSeconds = requestTarget_target_RetryPolicy_retryPolicy_MaximumEventAgeInSecond.Value;
                requestTarget_target_RetryPolicyIsNull = false;
            }
            System.Int32? requestTarget_target_RetryPolicy_retryPolicy_MaximumRetryAttempt = null;
            if (cmdletContext.RetryPolicy_MaximumRetryAttempt != null)
            {
                requestTarget_target_RetryPolicy_retryPolicy_MaximumRetryAttempt = cmdletContext.RetryPolicy_MaximumRetryAttempt.Value;
            }
            if (requestTarget_target_RetryPolicy_retryPolicy_MaximumRetryAttempt != null)
            {
                requestTarget_target_RetryPolicy.MaximumRetryAttempts = requestTarget_target_RetryPolicy_retryPolicy_MaximumRetryAttempt.Value;
                requestTarget_target_RetryPolicyIsNull = false;
            }
             // determine if requestTarget_target_RetryPolicy should be set to null
            if (requestTarget_target_RetryPolicyIsNull)
            {
                requestTarget_target_RetryPolicy = null;
            }
            if (requestTarget_target_RetryPolicy != null)
            {
                request.Target.RetryPolicy = requestTarget_target_RetryPolicy;
                requestTargetIsNull = false;
            }
            Amazon.Scheduler.Model.EcsParameters requestTarget_target_EcsParameters = null;
            
             // populate EcsParameters
            var requestTarget_target_EcsParametersIsNull = true;
            requestTarget_target_EcsParameters = new Amazon.Scheduler.Model.EcsParameters();
            List<Amazon.Scheduler.Model.CapacityProviderStrategyItem> requestTarget_target_EcsParameters_ecsParameters_CapacityProviderStrategy = null;
            if (cmdletContext.EcsParameters_CapacityProviderStrategy != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_CapacityProviderStrategy = cmdletContext.EcsParameters_CapacityProviderStrategy;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_CapacityProviderStrategy != null)
            {
                requestTarget_target_EcsParameters.CapacityProviderStrategy = requestTarget_target_EcsParameters_ecsParameters_CapacityProviderStrategy;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.Boolean? requestTarget_target_EcsParameters_ecsParameters_EnableECSManagedTag = null;
            if (cmdletContext.EcsParameters_EnableECSManagedTag != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_EnableECSManagedTag = cmdletContext.EcsParameters_EnableECSManagedTag.Value;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_EnableECSManagedTag != null)
            {
                requestTarget_target_EcsParameters.EnableECSManagedTags = requestTarget_target_EcsParameters_ecsParameters_EnableECSManagedTag.Value;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.Boolean? requestTarget_target_EcsParameters_ecsParameters_EnableExecuteCommand = null;
            if (cmdletContext.EcsParameters_EnableExecuteCommand != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_EnableExecuteCommand = cmdletContext.EcsParameters_EnableExecuteCommand.Value;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_EnableExecuteCommand != null)
            {
                requestTarget_target_EcsParameters.EnableExecuteCommand = requestTarget_target_EcsParameters_ecsParameters_EnableExecuteCommand.Value;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.String requestTarget_target_EcsParameters_ecsParameters_Group = null;
            if (cmdletContext.EcsParameters_Group != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_Group = cmdletContext.EcsParameters_Group;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_Group != null)
            {
                requestTarget_target_EcsParameters.Group = requestTarget_target_EcsParameters_ecsParameters_Group;
                requestTarget_target_EcsParametersIsNull = false;
            }
            Amazon.Scheduler.LaunchType requestTarget_target_EcsParameters_ecsParameters_LaunchType = null;
            if (cmdletContext.EcsParameters_LaunchType != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_LaunchType = cmdletContext.EcsParameters_LaunchType;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_LaunchType != null)
            {
                requestTarget_target_EcsParameters.LaunchType = requestTarget_target_EcsParameters_ecsParameters_LaunchType;
                requestTarget_target_EcsParametersIsNull = false;
            }
            List<Amazon.Scheduler.Model.PlacementConstraint> requestTarget_target_EcsParameters_ecsParameters_PlacementConstraint = null;
            if (cmdletContext.EcsParameters_PlacementConstraint != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_PlacementConstraint = cmdletContext.EcsParameters_PlacementConstraint;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_PlacementConstraint != null)
            {
                requestTarget_target_EcsParameters.PlacementConstraints = requestTarget_target_EcsParameters_ecsParameters_PlacementConstraint;
                requestTarget_target_EcsParametersIsNull = false;
            }
            List<Amazon.Scheduler.Model.PlacementStrategy> requestTarget_target_EcsParameters_ecsParameters_PlacementStrategy = null;
            if (cmdletContext.EcsParameters_PlacementStrategy != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_PlacementStrategy = cmdletContext.EcsParameters_PlacementStrategy;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_PlacementStrategy != null)
            {
                requestTarget_target_EcsParameters.PlacementStrategy = requestTarget_target_EcsParameters_ecsParameters_PlacementStrategy;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.String requestTarget_target_EcsParameters_ecsParameters_PlatformVersion = null;
            if (cmdletContext.EcsParameters_PlatformVersion != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_PlatformVersion = cmdletContext.EcsParameters_PlatformVersion;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_PlatformVersion != null)
            {
                requestTarget_target_EcsParameters.PlatformVersion = requestTarget_target_EcsParameters_ecsParameters_PlatformVersion;
                requestTarget_target_EcsParametersIsNull = false;
            }
            Amazon.Scheduler.PropagateTags requestTarget_target_EcsParameters_ecsParameters_PropagateTag = null;
            if (cmdletContext.EcsParameters_PropagateTag != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_PropagateTag = cmdletContext.EcsParameters_PropagateTag;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_PropagateTag != null)
            {
                requestTarget_target_EcsParameters.PropagateTags = requestTarget_target_EcsParameters_ecsParameters_PropagateTag;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.String requestTarget_target_EcsParameters_ecsParameters_ReferenceId = null;
            if (cmdletContext.EcsParameters_ReferenceId != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_ReferenceId = cmdletContext.EcsParameters_ReferenceId;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_ReferenceId != null)
            {
                requestTarget_target_EcsParameters.ReferenceId = requestTarget_target_EcsParameters_ecsParameters_ReferenceId;
                requestTarget_target_EcsParametersIsNull = false;
            }
            List<Dictionary<System.String, System.String>> requestTarget_target_EcsParameters_ecsParameters_Tag = null;
            if (cmdletContext.EcsParameters_Tag != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_Tag = cmdletContext.EcsParameters_Tag;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_Tag != null)
            {
                requestTarget_target_EcsParameters.Tags = requestTarget_target_EcsParameters_ecsParameters_Tag;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.Int32? requestTarget_target_EcsParameters_ecsParameters_TaskCount = null;
            if (cmdletContext.EcsParameters_TaskCount != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_TaskCount = cmdletContext.EcsParameters_TaskCount.Value;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_TaskCount != null)
            {
                requestTarget_target_EcsParameters.TaskCount = requestTarget_target_EcsParameters_ecsParameters_TaskCount.Value;
                requestTarget_target_EcsParametersIsNull = false;
            }
            System.String requestTarget_target_EcsParameters_ecsParameters_TaskDefinitionArn = null;
            if (cmdletContext.EcsParameters_TaskDefinitionArn != null)
            {
                requestTarget_target_EcsParameters_ecsParameters_TaskDefinitionArn = cmdletContext.EcsParameters_TaskDefinitionArn;
            }
            if (requestTarget_target_EcsParameters_ecsParameters_TaskDefinitionArn != null)
            {
                requestTarget_target_EcsParameters.TaskDefinitionArn = requestTarget_target_EcsParameters_ecsParameters_TaskDefinitionArn;
                requestTarget_target_EcsParametersIsNull = false;
            }
            Amazon.Scheduler.Model.NetworkConfiguration requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfigurationIsNull = true;
            requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration = new Amazon.Scheduler.Model.NetworkConfiguration();
            Amazon.Scheduler.Model.AwsVpcConfiguration requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration = null;
            
             // populate AwsvpcConfiguration
            var requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = true;
            requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration = new Amazon.Scheduler.Model.AwsVpcConfiguration();
            Amazon.Scheduler.AssignPublicIp requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = null;
            if (cmdletContext.AwsvpcConfiguration_AssignPublicIp != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = cmdletContext.AwsvpcConfiguration_AssignPublicIp;
            }
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration.AssignPublicIp = requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp;
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = null;
            if (cmdletContext.AwsvpcConfiguration_SecurityGroup != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = cmdletContext.AwsvpcConfiguration_SecurityGroup;
            }
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration.SecurityGroups = requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup;
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = null;
            if (cmdletContext.AwsvpcConfiguration_Subnet != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = cmdletContext.AwsvpcConfiguration_Subnet;
            }
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration.Subnets = requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet;
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfigurationIsNull = false;
            }
             // determine if requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration should be set to null
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfigurationIsNull)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration = null;
            }
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration != null)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration.AwsvpcConfiguration = requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration_target_EcsParameters_NetworkConfiguration_AwsvpcConfiguration;
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfigurationIsNull = false;
            }
             // determine if requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration should be set to null
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfigurationIsNull)
            {
                requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration = null;
            }
            if (requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration != null)
            {
                requestTarget_target_EcsParameters.NetworkConfiguration = requestTarget_target_EcsParameters_target_EcsParameters_NetworkConfiguration;
                requestTarget_target_EcsParametersIsNull = false;
            }
             // determine if requestTarget_target_EcsParameters should be set to null
            if (requestTarget_target_EcsParametersIsNull)
            {
                requestTarget_target_EcsParameters = null;
            }
            if (requestTarget_target_EcsParameters != null)
            {
                request.Target.EcsParameters = requestTarget_target_EcsParameters;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.Scheduler.Model.UpdateScheduleResponse CallAWSServiceOperation(IAmazonScheduler client, Amazon.Scheduler.Model.UpdateScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge Scheduler", "UpdateSchedule");
            try
            {
                return client.UpdateScheduleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Scheduler.ActionAfterCompletion ActionAfterCompletion { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.DateTime? EndDate { get; set; }
            public System.Int32? FlexibleTimeWindow_MaximumWindowInMinute { get; set; }
            public Amazon.Scheduler.FlexibleTimeWindowMode FlexibleTimeWindow_Mode { get; set; }
            public System.String GroupName { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.String ScheduleExpression { get; set; }
            public System.String ScheduleExpressionTimezone { get; set; }
            public System.DateTime? StartDate { get; set; }
            public Amazon.Scheduler.ScheduleState State { get; set; }
            public System.String Target_Arn { get; set; }
            public System.String DeadLetterConfig_Arn { get; set; }
            public List<Amazon.Scheduler.Model.CapacityProviderStrategyItem> EcsParameters_CapacityProviderStrategy { get; set; }
            public System.Boolean? EcsParameters_EnableECSManagedTag { get; set; }
            public System.Boolean? EcsParameters_EnableExecuteCommand { get; set; }
            public System.String EcsParameters_Group { get; set; }
            public Amazon.Scheduler.LaunchType EcsParameters_LaunchType { get; set; }
            public Amazon.Scheduler.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.Scheduler.Model.PlacementConstraint> EcsParameters_PlacementConstraint { get; set; }
            public List<Amazon.Scheduler.Model.PlacementStrategy> EcsParameters_PlacementStrategy { get; set; }
            public System.String EcsParameters_PlatformVersion { get; set; }
            public Amazon.Scheduler.PropagateTags EcsParameters_PropagateTag { get; set; }
            public System.String EcsParameters_ReferenceId { get; set; }
            public List<Dictionary<System.String, System.String>> EcsParameters_Tag { get; set; }
            public System.Int32? EcsParameters_TaskCount { get; set; }
            public System.String EcsParameters_TaskDefinitionArn { get; set; }
            public System.String EventBridgeParameters_DetailType { get; set; }
            public System.String EventBridgeParameters_Source { get; set; }
            public System.String Target_Input { get; set; }
            public System.String KinesisParameters_PartitionKey { get; set; }
            public System.Int32? RetryPolicy_MaximumEventAgeInSecond { get; set; }
            public System.Int32? RetryPolicy_MaximumRetryAttempt { get; set; }
            public System.String Target_RoleArn { get; set; }
            public List<Amazon.Scheduler.Model.SageMakerPipelineParameter> SageMakerPipelineParameters_PipelineParameterList { get; set; }
            public System.String SqsParameters_MessageGroupId { get; set; }
            public System.Func<Amazon.Scheduler.Model.UpdateScheduleResponse, UpdateSCHScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduleArn;
        }
        
    }
}
