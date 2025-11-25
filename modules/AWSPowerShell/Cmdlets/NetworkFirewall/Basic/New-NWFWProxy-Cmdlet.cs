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
    /// Creates an Network Firewall <a>Proxy</a><para>
    /// Attaches a Proxy configuration to a NAT Gateway. 
    /// </para><para>
    /// To manage a proxy's tags, use the standard Amazon Web Services resource tagging operations,
    /// <a>ListTagsForResource</a>, <a>TagResource</a>, and <a>UntagResource</a>.
    /// </para><para>
    /// To retrieve information about proxies, use <a>ListProxies</a> and <a>DescribeProxy</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateProxyResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateProxy API operation.", Operation = new[] {"CreateProxy"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateProxyResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateProxyResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateProxyResponse object containing multiple properties."
    )]
    public partial class NewNWFWProxyCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ListenerProperty
        /// <summary>
        /// <para>
        /// <para>Listener properties for HTTP and HTTPS traffic.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ListenerProperties")]
        public Amazon.NetworkFirewall.Model.ListenerPropertyRequest[] ListenerProperty { get; set; }
        #endregion
        
        #region Parameter NatGatewayId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the NAT gateway to use with proxy resources.</para>
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
        
        #region Parameter ProxyName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the proxy. You can't change the name of a proxy after you
        /// create it.</para>
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
        public System.String ProxyName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateProxyResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateProxyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProxyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWProxy (CreateProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateProxyResponse, NewNWFWProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ListenerProperty != null)
            {
                context.ListenerProperty = new List<Amazon.NetworkFirewall.Model.ListenerPropertyRequest>(this.ListenerProperty);
            }
            context.NatGatewayId = this.NatGatewayId;
            #if MODULAR
            if (this.NatGatewayId == null && ParameterWasBound(nameof(this.NatGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter NatGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProxyConfigurationArn = this.ProxyConfigurationArn;
            context.ProxyConfigurationName = this.ProxyConfigurationName;
            context.ProxyName = this.ProxyName;
            #if MODULAR
            if (this.ProxyName == null && ParameterWasBound(nameof(this.ProxyName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
            }
            context.TlsInterceptProperties_PcaArn = this.TlsInterceptProperties_PcaArn;
            context.TlsInterceptProperties_TlsInterceptMode = this.TlsInterceptProperties_TlsInterceptMode;
            
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
            var request = new Amazon.NetworkFirewall.Model.CreateProxyRequest();
            
            if (cmdletContext.ListenerProperty != null)
            {
                request.ListenerProperties = cmdletContext.ListenerProperty;
            }
            if (cmdletContext.NatGatewayId != null)
            {
                request.NatGatewayId = cmdletContext.NatGatewayId;
            }
            if (cmdletContext.ProxyConfigurationArn != null)
            {
                request.ProxyConfigurationArn = cmdletContext.ProxyConfigurationArn;
            }
            if (cmdletContext.ProxyConfigurationName != null)
            {
                request.ProxyConfigurationName = cmdletContext.ProxyConfigurationName;
            }
            if (cmdletContext.ProxyName != null)
            {
                request.ProxyName = cmdletContext.ProxyName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.NetworkFirewall.Model.CreateProxyResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateProxy");
            try
            {
                return client.CreateProxyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkFirewall.Model.ListenerPropertyRequest> ListenerProperty { get; set; }
            public System.String NatGatewayId { get; set; }
            public System.String ProxyConfigurationArn { get; set; }
            public System.String ProxyConfigurationName { get; set; }
            public System.String ProxyName { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.String TlsInterceptProperties_PcaArn { get; set; }
            public Amazon.NetworkFirewall.TlsInterceptMode TlsInterceptProperties_TlsInterceptMode { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateProxyResponse, NewNWFWProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
