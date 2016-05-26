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
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

namespace Amazon.PowerShell.Cmdlets.ELB
{
    /// <summary>
    /// Describes the specified load balancer policy types.
    /// 
    ///  
    /// <para>
    /// You can use these policy types with <a>CreateLoadBalancerPolicy</a> to create policy
    /// configurations for a load balancer.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ELBLoadBalancerPolicyType")]
    [OutputType("Amazon.ElasticLoadBalancing.Model.PolicyTypeDescription")]
    [AWSCmdlet("Invokes the DescribeLoadBalancerPolicyTypes operation against Elastic Load Balancing.", Operation = new[] {"DescribeLoadBalancerPolicyTypes"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.PolicyTypeDescription",
        "This cmdlet returns a collection of PolicyTypeDescription objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetELBLoadBalancerPolicyTypeCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyTypeName
        /// <summary>
        /// <para>
        /// <para>The names of the policy types. If no names are specified, describes all policy types
        /// defined by Elastic Load Balancing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("PolicyTypeNames")]
        public System.String[] PolicyTypeName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.PolicyTypeName != null)
            {
                context.PolicyTypeNames = new List<System.String>(this.PolicyTypeName);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesRequest();
            
            if (cmdletContext.PolicyTypeNames != null)
            {
                request.PolicyTypeNames = cmdletContext.PolicyTypeNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PolicyTypeDescriptions;
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
        
        private static Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesRequest request)
        {
            return client.DescribeLoadBalancerPolicyTypes(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> PolicyTypeNames { get; set; }
        }
        
    }
}
