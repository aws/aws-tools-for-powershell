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
    /// Replaces the set of policies associated with the specified port on which the back-end
    /// server is listening with a new set of policies. At this time, only the back-end server
    /// authentication policy type can be applied to the back-end ports; this policy type
    /// is composed of multiple public key policies.
    /// 
    ///  
    /// <para>
    /// Each time you use <code>SetLoadBalancerPoliciesForBackendServer</code> to enable the
    /// policies, use the <code>PolicyNames</code> parameter to list the policies that you
    /// want to enable.
    /// </para><para>
    /// You can use <a>DescribeLoadBalancers</a> or <a>DescribeLoadBalancerPolicies</a> to
    /// verify that the policy is associated with the back-end server.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELBLoadBalancerPolicyForBackendServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetLoadBalancerPoliciesForBackendServer operation against Elastic Load Balancing.", Operation = new[] {"SetLoadBalancerPoliciesForBackendServer"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LoadBalancerName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type SetLoadBalancerPoliciesForBackendServerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetELBLoadBalancerPolicyForBackendServerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The port number associated with the back-end server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public Int32 InstancePort { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String LoadBalancerName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The names of the policies. If the list is empty, then all current polices are removed
        /// from the back-end server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyNames")]
        public System.String[] PolicyName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the LoadBalancerName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LoadBalancerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ELBLoadBalancerPolicyForBackendServer (SetLoadBalancerPoliciesForBackendServer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("InstancePort"))
                context.InstancePort = this.InstancePort;
            context.LoadBalancerName = this.LoadBalancerName;
            if (this.PolicyName != null)
            {
                context.PolicyNames = new List<String>(this.PolicyName);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SetLoadBalancerPoliciesForBackendServerRequest();
            
            if (cmdletContext.InstancePort != null)
            {
                request.InstancePort = cmdletContext.InstancePort.Value;
            }
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
                var response = client.SetLoadBalancerPoliciesForBackendServer(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.LoadBalancerName;
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
            public Int32? InstancePort { get; set; }
            public String LoadBalancerName { get; set; }
            public List<String> PolicyNames { get; set; }
        }
        
    }
}
