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
    /// Updates proxy rule group priorities within a proxy configuration.
    /// </summary>
    [Cmdlet("Update", "NWFWProxyRuleGroupPriority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateProxyRuleGroupPriorities API operation.", Operation = new[] {"UpdateProxyRuleGroupPriorities"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWProxyRuleGroupPriorityCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProxyConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a proxy configuration.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ProxyConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy configuration. You can't change the name of a proxy
        /// configuration after you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyConfigurationName { get; set; }
        #endregion
        
        #region Parameter RuleGroup
        /// <summary>
        /// <para>
        /// <para>proxy rule group resources to update to new positions. </para>
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
        [Alias("RuleGroups")]
        public Amazon.NetworkFirewall.Model.ProxyRuleGroupPriority[] RuleGroup { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. Network Firewall returns a token to your requests
        /// that access the proxy configuration. The token marks the state of the proxy configuration
        /// resource at the time of the request. </para><para>To make changes to the proxy configuration, you provide the token in your request.
        /// Network Firewall uses the token to ensure that the proxy configuration hasn't changed
        /// since you last retrieved it. If it has changed, the operation fails with an <c>InvalidTokenException</c>.
        /// If this happens, retrieve the proxy configuration again to get a current copy of it
        /// with a current token. Reapply your changes as needed, then try the operation again
        /// using the new token. </para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdateToken), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWProxyRuleGroupPriority (UpdateProxyRuleGroupPriorities)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse, UpdateNWFWProxyRuleGroupPriorityCmdlet>(Select) ??
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
            context.ProxyConfigurationArn = this.ProxyConfigurationArn;
            context.ProxyConfigurationName = this.ProxyConfigurationName;
            if (this.RuleGroup != null)
            {
                context.RuleGroup = new List<Amazon.NetworkFirewall.Model.ProxyRuleGroupPriority>(this.RuleGroup);
            }
            #if MODULAR
            if (this.RuleGroup == null && ParameterWasBound(nameof(this.RuleGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesRequest();
            
            if (cmdletContext.ProxyConfigurationArn != null)
            {
                request.ProxyConfigurationArn = cmdletContext.ProxyConfigurationArn;
            }
            if (cmdletContext.ProxyConfigurationName != null)
            {
                request.ProxyConfigurationName = cmdletContext.ProxyConfigurationName;
            }
            if (cmdletContext.RuleGroup != null)
            {
                request.RuleGroups = cmdletContext.RuleGroup;
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
        
        private Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateProxyRuleGroupPriorities");
            try
            {
                #if DESKTOP
                return client.UpdateProxyRuleGroupPriorities(request);
                #elif CORECLR
                return client.UpdateProxyRuleGroupPrioritiesAsync(request).GetAwaiter().GetResult();
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
            public System.String ProxyConfigurationArn { get; set; }
            public System.String ProxyConfigurationName { get; set; }
            public List<Amazon.NetworkFirewall.Model.ProxyRuleGroupPriority> RuleGroup { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateProxyRuleGroupPrioritiesResponse, UpdateNWFWProxyRuleGroupPriorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
