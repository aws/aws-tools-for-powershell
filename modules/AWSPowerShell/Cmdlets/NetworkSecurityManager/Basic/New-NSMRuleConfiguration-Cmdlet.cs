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
using Amazon.NetworkSecurityManager;
using Amazon.NetworkSecurityManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NSM
{
    /// <summary>
    /// Generates a rule configuration from a natural-language description. Provide a prompt
    /// along with the rule's firewall type and rule type. The service returns a configuration
    /// that you can use when you create or update a rule. If you also provide an existing
    /// configuration, the service edits that configuration instead of generating a new one.
    /// </summary>
    [Cmdlet("New", "NSMRuleConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Security Manager Customer API GenerateRuleConfiguration API operation.", Operation = new[] {"GenerateRuleConfiguration"}, SelectReturnType = typeof(Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse object containing multiple properties."
    )]
    public partial class NewNSMRuleConfigurationCmdlet : AmazonNetworkSecurityManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CurrentConfiguration
        /// <summary>
        /// <para>
        /// <para>An existing configuration to edit, as a JSON string. When you provide this value,
        /// the operation edits the configuration. When you omit it, the operation generates a
        /// new configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CurrentConfiguration { get; set; }
        #endregion
        
        #region Parameter Prompt
        /// <summary>
        /// <para>
        /// <para>A natural-language description of the configuration that you want to generate.</para>
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
        public System.String Prompt { get; set; }
        #endregion
        
        #region Parameter RuleFirewallType
        /// <summary>
        /// <para>
        /// <para>The firewall type of the rule.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.RuleFirewallType")]
        public Amazon.NetworkSecurityManager.RuleFirewallType RuleFirewallType { get; set; }
        #endregion
        
        #region Parameter RuleType
        /// <summary>
        /// <para>
        /// <para>The type of the rule. <c>CONFIGURATION</c> rules contain firewall settings, and <c>INSPECTION</c>
        /// rules contain rule groups.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.RuleType")]
        public Amazon.NetworkSecurityManager.RuleType RuleType { get; set; }
        #endregion
        
        #region Parameter WafConfigDataType
        /// <summary>
        /// <para>
        /// <para>For AWS WAF configuration rules, the specific AWS WAF configuration variant to generate.
        /// This is optional; if you omit it, the service selects the variant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkSecurityManager.WAFConfigDataType")]
        public Amazon.NetworkSecurityManager.WAFConfigDataType WafConfigDataType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure that the operation completes
        /// no more than one time. If you retry a request with the same client token and the same
        /// parameters, the service returns the result of the original successful request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSMRuleConfiguration (GenerateRuleConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse, NewNSMRuleConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CurrentConfiguration = this.CurrentConfiguration;
            context.Prompt = this.Prompt;
            #if MODULAR
            if (this.Prompt == null && ParameterWasBound(nameof(this.Prompt)))
            {
                WriteWarning("You are passing $null as a value for parameter Prompt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleFirewallType = this.RuleFirewallType;
            #if MODULAR
            if (this.RuleFirewallType == null && ParameterWasBound(nameof(this.RuleFirewallType)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleFirewallType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleType = this.RuleType;
            #if MODULAR
            if (this.RuleType == null && ParameterWasBound(nameof(this.RuleType)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WafConfigDataType = this.WafConfigDataType;
            
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
            var request = new Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CurrentConfiguration != null)
            {
                request.CurrentConfiguration = cmdletContext.CurrentConfiguration;
            }
            if (cmdletContext.Prompt != null)
            {
                request.Prompt = cmdletContext.Prompt;
            }
            if (cmdletContext.RuleFirewallType != null)
            {
                request.RuleFirewallType = cmdletContext.RuleFirewallType;
            }
            if (cmdletContext.RuleType != null)
            {
                request.RuleType = cmdletContext.RuleType;
            }
            if (cmdletContext.WafConfigDataType != null)
            {
                request.WafConfigDataType = cmdletContext.WafConfigDataType;
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
        
        private Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse CallAWSServiceOperation(IAmazonNetworkSecurityManager client, Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Security Manager Customer API", "GenerateRuleConfiguration");
            try
            {
                return client.GenerateRuleConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CurrentConfiguration { get; set; }
            public System.String Prompt { get; set; }
            public Amazon.NetworkSecurityManager.RuleFirewallType RuleFirewallType { get; set; }
            public Amazon.NetworkSecurityManager.RuleType RuleType { get; set; }
            public Amazon.NetworkSecurityManager.WAFConfigDataType WafConfigDataType { get; set; }
            public System.Func<Amazon.NetworkSecurityManager.Model.GenerateRuleConfigurationResponse, NewNSMRuleConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
