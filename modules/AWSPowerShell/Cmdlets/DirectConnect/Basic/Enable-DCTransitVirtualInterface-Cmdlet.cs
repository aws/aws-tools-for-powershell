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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Provisions a transit virtual interface to be owned by the specified Amazon Web Services
    /// account. Use this type of interface to connect a transit gateway to your Direct Connect
    /// gateway.
    /// 
    ///  
    /// <para>
    /// The owner of a connection provisions a transit virtual interface to be owned by the
    /// specified Amazon Web Services account.
    /// </para><para>
    /// After you create a transit virtual interface, it must be confirmed by the owner using
    /// <a>ConfirmTransitVirtualInterface</a>. Until this step has been completed, the transit
    /// virtual interface is in the <c>requested</c> state and is not available to handle
    /// traffic.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DCTransitVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterface")]
    [AWSCmdlet("Calls the AWS Direct Connect AllocateTransitVirtualInterface API operation.", Operation = new[] {"AllocateTransitVirtualInterface"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterface or Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.VirtualInterface object.",
        "The service call response (type Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableDCTransitVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NewTransitVirtualInterfaceAllocation_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewTransitVirtualInterfaceAllocation_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterfaceAllocation_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system (AS) number for Border Gateway Protocol (BGP) configuration.</para><para>The valid values are 1-2147483647.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewTransitVirtualInterfaceAllocation_Asn { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterfaceAllocation_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection on which the transit virtual interface is provisioned.</para>
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
        
        #region Parameter NewTransitVirtualInterfaceAllocation_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterfaceAllocation_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_Mtu
        /// <summary>
        /// <para>
        /// <para>The maximum transmission unit (MTU), in bytes. The supported values are 1500 and 8500.
        /// The default value is 1500 </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewTransitVirtualInterfaceAllocation_Mtu { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the transit virtual interface.</para>
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
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the transitive virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewTransitVirtualInterfaceAllocation_Tags")]
        public Amazon.DirectConnect.Model.Tag[] NewTransitVirtualInterfaceAllocation_Tag { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual interface assigned by the customer network. The name has a
        /// maximum of 100 characters. The following are valid characters: a-z, 0-9 and a hyphen
        /// (-).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewTransitVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewTransitVirtualInterfaceAllocation_Vlan
        /// <summary>
        /// <para>
        /// <para>The ID of the VLAN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewTransitVirtualInterfaceAllocation_Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCTransitVirtualInterface (AllocateTransitVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse, EnableDCTransitVirtualInterfaceCmdlet>(Select) ??
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
            context.NewTransitVirtualInterfaceAllocation_AddressFamily = this.NewTransitVirtualInterfaceAllocation_AddressFamily;
            context.NewTransitVirtualInterfaceAllocation_AmazonAddress = this.NewTransitVirtualInterfaceAllocation_AmazonAddress;
            context.NewTransitVirtualInterfaceAllocation_Asn = this.NewTransitVirtualInterfaceAllocation_Asn;
            context.NewTransitVirtualInterfaceAllocation_AuthKey = this.NewTransitVirtualInterfaceAllocation_AuthKey;
            context.NewTransitVirtualInterfaceAllocation_CustomerAddress = this.NewTransitVirtualInterfaceAllocation_CustomerAddress;
            context.NewTransitVirtualInterfaceAllocation_Mtu = this.NewTransitVirtualInterfaceAllocation_Mtu;
            if (this.NewTransitVirtualInterfaceAllocation_Tag != null)
            {
                context.NewTransitVirtualInterfaceAllocation_Tag = new List<Amazon.DirectConnect.Model.Tag>(this.NewTransitVirtualInterfaceAllocation_Tag);
            }
            context.NewTransitVirtualInterfaceAllocation_VirtualInterfaceName = this.NewTransitVirtualInterfaceAllocation_VirtualInterfaceName;
            context.NewTransitVirtualInterfaceAllocation_Vlan = this.NewTransitVirtualInterfaceAllocation_Vlan;
            context.OwnerAccount = this.OwnerAccount;
            #if MODULAR
            if (this.OwnerAccount == null && ParameterWasBound(nameof(this.OwnerAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter OwnerAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewTransitVirtualInterfaceAllocation
            var requestNewTransitVirtualInterfaceAllocationIsNull = true;
            request.NewTransitVirtualInterfaceAllocation = new Amazon.DirectConnect.Model.NewTransitVirtualInterfaceAllocation();
            Amazon.DirectConnect.AddressFamily requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AddressFamily = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_AddressFamily != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AddressFamily = cmdletContext.NewTransitVirtualInterfaceAllocation_AddressFamily;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AddressFamily != null)
            {
                request.NewTransitVirtualInterfaceAllocation.AddressFamily = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AddressFamily;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AmazonAddress = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_AmazonAddress != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AmazonAddress = cmdletContext.NewTransitVirtualInterfaceAllocation_AmazonAddress;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AmazonAddress != null)
            {
                request.NewTransitVirtualInterfaceAllocation.AmazonAddress = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AmazonAddress;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Asn = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_Asn != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Asn = cmdletContext.NewTransitVirtualInterfaceAllocation_Asn.Value;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Asn != null)
            {
                request.NewTransitVirtualInterfaceAllocation.Asn = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Asn.Value;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AuthKey = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_AuthKey != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AuthKey = cmdletContext.NewTransitVirtualInterfaceAllocation_AuthKey;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AuthKey != null)
            {
                request.NewTransitVirtualInterfaceAllocation.AuthKey = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_AuthKey;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_CustomerAddress = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_CustomerAddress != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_CustomerAddress = cmdletContext.NewTransitVirtualInterfaceAllocation_CustomerAddress;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_CustomerAddress != null)
            {
                request.NewTransitVirtualInterfaceAllocation.CustomerAddress = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_CustomerAddress;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Mtu = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_Mtu != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Mtu = cmdletContext.NewTransitVirtualInterfaceAllocation_Mtu.Value;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Mtu != null)
            {
                request.NewTransitVirtualInterfaceAllocation.Mtu = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Mtu.Value;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            List<Amazon.DirectConnect.Model.Tag> requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Tag = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_Tag != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Tag = cmdletContext.NewTransitVirtualInterfaceAllocation_Tag;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Tag != null)
            {
                request.NewTransitVirtualInterfaceAllocation.Tags = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Tag;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_VirtualInterfaceName = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_VirtualInterfaceName = cmdletContext.NewTransitVirtualInterfaceAllocation_VirtualInterfaceName;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                request.NewTransitVirtualInterfaceAllocation.VirtualInterfaceName = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_VirtualInterfaceName;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Vlan = null;
            if (cmdletContext.NewTransitVirtualInterfaceAllocation_Vlan != null)
            {
                requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Vlan = cmdletContext.NewTransitVirtualInterfaceAllocation_Vlan.Value;
            }
            if (requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Vlan != null)
            {
                request.NewTransitVirtualInterfaceAllocation.Vlan = requestNewTransitVirtualInterfaceAllocation_newTransitVirtualInterfaceAllocation_Vlan.Value;
                requestNewTransitVirtualInterfaceAllocationIsNull = false;
            }
             // determine if request.NewTransitVirtualInterfaceAllocation should be set to null
            if (requestNewTransitVirtualInterfaceAllocationIsNull)
            {
                request.NewTransitVirtualInterfaceAllocation = null;
            }
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
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
        
        private Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AllocateTransitVirtualInterface");
            try
            {
                #if DESKTOP
                return client.AllocateTransitVirtualInterface(request);
                #elif CORECLR
                return client.AllocateTransitVirtualInterfaceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily NewTransitVirtualInterfaceAllocation_AddressFamily { get; set; }
            public System.String NewTransitVirtualInterfaceAllocation_AmazonAddress { get; set; }
            public System.Int32? NewTransitVirtualInterfaceAllocation_Asn { get; set; }
            public System.String NewTransitVirtualInterfaceAllocation_AuthKey { get; set; }
            public System.String NewTransitVirtualInterfaceAllocation_CustomerAddress { get; set; }
            public System.Int32? NewTransitVirtualInterfaceAllocation_Mtu { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> NewTransitVirtualInterfaceAllocation_Tag { get; set; }
            public System.String NewTransitVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
            public System.Int32? NewTransitVirtualInterfaceAllocation_Vlan { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Func<Amazon.DirectConnect.Model.AllocateTransitVirtualInterfaceResponse, EnableDCTransitVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualInterface;
        }
        
    }
}
