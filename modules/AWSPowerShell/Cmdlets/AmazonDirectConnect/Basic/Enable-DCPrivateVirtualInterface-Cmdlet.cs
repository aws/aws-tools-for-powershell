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
    /// Provisions a private virtual interface to be owned by a different customer.
    /// 
    ///  
    /// <para>
    /// The owner of a connection calls this function to provision a private virtual interface
    /// which will be owned by another AWS customer.
    /// </para><para>
    /// Virtual interfaces created using this function must be confirmed by the virtual interface
    /// owner by calling ConfirmPrivateVirtualInterface. Until this step has been completed,
    /// the virtual interface will be in 'Confirming' state, and will not be available for
    /// handling traffic.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DCPrivateVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse")]
    [AWSCmdlet("Invokes the AllocatePrivateVirtualInterface operation against AWS Direct Connect.", Operation = new[] {"AllocatePrivateVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse",
        "This cmdlet returns a AllocatePrivateVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EnableDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterfaceAllocation_AmazonAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 NewPrivateVirtualInterfaceAllocation_Asn { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterfaceAllocation_AuthKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The connection ID on which the private virtual interface is provisioned.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ConnectionId { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterfaceAllocation_CustomerAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The AWS account that will own the new private virtual interface.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String OwnerAccount { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 NewPrivateVirtualInterfaceAllocation_Vlan { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConnectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCPrivateVirtualInterface (AllocatePrivateVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ConnectionId = this.ConnectionId;
            context.NewPrivateVirtualInterfaceAllocation_AmazonAddress = this.NewPrivateVirtualInterfaceAllocation_AmazonAddress;
            if (ParameterWasBound("NewPrivateVirtualInterfaceAllocation_Asn"))
                context.NewPrivateVirtualInterfaceAllocation_Asn = this.NewPrivateVirtualInterfaceAllocation_Asn;
            context.NewPrivateVirtualInterfaceAllocation_AuthKey = this.NewPrivateVirtualInterfaceAllocation_AuthKey;
            context.NewPrivateVirtualInterfaceAllocation_CustomerAddress = this.NewPrivateVirtualInterfaceAllocation_CustomerAddress;
            context.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName = this.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
            if (ParameterWasBound("NewPrivateVirtualInterfaceAllocation_Vlan"))
                context.NewPrivateVirtualInterfaceAllocation_Vlan = this.NewPrivateVirtualInterfaceAllocation_Vlan;
            context.OwnerAccount = this.OwnerAccount;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new AllocatePrivateVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPrivateVirtualInterfaceAllocation
            bool requestNewPrivateVirtualInterfaceAllocationIsNull = true;
            request.NewPrivateVirtualInterfaceAllocation = new NewPrivateVirtualInterfaceAllocation();
            String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_AmazonAddress != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress = cmdletContext.NewPrivateVirtualInterfaceAllocation_AmazonAddress;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.AmazonAddress = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AmazonAddress;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            Int32? requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_Asn != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn = cmdletContext.NewPrivateVirtualInterfaceAllocation_Asn.Value;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.Asn = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Asn.Value;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_AuthKey != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey = cmdletContext.NewPrivateVirtualInterfaceAllocation_AuthKey;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.AuthKey = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_AuthKey;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_CustomerAddress != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress = cmdletContext.NewPrivateVirtualInterfaceAllocation_CustomerAddress;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.CustomerAddress = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_CustomerAddress;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            String requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName = null;
            if (cmdletContext.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName = cmdletContext.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
            }
            if (requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName != null)
            {
                request.NewPrivateVirtualInterfaceAllocation.VirtualInterfaceName = requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
                requestNewPrivateVirtualInterfaceAllocationIsNull = false;
            }
            Int32? requestNewPrivateVirtualInterfaceAllocation_newPrivateVirtualInterfaceAllocation_Vlan = null;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.AllocatePrivateVirtualInterface(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String ConnectionId { get; set; }
            public String NewPrivateVirtualInterfaceAllocation_AmazonAddress { get; set; }
            public Int32? NewPrivateVirtualInterfaceAllocation_Asn { get; set; }
            public String NewPrivateVirtualInterfaceAllocation_AuthKey { get; set; }
            public String NewPrivateVirtualInterfaceAllocation_CustomerAddress { get; set; }
            public String NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
            public Int32? NewPrivateVirtualInterfaceAllocation_Vlan { get; set; }
            public String OwnerAccount { get; set; }
        }
        
    }
}
