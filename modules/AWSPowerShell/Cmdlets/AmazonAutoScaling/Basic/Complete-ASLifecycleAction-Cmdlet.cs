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
    /// Completes the lifecycle action for the specified token or instance with the specified
    /// result.
    /// 
    ///  
    /// <para>
    /// This step is a part of the procedure for adding a lifecycle hook to an Auto Scaling
    /// group:
    /// </para><ol><li>(Optional) Create a Lambda function and a rule that allows CloudWatch Events
    /// to invoke your Lambda function when Auto Scaling launches or terminates instances.</li><li>(Optional) Create a notification target and an IAM role. The target can be either
    /// an Amazon SQS queue or an Amazon SNS topic. The role allows Auto Scaling to publish
    /// lifecycle notifications to the target.</li><li>Create the lifecycle hook. Specify
    /// whether the hook is used when the instances launch or terminate.</li><li>If you need
    /// more time, record the lifecycle action heartbeat to keep the instance in a pending
    /// state.</li><li><b>If you finish before the timeout period ends, complete the lifecycle
    /// action.</b></li></ol><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/AutoScalingGroupLifecycle.html">Auto
    /// Scaling Lifecycle</a> in the <i>Auto Scaling Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Complete", "ASLifecycleAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CompleteLifecycleAction operation against Auto Scaling.", Operation = new[] {"CompleteLifecycleAction"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.CompleteLifecycleActionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CompleteASLifecycleActionCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the group for the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LifecycleActionResult
        /// <summary>
        /// <para>
        /// <para>The action for the group to take. This parameter can be either <code>CONTINUE</code>
        /// or <code>ABANDON</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LifecycleActionResult { get; set; }
        #endregion
        
        #region Parameter LifecycleActionToken
        /// <summary>
        /// <para>
        /// <para>A universally unique identifier (UUID) that identifies a specific lifecycle action
        /// associated with an instance. Auto Scaling sends this token to the notification target
        /// you specified when you created the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LifecycleActionToken { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-ASLifecycleAction (CompleteLifecycleAction)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            context.InstanceId = this.InstanceId;
            context.LifecycleActionResult = this.LifecycleActionResult;
            context.LifecycleActionToken = this.LifecycleActionToken;
            context.LifecycleHookName = this.LifecycleHookName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AutoScaling.Model.CompleteLifecycleActionRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.LifecycleActionResult != null)
            {
                request.LifecycleActionResult = cmdletContext.LifecycleActionResult;
            }
            if (cmdletContext.LifecycleActionToken != null)
            {
                request.LifecycleActionToken = cmdletContext.LifecycleActionToken;
            }
            if (cmdletContext.LifecycleHookName != null)
            {
                request.LifecycleHookName = cmdletContext.LifecycleHookName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CompleteLifecycleAction(request);
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
            public System.String InstanceId { get; set; }
            public System.String LifecycleActionResult { get; set; }
            public System.String LifecycleActionToken { get; set; }
            public System.String LifecycleHookName { get; set; }
        }
        
    }
}
