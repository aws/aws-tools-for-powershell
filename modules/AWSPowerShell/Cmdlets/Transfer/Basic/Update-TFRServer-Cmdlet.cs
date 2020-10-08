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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Updates the file transfer protocol-enabled server's properties after that server has
    /// been created.
    /// 
    ///  
    /// <para>
    /// The <code>UpdateServer</code> call returns the <code>ServerId</code> of the server
    /// you updated.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TFRServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP UpdateServer API operation.", Operation = new[] {"UpdateServer"}, SelectReturnType = typeof(Amazon.Transfer.Model.UpdateServerResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.UpdateServerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.UpdateServerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTFRServerCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        #region Parameter EndpointDetails_AddressAllocationId
        /// <summary>
        /// <para>
        /// <para>A list of address allocation IDs that are required to attach an Elastic IP address
        /// to your server's endpoint.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>
        /// and it is only valid in the <code>UpdateServer</code> API.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_AddressAllocationIds")]
        public System.String[] EndpointDetails_AddressAllocationId { get; set; }
        #endregion
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Certificate Manager (ACM) certificate. Required
        /// when <code>Protocols</code> is set to <code>FTPS</code>.</para><para>To request a new public certificate, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-request-public.html">Request
        /// a public certificate</a> in the <i> AWS Certificate Manager User Guide</i>.</para><para>To import an existing certificate into ACM, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/import-certificate.html">Importing
        /// certificates into ACM</a> in the <i> AWS Certificate Manager User Guide</i>.</para><para>To request a private certificate to use FTPS through private IP addresses, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-request-private.html">Request
        /// a private certificate</a> in the <i> AWS Certificate Manager User Guide</i>.</para><para>Certificates with the following cryptographic algorithms and key sizes are supported:</para><ul><li><para>2048-bit RSA (RSA_2048)</para></li><li><para>4096-bit RSA (RSA_4096)</para></li><li><para>Elliptic Prime Curve 256 bit (EC_prime256v1)</para></li><li><para>Elliptic Prime Curve 384 bit (EC_secp384r1)</para></li><li><para>Elliptic Prime Curve 521 bit (EC_secp521r1)</para></li></ul><note><para>The certificate must be a valid SSL/TLS X.509 version 3 certificate with FQDN or IP
        /// address specified and information about the issuer.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Certificate { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint that you want your server to connect to. You can choose to connect
        /// to the public internet or a VPC endpoint. With a VPC endpoint, you can restrict access
        /// to your server and resources only within your VPC.</para><note><para>It is recommended that you use <code>VPC</code> as the <code>EndpointType</code>.
        /// With this endpoint type, you have the option to directly associate up to three Elastic
        /// IPv4 addresses (BYO IP included) with your server's endpoint and use VPC security
        /// groups to restrict traffic by the client's public IP address. This is not possible
        /// with <code>EndpointType</code> set to <code>VPC_ENDPOINT</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.EndpointType")]
        public Amazon.Transfer.EndpointType EndpointType { get; set; }
        #endregion
        
        #region Parameter HostKey
        /// <summary>
        /// <para>
        /// <para>The RSA private key as generated by <code>ssh-keygen -N "" -m PEM -f my-new-server-key</code>.</para><important><para>If you aren't planning to migrate existing users from an existing server to a new
        /// server, don't update the host key. Accidentally changing a server's host key can be
        /// disruptive.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/edit-server-config.html#configuring-servers-change-host-key">Change
        /// the host key for your SFTP-enabled server</a> in the <i>AWS Transfer Family User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostKey { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_InvocationRole
        /// <summary>
        /// <para>
        /// <para>Provides the type of <code>InvocationRole</code> used to authenticate the user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_InvocationRole { get; set; }
        #endregion
        
        #region Parameter LoggingRole
        /// <summary>
        /// <para>
        /// <para>Changes the AWS Identity and Access Management (IAM) role that allows Amazon S3 events
        /// to be logged in Amazon CloudWatch, turning logging on or off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingRole { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>Specifies the file transfer protocol or protocols over which your file transfer protocol
        /// client can connect to your server's endpoint. The available protocols are:</para><ul><li><para>Secure Shell (SSH) File Transfer Protocol (SFTP): File transfer over SSH</para></li><li><para>File Transfer Protocol Secure (FTPS): File transfer with TLS encryption</para></li><li><para>File Transfer Protocol (FTP): Unencrypted file transfer</para></li></ul><note><para>If you select <code>FTPS</code>, you must choose a certificate stored in AWS Certificate
        /// Manager (ACM) which will be used to identify your server when clients connect to it
        /// over FTPS.</para><para>If <code>Protocol</code> includes either <code>FTP</code> or <code>FTPS</code>, then
        /// the <code>EndpointType</code> must be <code>VPC</code> and the <code>IdentityProviderType</code>
        /// must be <code>API_GATEWAY</code>.</para><para>If <code>Protocol</code> includes <code>FTP</code>, then <code>AddressAllocationIds</code>
        /// cannot be associated.</para><para>If <code>Protocol</code> is set only to <code>SFTP</code>, the <code>EndpointType</code>
        /// can be set to <code>PUBLIC</code> and the <code>IdentityProviderType</code> can be
        /// set to <code>SERVICE_MANAGED</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocols")]
        public System.String[] Protocol { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security groups IDs that are available to attach to your server's endpoint.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>.</para><para>You can only edit the <code>SecurityGroupIds</code> property in the <code>UpdateServer</code>
        /// API and only if you are changing the <code>EndpointType</code> from <code>PUBLIC</code>
        /// or <code>VPC_ENDPOINT</code> to <code>VPC</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_SecurityGroupIds")]
        public System.String[] EndpointDetails_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityPolicyName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the security policy that is attached to the server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityPolicyName { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned unique identifier for a server instance that the user account is
        /// assigned to.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs that are required to host your server endpoint in your VPC.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_SubnetIds")]
        public System.String[] EndpointDetails_SubnetId { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_Url
        /// <summary>
        /// <para>
        /// <para>Provides the location of the service endpoint used to authenticate users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_Url { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC endpoint.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC_ENDPOINT</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointDetails_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_VpcId
        /// <summary>
        /// <para>
        /// <para>The VPC ID of the VPC in which a server's endpoint will be hosted.</para><note><para>This property can only be set when <code>EndpointType</code> is set to <code>VPC</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointDetails_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.UpdateServerResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.UpdateServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TFRServer (UpdateServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.UpdateServerResponse, UpdateTFRServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Certificate = this.Certificate;
            if (this.EndpointDetails_AddressAllocationId != null)
            {
                context.EndpointDetails_AddressAllocationId = new List<System.String>(this.EndpointDetails_AddressAllocationId);
            }
            if (this.EndpointDetails_SecurityGroupId != null)
            {
                context.EndpointDetails_SecurityGroupId = new List<System.String>(this.EndpointDetails_SecurityGroupId);
            }
            if (this.EndpointDetails_SubnetId != null)
            {
                context.EndpointDetails_SubnetId = new List<System.String>(this.EndpointDetails_SubnetId);
            }
            context.EndpointDetails_VpcEndpointId = this.EndpointDetails_VpcEndpointId;
            context.EndpointDetails_VpcId = this.EndpointDetails_VpcId;
            context.EndpointType = this.EndpointType;
            context.HostKey = this.HostKey;
            context.IdentityProviderDetails_InvocationRole = this.IdentityProviderDetails_InvocationRole;
            context.IdentityProviderDetails_Url = this.IdentityProviderDetails_Url;
            context.LoggingRole = this.LoggingRole;
            if (this.Protocol != null)
            {
                context.Protocol = new List<System.String>(this.Protocol);
            }
            context.SecurityPolicyName = this.SecurityPolicyName;
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.UpdateServerRequest();
            
            if (cmdletContext.Certificate != null)
            {
                request.Certificate = cmdletContext.Certificate;
            }
            
             // populate EndpointDetails
            var requestEndpointDetailsIsNull = true;
            request.EndpointDetails = new Amazon.Transfer.Model.EndpointDetails();
            List<System.String> requestEndpointDetails_endpointDetails_AddressAllocationId = null;
            if (cmdletContext.EndpointDetails_AddressAllocationId != null)
            {
                requestEndpointDetails_endpointDetails_AddressAllocationId = cmdletContext.EndpointDetails_AddressAllocationId;
            }
            if (requestEndpointDetails_endpointDetails_AddressAllocationId != null)
            {
                request.EndpointDetails.AddressAllocationIds = requestEndpointDetails_endpointDetails_AddressAllocationId;
                requestEndpointDetailsIsNull = false;
            }
            List<System.String> requestEndpointDetails_endpointDetails_SecurityGroupId = null;
            if (cmdletContext.EndpointDetails_SecurityGroupId != null)
            {
                requestEndpointDetails_endpointDetails_SecurityGroupId = cmdletContext.EndpointDetails_SecurityGroupId;
            }
            if (requestEndpointDetails_endpointDetails_SecurityGroupId != null)
            {
                request.EndpointDetails.SecurityGroupIds = requestEndpointDetails_endpointDetails_SecurityGroupId;
                requestEndpointDetailsIsNull = false;
            }
            List<System.String> requestEndpointDetails_endpointDetails_SubnetId = null;
            if (cmdletContext.EndpointDetails_SubnetId != null)
            {
                requestEndpointDetails_endpointDetails_SubnetId = cmdletContext.EndpointDetails_SubnetId;
            }
            if (requestEndpointDetails_endpointDetails_SubnetId != null)
            {
                request.EndpointDetails.SubnetIds = requestEndpointDetails_endpointDetails_SubnetId;
                requestEndpointDetailsIsNull = false;
            }
            System.String requestEndpointDetails_endpointDetails_VpcEndpointId = null;
            if (cmdletContext.EndpointDetails_VpcEndpointId != null)
            {
                requestEndpointDetails_endpointDetails_VpcEndpointId = cmdletContext.EndpointDetails_VpcEndpointId;
            }
            if (requestEndpointDetails_endpointDetails_VpcEndpointId != null)
            {
                request.EndpointDetails.VpcEndpointId = requestEndpointDetails_endpointDetails_VpcEndpointId;
                requestEndpointDetailsIsNull = false;
            }
            System.String requestEndpointDetails_endpointDetails_VpcId = null;
            if (cmdletContext.EndpointDetails_VpcId != null)
            {
                requestEndpointDetails_endpointDetails_VpcId = cmdletContext.EndpointDetails_VpcId;
            }
            if (requestEndpointDetails_endpointDetails_VpcId != null)
            {
                request.EndpointDetails.VpcId = requestEndpointDetails_endpointDetails_VpcId;
                requestEndpointDetailsIsNull = false;
            }
             // determine if request.EndpointDetails should be set to null
            if (requestEndpointDetailsIsNull)
            {
                request.EndpointDetails = null;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            if (cmdletContext.HostKey != null)
            {
                request.HostKey = cmdletContext.HostKey;
            }
            
             // populate IdentityProviderDetails
            var requestIdentityProviderDetailsIsNull = true;
            request.IdentityProviderDetails = new Amazon.Transfer.Model.IdentityProviderDetails();
            System.String requestIdentityProviderDetails_identityProviderDetails_InvocationRole = null;
            if (cmdletContext.IdentityProviderDetails_InvocationRole != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_InvocationRole = cmdletContext.IdentityProviderDetails_InvocationRole;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_InvocationRole != null)
            {
                request.IdentityProviderDetails.InvocationRole = requestIdentityProviderDetails_identityProviderDetails_InvocationRole;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_Url = null;
            if (cmdletContext.IdentityProviderDetails_Url != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_Url = cmdletContext.IdentityProviderDetails_Url;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_Url != null)
            {
                request.IdentityProviderDetails.Url = requestIdentityProviderDetails_identityProviderDetails_Url;
                requestIdentityProviderDetailsIsNull = false;
            }
             // determine if request.IdentityProviderDetails should be set to null
            if (requestIdentityProviderDetailsIsNull)
            {
                request.IdentityProviderDetails = null;
            }
            if (cmdletContext.LoggingRole != null)
            {
                request.LoggingRole = cmdletContext.LoggingRole;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocols = cmdletContext.Protocol;
            }
            if (cmdletContext.SecurityPolicyName != null)
            {
                request.SecurityPolicyName = cmdletContext.SecurityPolicyName;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
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
        
        private Amazon.Transfer.Model.UpdateServerResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.UpdateServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "UpdateServer");
            try
            {
                #if DESKTOP
                return client.UpdateServer(request);
                #elif CORECLR
                return client.UpdateServerAsync(request).GetAwaiter().GetResult();
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
            public System.String Certificate { get; set; }
            public List<System.String> EndpointDetails_AddressAllocationId { get; set; }
            public List<System.String> EndpointDetails_SecurityGroupId { get; set; }
            public List<System.String> EndpointDetails_SubnetId { get; set; }
            public System.String EndpointDetails_VpcEndpointId { get; set; }
            public System.String EndpointDetails_VpcId { get; set; }
            public Amazon.Transfer.EndpointType EndpointType { get; set; }
            public System.String HostKey { get; set; }
            public System.String IdentityProviderDetails_InvocationRole { get; set; }
            public System.String IdentityProviderDetails_Url { get; set; }
            public System.String LoggingRole { get; set; }
            public List<System.String> Protocol { get; set; }
            public System.String SecurityPolicyName { get; set; }
            public System.String ServerId { get; set; }
            public System.Func<Amazon.Transfer.Model.UpdateServerResponse, UpdateTFRServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerId;
        }
        
    }
}
