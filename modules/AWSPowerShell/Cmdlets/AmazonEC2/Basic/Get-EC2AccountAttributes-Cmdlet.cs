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
    /// Describes attributes of your AWS account. The following are the supported account
    /// attributes:
    /// 
    ///  <ul><li><para><code>supported-platforms</code>: Indicates whether your account can launch instances
    /// into EC2-Classic and EC2-VPC, or only into EC2-VPC.
    /// </para></li><li><para><code>default-vpc</code>: The ID of the default VPC for your account, or <code>none</code>.
    /// </para></li><li><para><code>max-instances</code>: The maximum number of On-Demand instances that you can
    /// run.
    /// </para></li><li><para><code>vpc-max-security-groups-per-interface</code>: The maximum number of security
    /// groups that you can assign to a network interface.
    /// </para></li><li><para><code>max-elastic-ips</code>: The maximum number of Elastic IP addresses that you
    /// can allocate for use with EC2-Classic. 
    /// </para></li><li><para><code>vpc-max-elastic-ips</code>: The maximum number of Elastic IP addresses that
    /// you can allocate for use with EC2-VPC.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "EC2AccountAttributes")]
    [OutputType("Amazon.EC2.Model.AccountAttribute")]
    [AWSCmdlet("Invokes the DescribeAccountAttributes operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeAccountAttributes"})]
    [AWSCmdletOutput("Amazon.EC2.Model.AccountAttribute",
        "This cmdlet returns a collection of AccountAttribute objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAccountAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2AccountAttributesCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>One or more account attribute names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("AccountAttributeNames","AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AttributeName != null)
            {
                context.AttributeNames = new List<System.String>(this.AttributeName);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeAccountAttributesRequest();
            
            if (cmdletContext.AttributeNames != null)
            {
                request.AttributeNames = cmdletContext.AttributeNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AccountAttributes;
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
        
        private static Amazon.EC2.Model.DescribeAccountAttributesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAccountAttributesRequest request)
        {
            return client.DescribeAccountAttributes(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AttributeNames { get; set; }
        }
        
    }
}
