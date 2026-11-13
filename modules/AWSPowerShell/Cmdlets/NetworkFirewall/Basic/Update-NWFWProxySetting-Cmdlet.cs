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
    /// Modifies the proxy settings of a proxy mode firewall. Use this operation to change
    /// the ports and protocols on which the firewall's proxy listens for traffic. The new
    /// listeners take effect without recreating the firewall.
    /// 
    ///  
    /// <para>
    /// The <c>ProxySettings</c> that you provide replace the firewall's current proxy settings.
    /// If you created the firewall with your own <c>CertificateArn</c> and <c>DomainName</c>,
    /// you must specify the same values in every request. You can't change or remove them.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "NWFWProxySetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateProxySettings API operation.", Operation = new[] {"UpdateProxySettings"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWProxySettingCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProxySettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate that the firewall's HTTPS proxy
        /// listener presents to clients. The certificate must be an Certificate Manager (ACM)
        /// certificate in the same account and Region as the firewall. Its subject alternative
        /// names must cover <c>DomainName</c>, either exactly or with a wildcard that matches
        /// exactly one label. For example, <c>*.example.com</c> covers <c>proxy.example.com</c>.
        /// If you don't specify this, Network Firewall uses a certificate that it manages for
        /// a domain name that it generates.</para><para>You manage and renew the certificate in ACM, and Network Firewall uses renewed certificates
        /// automatically. While the firewall uses the certificate, you can't delete it from ACM.
        /// Your clients must trust the certificate's certificate authority.</para><para>If you specify <c>CertificateArn</c>, you must also specify <c>DomainName</c>. You
        /// can set them only when you create the firewall. When you call <c>UpdateProxySettings</c>,
        /// specify the same values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxySettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter ProxySettings_DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name that your clients use to reach the firewall's proxy. The name must
        /// have at least two labels and at most 253 characters. It can't contain a wildcard or
        /// use the <c>proxy-<i>id</i>.nfw.<i>region</i>.amazonaws.com</c> format, and the certificate
        /// in <c>CertificateArn</c> must cover it. If you don't specify this, Network Firewall
        /// generates a domain name.</para><para>Network Firewall creates the Route 53 private hosted zones that resolve this name
        /// to the firewall endpoints, so you don't need to configure DNS. A VPC can have only
        /// one private hosted zone with a given name. If a VPC that the firewall serves already
        /// has one with this name, Network Firewall can't set up the Availability Zones in that
        /// VPC.</para><para>If you specify <c>DomainName</c>, you must also specify <c>CertificateArn</c>. You
        /// can set them only when you create the firewall. When you call <c>UpdateProxySettings</c>,
        /// specify the same values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxySettings_DomainName { get; set; }
        #endregion
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter FirewallName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall. You can't change the name of a firewall after
        /// you create it.</para><para>You must specify the ARN or the name, and you can specify both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FirewallName { get; set; }
        #endregion
        
        #region Parameter ProxySettings_ListenerProperty
        /// <summary>
        /// <para>
        /// <para>The listeners of the firewall's proxy. Specify at least one listener, and at most
        /// one HTTP listener and one HTTPS listener. Each listener needs a port from 1 to 65535,
        /// and the two listeners must use different ports.</para><para>If you don't specify listeners when you create the firewall, the firewall listens
        /// for HTTP on port 3128 and HTTPS on port 8443.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProxySettings_ListenerProperties")]
        public Amazon.NetworkFirewall.Model.ListenerProperty[] ProxySettings_ListenerProperty { get; set; }
        #endregion
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>An optional token that you can use for optimistic locking. Network Firewall returns
        /// a token to your requests that access the firewall. The token marks the state of the
        /// firewall resource at the time of the request. </para><para>To make an unconditional change to the firewall, omit the token in your update request.
        /// Without the token, Network Firewall performs your updates regardless of whether the
        /// firewall has changed since you last retrieved it.</para><para>To make a conditional change to the firewall, provide the token in your update request.
        /// Network Firewall uses the token to ensure that the firewall hasn't changed since you
        /// last retrieved it. If it has changed, the operation fails with an <c>InvalidTokenException</c>.
        /// If this happens, retrieve the firewall again to get a current copy of it with a new
        /// token. Reapply your changes as needed, then try the operation again using the new
        /// token. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.FirewallName),
                nameof(this.FirewallArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWProxySetting (UpdateProxySettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse, UpdateNWFWProxySettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FirewallArn = this.FirewallArn;
            context.FirewallName = this.FirewallName;
            context.ProxySettings_CertificateArn = this.ProxySettings_CertificateArn;
            context.ProxySettings_DomainName = this.ProxySettings_DomainName;
            if (this.ProxySettings_ListenerProperty != null)
            {
                context.ProxySettings_ListenerProperty = new List<Amazon.NetworkFirewall.Model.ListenerProperty>(this.ProxySettings_ListenerProperty);
            }
            context.UpdateToken = this.UpdateToken;
            
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
            var request = new Amazon.NetworkFirewall.Model.UpdateProxySettingsRequest();
            
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
            }
            
             // populate ProxySettings
            var requestProxySettingsIsNull = true;
            request.ProxySettings = new Amazon.NetworkFirewall.Model.ProxySettings();
            System.String requestProxySettings_proxySettings_CertificateArn = null;
            if (cmdletContext.ProxySettings_CertificateArn != null)
            {
                requestProxySettings_proxySettings_CertificateArn = cmdletContext.ProxySettings_CertificateArn;
            }
            if (requestProxySettings_proxySettings_CertificateArn != null)
            {
                request.ProxySettings.CertificateArn = requestProxySettings_proxySettings_CertificateArn;
                requestProxySettingsIsNull = false;
            }
            System.String requestProxySettings_proxySettings_DomainName = null;
            if (cmdletContext.ProxySettings_DomainName != null)
            {
                requestProxySettings_proxySettings_DomainName = cmdletContext.ProxySettings_DomainName;
            }
            if (requestProxySettings_proxySettings_DomainName != null)
            {
                request.ProxySettings.DomainName = requestProxySettings_proxySettings_DomainName;
                requestProxySettingsIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.ListenerProperty> requestProxySettings_proxySettings_ListenerProperty = null;
            if (cmdletContext.ProxySettings_ListenerProperty != null)
            {
                requestProxySettings_proxySettings_ListenerProperty = cmdletContext.ProxySettings_ListenerProperty;
            }
            if (requestProxySettings_proxySettings_ListenerProperty != null)
            {
                request.ProxySettings.ListenerProperties = requestProxySettings_proxySettings_ListenerProperty;
                requestProxySettingsIsNull = false;
            }
             // determine if request.ProxySettings should be set to null
            if (requestProxySettingsIsNull)
            {
                request.ProxySettings = null;
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
        
        private Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateProxySettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateProxySettings");
            try
            {
                return client.UpdateProxySettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FirewallArn { get; set; }
            public System.String FirewallName { get; set; }
            public System.String ProxySettings_CertificateArn { get; set; }
            public System.String ProxySettings_DomainName { get; set; }
            public List<Amazon.NetworkFirewall.Model.ListenerProperty> ProxySettings_ListenerProperty { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateProxySettingsResponse, UpdateNWFWProxySettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
