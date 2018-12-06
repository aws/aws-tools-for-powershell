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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates or updates a lifecycle hook for the specified Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// A lifecycle hook tells Amazon EC2 Auto Scaling to perform an action on an instance
    /// that is not actively in service; for example, either when the instance launches or
    /// before the instance terminates.
    /// </para><para>
    /// This step is a part of the procedure for adding a lifecycle hook to an Auto Scaling
    /// group:
    /// </para><ol><li><para>
    /// (Optional) Create a Lambda function and a rule that allows CloudWatch Events to invoke
    /// your Lambda function when Amazon EC2 Auto Scaling launches or terminates instances.
    /// </para></li><li><para>
    /// (Optional) Create a notification target and an IAM role. The target can be either
    /// an Amazon SQS queue or an Amazon SNS topic. The role allows Amazon EC2 Auto Scaling
    /// to publish lifecycle notifications to the target.
    /// </para></li><li><para><b>Create the lifecycle hook. Specify whether the hook is used when the instances
    /// launch or terminate.</b></para></li><li><para>
    /// If you need more time, record the lifecycle action heartbeat to keep the instance
    /// in a pending state.
    /// </para></li><li><para>
    /// If you finish before the timeout period ends, complete the lifecycle action.
    /// </para></li></ol><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/lifecycle-hooks.html">Auto
    /// Scaling Lifecycle Hooks</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// If you exceed your maximum limit of lifecycle hooks, which by default is 50 per Auto
    /// Scaling group, the call fails. For information about updating this limit, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">AWS
    /// Service Limits</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASLifecycleHook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Auto Scaling PutLifecycleHook API operation.", Operation = new[] {"PutLifecycleHook"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.PutLifecycleHookResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteASLifecycleHookCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter DefaultResult
        /// <summary>
        /// <para>
        /// <para>Defines the action the Auto Scaling group should take when the lifecycle hook timeout
        /// elapses or if an unexpected failure occurs. This parameter can be either <code>CONTINUE</code>
        /// or <code>ABANDON</code>. The default value is <code>ABANDON</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultResult { get; set; }
        #endregion
        
        #region Parameter HeartbeatTimeout
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that can elapse before the lifecycle hook times out.
        /// The range is from 30 to 7200 seconds. The default is 3600 seconds (1 hour).</para><para>If the lifecycle hook times out, Amazon EC2 Auto Scaling performs the default action.
        /// You can prevent the lifecycle hook from timing out by calling <a>RecordLifecycleActionHeartbeat</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HeartbeatTimeout { get; set; }
        #endregion
        
        #region Parameter LifecycleHookName
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LifecycleHookName { get; set; }
        #endregion
        
        #region Parameter LifecycleTransition
        /// <summary>
        /// <para>
        /// <para>The instance state to which you want to attach the lifecycle hook. The possible values
        /// are:</para><ul><li><para>autoscaling:EC2_INSTANCE_LAUNCHING</para></li><li><para>autoscaling:EC2_INSTANCE_TERMINATING</para></li></ul><para>This parameter is required for new lifecycle hooks, but optional when updating existing
        /// hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LifecycleTransition { get; set; }
        #endregion
        
        #region Parameter NotificationMetadata
        /// <summary>
        /// <para>
        /// <para>Contains additional information that you want to include any time Amazon EC2 Auto
        /// Scaling sends a message to the notification target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationMetadata { get; set; }
        #endregion
        
        #region Parameter NotificationTargetARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the notification target that Amazon EC2 Auto Scaling uses to notify you
        /// when an instance is in the transition state for the lifecycle hook. This target can
        /// be either an SQS queue or an SNS topic. If you specify an empty string, this overrides
        /// the current ARN.</para><para>This operation uses the JSON format when sending notifications to an Amazon SQS queue,
        /// and an email key-value pair format when sending notifications to an Amazon SNS topic.</para><para>When you specify a notification target, Amazon EC2 Auto Scaling sends it a test message.
        /// Test messages contain the following additional key-value pair: <code>"Event": "autoscaling:TEST_NOTIFICATION"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTargetARN { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows the Auto Scaling group to publish to the specified
        /// notification target.</para><para>This parameter is required for new lifecycle hooks, but optional when updating existing
        /// hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AutoScalingGroupName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AutoScalingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASLifecycleHook (PutLifecycleHook)"))
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
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            context.DefaultResult = this.DefaultResult;
            if (ParameterWasBound("HeartbeatTimeout"))
                context.HeartbeatTimeout = this.HeartbeatTimeout;
            context.LifecycleHookName = this.LifecycleHookName;
            context.LifecycleTransition = this.LifecycleTransition;
            context.NotificationMetadata = this.NotificationMetadata;
            context.NotificationTargetARN = this.NotificationTargetARN;
            context.RoleARN = this.RoleARN;
            
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
            var request = new Amazon.AutoScaling.Model.PutLifecycleHookRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.DefaultResult != null)
            {
                request.DefaultResult = cmdletContext.DefaultResult;
            }
            if (cmdletContext.HeartbeatTimeout != null)
            {
                request.HeartbeatTimeout = cmdletContext.HeartbeatTimeout.Value;
            }
            if (cmdletContext.LifecycleHookName != null)
            {
                request.LifecycleHookName = cmdletContext.LifecycleHookName;
            }
            if (cmdletContext.LifecycleTransition != null)
            {
                request.LifecycleTransition = cmdletContext.LifecycleTransition;
            }
            if (cmdletContext.NotificationMetadata != null)
            {
                request.NotificationMetadata = cmdletContext.NotificationMetadata;
            }
            if (cmdletContext.NotificationTargetARN != null)
            {
                request.NotificationTargetARN = cmdletContext.NotificationTargetARN;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.AutoScalingGroupName;
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
        
        private Amazon.AutoScaling.Model.PutLifecycleHookResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutLifecycleHookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Auto Scaling", "PutLifecycleHook");
            try
            {
                #if DESKTOP
                return client.PutLifecycleHook(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutLifecycleHookAsync(request);
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
            public System.String AutoScalingGroupName { get; set; }
            public System.String DefaultResult { get; set; }
            public System.Int32? HeartbeatTimeout { get; set; }
            public System.String LifecycleHookName { get; set; }
            public System.String LifecycleTransition { get; set; }
            public System.String NotificationMetadata { get; set; }
            public System.String NotificationTargetARN { get; set; }
            public System.String RoleARN { get; set; }
        }
        
    }
}
