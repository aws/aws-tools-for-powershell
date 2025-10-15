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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Replaces the specified properties of the specified rule. Any properties that you do
    /// not specify are unchanged.
    /// 
    ///  
    /// <para>
    /// To add an item to a list, remove an item from a list, or update an item in a list,
    /// you must provide the entire list. For example, to add an action, specify a list with
    /// the current actions plus the new action.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "ELB2Rule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.Rule")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 ModifyRule API operation.", Operation = new[] {"ModifyRule"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.Rule or Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.Rule objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditELB2RuleCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public Amazon.ElasticLoadBalancingV2.Model.Action[] Action { get; set; }
        #endregion
        
        #region Parameter Condition
        /// <summary>
        /// <para>
        /// <para>The conditions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Conditions")]
        public Amazon.ElasticLoadBalancingV2.Model.RuleCondition[] Condition { get; set; }
        #endregion
        
        #region Parameter ResetTransform
        /// <summary>
        /// <para>
        /// <para>Indicates whether to remove all transforms from the rule. If you specify <c>ResetTransforms</c>,
        /// you can't specify <c>Transforms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResetTransforms")]
        public System.Boolean? ResetTransform { get; set; }
        #endregion
        
        #region Parameter RuleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the rule.</para>
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
        public System.String RuleArn { get; set; }
        #endregion
        
        #region Parameter Transform
        /// <summary>
        /// <para>
        /// <para>The transforms to apply to requests that match this rule. You can add one host header
        /// rewrite transform and one URL rewrite transform. If you specify <c>Transforms</c>,
        /// you can't specify <c>ResetTransforms</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Transforms")]
        public Amazon.ElasticLoadBalancingV2.Model.RuleTransform[] Transform { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rules'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rules";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RuleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RuleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RuleArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELB2Rule (ModifyRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse, EditELB2RuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RuleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Action != null)
            {
                context.Action = new List<Amazon.ElasticLoadBalancingV2.Model.Action>(this.Action);
            }
            if (this.Condition != null)
            {
                context.Condition = new List<Amazon.ElasticLoadBalancingV2.Model.RuleCondition>(this.Condition);
            }
            context.ResetTransform = this.ResetTransform;
            context.RuleArn = this.RuleArn;
            #if MODULAR
            if (this.RuleArn == null && ParameterWasBound(nameof(this.RuleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Transform != null)
            {
                context.Transform = new List<Amazon.ElasticLoadBalancingV2.Model.RuleTransform>(this.Transform);
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.ModifyRuleRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Condition != null)
            {
                request.Conditions = cmdletContext.Condition;
            }
            if (cmdletContext.ResetTransform != null)
            {
                request.ResetTransforms = cmdletContext.ResetTransform.Value;
            }
            if (cmdletContext.RuleArn != null)
            {
                request.RuleArn = cmdletContext.RuleArn;
            }
            if (cmdletContext.Transform != null)
            {
                request.Transforms = cmdletContext.Transform;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.ModifyRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "ModifyRule");
            try
            {
                #if DESKTOP
                return client.ModifyRule(request);
                #elif CORECLR
                return client.ModifyRuleAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ResetTransform { get; set; }
            public System.String RuleArn { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.RuleTransform> Transform { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.ModifyRuleResponse, EditELB2RuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rules;
        }
        
    }
}
