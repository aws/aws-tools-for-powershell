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
    /// Replaces the specified rule. You must specify all parameters for the new rule. Creating
    /// rules is an administrator-level action. Any user who has permission to create rules
    /// will be able to access data processed by the rule.
    /// </summary>
    [Cmdlet("Set", "IOTTopicRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ReplaceTopicRule operation against AWS IoT.", Operation = new[] {"ReplaceTopicRule"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the RuleName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.ReplaceTopicRuleResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetIOTTopicRuleCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter TopicRulePayload_Action
        /// <summary>
        /// <para>
        /// <para>The actions associated with the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TopicRulePayload_Actions")]
        public Amazon.IoT.Model.Action[] TopicRulePayload_Action { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_AwsIotSqlVersion
        /// <summary>
        /// <para>
        /// <para>The version of the SQL rules engine to use when evaluating the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TopicRulePayload_AwsIotSqlVersion { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_Description
        /// <summary>
        /// <para>
        /// <para>The description of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TopicRulePayload_Description { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_RuleDisabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the rule is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean TopicRulePayload_RuleDisabled { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter TopicRulePayload_Sql
        /// <summary>
        /// <para>
        /// <para>The SQL statement used to query the topic. For more information, see <a href="http://docs.aws.amazon.com/iot/latest/developerguide/iot-rules.html#aws-iot-sql-reference">AWS
        /// IoT SQL Reference</a> in the <i>AWS IoT Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TopicRulePayload_Sql { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the RuleName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RuleName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IOTTopicRule (ReplaceTopicRule)"))
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
            
            context.RuleName = this.RuleName;
            if (this.TopicRulePayload_Action != null)
            {
                context.TopicRulePayload_Actions = new List<Amazon.IoT.Model.Action>(this.TopicRulePayload_Action);
            }
            context.TopicRulePayload_AwsIotSqlVersion = this.TopicRulePayload_AwsIotSqlVersion;
            context.TopicRulePayload_Description = this.TopicRulePayload_Description;
            if (ParameterWasBound("TopicRulePayload_RuleDisabled"))
                context.TopicRulePayload_RuleDisabled = this.TopicRulePayload_RuleDisabled;
            context.TopicRulePayload_Sql = this.TopicRulePayload_Sql;
            
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
            var request = new Amazon.IoT.Model.ReplaceTopicRuleRequest();
            
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            
             // populate TopicRulePayload
            bool requestTopicRulePayloadIsNull = true;
            request.TopicRulePayload = new Amazon.IoT.Model.TopicRulePayload();
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
            System.String requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion = null;
            if (cmdletContext.TopicRulePayload_AwsIotSqlVersion != null)
            {
                requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion = cmdletContext.TopicRulePayload_AwsIotSqlVersion;
            }
            if (requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion != null)
            {
                request.TopicRulePayload.AwsIotSqlVersion = requestTopicRulePayload_topicRulePayload_AwsIotSqlVersion;
                requestTopicRulePayloadIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_Description = null;
            if (cmdletContext.TopicRulePayload_Description != null)
            {
                requestTopicRulePayload_topicRulePayload_Description = cmdletContext.TopicRulePayload_Description;
            }
            if (requestTopicRulePayload_topicRulePayload_Description != null)
            {
                request.TopicRulePayload.Description = requestTopicRulePayload_topicRulePayload_Description;
                requestTopicRulePayloadIsNull = false;
            }
            System.Boolean? requestTopicRulePayload_topicRulePayload_RuleDisabled = null;
            if (cmdletContext.TopicRulePayload_RuleDisabled != null)
            {
                requestTopicRulePayload_topicRulePayload_RuleDisabled = cmdletContext.TopicRulePayload_RuleDisabled.Value;
            }
            if (requestTopicRulePayload_topicRulePayload_RuleDisabled != null)
            {
                request.TopicRulePayload.RuleDisabled = requestTopicRulePayload_topicRulePayload_RuleDisabled.Value;
                requestTopicRulePayloadIsNull = false;
            }
            System.String requestTopicRulePayload_topicRulePayload_Sql = null;
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
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.RuleName;
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
        
        private Amazon.IoT.Model.ReplaceTopicRuleResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.ReplaceTopicRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "ReplaceTopicRule");
            #if DESKTOP
            return client.ReplaceTopicRule(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ReplaceTopicRuleAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String RuleName { get; set; }
            public List<Amazon.IoT.Model.Action> TopicRulePayload_Actions { get; set; }
            public System.String TopicRulePayload_AwsIotSqlVersion { get; set; }
            public System.String TopicRulePayload_Description { get; set; }
            public System.Boolean? TopicRulePayload_RuleDisabled { get; set; }
            public System.String TopicRulePayload_Sql { get; set; }
        }
        
    }
}
