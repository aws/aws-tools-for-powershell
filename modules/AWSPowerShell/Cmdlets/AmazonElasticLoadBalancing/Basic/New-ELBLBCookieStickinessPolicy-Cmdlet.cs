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
    /// Generates a stickiness policy with sticky session lifetimes controlled by the lifetime
    /// of the browser (user-agent) or a specified expiration period. This policy can be associated
    /// only with HTTP/HTTPS listeners.
    /// 
    ///  
    /// <para>
    /// When a load balancer implements this policy, the load balancer uses a special cookie
    /// to track the back-end server instance for each request. When the load balancer receives
    /// a request, it first checks to see if this cookie is present in the request. If so,
    /// the load balancer sends the request to the application server specified in the cookie.
    /// If not, the load balancer sends the request to a server that is chosen based on the
    /// existing load-balancing algorithm.
    /// </para><para>
    /// A cookie is inserted into the response for binding subsequent requests from the same
    /// user to that server. The validity of the cookie is based on the cookie expiration
    /// time, which is specified in the policy configuration.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/US_StickySessions.html#US_EnableStickySessionsLBCookies">Duration-Based
    /// Session Stickiness</a> in the <i>Elastic Load Balancing Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELBLBCookieStickinessPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateLBCookieStickinessPolicy operation against Elastic Load Balancing.", Operation = new[] {"CreateLBCookieStickinessPolicy"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LoadBalancerName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type CreateLBCookieStickinessPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewELBLBCookieStickinessPolicyCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The time period, in seconds, after which the cookie should be considered stale. If
        /// you do not specify this parameter, the sticky session lasts for the duration of the
        /// browser session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Int64 CookieExpirationPeriod { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String LoadBalancerName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the policy being created. This name must be unique within the set of policies
        /// for this load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String PolicyName { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELBLBCookieStickinessPolicy (CreateLBCookieStickinessPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("CookieExpirationPeriod"))
                context.CookieExpirationPeriod = this.CookieExpirationPeriod;
            context.LoadBalancerName = this.LoadBalancerName;
            context.PolicyName = this.PolicyName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateLBCookieStickinessPolicyRequest();
            
            if (cmdletContext.CookieExpirationPeriod != null)
            {
                request.CookieExpirationPeriod = cmdletContext.CookieExpirationPeriod.Value;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateLBCookieStickinessPolicy(request);
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
            public Int64? CookieExpirationPeriod { get; set; }
            public String LoadBalancerName { get; set; }
            public String PolicyName { get; set; }
        }
        
    }
}
