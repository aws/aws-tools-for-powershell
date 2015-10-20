/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates or updates a lifecycle hook for the specified Auto Scaling Group.
    /// 
    ///  
    /// <para>
    /// A lifecycle hook tells Auto Scaling that you want to perform an action on an instance
    /// that is not actively in service; for example, either when the instance launches or
    /// before the instance terminates.
    /// </para><para>
    /// This operation is a part of the basic sequence for adding a lifecycle hook to an Auto
    /// Scaling group:
    /// </para><ol><li>Create a notification target. A target can be either an Amazon SQS queue
    /// or an Amazon SNS topic.</li><li>Create an IAM role. This role allows Auto Scaling
    /// to publish lifecycle notifications to the designated SQS queue or SNS topic.</li><li><b>Create the lifecycle hook. You can create a hook that acts when instances launch
    /// or when instances terminate.</b></li><li>If necessary, record the lifecycle action
    /// heartbeat to keep the instance in a pending state.</li><li>Complete the lifecycle
    /// action.</li></ol><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/AutoScalingPendingState.html">Auto
    /// Scaling Pending State</a> and <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/AutoScalingTerminatingState.html">Auto
    /// Scaling Terminating State</a> in the <i>Auto Scaling Developer Guide</i>.
    /// </para><para>
    /// If you exceed your maximum limit of lifecycle hooks, which by default is 50 per region,
    /// the call fails. For information about updating this limit, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">AWS
    /// Service Limits</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASLifecycleHook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutLifecycleHook operation against Auto Scaling.", Operation = new[] {"PutLifecycleHook"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.PutLifecycleHookResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteASLifecycleHookCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group to which you want to assign the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Defines the action the Auto Scaling group should take when the lifecycle hook timeout
        /// elapses or if an unexpected failure occurs. The value for this parameter can be either
        /// <code>CONTINUE</code> or <code>ABANDON</code>. The default value for this parameter
        /// is <code>ABANDON</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultResult { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that can elapse before the lifecycle hook times out.
        /// When the lifecycle hook times out, Auto Scaling performs the action defined in the
        /// <code>DefaultResult</code> parameter. You can prevent the lifecycle hook from timing
        /// out by calling <a>RecordLifecycleActionHeartbeat</a>. The default is 3600 seconds
        /// (1 hour).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HeartbeatTimeout { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LifecycleHookName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance state to which you want to attach the lifecycle hook. For a list of lifecycle
        /// hook types, see <a>DescribeLifecycleHookTypes</a>.</para><para>This parameter is required for new lifecycle hooks, but optional when updating existing
        /// hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LifecycleTransition { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Contains additional information that you want to include any time Auto Scaling sends
        /// a message to the notification target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationMetadata { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the notification target that Auto Scaling will use to notify you when an
        /// instance is in the transition state for the lifecycle hook. This ARN target can be
        /// either an SQS queue or an SNS topic. </para><para>This parameter is required for new lifecycle hooks, but optional when updating existing
        /// hooks.</para><para>The notification message sent to the target will include:</para><ul><li><b>LifecycleActionToken</b>. The Lifecycle action token.</li><li><b>AccountId</b>.
        /// The user account ID.</li><li><b>AutoScalingGroupName</b>. The name of the Auto Scaling
        /// group.</li><li><b>LifecycleHookName</b>. The lifecycle hook name.</li><li><b>EC2InstanceId</b>.
        /// The EC2 instance ID.</li><li><b>LifecycleTransition</b>. The lifecycle transition.</li><li><b>NotificationMetadata</b>. The notification metadata.</li></ul><para>This operation uses the JSON format when sending notifications to an Amazon SQS queue,
        /// and an email key/value pair format when sending notifications to an Amazon SNS topic.</para><para>When you call this operation, a test message is sent to the notification target. This
        /// test message contains an additional key/value pair: <code>Event:autoscaling:TEST_NOTIFICATION</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTargetARN { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows the Auto Scaling group to publish to the specified
        /// notification target.</para><para>This parameter is required for new lifecycle hooks, but optional when updating existing
        /// hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
        
        /// <summary>
        /// Returns the value passed to the AutoScalingGroupName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            context.DefaultResult = this.DefaultResult;
            if (ParameterWasBound("HeartbeatTimeout"))
                context.HeartbeatTimeout = this.HeartbeatTimeout;
            context.LifecycleHookName = this.LifecycleHookName;
            context.LifecycleTransition = this.LifecycleTransition;
            context.NotificationMetadata = this.NotificationMetadata;
            context.NotificationTargetARN = this.NotificationTargetARN;
            context.RoleARN = this.RoleARN;
            
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
                var response = client.PutLifecycleHook(request);
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
        
        
        internal class CmdletContext : ExecutorContext
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
