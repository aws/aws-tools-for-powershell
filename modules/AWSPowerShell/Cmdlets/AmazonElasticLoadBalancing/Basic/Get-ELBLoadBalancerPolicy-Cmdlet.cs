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
    /// Describes the specified policies.
    /// 
    ///  
    /// <para>
    /// If you specify a load balancer name, the action returns the descriptions of all policies
    /// created for the load balancer. If you specify a policy name associated with your load
    /// balancer, the action returns the description of that policy. If you don't specify
    /// a load balancer name, the action returns descriptions of the specified sample policies,
    /// or descriptions of all sample policies. The names of the sample policies have the
    /// <code>ELBSample-</code> prefix.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ELBLoadBalancerPolicy")]
    [OutputType("Amazon.ElasticLoadBalancing.Model.PolicyDescription")]
    [AWSCmdlet("Calls the Elastic Load Balancing DescribeLoadBalancerPolicies API operation.", Operation = new[] {"DescribeLoadBalancerPolicies"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.PolicyDescription",
        "This cmdlet returns a collection of PolicyDescription objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetELBLoadBalancerPolicyCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The names of the policies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyNames")]
        public System.String[] PolicyName { get; set; }
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
            
            context.LoadBalancerName = this.LoadBalancerName;
            if (this.PolicyName != null)
            {
                context.PolicyNames = new List<System.String>(this.PolicyName);
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
            var request = new Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesRequest();
            
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
            }
            if (cmdletContext.PolicyNames != null)
            {
                request.PolicyNames = cmdletContext.PolicyNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PolicyDescriptions;
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
        
        private Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "DescribeLoadBalancerPolicies");
            try
            {
                #if DESKTOP
                return client.DescribeLoadBalancerPolicies(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeLoadBalancerPoliciesAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String LoadBalancerName { get; set; }
            public List<System.String> PolicyNames { get; set; }
        }
        
    }
}
