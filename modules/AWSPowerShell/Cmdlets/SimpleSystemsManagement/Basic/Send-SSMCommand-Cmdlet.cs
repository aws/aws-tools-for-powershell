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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Runs commands on one or more managed nodes.
    /// </summary>
    [Cmdlet("Send", "SSMCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.Command")]
    [AWSCmdlet("Calls the AWS Systems Manager SendCommand API operation.", Operation = new[] {"SendCommand"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.SendCommandResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.Command or Amazon.SimpleSystemsManagement.Model.SendCommandResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.Command object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.SendCommandResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSSMCommandCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter AlarmConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch alarm specified in the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlarmConfiguration_Alarms")]
        public Amazon.SimpleSystemsManagement.Model.Alarm[] AlarmConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter CloudWatchOutputConfig_CloudWatchLogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group where you want to send command output. If
        /// you don't specify a group name, Amazon Web Services Systems Manager automatically
        /// creates a log group for you. The log group uses the following naming format:</para><para><code>aws/ssm/<i>SystemsManagerDocumentName</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchOutputConfig_CloudWatchLogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchOutputConfig_CloudWatchOutputEnabled
        /// <summary>
        /// <para>
        /// <para>Enables Systems Manager to send command output to CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CloudWatchOutputConfig_CloudWatchOutputEnabled { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>User-specified information about the command, such as a brief description of what
        /// the command should do.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter DocumentHash
        /// <summary>
        /// <para>
        /// <para>The Sha256 or Sha1 hash created by the system when the document was created. </para><note><para>Sha1 hashes have been deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentHash { get; set; }
        #endregion
        
        #region Parameter DocumentHashType
        /// <summary>
        /// <para>
        /// <para>Sha256 or Sha1.</para><note><para>Sha1 hashes have been deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentHashType")]
        public Amazon.SimpleSystemsManagement.DocumentHashType DocumentHashType { get; set; }
        #endregion
        
        #region Parameter DocumentName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services Systems Manager document (SSM document) to run.
        /// This can be a public document or a custom document. To run a shared document belonging
        /// to another account, specify the document Amazon Resource Name (ARN). For more information
        /// about how to use shared documents, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/ssm-using-shared.html">Using
        /// shared SSM documents</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para><note><para>If you specify a document name or ARN that hasn't been shared with your account, you
        /// receive an <code>InvalidDocument</code> error. </para></note>
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
        public System.String DocumentName { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The SSM document version to use in the request. You can specify $DEFAULT, $LATEST,
        /// or a specific version number. If you run commands by using the Command Line Interface
        /// (Amazon Web Services CLI), then you must escape the first two options by using a backslash.
        /// If you specify a version number, then you don't need to use the backslash. For example:</para><para>--document-version "\$DEFAULT"</para><para>--document-version "\$LATEST"</para><para>--document-version "3"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
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
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the managed nodes where the command should run. Specifying managed node
        /// IDs is most useful when you are targeting a limited number of managed nodes, though
        /// you can specify up to 50 IDs.</para><para>To target a larger number of managed nodes, or if you prefer not to list individual
        /// node IDs, we recommend using the <code>Targets</code> option instead. Using <code>Targets</code>,
        /// which accepts tag key-value pairs to identify the managed nodes to send commands to,
        /// you can a send command to tens, hundreds, or thousands of nodes at once.</para><para>For more information about how to use targets, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-multiple.html">Using
        /// targets and rate controls to send commands to a fleet</a> in the <i>Amazon Web Services
        /// Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of managed nodes that are allowed to run the command
        /// at the same time. You can specify a number such as 10 or a percentage such as 10%.
        /// The default value is <code>50</code>. For more information about how to use <code>MaxConcurrency</code>,
        /// see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-multiple.html#send-commands-velocity">Using
        /// concurrency controls</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The maximum number of errors allowed without the command failing. When the command
        /// fails one more time beyond the value of <code>MaxErrors</code>, the systems stops
        /// sending the command to additional targets. You can specify a number like 10 or a percentage
        /// like 10%. The default value is <code>0</code>. For more information about how to use
        /// <code>MaxErrors</code>, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-multiple.html#send-commands-maxerrors">Using
        /// error controls</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) for an Amazon Simple Notification Service (Amazon SNS)
        /// topic. Run Command pushes notifications about command status changes to this topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationConfig_NotificationArn { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationEvent
        /// <summary>
        /// <para>
        /// <para>The different events for which you can receive notifications. To learn more about
        /// these events, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/monitoring-sns-notifications.html">Monitoring
        /// Systems Manager status changes using Amazon SNS notifications</a> in the <i>Amazon
        /// Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationConfig_NotificationEvents")]
        public System.String[] NotificationConfig_NotificationEvent { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationType
        /// <summary>
        /// <para>
        /// <para>The type of notification.</para><ul><li><para><code>Command</code>: Receive notification when the status of a command changes.</para></li><li><para><code>Invocation</code>: For commands sent to multiple managed nodes, receive notification
        /// on a per-node basis when the status of a command changes. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.NotificationType")]
        public Amazon.SimpleSystemsManagement.NotificationType NotificationConfig_NotificationType { get; set; }
        #endregion
        
        #region Parameter OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where command execution responses should be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The directory structure within the S3 bucket where the responses should be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter OutputS3Region
        /// <summary>
        /// <para>
        /// <para>(Deprecated) You can no longer specify this parameter. The system ignores it. Instead,
        /// Systems Manager automatically determines the Amazon Web Services Region of the S3
        /// bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3Region { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The required and optional parameters specified in the document being run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Identity and Access Management (IAM) service role to use to publish
        /// Amazon Simple Notification Service (Amazon SNS) notifications for Run Command commands.</para><para>This role must provide the <code>sns:Publish</code> permission for your notification
        /// topic. For information about creating and using this service role, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/monitoring-sns-notifications.html">Monitoring
        /// Systems Manager status changes using Amazon SNS notifications</a> in the <i>Amazon
        /// Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>An array of search criteria that targets managed nodes using a <code>Key,Value</code>
        /// combination that you specify. Specifying targets is most useful when you want to send
        /// a command to a large number of managed nodes at once. Using <code>Targets</code>,
        /// which accepts tag key-value pairs to identify managed nodes, you can send a command
        /// to tens, hundreds, or thousands of nodes at once.</para><para>To send a command to a smaller number of managed nodes, you can use the <code>InstanceIds</code>
        /// option instead.</para><para>For more information about how to use targets, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-multiple.html">Sending
        /// commands to a fleet</a> in the <i>Amazon Web Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>If this time is reached and the command hasn't already started running, it won't run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSeconds")]
        public System.Int32? TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Command'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.SendCommandResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.SendCommandResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Command";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SSMCommand (SendCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.SendCommandResponse, SendSSMCommandCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AlarmConfiguration_Alarm != null)
            {
                context.AlarmConfiguration_Alarm = new List<Amazon.SimpleSystemsManagement.Model.Alarm>(this.AlarmConfiguration_Alarm);
            }
            context.AlarmConfiguration_IgnorePollAlarmFailure = this.AlarmConfiguration_IgnorePollAlarmFailure;
            context.CloudWatchOutputConfig_CloudWatchLogGroupName = this.CloudWatchOutputConfig_CloudWatchLogGroupName;
            context.CloudWatchOutputConfig_CloudWatchOutputEnabled = this.CloudWatchOutputConfig_CloudWatchOutputEnabled;
            context.Comment = this.Comment;
            context.DocumentHash = this.DocumentHash;
            context.DocumentHashType = this.DocumentHashType;
            context.DocumentName = this.DocumentName;
            #if MODULAR
            if (this.DocumentName == null && ParameterWasBound(nameof(this.DocumentName)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DocumentVersion = this.DocumentVersion;
            if (this.InstanceId != null)
            {
                context.InstanceId = new List<System.String>(this.InstanceId);
            }
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxError = this.MaxError;
            context.NotificationConfig_NotificationArn = this.NotificationConfig_NotificationArn;
            if (this.NotificationConfig_NotificationEvent != null)
            {
                context.NotificationConfig_NotificationEvent = new List<System.String>(this.NotificationConfig_NotificationEvent);
            }
            context.NotificationConfig_NotificationType = this.NotificationConfig_NotificationType;
            context.OutputS3BucketName = this.OutputS3BucketName;
            context.OutputS3KeyPrefix = this.OutputS3KeyPrefix;
            context.OutputS3Region = this.OutputS3Region;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameter.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Parameter.Add((String)hashKey, valueSet);
                }
            }
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.Target != null)
            {
                context.Target = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
            }
            context.TimeoutSecond = this.TimeoutSecond;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.SendCommandRequest();
            
            
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
            
             // populate CloudWatchOutputConfig
            var requestCloudWatchOutputConfigIsNull = true;
            request.CloudWatchOutputConfig = new Amazon.SimpleSystemsManagement.Model.CloudWatchOutputConfig();
            System.String requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName = null;
            if (cmdletContext.CloudWatchOutputConfig_CloudWatchLogGroupName != null)
            {
                requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName = cmdletContext.CloudWatchOutputConfig_CloudWatchLogGroupName;
            }
            if (requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName != null)
            {
                request.CloudWatchOutputConfig.CloudWatchLogGroupName = requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchLogGroupName;
                requestCloudWatchOutputConfigIsNull = false;
            }
            System.Boolean? requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled = null;
            if (cmdletContext.CloudWatchOutputConfig_CloudWatchOutputEnabled != null)
            {
                requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled = cmdletContext.CloudWatchOutputConfig_CloudWatchOutputEnabled.Value;
            }
            if (requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled != null)
            {
                request.CloudWatchOutputConfig.CloudWatchOutputEnabled = requestCloudWatchOutputConfig_cloudWatchOutputConfig_CloudWatchOutputEnabled.Value;
                requestCloudWatchOutputConfigIsNull = false;
            }
             // determine if request.CloudWatchOutputConfig should be set to null
            if (requestCloudWatchOutputConfigIsNull)
            {
                request.CloudWatchOutputConfig = null;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.DocumentHash != null)
            {
                request.DocumentHash = cmdletContext.DocumentHash;
            }
            if (cmdletContext.DocumentHashType != null)
            {
                request.DocumentHashType = cmdletContext.DocumentHashType;
            }
            if (cmdletContext.DocumentName != null)
            {
                request.DocumentName = cmdletContext.DocumentName;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency;
            }
            if (cmdletContext.MaxError != null)
            {
                request.MaxErrors = cmdletContext.MaxError;
            }
            
             // populate NotificationConfig
            var requestNotificationConfigIsNull = true;
            request.NotificationConfig = new Amazon.SimpleSystemsManagement.Model.NotificationConfig();
            System.String requestNotificationConfig_notificationConfig_NotificationArn = null;
            if (cmdletContext.NotificationConfig_NotificationArn != null)
            {
                requestNotificationConfig_notificationConfig_NotificationArn = cmdletContext.NotificationConfig_NotificationArn;
            }
            if (requestNotificationConfig_notificationConfig_NotificationArn != null)
            {
                request.NotificationConfig.NotificationArn = requestNotificationConfig_notificationConfig_NotificationArn;
                requestNotificationConfigIsNull = false;
            }
            List<System.String> requestNotificationConfig_notificationConfig_NotificationEvent = null;
            if (cmdletContext.NotificationConfig_NotificationEvent != null)
            {
                requestNotificationConfig_notificationConfig_NotificationEvent = cmdletContext.NotificationConfig_NotificationEvent;
            }
            if (requestNotificationConfig_notificationConfig_NotificationEvent != null)
            {
                request.NotificationConfig.NotificationEvents = requestNotificationConfig_notificationConfig_NotificationEvent;
                requestNotificationConfigIsNull = false;
            }
            Amazon.SimpleSystemsManagement.NotificationType requestNotificationConfig_notificationConfig_NotificationType = null;
            if (cmdletContext.NotificationConfig_NotificationType != null)
            {
                requestNotificationConfig_notificationConfig_NotificationType = cmdletContext.NotificationConfig_NotificationType;
            }
            if (requestNotificationConfig_notificationConfig_NotificationType != null)
            {
                request.NotificationConfig.NotificationType = requestNotificationConfig_notificationConfig_NotificationType;
                requestNotificationConfigIsNull = false;
            }
             // determine if request.NotificationConfig should be set to null
            if (requestNotificationConfigIsNull)
            {
                request.NotificationConfig = null;
            }
            if (cmdletContext.OutputS3BucketName != null)
            {
                request.OutputS3BucketName = cmdletContext.OutputS3BucketName;
            }
            if (cmdletContext.OutputS3KeyPrefix != null)
            {
                request.OutputS3KeyPrefix = cmdletContext.OutputS3KeyPrefix;
            }
            if (cmdletContext.OutputS3Region != null)
            {
                request.OutputS3Region = cmdletContext.OutputS3Region;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
            }
            if (cmdletContext.TimeoutSecond != null)
            {
                request.TimeoutSeconds = cmdletContext.TimeoutSecond.Value;
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
        
        private Amazon.SimpleSystemsManagement.Model.SendCommandResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.SendCommandRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "SendCommand");
            try
            {
                #if DESKTOP
                return client.SendCommand(request);
                #elif CORECLR
                return client.SendCommandAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.Alarm> AlarmConfiguration_Alarm { get; set; }
            public System.Boolean? AlarmConfiguration_IgnorePollAlarmFailure { get; set; }
            public System.String CloudWatchOutputConfig_CloudWatchLogGroupName { get; set; }
            public System.Boolean? CloudWatchOutputConfig_CloudWatchOutputEnabled { get; set; }
            public System.String Comment { get; set; }
            public System.String DocumentHash { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentHashType DocumentHashType { get; set; }
            public System.String DocumentName { get; set; }
            public System.String DocumentVersion { get; set; }
            public List<System.String> InstanceId { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxError { get; set; }
            public System.String NotificationConfig_NotificationArn { get; set; }
            public List<System.String> NotificationConfig_NotificationEvent { get; set; }
            public Amazon.SimpleSystemsManagement.NotificationType NotificationConfig_NotificationType { get; set; }
            public System.String OutputS3BucketName { get; set; }
            public System.String OutputS3KeyPrefix { get; set; }
            public System.String OutputS3Region { get; set; }
            public Dictionary<System.String, List<System.String>> Parameter { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Target { get; set; }
            public System.Int32? TimeoutSecond { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.SendCommandResponse, SendSSMCommandCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Command;
        }
        
    }
}
