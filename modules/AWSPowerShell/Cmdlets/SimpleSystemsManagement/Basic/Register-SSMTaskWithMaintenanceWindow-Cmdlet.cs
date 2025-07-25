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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Adds a new task to a maintenance window.
    /// </summary>
    [Cmdlet("Register", "SSMTaskWithMaintenanceWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager RegisterTaskWithMaintenanceWindow API operation.", Operation = new[] {"RegisterTaskWithMaintenanceWindow"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterSSMTaskWithMaintenanceWindowCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AlarmConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm specified in the configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmConfiguration_Alarms")]
        public Amazon.SimpleSystemsManagement.Model.Alarm[] AlarmConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter Lambda_ClientContext
        /// <summary>
        /// <para>
        /// <para>Pass client-specific information to the Lambda function that you are invoking. You
        /// can then process the client information in your Lambda function as you choose through
        /// the context variable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_Lambda_ClientContext")]
        public System.String Lambda_ClientContext { get; set; }
        #endregion
        
        #region Parameter CloudWatchOutputConfig_CloudWatchLogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group where you want to send command output. If
        /// you don't specify a group name, Amazon Web Services Systems Manager automatically
        /// creates a log group for you. The log group uses the following naming format:</para><para><c>aws/ssm/<i>SystemsManagerDocumentName</i></c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_CloudWatchOutputConfig_CloudWatchLogGroupName")]
        public System.String CloudWatchOutputConfig_CloudWatchLogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchOutputConfig_CloudWatchOutputEnabled
        /// <summary>
        /// <para>
        /// <para>Enables Systems Manager to send command output to CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_CloudWatchOutputConfig_CloudWatchOutputEnabled")]
        public System.Boolean? CloudWatchOutputConfig_CloudWatchOutputEnabled { get; set; }
        #endregion
        
        #region Parameter RunCommand_Comment
        /// <summary>
        /// <para>
        /// <para>Information about the commands to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_Comment")]
        public System.String RunCommand_Comment { get; set; }
        #endregion
        
        #region Parameter CutoffBehavior
        /// <summary>
        /// <para>
        /// <para>Indicates whether tasks should continue to run after the cutoff time specified in
        /// the maintenance windows is reached. </para><ul><li><para><c>CONTINUE_TASK</c>: When the cutoff time is reached, any tasks that are running
        /// continue. The default value.</para></li><li><para><c>CANCEL_TASK</c>:</para><ul><li><para>For Automation, Lambda, Step Functions tasks: When the cutoff time is reached, any
        /// task invocations that are already running continue, but no new task invocations are
        /// started.</para></li><li><para>For Run Command tasks: When the cutoff time is reached, the system sends a <a>CancelCommand</a>
        /// operation that attempts to cancel the command associated with the task. However, there
        /// is no guarantee that the command will be terminated and the underlying process stopped.</para></li></ul><para>The status for tasks that are not completed is <c>TIMED_OUT</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.MaintenanceWindowTaskCutoffBehavior")]
        public Amazon.SimpleSystemsManagement.MaintenanceWindowTaskCutoffBehavior CutoffBehavior { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RunCommand_DocumentHash
        /// <summary>
        /// <para>
        /// <para>The SHA-256 or SHA-1 hash created by the system when the document was created. SHA-1
        /// hashes have been deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_DocumentHash")]
        public System.String RunCommand_DocumentHash { get; set; }
        #endregion
        
        #region Parameter RunCommand_DocumentHashType
        /// <summary>
        /// <para>
        /// <para>SHA-256 or SHA-1. SHA-1 hashes have been deprecated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_DocumentHashType")]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentHashType")]
        public Amazon.SimpleSystemsManagement.DocumentHashType RunCommand_DocumentHashType { get; set; }
        #endregion
        
        #region Parameter Automation_DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The version of an Automation runbook to use during task execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_Automation_DocumentVersion")]
        public System.String Automation_DocumentVersion { get; set; }
        #endregion
        
        #region Parameter RunCommand_DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Systems Manager document (SSM document) version to use in
        /// the request. You can specify <c>$DEFAULT</c>, <c>$LATEST</c>, or a specific version
        /// number. If you run commands by using the Amazon Web Services CLI, then you must escape
        /// the first two options by using a backslash. If you specify a version number, then
        /// you don't need to use the backslash. For example:</para><para><c>--document-version "\$DEFAULT"</c></para><para><c>--document-version "\$LATEST"</c></para><para><c>--document-version "3"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_DocumentVersion")]
        public System.String RunCommand_DocumentVersion { get; set; }
        #endregion
        
        #region Parameter AlarmConfiguration_IgnorePollAlarmFailure
        /// <summary>
        /// <para>
        /// <para>When this value is <i>true</i>, your automation or command continues to run in cases
        /// where we can’t retrieve alarm status information from CloudWatch. In cases where we
        /// successfully retrieve an alarm status of OK or INSUFFICIENT_DATA, the automation or
        /// command continues to run, regardless of this value. Default is <i>false</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
        #endregion
        
        #region Parameter StepFunctions_Input
        /// <summary>
        /// <para>
        /// <para>The inputs for the <c>STEP_FUNCTIONS</c> task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_StepFunctions_Input")]
        public System.String StepFunctions_Input { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of targets this task can be run for, in parallel.</para><note><para>Although this element is listed as "Required: No", a value can be omitted only when
        /// you are registering or updating a <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/maintenance-windows-targetless-tasks.html">targetless
        /// task</a> You must provide a value in all other cases.</para><para>For maintenance window tasks without a target specified, you can't supply a value
        /// for this option. Instead, the system inserts a placeholder value of <c>1</c>. This
        /// value doesn't affect the running of your task.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The maximum number of errors allowed before this task stops being scheduled.</para><note><para>Although this element is listed as "Required: No", a value can be omitted only when
        /// you are registering or updating a <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/maintenance-windows-targetless-tasks.html">targetless
        /// task</a> You must provide a value in all other cases.</para><para>For maintenance window tasks without a target specified, you can't supply a value
        /// for this option. Instead, the system inserts a placeholder value of <c>1</c>. This
        /// value doesn't affect the running of your task.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An optional name for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StepFunctions_Name
        /// <summary>
        /// <para>
        /// <para>The name of the <c>STEP_FUNCTIONS</c> task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_StepFunctions_Name")]
        public System.String StepFunctions_Name { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) for an Amazon Simple Notification Service (Amazon SNS)
        /// topic. Run Command pushes notifications about command status changes to this topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_NotificationConfig_NotificationArn")]
        public System.String NotificationConfig_NotificationArn { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationEvent
        /// <summary>
        /// <para>
        /// <para>The different events for which you can receive notifications. To learn more about
        /// these events, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/monitoring-sns-notifications.html">Monitoring
        /// Systems Manager status changes using Amazon SNS notifications</a> in the <i>Amazon
        /// Web Services Systems Manager User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_NotificationConfig_NotificationEvents")]
        public System.String[] NotificationConfig_NotificationEvent { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationType
        /// <summary>
        /// <para>
        /// <para>The type of notification.</para><ul><li><para><c>Command</c>: Receive notification when the status of a command changes.</para></li><li><para><c>Invocation</c>: For commands sent to multiple managed nodes, receive notification
        /// on a per-node basis when the status of a command changes. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType")]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.NotificationType")]
        public Amazon.SimpleSystemsManagement.NotificationType NotificationConfig_NotificationType { get; set; }
        #endregion
        
        #region Parameter RunCommand_OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Simple Storage Service (Amazon S3) bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_OutputS3BucketName")]
        public System.String RunCommand_OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter RunCommand_OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The S3 bucket subfolder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_OutputS3KeyPrefix")]
        public System.String RunCommand_OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Automation_Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the <c>AUTOMATION</c> task.</para><para>For information about specifying and updating task parameters, see <a>RegisterTaskWithMaintenanceWindow</a>
        /// and <a>UpdateMaintenanceWindowTask</a>.</para><note><para><c>LoggingInfo</c> has been deprecated. To specify an Amazon Simple Storage Service
        /// (Amazon S3) bucket to contain logs, instead use the <c>OutputS3BucketName</c> and
        /// <c>OutputS3KeyPrefix</c> options in the <c>TaskInvocationParameters</c> structure.
        /// For information about how Amazon Web Services Systems Manager handles these options
        /// for the supported maintenance window task types, see <a>MaintenanceWindowTaskInvocationParameters</a>.</para><para><c>TaskParameters</c> has been deprecated. To specify parameters to pass to a task
        /// when it runs, instead use the <c>Parameters</c> option in the <c>TaskInvocationParameters</c>
        /// structure. For information about how Systems Manager handles these options for the
        /// supported maintenance window task types, see <a>MaintenanceWindowTaskInvocationParameters</a>.</para><para>For <c>AUTOMATION</c> task types, Amazon Web Services Systems Manager ignores any
        /// values specified for these parameters.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_Automation_Parameters")]
        public System.Collections.Hashtable Automation_Parameter { get; set; }
        #endregion
        
        #region Parameter RunCommand_Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the <c>RUN_COMMAND</c> task execution.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_Parameters")]
        public System.Collections.Hashtable RunCommand_Parameter { get; set; }
        #endregion
        
        #region Parameter Lambda_Payload
        /// <summary>
        /// <para>
        /// <para>JSON to provide to your Lambda function as input.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_Lambda_Payload")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Lambda_Payload { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the task in the maintenance window, the lower the number the higher
        /// the priority. Tasks in a maintenance window are scheduled in priority order with tasks
        /// that have the same priority scheduled in parallel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Lambda_Qualifier
        /// <summary>
        /// <para>
        /// <para>(Optional) Specify an Lambda function version or alias name. If you specify a function
        /// version, the operation uses the qualified function Amazon Resource Name (ARN) to invoke
        /// a specific Lambda function. If you specify an alias name, the operation uses the alias
        /// ARN to invoke the Lambda function version to which the alias points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_Lambda_Qualifier")]
        public System.String Lambda_Qualifier { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an S3 bucket where execution logs are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_S3BucketName { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>(Optional) The S3 bucket subfolder. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the S3 bucket is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_S3Region { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role for Amazon Web Services Systems
        /// Manager to assume when running a maintenance window task. If you do not specify a
        /// service role ARN, Systems Manager uses a service-linked role in your account. If no
        /// appropriate service-linked role for Systems Manager exists in your account, it is
        /// created when you run <c>RegisterTaskWithMaintenanceWindow</c>.</para><para>However, for an improved security posture, we strongly recommend creating a custom
        /// policy and custom service role for running your maintenance window tasks. The policy
        /// can be crafted to provide only the permissions needed for your particular maintenance
        /// window tasks. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/sysman-maintenance-permissions.html">Setting
        /// up Maintenance Windows</a> in the in the <i>Amazon Web Services Systems Manager User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter RunCommand_ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM service role for Amazon Web Services Systems
        /// Manager to assume when running a maintenance window task. If you do not specify a
        /// service role ARN, Systems Manager uses a service-linked role in your account. If no
        /// appropriate service-linked role for Systems Manager exists in your account, it is
        /// created when you run <c>RegisterTaskWithMaintenanceWindow</c>.</para><para>However, for an improved security posture, we strongly recommend creating a custom
        /// policy and custom service role for running your maintenance window tasks. The policy
        /// can be crafted to provide only the permissions needed for your particular maintenance
        /// window tasks. For more information, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/sysman-maintenance-permissions.html">Setting
        /// up Maintenance Windows</a> in the in the <i>Amazon Web Services Systems Manager User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_ServiceRoleArn")]
        public System.String RunCommand_ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets (either managed nodes or maintenance window targets).</para><note><para>One or more targets must be specified for maintenance window Run Command-type tasks.
        /// Depending on the task, targets are optional for other maintenance window task types
        /// (Automation, Lambda, and Step Functions). For more information about running tasks
        /// that don't specify targets, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/maintenance-windows-targetless-tasks.html">Registering
        /// maintenance window tasks without targets</a> in the <i>Amazon Web Services Systems
        /// Manager User Guide</i>.</para></note><para>Specify managed nodes using the following format: </para><para><c>Key=InstanceIds,Values=&lt;instance-id-1&gt;,&lt;instance-id-2&gt;</c></para><para>Specify maintenance window targets using the following format:</para><para><c>Key=WindowTargetIds,Values=&lt;window-target-id-1&gt;,&lt;window-target-id-2&gt;</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter TaskArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the task to run.</para>
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
        public System.String TaskArn { get; set; }
        #endregion
        
        #region Parameter TaskParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that should be passed to the task when it is run.</para><note><para><c>TaskParameters</c> has been deprecated. To specify parameters to pass to a task
        /// when it runs, instead use the <c>Parameters</c> option in the <c>TaskInvocationParameters</c>
        /// structure. For information about how Systems Manager handles these options for the
        /// supported maintenance window task types, see <a>MaintenanceWindowTaskInvocationParameters</a>.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskParameters")]
        public System.Collections.Hashtable TaskParameter { get; set; }
        #endregion
        
        #region Parameter TaskType
        /// <summary>
        /// <para>
        /// <para>The type of task being registered.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType")]
        public Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType TaskType { get; set; }
        #endregion
        
        #region Parameter RunCommand_TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>If this time is reached and the command hasn't already started running, it doesn't
        /// run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskInvocationParameters_RunCommand_TimeoutSeconds")]
        public System.Int32? RunCommand_TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter WindowId
        /// <summary>
        /// <para>
        /// <para>The ID of the maintenance window the task should be added to.</para>
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
        public System.String WindowId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WindowTaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WindowTaskId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TaskArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SSMTaskWithMaintenanceWindow (RegisterTaskWithMaintenanceWindow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse, RegisterSSMTaskWithMaintenanceWindowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AlarmConfiguration_Alarm != null)
            {
                context.AlarmConfiguration_Alarm = new List<Amazon.SimpleSystemsManagement.Model.Alarm>(this.AlarmConfiguration_Alarm);
            }
            context.AlarmConfiguration_IgnorePollAlarmFailure = this.AlarmConfiguration_IgnorePollAlarmFailure;
            context.ClientToken = this.ClientToken;
            context.CutoffBehavior = this.CutoffBehavior;
            context.Description = this.Description;
            context.LoggingInfo_S3BucketName = this.LoggingInfo_S3BucketName;
            context.LoggingInfo_S3KeyPrefix = this.LoggingInfo_S3KeyPrefix;
            context.LoggingInfo_S3Region = this.LoggingInfo_S3Region;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxError = this.MaxError;
            context.Name = this.Name;
            context.Priority = this.Priority;
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.Target != null)
            {
                context.Target = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
            }
            context.TaskArn = this.TaskArn;
            #if MODULAR
            if (this.TaskArn == null && ParameterWasBound(nameof(this.TaskArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Automation_DocumentVersion = this.Automation_DocumentVersion;
            if (this.Automation_Parameter != null)
            {
                context.Automation_Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Automation_Parameter.Keys)
                {
                    object hashValue = this.Automation_Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Automation_Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Automation_Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.Lambda_ClientContext = this.Lambda_ClientContext;
            context.Lambda_Payload = this.Lambda_Payload;
            context.Lambda_Qualifier = this.Lambda_Qualifier;
            context.CloudWatchOutputConfig_CloudWatchLogGroupName = this.CloudWatchOutputConfig_CloudWatchLogGroupName;
            context.CloudWatchOutputConfig_CloudWatchOutputEnabled = this.CloudWatchOutputConfig_CloudWatchOutputEnabled;
            context.RunCommand_Comment = this.RunCommand_Comment;
            context.RunCommand_DocumentHash = this.RunCommand_DocumentHash;
            context.RunCommand_DocumentHashType = this.RunCommand_DocumentHashType;
            context.RunCommand_DocumentVersion = this.RunCommand_DocumentVersion;
            context.NotificationConfig_NotificationArn = this.NotificationConfig_NotificationArn;
            if (this.NotificationConfig_NotificationEvent != null)
            {
                context.NotificationConfig_NotificationEvent = new List<System.String>(this.NotificationConfig_NotificationEvent);
            }
            context.NotificationConfig_NotificationType = this.NotificationConfig_NotificationType;
            context.RunCommand_OutputS3BucketName = this.RunCommand_OutputS3BucketName;
            context.RunCommand_OutputS3KeyPrefix = this.RunCommand_OutputS3KeyPrefix;
            if (this.RunCommand_Parameter != null)
            {
                context.RunCommand_Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.RunCommand_Parameter.Keys)
                {
                    object hashValue = this.RunCommand_Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.RunCommand_Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.RunCommand_Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.RunCommand_ServiceRoleArn = this.RunCommand_ServiceRoleArn;
            context.RunCommand_TimeoutSecond = this.RunCommand_TimeoutSecond;
            context.StepFunctions_Input = this.StepFunctions_Input;
            context.StepFunctions_Name = this.StepFunctions_Name;
            if (this.TaskParameter != null)
            {
                context.TaskParameter = new Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression>(StringComparer.Ordinal);
                foreach (var hashKey in this.TaskParameter.Keys)
                {
                    context.TaskParameter.Add((String)hashKey, (Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression)(this.TaskParameter[hashKey]));
                }
            }
            context.TaskType = this.TaskType;
            #if MODULAR
            if (this.TaskType == null && ParameterWasBound(nameof(this.TaskType)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WindowId = this.WindowId;
            #if MODULAR
            if (this.WindowId == null && ParameterWasBound(nameof(this.WindowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WindowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _Lambda_PayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowRequest();
                
                
                 // populate AlarmConfiguration
                var requestAlarmConfigurationIsNull = true;
                request.AlarmConfiguration = new Amazon.SimpleSystemsManagement.Model.AlarmConfiguration();
                List<Amazon.SimpleSystemsManagement.Model.Alarm> requestAlarmConfiguration_alarmConfiguration_Alarm = null;
                if (cmdletContext.AlarmConfiguration_Alarm != null)
                {
                    requestAlarmConfiguration_alarmConfiguration_Alarm = cmdletContext.AlarmConfiguration_Alarm;
                }
                if (requestAlarmConfiguration_alarmConfiguration_Alarm != null)
                {
                    request.AlarmConfiguration.Alarms = requestAlarmConfiguration_alarmConfiguration_Alarm;
                    requestAlarmConfigurationIsNull = false;
                }
                System.Boolean? requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure = null;
                if (cmdletContext.AlarmConfiguration_IgnorePollAlarmFailure != null)
                {
                    requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure = cmdletContext.AlarmConfiguration_IgnorePollAlarmFailure.Value;
                }
                if (requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure != null)
                {
                    request.AlarmConfiguration.IgnorePollAlarmFailure = requestAlarmConfiguration_alarmConfiguration_IgnorePollAlarmFailure.Value;
                    requestAlarmConfigurationIsNull = false;
                }
                 // determine if request.AlarmConfiguration should be set to null
                if (requestAlarmConfigurationIsNull)
                {
                    request.AlarmConfiguration = null;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                if (cmdletContext.CutoffBehavior != null)
                {
                    request.CutoffBehavior = cmdletContext.CutoffBehavior;
                }
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                
                 // populate LoggingInfo
                var requestLoggingInfoIsNull = true;
                request.LoggingInfo = new Amazon.SimpleSystemsManagement.Model.LoggingInfo();
                System.String requestLoggingInfo_loggingInfo_S3BucketName = null;
                if (cmdletContext.LoggingInfo_S3BucketName != null)
                {
                    requestLoggingInfo_loggingInfo_S3BucketName = cmdletContext.LoggingInfo_S3BucketName;
                }
                if (requestLoggingInfo_loggingInfo_S3BucketName != null)
                {
                    request.LoggingInfo.S3BucketName = requestLoggingInfo_loggingInfo_S3BucketName;
                    requestLoggingInfoIsNull = false;
                }
                System.String requestLoggingInfo_loggingInfo_S3KeyPrefix = null;
                if (cmdletContext.LoggingInfo_S3KeyPrefix != null)
                {
                    requestLoggingInfo_loggingInfo_S3KeyPrefix = cmdletContext.LoggingInfo_S3KeyPrefix;
                }
                if (requestLoggingInfo_loggingInfo_S3KeyPrefix != null)
                {
                    request.LoggingInfo.S3KeyPrefix = requestLoggingInfo_loggingInfo_S3KeyPrefix;
                    requestLoggingInfoIsNull = false;
                }
                System.String requestLoggingInfo_loggingInfo_S3Region = null;
                if (cmdletContext.LoggingInfo_S3Region != null)
                {
                    requestLoggingInfo_loggingInfo_S3Region = cmdletContext.LoggingInfo_S3Region;
                }
                if (requestLoggingInfo_loggingInfo_S3Region != null)
                {
                    request.LoggingInfo.S3Region = requestLoggingInfo_loggingInfo_S3Region;
                    requestLoggingInfoIsNull = false;
                }
                 // determine if request.LoggingInfo should be set to null
                if (requestLoggingInfoIsNull)
                {
                    request.LoggingInfo = null;
                }
                if (cmdletContext.MaxConcurrency != null)
                {
                    request.MaxConcurrency = cmdletContext.MaxConcurrency;
                }
                if (cmdletContext.MaxError != null)
                {
                    request.MaxErrors = cmdletContext.MaxError;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.Priority != null)
                {
                    request.Priority = cmdletContext.Priority.Value;
                }
                if (cmdletContext.ServiceRoleArn != null)
                {
                    request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
                }
                if (cmdletContext.Target != null)
                {
                    request.Targets = cmdletContext.Target;
                }
                if (cmdletContext.TaskArn != null)
                {
                    request.TaskArn = cmdletContext.TaskArn;
                }
                
                 // populate TaskInvocationParameters
                var requestTaskInvocationParametersIsNull = true;
                request.TaskInvocationParameters = new Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskInvocationParameters();
                Amazon.SimpleSystemsManagement.Model.MaintenanceWindowAutomationParameters requestTaskInvocationParameters_taskInvocationParameters_Automation = null;
                
                 // populate Automation
                var requestTaskInvocationParameters_taskInvocationParameters_AutomationIsNull = true;
                requestTaskInvocationParameters_taskInvocationParameters_Automation = new Amazon.SimpleSystemsManagement.Model.MaintenanceWindowAutomationParameters();
                System.String requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_DocumentVersion = null;
                if (cmdletContext.Automation_DocumentVersion != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_DocumentVersion = cmdletContext.Automation_DocumentVersion;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_DocumentVersion != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Automation.DocumentVersion = requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_DocumentVersion;
                    requestTaskInvocationParameters_taskInvocationParameters_AutomationIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_Parameter = null;
                if (cmdletContext.Automation_Parameter != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_Parameter = cmdletContext.Automation_Parameter;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_Parameter != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Automation.Parameters = requestTaskInvocationParameters_taskInvocationParameters_Automation_automation_Parameter;
                    requestTaskInvocationParameters_taskInvocationParameters_AutomationIsNull = false;
                }
                 // determine if requestTaskInvocationParameters_taskInvocationParameters_Automation should be set to null
                if (requestTaskInvocationParameters_taskInvocationParameters_AutomationIsNull)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Automation = null;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Automation != null)
                {
                    request.TaskInvocationParameters.Automation = requestTaskInvocationParameters_taskInvocationParameters_Automation;
                    requestTaskInvocationParametersIsNull = false;
                }
                Amazon.SimpleSystemsManagement.Model.MaintenanceWindowStepFunctionsParameters requestTaskInvocationParameters_taskInvocationParameters_StepFunctions = null;
                
                 // populate StepFunctions
                var requestTaskInvocationParameters_taskInvocationParameters_StepFunctionsIsNull = true;
                requestTaskInvocationParameters_taskInvocationParameters_StepFunctions = new Amazon.SimpleSystemsManagement.Model.MaintenanceWindowStepFunctionsParameters();
                System.String requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Input = null;
                if (cmdletContext.StepFunctions_Input != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Input = cmdletContext.StepFunctions_Input;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Input != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctions.Input = requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Input;
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctionsIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Name = null;
                if (cmdletContext.StepFunctions_Name != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Name = cmdletContext.StepFunctions_Name;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Name != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctions.Name = requestTaskInvocationParameters_taskInvocationParameters_StepFunctions_stepFunctions_Name;
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctionsIsNull = false;
                }
                 // determine if requestTaskInvocationParameters_taskInvocationParameters_StepFunctions should be set to null
                if (requestTaskInvocationParameters_taskInvocationParameters_StepFunctionsIsNull)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_StepFunctions = null;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_StepFunctions != null)
                {
                    request.TaskInvocationParameters.StepFunctions = requestTaskInvocationParameters_taskInvocationParameters_StepFunctions;
                    requestTaskInvocationParametersIsNull = false;
                }
                Amazon.SimpleSystemsManagement.Model.MaintenanceWindowLambdaParameters requestTaskInvocationParameters_taskInvocationParameters_Lambda = null;
                
                 // populate Lambda
                var requestTaskInvocationParameters_taskInvocationParameters_LambdaIsNull = true;
                requestTaskInvocationParameters_taskInvocationParameters_Lambda = new Amazon.SimpleSystemsManagement.Model.MaintenanceWindowLambdaParameters();
                System.String requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_ClientContext = null;
                if (cmdletContext.Lambda_ClientContext != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_ClientContext = cmdletContext.Lambda_ClientContext;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_ClientContext != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda.ClientContext = requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_ClientContext;
                    requestTaskInvocationParameters_taskInvocationParameters_LambdaIsNull = false;
                }
                System.IO.MemoryStream requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Payload = null;
                if (cmdletContext.Lambda_Payload != null)
                {
                    _Lambda_PayloadStream = new System.IO.MemoryStream(cmdletContext.Lambda_Payload);
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Payload = _Lambda_PayloadStream;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Payload != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda.Payload = requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Payload;
                    requestTaskInvocationParameters_taskInvocationParameters_LambdaIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Qualifier = null;
                if (cmdletContext.Lambda_Qualifier != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Qualifier = cmdletContext.Lambda_Qualifier;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Qualifier != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda.Qualifier = requestTaskInvocationParameters_taskInvocationParameters_Lambda_lambda_Qualifier;
                    requestTaskInvocationParameters_taskInvocationParameters_LambdaIsNull = false;
                }
                 // determine if requestTaskInvocationParameters_taskInvocationParameters_Lambda should be set to null
                if (requestTaskInvocationParameters_taskInvocationParameters_LambdaIsNull)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_Lambda = null;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_Lambda != null)
                {
                    request.TaskInvocationParameters.Lambda = requestTaskInvocationParameters_taskInvocationParameters_Lambda;
                    requestTaskInvocationParametersIsNull = false;
                }
                Amazon.SimpleSystemsManagement.Model.MaintenanceWindowRunCommandParameters requestTaskInvocationParameters_taskInvocationParameters_RunCommand = null;
                
                 // populate RunCommand
                var requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = true;
                requestTaskInvocationParameters_taskInvocationParameters_RunCommand = new Amazon.SimpleSystemsManagement.Model.MaintenanceWindowRunCommandParameters();
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Comment = null;
                if (cmdletContext.RunCommand_Comment != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Comment = cmdletContext.RunCommand_Comment;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Comment != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.Comment = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Comment;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHash = null;
                if (cmdletContext.RunCommand_DocumentHash != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHash = cmdletContext.RunCommand_DocumentHash;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHash != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.DocumentHash = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHash;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                Amazon.SimpleSystemsManagement.DocumentHashType requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHashType = null;
                if (cmdletContext.RunCommand_DocumentHashType != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHashType = cmdletContext.RunCommand_DocumentHashType;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHashType != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.DocumentHashType = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentHashType;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentVersion = null;
                if (cmdletContext.RunCommand_DocumentVersion != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentVersion = cmdletContext.RunCommand_DocumentVersion;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentVersion != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.DocumentVersion = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_DocumentVersion;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3BucketName = null;
                if (cmdletContext.RunCommand_OutputS3BucketName != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3BucketName = cmdletContext.RunCommand_OutputS3BucketName;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3BucketName != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.OutputS3BucketName = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3BucketName;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3KeyPrefix = null;
                if (cmdletContext.RunCommand_OutputS3KeyPrefix != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3KeyPrefix = cmdletContext.RunCommand_OutputS3KeyPrefix;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3KeyPrefix != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.OutputS3KeyPrefix = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_OutputS3KeyPrefix;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                Dictionary<System.String, List<System.String>> requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Parameter = null;
                if (cmdletContext.RunCommand_Parameter != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Parameter = cmdletContext.RunCommand_Parameter;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Parameter != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.Parameters = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_Parameter;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_ServiceRoleArn = null;
                if (cmdletContext.RunCommand_ServiceRoleArn != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_ServiceRoleArn = cmdletContext.RunCommand_ServiceRoleArn;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_ServiceRoleArn != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.ServiceRoleArn = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_ServiceRoleArn;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                System.Int32? requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_TimeoutSecond = null;
                if (cmdletContext.RunCommand_TimeoutSecond != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_TimeoutSecond = cmdletContext.RunCommand_TimeoutSecond.Value;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_TimeoutSecond != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.TimeoutSeconds = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_runCommand_TimeoutSecond.Value;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                Amazon.SimpleSystemsManagement.Model.CloudWatchOutputConfig requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig = null;
                
                 // populate CloudWatchOutputConfig
                var requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfigIsNull = true;
                requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig = new Amazon.SimpleSystemsManagement.Model.CloudWatchOutputConfig();
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName = null;
                if (cmdletContext.CloudWatchOutputConfig_CloudWatchLogGroupName != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName = cmdletContext.CloudWatchOutputConfig_CloudWatchLogGroupName;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig.CloudWatchLogGroupName = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfigIsNull = false;
                }
                System.Boolean? requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled = null;
                if (cmdletContext.CloudWatchOutputConfig_CloudWatchOutputEnabled != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled = cmdletContext.CloudWatchOutputConfig_CloudWatchOutputEnabled.Value;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig.CloudWatchOutputEnabled = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled.Value;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfigIsNull = false;
                }
                 // determine if requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig should be set to null
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfigIsNull)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig = null;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.CloudWatchOutputConfig = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_CloudWatchOutputConfig;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                Amazon.SimpleSystemsManagement.Model.NotificationConfig requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig = null;
                
                 // populate NotificationConfig
                var requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfigIsNull = true;
                requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig = new Amazon.SimpleSystemsManagement.Model.NotificationConfig();
                System.String requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationArn = null;
                if (cmdletContext.NotificationConfig_NotificationArn != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationArn = cmdletContext.NotificationConfig_NotificationArn;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationArn != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig.NotificationArn = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationArn;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfigIsNull = false;
                }
                List<System.String> requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationEvent = null;
                if (cmdletContext.NotificationConfig_NotificationEvent != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationEvent = cmdletContext.NotificationConfig_NotificationEvent;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationEvent != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig.NotificationEvents = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationEvent;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfigIsNull = false;
                }
                Amazon.SimpleSystemsManagement.NotificationType requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationType = null;
                if (cmdletContext.NotificationConfig_NotificationType != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationType = cmdletContext.NotificationConfig_NotificationType;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationType != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig.NotificationType = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig_notificationConfig_NotificationType;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfigIsNull = false;
                }
                 // determine if requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig should be set to null
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfigIsNull)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig = null;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig != null)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand.NotificationConfig = requestTaskInvocationParameters_taskInvocationParameters_RunCommand_taskInvocationParameters_RunCommand_NotificationConfig;
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull = false;
                }
                 // determine if requestTaskInvocationParameters_taskInvocationParameters_RunCommand should be set to null
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommandIsNull)
                {
                    requestTaskInvocationParameters_taskInvocationParameters_RunCommand = null;
                }
                if (requestTaskInvocationParameters_taskInvocationParameters_RunCommand != null)
                {
                    request.TaskInvocationParameters.RunCommand = requestTaskInvocationParameters_taskInvocationParameters_RunCommand;
                    requestTaskInvocationParametersIsNull = false;
                }
                 // determine if request.TaskInvocationParameters should be set to null
                if (requestTaskInvocationParametersIsNull)
                {
                    request.TaskInvocationParameters = null;
                }
                if (cmdletContext.TaskParameter != null)
                {
                    request.TaskParameters = cmdletContext.TaskParameter;
                }
                if (cmdletContext.TaskType != null)
                {
                    request.TaskType = cmdletContext.TaskType;
                }
                if (cmdletContext.WindowId != null)
                {
                    request.WindowId = cmdletContext.WindowId;
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
                if( _Lambda_PayloadStream != null)
                {
                    _Lambda_PayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "RegisterTaskWithMaintenanceWindow");
            try
            {
                return client.RegisterTaskWithMaintenanceWindowAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.Alarm> AlarmConfiguration_Alarm { get; set; }
            public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.SimpleSystemsManagement.MaintenanceWindowTaskCutoffBehavior CutoffBehavior { get; set; }
            public System.String Description { get; set; }
            public System.String LoggingInfo_S3BucketName { get; set; }
            public System.String LoggingInfo_S3KeyPrefix { get; set; }
            public System.String LoggingInfo_S3Region { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxError { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Target { get; set; }
            public System.String TaskArn { get; set; }
            public System.String Automation_DocumentVersion { get; set; }
            public Dictionary<System.String, List<System.String>> Automation_Parameter { get; set; }
            public System.String Lambda_ClientContext { get; set; }
            public byte[] Lambda_Payload { get; set; }
            public System.String Lambda_Qualifier { get; set; }
            public System.String CloudWatchOutputConfig_CloudWatchLogGroupName { get; set; }
            public System.Boolean? CloudWatchOutputConfig_CloudWatchOutputEnabled { get; set; }
            public System.String RunCommand_Comment { get; set; }
            public System.String RunCommand_DocumentHash { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentHashType RunCommand_DocumentHashType { get; set; }
            public System.String RunCommand_DocumentVersion { get; set; }
            public System.String NotificationConfig_NotificationArn { get; set; }
            public List<System.String> NotificationConfig_NotificationEvent { get; set; }
            public Amazon.SimpleSystemsManagement.NotificationType NotificationConfig_NotificationType { get; set; }
            public System.String RunCommand_OutputS3BucketName { get; set; }
            public System.String RunCommand_OutputS3KeyPrefix { get; set; }
            public Dictionary<System.String, List<System.String>> RunCommand_Parameter { get; set; }
            public System.String RunCommand_ServiceRoleArn { get; set; }
            public System.Int32? RunCommand_TimeoutSecond { get; set; }
            public System.String StepFunctions_Input { get; set; }
            public System.String StepFunctions_Name { get; set; }
            public Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression> TaskParameter { get; set; }
            public Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType TaskType { get; set; }
            public System.String WindowId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse, RegisterSSMTaskWithMaintenanceWindowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WindowTaskId;
        }
        
    }
}
