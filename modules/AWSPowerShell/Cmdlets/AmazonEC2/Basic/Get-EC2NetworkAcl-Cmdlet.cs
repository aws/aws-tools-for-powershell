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
    /// Describes one or more of your network ACLs.
    /// 
    ///  
    /// <para>
    /// For more information about network ACLs, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_ACLs.html">Network
    /// ACLs</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2NetworkAcl")]
    [OutputType("Amazon.EC2.Model.NetworkAcl")]
    [AWSCmdlet("Invokes the DescribeNetworkAcls operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeNetworkAcls"})]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkAcl",
        "This cmdlet returns a collection of NetworkAcl objects.",
        "The service call response (type Amazon.EC2.Model.DescribeNetworkAclsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2NetworkAclCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>association.association-id</code> - The ID of an association ID for the ACL.</para></li><li><para><code>association.network-acl-id</code> - The ID of the network ACL involved in the
        /// association.</para></li><li><para><code>association.subnet-id</code> - The ID of the subnet involved in the association.</para></li><li><para><code>default</code> - Indicates whether the ACL is the default network ACL for the
        /// VPC.</para></li><li><para><code>entry.cidr</code> - The CIDR range specified in the entry.</para></li><li><para><code>entry.egress</code> - Indicates whether the entry applies to egress traffic.</para></li><li><para><code>entry.icmp.code</code> - The ICMP code specified in the entry, if any.</para></li><li><para><code>entry.icmp.type</code> - The ICMP type specified in the entry, if any.</para></li><li><para><code>entry.port-range.from</code> - The start of the port range specified in the
        /// entry. </para></li><li><para><code>entry.port-range.to</code> - The end of the port range specified in the entry.
        /// </para></li><li><para><code>entry.protocol</code> - The protocol specified in the entry (<code>tcp</code>
        /// | <code>udp</code> | <code>icmp</code> or a protocol number).</para></li><li><para><code>entry.rule-action</code> - Allows or denies the matching traffic (<code>allow</code>
        /// | <code>deny</code>).</para></li><li><para><code>entry.rule-number</code> - The number of an entry (in other words, rule) in
        /// the ACL's set of entries.</para></li><li><para><code>network-acl-id</code> - The ID of the network ACL.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is independent
        /// of the <code>tag-value</code> filter. For example, if you use both the filter "tag-key=Purpose"
        /// and the filter "tag-value=X", you get any resources assigned both the tag key Purpose
        /// (regardless of what the tag's value is), and the tag value X (regardless of what the
        /// tag's key is). If you want to list only resources where Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i>
        /// filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>vpc-id</code> - The ID of the VPC for the network ACL.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter NetworkAclId
        /// <summary>
        /// <para>
        /// <para>One or more network ACL IDs.</para><para>Default: Describes all your network ACLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("NetworkAclIds")]
        public System.String[] NetworkAclId { get; set; }
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
            if (this.NetworkAclId != null)
            {
                context.NetworkAclIds = new List<System.String>(this.NetworkAclId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeNetworkAclsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.NetworkAclIds != null)
            {
                request.NetworkAclIds = cmdletContext.NetworkAclIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NetworkAcls;
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
        
        private static Amazon.EC2.Model.DescribeNetworkAclsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeNetworkAclsRequest request)
        {
            return client.DescribeNetworkAcls(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> NetworkAclIds { get; set; }
        }
        
    }
}
