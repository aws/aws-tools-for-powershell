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
    [AWSCmdlet("Calls the Elastic Load Balancing DescribeLoadBalancerPolicyTypes API operation.", Operation = new[] {"DescribeLoadBalancerPolicyTypes"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancing.Model.PolicyTypeDescription or Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancing.Model.PolicyTypeDescription objects.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetELBLoadBalancerPolicyTypeCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PolicyTypeName
        /// <summary>
        /// <para>
        /// <para>The names of the policy types. If no names are specified, describes all policy types
        /// defined by Elastic Load Balancing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("PolicyTypeNames")]
        public System.String[] PolicyTypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PolicyTypeDescriptions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PolicyTypeDescriptions";
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
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse, GetELBLoadBalancerPolicyTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.PolicyTypeName != null)
            {
                context.PolicyTypeName = new List<System.String>(this.PolicyTypeName);
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
            
            if (cmdletContext.PolicyTypeName != null)
            {
                request.PolicyTypeNames = cmdletContext.PolicyTypeName;
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
        
        private Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "DescribeLoadBalancerPolicyTypes");
            try
            {
                #if DESKTOP
                return client.DescribeLoadBalancerPolicyTypes(request);
                #elif CORECLR
                return client.DescribeLoadBalancerPolicyTypesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PolicyTypeName { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.DescribeLoadBalancerPolicyTypesResponse, GetELBLoadBalancerPolicyTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PolicyTypeDescriptions;
        }
        
    }
}
