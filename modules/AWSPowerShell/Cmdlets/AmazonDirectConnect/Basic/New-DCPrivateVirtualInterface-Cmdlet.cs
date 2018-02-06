/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [OutputType("Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreatePrivateVirtualInterface API operation.", Operation = new[] {"CreatePrivateVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewPrivateVirtualInterface_AddressFamily
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterface_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_AmazonAddress
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterface_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_Asn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPrivateVirtualInterface_Asn { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_AuthKey
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterface_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_CustomerAddress
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterface_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterface_DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_VirtualGatewayId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterface_VirtualGatewayId { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterface_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterface_Vlan
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPrivateVirtualInterface_Vlan { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCPrivateVirtualInterface (CreatePrivateVirtualInterface)"))
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
            context.NewPrivateVirtualInterface_AddressFamily = this.NewPrivateVirtualInterface_AddressFamily;
            context.NewPrivateVirtualInterface_AmazonAddress = this.NewPrivateVirtualInterface_AmazonAddress;
            if (ParameterWasBound("NewPrivateVirtualInterface_Asn"))
                context.NewPrivateVirtualInterface_Asn = this.NewPrivateVirtualInterface_Asn;
            context.NewPrivateVirtualInterface_AuthKey = this.NewPrivateVirtualInterface_AuthKey;
            context.NewPrivateVirtualInterface_CustomerAddress = this.NewPrivateVirtualInterface_CustomerAddress;
            context.NewPrivateVirtualInterface_DirectConnectGatewayId = this.NewPrivateVirtualInterface_DirectConnectGatewayId;
            context.NewPrivateVirtualInterface_VirtualGatewayId = this.NewPrivateVirtualInterface_VirtualGatewayId;
            context.NewPrivateVirtualInterface_VirtualInterfaceName = this.NewPrivateVirtualInterface_VirtualInterfaceName;
            if (ParameterWasBound("NewPrivateVirtualInterface_Vlan"))
                context.NewPrivateVirtualInterface_Vlan = this.NewPrivateVirtualInterface_Vlan;
            
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
            bool requestNewPrivateVirtualInterfaceIsNull = true;
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
        
        private Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreatePrivateVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreatePrivateVirtualInterface");
            try
            {
                #if DESKTOP
                return client.CreatePrivateVirtualInterface(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreatePrivateVirtualInterfaceAsync(request);
                return task.Result;
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
            public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterface_AddressFamily { get; set; }
            public System.String NewPrivateVirtualInterface_AmazonAddress { get; set; }
            public System.Int32? NewPrivateVirtualInterface_Asn { get; set; }
            public System.String NewPrivateVirtualInterface_AuthKey { get; set; }
            public System.String NewPrivateVirtualInterface_CustomerAddress { get; set; }
            public System.String NewPrivateVirtualInterface_DirectConnectGatewayId { get; set; }
            public System.String NewPrivateVirtualInterface_VirtualGatewayId { get; set; }
            public System.String NewPrivateVirtualInterface_VirtualInterfaceName { get; set; }
            public System.Int32? NewPrivateVirtualInterface_Vlan { get; set; }
        }
        
    }
}
