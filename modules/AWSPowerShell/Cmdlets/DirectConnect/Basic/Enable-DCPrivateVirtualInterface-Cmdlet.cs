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
    /// Provisions a private virtual interface to be owned by the specified account.
    /// 
    ///  
    /// <para>
    /// Virtual interfaces created using this action must be confirmed by the owner using
    /// <a>ConfirmPrivateVirtualInterface</a>. Until then, the virtual interface is in the
    /// <code>Confirming</code> state and is not available to handle traffic.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DCPrivateVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect AllocatePrivateVirtualInterface API operation.", Operation = new[] {"AllocatePrivateVirtualInterface"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterfaceAllocation_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterfaceAllocation_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_Asn
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
        public System.Int32? NewPrivateVirtualInterfaceAllocation_Asn { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterfaceAllocation_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection on which the private virtual interface is provisioned.</para>
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
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPrivateVirtualInterfaceAllocation_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_Mtu
        /// <summary>
        /// <para>
        /// <para>The maximum transmission unit (MTU), in bytes. The supported values are 1500 and 9001.
        /// The default value is 1500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewPrivateVirtualInterfaceAllocation_Mtu { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the account that owns the virtual private interface.</para>
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
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the private virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewPrivateVirtualInterfaceAllocation_Tags")]
        public Amazon.DirectConnect.Model.Tag[] NewPrivateVirtualInterfaceAllocation_Tag { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName
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
        public System.String NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_Vlan
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
        public System.Int32? NewPrivateVirtualInterfaceAllocation_Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCPrivateVirtualInterface (AllocatePrivateVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse, EnableDCPrivateVirtualInterfaceCmdlet>(Select) ??
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
            context.NewPrivateVirtualInterfaceAllocation_AddressFamily = this.NewPrivateVirtualInterfaceAllocation_AddressFamily;
            context.NewPrivateVirtualInterfaceAllocation_AmazonAddress = this.NewPrivateVirtualInterfaceAllocation_AmazonAddress;
            context.NewPrivateVirtualInterfaceAllocation_Asn = this.NewPrivateVirtualInterfaceAllocation_Asn;
            #if MODULAR
            if (this.NewPrivateVirtualInterfaceAllocation_Asn == null && ParameterWasBound(nameof(this.NewPrivateVirtualInterfaceAllocation_Asn)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrivateVirtualInterfaceAllocation_Asn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPrivateVirtualInterfaceAllocation_AuthKey = this.NewPrivateVirtualInterfaceAllocation_AuthKey;
            context.NewPrivateVirtualInterfaceAllocation_CustomerAddress = this.NewPrivateVirtualInterfaceAllocation_CustomerAddress;
            context.NewPrivateVirtualInterfaceAllocation_Mtu = this.NewPrivateVirtualInterfaceAllocation_Mtu;
            if (this.NewPrivateVirtualInterfaceAllocation_Tag != null)
            {
                context.NewPrivateVirtualInterfaceAllocation_Tag = new List<Amazon.DirectConnect.Model.Tag>(this.NewPrivateVirtualInterfaceAllocation_Tag);
            }
            context.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName = this.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
            #if MODULAR
            if (this.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName == null && ParameterWasBound(nameof(this.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPrivateVirtualInterfaceAllocation_Vlan = this.NewPrivateVirtualInterfaceAllocation_Vlan;
            #if MODULAR
            if (this.NewPrivateVirtualInterfaceAllocation_Vlan == null && ParameterWasBound(nameof(this.NewPrivateVirtualInterfaceAllocation_Vlan)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPrivateVirtualInterfaceAllocation_Vlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPrivateVirtualInterfaceAllocation
            var requestNewPrivateVirtualInterfaceAllocationIsNull = true;
            request.NewPrivateVirtualInterfaceAllocation = new Amazon.DirectConnect.Model.NewPrivateVirtualInterfaceAllocation();
            Amazon.DirectConnect.AddressFamily requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AddressFamily = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_AddressFamily != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AddressFamily = cmdletContext.NewPrivateVirtualInterfaceAllocation_AddressFamily;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AddressFamily != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.AddressFamily = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AddressFamily;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_AmazonAddress != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress = cmdletContext.NewPrivateVirtualInterfaceAllocation_AmazonAddress;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.AmazonAddress = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_Asn != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn = cmdletContext.NewPrivateVirtualInterfaceAllocation_Asn.Value;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.Asn = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn.Value;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_AuthKey != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey = cmdletContext.NewPrivateVirtualInterfaceAllocation_AuthKey;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.AuthKey = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_CustomerAddress != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress = cmdletContext.NewPrivateVirtualInterfaceAllocation_CustomerAddress;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.CustomerAddress = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Mtu = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_Mtu != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Mtu = cmdletContext.NewPrivateVirtualInterfaceAllocation_Mtu.Value;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Mtu != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.Mtu = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Mtu.Value;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            List<Amazon.DirectConnect.Model.Tag> requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Tag = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_Tag != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Tag = cmdletContext.NewPrivateVirtualInterfaceAllocation_Tag;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Tag != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.Tags = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Tag;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName = cmdletContext.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.VirtualInterfaceName = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Vlan = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_Vlan != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Vlan = cmdletContext.NewPrivateVirtualInterfaceAllocation_Vlan.Value;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Vlan != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.Vlan = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Vlan.Value;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
             // determine if request.NewPrivateVirtualInterfaceAllocation should be set to null
            if (requestNewPrivateVirtualInterfaceAllocationIsNull)
            {
                request.NewPrivateVirtualInterfaceAllocation = null;
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
        
        private Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AllocatePrivateVirtualInterface");
            try
            {
                #if DESKTOP
                return client.AllocatePrivateVirtualInterface(request);
                #elif CORECLR
                return client.AllocatePrivateVirtualInterfaceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterfaceAllocation_AddressFamily { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_AmazonAddress { get; set; }
            public System.Int32? NewPrivateVirtualInterfaceAllocation_Asn { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_AuthKey { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_CustomerAddress { get; set; }
            public System.Int32? NewPrivateVirtualInterfaceAllocation_Mtu { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> NewPrivateVirtualInterfaceAllocation_Tag { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
            public System.Int32? NewPrivateVirtualInterfaceAllocation_Vlan { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Func<Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse, EnableDCPrivateVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
