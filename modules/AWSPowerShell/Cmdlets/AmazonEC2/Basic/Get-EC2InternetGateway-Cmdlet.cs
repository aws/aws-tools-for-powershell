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
    /// Describes one or more of your Internet gateways.
    /// </summary>
    [Cmdlet("Get", "EC2InternetGateway")]
    [OutputType("Amazon.EC2.Model.InternetGateway")]
    [AWSCmdlet("Invokes the DescribeInternetGateways operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeInternetGateways"})]
    [AWSCmdletOutput("Amazon.EC2.Model.InternetGateway",
        "This cmdlet returns a collection of InternetGateway objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInternetGatewaysResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2InternetGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>attachment.state</code> - The current state of the attachment between the gateway
        /// and the VPC (<code>available</code>). Present only if a VPC is attached.</para></li><li><para><code>attachment.vpc-id</code> - The ID of an attached VPC.</para></li><li><para><code>internet-gateway-id</code> - The ID of the Internet gateway.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
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
        #endregion
        
        #region Parameter InternetGatewayId
        /// <summary>
        /// <para>
        /// <para>One or more Internet gateway IDs.</para><para>Default: Describes all your Internet gateways.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InternetGatewayIds")]
        public System.String[] InternetGatewayId { get; set; }
        #endregion
        
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
            if (this.InternetGatewayId != null)
            {
                context.InternetGatewayIds = new List<System.String>(this.InternetGatewayId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeInternetGatewaysRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.InternetGatewayIds != null)
            {
                request.InternetGatewayIds = cmdletContext.InternetGatewayIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeInternetGateways(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InternetGateways;
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
            public List<System.String> InternetGatewayIds { get; set; }
        }
        
    }
}
