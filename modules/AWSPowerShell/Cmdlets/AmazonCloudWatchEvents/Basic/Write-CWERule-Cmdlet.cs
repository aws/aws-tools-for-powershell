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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Creates or updates a rule. Rules are enabled by default, or based on value of the
    /// State parameter. You can disable a rule using <a>DisableRule</a>.
    /// 
    ///  
    /// <para><b>Note:</b> When you make a change with this action, incoming events might not immediately
    /// start matching to new or updated rules. Please allow a short period of time for changes
    /// to take effect.
    /// </para><para>
    /// A rule must contain at least an EventPattern or ScheduleExpression. Rules with EventPatterns
    /// are triggered when a matching event is observed. Rules with ScheduleExpressions self-trigger
    /// based on the given schedule. A rule can have both an EventPattern and a ScheduleExpression,
    /// in which case the rule will trigger on matching events as well as on a schedule.
    /// </para><para><b>Note:</b> Most services in AWS treat : or / as the same character in Amazon Resource
    /// Names (ARNs). However, CloudWatch Events uses an exact match in event patterns and
    /// rules. Be sure to use the correct ARN characters when creating event patterns so that
    /// they match the ARN syntax in the event you want to match. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWERule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the PutRule operation against Amazon CloudWatch Events.", Operation = new[] {"PutRule"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudWatchEvents.Model.PutRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCWERuleCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventPattern
        /// <summary>
        /// <para>
        /// <para>The event pattern.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventPattern { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the rule that you are creating or updating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role associated with the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The scheduling expression. For example, "cron(0 20 * * ? *)", "rate(5 minutes)".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>Indicates whether the rule is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatchEvents.RuleState")]
        public Amazon.CloudWatchEvents.RuleState State { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWERule (PutRule)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.EventPattern = this.EventPattern;
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            context.ScheduleExpression = this.ScheduleExpression;
            context.State = this.State;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchEvents.Model.PutRuleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventPattern != null)
            {
                request.EventPattern = cmdletContext.EventPattern;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutRule(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RuleArn;
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
            public System.String Description { get; set; }
            public System.String EventPattern { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String ScheduleExpression { get; set; }
            public Amazon.CloudWatchEvents.RuleState State { get; set; }
        }
        
    }
}
