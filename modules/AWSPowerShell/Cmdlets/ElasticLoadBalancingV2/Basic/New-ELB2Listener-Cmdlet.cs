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
    /// Creates a listener for the specified Application Load Balancer, Network Load Balancer,
    /// or Gateway Load Balancer.
    /// 
    ///  
    /// <para>
    /// For more information, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-listeners.html">Listeners
    /// for your Application Load Balancers</a></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/load-balancer-listeners.html">Listeners
    /// for your Network Load Balancers</a></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/gateway/gateway-listeners.html">Listeners
    /// for your Gateway Load Balancers</a></para></li></ul><para>
    /// This operation is idempotent, which means that it completes at most one time. If you
    /// attempt to create multiple listeners with the same settings, each call succeeds.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2Listener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.Listener")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateListener API operation.", Operation = new[] {"CreateListener"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.Listener or Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.Listener objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewELB2ListenerCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        
        #region Parameter LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the load balancer.</para>
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
        public System.String LoadBalancerArn { get; set; }
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
        /// <para>The port on which the load balancer is listening. You can't specify a port for a Gateway
        /// Load Balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol for connections from clients to the load balancer. For Application Load
        /// Balancers, the supported protocols are HTTP and HTTPS. For Network Load Balancers,
        /// the supported protocols are TCP, TLS, UDP, and TCP_UDP. You can’t specify the UDP
        /// or TCP_UDP protocol if dual-stack mode is enabled. You can't specify a protocol for
        /// a Gateway Load Balancer.</para>
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
        /// policies</a> in the <i>Application Load Balancers Guide</i> and <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/create-tls-listener.html#describe-ssl-policies">Security
        /// policies</a> in the <i>Network Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SslPolicy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticLoadBalancingV2.Model.Tag[] Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Listeners";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoadBalancerArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoadBalancerArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoadBalancerArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELB2Listener (CreateListener)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse, NewELB2ListenerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoadBalancerArn;
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
            #if MODULAR
            if (this.DefaultAction == null && ParameterWasBound(nameof(this.DefaultAction)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerArn = this.LoadBalancerArn;
            #if MODULAR
            if (this.LoadBalancerArn == null && ParameterWasBound(nameof(this.LoadBalancerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MutualAuthentication_IgnoreClientCertificateExpiry = this.MutualAuthentication_IgnoreClientCertificateExpiry;
            context.MutualAuthentication_Mode = this.MutualAuthentication_Mode;
            context.MutualAuthentication_TrustStoreArn = this.MutualAuthentication_TrustStoreArn;
            context.MutualAuthentication_TrustStoreAssociationStatus = this.MutualAuthentication_TrustStoreAssociationStatus;
            context.Port = this.Port;
            context.Protocol = this.Protocol;
            context.SslPolicy = this.SslPolicy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticLoadBalancingV2.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.CreateListenerRequest();
            
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
            if (cmdletContext.LoadBalancerArn != null)
            {
                request.LoadBalancerArn = cmdletContext.LoadBalancerArn;
            }
            
             // populate MutualAuthentication
            var requestMutualAuthenticationIsNull = true;
            request.MutualAuthentication = new Amazon.ElasticLoadBalancingV2.Model.MutualAuthenticationAttributes();
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.CreateListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "CreateListener");
            try
            {
                #if DESKTOP
                return client.CreateListener(request);
                #elif CORECLR
                return client.CreateListenerAsync(request).GetAwaiter().GetResult();
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
            public System.String LoadBalancerArn { get; set; }
            public System.Boolean? MutualAuthentication_IgnoreClientCertificateExpiry { get; set; }
            public System.String MutualAuthentication_Mode { get; set; }
            public System.String MutualAuthentication_TrustStoreArn { get; set; }
            public Amazon.ElasticLoadBalancingV2.TrustStoreAssociationStatusEnum MutualAuthentication_TrustStoreAssociationStatus { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
            public System.String SslPolicy { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.CreateListenerResponse, NewELB2ListenerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Listeners;
        }
        
    }
}
