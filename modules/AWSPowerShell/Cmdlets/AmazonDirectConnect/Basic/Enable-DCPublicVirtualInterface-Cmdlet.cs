/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Provisions a public virtual interface to be owned by a different customer.
    /// 
    ///  
    /// <para>
    /// The owner of a connection calls this function to provision a public virtual interface
    /// which will be owned by another AWS customer.
    /// </para><para>
    /// Virtual interfaces created using this function must be confirmed by the virtual interface
    /// owner by calling ConfirmPublicVirtualInterface. Until this step has been completed,
    /// the virtual interface will be in 'Confirming' state, and will not be available for
    /// handling traffic.
    /// </para><para>
    /// When creating an IPv6 public virtual interface (addressFamily is 'ipv6'), the customer
    /// and amazon address fields should be left blank to use auto-assigned IPv6 space. Custom
    /// IPv6 Addresses are currently not supported.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DCPublicVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse")]
    [AWSCmdlet("Invokes the AllocatePublicVirtualInterface operation against AWS Direct Connect.", Operation = new[] {"AllocatePublicVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.AllocatePublicVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableDCPublicVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewPublicVirtualInterfaceAllocation_AddressFamily
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterfaceAllocation_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_AmazonAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterfaceAllocation_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_Asn
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPublicVirtualInterfaceAllocation_Asn { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_AuthKey
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterfaceAllocation_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The connection ID on which the public virtual interface is provisioned.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_CustomerAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterfaceAllocation_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The AWS account that will own the new public virtual interface.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_RouteFilterPrefix
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewPublicVirtualInterfaceAllocation_RouteFilterPrefixes")]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] NewPublicVirtualInterfaceAllocation_RouteFilterPrefix { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterfaceAllocation_Vlan
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPublicVirtualInterfaceAllocation_Vlan { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConnectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCPublicVirtualInterface (AllocatePublicVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConnectionId = this.ConnectionId;
            context.NewPublicVirtualInterfaceAllocation_AddressFamily = this.NewPublicVirtualInterfaceAllocation_AddressFamily;
            context.NewPublicVirtualInterfaceAllocation_AmazonAddress = this.NewPublicVirtualInterfaceAllocation_AmazonAddress;
            if (ParameterWasBound("NewPublicVirtualInterfaceAllocation_Asn"))
                context.NewPublicVirtualInterfaceAllocation_Asn = this.NewPublicVirtualInterfaceAllocation_Asn;
            context.NewPublicVirtualInterfaceAllocation_AuthKey = this.NewPublicVirtualInterfaceAllocation_AuthKey;
            context.NewPublicVirtualInterfaceAllocation_CustomerAddress = this.NewPublicVirtualInterfaceAllocation_CustomerAddress;
            if (this.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix != null)
            {
                context.NewPublicVirtualInterfaceAllocation_RouteFilterPrefixes = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.NewPublicVirtualInterfaceAllocation_RouteFilterPrefix);
            }
            context.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName = this.NewPublicVirtualInterfaceAllocation_VirtualInterfaceName;
            if (ParameterWasBound("NewPublicVirtualInterfaceAllocation_Vlan"))
                context.NewPublicVirtualInterfaceAllocation_Vlan = this.NewPublicVirtualInterfaceAllocation_Vlan;
            context.OwnerAccount = this.OwnerAccount;
            
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
            bool requestNewPublicVirtualInterfaceAllocationIsNull = true;
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
            if (cmdletContext.NewPublicVirtualInterfaceAllocation_RouteFilterPrefixes != null)
            {
                requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix = cmdletContext.NewPublicVirtualInterfaceAllocation_RouteFilterPrefixes;
            }
            if (requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix != null)
            {
                request.NewPublicVirtualInterfaceAllocation.RouteFilterPrefixes = requestNewPublicVirtualInterfaceAllocation_newPublicVirtualInterfaceAllocation_RouteFilterPrefix;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            #if DESKTOP
            return client.AllocatePublicVirtualInterface(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AllocatePublicVirtualInterfaceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
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
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> NewPublicVirtualInterfaceAllocation_RouteFilterPrefixes { get; set; }
            public System.String NewPublicVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
            public System.Int32? NewPublicVirtualInterfaceAllocation_Vlan { get; set; }
            public System.String OwnerAccount { get; set; }
        }
        
    }
}
