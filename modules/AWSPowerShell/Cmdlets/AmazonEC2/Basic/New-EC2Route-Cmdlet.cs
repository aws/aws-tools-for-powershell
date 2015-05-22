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
    /// gateway, NAT instance, VPC peering connection, or network interface.
    /// </para><para>
    /// When determining how to route traffic, we use the route with the most specific match.
    /// For example, let's say the traffic is destined for <code>192.0.2.3</code>, and the
    /// route table includes the following two routes:
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
    [OutputType("Amazon.EC2.Model.CreateRouteResponse")]
    [AWSCmdlet("Invokes the CreateRoute operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateRoute"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateRouteResponse",
        "This cmdlet returns a CreateRouteResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2RouteCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The CIDR address block used for the destination match. Routing decisions are based
        /// on the most specific match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String DestinationCidrBlock { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of an Internet gateway or virtual private gateway attached to your VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public String GatewayId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of a NAT instance in your VPC. The operation fails if you specify an instance
        /// ID unless exactly one network interface is attached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public String InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of a network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public String NetworkInterfaceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the route table for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String RouteTableId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of a VPC peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String VpcPeeringConnectionId { get; set; }
        
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
            
            context.ClientToken = this.ClientToken;
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.GatewayId = this.GatewayId;
            context.InstanceId = this.InstanceId;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            context.RouteTableId = this.RouteTableId;
            context.VpcPeeringConnectionId = this.VpcPeeringConnectionId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateRouteRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
                var response = client.CreateRoute(request);
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
            public String ClientToken { get; set; }
            public String DestinationCidrBlock { get; set; }
            public String GatewayId { get; set; }
            public String InstanceId { get; set; }
            public String NetworkInterfaceId { get; set; }
            public String RouteTableId { get; set; }
            public String VpcPeeringConnectionId { get; set; }
        }
        
    }
}
