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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Replaces an existing route within a route table in a VPC.
    /// 
    ///  
    /// <para>
    /// You must specify either a destination CIDR block or a prefix list ID. You must also
    /// specify exactly one of the resources from the parameter list, or reset the local route
    /// to its default target.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Route_Tables.html">Route
    /// tables</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "EC2Route", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ReplaceRoute API operation.", Operation = new[] {"ReplaceRoute"}, SelectReturnType = typeof(Amazon.EC2.Model.ReplaceRouteResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ReplaceRouteResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ReplaceRouteResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetEC2RouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CarrierGatewayId
        /// <summary>
        /// <para>
        /// <para>[IPv4 traffic only] The ID of a carrier gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CarrierGatewayId { get; set; }
        #endregion
        
        #region Parameter CoreNetworkArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the core network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CoreNetworkArn { get; set; }
        #endregion
        
        #region Parameter DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR address block used for the destination match. The value that you provide
        /// must match the CIDR of an existing route in the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationIpv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR address block used for the destination match. The value that you provide
        /// must match the CIDR of an existing route in the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationIpv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationPrefixListId
        /// <summary>
        /// <para>
        /// <para>The ID of the prefix list for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationPrefixListId { get; set; }
        #endregion
        
        #region Parameter EgressOnlyInternetGatewayId
        /// <summary>
        /// <para>
        /// <para>[IPv6 traffic only] The ID of an egress-only internet gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EgressOnlyInternetGatewayId { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of an internet gateway or virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of a NAT instance in your VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter LocalGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the local gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalGatewayId { get; set; }
        #endregion
        
        #region Parameter LocalTarget
        /// <summary>
        /// <para>
        /// <para>Specifies whether to reset the local route to its default target (<code>local</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LocalTarget { get; set; }
        #endregion
        
        #region Parameter NatGatewayId
        /// <summary>
        /// <para>
        /// <para>[IPv4 traffic only] The ID of a NAT gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NatGatewayId { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of a network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter RouteTableId
        /// <summary>
        /// <para>
        /// <para>The ID of the route table.</para>
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
        public System.String RouteTableId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of a transit gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayId { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of a VPC endpoint. Supported for Gateway Load Balancer endpoints only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter VpcPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of a VPC peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcPeeringConnectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ReplaceRouteResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RouteTableId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RouteTableId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RouteTableId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RouteTableId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EC2Route (ReplaceRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ReplaceRouteResponse, SetEC2RouteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RouteTableId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CarrierGatewayId = this.CarrierGatewayId;
            context.CoreNetworkArn = this.CoreNetworkArn;
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.DestinationIpv6CidrBlock = this.DestinationIpv6CidrBlock;
            context.DestinationPrefixListId = this.DestinationPrefixListId;
            context.EgressOnlyInternetGatewayId = this.EgressOnlyInternetGatewayId;
            context.GatewayId = this.GatewayId;
            context.InstanceId = this.InstanceId;
            context.LocalGatewayId = this.LocalGatewayId;
            context.LocalTarget = this.LocalTarget;
            context.NatGatewayId = this.NatGatewayId;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            context.RouteTableId = this.RouteTableId;
            #if MODULAR
            if (this.RouteTableId == null && ParameterWasBound(nameof(this.RouteTableId)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteTableId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransitGatewayId = this.TransitGatewayId;
            context.VpcEndpointId = this.VpcEndpointId;
            context.VpcPeeringConnectionId = this.VpcPeeringConnectionId;
            
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
            var request = new Amazon.EC2.Model.ReplaceRouteRequest();
            
            if (cmdletContext.CarrierGatewayId != null)
            {
                request.CarrierGatewayId = cmdletContext.CarrierGatewayId;
            }
            if (cmdletContext.CoreNetworkArn != null)
            {
                request.CoreNetworkArn = cmdletContext.CoreNetworkArn;
            }
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            if (cmdletContext.DestinationIpv6CidrBlock != null)
            {
                request.DestinationIpv6CidrBlock = cmdletContext.DestinationIpv6CidrBlock;
            }
            if (cmdletContext.DestinationPrefixListId != null)
            {
                request.DestinationPrefixListId = cmdletContext.DestinationPrefixListId;
            }
            if (cmdletContext.EgressOnlyInternetGatewayId != null)
            {
                request.EgressOnlyInternetGatewayId = cmdletContext.EgressOnlyInternetGatewayId;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.LocalGatewayId != null)
            {
                request.LocalGatewayId = cmdletContext.LocalGatewayId;
            }
            if (cmdletContext.LocalTarget != null)
            {
                request.LocalTarget = cmdletContext.LocalTarget.Value;
            }
            if (cmdletContext.NatGatewayId != null)
            {
                request.NatGatewayId = cmdletContext.NatGatewayId;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.RouteTableId != null)
            {
                request.RouteTableId = cmdletContext.RouteTableId;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
            }
            if (cmdletContext.VpcPeeringConnectionId != null)
            {
                request.VpcPeeringConnectionId = cmdletContext.VpcPeeringConnectionId;
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
        
        private Amazon.EC2.Model.ReplaceRouteResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ReplaceRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ReplaceRoute");
            try
            {
                #if DESKTOP
                return client.ReplaceRoute(request);
                #elif CORECLR
                return client.ReplaceRouteAsync(request).GetAwaiter().GetResult();
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
            public System.String CarrierGatewayId { get; set; }
            public System.String CoreNetworkArn { get; set; }
            public System.String DestinationCidrBlock { get; set; }
            public System.String DestinationIpv6CidrBlock { get; set; }
            public System.String DestinationPrefixListId { get; set; }
            public System.String EgressOnlyInternetGatewayId { get; set; }
            public System.String GatewayId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String LocalGatewayId { get; set; }
            public System.Boolean? LocalTarget { get; set; }
            public System.String NatGatewayId { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.String RouteTableId { get; set; }
            public System.String TransitGatewayId { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.String VpcPeeringConnectionId { get; set; }
            public System.Func<Amazon.EC2.Model.ReplaceRouteResponse, SetEC2RouteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
