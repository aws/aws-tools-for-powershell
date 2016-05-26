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
    /// Describes one or more of your Elastic IP addresses.
    /// 
    ///  
    /// <para>
    /// An Elastic IP address is for use in either the EC2-Classic platform or in a VPC. For
    /// more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
    /// IP Addresses</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2Address")]
    [OutputType("Amazon.EC2.Model.Address")]
    [AWSCmdlet("Invokes the DescribeAddresses operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeAddresses"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Address",
        "This cmdlet returns a collection of Address objects.",
        "The service call response (type Amazon.EC2.Model.DescribeAddressesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2AddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] One or more allocation IDs.</para><para>Default: Describes all your Elastic IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("AllocationIds")]
        public System.String[] AllocationId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. Filter names and values are case-sensitive.</para><ul><li><para><code>allocation-id</code> - [EC2-VPC] The allocation ID for the address.</para></li><li><para><code>association-id</code> - [EC2-VPC] The association ID for the address.</para></li><li><para><code>domain</code> - Indicates whether the address is for use in EC2-Classic (<code>standard</code>)
        /// or in a VPC (<code>vpc</code>).</para></li><li><para><code>instance-id</code> - The ID of the instance the address is associated with,
        /// if any.</para></li><li><para><code>network-interface-id</code> - [EC2-VPC] The ID of the network interface that
        /// the address is associated with, if any.</para></li><li><para><code>network-interface-owner-id</code> - The AWS account ID of the owner.</para></li><li><para><code>private-ip-address</code> - [EC2-VPC] The private IP address associated with
        /// the Elastic IP address.</para></li><li><para><code>public-ip</code> - The Elastic IP address.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter PublicIp
        /// <summary>
        /// <para>
        /// <para>[EC2-Classic] One or more Elastic IP addresses.</para><para>Default: Describes all your Elastic IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("PublicIps")]
        public System.String[] PublicIp { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AllocationId != null)
            {
                context.AllocationIds = new List<System.String>(this.AllocationId);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.PublicIp != null)
            {
                context.PublicIps = new List<System.String>(this.PublicIp);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeAddressesRequest();
            
            if (cmdletContext.AllocationIds != null)
            {
                request.AllocationIds = cmdletContext.AllocationIds;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.PublicIps != null)
            {
                request.PublicIps = cmdletContext.PublicIps;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Addresses;
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
        
        private static Amazon.EC2.Model.DescribeAddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeAddressesRequest request)
        {
            return client.DescribeAddresses(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AllocationIds { get; set; }
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> PublicIps { get; set; }
        }
        
    }
}
