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
    /// Creates a new BGP peer on a specified virtual interface. The BGP peer cannot be in
    /// the same address family (IPv4/IPv6) of an existing BGP peer on the virtual interface.
    /// 
    ///  
    /// <para>
    /// You must create a BGP peer for the corresponding address family in order to access
    /// AWS resources that also use that address family.
    /// </para><para>
    /// When creating a IPv6 BGP peer, the Amazon address and customer address fields must
    /// be left blank. IPv6 addresses are automatically assigned from Amazon's pool of IPv6
    /// addresses; you cannot specify custom IPv6 addresses.
    /// </para><para>
    /// For a public virtual interface, the Autonomous System Number (ASN) must be private
    /// or already whitelisted for the virtual interface.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCBGPPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterface")]
    [AWSCmdlet("Invokes the CreateBGPPeer operation against AWS Direct Connect.", Operation = new[] {"CreateBGPPeer"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterface",
        "This cmdlet returns a VirtualInterface object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateBGPPeerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCBGPPeerCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewBGPPeer_AddressFamily
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewBGPPeer_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_AmazonAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewBGPPeer_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_Asn
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewBGPPeer_Asn { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_AuthKey
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewBGPPeer_AuthKey { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_CustomerAddress
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewBGPPeer_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface on which the BGP peer will be provisioned.</para><para>Example: dxvif-456abc78</para><para>Default: None</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VirtualInterfaceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VirtualInterfaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCBGPPeer (CreateBGPPeer)"))
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
            
            context.NewBGPPeer_AddressFamily = this.NewBGPPeer_AddressFamily;
            context.NewBGPPeer_AmazonAddress = this.NewBGPPeer_AmazonAddress;
            if (ParameterWasBound("NewBGPPeer_Asn"))
                context.NewBGPPeer_Asn = this.NewBGPPeer_Asn;
            context.NewBGPPeer_AuthKey = this.NewBGPPeer_AuthKey;
            context.NewBGPPeer_CustomerAddress = this.NewBGPPeer_CustomerAddress;
            context.VirtualInterfaceId = this.VirtualInterfaceId;
            
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
            var request = new Amazon.DirectConnect.Model.CreateBGPPeerRequest();
            
            
             // populate NewBGPPeer
            bool requestNewBGPPeerIsNull = true;
            request.NewBGPPeer = new Amazon.DirectConnect.Model.NewBGPPeer();
            Amazon.DirectConnect.AddressFamily requestNewBGPPeer_newBGPPeer_AddressFamily = null;
            if (cmdletContext.NewBGPPeer_AddressFamily != null)
            {
                requestNewBGPPeer_newBGPPeer_AddressFamily = cmdletContext.NewBGPPeer_AddressFamily;
            }
            if (requestNewBGPPeer_newBGPPeer_AddressFamily != null)
            {
                request.NewBGPPeer.AddressFamily = requestNewBGPPeer_newBGPPeer_AddressFamily;
                requestNewBGPPeerIsNull = false;
            }
            System.String requestNewBGPPeer_newBGPPeer_AmazonAddress = null;
            if (cmdletContext.NewBGPPeer_AmazonAddress != null)
            {
                requestNewBGPPeer_newBGPPeer_AmazonAddress = cmdletContext.NewBGPPeer_AmazonAddress;
            }
            if (requestNewBGPPeer_newBGPPeer_AmazonAddress != null)
            {
                request.NewBGPPeer.AmazonAddress = requestNewBGPPeer_newBGPPeer_AmazonAddress;
                requestNewBGPPeerIsNull = false;
            }
            System.Int32? requestNewBGPPeer_newBGPPeer_Asn = null;
            if (cmdletContext.NewBGPPeer_Asn != null)
            {
                requestNewBGPPeer_newBGPPeer_Asn = cmdletContext.NewBGPPeer_Asn.Value;
            }
            if (requestNewBGPPeer_newBGPPeer_Asn != null)
            {
                request.NewBGPPeer.Asn = requestNewBGPPeer_newBGPPeer_Asn.Value;
                requestNewBGPPeerIsNull = false;
            }
            System.String requestNewBGPPeer_newBGPPeer_AuthKey = null;
            if (cmdletContext.NewBGPPeer_AuthKey != null)
            {
                requestNewBGPPeer_newBGPPeer_AuthKey = cmdletContext.NewBGPPeer_AuthKey;
            }
            if (requestNewBGPPeer_newBGPPeer_AuthKey != null)
            {
                request.NewBGPPeer.AuthKey = requestNewBGPPeer_newBGPPeer_AuthKey;
                requestNewBGPPeerIsNull = false;
            }
            System.String requestNewBGPPeer_newBGPPeer_CustomerAddress = null;
            if (cmdletContext.NewBGPPeer_CustomerAddress != null)
            {
                requestNewBGPPeer_newBGPPeer_CustomerAddress = cmdletContext.NewBGPPeer_CustomerAddress;
            }
            if (requestNewBGPPeer_newBGPPeer_CustomerAddress != null)
            {
                request.NewBGPPeer.CustomerAddress = requestNewBGPPeer_newBGPPeer_CustomerAddress;
                requestNewBGPPeerIsNull = false;
            }
             // determine if request.NewBGPPeer should be set to null
            if (requestNewBGPPeerIsNull)
            {
                request.NewBGPPeer = null;
            }
            if (cmdletContext.VirtualInterfaceId != null)
            {
                request.VirtualInterfaceId = cmdletContext.VirtualInterfaceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VirtualInterface;
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
        
        private Amazon.DirectConnect.Model.CreateBGPPeerResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateBGPPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateBGPPeer");
            #if DESKTOP
            return client.CreateBGPPeer(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateBGPPeerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.DirectConnect.AddressFamily NewBGPPeer_AddressFamily { get; set; }
            public System.String NewBGPPeer_AmazonAddress { get; set; }
            public System.Int32? NewBGPPeer_Asn { get; set; }
            public System.String NewBGPPeer_AuthKey { get; set; }
            public System.String NewBGPPeer_CustomerAddress { get; set; }
            public System.String VirtualInterfaceId { get; set; }
        }
        
    }
}
