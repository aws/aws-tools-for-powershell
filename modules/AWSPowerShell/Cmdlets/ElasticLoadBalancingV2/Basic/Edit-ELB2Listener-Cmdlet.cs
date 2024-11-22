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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Replaces the specified properties of the specified listener. Any properties that you
    /// do not specify remain unchanged.
    /// 
    ///  
    /// <para>
    /// Changing the protocol from HTTPS to HTTP, or from TLS to TCP, removes the security
    /// policy and default certificate properties. If you change the protocol from HTTP to
    /// HTTPS, or from TCP to TLS, you must add the security policy and default certificate
    /// properties.
    /// </para><para>
    /// To add an item to a list, remove an item from a list, or update an item in a list,
    /// you must provide the entire list. For example, to add an action, specify a list with
    /// the current actions plus the new action.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "ELB2Listener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.Listener")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 ModifyListener API operation.", Operation = new[] {"ModifyListener"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.Listener or Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.Listener objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditELB2ListenerCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MutualAuthentication_AdvertiseTrustStoreCaName
        /// <summary>
        /// <para>
        /// <para>Indicates whether trust store CA certificate names are advertised.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MutualAuthentication_AdvertiseTrustStoreCaNames")]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.AdvertiseTrustStoreCaNamesEnum")]
        public Amazon.ElasticLoadBalancingV2.AdvertiseTrustStoreCaNamesEnum MutualAuthentication_AdvertiseTrustStoreCaName { get; set; }
        #endregion
        
        #region Parameter AlpnPolicy
        /// <summary>
        /// <para>
        /// <para>[TLS listeners] The name of the Application-Layer Protocol Negotiation (ALPN) policy.
        /// You can specify one policy name. The following are the possible values:</para><ul><li><para><c>HTTP1Only</c></para></li><li><para><c>HTTP2Only</c></para></li><li><para><c>HTTP2Optional</c></para></li><li><para><c>HTTP2Preferred</c></para></li><li><para><c>None</c></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/create-tls-listener.html#alpn-policies">ALPN
        /// policies</a> in the <i>Network Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AlpnPolicy { get; set; }
        #endregion
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>[HTTPS and TLS listeners] The default certificate for the listener. You must provide
        /// exactly one certificate. Set <c>CertificateArn</c> to the certificate ARN but do not
        /// set <c>IsDefault</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Certificates")]
        public Amazon.ElasticLoadBalancingV2.Model.Certificate[] Certificate { get; set; }
        #endregion
        
        #region Parameter DefaultAction
        /// <summary>
        /// <para>
        /// <para>The actions for the default rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultActions")]
        public Amazon.ElasticLoadBalancingV2.Model.Action[] DefaultAction { get; set; }
        #endregion
        
        #region Parameter MutualAuthentication_IgnoreClientCertificateExpiry
        /// <summary>
        /// <para>
        /// <para>Indicates whether expired client certificates are ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MutualAuthentication_IgnoreClientCertificateExpiry { get; set; }
        #endregion
        
        #region Parameter ListenerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the listener.</para>
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
        public System.String ListenerArn { get; set; }
        #endregion
        
        #region Parameter MutualAuthentication_Mode
        /// <summary>
        /// <para>
        /// <para>The client certificate handling method. Options are <c>off</c>, <c>passthrough</c>
        /// or <c>verify</c>. The default value is <c>off</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MutualAuthentication_Mode { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port for connections from clients to the load balancer. You can't specify a port
        /// for a Gateway Load Balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol for connections from clients to the load balancer. Application Load Balancers
        /// support the HTTP and HTTPS protocols. Network Load Balancers support the TCP, TLS,
        /// UDP, and TCP_UDP protocols. You can’t change the protocol to UDP or TCP_UDP if dual-stack
        /// mode is enabled. You can't specify a protocol for a Gateway Load Balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.ProtocolEnum")]
        public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
        #endregion
        
        #region Parameter SslPolicy
        /// <summary>
        /// <para>
        /// <para>[HTTPS and TLS listeners] The security policy that defines which protocols and ciphers
        /// are supported.</para><para>For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/create-https-listener.html#describe-ssl-policies">Security
        /// policies</a> in the <i>Application Load Balancers Guide</i> or <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/create-tls-listener.html#describe-ssl-policies">Security
        /// policies</a> in the <i>Network Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SslPolicy { get; set; }
        #endregion
        
        #region Parameter MutualAuthentication_TrustStoreArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the trust store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MutualAuthentication_TrustStoreArn { get; set; }
        #endregion
        
        #region Parameter MutualAuthentication_TrustStoreAssociationStatus
        /// <summary>
        /// <para>
        /// <para>Indicates a shared trust stores association status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.TrustStoreAssociationStatusEnum")]
        public Amazon.ElasticLoadBalancingV2.TrustStoreAssociationStatusEnum MutualAuthentication_TrustStoreAssociationStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Listeners'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Listeners";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ListenerArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ListenerArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ListenerArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ListenerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELB2Listener (ModifyListener)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse, EditELB2ListenerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ListenerArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AlpnPolicy != null)
            {
                context.AlpnPolicy = new List<System.String>(this.AlpnPolicy);
            }
            if (this.Certificate != null)
            {
                context.Certificate = new List<Amazon.ElasticLoadBalancingV2.Model.Certificate>(this.Certificate);
            }
            if (this.DefaultAction != null)
            {
                context.DefaultAction = new List<Amazon.ElasticLoadBalancingV2.Model.Action>(this.DefaultAction);
            }
            context.ListenerArn = this.ListenerArn;
            #if MODULAR
            if (this.ListenerArn == null && ParameterWasBound(nameof(this.ListenerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ListenerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MutualAuthentication_AdvertiseTrustStoreCaName = this.MutualAuthentication_AdvertiseTrustStoreCaName;
            context.MutualAuthentication_IgnoreClientCertificateExpiry = this.MutualAuthentication_IgnoreClientCertificateExpiry;
            context.MutualAuthentication_Mode = this.MutualAuthentication_Mode;
            context.MutualAuthentication_TrustStoreArn = this.MutualAuthentication_TrustStoreArn;
            context.MutualAuthentication_TrustStoreAssociationStatus = this.MutualAuthentication_TrustStoreAssociationStatus;
            context.Port = this.Port;
            context.Protocol = this.Protocol;
            context.SslPolicy = this.SslPolicy;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.ModifyListenerRequest();
            
            if (cmdletContext.AlpnPolicy != null)
            {
                request.AlpnPolicy = cmdletContext.AlpnPolicy;
            }
            if (cmdletContext.Certificate != null)
            {
                request.Certificates = cmdletContext.Certificate;
            }
            if (cmdletContext.DefaultAction != null)
            {
                request.DefaultActions = cmdletContext.DefaultAction;
            }
            if (cmdletContext.ListenerArn != null)
            {
                request.ListenerArn = cmdletContext.ListenerArn;
            }
            
             // populate MutualAuthentication
            var requestMutualAuthenticationIsNull = true;
            request.MutualAuthentication = new Amazon.ElasticLoadBalancingV2.Model.MutualAuthenticationAttributes();
            Amazon.ElasticLoadBalancingV2.AdvertiseTrustStoreCaNamesEnum requestMutualAuthentication_mutualAuthentication_AdvertiseTrustStoreCaName = null;
            if (cmdletContext.MutualAuthentication_AdvertiseTrustStoreCaName != null)
            {
                requestMutualAuthentication_mutualAuthentication_AdvertiseTrustStoreCaName = cmdletContext.MutualAuthentication_AdvertiseTrustStoreCaName;
            }
            if (requestMutualAuthentication_mutualAuthentication_AdvertiseTrustStoreCaName != null)
            {
                request.MutualAuthentication.AdvertiseTrustStoreCaNames = requestMutualAuthentication_mutualAuthentication_AdvertiseTrustStoreCaName;
                requestMutualAuthenticationIsNull = false;
            }
            System.Boolean? requestMutualAuthentication_mutualAuthentication_IgnoreClientCertificateExpiry = null;
            if (cmdletContext.MutualAuthentication_IgnoreClientCertificateExpiry != null)
            {
                requestMutualAuthentication_mutualAuthentication_IgnoreClientCertificateExpiry = cmdletContext.MutualAuthentication_IgnoreClientCertificateExpiry.Value;
            }
            if (requestMutualAuthentication_mutualAuthentication_IgnoreClientCertificateExpiry != null)
            {
                request.MutualAuthentication.IgnoreClientCertificateExpiry = requestMutualAuthentication_mutualAuthentication_IgnoreClientCertificateExpiry.Value;
                requestMutualAuthenticationIsNull = false;
            }
            System.String requestMutualAuthentication_mutualAuthentication_Mode = null;
            if (cmdletContext.MutualAuthentication_Mode != null)
            {
                requestMutualAuthentication_mutualAuthentication_Mode = cmdletContext.MutualAuthentication_Mode;
            }
            if (requestMutualAuthentication_mutualAuthentication_Mode != null)
            {
                request.MutualAuthentication.Mode = requestMutualAuthentication_mutualAuthentication_Mode;
                requestMutualAuthenticationIsNull = false;
            }
            System.String requestMutualAuthentication_mutualAuthentication_TrustStoreArn = null;
            if (cmdletContext.MutualAuthentication_TrustStoreArn != null)
            {
                requestMutualAuthentication_mutualAuthentication_TrustStoreArn = cmdletContext.MutualAuthentication_TrustStoreArn;
            }
            if (requestMutualAuthentication_mutualAuthentication_TrustStoreArn != null)
            {
                request.MutualAuthentication.TrustStoreArn = requestMutualAuthentication_mutualAuthentication_TrustStoreArn;
                requestMutualAuthenticationIsNull = false;
            }
            Amazon.ElasticLoadBalancingV2.TrustStoreAssociationStatusEnum requestMutualAuthentication_mutualAuthentication_TrustStoreAssociationStatus = null;
            if (cmdletContext.MutualAuthentication_TrustStoreAssociationStatus != null)
            {
                requestMutualAuthentication_mutualAuthentication_TrustStoreAssociationStatus = cmdletContext.MutualAuthentication_TrustStoreAssociationStatus;
            }
            if (requestMutualAuthentication_mutualAuthentication_TrustStoreAssociationStatus != null)
            {
                request.MutualAuthentication.TrustStoreAssociationStatus = requestMutualAuthentication_mutualAuthentication_TrustStoreAssociationStatus;
                requestMutualAuthenticationIsNull = false;
            }
             // determine if request.MutualAuthentication should be set to null
            if (requestMutualAuthenticationIsNull)
            {
                request.MutualAuthentication = null;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SslPolicy != null)
            {
                request.SslPolicy = cmdletContext.SslPolicy;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.ModifyListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "ModifyListener");
            try
            {
                #if DESKTOP
                return client.ModifyListener(request);
                #elif CORECLR
                return client.ModifyListenerAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AlpnPolicy { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.Certificate> Certificate { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.Action> DefaultAction { get; set; }
            public System.String ListenerArn { get; set; }
            public Amazon.ElasticLoadBalancingV2.AdvertiseTrustStoreCaNamesEnum MutualAuthentication_AdvertiseTrustStoreCaName { get; set; }
            public System.Boolean? MutualAuthentication_IgnoreClientCertificateExpiry { get; set; }
            public System.String MutualAuthentication_Mode { get; set; }
            public System.String MutualAuthentication_TrustStoreArn { get; set; }
            public Amazon.ElasticLoadBalancingV2.TrustStoreAssociationStatusEnum MutualAuthentication_TrustStoreAssociationStatus { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
            public System.String SslPolicy { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse, EditELB2ListenerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Listeners;
        }
        
    }
}
