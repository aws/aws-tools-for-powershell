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
    /// Creates or updates a scheduled scaling action for an Auto Scaling group. When updating
    /// a scheduled scaling action, if you leave a parameter unspecified, the corresponding
    /// value remains unchanged in the affected Auto Scaling group. 
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/schedule_time.html">Scheduled
    /// Scaling</a> in the <i>Auto Scaling Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASScheduledUpdateGroupAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutScheduledUpdateGroupAction operation against Auto Scaling.", Operation = new[] {"PutScheduledUpdateGroupAction"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type PutScheduledUpdateGroupActionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteASScheduledUpdateGroupActionCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String AutoScalingGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The number of EC2 instances that should be running in the group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 DesiredCapacity { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time for this action to end.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum size for the Auto Scaling group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 MaxSize { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The minimum size for the Auto Scaling group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 MinSize { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time when recurring future actions will start. Start time is specified by the
        /// user following the Unix cron syntax format. For more information, see <a href="http://en.wikipedia.org/wiki/Cron">Cron</a>
        /// in Wikipedia.</para><para>When <code>StartTime</code> and <code>EndTime</code> are specified with <code>Recurrence</code>,
        /// they form the boundaries of when the recurring action will start and stop.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Recurrence { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of this scaling action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String ScheduledActionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The time for this action to start, in "YYYY-MM-DDThh:mm:ssZ" format in UTC/GMT only
        /// (for example, <code>2014-06-01T00:00:00Z</code>).</para><para>If you try to schedule your action in the past, Auto Scaling returns an error message.
        /// </para><para>When <code>StartTime</code> and <code>EndTime</code> are specified with <code>Recurrence</code>,
        /// they form the boundaries of when the recurring action starts and stops.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter is deprecated; use <code>StartTime</code> instead.</para><para>The time for this action to start. If both <code>Time</code> and <code>StartTime</code>
        /// are specified, their values must be identical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime Time { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASScheduledUpdateGroupAction (PutScheduledUpdateGroupAction)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (ParameterWasBound("DesiredCapacity"))
                context.DesiredCapacity = this.DesiredCapacity;
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (ParameterWasBound("MaxSize"))
                context.MaxSize = this.MaxSize;
            if (ParameterWasBound("MinSize"))
                context.MinSize = this.MinSize;
            context.Recurrence = this.Recurrence;
            context.ScheduledActionName = this.ScheduledActionName;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            if (ParameterWasBound("Time"))
                context.Time = this.Time;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PutScheduledUpdateGroupActionRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.DesiredCapacity != null)
            {
                request.DesiredCapacity = cmdletContext.DesiredCapacity.Value;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxSize != null)
            {
                request.MaxSize = cmdletContext.MaxSize.Value;
            }
            if (cmdletContext.MinSize != null)
            {
                request.MinSize = cmdletContext.MinSize.Value;
            }
            if (cmdletContext.Recurrence != null)
            {
                request.Recurrence = cmdletContext.Recurrence;
            }
            if (cmdletContext.ScheduledActionName != null)
            {
                request.ScheduledActionName = cmdletContext.ScheduledActionName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Time != null)
            {
                request.Time = cmdletContext.Time.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutScheduledUpdateGroupAction(request);
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
            public Int32? DesiredCapacity { get; set; }
            public DateTime? EndTime { get; set; }
            public Int32? MaxSize { get; set; }
            public Int32? MinSize { get; set; }
            public String Recurrence { get; set; }
            public String ScheduledActionName { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? Time { get; set; }
        }
        
    }
}
