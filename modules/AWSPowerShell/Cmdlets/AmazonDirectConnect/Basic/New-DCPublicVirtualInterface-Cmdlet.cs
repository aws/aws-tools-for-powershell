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
    /// Creates a public virtual interface. A virtual interface is the VLAN that transports
    /// AWS Direct Connect traffic. A public virtual interface supports sending traffic to
    /// public services of AWS such as Amazon S3.
    /// 
    ///  
    /// <para>
    /// When creating an IPv6 public virtual interface (<code>addressFamily</code> is <code>ipv6</code>),
    /// leave the <code>customer</code> and <code>amazon</code> address fields blank to use
    /// auto-assigned IPv6 space. Custom IPv6 addresses are not supported.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCPublicVirtualInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse")]
    [AWSCmdlet("Calls the AWS Direct Connect CreatePublicVirtualInterface API operation.", Operation = new[] {"CreatePublicVirtualInterface"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse",
        "This cmdlet returns a Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCPublicVirtualInterfaceCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter NewPublicVirtualInterface_AddressFamily
        /// <summary>
        /// <para>
        /// <para>The address family for the BGP peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DirectConnect.AddressFamily")]
        public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterface_AddressFamily { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_AmazonAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the Amazon interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_AmazonAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Asn
        /// <summary>
        /// <para>
        /// <para>The autonomous system (AS) number for Border Gateway Protocol (BGP) configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewPublicVirtualInterface_Asn { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_AuthKey
        /// <summary>
        /// <para>
        /// <para>The authentication key for BGP configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_AuthKey { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_CustomerAddress
        /// <summary>
        /// <para>
        /// <para>The IP address assigned to the customer interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_CustomerAddress { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_RouteFilterPrefix
        /// <summary>
        /// <para>
        /// <para>The routes to be advertised to the AWS network in this Region. Applies to public virtual
        /// interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewPublicVirtualInterface_RouteFilterPrefixes")]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] NewPublicVirtualInterface_RouteFilterPrefix { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_VirtualInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual interface assigned by the customer network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPublicVirtualInterface_VirtualInterfaceName { get; set; }
        #endregion
        
        #region Parameter NewPublicVirtualInterface_Vlan
        /// <summary>
        /// <para>
        /// <para>The ID of the VLAN.</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConnectionId = this.ConnectionId;
            context.NewPublicVirtualInterface_AddressFamily = this.NewPublicVirtualInterface_AddressFamily;
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
            var request = new Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceRequest();
            
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            
             // populate NewPublicVirtualInterface
            bool requestNewPublicVirtualInterfaceIsNull = true;
            request.NewPublicVirtualInterface = new Amazon.DirectConnect.Model.NewPublicVirtualInterface();
            Amazon.DirectConnect.AddressFamily requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily = null;
            if (cmdletContext.NewPublicVirtualInterface_AddressFamily != null)
            {
                requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily = cmdletContext.NewPublicVirtualInterface_AddressFamily;
            }
            if (requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily != null)
            {
                request.NewPublicVirtualInterface.AddressFamily = requestNewPublicVirtualInterface_newPublicVirtualInterface_AddressFamily;
                requestNewPublicVirtualInterfaceIsNull = false;
            }
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
        
        private Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreatePublicVirtualInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreatePublicVirtualInterface");
            try
            {
                #if DESKTOP
                return client.CreatePublicVirtualInterface(request);
                #elif CORECLR
                return client.CreatePublicVirtualInterfaceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DirectConnect.AddressFamily NewPublicVirtualInterface_AddressFamily { get; set; }
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
