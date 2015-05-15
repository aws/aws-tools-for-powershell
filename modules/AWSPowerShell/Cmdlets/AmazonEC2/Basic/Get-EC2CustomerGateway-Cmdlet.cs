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
    /// Describes one or more of your VPN customer gateways.
    /// 
    ///  
    /// <para>
    /// For more information about VPN customer gateways, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_VPN.html">Adding
    /// a Hardware Virtual Private Gateway to Your VPC</a> in the <i>Amazon Virtual Private
    /// Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2CustomerGateway")]
    [OutputType("Amazon.EC2.Model.CustomerGateway")]
    [AWSCmdlet("Invokes the DescribeCustomerGateways operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeCustomerGateways"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CustomerGateway",
        "This cmdlet returns a collection of CustomerGateway objects.",
        "The service call response (type DescribeCustomerGatewaysResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2CustomerGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more customer gateway IDs.</para><para>Default: Describes all your customer gateways.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("CustomerGatewayIds")]
        public System.String[] CustomerGatewayId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>bgp-asn</code> - The customer gateway's Border Gateway Protocol (BGP) Autonomous
        /// System Number (ASN).</para></li><li><para><code>customer-gateway-id</code> - The ID of the customer gateway.</para></li><li><para><code>ip-address</code> - The IP address of the customer gateway's Internet-routable
        /// external interface.</para></li><li><para><code>state</code> - The state of the customer gateway (<code>pending</code> | <code>available</code>
        /// | <code>deleting</code> | <code>deleted</code>).</para></li><li><para><code>type</code> - The type of customer gateway. Currently, the only supported type
        /// is <code>ipsec.1</code>.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.CustomerGatewayId != null)
            {
                context.CustomerGatewayIds = new List<String>(this.CustomerGatewayId);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Filter>(this.Filter);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeCustomerGatewaysRequest();
            
            if (cmdletContext.CustomerGatewayIds != null)
            {
                request.CustomerGatewayIds = cmdletContext.CustomerGatewayIds;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeCustomerGateways(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CustomerGateways;
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
            public List<String> CustomerGatewayIds { get; set; }
            public List<Filter> Filters { get; set; }
        }
        
    }
}
