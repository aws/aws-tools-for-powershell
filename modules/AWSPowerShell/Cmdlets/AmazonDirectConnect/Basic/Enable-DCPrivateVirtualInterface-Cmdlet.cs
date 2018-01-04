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
    /// Provisions a private virtual interface to be owned by another AWS customer.
    /// 
    ///  
    /// <para>
    /// Virtual interfaces created using this action must be confirmed by the virtual interface
    /// owner by using the <a>ConfirmPrivateVirtualInterface</a> action. Until then, the virtual
    /// interface will be in 'Confirming' state, and will not be available for handling traffic.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "DCPrivateVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect AllocatePrivateVirtualInterface API operation.", Operation = new[] {"AllocatePrivateVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableDCPrivateVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_AddressFamily
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterfaceAllocation_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_AmazonAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterfaceAllocation_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_Asn
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPrivateVirtualInterfaceAllocation_Asn { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_AuthKey
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterfaceAllocation_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The connection ID on which the private virtual interface is provisioned.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_CustomerAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterfaceAllocation_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The AWS account that will own the new private virtual interface.</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPrivateVirtualInterfaceAllocation_Vlan
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPrivateVirtualInterfaceAllocation_Vlan { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-DCPrivateVirtualInterface (AllocatePrivateVirtualInterface)"))
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
            context.NewPrivateVirtualInterfaceAllocation_AddressFamily = this.NewPrivateVirtualInterfaceAllocation_AddressFamily;
            context.NewPrivateVirtualInterfaceAllocation_AmazonAddress = this.NewPrivateVirtualInterfaceAllocation_AmazonAddress;
            if (ParameterWasBound("NewPrivateVirtualInterfaceAllocation_Asn"))
                context.NewPrivateVirtualInterfaceAllocation_Asn = this.NewPrivateVirtualInterfaceAllocation_Asn;
            context.NewPrivateVirtualInterfaceAllocation_AuthKey = this.NewPrivateVirtualInterfaceAllocation_AuthKey;
            context.NewPrivateVirtualInterfaceAllocation_CustomerAddress = this.NewPrivateVirtualInterfaceAllocation_CustomerAddress;
            context.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName = this.NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName;
            if (ParameterWasBound("NewPrivateVirtualInterfaceAllocation_Vlan"))
                context.NewPrivateVirtualInterfaceAllocation_Vlan = this.NewPrivateVirtualInterfaceAllocation_Vlan;
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
            var request = new Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPrivateVirtualInterfaceAllocation
            bool requestNewPrivateVirtualInterfaceAllocationIsNull = true;
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
        
        private Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AllocatePrivateVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AllocatePrivateVirtualInterface");
            try
            {
                #if DESKTOP
                return client.AllocatePrivateVirtualInterface(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AllocatePrivateVirtualInterfaceAsync(request);
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
            public Amazon.DirectConnect.AddressFamily NewPrivateVirtualInterfaceAllocation_AddressFamily { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_AmazonAddress { get; set; }
            public System.Int32? NewPrivateVirtualInterfaceAllocation_Asn { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_AuthKey { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_CustomerAddress { get; set; }
            public System.String NewPrivateVirtualInterfaceAllocation_VirtualInterfaceName { get; set; }
            public System.Int32? NewPrivateVirtualInterfaceAllocation_Vlan { get; set; }
            public System.String OwnerAccount { get; set; }
        }
        
    }
}
