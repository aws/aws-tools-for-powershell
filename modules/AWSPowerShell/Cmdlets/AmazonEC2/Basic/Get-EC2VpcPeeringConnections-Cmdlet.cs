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
    /// Describes one or more of your VPC peering connections.
    /// </summary>
    [Cmdlet("Get", "EC2VpcPeeringConnections")]
    [OutputType("Amazon.EC2.Model.VpcPeeringConnection")]
    [AWSCmdlet("Invokes the DescribeVpcPeeringConnections operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeVpcPeeringConnections"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VpcPeeringConnection",
        "This cmdlet returns a collection of VpcPeeringConnection objects.",
        "The service call response (type DescribeVpcPeeringConnectionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2VpcPeeringConnectionsCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>accepter-vpc-info.cidr-block</code> - The CIDR block of the peer VPC.</para></li><li><para><code>accepter-vpc-info.owner-id</code> - The AWS account ID of the owner of the peer
        /// VPC.</para></li><li><para><code>accepter-vpc-info.vpc-id</code> - The ID of the peer VPC.</para></li><li><para><code>expiration-time</code> - The expiration date and time for the VPC peering connection.</para></li><li><para><code>requester-vpc-info.cidr-block</code> - The CIDR block of the requester's VPC.</para></li><li><para><code>requester-vpc-info.owner-id</code> - The AWS account ID of the owner of the
        /// requester VPC.</para></li><li><para><code>requester-vpc-info.vpc-id</code> - The ID of the requester VPC.</para></li><li><para><code>status-code</code> - The status of the VPC peering connection (<code>pending-acceptance</code>
        /// | <code>failed</code> | <code>expired</code> | <code>provisioning</code> | <code>active</code>
        /// | <code>deleted</code> | <code>rejected</code>).</para></li><li><para><code>status-message</code> - A message that provides more information about the status
        /// of the VPC peering connection, if applicable.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>vpc-peering-connection-id</code> - The ID of the VPC peering connection.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more VPC peering connection IDs.</para><para>Default: Describes all your VPC peering connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("VpcPeeringConnectionIds")]
        public System.String[] VpcPeeringConnectionId { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Filter != null)
            {
                context.Filters = new List<Filter>(this.Filter);
            }
            if (this.VpcPeeringConnectionId != null)
            {
                context.VpcPeeringConnectionIds = new List<String>(this.VpcPeeringConnectionId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeVpcPeeringConnectionsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.VpcPeeringConnectionIds != null)
            {
                request.VpcPeeringConnectionIds = cmdletContext.VpcPeeringConnectionIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeVpcPeeringConnections(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpcPeeringConnections;
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
            public List<Filter> Filters { get; set; }
            public List<String> VpcPeeringConnectionIds { get; set; }
        }
        
    }
}
