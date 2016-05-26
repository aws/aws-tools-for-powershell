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
    /// Creates a new public virtual interface. A virtual interface is the VLAN that transports
    /// AWS Direct Connect traffic. A public virtual interface supports sending traffic to
    /// public services of AWS such as Amazon Simple Storage Service (Amazon S3).
    /// </summary>
    [Cmdlet("New", "DCPublicVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse")]
    [AWSCmdlet("Invokes the CreatePublicVirtualInterface operation against AWS Direct Connect.", Operation = new[] {"CreatePublicVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewDCPublicVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewPublicVirtualInterface_AmazonAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Asn
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPublicVirtualInterface_Asn { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_AuthKey
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_CustomerAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_RouteFilterPrefix
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewPublicVirtualInterface_RouteFilterPrefixes")]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] NewPublicVirtualInterface_RouteFilterPrefix { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Vlan
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPublicVirtualInterface_Vlan { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCPublicVirtualInterface (CreatePublicVirtualInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ConnectionId = this.ConnectionId;
            context.NewPublicVirtualInterface_AmazonAddress = this.NewPublicVirtualInterface_AmazonAddress;
            if (ParameterWasBound("NewPublicVirtualInterface_Asn"))
                context.NewPublicVirtualInterface_Asn = this.NewPublicVirtualInterface_Asn;
            context.NewPublicVirtualInterface_AuthKey = this.NewPublicVirtualInterface_AuthKey;
            context.NewPublicVirtualInterface_CustomerAddress = this.NewPublicVirtualInterface_CustomerAddress;
            if (this.NewPublicVirtualInterface_RouteFilterPrefix != null)
            {
                context.NewPublicVirtualInterface_RouteFilterPrefixes = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.NewPublicVirtualInterface_RouteFilterPrefix);
            }
            context.NewPublicVirtualInterface_VirtualInterfaceName = this.NewPublicVirtualInterface_VirtualInterfaceName;
            if (ParameterWasBound("NewPublicVirtualInterface_Vlan"))
                context.NewPublicVirtualInterface_Vlan = this.NewPublicVirtualInterface_Vlan;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPublicVirtualInterface
            bool requestNewPublicVirtualInterfaceIsNull = true;
            request.NewPublicVirtualInterface = new Amazon.DirectConnect.Model.NewPublicVirtualInterface();
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress = null;
            if (cmdletContext.NewPublicVirtualInterface_AmazonAddress != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress = cmdletContext.NewPublicVirtualInterface_AmazonAddress;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress != null)
            {
                request.NewPublicVirtualInterface.AmazonAddress = requestNewPublicVirtualInterface_newPublicVirtualInterface_AmazonAddress;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn = null;
            if (cmdletContext.NewPublicVirtualInterface_Asn != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn = cmdletContext.NewPublicVirtualInterface_Asn.Value;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn != null)
            {
                request.NewPublicVirtualInterface.Asn = requestNewPublicVirtualInterface_newPublicVirtualInterface_Asn.Value;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey = null;
            if (cmdletContext.NewPublicVirtualInterface_AuthKey != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey = cmdletContext.NewPublicVirtualInterface_AuthKey;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey != null)
            {
                request.NewPublicVirtualInterface.AuthKey = requestNewPublicVirtualInterface_newPublicVirtualInterface_AuthKey;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress = null;
            if (cmdletContext.NewPublicVirtualInterface_CustomerAddress != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress = cmdletContext.NewPublicVirtualInterface_CustomerAddress;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress != null)
            {
                request.NewPublicVirtualInterface.CustomerAddress = requestNewPublicVirtualInterface_newPublicVirtualInterface_CustomerAddress;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            List<Amazon.DirectConnect.Model.RouteFilterPrefix> requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix = null;
            if (cmdletContext.NewPublicVirtualInterface_RouteFilterPrefixes != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix = cmdletContext.NewPublicVirtualInterface_RouteFilterPrefixes;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix != null)
            {
                request.NewPublicVirtualInterface.RouteFilterPrefixes = requestNewPublicVirtualInterface_newPublicVirtualInterface_RouteFilterPrefix;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.String requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName = null;
            if (cmdletContext.NewPublicVirtualInterface_VirtualInterfaceName != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName = cmdletContext.NewPublicVirtualInterface_VirtualInterfaceName;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName != null)
            {
                request.NewPublicVirtualInterface.VirtualInterfaceName = requestNewPublicVirtualInterface_newPublicVirtualInterface_VirtualInterfaceName;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
            System.Int32? requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan = null;
            if (cmdletContext.NewPublicVirtualInterface_Vlan != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan = cmdletContext.NewPublicVirtualInterface_Vlan.Value;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan != null)
            {
                request.NewPublicVirtualInterface.Vlan = requestNewPublicVirtualInterface_newPublicVirtualInterface_Vlan.Value;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
             // determine if request.NewPublicVirtualInterface should be set to null
            if (requestNewPublicVirtualInterfaceIsNull)
            {
                request.NewPublicVirtualInterface = null;
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
        
        private static Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceRequest request)
        {
            return client.CreatePublicVirtualInterface(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ConnectionId { get; set; }
            public System.String NewPublicVirtualInterface_AmazonAddress { get; set; }
            public System.Int32? NewPublicVirtualInterface_Asn { get; set; }
            public System.String NewPublicVirtualInterface_AuthKey { get; set; }
            public System.String NewPublicVirtualInterface_CustomerAddress { get; set; }
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> NewPublicVirtualInterface_RouteFilterPrefixes { get; set; }
            public System.String NewPublicVirtualInterface_VirtualInterfaceName { get; set; }
            public System.Int32? NewPublicVirtualInterface_Vlan { get; set; }
        }
        
    }
}
