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
    /// Provisions a public virtual interface to be owned by the specified Amazon Web Services
    /// account.
    /// 
    ///  
    /// <para>
    /// The owner of a connection calls this function to provision a public virtual interface
    /// to be owned by the specified Amazon Web Services account.
    /// </para><para>
    /// Virtual interfaces created using this function must be confirmed by the owner using
    /// <a>ConfirmPublicVirtualInterface</a>. Until this step has been completed, the virtual
    /// interface is in the <c>confirming</c> state and is not available to handle traffic.
    /// </para><para>
    /// When creating an IPv6 public virtual interface, omit the Amazon address and customer
    /// address. IPv6 addresses are automatically assigned from the Amazon pool of IPv6 addresses;
    /// you cannot specify custom IPv6 addresses.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DCPublicVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect AllocatePublicVirtualInterface API operation.", Operation = new[] {"AllocatePublicVirtualInterface"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse object containing multiple properties."
    )]
    public partial class EnableDCPublicVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NewPublicVirtualInterfaceAllocation_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterfaceAllocation_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPublicVirtualInterfaceAllocation_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_Asn
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
        public System.Int32? NewPublicVirtualInterfaceAllocation_Asn { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPublicVirtualInterfaceAllocation_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection on which the public virtual interface is provisioned.</para>
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
        
        #region Parameter NewPublicVirtualInterfaceAllocation_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewPublicVirtualInterfaceAllocation_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the public virtual interface.</para>
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
        
        #region Parameter NewPublicVirtualInterfaceAllocation_RouteFilterPrefix
        /// <summary>
        /// <para>
        /// <para>The routes to be advertised to the Amazon Web Services network in this Region. Applies
        /// to public virtual interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewPublicVirtualInterfaceAllocation_RouteFilterPrefixes")]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] NewPublicVirtualInterfaceAllocation_RouteFilterPrefix { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the public virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewPublicVirtualInterfaceAllocation_Tags")]
        public Amazon.DirectConnect.Model.Tag[] NewPublicVirtualInterfaceAllocation_Tag { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_VirtualInterfaceName
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
        public System.String NewPublicVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_Vlan
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
        public System.Int32? NewPublicVirtualInterfaceAllocation_Vlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCPublicVirtualInterface (AllocatePublicVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse, EnableDCPublicVirtualInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionId = this.ConnectionId;
            #if MODULAR
            if (this.ConnectionId == null && ParameterWasBound(nameof(this.ConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPublicVirtualInterfaceAllocation_AddressFamily = this.NewPublicVirtualInterfaceAllocation_AddressFamily;
            context.NewPublicVirtualInterfaceAllocation_AmazonAddress = this.NewPublicVirtualInterfaceAllocation_AmazonAddress;
            context.NewPublicVirtualInterfaceAllocation_Asn = this.NewPublicVirtualInterfaceAllocation_Asn;
            #if MODULAR
            if (this.NewPublicVirtualInterfaceAllocation_Asn == null && ParameterWasBound(nameof(this.NewPublicVirtualInterfaceAllocation_Asn)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPublicVirtualInterfaceAllocation_Asn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPublicVirtualInterfaceAllocation_AuthKey = this.NewPublicVirtualInterfaceAllocation_AuthKey;
            context.NewPublicVirtualInterfaceAllocation_CustomerAddress = this.NewPublicVirtualInterfaceAllocation_CustomerAddress;
            if (this.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix != null)
            {
                context.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix);
            }
            if (this.NewPublicVirtualInterfaceAllocation_Tag != null)
            {
                context.NewPublicVirtualInterfaceAllocation_Tag = new List<Amazon.DirectConnect.Model.Tag>(this.NewPublicVirtualInterfaceAllocation_Tag);
            }
            context.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName = this.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName;
            #if MODULAR
            if (this.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName == null && ParameterWasBound(nameof(this.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPublicVirtualInterfaceAllocation_VirtualInterfaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPublicVirtualInterfaceAllocation_Vlan = this.NewPublicVirtualInterfaceAllocation_Vlan;
            #if MODULAR
            if (this.NewPublicVirtualInterfaceAllocation_Vlan == null && ParameterWasBound(nameof(this.NewPublicVirtualInterfaceAllocation_Vlan)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPublicVirtualInterfaceAllocation_Vlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPublicVirtualInterfaceAllocation
            var requestNewPublicVirtualInterfaceAllocationIsNull = true;
            request.NewPublicVirtualInterfaceAllocation = new Amazon.DirectConnect.Model.NewPublicVirtualInterfaceAllocation();
            Amazon.DirectConnect.AddressFamily requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AddressFamily = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_AddressFamily != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AddressFamily = cmdletContext.NewPublicVirtualInterfaceAllocation_AddressFamily;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AddressFamily != null)
            {
                request.NewPublicVirtualInterfaceAllocation.AddressFamily = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AddressFamily;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AmazonAddress = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_AmazonAddress != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AmazonAddress = cmdletContext.NewPublicVirtualInterfaceAllocation_AmazonAddress;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AmazonAddress != null)
            {
                request.NewPublicVirtualInterfaceAllocation.AmazonAddress = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AmazonAddress;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Asn = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_Asn != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Asn = cmdletContext.NewPublicVirtualInterfaceAllocation_Asn.Value;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Asn != null)
            {
                request.NewPublicVirtualInterfaceAllocation.Asn = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Asn.Value;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AuthKey = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_AuthKey != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AuthKey = cmdletContext.NewPublicVirtualInterfaceAllocation_AuthKey;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AuthKey != null)
            {
                request.NewPublicVirtualInterfaceAllocation.AuthKey = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_AuthKey;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_CustomerAddress = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_CustomerAddress != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_CustomerAddress = cmdletContext.NewPublicVirtualInterfaceAllocation_CustomerAddress;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_CustomerAddress != null)
            {
                request.NewPublicVirtualInterfaceAllocation.CustomerAddress = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_CustomerAddress;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            List<Amazon.DirectConnect.Model.RouteFilterPrefix> requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix = cmdletContext.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix != null)
            {
                request.NewPublicVirtualInterfaceAllocation.RouteFilterPrefixes = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            List<Amazon.DirectConnect.Model.Tag> requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Tag = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_Tag != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Tag = cmdletContext.NewPublicVirtualInterfaceAllocation_Tag;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Tag != null)
            {
                request.NewPublicVirtualInterfaceAllocation.Tags = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Tag;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            System.String requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_VirtualInterfaceName = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_VirtualInterfaceName = cmdletContext.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                request.NewPublicVirtualInterfaceAllocation.VirtualInterfaceName = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_VirtualInterfaceName;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
            System.Int32? requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Vlan = null;
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_Vlan != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Vlan = cmdletContext.NewPublicVirtualInterfaceAllocation_Vlan.Value;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Vlan != null)
            {
                request.NewPublicVirtualInterfaceAllocation.Vlan = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_Vlan.Value;
                requestNewPublicVirtualInterfaceAllocationIsNull = false;
            }
             // determine if request.NewPublicVirtualInterfaceAllocation should be set to null
            if (requestNewPublicVirtualInterfaceAllocationIsNull)
            {
                request.NewPublicVirtualInterfaceAllocation = null;
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
        
        private Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AllocatePublicVirtualInterface");
            try
            {
                return client.AllocatePublicVirtualInterfaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterfaceAllocation_AddressFamily { get; set; }
            public System.String NewPublicVirtualInterfaceAllocation_AmazonAddress { get; set; }
            public System.Int32? NewPublicVirtualInterfaceAllocation_Asn { get; set; }
            public System.String NewPublicVirtualInterfaceAllocation_AuthKey { get; set; }
            public System.String NewPublicVirtualInterfaceAllocation_CustomerAddress { get; set; }
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> NewPublicVirtualInterfaceAllocation_RouteFilterPrefix { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> NewPublicVirtualInterfaceAllocation_Tag { get; set; }
            public System.String NewPublicVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
            public System.Int32? NewPublicVirtualInterfaceAllocation_Vlan { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Func<Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse, EnableDCPublicVirtualInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
