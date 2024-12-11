/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// <c>ELBSample-</c> prefix.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ELBLoadBalancerPolicy")]
    [OutputType("Amazon.ElasticLoadBalancing.Model.PolicyDescription")]
    [AWSCmdlet("Calls the Elastic Load Balancing DescribeLoadBalancerPolicies API operation.", Operation = new[] {"DescribeLoadBalancerPolicies"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.PolicyDescription or Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancing.Model.PolicyDescription objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetELBLoadBalancerPolicyCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PolicyDescriptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PolicyDescriptions";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse, GetELBLoadBalancerPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoadBalancerName = this.LoadBalancerName;
            if (this.PolicyName != null)
            {
                context.PolicyName = new List<System.String>(this.PolicyName);
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
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyNames = cmdletContext.PolicyName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.DescribeLoadBalancerPoliciesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PolicyName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPoliciesResponse, GetELBLoadBalancerPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PolicyDescriptions;
        }
        
    }
}
