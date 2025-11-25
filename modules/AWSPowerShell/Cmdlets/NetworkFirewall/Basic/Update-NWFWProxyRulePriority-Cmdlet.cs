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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Updates proxy rule priorities within a proxy rule group.
    /// </summary>
    [Cmdlet("Update", "NWFWProxyRulePriority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateProxyRulePriorities API operation.", Operation = new[] {"UpdateProxyRulePriorities"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWProxyRulePriorityCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProxyRuleGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a proxy rule group.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyRuleGroupArn { get; set; }
        #endregion
        
        #region Parameter ProxyRuleGroupName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy rule group. You can't change the name of a proxy
        /// rule group after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyRuleGroupName { get; set; }
        #endregion
        
        #region Parameter RuleGroupRequestPhase
        /// <summary>
        /// <para>
        /// <para>Evaluation points in the traffic flow where rules are applied. There are three phases
        /// in a traffic where the rule match is applied. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkFirewall.RuleGroupRequestPhase")]
        public Amazon.NetworkFirewall.RuleGroupRequestPhase RuleGroupRequestPhase { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>proxy rule resources to update to new positions. </para>
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
        [Alias("Rules")]
        public Amazon.NetworkFirewall.Model.ProxyRulePriority[] Rule { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. Network Firewall returns a token to your requests
        /// that access the proxy rule group. The token marks the state of the proxy rule group
        /// resource at the time of the request. </para><para>To make changes to the proxy rule group, you provide the token in your request. Network
        /// Firewall uses the token to ensure that the proxy rule group hasn't changed since you
        /// last retrieved it. If it has changed, the operation fails with an <c>InvalidTokenException</c>.
        /// If this happens, retrieve the proxy rule group again to get a current copy of it with
        /// a current token. Reapply your changes as needed, then try the operation again using
        /// the new token. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWProxyRulePriority (UpdateProxyRulePriorities)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse, UpdateNWFWProxyRulePriorityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProxyRuleGroupArn = this.ProxyRuleGroupArn;
            context.ProxyRuleGroupName = this.ProxyRuleGroupName;
            context.RuleGroupRequestPhase = this.RuleGroupRequestPhase;
            #if MODULAR
            if (this.RuleGroupRequestPhase == null && ParameterWasBound(nameof(this.RuleGroupRequestPhase)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleGroupRequestPhase which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.NetworkFirewall.Model.ProxyRulePriority>(this.Rule);
            }
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesRequest();
            
            if (cmdletContext.ProxyRuleGroupArn != null)
            {
                request.ProxyRuleGroupArn = cmdletContext.ProxyRuleGroupArn;
            }
            if (cmdletContext.ProxyRuleGroupName != null)
            {
                request.ProxyRuleGroupName = cmdletContext.ProxyRuleGroupName;
            }
            if (cmdletContext.RuleGroupRequestPhase != null)
            {
                request.RuleGroupRequestPhase = cmdletContext.RuleGroupRequestPhase;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
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
        
        private Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateProxyRulePriorities");
            try
            {
                #if DESKTOP
                return client.UpdateProxyRulePriorities(request);
                #elif CORECLR
                return client.UpdateProxyRulePrioritiesAsync(request).GetAwaiter().GetResult();
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
            public System.String ProxyRuleGroupArn { get; set; }
            public System.String ProxyRuleGroupName { get; set; }
            public Amazon.NetworkFirewall.RuleGroupRequestPhase RuleGroupRequestPhase { get; set; }
            public List<Amazon.NetworkFirewall.Model.ProxyRulePriority> Rule { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateProxyRulePrioritiesResponse, UpdateNWFWProxyRulePriorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
