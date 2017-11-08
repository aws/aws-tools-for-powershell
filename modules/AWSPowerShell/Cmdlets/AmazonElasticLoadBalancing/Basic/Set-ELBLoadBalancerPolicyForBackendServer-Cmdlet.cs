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
    /// Replaces the set of policies associated with the specified port on which the EC2 instance
    /// is listening with a new set of policies. At this time, only the back-end server authentication
    /// policy type can be applied to the instance ports; this policy type is composed of
    /// multiple public key policies.
    /// 
    ///  
    /// <para>
    /// Each time you use <code>SetLoadBalancerPoliciesForBackendServer</code> to enable the
    /// policies, use the <code>PolicyNames</code> parameter to list the policies that you
    /// want to enable.
    /// </para><para>
    /// You can use <a>DescribeLoadBalancers</a> or <a>DescribeLoadBalancerPolicies</a> to
    /// verify that the policy is associated with the EC2 instance.
    /// </para><para>
    /// For more information about enabling back-end instance authentication, see <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-create-https-ssl-load-balancer.html#configure_backendauth_clt">Configure
    /// Back-end Instance Authentication</a> in the <i>Classic Load Balancer Guide</i>. For
    /// more information about Proxy Protocol, see <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/enable-proxy-protocol.html">Configure
    /// Proxy Protocol Support</a> in the <i>Classic Load Balancer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELBLoadBalancerPolicyForBackendServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Elastic Load Balancing SetLoadBalancerPoliciesForBackendServer API operation.", Operation = new[] {"SetLoadBalancerPoliciesForBackendServer"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LoadBalancerName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesForBackendServerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetELBLoadBalancerPolicyForBackendServerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        #region Parameter InstancePort
        /// <summary>
        /// <para>
        /// <para>The port number associated with the EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 InstancePort { get; set; }
        #endregion
        
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
        /// <para>The names of the policies. If the list is empty, then all current polices are removed
        /// from the EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("PolicyNames")]
        public System.String[] PolicyName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the LoadBalancerName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("InstancePort"))
                context.InstancePort = this.InstancePort;
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
            var request = new Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesForBackendServerRequest();
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesForBackendServerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesForBackendServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "SetLoadBalancerPoliciesForBackendServer");
            try
            {
                #if DESKTOP
                return client.SetLoadBalancerPoliciesForBackendServer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SetLoadBalancerPoliciesForBackendServerAsync(request);
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
            public System.Int32? InstancePort { get; set; }
            public System.String LoadBalancerName { get; set; }
            public List<System.String> PolicyNames { get; set; }
        }
        
    }
}
