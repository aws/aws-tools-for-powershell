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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Updates the properties of the specified firewall policy.
    /// </summary>
    [Cmdlet("Update", "NWFWFirewallPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateFirewallPolicy API operation.", Operation = new[] {"UpdateFirewallPolicy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWFirewallPolicyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the firewall policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want Network Firewall to just check the validity of the request,
        /// rather than run the request. </para><para>If set to <c>TRUE</c>, Network Firewall checks whether the request can run successfully,
        /// but doesn't actually make the requested changes. The call returns the value that the
        /// request would return if you ran it with dry run set to <c>FALSE</c>, but doesn't make
        /// additions or changes to your resources. This option allows you to make sure that you
        /// have the required permissions to run the request and that your request parameters
        /// are valid. </para><para>If set to <c>FALSE</c>, Network Firewall makes the requested changes to your resources.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall policy.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyArn { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall policy. You can't change the name of a firewall
        /// policy after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyName { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Key Management Service (KMS) customer managed key.
        /// You can use any of the key identifiers that KMS supports, unless you're using a key
        /// that's managed by another account. If you're using a key managed by another account,
        /// then specify the key ARN. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// ID</a> in the <i>Amazon Web Services KMS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter StatefulEngineOptions_RuleOrder
        /// <summary>
        /// <para>
        /// <para>Indicates how to manage the order of stateful rule evaluation for the policy. <c>STRICT_ORDER</c>
        /// is the default and recommended option. With <c>STRICT_ORDER</c>, provide your rules
        /// in the order that you want them to be evaluated. You can then choose one or more default
        /// actions for packets that don't match any rules. Choose <c>STRICT_ORDER</c> to have
        /// the stateful rules engine determine the evaluation order of your rules. The default
        /// action for this rule order is <c>PASS</c>, followed by <c>DROP</c>, <c>REJECT</c>,
        /// and <c>ALERT</c> actions. Stateful rules are provided to the rule engine as Suricata
        /// compatible strings, and Suricata evaluates them based on your settings. For more information,
        /// see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/suricata-rule-evaluation-order.html">Evaluation
        /// order for stateful rules</a> in the <i>Network Firewall Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulEngineOptions_RuleOrder")]
        [AWSConstantClassSource("Amazon.NetworkFirewall.RuleOrder")]
        public Amazon.NetworkFirewall.RuleOrder StatefulEngineOptions_RuleOrder { get; set; }
        #endregion
        
        #region Parameter PolicyVariables_RuleVariable
        /// <summary>
        /// <para>
        /// <para>The IPv4 or IPv6 addresses in CIDR notation to use for the Suricata <c>HOME_NET</c>
        /// variable. If your firewall uses an inspection VPC, you might want to override the
        /// <c>HOME_NET</c> variable with the CIDRs of your home networks. If you don't override
        /// <c>HOME_NET</c> with your own CIDRs, Network Firewall by default uses the CIDR of
        /// your inspection VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_PolicyVariables_RuleVariables")]
        public System.Collections.Hashtable PolicyVariables_RuleVariable { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatefulDefaultAction
        /// <summary>
        /// <para>
        /// <para>The default actions to take on a packet that doesn't match any stateful rules. The
        /// stateful default action is optional, and is only valid when using the strict rule
        /// order.</para><para>Valid values of the stateful default action:</para><ul><li><para>aws:drop_strict</para></li><li><para>aws:drop_established</para></li><li><para>aws:alert_strict</para></li><li><para>aws:alert_established</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/suricata-rule-evaluation-order.html#suricata-strict-rule-evaluation-order.html">Strict
        /// evaluation order</a> in the <i>Network Firewall Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulDefaultActions")]
        public System.String[] FirewallPolicy_StatefulDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatefulRuleGroupReference
        /// <summary>
        /// <para>
        /// <para>References to the stateful rule groups that are used in the policy. These define the
        /// inspection criteria in stateful rules. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulRuleGroupReferences")]
        public Amazon.NetworkFirewall.Model.StatefulRuleGroupReference[] FirewallPolicy_StatefulRuleGroupReference { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessCustomAction
        /// <summary>
        /// <para>
        /// <para>The custom action definitions that are available for use in the firewall policy's
        /// <c>StatelessDefaultActions</c> setting. You name each custom action that you define,
        /// and then you can use it by name in your default actions specifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatelessCustomActions")]
        public Amazon.NetworkFirewall.Model.CustomAction[] FirewallPolicy_StatelessCustomAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessDefaultAction
        /// <summary>
        /// <para>
        /// <para>The actions to take on a packet if it doesn't match any of the stateless rules in
        /// the policy. If you want non-matching packets to be forwarded for stateful inspection,
        /// specify <c>aws:forward_to_sfe</c>. </para><para>You must specify one of the standard actions: <c>aws:pass</c>, <c>aws:drop</c>, or
        /// <c>aws:forward_to_sfe</c>. In addition, you can specify custom actions that are compatible
        /// with your standard section choice.</para><para>For example, you could specify <c>["aws:pass"]</c> or you could specify <c>["aws:pass",
        /// “customActionName”]</c>. For information about compatibility, see the custom action
        /// descriptions under <a>CustomAction</a>.</para>
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
        [Alias("FirewallPolicy_StatelessDefaultActions")]
        public System.String[] FirewallPolicy_StatelessDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessFragmentDefaultAction
        /// <summary>
        /// <para>
        /// <para>The actions to take on a fragmented UDP packet if it doesn't match any of the stateless
        /// rules in the policy. Network Firewall only manages UDP packet fragments and silently
        /// drops packet fragments for other protocols. If you want non-matching fragmented UDP
        /// packets to be forwarded for stateful inspection, specify <c>aws:forward_to_sfe</c>.
        /// </para><para>You must specify one of the standard actions: <c>aws:pass</c>, <c>aws:drop</c>, or
        /// <c>aws:forward_to_sfe</c>. In addition, you can specify custom actions that are compatible
        /// with your standard section choice.</para><para>For example, you could specify <c>["aws:pass"]</c> or you could specify <c>["aws:pass",
        /// “customActionName”]</c>. For information about compatibility, see the custom action
        /// descriptions under <a>CustomAction</a>.</para>
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
        [Alias("FirewallPolicy_StatelessFragmentDefaultActions")]
        public System.String[] FirewallPolicy_StatelessFragmentDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_StatelessRuleGroupReference
        /// <summary>
        /// <para>
        /// <para>References to the stateless rule groups that are used in the policy. These define
        /// the matching criteria in stateless rules. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatelessRuleGroupReferences")]
        public Amazon.NetworkFirewall.Model.StatelessRuleGroupReference[] FirewallPolicy_StatelessRuleGroupReference { get; set; }
        #endregion
        
        #region Parameter StatefulEngineOptions_StreamExceptionPolicy
        /// <summary>
        /// <para>
        /// <para>Configures how Network Firewall processes traffic when a network connection breaks
        /// midstream. Network connections can break due to disruptions in external networks or
        /// within the firewall itself.</para><ul><li><para><c>DROP</c> - Network Firewall fails closed and drops all subsequent traffic going
        /// to the firewall. This is the default behavior.</para></li><li><para><c>CONTINUE</c> - Network Firewall continues to apply rules to the subsequent traffic
        /// without context from traffic before the break. This impacts the behavior of rules
        /// that depend on this context. For example, if you have a stateful rule to <c>drop http</c>
        /// traffic, Network Firewall won't match the traffic for this rule because the service
        /// won't have the context from session initialization defining the application layer
        /// protocol as HTTP. However, this behavior is rule dependent—a TCP-layer rule using
        /// a <c>flow:stateless</c> rule would still match, as would the <c>aws:drop_strict</c>
        /// default action.</para></li><li><para><c>REJECT</c> - Network Firewall fails closed and drops all subsequent traffic going
        /// to the firewall. Network Firewall also sends a TCP reject packet back to your client
        /// so that the client can immediately establish a new session. Network Firewall will
        /// have context about the new session and will apply rules to the subsequent traffic.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulEngineOptions_StreamExceptionPolicy")]
        [AWSConstantClassSource("Amazon.NetworkFirewall.StreamExceptionPolicy")]
        public Amazon.NetworkFirewall.StreamExceptionPolicy StatefulEngineOptions_StreamExceptionPolicy { get; set; }
        #endregion
        
        #region Parameter FlowTimeouts_TcpIdleTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds that can pass without any TCP traffic sent through the firewall
        /// before the firewall determines that the connection is idle. After the idle timeout
        /// passes, data packets are dropped, however, the next TCP SYN packet is considered a
        /// new flow and is processed by the firewall. Clients or targets can use TCP keepalive
        /// packets to reset the idle timeout. </para><para>You can define the <c>TcpIdleTimeoutSeconds</c> value to be between 60 and 6000 seconds.
        /// If no value is provided, it defaults to 350 seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicy_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSeconds")]
        public System.Int32? FlowTimeouts_TcpIdleTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter FirewallPolicy_TLSInspectionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the TLS inspection configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicy_TLSInspectionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services KMS key to use for encryption of your Network Firewall
        /// resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.EncryptionType")]
        public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. Network Firewall returns a token to your requests
        /// that access the firewall policy. The token marks the state of the policy resource
        /// at the time of the request. </para><para>To make changes to the policy, you provide the token in your request. Network Firewall
        /// uses the token to ensure that the policy hasn't changed since you last retrieved it.
        /// If it has changed, the operation fails with an <c>InvalidTokenException</c>. If this
        /// happens, retrieve the firewall policy again to get a current copy of it with current
        /// token. Reapply your changes as needed, then try the operation again using the new
        /// token. </para>
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
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWFirewallPolicy (UpdateFirewallPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse, UpdateNWFWFirewallPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            if (this.PolicyVariables_RuleVariable != null)
            {
                context.PolicyVariables_RuleVariable = new Dictionary<System.String, Amazon.NetworkFirewall.Model.IPSet>(StringComparer.Ordinal);
                foreach (var hashKey in this.PolicyVariables_RuleVariable.Keys)
                {
                    context.PolicyVariables_RuleVariable.Add((String)hashKey, (Amazon.NetworkFirewall.Model.IPSet)(this.PolicyVariables_RuleVariable[hashKey]));
                }
            }
            if (this.FirewallPolicy_StatefulDefaultAction != null)
            {
                context.FirewallPolicy_StatefulDefaultAction = new List<System.String>(this.FirewallPolicy_StatefulDefaultAction);
            }
            context.FlowTimeouts_TcpIdleTimeoutSecond = this.FlowTimeouts_TcpIdleTimeoutSecond;
            context.StatefulEngineOptions_RuleOrder = this.StatefulEngineOptions_RuleOrder;
            context.StatefulEngineOptions_StreamExceptionPolicy = this.StatefulEngineOptions_StreamExceptionPolicy;
            if (this.FirewallPolicy_StatefulRuleGroupReference != null)
            {
                context.FirewallPolicy_StatefulRuleGroupReference = new List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference>(this.FirewallPolicy_StatefulRuleGroupReference);
            }
            if (this.FirewallPolicy_StatelessCustomAction != null)
            {
                context.FirewallPolicy_StatelessCustomAction = new List<Amazon.NetworkFirewall.Model.CustomAction>(this.FirewallPolicy_StatelessCustomAction);
            }
            if (this.FirewallPolicy_StatelessDefaultAction != null)
            {
                context.FirewallPolicy_StatelessDefaultAction = new List<System.String>(this.FirewallPolicy_StatelessDefaultAction);
            }
            #if MODULAR
            if (this.FirewallPolicy_StatelessDefaultAction == null && ParameterWasBound(nameof(this.FirewallPolicy_StatelessDefaultAction)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicy_StatelessDefaultAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FirewallPolicy_StatelessFragmentDefaultAction != null)
            {
                context.FirewallPolicy_StatelessFragmentDefaultAction = new List<System.String>(this.FirewallPolicy_StatelessFragmentDefaultAction);
            }
            #if MODULAR
            if (this.FirewallPolicy_StatelessFragmentDefaultAction == null && ParameterWasBound(nameof(this.FirewallPolicy_StatelessFragmentDefaultAction)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicy_StatelessFragmentDefaultAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FirewallPolicy_StatelessRuleGroupReference != null)
            {
                context.FirewallPolicy_StatelessRuleGroupReference = new List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference>(this.FirewallPolicy_StatelessRuleGroupReference);
            }
            context.FirewallPolicy_TLSInspectionConfigurationArn = this.FirewallPolicy_TLSInspectionConfigurationArn;
            context.FirewallPolicyArn = this.FirewallPolicyArn;
            context.FirewallPolicyName = this.FirewallPolicyName;
            context.UpdateToken = this.UpdateToken;
            #if MODULAR
            if (this.UpdateToken == null && ParameterWasBound(nameof(this.UpdateToken)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.UpdateFirewallPolicyRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.NetworkFirewall.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KeyId = null;
            if (cmdletContext.EncryptionConfiguration_KeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KeyId = cmdletContext.EncryptionConfiguration_KeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KeyId != null)
            {
                request.EncryptionConfiguration.KeyId = requestEncryptionConfiguration_encryptionConfiguration_KeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.NetworkFirewall.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate FirewallPolicy
            var requestFirewallPolicyIsNull = true;
            request.FirewallPolicy = new Amazon.NetworkFirewall.Model.FirewallPolicy();
            List<System.String> requestFirewallPolicy_firewallPolicy_StatefulDefaultAction = null;
            if (cmdletContext.FirewallPolicy_StatefulDefaultAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulDefaultAction = cmdletContext.FirewallPolicy_StatefulDefaultAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulDefaultAction != null)
            {
                request.FirewallPolicy.StatefulDefaultActions = requestFirewallPolicy_firewallPolicy_StatefulDefaultAction;
                requestFirewallPolicyIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference> requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference = null;
            if (cmdletContext.FirewallPolicy_StatefulRuleGroupReference != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference = cmdletContext.FirewallPolicy_StatefulRuleGroupReference;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference != null)
            {
                request.FirewallPolicy.StatefulRuleGroupReferences = requestFirewallPolicy_firewallPolicy_StatefulRuleGroupReference;
                requestFirewallPolicyIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.CustomAction> requestFirewallPolicy_firewallPolicy_StatelessCustomAction = null;
            if (cmdletContext.FirewallPolicy_StatelessCustomAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessCustomAction = cmdletContext.FirewallPolicy_StatelessCustomAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessCustomAction != null)
            {
                request.FirewallPolicy.StatelessCustomActions = requestFirewallPolicy_firewallPolicy_StatelessCustomAction;
                requestFirewallPolicyIsNull = false;
            }
            List<System.String> requestFirewallPolicy_firewallPolicy_StatelessDefaultAction = null;
            if (cmdletContext.FirewallPolicy_StatelessDefaultAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessDefaultAction = cmdletContext.FirewallPolicy_StatelessDefaultAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessDefaultAction != null)
            {
                request.FirewallPolicy.StatelessDefaultActions = requestFirewallPolicy_firewallPolicy_StatelessDefaultAction;
                requestFirewallPolicyIsNull = false;
            }
            List<System.String> requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction = null;
            if (cmdletContext.FirewallPolicy_StatelessFragmentDefaultAction != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction = cmdletContext.FirewallPolicy_StatelessFragmentDefaultAction;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction != null)
            {
                request.FirewallPolicy.StatelessFragmentDefaultActions = requestFirewallPolicy_firewallPolicy_StatelessFragmentDefaultAction;
                requestFirewallPolicyIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference> requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference = null;
            if (cmdletContext.FirewallPolicy_StatelessRuleGroupReference != null)
            {
                requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference = cmdletContext.FirewallPolicy_StatelessRuleGroupReference;
            }
            if (requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference != null)
            {
                request.FirewallPolicy.StatelessRuleGroupReferences = requestFirewallPolicy_firewallPolicy_StatelessRuleGroupReference;
                requestFirewallPolicyIsNull = false;
            }
            System.String requestFirewallPolicy_firewallPolicy_TLSInspectionConfigurationArn = null;
            if (cmdletContext.FirewallPolicy_TLSInspectionConfigurationArn != null)
            {
                requestFirewallPolicy_firewallPolicy_TLSInspectionConfigurationArn = cmdletContext.FirewallPolicy_TLSInspectionConfigurationArn;
            }
            if (requestFirewallPolicy_firewallPolicy_TLSInspectionConfigurationArn != null)
            {
                request.FirewallPolicy.TLSInspectionConfigurationArn = requestFirewallPolicy_firewallPolicy_TLSInspectionConfigurationArn;
                requestFirewallPolicyIsNull = false;
            }
            Amazon.NetworkFirewall.Model.PolicyVariables requestFirewallPolicy_firewallPolicy_PolicyVariables = null;
            
             // populate PolicyVariables
            var requestFirewallPolicy_firewallPolicy_PolicyVariablesIsNull = true;
            requestFirewallPolicy_firewallPolicy_PolicyVariables = new Amazon.NetworkFirewall.Model.PolicyVariables();
            Dictionary<System.String, Amazon.NetworkFirewall.Model.IPSet> requestFirewallPolicy_firewallPolicy_PolicyVariables_policyVariables_RuleVariable = null;
            if (cmdletContext.PolicyVariables_RuleVariable != null)
            {
                requestFirewallPolicy_firewallPolicy_PolicyVariables_policyVariables_RuleVariable = cmdletContext.PolicyVariables_RuleVariable;
            }
            if (requestFirewallPolicy_firewallPolicy_PolicyVariables_policyVariables_RuleVariable != null)
            {
                requestFirewallPolicy_firewallPolicy_PolicyVariables.RuleVariables = requestFirewallPolicy_firewallPolicy_PolicyVariables_policyVariables_RuleVariable;
                requestFirewallPolicy_firewallPolicy_PolicyVariablesIsNull = false;
            }
             // determine if requestFirewallPolicy_firewallPolicy_PolicyVariables should be set to null
            if (requestFirewallPolicy_firewallPolicy_PolicyVariablesIsNull)
            {
                requestFirewallPolicy_firewallPolicy_PolicyVariables = null;
            }
            if (requestFirewallPolicy_firewallPolicy_PolicyVariables != null)
            {
                request.FirewallPolicy.PolicyVariables = requestFirewallPolicy_firewallPolicy_PolicyVariables;
                requestFirewallPolicyIsNull = false;
            }
            Amazon.NetworkFirewall.Model.StatefulEngineOptions requestFirewallPolicy_firewallPolicy_StatefulEngineOptions = null;
            
             // populate StatefulEngineOptions
            var requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull = true;
            requestFirewallPolicy_firewallPolicy_StatefulEngineOptions = new Amazon.NetworkFirewall.Model.StatefulEngineOptions();
            Amazon.NetworkFirewall.RuleOrder requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder = null;
            if (cmdletContext.StatefulEngineOptions_RuleOrder != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder = cmdletContext.StatefulEngineOptions_RuleOrder;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions.RuleOrder = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_RuleOrder;
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull = false;
            }
            Amazon.NetworkFirewall.StreamExceptionPolicy requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_StreamExceptionPolicy = null;
            if (cmdletContext.StatefulEngineOptions_StreamExceptionPolicy != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_StreamExceptionPolicy = cmdletContext.StatefulEngineOptions_StreamExceptionPolicy;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_StreamExceptionPolicy != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions.StreamExceptionPolicy = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_statefulEngineOptions_StreamExceptionPolicy;
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull = false;
            }
            Amazon.NetworkFirewall.Model.FlowTimeouts requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts = null;
            
             // populate FlowTimeouts
            var requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeoutsIsNull = true;
            requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts = new Amazon.NetworkFirewall.Model.FlowTimeouts();
            System.Int32? requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts_flowTimeouts_TcpIdleTimeoutSecond = null;
            if (cmdletContext.FlowTimeouts_TcpIdleTimeoutSecond != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts_flowTimeouts_TcpIdleTimeoutSecond = cmdletContext.FlowTimeouts_TcpIdleTimeoutSecond.Value;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts_flowTimeouts_TcpIdleTimeoutSecond != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts.TcpIdleTimeoutSeconds = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts_flowTimeouts_TcpIdleTimeoutSecond.Value;
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeoutsIsNull = false;
            }
             // determine if requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts should be set to null
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeoutsIsNull)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts = null;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts != null)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions.FlowTimeouts = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions_firewallPolicy_StatefulEngineOptions_FlowTimeouts;
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull = false;
            }
             // determine if requestFirewallPolicy_firewallPolicy_StatefulEngineOptions should be set to null
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptionsIsNull)
            {
                requestFirewallPolicy_firewallPolicy_StatefulEngineOptions = null;
            }
            if (requestFirewallPolicy_firewallPolicy_StatefulEngineOptions != null)
            {
                request.FirewallPolicy.StatefulEngineOptions = requestFirewallPolicy_firewallPolicy_StatefulEngineOptions;
                requestFirewallPolicyIsNull = false;
            }
             // determine if request.FirewallPolicy should be set to null
            if (requestFirewallPolicyIsNull)
            {
                request.FirewallPolicy = null;
            }
            if (cmdletContext.FirewallPolicyArn != null)
            {
                request.FirewallPolicyArn = cmdletContext.FirewallPolicyArn;
            }
            if (cmdletContext.FirewallPolicyName != null)
            {
                request.FirewallPolicyName = cmdletContext.FirewallPolicyName;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
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
        
        private Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateFirewallPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateFirewallPolicy");
            try
            {
                return client.UpdateFirewallPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String EncryptionConfiguration_KeyId { get; set; }
            public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
            public Dictionary<System.String, Amazon.NetworkFirewall.Model.IPSet> PolicyVariables_RuleVariable { get; set; }
            public List<System.String> FirewallPolicy_StatefulDefaultAction { get; set; }
            public System.Int32? FlowTimeouts_TcpIdleTimeoutSecond { get; set; }
            public Amazon.NetworkFirewall.RuleOrder StatefulEngineOptions_RuleOrder { get; set; }
            public Amazon.NetworkFirewall.StreamExceptionPolicy StatefulEngineOptions_StreamExceptionPolicy { get; set; }
            public List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference> FirewallPolicy_StatefulRuleGroupReference { get; set; }
            public List<Amazon.NetworkFirewall.Model.CustomAction> FirewallPolicy_StatelessCustomAction { get; set; }
            public List<System.String> FirewallPolicy_StatelessDefaultAction { get; set; }
            public List<System.String> FirewallPolicy_StatelessFragmentDefaultAction { get; set; }
            public List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference> FirewallPolicy_StatelessRuleGroupReference { get; set; }
            public System.String FirewallPolicy_TLSInspectionConfigurationArn { get; set; }
            public System.String FirewallPolicyArn { get; set; }
            public System.String FirewallPolicyName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse, UpdateNWFWFirewallPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
