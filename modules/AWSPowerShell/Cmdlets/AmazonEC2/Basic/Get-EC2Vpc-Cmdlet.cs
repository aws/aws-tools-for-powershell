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
    /// Describes one or more of your VPCs.
    /// </summary>
    [Cmdlet("Get", "EC2Vpc")]
    [OutputType("Amazon.EC2.Model.Vpc")]
    [AWSCmdlet("Invokes the DescribeVpcs operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeVpcs"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Vpc",
        "This cmdlet returns a collection of Vpc objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVpcsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2VpcCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>cidr</code> - The CIDR block of the VPC. The CIDR block you specify must exactly
        /// match the VPC's CIDR block for information to be returned for the VPC. Must contain
        /// the slash followed by one or two digits (for example, <code>/28</code>).</para></li><li><para><code>dhcp-options-id</code> - The ID of a set of DHCP options.</para></li><li><para><code>isDefault</code> - Indicates whether the VPC is the default VPC.</para></li><li><para><code>state</code> - The state of the VPC (<code>pending</code> | <code>available</code>).</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>vpc-id</code> - The ID of the VPC.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>One or more VPC IDs.</para><para>Default: Describes all your VPCs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VpcIds")]
        public System.String[] VpcId { get; set; }
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
            if (this.VpcId != null)
            {
                context.VpcIds = new List<System.String>(this.VpcId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeVpcsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.VpcIds != null)
            {
                request.VpcIds = cmdletContext.VpcIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeVpcs(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Vpcs;
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
            public List<System.String> VpcIds { get; set; }
        }
        
    }
}
