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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the customer gateway or the target gateway of an Amazon Web Services Site-to-Site
    /// VPN connection. To modify the target gateway, the following migration options are
    /// available:
    /// 
    ///  <ul><li><para>
    /// An existing virtual private gateway to a new virtual private gateway
    /// </para></li><li><para>
    /// An existing virtual private gateway to a transit gateway
    /// </para></li><li><para>
    /// An existing transit gateway to a new transit gateway
    /// </para></li><li><para>
    /// An existing transit gateway to a virtual private gateway
    /// </para></li></ul><para>
    /// Before you perform the migration to the new gateway, you must configure the new gateway.
    /// Use <a>CreateVpnGateway</a> to create a virtual private gateway, or <a>CreateTransitGateway</a>
    /// to create a transit gateway.
    /// </para><para>
    /// This step is required when you migrate from a virtual private gateway with static
    /// routes to a transit gateway. 
    /// </para><para>
    /// You must delete the static routes before you migrate to the new gateway.
    /// </para><para>
    /// Keep a copy of the static route before you delete it. You will need to add back these
    /// routes to the transit gateway after the VPN connection migration is complete.
    /// </para><para>
    /// After you migrate to the new gateway, you might need to modify your VPC route table.
    /// Use <a>CreateRoute</a> and <a>DeleteRoute</a> to make the changes described in <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/modify-vpn-target.html#step-update-routing">Update
    /// VPC route tables</a> in the <i>Amazon Web Services Site-to-Site VPN User Guide</i>.
    /// </para><para>
    /// When the new gateway is a transit gateway, modify the transit gateway route table
    /// to allow traffic between the VPC and the Amazon Web Services Site-to-Site VPN connection.
    /// Use <a>CreateTransitGatewayRoute</a> to add the routes.
    /// </para><para>
    ///  If you deleted VPN static routes, you must add the static routes to the transit gateway
    /// route table.
    /// </para><para>
    /// After you perform this operation, the VPN endpoint's IP addresses on the Amazon Web
    /// Services side and the tunnel options remain intact. Your Amazon Web Services Site-to-Site
    /// VPN connection will be temporarily unavailable for a brief period while we provision
    /// the new endpoints.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2VpnConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpnConnection API operation.", Operation = new[] {"ModifyVpnConnection"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpnConnectionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection or Amazon.EC2.Model.ModifyVpnConnectionResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpnConnection object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpnConnectionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2VpnConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomerGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the customer gateway at your end of the VPN connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerGatewayId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayId { get; set; }
        #endregion
        
        #region Parameter VpnConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPN connection.</para>
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
        public System.String VpnConnectionId { get; set; }
        #endregion
        
        #region Parameter VpnGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway at the Amazon Web Services side of the VPN connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpnGatewayId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpnConnectionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpnConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnection";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpnConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpnConnection (ModifyVpnConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpnConnectionResponse, EditEC2VpnConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomerGatewayId = this.CustomerGatewayId;
            context.TransitGatewayId = this.TransitGatewayId;
            context.VpnConnectionId = this.VpnConnectionId;
            #if MODULAR
            if (this.VpnConnectionId == null && ParameterWasBound(nameof(this.VpnConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpnConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpnGatewayId = this.VpnGatewayId;
            
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
            var request = new Amazon.EC2.Model.ModifyVpnConnectionRequest();
            
            if (cmdletContext.CustomerGatewayId != null)
            {
                request.CustomerGatewayId = cmdletContext.CustomerGatewayId;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
            }
            if (cmdletContext.VpnConnectionId != null)
            {
                request.VpnConnectionId = cmdletContext.VpnConnectionId;
            }
            if (cmdletContext.VpnGatewayId != null)
            {
                request.VpnGatewayId = cmdletContext.VpnGatewayId;
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
        
        private Amazon.EC2.Model.ModifyVpnConnectionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpnConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpnConnection");
            try
            {
                #if DESKTOP
                return client.ModifyVpnConnection(request);
                #elif CORECLR
                return client.ModifyVpnConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomerGatewayId { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.String VpnConnectionId { get; set; }
            public System.String VpnGatewayId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpnConnectionResponse, EditEC2VpnConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnection;
        }
        
    }
}
