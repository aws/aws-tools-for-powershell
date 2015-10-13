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
    /// Describes one or more of your route tables. 
    /// 
    ///  
    /// <para>
    /// Each subnet in your VPC must be associated with a route table. If a subnet is not
    /// explicitly associated with any route table, it is implicitly associated with the main
    /// route table. This command does not return the subnet ID for implicit associations.
    /// </para><para>
    /// For more information about route tables, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_Route_Tables.html">Route
    /// Tables</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2RouteTable")]
    [OutputType("Amazon.EC2.Model.RouteTable")]
    [AWSCmdlet("Invokes the DescribeRouteTables operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeRouteTables"})]
    [AWSCmdletOutput("Amazon.EC2.Model.RouteTable",
        "This cmdlet returns a collection of RouteTable objects.",
        "The service call response (type Amazon.EC2.Model.DescribeRouteTablesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2RouteTableCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>association.route-table-association-id</code> - The ID of an association ID
        /// for the route table.</para></li><li><para><code>association.route-table-id</code> - The ID of the route table involved in the
        /// association.</para></li><li><para><code>association.subnet-id</code> - The ID of the subnet involved in the association.</para></li><li><para><code>association.main</code> - Indicates whether the route table is the main route
        /// table for the VPC.</para></li><li><para><code>route-table-id</code> - The ID of the route table.</para></li><li><para><code>route.destination-cidr-block</code> - The CIDR range specified in a route in
        /// the table.</para></li><li><para><code>route.destination-prefix-list-id</code> - The ID (prefix) of the AWS service
        /// specified in a route in the table.</para></li><li><para><code>route.gateway-id</code> - The ID of a gateway specified in a route in the table.</para></li><li><para><code>route.instance-id</code> - The ID of an instance specified in a route in the
        /// table.</para></li><li><para><code>route.origin</code> - Describes how the route was created. <code>CreateRouteTable</code>
        /// indicates that the route was automatically created when the route table was created;
        /// <code>CreateRoute</code> indicates that the route was manually added to the route
        /// table; <code>EnableVgwRoutePropagation</code> indicates that the route was propagated
        /// by route propagation.</para></li><li><para><code>route.state</code> - The state of a route in the route table (<code>active</code>
        /// | <code>blackhole</code>). The blackhole state indicates that the route's target isn't
        /// available (for example, the specified gateway isn't attached to the VPC, the specified
        /// NAT instance has been terminated, and so on).</para></li><li><para><code>route.vpc-peering-connection-id</code> - The ID of a VPC peering connection
        /// specified in a route in the table.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>vpc-id</code> - The ID of the VPC for the route table.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more route table IDs.</para><para>Default: Describes all your route tables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("RouteTableIds")]
        public System.String[] RouteTableId { get; set; }
        
        
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
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.RouteTableId != null)
            {
                context.RouteTableIds = new List<System.String>(this.RouteTableId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeRouteTablesRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.RouteTableIds != null)
            {
                request.RouteTableIds = cmdletContext.RouteTableIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeRouteTables(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RouteTables;
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
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> RouteTableIds { get; set; }
        }
        
    }
}
