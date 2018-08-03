/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Creates a rule for the specified listener. The listener must be associated with an
    /// Application Load Balancer.
    /// 
    ///  
    /// <para>
    /// Rules are evaluated in priority order, from the lowest value to the highest value.
    /// When the conditions for a rule are met, its actions are performed. If the conditions
    /// for no rules are met, the actions for the default rule are performed. For more information,
    /// see <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-listeners.html#listener-rules">Listener
    /// Rules</a> in the <i>Application Load Balancers Guide</i>.
    /// </para><para>
    /// To view your current rules, use <a>DescribeRules</a>. To update a rule, use <a>ModifyRule</a>.
    /// To set the priorities of your rules, use <a>SetRulePriorities</a>. To delete a rule,
    /// use <a>DeleteRule</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2Rule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.Rule")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateRule API operation.", Operation = new[] {"CreateRule"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.Rule",
        "This cmdlet returns a collection of Rule objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewELB2RuleCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions. Each rule must include exactly one of the following types of actions:
        /// <code>forward</code>, <code>fixed-response</code>, or <code>redirect</code>.</para><para>If the action type is <code>forward</code>, you can specify a single target group.</para><para>[HTTPS listener] If the action type is <code>authenticate-oidc</code>, you can use
        /// an identity provider that is OpenID Connect (OIDC) compliant to authenticate users
        /// as they access your application.</para><para>[HTTPS listener] If the action type is <code>authenticate-cognito</code>, you can
        /// use Amazon Cognito to authenticate users as they access your application.</para><para>[Application Load Balancer] If the action type is <code>redirect</code>, you can redirect
        /// HTTP and HTTPS requests.</para><para>[Application Load Balancer] If the action type is <code>fixed-response</code>, you
        /// can return a custom HTTP response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Actions")]
        public Amazon.ElasticLoadBalancingV2.Model.Action[] Action { get; set; }
        #endregion
        
        #region Parameter Condition
        /// <summary>
        /// <para>
        /// <para>The conditions. Each condition specifies a field name and a single value.</para><para>If the field name is <code>host-header</code>, you can specify a single host name
        /// (for example, my.example.com). A host name is case insensitive, can be up to 128 characters
        /// in length, and can contain any of the following characters. You can include up to
        /// three wildcard characters.</para><ul><li><para>A-Z, a-z, 0-9</para></li><li><para>- .</para></li><li><para>* (matches 0 or more characters)</para></li><li><para>? (matches exactly 1 character)</para></li></ul><para>If the field name is <code>path-pattern</code>, you can specify a single path pattern.
        /// A path pattern is case-sensitive, can be up to 128 characters in length, and can contain
        /// any of the following characters. You can include up to three wildcard characters.</para><ul><li><para>A-Z, a-z, 0-9</para></li><li><para>_ - . $ / ~ " ' @ : +</para></li><li><para>&amp; (using &amp;amp;)</para></li><li><para>* (matches 0 or more characters)</para></li><li><para>? (matches exactly 1 character)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Conditions")]
        public Amazon.ElasticLoadBalancingV2.Model.RuleCondition[] Condition { get; set; }
        #endregion
        
        #region Parameter ListenerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ListenerArn { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The rule priority. A listener can't have multiple rules with the same priority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Priority { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ListenerArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELB2Rule (CreateRule)"))
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
            
            if (this.Action != null)
            {
                context.Actions = new List<Amazon.ElasticLoadBalancingV2.Model.Action>(this.Action);
            }
            if (this.Condition != null)
            {
                context.Conditions = new List<Amazon.ElasticLoadBalancingV2.Model.RuleCondition>(this.Condition);
            }
            context.ListenerArn = this.ListenerArn;
            if (ParameterWasBound("Priority"))
                context.Priority = this.Priority;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.CreateRuleRequest();
            
            if (cmdletContext.Actions != null)
            {
                request.Actions = cmdletContext.Actions;
            }
            if (cmdletContext.Conditions != null)
            {
                request.Conditions = cmdletContext.Conditions;
            }
            if (cmdletContext.ListenerArn != null)
            {
                request.ListenerArn = cmdletContext.ListenerArn;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Rules;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.CreateRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "CreateRule");
            try
            {
                #if DESKTOP
                return client.CreateRule(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRuleAsync(request);
                return task.Result;
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
            public List<Amazon.ElasticLoadBalancingV2.Model.Action> Actions { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.RuleCondition> Conditions { get; set; }
            public System.String ListenerArn { get; set; }
            public System.Int32? Priority { get; set; }
        }
        
    }
}
