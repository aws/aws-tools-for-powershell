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
    /// Each rule consists of a priority, one or more actions, and one or more conditions.
    /// Rules are evaluated in priority order, from the lowest value to the highest value.
    /// When the conditions for a rule are met, its actions are performed. If the conditions
    /// for no rules are met, the actions for the default rule are performed. For more information,
    /// see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-listeners.html#listener-rules">Listener
    /// Rules</a> in the <i>Application Load Balancers Guide</i>.
    /// </para><para>
    /// To view your current rules, use <a>DescribeRules</a>. To update a rule, use <a>ModifyRule</a>.
    /// To set the priorities of your rules, use <a>SetRulePriorities</a>. To delete a rule,
    /// use <a>DeleteRule</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2Rule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.Rule")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateRule API operation.", Operation = new[] {"CreateRule"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.Rule or Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.Rule objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewELB2RuleCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions. Each rule must include exactly one of the following types of actions:
        /// <code>forward</code>, <code>fixed-response</code>, or <code>redirect</code>, and it
        /// must be the last action to be performed.</para><para>If the action type is <code>forward</code>, you specify one or more target groups.
        /// The protocol of the target group must be HTTP or HTTPS for an Application Load Balancer.
        /// The protocol of the target group must be TCP, TLS, UDP, or TCP_UDP for a Network Load
        /// Balancer.</para><para>[HTTPS listeners] If the action type is <code>authenticate-oidc</code>, you authenticate
        /// users through an identity provider that is OpenID Connect (OIDC) compliant.</para><para>[HTTPS listeners] If the action type is <code>authenticate-cognito</code>, you authenticate
        /// users through the user pools supported by Amazon Cognito.</para><para>[Application Load Balancer] If the action type is <code>redirect</code>, you redirect
        /// specified client requests from one URL to another.</para><para>[Application Load Balancer] If the action type is <code>fixed-response</code>, you
        /// drop specified client requests and return a custom HTTP response.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Actions")]
        public Amazon.ElasticLoadBalancingV2.Model.Action[] Action { get; set; }
        #endregion
        
        #region Parameter Condition
        /// <summary>
        /// <para>
        /// <para>The conditions. Each rule can optionally include up to one of each of the following
        /// conditions: <code>http-request-method</code>, <code>host-header</code>, <code>path-pattern</code>,
        /// and <code>source-ip</code>. Each rule can also optionally include one or more of each
        /// of the following conditions: <code>http-header</code> and <code>query-string</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Conditions")]
        public Amazon.ElasticLoadBalancingV2.Model.RuleCondition[] Condition { get; set; }
        #endregion
        
        #region Parameter ListenerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the listener.</para>
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
        public System.String ListenerArn { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The rule priority. A listener can't have multiple rules with the same priority.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rules";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ListenerArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ListenerArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ListenerArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ListenerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELB2Rule (CreateRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse, NewELB2RuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ListenerArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Action != null)
            {
                context.Action = new List<Amazon.ElasticLoadBalancingV2.Model.Action>(this.Action);
            }
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Condition != null)
            {
                context.Condition = new List<Amazon.ElasticLoadBalancingV2.Model.RuleCondition>(this.Condition);
            }
            #if MODULAR
            if (this.Condition == null && ParameterWasBound(nameof(this.Condition)))
            {
                WriteWarning("You are passing $null as a value for parameter Condition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ListenerArn = this.ListenerArn;
            #if MODULAR
            if (this.ListenerArn == null && ParameterWasBound(nameof(this.ListenerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ListenerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Condition != null)
            {
                request.Conditions = cmdletContext.Condition;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.CreateRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "CreateRule");
            try
            {
                #if DESKTOP
                return client.CreateRule(request);
                #elif CORECLR
                return client.CreateRuleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ElasticLoadBalancingV2.Model.Action> Action { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.RuleCondition> Condition { get; set; }
            public System.String ListenerArn { get; set; }
            public System.Int32? Priority { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.CreateRuleResponse, NewELB2RuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rules;
        }
        
    }
}
