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
    /// Executes the specified policy.
    /// </summary>
    [Cmdlet("Start", "ASPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ExecutePolicy operation against Auto Scaling.", Operation = new[] {"ExecutePolicy"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.ExecutePolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StartASPolicyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The breach threshold for the alarm.</para><para>This parameter is required if the policy type is <code>StepScaling</code> and not
        /// supported otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double BreachThreshold { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If this parameter is true, Auto Scaling waits for the cooldown period to complete
        /// before executing the policy. Otherwise, Auto Scaling executes the policy without waiting
        /// for the cooldown period to complete.</para><para>This parameter is not supported if the policy type is <code>StepScaling</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/Cooldown.html">Understanding
        /// Auto Scaling Cooldowns</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Boolean HonorCooldown { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The metric value to compare to <code>BreachThreshold</code>. This enables you to execute
        /// a policy of type <code>StepScaling</code> and determine which step adjustment to use.
        /// For example, if the breach threshold is 50 and you want to use a step adjustment with
        /// a lower bound of 0 and an upper bound of 10, you can set the metric value to 59.</para><para>If you specify a metric value that doesn't correspond to a step adjustment for the
        /// policy, the call returns an error.</para><para>This parameter is required if the policy type is <code>StepScaling</code> and not
        /// supported otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double MetricValue { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PolicyName { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ASPolicy (ExecutePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (ParameterWasBound("BreachThreshold"))
                context.BreachThreshold = this.BreachThreshold;
            if (ParameterWasBound("HonorCooldown"))
                context.HonorCooldown = this.HonorCooldown;
            if (ParameterWasBound("MetricValue"))
                context.MetricValue = this.MetricValue;
            context.PolicyName = this.PolicyName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AutoScaling.Model.ExecutePolicyRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.BreachThreshold != null)
            {
                request.BreachThreshold = cmdletContext.BreachThreshold.Value;
            }
            if (cmdletContext.HonorCooldown != null)
            {
                request.HonorCooldown = cmdletContext.HonorCooldown.Value;
            }
            if (cmdletContext.MetricValue != null)
            {
                request.MetricValue = cmdletContext.MetricValue.Value;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ExecutePolicy(request);
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
            public System.Double? BreachThreshold { get; set; }
            public System.Boolean? HonorCooldown { get; set; }
            public System.Double? MetricValue { get; set; }
            public System.String PolicyName { get; set; }
        }
        
    }
}
