/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Executes commands on one or more managed instances.
    /// </summary>
    [Cmdlet("Send", "SSMCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.Command")]
    [AWSCmdlet("Calls the AWS Systems Manager SendCommand API operation.", Operation = new[] {"SendCommand"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.Command",
        "This cmdlet returns a Command object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.SendCommandResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSSMCommandCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>User-specified information about the command, such as a brief description of what
        /// the command should do.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter DocumentHash
        /// <summary>
        /// <para>
        /// <para>The Sha256 or Sha1 hash created by the system when the document was created. </para><note><para>Sha1 hashes have been deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DocumentHash { get; set; }
        #endregion
        
        #region Parameter DocumentHashType
        /// <summary>
        /// <para>
        /// <para>Sha256 or Sha1.</para><note><para>Sha1 hashes have been deprecated.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentHashType")]
        public Amazon.SimpleSystemsManagement.DocumentHashType DocumentHashType { get; set; }
        #endregion
        
        #region Parameter DocumentName
        /// <summary>
        /// <para>
        /// <para>Required. The name of the Systems Manager document to execute. This can be a public
        /// document or a custom document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DocumentName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance IDs where the command should execute. You can specify a maximum of 50
        /// IDs. If you prefer not to list individual instance IDs, you can instead send commands
        /// to a fleet of instances using the Targets parameter, which accepts EC2 tags. For more
        /// information about how to use Targets, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-multiple.html">Sending
        /// Commands to a Fleet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceIds")]
        public System.String[] InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of instances that are allowed to execute the command
        /// at the same time. You can specify a number such as 10 or a percentage such as 10%.
        /// The default value is 50. For more information about how to use MaxConcurrency, see
        /// <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-velocity.html">Using
        /// Concurrency Controls</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The maximum number of errors allowed without the command failing. When the command
        /// fails one more time beyond the value of MaxErrors, the systems stops sending the command
        /// to additional targets. You can specify a number like 10 or a percentage like 10%.
        /// The default value is 0. For more information about how to use MaxErrors, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-maxerrors.html">Using
        /// Error Controls</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) for a Simple Notification Service (SNS) topic. Run Command
        /// pushes notifications about command status changes to this topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationConfig_NotificationArn { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationEvent
        /// <summary>
        /// <para>
        /// <para>The different events for which you can receive notifications. These events include
        /// the following: All (events), InProgress, Success, TimedOut, Cancelled, Failed. To
        /// learn more about these events, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/monitor-commands.html">Setting
        /// Up Events and Notifications</a> in the <i>AWS Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NotificationConfig_NotificationEvents")]
        public System.String[] NotificationConfig_NotificationEvent { get; set; }
        #endregion
        
        #region Parameter NotificationConfig_NotificationType
        /// <summary>
        /// <para>
        /// <para>Command: Receive notification when the status of a command changes. Invocation: For
        /// commands sent to multiple instances, receive notification on a per-instance basis
        /// when the status of a command changes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.NotificationType")]
        public Amazon.SimpleSystemsManagement.NotificationType NotificationConfig_NotificationType { get; set; }
        #endregion
        
        #region Parameter OutputS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where command execution responses should be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3BucketName { get; set; }
        #endregion
        
        #region Parameter OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The directory structure within the S3 bucket where the responses should be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter OutputS3Region
        /// <summary>
        /// <para>
        /// <para>(Deprecated) You can no longer specify this parameter. The system ignores it. Instead,
        /// Systems Manager automatically determines the Amazon S3 bucket region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OutputS3Region { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The required and optional parameters specified in the document being executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that Systems Manager uses to send notifications. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>(Optional) An array of search criteria that targets instances using a Key,Value combination
        /// that you specify. Targets is required if you don't provide one or more instance IDs
        /// in the call. For more information about how to use Targets, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/send-commands-multiple.html">Sending
        /// Commands to a Fleet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>If this time is reached and the command has not already started executing, it will
        /// not run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeoutSeconds")]
        public System.Int32 TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SSMCommand (SendCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Comment = this.Comment;
            context.DocumentHash = this.DocumentHash;
            context.DocumentHashType = this.DocumentHashType;
            context.DocumentName = this.DocumentName;
            if (this.InstanceId != null)
            {
                context.InstanceIds = new List<System.String>(this.InstanceId);
            }
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxErrors = this.MaxError;
            context.NotificationConfig_NotificationArn = this.NotificationConfig_NotificationArn;
            if (this.NotificationConfig_NotificationEvent != null)
            {
                context.NotificationConfig_NotificationEvents = new List<System.String>(this.NotificationConfig_NotificationEvent);
            }
            context.NotificationConfig_NotificationType = this.NotificationConfig_NotificationType;
            context.OutputS3BucketName = this.OutputS3BucketName;
            context.OutputS3KeyPrefix = this.OutputS3KeyPrefix;
            context.OutputS3Region = this.OutputS3Region;
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    object hashValue = this.Parameter[hashKey];
                    if (hashValue == null)
                    {
                        context.Parameters.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.Parameters.Add((String)hashKey, valueSet);
                }
            }
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.Target != null)
            {
                context.Targets = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
            }
            if (ParameterWasBound("TimeoutSecond"))
                context.TimeoutSeconds = this.TimeoutSecond;
            
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
            if (cmdletContext.InstanceIds != null)
            {
                request.InstanceIds = cmdletContext.InstanceIds;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency;
            }
            if (cmdletContext.MaxErrors != null)
            {
                request.MaxErrors = cmdletContext.MaxErrors;
            }
            
             // populate NotificationConfig
            bool requestNotificationConfigIsNull = true;
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
            if (cmdletContext.NotificationConfig_NotificationEvents != null)
            {
                requestNotificationConfig_notificationConfig_NotificationEvent = cmdletContext.NotificationConfig_NotificationEvents;
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
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            if (cmdletContext.TimeoutSeconds != null)
            {
                request.TimeoutSeconds = cmdletContext.TimeoutSeconds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Command;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendCommandAsync(request);
                return task.Result;
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
            public System.String Comment { get; set; }
            public System.String DocumentHash { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentHashType DocumentHashType { get; set; }
            public System.String DocumentName { get; set; }
            public List<System.String> InstanceIds { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxErrors { get; set; }
            public System.String NotificationConfig_NotificationArn { get; set; }
            public List<System.String> NotificationConfig_NotificationEvents { get; set; }
            public Amazon.SimpleSystemsManagement.NotificationType NotificationConfig_NotificationType { get; set; }
            public System.String OutputS3BucketName { get; set; }
            public System.String OutputS3KeyPrefix { get; set; }
            public System.String OutputS3Region { get; set; }
            public Dictionary<System.String, List<System.String>> Parameters { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Targets { get; set; }
            public System.Int32? TimeoutSeconds { get; set; }
        }
        
    }
}
