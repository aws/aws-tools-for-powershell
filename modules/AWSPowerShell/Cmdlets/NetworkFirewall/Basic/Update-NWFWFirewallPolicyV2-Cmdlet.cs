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
    /// Updates the properties of the specified Next Generation policy.
    /// </summary>
    [Cmdlet("Update", "NWFWFirewallPolicyV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateFirewallPolicyV2 API operation.", Operation = new[] {"UpdateFirewallPolicyV2"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response object containing multiple properties."
    )]
    public partial class UpdateNWFWFirewallPolicyV2Cmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FirewallPolicyV2_Route53ResolvedIPValidation_Action
        /// <summary>
        /// <para>
        /// <para>The action that Network Firewall takes for a connection whose destination IP address
        /// fails resolved IP validation. A destination IP address fails validation when the Route
        /// 53 Resolver didn't return it in a DNS response in an associated VPC. Valid values
        /// are the following:</para><ul><li><para><c>ALERT</c> – Tags the matching connection in the firewall's flow logs without blocking
        /// it, when you enable logging. Use this to observe the effect of resolved IP validation
        /// before you enforce it.</para></li><li><para><c>DROP</c> – Silently blocks the connection without sending any response to the
        /// client.</para></li><li><para><c>REJECT</c> – Blocks the connection and sends a TCP reset (RST) to the client.
        /// Because a TCP reset applies only to TCP connections, Network Firewall drops non-TCP
        /// traffic instead of resetting it.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.Route53ResolvedIPValidationAction")]
        public Amazon.NetworkFirewall.Route53ResolvedIPValidationAction FirewallPolicyV2_Route53ResolvedIPValidation_Action { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange
        /// <summary>
        /// <para>
        /// <para>The destination IP address ranges that are exempt from the policy-level resolved IP
        /// check. Network Firewall doesn't apply the <c>Action</c> in this configuration to a
        /// connection whose destination falls in these ranges, even if the Route 53 Resolver
        /// didn't return that IP address in an associated VPC. Specify each entry as an IPv4
        /// or IPv6 address or CIDR range, up to 100 entries.</para><para>This exemption applies only to the policy-level check. Stateful rules that use the
        /// <c>AWS_ROUTE_53_RESOLVED_DOMAIN</c> target type or the <c>aws_route_53_resolved_domain</c>
        /// keyword still evaluate connections to these destinations and match them independently
        /// of this list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRanges")]
        public Amazon.NetworkFirewall.Model.Address[] FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the firewall policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy
        /// <summary>
        /// <para>
        /// <para>The action that Network Firewall takes when the DNS resolution recorded for a destination
        /// IP address has expired from the resolved IP cache. This applies when Network Firewall
        /// still sees traffic to that IP address after the expiry. Network Firewall keeps a resolution
        /// for longer than the DNS record's time to live (TTL). Valid values are the following:</para><ul><li><para><c>CONTINUE</c> – Treats the expired resolution as still valid and doesn't block
        /// the connection because of expiry.</para></li><li><para><c>DROP</c> – Silently blocks traffic to the IP address after its resolution has
        /// expired, without sending any response to the client.</para></li><li><para><c>REJECT</c> – Blocks traffic to the IP address after its resolution has expired
        /// and sends a TCP reset (RST) to the client. Network Firewall drops non-TCP traffic
        /// instead of resetting it.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.DNSExpiryExceptionPolicy")]
        public Amazon.NetworkFirewall.DNSExpiryExceptionPolicy FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the Route 53 Resolver DNS Firewall rule group that determines which VPCs'
        /// DNS resolutions count for resolved IP validation. A destination IP address counts
        /// as resolved for a domain only when the Route 53 Resolver returned it in a DNS response
        /// within a VPC that's associated with this rule group. Associate the rule group with
        /// the VPCs that send traffic to the firewall. The ID must match the pattern <c>^rslvr-frg-[0-9a-f]+$</c>.
        /// It must also exist and be accessible from your account. Network Firewall validates
        /// this when you create or update the policy.</para><para>Changing this value swaps the managed rule group association. Network Firewall processes
        /// the swap asynchronously. Each policy can have only one managed Route 53 Resolver DNS
        /// Firewall association. While a swap is in progress, Network Firewall rejects further
        /// changes to this setting. Wait until the swap completes, then retry. The change may
        /// also require a restart of the stateful engine. When this occurs, existing connections
        /// will be treated according to your stream exception policy configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId { get; set; }
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
        
        #region Parameter FirewallPolicyV2_FirewallDefaultAction
        /// <summary>
        /// <para>
        /// <para>The action that the firewall engine takes on traffic that doesn't match any firewall
        /// engine rule at a hook. The firewall engine is drop by default. You can set the default
        /// action to one of the following:</para><ul><li><para><c>DROP</c> - Block the traffic.</para></li><li><para><c>ACCEPT</c> - Allow the traffic.</para></li><li><para><c>REJECT</c> - Block the traffic and send a TCP reset packet back to the client.</para></li><li><para><c>ALERT</c> - Allow the traffic and generate an alert log for the traffic that reaches
        /// the default action at every hook. This is distinct from setting the policy mode to
        /// <c>MONITOR</c>.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/firewall-policies-v2.html">Next
        /// Generation policies</a> in the <i>Network Firewall Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.PolicyDefaultAction")]
        public Amazon.NetworkFirewall.PolicyDefaultAction FirewallPolicyV2_FirewallDefaultAction { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Next Generation policy.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyV2Arn { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2Name
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the Next Generation policy. You can't change the name of a
        /// firewall policy after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyV2Name { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_FirewallRuleGroupEntry
        /// <summary>
        /// <para>
        /// <para>The firewall section of the policy—the rule groups that the firewall engine evaluates.
        /// Each entry references an existing firewall engine rule group or embeds a rule group
        /// directly in the policy, and each entry has a unique priority that sets its evaluation
        /// order within the section.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicyV2_FirewallRuleGroupEntries")]
        public Amazon.NetworkFirewall.Model.FirewallRuleGroupEntry[] FirewallPolicyV2_FirewallRuleGroupEntry { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_IpsRuleGroupEntry
        /// <summary>
        /// <para>
        /// <para>The IPS section of the policy—the rule groups that the IPS engine evaluates. Each
        /// entry references an existing IPS engine rule group or embeds a rule group directly
        /// in the policy. IPS section entries don't use a priority.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicyV2_IpsRuleGroupEntries")]
        public Amazon.NetworkFirewall.Model.IpsRuleGroupEntry[] FirewallPolicyV2_IpsRuleGroupEntry { get; set; }
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
        
        #region Parameter FirewallPolicyV2_PolicyMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether the policy's engines enforce their verdicts or only report them.
        /// In <c>ENFORCE</c> mode, the firewall engine and IPS engine apply their verdicts to
        /// traffic. In <c>MONITOR</c> mode, the engines evaluate traffic and generate logs and
        /// metrics, but don't block traffic, so you can observe how a policy would behave before
        /// you enforce it. For more information, see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/firewall-policies-v2.html">Next
        /// Generation policies</a> in the <i>Network Firewall Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.PolicyMode")]
        public Amazon.NetworkFirewall.PolicyMode FirewallPolicyV2_PolicyMode { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_PolicyVariables_RuleVariable
        /// <summary>
        /// <para>
        /// <para>The IPv4 or IPv6 addresses in CIDR notation to use for the Suricata <c>HOME_NET</c>
        /// variable. If your firewall uses an inspection VPC, you might want to override the
        /// <c>HOME_NET</c> variable with the CIDRs of your home networks. If you don't override
        /// <c>HOME_NET</c> with your own CIDRs, Network Firewall by default uses the CIDR of
        /// your inspection VPC.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicyV2_PolicyVariables_RuleVariables")]
        public System.Collections.Hashtable FirewallPolicyV2_PolicyVariables_RuleVariable { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange
        /// <summary>
        /// <para>
        /// <para>The client source IP address ranges whose connections are subject to resolved IP validation.
        /// Specify each entry as an IPv4 or IPv6 address or CIDR range, up to 100 entries. If
        /// you omit this field, resolved IP validation applies to the CIDR ranges of the firewall's
        /// VPC and of any additional VPCs attached to the firewall. Specifying an empty list
        /// is not the same as omitting the field: an empty list means that Network Firewall doesn't
        /// validate any source addresses.</para><para>This scope applies to the policy-level check only. Stateful rules that use the <c>AWS_ROUTE_53_RESOLVED_DOMAIN</c>
        /// target type or the <c>aws_route_53_resolved_domain</c> keyword still evaluate their
        /// destinations regardless of <c>SourceIPRanges</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRanges")]
        public Amazon.NetworkFirewall.Model.Address[] FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy
        /// <summary>
        /// <para>
        /// <para>How Network Firewall handles traffic on a network connection that breaks midstream.
        /// A Next Generation policy supports <c>DROP</c> and <c>REJECT</c>. For more information,
        /// see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/stream-exception-policy.html">Stream
        /// exception policy options in your firewall policy</a> in the <i>Network Firewall Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.StreamExceptionPolicyV2")]
        public Amazon.NetworkFirewall.StreamExceptionPolicyV2 FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond
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
        [Alias("FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSeconds")]
        public System.Int32? FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyV2_TLSInspectionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the TLS inspection configuration to use to decrypt
        /// traffic for inspection. Next Generation policies support session holding only. For
        /// more information, see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/tls-inspection.html">Inspecting
        /// SSL/TLS traffic with TLS inspection configurations</a> in the <i>Network Firewall
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallPolicyV2_TLSInspectionConfigurationArn { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdateToken), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWFirewallPolicyV2 (UpdateFirewallPolicyV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response, UpdateNWFWFirewallPolicyV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            context.FirewallPolicyV2_FirewallDefaultAction = this.FirewallPolicyV2_FirewallDefaultAction;
            if (this.FirewallPolicyV2_FirewallRuleGroupEntry != null)
            {
                context.FirewallPolicyV2_FirewallRuleGroupEntry = new List<Amazon.NetworkFirewall.Model.FirewallRuleGroupEntry>(this.FirewallPolicyV2_FirewallRuleGroupEntry);
            }
            if (this.FirewallPolicyV2_IpsRuleGroupEntry != null)
            {
                context.FirewallPolicyV2_IpsRuleGroupEntry = new List<Amazon.NetworkFirewall.Model.IpsRuleGroupEntry>(this.FirewallPolicyV2_IpsRuleGroupEntry);
            }
            context.FirewallPolicyV2_PolicyMode = this.FirewallPolicyV2_PolicyMode;
            if (this.FirewallPolicyV2_PolicyVariables_RuleVariable != null)
            {
                context.FirewallPolicyV2_PolicyVariables_RuleVariable = new Dictionary<System.String, Amazon.NetworkFirewall.Model.IPSet>(StringComparer.Ordinal);
                foreach (var hashKey in this.FirewallPolicyV2_PolicyVariables_RuleVariable.Keys)
                {
                    context.FirewallPolicyV2_PolicyVariables_RuleVariable.Add((String)hashKey, (Amazon.NetworkFirewall.Model.IPSet)(this.FirewallPolicyV2_PolicyVariables_RuleVariable[hashKey]));
                }
            }
            context.FirewallPolicyV2_Route53ResolvedIPValidation_Action = this.FirewallPolicyV2_Route53ResolvedIPValidation_Action;
            if (this.FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange != null)
            {
                context.FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange = new List<Amazon.NetworkFirewall.Model.Address>(this.FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange);
            }
            context.FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy = this.FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy;
            context.FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId = this.FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId;
            if (this.FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange != null)
            {
                context.FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange = new List<Amazon.NetworkFirewall.Model.Address>(this.FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange);
            }
            context.FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond = this.FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond;
            context.FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy = this.FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy;
            context.FirewallPolicyV2_TLSInspectionConfigurationArn = this.FirewallPolicyV2_TLSInspectionConfigurationArn;
            context.FirewallPolicyV2Arn = this.FirewallPolicyV2Arn;
            context.FirewallPolicyV2Name = this.FirewallPolicyV2Name;
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
            var request = new Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Request();
            
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
            
             // populate FirewallPolicyV2
            var requestFirewallPolicyV2IsNull = true;
            request.FirewallPolicyV2 = new Amazon.NetworkFirewall.Model.FirewallPolicyV2();
            Amazon.NetworkFirewall.PolicyDefaultAction requestFirewallPolicyV2_firewallPolicyV2_FirewallDefaultAction = null;
            if (cmdletContext.FirewallPolicyV2_FirewallDefaultAction != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_FirewallDefaultAction = cmdletContext.FirewallPolicyV2_FirewallDefaultAction;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_FirewallDefaultAction != null)
            {
                request.FirewallPolicyV2.FirewallDefaultAction = requestFirewallPolicyV2_firewallPolicyV2_FirewallDefaultAction;
                requestFirewallPolicyV2IsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.FirewallRuleGroupEntry> requestFirewallPolicyV2_firewallPolicyV2_FirewallRuleGroupEntry = null;
            if (cmdletContext.FirewallPolicyV2_FirewallRuleGroupEntry != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_FirewallRuleGroupEntry = cmdletContext.FirewallPolicyV2_FirewallRuleGroupEntry;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_FirewallRuleGroupEntry != null)
            {
                request.FirewallPolicyV2.FirewallRuleGroupEntries = requestFirewallPolicyV2_firewallPolicyV2_FirewallRuleGroupEntry;
                requestFirewallPolicyV2IsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.IpsRuleGroupEntry> requestFirewallPolicyV2_firewallPolicyV2_IpsRuleGroupEntry = null;
            if (cmdletContext.FirewallPolicyV2_IpsRuleGroupEntry != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_IpsRuleGroupEntry = cmdletContext.FirewallPolicyV2_IpsRuleGroupEntry;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_IpsRuleGroupEntry != null)
            {
                request.FirewallPolicyV2.IpsRuleGroupEntries = requestFirewallPolicyV2_firewallPolicyV2_IpsRuleGroupEntry;
                requestFirewallPolicyV2IsNull = false;
            }
            Amazon.NetworkFirewall.PolicyMode requestFirewallPolicyV2_firewallPolicyV2_PolicyMode = null;
            if (cmdletContext.FirewallPolicyV2_PolicyMode != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_PolicyMode = cmdletContext.FirewallPolicyV2_PolicyMode;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_PolicyMode != null)
            {
                request.FirewallPolicyV2.PolicyMode = requestFirewallPolicyV2_firewallPolicyV2_PolicyMode;
                requestFirewallPolicyV2IsNull = false;
            }
            System.String requestFirewallPolicyV2_firewallPolicyV2_TLSInspectionConfigurationArn = null;
            if (cmdletContext.FirewallPolicyV2_TLSInspectionConfigurationArn != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_TLSInspectionConfigurationArn = cmdletContext.FirewallPolicyV2_TLSInspectionConfigurationArn;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_TLSInspectionConfigurationArn != null)
            {
                request.FirewallPolicyV2.TLSInspectionConfigurationArn = requestFirewallPolicyV2_firewallPolicyV2_TLSInspectionConfigurationArn;
                requestFirewallPolicyV2IsNull = false;
            }
            Amazon.NetworkFirewall.Model.PolicyVariables requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables = null;
            
             // populate PolicyVariables
            var requestFirewallPolicyV2_firewallPolicyV2_PolicyVariablesIsNull = true;
            requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables = new Amazon.NetworkFirewall.Model.PolicyVariables();
            Dictionary<System.String, Amazon.NetworkFirewall.Model.IPSet> requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables_firewallPolicyV2_PolicyVariables_RuleVariable = null;
            if (cmdletContext.FirewallPolicyV2_PolicyVariables_RuleVariable != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables_firewallPolicyV2_PolicyVariables_RuleVariable = cmdletContext.FirewallPolicyV2_PolicyVariables_RuleVariable;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables_firewallPolicyV2_PolicyVariables_RuleVariable != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables.RuleVariables = requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables_firewallPolicyV2_PolicyVariables_RuleVariable;
                requestFirewallPolicyV2_firewallPolicyV2_PolicyVariablesIsNull = false;
            }
             // determine if requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables should be set to null
            if (requestFirewallPolicyV2_firewallPolicyV2_PolicyVariablesIsNull)
            {
                requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables = null;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables != null)
            {
                request.FirewallPolicyV2.PolicyVariables = requestFirewallPolicyV2_firewallPolicyV2_PolicyVariables;
                requestFirewallPolicyV2IsNull = false;
            }
            Amazon.NetworkFirewall.Model.StatefulEngineOptionsV2 requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions = null;
            
             // populate StatefulEngineOptions
            var requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptionsIsNull = true;
            requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions = new Amazon.NetworkFirewall.Model.StatefulEngineOptionsV2();
            Amazon.NetworkFirewall.StreamExceptionPolicyV2 requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy = null;
            if (cmdletContext.FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy = cmdletContext.FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions.StreamExceptionPolicy = requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy;
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptionsIsNull = false;
            }
            Amazon.NetworkFirewall.Model.FlowTimeouts requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts = null;
            
             // populate FlowTimeouts
            var requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeoutsIsNull = true;
            requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts = new Amazon.NetworkFirewall.Model.FlowTimeouts();
            System.Int32? requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond = null;
            if (cmdletContext.FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond = cmdletContext.FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond.Value;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts.TcpIdleTimeoutSeconds = requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond.Value;
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeoutsIsNull = false;
            }
             // determine if requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts should be set to null
            if (requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeoutsIsNull)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts = null;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions.FlowTimeouts = requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions_firewallPolicyV2_StatefulEngineOptions_FlowTimeouts;
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptionsIsNull = false;
            }
             // determine if requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions should be set to null
            if (requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptionsIsNull)
            {
                requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions = null;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions != null)
            {
                request.FirewallPolicyV2.StatefulEngineOptions = requestFirewallPolicyV2_firewallPolicyV2_StatefulEngineOptions;
                requestFirewallPolicyV2IsNull = false;
            }
            Amazon.NetworkFirewall.Model.Route53ResolvedIPValidation requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation = null;
            
             // populate Route53ResolvedIPValidation
            var requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull = true;
            requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation = new Amazon.NetworkFirewall.Model.Route53ResolvedIPValidation();
            Amazon.NetworkFirewall.Route53ResolvedIPValidationAction requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_Action = null;
            if (cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_Action != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_Action = cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_Action;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_Action != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation.Action = requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_Action;
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.Address> requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange = null;
            if (cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange = cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation.BypassDestinationValidationIPRanges = requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange;
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull = false;
            }
            Amazon.NetworkFirewall.DNSExpiryExceptionPolicy requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy = null;
            if (cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy = cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation.DNSExpiryExceptionPolicy = requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy;
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull = false;
            }
            System.String requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId = null;
            if (cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId = cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation.DNSFirewallRuleGroupId = requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId;
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.Address> requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange = null;
            if (cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange = cmdletContext.FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange != null)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation.SourceIPRanges = requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation_firewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange;
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull = false;
            }
             // determine if requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation should be set to null
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidationIsNull)
            {
                requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation = null;
            }
            if (requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation != null)
            {
                request.FirewallPolicyV2.Route53ResolvedIPValidation = requestFirewallPolicyV2_firewallPolicyV2_Route53ResolvedIPValidation;
                requestFirewallPolicyV2IsNull = false;
            }
             // determine if request.FirewallPolicyV2 should be set to null
            if (requestFirewallPolicyV2IsNull)
            {
                request.FirewallPolicyV2 = null;
            }
            if (cmdletContext.FirewallPolicyV2Arn != null)
            {
                request.FirewallPolicyV2Arn = cmdletContext.FirewallPolicyV2Arn;
            }
            if (cmdletContext.FirewallPolicyV2Name != null)
            {
                request.FirewallPolicyV2Name = cmdletContext.FirewallPolicyV2Name;
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
        
        private Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateFirewallPolicyV2");
            try
            {
                return client.UpdateFirewallPolicyV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.NetworkFirewall.PolicyDefaultAction FirewallPolicyV2_FirewallDefaultAction { get; set; }
            public List<Amazon.NetworkFirewall.Model.FirewallRuleGroupEntry> FirewallPolicyV2_FirewallRuleGroupEntry { get; set; }
            public List<Amazon.NetworkFirewall.Model.IpsRuleGroupEntry> FirewallPolicyV2_IpsRuleGroupEntry { get; set; }
            public Amazon.NetworkFirewall.PolicyMode FirewallPolicyV2_PolicyMode { get; set; }
            public Dictionary<System.String, Amazon.NetworkFirewall.Model.IPSet> FirewallPolicyV2_PolicyVariables_RuleVariable { get; set; }
            public Amazon.NetworkFirewall.Route53ResolvedIPValidationAction FirewallPolicyV2_Route53ResolvedIPValidation_Action { get; set; }
            public List<Amazon.NetworkFirewall.Model.Address> FirewallPolicyV2_Route53ResolvedIPValidation_BypassDestinationValidationIPRange { get; set; }
            public Amazon.NetworkFirewall.DNSExpiryExceptionPolicy FirewallPolicyV2_Route53ResolvedIPValidation_DNSExpiryExceptionPolicy { get; set; }
            public System.String FirewallPolicyV2_Route53ResolvedIPValidation_DNSFirewallRuleGroupId { get; set; }
            public List<Amazon.NetworkFirewall.Model.Address> FirewallPolicyV2_Route53ResolvedIPValidation_SourceIPRange { get; set; }
            public System.Int32? FirewallPolicyV2_StatefulEngineOptions_FlowTimeouts_TcpIdleTimeoutSecond { get; set; }
            public Amazon.NetworkFirewall.StreamExceptionPolicyV2 FirewallPolicyV2_StatefulEngineOptions_StreamExceptionPolicy { get; set; }
            public System.String FirewallPolicyV2_TLSInspectionConfigurationArn { get; set; }
            public System.String FirewallPolicyV2Arn { get; set; }
            public System.String FirewallPolicyV2Name { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateFirewallPolicyV2Response, UpdateNWFWFirewallPolicyV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
