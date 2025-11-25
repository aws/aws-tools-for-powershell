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
    /// Detaches <a>ProxyRuleGroup</a> resources from a <a>ProxyConfiguration</a><para>
    /// A Proxy Configuration defines the monitoring and protection behavior for a Proxy.
    /// The details of the behavior are defined in the rule groups that you add to your configuration.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Dismount", "NWFWRuleGroupsFromProxyConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall DetachRuleGroupsFromProxyConfiguration API operation.", Operation = new[] {"DetachRuleGroupsFromProxyConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse object containing multiple properties."
    )]
    public partial class DismountNWFWRuleGroupsFromProxyConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
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
        
        #region Parameter RuleGroupArn
        /// <summary>
        /// <para>
        /// <para>The proxy rule group arns to detach from the proxy configuration</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleGroupArns")]
        public System.String[] RuleGroupArn { get; set; }
        #endregion
        
        #region Parameter RuleGroupName
        /// <summary>
        /// <para>
        /// <para>The proxy rule group names to detach from the proxy configuration</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuleGroupNames")]
        public System.String[] RuleGroupName { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Dismount-NWFWRuleGroupsFromProxyConfiguration (DetachRuleGroupsFromProxyConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse, DismountNWFWRuleGroupsFromProxyConfigurationCmdlet>(Select) ??
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
            if (this.RuleGroupArn != null)
            {
                context.RuleGroupArn = new List<System.String>(this.RuleGroupArn);
            }
            if (this.RuleGroupName != null)
            {
                context.RuleGroupName = new List<System.String>(this.RuleGroupName);
            }
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
            var request = new Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationRequest();
            
            if (cmdletContext.ProxyConfigurationArn != null)
            {
                request.ProxyConfigurationArn = cmdletContext.ProxyConfigurationArn;
            }
            if (cmdletContext.ProxyConfigurationName != null)
            {
                request.ProxyConfigurationName = cmdletContext.ProxyConfigurationName;
            }
            if (cmdletContext.RuleGroupArn != null)
            {
                request.RuleGroupArns = cmdletContext.RuleGroupArn;
            }
            if (cmdletContext.RuleGroupName != null)
            {
                request.RuleGroupNames = cmdletContext.RuleGroupName;
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
        
        private Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "DetachRuleGroupsFromProxyConfiguration");
            try
            {
                #if DESKTOP
                return client.DetachRuleGroupsFromProxyConfiguration(request);
                #elif CORECLR
                return client.DetachRuleGroupsFromProxyConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> RuleGroupArn { get; set; }
            public List<System.String> RuleGroupName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.DetachRuleGroupsFromProxyConfigurationResponse, DismountNWFWRuleGroupsFromProxyConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
