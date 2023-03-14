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
    /// Creates a BGP peer on the specified virtual interface.
    /// 
    ///  
    /// <para>
    /// You must create a BGP peer for the corresponding address family (IPv4/IPv6) in order
    /// to access Amazon Web Services resources that also use that address family.
    /// </para><para>
    /// If logical redundancy is not supported by the connection, interconnect, or LAG, the
    /// BGP peer cannot be in the same address family as an existing BGP peer on the virtual
    /// interface.
    /// </para><para>
    /// When creating a IPv6 BGP peer, omit the Amazon address and customer address. IPv6
    /// addresses are automatically assigned from the Amazon pool of IPv6 addresses; you cannot
    /// specify custom IPv6 addresses.
    /// </para><important><para>
    /// If you let Amazon Web Services auto-assign IPv4 addresses, a /30 CIDR will be allocated
    /// from 169.254.0.0/16. Amazon Web Services does not recommend this option if you intend
    /// to use the customer router peer IP address as the source and destination for traffic.
    /// Instead you should use RFC 1918 or other addressing, and specify the address yourself.
    /// For more information about RFC 1918 see <a href="https://datatracker.ietf.org/doc/html/rfc1918">
    /// Address Allocation for Private Internets</a>.
    /// </para></important><para>
    /// For a public virtual interface, the Autonomous System Number (ASN) must be private
    /// or already on the allow list for the virtual interface.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCBGPPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.VirtualInterface")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateBGPPeer API operation.", Operation = new[] {"CreateBGPPeer"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateBGPPeerResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.VirtualInterface or Amazon.DirectConnect.Model.CreateBGPPeerResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.VirtualInterface object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateBGPPeerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCBGPPeerCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewBGPPeer_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewBGPPeer_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewBGPPeer_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system (AS) number for Border Gateway Protocol (BGP) configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewBGPPeer_Asn { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration. This string has a minimum length of
        /// 6 characters and and a maximun lenth of 80 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewBGPPeer_AuthKey { get; set; }
        #endregion
        
        #region Parameter NewBGPPeer_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewBGPPeer_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter VirtualInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VirtualInterfaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateBGPPeerResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateBGPPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualInterface";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VirtualInterfaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VirtualInterfaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VirtualInterfaceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCBGPPeer (CreateBGPPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateBGPPeerResponse, NewDCBGPPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VirtualInterfaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NewBGPPeer_AddressFamily = this.NewBGPPeer_AddressFamily;
            context.NewBGPPeer_AmazonAddress = this.NewBGPPeer_AmazonAddress;
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
            var requestNewBGPPeerIsNull = true;
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
        
        private Amazon.DirectConnect.Model.CreateBGPPeerResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateBGPPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateBGPPeer");
            try
            {
                #if DESKTOP
                return client.CreateBGPPeer(request);
                #elif CORECLR
                return client.CreateBGPPeerAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily NewBGPPeer_AddressFamily { get; set; }
            public System.String NewBGPPeer_AmazonAddress { get; set; }
            public System.Int32? NewBGPPeer_Asn { get; set; }
            public System.String NewBGPPeer_AuthKey { get; set; }
            public System.String NewBGPPeer_CustomerAddress { get; set; }
            public System.String VirtualInterfaceId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreateBGPPeerResponse, NewDCBGPPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualInterface;
        }
        
    }
}
