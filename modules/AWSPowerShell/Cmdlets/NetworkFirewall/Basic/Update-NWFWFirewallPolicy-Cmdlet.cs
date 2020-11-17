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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Updates the properties of the specified firewall policy.
    /// </summary>
    [Cmdlet("Update", "NWFWFirewallPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateFirewallPolicy API operation.", Operation = new[] {"UpdateFirewallPolicy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateNWFWFirewallPolicyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
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
        /// rather than run the request. </para><para>If set to <code>TRUE</code>, Network Firewall checks whether the request can run successfully,
        /// but doesn't actually make the requested changes. The call returns the value that the
        /// request would return if you ran it with dry run set to <code>FALSE</code>, but doesn't
        /// make additions or changes to your resources. This option allows you to make sure that
        /// you have the required permissions to run the request and that your request parameters
        /// are valid. </para><para>If set to <code>FALSE</code>, Network Firewall makes the requested changes to your
        /// resources. </para>
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
        
        #region Parameter FirewallPolicy_StatefulRuleGroupReference
        /// <summary>
        /// <para>
        /// <para>References to the stateless rule groups that are used in the policy. These define
        /// the inspection criteria in stateful rules. </para>
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
        /// <code>StatelessDefaultActions</code> setting. You name each custom action that you
        /// define, and then you can use it by name in your default actions specifications.</para>
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
        /// specify <code>aws:forward_to_sfe</code>. </para><para>You must specify one of the standard actions: <code>aws:pass</code>, <code>aws:drop</code>,
        /// or <code>aws:forward_to_sfe</code>. In addition, you can specify custom actions that
        /// are compatible with your standard section choice.</para><para>For example, you could specify <code>["aws:pass"]</code> or you could specify <code>["aws:pass",
        /// “customActionName”]</code>. For information about compatibility, see the custom action
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
        /// <para>The actions to take on a fragmented packet if it doesn't match any of the stateless
        /// rules in the policy. If you want non-matching fragmented packets to be forwarded for
        /// stateful inspection, specify <code>aws:forward_to_sfe</code>. </para><para>You must specify one of the standard actions: <code>aws:pass</code>, <code>aws:drop</code>,
        /// or <code>aws:forward_to_sfe</code>. In addition, you can specify custom actions that
        /// are compatible with your standard section choice.</para><para>For example, you could specify <code>["aws:pass"]</code> or you could specify <code>["aws:pass",
        /// “customActionName”]</code>. For information about compatibility, see the custom action
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
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. Network Firewall returns a token to your requests
        /// that access the firewall policy. The token marks the state of the policy resource
        /// at the time of the request. </para><para>To make changes to the policy, you provide the token in your request. Network Firewall
        /// uses the token to ensure that the policy hasn't changed since you last retrieved it.
        /// If it has changed, the operation fails with an <code>InvalidTokenException</code>.
        /// If this happens, retrieve the firewall policy again to get a current copy of it with
        /// current token. Reapply your changes as needed, then try the operation again using
        /// the new token. </para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UpdateToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UpdateToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UpdateToken' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWFirewallPolicy (UpdateFirewallPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse, UpdateNWFWFirewallPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UpdateToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.DryRun = this.DryRun;
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
            
             // populate FirewallPolicy
            var requestFirewallPolicyIsNull = true;
            request.FirewallPolicy = new Amazon.NetworkFirewall.Model.FirewallPolicy();
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
                #if DESKTOP
                return client.UpdateFirewallPolicy(request);
                #elif CORECLR
                return client.UpdateFirewallPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public List<Amazon.NetworkFirewall.Model.StatefulRuleGroupReference> FirewallPolicy_StatefulRuleGroupReference { get; set; }
            public List<Amazon.NetworkFirewall.Model.CustomAction> FirewallPolicy_StatelessCustomAction { get; set; }
            public List<System.String> FirewallPolicy_StatelessDefaultAction { get; set; }
            public List<System.String> FirewallPolicy_StatelessFragmentDefaultAction { get; set; }
            public List<Amazon.NetworkFirewall.Model.StatelessRuleGroupReference> FirewallPolicy_StatelessRuleGroupReference { get; set; }
            public System.String FirewallPolicyArn { get; set; }
            public System.String FirewallPolicyName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateFirewallPolicyResponse, UpdateNWFWFirewallPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
