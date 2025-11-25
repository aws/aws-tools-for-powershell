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
    /// Deletes the specified <a>ProxyRule</a>(s). currently attached to a <a>ProxyRuleGroup</a>
    /// </summary>
    [Cmdlet("Remove", "NWFWProxyRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.NetworkFirewall.Model.ProxyRuleGroup")]
    [AWSCmdlet("Calls the AWS Network Firewall DeleteProxyRules API operation.", Operation = new[] {"DeleteProxyRules"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.ProxyRuleGroup or Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.ProxyRuleGroup object.",
        "The service call response (type Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveNWFWProxyRuleCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
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
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The proxy rule(s) to remove from the existing proxy rule group. </para>
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
        public System.String[] Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProxyRuleGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProxyRuleGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Rule), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NWFWProxyRule (DeleteProxyRules)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse, RemoveNWFWProxyRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProxyRuleGroupArn = this.ProxyRuleGroupArn;
            context.ProxyRuleGroupName = this.ProxyRuleGroupName;
            if (this.Rule != null)
            {
                context.Rule = new List<System.String>(this.Rule);
            }
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.DeleteProxyRulesRequest();
            
            if (cmdletContext.ProxyRuleGroupArn != null)
            {
                request.ProxyRuleGroupArn = cmdletContext.ProxyRuleGroupArn;
            }
            if (cmdletContext.ProxyRuleGroupName != null)
            {
                request.ProxyRuleGroupName = cmdletContext.ProxyRuleGroupName;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
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
        
        private Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DeleteProxyRulesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DeleteProxyRules");
            try
            {
                #if DESKTOP
                return client.DeleteProxyRules(request);
                #elif CORECLR
                return client.DeleteProxyRulesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Rule { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DeleteProxyRulesResponse, RemoveNWFWProxyRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProxyRuleGroup;
        }
        
    }
}
