/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Creates or updates the specified rule. Rules are enabled by default, or based on value
    /// of the state. You can disable a rule using <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_DisableRule.html">DisableRule</a>.
    /// 
    ///  
    /// <para>
    /// A single rule watches for events from a single event bus. Events generated by Amazon
    /// Web Services services go to your account's default event bus. Events generated by
    /// SaaS partner services or applications go to the matching partner event bus. If you
    /// have custom applications or services, you can specify whether their events go to your
    /// default event bus or a custom event bus that you have created. For more information,
    /// see <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_CreateEventBus.html">CreateEventBus</a>.
    /// </para><para>
    /// If you are updating an existing rule, the rule is replaced with what you specify in
    /// this <c>PutRule</c> command. If you omit arguments in <c>PutRule</c>, the old values
    /// for those arguments are not kept. Instead, they are replaced with null values.
    /// </para><para>
    /// When you create or update a rule, incoming events might not immediately start matching
    /// to new or updated rules. Allow a short period of time for changes to take effect.
    /// </para><para>
    /// A rule must contain at least an EventPattern or ScheduleExpression. Rules with EventPatterns
    /// are triggered when a matching event is observed. Rules with ScheduleExpressions self-trigger
    /// based on the given schedule. A rule can have both an EventPattern and a ScheduleExpression,
    /// in which case the rule triggers on matching events as well as on a schedule.
    /// </para><para>
    /// When you initially create a rule, you can optionally assign one or more tags to the
    /// rule. Tags can help you organize and categorize your resources. You can also use them
    /// to scope user permissions, by granting a user permission to access or change only
    /// rules with certain tag values. To use the <c>PutRule</c> operation and assign tags,
    /// you must have both the <c>events:PutRule</c> and <c>events:TagResource</c> permissions.
    /// </para><para>
    /// If you are updating an existing rule, any tags you specify in the <c>PutRule</c> operation
    /// are ignored. To update the tags of an existing rule, use <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_UntagResource.html">UntagResource</a>.
    /// </para><para>
    /// Most services in Amazon Web Services treat : or / as the same character in Amazon
    /// Resource Names (ARNs). However, EventBridge uses an exact match in event patterns
    /// and rules. Be sure to use the correct ARN characters when creating event patterns
    /// so that they match the ARN syntax in the event you want to match.
    /// </para><para>
    /// In EventBridge, it is possible to create rules that lead to infinite loops, where
    /// a rule is fired repeatedly. For example, a rule might detect that ACLs have changed
    /// on an S3 bucket, and trigger software to change them to the desired state. If the
    /// rule is not written carefully, the subsequent change to the ACLs fires the rule again,
    /// creating an infinite loop.
    /// </para><para>
    /// To prevent this, write the rules so that the triggered actions do not re-fire the
    /// same rule. For example, your rule could fire only if ACLs are found to be in a bad
    /// state, instead of after any change. 
    /// </para><para>
    /// An infinite loop can quickly cause higher than expected charges. We recommend that
    /// you use budgeting, which alerts you when charges exceed your specified limit. For
    /// more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/budgets-managing-costs.html">Managing
    /// Your Costs with Budgets</a>.
    /// </para><para>
    /// To create a rule that filters for management events from Amazon Web Services services,
    /// see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-service-event-cloudtrail.html#eb-service-event-cloudtrail-management">Receiving
    /// read-only management events from Amazon Web Services services</a> in the <i>EventBridge
    /// User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EVBRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EventBridge PutRule API operation.", Operation = new[] {"PutRule"}, SelectReturnType = typeof(Amazon.EventBridge.Model.PutRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.EventBridge.Model.PutRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EventBridge.Model.PutRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteEVBRuleCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBusName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the event bus to associate with this rule. If you omit this, the
        /// default event bus is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventBusName { get; set; }
        #endregion
        
        #region Parameter EventPattern
        /// <summary>
        /// <para>
        /// <para>The event pattern. For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-event-patterns.html">Amazon
        /// EventBridge event patterns</a> in the <i><i>Amazon EventBridge User Guide</i></i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventPattern { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the rule that you are creating or updating.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role associated with the rule.</para><para>If you're setting an event bus in another account as the target and that account granted
        /// permission to your account through an organization instead of directly by the account
        /// ID, you must specify a <c>RoleArn</c> with proper permissions in the <c>Target</c>
        /// structure, instead of here in this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The scheduling expression. For example, "cron(0 20 * * ? *)" or "rate(5 minutes)".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the rule.</para><para>Valid values include:</para><ul><li><para><c>DISABLED</c>: The rule is disabled. EventBridge does not match any events against
        /// the rule.</para></li><li><para><c>ENABLED</c>: The rule is enabled. EventBridge matches events against the rule,
        /// <i>except</i> for Amazon Web Services management events delivered through CloudTrail.</para></li><li><para><c>ENABLED_WITH_ALL_CLOUDTRAIL_MANAGEMENT_EVENTS</c>: The rule is enabled for all
        /// events, including Amazon Web Services management events delivered through CloudTrail.</para><para>Management events provide visibility into management operations that are performed
        /// on resources in your Amazon Web Services account. These are also known as control
        /// plane operations. For more information, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-management-events-with-cloudtrail.html#logging-management-events">Logging
        /// management events</a> in the <i>CloudTrail User Guide</i>, and <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-service-event.html#eb-service-event-cloudtrail">Filtering
        /// management events from Amazon Web Services services</a> in the <i><i>Amazon EventBridge
        /// User Guide</i></i>.</para><para>This value is only valid for rules on the <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-what-is-how-it-works-concepts.html#eb-bus-concepts-buses">default</a>
        /// event bus or <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-create-event-bus.html">custom
        /// event buses</a>. It does not apply to <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-saas.html">partner
        /// event buses</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridge.RuleState")]
        public Amazon.EventBridge.RuleState State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of key-value pairs to associate with the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.EventBridge.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.PutRuleResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.PutRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EVBRule (PutRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.PutRuleResponse, WriteEVBRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EventBusName = this.EventBusName;
            context.EventPattern = this.EventPattern;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.ScheduleExpression = this.ScheduleExpression;
            context.State = this.State;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.EventBridge.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.EventBridge.Model.PutRuleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventBusName != null)
            {
                request.EventBusName = cmdletContext.EventBusName;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.EventBridge.Model.PutRuleResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.PutRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "PutRule");
            try
            {
                #if DESKTOP
                return client.PutRule(request);
                #elif CORECLR
                return client.PutRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EventBusName { get; set; }
            public System.String EventPattern { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String ScheduleExpression { get; set; }
            public Amazon.EventBridge.RuleState State { get; set; }
            public List<Amazon.EventBridge.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.EventBridge.Model.PutRuleResponse, WriteEVBRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleArn;
        }
        
    }
}
