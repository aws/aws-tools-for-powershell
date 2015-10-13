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
    /// Describes one or more of your VPN connections.
    /// 
    ///  
    /// <para>
    /// For more information about VPN connections, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_VPN.html">Adding
    /// a Hardware Virtual Private Gateway to Your VPC</a> in the <i>Amazon Virtual Private
    /// Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2VpnConnection")]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Invokes the DescribeVpnConnections operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeVpnConnections"})]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection",
        "This cmdlet returns a collection of VpnConnection objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVpnConnectionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2VpnConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>customer-gateway-configuration</code> - The configuration information for the
        /// customer gateway.</para></li><li><para><code>customer-gateway-id</code> - The ID of a customer gateway associated with the
        /// VPN connection.</para></li><li><para><code>state</code> - The state of the VPN connection (<code>pending</code> | <code>available</code>
        /// | <code>deleting</code> | <code>deleted</code>).</para></li><li><para><code>option.static-routes-only</code> - Indicates whether the connection has static
        /// routes only. Used for devices that do not support Border Gateway Protocol (BGP).</para></li><li><para><code>route.destination-cidr-block</code> - The destination CIDR block. This corresponds
        /// to the subnet used in a customer data center.</para></li><li><para><code>bgp-asn</code> - The BGP Autonomous System Number (ASN) associated with a BGP
        /// device.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>type</code> - The type of VPN connection. Currently the only supported type
        /// is <code>ipsec.1</code>.</para></li><li><para><code>vpn-connection-id</code> - The ID of the VPN connection.</para></li><li><para><code>vpn-gateway-id</code> - The ID of a virtual private gateway associated with
        /// the VPN connection.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more VPN connection IDs.</para><para>Default: Describes your VPN connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VpnConnectionIds")]
        public System.String[] VpnConnectionId { get; set; }
        
        
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
            if (this.VpnConnectionId != null)
            {
                context.VpnConnectionIds = new List<System.String>(this.VpnConnectionId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeVpnConnectionsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.VpnConnectionIds != null)
            {
                request.VpnConnectionIds = cmdletContext.VpnConnectionIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeVpnConnections(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpnConnections;
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
            public List<System.String> VpnConnectionIds { get; set; }
        }
        
    }
}
