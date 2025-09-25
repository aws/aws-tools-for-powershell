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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a transit virtual interface. A transit virtual interface should be used to
    /// access one or more transit gateways associated with Direct Connect gateways. A transit
    /// virtual interface enables the connection of multiple VPCs attached to a transit gateway
    /// to a Direct Connect gateway.
    /// 
    ///  <important><para>
    /// If you associate your transit gateway with one or more Direct Connect gateways, the
    /// Autonomous System Number (ASN) used by the transit gateway and the Direct Connect
    /// gateway must be different. For example, if you use the default ASN 64512 for both
    /// your the transit gateway and Direct Connect gateway, the association request fails.
    /// </para></important><para>
    /// A jumbo MTU value must be either 1500 or 8500. No other values will be accepted. Setting
    /// the MTU of a virtual interface to 8500 (jumbo frames) can cause an update to the underlying
    /// physical connection if it wasn't updated to support jumbo frames. Updating the connection
    /// disrupts network connectivity for all virtual interfaces associated with the connection
    /// for up to 30 seconds. To check whether your connection supports jumbo frames, call
    /// <a>DescribeConnections</a>. To check whether your virtual interface supports jumbo
    /// frames, call <a>DescribeVirtualInterfaces</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCTransitVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterface")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateTransitVirtualInterface API operation.", Operation = new[] {"CreateTransitVirtualInterface"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterface or Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.VirtualInterface object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDCTransitVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NewTransitVirtualInterface_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewTransitVirtualInterface_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterface_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system number (ASN). The valid range is from 1 to 2147483646 for Border
        /// Gateway Protocol (BGP) configuration. If you provide a number greater than the maximum,
        /// an error is returned. Use <c>asnLong</c> instead.</para><note><para>You can use <c>asnLong</c> or <c>asn</c>, but not both. We recommend using <c>asnLong</c>
        /// as it supports a greater pool of numbers. </para><ul><li><para>The <c>asnLong</c> attribute accepts both ASN and long ASN ranges.</para></li><li><para>If you provide a value in the same API call for both <c>asn</c> and <c>asnLong</c>,
        /// the API will only accept the value for <c>asnLong</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewTransitVirtualInterface_Asn { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_AsnLong
        /// <summary>
        /// <para>
        /// <para>The long ASN for a new transit virtual interface.The valid range is from 1 to 4294967294
        /// for BGP configuration.</para><note><para>You can use <c>asnLong</c> or <c>asn</c>, but not both. We recommend using <c>asnLong</c>
        /// as it supports a greater pool of numbers. </para><ul><li><para>The <c>asnLong</c> attribute accepts both ASN and long ASN ranges.</para></li><li><para>If you provide a value in the same API call for both <c>asn</c> and <c>asnLong</c>,
        /// the API will only accept the value for <c>asnLong</c>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? NewTransitVirtualInterface_AsnLong { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterface_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection.</para>
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
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterface_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterface_DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_EnableSiteLink
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable SiteLink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NewTransitVirtualInterface_EnableSiteLink { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_Mtu
        /// <summary>
        /// <para>
        /// <para>The maximum transmission unit (MTU), in bytes. The supported values are 1500 and 8500.
        /// The default value is 1500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewTransitVirtualInterface_Mtu { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the transitive virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewTransitVirtualInterface_Tags")]
        public Amazon.DirectConnect.Model.Tag[] NewTransitVirtualInterface_Tag { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual interface assigned by the customer network. The name has a
        /// maximum of 100 characters. The following are valid characters: a-z, 0-9 and a hyphen
        /// (-).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterface_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterface_Vlan
        /// <summary>
        /// <para>
        /// <para>The ID of the VLAN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewTransitVirtualInterface_Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualInterface";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCTransitVirtualInterface (CreateTransitVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse, NewDCTransitVirtualInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectionId = this.ConnectionId;
            #if MODULAR
            if (this.ConnectionId == null && ParameterWasBound(nameof(this.ConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewTransitVirtualInterface_AddressFamily = this.NewTransitVirtualInterface_AddressFamily;
            context.NewTransitVirtualInterface_AmazonAddress = this.NewTransitVirtualInterface_AmazonAddress;
            context.NewTransitVirtualInterface_Asn = this.NewTransitVirtualInterface_Asn;
            context.NewTransitVirtualInterface_AsnLong = this.NewTransitVirtualInterface_AsnLong;
            context.NewTransitVirtualInterface_AuthKey = this.NewTransitVirtualInterface_AuthKey;
            context.NewTransitVirtualInterface_CustomerAddress = this.NewTransitVirtualInterface_CustomerAddress;
            context.NewTransitVirtualInterface_DirectConnectGatewayId = this.NewTransitVirtualInterface_DirectConnectGatewayId;
            context.NewTransitVirtualInterface_EnableSiteLink = this.NewTransitVirtualInterface_EnableSiteLink;
            context.NewTransitVirtualInterface_Mtu = this.NewTransitVirtualInterface_Mtu;
            if (this.NewTransitVirtualInterface_Tag != null)
            {
                context.NewTransitVirtualInterface_Tag = new List<Amazon.DirectConnect.Model.Tag>(this.NewTransitVirtualInterface_Tag);
            }
            context.NewTransitVirtualInterface_VirtualInterfaceName = this.NewTransitVirtualInterface_VirtualInterfaceName;
            context.NewTransitVirtualInterface_Vlan = this.NewTransitVirtualInterface_Vlan;
            
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
            var request = new Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewTransitVirtualInterface
            var requestNewTransitVirtualInterfaceIsNull = true;
            request.NewTransitVirtualInterface = new Amazon.DirectConnect.Model.NewTransitVirtualInterface();
            Amazon.DirectConnect.AddressFamily requestNewTransitVirtualInterface_newTransitVirtualInterface_AddressFamily = null;
            if (cmdletContext.NewTransitVirtualInterface_AddressFamily != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_AddressFamily = cmdletContext.NewTransitVirtualInterface_AddressFamily;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_AddressFamily != null)
            {
                request.NewTransitVirtualInterface.AddressFamily = requestNewTransitVirtualInterface_newTransitVirtualInterface_AddressFamily;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.String requestNewTransitVirtualInterface_newTransitVirtualInterface_AmazonAddress = null;
            if (cmdletContext.NewTransitVirtualInterface_AmazonAddress != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_AmazonAddress = cmdletContext.NewTransitVirtualInterface_AmazonAddress;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_AmazonAddress != null)
            {
                request.NewTransitVirtualInterface.AmazonAddress = requestNewTransitVirtualInterface_newTransitVirtualInterface_AmazonAddress;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewTransitVirtualInterface_newTransitVirtualInterface_Asn = null;
            if (cmdletContext.NewTransitVirtualInterface_Asn != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_Asn = cmdletContext.NewTransitVirtualInterface_Asn.Value;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_Asn != null)
            {
                request.NewTransitVirtualInterface.Asn = requestNewTransitVirtualInterface_newTransitVirtualInterface_Asn.Value;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.Int64? requestNewTransitVirtualInterface_newTransitVirtualInterface_AsnLong = null;
            if (cmdletContext.NewTransitVirtualInterface_AsnLong != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_AsnLong = cmdletContext.NewTransitVirtualInterface_AsnLong.Value;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_AsnLong != null)
            {
                request.NewTransitVirtualInterface.AsnLong = requestNewTransitVirtualInterface_newTransitVirtualInterface_AsnLong.Value;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.String requestNewTransitVirtualInterface_newTransitVirtualInterface_AuthKey = null;
            if (cmdletContext.NewTransitVirtualInterface_AuthKey != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_AuthKey = cmdletContext.NewTransitVirtualInterface_AuthKey;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_AuthKey != null)
            {
                request.NewTransitVirtualInterface.AuthKey = requestNewTransitVirtualInterface_newTransitVirtualInterface_AuthKey;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.String requestNewTransitVirtualInterface_newTransitVirtualInterface_CustomerAddress = null;
            if (cmdletContext.NewTransitVirtualInterface_CustomerAddress != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_CustomerAddress = cmdletContext.NewTransitVirtualInterface_CustomerAddress;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_CustomerAddress != null)
            {
                request.NewTransitVirtualInterface.CustomerAddress = requestNewTransitVirtualInterface_newTransitVirtualInterface_CustomerAddress;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.String requestNewTransitVirtualInterface_newTransitVirtualInterface_DirectConnectGatewayId = null;
            if (cmdletContext.NewTransitVirtualInterface_DirectConnectGatewayId != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_DirectConnectGatewayId = cmdletContext.NewTransitVirtualInterface_DirectConnectGatewayId;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_DirectConnectGatewayId != null)
            {
                request.NewTransitVirtualInterface.DirectConnectGatewayId = requestNewTransitVirtualInterface_newTransitVirtualInterface_DirectConnectGatewayId;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.Boolean? requestNewTransitVirtualInterface_newTransitVirtualInterface_EnableSiteLink = null;
            if (cmdletContext.NewTransitVirtualInterface_EnableSiteLink != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_EnableSiteLink = cmdletContext.NewTransitVirtualInterface_EnableSiteLink.Value;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_EnableSiteLink != null)
            {
                request.NewTransitVirtualInterface.EnableSiteLink = requestNewTransitVirtualInterface_newTransitVirtualInterface_EnableSiteLink.Value;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewTransitVirtualInterface_newTransitVirtualInterface_Mtu = null;
            if (cmdletContext.NewTransitVirtualInterface_Mtu != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_Mtu = cmdletContext.NewTransitVirtualInterface_Mtu.Value;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_Mtu != null)
            {
                request.NewTransitVirtualInterface.Mtu = requestNewTransitVirtualInterface_newTransitVirtualInterface_Mtu.Value;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            List<Amazon.DirectConnect.Model.Tag> requestNewTransitVirtualInterface_newTransitVirtualInterface_Tag = null;
            if (cmdletContext.NewTransitVirtualInterface_Tag != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_Tag = cmdletContext.NewTransitVirtualInterface_Tag;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_Tag != null)
            {
                request.NewTransitVirtualInterface.Tags = requestNewTransitVirtualInterface_newTransitVirtualInterface_Tag;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.String requestNewTransitVirtualInterface_newTransitVirtualInterface_VirtualInterfaceName = null;
            if (cmdletContext.NewTransitVirtualInterface_VirtualInterfaceName != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_VirtualInterfaceName = cmdletContext.NewTransitVirtualInterface_VirtualInterfaceName;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_VirtualInterfaceName != null)
            {
                request.NewTransitVirtualInterface.VirtualInterfaceName = requestNewTransitVirtualInterface_newTransitVirtualInterface_VirtualInterfaceName;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewTransitVirtualInterface_newTransitVirtualInterface_Vlan = null;
            if (cmdletContext.NewTransitVirtualInterface_Vlan != null)
            {
                requestNewTransitVirtualInterface_newTransitVirtualInterface_Vlan = cmdletContext.NewTransitVirtualInterface_Vlan.Value;
            }
            if (requestNewTransitVirtualInterface_newTransitVirtualInterface_Vlan != null)
            {
                request.NewTransitVirtualInterface.Vlan = requestNewTransitVirtualInterface_newTransitVirtualInterface_Vlan.Value;
                requestNewTransitVirtualInterfaceIsNull = false;
            }
             // determine if request.NewTransitVirtualInterface should be set to null
            if (requestNewTransitVirtualInterfaceIsNull)
            {
                request.NewTransitVirtualInterface = null;
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
        
        private Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateTransitVirtualInterface");
            try
            {
                #if DESKTOP
                return client.CreateTransitVirtualInterface(request);
                #elif CORECLR
                return client.CreateTransitVirtualInterfaceAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectionId { get; set; }
            public Amazon.DirectConnect.AddressFamily NewTransitVirtualInterface_AddressFamily { get; set; }
            public System.String NewTransitVirtualInterface_AmazonAddress { get; set; }
            public System.Int32? NewTransitVirtualInterface_Asn { get; set; }
            public System.Int64? NewTransitVirtualInterface_AsnLong { get; set; }
            public System.String NewTransitVirtualInterface_AuthKey { get; set; }
            public System.String NewTransitVirtualInterface_CustomerAddress { get; set; }
            public System.String NewTransitVirtualInterface_DirectConnectGatewayId { get; set; }
            public System.Boolean? NewTransitVirtualInterface_EnableSiteLink { get; set; }
            public System.Int32? NewTransitVirtualInterface_Mtu { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> NewTransitVirtualInterface_Tag { get; set; }
            public System.String NewTransitVirtualInterface_VirtualInterfaceName { get; set; }
            public System.Int32? NewTransitVirtualInterface_Vlan { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreateTransitVirtualInterfaceResponse, NewDCTransitVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualInterface;
        }
        
    }
}
