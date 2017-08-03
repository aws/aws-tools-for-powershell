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
    /// Describes the specified load balancer policy types or all load balancer policy types.
    /// 
    ///  
    /// <para>
    /// The description of each type indicates how it can be used. For example, some policies
    /// can be used only with layer 7 listeners, some policies can be used only with layer
    /// 4 listeners, and some policies can be used only with your EC2 instances.
    /// </para><para>
    /// You can use <a>CreateLoadBalancerPolicy</a> to create a policy configuration for any
    /// of these policy types. Then, depending on the policy type, use either <a>SetLoadBalancerPoliciesOfListener</a>
    /// or <a>SetLoadBalancerPoliciesForBackendServer</a> to set the policy.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ELBLoadBalancerPolicyType")]
    [OutputType("Amazon.ElasticLoadBalancing.Model.PolicyTypeDescription")]
    [AWSCmdlet("Invokes the DescribeLoadBalancerPolicyTypes operation against Elastic Load Balancing.", Operation = new[] {"DescribeLoadBalancerPolicyTypes"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.PolicyTypeDescription",
        "This cmdlet returns a collection of PolicyTypeDescription objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetELBLoadBalancerPolicyTypeCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.PolicyTypeName != null)
            {
                context.PolicyTypeNames = new List<System.String>(this.PolicyTypeName);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
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
        
        private Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "DescribeLoadBalancerPolicyTypes");
            #if DESKTOP
            return client.DescribeLoadBalancerPolicyTypes(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeLoadBalancerPolicyTypesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> PolicyTypeNames { get; set; }
        }
        
    }
}
