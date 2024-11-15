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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates values stored in the domain configuration. Domain configurations for default
    /// endpoints can't be updated.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateDomainConfiguration</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTDomainConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateDomainConfigurationResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateDomainConfiguration API operation.", Operation = new[] {"UpdateDomainConfiguration"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateDomainConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateDomainConfigurationResponse",
        "This cmdlet returns an Amazon.IoT.Model.UpdateDomainConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateIOTDomainConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthorizerConfig_AllowAuthorizerOverride
        /// <summary>
        /// <para>
        /// <para>A Boolean that specifies whether the domain configuration's authorization service
        /// can be overridden.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AuthorizerConfig_AllowAuthorizerOverride { get; set; }
        #endregion
        
        #region Parameter ApplicationProtocol
        /// <summary>
        /// <para>
        /// <para>An enumerated string that speciﬁes the application-layer protocol.</para><ul><li><para><c>SECURE_MQTT</c> - MQTT over TLS.</para></li></ul><ul><li><para><c>MQTT_WSS</c> - MQTT over WebSocket.</para></li></ul><ul><li><para><c>HTTPS</c> - HTTP over TLS.</para></li></ul><ul><li><para><c>DEFAULT</c> - Use a combination of port and Application Layer Protocol Negotiation
        /// (ALPN) to specify application_layer protocol. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/protocols.html">Device
        /// communication protocols</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ApplicationProtocol")]
        public Amazon.IoT.ApplicationProtocol ApplicationProtocol { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>An enumerated string that speciﬁes the authentication type.</para><ul><li><para><c>CUSTOM_AUTH_X509</c> - Use custom authentication and authorization with additional
        /// details from the X.509 client certificate.</para></li></ul><ul><li><para><c>CUSTOM_AUTH</c> - Use custom authentication and authorization. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/custom-authentication.html">Custom
        /// authentication and authorization</a>.</para></li></ul><ul><li><para><c>AWS_X509</c> - Use X.509 client certificates without custom authentication and
        /// authorization. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/x509-client-certs.html">X.509
        /// client certificates</a>.</para></li></ul><ul><li><para><c>AWS_SIGV4</c> - Use Amazon Web Services Signature Version 4. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/custom-authentication.html">IAM
        /// users, groups, and roles</a>.</para></li></ul><ul><li><para><c>DEFAULT </c> - Use a combination of port and Application Layer Protocol Negotiation
        /// (ALPN) to specify authentication type. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/protocols.html">Device
        /// communication protocols</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.AuthenticationType")]
        public Amazon.IoT.AuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter ClientCertificateConfig_ClientCertificateCallbackArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function that IoT invokes after mutual TLS authentication during
        /// the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientCertificateConfig_ClientCertificateCallbackArn { get; set; }
        #endregion
        
        #region Parameter AuthorizerConfig_DefaultAuthorizerName
        /// <summary>
        /// <para>
        /// <para>The name of the authorization service for a domain configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerConfig_DefaultAuthorizerName { get; set; }
        #endregion
        
        #region Parameter DomainConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the domain configuration to be updated.</para>
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
        public System.String DomainConfigurationName { get; set; }
        #endregion
        
        #region Parameter DomainConfigurationStatus
        /// <summary>
        /// <para>
        /// <para>The status to which the domain configuration should be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.DomainConfigurationStatus")]
        public Amazon.IoT.DomainConfigurationStatus DomainConfigurationStatus { get; set; }
        #endregion
        
        #region Parameter ServerCertificateConfig_EnableOCSPCheck
        /// <summary>
        /// <para>
        /// <para>A Boolean value that indicates whether Online Certificate Status Protocol (OCSP) server
        /// certificate check is enabled or not.</para><para>For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-custom-endpoints-cert-config.html">
        /// Server certificate configuration for OCSP stapling</a> from Amazon Web Services IoT
        /// Core Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ServerCertificateConfig_EnableOCSPCheck { get; set; }
        #endregion
        
        #region Parameter ServerCertificateConfig_OcspAuthorizedResponderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for an X.509 certificate stored in Amazon Web Services
        /// Certificate Manager (ACM). If provided, Amazon Web Services IoT Core will use this
        /// certificate to validate the signature of the received OCSP response. The OCSP responder
        /// must sign responses using either this authorized responder certificate or the issuing
        /// certificate, depending on whether the ARN is provided or not. The certificate must
        /// be in the same Amazon Web Services region and account as the domain configuration.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerCertificateConfig_OcspAuthorizedResponderArn { get; set; }
        #endregion
        
        #region Parameter ServerCertificateConfig_OcspLambdaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for a Lambda function that acts as a Request for Comments
        /// (RFC) 6960-compliant Online Certificate Status Protocol (OCSP) responder, supporting
        /// basic OCSP responses. The Lambda function accepts a JSON string that's Base64-encoded.
        /// Therefore, you must convert your OCSP response, which is typically in the Distinguished
        /// Encoding Rules (DER) format, into a JSON string that's Base64-encoded. The Lambda
        /// function's response is also a Base64-encoded JSON string and the response payload
        /// must not exceed 8 kilobytes (KiB) in size. The Lambda function must be in the same
        /// Amazon Web Services region and account as the domain configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerCertificateConfig_OcspLambdaArn { get; set; }
        #endregion
        
        #region Parameter RemoveAuthorizerConfig
        /// <summary>
        /// <para>
        /// <para>Removes the authorization configuration from a domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveAuthorizerConfig { get; set; }
        #endregion
        
        #region Parameter TlsConfig_SecurityPolicy
        /// <summary>
        /// <para>
        /// <para>The security policy for a domain configuration. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/transport-security.html#tls-policy-table">Security
        /// policies </a> in the <i>Amazon Web Services IoT Core developer guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TlsConfig_SecurityPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateDomainConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.UpdateDomainConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTDomainConfiguration (UpdateDomainConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateDomainConfigurationResponse, UpdateIOTDomainConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationProtocol = this.ApplicationProtocol;
            context.AuthenticationType = this.AuthenticationType;
            context.AuthorizerConfig_AllowAuthorizerOverride = this.AuthorizerConfig_AllowAuthorizerOverride;
            context.AuthorizerConfig_DefaultAuthorizerName = this.AuthorizerConfig_DefaultAuthorizerName;
            context.ClientCertificateConfig_ClientCertificateCallbackArn = this.ClientCertificateConfig_ClientCertificateCallbackArn;
            context.DomainConfigurationName = this.DomainConfigurationName;
            #if MODULAR
            if (this.DomainConfigurationName == null && ParameterWasBound(nameof(this.DomainConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainConfigurationStatus = this.DomainConfigurationStatus;
            context.RemoveAuthorizerConfig = this.RemoveAuthorizerConfig;
            context.ServerCertificateConfig_EnableOCSPCheck = this.ServerCertificateConfig_EnableOCSPCheck;
            context.ServerCertificateConfig_OcspAuthorizedResponderArn = this.ServerCertificateConfig_OcspAuthorizedResponderArn;
            context.ServerCertificateConfig_OcspLambdaArn = this.ServerCertificateConfig_OcspLambdaArn;
            context.TlsConfig_SecurityPolicy = this.TlsConfig_SecurityPolicy;
            
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
            var request = new Amazon.IoT.Model.UpdateDomainConfigurationRequest();
            
            if (cmdletContext.ApplicationProtocol != null)
            {
                request.ApplicationProtocol = cmdletContext.ApplicationProtocol;
            }
            if (cmdletContext.AuthenticationType != null)
            {
                request.AuthenticationType = cmdletContext.AuthenticationType;
            }
            
             // populate AuthorizerConfig
            var requestAuthorizerConfigIsNull = true;
            request.AuthorizerConfig = new Amazon.IoT.Model.AuthorizerConfig();
            System.Boolean? requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride = null;
            if (cmdletContext.AuthorizerConfig_AllowAuthorizerOverride != null)
            {
                requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride = cmdletContext.AuthorizerConfig_AllowAuthorizerOverride.Value;
            }
            if (requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride != null)
            {
                request.AuthorizerConfig.AllowAuthorizerOverride = requestAuthorizerConfig_authorizerConfig_AllowAuthorizerOverride.Value;
                requestAuthorizerConfigIsNull = false;
            }
            System.String requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName = null;
            if (cmdletContext.AuthorizerConfig_DefaultAuthorizerName != null)
            {
                requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName = cmdletContext.AuthorizerConfig_DefaultAuthorizerName;
            }
            if (requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName != null)
            {
                request.AuthorizerConfig.DefaultAuthorizerName = requestAuthorizerConfig_authorizerConfig_DefaultAuthorizerName;
                requestAuthorizerConfigIsNull = false;
            }
             // determine if request.AuthorizerConfig should be set to null
            if (requestAuthorizerConfigIsNull)
            {
                request.AuthorizerConfig = null;
            }
            
             // populate ClientCertificateConfig
            var requestClientCertificateConfigIsNull = true;
            request.ClientCertificateConfig = new Amazon.IoT.Model.ClientCertificateConfig();
            System.String requestClientCertificateConfig_clientCertificateConfig_ClientCertificateCallbackArn = null;
            if (cmdletContext.ClientCertificateConfig_ClientCertificateCallbackArn != null)
            {
                requestClientCertificateConfig_clientCertificateConfig_ClientCertificateCallbackArn = cmdletContext.ClientCertificateConfig_ClientCertificateCallbackArn;
            }
            if (requestClientCertificateConfig_clientCertificateConfig_ClientCertificateCallbackArn != null)
            {
                request.ClientCertificateConfig.ClientCertificateCallbackArn = requestClientCertificateConfig_clientCertificateConfig_ClientCertificateCallbackArn;
                requestClientCertificateConfigIsNull = false;
            }
             // determine if request.ClientCertificateConfig should be set to null
            if (requestClientCertificateConfigIsNull)
            {
                request.ClientCertificateConfig = null;
            }
            if (cmdletContext.DomainConfigurationName != null)
            {
                request.DomainConfigurationName = cmdletContext.DomainConfigurationName;
            }
            if (cmdletContext.DomainConfigurationStatus != null)
            {
                request.DomainConfigurationStatus = cmdletContext.DomainConfigurationStatus;
            }
            if (cmdletContext.RemoveAuthorizerConfig != null)
            {
                request.RemoveAuthorizerConfig = cmdletContext.RemoveAuthorizerConfig.Value;
            }
            
             // populate ServerCertificateConfig
            var requestServerCertificateConfigIsNull = true;
            request.ServerCertificateConfig = new Amazon.IoT.Model.ServerCertificateConfig();
            System.Boolean? requestServerCertificateConfig_serverCertificateConfig_EnableOCSPCheck = null;
            if (cmdletContext.ServerCertificateConfig_EnableOCSPCheck != null)
            {
                requestServerCertificateConfig_serverCertificateConfig_EnableOCSPCheck = cmdletContext.ServerCertificateConfig_EnableOCSPCheck.Value;
            }
            if (requestServerCertificateConfig_serverCertificateConfig_EnableOCSPCheck != null)
            {
                request.ServerCertificateConfig.EnableOCSPCheck = requestServerCertificateConfig_serverCertificateConfig_EnableOCSPCheck.Value;
                requestServerCertificateConfigIsNull = false;
            }
            System.String requestServerCertificateConfig_serverCertificateConfig_OcspAuthorizedResponderArn = null;
            if (cmdletContext.ServerCertificateConfig_OcspAuthorizedResponderArn != null)
            {
                requestServerCertificateConfig_serverCertificateConfig_OcspAuthorizedResponderArn = cmdletContext.ServerCertificateConfig_OcspAuthorizedResponderArn;
            }
            if (requestServerCertificateConfig_serverCertificateConfig_OcspAuthorizedResponderArn != null)
            {
                request.ServerCertificateConfig.OcspAuthorizedResponderArn = requestServerCertificateConfig_serverCertificateConfig_OcspAuthorizedResponderArn;
                requestServerCertificateConfigIsNull = false;
            }
            System.String requestServerCertificateConfig_serverCertificateConfig_OcspLambdaArn = null;
            if (cmdletContext.ServerCertificateConfig_OcspLambdaArn != null)
            {
                requestServerCertificateConfig_serverCertificateConfig_OcspLambdaArn = cmdletContext.ServerCertificateConfig_OcspLambdaArn;
            }
            if (requestServerCertificateConfig_serverCertificateConfig_OcspLambdaArn != null)
            {
                request.ServerCertificateConfig.OcspLambdaArn = requestServerCertificateConfig_serverCertificateConfig_OcspLambdaArn;
                requestServerCertificateConfigIsNull = false;
            }
             // determine if request.ServerCertificateConfig should be set to null
            if (requestServerCertificateConfigIsNull)
            {
                request.ServerCertificateConfig = null;
            }
            
             // populate TlsConfig
            var requestTlsConfigIsNull = true;
            request.TlsConfig = new Amazon.IoT.Model.TlsConfig();
            System.String requestTlsConfig_tlsConfig_SecurityPolicy = null;
            if (cmdletContext.TlsConfig_SecurityPolicy != null)
            {
                requestTlsConfig_tlsConfig_SecurityPolicy = cmdletContext.TlsConfig_SecurityPolicy;
            }
            if (requestTlsConfig_tlsConfig_SecurityPolicy != null)
            {
                request.TlsConfig.SecurityPolicy = requestTlsConfig_tlsConfig_SecurityPolicy;
                requestTlsConfigIsNull = false;
            }
             // determine if request.TlsConfig should be set to null
            if (requestTlsConfigIsNull)
            {
                request.TlsConfig = null;
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
        
        private Amazon.IoT.Model.UpdateDomainConfigurationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateDomainConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateDomainConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateDomainConfiguration(request);
                #elif CORECLR
                return client.UpdateDomainConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoT.ApplicationProtocol ApplicationProtocol { get; set; }
            public Amazon.IoT.AuthenticationType AuthenticationType { get; set; }
            public System.Boolean? AuthorizerConfig_AllowAuthorizerOverride { get; set; }
            public System.String AuthorizerConfig_DefaultAuthorizerName { get; set; }
            public System.String ClientCertificateConfig_ClientCertificateCallbackArn { get; set; }
            public System.String DomainConfigurationName { get; set; }
            public Amazon.IoT.DomainConfigurationStatus DomainConfigurationStatus { get; set; }
            public System.Boolean? RemoveAuthorizerConfig { get; set; }
            public System.Boolean? ServerCertificateConfig_EnableOCSPCheck { get; set; }
            public System.String ServerCertificateConfig_OcspAuthorizedResponderArn { get; set; }
            public System.String ServerCertificateConfig_OcspLambdaArn { get; set; }
            public System.String TlsConfig_SecurityPolicy { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateDomainConfigurationResponse, UpdateIOTDomainConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
