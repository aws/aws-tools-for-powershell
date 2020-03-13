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
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditELB2ListenerCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        #region Parameter AlpnPolicy
        /// <summary>
        /// <para>
        /// <para>[TLS listeners] The name of the Application-Layer Protocol Negotiation (ALPN) policy.
        /// You can specify one policy name. The following are the possible values:</para><ul><li><para><code>HTTP1Only</code></para></li><li><para><code>HTTP2Only</code></para></li><li><para><code>HTTP2Optional</code></para></li><li><para><code>HTTP2Preferred</code></para></li><li><para><code>None</code></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/create-tls-listener.html#alpn-policies">ALPN
        /// Policies</a> in the <i>Network Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AlpnPolicy { get; set; }
        #endregion
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>[HTTPS and TLS listeners] The default certificate for the listener. You must provide
        /// exactly one certificate. Set <code>CertificateArn</code> to the certificate ARN but
        /// do not set <code>IsDefault</code>.</para><para>To create a certificate list, use <a>AddListenerCertificates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Certificates")]
        public Amazon.ElasticLoadBalancingV2.Model.Certificate[] Certificate { get; set; }
        #endregion
        
        #region Parameter DefaultAction
        /// <summary>
        /// <para>
        /// <para>The actions for the default rule. The rule must include one forward action or one
        /// or more fixed-response actions.</para><para>If the action type is <code>forward</code>, you specify one or more target groups.
        /// The protocol of the target group must be HTTP or HTTPS for an Application Load Balancer.
        /// The protocol of the target group must be TCP, TLS, UDP, or TCP_UDP for a Network Load
        /// Balancer.</para><para>[HTTPS listeners] If the action type is <code>authenticate-oidc</code>, you authenticate
        /// users through an identity provider that is OpenID Connect (OIDC) compliant.</para><para>[HTTPS listeners] If the action type is <code>authenticate-cognito</code>, you authenticate
        /// users through the user pools supported by Amazon Cognito.</para><para>[Application Load Balancer] If the action type is <code>redirect</code>, you redirect
        /// specified client requests from one URL to another.</para><para>[Application Load Balancer] If the action type is <code>fixed-response</code>, you
        /// drop specified client requests and return a custom HTTP response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultActions")]
        public Amazon.ElasticLoadBalancingV2.Model.Action[] DefaultAction { get; set; }
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
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port for connections from clients to the load balancer.</para>
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
        /// UDP, and TCP_UDP protocols.</para>
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
        /// are supported. The following are the possible values:</para><ul><li><para><code>ELBSecurityPolicy-2016-08</code></para></li><li><para><code>ELBSecurityPolicy-TLS-1-0-2015-04</code></para></li><li><para><code>ELBSecurityPolicy-TLS-1-1-2017-01</code></para></li><li><para><code>ELBSecurityPolicy-TLS-1-2-2017-01</code></para></li><li><para><code>ELBSecurityPolicy-TLS-1-2-Ext-2018-06</code></para></li><li><para><code>ELBSecurityPolicy-FS-2018-06</code></para></li><li><para><code>ELBSecurityPolicy-FS-1-1-2019-08</code></para></li><li><para><code>ELBSecurityPolicy-FS-1-2-2019-08</code></para></li><li><para><code>ELBSecurityPolicy-FS-1-2-Res-2019-08</code></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/create-https-listener.html#describe-ssl-policies">Security
        /// Policies</a> in the <i>Application Load Balancers Guide</i> and <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/create-tls-listener.html#describe-ssl-policies">Security
        /// Policies</a> in the <i>Network Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SslPolicy { get; set; }
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
            public System.Int32? Port { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum Protocol { get; set; }
            public System.String SslPolicy { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.ModifyListenerResponse, EditELB2ListenerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Listeners;
        }
        
    }
}
