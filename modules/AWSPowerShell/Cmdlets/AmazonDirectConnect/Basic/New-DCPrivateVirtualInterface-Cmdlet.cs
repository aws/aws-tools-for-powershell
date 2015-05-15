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
    /// Creates a new private virtual interface. A virtual interface is the VLAN that transports
    /// AWS Direct Connect traffic. A private virtual interface supports sending traffic to
    /// a single virtual private cloud (VPC).
    /// </summary>
    [Cmdlet("New", "DCPrivateVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResult")]
    [AWSCmdlet("Invokes the CreatePrivateVirtualInterface operation against AWS Direct Connect.", Operation = new[] {"CreatePrivateVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResult",
        "This cmdlet returns a CreatePrivateVirtualInterfaceResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterface_AmazonAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 NewPrivateVirtualInterface_Asn { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterface_AuthKey { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
        public String NewPrivateVirtualInterface_CustomerAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterface_VirtualGatewayId { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NewPrivateVirtualInterface_VirtualInterfaceName { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 NewPrivateVirtualInterface_Vlan { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCPrivateVirtualInterface (CreatePrivateVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ConnectionId = this.ConnectionId;
            context.NewPrivateVirtualInterface_AmazonAddress = this.NewPrivateVirtualInterface_AmazonAddress;
            if (ParameterWasBound("NewPrivateVirtualInterface_Asn"))
                context.NewPrivateVirtualInterface_Asn = this.NewPrivateVirtualInterface_Asn;
            context.NewPrivateVirtualInterface_AuthKey = this.NewPrivateVirtualInterface_AuthKey;
            context.NewPrivateVirtualInterface_CustomerAddress = this.NewPrivateVirtualInterface_CustomerAddress;
            context.NewPrivateVirtualInterface_VirtualGatewayId = this.NewPrivateVirtualInterface_VirtualGatewayId;
            context.NewPrivateVirtualInterface_VirtualInterfaceName = this.NewPrivateVirtualInterface_VirtualInterfaceName;
            if (ParameterWasBound("NewPrivateVirtualInterface_Vlan"))
                context.NewPrivateVirtualInterface_Vlan = this.NewPrivateVirtualInterface_Vlan;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreatePrivateVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPrivateVirtualInterface
            bool requestNewPrivateVirtualInterfaceIsNull = true;
            request.NewPrivateVirtualInterface = new NewPrivateVirtualInterface();
            String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress = null;
            if (cmdletContext.NewPrivateVirtualInterface_AmazonAddress != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress = cmdletContext.NewPrivateVirtualInterface_AmazonAddress;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress != null)
            {
                request.NewPrivateVirtualInterface.AmazonAddress = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AmazonAddress;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            Int32? requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn = null;
            if (cmdletContext.NewPrivateVirtualInterface_Asn != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn = cmdletContext.NewPrivateVirtualInterface_Asn.Value;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn != null)
            {
                request.NewPrivateVirtualInterface.Asn = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Asn.Value;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey = null;
            if (cmdletContext.NewPrivateVirtualInterface_AuthKey != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey = cmdletContext.NewPrivateVirtualInterface_AuthKey;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey != null)
            {
                request.NewPrivateVirtualInterface.AuthKey = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_AuthKey;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress = null;
            if (cmdletContext.NewPrivateVirtualInterface_CustomerAddress != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress = cmdletContext.NewPrivateVirtualInterface_CustomerAddress;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress != null)
            {
                request.NewPrivateVirtualInterface.CustomerAddress = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_CustomerAddress;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId = null;
            if (cmdletContext.NewPrivateVirtualInterface_VirtualGatewayId != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId = cmdletContext.NewPrivateVirtualInterface_VirtualGatewayId;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId != null)
            {
                request.NewPrivateVirtualInterface.VirtualGatewayId = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualGatewayId;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            String requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName = null;
            if (cmdletContext.NewPrivateVirtualInterface_VirtualInterfaceName != null)
            {
                requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName = cmdletContext.NewPrivateVirtualInterface_VirtualInterfaceName;
            }
            if (requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName != null)
            {
                request.NewPrivateVirtualInterface.VirtualInterfaceName = requestNewPrivateVirtualInterface_newPrivateVirtualInterface_VirtualInterfaceName;
                requestNewPrivateVirtualInterfaceIsNull = false;
            }
            Int32? requestNewPrivateVirtualInterface_newPrivateVirtualInterface_Vlan = null;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreatePrivateVirtualInterface(request);
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
            public String NewPrivateVirtualInterface_AmazonAddress { get; set; }
            public Int32? NewPrivateVirtualInterface_Asn { get; set; }
            public String NewPrivateVirtualInterface_AuthKey { get; set; }
            public String NewPrivateVirtualInterface_CustomerAddress { get; set; }
            public String NewPrivateVirtualInterface_VirtualGatewayId { get; set; }
            public String NewPrivateVirtualInterface_VirtualInterfaceName { get; set; }
            public Int32? NewPrivateVirtualInterface_Vlan { get; set; }
        }
        
    }
}
