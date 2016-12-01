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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a route in a route table within a VPC.
    /// 
    ///  
    /// <para>
    /// You must specify one of the following targets: Internet gateway or virtual private
    /// gateway, NAT instance, NAT gateway, VPC peering connection, network interface, or
    /// egress-only Internet gateway.
    /// </para><para>
    /// When determining how to route traffic, we use the route with the most specific match.
    /// For example, traffic is destined for the IPv4 address <code>192.0.2.3</code>, and
    /// the route table includes the following two IPv4 routes:
    /// </para><ul><li><para><code>192.0.2.0/24</code> (goes to some target A)
    /// </para></li><li><para><code>192.0.2.0/28</code> (goes to some target B)
    /// </para></li></ul><para>
    /// Both routes apply to the traffic destined for <code>192.0.2.3</code>. However, the
    /// second route in the list covers a smaller number of IP addresses and is therefore
    /// more specific, so we use that route to determine where to target the traffic.
    /// </para><para>
    /// For more information about route tables, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_Route_Tables.html">Route
    /// Tables</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Route", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Invokes the CreateRoute operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateRoute"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.CreateRouteResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2RouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 CIDR address block used for the destination match. Routing decisions are
        /// based on the most specific match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationIpv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR block used for the destination match. Routing decisions are based on
        /// the most specific match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationIpv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter EgressOnlyInternetGatewayId
        /// <summary>
        /// <para>
        /// <para>[IPv6 traffic only] The ID of an egress-only Internet gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EgressOnlyInternetGatewayId { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of an Internet gateway or virtual private gateway attached to your VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of a NAT instance in your VPC. The operation fails if you specify an instance
        /// ID unless exactly one network interface is attached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter NatGatewayId
        /// <summary>
        /// <para>
        /// <para>[IPv4 traffic only] The ID of a NAT gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// <para>The ID of the route table for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RouteTableId { get; set; }
        #endregion
        
        #region Parameter VpcPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of a VPC peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpcPeeringConnectionId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RouteTableId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Route (CreateRoute)"))
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
            
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.DestinationIpv6CidrBlock = this.DestinationIpv6CidrBlock;
            context.EgressOnlyInternetGatewayId = this.EgressOnlyInternetGatewayId;
            context.GatewayId = this.GatewayId;
            context.InstanceId = this.InstanceId;
            context.NatGatewayId = this.NatGatewayId;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            context.RouteTableId = this.RouteTableId;
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
            var request = new Amazon.EC2.Model.CreateRouteRequest();
            
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            if (cmdletContext.DestinationIpv6CidrBlock != null)
            {
                request.DestinationIpv6CidrBlock = cmdletContext.DestinationIpv6CidrBlock;
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
            if (cmdletContext.VpcPeeringConnectionId != null)
            {
                request.VpcPeeringConnectionId = cmdletContext.VpcPeeringConnectionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Return;
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
        
        private static Amazon.EC2.Model.CreateRouteResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateRouteRequest request)
        {
            #if DESKTOP
            return client.CreateRoute(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateRouteAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DestinationCidrBlock { get; set; }
            public System.String DestinationIpv6CidrBlock { get; set; }
            public System.String EgressOnlyInternetGatewayId { get; set; }
            public System.String GatewayId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String NatGatewayId { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.String RouteTableId { get; set; }
            public System.String VpcPeeringConnectionId { get; set; }
        }
        
    }
}
