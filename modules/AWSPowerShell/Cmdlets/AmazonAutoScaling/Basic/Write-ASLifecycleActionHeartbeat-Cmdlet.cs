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
    /// Records a heartbeat for the lifecycle action associated with a specific token. This
    /// extends the timeout by the length of time defined by the <code>HeartbeatTimeout</code>
    /// parameter of <a>PutLifecycleHook</a>.
    /// 
    ///  
    /// <para>
    /// This operation is a part of the basic sequence for adding a lifecycle hook to an Auto
    /// Scaling group:
    /// </para><ol><li>Create a notification target. A target can be either an Amazon SQS queue
    /// or an Amazon SNS topic.</li><li>Create an IAM role. This role allows Auto Scaling
    /// to publish lifecycle notifications to the designated SQS queue or SNS topic.</li><li>Create the lifecycle hook. You can create a hook that acts when instances launch
    /// or when instances terminate.</li><li><b>If necessary, record the lifecycle action
    /// heartbeat to keep the instance in a pending state.</b></li><li>Complete the lifecycle
    /// action.</li></ol><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/AutoScalingPendingState.html">Auto
    /// Scaling Pending State</a> and <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/AutoScalingTerminatingState.html">Auto
    /// Scaling Terminating State</a> in the <i>Auto Scaling Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASLifecycleActionHeartbeat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the RecordLifecycleActionHeartbeat operation against Auto Scaling.", Operation = new[] {"RecordLifecycleActionHeartbeat"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type RecordLifecycleActionHeartbeatResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteASLifecycleActionHeartbeatCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group for the hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String AutoScalingGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A token that uniquely identifies a specific lifecycle action associated with an instance.
        /// Auto Scaling sends this token to the notification target you specified when you created
        /// the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String LifecycleActionToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle hook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String LifecycleHookName { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASLifecycleActionHeartbeat (RecordLifecycleActionHeartbeat)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
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
            var request = new RecordLifecycleActionHeartbeatRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
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
                var response = client.RecordLifecycleActionHeartbeat(request);
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
            public String AutoScalingGroupName { get; set; }
            public String LifecycleActionToken { get; set; }
            public String LifecycleHookName { get; set; }
        }
        
    }
}
