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
    /// Describes one or more of your security groups.
    /// 
    ///  
    /// <para>
    /// A security group is for use with instances either in the EC2-Classic platform or in
    /// a specific VPC. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-network-security.html">Amazon
    /// EC2 Security Groups</a> in the <i>Amazon Elastic Compute Cloud User Guide</i> and
    /// <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_SecurityGroups.html">Security
    /// Groups for Your VPC</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2SecurityGroup")]
    [OutputType("Amazon.EC2.Model.SecurityGroup")]
    [AWSCmdlet("Invokes the DescribeSecurityGroups operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeSecurityGroups"})]
    [AWSCmdletOutput("Amazon.EC2.Model.SecurityGroup",
        "This cmdlet returns a collection of SecurityGroup objects.",
        "The service call response (type DescribeSecurityGroupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2SecurityGroupCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>description</code> - The description of the security group.</para></li><li><para><code>egress.ip-permission.prefix-list-id</code> - The ID (prefix) of the AWS service
        /// to which the security group allows access.</para></li><li><para><code>group-id</code> - The ID of the security group. </para></li><li><para><code>group-name</code> - The name of the security group.</para></li><li><para><code>ip-permission.cidr</code> - A CIDR range that has been granted permission.</para></li><li><para><code>ip-permission.from-port</code> - The start of port range for the TCP and UDP
        /// protocols, or an ICMP type number.</para></li><li><para><code>ip-permission.group-id</code> - The ID of a security group that has been granted
        /// permission.</para></li><li><para><code>ip-permission.group-name</code> - The name of a security group that has been
        /// granted permission.</para></li><li><para><code>ip-permission.protocol</code> - The IP protocol for the permission (<code>tcp</code>
        /// | <code>udp</code> | <code>icmp</code> or a protocol number).</para></li><li><para><code>ip-permission.to-port</code> - The end of port range for the TCP and UDP protocols,
        /// or an ICMP code.</para></li><li><para><code>ip-permission.user-id</code> - The ID of an AWS account that has been granted
        /// permission.</para></li><li><para><code>owner-id</code> - The AWS account ID of the owner of the security group.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the security group.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the security group.</para></li><li><para><code>vpc-id</code> - The ID of the VPC specified when the security group was created.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more security group IDs. Required for security groups in a nondefault VPC.</para><para>Default: Describes all your security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("GroupIds")]
        public System.String[] GroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>[EC2-Classic and default VPC only] One or more security group names. You can specify
        /// either the security group name or the security group ID. For security groups in a
        /// nondefault VPC, use the <code>group-name</code> filter to describe security groups
        /// by name.</para><para>Default: Describes all your security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GroupNames")]
        public System.String[] GroupName { get; set; }
        
        
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
            if (this.GroupId != null)
            {
                context.GroupIds = new List<String>(this.GroupId);
            }
            if (this.GroupName != null)
            {
                context.GroupNames = new List<String>(this.GroupName);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DescribeSecurityGroupsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.GroupIds != null)
            {
                request.GroupIds = cmdletContext.GroupIds;
            }
            if (cmdletContext.GroupNames != null)
            {
                request.GroupNames = cmdletContext.GroupNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeSecurityGroups(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SecurityGroups;
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
            public List<String> GroupIds { get; set; }
            public List<String> GroupNames { get; set; }
        }
        
    }
}
