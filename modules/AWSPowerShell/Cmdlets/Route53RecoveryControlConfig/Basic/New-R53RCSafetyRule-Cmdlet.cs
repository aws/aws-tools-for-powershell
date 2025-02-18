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
using System.Threading;
using Amazon.Route53RecoveryControlConfig;
using Amazon.Route53RecoveryControlConfig.Model;

namespace Amazon.PowerShell.Cmdlets.R53RC
{
    /// <summary>
    /// Creates a safety rule in a control panel. Safety rules let you add safeguards around
    /// changing routing control states, and for enabling and disabling routing controls,
    /// to help prevent unexpected outcomes.
    /// 
    ///  
    /// <para>
    /// There are two types of safety rules: assertion rules and gating rules.
    /// </para><para>
    /// Assertion rule: An assertion rule enforces that, when you change a routing control
    /// state, that a certain criteria is met. For example, the criteria might be that at
    /// least one routing control state is On after the transaction so that traffic continues
    /// to flow to at least one cell for the application. This ensures that you avoid a fail-open
    /// scenario.
    /// </para><para>
    /// Gating rule: A gating rule lets you configure a gating routing control as an overall
    /// "on/off" switch for a group of routing controls. Or, you can configure more complex
    /// gating scenarios, for example by configuring multiple gating routing controls.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.safety-rules.html">Safety
    /// rules</a> in the Amazon Route 53 Application Recovery Controller Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53RCSafetyRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Control Config CreateSafetyRule API operation.", Operation = new[] {"CreateSafetyRule"}, SelectReturnType = typeof(Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse",
        "This cmdlet returns an Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse object containing multiple properties."
    )]
    public partial class NewR53RCSafetyRuleCmdlet : AmazonRoute53RecoveryControlConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssertionRule_AssertedControl
        /// <summary>
        /// <para>
        /// <para>The routing controls that are part of transactions that are evaluated to determine
        /// if a request to change a routing control state is allowed. For example, you might
        /// include three routing controls, one for each of three Amazon Web Services Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssertionRule_AssertedControls")]
        public System.String[] AssertionRule_AssertedControl { get; set; }
        #endregion
        
        #region Parameter AssertionRule_ControlPanelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the control panel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssertionRule_ControlPanelArn { get; set; }
        #endregion
        
        #region Parameter GatingRule_ControlPanelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the control panel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatingRule_ControlPanelArn { get; set; }
        #endregion
        
        #region Parameter GatingRule_GatingControl
        /// <summary>
        /// <para>
        /// <para>The gating controls for the new gating rule. That is, routing controls that are evaluated
        /// by the rule configuration that you specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatingRule_GatingControls")]
        public System.String[] GatingRule_GatingControl { get; set; }
        #endregion
        
        #region Parameter AssertionRule_RuleConfig_Inverted
        /// <summary>
        /// <para>
        /// <para>Logical negation of the rule. If the rule would usually evaluate true, it's evaluated
        /// as false, and vice versa.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssertionRule_RuleConfig_Inverted { get; set; }
        #endregion
        
        #region Parameter GatingRule_RuleConfig_Inverted
        /// <summary>
        /// <para>
        /// <para>Logical negation of the rule. If the rule would usually evaluate true, it's evaluated
        /// as false, and vice versa.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GatingRule_RuleConfig_Inverted { get; set; }
        #endregion
        
        #region Parameter AssertionRule_Name
        /// <summary>
        /// <para>
        /// <para>The name of the assertion rule. You can use any non-white space character in the name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssertionRule_Name { get; set; }
        #endregion
        
        #region Parameter GatingRule_Name
        /// <summary>
        /// <para>
        /// <para>The name for the new gating rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatingRule_Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the safety rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter GatingRule_TargetControl
        /// <summary>
        /// <para>
        /// <para>Routing controls that can only be set or unset if the specified RuleConfig evaluates
        /// to true for the specified GatingControls. For example, say you have three gating controls,
        /// one for each of three Amazon Web Services Regions. Now you specify ATLEAST 2 as your
        /// RuleConfig. With these settings, you can only change (set or unset) the routing controls
        /// that you have specified as TargetControls if that rule evaluates to true.</para><para>In other words, your ability to change the routing controls that you have specified
        /// as TargetControls is gated by the rule that you set for the routing controls in GatingControls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatingRule_TargetControls")]
        public System.String[] GatingRule_TargetControl { get; set; }
        #endregion
        
        #region Parameter AssertionRule_RuleConfig_Threshold
        /// <summary>
        /// <para>
        /// <para>The value of N, when you specify an ATLEAST rule type. That is, Threshold is the number
        /// of controls that must be set when you specify an ATLEAST type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AssertionRule_RuleConfig_Threshold { get; set; }
        #endregion
        
        #region Parameter GatingRule_RuleConfig_Threshold
        /// <summary>
        /// <para>
        /// <para>The value of N, when you specify an ATLEAST rule type. That is, Threshold is the number
        /// of controls that must be set when you specify an ATLEAST type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GatingRule_RuleConfig_Threshold { get; set; }
        #endregion
        
        #region Parameter AssertionRule_RuleConfig_Type
        /// <summary>
        /// <para>
        /// <para>A rule can be one of the following: ATLEAST, AND, or OR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53RecoveryControlConfig.RuleType")]
        public Amazon.Route53RecoveryControlConfig.RuleType AssertionRule_RuleConfig_Type { get; set; }
        #endregion
        
        #region Parameter GatingRule_RuleConfig_Type
        /// <summary>
        /// <para>
        /// <para>A rule can be one of the following: ATLEAST, AND, or OR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53RecoveryControlConfig.RuleType")]
        public Amazon.Route53RecoveryControlConfig.RuleType GatingRule_RuleConfig_Type { get; set; }
        #endregion
        
        #region Parameter AssertionRule_WaitPeriodMs
        /// <summary>
        /// <para>
        /// <para>An evaluation period, in milliseconds (ms), during which any request against the target
        /// routing controls will fail. This helps prevent "flapping" of state. The wait period
        /// is 5000 ms by default, but you can choose a custom value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AssertionRule_WaitPeriodMs { get; set; }
        #endregion
        
        #region Parameter GatingRule_WaitPeriodMs
        /// <summary>
        /// <para>
        /// <para>An evaluation period, in milliseconds (ms), during which any request against the target
        /// routing controls will fail. This helps prevent "flapping" of state. The wait period
        /// is 5000 ms by default, but you can choose a custom value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GatingRule_WaitPeriodMs { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive string of up to 64 ASCII characters. To make an idempotent
        /// API request with an action, specify a client token in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53RCSafetyRule (CreateSafetyRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse, NewR53RCSafetyRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssertionRule_AssertedControl != null)
            {
                context.AssertionRule_AssertedControl = new List<System.String>(this.AssertionRule_AssertedControl);
            }
            context.AssertionRule_ControlPanelArn = this.AssertionRule_ControlPanelArn;
            context.AssertionRule_Name = this.AssertionRule_Name;
            context.AssertionRule_RuleConfig_Inverted = this.AssertionRule_RuleConfig_Inverted;
            context.AssertionRule_RuleConfig_Threshold = this.AssertionRule_RuleConfig_Threshold;
            context.AssertionRule_RuleConfig_Type = this.AssertionRule_RuleConfig_Type;
            context.AssertionRule_WaitPeriodMs = this.AssertionRule_WaitPeriodMs;
            context.ClientToken = this.ClientToken;
            context.GatingRule_ControlPanelArn = this.GatingRule_ControlPanelArn;
            if (this.GatingRule_GatingControl != null)
            {
                context.GatingRule_GatingControl = new List<System.String>(this.GatingRule_GatingControl);
            }
            context.GatingRule_Name = this.GatingRule_Name;
            context.GatingRule_RuleConfig_Inverted = this.GatingRule_RuleConfig_Inverted;
            context.GatingRule_RuleConfig_Threshold = this.GatingRule_RuleConfig_Threshold;
            context.GatingRule_RuleConfig_Type = this.GatingRule_RuleConfig_Type;
            if (this.GatingRule_TargetControl != null)
            {
                context.GatingRule_TargetControl = new List<System.String>(this.GatingRule_TargetControl);
            }
            context.GatingRule_WaitPeriodMs = this.GatingRule_WaitPeriodMs;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleRequest();
            
            
             // populate AssertionRule
            var requestAssertionRuleIsNull = true;
            request.AssertionRule = new Amazon.Route53RecoveryControlConfig.Model.NewAssertionRule();
            List<System.String> requestAssertionRule_assertionRule_AssertedControl = null;
            if (cmdletContext.AssertionRule_AssertedControl != null)
            {
                requestAssertionRule_assertionRule_AssertedControl = cmdletContext.AssertionRule_AssertedControl;
            }
            if (requestAssertionRule_assertionRule_AssertedControl != null)
            {
                request.AssertionRule.AssertedControls = requestAssertionRule_assertionRule_AssertedControl;
                requestAssertionRuleIsNull = false;
            }
            System.String requestAssertionRule_assertionRule_ControlPanelArn = null;
            if (cmdletContext.AssertionRule_ControlPanelArn != null)
            {
                requestAssertionRule_assertionRule_ControlPanelArn = cmdletContext.AssertionRule_ControlPanelArn;
            }
            if (requestAssertionRule_assertionRule_ControlPanelArn != null)
            {
                request.AssertionRule.ControlPanelArn = requestAssertionRule_assertionRule_ControlPanelArn;
                requestAssertionRuleIsNull = false;
            }
            System.String requestAssertionRule_assertionRule_Name = null;
            if (cmdletContext.AssertionRule_Name != null)
            {
                requestAssertionRule_assertionRule_Name = cmdletContext.AssertionRule_Name;
            }
            if (requestAssertionRule_assertionRule_Name != null)
            {
                request.AssertionRule.Name = requestAssertionRule_assertionRule_Name;
                requestAssertionRuleIsNull = false;
            }
            System.Int32? requestAssertionRule_assertionRule_WaitPeriodMs = null;
            if (cmdletContext.AssertionRule_WaitPeriodMs != null)
            {
                requestAssertionRule_assertionRule_WaitPeriodMs = cmdletContext.AssertionRule_WaitPeriodMs.Value;
            }
            if (requestAssertionRule_assertionRule_WaitPeriodMs != null)
            {
                request.AssertionRule.WaitPeriodMs = requestAssertionRule_assertionRule_WaitPeriodMs.Value;
                requestAssertionRuleIsNull = false;
            }
            Amazon.Route53RecoveryControlConfig.Model.RuleConfig requestAssertionRule_assertionRule_RuleConfig = null;
            
             // populate RuleConfig
            var requestAssertionRule_assertionRule_RuleConfigIsNull = true;
            requestAssertionRule_assertionRule_RuleConfig = new Amazon.Route53RecoveryControlConfig.Model.RuleConfig();
            System.Boolean? requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Inverted = null;
            if (cmdletContext.AssertionRule_RuleConfig_Inverted != null)
            {
                requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Inverted = cmdletContext.AssertionRule_RuleConfig_Inverted.Value;
            }
            if (requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Inverted != null)
            {
                requestAssertionRule_assertionRule_RuleConfig.Inverted = requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Inverted.Value;
                requestAssertionRule_assertionRule_RuleConfigIsNull = false;
            }
            System.Int32? requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Threshold = null;
            if (cmdletContext.AssertionRule_RuleConfig_Threshold != null)
            {
                requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Threshold = cmdletContext.AssertionRule_RuleConfig_Threshold.Value;
            }
            if (requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Threshold != null)
            {
                requestAssertionRule_assertionRule_RuleConfig.Threshold = requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Threshold.Value;
                requestAssertionRule_assertionRule_RuleConfigIsNull = false;
            }
            Amazon.Route53RecoveryControlConfig.RuleType requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Type = null;
            if (cmdletContext.AssertionRule_RuleConfig_Type != null)
            {
                requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Type = cmdletContext.AssertionRule_RuleConfig_Type;
            }
            if (requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Type != null)
            {
                requestAssertionRule_assertionRule_RuleConfig.Type = requestAssertionRule_assertionRule_RuleConfig_assertionRule_RuleConfig_Type;
                requestAssertionRule_assertionRule_RuleConfigIsNull = false;
            }
             // determine if requestAssertionRule_assertionRule_RuleConfig should be set to null
            if (requestAssertionRule_assertionRule_RuleConfigIsNull)
            {
                requestAssertionRule_assertionRule_RuleConfig = null;
            }
            if (requestAssertionRule_assertionRule_RuleConfig != null)
            {
                request.AssertionRule.RuleConfig = requestAssertionRule_assertionRule_RuleConfig;
                requestAssertionRuleIsNull = false;
            }
             // determine if request.AssertionRule should be set to null
            if (requestAssertionRuleIsNull)
            {
                request.AssertionRule = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate GatingRule
            var requestGatingRuleIsNull = true;
            request.GatingRule = new Amazon.Route53RecoveryControlConfig.Model.NewGatingRule();
            System.String requestGatingRule_gatingRule_ControlPanelArn = null;
            if (cmdletContext.GatingRule_ControlPanelArn != null)
            {
                requestGatingRule_gatingRule_ControlPanelArn = cmdletContext.GatingRule_ControlPanelArn;
            }
            if (requestGatingRule_gatingRule_ControlPanelArn != null)
            {
                request.GatingRule.ControlPanelArn = requestGatingRule_gatingRule_ControlPanelArn;
                requestGatingRuleIsNull = false;
            }
            List<System.String> requestGatingRule_gatingRule_GatingControl = null;
            if (cmdletContext.GatingRule_GatingControl != null)
            {
                requestGatingRule_gatingRule_GatingControl = cmdletContext.GatingRule_GatingControl;
            }
            if (requestGatingRule_gatingRule_GatingControl != null)
            {
                request.GatingRule.GatingControls = requestGatingRule_gatingRule_GatingControl;
                requestGatingRuleIsNull = false;
            }
            System.String requestGatingRule_gatingRule_Name = null;
            if (cmdletContext.GatingRule_Name != null)
            {
                requestGatingRule_gatingRule_Name = cmdletContext.GatingRule_Name;
            }
            if (requestGatingRule_gatingRule_Name != null)
            {
                request.GatingRule.Name = requestGatingRule_gatingRule_Name;
                requestGatingRuleIsNull = false;
            }
            List<System.String> requestGatingRule_gatingRule_TargetControl = null;
            if (cmdletContext.GatingRule_TargetControl != null)
            {
                requestGatingRule_gatingRule_TargetControl = cmdletContext.GatingRule_TargetControl;
            }
            if (requestGatingRule_gatingRule_TargetControl != null)
            {
                request.GatingRule.TargetControls = requestGatingRule_gatingRule_TargetControl;
                requestGatingRuleIsNull = false;
            }
            System.Int32? requestGatingRule_gatingRule_WaitPeriodMs = null;
            if (cmdletContext.GatingRule_WaitPeriodMs != null)
            {
                requestGatingRule_gatingRule_WaitPeriodMs = cmdletContext.GatingRule_WaitPeriodMs.Value;
            }
            if (requestGatingRule_gatingRule_WaitPeriodMs != null)
            {
                request.GatingRule.WaitPeriodMs = requestGatingRule_gatingRule_WaitPeriodMs.Value;
                requestGatingRuleIsNull = false;
            }
            Amazon.Route53RecoveryControlConfig.Model.RuleConfig requestGatingRule_gatingRule_RuleConfig = null;
            
             // populate RuleConfig
            var requestGatingRule_gatingRule_RuleConfigIsNull = true;
            requestGatingRule_gatingRule_RuleConfig = new Amazon.Route53RecoveryControlConfig.Model.RuleConfig();
            System.Boolean? requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Inverted = null;
            if (cmdletContext.GatingRule_RuleConfig_Inverted != null)
            {
                requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Inverted = cmdletContext.GatingRule_RuleConfig_Inverted.Value;
            }
            if (requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Inverted != null)
            {
                requestGatingRule_gatingRule_RuleConfig.Inverted = requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Inverted.Value;
                requestGatingRule_gatingRule_RuleConfigIsNull = false;
            }
            System.Int32? requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Threshold = null;
            if (cmdletContext.GatingRule_RuleConfig_Threshold != null)
            {
                requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Threshold = cmdletContext.GatingRule_RuleConfig_Threshold.Value;
            }
            if (requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Threshold != null)
            {
                requestGatingRule_gatingRule_RuleConfig.Threshold = requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Threshold.Value;
                requestGatingRule_gatingRule_RuleConfigIsNull = false;
            }
            Amazon.Route53RecoveryControlConfig.RuleType requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Type = null;
            if (cmdletContext.GatingRule_RuleConfig_Type != null)
            {
                requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Type = cmdletContext.GatingRule_RuleConfig_Type;
            }
            if (requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Type != null)
            {
                requestGatingRule_gatingRule_RuleConfig.Type = requestGatingRule_gatingRule_RuleConfig_gatingRule_RuleConfig_Type;
                requestGatingRule_gatingRule_RuleConfigIsNull = false;
            }
             // determine if requestGatingRule_gatingRule_RuleConfig should be set to null
            if (requestGatingRule_gatingRule_RuleConfigIsNull)
            {
                requestGatingRule_gatingRule_RuleConfig = null;
            }
            if (requestGatingRule_gatingRule_RuleConfig != null)
            {
                request.GatingRule.RuleConfig = requestGatingRule_gatingRule_RuleConfig;
                requestGatingRuleIsNull = false;
            }
             // determine if request.GatingRule should be set to null
            if (requestGatingRuleIsNull)
            {
                request.GatingRule = null;
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
        
        private Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse CallAWSServiceOperation(IAmazonRoute53RecoveryControlConfig client, Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Control Config", "CreateSafetyRule");
            try
            {
                return client.CreateSafetyRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AssertionRule_AssertedControl { get; set; }
            public System.String AssertionRule_ControlPanelArn { get; set; }
            public System.String AssertionRule_Name { get; set; }
            public System.Boolean? AssertionRule_RuleConfig_Inverted { get; set; }
            public System.Int32? AssertionRule_RuleConfig_Threshold { get; set; }
            public Amazon.Route53RecoveryControlConfig.RuleType AssertionRule_RuleConfig_Type { get; set; }
            public System.Int32? AssertionRule_WaitPeriodMs { get; set; }
            public System.String ClientToken { get; set; }
            public System.String GatingRule_ControlPanelArn { get; set; }
            public List<System.String> GatingRule_GatingControl { get; set; }
            public System.String GatingRule_Name { get; set; }
            public System.Boolean? GatingRule_RuleConfig_Inverted { get; set; }
            public System.Int32? GatingRule_RuleConfig_Threshold { get; set; }
            public Amazon.Route53RecoveryControlConfig.RuleType GatingRule_RuleConfig_Type { get; set; }
            public List<System.String> GatingRule_TargetControl { get; set; }
            public System.Int32? GatingRule_WaitPeriodMs { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Route53RecoveryControlConfig.Model.CreateSafetyRuleResponse, NewR53RCSafetyRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
