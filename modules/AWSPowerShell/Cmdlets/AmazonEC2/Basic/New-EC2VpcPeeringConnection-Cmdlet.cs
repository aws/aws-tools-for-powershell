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
    /// Requests a VPC peering connection between two VPCs: a requester VPC that you own and
    /// a peer VPC with which to create the connection. The peer VPC can belong to another
    /// AWS account. The requester VPC and peer VPC cannot have overlapping CIDR blocks.
    /// 
    ///  
    /// <para>
    /// The owner of the peer VPC must accept the peering request to activate the peering
    /// connection. The VPC peering connection request expires after 7 days, after which it
    /// cannot be accepted or rejected.
    /// </para><para>
    /// A <code>CreateVpcPeeringConnection</code> request between VPCs with overlapping CIDR
    /// blocks results in the VPC peering connection having a status of <code>failed</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2VpcPeeringConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpcPeeringConnection")]
    [AWSCmdlet("Invokes the CreateVpcPeeringConnection operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateVpcPeeringConnection"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcPeeringConnection",
        "This cmdlet returns a VpcPeeringConnection object.",
        "The service call response (type CreateVpcPeeringConnectionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2VpcPeeringConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The AWS account ID of the owner of the peer VPC.</para><para>Default: Your AWS account ID</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String PeerOwnerId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC with which you are creating the VPC peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String PeerVpcId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the requester VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String VpcId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VpcId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VpcPeeringConnection (CreateVpcPeeringConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.PeerOwnerId = this.PeerOwnerId;
            context.PeerVpcId = this.PeerVpcId;
            context.VpcId = this.VpcId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateVpcPeeringConnectionRequest();
            
            if (cmdletContext.PeerOwnerId != null)
            {
                request.PeerOwnerId = cmdletContext.PeerOwnerId;
            }
            if (cmdletContext.PeerVpcId != null)
            {
                request.PeerVpcId = cmdletContext.PeerVpcId;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateVpcPeeringConnection(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpcPeeringConnection;
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
            public String PeerOwnerId { get; set; }
            public String PeerVpcId { get; set; }
            public String VpcId { get; set; }
        }
        
    }
}
