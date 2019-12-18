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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a Client VPN endpoint. A Client VPN endpoint is the resource you create and
    /// configure to enable and manage client VPN sessions. It is the destination endpoint
    /// at which all client VPN sessions are terminated.
    /// </summary>
    [Cmdlet("New", "EC2ClientVpnEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateClientVpnEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateClientVpnEndpoint API operation.", Operation = new[] {"CreateClientVpnEndpoint"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateClientVpnEndpointResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateClientVpnEndpointResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateClientVpnEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ClientVpnEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationOption
        /// <summary>
        /// <para>
        /// <para>Information about the authentication method to be used to authenticate clients.</para>
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
        [Alias("AuthenticationOptions")]
        public Amazon.EC2.Model.ClientVpnAuthenticationRequest[] AuthenticationOption { get; set; }
        #endregion
        
        #region Parameter ClientCidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 address range, in CIDR notation, from which to assign client IP addresses.
        /// The address range cannot overlap with the local CIDR of the VPC in which the associated
        /// subnet is located, or the routes that you add manually. The address range cannot be
        /// changed after the Client VPN endpoint has been created. The CIDR block should be /22
        /// or greater.</para>
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
        public System.String ClientCidrBlock { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_CloudwatchLogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_CloudwatchLogStream
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch Logs log stream to which the connection data is published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of the Client VPN endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DnsServer
        /// <summary>
        /// <para>
        /// <para>Information about the DNS servers to be used for DNS resolution. A Client VPN endpoint
        /// can have up to two DNS servers. If no DNS server is specified, the DNS address configured
        /// on the device is used for the DNS server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DnsServers")]
        public System.String[] DnsServer { get; set; }
        #endregion
        
        #region Parameter ConnectionLogOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether connection logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectionLogOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ServerCertificateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the server certificate. For more information, see the <a href="https://docs.aws.amazon.com/acm/latest/userguide/">AWS
        /// Certificate Manager User Guide</a>.</para>
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
        public System.String ServerCertificateArn { get; set; }
        #endregion
        
        #region Parameter SplitTunnel
        /// <summary>
        /// <para>
        /// <para>Indicates whether split-tunnel is enabled on the AWS Client VPN endpoint.</para><para>By default, split-tunnel on a VPN endpoint is disabled.</para><para>For information about split-tunnel VPN endpoints, see <a href="https://docs.aws.amazon.com/vpn/latest/clientvpn-admin/split-tunnel-vpn.html">Split-Tunnel
        /// AWS Client VPN Endpoint</a> in the <i>AWS Client VPN Administrator Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SplitTunnel { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Client VPN endpoint during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TransportProtocol
        /// <summary>
        /// <para>
        /// <para>The transport protocol to be used by the VPN session.</para><para>Default value: <code>udp</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TransportProtocol")]
        public Amazon.EC2.TransportProtocol TransportProtocol { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateClientVpnEndpointResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateClientVpnEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerCertificateArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerCertificateArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerCertificateArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerCertificateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ClientVpnEndpoint (CreateClientVpnEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateClientVpnEndpointResponse, NewEC2ClientVpnEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerCertificateArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AuthenticationOption != null)
            {
                context.AuthenticationOption = new List<Amazon.EC2.Model.ClientVpnAuthenticationRequest>(this.AuthenticationOption);
            }
            #if MODULAR
            if (this.AuthenticationOption == null && ParameterWasBound(nameof(this.AuthenticationOption)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationOption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientCidrBlock = this.ClientCidrBlock;
            #if MODULAR
            if (this.ClientCidrBlock == null && ParameterWasBound(nameof(this.ClientCidrBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientCidrBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ConnectionLogOptions_CloudwatchLogGroup = this.ConnectionLogOptions_CloudwatchLogGroup;
            context.ConnectionLogOptions_CloudwatchLogStream = this.ConnectionLogOptions_CloudwatchLogStream;
            context.ConnectionLogOptions_Enabled = this.ConnectionLogOptions_Enabled;
            context.Description = this.Description;
            if (this.DnsServer != null)
            {
                context.DnsServer = new List<System.String>(this.DnsServer);
            }
            context.ServerCertificateArn = this.ServerCertificateArn;
            #if MODULAR
            if (this.ServerCertificateArn == null && ParameterWasBound(nameof(this.ServerCertificateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerCertificateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SplitTunnel = this.SplitTunnel;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TransportProtocol = this.TransportProtocol;
            
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
            var request = new Amazon.EC2.Model.CreateClientVpnEndpointRequest();
            
            if (cmdletContext.AuthenticationOption != null)
            {
                request.AuthenticationOptions = cmdletContext.AuthenticationOption;
            }
            if (cmdletContext.ClientCidrBlock != null)
            {
                request.ClientCidrBlock = cmdletContext.ClientCidrBlock;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConnectionLogOptions
            var requestConnectionLogOptionsIsNull = true;
            request.ConnectionLogOptions = new Amazon.EC2.Model.ConnectionLogOptions();
            System.String requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup = null;
            if (cmdletContext.ConnectionLogOptions_CloudwatchLogGroup != null)
            {
                requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup = cmdletContext.ConnectionLogOptions_CloudwatchLogGroup;
            }
            if (requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup != null)
            {
                request.ConnectionLogOptions.CloudwatchLogGroup = requestConnectionLogOptions_connectionLogOptions_CloudwatchLogGroup;
                requestConnectionLogOptionsIsNull = false;
            }
            System.String requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream = null;
            if (cmdletContext.ConnectionLogOptions_CloudwatchLogStream != null)
            {
                requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream = cmdletContext.ConnectionLogOptions_CloudwatchLogStream;
            }
            if (requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream != null)
            {
                request.ConnectionLogOptions.CloudwatchLogStream = requestConnectionLogOptions_connectionLogOptions_CloudwatchLogStream;
                requestConnectionLogOptionsIsNull = false;
            }
            System.Boolean? requestConnectionLogOptions_connectionLogOptions_Enabled = null;
            if (cmdletContext.ConnectionLogOptions_Enabled != null)
            {
                requestConnectionLogOptions_connectionLogOptions_Enabled = cmdletContext.ConnectionLogOptions_Enabled.Value;
            }
            if (requestConnectionLogOptions_connectionLogOptions_Enabled != null)
            {
                request.ConnectionLogOptions.Enabled = requestConnectionLogOptions_connectionLogOptions_Enabled.Value;
                requestConnectionLogOptionsIsNull = false;
            }
             // determine if request.ConnectionLogOptions should be set to null
            if (requestConnectionLogOptionsIsNull)
            {
                request.ConnectionLogOptions = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DnsServer != null)
            {
                request.DnsServers = cmdletContext.DnsServer;
            }
            if (cmdletContext.ServerCertificateArn != null)
            {
                request.ServerCertificateArn = cmdletContext.ServerCertificateArn;
            }
            if (cmdletContext.SplitTunnel != null)
            {
                request.SplitTunnel = cmdletContext.SplitTunnel.Value;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TransportProtocol != null)
            {
                request.TransportProtocol = cmdletContext.TransportProtocol;
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
        
        private Amazon.EC2.Model.CreateClientVpnEndpointResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateClientVpnEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateClientVpnEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateClientVpnEndpoint(request);
                #elif CORECLR
                return client.CreateClientVpnEndpointAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.ClientVpnAuthenticationRequest> AuthenticationOption { get; set; }
            public System.String ClientCidrBlock { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogGroup { get; set; }
            public System.String ConnectionLogOptions_CloudwatchLogStream { get; set; }
            public System.Boolean? ConnectionLogOptions_Enabled { get; set; }
            public System.String Description { get; set; }
            public List<System.String> DnsServer { get; set; }
            public System.String ServerCertificateArn { get; set; }
            public System.Boolean? SplitTunnel { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.TransportProtocol TransportProtocol { get; set; }
            public System.Func<Amazon.EC2.Model.CreateClientVpnEndpointResponse, NewEC2ClientVpnEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
