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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates or updates a lifecycle hook for the specified Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// Lifecycle hooks let you create solutions that are aware of events in the Auto Scaling
    /// instance lifecycle, and then perform a custom action on instances when the corresponding
    /// lifecycle event occurs.
    /// </para><para>
    /// This step is a part of the procedure for adding a lifecycle hook to an Auto Scaling
    /// group:
    /// </para><ol><li><para>
    /// (Optional) Create a launch template or launch configuration with a user data script
    /// that runs while an instance is in a wait state due to a lifecycle hook.
    /// </para></li><li><para>
    /// (Optional) Create a Lambda function and a rule that allows Amazon EventBridge to invoke
    /// your Lambda function when an instance is put into a wait state due to a lifecycle
    /// hook.
    /// </para></li><li><para>
    /// (Optional) Create a notification target and an IAM role. The target can be either
    /// an Amazon SQS queue or an Amazon SNS topic. The role allows Amazon EC2 Auto Scaling
    /// to publish lifecycle notifications to the target.
    /// </para></li><li><para><b>Create the lifecycle hook. Specify whether the hook is used when the instances
    /// launch or terminate.</b></para></li><li><para>
    /// If you need more time, record the lifecycle action heartbeat to keep the instance
    /// in a wait state using the <a>RecordLifecycleActionHeartbeat</a> API call.
    /// </para></li><li><para>
    /// If you finish before the timeout period ends, send a callback by using the <a>CompleteLifecycleAction</a>
    /// API call.
    /// </para></li></ol><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/lifecycle-hooks.html">Amazon
    /// EC2 Auto Scaling lifecycle hooks</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// If you exceed your maximum limit of lifecycle hooks, which by default is 50 per Auto
    /// Scaling group, the call fails.
    /// </para><para>
    /// You can view the lifecycle hooks for an Auto Scaling group using the <a>DescribeLifecycleHooks</a>
    /// API call. If you are no longer using a lifecycle hook, you can delete it by calling
    /// the <a>DeleteLifecycleHook</a> API.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASLifecycleHook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling PutLifecycleHook API operation.", Operation = new[] {"PutLifecycleHook"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.PutLifecycleHookResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.PutLifecycleHookResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.PutLifecycleHookResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteASLifecycleHookCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter DefaultResult
        /// <summary>
        /// <para>
        /// <para>The action the Auto Scaling group takes when the lifecycle hook timeout elapses or
        /// if an unexpected failure occurs. The default value is <code>ABANDON</code>.</para><para>Valid values: <code>CONTINUE</code> | <code>ABANDON</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultResult { get; set; }
        #endregion
        
        #region Parameter HeartbeatTimeout
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that can elapse before the lifecycle hook times out.
        /// The range is from <code>30</code> to <code>7200</code> seconds. The default value
        /// is <code>3600</code> seconds (1 hour).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HeartbeatTimeout { get; set; }
        #endregion
        
        #region Parameter LifecycleHookName
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle hook.</para>
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
        public System.String LifecycleHookName { get; set; }
        #endregion
        
        #region Parameter LifecycleTransition
        /// <summary>
        /// <para>
        /// <para>The lifecycle transition. For Auto Scaling groups, there are two major lifecycle transitions.</para><ul><li><para>To create a lifecycle hook for scale-out events, specify <code>autoscaling:EC2_INSTANCE_LAUNCHING</code>.</para></li><li><para>To create a lifecycle hook for scale-in events, specify <code>autoscaling:EC2_INSTANCE_TERMINATING</code>.</para></li></ul><para>Required for new lifecycle hooks, but optional when updating existing hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LifecycleTransition { get; set; }
        #endregion
        
        #region Parameter NotificationMetadata
        /// <summary>
        /// <para>
        /// <para>Additional information that you want to include any time Amazon EC2 Auto Scaling sends
        /// a message to the notification target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationMetadata { get; set; }
        #endregion
        
        #region Parameter NotificationTargetARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the notification target that Amazon EC2 Auto Scaling
        /// uses to notify you when an instance is in a wait state for the lifecycle hook. You
        /// can specify either an Amazon SNS topic or an Amazon SQS queue.</para><para>If you specify an empty string, this overrides the current ARN.</para><para>This operation uses the JSON format when sending notifications to an Amazon SQS queue,
        /// and an email key-value pair format when sending notifications to an Amazon SNS topic.</para><para>When you specify a notification target, Amazon EC2 Auto Scaling sends it a test message.
        /// Test messages contain the following additional key-value pair: <code>"Event": "autoscaling:TEST_NOTIFICATION"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTargetARN { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that allows the Auto Scaling group to publish to the specified
        /// notification target.</para><para>Valid only if the notification target is an Amazon SNS topic or an Amazon SQS queue.
        /// Required for new lifecycle hooks, but optional when updating existing hooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.PutLifecycleHookResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASLifecycleHook (PutLifecycleHook)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.PutLifecycleHookResponse, WriteASLifecycleHookCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultResult = this.DefaultResult;
            context.HeartbeatTimeout = this.HeartbeatTimeout;
            context.LifecycleHookName = this.LifecycleHookName;
            #if MODULAR
            if (this.LifecycleHookName == null && ParameterWasBound(nameof(this.LifecycleHookName)))
            {
                WriteWarning("You are passing $null as a value for parameter LifecycleHookName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.AutoScaling.Model.PutLifecycleHookResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutLifecycleHookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "PutLifecycleHook");
            try
            {
                #if DESKTOP
                return client.PutLifecycleHook(request);
                #elif CORECLR
                return client.PutLifecycleHookAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.AutoScaling.Model.PutLifecycleHookResponse, WriteASLifecycleHookCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
