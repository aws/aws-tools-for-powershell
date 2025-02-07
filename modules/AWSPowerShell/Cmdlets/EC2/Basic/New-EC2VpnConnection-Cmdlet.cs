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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a VPN connection between an existing virtual private gateway or transit gateway
    /// and a customer gateway. The supported connection type is <c>ipsec.1</c>.
    /// 
    ///  
    /// <para>
    /// The response includes information that you need to give to your network administrator
    /// to configure your customer gateway.
    /// </para><important><para>
    /// We strongly recommend that you use HTTPS when calling this operation because the response
    /// contains sensitive cryptographic information for configuring your customer gateway
    /// device.
    /// </para></important><para>
    /// If you decide to shut down your VPN connection for any reason and later create a new
    /// VPN connection, you must reconfigure your customer gateway with the new information
    /// returned from this call.
    /// </para><para>
    /// This is an idempotent operation. If you perform the operation more than once, Amazon
    /// EC2 doesn't return an error.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/VPC_VPN.html">Amazon
    /// Web Services Site-to-Site VPN</a> in the <i>Amazon Web Services Site-to-Site VPN User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpnConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpnConnection API operation.", Operation = new[] {"CreateVpnConnection"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpnConnectionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection or Amazon.EC2.Model.CreateVpnConnectionResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpnConnection object.",
        "The service call response (type Amazon.EC2.Model.CreateVpnConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2VpnConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomerGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the customer gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CustomerGatewayId { get; set; }
        #endregion
        
        #region Parameter Options_EnableAcceleration
        /// <summary>
        /// <para>
        /// <para>Indicate whether to enable acceleration for the VPN connection.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_EnableAcceleration { get; set; }
        #endregion
        
        #region Parameter Options_LocalIpv4NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR on the customer gateway (on-premises) side of the VPN connection.</para><para>Default: <c>0.0.0.0/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_LocalIpv4NetworkCidr { get; set; }
        #endregion
        
        #region Parameter Options_LocalIpv6NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR on the customer gateway (on-premises) side of the VPN connection.</para><para>Default: <c>::/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_LocalIpv6NetworkCidr { get; set; }
        #endregion
        
        #region Parameter Options_OutsideIpAddressType
        /// <summary>
        /// <para>
        /// <para>The type of IPv4 address assigned to the outside interface of the customer gateway
        /// device.</para><para>Valid values: <c>PrivateIpv4</c> | <c>PublicIpv4</c></para><para>Default: <c>PublicIpv4</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_OutsideIpAddressType { get; set; }
        #endregion
        
        #region Parameter Options_RemoteIpv4NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR on the Amazon Web Services side of the VPN connection.</para><para>Default: <c>0.0.0.0/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_RemoteIpv4NetworkCidr { get; set; }
        #endregion
        
        #region Parameter Options_RemoteIpv6NetworkCidr
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR on the Amazon Web Services side of the VPN connection.</para><para>Default: <c>::/0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_RemoteIpv6NetworkCidr { get; set; }
        #endregion
        
        #region Parameter Options_StaticRoutesOnly
        /// <summary>
        /// <para>
        /// <para>Indicate whether the VPN connection uses static routes only. If you are creating a
        /// VPN connection for a device that does not support BGP, you must specify <c>true</c>.
        /// Use <a>CreateVpnConnectionRoute</a> to create a static route.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("StaticRoutesOnly")]
        public System.Boolean? Options_StaticRoutesOnly { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the VPN connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TransitGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway. If you specify a transit gateway, you cannot specify
        /// a virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayId { get; set; }
        #endregion
        
        #region Parameter Options_TransportTransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The transit gateway attachment ID to use for the VPN tunnel.</para><para>Required if <c>OutsideIpAddressType</c> is set to <c>PrivateIpv4</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Options_TransportTransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter Options_TunnelInsideIpVersion
        /// <summary>
        /// <para>
        /// <para>Indicate whether the VPN tunnels process IPv4 or IPv6 traffic.</para><para>Default: <c>ipv4</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TunnelInsideIpVersion")]
        public Amazon.EC2.TunnelInsideIpVersion Options_TunnelInsideIpVersion { get; set; }
        #endregion
        
        #region Parameter Options_TunnelOption
        /// <summary>
        /// <para>
        /// <para>The tunnel options for the VPN connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options_TunnelOptions")]
        public Amazon.EC2.Model.VpnTunnelOptionsSpecification[] Options_TunnelOption { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of VPN connection (<c>ipsec.1</c>).</para>
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
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter VpnGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway. If you specify a virtual private gateway, you
        /// cannot specify a transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String VpnGatewayId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpnConnectionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpnConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnection";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpnGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpnConnection (CreateVpnConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpnConnectionResponse, NewEC2VpnConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomerGatewayId = this.CustomerGatewayId;
            #if MODULAR
            if (this.CustomerGatewayId == null && ParameterWasBound(nameof(this.CustomerGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomerGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Options_EnableAcceleration = this.Options_EnableAcceleration;
            context.Options_LocalIpv4NetworkCidr = this.Options_LocalIpv4NetworkCidr;
            context.Options_LocalIpv6NetworkCidr = this.Options_LocalIpv6NetworkCidr;
            context.Options_OutsideIpAddressType = this.Options_OutsideIpAddressType;
            context.Options_RemoteIpv4NetworkCidr = this.Options_RemoteIpv4NetworkCidr;
            context.Options_RemoteIpv6NetworkCidr = this.Options_RemoteIpv6NetworkCidr;
            context.Options_StaticRoutesOnly = this.Options_StaticRoutesOnly;
            context.Options_TransportTransitGatewayAttachmentId = this.Options_TransportTransitGatewayAttachmentId;
            context.Options_TunnelInsideIpVersion = this.Options_TunnelInsideIpVersion;
            if (this.Options_TunnelOption != null)
            {
                context.Options_TunnelOption = new List<Amazon.EC2.Model.VpnTunnelOptionsSpecification>(this.Options_TunnelOption);
            }
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TransitGatewayId = this.TransitGatewayId;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpnGatewayId = this.VpnGatewayId;
            
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
            var request = new Amazon.EC2.Model.CreateVpnConnectionRequest();
            
            if (cmdletContext.CustomerGatewayId != null)
            {
                request.CustomerGatewayId = cmdletContext.CustomerGatewayId;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.VpnConnectionOptionsSpecification();
            System.Boolean? requestOptions_options_EnableAcceleration = null;
            if (cmdletContext.Options_EnableAcceleration != null)
            {
                requestOptions_options_EnableAcceleration = cmdletContext.Options_EnableAcceleration.Value;
            }
            if (requestOptions_options_EnableAcceleration != null)
            {
                request.Options.EnableAcceleration = requestOptions_options_EnableAcceleration.Value;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_LocalIpv4NetworkCidr = null;
            if (cmdletContext.Options_LocalIpv4NetworkCidr != null)
            {
                requestOptions_options_LocalIpv4NetworkCidr = cmdletContext.Options_LocalIpv4NetworkCidr;
            }
            if (requestOptions_options_LocalIpv4NetworkCidr != null)
            {
                request.Options.LocalIpv4NetworkCidr = requestOptions_options_LocalIpv4NetworkCidr;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_LocalIpv6NetworkCidr = null;
            if (cmdletContext.Options_LocalIpv6NetworkCidr != null)
            {
                requestOptions_options_LocalIpv6NetworkCidr = cmdletContext.Options_LocalIpv6NetworkCidr;
            }
            if (requestOptions_options_LocalIpv6NetworkCidr != null)
            {
                request.Options.LocalIpv6NetworkCidr = requestOptions_options_LocalIpv6NetworkCidr;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_OutsideIpAddressType = null;
            if (cmdletContext.Options_OutsideIpAddressType != null)
            {
                requestOptions_options_OutsideIpAddressType = cmdletContext.Options_OutsideIpAddressType;
            }
            if (requestOptions_options_OutsideIpAddressType != null)
            {
                request.Options.OutsideIpAddressType = requestOptions_options_OutsideIpAddressType;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_RemoteIpv4NetworkCidr = null;
            if (cmdletContext.Options_RemoteIpv4NetworkCidr != null)
            {
                requestOptions_options_RemoteIpv4NetworkCidr = cmdletContext.Options_RemoteIpv4NetworkCidr;
            }
            if (requestOptions_options_RemoteIpv4NetworkCidr != null)
            {
                request.Options.RemoteIpv4NetworkCidr = requestOptions_options_RemoteIpv4NetworkCidr;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_RemoteIpv6NetworkCidr = null;
            if (cmdletContext.Options_RemoteIpv6NetworkCidr != null)
            {
                requestOptions_options_RemoteIpv6NetworkCidr = cmdletContext.Options_RemoteIpv6NetworkCidr;
            }
            if (requestOptions_options_RemoteIpv6NetworkCidr != null)
            {
                request.Options.RemoteIpv6NetworkCidr = requestOptions_options_RemoteIpv6NetworkCidr;
                requestOptionsIsNull = false;
            }
            System.Boolean? requestOptions_options_StaticRoutesOnly = null;
            if (cmdletContext.Options_StaticRoutesOnly != null)
            {
                requestOptions_options_StaticRoutesOnly = cmdletContext.Options_StaticRoutesOnly.Value;
            }
            if (requestOptions_options_StaticRoutesOnly != null)
            {
                request.Options.StaticRoutesOnly = requestOptions_options_StaticRoutesOnly.Value;
                requestOptionsIsNull = false;
            }
            System.String requestOptions_options_TransportTransitGatewayAttachmentId = null;
            if (cmdletContext.Options_TransportTransitGatewayAttachmentId != null)
            {
                requestOptions_options_TransportTransitGatewayAttachmentId = cmdletContext.Options_TransportTransitGatewayAttachmentId;
            }
            if (requestOptions_options_TransportTransitGatewayAttachmentId != null)
            {
                request.Options.TransportTransitGatewayAttachmentId = requestOptions_options_TransportTransitGatewayAttachmentId;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.TunnelInsideIpVersion requestOptions_options_TunnelInsideIpVersion = null;
            if (cmdletContext.Options_TunnelInsideIpVersion != null)
            {
                requestOptions_options_TunnelInsideIpVersion = cmdletContext.Options_TunnelInsideIpVersion;
            }
            if (requestOptions_options_TunnelInsideIpVersion != null)
            {
                request.Options.TunnelInsideIpVersion = requestOptions_options_TunnelInsideIpVersion;
                requestOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.VpnTunnelOptionsSpecification> requestOptions_options_TunnelOption = null;
            if (cmdletContext.Options_TunnelOption != null)
            {
                requestOptions_options_TunnelOption = cmdletContext.Options_TunnelOption;
            }
            if (requestOptions_options_TunnelOption != null)
            {
                request.Options.TunnelOptions = requestOptions_options_TunnelOption;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.VpnGatewayId != null)
            {
                request.VpnGatewayId = cmdletContext.VpnGatewayId;
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
        
        private Amazon.EC2.Model.CreateVpnConnectionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpnConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpnConnection");
            try
            {
                #if DESKTOP
                return client.CreateVpnConnection(request);
                #elif CORECLR
                return client.CreateVpnConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerGatewayId { get; set; }
            public System.Boolean? Options_EnableAcceleration { get; set; }
            public System.String Options_LocalIpv4NetworkCidr { get; set; }
            public System.String Options_LocalIpv6NetworkCidr { get; set; }
            public System.String Options_OutsideIpAddressType { get; set; }
            public System.String Options_RemoteIpv4NetworkCidr { get; set; }
            public System.String Options_RemoteIpv6NetworkCidr { get; set; }
            public System.Boolean? Options_StaticRoutesOnly { get; set; }
            public System.String Options_TransportTransitGatewayAttachmentId { get; set; }
            public Amazon.EC2.TunnelInsideIpVersion Options_TunnelInsideIpVersion { get; set; }
            public List<Amazon.EC2.Model.VpnTunnelOptionsSpecification> Options_TunnelOption { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.String Type { get; set; }
            public System.String VpnGatewayId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpnConnectionResponse, NewEC2VpnConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnection;
        }
        
    }
}
