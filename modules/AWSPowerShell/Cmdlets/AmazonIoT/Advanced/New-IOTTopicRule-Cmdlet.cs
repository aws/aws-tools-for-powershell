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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates a rule.
    /// </summary>
    [Cmdlet("New", "IOTTopicRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the CreateTopicRule operation against AWS IoT.", Operation = new[] {"CreateTopicRule"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type CreateTopicRuleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewIOTTopicRuleCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The actions associated with the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TopicRulePayload_Actions")]
        public Amazon.IoT.Model.Action[] TopicRulePayload_Action { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The description of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TopicRulePayload_Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether the rule is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean TopicRulePayload_RuleDisabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RuleName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The SQL statement used to query the topic. For more information, see <a href="http://docs.aws.amazon.com/iot/latest/developerguide/iot-rules.html#aws-iot-sql-reference">AWS
        /// IoT SQL Reference</a> in the <i>AWS IoT Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TopicRulePayload_Sql { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RuleName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTTopicRule (CreateTopicRule)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.RuleName = this.RuleName;
            if (this.TopicRulePayload_Action != null)
            {
                context.TopicRulePayload_Actions = new List<Amazon.IoT.Model.Action>(this.TopicRulePayload_Action);
            }
            context.TopicRulePayload_Description = this.TopicRulePayload_Description;
            if (ParameterWasBound("TopicRulePayload_RuleDisabled"))
                context.TopicRulePayload_RuleDisabled = this.TopicRulePayload_RuleDisabled;
            context.TopicRulePayload_Sql = this.TopicRulePayload_Sql;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateTopicRuleRequest();
            
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            
             // populate TopicRulePayload
            bool requestTopicRulePayloadIsNull = true;
            request.TopicRulePayload = new TopicRulePayload();
            List<Amazon.IoT.Model.Action> requestTopicRulePayload_topicRulePayload_Action = null;
            if (cmdletContext.TopicRulePayload_Actions != null)
            {
                requestTopicRulePayload_topicRulePayload_Action = cmdletContext.TopicRulePayload_Actions;
            }
            if (requestTopicRulePayload_topicRulePayload_Action != null)
            {
                request.TopicRulePayload.Actions = requestTopicRulePayload_topicRulePayload_Action;
                requestTopicRulePayloadIsNull = false;
            }
            String requestTopicRulePayload_topicRulePayload_Description = null;
            if (cmdletContext.TopicRulePayload_Description != null)
            {
                requestTopicRulePayload_topicRulePayload_Description = cmdletContext.TopicRulePayload_Description;
            }
            if (requestTopicRulePayload_topicRulePayload_Description != null)
            {
                request.TopicRulePayload.Description = requestTopicRulePayload_topicRulePayload_Description;
                requestTopicRulePayloadIsNull = false;
            }
            Boolean? requestTopicRulePayload_topicRulePayload_RuleDisabled = null;
            if (cmdletContext.TopicRulePayload_RuleDisabled != null)
            {
                requestTopicRulePayload_topicRulePayload_RuleDisabled = cmdletContext.TopicRulePayload_RuleDisabled.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_RuleDisabled != null)
            {
                request.TopicRulePayload.RuleDisabled = requestTopicRulePayload_topicRulePayload_RuleDisabled.Value;
                requestTopicRulePayloadIsNull = false;
            }
            String requestTopicRulePayload_topicRulePayload_Sql = null;
            if (cmdletContext.TopicRulePayload_Sql != null)
            {
                requestTopicRulePayload_topicRulePayload_Sql = cmdletContext.TopicRulePayload_Sql;
            }
            if (requestTopicRulePayload_topicRulePayload_Sql != null)
            {
                request.TopicRulePayload.Sql = requestTopicRulePayload_topicRulePayload_Sql;
                requestTopicRulePayloadIsNull = false;
            }
             // determine if request.TopicRulePayload should be set to null
            if (requestTopicRulePayloadIsNull)
            {
                request.TopicRulePayload = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateTopicRule(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
            public String RuleName { get; set; }
            public List<Amazon.IoT.Model.Action> TopicRulePayload_Actions { get; set; }
            public String TopicRulePayload_Description { get; set; }
            public Boolean? TopicRulePayload_RuleDisabled { get; set; }
            public String TopicRulePayload_Sql { get; set; }
        }
        
    }
}
