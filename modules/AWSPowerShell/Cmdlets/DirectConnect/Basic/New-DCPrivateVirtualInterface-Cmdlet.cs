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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a private virtual interface. A virtual interface is the VLAN that transports
    /// Direct Connect traffic. A private virtual interface can be connected to either a Direct
    /// Connect gateway or a Virtual Private Gateway (VGW). Connecting the private virtual
    /// interface to a Direct Connect gateway enables the possibility for connecting to multiple
    /// VPCs, including VPCs in different Amazon Web Services Regions. Connecting the private
    /// virtual interface to a VGW only provides access to a single VPC within the same Region.
    /// 
    ///  
    /// <para>
    /// Setting the MTU of a virtual interface to 8500 (jumbo frames) can cause an update
    /// to the underlying physical connection if it wasn't updated to support jumbo frames.
    /// Updating the connection disrupts network connectivity for all virtual interfaces associated
    /// with the connection for up to 30 seconds. To check whether your connection supports
    /// jumbo frames, call <a>DescribeConnections</a>. To check whether your virtual interface
    /// supports jumbo frames, call <a>DescribeVirtualInterfaces</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCPrivateVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreatePrivateVirtualInterface API operation.", Operation = new[] {"CreatePrivateVirtualInterface"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse object containing multiple properties."
    )]
    public partial class NewDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NewPrivateVirtualInterface_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterface_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterface_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system (AS) number for Border Gateway Protocol (BGP) configuration.</para><para>The valid values are 1-2147483647.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NewPrivateVirtualInterface_Asn { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterface_AuthKey { get; set; }
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
        
        #region Parameter NewPrivateVirtualInterface_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterface_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterface_DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_EnableSiteLink
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable SiteLink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NewPrivateVirtualInterface_EnableSiteLink { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_Mtu
        /// <summary>
        /// <para>
        /// <para>The maximum transmission unit (MTU), in bytes. The supported values are 1500 and 8500.
        /// The default value is 1500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewPrivateVirtualInterface_Mtu { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the private virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewPrivateVirtualInterface_Tags")]
        public Amazon.DirectConnect.Model.Tag[] NewPrivateVirtualInterface_Tag { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_VirtualGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterface_VirtualGatewayId { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual interface assigned by the customer network. The name has a
        /// maximum of 100 characters. The following are valid characters: a-z, 0-9 and a hyphen
        /// (-).</para>
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
        public System.String NewPrivateVirtualInterface_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_Vlan
        /// <summary>
        /// <para>
        /// <para>The ID of the VLAN.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NewPrivateVirtualInterface_Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCPrivateVirtualInterface (CreatePrivateVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse, NewDCPrivateVirtualInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionId = this.ConnectionId;
            #if MODULAR
            if (this.ConnectionId == null && ParameterWasBound(nameof(this.ConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPrivateVirtualInterface_AddressFamily = this.NewPrivateVirtualInterface_AddressFamily;
            context.NewPrivateVirtualInterface_AmazonAddress = this.NewPrivateVirtualInterface_AmazonAddress;
            context.NewPrivateVirtualInterface_Asn = this.NewPrivateVirtualInterface_Asn;
            #if MODULAR
            if (this.NewPrivateVirtualInterface_Asn == null && ParameterWasBound(nameof(this.NewPrivateVirtualInterface_Asn)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrivateVirtualInterface_Asn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPrivateVirtualInterface_AuthKey = this.NewPrivateVirtualInterface_AuthKey;
            context.NewPrivateVirtualInterface_CustomerAddress = this.NewPrivateVirtualInterface_CustomerAddress;
            context.NewPrivateVirtualInterface_DirectConnectGatewayId = this.NewPrivateVirtualInterface_DirectConnectGatewayId;
            context.NewPrivateVirtualInterface_EnableSiteLink = this.NewPrivateVirtualInterface_EnableSiteLink;
            context.NewPrivateVirtualInterface_Mtu = this.NewPrivateVirtualInterface_Mtu;
            if (this.NewPrivateVirtualInterface_Tag != null)
            {
                context.NewPrivateVirtualInterface_Tag = new List<Amazon.DirectConnect.Model.Tag>(this.NewPrivateVirtualInterface_Tag);
            }
            context.NewPrivateVirtualInterface_VirtualGatewayId = this.NewPrivateVirtualInterface_VirtualGatewayId;
            context.NewPrivateVirtualInterface_VirtualInterfaceName = this.NewPrivateVirtualInterface_VirtualInterfaceName;
            #if MODULAR
            if (this.NewPrivateVirtualInterface_VirtualInterfaceName == null && ParameterWasBound(nameof(this.NewPrivateVirtualInterface_VirtualInterfaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrivateVirtualInterface_VirtualInterfaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPrivateVirtualInterface_Vlan = this.NewPrivateVirtualInterface_Vlan;
            #if MODULAR
            if (this.NewPrivateVirtualInterface_Vlan == null && ParameterWasBound(nameof(this.NewPrivateVirtualInterface_Vlan)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrivateVirtualInterface_Vlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPrivateVirtualInterface
            var requestNewPrivateVirtualInterfaceIsNull = true;
            request.NewPrivateVirtualInterface = new Amazon.DirectConnect.Model.NewPrivateVirtualInterface();
            Amazon.DirectConnect.AddressFamily requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AddressFamily = null;
            if (cmdletContext.NewPrivateVirtualInterface_AddressFamily != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AddressFamily = cmdletContext.NewPrivateVirtualInterface_AddressFamily;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AddressFamily != null)
            {
                request.NewPrivateVirtualInterface.AddressFamily = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AddressFamily;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress = null;
            if (cmdletContext.NewPrivateVirtualInterface_AmazonAddress != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress = cmdletContext.NewPrivateVirtualInterface_AmazonAddress;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress != null)
            {
                request.NewPrivateVirtualInterface.AmazonAddress = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn = null;
            if (cmdletContext.NewPrivateVirtualInterface_Asn != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn = cmdletContext.NewPrivateVirtualInterface_Asn.Value;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn != null)
            {
                request.NewPrivateVirtualInterface.Asn = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn.Value;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey = null;
            if (cmdletContext.NewPrivateVirtualInterface_AuthKey != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey = cmdletContext.NewPrivateVirtualInterface_AuthKey;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey != null)
            {
                request.NewPrivateVirtualInterface.AuthKey = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress = null;
            if (cmdletContext.NewPrivateVirtualInterface_CustomerAddress != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress = cmdletContext.NewPrivateVirtualInterface_CustomerAddress;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress != null)
            {
                request.NewPrivateVirtualInterface.CustomerAddress = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_DirectConnectGatewayId = null;
            if (cmdletContext.NewPrivateVirtualInterface_DirectConnectGatewayId != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_DirectConnectGatewayId = cmdletContext.NewPrivateVirtualInterface_DirectConnectGatewayId;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_DirectConnectGatewayId != null)
            {
                request.NewPrivateVirtualInterface.DirectConnectGatewayId = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_DirectConnectGatewayId;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.Boolean? requestNewPrivateVirtualInterface_newPrivateVirtualInterface_EnableSiteLink = null;
            if (cmdletContext.NewPrivateVirtualInterface_EnableSiteLink != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_EnableSiteLink = cmdletContext.NewPrivateVirtualInterface_EnableSiteLink.Value;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_EnableSiteLink != null)
            {
                request.NewPrivateVirtualInterface.EnableSiteLink = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_EnableSiteLink.Value;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Mtu = null;
            if (cmdletContext.NewPrivateVirtualInterface_Mtu != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Mtu = cmdletContext.NewPrivateVirtualInterface_Mtu.Value;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Mtu != null)
            {
                request.NewPrivateVirtualInterface.Mtu = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Mtu.Value;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            List<Amazon.DirectConnect.Model.Tag> requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Tag = null;
            if (cmdletContext.NewPrivateVirtualInterface_Tag != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Tag = cmdletContext.NewPrivateVirtualInterface_Tag;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Tag != null)
            {
                request.NewPrivateVirtualInterface.Tags = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Tag;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId = null;
            if (cmdletContext.NewPrivateVirtualInterface_VirtualGatewayId != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId = cmdletContext.NewPrivateVirtualInterface_VirtualGatewayId;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId != null)
            {
                request.NewPrivateVirtualInterface.VirtualGatewayId = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName = null;
            if (cmdletContext.NewPrivateVirtualInterface_VirtualInterfaceName != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName = cmdletContext.NewPrivateVirtualInterface_VirtualInterfaceName;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName != null)
            {
                request.NewPrivateVirtualInterface.VirtualInterfaceName = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Vlan = null;
            if (cmdletContext.NewPrivateVirtualInterface_Vlan != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Vlan = cmdletContext.NewPrivateVirtualInterface_Vlan.Value;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Vlan != null)
            {
                request.NewPrivateVirtualInterface.Vlan = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Vlan.Value;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
             // determine if request.NewPrivateVirtualInterface should be set to null
            if (requestNewPrivateVirtualInterfaceIsNull)
            {
                request.NewPrivateVirtualInterface = null;
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
        
        private Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreatePrivateVirtualInterface");
            try
            {
                return client.CreatePrivateVirtualInterfaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterface_AddressFamily { get; set; }
            public System.String NewPrivateVirtualInterface_AmazonAddress { get; set; }
            public System.Int32? NewPrivateVirtualInterface_Asn { get; set; }
            public System.String NewPrivateVirtualInterface_AuthKey { get; set; }
            public System.String NewPrivateVirtualInterface_CustomerAddress { get; set; }
            public System.String NewPrivateVirtualInterface_DirectConnectGatewayId { get; set; }
            public System.Boolean? NewPrivateVirtualInterface_EnableSiteLink { get; set; }
            public System.Int32? NewPrivateVirtualInterface_Mtu { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> NewPrivateVirtualInterface_Tag { get; set; }
            public System.String NewPrivateVirtualInterface_VirtualGatewayId { get; set; }
            public System.String NewPrivateVirtualInterface_VirtualInterfaceName { get; set; }
            public System.Int32? NewPrivateVirtualInterface_Vlan { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse, NewDCPrivateVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
