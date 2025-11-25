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
    /// Updates the properties of the specified proxy.
    /// </summary>
    [Cmdlet("Update", "NWFWProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateProxyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateProxy API operation.", Operation = new[] {"UpdateProxy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateProxyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateProxyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateProxyResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWProxyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ListenerPropertiesToAdd
        /// <summary>
        /// <para>
        /// <para>Listener properties for HTTP and HTTPS traffic to add. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFirewall.Model.ListenerPropertyRequest[] ListenerPropertiesToAdd { get; set; }
        #endregion
        
        #region Parameter ListenerPropertiesToRemove
        /// <summary>
        /// <para>
        /// <para>Listener properties for HTTP and HTTPS traffic to remove. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFirewall.Model.ListenerPropertyRequest[] ListenerPropertiesToRemove { get; set; }
        #endregion
        
        #region Parameter NatGatewayId
        /// <summary>
        /// <para>
        /// <para>The NAT Gateway the proxy is attached to. </para>
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
        public System.String NatGatewayId { get; set; }
        #endregion
        
        #region Parameter TlsInterceptProperties_PcaArn
        /// <summary>
        /// <para>
        /// <para>Private Certificate Authority (PCA) used to issue private TLS certificates so that
        /// the proxy can present PCA-signed certificates which applications trust through the
        /// same root, establishing a secure and consistent trust model for encrypted communication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TlsInterceptProperties_PcaArn { get; set; }
        #endregion
        
        #region Parameter ProxyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a proxy.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyArn { get; set; }
        #endregion
        
        #region Parameter ProxyName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy. You can't change the name of a proxy after you
        /// create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyName { get; set; }
        #endregion
        
        #region Parameter TlsInterceptProperties_TlsInterceptMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable or disable TLS Intercept Mode. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.TlsInterceptMode")]
        public Amazon.NetworkFirewall.TlsInterceptMode TlsInterceptProperties_TlsInterceptMode { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. Network Firewall returns a token to your requests
        /// that access the proxy. The token marks the state of the proxy resource at the time
        /// of the request. </para><para>To make changes to the proxy, you provide the token in your request. Network Firewall
        /// uses the token to ensure that the proxy hasn't changed since you last retrieved it.
        /// If it has changed, the operation fails with an <c>InvalidTokenException</c>. If this
        /// happens, retrieve the proxy again to get a current copy of it with a current token.
        /// Reapply your changes as needed, then try the operation again using the new token.
        /// </para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateProxyResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateProxyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NatGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWProxy (UpdateProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateProxyResponse, UpdateNWFWProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ListenerPropertiesToAdd != null)
            {
                context.ListenerPropertiesToAdd = new List<Amazon.NetworkFirewall.Model.ListenerPropertyRequest>(this.ListenerPropertiesToAdd);
            }
            if (this.ListenerPropertiesToRemove != null)
            {
                context.ListenerPropertiesToRemove = new List<Amazon.NetworkFirewall.Model.ListenerPropertyRequest>(this.ListenerPropertiesToRemove);
            }
            context.NatGatewayId = this.NatGatewayId;
            #if MODULAR
            if (this.NatGatewayId == null && ParameterWasBound(nameof(this.NatGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter NatGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProxyArn = this.ProxyArn;
            context.ProxyName = this.ProxyName;
            context.TlsInterceptProperties_PcaArn = this.TlsInterceptProperties_PcaArn;
            context.TlsInterceptProperties_TlsInterceptMode = this.TlsInterceptProperties_TlsInterceptMode;
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
            var request = new Amazon.NetworkFirewall.Model.UpdateProxyRequest();
            
            if (cmdletContext.ListenerPropertiesToAdd != null)
            {
                request.ListenerPropertiesToAdd = cmdletContext.ListenerPropertiesToAdd;
            }
            if (cmdletContext.ListenerPropertiesToRemove != null)
            {
                request.ListenerPropertiesToRemove = cmdletContext.ListenerPropertiesToRemove;
            }
            if (cmdletContext.NatGatewayId != null)
            {
                request.NatGatewayId = cmdletContext.NatGatewayId;
            }
            if (cmdletContext.ProxyArn != null)
            {
                request.ProxyArn = cmdletContext.ProxyArn;
            }
            if (cmdletContext.ProxyName != null)
            {
                request.ProxyName = cmdletContext.ProxyName;
            }
            
             // populate TlsInterceptProperties
            var requestTlsInterceptPropertiesIsNull = true;
            request.TlsInterceptProperties = new Amazon.NetworkFirewall.Model.TlsInterceptPropertiesRequest();
            System.String requestTlsInterceptProperties_tlsInterceptProperties_PcaArn = null;
            if (cmdletContext.TlsInterceptProperties_PcaArn != null)
            {
                requestTlsInterceptProperties_tlsInterceptProperties_PcaArn = cmdletContext.TlsInterceptProperties_PcaArn;
            }
            if (requestTlsInterceptProperties_tlsInterceptProperties_PcaArn != null)
            {
                request.TlsInterceptProperties.PcaArn = requestTlsInterceptProperties_tlsInterceptProperties_PcaArn;
                requestTlsInterceptPropertiesIsNull = false;
            }
            Amazon.NetworkFirewall.TlsInterceptMode requestTlsInterceptProperties_tlsInterceptProperties_TlsInterceptMode = null;
            if (cmdletContext.TlsInterceptProperties_TlsInterceptMode != null)
            {
                requestTlsInterceptProperties_tlsInterceptProperties_TlsInterceptMode = cmdletContext.TlsInterceptProperties_TlsInterceptMode;
            }
            if (requestTlsInterceptProperties_tlsInterceptProperties_TlsInterceptMode != null)
            {
                request.TlsInterceptProperties.TlsInterceptMode = requestTlsInterceptProperties_tlsInterceptProperties_TlsInterceptMode;
                requestTlsInterceptPropertiesIsNull = false;
            }
             // determine if request.TlsInterceptProperties should be set to null
            if (requestTlsInterceptPropertiesIsNull)
            {
                request.TlsInterceptProperties = null;
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
        
        private Amazon.NetworkFirewall.Model.UpdateProxyResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateProxy");
            try
            {
                #if DESKTOP
                return client.UpdateProxy(request);
                #elif CORECLR
                return client.UpdateProxyAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkFirewall.Model.ListenerPropertyRequest> ListenerPropertiesToAdd { get; set; }
            public List<Amazon.NetworkFirewall.Model.ListenerPropertyRequest> ListenerPropertiesToRemove { get; set; }
            public System.String NatGatewayId { get; set; }
            public System.String ProxyArn { get; set; }
            public System.String ProxyName { get; set; }
            public System.String TlsInterceptProperties_PcaArn { get; set; }
            public Amazon.NetworkFirewall.TlsInterceptMode TlsInterceptProperties_TlsInterceptMode { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateProxyResponse, UpdateNWFWProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
