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
    /// Updates the properties of the specified proxy configuration.
    /// </summary>
    [Cmdlet("Update", "NWFWProxyConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateProxyConfiguration API operation.", Operation = new[] {"UpdateProxyConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWProxyConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DefaultRulePhaseActions_PostRESPONSE
        /// <summary>
        /// <para>
        /// <para>After receiving response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.ProxyRulePhaseAction")]
        public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PostRESPONSE { get; set; }
        #endregion
        
        #region Parameter DefaultRulePhaseActions_PreDNS
        /// <summary>
        /// <para>
        /// <para>Before domain resolution. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.ProxyRulePhaseAction")]
        public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreDNS { get; set; }
        #endregion
        
        #region Parameter DefaultRulePhaseActions_PreREQUEST
        /// <summary>
        /// <para>
        /// <para>After DNS, before request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.ProxyRulePhaseAction")]
        public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreREQUEST { get; set; }
        #endregion
        
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWProxyConfiguration (UpdateProxyConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse, UpdateNWFWProxyConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DefaultRulePhaseActions_PostRESPONSE = this.DefaultRulePhaseActions_PostRESPONSE;
            context.DefaultRulePhaseActions_PreDNS = this.DefaultRulePhaseActions_PreDNS;
            context.DefaultRulePhaseActions_PreREQUEST = this.DefaultRulePhaseActions_PreREQUEST;
            context.ProxyConfigurationArn = this.ProxyConfigurationArn;
            context.ProxyConfigurationName = this.ProxyConfigurationName;
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
            var request = new Amazon.NetworkFirewall.Model.UpdateProxyConfigurationRequest();
            
            
             // populate DefaultRulePhaseActions
            var requestDefaultRulePhaseActionsIsNull = true;
            request.DefaultRulePhaseActions = new Amazon.NetworkFirewall.Model.ProxyConfigDefaultRulePhaseActionsRequest();
            Amazon.NetworkFirewall.ProxyRulePhaseAction requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE = null;
            if (cmdletContext.DefaultRulePhaseActions_PostRESPONSE != null)
            {
                requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE = cmdletContext.DefaultRulePhaseActions_PostRESPONSE;
            }
            if (requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE != null)
            {
                request.DefaultRulePhaseActions.PostRESPONSE = requestDefaultRulePhaseActions_defaultRulePhaseActions_PostRESPONSE;
                requestDefaultRulePhaseActionsIsNull = false;
            }
            Amazon.NetworkFirewall.ProxyRulePhaseAction requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS = null;
            if (cmdletContext.DefaultRulePhaseActions_PreDNS != null)
            {
                requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS = cmdletContext.DefaultRulePhaseActions_PreDNS;
            }
            if (requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS != null)
            {
                request.DefaultRulePhaseActions.PreDNS = requestDefaultRulePhaseActions_defaultRulePhaseActions_PreDNS;
                requestDefaultRulePhaseActionsIsNull = false;
            }
            Amazon.NetworkFirewall.ProxyRulePhaseAction requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST = null;
            if (cmdletContext.DefaultRulePhaseActions_PreREQUEST != null)
            {
                requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST = cmdletContext.DefaultRulePhaseActions_PreREQUEST;
            }
            if (requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST != null)
            {
                request.DefaultRulePhaseActions.PreREQUEST = requestDefaultRulePhaseActions_defaultRulePhaseActions_PreREQUEST;
                requestDefaultRulePhaseActionsIsNull = false;
            }
             // determine if request.DefaultRulePhaseActions should be set to null
            if (requestDefaultRulePhaseActionsIsNull)
            {
                request.DefaultRulePhaseActions = null;
            }
            if (cmdletContext.ProxyConfigurationArn != null)
            {
                request.ProxyConfigurationArn = cmdletContext.ProxyConfigurationArn;
            }
            if (cmdletContext.ProxyConfigurationName != null)
            {
                request.ProxyConfigurationName = cmdletContext.ProxyConfigurationName;
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
        
        private Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateProxyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateProxyConfiguration");
            try
            {
                return client.UpdateProxyConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PostRESPONSE { get; set; }
            public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreDNS { get; set; }
            public Amazon.NetworkFirewall.ProxyRulePhaseAction DefaultRulePhaseActions_PreREQUEST { get; set; }
            public System.String ProxyConfigurationArn { get; set; }
            public System.String ProxyConfigurationName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateProxyConfigurationResponse, UpdateNWFWProxyConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
