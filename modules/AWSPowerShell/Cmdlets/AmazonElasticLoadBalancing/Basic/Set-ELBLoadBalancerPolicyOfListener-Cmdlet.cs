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
    /// Replaces the current set of policies for the specified load balancer port with the
    /// specified set of policies.
    /// 
    ///  
    /// <para>
    /// To enable back-end server authentication, use <a>SetLoadBalancerPoliciesForBackendServer</a>.
    /// </para><para>
    /// For more information about setting policies, see <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/ssl-config-update.html">Update
    /// the SSL Negotiation Configuration</a>, <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-sticky-sessions.html#enable-sticky-sessions-duration">Duration-Based
    /// Session Stickiness</a>, and <a href="http://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-sticky-sessions.html#enable-sticky-sessions-application">Application-Controlled
    /// Session Stickiness</a> in the <i>Classic Load Balancer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELBLoadBalancerPolicyOfListener", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Elastic Load Balancing SetLoadBalancerPoliciesOfListener API operation.", Operation = new[] {"SetLoadBalancerPoliciesOfListener"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LoadBalancerName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesOfListenerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetELBLoadBalancerPolicyOfListenerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
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
        
        #region Parameter LoadBalancerPort
        /// <summary>
        /// <para>
        /// <para>The external port of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 LoadBalancerPort { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The names of the policies. This list must include all policies to be enabled. If you
        /// omit a policy that is currently enabled, it is disabled. If the list is empty, all
        /// current policies are disabled.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ELBLoadBalancerPolicyOfListener (SetLoadBalancerPoliciesOfListener)"))
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
            
            context.LoadBalancerName = this.LoadBalancerName;
            if (ParameterWasBound("LoadBalancerPort"))
                context.LoadBalancerPort = this.LoadBalancerPort;
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
            var request = new Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesOfListenerRequest();
            
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
            }
            if (cmdletContext.LoadBalancerPort != null)
            {
                request.LoadBalancerPort = cmdletContext.LoadBalancerPort.Value;
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
        
        private Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesOfListenerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.SetLoadBalancerPoliciesOfListenerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "SetLoadBalancerPoliciesOfListener");
            try
            {
                #if DESKTOP
                return client.SetLoadBalancerPoliciesOfListener(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SetLoadBalancerPoliciesOfListenerAsync(request);
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
            public System.Int32? LoadBalancerPort { get; set; }
            public List<System.String> PolicyNames { get; set; }
        }
        
    }
}
